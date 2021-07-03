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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            bool IsManager = false;
            bool IsReceptionsist = false;
            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Please Select Only One Box");
            }
            else if (checkBox1.Checked)
            {
                IsManager = true;
            }
            else if (checkBox2.Checked)
            {
                IsReceptionsist = true;
            }
            else if (!checkBox1.Checked || !checkBox2.Checked || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Fill All the boxes.");
            }

            string query = "INSERT INTO [User] (login, password, IsManager, IsReceptionist) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + IsManager + "','" + IsReceptionsist + "')";
            SqlDataAdapter spd = new SqlDataAdapter(query, con);
            spd.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("WELCOME");
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SignInorUp sp = new SignInorUp();
            sp.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
