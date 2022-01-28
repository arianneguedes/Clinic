//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
//comment
namespace Clinic
{
    class Rooms
    {
        Database database = new Database();
        public List<Room> RoomsTable = new List<Room>();

        public void Add(Room room)
        {
            string sql = "insert into rooms (name, notes) values ('" + room.Name + "', '" + room.Notes + "')";
            database.QueryString = sql;
            database.Execute();
        }
        public void Remove(Room room)
        {
            string sql = "delete rooms where roomid = " + room.RoomId;
            database.QueryString = sql;
            database.Execute();
        }
        public void Update(Room room)
        {
            
            string sql = "update rooms set name = '" + room.Name + "', notes = '" + room.Notes + "' where roomid = " + room.RoomId;
            database.QueryString = sql;
            database.Execute();

        }

        public void GetAll()
        {
            RoomsTable.Clear();
            string queryString = "select * from Rooms";
            database.QueryString = queryString;
            DataTable data = database.GetAll();

            for (int row = 0; row < data.Rows.Count; row++)
            {
                int id = int.Parse(data.Rows[row]["Roomid"].ToString());
                String name = data.Rows[row]["Name"].ToString();
                String notes = data.Rows[row]["Notes"].ToString();
                Room fieldData = new Room();
                fieldData.RoomId = id;
                fieldData.Name = name;
                fieldData.Notes = notes;
                RoomsTable.Add(fieldData);
            }

        }
    }
}
