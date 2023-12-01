using BelaApi.Interfaces;
using BelaApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BelaApi.Services
{
    public class ContatoAppService : IContatoAppService
    {
        private readonly Context _context;
        private readonly IClienteAppService _clienteAppService;
        public ContatoAppService(Context context, IClienteAppService clienteAppService)
        {
            _context = context;
            _clienteAppService = clienteAppService;
        }
        public async Task DeleteContatoAsync(string email)
        {
            var contato = await _context.ContatoDoClientes.FirstOrDefaultAsync(x => x.Email == email);
            if (contato == null)
                throw new Exception("Cliente não encontrado para exclusão");
            _context.Remove(contato);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContatoDoCliente>> GetAllContatoDoClientAsync()
        {
            var contatos = await _context.ContatoDoClientes.ToListAsync();
            var retorno = new List<ContatoDoCliente>();
            foreach (var contato in contatos)
            {
                contato.Nome = contato.Nome;
                contato.Telefone = contato.Telefone;
                contato.Email = contato.Email;
                contato.Relacionamento = contato.Relacionamento;
                contato.EmailClienteConexao = contato.EmailClienteConexao;

                retorno.Add(contato);
            }
            return retorno;
        }

        public async Task<ContatoDoCliente> GetContatoDoClienteByEmailAsync(string email)
        {
            var retorno = await _context.ContatoDoClientes.FirstOrDefaultAsync(x => x.Email == email);
            retorno ??= new ContatoDoCliente();
            return retorno;
        }

        public async Task<ContatoDoCliente> PostContatoDoClienteAsync(ContatoDoCliente contato)
        {
            if (contato is null)
                throw new Exception("Contato não pode ser nulo");

            var clienteConexao = await _clienteAppService.GetByEmailAsync(contato.EmailClienteConexao);

            //Se não for um contato Lead oriundo de indicação de cliente, o email de conexao será o Default
            if (clienteConexao.Email == null)
                contato.EmailClienteConexao = "belagricola@belagricola.com.br";
            else
                contato.EmailClienteConexao = clienteConexao.Email;

            await _context.AddAsync(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<ContatoDoCliente> UpdateContatoDoClienteAsync(ContatoDoCliente contato)
        {
            var obj = await GetContatoDoClienteByEmailAsync(contato.Email);
            if (obj is null)
                await PostContatoDoClienteAsync(contato);

            obj.Nome = contato.Nome;
            obj.Telefone = contato.Telefone;
            obj.Email = contato.Email;
            obj.Relacionamento = contato.Relacionamento;
            //O Email do cliente que indicou o contato não pode ser alterado.
            obj.EmailClienteConexao = obj.EmailClienteConexao;

            _context.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
