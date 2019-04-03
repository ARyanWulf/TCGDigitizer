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
            this.Load_Card_Button = new System.Windows.Forms.Button();
            this.Users_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.user_first_name_sort = new System.Windows.Forms.Button();
            this.user_last_name_sort = new System.Windows.Forms.Button();
            this.authority_sort_button = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progress_textbox = new System.Windows.Forms.TextBox();
            this.newUserButton = new System.Windows.Forms.Button();
            this.dropUser = new System.Windows.Forms.Button();
            this.editUserButton = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.user_text_box = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Location = new System.Drawing.Point(577, 465);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(2);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(96, 35);
            this.QuitButton.TabIndex = 5;
            this.QuitButton.Text = "Back";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // DefualtButton
            // 
            this.DefualtButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DefualtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DefualtButton.Location = new System.Drawing.Point(470, 465);
            this.DefualtButton.Margin = new System.Windows.Forms.Padding(2);
            this.DefualtButton.Name = "DefualtButton";
            this.DefualtButton.Size = new System.Drawing.Size(103, 35);
            this.DefualtButton.TabIndex = 6;
            this.DefualtButton.Text = "Restore Defaults";
            this.DefualtButton.UseVisualStyleBackColor = true;
            this.DefualtButton.Click += new System.EventHandler(this.DefualtButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.DeleteAllButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeleteAllButton.Enabled = false;
            this.DeleteAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAllButton.Location = new System.Drawing.Point(11, 465);
            this.DeleteAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(96, 35);
            this.DeleteAllButton.TabIndex = 7;
            this.DeleteAllButton.Text = "Erase Inventory";
            this.DeleteAllButton.UseVisualStyleBackColor = false;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // Load_Card_Button
            // 
            this.Load_Card_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Load_Card_Button.Location = new System.Drawing.Point(111, 465);
            this.Load_Card_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Load_Card_Button.Name = "Load_Card_Button";
            this.Load_Card_Button.Size = new System.Drawing.Size(103, 35);
            this.Load_Card_Button.TabIndex = 9;
            this.Load_Card_Button.Text = "Load Card Data";
            this.Load_Card_Button.UseVisualStyleBackColor = true;
            this.Load_Card_Button.Click += new System.EventHandler(this.Load_Card_Button_Click);
            // 
            // Users_Panel
            // 
            this.Users_Panel.AutoSize = true;
            this.Users_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Users_Panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Users_Panel.ColumnCount = 4;
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.Users_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Users_Panel.ForeColor = System.Drawing.Color.Silver;
            this.Users_Panel.Location = new System.Drawing.Point(24, 129);
            this.Users_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Users_Panel.MaximumSize = new System.Drawing.Size(680, 0);
            this.Users_Panel.MinimumSize = new System.Drawing.Size(680, 0);
            this.Users_Panel.Name = "Users_Panel";
            this.Users_Panel.RowCount = 1;
            this.Users_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Users_Panel.Size = new System.Drawing.Size(680, 2);
            this.Users_Panel.TabIndex = 12;
            this.Users_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.users_panel);
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectAllCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectAllCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectAllCheckBox.Location = new System.Drawing.Point(3, 3);
            this.selectAllCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(26, 27);
            this.selectAllCheckBox.TabIndex = 17;
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // user_first_name_sort
            // 
            this.user_first_name_sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_first_name_sort.FlatAppearance.BorderSize = 0;
            this.user_first_name_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_first_name_sort.ForeColor = System.Drawing.Color.Silver;
            this.user_first_name_sort.Location = new System.Drawing.Point(34, 3);
            this.user_first_name_sort.Margin = new System.Windows.Forms.Padding(2);
            this.user_first_name_sort.Name = "user_first_name_sort";
            this.user_first_name_sort.Size = new System.Drawing.Size(276, 27);
            this.user_first_name_sort.TabIndex = 0;
            this.user_first_name_sort.Text = "First Name";
            this.user_first_name_sort.UseVisualStyleBackColor = true;
            // 
            // user_last_name_sort
            // 
            this.user_last_name_sort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_last_name_sort.FlatAppearance.BorderSize = 0;
            this.user_last_name_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_last_name_sort.ForeColor = System.Drawing.Color.Silver;
            this.user_last_name_sort.Location = new System.Drawing.Point(315, 3);
            this.user_last_name_sort.Margin = new System.Windows.Forms.Padding(2);
            this.user_last_name_sort.Name = "user_last_name_sort";
            this.user_last_name_sort.Size = new System.Drawing.Size(276, 27);
            this.user_last_name_sort.TabIndex = 1;
            this.user_last_name_sort.Text = "Last Name";
            this.user_last_name_sort.UseVisualStyleBackColor = true;
            // 
            // authority_sort_button
            // 
            this.authority_sort_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authority_sort_button.FlatAppearance.BorderSize = 0;
            this.authority_sort_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authority_sort_button.ForeColor = System.Drawing.Color.Silver;
            this.authority_sort_button.Location = new System.Drawing.Point(596, 3);
            this.authority_sort_button.Margin = new System.Windows.Forms.Padding(2);
            this.authority_sort_button.Name = "authority_sort_button";
            this.authority_sort_button.Size = new System.Drawing.Size(81, 27);
            this.authority_sort_button.TabIndex = 15;
            this.authority_sort_button.Text = "Authority";
            this.authority_sort_button.UseVisualStyleBackColor = true;
            this.authority_sort_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 442);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(203, 19);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Visible = false;
            // 
            // progress_textbox
            // 
            this.progress_textbox.BackColor = System.Drawing.Color.SlateGray;
            this.progress_textbox.Location = new System.Drawing.Point(10, 377);
            this.progress_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.progress_textbox.Multiline = true;
            this.progress_textbox.Name = "progress_textbox";
            this.progress_textbox.Size = new System.Drawing.Size(204, 61);
            this.progress_textbox.TabIndex = 14;
            this.progress_textbox.Visible = false;
            // 
            // newUserButton
            // 
            this.newUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newUserButton.Location = new System.Drawing.Point(219, 410);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(144, 28);
            this.newUserButton.TabIndex = 17;
            this.newUserButton.Text = "Add User";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // dropUser
            // 
            this.dropUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropUser.Location = new System.Drawing.Point(369, 410);
            this.dropUser.Name = "dropUser";
            this.dropUser.Size = new System.Drawing.Size(148, 28);
            this.dropUser.TabIndex = 18;
            this.dropUser.Text = "Delete User";
            this.dropUser.UseVisualStyleBackColor = true;
            // 
            // editUserButton
            // 
            this.editUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editUserButton.Location = new System.Drawing.Point(523, 410);
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(163, 28);
            this.editUserButton.TabIndex = 19;
            this.editUserButton.Text = "Edit User";
            this.editUserButton.UseVisualStyleBackColor = true;
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Silver;
            this.Header.Location = new System.Drawing.Point(20, 18);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(153, 42);
            this.Header.TabIndex = 20;
            this.Header.Text = "Settings";
            // 
            // user_text_box
            // 
            this.user_text_box.AutoSize = true;
            this.user_text_box.Location = new System.Drawing.Point(21, 80);
            this.user_text_box.Name = "user_text_box";
            this.user_text_box.Size = new System.Drawing.Size(34, 13);
            this.user_text_box.TabIndex = 21;
            this.user_text_box.Text = "Users";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.selectAllCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.user_last_name_sort, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.user_first_name_sort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.authority_sort_button, 3, 0);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 96);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 33);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(713, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.user_text_box);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.editUserButton);
            this.Controls.Add(this.dropUser);
            this.Controls.Add(this.newUserButton);
            this.Controls.Add(this.progress_textbox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Users_Panel);
            this.Controls.Add(this.Load_Card_Button);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.DefualtButton);
            this.Controls.Add(this.QuitButton);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.Text = "TCGDigitizer - Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button DefualtButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.Button Load_Card_Button;
        private System.Windows.Forms.TableLayoutPanel Users_Panel;
        private System.Windows.Forms.Button user_first_name_sort;
        private System.Windows.Forms.Button user_last_name_sort;
        private System.Windows.Forms.Button authority_sort_button;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox progress_textbox;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button dropUser;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Label user_text_box;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}