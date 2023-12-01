using BelaApi.Interfaces;
using BelaApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BelaApi.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly Context _context;
        public ClienteAppService(Context context)
        {
            _context = context;
        }
        public async Task DeleteClienteAsync(string email)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.Email == email);
            if (cliente == null)
                throw new Exception("Cliente não encontrado para exclusão");
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClienteModel>> GetAllClientesAsync()
        {
            var clientes = await _context.Cliente.ToListAsync();
            var retorno = new List<ClienteModel>();
            foreach (var cliente in clientes)
            {
                cliente.Nome = cliente.Nome;
                cliente.Email = cliente.Email;
                cliente.Cidade = cliente.Cidade;

                retorno.Add(cliente);
            }
            return retorno;
        }

        public async Task<ClienteModel?> GetByEmailAsync(string email)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.Email == email);
                cliente ??= new ClienteModel();
            return cliente;
        }

        public async Task<ClienteModel?> PutClienteAsync(ClienteModel cliente)
        {
            if (cliente is null)
                throw new Exception("Cliente não pode ser nulo!");
            var verCliente = await GetByEmailAsync(cliente.Email);
            if (verCliente != null)
                await UpdateClienteAsync(cliente);
            else
            {
                await _context.Cliente.AddAsync(cliente);
                await _context.SaveChangesAsync();
            }
            return cliente;
        }

        public async Task<ClienteModel?> UpdateClienteAsync(ClienteModel cliente)
        {
            var obj = await GetByEmailAsync(cliente.Email);
            if (obj is null)
                await PutClienteAsync(cliente);

            obj.Nome = cliente.Nome;
            obj.Email = obj.Email;
            obj.Cidade = cliente.Cidade;
            obj.Telefone = cliente.Telefone;
            obj.Senha = cliente.Senha;
            obj.DataNascimento = cliente.DataNascimento;

            _context.Cliente.Update(obj);
            _context.SaveChanges();
            return obj;
        }
    }
}
