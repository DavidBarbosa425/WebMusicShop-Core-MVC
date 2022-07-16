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
            try
            {
                _vendaService.CadastraVendaService(venda);
                return RedirectToAction("ListarVendas");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }

        public IActionResult ListarVendas()
        {

            try
            {
                List<Venda> vendas = _vendaService.ListarVendasService();
                return View(vendas);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }
        public IActionResult BuscaVenda(int id)
        {
            try
            {
                Venda venda = _vendaService.BuscaVendaService(id);
                return View(venda);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }

        public IActionResult AtualizaVenda(int id)
        {
            try
            {
                Venda venda = _vendaService.BuscaVendaService(id);
                return View(venda);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizaVenda([Bind("Id,ProdutoId,ClienteId,UsuarioId,Quantidade")] Venda venda)
        {
            try
            {
                _vendaService.AtualizaVendaService(venda);
                return RedirectToAction("ListarVendas");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }

        public IActionResult DeletaVenda(int id)
        {
            try
            {
                Venda venda = _vendaService.BuscaVendaService(id);
                return View(venda);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletaVenda([Bind("Id")] Venda venda)
        {
            try
            {
                _vendaService.DeletaVendaService(venda.Id);
                return RedirectToAction("ListarVendas");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }
    }
}
