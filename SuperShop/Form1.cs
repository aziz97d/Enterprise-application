using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperShop.Common;
using SuperShop.Presentation;

namespace SuperShop
{
    public partial class Form1 : Form
    {
        frmProductImage productImage = new frmProductImage();
        frmBrand brand = new frmBrand();
        frmCategory category = new frmCategory();
        frmCity city = new frmCity();
        frmLedger ledger = new frmLedger();
        frmProduct product = new frmProduct();
        frmProductPrice productPrice = new frmProductPrice();
        frmUnit unit = new frmUnit();
        frmSale sale = new frmSale();
        frmSetting setting = new frmSetting();
        frmTransactionNew transaction = new frmTransactionNew();
        frmCashFlow cashFlow = new frmCashFlow();
        frmDBSetting dbSetting = new frmDBSetting();
        frmBackup backup = new frmBackup();
        frmSaleReport saleReport = new frmSaleReport();
        frmStock stock = new frmStock();
        frmEmployee employee = new frmEmployee();
        public Form1()
        {
            InitializeComponent();
        }

        private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productImage.IsDisposed)
                productImage = new frmProductImage();
            productImage.MdiParent = this;
            productImage.Show();
            productImage.BringToFront();
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(city.IsDisposed)
                city = new frmCity();
            city.MdiParent = this;
            city.Show();
            city.BringToFront();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brand.IsDisposed)
                brand = new frmBrand();
            brand.MdiParent = this;
            brand.Show();
            brand.BringToFront();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (category.IsDisposed)
                category = new frmCategory();
            category.MdiParent = this;
            category.Show();
            category.BringToFront();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unit.IsDisposed)
                unit = new frmUnit();
            unit.MdiParent = this;
            unit.Show();
            unit.BringToFront();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (product.IsDisposed)
                product = new frmProduct();
            product.MdiParent = this;
            product.Show();
            product.BringToFront();
        }

        private void productPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productPrice.IsDisposed)
                productPrice = new frmProductPrice();
            productPrice.MdiParent = this;
            productPrice.Show();
            productPrice.BringToFront();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ledger.IsDisposed)
                ledger = new frmLedger();
            ledger.MdiParent = this;
            ledger.Show();
            ledger.BringToFront();
        }


        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sale.IsDisposed)
                sale = new frmSale();
            sale.MdiParent = this;
            sale.Show();
            sale.BringToFront();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(employee.IsDisposed)
                employee = new frmEmployee();
            employee.MdiParent = this;
            employee.Show();
            employee.BringToFront();
        }

        private void vatDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(setting.IsDisposed)
                setting = new frmSetting();
            setting.Show();
            setting.BringToFront();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(transaction.IsDisposed)
                transaction = new frmTransactionNew();
            transaction.MdiParent = this;
            transaction.Show();
            transaction.BringToFront();
        }

        private void receiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transaction.IsDisposed)
                transaction = new frmTransactionNew("Credit");
            transaction.MdiParent = this;
            transaction.Show();
            transaction.BringToFront();
        }

        private void contraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transaction.IsDisposed)
                transaction = new frmTransactionNew("Contra");
            transaction.MdiParent = this;
            transaction.Show();
            transaction.BringToFront();
        }

        private void cashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cashFlow.IsDisposed)
                cashFlow = new frmCashFlow();
            cashFlow.MdiParent = this;
            cashFlow.Show();
            cashFlow.BringToFront();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dbSetting.IsDisposed)
                dbSetting = new frmDBSetting();
            
            dbSetting.ShowDialog();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(backup.IsDisposed)
                backup = new frmBackup();
            backup.MdiParent = this;
            backup.Show();
            backup.BringToFront();
        }

        private void salesRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saleReport.IsDisposed)
                saleReport = new frmSaleReport();
            saleReport.MdiParent = this;
            saleReport.Show();
            saleReport.BringToFront();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(stock.IsDisposed)
                stock = new frmStock();
            stock.MdiParent = this;
            stock.Show();
            stock.BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
