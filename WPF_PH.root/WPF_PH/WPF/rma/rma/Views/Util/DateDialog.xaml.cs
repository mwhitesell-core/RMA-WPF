using System;
using System.Windows;
using System.Windows.Threading;
using HPB.Resources;


namespace HPB.Views
{
    /// <summary>
    /// Interaction logic for ComboDialogDialog.xaml
    /// </summary>
    public partial class DateDialog : Window
    {
        private readonly double _originalHeight;
        private readonly double _originalWidth;
        private string _messageText;
        private string type;

        public DateDialog(string dialogTitle, string messageText, DateTime? value,
                          DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            InitializeComponent();
            try
            {
                Owner = ApplicationState.Current.CurrentScreen ?? Application.Current.MainWindow;
            }
            catch
            {
                Owner = Application.Current.MainWindow;
            }
            _messageText = messageText;
            Loaded += ConfirmationDialogLoaded;
            Unloaded += ConfirmationDialogUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            InitializeDialog(dialogTitle, messageText, value, dialogButtons);
        }

        public DateTime? ResponseText { get; set; }


        private void InitializeDialog(string dialogTitle, string messageText, DateTime? value,
                                      DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            Title = dialogTitle;
            MainMessageField.Text = messageText;


            if (value != null)
                ResponsetextBox.SelectedValue = value;


            if (dialogButtons == DialogButtons.OkCancel)
            {
                OkButton.Content = ApplicationStrings.OKButton;
                CancelButton.Content = ApplicationStrings.CancelButton;
            }
            else if (dialogButtons == DialogButtons.Ok)
            {
                OkButton.Content = ApplicationStrings.OKButton;
                CancelButton.Visibility = Visibility.Hidden;
            }
            else
            {
                OkButton.Content = ApplicationStrings.YesButton;
                CancelButton.Content = ApplicationStrings.NoButton;
            }
        }


        private void ConfirmationDialogLoaded(object sender, RoutedEventArgs e)
        {
            ResponsetextBox.LostFocus += ResponsetextBoxLostFocus;
            ResponsetextBox.Focus();
            var dt = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 500)};
            dt.Tick += MakeTopmost;
            dt.Start();
        }

        private void ResponsetextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (ResponsetextBox.InCorrectFormat)
            {
                ResponsetextBox.InCorrectFormat = false;
                ResponsetextBox.SelectedValue = null;
                DisplayMessage("Incorrect Format! Please use (ddmmyyyy|dd mm yyyy|ddmmmyyyy|dd mmm yyyy)");
            }
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
            ResponsetextBox.LostFocus -= ResponsetextBoxLostFocus;
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

        public void DisplayMessage(string message)
        {
            MainMessageField.Text = message;
            var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 1, 0) };
            dt.Tick += ErrorMessage;
            dt.Start();
        }

        public void ErrorMessage(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            MainMessageField.Text = _messageText;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            ResponseText = ResponsetextBox.SelectedValue;
            DialogResult = true;
        }


        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}