using System.Data.SqlClient;
using WebMusicShop.Models.Interfaces;

namespace WebMusicShop.Models.Context
{
    public class ConnectionManager : IConnectionManager
    {
        private static string _connStrName = "MusicShop";
        private static SqlConnection connection = null;

        public ConnectionManager(IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString(_connStrName);
            if (connection == null)
                connection = new SqlConnection(connStr);
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
