using Dagobar.Core.Network;
using System;

namespace Dagobar.Core
{
    class Bot
    {
        #region Singleton
        private static Bot instance = null;
        public static Bot I
        {
            get
            {
                if (instance == null) instance = new Bot();

                return instance;
            }
        }
        #endregion

        private IRC irc;

        public Bot()
        {
            irc = new IRC(Properties.Settings.Default.BotOwner);
            irc.OnReceived += irc_OnReceived;
        }

        public void Run()
        {
            irc.Connect(ConnectionInformations.Twitch);
            irc.Login(new AuthentificationInformations()
            {
                Nick = Properties.Settings.Default.BotNickname,
                Password = Properties.Settings.Default.BotOAuth
            });
        }
        public void Close()
        {
            irc.Close();
        }

        public event EventHandler OnDataReceived;
        public event EventHandler OnMessageReceived;

        public void irc_OnReceived(object sender, EventArgs e)
        {
            EventHandler localEvent = OnDataReceived;
            if (localEvent != null) localEvent(this, e);

            string data = ((Core.ReceiveDataEventArgs)e).Data;
            string[] dataSplit = data.Split(' ');

            if (dataSplit.Length >= 2 && dataSplit[1] == "PRIVMSG")
            {
                string username = data.Split('!')[0].Remove(0, 1);

                string text = "";

                for (int i = 3; i < dataSplit.Length; i++)
                {
                    text += dataSplit[i] + " ";
                }

                text = text.Remove(0, 1);
                text = text.Remove(text.Length - 1, 1);

                localEvent = OnMessageReceived;
                if (localEvent != null) localEvent(this, (EventArgs) new Core.ReceiveMessageEventArgs(username, text));
            }
        }

        public void SendChannelMessage(string message)
        {
            irc.SendChannelMessage(message);
        }
        
    }
}
