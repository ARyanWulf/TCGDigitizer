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
            this.Cam_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Stop_Video_Button = new System.Windows.Forms.Button();
            this.Start_Video__Button = new System.Windows.Forms.Button();
            this.Display_Picture_Box = new System.Windows.Forms.PictureBox();
            this.Preview_Label = new System.Windows.Forms.Label();
            this.Card_Boarder = new System.Windows.Forms.PictureBox();
            this.Name_Header_Pic_Box = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Output_Label = new System.Windows.Forms.Label();
            this.Search_Card_Button = new System.Windows.Forms.Button();
            this.Manual_Entry_Toggle = new System.Windows.Forms.CheckBox();
            this.Card_Table_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Date_Button = new System.Windows.Forms.Button();
            this.Mana_Button = new System.Windows.Forms.Button();
            this.Number_Button = new System.Windows.Forms.Button();
            this.Expansion_Button = new System.Windows.Forms.Button();
            this.Type_Button = new System.Windows.Forms.Button();
            this.Name_Button = new System.Windows.Forms.Button();
            this.Inventory_Checkbox = new System.Windows.Forms.CheckBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Cam_Picture_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Display_Picture_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Card_Boarder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Name_Header_Pic_Box)).BeginInit();
            this.Card_Table_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(342, 9);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(96, 35);
            this.button.TabIndex = 0;
            this.button.Text = "Open";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Open_Button);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Location = new System.Drawing.Point(483, 60);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(316, 187);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.Tess_TextBox);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Take Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Take_Picture_Button_Click);
            // 
            // Cam_Picture_Box
            // 
            this.Cam_Picture_Box.BackColor = System.Drawing.SystemColors.Window;
            this.Cam_Picture_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cam_Picture_Box.Location = new System.Drawing.Point(15, 60);
            this.Cam_Picture_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Cam_Picture_Box.Name = "Cam_Picture_Box";
            this.Cam_Picture_Box.Size = new System.Drawing.Size(316, 186);
            this.Cam_Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Cam_Picture_Box.TabIndex = 3;
            this.Cam_Picture_Box.TabStop = false;
            this.Cam_Picture_Box.Click += new System.EventHandler(this.Webcam_Feed_Box);
            // 
            // Stop_Video_Button
            // 
            this.Stop_Video_Button.Location = new System.Drawing.Point(124, 9);
            this.Stop_Video_Button.Name = "Stop_Video_Button";
            this.Stop_Video_Button.Size = new System.Drawing.Size(96, 35);
            this.Stop_Video_Button.TabIndex = 4;
            this.Stop_Video_Button.Text = "Stop Webcam";
            this.Stop_Video_Button.UseVisualStyleBackColor = true;
            this.Stop_Video_Button.Click += new System.EventHandler(this.Stop_Video_Button_Click);
            // 
            // Start_Video__Button
            // 
            this.Start_Video__Button.Location = new System.Drawing.Point(15, 9);
            this.Start_Video__Button.Name = "Start_Video__Button";
            this.Start_Video__Button.Size = new System.Drawing.Size(96, 35);
            this.Start_Video__Button.TabIndex = 5;
            this.Start_Video__Button.Text = "Start Webcam";
            this.Start_Video__Button.UseVisualStyleBackColor = true;
            this.Start_Video__Button.Click += new System.EventHandler(this.Start_Video_Button_Click);
            // 
            // Display_Picture_Box
            // 
            this.Display_Picture_Box.BackColor = System.Drawing.SystemColors.Window;
            this.Display_Picture_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Display_Picture_Box.Location = new System.Drawing.Point(349, 60);
            this.Display_Picture_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Display_Picture_Box.Name = "Display_Picture_Box";
            this.Display_Picture_Box.Size = new System.Drawing.Size(119, 170);
            this.Display_Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Display_Picture_Box.TabIndex = 6;
            this.Display_Picture_Box.TabStop = false;
            this.Display_Picture_Box.Click += new System.EventHandler(this.Display_Picture_Box_Click);
            // 
            // Preview_Label
            // 
            this.Preview_Label.AutoSize = true;
            this.Preview_Label.Location = new System.Drawing.Point(346, 44);
            this.Preview_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Preview_Label.Name = "Preview_Label";
            this.Preview_Label.Size = new System.Drawing.Size(77, 13);
            this.Preview_Label.TabIndex = 7;
            this.Preview_Label.Text = "Image Preview";
            // 
            // Card_Boarder
            // 
            this.Card_Boarder.BackColor = System.Drawing.Color.Transparent;
            this.Card_Boarder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Card_Boarder.Location = new System.Drawing.Point(44, 60);
            this.Card_Boarder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.Card_Boarder.Name = "Card_Boarder";
            this.Card_Boarder.Size = new System.Drawing.Size(256, 186);
            this.Card_Boarder.TabIndex = 8;
            this.Card_Boarder.TabStop = false;
            this.Card_Boarder.Click += new System.EventHandler(this.Card_Boarder_Click);
            // 
            // Name_Header_Pic_Box
            // 
            this.Name_Header_Pic_Box.BackColor = System.Drawing.SystemColors.Window;
            this.Name_Header_Pic_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name_Header_Pic_Box.Location = new System.Drawing.Point(483, 169);
            this.Name_Header_Pic_Box.Margin = new System.Windows.Forms.Padding(2);
            this.Name_Header_Pic_Box.Name = "Name_Header_Pic_Box";
            this.Name_Header_Pic_Box.Size = new System.Drawing.Size(315, 78);
            this.Name_Header_Pic_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Name_Header_Pic_Box.TabIndex = 9;
            this.Name_Header_Pic_Box.TabStop = false;
            this.Name_Header_Pic_Box.Click += new System.EventHandler(this.Name_Header_Pic_Box_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 731);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 36);
            this.button2.TabIndex = 10;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Output_Label
            // 
            this.Output_Label.AutoSize = true;
            this.Output_Label.Location = new System.Drawing.Point(480, 44);
            this.Output_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(39, 13);
            this.Output_Label.TabIndex = 12;
            this.Output_Label.Text = "Output";
            this.Output_Label.Click += new System.EventHandler(this.Output_Label_Click);
            // 
            // Search_Card_Button
            // 
            this.Search_Card_Button.Enabled = false;
            this.Search_Card_Button.Location = new System.Drawing.Point(505, 253);
            this.Search_Card_Button.Name = "Search_Card_Button";
            this.Search_Card_Button.Size = new System.Drawing.Size(100, 36);
            this.Search_Card_Button.TabIndex = 13;
            this.Search_Card_Button.Text = "Search for card";
            this.Search_Card_Button.UseVisualStyleBackColor = true;
            this.Search_Card_Button.Visible = false;
            this.Search_Card_Button.Click += new System.EventHandler(this.Search_Card_Button_Click);
            // 
            // Manual_Entry_Toggle
            // 
            this.Manual_Entry_Toggle.AutoSize = true;
            this.Manual_Entry_Toggle.Enabled = false;
            this.Manual_Entry_Toggle.Location = new System.Drawing.Point(712, 39);
            this.Manual_Entry_Toggle.Margin = new System.Windows.Forms.Padding(2);
            this.Manual_Entry_Toggle.Name = "Manual_Entry_Toggle";
            this.Manual_Entry_Toggle.Size = new System.Drawing.Size(88, 17);
            this.Manual_Entry_Toggle.TabIndex = 14;
            this.Manual_Entry_Toggle.Text = "Manual Entry";
            this.Manual_Entry_Toggle.UseVisualStyleBackColor = true;
            this.Manual_Entry_Toggle.Visible = false;
            this.Manual_Entry_Toggle.CheckedChanged += new System.EventHandler(this.Manual_Entry_Toggle_CheckedChanged);
            // 
            // Card_Table_Panel
            // 
            this.Card_Table_Panel.AutoScroll = true;
            this.Card_Table_Panel.AutoSize = true;
            this.Card_Table_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Card_Table_Panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.Card_Table_Panel.ColumnCount = 7;
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.Card_Table_Panel.Controls.Add(this.Date_Button, 6, 0);
            this.Card_Table_Panel.Controls.Add(this.Mana_Button, 5, 0);
            this.Card_Table_Panel.Controls.Add(this.Number_Button, 4, 0);
            this.Card_Table_Panel.Controls.Add(this.Expansion_Button, 3, 0);
            this.Card_Table_Panel.Controls.Add(this.Type_Button, 2, 0);
            this.Card_Table_Panel.Controls.Add(this.Name_Button, 1, 0);
            this.Card_Table_Panel.Controls.Add(this.Inventory_Checkbox, 0, 0);
            this.Card_Table_Panel.Location = new System.Drawing.Point(33, 307);
            this.Card_Table_Panel.MaximumSize = new System.Drawing.Size(750, 400);
            this.Card_Table_Panel.Name = "Card_Table_Panel";
            this.Card_Table_Panel.RowCount = 1;
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.Card_Table_Panel.Size = new System.Drawing.Size(750, 42);
            this.Card_Table_Panel.TabIndex = 18;
            // 
            // Date_Button
            // 
            this.Date_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date_Button.Location = new System.Drawing.Point(661, 5);
            this.Date_Button.Name = "Date_Button";
            this.Date_Button.Size = new System.Drawing.Size(84, 32);
            this.Date_Button.TabIndex = 12;
            this.Date_Button.Text = "Date";
            this.Date_Button.UseVisualStyleBackColor = true;
            // 
            // Mana_Button
            // 
            this.Mana_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mana_Button.Location = new System.Drawing.Point(571, 5);
            this.Mana_Button.Name = "Mana_Button";
            this.Mana_Button.Size = new System.Drawing.Size(82, 32);
            this.Mana_Button.TabIndex = 11;
            this.Mana_Button.Text = "Mana";
            this.Mana_Button.UseVisualStyleBackColor = true;
            // 
            // Number_Button
            // 
            this.Number_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Number_Button.Location = new System.Drawing.Point(439, 5);
            this.Number_Button.Name = "Number_Button";
            this.Number_Button.Size = new System.Drawing.Size(124, 32);
            this.Number_Button.TabIndex = 10;
            this.Number_Button.Text = "Number";
            this.Number_Button.UseVisualStyleBackColor = true;
            // 
            // Expansion_Button
            // 
            this.Expansion_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Expansion_Button.Location = new System.Drawing.Point(307, 5);
            this.Expansion_Button.Name = "Expansion_Button";
            this.Expansion_Button.Size = new System.Drawing.Size(124, 32);
            this.Expansion_Button.TabIndex = 9;
            this.Expansion_Button.Text = "Expansion";
            this.Expansion_Button.UseVisualStyleBackColor = true;
            // 
            // Type_Button
            // 
            this.Type_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Type_Button.Location = new System.Drawing.Point(175, 5);
            this.Type_Button.Name = "Type_Button";
            this.Type_Button.Size = new System.Drawing.Size(124, 32);
            this.Type_Button.TabIndex = 8;
            this.Type_Button.Text = "Type";
            this.Type_Button.UseVisualStyleBackColor = true;
            // 
            // Name_Button
            // 
            this.Name_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_Button.Location = new System.Drawing.Point(43, 5);
            this.Name_Button.Name = "Name_Button";
            this.Name_Button.Size = new System.Drawing.Size(124, 32);
            this.Name_Button.TabIndex = 7;
            this.Name_Button.Text = "Name";
            this.Name_Button.UseVisualStyleBackColor = true;
            // 
            // Inventory_Checkbox
            // 
            this.Inventory_Checkbox.AutoSize = true;
            this.Inventory_Checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Inventory_Checkbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inventory_Checkbox.Location = new System.Drawing.Point(5, 5);
            this.Inventory_Checkbox.Name = "Inventory_Checkbox";
            this.Inventory_Checkbox.Size = new System.Drawing.Size(30, 32);
            this.Inventory_Checkbox.TabIndex = 1;
            this.Inventory_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(684, 731);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(99, 36);
            this.Cancel_Button.TabIndex = 17;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 790);
            this.Controls.Add(this.Card_Table_Panel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Manual_Entry_Toggle);
            this.Controls.Add(this.Search_Card_Button);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Name_Header_Pic_Box);
            this.Controls.Add(this.Card_Boarder);
            this.Controls.Add(this.Preview_Label);
            this.Controls.Add(this.Display_Picture_Box);
            this.Controls.Add(this.Start_Video__Button);
            this.Controls.Add(this.Stop_Video_Button);
            this.Controls.Add(this.Cam_Picture_Box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "TCG Digitizer - Get Image";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCardWithCondition);
            ((System.ComponentModel.ISupportInitialize)(this.Cam_Picture_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Display_Picture_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Card_Boarder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Name_Header_Pic_Box)).EndInit();
            this.Card_Table_Panel.ResumeLayout(false);
            this.Card_Table_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Cam_Picture_Box;
        private System.Windows.Forms.Button Stop_Video_Button;
        private System.Windows.Forms.Button Start_Video__Button;
        public System.Windows.Forms.PictureBox Display_Picture_Box;
        private System.Windows.Forms.Label Preview_Label;
        private System.Windows.Forms.PictureBox Card_Boarder;
        private System.Windows.Forms.PictureBox Name_Header_Pic_Box;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Output_Label;
        private System.Windows.Forms.Button Search_Card_Button;
        private System.Windows.Forms.CheckBox Manual_Entry_Toggle;
        private System.Windows.Forms.TableLayoutPanel Card_Table_Panel;
        private System.Windows.Forms.Button Date_Button;
        private System.Windows.Forms.Button Mana_Button;
        private System.Windows.Forms.Button Number_Button;
        private System.Windows.Forms.Button Expansion_Button;
        private System.Windows.Forms.Button Type_Button;
        private System.Windows.Forms.Button Name_Button;
        private System.Windows.Forms.CheckBox Inventory_Checkbox;
        private System.Windows.Forms.Button Cancel_Button;
    }
}

