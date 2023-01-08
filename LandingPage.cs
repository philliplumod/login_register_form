using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_register_form
{
    public partial class LandingPage : Form
    {
        public string UserName { get; set; }
        public LandingPage(string username)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.MaximizeBox = false;

            UserName = username;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            txtuser.Text = UserName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the form?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
