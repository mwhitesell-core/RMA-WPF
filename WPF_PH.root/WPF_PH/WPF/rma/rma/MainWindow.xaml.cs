using System;
using System.ComponentModel;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using rma.Controls;

using rma.Helpers;
using Core.Resources;
using rma.Views;
using Process = System.Diagnostics.Process;
using Core.Windows.UI;
using Core.Windows.UI.Core.Windows.UI;
using Core.Framework.Core.Framework;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace rma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _dt;
        private int _previousSelectedTab;
        private bool move = true;
        private string _screen;
        private PageModeTypes _taskMode;




        public MainWindow()
        {

            InitializeComponent();

            var login = new Login();
            login.ShowDialog();
            Visibility = Visibility.Visible;

            taskPanel.setvisibility();
            taskPanel2.setvisibility();

            taskPanel.OnTaskSelectionChanged += taskPanel_OnTaskSelectionChanged;
            taskPanel2.OnTaskSelectionChanged += taskPanel_OnTaskSelectionChanged;

            taskPanel.OnAppChange += TaskPanel_OnAppChange;
            taskPanel2.OnAppChange += TaskPanel_OnAppChange;

            SizeChanged += MainWindowSizeChanged;
            LocationChanged += MainWindowLocationChanged;
            Closing += MainWindowClosing;
            Loaded += MainWindowLoaded;


            SourceInitialized += Window1_SourceInitialized;

            PopulateMessage();


            MouseRightButtonDown += MainWindow_MouseRightButtonDown;


            taskPanel.Visibility = Visibility.Collapsed;
            menucolumn.Width = new GridLength(0);
            mainWindow.Width = mainWindow.Width + 400;
            MenuButtonClick();

            Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString1";

            if (System.Configuration.ConfigurationManager.AppSettings["IsQA"] != null && System.Configuration.ConfigurationManager.AppSettings["IsQA"].ToString().ToUpper() == "TRUE")
            {
                isQA.Visibility = Visibility.Visible;
                isQA.Text = "Test 101C";
            }
            else
            {
                isQA.Visibility = Visibility.Visible;
                isQA.Text = "101C";
            }

            //ApplicationState.Current.IsQA = true;
            //isQA.Visibility = Visibility.Visible;
            //isQA.Text = "Test 101C";


            if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) != null)
            {
               
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "101c")
                {
                    ApplicationState.Current.Selected = 0;
                    TaskPanel_OnAppChange("101C");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "101cd2")
                {
                    ApplicationState.Current.Selected = 1;
                    TaskPanel_OnAppChange("101CD2");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "101cd3")
                {
                    ApplicationState.Current.Selected = 2;
                    TaskPanel_OnAppChange("101CD3");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "101cd4")
                {
                    ApplicationState.Current.Selected = 3;
                    TaskPanel_OnAppChange("101CD4");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "101cd5")
                {
                    ApplicationState.Current.Selected = 4;
                    TaskPanel_OnAppChange("101CD5");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "mp")
                {
                    ApplicationState.Current.Selected = 5;
                    TaskPanel_OnAppChange("MP");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "solo")
                {
                    ApplicationState.Current.Selected = 6;
                    TaskPanel_OnAppChange("SOLO");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "solod2")
                {
                    ApplicationState.Current.Selected = 7;
                    TaskPanel_OnAppChange("SOLOD2");
                }
                if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == "101")
                {
                    ApplicationState.Current.Selected = 8;
                    TaskPanel_OnAppChange("101");
                }

                taskPanel.AppSelection.SelectedIndex = ApplicationState.Current.Selected;
                taskPanel2.AppSelection.SelectedIndex = ApplicationState.Current.Selected;

                
            }

            try
            {
                int currDirectory = 0;

                if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process) != null)
                {

                    if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK1")
                    {
                        currDirectory = 1;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK2")
                    {
                        currDirectory = 2;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK3")
                    {
                        currDirectory = 3;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK4")
                    {
                        currDirectory = 4;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK5")
                    {
                        currDirectory = 5;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK6")
                    {
                        currDirectory = 6;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK7")
                    {
                        currDirectory = 7;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK8")
                    {
                        currDirectory = 8;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK9")
                    {
                        currDirectory = 9;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "DISK10")
                    {
                        currDirectory = 10;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR1")
                    {
                        currDirectory = 11;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR2")
                    {
                        currDirectory = 12;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR3")
                    {
                        currDirectory = 13;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR4")
                    {
                        currDirectory = 14;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR5")
                    {
                        currDirectory = 15;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR6")
                    {
                        currDirectory = 16;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR7")
                    {
                        currDirectory = 17;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR8")
                    {
                        currDirectory = 18;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR9")
                    {
                        currDirectory = 19;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR10")
                    {
                        currDirectory = 20;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR11")
                    {
                        currDirectory = 21;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR12")
                    {
                        currDirectory = 22;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR13")
                    {
                        currDirectory = 23;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR14")
                    {
                        currDirectory = 24;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR15")
                    {
                        currDirectory = 25;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR16")
                    {
                        currDirectory = 26;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR17")
                    {
                        currDirectory = 27;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR18")
                    {
                        currDirectory = 28;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR19")
                    {
                        currDirectory = 29;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR20")
                    {
                        currDirectory = 30;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "OSCAR21")
                    {
                        currDirectory = 31;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB")
                    {
                        currDirectory = 32;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB1")
                    {
                        currDirectory = 33;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB2")
                    {
                        currDirectory = 34;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB3")
                    {
                        currDirectory = 35;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB4")
                    {
                        currDirectory = 36;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB5")
                    {
                        currDirectory = 37;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB6")
                    {
                        currDirectory = 38;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB7")
                    {
                        currDirectory = 39;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB8")
                    {
                        currDirectory = 40;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB9")
                    {
                        currDirectory = 41;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB10")
                    {
                        currDirectory = 42;
                    }
                    else if (Environment.GetEnvironmentVariable("VS_DIRECTORY", EnvironmentVariableTarget.Process).ToUpper() == "WEB11")
                    {
                        currDirectory = 43;
                    }
                }

                taskPanel.CurrentDirectory.SelectedIndex = currDirectory;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Core - Set environment variable for the user's home directory
            string homedir = ConfigurationManager.AppSettings["HomePath"];

            if (homedir == null)
            {
                homedir = "C:\\Temp\\";
            }
            else if (!homedir.EndsWith("\\"))
            {
                homedir += "\\";
            }

            if (!Directory.Exists(homedir + ApplicationState.Current.CurrentUser))
            {
                Directory.CreateDirectory(homedir + ApplicationState.Current.CurrentUser);
            }

            Environment.SetEnvironmentVariable("HOMEDIR", homedir + ApplicationState.Current.CurrentUser);

            if (Environment.GetEnvironmentVariable("CallScreen", EnvironmentVariableTarget.Process) != null)          
            {
                _screen = Environment.GetEnvironmentVariable("CallScreen", EnvironmentVariableTarget.Process);
                _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 300) };
                _dt.Tick += Navigate;
                _dt.Start();
                Environment.SetEnvironmentVariable("CallScreen", "");
            }
        }




        private void TaskPanel_OnAppChange(string app)
        {
            var bc = new BrushConverter();

            if (app == "101C")
            {
                ApplicationState.Current.IsQA = false;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#FF003876");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString1";
            }
            else if (app == "101CD2")
            {
                ApplicationState.Current.IsQA = true;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#FF003876");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString2";
            }
            else if (app == "101CD3")
            {
                ApplicationState.Current.IsQA = true;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#FF003876");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString3";
            }
            else if (app == "101CD4")
            {
                ApplicationState.Current.IsQA = true;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#FF003876");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString4";
            }
            else if (app == "101CD5")
            {
                ApplicationState.Current.IsQA = true;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#FF003876");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString5";
            }
            else if(app == "MP")
            {
                ApplicationState.Current.IsQA = false;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#bb1e3a");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString6";
            }
            else if (app == "SOLO")
            {
                ApplicationState.Current.IsQA = false;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#008000");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString7";
            }
            else if (app == "SOLOD2")
            {
                ApplicationState.Current.IsQA = true;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#008000");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString8";
            }
            else if (app == "101")
            {
                ApplicationState.Current.IsQA = true;
                NavigationGrid.Background = (Brush)bc.ConvertFrom("#008000");
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString9";
            }



            isQA.Visibility = Visibility.Visible;
            isQA.Text = "" + app;


        }

        private void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);
        }

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        const int WM_NCLBUTTONDBLCLK = 0xa3;

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_NCLBUTTONDBLCLK:
                    if (!move)
                        handled = true;
                    break;
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE && !move)
                    {
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        private const Int32 WS_MAXIMIZEBOX = 0x00010000;
        private const Int32 WS_MINIMIZEBOX = 0x00020000;
        public void RemoveButtons()
        {
            move = false;
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);

            MaxWidth = Application.Current.MainWindow.ActualWidth;
            MinWidth = Application.Current.MainWindow.ActualWidth;
            MaxHeight = Application.Current.MainWindow.ActualHeight;
            MinHeight = Application.Current.MainWindow.ActualHeight;

        }

        public void AddButtons()
        {
            move = true;
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) | WS_SYSMENU);

            MaxWidth = 200000;
            MinWidth = 0;
            MaxHeight = 200000;
            MinHeight = 0;
        }



        private DateTime GetBuildDate
        {
            get
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
        }



        private void MainWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            PointToScreen(Mouse.GetPosition(this));
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {



            // Check if the application was deployed via ClickOnce.

            if (!ApplicationDeployment.IsNetworkDeployed) return;
            if (ConfigurationManager.AppSettings["Update"] == null ||
                ConfigurationManager.AppSettings["Update"].ToUpper() != "TRUE") return;
            var bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorder_RunWorkerCompleted;
            bgWorker.RunWorkerAsync();
        }


        /// <summary>
        /// Will be executed when works needs to be done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCheckInfo info = null;


            ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;


            try
            {
                info = updateCheck.CheckForDetailedUpdate();
            }

            catch (DeploymentDownloadException dde)
            {
                e.Result = UpdateStatuses.DeploymentDownloadException;
                return;
            }

            catch (InvalidDeploymentException ide)
            {
                e.Result = UpdateStatuses.InvalidDeploymentException;
                return;
            }

            catch (InvalidOperationException ioe)
            {
                e.Result = UpdateStatuses.InvalidOperationException;
                return;
            }

            if (info.UpdateAvailable)

                e.Result = info.IsUpdateRequired ? UpdateStatuses.UpdateRequired : UpdateStatuses.UpdateAvailable;
            else
                e.Result = UpdateStatuses.NoUpdateAvailable;
        }

        /// <summary>
        /// Will be executed once it's complete...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ConfirmationDialog confirmation;
            switch ((UpdateStatuses)e.Result)
            {
                case UpdateStatuses.NoUpdateAvailable:

                    break;

                case UpdateStatuses.UpdateAvailable:
                case UpdateStatuses.UpdateRequired:


                    _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 20) };
                    _dt.Tick += Hide;
                    _dt.Start();
                    _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 5) };
                    _dt.Tick += ShowUpdate;
                    _dt.Start();
                    _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 50) };
                    _dt.Tick += Update;
                    _dt.Start();


                    break;

                case UpdateStatuses.NotDeployedViaClickOnce:
                    break;

                case UpdateStatuses.DeploymentDownloadException:
                    break;

                case UpdateStatuses.InvalidDeploymentException:
                    break;

                case UpdateStatuses.InvalidOperationException:
                    break;

                default:
                    MessageBox.Show("Error?");
                    break;
            }
        }


        private void UpdateApplication()
        {
            try
            {
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                updateCheck.CheckForUpdate(false);
                updateCheck.CheckForDetailedUpdate(false);

                updateCheck.Update();

                //ExceptionLogging.LogMessage(string.Format("Upgraded: Username: {0} ",
                //                                          ApplicationState.Current.CurrentUser.ADUserName));

                System.Windows.Forms.Application.Restart();


                Application.Current.Shutdown();
            }
            catch (DeploymentDownloadException dde)
            {
                var confirmation = new ConfirmationDialog("Update errror",
                                                          "Cannot install the latest version of the application." +
                                                          Environment.NewLine +
                                                          "Please check your network connection, or try again later. Error: " +
                                                          dde, "",
                                                          DialogButtons.Ok)
                { Owner = Application.Current.MainWindow };

                confirmation.ShowDialog();
                return;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            var dt = (DispatcherTimer)sender;
            ClearTimer(ref dt);
            UpdateApplication();
        }

        private void ShowUpdate(object sender, EventArgs e)
        {
            var dt = (DispatcherTimer)sender;
            ClearTimer(ref dt);
            var update = new Update { Owner = Application.Current.MainWindow };
            update.ShowDialog();
        }

        private void Hide(object sender, EventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var dt = (DispatcherTimer)sender;
            ClearTimer(ref dt);
        }


        private void MainWindowClosing(object sender, CancelEventArgs e)
        {
            if (ApplicationState.Current.CorePage != null)
                if (ApplicationState.Current.CorePage.IsDirty)
                {
                    var confirmation = new ConfirmationDialog(Labels.UnsavedUpdatesExist,
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

        private void ContinueClose(object sender, EventArgs e)
        {
            Visibility = Visibility.Collapsed;
            var dt = (DispatcherTimer)sender;
            ClearTimer(ref dt);
        }

        public static object[] AssemblyAttributes(Type assemblyAttributeType)
        {
            // Get all Copyright attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(assemblyAttributeType, false);
            return attributes.Length == 0 ? null : attributes;
        }
        public static string AssemblyFileVersion
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                    return ad.CurrentVersion.ToString();
                }
                else
                {
                    return
                        ((AssemblyFileVersionAttribute)AssemblyAttributes(typeof(AssemblyFileVersionAttribute))[0]).
                            Version;
                }
            }
        }

        private void PopulateMessage()
        {
            versionTextBlock.Text = "Version: " + AssemblyFileVersion;
            dateTextBlock.Text = DateTime.Now.ToString(ApplicationState.Current.DateFormat);
            string userName = ApplicationState.Current.CurrentUser.FirstName;

            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12)
                HelloMessageExpanderHeaderText.Text = "Good morning, " + userName;
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17)
                HelloMessageExpanderHeaderText.Text = "Good afternoon, " + userName;
            else
                HelloMessageExpanderHeaderText.Text = "Good evening, " + userName;
        }

        private void MainWindowLocationChanged(object sender, EventArgs e)
        {

            MainWindowSizeChanged(null, null);
        }

        private void MainWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Application.Current.MainWindow == null) return;




            double currentWidth = Application.Current.MainWindow.ActualWidth;
            double currentHeight = Application.Current.MainWindow.ActualHeight;


            App.UniformScaleAmount = Math.Min((currentWidth / 1144), (currentHeight / 812));


            Vector x = mainWindow.PointToScreen(new Point(mainWindow.ActualWidth, mainWindow.ActualHeight)) -
                       mainWindow.PointToScreen(new Point(0, 0));
            ApplicationState.Current.MainHeight =
                (mainWindow.PointToScreen(new Point(mainWindow.ActualWidth, mainWindow.ActualHeight)) -
                 mainWindow.PointToScreen(new Point(0, 0))).Y;
            ApplicationState.Current.MainWidth =
                (mainWindow.PointToScreen(new Point(mainWindow.ActualWidth, mainWindow.ActualHeight)) -
                 mainWindow.PointToScreen(new Point(0, 0))).X;

            ApplicationState.Current.MainX = mainWindow.PointToScreen(new Point(0, 0)).X;
            ApplicationState.Current.MainY = mainWindow.PointToScreen(new Point(0, 0)).Y;
        }

        public void OnCloseUpdateNotification(object sender, RoutedEventArgs e)
        {
            ClearTimer(ref _dt);
            _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            _dt.Tick += DtTick;
            _dt.Start();
        }


        private void DtTick(object sender, EventArgs e)
        {
            NotificationMessage.Visibility = Visibility.Collapsed;
            var dt = (DispatcherTimer)sender;
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
                _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 10, 0) };
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


        /// <summary>
        /// Put Focus on the menu
        /// </summary>
        public void FocusMenu()
        {
            taskPanel.TreeView.Focus();
        }


        private void SupportButtonClick(object sender, RoutedEventArgs e)
        {
            if (ApplicationState.Current.HasError) return;

            var about = new About { Owner = Application.Current.MainWindow };
            about.ShowDialog();

        }

        public void MenuButtonClick()
        {
            HideMenu();

            taskPanel.AppSelection.SelectedIndex = ApplicationState.Current.Selected;
            taskPanel2.AppSelection.SelectedIndex = ApplicationState.Current.Selected;

            taskPanel.TreeView = ApplicationState.Current.trview;
            taskPanel2.TreeView = ApplicationState.Current.trview;

            UpdateLayout();

            if (taskPanel.Visibility == Visibility.Collapsed)
            {
                var bc = new BrushConverter();
                taskPanel2.Top.Background = (Brush)bc.ConvertFrom("#FF4C739F");

                taskPanel.Visibility = Visibility.Visible;
                menucolumn.Width = new GridLength(400);
                mainWindow.Width = mainWindow.Width - 400;
                ApplicationState.Current.ShowMenu = true;
            }
            else
            {
                taskPanel.Visibility = Visibility.Collapsed;
                menucolumn.Width = new GridLength(0);
                mainWindow.Width = mainWindow.Width + 400;
                ApplicationState.Current.ShowMenu = false;

                taskPanel2.Top.Background = new SolidColorBrush(Colors.White);
            }

            taskPanel.MenuButton1.Visibility = Visibility.Visible;
            taskPanel.MenuButton2.Visibility = Visibility.Collapsed;

            taskPanel2.MenuButton1.Visibility = Visibility.Collapsed;
            taskPanel2.MenuButton2.Visibility = Visibility.Visible;





            if (taskPanel.Visibility == Visibility.Visible)
                taskPanel.setfocus();
            else
                taskPanel2.setfocus();


            _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 50) };
            _dt.Tick += MenuSize;
            _dt.Start();
        }



        private void MenuSize(object sender, EventArgs e)
        {
            var dt = (DispatcherTimer)sender;
            ClearTimer(ref dt);

            MainWindowSizeChanged(null, null);
        }

        private void HideMenu()
        {
            DoubleAnimation db = new DoubleAnimation();
            db.To = 6;
            db.Duration = TimeSpan.FromSeconds(0);
            db.AutoReverse = false;
            db.RepeatBehavior = new RepeatBehavior(1);
            menuBorder.BeginAnimation(StackPanel.HeightProperty, db);
        }

        public void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (taskPanel.Visibility == Visibility.Collapsed)
            {

                var bc = new BrushConverter();
                taskPanel2.Top.Background = (Brush)bc.ConvertFrom("#FF4C739F");

                DoubleAnimation db = new DoubleAnimation();
                db.To = 760;
                db.Duration = TimeSpan.FromSeconds(0.2);
                db.AutoReverse = false;
                db.RepeatBehavior = new RepeatBehavior(1);
                menuBorder.BeginAnimation(StackPanel.HeightProperty, db);
                taskPanel2.setfocus();
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (taskPanel.Visibility == Visibility.Collapsed)
            {
                taskPanel2.Top.Background = new SolidColorBrush(Colors.White);

                DoubleAnimation db = new DoubleAnimation();

                db.To = 6;
                db.Duration = TimeSpan.FromSeconds(0.2);
                db.AutoReverse = false;
                db.RepeatBehavior = new RepeatBehavior(1);
                menuBorder.BeginAnimation(StackPanel.HeightProperty, db);
            }
        }


        private void TreeNodes(CoreTreeViewItem coreTreeViewItem)
        {
            foreach (CoreTreeViewItem i in coreTreeViewItem.Items)
            {

                i.Visibility = Visibility.Visible;

                TreeNodes(i);
            }
        }

        private void ChangeScreen()
        {
            HideAlert();
        }

        private void taskPanel_OnTaskSelectionChanged(string screen, string header, string mode)
        {
            if (openingscreen)
                return;

            MainWindowSizeChanged(null, null);

            _screen = screen;
            ApplicationState.Current.Navigate = true;

            PageModeTypes taskMode = PageModeTypes.NoMode;

            if (mode != null)
                switch (mode.ToUpper())
                {
                    case "F":
                        taskMode = PageModeTypes.Find;
                        break;
                    case "E":
                        taskMode = PageModeTypes.Entry;
                        break;

                }

            _taskMode = taskMode;

            bool exit = false;
            if (ApplicationState.Current.CorePage != null && ApplicationState.Current.CorePage.IsDirty && screen != "home")
            {
                var confirmation = new ConfirmationDialog(Labels.UnsavedUpdatesExist,
                                                          "Unsaved update Exist." + Environment.NewLine +
                                                          "Do you want to navigate away from this screen?", "",
                                                          DialogButtons.YesNo);


                confirmation.Closed += delegate
                                           {
                                               if (confirmation.DialogResult != null &&
                                                   confirmation.DialogResult == false)
                                               {
                                                   exit = true;
                                               }
                                           };

                confirmation.Owner = Application.Current.MainWindow;
                confirmation.ShowDialog();
            }


            if (exit) return;

            if (NotificationMessage.Visibility == Visibility.Visible)
            {
                HideAlert();
            }

            if (ApplicationState.Current.CorePage != null)
                ApplicationState.Current.CorePage.IsDirty = false;

            string path = string.Empty;

            HideMenu();

            openingscreen = true;

            _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 300) };
            _dt.Tick += Navigate;
            _dt.Start();




        }

        private bool openingscreen;

        private void Navigate(object sender, EventArgs e)
        {

            var dt = (DispatcherTimer)sender;
            ClearTimer(ref dt);

            openingscreen = false;

            Core.Windows.UI.Core.Windows.UI.Page control = null;

            switch (_screen)
            {
                case "d001": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new d001();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "d002": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new d002();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "d003": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new d003();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "d004": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new d004();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m030": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new m030();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m040": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new m040();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m070": // cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new m070();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m094": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new m094();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m095": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new m095();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "newu701": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new newu701();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "newu703": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new newu703();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "r001": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new r001();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "u701oscar": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new u701oscar();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "u703oscar": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new u703oscar();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "u993": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new u993();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m090COBOL": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new m090();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "d050": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new d050();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "u030a": //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new u030a();
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m902":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M902();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m098":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M098();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m096":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M096();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m093":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M093();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m092":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M092();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m074":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M074();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m075":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M075();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

               // case "d001":
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_D001();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                //    break;

                case "m088":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M088();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "d087_hdr":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_D087_HDR();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "d087":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_D087();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m201":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M201();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;



                case "_m096":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M096();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m090g":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M090G();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

               // case "d002":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_D002();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
               //     break;

                case "d084":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Yas_D084();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m084a":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M084A();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "utl1000":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_UTL1000();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "utl1002":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_UTL1002();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m200":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M200();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

               // case "d003":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_D003();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
               //     break;

              //  case "d004":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_D004();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
              //      break;

                case "m113":
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M113();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m010":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M010();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m020":
                    mainWindow.Content = null;
                    App.Collection();
                    if (ApplicationState.Current.Selected == 1)
                        control = new Mp_M020();
                    else
                        control = new Billing_M020();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "f021_doc_nbrs":
                    //????
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_F021_DOC_NBRS();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

               // case "m030":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M030();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                //    break;

               // case "m040":
                    //cobol
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M040();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
               //     break;

               // case "m070":
                    //cobol
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M070();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m123":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M123();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m080":
                    //cobol
                    mainWindow.Content = null;
                    App.Collection();
                    control = new M080();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m090":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M090();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;



                case "m074a":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M074A();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;





                case "f096_pay_code":
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_F096_PAY_CODE();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m091":
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M091();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m101":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M101();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m102":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M102();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "in01":
                    //Not included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_IN01();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m940":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M940();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m083":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M083();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m941":
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M941();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m923":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M923();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m924":
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M924();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m020c":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M020C();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "m076":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Moira_M076();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

               // case "m094":
                    //Cobol
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M094();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
               //     break;

                case "":
                    //Cobol
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M095();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;



                case "d713":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_D713();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "d705":

                    //Environment.GetEnvironmentVariable("CurrentDirectory");
                    //MessageBox.Show("100: " + Environment.GetEnvironmentVariable("CurrentDirectory"));
                    //taskPanel.CurrentDirectory.SelectedValue = (Environment.GetEnvironmentVariable("CurrentDirectory").Substring(Environment.GetEnvironmentVariable("CurrentDirectory").LastIndexOf("\\") + 1)).ToUpper();

                    mainWindow.Content = null;
                    App.Collection();
                    control = new Moira_D705();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "d705_App":

                    if (taskPanel.CurrentDirectory.Text.ToString().ToUpper() != "SELECT ENVIRONMENT")
                    {
                        mainWindow.Content = null;
                        App.Collection();
                        control = new Moira_D705();
                        control.CloseRunscreen += control_CloseRunscreen;
                        control.Mode = _taskMode;
                        mainWindow.Content = control;
                    }
                    else
                    {
                        MessageBox.Show("An environment needs to be selected from the dropdown.");
                    }
                    break;

                case "m099":
                    //Not Included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M099();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "d811":
                    //Not Included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_D811();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "m115":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M115();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "M116":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Moira_M116();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                case "m040_dtl":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M040_DTL();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "D020":
                    mainWindow.Content = null;
                    App.Collection();
                    if (ApplicationState.Current.Selected == 1)
                        control = new Mp_D020();
                    else
                        control = new Billing_D020();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "M190":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M190();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "M193":
                    //Not Included
                    //mainWindow.Content = null;
                    //App.Collection();
                    //control = new Billing_M193();
                    //control.CloseRunscreen += control_CloseRunscreen;
                    //control.Mode = _taskMode;
                    //mainWindow.Content = control;
                    break;

                case "M090F":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M090F();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "M191":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M191();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "M199":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_M199();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "Mp_m020":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Mp_M020();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;

                case "D114":
                    mainWindow.Content = null;
                    App.Collection();
                    if (ApplicationState.Current.Selected == 1)
                        control = new Mp_D114();
                    else
                        control = new Billing_D114();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;


                case "ohip_run_dates":
                    mainWindow.Content = null;
                    App.Collection();
                    control = new Billing_OHIP_RUN_DATES();
                    control.CloseRunscreen += control_CloseRunscreen;
                    control.Mode = _taskMode;
                    mainWindow.Content = control;
                    break;
                    

                default:
                    if (mainWindow.Content == null || mainWindow.Content.ToString() != "rma.Views.Home")
                    {
                        mainWindow.Content = null;
                        App.Collection();
                        mainWindow.Content = new Home();
                    }
                    break;

                    ApplicationState.Current.Navigate = false;
            }


        }


        public void OpenHomeScreen()
        {
            mainWindow.Content = null;
            App.Collection();
            mainWindow.Content = new Home();
        }

        void control_CloseRunscreen()
        {

            mainWindow.Content = null;
            App.Collection();
            mainWindow.Content = new Home();
        }

        #region Nested type: UpdateStatuses

        private enum UpdateStatuses
        {
            NoUpdateAvailable,

            UpdateAvailable,

            UpdateRequired,

            NotDeployedViaClickOnce,

            DeploymentDownloadException,

            InvalidDeploymentException,

            InvalidOperationException
        }

        #endregion
    }
}