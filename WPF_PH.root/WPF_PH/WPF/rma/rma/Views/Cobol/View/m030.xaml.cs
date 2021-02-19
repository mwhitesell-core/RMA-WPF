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

namespace rma.Views
{
    /// <summary>
    /// Interaction logic for m030.xaml
    /// </summary>
    public partial class m030 : BasePage
    {
        private M030ViewModel _objM030ViewModel = null;
        public m030()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;           
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objM030ViewModel = null;
            _objM030ViewModel = new M030ViewModel();
            DataContext = null;
            DataContext = _objM030ViewModel;
            _objM030ViewModel.PromptExit = true;
            _objM030ViewModel.LayoutRoot = LayoutRoot;
            _objM030ViewModel.ScreenDataCollection = _objM030ViewModel.ScreenSection();
            _objM030ViewModel.GridAddControl();
            _objM030ViewModel.mainline();

            _objM030ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {           
            if (e.Key.Equals(Key.Return))
            {
                _objM030ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objM030ViewModel != null)
            {
                _objM030ViewModel.PromptExit = true;
                _objM030ViewModel.destroy_objects();
                _objM030ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
