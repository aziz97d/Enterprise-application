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
    public partial class frmUnitNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmUnitNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                er++;
                ep.SetError(txtName,"Required");
            }
            if (string.IsNullOrEmpty(txtPrimaryQuantity.Text))
            {
                er++;
                ep.SetError(txtPrimaryQuantity,"Required");
            }

            if(er>0)
                return;

            Unit unit =new Unit();
            unit.Name = txtName.Text;
            unit.Description = txtDescription.Text;
            unit.PrimaryQuantity = txtPrimaryQuantity.Text;

            if (unit.Insert())
            {
                MessageBox.Show("Unit Saved");
                txtName.Text = "";
                txtDescription.Text = "";
                txtPrimaryQuantity.Text = "";

                txtName.Focus();
            }
            else
            {
                MessageBox.Show(unit.Error);
            }
        }

        private void frmUnitNew_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
    }
}
