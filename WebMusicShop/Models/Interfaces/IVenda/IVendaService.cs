using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IVenda
{
    public interface IVendaService
    {
        void CadastraVendaService(Venda venda);
        List<Venda> ListarVendasService();
        Venda BuscaVendaService(int id);
        void AtualizaVendaService(Venda venda);
        void DeletaVendaService(int id);
    }
}
