using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Enums;
using WebMusicShop.Models.Interfaces.ICliente;
using WebMusicShop.Models.Interfaces.IProduto;
using WebMusicShop.Models.Interfaces.IUsuario;
using WebMusicShop.Models.Interfaces.IVenda;

namespace WebMusicShop.Models.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        public readonly IProdutoService _produtoService;
        public readonly IClienteService _clienteService;
        public readonly IUsuarioService _usuarioService;
        public VendaService(IVendaRepository vendaRepository, IProdutoService produtoService, IClienteService clienteService, IUsuarioService usuarioService)
        {
            _vendaRepository = vendaRepository;
            _produtoService = produtoService;
            _clienteService = clienteService;
            _usuarioService = usuarioService;
        }


        public void CadastraVendaService(Venda venda)
        {
            try
            {
                string[] p = venda.Produto.Split(" - ");
                string[] c = venda.Cliente.Split(" - ");
                string[] u = venda.Usuario.Split(" - ");

                venda.ProdutoId = int.Parse(p[0]);
                venda.ClienteId = int.Parse(c[0]);
                venda.UsuarioId = int.Parse(u[0]);

                Cliente cliente = _clienteService.BuscaCliente(venda.ClienteId);

                if (cliente.Status == StatusCliente.Inativo.ToString() || cliente.Status == StatusCliente.Bloqueado.ToString())
                    throw new Exception("Venda não pode ser efetuada, cliente esta inativo ou bloqueado");
 

                Usuario usuario = _usuarioService.BuscaUsuarioService(venda.UsuarioId);

                if (usuario.Status == StatusUsuario.Inativo.ToString() || usuario.Status == StatusUsuario.Bloqueado.ToString())
                    throw new Exception("Venda não pode ser efetuada, usuário esta inativo ou bloqueado");

                Produto produto = _produtoService.BuscaProdutoService(venda.ProdutoId);

                if (produto.QtdEstoque < venda.Quantidade || produto.QtdEstoque == 0)
                    throw new Exception("Quantidade em Estoque Insuficiente");

                if (venda.Quantidade <= 0)
                    throw new Exception("Insira a Quantidade de Produtos");

                _vendaRepository.CadastraVendaRepository(venda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    }

        public List<Venda> ListarVendasService()
        {
            try
            {
                List<Venda> vendas = _vendaRepository.ListarVendasRepository();
                return vendas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Venda BuscaVendaService(int id)
        {
            try
            {
                Venda? venda = _vendaRepository.ListarVendasRepository().Find(x => x.Id == id);
                Venda? vendaIdNome = _vendaRepository.ListarVendasRepository().Find(x => x.Id == venda.Id);
                vendaIdNome.Produto = venda.ProdutoId.ToString() + " - " + vendaIdNome.Produto.ToString();
                vendaIdNome.Cliente = venda.ClienteId.ToString() + " - " + vendaIdNome.Cliente.ToString();
                vendaIdNome.Usuario = venda.UsuarioId.ToString() + " - " + vendaIdNome.Usuario.ToString();
                vendaIdNome.Quantidade = venda.Quantidade;


                return vendaIdNome;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AtualizaVendaService(Venda venda)
        {

            try
            {
                string[] p = venda.Produto.Split(" - ");
                string[] c = venda.Cliente.Split(" - ");
                string[] u = venda.Usuario.Split(" - ");

                venda.ProdutoId = int.Parse(p[0]);
                venda.ClienteId = int.Parse(c[0]);
                venda.UsuarioId = int.Parse(u[0]);

                Produto produto = _produtoService.BuscaProdutoService(venda.ProdutoId);
                Venda? ultimaVenda = _vendaRepository.ListarVendasRepository().Find(x => x.Id == venda.Id);
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
                    throw new Exception("Quantidade em Estoque Insuficiente");

                if (venda.Quantidade == 0)
                    throw new Exception("Insira a Quantidade de Produtos");

                _produtoService.AtualizaProdutoService(produto);
                _vendaRepository.AtualizaVendaRepository(venda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeletaVendaService(int id)
        {
            try
            {
                _vendaRepository.DeletaVendaRepository(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
