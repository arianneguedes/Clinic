﻿//Name: Project - Clinic Management System
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
    //Patient class - Module class that contains all Patient data
    class Patient : Person
    {
        public string HealthCardNumber { get; set; }
    }
}
