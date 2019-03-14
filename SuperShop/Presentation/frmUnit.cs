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
    public partial class frmUnit : SuperShop.Presentation.Template.frmDispaly
    {
        public frmUnit()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Unit unit = new Unit();
            myGrid2.DataSource = unit.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmUnitNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            new frmUnitEdit(id).ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Unit unit = new Unit();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            unit.Id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            if (unit.Delete())
            {
                MessageBox.Show("Unit Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(unit.Error);
            }
        }
    }
}
