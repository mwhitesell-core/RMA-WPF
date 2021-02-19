using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using RmaDAL;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.IO;
using System.Diagnostics;
using rma.Cobol;

namespace rma.Views
{
    public delegate void D002ExitCobolScreen();
    public class D002ViewModel : CommonFunctionScr
    {
        public event D002ExitCobolScreen ExitCobol;

        public D002ViewModel()
        {

        }

        #region FD Section
        // FD: batch_ctrl_file	Copy : f001_batch_control_file.fd
        private F001_BATCH_CONTROL_FILE objBatctrl_rec = null;
        private ObservableCollection<F001_BATCH_CONTROL_FILE> Batctrl_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private F002_CLAIMS_MSTR_HDR objClaims_mstr_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private F002_CLAIMS_MSTR_DTL objClaims_mstr_dtl_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claims_mstr_dtl_rec_Collection;

        private F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR = null;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> F002_CLAIMS_MSTR_HDR_Collection;

        private F002_CLAIMS_MSTR_DTL_DESC objF002_CLAIMS_MSTR_DTL_DESC = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC> F002_CLAIMS_MSTR_DTL_DESC_Collection;

        // FD: pat_mstr	Copy : f010_patient_mstr.fd
        private F010_PAT_MSTR objPat_mstr_rec = null;
        private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;


        #endregion

        #region Properties
        private string _acpt_claim_id;
        public string acpt_claim_id
        {
            get
            {
                return _acpt_claim_id;
            }
            set
            {
                if (_acpt_claim_id != value)
                {
                    _acpt_claim_id = value;
                    _acpt_claim_id = _acpt_claim_id.ToUpper();
                    RaisePropertyChanged("acpt_claim_id");
                }
            }
        }

        private string _clmhdr_agent_cd;
        public string clmhdr_agent_cd
        {
            get
            {
                return _clmhdr_agent_cd;
            }
            set
            {
                if (_clmhdr_agent_cd != value)
                {
                    _clmhdr_agent_cd = value;
                    _clmhdr_agent_cd = _clmhdr_agent_cd.ToUpper();
                    RaisePropertyChanged("clmhdr_agent_cd");
                }
            }
        }

        private int _clmhdr_claim_nbr;
        public int clmhdr_claim_nbr
        {
            get
            {
                return _clmhdr_claim_nbr;
            }
            set
            {
                if (_clmhdr_claim_nbr != value)
                {
                    _clmhdr_claim_nbr = value;                  
                    RaisePropertyChanged("clmhdr_claim_nbr");
                }
            }
        }

        private string _clmhdr_clinic_nbr_1_2;
        public string clmhdr_clinic_nbr_1_2
        {
            get
            {
                return _clmhdr_clinic_nbr_1_2;
            }
            set
            {
                if (_clmhdr_clinic_nbr_1_2 != value)
                {
                    _clmhdr_clinic_nbr_1_2 = value;
                    _clmhdr_clinic_nbr_1_2 = _clmhdr_clinic_nbr_1_2.ToUpper();
                    RaisePropertyChanged("clmhdr_clinic_nbr_1_2");
                }
            }
        }

        private string _clmhdr_date_admit_dd;
        public string clmhdr_date_admit_dd
        {
            get
            {
                return _clmhdr_date_admit_dd;
            }
            set
            {
                if (_clmhdr_date_admit_dd != value)
                {
                    _clmhdr_date_admit_dd = value;
                    _clmhdr_date_admit_dd = _clmhdr_date_admit_dd.ToUpper();
                    RaisePropertyChanged("clmhdr_date_admit_dd");
                }
            }
        }

        private string _clmhdr_date_admit_mm;
        public string clmhdr_date_admit_mm
        {
            get
            {
                return _clmhdr_date_admit_mm;
            }
            set
            {
                if (_clmhdr_date_admit_mm != value)
                {
                    _clmhdr_date_admit_mm = value;
                    _clmhdr_date_admit_mm = _clmhdr_date_admit_mm.ToUpper();
                    RaisePropertyChanged("clmhdr_date_admit_mm");
                }
            }
        }

        private string _clmhdr_date_admit_yy;
        public string clmhdr_date_admit_yy
        {
            get
            {
                return _clmhdr_date_admit_yy;
            }
            set
            {
                if (_clmhdr_date_admit_yy != value)
                {
                    _clmhdr_date_admit_yy = value;
                    _clmhdr_date_admit_yy = _clmhdr_date_admit_yy.ToUpper();
                    RaisePropertyChanged("clmhdr_date_admit_yy");
                }
            }
        }

        private string _clmhdr_date_cash_tape_payment;
        public string clmhdr_date_cash_tape_payment
        {
            get
            {
                return _clmhdr_date_cash_tape_payment;
            }
            set
            {
                if (_clmhdr_date_cash_tape_payment != value)
                {
                    _clmhdr_date_cash_tape_payment = value;
                    _clmhdr_date_cash_tape_payment = _clmhdr_date_cash_tape_payment.ToUpper();
                    RaisePropertyChanged("clmhdr_date_cash_tape_payment");
                }
            }
        }

        private string _clmhdr_day;
        public string clmhdr_day
        {
            get
            {
                return _clmhdr_day;
            }
            set
            {
                if (_clmhdr_day != value)
                {
                    _clmhdr_day = value;
                    _clmhdr_day = _clmhdr_day.ToUpper();
                    RaisePropertyChanged("clmhdr_day");
                }
            }
        }

        private string _clmhdr_diag_cd;
        public string clmhdr_diag_cd
        {
            get
            {
                return _clmhdr_diag_cd;
            }
            set
            {
                if (_clmhdr_diag_cd != value)
                {
                    _clmhdr_diag_cd = value;
                    _clmhdr_diag_cd = _clmhdr_diag_cd.ToUpper();
                    RaisePropertyChanged("clmhdr_diag_cd");
                }
            }
        }

        private string _clmhdr_doc_nbr;
        public string clmhdr_doc_nbr
        {
            get
            {
                return _clmhdr_doc_nbr;
            }
            set
            {
                if (_clmhdr_doc_nbr != value)
                {
                    _clmhdr_doc_nbr = value;
                    _clmhdr_doc_nbr = _clmhdr_doc_nbr.ToUpper();
                    RaisePropertyChanged("clmhdr_doc_nbr");
                }
            }
        }

        private string _clmhdr_i_o_pat_ind;
        public string clmhdr_i_o_pat_ind
        {
            get
            {
                return _clmhdr_i_o_pat_ind;
            }
            set
            {
                if (_clmhdr_i_o_pat_ind != value)
                {
                    _clmhdr_i_o_pat_ind = value;
                    _clmhdr_i_o_pat_ind = _clmhdr_i_o_pat_ind.ToUpper();
                    RaisePropertyChanged("clmhdr_i_o_pat_ind");
                }
            }
        }

        private string _clmhdr_loc;
        public string clmhdr_loc
        {
            get
            {
                return _clmhdr_loc;
            }
            set
            {
                if (_clmhdr_loc != value)
                {
                    _clmhdr_loc = value;
                    _clmhdr_loc = _clmhdr_loc.ToUpper();
                    RaisePropertyChanged("clmhdr_loc");
                }
            }
        }

        private decimal _clmhdr_manual_and_tape_paymnts;
        public decimal clmhdr_manual_and_tape_paymnts
        {
            get
            {
                return _clmhdr_manual_and_tape_paymnts;
            }
            set
            {
                if (_clmhdr_manual_and_tape_paymnts != value)
                {
                    _clmhdr_manual_and_tape_paymnts = value;
                    RaisePropertyChanged("clmhdr_manual_and_tape_paymnts");
                }
            }
        }

        private string _clmhdr_pat_acronym6;
        public string clmhdr_pat_acronym6
        {
            get
            {
                return _clmhdr_pat_acronym6;
            }
            set
            {
                if (_clmhdr_pat_acronym6 != value)
                {
                    _clmhdr_pat_acronym6 = value;
                    _clmhdr_pat_acronym6 = _clmhdr_pat_acronym6.ToUpper();
                    RaisePropertyChanged("clmhdr_pat_acronym6");
                }
            }
        }

        private string _clmhdr_reference;
        public string clmhdr_reference
        {
            get
            {
                return _clmhdr_reference;
            }
            set
            {
                if (_clmhdr_reference != value)
                {
                    _clmhdr_reference = value;
                    _clmhdr_reference = _clmhdr_reference.ToUpper();
                    RaisePropertyChanged("clmhdr_reference");
                }
            }
        }

        private string _clmhdr_status_ohip;
        public string clmhdr_status_ohip
        {
            get
            {
                return _clmhdr_status_ohip;
            }
            set
            {
                if (_clmhdr_status_ohip != value)
                {
                    _clmhdr_status_ohip = value;
                    _clmhdr_status_ohip = _clmhdr_status_ohip.ToUpper();
                    RaisePropertyChanged("clmhdr_status_ohip");
                }
            }
        }

        private string _clmhdr_tape_submit_ind;
        public string clmhdr_tape_submit_ind
        {
            get
            {
                return _clmhdr_tape_submit_ind;
            }
            set
            {
                if (_clmhdr_tape_submit_ind != value)
                {
                    _clmhdr_tape_submit_ind = value;
                    _clmhdr_tape_submit_ind = _clmhdr_tape_submit_ind.ToUpper();
                    RaisePropertyChanged("clmhdr_tape_submit_ind");
                }
            }
        }

        private decimal _clmhdr_tot_claim_ar_ohip;
        public decimal clmhdr_tot_claim_ar_ohip
        {
            get
            {
                return _clmhdr_tot_claim_ar_ohip;
            }
            set
            {
                if (_clmhdr_tot_claim_ar_ohip != value)
                {
                    _clmhdr_tot_claim_ar_ohip = value;
                    RaisePropertyChanged("clmhdr_tot_claim_ar_ohip");
                }
            }
        }

        private string _clmhdr_week;
        public string clmhdr_week
        {
            get
            {
                return _clmhdr_week;
            }
            set
            {
                if (_clmhdr_week != value)
                {
                    _clmhdr_week = value;
                    _clmhdr_week = _clmhdr_week.ToUpper();
                    RaisePropertyChanged("clmhdr_week");
                }
            }
        }

        private string _confirm_space;
        public string confirm_space
        {
            get
            {
                return _confirm_space;
            }
            set
            {
                if (_confirm_space != value)
                {
                    _confirm_space = value;
                    _confirm_space = _confirm_space.ToUpper();
                    RaisePropertyChanged("confirm_space");
                }
            }
        }

        private int _ctr_read_batctrl_mstr;
        public int ctr_read_batctrl_mstr
        {
            get
            {
                return _ctr_read_batctrl_mstr;
            }
            set
            {
                if (_ctr_read_batctrl_mstr != value)
                {
                    _ctr_read_batctrl_mstr = value;
                    RaisePropertyChanged("ctr_read_batctrl_mstr");
                }
            }
        }

        private int _ctr_read_claims_mstr;
        public int ctr_read_claims_mstr
        {
            get
            {
                return _ctr_read_claims_mstr;
            }
            set
            {
                if (_ctr_read_claims_mstr != value)
                {
                    _ctr_read_claims_mstr = value;
                    RaisePropertyChanged("ctr_read_claims_mstr");
                }
            }
        }

        private int _ctr_read_pat_mstr;
        public int ctr_read_pat_mstr
        {
            get
            {
                return _ctr_read_pat_mstr;
            }
            set
            {
                if (_ctr_read_pat_mstr != value)
                {
                    _ctr_read_pat_mstr = value;
                    RaisePropertyChanged("ctr_read_pat_mstr");
                }
            }
        }

        private int _ctr_writ_batctrl_file;
        public int ctr_writ_batctrl_file
        {
            get
            {
                return _ctr_writ_batctrl_file;
            }
            set
            {
                if (_ctr_writ_batctrl_file != value)
                {
                    _ctr_writ_batctrl_file = value;
                    RaisePropertyChanged("ctr_writ_batctrl_file");
                }
            }
        }

        private int _ctr_writ_claims_mstr;
        public int ctr_writ_claims_mstr
        {
            get
            {
                return _ctr_writ_claims_mstr;
            }
            set
            {
                if (_ctr_writ_claims_mstr != value)
                {
                    _ctr_writ_claims_mstr = value;
                    RaisePropertyChanged("ctr_writ_claims_mstr");
                }
            }
        }

        private string _err_msg_comment;
        public string err_msg_comment
        {
            get
            {
                return _err_msg_comment;
            }
            set
            {
                if (_err_msg_comment != value)
                {
                    _err_msg_comment = value;
                    _err_msg_comment = _err_msg_comment.ToUpper();
                    RaisePropertyChanged("err_msg_comment");
                }
            }
        }

        private string _flag;
        public string flag
        {
            get
            {
                return _flag;
            }
            set
            {
                if (_flag != value)
                {
                    _flag = value;
                    _flag = _flag.ToUpper();
                    RaisePropertyChanged("flag");
                }
            }
        }

        private string _hold_clm_adj_cd_1;
        public string hold_clm_adj_cd_1
        {
            get
            {
                return _hold_clm_adj_cd_1;
            }
            set
            {
                if (_hold_clm_adj_cd_1 != value)
                {
                    _hold_clm_adj_cd_1 = value;
                    _hold_clm_adj_cd_1 = _hold_clm_adj_cd_1.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_1");
                }
            }
        }

        private string _hold_clm_adj_cd_2;
        public string hold_clm_adj_cd_2
        {
            get
            {
                return _hold_clm_adj_cd_2;
            }
            set
            {
                if (_hold_clm_adj_cd_2 != value)
                {
                    _hold_clm_adj_cd_2 = value;
                    _hold_clm_adj_cd_2 = _hold_clm_adj_cd_2.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_2");
                }
            }
        }

        private string _hold_clm_adj_cd_3;
        public string hold_clm_adj_cd_3
        {
            get
            {
                return _hold_clm_adj_cd_3;
            }
            set
            {
                if (_hold_clm_adj_cd_3 != value)
                {
                    _hold_clm_adj_cd_3 = value;
                    _hold_clm_adj_cd_3 = _hold_clm_adj_cd_3.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_3");
                }
            }
        }

        private string _hold_clm_adj_cd_4;
        public string hold_clm_adj_cd_4
        {
            get
            {
                return _hold_clm_adj_cd_4;
            }
            set
            {
                if (_hold_clm_adj_cd_4 != value)
                {
                    _hold_clm_adj_cd_4 = value;
                    _hold_clm_adj_cd_4 = _hold_clm_adj_cd_4.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_4");
                }
            }
        }

        private string _hold_clm_adj_cd_5;
        public string hold_clm_adj_cd_5
        {
            get
            {
                return _hold_clm_adj_cd_5;
            }
            set
            {
                if (_hold_clm_adj_cd_5 != value)
                {
                    _hold_clm_adj_cd_5 = value;
                    _hold_clm_adj_cd_5 = _hold_clm_adj_cd_5.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_5");
                }
            }
        }

        private string _hold_clm_adj_cd_6;
        public string hold_clm_adj_cd_6
        {
            get
            {
                return _hold_clm_adj_cd_6;
            }
            set
            {
                if (_hold_clm_adj_cd_6 != value)
                {
                    _hold_clm_adj_cd_6 = value;
                    _hold_clm_adj_cd_6 = _hold_clm_adj_cd_6.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_6");
                }
            }
        }

        private string _hold_clm_adj_cd_7;
        public string hold_clm_adj_cd_7
        {
            get
            {
                return _hold_clm_adj_cd_7;
            }
            set
            {
                if (_hold_clm_adj_cd_7 != value)
                {
                    _hold_clm_adj_cd_7 = value;
                    _hold_clm_adj_cd_7 = _hold_clm_adj_cd_7.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_7");
                }
            }
        }

        private string _hold_clm_adj_cd_8;
        public string hold_clm_adj_cd_8
        {
            get
            {
                return _hold_clm_adj_cd_8;
            }
            set
            {
                if (_hold_clm_adj_cd_8 != value)
                {
                    _hold_clm_adj_cd_8 = value;
                    _hold_clm_adj_cd_8 = _hold_clm_adj_cd_8.ToUpper();
                    RaisePropertyChanged("hold_clm_adj_cd_8");
                }
            }
        }

        private int _hold_clm_agent_1;
        public int hold_clm_agent_1
        {
            get
            {
                return _hold_clm_agent_1;
            }
            set
            {
                if (_hold_clm_agent_1 != value)
                {
                    _hold_clm_agent_1 = value;
                    RaisePropertyChanged("hold_clm_agent_1");
                }
            }
        }

        private int _hold_clm_agent_2;
        public int hold_clm_agent_2
        {
            get
            {
                return _hold_clm_agent_2;
            }
            set
            {
                if (_hold_clm_agent_2 != value)
                {
                    _hold_clm_agent_2 = value;
                    RaisePropertyChanged("hold_clm_agent_2");
                }
            }
        }

        private int _hold_clm_agent_3;
        public int hold_clm_agent_3
        {
            get
            {
                return _hold_clm_agent_3;
            }
            set
            {
                if (_hold_clm_agent_3 != value)
                {
                    _hold_clm_agent_3 = value;
                    RaisePropertyChanged("hold_clm_agent_3");
                }
            }
        }

        private int _hold_clm_agent_4;
        public int hold_clm_agent_4
        {
            get
            {
                return _hold_clm_agent_4;
            }
            set
            {
                if (_hold_clm_agent_4 != value)
                {
                    _hold_clm_agent_4 = value;
                    RaisePropertyChanged("hold_clm_agent_4");
                }
            }
        }

        private int _hold_clm_agent_5;
        public int hold_clm_agent_5
        {
            get
            {
                return _hold_clm_agent_5;
            }
            set
            {
                if (_hold_clm_agent_5 != value)
                {
                    _hold_clm_agent_5 = value;
                    RaisePropertyChanged("hold_clm_agent_5");
                }
            }
        }

        private int _hold_clm_agent_6;
        public int hold_clm_agent_6
        {
            get
            {
                return _hold_clm_agent_6;
            }
            set
            {
                if (_hold_clm_agent_6 != value)
                {
                    _hold_clm_agent_6 = value;
                    RaisePropertyChanged("hold_clm_agent_6");
                }
            }
        }

        private int _hold_clm_agent_7;
        public int hold_clm_agent_7
        {
            get
            {
                return _hold_clm_agent_7;
            }
            set
            {
                if (_hold_clm_agent_7 != value)
                {
                    _hold_clm_agent_7 = value;
                    RaisePropertyChanged("hold_clm_agent_7");
                }
            }
        }

        private int _hold_clm_agent_8;
        public int hold_clm_agent_8
        {
            get
            {
                return _hold_clm_agent_8;
            }
            set
            {
                if (_hold_clm_agent_8 != value)
                {
                    _hold_clm_agent_8 = value;
                    RaisePropertyChanged("hold_clm_agent_8");
                }
            }
        }

        private decimal _hold_clm_amt_due_1;
        public decimal hold_clm_amt_due_1
        {
            get
            {
                return _hold_clm_amt_due_1;
            }
            set
            {
                if (_hold_clm_amt_due_1 != value)
                {
                    _hold_clm_amt_due_1 = value;
                    RaisePropertyChanged("hold_clm_amt_due_1");
                }
            }
        }

        private decimal _hold_clm_amt_due_2;
        public decimal hold_clm_amt_due_2
        {
            get
            {
                return _hold_clm_amt_due_2;
            }
            set
            {
                if (_hold_clm_amt_due_2 != value)
                {
                    _hold_clm_amt_due_2 = value;
                    RaisePropertyChanged("hold_clm_amt_due_2");
                }
            }
        }

        private decimal _hold_clm_amt_due_3;
        public decimal hold_clm_amt_due_3
        {
            get
            {
                return _hold_clm_amt_due_3;
            }
            set
            {
                if (_hold_clm_amt_due_3 != value)
                {
                    _hold_clm_amt_due_3 = value;
                    RaisePropertyChanged("hold_clm_amt_due_3");
                }
            }
        }

        private decimal _hold_clm_amt_due_4;
        public decimal hold_clm_amt_due_4
        {
            get
            {
                return _hold_clm_amt_due_4;
            }
            set
            {
                if (_hold_clm_amt_due_4 != value)
                {
                    _hold_clm_amt_due_4 = value;
                    RaisePropertyChanged("hold_clm_amt_due_4");
                }
            }
        }

        private decimal _hold_clm_amt_due_5;
        public decimal hold_clm_amt_due_5
        {
            get
            {
                return _hold_clm_amt_due_5;
            }
            set
            {
                if (_hold_clm_amt_due_5 != value)
                {
                    _hold_clm_amt_due_5 = value;
                    RaisePropertyChanged("hold_clm_amt_due_5");
                }
            }
        }

        private decimal _hold_clm_amt_due_6;
        public decimal hold_clm_amt_due_6
        {
            get
            {
                return _hold_clm_amt_due_6;
            }
            set
            {
                if (_hold_clm_amt_due_6 != value)
                {
                    _hold_clm_amt_due_6 = value;
                    RaisePropertyChanged("hold_clm_amt_due_6");
                }
            }
        }

        private decimal _hold_clm_amt_due_7;
        public decimal hold_clm_amt_due_7
        {
            get
            {
                return _hold_clm_amt_due_7;
            }
            set
            {
                if (_hold_clm_amt_due_7 != value)
                {
                    _hold_clm_amt_due_7 = value;
                    RaisePropertyChanged("hold_clm_amt_due_7");
                }
            }
        }

        private decimal _hold_clm_amt_due_8;
        public decimal hold_clm_amt_due_8
        {
            get
            {
                return _hold_clm_amt_due_8;
            }
            set
            {
                if (_hold_clm_amt_due_8 != value)
                {
                    _hold_clm_amt_due_8 = value;
                    RaisePropertyChanged("hold_clm_amt_due_8");
                }
            }
        }

        private string _hold_clm_card_col_1;
        public string hold_clm_card_col_1
        {
            get
            {
                return _hold_clm_card_col_1;
            }
            set
            {
                if (_hold_clm_card_col_1 != value)
                {
                    _hold_clm_card_col_1 = value;
                    _hold_clm_card_col_1 = _hold_clm_card_col_1.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_1");
                }
            }
        }

        private string _hold_clm_card_col_2;
        public string hold_clm_card_col_2
        {
            get
            {
                return _hold_clm_card_col_2;
            }
            set
            {
                if (_hold_clm_card_col_2 != value)
                {
                    _hold_clm_card_col_2 = value;
                    _hold_clm_card_col_2 = _hold_clm_card_col_2.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_2");
                }
            }
        }

        private string _hold_clm_card_col_3;
        public string hold_clm_card_col_3
        {
            get
            {
                return _hold_clm_card_col_3;
            }
            set
            {
                if (_hold_clm_card_col_3 != value)
                {
                    _hold_clm_card_col_3 = value;
                    _hold_clm_card_col_3 = _hold_clm_card_col_3.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_3");
                }
            }
        }

        private string _hold_clm_card_col_4;
        public string hold_clm_card_col_4
        {
            get
            {
                return _hold_clm_card_col_4;
            }
            set
            {
                if (_hold_clm_card_col_4 != value)
                {
                    _hold_clm_card_col_4 = value;
                    _hold_clm_card_col_4 = _hold_clm_card_col_4.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_4");
                }
            }
        }

        private string _hold_clm_card_col_5;
        public string hold_clm_card_col_5
        {
            get
            {
                return _hold_clm_card_col_5;
            }
            set
            {
                if (_hold_clm_card_col_5 != value)
                {
                    _hold_clm_card_col_5 = value;
                    _hold_clm_card_col_5 = _hold_clm_card_col_5.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_5");
                }
            }
        }

        private string _hold_clm_card_col_6;
        public string hold_clm_card_col_6
        {
            get
            {
                return _hold_clm_card_col_6;
            }
            set
            {
                if (_hold_clm_card_col_6 != value)
                {
                    _hold_clm_card_col_6 = value;
                    _hold_clm_card_col_6 = _hold_clm_card_col_6.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_6");
                }
            }
        }

        private string _hold_clm_card_col_7;
        public string hold_clm_card_col_7
        {
            get
            {
                return _hold_clm_card_col_7;
            }
            set
            {
                if (_hold_clm_card_col_7 != value)
                {
                    _hold_clm_card_col_7 = value;
                    _hold_clm_card_col_7 = _hold_clm_card_col_7.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_7");
                }
            }
        }

        private string _hold_clm_card_col_8;
        public string hold_clm_card_col_8
        {
            get
            {
                return _hold_clm_card_col_8;
            }
            set
            {
                if (_hold_clm_card_col_8 != value)
                {
                    _hold_clm_card_col_8 = value;
                    _hold_clm_card_col_8 = _hold_clm_card_col_8.ToUpper();
                    RaisePropertyChanged("hold_clm_card_col_8");
                }
            }
        }

        private int _hold_clm_clm_nbr_1;
        public int hold_clm_clm_nbr_1
        {
            get
            {
                return _hold_clm_clm_nbr_1;
            }
            set
            {
                if (_hold_clm_clm_nbr_1 != value)
                {
                    _hold_clm_clm_nbr_1 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_1");
                }
            }
        }

        private int _hold_clm_clm_nbr_2;
        public int hold_clm_clm_nbr_2
        {
            get
            {
                return _hold_clm_clm_nbr_2;
            }
            set
            {
                if (_hold_clm_clm_nbr_2 != value)
                {
                    _hold_clm_clm_nbr_2 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_2");
                }
            }
        }

        private int _hold_clm_clm_nbr_3;
        public int hold_clm_clm_nbr_3
        {
            get
            {
                return _hold_clm_clm_nbr_3;
            }
            set
            {
                if (_hold_clm_clm_nbr_3 != value)
                {
                    _hold_clm_clm_nbr_3 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_3");
                }
            }
        }

        private int _hold_clm_clm_nbr_4;
        public int hold_clm_clm_nbr_4
        {
            get
            {
                return _hold_clm_clm_nbr_4;
            }
            set
            {
                if (_hold_clm_clm_nbr_4 != value)
                {
                    _hold_clm_clm_nbr_4 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_4");
                }
            }
        }

        private int _hold_clm_clm_nbr_5;
        public int hold_clm_clm_nbr_5
        {
            get
            {
                return _hold_clm_clm_nbr_5;
            }
            set
            {
                if (_hold_clm_clm_nbr_5 != value)
                {
                    _hold_clm_clm_nbr_5 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_5");
                }
            }
        }

