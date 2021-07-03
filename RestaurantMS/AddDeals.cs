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
using System.Globalization;
using System.Configuration;

namespace RestaurantMS
{
    public partial class AddDeals : Form
    {
        public AddDeals()
        {
            InitializeComponent();
            populatecheckbox();
        }
        void cleaar()
        {
            textBox1.Clear();
            textBox3.Clear();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand cmd = new SqlCommand("Select deal_name from Deal WHERE deal_name = '"+textBox1.Text+"'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read() == true)
                {
                    MessageBox.Show("Deal with this Name Already Exists, Try a Different Name");
                }
                sdr.Close();
                SqlCommand cmd1 = new SqlCommand("SELECT deal_date FROM Deal WHERE deal_date = '" + dateTimePicker1.Text + "'", con);
                SqlDataReader sdr1 = cmd1.ExecuteReader();
                DateTime dateTime;
                if (textBox1.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please fill all text boxes");
                }


                else if (DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
                {
                    MessageBox.Show("Not valid date");
                }

                else if (Convert.ToInt32(textBox3.Text) <= 0)
                {
                    MessageBox.Show("Enter the correct amount");
                }
                else if (DateTime.Parse(dateTimePicker1.Text) < DateTime.Today)
                {
                    MessageBox.Show("Date has passed");
                }

                else if (!checklist())
                {
                    MessageBox.Show("Select atleast one item");
                }
                else if (sdr1.Read() == true)
                {
                    MessageBox.Show("There is already a deal on this date");
                }
                else
                {
                    string q = "INSERT INTO Deal (deal_name,deal_date,deal_price) VALUES ('" + textBox1.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + textBox3.Text + "')";
                    sdr1.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    foreach (var checkItems in checkedListBox1.CheckedItems)
                    {
                        string query = "INSERT INTO menuDeal (deal_name, itemNo) values ('" + textBox1.Text + "',(select itemNo from Menu where itemName = '" + checkItems.ToString() + "'))";
                        SqlDataAdapter sda2 = new SqlDataAdapter(query, con);
                        sda2.SelectCommand.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Deal Added");
                }
            }
            catch (Exception eq)
            {
                MessageBox.Show(eq.StackTrace);
            }
        }
        bool checklist()
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.CheckedItems.Contains("ItemsWithIndex'"+i+"'") !=null)
                {
                    return true;
                }

            }
            return false;
        }

        private void AddDeals_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }
        void populatecheckbox()
        {
            string q = "select itemName from Menu";
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                int statusindex = r.GetOrdinal("itemName");
                string fill = r.IsDBNull(statusindex) ? null : r.GetString(statusindex);
                if (fill != null)
                {
                    checkedListBox1.Items.Add(fill);
                }
            }
            r.Close();
           // con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deals d = new Deals();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
