using AutoMapper;
using Filmes.Domain.Entities;
using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.AutoMapper.Profiles
{
    public class AuthUserProfile : Profile
    {
        public AuthUserProfile()
        {
            CreateMap<Auth, UserModel>();
            CreateMap<UserModel, Auth>();
        }
    }
}
