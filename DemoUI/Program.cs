using KTX_PHONG;
using System;
using System.Windows.Forms;

namespace DemoUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDashBoard());
        }
    }
}
