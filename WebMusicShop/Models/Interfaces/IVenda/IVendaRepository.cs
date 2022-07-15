using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IVenda
{
    public interface IVendaRepository
    {
        void CadastraVendaRepository(Venda venda);
        List<Venda> ListarVendasRepository();
        void AtualizaVendaRepository(Venda venda);
        void DeletaVendaRepository(int id);
    }
}
