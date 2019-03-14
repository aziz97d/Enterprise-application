using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class Category:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public bool Insert()
        {
            if (CategoryId>0)
            {
                MyCommand =
                CommandBuilder(
                    "INSERT INTO category (name, description, categoryId) VALUES (@name, @descripiton, @categoryId)");
                MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            }
            else
            {
                MyCommand =
                CommandBuilder(
                    "INSERT INTO category (name, description) VALUES (@name, @descripiton)");
                
            }
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@descripiton", Description);
            
            return ExecuteNQ(MyCommand);
        }
        public bool Update()
        {
            MyCommand =
                CommandBuilder(
                    "UPDATE category SET name=@name, description=@description, categoryId=@categoryId WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM category WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(MyCommand);
        }
        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, name, description, categoryId FROM category WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Description = MyReader["description"].ToString();
                try
                {
                    CategoryId = Convert.ToInt32(MyReader["categoryId"].ToString());
                }
                catch{}
                
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT ct1.id, ct1.name, ct1.description, ct2.name as category, ct2.id as categoryId FROM category as ct1 LEFT JOIN category as ct2 on ct1.categoryId=ct2.id");
            if (!string.IsNullOrEmpty(Name))
            {
                MyCommand.CommandText += " AND ct1.name LIKE @name";
                MyCommand.Parameters.AddWithValue("@name", "%"+Search+"%");
            }
            if (CategoryId > 0)
            {
                MyCommand.CommandText += " AND ct2.id=@categoryId";
                MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            }
            return ExecuteDataSet(MyCommand);
        }
    }
}
