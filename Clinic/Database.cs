//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Clinic
{
    //Class that handles the connection with the database
    class Database
    {
        //Creates the connection with the database
        string dbConnectionString = ConfigurationManager.ConnectionStrings["Clinic.Properties.Settings.ClinicConnectionString"].ConnectionString;
        public string QueryString { get; set; }

        public Database()
        {

        }

        public void Execute()
        {
            //Function used to execute commands in the database

            SqlConnection myConnection = new SqlConnection(dbConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = QueryString;

            //try
            //{
                myConnection.Open();
                adapter.UpdateCommand = myConnection.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;
                adapter.UpdateCommand.ExecuteNonQuery();
                myConnection.Close();
            //}
        }

        public DataTable GetAll()
        {
            // Get information from the database based on a query
            using (SqlConnection myConnection = new SqlConnection(dbConnectionString))
            using (SqlDataAdapter DataAdapter = new SqlDataAdapter(QueryString, myConnection))
            {
                DataTable Data = new DataTable();
                myConnection.Open();
                DataAdapter.Fill(Data);
                myConnection.Close();
                Data = Data.DefaultView.ToTable();
                return Data;
            }
        }
    }
}