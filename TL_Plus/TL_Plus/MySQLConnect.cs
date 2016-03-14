using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
//using System.Windows.Forms.MessageBox;
using System.Windows;



namespace TL_Plus
{
    class MySQLConnect
    {
        private string server, database, uid, password;
        private MySqlConnection connection;

        public MySQLConnect()
        {
            Initialize();
        }

        private void Initialize()
        {

            server = "localhost";
            database = "cs3450";
            uid = "root";
            password = "Pass";
            string connectString;
            connectString = "Server=" + server + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + password + ";";
            connection = new MySqlConnection(connectString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
               // MessageBox.Show("Connection Opened");  Debug to show the connection opens
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Not Connected, can't use the force Vader");
                        break;
                    case 1045:
                        MessageBox.Show("Wrong Username or Password Anakin");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void Insert(string ANum, string sTime = null, string eTime = null, string course = null, string name=null, string sProb=null, string tProb=null)
        {
            string query = "INSERT INTO studentinfo(STime, ETime, Course, ANumber, Name, Student_Problem, Tutor_Problem) VALUES (" +
                "'" + sTime
                + "','" + eTime 
                + "','" + course 
                + "','" + ANum
                + "','" + name
                + "','" + sProb
                + "','" + tProb
                + "')";
            if(this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
