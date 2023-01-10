using Filmes.Services.Interfaces;
using Filmes.Services.Services;
using FilmesApi.Services;
using FilmesDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [Route("Login")]
        [HttpPost]
        public IActionResult LoginAndGetToken(UserModel User)
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

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(UserModel User)
        {
            if (ModelState.IsValid)
            {
                _authService.AddNewUser(User);
                return NoContent();
            }

            return BadRequest();
        }

    }
}
