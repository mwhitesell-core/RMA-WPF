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
    /// Interaction logic for m090.xaml
    /// </summary>
    public partial class m090 : BasePage
    {
        M090ViewModel _objM090ViewModel = null;
        public m090()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objM090ViewModel = null;
            _objM090ViewModel = new M090ViewModel();
            DataContext = null;
            DataContext = _objM090ViewModel;
            _objM090ViewModel.PromptExit = true;
            _objM090ViewModel.LayoutRoot = LayoutRoot;
            _objM090ViewModel.ScreenDataCollection = _objM090ViewModel.ScreenSection();
            _objM090ViewModel.GridAddControl();
            _objM090ViewModel.mainline();

            _objM090ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {

           /* if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                if (e.Key == Key.D8)
                {
                    ((App)Application.Current).MainWindow.OpenHomeScreen();
                }
            } */

            if (e.Key.Equals(Key.Return))
            {
                _objM090ViewModel.PromptExit = true;

            }           
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objM090ViewModel != null)
            {
                _objM090ViewModel.PromptExit = true;
                _objM090ViewModel.destroy_objects();
                _objM090ViewModel = null;
                DataContext = null;
                ClearMemory();
            }
        }
    }
}
