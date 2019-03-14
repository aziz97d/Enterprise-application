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
    public partial class frmUnitEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        DAL.Unit unit = new DAL.Unit() ;

        public frmUnitEdit(int id=0)
        {
            unit.Id = id;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUnitEdit_Load(object sender, EventArgs e)
        {
            unit.SelectById();
            txtName.Text = unit.Name;
            txtDescription.Text = unit.Description;
            txtPrimaryQuantity.Text = unit.PrimaryQuantity;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if (string.IsNullOrEmpty(txtPrimaryQuantity.Text))
            {
                er++;
                ep.SetError(txtPrimaryQuantity, "Required");
            }

            if (er > 0)
                return;

            unit.Name = txtName.Text;
            unit.Description = txtDescription.Text;
            unit.PrimaryQuantity = txtPrimaryQuantity.Text;

            if (unit.Update())
            {
                MessageBox.Show("Unit Updated");

                txtName.Focus();
            }
            else
            {
                MessageBox.Show(unit.Error);
            }
        }
    }
}
