using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IProduto
{
    public interface IProdutoService
    {
        void CadastraProdutoService(Produto produto);
        List<Produto> ListarProdutosService();
        Produto BuscaProdutoService(int id);
    }
}
