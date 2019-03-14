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
    public partial class frmBrandEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        Brand brand = new Brand();
            
        public frmBrandEdit(int id =0)
        {
            brand.Id = id;
            InitializeComponent();
        }

        private void frmBrandEdit_Load(object sender, EventArgs e)
        {
            
            brand.SelectById();

            txtName.Text = brand.Name;
            txtOrigin.Text = brand.Origin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            brand.Name = txtName.Text;
            brand.Origin = txtOrigin.Text;

            if (brand.Update())
            {
                MessageBox.Show("Update Successful");
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
