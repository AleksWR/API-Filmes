using Filmes.Domain.Entities;
using Filmes.Domain.Models;
using Filmes.Infra.Data.Contexts;
using Filmes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private ProjectContext _context;
        public FilmeRepository(ProjectContext context)
        {
            _context = context;
        }

        public void AddNewFilme(Filme filme)
        {
            _context.Filme.Add(filme);
            _context.SaveChanges();
        }

        public void DeleteFilmeById(int id)
        {
            Filme filme = _context.Filme.Where(p => p.Id == id).FirstOrDefault();
            if(filme != null)
            {
                _context.Filme.Remove(filme);
                _context.SaveChanges();
            }
            else
                throw new Exception("Filme Nao Encontrado");
        }

        public List<Filme> GetAllFilmes()
        {
            return _context.Filme.ToList();
        }

        public Filme GetFilmeById(int id)
        {
            return _context.Filme.Where(p => p.Id == id).FirstOrDefault(); 
        }

        public void UpdateExistingFilme(FilmeActionsDTO filme, int id)
        {
            Filme filmeToEdit = _context.Filme.Where(p => p.Id == id).FirstOrDefault();

            if (filmeToEdit != null)
            {
                if (!string.IsNullOrEmpty(filme.Name))
                    filmeToEdit.Name = filme.Name;
                if (!string.IsNullOrEmpty(filme.Description))
                    filmeToEdit.Description = filme.Description;
                if (!string.IsNullOrEmpty(filme.Type))
                    filmeToEdit.Type = filme.Type;
                if (filme.MinutesDuration != 0)
                    filmeToEdit.MinutesDuration = filme.MinutesDuration;

                _context.SaveChanges();
            }
            else
                throw new Exception("Filme Nao Encontrado");
        }
    }
}
