using System;
using System.Windows.Forms;
using NLog;

namespace ElrondConsole
{
    static class Program
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            Application.Run(new frmMain());
#else
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new frmMain());
#endif
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                while (ex != null)
                {
                    _log.Debug(ex, "Fatal error: " + ex.Message);
                    ex = ex.InnerException;
                }
            }
            catch { }

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.ExceptionObject as Exception;
                while (ex != null)
                {
                    _log.Debug(ex, "Fatal error: " + ex.Message);
                    ex = ex.InnerException;
                }
            }
            catch { }
        }
    }
}
