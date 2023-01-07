using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace login_register_form
{
    public partial class RegisterForm : Form
    {

        public RegisterForm()
        {
            InitializeComponent();

        }
        SqlConnection connect = new SqlConnection(@"Data Source=LAYOUT-PC;Initial Catalog=mydata;Integrated Security=True");






        private void lblLogin_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCompPass.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtCompPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtCompPass.PasswordChar = '•';
            }
        }

        private void btnCreateAccount_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtCompPass.Text))
            {
                MessageBox.Show("ALL FIELDS MUST BE FILL");
            } else if (txtPassword.Text == txtCompPass.Text)
            {
                try
                {
                    string querry = "INSERT into tbl_users (username,password) VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text + "')";
                    SqlDataAdapter adapater = new SqlDataAdapter(querry, connect);
                    connect.Open();

                    adapater.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("DATA SAVED");

                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("Password does not match");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
