using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO> GetByIdAsync(string id);
        Task<ClienteDTO> AddAsync(ClienteDTO? clienteDTO);
    }
}
