using Microsoft.Extensions.DependencyInjection;
using ProjetoFinanceiro.Testes.Applications;
using ProjetoFinanceiro.Testes.Extensions;
using System;

try
{
    var serviceCollection = ConfigureServices();
    IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
    var eventService = serviceProvider.GetRequiredService<AppTestePrincipal>();
    eventService.Execute();
}
catch (Exception)
{
    throw;
}

IServiceCollection ConfigureServices()
{
    IServiceCollection serviceCollection = new ServiceCollection();
    serviceCollection.AddDependecies();
    return serviceCollection;
}
