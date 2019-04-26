using System;
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
    public delegate void ShowFrm();
    public partial class Login_Screen : Form
    {
        public event ShowFrm evtFrm;
        public Login_Screen()
        {
            InitializeComponent();
            login_button.Visible = true;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //string pass_mask = "";

            if (login_username_textbox.Text.Length > 0 && login_username_textbox.Text.Length <= 15)
            {

                if (login_password_textbox.Text.Length > 0 && login_password_textbox.Text.Length <= 30)
                {

                    NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
                    connection.Open();


                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.users WHERE login_name ILIKE '" + "ccooper"/*login_username_textbox.Text*/ + "' AND login_pass ILIKE '" + "ccowner"/*login_password_textbox.Text*/ + "'AND privilege_lvl > 0", connection);
                    NpgsqlDataReader reader = command.ExecuteReader();


                    if (reader.HasRows)
                    {
                        reader.Read();
                        CurrentUser.user_ID = System.Convert.ToInt32(reader[(int)DBuser.id].ToString());
                        CurrentUser.prvlg_lvl = System.Convert.ToInt32(reader[(int)DBuser.priv_lvl].ToString());
                        string username = reader[(int)DBuser.log_name].ToString();

                        if (CurrentUser.user_ID > 0 && CurrentUser.prvlg_lvl > 0)
                        {
                            /*login_label.Visible = false;
                            login_username_textbox.Visible = false;
                            user_name_label.Visible = false;
                            login_password_textbox.Visible = false;
                            password_label.Visible = false;
                            login_button.Visible = false;
                            textBox1.Visible = false;

                            //logout_link.Visible = true;
                            //welcome_label.Text = "Welcome " + username;
                            //welcome_label.Visible = true;

                            Main_Menu.ActiveUser
                            Main_Menu.ScanButton.Enabled = true;
                            InventoryButton.Enabled = true;
                            SettingsButton.Enabled = true;
                            */
                            //login_username_textbox.Text = "";
                            //login_password_textbox.Text = "";
                            evtFrm();
                        }
                        else
                        {
                            CurrentUser.user_ID = 0;
                            CurrentUser.prvlg_lvl = 0;
                            textBox1.AppendText("Unforeseen Error - Returned Deleted");
                          
                        }

                    }
                    else
                    {
                        textBox1.AppendText("Username/Password Doesn't Match");
                       
                    }

                }
                else
                {
                    textBox1.AppendText("Password Range Error");
                   
                }
            }
            else
            {
                textBox1.AppendText("Username Range Error");
                ;
            }
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
