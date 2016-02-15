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


        public StudentCheckIn(List<string> courseList)// constructor, initializes the Gui, loads the combobox with the list of classes
        {
            courses = courseList;

            InitializeComponent();

             for (int i = 0; i < courses.Count; i++)
             {
            SignInComboBox.Items.Add(courses[i]);
            //SignInComboBox.Items.Add(myvar);
             }
             SignInComboBox.SelectedIndex = 0;
        }

        private void Action_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Action_Check_In(object sender, RoutedEventArgs e)
        {// THIS FUNCTION IS CALLED WHEN THE STUDENT CLICKS THE CHECK IN BUTTON ON THE POP UP PAGE

            // TO DO: SAVE THE DATA ENTERED IN THE FIELDS INTO THESE VARIABLES - CREATE OBJECT INITIALIZED WITH THESE VALUES

            string _ANum = SignInANum.Text; 
            string _Class = (SignInComboBox.SelectedItem).ToString();// parse selecteditem object into string
            if (_Class == "") { _Class = "-None Selected-"; }
            string _problem = SignInProblem.Text;
           MainWindow.writeCheckInData(_ANum,_Class, _problem);

           this.Close();

        }

    }
}
