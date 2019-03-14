using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class ProductImage:MyBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder("INSERT INTO productImage (productId, image, title) VALUES (@productId, @image, @title)");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@image", Image);
            MyCommand.Parameters.AddWithValue("@title", Title);
            return ExecuteNQ(MyCommand);
        }
        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE productImage SET productId = @productId, image=@image, title=@title WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@image", Image);
            MyCommand.Parameters.AddWithValue("@title", Title);
            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM productImage WHERE productId=@productId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            return ExecuteNQ(MyCommand);
        }
        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, productId, image, title from productImage WHERE productId=@productId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);

            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                ProductId = Convert.ToInt32(MyReader["productId"].ToString());
                Image =(byte[]) MyReader["image"];
                Title = MyReader["title"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"SELECT pi.id, pi.productId, pi.image, pi.title, pdt.name as product FROM productImage as pi
                                            LEFT JOIN product as pdt on pi.productId=pdt.id WHERE pi.id>0");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " AND pi.title LIKE @title";
                MyCommand.Parameters.AddWithValue("@title", "%" + Search + "%");
            }
            if (ProductId>0)
            {
                MyCommand.CommandText += " AND pdt.id = @productId";
                MyCommand.Parameters.AddWithValue("@productId", ProductId);
            }
            
            return ExecuteDataSet(MyCommand);
        }
    }
    
}
