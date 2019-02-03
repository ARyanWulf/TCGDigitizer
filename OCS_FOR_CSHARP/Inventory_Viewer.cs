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
    public partial class Inventory_Table : Form
    {
        Edit_Card_Form editForm;

        public Inventory_Table()
        {
            InitializeComponent();
        }

        private void Scan_Button_Click(object sender, EventArgs e)
        {
            // Will have to change the name for "Form1" here if we change the name of it elsewhere

            var getEditForm = new Edit_Card_Form();
            getEditForm.ShowDialog();


            //editForm = new Edit_Card_Form();

            /*
            editForm.Show();
            editForm.callingForm = this;
            //getImageForm = new Form1();*/
        }

        private void Cancel_Button_Click(object sender, EventArgs e) => Close();
        /*{
            Close();
        }*/
    }
}
