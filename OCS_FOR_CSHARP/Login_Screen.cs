/* -----------------------------------------------------------------------------
@
@ FILE NAME:         Login_Screen.cs
@
@ DESCRIPTION:       Provides a login screen UI for users to login to their
@                       their account. If the user is not logged in all other
@                       functionality is blocked.
@
@ COMPILATION:       Microsoft Visual Studio Community 2017
@
@ NOTES:             None
@
@ MODIFICATION HISTORY:
@
@ Author                Date           Modification(s)  Changes
@ -------------         -----------    ---------------  ---------------------
@ Christopher Cooper    05-06-2017     v 0.1            
@ Ryan Fox              05-06-2017     v 0.1
----------------------------------------------------------------------------- */

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

    /* -----------------------------------------------------------------------------
    @ CLASS NAME:       public partial class Login_Screen
    @
    @ PURPOSE:          Contains class used to display and operate login functionality
    @ 
    @ PARAM:            none
    @
    @ RETURNS:          none
    @ NOTES:            none
    ----------------------------------------------------------------------------- */
    public partial class Login_Screen : Form
    {
        private const int MAX_LOGIN_LENGTH = 15;
        public event ShowFrm evtFrm;

        /* -----------------------------------------------------------------------------
        @ FUNCTION NAME:    public Login_Screen()
        @
        @ PURPOSE:          Initialization of objects in form
        @                   
        @ PARAM:            none
        @
        @ RETURNS:          none
        @ NOTES:            none
        ----------------------------------------------------------------------------- */
        public Login_Screen()
        {
            InitializeComponent();
            login_button.Visible = true;
        }


        /* -----------------------------------------------------------------------------
        @ FUNCTION NAME:    private void login_button_Click(object sender, EventArgs e)
        @
        @ PURPOSE:          When Login button is clicked, user's input is checked against
        @                       user data stored in database.
        @                   
        @ PARAM:            not used
        @
        @ RETURNS:          none
        @ NOTES:            none
        ----------------------------------------------------------------------------- */
        private void login_button_Click(object sender, EventArgs e)
        {
            ErrorTextBox.Text = "";

            //username string length between 0 and MAX_LOGIN_LENGTH
            if (login_username_textbox.Text.Length > 0 && login_username_textbox.Text.Length <= MAX_LOGIN_LENGTH)
            {
                //password string length between 0 and MAX_LOGIN_LENGTH
                if (login_password_textbox.Text.Length > 0 && login_password_textbox.Text.Length <= MAX_LOGIN_LENGTH)
                {
                    //call database open connection
                    NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
                    connection.Open();

                    //database query
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.users WHERE login_name ILIKE '" + login_username_textbox.Text + "' AND login_pass ILIKE '" + login_password_textbox.Text + "'AND privilege_lvl > 0", connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    //if data was returned
                    if (reader.HasRows)
                    {
                        reader.Read();
                        CurrentUser.user_ID = System.Convert.ToInt32(reader[(int)DBuser.id].ToString());
                        CurrentUser.prvlg_lvl = System.Convert.ToInt32(reader[(int)DBuser.priv_lvl].ToString());
                        string username = reader[(int)DBuser.log_name].ToString();

                        //if an active user
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
