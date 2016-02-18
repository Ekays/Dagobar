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

        public List<string> welcomeWords = new List<string>();
        public List<string> welcomedUsers = new List<string>();

        public void Initialize(IPluginContext context)
        {
            try
            {
                string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json";
                string content = File.ReadAllText(configPath);
                JObject json = JObject.Parse(content);
                foreach (string word in json["welcome"])
                {
                    welcomeWords.Add(word);
                }
            }
            catch (Exception) { }

            context.Bot.OnPart += Bot_OnPart;
            context.Bot.OnChannelChanged += Bot_OnChannelChanged;
        }

        void Bot_OnChannelChanged(object sender, EventArgs e)
        {
            welcomedUsers = new List<string>();
        }

        void Bot_OnPart(object sender, EventArgs e)
        {
            JoinPartEventArgs realEvent = (JoinPartEventArgs)e;
            if (welcomedUsers.Contains(realEvent.Username)) welcomedUsers.Remove(realEvent.Username);
        }

        public void PerformCommand(IPluginContext context)
        {
            if (welcomeWords.Count == 0) return;
            if (welcomedUsers.Contains(context.Username)) return;
            
            string lowerText = context.Text.ToLower();

            if (lowerText.StartsWith("!")) return;

            foreach (string welcomeWord in welcomeWords)
            {
                string lowerWelcome = welcomeWord.ToLower();
                if (lowerText == lowerWelcome || lowerText.StartsWith(lowerWelcome + " ") || lowerText.Contains(" " + lowerWelcome + " ") || lowerText.EndsWith(" " + lowerWelcome))
                {
                    context.Bot.SendChannelMessage("Bienvenue @" + context.Username + "!");
                    welcomedUsers.Add(context.Username);
                }
            }
        }
    }
}