        private int _hold_clm_clm_nbr_6;
        public int hold_clm_clm_nbr_6
        {
            get
            {
                return _hold_clm_clm_nbr_6;
            }
            set
            {
                if (_hold_clm_clm_nbr_6 != value)
                {
                    _hold_clm_clm_nbr_6 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_6");
                }
            }
        }

        private int _hold_clm_clm_nbr_7;
        public int hold_clm_clm_nbr_7
        {
            get
            {
                return _hold_clm_clm_nbr_7;
            }
            set
            {
                if (_hold_clm_clm_nbr_7 != value)
                {
                    _hold_clm_clm_nbr_7 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_7");
                }
            }
        }

        private int _hold_clm_clm_nbr_8;
        public int hold_clm_clm_nbr_8
        {
            get
            {
                return _hold_clm_clm_nbr_8;
            }
            set
            {
                if (_hold_clm_clm_nbr_8 != value)
                {
                    _hold_clm_clm_nbr_8 = value;                    
                    RaisePropertyChanged("hold_clm_clm_nbr_8");
                }
            }
        }

        private int _hold_clm_cyc_1;
        public int hold_clm_cyc_1
        {
            get
            {
                return _hold_clm_cyc_1;
            }
            set
            {
                if (_hold_clm_cyc_1 != value)
                {
                    _hold_clm_cyc_1 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_1");
                }
            }
        }

        private int _hold_clm_cyc_2;
        public int hold_clm_cyc_2
        {
            get
            {
                return _hold_clm_cyc_2;
            }
            set
            {
                if (_hold_clm_cyc_2 != value)
                {
                    _hold_clm_cyc_2 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_2");
                }
            }
        }

        private int _hold_clm_cyc_3;
        public int hold_clm_cyc_3
        {
            get
            {
                return _hold_clm_cyc_3;
            }
            set
            {
                if (_hold_clm_cyc_3 != value)
                {
                    _hold_clm_cyc_3 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_3");
                }
            }
        }

        private int _hold_clm_cyc_4;
        public int hold_clm_cyc_4
        {
            get
            {
                return _hold_clm_cyc_4;
            }
            set
            {
                if (_hold_clm_cyc_4 != value)
                {
                    _hold_clm_cyc_4 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_4");
                }
            }
        }

        private int _hold_clm_cyc_5;
        public int hold_clm_cyc_5
        {
            get
            {
                return _hold_clm_cyc_5;
            }
            set
            {
                if (_hold_clm_cyc_5 != value)
                {
                    _hold_clm_cyc_5 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_5");
                }
            }
        }

        private int _hold_clm_cyc_6;
        public int hold_clm_cyc_6
        {
            get
            {
                return _hold_clm_cyc_6;
            }
            set
            {
                if (_hold_clm_cyc_6 != value)
                {
                    _hold_clm_cyc_6 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_6");
                }
            }
        }

        private int _hold_clm_cyc_7;
        public int hold_clm_cyc_7
        {
            get
            {
                return _hold_clm_cyc_7;
            }
            set
            {
                if (_hold_clm_cyc_7 != value)
                {
                    _hold_clm_cyc_7 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_7");
                }
            }
        }

        private int _hold_clm_cyc_8;
        public int hold_clm_cyc_8
        {
            get
            {
                return _hold_clm_cyc_8;
            }
            set
            {
                if (_hold_clm_cyc_8 != value)
                {
                    _hold_clm_cyc_8 = value;                    
                    RaisePropertyChanged("hold_clm_cyc_8");
                }
            }
        }

        private string _hold_clm_id_1;
        public string hold_clm_id_1
        {
            get
            {
                return _hold_clm_id_1;
            }
            set
            {
                if (_hold_clm_id_1 != value)
                {
                    _hold_clm_id_1 = value;
                    _hold_clm_id_1 = _hold_clm_id_1.ToUpper();
                    RaisePropertyChanged("hold_clm_id_1");
                }
            }
        }

        private string _hold_clm_id_2;
        public string hold_clm_id_2
        {
            get
            {
                return _hold_clm_id_2;
            }
            set
            {
                if (_hold_clm_id_2 != value)
                {
                    _hold_clm_id_2 = value;
                    _hold_clm_id_2 = _hold_clm_id_2.ToUpper();
                    RaisePropertyChanged("hold_clm_id_2");
                }
            }
        }

        private string _hold_clm_id_3;
        public string hold_clm_id_3
        {
            get
            {
                return _hold_clm_id_3;
            }
            set
            {
                if (_hold_clm_id_3 != value)
                {
                    _hold_clm_id_3 = value;
                    _hold_clm_id_3 = _hold_clm_id_3.ToUpper();
                    RaisePropertyChanged("hold_clm_id_3");
                }
            }
        }

        private string _hold_clm_id_4;
        public string hold_clm_id_4
        {
            get
            {
                return _hold_clm_id_4;
            }
            set
            {
                if (_hold_clm_id_4 != value)
                {
                    _hold_clm_id_4 = value;
                    _hold_clm_id_4 = _hold_clm_id_4.ToUpper();
                    RaisePropertyChanged("hold_clm_id_4");
                }
            }
        }

        private string _hold_clm_id_5;
        public string hold_clm_id_5
        {
            get
            {
                return _hold_clm_id_5;
            }
            set
            {
                if (_hold_clm_id_5 != value)
                {
                    _hold_clm_id_5 = value;
                    _hold_clm_id_5 = _hold_clm_id_5.ToUpper();
                    RaisePropertyChanged("hold_clm_id_5");
                }
            }
        }

        private string _hold_clm_id_6;
        public string hold_clm_id_6
        {
            get
            {
                return _hold_clm_id_6;
            }
            set
            {
                if (_hold_clm_id_6 != value)
                {
                    _hold_clm_id_6 = value;
                    _hold_clm_id_6 = _hold_clm_id_6.ToUpper();
                    RaisePropertyChanged("hold_clm_id_6");
                }
            }
        }

        private string _hold_clm_id_7;
        public string hold_clm_id_7
        {
            get
            {
                return _hold_clm_id_7;
            }
            set
            {
                if (_hold_clm_id_7 != value)
                {
                    _hold_clm_id_7 = value;
                    _hold_clm_id_7 = _hold_clm_id_7.ToUpper();
                    RaisePropertyChanged("hold_clm_id_7");
                }
            }
        }

        private string _hold_clm_id_8;
        public string hold_clm_id_8
        {
            get
            {
                return _hold_clm_id_8;
            }
            set
            {
                if (_hold_clm_id_8 != value)
                {
                    _hold_clm_id_8 = value;
                    _hold_clm_id_8 = _hold_clm_id_8.ToUpper();
                    RaisePropertyChanged("hold_clm_id_8");
                }
            }
        }

        private string _hold_clm_oma_cd_1;
        public string hold_clm_oma_cd_1
        {
            get
            {
                return _hold_clm_oma_cd_1;
            }
            set
            {
                if (_hold_clm_oma_cd_1 != value)
                {
                    _hold_clm_oma_cd_1 = value;
                    _hold_clm_oma_cd_1 = _hold_clm_oma_cd_1.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_1");
                }
            }
        }

        private string _hold_clm_oma_cd_2;
        public string hold_clm_oma_cd_2
        {
            get
            {
                return _hold_clm_oma_cd_2;
            }
            set
            {
                if (_hold_clm_oma_cd_2 != value)
                {
                    _hold_clm_oma_cd_2 = value;
                    _hold_clm_oma_cd_2 = _hold_clm_oma_cd_2.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_2");
                }
            }
        }

        private string _hold_clm_oma_cd_3;
        public string hold_clm_oma_cd_3
        {
            get
            {
                return _hold_clm_oma_cd_3;
            }
            set
            {
                if (_hold_clm_oma_cd_3 != value)
                {
                    _hold_clm_oma_cd_3 = value;
                    _hold_clm_oma_cd_3 = _hold_clm_oma_cd_3.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_3");
                }
            }
        }

        private string _hold_clm_oma_cd_4;
        public string hold_clm_oma_cd_4
        {
            get
            {
                return _hold_clm_oma_cd_4;
            }
            set
            {
                if (_hold_clm_oma_cd_4 != value)
                {
                    _hold_clm_oma_cd_4 = value;
                    _hold_clm_oma_cd_4 = _hold_clm_oma_cd_4.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_4");
                }
            }
        }

        private string _hold_clm_oma_cd_5;
        public string hold_clm_oma_cd_5
        {
            get
            {
                return _hold_clm_oma_cd_5;
            }
            set
            {
                if (_hold_clm_oma_cd_5 != value)
                {
                    _hold_clm_oma_cd_5 = value;
                    _hold_clm_oma_cd_5 = _hold_clm_oma_cd_5.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_5");
                }
            }
        }

        private string _hold_clm_oma_cd_6;
        public string hold_clm_oma_cd_6
        {
            get
            {
                return _hold_clm_oma_cd_6;
            }
            set
            {
                if (_hold_clm_oma_cd_6 != value)
                {
                    _hold_clm_oma_cd_6 = value;
                    _hold_clm_oma_cd_6 = _hold_clm_oma_cd_6.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_6");
                }
            }
        }

        private string _hold_clm_oma_cd_7;
        public string hold_clm_oma_cd_7
        {
            get
            {
                return _hold_clm_oma_cd_7;
            }
            set
            {
                if (_hold_clm_oma_cd_7 != value)
                {
                    _hold_clm_oma_cd_7 = value;
                    _hold_clm_oma_cd_7 = _hold_clm_oma_cd_7.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_7");
                }
            }
        }

        private string _hold_clm_oma_cd_8;
        public string hold_clm_oma_cd_8
        {
            get
            {
                return _hold_clm_oma_cd_8;
            }
            set
            {
                if (_hold_clm_oma_cd_8 != value)
                {
                    _hold_clm_oma_cd_8 = value;
                    _hold_clm_oma_cd_8 = _hold_clm_oma_cd_8.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_cd_8");
                }
            }
        }

        private string _hold_clm_oma_suff_1;
        public string hold_clm_oma_suff_1
        {
            get
            {
                return _hold_clm_oma_suff_1;
            }
            set
            {
                if (_hold_clm_oma_suff_1 != value)
                {
                    _hold_clm_oma_suff_1 = value;
                    _hold_clm_oma_suff_1 = _hold_clm_oma_suff_1.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_1");
                }
            }
        }

        private string _hold_clm_oma_suff_2;
        public string hold_clm_oma_suff_2
        {
            get
            {
                return _hold_clm_oma_suff_2;
            }
            set
            {
                if (_hold_clm_oma_suff_2 != value)
                {
                    _hold_clm_oma_suff_2 = value;
                    _hold_clm_oma_suff_2 = _hold_clm_oma_suff_2.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_2");
                }
            }
        }

        private string _hold_clm_oma_suff_3;
        public string hold_clm_oma_suff_3
        {
            get
            {
                return _hold_clm_oma_suff_3;
            }
            set
            {
                if (_hold_clm_oma_suff_3 != value)
                {
                    _hold_clm_oma_suff_3 = value;
                    _hold_clm_oma_suff_3 = _hold_clm_oma_suff_3.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_3");
                }
            }
        }

        private string _hold_clm_oma_suff_4;
        public string hold_clm_oma_suff_4
        {
            get
            {
                return _hold_clm_oma_suff_4;
            }
            set
            {
                if (_hold_clm_oma_suff_4 != value)
                {
                    _hold_clm_oma_suff_4 = value;
                    _hold_clm_oma_suff_4 = _hold_clm_oma_suff_4.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_4");
                }
            }
        }

        private string _hold_clm_oma_suff_5;
        public string hold_clm_oma_suff_5
        {
            get
            {
                return _hold_clm_oma_suff_5;
            }
            set
            {
                if (_hold_clm_oma_suff_5 != value)
                {
                    _hold_clm_oma_suff_5 = value;
                    _hold_clm_oma_suff_5 = _hold_clm_oma_suff_5.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_5");
                }
            }
        }

        private string _hold_clm_oma_suff_6;
        public string hold_clm_oma_suff_6
        {
            get
            {
                return _hold_clm_oma_suff_6;
            }
            set
            {
                if (_hold_clm_oma_suff_6 != value)
                {
                    _hold_clm_oma_suff_6 = value;
                    _hold_clm_oma_suff_6 = _hold_clm_oma_suff_6.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_6");
                }
            }
        }

        private string _hold_clm_oma_suff_7;
        public string hold_clm_oma_suff_7
        {
            get
            {
                return _hold_clm_oma_suff_7;
            }
            set
            {
                if (_hold_clm_oma_suff_7 != value)
                {
                    _hold_clm_oma_suff_7 = value;
                    _hold_clm_oma_suff_7 = _hold_clm_oma_suff_7.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_7");
                }
            }
        }

        private string _hold_clm_oma_suff_8;
        public string hold_clm_oma_suff_8
        {
            get
            {
                return _hold_clm_oma_suff_8;
            }
            set
            {
                if (_hold_clm_oma_suff_8 != value)
                {
                    _hold_clm_oma_suff_8 = value;
                    _hold_clm_oma_suff_8 = _hold_clm_oma_suff_8.ToUpper();
                    RaisePropertyChanged("hold_clm_oma_suff_8");
                }
            }
        }

        private string _hold_clm_per_end_date_1;
        public string hold_clm_per_end_date_1
        {
            get
            {
                return _hold_clm_per_end_date_1;
            }
            set
            {
                if (_hold_clm_per_end_date_1 != value)
                {
                    _hold_clm_per_end_date_1 = value;
                    _hold_clm_per_end_date_1 = _hold_clm_per_end_date_1.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_1");
                }
            }
        }

        private string _hold_clm_per_end_date_2;
        public string hold_clm_per_end_date_2
        {
            get
            {
                return _hold_clm_per_end_date_2;
            }
            set
            {
                if (_hold_clm_per_end_date_2 != value)
                {
                    _hold_clm_per_end_date_2 = value;
                    _hold_clm_per_end_date_2 = _hold_clm_per_end_date_2.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_2");
                }
            }
        }

        private string _hold_clm_per_end_date_3;
        public string hold_clm_per_end_date_3
        {
            get
            {
                return _hold_clm_per_end_date_3;
            }
            set
            {
                if (_hold_clm_per_end_date_3 != value)
                {
                    _hold_clm_per_end_date_3 = value;
                    _hold_clm_per_end_date_3 = _hold_clm_per_end_date_3.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_3");
                }
            }
        }

        private string _hold_clm_per_end_date_4;
        public string hold_clm_per_end_date_4
        {
            get
            {
                return _hold_clm_per_end_date_4;
            }
            set
            {
                if (_hold_clm_per_end_date_4 != value)
                {
                    _hold_clm_per_end_date_4 = value;
                    _hold_clm_per_end_date_4 = _hold_clm_per_end_date_4.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_4");
                }
            }
        }

        private string _hold_clm_per_end_date_5;
        public string hold_clm_per_end_date_5
        {
            get
            {
                return _hold_clm_per_end_date_5;
            }
            set
            {
                if (_hold_clm_per_end_date_5 != value)
                {
                    _hold_clm_per_end_date_5 = value;
                    _hold_clm_per_end_date_5 = _hold_clm_per_end_date_5.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_5");
                }
            }
        }

        private string _hold_clm_per_end_date_6;
        public string hold_clm_per_end_date_6
        {
            get
            {
                return _hold_clm_per_end_date_6;
            }
            set
            {
                if (_hold_clm_per_end_date_6 != value)
                {
                    _hold_clm_per_end_date_6 = value;
                    _hold_clm_per_end_date_6 = _hold_clm_per_end_date_6.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_6");
                }
            }
        }

        private string _hold_clm_per_end_date_7;
        public string hold_clm_per_end_date_7
        {
            get
            {
                return _hold_clm_per_end_date_7;
            }
            set
            {
                if (_hold_clm_per_end_date_7 != value)
                {
                    _hold_clm_per_end_date_7 = value;
                    _hold_clm_per_end_date_7 = _hold_clm_per_end_date_7.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_7");
                }
            }
        }

        private string _hold_clm_per_end_date_8;
        public string hold_clm_per_end_date_8
        {
            get
            {
                return _hold_clm_per_end_date_8;
            }
            set
            {
                if (_hold_clm_per_end_date_8 != value)
                {
                    _hold_clm_per_end_date_8 = value;
                    _hold_clm_per_end_date_8 = _hold_clm_per_end_date_8.ToUpper();
                    RaisePropertyChanged("hold_clm_per_end_date_8");
                }
            }
        }

        private int _hold_clm_svc_1;
        public int hold_clm_svc_1
        {
            get
            {
                return _hold_clm_svc_1;
            }
            set
            {
                if (_hold_clm_svc_1 != value)
                {
                    _hold_clm_svc_1 = value;
                    RaisePropertyChanged("hold_clm_svc_1");
                }
            }
        }

        private int _hold_clm_svc_2;
        public int hold_clm_svc_2
        {
            get
            {
                return _hold_clm_svc_2;
            }
            set
            {
                if (_hold_clm_svc_2 != value)
                {
                    _hold_clm_svc_2 = value;
                    RaisePropertyChanged("hold_clm_svc_2");
                }
            }
        }

        private int _hold_clm_svc_3;
        public int hold_clm_svc_3
        {
            get
            {
                return _hold_clm_svc_3;
            }
            set
            {
                if (_hold_clm_svc_3 != value)
                {
                    _hold_clm_svc_3 = value;
                    RaisePropertyChanged("hold_clm_svc_3");
                }
            }
        }

        private int _hold_clm_svc_4;
        public int hold_clm_svc_4
        {
            get
            {
                return _hold_clm_svc_4;
            }
            set
            {
                if (_hold_clm_svc_4 != value)
                {
                    _hold_clm_svc_4 = value;
                    RaisePropertyChanged("hold_clm_svc_4");
                }
            }
        }

        private int _hold_clm_svc_5;
        public int hold_clm_svc_5
        {
            get
            {
                return _hold_clm_svc_5;
            }
            set
            {
                if (_hold_clm_svc_5 != value)
                {
                    _hold_clm_svc_5 = value;
                    RaisePropertyChanged("hold_clm_svc_5");
                }
            }
        }

        private int _hold_clm_svc_6;
        public int hold_clm_svc_6
        {
            get
            {
                return _hold_clm_svc_6;
            }
            set
            {
                if (_hold_clm_svc_6 != value)
                {
                    _hold_clm_svc_6 = value;
                    RaisePropertyChanged("hold_clm_svc_6");
                }
            }
        }

        private int _hold_clm_svc_7;
        public int hold_clm_svc_7
        {
            get
            {
                return _hold_clm_svc_7;
            }
            set
            {
                if (_hold_clm_svc_7 != value)
                {
                    _hold_clm_svc_7 = value;
                    RaisePropertyChanged("hold_clm_svc_7");
                }
            }
        }

        private int _hold_clm_svc_8;
        public int hold_clm_svc_8
        {
            get
            {
                return _hold_clm_svc_8;
            }
            set
            {
                if (_hold_clm_svc_8 != value)
                {
                    _hold_clm_svc_8 = value;
                    RaisePropertyChanged("hold_clm_svc_8");
                }
            }
        }

        private string _hold_clm_svc_date_1;
        public string hold_clm_svc_date_1
        {
            get
            {
                return _hold_clm_svc_date_1;
            }
            set
            {
                if (_hold_clm_svc_date_1 != value)
                {
                    _hold_clm_svc_date_1 = value;
                    _hold_clm_svc_date_1 = _hold_clm_svc_date_1.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_1");
                }
            }
        }

        private string _hold_clm_svc_date_2;
        public string hold_clm_svc_date_2
        {
            get
            {
                return _hold_clm_svc_date_2;
            }
            set
            {
                if (_hold_clm_svc_date_2 != value)
                {
                    _hold_clm_svc_date_2 = value;
                    _hold_clm_svc_date_2 = _hold_clm_svc_date_2.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_2");
                }
            }
        }

        private string _hold_clm_svc_date_3;
        public string hold_clm_svc_date_3
        {
            get
            {
                return _hold_clm_svc_date_3;
            }
            set
            {
                if (_hold_clm_svc_date_3 != value)
                {
                    _hold_clm_svc_date_3 = value;
                    _hold_clm_svc_date_3 = _hold_clm_svc_date_3.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_3");
                }
            }
        }

        private string _hold_clm_svc_date_4;
        public string hold_clm_svc_date_4
        {
            get
            {
                return _hold_clm_svc_date_4;
            }
            set
            {
                if (_hold_clm_svc_date_4 != value)
                {
                    _hold_clm_svc_date_4 = value;
                    _hold_clm_svc_date_4 = _hold_clm_svc_date_4.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_4");
                }
            }
        }

        private string _hold_clm_svc_date_5;
        public string hold_clm_svc_date_5
        {
            get
            {
                return _hold_clm_svc_date_5;
            }
            set
            {
                if (_hold_clm_svc_date_5 != value)
                {
                    _hold_clm_svc_date_5 = value;
                    _hold_clm_svc_date_5 = _hold_clm_svc_date_5.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_5");
                }
            }
        }

        private string _hold_clm_svc_date_6;
        public string hold_clm_svc_date_6
        {
            get
            {
                return _hold_clm_svc_date_6;
            }
            set
            {
                if (_hold_clm_svc_date_6 != value)
                {
                    _hold_clm_svc_date_6 = value;
                    _hold_clm_svc_date_6 = _hold_clm_svc_date_6.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_6");
                }
            }
        }

        private string _hold_clm_svc_date_7;
        public string hold_clm_svc_date_7
        {
            get
            {
                return _hold_clm_svc_date_7;
            }
            set
            {
                if (_hold_clm_svc_date_7 != value)
                {
                    _hold_clm_svc_date_7 = value;
                    _hold_clm_svc_date_7 = _hold_clm_svc_date_7.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_7");
                }
            }
        }

        private string _hold_clm_svc_date_8;
        public string hold_clm_svc_date_8
        {
            get
            {
                return _hold_clm_svc_date_8;
            }
            set
            {
                if (_hold_clm_svc_date_8 != value)
                {
                    _hold_clm_svc_date_8 = value;
                    _hold_clm_svc_date_8 = _hold_clm_svc_date_8.ToUpper();
                    RaisePropertyChanged("hold_clm_svc_date_8");
                }
            }
        }

        private decimal _hold_clmhdr_bal;
        public decimal hold_clmhdr_bal
        {
            get
            {
                return _hold_clmhdr_bal;
            }
            set
            {
                if (_hold_clmhdr_bal != value)
                {
                    _hold_clmhdr_bal = value;
                    RaisePropertyChanged("hold_clmhdr_bal");
                }
            }
        }

        private string _hold_desc_1;
        public string hold_desc_1
        {
            get
            {
                return _hold_desc_1;
            }
            set
            {
                if (_hold_desc_1 != value)
                {
                    _hold_desc_1 = value;
                    _hold_desc_1 = _hold_desc_1.ToUpper();
                    RaisePropertyChanged("hold_desc_1");
                }
            }
        }

        private string _hold_desc_2;
        public string hold_desc_2
        {
            get
            {
                return _hold_desc_2;
            }
            set
            {
                if (_hold_desc_2 != value)
                {
                    _hold_desc_2 = value;
                    _hold_desc_2 = _hold_desc_2.ToUpper();
                    RaisePropertyChanged("hold_desc_2");
                }
            }
        }

        private string _hold_desc_3;
        public string hold_desc_3
        {
            get
            {
                return _hold_desc_3;
            }
            set
            {
                if (_hold_desc_3 != value)
                {
                    _hold_desc_3 = value;
                    _hold_desc_3 = _hold_desc_3.ToUpper();
                    RaisePropertyChanged("hold_desc_3");
                }
            }
        }

        private string _hold_desc_4;
        public string hold_desc_4
        {
            get
            {
                return _hold_desc_4;
            }
            set
            {
                if (_hold_desc_4 != value)
                {
                    _hold_desc_4 = value;
                    _hold_desc_4 = _hold_desc_4.ToUpper();
                    RaisePropertyChanged("hold_desc_4");
                }
            }
        }

        private string _hold_desc_5;
        public string hold_desc_5
        {
            get
            {
                return _hold_desc_5;
            }
            set
            {
                if (_hold_desc_5 != value)
                {
                    _hold_desc_5 = value;
                    _hold_desc_5 = _hold_desc_5.ToUpper();
                    RaisePropertyChanged("hold_desc_5");
                }
            }
        }

        private string _pat_chart_nbr_grp;
        public string pat_chart_nbr_grp
        {
            get
            {
                return _pat_chart_nbr_grp;
            }
            set
            {
                if (_pat_chart_nbr_grp != value)
                {
                    _pat_chart_nbr_grp = value;
                    _pat_chart_nbr_grp = _pat_chart_nbr_grp.ToUpper();
                    RaisePropertyChanged("pat_chart_nbr_grp");
                }
            }
        }

        private string _pat_given_name;
        public string pat_given_name
        {
            get
            {
                return _pat_given_name;
            }
            set
            {
                if (_pat_given_name != value)
                {
                    _pat_given_name = value;
                    _pat_given_name = _pat_given_name.ToUpper();
                    RaisePropertyChanged("pat_given_name");
                }
            }
        }

        private string _pat_health_nbr;
        public string pat_health_nbr
        {
            get
            {
                return _pat_health_nbr;
            }
            set
            {
                if (_pat_health_nbr != value)
                {
                    _pat_health_nbr = value;
                    _pat_health_nbr = _pat_health_nbr.ToUpper();
                    RaisePropertyChanged("pat_health_nbr");
                }
            }
        }

        private string _pat_init;
        public string pat_init
        {
            get
            {
                return _pat_init;
            }
            set
            {
                if (_pat_init != value)
                {
                    _pat_init = value;
                    _pat_init = _pat_init.ToUpper();
                    RaisePropertyChanged("pat_init");
                }
            }
        }

        private string _pat_ohip_mmyy;
        public string pat_ohip_mmyy
        {
            get
            {
                return _pat_ohip_mmyy;
            }
            set
            {
                if (_pat_ohip_mmyy != value)
                {
                    _pat_ohip_mmyy = value;
                    _pat_ohip_mmyy = _pat_ohip_mmyy.ToUpper();
                    RaisePropertyChanged("pat_ohip_mmyy");
                }
            }
        }

