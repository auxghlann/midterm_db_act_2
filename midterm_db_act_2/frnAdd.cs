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
    public partial class frmAdd : Form
    {

        private Database _db;
        public frmAdd(Database db)
        {
            InitializeComponent();
            this._db = db;
        }

        // Helper functions
        public void InitializeCBO()
        {
            cboAddSex.Items.Add("Male");
            cboAddSex.Items.Add("Female");
        }

        // Winform fucntions


        private void frmAdd_Load(object sender, EventArgs e)
        {
            InitializeCBO();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddName.Text) || string.IsNullOrEmpty(txtAddEmail.Text) ||
                string.IsNullOrEmpty(txtAddAddress.Text) || string.IsNullOrEmpty(cboAddSex.Text))
            {
                MessageBox.Show("Input fields must have a value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rows_affected = this._db.add_employee(txtAddName.Text, txtAddEmail.Text, cboAddSex.Text, txtAddAddress.Text);

            if (rows_affected > 0)
            {
                MessageBox.Show("Employee Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add Employee", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAddAddress.Clear();
            txtAddEmail.Clear();
            txtAddAddress.Clear();
            cboAddSex.SelectedIndex = -1;
        }
    }
}
