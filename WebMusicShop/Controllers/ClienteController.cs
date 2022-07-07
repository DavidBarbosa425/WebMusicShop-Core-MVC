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
        public IActionResult CadastrarCliente([Bind("Nome,CPF")] Cliente cliente)
        {
            try
            {
                _clienteService.CadastrarClienteService(cliente);
                TempData["MensagemSucesso"] = "Cliente Cadastrado com Sucesso!";
                return RedirectToAction("CadastrarCliente");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar cliente, detalhes: {ex.Message}";
                return RedirectToAction("CadastrarCliente");
            }

        }

        public IActionResult CadastrarCliente()
        {
           return View();
        }

        public IActionResult ListarClientes()
        {
           List<Cliente> clientes = _clienteService.ListarClientesService();
           return View(clientes);
        }

        public IActionResult BuscaCliente(int id)
        {
           Cliente cliente = _clienteService.BuscaCliente(id);
            return View(cliente);
        }
    }
}
