using Microsoft.AspNetCore.Mvc;
using ProjectFinance.Domain.Configuration;
using ProjectFinance.Domain.DTOs;
using ProjectFinance.Domain.Entities;
using ProjectFinance.Services.Services;

namespace ProjectFinance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        #region Props/ID

        private readonly ClientService _clientService;

        #endregion

        #region Constructor
        public ClientController(ClientService clientService, IApiConfig apiConfig)
        {
            _clientService = clientService;
        }

        #endregion

        #region Get

        [HttpGet]
        public List<DtoClient> Get()
        {
            try
            {
                List<Client> client = _clientService.Get();
                List<DtoClient> clientesDto = client != null ? Client.ConverterParaDto(client) : null;

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
                Client client = _clientService.Search(id);
                DtoClient dto = client != null ? client.ConverterParaDto() : null;
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                _clientService.Delete(id);
                return $"Cliente: excluído com sucesso, Id: {id}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Post

        [HttpPost]
        public string Post([Bind("Nome, Cpf")] DtoClient clientDto)
        {
            try
            {
                Client client = clientDto.ToEntity();
                _clientService.Save(client);
                return $"Cliente: {client.Name} cadastrado com sucesso, Id: {client.ClientId}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Put

        [HttpPut]
        public string Put([FromBody] DtoClient clientDto)
        {
            try
            {
                Client client = clientDto.ToEntity();
                _clientService.Update(client);
                return $"Cliente: {client.Name} atualizado com sucesso, Id: {client.ClientId}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}