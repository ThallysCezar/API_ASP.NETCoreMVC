using Microsoft.AspNetCore.Mvc;
using ProjectFinance.Domain.Configuration;
using ProjectFinance.Domain.DTOs;
using ProjectFinance.Services.Services;

namespace ProjectFinance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService, IApiConfig apiConfig)
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