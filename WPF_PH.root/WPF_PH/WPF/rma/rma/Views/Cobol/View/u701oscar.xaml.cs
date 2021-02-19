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
    /// Interaction logic for u701oscar.xaml
    /// </summary>
    public partial class u701oscar : BasePage
    {
        private U701oscarViewModel _objU701oscarViewModel = null;
        public u701oscar()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;           
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objU701oscarViewModel = null;
            _objU701oscarViewModel = new U701oscarViewModel();
            DataContext = null;
            DataContext = _objU701oscarViewModel;
            _objU701oscarViewModel.PromptExit = true;
            _objU701oscarViewModel.LayoutRoot = LayoutRoot;
            _objU701oscarViewModel.ScreenDataCollection = _objU701oscarViewModel.ScreenSection();
            _objU701oscarViewModel.GridAddControl();
            _objU701oscarViewModel.mainline_section();

            _objU701oscarViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objU701oscarViewModel.PromptExit = true;

            }
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objU701oscarViewModel != null)
            {
                _objU701oscarViewModel.PromptExit = true;
                _objU701oscarViewModel.destroy_objects();
                _objU701oscarViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
