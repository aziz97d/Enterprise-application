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
    public partial class frmCategoryNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmCategoryNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategoryNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            Category category = new Category();
            cmbCategory.DataSource = category.Select().Tables[0];
            
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
            cmbCategory.SelectedValue = -1;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int err = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                err++;
                ep.SetError(txtName,"Required");
            }
            if(err>0)
                return;

            Category category = new Category();
            category.Name = txtName.Text;
            category.Description = txtDescription.Text;
            category.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            if (category.Insert())
            {
                MessageBox.Show("Category Saved");
                txtName.Text = "";
                txtDescription.Text = "";
                cmbCategory.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }
    }
}
