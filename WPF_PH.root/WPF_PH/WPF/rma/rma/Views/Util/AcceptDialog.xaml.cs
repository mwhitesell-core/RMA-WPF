using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using HPB.Helpers;
using HPB.Resources;


namespace HPB.Views
{
    /// <summary>
    /// Interaction logic for AcceptDialogDialog.xaml
    /// </summary>
    public partial class AcceptDialog : Window
    {
        private readonly bool _isNumeric;
        private readonly string _messageText;
        private readonly double _originalHeight;
        private readonly double _originalWidth;
        private bool _isPositive;
        private string _match;
        private string _responseText;
        private string type;

        public AcceptDialog(string dialogTitle, string messageText, int maxLength, bool isNumeric,
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
            _isNumeric = isNumeric;
            _messageText = messageText;
            Loaded += ConfirmationDialogLoaded;
            Unloaded += ConfirmationDialogUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            InitializeDialog(dialogTitle, messageText, null, null, null, maxLength, isNumeric, dialogButtons);
        }

        public AcceptDialog(string dialogTitle, string messageText, string defaultValue, string type, int maxLength,
                            bool isNumeric,
                            DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            InitializeComponent();

            _isNumeric = isNumeric;
            _messageText = messageText;
            Loaded += ConfirmationDialogLoaded;
            Unloaded += ConfirmationDialogUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            InitializeDialog(dialogTitle, messageText, defaultValue, type, null, maxLength, isNumeric, dialogButtons);
        }

        public AcceptDialog(string dialogTitle, string messageText, string match, int maxLength, bool isNumeric,
                            DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            InitializeComponent();

            _isNumeric = isNumeric;
            _messageText = messageText;
            Loaded += ConfirmationDialogLoaded;
            Unloaded += ConfirmationDialogUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            InitializeDialog(dialogTitle, messageText, null, null, match, maxLength, isNumeric, dialogButtons);
        }

        public string ResponseText
        {
            get { return ReturnValueBasedOnType(_responseText); }
            set { _responseText = value; }
        }

        private void InitializeDialog(string dialogTitle, string messageText, string defaultValue, string type,
                                      string match, int maxLength, bool isNumeric,
                                      DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            Title = dialogTitle;
            if (isNumeric)
                ResponsetextBox.TextAlignment = TextAlignment.Right;
            MainMessageField.Text = messageText;
            ResponsetextBox.SetResourceReference(StyleProperty, "CoreTextStyle");
            ResponsetextBox.MaxLength = maxLength;
            if (maxLength == 1)
                ResponsetextBox.Width = 26;
            else
                ResponsetextBox.Width = maxLength*14;
            _match = match;

            if (defaultValue != null)
            {
                ResponsetextBox.Text = defaultValue;
                ResponsetextBox.SelectAll();
            }
            else if (isNumeric)
            {
                ResponsetextBox.Text = "0";
                ResponsetextBox.SelectAll();
            }

            if (type != null && type.StartsWith("+"))
            {
                _isPositive = true;
                type = type.Replace("+", "");
            }

            this.type = type;

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

        private string ReturnValueBasedOnType(string value)
        {
            if (type == null)
            {
                return value;
            }
            else
            {
                if (value == null)
                {
                    value = "0";
                }

                int decimals;

                if (GuiUtil.IsNumeric(type.Replace("Z", "")))
                {
                    decimals = Convert.ToInt32(type.Replace("Z", ""));
                }
                else
                {
                    decimals = 0;
                }

                int hasDecimals = 0;

                while (decimals > hasDecimals)
                {
                    value = (Util.NumDec(value)*10).ToString();
                    hasDecimals += 1;
                }

                return value;
            }
        }

        private void ConfirmationDialogLoaded(object sender, RoutedEventArgs e)
        {
            ResponsetextBox.Focus();
            if (ConfigurationManager.AppSettings["Keys"] == "True")
            {
                PreviewMouseDown += Keys_MouseDown;
                PreviewKeyDown += Keys_KeyDown;
            }

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
            PreviewMouseDown -= Keys_MouseDown;
            PreviewKeyDown -= Keys_KeyDown;
        }

        private void Keys_KeyDown(object sender, KeyEventArgs e)
        {
            var sw = new StreamWriter(ApplicationState.Current.Keys, true);
            sw.Write(DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ssss") + " " + e.Key + Environment.NewLine);
            sw.Flush();
            sw.Dispose();
        }

        private void Keys_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var sw = new StreamWriter(ApplicationState.Current.Keys, true);
            sw.Write(DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ssss") + " " + "X=" +
                     PointToScreen(Mouse.GetPosition(this)).X + " Y=" + PointToScreen(Mouse.GetPosition(this)).Y +
                     Environment.NewLine);
            sw.Flush();
            sw.Dispose();
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
            if (_isNumeric && !GuiUtil.IsNumeric(ResponsetextBox.Text))
            {
                DisplayMessage("Value must be numeric");
            }
            else if (_isPositive && Util.NumDec(ResponsetextBox.Text) < 0)
            {
                DisplayMessage("Value must not be less than zero");
            }
            else if (_isNumeric && GuiUtil.IsNumeric(ResponsetextBox.Text) && !string.IsNullOrEmpty(type))
            {
                if (type.StartsWith("Z") && GuiUtil.IsNumeric(type.Replace("Z", "")))
                {
                    ResponseText = ResponsetextBox.Text;
                    DialogResult = true;
                }
                else
                {
                    if (Convert.ToDecimal(ResponsetextBox.Text.Replace("$", "").Replace(",", "")) >
                        Convert.ToDecimal(type.Replace("$", "").Replace(",", "").Replace("Z", "9")))
                    {
                        DisplayMessage("Invalid Input! Please use... " + type);
                        return;
                    }
                    else
                    {
                        ResponseText = ResponsetextBox.Text;
                        DialogResult = true;
                    }
                }
            }
            else
            {
                if (_match != null && !Util.Match(ResponsetextBox.Text, _match))
                {
                    DisplayMessage("Value must be " + _match.Replace(", ", ",' '"));
                    return;
                }
                else
                {
                    ResponseText = ResponsetextBox.Text;
                    DialogResult = true;
                }
            }
        }

        public void DisplayMessage(string message)
        {
            MainMessageField.Text = message;
            var dt = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 1, 0)};
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

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            ResponseText = "";
            DialogResult = false;
        }
    }
}