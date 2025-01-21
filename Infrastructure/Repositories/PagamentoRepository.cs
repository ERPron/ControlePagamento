using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        protected readonly IDbSession _appSession;

        public PagamentoRepository(IDbSession appSession)
        {
            _appSession = appSession;
        }


        public async Task<IEnumerable<Pagamento?>> GetByClienteIdAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransation)
        {
            return await _appSession.Connection.QueryAsync<Pagamento>(commandSql, dbTEntity, dbTransation, null, null);
        }

        public async Task<Pagamento?> GetByIdAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction)
        {
            return await _appSession.Connection.QuerySingleOrDefaultAsync<Pagamento>(commandSql, dbTEntity, dbTransaction, null, null);
        }

        public async Task<int> AddAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction)
        {
            return await _appSession.Connection.ExecuteScalarAsync<int>(commandSql, dbTEntity, dbTransaction, null, null);
        }

        public async Task<int> UpdateAsync(string commandSql, Pagamento dbTEntity, IDbTransaction dbTransaction)
        {
            return await _appSession.Connection.ExecuteScalarAsync<int>(commandSql, dbTEntity, dbTransaction, null, null);
        }
    }
}
