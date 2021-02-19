using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using rma.Views;


namespace rma.Helpers
{
    internal static class GuiUtil
    {
        //private static BorderlessModalWindow nonModal;

        public static bool IsNumeric(string value)
        {
            double number;
            bool result = double.TryParse(value, out number);
            return result;
        }

        public static int NumInt(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;
            return Convert.ToInt32(value);
        }

        public static decimal NumDec(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;
            return Convert.ToDecimal(value);
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

        public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                var controlName = child.GetValue(FrameworkElement.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    var result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public static T FindVisualChildByCoreType<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                var controlName = child.GetValue(FrameworkElement.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    var result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public static List<T> GetVisibleChildrenByType<T>(this UIElement element, Func<T, bool> condition)
            where T : UIElement
        {
            var results = new List<T>();
            GetVisibleChildrenByType(element, condition, results);
            return results;
        }

        private static void GetVisibleChildrenByType<T>(UIElement element, Func<T, bool> condition, List<T> results)
            where T : UIElement
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var child = VisualTreeHelper.GetChild(element, i) as UIElement;
                if (child != null && child.IsVisible)
                {
                    var t = child as T;
                    if (t != null)
                    {
                        if (condition == null)
                            results.Add(t);
                        else if (condition(t))
                            results.Add(t);
                    }
                    GetVisibleChildrenByType(child, condition, results);
                }
            }
        }

        //public static void Call(BaseUserControl baseUserControl, bool borderless = false)
        //{
        //    ApplicationState.Current.PreviousCurrentScreen = ApplicationState.Current.CurrentScreen;
        //    if (borderless)
        //    {
        //        var modalWindow = new BorderlessModalWindow(baseUserControl, null) { Owner = Application.Current.MainWindow };
        //        modalWindow.Closed += BorderlessModalWindowClosed;
        //        var parent = FindParent<BorderlessModalWindow>(baseUserControl);

        //        var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 400) };
        //        dt.Tick += LockMainWindow;
        //        dt.Start();

        //        modalWindow.ShowDialog();
        //        var dt2 = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 10) };
        //        dt2.Tick += UnLockMainWindow;
        //        dt2.Start();
        //    }
        //    else
        //    {
        //        var modalWindow = new ModalWindow(baseUserControl) { Owner = Application.Current.MainWindow };
        //        modalWindow.Closed += ModalWindowClosed;
        //        modalWindow.ShowDialog();
        //    }
        //    ApplicationState.Current.CurrentScreen = ApplicationState.Current.PreviousCurrentScreen;
        //}

        public static void LockMainWindow(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            ((MainWindow)(Application.Current.MainWindow)).RemoveButtons();
            Application.Current.MainWindow.IsHitTestVisible = false;
        }

        public static void UnLockMainWindow(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            ((MainWindow)(Application.Current.MainWindow)).AddButtons();
            Application.Current.MainWindow.IsHitTestVisible = true;
        }

      
    }
}