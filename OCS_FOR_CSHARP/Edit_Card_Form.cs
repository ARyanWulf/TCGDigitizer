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

    /*
     * This form is depreciated and is no longer in use
     * It will not receive future updates but will remain in the solution as possible reference material
     */
    public partial class Edit_Card_Form : Form
    {
        public cardWrapper currentCard = new cardWrapper(); //holds currently displayed card
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer"); //creates connection to postreSQL database
        Timer searchTimer = new Timer(); //time to wait before searching after searchbox textchanged
        List<cardWrapper> foundCards = new List<cardWrapper>(); //list of cards found from search

        public Edit_Card_Form()
        {
            InitializeComponent();

            //initialize searchtimer properties
            searchTimer.Tick += new EventHandler(searchEventHandler);
            searchTimer.Interval = 1000;
            searchTimer.Enabled = true;
            searchTimer.Stop();

            Add_Card_Button.Enabled = false;
            Remove_Card_Button.Enabled = false;
        }

        // The save button is also binded to the enter key for the user
        private void Save_Button(object sender, EventArgs e)
        {
            //add current card to inventory
            if(!addToInventory(1))
            {
                MessageBox.Show("ERROR! Insufficient permissions.");
            }
            else
            {
                Add_Card_Button.Enabled = false;
                Remove_Card_Button.Enabled = false;
                Add_Card_Button.Text = "Added";
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

        
        //populates data fields with card information
        public void populate(cardWrapper input)
        {
            currentCard = input;

            Name_Textbox.Text = currentCard.card.name;
            Card_Mana_Cost_TextBox.Text = currentCard.card.manaCost;
            Card_Type_TextBox.Text = currentCard.card.type;
            Card_Expansion_TextBox.Text = currentCard.card.setCode;
            Card_Number_Textbox.Text = currentCard.card.number;

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

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Card_Button.Enabled = false;
            Name_Textbox.Clear();
            Card_Type_TextBox.Clear();
            Card_Additional_TextBox.Clear();
            Card_Mana_Cost_TextBox.Clear();
            Card_Expansion_TextBox.Clear();
            Card_Description_TextBox.Clear();
            Card_Flavor_Text_TextBox.Clear();
            Card_Power_TextBox.Clear();
            Card_Toughness_TextBox.Clear();
            Card_Number_Textbox.Clear();
            Name_Textbox.ReadOnly = false;
        }

        public bool addToInventory(int transType)
        {

            if (CurrentUser.prvlg_lvl > 0 && CurrentUser.prvlg_lvl < 5)
            {
                cardWrapper card = currentCard;
                bool exists = false;

                connection.Open();

                using (var cmd = new NpgsqlCommand("new_trans_event", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_foreign_card_id", card.card.cardID);
                    cmd.Parameters.AddWithValue("in_foreign_user_id", CurrentUser.user_ID);
                    cmd.Parameters.AddWithValue("in_datetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("in_trans_type", transType);

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
                        cmd.Parameters.AddWithValue("in_new_count", transType);

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
                        cmd.Parameters.AddWithValue("in_new_count", transType);

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

        private void searchEventHandler(object myObject, EventArgs eventArgs)
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

                var reader = cmd.ExecuteReader();

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

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            Add_Card_Button.Enabled = true;
            Remove_Card_Button.Enabled = true;
            Add_Card_Button.Text = "Add to Inventory";
            Remove_Card_Button.Text = "Remove from Inventory";
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
        
        //called when a card is selected in searchbox
        private void SearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shows delete button
            Remove_Card_Button.Enabled = true;

            //shows add button
            Add_Card_Button.Enabled = true;

            //populates card data
            populate(foundCards[SearchBox.SelectedIndex]);
        }

        private void Remove_Card_Button_Click(object sender, EventArgs e)
        {
            if (!addToInventory(-1))
            {
                MessageBox.Show("ERROR! Insufficient permissions.");
            }
            else
            {
                Add_Card_Button.Enabled = false;
                Remove_Card_Button.Enabled = false;
                Remove_Card_Button.Text = "Removed";
            }
        }
    }
}