        private string _pat_ohip_mmyy_r;
        public string pat_ohip_mmyy_r
        {
            get
            {
                return _pat_ohip_mmyy_r;
            }
            set
            {
                if (_pat_ohip_mmyy_r != value)
                {
                    _pat_ohip_mmyy_r = value;
                    _pat_ohip_mmyy_r = _pat_ohip_mmyy_r.ToUpper();
                    RaisePropertyChanged("pat_ohip_mmyy_r");
                }
            }
        }

        private string _pat_surname;
        public string pat_surname
        {
            get
            {
                return _pat_surname;
            }
            set
            {
                if (_pat_surname != value)
                {
                    _pat_surname = value;
                    _pat_surname = _pat_surname.ToUpper();
                    RaisePropertyChanged("pat_surname");
                }
            }
        }

        private string _reply_create_pat;
        public string reply_create_pat
        {
            get
            {
                return _reply_create_pat;
            }
            set
            {
                if (_reply_create_pat != value)
                {
                    _reply_create_pat = value;
                    _reply_create_pat = _reply_create_pat.ToUpper();
                    RaisePropertyChanged("reply_create_pat");
                }
            }
        }

        private string _status_common;
        public string status_common
        {
            get
            {
                return _status_common;
            }
            set
            {
                if (_status_common != value)
                {
                    _status_common = value;
                    _status_common = _status_common.ToUpper();
                    RaisePropertyChanged("status_common");
                }
            }
        }

        private int _sys_dd;
        public int sys_dd
        {
            get
            {
                return _sys_dd;
            }
            set
            {
                if (_sys_dd != value)
                {
                    _sys_dd = value;
                    RaisePropertyChanged("sys_dd");
                }
            }
        }

        private int _sys_hrs;
        public int sys_hrs
        {
            get
            {
                return _sys_hrs;
            }
            set
            {
                if (_sys_hrs != value)
                {
                    _sys_hrs = value;
                    RaisePropertyChanged("sys_hrs");
                }
            }
        }

        private int _sys_min;
        public int sys_min
        {
            get
            {
                return _sys_min;
            }
            set
            {
                if (_sys_min != value)
                {
                    _sys_min = value;
                    RaisePropertyChanged("sys_min");
                }
            }
        }

        private int _sys_mm;
        public int sys_mm
        {
            get
            {
                return _sys_mm;
            }
            set
            {
                if (_sys_mm != value)
                {
                    _sys_mm = value;
                    RaisePropertyChanged("sys_mm");
                }
            }
        }

        private int _sys_yy;
        public int sys_yy
        {
            get
            {
                return _sys_yy;
            }
            set
            {
                if (_sys_yy != value)
                {
                    _sys_yy = value;
                    RaisePropertyChanged("sys_yy");
                }
            }
        }

        private string _ws_clmhdr_delete;
        public string ws_clmhdr_delete
        {
            get
            {
                return _ws_clmhdr_delete;
            }
            set
            {
                if (_ws_clmhdr_delete != value)
                {
                    _ws_clmhdr_delete = value;
                    _ws_clmhdr_delete = _ws_clmhdr_delete.ToUpper();
                    RaisePropertyChanged("ws_clmhdr_delete");
                }
            }
        }

        private string _ws_disp_pat_key_type;
        public string ws_disp_pat_key_type
        {
            get
            {
                return _ws_disp_pat_key_type;
            }
            set
            {
                if (_ws_disp_pat_key_type != value)
                {
                    _ws_disp_pat_key_type = value;
                    _ws_disp_pat_key_type = _ws_disp_pat_key_type.ToUpper();
                    RaisePropertyChanged("ws_disp_pat_key_type");
                }
            }
        }

        private string _ws_err_diag;
        public string ws_err_diag
        {
            get
            {
                return _ws_err_diag;
            }
            set
            {
                if (_ws_err_diag != value)
                {
                    _ws_err_diag = value;
                    _ws_err_diag = _ws_err_diag.ToUpper();
                    RaisePropertyChanged("ws_err_diag");
                }
            }
        }

        private string _ws_err_oma_cd_1;
        public string ws_err_oma_cd_1
        {
            get
            {
                return _ws_err_oma_cd_1;
            }
            set
            {
                if (_ws_err_oma_cd_1 != value)
                {
                    _ws_err_oma_cd_1 = value;
                    _ws_err_oma_cd_1 = _ws_err_oma_cd_1.ToUpper();
                    RaisePropertyChanged("ws_err_oma_cd_1");
                }
            }
        }

        private string _ws_err_oma_cd_2;
        public string ws_err_oma_cd_2
        {
            get
            {
                return _ws_err_oma_cd_2;
            }
            set
            {
                if (_ws_err_oma_cd_2 != value)
                {
                    _ws_err_oma_cd_2 = value;
                    _ws_err_oma_cd_2 = _ws_err_oma_cd_2.ToUpper();
                    RaisePropertyChanged("ws_err_oma_cd_2");
                }
            }
        }

        private string _ws_err_oma_cd_3;
        public string ws_err_oma_cd_3
        {
            get
            {
                return _ws_err_oma_cd_3;
            }
            set
            {
                if (_ws_err_oma_cd_3 != value)
                {
                    _ws_err_oma_cd_3 = value;
                    _ws_err_oma_cd_3 = _ws_err_oma_cd_3.ToUpper();
                    RaisePropertyChanged("ws_err_oma_cd_3");
                }
            }
        }

        private string _ws_err_oma_cd_4;
        public string ws_err_oma_cd_4
        {
            get
            {
                return _ws_err_oma_cd_4;
            }
            set
            {
                if (_ws_err_oma_cd_4 != value)
                {
                    _ws_err_oma_cd_4 = value;
                    _ws_err_oma_cd_4 = _ws_err_oma_cd_4.ToUpper();
                    RaisePropertyChanged("ws_err_oma_cd_4");
                }
            }
        }

        private string _ws_err_oma_cd_5;
        public string ws_err_oma_cd_5
        {
            get
            {
                return _ws_err_oma_cd_5;
            }
            set
            {
                if (_ws_err_oma_cd_5 != value)
                {
                    _ws_err_oma_cd_5 = value;
                    _ws_err_oma_cd_5 = _ws_err_oma_cd_5.ToUpper();
                    RaisePropertyChanged("ws_err_oma_cd_5");
                }
            }
        }

        private string _ws_err_oma_cd_6;
        public string ws_err_oma_cd_6
        {
            get
            {
                return _ws_err_oma_cd_6;
            }
            set
            {
                if (_ws_err_oma_cd_6 != value)
                {
                    _ws_err_oma_cd_6 = value;
                    _ws_err_oma_cd_6 = _ws_err_oma_cd_6.ToUpper();
                    RaisePropertyChanged("ws_err_oma_cd_6");
                }
            }
        }

        private string _ws_err_oma_msg;
        public string ws_err_oma_msg
        {
            get
            {
                return _ws_err_oma_msg;
            }
            set
            {
                if (_ws_err_oma_msg != value)
                {
                    _ws_err_oma_msg = value;
                    _ws_err_oma_msg = _ws_err_oma_msg.ToUpper();
                    RaisePropertyChanged("ws_err_oma_msg");
                }
            }
        }

        private string _ws_err_oma_msg_star;
        public string ws_err_oma_msg_star
        {
            get
            {
                return _ws_err_oma_msg_star;
            }
            set
            {
                if (_ws_err_oma_msg_star != value)
                {
                    _ws_err_oma_msg_star = value;
                    _ws_err_oma_msg_star = _ws_err_oma_msg_star.ToUpper();
                    RaisePropertyChanged("ws_err_oma_msg_star");
                }
            }
        }

        private string _ws_file_err_msg;
        public string ws_file_err_msg
        {
            get
            {
                return _ws_file_err_msg;
            }
            set
            {
                if (_ws_file_err_msg != value)
                {
                    _ws_file_err_msg = value;
                    _ws_file_err_msg = _ws_file_err_msg.ToUpper();
                    RaisePropertyChanged("ws_file_err_msg");
                }
            }
        }

        private string _ws_hosp_nbr;
        public string ws_hosp_nbr
        {
            get
            {
                return _ws_hosp_nbr;
            }
            set
            {
                if (_ws_hosp_nbr != value)
                {
                    _ws_hosp_nbr = value;
                    _ws_hosp_nbr = _ws_hosp_nbr.ToUpper();
                    RaisePropertyChanged("ws_hosp_nbr");
                }
            }
        }

