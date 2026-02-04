using System.Data;
using System.Data.SqlClient;
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


    }
}