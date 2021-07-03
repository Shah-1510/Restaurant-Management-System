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
    public partial class Viewdealtomanager : Form
    {
        public Viewdealtomanager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            DateTime dateTime;
            if (string.IsNullOrEmpty(dateTimePicker1.Text) || (string.IsNullOrEmpty(dateTimePicker2.Text)))
            {
                MessageBox.Show("Please Fill all boxes First");
            }
            else if (DateTime.TryParse(dateTimePicker2.Text, out dateTime) == false || DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
            {
                MessageBox.Show("Invalid Dates");
            }
            else if (DateTime.Parse(dateTimePicker1.Text) > DateTime.Parse(dateTimePicker2.Text))
            {
                MessageBox.Show("Invalid Dates");
            }
            else
            {
                string query = "select distinct deal_date AS Date, deal_name AS Name, deal_price AS Price from Deal WHERE deal_date between '" + DateTime.Parse(dateTimePicker1.Text) + "' and '" + DateTime.Parse(dateTimePicker2.Text) + "' order by deal_date";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    label4.Show();
                }
                else
                {
                    label4.Hide();
                    dataGridView1.DataSource = dt;
                }
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deals m = new Deals();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Viewdealtomanager_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

       
    }
}
