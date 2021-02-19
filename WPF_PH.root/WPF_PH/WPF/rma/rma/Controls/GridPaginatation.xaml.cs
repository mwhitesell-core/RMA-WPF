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
    public partial class GridPaginatation : UserControl
    {
        public GridPaginatation()
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
           

            if (ApplicationState.Current.CorePage.TotalPages > 1 && ApplicationState.Current.CorePage.Mode != PageModeTypes.NoMode)
            {
                Visibility = Visibility.Visible;

                TotalToolbarItemCount.Text = ApplicationState.Current.CorePage.TotalGridRecords.ToString();
                //ToolBarPage.Text = ApplicationState.Current.CorePage.CurrentPageNumber.ToString();
                TotalPageCount.Text = ApplicationState.Current.CorePage.TotalPages.ToString();

                if (ApplicationState.Current.CorePage.CurrentPageSetNumber == 0)
                    ApplicationState.Current.CorePage.CurrentPageSetNumber = 1;

                if (ApplicationState.Current.CorePage.CurrentPageSetNumber == 1)
                {
                    FirstButton.IsEnabled = false;
                    PreviousButton.IsEnabled = false;
                }
                else
                {
                    FirstButton.IsEnabled = true;
                    PreviousButton.IsEnabled = true;
                }

                if (ApplicationState.Current.CorePage.CurrentPageSetNumber == ApplicationState.Current.CorePage.TotalPageSets)
                {
                    LastButton.IsEnabled = false;
                    NextButton.IsEnabled = false;
                }
                else
                {
                    LastButton.IsEnabled = true;
                    NextButton.IsEnabled = true;
                }


                OneButton.Visibility = Visibility.Collapsed;
                TwoButton.Visibility = Visibility.Collapsed;
                ThreeButton.Visibility = Visibility.Collapsed;
                FourButton.Visibility = Visibility.Collapsed;
                FiveButton.Visibility = Visibility.Collapsed;
                SixButton.Visibility = Visibility.Collapsed;
                SevenButton.Visibility = Visibility.Collapsed;
                EightButton.Visibility = Visibility.Collapsed;
                NineButton.Visibility = Visibility.Collapsed;
                TenButton.Visibility = Visibility.Collapsed;

                int start = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10));

                for (int i = start; i < ApplicationState.Current.CorePage.TotalPages; i++)
                {
                    switch (i.ToString().PadLeft(10,'0').Substring(9))
                    {
                        case "0":
                            OneButton.Visibility = Visibility.Visible;
                            onetext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 1).ToString();
                            break;
                        case "1":
                            TwoButton.Visibility = Visibility.Visible;
                            twotext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 2).ToString();
                            break;
                        case "2":
                            ThreeButton.Visibility = Visibility.Visible;
                            threetext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 3).ToString();
                            break;
                        case "3":
                            FourButton.Visibility = Visibility.Visible;
                            fourtext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 4).ToString();
                            break;
                        case "4":
                            FiveButton.Visibility = Visibility.Visible;
                            fivetext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 5).ToString();
                            break;
                        case "5":
                            SixButton.Visibility = Visibility.Visible;
                            sixtext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 6).ToString();
                            break;
                        case "6":
                            SevenButton.Visibility = Visibility.Visible;
                            seventext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 7).ToString();
                            break;
                        case "7":
                            EightButton.Visibility = Visibility.Visible;
                            eighttext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 8).ToString();
                            break;
                        case "8":
                            NineButton.Visibility = Visibility.Visible;
                            ninetext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 9).ToString();
                            break;
                        case "9":
                            TenButton.Visibility = Visibility.Visible;
                            tentext.Text = (((ApplicationState.Current.CorePage.CurrentPageSetNumber - 1) * 10) + 10).ToString();
                            break;
                       
                    }
                }

                OneButton.IsEnabled = true;
                TwoButton.IsEnabled = true;
                ThreeButton.IsEnabled = true;
                FourButton.IsEnabled = true;
                FiveButton.IsEnabled = true;
                SixButton.IsEnabled = true;
                SevenButton.IsEnabled = true;
                EightButton.IsEnabled = true;
                NineButton.IsEnabled = true;
                TenButton.IsEnabled = true;

                switch ((ApplicationState.Current.CorePage.CurrentPageNumber - 1).ToString().PadLeft(10, '0').Substring(9))
                {
                    case "0":
                        OneButton.IsEnabled = false;
                        break;
                    case "1":
                        TwoButton.IsEnabled = false;
                        break;
                    case "2":
                        ThreeButton.IsEnabled = false;
                        break;
                    case "3":
                        FourButton.IsEnabled = false;
                        break;
                    case "4":
                        FiveButton.IsEnabled = false;
                        break;
                    case "5":
                        SixButton.IsEnabled = false;
                        break;
                    case "6":
                        SevenButton.IsEnabled = false;
                        break;
                    case "7":
                        EightButton.IsEnabled = false;
                        break;
                    case "8":
                        NineButton.IsEnabled = false;
                        break;
                    case "9":
                        TenButton.IsEnabled = false;
                        break;
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

        private void FirstButton_Click(object sender, RoutedEventArgs e)
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
            ApplicationState.Current.CorePage.PageClick = PaginationClick.First;
            ApplicationState.Current.CorePage.ClearSequence();
           
            CallPage_Load();
        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
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
           
            CallPage_Load();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
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
            ApplicationState.Current.CorePage.PageClick = PaginationClick.Previous;
            ApplicationState.Current.CorePage.ClearSequence();
           
            CallPage_Load();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
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

        private void pagbutton_click(int intbutton)
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

            ApplicationState.Current.CorePage.PageClick = PaginationClick.GoTo;
            ApplicationState.Current.CorePage.CurrentPageNumber = intbutton;


            //NextPageButton.IsEnabled = false;
            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None;
            ApplicationState.Current.CorePage.CallPerformOperation = true;
            ApplicationState.Current.CorePage.ResetAppendVariables();
            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Unknown;
            ApplicationState.Current.CorePage.PageActionType = PageActionType.PaginationClick;
            ApplicationState.Current.CorePage.ClearSequence();
           
            CallPage_Load();
        }
        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(onetext.Text));
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(twotext.Text));
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(threetext.Text));
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(fourtext.Text));
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(fivetext.Text));
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(sixtext.Text));
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(seventext.Text));
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(eighttext.Text));
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(ninetext.Text));
        }

        private void TenButton_Click(object sender, RoutedEventArgs e)
        {
            pagbutton_click(Convert.ToInt16(tentext.Text));
        }
    }
}
