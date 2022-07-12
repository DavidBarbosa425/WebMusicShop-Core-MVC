using System.Data;
using System.Data.SqlClient;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.IVenda;

namespace WebMusicShop.Models.Context
{
    public class VendaContext : IVendaContext
    {
        private readonly SqlConnection _connection;

        public VendaContext(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }
        public void CadastraVendaContext(Venda venda)
        {
            try
            {
                string proc = "SpIns_Venda";
                SqlCommand cmdIns = new SqlCommand(proc, _connection);
                cmdIns.CommandType = CommandType.StoredProcedure;

                _connection.Open();

                cmdIns.Parameters.Add("ProdutoId", SqlDbType.Int).Value = venda.ProdutoId;
                cmdIns.Parameters.Add("ClienteId", SqlDbType.Int).Value = venda.ClienteId;
                cmdIns.Parameters.Add("UsuarioId", SqlDbType.Int).Value = venda.UsuarioId;
                cmdIns.Parameters.Add("Quantidade", SqlDbType.Int).Value = venda.Quantidade;

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
    }
}
