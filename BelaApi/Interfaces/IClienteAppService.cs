using BelaApi.Models;

namespace BelaApi.Interfaces
{
    public interface IClienteAppService
    {
        Task<ClienteModel?> GetByEmailAsync(string email);
        Task<List<ClienteModel>> GetAllClientesAsync();
        Task<ClienteModel?> PutClienteAsync(ClienteModel cliente);
        Task DeleteClienteAsync(string email);
        Task<ClienteModel?> UpdateClienteAsync(ClienteModel cliente);
    }
}
