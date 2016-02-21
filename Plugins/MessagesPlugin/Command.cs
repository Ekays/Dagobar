/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

namespace MessagesPlugin
{
    public class Command
    {
        public string Name      { get; set; }
        public string Text      { get; set; }
        public int Interval     { get; set; }
    }
}
