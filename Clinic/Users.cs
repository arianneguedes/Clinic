//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
namespace Clinic
{
    class Users
    {
        Database database = new Database();
        
        public List<User> UserTable = new List<User>();

        public void Add(User user)
        {
            string sql = "insert into Users (UserName, Password, AccessLevel) values ('" + user.Username + "', '" + user.Password + "', " + user.AccessLevel +" )";
            database.QueryString = sql;
            database.Execute();
        }
        public void Remove(User user)
        {
            string sql = "delete Users where userid = " + user.UserId;
            database.QueryString = sql;
            database.Execute();
        }
        public void Update(User user)
        {

            string sql = "update users set username = '" + user.Username + "', password = '" + user.Username + "' where userid = " + user.UserId;
            database.QueryString = sql;
            database.Execute();

        }

        public void GetAll()
        {
            UserTable.Clear();
            string queryString = "select * from Users";
            database.QueryString = queryString;
            DataTable data = database.GetAll();

            for (int row = 0; row < data.Rows.Count; row++)
            {
                int id = int.Parse(data.Rows[row]["Userid"].ToString());
                String username = data.Rows[row]["UserName"].ToString();
                String password = data.Rows[row]["Password"].ToString();
                int accesslevel = int.Parse(data.Rows[row]["AccessLevel"].ToString());
                User fieldData = new User();
                fieldData.UserId = id;
                fieldData.Username = username;
                fieldData.Password = password;
                fieldData.AccessLevel = accesslevel;
                UserTable.Add(fieldData);
            }

        }

        public User GetOne(string _username)
        {

            string queryString = "select * from Users where UserName = '" + _username +"'";
            database.QueryString = queryString;
            DataTable data = database.GetAll();
            if(data.Rows.Count == 0)
            {
                MessageBox.Show("Username is incorrect", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = int.Parse(data.Rows[0]["Userid"].ToString());
                String username = data.Rows[0]["UserName"].ToString();
                String password = data.Rows[0]["Password"].ToString();
                int accesslevel = int.Parse(data.Rows[0]["AccessLevel"].ToString());
                User fieldData = new User();
                fieldData.UserId = id;
                fieldData.Username = username;
                fieldData.Password = password;
                fieldData.AccessLevel = accesslevel;

                return fieldData;
            }

            return null;
        }

    }
}
