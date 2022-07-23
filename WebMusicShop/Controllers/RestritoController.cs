using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Filters;

namespace WebMusicShop.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
