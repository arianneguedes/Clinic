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
    class Patients
    {
        Database database = new Database();
        public List<Patient> PatientsTable = new List<Patient>();
        public PatientSearch Search = new PatientSearch();

        public void Add(Patient patient)
        {
            string sql = "insert into patients (firstname, lastname, address, address2, city, healthcard, postalcode, provinceid, phone, email, dob) values ('" + patient.FirstName + "', '" + patient.LastName + "', '" + patient.Address + "', '" + patient.Address2 + "', '" + patient.City + "', '" + patient.HealthCardNumber + "', '" + patient.PostalCode + "', '" + patient.ProvinceID + "', '" + patient.Phone + "', '" + patient.Email + "', '" + patient.DoB + "')";
            database.QueryString = sql;
            database.Execute();
        }

        public void Remove(Patient patient)
        {
            string sql = "delete patients where patientid = " + patient.ID;
            database.QueryString = sql;
            database.Execute();
        }

        public void Update(Patient patient)
        {
            string sql = "update patients set firstname = '" + patient.FirstName + "', lastname = '" + patient.LastName + "', address = '" + patient.Address + "', address2 = '" + patient.Address2 + "', city = '" + patient.City + "', healthcard = '" + patient.HealthCardNumber + "', postalcode = '" + patient.PostalCode + "', provinceid = " + patient.ProvinceID + ", phone = '" + patient.Phone + "', email = '" + patient.Email + "', dob = '" + patient.DoB + "' where patientid = " + patient.ID;
            database.QueryString = sql;
            database.Execute();
        }

        public void GetAll()
        {
            PatientsTable.Clear();
            string queryString = searchSQL();
            database.QueryString = queryString;
            DataTable data = database.GetAll();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                int id = int.Parse(data.Rows[i]["PatientID"].ToString());
                string firstName = data.Rows[i]["FirstName"].ToString();
                string lastName = data.Rows[i]["LastName"].ToString();
                string address = data.Rows[i]["Address"].ToString();
                string address2 = data.Rows[i]["Address2"].ToString();
                string city = data.Rows[i]["City"].ToString();
                string healthCardNumber = data.Rows[i]["HealthCard"].ToString();
                string postalCode = data.Rows[i]["PostalCode"].ToString();
                int provindeId = int.Parse(data.Rows[i]["ProvinceID"].ToString());
                string phone = data.Rows[i]["Phone"].ToString();
                string email = data.Rows[i]["Email"].ToString();
                string dob = data.Rows[i]["DOB"].ToString();

                Patient fieldData = new Patient();
                fieldData.ID = id;
                fieldData.FirstName = firstName;
                fieldData.LastName = lastName;
                fieldData.Address = address;
                fieldData.Address2 = address2;
                fieldData.City = city;
                fieldData.HealthCardNumber = healthCardNumber;
                fieldData.PostalCode = postalCode;
                fieldData.ProvinceID = provindeId;
                fieldData.Phone = phone;
                fieldData.Email = email;
                fieldData.DoB = dob;
                PatientsTable.Add(fieldData);
            }
        }

        public Patient GetOne(int id)
        {
            string queryString = "select * from Patients where PatientID = " + id;
            database.QueryString = queryString;
            DataTable data = database.GetAll();
            int patientId = int.Parse(data.Rows[0]["PatientID"].ToString());
            string firstName = data.Rows[0]["FirstName"].ToString();
            string lastName = data.Rows[0]["LastName"].ToString();
            string address = data.Rows[0]["Address"].ToString();
            string address2 = data.Rows[0]["Address2"].ToString();
            string city = data.Rows[0]["City"].ToString();
            string healthCardNumber = data.Rows[0]["HealthCard"].ToString();
            string postalCode = data.Rows[0]["PostalCode"].ToString();
            int provinceId = int.Parse(data.Rows[0]["ProvinceID"].ToString());
            string phone = data.Rows[0]["Phone"].ToString();
            string email = data.Rows[0]["Email"].ToString();
            string dob = data.Rows[0]["DOB"].ToString();

            Patient fieldData = new Patient();
            fieldData.ID = patientId;
            fieldData.FirstName = firstName;
            fieldData.LastName = lastName;
            fieldData.Address = address;
            fieldData.Address2 = address2;
            fieldData.City = city;
            fieldData.HealthCardNumber = healthCardNumber;
            fieldData.PostalCode = postalCode;
            fieldData.ProvinceID = provinceId;
            fieldData.Phone = phone;
            fieldData.Email = email;
            fieldData.DoB = dob;

            return fieldData;
        }

        private string searchSQL()
        {
            string sql = "select * from Patients ";
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

            if (Search.HealthID != "" && Search.HealthID != null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";
                sql += " (HealthCard like '%" + Search.HealthID + "%')";
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

    public class PatientSearch
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string HealthID { get; set; }
    }
}