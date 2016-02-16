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
    public interface IPlugin
    {
        string Name { get; set; }
        void PerformCommand(IPluginContext context);
    }
}
