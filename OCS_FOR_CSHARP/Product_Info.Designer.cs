namespace OCS_FOR_CSHARP
{
    partial class Product_Info
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
            this.ContactText = new System.Windows.Forms.TextBox();
            this.login_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContactText
            // 
            this.ContactText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ContactText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ContactText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContactText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactText.ForeColor = System.Drawing.Color.Silver;
            this.ContactText.Location = new System.Drawing.Point(41, 183);
            this.ContactText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ContactText.MaximumSize = new System.Drawing.Size(667, 369);
            this.ContactText.Multiline = true;
            this.ContactText.Name = "ContactText";
            this.ContactText.ReadOnly = true;
            this.ContactText.Size = new System.Drawing.Size(419, 288);
            this.ContactText.TabIndex = 18;
            this.ContactText.Text = "TCG Digitizer Development Team\r\n-Brodie Boldt\r\n-Chris Cooper\r\n-Ryan Fox\r\n-Jared P" +
    "arks";
            this.ContactText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ContactText.WordWrap = false;
            // 
            // login_label
            // 
            this.login_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_label.ForeColor = System.Drawing.Color.Silver;
            this.login_label.Location = new System.Drawing.Point(48, 105);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(403, 52);
            this.login_label.TabIndex = 32;
            this.login_label.Text = "Product Information";
            // 
            // Product_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(495, 554);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.ContactText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Product_Info";
            this.Text = "Product_Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ContactText;
        private System.Windows.Forms.Label login_label;
    }
}