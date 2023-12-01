using BelaApi.Interfaces;
using BelaApi.Models;
using BelaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BelaApi.Controllers
{
    [ApiController]
    [Route("Contato/")]
    public class ContatoController : Controller
    {
        private readonly Context _context;
        private readonly IContatoAppService _contatoAppService;
        public ContatoController(Context context, IContatoAppService contato)
        {
            _context = context;
            _contatoAppService = contato;
        }

        [HttpPost("PostContato")]
        [AllowAnonymous]
        public async Task<IActionResult> PostContato([FromBody] ContatoDoCliente contato)
        {
            try
            {
                var response = await _contatoAppService.PostContatoDoClienteAsync(contato);
                return Ok(response);
            }
            catch
            {
                throw new Exception("Não foi possível criar contato.");
            }
        }

        [HttpGet("GetContatoByEmail{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetContatoByEmail(string email)
        {
            try
            {
                var retorno = await _contatoAppService.GetContatoDoClienteByEmailAsync(email);
                return Ok(retorno);
            }
            catch
            {
                throw new Exception("Não existe contato com o email informado.");
            }
        }

        [HttpGet("GetAllContatos")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllContatos()
        {
            try
            {
                var retorno = await _contatoAppService.GetAllContatoDoClientAsync();
                return Ok(retorno);
            }
            catch
            {
                throw new Exception("Não existe contatos cadastrados.");
            }
        }

        [HttpPost("UpdateContato")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateContato([FromBody] ContatoDoCliente contato)
        {
            try
            {
                await _contatoAppService.UpdateContatoDoClienteAsync(contato);
                return Ok("Contato atualizado com Sucesso.");
            }
            catch
            {
                throw new Exception("Não foi possível atualizar cliente.");
            }
        }

        [HttpDelete("DeleteContato/{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteContato(string email)
        {
            try
            {
                await _contatoAppService.DeleteContatoAsync(email);
                return Ok("Contato excluido com Sucesso.");
            }
            catch
            {
                throw new Exception("Não foi possível excluir contato. Contato Inexistente.");
            }
        }
    }
}
