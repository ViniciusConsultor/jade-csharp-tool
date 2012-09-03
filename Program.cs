using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Jade
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常 
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            SplashScreenManager.ShowForm(typeof(StartScreen));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogUnhandledException(e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogUnhandledException(e.Exception);
        }

        static void LogUnhandledException(object exceptionobj)
        {
            Exception ex = exceptionobj as Exception;
            Log4Log.Exception(ex);
            Log4Log.Close();
            MessageBox.Show(ex.Message);
        }
    }
}
