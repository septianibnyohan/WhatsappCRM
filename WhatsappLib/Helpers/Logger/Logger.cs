using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Helpers.Logger
{
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
    }
    public class FileLogger : LogBase
    {
        public string filePath = "Log\\" + DateTime.Now.ToString("yyyyMMdd") + "Log.txt";

        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    //streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " : ");
                    streamWriter.WriteLine("======================================== " + DateTime.Now.ToString("HH:mm:ss") + " ========================================");
                    streamWriter.WriteLine(message);
                    //streamWriter.WriteLine("======================================== "+ DateTime.Now.ToString("HH:mm:ss") + " ========================================");
                    streamWriter.Close();
                }
            }
        }

        public class DBLogger : LogBase
        {
            string connectionString = string.Empty;
            public override void Log(string message)
            {
                lock (lockObj)
                {
                    //Code to log data to the database
                }
            }
        }

        public class EventLogger : LogBase
        {
            public override void Log(string message)
            {
                lock (lockObj)
                {
                    EventLog eventLog = new EventLog("");
                    eventLog.Source = "IDGEventLog";
                    eventLog.WriteEntry(message);
                }
            }
        }
    }
}
