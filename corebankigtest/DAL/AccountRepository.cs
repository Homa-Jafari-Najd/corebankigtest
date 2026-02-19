using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using corebankigtest.Entities;

namespace corebankigtest.DAL
{
    public class AccountRepository
    {
        private readonly string _cs;

        public AccountRepository()
        {
            _cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        }
        public List<AccountComboItem> GetAccountsForCombo()
        {
            var list = new List<AccountComboItem>();
            using var con = new SqlConnection(_cs);
            using var cmd = new SqlCommand(@"
                   Select Id,AccountNumber from Account
                   order By AccountNumber;", con);
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
            using (var con = new SqlConnection(_cs))
            {
                using (var cmd = new SqlCommand("sp_GETAccountsPaged", con))
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
        }

        public int GetTotalAccounts(string search)
        {
            using (var con = new SqlConnection(_cs))
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
        ", con))
                {
                    cmd.Parameters.AddWithValue("@search", search);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public List<Account> GetAccounts()
        {
            var accounts = new List<Account>();

            using (SqlConnection con = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("sp_GetAccounts", con))
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

        public void UpdateBalance(int Id, decimal amount, string type)
        {
            using (var con = new SqlConnection(_cs))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;

                if (type == "Deposit")
                {
                    cmd.CommandText = "UPDATE Account SET Balance = Balance + @Amount WHERE Id = @Id";
                }
                else
                {
                    cmd.CommandText = "UPDATE Account SET Balance = Balance - @Amount WHERE Id = @Id";
                }

                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public decimal GetBalance(int Id)
        {
            using (SqlConnection cn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT Balance FROM dbo.Account WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", Id);
                cn.Open();

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new Exception("Account not found.");

                return Convert.ToDecimal(result);
            }
        }
    }
}