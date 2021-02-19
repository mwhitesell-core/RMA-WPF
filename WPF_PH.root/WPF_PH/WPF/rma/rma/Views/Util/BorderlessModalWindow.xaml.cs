using Core.Windows.UI.Core.Windows.UI;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace rma.Views
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class BorderlessModalWindow : Window
    {
        private readonly Core.Windows.UI.Core.Windows.UI.Page _baseUserControl;
        private readonly double _originalHeight;
        private readonly double _originalWidth;
        private readonly UserControl _userControl;
        private DispatcherTimer _dt;
        private BorderlessModalWindow _parent;

        public BorderlessModalWindow(Core.Windows.UI.Core.Windows.UI.Page baseUserControl, BorderlessModalWindow parent)
        {
            InitializeComponent();
            _baseUserControl = baseUserControl;
            _originalHeight = Height;
            _originalWidth = Width;
            _parent = parent;
            ContentResized();
            mainWindow.Content = baseUserControl;
            Unloaded += ModalWindowUnloaded;
            Closing += ModalWindowClosing;
            _baseUserControl.CloseRunscreen += _baseUserControl_CloseRunscreen;
            KeyDown += BorderlessModalWindow_KeyDown;

       

            ApplicationState.Current.CurrentScreen = this;
           
        }

      

        void _baseUserControl_CloseRunscreen()
        {
            Close();
        }

        public BorderlessModalWindow(UserControl UserControl, BorderlessModalWindow parent)
        {
            InitializeComponent();
            _userControl = UserControl;
            _originalHeight = Height;
            _originalWidth = Width;
            _parent = parent;
            ContentResized();
            mainWindow.Content = UserControl;
            Unloaded += ModalWindowUnloaded;
            Closing += ModalWindowClosing;

            ApplicationState.Current.CurrentScreen = this;
            
        }

        private void BorderlessModalWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (NotificationMessage.Visibility == Visibility.Visible && e.Key == Key.Space)
            {
                OnCloseUpdateNotification(null, null);
            }
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
            _dt = null;
            
        }

        

        private void ContentResized()
        {
            double dpi =
                PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice.M11;
            Height = ApplicationState.Current.MainHeight/dpi;
            Width = ApplicationState.Current.MainWidth/dpi;
            view.Height = ApplicationState.Current.MainHeight/dpi;
            view.Width = ApplicationState.Current.MainWidth/dpi;

            Left = ApplicationState.Current.MainX/dpi;
            Top = ApplicationState.Current.MainY/dpi;

            if (ApplicationState.Current.ShowMenu)
            {
                mainWindow.Width = 950;
            }
            else
            {
                mainWindow.Width = 1350;
            }

            ChangeDefaultPostion();

            UpdateLayout();
        }

        private void ChangeDefaultPostion()
        {
            double h = 0;
            switch (_baseUserControl.FormName)
            {
                case "D110":
                case "H110":
                case "D113":
                case "H113":
                case "D119":
                case "H119":
                case "D119GOV":
                case "H119GOV":
                case "D119TITHE":
                case "H119TITHE":
                case "D020B":
                case "D118":
                case "M021":
                case "D199":
                    h = 204;
                    break;

               
                case "D112":
                case "H112":
                case "H020A":
                case "D112A":
                case "H112A":
                case "D020A":
                    h = 230;
                    break;

                case "M020_LOC":
                    h = 308;
                    break;



            }

            if(h > 0)
            {
                var bottom = h;
                h = h * App.UniformScaleAmount;

                Height = Height - h;
                Top = Top + h;

              

                NotificationMessage.Margin = new Thickness(NotificationMessage.Margin.Left, NotificationMessage.Margin.Top, NotificationMessage.Margin.Right, NotificationMessage.Margin.Bottom + bottom
                    );

            }
        }

        public void OnCloseUpdateNotification(object sender, RoutedEventArgs e)
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