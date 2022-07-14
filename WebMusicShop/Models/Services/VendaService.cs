using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IVenda;

namespace WebMusicShop.Models.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public void CadastraVendaService(Venda venda)
        {
            try
            {
                _vendaRepository.CadastraVendaRepository(venda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Venda> ListarVendasService()
        {
            try
            {
                List<Venda> vendas = _vendaRepository.ListarVendasRepository();
                return vendas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
