using System;
using System.Windows.Forms;
using BSPLumpManager.Forms;

namespace BSPLumpManager
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
            Application.Run(new LumpManager());
        }
    }
}