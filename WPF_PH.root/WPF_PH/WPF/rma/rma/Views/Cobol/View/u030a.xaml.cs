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
    /// Interaction logic for u030a.xaml
    /// </summary>
    public partial class u030a : BasePage
    {
        u030aViewModel _obju030aViewModel = null;
        public u030a()
        {
            InitializeComponent();           

            ClearMemory();
            _obju030aViewModel = null;
            _obju030aViewModel = new u030aViewModel();
            DataContext = null;
            DataContext = _obju030aViewModel;
            _obju030aViewModel.PromptExit = true;
            _obju030aViewModel.LayoutRoot = LayoutRoot;
            _obju030aViewModel.ScreenDataCollection = _obju030aViewModel.ScreenSection();
            _obju030aViewModel.GridAddControl();
            _obju030aViewModel.mainline();

            //_obju030aViewModel = new u030aViewModel("2215", 06, "Y", "Y", "Y");
        }

        public u030a(string ws_request_clinic_ident, //2215
                              int ws_sel_month, // 06
                              string ws_flag_tape_mth, //y
                              string ws_flag_over_mth, // y
                              string ws_confirm_reply)
        {
            InitializeComponent();
            _obju030aViewModel = new u030aViewModel(ws_request_clinic_ident, ws_sel_month, ws_flag_tape_mth, ws_flag_over_mth, ws_confirm_reply);           
        }

        public override void  COBOL_KeyCode_Check(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Return))
            {               
                _obju030aViewModel.PromptExit = true;             
            }
        }       
    }
}
