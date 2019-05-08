using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace OCS_FOR_CSHARP
{
    public partial class Main_Menu : Form
    {
        get_image_form scan_form;
        Inventory_Menu inventory_form;
        Settings settings_form;
        Product_Info product_info;
        bool product_info_clicked = false;

        public Main_Menu()
        {
            InitializeComponent();


            // Disable scan button, inventory button, and settings button until a valid user logs in
            ScanButton.Enabled = false;
            ScanButton.Image = OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_black_64;
            
            InventoryButton.Enabled = false;
            InventoryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_black_64;

            SettingsButton.Enabled = false;
            SettingsButton.Image = OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_black_64;

            logout_link.Enabled = false;
            Login_Screen();

            CurrentUser.user_ID = 0;
            CurrentUser.prvlg_lvl = 0;
        }

        // Loads Login form into Slot Panel
        private void Login_Screen()
        {
            Slot_Panel.Controls.Clear();
            Login_Screen login_prompt = new Login_Screen();
            login_prompt.evtFrm += new ShowFrm(logged_in);
            login_prompt.TopLevel = false;
            Slot_Panel.Controls.Add(login_prompt);
            login_prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            login_prompt.Dock = DockStyle.Fill;
            login_prompt.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
            login_prompt.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            login_prompt.Show();
        }

        // Valid user successfully logged in; unlock the scan, inventory, and settings button
        void logged_in()
        {
            Slot_Panel.Controls.Clear();

            ScanButton.Enabled = true;
            ScanButton.Image = OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_silver_64;

            InventoryButton.Enabled = true;
            InventoryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_silver_64;

            SettingsButton.Enabled = true;
            SettingsButton.Image = OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_silver_64;

            logout_link.Enabled = true;
        }


        // Loads the Scan form into Slot panel
        private void ScanButton_Click(object sender, EventArgs e)
        {

            ResetButtonColors();
            ScanButton.BackColor = Color.FromArgb(65, 70, 78);

            Slot_Panel.Controls.Clear();
            if (scan_form == null|| scan_form.IsDisposed)
            {
                scan_form = new get_image_form();
            }
            scan_form.TopLevel = false;
            Slot_Panel.Controls.Add(scan_form);
            scan_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            scan_form.Dock = DockStyle.Fill;
            scan_form.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
            scan_form.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            scan_form.Show();
        }

        // Loads Inventory form into slot panel
        private void InventoryButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            InventoryButton.BackColor = Color.FromArgb(65, 70, 78);

            Slot_Panel.Controls.Clear();
            if(inventory_form == null || inventory_form.IsDisposed)
            {
                inventory_form = new Inventory_Menu();
            }

            inventory_form.TopLevel = false;
            Slot_Panel.Controls.Add(inventory_form);
            inventory_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            inventory_form.Dock = DockStyle.Fill;
            inventory_form.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
            inventory_form.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            inventory_form.Show();
            inventory_form.refreshTable();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            //loads Inventory form into panel 2
            ResetButtonColors();
            SettingsButton.BackColor = Color.FromArgb(65, 70, 78);

            Slot_Panel.Controls.Clear();
            if(settings_form == null || settings_form.IsDisposed)
            {
                settings_form = new Settings();
            }

            settings_form.TopLevel = false;
            Slot_Panel.Controls.Add(settings_form);
            settings_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            settings_form.Dock = DockStyle.Fill;
            settings_form.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
            settings_form.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            settings_form.Show();

        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ContactButton.BackColor = Color.FromArgb(65, 70, 78);
            product_info_clicked = !product_info_clicked;
            Slot_Panel.Controls.Clear();
            if (product_info_clicked || CurrentUser.user_ID != 0)
            {
                if (product_info == null || product_info.IsDisposed)
                {
                    product_info = new Product_Info();
                }

                product_info.TopLevel = false;
                Slot_Panel.Controls.Add(product_info);
                product_info.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                product_info.Dock = DockStyle.Fill;
                product_info.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
                product_info.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
                product_info.Show();
            }
            else if (!product_info_clicked && CurrentUser.user_ID == 0)
            {
                ResetButtonColors();
                Login_Screen();
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

 

 

        private void logout_link_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetButtonColors();
            Login_Screen();

            ScanButton.Enabled = false;
            ScanButton.Image = OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_black_64;
            

            InventoryButton.Enabled = false;
            InventoryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_black_64;

            SettingsButton.Enabled = false;
            SettingsButton.Image = OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_black_64;

            CurrentUser.user_ID = 0;
            CurrentUser.prvlg_lvl = 0;
            logout_link.Enabled = false;
        }

        private void ResetButtonColors()
        {
            var defaultColor = Color.FromArgb(40, 44, 52);
            ScanButton.BackColor = defaultColor;
            InventoryButton.BackColor = defaultColor;
            ContactButton.BackColor = defaultColor;
            SettingsButton.BackColor = defaultColor;
        }
    }


    static class CurrentUser
    {
        private static int _user_ID = 0;
        private static int _prvlg_lvl = 0;

        public static int user_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        public static int prvlg_lvl
        {
            get { return _prvlg_lvl; }
            set { _prvlg_lvl = value; }
        }
    }
}
