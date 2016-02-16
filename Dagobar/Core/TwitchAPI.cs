/*
 *          Dagobar is a Twitch bot with an UI which tends to be simple
 *          Copyright (C) 2016 r00tKiller
 *          This project is under license GNU GENERAL PUBLIC LICENSE Version 3
 *          You can found a copy of this license at http://www.gnu.org/licenses/gpl-3.0.fr.html
 *          
 * */

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Dagobar.Core
{
    public class TwitchAPI
    {
        #region Singleton
        // This is a singleton, because at any time, we only need one instance of this class.
        private static TwitchAPI instance = null;
        public static TwitchAPI I
        {
            get
            {
                if (instance == null) instance = new TwitchAPI(); // If the instance isn't initialized, create it!
                return instance;
            }
        }
        #endregion

        private String currentChannel; // Current channel we are fetching values for

        private Dictionary<string, JObject> jsons = new Dictionary<string, JObject>(); // Dictionary of fetched json values
        public Dictionary<string, JObject> Values
        {
            get
            {
                return jsons;
            }
            set
            {

            }
        } // Property for the dictionary
         
        // Run: Starts the main Thread
        public void Run()
        {
            new Thread(MainThread).Start(); // Create a new thread a start it
        }

        private DateTime nextCheck = DateTime.Now; // The time when the next fetch will be
        private void MainThread() // Thread: Fetch data every minute
        {
            while (Application.OpenForms.Count > 0) // While Dagobar is running
            {
                if (currentChannel != Core.Bot.I.CurrentChannel) // If channel changed
                {
                    jsons = new Dictionary<string, JObject>(); // Reset values
                    currentChannel = Core.Bot.I.CurrentChannel; // Set the new channel
                    nextCheck = DateTime.Now; // Fetch new datas now!
                }

                if (DateTime.Now < nextCheck) // If the next fetch time is not passed
                { 
                    Thread.Sleep(1000); // Wait a second 
                    continue; // And go on top of loop
                }

                UpdateInformations(); // Else , need an update
                nextCheck = DateTime.Now.Add(TimeSpan.FromMinutes(1)); // Define next fetch time,  T + 1 minute
            }
        }

        public event EventHandler OnFetched;

        // UpdateInformations: Fetch values from Twitch API
        private void UpdateInformations()
        {
            //@TODO: Make this dynamic
            jsons = new Dictionary<string, JObject>();

            WebClient c = new WebClient(); // WebClient to fetch string
            string content = String.Empty;
            while (content == String.Empty) // While the content isn't fetched
            {
                try
                {
                    content = c.DownloadString(String.Format("http://tmi.twitch.tv/group/user/{0}/chatters", currentChannel)); // Try to fetch values
                } 
                catch (WebException) { continue;  } // If it fails, retry
            }

            JObject jsonChatters = JObject.Parse(content); // Parse the json
            jsons.Add("chatters", jsonChatters); // And store it in the Dictionary


            // Throw an Fetched event
            EventHandler localEvent = OnFetched;
            if (localEvent != null) localEvent(this, EventArgs.Empty);
        }
    }
}
