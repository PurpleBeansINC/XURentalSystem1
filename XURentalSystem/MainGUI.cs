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
            InventoryDisplay ID = new InventoryDisplay();
            this.Hide();
            ID.Show();
        }
    }
}