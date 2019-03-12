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
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Add_Card_Button = new System.Windows.Forms.Button();
            this.Card_Table_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Date_Button = new System.Windows.Forms.Button();
            this.Mana_Button = new System.Windows.Forms.Button();
            this.Number_Button = new System.Windows.Forms.Button();
            this.Expansion_Button = new System.Windows.Forms.Button();
            this.Type_Button = new System.Windows.Forms.Button();
            this.Name_Button = new System.Windows.Forms.Button();
            this.Inventory_Checkbox = new System.Windows.Forms.CheckBox();
            this.InventoryCountLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.Page_Back_Button = new System.Windows.Forms.Button();
            this.Page_Forward_Button = new System.Windows.Forms.Button();
            this.Card_Table_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scan_Card_Button
            // 
            this.Scan_Card_Button.Location = new System.Drawing.Point(16, 30);
            this.Scan_Card_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Scan_Card_Button.Name = "Scan_Card_Button";
            this.Scan_Card_Button.Size = new System.Drawing.Size(100, 28);
            this.Scan_Card_Button.TabIndex = 0;
            this.Scan_Card_Button.Text = "Scan Card";
            this.Scan_Card_Button.UseVisualStyleBackColor = true;
            this.Scan_Card_Button.Click += new System.EventHandler(this.Scan_Card_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(723, 647);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(100, 28);
            this.OK_Button.TabIndex = 2;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(828, 647);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(100, 28);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Add_Card_Button
            // 
            this.Add_Card_Button.Location = new System.Drawing.Point(125, 30);
            this.Add_Card_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add_Card_Button.Name = "Add_Card_Button";
            this.Add_Card_Button.Size = new System.Drawing.Size(100, 28);
            this.Add_Card_Button.TabIndex = 5;
            this.Add_Card_Button.Text = "Add Card";
            this.Add_Card_Button.UseVisualStyleBackColor = true;
            this.Add_Card_Button.Click += new System.EventHandler(this.Add_Card_Button_Click);
            // 
            // Card_Table_Panel
            // 
            this.Card_Table_Panel.AutoScroll = true;
            this.Card_Table_Panel.AutoSize = true;
            this.Card_Table_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Card_Table_Panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Card_Table_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.Card_Table_Panel.Location = new System.Drawing.Point(16, 65);
            this.Card_Table_Panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Card_Table_Panel.MaximumSize = new System.Drawing.Size(1000, 492);
            this.Card_Table_Panel.Name = "Card_Table_Panel";
            this.Card_Table_Panel.RowCount = 1;
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.Card_Table_Panel.Size = new System.Drawing.Size(1000, 47);
            this.Card_Table_Panel.TabIndex = 6;
            // 
            // Date_Button
            // 
            this.Date_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Date_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Date_Button.Location = new System.Drawing.Point(882, 4);
            this.Date_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Date_Button.Name = "Date_Button";
            this.Date_Button.Size = new System.Drawing.Size(114, 39);
            this.Date_Button.TabIndex = 12;
            this.Date_Button.Text = "Date";
            this.Date_Button.UseVisualStyleBackColor = false;
            // 
            // Mana_Button
            // 
            this.Mana_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Mana_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mana_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mana_Button.Location = new System.Drawing.Point(762, 4);
            this.Mana_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Mana_Button.Name = "Mana_Button";
            this.Mana_Button.Size = new System.Drawing.Size(112, 39);
            this.Mana_Button.TabIndex = 11;
            this.Mana_Button.Text = "Mana";
            this.Mana_Button.UseVisualStyleBackColor = false;
            // 
            // Number_Button
            // 
            this.Number_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Number_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Number_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Number_Button.Location = new System.Drawing.Point(585, 4);
            this.Number_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Number_Button.Name = "Number_Button";
            this.Number_Button.Size = new System.Drawing.Size(169, 39);
            this.Number_Button.TabIndex = 10;
            this.Number_Button.Text = "Number";
            this.Number_Button.UseVisualStyleBackColor = false;
            // 
            // Expansion_Button
            // 
            this.Expansion_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Expansion_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Expansion_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Expansion_Button.Location = new System.Drawing.Point(408, 4);
            this.Expansion_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Expansion_Button.Name = "Expansion_Button";
            this.Expansion_Button.Size = new System.Drawing.Size(169, 39);
            this.Expansion_Button.TabIndex = 9;
            this.Expansion_Button.Text = "Expansion";
            this.Expansion_Button.UseVisualStyleBackColor = false;
            // 
            // Type_Button
            // 
            this.Type_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Type_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Type_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Type_Button.Location = new System.Drawing.Point(231, 4);
            this.Type_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Type_Button.Name = "Type_Button";
            this.Type_Button.Size = new System.Drawing.Size(169, 39);
            this.Type_Button.TabIndex = 8;
            this.Type_Button.Text = "Type";
            this.Type_Button.UseVisualStyleBackColor = false;
            // 
            // Name_Button
            // 
            this.Name_Button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Name_Button.Location = new System.Drawing.Point(54, 4);
            this.Name_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name_Button.Name = "Name_Button";
            this.Name_Button.Size = new System.Drawing.Size(169, 39);
            this.Name_Button.TabIndex = 7;
            this.Name_Button.Text = "Name";
            this.Name_Button.UseVisualStyleBackColor = false;
            // 
            // Inventory_Checkbox
            // 
            this.Inventory_Checkbox.AutoSize = true;
            this.Inventory_Checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Inventory_Checkbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inventory_Checkbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Inventory_Checkbox.Location = new System.Drawing.Point(4, 4);
            this.Inventory_Checkbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Inventory_Checkbox.Name = "Inventory_Checkbox";
            this.Inventory_Checkbox.Size = new System.Drawing.Size(42, 39);
            this.Inventory_Checkbox.TabIndex = 1;
            this.Inventory_Checkbox.UseVisualStyleBackColor = true;
            // 
            // InventoryCountLabel
            // 
            this.InventoryCountLabel.AutoSize = true;
            this.InventoryCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryCountLabel.Location = new System.Drawing.Point(719, 30);
            this.InventoryCountLabel.Name = "InventoryCountLabel";
            this.InventoryCountLabel.Size = new System.Drawing.Size(248, 25);
            this.InventoryCountLabel.TabIndex = 7;
            this.InventoryCountLabel.Text = "Cards in inventory: 4000";
            this.InventoryCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InventoryCountLabel.Click += new System.EventHandler(this.InventoryCountLabel_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(232, 30);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(100, 28);
            this.RefreshButton.TabIndex = 8;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Page_Back_Button
            // 
            this.Page_Back_Button.Location = new System.Drawing.Point(651, 647);
            this.Page_Back_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Page_Back_Button.Name = "Page_Back_Button";
            this.Page_Back_Button.Size = new System.Drawing.Size(31, 27);
            this.Page_Back_Button.TabIndex = 9;
            this.Page_Back_Button.Text = "<";
            this.Page_Back_Button.UseVisualStyleBackColor = true;
            this.Page_Back_Button.Click += new System.EventHandler(this.Page_Back_Button_Click);
            // 
            // Page_Forward_Button
            // 
            this.Page_Forward_Button.Location = new System.Drawing.Point(687, 647);
            this.Page_Forward_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Page_Forward_Button.Name = "Page_Forward_Button";
            this.Page_Forward_Button.Size = new System.Drawing.Size(31, 27);
            this.Page_Forward_Button.TabIndex = 10;
            this.Page_Forward_Button.Text = ">";
            this.Page_Forward_Button.UseVisualStyleBackColor = true;
            this.Page_Forward_Button.Click += new System.EventHandler(this.Page_Forward_Button_Click);
            // 
            // Inventory_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Add_Card_Button);
            this.Controls.Add(this.Scan_Card_Button);
            this.Controls.Add(this.Page_Forward_Button);
            this.Controls.Add(this.Page_Back_Button);
            this.Controls.Add(this.InventoryCountLabel);
            this.Controls.Add(this.Card_Table_Panel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Inventory_Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TCG Digitizer - Inventory";
            this.Load += new System.EventHandler(this.Inventory_Menu_Load);
            this.Card_Table_Panel.ResumeLayout(false);
            this.Card_Table_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scan_Card_Button;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Add_Card_Button;
        private System.Windows.Forms.TableLayoutPanel Card_Table_Panel;
        private System.Windows.Forms.CheckBox Inventory_Checkbox;
        private System.Windows.Forms.Button Name_Button;
        private System.Windows.Forms.Button Date_Button;
        private System.Windows.Forms.Button Mana_Button;
        private System.Windows.Forms.Button Number_Button;
        private System.Windows.Forms.Button Expansion_Button;
        private System.Windows.Forms.Button Type_Button;
        private System.Windows.Forms.Label InventoryCountLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button Page_Back_Button;
        private System.Windows.Forms.Button Page_Forward_Button;
    }
}