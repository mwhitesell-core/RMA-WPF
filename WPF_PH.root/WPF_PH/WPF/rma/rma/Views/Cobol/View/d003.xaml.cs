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
using Core.Framework;
using Core.Framework.Core.Framework;

namespace rma.Views
{
    /// <summary>
    /// Interaction logic for d003.xaml
    /// </summary>
    public partial class d003 : BasePage
    {
        D003ViewModel _objD003ViewModel = null;
        public d003()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objD003ViewModel = null;
            _objD003ViewModel = new D003ViewModel();
            DataContext = null;
            DataContext = _objD003ViewModel;
            _objD003ViewModel.PromptExit = true;
            _objD003ViewModel.EscapeKeyValue = -1;
            _objD003ViewModel.LayoutRoot = LayoutRoot;
            _objD003ViewModel.ScreenDataCollection = _objD003ViewModel.ScreenSection();
            //_objD003ViewModel.GridAddControl();
            _objD003ViewModel.mainline();

            _objD003ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };

            _objD003ViewModel.RunM088 += delegate
            {
                object[] arrRunScreen = { };
                RunScreen(new Billing_M088_1A(), RunScreenModes.Find, ref arrRunScreen);
            };

            _objD003ViewModel.RunD003_1 += delegate
            {
                 object[] arrRunScreen = { };
                RunScreen(new Billing_D003_1A(), RunScreenModes.Find, ref arrRunScreen);
            };

            _objD003ViewModel.RunM010 += delegate
           {
               object[] arrRunScreen = { };
               RunScreen(new Billing_M010(), RunScreenModes.Find, ref arrRunScreen);
           };
        }
       
        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
            _objD003ViewModel.EscapeKeyValue = -1;
            if (e.Key.Equals(Key.Return))
            {
                _objD003ViewModel.PromptExit = true;
                _objD003ViewModel.EscapeKeyValue = 0;  // COBOL Code  Enter Key

            }
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objD003ViewModel != null)
            {
                _objD003ViewModel.PromptExit = true;
                _objD003ViewModel.IsExitForm = true;

                _objD003ViewModel.ClearControls();
                LayoutRoot.Children.Clear();               
                _objD003ViewModel.destroy_objects();
                _objD003ViewModel = null;
                DataContext = null;
                ClearMemory();               
            }
        }
    }
}
