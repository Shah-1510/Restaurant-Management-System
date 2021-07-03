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
    public partial class viewdeals : Form
    {
        public viewdeals()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Customer c = new Customer();
            c.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView2.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;

        }


        private void viewdeals_Load(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "select deal_name AS DealName, deal_price AS Price from Deal where deal_date = '" + DateTime.Today + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string query2 = "select m.itemName AS ITEMS from Menu m, Deal d, menuDeal md where m.itemNo = md.itemNo AND md.deal_name = d.deal_name AND deal_date = '" + DateTime.Today + "' Group by m.itemName";
                SqlDataAdapter sdp = new SqlDataAdapter(query2, con);
                DataTable dt1 = new DataTable();
                sdp.Fill(dt1);



                if (dt.Rows.Count == 0)
                {
                    this.label1.Show();
                    this.label2.Show();
                    dataGridView1.Hide();
                    dataGridView2.Hide();

                }
                else
                {
                    dataGridView1.DataSource = dt;
                    dataGridView2.DataSource = dt1;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Some Problem Has Occured.. Please Check Your Query.");

            }
        }

        


    }

    //int itemNo;
    //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    //{

    //    try
    //    {
    //        String conString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
    //        SqlConnection con = new SqlConnection(conString);
    //        con.Open();
    //        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
    //        {
    //            itemNo = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
    //        }
    //        string query2 = "select m.itemName AS ITEMS from Menu m, Deal d, menuDeal md where m.itemNo = md.itemNo AND md.deal_name = d.deal_name AND deal_date = '" + DateTime.Today + "' Group by m.itemName";
    //        SqlDataAdapter sdp = new SqlDataAdapter(query2, con);
    //        DataTable dt1 = new DataTable();
    //        sdp.Fill(dt1);

    //        if (dt1.Rows.Count == 0)
    //        {
    //            //    this.label1.Show();
    //            this.label2.Show();
    //            //     dataGridView1.Hide();
    //            dataGridView2.Hide();

    //        }
    //        /*
    //        else
    //        {
    //            //      dataGridView1.DataSource = dt;
    //            dataGridView2.DataSource = dt1;
    //        }
    //        */
    //        con.Close();
    //    }
    //    catch (Exception)
    //    {
    //        MessageBox.Show("Some Problem Has Occured.. Please Check Your Query.");

    //    }

    //}


    
}
