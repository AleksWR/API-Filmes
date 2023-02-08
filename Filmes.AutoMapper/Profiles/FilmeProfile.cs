using AutoMapper;
using Filmes.Domain.Entities;
using Filmes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.AutoMapper.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, FilmeActionsDTO>();
            CreateMap<FilmeActionsDTO, Filme>();
        }
    }
}
