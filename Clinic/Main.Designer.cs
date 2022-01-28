
namespace Clinic
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Tooltip = new System.Windows.Forms.ToolStrip();
            this.toolPatients = new System.Windows.Forms.ToolStripButton();
            this.toolRooms = new System.Windows.Forms.ToolStripButton();
            this.toolDoctors = new System.Windows.Forms.ToolStripButton();
            this.toolSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolUsers = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Tooltip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1272, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "Welcome to Clinic Appointment Management System";
            // 
            // Tooltip
            // 
            this.Tooltip.CanOverflow = false;
            this.Tooltip.GripMargin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.Tooltip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tooltip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.Tooltip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPatients,
            this.toolRooms,
            this.toolDoctors,
            this.toolSchedule,
            this.toolUsers});
            this.Tooltip.Location = new System.Drawing.Point(0, 0);
            this.Tooltip.Name = "Tooltip";
            this.Tooltip.Size = new System.Drawing.Size(1272, 64);
            this.Tooltip.TabIndex = 1;
            this.Tooltip.Text = "toolStrip1";
            // 
            // toolPatients
            // 
            this.toolPatients.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPatients.Enabled = false;
            this.toolPatients.Image = ((System.Drawing.Image)(resources.GetObject("toolPatients.Image")));
            this.toolPatients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPatients.Name = "toolPatients";
            this.toolPatients.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolPatients.Size = new System.Drawing.Size(54, 61);
            this.toolPatients.Text = "Patients";
            this.toolPatients.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolPatients.Click += new System.EventHandler(this.openPatient);
            // 
            // toolRooms
            // 
            this.toolRooms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRooms.Enabled = false;
            this.toolRooms.Image = ((System.Drawing.Image)(resources.GetObject("toolRooms.Image")));
            this.toolRooms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRooms.Name = "toolRooms";
            this.toolRooms.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolRooms.Size = new System.Drawing.Size(54, 61);
            this.toolRooms.Text = "Rooms";
            this.toolRooms.Click += new System.EventHandler(this.toolRooms_Click);
            // 
            // toolDoctors
            // 
            this.toolDoctors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDoctors.Enabled = false;
            this.toolDoctors.Image = ((System.Drawing.Image)(resources.GetObject("toolDoctors.Image")));
            this.toolDoctors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDoctors.Name = "toolDoctors";
            this.toolDoctors.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolDoctors.Size = new System.Drawing.Size(54, 61);
            this.toolDoctors.Text = "Doctors";
            this.toolDoctors.Click += new System.EventHandler(this.openDoctor);
            // 
            // toolSchedule
            // 
            this.toolSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSchedule.Enabled = false;
            this.toolSchedule.Image = ((System.Drawing.Image)(resources.GetObject("toolSchedule.Image")));
            this.toolSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSchedule.Margin = new System.Windows.Forms.Padding(15);
            this.toolSchedule.Name = "toolSchedule";
            this.toolSchedule.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolSchedule.Size = new System.Drawing.Size(54, 34);
            this.toolSchedule.Text = "Schedule";
            this.toolSchedule.Click += new System.EventHandler(this.toolSchedule_Click);
            // 
            // toolUsers
            // 
            this.toolUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUsers.Enabled = false;
            this.toolUsers.Image = ((System.Drawing.Image)(resources.GetObject("toolUsers.Image")));
            this.toolUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUsers.Name = "toolUsers";
            this.toolUsers.Size = new System.Drawing.Size(34, 61);
            this.toolUsers.Text = "Users";
            this.toolUsers.Click += new System.EventHandler(this.toolUsers_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 676);
            this.Controls.Add(this.Tooltip);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Clinic Appointment Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Enter += new System.EventHandler(this.frmMain_Enter);
            this.MouseEnter += new System.EventHandler(this.frmMain_MouseEnter);
            this.MouseHover += new System.EventHandler(this.frmMain_MouseHover);
            this.Tooltip.ResumeLayout(false);
            this.Tooltip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip Tooltip;
        private System.Windows.Forms.ToolStripButton toolPatients;
        private System.Windows.Forms.ToolStripButton toolRooms;
        private System.Windows.Forms.ToolStripButton toolDoctors;
        private System.Windows.Forms.ToolStripButton toolSchedule;
        private System.Windows.Forms.ToolStripButton toolUsers;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

