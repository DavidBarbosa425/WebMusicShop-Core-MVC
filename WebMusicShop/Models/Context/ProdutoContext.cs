using System.Data;
using System.Data.SqlClient;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces;
using WebMusicShop.Models.Interfaces.IProduto;

namespace WebMusicShop.Models.Context
{
    public class ProdutoContext : IProdutoContext
    {
        private readonly SqlConnection _connection;

        public ProdutoContext(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }


        public void CadastraProdutoContext(Produto produto)
        {
            try
            {
                string proc = "SpIns_Produto";
                SqlCommand cmdIns = new SqlCommand(proc, _connection);
                cmdIns.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                cmdIns.Parameters.Add("Tipo", SqlDbType.VarChar).Value = produto.Tipo;
                cmdIns.Parameters.Add("Descricao", SqlDbType.VarChar).Value = produto.Descricao;
                cmdIns.Parameters.Add("PrecoCusto", SqlDbType.Decimal).Value = produto.PrecoCusto.Replace("R$","");
                cmdIns.Parameters.Add("PrecoVenda", SqlDbType.Decimal).Value = produto.PrecoVenda.Replace("R$", "");
                cmdIns.Parameters.Add("QtdEstoque", SqlDbType.VarChar).Value = produto.QtdEstoque;
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
        public List<Produto> ListarProdutosContext()
        {
            try
            {
                List<Produto> produtos = new List<Produto>();
                string proc = "SpSel_produtos";
                SqlCommand cmdSel = new SqlCommand(proc, _connection);
                cmdSel.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                SqlDataReader dataReader = cmdSel.ExecuteReader();

                while (dataReader.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = dataReader.GetInt32("Id");
                    produto.Tipo = dataReader.GetString("Tipo");
                    produto.Descricao = dataReader.GetString("Descricao");
                    produto.PrecoCusto = dataReader.GetDecimal("PrecoCusto").ToString("C");
                    produto.PrecoVenda = dataReader.GetDecimal("PrecoVenda").ToString("C");
                    produto.QtdEstoque = dataReader.GetInt32("QtdEstoque");
                    produtos.Add(produto);
                }
                return produtos;
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
        public void AtualizarProdutoContext(Produto produto)
        {
            try
            {
                string proc = "SpUpd_Produto";
                SqlCommand cmdUpd = new SqlCommand(proc, _connection);
                cmdUpd.CommandType = CommandType.StoredProcedure;

                _connection.Open();
                cmdUpd.Parameters.Add("Id", SqlDbType.Int).Value = produto.Id;
                cmdUpd.Parameters.Add("Tipo", SqlDbType.VarChar).Value = produto.Tipo;
                cmdUpd.Parameters.Add("Descricao", SqlDbType.VarChar).Value = produto.Descricao;
                cmdUpd.Parameters.Add("PrecoCusto", SqlDbType.Decimal).Value = produto.PrecoCusto.Replace("R$", "");
                cmdUpd.Parameters.Add("PrecoVenda", SqlDbType.Decimal).Value = produto.PrecoVenda.Replace("R$", "");
                cmdUpd.Parameters.Add("QtdEstoque", SqlDbType.Int).Value = produto.QtdEstoque;
                cmdUpd.ExecuteNonQuery();
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

        public void DeletaProdutoContext(int id)
        {
            try
            {
                string proc = "SpDel_Produto";
                SqlCommand cmdDel = new SqlCommand(proc, _connection);
                cmdDel.CommandType = CommandType.StoredProcedure;
                _connection.Open();

                cmdDel.Parameters.Add("Id", SqlDbType.Int).Value = id;
                cmdDel.ExecuteNonQuery();
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
