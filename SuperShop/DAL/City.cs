using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShop.DAL
{
    class City:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool Insert()
        {
            MyCommand = CommandBuilder("INSERT INTO City (name) VALUES (@name)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            
            return ExecuteNQ(MyCommand);
            
        }

        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE City SET name=@name WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
           
            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {
            MyCommand = CommandBuilder("DELETE FROM City WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }
        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, name FROM city WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("SELECT id, name FROM city");

            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " where name LIKE @search";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExecuteDataSet(MyCommand);

        }
    }
}
