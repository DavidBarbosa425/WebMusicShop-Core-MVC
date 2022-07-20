using System.ComponentModel.DataAnnotations;

namespace WebMusicShop.Models.Entities
{
    public class Login
    {
        [Required(ErrorMessage ="Digite o E-mail")]
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "DIgite a Senha")]
        public string Senha { get; set; }
    }
}
