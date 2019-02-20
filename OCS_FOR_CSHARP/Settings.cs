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

        private void DeleteCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(DeleteCheckbox.Checked)
            {
                DeleteAllButton.Enabled = true;
            }
            else
            {
                DeleteAllButton.Enabled = false;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
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
                        }
                    }
                }
            }   
            
        }
    }
}
