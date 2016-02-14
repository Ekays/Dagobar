using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dagobar.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Core.Bot.I.Run();
            Core.Bot.I.OnReceived += I_OnReceived;
        }

        void I_OnReceived(object sender, EventArgs e)
        {
            string data = ((Core.Network.ReceiveEventArgs)e).Data;
            Invoke((AddLineDelegate)AddLine, new object[] { data });
        }

        public delegate void AddLineDelegate(string line);
        public void AddLine(string line) {
            List<string> list = Helpers.Array.ArrayToList<string>(richTextBoxRawData.Lines);
            list.Add(line);
            richTextBoxRawData.Lines = list.ToArray();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.Bot.I.Close();
            Application.Exit();
        }
    }
}
