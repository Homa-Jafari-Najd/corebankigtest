using System.Data;
using CoreBanking.Entities;
using CoreBanking.DataAccess.Abstractions;
using Microsoft.Data.SqlClient;


namespace CoreBanking.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDConnectionFactory _connectionFactory;
        public AccountRepository(IDConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<AccountComboItem> GetAccountsForCombo()
        {
            var list = new List<AccountComboItem>();
            using var con = (SqlConnection)_connectionFactory.CreateConnection();
            using var cmd = new SqlCommand(@"
                   Select Id,AccountNumber from Account
                   order By AccountNumber;", (SqlConnection)con);
            con.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new AccountComboItem
                {
                    AccountId = r.GetInt32(0),
                    DisplayText = r.GetString(1)
                });
            }
            return list;
        }
        public DataTable GetAccountsPaged(int pageNumber, int pageSize, string search)
        {
            using var con = _connectionFactory.CreateConnection();

            using (var cmd = new SqlCommand("sp_GETAccountsPaged", (SqlConnection)con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                cmd.Parameters.AddWithValue("@Search", search);

                var dt = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public int GetTotalAccounts(string search)
        {
            using var con = _connectionFactory.CreateConnection();
            {
                con.Open();
                using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM Account a
                        INNER JOIN Customer c ON c.Id = a.CustomerId
                        WHERE
                        (@search = ''
                        OR a.AccountNumber LIKE '%' + @search + '%'
                        OR REPLACE(c.NationalCode,'-','') LIKE '%' + REPLACE(@search,'-','') + '%'
                        OR (c.FirstName + ' ' + c.LastName) LIKE '%' + @search + '%')
        ", (SqlConnection)con))
                {
                    cmd.Parameters.AddWithValue("@search", search);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public List<Account> GetAccounts()
        {
            var accounts = new List<Account>();

            using var con = _connectionFactory.CreateConnection();
            using var cmd = new SqlCommand("sp_GetAccounts", (SqlConnection)con);
            {
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            AccountNumber = reader["AccountNumber"].ToString(),
                            Balance = Convert.ToDecimal(reader["Balance"]),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                            FullName = reader["FullName"].ToString()
                        });
                    }
                }
            }

            return accounts;
        }

        public void UpdateTransaction(int accountId, decimal amount, string type)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();

            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
        UPDATE Transactions
        SET Amount = @Amount,
            Type = @Type
        WHERE Id = @TransactionId;

        UPDATE Account
        SET Balance = (
            SELECT ISNULL(SUM(Amount), 0)
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
            p3.Value = accountId;
            cmd.Parameters.Add(p3);

            cmd.ExecuteNonQuery();
        }



        public decimal GetBalance(int accountId)
        {
            using var cn = (SqlConnection)_connectionFactory.CreateConnection();
            using var cmd = new SqlCommand(@"
        SELECT ISNULL(SUM(
            CASE 
                WHEN Type = 'Deposit' THEN Amount
                WHEN Type = 'Withdraw' THEN -Amount
            END
        ), 0)
        FROM Transactions
        WHERE AccountId = @accountId", cn);

            cmd.Parameters.AddWithValue("@accountId", accountId);

            cn.Open();

            object result = cmd.ExecuteScalar();

            return Convert.ToDecimal(result);
        }
        public User? GetUserByUsernamePassword(string username, string password)
        {
            using var con = _connectionFactory.CreateConnection();
            con.Open();

            using var cmd = new SqlCommand(@"
        SELECT TOP 1 Id, Username, Role, ISActive
        FROM dbo.Users
        WHERE Username = @username AND Password = @password AND ISActive = 1
    ", (SqlConnection)con);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var r = cmd.ExecuteReader();
            if (!r.Read())
                return null;

            return new User
            {
                Id = Convert.ToInt32(r["Id"]),
                Username = r["Username"].ToString() ?? "",
                Role = r["Role"].ToString() ?? "",
                IsActive = Convert.ToBoolean(r["ISActive"])
            };
        }

    

    public void UpdateBalance(int accountId, decimal amount, string type)
        {
            type = (type ?? "").Trim();
            amount = Math.Abs(amount);

            using var con = _connectionFactory.CreateConnection();
            con.Open();

            using var cmd = con.CreateCommand();

            if (string.Equals(type, "Deposit", StringComparison.OrdinalIgnoreCase))
                cmd.CommandText = "UPDATE Account SET Balance = Balance + @Amount WHERE Id = @accountId";
            else if (string.Equals(type, "Withdraw", StringComparison.OrdinalIgnoreCase))
                cmd.CommandText = "UPDATE Account SET Balance = Balance - @Amount WHERE Id = @accountId";
            else
                throw new Exception("Invalid transaction type: " + type);

            var p1 = cmd.CreateParameter();
            p1.ParameterName = "@Amount";
            p1.Value = amount;
            cmd.Parameters.Add(p1);

            var p2 = cmd.CreateParameter();
            p2.ParameterName = "@accountId";
            p2.Value = accountId;
            cmd.Parameters.Add(p2);

            cmd.ExecuteNonQuery();
        }

    }
}