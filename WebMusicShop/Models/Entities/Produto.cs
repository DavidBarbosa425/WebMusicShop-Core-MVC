using System.ComponentModel.DataAnnotations;

namespace WebMusicShop.Models.Entities
{
    public class Produto
    {
        [Display(Name ="#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo tipo do produto é obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo descrição do produto é obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço de Custo")]
        [Required(ErrorMessage = "Campo preço de custo do produto é obrigatório")]
        public string PrecoCusto { get; set; }
        [Display(Name = "Preço de Venda")]
        [Required(ErrorMessage = "Campo preço de venda do produto é obrigatório")]
        public string PrecoVenda { get; set; }
        [Display(Name = "Quantidade em Estoque")]
        [Required(ErrorMessage = "Campo quantidade em estoque do produto é obrigatório")]
        public int QtdEstoque { get; set; }

    }
}
