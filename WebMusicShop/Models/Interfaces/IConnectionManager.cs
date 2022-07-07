using System.Data.SqlClient;

namespace WebMusicShop.Models.Interfaces
{
    public interface IConnectionManager
    {
       SqlConnection GetConnection();
    
    }
}
