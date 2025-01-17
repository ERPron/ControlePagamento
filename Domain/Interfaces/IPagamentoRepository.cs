using Domain.Entities;
using System.Data;

namespace Domain.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> GetByClienteIdAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction);
        Task<Pagamento> GetByIdAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction);
        Task<int> AddAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction);
        Task<int> UpdateAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction);
    }
}
