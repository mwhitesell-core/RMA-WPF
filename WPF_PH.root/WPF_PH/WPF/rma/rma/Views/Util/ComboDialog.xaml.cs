using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using HPB.Controls;
using HPB.Resources;


namespace HPB.Views
{
    /// <summary>
    /// Interaction logic for ComboDialogDialog.xaml
    /// </summary>
    public partial class ComboDialog : Window
    {
        private readonly double _originalHeight;
        private readonly double _originalWidth;
        private string _messageText;
        private string type;

        public ComboDialog(string dialogTitle, string messageText, string values, int width = 50,
                           DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            InitializeComponent();
            if (ApplicationState.Current.CurrentScreen != null)
                Owner = ApplicationState.Current.CurrentScreen;
            _messageText = messageText;
            Loaded += ConfirmationDialogLoaded;
            Unloaded += ConfirmationDialogUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            InitializeDialog(dialogTitle, messageText, values, width, dialogButtons);
        }

        public ComboDialog(string dialogTitle, string messageText, string values, string defaultvalue, int width = 50,
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

            InitializeDialog(dialogTitle, messageText, values, width, dialogButtons);

            ResponsetextBox.Text = defaultvalue;
        }

        public string ResponseText { get; set; }


        private void InitializeDialog(string dialogTitle, string messageText, string values, int width,
                                      DialogButtons dialogButtons = DialogButtons.OkCancel)
        {
            Title = dialogTitle;
            MainMessageField.Text = messageText;
            ResponsetextBox.Width = width;
            ResponsetextBox.SetResourceReference(StyleProperty, "RadComboBox");

            if (string.IsNullOrEmpty(ResponsetextBox.SelectedValuePath))
                ResponsetextBox.SelectedValuePath = "Value";
            if (string.IsNullOrEmpty(ResponsetextBox.DisplayMemberPath))
                ResponsetextBox.DisplayMemberPath = "DisplayText";

            string[] valueArray = values.Split(',');

            List<ComboBoxItemSource> comboItemsource = valueArray.Select(t => new ComboBoxItemSource(t, t)).ToList();

            ResponsetextBox.ItemsSource = comboItemsource.OrderBy(o => o.DisplayText);

            type = type;

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

        private void ConfirmationDialogUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ConfirmationDialogLoaded;
            Unloaded -= ConfirmationDialogUnloaded;
            PreviewMouseDown -= Keys_MouseDown;
            PreviewKeyDown -= Keys_KeyDown;
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
            ResponseText = ResponsetextBox.Text;
            DialogResult = true;
        }


        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            ResponseText = "";
            DialogResult = false;
        }
    }
}