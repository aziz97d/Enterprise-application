using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class Transaction:MyBase
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public DateTime DateTime { get; set; }
        public int LedgerId { get; set; }
        public int EmployeeId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Remarks { get; set; }


        public bool Insert()
        {
            MyCommand =
                CommandBuilder(
                    @"INSERT INTO [transaction] (number, reference, [dateTime], ledgerId, employeeId, debit, credit, remarks) 
                    VALUES (@number, @reference, @dateTime, @ledgerId, @employeeId, @debit, @credit, @remarks)");
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@reference", Reference);
            MyCommand.Parameters.AddWithValue("@dateTime", DateTime);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@debit", Debit);
            MyCommand.Parameters.AddWithValue("@credit", Credit);
            MyCommand.Parameters.AddWithValue("@remarks", Remarks);

            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand =
                CommandBuilder(
                    @"UPDATE transaction SET number=@number, reference=@reference, dateTime=@dateTime, ledgerId=@ledgerId, employeeId=@employeeId,
                    debit=@debit, credit=@credit, remarks=@remarks WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@reference", Reference);
            MyCommand.Parameters.AddWithValue("@dateTime", DateTime);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@debit", Debit);
            MyCommand.Parameters.AddWithValue("@credit", Credit);
            MyCommand.Parameters.AddWithValue("@remarks", Remarks);


            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder(@"DELETE FROM transaction WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }

        public DataSet Select()
        {
            MyCommand =
                CommandBuilder(
                    "SELECT id, number, reference, dateTime, ledgerId, employeeId, debit, credit, remarks FROM [transaction]");
            return ExecuteDataSet(MyCommand);
        }
    }
}
