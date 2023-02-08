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
        List<FilmeActionsDTO> GetAllFilmes();
        FilmeActionsDTO GetFilmeById(int id);
        void AddNewFilme(FilmeActionsDTO filme);
        void UpdateExistingFilme(FilmeActionsDTO filme, int id);
        void DeleteFilmeById(int id);
    }
}
