using BelaApi.Interfaces;
using BelaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BelaApi.Controllers
{
    [ApiController]
    [Route("Cliente/")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet("GetAllAsync")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _clienteAppService.GetAllClientesAsync();
                return Ok(response);
            }
            catch
            {
                throw new Exception("Não foi possível encontrar o cliente.");
            }
        }

        [HttpGet("GetByEmail/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var response = await _clienteAppService.GetByEmailAsync(email);
                return Ok(response);
            }
            catch
            {
                throw new Exception("Não foi possível encontrar o cliente.");
            }
        }

        [HttpPost("PostCliente")]
        [AllowAnonymous]
        public async Task<IActionResult> PostCliente([FromBody] ClienteModel cliente)
        {
            try
            {
                var response = await _clienteAppService.PutClienteAsync(cliente);
                return Ok(response);
            }
            catch
            {
                throw new Exception("Não foi possível criar cliente. Veja se o cliente já não foi criado!");
            }
        }

        [HttpPost("UpdateCliente")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteModel cliente)
        {
            try
            {
                await _clienteAppService.UpdateClienteAsync(cliente);
                return Ok("Cliente alterado com Sucesso.");
            }
            catch
            {
                throw new Exception("Não foi possível atualizar o cliente.");
            }
        }

        [HttpDelete("DeleteCliente/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCliente(string email)
        {
            try
            {
                await _clienteAppService.DeleteClienteAsync(email);
                return Ok("Cliente deletado com Sucesso.");
            }
            catch
            {
                throw new Exception("Não foi possível criar cliente.");
            }
        }

    }
}
