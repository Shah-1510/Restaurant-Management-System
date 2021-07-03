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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selectone so = new Selectone();
            so.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservation r = new Reservation();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationtorecep rp = new ViewReservationtorecep();
            rp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PLaceOrder po = new PLaceOrder();
            po.Show();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selectone l = new Selectone();
            l.Show();
        }
    }
}
