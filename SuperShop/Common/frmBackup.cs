using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShop.Common
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            txtBackupPath.Text = fbd.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String sql =
               String.Format("BACKUP DATABASE [{0}] TO  DISK = N'{1}{2}.bak' WITH NOFORMAT, NOINIT,  NAME = N'{3}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", Properties.Settings.Default.DatabaseName, txtBackupPath.Text, txtFileName.Text, Properties.Settings.Default.DatabaseName);

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.MyCon);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            connection.Open();
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            Close();
            MessageBox.Show("Database Backup Successful");
        }
    }
}
