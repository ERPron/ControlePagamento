using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<PagamentoDTO> GetByClienteIdAsync(string clienteId);
        Task<PagamentoDTO> GetByIdAsync(string id);
        Task<PagamentoDTO> AddAsync(PagamentoDTO? pagamentoDTO);
        Task<PagamentoDTO> UpdateAsync(PagamentoDTO? pagamentoDTO);
    }
}
