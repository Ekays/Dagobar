#pragma warning disable 0162

using Dagobar.Core.ChatProcessing;
using System;


namespace DebugPlugin
{
    public class DebugPlugin : IPlugin
    {
        private const bool DebugMode = false;

        public string Name { get { return "Debug"; } set { } }

        public void Initialize(IPluginContext context)
        {
            if (DebugMode) context.Bot.SendChannelMessage("Debug plugin launched !");
        }

        public void PerformCommand(IPluginContext context)
        {
            if (DebugMode) context.Bot.SendChannelMessage("Debug plugin processed !");
        }
    }
}
