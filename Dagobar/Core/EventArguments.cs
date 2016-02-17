/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using System;

namespace Dagobar.Core
{
    /*
     * Those are just storing class for when i throw events
     * */

    class ReceiveDataEventArgs : EventArgs
    {
        private string d = String.Empty;
        public string Data
        {
            get
            {
                return d;
            }
        }

        public ReceiveDataEventArgs(string data)
        {
            d = data;
        }
    }

    class ReceiveMessageEventArgs : EventArgs
    {
        private string username = String.Empty, text = String.Empty;
        private string[] informations;

        public string Username { get { return username; } }
        public string Text { get { return text; } }
        public string[] Informations { get { return informations; } }

        public ReceiveMessageEventArgs(string u, string t, string[] i)
        {
            username = u;
            text = t;
            informations = i;
        }
    }

    class JoinNPartEventArgs : EventArgs
    {
        private string username = String.Empty, channel = String.Empty;

        public string Username { get { return username; } }
        public string Channel { get { return channel; } }

        public JoinNPartEventArgs(string u, string c)
        {
            username = u;
            channel = c;
        }
    }
}
