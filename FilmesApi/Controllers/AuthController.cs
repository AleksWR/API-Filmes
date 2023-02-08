using Filmes.Services.Interfaces;
using Filmes.Services.Services;
using FilmesApi.Services;
using FilmesDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>Efetua Login e Obtem Token </summary>
        /// <returns>Bearer Token</returns>
        /// <response code="200">Token Gerado</response>
        /// <response code="400">Falha no Login</response>
        /// 
        [Route("Login")]
        [HttpPost]
        public IActionResult LoginAndGetToken(AuthActionsDTO User)
        {
            if (ModelState.IsValid)
            {
                bool userIsAuthenticated = _authService.CheckIfUserIsAuthenticate(User);
                if (userIsAuthenticated == false)
                    return Unauthorized();
                else
                    return Ok(TokenService.GenerateToken(User));
            }

            return BadRequest();
        }

        /// <summary>Cria novo Usuário</summary>
        /// <returns>No Content</returns>
        /// <response code="204">Usuario Criado com Sucesso</response>
        /// <response code="400">Falha na criação do usuário</response>
        /// 
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(AuthActionsDTO User)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authService.AddNewUser(User);
                    return NoContent();
                }catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest();
        }

    }
}
