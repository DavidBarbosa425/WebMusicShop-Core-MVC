using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Models.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IUsuarioContext _Usuariocontext;
        public UsuarioRepository(IUsuarioContext Usuariocontext)
        {
            _Usuariocontext = Usuariocontext;
        }

        public void CadastraUsuarioRepository(Usuario usuario)
        {
            _Usuariocontext.CadastraUsuarioContext(usuario);
        }

        public List<Usuario> ListarUsuariosRepository()
        {
            List<Usuario> usuarios = _Usuariocontext.ListarUsuariosContext();
            return usuarios;
        }
    }
}
