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
        Form1 scan_form;
        Inventory_Menu inventory_form;
        Settings settings_form;
        Edit_Card_Form edit_form;
        Product_Info product_info;
        bool product_info_clicked = false;

        public Main_Menu()
        {
            InitializeComponent();

            //REMOVE IF NOT USED FOR UI IMPROVEMENTS 3/12
            //var designSize = this.ClientSize;
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.Size = designSize;

            //login_label.Visible = true;
            //login_username_textbox.Visible = true;
            //user_name_label.Visible = true;
            //login_password_textbox.Visible = true;
            //password_label.Visible = true;
            //login_button.Visible = true;
            //logout_link.Visible = false;
            //textBox1.Visible = true;

            //REMOVE FOR FINAL PRODUCT
            //login_username_textbox.Text = "admin";
            //login_password_textbox.Text = "admin";

            login_username_textbox.GotFocus += login_username_textbox_GotFocus;
            login_password_textbox.GotFocus += login_password_textbox_GotFocus;

            //welcome_label.Visible = false;
            //welcome_label.TextAlign = ContentAlignment.MiddleRight;

            //Final build should change all of these to false TEMP
            ScanButton.Enabled = false;
            ScanButton.Image = OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_black_64;

            ManualEntryButton.Enabled = false;
            ManualEntryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_flat_black_64;

            InventoryButton.Enabled = false;
            InventoryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_black_64;

            SettingsButton.Enabled = false;
            SettingsButton.Image = OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_black_64;

            logout_link.Enabled = false;
            Login_Screen();

            CurrentUser.user_ID = 0;
            CurrentUser.prvlg_lvl = 0;
        }

        public bool ActiveUser
        {
            get
            {
                return ScanButton.Enabled;
            }
            set
            {
                ScanButton.Enabled = value;
                InventoryButton.Enabled = value;
                SettingsButton.Enabled = value;
                ManualEntryButton.Enabled = value;
            }
        }
        /*REMOVE IF NOT USED FOR UI IMPROVEMENTS 3/12
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        */

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

        void logged_in()
        {
            Slot_Panel.Controls.Clear();

            ScanButton.Enabled = true;
            ScanButton.Image = OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_silver_64;

            ManualEntryButton.Enabled = true;
            ManualEntryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_flat_silver_64;

            InventoryButton.Enabled = true;
            InventoryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_silver_64;

            SettingsButton.Enabled = true;
            SettingsButton.Image = OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_silver_64;

            logout_link.Enabled = true;

            // change button colors to silver from black to show they are enabled
        }

        private void login_username_textbox_GotFocus(object sender, EventArgs e)
        {
            login_username_textbox.Clear();
        }

        private void login_password_textbox_GotFocus(object sender, EventArgs e)
        {
            login_password_textbox.Clear();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            //var getImageForm = new Form1();
            //getImageForm.ShowDialog();

            //loads Scan form into panel 2
            ResetButtonColors();
            ScanButton.BackColor = Color.FromArgb(65, 70, 78);

            Slot_Panel.Controls.Clear();
            if (scan_form == null|| scan_form.IsDisposed)
            {
                scan_form = new Form1();
            }
            scan_form.TopLevel = false;
            Slot_Panel.Controls.Add(scan_form);
            scan_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            scan_form.Dock = DockStyle.Fill;
            scan_form.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
            scan_form.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            scan_form.Show();
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            //var getImageForm = new Inventory_Menu();//Change to the Inventory viewer form
            //getImageForm.ShowDialog();

            //loads Inventory form into panel 2
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
            //var getImageForm = new Settings();
            //getImageForm.ShowDialog();

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
            /*if (ContactText.Visible == true)
            {
                ContactText.Visible = false;
                CloseTextButton.Visible = false;

                if (CurrentUser.user_ID == 0)
                {
                    login_label.Visible = true;
                    login_username_textbox.Visible = true;
                    user_name_label.Visible = true;
                    login_password_textbox.Visible = true;
                    password_label.Visible = true;
                    login_button.Visible = true;
                    textBox1.Visible = true;
                }
            }
            else
            {
                ContactText.Visible = true;
                CloseTextButton.Visible = true;

                if (CurrentUser.user_ID == 0)
                {
                    login_label.Visible = false;
                    login_username_textbox.Visible = false;
                    user_name_label.Visible = false;
                    login_password_textbox.Visible = false;
                    password_label.Visible = false;
                    login_button.Visible = false;
                    textBox1.Visible = false;
                }
            }    */
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContactText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CloseTextButton_Click(object sender, EventArgs e)
        {
            ContactText.Visible = false;
            CloseTextButton.Visible = false;

            if (CurrentUser.user_ID == 0)
            {
                login_label.Visible = true;
                login_username_textbox.Visible = true;
                user_name_label.Visible = true;
                login_password_textbox.Visible = true;
                password_label.Visible = true;
                login_button.Visible = true;
                textBox1.Visible = true;
            }
        }

        private void login_label_Click(object sender, EventArgs e)
        {

        }

        private void login_username_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void user_name_label_Click(object sender, EventArgs e)
        {

        }

        private void login_password_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_label_Click(object sender, EventArgs e)
        {

        }

        // broken one, use the logout_link_LinkClicked1 further below
        private void logout_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetButtonColors();

            login_label.Visible = true;
            login_username_textbox.Visible = true;
            user_name_label.Visible = true;
            login_password_textbox.Visible = true;
            password_label.Visible = true;
            login_button.Visible = true;
            logout_link.Visible = false;
            textBox1.Visible = true;
            welcome_label.Visible = false;

            ContactText.Visible = false;
            CloseTextButton.Visible = false;

            ScanButton.Enabled = false;
            InventoryButton.Enabled = false;
            SettingsButton.Enabled = false;

            CurrentUser.user_ID = 0;
            CurrentUser.prvlg_lvl = 0;



        }

        private void login_button_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string pass_mask = "";
            for (int i = 0; i < login_password_textbox.Text.Length; i++)
            {
                pass_mask += "*";
            }
            if (login_username_textbox.Text.Length > 0 && login_username_textbox.Text.Length <= 15)
            {
              
                if (login_password_textbox.Text.Length > 0 && login_password_textbox.Text.Length <= 30)
                {

                    NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
                    connection.Open();


                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.users WHERE login_name ILIKE '" + login_username_textbox.Text + "' AND login_pass ILIKE '" + login_password_textbox.Text + "'AND privilege_lvl > 0", connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                
                    if (reader.HasRows)
                    {
                        reader.Read();
                        CurrentUser.user_ID = System.Convert.ToInt32(reader[(int)DBuser.id].ToString());
                        CurrentUser.prvlg_lvl = System.Convert.ToInt32(reader[(int)DBuser.priv_lvl].ToString());
                        string username = reader[(int)DBuser.log_name].ToString();

                        if (CurrentUser.user_ID > 0 && CurrentUser.prvlg_lvl > 0)
                        {
                            login_label.Visible = false;
                            login_username_textbox.Visible = false;
                            user_name_label.Visible = false;
                            login_password_textbox.Visible = false;
                            password_label.Visible = false;
                            login_button.Visible = false;
                            textBox1.Visible = false;
                            welcome_label.Text = "Welcome " + username;
                            welcome_label.Visible = true;

                            //ScanButton.Enabled = true;
                            //InventoryButton.Enabled = true;
                            //SettingsButton.Enabled = true;

                            login_username_textbox.Text = "";
                            login_password_textbox.Text = "";
                        }
                        else
                        {
                            CurrentUser.user_ID = 0;
                            CurrentUser.prvlg_lvl = 0;
                            textBox1.AppendText("Unforeseen Error - Returned Deleted");
                            login_password_textbox.Text = pass_mask;
                        }

                    }
                    else
                    {
                        textBox1.AppendText("Username/Password Doesn't Match");
                        login_password_textbox.Text = pass_mask;
                    }
                    
                }
                else
                {
                    textBox1.AppendText("Password Range Error");
                    login_password_textbox.Text = pass_mask;
                }
            }
            else
            {
                textBox1.AppendText("Username Range Error");
                login_password_textbox.Text = pass_mask;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void tcgdigitizer_logo_label_Click(object sender, EventArgs e)
        {

        }

        private void login_password_textbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void login_button_Click_1(object sender, EventArgs e)
        {

        }

        private void login_label_Click_1(object sender, EventArgs e)
        {

        }

        private void LogoPicture_Click(object sender, EventArgs e)
        {

        }
        /**/
        private void user_name_label_Click_1(object sender, EventArgs e)
        {

        }

        private void password_label_Click_1(object sender, EventArgs e)
        {

        }

        private void login_username_textbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ContactText_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CloseTextButton_Click_1(object sender, EventArgs e)
        {

        }

        private void welcome_label_Click(object sender, EventArgs e)
        {

        }

        private void logout_link_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*login_label.Visible = true;
            login_username_textbox.Visible = true;
            user_name_label.Visible = true;
            login_password_textbox.Visible = true;
            password_label.Visible = true;
            login_button.Visible = true;
            logout_link.Visible = false;
            textBox1.Visible = true;
            welcome_label.Visible = false;*/
            ResetButtonColors();
            Login_Screen();

            ContactText.Visible = false;
            CloseTextButton.Visible = false;

            ScanButton.Enabled = false;
            ScanButton.Image = OCS_FOR_CSHARP.Properties.Resources.scan_icon_flat_black_64;

            ManualEntryButton.Enabled = false;
            ManualEntryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_flat_black_64;

            InventoryButton.Enabled = false;
            InventoryButton.Image = OCS_FOR_CSHARP.Properties.Resources.manual_icon_2_flat_black_64;

            SettingsButton.Enabled = false;
            SettingsButton.Image = OCS_FOR_CSHARP.Properties.Resources.settings_icon_flat_black_64;

            CurrentUser.user_ID = 0;
            CurrentUser.prvlg_lvl = 0;
            logout_link.Enabled = false;
        }


        private void ManualEntryButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ManualEntryButton.BackColor = Color.FromArgb(65, 70, 78);
            Slot_Panel.Controls.Clear();
            if(edit_form == null || edit_form.IsDisposed)
            {
                edit_form = new Edit_Card_Form();
            }

            edit_form.TopLevel = false;
            Slot_Panel.Controls.Add(edit_form);
            edit_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            edit_form.Dock = DockStyle.Fill;
            edit_form.Size = new Size(Slot_Panel.Width, Slot_Panel.Height);
            edit_form.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            edit_form.Show();
        }

        private void ResetButtonColors()
        {
            var defaultColor = Color.FromArgb(40, 44, 52);
            ManualEntryButton.BackColor = defaultColor;
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
