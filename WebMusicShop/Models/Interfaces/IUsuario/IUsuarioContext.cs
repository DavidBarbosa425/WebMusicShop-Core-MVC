using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IUsuario
{
    public interface IUsuarioContext
    {
        void CadastraUsuarioContext(Usuario usuario);
        List<Usuario> ListarUsuariosContext();
    }
}
