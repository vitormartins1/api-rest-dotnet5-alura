using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(dto);
            
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{Id}")]
        public IActionResult RecuperaGerentesPorId(int Id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentesPorId(Id);
            if (readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }
    }
}
