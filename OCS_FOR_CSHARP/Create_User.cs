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
    public partial class Create_User : Form
    {
        private int user_id;
        private int trans_type;
        private int currentUser = 1;//REMOVE WHEN MASTER IS MERGED 2/24/19 change function calls in settings.cs as well to reflect this

        public Create_User(int ttype, int user)
        {
            user_id = user;
            trans_type = ttype;

            InitializeComponent();


            if (trans_type == (int)UserProfile.edit)
            {
                Edit_User();
            }
        }

        private void Edit_User()
        {

            NpgsqlConnection con = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM public.users WHERE user_id = " + user_id, con);
            NpgsqlDataReader reader = com.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                error_textbox.Visible = true;
                error_textbox.Text = "Change User Fields";

                //filling in fields with database user information
                fname_textbox.Text = reader[(int)DB_user.fname].ToString();
                lname_textbox.Text = reader[(int)DB_user.lname].ToString();
                privilege_dropdown.SelectedIndex = (System.Convert.ToInt32(reader[(int)DB_user.priv_lvl].ToString())-1);
                
                //if current user is editing their own user profile
                if (user_id == currentUser)
                {
                    username_textbox.Text = reader[(int)DB_user.login].ToString();
                }
            }

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void fname_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lname_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passconf_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            int privilege = -2;
            bool creationFail = false;
            error_textbox.Visible = true;
            error_textbox.Text = "";

            //First Name length checks
            if (fname_textbox.Text.Length > 35)
            {
                creationFail = true;
                error_textbox.AppendText("* First name maximum length is 35 characters.");
            }
            else if (fname_textbox.Text.Length == 0)
            {
                creationFail = true;
                error_textbox.AppendText("* Must enter a First Name.");
            }
            else { }//no problem

            //Last Name length checks
            if (lname_textbox.Text.Length > 35)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Last name maximum length is 35 characters.");
            }
            else if (lname_textbox.Text.Length == 0)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Must enter a Last Name.");
            }

            //Privilege Level Checks
            if (privilege_dropdown.Text.Length > 0)
            {
                privilege = privilege_dropdown.Text[0] - 48; //gets int from privilege dropdown. ascii arth
            }
            else
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Must select a privilege level for this user.");
            }

            //Username checks
            if (username_textbox.Text.Length > 15)
            { 
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Username maximum length is 15 characters.");
            }
            else if (username_textbox.Text.Length == 0)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Must enter a User Name");
            }

            //Password tests
            if (pass_textbox.Text.Length > 30)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Password maximum length is 30 characters.");
            }
            else if (pass_textbox.Text.Length == 0)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Must enter a Password.");
            }
            else if (passconf_textbox.Text.Length == 0)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Please Confirm Your Password.");
            }
            else if (pass_textbox.Text != passconf_textbox.Text)
            {
                if (creationFail == true)
                {
                    error_textbox.AppendText(Environment.NewLine);
                }
                creationFail = true;
                error_textbox.AppendText("* Confirmation does not match Password.");
            }
            else
            {
                NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
                connection.Open();

                NpgsqlCommand command;

                if (trans_type == (int)UserProfile.add)
                {
                    command = new NpgsqlCommand("SELECT * FROM public.users WHERE login_name ILIKE '" + username_textbox.Text + "' AND privilege_lvl > 0", connection);
                }
                else //if (trans_type == (int)UserProfile.edit)
                {
                    command = new NpgsqlCommand("SELECT * FROM public.users WHERE login_name ILIKE '" + username_textbox.Text + "' AND privilege_lvl > 0 AND user_id != " + user_id, connection);
                }
                //else if (trans_type == (int)UserProfile.delete)
                //{ 
                    //SOMETHING 
                //}
                //else
                //{
                    //error state
                //}

                NpgsqlDataReader reader = command.ExecuteReader();
                
                //if database has a user with the same login name
                if (reader.HasRows)
                {
                    if (creationFail == true)
                    {
                        error_textbox.AppendText(Environment.NewLine);
                    }
                    creationFail = true;
                    error_textbox.AppendText("* Username already in use.");
                }
                connection.Close();


                //Success
                if (!creationFail)
                {
                    connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
                    connection.Open();
                    using (var cmd = new NpgsqlCommand("newuser", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_time_created", DateTime.Now);
                        cmd.Parameters.AddWithValue("in_fname", fname_textbox.Text);
                        cmd.Parameters.AddWithValue("in_lname", lname_textbox.Text);
                        cmd.Parameters.AddWithValue("in_priv_lvl", privilege);
                        cmd.Parameters.AddWithValue("in_login", username_textbox.Text);
                        cmd.Parameters.AddWithValue("in_pass", pass_textbox.Text);

                        cmd.ExecuteScalar();
                    }
                    connection.Close();
                    Close();

                    if (trans_type == (int)UserProfile.edit)
                    {
                        connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
                        connection.Open();
                        command = new NpgsqlCommand("UPDATE users SET privilege_lvl = -1, time_created = ('"+DateTime.Now.ToString()+"'::timestamp) WHERE user_id = " + user_id, connection);
                        command.ExecuteNonQuery();
                        //command = new NpgsqlCommand("UPDATE inventory Set user_id = "newuserid" WHERE user_id = "olduserid)//////////////////YOU ENDED HERE. FIX INVENTORY/USER LINK LOSS WHEN EDITING USER PROFILE
                        connection.Close();
                    }


                }
                else //Failure
                {
                }

            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void error_textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
