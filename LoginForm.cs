using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace login_register_form
{
    public partial class LoginForm : Form
    {


        
        public LoginForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.MaximizeBox = false;
 
        }

        SqlConnection connect = new SqlConnection(@"Data Source=LAYOUT-PC;Initial Catalog=mydata;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            String username, userpassword;

            username = txtUsername.Text;
            userpassword = txtPassword.Text;

            string querry = "SELECT * FROM tbl_users WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, connect);
            connect.Open();
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                username = txtUsername.Text;
                userpassword = txtPassword.Text;
                LandingPage landform = new LandingPage(username);
                landform.Show();
                this.Hide();
            }
            else
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Please enter a username.");
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please enter a password.");
                }
                else
                {
                    string querry2 = "SELECT * FROM tbl_users WHERE username = '" + txtUsername.Text + "'";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(querry2, connect);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    if (table2.Rows.Count > 0)
                    {
                        MessageBox.Show("Incorrect password, please try again.");
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password, please try again.");
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                }
            }
            connect.Close();
        }




        private void lblRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
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
