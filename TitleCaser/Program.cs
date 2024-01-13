using System;
using System.Windows.Forms;
using TitleCaser.Helpers;

namespace TitleCaser
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SetProcessDPIAware();
#if RELEASE
            CheckForIllegalCrossThreadCalls = false;
#endif
            CultureHelper.GloballySetCultureToGB();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));
        }
    }
}
