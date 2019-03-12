namespace OCS_FOR_CSHARP
{
    partial class Main_Menu
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
            this.ScanButton = new System.Windows.Forms.Button();
            this.InventoryButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ContactButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.ContactText = new System.Windows.Forms.TextBox();
            this.CloseTextButton = new System.Windows.Forms.Button();
            this.logout_link = new System.Windows.Forms.LinkLabel();
            this.login_username_textbox = new System.Windows.Forms.TextBox();
            this.user_name_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_password_textbox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.login_label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            this.welcome_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ScanButton
            // 
            this.ScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanButton.Location = new System.Drawing.Point(137, 235);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(375, 75);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // InventoryButton
            // 
            this.InventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.Location = new System.Drawing.Point(137, 335);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(375, 75);
            this.InventoryButton.TabIndex = 1;
            this.InventoryButton.Text = "Inventory";
            this.InventoryButton.UseVisualStyleBackColor = true;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.Location = new System.Drawing.Point(137, 435);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(375, 75);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ContactButton
            // 
            this.ContactButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactButton.Location = new System.Drawing.Point(137, 535);
            this.ContactButton.Name = "ContactButton";
            this.ContactButton.Size = new System.Drawing.Size(375, 75);
            this.ContactButton.TabIndex = 3;
            this.ContactButton.Text = "Product Information";
            this.ContactButton.UseVisualStyleBackColor = true;
            this.ContactButton.Click += new System.EventHandler(this.ContactButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(137, 635);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(375, 75);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // ContactText
            // 
            this.ContactText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContactText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactText.Location = new System.Drawing.Point(617, 322);
            this.ContactText.MaximumSize = new System.Drawing.Size(500, 300);
            this.ContactText.Multiline = true;
            this.ContactText.Name = "ContactText";
            this.ContactText.ReadOnly = true;
            this.ContactText.Size = new System.Drawing.Size(437, 234);
            this.ContactText.TabIndex = 5;
            this.ContactText.Text = "TCG Digitizer Development Team\r\n-Brodie Boldt\r\n-Chris Cooper\r\n-Ryan Fox\r\n-Jared P" +
    "arks";
            this.ContactText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ContactText.Visible = false;
            this.ContactText.WordWrap = false;
            this.ContactText.TextChanged += new System.EventHandler(this.ContactText_TextChanged);
            // 
            // CloseTextButton
            // 
            this.CloseTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseTextButton.Location = new System.Drawing.Point(707, 562);
            this.CloseTextButton.Name = "CloseTextButton";
            this.CloseTextButton.Size = new System.Drawing.Size(258, 48);
            this.CloseTextButton.TabIndex = 6;
            this.CloseTextButton.Text = "Close";
            this.CloseTextButton.UseVisualStyleBackColor = true;
            this.CloseTextButton.Visible = false;
            this.CloseTextButton.Click += new System.EventHandler(this.CloseTextButton_Click);
            // 
            // logout_link
            // 
            this.logout_link.AutoSize = true;
            this.logout_link.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_link.Location = new System.Drawing.Point(1040, 45);
            this.logout_link.Name = "logout_link";
            this.logout_link.Size = new System.Drawing.Size(72, 25);
            this.logout_link.TabIndex = 8;
            this.logout_link.TabStop = true;
            this.logout_link.Text = "Logout";
            this.logout_link.VisitedLinkColor = System.Drawing.Color.Blue;
            this.logout_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_link_LinkClicked);
            // 
            // login_username_textbox
            // 
            this.login_username_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_username_textbox.Location = new System.Drawing.Point(803, 358);
            this.login_username_textbox.Name = "login_username_textbox";
            this.login_username_textbox.Size = new System.Drawing.Size(162, 30);
            this.login_username_textbox.TabIndex = 9;
            this.login_username_textbox.TextChanged += new System.EventHandler(this.login_username_textbox_TextChanged);
            // 
            // user_name_label
            // 
            this.user_name_label.AutoSize = true;
            this.user_name_label.Location = new System.Drawing.Point(699, 365);
            this.user_name_label.Name = "user_name_label";
            this.user_name_label.Size = new System.Drawing.Size(83, 20);
            this.user_name_label.TabIndex = 10;
            this.user_name_label.Text = "Username";
            this.user_name_label.Click += new System.EventHandler(this.user_name_label_Click);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(699, 416);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(78, 20);
            this.password_label.TabIndex = 12;
            this.password_label.Text = "Password";
            this.password_label.Click += new System.EventHandler(this.password_label_Click);
            // 
            // login_password_textbox
            // 
            this.login_password_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_password_textbox.Location = new System.Drawing.Point(803, 409);
            this.login_password_textbox.Name = "login_password_textbox";
            this.login_password_textbox.Size = new System.Drawing.Size(162, 30);
            this.login_password_textbox.TabIndex = 11;
            this.login_password_textbox.TextChanged += new System.EventHandler(this.login_password_textbox_TextChanged);
            // 
            // login_button
            // 
            this.login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.Location = new System.Drawing.Point(774, 465);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(146, 43);
            this.login_button.TabIndex = 14;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Visible = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_label.Location = new System.Drawing.Point(768, 302);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(152, 32);
            this.login_label.TabIndex = 13;
            this.login_label.Text = "User Login";
            this.login_label.Click += new System.EventHandler(this.login_label_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(703, 513);
            this.textBox1.MaximumSize = new System.Drawing.Size(500, 300);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(262, 59);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LogoPicture
            // 
            this.LogoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogoPicture.Image = global::OCS_FOR_CSHARP.Properties.Resources.TCG_Logo_Transparent;
            this.LogoPicture.Location = new System.Drawing.Point(31, 24);
            this.LogoPicture.MaximumSize = new System.Drawing.Size(600, 150);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(600, 140);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPicture.TabIndex = 7;
            this.LogoPicture.TabStop = false;
            // 
            // welcome_label
            // 
            this.welcome_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.welcome_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_label.Location = new System.Drawing.Point(828, 9);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(293, 36);
            this.welcome_label.TabIndex = 16;
            this.welcome_label.Text = "Welcome Guest";
            // 
            // Main_Menu
            // 
            this.AcceptButton = this.login_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 807);
            this.Controls.Add(this.welcome_label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_password_textbox);
            this.Controls.Add(this.user_name_label);
            this.Controls.Add(this.login_username_textbox);
            this.Controls.Add(this.logout_link);
            this.Controls.Add(this.LogoPicture);
            this.Controls.Add(this.CloseTextButton);
            this.Controls.Add(this.ContactText);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ContactButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.ScanButton);
            this.Name = "Main_Menu";
            this.Text = "TCG Digitizer";
            this.Load += new System.EventHandler(this.Main_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Button InventoryButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ContactButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.TextBox ContactText;
        private System.Windows.Forms.Button CloseTextButton;
        private System.Windows.Forms.PictureBox LogoPicture;
        private System.Windows.Forms.LinkLabel logout_link;
        private System.Windows.Forms.TextBox login_username_textbox;
        private System.Windows.Forms.Label user_name_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox login_password_textbox;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label welcome_label;
    }
}