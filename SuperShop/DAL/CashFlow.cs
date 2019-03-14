using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class CashFlow:MyBase
    {
        public int Id { get; set; }
        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT * FROM vwCashFlow");
            return ExecuteDataSet(MyCommand);
        }
    }
}
