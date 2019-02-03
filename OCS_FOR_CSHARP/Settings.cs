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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
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
    }
}
