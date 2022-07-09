using System.ComponentModel.DataAnnotations;

namespace WebMusicShop.Models.Entities
{
    public class Cliente
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage ="Campo nome precisa ter entre 3 e 40 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage ="Campo Email é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Endereço de email inválido")]
        public string Email { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Número de telefone inválido")]
        [Required(ErrorMessage ="Campo Telefone é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Campo Status é obrigatório")]
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
