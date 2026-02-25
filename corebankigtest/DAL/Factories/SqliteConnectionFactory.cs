using System.Data;
using Microsoft.Data.Sqlite;
using corebankigtest.DAL.Abstractions;

namespace corebankigtest.DAL.Factories
{
    public class SqliteConnectionFactory : IDConnectionFactory
    {
        private readonly string _connectionString;

        public SqliteConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}