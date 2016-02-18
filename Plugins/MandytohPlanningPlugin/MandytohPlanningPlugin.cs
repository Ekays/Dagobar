using Dagobar.Core.ChatProcessing;
using System;
using System.Collections.Generic;

namespace MandytohPlanningPlugin
{
    public class MandytohPlanningPlugin : IPlugin
    {
        public string Name { get { return "Mandytoh Planning"; } set { } }

        public Dictionary<string, string> planning = new Dictionary<string, string>();

        public void Initialize(IPluginContext context)
        {
            planning.Add("Monday", ", c'est Game Analyse ! On analyse un jeu à la manière d'un game designer.");
            planning.Add("Wednesday", ", c'est Long Series ! On découvre un même jeu pendant plusieurs épisodes.");
            planning.Add("Friday", ", c'est Plagia Game Dev ! On essaye de reproduire le concept d'un jeu en 3 heures.");
            planning.Add("Sunday", ", c'est Libre Antenne ! On parle avec vous");
            planning.Add("None", ", rien de prévu, on fait comme on veut !");
            planning.Add("Error", "Je ne reconnais pas ce jour !");
        }

        public void PerformCommand(IPluginContext context)
        {
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