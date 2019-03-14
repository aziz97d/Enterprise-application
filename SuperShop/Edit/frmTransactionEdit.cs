using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.Presentation
{
    public partial class frmTransactionEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmTransactionEdit(int id=0)
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
