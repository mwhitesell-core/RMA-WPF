using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.IO.Compression;
using System.Resources;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace RMA_Install
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class Complete : UserControl
    {
        public Complete()
        {
            InitializeComponent();
           
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();

        }

    }
}
