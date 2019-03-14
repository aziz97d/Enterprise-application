using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class Unit:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PrimaryQuantity { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder("INSERT INTO unit (name, description, primaryQty) VALUES (@name, @description, @primaryQty)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@primaryQty", PrimaryQuantity);
            return ExecuteNQ(MyCommand);
        }
        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE brand SET name = @name, description=@description, primaryQty=@primaryQty WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@primaryQty", PrimaryQuantity);
            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM unit WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, name, description, primaryQty FROM unit where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Description = MyReader["description"].ToString();
                PrimaryQuantity = MyReader["primaryQty"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT id, name, description, primaryQty FROM unit");
            return ExecuteDataSet(MyCommand);
        }
    }
}
