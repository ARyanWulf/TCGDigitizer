namespace OCS_FOR_CSHARP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Card_Form));
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.RightPanel = new System.Windows.Forms.Panel();
            this.RightButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.RightPanel.SuspendLayout();
            this.RightButtonTable.SuspendLayout();
            this.BackPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(4, 740);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 362);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Save_Button);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-15, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Card_Display_PictureBox);
            // 
            // Card_Name_Label
            // 
            this.Card_Name_Label.AutoSize = true;
            this.Card_Name_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Name_Label.Location = new System.Drawing.Point(4, 1);
            this.Card_Name_Label.Name = "Card_Name_Label";
            this.Card_Name_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Name_Label.TabIndex = 8;
            this.Card_Name_Label.Text = "Name:";
            this.Card_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Type_Label
            // 
            this.Card_Type_Label.AutoSize = true;
            this.Card_Type_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Type_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Type_Label.Location = new System.Drawing.Point(4, 14);
            this.Card_Type_Label.Name = "Card_Type_Label";
            this.Card_Type_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Type_Label.TabIndex = 9;
            this.Card_Type_Label.Text = "Type:";
            this.Card_Type_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Additional_Label
            // 
            this.Card_Additional_Label.AutoSize = true;
            this.Card_Additional_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Additional_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Additional_Label.Location = new System.Drawing.Point(4, 27);
            this.Card_Additional_Label.Name = "Card_Additional_Label";
            this.Card_Additional_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Additional_Label.TabIndex = 10;
            this.Card_Additional_Label.Text = "-SubType:";
            this.Card_Additional_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Mana_Cost_Label
            // 
            this.Card_Mana_Cost_Label.AutoSize = true;
            this.Card_Mana_Cost_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Mana_Cost_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Mana_Cost_Label.Location = new System.Drawing.Point(4, 40);
            this.Card_Mana_Cost_Label.Name = "Card_Mana_Cost_Label";
            this.Card_Mana_Cost_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Mana_Cost_Label.TabIndex = 11;
            this.Card_Mana_Cost_Label.Text = "Mana Cost:";
            this.Card_Mana_Cost_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Expansion_Label
            // 
            this.Card_Expansion_Label.AutoSize = true;
            this.Card_Expansion_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Expansion_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Expansion_Label.Location = new System.Drawing.Point(4, 53);
            this.Card_Expansion_Label.Name = "Card_Expansion_Label";
            this.Card_Expansion_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Expansion_Label.TabIndex = 12;
            this.Card_Expansion_Label.Text = "Expansion:";
            this.Card_Expansion_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Description_Label
            // 
            this.Card_Description_Label.AutoSize = true;
            this.Card_Description_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Description_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Description_Label.Location = new System.Drawing.Point(4, 66);
            this.Card_Description_Label.Name = "Card_Description_Label";
            this.Card_Description_Label.Size = new System.Drawing.Size(155, 36);
            this.Card_Description_Label.TabIndex = 13;
            this.Card_Description_Label.Text = "Description:";
            this.Card_Description_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Flavor_Text_Label
            // 
            this.Card_Flavor_Text_Label.AutoSize = true;
            this.Card_Flavor_Text_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Flavor_Text_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Flavor_Text_Label.Location = new System.Drawing.Point(4, 103);
            this.Card_Flavor_Text_Label.Name = "Card_Flavor_Text_Label";
            this.Card_Flavor_Text_Label.Size = new System.Drawing.Size(155, 36);
            this.Card_Flavor_Text_Label.TabIndex = 14;
            this.Card_Flavor_Text_Label.Text = "Flavor Text:";
            this.Card_Flavor_Text_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Card_Flavor_Text_Label.Click += new System.EventHandler(this.Card_Flavor_Text_Label_Click);
            // 
            // Card_Power_Label
            // 
            this.Card_Power_Label.AutoSize = true;
            this.Card_Power_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Power_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Power_Label.Location = new System.Drawing.Point(4, 140);
            this.Card_Power_Label.Name = "Card_Power_Label";
            this.Card_Power_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Power_Label.TabIndex = 15;
            this.Card_Power_Label.Text = "Power:";
            this.Card_Power_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Toughness_Label
            // 
            this.Card_Toughness_Label.AutoSize = true;
            this.Card_Toughness_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Toughness_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Toughness_Label.Location = new System.Drawing.Point(4, 153);
            this.Card_Toughness_Label.Name = "Card_Toughness_Label";
            this.Card_Toughness_Label.Size = new System.Drawing.Size(155, 12);
            this.Card_Toughness_Label.TabIndex = 16;
            this.Card_Toughness_Label.Text = "Toughness:";
            this.Card_Toughness_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Additional_TextBox
            // 
            this.Card_Additional_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Additional_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Additional_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Additional_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Additional_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Additional_TextBox.Location = new System.Drawing.Point(163, 27);
            this.Card_Additional_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Additional_TextBox.Multiline = true;
            this.Card_Additional_TextBox.Name = "Card_Additional_TextBox";
            this.Card_Additional_TextBox.ReadOnly = true;
            this.Card_Additional_TextBox.Size = new System.Drawing.Size(378, 12);
            this.Card_Additional_TextBox.TabIndex = 20;
            this.Card_Additional_TextBox.TextChanged += new System.EventHandler(this.Card_Additional_TextBox_TextChanged);
            // 
            // Card_Type_TextBox
            // 
            this.Card_Type_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Type_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Type_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Type_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Type_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Type_TextBox.Location = new System.Drawing.Point(163, 14);
            this.Card_Type_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Type_TextBox.Multiline = true;
            this.Card_Type_TextBox.Name = "Card_Type_TextBox";
            this.Card_Type_TextBox.ReadOnly = true;
            this.Card_Type_TextBox.Size = new System.Drawing.Size(378, 12);
            this.Card_Type_TextBox.TabIndex = 21;
            // 
            // Card_Toughness_TextBox
            // 
            this.Card_Toughness_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Toughness_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Toughness_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Toughness_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Toughness_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Toughness_TextBox.Location = new System.Drawing.Point(163, 153);
            this.Card_Toughness_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Toughness_TextBox.Multiline = true;
            this.Card_Toughness_TextBox.Name = "Card_Toughness_TextBox";
            this.Card_Toughness_TextBox.ReadOnly = true;
            this.Card_Toughness_TextBox.Size = new System.Drawing.Size(378, 12);
            this.Card_Toughness_TextBox.TabIndex = 22;
            // 
            // Card_Power_TextBox
            // 
            this.Card_Power_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Power_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Power_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Power_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Power_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Power_TextBox.Location = new System.Drawing.Point(163, 140);
            this.Card_Power_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Power_TextBox.Multiline = true;
            this.Card_Power_TextBox.Name = "Card_Power_TextBox";
            this.Card_Power_TextBox.ReadOnly = true;
            this.Card_Power_TextBox.Size = new System.Drawing.Size(378, 12);
            this.Card_Power_TextBox.TabIndex = 24;
            // 
            // Card_Flavor_Text_TextBox
            // 
            this.Card_Flavor_Text_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Flavor_Text_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Flavor_Text_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Flavor_Text_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Flavor_Text_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Flavor_Text_TextBox.Location = new System.Drawing.Point(163, 103);
            this.Card_Flavor_Text_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Flavor_Text_TextBox.Multiline = true;
            this.Card_Flavor_Text_TextBox.Name = "Card_Flavor_Text_TextBox";
            this.Card_Flavor_Text_TextBox.ReadOnly = true;
            this.Card_Flavor_Text_TextBox.Size = new System.Drawing.Size(378, 36);
            this.Card_Flavor_Text_TextBox.TabIndex = 25;
            // 
            // Card_Description_TextBox
            // 
            this.Card_Description_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Description_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Description_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Description_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Description_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Description_TextBox.Location = new System.Drawing.Point(163, 66);
            this.Card_Description_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Description_TextBox.Multiline = true;
            this.Card_Description_TextBox.Name = "Card_Description_TextBox";
            this.Card_Description_TextBox.ReadOnly = true;
            this.Card_Description_TextBox.Size = new System.Drawing.Size(378, 36);
            this.Card_Description_TextBox.TabIndex = 26;
            this.Card_Description_TextBox.TextChanged += new System.EventHandler(this.Card_Description_TextBox_TextChanged);
            // 
            // Card_Expansion_TextBox
            // 
            this.Card_Expansion_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Expansion_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Expansion_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Expansion_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Expansion_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Expansion_TextBox.Location = new System.Drawing.Point(163, 53);
            this.Card_Expansion_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Expansion_TextBox.Multiline = true;
            this.Card_Expansion_TextBox.Name = "Card_Expansion_TextBox";
            this.Card_Expansion_TextBox.ReadOnly = true;
            this.Card_Expansion_TextBox.Size = new System.Drawing.Size(378, 12);
            this.Card_Expansion_TextBox.TabIndex = 27;
            // 
            // Card_Mana_Cost_TextBox
            // 
            this.Card_Mana_Cost_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Mana_Cost_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card_Mana_Cost_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Mana_Cost_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Card_Mana_Cost_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Mana_Cost_TextBox.Location = new System.Drawing.Point(163, 40);
            this.Card_Mana_Cost_TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Card_Mana_Cost_TextBox.Multiline = true;
            this.Card_Mana_Cost_TextBox.Name = "Card_Mana_Cost_TextBox";
            this.Card_Mana_Cost_TextBox.ReadOnly = true;
            this.Card_Mana_Cost_TextBox.Size = new System.Drawing.Size(378, 12);
            this.Card_Mana_Cost_TextBox.TabIndex = 28;
            // 
            // Card_Nmbr_Label
            // 
            this.Card_Nmbr_Label.AutoSize = true;
            this.Card_Nmbr_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Card_Nmbr_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Nmbr_Label.Location = new System.Drawing.Point(4, 166);
            this.Card_Nmbr_Label.Name = "Card_Nmbr_Label";
            this.Card_Nmbr_Label.Size = new System.Drawing.Size(155, 14);
            this.Card_Nmbr_Label.TabIndex = 29;
            this.Card_Nmbr_Label.Text = "Number:";
            this.Card_Nmbr_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SlateGray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox2.ForeColor = System.Drawing.Color.Silver;
            this.textBox2.Location = new System.Drawing.Point(163, 166);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(378, 14);
            this.textBox2.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(192, 361);
            this.button4.TabIndex = 31;
            this.button4.Text = "Find Card";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(4, 372);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(192, 361);
            this.button5.TabIndex = 32;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Name_Textbox
            // 
            this.Name_Textbox.BackColor = System.Drawing.Color.SlateGray;
            this.Name_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Name_Textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Name_Textbox.ForeColor = System.Drawing.Color.Silver;
            this.Name_Textbox.Location = new System.Drawing.Point(163, 1);
            this.Name_Textbox.Margin = new System.Windows.Forms.Padding(0);
            this.Name_Textbox.Multiline = true;
            this.Name_Textbox.Name = "Name_Textbox";
            this.Name_Textbox.Size = new System.Drawing.Size(378, 12);
            this.Name_Textbox.TabIndex = 33;
            this.Name_Textbox.Click += new System.EventHandler(this.Name_Textbox_Click);
            this.Name_Textbox.TextChanged += new System.EventHandler(this.Name_Textbox_TextChanged);
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.RightButtonTable);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(745, 0);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(200, 1106);
            this.RightPanel.TabIndex = 34;
            // 
            // RightButtonTable
            // 
            this.RightButtonTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.RightButtonTable.ColumnCount = 1;
            this.RightButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightButtonTable.Controls.Add(this.button4, 0, 0);
            this.RightButtonTable.Controls.Add(this.button5, 0, 1);
            this.RightButtonTable.Controls.Add(this.button2, 0, 2);
            this.RightButtonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightButtonTable.Location = new System.Drawing.Point(0, 0);
            this.RightButtonTable.Name = "RightButtonTable";
            this.RightButtonTable.RowCount = 3;
            this.RightButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RightButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RightButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RightButtonTable.Size = new System.Drawing.Size(200, 1106);
            this.RightButtonTable.TabIndex = 35;
            // 
            // BackPanel
            // 
            this.BackPanel.Controls.Add(this.tableLayoutPanel1);
            this.BackPanel.Location = new System.Drawing.Point(203, 250);
            this.BackPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(542, 181);
            this.BackPanel.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.Card_Name_Label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Card_Nmbr_Label, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.Card_Toughness_Label, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.Name_Textbox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Card_Power_Label, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.Card_Type_TextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Card_Flavor_Text_Label, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Card_Toughness_TextBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.Card_Description_Label, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Card_Power_TextBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.Card_Expansion_Label, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Card_Flavor_Text_TextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.Card_Mana_Cost_Label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Card_Description_TextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Card_Additional_Label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Card_Expansion_TextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Card_Type_Label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Card_Mana_Cost_TextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Card_Additional_TextBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 181);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.pictureBox1);
            this.LeftPanel.Location = new System.Drawing.Point(162, 386);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 720);
            this.LeftPanel.TabIndex = 36;
            // 
            // Edit_Card_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(945, 720);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.BackPanel);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Edit_Card_Form";
            this.Text = "TCGDigitizer - Manual Entry";
            this.Load += new System.EventHandler(this.Edit_Card_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.RightButtonTable.ResumeLayout(false);
            this.BackPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.TableLayoutPanel RightButtonTable;
        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel LeftPanel;
    }
}