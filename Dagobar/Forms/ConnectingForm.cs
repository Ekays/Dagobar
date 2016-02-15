/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System;
using System.Threading;
using System.Windows.Forms;

namespace Dagobar.Forms
{
    public partial class ConnectingForm : Form
    {
        public ConnectingForm()
        {
            InitializeComponent();
        }

        private void ConnectingForm_Load(object sender, EventArgs e)
        {
            //TODO: Thread this
            Core.Bot.I.Run(); // Run the bot
            MainForm f = new MainForm(); // Ouvre la fenêtre principale
            f.Show();

            this.Close(); // Fermer cette fenêtre
        }
    }
}
