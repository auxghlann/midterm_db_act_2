using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm_db_act_2
{
    public partial class frmDelete : Form
    {
        private Database _db;
        private string name, email;
        public frmDelete(string name, string email, Database db)
        {
            InitializeComponent();
            this.name = name;
            this.email = email;
            this._db = db;
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            txtDelEmail.Text = this.email;
            txtDelName.Text = this.name;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDelName.Text) || string.IsNullOrEmpty(txtDelEmail.Text))
            {
                MessageBox.Show("Input fields must have a value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rows_affected = this._db.delete_employee(txtDelName.Text, txtDelEmail.Text);

            if (rows_affected > 0)
            {
                MessageBox.Show("Employee Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to delete Employee", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDelName.Clear(); 
            txtDelEmail.Clear();
        }



    }
}
