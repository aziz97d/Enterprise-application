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
    public partial class frmProductImage : SuperShop.Presentation.Template.frmDispaly
    {
        public frmProductImage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductImage productImage = new ProductImage();
            productImage.Search = txtSearch.Text;
            try
            {
                productImage.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            }
            catch (Exception){ }
            
            myGrid2.DataSource = productImage.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductImageNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int productId = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colProductId"].Value);

            new frmProductImageEdit(productId).ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmProductImage_Load(object sender, EventArgs e)
        {
            Product product = new Product();
            cmbProduct.DataSource = product.Select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
            cmbProduct.SelectedValue = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductImage productImage  = new ProductImage();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            productImage.ProductId = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colProductId"].Value);

            if (productImage.Delete())
            {
                MessageBox.Show("Product Image Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(productImage.Error);
            }
        }
    }
}
