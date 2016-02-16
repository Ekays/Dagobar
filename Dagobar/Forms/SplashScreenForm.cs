/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Dagobar.Forms;
using System;
using System.Net;
using System.Windows.Forms;

namespace Dagobar
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timerClose.Start(); // On Load , start the 3 seconds timer

            // Dat simplest updater do'
            try
            {
                WebClient c = new WebClient();
                string lastVersion = c.DownloadString(Properties.Settings.Default.LastVersionAddress);
                string currentVersion = Properties.Settings.Default.Version;
                labelUpdate.Visible = lastVersion != currentVersion;
            }
            catch (WebException) { }
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            timerClose.Stop(); // On Tick, stop the timer

            if (Properties.Settings.Default.HasBeenSetuped) // If the bot as already been configured
                new ConnectingForm().Show(); // Start the bots
            else
                new SetupForm().Show(); // else show the Setup form

            this.Close(); // Close this form
        }
    }
}
