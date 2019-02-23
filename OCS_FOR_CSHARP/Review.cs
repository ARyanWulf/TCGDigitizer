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

namespace OCS_FOR_CSHARP
{
    public partial class Review : Form
    {
        public List<cardWrapper> reviewCards = new List<cardWrapper>();

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
        private void OK_Button_Click(object sender, EventArgs e) => Close();

        private void Cancel_Button_Click(object sender, EventArgs e) => Close();

        public void addToList(cardWrapper sentCard)
        {
            Card_Table_Panel.RowCount++;

            // begin popluating rows with cards
            // populate each row with a checkbox
            //Card_Table_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter }, 0, Card_Table_Panel.RowCount - 1);
            string tempString = sentCard.card.name;
            Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 1, Card_Table_Panel.RowCount - 1);
            tempString = sentCard.card.type;

            Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 2, Card_Table_Panel.RowCount - 1);
            //tempString = sentCard.card.expansion;

            Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 3, Card_Table_Panel.RowCount - 1);
            // tempString = database card expansion

            Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 4, Card_Table_Panel.RowCount - 1);
            // tempString = database card number

            Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 5, Card_Table_Panel.RowCount - 1);
            // tempString = database card mana

            Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 6, Card_Table_Panel.RowCount - 1);
            // tempString = database card date added
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
    }
}
