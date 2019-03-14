using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SuperShop.Report
{
    public partial class frmReport : Form
    {
        public frmReport(string reportName, DataTable dt)
        {
            
            InitializeComponent();
            reportViewer1.Reset();

            ReportDataSource ds  = new ReportDataSource("DataSet1", dt );
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = "Report/" + reportName + ".rdlc";
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Reports/" + reportName + ".rdlc";
            reportViewer1.LocalReport.Refresh();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
