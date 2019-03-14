using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    internal class Product : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        //public DateTime CreateDate { get; set; }


        public bool Insert()
        {
            MyCommand = CommandBuilder(@"INSERT INTO product (name, code, description, brandId, categoryId)
                                        VALUES  (@name,@code,@description,@brandId,@categoryId)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@code", Code);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@brandId", BrandId);
            MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            //MyCommand.Parameters.AddWithValue("@createDate", CreateDate);

            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand =
                CommandBuilder(
                    @"UPDATE product SET name=@name, code=@code, description=@description, brandId=@brandId, categoryId=@categoryId, createDate=@createDate, WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@code", Code);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@brandId", BrandId);
            MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
           // MyCommand.Parameters.AddWithValue("@createDate", CreateDate);

            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder(@"DELETE product WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"SELECT product.id, product.name, product.code, product.description, 
                                        brand.name as brand, category.name as category, product.createDate FROM product
                                        LEFT JOIN brand on product.brandId=brand.id
                                        LEFT JOIN category on product.categoryId=category.id where product.id>0");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and (product.name like @search or product.code like @search)";
                MyCommand.Parameters.AddWithValue("@search", "%"+Search+"%");
            }
            if (BrandId > 0)
            {
                MyCommand.CommandText += " and (brand.id = @brandId)";
                MyCommand.Parameters.AddWithValue("@brandId", BrandId);
            }
            if (CategoryId > 0)
            {
                MyCommand.CommandText += " and (category.id = @categoryId)";
                MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            }
            if (IsDateSearch)
            {
                MyCommand.CommandText += " and product.createDate between @date1 and @date2";
                MyCommand.Parameters.AddWithValue("@date1", DateFrom);
                MyCommand.Parameters.AddWithValue("@date2", DateTo);
            }

            return ExecuteDataSet(MyCommand);
        }

        public bool SelectById()
        {
            MyCommand = CommandBuilder(@"SELECT product.id, product.name, product.code, product.description, 
                                        brand.name as brand, product.brandId, product.categoryId, category.name as category, product.createDate FROM product
                                        LEFT JOIN brand on product.brandId=brand.id
                                        LEFT JOIN category on product.categoryId=category.id where product.id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Code = MyReader["code"].ToString();
                Description = MyReader["description"].ToString();
                BrandId = Convert.ToInt32(MyReader["brandId"]);
                CategoryId = Convert.ToInt32(MyReader["categoryId"]);
                return true;
            }
            return false;
        }
    }
}
