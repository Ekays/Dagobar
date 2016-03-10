using Dagobar.Crap;
using Nevron.Nov.Graphics;
using Nevron.Nov.Presentation;
using Nevron.Nov.UI;
using Nevron.Nov.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dagobar.Forms
{

    class MainForm : Form
    {

        #region Graphics

        private const int windowCoeff = 60;

        private Control controlMain;
        private NStackPanel panelRibbon, panelMain, panelTabChat, panelChat, panelUsers, panelSend, panelRibbonInformations;
        private NTextBox textBoxSend;
        private NButton buttonSend;
        private NLabel labelChannel, labelRibbonChannel, labelRibbonViewers, labelRibbonVersion;
        private NListBox listBoxUsers, listBoxChat, listBoxPlugins;
        private NRibbon ribbon;
        private NRibbonTabPage ribbonTagPageMain;
        private NRibbonGroup ribbonGroupInformations, ribbonGroupPlugins, ribbonGroupActions;
        private NRibbonButton ribbonButtonConfiguration, ribbonButtonChannel, ribbonButtonQuit;

        private void InitializeComponent()
        {

            /*
            *   Window setup
            * */
            this.Text = "Dagobar";
            this.Size = new System.Drawing.Size(16 * windowCoeff, 9 * windowCoeff);
            this.MinimumSize = new System.Drawing.Size(this.Width / 2, this.Height / 2);

            #region "Controls Setup & Layout Setup"
            textBoxSend = new NTextBox();
            textBoxSend.Font = new Nevron.Nov.Graphics.NFont("Lucidia Console", 12);
            textBoxSend.VerticalPlacement = Nevron.Nov.Layout.ENVerticalPlacement.Center;
            textBoxSend.Margins = new Nevron.Nov.Graphics.NMargins(1, 3, 0, 3);
            textBoxSend.KeyUp += textBoxSend_KeyUp;

            buttonSend = new NButton("Envoyer");
            buttonSend.PreferredWidth = 100;
            buttonSend.Content.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            buttonSend.Margins = new Nevron.Nov.Graphics.NMargins(3.0);
            buttonSend.Click += buttonSend_Click;

            panelSend = new NStackPanel();
            panelSend.Direction = Nevron.Nov.Layout.ENHVDirection.LeftToRight;
            panelSend.FillMode = Nevron.Nov.Layout.ENStackFillMode.First;
            panelSend.Add(textBoxSend);
            panelSend.Add(buttonSend);

            listBoxChat = new NListBox();
            listBoxChat.Margins = new Nevron.Nov.Graphics.NMargins(1.0);

            panelChat = new NStackPanel();
            panelChat.Direction = Nevron.Nov.Layout.ENHVDirection.TopToBottom;
            panelChat.FillMode = Nevron.Nov.Layout.ENStackFillMode.First;
            panelChat.Add(listBoxChat);
            panelChat.Add(panelSend);

            labelChannel = new NLabel("/--/");
            labelChannel.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            labelChannel.Font = new Nevron.Nov.Graphics.NFont("Lucidia Console", 14);

            listBoxUsers = new NListBox();
            listBoxUsers.Margins = new Nevron.Nov.Graphics.NMargins(1.0);

            panelUsers = new NStackPanel();
            panelUsers.Direction = Nevron.Nov.Layout.ENHVDirection.TopToBottom;
            panelUsers.FillMode = Nevron.Nov.Layout.ENStackFillMode.Last;
            panelUsers.Add(labelChannel);
            panelUsers.Add(listBoxUsers);
            panelUsers.PreferredWidth = 150;

            panelTabChat = new NStackPanel();
            panelTabChat.FillMode = Nevron.Nov.Layout.ENStackFillMode.First;
            panelTabChat.Direction = Nevron.Nov.Layout.ENHVDirection.LeftToRight;
            panelTabChat.Add(panelChat);
            panelTabChat.Add(panelUsers);

            panelMain = new NStackPanel();
            panelMain.Direction = Nevron.Nov.Layout.ENHVDirection.LeftToRight;
            panelMain.FillMode = Nevron.Nov.Layout.ENStackFillMode.Last;
            panelMain.Add(panelTabChat);

            panelRibbonInformations = new NStackPanel();
            panelRibbonInformations.FillMode = Nevron.Nov.Layout.ENStackFillMode.Equal;

            labelRibbonChannel = new NLabel("Chaîne : /--/");
            labelRibbonChannel.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            labelRibbonViewers = new NLabel("Nombre de spectateurs : /--/");
            labelRibbonViewers.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            labelRibbonVersion = new NLabel("Version : " + Properties.Settings.Default.Version);
            labelRibbonVersion.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;

            panelRibbonInformations.Add(labelRibbonChannel);
            panelRibbonInformations.Add(labelRibbonViewers);
            panelRibbonInformations.Add(labelRibbonVersion);

            ribbonGroupInformations = new NRibbonGroup("Informations");
            ribbonGroupInformations.Header.DialogLauncherButton.Visibility = ENVisibility.Hidden;
            ribbonGroupInformations.PreferredHeight = 64;
            ribbonGroupInformations.Items.Add(panelRibbonInformations);

            listBoxPlugins = new NListBox();
            listBoxPlugins.VScrollMode = ENScrollMode.Always;
            listBoxPlugins.PreferredHeight = 64;
            listBoxPlugins.PreferredWidth = 256;

            ribbonGroupPlugins = new NRibbonGroup("Plugins");
            ribbonGroupPlugins.Header.DialogLauncherButton.Visibility = ENVisibility.Hidden;
            ribbonGroupPlugins.Items.Add(listBoxPlugins);

            ribbonButtonConfiguration = new NRibbonButton("Configuration", NImage.FromFile(Application.StartupPath + @"\Resources\settings.png"), NImage.FromFile(Application.StartupPath + @"\Resources\settings.png"));
            ribbonButtonConfiguration.PreferredWidth = 86;
            ribbonButtonConfiguration.Click += ribbonButtonConfiguration_Click;

            ribbonButtonChannel = new NRibbonButton("Changer de chaîne", NImage.FromFile(Application.StartupPath + @"\Resources\move_shit_around.png"), NImage.FromFile(Application.StartupPath + @"\Resources\move_shit_around.png"));
            ribbonButtonChannel.PreferredWidth = 86;
            ribbonButtonChannel.Click += ribbonButtonChannel_Click;

            ribbonButtonQuit = new NRibbonButton("Quitter", NImage.FromFile(Application.StartupPath + @"\Resources\quit.png"), NImage.FromFile(Application.StartupPath + @"\Resources\quit.png"));
            ribbonButtonQuit.PreferredWidth = 86;
            ribbonButtonQuit.Click += ribbonButtonQuit_Click;

            ribbonGroupActions = new NRibbonGroup("Actions");
            ribbonGroupActions.Header.DialogLauncherButton.Visibility = ENVisibility.Hidden;
            ribbonGroupActions.Items.Add(ribbonButtonConfiguration);
            ribbonGroupActions.Items.Add(ribbonButtonChannel);
            ribbonGroupActions.Items.Add(ribbonButtonQuit);

            ribbonTagPageMain = new NRibbonTabPage("Dagobar");
            ribbonTagPageMain.Groups.Add(ribbonGroupInformations);
            ribbonTagPageMain.Groups.Add(ribbonGroupPlugins);
            ribbonTagPageMain.Groups.Add(ribbonGroupActions);

            ribbon = new NRibbon();
            ribbon.Tab.TabPages.Add(ribbonTagPageMain);

            panelRibbon = new NStackPanel();
            panelRibbon.FillMode = Nevron.Nov.Layout.ENStackFillMode.Last;
            panelRibbon.Add(ribbon);
            panelRibbon.Add(panelMain);
            #endregion

            // Create main control
            controlMain = new NNovWidgetHost<NStackPanel>(panelRibbon);
            controlMain.Dock = DockStyle.Fill;
        }

        #endregion

        void ribbonButtonQuit_Click(Nevron.Nov.Dom.NEventArgs arg)
        {
            Application.Exit();
        }

        void ribbonButtonChannel_Click(Nevron.Nov.Dom.NEventArgs arg)
        {
            string newChannel = Microsoft.VisualBasic.Interaction.InputBox("Nom du nouveau channel: ", "Dagobar", Properties.Settings.Default.BotOwner).ToLower(); //@TODO: Make a custom input box
            if (newChannel == String.Empty) return; // Ask for a new channel and check if it is not empty
            Core.Bot.I.ChangeChannel(newChannel); // Set the new channel
            Properties.Settings.Default.BotChannel = newChannel; // Change it in the settings
            Properties.Settings.Default.Save(); // Save the settings
        }

        void ribbonButtonConfiguration_Click(Nevron.Nov.Dom.NEventArgs arg)
        {
            new SetupForm().Show(); // Show the settings form  
            this.Close(); // And close this one
        }

        void textBoxSend_KeyUp(NKeyEventArgs arg)
        {
            if (arg.Key.Code == ENKeyCode.Enter) buttonSend_Click(null);
        }

        void buttonSend_Click(Nevron.Nov.Dom.NEventArgs arg)
        {
            if (textBoxSend.Text != String.Empty)
            {
                Core.Bot.I.SendChannelMessage(textBoxSend.Text);
                listBoxChat.Items.Add(new NListBoxItem(Properties.Settings.Default.BotNickname + ": " + textBoxSend.Text)); // Add the message to the Chat Box
                textBoxSend.Text = String.Empty; // Reset the textbox
            }
        }

        void I_OnFetched(object sender, EventArgs e)
        {
            labelRibbonViewers.Text = "Nombre de spectateurs : " + (string)Core.TwitchAPI.I.Values["chatters"]["chatter_count"];

            // Define user list
            listBoxUsers.Items.Clear();

            foreach (string u in Core.TwitchAPI.I.Values["chatters"]["chatters"]["moderators"])
                listBoxUsers.Items.Add(new NListBoxItem(u));

            foreach (string u in Core.TwitchAPI.I.Values["chatters"]["chatters"]["viewers"])
                listBoxUsers.Items.Add(new NListBoxItem(u));
        }

        void I_OnChannelChanged(object sender, EventArgs e)
        {
            listBoxUsers.Items.Clear();
            labelRibbonChannel.Text = "Chaîne : " + Core.Bot.I.CurrentChannel;
            labelChannel.Text = Core.Bot.I.CurrentChannel;
        }

        void I_OnMessageReceived(object sender, EventArgs e)
        {
            string data = ((Core.ReceiveMessageEventArgs)e).Username + ": " + ((Core.ReceiveMessageEventArgs)e).Text;

            listBoxChat.Items.Add(new NListBoxItem(data));
        }

        public MainForm()
        {
            InitializeComponent();

            Controls.Clear();
            Controls.Add(controlMain);

            // Bind events
            Core.Bot.I.OnMessageReceived += I_OnMessageReceived;
            Core.Bot.I.OnChannelChanged += I_OnChannelChanged;
            Core.TwitchAPI.I.OnFetched += I_OnFetched;

            // Define channel labels
            labelRibbonChannel.Text = "Chaîne : " + Core.Bot.I.CurrentChannel;
            labelChannel.Text = Core.Bot.I.CurrentChannel;

            // Define Plugins list 
            listBoxPlugins.Items.Clear();

            foreach (string plugin in Core.Bot.I.LoadedPlugins)
            {
                NPluginCheckBox checkBox = new NPluginCheckBox(plugin);
                listBoxPlugins.Items.Add(new NListBoxItem(checkBox.GetCheckBox()));
            }
        }

    }
}
