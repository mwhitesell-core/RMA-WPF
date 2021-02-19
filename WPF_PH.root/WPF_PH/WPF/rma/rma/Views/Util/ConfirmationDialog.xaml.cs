using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Core.Resources;


namespace rma.Views
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

            if (dialogButtons == DialogButtons.OkCancel)
            {
                OkButton.Content = Labels.OKButton;
                CancelButton.Content = Labels.CancelButton;
            }
            else if (dialogButtons == DialogButtons.Ok)
            {
                OkButton.Content = Labels.OKButton;
                CancelButton.Visibility = Visibility.Hidden;
            }
            else if (dialogButtons == DialogButtons.None)
            {
                OkButton.Visibility = Visibility.Hidden;
                CancelButton.Visibility = Visibility.Hidden;
            }
            else
            {
                OkButton.Content = Labels.YesButton;
                CancelButton.Content = Labels.NoButton;
            }

            if (OkButton.Visibility == Visibility.Visible)
            {
                OkButton.Focus();
            }
        }

        private void ConfirmationDialogLoaded(object sender, RoutedEventArgs e)
        {            

            var dt = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 500)};
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
            view.Height = ((_originalHeight - 40)*App.UniformScaleAmount);
            view.Width = ((_originalWidth - 20)*App.UniformScaleAmount);
            Height = (_originalHeight*App.UniformScaleAmount);
            Width = (_originalWidth*App.UniformScaleAmount);

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