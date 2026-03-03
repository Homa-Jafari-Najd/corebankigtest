using System.Data;
using CoreBanking.Entities;
using CoreBanking.DataAccess.Abstractions;

namespace CoreBanking.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly IDConnectionFactory _factory;
        public TransactionRepository(IDConnectionFactory factory)
        {
            _factory = factory;
        }

        public List<Transaction> GetByAccountId(int accountId)
        {
            var list = new List<Transaction>();

            using var con = _factory.CreateConnection();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
                SELECT TransactionId, AccountId, Amount, Type, TransactionDate
                FROM Transactions
                WHERE AccountId = @AccountId
                ORDER BY TransactionDate DESC, TransactionId DESC
            ";

            var p = cmd.CreateParameter();
            p.ParameterName = "@AccountId";
            p.Value = accountId;
            cmd.Parameters.Add(p);
            con.Open();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Transaction
                {
                    TransactionId = r.GetInt32(0),
                    AccountId = r.GetInt32(1),
                    Amount = r.GetDecimal(2),
                    Type = r.GetString(3),
                    TransactionDate = r.IsDBNull(4) ? (DateTime?)null : r.GetDateTime(4)
                });
            }

            return list;
        }
        public void DeleteTransactionAndRevertBalance(int transactionId)
        {
            using var con = _factory.CreateConnection();
            con.Open();

            using var cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.sp_DeleteTransactionAndRevertBalance";

            var p = cmd.CreateParameter();
            p.ParameterName = "@TransactionId";
            p.Value = transactionId;
            cmd.Parameters.Add(p);

            cmd.ExecuteNonQuery();
        }
        public void Insert(int accountId, decimal amount, string type)
        {
            using var con = _factory.CreateConnection();
            con.Open();

            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
INSERT INTO Transactions (AccountId, Amount, Type, TransactionDate)
VALUES (@AccountId, @Amount, @Type, GETDATE());

UPDATE Account
SET Balance = (
    SELECT ISNULL(SUM(
  CASE
    WHEN LTRIM(RTRIM(LOWER(Type))) = 'deposit' THEN Amount
    WHEN LTRIM(RTRIM(LOWER(Type))) = 'withdraw' THEN -Amount
    ELSE 0
END
    ), 0)
    FROM Transactions
    WHERE AccountId = @AccountId
)
WHERE Id = @AccountId;
";

            var p1 = cmd.CreateParameter();
            p1.ParameterName = "@AccountId";
            p1.Value = accountId;
            cmd.Parameters.Add(p1);

            var p2 = cmd.CreateParameter();
            p2.ParameterName = "@Amount";
            p2.Value = amount;
            cmd.Parameters.Add(p2);

            var p3 = cmd.CreateParameter();
            p3.ParameterName = "@Type";
            p3.Value = type;
            cmd.Parameters.Add(p3);

            cmd.ExecuteNonQuery();
        }


        public void UpdateTransaction(int transactionId, decimal amount, string type)
        {
            using var con = _factory.CreateConnection();
            con.Open();

            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
UPDATE Transactions
SET Amount = @Amount,
    Type = @Type
WHERE Id = @TransactionId;

UPDATE Account
SET Balance = (
    SELECT ISNULL(SUM(
        CASE
            WHEN Type = 'Deposit' THEN Amount
            WHEN Type = 'Withdraw' THEN -Amount
            ELSE 0
        END
    ), 0)
    FROM Transactions
    WHERE AccountId = (
        SELECT AccountId FROM Transactions WHERE Id = @TransactionId
    )
)
WHERE Id = (
    SELECT AccountId FROM Transactions WHERE Id = @TransactionId
);
";

            var p1 = cmd.CreateParameter();
            p1.ParameterName = "@Amount";
            p1.Value = amount;
            cmd.Parameters.Add(p1);

            var p2 = cmd.CreateParameter();
            p2.ParameterName = "@Type";
            p2.Value = type;
            cmd.Parameters.Add(p2);

            var p3 = cmd.CreateParameter();
            p3.ParameterName = "@TransactionId";
            p3.Value = transactionId;
            cmd.Parameters.Add(p3);

            cmd.ExecuteNonQuery();
        }
    }
}