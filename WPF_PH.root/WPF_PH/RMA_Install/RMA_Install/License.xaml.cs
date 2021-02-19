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

namespace RMA_Install
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class License : UserControl
    {
        public License()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Directories();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Welcome();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            radioButton.IsChecked = false;
            btnNext.IsEnabled = true;
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            radioButton1.IsChecked = false;
            btnNext.IsEnabled = false;
        }
    }
}
