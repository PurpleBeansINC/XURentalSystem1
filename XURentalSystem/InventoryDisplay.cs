using System;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class InventoryDisplay : Form
    {
        private Inventory inv = new Inventory();
        private MainGUI mainForm;

        public InventoryDisplay(MainGUI mainGui)
        {
            InitializeComponent();
            ComboBoxInv.DataSource = inv.Products;
            ComboBoxInv.DisplayMember = "Name";
            mainForm = mainGui;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(inv);
            addProduct.Show();
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = ComboBoxInv.SelectedIndex;

            inv.RemoveProduct(selectedIndex);
            ComboBoxInv.DataSource = null;
            ComboBoxInv.DataSource = inv.Products;
            ComboBoxInv.DisplayMember = "Name";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ComboBoxInv.DataSource = null;
            ComboBoxInv.DataSource = inv.Products;
            ComboBoxInv.DisplayMember = "Name";
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = ComboBoxInv.SelectedIndex;

            ItemDisplay item = new ItemDisplay(inv, selectedIndex);
            item.Show();
        }

        private void InventoryDisplay_FormClosing(object sender, EventArgs e)
        {
            mainForm.Close();
        }
    }
}