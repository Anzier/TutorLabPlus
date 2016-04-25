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
            server = "se3450.cl7tq4md0ynb.us-west-1.rds.amazonaws.com";
            database = "se3450";
            uid = "Mach5";
            password = "DarthVader";

            /*server = "localhost";
            database = "cs3450";
            uid = "root";
            password = "Pass";*/
            string connectString;
            connectString = "host=" + server + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + password + ";";
            connection = new MySqlConnection(connectString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
              //  MessageBox.Show("Connection Opened");  //Debug to show the connection opens
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
        //When a problem had an apostrophe, it was messing up the sql string beause it needed to be formatted as a ''
        public string fixApostrophe(string s)
        {
            return s.Replace("'", "''");
        }
        public void Insert(string name, string course, string teacher, string sTime, string eTime, string sProb, string tProb)
        {
            //string studentInfo = "INSERT INTO studentSessions(sName) VALUES('Test')";
            string studentInfo = "INSERT INTO studentSessions(sName, class, teacher, timeIn, timeOut, sComment, tComment) VALUES ("
                + "'" + name
                + "','" + course
                + "','" + teacher
                + "','" + sTime
                + "',' " + eTime
                + "','" + fixApostrophe(sProb)
                + "','" + fixApostrophe(tProb)
                + "')";
            if (this.OpenConnection() == true)
            {
               // MessageBox.Show("Connection Opened");
                MySqlCommand cmd = new MySqlCommand(studentInfo, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            else
            {
                MessageBox.Show("Not Connected, can't use the force Vader");
            }
        }
        public List<string> getClasses(){
            List<string> tempList = new List<string>();
            tempList.Add("-None Selected-");
            string query = "select cName from classList";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    for(int i = 0; i< mdr.FieldCount; i++){
                        string course;
                        course = mdr.GetString(i);
                        tempList.Add(course);
                    }
                }
            }
            CloseConnection();
            return tempList;
        }
        
        //Helper Function for testing getting a list of IDs
        public List<string> getTeachersHelper(string course)
        {
            List<string> courseIDs = new List<string>();
            string courseQuery = "select * from classList where cName='" + course + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(courseQuery, connection);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    if (!(mdr["tID1"].Equals(System.DBNull.Value)))
                    {
                        courseIDs.Add(mdr.GetString("tID1"));
                    }
                    if (!(mdr["tID2"].Equals(System.DBNull.Value)))
                    {
                        courseIDs.Add(mdr.GetString("tID2"));
                    }
                    if (!(mdr["tID3"].Equals(System.DBNull.Value)))
                    {
                        courseIDs.Add(mdr.GetString("tID3"));
                    }
                    if (!(mdr["tID4"].Equals(System.DBNull.Value)))
                    {
                        courseIDs.Add(mdr.GetString("tID4"));
                    }
                }
            }
            CloseConnection();
            return courseIDs;
        }


        //Returns a list of teachers currently in the DB.
        public List<string> getTeachers(List<string> ids)
        {
            string querySelection="";
            for (int i = 0; i < ids.Count; ++i)
            {
                querySelection += " tID =" + ids[i] + "";
                if (i != (ids.Count - 1))
                {
                    querySelection += " or ";
                }
            }
            List<string> tempList = new List<string>();
            string query = "select tName from teacherList where" + querySelection;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    for (int i = 0; i < mdr.FieldCount; i++)
                    {
                        string teacher;
                        teacher = mdr.GetString(i);
                        tempList.Add(teacher);
                    }
                }
            }
            CloseConnection();
            return tempList;
        }
    }
}
