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
    public partial class updateinventory : Form
    {
        public updateinventory()
        {
            InitializeComponent();
            populateComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inv = new Inventory();
            inv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        void populateComboBox()
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string comboQuery = "Select ItmName From Inventory";
            SqlCommand cmd = new SqlCommand(comboQuery, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string fil1 = rdr.GetString(0);
                comboBox1.Items.Add(fil1);
            }
            rdr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Please fill the Text box first.");
                }
                else if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select atleast one item");
                }
                else if (Convert.ToInt32(textBox2.Text) < 0)
                {
                    MessageBox.Show("This is not correct Quantity");
                }
                else
                {
                    string q = "UPDATE INVENTORY SET qty = '" + textBox2.Text + "'where itmName ='" + comboBox1.SelectedItem + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item updated in inventory");
                    clear();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Some Problem has Occurred");
            }
            void clear()
            {
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
            }
        }
    }
}
