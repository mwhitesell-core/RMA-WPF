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
    /// Interaction logic for newu701.xaml
    /// </summary>
    public partial class newu701 : BasePage
    {
        private Newu701ViewModel _objNewu701ViewModel = null;
        public newu701()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objNewu701ViewModel = null;
            _objNewu701ViewModel = new Newu701ViewModel();
            DataContext = null;
            DataContext = _objNewu701ViewModel;
            _objNewu701ViewModel.PromptExit = true;
            _objNewu701ViewModel.LayoutRoot = LayoutRoot;
            _objNewu701ViewModel.ScreenDataCollection = _objNewu701ViewModel.ScreenSection();
            _objNewu701ViewModel.GridAddControl();
            _objNewu701ViewModel.mainline_section();

            _objNewu701ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {           

            if (e.Key.Equals(Key.Return))
            {
                _objNewu701ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objNewu701ViewModel != null)
            {
                _objNewu701ViewModel.PromptExit = true;
                _objNewu701ViewModel.destroy_objects();
                _objNewu701ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }

    }
}
