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
        private IAutoMapperService _mapper;

        public AuthService(IAuthRepository authRepository, IAutoMapperService mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public bool CheckIfUserIsAuthenticate(UserModel User)
        {
            var userFounded = _authRepository.GetUserByUsername(User.Username);
            if(userFounded != null)
            {
                bool PasswordCorrect = CryptSharpService.CheckIfCryptedPasswordMatch(User.Password, userFounded.Password);
                if (PasswordCorrect == true)
                {
                    var mapperObject = _mapper.GetMapper();
                    var userModel = mapperObject.Map<UserModel>(userFounded);

                    return true;
                }

                return false;            
            }

            return false;
        }

        public void AddNewUser(UserModel User)
        {
            User.Password = CryptSharpService.CryptPassword(User.Password);

            var mapperObject = _mapper.GetMapper();
            var userModel = mapperObject.Map<Auth>(User);

            _authRepository.AddNewUser(userModel);
        }
    }
}
