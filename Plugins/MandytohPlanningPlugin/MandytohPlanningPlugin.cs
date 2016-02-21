/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */
 
using Dagobar.Core.ChatProcessing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MandytohPlanningPlugin
{
    public class MandytohPlanningPlugin : IPlugin
    {
        public string Name { get { return "Mandytoh Planning"; } set { } }

        public Dictionary<string, string> planning = new Dictionary<string, string>(); // Dictionnary to store the config

        public void Initialize(IPluginContext context)
        {
            try // Try to load the config
            {
                string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json"; // Define the config file 's path
                string content = File.ReadAllText(configPath, System.Text.Encoding.UTF8); // Get the content of the config file

                JsonTextReader reader = new JsonTextReader(new StringReader(content)); // Create the JSonTextReader

                /*
                 * Parse the Json here
                 * */
                string lastName = String.Empty; 
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        lastName = (string) reader.Value;
                    }
                    else if (reader.TokenType == JsonToken.String)
                    {
                        planning.Add(lastName, (string)reader.Value);
                        lastName = "";
                    }
                }
            }
            catch (Exception) { } // Catch any error and don't notify it
        }

        public void PerformCommand(IPluginContext context)
        {
            if (planning.Count == 0) return; // If config is not loaded, return

            if (context.Command.ToLower() == "!planning") // If the command is planning
            {
                string key = "None"; // Set a default key
                string pre = "Aujourd'hui"; // Set a default pre

                if (context.Arguments.Length > 0) // If there is any arguments
                {
                    pre = context.Arguments[0]; // Define the pre message
                    string preLower = pre.ToLower(); // Get the pre message to lower case

                    /*
                     * Translate to English or set the key to Error
                     * */
                    if (preLower == "lundi") key = "Monday";
                    else if (preLower == "mardi") key = "Tuesday";
                    else if (preLower == "mercredi") key = "Wednesday";
                    else if (preLower == "jeudi") key = "Thursday";
                    else if (preLower == "vendredi") key = "Friday";
                    else if (preLower == "samedi") key = "Saturday";
                    else if (preLower == "dimanche") key = "Sunday";
                    else key = "Error";
                }
                else if (planning.ContainsKey(System.DateTime.Now.DayOfWeek.ToString())) // Else if the planning contains the current day
                {
                    key = System.DateTime.Now.DayOfWeek.ToString(); // Define the key as the current day
                }

                if (!planning.ContainsKey(key)) key = "None"; // If the key isn't valid, set it to None
                if (pre.Length > 0) // If pre is not null
                {
                    /*
                     * Set the first char to uppercase
                     * */
                    string first = pre[0].ToString().ToUpper();
                    pre = pre.Remove(0, 1);
                    pre = first + pre;
                }
                if (key == "Error") pre = String.Empty; // If the key is error, no pre-message

                context.Bot.SendChannelMessage(pre + planning[key]); // Send the message

            }
        }
    }
}