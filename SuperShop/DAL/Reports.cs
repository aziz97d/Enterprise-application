using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class Reports:MyBase
    {
        
        public DataSet CashFlow()
        {
            MyCommand = CommandBuilder("SELECT * FROM vwCashFlow");
            return ExecuteDataSet(MyCommand);
        }


        public DataSet GetSaleDetails(int p=0)
        {
            MyCommand = CommandBuilder("SELECT * FROM vwSaleVoucher");
            if (p > 0)
            {
                MyCommand.CommandText += " where id = @id";
                MyCommand.Parameters.AddWithValue("@id", p);
            }
            return ExecuteDataSet(MyCommand);
        }

        
    }
}
