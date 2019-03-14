using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DAL
{
    internal class Ledger : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }


        public bool Insert()
        {
            MyCommand =
                CommandBuilder(
                    @"INSERT INTO ledger (name, contact, email, password, gender, dateOfBirth, address, cityId, createDate, image, type) 
                    VALUES (@name,@contact,@email,@password,@gender,@dateOfBirth,@address,@cityId,@createDate,@image,@type)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@gender", Gender);
            MyCommand.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            MyCommand.Parameters.AddWithValue("@address", Address);
            MyCommand.Parameters.AddWithValue("@cityId", CityId);
            MyCommand.Parameters.AddWithValue("@createDate", CreateDate);
            MyCommand.Parameters.AddWithValue("@image", Image);
            MyCommand.Parameters.AddWithValue("@type", Type);

            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand =
                CommandBuilder(
                    @"UPDATE ledger SET name=@name, contact=@contact, email=@email, password=@password, gender=@gender,
                    address=@address, cityId=@cityId, type=@type WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@gender", Gender);
            //MyCommand.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            MyCommand.Parameters.AddWithValue("@address", Address);
            MyCommand.Parameters.AddWithValue("@cityId", CityId);           
            //MyCommand.Parameters.AddWithValue("@image", Image);
            MyCommand.Parameters.AddWithValue("@type", Type);

            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder(@"DELETE FROM ledger WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
         
            return ExecuteNQ(MyCommand);
        }
        public bool SelectById()
        {
            MyCommand = CommandBuilder("SELECT id, name, contact, email, password, gender, dateOfBirth,address," +
                                       "cityId, createDate, image, type  FROM ledger WHERE id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Contact = MyReader["contact"].ToString();
                Email = MyReader["email"].ToString();
                Password = MyReader["password"].ToString();
                Gender = Convert.ToInt32(MyReader["gender"].ToString());
                DateOfBirth = Convert.ToDateTime(MyReader["dateOfBirth"].ToString());
                Address = MyReader["address"].ToString();
                CityId = Convert.ToInt32(MyReader["cityId"].ToString());
                //Image = new[] {Convert.ToByte(MyReader["image"])};
                Type = MyReader["type"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand =
                CommandBuilder(
                    @"SELECT ledger.id, ledger.name, ledger.contact, ledger.email, ledger.password,
                    case ledger.gender
                    when 0 then 'Male'
                    when 1 then 'Female'
                    end
                    as gender,
                    ledger.dateOfBirth, ledger.address, ledger.cityId, ledger.createDate, ledger.image, case ledger.type 
                    when 'c' then 'Customer'
                    when 'e' then 'Employee'
                    when 's' then 'Supplier'
                    end
                    as type,
                    city.name as cityName FROM ledger
                    LEFT JOIN City on ledger.cityId=city.id where ledger.id>0
                    ");
            if (Type != null && Type != "")
            {
                MyCommand.CommandText += " and type=@type";
                MyCommand.Parameters.AddWithValue("@type", Type);
            }
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and ledger.name like @name";
                MyCommand.Parameters.AddWithValue("@name", Search);
            }
            return ExecuteDataSet(MyCommand);
        }
    }
}

