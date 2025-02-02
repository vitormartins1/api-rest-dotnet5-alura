﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly FilmeDBContext _context;
        private readonly IMapper _mapper;

        public SessaoService(FilmeDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return sessaoDto;
            }

            return null;
        }

        public List<ReadSessaoDto> RecuperaSessoes()
        {
            List<Sessao> sessao = _context.Sessoes.ToList();
            if (sessao != null)
            {
                List<ReadSessaoDto> sessaoDto = _mapper.Map<List<ReadSessaoDto>>(sessao);

                return sessaoDto;
            }

            return null;
        }
    }
}
