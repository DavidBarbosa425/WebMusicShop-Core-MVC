using System.ComponentModel.DataAnnotations;

namespace WebMusicShop.Models.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo ProdutoId é obrigatório")]
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        [Required(ErrorMessage = "Campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Campo UsuarioId é obrigatório")]
        public string Cliente { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        [Display(Name = "Data da Venda")]
        [DataType(DataType.Date)]
        public DateTime? DataVenda { get; set; }
        [Required(ErrorMessage = "Campo Quantidade é obrigatório")]
        public int Quantidade { get; set; }
        [Display(Name = "Data de Alteração da Venda")]
        [DataType(DataType.Date)]
        public DateTime? DataAlteracao { get; set; }
    }
}
