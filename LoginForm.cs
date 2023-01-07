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


        }

        SqlConnection connect = new SqlConnection(@"Data Source=LAYOUT-PC;Initial Catalog=mydata;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            String username, userpassword;

            username = txtUsername.Text;
            userpassword = txtPassword.Text;

            try
            {
                string querry = "SELECT * FROM tbl_users WHERE username = '"+txtUsername.Text+"' AND password = '"+txtPassword.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, connect);
                connect.Open();
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0 )
                {
                    username = txtUsername.Text;
                    userpassword = txtPassword.Text;

                    LandingPage landform = new LandingPage();
                    landform.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("INVALID DETAILS");
                   txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }


            }catch {
                MessageBox.Show("ERRORR");
            } finally   {
                connect.Close();
            }

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
    }
}