        private string _ws_pat_id;
        public string ws_pat_id
        {
            get
            {
                return _ws_pat_id;
            }
            set
            {
                if (_ws_pat_id != value)
                {
                    _ws_pat_id = value;
                    _ws_pat_id = _ws_pat_id.ToUpper();
                    RaisePropertyChanged("ws_pat_id");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private string option;
        private int pat_count;
        private int pat_occur;
        private int claims_occur;
        private string display_key_type;
        private int subs_table_addr;
        private int ss_clmdtl = 0;
        private int ss_nbr_fnd;
        private int ss_nbr;
        private int temp;
        private string end_job = "N";
        //private string ws_hosp_nbr;
        private string ws_pat_acronym;
        //private string ws_pat_id;
        private string ws_more_msg;
        private int ws_sel_nbr;
        private string end_search_index = "N";
        private int ws_total_nbr_svc;
        private string flag_del;
        private string eof_pat_mstr = "N";
        private string eof_claims_mstr = "N";
        private string eof_batctrl_file = "N";
        //private string confirm_space = space;

        //private string acpt_claim_id_grp;
        private string acpt_claim_grp;
        private int acpt_claim_clinic;
        private string acpt_claim_clinic_r_grp;
        private string acpt_claim_clinic_1;
        private string filler;
        private string acpt_claim_doc_nbr;
        private int acpt_claim_week;
        private int acpt_claim_day;
        private int acpt_claim_claim_nbr;
        private string acpt_acronym;
        //private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string flag_ohip_vs_chart;
        private string ohip = "O";
        private string chart = "C";
        private string flag_found_batch;
        private string flag_found_batch_y = "Y";
        private string flag_found_batch_n = "N";
        private string flag_batch_status;
        private string flag_batch_status_ok = "Y";
        private string flag_batch_status_not_ok = "N";
        private string flag_del_clm;
        private string flag_del_clm_y = "Y";
        private string flag_del_clm_n = "N";
        private string flag_valid_ohip_or_chart;
        private string valid_ohip = "Y";
        private string valid_chart = "Y";
        private string invalid_ohip = "N";
        private string invalid_chart = "N";
        private string flag_ohip_mmyy;
        private string valid_mmyy = "Y";
        private string invalid_mmyy = "N";
        private int err_ind = 0;
        private string password_input;
        private string password = "RMA";
        private string reply;
        private string change_reply;
        private string hold_feedback_clmhdr;
        private string hold_key_claims_mstr;
        private string hold_pat_key_data;
        private string hold_batch_nbr = "";
        private int hold_claim_nbr = 0;
        //private string ws_clmhdr_delete;
        //private string ws_disp_pat_key_type;
        private string ws_disp_pat_err_msg;
        private string ws_doc_nbr;
        private decimal ws_batctrl_amt_diff;
        private int ws_nbr_clmdtl_recs;
        private decimal ws_batctrl_svc_diff;
        //private string ws_file_err_msg = "";
        private string ws_i_o_pat_ind;
        private string ws_oma_cd;
        private string ws_oma_suff;
        private string ws_loc;

        private string ws_date_grp;
        private int ws_yy;
        private int ws_mm;
        private int ws_dd;
        private int ss;
        private int subs_hosp;
        private int ss_clmhdr;
        private int ss_clmdtl_oma;
        private int ss_clmdtl_desc;
        private int ss_conseq_dd;
        private int ss_det_nbr;
        private int ss_ind;
        private int ss_card_colour_ind = 1;
        private int ss_diag_ind = 2;
        private int ss_phy_ind = 3;
        private int ss_hosp_nbr_ind = 4;
        private int ss_i_o_ind = 5;
        private int ss_admit_ind = 6;
        private int ss_max_nbr_locs_in_doc_rec = 20;
        private int ss_max_nbr_of_desc_rec_allow = 5;
        private string feedback_claims_mstr;
        private string feedback_pat_mstr;
        private string feedback_batctrl_file;
        private string eof_filename_here = "N";
        //private string status_common;
        private string status_claims_mstr = "0";
        private string status_cobol_claims_mstr;
        private string status_pat_mstr = "0";
        private string status_cobol_pat_mstr;
        private string status_batctrl_file = "0";
        private string status_cobol_batctrl_file;

        private string ws_hold_clmdtl_batch_nbr_grp;
        private int ws_clinic_nbr1;
        private string ws_doc_nbr_grp;
        private string ws_doc_nbr3;
        private int ws_week_day;
        //private string option;
        private string new_batch = "1";
        private string old_batch = "2";
        private string stop_option = "S";
        private string flag_err_data;
        private string err_data = "N";
        private string ok_data = "Y";
        private string flag_done_clmdtl_recs;
        private string done_clmdtl_recs_yes = "Y";
        private string flag_eoj;
        private string eoj_create_new_patient = "C";
        private string eoj = "E";
        //private string reply_create_pat;
        private string new_patient = "Y";
        private string err_patient = "N";

        private string counters_grp;
        //private int ctr_read_batctrl_mstr;
        //private int ctr_read_claims_mstr;
        //private int ctr_read_pat_mstr;
        //private int ctr_writ_batctrl_file;
        //private int ctr_writ_claims_mstr;
        private int ctr_rewrit_batctrl_mstr;
        private int ctr_rewrit_claims_mstr;

        private int ctr_read_claims_mstr_dtl;

        private string hold_claim_detail_grp;
        private string hold_clm_table_1_grp;
        //private string hold_clm_id_1;
        //private int hold_clm_clm_nbr_1;
        //private int hold_clm_cyc_1;
        //private string hold_clm_per_end_date_1;
        //private string hold_clm_svc_date_1;
        //private string hold_clm_oma_cd_1;
        //private string hold_clm_oma_suff_1;
        //private int hold_clm_svc_1;
        //private int hold_clm_agent_1;
        //private string hold_clm_adj_cd_1;
        //private string hold_clm_card_col_1;
        //private decimal hold_clm_amt_due_1;
        private string hold_clm_table_2_grp;
        //private string hold_clm_id_2;
        //private int hold_clm_clm_nbr_2;
        //private int hold_clm_cyc_2;
        //private string hold_clm_per_end_date_2;
        //private string hold_clm_svc_date_2;
        //private string hold_clm_oma_cd_2;
        //private string hold_clm_oma_suff_2;
        //private int hold_clm_svc_2;
        //private int hold_clm_agent_2;
        //private string hold_clm_adj_cd_2;
        //private string hold_clm_card_col_2;
        //private decimal hold_clm_amt_due_2;
        private string hold_clm_table_3_grp;
        //private string hold_clm_id_3;
        //private int hold_clm_clm_nbr_3;
        //private int hold_clm_cyc_3;
        //private string hold_clm_per_end_date_3;
        //private string hold_clm_svc_date_3;
        //private string hold_clm_oma_cd_3;
        //private string hold_clm_oma_suff_3;
        //private int hold_clm_svc_3;
        //private int hold_clm_agent_3;
        //private string hold_clm_adj_cd_3;
        //private string hold_clm_card_col_3;
        //private decimal hold_clm_amt_due_3;
        private string hold_clm_table_4_grp;
        //private string hold_clm_id_4;
        //private int hold_clm_clm_nbr_4;
        //private int hold_clm_cyc_4;
        //private string hold_clm_per_end_date_4;
        //private string hold_clm_svc_date_4;
        //private string hold_clm_oma_cd_4;
        //private string hold_clm_oma_suff_4;
        //private int hold_clm_svc_4;
        //private int hold_clm_agent_4;
        //private string hold_clm_adj_cd_4;
        //private string hold_clm_card_col_4;
        //private decimal hold_clm_amt_due_4;
        private string hold_clm_table_5_grp;
        //private string hold_clm_id_5;
        //private int hold_clm_clm_nbr_5;
        //private int hold_clm_cyc_5;
        //private string hold_clm_per_end_date_5;
        //private string hold_clm_svc_date_5;
        //private string hold_clm_oma_cd_5;
        //private string hold_clm_oma_suff_5;
        //private int hold_clm_svc_5;
        //private int hold_clm_agent_5;
        //private string hold_clm_adj_cd_5;
        //private string hold_clm_card_col_5;
        //private decimal hold_clm_amt_due_5;
        private string hold_clm_table_6_grp;
        //private string hold_clm_id_6;
        //private int hold_clm_clm_nbr_6;
        //private int hold_clm_cyc_6;
        //private string hold_clm_per_end_date_6;
        //private string hold_clm_svc_date_6;
        //private string hold_clm_oma_cd_6;
        //private string hold_clm_oma_suff_6;
        //private int hold_clm_svc_6;
        //private int hold_clm_agent_6;
        //private string hold_clm_adj_cd_6;
        //private string hold_clm_card_col_6;
        //private decimal hold_clm_amt_due_6;
        private string hold_clm_table_7_grp;
        //private string hold_clm_id_7;
        //private int hold_clm_clm_nbr_7;
        //private int hold_clm_cyc_7;
        //private string hold_clm_per_end_date_7;
        //private string hold_clm_svc_date_7;
        //private string hold_clm_oma_cd_7;
        //private string hold_clm_oma_suff_7;
        //private int hold_clm_svc_7;
        //private int hold_clm_agent_7;
        //private string hold_clm_adj_cd_7;
        //private string hold_clm_card_col_7;
        //private decimal hold_clm_amt_due_7;
        private string hold_clm_table_8_grp;
        //private string hold_clm_id_8;
        //private int hold_clm_clm_nbr_8;
        //private int hold_clm_cyc_8;
        //private string hold_clm_per_end_date_8;
        //private string hold_clm_svc_date_8;
        //private string hold_clm_oma_cd_8;
        //private string hold_clm_oma_suff_8;
        //private int hold_clm_svc_8;
        //private int hold_clm_agent_8;
        //private string hold_clm_adj_cd_8;
        //private string hold_clm_card_col_8;
        //private decimal hold_clm_amt_due_8;

        private string hold_claim_detail_r_grp;
        private string[] hold_detail = new string[101];
        private string[] hold_clm_id = new string[101];
        private int[] hold_clm_clinic_nbr = new int[101];
        private string[] hold_clm_doc_nbr = new string[101];
        private int[] hold_clm_week_day = new int[101];
        private int[] hold_clm_clm_nbr = new int[101];
        private int[] hold_clm_cyc = new int[101];
        private string[] hold_clm_per_end_date = new string[101];
        private string[] hold_clm_svc_date = new string[101];
        private string[] hold_clm_oma_cd = new string[101];
        private string[] hold_clm_oma_suff = new string[101];
        private int[] hold_clm_svc = new int[101];
        private int[] hold_clm_agent = new int[101];
        private string[] hold_clm_adj_cd = new string[101];
        private string[] hold_clm_card_col = new string[101];
        private decimal[] hold_clm_amt_due = new decimal[101];
        //private decimal hold_clmhdr_bal;

        private string hold_descriptions_grp;
        //private string hold_desc_1;
        //private string hold_desc_2;
        //private string hold_desc_3;
        //private string hold_desc_4;
        //private string hold_desc_5;

        private string hold_descs_r_grp;
        private string[] hold_descs = new string[6];
        private string[] hold_desc = new string[6];

        private string ws_val_err_msg_mask_grp;
        //private string ws_err_diag;
        //private string ws_err_oma_cd_1;
        //private string ws_err_oma_cd_2;
        //private string ws_err_oma_cd_3;
        //private string ws_err_oma_cd_4;
        //private string ws_err_oma_cd_5;
        //private string ws_err_oma_cd_6;
        //private string ws_err_oma_msg_star;
        //private string ws_err_oma_msg;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string[] err_msg = {"", "invalid reply",
                                   "NO SUCH BATCH NUMBER EXISTS IN THE BATCH CONTROL FILE",
                                   "invalid password",
                                   "CLAIM NUMBER NOT FOUND",
                                   "YOU CAN'T DELETE 'P'AYMENT OR 'A'DJUSTMENT ENTRIES",
                                   "ADMIT DATE > CURRENT SYSTEM DATE",
                                   "DOCTOR SPECIFIED IS INVALID",
                                   "OMA CODES INPUT REQUIRE NON-ZERO DIAGNOSTIC CODE",
                                   "SERIOUS CONDITION !! -- BATCH'S DOCTOR NOT FOUND IN DOC MSTR",
                                   "INVALID LOCATION FOR BATCH'S DOCTOR",
                                   "INVALID HOSPITAL NUMBER",
                                   "IN/OUT PATIENT CODE MUST BE 'I' OR 'O'",
                                   "INVALID OHIP NBR / CHART ID -- PLEASE CORRECT",
                                   "BATCH TYPE MUST BE 'C', 'P', OR 'A'",
                                   "INVALID WEEK NUMBER IN BATCH ID",
                                   "INVALID DAY IN BATCH ID",
                                   "PATIENT OHIP NBR DOESN'T EXIST",
                                   "PATIENT CHART NBR DOESN'T EXIST",
                                   "1ST DIGIT OF CLINIC # MUST = 1ST DIGIT OF BATCH #",
                                   "INVALID CLINIC NUMBER",
                                   "SERIOUS CONDITION !!! - INVALID CLAIMS MSTR INDEX POINTER",
                                   "SUBSCRIBER DOES NOT EXIST ",
                                   "NO CLAIMS ALLOWED - PATIENT OHIP STATUS = 'J2','J8', OR 'K1'",
                                   "NO CLAIMS ALLOWED - PATIENT OHIP STATUS = K4,K5,K6,K7, OR K9",
                                   "SELECTED NBR > NBR OF SELECTIONS AVAILABLE ",
                                   "NO MORE PATIENTS TO DISPLAY ",
                                   "SURNAME INPUT NOT = SURNAME OF PATIENT ON FILE",
                                   "INVALID OMA CODE",
                                   "SERIOUS CONDITION #1 - INVALID WRITE ON CLAIMS HEADER INDX 1",
                                   "SERIOUS CONDITION #2 - INVALID WRITE ON CLAIMS HEADER INDX 2",
                                   "SERIOUS CONDITION !! -- INVALID WRITE ON CLAIMS DETAIL REC",
                                   "# SERVICES FROM DAY DOES NOT FALL WITHIN # DAYS IN MONTH",
                                   "SERVICE DATE < ADMIT DATE",
                                   "'OHIP' AGENT REQUIRES A REFERRING PHYSICAN",
                                   "'OHIP' AGENT REQUIRES A HOSPITAL #",
                                   "'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'I'",
                                   "'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'O'",
                                   "'OHIP' AGENT REQUIRES AN ADMIT DATE",
                                   "'OHIP' AGENT REQUIRES DOCTOR SPECIALTY CODE BE WITHIN RANGE",
                                   "'OHIP' AGENT REQUIRES SERVICE WITHIN 6 MTHS OF SYSTEM DATE",
                                   "DAY INPUT FALLS WITHIN PREVIOUS CONSEQUTIVE DAY RANGE",
                                   "BATCH ALREADY EXISTS",
                                   "PATIENT ACRONYM NOT FOUND",
                                   "INVALID DIAGNOSTIC CODE",
                                   "SERVICE DATE > SYSTEM DATE",
                                   "LAST CLAIM FOR ENTERED ACRONYM",
                                   "OMA CODE'S SUFFIX MUST BE 'A','B','C', OR 'M'",
                                   "AT END OF CLAIMS MASTER ",
                                   "SERIOUS ERROR!!! BATCH RECORD DOESN'T EXIST (CAN'T DELETE)",
                                   "SERIOUS ERROR ON BATCH CONTROL RE-WRITE",
                                   "SERIOUS ERROR WHILE ATTEMPTING TO RE-READ CLAIM HEADER",
                                   "SERIOUS ERROR IN ATTEMPTING TO READ A CLAIM WITH A 'P' TYPE",
                                   "INVALID REWRITE TO PATIENT MASTER",
                                   "INVALID DELETE ON CLAIM PATIENT INDEX",
                                   "INVALID DELETE ON CLAIM HEADER OR DETAIL RECORD",
                                   "NO DETAIL RECORD FOR HEADER OR REACH END OF FILE",
                                   "SERIOUS ERROR! INVALID BATCH DELETION",
                                   "SERIOUS ERROR! INVALID READ ON PATIENT MASTER",
                                   "CLAIM CAN'T BE DELETED -- BATCH ALREADY SENT TO OHIP",
                                   "CLAIM NUMBER MUST BE NUMERIC",
                                   "VERIFY BATCH ISN'T CURRENTLY ACCESSED ON ANOTHER SCREEN",
                                   "BATCH EXISTS WITH NO CLAIMS, IT MUST BE MANUALLY DELETED",
                                  "CLAIM HDR P.E.D. DOESN'T MATCH BATCHES P.E.D. (CAN'T DELETE)" };
        private string error_messages_r_grp;
        //private string[] err_msg = new string[64];
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp;
        private string sys_date_long;
        private string sys_date_long_r_grp;
        //private int sys_yy;
        private string sys_yy_alpha_grp;
        private int sys_y1;
        private int sys_y2;
        private int sys_y3;
        private int sys_y4;
        //private int sys_mm;
        //private int sys_dd;
        private int sys_date_numeric;

        private string sys_date_y2kfix_grp;
        private string sys_date_left;
        //private string filler;

        private string sys_date_y2kfixed_grp;
        private string sys_date_blank;
        private string sys_date_right;
        private string sys_date_temp;

        private string run_date_grp;
        private int run_yy;
        //private string filler = "/";
        private int run_mm;
        //private string filler = "/";
        private int run_dd;

        private string sys_time_grp;
        //private int sys_hrs;
        //private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        private string run_time_grp;
        private int run_hrs;
        //private string filler = ":";
        private int run_min;
        //private string filler = ":";
        private int run_sec;

        private string claim_header_rec_grp;
        private string clmhdr_claim_id_grp;
        private string clmhdr_batch_nbr;
        private string clmhdr_batch_nbr_r1_grp;
        //private int clmhdr_clinic_nbr_1_2;
        //private string clmhdr_doc_nbr;
        //private string clmhdr_week;
        //private string clmhdr_day;
        private string clmhdr_batch_nbr_r2_grp;
        //private string filler;
        private string clmhdr_batch_nbr_3_6;
        private int clmhdr_batch_nbr_7_9;
        //private int clmhdr_claim_nbr;
        private string clmhdr_zeroed_oma_suff_adj_grp;
        private string clmhdr_adj_oma_cd;
        private string clmhdr_adj_oma_suff;
        private int clmhdr_adj_adj_nbr;
        private int clmhdr_zeroed_area;
        private string clmhdr_batch_type;
        private string clmhdr_adj_cd_sub_type;
        private int clmhdr_adj_cd_sub_type_ss;
        private string clmhdr_claim_source_cd;
        private int clmhdr_doc_nbr_ohip;
        private int clmhdr_doc_spec_cd;
        private int clmhdr_refer_doc_nbr;
        //private int clmhdr_diag_cd;
        //private string clmhdr_loc;
        private string clmhdr_hosp;
        private string clmhdr_payroll;
        //private int clmhdr_agent_cd;
        private string clmhdr_adj_cd;
        //private string clmhdr_tape_submit_ind;
        //private string clmhdr_i_o_pat_ind;
        private string clmhdr_pat_ohip_id_or_chart_grp;
        private string clmhdr_pat_key_type;
        private string clmhdr_pat_key_data_grp;
        private string clmhdr_pat_key_ohip;
        //private string filler;
        private string clmhdr_pat_acronym_grp;
        //private string clmhdr_pat_acronym6;
        private string clmhdr_pat_acronym3;
        //private string clmhdr_reference_grp;
        private string clmhdr_ref1;
        private string clmhdr_ref2;
        private string clmhdr_ref3;
        private string clmhdr_ref4;
        private string clmhdr_ref5;
        private string clmhdr_ref6;
        private string clmhdr_ref7;
        private string clmhdr_ref8;
        private string clmhdr_ref9;
        private string clmhdr_ref10;
        private string clmhdr_ref11;
        private string clmhdr_reference_r_grp;
        private string clmhdr_ref_date1_grp;
        private int clmhdr_ref_date_yy;
        private int clmhdr_ref_date_mm;
        private int clmhdr_ref_date_dd;
        private string clmhdr_ref_inits;
        private string clmhdr_reference_r1_grp;
        //private string filler;
        private string clmhdr_ref_date2;
        //private string filler;
        private string clmhdr_reference_r2_grp;
        //private string filler;
        private string clmhdr_ref_date3;
        //private string filler;
        private string clmhdr_reference_r3_grp;
        //private string filler;
        private string clmhdr_ref_date4;
        private string clmhdr_date_admit_grp;
        //private string clmhdr_date_admit_yy;
        private string clmhdr_date_admit_yy_r_grp;
        private string clmhdr_date_admit_yy_12;
        private string clmhdr_date_admit_yy_34;
        //private int clmhdr_date_admit_mm;
        private string clmhdr_date_admit_mm_r;
        //private int clmhdr_date_admit_dd;
        private string clmhdr_date_admit_dd_r;
        private int clmhdr_date_admit_r;
        private string clmhdr_date_admit_r2_grp;
        private int clmhdr_date_admit_12;
        private int clmhdr_date_admit_38;
        private int clmhdr_doc_dept;
        //private string clmhdr_date_cash_tape_payment;
        private string clmhdr_date_cash_tape_paymt_r_grp;
        private int clmhdr_date_cash_tape_paymt_12;
        private int clmhdr_date_cash_tape_paymt_38;
        private string clmhdr_direct_bills_clm_info_grp;
        private string clmhdr_msg_nbr;
        private string clmhdr_reprint_flag;
        private string clmhdr_sub_nbr;
        private string clmhdr_auto_logout;
        private string clmhdr_fee_complex;
        //private string filler;
        private decimal clmhdr_curr_payment;
        private string clmhdr_date_period_end_grp;
        private int clmhdr_period_end_yy;
        private int clmhdr_period_end_mm;
        private int clmhdr_period_end_dd;
        private int clmhdr_cycle_nbr;
        private string clmhdr_date_sys;
        private string clmhdr_date_sys_r_grp;
        private int clmhdr_date_sys_12;
        private int clmhdr_date_sys_38;
        private decimal clmhdr_amt_tech_billed;
        private decimal clmhdr_amt_tech_paid;
        private decimal clmhdr_tot_claim_ar_oma;
        //private decimal clmhdr_tot_claim_ar_ohip;
        //private decimal clmhdr_manual_and_tape_paymnts;
        //private string clmhdr_status_ohip;
        private string clmhdr_manual_review;
        private string clmhdr_submit_date_grp;
        private int clmhdr_submit_yy;
        private int clmhdr_submit_mm;
        private int clmhdr_submit_dd;
        private string clmhdr_confidential_flag;
        private int clmhdr_serv_date;
        private string clmhdr_elig_error;
        private string clmhdr_elig_status;
        private string clmhdr_serv_error;
        private string clmhdr_serv_status;
        private string clmhdr_orig_batch_id_grp;
        private string clmhdr_orig_batch_nbr_grp;
        private int clmhdr_orig_batch_nbr_1_2;
        private string clmhdr_orig_batch_nbr_4_9;
        private string clmhdr_orig_batch_nbr_next_def_grp;
        //private int filler;
        private string clmhdr_orig_batch_nbr_4_6;
        private int clmhdr_orig_batch_nbr_7_8;
        private int clmhdr_orig_batch_nbr_9;
        private int clmhdr_orig_claim_nbr;
        private string clmhdr_orig_batch_id_r_grp;
        private string clmhdr_orig_complete_batch_nbr;
        private string k_clmhdr_claims_mstr_grp;
        private string k_clmhdr_b_key_type;
        private string k_clmhdr_b_data_grp;
        private string k_clmhdr_b_batch_num;
        private string k_clmhdr_b_batch_nbr_grp;
        private int k_clmhdr_b_clinic_nbr_1_2;
        private string k_clmhdr_b_doc_nbr;
        private string k_clmhdr_b_doc_nbr_r_grp;
        private string k_clmhdr_b_doc_nbr_2_4;
        private string k_clmhdr_b_batch_number_grp;
        private int k_clmhdr_b_week;
        private int k_clmhdr_b_day;
        private int k_clmhdr_b_claim_nbr;
        private string k_clmhdr_b_oma_cd;
        private string k_clmhdr_b_oma_suff;
        private string k_clmhdr_b_adj_nbr;
        private string k_clmhdr_b_data_r_grp;
        private string k_clmhdr_b_pat_id;
        //private string filler;
        private string k_clmhdr_p_claims_mstr_grp;
        private string k_clmhdr_p_key_type;
        private string k_clmhdr_p_data_grp;
        private string k_clmhdr_p_batch_nbr_grp;
        private int k_clmhdr_p_clinic_nbr_1_2;
        private string k_clmhdr_p_doc_nbr;
        private int k_clmhdr_p_week;
        private int k_clmhdr_p_day;
        private int k_clmhdr_p_claim_nbr;
        private string k_clmhdr_p_oma_cd;
        private string k_clmhdr_p_oma_suff;
        private string k_clmhdr_p_adj_nbr;

        private string clmhdr_b_key_type;
        private string clmhdr_b_data_grp;
        private string clmhdr_b_batch_num;
        private string clmhdr_b_batch_nbr_grp;
        private int clmhdr_b_clinic_nbr_1_2;
        private string clmhdr_b_doc_nbr;
        private string clmhdr_b_doc_nbr_r_grp;
        private string clmhdr_b_doc_nbr_2_4;
        private string clmhdr_b_batch_number_grp;
        private int clmhdr_b_week;
        private int clmhdr_b_day;
        private int clmhdr_b_claim_nbr;
        private string clmhdr_b_oma_cd;
        private string clmhdr_b_oma_suff;
        private string clmhdr_b_adj_nbr;
        private string clmhdr_b_data_r_grp;
        private string clmhdr_b_pat_id;
        //private string filler;
        private string clmhdr_p_claims_mstr_grp;
        private string clmhdr_p_key_type;
        private string clmhdr_p_data_grp;
        private string clmhdr_p_batch_nbr_grp;
        private int clmhdr_p_clinic_nbr_1_2;
        private string clmhdr_p_doc_nbr;
        private int clmhdr_p_week;
        private int clmhdr_p_day;
        private int clmhdr_p_claim_nbr;
        private string clmhdr_p_oma_cd;
        private string clmhdr_p_oma_suff;
        private string clmhdr_p_adj_nbr;

        private string claim_detail_rec_grp;
        private string clmdtl_id_grp;
        private string clmdtl_batch_nbr;
        private int clmdtl_claim_nbr;
        private string clmdtl_oma_cd;        
        private string clmdtl_oma_suff;
        private int clmdtl_adj_nbr;
        private string clmdtl_det_rec_grp;
        private string clmdtl_rev_group_cd;
        private int clmdtl_agent_cd;
        private string clmdtl_adj_cd;
        private int clmdtl_nbr_serv;
        private string clmdtl_nbr_serv_r_grp;
        private string clmdtl_adjust_reprint;
        //private string filler;
        private string clmdtl_sv_date_grp;
        private int clmdtl_sv_yy;
        private int clmdtl_sv_mm;
        private int clmdtl_sv_dd;
        private string clmdtl_consec_dates_grp;
        private int[] clmdtl_consecutive_sv_date = new int[4];
        private string clmdtl_consec_dates_r_grp;
        private string[] clmdtl_consecutive_dates = new string[4];
        private int[] clmdtl_sv_nbr = new int[4];
        private string[] clmdtl_sv_day = new string[4];
        private decimal clmdtl_amt_tech_billed;
        private decimal clmdtl_fee_oma;
        private decimal clmdtl_fee_ohip;
        private string clmdtl_date_period_end;
        private int clmdtl_cycle_nbr;
        private int clmdtl_diag_cd;
        private int clmdtl_line_no;
        private string clmdtl_resubmit_flag;
        private string clmdtl_reserve_for_future;
        private string clmdtl_desc_rec_grp;
        private string clmdtl_desc;
        //private string filler;
        private string clmdtl_filler;
        private string clmdtl_orig_batch_id_grp;
        private string clmdtl_orig_batch_nbr;
        private string clmdtl_orig_batch_nbr_r_grp;
        private int clmdtl_orig_batch_nbr_1_2;
        private string clmdtl_orig_batch_nbr_4_9;
        private int clmdtl_orig_claim_nbr_in_batch;
        private string clmdtl_orig_batch_id_r_grp;
        private int clmdtl_orig_complete_batch_nbr;
        private string clmdtl_orig_complete_batch_n_r_grp;
        private int clmdtl_orig_clinic_number;
        private string clmdtl_orig_doc_number;
        private int clmdtl_orig_batch_number;
        private int clmdtl_orig_claim_number;
        private string k_clmdtl_claims_mstr_grp;
        private string k_clmdtl_b_key_type;
        private string k_clmdtl_b_data_grp;
        private string k_clmdtl_b_batch_num;
        private string k_clmdtl_b_batch_nbr_grp;
        private int k_clmdtl_b_clinic_nbr_1_2;
        private string k_clmdtl_b_doc_nbr;
        private string k_clmdtl_b_doc_nbr_r_grp;
        private string k_clmdtl_b_doc_nbr_2_4;
        private string k_clmdtl_b_batch_number_grp;
        private int k_clmdtl_b_week;
        private int k_clmdtl_b_day;
        private int k_clmdtl_b_claim_nbr;
        private string k_clmdtl_b_oma_cd;
        private string k_clmdtl_b_oma_suff;
        private string k_clmdtl_b_adj_nbr;
        private string k_clmdtl_b_data_r_grp;
        private string k_clmdtl_b_pat_id;
        //private string filler;
        private string k_clmdtl_p_claims_mstr_grp;
        private string k_clmdtl_p_key_type;
        private string k_clmdtl_p_data_grp;
        private string k_clmdtl_p_batch_nbr_grp;
        private int k_clmdtl_p_clinic_nbr_1_2;
        private string k_clmdtl_p_doc_nbr;
        private int k_clmdtl_p_week;
        private int k_clmdtl_p_day;
        private int k_clmdtl_p_claim_nbr;
        private string k_clmdtl_p_oma_cd;
        private string k_clmdtl_p_oma_suff;
        private string k_clmdtl_p_adj_nbr;

        private string hosp_table_grp;
        private string hosp_values_grp;
        private string[] hosp_code_nbr = {"", "A1992",
                                         "B1160",
                                         "C1972",
                                         "D1557",
                                         "E1146",
                                         "F3361",
                                         "G1982",
                                         "H1983",
                                         "I3309",
                                         "J2003",
                                         "K1076",
                                         "L1538",
                                         "M1994",
                                         "N1591",
                                         "O1172",
                                         "P1524",
                                         "Q3446",
                                         "R1978",
                                         "S2006",
                                         "T1406",
                                         "U1542",
                                         "V1149",
                                         "W0000",
                                         "X1082",
                                         "Y1020",
                                         "Z1987",
                                         "11965",
                                         "21969",
                                         "33401",
                                         "42001",
                                         "51966",
                                         "61967",
                                         "73409",
                                         "83642",
                                        "93251"};
        private string hosp_values_r_grp;
        private string[] hosp_code = {"", "A",
                                         "B",
                                         "C",
                                         "D",
                                         "E",
                                         "F",
                                         "G",
                                         "H",
                                         "I",
                                         "J",
                                         "K",
                                         "L",
                                         "M",
                                         "N",
                                         "O",
                                         "P",
                                         "Q",
                                         "R",
                                         "S",
                                         "T",
                                         "U",
                                         "V",
                                         "W",
                                         "X",
                                         "Y",
                                         "Z",
                                         "1",
                                         "2",
                                         "3",
                                         "4",
                                         "5",
                                         "6",
                                         "7",
                                         "8",
                                        "9"};

        private string[] hosp_nbr = {"", "1992",
                                         "1160",
                                         "1972",
                                         "1557",
                                         "1146",
                                         "3361",
                                         "1982",
                                         "1983",
                                         "3309",
                                         "2003",
                                         "1076",
                                         "1538",
                                         "1994",
                                         "1591",
                                         "1172",
                                         "1524",
                                         "3446",
                                         "1978",
                                         "2006",
                                         "1406",
                                         "1542",
                                         "1149",
                                         "0000",
                                         "1082",
                                         "1020",
                                         "1987",
                                         "1965",
                                         "1969",
                                         "3401",
                                         "2001",
                                         "1966",
                                         "1967",
                                         "3409",
                                         "3642",
                                        "3251"};
        private string endOfJob = "End of Job";


        private string clmrec_dtl_oma_cd;
        private int clmrec_dtl_agent_cd;
        private string clmrec_dtl_adj_cd;
        private int clmrec_dtl_nbr_serv;
        private string clmrec_dtl_sv_date;
        private string[] clmrec_dtl_consec_dates = new string[4];
        private int[] clmrec_dtl_sv_nbr = new int[4];
        private decimal clmrec_dtl_amt_tech_billed;
        private decimal clmrec_dtl_fee_oma;
        private decimal clmrec_dtl_fee_ohip;
        private string key_claims_mstr;
        private string clmdtl_b_key_type;
        private string clmdtl_b_data;
        private string clmdtl_b_batch_num;
        private string clmdtl_b_batch_nbr;
        private int clmdtl_b_clinic_nbr_1_2;
        private string clmdtl_b_doc_nbr;
        private string clmdtl_b_doc_nbr_r;
        private string clmdtl_b_doc_nbr_2_4;
        private string clmdtl_b_batch_number;
        private int clmdtl_b_week;
        private int clmdtl_b_day;
        private int clmdtl_b_batch_number_numeric;
        private int clmdtl_b_claim_nbr;
        private string clmdtl_b_oma_cd;
        private string clmdtl_b_oma_suff;
        private string clmdtl_b_adj_nbr;
        private string clmdtl_b_data_r;
        private string clmdtl_b_pat_id;
        private string clmdtl_p_claims_mstr;
        private string clmdtl_p_key_type;
        private string clmdtl_p_data;
        private string clmdtl_p_batch_nbr;
        private int clmdtl_p_clinic_nbr_1_2;
        private string clmdtl_p_doc_nbr;
        private int clmdtl_p_week;
        private int clmdtl_p_day;
        private int clmdtl_p_claim_nbr;
        private string clmdtl_p_oma_cd;
        private string clmdtl_p_oma_suff;
        private string clmdtl_p_adj_nbr;

        // Pat_id_rec
        private int pat_last_birth_date;
        private string pat_last_version_cd;
        private string pat_old_surname;
        private string pat_old_given_name;
        private int pat_old_health_nbr;
        private string pat_old_chart_nbr;
        private string pat_old_chart_nbr_2;
        private string pat_old_chart_nbr_3;
        private string pat_old_chart_nbr_4;
        private string pat_old_chart_nbr_5;
        private string pat_old_addr1;
        private string pat_old_addr2;
        private string pat_old_addr3;

        private string msg_sub_key;
        private string msg_sub_key_1;
        private string msg_sub_key_23;
        private string msg_sub_key_2;
        private string msg_sub_key_3;
        private string msg_rec;
        private string msg_reprint_flag;
        private string msg_auto_logout;
        private string msg_dtl1;
        private string msg_dtl2;
        private string msg_dtl3;
        private string msg_dtl4;
        private string sub_rec;
        private string sub_name;
        private string sub_fee_complex;
        private string sub_auto_logout;

        private string pat_acronym_grp;
        private string pat_acronym_first6;
        private string pat_acronym_last3;
        //private string pat_ohip_mmyy;
        private string pat_ohip_out_prov_grp;
        private int pat_ohip_nbr;
        private int pat_mm;
        private int pat_yy;
        private string Filler;
        //private string pat_ohip_mmyy_r;
        private string pat_direct_alpha_grp;
        private string pat_alpha1;
        private string pat_alpha2_3;
        private string pat_direct_yy;
        private string pat_direct_mm;
        private string pat_direct_dd;
        private string pat_direct_filler;
        //private string pat_chart_nbr_grp;
        private string pat_chart_1st_char;
        private string pat_chart_remainder;
        private string pat_chart_nbr_2_grp;
        private string pat_chart_1st_char_2;
        private string pat_chart_remainder_2;        
        private string pat_chart_nbr_3_grp;
        private string pat_chart_1st_char_3;
        private string pat_chart_remainder_3;        
        private string pat_chart_nbr_4_grp;
        private string pat_chart_1st_char_4;
        private string pat_chart_remainder_4;
        private string pat_chart_nbr_5_grp;
        private string pat_chart_1st_char_5;
        private string pat_chart_remainder_5;
        private string pat_full_name;
        //private string pat_surname;
        private string pat_surname_r_grp;
        private string pat_surname_first6;
        private string pat_surname_last19;
        private string pat_surname_rr_grp;
        private string pat_surname_first3;
        private string pat_surname_last22;
        //private string pat_given_name;
        private string pat_given_name_r_grp;
        private string pat_given_name_first3;
        private string pat_given_name_last14;
        private string pat_given_name_rr_grp;
        private string pat_given_name_first1;
        private string pat_init_grp;
        private string pat_init1;
        private string pat_init2;
        private string pat_init3;
        private string pat_location_field_grp;
        private string pat_location_field_1_3;
        private string pat_last_doc_nbr_seen;
        private int pat_birth_date;
        private string pat_birth_date_r_grp;
        private int pat_birth_date_yy;
        private int pat_birth_date_mm;
        private int pat_birth_date_dd;
        private int pat_date_last_maint;
        private string pat_date_last_maint_r_grp;
        private int pat_date_last_maint_yy;
        private int pat_date_last_maint_mm;
        private int pat_date_last_maint_dd;
        private int pat_date_last_visit;
        private string pat_date_last_visit_r_grp;
        private int pat_date_last_visit_yy;
        private int pat_date_last_visit_mm;
        private int pat_date_last_visit_dd;
        private int pat_date_last_admit;
        private string pat_date_last_admit_r_grp;
        private int pat_date_last_admit_yy;
        private int pat_date_last_admit_mm;
        private int pat_date_last_admit_dd;
        private string pat_phone_nbr_grp;
        private int pat_phone_nbr_first3;
        private int pat_phone_nbr_last4;
        private string pat_phone_nbr_remainder;
        private int pat_total_nbr_visits;
        private int pat_total_nbr_claims;
        private string pat_sex;
        private string pat_in_out;
        private int pat_nbr_outstanding_claims;
        private string key_pat_mstr_grp;
        private string pat_i_key;
        private int pat_con_nbr;
        private int pat_i_nbr;
        //private int pat_health_nbr;
        private string pat_version_cd_grp;
        private string pat_version_cd_1;
        private string pat_version_cd_2;
        private string pat_health_65_ind;
        private string pat_expiry_date_grp;
        private int pat_expiry_yy;
        private int pat_expiry_mm;
        private string pat_prov_cd;
        private string subscr_addr1;
        private string subscr_addr2;
        private string subscr_addr3;
        private string subscr_prov_cd;
        private string subscr_postal_cd;
        private string subscr_postal_cd_r_grp;
        private string subscr_post_code1_grp;
        private string subscr_post_cd1;
        private string subscr_post_cd2;
        private string subscr_post_cd3;
        private string subscr_post_code2_grp;
        private string subscr_post_cd4;
        private string subscr_post_cd5;
        private string subscr_post_cd6;
        private string subscr_msg_data;
        private string subscr_msg_nbr;
        private int subscr_date_msg_nbr_eff_to;
        private string subscr_date_msg_nbr_eff_to_r;
        private int subscr_date_msg_nbr_eff_to_yy;
        private int subscr_date_msg_nbr_eff_to_mm;
        private int subscr_date_msg_nbr_eff_to_dd;
        private string subscr_date_msg_nbr_eff_to_r1;
        private int subscr_date_last_statement;
        private string subscr_date_last_statement_r_grp;
        private int subscr_date_last_statement_yy;
        private int subscr_date_last_statement_mm;
        private int subscr_date_last_statement_dd;
        private string subscr_auto_update;
        private string pat_last_mod_by;
        private int pat_date_last_elig_mailing;
        private int pat_date_last_elig_maint;
        //private int pat_last_birth_date ;        
        //private string pat_last_version_cd ;        
        private string pat_mess_code;
        private string pat_country;
        private int pat_no_of_letter_sent;
        private string pat_dialysis;
        private string pat_ohip_validiation_status;
        private string pat_obec_status;

        private int claims_mstr_detail_ctr = 0;
        private int claims_details_ctr = 0;
        private int ctr_read_claimss_hdr = 0;

        private string mstr_desc_clmdtl_oma_cd;
        private string mstr_desc_dtl_desc;

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 1,Data1 = "D002",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 33,Data1 = "- CLAIM DELETE -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 74,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 77,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 78,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-claim-id.",Line = "03",Col = 1,Data1 = "CLAIM #-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-claim-id.",Line = "03",Col = 9,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(10)",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acpt_claim_id",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-claim-id"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 23,Data1 = "PATIENT-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(15)",MaxLength = 15,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "pat_surname",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 48,Data1 = "FIRST-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 54,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(12)",MaxLength = 12,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "pat_given_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 68,Data1 = "INITS-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 74,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "pat_init",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 1,Data1 = "H/C NBR-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(10)",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "pat_health_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 23,Data1 = "ID-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(12)",MaxLength = 12,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_pat_id",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 43,Data1 = "CHART-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(10)",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "pat_chart_nbr_grp",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 67,Data1 = "DIAGNOSIS-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_diag_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 1,Data1 = "BATCH #",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_clinic_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 14,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_week",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_day",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 18,Data1 = "-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 19,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_claim_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 22,Data1 = "DOCTOR #-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 36,Data1 = "LOC -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_loc",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 48,Data1 = "HOSP",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_hosp_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 58,Data1 = "ADMIT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_date_admit_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 68,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_date_admit_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_date_admit_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 73,Data1 = "AGENT-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "07",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_agent_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 1,Data1 = "TAPE SUB",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_tape_submit_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 14,Data1 = "IN/OUT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_i_o_pat_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 25,Data1 = "REF -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 29,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(9)",MaxLength = 9,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_reference",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "update-ref"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 42,Data1 = "REASON-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_status_ohip",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 57,Data1 = "CASH/DATE-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "09",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxxxxxxxx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_date_cash_tape_payment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "10",Col = 21,Data1 = "--------------------------------------------------------------------------------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "11",Col = 2,Data1 = "BATCH        CYC     PERIOD       SERVICE       OMA   #S  AG C",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "11",Col = 55,Data1 = "AMOUNT     DESCRIPTION RECORDS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "12",Col = 1,Data1 = "NUMBER         #     END DATE        DATE       CODE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "12",Col = 49,Data1 = " C       DUE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-1.",Line = "13",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-2.",Line = "14",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-3.",Line = "15",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-4.",Line = "16",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-5.",Line = "17",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-6.",Line = "18",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-7.",Line = "19",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_id_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_clm_nbr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_cyc_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_per_end_date_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_svc_date_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_cd_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_oma_suff_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_svc_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_agent_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_adj_cd_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_clm_card_col_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-clmdet-8.",Line = "20",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clm_amt_due_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "13",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "14",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "15",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "16",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "17",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "18",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "19",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clr-dtls.",Line = "20",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-desc.",Line = "13",Col = 63,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(21)",MaxLength = 21,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dis-desc-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-desc.",Line = "14",Col = 63,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(21)",MaxLength = 21,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dis-desc-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-desc.",Line = "15",Col = 63,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(21)",MaxLength = 21,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dis-desc-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-desc.",Line = "16",Col = 63,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(21)",MaxLength = 21,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dis-desc-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-desc.",Line = "17",Col = 63,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(21)",MaxLength = 21,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dis-desc-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-footing.",Line = "21",Col = 1,Data1 = "ORIGINAL BALANCE-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-footing.",Line = "21",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_tot_claim_ar_ohip",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-footing.",Line = "21",Col = 31,Data1 = "AMOUNT PAID-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-footing.",Line = "21",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_manual_and_tape_paymnts",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-footing.",Line = "21",Col = 58,Data1 = "BALANCE DUE-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-footing.",Line = "21",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hold_clmhdr_bal",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-continue.",Line = "24",Col = 30,Data1 = "CORRECT CLAIM? (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-continue.",Line = "24",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-id-chart.",Line = "11",Col = 18,Data1 = "OHIP-ID/CHART:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-id-chart.",Line = "11",Col = 36,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xxx9(9)",MaxLength = 9,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "pat_ohip_mmyy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clmhdr-ohip-chart"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-patient-verif.",Line = "11",Col = 53,Data1 = "CREATE NEW PATIENT (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-patient-verif.",Line = "11",Col = 78,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "reply_create_pat",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clmhdr-pat-verif"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-pat-surname.",Line = "11",Col = 53,Data1 = "PATIENT SURNAME:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-pat-surname.",Line = "11",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(6)",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_pat_acronym6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clmhdr-pat-surname"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clear-pat-verif.",Line = "11",Col = 53,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-delete-claim.",Line = "22",Col = 25,Data1 = "DELETE CLAIM AND ALL DETAILS (Y/N)??",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-delete-claim.",Line = "22",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_clmhdr_delete",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-re-try-del-batch.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-re-try-del-batch.",Line = "24",Col = 30,Data1 = "TRY TO DELETE BATCH AGAIN (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-re-try-del-batch.",Line = "24",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-acpt-re-try-del-batch-flag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-22.",Line = "22",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "05",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_diag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-diag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "15",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_cd_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-cd-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "16",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_cd_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-cd-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "17",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_cd_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-cd-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "18",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_cd_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-cd-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "19",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_cd_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-cd-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "20",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_cd_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-cd-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "21",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_msg_star",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-msg-star"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-error-mask.",Line = "21",Col = 3,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(50)",MaxLength = 50,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_err_oma_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-err-oma-msg"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "22",Col = 1,Data1 = "DESC #1:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "22",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(22)",MaxLength = 22,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hold-desc-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "22",Col = 31,Data1 = "#2:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "22",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(22)",MaxLength = 22,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hold-desc-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "22",Col = 56,Data1 = "#3:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "22",Col = 59,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(22)",MaxLength = 22,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hold-desc-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "23",Col = 1,Data1 = "DESC #4:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "23",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(22)",MaxLength = 22,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hold-desc-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "23",Col = 31,Data1 = "#5:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-det-desc.",Line = "23",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(22)",MaxLength = 22,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "hold_desc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hold-desc-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-column-titles.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-column-titles.",Line = "12",Col = 8,Data1 = "* PATIENT DATA *",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-disp-pat-title"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-column-titles.",Line = "02",Col = 49,Data1 = "* SUBSCRIBER DATA *",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-ident-chart.",Line = "04",Col = 1,Data1 = "IDENT/CHART     -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-ident-chart.",Line = "04",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(12)",MaxLength = 12,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "pat_ohip_mmyy_r",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-acpt-ohip-mmyy"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 2,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(75)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verification-screen.",Line = "24",Col = 30,Data1 = "CORRECT PATIENT? (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verification-screen.",Line = "24",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(42)",MaxLength = 42,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_file_err_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_disp_pat_key_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_common",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "exit",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen.",Line = "24",Col = 58,Data1 = "ACCEPT (Y/N/M) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen.",Line = "24",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 59,Data1 = "REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 20,Data1 = "# OF BATCH CONTROL READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_batctrl_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "6",Col = 20,Data1 = "# OF CLAIMS MASTER READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "6",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_claims_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "# OF PATIENT MSTR  READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_pat_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "# OF BATCH CONTROL WRITES =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_writ_batctrl_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 20,Data1 = "# OF CLAIMS MASTER WRITES =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_writ_claims_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM D002 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_claims_mstr_file_section()
        {

            //     use after standard error procedure on claims-mstr.;
        }

        private async Task err_claims_mstr()
        {

            status_common = status_cobol_claims_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
        }

        private async Task err_batctrl_mstr_file_section()
        {

            //     use after standard error procedure on batch-ctrl-file.;
        }

        private async Task err_batctrl_file()
        {

            //     if status-batctrl-file = '7012';
            //     then;
            flag_del = "Y";
            //     else;
            status_common = status_cobol_batctrl_file;
            // 	display file-status-display;
            // 	stop "ERROR IN ACCESSING BATCH CONTROL FILE".;
        }

        private async Task err_pat_mstr_file_section()
        {

            //     use after standard error procedure on pat-mstr.;
        }

        private async Task err_pat_mstr()
        {

            status_common = status_cobol_pat_mstr;
            //     display file-status-display.;
            //     stop " ".;
            ws_file_err_msg = "";
            ws_disp_pat_key_type = "";
            //   ws-disp-pat-key-type.;
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {

        }

        private async Task initialize_objects()
        {
            objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
            Batctrl_rec_Collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

            objClaims_mstr_dtl_rec = new F002_CLAIMS_MSTR_DTL();
            Claims_mstr_dtl_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            objPat_mstr_rec = new F010_PAT_MSTR();
            Pat_mstr_rec_Collection = new ObservableCollection<F010_PAT_MSTR>();

            objF002_CLAIMS_MSTR_DTL_DESC = new F002_CLAIMS_MSTR_DTL_DESC();
            F002_CLAIMS_MSTR_DTL_DESC_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>();
    }

        public async void mainline()
        {
            await Exit_Trakker();
            try
            {
                await initialize_objects();

                //  perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit;
                // 	until end-job = "Y".;

                do
                {
                    await ab0_processing();
                    await ab0_10_acpt_claim_id();
                    await ab0_90_clr_dtls();
                    await ab0_99_exit();
                } while (!end_job.ToUpper().Equals("Y"));

                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_10_end_of_job();

                //     stop run.;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                    Display("err-msg-line.");
                    Write_ErrorLog("D002", e.Message, e.StackTrace);
                }
            }
            finally
            {

            }
        }

        private async Task aa0_initialization()
        {
            await Exit_Trakker();

            //     accept sys-date			from date.;
            sys_date_grp = Sysdate();
            sys_date_long_child = sys_date_grp.Substring(0, 4) + sys_date_grp.Substring(4, 2) + sys_date_grp.Substring(6, 2);
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = Util.NumInt(sys_date_grp.Substring(0, 4));
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(sys_date_grp.Substring(0, 1));
            sys_y2 = Util.NumInt(sys_date_grp.Substring(1, 1));
            sys_y3 = Util.NumInt(sys_date_grp.Substring(2, 1));
            sys_y4 = Util.NumInt(sys_date_grp.Substring(3, 1));
            sys_mm = Util.NumInt(sys_date_grp.Substring(4, 2));
            sys_dd = Util.NumInt(sys_date_grp.Substring(6, 2));

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;
            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     display scr-title-claim-rec-data.;
            Display("scr-title-claim-rec-data.");            

            //     open i-o    claims-mstr;
            // 		batch-ctrl-file;
            // 		pat-mstr.;

            //counters = 0;
            ctr_read_batctrl_mstr = 0;
            ctr_read_claims_mstr = 0;
            ctr_read_claims_mstr_dtl = 0;
            ctr_read_pat_mstr = 0;
            ctr_writ_batctrl_file = 0;
            ctr_writ_claims_mstr = 0;
            ctr_rewrit_batctrl_mstr = 0;
            ctr_rewrit_claims_mstr = 0;


            //objBatctrl_rec.batctrl_rec = "";
            //ws_val_err_msg_mask = "";
            ws_val_err_msg_mask_grp = "";
            ws_err_diag = "";
            ws_err_oma_cd_1 = "";
            ws_err_oma_cd_2 = "";
            ws_err_oma_cd_3 = "";
            ws_err_oma_cd_4 = "";
            ws_err_oma_cd_5 = "";
            ws_err_oma_cd_6 = "";
            ws_err_oma_msg_star = "";
            ws_err_oma_msg = "";

            //claim_header_rec = "";
            //claim_detail_rec = "";       
            await Initialize_ClmHdr_Record_ScreenVariables();
            await Initialize_Clmdtl_Record_ScreenVariables();
        }

        private async Task aa0_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task<string> aa3_disp_claim()
        {
            await Exit_Trakker();
            //  perform xc0-read-claims-mstr	thru	xc0-99-exit.;
            await xc0_read_claims_mstr();
            await xc0_99_exit();


            //  if not-ok then           
            if (Util.Str(flag).Equals(not_ok))
            {
                err_ind = 4;
                //  perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                ws_clmhdr_delete = "N";
                // 	   go to aa3-99-exit.;                
                return "aa3_99_exit";
            }

            // if pat-count > -1 then            
            if (pat_count > -1)
            {
                // 	   if key-pat-mstr = clmhdr-pat-ohip-id-or-chart then        

                if ((objPat_mstr_rec.PAT_I_KEY + objPat_mstr_rec.PAT_CON_NBR + objPat_mstr_rec.PAT_I_NBR + new string(' ', 1)) == (objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_TYPE + objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_DATA))
                {
                    // 	       next sentence;
                }
                else
                {
                    err_ind = 46;
                    // 	       perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	       go to aa3-99-exit.;                    
                    return "aa3_99_exit";
                }
            }

            //key_pat_mstr = clmhdr_pat_ohip_id_or_chart;
            clmhdr_pat_ohip_id_or_chart_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_TYPE) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_DATA) + new string(' ', 7);
            objPat_mstr_rec.PAT_I_KEY = clmhdr_pat_ohip_id_or_chart_grp.PadRight(16).Substring(0, 1);
            objPat_mstr_rec.PAT_CON_NBR = Util.NumDec(clmhdr_pat_ohip_id_or_chart_grp.PadRight(16).Substring(1, 2));
            objPat_mstr_rec.PAT_I_NBR = Util.NumDec(clmhdr_pat_ohip_id_or_chart_grp.PadRight(16).Substring(3, 12));

            //     perform ka0-access-patient		thru	ka0-99-exit.;
            await ka0_access_patient();
            await ka0_99_exit();

            //  if clmhdr-hosp not = spaces then     
            if (!string.IsNullOrWhiteSpace(clmhdr_hosp))
            {
                // 	    perform xf0-move-hosp-nbr	thru xf0-99-exit;                
                await xf0_move_hosp_nbr();
                await xf0_10_hosp_loop();
                await xf0_99_exit();

            }
            else
            {
                ws_hosp_nbr = "";
            }

            //  if pat-ohip-mmyy-r not = spaces then         
            pat_ohip_mmyy_r = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadLeft(4,'0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadLeft(2,'0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadLeft(2,'0');
            if (!string.IsNullOrWhiteSpace(pat_ohip_mmyy_r) && Util.NumInt(pat_ohip_mmyy_r) != 0)
            {
                //     ws_pat_id = objPat_mstr_rec.pat_ohip_mmyy_r;
                ws_pat_id = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadLeft(4,'0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadLeft(2,'0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadLeft(2,'0') + new string(' ', 6);
            }
            else
            {
                ws_pat_id = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
            }

            //     display scr-acpt-clmhdr.;
            Display("scr-acpt-clmhdr.");
            //await Prompt("pat_surname");

            //  add clmhdr-tot-claim-ar-ohip , clmhdr-manual-and-tape-paymnts;
            // 					giving hold-clmhdr-bal.;
            hold_clmhdr_bal = clmhdr_tot_claim_ar_ohip + clmhdr_manual_and_tape_paymnts;

            //   perform xd0-read-all-clmdtl		thru	xd0-99-exit.;
            await xd0_read_all_clmdtl();
            await xd0_10_read_index_rec();
            await xd0_99_exit();


            //  if ss-clmdtl > 0 then            
            // 	   display scr-dis-clmdet-1;
            // 	     if ss-clmdtl > 1 then
            // 	         display scr-dis-clmdet-2;
            // 	            if ss-clmdtl > 2 then            
            // 		           display scr-dis-clmdet-3;
            // 		             if ss-clmdtl > 3 then            
            // 		                display scr-dis-clmdet-4;
            // 		                   if ss-clmdtl > 4 then            
            // 			                  display scr-dis-clmdet-5;
            // 			                     if ss-clmdtl > 5 then            
            // 			                        display scr-dis-clmdet-6;
            // 			                          if ss-clmdtl > 6 then                        
            // 				                         display scr-dis-clmdet-7;
            // 				                            if ss-clmdtl > 7 then                                                              
            // 				                               display scr-dis-clmdet-8;                                                        
            // 				                                next sentence;                                                        
            // 			                          else;
            // 				                         next sentence;
            // 			                    else;
            // 			                       next sentence;
            // 		                  else;
            // 			                  next sentence;
            // 		          else;
            // 		              next sentence;
            // 	         else;
            // 		         next sentence;
            // 	      else;
            // 	          next sentence;
            //    else;
            //      	next sentence.;

            for (int i = 1; i <= ss_clmdtl; i++)
            {
                await display_scr_dis_clmdet(i);
                await display_scr_dis_desc(i);
            }

            /* if (ss_clmdtl > 0)
             {
                 // 	   display scr-dis-clmdet-1;
                 Display("scr-dis-clmdet-1.");
                 await display_scr_dis_clmdet(i);
                 if (ss_clmdtl > 1)
                 {
                     // 	         display scr-dis-clmdet-2;
                     Display("scr-dis-clmdet-2.");
                     await display_scr_dis_clmdet(ss_clmdtl);
                     if (ss_clmdtl > 2)
                     {
                         // 		           display scr-dis-clmdet-3;
                         Display("scr-dis-clmdet-3.");
                         await display_scr_dis_clmdet(ss_clmdtl);
                         if (ss_clmdtl > 3)
                         {
                             // 		                display scr-dis-clmdet-4;
                             Display("scr-dis-clmdet-4.");
                             await display_scr_dis_clmdet(ss_clmdtl);
                             if (ss_clmdtl > 4)
                             {
                                 // 			                  display scr-dis-clmdet-5;
                                 Display("scr-dis-clmdet-5.");
                                 await display_scr_dis_clmdet(ss_clmdtl);
                                 if (ss_clmdtl > 5)
                                 {
                                     // 			                        display scr-dis-clmdet-6;
                                     Display("scr-dis-clmdet-6.");
                                     await display_scr_dis_clmdet(ss_clmdtl);
                                     if (ss_clmdtl > 6)
                                     {
                                         // 				                         display scr-dis-clmdet-7;
                                         Display("scr-dis-clmdet-7.");
                                         await display_scr_dis_clmdet(ss_clmdtl);
                                         if (ss_clmdtl > 7)
                                         {
                                             // 				                               display scr-dis-clmdet-8;
                                             Display("scr-dis-clmdet-8.");
                                             await display_scr_dis_clmdet(ss_clmdtl);
                                         }
                                         else
                                         {
                                             // 				                                next sentence;
                                         }
                                     }
                                     else
                                     {

                                     }
                                 }
                                 else
                                 {

                                 }
                             }
                             else
                             {

                             }
                         }
                         else
                         {

                         }

                     }
                     else
                     {

                     }
                 }
                 else
                 {

                 }
             }
             else
             {

             } */



            //     display scr-dis-desc.;       
            for (int i = 1; i <= ss_clmdtl_desc; i++) {
                await display_scr_dis_desc(i);
            }
            //     display scr-dis-footing.;
            Display("scr-dis-footing.");           

            // if clmhdr-batch-type = "P" or "A" then            
            if (Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("P") || Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("A"))
            {
                err_ind = 5;
                // 	  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                flag_del_clm = "N";
                // 	  go to aa3-99-exit;                
                return "aa3_99_exit";
            }
            else
            {
                flag_del_clm = "Y";
            }

            return string.Empty;
        }

        private async Task aa3_90_reply()
        {
            await Exit_Trakker();

            ws_clmhdr_delete = "N";
            //     display scr-acpt-delete-claim.;
            Display("scr-acpt-delete-claim.");
            //     accept  scr-acpt-delete-claim.;
            await Prompt("ws_clmhdr_delete");

            //  if ws-clmhdr-delete = 'Y' or  'N' then            
            if (Util.Str(ws_clmhdr_delete).ToUpper().Equals("Y") || Util.Str(ws_clmhdr_delete).ToUpper().Equals("N"))
            {
                // 	    next sentence;
            }
            else
            {
                err_ind = 1;
                // 	   perform za0-common-error thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to aa3-90-reply.;
                await aa3_90_reply();
                return;
            }
        }

        private async Task aa3_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task az0_end_of_job()
        {
            await Exit_Trakker();

            // if ws-clmhdr-delete	= 'Y' and batctrl-last-claim-nbr	= zero and batctrl-nbr-claims-in-batch	= zero  then
            if (Util.Str(ws_clmhdr_delete).ToUpper().Equals("Y") && Util.NumInt(objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR) == 0 && Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH) == 0)
            {
                // 	perform ma41-del-phys-batch	thru ma41-99-exit.;
                await ma41_del_phys_batch();
                await ma41_99_exit();
            }
        }

        private async Task az0_10_end_of_job()
        {
            //     display blank-screen.;
            Display("blank-screen.");
            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");
            sys_hrs = Util.NumInt(DateTime.Now.ToString("HH"));
            sys_min = Util.NumInt(DateTime.Now.ToString("mm"));
            sys_sec = Util.NumInt(DateTime.Now.ToString("ss"));

            //     display scr-closing-screen.;
            Display("scr-closing-screen.");
            //     display confirm.;
            Display("scr-confirm");
            await Prompt("confirm_space");
            ExitCobol();

            //     stop " ".;

            //     close pat-mstr;
            // 	  batch-ctrl-file;
            // 	  claims-mstr.;
            //     call program "$obj/menu".;
            //     stop run.;
            //throw new Exception(endOfJob);
        }

        private async Task az0_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ab0_processing()
        {
            await Exit_Trakker();
            pat_count = -1;
        }

        private async Task ab0_10_acpt_claim_id()
        {
            await Exit_Trakker();

            //     display scr-acpt-claim-id.;
            Display("scr-acpt-claim-id.");
            //     accept scr-claim-id.;
            await Prompt("acpt_claim_id");

            acpt_claim_clinic_1 = Util.Str(acpt_claim_id).PadRight(10).Substring(0,1);
            acpt_claim_clinic = Util.NumInt(Util.Str(acpt_claim_id).PadRight(10).Substring(0, 2));
            acpt_claim_doc_nbr = Util.Str(acpt_claim_id).PadRight(10).Substring(2, 3);
            acpt_claim_week = Util.NumInt(Util.Str(acpt_claim_id).PadRight(10).Substring(5, 2));
            acpt_claim_day = Util.NumInt(Util.Str(acpt_claim_id).PadRight(10).Substring(7, 1));
            acpt_claim_claim_nbr = Util.NumInt(Util.Str(acpt_claim_id).PadRight(10).Substring(8, 2));

            // if acpt-claim-clinic-1 = "*" then            
            if (Util.Str(acpt_claim_clinic_1).Equals("*"))
            {
                end_job = "Y";
                // 	go to ab0-99-exit.;
                await ab0_99_exit();
                return;
            }

            clmdtl_b_key_type = "B";
            clmdtl_b_clinic_nbr_1_2 = acpt_claim_clinic;
            clmdtl_b_doc_nbr = acpt_claim_doc_nbr;
            clmdtl_b_week = acpt_claim_week;
            clmdtl_b_day = acpt_claim_day;
            clmdtl_b_claim_nbr = acpt_claim_claim_nbr;

            clmdtl_b_oma_cd = "0";
            clmdtl_b_oma_suff = "0";
            clmdtl_b_adj_nbr = "0";

            //     perform ma2-access-batctrl		thru ma2-99-exit.;
            await ma2_access_batctrl();
            await ma2_99_exit();            

            //     perform aa3-disp-claim		thru aa3-99-exit.;
            string retval =  await aa3_disp_claim();
            if (Util.Str(retval).Equals("aa3_99_exit"))
            {
                goto _aa3_99_exit;
            }
            await aa3_90_reply();
            _aa3_99_exit:
            await aa3_99_exit();


            // if flag-del-clm-n or ws-clmhdr-delete = 'N'  then      
            if (Util.Str(flag_del_clm).Equals(flag_del_clm_n) || Util.Str(ws_clmhdr_delete).ToUpper().Equals("N"))
            {
                //   	go to ab0-90-clr-dtls.;
                await ab0_90_clr_dtls();
                return;
            }

            // if flag-found-batch-n then       
            if (Util.Str(flag_found_batch).Equals(flag_found_batch_n))
            {
                err_ind = 49;
                // 	  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ab0-90-clr-dtls.;
                await ab0_90_clr_dtls();
                return;
            }

            //     perform ba1-verify-batch-for-del	thru ba1-99-exit.;
            await ba1_verify_batch_for_del();
            await ba1_99_exit();


            // if flag-batch-status-not-ok then            
            if (Util.Str(flag_batch_status).Equals(flag_batch_status_not_ok))
            {
                // 	  go to ab0-90-clr-dtls.;
                await ab0_90_clr_dtls();
                return;
            }

            //  perform ba3-verify-clm-for-del	thru ba3-99-exit.;
            await ba3_verify_clm_for_del();
            await ba3_99_exit();

            // if flag-del-clm-y then       
            if (Util.Str(flag_del_clm).Equals(flag_del_clm_y))
            {
                // 	   perform ma0-clmhdr-detail-phys-del thru ma0-99-exit.            
                await ma0_clmhdr_detail_phys_del();
                await ma0_10_delete_records();
            }
        }

        private async Task ab0_90_clr_dtls()
        {
            await Exit_Trakker();

            //     display scr-clr-dtls.;
            Display("scr-clr-dtls.");

        }

        private async Task ab0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ba1_verify_batch_for_del()
        {
            await Exit_Trakker();

            // if batctrl-batch-status =    '0' or '1'   then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).Equals("0") || Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).Equals("1"))
            {
                flag_batch_status = "Y";
            }
            else
            {
                err_ind = 59;
                // 	   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                flag_batch_status = "N";
            }
        }

        private async Task ba1_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ba3_verify_clm_for_del()
        {
            await Exit_Trakker();

            // if clmhdr-date-period-end not = batctrl-date-period-end then
            clmhdr_date_period_end_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_PERIOD_END);
            if (clmhdr_date_period_end_grp != Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                err_ind = 63;
                // 	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                flag_del_clm = "N";
            }
        }

