/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System;

namespace Dagobar.Core.ChatProcessing
{
    /*
     * A struct to send data to the plugins
     * */
    public struct IPluginContext
    {
        public Bot Bot { get; set; }
        public string Username { get; set; }
        public string Command { get; set; }
        public string[] Arguments { get; set; }
        public string Text { get; set; }
    }
}
