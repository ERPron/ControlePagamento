using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
        void Commit();
        void Rollback();
    }
}
