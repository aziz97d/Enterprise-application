using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class StockReport:MyBase
    {
        public string BrandName { get; set; }
        public string CategoryName { get; set; }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT * FROM VWSTOCK where id>0");


            //if (!string.IsNullOrEmpty(Search))
            //{
            //    MyCommand.CommandText += " and where name like @search ";
            //    MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            //}

            //----doing proble in search query why i dont know

            if (!string.IsNullOrEmpty(BrandName))
            {
                MyCommand.CommandText += " and brand=@brand";
                MyCommand.Parameters.AddWithValue("@brand", BrandName);
            }
            if (!string.IsNullOrEmpty(CategoryName))
            {
                MyCommand.CommandText += " and category=@category";
                MyCommand.Parameters.AddWithValue("@category", CategoryName);
            }

            return ExecuteDataSet(MyCommand);
        }
    }
}
