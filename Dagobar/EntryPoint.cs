using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dagobar
{
    static class EntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new SplashScreen().Show();

            new Thread(CloseCheck).Start();

            Application.Run();

        }

        static void CloseCheck()
        {
            while (Application.OpenForms.Count > 0) Thread.Sleep(1000);

            Application.Exit();
        }
    }
}
