using System.Diagnostics;

using Jade.CQA.Robot.Extensions;
using Jade.CQA.Robot.Interfaces;
using System;
using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot.Services
{
    /// <summary>
    /// Trace 日志
    /// </summary>
    public class SystemTraceLoggerService : ILog
    {
        #region ILog Members

        public void Verbose(string format, params object[] parameters)
        {
            Trace.TraceInformation(ToMessage(format, parameters));
        }

        public void Warning(string format, params object[] parameters)
        {
            Trace.TraceWarning(ToMessage(format, parameters));
        }

        public void Debug(string format, params object[] parameters)
        {
            System.Diagnostics.Debug.Write(ToMessage(format, parameters));
        }

        public void Error(string format, params object[] parameters)
        {
            Trace.TraceError(ToMessage(format, parameters));
        }

        public void FatalError(string format, params object[] parameters)
        {
            Trace.TraceError(ToMessage(format, parameters));
        }

        #endregion

        #region Class Methods

        private static string ToMessage(string format, object[] parameters)
        {
            return format.FormatWith(parameters);
        }

        #endregion
    }

    public class ConsoleLoggerService : ILog
    {
        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            AspectF.Define.
                NotNull(format, "format");

            Console.ForegroundColor = color;
            Console.Out.WriteLine(format, args);
            Console.ResetColor();
        }

        #region ILog 成员

        public void Verbose(string format, params object[] parameters)
        {
            WriteLine(ConsoleColor.White, format, parameters);
        }

        public void Warning(string format, params object[] parameters)
        {
            WriteLine(ConsoleColor.Yellow, format, parameters);
        }

        public void Debug(string format, params object[] parameters)
        {
            WriteLine(ConsoleColor.DarkYellow, format, parameters);
        }

        public void Error(string format, params object[] parameters)
        {
            WriteLine(ConsoleColor.DarkRed, format, parameters);
        }

        public void FatalError(string format, params object[] parameters)
        {
            WriteLine(ConsoleColor.Red, format, parameters);
        }

        #endregion
    }
}