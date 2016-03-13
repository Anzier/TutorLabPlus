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
            // ACCESS DATABASE HERE AND RETRIEVE DATA FOR TUTOR SCHEDULES
            //////////////////////////////////////////////////////////////////////
            // LOGAN - JAKE                                                     //
            // THIS IS WHERE YOU INSERT THE CODE TO CONNECT TO THE DATABASE     //
            //////////////////////////////////////////////////////////////////////
            //Initialize entries in the grid to show [M] [T] [W] [R] [F] [S] [S], as well as each name and the times inside each cell
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
