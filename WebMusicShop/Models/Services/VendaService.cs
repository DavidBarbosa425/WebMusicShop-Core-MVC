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

        public Venda BuscaVendaService(int id)
        {
            Venda? venda =_vendaRepository.ListarVendasRepository().Find(x => x.Id == id);
            return venda;
        }
        public void AtualizaVendaService(Venda venda)
        {
            _vendaRepository.AtualizaVendaRepository(venda);
        }
        public void DeletaVendaService(int id)
        {
            try
            {
                _vendaRepository.DeletaVendaRepository(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
