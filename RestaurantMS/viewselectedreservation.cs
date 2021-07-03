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
    public partial class viewselectedreservation : Form
    {
        public viewselectedreservation()
        {
            InitializeComponent();
        }

        private void viewselectedreservation_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;

            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationtorecep vr = new ViewReservationtorecep();
            vr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            DateTime datetime;
            if (string.IsNullOrEmpty(dateTimePicker1.Text) || (string.IsNullOrEmpty(dateTimePicker2.Text)))
            {
                MessageBox.Show("Please Fill all the boxes");
                    
            }
            else if (DateTime.TryParse(dateTimePicker2.Text, out datetime) == false || DateTime.TryParse(dateTimePicker1.Text, out datetime)== false)
            {
                MessageBox.Show("Invalid dates");
            }
            else if (DateTime.Parse(dateTimePicker1.Text) > DateTime.Parse(dateTimePicker2.Text))
            {
                MessageBox.Show("Invalid dates");
            }
            else
            {
                string query = "select tableNo, res_date as Date from Reservation where res_date between '"+DateTime.Parse(dateTimePicker1.Text)+"' and '"+DateTime.Parse(dateTimePicker2.Text)+"'order by res_date";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count.ToString() == null)
                {
                    MessageBox.Show("Please select some row");
                   
                }
                else
                {
                    String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    int tableNo = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value);
                    dataGridView1.Rows.RemoveAt(rowindex);
                    String query2 = String.Format(@"Delete from Reservation where tableNo = '{0}'", tableNo);
                    SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Reservation canceled");
                    con.Close();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured..");
            }
            


        }
    }
}
