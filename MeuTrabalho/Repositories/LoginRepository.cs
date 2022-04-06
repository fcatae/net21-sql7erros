using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace MeuTrabalho.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        readonly string _connectionString;

        public LoginRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string FindUsername(string email, string password)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            var ret = connection.Query(
                $"SELECT username FROM tbLogin WHERE email=@email AND pwd=@pwd",
                new { email = email, pwd = password }
                );

            string username = ret.FirstOrDefault();

            return username;
        }
    }
}
