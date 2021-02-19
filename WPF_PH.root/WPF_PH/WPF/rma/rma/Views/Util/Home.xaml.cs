using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace rma.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            try
            {
                if (ConfigurationManager.AppSettings["PreReleaseMode"] != null)
                    if (ConfigurationManager.AppSettings["PreReleaseMode"].Equals("1"))
                        SplashMessage.Visibility = Visibility.Visible;
            }
            catch
            {
            }
        }
    }
}