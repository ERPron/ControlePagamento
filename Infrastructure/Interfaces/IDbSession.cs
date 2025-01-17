using System.Data;

namespace Infrastructure.Interfaces
{
    public interface IDbSession : IDisposable
    {
        public IDbConnection Connection { get; }
    }
}
