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
    /// Interaction logic for d050.xaml
    /// </summary>
    public partial class d050 : BasePage
    {
        D050ViewModel _objD050ViewModel = null;
        public d050()
        {
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;          
        }

        public d050(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11)
        {
            InitializeComponent();
            _objD050ViewModel = new D050ViewModel(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11);
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            ClearMemory();
            _objD050ViewModel = null;
            _objD050ViewModel = new D050ViewModel();
            this.DataContext = null;
            this.DataContext = _objD050ViewModel;
            _objD050ViewModel.PromptExit = true;
            _objD050ViewModel.LayoutRoot = LayoutRoot;
            _objD050ViewModel.ScreenDataCollection = _objD050ViewModel.ScreenSection();
            _objD050ViewModel.GridAddControl();
            _objD050ViewModel.mainline();

            _objD050ViewModel.ExitCobol += delegate
            {
                ((App)Application.Current).MainWindow.OpenHomeScreen();
            };
        }

        public override void COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {
                _objD050ViewModel.PromptExit = true;
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_objD050ViewModel !=null)
            {
                _objD050ViewModel.PromptExit = true;
                _objD050ViewModel.IsExitForm = true;                
                _objD050ViewModel.ScreenDataCollection.Clear();                
                _objD050ViewModel.destroy_objects();
                _objD050ViewModel = null;
                DataContext = null;
                ClearMemory();               
            }
        }
    }
}
