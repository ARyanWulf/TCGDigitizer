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
    public partial class Inventory_Menu : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");

        public Inventory_Menu()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            var getImageForm = new Form1();//Change to the Inventory viewer form
            getImageForm.ShowDialog();
        }

        private void Add_Card_Button_Click(object sender, EventArgs e)
        {
            var getEditCardForm = new Edit_Card_Form();
            getEditCardForm.ShowDialog();
        }

        // TODO:
        // When OK button is pressed, if current changes are not saved
        // prompt user to save changes
        // else, close
        private void OK_Button_Click(object sender, EventArgs e) => Close();

        private void Cancel_Button_Click(object sender, EventArgs e) => Close();

        // TODO:
        // Use the cards List<cardWrapper> to
        // populate the inventory list for the user.
        private void Inventory_Menu_Load(object sender, EventArgs e)
        {
            List<cardWrapper> cards = Get_Inventory();

            // initialize table to zero rows to be empty
            Card_Table_Panel.RowCount = 1;

            /*
             * display count will be max 20 for the display limit
             * subtract 20 from the card count if the card count is greater than 20
             */



            int cardsRemaining = cards.Count;
            int displayCount = cardsRemaining;
            if (cardsRemaining > 20)
            {
                cardsRemaining -= 20;
                displayCount = 20;
            }

            // TO DO:
            // Add refresh button to refresh the table
            // clicking the save button for the add new card should also refresh the table
            // Cards remaining should also be re-initialized


            /* begin populating table, start at second row so the first row containing buttons is not overwritten */
            for (int i = 1; i < displayCount + 1; i++)
            {
                // create a new row for each card
                Card_Table_Panel.RowCount++;

                /* begin popluating rows with cards */

                // populate each row with a checkbox
                /* Currently not working, inventory table auto formats the column to be wider than it should be*/
                //Card_Table_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter }, 0, Card_Table_Panel.RowCount - 1);

                // card name
                Card_Table_Panel.Controls.Add(new Label() { Text = cards[i-1].card.name, AutoEllipsis = true }, 1, Card_Table_Panel.RowCount - 1);

                // database card type
                Card_Table_Panel.Controls.Add(new Label() { Text = cards[i-1].card.type, AutoEllipsis = true }, 2, Card_Table_Panel.RowCount - 1);

                // database card set expansion
                Card_Table_Panel.Controls.Add(new Label() { Text = cards[i-1].set, AutoEllipsis = true }, 3, Card_Table_Panel.RowCount - 1);

                // database card number/multiverse ID
                Card_Table_Panel.Controls.Add(new Label() { Text = cards[i-1].card.multiverseId.ToString(), AutoEllipsis = true }, 4, Card_Table_Panel.RowCount - 1);

                // database card mana
                Card_Table_Panel.Controls.Add(new Label() { Text = cards[i-1].card.manaCost, AutoEllipsis = true }, 5, Card_Table_Panel.RowCount - 1);

                // database card date added
                Card_Table_Panel.Controls.Add(new Label() { Text = "N/A", AutoEllipsis = true }, 6, Card_Table_Panel.RowCount - 1);

            }
            AutoScroll = true;


        }

        private void Card_Table_Panel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        /*
        List of variables returned:
            *
        */
        private List<cardWrapper> Get_Inventory()
        {
            // create list of cards
            List<cardWrapper> cards = new List<cardWrapper>();

            // open connection to server
            connection.Open();

            // return entire inventory table, go through it,
            // populate cards inside list with their card IDs,
            // check for duplicates
            // query the database again, looking for those same card IDs within the database
            // go back to the system so it can read all the return data from the database so
            // it can be returned to the calling function
            using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory", connection))
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cardWrapper card = new cardWrapper();
                    card.card_ID = System.Convert.ToInt32(reader[1].ToString());
                    card.count = System.Convert.ToInt32(reader[4].ToString());

                    if (cards.Contains(card))
                    {
                        cards[cards.IndexOf(card)].count += card.count;
                    }
                    else
                    {
                        cards.Add(card);
                    }
                }
            }
            connection.Close();

            string cmdhold = "";
            for (int i = 0; i < cards.Count; i++)
            {
                if(cards[i].count <= 0)
                {
                    cards.RemoveAt(i);
                    i--;
                }
                else if(i != 0)
                {
                    cmdhold += "OR card_id = " + cards[i].card_ID;
                }
                else
                {
                    cmdhold = "card_id = " + cards[i].card_ID;
                }
            }


            // TO DO:
            // add ability to grab card expansion
            if(cards.Count != 0)
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE " + cmdhold, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        string temp;
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

                        for(int i = 0; i < cards.Count; i++)
                        {
                            if(cards[i].card_ID == tempCard.cardID)
                            {
                                cards[i].card = tempCard;
                            }
                        }
                    }
                }
                connection.Close();
                

            }
           

            return cards;
        }
    }
}


/*

     
*/
