using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories
{
    public interface ILogRepository
    {
        void InsereLog(string tipo);
        int TotalRegistros();
    }
}
