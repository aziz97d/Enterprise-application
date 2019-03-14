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
    public partial class frmCityEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        City city = new City();
        public frmCityEdit(int id=0)
        {
            city.Id = id;
            InitializeComponent();
        }

        private void frmCityEdit_Load(object sender, EventArgs e)
        {
            city.SelectById();
            txtName.Text = city.Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            city.Name = txtName.Text;
            if (city.Update())
            {
                MessageBox.Show("City Updated");
            }
            else
            {
                MessageBox.Show(city.Error);
            }
        }
    }
}
