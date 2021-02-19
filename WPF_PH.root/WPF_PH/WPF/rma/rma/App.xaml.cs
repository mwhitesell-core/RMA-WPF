using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using rma.Views;
using Core.Windows.UI.Core.Windows.UI;
using Core.ExceptionManagement;

namespace rma
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static double UniformScaleAmount;
        public static double BorderlessScaleAmount;
        private static string _collectGarbage;
        private ErrorWindow _errorWindow;

   
        public App()
        {
            ApplicationState.Current.LookupCharacter = "*";
            ApplicationState.Current.GenericRetrievalCharacter = "@";
        }


        // Allows navigation pages (through the base page) access
        // to main page for displaying messages.
        public new MainWindow MainWindow
        {
            get { return Current.MainWindow as MainWindow; }
        }

        public static bool ApplicationUserLoaded()
        {




            try
            {
                ApplicationState.Current.CurrentRoles = DsAccountManagement.RoleCollection(Environment.UserName,
                                                                                           Environment.
                                                                                               UserDomainName);




                if (ApplicationState.Current.CurrentRoles == null ||
                    ApplicationState.Current.CurrentRoles.Count == 0)
                {
                    var uaex =
                        new UnauthorizedAccessException(String.Format("Login denied. Username: {0}",
                                                                      Environment.UserName));
                    ExceptionLogging.HandleException(uaex);

                    var accessDenied = new AccessDenied { Message = uaex.Message };
                    accessDenied.ShowDialog();
                    Environment.Exit(0);
                    return false;
                }
                else
                {
                    Core.Framework.Core.Security.SecurityManager sm = new Core.Framework.Core.Security.SecurityManager();
                    ApplicationState.Current.CurrentRoles = sm.CheckRoles(ApplicationState.Current.CurrentRoles);

                    if (ApplicationState.Current.CurrentRoles == null ||
                    ApplicationState.Current.CurrentRoles.Count == 0)
                    {   
                        var uaex =
                            new UnauthorizedAccessException(String.Format("Login denied. Username: {0}",
                                                                          Environment.UserName));
                        ExceptionLogging.HandleException(uaex);

                        var accessDenied = new AccessDenied { Message = uaex.Message };
                        accessDenied.ShowDialog();
                        Environment.Exit(0);
                        return false;
                    }

                }

                var appUser = new Core.Framework.AppUser();
                appUser.ADUserName = ApplicationState.Current.UserName;
                appUser.FirstName = DsAccountManagement.GivenName(Environment.UserName);
                appUser.LastName = DsAccountManagement.LastName(Environment.UserName);

                //appUser.FirstName = "manager";// DsAccountManagement.GivenName(Environment.UserName);
                //appUser.LastName = "manager";// DsAccountManagement.LastName(Environment.UserName);
                ApplicationState.Current.CurrentUser = appUser;
            }
            catch (Exception e)
            {
                var accessDenied = new AccessDenied();
                ExceptionLogging.HandleException(e);
                accessDenied.Message = e.Message;
                accessDenied.ShowDialog();
                Environment.Exit(0);
                return false;
            }


            try
            {
                ExceptionLogging.LogMessage(String.Format("Login: Username: {0} ",
                                                    ApplicationState.Current.CurrentUser.ADUserName) + " Version: " +
                                      ((AssemblyFileVersionAttribute)
                                       AssemblyAttributes(typeof(AssemblyFileVersionAttribute))[0]).
                                          Version + " Build Date: " + GetBuildDate());
            }
            catch (Exception e)
            { }


                return true;
        }

        private static object[] AssemblyAttributes(Type assemblyAttributeType)
        {
            // Get all Copyright attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(assemblyAttributeType, false);
            return attributes.Length == 0 ? null : attributes;
        }

        private static DateTime GetBuildDate()
        {
            var date = new DateTime(2000, 1, 1);
            string[] parts = Assembly.GetExecutingAssembly().FullName.Split(',');
            string[] versionParts = parts[1].Split('.');
            date = date.AddDays(Int32.Parse(versionParts[2]));
            date = date.AddSeconds(Int32.Parse(versionParts[3]) * 2);
            if (TimeZoneInfo.Local.IsDaylightSavingTime(date))
            {
                date = date.AddHours(1);
            }

            return date;
        }

        public static void Collection()
        {
            if (_collectGarbage == null)
                _collectGarbage = ConfigurationManager.AppSettings.Get("CollectGarbage");
            if (_collectGarbage.ToLower() == "true")
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            }
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            
        }


        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            ExceptionLogging.LogMessage(String.Format("Logout: Username: {0} ",
                                                      ApplicationState.Current.CurrentUser.ADUserName));
        }

        private void ApplicationDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            string fullStackTrace = e.Exception.StackTrace;

            // Account for nested exceptions
            Exception innerException = e.Exception.InnerException;
            while (innerException != null)
            {
                fullStackTrace += "\nCaused by: " + e.Exception.Message + "\n\n" + e.Exception.StackTrace;
                innerException = innerException.InnerException;
            }

            ExceptionLogging.HandleException(e.Exception);
            _errorWindow = new ErrorWindow(e.Exception.Message, fullStackTrace, ErrorLevel.Error)
            { Owner = Current.MainWindow };
            e.Handled = true;
            _errorWindow.Closed += ErrorWindowClosed;
            _errorWindow.ShowDialog();
        }

        private void ErrorWindowClosed(object sender, EventArgs e)
        {
            _errorWindow = null;
        }
    }
}