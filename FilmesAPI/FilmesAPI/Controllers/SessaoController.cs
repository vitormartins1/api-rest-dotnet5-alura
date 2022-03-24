using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            List<ReadSessaoDto> sessoes = _sessaoService.RecuperaSessoes();

            if (sessoes == null) return NotFound();

            return Ok(sessoes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessoesPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        //[HttpPut("{id}")]
        //public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        //{
        //    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        //    if(cinema == null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(cinemaDto, cinema);
        //    _context.SaveChanges();
        //    return NoContent();
        //}


        //[HttpDelete("{id}")]
        //public IActionResult DeletaCinema(int id)
        //{
        //    Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        //    if (cinema == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Remove(cinema);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

    }
}
