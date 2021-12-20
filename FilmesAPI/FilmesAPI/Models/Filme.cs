using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O genero nao deve passar de 30 caracteres.")]
        public string Genero { get; set; }
        [Range(1, 30000)]
        public int Duracao { get; set; }
    }
}
