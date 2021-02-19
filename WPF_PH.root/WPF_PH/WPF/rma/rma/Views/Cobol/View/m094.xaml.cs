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
    /// Interaction logic for m094.xaml
    /// </summary>
    public partial class m094 : BasePage
    {
        private M094ViewModel _objM094ViewModel = null;
        public m094()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objM094ViewModel = null;
            _objM094ViewModel = new M094ViewModel();
            DataContext = null;
            DataContext = _objM094ViewModel;
            _objM094ViewModel.PromptExit = true;
            _objM094ViewModel.LayoutRoot = LayoutRoot;
            _objM094ViewModel.ScreenDataCollection = _objM094ViewModel.ScreenSection();
            _objM094ViewModel.GridAddControl();
            _objM094ViewModel.mainline();

            _objM094ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objM094ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objM094ViewModel != null)
            {
                _objM094ViewModel.PromptExit = true;
                _objM094ViewModel.destroy_objects();
                _objM094ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
