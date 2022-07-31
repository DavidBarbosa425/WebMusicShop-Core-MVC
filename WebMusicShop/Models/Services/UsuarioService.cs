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
                 usuario.SetSenhaHash();
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
                 usuario.SetSenhaHash();
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

        public List<string> PesquisarUsuariosService(string term)
        {
            List<string> filtro = new List<string>();
            var usuarios = _usuarioRepository.ListarUsuariosRepository().Select(x => new { Id = x.Id, Nome = x.Nome });

            foreach (var usuario in usuarios)
            {
                string usuarioConcat = usuario.Id.ToString() + " - " + usuario.Nome.ToString();
                filtro.Add(usuarioConcat);
            }

            List<string> filtrarUsuarios = filtro.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return filtrarUsuarios;
        }
    }
}
