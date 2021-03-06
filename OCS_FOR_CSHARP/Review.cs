﻿using System;
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
        Form1 getImageForm;
        public Form1 callingForm;
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");

        public Review()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            if (getImageForm == null)
            {
                getImageForm = new Form1();//Change to the Inventory viewer form
                getImageForm.callingForm = this;
                getImageForm.Show();
            }
            getImageForm.BringToFront();
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
            Card_Table_Panel.Visible = false;
            int addAmount = sentCard.Count;
            int rowOffset = Card_Table_Panel.RowCount;
            Card_Table_Panel.RowCount += addAmount;
            for (int i = 0; i < addAmount; i++)
            {
                reviewCards.Add(sentCard[i]);
                // begin popluating rows with cards
                // populate each row with a checkbox
                //Card_Table_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter }, 0, Card_Table_Panel.RowCount - 1);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.name, AutoEllipsis = true }, 1, rowOffset + i);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.type, AutoEllipsis = true }, 2, rowOffset + i);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.setCode, AutoEllipsis = true }, 3, rowOffset + i);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.multiverseId.ToString(), AutoEllipsis = true }, 4, rowOffset + i);
                Card_Table_Panel.Controls.Add(new Label() { Text = sentCard[i].card.manaCost, AutoEllipsis = true }, 5, rowOffset + i);
                Card_Table_Panel.Controls.Add(new Label() { Text = "N/A", AutoEllipsis = true }, 6, rowOffset + i);
            }
            Card_Table_Panel.Visible = true;
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
            getImageForm = new Form1();
            getImageForm.callingForm = this;
            getImageForm.Show();
            getImageForm.BringToFront();
        }

        private void Add_Cards_To_Inventory()
        {
            bool exists = false;
            for(int i = 0; i < reviewCards.Count; i++)
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("new_trans_event", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_foreign_card_id", reviewCards[i].card.cardID);
                    cmd.Parameters.AddWithValue("in_foreign_user_id", CurrentUser.user_ID);
                    cmd.Parameters.AddWithValue("in_datetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("in_trans_type", 1);

                    cmd.ExecuteScalar();
                }

                connection.Close();


                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory WHERE card_id = " + reviewCards[i].card.cardID, connection))
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

                        cmd.Parameters.AddWithValue("in_foreign_card_id", reviewCards[i].card.cardID);
                        cmd.Parameters.AddWithValue("in_new_count", 1);

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

                        cmd.Parameters.AddWithValue("in_foreign_card_id", reviewCards[i].card.cardID);
                        cmd.Parameters.AddWithValue("in_new_count", 1);

                        cmd.ExecuteScalar();
                    }
                    connection.Close();
                }

            }
        }
    }
}
