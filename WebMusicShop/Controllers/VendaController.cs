using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IVenda;

namespace WebMusicShop.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        public IActionResult CadastraVenda()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraVenda([Bind("ProdutoId,ClienteId,UsuarioId,Quantidade")] Venda venda)
        {
            _vendaService.CadastraVendaService(venda);
            return RedirectToAction("ListarVendas");
        }

        public IActionResult ListarVendas()
        {
            List<Venda> vendas = _vendaService.ListarVendasService();
            return View(vendas);
        }
    }
}
