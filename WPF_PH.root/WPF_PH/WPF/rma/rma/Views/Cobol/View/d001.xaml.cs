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
    /// Interaction logic for d001.xaml
    /// </summary>
    public partial class d001 : BasePage
    {
        D001ViewModel _objD001ViewModel = null;
       
        public d001()
        {
            InitializeComponent();            
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;                       
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objD001ViewModel = null;
            _objD001ViewModel = new D001ViewModel();
            DataContext = null;
            DataContext = _objD001ViewModel;
            _objD001ViewModel.PromptExit = true;
            _objD001ViewModel.LayoutRoot = LayoutRoot;
            _objD001ViewModel.ScreenDataCollection = _objD001ViewModel.ScreenSection();
            _objD001ViewModel.GridAddControl();
            _objD001ViewModel.mainline();

            _objD001ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };

            _objD001ViewModel.RunExternalScreen += delegate
            {
                object[] arrRunScreen = { };
                RunScreen(new Billing_M010(), RunScreenModes.Entry, ref arrRunScreen);
            };
        }
                   
        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {            
            if (e.Key.Equals(Key.Return))
            {
                _objD001ViewModel.PromptExit = true;

            }
        }

       private  void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objD001ViewModel != null)
            {
                _objD001ViewModel.PromptExit = true;
                _objD001ViewModel.IsExitForm = true;
                _objD001ViewModel.ClearControls();
                LayoutRoot.Children.Clear();
                _objD001ViewModel.destroy_objects();
                _objD001ViewModel = null;
                DataContext = null;
                ClearMemory();               
            }
        }
              
    }
}
