using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.ICliente;

namespace WebMusicShop.Models.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClienteContext _context;

        public ClienteRepository(IClienteContext context)
        {
            _context = context;
        }


        void IClienteRepository.CadastrarClienteRepository(Cliente cliente)
        {
           _context.CadastrarClienteContext(cliente);
        }
        public List<Cliente> ListarClientesRepository()
        {
           List<Cliente> Clientes = _context.ListarClientesContext();
           return Clientes;
        }

        public void AtualizaClienteRepository(Cliente cliente)
        {
            _context.AtualizarClienteContext(cliente);
        }

        public void DeletarClienteRepository(int id)
        {
            _context.DeletarClienteContext(id);
        }
    }
}
