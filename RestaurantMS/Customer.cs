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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewdeals vd = new viewdeals();
            vd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selectone su = new Selectone();
            su.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationtocustomer vrc = new ViewReservationtocustomer();
            vrc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewmenu vm = new viewmenu();
            vm.Show();
        }
    }
}
