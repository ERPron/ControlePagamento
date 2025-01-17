using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDbSession AppDbSession { get; }
        public IDbTransaction? Transaction { get; private set; }
        public UnitOfWork(IDbSession connection)
        {
            AppDbSession = connection;
            Transaction = AppDbSession.Connection.BeginTransaction();

        }
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            if (Transaction == null)
                Transaction = AppDbSession.Connection.BeginTransaction(isolationLevel);
            return Transaction;
        }
        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }
        public void Rollback()
        {
            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }
        public void Dispose()
        {
            AppDbSession?.Dispose();
            Transaction?.Dispose();
        }
    }
}
