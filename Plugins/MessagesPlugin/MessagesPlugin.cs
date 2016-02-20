using Dagobar.Core.ChatProcessing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace MessagesPlugin
{
    public class MessagesPlugin : IPlugin
    {
        public string Name { get { return "Messages"; } set { } }

        private string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json";
        public List<Command> commands = new List<Command>();

        public void Initialize(IPluginContext context)
        {
            try
            {
                string content = File.ReadAllText(configPath, System.Text.Encoding.UTF8);
                commands = JsonConvert.DeserializeObject<List<Command>>(content);

                foreach (Command c in commands)
                {
                    new Thread(TimedCommandThread).Start(new object[] {
                        context,
                        c.Name
                    });
                }
            }
            catch (Exception) { }

            Save();
        }

        private void Save()
        {
            if (File.Exists(configPath)) File.Delete(configPath);
            string content = JsonConvert.SerializeObject(commands);
            File.WriteAllText(configPath, content, System.Text.Encoding.UTF8);
        }

        public void PerformCommand(IPluginContext context)
        {
            string command = context.Command.ToLower();

            if (!command.StartsWith("!")) return;

            if (command == "!apprendre")
            {
                if (!Dagobar.Helpers.Array.Contains(context.UserInformations, "mod=1") && context.Username != context.Bot.CurrentChannel)
                {
                    context.Bot.SendChannelMessage("Cette commande requiert d'être administrateur pour être utilisée !");
                    return;
                }

                if (context.Arguments.Length < 2)
                {
                    context.Bot.SendChannelMessage("Usage: !apprendre <nom de la commande> <message>");
                    return;
                }

                string commandName = context.Arguments[0];
                string commandText;
                List<string> commandTextList = Dagobar.Helpers.Array.ArrayToList<string>(context.Arguments);
                commandTextList.RemoveAt(0);
                commandText = string.Join(" ", commandTextList);

                Command c = new Command
                {
                    Name = commandName,
                    Text = commandText,
                    Interval = 0,
                };

                commands.Add(c);

                new Thread(TimedCommandThread).Start(new object[] {
                        context,
                        c.Name
                });

                context.Bot.SendChannelMessage("La commande !" + c.Name + " a été ajoutée !");
                Save();
            }
            else if (command == "!oublier")
            {
                if (!Dagobar.Helpers.Array.Contains(context.UserInformations, "mod=1") && context.Username != context.Bot.CurrentChannel)
                {
                    context.Bot.SendChannelMessage("Cette commande requiert d'être administrateur pour être utilisée !");
                    return;
                }

                if (context.Arguments.Length < 1)
                {
                    context.Bot.SendChannelMessage("Usage: !oublier <nom de la commande>");
                    return;
                }

                Command toRemove = new Command();
                bool found = false;
                foreach (Command c in commands)
                {
                    if (c.Name == context.Arguments[0])
                    {
                        found = true;
                        toRemove = c;
                        break;
                    }
                }

                if (found)
                {
                    commands.Remove(toRemove);
                    context.Bot.SendChannelMessage("La commande !" + toRemove.Name + " a été supprimée !");
                    Save();
                }
                else
                {
                    context.Bot.SendChannelMessage("Impossible de trouver la commande !" + context.Arguments[0] + " !");
                }
            }
            else if (command == "!intervalle")
            {
                if (!Dagobar.Helpers.Array.Contains(context.UserInformations, "mod=1") && context.Username != context.Bot.CurrentChannel)
                {
                    context.Bot.SendChannelMessage("Cette commande requiert d'être administrateur pour être utilisée !");
                    return;
                }

                if (context.Arguments.Length < 2)
                {
                    context.Bot.SendChannelMessage("Usage: !intervalle <nom de la commande> <intervalle en minutes>");
                    return;
                }

                int newInterval;
                bool validInput = int.TryParse(context.Arguments[1], out newInterval);

                if (!validInput)
                {
                    context.Bot.SendChannelMessage("Usage: !intervalle <nom de la commande> <intervalle en minutes>");
                    return;
                }

                int found = -1;

                for (int i = 0; i < commands.Count; i++)
                {
                    if (commands[i].Name == context.Arguments[0])
                    {
                        found = i;
                        commands[i].Interval = newInterval;
                        break;
                    }
                }

                if (found == -1)
                {
                    context.Bot.SendChannelMessage("Impossible de trouver la commande !" + context.Arguments[0] + " !");
                    return;
                }

                Save();

                if (commands[found].Interval == 1)
                {
                    context.Bot.SendChannelMessage("L'intervalle d'affichage de la commande !" + commands[found].Name + " est désormais de " + commands[found].Interval + " minute!");
                }
                else if (commands[found].Interval == 0)
                {
                    context.Bot.SendChannelMessage("La commande !" + commands[found].Name + " ne s'affichera plus automatiquement !");
                }
                else
                {
                    context.Bot.SendChannelMessage("L'intervalle d'affichage de la commande !" + commands[found].Name + " est désormais de " + commands[found].Interval + " minutes!");
                }
            }
            else
            {
                foreach (Command c in commands)
                {
                    if (command == "!" + c.Name.ToLower())
                    {
                        context.Bot.SendChannelMessage(c.Text);
                        break;
                    }
                }
            }
        }

        public void TimedCommandThread(object o)
        {
            object[] arguments = (object[])o;
            IPluginContext context = (IPluginContext)arguments[0];
            string name = (string) arguments[1];

            while (context.Bot.IsRunning)
            {
                Command command = new Command { Name = "FCKOFF2000" };
                foreach (Command c in commands)
                {
                    if (c.Name == name)
                    {
                        command = c;
                        break;
                    }
                }

                if (command.Name == "FCKOFF2000")
                {
                    break;
                }

                Thread.Sleep(command.Interval); // Change to minuts after debug
                context.Bot.SendChannelMessage(command.Text);

            }
        }
    }
}
