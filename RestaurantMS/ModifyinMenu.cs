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
    public partial class ModifyinMenu : Form
    {
        public ModifyinMenu()
        {
            InitializeComponent();
            populateitemname();
            populatecatname();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();

        }
        void populateitemname()
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string comboquery = "Select itemName from Menu";
            SqlCommand cmd = new SqlCommand(comboquery, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int statusindex = sdr.GetOrdinal("itemName");
                
                string fill = sdr.IsDBNull(statusindex) ? null : sdr.GetString(statusindex);
               
                if (fill != null )
                {
                    comboBox1.Items.Add(fill);
                   
                }

            }
            sdr.Close();
            con.Close();

        }
        void populatecatname()
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string comboquery = "Select distinct itemcategory from Menu";
            SqlCommand cmd = new SqlCommand(comboquery, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int statusindex = sdr.GetOrdinal("itemcategory");

                string fill = sdr.IsDBNull(statusindex) ? null : sdr.GetString(statusindex);

                if (fill != null)
                {
                    comboBox2.Items.Add(fill);

                }

            }
            sdr.Close();
            con.Close();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (textBox3.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill or Check the boxes again");
                }
                else if (Convert.ToInt32(textBox3.Text) <= 0)
                {
                    MessageBox.Show("Ooops...Please correct the price.😜");
                }
                else
                {
                    Object itemname = comboBox1.SelectedItem;
                    Object catname = comboBox2.SelectedItem;

                    string query = "UPDATE Menu SET itemprice = '" + textBox3.Text + "' WHERE itemName = '" + itemname + "' and itemcategory = '" + catname + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Price Updated");
                    clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Some Problem Has Occured..😜");
            }
            

            }
        void clear()
        {
            comboBox1.SelectedIndex = -1;
            textBox3.Clear();
            comboBox2.SelectedIndex = -1;
        }

        }
    }

