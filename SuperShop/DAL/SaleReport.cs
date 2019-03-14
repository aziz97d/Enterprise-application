using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class SaleReport:MyBase
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT * FROM VWSALE where id>0");

            if (IsDateSearch)
            {
                MyCommand.CommandText += " and datetime between @date1 and @date2";
                MyCommand.Parameters.AddWithValue("@date1", DateFrom);
                MyCommand.Parameters.AddWithValue("@date2", DateTo);
            }
            if (EmployeeId > 0)
            {
                MyCommand.CommandText += " and employeeId=@employeeId";
                MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            }
            if (CustomerId > 0)
            {
                MyCommand.CommandText += " and customerLedgerId=@customerLedgerId";
                MyCommand.Parameters.AddWithValue("@customerLedgerId", CustomerId);
            }
            if (ProductId > 0)
            {
                MyCommand.CommandText += " and productId=@productId";
                MyCommand.Parameters.AddWithValue("@productId", ProductId);
            }

            return ExecuteDataSet(MyCommand);
        }
        
    }
}
