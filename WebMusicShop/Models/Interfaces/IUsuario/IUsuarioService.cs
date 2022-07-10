﻿using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IUsuario
{
    public interface IUsuarioService
    {
        void CadastraUsuarioService(Usuario usuario);
        List<Usuario> ListarUsuariosService();
        Usuario BuscaUsuarioService(int id);
        void AtualizaUsuarioService(Usuario usuario);
    }
}
