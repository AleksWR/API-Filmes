using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Services.Interfaces
{
    public interface IAuthService
    {
        bool CheckIfUserIsAuthenticate(UserModel User);
        void AddNewUser(UserModel User);
    }
}
