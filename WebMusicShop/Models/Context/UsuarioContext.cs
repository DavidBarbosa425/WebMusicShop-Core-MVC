using System.Data;
using System.Data.SqlClient;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Models.Context
{
    public class UsuarioContext : IUsuarioContext
    {
        private readonly SqlConnection _connection;
        public UsuarioContext(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }
        public void CadastraUsuarioContext(Usuario usuario)
        {
            try
            {
                string proc = "SpIns_Usuario";
                SqlCommand cmdIns = new SqlCommand(proc, _connection);
                cmdIns.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                cmdIns.Parameters.Add("Nome", SqlDbType.VarChar).Value = usuario.Nome;
                cmdIns.Parameters.Add("CPF", SqlDbType.VarChar).Value = usuario.CPF;
                cmdIns.Parameters.Add("Email", SqlDbType.VarChar).Value = usuario.Email;
                cmdIns.Parameters.Add("StatusId", SqlDbType.Int).Value = Convert.ToInt32(usuario.Status);
                cmdIns.ExecuteNonQuery();
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

        public List<Usuario> ListarUsuariosContext()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                string proc = "SpSel_Usuario";
                SqlCommand cmdSel = new SqlCommand(proc, _connection);
                cmdSel.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                SqlDataReader dataReader = cmdSel.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = dataReader.GetInt32("Id");
                    usuario.Nome = dataReader.GetString("Nome");
                    usuario.CPF = dataReader.GetString("CPF");
                    usuario.Email = dataReader.GetString("Email");
                    usuario.Status = dataReader.GetString("Status");
                    usuarios.Add(usuario);
                }
                return usuarios;
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
