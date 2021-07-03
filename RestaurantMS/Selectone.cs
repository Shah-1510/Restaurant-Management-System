using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMS
{
    public partial class Selectone : Form
    {
        public Selectone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F = new Form1();
            F.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInorUp Sign = new SignInorUp();
            Sign.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInorUp sign = new SignInorUp();
            sign.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           Customer c = new Customer();
            c.Show();
        }

        private void Selectone_Load(object sender, EventArgs e)
        {

        }
    }
}
