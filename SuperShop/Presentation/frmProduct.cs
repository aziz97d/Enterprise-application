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
    public partial class frmProduct : SuperShop.Presentation.Template.frmDispaly
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Search = txtSearch.Text;
            product.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            product.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            product.IsDateSearch = ucDateSearch1.IsDateEnable;
            product.DateFrom = ucDateSearch1.DateFrom;
            product.DateTo = ucDateSearch1.DateTo;
            myGrid2.DataSource = product.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new frmProductEdit().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            product.Id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            if (product.Delete())
            {
                MessageBox.Show("Product Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(product.Error);
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            DAL.Category category = new Category();
            cmbCategory.DataSource = category.Select().Tables[0];
            
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;

            DAL.Brand brand = new Brand();
            cmbBrand.DataSource = brand.Select().Tables[0];
            cmbBrand.ValueMember = "id";
            cmbBrand.DisplayMember = "name";
            cmbBrand.SelectedValue = -1;
        }
    }
}
