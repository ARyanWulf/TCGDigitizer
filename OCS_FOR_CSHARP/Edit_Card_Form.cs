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

        public Edit_Card_Form()
        {
            InitializeComponent();
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

            if(CurrentUser.prvlg_lvl > 0 && CurrentUser.prvlg_lvl < 5)
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("new_inv_event", connection))
                {

                }

                connection.Close();
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

        private void Card_Name_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void populate(cardWrapper input)
        {
            currentCard.card = input.card;

            Card_Name_TextBox.Text = currentCard.card.name;
            Card_Mana_Cost_TextBox.Text = currentCard.card.manaCost;
            Card_Type_TextBox.Text = currentCard.card.type;
            Card_Expansion_TextBox.Text = currentCard.set;
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

            if (Card_Name_TextBox.Text != null)
            {
                connection.Open();

                var str = "SELECT * FROM public.card WHERE card_name ILIKE '%" + Card_Name_TextBox.Text + "%'";

                /*if(Card_Type_TextBox.Text != null)
                {
                    str += "AND card_type ILIKE '%" + Card_Type_TextBox.Text + "%'";
                }*/
                
                var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE card_name ILIKE '%" + Card_Name_TextBox.Text + "%'", connection);
                
                NpgsqlDataReader reader = cmd.ExecuteReader();

                for (int i = 0; reader.Read(); i++)
                {
                    string temp;
                    cardWrapper tempWrapper = new cardWrapper();
                    CardObject tempCard = new CardObject();
                    tempCard.cardID = System.Convert.ToInt32(reader[0].ToString());
                    tempCard.name = reader[2].ToString();
                    tempCard.type = reader[3].ToString();
                    tempCard.manaCost = reader[4].ToString();
                    tempWrapper.set = reader[5].ToString();
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
                textBox1.Text = "Card not valid";
            }

            if(databaseList[0] != null)
            {
                populate(databaseList[0]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Enter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Edit_Card_Form newEditForm = new Edit_Card_Form();
            newEditForm.Show();
            this.Dispose(false);
        }

        private void Card_Description_TextBox_TextChanged(object sender, EventArgs e)
        {
            //push test
        }

        private void Card_Additional_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
