using Core.Windows.UI.Core.Windows.UI;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;


namespace rma.Views
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        private readonly Page _baseUserControl;
        private readonly double _originalHeight;
        private readonly double _originalWidth;
        private DispatcherTimer _dt;

        public ModalWindow(Page baseUserControl)
        {
            InitializeComponent();
            _baseUserControl = baseUserControl;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();
            mainWindow.Content = baseUserControl;
            Unloaded += ModalWindowUnloaded;
            Loaded += ModalWindowLoaded;
            Closing += ModalWindowClosing;
            _baseUserControl.CloseRunscreen += _baseUserControl_CloseRunscreen;
            
        }

        void _baseUserControl_CloseRunscreen()
        {
            Close();
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
       

        private void ModalWindowLoaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
            ApplicationState.Current.CurrentScreen = this;
        }

        private void ModalWindowClosing(object sender, CancelEventArgs e)
        {

            if (_baseUserControl.IsDirty)
            {
                var confirmation = new ConfirmationDialog("Unsaved updates exist ...",
                                                          "Unsaved update Exist." + Environment.NewLine +
                                                          "Do you want to close this screen?", "",
                                                          DialogButtons.YesNo);


                confirmation.Closed += delegate
                {
                    if (confirmation.DialogResult != null &&
                        confirmation.DialogResult == false)
                    {
                        e.Cancel = true;
                    }
                };

                confirmation.Owner = Application.Current.MainWindow;
                confirmation.ShowDialog();
            }
            ApplicationState.Current.CurrentScreen = ApplicationState.Current.PreviousCurrentScreen;
        }

        private void _viewModelHideDisplayAlert(object sender, EventArgs e)
        {
            HideAlert();
        }

        

        private void _viewModelCloseScreen(object sender, EventArgs e)
        {
            Close();
        }

        private void _viewModelRaiseModalError(string message, bool autoClose)
        {
            DisplayAlert(message, autoClose);
        }

        private void ModalWindowUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ModalWindowLoaded;           
            _dt = null;           

        }

       
        private void ContentResized()
        {
            view.Height = ((_originalHeight - 40)*App.UniformScaleAmount);
            view.Width = ((_originalWidth - 20)*App.UniformScaleAmount);
            Height = (_originalHeight*App.UniformScaleAmount);
            Width = (_originalWidth*App.UniformScaleAmount);

            UpdateLayout();
        }

        private void OnCloseUpdateNotification(object sender, RoutedEventArgs e)
        {
            ClearTimer(ref _dt);
            _dt = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 200)};
            _dt.Tick += DtTick;
            _dt.Start();
        }

        private void DtTick(object sender, EventArgs e)
        {
            NotificationMessage.Visibility = Visibility.Collapsed;
            var dt = (DispatcherTimer) sender;
            ClearTimer(ref dt);
        }

        /// <summary>
        /// Clear timer
        /// </summary>
        /// <param name="dt"></param>
        private static void ClearTimer(ref DispatcherTimer dt)
        {
            if (dt != null)
                dt.Stop();
            dt = null;
        }

        /// <summary>
        /// Display the alert message on the screen.
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="autoClose">Automatically closes the alert after (n) seconds.</param>
        public void DisplayAlert(string message, bool autoClose)
        {
            if (autoClose)
            {
                NotificationMessageImageInfo.Visibility = Visibility.Visible;
                NotificationMessageImageError.Visibility = Visibility.Collapsed;
                _dt = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 10, 0)};
                _dt.Tick += DtTick;
                _dt.Start();
            }
            else
            {
                NotificationMessageImageInfo.Visibility = Visibility.Collapsed;
                NotificationMessageImageError.Visibility = Visibility.Visible;
            }


            NotificationMessage.Visibility = Visibility.Visible;
            NotificationTextBlock.Text = message;
        }

        /// <summary>
        /// Hide the alert message on the screen.
        /// </summary>
        public void HideAlert()
        {
            NotificationMessage.Visibility = Visibility.Collapsed;
        }
    }
}