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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            loadTables();
            getMaxResID();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist rp = new Receptionist();
            rp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void clear()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select res_id FROM Reservation WHERE res_id = '" + textBox3.Text + "'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                int tableno = (int)comboBox1.SelectedItem;
                DateTime datetime;
                if (textBox1.Text == "" || textBox3.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please fill the Boxes");

                }

                if (Convert.ToInt32(textBox1.Text) <= 0)
                {
                    MessageBox.Show("Incorrect Number of Chairs");
                }
                else if (rdr.Read() == true)
                {
                    MessageBox.Show("Please try a Different ID");
                }
                else if (DateTime.TryParse(dateTimePicker1.Text, out datetime) == false)
                {
                    MessageBox.Show("Not a Valid date");
                }
                else if (DateTime.Parse(dateTimePicker1.Text) < DateTime.Today)
                {
                    MessageBox.Show("hmmph This Date has Passed, Can't Reserved");
                }
                else
                {
                    string query2 = "INSERT into Reservation (tableNo, noofchairs, res_date, res_id, res_name) VALUES ('" + tableno + "','" + textBox1.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    rdr.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your Table Is Reserverd..");
                    clear();

                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured");
                
            }
            
            

        }
        void getMaxResID()
        {
            int maxId = 0;
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            String query = "Select MAX(res_id) from Reservation";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                maxId = rdr.GetInt32(0);
            }
            int curr_id = maxId + 1;
            textBox3.Text = curr_id.ToString();
            textBox3.Enabled = false;
        }
        void loadTables()
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "select tableNo from Reservation";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            bool[] visited = new bool[51];
            for (int i = 1; i <= 50; i++)
                visited[i] = false;

            int c = ds.Tables[0].Rows.Count;
            for (int k = 0; k < c; k++)
            {
                visited[(int)ds.Tables[0].Rows[k]["tableNo"]] = true;
            }
            for (int i = 1; i <= 50; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if ((int)ds.Tables[0].Rows[j]["tableNo"] != i && !visited[i])
                    {
                        comboBox1.Items.Add(i);
                        visited[i] = true;
                    }
                }
            }
            con.Close();        
        }
    }
}
    