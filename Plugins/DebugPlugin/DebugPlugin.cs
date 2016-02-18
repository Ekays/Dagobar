using Dagobar.Core.ChatProcessing;
using System;

namespace DebugPlugin
{
    public class DebugPlugin : IPlugin
    {

        public string Name { get { return "Debug"; } set { } }

        public void Initialize(IPluginContext context)
        {
            context.Bot.SendChannelMessage("Debug plugin launched !");
        }

        public void PerformCommand(IPluginContext context)
        {
            context.Bot.SendChannelMessage("Debug plugin processed !");
        }
    }
}
