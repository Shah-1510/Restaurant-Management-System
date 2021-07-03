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
using System.Configuration;
namespace RestaurantMS
{
    public partial class InsertinMenu : Form
    {
        public InsertinMenu()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand cmd = new SqlCommand("Select itemName from Menu where itemName = '" + textBox1.Text + "'", con);
                SqlDataReader sda = cmd.ExecuteReader();

                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all the boxes");
                }
                else if (sda.Read()== true)
                {
                    MessageBox.Show("This Item is Already Present in Menu");
                }
                else if (Convert.ToInt32(textBox2.Text) <= 0)
                {
                    MessageBox.Show("Please Enter the Correct Value");
                }
                else
                {
                    string query = "INSERT into Menu (itemName, itemprice, itemcategory) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                    sda.Close();
                    SqlDataAdapter sd = new SqlDataAdapter(query, con);
                    sd.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Inserted");
                    clear();


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some Problem Has Occur");
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
