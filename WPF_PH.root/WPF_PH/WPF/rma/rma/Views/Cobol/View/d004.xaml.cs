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
    /// Interaction logic for d004.xaml
    /// </summary>
    public partial class d004 : BasePage
    {
        private D004ViewModel _objD004ViewModel = null;
        public d004()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;           
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objD004ViewModel = null;
            _objD004ViewModel = new D004ViewModel();
            DataContext = null;
            DataContext = _objD004ViewModel;
            _objD004ViewModel.PromptExit = true;
            _objD004ViewModel.LayoutRoot = LayoutRoot;
            _objD004ViewModel.ScreenDataCollection = _objD004ViewModel.ScreenSection();
            _objD004ViewModel.GridAddControl();
            _objD004ViewModel.mainline();

            _objD004ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objD004ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objD004ViewModel != null)
            {
                _objD004ViewModel.PromptExit = true;
                _objD004ViewModel.IsExitForm = true;
                _objD004ViewModel.ClearControls();
                LayoutRoot.Children.Clear();
                _objD004ViewModel.destroy_objects();
                _objD004ViewModel = null;
                DataContext = null;
                ClearMemory();              
            }
        }

    }
}
