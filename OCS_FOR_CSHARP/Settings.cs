using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Npgsql;

namespace OCS_FOR_CSHARP
{
    public partial class Settings : Form
    {
        private List<userWrapper> users = new List<userWrapper>(); //list of users that will be used to populate the table
        private userWrapper currentUser = new userWrapper(); //currently selected user used for editing/deleting users
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer"); //creates connection to local postgreSQL database

        //runs at form creation
        public Settings()
        {
            InitializeComponent();
            Populate_Settings_List();
        }


        private void DefualtButton_Click(object sender, EventArgs e)
        {
            List<int> cardIDs = new List<int>();
            List<int> cardQuantity = new List<int>();
            List<cardWrapper> cards = new List<cardWrapper>();

            //Reset settings to default values
            connection.Open();
            using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory", connection))
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cardIDs.Add(System.Convert.ToInt32(reader[1].ToString()));
                    cardQuantity.Add(System.Convert.ToInt32(reader[2].ToString()));
                }
            }
            connection.Close();

            cards = getCards(cardIDs);

            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].count = cardQuantity[cardIDs.IndexOf(cards[i].card.cardID)];
            }

            connection.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM transactions WHERE transaction_id >= 0", connection))
            {
                cmd.ExecuteScalar();
            }
            connection.Close();

            connection.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM inventory WHERE inventory_id >= 0", connection))
            {
                cmd.ExecuteScalar();
            }
            connection.Close();

            connection.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM card WHERE card_id >= 0", connection))
            {
                cmd.ExecuteScalar();
            }
            connection.Close();

            Load_Card_Button_Click(this, System.EventArgs.Empty);

            cardIDs.Clear();
            cardQuantity.Clear();

            for(int i =0; i < cards.Count; i++)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("get_card_with_name", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_name", cards[i].card.name);
                    cardIDs.Add((int)cmd.ExecuteScalar());
                    cardQuantity.Add(cards[i].count);
                }
                connection.Close();
            }

            for(int i = 0; i < cardIDs.Count; i++)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("new_inv_event", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_foreign_card_id", cardIDs[i]);
                    cmd.Parameters.AddWithValue("in_new_count", cardQuantity[i]);

                    cmd.ExecuteScalar();
                }
                connection.Close();
            }
        }

        public List<cardWrapper> getCards(List<int> cardIDs)
        {
            List<cardWrapper> Cards = new List<cardWrapper>();

            connection.Open();

            using (var cmd = new NpgsqlCommand("get_inv_by_name", connection))
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

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            //Delete all data

            Close();
        }

        private void users_panel(object sender, PaintEventArgs e)
        {

        }

        /* Autopopulates users table a list of current users that exist in the system
         * resets table size
         * gets list of users
         * sets length that the table should be displaying
         * creates and populates a row for each user  in the table
         */
        public void Populate_Settings_List()
        {
            //Clears table and redraws it
            Users_Panel.Controls.Clear();
            Users_Panel.RowCount = 0;
            Users_Panel.Dock = DockStyle.None;
            Users_Panel.AutoSize = true;
            Users_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            //retrieves list of users from database
            users = Get_Users();

            //sets length that the table should be displaying
            int displayRange = users.Count; //holds 
            Users_Panel.RowCount = displayRange;

            //iterates through list of users and creates new rows for them
            for (int i = 0; i < displayRange; i++)
            {
                //adds a new row to the users panel
                Users_Panel.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = 50 });

                //populates first name of user
                Label tempLabel = new Label() { Text = users[i].first, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag =  users[i]};
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Users_Panel.Controls.Add(tempLabel, 0, i);

                //populates last name of user
                tempLabel = new Label() { Text = users[i].last, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = users[i] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Users_Panel.Controls.Add(tempLabel , 1, i);

                //populates priveledge level of user
                tempLabel = new Label() { Text = users[i].prvlg, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = users[i] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Users_Panel.Controls.Add(tempLabel , 2, i);
            }


        }

        /*
         * retrieves all users from the database using npgsql
         * populates list with row data
         * returns list
         */
        private List<userWrapper> Get_Users()
        {
            List<userWrapper> users = new List<userWrapper>();

            connection.Open();

            using (var cmd = new NpgsqlCommand("SELECT * FROM users", connection))
            {
                var reader = cmd.ExecuteReader();

                // grab all users that exist in the database and add them to the databaseList
                while (reader.Read())
                {
                    userWrapper tempUser = new userWrapper();

                    tempUser.first = reader[1].ToString();
                    tempUser.last = reader[2].ToString();
                    tempUser.prvlg = reader[3].ToString();

                    users.Add(tempUser);
                }
            }

            connection.Close();

            return users;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        /*Populates card table with all cards from online JSON files
         * lets user know that download is in progress
         * creates web client and gets json files
         * iterates through list of sets
         * parses JSON file of each set for cards in set
         * opens connection to the database
         * iterates through list of cards and creates one or more tuples for each card
         * closes database connection
         */
        private void Load_Card_Button_Click(object sender, EventArgs e)
        {
            //shows that download is in progress
            downloadLabel.Visible = true;

            //creates webclient
            using (var webc = new WebClient())
            {
                //string containing set list json from URL
                var mtgjson = webc.DownloadString("https://mtgjson.com/json/SetList.json");

                //parced set list. will contain an array of every set's: name, code, and release date
                List<SetObject> setList = (List<SetObject>)Newtonsoft.Json.JsonConvert.DeserializeObject(mtgjson, typeof(List<SetObject>));
                
                //will hold the card list json 
                string mtgCardjson;

                //for every set

                for (int i = 0; i < setList.Count; i++)
                {
                    using (var wc = new WebClient())
                    {
                        //will hold card json from ("URL" + setCode + ".json")
                        mtgCardjson = wc.DownloadString("https://mtgjson.com/json/"+setList[i].code+".json");
                        if (i%(20) == 0 )
                        {
                            //stop here I'm here to stop the program during testing to make sure it isn't hanging
                        }
                        //parced card list. will contain an array of every card contained in the set setList[i].name
                        CardRootObject currentCardList = (CardRootObject)Newtonsoft.Json.JsonConvert.DeserializeObject(mtgCardjson, typeof(CardRootObject));

                        //Open connection to local database
                        connection.Open();

                        //for every card in the set
                        for (int j = 0; j < currentCardList.cards.Count; j++)
                        {
                            /*/////////////////////////////////////////////////////////////////////////////////////////////////////
                            //                           INSERT POSTGRES/PGADMIN CALLS IN HERE!!                                 //
                            // WILL CYCLE FOR EVERY CARD IN A SET, SWITCH SETS, AND RE-ENTER                                     //
                            // SetObject and CardObject classes can be viewed in file CardHolder.cs                              //
                            // additional notes on unused data and commented out data can be reviewed there                      //
                            // make sure the database calls are removed from save button on edit card forms as well.             //
                            // info not retrieved from currentCardList[j] CardObject                                             //
                            // DateTime, setName (get set name from setList[i].name)                                             //
                            // also I don't know what mtg Loyalties are and their does not seem to be a data type in CardObject. //
                            //   it may need to be removed from database if parced json files do not contain it.                 //
                            //                                                                                                   //
                            //  - Chris                                                                                          //
                            /////////////////////////////////////////////////////////////////////////////////////////////////////*/

                            //if card is from a promo set 
                            if(currentCardList.type == "promo")
                            {
                                //creates newcard command
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

                                    currentCardList.cards[j].name = currentCardList.cards[j].name.Replace("â€™", "'");
                                    cmd.Parameters.AddWithValue("in_name", currentCardList.cards[j].name + " - " + currentCardList.name);

                                    if (currentCardList.cards[j].manaCost != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", currentCardList.cards[j].manaCost);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", "land");
                                    }

                                    cmd.Parameters.AddWithValue("in_cmc", currentCardList.cards[j].convertedManaCost);

                                    cmd.Parameters.AddWithValue("in_colors", currentCardList.cards[j].colors);

                                    cmd.Parameters.AddWithValue("in_identity", currentCardList.cards[j].colorIdentity);

                                    cmd.Parameters.AddWithValue("in_set", setList[i].code);

                                    cmd.Parameters.AddWithValue("in_num", currentCardList.cards[j].number);

                                    cmd.Parameters.AddWithValue("in_rarity", currentCardList.cards[j].rarity);

                                    if (currentCardList.cards[j].borderColor != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_border", currentCardList.cards[j].borderColor);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_border", "Black");
                                    }

                                    cmd.Parameters.AddWithValue("in_multi", currentCardList.cards[j].multiverseId);

                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€™", "'");
                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€”", "-");
                                    cmd.Parameters.AddWithValue("in_type", currentCardList.cards[j].type);
                                    if (currentCardList.cards[j].types != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_types", currentCardList.cards[j].types);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_types", new string[0]);
                                    }

                                    if (currentCardList.cards[j].subtypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", currentCardList.cards[j].subtypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", new string[0]);
                                    }

                                    if (currentCardList.cards[j].supertypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", currentCardList.cards[j].supertypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", new string[0]);
                                    }


                                    if (currentCardList.cards[j].text != null)
                                    {
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€™", "'");
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€™", "'");
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_flavor", currentCardList.cards[j].flavorText);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_flavor", "n/a");
                                    }

                                    if (currentCardList.cards[j].power != null && currentCardList.cards[j].toughness != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_power", currentCardList.cards[j].power);
                                        cmd.Parameters.AddWithValue("in_tough", currentCardList.cards[j].toughness);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_power", "n/a");
                                        cmd.Parameters.AddWithValue("in_tough", "n/a");
                                    }

                                    if (currentCardList.cards[j].loyalty != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", currentCardList.cards[j].loyalty);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", "n/a");
                                    }

                                    if (currentCardList.cards[j].artist != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", "unknown");
                                    }
                                    cmd.Parameters.AddWithValue("in_foil", 'y');
                                    cmd.Parameters.AddWithValue("in_prerelease", 'n');
                                    cmd.Parameters.AddWithValue("in_location", "n/a");

                                    cmd.ExecuteScalar();
                                }
                            }
                            //if card is from a masterpiece set
                            else if(currentCardList.type == "masterpiece")
                            {
                                //creates newcard command
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

                                    currentCardList.cards[j].name = currentCardList.cards[j].name.Replace("â€™", "'");
                                    cmd.Parameters.AddWithValue("in_name", currentCardList.cards[j].name + " - MASTERPIECE");

                                    if (currentCardList.cards[j].manaCost != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", currentCardList.cards[j].manaCost);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", "land");
                                    }

                                    cmd.Parameters.AddWithValue("in_cmc", currentCardList.cards[j].convertedManaCost);

                                    cmd.Parameters.AddWithValue("in_colors", currentCardList.cards[j].colors);

                                    cmd.Parameters.AddWithValue("in_identity", currentCardList.cards[j].colorIdentity);

                                    cmd.Parameters.AddWithValue("in_set", setList[i].code);

                                    cmd.Parameters.AddWithValue("in_num", currentCardList.cards[j].number);

                                    cmd.Parameters.AddWithValue("in_rarity", currentCardList.cards[j].rarity);

                                    if (currentCardList.cards[j].borderColor != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_border", currentCardList.cards[j].borderColor);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_border", "Black");
                                    }

                                    cmd.Parameters.AddWithValue("in_multi", currentCardList.cards[j].multiverseId);

                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€™", "'");
                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€”", "-");
                                    cmd.Parameters.AddWithValue("in_type", currentCardList.cards[j].type);
                                    if (currentCardList.cards[j].types != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_types", currentCardList.cards[j].types);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_types", new string[0]);
                                    }

                                    if (currentCardList.cards[j].subtypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", currentCardList.cards[j].subtypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", new string[0]);
                                    }

                                    if (currentCardList.cards[j].supertypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", currentCardList.cards[j].supertypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", new string[0]);
                                    }


                                    if (currentCardList.cards[j].text != null)
                                    {
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€™", "'");
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€™", "'");
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_flavor", currentCardList.cards[j].flavorText);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_flavor", "n/a");
                                    }

                                    if (currentCardList.cards[j].power != null && currentCardList.cards[j].toughness != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_power", currentCardList.cards[j].power);
                                        cmd.Parameters.AddWithValue("in_tough", currentCardList.cards[j].toughness);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_power", "n/a");
                                        cmd.Parameters.AddWithValue("in_tough", "n/a");
                                    }

                                    if (currentCardList.cards[j].loyalty != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", currentCardList.cards[j].loyalty);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", "n/a");
                                    }

                                    if (currentCardList.cards[j].artist != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", "unknown");
                                    }
                                    cmd.Parameters.AddWithValue("in_foil", 'y');
                                    cmd.Parameters.AddWithValue("in_prerelease", 'n');
                                    cmd.Parameters.AddWithValue("in_location", "n/a");

                                    cmd.ExecuteScalar();
                                }
                            }
                            //if card can be a foil
                            else if(currentCardList.cards[j].hasFoil)
                            {
                                //creates newcard command
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

                                    currentCardList.cards[j].name = currentCardList.cards[j].name.Replace("â€™", "'");
                                    cmd.Parameters.AddWithValue("in_name", currentCardList.cards[j].name + " - FOIL");

                                    if (currentCardList.cards[j].manaCost != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", currentCardList.cards[j].manaCost);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", "land");
                                    }

                                    cmd.Parameters.AddWithValue("in_cmc", currentCardList.cards[j].convertedManaCost);

                                    cmd.Parameters.AddWithValue("in_colors", currentCardList.cards[j].colors);

                                    cmd.Parameters.AddWithValue("in_identity", currentCardList.cards[j].colorIdentity);

                                    cmd.Parameters.AddWithValue("in_set", setList[i].code);

                                    cmd.Parameters.AddWithValue("in_num", currentCardList.cards[j].number);

                                    cmd.Parameters.AddWithValue("in_rarity", currentCardList.cards[j].rarity);

                                    if (currentCardList.cards[j].borderColor != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_border", currentCardList.cards[j].borderColor);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_border", "Black");
                                    }

                                    cmd.Parameters.AddWithValue("in_multi", currentCardList.cards[j].multiverseId);

                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€™", "'");
                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€”", "-");
                                    cmd.Parameters.AddWithValue("in_type", currentCardList.cards[j].type);
                                    if (currentCardList.cards[j].types != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_types", currentCardList.cards[j].types);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_types", new string[0]);
                                    }

                                    if (currentCardList.cards[j].subtypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", currentCardList.cards[j].subtypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", new string[0]);
                                    }

                                    if (currentCardList.cards[j].supertypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", currentCardList.cards[j].supertypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", new string[0]);
                                    }


                                    if (currentCardList.cards[j].text != null)
                                    {
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€™", "'");
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€™", "'");
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_flavor", currentCardList.cards[j].flavorText);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_flavor", "n/a");
                                    }

                                    if (currentCardList.cards[j].power != null && currentCardList.cards[j].toughness != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_power", currentCardList.cards[j].power);
                                        cmd.Parameters.AddWithValue("in_tough", currentCardList.cards[j].toughness);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_power", "n/a");
                                        cmd.Parameters.AddWithValue("in_tough", "n/a");
                                    }

                                    if (currentCardList.cards[j].loyalty != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", currentCardList.cards[j].loyalty);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", "n/a");
                                    }

                                    if (currentCardList.cards[j].artist != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", "unknown");
                                    }
                                    cmd.Parameters.AddWithValue("in_foil", 'y');
                                    cmd.Parameters.AddWithValue("in_prerelease", 'n');
                                    cmd.Parameters.AddWithValue("in_location", "n/a");

                                    cmd.ExecuteScalar();
                                }
                            }

                            //if card can be non-foil
                            if(currentCardList.cards[j].hasNonFoil)
                            {
                                //creates newcard command
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

                                    currentCardList.cards[j].name = currentCardList.cards[j].name.Replace("â€™", "'");
                                    cmd.Parameters.AddWithValue("in_name", currentCardList.cards[j].name);

                                    if (currentCardList.cards[j].manaCost != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", currentCardList.cards[j].manaCost);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_mana", "land");
                                    }

                                    cmd.Parameters.AddWithValue("in_cmc", currentCardList.cards[j].convertedManaCost);

                                    cmd.Parameters.AddWithValue("in_colors", currentCardList.cards[j].colors);

                                    cmd.Parameters.AddWithValue("in_identity", currentCardList.cards[j].colorIdentity);

                                    cmd.Parameters.AddWithValue("in_set", setList[i].code);

                                    cmd.Parameters.AddWithValue("in_num", currentCardList.cards[j].number);

                                    cmd.Parameters.AddWithValue("in_rarity", currentCardList.cards[j].rarity);

                                    if (currentCardList.cards[j].borderColor != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_border", currentCardList.cards[j].borderColor);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_border", "Black");
                                    }

                                    cmd.Parameters.AddWithValue("in_multi", currentCardList.cards[j].multiverseId);

                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€™", "'");
                                    currentCardList.cards[j].type = currentCardList.cards[j].type.Replace("â€”", "-");
                                    cmd.Parameters.AddWithValue("in_type", currentCardList.cards[j].type);
                                    if (currentCardList.cards[j].types != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_types", currentCardList.cards[j].types);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_types", new string[0]);
                                    }

                                    if (currentCardList.cards[j].subtypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", currentCardList.cards[j].subtypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_subtypes", new string[0]);
                                    }

                                    if (currentCardList.cards[j].supertypes != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", currentCardList.cards[j].supertypes);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_supertypes", new string[0]);
                                    }


                                    if (currentCardList.cards[j].text != null)
                                    {
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€™", "'");
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€™", "'");
                                        currentCardList.cards[j].flavorText = currentCardList.cards[j].flavorText.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_flavor", currentCardList.cards[j].flavorText);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_flavor", "n/a");
                                    }

                                    if (currentCardList.cards[j].power != null && currentCardList.cards[j].toughness != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_power", currentCardList.cards[j].power);
                                        cmd.Parameters.AddWithValue("in_tough", currentCardList.cards[j].toughness);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_power", "n/a");
                                        cmd.Parameters.AddWithValue("in_tough", "n/a");
                                    }

                                    if (currentCardList.cards[j].loyalty != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", currentCardList.cards[j].loyalty);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_loyalty", "n/a");
                                    }

                                    if (currentCardList.cards[j].artist != null)
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_artist", "unknown");
                                    }
                                    cmd.Parameters.AddWithValue("in_foil", 'n');
                                    cmd.Parameters.AddWithValue("in_prerelease", 'n');
                                    cmd.Parameters.AddWithValue("in_location", "n/a");

                                    cmd.ExecuteScalar();
                                }
                            }
                        }

                        //close conection to database between sets
                        connection.Close();
                    }
                }
                
                //hides status panel
                downloadLabel.Visible = false;
            }   
            
        }

        //opens the create user dialogue
        private void newUserButton_Click(object sender, EventArgs e)
        {
            var newForm = new Create_User();
            newForm.ShowDialog();
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            ////////////////////ADD EDIT USER FUNCTIONALITY///////////////////////////
        }

        /*Click event to select users from table
         */
        private void tempLabel_Click(object sender, EventArgs e)
        {
            //create temporary value to hold sender
            Label temp = (Label)sender;

            //set current user
            currentUser = (userWrapper) temp.Tag;

            //gets row number of user in table
            int rowNumber = Users_Panel.GetRow((Label)sender);

            // Cycle through rows
            for (int i = 0; i < Users_Panel.RowCount; i++) 
            {
                if (i == rowNumber)
                {
                    // Cycle through columns of selected row
                    for (int j = 0; j < Users_Panel.ColumnCount; j++) 
                    {
                        //set color to selected color
                        Users_Panel.GetControlFromPosition(j, rowNumber).BackColor = Color.FromArgb(65, 70, 78);
                    }
                }
                else
                {
                    // Cycle through columns of other rows
                    for (int j = 0; j < Users_Panel.ColumnCount; j++) 
                    {
                        //reset color
                        Users_Panel.GetControlFromPosition(j, i).BackColor = Color.FromArgb(45, 49, 57);
                    }
                }
            }

            //refreshes table
            Users_Panel.Refresh();
        }

        private void dropUser_Click(object sender, EventArgs e)
        {
            /////////////////////////ADD DELETE USER FUNCTIONALITY////////////////////////////////
        }
    }
}
