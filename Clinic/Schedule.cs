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

namespace Clinic
{
    class Schedule
    {
        Database database = new Database();
        public List<Appointment> ScheduleTable { get; set; }

        public ScheduleSearch Search;
        public Schedule()
        {
            ScheduleTable = new List<Appointment>();
            Search = new ScheduleSearch();
        }

        public void Add(Appointment Appointment)
        {
            string sql = "insert into Appointments (doctorid, patientid, roomid, date, scheduleid, observation) values (" + Appointment.DoctorID + ", " + Appointment.PatientID + "," + Appointment.RoomID + ",'" + Appointment.Date.Year + "/" + Appointment.Date.Month + "/" + Appointment.Date.Day + "'," + Appointment.ScheduleID + ", '" + Appointment.Observation + "')";
            database.QueryString = sql;
            database.Execute();
        }
        public void Remove(Appointment Appointment)
        {
            string sql = "delete Appointments where Appointmentid = " + Appointment.AppointmentID;
            database.QueryString = sql;
            database.Execute();
        }
        public void Update(Appointment Appointment)
        {

            string sql = "update Appointments set doctorID = " + Appointment.DoctorID + ", patientid = " + Appointment.PatientID +  ", roomid = " + Appointment.RoomID + ", date = '" + Appointment.Date.Year + "/" + Appointment.Date.Month + "/" + Appointment.Date.Day + "', scheduleid = " + Appointment.ScheduleID + ", observation = '" + Appointment.Observation.Trim() + "' where Appointmentid = " + Appointment.AppointmentID;
            database.QueryString = sql;
           database.Execute();

        }

        public void GetAll()
        {
            ScheduleTable.Clear();

            string queryString = searchSQL();
            
            database.QueryString = queryString;
            DataTable data = database.GetAll();

            for (int row = 0; row < data.Rows.Count; row++)
            {
                int appointmentID = int.Parse(data.Rows[row]["Appointmentid"].ToString());
                int doctorID = int.Parse(data.Rows[row]["DoctorID"].ToString());
                string doctorName = data.Rows[row]["DoctorName"].ToString();
                int patientID = int.Parse(data.Rows[row]["PatientID"].ToString());
                string patientName = data.Rows[row]["PatientName"].ToString();
                int roomID = int.Parse(data.Rows[row]["RoomID"].ToString());
                string roomName = data.Rows[row]["RoomName"].ToString();
                DateTime date = DateTime.Parse( (data.Rows[row]["Date"].ToString()));
                string time = Appointment.Times[int.Parse(data.Rows[row]["ScheduleID"].ToString())];
                string observation = data.Rows[row]["observation"].ToString();
                
                Appointment fieldData = new Appointment();
                fieldData.AppointmentID = appointmentID;
                fieldData.DoctorID = doctorID;
                fieldData.DoctorName = doctorName;
                fieldData.PatientID = patientID;
                fieldData.PatientName = patientName;
                fieldData.RoomID = roomID;
                fieldData.RoomName = roomName;
                fieldData.Time = time;
                fieldData.Date = date;
                
                fieldData.Observation = observation;
                
                ScheduleTable.Add(fieldData);
            }

        }



        private string searchSQL()
        {
            string sql = "select ScheduleID, AppointmentID, a.RoomID, r.Name as RoomName, a.PatientID, p.LastName as PatientName, a.DoctorID, d.LastName as DoctorName, date,  observation from Appointments a left join doctors d on a.DoctorID = d.DoctorID left join Patients p on a.PatientID = p.PatientID   left join Rooms r on a.RoomID = r.RoomID";
            bool bCriteria = false;


            if (Search.DoctorID != 0)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";

                sql += " (a.doctorid = " + Search.DoctorID + ")";
                bCriteria = true;
            }

            if (Search.Date != null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";

                sql += " (a.date = '" + Search.Date.Year + "/" + Search.Date.Month + "/" + Search.Date.Day +  "')";
                bCriteria = true;
            }

            if (Search.PatientName != "" && Search.PatientName !=null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";

                sql += " (p.lastname like '%" + Search.PatientName + "%' or p.firstname like '%" + Search.PatientName + "%')";
                bCriteria = true;
            }

            if (Search.HealthID != "" && Search.HealthID != null)
            {
                if (!bCriteria) 
                    sql += " where ";
                else
                    sql += " and ";
                sql += " (p.healthcard like '%" + Search.HealthID + "%')";
                bCriteria = true;
            }

            if (Search.Phone != "" && Search.Phone != null)
            {
                if (!bCriteria)
                    sql += " where ";
                else
                    sql += " and ";

                sql += " (p.phone like '%" + Search.Phone + "%')";
            }

            sql += " order by ScheduleID ";
            return sql;
        }

    }
    public class ScheduleSearch
    {
        public string Phone { get; set; }
        public string PatientName { get; set; }
        public string HealthID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date { get; set; }

    }
}
