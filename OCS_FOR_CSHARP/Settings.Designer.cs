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
            this.DefualtButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.Load_Card_Button = new System.Windows.Forms.Button();
            this.Users_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.user_first_name_sort = new System.Windows.Forms.Button();
            this.user_last_name_sort = new System.Windows.Forms.Button();
            this.authority_sort_button = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progress_textbox = new System.Windows.Forms.TextBox();
            this.newUserButton = new System.Windows.Forms.Button();
            this.dropUser = new System.Windows.Forms.Button();
            this.editUserButton = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.users_header_panel = new System.Windows.Forms.TableLayoutPanel();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.user_settings_buttons_panel = new System.Windows.Forms.Panel();
            this.Buttons_Table = new System.Windows.Forms.TableLayoutPanel();
            this.user_table_panel = new System.Windows.Forms.Panel();
            this.Users_Left_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.users_header_panel.SuspendLayout();
            this.user_settings_buttons_panel.SuspendLayout();
            this.Buttons_Table.SuspendLayout();
            this.user_table_panel.SuspendLayout();
            this.Users_Left_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefualtButton
            // 
            this.DefualtButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DefualtButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefualtButton.FlatAppearance.BorderSize = 0;
            this.DefualtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DefualtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefualtButton.Location = new System.Drawing.Point(2, 626);
            this.DefualtButton.Margin = new System.Windows.Forms.Padding(2);
            this.DefualtButton.Name = "DefualtButton";
            this.DefualtButton.Size = new System.Drawing.Size(357, 205);
            this.DefualtButton.TabIndex = 6;
            this.DefualtButton.Text = "Restore Defaults";
            this.DefualtButton.UseVisualStyleBackColor = true;
            this.DefualtButton.Click += new System.EventHandler(this.DefualtButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.DeleteAllButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeleteAllButton.Enabled = false;
            this.DeleteAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAllButton.Location = new System.Drawing.Point(11, 787);
            this.DeleteAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(96, 35);
            this.DeleteAllButton.TabIndex = 7;
            this.DeleteAllButton.Text = "Erase Inventory";
            this.DeleteAllButton.UseVisualStyleBackColor = false;
            this.DeleteAllButton.Visible = false;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // Load_Card_Button
            // 
            this.Load_Card_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Load_Card_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Card_Button.Location = new System.Drawing.Point(111, 787);
            this.Load_Card_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Load_Card_Button.Name = "Load_Card_Button";
            this.Load_Card_Button.Size = new System.Drawing.Size(103, 35);
            this.Load_Card_Button.TabIndex = 9;
            this.Load_Card_Button.Text = "Load Card Data";
            this.Load_Card_Button.UseVisualStyleBackColor = true;
            this.Load_Card_Button.Visible = false;
            this.Load_Card_Button.Click += new System.EventHandler(this.Load_Card_Button_Click);
            // 
            // Users_Panel
            // 
            this.Users_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Users_Panel.AutoScroll = true;
            this.Users_Panel.AutoSize = true;
            this.Users_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Users_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Users_Panel.ColumnCount = 3;
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Users_Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Users_Panel.ForeColor = System.Drawing.Color.Silver;
            this.Users_Panel.Location = new System.Drawing.Point(0, 94);
            this.Users_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Users_Panel.Name = "Users_Panel";
            this.Users_Panel.RowCount = 1;
            this.Users_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Users_Panel.Size = new System.Drawing.Size(730, 50);
            this.Users_Panel.TabIndex = 12;
            this.Users_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.users_panel);
            // 
            // user_first_name_sort
            // 
            this.user_first_name_sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_first_name_sort.FlatAppearance.BorderSize = 0;
            this.user_first_name_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_first_name_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_first_name_sort.ForeColor = System.Drawing.Color.Silver;
            this.user_first_name_sort.Location = new System.Drawing.Point(3, 3);
            this.user_first_name_sort.Margin = new System.Windows.Forms.Padding(2);
            this.user_first_name_sort.Name = "user_first_name_sort";
            this.user_first_name_sort.Size = new System.Drawing.Size(238, 38);
            this.user_first_name_sort.TabIndex = 0;
            this.user_first_name_sort.Text = "First Name";
            this.user_first_name_sort.UseVisualStyleBackColor = true;
            // 
            // user_last_name_sort
            // 
            this.user_last_name_sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_last_name_sort.FlatAppearance.BorderSize = 0;
            this.user_last_name_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_last_name_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_last_name_sort.ForeColor = System.Drawing.Color.Silver;
            this.user_last_name_sort.Location = new System.Drawing.Point(246, 3);
            this.user_last_name_sort.Margin = new System.Windows.Forms.Padding(2);
            this.user_last_name_sort.Name = "user_last_name_sort";
            this.user_last_name_sort.Size = new System.Drawing.Size(238, 38);
            this.user_last_name_sort.TabIndex = 1;
            this.user_last_name_sort.Text = "Last Name";
            this.user_last_name_sort.UseVisualStyleBackColor = true;
            // 
            // authority_sort_button
            // 
            this.authority_sort_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authority_sort_button.FlatAppearance.BorderSize = 0;
            this.authority_sort_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authority_sort_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authority_sort_button.ForeColor = System.Drawing.Color.Silver;
            this.authority_sort_button.Location = new System.Drawing.Point(489, 3);
            this.authority_sort_button.Margin = new System.Windows.Forms.Padding(2);
            this.authority_sort_button.Name = "authority_sort_button";
            this.authority_sort_button.Size = new System.Drawing.Size(238, 38);
            this.authority_sort_button.TabIndex = 15;
            this.authority_sort_button.Text = "Authority";
            this.authority_sort_button.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(11, 764);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(203, 19);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // progress_textbox
            // 
            this.progress_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progress_textbox.BackColor = System.Drawing.Color.SlateGray;
            this.progress_textbox.Location = new System.Drawing.Point(10, 699);
            this.progress_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.progress_textbox.Multiline = true;
            this.progress_textbox.Name = "progress_textbox";
            this.progress_textbox.Size = new System.Drawing.Size(204, 61);
            this.progress_textbox.TabIndex = 14;
            this.progress_textbox.Visible = false;
            // 
            // newUserButton
            // 
            this.newUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newUserButton.FlatAppearance.BorderSize = 0;
            this.newUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserButton.Location = new System.Drawing.Point(3, 3);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(355, 202);
            this.newUserButton.TabIndex = 17;
            this.newUserButton.Text = "Add User";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // dropUser
            // 
            this.dropUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropUser.FlatAppearance.BorderSize = 0;
            this.dropUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropUser.Location = new System.Drawing.Point(3, 419);
            this.dropUser.Name = "dropUser";
            this.dropUser.Size = new System.Drawing.Size(355, 202);
            this.dropUser.TabIndex = 18;
            this.dropUser.Text = "Delete User";
            this.dropUser.UseVisualStyleBackColor = true;
            this.dropUser.Click += new System.EventHandler(this.dropUser_Click);
            // 
            // editUserButton
            // 
            this.editUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editUserButton.FlatAppearance.BorderSize = 0;
            this.editUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUserButton.Location = new System.Drawing.Point(3, 211);
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(355, 202);
            this.editUserButton.TabIndex = 19;
            this.editUserButton.Text = "Edit User";
            this.editUserButton.UseVisualStyleBackColor = true;
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Silver;
            this.Header.Location = new System.Drawing.Point(3, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(724, 50);
            this.Header.TabIndex = 20;
            this.Header.Text = "Users";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // users_header_panel
            // 
            this.users_header_panel.AutoSize = true;
            this.users_header_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.users_header_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.users_header_panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.users_header_panel.ColumnCount = 3;
            this.users_header_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.users_header_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.users_header_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.users_header_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.users_header_panel.Controls.Add(this.user_last_name_sort, 1, 0);
            this.users_header_panel.Controls.Add(this.user_first_name_sort, 0, 0);
            this.users_header_panel.Controls.Add(this.authority_sort_button, 2, 0);
            this.users_header_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_header_panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.users_header_panel.Location = new System.Drawing.Point(0, 50);
            this.users_header_panel.Margin = new System.Windows.Forms.Padding(0);
            this.users_header_panel.Name = "users_header_panel";
            this.users_header_panel.RowCount = 1;
            this.users_header_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.users_header_panel.Size = new System.Drawing.Size(730, 44);
            this.users_header_panel.TabIndex = 22;
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.downloadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadLabel.ForeColor = System.Drawing.Color.Silver;
            this.downloadLabel.Location = new System.Drawing.Point(111, 206);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(514, 80);
            this.downloadLabel.TabIndex = 26;
            this.downloadLabel.Text = "Downloading Card Database\r\n(This may take several minutes)\r\n";
            this.downloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadLabel.Visible = false;
            // 
            // user_settings_buttons_panel
            // 
            this.user_settings_buttons_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_settings_buttons_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.user_settings_buttons_panel.Controls.Add(this.Buttons_Table);
            this.user_settings_buttons_panel.Location = new System.Drawing.Point(734, -1);
            this.user_settings_buttons_panel.Name = "user_settings_buttons_panel";
            this.user_settings_buttons_panel.Size = new System.Drawing.Size(365, 837);
            this.user_settings_buttons_panel.TabIndex = 27;
            // 
            // Buttons_Table
            // 
            this.Buttons_Table.ColumnCount = 1;
            this.Buttons_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Buttons_Table.Controls.Add(this.newUserButton, 0, 0);
            this.Buttons_Table.Controls.Add(this.editUserButton, 0, 1);
            this.Buttons_Table.Controls.Add(this.dropUser, 0, 2);
            this.Buttons_Table.Controls.Add(this.DefualtButton, 0, 3);
            this.Buttons_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Buttons_Table.Location = new System.Drawing.Point(0, 0);
            this.Buttons_Table.Name = "Buttons_Table";
            this.Buttons_Table.RowCount = 4;
            this.Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Buttons_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Buttons_Table.Size = new System.Drawing.Size(361, 833);
            this.Buttons_Table.TabIndex = 28;
            // 
            // user_table_panel
            // 
            this.user_table_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_table_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.user_table_panel.Controls.Add(this.Users_Left_Panel);
            this.user_table_panel.Location = new System.Drawing.Point(0, -1);
            this.user_table_panel.Name = "user_table_panel";
            this.user_table_panel.Size = new System.Drawing.Size(734, 833);
            this.user_table_panel.TabIndex = 28;
            // 
            // Users_Left_Panel
            // 
            this.Users_Left_Panel.ColumnCount = 1;
            this.Users_Left_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Users_Left_Panel.Controls.Add(this.users_header_panel, 0, 1);
            this.Users_Left_Panel.Controls.Add(this.Header, 0, 0);
            this.Users_Left_Panel.Controls.Add(this.Users_Panel, 0, 2);
            this.Users_Left_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Users_Left_Panel.Location = new System.Drawing.Point(0, 0);
            this.Users_Left_Panel.Name = "Users_Left_Panel";
            this.Users_Left_Panel.RowCount = 3;
            this.Users_Left_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Users_Left_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Users_Left_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Users_Left_Panel.Size = new System.Drawing.Size(730, 829);
            this.Users_Left_Panel.TabIndex = 29;
            // 
            // Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1098, 833);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.user_table_panel);
            this.Controls.Add(this.user_settings_buttons_panel);
            this.Controls.Add(this.progress_textbox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Load_Card_Button);
            this.Controls.Add(this.DeleteAllButton);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.Text = "TCGDigitizer - Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.users_header_panel.ResumeLayout(false);
            this.user_settings_buttons_panel.ResumeLayout(false);
            this.Buttons_Table.ResumeLayout(false);
            this.user_table_panel.ResumeLayout(false);
            this.Users_Left_Panel.ResumeLayout(false);
            this.Users_Left_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DefualtButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.Button Load_Card_Button;
        private System.Windows.Forms.TableLayoutPanel Users_Panel;
        private System.Windows.Forms.Button user_first_name_sort;
        private System.Windows.Forms.Button user_last_name_sort;
        private System.Windows.Forms.Button authority_sort_button;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox progress_textbox;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button dropUser;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.TableLayoutPanel users_header_panel;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Panel user_settings_buttons_panel;
        private System.Windows.Forms.TableLayoutPanel Buttons_Table;
        private System.Windows.Forms.Panel user_table_panel;
        private System.Windows.Forms.TableLayoutPanel Users_Left_Panel;
    }
}