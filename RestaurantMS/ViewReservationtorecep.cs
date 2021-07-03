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
    public partial class ViewReservationtorecep : Form
    {
        public ViewReservationtorecep()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewselectedreservation vsr = new viewselectedreservation();
            vsr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist r = new Receptionist();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewallreservation va = new viewallreservation();
            va.Show();
        }
    }
}
