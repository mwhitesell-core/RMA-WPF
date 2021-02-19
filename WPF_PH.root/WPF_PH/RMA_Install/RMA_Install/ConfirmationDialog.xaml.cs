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
using System.Windows.Threading;

namespace RMA_Install
{
    public enum DialogButtons
    {
        YesNo,
        OkCancel,
        Ok,
        None
    }

    /// <summary>
    /// Interaction logic for ConfirmationDialog.xaml
    /// </summary>
    public partial class ConfirmationDialog : Window
    {
        private readonly double _originalHeight;
        private readonly double _originalWidth;

        public ConfirmationDialog(string dialogTitle, string messageText, string additionalInformationText,
                                  DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            InitializeComponent();

            Loaded += ConfirmationDialogLoaded;
            Unloaded += ConfirmationDialogUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            Title = dialogTitle;
            MainMessageField.Text = messageText;
            AdditionalTextField.Text = additionalInformationText;

            if (dialogButtons == DialogButtons.Ok)
            {
                OkButton.Content = "OK";
                CancelButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                OkButton.Content = "Yes";
                CancelButton.Content = "No";                
            }


            if (OkButton.Visibility == Visibility.Visible)
            {
                OkButton.Focus();
            }

        }

        private void ConfirmationDialogLoaded(object sender, RoutedEventArgs e)
        {

            var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 500) };
            dt.Tick += MakeTopmost;
            dt.Start();
        }

        private void MakeTopmost(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            Topmost = true;
            Topmost = false;
        }



        private void ConfirmationDialogUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ConfirmationDialogLoaded;
            Unloaded -= ConfirmationDialogUnloaded;

        }

        private void ContentResized()
        {
           

            UpdateLayout();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
