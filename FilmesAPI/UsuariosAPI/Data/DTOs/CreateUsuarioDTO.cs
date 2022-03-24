using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTOs
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Error password.")]
        public string RePassword { get; set; }
    }
}
