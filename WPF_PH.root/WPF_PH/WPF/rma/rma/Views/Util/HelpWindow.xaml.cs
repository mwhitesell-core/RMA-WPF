using Core.Windows.UI.Core.Windows.UI;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;


namespace rma.Views
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        private readonly double _originalHeight;
        private readonly double _originalWidth;

        public HelpWindow(string title, string message)
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
            Loaded += HelpWindowLoaded;
            Unloaded += HelpWindowUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();
            Title = title;
            Message.Text = message;
        }

        private void ContentResized()
        {
            view.Height = ((_originalHeight - 40) * App.UniformScaleAmount);
            view.Width = ((_originalWidth - 20) * App.UniformScaleAmount);
            Height = (_originalHeight * App.UniformScaleAmount);
            Width = (_originalWidth * App.UniformScaleAmount);

            UpdateLayout();
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void HelpWindowLoaded(object sender, RoutedEventArgs e)
        {
            KeyUp += HelpWindowKeyUp;
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void HelpWindowKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                Close();
            }
        }

        private void HelpWindowUnloaded(object sender, RoutedEventArgs e)
        {
            KeyUp -= HelpWindowKeyUp;
            Loaded -= HelpWindowLoaded;
            Unloaded -= HelpWindowUnloaded;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}