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
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Dagobar.Core
{
    /*
     * Storing structures for connecting and authentification 
     * */
    struct ConnectionInformations {
        public static ConnectionInformations Twitch = new ConnectionInformations() { Address = "irc.twitch.tv", Port = 6667}; // Static Twitch informations

        public string Address;
        public int Port;
    }
    struct AuthentificationInformations
    {
        public static AuthentificationInformations Anonymous = new AuthentificationInformations() { Nick = "Anonymous", Password = "" }; // Static Anonymous informations ( uselss , but to prevent unused variables in IDE )
        public string Nick, Password;
    }

    class IRC
    {
        private TcpClient client; // The client used for connection
        private NetworkStream stream; // The stream handler
        private StreamReader reader; // The reader for the stream
        private StreamWriter writer; // The writer for the stream

        /*
         * The current channel and its property
         * */
        private string currentChannel = "none";
        public string CurrentChannel
        {
            get
            {
                return currentChannel;
            }
        }

        // ctor
        public IRC()
        {
            client = new TcpClient(); // Initilalize the TcpClient
        }

        // ctor
        public IRC(string newChannel)
        {
            currentChannel = newChannel; // Define the current channel
            client = new TcpClient(); // Initilalize the TcpClient
        }

        // Is Connected property tells if the TcpClient is currently connected to a server
        public bool IsConnected
        {
            get
            {
                return client.Connected;
            }
        }

        // Connect: try to connect to an IRC server
        public bool Connect(ConnectionInformations ci)
        {
            // If the client is already connected,
            if (IsConnected)
            {
                // just close everything
                client.Close();
                stream.Close();
            }

            // ReInitialize the client and try to connect
            try
            {
                client = new TcpClient();
                client.Connect(ci.Address, ci.Port);
            }
            catch (SocketException)
            {
                // If here, the connection went wrong, just return
                return false;
            }

            // Prepare the stream, reader and writer
            stream = client.GetStream();
            writer = new StreamWriter(stream, new UTF8Encoding(false));
            reader = new StreamReader(stream, new UTF8Encoding(false));

            // Start the receiving thread
            Thread t = new Thread(Read);
            t.Start();

            // Return
            return true;
        }

        // Close: Close the current connection
        public void Close()
        {
            // If the client is already closed, return
            if (!IsConnected) return;

            // Leave the current channel
            SendData("PART #" + currentChannel);

            // Close everything
            client.Close();
            stream.Close();
        }

        // Login: Log into the IRC server
        public void Login(AuthentificationInformations ai)
        {
            // If the client isn't connected, return
            if (!IsConnected) return;

            // Send the login informations and join the wanted channel
            SendData(new string[] {
                "PASS " + ai.Password,
                "NICK " + ai.Nick,
                "JOIN #" + currentChannel
            });
        }

        // ChangeChannel: Change the current channel;
        public void ChangeChannel(string newChannel)
        {
            // If the client isn't connected, return
            if (!IsConnected) return;

            SendData(new string[] {
                "PART #" + currentChannel,
                "JOIN #" + newChannel
            }); // Send a Part and a Join command to the IRC server
            currentChannel = newChannel; // Redefine the currentChannel variable
        }

        // SendChannelMessage: Send a message in the current channel
        public void SendChannelMessage(string message)
        {
            // If the client isn't connected, return
            if (!IsConnected) return;
            SendData("PRIVMSG #" + currentChannel + " :" + message); // Use the SendData function to send Raw Data ...
        }

        // SendData: Send raw message to the server
        public void SendData(string[] data)
        {
            // If the client isn't connected, return
            if (!IsConnected) return;

            // Foreach line the array
            foreach (String s in data)
            {
                writer.WriteLine(s); // Write it in the stream
            }

            writer.Flush(); // And then send them all
        }

        // SendData: Alias for SendData
        public void SendData(string data)
        {
            SendData(new string[] { data });
        }

        // SendData: Alias for SendData
        public void SendData(List<string> data)
        {
            SendData(data.ToArray());
        }

        // EventHandler for Raw data
        public event EventHandler OnReceived;

        // Read: Reading from the stream, usualy used for Threading
        private void Read()
        {
            // While we are connected ( we don't want to read when not connected,  right ? )
            while (IsConnected)
            {
                string dataLine = null; // Declare the dataLine variable who will receive the data
                try
                {
                    dataLine = reader.ReadLine(); // Try to read a line in the stream
                }
                catch (IOException) { continue; } // If we go here, a reading error happend

                if (dataLine == null) // If the dataLine is empty
                {
                    Thread.Sleep(100); // Wait a bit and go back to the beginning of the loop
                    continue;
                }

                string[] dataSplit = dataLine.Split(' '); // Split the data line by a space
                if (dataSplit[0] == "PING") // If the message is a PING 
                {
                    SendData("PONG " + dataLine[1]); // Send an PONG answer
                }
                else // else
                {
                    // Throw an Receive Data event
                    EventHandler localEvent = OnReceived;
                    if (localEvent != null) localEvent(this, new ReceiveDataEventArgs(dataLine));
                }
            }
        }
    }
}
