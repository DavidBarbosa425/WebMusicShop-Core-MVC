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

        public IActionResult BuscaProduto(int id)
        {
           Produto produto = _produtoService.BuscaProdutoService(id);
            return View(produto);
        }

        public IActionResult AtualizaProduto(int id)
        {
            Produto produto = _produtoService.BuscaProdutoService(id);
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizaProduto([Bind("Id,Tipo,Descricao,PrecoCusto,PrecoVenda,QtdEstoque")] Produto produto)
        {
            if (produto.QtdEstoque < 0)
            {
                TempData["MensagemErro"] = "Quantidade em Estoque não pode ser menor do que 0";
                return RedirectToAction("AtualizaProduto");
            }

            _produtoService.AtualizaProdutoService(produto);
            TempData["MensagemSucesso"] = "Produto Atualizado com sucesso!";
            return RedirectToAction("ListarProdutos");
        }
    }
}
