namespace OCS_FOR_CSHARP
{
    partial class Inventory_Menu
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
            this.Scan_Card_Button = new System.Windows.Forms.Button();
            this.Add_Card_Button = new System.Windows.Forms.Button();
            this.Card_Table_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.InventoryCountLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.Page_Back_Button = new System.Windows.Forms.Button();
            this.Page_Forward_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scan_Card_Button
            // 
            this.Scan_Card_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.Scan_Card_Button.ForeColor = System.Drawing.Color.Silver;
            this.Scan_Card_Button.Location = new System.Drawing.Point(18, 37);
            this.Scan_Card_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Scan_Card_Button.Name = "Scan_Card_Button";
            this.Scan_Card_Button.Size = new System.Drawing.Size(112, 35);
            this.Scan_Card_Button.TabIndex = 0;
            this.Scan_Card_Button.Text = "Scan Card";
            this.Scan_Card_Button.UseVisualStyleBackColor = false;
            this.Scan_Card_Button.Click += new System.EventHandler(this.Scan_Card_Button_Click);
            // 
            // Add_Card_Button
            // 
            this.Add_Card_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.Add_Card_Button.ForeColor = System.Drawing.Color.Silver;
            this.Add_Card_Button.Location = new System.Drawing.Point(141, 37);
            this.Add_Card_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add_Card_Button.Name = "Add_Card_Button";
            this.Add_Card_Button.Size = new System.Drawing.Size(112, 35);
            this.Add_Card_Button.TabIndex = 5;
            this.Add_Card_Button.Text = "Add Card";
            this.Add_Card_Button.UseVisualStyleBackColor = false;
            this.Add_Card_Button.Click += new System.EventHandler(this.Add_Card_Button_Click);
            // 
            // Card_Table_Panel
            // 
            this.Card_Table_Panel.AutoSize = true;
            this.Card_Table_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Card_Table_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.Card_Table_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Card_Table_Panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Card_Table_Panel.ColumnCount = 7;
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Card_Table_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.Card_Table_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Card_Table_Panel.Location = new System.Drawing.Point(1, 0);
            this.Card_Table_Panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Card_Table_Panel.MaximumSize = new System.Drawing.Size(973, 0);
            this.Card_Table_Panel.MinimumSize = new System.Drawing.Size(973, 50);
            this.Card_Table_Panel.Name = "Card_Table_Panel";
            this.Card_Table_Panel.RowCount = 1;
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.Card_Table_Panel.Size = new System.Drawing.Size(973, 105);
            this.Card_Table_Panel.TabIndex = 6;
            // 
            // InventoryCountLabel
            // 
            this.InventoryCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryCountLabel.AutoSize = true;
            this.InventoryCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryCountLabel.ForeColor = System.Drawing.Color.Silver;
            this.InventoryCountLabel.Location = new System.Drawing.Point(625, 31);
            this.InventoryCountLabel.Name = "InventoryCountLabel";
            this.InventoryCountLabel.Size = new System.Drawing.Size(388, 37);
            this.InventoryCountLabel.TabIndex = 7;
            this.InventoryCountLabel.Text = "Cards in inventory: 4000";
            this.InventoryCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InventoryCountLabel.Click += new System.EventHandler(this.InventoryCountLabel_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.RefreshButton.ForeColor = System.Drawing.Color.Silver;
            this.RefreshButton.Location = new System.Drawing.Point(261, 37);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(112, 35);
            this.RefreshButton.TabIndex = 8;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Page_Back_Button
            // 
            this.Page_Back_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.Page_Back_Button.ForeColor = System.Drawing.Color.Silver;
            this.Page_Back_Button.Location = new System.Drawing.Point(851, 810);
            this.Page_Back_Button.Name = "Page_Back_Button";
            this.Page_Back_Button.Size = new System.Drawing.Size(34, 34);
            this.Page_Back_Button.TabIndex = 9;
            this.Page_Back_Button.Text = "<";
            this.Page_Back_Button.UseVisualStyleBackColor = false;
            this.Page_Back_Button.Click += new System.EventHandler(this.Page_Back_Button_Click);
            // 
            // Page_Forward_Button
            // 
            this.Page_Forward_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.Page_Forward_Button.ForeColor = System.Drawing.Color.Silver;
            this.Page_Forward_Button.Location = new System.Drawing.Point(891, 809);
            this.Page_Forward_Button.Name = "Page_Forward_Button";
            this.Page_Forward_Button.Size = new System.Drawing.Size(34, 34);
            this.Page_Forward_Button.TabIndex = 10;
            this.Page_Forward_Button.Text = ">";
            this.Page_Forward_Button.UseVisualStyleBackColor = false;
            this.Page_Forward_Button.Click += new System.EventHandler(this.Page_Forward_Button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(975, 60);
            this.tableLayoutPanel1.TabIndex = 11;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(826, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.MaximumSize = new System.Drawing.Size(92, 53);
            this.button1.MinimumSize = new System.Drawing.Size(92, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 53);
            this.button1.TabIndex = 12;
            this.button1.Text = "Date";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(750, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 60);
            this.button2.TabIndex = 11;
            this.button2.Text = "Mana";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Silver;
            this.button3.Location = new System.Drawing.Point(674, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 60);
            this.button3.TabIndex = 10;
            this.button3.Text = "#";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Silver;
            this.button4.Location = new System.Drawing.Point(598, 6);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 60);
            this.button4.TabIndex = 9;
            this.button4.Text = "Expn";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Silver;
            this.button5.Location = new System.Drawing.Point(347, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(242, 60);
            this.button5.TabIndex = 8;
            this.button5.Text = "Type";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Silver;
            this.button6.Location = new System.Drawing.Point(46, 6);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(292, 60);
            this.button6.TabIndex = 7;
            this.button6.Text = "Name";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(5, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(32, 60);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(18, 83);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 60);
            this.panel2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.Card_Table_Panel);
            this.panel1.Location = new System.Drawing.Point(18, 143);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(1000, 650);
            this.panel1.MinimumSize = new System.Drawing.Size(1000, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 110);
            this.panel1.TabIndex = 14;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.Cancel_Button.Enabled = false;
            this.Cancel_Button.Location = new System.Drawing.Point(932, 809);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(112, 35);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = false;
            this.Cancel_Button.Visible = false;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Inventory_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1270, 863);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Add_Card_Button);
            this.Controls.Add(this.Scan_Card_Button);
            this.Controls.Add(this.Page_Forward_Button);
            this.Controls.Add(this.Page_Back_Button);
            this.Controls.Add(this.InventoryCountLabel);
            this.Controls.Add(this.Cancel_Button);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Inventory_Menu";
            this.Text = "TCG Digitizer - Inventory";
            this.Load += new System.EventHandler(this.Inventory_Menu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scan_Card_Button;
        private System.Windows.Forms.Button Add_Card_Button;
        private System.Windows.Forms.TableLayoutPanel Card_Table_Panel;
        private System.Windows.Forms.Label InventoryCountLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button Page_Back_Button;
        private System.Windows.Forms.Button Page_Forward_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel_Button;
    }
}