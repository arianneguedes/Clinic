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
    public partial class frmRooms : Form
    {
        Rooms RoomsData = new Rooms();
        public frmRooms()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
        }
        public bool validateFields()
        {
            if (tBoxRoomName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a name for the room", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxRoomName.Focus();
                return false;
            }


            return true;
        }

        private void loadData()
        {

            RoomsData.GetAll();
            populateLvw(RoomsData.RoomsTable);

        }

        private void populateLvw (List<Room> rooms)
        {
            lvwRooms.Items.Clear();
            foreach (var item in rooms)
            {
                ListViewItem lvwItem = new ListViewItem();
                lvwItem.Text = item.RoomId.ToString();
                lvwItem.SubItems.Add(item.Name);
                lvwItem.SubItems.Add(item.Notes);
                lvwRooms.Items.Add(lvwItem);
            }
            lblCount.Text = lvwRooms.Items.Count + " Rooms found";
        }

        private void lvwRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lvwRooms_MouseClick(object sender, MouseEventArgs e)
        {
            enableButtons(false);
            EnDisFields(false);
            if (lvwRooms.SelectedItems.Count > 0)
            {
                tBoxRoomID.Text = lvwRooms.Items[lvwRooms.SelectedItems[0].Index].SubItems[0].Text;
                tBoxRoomName.Text = lvwRooms.Items[lvwRooms.SelectedItems[0].Index].SubItems[1].Text;
                tBoxRoomNotes.Text = lvwRooms.Items[lvwRooms.SelectedItems[0].Index].SubItems[2].Text;
                enableButtons(true);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clearfields();
            EnDisFields(true);
            EnableCrud("Add");
        }
        public void EnDisFields ( bool value)
        {
            grpFields.Enabled = value;
            btnOk.Visible = value;
        }
        public void Clearfields()
        {
            tBoxRoomID.Text = "";
            tBoxRoomName.Text = "";
            tBoxRoomNotes.Text = "";

            unSelectItems();
            enableButtons(false);

        }
        public void EnableCrud(string text)
        {
            grpFields.Text = text + " Room";
            btnOk.Text = text;
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
            if (lvwRooms.SelectedItems.Count > 0)
                for (int i = 0; i < lvwRooms.SelectedItems.Count; i++)
                {
                    lvwRooms.SelectedItems[i].Selected = false;
                }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tBoxRoomID.Text != "" && lvwRooms.SelectedItems.Count > 0)
            {
                if (MessageBox.Show ("Do you confirm this deletion?", "Confirmation",  MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    //delete
                    RoomsData.Remove(returnFormData());
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
                    RoomsData.Update(returnFormData());
                    MessageBox.Show("Record updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RoomsData.Add(returnFormData());
                    MessageBox.Show("Record added successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                loadData();
            }
        }

        private Room returnFormData()
        {
            Room room = new Room();
            int roomid = 0;
            int.TryParse(tBoxRoomID.Text, out roomid);
            room.RoomId = roomid;
            room.Name = tBoxRoomName.Text;
            room.Notes = tBoxRoomNotes.Text;
            return room;
        }

        private void grpFields_Enter(object sender, EventArgs e)
        {

        }
    }

}
