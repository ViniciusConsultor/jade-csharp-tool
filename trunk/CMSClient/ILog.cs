using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
namespace Jade
{
    public interface ILog
    {
        void Error(string msg);
        void Info(string msg);
        void Success(string msg);
        void Warn(string msg);
    }

    public class Log4Log
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("ConsoleLog");
        static log4net.ILog errorLog = log4net.LogManager.GetLogger("ErrorLog");


        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Debug(string message)
        {
            log.Debug(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Info(string message)
        {
            log.Info(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Info(string format, params object[] args)
        {
            log.Info(Format(format, args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(string message)
        {
            log.Warn(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(string format, params object[] args)
        {
            log.Warn(Format(format, args));
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void ErrorUrl(string url, string message)
        {
            errorLog.Error(url + " " + message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(string message)
        {
            errorLog.Error(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(string format, params object[] args)
        {
            errorLog.Error(Format(format, args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Exception(Exception exception)
        {
            errorLog.Fatal(exception);
            if (Jade.Properties.Settings.Default.IsOnline)
            {
                try
                {
                    (CacheObject.DownloadDataDAL as Jade.Model.MySql.NewsDAL).AddLog(Jade.Properties.Settings.Default.Name, "Message:" + exception.Message + "\r\nStackTrace:" + exception.StackTrace, "未处理异常");
                }
                catch
                {
                }
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Exception(string message, Exception exception)
        {
            errorLog.Fatal(message, exception);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string Format(string format, params object[] args)
        {
            return string.Format(format, args);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Close()
        {
            errorLog.Logger.Repository.Shutdown();
            errorLog = null;
            log.Logger.Repository.Shutdown();
            log = null;
            GC.Collect();
        }
    }
}
