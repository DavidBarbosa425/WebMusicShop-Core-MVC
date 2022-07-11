using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Models.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IUsuarioContext _usuariocontext;
        public UsuarioRepository(IUsuarioContext Usuariocontext)
        {
            _usuariocontext = Usuariocontext;
        }


        public void CadastraUsuarioRepository(Usuario usuario)
        {
            _usuariocontext.CadastraUsuarioContext(usuario);
        }

        public List<Usuario> ListarUsuariosRepository()
        {
            List<Usuario> usuarios = _usuariocontext.ListarUsuariosContext();
            return usuarios;
        }
        public void AtualizaUsuarioRepoSitory(Usuario usuario)
        {
            _usuariocontext.AtualizaUsuarioContext(usuario);
        }

        public void DeletaUsuarioRepository(int id)
        {
            _usuariocontext.DeletaUsuarioContext(id);
        }
    }
}
