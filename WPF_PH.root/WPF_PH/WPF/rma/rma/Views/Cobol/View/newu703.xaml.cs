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
    /// Interaction logic for newu703.xaml
    /// </summary>
    public partial class newu703 : BasePage
    {
        private Newu703ViewModel _objNewu703ViewModel = null;
        public newu703()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objNewu703ViewModel = null;
            _objNewu703ViewModel = new Newu703ViewModel();
            DataContext = null;
            DataContext = _objNewu703ViewModel;
            _objNewu703ViewModel.PromptExit = true;
            _objNewu703ViewModel.LayoutRoot = LayoutRoot;
            _objNewu703ViewModel.ScreenDataCollection = _objNewu703ViewModel.ScreenSection();
            _objNewu703ViewModel.GridAddControl();
            _objNewu703ViewModel.mainline();

            _objNewu703ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objNewu703ViewModel.PromptExit = true;

            }
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objNewu703ViewModel != null)
            {
                _objNewu703ViewModel.PromptExit = true;
                _objNewu703ViewModel.destroy_objects();
                _objNewu703ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
