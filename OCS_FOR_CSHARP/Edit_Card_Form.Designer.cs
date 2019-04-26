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
            this.Add_Card_Button = new System.Windows.Forms.Button();
            this.Card_Image_Box = new System.Windows.Forms.PictureBox();
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
            this.Card_Number_Textbox = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Name_Textbox = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.ComboBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.TopButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.Remove_Card_Button = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.Card_Image_Box)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.TopButtonTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // Add_Card_Button
            // 
            this.Add_Card_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_Card_Button.Enabled = false;
            this.Add_Card_Button.FlatAppearance.BorderSize = 0;
            this.Add_Card_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Card_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Card_Button.ForeColor = System.Drawing.Color.Transparent;
            this.Add_Card_Button.Location = new System.Drawing.Point(3, 3);
            this.Add_Card_Button.Name = "Add_Card_Button";
            this.Add_Card_Button.Size = new System.Drawing.Size(332, 71);
            this.Add_Card_Button.TabIndex = 1;
            this.Add_Card_Button.Text = "Add to Inventory";
            this.Add_Card_Button.UseVisualStyleBackColor = true;
            this.Add_Card_Button.Click += new System.EventHandler(this.Save_Button);
            // 
            // Card_Image_Box
            // 
            this.Card_Image_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Image_Box.BackColor = System.Drawing.Color.Transparent;
            this.Card_Image_Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Card_Image_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Card_Image_Box.Image = ((System.Drawing.Image)(resources.GetObject("Card_Image_Box.Image")));
            this.Card_Image_Box.InitialImage = ((System.Drawing.Image)(resources.GetObject("Card_Image_Box.InitialImage")));
            this.Card_Image_Box.Location = new System.Drawing.Point(210, 89);
            this.Card_Image_Box.Name = "Card_Image_Box";
            this.Card_Image_Box.Size = new System.Drawing.Size(278, 399);
            this.Card_Image_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Card_Image_Box.TabIndex = 4;
            this.Card_Image_Box.TabStop = false;
            this.Card_Image_Box.Click += new System.EventHandler(this.Card_Display_PictureBox);
            // 
            // Card_Name_Label
            // 
            this.Card_Name_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Name_Label.AutoSize = true;
            this.Card_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Name_Label.Location = new System.Drawing.Point(537, 89);
            this.Card_Name_Label.Name = "Card_Name_Label";
            this.Card_Name_Label.Size = new System.Drawing.Size(66, 24);
            this.Card_Name_Label.TabIndex = 8;
            this.Card_Name_Label.Text = "Name:";
            this.Card_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Type_Label
            // 
            this.Card_Type_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Type_Label.AutoSize = true;
            this.Card_Type_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Type_Label.Location = new System.Drawing.Point(545, 124);
            this.Card_Type_Label.Name = "Card_Type_Label";
            this.Card_Type_Label.Size = new System.Drawing.Size(58, 24);
            this.Card_Type_Label.TabIndex = 9;
            this.Card_Type_Label.Text = "Type:";
            this.Card_Type_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Additional_Label
            // 
            this.Card_Additional_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Additional_Label.AutoSize = true;
            this.Card_Additional_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Additional_Label.Location = new System.Drawing.Point(505, 159);
            this.Card_Additional_Label.Name = "Card_Additional_Label";
            this.Card_Additional_Label.Size = new System.Drawing.Size(98, 24);
            this.Card_Additional_Label.TabIndex = 10;
            this.Card_Additional_Label.Text = "-SubType:";
            this.Card_Additional_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Mana_Cost_Label
            // 
            this.Card_Mana_Cost_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Mana_Cost_Label.AutoSize = true;
            this.Card_Mana_Cost_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Mana_Cost_Label.Location = new System.Drawing.Point(499, 194);
            this.Card_Mana_Cost_Label.Name = "Card_Mana_Cost_Label";
            this.Card_Mana_Cost_Label.Size = new System.Drawing.Size(104, 24);
            this.Card_Mana_Cost_Label.TabIndex = 11;
            this.Card_Mana_Cost_Label.Text = "Mana Cost:";
            this.Card_Mana_Cost_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Expansion_Label
            // 
            this.Card_Expansion_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Expansion_Label.AutoSize = true;
            this.Card_Expansion_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Expansion_Label.Location = new System.Drawing.Point(498, 224);
            this.Card_Expansion_Label.Name = "Card_Expansion_Label";
            this.Card_Expansion_Label.Size = new System.Drawing.Size(105, 24);
            this.Card_Expansion_Label.TabIndex = 12;
            this.Card_Expansion_Label.Text = "Expansion:";
            this.Card_Expansion_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Description_Label
            // 
            this.Card_Description_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Description_Label.AutoSize = true;
            this.Card_Description_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Description_Label.Location = new System.Drawing.Point(494, 259);
            this.Card_Description_Label.Name = "Card_Description_Label";
            this.Card_Description_Label.Size = new System.Drawing.Size(109, 24);
            this.Card_Description_Label.TabIndex = 13;
            this.Card_Description_Label.Text = "Description:";
            this.Card_Description_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Flavor_Text_Label
            // 
            this.Card_Flavor_Text_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Flavor_Text_Label.AutoSize = true;
            this.Card_Flavor_Text_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Flavor_Text_Label.Location = new System.Drawing.Point(494, 379);
            this.Card_Flavor_Text_Label.Name = "Card_Flavor_Text_Label";
            this.Card_Flavor_Text_Label.Size = new System.Drawing.Size(109, 24);
            this.Card_Flavor_Text_Label.TabIndex = 14;
            this.Card_Flavor_Text_Label.Text = "Flavor Text:";
            this.Card_Flavor_Text_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Card_Flavor_Text_Label.Click += new System.EventHandler(this.Card_Flavor_Text_Label_Click);
            // 
            // Card_Power_Label
            // 
            this.Card_Power_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Power_Label.AutoSize = true;
            this.Card_Power_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Power_Label.Location = new System.Drawing.Point(534, 459);
            this.Card_Power_Label.Name = "Card_Power_Label";
            this.Card_Power_Label.Size = new System.Drawing.Size(69, 24);
            this.Card_Power_Label.TabIndex = 15;
            this.Card_Power_Label.Text = "Power:";
            this.Card_Power_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Toughness_Label
            // 
            this.Card_Toughness_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Toughness_Label.AutoSize = true;
            this.Card_Toughness_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Toughness_Label.Location = new System.Drawing.Point(492, 494);
            this.Card_Toughness_Label.Name = "Card_Toughness_Label";
            this.Card_Toughness_Label.Size = new System.Drawing.Size(111, 24);
            this.Card_Toughness_Label.TabIndex = 16;
            this.Card_Toughness_Label.Text = "Toughness:";
            this.Card_Toughness_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Additional_TextBox
            // 
            this.Card_Additional_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Additional_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Additional_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Additional_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Additional_TextBox.Location = new System.Drawing.Point(609, 154);
            this.Card_Additional_TextBox.Name = "Card_Additional_TextBox";
            this.Card_Additional_TextBox.ReadOnly = true;
            this.Card_Additional_TextBox.Size = new System.Drawing.Size(200, 29);
            this.Card_Additional_TextBox.TabIndex = 20;
            // 
            // Card_Type_TextBox
            // 
            this.Card_Type_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Type_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Type_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Type_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Type_TextBox.Location = new System.Drawing.Point(609, 119);
            this.Card_Type_TextBox.Name = "Card_Type_TextBox";
            this.Card_Type_TextBox.ReadOnly = true;
            this.Card_Type_TextBox.Size = new System.Drawing.Size(200, 29);
            this.Card_Type_TextBox.TabIndex = 21;
            // 
            // Card_Toughness_TextBox
            // 
            this.Card_Toughness_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Toughness_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Toughness_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Toughness_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Toughness_TextBox.Location = new System.Drawing.Point(609, 494);
            this.Card_Toughness_TextBox.Name = "Card_Toughness_TextBox";
            this.Card_Toughness_TextBox.ReadOnly = true;
            this.Card_Toughness_TextBox.Size = new System.Drawing.Size(40, 29);
            this.Card_Toughness_TextBox.TabIndex = 22;
            // 
            // Card_Power_TextBox
            // 
            this.Card_Power_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Power_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Power_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Power_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Power_TextBox.Location = new System.Drawing.Point(609, 459);
            this.Card_Power_TextBox.Name = "Card_Power_TextBox";
            this.Card_Power_TextBox.ReadOnly = true;
            this.Card_Power_TextBox.Size = new System.Drawing.Size(40, 29);
            this.Card_Power_TextBox.TabIndex = 24;
            // 
            // Card_Flavor_Text_TextBox
            // 
            this.Card_Flavor_Text_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Flavor_Text_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Flavor_Text_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Flavor_Text_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Flavor_Text_TextBox.Location = new System.Drawing.Point(609, 379);
            this.Card_Flavor_Text_TextBox.Multiline = true;
            this.Card_Flavor_Text_TextBox.Name = "Card_Flavor_Text_TextBox";
            this.Card_Flavor_Text_TextBox.ReadOnly = true;
            this.Card_Flavor_Text_TextBox.Size = new System.Drawing.Size(200, 74);
            this.Card_Flavor_Text_TextBox.TabIndex = 25;
            // 
            // Card_Description_TextBox
            // 
            this.Card_Description_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Description_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Description_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Description_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Description_TextBox.Location = new System.Drawing.Point(609, 259);
            this.Card_Description_TextBox.Multiline = true;
            this.Card_Description_TextBox.Name = "Card_Description_TextBox";
            this.Card_Description_TextBox.ReadOnly = true;
            this.Card_Description_TextBox.Size = new System.Drawing.Size(200, 114);
            this.Card_Description_TextBox.TabIndex = 26;
            // 
            // Card_Expansion_TextBox
            // 
            this.Card_Expansion_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Expansion_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Expansion_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Expansion_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Expansion_TextBox.Location = new System.Drawing.Point(609, 224);
            this.Card_Expansion_TextBox.Name = "Card_Expansion_TextBox";
            this.Card_Expansion_TextBox.ReadOnly = true;
            this.Card_Expansion_TextBox.Size = new System.Drawing.Size(200, 29);
            this.Card_Expansion_TextBox.TabIndex = 27;
            // 
            // Card_Mana_Cost_TextBox
            // 
            this.Card_Mana_Cost_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Mana_Cost_TextBox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Mana_Cost_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Mana_Cost_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Mana_Cost_TextBox.Location = new System.Drawing.Point(609, 189);
            this.Card_Mana_Cost_TextBox.Name = "Card_Mana_Cost_TextBox";
            this.Card_Mana_Cost_TextBox.ReadOnly = true;
            this.Card_Mana_Cost_TextBox.Size = new System.Drawing.Size(200, 29);
            this.Card_Mana_Cost_TextBox.TabIndex = 28;
            // 
            // Card_Nmbr_Label
            // 
            this.Card_Nmbr_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Nmbr_Label.AutoSize = true;
            this.Card_Nmbr_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Nmbr_Label.Location = new System.Drawing.Point(519, 529);
            this.Card_Nmbr_Label.Name = "Card_Nmbr_Label";
            this.Card_Nmbr_Label.Size = new System.Drawing.Size(84, 24);
            this.Card_Nmbr_Label.TabIndex = 29;
            this.Card_Nmbr_Label.Text = "Number:";
            this.Card_Nmbr_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Card_Number_Textbox
            // 
            this.Card_Number_Textbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Card_Number_Textbox.BackColor = System.Drawing.Color.SlateGray;
            this.Card_Number_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Card_Number_Textbox.ForeColor = System.Drawing.Color.Silver;
            this.Card_Number_Textbox.Location = new System.Drawing.Point(609, 529);
            this.Card_Number_Textbox.Name = "Card_Number_Textbox";
            this.Card_Number_Textbox.ReadOnly = true;
            this.Card_Number_Textbox.Size = new System.Drawing.Size(40, 29);
            this.Card_Number_Textbox.TabIndex = 30;
            // 
            // Cancel
            // 
            this.Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.Transparent;
            this.Cancel.Location = new System.Drawing.Point(679, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(332, 71);
            this.Cancel.TabIndex = 32;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button5_Click);
            // 
            // Name_Textbox
            // 
            this.Name_Textbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Name_Textbox.BackColor = System.Drawing.Color.SlateGray;
            this.Name_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_Textbox.ForeColor = System.Drawing.Color.Silver;
            this.Name_Textbox.Location = new System.Drawing.Point(609, 84);
            this.Name_Textbox.Name = "Name_Textbox";
            this.Name_Textbox.ReadOnly = true;
            this.Name_Textbox.Size = new System.Drawing.Size(200, 29);
            this.Name_Textbox.TabIndex = 33;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SearchBox.BackColor = System.Drawing.Color.SlateGray;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.FormattingEnabled = true;
            this.SearchBox.Location = new System.Drawing.Point(62, 27);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(894, 32);
            this.SearchBox.TabIndex = 34;
            this.SearchBox.SelectedIndexChanged += new System.EventHandler(this.SearchBox_SelectedIndexChanged);
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.TopButtonTable);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TopPanel.Location = new System.Drawing.Point(0, 719);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1014, 77);
            this.TopPanel.TabIndex = 35;
            // 
            // TopButtonTable
            // 
            this.TopButtonTable.ColumnCount = 3;
            this.TopButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TopButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TopButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TopButtonTable.Controls.Add(this.Remove_Card_Button, 1, 0);
            this.TopButtonTable.Controls.Add(this.Cancel, 2, 0);
            this.TopButtonTable.Controls.Add(this.Add_Card_Button, 0, 0);
            this.TopButtonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopButtonTable.Location = new System.Drawing.Point(0, 0);
            this.TopButtonTable.Margin = new System.Windows.Forms.Padding(0);
            this.TopButtonTable.Name = "TopButtonTable";
            this.TopButtonTable.RowCount = 1;
            this.TopButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopButtonTable.Size = new System.Drawing.Size(1014, 77);
            this.TopButtonTable.TabIndex = 0;
            // 
            // Remove_Card_Button
            // 
            this.Remove_Card_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Remove_Card_Button.Enabled = false;
            this.Remove_Card_Button.FlatAppearance.BorderSize = 0;
            this.Remove_Card_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove_Card_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove_Card_Button.ForeColor = System.Drawing.Color.Transparent;
            this.Remove_Card_Button.Location = new System.Drawing.Point(341, 3);
            this.Remove_Card_Button.Name = "Remove_Card_Button";
            this.Remove_Card_Button.Size = new System.Drawing.Size(332, 71);
            this.Remove_Card_Button.TabIndex = 36;
            this.Remove_Card_Button.Text = "Remove from Inventory";
            this.Remove_Card_Button.UseVisualStyleBackColor = true;
            this.Remove_Card_Button.Click += new System.EventHandler(this.Remove_Card_Button_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Edit_Card_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1014, 796);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.Name_Textbox);
            this.Controls.Add(this.Card_Number_Textbox);
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
            this.Controls.Add(this.Card_Image_Box);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Edit_Card_Form";
            this.Text = "TCGDigitizer - Review Card";
            this.Load += new System.EventHandler(this.Edit_Card_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Card_Image_Box)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopButtonTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Add_Card_Button;
        private System.Windows.Forms.PictureBox Card_Image_Box;
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
        private System.Windows.Forms.TextBox Card_Number_Textbox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox Name_Textbox;
        private System.Windows.Forms.TextBox Card_Description_TextBox;
        private System.Windows.Forms.ComboBox SearchBox;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.TableLayoutPanel TopButtonTable;
        private System.Windows.Forms.Button Remove_Card_Button;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}