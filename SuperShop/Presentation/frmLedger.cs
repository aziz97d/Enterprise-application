using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuperShop.DAL;

namespace SuperShop.Presentation
{
    public partial class frmLedger : SuperShop.Presentation.Template.frmDispaly
    {
        public frmLedger()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Ledger ledger = new Ledger();
            myGrid2.DataSource = ledger.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmLedgerNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            new frmLedgerEdit(id).ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Ledger ledger = new Ledger();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            ledger.Id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            if (ledger.Delete())
            {
                MessageBox.Show("Ledger Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
        }
    }
}
