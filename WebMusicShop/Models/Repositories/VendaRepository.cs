using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IVenda;

namespace WebMusicShop.Models.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly IVendaContext _vendaContext;

        public VendaRepository(IVendaContext vendaContext)
        {
            _vendaContext = vendaContext;
        }

        public void CadastraVendaRepository(Venda venda)
        {
            _vendaContext.CadastraVendaContext(venda);            
        }

        public List<Venda> ListarVendasRepository()
        {
            List<Venda> vendas = _vendaContext.ListarVendasContext();
            return vendas;
        }
        public void AtualizaVendaRepository(Venda venda)
        {
            _vendaContext.AtualizaVendaContext(venda);
        }

        public void DeletaVendaRepository(int id)
        {
            _vendaContext.DeletaVendaContext(id);
        }
    }
}
