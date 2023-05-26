using Microsoft.Extensions.Options;
using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Services;

var builder = WebApplication.CreateBuilder(args);

#region Arquivo de Config
// Obt�m a se��o de configura��o
var configuration = builder.Configuration;
var apiConfigSection = configuration.GetSection(nameof(ApiConfig));

// Configura o objeto de configura��o
builder.Services.Configure<ApiConfig>(apiConfigSection);
builder.Services.AddSingleton<IApiConfig>(x => x.GetRequiredService<IOptions<ApiConfig>>().Value);
#endregion

#region Injecao de Dependecias
// repositorios
builder.Services.AddSingleton<IRepositoryClient, RepositoryClient>();
//servicos
builder.Services.AddScoped<ClientService>();
#endregion

builder.Services.AddControllers();
// Saiba mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
