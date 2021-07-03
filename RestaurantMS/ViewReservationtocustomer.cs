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
    public partial class ViewReservationtocustomer : Form
    {
        public ViewReservationtocustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer c = new Customer();
            c.Show();
        }
        void clear()
        {
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            try
            {
                string sql2 = "select res_id AS AssignedID, res_name AS Name,tableNo AS TableNo, noofchairs AS Chairs, res_date AS Date from Reservation where res_id = '" + Convert.ToInt32(textBox1.Text) + "'";
                SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    label2.Show();
                    dataGridView1.DataSource = null;
                }
                else
                {
                    label2.Hide();
                    dataGridView1.DataSource = dt;
                    clear();
                }

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Write Correct Reservation ID");

            }
            
        }
    }
}
