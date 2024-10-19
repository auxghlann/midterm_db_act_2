using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace midterm_db_act_2
{
    public partial class frmEdit : Form
    {
        private Database _db;
        private string id, name, email, address;

        public frmEdit(string id, string name, string email, string address, Database db)
        {
            InitializeComponent();
            this._db = db;
            this.id = id;
            this.name = name;
            this.email = email;
            this.address = address;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            txtUpdateID.Text = this.id;
            txtUpdateName.Text = this.name;
            txtUpdateEmail.Text = this.email;
            txtUpdateAddress.Text = this.address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUpdateID.Text) || string.IsNullOrEmpty(txtUpdateName.Text) ||
               string.IsNullOrEmpty(txtUpdateEmail.Text) || string.IsNullOrEmpty(txtUpdateAddress.Text))
            {
                MessageBox.Show("Input fields must have a value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rows_affected = this._db.update_employee(Convert.ToInt32(txtUpdateID.Text), txtUpdateName.Text,
                txtUpdateEmail.Text, txtUpdateAddress.Text);

            if (rows_affected > 0)
            {
                MessageBox.Show("Employee Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update Employee", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUpdateID.Clear();
            txtUpdateName.Clear();
            txtUpdateEmail.Clear();
            txtUpdateAddress.Clear();
        }


    }
}
