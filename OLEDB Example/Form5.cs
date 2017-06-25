using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OLEDB_Example
{
    public partial class Form5 : Form
    {
        private MySqlConnection mysqlConn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Form5()
        {
            InitializeComponent();
            server = "localhost";
            database = "polair";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            mysqlConn = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                mysqlConn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator.");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again.");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                mysqlConn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(login(textBoxUsername.Text, textBoxPassword.Text))
            {
                user.loggedIn = true;
                user.account = textBoxUsername.Text;
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            else
            {
                label3.Visible = true;
            }
        }

        private bool login(string username, string password)
        {
            if (this.OpenConnection())
            {
                MySqlCommand mysqlCmd = new MySqlCommand(
                    "SELECT * FROM users WHERE username = '" + username + "' AND password  = '" + password + "'", mysqlConn);
                if (!string.IsNullOrEmpty((mysqlCmd.ExecuteScalar() + "")))
                {
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    this.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
