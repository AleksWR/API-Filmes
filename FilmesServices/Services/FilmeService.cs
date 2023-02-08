using AutoMapper;
using Filmes.AutoMapper.Interfaces;
using Filmes.Domain.Entities;
using Filmes.Domain.Models;
using Filmes.Infra.Interfaces;
using Filmes.Infra.Repositories;
using Filmes.Services.Interfaces;
using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Services.Services
{
    public class FilmeService : IFilmeService
    {
        private IFilmeRepository _filmeRepository;
        private IMapper _mapper;
        public FilmeService(IFilmeRepository filmeRepository, IAutoMapperService mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper.GetMapper();
        }

        public void AddNewFilme(FilmeActionsDTO filme)
        {
            var filmeEntitie = _mapper.Map<Filme>(filme);
            _filmeRepository.AddNewFilme(filmeEntitie);
        }

        public void DeleteFilmeById(int id)
        {
            _filmeRepository.DeleteFilmeById(id);
        }

        public List<FilmeActionsDTO> GetAllFilmes()
        {
            List<Filme> Filmes = _filmeRepository.GetAllFilmes();
            return _mapper.Map<List<FilmeActionsDTO>>(Filmes);
        }

        public FilmeActionsDTO GetFilmeById(int id)
        {
            Filme film = _filmeRepository.GetFilmeById(id);
            return _mapper.Map<FilmeActionsDTO>(film);
        }

        public void UpdateExistingFilme(FilmeActionsDTO filme, int id)
        {
            _filmeRepository.UpdateExistingFilme(filme, id);
        }
    }
}
