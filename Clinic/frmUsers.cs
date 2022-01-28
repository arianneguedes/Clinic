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
    public partial class frmUsers : Form
    {
        Users UserData = new Users();
        public frmUsers()
        {
            InitializeComponent();
        }

        public bool validateFields()
        {
            if (tBoxUsername.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxUsername.Focus();
                return false;
            }


            return true;
        }


        private void frmUsers_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {

            UserData.GetAll();
            populateLvw(UserData.UserTable);

        }

        private void populateLvw(List<User> users)
        {
            lvwUsers.Items.Clear();
            foreach (var item in users)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = item.UserId.ToString();
                lvwItem.SubItems.Add(item.Username);
                lvwItem.SubItems.Add(item.Password);
                lvwItem.SubItems.Add(item.AccessLevel.ToString());
                lvwUsers.Items.Add(lvwItem);
            }
            lblCount.Text = lvwUsers.Items.Count + " users found";
        }

        private void grpTools_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clearfields();
            EnDisFields(true);
            EnableCrud("Add");
        }

        public void EnDisFields(bool value)
        {
            grpFields.Enabled = value;
            btnUserOk.Visible = value;
        }
        public void Clearfields()
        {
            tBoxUserID.Text = "";
            tBoxUsername.Text = "";
            tBoxUserPassword.Text = "";
            tBoxAccessLevel.Text = "";
            unSelectItems();
            enableButtons(false);

        }
        public void EnableCrud(string text)
        {
            grpFields.Text = text + " User";
            btnOk.Text = text;
        }
        private void enableButtons(bool value)
        {
            btnDelete.Enabled = value;
            btnEdit.Enabled = value;
        }

        private void unSelectItems()
        {
            if (lvwUsers.SelectedItems.Count > 0)
                for (int i = 0; i < lvwUsers.SelectedItems.Count; i++)
                {
                    lvwUsers.SelectedItems[i].Selected = false;
                }
        }

        private void btnUserOk_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (btnOk.Text == "Update")
                {
                    UserData.Update(returnFormData());
                    MessageBox.Show("Record updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UserData.Add(returnFormData());
                    MessageBox.Show("Record added successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                loadData();
            }
        }
        private User returnFormData()
        {
            User user = new User();
            int userid = 0;
            int accesslevel = 0;
            int.TryParse(tBoxAccessLevel.Text, out accesslevel);
            int.TryParse(tBoxUserID.Text, out userid);
            user.UserId = userid;
            user.Username = tBoxUsername.Text;
            user.Password = tBoxUserPassword.Text;
            user.AccessLevel = accesslevel;
            return user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableCrud("Update");
            EnDisFields(true);
        }

        private void lvwUsers_MouseClick(object sender, MouseEventArgs e)
        {
            enableButtons(false);
            EnDisFields(false);
            if (lvwUsers.SelectedItems.Count > 0)
            {
                tBoxUserID.Text = lvwUsers.Items[lvwUsers.SelectedItems[0].Index].SubItems[0].Text;
                tBoxUsername.Text = lvwUsers.Items[lvwUsers.SelectedItems[0].Index].SubItems[1].Text;
                tBoxUserPassword.Text = lvwUsers.Items[lvwUsers.SelectedItems[0].Index].SubItems[2].Text;
                tBoxAccessLevel.Text = lvwUsers.Items[lvwUsers.SelectedItems[0].Index].SubItems[3].Text;
                enableButtons(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tBoxUserID.Text != "" && lvwUsers.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Do you confirm this deletion?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //delete
                   UserData.Remove(returnFormData());
                    MessageBox.Show("Record deleted successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
        }
    }
}
