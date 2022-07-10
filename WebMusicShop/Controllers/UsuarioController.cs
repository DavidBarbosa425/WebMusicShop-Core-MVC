using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult CadastraUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraUsuario([Bind("Nome,CPF,Email,Status")] Usuario usuario)
        {
            _usuarioService.CadastraUsuarioService(usuario);
            return RedirectToAction("ListarUsuarios");
        }
        public IActionResult ListarUsuarios()
        {
            List<Usuario> usuarios =_usuarioService.ListarUsuariosService();
            return View(usuarios);
        }
        
    }
}
