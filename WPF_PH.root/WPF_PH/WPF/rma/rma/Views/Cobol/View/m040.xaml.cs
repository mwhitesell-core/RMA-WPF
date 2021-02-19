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
    /// Interaction logic for m040.xaml
    /// </summary>
    public partial class m040 : BasePage
    {
        private M040ViewModel _objM040ViewModel = null;
        public m040()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objM040ViewModel = null;
            _objM040ViewModel = new M040ViewModel();
            DataContext = null;
            DataContext = _objM040ViewModel;
            _objM040ViewModel.PromptExit = true;
            _objM040ViewModel.LayoutRoot = LayoutRoot;
            _objM040ViewModel.ScreenDataCollection = _objM040ViewModel.ScreenSection();
            _objM040ViewModel.GridAddControl();
            _objM040ViewModel.mainline();

            _objM040ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {           
            if (e.Key.Equals(Key.Return))
            {
                _objM040ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objM040ViewModel != null)
            {
                _objM040ViewModel.PromptExit = true;
                _objM040ViewModel.destroy_objects();
                _objM040ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
