using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Filters;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IUsuario;

namespace WebMusicShop.Controllers
{
    [PaginaRestritaSomenteAdmin]
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
        public IActionResult CadastraUsuario([Bind("Nome,CPF,Email,Senha,StatusEnum")] Usuario usuario)
        {
            try
            {
                _usuarioService.CadastraUsuarioService(usuario);
                return RedirectToAction("ListarUsuarios");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }
        public IActionResult ListarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = _usuarioService.ListarUsuariosService();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }

        public IActionResult BuscaUsuario(int id)
        {
            try
            {
                Usuario usuario = _usuarioService.BuscaUsuarioService(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }

        public IActionResult AtualizaUsuario(int id)
        {
            try
            {
                Usuario usuario = _usuarioService.BuscaUsuarioService(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizaUsuario([Bind("Id,Nome,CPF,Email,StatusEnum")]Usuario usuario)
        {
            try
            {
                _usuarioService.AtualizaUsuarioService(usuario);
                return RedirectToAction("ListarUsuarios");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }

        public IActionResult DeletaUsuario(int id)
        {
            try
            {
                Usuario usuario = _usuarioService.BuscaUsuarioService(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletaUsuario([Bind("Id")]Usuario usuario)
        {
            try
            {
                _usuarioService.DeletaUsuarioService(usuario.Id);
                return RedirectToAction("ListarUsuarios");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarUsuarios");
            }
        }

        public IActionResult PesquisarUsuarios(string term)
        {
            List<string> filtro = new List<string>();
            var usuarios = _usuarioService.ListarUsuariosService().Select(x => new { Id = x.Id, Nome = x.Nome });

            foreach (var usuario in usuarios)
            {
                string usuarioConcat = usuario.Id.ToString() + " - " + usuario.Nome.ToString();
                filtro.Add(usuarioConcat);
            }

            var filtrarUsuarios = filtro.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase));
            return Json(filtrarUsuarios);
        }

    }
}
