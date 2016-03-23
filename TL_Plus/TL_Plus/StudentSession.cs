using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TL_Plus
{
   public class StudentSession
    {
        //StudentSession(){
        //    Class = "";
        //    ANumber = "";
        //    Name = "";
        //    S_ProbDesc = "";
        //    T_ProbDesc = "";
        //    startTime = 0;
        //    endTime = 0;
        //}
       public StudentSession(string _ANum, string _Class, string _problem)
        {
            active = true;
            Class = _Class;
            ANumber = _ANum;
            Name = "";// awaiting the database to return name
            S_ProbDesc = _problem;
            T_ProbDesc = "";// awaiting final submission to be saved
            startTime = DateTime.Now.ToString();
            endTime = "-1";// to be written on final submission
            Teacher = "Dan Watson";
        }


       // ACTIVITY
       public void SetActivity(bool A) {
           active = A;
       }

       public bool Active() {// used when determining if a user is still active
           return active;
       }
       // START TIME
       public void SetStartTime(string time)
       {
           startTime = time;
       }
       public string GetStartTime()
       {
           return startTime;
       }
       // END TIME
       public void SetEndTime(string time)
        {
            endTime = time;
        }
       public string GetEndTime()
        {
            return endTime;
        }
       // NAME
       public  void SetName(string name)
        {
            Name = name;
        }  
       public string getName()
        {
            return Name;// CHANGE THIS BACK TO NAME ONCE WE FINALIZE DATABASE
        }
       // A NUMBER
       public void SetANum(string name)
       {
           ANumber = name;
       }
       public string getANum()
       {
           return ANumber;
       }
       // TUTOR PROBLEM DESCRIPTION
       public void SetTutorDescription(string desc)
       {
           T_ProbDesc = desc;
       }
       public string GetTutorDescription()
       {
           return T_ProbDesc;
       }
       // STUDENT PROBLEM DESCRIPTION
       public void SetStudentDescription(string desc)
       {
           S_ProbDesc = desc;
       }
       public string GetStudentDescription()
       {
           return S_ProbDesc;
       }
       // CLASS
       public string getClass()
       {
           return Class;
       }
       public void setClass(string clas)
       {
           Class = clas;
       }
       // CLASS
       public string getTeacher()
       {
           return Teacher;
       }
       public void setTeacher(string teacher)
       {
           Teacher = teacher;
       }

        bool active;
        string startTime;
        string endTime;
        string Class;
        string ANumber;
        string Name;
        string S_ProbDesc;//students problem description (may need better variable that holds more data)
        string T_ProbDesc;// tutors description of the problem at the end.
        string Teacher;

    }
}
