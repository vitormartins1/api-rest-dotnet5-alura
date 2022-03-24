using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using System;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private FilmeDBContext _context;
        private IMapper _mapper;

        public GerenteService(FilmeDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentesPorId(int Id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == Id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }

            return null;
        }
    }
}
