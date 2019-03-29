﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace OCS_FOR_CSHARP
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();

            //REMOVE IF NOT USED FOR UI IMPROVEMENTS 3/12
            //var designSize = this.ClientSize;
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.Size = designSize;

            login_label.Visible = true;
            login_username_textbox.Visible = true;
            user_name_label.Visible = true;
            login_password_textbox.Visible = true;
            password_label.Visible = true;
            login_button.Visible = true;
            logout_link.Visible = false;
            textBox1.Visible = true;

            //REMOVE FOR FINAL PRODUCT
            //login_username_textbox.Text = "admin";
            //login_password_textbox.Text = "admin";

            login_username_textbox.GotFocus += login_username_textbox_GotFocus;
            login_password_textbox.GotFocus += login_password_textbox_GotFocus;

            welcome_label.Visible = false;
            welcome_label.TextAlign = ContentAlignment.MiddleRight;

            //Final build should change all of these to false TEMP
            ScanButton.Enabled = true;
            InventoryButton.Enabled = true;
            SettingsButton.Enabled = true;

            CurrentUser.user_ID = 0;
            CurrentUser.prvlg_lvl = 0;
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
            var getImageForm = new Form1();
            getImageForm.ShowDialog();
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            var getImageForm = new Inventory_Menu();//Change to the Inventory viewer form
            getImageForm.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var getImageForm = new Settings();
            getImageForm.ShowDialog();

        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            if (ContactText.Visible == true)
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
            }    
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

        private void logout_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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
                            logout_link.Visible = true;

                            welcome_label.Text = "Welcome " + username;
                            welcome_label.Visible = true;

                            ScanButton.Enabled = true;
                            InventoryButton.Enabled = true;
                            SettingsButton.Enabled = true;

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
