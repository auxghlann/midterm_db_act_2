using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace midterm_db_act_2
{
    public class Database
    {

        private string conn_str;
        private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataReader reader;
        private OleDbDataAdapter adapter;

        public Database()
        {
            this.conn_str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\khest\\Documents\\C#\\app_dev\\midterm_db_act_2\\resources\\DB-ACT3.mdb";
            this.connection = new OleDbConnection(this.conn_str);
        }

        public OleDbConnection Connection { get { return this.connection; } }

        public void OpenConnection()
        {
            if (this.Connection.State != System.Data.ConnectionState.Open)
            {
                this.Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (this.Connection.State == System.Data.ConnectionState.Open)
            {
                this.Connection.Close();
            }
        }


        // login query function

        public string login(string username, string password)
        {
            string query = "SELECT username, password from account where username=? and password=?";
            //string username_result = "";

            OpenConnection();

            using (OleDbCommand command = new OleDbCommand(query, this.Connection))
            {
                command.Parameters.AddWithValue("?", username);
                command.Parameters.AddWithValue("?", password);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        // Extract the username from the reader
                        return reader["username"].ToString();
                        
                    }
                    else
                    {
                        CloseConnection();
                        return null;
                    }
                    
                }
            }


        }


        public void search_by_keyword(string keyword, string sex, DataGridView grdData)
        {
            string query = "SELECT * from employee WHERE name=? and sex=?";

            OpenConnection();

            using (command = new OleDbCommand(query, this.Connection))
            {

                command.Parameters.AddWithValue("?", keyword);
                command.Parameters.AddWithValue("?", sex);
                DataTable dt = new DataTable();

                using (adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(dt);

                    grdData.DataSource = dt;

                    CloseConnection();
                }
            }
        }

        
    }
}
