﻿namespace UsuariosAPI.Models
{
    public class Token
    {
        public string Value { get; }

        public Token(string valor)
        {
            Value = valor;
        }
    }
}
