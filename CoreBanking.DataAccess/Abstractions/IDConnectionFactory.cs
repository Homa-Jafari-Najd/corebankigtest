using System.Data;
using Microsoft.Data.SqlClient;

namespace CoreBanking.DataAccess.Abstractions
{
    public interface IDConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
