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
    /// Interaction logic for TutorAccept.xaml
    /// </summary>
    public partial class TutorAccept : Window
    {
        public bool submitted;
        public TutorShift shift;
        public TutorAccept(TutorShift In)
        {
            InitializeComponent();
            submitted = false;
            shift = new TutorShift(In.initiatorName, In.start, In.end, In.date, In.givingshift);// Copy over passed in data
            date.Text = In.date;
            starttime.Text = In.start;
            endtime.Text = In.end;
            giverName.Text = In.initiatorName;
            if (In.givingshift == true)
            {
                t.Content = "You are assuming responsibility for taking this shift...";
            }
            else { t.Content = "You are responsible for this shift until it is covered..."; }

        }


        private void takeShift(object sender, MouseButtonEventArgs e)
        {
            if (auth.IsChecked != true)
            {
                MessageBox.Show("You must accept responsibility in order to take this shift.");
            }
            else
            {
                shift.accepted = true;
                shift.acceptorName = acceptor.Text;
                submitted = true;
                this.Close();
            }


        }

        private void cancel(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}