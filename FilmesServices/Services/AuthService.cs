using AutoMapper;
using CryptSharp;
using Filmes.AutoMapper.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Infra.Data.Interfaces;
using Filmes.Infra.Data.Repositories;
using Filmes.Services.Interfaces;
using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Services.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;
        private IMapper _mapper;

        public AuthService(IAuthRepository authRepository, IAutoMapperService mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper.GetMapper();
        }

        public bool CheckIfUserIsAuthenticate(AuthActionsDTO User)
        {
            var userFounded = _authRepository.GetUserByUsername(User.Username);
            if(userFounded != null)
            {
                bool PasswordCorrect = Crypter.CheckPassword(User.Password, userFounded.Password);
                if (PasswordCorrect == true)
                    return true;
                else
                    return false;            
            }

            return false;
        }

        public void AddNewUser(AuthActionsDTO User)
        {
            User.Password = Crypter.MD5.Crypt(User.Password);
            var userModel = _mapper.Map<Auth>(User);

            _authRepository.AddNewUser(userModel);
        }
    }
}
