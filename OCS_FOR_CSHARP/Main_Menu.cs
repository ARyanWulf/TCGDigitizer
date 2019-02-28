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
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            var getImageForm = new Review();
            getImageForm.ShowDialog();
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            var getImageForm = new Inventory_Menu();//Change to the Inventory viewer form
            getImageForm.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var getImageForm = new Settings();
            getImageForm.ShowDialog();
        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            ContactText.Visible = true;
            CloseTextButton.Visible = true;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContactText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CloseTextButton_Click(object sender, EventArgs e)
        {
            ContactText.Visible = false;
            CloseTextButton.Visible = false;
        }
    }

    static class CurrentUser
    {
        private static int _user_ID = 3;
        private static int _prvlg_lvl = 1;

        public static int user_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        public static int prvlg_lvl
        {
            get { return _prvlg_lvl; }
            set { _prvlg_lvl = value; }
        }
    }
}
