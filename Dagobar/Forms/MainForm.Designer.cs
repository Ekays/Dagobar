namespace Dagobar.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageChat = new System.Windows.Forms.TabPage();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.tabPageRaw = new System.Windows.Forms.TabPage();
            this.richTextBoxRaw = new System.Windows.Forms.RichTextBox();
            this.tabPageInformations = new System.Windows.Forms.TabPage();
            this.labelViewers = new System.Windows.Forms.Label();
            this.labelIntroViewers = new System.Windows.Forms.Label();
            this.labelPlugins = new System.Windows.Forms.Label();
            this.labelIntroPlugins = new System.Windows.Forms.Label();
            this.labelChannel = new System.Windows.Forms.Label();
            this.labelIntroChannel = new System.Windows.Forms.Label();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonChangeChannel = new System.Windows.Forms.Button();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPageChat.SuspendLayout();
            this.tabPageRaw.SuspendLayout();
            this.tabPageInformations.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.tableLayoutPanelOptions.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageChat);
            this.tabControl.Controls.Add(this.tabPageRaw);
            this.tabControl.Controls.Add(this.tabPageInformations);
            this.tabControl.Controls.Add(this.tabPageOptions);
            this.tabControl.Controls.Add(this.tabPageAbout);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(634, 396);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageChat
            // 
            this.tabPageChat.Controls.Add(this.textBoxChat);
            this.tabPageChat.Controls.Add(this.richTextBoxChat);
            this.tabPageChat.Location = new System.Drawing.Point(4, 27);
            this.tabPageChat.Name = "tabPageChat";
            this.tabPageChat.Size = new System.Drawing.Size(626, 365);
            this.tabPageChat.TabIndex = 0;
            this.tabPageChat.Text = "Chat";
            this.tabPageChat.UseVisualStyleBackColor = true;
            // 
            // textBoxChat
            // 
            this.textBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChat.BackColor = System.Drawing.Color.SlateGray;
            this.textBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxChat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxChat.ForeColor = System.Drawing.Color.White;
            this.textBoxChat.Location = new System.Drawing.Point(3, 334);
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(620, 25);
            this.textBoxChat.TabIndex = 1;
            this.textBoxChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyDown);
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChat.BackColor = System.Drawing.Color.SlateGray;
            this.richTextBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxChat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxChat.ForeColor = System.Drawing.Color.White;
            this.richTextBoxChat.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(620, 323);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // tabPageRaw
            // 
            this.tabPageRaw.Controls.Add(this.richTextBoxRaw);
            this.tabPageRaw.Location = new System.Drawing.Point(4, 27);
            this.tabPageRaw.Name = "tabPageRaw";
            this.tabPageRaw.Size = new System.Drawing.Size(626, 365);
            this.tabPageRaw.TabIndex = 1;
            this.tabPageRaw.Text = "Données brutes";
            this.tabPageRaw.UseVisualStyleBackColor = true;
            // 
            // richTextBoxRaw
            // 
            this.richTextBoxRaw.BackColor = System.Drawing.Color.SlateGray;
            this.richTextBoxRaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxRaw.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxRaw.ForeColor = System.Drawing.Color.White;
            this.richTextBoxRaw.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxRaw.Name = "richTextBoxRaw";
            this.richTextBoxRaw.ReadOnly = true;
            this.richTextBoxRaw.Size = new System.Drawing.Size(626, 365);
            this.richTextBoxRaw.TabIndex = 1;
            this.richTextBoxRaw.Text = "";
            // 
            // tabPageInformations
            // 
            this.tabPageInformations.BackColor = System.Drawing.Color.SlateGray;
            this.tabPageInformations.Controls.Add(this.labelViewers);
            this.tabPageInformations.Controls.Add(this.labelIntroViewers);
            this.tabPageInformations.Controls.Add(this.labelPlugins);
            this.tabPageInformations.Controls.Add(this.labelIntroPlugins);
            this.tabPageInformations.Controls.Add(this.labelChannel);
            this.tabPageInformations.Controls.Add(this.labelIntroChannel);
            this.tabPageInformations.ForeColor = System.Drawing.Color.White;
            this.tabPageInformations.Location = new System.Drawing.Point(4, 27);
            this.tabPageInformations.Name = "tabPageInformations";
            this.tabPageInformations.Size = new System.Drawing.Size(626, 365);
            this.tabPageInformations.TabIndex = 3;
            this.tabPageInformations.Text = "Informations";
            // 
            // labelViewers
            // 
            this.labelViewers.AutoSize = true;
            this.labelViewers.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViewers.Location = new System.Drawing.Point(121, 31);
            this.labelViewers.Name = "labelViewers";
            this.labelViewers.Size = new System.Drawing.Size(105, 22);
            this.labelViewers.TabIndex = 5;
            this.labelViewers.Text = "Mise à jour...";
            // 
            // labelIntroViewers
            // 
            this.labelIntroViewers.AutoSize = true;
            this.labelIntroViewers.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroViewers.Location = new System.Drawing.Point(11, 31);
            this.labelIntroViewers.Name = "labelIntroViewers";
            this.labelIntroViewers.Size = new System.Drawing.Size(77, 22);
            this.labelIntroViewers.TabIndex = 4;
            this.labelIntroViewers.Text = "Viewers: ";
            // 
            // labelPlugins
            // 
            this.labelPlugins.AutoSize = true;
            this.labelPlugins.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlugins.Location = new System.Drawing.Point(121, 53);
            this.labelPlugins.Name = "labelPlugins";
            this.labelPlugins.Size = new System.Drawing.Size(105, 22);
            this.labelPlugins.TabIndex = 3;
            this.labelPlugins.Text = "Mise à jour...";
            // 
            // labelIntroPlugins
            // 
            this.labelIntroPlugins.AutoSize = true;
            this.labelIntroPlugins.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroPlugins.Location = new System.Drawing.Point(15, 53);
            this.labelIntroPlugins.Name = "labelIntroPlugins";
            this.labelIntroPlugins.Size = new System.Drawing.Size(73, 22);
            this.labelIntroPlugins.TabIndex = 2;
            this.labelIntroPlugins.Text = "Plugins: ";
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChannel.Location = new System.Drawing.Point(121, 9);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(109, 22);
            this.labelChannel.TabIndex = 1;
            this.labelChannel.Text = "Mise à jour ...";
            // 
            // labelIntroChannel
            // 
            this.labelIntroChannel.AutoSize = true;
            this.labelIntroChannel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroChannel.Location = new System.Drawing.Point(8, 9);
            this.labelIntroChannel.Name = "labelIntroChannel";
            this.labelIntroChannel.Size = new System.Drawing.Size(80, 22);
            this.labelIntroChannel.TabIndex = 0;
            this.labelIntroChannel.Text = "Channel: ";
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.BackColor = System.Drawing.Color.SlateGray;
            this.tabPageOptions.Controls.Add(this.tableLayoutPanelOptions);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 27);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Size = new System.Drawing.Size(626, 365);
            this.tabPageOptions.TabIndex = 2;
            this.tabPageOptions.Text = "Options";
            // 
            // tableLayoutPanelOptions
            // 
            this.tableLayoutPanelOptions.ColumnCount = 1;
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOptions.Controls.Add(this.buttonSettings, 0, 0);
            this.tableLayoutPanelOptions.Controls.Add(this.buttonQuit, 0, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.buttonChangeChannel, 0, 1);
            this.tableLayoutPanelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOptions.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
            this.tableLayoutPanelOptions.RowCount = 3;
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelOptions.Size = new System.Drawing.Size(626, 365);
            this.tableLayoutPanelOptions.TabIndex = 0;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSettings.Location = new System.Drawing.Point(3, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(620, 44);
            this.buttonSettings.TabIndex = 0;
            this.buttonSettings.Text = "Configuration";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonQuit.Location = new System.Drawing.Point(3, 103);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(620, 44);
            this.buttonQuit.TabIndex = 1;
            this.buttonQuit.Text = "Quitter";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonChangeChannel
            // 
            this.buttonChangeChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChangeChannel.Location = new System.Drawing.Point(3, 53);
            this.buttonChangeChannel.Name = "buttonChangeChannel";
            this.buttonChangeChannel.Size = new System.Drawing.Size(620, 44);
            this.buttonChangeChannel.TabIndex = 2;
            this.buttonChangeChannel.Text = "Changer de channel";
            this.buttonChangeChannel.UseVisualStyleBackColor = true;
            this.buttonChangeChannel.Click += new System.EventHandler(this.buttonChangeChannel_Click);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.BackColor = System.Drawing.Color.SlateGray;
            this.tabPageAbout.Controls.Add(this.richTextBoxAbout);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 27);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(626, 365);
            this.tabPageAbout.TabIndex = 4;
            this.tabPageAbout.Text = "À propos";
            // 
            // richTextBoxAbout
            // 
            this.richTextBoxAbout.BackColor = System.Drawing.Color.SlateGray;
            this.richTextBoxAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxAbout.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxAbout.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAbout.ForeColor = System.Drawing.Color.White;
            this.richTextBoxAbout.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxAbout.Name = "richTextBoxAbout";
            this.richTextBoxAbout.Size = new System.Drawing.Size(626, 365);
            this.richTextBoxAbout.TabIndex = 0;
            this.richTextBoxAbout.Text = resources.GetString("richTextBoxAbout.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(634, 396);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 435);
            this.Name = "MainForm";
            this.Text = "Dagobar";
            this.tabControl.ResumeLayout(false);
            this.tabPageChat.ResumeLayout(false);
            this.tabPageChat.PerformLayout();
            this.tabPageRaw.ResumeLayout(false);
            this.tabPageInformations.ResumeLayout(false);
            this.tabPageInformations.PerformLayout();
            this.tabPageOptions.ResumeLayout(false);
            this.tableLayoutPanelOptions.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageChat;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TabPage tabPageRaw;
        private System.Windows.Forms.RichTextBox richTextBoxRaw;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptions;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonChangeChannel;
        private System.Windows.Forms.TabPage tabPageInformations;
        private System.Windows.Forms.Label labelIntroChannel;
        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.Label labelPlugins;
        private System.Windows.Forms.Label labelIntroPlugins;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.RichTextBox richTextBoxAbout;
        private System.Windows.Forms.Label labelViewers;
        private System.Windows.Forms.Label labelIntroViewers;




    }
}