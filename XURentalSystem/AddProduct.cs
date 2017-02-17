using System;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class AddProduct : Form
    {
        private Inventory inv;

        public AddProduct(Inventory inv)
        {
            InitializeComponent();
            this.inv = inv;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = NameBox.Text,
                Quantity = int.Parse(AmountBox.Text)
            };
            inv.addProduct(product);
            this.Close();
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}