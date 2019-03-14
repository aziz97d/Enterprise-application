using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShop.Presentation.MyControls
{
    public partial class ucDateSearch : UserControl
    {
        public ucDateSearch()
        {
            InitializeComponent();
        }

        private void ucDateSearch_Load(object sender, EventArgs e)
        {
            DateCheckUncheck();
        }

        private void DateCheckUncheck()
        {
            dtpDateFrom.Enabled = chkDateSearch.Checked;
            dtpDateTo.Enabled = chkDateSearch.Checked;
        }

        public DateTime DateFrom
        {
            get { return dtpDateFrom.Value; }
            set { dtpDateFrom.Value = value; }
        }
        public DateTime DateTo
        {
            get { return dtpDateTo.Value; }
            set { dtpDateTo.Value = value; }
        }

        public bool IsDateEnable
        {
            get { return chkDateSearch.Checked; }
        }

        private void chkDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            DateCheckUncheck();
        }
    }
}
