using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        public static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogException(Exception ex)
        {
            logger.Log(LogLevel.Error, "\r\nError Code: {0}\r\nMessage: {1}\r\nStack Trace: {2}\r\nInner Exception: {3}\r\n{4}",
                Guid.NewGuid().ToString(),
                ex.Message,
                ex.StackTrace,
                ex.InnerException,
                "##################################################");
        }
    }
}
