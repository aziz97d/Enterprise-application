using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class ProductPrice:MyBase
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder("INSERT INTO productPrice (productId, unitId, price) VALUES (@productId, @unitId, @price)");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            MyCommand.Parameters.AddWithValue("@price", Price);
            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE productPrice SET price=@price WHERE productId=@productId and unitId=@unitId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            MyCommand.Parameters.AddWithValue("@price", Price);
            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM productPrice WHERE productId=@productId AND unitId=@unitId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            return ExecuteNQ(MyCommand);
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"SELECT product.id as productId, product.name as product, unit.id as unitId, unit.name as unit, productPrice.price FROM productPrice
                                        LEFT JOIN product on productPrice.productId=product.id
                                        LEFT JOIN unit on productPrice.unitId=unit.id
                                        where product.id>0");
            if (ProductId > 0)
            {
                MyCommand.CommandText += " and product.id=@productId";
                MyCommand.Parameters.AddWithValue("@productId", ProductId);
            }
            if (UnitId > 0)
            {
                MyCommand.CommandText += " and unit.id=@unitId";
                MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and product.name like @name";
                MyCommand.Parameters.AddWithValue("@name", "%"+Search+"%");
            }
            return ExecuteDataSet(MyCommand);
        }

        //public bool SelectById()
        //{
        //    MyCommand = CommandBuilder(@"SELECT productId, unitId, price from ProductPrice where productId=@productId and unitId=@unitId");
        //    MyCommand.Parameters.AddWithValue("@productId", ProductId);
        //    MyCommand.Parameters.AddWithValue("@unitId", UnitId);

        //    MyReader = ExecuteReader(MyCommand);
        //    while (MyReader.Read())
        //    {
        //        ProductId = Convert.ToInt32(MyReader["productId"]);
        //        Price = Convert.ToDouble(MyReader["price"]);
        //        UnitId = Convert.ToInt32(MyReader["unitId"]);
        //        return true;
        //    }
        //    return false;
            
        //}
        public bool SelectById()
        {
            MyCommand = CommandBuilder(@"SELECT productId, unitId, price from ProductPrice where productId=@productId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);


            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                ProductId = Convert.ToInt32(MyReader["productId"]);
                Price = Convert.ToDouble(MyReader["price"]);
                UnitId = Convert.ToInt32(MyReader["unitId"]);
                return true;
            }
            return false;

        }

    }
}
