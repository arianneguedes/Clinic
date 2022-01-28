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
    class Provinces
    {
        Database database = new Database();
        public List<Province> ProvincesTable= new List<Province>();

        public void GetAll()
        {
            ProvincesTable.Clear();
            string queryString = "select * from Provinces";
            database.QueryString = queryString;
            DataTable data = database.GetAll();

            for (int row = 0; row < data.Rows.Count; row++)
            {
                int id = int.Parse(data.Rows[row]["ProvinceID"].ToString());
                String name = data.Rows[row]["Name"].ToString();
                Province fieldData = new Province();
                fieldData.ProvinceID = id;
                fieldData.Name = name;
                ProvincesTable.Add(fieldData);
            }

        }

        public Province GetOne(int id)
        {
            string queryString = "select * from Provinces where provinceID = " + id;
            database.QueryString = queryString;
            DataTable data = database.GetAll();
            int provinceId = int.Parse(data.Rows[0]["provinceID"].ToString());
            String name = data.Rows[0]["Name"].ToString();
            Province fieldData = new Province();
            fieldData.ProvinceID= id;
            fieldData.Name = name;
            return fieldData;

        }
    }
}
