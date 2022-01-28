using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    //Appointment class - Module class that contains all Appointment data
    class Appointment
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public DateTime Date { get; set; }
        public string Time {get; set;}
        public string Observation { get; set; }
        public int ScheduleID { 
            get
            {
                for (int i = 0; i < 19; i++)
                {
                    if (Times[i] == Time)
                    {
                        return i;
                    }
                }
                return 0;
            }
        }

        public static string [] Times
        {
            get
            {
                string[] _Times = new string[19];
                _Times[1] = "08:00";
                _Times[2] = "08:30";
                _Times[3] = "09:00";
                _Times[4] = "09:30";
                _Times[5] = "10:00";
                _Times[6] = "10:30";
                _Times[7] = "11:00";
                _Times[8] = "11:30";
                _Times[9] = "12:00";
                _Times[10] = "12:30";
                _Times[11] = "13:00";
                _Times[12] = "13:30";
                _Times[13] = "14:00";
                _Times[14] = "14:30";
                _Times[15] = "15:00";
                _Times[16] = "15:30";
                _Times[17] = "16:00";
                _Times[18] = "16:30";
                return _Times;
            }
        }
    }



}