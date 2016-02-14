using System;

namespace Dagobar.Core
{
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

        public string Username { get { return username; } }
        public string Text { get { return text; } }

        public ReceiveMessageEventArgs(string u, string t)
        {
            username = u;
            text = t;
        }
    }
}
