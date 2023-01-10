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
        private IAutoMapperService _mapper;
        public FilmeService(IFilmeRepository filmeRepository, IAutoMapperService mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public void AddNewFilme(FilmeModel filme)
        {
            var mapperObject = _mapper.GetMapper();
            var filmeEntitie = mapperObject.Map<Filme>(filme);

            _filmeRepository.AddNewFilme(filmeEntitie);
        }

        public void DeleteFilmeById(int id)
        {
            _filmeRepository.DeleteFilmeById(id);
        }

        public List<FilmeModel> GetAllFilmes()
        {
            List<Filme> Filmes = _filmeRepository.GetAllFilmes();

            var mapperObject = _mapper.GetMapper();
            return mapperObject.Map<List<FilmeModel>>(Filmes);
        }

        public FilmeModel GetFilmeById(int id)
        {
            Filme film = _filmeRepository.GetFilmeById(id);

            var mapperObject = _mapper.GetMapper();
            return mapperObject.Map<FilmeModel>(film);
        }

        public void UpdateExistingFilme(FilmeModel filme, int id)
        {
            _filmeRepository.UpdateExistingFilme(filme, id);
        }
    }
}
