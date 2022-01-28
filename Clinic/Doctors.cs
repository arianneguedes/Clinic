//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Clinic
{
    class Doctors
    {
        Database database = new Database();
        public List<Doctor> DoctorsTable = new List<Doctor>();
        public DoctorSearch Search = new DoctorSearch();

        public void Add(Doctor doctor)
        {
            string sql = "insert into doctors (firstname, lastname, address, address2, city, licencenumber, postalcode, provinceid, phone, email, dob) values ('" + doctor.FirstName + "', '" + doctor.LastName + "', '" + doctor.Address + "', '" + doctor.Address2 + "', '" + doctor.City + "', '" + doctor.LicenceNumber + "', '" + doctor.PostalCode + "', '" + doctor.ProvinceID + "', '" + doctor.Phone + "', '" + doctor.Email + "', '" + doctor.DoB + "')";
            database.QueryString = sql;
            database.Execute();
        }

        public void Remove(Doctor doctor)
        {
            string sql = "delete doctors where doctorid = " + doctor.ID;
            database.QueryString = sql;
            database.Execute();
        }

        public void Update(Doctor doctor)
        {
            string sql = "update doctors set firstname = '" + doctor.FirstName + "', lastname = '" + doctor.LastName + "', address = '" + doctor.Address + "', address2 = '" + doctor.Address2 + "', city = '" + doctor.City + "', licencenumber = '" + doctor.LicenceNumber + "', postalcode = '" + doctor.PostalCode + "', provinceid = " + doctor.ProvinceID + ", phone = '" + doctor.Phone + "', email = '" + doctor.Email + "', dob = '" + doctor.DoB + "' where doctorid = " + doctor.ID;
            database.QueryString = sql;
            database.Execute();
        }

        public void GetAll()
        {
            DoctorsTable.Clear();
            string queryString = searchSQL();
            database.QueryString = queryString;
            DataTable data = database.GetAll();

            for (int row = 0; row < data.Rows.Count; row++)
            {
                int id = int.Parse(data.Rows[row]["DoctorID"].ToString());
                string firstName = data.Rows[row]["FirstName"].ToString();
                string lastName = data.Rows[row]["LastName"].ToString();
                string address = data.Rows[row]["Address"].ToString();
                string address2 = data.Rows[row]["Address2"].ToString();
                string city = data.Rows[row]["City"].ToString();
                string licenceNumber = data.Rows[row]["LicenceNumber"].ToString();
                string postalCode = data.Rows[row]["PostalCode"].ToString();
                int provindeId = int.Parse(data.Rows[row]["ProvinceID"].ToString()); //Smallint
                string phone = data.Rows[row]["Phone"].ToString();
                string email = data.Rows[row]["Email"].ToString();
                string dob = data.Rows[row]["DOB"].ToString(); //Date

                Doctor fieldData = new Doctor();
                fieldData.ID = id;
                fieldData.FirstName = firstName;
                fieldData.LastName = lastName;
                fieldData.Address = address;
                fieldData.Address2 = address2;
                fieldData.City = city;
                fieldData.LicenceNumber = licenceNumber;
                fieldData.PostalCode = postalCode;
                fieldData.ProvinceID = provindeId;
                fieldData.Phone = phone;
                fieldData.Email = email;
                fieldData.DoB = dob;
                DoctorsTable.Add(fieldData);
            }
        }

        public Doctor GetOne(int id)
        {
            string queryString = "select * from Doctors where DoctorID = " + id;
            database.QueryString = queryString;
            DataTable data = database.GetAll();
            int doctorId = int.Parse(data.Rows[0]["DoctorID"].ToString());
            string firstName = data.Rows[0]["FirstName"].ToString();
            string lastName = data.Rows[0]["LastName"].ToString();
            string address = data.Rows[0]["Address"].ToString();
            string address2 = data.Rows[0]["Address2"].ToString();
            string city = data.Rows[0]["City"].ToString();
            string licenceNumber = data.Rows[0]["LicenceNumber"].ToString();
            string postalCode = data.Rows[0]["PostalCode"].ToString();
            int provinceId = int.Parse(data.Rows[0]["ProvinceID"].ToString());
            string phone = data.Rows[0]["Phone"].ToString();
            string email = data.Rows[0]["Email"].ToString();
            string dob = data.Rows[0]["DOB"].ToString();

            Doctor fieldData = new Doctor();
            fieldData.ID = doctorId;
            fieldData.FirstName = firstName;
            fieldData.LastName = lastName;
            fieldData.Address = address;
            fieldData.Address2 = address2;
            fieldData.City = city;
            fieldData.LicenceNumber = licenceNumber;
            fieldData.PostalCode = postalCode;
            fieldData.ProvinceID = provinceId;
            fieldData.Phone = phone;
            fieldData.Email = email;
            fieldData.DoB = dob;

            return fieldData;
        }

        private string searchSQL()
        {
            string sql = "select * from Doctors ";
            bool bCriteria = false;

            if (Search.Name != "" && Search.Name != null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";

                sql += " (lastname like '%" + Search.Name + "%' or firstname like '%" + Search.Name + "%')";
                bCriteria = true;
            }

            if (Search.LicenceID != "" && Search.LicenceID != null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";
                sql += " (LicenceNumber like '%" + Search.LicenceID + "%')";
                bCriteria = true;
            }

            if (Search.Phone != "" && Search.Phone != null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";

                sql += " (phone like '%" + Search.Phone + "%')";
            }

            sql += " order by lastname ";
            return sql;
        }
    }

    public class DoctorSearch
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string LicenceID { get; set; }
    }
}