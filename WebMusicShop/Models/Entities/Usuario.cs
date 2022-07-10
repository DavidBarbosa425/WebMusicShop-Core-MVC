using System.ComponentModel.DataAnnotations;

namespace WebMusicShop.Models.Entities
{
    public class Usuario
    {
        [Display(Name ="#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo nome CPF obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O campo nome Email obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo nome StatusId obrigatório")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "O campo nome Status obrigatório")]
        public string Status { get; set; }
    }
}
