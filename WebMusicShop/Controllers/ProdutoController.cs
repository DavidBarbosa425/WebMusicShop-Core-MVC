using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IProduto;
using WebMusicShop.Models.Services;

namespace WebMusicShop.Controllers
{
    public class ProdutoController : Controller
    {
        public readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult CadastraProduto()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraProduto([Bind("Tipo,Descricao,PrecoCusto,PrecoVenda,QtdEstoque")] Produto produto)
        {
            _produtoService.CadastraProdutoService(produto);
            return RedirectToAction("index", "home");
        }

        public IActionResult ListarProdutos()
        {
            List<Produto> produtos = _produtoService.ListarProdutosService();
            return View(produtos);
        }
    }
}
