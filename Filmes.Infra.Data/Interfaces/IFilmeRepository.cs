using Filmes.Domain.Entities;
using Filmes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Infra.Interfaces
{
    public interface IFilmeRepository
    {
        List<Filme> GetAllFilmes();
        Filme GetFilmeById(int id);
        void AddNewFilme(Filme filme);
        void UpdateExistingFilme(FilmeModel filme, int id);
        void DeleteFilmeById(int id);
    }
}
