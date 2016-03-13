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
    /// Interaction logic for TutorVerification.xaml

    public partial class TutorVerification : Window
    {
        public TutorVerification()
        {
            InitializeComponent();
        }
        private void Action_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Action_Continue(object sender, RoutedEventArgs e)// connected to continue button, will launch tutor window if passowrd matched
        {
            if (password.Text == "domyhomework")
            {
                // launch tutor window
                TutorsPage Tpage = new TutorsPage();
                WindowState = WindowState.Minimized;// next best thing to closing it before were done executing code.
                Tpage.Owner = this;// focuses on newly opened page
                Tpage.ShowDialog();
                this.Close();
                
            }
            else {
                MessageBox.Show("Sorry, you're not allowed in here");
            }
        }
        private void InstaAccess(object sender, TextChangedEventArgs e)// this checks any time the text in the box has been changed.
        {
            if (password.Text == "vader")
            {
                TutorsPage Tpage = new TutorsPage();
                WindowState = WindowState.Minimized;
                Tpage.Owner = this;
                Tpage.ShowDialog();
                this.Close();
            }
        }
    }
}
