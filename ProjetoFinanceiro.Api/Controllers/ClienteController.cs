using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.DTOs;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Services.Services;

namespace ProjetoFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClienteController(ClientService clientService, IApiConfig apiConfig)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public List<DtoClient> Get()
        {
            try
            {
                List<Domain.Entities.Client> client = _clientService.Listar();
                List<DtoClient> clientesDto = client != null ? Domain.Entities.Client.ConverterParaDto(client) : null;

                return clientesDto;
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public DtoClient Get(int id)
        {
            try
            {
                Domain.Entities.Client client = _clientService.Pesquisar(id);
                DtoClient dto = client != null ? client.ConverterParaDto() : null;
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                _clientService.Excluir(id);
                return $"Cliente: excluído com sucesso, Id: {id}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public string Post([Bind("Nome, Cpf")] DtoClient clienteDto)
        {
            try
            {
                Domain.Entities.Client client = clienteDto.ConverterParaEntidade();
                _clientService.Salvar(client);
                return $"Cliente: {client.Name} cadastrado com sucesso, Id: {client.ClientId}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public string Put([FromBody] DtoClient clienteDto)
        {
            try
            {
                Domain.Entities.Client client = clienteDto.ConverterParaEntidade();
                _clientService.Atualizar(client);
                return $"Cliente: {client.Name} atualizado com sucesso, Id: {client.ClientId}";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
