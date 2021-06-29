using Log_Implementataions.Contracts;

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log_Implementataions.Services
{
    public class LoggerServices : ILoggerServices
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string mesage)
        {
            logger.Debug(mesage);
        }
        public void LogError(string mesage)
        {
            logger.Error(mesage);
        }
        public void LogInfo(string mesage)
        {
            logger.Info(mesage);
        }
        public void LogWarn(string mesage)
        {
            logger.Warn(mesage);
        }
    }
}
