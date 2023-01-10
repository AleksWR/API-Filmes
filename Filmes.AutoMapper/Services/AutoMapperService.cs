using AutoMapper;
using Filmes.AutoMapper.Interfaces;
using Filmes.AutoMapper.Profiles;
using Filmes.Domain.Entities;
using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.AutoMapper.Services
{
    public class AutoMapperService : IAutoMapperService
    {
        private MapperConfiguration configuration { get; set; }
        public IMapper GetMapper()
        {
            SetConfiguration();
            var configuration = GetConfiguration();
            var mapper = configuration.CreateMapper();

            return mapper;
        }

        public MapperConfiguration GetConfiguration() { return configuration; }
        public void SetConfiguration()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuthUserProfile>();
                cfg.AddProfile<FilmeProfile>();
            });
        }
    }
}
