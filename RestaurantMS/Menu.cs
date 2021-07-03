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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager m = new Manager();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertinMenu im = new InsertinMenu();
            im.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModifyinMenu im = new ModifyinMenu();
            im.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemovefromMenu rm = new RemovefromMenu();
            rm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewmenutomanager vm = new viewmenutomanager();
            vm.Show();
        }
    }
}
