using WebMusicShop.Models.Entities;

namespace WebMusicShop.Helper
{
    public interface ISessao
    {
        void CriaSessaoUsuario(Usuario usuario);
        void RemoveSessaoUsuario();
        Usuario BuscaSessaoUsuario();
    }
}
