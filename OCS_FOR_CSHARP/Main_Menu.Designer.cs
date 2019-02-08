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
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(67, 101);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(144, 54);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // InventoryButton
            // 
            this.InventoryButton.Location = new System.Drawing.Point(67, 161);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(144, 54);
            this.InventoryButton.TabIndex = 1;
            this.InventoryButton.Text = "Inventory";
            this.InventoryButton.UseVisualStyleBackColor = true;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(67, 221);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(144, 54);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ContactButton
            // 
            this.ContactButton.Location = new System.Drawing.Point(67, 281);
            this.ContactButton.Name = "ContactButton";
            this.ContactButton.Size = new System.Drawing.Size(144, 54);
            this.ContactButton.TabIndex = 3;
            this.ContactButton.Text = "Product Information";
            this.ContactButton.UseVisualStyleBackColor = true;
            this.ContactButton.Click += new System.EventHandler(this.ContactButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(67, 341);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(144, 54);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // ContactText
            // 
            this.ContactText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContactText.Location = new System.Drawing.Point(440, 101);
            this.ContactText.MaximumSize = new System.Drawing.Size(300, 300);
            this.ContactText.Multiline = true;
            this.ContactText.Name = "ContactText";
            this.ContactText.ReadOnly = true;
            this.ContactText.Size = new System.Drawing.Size(258, 234);
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
            this.CloseTextButton.Location = new System.Drawing.Point(496, 341);
            this.CloseTextButton.Name = "CloseTextButton";
            this.CloseTextButton.Size = new System.Drawing.Size(144, 54);
            this.CloseTextButton.TabIndex = 6;
            this.CloseTextButton.Text = "Close";
            this.CloseTextButton.UseVisualStyleBackColor = true;
            this.CloseTextButton.Visible = false;
            this.CloseTextButton.Click += new System.EventHandler(this.CloseTextButton_Click);
            // 
            // LogoPicture
            // 
            this.LogoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogoPicture.Image = global::OCS_FOR_CSHARP.Properties.Resources.TCG_Logo_Transparent;
            this.LogoPicture.Location = new System.Drawing.Point(12, 12);
            this.LogoPicture.MaximumSize = new System.Drawing.Size(369, 80);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(369, 80);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPicture.TabIndex = 7;
            this.LogoPicture.TabStop = false;
            // 
            // Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}