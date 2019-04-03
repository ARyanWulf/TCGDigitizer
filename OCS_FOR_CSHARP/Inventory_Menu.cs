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

        public int display_lower;
        public int display_upper;
        public bool hold = false;
        public List<cardWrapper> id_list = new List<cardWrapper>();
        private List<cardWrapper> cards = new List<cardWrapper>();
        private TableLayoutPanel tempTable;

        public Inventory_Menu()
        {
            InitializeComponent();
            refreshTable();
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            var getImageForm = new Form1();//Change to the Inventory viewer form
            getImageForm.ShowDialog();
        }

        private void Add_Card_Button_Click(object sender, EventArgs e)
        {
            var getEditCardForm = new Edit_Card_Form();
            //getEditCardForm.inv_menu = this;
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
            tempTable = Card_Table_Panel;
            display_lower = 0;
            display_upper = 0;
            Page_Back_Button.Enabled = false;

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
                    card.count = System.Convert.ToInt32(reader[2].ToString());

                    cards.Add(card);
                }
            }
            connection.Close();

            string cmdhold = "";
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].count <= 0)
                {
                    cards.RemoveAt(i);
                    i--;
                }
                else if (i != 0)
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
            if (cards.Count != 0)
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE " + cmdhold, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
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

                        for (int i = 0; i < cards.Count; i++)
                        {
                            if (cards[i].card_ID == tempCard.cardID)
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

        public void refreshTable()
        {
            //yes
            //panel2.Visible = false;
            panel1.Visible = false;
            Size tempSize = panel1.MaximumSize;
            tempSize.Height = Height - 100;
            tempSize.Width = Card_Table_Panel.Width;
            panel1.MaximumSize = tempSize;
            //Card_Table_Panel.Visible = false;
            //Clear table and redraw
            Card_Table_Panel.Controls.Clear();
            //Card_Table_Panel.Padding = new Padding(0, 0, System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 0);
            Card_Table_Panel.RowCount = 0;
            Card_Table_Panel.Dock = DockStyle.None;
            Card_Table_Panel.AutoSize = true;
            Card_Table_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //Card_Table_Panel.AutoScroll = true;
            /*Card_Table_Panel.Controls.Add(new CheckBox { Name = "Inventory_Checkbox", CheckAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 0);
            Card_Table_Panel.Controls.Add(new Button { Name = "Name_Button", Text = "Name", Dock = DockStyle.Fill }, 1, 0);
            Card_Table_Panel.Controls.Add(new Button { Name = "Type_Button", Text = "Type", Dock = DockStyle.Fill }, 2, 0);
            Card_Table_Panel.Controls.Add(new Button { Name = "Expansion_Button", Text = "Expansion", Dock = DockStyle.Fill }, 3, 0);
            Card_Table_Panel.Controls.Add(new Button { Name = "Number_Button", Text = "Number", Dock = DockStyle.Fill }, 4, 0);
            Card_Table_Panel.Controls.Add(new Button { Name = "Mana_Button", Text = "Mana", Dock = DockStyle.Fill }, 5, 0);
            Card_Table_Panel.Controls.Add(new Button { Name = "Date_Button", Text = "Date", Dock = DockStyle.Fill }, 6, 0);*/


            cards = Get_Inventory();
            int cardCount = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = 0; j < cards[i].count; j++)
                {
                    cardCount++;
                }
            }
            InventoryCountLabel.Text = "Cards in inventory: " + cardCount;
            // initialize table to zero rows to be empty
            if (cards.Count - display_lower < 20) //If the amount of cards to be displayed on refresh is less than 20
            {
                display_upper = cards.Count;
            }
            else
            {
                display_upper = display_lower + 20;
            }
            int displayRange = display_upper - display_lower;
            int cardIndex = display_lower;
            Card_Table_Panel.RowCount += displayRange;
            /*
             * display count will be max 20 for the display limit
             * subtract 20 from the card count if the card count is greater than 20
             */

            // TO DO:
            // Cards remaining should also be re-initialized


            /* begin populating table, start at second row so the first row containing buttons is not overwritten */
            for (int i = 0; i < displayRange; i++)
            {
                //Card_Table_Panel.RowStyles[0].Height = 200;
                // create a new row for each card
                /* begin popluating rows with cards */
                // populate each row with a checkbox
                /* Currently not working, inventory table auto formats the column to be wider than it should be*/
                //Card_Table_Panel.RowCount++;
                Card_Table_Panel.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = 75 });

                CheckBox tempCheck = new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, Tag = cards[cardIndex] };
                tempCheck.CheckedChanged += new EventHandler(tempCheck_CheckedChanged);
                Card_Table_Panel.Controls.Add(tempCheck, 0, i);
                // card name
                Label tempLabel = new Label() { Text = cards[cardIndex].card.name, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 1, i);

                // database card type
                tempLabel = new Label() { Text = cards[cardIndex].card.type, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 2, i);

                // database card set expansion
                tempLabel = new Label() { Text = cards[cardIndex].card.setCode, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 3, i);

                // database card number/multiverse ID
                tempLabel = new Label() { Text = cards[cardIndex].card.number.ToString(), AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 4, i);

                // database card mana
                tempLabel = new Label() { Text = cards[cardIndex].card.manaCost, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 5, i);

                // database card date added
                tempLabel = new Label() { Text = cards[cardIndex].count.ToString(), AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 6, i);
                cardIndex++;
            }


            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

            //Card_Table_Panel.Visible = true;
            panel1.Visible = true;
            //panel2.Visible = true;
            if (cards.Count() > 20 && display_upper < cards.Count())
            {
                Page_Forward_Button.Enabled = true;
            }
            else
            {
                Page_Forward_Button.Enabled = false;
            }

            if (display_lower >= 20)
            {
                Page_Back_Button.Enabled = true;
            }
            else
            {
                Page_Back_Button.Enabled = false;
            }
        }

        public void addToInventory(cardWrapper newEntry)
        {
            Card_Table_Panel.RowCount++;

            Card_Table_Panel.Controls.Add(new Label() { Text = newEntry.card.name, AutoEllipsis = true }, 1, Card_Table_Panel.RowCount - 1);
            Card_Table_Panel.Controls.Add(new Label() { Text = newEntry.card.type, AutoEllipsis = true }, 2, Card_Table_Panel.RowCount - 1);
            Card_Table_Panel.Controls.Add(new Label() { Text = newEntry.card.setCode, AutoEllipsis = true }, 3, Card_Table_Panel.RowCount - 1);
            Card_Table_Panel.Controls.Add(new Label() { Text = newEntry.card.multiverseId.ToString(), AutoEllipsis = true }, 4, Card_Table_Panel.RowCount - 1);
            Card_Table_Panel.Controls.Add(new Label() { Text = newEntry.card.manaCost, AutoEllipsis = true }, 5, Card_Table_Panel.RowCount - 1);
            Card_Table_Panel.Controls.Add(new Label() { Text = "N/A", AutoEllipsis = true }, 6, Card_Table_Panel.RowCount - 1);
        }

        private void InventoryCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            //TopPanel.Visible = false;
            RefreshButton.Enabled = false;
            refreshTable();
            RefreshButton.Enabled = true;
            //TopPanel.Visible = true;
        }

        private void Page_Forward_Button_Click(object sender, EventArgs e)
        {
            display_lower += 20;
            refreshTable();
        }

        private void Page_Back_Button_Click(object sender, EventArgs e)
        {
            display_lower -= 20;
            refreshTable();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inventory_Menu_VisibleChanged(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void tempCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = (CheckBox)sender;
            id_list.Add((cardWrapper)temp.Tag);
            //InventoryCountLabel.Text = id_list[id_list.Count - 1].card_ID.ToString();
            populate((cardWrapper)temp.Tag);
        }

        private void tempLabel_Click(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            id_list.Add((cardWrapper)temp.Tag);
            //InventoryCountLabel.Text = id_list[id_list.Count - 1].card_ID.ToString();
            populate((cardWrapper)temp.Tag);
        }

        public void populate(cardWrapper input)
        {
            cardWrapper currentCard = input;

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
                    Card_Additional_TextBox.Text += currentCard.card.subtypes[i] + " ";

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

            if (currentCard.card.flavorText != null)
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

        private void Inventory_Menu_SizeChanged(object sender, EventArgs e)
        {
            refreshTable();
        }
    }
}


/*

     
*/
