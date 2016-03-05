/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System;
using System.Windows.Forms;

namespace Dagobar.Forms
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateOAuth(textBoxOAuth.Text) && textBoxBotNick.Text.Length > 0 && textBoxOwner.Text.Length > 0) // If all inputs are valide
            {
                // Define all the Settings
                Properties.Settings.Default.BotNickname = textBoxBotNick.Text;
                Properties.Settings.Default.BotOAuth = textBoxOAuth.Text;
                Properties.Settings.Default.BotOwner = textBoxOwner.Text;

                if (!Properties.Settings.Default.HasBeenSetuped) // If it's the first configuration
                {
                    Properties.Settings.Default.HasBeenSetuped = true; // Set as setuped
                    Properties.Settings.Default.BotChannel = Properties.Settings.Default.BotOwner; // And define default channel
                }
               
                Properties.Settings.Default.Save(); // Save the Settings

                new MainForm().Show(); // Show the next form

                this.Close(); // Close this form
            }
            else
            {
                MessageBox.Show("Certains paramètres sont invalides !", "Erreur lors de la configuration", MessageBoxButtons.OK, MessageBoxIcon.Error); // Else display a message
            }
        }

        // ValidateOAuth: Validate a OAuth token depending on its length and beginning
        private static bool ValidateOAuth(string oauth)
        {
            return oauth.StartsWith("oauth:") && oauth.Length == 36;
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            /*
             * On load, set the text as the existing values
             * */
            textBoxBotNick.Text = Properties.Settings.Default.BotNickname;
            textBoxOAuth.Text = Properties.Settings.Default.BotOAuth;
            textBoxOwner.Text = Properties.Settings.Default.BotOwner;
        }
    }
}
