using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.ICliente
{
    public interface IClienteRepository
    {
        void CadastrarClienteRepository(Cliente cliente);
        List<Cliente> ListarClientesRepository();
    }
}
