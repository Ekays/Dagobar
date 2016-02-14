using System;
using System.Windows.Forms;

namespace Dagobar.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Core.Bot.I.Close();
            Application.Exit();
        }
    }
}
