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

        public List<Cliente> ListarClientesService()
        {
            try
            {
                List<Cliente> Clientes = _clienteRepository.ListarClientesRepository();
                List<Cliente> clientesOrdenados = Clientes.Where(x => x.Nome != null).OrderBy(x => x.Id).ToList();
                return clientesOrdenados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Cliente BuscaCliente(int id)
        {
            try
            {
                List<Cliente> Clientes = _clienteRepository.ListarClientesRepository();
                Cliente cliente = Clientes.Find(x => x.Id == id);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizarClienteService(Cliente cliente)
        {

            _clienteRepository.AtualizaClienteRepository(cliente);
        }

        public void DeletarClienteService(int id)
        {
            _clienteRepository.DeletarClienteRepository(id);
        }
    }
}
