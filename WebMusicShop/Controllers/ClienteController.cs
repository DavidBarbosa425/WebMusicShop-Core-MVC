﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AtualizaCliente([Bind("Id, Nome, CPF")] Cliente cliente)
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
    }
}
