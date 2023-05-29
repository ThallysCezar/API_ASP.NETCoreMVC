using Microsoft.Extensions.DependencyInjection;
using ProjectFinance.Testes.Applications;
using ProjectFinance.Testes.Extensions;
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
