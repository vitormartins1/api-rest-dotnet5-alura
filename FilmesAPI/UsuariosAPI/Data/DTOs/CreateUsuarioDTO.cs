﻿using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
