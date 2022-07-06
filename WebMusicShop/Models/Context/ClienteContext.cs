using System.Data;
using System.Data.SqlClient;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.ICliente;

namespace WebMusicShop.Models.Context
{
    public class ClienteContext : IClienteContext
    {
        private readonly SqlConnection _connection;

        public ClienteContext(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection("MusicShop");
        }
        public void CadastrarClienteContext(Cliente cliente)
        {
            try
            {
                string proc = "exec SpIns_Cliente";
                SqlCommand commIns = new SqlCommand(proc, _connection);
                commIns.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                commIns.Parameters.Add("@Nome", SqlDbType.VarChar).Value = cliente.Nome;
                commIns.Parameters.Add("@CPF", SqlDbType.VarChar).Value = cliente.CPF;
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
