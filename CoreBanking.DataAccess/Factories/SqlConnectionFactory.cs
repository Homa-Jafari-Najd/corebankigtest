using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CoreBanking.DataAccess.Abstractions;
using Microsoft.Data.SqlClient;


namespace CoreBanking.DataAccess.Factories
{
    public class SqlConnectionFactory : IDConnectionFactory
    {
        private readonly string _connectionString;
        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
