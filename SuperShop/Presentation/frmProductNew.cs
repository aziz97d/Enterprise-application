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
    public partial class frmProductNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmProductNew()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                er++;
                ep.SetError(txtName,"Required");
            }
            if(string.IsNullOrEmpty(txtCode.Text))
            {
                er++;
                ep.SetError(txtCode,"Required");
            }
            if (cmbBrand.SelectedValue == null || cmbBrand.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbBrand,"Required");
            }
            if (cmbCategory.SelectedValue == null || cmbCategory.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbCategory,"Required");
            }

            if (er > 0) 
                return;

            Product product = new Product();
            product.Name = txtName.Text;
            product.Code = txtCode.Text;
            product.Description = txtDescription.Text;
            product.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            product.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);


            if (product.Insert())
            {
                MessageBox.Show("Data Saved");
                txtName.Text = "";
                txtCode.Text = "";
                txtDescription.Text = "";
                cmbCategory.SelectedValue = -1;
                cmbBrand.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(product.Error);
            }

        }

        private void frmProductNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            Brand brand = new Brand();
            cmbBrand.DataSource = brand.Select().Tables[0];
            cmbBrand.DisplayMember = "name";
            cmbBrand.ValueMember = "id";
            cmbBrand.SelectedValue = -1;

            Category category = new Category();
            cmbCategory.DataSource = category.Select().Tables[0];
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
