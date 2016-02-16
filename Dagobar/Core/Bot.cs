/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Dagobar.Core.ChatProcessing;
using System;
using System.Collections.Generic;

namespace Dagobar.Core
{
    public class Bot
    {
        #region Singleton
        // This is a singleton, because at any time, we only need one instance of this class.
        private static Bot instance = null;
        public static Bot I
        {
            get
            {
                if (instance == null) instance = new Bot(); // If the instance isn't initialized, create it!
                return instance;
            }
        }
        #endregion

        // Current channel the bot is on 
        public string CurrentChannel
        {
            get
            {
                return irc.CurrentChannel;
            }
        }

        // List of the loaded plugins
        public List<string> LoadedPlugins
        {
            get
            {
                return cp.LoadedPluginNames();
            }
        }

        private IRC irc; // Private member: the IRC object which makes a basic connection with an IRC server
        private ChatProcessor cp; // Private member: the CommandProcessor object which executes commands
        // ctor
        public Bot()
        {
            irc = new IRC(Properties.Settings.Default.BotChannel); // Initialize the IRC object with the last channel used
            irc.OnReceived += irc_OnReceived; // Bind the receive event

            cp = new ChatProcessor(); // Initialize the Chat Processor object
        }

        // Run: Simply connect and login to the Twitch server
        public void Run()
        {
            irc.Connect(ConnectionInformations.Twitch); // Connect to Twitch
            irc.Login(new AuthentificationInformations() // Login with the details in the Settings
            {
                Nick = Properties.Settings.Default.BotNickname,
                Password = Properties.Settings.Default.BotOAuth
            });
        }
        // Close: Disconnect from the Twitch server
        public void Close()
        {
            irc.Close(); // Close the connection with Twitch
        }

        // ChangeChannel: Switch to a new channel
        public void ChangeChannel(string newChannel)
        {
            irc.ChangeChannel(newChannel); // Tell the IRC instance to leave current channel and join a new one
        }

        // EventHandlers 
        public event EventHandler OnDataReceived; // This one is for raw data
        public event EventHandler OnMessageReceived; // And this one is for preprocessed messages

        public void irc_OnReceived(object sender, EventArgs e) // Event from the IRC instance sending a raw message
        {
            // Send the raw message event
            EventHandler localEvent = OnDataReceived;
            if (localEvent != null) localEvent(this, e);

            string data = ((Core.ReceiveDataEventArgs)e).Data; // Get the raw message from arguments
            string[] dataSplit = data.Split(' '); // Split the raw message with a space

            if (dataSplit.Length >= 2 && dataSplit[1] == "PRIVMSG") // This checks if the data is a user's message
            {
                /* 
                 * A lot of processing in the following lines
                 * */
                string username = data.Split('!')[0].Remove(0, 1);

                string text = "";

                for (int i = 3; i < dataSplit.Length; i++)
                {
                    text += dataSplit[i] + " ";
                }

                text = text.Remove(0, 1);
                text = text.Remove(text.Length - 1, 1);

                // Send the processed message event
                localEvent = OnMessageReceived;
                if (localEvent != null) localEvent(this, (EventArgs) new Core.ReceiveMessageEventArgs(username, text));
            }
        }

        // SendChannelMessage: Send a message in the current channel
        public void SendChannelMessage(string message)
        {
            irc.SendChannelMessage(message);
        }
        
    }
}