        private async Task ba3_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ka0_access_patient()
        {
            await Exit_Trakker();

            this.flag = "N";

            // read pat-mstr;
            // 	        invalid key;
            //             flag = "N";
            // 	            go to ka0-99-exit.;

            objPat_mstr_rec = new F010_PAT_MSTR
            {
                WherePat_i_key = objPat_mstr_rec.PAT_I_KEY, //key_pat_mstr_grp.PadRight(15).Substring(0, 1),
                WherePat_con_nbr = objPat_mstr_rec.PAT_CON_NBR,  //Util.NumDec(key_pat_mstr_grp.PadRight(15).Substring(1, 2)),
                WherePat_i_nbr = objPat_mstr_rec.PAT_I_NBR  //Util.NumDec(key_pat_mstr_grp.PadRight(15).Substring(3, 12))
            }.Collection().FirstOrDefault();

            if (objPat_mstr_rec == null)
            {
                objPat_mstr_rec = new F010_PAT_MSTR();
                this.flag = "N";
                await ka0_99_exit();
                return;
            }

            await PatMstr_To_ScreenVariables();
            flag = "Y";
            //     add 1				to ctr-read-pat-mstr.;
            ctr_read_pat_mstr++;
        }

        private async Task ka0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ma0_clmhdr_detail_phys_del()
        {
            await Exit_Trakker();

            feedback_claims_mstr = "0";
            claims_occur = 0;

            //objClaims_mstr_dtl_rec.key_claims_mstr = hold_key_claims_mstr;

            // start claims-mstr key is equal to key-claims-mstr;
            //    	invalid key;
            //          err_ind = 51;
            // 	        perform za0-common-error	thru za0-99-exit;
            // 	        go to az0-end-of-job.;

            // read claims-mstr next  into claim-header-rec;
            // 	   at end;
            //        err_ind = 56;
            // 	      perform za0-common-error	thru za0-99-exit;
            // 	      go to az0-end-of-job.;

            claims_mstr_detail_ctr = 0;

            ObservableCollection<F002_CLAIMS_MSTR_HDR> tmp_F002_CLAIMS_MSTR_HDR_Collection = null;
            tmp_F002_CLAIMS_MSTR_HDR_Collection = new F002_CLAIMS_MSTR_HDR
            {
                WhereKey_clm_batch_nbr = clmhdr_b_batch_num
            }.Collection();

            Claims_mstr_rec_Collection.Clear();
            foreach (var obj in tmp_F002_CLAIMS_MSTR_HDR_Collection.OrderBy(x => x.KEY_CLM_BATCH_NBR).ThenBy(y => y.KEY_CLM_CLAIM_NBR))
            {
                Claims_mstr_rec_Collection.Add(obj);
            }

            ctr_read_claimss_hdr = -1;  
            foreach (var obj in Claims_mstr_rec_Collection)
            {
                ctr_read_claimss_hdr++;
                if (obj.CLMHDR_BATCH_NBR == clmhdr_b_batch_num && obj.CLMHDR_CLAIM_NBR == clmhdr_claim_nbr)
                {
                    objClaims_mstr_rec = obj;
                    break;
                }
            }

            Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = clmhdr_b_key_type, 
                WhereKey_clm_batch_nbr = clmhdr_b_batch_num, 
                WhereKey_clm_claim_nbr = clmhdr_claim_nbr
            }.Collection();

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                err_ind = 51;
                // 	 perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	        go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }
            else
            {

            }

            await Clmhdr_Record_To_ScreenVariables();
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[claims_mstr_detail_ctr];
            await Clmdtl_Record_To_ScreenVariables();
            claims_mstr_detail_ctr++;
           
            hold_batch_nbr = clmhdr_orig_batch_nbr_grp;
            hold_claim_nbr = clmhdr_orig_claim_nbr;
            hold_pat_key_data = clmhdr_pat_key_data_grp;
            ws_total_nbr_svc = 0;

            //   perform ma5-update-batch-values	thru ma5-99-exit.;
            await ma5_update_batch_values();
            await ma5_99_exit();
        }

