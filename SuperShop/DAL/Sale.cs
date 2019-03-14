using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class Sale:MyBase
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerLedgerId { get; set; }
        public int EmployeeId { get; set; }
        public double Total { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }


        public bool Insert()
        {
            MyCommand =
                CommandBuilder(
                    @"INSERT INTO sale (number, dateTime, customerLedgerId, employeeId, total, vat, discount) 
                    VALUES(@number, @dateTime, @customerLedgerId, @employeeId, @total, @vat, @discount) select @@identity");
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@dateTime", DateTime);
            MyCommand.Parameters.AddWithValue("@customerLedgerId", CustomerLedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@total", Total);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);

            return ExecuteScaler(MyCommand);
        }

        public bool Update()
        {
            MyCommand =
                CommandBuilder(
                    @"UPDATE sale SET number=@number, dateTime=@dateTime, customerLadgerId=@customerLadgerId, employeeId=@employeeId, total=@total,
                    vat=@vat, discount=@discount, cityId=@cityId, createDate=@createDate, image=@image, type=@type WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@dateTime", DateTime);
            MyCommand.Parameters.AddWithValue("@customerLadgerId", CustomerLedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@total", Total);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);

            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder(@"DELETE FROM Sale WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT id, number, dateTime, customerLadgerId, employeeId, total, vat, discount FROM Sale");
            return ExecuteDataSet(MyCommand);
        }
    }
}
