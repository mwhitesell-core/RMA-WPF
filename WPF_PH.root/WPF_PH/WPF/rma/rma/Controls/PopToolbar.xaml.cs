using System.Windows;
using System.Windows.Controls;
using rma.Helpers;
using rma.Views;
using Core.Windows.UI.Core.Windows.UI;
using Core.Framework.Core.Framework;
using System.Windows.Threading;
using System.Windows.Media;
using System;
using Core.Resources;
using System.Windows.Input;



namespace rma.Controls
{
    /// <summary>
    /// Interaction logic for Toolbar.xaml
    /// </summary>
    public partial class PopToolbar : UserControl
    {
        private string _toolbarTitle = "";
        private ToolbarIcons _toolbarClick;

        public PopToolbar()
        {
            Loaded += ToolbarLoaded;
            Unloaded += ToolbarUnloaded;

            InitializeComponent();

            if (ApplicationState.Current.CorePage != null)
            {
                ApplicationState.Current.CorePage.toolbar = this;
                ApplicationState.Current.CorePage.ChangeToolBarDisplay += ChangeDisplay;
                ChangeDisplay();


            }
            else
            {
                paginate.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        public string ToolbarTitle
        {
            get { return _toolbarTitle; }
            set
            {
                if (_toolbarTitle != value)
                {
                    _toolbarTitle = value;
                }
            }
        }

        private void ToolbarUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ToolbarLoaded;
            Unloaded -= ToolbarUnloaded;
        }

        private void ToolbarLoaded(object sender, RoutedEventArgs e)
        {

        }




        private void ChangeDisplay()
        {


            if (ApplicationState.Current.CorePage.IsPopup)
            {
                //CloseRec.Visibility = Visibility.Visible;
                CloseButton.Visibility = Visibility.Visible;
                SubmitExitButton.Visibility = Visibility.Visible;
                SubmitExitButtonLine.Visibility = Visibility.Visible;
            }

            if (ApplicationState.Current.CorePage.PageTitle != null)
                Title.Text = ApplicationState.Current.CorePage.PageTitle.Trim();
            FormName.Text = ApplicationState.Current.CorePage.FormName;

            Mode.Text = "Mode: " + ApplicationState.Current.CorePage.Mode.ToString();

            switch (ApplicationState.Current.CorePage.Mode)
            {
                case PageModeTypes.Change:


                    if (ApplicationState.Current.CorePage.UseAcceptProcessing && ApplicationState.Current.CorePage.IsAppend)
                    {


                        this.DeleteButton.IsEnabled = false;
                        this.FindButton.IsEnabled = false;
                        this.AddButton.IsEnabled = false;
                        this.CancelButton.IsEnabled = true;
                        this.SubmitButton.IsEnabled = false;
                        this.SubmitExitButton.IsEnabled = false;

                    }
                    else
                    {
                        {
                            if (ApplicationState.Current.CorePage.FindActivity && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.FindButton.IsEnabled = true;
                            }
                            else
                            {
                                this.FindButton.IsEnabled = false;
                            }
                            if ((!ApplicationState.Current.CorePage.DisableEntry) && ApplicationState.Current.CorePage.EntryActivity && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.AddButton.IsEnabled = true;
                            }
                            else
                            {
                                this.AddButton.IsEnabled = false;
                            }
                            if ((((!ApplicationState.Current.CorePage.DisableUpdate) && ApplicationState.Current.CorePage.ChangeActivity) || ((!ApplicationState.Current.CorePage.DisableDelete) && ApplicationState.Current.CorePage.DeleteActivity)) && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.SubmitButton.IsEnabled = true;
                                this.SubmitExitButton.IsEnabled = true;
                            }
                            else
                            {
                                this.SubmitButton.IsEnabled = false;
                                this.SubmitExitButton.IsEnabled = false;
                            }
                            this.CancelButton.IsEnabled = true;

                            if ((!ApplicationState.Current.CorePage.DisableDelete) && ApplicationState.Current.CorePage.DeleteActivity && ApplicationState.Current.CorePage.PrimaryFile.TrimEnd().Length > 0 && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.DeleteButton.IsEnabled = true;
                            }
                            else
                            {
                                this.DeleteButton.IsEnabled = false;
                            }
                        }
                    }

                    break;
                case PageModeTypes.Correct:


                    this.CancelButton.IsEnabled = true;
                    this.SubmitButton.IsEnabled = true;
                    this.SubmitExitButton.IsEnabled = true;
                    if (ApplicationState.Current.CorePage.IsDirty || !ApplicationState.Current.CorePage.EnableNumberedDesigners)
                    {

                        this.FindButton.IsEnabled = false;
                        this.AddButton.IsEnabled = false;
                    }
                    else
                    {
                        {
                            if (ApplicationState.Current.CorePage.FindActivity && ApplicationState.Current.CorePage.PrimaryFile.TrimEnd().Length > 0 && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.FindButton.IsEnabled = true;
                            }
                            else
                            {
                                this.FindButton.IsEnabled = false;
                            }
                            if (((!ApplicationState.Current.CorePage.DisableEntry) && ApplicationState.Current.CorePage.EntryActivity) && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.AddButton.IsEnabled = true;
                            }
                            else
                            {
                                this.AddButton.IsEnabled = false;
                            }
                            if ((((!ApplicationState.Current.CorePage.DisableUpdate) && ApplicationState.Current.CorePage.ChangeActivity) || (((!ApplicationState.Current.CorePage.DisableDelete) && ApplicationState.Current.CorePage.DeleteActivity)) || !ApplicationState.Current.CorePage.DeleteActivity) && !ApplicationState.Current.CorePage.HasErrorInFind)
                            {
                                this.SubmitButton.IsEnabled = true;
                                this.SubmitExitButton.IsEnabled = true;
                            }
                            else
                            {
                                this.SubmitButton.IsEnabled = false;
                                this.SubmitExitButton.IsEnabled = false;
                            }
                            if ((!ApplicationState.Current.CorePage.DisableDelete) && ApplicationState.Current.CorePage.DeleteActivity && ApplicationState.Current.CorePage.PrimaryFile.TrimEnd().Length > 0)
                            {
                                this.DeleteButton.IsEnabled = true;
                            }
                            else
                            {
                                this.DeleteButton.IsEnabled = false;
                            }
                        }
                    }

                    break;
                case PageModeTypes.Entry:


                    this.DeleteButton.IsEnabled = false;
                    this.FindButton.IsEnabled = false;
                    this.AddButton.IsEnabled = false;
                    this.CancelButton.IsEnabled = true;
                    if (ApplicationState.Current.CorePage.UseAcceptProcessing)
                    {
                        this.SubmitButton.IsEnabled = false;
                        this.SubmitExitButton.IsEnabled = false;
                    }
                    else
                    {
                        this.SubmitButton.IsEnabled = true;
                        this.SubmitExitButton.IsEnabled = true;
                    }

                    break;
                case PageModeTypes.Find:


                    this.DeleteButton.IsEnabled = false;
                    this.FindButton.IsEnabled = false;
                    this.AddButton.IsEnabled = false;
                    this.CancelButton.IsEnabled = true;
                    if (ApplicationState.Current.CorePage.UseAcceptProcessing)
                    {
                        this.SubmitButton.IsEnabled = false;
                        this.SubmitExitButton.IsEnabled = false;
                    }
                    else
                    {
                        this.SubmitButton.IsEnabled = true;
                        this.SubmitExitButton.IsEnabled = true;
                    }

                    break;
                case PageModeTypes.Select:


                    this.DeleteButton.IsEnabled = false;
                    this.FindButton.IsEnabled = false;
                    this.AddButton.IsEnabled = false;
                    this.CancelButton.IsEnabled = true;
                    this.SubmitButton.IsEnabled = true;
                    this.SubmitExitButton.IsEnabled = true;

                    break;
                case PageModeTypes.NoMode:
                case PageModeTypes.Unknown:


                    this.SubmitButton.IsEnabled = false;
                    this.SubmitExitButton.IsEnabled = false;
                    this.CancelButton.IsEnabled = false;
                    {
                        if (ApplicationState.Current.CorePage.FindActivity)
                        {
                            this.FindButton.IsEnabled = true;
                        }
                        else
                        {
                            this.FindButton.IsEnabled = false;
                        }
                        if (((!ApplicationState.Current.CorePage.DisableEntry) && ApplicationState.Current.CorePage.EntryActivity))
                        {
                            this.AddButton.IsEnabled = true;
                        }
                        else
                        {
                            this.AddButton.IsEnabled = false;
                        }
                    }

                    this.DeleteButton.IsEnabled = false;
                    break;
                default:

                    break;
            }

            if (ApplicationState.Current.CorePage.EnableNavigation == false || ApplicationState.Current.CorePage.ScreenType == ScreenTypes.Grid)
            {
                paginate.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {

                var intNavigationRecordCount = ApplicationState.Current.CorePage.NavigationRecordCount;
                var intCurrentRecordNumber = ApplicationState.Current.CorePage.CurrentRecordNumber;

                CurrentToolbarRecord.Text = intCurrentRecordNumber.ToString();
                TotalToolbarItemCount.Text = intNavigationRecordCount.ToString();


                if (intNavigationRecordCount < 2 || intCurrentRecordNumber == 0)
                {
                    paginate.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    paginate.Visibility = System.Windows.Visibility.Visible;

                    if (intCurrentRecordNumber == 1 || intCurrentRecordNumber == 0)
                    {
                        FirstPageButton.IsEnabled = false;
                        PreviousPageButton.IsEnabled = false;
                        NextPageButton.IsEnabled = true;
                        LastPageButton.IsEnabled = true;
                    }
                    else if (intCurrentRecordNumber == intNavigationRecordCount)
                    {
                        FirstPageButton.IsEnabled = true;
                        PreviousPageButton.IsEnabled = true;
                        NextPageButton.IsEnabled = false;
                        LastPageButton.IsEnabled = false;
                    }
                    else
                    {
                        FirstPageButton.IsEnabled = true;
                        PreviousPageButton.IsEnabled = true;
                        NextPageButton.IsEnabled = true;
                        LastPageButton.IsEnabled = true;
                    }
                }
            }



        }


        private void InquireButton_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.CorePage.RunningDesigner = null;
            _toolbarClick = ToolbarIcons.Find;
            CallPage_Load();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = ((App)Application.Current).MainWindow;
            if (main != null)
            {
                if (main.NotificationMessage.Visibility == Visibility.Visible && main.NotificationMessageImageError.Visibility == Visibility.Visible)
                {
                    return;
                }
                else if (main.NotificationMessage.Visibility == Visibility.Visible)
                {
                    main.HideAlert();
                }
            }

            _toolbarClick = ToolbarIcons.Submit;
            CallPage_Load();
        }

        private void SubmitExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = ((App)Application.Current).MainWindow;
            if (main != null)
            {
                if (main.NotificationMessage.Visibility == Visibility.Visible && main.NotificationMessageImageError.Visibility == Visibility.Visible)
                {
                    return;
                }
                else if (main.NotificationMessage.Visibility == Visibility.Visible)
                {
                    main.HideAlert();
                }
            }
            ApplicationState.Current.CorePage.IsDirty = false;
            _toolbarClick = ToolbarIcons.SubmitExit;
            CallPage_Load();


        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var helpWindow = new HelpWindow("Screen Help: " + Title, "This is help \n more help") { Owner = Application.Current.MainWindow };
            helpWindow.ShowDialog();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = ((App)Application.Current).MainWindow;
            main.taskPanel.MenuButton1.Visibility = Visibility.Collapsed;
            main.taskPanel.MenuButton2.Visibility = Visibility.Visible;
            main.taskPanel2.MenuButton1.Visibility = Visibility.Visible;
            main.taskPanel2.MenuButton2.Visibility = Visibility.Collapsed;
            main.MenuButtonClick();
            PrintDialog dlg = new PrintDialog();
            Nullable<Boolean> print = dlg.ShowDialog();
            if (print == true)
            {
                double oldWidth = main.ActualWidth;
                double oldHeight = main.ActualHeight;
                dlg.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                System.Printing.PrintCapabilities capabilities = dlg.PrintQueue.GetPrintCapabilities(dlg.PrintTicket);
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / main.ActualWidth, capabilities.PageImageableArea.ExtentHeight / main.ActualHeight);
                main.LayoutTransform = new ScaleTransform(scale, scale);
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
                main.Measure(sz);
                main.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));
                dlg.PrintVisual(main, "");
                scale = Math.Min(oldWidth, oldHeight);
                main.LayoutTransform = new ScaleTransform(oldWidth, oldHeight);
                sz = new Size(oldWidth, oldHeight);
                main.Measure(sz);
                main.Arrange(new Rect(new Point(oldWidth, oldHeight), sz));
                main.InvalidateVisual();
            }
            main.taskPanel.MenuButton1.Visibility = Visibility.Collapsed;
            main.taskPanel.MenuButton2.Visibility = Visibility.Visible;
            main.taskPanel2.MenuButton1.Visibility = Visibility.Visible;
            main.taskPanel2.MenuButton2.Visibility = Visibility.Collapsed;
            main.MenuButtonClick();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CancelButton.Focus();

            ApplicationState.Current.CorePage.RunningDesigner = null;
            ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
            ApplicationState.Current.CorePage.ClearSequence();
            ApplicationState.Current.CorePage.ResetGridVariables();
            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel;
            ApplicationState.Current.CorePage.CallPerformOperation = true;
            ApplicationState.Current.CorePage.ResetAppendVariables();
            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Cancel;
            ApplicationState.Current.CorePage.CallSetVariables();

            MainWindow main = ((App)Application.Current).MainWindow;
            if (main != null)
            {
                if (main.NotificationMessage.Visibility == Visibility.Visible)
                {
                    main.HideAlert();
                }
            }

            _toolbarClick = ToolbarIcons.NotSet;

            ApplicationState.Current.CorePage.Page_Load();

            var _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            _dt.Tick += ContinueCancel;
            _dt.Start();
        }

        private void ContinueCancel(object sender, EventArgs e)
        {

            var dt = (DispatcherTimer)sender;
            if (dt != null)
                dt.Stop();
            dt = null;

            Mouse.OverrideCursor = Cursors.Arrow;


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = ((App)Application.Current).MainWindow;
            if (main != null)
            {
                if (main.NotificationMessage.Visibility == Visibility.Visible)
                {
                    main.HideAlert();
                }
            }

            var message = "Do you wish to delete this record?";
            if (ApplicationState.Current.CorePage.ScreenType == ScreenTypes.Grid)
            {
                message = "Do you wish to delete these records?";
            }
            var confirm = new ConfirmationDialog("Delete", message, "", DialogButtons.YesNo);

            confirm.Owner = Application.Current.MainWindow;
            confirm.ShowDialog();

            if (confirm.DialogResult == true)
            {
                _toolbarClick = ToolbarIcons.Delete;
                ApplicationState.Current.CorePage.RunningDesigner = null;
                CallPage_Load();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.CorePage.RunningDesigner = null;
            _toolbarClick = ToolbarIcons.Add;
            CallPage_Load();
        }



        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.CorePage.RunningDesigner = null;
            FirstPageButton.IsEnabled = false;
            _toolbarClick = ToolbarIcons.First;
            CallPage_Load();

        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.CorePage.RunningDesigner = null;
            PreviousPageButton.IsEnabled = false;
            _toolbarClick = ToolbarIcons.Previous;
            CallPage_Load();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.CorePage.RunningDesigner = null;
            NextPageButton.IsEnabled = false;
            _toolbarClick = ToolbarIcons.Next;
            CallPage_Load();
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.CorePage.RunningDesigner = null;
            LastPageButton.IsEnabled = false;
            _toolbarClick = ToolbarIcons.Last;
            CallPage_Load();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            _dt.Tick += DtTick;
            _dt.Start();
        }

        private void DtTick(object sender, EventArgs e)
        {

            var dt = (DispatcherTimer)sender;
            if (dt != null)
                dt.Stop();
            dt = null;

            ApplicationState.Current.CorePage.CallExit();


        }

        private void CallPage_Load()
        {

            DispatcherTimer dt;

           

            if (_toolbarClick == ToolbarIcons.Find || _toolbarClick == ToolbarIcons.Add)
            {

                var exitreturn = false;

                if (_toolbarClick != ToolbarIcons.Submit && _toolbarClick != ToolbarIcons.SubmitExit && ApplicationState.Current.CorePage != null && ApplicationState.Current.CorePage.IsDirty)
                {
                    var confirmation = new ConfirmationDialog(Labels.UnsavedUpdatesExist,
                                                              "Unsaved update Exist." + Environment.NewLine +
                                                              "Do you wish to continue?", "",
                                                              DialogButtons.YesNo);


                    confirmation.Closed += delegate
                    {
                        if (confirmation.DialogResult != null &&
                            confirmation.DialogResult == false)
                        {
                            exitreturn = true;
                        }
                    };

                    confirmation.Owner = Application.Current.MainWindow;
                    confirmation.ShowDialog();
                }

                if (exitreturn)
                    return;

                var tclick = _toolbarClick;

                ApplicationState.Current.CorePage.RunningDesigner = null;
                ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
                ApplicationState.Current.CorePage.ClearSequence();
                ApplicationState.Current.CorePage.ResetGridVariables();
                ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel;
                ApplicationState.Current.CorePage.CallPerformOperation = true;
                ApplicationState.Current.CorePage.ResetAppendVariables();
                ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Cancel;
                ApplicationState.Current.CorePage.CallSetVariables();
                _toolbarClick = ToolbarIcons.NotSet;
                ApplicationState.Current.CorePage.Page_Load();

                _toolbarClick = tclick;
                dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
                dt.Tick += EndCallPage_Load;
                dt.Start();
                return;
            }

            if (ApplicationState.Current.CorePage.Mode == PageModeTypes.NoMode)
            {

                EndCallPage_Load(null, null);
                return;
            }

            switch (_toolbarClick)
            {
                case ToolbarIcons.Last:
                case ToolbarIcons.Next:
                case ToolbarIcons.Previous:
                case ToolbarIcons.First:
                    dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
                    dt.Tick += EndCallPage_Load;
                    dt.Start();
                    break;
                case ToolbarIcons.Find:
                case ToolbarIcons.Submit:
                case ToolbarIcons.Add:
                    var t = 200;
                    UIElement elementWithFocus = (UIElement)System.Windows.Input.Keyboard.FocusedElement;
                    if (elementWithFocus != null)
                    {
                        if (elementWithFocus.GetType().ToString() == "System.Windows.Controls.TextBox")
                        {
                            elementWithFocus = ((System.Windows.Controls.TextBox)elementWithFocus).ParentOfType<Core.Windows.UI.Core.Windows.UI.ComboBox>();
                        }
                        else if (elementWithFocus.GetType().ToString() == "System.Windows.Controls.Primitives.DatePickerTextBox")
                        {
                            elementWithFocus = ((System.Windows.Controls.Primitives.DatePickerTextBox)elementWithFocus).ParentOfType<DateControl>();
                        }
                        if (elementWithFocus.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.TextBox")
                        {
                            if (((Core.Windows.UI.Core.Windows.UI.TextBox)elementWithFocus).Text !=
                                ((Core.Windows.UI.Core.Windows.UI.TextBox)elementWithFocus).OldText)
                                t = 2000;
                        }
                        else if (elementWithFocus.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.DateControl")
                        {
                            if (((Core.Windows.UI.Core.Windows.UI.DateControl)elementWithFocus).Text !=
                                ((Core.Windows.UI.Core.Windows.UI.DateControl)elementWithFocus).OldText)
                                t = 2000;
                        }
                        else if (elementWithFocus.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.ComboBox")
                        {
                            if (((Core.Windows.UI.Core.Windows.UI.ComboBox)elementWithFocus).Text !=
                                ((Core.Windows.UI.Core.Windows.UI.ComboBox)elementWithFocus).OldText)
                                t = 2000;
                        }
                    }
                    dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, t) };
                    dt.Tick += EndCallPage_Load;
                    dt.Start();
                    break;
                default:
                    dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 600) };
                    dt.Tick += EndCallPage_Load;
                    dt.Start();
                    break;
            }

        }
        private void EndCallPage_Load(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            var exitreturn = false;

            if (_toolbarClick != ToolbarIcons.Submit && ApplicationState.Current.CorePage != null && ApplicationState.Current.CorePage.IsDirty)
            {
                var confirmation = new ConfirmationDialog(Labels.UnsavedUpdatesExist,
                                                          "Unsaved update Exist." + Environment.NewLine +
                                                          "Do you wish to continue?", "",
                                                          DialogButtons.YesNo);


                confirmation.Closed += delegate
                {
                    if (confirmation.DialogResult != null &&
                        confirmation.DialogResult == false)
                    {
                        exitreturn = true;
                    }
                };

                confirmation.Owner = Application.Current.MainWindow;
                confirmation.ShowDialog();
            }

            if (!exitreturn)
            {

                MainWindow main = ((App)Application.Current).MainWindow;
                if (main != null)
                {
                    if (main.NotificationMessage.Visibility == Visibility.Visible)
                    {
                        main.HideAlert();
                    }
                }

                ApplicationState.Current.CorePage.RunningDesigner = null;

                switch (_toolbarClick)
                {
                    case ToolbarIcons.Last:
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Last;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ResetAppendVariables();
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Last;
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;

                        break;

                    case ToolbarIcons.Next:
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Next;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ResetAppendVariables();
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Next;
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;

                        break;

                    case ToolbarIcons.Previous:
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Previous;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ResetAppendVariables();
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Previous;
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;

                        break;

                    case ToolbarIcons.First:
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.First;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ResetAppendVariables();
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.First;
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;

                        break;

                    case ToolbarIcons.Add:
                        ApplicationState.Current.CorePage.ClearSequence();
                        ApplicationState.Current.CorePage.ResetGridVariables();
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Entry;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Add;
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
                        ApplicationState.Current.CorePage.CallSetVariables();

                        break;

                    case ToolbarIcons.Delete:
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
                        ApplicationState.Current.CorePage.ClearSequence();
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Delete;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ResetAppendVariables();
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Delete;
                        break;

                    case ToolbarIcons.Submit:
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Submit;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.Submit = true;
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Submit;
                        break;

                    case ToolbarIcons.SubmitExit:
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Submit;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.Submit = true;
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Submit;

                        var _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 800) };
                        _dt.Tick += DtTick;
                        _dt.Start();
                        break;

                    case ToolbarIcons.Find:
                        ApplicationState.Current.CorePage.ClearSequence();
                        ApplicationState.Current.CorePage.ResetGridVariables();
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Find;
                        ApplicationState.Current.CorePage.CallPerformOperation = true;
                        ApplicationState.Current.CorePage.ResetAppendVariables();
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.ToolbarClick;
                        ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Find;
                        ApplicationState.Current.CorePage.CallSetVariables();

                        break;
                }

                _toolbarClick = ToolbarIcons.NotSet;

                ApplicationState.Current.CorePage.Page_Load();
            }

        }

        public void ToolBarKeyDown(object sender, KeyEventArgs e)
        {
            if (FindButton.IsEnabled && e.Key == Key.F && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                InquireButton_Click(null, null);
            }
            else if (AddButton.IsEnabled && e.Key == Key.N && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                AddButton_Click(null, null);
            }

            else if (SubmitButton.IsEnabled && e.Key == Key.U && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                SubmitButton_Click(null, null);
            }

            else if (SubmitExitButton.IsEnabled && e.Key == Key.R && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                SubmitButton_Click(null, null);
            }

            else if (DeleteButton.IsEnabled && e.Key == Key.D && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                DeleteButton_Click(null, null);
            }

            else if (CancelButton.IsEnabled && e.Key == Key.Oem2 && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                CancelButton_Click(null, null);
            }
            else if (NextPageButton.IsEnabled && e.Key == Key.Right && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                NextPageButton_Click(null, null);
            }
            else if (LastPageButton.IsEnabled && e.Key == Key.Up && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                LastPageButton_Click(null, null);
            }
            else if (PreviousPageButton.IsEnabled && e.Key == Key.Left && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                PreviousPageButton_Click(null, null);
            }
            else if (FirstPageButton.IsEnabled && e.Key == Key.Down && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                FirstPageButton_Click(null, null);
            }
            else if (PrintButton.IsEnabled && e.Key == Key.P && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                PrintButton_Click(null, null);
            }
            else if (HelpButton.IsEnabled && e.Key == Key.H && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                HelpButton_Click(null, null);
            }
            else if (CloseButton.IsEnabled && e.Key == Key.X && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                CloseButton_Click(null, null);
            }

            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                e.Handled = true;
            }

        }

    }
}