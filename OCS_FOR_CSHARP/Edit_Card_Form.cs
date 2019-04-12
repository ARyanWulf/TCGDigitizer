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
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Utility;
using MtgApiManager.Lib.Dto;

namespace OCS_FOR_CSHARP
{
    public partial class Edit_Card_Form : Form
    {
        public cardWrapper currentCard = new cardWrapper();
        List<cardWrapper> cards = new List<cardWrapper>();
        Form1 getImageForm;
        CardService service = new CardService();
        string cardData;
        List<Card> middleMan;
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
        List<cardWrapper> databaseList = new List<cardWrapper>();
        private bool cardExists = false;
        Timer searchTimer = new Timer();
        List<cardWrapper> foundCards = new List<cardWrapper>();

        public Edit_Card_Form()
        {
            InitializeComponent();
            searchTimer.Tick += new EventHandler(searchEventHandler);
            searchTimer.Interval = 3000;
            searchTimer.Enabled = true;
            searchTimer.Stop();
        }

        private void Scan_Card_Button(object sender, EventArgs e)
        {
            // Will have to change the name for "Form1" here if we change the name of it elsewhere
            
            getImageForm = new Form1();

            getImageForm.Show();
            //getImageForm.callingForm = this;
            //getImageForm = new Form1();
        }

        // The save button is also binded to the enter key for the user
        private void Save_Button(object sender, EventArgs e)
        {
            if(!addToInventory())
            {
                MessageBox.Show("ERROR! Insufficient permissions.");
            }
            else
            {
                Close();
            }
        }

        // Visual Studio recommended to use "=> Close();" over the traditional brackets.
        // Either way works
        private void Cancel_Button(object sender, EventArgs e) => Close();
        /*{
            Close();
        }*/


        // nothing currently implemented yet
        private void Card_Display_PictureBox(object sender, EventArgs e)
        {

        }

