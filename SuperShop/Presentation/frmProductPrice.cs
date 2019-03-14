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
    public partial class frmProductPrice : SuperShop.Presentation.Template.frmDispaly
    {
        public frmProductPrice()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductPrice productPrice = new ProductPrice();
            productPrice.Search = txtSearch.Text;
            myGrid2.DataSource = productPrice.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductPriceNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int productId = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colProductId"].Value);
            int unitId = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colUnitId"].Value);

            new frmProductPriceEdit(productId,unitId).ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductPrice productPrice = new ProductPrice();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            productPrice.ProductId = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colProductId"].Value);
            productPrice.UnitId = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colUnitId"].Value);

            if (productPrice.Delete())
            {
                MessageBox.Show("Product Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(productPrice.Error);
            }
        }
    }
}
