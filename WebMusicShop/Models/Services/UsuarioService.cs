using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Models.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CadastraUsuarioService(Usuario usuario)
        {
            try
            {
                _usuarioRepository.CadastraUsuarioRepository(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<Usuario> ListarUsuariosService()
        {
            try
            {
               List<Usuario> usuarios = _usuarioRepository.ListarUsuariosRepository();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario BuscaUsuarioService(int id)
        {
            try
            {
               Usuario? usuario =  _usuarioRepository.ListarUsuariosRepository().FirstOrDefault(x => x.Id == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizaUsuarioService(Usuario usuario)
        {
            try
            {
                _usuarioRepository.AtualizaUsuarioRepoSitory(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletaUsuarioService(int id)
        {
            try
            {
                _usuarioRepository.DeletaUsuarioRepository(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
