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

        public List<Venda> ListarVendasContext()
        {
            try
            {
                List<Venda> Vendas = new List<Venda>();
                string proc = "SpSel_Venda";
                SqlCommand cmdSel = new SqlCommand(proc, _connection);
                cmdSel.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                SqlDataReader dataReader = cmdSel.ExecuteReader();

                while (dataReader.Read())
                {
                    Venda venda = new Venda();
                    venda.Id = dataReader.GetInt32("VendaId");
                    venda.ProdutoId = dataReader.GetInt32("ProdutoId");
                    venda.Produto = dataReader.GetString("Produto");
                    venda.ClienteId = dataReader.GetInt32("ClienteId");
                    venda.Cliente = dataReader.GetString("nomeCliente");
                    venda.UsuarioId = dataReader.GetInt32("UsuarioId");
                    venda.Usuario = dataReader.GetString("nomeUsuario");
                    venda.DataVenda = dataReader.IsDBNull("DataVenda") ? null : dataReader.GetDateTime("DataVenda");
                    venda.Quantidade = dataReader.GetInt32("Quantidade");
                    venda.DataAlteracao = dataReader.IsDBNull("DataAlteracao") ? null : dataReader.GetDateTime("DataAlteracao");
                    Vendas.Add(venda);
                }
                return Vendas;
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
