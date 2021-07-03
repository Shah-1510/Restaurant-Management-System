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
    public partial class Printorder : Form
    {
        public Printorder()
        {
            InitializeComponent();
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist r = new Receptionist();
            r.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Printorder_Load(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();



            SqlDataAdapter asd = new SqlDataAdapter("select customer.cust_id,customer.cust_name,customer.phNO,invoice.invo_no,invoice.ord_no,invoice.deal_name,invoice.noOfDeals,invoice.amount from invoice inner join customer ON customer.cust_id = invoice.cust_id ", con);
            DataTable dt = new DataTable();
            asd.Fill(dt);
            dataGridView1.DataSource = dt;
            VisiDataView();
            con.Close();



        }
        void VisiDataView()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value.ToString() == "")
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager1.SuspendBinding();
                    dr.Visible = false;
                }
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_ColumnAdded_1(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_AutoSizeRowsModeChanged_1(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("  MY CAFE/RESTAURANT MANAGEMENT SYSTEM ", new Font("century", 18, FontStyle.Bold), Brushes.Red, new Point(100, 20));
            e.Graphics.DrawString("===== ORDERS SUMMARY =====", new Font("century", 17, FontStyle.Bold), Brushes.Red, new Point(240, 70));
            e.Graphics.DrawString("Customer ID:          " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 135));
            e.Graphics.DrawString("Customer Name:        " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 185));
            e.Graphics.DrawString("Phone Number:         " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 235));
            e.Graphics.DrawString("Invoice Number:       " + dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 285));
            e.Graphics.DrawString("Order Number:         " + dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 335));
            e.Graphics.DrawString("Deal Name:            " + dataGridView1.SelectedRows[0].Cells[5].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 385));
            e.Graphics.DrawString("Number Of Deals:      " + dataGridView1.SelectedRows[0].Cells[6].Value.ToString(), new Font("century", 17, FontStyle.Regular), Brushes.Black, new Point(120, 435));
            e.Graphics.DrawString("\t\t\t\t AMOUNT:     " + dataGridView1.SelectedRows[0].Cells[7].Value.ToString(), new Font("century", 19, FontStyle.Regular), Brushes.Red, new Point(120, 485));
            e.Graphics.DrawString("===== POWERED BY SHAH, HUMZA AND FARAZ =====", new Font("century", 15, FontStyle.Bold), Brushes.Red, new Point(150, 590));
            
        }
    }
    }

