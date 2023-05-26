using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Services;
using ProjetoFinanceiro.Testes.Applications;
using ProjetoFinanceiro.Testes.Contexts;
using ProjetoFinanceiro.Testes.Repositories;
using ProjetoFinanceiro.Testes.Services;

namespace ProjetoFinanceiro.Testes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependecies(this IServiceCollection services)
        {
            IConfiguration configuration = GetConfiguration();
            services.AddSingleton<IConfiguration>(configuration);
            RegisterDependencies(services);

            return services;

        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<AppTestePrincipal>();

            // Registro da dependência
            services.AddScoped<IRepositoryClient, RepositoryClient>();

            //testes
            services.AddScoped<RepositorioTeste>();

            //servicos
            services.AddScoped<ClientService>();
            services.AddScoped<ServicoTeste>();
            services.AddScoped<ConnectionTest>();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            return configuration;
        }
    }
}
