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
    public partial class frmBrandNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmBrandNew()
        {
            InitializeComponent();
        }

        private void frmBrandNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int err = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                err++;
                ep.SetError(txtName,"Required");
            }
            if (string.IsNullOrEmpty(txtOrigin.Text))
            {
                err++;
                ep.SetError(txtOrigin,"Required");
            }
            if (err>0)
            {
                return;
            }
            Brand brand = new Brand();
            brand.Name = txtName.Text;
            brand.Origin = txtOrigin.Text;

            if (brand.Insert())
            {
                MessageBox.Show("Brand Saved");
                txtName.Text = "";
                txtOrigin.Text = "";
            } 
            else
                MessageBox.Show(brand.Error);
            
        }
    }
}
