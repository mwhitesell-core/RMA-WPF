using System.Windows;
using System.Windows.Input;

namespace rma.Views
{
    /// <summary>
    /// Interaction logic for AccessDenied.xaml
    /// </summary>
    public partial class AccessDenied : Window
    {
        public string Message;

        public AccessDenied()
        {
            InitializeComponent();
            Loaded += AccessDeniedLoaded;
            Unloaded += AccessDeniedUnloaded;
        }

        private void AccessDeniedLoaded(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = Message;
            KeyUp += AccessDeniedKeyUp;
        }

        private void AccessDeniedKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                Close();
            }
        }

        private void AccessDeniedUnloaded(object sender, RoutedEventArgs e)
        {
            KeyUp -= AccessDeniedKeyUp;
            Loaded -= AccessDeniedLoaded;
            Unloaded -= AccessDeniedUnloaded;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}