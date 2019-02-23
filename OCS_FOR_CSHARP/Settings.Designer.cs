namespace OCS_FOR_CSHARP
{
    partial class Settings
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
            this.QuitButton = new System.Windows.Forms.Button();
            this.DefualtButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.DeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.Load_Card_Button = new System.Windows.Forms.Button();
            this.user_settings_backpanel = new System.Windows.Forms.PictureBox();
            this.user_text_box = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.last_name_label_1 = new System.Windows.Forms.Label();
            this.user_first_name_sort = new System.Windows.Forms.Button();
            this.user_last_name_sort = new System.Windows.Forms.Button();
            this.first_name_label_1 = new System.Windows.Forms.Label();
            this.authority_label_1 = new System.Windows.Forms.Label();
            this.authority_sort_button = new System.Windows.Forms.Button();
            this.userCheckBox1 = new System.Windows.Forms.CheckBox();
            this.SettingsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.user_settings_backpanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButton.Location = new System.Drawing.Point(620, 540);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(144, 54);
            this.QuitButton.TabIndex = 5;
            this.QuitButton.Text = "Back";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // DefualtButton
            // 
            this.DefualtButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DefualtButton.Location = new System.Drawing.Point(45, 525);
            this.DefualtButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DefualtButton.Name = "DefualtButton";
            this.DefualtButton.Size = new System.Drawing.Size(144, 54);
            this.DefualtButton.TabIndex = 6;
            this.DefualtButton.Text = "Restore Defaults";
            this.DefualtButton.UseVisualStyleBackColor = true;
            this.DefualtButton.Click += new System.EventHandler(this.DefualtButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteAllButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeleteAllButton.Enabled = false;
            this.DeleteAllButton.Location = new System.Drawing.Point(195, 465);
            this.DeleteAllButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(144, 54);
            this.DeleteAllButton.TabIndex = 7;
            this.DeleteAllButton.Text = "Erase Inventory";
            this.DeleteAllButton.UseVisualStyleBackColor = false;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // DeleteCheckbox
            // 
            this.DeleteCheckbox.AutoSize = true;
            this.DeleteCheckbox.Location = new System.Drawing.Point(345, 483);
            this.DeleteCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteCheckbox.Name = "DeleteCheckbox";
            this.DeleteCheckbox.Size = new System.Drawing.Size(22, 21);
            this.DeleteCheckbox.TabIndex = 8;
            this.DeleteCheckbox.UseVisualStyleBackColor = true;
            this.DeleteCheckbox.CheckedChanged += new System.EventHandler(this.DeleteCheckbox_CheckedChanged);
            // 
            // Load_Card_Button
            // 
            this.Load_Card_Button.Location = new System.Drawing.Point(45, 465);
            this.Load_Card_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Load_Card_Button.Name = "Load_Card_Button";
            this.Load_Card_Button.Size = new System.Drawing.Size(144, 54);
            this.Load_Card_Button.TabIndex = 9;
            this.Load_Card_Button.Text = "Load Card Data";
            this.Load_Card_Button.UseVisualStyleBackColor = true;
            // 
            // user_settings_backpanel
            // 
            this.user_settings_backpanel.BackColor = System.Drawing.Color.Transparent;
            this.user_settings_backpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_settings_backpanel.Location = new System.Drawing.Point(24, 85);
            this.user_settings_backpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user_settings_backpanel.Name = "user_settings_backpanel";
            this.user_settings_backpanel.Size = new System.Drawing.Size(437, 237);
            this.user_settings_backpanel.TabIndex = 10;
            this.user_settings_backpanel.TabStop = false;
            // 
            // user_text_box
            // 
            this.user_text_box.BackColor = System.Drawing.SystemColors.Control;
            this.user_text_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_text_box.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_text_box.ForeColor = System.Drawing.SystemColors.WindowText;
            this.user_text_box.Location = new System.Drawing.Point(24, 84);
            this.user_text_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user_text_box.Multiline = true;
            this.user_text_box.Name = "user_text_box";
            this.user_text_box.ReadOnly = true;
            this.user_text_box.Size = new System.Drawing.Size(69, 28);
            this.user_text_box.TabIndex = 11;
            this.user_text_box.Text = "Users";
            this.user_text_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.user_text_box.WordWrap = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.33742F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.66257F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Controls.Add(this.selectAllCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.last_name_label_1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.user_first_name_sort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.user_last_name_sort, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.first_name_label_1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.authority_label_1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.authority_sort_button, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.userCheckBox1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(45, 118);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.8125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.1875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 155);
            this.tableLayoutPanel1.TabIndex = 12;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(5, 6);
            this.selectAllCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(21, 39);
            this.selectAllCheckBox.TabIndex = 17;
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // last_name_label_1
            // 
            this.last_name_label_1.Location = new System.Drawing.Point(185, 51);
            this.last_name_label_1.Name = "last_name_label_1";
            this.last_name_label_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.last_name_label_1.Size = new System.Drawing.Size(97, 34);
            this.last_name_label_1.TabIndex = 13;
            this.last_name_label_1.Text = "label1";
            this.last_name_label_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // user_first_name_sort
            // 
            this.user_first_name_sort.Location = new System.Drawing.Point(34, 6);
            this.user_first_name_sort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user_first_name_sort.Name = "user_first_name_sort";
            this.user_first_name_sort.Size = new System.Drawing.Size(143, 39);
            this.user_first_name_sort.TabIndex = 0;
            this.user_first_name_sort.Text = "First";
            this.user_first_name_sort.UseVisualStyleBackColor = true;
            // 
            // user_last_name_sort
            // 
            this.user_last_name_sort.Location = new System.Drawing.Point(185, 6);
            this.user_last_name_sort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user_last_name_sort.Name = "user_last_name_sort";
            this.user_last_name_sort.Size = new System.Drawing.Size(97, 39);
            this.user_last_name_sort.TabIndex = 1;
            this.user_last_name_sort.Text = "Last";
            this.user_last_name_sort.UseVisualStyleBackColor = true;
            // 
            // first_name_label_1
            // 
            this.first_name_label_1.Location = new System.Drawing.Point(34, 51);
            this.first_name_label_1.Name = "first_name_label_1";
            this.first_name_label_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.first_name_label_1.Size = new System.Drawing.Size(143, 34);
            this.first_name_label_1.TabIndex = 2;
            this.first_name_label_1.Text = "label1";
            this.first_name_label_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authority_label_1
            // 
            this.authority_label_1.Location = new System.Drawing.Point(291, 51);
            this.authority_label_1.Name = "authority_label_1";
            this.authority_label_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.authority_label_1.Size = new System.Drawing.Size(97, 34);
            this.authority_label_1.TabIndex = 14;
            this.authority_label_1.Text = "label1";
            this.authority_label_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authority_sort_button
            // 
            this.authority_sort_button.Location = new System.Drawing.Point(291, 6);
            this.authority_sort_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.authority_sort_button.Name = "authority_sort_button";
            this.authority_sort_button.Size = new System.Drawing.Size(97, 39);
            this.authority_sort_button.TabIndex = 15;
            this.authority_sort_button.Text = "Authority";
            this.authority_sort_button.UseVisualStyleBackColor = true;
            this.authority_sort_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // userCheckBox1
            // 
            this.userCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userCheckBox1.AutoSize = true;
            this.userCheckBox1.Location = new System.Drawing.Point(5, 55);
            this.userCheckBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCheckBox1.Name = "userCheckBox1";
            this.userCheckBox1.Size = new System.Drawing.Size(21, 26);
            this.userCheckBox1.TabIndex = 16;
            this.userCheckBox1.UseVisualStyleBackColor = true;
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLabel.Location = new System.Drawing.Point(143, 18);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(164, 46);
            this.SettingsLabel.TabIndex = 13;
            this.SettingsLabel.Text = "Settings";
            this.SettingsLabel.Click += new System.EventHandler(this.SettingsLabel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.user_text_box);
            this.Controls.Add(this.Load_Card_Button);
            this.Controls.Add(this.DeleteCheckbox);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.DefualtButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.user_settings_backpanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.user_settings_backpanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button DefualtButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.CheckBox DeleteCheckbox;
        private System.Windows.Forms.Button Load_Card_Button;
        private System.Windows.Forms.PictureBox user_settings_backpanel;
        private System.Windows.Forms.TextBox user_text_box;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button user_first_name_sort;
        private System.Windows.Forms.Button user_last_name_sort;
        private System.Windows.Forms.Label first_name_label_1;
        private System.Windows.Forms.Label last_name_label_1;
        private System.Windows.Forms.Label authority_label_1;
        private System.Windows.Forms.Button authority_sort_button;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.CheckBox userCheckBox1;
        private System.Windows.Forms.Label SettingsLabel;
    }
}