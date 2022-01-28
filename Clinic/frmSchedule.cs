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
    public partial class frmSchedule : Form
    {
        Schedule ScheduleData = new Schedule();
        List<Doctor> localDoctors = new List<Doctor>();
        public frmSchedule()
        {
            InitializeComponent();
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            dtFilterDate.Value = DateTime.Today;
            loadDoctors();
            loadPatients();
            loadTimes();
            loadRooms();
            loadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool validateFields()
        {
            //if (tBoxRoomName.Text.Trim() == "")
            //{
            //    MessageBox.Show(this, "Please enter a name for the room", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tBoxRoomName.Focus();
            //    return false;
            //}


            return true;
        }

        private void loadData()
        {
            ScheduleData.GetAll();
            populateLvw(ScheduleData.ScheduleTable);

        }

        private void populateLvw(List<Appointment> schedule)
        {
            //Populate lvw with all schedule information
            lvwSchedule.Items.Clear();
            foreach (var item in schedule)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = item.AppointmentID.ToString();
                lvwItem.SubItems.Add(item.DoctorName);
                lvwItem.SubItems.Add(item.Date.Month + "/" + item.Date.Day + "/" + item.Date.Year);
                lvwItem.SubItems.Add(item.Time.ToString());
                lvwItem.SubItems.Add(item.PatientName.ToString());
                lvwItem.SubItems.Add(item.Observation.ToString());
                lvwItem.SubItems.Add(item.RoomName.ToString());

                lvwSchedule.Items.Add(lvwItem);
            }
            lblCount.Text = lvwSchedule.Items.Count + " Appointments found";
            lblAvailableTime.Text = 18 - lvwSchedule.Items.Count + " Available times ";
        }
        public void EnDisFields(bool value)
        {
            grpFields.Enabled = value;
            btnOk.Visible = value;
        }
        public void Clearfields()
        {
            //Clear fields from the form
            cboDoctor.SelectedIndex = 0;
            cboPatient.SelectedIndex = 0;
            cboRoom.SelectedIndex = 0;
            dtDate.Value = dtFilterDate.Value;
            txtObservation.Clear();
            cboTime.SelectedIndex = 0;

            unSelectItems();
            enableButtons(false);

        }
        public void EnableCrud(string text)
        {
            grpFields.Text = text + " Appointment";
            btnOk.Text = text;
        }
        private void enableButtons(bool value)
        {
            btnDelete.Enabled = value;
            btnEdit.Enabled = value;
        }

        private void unSelectItems()
        {
            if (lvwSchedule.SelectedItems.Count > 0)
                for (int i = 0; i < lvwSchedule.SelectedItems.Count; i++)
                {
                    lvwSchedule.SelectedItems[i].Selected = false;
                }
        }

        private Appointment returnFormData()
        {
            //insert all data from the form to an object
            Appointment app = new Appointment();
            int appid = 0;
            int.TryParse(txtAppointmentID.Text, out appid);
            app.AppointmentID = appid;
            app.DoctorID = int.Parse(cboDoctor.SelectedValue.ToString());
            app.PatientID = int.Parse(cboPatient.SelectedValue.ToString());
            app.RoomID = int.Parse(cboRoom.SelectedValue.ToString());
            app.Time = cboTime.Text;
            app.Date = dtDate.Value;
            app.Observation = txtObservation.Text.Trim();
            return app;
        }

        private void lvwSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwSchedule_MouseClick(object sender, MouseEventArgs e)
        {
            enableButtons(false);
            EnDisFields(false);
            if (lvwSchedule.SelectedItems.Count > 0)
            {
                txtAppointmentID.Text = lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].Text;
                cboDoctor.Text = lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].SubItems[1].Text;
                dtDate.Value = DateTime.Parse( lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].SubItems[2].Text);
                cboTime.Text = lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].SubItems[3].Text;
                cboPatient.Text = lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].SubItems[4].Text;
                txtObservation.Text = lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].SubItems[5].Text;
                cboRoom.Text = lvwSchedule.Items[lvwSchedule.SelectedItems[0].Index].SubItems[6].Text;
                enableButtons(true);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clearfields();
            EnDisFields(true);
            EnableCrud("Add");

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableCrud("Update");
            EnDisFields(true);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtAppointmentID.Text != "" && lvwSchedule.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Do you confirm this deletion?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //delete
                    ScheduleData.Remove(returnFormData());
                    MessageBox.Show("Record deleted successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (btnOk.Text == "Update")
                {
                    ScheduleData.Update(returnFormData());
                    MessageBox.Show("Record updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ScheduleData.Add(returnFormData());
                    MessageBox.Show("Record added successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfields();
                }
                ScheduleData.Search.Date = dtFilterDate.Value;
                loadData();
                enableButtons(false);
                EnDisFields(false);
            }
        }
        private void loadDoctors()
        {
            Doctors doctors = new Doctors();
            doctors.GetAll();

            localDoctors =  doctors.DoctorsTable;

            cboDoctor.Items.Clear();
            cboDoctor.DisplayMember = "LastName";
            cboDoctor.ValueMember = "ID";
            cboDoctor.DataSource = doctors.DoctorsTable;

            cboDoctor.SelectedIndex = 0;

            cboFilterDoctor.Items.Clear();
            cboFilterDoctor.Items.Add ("All Doctors");
            foreach (var item in localDoctors)
            {
                cboFilterDoctor.Items.Add(item.LastName + ", " + item.FirstName);
            }
            
            cboFilterDoctor.SelectedIndex = 0;


        }

        private void loadPatients()
        {
            Patients patients = new Patients();
            patients.GetAll();
            List<Patient> localPatients = new List<Patient>();
            localPatients = patients.PatientsTable;
            cboPatient.Items.Clear();

            cboPatient.DisplayMember = "LastName";
            cboPatient.ValueMember = "ID";
            cboPatient.DataSource = patients.PatientsTable;
            cboPatient.SelectedIndex = 0;
        }

        private void loadTimes() {
            cboTime.Items.Clear();
            foreach (var item in Appointment.Times)
            {
                if (item!=null)
                {
                    cboTime.Items.Add(item);
                }
                
            }
        }

        private void loadRooms()
        {
            cboRoom.Items.Clear();
            Rooms rooms = new Rooms();
            rooms.GetAll();

            cboRoom.DisplayMember = "Name";
            cboRoom.ValueMember = "RoomID";
            cboRoom.DataSource = rooms.RoomsTable;
            cboRoom.SelectedIndex = 0;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtFilterDate_ValueChanged(object sender, EventArgs e)
        {
            ScheduleData.Search.Date = dtFilterDate.Value;
            loadData();
        }

        private void cboFilterDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleData.Search.DoctorID = getDoctorID();
            loadData();
        }

        private int getDoctorID()
        {
            int id = 0;
            foreach (var item in localDoctors)
            {
                if ((item.LastName + ", " + item.FirstName) == cboFilterDoctor.Text)
                {
                    id=  item.ID;
                }
            }
            return id;
        }
        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            ScheduleData.Search.PatientName = txtSearchName.Text;
            loadData();
        }

        private void txtHealth_TextChanged(object sender, EventArgs e)
        {
            ScheduleData.Search.HealthID = txtHealth.Text;
            loadData();

        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            ScheduleData.Search.Phone = txtSearchPhone.Text;
            loadData();
        }
    }
}
