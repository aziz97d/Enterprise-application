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
    public partial class frmProductImageEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        ProductImage productImage = new ProductImage();
        public frmProductImageEdit(int productId=0)
        {
            productImage.ProductId = productId;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductImageEdit_Load(object sender, EventArgs e)
        {
            Product product = new Product();
            cmbProduct.DataSource = product.Select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";

            productImage.SelectById();

            cmbProduct.SelectedValue = productImage.ProductId;
            txtTitle.Text = productImage.Title;
            productImage.Image = productImage.Image;
        }
    }
}
