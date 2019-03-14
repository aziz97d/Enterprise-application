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
    public partial class frmCategory : SuperShop.Presentation.Template.frmDispaly
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Search = txtSearch.Text;
            try
            {
                category.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            }
            catch{}
            myGrid2.DataSource = category.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCategoryNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);
            new frmCategoryEdit(id).ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            category.Id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            if (category.Delete())
            {
                MessageBox.Show("Category Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            Category category = new Category();
            cmbCategory.DataSource = category.Select().Tables[0];

            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;
        }
    }
}
