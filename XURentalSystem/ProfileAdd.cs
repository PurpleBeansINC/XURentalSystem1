using System;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class ProfileAdd : Form
    {
        private ItemDisplay itemDisplay;
        private int id;
        private Button button;

        public ProfileAdd(int id, ItemDisplay itemDisplay, Button button)
        {
            InitializeComponent();
            this.itemDisplay = itemDisplay;
            this.id = id;
            this.button = button;
        }

        private void OkeyButton_Click(object sender, EventArgs e)
        {
            bool CSGMember;
            string price;
            if (radioButtonYes.Checked == true)
            {
                CSGMember = true;
                price = "0";
            }
            else
            {
                CSGMember = false;
                price = itemDisplay.priceforrent;
            }
            Profile profile = new Profile
            {
                Name = textBoxName.Text,
                Section = textBoxSection.Text,
                IdNumber = textBoxIdNumber.Text,
                Time = DateTime.Now,
                CSG = CSGMember,
                Amount = price
            };
            itemDisplay.addProfile(id, profile, button);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}