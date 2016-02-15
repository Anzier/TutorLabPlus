using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Class = _Class;
            ANumber = _ANum;
            Name = "";// awaiting the database to return name
            S_ProbDesc = _problem;
            T_ProbDesc = "";// awaiting final submission to be saved
            startTime = -1;
            endTime = -1;// to be written on final submission
        }
        void SetStartTime(double time)
        {
            startTime = time;
        }
        void SetEndTime(double time)
        {
            endTime = time;
        }
        void SetName(string name)
        {
            Name = name;
        }
        void SetTutorDescription(string desc)
        {
            T_ProbDesc = desc;
        }
       public string returnName()//THIS FUNCTION IS ONLY FOR TESTING UNTIL WE CAN ACCESS THE DATABASE TO RETRIEVE THE NAME
        {
            return ANumber;
        }
       public string returnClass()//THIS FUNCTION IS ONLY FOR TESTING UNTIL WE CAN ACCESS THE DATABASE TO RETRIEVE THE NAME
       {
           return Class;
       }

        double startTime;
        double endTime;

        string Class;
        string ANumber;
        string Name;
        string S_ProbDesc;//students problem description (may need better variable that holds more data)
        string T_ProbDesc;// tutors description of the problem at the end.

    }
}
