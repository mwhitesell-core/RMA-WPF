using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace rma.Views
{
    /// <summary>
    ///     Controls when a stack trace should be displayed on the
    ///     Error Window
    ///     
    ///     Defaults to <see cref="OnlyWhenDebuggingOrRunningLocally"/>
    /// </summary>
    public enum StackTracePolicy
    {
        /// <summary>
        ///   Stack trace is showed only when running with a debugger attached
        ///   or when running the app on the local machine. Use this to get
        ///   additional debug information you don't want the end users to see
        /// </summary>
        OnlyWhenDebuggingOrRunningLocally,

        /// <summary>
        /// Always show the stack trace, even if debugging
        /// </summary>
        Always,

        /// <summary>
        /// Never show the stack trace, even when debugging
        /// </summary>
        Never
    }

    /// <summary>
    ///     Controls what icon should be displayed on the
    ///     Error Window
    ///     
    ///     Defaults to Error
    /// </summary>
    public enum ErrorLevel
    {
        Error,
        Severe,
        Information
    }

    public partial class ErrorWindow : Window
    {
        private readonly double _originalHeight;
        private readonly double _originalWidth;

        protected ErrorWindow(string message, string errorDetails)
        {
            InitializeComponent();
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();
            IntroductoryText.Text = message;
            ErrorTextBox.Text = errorDetails;
        }

        public ErrorWindow(string message, string errorDetails, ErrorLevel level)
        {
            InitializeComponent();
            Loaded += ErrorWindowLoaded;
            Unloaded += ErrorWindowUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();
            IntroductoryText.Text = message;
            ErrorTextBox.Text = errorDetails;

            switch (level)
            {
                case ErrorLevel.Error:
                    {
                        ErrorImage.Visibility = Visibility.Visible;
                        break;
                    }
                case ErrorLevel.Severe:
                    {
                        ErrorImage.Visibility = Visibility.Collapsed;
                        SevereImage.Visibility = Visibility.Visible;
                        break;
                    }
                case ErrorLevel.Information:
                    {
                        ErrorImage.Visibility = Visibility.Collapsed;
                        InfoImage.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }

        private void ErrorWindowLoaded(object sender, RoutedEventArgs e)
        {
            KeyUp += ErrorWindowKeyUp;
        }

        private void ErrorWindowKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                Close();
            }
        }

        private void ErrorWindowUnloaded(object sender, RoutedEventArgs e)
        {
            KeyUp -= ErrorWindowKeyUp;
            Loaded -= ErrorWindowLoaded;
            Unloaded -= ErrorWindowUnloaded;
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

        #region Factory Shortcut Methods

        /// <summary>
        ///     Creates a new Error Window given an error message.
        ///     Current stack trace will be displayed if app is running under
        ///     debug or on the local machine
        /// </summary>
        public static void CreateNew(string message)
        {
            CreateNew(message, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally);
        }

        public static void CreateNew(string message, ErrorLevel level)
        {
            CreateNew(message, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally, level);
        }

        /// <summary>
        ///     Creates a new Error Window given an exception.
        ///     Current stack trace will be displayed if app is running under
        ///     debug or on the local machine
        ///     
        ///     The exception is converted onto a message using
        ///     <see cref="ConvertExceptionToMessage"/>
        /// </summary>
        public static void CreateNew(Exception exception)
        {
            CreateNew(exception, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally);
        }

        /// <summary>
        ///     Creates a new Error Window given an exception. The exception is converted onto a message using
        ///     <see cref="ConvertExceptionToMessage"/>
        ///     
        ///     <param name="policy">When to display the stack trace, see <see cref="StackTracePolicy"/></param>
        /// </summary>
        public static void CreateNew(Exception exception, StackTracePolicy policy)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            string fullStackTrace = exception.StackTrace;

            // Account for nested exceptions
            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                fullStackTrace += "\nCaused by: " + exception.Message + "\n\n" + exception.StackTrace;
                innerException = innerException.InnerException;
            }

            CreateNew(ConvertExceptionToMessage(exception), fullStackTrace, policy);
        }

        /// <summary>
        ///     Creates a new Error Window given an error message.
        ///     
        ///     <param name="policy">When to display the stack trace, see <see cref="StackTracePolicy"/></param>
        /// </summary>
        public static void CreateNew(string message, StackTracePolicy policy)
        {
            CreateNew(message, new StackTrace().ToString(), policy);
        }

        public static void CreateNew(string message, StackTracePolicy policy, ErrorLevel level)
        {
            CreateNew(message, new StackTrace().ToString(), policy, level);
        }

        #endregion

        #region Factory Methods

        /// <summary>
        ///     All other factory methods will result in a call to this one
        /// </summary>
        /// 
        /// <param name="message">Which message to display</param>
        /// <param name="stackTrace">The associated stack trace</param>
        /// <param name="policy">In which situations the stack trace should be appended to the message</param>
        private static void CreateNew(string message, string stackTrace, StackTracePolicy policy)
        {
            string errorDetails = string.Empty;

            if (policy == StackTracePolicy.Always ||
                policy == StackTracePolicy.OnlyWhenDebuggingOrRunningLocally)
            {
                errorDetails = stackTrace ?? string.Empty;
            }

            var window = new ErrorWindow(message, errorDetails);
            window.Show();
        }

        private static void CreateNew(string message, string stackTrace, StackTracePolicy policy, ErrorLevel level)
        {
            string errorDetails = string.Empty;

            if (policy == StackTracePolicy.Always ||
                policy == StackTracePolicy.OnlyWhenDebuggingOrRunningLocally)
            {
                errorDetails = stackTrace ?? string.Empty;
            }

            var window = new ErrorWindow(message, errorDetails, level);
            window.Show();
        }

        #endregion

        #region Factory Helpers        

        /// <summary>
        ///     Creates a user friendly message given an Exception. Currently this simply
        ///     takes the Exception.Message value, optionally  but you might want to change this to treat
        ///     some specific Exception classes differently
        /// </summary>
        private static string ConvertExceptionToMessage(Exception e)
        {
            return e.Message;
        }

        #endregion
    }
}