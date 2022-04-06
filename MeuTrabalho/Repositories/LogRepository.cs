using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MeuTrabalho.Repositories
{
    public class LogRepository : ILogRepository
    {
        string _connectionString;

        public LogRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void InsereLog(string tipo)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Execute("INSERT tbLog VALUES (@tipo)", new { tipo = tipo });
        }

        public int TotalRegistros()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            var resultado = connection.QuerySingle("SELECT total=COUNT(*) FROM tbLog ORDER BY 1");

            return (int)resultado.total;
        }
    }
}
