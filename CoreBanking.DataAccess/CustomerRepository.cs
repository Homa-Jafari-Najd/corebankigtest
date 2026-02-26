using System.Data;
using CoreBanking.Entities;
using CoreBanking.DataAccess.Abstractions;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace CoreBanking.DataAccess
{
    public class CustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in App.config");
        }

        public DataTable SearchByNationalCode(string nationalCode)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("dbo.SearchCustomerByNationalCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NationalCode", nationalCode);

            var table = new DataTable();
            using var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            return table;
        }
    }
}