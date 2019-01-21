namespace OCS_FOR_CSHARP
{
    partial class Form1
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
            this.button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Picture_Box = new System.Windows.Forms.PictureBox();
            this.Stop_Video_Button = new System.Windows.Forms.Button();
            this.Start_Video__Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(690, 14);
            this.button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(144, 54);
            this.button.TabIndex = 0;
            this.button.Text = "Open";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.open_button);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(690, 92);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(511, 302);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Take Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Take_Picture_Button_Click);
            // 
            // Picture_Box
            // 
            this.Picture_Box.BackColor = System.Drawing.SystemColors.Window;
            this.Picture_Box.Location = new System.Drawing.Point(23, 92);
            this.Picture_Box.Name = "Picture_Box";
            this.Picture_Box.Size = new System.Drawing.Size(511, 302);
            this.Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture_Box.TabIndex = 3;
            this.Picture_Box.TabStop = false;
            this.Picture_Box.Click += new System.EventHandler(this.Webcam_Feed_Box);
            // 
            // Stop_Video_Button
            // 
            this.Stop_Video_Button.Location = new System.Drawing.Point(227, 14);
            this.Stop_Video_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Stop_Video_Button.Name = "Stop_Video_Button";
            this.Stop_Video_Button.Size = new System.Drawing.Size(144, 54);
            this.Stop_Video_Button.TabIndex = 4;
            this.Stop_Video_Button.Text = "Stop Webcam";
            this.Stop_Video_Button.UseVisualStyleBackColor = true;
            this.Stop_Video_Button.Click += new System.EventHandler(this.Stop_Video_Button_Click);
            // 
            // Start_Video__Button
            // 
            this.Start_Video__Button.Location = new System.Drawing.Point(63, 14);
            this.Start_Video__Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Start_Video__Button.Name = "Start_Video__Button";
            this.Start_Video__Button.Size = new System.Drawing.Size(144, 54);
            this.Start_Video__Button.TabIndex = 5;
            this.Start_Video__Button.Text = "Start Webcam";
            this.Start_Video__Button.UseVisualStyleBackColor = true;
            this.Start_Video__Button.Click += new System.EventHandler(this.Start_Video_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 425);
            this.Controls.Add(this.Start_Video__Button);
            this.Controls.Add(this.Stop_Video_Button);
            this.Controls.Add(this.Picture_Box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Picture_Box;
        private System.Windows.Forms.Button Stop_Video_Button;
        private System.Windows.Forms.Button Start_Video__Button;
    }
}

