/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Dagobar.Core.ChatProcessing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Welcome Plugin
 *  This plugin says welcome to everyone who say hi !
 * */
namespace WelcomePlugin
{
    public class WelcomePlugin_Main : IPlugin
    {
        public string Name { get { return "Welcome Plugin"; } set { Name = value; } } // Name of the plugin

        string configPath = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + @"\config.json"; // Path to the json file which stores the words list
        bool validConfig = false; // Is the config file valid 
        string[] welcomeWords; // Array of words used for recognition
        List<string> alreadyWelcomed = new List<string>(); // List of persons already welcomed

        // LoadConfig: Load the words used for recognition 
        private void LoadConfig()
        {
            JObject json;
            if (System.IO.File.Exists(configPath)) // If the file exists
            {
                try
                {
                    /*
                     * Try to get its json content
                     * */
                    string content = System.IO.File.ReadAllText(configPath, System.Text.Encoding.UTF8);
                    json = JObject.Parse(content);

                    welcomeWords = json["welcome"].Values<string>().ToArray<string>() ;

                    validConfig = true; // No error ? Config is valid
                }
                catch (Exception) { return; }
            }
        }

        public void Initialize(IPluginContext context)
        {
            // Bind event
            context.Bot.OnPart += Bot_OnPart;

            // Load config
            LoadConfig();
        }

        void Bot_OnPart(object sender, EventArgs e)
        {
            alreadyWelcomed.Remove(((Dagobar.Core.JoinPartEventArgs)e).Username); // If a viewer leaves, we can welcome him again
        }

        public void PerformCommand(IPluginContext context)
        {
            if (!validConfig) return;

            if (alreadyWelcomed.Contains(context.Username)) return; // Don't welcome twice

            string lowerText = context.Text.ToLower(); // Get the sended text to lower

            foreach (string welcome in welcomeWords) // Foreach welcome word
            {
                if (lowerText == welcome || lowerText.Contains(" " + welcome + " ") || lowerText.StartsWith(welcome + " ") || lowerText.EndsWith(" " + welcome)) // Is it as a word ( so not IN a word ) in the text
                {
                    alreadyWelcomed.Add(context.Username);
                    context.Bot.SendChannelMessage("Bienvenue @" + context.Username + "!"); // Say welcome !
                    break;
                }
            }
        }
    }
}
