using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IProduto;

namespace WebMusicShop.Models.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IProdutoContext _produtoContext;

        public ProdutoRepository(IProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }


        public void CadastraProdutoRepository(Produto produto)
        {
            _produtoContext.CadastraProdutoContext(produto);
        }

        public List<Produto> ListarProdutosRepository()
        {
            List<Produto> produtos = _produtoContext.ListarProdutosContext();
            return produtos;
        }
        public void AtualizarProdutoRepository(Produto produto)
        {
            _produtoContext.AtualizarProdutoContext(produto);
        }

        public void DeletaProdutoRepository(int id)
        {
            _produtoContext.DeletaProdutoContext(id);
        }
    }
}
