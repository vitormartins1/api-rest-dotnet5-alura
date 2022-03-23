using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
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
        private FilmeDBContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
  

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes()
        {
            return _context.Sessoes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if(sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
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
