using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Utility;
using MtgApiManager.Lib.Dto;
using Npgsql;

namespace OCS_FOR_CSHARP
{
    public partial class Review : Form
    {
        public List<cardWrapper> reviewCards = new List<cardWrapper>();
        public List<Bitmap> reviewImages = new List<Bitmap>();
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");

        public Review()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            var getImageForm = new Form1();//Change to the Inventory viewer form
            getImageForm.callingForm = this;
            getImageForm.Show();
        }

        // will need to change functionality of the OK button later
        private void OK_Button_Click(object sender, EventArgs e)
        {
            Add_Cards_To_Inventory();
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e) => Close();

        public void addToList(List<cardWrapper> sentCard)
        {
            int addAmount = sentCard.Capacity;
            Card_Table_Panel.RowCount += addAmount;
            for (int i = 0; i < addAmount; i++)
            {
                // begin popluating rows with cards
                // populate each row with a checkbox
                //Card_Table_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter }, 0, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.name, AutoEllipsis = true }, 1, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.type, AutoEllipsis = true }, 2, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.setCode, AutoEllipsis = true }, 3, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.multiverseId.ToString(), AutoEllipsis = true }, 4, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.manaCost, AutoEllipsis = true }, 5, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = "N/A", AutoEllipsis = true }, 6, Card_Table_Panel.RowCount - 1);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inventory_Checkbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Card_Table_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Review_Load(object sender, EventArgs e)
        {

        }

        private void Add_Cards_To_Inventory()
        {
            connection.Open();

            for(int i = 0; i < reviewCards.Count; i++)
            {
                using (var cmd = new NpgsqlCommand("new_inv_event", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_foreign_card_id", reviewCards[i].card.cardID);
                    cmd.Parameters.AddWithValue("in_foreign_user_id", CurrentUser.user_ID);
                    cmd.Parameters.AddWithValue("in_datetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("in_trans_type", 1);

                    cmd.ExecuteScalar();
                }

            }

            connection.Close();
        }
    }
}
