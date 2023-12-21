using Application.Interfaces;
using Application;
using Domain.Interfaces;
using Infra.Context;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IAnexosRepository, AnexosRepository>();
            services.AddScoped<ITemaRepository, TemaRepository>();
            services.AddScoped<IObjetivoRepository, ObjetivoRepository>();
            services.AddScoped<IFinanciamentoRepository, FinanciamentoRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IGerenciaGeralRepository, GerenciaGeralRepository>();
            services.AddScoped<IGerenciaRepository, GerenciaRepository>();
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioProjetoRepository, UsuarioProjetoRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();

            services.AddScoped<IAnexosApp, AnexosApp>();
            services.AddScoped<ITemaApp, TemaApp>();
            services.AddScoped<IObjetivoApp, ObjetivoApp>();
            services.AddScoped<IFinanciamentoApp, FinanciamentoApp>();
            services.AddScoped<ISetorApp, SetorApp>();
            services.AddScoped<IGerenciaGeralApp, GerenciaGeralApp>();
            services.AddScoped<IGerenciaApp, GerenciaApp>();
            services.AddScoped<IFuncaoApp, FuncaoApp>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IUsuarioProjetoApp, UsuarioProjetoApp>();
            services.AddScoped<IProjetoApp, ProjetoApp>();

            return services;
        }
    }
}