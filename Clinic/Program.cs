//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
