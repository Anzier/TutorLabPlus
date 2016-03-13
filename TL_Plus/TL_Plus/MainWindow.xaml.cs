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
using System.Drawing;// to attempt to render new background colors on listbox
using System.ComponentModel;// for INotifypropertychanged
using System.Globalization;// for time
using Microsoft.VisualBasic;// for messagebox input
namespace TL_Plus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

       // public event PropertyChangedEventHandler INotifyPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        static List<string> courseList;
        static List<StudentSession> ActiveList;// will hold all the students actively in the tutor lab
        int NUM_STUDENTS_IN_LAB;
        bool checkin; // boolean determines if "check in" button should route to check in or check out: true = checkin, false = checkout;

        public MainWindow()// render the main window
        {
            checkin = true;
            ActiveList = new List<StudentSession>();
            courseList = new List<string> {"-None Selected-","CS1", "CS2", "CS3", "Software Dev", "Java", "Computer Architecture", "Web Development", "Operating Systems","Information storage" };

            NUM_STUDENTS_IN_LAB = 0;
            InitializeComponent();
        }

        //ACTION EVENTS
        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)// allows dragging the window around
        {
            StudentsInLab.UnselectAll();
            this.DragMove();
        }
        private void Button_UPLOAD(object sender, MouseButtonEventArgs e)// allows dragging the window around
        {
          // INSERT CODE TO CONNECT TO DATABASE
        }
        private void MinimizeButton_MinimizeLeftClick(object sender, MouseButtonEventArgs e)
        {
            StudentsInLab.UnselectAll();
            WindowState = WindowState.Minimized;
        }
        private void closeButton_CloseLeftClick(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        void OnSelected(object sender, System.EventArgs e)// when a name is selected from the listbox
        {
            
            int index = StudentsInLab.SelectedIndex;
           // MessageBox.Show(index.ToString() + " listbox index");
           // MessageBox.Show(ActiveList[index].returnName().ToString() + " activelist at that location");


            if (index != -1) { 
                    if (ActiveList[index].Active() == true)// active user selecting their name
                    { 
                        checkInOut.Content = "Check Out";
                        checkin = false;
                    }
                    else{// inactive user selected by tutor
                    // TO DO:  SET UP TUTOR BUTTON FOR FINISHING STUDENT APPLICATION
                    }
            } 
            else{// list was de-selected, reset button to default
                checkInOut.Content = "Check In";
                checkin = true;
            }


        }
        private void check_Out() { 
        // todo: remove student from list, put in new list. 0R change label

            int index = StudentsInLab.SelectedIndex;
            ActiveList[index].SetActivity(false);// activeLists index should be parallel with StudentsInLab, if not, attempt a search by the given name
            //StudentsInLab.SelectedItem.Equals("-");
            //StudentsInLab.Items[index].BackColor = Color.Green;
            //NotifyPropertyChanged();
            //NotifyPropertyChange("checkin");

            StudentsInLab.Items.RemoveAt(index);
            StudentsInLab.Items.Insert(index, ActiveList[index].getName()+"[Checked Out]");
            StudentsInLab.SelectedIndex = index;
            //NotifyPropertyChanged("checkin"); 
            checkInOut.Content = "Check In";
            checkin = true;
            StudentsInLab.UnselectAll();// deselect the item
        }


        private void AddStudent(object sender, MouseButtonEventArgs e)// check in button on the main page
        {
            if (checkin == false) { check_Out(); return; } // if the button is displaying "Check Out" call that function instead


            // create a new window displaying sign in info
            StudentCheckIn newUser = new StudentCheckIn(courseList);// newuser is an object instance of the check in POPUP WINDOW
            newUser.Owner = this;
            newUser.ShowDialog();
            //Studentcheckin calls writeCheckInData

            int LSA= ActiveList.Count;//index of the last student added in the array
            if (LSA <= 0)
            {
                StudentsInLab.Items.Add(ActiveList[LSA].getName());
            }
            else { 
             StudentsInLab.Items.Add(ActiveList[LSA - 1].getName() /*+ "                "+ ActiveList[LSA - 1].returnClass()*/);
            }
           
            NUM_STUDENTS_IN_LAB++;
            StudentInLabLabel.Text = "There are " + NUM_STUDENTS_IN_LAB + " students in the lab";
        }

        public static void writeCheckInData(string anum, string Class, string problem)
        {
            StudentSession newUser = new StudentSession(anum, Class, problem);
            ActiveList.Add(newUser);
            
        }

        private void TutorControls(object sender, MouseButtonEventArgs e)
        {
            if (checkin == true && StudentsInLab.SelectedIndex != -1) {// will only activate if a user is selected, but they are not checked in
                TutorCompetion endSession = new TutorCompetion(ActiveList[StudentsInLab.SelectedIndex]);
                endSession.Owner = this;
                endSession.ShowDialog();

                int index = StudentsInLab.SelectedIndex;
                StudentsInLab.Items.RemoveAt(index);
                StudentsInLab.Items.Insert(index, ActiveList[index].getName() + "[Completed]");

                NUM_STUDENTS_IN_LAB--;
                StudentInLabLabel.Text = "There are " + NUM_STUDENTS_IN_LAB + " students in the lab";
                StudentsInLab.UnselectAll();
                return; }

            //MessageBox.Show("Sorry Wilfred, The tutor Access isn't complete yet");
            TutorVerification Tlogin = new TutorVerification();
            Tlogin.Owner = this;
            Tlogin.ShowDialog();
            return;

        }



    }
}
