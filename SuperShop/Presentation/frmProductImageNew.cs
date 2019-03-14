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
    public partial class frmProductImageNew : SuperShop.Presentation.Template.frmNewEdit
    {
        public frmProductImageNew()
        {
            InitializeComponent();
        }

        private void llClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.Image = null;
        }

        private void llBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg|GIF|*.gif|PNG|*.png";
            openFileDialog.ShowDialog();

            if(string.IsNullOrEmpty(openFileDialog.FileName))
                return;
            pbImage.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void frmProductImageNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            Product product = new Product();
            cmbProduct.DataSource = product.Select().Tables[0];
            cmbProduct.DisplayMember = "name";
            cmbProduct.ValueMember = "id";
            cmbProduct.SelectedValue = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue == "")
            {
                er++;
                ep.SetError(cmbProduct,"Required");
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                er++;
                ep.SetError(txtTitle,"Required");
            }
            if (pbImage.Image == null)
            {
                er++;
                ep.SetError(pbImage,"Required");
            }
            if(er>0)
                return;
            
            ProductImage productImage = new ProductImage();
            productImage.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            productImage.Title = txtTitle.Text;
            productImage.Image = FileClass.ImageToByte(pbImage.Image);

            if (productImage.Insert())
            {
                MessageBox.Show("Image Saved");
                cmbProduct.SelectedValue = -1;
                txtTitle.Text = "";
                pbImage.Image = null;
                cmbProduct.Focus();
            }
            else
            {
                MessageBox.Show(productImage.Error);
            }
        }
    }
}
