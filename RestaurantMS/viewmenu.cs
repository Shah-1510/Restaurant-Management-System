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
    public partial class viewmenu : Form
    {
        SqlConnection con;
        public viewmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer c = new Customer();
            c.Show();
        }

        private void viewmenu_Load(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                con = new SqlConnection(conString);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select itemName AS ITEMS, itemprice AS PRICE, itemcategory AS Category from Menu", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                viewDataview();
                con.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            void viewDataview()
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    dr.Visible = false;
                }
            }
            dataGridView1.Refresh();
        }
        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


    }
}
