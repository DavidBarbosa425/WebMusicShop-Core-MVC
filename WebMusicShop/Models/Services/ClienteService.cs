using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.ICliente;

namespace WebMusicShop.Models.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CadastrarClienteService(Cliente cliente)
        {
            try
            {
                _clienteRepository.CadastrarClienteRepository(cliente);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
   
        }
    }
}
