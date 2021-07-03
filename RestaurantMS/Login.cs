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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selectone so = new Selectone();
            so.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            String query = String.Format("select * from [User] where login = '{0}' and password = '{1}'",textBox1.Text.ToLower(), textBox2.Text.ToLower());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                bool manager = sdr.GetBoolean(3);
                bool receptionist = sdr.GetBoolean(4);
                if (manager)
                {
                    this.Hide();
                    Manager m = new Manager();
                    m.Show();
                }
                else if (receptionist)
                {
                    this.Hide();
                    Receptionist r = new Receptionist();
                    r.Show();
                }
                else
                {
                    MessageBox.Show("Wrong User Name or Password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                con.Close();
            }
        }
    }
}
