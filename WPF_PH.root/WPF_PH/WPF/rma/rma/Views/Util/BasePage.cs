using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace rma.Views
{
    public partial class BasePage : Core.Windows.UI.Core.Windows.UI.Page
    {
        private bool _isPopUp;
        private int designerkey;
        protected bool _promptExit;

        public BasePage()
        {
            InitializeComponent();
            Loaded += BasePage_Loaded;
            PreviewKeyDown += COBOL_KeyCode_Check;
            PreviewKeyDown += BasePage_UpDown;
            PreviewKeyUp += BasePage_PreviewKeyUp;
            ApplicationState.Current.CorePage = null;
        }



        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;
            TraversalRequest request = new TraversalRequest(focusDirection);
            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
            if (elementWithFocus != null)
            {
                elementWithFocus.MoveFocus(request);
            }

            if (ApplicationState.Current.IsQA)
            {
                Grid l = this.FindChild<Grid>("LayoutRoot");
                if (l != null)
                {
                    var bc = new BrushConverter();
                    if (ApplicationState.Current.Selected == 1)
                    {
                        l.Background = (Brush)bc.ConvertFrom("#ffebcc");
                    }
                    else if (ApplicationState.Current.Selected == 2)
                    {
                        l.Background = (Brush)bc.ConvertFrom("#ffebcc");
                    }
                    else
                    {
                        l.Background = (Brush)bc.ConvertFrom("#ffebcc");
                    }
                }
            }



        }

        private rma.Controls.Toolbar tb;
        private rma.Controls.PopToolbar tbp;



        private void BasePage_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
                {
                    var des = this.GetDescendants<Designer>();
                    var count = 0;
                    foreach (Designer d in des.Where(q => q.IsNumberedDesigner == false))
                    {
                        count += 1;
                        if (designerkey == count)
                        {
                            if (d.IsEnabled)
                            {
                                d.Focus();
                                PageActionType = PageActionType.DesignerClick;
                                Page_Load(d);
                            }

                            break;
                        }
                    }
                    designerkey = 0;
                }

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }
        private void BasePage_UpDown(object sender, KeyEventArgs e)
        {

            if ((e.Key == Key.D1 || e.Key == Key.NumPad1) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                if (designerkey == 0)
                    designerkey = 1;
                else
                    designerkey = designerkey * 10 + 1;
            }
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad2) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 2;
                else
                    designerkey = designerkey * 10 + 2;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad3) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 3;
                else
                    designerkey = designerkey * 10 + 3;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad4) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 4;
                else
                    designerkey = designerkey * 10 + 4;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad5) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 5;
                else
                    designerkey = designerkey * 10 + 5;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad6) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 6;
                else
                    designerkey = designerkey * 10 + 6;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad7) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 7;
                else
                    designerkey = designerkey * 10 + 7;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad8) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 8;
                else
                    designerkey = designerkey * 10 + 8;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad9) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 9;
                else
                    designerkey = designerkey * 10 + 9;
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad0) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                if (designerkey == 0)
                    designerkey = 0;
                else
                    designerkey = designerkey * 10 + 0;


            if (e.Key == Key.Enter)
            {
                FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;
                TraversalRequest request = new TraversalRequest(focusDirection);
                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
                if (elementWithFocus != null && (
                    elementWithFocus.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.TextBox" ||
                    elementWithFocus.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.DateControl" ||
                    elementWithFocus.GetType().ToString() == "System.Windows.Controls.Primitives.DatePickerTextBox" ||
                     elementWithFocus.GetType().ToString() == "System.Windows.Controls.TextBox" ||
                    elementWithFocus.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.ComboBox"))
                {
                    _promptExit = true;
                    e.Handled = true;
                    elementWithFocus.MoveFocus(request);
                }
            }
            else if (e.Key == Key.Space)
            {
                if (Window.GetWindow(this).GetType().ToString() == "rma.MainWindow")
                {
                    MainWindow mn = (MainWindow)Window.GetWindow(this);
                    if (mn.NotificationMessage.Visibility == Visibility.Visible)
                    {
                        mn.OnCloseUpdateNotification(null, null);
                    }
                }
                else
                {
                    BorderlessModalWindow mn = (BorderlessModalWindow)Window.GetWindow(this);
                    if (mn.NotificationMessage.Visibility == Visibility.Visible)
                    {
                        mn.OnCloseUpdateNotification(null, null);
                    }
                }
            }
            else if (e.Key == Key.Left && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                if (Window.GetWindow(this).GetType().ToString() == "rma.MainWindow")
                {
                    MainWindow mn = (MainWindow)Window.GetWindow(this);
                    mn.StackPanel_MouseEnter(null, null);
                    mn.taskPanel2.setfocus();
                }
            }
            else if (e.Key == Key.Right && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                if (Window.GetWindow(this).GetType().ToString() == "rma.MainWindow")
                {
                    MainWindow mn = (MainWindow)Window.GetWindow(this);
                    mn.MenuButtonClick();
                }
            }
            else if (e.Key == Key.F1)
            {
                var control = Keyboard.FocusedElement;

                if (control.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.TextBox")
                {
                    var helpWindow = new HelpWindow("Field Help: " + ((Core.Windows.UI.Core.Windows.UI.TextBox)control).FieldName, ((Core.Windows.UI.Core.Windows.UI.TextBox)control).Description.Replace("<BR/>", "\n")) { Owner = Application.Current.MainWindow };
                    helpWindow.ShowDialog();
                }
                else if (control.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.DateControl")
                {
                    var helpWindow = new HelpWindow("Field Help: " + ((Core.Windows.UI.Core.Windows.UI.DateControl)control).FieldName, ((Core.Windows.UI.Core.Windows.UI.DateControl)control).Description.Replace("<BR/>", "\n")) { Owner = Application.Current.MainWindow };
                    helpWindow.ShowDialog();
                }
                else if (control.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.ComboBox")
                {
                    var helpWindow = new HelpWindow("Field Help: " + ((Core.Windows.UI.Core.Windows.UI.ComboBox)control).FieldName, ((Core.Windows.UI.Core.Windows.UI.ComboBox)control).Description.Replace("<BR/>", "\n")) { Owner = Application.Current.MainWindow };
                    helpWindow.ShowDialog();
                }


            }
            if (e.Key == Key.Insert && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                  foreach (var ctl in this.GetDescendants<GridButton>())
                {

                    if (ctl.Name == "btnGridRowNew" && ctl.IsEnabled)
                    {
                        ctl.OnClick(null, null);
                        break;
                    }
                    else if (ctl.Name == "btnGridRowEdit" && ctl.IsEnabled && ((System.Windows.Controls.Image)ctl.Content).Source.ToString().IndexOf("Add.png") >= 0)
                    {
                        ctl.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                        break;
                    }
                }
            }
            else
            {
                if (ApplicationState.Current.CorePage != null)
                {
                    if (ApplicationState.Current.CorePage.toolbar != null)
                    {
                        if (ApplicationState.Current.CorePage.toolbar.GetType().ToString() == "rma.Controls.Toolbar")
                        {
                            tb = (rma.Controls.Toolbar)ApplicationState.Current.CorePage.toolbar;
                            tb.ToolBarKeyDown(sender, e);
                        }
                        else
                        {
                            tbp = (rma.Controls.PopToolbar)ApplicationState.Current.CorePage.toolbar;
                            tbp.ToolBarKeyDown(sender, e);
                        }
                    }
                    else
                    {
                        if (e.Key == Key.P && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
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
                            e.Handled = true;
                            main.taskPanel.MenuButton1.Visibility = Visibility.Visible;
                            main.taskPanel.MenuButton2.Visibility = Visibility.Collapsed;
                            main.taskPanel2.MenuButton1.Visibility = Visibility.Collapsed;
                            main.taskPanel2.MenuButton2.Visibility = Visibility.Visible;
                            main.MenuButtonClick();
                        }
                    }
                }
                else
                {
                    if (e.Key == Key.P && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
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
                        e.Handled = true;
                        main.taskPanel.MenuButton1.Visibility = Visibility.Visible;
                        main.taskPanel.MenuButton2.Visibility = Visibility.Collapsed;
                        main.taskPanel2.MenuButton1.Visibility = Visibility.Collapsed;
                        main.taskPanel2.MenuButton2.Visibility = Visibility.Visible;
                        main.MenuButtonClick();
                    }
                }
            }
        }

        public virtual void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
        }

        #region "Display Alert"

        public override void DisplayAlert(string message, bool autoClose)
        {
            try
            {
                if (IsPopup)
                {
                    BorderlessModalWindow borderlessParent = FindParent<BorderlessModalWindow>(this);
                    if (borderlessParent != null)
                    {
                        borderlessParent.DisplayAlert(message, autoClose);
                        return;
                    }

                    ModalWindow parent = FindParent<ModalWindow>(this);
                    if (parent != null)
                        parent.DisplayAlert(message, autoClose);
                }
                else
                {
                    MainWindow main = ((App)Application.Current).MainWindow;
                    if (main != null) main.DisplayAlert(message, autoClose);
                }

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        protected override void HideAlert()
        {
            try
            {
                if (IsPopup)
                {
                    BorderlessModalWindow borderlessParent = FindParent<BorderlessModalWindow>(this);
                    if (borderlessParent != null)
                    {
                        borderlessParent.HideAlert();
                        return;
                    }

                    ModalWindow parent = FindParent<ModalWindow>(this);
                    if (parent != null)
                        parent.HideAlert();

                }
                else
                {
                    MainWindow main = ((App)Application.Current).MainWindow;
                    if (main != null) main.HideAlert();
                }
            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        #endregion

        public void RunJob(string RunJobName)
        {
            //RunJobName = RunJobName.Trim() + "_" + Process.GetCurrentProcess().Id + "_" + UserID + "_" + ApplicationState.Current.dtNow;
            //object[] arrRunscreen = { RunJobName, JobScriptPath() + RunJobName.Trim() + ".txt" };
            //RunScreen(new JobControl(), RunScreenModes.Entry, ref arrRunscreen);
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            var parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }


        protected override void CallScreen(Core.Windows.UI.Core.Windows.UI.Page baseUserControl, bool borderless)
        {
            Cursor = Cursors.Wait;
            ApplicationState.Current.PreviousCurrentScreen = ApplicationState.Current.CurrentScreen;


            if (borderless && !_isPopUp)
            {
                var parent = FindParent<BorderlessModalWindow>(this);
                var modalWindow = new BorderlessModalWindow(baseUserControl, parent) { Owner = Application.Current.MainWindow };


                var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1) };
                dt.Tick += LockMainWindow;
                dt.Start();
                baseUserControl.IsPopup = true;
                modalWindow.ShowDialog();
                baseUserControl.IsPopup = false;
                var dt2 = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 10) };
                dt2.Tick += UnLockMainWindow;
                dt2.Start();
            }
            else
            {
                baseUserControl.IsPopup = true;
                var modalWindow = new ModalWindow(baseUserControl) { Owner = Application.Current.MainWindow };
                modalWindow.ShowDialog();
                baseUserControl.IsPopup = false;
            }
            ApplicationState.Current.CurrentScreen = ApplicationState.Current.PreviousCurrentScreen;
            Cursor = Cursors.Arrow;
        }

        public void LockMainWindow(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            Application.Current.MainWindow.Opacity = 0.8;

            ((MainWindow)(Application.Current.MainWindow)).RemoveButtons();
            Application.Current.MainWindow.IsHitTestVisible = false;
        }

        public void UnLockMainWindow(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            Application.Current.MainWindow.Opacity = 1;

            ((MainWindow)(Application.Current.MainWindow)).AddButtons();
            Application.Current.MainWindow.IsHitTestVisible = true;
        }

        public void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
