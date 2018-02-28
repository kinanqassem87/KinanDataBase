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
    public partial class FRM_SignIn : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\KinanData.accdb;Persist Security Info=True");
        OleDbDataAdapter da;
        string stateEnter = "0";
        public FRM_SignIn()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();

            try
            {

                da = new OleDbDataAdapter("select * from Users ", con);
                da.Fill(dt);
                if (txtUserN.Text.Equals("") || txtPass.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء ادخال اسم المستخدم و كلمة المرور");
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][1].Equals(txtUserN.Text))
                        {
                            if (dt.Rows[i][2].Equals(txtPass.Text))
                            {
                                Close();
                                stateEnter = "1";
                                FRM_Main.User_ID = dt.Rows[i][0].ToString();
                                FRM_Main.FullName = dt.Rows[i][4].ToString();
                                FRM_Main.UserName = dt.Rows[i][1].ToString();
                                FRM_Main.Password = dt.Rows[i][2].ToString();

                                if (dt.Rows[i][3].Equals("admin"))
                                {
                                    FRM_Main.per = "admin";

                                }
                                if (dt.Rows[i][3].Equals("user"))
                                {
                                    FRM_Main.per = "user";
                                }

                            }

                        }
                    }
                    if (!stateEnter.Equals("1"))
                    {
                        MessageBox.Show("اسم المستخدم أو كلمة السر غير صحيحة");
                        txtUserN.Text = txtPass.Text = "";
                    }
                }
            }
            catch(Exception){}    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
