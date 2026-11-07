using System;
using System.IO;
using System.Windows.Forms;

namespace S2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) => ShowError(e.Exception);
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, e) => ShowError(e.ExceptionObject as Exception);
            Application.Run(new LoginForm());
        }

        private static void ShowError(Exception ex)
        {
            string message = ex == null ? "Unknown error" : ex.ToString();
            File.WriteAllText(Path.Combine(Application.StartupPath, "error.log"), message);
            MessageBox.Show(message, "S2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
