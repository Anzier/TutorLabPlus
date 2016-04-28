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

namespace TL_Plus
{
    /// <summary>
    /// Interaction logic for StudentCheckIn.xaml
    /// </summary>
    public partial class StudentCheckIn : Window
    {
        static List<string> courses;// predetermined list of classes offered at USU
        static List<string> teachersIDs;// predetermined list of Teachers DB IDs at USU
        static List<string> teachers;// predetermined list of Teachers at USU
        public bool continuing;
        static string c;

        public StudentCheckIn(List<string> courseList)// constructor, initializes the Gui, loads the combobox with the list of classes
        {
            InitializeComponent();
            continuing = false;
           TeacherCB.Visibility = Visibility.Hidden;

             MySQLConnect connectCourse = new MySQLConnect();//opens a new connection to the DB
             courses = connectCourse.getClasses(); // Returns a list of the courses in the database as a list of strings.


             for (int i = 0; i < courses.Count; i++)
             {
                SignInComboBox.Items.Add(courses[i]);
                //TeacherCB.Items.Add("Teacher "+i);// HERE IS WHERE I WE ARE POPULATING THE TEACHER LIST FOR THE DROPDOWN BOX
             }
             //for (int i = 0; i < teachers.Count; i++)
             //{
             //    TeacherCB.Items.Add(teachers[i]);
             //}
             //TeacherCB.SelectedIndex = 0;
             SignInComboBox.SelectedIndex = 0;
        }

        private void Action_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Action_Check_In(object sender, RoutedEventArgs e)
        {// THIS FUNCTION IS CALLED WHEN THE STUDENT CLICKS THE CHECK IN BUTTON ON THE POP UP PAGE
            continuing = true;
            

            string Name = SignInName.Text; 
            string _Class = (SignInComboBox.SelectedItem).ToString();// parse selecteditem object into string
            if (_Class == "") { _Class = "-None Selected-"; }
            string _problem = SignInProblem.Text;
            string teacher = (TeacherCB.SelectedItem).ToString();
           MainWindow.writeCheckInData(Name,_Class, _problem, teacher);
           this.Close();

        }


        private void SignInComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (SignInComboBox.SelectedItem).ToString();
            if (SignInComboBox.SelectedItem.ToString() != "-None Selected-")
            {
                
                MySQLConnect connectTeachers = new MySQLConnect();//opens a new connection to the DB
                teachersIDs = connectTeachers.getTeachersHelper(c);
                MySQLConnect connectTeachers2 = new MySQLConnect();//opens a new connection to the DB
                teachers = connectTeachers2.getTeachers(teachersIDs); // Returns a list of the teachers in the database as a list of strings.
                TeacherCB.Items.Clear();
                
                for (int i = 0; i < teachers.Count; i++)
                {
                    TeacherCB.Items.Add(teachers[i]);
                }
                TeacherCB.SelectedIndex = 0;


                TeacherCB.Visibility = Visibility.Visible;//

            }
        }



    }
}
