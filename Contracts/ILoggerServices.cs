using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log_Implementataions.Contracts
{
    public interface ILoggerServices
    {
        void LogInfo(string mesage);
        void LogWarn(string mesage);
        void LogDebug(string mesage);
        void LogError(string mesage);
    }
}
