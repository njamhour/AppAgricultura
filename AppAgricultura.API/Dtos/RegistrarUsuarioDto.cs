using System.ComponentModel.DataAnnotations;

namespace AppAgricultura.API.Dtos
{
    public class RegistrarUsuarioDto
    {
        [Required]
        public string Login {get; set;}
        
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Utilize uma senha entre 4 e 10 caracteres")]
        public string Senha { get; set; }
        [Required]
        public string Nome { get; set;}
    }
}