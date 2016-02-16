/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Dagobar.Core.ChatProcessing
{
    class ChatProcessor
    {
        List<IPlugin> plugins = new List<IPlugin>(); // List of loaded plugins

        public ChatProcessor()
        {
            string pluginFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Plugins"; // Get the Plugins folder
            if (!Directory.Exists(pluginFolderPath)) Directory.CreateDirectory(pluginFolderPath); // If the Plugins folder dont exists, create it
            string[] dllFileNames = Directory.GetFiles(pluginFolderPath, "*.dll", SearchOption.AllDirectories); // Get all the dll files inside the Plugins folder next to the executable

            List<Assembly> assemblies = new List<Assembly>(); // List of assemblies of these dlls
            foreach (string dllFileName in dllFileNames) // Foreach dll found
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dllFileName); // Get his assemlby name
                Assembly a = Assembly.Load(an); // Load this assembly
                assemblies.Add(a); // Add it to the list
            }

            Type pluginType = typeof(IPlugin); // Get the type of the Plugin Interface
            List<Type> pluginTypes = new List<Type>(); // List of the types of the plugins

            foreach (Assembly assembly in assemblies) // Foreach assembly we found
            {
                if (assembly == null) continue; // If the assembly is null, skip
                Type[] assemblyTypes = assembly.GetTypes(); // Get all the types in this Assembly
                foreach (Type type in assemblyTypes) // Foreach type we found
                {
                    if (type.IsInterface || type.IsAbstract) continue; // If the type is an interface or is abtract, skip it
                    if (type.GetInterface(pluginType.FullName) != null) pluginTypes.Add(type); // If the type implements the Plugin Interface, store it
                }
            }

            foreach (Type type in pluginTypes) // Foreach plugin
            {
                IPlugin plugin = (IPlugin)Activator.CreateInstance(type); // Inititialize it
                plugins.Add(plugin); // Add it to the list of Plugins
            }

            Core.Bot.I.OnMessageReceived += bot_OnMessageReceived; // Bind event
        }

        // LoadedPluginNames: Return all the names of loaded plugins
        public List<string> LoadedPluginNames()
        {
            List<string> list = new List<string>(); // Create a new list
            foreach (IPlugin plugin in plugins) // Foreach plugin
            {
                list.Add(plugin.Name); // Add its name to the list
            }
            return list; // Return the list
        }

        void bot_OnMessageReceived(object sender, EventArgs e)
        {
            Core.ReceiveMessageEventArgs receivedMessage = (Core.ReceiveMessageEventArgs)e; // Cast the EventArgs as its real type

            string[] textSplit = receivedMessage.Text.Split(' '); // Split the message's text with space
            string command = textSplit[0]; // Command is the first part of the message

            /*
             * Arguments are the rest of the message
             * */
            List<string> argumentsList = Helpers.Array.ArrayToList<string>(textSplit);
            argumentsList.RemoveAt(0);
            string[] arguments = argumentsList.ToArray();

            foreach (IPlugin plugin in plugins) // Foreach loaded plugin
            {
                plugin.PerformCommand(new IPluginContext // Call the plugin
                {
                    Arguments = arguments,
                    Username = receivedMessage.Username,
                    Command = command,
                    Text = receivedMessage.Text,
                    Bot = Core.Bot.I,
                    TwitchAPI = Core.TwitchAPI.I
                });
            }
        }

        
    }
}
