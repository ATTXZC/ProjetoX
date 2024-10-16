using System.ComponentModel.DataAnnotations;

namespace Eco_life.Models
{
    public class Cadastros1
    {
        [Key]
        public int ID_User { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome_User { get; set; }

        [Required] 
        [MaxLength(100)]
        public string? Email_User { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Senha_User { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string? CPF { get; set; }
    }
}