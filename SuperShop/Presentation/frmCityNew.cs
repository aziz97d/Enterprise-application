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
    public partial class frmCityNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmCityNew()
        {
            InitializeComponent();
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
            if (err>0)
                return;
            City city = new City();
            city.Name = txtName.Text;

            if (city.Insert())
                MessageBox.Show("City Saved");
            else
                MessageBox.Show(city.Error);
        }
    }
}
