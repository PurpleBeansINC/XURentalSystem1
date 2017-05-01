using System;
using System.Windows.Forms;

namespace XURentalSystem
{
    public partial class ProfileDisplay : Form
    {
        private Profile profile;

        public ProfileDisplay(Profile profile)
        {
            InitializeComponent();
            this.profile = profile;
            setText();
        }

        public void setText()
        {
            if (profile != null)
            {
                textBoxName.Text = profile.Name;
                textBoxIdNumber.Text = profile.IdNumber;
                textBoxSection.Text = profile.Section;
                if (profile.CSG == true)
                {
                    textBoxCSG.Text = "CSG Member";
                }
                else
                {
                    textBoxCSG.Text = "Not CSG Member";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}