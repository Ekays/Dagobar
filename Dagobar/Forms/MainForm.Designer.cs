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
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonChangeChannel = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageChat.SuspendLayout();
            this.tabPageRaw.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.tableLayoutPanelOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageChat);
            this.tabControl.Controls.Add(this.tabPageRaw);
            this.tabControl.Controls.Add(this.tabPageOptions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(634, 396);
            this.tabControl.TabIndex = 0;
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
            this.textBoxChat.Location = new System.Drawing.Point(3, 332);
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
            this.richTextBoxRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxRaw.BackColor = System.Drawing.Color.SlateGray;
            this.richTextBoxRaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxRaw.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxRaw.ForeColor = System.Drawing.Color.White;
            this.richTextBoxRaw.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxRaw.Name = "richTextBoxRaw";
            this.richTextBoxRaw.ReadOnly = true;
            this.richTextBoxRaw.Size = new System.Drawing.Size(620, 354);
            this.richTextBoxRaw.TabIndex = 1;
            this.richTextBoxRaw.Text = "";
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
            this.tabPageOptions.ResumeLayout(false);
            this.tableLayoutPanelOptions.ResumeLayout(false);
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




    }
}