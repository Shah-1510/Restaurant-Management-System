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
    public partial class RemovefromMenu : Form
    {
        public RemovefromMenu()
        {
            InitializeComponent();
            populatecombo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }
        void populatecombo()
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string sq = "Select itemName from Menu";
            SqlCommand cmd = new SqlCommand(sq, con);
            SqlDataReader sd = cmd.ExecuteReader();
            while (sd.Read())
            {
                int statusindex = sd.GetOrdinal("itemName");
                string fill = sd.IsDBNull(statusindex) ? null : sd.GetString(statusindex);
                if (fill != null)
                {
                    comboBox1.Items.Add(fill);

                }
            }
            sd.Close();
            con.Close();
        }
        void clear()
        {
            comboBox1.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Any Item");
                }
                else
                {
                    string q = "DELETE from Menu where itemName='" + comboBox1.SelectedItem.ToString() + "'";
              //      string query = "UPDATE Menu Set itemName = Null where itemName = '" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    /*
                    string q2 = "UPDATE Menu Set itemName = Null where itemName = '" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter sd = new SqlDataAdapter(q2, con);
                    sd.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    */
                    MessageBox.Show("Item Removed");
                    clear();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Some Problem Has Occured..");
            }
            
        }
    }
}
