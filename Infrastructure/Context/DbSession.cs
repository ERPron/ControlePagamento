using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Context
{
    public class DbSession : IDbSession
    {
        public IDbConnection Connection { get; }

        public DbSession(IConfiguration configuration)
        {
            try
            {
                //Pega a string de conexao com o banco de dados
                var con = configuration.GetConnectionString("DefaultConnection");
                //Instancia de conexao com o banco de dados
                Connection = new SqlConnection(con);
                //Abre a conexao com o banco de dados
                Connection.Open();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void Dispose() => Connection?.Dispose();
    }
}
