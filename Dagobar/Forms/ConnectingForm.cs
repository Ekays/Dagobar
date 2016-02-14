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
            Core.Bot.I.Run();
            Thread.Sleep(1000);
        }
    }
}
