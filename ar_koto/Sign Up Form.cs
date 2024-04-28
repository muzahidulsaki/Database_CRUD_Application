using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ar_koto
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Youtube;Integrated Security=True;Encrypt=False");


        private void menu_Load(object sender, EventArgs e)
        {
           // label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent; 
            label8.ForeColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = 0;

            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string user_fullname, user_name, user_password, user_email, user_phone, user_address;

            user_fullname = txt_name.Text;
            user_name = txt_user.Text;
            user_email = txt_email.Text;
            user_password = txt_passsword.Text;
            user_phone = txt_phone.Text;
            user_address = txt_address.Text;

            Form1 form1 = new Form1();
            form1.user_username = txt_user.Text;
            form1.user_userpassword = txt_passsword.Text;

            try
            {
                if (string.IsNullOrEmpty(user_fullname) || string.IsNullOrEmpty(user_name) ||
                    string.IsNullOrEmpty(user_email) || string.IsNullOrEmpty(user_password) ||
                    string.IsNullOrEmpty(user_phone) || string.IsNullOrEmpty(user_address))
                {
                    MessageBox.Show("Please fill up all sections.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO User_table (Full_Name, Username, Password, Email, Phone, Address) " +
                                                    "VALUES (@FullName, @Username, @Password, @Email, @Phone, @Address)", conn);
                    // Add parameters
                    cmd.Parameters.AddWithValue("@FullName", user_fullname);
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", user_password);
                    cmd.Parameters.AddWithValue("@Email", user_email);
                    cmd.Parameters.AddWithValue("@Phone", user_phone);
                    cmd.Parameters.AddWithValue("@Address", user_address);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        DialogResult result = MessageBox.Show("Successful Sign up", "Done", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            Form1 form = new Form1();
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sign up failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
