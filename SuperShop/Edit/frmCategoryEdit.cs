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
    public partial class frmCategoryEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        Category category = new Category();
        public frmCategoryEdit(int id=0)
        {
            category.Id = id;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategoryEdit_Load(object sender, EventArgs e)
        {
            category.SelectById();
            txtName.Text = category.Name;
            txtDescription.Text = category.Description;

            cmbCategory.DataSource = category.Select().Tables[0];
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "categoryId";
            //cmbCategory.SelectedValue = category.CategoryId;
        }
    }
}
