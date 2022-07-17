using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IProduto;
using WebMusicShop.Models.Interfaces.IVenda;

namespace WebMusicShop.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        public readonly IProdutoService _produtoService;

        public VendaController(IVendaService vendaService, IProdutoService produtoService)
        {
            _vendaService = vendaService;
            _produtoService = produtoService;
        }

        public IActionResult CadastraVenda()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastraVenda([Bind("Produto,Cliente,Usuario,Quantidade")] Venda venda)
        {
            string[] p = venda.Produto.Split(" - ");
            string[] c = venda.Cliente.Split(" - ");
            string[] u = venda.Usuario.Split(" - ");

            venda.ProdutoId = int.Parse(p[0]);
            venda.ClienteId = int.Parse(c[0]);
            venda.UsuarioId = int.Parse(u[0]);

            try
            {
                Produto produto = _produtoService.BuscaProdutoService(venda.ProdutoId);

                if (produto.QtdEstoque < venda.Quantidade || produto.QtdEstoque == 0)
                {
                    TempData["MensagemErro"] = "Quantidade em Estoque Insuficiente";
                    return RedirectToAction("ListarVendas");
                }

                if (venda.Quantidade <= 0)
                {
                    TempData["MensagemErro"] = "Insira a Quantidade de Produtos";
                    return RedirectToAction("ListarVendas");
                }

                _vendaService.CadastraVendaService(venda);
                TempData["MensagemSucesso"] = "Venda Cadastrada com Sucesso!";
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
                Venda? vendaIdNome = _vendaService.ListarVendasService().Find(x => x.Id == venda.Id);
                vendaIdNome.Produto = venda.ProdutoId.ToString() + " - " + vendaIdNome.Produto.ToString();
                vendaIdNome.Cliente = venda.ClienteId.ToString() + " - " + vendaIdNome.Cliente.ToString();
                vendaIdNome.Usuario = venda.UsuarioId.ToString() + " - " + vendaIdNome.Usuario.ToString();
                vendaIdNome.Quantidade = venda.Quantidade;


                return View(vendaIdNome);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("ListarVendas");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizaVenda([Bind("Id,Produto,Cliente,Usuario,Quantidade")] Venda venda)
        {
            string[] p = venda.Produto.Split(" - ");
            string[] c = venda.Cliente.Split(" - ");
            string[] u = venda.Usuario.Split(" - ");

            venda.ProdutoId = int.Parse(p[0]);
            venda.ClienteId = int.Parse(c[0]);
            venda.UsuarioId = int.Parse(u[0]);

            try
            {
                Produto produto = _produtoService.BuscaProdutoService(venda.ProdutoId);
                Venda ultimaVenda = _vendaService.BuscaVendaService(venda.Id);
                var qtdVendaAtualizar = 0;

                if (ultimaVenda.Quantidade < venda.Quantidade)
                {
                    qtdVendaAtualizar = venda.Quantidade - ultimaVenda.Quantidade;
                    produto.QtdEstoque -= qtdVendaAtualizar;
                    
                }

                if (ultimaVenda.Quantidade > venda.Quantidade)
                {
                    qtdVendaAtualizar = ultimaVenda.Quantidade - venda.Quantidade;
                    produto.QtdEstoque += qtdVendaAtualizar;
                }

                if (produto.QtdEstoque < 0)
                {
                    TempData["MensagemErro"] = "Quantidade em Estoque Insuficiente";
                    return RedirectToAction("ListarVendas");
                }
                if (venda.Quantidade == 0)
                {
                    TempData["MensagemErro"] = "Insira a Quantidade de Produtos";
                    return RedirectToAction("ListarVendas");
                }

                _produtoService.AtualizaProdutoService(produto);
                _vendaService.AtualizaVendaService(venda);
                TempData["MensagemSucesso"] = "Venda Atualizada com Sucesso!";
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
                TempData["MensagemSucesso"] = "Venda Deletada com Sucesso!";
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
