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
    public partial class frmTransactionNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmTransactionNew(string vocher="Debit")
        {
            InitializeComponent();
            cmbVoucher.Text = vocher;
        }

        private void frmTransactionNew_Load(object sender, EventArgs e)
        {
            DAL.Ledger ledger =new Ledger();
            cmbEmployee.DataSource = ledger.Select().Tables[0];
            cmbEmployee.ValueMember = "id";
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.SelectedValue = -1;

            cmbLedger.DataSource = ledger.Select().Tables[0];
            cmbLedger.ValueMember = "id";
            cmbLedger.DisplayMember = "name";
            cmbLedger.SelectedValue = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                er++;
                ep.SetError(txtNumber,"Required");
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                er++;
                ep.SetError(txtAmount,"Required");
            }
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbEmployee,"Required");
            }
            if (cmbLedger.SelectedValue == null || cmbLedger.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbLedger,"Required");
            }
            if(er>0)
                return;
            
            Transaction trs = new Transaction();
            trs.DateTime = dtpDate.Value;
            trs.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            trs.LedgerId = Convert.ToInt32(cmbLedger.SelectedValue);
            trs.Number = txtNumber.Text;
            trs.Reference = cmbVoucher.Text;
            trs.Remarks = txtRemarks.Text;
            if (cmbVoucher.Text == "Credit")
            {
                trs.Credit = Convert.ToDouble(txtAmount.Text);
                trs.Debit = 0;
            }
            else
            {
                trs.Debit = Convert.ToDouble(txtAmount.Text);
                trs.Credit = 0;
            }

            if (trs.Insert())
            {
                MessageBox.Show(trs.Reference + " Voucher Saved");
                cmbEmployee.SelectedValue = -1;
                cmbLedger.SelectedValue = -1;
                txtNumber.Text = "";
                txtRemarks.Text = "";
            }
            else
            {
                MessageBox.Show(trs.Error);
            }
        }
    }
}