        private async Task ma0_10_delete_records()
        {
            await Exit_Trakker();

            //  delete claims-mstr record;                                     
            // 	     invalid key;
            //          err_ind = 55;
            // 	        perform za0-common-error	thru za0-99-exit;
            // 	        go to az0-end-of-job.;
            if (claims_mstr_detail_ctr <= Claims_mstr_dtl_rec_Collection.Count())
            {             
                    if (mstr_desc_clmdtl_oma_cd != "ZZZZ" || string.IsNullOrWhiteSpace(mstr_desc_dtl_desc))
                    {
                        await ma3_add_nbr_svc_to_ctr();
                    }             
            }
                

            delete_claims_dtl:

            if (!objClaims_mstr_dtl_rec.Delete()) // remove in claims details database   
            {
                err_ind = 55;
                // 	 perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	        go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }           

            feedback_claims_mstr = "0";
            claims_occur = 0;

            //     read claims-mstr next into claim-detail-rec;
            // 	at end;
            // 	    perform zz0-end-of-job	thru zz0-99-exit.;
            
            if ( claims_mstr_detail_ctr >= Claims_mstr_dtl_rec_Collection.Count())
            {                
                foreach (var obj in  F002_CLAIMS_MSTR_DTL_DESC_Collection)  //delete claims desc if it exist. 
                {
                    obj.Delete();
                }

                if (!objClaims_mstr_rec.Delete())
                {
                    err_ind = 55;
                    // 	 perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    
                    //   go to az0-end-of-job.;
                    await az0_end_of_job();
                    return;
                }

                //perform zz0-end - of - job  thru zz0-99 - exit.;
                await zz0_end_of_job(false);
                await zz0_99_exit();
                return;
            }
            
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[claims_mstr_detail_ctr];
            claims_mstr_detail_ctr++;

            if (objClaims_mstr_dtl_rec == null)
            {
                //perform zz0-end - of - job  thru zz0-99 - exit.;
                await zz0_end_of_job();
                await zz0_99_exit();
            }

            await Clmdtl_Record_To_ScreenVariables();

            // if clmdtl-b-batch-nbr = hold-batch-nbr and clmdtl-b-claim-nbr = hold-claim-nbr   then   
            if (clmdtl_batch_nbr == hold_batch_nbr && clmdtl_b_claim_nbr == hold_claim_nbr)
            {
                // 	   if clmdtl-oma-cd not = "ZZZZ" then            
                if (mstr_desc_clmdtl_oma_cd != "ZZZZ"  || string.IsNullOrWhiteSpace(mstr_desc_dtl_desc))
                {
                    // 	         perform ma3-add-nbr-svc-to-ctr thru ma3-99-exit            
                    await ma3_add_nbr_svc_to_ctr();
                    await ma3_99_exit();
                    // 	         go to ma0-10-delete-records;
                    goto delete_claims_dtl;   
                    return;
                }
                else
                {
                    // 	       go to ma0-10-delete-records.;
                    goto delete_claims_dtl;  
                    return;
                }
            }

            //  perform ma4-check-for-last-claim	thru ma4-99-exit.;
            await ma4_check_for_last_claim();
            await ma4_99_exit();


            // if batctrl-batch-type not = "C" then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper() != "C")
            {
                // 	   go to ma0-99-exit.;
                await ma0_99_exit();
                return;
            }
        }

        private async Task ma0_20_read_claims_mstr()
        {
            await Exit_Trakker();
        }

        private async Task ma0_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma1_read_claim_next_for_index()
        {
            await Exit_Trakker();

            feedback_claims_mstr = "0";
            claims_occur = 0;

            //  read claims-mstr next into claim-header-rec;
            //         at end;
            //          end_search_index = "Y";
            // 	        go to ma1-99-exit.;
           
            if (claims_mstr_detail_ctr >= Claims_mstr_dtl_rec_Collection.Count())
            {
                end_search_index = "Y";
                // 	        go to ma1-99-exit.;
                await ma1_99_exit();
                return;
            }

            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[claims_mstr_detail_ctr];
            claims_mstr_detail_ctr++;

            if (objClaims_mstr_dtl_rec == null)
            {
                    end_search_index = "Y";
                // 	        go to ma1-99-exit.;
                ma1_99_exit();
                return;
            }

            await Clmhdr_Record_To_ScreenVariables();

            // if hold-pat-key-data not = clmhdr-pat-key-data  then            
            if (hold_pat_key_data != clmhdr_pat_key_data_grp)
            {
                end_search_index = "Y";
            }
        }

        private async Task ma1_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma2_access_batctrl()
        {
            await Exit_Trakker();

            objBatctrl_rec.BATCTRL_BATCH_NBR = Util.Str(clmdtl_b_clinic_nbr_1_2).PadLeft(2,'0') + Util.Str(clmdtl_b_doc_nbr).PadRight(3) + Util.Str(clmdtl_b_week).PadLeft(2,'0') + Util.Str(clmdtl_b_day);
            flag_found_batch = "Y";

            //  read batch-ctrl-file key is key-batctrl-file;
            //       	invalid key;
            //             flag_found_batch = "N";
            // 	          go to ma2-99-exit.;

            objBatctrl_rec = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR)
            }.Collection().FirstOrDefault();

            if (objBatctrl_rec == null)
            {
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                flag_found_batch = "N";
                //  go to ma2-99-exit.;
                await ma2_99_exit();
                return;
            }

