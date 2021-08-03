using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WhatsappLib.Helpers.Logger;
using static WhatsappLib.Helpers.Logger.FileLogger;

namespace WhatsappLib.Helpers
{
    public static class LogHelper
    {
        private static LogBase logger = null;
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogTarget.Database:
                    logger = new DBLogger();
                    logger.Log(message);
                    break;
                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }

        public static void LogEx(_Exception ex)
        {
            var error = "error : " + ex.Message + "\n";
            error += "stacktace : " + ex.StackTrace;
            Log(LogTarget.File, error);
        }
    }
}
