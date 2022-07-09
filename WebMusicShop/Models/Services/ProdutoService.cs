using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IProduto;

namespace WebMusicShop.Models.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void CadastraProdutoService(Produto produto)
        {
            try
            {
                _produtoRepository.CadastraProdutoRepository(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public List<Produto> ListarProdutosService()
        {
            try
            {
                List<Produto> produtos = _produtoRepository.ListarProdutosRepository();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
