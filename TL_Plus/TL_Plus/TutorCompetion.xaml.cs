using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;

namespace TL_Plus
{
    /// <summary>
    /// Interaction logic for TutorCompetion.xaml
    /// </summary>
    public partial class TutorCompetion : Window
    {
        StudentSession publicObject;

        public TutorCompetion(StudentSession inc_app)// incomplete application
        {
            publicObject = inc_app;
            InitializeComponent();


            // COMMENTED VARIABLES ARE THOSE THAT SHOULD HAVE BEEN WRITTEN PRIOR TO THIS STAGE
            t_ANum.Text = inc_app.getANum();
            t_class.Text = inc_app.getClass();
            t_SignInProblem.Text = inc_app.GetStudentDescription();
            //t_tutorFeedback.Text = "";
            //t_name.Text;
            t_startTime.Text = inc_app.GetStartTime(); ;
            t_endTime.Text = DateTime.Now.ToString();
        }
        /*
         string startTime;
        string endTime;
        string Class;
        string ANumber;
        string Name;
        string S_ProbDesc;//students problem description (may need better variable that holds more data)
        string T_ProbDesc;// tutors description of the problem at the end.
         
         */
        private void Action_Cancel(object sender, RoutedEventArgs e)//@@@@@@@@@@@ HANDLE BUG HERE: CANCELING DOES NOTHING TO STOP THE PROGRAM FROM READING IN A BLANK OBJECT ANYWAYS AND ENTERING A DEFAULT STUDENT
        {
            this.Close();
        }

        private void Action_Submit(object sender, RoutedEventArgs e)
        {
            string verifyUntouched = "Mention anything the student did not understand. What you worked through and accomplished together. What areas the student needs more strengthening in.";
            if (t_tutorFeedback.Text.Length < 20 || t_tutorFeedback.Text == "" || t_tutorFeedback.Text == verifyUntouched) {
                MessageBox.Show("Be More Elaborate in your description!\n Access Denied!"); return;
            }
            // TO DO: SAVE THE DATA ENTERED IN THE FIELDS INTO THESE VARIABLES - CREATE OBJECT INITIALIZED WITH THESE VALUES

            publicObject.SetANum(t_ANum.Text);
            publicObject.setClass(t_class.Text);
            publicObject.SetEndTime(t_endTime.Text);
            publicObject.SetName(t_name.Text);
            publicObject.SetStartTime(t_startTime.Text);
            publicObject.SetStudentDescription(t_SignInProblem.Text);
            publicObject.SetTutorDescription(t_tutorFeedback.Text);
            //////////////////////////////////////////////////////////////////////
            // LOGAN - JAKE                                                     //
            // THIS IS WHERE YOU INSERT THE CODE TO CONNECT TO THE DATABASE     //
            //////////////////////////////////////////////////////////////////////
            MessageBox.Show("'Data Theoretically Sent to DB'\n" + "A#: " + publicObject.getANum() +"\n class: " 
                + publicObject.getClass()+"\n Student problem:" + publicObject.GetStudentDescription() 
                + "\n tutor desc: " + publicObject.GetTutorDescription() + "\n start time: " 
                + publicObject.GetStartTime() + "\n end Time: " + publicObject.GetEndTime()
                + "\n Name: (not yet handled)");

            MySQLConnect connect = new MySQLConnect() ;
            connect.Insert(publicObject.getName(), publicObject.getClass(), publicObject.getTeacher(), publicObject.GetStartTime(),
                publicObject.GetEndTime(), publicObject.GetStudentDescription(), publicObject.GetTutorDescription());

            //MainWindow.writeCheckInData(_ANum, _Class, _problem);
            // TO DO: Call a function that removes the user after this within the main window
            // TO DO: IDEA - send object by reference, return boolean to indicate if they canceled or submitted application
            this.Close();

        }
       // private void TRTC(object sender, TextChangedEventArgs e)
       // {
       //     if (t_tutorFeedback.Text.Length < 20) { MessageBox.Show("Be More Elaborate!"); }
       // }
    }
}
