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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TL_Plus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        static List<string> courseList;
        static List<StudentSession> ActiveList;// will hold all the students actively in the tutor lab
        int NUM_STUDENTS_IN_LAB;

        public MainWindow()// render the main window
        {
            ActiveList = new List<StudentSession>();
            courseList = new List<string> {"-None Selected-","CS1", "CS2", "CS3", "Software Dev", "Java", "Computer Architecture", "Web Development", "Operating Systems","Information storage" };

            NUM_STUDENTS_IN_LAB = 0;
            InitializeComponent();
        }

        //ACTION EVENTS
        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)// allows dragging the window around
        {
            this.DragMove();
        }
        private void Button_UPLOAD(object sender, MouseButtonEventArgs e)// allows dragging the window around
        {
          // INSERT CODE TO CONNECT TO DATABASE
        }
        private void MinimizeButton_MinimizeLeftClick(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void closeButton_CloseLeftClick(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddStudent(object sender, MouseButtonEventArgs e)// check in button on the main page
        {

            //StudentsInLab.Items.Add("student number " + NUM_STUDENTS_IN_LAB);// THIS LINE WILL BE REPLACED WHEN CHECK IN FORM IS COMPLETE
            //NUM_STUDENTS_IN_LAB++;
            //StudentInLabLabel.Text = "There are "+ NUM_STUDENTS_IN_LAB + " students in the lab";


            // create a new window displaying sign in info
            StudentCheckIn newUser = new StudentCheckIn(courseList);// newuser is an object instance of the check in POPUP WINDOW
            newUser.Owner = this;
            newUser.ShowDialog();
            //
            //Studentcheckin calls writeCheckInData
            //

            int LSA= ActiveList.Count;//index of the last student added in the array
            StudentsInLab.Items.Add(ActiveList[LSA - 1].returnName() /*+ "                "+ ActiveList[LSA - 1].returnClass()*/);// commented portion would display the class they are in
            NUM_STUDENTS_IN_LAB++;
            StudentInLabLabel.Text = "There are " + NUM_STUDENTS_IN_LAB + " students in the lab";
        }
        public static void writeCheckInData(string anum, string Class, string problem)
        {
            StudentSession newUser = new StudentSession(anum, Class, problem);
            ActiveList.Add(newUser);
            
        }




    }
}
