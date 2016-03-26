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
        public bool continuing;
        public TutorCompetion(StudentSession inc_app)// incomplete application
        {
            continuing = false;// is set to true on submit, otherwise MainWindow will not try to process the empty return
            publicObject = inc_app;
            InitializeComponent();


            t_teacher.Text = inc_app.getTeacher();
            t_name.Text = inc_app.getName();
            t_class.Text = inc_app.getClass();
            t_SignInProblem.Text = inc_app.GetStudentDescription();
            t_tutorFeedback.Text = "";
            t_startTime.Text = inc_app.GetStartTime(); ;
            t_endTime.Text = DateTime.Now.ToString();
            inc_app.SetEndTime(t_endTime.Text);
        }
        private void Action_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Action_Submit(object sender, RoutedEventArgs e)
        {
            
            string verifyUntouched = "Mention anything the student did not understand. What you worked through and accomplished together. What areas the student needs more strengthening in.";
            if (t_tutorFeedback.Text.Length < 20 || t_tutorFeedback.Text == "" || t_tutorFeedback.Text == verifyUntouched) {
                MessageBox.Show("It is essential that we gain personalized data,\nPlease enter a unique description "); return;
            }
           

            publicObject.setTeacher(t_teacher.Text);
            publicObject.setClass(t_class.Text);
            publicObject.SetEndTime(t_endTime.Text);
            publicObject.SetName(t_name.Text);
            publicObject.SetStartTime(t_startTime.Text);
            publicObject.SetStudentDescription(t_SignInProblem.Text);
            publicObject.SetTutorDescription(t_tutorFeedback.Text);


              //MessageBox.Show("'Data Theoretically Sent to DB'\n" + "name: " + publicObject.getName() +"\n class: " 
              // + publicObject.getClass()+"\n Student problem:" + publicObject.GetStudentDescription() 
              // + "\n tutor desc: " + publicObject.GetTutorDescription() + "\n start time: " 
              //  + publicObject.GetStartTime() + "\n end Time: " + publicObject.GetEndTime()
              //  + "\n Name: (not yet handled)");

            string name = "nanem";
            name = name.ToUpper();
            MySQLConnect connect = new MySQLConnect() ;
            connect.Insert(publicObject.getName().ToUpper(), publicObject.getClass().ToUpper(), publicObject.getTeacher().ToUpper(),
                publicObject.GetStartTime().ToUpper(), publicObject.GetEndTime().ToUpper(), publicObject.GetStudentDescription().ToUpper(),
                publicObject.GetTutorDescription().ToUpper());// ALL CONTENT STORED IN THE DATABASE WILL BE CONVERTED TO UPPERCASE STANDARDIZATION


            continuing = true;
            this.Close();

        }
       // private void TRTC(object sender, TextChangedEventArgs e)
       // {
       //     if (t_tutorFeedback.Text.Length < 20) { MessageBox.Show("Be More Elaborate!"); }
       // }
    }
}
