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
    /// Interaction logic for u140.xaml
    /// </summary>
    public partial class u140 : BasePage
    {
        U140ViewModel _obju140ViewModel = null;
        public u140()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
          
            //_obju140ViewModel.mainline("2215", 06, "Y", "Y", "Y");
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _obju140ViewModel = null;
            _obju140ViewModel = new U140ViewModel();
            DataContext = null;
            DataContext = _obju140ViewModel;
            _obju140ViewModel.PromptExit = true;
            _obju140ViewModel.LayoutRoot = LayoutRoot;
            _obju140ViewModel.ScreenDataCollection = _obju140ViewModel.ScreenSection();
            _obju140ViewModel.GridAddControl();
            _obju140ViewModel.mainline();
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                _obju140ViewModel.PromptExit = true;
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_obju140ViewModel != null)
            {
                _obju140ViewModel.PromptExit = true;
                _obju140ViewModel.destroy_objects();
                _obju140ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
