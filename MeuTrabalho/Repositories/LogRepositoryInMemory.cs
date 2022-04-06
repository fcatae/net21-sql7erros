using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories
{
    public class LogRepositoryInMemory : ILogRepository
    {
        int total;

        public void InsereLog(string tipo)
        {
            
        }

        public int TotalRegistros()
        {
            return total++;
        }
    }
}
