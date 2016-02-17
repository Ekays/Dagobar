/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace Dagobar.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Bind events
            Core.Bot.I.OnDataReceived += I_OnDataReceived;
            Core.Bot.I.OnMessageReceived += I_OnMessageReceived;
            Core.Bot.I.OnJoin += I_OnJoin;
            Core.Bot.I.OnPart += I_OnPart;
            Core.TwitchAPI.I.OnFetched += I_OnFetched;
        }

        void I_OnPart(object sender, EventArgs e)
        {
            RemoveItemListbox(listBoxChatters, ((Core.JoinNPartEventArgs)e).Username);
        }

        void I_OnJoin(object sender, EventArgs e)
        {
            AddItemListbox(listBoxChatters, ((Core.JoinNPartEventArgs)e).Username);
        }

        void I_OnFetched(object sender, EventArgs e)
        {
            // Update the viewer count label thread safe
            ChangeLabelText(labelViewers, (string) Core.TwitchAPI.I.Values["chatters"]["chatter_count"]);
        }

        void I_OnMessageReceived(object sender, EventArgs e)
        {
            // Print the processed message
            string data = ((Core.ReceiveMessageEventArgs)e).Username + ": " + ((Core.ReceiveMessageEventArgs)e).Text;
            try
            {
                Invoke((AddLineChatDelegate)AddLineChat, new object[] { data });
            }
            catch (Exception) { }
        }

        void I_OnDataReceived(object sender, EventArgs e)
        {
            // Print the raw message
            string data = ((Core.ReceiveDataEventArgs)e).Data;
            try
            {
                Invoke((AddLineRawDataDelegate)AddLineRawData, new object[] { data });
            }
            catch (Exception) { }
        }

        // AddeLineRaw: Add a line to the raw data rich text box , thread safe
        public delegate void AddLineRawDataDelegate(string line);
        public void AddLineRawData(string line)
        {
            List<string> list = Helpers.Array.ArrayToList<string>(richTextBoxRaw.Lines);
            list.Add(line);
            richTextBoxRaw.Lines = list.ToArray();
            richTextBoxRaw.SelectionStart = richTextBoxRaw.Text.Length;
            richTextBoxRaw.ScrollToCaret();
        }

        // AddeLineChat: Add a line to the chat data rich text box , thread safe
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
            if (e.KeyCode != Keys.Enter || textBoxChat.Text == String.Empty) return; // If the key is different then Enter or if the textbox is empty, return

            Core.Bot.I.SendChannelMessage(textBoxChat.Text); // Else send the message
            AddLineChat(Properties.Settings.Default.BotNickname + ": " + textBoxChat.Text); // Add the message to the Chat Box
            textBoxChat.Text = String.Empty; // Reset the textbox
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close(); // Close this form, and generaly, the program
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            new SetupForm().Show(); // Show the settings form  
            this.Close(); // And close this one
        }

        private void buttonChangeChannel_Click(object sender, EventArgs e)
        {
            string newChannel = Microsoft.VisualBasic.Interaction.InputBox("Nom du nouveau channel: ", "Dagobar", Properties.Settings.Default.BotOwner); //@TODO: Make a custom input box
            if (newChannel == String.Empty) return; // Ask for a new channel and check if it is not empty
            Core.Bot.I.ChangeChannel(newChannel); // Set the new channel
            Properties.Settings.Default.BotChannel = newChannel; // Change it in the settings
            Properties.Settings.Default.Save(); // Save the settings
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageInformations) // On tab changed, if new tab is informations tab
            {
                UpdateInformations(); // Update informations in this tab
            }
        }

        // UpdateInformations: Update the displayed informations in the Informations tab
        private void UpdateInformations()
        {
            labelChannel.Text = Core.Bot.I.CurrentChannel; // Set the channel label to current channel

            string pluginsText = ""; // Set the plugin label to loaded plugins
            bool first = true;
            foreach(string s in Core.Bot.I.LoadedPlugins) {
                if (first)
                {
                    first = !first;
                    pluginsText += s; 
                }
                else pluginsText += "  -  " + s; 
            }
            labelPlugins.Text = pluginsText;
        }

        public delegate void ChangeLabelTextDelegate(Label label, string text);
        public void ChangeLabelText(Label label, string text)
        {
            if (InvokeRequired)
                Invoke((ChangeLabelTextDelegate)ChangeLabelText, new object[] { label, text });
            else
                label.Text = text;
        }

        public delegate void AddItemListboxDelegate(ListBox listbox, string text);
        public void AddItemListbox(ListBox listbox, string text)
        {
            if (InvokeRequired)
                Invoke((AddItemListboxDelegate)AddItemListbox, new object[] { listbox, text });
            else
                listbox.Items.Add(text);
        }

        public delegate void RemoveItemListboxDelegate(ListBox listbox, string text);
        public void RemoveItemListbox(ListBox listbox, string text)
        {
            if (InvokeRequired)
                Invoke((RemoveItemListboxDelegate)RemoveItemListbox, new object[] { listbox, text });
            else
                listbox.Items.Remove(text);
        }

        private void richTextBoxChat_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // When the user clicks a link, ask if he wants to open it
            if (MessageBox.Show("Voulez-vous ouvrir ce lien ?", e.LinkText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(e.LinkText); // If yes, open it
            }
        }
    }
}
