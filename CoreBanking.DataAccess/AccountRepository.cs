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

        public void UpdateBalance(int Id, decimal amount, string type)
        {
            using var con = _connectionFactory.CreateConnection();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = (SqlConnection)con;

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
            using SqlConnection cn = (SqlConnection)_connectionFactory.CreateConnection();
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
    }
}