using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperShop.DAL;
using SuperShop.Report;

namespace SuperShop.Presentation
{
    public partial class frmCashFlow : Form
    {
        public frmCashFlow()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport rpt = new frmReport("CashFlow", (DataTable) myGrid1.DataSource);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            myGrid1.DataSource = reports.CashFlow().Tables[0];
        }
    }
}
