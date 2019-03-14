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
    public partial class frmLedgerEdit : SuperShop.Presentation.Template.frmNewEdit
    {
        Ledger ledger = new Ledger();
        public frmLedgerEdit(int id=0)
        {
            ledger.Id = id;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLedgerEdit_Load(object sender, EventArgs e)
        {
            ledger.SelectById();
            txtName.Text = ledger.Name;
            txtContact.Text = ledger.Contact;
            txtEmail.Text = ledger.Email;
            txtAddress.Text = ledger.Address;
            txtPassword.Text = ledger.Password;
            if (ledger.Gender == 0)
            {
                rbMale.Checked=true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            if (ledger.Type == "C")
            {
                rbCustomer.Checked = true;
            }
            else if (ledger.Type=="E")
            {
                rbEmployee.Checked = true;
            }
            else
            {
                rbSupplier.Checked = true;
            }

            //dtpDateOfBirth.Value = ledger.DateOfBirth;
            //pbImage.Image = ledger.Image;
            cmbCity.DataSource = new City().Select().Tables[0];
            cmbCity.DisplayMember = "name";
            cmbCity.ValueMember = "id";
            cmbCity.SelectedValue = ledger.CityId;

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
                ep.SetError(gbGender, "Required");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                er++;
                ep.SetError(txtPassword, "Required");
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
           


            if (er > 0)
                return;

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
            //ledger.DateOfBirth = dtpDateOfBirth.Value;
            
            ledger.Address = txtAddress.Text;
            ledger.CityId = Convert.ToInt32(cmbCity.SelectedValue);
            //ledger.Image = FileClass.ImageToByte(pbImage.Image);
            ledger.Type = type;

            if (ledger.Update())
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
