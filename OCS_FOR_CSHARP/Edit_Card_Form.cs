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
        Form1 newForm;
        CardService service = new CardService();
        List<Card> middleMan;

        public Edit_Card_Form()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button(object sender, EventArgs e)
        {
            // Will have to change the name for "Form1" here if we change the name of it elsewhere
            
            newForm = new Form1();

            newForm.Show();
            newForm.callingForm = this;
            //newForm = new Form1();
        }

        // The save button is also binded to the enter key for the user
        private void Save_Button(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432; User Id=postgres; Password=tcgdigitizer; Database=postgres");
            connection.Open();

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
