 using HelpMap.CrossCutting.Identity.Authorization;
using HelpMap.CrossCutting.Identity.Models;
using HelpMap.Domain.Interfaces;
using HelpMap.Infrastructure.Context;
using HelpMap.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace HelpMap.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IReuniaoRepository, ReuniaoRepository>();
            services.AddScoped<IReuniaoAbertaRepository, ReuniaoAbertaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<ContextEntity>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
