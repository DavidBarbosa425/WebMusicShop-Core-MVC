using Newtonsoft.Json;
using WebMusicShop.Models.Entities;

namespace WebMusicShop.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public Sessao(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public Usuario BuscaSessaoUsuario()
        {
            string sessaoUsuario = _iHttpContextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriaSessaoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _iHttpContextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);
        }

        public void RemoveSessaoUsuario()
        {
            _iHttpContextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
