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
using System.Configuration;
using System.Data.SqlClient;

namespace Clinic
{
    public partial class frmPatients : Form
    {
        Patients PatientsData = new Patients();

        public frmPatients()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
            
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            dtBirthDate.Value = DateTime.Today;
            loadData();
            populateProvinces();
        }

        private void loadData()
        {
            PatientsData.GetAll();
            populateLvw(PatientsData.PatientsTable);
        }

        private void populateProvinces()
        {
            Provinces provinces = new Provinces();
            provinces.GetAll();
            cboProvince.DisplayMember = "Name";
            cboProvince.ValueMember = "ProvinceID";
            cboProvince.DataSource = provinces.ProvincesTable;
        }

        private void populateLvw(List<Patient> patients)
        {
            lvwPatients.Items.Clear();
            foreach (var item in patients)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = item.ID.ToString();
                lvwItem.SubItems.Add(item.LastName);
                lvwItem.SubItems.Add(item.FirstName);
                lvwItem.SubItems.Add(item.Phone);
                lvwItem.SubItems.Add(item.HealthCardNumber);
                lvwPatients.Items.Add(lvwItem);
            }
            lblCount.Text = lvwPatients.Items.Count + " Patient(s) found";
        }

        private void enableDisableFields(bool value)
        {
            grpAddressInfo.Enabled = value;
            grpPersonalInfo.Enabled = value;
        }

        private void lvwPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwPatients_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            enableDisableFields(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clearfields();
            EnDisFields(true);
            EnableCrud("Add");
        }

        public void EnDisFields(bool value)
        {
            grpPersonalInfo.Enabled = value;
            grpAddressInfo.Enabled = value;
            btnOk.Visible = value;
        }

        public void Clearfields()
        {
            txtPatientID.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtHealthID.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            dtBirthDate.Text = DateTime.Parse(DateTime.Today.ToString()).ToString("dd/MM/yyyy");
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            cboProvince.SelectedIndex = 0;
            txtCity.Text = "";
            txtPostalCode.Text = "";

            unSelectItems();
            enableButtons(false);
        }

        public void EnableCrud(string text)
        {
            btnOk.Text = text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (btnOk.Text == "Update")
                {
                    PatientsData.Update(returnFormData());
                    MessageBox.Show("Record updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PatientsData.Add(returnFormData());
                    MessageBox.Show("Record added successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfields();
                }
                loadData();
            }
        }

        private Patient returnFormData()
        {
            Patient patient = new Patient();
            int patientid = 0;
            int.TryParse(txtPatientID.Text, out patientid);
            patient.ID = patientid;
            patient.LastName = txtLastName.Text;
            patient.FirstName = txtFirstName.Text;
            patient.Address = txtAddress1.Text;
            patient.Address2 = txtAddress2.Text;
            patient.City = txtCity.Text;
            patient.HealthCardNumber = txtHealthID.Text;
            patient.PostalCode = txtPostalCode.Text;
            patient.ProvinceID = int.Parse(cboProvince.SelectedValue.ToString());
            patient.Phone = txtPhone.Text;
            patient.Email = txtEmail.Text;
            patient.DoB = dtBirthDate.Value.Year + "/" + dtBirthDate.Value.Month + "/" + dtBirthDate.Value.Day;
            return patient;
        }

        public bool validateFields()
            //Validate fields from the form
        {
            if (txtLastName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a last name","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                txtLastName.Focus();
                return false;
            }

            if (txtFirstName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a first name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (txtHealthID.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a health ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHealthID.Focus();
                return false;
            }

            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a phone number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter an email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            string d1 = DateTime.Parse(DateTime.Today.ToString()).ToString("dd/MM/yyyy");
            string d2 = DateTime.Parse(dtBirthDate.Text).ToString("dd/MM/yyyy");

            if (d1 == d2)
            {
                MessageBox.Show(this, "The birthdate cannot be today!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtBirthDate.Focus();
                return false;
            }

            if (txtAddress1.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter an dddress", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress1.Focus();
                return false;
            }

            if (cboProvince.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a province", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProvince.Focus();
                return false;
            }

            if (txtCity.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a city", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return false;
            }

            if (txtPostalCode.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a postal code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPostalCode.Focus();
                return false;
            }

            return true; 
        }

        private void lvwPatients_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void grpTools_Enter(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableCrud("Update");
            EnDisFields(true);
        }

        private void enableButtons(bool value)
        {
            btnDelete.Enabled = value;
            btnEdit.Enabled = value;
        }

        private void unSelectItems()
        {
            if (lvwPatients.SelectedItems.Count > 0)
                for (int i = 0; i < lvwPatients.SelectedItems.Count; i++)
                {
                    lvwPatients.SelectedItems[i].Selected = false;
                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text != "" && lvwPatients.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Do you confirm this deletion?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Delete
                    PatientsData.Remove(returnFormData());
                    MessageBox.Show("Record deleted successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfields();
                    loadData();
                }
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            PatientsData.Search.Name = txtSearchName.Text;
            loadData();
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            PatientsData.Search.Phone = txtSearchPhone.Text;
            loadData();
        }

        private void txtHealth_TextChanged(object sender, EventArgs e)
        {
            PatientsData.Search.HealthID = txtHealth.Text;
            loadData();
        }

        private void lvwPatients_MouseClick_1(object sender, MouseEventArgs e)
        {
            enableButtons(false);
            EnDisFields(false);

            if (lvwPatients.SelectedItems.Count > 0)
            {
                Patient patient = new Patient();
                patient = PatientsData.GetOne(int.Parse(lvwPatients.Items[lvwPatients.SelectedItems[0].Index].Text));

                txtPatientID.Text = patient.ID.ToString();
                txtLastName.Text = patient.LastName;
                txtFirstName.Text = patient.FirstName;
                txtAddress1.Text = patient.Address;
                txtAddress2.Text = patient.Address2;
                txtCity.Text = patient.City;
                txtHealthID.Text = patient.HealthCardNumber;
                txtPostalCode.Text = patient.PostalCode;
                Provinces provinces = new Provinces();
                cboProvince.Text = provinces.GetOne(patient.ProvinceID).Name;
                txtPhone.Text = patient.Phone;
                txtEmail.Text = patient.Email;
                dtBirthDate.Text = patient.DoB;

                enableButtons(true);
            }
        }

        private void grpAddressInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}