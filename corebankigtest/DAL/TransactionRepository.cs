using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using corebankigtest.Entities;
using Microsoft.Data.SqlClient;

namespace corebankigtest.DAL
{
    public class TransactionRepository
    {
        private readonly string _cs;

        public TransactionRepository()
        {
            _cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        }

        public List<Transaction> GetByAccountId(int accountId)
        {
            var list = new List<Transaction>();

            using var con = new SqlConnection(_cs);
            using var cmd = new SqlCommand(@"
                SELECT TransactionId, AccountId, Amount, Type, TransactionDate
                FROM Transactions
                WHERE AccountId = @AccountId
                ORDER BY TransactionDate DESC, TransactionId DESC
            ", con);

            cmd.Parameters.AddWithValue("@AccountId", accountId);

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
            using (var conn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("dbo.sp_DeleteTransactionAndRevertBalance", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionId", transactionId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Insert(int accountId, decimal amount, string type)
        {
            using var con = new SqlConnection(_cs);
            using var cmd = new SqlCommand(@"
             INSERT INTO Transactions (AccountId,Amount,Type,TransactionDate)
             VALUES(@AccountId,@Amount,@Type,GETDATE());", con);
            cmd.Parameters.AddWithValue("@AccountId", accountId);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@Type", type);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}