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
    public partial class frmCity : SuperShop.Presentation.Template.frmDispaly
    {
        public frmCity()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.City city = new City();
            city.Search = txtSearch.Text;
            myGrid2.DataSource = city.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCityNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (myGrid2.SelectedRows.Count <= 0)
                return;
            int id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);

            new frmCityEdit(id).ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            City city = new City();
            if(myGrid2.SelectedRows.Count<=0)
                return;
            city.Id = Convert.ToInt32(myGrid2.SelectedRows[0].Cells["colId"].Value);
            
            if (city.Delete())
            {
                MessageBox.Show("City Deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(city.Error);
            }
        }
    }
}
