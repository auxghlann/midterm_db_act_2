using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace midterm_db_act_2
{
    public partial class frmLogin : Form
    {

        private Database _db;
        private OleDbDataReader reader;
        public frmLogin()
        {
            InitializeComponent();
            this._db = new Database();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text)) 
            {
                MessageBox.Show("username and password must have a value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = _db.login(txtUsername.Text, txtPassword.Text);

            if (!string.IsNullOrEmpty(username))
            {
                frmMain frmMain = new frmMain(username, _db);
                frmMain.ShowDialog();
            } else
            {
                MessageBox.Show("Invalid Credentials", "Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
