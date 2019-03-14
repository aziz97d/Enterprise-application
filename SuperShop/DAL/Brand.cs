using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    class Brand:MyBase
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder("INSERT INTO brand (name, origin) VALUES (@name, @origin)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@origin", Origin);
            return ExecuteNQ(MyCommand);
        }
        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE brand SET name = @name, origin=@origin WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@origin", Origin);
            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM brand WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, name, origin FROM brand WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Origin = MyReader["origin"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT id, name, origin FROM brand WHERE id>0");
            if (Search != "")
            {
                MyCommand.CommandText += " AND name LIKE @name";
                MyCommand.Parameters.AddWithValue("@name", "%"+Search+"%");
            }
            
            return ExecuteDataSet(MyCommand);
        }
    }
}
