using System;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            InventoryDisplay ID = new InventoryDisplay(this);
            this.Hide();
            ID.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: Automatically Create Excel Sheets, Make It Possible Add Item Direct to Excel Sheet, Make PopUP for deleting of profiles/user from item");
        }
    }
}