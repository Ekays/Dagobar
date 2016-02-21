/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */
 
using Dagobar.Core;
using Dagobar.Core.ChatProcessing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WelcomePlugin
{
    public class WelcomePlugin : IPlugin
    {
        public string Name { get { return "Welcome"; } set { } }

        public List<string> welcomeWords = new List<string>(); // List of words used for recognition
        public List<string> welcomedUsers = new List<string>(); // List of users we already said Welcome

        public void Initialize(IPluginContext context)
        {
            try // Try to load the configuration
            {
                string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json"; // Get the config file 's path
                string content = File.ReadAllText(configPath, System.Text.Encoding.UTF8); // Read the content of the file
                JObject json = JObject.Parse(content); // Parse the content of the config file to json
                foreach (string word in json["welcome"]) // foreach entry
                {
                    welcomeWords.Add(word); // Add the entry to the list !
                }
            }
            catch (Exception) { } // File not found ... Don't notice

            // Bind events
            context.Bot.OnPart += Bot_OnPart;
            context.Bot.OnChannelChanged += Bot_OnChannelChanged;
        }

        void Bot_OnChannelChanged(object sender, EventArgs e)
        {
            welcomedUsers = new List<string>(); // When the bot changes his current channel, reset the list of users we already said Welcome
        }

        void Bot_OnPart(object sender, EventArgs e)
        {
            JoinPartEventArgs realEvent = (JoinPartEventArgs)e; // Cast the event args to his real type
            if (welcomedUsers.Contains(realEvent.Username)) welcomedUsers.Remove(realEvent.Username); // We can welcome the user again because he leaved
        }

        public void PerformCommand(IPluginContext context)
        {
            if (welcomeWords.Count == 0) return; // If the config hasn't been loaded, return
            if (welcomedUsers.Contains(context.Username)) return; // If the user has already been welcomed, return
            
            string lowerText = context.Text.ToLower(); // Get the user's message to lower case

            if (lowerText.StartsWith("!")) return; // If it's a command, return

            foreach (string welcomeWord in welcomeWords) // Foreach word in the config
            {
                string lowerWelcome = welcomeWord.ToLower(); // Get the welcome word to lower
                if (lowerText == lowerWelcome || lowerText.StartsWith(lowerWelcome + " ") || lowerText.Contains(" " + lowerWelcome + " ") || lowerText.EndsWith(" " + lowerWelcome)) // If the message contains the word alone ( not inside an other word )
                {
                    context.Bot.SendChannelMessage("Bienvenue @" + context.Username + "!"); // Say welcome !
                    welcomedUsers.Add(context.Username); // Add the user to the welcomed list
                    break; // Stop the recognition
                }
            }
        }
    }
}
