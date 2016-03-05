/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Dagobar.Forms;
using Nevron.Nov;
using Nevron.Nov.Windows.Forms;
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

            // Apply license for redistribution here
            NLicenseManager.Instance.SetLicense(new NLicense("99040c6f01a38c43bcc8a01902004100027d84097206d449"));

            // Install Nevron Open Vision for Windows Forms
            NNovApplicationInstaller.Install();

            Core.Bot.I.Run(); // Run the bot instance
            Core.TwitchAPI.I.Run(); // Run the Twitch API fetcher

            if (Properties.Settings.Default.HasBeenSetuped) // If the bot as already been configured
                new MainForm().Show(); // Start the bots
            else
                new SetupForm().Show(); // else show the Setup form

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
