﻿namespace OCS_FOR_CSHARP
{
    partial class Edit_Card_Form
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Card_Name_Label = new System.Windows.Forms.Label();
            this.Card_Type_Label = new System.Windows.Forms.Label();
            this.Card_Additional_Label = new System.Windows.Forms.Label();
            this.Card_Mana_Cost_Label = new System.Windows.Forms.Label();
            this.Card_Expansion_Label = new System.Windows.Forms.Label();
            this.Card_Description_Label = new System.Windows.Forms.Label();
            this.Card_Flavor_Text_Label = new System.Windows.Forms.Label();
            this.Card_Power_Label = new System.Windows.Forms.Label();
            this.Card_Toughness_Label = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Card_Additional_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Type_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Toughness_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Power_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Flavor_Text_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Description_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Expansion_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Mana_Cost_TextBox = new System.Windows.Forms.TextBox();
            this.Card_Nmbr_Label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Name_Textbox = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(561, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scan Card";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Scan_Card_Button);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(567, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Save_Button);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(562, 317);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.Cancel_Button);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(57, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Card_Display_PictureBox);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(129, 408);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Foil";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.Click += new System.EventHandler(this.Foil_CheckBox);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SlateGray;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.Silver;
            this.textBox1.Location = new System.Drawing.Point(57, 452);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(180, 80);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(53, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Location Information:";
            this.label2.Visible = false;
            // 
            // Card_Name_Label
            // 
            this.Card_Name_Label.AutoSize = true;
            this.Card_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Name_Label.Location = new System.Drawing.Point(256, 133);
            this.Card_Name_Label.Name = "Card_Name_Label";
            this.Card_Name_Label.Size = new System.Drawing.Size(55, 20);
            this.Card_Name_Label.TabIndex = 8;
            this.Card_Name_Label.Text = "Name:";
            // 
            // Card_Type_Label
            // 
            this.Card_Type_Label.AutoSize = true;
            this.Card_Type_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Type_Label.Location = new System.Drawing.Point(256, 165);
            this.Card_Type_Label.Name = "Card_Type_Label";
            this.Card_Type_Label.Size = new System.Drawing.Size(47, 20);
            this.Card_Type_Label.TabIndex = 9;
            this.Card_Type_Label.Text = "Type:";
            // 
            // Card_Additional_Label
            // 
            this.Card_Additional_Label.AutoSize = true;
            this.Card_Additional_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Additional_Label.Location = new System.Drawing.Point(258, 196);
            this.Card_Additional_Label.Name = "Card_Additional_Label";
            this.Card_Additional_Label.Size = new System.Drawing.Size(81, 20);
            this.Card_Additional_Label.TabIndex = 10;
            this.Card_Additional_Label.Text = "-SubType:";
            // 
            // Card_Mana_Cost_Label
            // 
            this.Card_Mana_Cost_Label.AutoSize = true;
            this.Card_Mana_Cost_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Mana_Cost_Label.Location = new System.Drawing.Point(256, 223);
            this.Card_Mana_Cost_Label.Name = "Card_Mana_Cost_Label";
            this.Card_Mana_Cost_Label.Size = new System.Drawing.Size(90, 20);
            this.Card_Mana_Cost_Label.TabIndex = 11;
            this.Card_Mana_Cost_Label.Text = "Mana Cost:";
            // 
            // Card_Expansion_Label
            // 
            this.Card_Expansion_Label.AutoSize = true;
            this.Card_Expansion_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Expansion_Label.Location = new System.Drawing.Point(256, 253);
            this.Card_Expansion_Label.Name = "Card_Expansion_Label";
            this.Card_Expansion_Label.Size = new System.Drawing.Size(87, 20);
            this.Card_Expansion_Label.TabIndex = 12;
            this.Card_Expansion_Label.Text = "Expansion:";
            // 
            // Card_Description_Label
            // 
            this.Card_Description_Label.AutoSize = true;
            this.Card_Description_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Description_Label.Location = new System.Drawing.Point(256, 282);
            this.Card_Description_Label.Name = "Card_Description_Label";
            this.Card_Description_Label.Size = new System.Drawing.Size(93, 20);
            this.Card_Description_Label.TabIndex = 13;
            this.Card_Description_Label.Text = "Description:";
            // 
            // Card_Flavor_Text_Label
            // 
            this.Card_Flavor_Text_Label.AutoSize = true;
            this.Card_Flavor_Text_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Flavor_Text_Label.Location = new System.Drawing.Point(256, 403);
            this.Card_Flavor_Text_Label.Name = "Card_Flavor_Text_Label";
            this.Card_Flavor_Text_Label.Size = new System.Drawing.Size(90, 20);
            this.Card_Flavor_Text_Label.TabIndex = 14;
            this.Card_Flavor_Text_Label.Text = "Flavor Text:";
            this.Card_Flavor_Text_Label.Click += new System.EventHandler(this.Card_Flavor_Text_Label_Click);
            // 
            // Card_Power_Label
            // 
            this.Card_Power_Label.AutoSize = true;
            this.Card_Power_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Power_Label.Location = new System.Drawing.Point(256, 483);
            this.Card_Power_Label.Name = "Card_Power_Label";
            this.Card_Power_Label.Size = new System.Drawing.Size(57, 20);
            this.Card_Power_Label.TabIndex = 15;
            this.Card_Power_Label.Text = "Power:";
            // 
            // Card_Toughness_Label
            // 
            this.Card_Toughness_Label.AutoSize = true;
            this.Card_Toughness_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Toughness_Label.Location = new System.Drawing.Point(256, 513);
            this.Card_Toughness_Label.Name = "Card_Toughness_Label";
            this.Card_Toughness_Label.Size = new System.Drawing.Size(92, 20);
            this.Card_Toughness_Label.TabIndex = 16;
            this.Card_Toughness_Label.Text = "Toughness:";
            // 
            // Card_Additional_TextBox
            // 
            this.Card_Additional_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Additional_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Additional_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Additional_TextBox.Location = new System.Drawing.Point(356, 190);
            this.Card_Additional_TextBox.Name = "Card_Additional_TextBox";
            this.Card_Additional_TextBox.ReadOnly = true;
            this.Card_Additional_TextBox.Size = new System.Drawing.Size(200, 26);
            this.Card_Additional_TextBox.TabIndex = 20;
            this.Card_Additional_TextBox.TextChanged += new System.EventHandler(this.Card_Additional_TextBox_TextChanged);
            // 
            // Card_Type_TextBox
            // 
            this.Card_Type_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Type_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Type_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Type_TextBox.Location = new System.Drawing.Point(356, 159);
            this.Card_Type_TextBox.Name = "Card_Type_TextBox";
            this.Card_Type_TextBox.ReadOnly = true;
            this.Card_Type_TextBox.Size = new System.Drawing.Size(200, 26);
            this.Card_Type_TextBox.TabIndex = 21;
            // 
            // Card_Toughness_TextBox
            // 
            this.Card_Toughness_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Toughness_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Toughness_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Toughness_TextBox.Location = new System.Drawing.Point(356, 510);
            this.Card_Toughness_TextBox.Name = "Card_Toughness_TextBox";
            this.Card_Toughness_TextBox.ReadOnly = true;
            this.Card_Toughness_TextBox.Size = new System.Drawing.Size(40, 26);
            this.Card_Toughness_TextBox.TabIndex = 22;
            // 
            // Card_Power_TextBox
            // 
            this.Card_Power_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Power_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Power_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Power_TextBox.Location = new System.Drawing.Point(356, 480);
            this.Card_Power_TextBox.Name = "Card_Power_TextBox";
            this.Card_Power_TextBox.ReadOnly = true;
            this.Card_Power_TextBox.Size = new System.Drawing.Size(40, 26);
            this.Card_Power_TextBox.TabIndex = 24;
            // 
            // Card_Flavor_Text_TextBox
            // 
            this.Card_Flavor_Text_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Flavor_Text_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Flavor_Text_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Flavor_Text_TextBox.Location = new System.Drawing.Point(356, 400);
            this.Card_Flavor_Text_TextBox.Multiline = true;
            this.Card_Flavor_Text_TextBox.Name = "Card_Flavor_Text_TextBox";
            this.Card_Flavor_Text_TextBox.ReadOnly = true;
            this.Card_Flavor_Text_TextBox.Size = new System.Drawing.Size(200, 74);
            this.Card_Flavor_Text_TextBox.TabIndex = 25;
            // 
            // Card_Description_TextBox
            // 
            this.Card_Description_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Description_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Description_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Description_TextBox.Location = new System.Drawing.Point(356, 280);
            this.Card_Description_TextBox.Multiline = true;
            this.Card_Description_TextBox.Name = "Card_Description_TextBox";
            this.Card_Description_TextBox.ReadOnly = true;
            this.Card_Description_TextBox.Size = new System.Drawing.Size(200, 114);
            this.Card_Description_TextBox.TabIndex = 26;
            this.Card_Description_TextBox.TextChanged += new System.EventHandler(this.Card_Description_TextBox_TextChanged);
            // 
            // Card_Expansion_TextBox
            // 
            this.Card_Expansion_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Expansion_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Expansion_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Expansion_TextBox.Location = new System.Drawing.Point(356, 250);
            this.Card_Expansion_TextBox.Name = "Card_Expansion_TextBox";
            this.Card_Expansion_TextBox.ReadOnly = true;
            this.Card_Expansion_TextBox.Size = new System.Drawing.Size(200, 26);
            this.Card_Expansion_TextBox.TabIndex = 27;
            // 
            // Card_Mana_Cost_TextBox
            // 
            this.Card_Mana_Cost_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Mana_Cost_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Card_Mana_Cost_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Mana_Cost_TextBox.Location = new System.Drawing.Point(356, 220);
            this.Card_Mana_Cost_TextBox.Name = "Card_Mana_Cost_TextBox";
            this.Card_Mana_Cost_TextBox.ReadOnly = true;
            this.Card_Mana_Cost_TextBox.Size = new System.Drawing.Size(200, 26);
            this.Card_Mana_Cost_TextBox.TabIndex = 28;
            // 
            // Card_Nmbr_Label
            // 
            this.Card_Nmbr_Label.AutoSize = true;
            this.Card_Nmbr_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Nmbr_Label.Location = new System.Drawing.Point(256, 542);
            this.Card_Nmbr_Label.Name = "Card_Nmbr_Label";
            this.Card_Nmbr_Label.Size = new System.Drawing.Size(69, 20);
            this.Card_Nmbr_Label.TabIndex = 29;
            this.Card_Nmbr_Label.Text = "Number:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SlateGray;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(356, 539);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(40, 26);
            this.textBox2.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(567, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 37);
            this.button4.TabIndex = 31;
            this.button4.Text = "Find Card";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(567, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 37);
            this.button5.TabIndex = 32;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Name_Textbox
            // 
            this.Name_Textbox.BackColor = System.Drawing.Color.SlateGray;
            this.Name_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Name_Textbox.ForeColor = System.Drawing.Color.Silver;
            this.Name_Textbox.Location = new System.Drawing.Point(356, 129);
            this.Name_Textbox.Name = "Name_Textbox";
            this.Name_Textbox.Size = new System.Drawing.Size(200, 26);
            this.Name_Textbox.TabIndex = 33;
            this.Name_Textbox.TextChanged += new System.EventHandler(this.Name_Textbox_TextChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.BackColor = System.Drawing.Color.SlateGray;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.FormattingEnabled = true;
            this.SearchBox.Location = new System.Drawing.Point(57, 29);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(599, 32);
            this.SearchBox.TabIndex = 34;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // Edit_Card_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(736, 684);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.Name_Textbox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Card_Nmbr_Label);
            this.Controls.Add(this.Card_Mana_Cost_TextBox);
            this.Controls.Add(this.Card_Expansion_TextBox);
            this.Controls.Add(this.Card_Description_TextBox);
            this.Controls.Add(this.Card_Flavor_Text_TextBox);
            this.Controls.Add(this.Card_Power_TextBox);
            this.Controls.Add(this.Card_Toughness_TextBox);
            this.Controls.Add(this.Card_Type_TextBox);
            this.Controls.Add(this.Card_Additional_TextBox);
            this.Controls.Add(this.Card_Toughness_Label);
            this.Controls.Add(this.Card_Power_Label);
            this.Controls.Add(this.Card_Flavor_Text_Label);
            this.Controls.Add(this.Card_Description_Label);
            this.Controls.Add(this.Card_Expansion_Label);
            this.Controls.Add(this.Card_Mana_Cost_Label);
            this.Controls.Add(this.Card_Additional_Label);
            this.Controls.Add(this.Card_Type_Label);
            this.Controls.Add(this.Card_Name_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Edit_Card_Form";
            this.Text = "TCGDigitizer - Review Card";
            this.Load += new System.EventHandler(this.Edit_Card_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Card_Name_Label;
        private System.Windows.Forms.Label Card_Type_Label;
        private System.Windows.Forms.Label Card_Additional_Label;
        private System.Windows.Forms.Label Card_Mana_Cost_Label;
        private System.Windows.Forms.Label Card_Expansion_Label;
        private System.Windows.Forms.Label Card_Description_Label;
        private System.Windows.Forms.Label Card_Flavor_Text_Label;
        private System.Windows.Forms.Label Card_Power_Label;
        private System.Windows.Forms.Label Card_Toughness_Label;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox Card_Additional_TextBox;
        private System.Windows.Forms.TextBox Card_Type_TextBox;
        private System.Windows.Forms.TextBox Card_Toughness_TextBox;
        private System.Windows.Forms.TextBox Card_Power_TextBox;
        private System.Windows.Forms.TextBox Card_Flavor_Text_TextBox;
        private System.Windows.Forms.TextBox Card_Expansion_TextBox;
        private System.Windows.Forms.TextBox Card_Mana_Cost_TextBox;
        private System.Windows.Forms.Label Card_Nmbr_Label;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox Name_Textbox;
        private System.Windows.Forms.TextBox Card_Description_TextBox;
        private System.Windows.Forms.ComboBox SearchBox;
    }
}