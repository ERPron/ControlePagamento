using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<ClienteDTO> AddAsync(ClienteDTO? clienteDTO);
    }
}
