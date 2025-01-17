using Domain.Entities;
using System.Data;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync(string commandSql, Cliente dbTEntity, IDbTransaction dbTransaction);
        Task<Cliente?> GetByIdAsync(string commandSql, Cliente dbTEntity, IDbTransaction dbTransaction);
        Task<int> AddAsync(string commandSql, Cliente dbTEntity, IDbTransaction dbTransaction);
    }
}
