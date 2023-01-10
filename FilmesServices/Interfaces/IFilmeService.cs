using Filmes.Domain.Entities;
using Filmes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Services.Interfaces
{
    public interface IFilmeService
    {
        List<FilmeModel> GetAllFilmes();
        FilmeModel GetFilmeById(int id);
        void AddNewFilme(FilmeModel filme);
        void UpdateExistingFilme(FilmeModel filme, int id);
        void DeleteFilmeById(int id);
    }
}
