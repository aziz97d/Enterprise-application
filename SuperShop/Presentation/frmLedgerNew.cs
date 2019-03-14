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
    public partial class frmLedgerNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmLedgerNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*jpg|PNG|*.png|GIF|*.gif";
            openFileDialog.ShowDialog();

            if (string.IsNullOrEmpty(openFileDialog.FileName))
                return;

            pbImage.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void llClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.Image = null;
        }

        private void frmLedgerNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            DAL .City ct = new City();
            cmbCity.DataSource = ct.Select().Tables[0];
            cmbCity.ValueMember = "id";
            cmbCity.DisplayMember = "name";
            cmbCity.SelectedValue = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            string type = "C";
            if (string.IsNullOrEmpty(txtName.Text))
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if (string.IsNullOrEmpty(txtContact.Text))
            {
                er++;
                ep.SetError(txtContact, "Required");
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                er++;
                ep.SetError(txtEmail, "Required");
            }
            if (!rbFemale.Checked && !rbMale.Checked)
            {
                er++;
                ep.SetError(gbGender,"Required");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }
            
            if (DateTime.Now == dtpDateOfBirth.Value)
            {
                er++;
                ep.SetError(dtpDateOfBirth, "Required");
            }
            if (txtAddress.Text.Length < 10)
            {
                er++;
                ep.SetError(txtAddress, "Must be 10 character");
            }
            if (Convert.ToInt32(cmbCity.SelectedValue) < 0)
            {
                er++;
                ep.SetError(cmbCity, "Required");
            }
            if (pbImage.Image == null)
            {
                er++;
                ep.SetError(pbImage, "Required");
            }
            

            if (er > 0)
                return;

       
            DAL.Ledger ledger = new Ledger();
            if (rbEmployee.Checked)
                type = "E";
            if (rbSupplier.Checked)
                type = "S";
            if (rbMale.Checked)
                ledger.Gender = 0;
            if (rbFemale.Checked)
                ledger.Gender = 1;   
            ledger.Name = txtName.Text;
            ledger.Contact = txtContact.Text;
            ledger.Email = txtEmail.Text;
            ledger.Password = txtPassword.Text;
            ledger.DateOfBirth = dtpDateOfBirth.Value;
            ledger.CreateDate =DateTime.Now;
            ledger.Address = txtAddress.Text;
            ledger.CityId = Convert.ToInt32(cmbCity.SelectedValue);
            ledger.Image = FileClass.ImageToByte(pbImage.Image);
            ledger.Type = type;

            if (ledger.Insert())
            {
                MessageBox.Show("Data Saved");
                txtName.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                rbMale.Checked = false;
                rbFemale.Checked = false;
                dtpDateOfBirth.Value = DateTime.Now;
                txtAddress.Text = "";
                cmbCity.SelectedValue = -1;
                pbImage.Image = null;
                rbCustomer.Checked = true;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
            
        }
    }
}
