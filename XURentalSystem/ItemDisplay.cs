using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class ItemDisplay : Form
    {
        private string name;
        private Inventory inv;
        private Product currentItem;
        private Profile[] profiles;
        private int amount;

        public string priceforrent;

        public ItemDisplay(Inventory inv, int itemIndex)
        {
            InitializeComponent();
            this.inv = inv;
            currentItem = inv.Products[itemIndex];
            name = currentItem.Name;
            amount = currentItem.Quantity;
            priceforrent = currentItem.Price;
            profiles = LoadProfile();
            createButtons();
        }

        public void createButtons()
        {
            int placed = 0;
            int distance = 100;

            for (int y = 0; placed < amount; y++)
            {
                for (int x = 0; x < 7 && placed != amount; x++)
                {
                    Button button = new Button();
                    button.Name = string.Format("b_{0}", placed + 1);
                    button.Height = 60;
                    button.Width = 60;
                    button.Left = distance + (distance * x);
                    button.Top = distance + (distance * y);
                    button.Text = currentItem.Name + " " + (placed + 1);
                    if (profiles[placed] == null)
                    {
                        button.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                    }
                    else
                    {
                        button.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                    }
                    button.Click += b_click;
                    Button infoButton = new Button();
                    infoButton.Name = string.Format("IB_{0}", placed + 1);
                    infoButton.Height = 30;
                    infoButton.Width = 60;
                    infoButton.Left = distance + (distance * x);
                    infoButton.Top = (distance + 60) + (distance * y);
                    infoButton.Text = "Info";
                    infoButton.Click += openProfile;
                    this.Controls.Add(button);
                    this.Controls.Add(infoButton);
                    placed++;
                }
            }
        }

        public void SaveProducts(Profile[] listOfProfile)
        {
            string dataPath = string.Format("{0}.json", name);

            string json = JsonConvert.SerializeObject(listOfProfile);

            File.WriteAllText(dataPath, json);
        }

        public Profile[] LoadProfile()
        {
            string dataPath = string.Format("{0}.json", name);

            Profile[] listOfProfile = new Profile[amount];

            if (File.Exists(dataPath))
            {
                string json = File.ReadAllText(dataPath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    listOfProfile = JsonConvert.DeserializeObject<Profile[]>(json);
                }
            }

            return listOfProfile;
        }

        public void b_click(object sender, EventArgs e)
        {
            var b = sender as Button;

            for (int ctr = 0; ctr < amount; ctr++)
            {
                if (b.Name == String.Format("b_{0}", ctr + 1))
                {
                    if (b.BackColor == System.Drawing.Color.FromArgb(0, 255, 0))
                    {
                        ProfileAdd profileAdd = new ProfileAdd(ctr + 1, this, b);
                        profileAdd.Show();
                    }
                    else
                    {
                        removeProfile(ctr + 1, b);
                    }
                }
            }
        }

        public void openProfile(object sender, EventArgs e)
        {
            var b = sender as Button;

            for (int ctr = 0; ctr < amount; ctr++)
            {
                if (b.Name == String.Format("IB_{0}", ctr + 1))
                {
                    ProfileDisplay profileDisplay = new ProfileDisplay(profiles[ctr]);
                    profileDisplay.Show();
                }
            }
        }

        public void addProfile(int id, Profile profile, Button button)
        {
            profiles[id - 1] = profile;
            button.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            SaveProducts(profiles);
        }

        public void removeProfile(int id, Button b)
        {
            profiles[id - 1] = null;
            b.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] 
            {
                new DataColumn("Date", typeof(string)),
                new DataColumn("ID", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Section", typeof(string)),
                new DataColumn("CSG", typeof(Boolean)),
                new DataColumn("Paid", typeof(string)),
            });
            for (int ctr = 0; ctr < amount; ctr++)
            {
                if(profiles[ctr] != null)
                {
                    dt.Rows.Add(profiles[ctr].Time.ToString("yyyy-MM-dd"), profiles[ctr].IdNumber, profiles[ctr].Name, profiles[ctr].Section, profiles[ctr].CSG, profiles[ctr].Amount);
                }
            }
            FileInfo newFile = new FileInfo(string.Format("{0}.xlsx", name));
            if (newFile.Exists) newFile.Delete();

            using (ExcelPackage pck = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                pck.Save();
            }
        }
    }
}