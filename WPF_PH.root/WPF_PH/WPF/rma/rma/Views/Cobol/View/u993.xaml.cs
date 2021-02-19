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
    /// Interaction logic for u993.xaml
    /// </summary>
    public partial class u993 : BasePage
    {
        private U993ViewModel _objU993ViewModel = null;

        public u993()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objU993ViewModel = null;
            _objU993ViewModel = new U993ViewModel();
            DataContext = null;
            DataContext = _objU993ViewModel;
            _objU993ViewModel.PromptExit = true;
            _objU993ViewModel.ScreenDataCollection = _objU993ViewModel.ScreenSection();
            _objU993ViewModel.GridAddControl();
            _objU993ViewModel.mainline();

            _objU993ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objU993ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objU993ViewModel != null)
            {
                _objU993ViewModel.PromptExit = true;
                _objU993ViewModel.destroy_objects();
                _objU993ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
