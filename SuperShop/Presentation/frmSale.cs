using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
using SuperShop.DAL;
using SuperShop.Report;

namespace SuperShop.Presentation
{
    public partial class frmSale : Form
    {
        public frmSale()
        {
            InitializeComponent();
        }

        private void btnNewPos_Click(object sender, EventArgs e)
        {
            new frmSale().ShowDialog();

        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            double paid = 0;
            double returns = 0;

            try
            {
                paid = Convert.ToDouble(txtPaid.Text);
                returns = Convert.ToDouble(txtGranTotal.Text);
                returns = (paid - returns);
            }
            catch (Exception){}
            txtReturn.Text = returns.ToString();
        }

        

        private void frmSale_Load(object sender, EventArgs e)
        {
            DAL.Ledger lgr = new Ledger();
            lgr.Type = "C";
            cmbLadger.DataSource = lgr.Select().Tables[0];
            cmbLadger.DisplayMember = "name";
            cmbLadger.ValueMember = "id";
            cmbLadger.SelectedValue = -1;

            lgr.Type = "E";
            cmbEmployee.DataSource = lgr.Select().Tables[0];
            cmbEmployee.ValueMember = "id";
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.SelectedValue = -1;

            if (cmbEmployee.Items.Count == 1)
                cmbEmployee.SelectedIndex = 0;

            DAL.Product product = new Product();
            colProduct.DataSource = product.Select().Tables[0];
            colProduct.ValueMember = "id";
            colProduct.DisplayMember = "name";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmLedgerNew().ShowDialog();

            DAL.Ledger lgr = new Ledger();
            lgr.Type = "C";
            cmbLadger.DataSource = lgr.Select().Tables[0];
            cmbLadger.DisplayMember = "name";
            cmbLadger.ValueMember = "id";
            cmbLadger.SelectedValue = -1;
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ProductPrice productPrice = new ProductPrice();
                
                try
                {
                    productPrice.ProductId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colProduct"].Value);
                    
                    //colUnit.DataSource = productPrice.Select().Tables[0];
                    //colUnit.DisplayMember = "unit";
                    //colUnit.ValueMember = "unitId";

                    productPrice.SelectById();
                    dgvData.Rows[e.RowIndex].Cells["colQty"].Value = 1;
                    dgvData.Rows[e.RowIndex].Cells["colRate"].Value = productPrice.Price;
                    dgvData.Rows[e.RowIndex].Cells["colVat"].Value = 0;
                    dgvData.Rows[e.RowIndex].Cells["colDiscount"].Value = 0;
                    dgvData.Rows[e.RowIndex].Cells["colSubTotal"].Value = productPrice.Price;

                }
                catch (Exception){}
            }

            //-----This code write for Unit load

            //if (e.ColumnIndex == 1)
            //{
            //    ProductPrice productPrice = new ProductPrice();
            //    try
            //    {
            //        productPrice.ProductId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colProduct"].Value);
            //        productPrice.UnitId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colUnit"].Value);
            //        productPrice.SelectById();
            //        dgvData.Rows[e.RowIndex].Cells["colQty"].Value = 1;
            //        dgvData.Rows[e.RowIndex].Cells["colRate"].Value = productPrice.Price;
            //        dgvData.Rows[e.RowIndex].Cells["colVat"].Value = 0;
            //        dgvData.Rows[e.RowIndex].Cells["colDiscount"].Value = 0;
            //        dgvData.Rows[e.RowIndex].Cells["colSubTotal"].Value = productPrice.Price;

            //    }
            //    catch (Exception) { }

            //}

            if (e.ColumnIndex == 1)
            {
                try
                {
                    double qty = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colQty"].Value);
                    double rate = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colRate"].Value);
                    dgvData.Rows[e.RowIndex].Cells["colSubTotal"].Value = (rate*qty) ;

                }
                catch (Exception){}
            }
            if (e.ColumnIndex == 3)
            {
                try
                {
                    double qty = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colQty"].Value);
                    double rate = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colRate"].Value);
                    double vat = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colVat"].Value);
                    dgvData.Rows[e.RowIndex].Cells["colSubTotal"].Value = (rate + ((rate * vat) / 100)) * qty;

                }
                catch (Exception) { }
            }
            if (e.ColumnIndex == 4)
            {
                try
                {
                    double qty = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colQty"].Value);
                    double rate = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colRate"].Value);
                    double vat = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colVat"].Value);
                    double discount = Convert.ToDouble(dgvData.Rows[e.RowIndex].Cells["colDiscount"].Value);
                    dgvData.Rows[e.RowIndex].Cells["colSubTotal"].Value = (rate - ((rate * discount) / 100) + ((rate * vat) / 100)) * qty;

                }
                catch (Exception) { }
            }

