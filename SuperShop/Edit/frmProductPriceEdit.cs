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
    public partial class frmProductPriceEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        ProductPrice productPrice = new ProductPrice();
        public frmProductPriceEdit(int productId=0, int unitId=0)
        {
            productPrice.ProductId = productId;
            productPrice.UnitId = unitId;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductPriceEdit_Load(object sender, EventArgs e)
        {
            productPrice.SelectById();

            Unit unit = new Unit();
            cmbUnit.DataSource = unit.Select().Tables[0];
            cmbUnit.DisplayMember = "name";
            cmbUnit.ValueMember = "id";
            cmbUnit.SelectedValue = productPrice.UnitId;

            Product product = new Product();
            cmbProduct.DataSource = product.Select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
            cmbProduct.SelectedValue = productPrice.ProductId;

            txtPrice.Text = productPrice.Price.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                er++;
                ep.SetError(txtPrice, "Required");
            }
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbProduct, "Required");
            }
            if (cmbUnit.SelectedValue == null || cmbUnit.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbUnit, "Required");
            }

            if (er > 0)
                return;
            productPrice.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            productPrice.UnitId = Convert.ToInt32(cmbUnit.SelectedValue);
            productPrice.Price = Convert.ToDouble(txtPrice.Text);

            if (productPrice.Update())
            {
                MessageBox.Show("Price Updated");
                cmbProduct.Focus();
            }
            else
            {
                MessageBox.Show(productPrice.Error);
            }
        }
    }
}
