using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KinanDataBase
{
    public partial class FRM_Main : Form
    {
        public static string User_ID = "";
        public static string FullName = "";
        public static string UserName = "";
        public static string Password = "";
        public static string per = "";
        public FRM_Main()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            FRM_SignIn s = new FRM_SignIn();
            s.ShowDialog();
        }

        private void FRM_Main_Activated(object sender, EventArgs e)
        {
            if (per.Equals("admin"))
            {
                btnSearch.Enabled = true;
                btnSignIn.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FRM_Data d = new FRM_Data();
            d.ShowDialog();
        }
    }
}
