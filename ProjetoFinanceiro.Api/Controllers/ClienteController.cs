using Microsoft.AspNetCore.Mvc;
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
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService, IApiConfig apiConfig)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public List<ClienteDto> Get()
        {
            try
            {
                List<Cliente> clientes = _clienteService.Listar();
                List<ClienteDto> clientesDto = clientes != null ? Cliente.ConverterParaDto(clientes) : null;

                return clientesDto;
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ClienteDto Get(int id)
        {
            try
            {
                Cliente cliente = _clienteService.Pesquisar(id);
                ClienteDto dto = cliente != null ? cliente.ConverterParaDto() : null;
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
                _clienteService.Excluir(id);
                return $"Cliente: excluído com sucesso, Id: {id}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public string Post([Bind("Nome, Cpf")] ClienteDto clienteDto)
        {
            try
            {
                Cliente cliente = clienteDto.ConverterParaEntidade();
                _clienteService.Salvar(cliente);
                return $"Cliente: {cliente.Nome} cadastrado com sucesso, Id: {cliente.ClienteId}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public string Put([FromBody] ClienteDto clienteDto)
        {
            try
            {
                Cliente cliente = clienteDto.ConverterParaEntidade();
                _clienteService.Atualizar(cliente);
                return $"Cliente: {cliente.Nome} atualizado com sucesso, Id: {cliente.ClienteId}";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
