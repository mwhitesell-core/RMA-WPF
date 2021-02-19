using Core.Resources;
using Core.Windows.UI.Core.Windows.UI;
using rma.Views;
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace rma.Controls
{
    public delegate void TaskSelectionChangedEvent(string uriString, string header, string mode);
    public delegate void AppChangeEvent(string app);

    /// <summary>
    /// Interaction logic for TaskPanel.xaml
    /// </summary>
    public partial class TaskPanel : UserControl
    {
        public CoreTreeViewItem _treeViewItem;
        private DispatcherTimer _dt;

        public TaskPanel()
        {
            InitializeComponent();
            PreviewKeyDown += TaskPanel_PreviewKeyDown;


            _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 500) };
            _dt.Tick += setfocustree;
            _dt.Start();
        }

        public void setvisibility()
        {
        }

        private void checkchildren(CoreTreeViewItem c)
        {
            if (Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity != null &&
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity.Count > 0)
            {
                ArrayList re = new ArrayList();

                for (int i = 0; i <= c.Items.Count - 1; i++)
                {
                    if (((CoreTreeViewItem)c.Items[i]).Tag == null)
                    {
                        ((CoreTreeViewItem)c.Items[i]).Tag = "";
                    }

                    if (Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity.Contains(((CoreTreeViewItem)c.Items[i]).Tag.ToString().ToUpper()))
                    {
                        re.Add(((CoreTreeViewItem)c.Items[i]));
                    }
                    else
                    {
                        ((CoreTreeViewItem)c.Items[i]).Visibility = Visibility.Visible;
                    }

                    if (((CoreTreeViewItem)c.Items[i]).HasItems)
                    {
                        checkchildren(((CoreTreeViewItem)c.Items[i]));
                    }
                }

                foreach (var r in re)
                {
                    c.Items.Remove(r);
                }

                UpdateLayout();
            }
        }

        private void setfocustree(object sender, EventArgs e)
        {
            var dt = (DispatcherTimer)sender;
            if (dt != null)
                dt.Stop();
            dt = null;

            if(this.TreeView != null && this.TreeView.Items.Count > 0 && this.TreeView.Items[0] != null)
            ((CoreTreeViewItem)this.TreeView.Items[0]).Focus();
        }

        public event TaskSelectionChangedEvent OnTaskSelectionChanged;
        public event AppChangeEvent OnAppChange;

        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            if (ApplicationState.Current.HasError) return;

            MainWindow main = ((App)Application.Current).MainWindow;
            main.MenuButtonClick();
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cancel = false;

            if (AppSelection.SelectedIndex == ApplicationState.Current.Selected)
                return;

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
                            cancel = true;
                        }
                    };

                    confirmation.Owner = Application.Current.MainWindow;
                    confirmation.ShowDialog();
                }

            if (cancel)
            {
                AppSelection.SelectedIndex = ApplicationState.Current.Selected;
            }
            else
            {
                OnTaskSelectionChanged("home", "Home", "");

                ApplicationState.Current.Selected = ((System.Windows.Controls.ComboBox)sender).SelectedIndex;
                OnAppChange?.Invoke(((System.Windows.Controls.ContentControl)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString().Replace(" ",""));
            }
        }

        private void CurrentDirectory_LostFocus(object sender, RoutedEventArgs re)
        {
            Environment.SetEnvironmentVariable("VS_DIRECTORY", CurrentDirectory.Text.Trim());
        }
        
        private void CurrentDirectory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cancel = false;

            if (CurrentDirectory.SelectedIndex == ApplicationState.Current.Selected)
            {
                if (Environment.GetEnvironmentVariable("CURRENTDIRECTORY") != null)
                {
                    Environment.SetEnvironmentVariable("VS_DIRECTORY", Environment.GetEnvironmentVariable("CURRENTDIRECTORY").Substring(Environment.GetEnvironmentVariable("CURRENTDIRECTORY").LastIndexOf("\\") + 1).ToUpper());
                }

                return;
            }

            if (ApplicationState.Current.CorePage != null)
            {
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
                            cancel = true;
                        }
                    };

                    confirmation.Owner = Application.Current.MainWindow;
                    confirmation.ShowDialog();
                }

                if (cancel)
                {
                    CurrentDirectory.SelectedIndex = ApplicationState.Current.Selected;
                }
                else
                {
                    OnTaskSelectionChanged("home", "Home", "");

                    ApplicationState.Current.Selected = CurrentDirectory.SelectedIndex;
                    Environment.SetEnvironmentVariable("VS_DIRECTORY", (((System.Windows.Controls.ComboBox)sender).SelectedItem).ToString().Substring((((System.Windows.Controls.ComboBox)sender).SelectedItem).ToString().LastIndexOf(":") + 1).Trim());
                    OnAppChange?.Invoke(((System.Windows.Controls.ContentControl)(((System.Windows.Controls.ComboBox)sender).SelectedItem)).Content.ToString().Replace(" ", ""));
                }
            }
        }

        private void TaskPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.FocusedElement.GetType().ToString() == "Core.Windows.UI.Core.Windows.UI.CoreTreeViewItem")
            {
                _treeViewItem = (CoreTreeViewItem)(Keyboard.FocusedElement);
                _treeViewItem.IsSelected = true;
                if (!_treeViewItem.HasItems)
                {
                    if (_treeViewItem.Tag != null)
                    {
                        OnTaskSelectionChanged((string)_treeViewItem.Tag, _treeViewItem.Header.ToString(), _treeViewItem.Mode);
                    }
                }
                else
                {
                    if (_treeViewItem.IsExpanded)
                        _treeViewItem.IsExpanded = false;
                    else
                        _treeViewItem.IsExpanded = true;
                }

                ApplicationState.Current.trview = this.TreeView;
            }
        }

        private void CoreTreeViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _treeViewItem = (CoreTreeViewItem)((TreeViewItem)(sender));
            _treeViewItem.IsSelected = true;
            if (!_treeViewItem.HasItems)
            {
                if (_treeViewItem.Tag != null)
                {
                    OnTaskSelectionChanged((string)_treeViewItem.Tag, _treeViewItem.Header.ToString(), _treeViewItem.Mode);
                }
            }

            ApplicationState.Current.trview = this.TreeView;
        }

        public void setfocus()
        {
            _dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 50) };
            _dt.Tick += setfocustime;
            _dt.Start();
        }

        private void setfocustime(object sender, EventArgs e)
        {
            var dt = (DispatcherTimer)sender;
            if (dt != null)
                dt.Stop();
            dt = null;
            if (TreeView != null && TreeView.SelectedItem != null)
            {
                ((CoreTreeViewItem)TreeView.SelectedItem).Focus();
            }
        }

        private void CoreTreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            //if (Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity != null &&
            //    Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity.Count > 0)
            //{

            //    foreach (CoreTreeViewItem t in ((CoreTreeViewItem)sender).Items)
            //    {
            //        if (t.Tag != null)
            //        {
            //            if (Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity.Contains(t.Tag))
            //            {
            //                t.Visibility = Visibility.Collapsed;
            //            }
            //        }
            //    }

            //    UpdateLayout();

            //}
        }

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity != null &&
                               Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity.Count > 0)
                {
                    ArrayList re = new ArrayList();
                    for (int i = 0; i <= ((System.Windows.Controls.ItemsControl)sender).Items.Count - 1; i++)
                    {
                        if (((CoreTreeViewItem)((System.Windows.Controls.ItemsControl)sender).Items[i]).Tag != null)
                        {
                            if (Core.Framework.Core.Windows.Framework.ApplicationState.Current.menusecurity.Contains(((CoreTreeViewItem)((System.Windows.Controls.ItemsControl)sender).Items[i]).Tag.ToString().ToUpper()))
                            {
                                re.Add(((CoreTreeViewItem)((System.Windows.Controls.ItemsControl)sender).Items[i]));
                            }
                            else
                            {
                                checkchildren(((CoreTreeViewItem)((System.Windows.Controls.ItemsControl)sender).Items[i]));
                            }
                        }
                        else
                        {
                        }
                    }

                    foreach (var r in re)
                    {
                        ((System.Windows.Controls.ItemsControl)sender).Items.Remove(r);
                    }
                }
            }

            catch
            {
            }
        }
    }
}