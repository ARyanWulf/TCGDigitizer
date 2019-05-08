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
            this.Main_Menu_Buttons_Panel = new System.Windows.Forms.Panel();
            this.Main_Menu_Buttons_Table = new System.Windows.Forms.TableLayoutPanel();
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            this.Slot_Panel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.welcome_label = new System.Windows.Forms.Label();
            this.logout_link = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.Top_Gradient_Panel = new System.Windows.Forms.AlphaGradientPanel();
            this.colorWithAlpha2 = new System.Windows.Forms.ColorWithAlpha();
            this.colorWithAlpha1 = new System.Windows.Forms.ColorWithAlpha();
            this.Main_Menu_Buttons_Panel.SuspendLayout();
            this.Main_Menu_Buttons_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            this.Slot_Panel.SuspendLayout();
            this.Top_Gradient_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScanButton
            // 
            this.ScanButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.ScanButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScanButton.FlatAppearance.BorderSize = 0;
            this.ScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanButton.ForeColor = System.Drawing.Color.Silver;
            this.ScanButton.Image = global::OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_silver_64;
            this.ScanButton.Location = new System.Drawing.Point(0, 0);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(0);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(318, 149);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "Scan";
            this.ScanButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ScanButton.UseVisualStyleBackColor = false;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // InventoryButton
            // 
            this.InventoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryButton.FlatAppearance.BorderSize = 0;
            this.InventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.ForeColor = System.Drawing.Color.Silver;
            this.InventoryButton.Image = global::OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_silver_64;
            this.InventoryButton.Location = new System.Drawing.Point(0, 149);
            this.InventoryButton.Margin = new System.Windows.Forms.Padding(0);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(318, 149);
            this.InventoryButton.TabIndex = 1;
            this.InventoryButton.Text = "Inventory";
            this.InventoryButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InventoryButton.UseVisualStyleBackColor = true;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.Silver;
            this.SettingsButton.Image = global::OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_silver_64;
            this.SettingsButton.Location = new System.Drawing.Point(0, 298);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(318, 149);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ContactButton
            // 
            this.ContactButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContactButton.FlatAppearance.BorderSize = 0;
            this.ContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactButton.ForeColor = System.Drawing.Color.Silver;
            this.ContactButton.Image = global::OCS_FOR_CSHARP.Properties.Resources.product_info_icon_flat_silver_64;
            this.ContactButton.Location = new System.Drawing.Point(0, 447);
            this.ContactButton.Margin = new System.Windows.Forms.Padding(0);
            this.ContactButton.Name = "ContactButton";
            this.ContactButton.Size = new System.Drawing.Size(318, 149);
            this.ContactButton.TabIndex = 3;
            this.ContactButton.Text = "Product Information";
            this.ContactButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ContactButton.UseVisualStyleBackColor = true;
            this.ContactButton.Click += new System.EventHandler(this.ContactButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.ForeColor = System.Drawing.Color.Silver;
            this.QuitButton.Image = global::OCS_FOR_CSHARP.Properties.Resources.quit_icon_flat_silver_64;
            this.QuitButton.Location = new System.Drawing.Point(0, 596);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(0);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(318, 153);
            this.QuitButton.TabIndex = 4;
            this.QuitButton.Text = "Quit";
            this.QuitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // Main_Menu_Buttons_Panel
            // 
            this.Main_Menu_Buttons_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Main_Menu_Buttons_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.Main_Menu_Buttons_Panel.Controls.Add(this.Main_Menu_Buttons_Table);
            this.Main_Menu_Buttons_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Main_Menu_Buttons_Panel.Location = new System.Drawing.Point(0, 0);
            this.Main_Menu_Buttons_Panel.Name = "Main_Menu_Buttons_Panel";
            this.Main_Menu_Buttons_Panel.Size = new System.Drawing.Size(318, 749);
            this.Main_Menu_Buttons_Panel.TabIndex = 17;
            // 
            // Main_Menu_Buttons_Table
            // 
            this.Main_Menu_Buttons_Table.ColumnCount = 1;
            this.Main_Menu_Buttons_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_Menu_Buttons_Table.Controls.Add(this.QuitButton, 0, 4);
            this.Main_Menu_Buttons_Table.Controls.Add(this.ContactButton, 0, 3);
            this.Main_Menu_Buttons_Table.Controls.Add(this.ScanButton, 0, 0);
            this.Main_Menu_Buttons_Table.Controls.Add(this.SettingsButton, 0, 2);
            this.Main_Menu_Buttons_Table.Controls.Add(this.InventoryButton, 0, 1);
            this.Main_Menu_Buttons_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Menu_Buttons_Table.Location = new System.Drawing.Point(0, 0);
            this.Main_Menu_Buttons_Table.Name = "Main_Menu_Buttons_Table";
            this.Main_Menu_Buttons_Table.RowCount = 5;
            this.Main_Menu_Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Main_Menu_Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Main_Menu_Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Main_Menu_Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Main_Menu_Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Main_Menu_Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Main_Menu_Buttons_Table.Size = new System.Drawing.Size(318, 749);
            this.Main_Menu_Buttons_Table.TabIndex = 5;
            // 
            // LogoPicture
            // 
            this.LogoPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogoPicture.Image = global::OCS_FOR_CSHARP.Properties.Resources.TCG_Logo_Transparent;
            this.LogoPicture.Location = new System.Drawing.Point(119, 3);
            this.LogoPicture.MaximumSize = new System.Drawing.Size(600, 150);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(600, 140);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPicture.TabIndex = 19;
            this.LogoPicture.TabStop = false;
            // 
            // Slot_Panel
            // 
            this.Slot_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Slot_Panel.Controls.Add(this.textBox1);
            this.Slot_Panel.Location = new System.Drawing.Point(321, 176);
            this.Slot_Panel.Name = "Slot_Panel";
            this.Slot_Panel.Size = new System.Drawing.Size(951, 573);
            this.Slot_Panel.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(295, 667);
            this.textBox1.MaximumSize = new System.Drawing.Size(500, 300);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(323, 122);
            this.textBox1.TabIndex = 27;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.WordWrap = false;
            // 
            // welcome_label
            // 
            this.welcome_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.welcome_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_label.Location = new System.Drawing.Point(800, 9);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(138, 36);
            this.welcome_label.TabIndex = 28;
            this.welcome_label.Text = "Welcome Guest";
            this.welcome_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.welcome_label.Visible = false;
            // 
            // logout_link
            // 
            this.logout_link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logout_link.AutoSize = true;
            this.logout_link.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_link.Location = new System.Drawing.Point(889, 45);
            this.logout_link.Name = "logout_link";
            this.logout_link.Size = new System.Drawing.Size(72, 25);
            this.logout_link.TabIndex = 20;
            this.logout_link.TabStop = true;
            this.logout_link.Text = "Logout";
            this.logout_link.VisitedLinkColor = System.Drawing.Color.Blue;
            this.logout_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_link_LinkClicked_1);
            // 
            // Top_Gradient_Panel
            // 
            this.Top_Gradient_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Top_Gradient_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Top_Gradient_Panel.Border = false;
            this.Top_Gradient_Panel.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.Top_Gradient_Panel.Colors.Add(this.colorWithAlpha2);
            this.Top_Gradient_Panel.Colors.Add(this.colorWithAlpha1);
            this.Top_Gradient_Panel.ContentPadding = new System.Windows.Forms.Padding(0);
            this.Top_Gradient_Panel.Controls.Add(this.welcome_label);
            this.Top_Gradient_Panel.Controls.Add(this.LogoPicture);
            this.Top_Gradient_Panel.Controls.Add(this.logout_link);
            this.Top_Gradient_Panel.CornerRadius = 20;
            this.Top_Gradient_Panel.Corners = System.Windows.Forms.Corner.None;
            this.Top_Gradient_Panel.Gradient = true;
            this.Top_Gradient_Panel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Top_Gradient_Panel.GradientOffset = 1F;
            this.Top_Gradient_Panel.GradientSize = new System.Drawing.Size(0, 0);
            this.Top_Gradient_Panel.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.Top_Gradient_Panel.Grayscale = false;
            this.Top_Gradient_Panel.Image = null;
            this.Top_Gradient_Panel.ImageAlpha = 75;
            this.Top_Gradient_Panel.ImagePadding = new System.Windows.Forms.Padding(5);
            this.Top_Gradient_Panel.ImagePosition = System.Windows.Forms.ImagePosition.BottomRight;
            this.Top_Gradient_Panel.ImageSize = new System.Drawing.Size(48, 48);
            this.Top_Gradient_Panel.Location = new System.Drawing.Point(321, 0);
            this.Top_Gradient_Panel.Name = "Top_Gradient_Panel";
            this.Top_Gradient_Panel.Rounded = true;
            this.Top_Gradient_Panel.Size = new System.Drawing.Size(956, 175);
            this.Top_Gradient_Panel.TabIndex = 19;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(78)))));
            this.colorWithAlpha2.Parent = this.Top_Gradient_Panel;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.colorWithAlpha1.Parent = this.Top_Gradient_Panel;
            // 
            // Main_Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1274, 749);
            this.Controls.Add(this.Top_Gradient_Panel);
            this.Controls.Add(this.Main_Menu_Buttons_Panel);
            this.Controls.Add(this.Slot_Panel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "Main_Menu";
            this.Text = "TCG Digitizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Main_Menu_Buttons_Panel.ResumeLayout(false);
            this.Main_Menu_Buttons_Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).EndInit();
            this.Slot_Panel.ResumeLayout(false);
            this.Slot_Panel.PerformLayout();
            this.Top_Gradient_Panel.ResumeLayout(false);
            this.Top_Gradient_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Button InventoryButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ContactButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Panel Main_Menu_Buttons_Panel;
        private System.Windows.Forms.Panel Slot_Panel;
        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel logout_link;
        private System.Windows.Forms.PictureBox LogoPicture;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.AlphaGradientPanel Top_Gradient_Panel;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.ColorWithAlpha colorWithAlpha2;
        private System.Windows.Forms.TableLayoutPanel Main_Menu_Buttons_Table;
    }
}