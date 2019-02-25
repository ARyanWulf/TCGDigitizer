namespace OCS_FOR_CSHARP
{
    partial class Create_User
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
            this.fname_label = new System.Windows.Forms.Label();
            this.lname_label = new System.Windows.Forms.Label();
            this.privilege_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.passwordconf_label = new System.Windows.Forms.Label();
            this.fname_textbox = new System.Windows.Forms.TextBox();
            this.lname_textbox = new System.Windows.Forms.TextBox();
            this.passconf_textbox = new System.Windows.Forms.TextBox();
            this.pass_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.privilege_dropdown = new System.Windows.Forms.ComboBox();
            this.error_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fname_label
            // 
            this.fname_label.AutoSize = true;
            this.fname_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname_label.Location = new System.Drawing.Point(24, 118);
            this.fname_label.Name = "fname_label";
            this.fname_label.Size = new System.Drawing.Size(106, 25);
            this.fname_label.TabIndex = 0;
            this.fname_label.Text = "First Name";
            // 
            // lname_label
            // 
            this.lname_label.AutoSize = true;
            this.lname_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname_label.Location = new System.Drawing.Point(24, 184);
            this.lname_label.Name = "lname_label";
            this.lname_label.Size = new System.Drawing.Size(106, 25);
            this.lname_label.TabIndex = 1;
            this.lname_label.Text = "Last Name";
            // 
            // privilege_label
            // 
            this.privilege_label.AutoSize = true;
            this.privilege_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privilege_label.Location = new System.Drawing.Point(24, 318);
            this.privilege_label.Name = "privilege_label";
            this.privilege_label.Size = new System.Drawing.Size(138, 25);
            this.privilege_label.TabIndex = 2;
            this.privilege_label.Text = "Privilege Level";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(424, 118);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(102, 25);
            this.username_label.TabIndex = 3;
            this.username_label.Text = "Username";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(424, 182);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(98, 25);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Password";
            // 
            // passwordconf_label
            // 
            this.passwordconf_label.AutoSize = true;
            this.passwordconf_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordconf_label.Location = new System.Drawing.Point(424, 245);
            this.passwordconf_label.Name = "passwordconf_label";
            this.passwordconf_label.Size = new System.Drawing.Size(80, 25);
            this.passwordconf_label.TabIndex = 5;
            this.passwordconf_label.Text = "Confirm";
            // 
            // fname_textbox
            // 
            this.fname_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname_textbox.Location = new System.Drawing.Point(158, 115);
            this.fname_textbox.Name = "fname_textbox";
            this.fname_textbox.Size = new System.Drawing.Size(217, 30);
            this.fname_textbox.TabIndex = 6;
            this.fname_textbox.TextChanged += new System.EventHandler(this.fname_textbox_TextChanged);
            // 
            // lname_textbox
            // 
            this.lname_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname_textbox.Location = new System.Drawing.Point(158, 179);
            this.lname_textbox.Name = "lname_textbox";
            this.lname_textbox.Size = new System.Drawing.Size(217, 30);
            this.lname_textbox.TabIndex = 7;
            this.lname_textbox.TextChanged += new System.EventHandler(this.lname_textbox_TextChanged);
            // 
            // passconf_textbox
            // 
            this.passconf_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passconf_textbox.Location = new System.Drawing.Point(558, 240);
            this.passconf_textbox.Name = "passconf_textbox";
            this.passconf_textbox.Size = new System.Drawing.Size(217, 30);
            this.passconf_textbox.TabIndex = 11;
            this.passconf_textbox.TextChanged += new System.EventHandler(this.passconf_textbox_TextChanged);
            // 
            // pass_textbox
            // 
            this.pass_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_textbox.Location = new System.Drawing.Point(558, 177);
            this.pass_textbox.Name = "pass_textbox";
            this.pass_textbox.Size = new System.Drawing.Size(217, 30);
            this.pass_textbox.TabIndex = 10;
            this.pass_textbox.TextChanged += new System.EventHandler(this.pass_textbox_TextChanged);
            // 
            // username_textbox
            // 
            this.username_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_textbox.Location = new System.Drawing.Point(558, 113);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(217, 30);
            this.username_textbox.TabIndex = 9;
            this.username_textbox.TextChanged += new System.EventHandler(this.username_textbox_TextChanged);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(663, 391);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(112, 35);
            this.Cancel_Button.TabIndex = 13;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(544, 391);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(112, 35);
            this.OK_Button.TabIndex = 12;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // privilege_dropdown
            // 
            this.privilege_dropdown.BackColor = System.Drawing.SystemColors.Window;
            this.privilege_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.privilege_dropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privilege_dropdown.FormattingEnabled = true;
            this.privilege_dropdown.Items.AddRange(new object[] {
            "1 - Admin       (all usage rights, can change owner login)",
            "2 - Owner       (all usage rights, can change all logins below)",
            "3 - Manager    (all usage rights, can change employee logins)",
            "4 - Employee  (limited usage rights, no login changes except own)",
            "5 - Read Only  (view only rights, no login changes)"});
            this.privilege_dropdown.Location = new System.Drawing.Point(183, 310);
            this.privilege_dropdown.Name = "privilege_dropdown";
            this.privilege_dropdown.Size = new System.Drawing.Size(592, 33);
            this.privilege_dropdown.TabIndex = 14;
            this.privilege_dropdown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // error_textbox
            // 
            this.error_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.error_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error_textbox.Location = new System.Drawing.Point(29, 5);
            this.error_textbox.Multiline = true;
            this.error_textbox.Name = "error_textbox";
            this.error_textbox.ReadOnly = true;
            this.error_textbox.Size = new System.Drawing.Size(746, 104);
            this.error_textbox.TabIndex = 15;
            this.error_textbox.Visible = false;
            this.error_textbox.TextChanged += new System.EventHandler(this.error_textbox_TextChanged);
            // 
            // Create_User
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(812, 503);
            this.Controls.Add(this.error_textbox);
            this.Controls.Add(this.privilege_dropdown);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.passconf_textbox);
            this.Controls.Add(this.pass_textbox);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.lname_textbox);
            this.Controls.Add(this.fname_textbox);
            this.Controls.Add(this.passwordconf_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.privilege_label);
            this.Controls.Add(this.lname_label);
            this.Controls.Add(this.fname_label);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Create_User";
            this.Text = "User Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fname_label;
        private System.Windows.Forms.Label lname_label;
        private System.Windows.Forms.Label privilege_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label passwordconf_label;
        private System.Windows.Forms.TextBox fname_textbox;
        private System.Windows.Forms.TextBox lname_textbox;
        private System.Windows.Forms.TextBox passconf_textbox;
        private System.Windows.Forms.TextBox pass_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.ComboBox privilege_dropdown;
        private System.Windows.Forms.TextBox error_textbox;
    }
}