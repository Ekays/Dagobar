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
using System.Threading;

namespace MessagesPlugin
{
    public class MessagesPlugin : IPlugin
    {
        public string Name { get { return "Messages"; } set { } }

        private string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\config.json"; // The path of the config file
        public List<Command> commands = new List<Command>(); // The list of loaded commands

        public void Initialize(IPluginContext context)
        {
            try // Try to load the config
            {
                string content = File.ReadAllText(configPath, System.Text.Encoding.UTF8); // Read the content of the config file
                commands = JsonConvert.DeserializeObject<List<Command>>(content); // Deserialize the config

                foreach (Command c in commands) // Foreach command loaded
                {
                    new Thread(TimedCommandThread).Start(new object[] {
                        context,
                        c.Name
                    }); // Create its interval thread
                }
            }
            catch (Exception) { }
        }

        // Save: Save the config file
        private void Save()
        {
            if (File.Exists(configPath)) File.Delete(configPath); // Delete the existing file
            string content = JsonConvert.SerializeObject(commands); // Serialize the config
            File.WriteAllText(configPath, content, System.Text.Encoding.UTF8); // Write the json to the config file
        }

        public void PerformCommand(IPluginContext context)
        {
            string command = context.Command.ToLower(); // Get the lowered command 

            if (!command.StartsWith("!")) return; // If it's not a command return

            if (command == "!apprendre") // If command is apprendre
            {
                if (!Dagobar.Helpers.Array.Contains(context.UserInformations, "mod=1") && context.Username != context.Bot.CurrentChannel) // Must be op for this command
                {
                    context.Bot.SendChannelMessage("Cette commande requiert d'être opérateur pour être utilisée !");
                    return;
                }

                if (context.Arguments.Length < 2) // Command used wrong
                {
                    context.Bot.SendChannelMessage("Usage: !apprendre <nom de la commande> <message>"); // Send a tiny message
                    return;
                }

                string commandName = context.Arguments[0]; // Get the command name

                foreach (Command cmd in commands) // Foreach command
                {
                    if (cmd.Name.ToLower() == commandName.ToLower()) // If the command's name is the same as the desired name
                    {
                        context.Bot.SendChannelMessage("Une commande avec ce nom existe déjà !"); // Print a message
                        return; // And return
                    }
                }

                string commandText;
                List<string> commandTextList = Dagobar.Helpers.Array.ArrayToList<string>(context.Arguments);
                commandTextList.RemoveAt(0);
                commandText = string.Join(" ", commandTextList); // Get the command text

                Command c = new Command // Create the command
                {
                    Name = commandName,
                    Text = commandText,
                    Interval = 0,
                };

                commands.Add(c); // Add it to the list of commands

                new Thread(TimedCommandThread).Start(new object[] {
                        context,
                        c.Name
                }); // Start the interval thread of the command

                context.Bot.SendChannelMessage("La commande !" + c.Name + " a été ajoutée !"); // Send a tiny message
                Save(); // Save the config to the config file
            }
            else if (command == "!oublier") // Else if command is oublier
            {
                if (!Dagobar.Helpers.Array.Contains(context.UserInformations, "mod=1") && context.Username != context.Bot.CurrentChannel) // Must be op for this command
                {
                    context.Bot.SendChannelMessage("Cette commande requiert d'être opérateur pour être utilisée !");
                    return;
                }

                if (context.Arguments.Length < 1) // Command used wrong
                {
                    context.Bot.SendChannelMessage("Usage: !oublier <nom de la commande>"); // Send a tiny message
                    return;
                }

                for (int i = 0 ; i < commands.Count ; i++) // Foreach command
                {
                    if (commands[i].Name == context.Arguments[0]) // If it is the command we are looking for
                    {
                        context.Bot.SendChannelMessage("La commande !" + commands[i].Name + " a été supprimée !"); // Send a tiny message
                        commands.RemoveAt(i); // Remove the command from the list
                        Save(); // Save the config
                        return; // Return
                    }
                }

                // If we haven't found a command
                context.Bot.SendChannelMessage("Impossible de trouver la commande !" + context.Arguments[0] + " !"); // Send a tiny message
            }
            else if (command == "!intervalle") // Else if command is intervalle
            {
                if (!Dagobar.Helpers.Array.Contains(context.UserInformations, "mod=1") && context.Username != context.Bot.CurrentChannel) // Must be op for this command
                {
                    context.Bot.SendChannelMessage("Cette commande requiert d'être opérateur pour être utilisée !");
                    return;
                }

                if (context.Arguments.Length < 2) // Wrong usage of the command
                {
                    context.Bot.SendChannelMessage("Usage: !intervalle <nom de la commande> <intervalle en minutes>"); // Send a tiny message
                    return;
                }

                int newInterval; // Int to store the new interval
                bool validInput = int.TryParse(context.Arguments[1], out newInterval); // Cast string to int

                if (!validInput) // Wrong usage of the command (int while excepting string)
                {
                    context.Bot.SendChannelMessage("Usage: !intervalle <nom de la commande> <intervalle en minutes>"); // Send a tiny message
                    return;
                }

                int found = -1; // Variable to store the id of the found Command

                for (int i = 0; i < commands.Count; i++) // Foreach command
                {
                    if (commands[i].Name == context.Arguments[0]) // If it is the command we are looking for
                    {
                        found = i; // Store his id
                        commands[i].Interval = newInterval; // Change it's interval
                        break;
                    }
                }

                if (found == -1) // If no command found
                {
                    context.Bot.SendChannelMessage("Impossible de trouver la commande !" + context.Arguments[0] + " !"); // Send a tiny message
                    return;
                }

                Save(); // Save the config to the config file

                // Print a success message
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
            else // Else
            {
                foreach (Command c in commands) // Foreach existing command
                {
                    if (command == "!" + c.Name.ToLower()) // Is it the command we are looking for ?
                    {
                        context.Bot.SendChannelMessage(c.Text); // If yes ,send the message
                        break;
                    }
                }
            }
        }

        //TimedCommandThread : Thread for printing the timed message
        public void TimedCommandThread(object o)
        {
            // Get the arguments
            object[] arguments = (object[])o;
            IPluginContext context = (IPluginContext)arguments[0];
            string name = (string) arguments[1];

            while (context.Bot.IsRunning) // While the bot is running
            {
                Command command = new Command { Name = "FCKOFF2000" }; // Create an empty command with a weird name
                foreach (Command c in commands) // Foreach name
                {
                    if (c.Name == name) // Is it the name we are looking for ?
                    {
                        command = c; // Store the command
                        break;
                    }
                }

                if (command.Name == "FCKOFF2000") // If no command found, command has been removed, then stop thread
                    break;

                if (command.Interval == 0) // If interval is 0, sleep and continue
                {
                    Thread.Sleep(1000);
                }
                else 
                {
                    Thread.Sleep(command.Interval * 60000); // Else wait for the desired time
                    if (!commands.Contains(command)) return; // If command has been removed stop thread
                    context.Bot.SendChannelMessage(command.Text); // Then print the message
                }
            }
        }
    }
}
