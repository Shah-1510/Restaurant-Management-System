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
using System.Globalization;

namespace RestaurantMS
{
    public partial class insertitemininventory : Form
    {
        public insertitemininventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inv = new Inventory();
            inv.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void insertitemininventory_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                DateTime dateTime;
                if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "")
                {
                    MessageBox.Show("Fill all text box first");
                }
                else if (Convert.ToInt32(textBox2.Text) <= 0)
                {
                    MessageBox.Show("Quantity should be more 😊");
                }
                else if (DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
                {
                    MessageBox.Show("Not valid date");
                }
                else if (DateTime.Parse(dateTimePicker1.Text) < DateTime.Today)
                {
                    MessageBox.Show("This date has passed, please enter new date");
                }
                else
                {
                    string q = "INSERT INTO Inventory (itmName , qty , itm_date) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Inserted in Inventory");
                    clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Enter Again in inventory.");
            }
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            
        }

    
        }
    }

