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
    public partial class viewinventory : Form
    {
        public viewinventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewselectedcs vse = new viewselectedcs();
            vse.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllInven v = new ViewAllInven();
            v.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory v = new Inventory();
            v.Show();
        }
    }
}
