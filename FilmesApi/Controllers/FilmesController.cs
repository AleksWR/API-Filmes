using Filmes.Domain.Models;
using Filmes.Services.Interfaces;
using Filmes.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private IFilmeService _filmeService;
        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        /// <summary>Obtem Filmes </summary>
        /// <returns>Retorna todos os filmes disponiveis</returns>
        /// <response code="200">Retorna Filmes</response>
        /// <response code="404">Nenhum Filme Encontrado</response>

        [HttpGet]
        public IActionResult GetFilmes()
        {
            List<FilmeActionsDTO> Filmes = _filmeService.GetAllFilmes();
            if (Filmes.Count > 0)
                return Ok(Filmes);

            return NotFound();
        }

        /// <summary>Obtem Filme por Id </summary>
        /// <returns>Retorna filme buscado</returns>
        /// <response code="200">Retorna Filme</response>
        /// <response code="404">Filme não Encontrado</response>
        /// 
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetFilmeById(int id)
        {
            FilmeActionsDTO Filme = _filmeService.GetFilmeById(id);
            if (Filme != null)
                return Ok(Filme);

            return NotFound();
        }

        /// <summary>Deleta filme por Id </summary>
        /// <returns>No Content</returns>
        /// <response code="204">Filme deletado com sucesso</response>
        /// <response code="400">Erro para deletar o registro</response>
        /// 
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteFilmeById(int id)
        {
            try
            {
                _filmeService.DeleteFilmeById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Altera dados de um filme por Id </summary>
        /// <returns>No Content</returns>
        /// <response code="204">Alterações efetuadas com sucesso</response>
        /// <response code="400">Erro para efetuar alterações</response>
        /// 
        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateFilme(int id, [FromBody] FilmeActionsDTO filme)
        {
            try
            {
                _filmeService.UpdateExistingFilme(filme, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Adiciona novo Filme </summary>
        /// <returns>No Content</returns>
        /// <response code="204">Adição de filme efetuada com sucesso</response>
        /// <response code="400">Erro para adicionar filme</response>
        /// 
        [HttpPost]
        public IActionResult AddFilme([FromBody] FilmeActionsDTO filme)
        {
            try
            {
                _filmeService.AddNewFilme(filme);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
