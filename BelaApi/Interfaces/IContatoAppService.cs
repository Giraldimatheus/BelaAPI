using BelaApi.Models;

namespace BelaApi.Interfaces
{
    public interface IContatoAppService
    {
        Task<ContatoDoCliente> PostContatoDoClienteAsync(ContatoDoCliente contato);
        Task<ContatoDoCliente> UpdateContatoDoClienteAsync(ContatoDoCliente contato);
        Task DeleteContatoAsync(string email);
        Task<ContatoDoCliente> GetContatoDoClienteByEmailAsync(string email);
        Task<List<ContatoDoCliente>> GetAllContatoDoClientAsync();
    }
}
