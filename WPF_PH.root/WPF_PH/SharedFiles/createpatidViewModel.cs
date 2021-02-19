using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using rma.Cobol;
using RmaDAL;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.IO;
using System.Diagnostics;


namespace rma.Views
{
    public class CreatepatidViewModel
    {

        public CreatepatidViewModel()
        {

        }

        #region FD Section
        // FD: corrected_pat	Copy : f086_pat_id.fd
        private Pat_id_rec objPat_id_rec = null;
        private ObservableCollection<Pat_id_rec> Pat_id_rec_Collection;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private string status_corrected_pat = "0";

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion


        private void mainline()
        {

            // 	open i-o	corrected-pat.;
            //     stop run.;
        }

        #endregion
    }
}

