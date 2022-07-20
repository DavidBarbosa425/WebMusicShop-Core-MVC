using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Entrar(Login login)
        {

            if (ModelState.IsValid)
            {
                Usuario? usuario = _usuarioService.ListarUsuariosService().FirstOrDefault(x => x.Email.Equals(login.Email));

                if(usuario != null )
                {
                    if (usuario.SenhaValida(login.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                TempData["MensagemErro"] = "E-mail ou senha são inválidos, por favor, tente novamente";
            }
            return View("Index");
        }
    }
}
