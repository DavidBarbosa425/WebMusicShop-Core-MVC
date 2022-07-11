using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IUsuario
{
    public interface IUsuarioRepository
    {
        void CadastraUsuarioRepository(Usuario usuario);
        List<Usuario> ListarUsuariosRepository();
        void AtualizaUsuarioRepoSitory(Usuario usuario);
        void DeletaUsuarioRepository(int id);
    }
}
