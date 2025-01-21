using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<IEnumerable<PagamentoDTO>> GetByClienteIdAsync(int clienteId);
        Task<PagamentoDTO> GetByIdAsync(int id);
        Task<PagamentoDTO> AddAsync(PagamentoDTO? pagamentoDTO);
        Task<PagamentoDTO> UpdateAsync(PagamentoDTO? pagamentoDTO);
    }
}
