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
            Core.Bot.I.OnDataReceived += I_OnReceived;
            Core.Bot.I.OnMessageReceived += I_OnMessageReceived;
        }

        void I_OnMessageReceived(object sender, EventArgs e)
        {
            string data = ((Core.ReceiveMessageEventArgs)e).Username + ": " + ((Core.ReceiveMessageEventArgs)e).Text;
            Invoke((AddLineChatDelegate)AddLineChat, new object[] { data });
        }

        void I_OnReceived(object sender, EventArgs e)
        {
            string data = ((Core.ReceiveDataEventArgs)e).Data;
            Invoke((AddLineRawDataDelegate)AddLineRawData, new object[] { data });
        }

        public delegate void AddLineRawDataDelegate(string line);
        public void AddLineRawData(string line)
        {
            List<string> list = Helpers.Array.ArrayToList<string>(richTextBoxRaw.Lines);
            list.Add(line);
            richTextBoxRaw.Lines = list.ToArray();
            richTextBoxRaw.SelectionStart = richTextBoxRaw.Text.Length;
            richTextBoxRaw.ScrollToCaret();
        }

        public delegate void AddLineChatDelegate(string line);
        public void AddLineChat(string line)
        {
            List<string> list = Helpers.Array.ArrayToList<string>(richTextBoxChat.Lines);
            list.Add(line);
            richTextBoxChat.Lines = list.ToArray();
            richTextBoxChat.SelectionStart = richTextBoxChat.Text.Length;
            richTextBoxChat.ScrollToCaret();
        }

        private void textBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || textBoxChat.Text == String.Empty) return;

            Core.Bot.I.SendChannelMessage(textBoxChat.Text);
            AddLineChat(Properties.Settings.Default.BotNickname + ": " + textBoxChat.Text);
            textBoxChat.Text = String.Empty;
        }
    }
}
