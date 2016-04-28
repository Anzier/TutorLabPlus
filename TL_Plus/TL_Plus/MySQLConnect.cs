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
        public List<string> getClasses()
        {
            List<string> tempList = new List<string>();
            tempList.Add("-None Selected-");
            string query = "select cName from classList";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    for (int i = 0; i < mdr.FieldCount; i++)
                    {
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
            string querySelection = "";
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

        /***************************************************************************************/
        /*                 Tutor Connections Section                                           */
        /***************************************************************************************/
        public void TutorInsert(string name, bool giveTake, string date, string sTime, string eTime)//, bool accept, string aName)
        {
            string tutorInfo = "INSERT INTO tutorShifts(tName, giveTake, date, sTime, eTime, accepted) VALUES("//, aName) VALUES ("
                + "'" + name
                + "'," + giveTake
                + ",'" + date
                + "','" + sTime
                + "','" + eTime
                + "'," + false
                //+ "','" + aName
                + ")";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(tutorInfo, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            else
            {
                MessageBox.Show("Not Connected, can't use the force Vader");
            }
        }
        //Creates a SQL command string for updating to shifts that have been accepted.
        public void TutorUpdate(string name, string date, string sTime, string eTime, bool accept, string aName)
        {
            string studentInfo = "UPDATE tutorShifts SET accepted="
                + "" + accept
                + ", aName='" + aName
                + "' WHERE tName='" + name
                + "' AND date='" + date
                + "' AND sTime='" + sTime
                + "' AND eTime='" + eTime
                + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(studentInfo, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
            else
            {
                MessageBox.Show("Not Connected, can't use the force Vader");
            }
        }
        public List<TutorShift> ShifsPopulate(string date, bool giveTake, bool accepted)
        {
            string listQuery="";
            List<TutorShift>  tempList = new List<TutorShift>();
            if(accepted==true){
                listQuery = "select * from tutorShifts where date >='" + date + "' and date < '12/31/2999' and accepted="+ accepted + ""; 
            }else{
                listQuery = "select * from tutorShifts where date >='" + date + "' and date < '12/31/2999' and giveTake=" + giveTake + ""; 
            }
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(listQuery, connection);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    string iN="", aN="", d="", sT="", eT="";
                    bool acc=false, gt=false;
                    if (!(mdr["tName"].Equals(System.DBNull.Value))){
                        iN=mdr.GetString("tName");
                    }
                    if (!(mdr["aName"].Equals(System.DBNull.Value))){
                        aN=mdr.GetString("aName");
                    }
                    if (!(mdr["date"].Equals(System.DBNull.Value))){
                        d=mdr.GetString("date");
                    }
                    if (!(mdr["sTime"].Equals(System.DBNull.Value))){
                        sT=mdr.GetString("sTime");
                    }
                    if (!(mdr["eTime"].Equals(System.DBNull.Value))){
                        eT=mdr.GetString("eTime");
                    }
                    if (!(mdr["giveTake"].Equals(System.DBNull.Value))){
                        gt=mdr.GetBoolean("giveTake");
                    }
                    if (!(mdr["accepted"].Equals(System.DBNull.Value))){
                        acc=mdr.GetBoolean("accepted");
                    }
                    TutorShift t = new TutorShift(iN, sT, eT, date, gt);
                    if(aN != "") t.acceptorName = aN;
                    if(acc != false) t.accepted = true;
                    tempList.Add(t);
                }
            }
            CloseConnection();
            return tempList;

        }

    }
}