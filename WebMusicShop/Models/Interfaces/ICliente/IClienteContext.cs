﻿using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.ICliente
{
    public interface IClienteContext
    {
        void CadastrarClienteContext(Cliente cliente);
        List<Cliente> ListarClientesContext();
        void AtualizarClienteContext(Cliente cliente);
        void DeletarClienteContext(int id);
    }
}