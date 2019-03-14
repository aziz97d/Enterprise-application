using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class MyBase
    {
        protected SqlCommand MyCommand { get; set; }
        protected SqlDataReader MyReader { get; set; }
        private string _error;
        public string Error
        {
            get { return _error; }
        }
        //String for search
        public string Search { get; set; }
        public bool IsDateSearch { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double AmountFrom { get; set; }
        public double AmountTo { get; set; }
        public int LastId { get; set; }

        private SqlConnection CN = new SqlConnection("Data Source=DESKTOP-002O19U;Initial Catalog=dbSuperShop;Integrated Security=True");

        private bool Connection()
        {
            if (MyReader !=null && !MyReader.IsClosed)
                MyReader.Close();
            
            if (CN.State==ConnectionState.Open)
                return true;
            
            try
            {
                CN.Open();
                return true;
            }
            catch (Exception exception)
            {
                _error = exception.Message;
                return false;
            }

        }

        protected bool ExecuteNQ(SqlCommand cmd)
        {
            if (!Connection())
                return false;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                _error = exception.Message;
            }
            return false;
        }

        protected bool ExecuteScaler(SqlCommand cmd)
        {
            if (!Connection())
                return false;

            try
            {
                LastId = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
            }
            catch (Exception exception)
            {
                _error = exception.Message;
            }
            return false;
        }

        protected SqlCommand CommandBuilder(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CN;
            cmd.CommandText = sql;
            return cmd;
        }

        protected SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            if (!Connection())
                return null;
            return cmd.ExecuteReader();
        }


        protected DataSet ExecuteDataSet(string sql)
        {
            if (!Connection())
                return null;

            SqlCommand cmd = CommandBuilder(sql);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }
        protected DataSet ExecuteDataSet(SqlCommand cmd)
        {
            if (!Connection())
                return null;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }
    }
}
