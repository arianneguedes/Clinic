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
    public partial class frmDoctors : Form
    {
        Doctors DoctorsData = new Doctors();

        public frmDoctors()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            dtBirthDate.Value = DateTime.Today;
            loadData();
            populateProvinces();
        }

        private void loadData()
        {
            DoctorsData.GetAll();
            populateLvw(DoctorsData.DoctorsTable);
        }

        private void populateProvinces()
        {
            //Populate provinces on the form
            Provinces provinces = new Provinces();
            provinces.GetAll();
            cboProvince.DisplayMember = "Name";
            cboProvince.ValueMember = "ProvinceID";
            cboProvince.DataSource = provinces.ProvincesTable;
        }

        private void populateLvw(List<Doctor> doctors)
        {
            //Populate Lvw with doctor information
            lvwDoctors.Items.Clear();
            foreach (var item in doctors)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = item.ID.ToString();
                lvwItem.SubItems.Add(item.LastName);
                lvwItem.SubItems.Add(item.FirstName);
                lvwItem.SubItems.Add(item.Phone);
                lvwItem.SubItems.Add(item.LicenceNumber);
                lvwDoctors.Items.Add(lvwItem);
            }
            lblCount.Text = lvwDoctors.Items.Count + " Doctor(s) found";
        }

        private void enableDisableFields(bool value)
        {
            grpAddressInfo.Enabled = value;
            grpPersonalInfo.Enabled = value;
        }

        private void lvwDoctors_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
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
            txtDoctorID.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtLicenceID.Text = "";
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
            //grpPersonalInfo.Text = text + " Personal Information";
            //grpAddressInfo.Text = text + " Address Information";

            btnOk.Text = text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (btnOk.Text == "Update")
                {
                    DoctorsData.Update(returnFormData());
                    MessageBox.Show("Record updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DoctorsData.Add(returnFormData());
                    MessageBox.Show("Record added successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfields();
                }
                loadData();
            }
        }

        private Doctor returnFormData()
        {
            //Put all form information in an object
            Doctor doctor = new Doctor();
            int doctorid = 0;
            int.TryParse(txtDoctorID.Text, out doctorid);
            doctor.ID = doctorid;
            doctor.LastName = txtLastName.Text;
            doctor.FirstName = txtFirstName.Text;
            doctor.Address = txtAddress1.Text;
            doctor.Address2 = txtAddress2.Text;
            doctor.City = txtCity.Text;
            doctor.LicenceNumber = txtLicenceID.Text;
            doctor.PostalCode = txtPostalCode.Text;
            doctor.ProvinceID = int.Parse(cboProvince.SelectedValue.ToString());
            doctor.Phone = txtPhone.Text;
            doctor.Email = txtEmail.Text;
            doctor.DoB = dtBirthDate.Value.Year + "/" + dtBirthDate.Value.Month + "/" + dtBirthDate.Value.Day;
            return doctor;
        }

        public bool validateFields()
        {
            if (txtLastName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a last name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (txtFirstName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a first name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (txtLicenceID.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a licence ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenceID.Focus();
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

        private void lvwDoctors_MouseClick(object sender, MouseEventArgs e)
        {
            enableButtons(false);
            EnDisFields(false);

            if (lvwDoctors.SelectedItems.Count > 0)
            {
                Doctor doctor = new Doctor();
                doctor = DoctorsData.GetOne(int.Parse(lvwDoctors.Items[lvwDoctors.SelectedItems[0].Index].Text));

                txtDoctorID.Text = doctor.ID.ToString();
                txtLastName.Text = doctor.LastName;
                txtFirstName.Text = doctor.FirstName;
                txtAddress1.Text = doctor.Address;
                txtAddress2.Text = doctor.Address2;
                txtCity.Text = doctor.City;
                txtLicenceID.Text = doctor.LicenceNumber;
                txtPostalCode.Text = doctor.PostalCode;
                Provinces provinces = new Provinces();
                cboProvince.Text = provinces.GetOne(doctor.ProvinceID).Name;
                txtPhone.Text = doctor.Phone;
                txtEmail.Text = doctor.Email;
                dtBirthDate.Text = doctor.DoB;
                
                enableButtons(true);
            }
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
            if (lvwDoctors.SelectedItems.Count > 0)
                for (int i = 0; i < lvwDoctors.SelectedItems.Count; i++)
                {
                    lvwDoctors.SelectedItems[i].Selected = false;
                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDoctorID.Text != "" && lvwDoctors.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Do you confirm this deletion?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Delete
                    DoctorsData.Remove(returnFormData());
                    MessageBox.Show("Record deleted successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearfields();
                    loadData();
                }
            }
        }

        private void grpTools_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            DoctorsData.Search.Name = txtSearchName.Text;
            loadData();
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            DoctorsData.Search.Phone = txtSearchPhone.Text;
            loadData();
        }

        private void txtLicence_TextChanged(object sender, EventArgs e)
        {
            DoctorsData.Search.LicenceID = txtLicence.Text;
            loadData();
        }
    }
}