        private void Foil_CheckBox(object sender, EventArgs e)
        {

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Card_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void Card_Flavor_Text_Label_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Card_PictureBox_Click(object sender, EventArgs e)
        {

        }

        

        public void populate(cardWrapper input)
        {
            currentCard = input;

            Name_Textbox.Text = currentCard.card.name;
            Card_Mana_Cost_TextBox.Text = currentCard.card.manaCost;
            Card_Type_TextBox.Text = currentCard.card.type;
            Card_Expansion_TextBox.Text = currentCard.card.setCode;
            textBox2.Text = currentCard.card.number;

            if (currentCard.card.subtypes != null)
            {
                Card_Additional_Label.Visible = true;
                Card_Additional_TextBox.Visible = true;
                for (int i = 0; i < currentCard.card.subtypes.Count; i++)
                    Card_Additional_TextBox.Text += currentCard.card.subtypes[i]+" ";
                    
            }
            else
            {
                Card_Additional_Label.Visible = false;
                Card_Additional_TextBox.Visible = false;
            }

            if (currentCard.card.power != null)
            {
                Card_Power_Label.Visible = true;
                Card_Power_TextBox.Visible = true;
                Card_Power_TextBox.Text = currentCard.card.power;
            }
            else
            {
                Card_Power_Label.Visible = false;
                Card_Power_TextBox.Visible = false;
            }

            if (currentCard.card.toughness != null)
            {
                Card_Toughness_Label.Visible = true;
                Card_Toughness_TextBox.Visible = true;
                Card_Toughness_TextBox.Text = currentCard.card.toughness;
            }
            else
            {
                Card_Toughness_Label.Visible = false;
                Card_Toughness_TextBox.Visible = false;
            }

            if (currentCard.card.text != null)
            {
                Card_Description_Label.Visible = true;
                Card_Description_TextBox.Visible = true;
                Card_Description_TextBox.Text = currentCard.card.text;
            }
            else
            {
                Card_Description_Label.Visible = false;
                Card_Description_TextBox.Visible = false;
            }

            if(currentCard.card.flavorText != null)
            {
                Card_Flavor_Text_Label.Visible = true;
                Card_Flavor_Text_TextBox.Visible = true;
                Card_Flavor_Text_TextBox.Text = currentCard.card.flavorText;
            }
            else
            {
                Card_Flavor_Text_Label.Visible = false;
                Card_Flavor_Text_TextBox.Visible = false;
            }

            //pictureBox1.Image = newForm.Display_Picture_Box.Image;

            /*if (currentCard.card.ImageUrl.OriginalString != null)
            {
                pictureBox1.Load(currentCard.card.ImageUrl.OriginalString);
            }*/
        }

        private void Enter()
        {
            databaseList.Clear();
            if (Name_Textbox.Text.Length != 0)
            {
                connection.Open();

                var str = "SELECT * FROM public.card WHERE card_name ILIKE '%" + Name_Textbox.Text + "%'";

                /*if(Card_Type_TextBox.Text != null)
                {
                    str += "AND card_type ILIKE '%" + Card_Type_TextBox.Text + "%'";
                }*/
                
                var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE card_name ILIKE '%" + Name_Textbox.Text + "%'", connection);
                
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string temp;
                    cardWrapper tempWrapper = new cardWrapper();
                    CardObject tempCard = new CardObject();
                    tempCard.cardID = System.Convert.ToInt32(reader[0].ToString());
                    tempCard.name = reader[2].ToString();
                    tempCard.type = reader[3].ToString();
                    tempCard.manaCost = reader[4].ToString();
                    tempCard.setCode = reader[5].ToString();
                    tempCard.multiverseId = System.Convert.ToInt32(reader[9].ToString());
                    tempCard.power = reader[10].ToString();
                    tempCard.toughness = reader[11].ToString();

                    temp = reader[13].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colors = temp.Split(',').ToList<string>();

                    temp = reader[14].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colorIdentity = temp.Split(',').ToList<string>();

                    tempCard.text = reader[15].ToString();
                    tempCard.convertedManaCost = float.Parse(reader[16].ToString());

                    tempCard.flavorText = reader[17].ToString();
                    tempCard.rarity = reader[18].ToString();
                    tempCard.borderColor = reader[19].ToString();
                    tempCard.loyalty = reader[20].ToString();
                    tempCard.artist = reader[21].ToString();
                    tempCard.number = reader[24].ToString();

                    tempWrapper.card = tempCard;

                    databaseList.Add(tempWrapper);
                }

                
                connection.Close();
            }
            else
            {
                cardExists = false;
            }

            if(databaseList.Count != 0)
            {
                cardExists = true;
                button2.Enabled = true;
                Name_Textbox.ReadOnly = true;
                populate(databaseList[0]);
            }
            else
            {
                Name_Textbox.Text = "Card not valid";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Enter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*Edit_Card_Form newEditForm = new Edit_Card_Form();
            newEditForm.Show();
            this.Dispose(false);*/
            button2.Enabled = false;
            Name_Textbox.Clear();
            Card_Type_TextBox.Clear();
            Card_Additional_TextBox.Clear();
            Card_Mana_Cost_TextBox.Clear();
            Card_Expansion_TextBox.Clear();
            Card_Description_TextBox.Clear();
            Card_Flavor_Text_TextBox.Clear();
            Card_Power_TextBox.Clear();
            Card_Toughness_TextBox.Clear();
            textBox2.Clear();
            Name_Textbox.ReadOnly = false;
        }

        private void Card_Description_TextBox_TextChanged(object sender, EventArgs e)
        {
            //push test
        }

        private void Card_Additional_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public bool addToInventory()
        {

            if (CurrentUser.prvlg_lvl > 0 && CurrentUser.prvlg_lvl < 5)
            {
                cardWrapper card = databaseList[0];
                bool exists = false;
                int inv_id;

                connection.Open();

                using (var cmd = new NpgsqlCommand("new_trans_event", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_foreign_card_id", card.card.cardID);
                    cmd.Parameters.AddWithValue("in_foreign_user_id", CurrentUser.user_ID);
                    cmd.Parameters.AddWithValue("in_datetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("in_trans_type", 1);

                    cmd.ExecuteScalar();
                }

                connection.Close();


                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory WHERE card_id = " + card.card.cardID, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();


                    if (reader.HasRows)
                    {
                        exists = true;
                    }
                }
                connection.Close();

                if (exists)
                {

                    connection.Open();
                    using (var cmd = new NpgsqlCommand("update_inv_count", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("in_foreign_card_id", card.card.cardID);
                        cmd.Parameters.AddWithValue("in_new_count", 1);

                        cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
                else
                {

                    connection.Open();
                    using (var cmd = new NpgsqlCommand("new_inv_event", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("in_foreign_card_id", card.card.cardID);
                        cmd.Parameters.AddWithValue("in_new_count", 1);

                        cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void searchEventHandler(Object myObject, EventArgs eventArgs)
        {
            searchTimer.Stop();
            foundCards.Clear();
            foundCards = findCardsWithName(SearchBox.Text);

            SearchBox.Items.Clear();

            for (int i = 0; i < foundCards.Count; i++)
            {
                SearchBox.Items.Add(foundCards[i].card.name + " " + foundCards[i].card.setCode);
            }

        }

        private List<cardWrapper> findCardsWithName(string cardName)
        {
            List<cardWrapper> returnList = new List<cardWrapper>();

            List<int> tempIDs = new List<int>();

            connection.Open();

            using (var cmd = new NpgsqlCommand("get_cards_containing_name", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("in_name", cardName);

                //tempID = 
                var reader = cmd.ExecuteReader();

                //if(reader.HasRows)

                while (reader.Read())
                {
                    string temp;
                    cardWrapper tempWrapper = new cardWrapper();
                    CardObject tempCard = new CardObject();
                    tempCard.cardID = Convert.ToInt32(reader[0].ToString());
                    tempCard.name = reader[2].ToString();
                    tempCard.type = reader[3].ToString();
                    tempCard.manaCost = reader[4].ToString();
                    tempCard.setCode = reader[5].ToString();
                    tempCard.multiverseId = Convert.ToInt32(reader[9].ToString());
                    tempCard.power = reader[10].ToString();
                    tempCard.toughness = reader[11].ToString();

                    temp = reader[13].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colors = temp.Split(',').ToList<string>();

                    temp = reader[14].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colorIdentity = temp.Split(',').ToList<string>();

                    tempCard.text = reader[15].ToString();
                    tempCard.convertedManaCost = float.Parse(reader[16].ToString());

                    tempCard.flavorText = reader[17].ToString();
                    tempCard.rarity = reader[18].ToString();
                    tempCard.borderColor = reader[19].ToString();
                    tempCard.loyalty = reader[20].ToString();
                    tempCard.artist = reader[21].ToString();
                    tempCard.number = reader[24].ToString();

                    tempWrapper.card = tempCard;

                    returnList.Add(tempWrapper);
                }
            }

            connection.Close();

            return returnList;
        }

        private void Name_Textbox_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox1.Text.Length == 0)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }*/
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if ((SearchBox.Text != "") && (SearchBox.Text.Length >= 3) && (SearchBox.SelectedText != SearchBox.Text))
            {
                searchTimer.Stop();
                searchTimer.Start();
            }
            else
            {
                searchTimer.Stop();
            }
        }
    }
}
