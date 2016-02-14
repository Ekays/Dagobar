using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Dagobar.Network
{
    struct ConnectionInformations {
        public static ConnectionInformations Twitch = new ConnectionInformations() { Address = "irc.twitch.tv", Port = 6667};

        public string Address;
        public int Port;
    }

    struct AuthentificationInformations
    {
        public string Nick, Password;
    }

    class IRC
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        private string currentChannel = "none";
        public string CurrentChannel
        {
            get
            {
                return currentChannel;
            }
        }

        public IRC()
        {
            client = new TcpClient();
        }

        public IRC(string newChannel)
        {
            currentChannel = newChannel;
            client = new TcpClient();
        }

        public bool IsConnected
        {
            get
            {
                return client.Connected;
            }
        }

        public bool Connect(ConnectionInformations ci)
        {
            if (IsConnected)
            {
                client.Close();
                stream.Close();
            }

            try
            {
                client.Connect(ci.Address, ci.Port);
            }
            catch (SocketException)
            {
                return false;
            }

            stream = client.GetStream();
            writer = new StreamWriter(stream, new UTF8Encoding(false));
            reader = new StreamReader(stream, new UTF8Encoding(false));

            Thread t = new Thread(Read);
            t.Start();

            return true;
        }

        public void Close()
        {
            if (!IsConnected) return;

            SendData("PART #" + currentChannel);

            client.Close();
            stream.Close();
        }

        public void Login(AuthentificationInformations ai)
        {
            if (!IsConnected) return;

            SendData(new string[] {
                "PASS " + ai.Password,
                "NICK " + ai.Nick,
                "JOIN #" + currentChannel
            });
        }

        public void ChangeChannel(string newChannel)
        {
            if (!IsConnected) return;

            SendData(new string[] {
                "PART #" + currentChannel,
                "JOIN #" + newChannel
            });
            currentChannel = newChannel;
        }

        public void SendChannelMessage(string message)
        {
            if (!IsConnected) return;
            SendData("PRIVMSG #" + currentChannel + " :" + message);
        }

        private void SendData(string[] data)
        {
            if (!IsConnected) return;

            foreach (String s in data)
            {
                writer.WriteLine(s);
            }

            writer.Flush();
        }

        private void SendData(string data)
        {
            SendData(new string[] { data });
        }

        private void SendData(List<string> data)
        {
            SendData(data.ToArray());
        }

        public event EventHandler OnReceived;
        private void Read()
        {
            while (IsConnected)
            {
                string dataLine = reader.ReadLine();
                if (dataLine == null)
                {
                    Thread.Sleep(100);
                    continue;
                }

                EventHandler localEvent = OnReceived;
                if (localEvent != null) localEvent(this, new ReceiveEventArgs(dataLine));
            }
        }
    }
}
