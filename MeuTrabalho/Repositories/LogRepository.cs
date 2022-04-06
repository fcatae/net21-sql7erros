using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES (@tipo)", connection);
                sql.Parameters.AddWithValue("@tipo", tipo);

                sql.ExecuteScalar();
            }
        }

        public int TotalRegistros()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM tbLog ORDER BY 1", connection);

                int total = (int)command.ExecuteScalar();

                return total;
            }
        }
    }
}
