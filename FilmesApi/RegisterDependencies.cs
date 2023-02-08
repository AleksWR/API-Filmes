using Filmes.AutoMapper.Interfaces;
using Filmes.AutoMapper.Services;
using Filmes.Infra.Data.Interfaces;
using Filmes.Infra.Data.Repositories;
using Filmes.Infra.Interfaces;
using Filmes.Infra.Repositories;
using Filmes.Services.Interfaces;
using Filmes.Services.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FilmesApi
{
    public static class RegisterDependencies
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddSingleton<IAutoMapperService>(new AutoMapperService());
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
        }

    }
}
