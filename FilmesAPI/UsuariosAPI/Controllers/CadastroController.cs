﻿
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDTO createDTO)
        {

        }
    }
}
