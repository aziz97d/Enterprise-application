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
    class Country:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        

        public bool SaveCountry()
        {
            MyCommand = CommandBuilder("INSERT INTO Country (name) VALUES (@name)");
            MyCommand.Parameters.AddWithValue("@name", Name);

            return ExecuteNQ(MyCommand);
            
        }

        public bool Update()
        {
            MyCommand = CommandBuilder("UPDATE Country SET name=@name WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);

            return ExecuteNQ(MyCommand);
        }

        public bool Delete(string ids="")
        {
            if (ids == "")
            {
                MyCommand = CommandBuilder("DELETE FROM Country WHERE id=@id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                MyCommand = CommandBuilder("DELETE FROM Country WHERE id in (" + ids + ")");
            }
            

            return ExecuteNQ(MyCommand);
        }
        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, name FROM Country WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                return true;
            }

            return false;
        }

        public DataSet GetCountry()
        {
            MyCommand = CommandBuilder("SELECT id, name FROM Country");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " WHERE name LIKE @search";
                MyCommand.Parameters.AddWithValue("@search","%"+Search+"%");
            }

            return ExecuteDataSet(MyCommand);
        }
    }
}
