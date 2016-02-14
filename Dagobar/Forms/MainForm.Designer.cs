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
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.tabPageRaw = new System.Windows.Forms.TabPage();
            this.richTextBoxRaw = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPageChat.SuspendLayout();
            this.tabPageRaw.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageChat);
            this.tabControl.Controls.Add(this.tabPageRaw);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(634, 396);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 435);
            this.Name = "MainForm";
            this.Text = "Dagobar";
            this.tabControl.ResumeLayout(false);
            this.tabPageChat.ResumeLayout(false);
            this.tabPageChat.PerformLayout();
            this.tabPageRaw.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageChat;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TabPage tabPageRaw;
        private System.Windows.Forms.RichTextBox richTextBoxRaw;




    }
}