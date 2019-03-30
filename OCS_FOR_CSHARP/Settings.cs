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
        public Settings()
        {
            InitializeComponent();
            var position = this.PointToScreen(user_text_box.Location);
            position = user_settings_backpanel.PointToClient(position);
            user_text_box.Parent = user_settings_backpanel;
            user_text_box.Location = position;
            user_text_box.Visible = true;

        }

        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
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

        // Autopopulate with a list of current users that exist in the system
        private void users_panel(object sender, PaintEventArgs e)
        {

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
                                    cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
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
                                    cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
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
                                    cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
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
                                    cmd.Parameters.AddWithValue("in_artist", currentCardList.cards[j].artist);
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

    
    }
}
