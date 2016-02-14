namespace Dagobar.Forms
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.labelBotNickname = new System.Windows.Forms.Label();
            this.textBoxBotNick = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxOAuth = new System.Windows.Forms.TextBox();
            this.labelOAuth = new System.Windows.Forms.Label();
            this.textBoxOwner = new System.Windows.Forms.TextBox();
            this.labelOwner = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBotNickname
            // 
            this.labelBotNickname.AutoSize = true;
            this.labelBotNickname.Font = new System.Drawing.Font("Champagne & Limousines", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBotNickname.Location = new System.Drawing.Point(65, 80);
            this.labelBotNickname.Name = "labelBotNickname";
            this.labelBotNickname.Size = new System.Drawing.Size(225, 24);
            this.labelBotNickname.TabIndex = 1;
            this.labelBotNickname.Text = "Nom d\'utilisateur du bot:";
            // 
            // textBoxBotNick
            // 
            this.textBoxBotNick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBotNick.Font = new System.Drawing.Font("Open Sans", 12.5F);
            this.textBoxBotNick.Location = new System.Drawing.Point(296, 75);
            this.textBoxBotNick.Name = "textBoxBotNick";
            this.textBoxBotNick.Size = new System.Drawing.Size(376, 30);
            this.textBoxBotNick.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Champagne & Limousines", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(296, 183);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(376, 41);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Sauvegarder et relâcher Dagobar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxOAuth
            // 
            this.textBoxOAuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOAuth.Font = new System.Drawing.Font("Open Sans", 12.5F);
            this.textBoxOAuth.Location = new System.Drawing.Point(296, 110);
            this.textBoxOAuth.Name = "textBoxOAuth";
            this.textBoxOAuth.PasswordChar = '¤';
            this.textBoxOAuth.Size = new System.Drawing.Size(376, 30);
            this.textBoxOAuth.TabIndex = 9;
            this.textBoxOAuth.UseSystemPasswordChar = true;
            // 
            // labelOAuth
            // 
            this.labelOAuth.AutoSize = true;
            this.labelOAuth.Font = new System.Drawing.Font("Champagne & Limousines", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOAuth.Location = new System.Drawing.Point(153, 115);
            this.labelOAuth.Name = "labelOAuth";
            this.labelOAuth.Size = new System.Drawing.Size(137, 24);
            this.labelOAuth.TabIndex = 8;
            this.labelOAuth.Text = "OAuth du bot:";
            // 
            // textBoxOwner
            // 
            this.textBoxOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOwner.Font = new System.Drawing.Font("Open Sans", 12.5F);
            this.textBoxOwner.Location = new System.Drawing.Point(296, 145);
            this.textBoxOwner.Name = "textBoxOwner";
            this.textBoxOwner.Size = new System.Drawing.Size(376, 30);
            this.textBoxOwner.TabIndex = 11;
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.Font = new System.Drawing.Font("Champagne & Limousines", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwner.Location = new System.Drawing.Point(107, 150);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(183, 24);
            this.labelOwner.TabIndex = 10;
            this.labelOwner.Text = "Propriétaire du bot:";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.BackColor = System.Drawing.Color.SlateGray;
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLogo.Image = global::Dagobar.Properties.Resources.icon;
            this.pictureBoxLogo.InitialImage = null;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(660, 57);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 12;
            this.pictureBoxLogo.TabStop = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 236);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.textBoxOwner);
            this.Controls.Add(this.labelOwner);
            this.Controls.Add(this.textBoxOAuth);
            this.Controls.Add(this.labelOAuth);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxBotNick);
            this.Controls.Add(this.labelBotNickname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 275);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 275);
            this.Name = "SetupForm";
            this.Text = "Configuration de Dagobar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBotNickname;
        private System.Windows.Forms.TextBox textBoxBotNick;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxOAuth;
        private System.Windows.Forms.Label labelOAuth;
        private System.Windows.Forms.TextBox textBoxOwner;
        private System.Windows.Forms.Label labelOwner;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}