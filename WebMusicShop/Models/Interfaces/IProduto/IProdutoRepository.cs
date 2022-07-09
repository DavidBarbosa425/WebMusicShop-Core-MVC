using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IProduto
{
    public interface IProdutoRepository
    {
        void CadastraProdutoRepository(Produto produto);
        List<Produto> ListarProdutosRepository();
        void AtualizarProdutoRepository(Produto produto);
    }
}
