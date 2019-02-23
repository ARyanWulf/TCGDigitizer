namespace OCS_FOR_CSHARP
{
    partial class Review
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Card_Table_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Date_Button = new System.Windows.Forms.Button();
            this.Mana_Button = new System.Windows.Forms.Button();
            this.Number_Button = new System.Windows.Forms.Button();
            this.Expansion_Button = new System.Windows.Forms.Button();
            this.Type_Button = new System.Windows.Forms.Button();
            this.Name_Button = new System.Windows.Forms.Button();
            this.Inventory_Checkbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.Card_Table_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scan_Card_Button
            // 
            this.Scan_Card_Button.Location = new System.Drawing.Point(12, 24);
            this.Scan_Card_Button.Name = "Scan_Card_Button";
            this.Scan_Card_Button.Size = new System.Drawing.Size(75, 23);
            this.Scan_Card_Button.TabIndex = 0;
            this.Scan_Card_Button.Text = "Scan Card";
            this.Scan_Card_Button.UseVisualStyleBackColor = true;
            this.Scan_Card_Button.Click += new System.EventHandler(this.Scan_Card_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(632, 415);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 2;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(713, 415);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
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
            this.Card_Table_Panel.Location = new System.Drawing.Point(12, 53);
            this.Card_Table_Panel.MaximumSize = new System.Drawing.Size(750, 400);
            this.Card_Table_Panel.Name = "Card_Table_Panel";
            this.Card_Table_Panel.RowCount = 1;
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Card_Table_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Card_Table_Panel.Size = new System.Drawing.Size(750, 34);
            this.Card_Table_Panel.TabIndex = 7;
            this.Card_Table_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Table_Panel_Paint);
            // 
            // Date_Button
            // 
            this.Date_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date_Button.Location = new System.Drawing.Point(661, 5);
            this.Date_Button.Name = "Date_Button";
            this.Date_Button.Size = new System.Drawing.Size(84, 24);
            this.Date_Button.TabIndex = 12;
            this.Date_Button.Text = "Date";
            this.Date_Button.UseVisualStyleBackColor = true;
            // 
            // Mana_Button
            // 
            this.Mana_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mana_Button.Location = new System.Drawing.Point(571, 5);
            this.Mana_Button.Name = "Mana_Button";
            this.Mana_Button.Size = new System.Drawing.Size(82, 24);
            this.Mana_Button.TabIndex = 11;
            this.Mana_Button.Text = "Mana";
            this.Mana_Button.UseVisualStyleBackColor = true;
            // 
            // Number_Button
            // 
            this.Number_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Number_Button.Location = new System.Drawing.Point(439, 5);
            this.Number_Button.Name = "Number_Button";
            this.Number_Button.Size = new System.Drawing.Size(124, 24);
            this.Number_Button.TabIndex = 10;
            this.Number_Button.Text = "Number";
            this.Number_Button.UseVisualStyleBackColor = true;
            // 
            // Expansion_Button
            // 
            this.Expansion_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Expansion_Button.Location = new System.Drawing.Point(307, 5);
            this.Expansion_Button.Name = "Expansion_Button";
            this.Expansion_Button.Size = new System.Drawing.Size(124, 24);
            this.Expansion_Button.TabIndex = 9;
            this.Expansion_Button.Text = "Expansion";
            this.Expansion_Button.UseVisualStyleBackColor = true;
            // 
            // Type_Button
            // 
            this.Type_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Type_Button.Location = new System.Drawing.Point(175, 5);
            this.Type_Button.Name = "Type_Button";
            this.Type_Button.Size = new System.Drawing.Size(124, 24);
            this.Type_Button.TabIndex = 8;
            this.Type_Button.Text = "Type";
            this.Type_Button.UseVisualStyleBackColor = true;
            // 
            // Name_Button
            // 
            this.Name_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_Button.Location = new System.Drawing.Point(43, 5);
            this.Name_Button.Name = "Name_Button";
            this.Name_Button.Size = new System.Drawing.Size(124, 24);
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
            this.Inventory_Checkbox.Size = new System.Drawing.Size(30, 24);
            this.Inventory_Checkbox.TabIndex = 1;
            this.Inventory_Checkbox.UseVisualStyleBackColor = true;
            this.Inventory_Checkbox.CheckedChanged += new System.EventHandler(this.Inventory_Checkbox_CheckedChanged);
            // 
            // Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Card_Table_Panel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Scan_Card_Button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Review";
            this.Text = "TCG Digitizer - Scan Review";
            this.Load += new System.EventHandler(this.Review_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Card_Table_Panel.ResumeLayout(false);
            this.Card_Table_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scan_Card_Button;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel Card_Table_Panel;
        private System.Windows.Forms.Button Date_Button;
        private System.Windows.Forms.Button Mana_Button;
        private System.Windows.Forms.Button Number_Button;
        private System.Windows.Forms.Button Expansion_Button;
        private System.Windows.Forms.Button Type_Button;
        private System.Windows.Forms.Button Name_Button;
        private System.Windows.Forms.CheckBox Inventory_Checkbox;
    }
}