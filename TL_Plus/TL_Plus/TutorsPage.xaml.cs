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
    /// Interaction logic for TutorsPage.xaml
    /// </summary>
    public partial class TutorsPage : Window
    {


        public TutorsPage()
        {
            InitializeComponent();

            List<string> MFWTimes = new List<string> { "8:25-10:25", "10:25-12:25", "12:25-2:25", "2:25-4:25", "4:25-6:25", "6:25-9:00" };
            List<string> TRTimes = new List<string> { "8:25-10:25", "10:30-11:55", "11:55-1:25", "1:25-2:55", "2:55-4:25", "4:25-6:25", "6:25-9:00" };
            string[,] people = new string[3, 6];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    people[i, j] = "person "+(j+i);
                }
            }
            List<Tutor> Tutors = new List<Tutor>();
            Tutors.Add(new Tutor() { NTG = false, Name = "John Doe" });
            Tutors.Add(new Tutor() { NTG = false, Name = "Jane Doe" });
            Tutors.Add(new Tutor() { NTG = false, Name = "Sammy Doe" });

            for (int i = 0; i < 6; i++)
            {
                var data = new Test { day1 = people[0,i], day2 = "Tue", day3 = "Wed", day4 = "Thu", day5 = "Fri", day6 = "Sat" };
            DataGridTest.Items.Add(data);
            }


            //dgUsers.ItemsSource = Tutors;
            
            // ACCESS DATABASE HERE AND RETRIEVE DATA FOR TUTOR SCHEDULES
            //////////////////////////////////////////////////////////////////////
            // LOGAN - JAKE                                                     //
            // THIS IS WHERE YOU INSERT THE CODE TO CONNECT TO THE DATABASE     //
            //////////////////////////////////////////////////////////////////////
            //Initialize entries in the grid to show [M] [T] [W] [R] [F] [S] [S], as well as each name and the times inside each cell
        }
        public class Test
        {
            public string day1 { get; set; }
            public string day2 { get; set; }
            public string day3 { get; set; }
            public string day4 { get; set; }
            public string day5 { get; set; }
            public string day6 { get; set; }
        }
        public class Tutor
        {               // Need To Give (shift)
            public bool NTG { get; set; }
            public string Name { get; set; }
        }

        private void Action_Save(object sender, RoutedEventArgs e)
        {
            // ACCESS DATABASE HERE AND WRITE CHANGES
            //////////////////////////////////////////////////////////////////////
            // LOGAN - JAKE                                                     //
            // THIS IS WHERE YOU INSERT THE CODE TO CONNECT TO THE DATABASE     //
            //////////////////////////////////////////////////////////////////////

            // if(upload.wasSuccessful()){   <- pseudocode to verify it worked correctly
            MessageBox.Show("Your entry has been saved into the system");
        }
        private void Action_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
