﻿using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.ICliente;

namespace WebMusicShop.Models.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public void CadastrarClienteService(Cliente cliente)
        {
            try
            {
                _clienteRepository.CadastrarClienteRepository(cliente);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
   
        }

        public List<Cliente> ListarClientesService()
        {
            try
            {
                List<Cliente> Clientes = _clienteRepository.ListarClientesRepository();
                List<Cliente> clientesOrdenados = Clientes.Where(x => x.Nome != null).OrderBy(x => x.Id).ToList();
                return clientesOrdenados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Cliente BuscaCliente(int id)
        {
            try
            {
                Cliente? cliente = _clienteRepository
                                        .ListarClientesRepository()
                                        .FirstOrDefault(x => x.Id == id);
            
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizarClienteService(Cliente cliente)
        {
            try
            {
                _clienteRepository.AtualizaClienteRepository(cliente);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarClienteService(int id)
        {
            try
            {
                _clienteRepository.DeletarClienteRepository(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<string> PesquisarClientesService(string term)
        {
            List<string> filtro = new List<string>();
            var clientes = _clienteRepository.ListarClientesRepository().Select(x => new { Id = x.Id, Nome = x.Nome });

            foreach (var cliente in clientes)
            {
                string clienteConcat = cliente.Id.ToString() + " - " + cliente.Nome.ToString();
                filtro.Add(clienteConcat);
            }

            List<string> filtrarClientes = filtro.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return filtrarClientes;
        }
    }
}
