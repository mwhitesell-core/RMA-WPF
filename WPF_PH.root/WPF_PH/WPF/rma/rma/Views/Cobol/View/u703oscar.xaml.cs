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
    /// Interaction logic for u703oscar.xaml
    /// </summary>
    public partial class u703oscar : BasePage
    {
        private U703oscarViewModel _objU703oscarViewModel = null;

        public u703oscar()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objU703oscarViewModel = null;
            _objU703oscarViewModel = new U703oscarViewModel();
            DataContext = null;
            DataContext = _objU703oscarViewModel;
            _objU703oscarViewModel.PromptExit = true;
            _objU703oscarViewModel.LayoutRoot = LayoutRoot;
            _objU703oscarViewModel.ScreenDataCollection = _objU703oscarViewModel.ScreenSection();
            _objU703oscarViewModel.GridAddControl();
            _objU703oscarViewModel.mainline();

            _objU703oscarViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objU703oscarViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objU703oscarViewModel != null)
            {
                _objU703oscarViewModel.PromptExit = true;
                _objU703oscarViewModel.destroy_objects();
                _objU703oscarViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }

    }
}
