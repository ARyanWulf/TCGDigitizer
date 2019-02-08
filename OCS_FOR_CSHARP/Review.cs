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
        public List<cardWrapper> reviewCards;

        public Review()
        {
            InitializeComponent();
        }

        private void Scan_Card_Button_Click(object sender, EventArgs e)
        {
            var getImageForm = new Form1();//Change to the Inventory viewer form
            getImageForm.Show();
        }

        // will need to change functionality of the OK button later
        private void OK_Button_Click(object sender, EventArgs e) => Close();

        private void Cancel_Button_Click(object sender, EventArgs e) => Close();

        public void addToList(cardWrapper sentCard)
        {

            reviewCards.Add(sentCard);
            
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
