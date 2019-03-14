using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class SaleDetails:MyBase
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public double Qunatity { get; set; }
        public double Rate { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder("INSERT INTO saleDetails (saleId, productId, qty, rate, vat, discount ) VALUES (@saleId, @productId, @qty, @rate, @vat, @discount)");
            MyCommand.Parameters.AddWithValue("@saleId", SaleId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@qty", Qunatity);
            MyCommand.Parameters.AddWithValue("@rate", Rate);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);
            return ExecuteNQ(MyCommand);
        }
        ///Here's a problem in query
        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE saleDetails SET saleId=@saleId, productId = @productId, qty=@qty, rate=@rate, vat=@vat, discount=@discount WHERE saleId=@saleID AND productId=productId");
            MyCommand.Parameters.AddWithValue("@saleId", SaleId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@qty", Qunatity);
            MyCommand.Parameters.AddWithValue("@rate", Rate);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);
            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM saleDetails WHERE saleId=@saleId AND productId=@productId");
            MyCommand.Parameters.AddWithValue("@saleId", SaleId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            return ExecuteNQ(MyCommand);
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT saleId,productId,qty,rate FROM saleDetails");
            return ExecuteDataSet(MyCommand);
        }
    }
}
