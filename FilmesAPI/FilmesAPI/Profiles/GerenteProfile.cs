﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Linq;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, options => options
                .MapFrom(gerente => gerente.Cinemas
                .Select(c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId})));
        }
    }
}
