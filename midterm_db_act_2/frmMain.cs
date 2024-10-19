using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm_db_act_2
{
    public partial class frmMain : Form
    {

        private Database _db;
        private string username;
        public frmMain(string username, Database db)
        {
            InitializeComponent();
            this._db = db;
            this.username = username;
        }


        // Helper Functions

        public void InitializeCBO()
        {
            cboSex.Items.Add("All");
            cboSex.Items.Add("Male");
            cboSex.Items.Add("Female");
        }

        // WinForm Functions
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Welcome {username}";
            InitializeCBO();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dg != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKeyword.Text) || string.IsNullOrWhiteSpace(cboSex.Text)) 
            {
                MessageBox.Show("Input fields must have a value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _db.search_by_keyword(txtKeyword.Text, cboSex.Text, grdData);
        }

        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sex = cboSex.Text;

            if (cboSex.SelectedIndex !=  -1)
            {
                if (sex.Equals("All"))
                {
                    _db.search_by_all(grdData);
                }
                else
                {
                    _db.search_by_sex(sex, grdData);
                }
            }

           

        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            _db.search_by_text_changed(txtKeyword.Text, cboSex.Text, grdData);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd(_db);
            DialogResult res = frmAdd.ShowDialog();
            //this.Hide();
            //if (res == DialogResult.)
            //{
            //    this.Show();
            //}
        }
    }
}
