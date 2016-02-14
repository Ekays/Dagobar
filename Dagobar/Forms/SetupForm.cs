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
            if (ValidateOAuth(textBoxOAuth.Text) && textBoxBotNick.Text.Length > 0 && textBoxOwner.Text.Length > 0)
            {
                Properties.Settings.Default.BotNickname = textBoxBotNick.Text;
                Properties.Settings.Default.BotOAuth = textBoxOAuth.Text;
                Properties.Settings.Default.BotOwner = textBoxOwner.Text;
                Properties.Settings.Default.HasBeenSetuped = true;
                Properties.Settings.Default.Save();

                ConnectingForm f = new ConnectingForm();
                f.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Certains paramètres sont invalides !", "Erreur lors de la configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ValidateOAuth(string oauth)
        {
            return oauth.StartsWith("oauth:") && oauth.Length == 36;
        }
    }
}
