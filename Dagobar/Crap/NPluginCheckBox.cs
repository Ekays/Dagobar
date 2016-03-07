using Nevron.Nov.UI;

namespace Dagobar.Crap
{
    class NPluginCheckBox
    {
        private NCheckBox checkBox;
        private string PluginName;

        public NPluginCheckBox(string pluginName)
        {
            PluginName = pluginName;
            checkBox = new NCheckBox(PluginName, true);
            checkBox.CheckedChanged += NPluginCheckBox_CheckedChanged;

            Core.Bot.I.ChatProcessor.ActivePlugin(PluginName);
        }

        void NPluginCheckBox_CheckedChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            if ((bool)arg.NewValue)
                Core.Bot.I.ChatProcessor.ActivePlugin(PluginName);
            else
                Core.Bot.I.ChatProcessor.DesactivePlugin(PluginName);
        }

        public NCheckBox GetCheckBox()
        {
            return checkBox;
        }
    }
}
