using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Filters;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IProduto;
using WebMusicShop.Models.Services;

namespace WebMusicShop.Controllers
{
    [PaginaParaUsuarioLogado]
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
            try
            {
                _produtoService.CadastraProdutoService(produto);
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                return RedirectToAction("ListarProdutos");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar produto, detalhes:{ex.Message}";
                return RedirectToAction("ListarProdutos");
            }

        }

        public IActionResult ListarProdutos()
        {
            try
            {
                List<Produto> produtos = _produtoService.ListarProdutosService();
                return View(produtos);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarProdutos");
            }
        }

        public IActionResult BuscaProduto(int id)
        {
            try
            {
                Produto produto = _produtoService.BuscaProdutoService(id);
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarProdutos");
            }
        }

        public IActionResult AtualizaProduto(int id)
        {
            try
            {
                Produto produto = _produtoService.BuscaProdutoService(id);
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarProdutos");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizaProduto([Bind("Id,Tipo,Descricao,PrecoCusto,PrecoVenda,QtdEstoque")] Produto produto)
        {
            try
            {
                _produtoService.AtualizaProdutoService(produto);
                TempData["MensagemSucesso"] = "Produto Atualizado com sucesso!";
                return RedirectToAction("ListarProdutos");
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao atualizar produto, detalhes: {ex.Message}";
                return RedirectToAction("ListarProdutos");
            }
        }

        public IActionResult DeletaProduto(int id)
        {
            try
            {
                Produto produto = _produtoService.BuscaProdutoService(id);
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarProdutos");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletaProduto([Bind("Id")]Produto produto)
        {
            try
            {
                _produtoService.DeletaProdutoService(produto.Id);
                TempData["MensagemSucesso"] = "Produto deletado com sucesso!";
                return RedirectToAction("ListarProdutos");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar produto, detalhes:{ex.Message}";
                return RedirectToAction("ListarProdutos");
            }

        }
        public IActionResult PesquisarProdutos(string term)
        {
            List<string> produto = _produtoService.PesquisarProdutosService(term);
            return Json(produto);
        }
    }
}
