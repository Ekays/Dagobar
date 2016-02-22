using Dagobar.Core.ChatProcessing;
using Newtonsoft.Json;
using System;
/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WhoisPlugin
{
    public class WhoisPlugin : IPlugin
    {
        public string Name { get { return "WhoIs"; } set { } }

        private string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json"; // The path of the config file
        public Dictionary<string, string> whoisUsers = new Dictionary<string, string>();

        public void Initialize(IPluginContext context)
        {
            try // Try to load the config
            {
                string content = File.ReadAllText(configPath, System.Text.Encoding.UTF8); // Read the content of the config file
                whoisUsers = JsonConvert.DeserializeObject<Dictionary<string, string>>(content); // Deserialize the config
            }
            catch (Exception) { }
        }

        // Save: Save the config file
        private void Save()
        {
            if (File.Exists(configPath)) File.Delete(configPath); // Delete the existing file
            string content = JsonConvert.SerializeObject(whoisUsers); // Serialize the config
            File.WriteAllText(configPath, content, System.Text.Encoding.UTF8); // Write the json to the config file
        }

        public void PerformCommand(IPluginContext context)
        {
            if (context.Command.ToLower() == "!whois")
            {
                if (context.Arguments.Length > 0)
                {
                    PrintWhois(context.Arguments[0]);
                }
                else
                {
                    PrintWhois(context.Bot.CurrentChannel);
                }
            }
        }

        public void PrintWhois(string username)
        {

        }
    } 
}
