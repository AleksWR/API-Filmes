using Filmes.Domain.Entities;
using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Infra.Data.Interfaces
{
    public interface IAuthRepository
    {
        Auth GetUserByUsername(string username);
        void AddNewUser(Auth user);
    }
}
