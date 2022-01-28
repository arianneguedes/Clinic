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
    public partial class frmLogin : Form
    {
        Users users = new Users();
        User user = new User();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmMain.access_level = 2;
            //this.Close();
            check_credentials(tBoxUsername.Text);

        }
        private void check_credentials(string _username)
        {
            user = users.GetOne(_username);
            if(user == null)
            {
                
            }
            else
            {
                if (user.Password == tBoxPassword.Text)
                {
                    frmMain.access_level = user.AccessLevel;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is incorrect", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
