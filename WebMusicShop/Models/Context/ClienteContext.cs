using System.Data.SqlClient;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces;

namespace WebMusicShop.Models.Context
{
    public class ClienteContext : IClienteContext
    {
        private readonly SqlConnection _connection;

        public ClienteContext(ConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection("MusicShop");
        }
        public void CadastrarClienteContext(Cliente cliente)
        {
            try
            {
                string proc = "exec SpIns_Cliente @Nome,@CPF";
                SqlCommand commIns = new SqlCommand(proc, _connection);

                _connection.Open();
                commIns.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = cliente.Nome;
                commIns.Parameters.Add("@CPF", System.Data.SqlDbType.VarChar).Value = cliente.CPF;
                commIns.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
