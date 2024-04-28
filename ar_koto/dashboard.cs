using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ar_koto
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=ProductDB;Integrated Security=True;Encrypt=False");

        private void Employe_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            datagrid();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            int product_id;
            string item_name, design, color;
            float price;
            DateTime date;

            item_name = text_name.Text;
            design = text_design.Text;
            color = text_color.Text;

            // Parse input values
            if (!int.TryParse(text_id.Text, out product_id) || string.IsNullOrEmpty(text_name.Text) || string.IsNullOrEmpty(text_design.Text) ||
                string.IsNullOrEmpty(text_color.Text) || !float.TryParse(text_price.Text, out price) ||
                !DateTime.TryParse(text_date.Text, out date))
            {
                MessageBox.Show("Please fill up all sections with valid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if any input is invalid
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Product_info1(ProductID, ItemName, Design, Color, Price, InsertDate) VALUES (@ProductID, @ItemName, @Design, @Color, @Price, @InsertDate)", conn);

                // Use parameterized queries to avoid SQL injection and ensure proper data types
                cmd.Parameters.AddWithValue("@ProductID", product_id);
                cmd.Parameters.AddWithValue("@ItemName", item_name);
                cmd.Parameters.AddWithValue("@Design", design);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@InsertDate", date);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successful Insert", "Done", MessageBoxButtons.OK);
                    text_id.Clear();
                    text_name.Clear();
                    text_design.Clear();
                    text_price.Clear();
                    text_color.Text="none";
                    date = DateTime.Now;
                    text_id.Focus();

                }
                else
                {
                    MessageBox.Show("Insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                datagrid();
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        void datagrid()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Product_info1", conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            grid.DataSource = dt;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Product_info1 SET ItemName = @ItemName, Design = @Design, " +
                                                 "Color = @Color, Price = @Price WHERE ProductID = @ProductID", conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@ItemName", text_name.Text);
                cmd.Parameters.AddWithValue("@Design", text_design.Text);
                cmd.Parameters.AddWithValue("@Color", text_color.Text);
                cmd.Parameters.AddWithValue("@Price", float.Parse(text_price.Text));
                cmd.Parameters.AddWithValue("@ProductID", int.Parse(text_id.Text));

                // ExecuteNonQuery
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Successful Update", "Done", MessageBoxButtons.OK);
                datagrid(); // Assuming this method is defined to refresh the DataGridView
                text_id.Clear();
                text_name.Clear();
                text_design.Clear();
                text_price.Clear();
                text_color.Text = "none";
                DateTime date;
                DateTime.TryParse(text_date.Text, out date);
                date = DateTime.Now;
                text_id.Focus();
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

        private void DeleteData(int productId)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Product_info1 WHERE ProductID = @ProductID", conn);

                    
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successful delete data", "Done", MessageBoxButtons.OK);
                        datagrid();
                        text_id.Clear();
                        text_name.Clear();
                        text_design.Clear();
                        text_price.Clear();
                        text_color.Text = "none";
                        DateTime date;
                        DateTime.TryParse(text_date.Text, out date);
                        date = DateTime.Now;
                        text_id.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product ID not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            int productIdToDelete;
            if (int.TryParse(text_id.Text, out productIdToDelete))
            {
                DeleteData(productIdToDelete);
            }
            else
            {
                MessageBox.Show("Please enter a valid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private DataTable SearchProduct(int productId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product_info1 WHERE ProductID = @ProductID", conn);

                // Add parameter
                cmd.Parameters.AddWithValue("@ProductID", productId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dataTable;
        }



        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            int productId;
            if (int.TryParse(text_id.Text, out productId))
            {
                DataTable productTable = SearchProduct(productId);
                if (productTable.Rows.Count > 0)
                {
                    grid.DataSource = productTable; // Assuming your DataGridView is named dataGridView1
                }
                else
                {
                    MessageBox.Show("Product not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datagrid();
        }
    }
}
