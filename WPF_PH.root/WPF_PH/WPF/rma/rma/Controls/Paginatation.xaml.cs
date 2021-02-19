using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.Windows.UI.Core.Windows.UI;
using Core.Framework.Core.Framework;
using System.Windows.Threading;

namespace rma.Controls
{
    /// <summary>
    /// Interaction logic for Paginatation.xaml
    /// </summary>
    public partial class Paginatation : UserControl
    {
        public Paginatation()
        {
            InitializeComponent();
            Loaded += Paginatation_Loaded;
            Unloaded += Paginatation_Unloaded;

            if (ApplicationState.Current.CorePage != null)
                ApplicationState.Current.CorePage.ChangeToolBarDisplay += CorePage_ChangeToolBarDisplay;

            Visibility = Visibility.Collapsed;
            
        }

        void CorePage_ChangeToolBarDisplay()
        {
            if (ApplicationState.Current.CorePage.TotalPages > 0)
            {
                Visibility = Visibility.Visible;

                TotalToolbarItemCount.Text = ApplicationState.Current.CorePage.TotalGridRecords.ToString();
                ToolBarPage.Text = ApplicationState.Current.CorePage.CurrentPageNumber.ToString();
                TotalPageCount.Text = ApplicationState.Current.CorePage.TotalPages.ToString();

                if (ApplicationState.Current.CorePage.CurrentPageNumber == ApplicationState.Current.CorePage.TotalPages)
                {
                    LastPageButton.IsEnabled = false;
                    NextPageButton.IsEnabled = false;
                }
                else
                {
                    LastPageButton.IsEnabled = true;
                    NextPageButton.IsEnabled = true;
                }

                if (ApplicationState.Current.CorePage.CurrentPageNumber == 1)
                {
                    FirstPageButton.IsEnabled = false;
                    PreviousPageButton.IsEnabled = false;
                }
                else
                {
                    FirstPageButton.IsEnabled = true;
                    PreviousPageButton.IsEnabled = true;
                }


            }
            else
            {
                Visibility = Visibility.Collapsed;
            }
        }

        void Paginatation_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Paginatation_Loaded;
            Unloaded -= Paginatation_Unloaded;
        }

        void Paginatation_Loaded(object sender, RoutedEventArgs e)
        {
          
           
        }

        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
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

            //NextPageButton.IsEnabled = false;
            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None;
            ApplicationState.Current.CorePage.CallPerformOperation = true;
            ApplicationState.Current.CorePage.ResetAppendVariables();
            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Unknown;
            ApplicationState.Current.CorePage.PageActionType = PageActionType.PaginationClick;
            ApplicationState.Current.CorePage.PageClick = PaginationClick.First ;
            ApplicationState.Current.CorePage.ClearSequence();
            ApplicationState.Current.CorePage.CallSetVariables();
            CallPage_Load();
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
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

            //NextPageButton.IsEnabled = false;
            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None;
            ApplicationState.Current.CorePage.CallPerformOperation = true;
            ApplicationState.Current.CorePage.ResetAppendVariables();
            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Unknown;
            ApplicationState.Current.CorePage.PageActionType = PageActionType.PaginationClick;
            ApplicationState.Current.CorePage.PageClick = PaginationClick.Previous ;
            ApplicationState.Current.CorePage.ClearSequence();
            ApplicationState.Current.CorePage.CallSetVariables();
            CallPage_Load();
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
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

            //NextPageButton.IsEnabled = false;
            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None;
            ApplicationState.Current.CorePage.CallPerformOperation = true;
            ApplicationState.Current.CorePage.ResetAppendVariables();
            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Unknown;
            ApplicationState.Current.CorePage.PageActionType = PageActionType.PaginationClick;
            ApplicationState.Current.CorePage.PageClick = PaginationClick.Last;
            ApplicationState.Current.CorePage.ClearSequence();
            ApplicationState.Current.CorePage.CallSetVariables();
            CallPage_Load();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
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

            //NextPageButton.IsEnabled = false;
            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None;
            ApplicationState.Current.CorePage.CallPerformOperation = true;
            ApplicationState.Current.CorePage.ResetAppendVariables();
            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Unknown;
            ApplicationState.Current.CorePage.PageActionType = PageActionType.PaginationClick;
            ApplicationState.Current.CorePage.PageClick = PaginationClick.Next;
            ApplicationState.Current.CorePage.ClearSequence();
            ApplicationState.Current.CorePage.CallSetVariables();
            CallPage_Load();
        }

        private void CallPage_Load()
        {
            var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
            dt.Tick += EndCallPage_Load;
            dt.Start();

        }

        private void EndCallPage_Load(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;


            ApplicationState.Current.CorePage.Page_Load();

          
        }
    }
}
