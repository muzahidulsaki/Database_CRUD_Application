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
    public partial class Form1 : Form

    {
        public string user_username { get; set; }
        public string user_userpassword { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Youtube;Integrated Security=True;Encrypt=False");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            // Hardcoded username and password
            string hardcodedUsername = "Saki";
            string hardcodedPassword = "saki123";

            // Check if the input username and password match the hardcoded values
            if (username == hardcodedUsername && user_password == hardcodedPassword)
            {
                dashboard dash = new dashboard();
                dash.Show();
                this.Hide();
            }
            else
            {
                try
                {
                    string username11, userpassword11;
                    string querry = "SELECT * FROM User_table WHERE Username = '" + txt_username.Text + "' AND Password = '" + txt_password.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                    username11 = txt_username.Text;
                    userpassword11 = txt_password.Text;
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(username11) || string.IsNullOrEmpty(userpassword11))
                        {
                            MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_username.Clear();
                            txt_password.Clear();

                            txt_username.Focus();

                        }
                        else
                        {
                            username11 = txt_username.Text;
                            userpassword11 = txt_password.Text;
                            dashboard dash = new dashboard();
                            dash.Show();
                            this.Hide();
                        }
                        

                    }

                    else
                    {
                        MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_username.Clear();
                        txt_password.Clear();

                        txt_username.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            menu form2 = new menu();
            form2.Show();
            this.Hide();
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
