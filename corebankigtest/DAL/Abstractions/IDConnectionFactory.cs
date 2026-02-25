using System.Data;
using Microsoft.Data.SqlClient;

namespace corebankigtest.DAL.Abstractions
{
    public interface IDConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
