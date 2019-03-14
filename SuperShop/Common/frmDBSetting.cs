using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShop.Common
{
    public partial class frmDBSetting : Form
    {
        public frmDBSetting()
        {
            InitializeComponent();
        }

        private void frmDBSetting_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = !chkWindows.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String s = "";
            if (chkWindows.Checked)
            {
                s = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", txtServer.Text, txtDatabase.Text);
            }
            else
            {
                s = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtServer.Text, txtDatabase.Text, txtUserId.Text, txtPassword.Text);
            }
            SuperShop.Properties.Settings.Default.MyCon = s;
            SuperShop.Properties.Settings.Default.Save();
            MessageBox.Show("Database Setting Saved");
        }

        private void chkWindows_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !chkWindows.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
