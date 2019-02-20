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

        private void Load_Card_Button_Click(object sender, EventArgs e)
        {
            using (WebClient webc = new WebClient())
            {
                var mtgjson = webc.DownloadString("https://mtgjson.com/json/SetList.json");
                SetObject allSets = JsonConvert.DeserializeObject<SetObject>(mtgjson);//do you need to make a SetObject list class????
                
            }
            

            if (3 != 2)
            {

            }            

            //New plan download https://mtgjson.com/json/SetList.json, parce set codes
            //Use set codes to download individual sets via https://mtgjson.com/json/USE_SET_CODE_HERE.json
            //Parce indiviual set json files for all required information. "A lot"



        }
    }
}
