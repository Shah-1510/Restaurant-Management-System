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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewinventory vi = new viewinventory();
            vi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            insertitemininventory iii = new insertitemininventory();
            iii.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateinventory up = new updateinventory();
            up.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager m = new Manager();
            m.Show();
        }
    }
}
