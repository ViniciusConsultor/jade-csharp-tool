using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HFBBS
{
    public interface IFormLog
    {
        void Log(string message);
    }

    public class LogManager
    {
        private IFormLog formLogger;

        private string logPath;

        public void Info(string message)
        {
            this.formLogger.Log(message);
        }

        public void Error(string message)
        {
            this.formLogger.Log(message);
            lock (exLock)
            {
                string exFile = "error.txt";
                StreamWriter sw = new StreamWriter(exFile, true);
                sw.Write(DateTime.Now.ToString() + "\t\t");
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
        }

        public void Error(Exception ex)
        {
            Error(ex.Message);
        }

        public LogManager(IFormLog formLogger, string logPath)
        {
            this.formLogger = formLogger;
            this.logPath = logPath;
        }

        object exLock = new object();


        private static object logLock = new object();
        public static void LogError(Exception ex)
        {
            lock (logLock)
            {
                string exFile = string.Format("Error-{0}.txt", DateTime.Today.ToString("yyyy-MM-dd"));
                StreamWriter sw = new StreamWriter(exFile, true);
                sw.Write(DateTime.Now.ToString() + "\t\t");
                sw.WriteLine(ex.Message);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
