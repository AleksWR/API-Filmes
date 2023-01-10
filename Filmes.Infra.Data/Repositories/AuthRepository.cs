using Filmes.AutoMapper.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Infra.Data.Contexts;
using Filmes.Infra.Data.Interfaces;
using FilmesDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Infra.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private ProjectContext _context;

        public AuthRepository(ProjectContext context)
        {
            _context = context;
        }

        public void AddNewUser(Auth user)
        {
            _context.Auths.Add(user);
            _context.SaveChanges();
        }

        public Auth GetUserByUsername(string username)
        {
            return _context.Auths.Where(p => p.Username.Trim() == username.Trim()).FirstOrDefault();
        }
    }
}
