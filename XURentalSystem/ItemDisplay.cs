using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class ItemDisplay : Form
    {
        private Inventory inv;
        private Product currentItem;
        private int amount;

        List<Button> buttons = new List<Button>();

        public ItemDisplay(Inventory inv,int itemIndex)
        {
            InitializeComponent();
            this.inv = inv;
            currentItem = inv.Products[itemIndex];
            amount = currentItem.Quantity;
            createButtons();
        }

        public void createButtons()
        {
            int placed = 0;
            int distance = 100;
            for(int y = 0; placed < amount ; y++)
            {
                for(int x = 0; x < 8 && placed != amount; x++)
                {
                    Button tmpbutton = new Button();
                    tmpbutton.Height = 60;
                    tmpbutton.Width = 60;
                    tmpbutton.Left = distance + (distance * x);
                    tmpbutton.Top = distance + (distance * y);
                    tmpbutton.Text = currentItem.Name + " " + (placed+1);
                    this.Controls.Add(tmpbutton);
                    placed++;
                }
            }
        }
    }
}
