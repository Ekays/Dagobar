﻿using Dagobar.Core.Network;
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

        public event EventHandler OnReceived;
        public void irc_OnReceived(object sender, EventArgs e)
        {
            EventHandler localEvent = OnReceived;
            if (localEvent != null) localEvent(this, e);
        }

        public void SendChannelMessage(string message)
        {
            irc.SendChannelMessage(message);
        }
        
    }
}
