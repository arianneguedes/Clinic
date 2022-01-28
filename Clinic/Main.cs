//Name: Project - Clinic Management System
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Authors: Arianne Guedes (425002), Jorge Gayer (424267), Robert Parker (423817)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class frmMain : Form
    {
        public static int access_level;
        public frmMain()
        {
            
            InitializeComponent();
            frmLogin login = new frmLogin();
            login.ShowDialog(this);

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openPatient(object sender, EventArgs e)
        {
            frmPatients patient = new frmPatients();
            patient.MdiParent = this;
            patient.Show();
        }

        private void openDoctor(object sender, EventArgs e)
        {
            frmDoctors doctor = new frmDoctors();
            doctor.MdiParent = this;
            doctor.Show();
        }

        private void toolRooms_Click(object sender, EventArgs e)
        {
            frmRooms room = new frmRooms();
            room.MdiParent = this;
            room.Show();
        }

        private void toolSchedule_Click(object sender, EventArgs e)
        {
            frmSchedule schedule = new frmSchedule();
            schedule.MdiParent = this;
            schedule.Show();

        }

        private void toolUsers_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers();
            users.MdiParent = this;
            users.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           

        }

        private void frmMain_Enter(object sender, EventArgs e)
        {
           
        }

        private void frmMain_MouseHover(object sender, EventArgs e)
        {
            if(access_level == 1)
            {
                toolPatients.Enabled = true;
            }
        }

        private void frmMain_MouseEnter(object sender, EventArgs e)
        {
            if (access_level == 1)
            {
                toolPatients.Enabled = true;
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (access_level == 2)
            {
                toolPatients.Enabled = true;
                toolDoctors.Enabled = true;
                toolRooms.Enabled = true;
                toolSchedule.Enabled = true;
                toolUsers.Enabled = true;
            }
            if (access_level == 1)
            {
                toolPatients.Enabled = true;
    
                toolSchedule.Enabled = true;
                
            }
        }
    }
}