using System;

namespace Dagobar.Network
{
    class ReceiveEventArgs : EventArgs
    {
        private string d = String.Empty;
        public string Data
        {
            get
            {
                return d;
            }
        }

        public ReceiveEventArgs(string data)
        {
            d = data;
        }
    }
}