            double total = 0;
            for (int i = 0; i < dgvData.Rows.Count - 1; i++)
            {
                total += Convert.ToDouble(dgvData.Rows[i].Cells["colSubTotal"].Value);
            }
            txtTotal.Text = total.ToString();
            try
            {
                txtGranTotal.Text = (total - (total * Convert.ToDouble(txtDiscount.Text)/100) + (total * Convert.ToDouble(txtVat.Text) / 100)).ToString();
            }
            catch(Exception)
            {
                
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ErrorProvider ep = new ErrorProvider();
            int er = 0;
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                er++;
                ep.SetError(txtNumber,"required");
            }
            if (cmbEmployee.SelectedValue==null || cmbEmployee.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbEmployee,"Required");
            }
            if (cmbLadger.SelectedValue==null || cmbLadger.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbLadger,"Required");
            }
            if (dgvData.Rows.Count<=1)
            {
                er++;
                ep.SetError(dgvData,"Required");
            }
            if (er > 0)
            {
                return;
            }

            DAL.Sale sl = new Sale();
            try
            {
                sl.CustomerLedgerId = Convert.ToInt32(cmbLadger.SelectedValue);
                sl.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                sl.DateTime = dtpDate.Value;
                sl.Number = txtNumber.Text;
                sl.Total = Convert.ToDouble(txtTotal.Text);
                sl.Vat = Convert.ToDouble(txtVat.Text);
                sl.Discount = Convert.ToDouble(txtDiscount.Text);
            }
            catch{}

            if (sl.Insert())
            {
                for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                {
                    SaleDetails sld = new SaleDetails();
                    sld.ProductId = Convert.ToInt32(dgvData.Rows[i].Cells["colProduct"].Value);
                    sld.Discount = Convert.ToInt32(dgvData.Rows[i].Cells["colDiscount"].Value);
                    sld.Vat = Convert.ToInt32(dgvData.Rows[i].Cells["colVat"].Value);
                    sld.Qunatity = Convert.ToDouble(dgvData.Rows[i].Cells["colQty"].Value);
                    sld.Rate = Convert.ToDouble(dgvData.Rows[i].Cells["colRate"].Value);
                    sld.SaleId = sl.LastId;
                    sld.Insert();
                }
                
                try
                {
                    DAL.Transaction tr = new Transaction();
                    tr.Number = txtNumber.Text + "-ATS";
                    tr.DateTime = dtpDate.Value;
                    tr.LedgerId = Convert.ToInt32(cmbLadger.SelectedValue);
                    tr.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                    tr.Reference = "Credit";
                    tr.Remarks = "Aumtomatic trasaction during Sale";
                    tr.Debit = 0;
                    tr.Credit = Convert.ToDouble(txtGranTotal.Text);
                    if (!tr.Insert())
                    {
                        MessageBox.Show(tr.Error);
                    }
                }
                catch {}
    
                double paid = 0;

                try
                {
                    paid = Convert.ToDouble(txtPaid.Text);
                    DAL.Transaction trs = new Transaction();
                    trs.Number = txtNumber.Text + "-ATS";
                    trs.DateTime = dtpDate.Value;
                    trs.LedgerId = Convert.ToInt32(cmbLadger.SelectedValue);
                    trs.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                    trs.Reference = "Debit";
                    trs.Remarks = "Aumtomatic trasaction during Sale";
                    trs.Debit = paid;
                    trs.Credit = 0;

                    if (!trs.Insert())
                    {
                        MessageBox.Show(trs.Error);
                    }
                }
                catch {}

                

                MessageBox.Show("Sale Invoice Saved");

                PrintTransaction(sl.LastId);

                txtTotal.Text = "";
                txtPaid.Text = "";
                txtReturn.Text = "";
                txtGranTotal.Text = "";
                cmbLadger.SelectedValue = -1;
                txtNumber.Text = "";
                dgvData.Rows.Clear();
                txtNumber.Focus();
            }
            else
            {
                MessageBox.Show(sl.Error);
            }

            
        }

        private void PrintTransaction(int id)
        {
            frmReport report = new frmReport("AutomaticSale", new Reports().GetSaleDetails(id).Tables[0]);
            report.MdiParent = this.MdiParent;
            report.Show();
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
