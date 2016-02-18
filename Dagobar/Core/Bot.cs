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

        // EventHandlers 
        public event EventHandler OnDataReceived; // This one is for raw data
        public event EventHandler OnMessageReceived; // And this one is for preprocessed messages
        public event EventHandler OnJoin; // When someone joins the chat
        public event EventHandler OnPart; // When someone leaves :(
        public event EventHandler OnChannelChanged; // When the current channel is remplaced

        private IRC irc; // Private member: the IRC object which makes a basic connection with an IRC server
        private ChatProcessor cp; // Private member: the CommandProcessor object which executes commands
        // ctor
        public Bot()
        {
            irc = new IRC(Properties.Settings.Default.BotChannel); // Initialize the IRC object with the last channel used
            irc.OnReceived += irc_OnReceived; // Bind the receive event
        }

        // Run: Simply connect and login to the Twitch server
        public void Run()
        {
            irc.Connect(ConnectionInformations.Twitch); // Connect to Twitch

            /*
             * Ask for Twitch IRC permissions
             * */
            irc.SendData(new string[]{
                "CAP REQ :twitch.tv/tags",
                "CAP REQ :twitch.tv/membership",
                "CAP REQ :twitch.tv/commands"
            });

            irc.Login(new AuthentificationInformations() // Login with the details in the Settings
            {
                Nick = Properties.Settings.Default.BotNickname,
                Password = Properties.Settings.Default.BotOAuth
            });

            cp = new ChatProcessor(this, Core.TwitchAPI.I); // Initialize the Chat Processor object
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

            EventHandler localEvent = OnChannelChanged;
            if (localEvent != null) localEvent(this, EventArgs.Empty);
        }

        public void irc_OnReceived(object sender, EventArgs e) // Event from the IRC instance sending a raw message
        {
            // Send the raw message event
            EventHandler localEvent = OnDataReceived;
            if (localEvent != null) localEvent(this, e);

            string data = ((Core.ReceiveDataEventArgs)e).Data; // Get the raw message from arguments
            string[] dataSplit = data.Split(' '); // Split the raw message with a space

            if (dataSplit.Length == 3)
            {
                if (dataSplit[1] == "JOIN"){
                    string username = dataSplit[0].Split('!')[0].Remove(0, 1);
                    string channel = dataSplit[2].Remove(0, 1);

                    localEvent = OnJoin;
                    if (localEvent != null) localEvent(this, new JoinPartEventArgs(username, channel));
                }
                else if (dataSplit[1] == "PART")
                {
                    string username = dataSplit[0].Split('!')[0].Remove(0, 1);
                    string channel = dataSplit[2].Remove(0, 1);

                    localEvent = OnPart;
                    if (localEvent != null) localEvent(this, new JoinPartEventArgs(username, channel));
                }
            }

            if (dataSplit.Length >= 3 && dataSplit[2] == "PRIVMSG") // This checks if the data is a user's message
            {
                /* 
                 * A lot of processing in the following lines
                 * */
                string username = dataSplit[1].Split('!')[0].Remove(0, 1);

                string text = "";

                for (int i = 4; i < dataSplit.Length; i++)
                {
                    text += dataSplit[i] + " ";
                }
                text = text.Remove(0, 1);
                text = text.Remove(text.Length - 1, 1);

                string[] informations = dataSplit[0].Remove(0, 1).Split(';');

                // Send the processed message event
                localEvent = OnMessageReceived;
                if (localEvent != null) localEvent(this, (EventArgs) new Core.ReceiveMessageEventArgs(username, text, informations));
            }
        }

        // SendChannelMessage: Send a message in the current channel
        public void SendChannelMessage(string message)
        {
            irc.SendChannelMessage(message);
        }
        
    }
}
