using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCS_FOR_CSHARP
{
    public partial class Inventory_Menu : Form
    {
        public Inventory_Menu()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            var getImageForm = new Form1();//Change to the Inventory viewer form
            getImageForm.ShowDialog();
        }

        private void Add_Card_Button_Click(object sender, EventArgs e)
        {
            var getEditCardForm = new Edit_Card_Form();
            getEditCardForm.ShowDialog();
        }

        // TODO:
        // When OK button is pressed, if current changes are not saved
        // prompt user to save changes
        // else, close
        private void OK_Button_Click(object sender, EventArgs e) => Close();

        private void Cancel_Button_Click(object sender, EventArgs e) => Close();

        private void Inventory_Menu_Load(object sender, EventArgs e)
        {
            // initialize table to zero rows to be empty
            Card_Table_Panel.RowCount = 1;

            int cardCount = 20;
            string tempString = "Existence is suffering for a Meseeks.";

            // begin populating table, start at second row so the first
            // row containing buttons is not overwritten
            for (int i = 1; i < cardCount; i++)
            {
                // create a new row for each card
                Card_Table_Panel.RowCount++;

                // begin popluating rows with cards
                // populate each row with a checkbox
                //Card_Table_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter }, 0, Card_Table_Panel.RowCount - 1);

                Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 1, Card_Table_Panel.RowCount - 1);
                // tempString = database card name

                Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 2, Card_Table_Panel.RowCount - 1);
                // tempString = database card type

                Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 3, Card_Table_Panel.RowCount - 1);
                // tempString = database card expansion

                Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 4, Card_Table_Panel.RowCount - 1);
                // tempString = database card number

                Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 5, Card_Table_Panel.RowCount - 1);
                // tempString = database card mana

                Card_Table_Panel.Controls.Add(new Label() { Text = tempString, AutoEllipsis = true }, 6, Card_Table_Panel.RowCount - 1);
                // tempString = database card date added

            }
            AutoScroll = true;


        }

        private void Card_Table_Panel_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}


/*

     
*/
