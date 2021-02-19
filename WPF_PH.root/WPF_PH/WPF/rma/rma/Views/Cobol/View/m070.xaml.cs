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
using Core.Framework;
using Core.Framework.Core.Framework;
namespace rma.Views
{
    /// <summary>
    /// Interaction logic for d001.xaml
    /// </summary>
    public partial class m070 : BasePage
    {
       M070ViewModel _objM070ViewModel = null;

        public m070()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objM070ViewModel = null;
            _objM070ViewModel = new M070ViewModel();
            DataContext = null;
            DataContext = _objM070ViewModel;
            _objM070ViewModel.PromptExit = true;
            _objM070ViewModel.LayoutRoot = LayoutRoot;
            _objM070ViewModel.ScreenDataCollection = _objM070ViewModel.ScreenSection();
            _objM070ViewModel.GridAddControl();
            _objM070ViewModel.mainline();

            _objM070ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            }; 

        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                 _objM070ViewModel.PromptExit = true;
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objM070ViewModel != null)
            {
                _objM070ViewModel.PromptExit = true;
                _objM070ViewModel.destroy_objects();
                _objM070ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
