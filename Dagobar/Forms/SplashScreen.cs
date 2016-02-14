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

            //Show next form
            this.Close();
        }
    }
}
