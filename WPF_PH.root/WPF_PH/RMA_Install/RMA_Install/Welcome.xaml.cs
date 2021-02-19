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
    public partial class Welcome : UserControl
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new License();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Start();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
