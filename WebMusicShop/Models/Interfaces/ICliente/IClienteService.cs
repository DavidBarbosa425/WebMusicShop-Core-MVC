using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.ICliente
{
    public interface IClienteService
    {
        void CadastrarClienteService(Cliente cliente);
        List<Cliente> ListarClientesService();
        Cliente BuscaCliente(int id);
    }
}
