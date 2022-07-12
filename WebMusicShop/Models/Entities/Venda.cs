using System.ComponentModel.DataAnnotations;

namespace WebMusicShop.Models.Entities
{
    public class Venda
    {
        public int Int { get; set; }
        public int ProdutoId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        [Display(Name ="Data da Venda")]
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Data de Alteração da Venda")]
        public DateTime DataAlteracao { get; set; }
    }
}
