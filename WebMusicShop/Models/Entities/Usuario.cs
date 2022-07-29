using System.ComponentModel.DataAnnotations;
using WebMusicShop.Helper;
using WebMusicShop.Models.Enums;

namespace WebMusicShop.Models.Entities
{
    public class Usuario
    {
        [Display(Name ="#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo CPF obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O campo Email obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Status obrigatório")]
        [Display(Name ="Status")]
        public StatusUsuario StatusEnum { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "O campo Perfil obrigatório")]
        [Display(Name = "Perfil")]
        public Perfil PerfilEnum { get; set; }
        public string Perfil { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
