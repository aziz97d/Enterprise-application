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
    public partial class frmProductPriceNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmProductPriceNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductPriceNew_Load(object sender, EventArgs e)
        {
            this.MaximumSize = Size;
            this.MinimumSize = Size;

            Product product = new Product();
            cmbProduct.DataSource = product.Select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
            cmbProduct.SelectedValue = -1;

            Unit unit = new Unit();
            cmbUnit.DataSource = unit.Select().Tables[0];
            cmbUnit.DisplayMember = "name";
            cmbUnit.ValueMember = "id";
            cmbUnit.SelectedValue = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                er++;
                ep.SetError(txtPrice,"Required");
            }
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbProduct,"Required");
            }
            if (cmbUnit.SelectedValue == null || cmbUnit.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbUnit,"Required");
            }

            if(er>0)
                return;
            ProductPrice productPrice = new ProductPrice();
            productPrice.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            productPrice.UnitId = Convert.ToInt32(cmbUnit.SelectedValue);
            productPrice.Price = Convert.ToDouble(txtPrice.Text);

            if (productPrice.Insert())
            {
                MessageBox.Show("Data Saved");
                cmbProduct.SelectedValue = -1;
                cmbUnit.SelectedValue = -1;
                txtPrice.Text = "";
                cmbProduct.Focus();
            }
            else
            {
                MessageBox.Show(productPrice.Error);
            }

        }
    }
}
