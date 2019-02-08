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

        public Edit_Card_Form()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button(object sender, EventArgs e)
        {
            // Will have to change the name for "Form1" here if we change the name of it elsewhere
            
            getImageForm = new Form1();

            getImageForm.Show();
            getImageForm.callingForm = this;
            //getImageForm = new Form1();
        }

        // The save button is also binded to the enter key for the user
        private void Save_Button(object sender, EventArgs e)
        {

            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=postgres");
            connection.Open();
            Card newCard = currentCard.card;

            using (var cmd = new NpgsqlCommand("newCard", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_time", DateTime.Now);
                cmd.Parameters.AddWithValue("in name", newCard.Name);
                cmd.Parameters.AddWithValue("in_mana", newCard.ManaCost);
                cmd.Parameters.AddWithValue("in_cmc", newCard.Cmc);
                cmd.Parameters.AddWithValue("in_colors", newCard.Colors);
                cmd.Parameters.AddWithValue("in_identity", newCard.ColorIdentity);
                cmd.Parameters.AddWithValue("in_set", newCard.Set);
                cmd.Parameters.AddWithValue("in_num", newCard.Number);
                cmd.Parameters.AddWithValue("in_rarity", newCard.Rarity);
                cmd.Parameters.AddWithValue("in_border", newCard.Border);
                cmd.Parameters.AddWithValue("in_multi", newCard.MultiverseId);
                cmd.Parameters.AddWithValue("in_type", newCard.Type);
                cmd.Parameters.AddWithValue("in_types", newCard.Types);
                cmd.Parameters.AddWithValue("in_subtypes", newCard.SubTypes);
                cmd.Parameters.AddWithValue("in_supertypes", newCard.SuperTypes);
                cmd.Parameters.AddWithValue("in_text", newCard.Text);
                cmd.Parameters.AddWithValue("in_flavor", newCard.Flavor);
                cmd.Parameters.AddWithValue("in_power", newCard.Power);
                cmd.Parameters.AddWithValue("in_tough", newCard.Toughness);
                cmd.Parameters.AddWithValue("in_loyalty", newCard.Loyalty);
                cmd.Parameters.AddWithValue("in_artist", newCard.Artist);
                cmd.Parameters.AddWithValue("in_foil", currentCard.foil);
                cmd.Parameters.AddWithValue("in_prerelease", currentCard.prerelease);
                cmd.Parameters.AddWithValue("in_location", "n/a");

                cmd.ExecuteScalar();
            }
            /*
             * INSERT INTO "Card"(card_id, created_at, card_name, card_type, card_subtype, mana_cost, expansion, card_power, card_toughness, set_num, foil, prerelease, physical_location, multiverse_id)
	            VALUES
		            (1, in_time, in_name, in_type, in_subtype, in_mana, in_expansion, in_power, in_toughness, in_set_num, in_foil, in_prerelease, in_location, in_multi);
             */
            //NpgsqlCommand npgsqlCommand = new NpgsqlCommand("ALTER TABLE public." + '"' + "Card" + '"' + "ADD COLUMN " + '"' + "Name" + '"' + " character(32)[];");
            //npgsqlCommand.Connection = connection;
            //NpgsqlCommandBuilder npgsqlCommandBuilder = new NpgsqlCommandBuilder();
            //npgsqlCommand.ExecuteNonQuery();
            connection.Close();
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

            Card_Name_TextBox.Text = currentCard.card.Name;
            Card_Mana_Cost_TextBox.Text = currentCard.card.ManaCost;
            Card_Type_TextBox.Text = currentCard.card.Type;
            Card_Expansion_TextBox.Text = currentCard.card.SetName;
            textBox2.Text = currentCard.card.Number;

            if (currentCard.card.SubTypes != null)
            {
                Card_Additional_Label.Visible = true;
                Card_Additional_TextBox.Visible = true;
                for (int i = 0; i < currentCard.card.SubTypes.Length; i++)
                    Card_Additional_TextBox.Text = currentCard.card.SubTypes[i];
            }
            else
            {
                Card_Additional_Label.Visible = false;
                Card_Additional_TextBox.Visible = false;
            }

            if (currentCard.card.Power != null)
            {
                Card_Power_Label.Visible = true;
                Card_Power_TextBox.Visible = true;
                Card_Power_TextBox.Text = currentCard.card.Power;
            }
            else
            {
                Card_Power_Label.Visible = false;
                Card_Power_TextBox.Visible = false;
            }

            if (currentCard.card.Toughness != null)
            {
                Card_Toughness_Label.Visible = true;
                Card_Toughness_TextBox.Visible = true;
                Card_Toughness_TextBox.Text = currentCard.card.Toughness;
            }
            else
            {
                Card_Toughness_Label.Visible = false;
                Card_Toughness_TextBox.Visible = false;
            }

            if (currentCard.card.Text != null)
            {
                Card_Description_Label.Visible = true;
                Card_Description_TextBox.Visible = true;
                Card_Description_TextBox.Text = currentCard.card.Text;
            }
            else
            {
                Card_Description_Label.Visible = false;
                Card_Description_TextBox.Visible = false;
            }

            if(currentCard.card.Flavor != null)
            {
                Card_Flavor_Text_Label.Visible = true;
                Card_Flavor_Text_TextBox.Visible = true;
                Card_Flavor_Text_TextBox.Text = currentCard.card.Flavor;
            }
            else
            {
                Card_Flavor_Text_Label.Visible = false;
                Card_Flavor_Text_TextBox.Visible = false;
            }

            if(currentCard.card.SuperTypes != null)
            {
                Card_Type_TextBox.Text = currentCard.card.SuperTypes + " " + Card_Type_TextBox.Text;
            }

            //pictureBox1.Image = newForm.Display_Picture_Box.Image;
            pictureBox1.Load(currentCard.card.ImageUrl.OriginalString);
        }

        private void Enter()
        {
            if (Card_Name_TextBox.Text != null)
            {
                var result = service.Where(x => x.Name, Card_Name_TextBox.Text);
                middleMan = result.All().Value;
                if (middleMan.Count < 1)
                {
                    Card_Name_TextBox.Text = "Card not valid";
                }
                else if (middleMan.Count > 1)
                {
                    for (int i = 0; i < middleMan.Count; i++)
                    {
                        if (middleMan[i].Name == Card_Name_TextBox.Text)
                        {
                            if (currentCard.card == null || currentCard.card.Name != middleMan[i].Name)
                                currentCard.card = middleMan[i];
                            else
                                currentCard.printing.Add(middleMan[i].Set);
                        }
                    }
                    cards.Add(currentCard);
                }
                else
                {
                    currentCard.card = middleMan[0];
                    cards.Add(currentCard);
                }
            }
            else
            {
                textBox1.Text = "Card not valid";
            }

            if(currentCard.card != null)
            {
                populate(currentCard);
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
    }
}
