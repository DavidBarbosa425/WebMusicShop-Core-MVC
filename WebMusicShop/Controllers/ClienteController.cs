using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Filters;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.ICliente;

namespace WebMusicShop.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpPost]
        public IActionResult CadastrarCliente([Bind("Nome,CPF,Email,Telefone,StatusEnum")] Cliente cliente)
        {
            try
            {
                _clienteService.CadastrarClienteService(cliente);
                TempData["MensagemSucesso"] = "Cliente Cadastrado com Sucesso!";
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar cliente, detalhes: {ex.Message}";
                return RedirectToAction("ListarClientes");
            }

        }

        public IActionResult CadastrarCliente()
        {
           return View();
        }

        public IActionResult ListarClientes()
        {
            try
            {
                List<Cliente> clientes = _clienteService.ListarClientesService();
                return View(clientes);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao exibir lista de clientes, detalhes: {ex.Message}";
                return RedirectToAction("index","home");
            }
        }

        public IActionResult BuscaCliente(int id)
        {
            try
            {
                Cliente cliente = _clienteService.BuscaCliente(id);
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao buscar cliente selecionado, detalhes: {ex.Message}";
                return RedirectToAction("ListarClientes");
            }
        }


        public IActionResult AtualizaCliente(int id)
        {
            try
            {
                var cliente = _clienteService.BuscaCliente(id);
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao buscar cliente selecionado, detalhes: {ex.Message}";
                return RedirectToAction("ListarClientes");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizaCliente([Bind("Id, Nome, CPF, Email, Telefone, StatusEnum")] Cliente cliente)
        {
            try
            {
                _clienteService.AtualizarClienteService(cliente);
                TempData["MensagemSucesso"] = "Cliente Atualizado com Sucesso!";
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro na atualização do cliente, detalhes: {ex.Message}";
                return RedirectToAction("ListarClientes");
            }

        }

        public IActionResult DeletarCliente(int id)
        {
            try
            {
                Cliente cliente = _clienteService.BuscaCliente(id);
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao buscar cliente selecionado, detalhes: {ex.Message}";
                return RedirectToAction("ListarClientes");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarCliente([Bind("Id")] Cliente cliente)
        {
            try
            {
                _clienteService.DeletarClienteService(cliente.Id);
                TempData["MensagemSucesso"] = "Cliente Deletado com Sucesso!";
                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar cliente, detalhes: {ex.Message}";
                return RedirectToAction("ListarClientes");
            }

        }

        public IActionResult PesquisarClientes(string term)
        {

                List<string> clientes = _clienteService.PesquisarClientesService(term);
                return Json(clientes);
        }
    }
}
