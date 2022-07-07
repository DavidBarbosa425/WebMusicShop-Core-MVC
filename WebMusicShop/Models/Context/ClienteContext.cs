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
            _connection = connectionManager.GetConnection();
        }


        public void CadastrarClienteContext(Cliente cliente)
        {
            try
            {
                string proc = "SpIns_Cliente";
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

        public List<Cliente> ListarClientesContext()
        {
            List<Cliente> Clientes = new List<Cliente>();

            try
            {
                string proc = "SpSel_Cliente";
                SqlCommand commSel = new SqlCommand(proc, _connection);
                commSel.CommandType = CommandType.StoredProcedure;

                _connection.Open();

                SqlDataReader dataReader = commSel.ExecuteReader();

                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = dataReader.GetInt32("Id");
                    cliente.Nome = dataReader.GetString("Nome");
                    cliente.CPF = dataReader.GetString("CPF");
                    Clientes.Add(cliente);
                }

                return Clientes;
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
