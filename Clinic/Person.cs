//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    //Person class - Module class that contains all Person data
    class Person
    {
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string DoB { set; get; }
        public string Address { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public int ProvinceID { set; get; }
        public string PostalCode { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
    }
}