using Microsoft.AspNetCore.Mvc;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.ICliente;

namespace WebMusicShop.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpPost]
        public IActionResult CadastrarCliente([Bind("Nome,CPF,Email,Telefone,Status")] Cliente cliente)
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
        public IActionResult AtualizaCliente([Bind("Id, Nome, CPF, Email, Telefone, Status")] Cliente cliente)
        {
            try
            {
                _clienteService.AtualizarClienteService(cliente);
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
            List<string> filtro = new List<string>();
            var clientes = _clienteService.ListarClientesService().Select(x => new { Id = x.Id, Nome = x.Nome });

            foreach (var cliente in clientes)
            {
                string clienteConcat  = cliente.Id.ToString() + " - " + cliente.Nome.ToString();
                filtro.Add(clienteConcat);
            }

            var filtrarClientes = filtro.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase));
            return Json(filtrarClientes);
        }
    }
}