            //     add 1				to ctr-read-batctrl-mstr.;
            ctr_read_batctrl_mstr++;
        }

        private async Task ma2_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ma3_add_nbr_svc_to_ctr()
        {
            await Exit_Trakker();

            //     add clmdtl-nbr-serv;
            //         clmdtl-sv-nbr (1);
            //         clmdtl-sv-nbr (2);
            //         clmdtl-sv-nbr (3)		to ws-total-nbr-svc.;

            ws_total_nbr_svc += Util.NumInt(clmdtl_nbr_serv) +  Util.NumInt(clmdtl_sv_nbr[1]) + Util.NumInt(clmdtl_sv_nbr[2]) + Util.NumInt(clmdtl_sv_nbr[3]);            
        }

        private async Task ma3_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ma4_check_for_last_claim()
        {
            await Exit_Trakker();

            //  if hold-claim-nbr = batctrl-last-claim-nbr then            
            if (hold_claim_nbr == Util.NumInt(objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR))
            {
                // 	   if hold-claim-nbr = 1 then            
                if (hold_claim_nbr == 1)
                {
                    // 	      perform ma41-del-phys-batch	thru ma41-99-exit;
                    await ma41_del_phys_batch();
                    await ma41_99_exit();
                    // 	      go to ma4-99-exit;
                    await ma4_99_exit();
                    return;
                }
                else
                {
                    // 	      perform ma42-read-claim-backwards thru ma42-99-exit     
                    await ma42_read_claim_backwards();
                    await ma42_99_exit();

                    // 	      if clmdtl-b-batch-nbr not = batctrl-batch-nbr then      
                    if (Util.Str(clmdtl_batch_nbr) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR))
                    {
                        // 		      perform ma41-del-phys-batch thru ma41-99-exit            
                        await ma41_del_phys_batch();
                        await ma41_99_exit();
                        // 		      go to ma4-99-exit;
                        await ma4_99_exit();
                        return;
                    }
                    else
                    {
                        //           objBatctrl_rec.batctrl_last_claim_nbr = objClaims_mstr_dtl_rec.clmdtl_b_claim_nbr;
                        objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR = Util.NumDec(clmdtl_b_claim_nbr);
                    }
                }
            }

            // if  batctrl-nbr-claims-in-batch not numeric or batctrl-nbr-claims-in-batch = zero   then            
            if (Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH) == 0)
            {
                objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH = objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR;
            }
            else
            {
                //   	subtract 1			from	batctrl-nbr-claims-in-batch.;
                objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH = objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH - 1;
            }

            //     subtract ws-total-nbr-svc		from batctrl-svc-act.;
            objBatctrl_rec.BATCTRL_SVC_ACT = Util.NumInt(objBatctrl_rec.BATCTRL_SVC_ACT) - ws_total_nbr_svc;

            // if batctrl-amt-est = batctrl-amt-act  or batctrl-svc-est = batctrl-svc-act then            
            if (objBatctrl_rec.BATCTRL_AMT_EST == objBatctrl_rec.BATCTRL_AMT_ACT || objBatctrl_rec.BATCTRL_SVC_EST == objBatctrl_rec.BATCTRL_SVC_ACT)
            {
                objBatctrl_rec.BATCTRL_BATCH_STATUS = "1";
            }
            else
            {
                objBatctrl_rec.BATCTRL_BATCH_STATUS = "0";
            }

            //     perform ma43-re-write-batctrl	thru ma43-99-exit.;
            await ma43_re_write_batctrl();
            await ma43_99_exit();
        }

        private async Task ma4_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma41_del_phys_batch()
        {
            await Exit_Trakker();

            feedback_batctrl_file = "0";

            //  read batch-ctrl-file key is key-batctrl-file;
            //      	invalid key;
            //          err_ind = 49;
            // 	        perform za0-common-error	thru za0-99-exit;
            // 	        go to az0-end-of-job.;

            objBatctrl_rec = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = objBatctrl_rec.BATCTRL_BATCH_NBR  
            }.Collection().FirstOrDefault();

            if (objBatctrl_rec == null)
            {
                err_ind = 49;
                // 	 perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	        go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            flag = "N";
            flag_del = "N";

            //  delete batch-ctrl-file	record;
            // 	       invalid key;
            //            err_ind = 57;
            // 	         perform za0-common-error	thru za0-99-exit;
            // 	         perform ma41a-check-batch-not-accessed thru ma41a-99-exit.

            if (!objBatctrl_rec.Delete())
            {
                err_ind = 57;
                //   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	 perform ma41a-check-batch-not-accessed thru ma41a-99-exit.
                await ma41a_check_batch_not_accessed();
                await ma41a_99_exit();
            } else
            {
                return;
            }


            //  if ok  then;            
            if (Util.Str(flag).Equals(ok))
            {
                // 	     go to ma41-del-phys-batch;
                await ma41_del_phys_batch();
                return;
            }
            else
            {
                // 	    if flag-del = 'Y' then         
                if (Util.Str(flag_del).ToUpper().Equals("Y"))
                {
                    // 	  perform ma41a-check-batch-not-accessed thru ma41a-99-exit            
                    await ma41a_check_batch_not_accessed();
                    await ma41a_99_exit();

                    // 	         if ok then          
                    if (Util.Str(flag).Equals(ok))
                    {
                        // 	 go to ma41-del-phys-batch;
                        await ma41_del_phys_batch();
                        return;
                    }
                    else
                    {
                        // 	next sentence;
                    }
                }
                else
                {
                    // 	  next sentence.;
                }
            }
        }

        private async Task ma41_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ma41a_check_batch_not_accessed()
        {
            await Exit_Trakker();

            err_ind = 61;
            //     perform za0-common-error		thru za0-99-exit.;
            await za0_common_error();
            await za0_99_exit();

            flag = "Y";
            //     display scr-acpt-re-try-del-batch.;
            //     accept  scr-acpt-re-try-del-batch.;
            Display("scr-acpt-re-try-del-batch.");
            await Prompt("flag", "scr-acpt-re-try-del-batch.", "scr-acpt-re-try-del-batch-flag");

            // if not-ok then          
            if (Util.Str(flag).Equals(not_ok))
            {
                err_ind = 62;
                // 	 perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	 go to az0-10-end-of-job.;
                await az0_10_end_of_job();
                return;
            }
        }

        private async Task ma41a_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ma42_read_claim_backwards()
        {
            await Exit_Trakker();
            //   read claims-mstr previous;
            // 	at end;
            //      objClaims_mstr_dtl_rec.key_claims_mstr = 0;
            // 	    go to ma42-99-exit.;


            //  Claims_mstr_rec_Collection.Remove(Claims_mstr_rec_Collection.Where(x => x.KEY_CLM_BATCH_NBR == objClaims_mstr_rec.KEY_CLM_BATCH_NBR && x.KEY_CLM_CLAIM_NBR == objClaims_mstr_rec.KEY_CLM_CLAIM_NBR).FirstOrDefault()); //remove from collection

            //claims_mstr_detail_ctr--;
            ctr_read_claimss_hdr--;            

            if (ctr_read_claimss_hdr < 0)  
            {
                objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR = "0";
                objClaims_mstr_dtl_rec.CLMDTL_CLAIM_NBR = 0;
                objClaims_mstr_dtl_rec.CLMDTL_OMA_CD = "0";
                objClaims_mstr_dtl_rec.CLMDTL_OMA_SUFF = "0";
                objClaims_mstr_dtl_rec.CLMDTL_ADJ_NBR = 0;

                objClaims_mstr_rec.KEY_CLM_BATCH_NBR  = "0";
                objClaims_mstr_rec.KEY_CLM_CLAIM_NBR = 0;                
                await ma42_99_exit();
                return;
            }

          objClaims_mstr_rec = Claims_mstr_rec_Collection[ctr_read_claimss_hdr];
          await Clmhdr_Record_To_ScreenVariables();

            Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = clmhdr_b_key_type,
                WhereKey_clm_batch_nbr = clmhdr_b_batch_num,
                WhereKey_clm_claim_nbr = clmhdr_claim_nbr
            }.Collection();

            claims_mstr_detail_ctr = 0;
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[claims_mstr_detail_ctr];
            await Clmdtl_Record_To_ScreenVariables();
            claims_mstr_detail_ctr++;            
        }

        private async Task ma42_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma43_re_write_batctrl()
        {
            await Exit_Trakker();

            // rewrite batctrl-rec;
            //    	invalid key;
            //          err_ind = 50;
            // 	        perform za0-common-error	thru za0-99-exit;
            // 	        go to az0-end-of-job.;

            try
            {

                objBatctrl_rec.RecordState = State.Modified;
                objBatctrl_rec.Submit();
            }
            catch (Exception e)
            {
                err_ind = 50;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	 go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }
        }

        private async Task ma43_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma5_update_batch_values()
        {
            await Exit_Trakker();

            //  if batctrl-adj-cd = "A" then            
            if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("A"))
            {
                // 	      subtract clmhdr-tot-claim-ar-ohip from batctrl-calc-ar-due            
                objBatctrl_rec.BATCTRL_CALC_AR_DUE = objBatctrl_rec.BATCTRL_CALC_AR_DUE - clmhdr_tot_claim_ar_ohip;
            }
            //  else if batctrl-adj-cd = "B" then                        
            else if (objBatctrl_rec.BATCTRL_ADJ_CD.ToUpper().Equals("B"))
            {
                // 	        subtract clmhdr-tot-claim-ar-ohip;
                // 					from batctrl-calc-ar-due;
                // 					     batctrl-calc-tot-rev;

                objBatctrl_rec.BATCTRL_CALC_AR_DUE = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE) - clmhdr_tot_claim_ar_ohip;
                objBatctrl_rec.BATCTRL_CALC_TOT_REV = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV) - clmhdr_tot_claim_ar_ohip;
            }
            //  else if batctrl-adj-cd = "C" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C"))
            {
                // 		        subtract clmhdr-manual-and-tape-paymnts from batctrl-manual-pay-tot            
                objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT = Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT) - clmhdr_manual_and_tape_paymnts;
            }
            //  else if batctrl-batch-type = 'C'then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                // 		    subtract clmhdr-tot-claim-ar-ohip;
                // 					from batctrl-calc-ar-due;
                // 					     batctrl-calc-tot-rev;
                objBatctrl_rec.BATCTRL_CALC_AR_DUE = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE) - clmhdr_tot_claim_ar_ohip;
                objBatctrl_rec.BATCTRL_CALC_TOT_REV = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV) - clmhdr_tot_claim_ar_ohip;

                // 		    subtract clmhdr-tot-claim-ar-oma;
                // 					from batctrl-amt-act;
                objBatctrl_rec.BATCTRL_AMT_ACT = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_ACT) - clmhdr_tot_claim_ar_oma;
            }
            else
            {
                // 	  subtract clmhdr-tot-claim-ar-oma from batctrl-amt-act.       
                objBatctrl_rec.BATCTRL_AMT_ACT = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_ACT) - clmhdr_tot_claim_ar_oma;
            }
        }

        private async Task ma5_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma6_update_patient()
        {
            await Exit_Trakker();

            //objPat_mstr_rec.key_pat_mstr = "";
            key_pat_mstr_grp = "";
            key_pat_mstr_grp = clmhdr_pat_key_type + clmhdr_pat_key_data_grp;  //clmhdr_pat_ohip_id_or_chart_grp;

            //  perform ka0-access-patient		thru ka0-99-exit.;
            await ka0_access_patient();
            await ka0_99_exit();


            // if not-ok then            
            if (flag.Equals(not_ok))
            {
                err_ind = 58;
                // 	 perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            //   subtract 1				from pat-nbr-outstanding-claims;
            // 					     pat-total-nbr-claims.;

            pat_nbr_outstanding_claims--;
            pat_total_nbr_claims--;


            //  subtract ws-total-nbr-svc		from pat-total-nbr-visits.;
            pat_total_nbr_visits = pat_total_nbr_visits - ws_total_nbr_svc;

            //  rewrite pat-mstr-rec;
            // 	    invalid key;
            //         err_ind = 53;
            // 	       perform za0-common-error	thru za0-99-exit;
            // 	       go to az0-end-of-job.;

            if (!await Rewrite_Pat_Mstr_Rec())
            {
                err_ind = 53;
                //   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	       go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

        }

        private async Task ma6_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task ma7_delete_claim_patient_key()
        {
            await Exit_Trakker();

            //  delete claims-mstr;
            // 	invalid key;
            //        err_ind = 54;
            // 	       perform za0-common-error	thru za0-99-exit;
            // 	       go to az0-end-of-job.;

            objF002_CLAIMS_MSTR_HDR = new F002_CLAIMS_MSTR_HDR
            {
                // todo...
            }.Collection().FirstOrDefault();

            if (!objF002_CLAIMS_MSTR_HDR.Delete())
            {
                err_ind = 54;
                //   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	       go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            feedback_claims_mstr = "0";
            claims_occur = 0;

        }

        private async Task ma7_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xc0_read_claims_mstr()
        {
            await Exit_Trakker();

            feedback_claims_mstr = "0";
            claims_occur = 0;

            //  read claims-mstr	into claim-header-rec	  key is key-claims-mstr;
            //   	invalid key;
            //           flag = "N";
            // 		     go to xc0-99-exit.;

            Claims_mstr_rec_Collection = new F002_CLAIMS_MSTR_HDR
            {
                WhereKey_clm_batch_nbr = Util.Str(acpt_claim_clinic) + Util.Str(acpt_claim_doc_nbr).PadRight(3) + Util.Str(acpt_claim_week).PadLeft(2,'0') + Util.Str(acpt_claim_day),  
                WhereKey_clm_claim_nbr = acpt_claim_claim_nbr   //objClaims_mstr_rec.KEY_CLM_CLAIM_NBR
            }.Collection_HDR_Sort_Using_Top(100,1,false);

          

            if (Claims_mstr_rec_Collection.Count() == 0)
            {
                flag = "N";
                //   go to xc0-99-exit.;
                await xc0_99_exit();
                return;
            }

            Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
               // WhereKey_clm_type = clmdtl_b_key_type,
                WhereKey_clm_batch_nbr = Util.Str(acpt_claim_clinic) + Util.Str(acpt_claim_doc_nbr).PadRight(3) + Util.Str(acpt_claim_week).PadLeft(2, '0') + Util.Str(acpt_claim_day),
                WhereKey_clm_claim_nbr = acpt_claim_claim_nbr
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(100, false);

            if ( Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                flag = "N";
                //   go to xc0-99-exit.;
                await xc0_99_exit();
                return;
            }

            F002_CLAIMS_MSTR_DTL_DESC_Collection = new F002_CLAIMS_MSTR_DTL_DESC
            {
               WhereKey_clm_batch_nbr = Util.Str(acpt_claim_clinic) + Util.Str(acpt_claim_doc_nbr).PadRight(3) + Util.Str(acpt_claim_week).PadLeft(2, '0') + Util.Str(acpt_claim_day),
               WhereKey_clm_claim_nbr = acpt_claim_claim_nbr
            }.Collection();

            ss_clmdtl_desc = 0;
            mstr_desc_dtl_desc = string.Empty;
            mstr_desc_clmdtl_oma_cd = string.Empty;
            foreach (var obj in F002_CLAIMS_MSTR_DTL_DESC_Collection)
            {
                ss_clmdtl_desc++;
                hold_desc[ss_clmdtl_desc] = Util.Str(obj.CLMDTL_DESC);  
                mstr_desc_dtl_desc = Util.Str(obj.CLMDTL_DESC);
                mstr_desc_clmdtl_oma_cd = Util.Str(obj.CLMDTL_OMA_CD);
            }

            ctr_read_claimss_hdr = 0;
            claims_details_ctr = 0;

            objClaims_mstr_rec =  Claims_mstr_rec_Collection[ctr_read_claimss_hdr];
            await Clmhdr_Record_To_ScreenVariables();
            ctr_read_claimss_hdr++;
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[claims_details_ctr];
            
            hold_feedback_clmhdr = feedback_claims_mstr;
            key_claims_mstr = Util.Str(clmdtl_b_key_type) + clmhdr_b_batch_number_grp;
            hold_key_claims_mstr = key_claims_mstr;
            flag = "Y";
            //     add  1				to	ctr-read-claims-mstr.;
            ctr_read_claims_mstr++;            
        }

        private async Task xc0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xc2_read_claims_mstr_next()
        {
            await Exit_Trakker();

            feedback_claims_mstr = "0";
            claims_occur = 0;

            //  read claims-mstr next into claim-header-rec;
            //   	at end;
            //        flag = "N";
            // 	    go to xc2-99-exit.;

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                flag = "N";
                // 	    go to xc2-99-exit.;
                await xc2_99_exit();
                return;
            }
            else
            {
                if (ctr_read_claims_mstr_dtl >= Claims_mstr_dtl_rec_Collection.Count())
                {
                    flag = "N";
                    // 	    go to xc2-99-exit.;
                    await xc2_99_exit();
                    return;
                }
                else
                {
                    objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[ctr_read_claims_mstr_dtl];
                    ctr_read_claims_mstr_dtl++;
                    await Clmhdr_Record_To_ScreenVariables();
                }
            }

            hold_feedback_clmhdr = feedback_claims_mstr;
            hold_key_claims_mstr = key_claims_mstr;
            flag = "Y";
            //     add 1 				to ctr-read-claims-mstr.;
            ctr_read_claims_mstr++;
        }

        private async Task xc2_99_exit()
        {
            await Exit_Trakker();
        }

        private async Task xd0_read_all_clmdtl()
        {
            await Exit_Trakker();

            ss_clmdtl_oma = 0;
           // ss_clmdtl_desc = 0;
            ss_clmdtl = 0;

            hold_descriptions_grp = "";
            hold_desc_1 = "";
            hold_desc_2 = "";
            hold_desc_3 = "";
            hold_desc_4 = "";
            hold_desc_5 = "";
        }

        private async Task xd0_10_read_index_rec()
        {
            await Exit_Trakker();

            //     perform xd00-read-clmdtl-rec	thru xd00-99-exit.;
            await xd00_read_clmdtl_rec();
            await xd00_99_exit();


            // if ok then;            
            if (flag.Equals(ok))
            {
                // 	   perform xd02-move-clmdtl-to-hold-area	thru xd02-99-exit;
                await xd02_move_clmdtl_to_hold_area();
                await xd02_99_exit();

                // 	   if ss-clmdtl-desc < ss-max-nbr-of-desc-rec-allow then            
                if (ss_clmdtl_desc < ss_max_nbr_of_desc_rec_allow)
                {
                    // 	       go to xd0-10-read-index-rec.;
                    await xd0_10_read_index_rec();
                    return;
                }
            }
        }

        private async Task xd0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xd00_read_clmdtl_rec()
        {
            await Exit_Trakker();

            feedback_claims_mstr = "0";
            claims_occur = 0;

            // read    claims-mstr    next   into claim-detail-rec;
            //     	at end;
            //           flag = "N";
            // 	         go to xd00-99-exit.;

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                flag = "N";
                // 	    go to xc2-99-exit.;
                await xc2_99_exit();
                return;
            }
            else
            {
                if (claims_details_ctr >= Claims_mstr_dtl_rec_Collection.Count())
                {
                    flag = "N";
                    // 	    go to xc2-99-exit.;
                    await xc2_99_exit();
                    return;
                }
                else
                {
                    objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[claims_details_ctr];
                    await Clmdtl_Record_To_ScreenVariables();
                    claims_details_ctr++; 
                }
            }


            //  if  ((clmdtl-batch-nbr	= clmhdr-batch-nbr and clmdtl-claim-nbr	= clmhdr-claim-nbr)   or  (clmdtl-batch-nbr	= clmhdr-orig-batch-nbr  and clmdtl-claim-nbr	= clmhdr-orig-claim-nbr)) and clmdtl-oma-cd not 	= "0000"   then            
            if (
                ((clmdtl_batch_nbr == clmhdr_batch_nbr && Util.NumInt(clmdtl_claim_nbr) == Util.NumInt(clmhdr_claim_nbr)) || (clmdtl_batch_nbr == clmhdr_orig_batch_nbr_grp && clmdtl_claim_nbr == clmhdr_orig_claim_nbr)) && clmdtl_oma_cd != "0000"
                )
            {
                flag = "Y";
            }
            else
            {
                flag = "N";
            }
        }

        private async Task xd00_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xd01_read_clmdtl_data_rec()
        {
            await Exit_Trakker();

            //  read   claims-mstr        into claim-detail-rec	key is key-claims-mstr;
            //    	invalid key;
            //          err_ind = 21;
            // 	        perform za0-common-error		thru za0-99-exit;
            // 	        go to az0-end-of-job.;

            /* Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
             {
                 WhereKey_clm_type = Util.Str(key_claims_mstr).PadRight(17).Substring(0, 1),
                 WhereClmhdr_batch_nbr = Util.Str(key_claims_mstr).PadRight(17).Substring(1, 8),
                 WhereClmhdr_claim_nbr = Util.NumDec(Util.Str(key_claims_mstr).PadRight(17).Substring(9, 2)),
                 WhereClmhdr_adj_oma_cd = Util.Str(key_claims_mstr).PadRight(17).Substring(11, 4),
                 WhereClmhdr_adj_oma_suff = Util.Str(key_claims_mstr).PadRight(17).Substring(15, 1),
                 WhereClmhdr_adj_adj_nbr = Util.Str(key_claims_mstr).PadRight(17).Substring(16, 1)

             }.Collection_HDR_INNERJOIN_DTL(); */

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                err_ind = 21;
                // 	        perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	        go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            ctr_read_claims_mstr_dtl = 0;
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[ctr_read_claims_mstr_dtl];
            
            await Clmdtl_Record_To_ScreenVariables();

            //     add 1					to ctr-read-claims-mstr.;
            ctr_read_claims_mstr++;
        }

        private async Task xd01_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task xd02_move_clmdtl_to_hold_area()
        {
            await Exit_Trakker();

            // if clmdtl-oma-cd = "ZZZZ" then            
            /* if (mstr_desc_clmdtl_oma_cd == "ZZZZ")
             {
                 // 	   add 1				to           ss-clmdtl-desc;
                 ss_clmdtl_desc++;
                 hold_desc[ss_clmdtl_desc] = clmdtl_desc;
             } */

            //else
            //{
            // 	  add 1				to ss-clmdtl;
            ss_clmdtl++;
                this.ws_hold_clmdtl_batch_nbr_grp = clmdtl_orig_batch_nbr;
                ws_clinic_nbr1 = Util.NumInt(Util.Str(ws_hold_clmdtl_batch_nbr_grp).PadRight(8).Substring(0, 2));
                ws_doc_nbr = Util.Str(ws_hold_clmdtl_batch_nbr_grp).PadRight(8).Substring(2, 3);
                ws_doc_nbr3 = ws_doc_nbr;
                ws_week_day = Util.NumInt(Util.Str(ws_hold_clmdtl_batch_nbr_grp).PadRight(8).Substring(5, 3));
                hold_clm_id[ss_clmdtl] = clmdtl_orig_batch_nbr;
                hold_clm_clinic_nbr[ss_clmdtl] = ws_clinic_nbr1;
                hold_clm_doc_nbr[ss_clmdtl] = ws_doc_nbr3;
                hold_clm_week_day[ss_clmdtl] = ws_week_day;
                hold_clm_clm_nbr[ss_clmdtl] = clmdtl_claim_nbr;
                hold_clm_cyc[ss_clmdtl] = clmdtl_cycle_nbr;
                hold_clm_per_end_date[ss_clmdtl] = clmdtl_date_period_end;
                hold_clm_svc_date[ss_clmdtl] = clmdtl_sv_date_grp;
                hold_clm_oma_cd[ss_clmdtl] = clmdtl_oma_cd;
                hold_clm_oma_suff[ss_clmdtl] = clmdtl_oma_suff;
                // 	add clmdtl-nbr-serv clmdtl-sv-nbr (1);
                // 			    clmdtl-sv-nbr (2) clmdtl-sv-nbr (3);
                // 				giving hold-clm-svc (ss-clmdtl);

                hold_clm_svc[ss_clmdtl] = Util.NumInt(clmdtl_nbr_serv) + clmdtl_sv_nbr[1] + clmdtl_sv_nbr[2] + clmdtl_sv_nbr[3];

                hold_clm_agent[ss_clmdtl] = clmdtl_agent_cd;
                hold_clm_adj_cd[ss_clmdtl] = clmdtl_adj_cd;
                hold_clm_amt_due[ss_clmdtl] = clmdtl_fee_ohip;
            // }           

        }

        private async Task xd02_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        // hosp_nbr_code_to_nbr.rtn
        private async Task xf0_move_hosp_nbr()  //CA11_MOVE_HOSP()
        {
            await Exit_Trakker();

            //SUBS_HOSP = ZERO;
            subs_hosp = 0;
        }

        // hosp_nbr_code_to_nbr.rtn
        private async Task xf0_10_hosp_loop()
        {
            await Exit_Trakker();

            //     ADD 1			TO	SUBS-HOSP.;
            subs_hosp++;

            //IF CLMHDR-HOSP = HOSP-CODE (SUBS-HOSP)  THEN            
            if (clmhdr_hosp == hosp_code[subs_hosp])
            {
                //  MOVE HOSP-NBR(SUBS - HOSP) TO ws-hosp - nbr
                ws_hosp_nbr = hosp_nbr[subs_hosp];
                // 	  GO TO CA11-99-EXIT.;
                await xf0_99_exit();
                return;
            }

            // IF SUBS-HOSP < 35 THEN         
            if (subs_hosp < 35)
            {
                // 	   GO TO CA11-10-HOSP-LOOP;
                await xf0_10_hosp_loop();
                return;
            }
            else
            {
                ws_hosp_nbr = "0";
            }
        }

        // hosp_nbr_code_to_nbr.rtn
        private async Task xf0_99_exit()
        {
            await Exit_Trakker();

            //     EXIT.;
            // 	replacing ==ca11-move-hosp==	by	==xf0-move-hosp-nbr==;
            // 		  ==ca11-10-hosp-loop==	by	==xf0-10-hosp-loop==;
            // 		  ==ca11-99-exit==	by	==xf0-99-exit==;
            // 		  ==l1-hosp==		by	==ws-hosp-nbr==;
            // 		  ==spaces==		by	==clmhdr-hosp==.;
        }

        private async Task za0_common_error()
        {
            await Exit_Trakker();

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            //     accept scr-confirm.;
            Display("err-msg-line.");
            Display("scr-confirm");
            await Prompt("confirm_space");
            Display("scr-confirm",false);

            //     display blank-line-24.;
            Display("blank-line-24.");
        }

        private async Task za0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task zz0_end_of_job(bool isEof = true)
        {
            await Exit_Trakker();

            // if batctrl-batch-type = "C" then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                //       perform ma6-update-patient	thru ma6-99-exit.;
                await ma6_update_patient();
                await ma6_99_exit();
            }

            //  perform ma4-check-for-last-claim	thru ma4-99-exit.;
            await ma4_check_for_last_claim();
            await ma4_99_exit();

            if (!isEof) return;

            //err_ind = 56;
            //  perform za0-common-error	thru za0-99-exit.;
            //await za0_common_error();
            //await za0_99_exit();

            //    go to az0-10-end-of-job.;
            await az0_10_end_of_job();
            return;
        }

        private async Task zz0_99_exit()
        {
            await Exit_Trakker();

            //    exit.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {
            await Exit_Trakker();

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            //sys_date_blank = 0;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task Initialize_ClmHdr_Record_ScreenVariables()
        {
            await Exit_Trakker();

            clmhdr_batch_nbr = "";
            clmhdr_clinic_nbr_1_2 = "";
            clmhdr_doc_nbr = "";
            clmhdr_week = "";
            clmhdr_day = "";

            clmhdr_batch_nbr_3_6 = "";
            clmhdr_batch_nbr_7_9 = 0;

            clmhdr_claim_nbr = 0;

            //clmhdr_zeroed_oma_suff_adj_grp
            clmhdr_adj_oma_cd = "";
            clmhdr_adj_oma_suff = "";
            clmhdr_adj_adj_nbr = 0;

            clmhdr_batch_type = "";
            clmhdr_adj_cd_sub_type = "";
            clmhdr_adj_cd_sub_type_ss = 0;

            clmhdr_doc_nbr_ohip = 0;
            clmhdr_doc_spec_cd = 0;
            clmhdr_refer_doc_nbr = 0;
            clmhdr_diag_cd = "";
            clmhdr_loc = "";
            clmhdr_hosp = "";
            clmhdr_payroll = "";
            clmhdr_agent_cd = "";
            clmhdr_adj_cd = "";
            clmhdr_tape_submit_ind = "";
            clmhdr_i_o_pat_ind = "";
            //clmhdr_pat_ohip_id_or_chart 
            clmhdr_pat_key_type = "";
            clmhdr_pat_key_data_grp = "";
            clmhdr_pat_key_ohip = "";
            //clmhdr_pat_acronym_grp 
            clmhdr_pat_acronym6 = "";
            clmhdr_pat_acronym3 = "";
            clmhdr_reference = "";

            clmhdr_date_admit_yy = "";
            clmhdr_date_admit_yy_r_grp = "";
            clmhdr_date_admit_yy_12 = "";
            clmhdr_date_admit_yy_34 = "";
            clmhdr_date_admit_mm = "";
            clmhdr_date_admit_dd_r = "";
            clmhdr_date_admit_dd = "";
            clmhdr_date_admit_dd_r = "";
            clmhdr_date_admit_r = 0;
            clmhdr_doc_dept = 0;
            clmhdr_date_cash_tape_payment = "";
            clmhdr_curr_payment = 0;
            clmhdr_date_period_end_grp = "";
            clmhdr_period_end_yy = 0;
            clmhdr_period_end_mm = 0;
            clmhdr_period_end_dd = 0;
            clmhdr_cycle_nbr = 0;
            clmhdr_date_sys = "";
            clmhdr_amt_tech_billed = 0;
            clmhdr_amt_tech_paid = 0;
            clmhdr_tot_claim_ar_oma = 0;
            clmhdr_tot_claim_ar_ohip = 0;
            clmhdr_manual_and_tape_paymnts = 0;
            clmhdr_status_ohip = "";
            clmhdr_manual_review = "";
            clmhdr_submit_date_grp = "";
            clmhdr_submit_yy = 0;
            clmhdr_submit_mm = 0;
            clmhdr_submit_dd = 0;
            clmhdr_confidential_flag = "";
            clmhdr_serv_date = 0;
            clmhdr_elig_error = "";
            clmhdr_elig_status = "";
            clmhdr_serv_error = "";
            clmhdr_serv_status = "";
            clmhdr_orig_batch_id_grp = "";
            clmhdr_orig_batch_nbr_grp = "";
            clmhdr_orig_batch_nbr_1_2 = 0;
            clmhdr_orig_batch_nbr_4_9 = "";
            clmhdr_orig_batch_nbr_next_def_grp = "";
            clmhdr_orig_batch_nbr_4_6 = "";
            clmhdr_orig_batch_nbr_7_8 = 0;
            clmhdr_orig_batch_nbr_9 = 0;
            clmhdr_orig_claim_nbr = 0;
            clmhdr_orig_batch_id_r_grp = "";
            clmhdr_orig_complete_batch_nbr = "";
            clmhdr_b_key_type = "";
            clmhdr_b_data_grp = "";
            clmhdr_b_batch_num = "";
            clmhdr_b_clinic_nbr_1_2 = 0;
            clmhdr_b_doc_nbr = "";
            clmhdr_b_doc_nbr_r_grp = "";
            clmhdr_b_doc_nbr_2_4 = "";
            clmhdr_b_batch_number_grp = "";
            clmhdr_b_week = 0;
            clmhdr_b_day = 0;
            clmhdr_b_claim_nbr = 0;
            clmhdr_b_oma_cd = "";
            clmhdr_b_oma_suff = "";
            clmhdr_b_adj_nbr = "";
            clmhdr_b_data_r_grp = "";
            clmhdr_b_pat_id = "";
            // clmhdr_p_claims_mstr_grp
            clmhdr_p_key_type = "";
            clmhdr_p_data_grp = "";
            clmhdr_p_batch_nbr_grp = "";
            clmhdr_p_clinic_nbr_1_2 = 0;
            clmhdr_p_doc_nbr = "";
            clmhdr_p_week = 0;
            clmhdr_p_day = 0;
            clmhdr_p_claim_nbr = 0;
            clmhdr_p_oma_cd = "";
            clmhdr_p_oma_suff = "";
            clmhdr_p_adj_nbr = "";
        }
        private async Task Initialize_Clmdtl_Record_ScreenVariables()
        {
            clmdtl_batch_nbr = "";
            clmdtl_claim_nbr = 0;
            clmdtl_oma_cd = "";
            clmdtl_oma_suff = "";
            clmdtl_adj_nbr = 0;
            clmdtl_rev_group_cd = "";
            clmdtl_agent_cd = 0;
            clmdtl_adj_cd = "";
            clmdtl_nbr_serv = 0;
            clmdtl_sv_date_grp = "";
            clmdtl_sv_yy = 0;
            clmdtl_sv_mm = 0;
            clmdtl_sv_dd = 0;
            //clmdtl-consecutive-sv-date  occurs 3 times
            //15  clmdtl-consec-dates-r  redefines  clmdtl-consec-dates.
            //20  clmdtl-consecutive-dates    occurs 3 times.
            clmdtl_sv_nbr[1] = 0;
            clmdtl_sv_nbr[2] = 0;
            clmdtl_sv_nbr[3] = 0;
            clmdtl_sv_day[1] = "";
            clmdtl_sv_day[2] = "";
            clmdtl_sv_day[3] = "";
            clmdtl_amt_tech_billed = 0;
            clmdtl_fee_oma = 0;
            clmdtl_fee_ohip = 0;
            clmdtl_date_period_end = "";
            clmdtl_cycle_nbr = 0;
            clmdtl_diag_cd = 0;
            clmdtl_line_no = 0;
            clmdtl_resubmit_flag = "0";
            clmdtl_reserve_for_future = "";
            clmdtl_desc = "";
            clmdtl_filler = "";
            //clmdtl_orig_batch_id
            clmdtl_orig_batch_nbr = "";
            clmdtl_orig_batch_nbr_1_2 = 0;
            clmdtl_orig_batch_nbr_4_9 = "";
            clmdtl_orig_claim_nbr_in_batch = 0;
            clmdtl_b_key_type = "";
            clmdtl_b_batch_num = "";
            clmdtl_b_clinic_nbr_1_2 = 0;
            clmdtl_b_doc_nbr = "";
            clmdtl_b_doc_nbr_2_4 = "";
            clmdtl_b_week = 0;
            clmdtl_b_day = 0;
            clmdtl_b_claim_nbr = 0;
            clmdtl_b_oma_cd = "";
            clmdtl_b_oma_suff = "";
            clmdtl_b_adj_nbr = "";
            clmdtl_b_pat_id = "";

            clmdtl_p_key_type = "";
            clmdtl_p_data = "";
            clmdtl_p_batch_nbr = "";
            clmdtl_p_clinic_nbr_1_2 = 0;
            clmdtl_p_doc_nbr = "";
            clmdtl_p_week = 0;
            clmdtl_p_day = 0;
            clmdtl_p_claim_nbr = 0;
            clmdtl_p_oma_cd = "";
            clmdtl_p_oma_suff = "";
            clmdtl_p_adj_nbr = "";
        }

        private async Task PatMstr_To_ScreenVariables()
        {
            pat_acronym_grp = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6) + Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);
            pat_acronym_first6 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6);
            pat_acronym_last3 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);

            pat_ohip_out_prov_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadRight(2) + new string(' ', 6);
            pat_ohip_nbr = Util.NumInt(pat_ohip_out_prov_grp.Substring(0, 8));
            pat_mm = Util.NumInt(pat_ohip_out_prov_grp.Substring(8, 2));
            pat_yy = Util.NumInt(pat_ohip_out_prov_grp.Substring(10, 2));

            pat_direct_alpha_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA);
            pat_alpha1 = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3).Substring(0, 1);
            pat_alpha2_3 = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3).Substring(1, 2);

            /* pat_ohip_nbr_r_alpha = pat_ohip_out_prov_grp.Substring(0, 8);
             pat_ohip_nbr_MB_def_grp = pat_ohip_out_prov_grp.Substring(0, 8);
             pat_ohip_nbr_MB = Util.NumInt(pat_ohip_out_prov_grp.Substring(0, 6));
             pat_ohip_nbr_NT_1_char = pat_ohip_out_prov_grp.Substring(0, 1);
             pat_ohip_nbr_NT = Util.NumInt(pat_ohip_out_prov_grp.Substring(1, 7)); */

            pat_direct_yy = Util.Str(objPat_mstr_rec.PAT_DIRECT_YY);
            pat_direct_mm = Util.Str(objPat_mstr_rec.PAT_DIRECT_MM);
            pat_direct_dd = Util.Str(objPat_mstr_rec.PAT_DIRECT_DD);
            //ws_pat_direct_filler = objPat_mstr_rec.pat_

            pat_chart_nbr_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(1, 9);
            pat_chart_nbr_2_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2);
            pat_chart_1st_char_2 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(0, 1);
            pat_chart_remainder_2 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(1, 9);
            pat_chart_nbr_3_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3);
            pat_chart_1st_char_3 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(0, 1);
            pat_chart_remainder_3 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(1, 9);
            pat_chart_nbr_4_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4);
            pat_chart_1st_char_4 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(0, 1);
            pat_chart_remainder_4 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(1, 9);
            pat_chart_nbr_5_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5);
            pat_chart_1st_char_5 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(0, 1);
            pat_chart_remainder_5 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(1, 9);
            pat_surname = Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22);
            pat_surname_r_grp = Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22);
            pat_surname_first6 = pat_surname_r_grp.PadRight(25).Substring(0, 6);
            pat_surname_last19 = pat_surname_r_grp.PadRight(25).Substring(6, 19);
            pat_surname_rr_grp = pat_surname;
            pat_surname_first3 = pat_surname.PadRight(25).Substring(0, 3);
            pat_surname_last22 = pat_surname.PadRight(25).Substring(3, 22);
            pat_given_name = Util.Str(objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1).PadRight(1) + Util.Str(objPat_mstr_rec.FILLER3).PadRight(16);
            //pat_given_name_r_grp = ws_pat_given_name;
            pat_given_name_first3 = pat_given_name.Substring(0, 3);
            pat_given_name_last14 = pat_given_name.Substring(3, 14);
            pat_given_name_rr_grp = pat_given_name;
            pat_given_name_first1 = pat_given_name.Substring(0, 1);
            //filler 
            pat_init_grp = Util.Str(objPat_mstr_rec.PAT_INIT1) + Util.Str(objPat_mstr_rec.PAT_INIT2) + Util.Str(objPat_mstr_rec.PAT_INIT3);
            pat_location_field_grp = Util.Str(objPat_mstr_rec.PAT_LOCATION_FIELD);
            pat_location_field_1_3 = pat_location_field_grp.PadRight(4).Substring(0, 3);
            pat_last_doc_nbr_seen = Util.Str(objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN);
            pat_birth_date = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY) + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_MM) + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_DD));
            pat_birth_date_r_grp = Util.Str(pat_birth_date);
            pat_birth_date_yy = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_YY);
            pat_birth_date_mm = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_MM);
            pat_birth_date_dd = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_DD);
            pat_date_last_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_MAINT);
            pat_date_last_maint_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT);
            pat_date_last_maint_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(0, 4));
            pat_date_last_maint_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(4, 2));
            pat_date_last_maint_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(6, 2));
            pat_date_last_visit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            pat_date_last_visit_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            pat_date_last_visit_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(0, 4));
            pat_date_last_visit_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(4, 2));
            pat_date_last_visit_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(6, 2));
            pat_date_last_admit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            pat_date_last_admit_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            pat_date_last_admit_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(0, 4));
            pat_date_last_admit_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(4, 2));
            pat_date_last_admit_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(6, 2));
            pat_phone_nbr_grp = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR);
            pat_phone_nbr_first3 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(0, 3));
            pat_phone_nbr_last4 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(3, 4));
            pat_phone_nbr_remainder = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(7, 13);
            pat_total_nbr_visits = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_VISITS);
            pat_total_nbr_claims = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS);
            pat_sex = Util.Str(objPat_mstr_rec.PAT_SEX);
            pat_in_out = Util.Str(objPat_mstr_rec.PAT_IN_OUT);
            pat_nbr_outstanding_claims = Util.NumInt(objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS);
            key_pat_mstr_grp = Util.Str(objPat_mstr_rec.PAT_I_KEY) + Util.Str(objPat_mstr_rec.PAT_CON_NBR) + Util.Str(objPat_mstr_rec.PAT_I_NBR);
            pat_i_key = Util.Str(objPat_mstr_rec.PAT_I_KEY);
            pat_con_nbr = Util.NumInt(objPat_mstr_rec.PAT_CON_NBR);
            pat_i_nbr = Util.NumInt(objPat_mstr_rec.PAT_I_NBR);
            pat_health_nbr = Util.Str(objPat_mstr_rec.PAT_HEALTH_NBR);
            pat_version_cd_grp = Util.Str(objPat_mstr_rec.PAT_VERSION_CD);
            pat_version_cd_1 = Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(0, 1);
            pat_version_cd_2 = Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(1, 1);
            pat_health_65_ind = Util.Str(objPat_mstr_rec.PAT_HEALTH_65_IND);
            pat_expiry_date_grp = Util.Str(objPat_mstr_rec.PAT_EXPIRY_YY).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_EXPIRY_MM).PadLeft(2, '0');
            pat_expiry_yy = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_YY);
            pat_expiry_mm = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_MM);
            pat_prov_cd = Util.Str(objPat_mstr_rec.PAT_PROV_CD);
            subscr_addr1 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR1);
            subscr_addr2 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR2);
            subscr_addr3 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR3);
            subscr_prov_cd = Util.Str(objPat_mstr_rec.SUBSCR_PROV_CD);
            subscr_postal_cd = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            //subscr_postal_cd_r_grp = ws_subscr_postal_cd;
            subscr_post_code1_grp = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            subscr_post_cd1 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1);
            subscr_post_cd2 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2);
            subscr_post_cd3 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            subscr_post_code2_grp = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            subscr_post_cd4 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4);
            subscr_post_cd5 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5);
            subscr_post_cd6 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            //ws_subscr_msg_data_grp
            subscr_msg_nbr = Util.Str(objPat_mstr_rec.SUBSCR_MSG_NBR);
            subscr_date_msg_nbr_eff_to = Util.NumInt(Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD));
            subscr_date_msg_nbr_eff_to_r = Util.Str(subscr_date_msg_nbr_eff_to);
            subscr_date_msg_nbr_eff_to_yy = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY);
            subscr_date_msg_nbr_eff_to_mm = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM);
            subscr_date_msg_nbr_eff_to_dd = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD);
            //subscr_date_msg_nbr_eff_to_r1 = ws_subscr_dt_msg_no_eff_to_r_grp;
            subscr_date_last_statement = Util.NumInt(Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD));
            subscr_date_last_statement_r_grp = Util.Str(subscr_date_last_statement);
            subscr_date_last_statement_yy = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY);
            subscr_date_last_statement_mm = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM);
            subscr_date_last_statement_dd = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD);
            subscr_auto_update = Util.Str(objPat_mstr_rec.SUBSCR_AUTO_UPDATE);
            pat_last_mod_by = Util.Str(objPat_mstr_rec.PAT_LAST_MOD_BY);
            pat_date_last_elig_mailing = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING);
            pat_date_last_elig_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT);
            pat_last_birth_date = Util.NumInt(objPat_mstr_rec.PAT_LAST_BIRTH_DATE);
            pat_last_version_cd = Util.Str(objPat_mstr_rec.PAT_LAST_VERSION_CD);
            pat_mess_code = Util.Str(objPat_mstr_rec.PAT_MESS_CODE);
            pat_country = Util.Str(objPat_mstr_rec.PAT_COUNTRY);
            pat_no_of_letter_sent = Util.NumInt(objPat_mstr_rec.PAT_NO_OF_LETTER_SENT);
            pat_dialysis = Util.Str(objPat_mstr_rec.PAT_DIALYSIS);
            pat_ohip_validiation_status = Util.Str(objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS);
            pat_obec_status = Util.Str(objPat_mstr_rec.PAT_OBEC_STATUS);
        }

        private async Task<bool> Rewrite_Pat_Mstr_Rec()
        {
            try
            {
                objPat_mstr_rec.PAT_ACRONYM_FIRST6 = pat_acronym_first6;
                objPat_mstr_rec.PAT_ACRONYM_LAST3 = pat_acronym_last3;

                objPat_mstr_rec.PAT_DIRECT_ALPHA = pat_direct_alpha_grp;
                /* pat_ohip_nbr_r_alpha = pat_ohip_out_prov_grp.Substring(0, 8);
                 pat_ohip_nbr_MB_def_grp = pat_ohip_out_prov_grp.Substring(0, 8);
                 pat_ohip_nbr_MB = Util.NumInt(pat_ohip_out_prov_grp.Substring(0, 6));
                 pat_ohip_nbr_NT_1_char = pat_ohip_out_prov_grp.Substring(0, 1);
                 pat_ohip_nbr_NT = Util.NumInt(pat_ohip_out_prov_grp.Substring(1, 7)); */

                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumDec(pat_direct_yy);
                objPat_mstr_rec.PAT_DIRECT_MM = Util.NumDec(pat_direct_mm);
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumDec(pat_direct_dd);

                pat_chart_nbr_grp = Util.Str(pat_chart_1st_char).PadRight(1) + Util.Str(pat_chart_remainder).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR = pat_chart_nbr_grp;

                pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2).PadRight(1) + Util.Str(pat_chart_remainder_2).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_2 = pat_chart_nbr_2_grp;

                pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3).PadRight(1) + Util.Str(pat_chart_remainder_3).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_3 = pat_chart_nbr_3_grp;

                pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4).PadRight(1) + Util.Str(pat_chart_remainder_4).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_4 = pat_chart_nbr_4_grp;

                pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5).PadRight(1) + Util.Str(pat_chart_remainder_5).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_5 = pat_chart_nbr_5_grp;

                objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1 = pat_given_name.PadRight(1);
                //filler                 
                objPat_mstr_rec.PAT_LOCATION_FIELD = pat_location_field_grp;
                objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN = pat_last_doc_nbr_seen;
                objPat_mstr_rec.PAT_BIRTH_DATE_YY = pat_birth_date_yy;
                objPat_mstr_rec.PAT_BIRTH_DATE_MM = pat_birth_date_mm;
                objPat_mstr_rec.PAT_BIRTH_DATE_DD = pat_birth_date_dd;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = pat_date_last_maint;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumDec(pat_date_last_maint_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = pat_date_last_visit;
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = Util.NumDec(pat_date_last_visit_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = pat_date_last_admit;
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = Util.NumDec(pat_date_last_admit_r_grp);
                objPat_mstr_rec.PAT_PHONE_NBR = pat_phone_nbr_grp;
                objPat_mstr_rec.PAT_TOTAL_NBR_VISITS = pat_total_nbr_visits;
                objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS = pat_total_nbr_claims;
                objPat_mstr_rec.PAT_SEX = pat_sex;
                objPat_mstr_rec.PAT_IN_OUT = pat_in_out;
                objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS = pat_nbr_outstanding_claims;
                objPat_mstr_rec.PAT_I_KEY = pat_i_key;
                objPat_mstr_rec.PAT_CON_NBR = pat_con_nbr;
                objPat_mstr_rec.PAT_I_NBR = pat_i_nbr;
                objPat_mstr_rec.PAT_HEALTH_NBR = Util.NumDec(pat_health_nbr);
                objPat_mstr_rec.PAT_VERSION_CD = pat_version_cd_grp;
                objPat_mstr_rec.PAT_HEALTH_65_IND = pat_health_65_ind;
                objPat_mstr_rec.PAT_EXPIRY_YY = pat_expiry_yy;
                objPat_mstr_rec.PAT_EXPIRY_MM = pat_expiry_mm;
                objPat_mstr_rec.PAT_PROV_CD = pat_prov_cd;
                objPat_mstr_rec.SUBSCR_ADDR1 = subscr_addr1;
                objPat_mstr_rec.SUBSCR_ADDR2 = subscr_addr2;
                objPat_mstr_rec.SUBSCR_ADDR3 = subscr_addr3;
                objPat_mstr_rec.SUBSCR_PROV_CD = subscr_prov_cd;
                objPat_mstr_rec.SUBSCR_POST_CD1 = subscr_post_cd1;
                objPat_mstr_rec.SUBSCR_POST_CD2 = subscr_post_cd2;
                objPat_mstr_rec.SUBSCR_POST_CD3 = subscr_post_cd3;
                objPat_mstr_rec.SUBSCR_POST_CD4 = subscr_post_cd4;
                objPat_mstr_rec.SUBSCR_POST_CD5 = subscr_post_cd5;
                objPat_mstr_rec.SUBSCR_POST_CD6 = subscr_post_cd6;
                objPat_mstr_rec.SUBSCR_MSG_NBR = subscr_msg_nbr;
                subscr_date_msg_nbr_eff_to = Util.NumInt(subscr_date_msg_nbr_eff_to_r);
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = subscr_date_msg_nbr_eff_to_yy;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = subscr_date_msg_nbr_eff_to_mm;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = subscr_date_msg_nbr_eff_to_dd;
                subscr_date_last_statement = Util.NumInt(subscr_date_last_statement_r_grp);
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY = subscr_date_last_statement_yy;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM = subscr_date_last_statement_mm;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD = subscr_date_last_statement_dd;
                objPat_mstr_rec.SUBSCR_AUTO_UPDATE = subscr_auto_update;
                objPat_mstr_rec.PAT_LAST_MOD_BY = pat_last_mod_by;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING = pat_date_last_elig_mailing;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT = pat_date_last_elig_maint;
                objPat_mstr_rec.PAT_LAST_BIRTH_DATE = pat_last_birth_date;
                objPat_mstr_rec.PAT_LAST_VERSION_CD = pat_last_version_cd;
                objPat_mstr_rec.PAT_MESS_CODE = pat_mess_code;
                objPat_mstr_rec.PAT_COUNTRY = pat_country;
                objPat_mstr_rec.PAT_NO_OF_LETTER_SENT = pat_no_of_letter_sent;
                objPat_mstr_rec.PAT_DIALYSIS = pat_dialysis;
                objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS = pat_ohip_validiation_status;
                objPat_mstr_rec.PAT_OBEC_STATUS = pat_obec_status;

                objPat_mstr_rec.RecordState = State.Modified;
                objPat_mstr_rec.Submit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private async Task Clmhdr_Record_To_ScreenVariables()
        {
            clmhdr_batch_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR);
            clmhdr_clinic_nbr_1_2 = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Substring(0, 2);
            clmhdr_doc_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_week = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2);
            clmhdr_day = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1);

            clmhdr_batch_nbr_3_6 = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_batch_nbr_7_9 = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 3));

            clmhdr_claim_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_CLAIM_NBR);

            //clmhdr_zeroed_oma_suff_adj_grp
            clmhdr_adj_oma_cd = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_CD);
            clmhdr_adj_oma_suff = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_SUFF);
            clmhdr_adj_adj_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_ADJ_ADJ_NBR);

            clmhdr_batch_type = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE);
            clmhdr_adj_cd_sub_type = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_CD_SUB_TYPE);
            clmhdr_adj_cd_sub_type_ss = Util.NumInt(objClaims_mstr_rec.CLMHDR_ADJ_CD_SUB_TYPE);

            clmhdr_doc_nbr_ohip = Util.NumInt(objClaims_mstr_rec.CLMHDR_DOC_NBR_OHIP);
            clmhdr_doc_spec_cd = Util.NumInt(objClaims_mstr_rec.CLMHDR_DOC_SPEC_CD);
            clmhdr_refer_doc_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_REFER_DOC_NBR);
            clmhdr_diag_cd = Util.Str(objClaims_mstr_rec.CLMHDR_DIAG_CD);
            clmhdr_loc = Util.Str(objClaims_mstr_rec.CLMHDR_LOC);
            clmhdr_hosp = Util.Str(objClaims_mstr_rec.CLMHDR_HOSP);
            clmhdr_payroll = Util.Str(objClaims_mstr_rec.CLMHDR_HOSP);
            clmhdr_agent_cd = Util.Str(objClaims_mstr_rec.CLMHDR_AGENT_CD);
            clmhdr_adj_cd = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_CD);
            clmhdr_tape_submit_ind = Util.Str(objClaims_mstr_rec.CLMHDR_TAPE_SUBMIT_IND);
            clmhdr_i_o_pat_ind = Util.Str(objClaims_mstr_rec.CLMHDR_I_O_PAT_IND);
            //clmhdr_pat_ohip_id_or_chart 
            clmhdr_pat_key_type = Util.Str(objClaims_mstr_rec.CLMHDR_PAT_KEY_TYPE);
            clmhdr_pat_key_data_grp = Util.Str(objClaims_mstr_rec.CLMHDR_PAT_KEY_DATA);
            clmhdr_pat_key_ohip = Util.Str(objClaims_mstr_rec.CLMHDR_PAT_KEY_DATA).PadRight(15, ' ').Substring(0, 8);
            //clmhdr_pat_acronym_grp 
            clmhdr_pat_acronym6 = Util.Str(objClaims_mstr_rec.CLMHDR_PAT_ACRONYM6).PadRight(9).Substring(0, 6);
            clmhdr_pat_acronym3 = Util.Str(objClaims_mstr_rec.CLMHDR_PAT_ACRONYM3);
            clmhdr_reference = Util.Str(objClaims_mstr_rec.CLMHDR_REFERENCE);

            clmhdr_date_admit_yy = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(0, 4);
            clmhdr_date_admit_yy_r_grp = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(0, 4);
            clmhdr_date_admit_yy_12 = clmhdr_date_admit_yy.Substring(0, 2);
            clmhdr_date_admit_yy_34 = clmhdr_date_admit_yy.Substring(2, 2);
            clmhdr_date_admit_mm = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(4, 2);
            clmhdr_date_admit_dd_r = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(4, 2);
            clmhdr_date_admit_dd = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(6, 2);
            clmhdr_date_admit_dd_r = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(6, 2);
            clmhdr_date_admit_r = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_DATE_ADMIT));
            clmhdr_doc_dept = Util.NumInt(objClaims_mstr_rec.CLMHDR_DOC_DEPT);
            clmhdr_date_cash_tape_payment = Util.Str(objClaims_mstr_rec.CLMHDR_MSG_NBR).PadLeft(2,'0') + Util.Str(objClaims_mstr_rec.CLMHDR_REPRINT_FLAG).PadLeft(1,'0') + Util.Str(objClaims_mstr_rec.CLMHDR_SUB_NBR).PadLeft(1,'0') + "/" + Util.Str(objClaims_mstr_rec.CLMHDR_AUTO_LOGOUT).PadLeft(1,'0') + Util.Str(objClaims_mstr_rec.CLMHDR_FEE_COMPLEX).PadLeft(1,'0') + "/" + Util.Str(objClaims_mstr_rec.FILLER).PadRight(2,'0');             
            clmhdr_curr_payment = Util.NumDec(objClaims_mstr_rec.CLMHDR_CURR_PAYMENT);
            clmhdr_date_period_end_grp = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END);
            clmhdr_period_end_yy = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END).Substring(0, 4));
            clmhdr_period_end_mm = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END).Substring(4, 2));
            clmhdr_period_end_dd = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END).Substring(6, 2));
            clmhdr_cycle_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_CYCLE_NBR);
            clmhdr_date_sys = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_SYS);
            clmhdr_amt_tech_billed = Util.NumDec(objClaims_mstr_rec.CLMHDR_AMT_TECH_BILLED);
            clmhdr_amt_tech_paid = Util.NumDec(objClaims_mstr_rec.CLMHDR_AMT_TECH_PAID);
            clmhdr_tot_claim_ar_oma = Util.NumDec(objClaims_mstr_rec.CLMHDR_TOT_CLAIM_AR_OMA);
            clmhdr_tot_claim_ar_ohip = Util.NumDec(objClaims_mstr_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            clmhdr_manual_and_tape_paymnts = Util.NumDec(objClaims_mstr_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            clmhdr_status_ohip = Util.Str(objClaims_mstr_rec.CLMHDR_STATUS_OHIP);
            clmhdr_manual_review = Util.Str(objClaims_mstr_rec.CLMHDR_MANUAL_REVIEW);
            clmhdr_submit_date_grp = Util.Str(objClaims_mstr_rec.CLMHDR_SUBMIT_DATE);
            clmhdr_submit_yy = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_SUBMIT_DATE).PadRight(8).Substring(0, 4));
            clmhdr_submit_mm = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_SUBMIT_DATE).PadRight(8).Substring(4, 2));
            clmhdr_submit_dd = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_SUBMIT_DATE).PadRight(8).Substring(6, 2));
            clmhdr_confidential_flag = Util.Str(objClaims_mstr_rec.CLMHDR_CONFIDENTIAL_FLAG);
            clmhdr_serv_date = Util.NumInt(objClaims_mstr_rec.CLMHDR_SERV_DATE);
            clmhdr_elig_error = Util.Str(objClaims_mstr_rec.CLMHDR_ELIG_ERROR);
            clmhdr_elig_status = Util.Str(objClaims_mstr_rec.CLMHDR_ELIG_STATUS);
            clmhdr_serv_error = Util.Str(objClaims_mstr_rec.CLMHDR_SERV_ERROR);
            clmhdr_serv_status = Util.Str(objClaims_mstr_rec.CLMHDR_SERV_STATUS);
            clmhdr_orig_batch_id_grp = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_batch_nbr_grp = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_batch_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmhdr_orig_batch_nbr_4_9 = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(2, 4);
            clmhdr_orig_batch_nbr_next_def_grp = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_batch_nbr_4_6 = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_orig_batch_nbr_7_8 = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_orig_batch_nbr_9 = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmhdr_orig_claim_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_ORIG_CLAIM_NBR);
            clmhdr_orig_batch_id_r_grp = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_complete_batch_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_b_key_type = Util.Str(objClaims_mstr_rec.KEY_CLM_TYPE);
            clmhdr_b_data_grp = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR) + Util.Str(objClaims_mstr_rec.CLMHDR_CLAIM_NBR) + Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_CD) + Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_SUFF) + Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_ADJ_NBR);
            clmhdr_b_batch_num = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR);
            clmhdr_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Substring(0, 2));
            clmhdr_b_doc_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Substring(2, 3);
            clmhdr_b_doc_nbr_r_grp = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Substring(2, 3);
            clmhdr_b_doc_nbr_2_4 = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Substring(2, 3);
            clmhdr_b_batch_number_grp = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8);
            clmhdr_b_week = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_b_day = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmhdr_b_claim_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_CLAIM_NBR);
            clmhdr_b_oma_cd = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_CD);
            clmhdr_b_oma_suff = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_SUFF);
            clmhdr_b_adj_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_ADJ_NBR);
            clmhdr_b_data_r_grp = clmhdr_b_data_grp;
            clmhdr_b_pat_id = clmhdr_b_data_r_grp.Substring(0, 15);
            // clmhdr_p_claims_mstr_grp
            clmhdr_p_key_type = Util.Str(objClaims_mstr_rec.KEY_P_CLM_TYPE);
            clmhdr_p_data_grp = Util.Str(objClaims_mstr_rec.KEY_CLM_BATCH_NBR) + Util.Str(objClaims_mstr_rec.KEY_CLM_CLAIM_NBR) + Util.Str(objClaims_mstr_rec.KEY_CLM_SERV_CODE) + Util.Str(objClaims_mstr_rec.KEY_CLM_ADJ_NBR);
            clmhdr_p_batch_nbr_grp = Util.Str(objClaims_mstr_rec.KEY_CLM_BATCH_NBR);
            clmhdr_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmhdr_p_doc_nbr = Util.Str(objClaims_mstr_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_p_week = Util.NumInt(Util.Str(objClaims_mstr_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_p_day = Util.NumInt(Util.Str(objClaims_mstr_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmhdr_p_claim_nbr = Util.NumInt(objClaims_mstr_rec.KEY_CLM_CLAIM_NBR);
            clmhdr_p_oma_cd = Util.Str(objClaims_mstr_rec.KEY_CLM_SERV_CODE); // todo....not sure...???
            clmhdr_p_oma_suff = Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_OMA_SUFF);  // todo... not surel....???
            clmhdr_p_adj_nbr = Util.Str(objClaims_mstr_rec.KEY_CLM_ADJ_NBR);
        }

        private async Task Clmdtl_Record_To_ScreenVariables()
        {
            clmdtl_batch_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR);
            clmdtl_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_CLAIM_NBR);
            clmdtl_oma_cd = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_CD);
            clmdtl_oma_suff = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_SUFF);
            clmdtl_adj_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_ADJ_NBR);
            clmdtl_rev_group_cd = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_REV_GROUP_CD);
            clmdtl_agent_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_AGENT_CD);
            clmdtl_adj_cd = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ADJ_CD);
            clmdtl_nbr_serv = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_NBR_SERV);
            clmdtl_sv_date_grp = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_YY).PadLeft(4,'0') + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_MM).PadLeft(2,'0') + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_DD).PadLeft(2,'0');
            clmdtl_sv_yy = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_SV_YY);
            clmdtl_sv_mm = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_SV_MM);
            clmdtl_sv_dd = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_SV_DD);
            clmdtl_consec_dates_grp = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_CONSEC_DATES_R);
            clmdtl_sv_nbr[1] = Util.NumInt(Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(0, 1));
            clmdtl_sv_day[1] = Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(1, 2);
            clmdtl_sv_nbr[2] = Util.NumInt(Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(3, 1));
            clmdtl_sv_day[2] = Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(4, 2);
            clmdtl_sv_nbr[3] = Util.NumInt(Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(6, 1));
            clmdtl_sv_day[3] = Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(7, 2);            
            clmdtl_amt_tech_billed = Util.NumDec(objClaims_mstr_dtl_rec.CLMDTL_AMT_TECH_BILLED);
            clmdtl_fee_oma = Util.NumDec(objClaims_mstr_dtl_rec.CLMDTL_FEE_OMA);
            clmdtl_fee_ohip = Util.NumDec(objClaims_mstr_dtl_rec.CLMDTL_FEE_OHIP);
            clmdtl_date_period_end = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_DATE_PERIOD_END);
            clmdtl_cycle_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_CYCLE_NBR);
            clmdtl_diag_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_DIAG_CD);
            clmdtl_line_no = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_LINE_NO);
            clmdtl_resubmit_flag = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_RESUBMIT_FLAG);
            clmdtl_reserve_for_future = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_RESERVE_FOR_FUTURE);
            clmdtl_desc = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_DESC);
            clmdtl_filler = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_FILLER9);
            //clmdtl_orig_batch_id
            clmdtl_orig_batch_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ORIG_BATCH_NBR);
            clmdtl_orig_batch_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ORIG_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmdtl_orig_batch_nbr_4_9 = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ORIG_BATCH_NBR).PadRight(8).Substring(2, 6);
            clmdtl_orig_claim_nbr_in_batch = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH);
            clmdtl_b_key_type = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_TYPE);
            clmdtl_b_batch_num = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR);
            clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmdtl_b_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmdtl_b_doc_nbr_2_4 = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmdtl_b_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmdtl_b_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmdtl_b_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_CLAIM_NBR);
            clmdtl_b_oma_cd = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_CD);
            clmdtl_b_oma_suff = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_SUFF);
            clmdtl_b_adj_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ADJ_NBR);
            clmdtl_b_pat_id = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_CLAIM_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_CD) + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_SUFF) + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ADJ_NBR);

            clmdtl_p_key_type = Util.Str(objClaims_mstr_dtl_rec.KEY_P_CLM_TYPE);
            clmdtl_p_data = Util.Str(objClaims_mstr_dtl_rec.KEY_P_CLM_DATA);
            clmdtl_p_batch_nbr = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR);
            clmdtl_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmdtl_p_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmdtl_p_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmdtl_p_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmdtl_p_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.KEY_CLM_CLAIM_NBR);
            //clmdtl_p_oma_cd =    //todo...??
            //clmdtl_p_oma_suff =  //todo...??
            clmdtl_p_adj_nbr = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_ADJ_NBR);

         
        }


        #endregion

        #region display_details

        private async Task display_scr_dis_clmdet(int index)
        {
            switch (index)
            {
                case 1:
                case 9:
                case 17:
                case 25:
                case 33:
                case 41:
                case 49:
                case 57:
                case 65:
                case 73:
                case 81:
                case 89:
                case 97:
                    hold_clm_id_1 = hold_clm_id[index];
                    hold_clm_clm_nbr_1 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_1 = hold_clm_cyc[index];
                    hold_clm_per_end_date_1 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8,'0').Substring(0,4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2)  + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_1 = Util.Str(hold_clm_svc_date[index]).PadLeft(8,'0').Substring(0,4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2)  + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_1 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_1 = hold_clm_oma_suff[index];
                    hold_clm_svc_1 = hold_clm_svc[index];
                    hold_clm_agent_1 = hold_clm_agent[index];
                    hold_clm_adj_cd_1 = hold_clm_adj_cd[index];
                    hold_clm_card_col_1 = hold_clm_card_col[index];
                    hold_clm_amt_due_1 = hold_clm_amt_due[index];
                   // hold_desc_1 = hold_desc[index];
                    Display("scr-dis-clmdet-1.");
                    break;
                case 2:
                case 10:
                case 18:
                case 26:
                case 34:
                case 42:
                case 50:
                case 58:
                case 66:
                case 74:
                case 82:
                case 90:
                case 98:
                    hold_clm_id_2 = hold_clm_id[index];
                    hold_clm_clm_nbr_2 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_2 = hold_clm_cyc[index];
                    hold_clm_per_end_date_2 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_2 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_2 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_2 = hold_clm_oma_suff[index];
                    hold_clm_svc_2 = hold_clm_svc[index];
                    hold_clm_agent_2 = hold_clm_agent[index];
                    hold_clm_adj_cd_2 = hold_clm_adj_cd[index];
                    hold_clm_card_col_2 = hold_clm_card_col[index];
                    hold_clm_amt_due_2 = hold_clm_amt_due[index];
                   // hold_desc_2 = hold_desc[index];
                    Display("scr-dis-clmdet-2.");
                    break;
                case 3:
                case 11:
                case 19:
                case 27:
                case 35:
                case 43:
                case 51:
                case 59:
                case 67:
                case 75:
                case 83:
                case 91:
                case 99:
                    hold_clm_id_3 = hold_clm_id[index];
                    hold_clm_clm_nbr_3 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_3 = hold_clm_cyc[index];
                    hold_clm_per_end_date_3 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_3 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_3 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_3 = hold_clm_oma_suff[index];
                    hold_clm_svc_3 = hold_clm_svc[index];
                    hold_clm_agent_3 = hold_clm_agent[index];
                    hold_clm_adj_cd_3 = hold_clm_adj_cd[index];
                    hold_clm_card_col_3 = hold_clm_card_col[index];
                    hold_clm_amt_due_3 = hold_clm_amt_due[index];
                   // hold_desc_3 = hold_desc[index];
                    Display("scr-dis-clmdet-3.");
                    break;
                case 4:
                case 12:
                case 20:
                case 28:
                case 36:
                case 44:
                case 52:
                case 60:
                case 68:
                case 76:
                case 84:
                case 92:
                case 100:
                    hold_clm_id_4 = hold_clm_id[index];
                    hold_clm_clm_nbr_4 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_4 = hold_clm_cyc[index];
                    hold_clm_per_end_date_4 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_4 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_4 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_4 = hold_clm_oma_suff[index];
                    hold_clm_svc_4 = hold_clm_svc[index];
                    hold_clm_agent_4 = hold_clm_agent[index];
                    hold_clm_adj_cd_4 = hold_clm_adj_cd[index];
                    hold_clm_card_col_4 = hold_clm_card_col[index];
                    hold_clm_amt_due_4 = hold_clm_amt_due[index];
                    //hold_desc_4 = hold_desc[index];
                    Display("scr-dis-clmdet-4.");
                    break;
                case 5:
                case 13:
                case 21:
                case 29:
                case 37:
                case 45:
                case 53:
                case 61:
                case 69:
                case 77:
                case 85:
                case 93:
                    hold_clm_id_5 = hold_clm_id[index];
                    hold_clm_clm_nbr_5 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_5 = hold_clm_cyc[index];
                    hold_clm_per_end_date_5 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_5 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_5 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_5 = hold_clm_oma_suff[index];
                    hold_clm_svc_5 = hold_clm_svc[index];
                    hold_clm_agent_5 = hold_clm_agent[index];
                    hold_clm_adj_cd_5 = hold_clm_adj_cd[index];
                    hold_clm_card_col_5 = hold_clm_card_col[index];
                    hold_clm_amt_due_5 = hold_clm_amt_due[index];
                    //hold_desc_5 = hold_desc[index];
                    Display("scr-dis-clmdet-5.");
                    break;
                case 6:
                case 14:
                case 22:
                case 30:
                case 38:
                case 46:
                case 54:
                case 62:
                case 70:
                case 78:
                case 86:
                case 94:
                    hold_clm_id_6 = hold_clm_id[index];
                    hold_clm_clm_nbr_6 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_6 = hold_clm_cyc[index];
                    hold_clm_per_end_date_6 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_6 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_6 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_6 = hold_clm_oma_suff[index];
                    hold_clm_svc_6 = hold_clm_svc[index];
                    hold_clm_agent_6 = hold_clm_agent[index];
                    hold_clm_adj_cd_6 = hold_clm_adj_cd[index];
                    hold_clm_card_col_6 = hold_clm_card_col[index];
                    hold_clm_amt_due_6 = hold_clm_amt_due[index];
                    Display("scr-dis-clmdet-6.");
                    break;
                case 7:
                case 15:
                case 23:
                case 31:
                case 39:
                case 47:
                case 55:
                case 63:
                case 71:
                case 79:
                case 87:
                case 95:
                    hold_clm_id_7 = hold_clm_id[index];
                    hold_clm_clm_nbr_7 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_7 = hold_clm_cyc[index];
                    hold_clm_per_end_date_7 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_7 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_7 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_7 = hold_clm_oma_suff[index];
                    hold_clm_svc_7 = hold_clm_svc[index];
                    hold_clm_agent_7 = hold_clm_agent[index];
                    hold_clm_adj_cd_7 = hold_clm_adj_cd[index];
                    hold_clm_card_col_7 = hold_clm_card_col[index];
                    hold_clm_amt_due_7 = hold_clm_amt_due[index];
                    Display("scr-dis-clmdet-7.");
                    break;
                case 8:
                case 16:
                case 24:
                case 32:
                case 40:
                case 48:
                case 56:
                case 64:
                case 72:
                case 80:
                case 88:
                case 96:
                    hold_clm_id_8 = hold_clm_id[index];
                    hold_clm_clm_nbr_8 = hold_clm_clm_nbr[index];
                    hold_clm_cyc_8 = hold_clm_cyc[index];
                    hold_clm_per_end_date_8 = Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_per_end_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_svc_date_8 = Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(0, 4) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(4, 2) + "/" + Util.Str(hold_clm_svc_date[index]).PadLeft(8, '0').Substring(6, 2);
                    hold_clm_oma_cd_8 = hold_clm_oma_cd[index];
                    hold_clm_oma_suff_8 = hold_clm_oma_suff[index];
                    hold_clm_svc_8 = hold_clm_svc[index];
                    hold_clm_agent_8 = hold_clm_agent[index];
                    hold_clm_adj_cd_8 = hold_clm_adj_cd[index];
                    hold_clm_card_col_8 = hold_clm_card_col[index];
                    hold_clm_amt_due_8 = hold_clm_amt_due[index];
                    Display("scr-dis-clmdet-8.");
                    break;
            }
        }

        private async Task display_scr_dis_desc(int index)
        {
            switch (index)
            {
                case 1:
                case 9:
                case 17:
                case 25:
                case 33:
                case 41:
                case 49:
                case 57:
                case 65:
                case 73:
                case 81:
                case 89:
                case 97:                    
                     hold_desc_1 = Util.Str(hold_desc[index]);
                    Display("scr-dis-desc.", "scr-dis-desc-1");
                    break;
                case 2:
                case 10:
                case 18:
                case 26:
                case 34:
                case 42:
                case 50:
                case 58:
                case 66:
                case 74:
                case 82:
                case 90:
                case 98:                   
                     hold_desc_2 = Util.Str(hold_desc[index]);
                    Display("scr-dis-desc.", "scr-dis-desc-2");
                    break;
                case 3:
                case 11:
                case 19:
                case 27:
                case 35:
                case 43:
                case 51:
                case 59:
                case 67:
                case 75:
                case 83:
                case 91:
                case 99:                    
                     hold_desc_3 = Util.Str(hold_desc[index]);
                    Display("scr-dis-desc.", "scr-dis-desc-3");
                    break;
                case 4:
                case 12:
                case 20:
                case 28:
                case 36:
                case 44:
                case 52:
                case 60:
                case 68:
                case 76:
                case 84:
                case 92:
                case 100:                    
                    hold_desc_4 = Util.Str(hold_desc[index]);
                    Display("scr-dis-desc.", "scr-dis-desc-4");
                    break;
                case 5:
                case 13:
                case 21:
                case 29:
                case 37:
                case 45:
                case 53:
                case 61:
                case 69:
                case 77:
                case 85:
                case 93:                    
                    hold_desc_5 = Util.Str(hold_desc[index]);
                    Display("scr-dis-desc.", "scr-dis-desc-5");
                    break;                
            }
        }

        #endregion

        private async Task Exit_Trakker()
        {
            if (IsExitForm) az0_10_end_of_job();
        }

        public async Task destroy_objects()
        {
            objBatctrl_rec = null;
            Batctrl_rec_Collection = null;

            objClaims_mstr_dtl_rec = null;
            Claims_mstr_dtl_rec_Collection = null;

            objPat_mstr_rec = null;
            Pat_mstr_rec_Collection = null;

            objF002_CLAIMS_MSTR_DTL_DESC = null;
            F002_CLAIMS_MSTR_DTL_DESC_Collection = null;
        }
    }
}

