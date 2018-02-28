using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KinanDataBase
{
    public partial class FRM_Data : Form
    {
        int id=0;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\KinanData.accdb;Persist Security Info=True");
        public FRM_Data()
        {
            InitializeComponent();
            display();
        }
        void display() 
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select Data_id,D_Name,D_Place,D_Explane from Data_K order by Data_id desc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvdata.DataSource = dt;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Data_K where D_Name+D_Place+D_Explane like '%" + txtsearch.Text + "%' order by Data_id desc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvdata.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text.Equals(""))
                {
                    MessageBox.Show("Fill Fields");
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("insert into Data_K (D_Name,D_Place,D_Explane) values ('" + txtname.Text + "','" + rtxtplace.Text + "','" + rtxtexplane.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Done");
                    txtname.Text = rtxtexplane.Text = rtxtplace.Text = "";
                    display();
                }
            }
            catch (Exception) { MessageBox.Show("Data very Long"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text.Equals("") || id == 0)
                {
                    MessageBox.Show("Select One");
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand("update Data_K set" +
                        " D_Name='" + txtname.Text + "',D_Place='" + rtxtplace.Text + "',D_Explane='" + rtxtexplane.Text + "' where Data_id=" + id + " ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Done");
                    txtname.Text = rtxtexplane.Text = rtxtplace.Text = "";
                    display();
                }
            }
            catch (Exception) { MessageBox.Show("Data very Long"); }
        }

        private void dgvdata_DoubleClick(object sender, EventArgs e)
        {
            txtname.Text = dgvdata.CurrentRow.Cells[1].Value.ToString();
            rtxtplace.Text = dgvdata.CurrentRow.Cells[2].Value.ToString();
            rtxtexplane.Text = dgvdata.CurrentRow.Cells[3].Value.ToString();
            id = int.Parse(dgvdata.CurrentRow.Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Equals("") || id == 0)
            {
                MessageBox.Show("Select One");
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("delete from Data_K where Data_id=" + id + " ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                txtname.Text = rtxtexplane.Text = rtxtplace.Text = "";
                display();
            }
        }
    }
}
