using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IVenda
{
    public interface IVendaContext
    {
        void CadastraVendaContext(Venda venda);
        List<Venda> ListarVendasContext();
        void AtualizaVendaContext(Venda venda);
    }
}
