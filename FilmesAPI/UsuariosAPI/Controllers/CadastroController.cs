
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDTO createDTO)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDTO);
            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
