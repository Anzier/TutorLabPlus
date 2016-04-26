
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
    /// Interaction logic for TutorRequest.xaml
    /// </summary>
    public partial class TutorRequest : Window
    {
        public TutorShift newShift;
        public TutorRequest()
        {
            InitializeComponent();
        }

        private void Gshift(object sender, RoutedEventArgs e)
        {
            if (Takingshift != null)
            {
                Takingshift = null;
            }
        }

        private void Tshift(object sender, RoutedEventArgs e)
        {
            if (Givingshift != null)
            {
                Givingshift = null;
            }
        }

        private void submit(object sender, MouseButtonEventArgs e)
        {
            if (Givingshift != null || Takingshift != null)
            {
                bool giving;// local variable to pass into constructor
                if (Givingshift != null) { giving = true; } else { giving = false; }
                // creating dateTime which stores 
                newShift = new TutorShift(TReqName.Text, startTime.Text, endTime.Text, shiftDate.Text, giving);
                this.Close();
            }
            else { MessageBox.Show("You must select whether you are giving or taking a shift."); }


        }

        private void cancel(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}