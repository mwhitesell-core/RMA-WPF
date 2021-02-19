using Core.Windows.UI.Core.Windows.UI;
using System;
using System.Windows;
using System.Windows.Threading;

namespace rma.Views
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Login : Window
    {
        private DispatcherTimer _dt;
        public Login()
        {
            InitializeComponent();
            Loaded += LoginLoaded;
            Unloaded += LoginUnloaded;
        }

        private void LoginUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= LoginLoaded;
            Unloaded -= LoginUnloaded;
        }

        private void LoginLoaded(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.UserName = Environment.UserDomainName + "\\" + Environment.UserName;
            App.ApplicationUserLoaded();

            _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 50) };
            _dt.Tick += logintime;
            _dt.Start();
        }

        private void logintime(object sender, EventArgs e)
        {
            var dt = (DispatcherTimer)sender;
            if (dt != null)
                dt.Stop();
            dt = null;

          
            Close();
        }
    }
}