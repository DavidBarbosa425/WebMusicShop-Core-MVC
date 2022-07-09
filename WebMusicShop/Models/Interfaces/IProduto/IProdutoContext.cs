using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IProduto
{
    public interface IProdutoContext
    {
        void CadastraProdutoContext(Produto produto);
        List<Produto> ListarProdutosContext();
        void AtualizarProdutoContext(Produto produto);
    }
}
