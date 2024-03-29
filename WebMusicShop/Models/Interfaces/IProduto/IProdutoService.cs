﻿using WebMusicShop.Models.Entities;

namespace WebMusicShop.Models.Interfaces.IProduto
{
    public interface IProdutoService
    {
        void CadastraProdutoService(Produto produto);
        List<Produto> ListarProdutosService();
        Produto BuscaProdutoService(int id);
        void AtualizaProdutoService(Produto produto);
        void DeletaProdutoService(int id);
        List<string> PesquisarProdutosService(string term);
    }
}
