using System.Data.SqlClient;

namespace WebMusicShop.Models.Interfaces
{
    public interface IConnectionManager
    {
        public SqlConnection GetConnection(string connStrName);
    }
}
