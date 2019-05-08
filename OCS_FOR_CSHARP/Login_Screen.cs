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

        // When Login button is clicked, user's input is checked against user data stored in database
        private void login_button_Click(object sender, EventArgs e)
        {
            ErrorTextBox.Text = "";

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
                            evtFrm();
                        }
                        else
                        {
                            CurrentUser.user_ID = 0;
                            CurrentUser.prvlg_lvl = 0;
                            ErrorTextBox.AppendText("Unforeseen Error - Returned Deleted");
                        }

                    }
                    else
                    {
                        ErrorTextBox.AppendText("Username/Password Doesn't Match");
                    }

                }
                else
                {
                    ErrorTextBox.AppendText("Password Range Error");
                }
            }
            else
            {
                ErrorTextBox.AppendText("Username Range Error");
            }
        }
    }
}
