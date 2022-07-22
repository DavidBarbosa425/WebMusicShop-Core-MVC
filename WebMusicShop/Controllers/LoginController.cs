using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Helper;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioService usuarioService, ISessao sessao)
        {
            _usuarioService = usuarioService;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se usuario estiver logado, redirecionar para a home
            if(_sessao.BuscaSessaoUsuario() != null) return RedirectToAction("Index","Home");
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
                        _sessao.CriaSessaoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                TempData["MensagemErro"] = "E-mail ou senha são inválidos, por favor, tente novamente";
            }
            return View("Index");
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }
    }
}
