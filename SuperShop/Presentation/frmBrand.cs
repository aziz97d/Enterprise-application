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
    public partial class frmBrand : SuperShop.Presentation.Template.frmDispaly
    {
        public frmBrand()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmBrandNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            new frmBrandEdit(id).ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            brand.Search = txtSearch.Text;
            myGrid2.DataSource = brand.Select().Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            brand.Id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);
            
            if (brand.Delete())
            {
                MessageBox.Show("Brand Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
        }
    }
}
