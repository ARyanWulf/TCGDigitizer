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
    public partial class Inventory_Menu : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
        string orderBy = "name";
        public int display_lower;
        public int display_upper;
        public bool ctrlPressed = false;
        private List<cardWrapper> cards = new List<cardWrapper>(); //holds cards in inventory
        private List<cardWrapper> needImageQueue = new List<cardWrapper>(); //holds cards that need images
        private TableLayoutPanel tempTable;
        bool search = false;
        bool searchAll = false;
        CardService service = new CardService();
        Timer resizeTimer = new Timer();
        Timer cardImageTimer = new Timer();
        Timer searchTimer = new Timer(); //time to wait before searching after searchbox textchanged
        cardWrapper currentCard;
        List<cardWrapper> selectedCards = new List<cardWrapper>();

        public Inventory_Menu()
        {
            InitializeComponent();
            Card_Image_Box.WaitOnLoad = false;
            Card_Image_Box.Image = Card_Image_Box.InitialImage;
            refreshTable();

            // Scan through every card and add each one to a queue if it needs a display image
            for(int i = 0; i < cards.Count; i++)
            {
                if(cards[i].card.imageURL == null || cards[i].card.imageURL == "")
                {
                    needImageQueue.Add(cards[i]);
                }
            }

            // Set the time delay between each time the inventory page is updated
            resizeTimer.Tick += new EventHandler(resizeEventHandler);
            resizeTimer.Interval = 1000;
            resizeTimer.Enabled = true;
            resizeTimer.Stop();

            // Set the time delay between each time a card image is pulled from the website
            cardImageTimer.Tick += new EventHandler(getCardImage);
            cardImageTimer.Interval = 5000;
            cardImageTimer.Enabled = true;
            cardImageTimer.Start();

            //initialize searchtimer properties
            searchTimer.Tick += new EventHandler(searchEventHandler);
            searchTimer.Interval = 1000;
            searchTimer.Enabled = true;
            searchTimer.Stop();

            searchBar.GotFocus += new EventHandler(cleartext);
            searchBar.LostFocus += new EventHandler(addText);
        }

        private void cleartext(object sender, EventArgs e)
        {
            if(searchBar.Text == "Search")
            {
                searchBar.Text = "";
            }
        }

        private void addText(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(searchBar.Text))
            {
                searchBar.Text = "Search";
            }
        }

        private void resizeEventHandler(object sender, EventArgs e)
        {
            resizeTimer.Stop();
            Card_Table_Panel.Visible = true;
            refreshTable();
        }

        private void searchEventHandler(object myObject, EventArgs eventArgs)
        {
            searchTimer.Stop();
            cards.Clear();
            display_lower = 0;
            search = true;
            refreshTable();
        }

        // Give an image preview to every card that was put into the needImageQueue
        private void getCardImage(object sender, EventArgs e)
        {
            cardImageTimer.Stop();
            if(needImageQueue.Count > 0)
            {
                var tempCard = needImageQueue[0];
                needImageQueue.RemoveAt(0);
                try
                {
                    var imageURL = service.
                        Where(x => x.Set, tempCard.card.setCode).
                        Where(y => y.Number, tempCard.card.number).
                        All().Value[0].ImageUrl.OriginalString;
                    add_image(tempCard.card_ID, imageURL);
                    tempCard.card.imageURL = imageURL;
                }
                catch (Exception ex)
                {
                }
                cardImageTimer.Start();
            }
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            var getImageForm = new Form1(); // Change to the Inventory viewer form
            getImageForm.ShowDialog();
        }

        private void Add_Card_Button_Click(object sender, EventArgs e)
        {
            var getEditCardForm = new Edit_Card_Form();
            getEditCardForm.ShowDialog();
        }

        // Called on form initialization
        private void Inventory_Menu_Load(object sender, EventArgs e)
        {
            tempTable = Card_Table_Panel;
            display_lower = 0;
            display_upper = 0;
            Page_Back_Button.Enabled = false;

        }

        // Helper function for getCardImage. Queries the website to grab the official
        // preview image for each MTG card
        private void add_image(int in_id, string in_url)
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand("add_card_image", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("in_id", in_id);
                cmd.Parameters.AddWithValue("in_url", in_url);

                cmd.ExecuteScalar();
            }
            connection.Close();
        }

        // Helper function for refresh_table().
        // Grabs the inventory of cards from the local database
        private List<cardWrapper> Get_Inventory()
        {
            // create list of cards
            List<cardWrapper> Cards = new List<cardWrapper>();

            List<int> cardQuantity = new List<int>();
            List<int> cardIDs = new List<int>();

            // open connection to server
            connection.Open();

            /*
             * return entire inventory table, go through it,
             * populate cards inside list with their card IDs,
             * check for duplicates
             * query the database again, looking for those same card IDs within the database
             * go back to the system so it can read all the return data from the database so
             * it can be returned to the calling function
             */
            if (searchAll && search)
            {
                using (var cmd = new NpgsqlCommand("get_all_cards_containing_string", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_name", searchBar.Text);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read() && cardIDs.Count < 20)
                    {
                        cardIDs.Add(System.Convert.ToInt32(reader[0].ToString()));
                        try
                        {
                            cardQuantity.Add(System.Convert.ToInt32(reader[1].ToString()));
                        }
                        catch
                        {
                            cardQuantity.Add(0);
                        }
                    }
                }
            }
            else if(search)
            {
                using (var cmd = new NpgsqlCommand("get_inventory_cards_containing_string", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_name", searchBar.Text);

                    var reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        cardIDs.Add(System.Convert.ToInt32(reader[0].ToString()));
                        cardQuantity.Add(System.Convert.ToInt32(reader[1].ToString()));
                    }
                }
            }
            else
            {
                using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory", connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cardIDs.Add(System.Convert.ToInt32(reader[1].ToString()));
                        cardQuantity.Add(System.Convert.ToInt32(reader[2].ToString()));
                    }
                }
            }
            connection.Close();

            // Adjust query for all cards
            if (!searchAll)
            {
                for (int i = 0; i < cardIDs.Count; i++)
                {
                    if (cardQuantity[i] <= 0)
                    {
                        cardIDs.RemoveAt(i);
                        cardQuantity.RemoveAt(i);
                        i--;
                    }
                }
            }
            
            // Check that inventory has cards
            if (cardIDs.Count != 0)
            {
                Cards = getCards(cardIDs);

            }

            for (int i = 0; i < Cards.Count; i++)
            {
                Cards[i].count = cardQuantity[cardIDs.IndexOf(Cards[i].card.cardID)];
            }

            return Cards;
        }


        private List<cardWrapper> getCards(List<int> cardIDs)
        {
            List<cardWrapper> Cards = new List<cardWrapper>();

                connection.Open();

                using (var cmd = new NpgsqlCommand("get_inv_by_" + orderBy, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_ids", cardIDs);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string temp;
                        cardWrapper tempWrapper = new cardWrapper();
                        CardObject tempCard = new CardObject();
                        tempWrapper.card_ID = tempCard.cardID = System.Convert.ToInt32(reader[0].ToString());
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
                        tempCard.imageURL = reader[25].ToString();

                        tempWrapper.card = tempCard;

                        Cards.Add(tempWrapper);
                    }


                }

                connection.Close();

            return Cards;
        }

        public void refreshTable()
        {
            Card_Table_Panel.Visible = false;
            
            //Clear table and redraw
            Card_Table_Panel.Controls.Clear();
            Card_Table_Panel.Padding = new Padding(0, 0, System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 0);
            Card_Table_Panel.RowCount = 0;
            Card_Table_Panel.AutoSize = true;
            Card_Table_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Card_Table_Panel.AutoScroll = true;

            //get list of cards
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
            if(displayRange != 0)
                Card_Table_Panel.RowCount += displayRange - 1;
            /*
             * display count will be max 20 for the display limit
             * subtract 20 from the card count if the card count is greater than 20
             */

            // begin populating table, start at second row so the first row containing buttons is not overwritten
            for (int i = 0; i < displayRange; i++)
            {
                // create a new row for each card
                // begin popluating rows with cards 
                // populate each row with a checkbox
                Card_Table_Panel.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = 75 });

                // card name
                Label tempLabel = new Label() { Text = cards[cardIndex].card.name, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 0, i);

                // database card type
                tempLabel = new Label() { Text = cards[cardIndex].card.type, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 1, i);

                // database card set expansion
                tempLabel = new Label() { Text = cards[cardIndex].card.setCode, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 2, i);

                // database card number/multiverse ID
                tempLabel = new Label() { Text = cards[cardIndex].card.number.ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 3, i);

                // database card mana
                tempLabel = new Label() { Text = cards[cardIndex].card.manaCost, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 4, i);

                // database card date added
                tempLabel = new Label() { Text = cards[cardIndex].count.ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = cards[cardIndex] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Card_Table_Panel.Controls.Add(tempLabel, 5, i);
                cardIndex++;
            }
            
            // Each page of the inventory displays only 20 unique cards per page.
            // Check to see if a new page needs to be created if there are more than 20 unique cards
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

            Card_Table_Panel.Visible = true;
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshButton.Enabled = false;
            refreshTable();
            RefreshButton.Enabled = true;
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

        // Populate the right side of the panel
        private void tempLabel_Click(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            currentCard = (cardWrapper)temp.Tag;
            populate((cardWrapper)temp.Tag);
            int rowNumber = Card_Table_Panel.GetRow((Label)sender);
            if (ctrlPressed)
            {
                for (int i = 0; i < Card_Table_Panel.RowCount; i++) // Cycle through rows
                {
                    if (i == rowNumber && Card_Table_Panel.GetControlFromPosition(0, i).BackColor == Color.FromArgb(45, 49, 57))
                    {
                        for (int j = 0; j < Card_Table_Panel.ColumnCount; j++) // Cycle through columns of selected row
                        {
                            Card_Table_Panel.GetControlFromPosition(j, rowNumber).BackColor = Color.FromArgb(65, 70, 78);
                        }
                        selectedCards.Add(currentCard);
                        i = Card_Table_Panel.RowCount - 1;
                    }
                    else if (i == rowNumber && Card_Table_Panel.GetControlFromPosition(0, i).BackColor == Color.FromArgb(65, 70, 78))
                    {
                        for (int j = 0; j < Card_Table_Panel.ColumnCount; j++) // Cycle through columns of selected row
                        {
                            Card_Table_Panel.GetControlFromPosition(j, rowNumber).BackColor = Color.FromArgb(45, 49, 57);
                        }
                        if (selectedCards.Contains(currentCard))
                        {
                            selectedCards.Remove(currentCard);
                        }
                        i = Card_Table_Panel.RowCount - 1;
                    }
                }
            }
            else
            {
                selectedCards.Clear();
                for (int i = 0; i < Card_Table_Panel.RowCount; i++) // Cycle through rows
                {
                    if (i == rowNumber)
                    {
                        for (int j = 0; j < Card_Table_Panel.ColumnCount; j++) // Cycle through columns of selected row
                        {
                            Card_Table_Panel.GetControlFromPosition(j, rowNumber).BackColor = Color.FromArgb(65, 70, 78);
                        }
                        selectedCards.Add(currentCard);
                    }
                    else
                    {
                        for (int j = 0; j < Card_Table_Panel.ColumnCount; j++) // Cycle through columns of other rows
                        {
                            Card_Table_Panel.GetControlFromPosition(j, i).BackColor = Color.FromArgb(45, 49, 57);
                        }
                    }
                }
            }
            Card_Table_Panel.Refresh();
        }

        // Populate the inventory table
        public void populate(cardWrapper input)
        {
            cardWrapper currentCard = input;
            Card_Image_Box.Image = null;

            try
            {
                Card_Image_Box.Load(currentCard.card.imageURL);
            }
            catch
            {
                Card_Image_Box.Image = Card_Image_Box.InitialImage;
            }

            Name_Textbox.Text = currentCard.card.name;
            Card_Mana_Cost_TextBox.Text = currentCard.card.manaCost;
            Card_Type_TextBox.Text = currentCard.card.type;
            Card_Expansion_TextBox.Text = currentCard.card.setCode;
            Card_Number_Textbox.Text = currentCard.card.number;

            if (currentCard.card.power != null && currentCard.card.power != "n/a")
            {
                Card_Power_Label.Visible = true;
                card_loyalty_label.Visible = false;
                Card_Power_TextBox.Visible = true;
                Card_Power_TextBox.Text = currentCard.card.power + "/" + currentCard.card.toughness;
            }
            else if (currentCard.card.loyalty != null && currentCard.card.loyalty != "n/a")
            {
                Card_Power_Label.Visible = false;
                card_loyalty_label.Visible = true;
                Card_Power_TextBox.Visible = true;
                Card_Power_TextBox.Text = currentCard.card.loyalty;
            }
            else
            {
                Card_Power_Label.Visible = false;
                Card_Power_TextBox.Visible = false;
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




        }

        private void Inventory_Menu_SizeChanged(object sender, EventArgs e)
        {
            Card_Table_Panel.Visible = false;
            resizeTimer.Stop();
            resizeTimer.Start();
        }

        private void Inventory_Menu_ResizeBegin(object sender, EventArgs e)
        {
            Card_Table_Panel.Visible = false;
        }

        private void Inventory_Menu_ResizeEnd(object sender, EventArgs e)
        {
            Card_Table_Panel.Visible = true;
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

        private void PlusButton_Click(object sender, EventArgs e)
        {
            addToInventory(1);
            refreshTable();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            addToInventory(-1);
            refreshTable();
        }

        private void Name_Button_Click(object sender, EventArgs e)
        {
            if (orderBy == "name")
            {
                orderBy = "name_desc";
            }
            else
            {
                orderBy = "name";
            }
            refreshTable();
        }

        private void Type_Button_Click(object sender, EventArgs e)
        {
            if (orderBy == "type")
            {
                orderBy = "type_desc";
            }
            else
            {
                orderBy = "type";
            }
            refreshTable();

        }

        private void Expansion_Button_Click(object sender, EventArgs e)
        {
            if (orderBy == "set")
            {
                orderBy = "set_desc";
            }
            else
            {
                orderBy = "set";
            }
            refreshTable();

        }

        private void Number_Button_Click(object sender, EventArgs e)
        {
            if (orderBy == "set_num")
            {
                orderBy = "set_num_desc";
            }
            else
            {
                orderBy = "set_num";
            }
            refreshTable();

        }

        private void Mana_Button_Click(object sender, EventArgs e)
        {
            if (orderBy == "cmc")
            {
                orderBy = "cmc_desc";
            }
            else
            {
                orderBy = "cmc";
            }
            refreshTable();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {


            if ((searchBar.Text == "" || searchBar.Text == "Search") && !searchAll)
            {
                search = false;
                refreshTable();
            }
            else if (searchBar.Text.Length > 3)
            {
                searchTimer.Stop();
                searchTimer.Start();
            }
            else
            {
                searchTimer.Stop();
            }
        }

        private void Show_All_Cards_Button_Click(object sender, EventArgs e)
        {
            if (!searchAll)
            {
                Show_All_Cards_Button.Text = "Hide Cards Not In Inventory";
                searchAll = !searchAll;
                if (searchBar.Text.Length > 3)
                {
                    refreshTable();
                }
            }
            else if (searchAll)
            {
                Show_All_Cards_Button.Text = "Show Cards Not In Inventory";
                searchAll = !searchAll;
                refreshTable();
            }
        }
    }
}
