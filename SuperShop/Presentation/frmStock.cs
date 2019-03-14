using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperShop.DAL;
using SuperShop.Report;

namespace SuperShop.Presentation
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.StockReport reports = new DAL.StockReport();
            reports.BrandName = (string)cmbBrand.SelectedValue;
            reports.CategoryName = (string) cmbCategory.SelectedValue;
            myGrid1.DataSource = reports.Select().Tables[0];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport("Stock",(DataTable)myGrid1.DataSource);
            report.ShowDialog();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            cmbBrand.DataSource = brand.Select().Tables[0];
            cmbBrand.ValueMember = "name";
            cmbBrand.DisplayMember = "name";
            cmbBrand.SelectedValue = -1;

            Category category = new Category();
            cmbCategory.DataSource = category.Select().Tables[0];
            cmbCategory.ValueMember = "name";
            cmbCategory.DisplayMember = "name";
            cmbCategory.SelectedValue = -1;
        }
    }
}
