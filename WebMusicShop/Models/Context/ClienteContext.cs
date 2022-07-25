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
                commIns.Parameters.Add("@Email", SqlDbType.VarChar).Value = cliente.Email;
                commIns.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = cliente.Telefone;
                commIns.Parameters.Add("@StatusId", SqlDbType.Int).Value =cliente.StatusEnum;
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
                    cliente.Email = dataReader.GetString("Email");
                    cliente.Telefone = dataReader.GetString("Telefone");
                    cliente.Status = dataReader.GetString("Status");
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
        public void AtualizarClienteContext(Cliente cliente)
        {
            try
            {
                string proc = "SpUpd_Cliente";
                SqlCommand commIns = new SqlCommand(proc, _connection);
                commIns.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                commIns.Parameters.Add("Id", SqlDbType.Int).Value = cliente.Id;
                commIns.Parameters.Add("Nome", SqlDbType.VarChar).Value = cliente.Nome;
                commIns.Parameters.Add("CPF", SqlDbType.VarChar).Value = cliente.CPF;
                commIns.Parameters.Add("Email", SqlDbType.VarChar).Value = cliente.Email;
                commIns.Parameters.Add("Telefone", SqlDbType.VarChar).Value = cliente.Telefone;
                commIns.Parameters.Add("StatusId", SqlDbType.Int).Value = cliente.StatusEnum;
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

        public void DeletarClienteContext(int id)
        {
            try
            {
                string proc = "SpDel_Cliente";
                SqlCommand commDel = new SqlCommand(proc, _connection);
                commDel.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                commDel.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                commDel.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { _connection.Close(); }
        }
    }
}
