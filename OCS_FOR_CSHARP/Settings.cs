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
        // the list of users that will be used to populate the table
        private List<userWrapper> users = new List<userWrapper>();
        private userWrapper currentUser = new userWrapper();
        Color[,] bgColors = new Color[3, 100];

        public Settings()
        {
            InitializeComponent();
            Populate_Settings_List();
            //var position = this.PointToScreen(user_text_box.Location);
            //position = user_settings_backpanel.PointToClient(position);
            //user_text_box.Parent = user_settings_backpanel;
            //user_text_box.Location = position;
            //user_text_box.Visible = true;

        }

        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void DefualtButton_Click(object sender, EventArgs e)
        {
            //Reset settings to default values
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            //Delete all data

            Close();
        }

        private void users_panel(object sender, PaintEventArgs e)
        {

        }

        // Autopopulate with a list of current users that exist in the system
        public void Populate_Settings_List()
        {
            //Users_Panel.Visible = false;
            //Clear table and redraw
            Users_Panel.Controls.Clear();
            //Users_Panel.Padding = new Padding(0, 0, System.Windows.Forms.SystemInformation.VerticalScrollBarWidth, 0);
            Users_Panel.RowCount = 0;
            Users_Panel.Dock = DockStyle.None;
            Users_Panel.AutoSize = true;
            Users_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            users = Get_Users();

            int displayRange = users.Count;

            Users_Panel.RowCount = displayRange;

            for (int i = 0; i < displayRange; i++)
            {
                Users_Panel.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = 50 });
                //Users_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.None }, 0, i); //No onger need checkboxes for user management table

                Label tempLabel = new Label() { Text = users[i].first, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag =  users[i]};
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Users_Panel.Controls.Add(tempLabel, 0, i);

                tempLabel = new Label() { Text = users[i].last, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = users[i] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Users_Panel.Controls.Add(tempLabel , 1, i);

                tempLabel = new Label() { Text = users[i].prvlg, TextAlign = ContentAlignment.MiddleCenter, AutoEllipsis = true, AutoSize = true, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), Tag = users[i] };
                tempLabel.Click += new EventHandler(tempLabel_Click);
                Users_Panel.Controls.Add(tempLabel , 2, i);
            }


        }

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
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        //Creates database by downloading JSON files, parcing them and inserting them into POSTGRES DATABASE.
        private void Load_Card_Button_Click(object sender, EventArgs e)
        {
            downloadLabel.Visible = true;

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

                        //List<CardRootObject> currentCardList = (List<CardRootObject>)Newtonsoft.Json.JsonConvert.DeserializeObject(mtgCardjson, typeof(List<CardRootObject>));

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


                            if(currentCardList.type == "promo")
                            {
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

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
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
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
                            else if(currentCardList.type == "masterpiece")
                            {
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

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
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
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
                            else if(currentCardList.cards[j].hasFoil)
                            {
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

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
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
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

                                    if(currentCardList.cards[j].artist != null)
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

                            if(currentCardList.cards[j].hasNonFoil)
                            {
                                using (var cmd = new NpgsqlCommand("newCard", connection))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("in_id", 3);

                                    cmd.Parameters.AddWithValue("in_time", DateTime.Now);

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
                                        currentCardList.cards[j].text = currentCardList.cards[j].text.Replace("â€”", "-");
                                        cmd.Parameters.AddWithValue("in_text", currentCardList.cards[j].text);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("in_text", "n/a");
                                    }


                                    if (currentCardList.cards[j].flavorText != null)
                                    {
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
                
                downloadLabel.Visible = false;
            }   
            
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            var newForm = new Create_User();
            newForm.ShowDialog();
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {


            

        }

        private void login_label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tempLabel_Click(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            currentUser = (userWrapper) temp.Tag;
            int rowNumber = Users_Panel.GetRow((Label)sender);
            for (int i = 0; i < Users_Panel.RowCount; i++) // Cycle through rows
            {
                if (i == rowNumber)
                {
                    for (int j = 0; j < 3; j++) // Cycle through columns of selected row
                    {
                        Users_Panel.GetControlFromPosition(j, rowNumber).BackColor = Color.FromArgb(65, 70, 78);
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j++) // Cycle through columns of other rows
                    {
                        Users_Panel.GetControlFromPosition(j, i).BackColor = Color.FromArgb(45, 49, 57);
                    }
                }
            }
            Users_Panel.Refresh();
        }

        private void dropUser_Click(object sender, EventArgs e)
        {

        }
    }

    public class userWrapper
    {
        public string first, last, prvlg;

        public userWrapper()
        {
            first = "";
            last = "";
            prvlg = "";
        }

        ~userWrapper()
        {
        }
    };
}
