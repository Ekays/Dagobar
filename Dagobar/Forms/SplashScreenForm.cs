using Dagobar.Forms;
using System;
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
            timerClose.Start();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            timerClose.Stop();

            if (Properties.Settings.Default.HasBeenSetuped)
            {
                SetupForm f = new SetupForm();
                f.Show();
            }
            else
            {
                MainForm f = new MainForm();
                f.Show();
            }
            this.Hide();
        }
    }
}
