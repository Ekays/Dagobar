/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Dagobar.Core.ChatProcessing;
using System;

namespace HelloPlugin
{
    public class HelloPlugin_Main : IPlugin
    {
        public string Name { get { return "Plugin Hello"; } set { Name = value; } }
        public void PerformCommand(IPluginContext context)
        {
            if (context.Text.Contains("bonjour"))
            {
                context.Bot.SendChannelMessage("Salut " + context.Username);
            }
        } 
    }
}
