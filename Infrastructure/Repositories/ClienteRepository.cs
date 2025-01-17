using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly IDbSession _appSession;

        public ClienteRepository(IDbSession appSession)
        {
            _appSession = appSession;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync(string commandSql, Cliente dbEntity, IDbTransaction dbTransation)
        {
            return await _appSession.Connection.QueryAsync<Cliente>(commandSql, dbEntity, dbTransation, null, null);
        }

        public async Task<Cliente?> GetByIdAsync(string commandSql, Cliente dbEntity, IDbTransaction dbTransation)
        {
            return await _appSession.Connection.QuerySingleOrDefaultAsync<Cliente>(commandSql, dbEntity, dbTransation, null, null);
        }

        public async Task<int> AddAsync(string commandSql, Cliente dbEntity, IDbTransaction dbTransation)
        {
            return await _appSession.Connection.ExecuteScalarAsync<int>(commandSql, dbEntity, dbTransation, null, null);
        }
    }
}
