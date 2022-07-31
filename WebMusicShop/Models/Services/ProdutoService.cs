using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Interfaces.IProduto;

namespace WebMusicShop.Models.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        public void CadastraProdutoService(Produto produto)
        {
            try
            {
                _produtoRepository.CadastraProdutoRepository(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public List<Produto> ListarProdutosService()
        {
            try
            {
                List<Produto> produtos = _produtoRepository.ListarProdutosRepository();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Produto BuscaProdutoService(int id)
        {
            try
            {
                Produto? produto = _produtoRepository
                                    .ListarProdutosRepository()
                                    .FirstOrDefault(x => x.Id == id);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizaProdutoService(Produto produto)
        {
            try
            {
                if (produto.QtdEstoque < 0) throw new Exception("Quantidade em Estoque não pode ser menor do que 0(zero)");
                _produtoRepository.AtualizarProdutoRepository(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeletaProdutoService(int id)
        {
            try
            {
                _produtoRepository.DeletaProdutoRepository(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> PesquisarProdutosService(string term)
        {
            List<string> filtro = new List<string>();
            var produtos = _produtoRepository.ListarProdutosRepository().Select(x => new { Id = x.Id, Tipo = x.Tipo });

            foreach (var produto in produtos)
            {
                string produtoConcat = produto.Id.ToString() + " - " + produto.Tipo.ToString();
                filtro.Add(produtoConcat);
            }

            List<string> filtrarProdutos = filtro.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return filtrarProdutos;
        }
    }
}
