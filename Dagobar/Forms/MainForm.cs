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
        private NListBox listBoxUsers, listBoxChat;
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

            buttonSend = new NButton("Envoyer");
            buttonSend.PreferredWidth = 100;
            buttonSend.Content.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            buttonSend.Margins = new Nevron.Nov.Graphics.NMargins(3.0);

            panelSend = new NStackPanel();
            panelSend.Direction = Nevron.Nov.Layout.ENHVDirection.LeftToRight;
            panelSend.FillMode = Nevron.Nov.Layout.ENStackFillMode.First;
            panelSend.Add(textBoxSend);
            panelSend.Add(buttonSend);

            listBoxChat = new NListBox();
            listBoxChat.Margins = new Nevron.Nov.Graphics.NMargins(1.0);
            listBoxChat.Items.Add(new NListBoxItem("mandytoh : Je suis beau gosse"));
            listBoxChat.Items.Add(new NListBoxItem("r00tkiller : Moi plus"));
            listBoxChat.Items.Add(new NListBoxItem("jesterxav : Ouai j'avoue, r00t est plus Bg..."));

            panelChat = new NStackPanel();
            panelChat.Direction = Nevron.Nov.Layout.ENHVDirection.TopToBottom;
            panelChat.FillMode = Nevron.Nov.Layout.ENStackFillMode.First;
            panelChat.Add(listBoxChat);
            panelChat.Add(panelSend);

            labelChannel = new NLabel("mandytoh");
            labelChannel.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            labelChannel.Font = new Nevron.Nov.Graphics.NFont("Lucidia Console", 14);

            listBoxUsers = new NListBox();
            listBoxUsers.Margins = new Nevron.Nov.Graphics.NMargins(1.0);
            listBoxUsers.Items.Add(new NListBoxItem("mandytoh"));
            listBoxUsers.Items.Add(new NListBoxItem("r00tkiller"));
            listBoxUsers.Items.Add(new NListBoxItem("jesterxav"));

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
            labelRibbonChannel = new NLabel("Chaîne : mandytoh");
            labelRibbonChannel.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            labelRibbonViewers = new NLabel("Nombre de spectateurs : 999");
            labelRibbonViewers.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            labelRibbonVersion = new NLabel("Version : alpha2");
            labelRibbonVersion.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;

            panelRibbonInformations.Add(labelRibbonChannel);
            panelRibbonInformations.Add(labelRibbonViewers);
            panelRibbonInformations.Add(labelRibbonVersion);

            ribbonGroupInformations = new NRibbonGroup("Informations");
            ribbonGroupInformations.Header.DialogLauncherButton.Visibility = ENVisibility.Hidden;
            ribbonGroupInformations.PreferredHeight = 64;
            ribbonGroupInformations.Items.Add(panelRibbonInformations);

            NListBox ls = new NListBox();
            ls.VScrollMode = ENScrollMode.Always;
            ls.PreferredHeight = 64;
            ls.PreferredWidth = 256;
            ls.Items.Add(new NListBoxItem(new NCheckBox("PluginA", true)));
            ls.Items.Add(new NListBoxItem(new NCheckBox("PluginB", false)));
            ls.Items.Add(new NListBoxItem(new NCheckBox("PluginC", true)));
            ls.Items.Add(new NListBoxItem(new NCheckBox("PluginD", true)));
            ls.Items.Add(new NListBoxItem(new NCheckBox("PluginE", true)));
            ls.Items.Add(new NListBoxItem(new NCheckBox("PluginF", true)));

            NStackPanel panel = new NStackPanel();
            panel.FillMode = Nevron.Nov.Layout.ENStackFillMode.First;
            panel.FillMode = Nevron.Nov.Layout.ENStackFillMode.Equal;
            panel.HorizontalPlacement = Nevron.Nov.Layout.ENHorizontalPlacement.Center;
            panel.Add(ls);

            ribbonGroupPlugins = new NRibbonGroup("Plugins");
            ribbonGroupPlugins.Header.DialogLauncherButton.Visibility = ENVisibility.Hidden;
            ribbonGroupPlugins.Items.Add(panel);

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
            throw new NotImplementedException();
        }

        void ribbonButtonConfiguration_Click(Nevron.Nov.Dom.NEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public MainForm()
        {
            InitializeComponent();

            Controls.Clear();
            Controls.Add(controlMain);
        }

    }
}
