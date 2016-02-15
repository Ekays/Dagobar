using System;
using System.Threading;
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
            new SplashScreen().Show(); // Show the first form

            new Thread(CloseCheck).Start(); // Start the CloseCheck thread

            Application.Run(); // Run the application

        }

        // CloseCheck: Close the Program when needed
        static void CloseCheck()
        {
            while (Application.OpenForms.Count > 0) Thread.Sleep(1000); // While there is at least one form opened, wait

            Core.Bot.I.Close(); // Close the Bot if not closed

            // And exists the Program
            Application.ExitThread();
            Application.Exit();
        }
    }
}
