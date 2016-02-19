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

        public Dictionary<string, string> planning = new Dictionary<string, string>();

        public void Initialize(IPluginContext context)
        {
            try
            {
                string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json";
                string content = File.ReadAllText(configPath, System.Text.Encoding.UTF8);

                JsonTextReader reader = new JsonTextReader(new StringReader(content));

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
            catch (Exception) { }
        }

        public void PerformCommand(IPluginContext context)
        {
            if (planning.Count == 0) return;

            if (context.Command.ToLower() == "!planning")
            {
                string key = "None";
                string pre = "Aujourd'hui";

                if (context.Arguments.Length > 0)
                {
                    pre = context.Arguments[0];
                    string preLower = pre.ToLower();

                    if (preLower == "lundi") key = "Monday";
                    else if (preLower == "mardi") key = "Tuesday";
                    else if (preLower == "mercredi") key = "Wednesday";
                    else if (preLower == "jeudi") key = "Thursday";
                    else if (preLower == "vendredi") key = "Friday";
                    else if (preLower == "samedi") key = "Saturday";
                    else if (preLower == "dimanche") key = "Sunday";
                    else key = "Error";
                }
                else if (planning.ContainsKey(System.DateTime.Now.DayOfWeek.ToString()))
                {
                    key = System.DateTime.Now.DayOfWeek.ToString();
                }

                if (!planning.ContainsKey(key)) key = "None";
                if (pre.Length > 0)
                {
                    string first = pre[0].ToString().ToUpper();
                    pre = pre.Remove(0, 1);
                    pre = first + pre;
                }
                if (key == "Error") pre = String.Empty;

                context.Bot.SendChannelMessage(pre + planning[key]);

            }
        }
    }
}