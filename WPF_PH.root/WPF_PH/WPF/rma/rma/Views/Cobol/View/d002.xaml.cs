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
    /// Interaction logic for d002.xaml
    /// </summary>
    public partial class d002 : BasePage
    {
        private D002ViewModel _objD002ViewModel = null;
        public d002()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;          
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objD002ViewModel = null;
            _objD002ViewModel = new D002ViewModel();
            DataContext = null;
            DataContext = _objD002ViewModel;
            _objD002ViewModel.PromptExit = true;
            _objD002ViewModel.LayoutRoot = LayoutRoot;
            _objD002ViewModel.ScreenDataCollection = _objD002ViewModel.ScreenSection();
            _objD002ViewModel.GridAddControl();
            _objD002ViewModel.mainline();

            _objD002ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
           
            if (e.Key.Equals(Key.Return))
            {
                _objD002ViewModel.PromptExit = true;

            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objD002ViewModel != null)
            {
                _objD002ViewModel.PromptExit = true;
                _objD002ViewModel.IsExitForm = true;
                _objD002ViewModel.ClearControls();
                LayoutRoot.Children.Clear();
                _objD002ViewModel.destroy_objects();
                _objD002ViewModel = null;
                DataContext = null;
                ClearMemory();               
            }

            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
        }

    }
}
