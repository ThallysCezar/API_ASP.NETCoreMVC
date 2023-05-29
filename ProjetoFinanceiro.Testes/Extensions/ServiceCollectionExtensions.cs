using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectFinance.Infrastructure.Repositories;
using ProjectFinance.Services.Services;
using ProjectFinance.Testes.Applications;
using ProjectFinance.Testes.Contexts;
using ProjectFinance.Testes.Repositories;
using ProjectFinance.Testes.Services;

namespace ProjectFinance.Testes.Extensions
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
