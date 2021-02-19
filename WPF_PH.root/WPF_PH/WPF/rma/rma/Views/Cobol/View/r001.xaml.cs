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
    /// Interaction logic for r001.xaml
    /// </summary>
    public partial class r001 : BasePage
    {
        private R001ViewModel _objR001ViewModel = null;

        public r001()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objR001ViewModel = null;
            _objR001ViewModel = new R001ViewModel();
            DataContext = null;
            DataContext = _objR001ViewModel;
            _objR001ViewModel.PromptExit = true;
            _objR001ViewModel.LayoutRoot = LayoutRoot;
            _objR001ViewModel.ScreenDataCollection = _objR001ViewModel.ScreenSection();
            _objR001ViewModel.GridAddControl();
            _objR001ViewModel.mainline();

            _objR001ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objR001ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objR001ViewModel != null)
            {
                _objR001ViewModel.PromptExit = true;
                _objR001ViewModel.destroy_objects();
                _objR001ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
