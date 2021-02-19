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
    /// Interaction logic for m095.xaml
    /// </summary>
    public partial class m095 : BasePage
    {
        private M095ViewModel _objM095ViewModel = null;
        public m095()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;                      
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objM095ViewModel = null;
            _objM095ViewModel = new M095ViewModel();
            DataContext = null;
            DataContext = _objM095ViewModel;
            _objM095ViewModel.PromptExit = true;
            _objM095ViewModel.LayoutRoot = LayoutRoot;
            _objM095ViewModel.ScreenDataCollection = _objM095ViewModel.ScreenSection();
            _objM095ViewModel.GridAddControl();
            _objM095ViewModel.mainline();

            _objM095ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           

            if (e.Key.Equals(Key.Return))
            {
                _objM095ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objM095ViewModel != null)
            {
                _objM095ViewModel.PromptExit = true;
                _objM095ViewModel.destroy_objects();
                _objM095ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
