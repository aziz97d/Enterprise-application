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
    public partial class frmSaleReport : Form
    {
        public frmSaleReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.SaleReport reports = new SaleReport();
            reports.Search = txtSearch.Text;
            reports.IsDateSearch = ucDateSearch1.IsDateEnable;
            reports.DateFrom = ucDateSearch1.DateFrom;
            reports.DateTo = ucDateSearch1.DateTo;
            reports.CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            reports.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            reports.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);


            myGrid1.DataSource = reports.Select().Tables[0];
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport("Sales",(DataTable) myGrid1.DataSource);
            report.ShowDialog();
        }

        private void frmSaleReport_Load(object sender, EventArgs e)
        {
            Product product = new Product();
            cmbProduct.DataSource = product.Select().Tables[0];
            cmbProduct.ValueMember = "id";
            cmbProduct.DisplayMember = "name";
            cmbProduct.SelectedValue = -1;

            Ledger ledger = new Ledger();
            ledger.Type = "c";
            cmbCustomer.DataSource = ledger.Select().Tables[0];
            cmbCustomer.DisplayMember = "name";
            cmbCustomer.ValueMember = "id";
            cmbCustomer.SelectedValue = -1;

            ledger.Type = "e";
            cmbEmployee.DataSource = ledger.Select().Tables[0];
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";
            cmbEmployee.SelectedValue = -1;

        }
    }
}
