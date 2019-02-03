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
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.DefualtButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.DeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // UserTextBox
            // 
            this.UserTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.UserTextBox.Location = new System.Drawing.Point(45, 12);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.ReadOnly = true;
            this.UserTextBox.Size = new System.Drawing.Size(305, 46);
            this.UserTextBox.TabIndex = 0;
            this.UserTextBox.Text = "User Settings";
            this.UserTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserTextBox.WordWrap = false;
            this.UserTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // QuitButton
            // 
            this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButton.Location = new System.Drawing.Point(206, 540);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(144, 54);
            this.QuitButton.TabIndex = 5;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // DefualtButton
            // 
            this.DefualtButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DefualtButton.Location = new System.Drawing.Point(45, 540);
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
            this.DeleteAllButton.Location = new System.Drawing.Point(45, 465);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(305, 54);
            this.DeleteAllButton.TabIndex = 7;
            this.DeleteAllButton.Text = "Delete all data\r\n";
            this.DeleteAllButton.UseVisualStyleBackColor = false;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // DeleteCheckbox
            // 
            this.DeleteCheckbox.AutoSize = true;
            this.DeleteCheckbox.Location = new System.Drawing.Point(369, 481);
            this.DeleteCheckbox.Name = "DeleteCheckbox";
            this.DeleteCheckbox.Size = new System.Drawing.Size(22, 21);
            this.DeleteCheckbox.TabIndex = 8;
            this.DeleteCheckbox.UseVisualStyleBackColor = true;
            this.DeleteCheckbox.CheckedChanged += new System.EventHandler(this.DeleteCheckbox_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.DeleteCheckbox);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.DefualtButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.UserTextBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button DefualtButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.CheckBox DeleteCheckbox;
    }
}