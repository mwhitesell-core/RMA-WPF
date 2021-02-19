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
    public delegate void D004ExitCobolScreen();

    public class D004ViewModel : CommonFunctionScr
    {
        public event D004ExitCobolScreen ExitCobol;

        public D004ViewModel()
        {

        }

        #region FD Section
        // FD: batch_ctrl_file	Copy : f001_batch_control_file.fd
        private F001_BATCH_CONTROL_FILE objBatctrl_rec = null;
        private ObservableCollection<F001_BATCH_CONTROL_FILE> Batctrl_rec_Collection;

        private F001_BATCH_CONTROL_FILE objws_save_batctrl_rec = null;
        private F002_CLAIMS_MSTR_DTL objws_save_claims_header = null;


        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private Claims_mstr_rec objClaims_mstr_rec = null;
        private ObservableCollection<Claims_mstr_rec> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private F002_CLAIMS_MSTR_DTL objClaims_mstr_dtl_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claims_mstr_dtl_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        private F020C_DOC_CLINIC_NEXT_BATCH_NBR objF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
        private ObservableCollection<F020C_DOC_CLINIC_NEXT_BATCH_NBR> F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection;


        // FD: loc_mstr	Copy : f030_locations_mstr.fd
        private F030_LOCATIONS_MSTR objLoc_mstr_rec = null;
        private ObservableCollection<F030_LOCATIONS_MSTR> Loc_mstr_rec_Collection;

        // FD: oma_fee_mstr	Copy : f040_oma_fee_mstr.fd
        private F040_OMA_FEE_MSTR objFee_mstr_rec = null;
        private ObservableCollection<F040_OMA_FEE_MSTR> Fee_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_3.ws
        private CONSTANTS_MSTR_REC_3 objConstants_mstr_rec_3 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_3> Constants_mstr_rec_3_Collection;

        // FD: f040_dtl	Copy : f040_dtl.fd
        private F040_DTL objF040_dtl_rec = null;
        private ObservableCollection<F040_DTL> F040_dtl_rec_Collection;


        #endregion

        #region Properties
        private string _batctrl_adj_cd;
        public string batctrl_adj_cd
        {
            get
            {
                return _batctrl_adj_cd;
            }
            set
            {
                if (_batctrl_adj_cd != value)
                {
                    _batctrl_adj_cd = value;
                    _batctrl_adj_cd = _batctrl_adj_cd.ToUpper();
                    RaisePropertyChanged("batctrl_adj_cd");
                }
            }
        }

        private int _batctrl_agent_cd;
        public int batctrl_agent_cd
        {
            get
            {
                return _batctrl_agent_cd;
            }
            set
            {
                if (_batctrl_agent_cd != value)
                {
                    _batctrl_agent_cd = value;
                    RaisePropertyChanged("batctrl_agent_cd");
                }
            }
        }

        private decimal _batctrl_amt_act;
        public decimal batctrl_amt_act
        {
            get
            {
                return _batctrl_amt_act;
            }
            set
            {
                if (_batctrl_amt_act != value)
                {
                    _batctrl_amt_act = value;
                    RaisePropertyChanged("batctrl_amt_act");
                }
            }
        }

        private decimal _batctrl_amt_est;
        public decimal batctrl_amt_est
        {
            get
            {
                return _batctrl_amt_est;
            }
            set
            {
                if (_batctrl_amt_est != value)
                {
                    _batctrl_amt_est = value;
                    RaisePropertyChanged("batctrl_amt_est");
                }
            }
        }

        private int _batctrl_bat_clinic_nbr_1_2;
        public int batctrl_bat_clinic_nbr_1_2
        {
            get
            {
                return _batctrl_bat_clinic_nbr_1_2;
            }
            set
            {
                if (_batctrl_bat_clinic_nbr_1_2 != value)
                {
                    _batctrl_bat_clinic_nbr_1_2 = value;
                    RaisePropertyChanged("batctrl_bat_clinic_nbr_1_2");
                }
            }
        }

        private int _batctrl_bat_day;
        public int batctrl_bat_day
        {
            get
            {
                return _batctrl_bat_day;
            }
            set
            {
                if (_batctrl_bat_day != value)
                {
                    _batctrl_bat_day = value;
                    RaisePropertyChanged("batctrl_bat_day");
                }
            }
        }

        private string _batctrl_bat_doc_nbr;
        public string batctrl_bat_doc_nbr
        {
            get
            {
                return _batctrl_bat_doc_nbr;
            }
            set
            {
                if (_batctrl_bat_doc_nbr != value)
                {
                    _batctrl_bat_doc_nbr = value;
                    _batctrl_bat_doc_nbr = _batctrl_bat_doc_nbr.ToUpper();
                    RaisePropertyChanged("batctrl_bat_doc_nbr");
                }
            }
        }

        private int _batctrl_bat_week;
        public int batctrl_bat_week
        {
            get
            {
                return _batctrl_bat_week;
            }
            set
            {
                if (_batctrl_bat_week != value)
                {
                    _batctrl_bat_week = value;
                    RaisePropertyChanged("batctrl_bat_week");
                }
            }
        }

        private string _batctrl_batch_type;
        public string batctrl_batch_type
        {
            get
            {
                return _batctrl_batch_type;
            }
            set
            {
                if (_batctrl_batch_type != value)
                {
                    _batctrl_batch_type = value;
                    _batctrl_batch_type = _batctrl_batch_type.ToUpper();
                    RaisePropertyChanged("batctrl_batch_type");
                }
            }
        }

        private string _batctrl_clinic_nbr;
        public string batctrl_clinic_nbr
        {
            get
            {
                return _batctrl_clinic_nbr;
            }
            set
            {
                if (_batctrl_clinic_nbr != value)
                {
                    _batctrl_clinic_nbr = value;
                    _batctrl_clinic_nbr = _batctrl_clinic_nbr.ToUpper();
                    RaisePropertyChanged("batctrl_clinic_nbr");
                }
            }
        }

        private int _batctrl_cycle_nbr;
        public int batctrl_cycle_nbr
        {
            get
            {
                return _batctrl_cycle_nbr;
            }
            set
            {
                if (_batctrl_cycle_nbr != value)
                {
                    _batctrl_cycle_nbr = value;
                    RaisePropertyChanged("batctrl_cycle_nbr");
                }
            }
        }

        private int _batctrl_date_period_end_dd;
        public int batctrl_date_period_end_dd
        {
            get
            {
                return _batctrl_date_period_end_dd;
            }
            set
            {
                if (_batctrl_date_period_end_dd != value)
                {
                    _batctrl_date_period_end_dd = value;
                    RaisePropertyChanged("batctrl_date_period_end_dd");
                }
            }
        }

        private int _batctrl_date_period_end_mm;
        public int batctrl_date_period_end_mm
        {
            get
            {
                return _batctrl_date_period_end_mm;
            }
            set
            {
                if (_batctrl_date_period_end_mm != value)
                {
                    _batctrl_date_period_end_mm = value;
                    RaisePropertyChanged("batctrl_date_period_end_mm");
                }
            }
        }

        private int _batctrl_date_period_end_yy;
        public int batctrl_date_period_end_yy
        {
            get
            {
                return _batctrl_date_period_end_yy;
            }
            set
            {
                if (_batctrl_date_period_end_yy != value)
                {
                    _batctrl_date_period_end_yy = value;
                    RaisePropertyChanged("batctrl_date_period_end_yy");
                }
            }
        }

        private string _batctrl_loc;
        public string batctrl_loc
        {
            get
            {
                return _batctrl_loc;
            }
            set
            {
                if (_batctrl_loc != value)
                {
                    _batctrl_loc = value;
                    _batctrl_loc = _batctrl_loc.ToUpper();
                    RaisePropertyChanged("batctrl_loc");
                }
            }
        }

        private string _change_reply;
        public string change_reply
        {
            get
            {
                return _change_reply;
            }
            set
            {
                if (_change_reply != value)
                {
                    _change_reply = value;
                    _change_reply = _change_reply.ToUpper();
                    RaisePropertyChanged("change_reply");
                }
            }
        }

        private int _clmhdr_adj_cd_sub_type_ss;
        public int clmhdr_adj_cd_sub_type_ss
        {
            get
            {
                return _clmhdr_adj_cd_sub_type_ss;
            }
            set
            {
                if (_clmhdr_adj_cd_sub_type_ss != value)
                {
                    _clmhdr_adj_cd_sub_type_ss = value;
                    RaisePropertyChanged("clmhdr_adj_cd_sub_type_ss");
                }
            }
        }

        private string _clmhdr_adj_oma_cd;
        public string clmhdr_adj_oma_cd
        {
            get
            {
                return _clmhdr_adj_oma_cd;
            }
            set
            {
                if (_clmhdr_adj_oma_cd != value)
                {
                    _clmhdr_adj_oma_cd = value;
                    _clmhdr_adj_oma_cd = _clmhdr_adj_oma_cd.ToUpper();
                    RaisePropertyChanged("clmhdr_adj_oma_cd");
                }
            }
        }

        private string _clmhdr_adj_oma_suff;
        public string clmhdr_adj_oma_suff
        {
            get
            {
                return _clmhdr_adj_oma_suff;
            }
            set
            {
                if (_clmhdr_adj_oma_suff != value)
                {
                    _clmhdr_adj_oma_suff = value;
                    _clmhdr_adj_oma_suff = _clmhdr_adj_oma_suff.ToUpper();
                    RaisePropertyChanged("clmhdr_adj_oma_suff");
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

        private int _clmhdr_clinic_nbr_1_2;
        public int clmhdr_clinic_nbr_1_2
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
                    RaisePropertyChanged("clmhdr_clinic_nbr_1_2");
                }
            }
        }

        private int _clmhdr_day;
        public int clmhdr_day
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
                    RaisePropertyChanged("clmhdr_day");
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

        private int _clmhdr_orig_batch_nbr_1_2;
        public int clmhdr_orig_batch_nbr_1_2
        {
            get
            {
                return _clmhdr_orig_batch_nbr_1_2;
            }
            set
            {
                if (_clmhdr_orig_batch_nbr_1_2 != value)
                {
                    _clmhdr_orig_batch_nbr_1_2 = value;
                    RaisePropertyChanged("clmhdr_orig_batch_nbr_1_2");
                }
            }
        }

        private string _clmhdr_orig_batch_nbr_4_9;
        public string clmhdr_orig_batch_nbr_4_9
        {
            get
            {
                return _clmhdr_orig_batch_nbr_4_9;
            }
            set
            {
                if (_clmhdr_orig_batch_nbr_4_9 != value)
                {
                    _clmhdr_orig_batch_nbr_4_9 = value;
                    _clmhdr_orig_batch_nbr_4_9 = _clmhdr_orig_batch_nbr_4_9.ToUpper();
                    RaisePropertyChanged("clmhdr_orig_batch_nbr_4_9");
                }
            }
        }

        private int _clmhdr_orig_claim_nbr;
        public int clmhdr_orig_claim_nbr
        {
            get
            {
                return _clmhdr_orig_claim_nbr;
            }
            set
            {
                if (_clmhdr_orig_claim_nbr != value)
                {
                    _clmhdr_orig_claim_nbr = value;
                    RaisePropertyChanged("clmhdr_orig_claim_nbr");
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

        private int _clmhdr_week;
        public int clmhdr_week
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

        private int _ctr_del_batctrl_file;
        public int ctr_del_batctrl_file
        {
            get
            {
                return _ctr_del_batctrl_file;
            }
            set
            {
                if (_ctr_del_batctrl_file != value)
                {
                    _ctr_del_batctrl_file = value;
                    RaisePropertyChanged("ctr_del_batctrl_file");
                }
            }
        }

        private int _ctr_read_batctrl_file;
        public int ctr_read_batctrl_file
        {
            get
            {
                return _ctr_read_batctrl_file;
            }
            set
            {
                if (_ctr_read_batctrl_file != value)
                {
                    _ctr_read_batctrl_file = value;
                    RaisePropertyChanged("ctr_read_batctrl_file");
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

        private int _ctr_read_const_mstr;
        public int ctr_read_const_mstr
        {
            get
            {
                return _ctr_read_const_mstr;
            }
            set
            {
                if (_ctr_read_const_mstr != value)
                {
                    _ctr_read_const_mstr = value;
                    RaisePropertyChanged("ctr_read_const_mstr");
                }
            }
        }

        private int _ctr_read_doc_mstr;
        public int ctr_read_doc_mstr
        {
            get
            {
                return _ctr_read_doc_mstr;
            }
            set
            {
                if (_ctr_read_doc_mstr != value)
                {
                    _ctr_read_doc_mstr = value;
                    RaisePropertyChanged("ctr_read_doc_mstr");
                }
            }
        }

        private int _ctr_read_loc_mstr;
        public int ctr_read_loc_mstr
        {
            get
            {
                return _ctr_read_loc_mstr;
            }
            set
            {
                if (_ctr_read_loc_mstr != value)
                {
                    _ctr_read_loc_mstr = value;
                    RaisePropertyChanged("ctr_read_loc_mstr");
                }
            }
        }

        private int _ctr_rewrit_const_mstr;
        public int ctr_rewrit_const_mstr
        {
            get
            {
                return _ctr_rewrit_const_mstr;
            }
            set
            {
                if (_ctr_rewrit_const_mstr != value)
                {
                    _ctr_rewrit_const_mstr = value;
                    RaisePropertyChanged("ctr_rewrit_const_mstr");
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

        private string _doc_name;
        public string doc_name
        {
            get
            {
                return _doc_name;
            }
            set
            {
                if (_doc_name != value)
                {
                    _doc_name = value;
                    _doc_name = _doc_name.ToUpper();
                    RaisePropertyChanged("doc_name");
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

        private string _option;
        public string option
        {
            get
            {
                return _option;
            }
            set
            {
                if (_option != value)
                {
                    _option = value;
                    _option = _option.ToUpper();
                    RaisePropertyChanged("option");
                }
            }
        }

        private string _password_input;
        public string password_input
        {
            get
            {
                return _password_input;
            }
            set
            {
                if (_password_input != value)
                {
                    _password_input = value;
                    _password_input = _password_input.ToUpper();
                    RaisePropertyChanged("password_input");
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

        private decimal _ws_amt_tech;
        public decimal ws_amt_tech
        {
            get
            {
                return _ws_amt_tech;
            }
            set
            {
                if (_ws_amt_tech != value)
                {
                    _ws_amt_tech = value;
                    RaisePropertyChanged("ws_amt_tech");
                }
            }
        }

        private decimal _ws_batctrl_amt_diff;
        public decimal ws_batctrl_amt_diff
        {
            get
            {
                return _ws_batctrl_amt_diff;
            }
            set
            {
                if (_ws_batctrl_amt_diff != value)
                {
                    _ws_batctrl_amt_diff = value;
                    RaisePropertyChanged("ws_batctrl_amt_diff");
                }
            }
        }

        private string _ws_doc_nbr;
        public string ws_doc_nbr
        {
            get
            {
                return _ws_doc_nbr;
            }
            set
            {
                if (_ws_doc_nbr != value)
                {
                    _ws_doc_nbr = value;
                    _ws_doc_nbr = _ws_doc_nbr.ToUpper();
                    RaisePropertyChanged("ws_doc_nbr");
                }
            }
        }

        private string _ws_doc_nbr_alpha;
        public string ws_doc_nbr_alpha
        {
            get
            {
                return _ws_doc_nbr_alpha;
            }
            set
            {
                if (_ws_doc_nbr_alpha != value)
                {
                    _ws_doc_nbr_alpha = value;
                    _ws_doc_nbr_alpha = _ws_doc_nbr_alpha.ToUpper();
                    RaisePropertyChanged("ws_doc_nbr_alpha");
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

        private decimal _ws_misc_code_perc;
        public decimal ws_misc_code_perc
        {
            get
            {
                return _ws_misc_code_perc;
            }
            set
            {
                if (_ws_misc_code_perc != value)
                {
                    _ws_misc_code_perc = value;
                    RaisePropertyChanged("ws_misc_code_perc");
                }
            }
        }

        private decimal _ws_orig_ohip;
        public decimal ws_orig_ohip
        {
            get
            {
                return _ws_orig_ohip;
            }
            set
            {
                if (_ws_orig_ohip != value)
                {
                    _ws_orig_ohip = value;
                    RaisePropertyChanged("ws_orig_ohip");
                }
            }
        }

        private decimal _ws_orig_oma;
        public decimal ws_orig_oma
        {
            get
            {
                return _ws_orig_oma;
            }
            set
            {
                if (_ws_orig_oma != value)
                {
                    _ws_orig_oma = value;
                    RaisePropertyChanged("ws_orig_oma");
                }
            }
        }

        private int _ws_orig_total_svc;
        public int ws_orig_total_svc
        {
            get
            {
                return _ws_orig_total_svc;
            }
            set
            {
                if (_ws_orig_total_svc != value)
                {
                    _ws_orig_total_svc = value;
                    RaisePropertyChanged("ws_orig_total_svc");
                }
            }
        }

        private decimal _ws_posted_ohip;
        public decimal ws_posted_ohip
        {
            get
            {
                return _ws_posted_ohip;
            }
            set
            {
                if (_ws_posted_ohip != value)
                {
                    _ws_posted_ohip = value;
                    RaisePropertyChanged("ws_posted_ohip");
                }
            }
        }

        private decimal _ws_posted_oma;
        public decimal ws_posted_oma
        {
            get
            {
                return _ws_posted_oma;
            }
            set
            {
                if (_ws_posted_oma != value)
                {
                    _ws_posted_oma = value;
                    RaisePropertyChanged("ws_posted_oma");
                }
            }
        }

        private decimal _ws_prof_ohip;
        public decimal ws_prof_ohip
        {
            get
            {
                return _ws_prof_ohip;
            }
            set
            {
                if (_ws_prof_ohip != value)
                {
                    _ws_prof_ohip = value;
                    RaisePropertyChanged("ws_prof_ohip");
                }
            }
        }

        private decimal _ws_prof_oma;
        public decimal ws_prof_oma
        {
            get
            {
                return _ws_prof_oma;
            }
            set
            {
                if (_ws_prof_oma != value)
                {
                    _ws_prof_oma = value;
                    RaisePropertyChanged("ws_prof_oma");
                }
            }
        }

        private string _space_stop;
        public string space_stop
        {
            get
            {
                return _space_stop;
            }
            set
            {
                if (_space_stop != value)
                {
                    _space_stop = value;
                    _space_stop = _space_stop.ToUpper();
                    RaisePropertyChanged("space_stop");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        //private string password_input;
        private string password = "RMA";
        private string password_special_privledges = "GCN";
        private string reply;
        //private string change_reply;
        private decimal ws_batctrl_amt_act;
        private int ws_svc_posted;
        private decimal ws_hold_posted_oma;
        private decimal ws_hold_50_perc;
        //private decimal ws_posted_oma;
        //private decimal ws_posted_ohip;
        //private decimal ws_amt_tech;
        private decimal abs_posted_oma;
        private decimal abs_posted_ohip;
        private decimal abs_amt_tech;
        //private decimal ws_prof_oma;
        //private decimal ws_prof_ohip;
        //private int ws_orig_total_svc;
        //private decimal ws_orig_oma;
        //private decimal ws_orig_ohip;
        //private decimal ws_batctrl_amt_diff;
        private decimal ws_batctrl_svc_diff;
        //private string ws_doc_nbr;
        //private string ws_doc_nbr_alpha;
        //private string ws_file_err_msg = "";
        private string ws_flag_ok_to_adjust;
        private string ws_i_o_pat_ind;
        private string ws_oma_cd;
        private string ws_loc;
        //private decimal ws_misc_code_perc;
        private string hold_week;
        private string hold_day;
        private string hold_adjusted_clms_sv_date;
        private string hold_adjusted_clms_de_date;
        private decimal temp;
        //private string confirm_space = space;
        private string ws_save_batctrl_rec;
        private string feedback_oma_fee_mstr;
        private string ws_save_batctrl_key;
        private string ws_save_batctrl_feedback;
        private string ws_save_claims_header;
        private string ws_save_claims_feedback;

        private string ws_date_grp;
        private int ws_yy;
        private int ws_mm;
        private int ws_dd;
        private int ss;
        private int ss_clmhdr;
        private int ss_clmdtl_desc;
        private int ss_conseq_dd;
        private int ss_det_nbr;
        private int ss_ind;
        private int ss_max_nbr_locs_in_doc_rec = 30;
        private int ss_max_nbr_of_desc_rec_allow = 5;
        private string feedback_batctrl_file;
        private string feedback_claims_mstr;
        private string feedback_doc_mstr;
        private string feedback_loc_mstr;
        private string feedback_oma_mstr;
        private string feedback_iconst_mstr;
        private string eof_filename_here = "N";
        //private string status_common;
        private string status_batctrl_file = "0";
        private string status_cobol_batctrl_file = "0";
        private string status_claims_mstr = "0";
        private string status_cobol_claims_mstr = "0";
        private string status_doc_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_loc_mstr = "0";
        private string status_cobol_loc_mstr = "0";
        private string status_oma_mstr = "0";
        private string status_cobol_oma_mstr = "0";
        private string status_iconst_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_f040_dtl = "0";
        private int claims_occur;

        private string key_loc_mstr_grp;
        private string key_loc_nbr;

        private string key_oma_fee_mstr_grp;
        private string key_oma_cd;
        private int const_mstr_rec_nbr;
        //private string option;
        private string new_batch = "1";
        private string old_batch = "2";
        private string stop_option = "*";
        //private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string invalid_ohip = "N";
        private string invalid_chart = "N";
        private string flag_err_data;
        private string err_data = "N";
        private string ok_data = "Y";
        private string flag_dummy_claim_id;
        private string dummy_claim_id_required = "Y";
        private string flag_eoj;
        private string eoj = "E";
        private string flag_dup_key_status;
        private string duplicate_key = "0100";

        private string counters_grp;
        //private int ctr_read_batctrl_file;
        //private int ctr_read_claims_mstr;
        //private int ctr_read_doc_mstr;
        //private int ctr_read_loc_mstr;
        private int ctr_read_oma_mstr;
        //private int ctr_read_const_mstr;
        //private int ctr_writ_batctrl_file;
        //private int ctr_writ_claims_mstr;
        private int ctr_rewrit_batctrl_file;
        private int ctr_rewrit_claims_mstr;
        //private int ctr_rewrit_const_mstr;
        //private int ctr_del_batctrl_file;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string[] err_msg = {"", "invalid reply",
                               "NO SUCH ADJUSTMENT BATCH EXISTS IN THE BATCH CONTROL FILE",
                               "invalid password",
                               "FATAL ERROR #1 !! -- LAST CLAIM IN BATCH NOT FOUND",
                               "invalid date",
                               "FATAL ERROR #2 !! - DETAIL REC FOUND BUT NOT HEADER REC",
                               "'M' AND 'R' TRANSACTIONS REQUIRE A VALID DOCTOR NBR",
                               "ZERO CLAIM NBR ALLOWED ONLY FOR TRANSACTION CODE 'M' OR 'R'",
                               "FATAL ERROR #3 !! -- BATCH'S DOCTOR NOT FOUND IN DOC MSTR",
                               "NO SUCH CLAIM NBR ON FILE",
                               "'A'DJUSTMENT BATCH TRANSACTION CODES ARE 'A', 'B', AND 'R'",
                               "'P'AYMENT BATCH TRANSACTION CODES ARE 'C', AND 'M'",
                               "ATTEMPT TO ADJUST CLAIM THAT HASN'T 'GONE TO OHIP' YET",
                               "BATCH TYPE MUST BE 'P'AYMENT , OR 'A'DJUSTMENT",
                               "INVALID WEEK NUMBER IN BATCH ID",
                               "INVALID DAY IN BATCH ID",
                               "NON-ZERO AMOUNT REQUIRED",
                               "FATAL ERROR #4 !! - MAX. OF 99 CLAIMS PER BATCH REACHED",
                               "BATCH ALREADY EXISTS",
                               "INVALID 2 DIGIT CLINIC IDENTIFIER",
                               "SERIOUS ERROR #5 !! - INVALID CLAIMS MSTR INDEX POINTER",
                               "CLAIM AGENT CODE = 'OHIP' -- BUT PATIENT'S OHIP # IS INVALID",
                               "NO CLAIMS ALLOWED - PATIENT OHIP STATUS = 'J2','J8', OR 'K1'",
                               "NO CLAIMS ALLOWED - PATIENT OHIP STATUS = K4,K5,K6,K7, OR K9",
                               "IN/OUT PATIENT INDICATOR MUST BE 'I' OR 'O'",
                               "ZERO PERCENTAGE FOUND FOR MISCELLANEOUS PAY CODE",
                               "SURNAME INPUT NOT = SURNAME OF PATIENT ON FILE",
                               "INVALID OMA CODE",
                               "FATAL ERROR #6 !! - INVALID WRITE CLAIMS HEADER WRITE #1",
                               "FATAL ERROR #7 !! - INVALID WRITE CLAIMS HEADER WRITE #2",
                               "FATAL ERROR #8 !! - INVALID WRITE CLAIMS DETAIL INDX #1",
                               "FATAL ERROR #9 !! -- INVALID WRITE CLAIMS DETAIL INDX #2",
                               "AGENT OF REC TO BE ADJUSTED DIFFERS FROM BATCH BEING ENTERED",
                               "FATAL ERROR #10 !! - ERROR RE-WRITING UPDATED CLAIM HEADER",
                               "FATAL ERROR #11 !! - ERROR IN WRITING TO BATCH CONTROL FILE",
                               "FATAL ERROR #12 ! - ERROR RE-WRITING ADJ. CLAIM'S BACTRL REC",
                               "FATAL ERROR #13 !! - ERROR IN DELETING BATCH CONTROL RECORD",
                               "MAXIMUM OF 99 ENTRIES HAVE BEEN INPUT FOR BATCH - SHUT DOWN",
                               "NEXT CLAIM NBR ALREADY EXISTS !! -- START NEW BATCH NBR",
                               "FATAL ERROR #14!! -- CAN'T READ ADJUSTED CLAIM'S HDR AGAIN",
                               "UNABLE TO ACCESS BATCH -- STATUS IS NOT UNBALANCED/BALANCED",
                               "FATAL ERROR !! - ERROR READING CONSTANTS MSTR RECORD 3",
                               "OMA VALUE SUPPLIED ALTERED BY OVER 50% OF ORIGINAL VALUE",
                               "OMA VALUE CAN NOT BE ZERO",
                               "TECH Portion exceeds both Adjustment/Original $ amount",
                               "Tech Portion exceeds either OMA/OHIP $ amount",
                               "Invalid Technical portion entered",
                               "BATCTRL Amt > 99999.99, Re-enter the adj in a new batch",
                               "Doctor has terminated within 6 months, please verify",
                               "Estimated batch amount not equal to Actual batch amount",
                               "Doctor has not assigned to the selected clinic nbr",
                               "Not valid for Miscellaneous Payment for oma/dept/doc  ",
                               "Doctor has terminated > 6 months, please verify"};
        private string error_messages_r_grp;
        //private string[] err_msg =  new string[54];
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
        private string def_agent_code;
        private string def_agent_ohip = "0";
        private string def_agent_in_pat_diag_billing = "1";
        private string def_agent_ohip_wcb = "2";
        private string def_agent_icu_direct_bill = "3";
        private string def_agent_ohip_not_valid = "4";
        private string def_agent_moh_reduction = "5";
        private string def_agent_bill_direct = "6";  //"6", "4"
        private string def_agent_misc_payments = "7";
        private string def_agent_alternate_funding = "8";
        private string def_agent_wcb = "9";
        private string def_agent_ifhp_direct = "x";
        private string def_agent_ontario_direct = "x";
        private string def_agent_foreign_direct = "x";
        private string def_agent_reciprocal = "x";
        private string def_agent_quebec_direct = "x";

        private string month_descs_and_max_days_mth_grp;
        private string mth_desc_max_days_grp;
        /*private string filler = '31  january031';
        private string filler = '29 february059';
        private string filler = '31    march090';
        private string filler = '30    april120';
        private string filler = '31      may151';
        private string filler = '30     june181';
        private string filler = '31     july212';
        private string filler = '31   august243';
        private string filler = '30SEPTEMBER273';
        private string filler = '31  october304';
        private string filler = '30 november334';
        private string filler = '31 december365'; */
        private string mth_desc_max_days_r_grp;
        private string[] mth_desc_max_days_occur = new string[13];
        private int[] max_nbr_days = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private string[] mth_desc = { "", "january", "february", "march", "april", "may", "june", "july", "august", "SEPTEMBER", "october", "november", "december" };
        private int[] nbr_julian_days_ytd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
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
        private string filler;

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
        private string clmhdr_doc_nbr;
        //private string clmhdr_week;
        //private string clmhdr_day;
        private string clmhdr_batch_nbr_r2_grp;
        //private string filler;
        private string clmhdr_batch_nbr_3_6;
        private int clmhdr_batch_nbr_7_9;
        //private int clmhdr_claim_nbr;
        private string clmhdr_zeroed_oma_suff_adj_grp;
        //private string clmhdr_adj_oma_cd;
        //private string clmhdr_adj_oma_suff;
        private int clmhdr_adj_adj_nbr;
        private int clmhdr_zeroed_area;
        private string clmhdr_batch_type;
        private string clmhdr_adj_cd_sub_type;
        //private int clmhdr_adj_cd_sub_type_ss;
        private string clmhdr_claim_source_cd;
        private int clmhdr_doc_nbr_ohip;
        private int clmhdr_doc_spec_cd;
        private int clmhdr_refer_doc_nbr;
        private int clmhdr_diag_cd;
        //private string clmhdr_loc;
        private string clmhdr_hosp;
        private string clmhdr_payroll;
        private int clmhdr_agent_cd;
        private string clmhdr_adj_cd;
        private string clmhdr_tape_submit_ind;
        private string clmhdr_i_o_pat_ind;
        private string clmhdr_pat_ohip_id_or_chart_grp;
        private string clmhdr_pat_key_type;
        private string clmhdr_pat_key_data_grp;
        private string clmhdr_pat_key_ohip;
        //private string filler;
        private string clmhdr_pat_acronym_grp;
        private string clmhdr_pat_acronym6;
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
        private string clmhdr_date_admit_yy;
        private string clmhdr_date_admit_yy_r_grp;
        private string clmhdr_date_admit_yy_12;
        private string clmhdr_date_admit_yy_34;
        private int clmhdr_date_admit_mm;
        private string clmhdr_date_admit_mm_r;
        private int clmhdr_date_admit_dd;
        private string clmhdr_date_admit_dd_r;
        private int clmhdr_date_admit_r;
        private string clmhdr_date_admit_r2_grp;
        private int clmhdr_date_admit_12;
        private int clmhdr_date_admit_38;
        private int clmhdr_doc_dept;
        private string clmhdr_date_cash_tape_payment;
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
        private decimal clmhdr_tot_claim_ar_ohip;
        private decimal clmhdr_manual_and_tape_paymnts;
        private string clmhdr_status_ohip;
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
        //private int clmhdr_orig_batch_nbr_1_2;
        //private string clmhdr_orig_batch_nbr_4_9;
        private string clmhdr_orig_batch_nbr_next_def_grp;
        //private int filler;
        private string clmhdr_orig_batch_nbr_4_6;
        private int clmhdr_orig_batch_nbr_7_8;
        private int clmhdr_orig_batch_nbr_9;
        //private int clmhdr_orig_claim_nbr;
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
        private long clmdtl_orig_complete_batch_nbr;
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

        private string clmdtl_b_key_type;
        private string clmdtl_b_data_grp;
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
        private string clmdtl_p_claims_mstr_grp;
        private string clmdtl_p_key_type;
        private string clmdtl_p_data_grp;
        private string clmdtl_p_batch_nbr_grp;
        private int clmdtl_p_clinic_nbr_1_2;
        private string clmdtl_p_doc_nbr;
        private int clmdtl_p_week;
        private int clmdtl_p_day;
        private int clmdtl_p_claim_nbr;
        private string clmdtl_p_oma_cd;
        private string clmdtl_p_oma_suff;
        private string clmdtl_p_adj_nbr;
        private string key_claims_mstr_grp;



        private string claims_mstr_hdr_rec_grp;
        private int clmrec_hdr_clinic_nbr_1_2;
        //10  filler pic x(08).
        private string clmrec_zeroed_oma_suff_adj;
        private int clmrec_zeroed_area;
        private string clmrec_hdr_batch_type;
        //10  filler pic x(15).
        private int clmrec_hdr_diag_cd;
        private string clmrec_hdr_loc;
        private string clmrec_hdr_hosp;
        private string clmrec_hdr_payroll;
        private int clmrec_hdr_agent_cd;
        //private string  filler pic x(2).
        private string clmrec_hdr_i_o_pat_ind;
        private string clmrec_hdr_ohip_id_or_chart;
        private string clmrec_hdr_pat_acronym;
        //10  filler pic x(19).

        private int clmrec_doc_dept_nbr;
        //10  filler pic x(25).
        private string clmrec_hdr_date_claim;
        private decimal clmrec_hdr_amt_tech_billed;
        private decimal clmrec_hdr_amt_tech_paid;
        private decimal clmrec_hdr_tot_claim_ar_oma;
        private decimal clmrec_hdr_tot_claim_ar_ohip;
        private decimal clmrec_hdr_manual_tape_pymnts;
        private string clmrec_hdr_status_ohip;
        //10  filler pic x(36).

        private string clmrec_hdr_b_key_type;
        private string clmrec_hdr_b_data_grp;
        private string clmrec_hdr_b_batch_num;
        private string clmrec_hdr_b_batch_nbr;
        private int clmrec_hdr_b_clinic_nbr_1_2;
        private string clmrec_hdr_b_doc_nbr;
        private string clmrec_hdr_b_doc_nbr_r;
        private string clmrec_hdr_b_doc_nbr_2_4;
        private string clmrec_hdr_b_batch_number_grp;
        private int clmrec_hdr_b_week;
        private int clmrec_hdr_b_day;
        private int clmrec_hdr_b_claim_nbr;
        private string clmrec_hdr_b_oma_cd;
        private string clmrec_hdr_b_oma_suff;
        private string clmrec_hdr_b_adj_nbr;
        private string clmrec_hdr_b_data_r;
        private string clmrec_hdr_b_pat_id;


        private string claims_mstr_dtl_rec_grp;
        //10  filler pic x(10).
        private string clmrec_dtl_oma_cd;
        //10  filler pic x(5).
        private int clmrec_dtl_agent_cd;
        private string clmrec_dtl_adj_cd;
        private int clmrec_dtl_nbr_serv;
        private string clmrec_dtl_sv_date;
        //10  clmrec-dtl-consec-dates occurs 3 times.
        private string[] clmrec_dtl_consec_dates_grp = new string[4];
        private int[] clmrec_dtl_sv_nbr = new int[4];
        //15  filler pic xx.        
        private decimal clmrec_dtl_amt_tech_billed;
        private decimal clmrec_dtl_fee_oma;
        private decimal clmrec_dtl_fee_ohip;
        //10  filler pic x(134).

        private string doc_nbr;
        private string endOfJob = "End of Job";

        private string batctrl_batch_nbr_grp;
        private string batctrl_date_period_end_grp;
        private int batctrl_doc_nbr_ohip;
        private int batctrl_nbr_claims_in_batch;
        private string clmhdr_pat_ohip_id_or_chart;

        private string batctrl_batch_nbr;
        //private int batctrl_bat_clinic_nbr_1_2;
        //private string batctrl_bat_doc_nbr;
        private string batctrl_bat_week_day_grp;
        //private int batctrl_bat_week;
        //private int batctrl_bat_day;
        private int batctrl_bat_week_day_r;
        private string key_batctrl_file_r;
        private string key_batctrl_file;
        //private string batctrl_batch_type;
        //private string batctrl_adj_cd;
        private string batctrl_adj_cd_sub_type;
        private int batctrl_last_claim_nbr;
        //private string batctrl_clinic_nbr;
        private string batctrl_clinic_nbr_1_2;
        private string batctrl_clinic_nbr_3_4;
        //private int batctrl_doc_nbr_ohip;
        private string batctrl_hosp;
        private string batctrl_payroll;
        //private string batctrl_loc;
        private string batctrl_loc1;
        private string batctrl_loc2_4;
        //private int batctrl_agent_cd;
        private string batctrl_i_o_pat_ind;
        private string batctrl_date_batch_entered;
        //private string batctrl_date_period_end_grp;
        //private string batctrl_date_period_end_yy;
        //private string batctrl_date_period_end_mm;
        //private string batctrl_date_period_end_dd;
        //private int batctrl_cycle_nbr;
        //private decimal batctrl_amt_est;
        //private decimal batctrl_amt_act;
        private int batctrl_svc_est;
        private int batctrl_svc_act;
        private string batctrl_ar_yy_mm;
        private decimal batctrl_calc_ar_due;
        private decimal batctrl_calc_tot_rev;
        private decimal batctrl_manual_pay_tot;
        private string batctrl_batch_status;
        //private int batctrl_nbr_claims_in_batch;


        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 1,Data1 = "D004A",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 25,Data1 = "ADJUSTMENT/PAYMENT BATCH DATA ENTRY",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-batch-control-data.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-old-or-new-batch-option.",Line = "03",Col = 29,Data1 = "1 -CREATE NEW BATCH",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-old-or-new-batch-option.",Line = "04",Col = 29,Data1 = "2 -CONTINUE EXISTING BATCH",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-old-or-new-batch-option.",Line = "06",Col = 36,Data1 = "OPTION -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-old-or-new-batch-option.",Line = "06",Col = 44,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "option",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-option"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-type.",Line = "07",Col = 1,Data1 = "BATCH TYPE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-type.",Line = "07",Col = 14,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "batctrl_batch_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-batch-type"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-nbr.",Line = "08",Col = 1,Data1 = "BATCH NUMBER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-nbr.",Line = "08",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_bat_clinic_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-clinic-nbr-1-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-nbr.",Line = "08",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "batctrl_bat_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-doc-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-nbr.",Line = "08",Col = 21,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_bat_week",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-week"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-batch-nbr.",Line = "08",Col = 23,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_bat_day",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-day"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 27,Data1 = "PERIOD END DATE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_date_period_end_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-period-ends-yy"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 45,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 46,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_date_period_end_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-period-ends-mm"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 48,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 49,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_date_period_end_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-period-ends-dd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 60,Data1 = "CYCLE NUMBER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batch-period-cycle.",Line = "08",Col = 72,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_cycle_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-cycle-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "13",Col = 1,Data1 = "CLINIC NUMBER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "13",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "XXXX",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "batctrl_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-clinic-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "15",Col = 1,Data1 = "TRANSACTION CODE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "15",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "batctrl_adj_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-adj-cd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "17",Col = 1,Data1 = "AGENT CODE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "17",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_agent_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-agent-cd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "19",Col = 1,Data1 = "LOCATION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-mask.",Line = "19",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "batctrl_loc",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-batctrl-loc"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-lit-batctrl-data.",Line = "11",Col = 41,Data1 = "- BATCH CONTROL INFORMATION -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-lit-batctrl-data.",Line = "13",Col = 31,Data1 = "ESTIMATED $ AMOUNT =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-lit-batctrl-data.",Line = "15",Col = 31,Data1 = "ACTUAL    $ AMOUNT =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-lit-batctrl-data.",Line = "15",Col = 62,Data1 = "OUT BY",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batctrl-data.",Line = "13",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_amt_est",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-amt-est"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batctrl-data.",Line = "15",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "batctrl_amt_act",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-amt-act"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-val-batctrl-data.",Line = "15",Col = 68,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_batctrl_amt_diff",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-amt-diff"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-change-verification.",Line = "22",Col = 29,Data1 = "CHANGE BATCH CONTROL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-change-verification.",Line = "22",Col = 46,Data1 = "INFORMATION (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-change-verification.",Line = "22",Col = 61,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "change_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-change-password.",Line = "22",Col = 69,Data1 = "PASSWORD",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-change-password.",Line = "22",Col = 78,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumericPassword,IsRequired = false,InputVariableName = "password_input",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 1,Data1 = "D004B",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 31,Data1 = "ADJUSTMENT/PAYMENT BATCH DATA ENTRY",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-claim-rec-data.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 1,Data1 = "CLAIM CONTROL -  CLAIM ID :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_orig_batch_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 23,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(6)",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_orig_batch_nbr_4_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 31,Data1 = "-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "03",Col = 32,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_orig_claim_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 1,Data1 = "TRANSACTION CODE :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 16,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "batctrl_adj_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-adj-cd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 25,Data1 = "LOCATION :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 34,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_loc",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clmhdr-loc"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 45,Data1 = "EXPLANATION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr.",Line = "05",Col = 56,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(9)",MaxLength = 9,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_reference",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reference"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-tit-1.",Line = "07",Col = 8,Data1 = "-- B A T C H  N U M B E R --",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-tit-1.",Line = "07",Col = 40,Data1 = "(ORIGINAL  VALUES  SHOWN  IN  BRACKETS)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-tit-1.",Line = "08",Col = 1,Data1 = "CLINIC   DOC#   WEEK   DAY  CLM# ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-tit-1.",Line = "08",Col = 28,Data1 = "OMA    SUFF  DOC#           OHIP AMOUNT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-tit-1.",Line = "08",Col = 64,Data1 = "OMA AMOUNT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 3,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_clinic_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-clinic-nbr-1-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 8,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_doc_nbr_alpha",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-doc-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_week",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-week"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 19,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_day",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-day"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 21,Data1 = "-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 23,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_claim_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-claim-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_adj_oma_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-oma-cd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "clmhdr_adj_oma_suff",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hdr-oma-suff"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 38,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xxx",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ws-doc-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 44,Data1 = "(",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_orig_total_svc",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 47,Data1 = ")",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 50,Data1 = "(",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_orig_ohip",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-orig-ohip"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 61,Data1 = ")",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 64,Data1 = "(",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_orig_oma",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-orig-oma"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "10",Col = 75,Data1 = ")",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "12",Col = 31,Data1 = "ADJ/PAYMENT ----:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "14",Col = 31,Data1 = "TECHNICAL ------:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-clmhdr-dtl-1.",Line = "15",Col = 31,Data1 = "PROFESSIONAL ---:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-doc-name.",Line = "11",Col = 8,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "doc_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-doc-name"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-clmhdr-dtl-2.",Line = "12",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "ws_posted_ohip",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ohip-posted"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-clmhdr-dtl-2.",Line = "12",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "ws_posted_oma",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-oma-posted"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-clmhdr-dtl-3.",Line = "14",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "ws_amt_tech",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-amt-tech"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-clmhdr-dtl-3.",Line = "15",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "ws_prof_ohip",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prof-ohip"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-disp-clmhdr-dtl-3.",Line = "15",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z(5)9.99-",MaxLength = 9,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "ws_prof_oma",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prof-oma"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-misc-pay-code-lit.",Line = "13",Col = 9,Data1 = "MISCELLANEOUS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-misc-pay-code-lit.",Line = "14",Col = 11,Data1 = "PAY CODE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-misc-pay-code.",Line = "15",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "clmhdr_adj_cd_sub_type_ss",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-misc-pay-code-perc.",Line = "17",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_misc_code_perc",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-misc-pay-code-perc.",Line = "17",Col = 20,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clear-misc-pay-code.",Line = "13",Col = 1,Data1 = "                        ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clear-misc-pay-code.",Line = "14",Col = 1,Data1 = "                        ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clear-misc-pay-code.",Line = "16",Col = 1,Data1 = "                        ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clear-misc-pay-code.",Line = "17",Col = 1,Data1 = "                        ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(42)",MaxLength = 42,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_file_err_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_common",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "wrn-msg-line.",Line = "24",Col = 4,Data1 = "WARNING - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "wrn-msg-line.",Line = "24",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen.",Line = "24",Col = 58,Data1 = "ACCEPT (Y/N/M/L) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen.",Line = "24",Col = 72,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 59,Data1 = "REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "# OF BATCH CONTROL READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_batctrl_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 20,Data1 = "# OF CLAIMS MASTER READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_claims_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "9",Col = 20,Data1 = "# OF DOCTOR MSTR   READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "9",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_doc_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 20,Data1 = "# OF LOCATION MSTR  READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_loc_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "11",Col = 20,Data1 = "# OF CONSTANTS MSTR READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "11",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_const_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "# OF BATCH CONTROL WRITES =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_writ_batctrl_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 20,Data1 = "# OF CLAIMS MASTER WRITES =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_writ_claims_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "14",Col = 20,Data1 = "# OF CONST. MSTR RE-WRITES =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "14",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rewrit_const_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "15",Col = 20,Data1 = "# OF BATCH CONTROL DELETES =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "15",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_del_batctrl_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM D004 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-stop.",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "space_stop",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_batctrl_mstr_file_section()
        {

            //     use after standard error procedure on batch-ctrl-file.;
        }

        private async Task err_batctrl_file()
        {

            status_common = status_batctrl_file;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING BATCH CONTROL FILE".;
        }

        private async Task err_claims_mstr_file_section()
        {

            //     use after standard error procedure on claims-mstr.;
        }

        private async Task err_claims_mstr()
        {

            status_common = status_claims_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
        }

        private async Task err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private async Task err_doc_mstr()
        {

            status_common = status_doc_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING DOCTOR MASTER".;
        }

        private async Task err_locations_mstr_file_section()
        {

            //     use after standard error procedure on loc-mstr.;
        }

        private async Task err_loc_mstr()
        {

            status_common = status_loc_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING LOCATIONS MASTER".;
        }

        private async Task err_oma_fee_mstr_file_section()
        {

            //     use after standard error procedure on oma-fee-mstr.;
        }

        private async Task err_oma_fee_mstr()
        {

            status_common = status_oma_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING OMA FEE MASTER".;
        }

        private async Task err_constants_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private async Task err_constants_mstr()
        {

            status_common = status_iconst_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {

        }

        private async Task main_line()
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
            await y2k_default_sysdate();
            await y2k_default_sysdate_exit();

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

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     open i-o	batch-ctrl-file;
            // 		claims-mstr.;
            //     open input	iconst-mstr;
            // 		doc-mstr;
            // 		loc-mstr;
            // 		f040-dtl;
            // 		oma-fee-mstr.;
        }

        private async Task initialize_objects()
        {
            objBatctrl_rec = null;
            objBatctrl_rec = new F001_BATCH_CONTROL_FILE();

            Batctrl_rec_Collection = null;
            Batctrl_rec_Collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

            objClaims_mstr_dtl_rec = null;
            objClaims_mstr_dtl_rec = new F002_CLAIMS_MSTR_DTL();

            Claims_mstr_dtl_rec_Collection = null;
            Claims_mstr_dtl_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            objLoc_mstr_rec = null;
            objLoc_mstr_rec = new F030_LOCATIONS_MSTR();

            Loc_mstr_rec_Collection = null;
            Loc_mstr_rec_Collection = new ObservableCollection<F030_LOCATIONS_MSTR>();

            objFee_mstr_rec = null;
            objFee_mstr_rec = new F040_OMA_FEE_MSTR();

            Fee_mstr_rec_Collection = null;
            Fee_mstr_rec_Collection = new ObservableCollection<F040_OMA_FEE_MSTR>();

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();

            Iconst_mstr_rec_Collection = null;
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objConstants_mstr_rec_3 = null;
            objConstants_mstr_rec_3 = new CONSTANTS_MSTR_REC_3();

            Constants_mstr_rec_3_Collection = null;
            Constants_mstr_rec_3_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_3>();
        }

        public async Task mainline()
        {
            await Exit_Trakker();
            try
            {

                _main_line:
                await main_line();
                await initialize_objects();

                //     perform aa0-batch-initialization		thru aa0-99-exit.;
                await aa0_batch_initialization();
                await aa0_10_acpt_old_new_batch_opt();
                await aa0_99_exit();

                // if not stop-option then                
                if (!option.Equals(stop_option))
                {
                    flag_eoj = "";
                    //            perform ab0-processing		thru ab0-99-exit;                    
                    // 	        until eoj;

                    do
                    {
                        string retvalue = await ab0_processing();
                        if (retvalue.Equals("ab0_99_exit"))
                        {
                            goto _ab0_99_exit;
                        }
                        _ab0_10_input_claim:
                        retvalue = await ab0_10_input_claim();
                        if (retvalue.Equals("ab0_99_exit"))
                        {
                            goto _ab0_99_exit;
                        }
                        retvalue = await ab0_50_acpt_details();
                        if (retvalue.Equals("ab0_10_input_claim"))
                        {
                            goto _ab0_10_input_claim;
                        }
                        retvalue = await ab0_60_acpt_verification();
                        if (retvalue.Equals("ab0_10_input_claim"))
                        {
                            goto _ab0_10_input_claim;
                        }
                        _ab0_99_exit:
                        await ab0_99_exit();
                    } while (!flag_eoj.Equals(eoj));

                    //            perform ac0-totals                   thru ac0-99-exit;     
                    string retval = await ac0_totals();
                    if (retval.Equals("ac0_99_exit"))
                    {
                        goto _ac0_99_exit;
                    }
                    await ac0_50();
                    _ac0_99_exit:
                    await ac0_99_exit();

                    //            go to 000-main-line.;                        
                    goto _main_line;                  
                }

                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_10();
                await az0_99_exit();


                //     stop run.;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    err_msg_comment = " Runtime error : " + e.Message.ToString();
                    Display("err-msg-line.");
                    Write_ErrorLog("D004", e.Message, e.StackTrace);
                }
            }
            finally
            {
                if (option.Equals(stop_option))
                {
                    if (ExitCobol != null)
                    {
                        ExitCobol();
                    }
                }
            }
        }

        private async Task aa0_batch_initialization()
        {
            await Exit_Trakker();

            //counters = 0;
            ctr_read_batctrl_file = 0;
            ctr_read_claims_mstr = 0;
            ctr_read_doc_mstr = 0;
            ctr_read_loc_mstr = 0;
            ctr_read_oma_mstr = 0;
            ctr_read_const_mstr = 0;

            ctr_writ_batctrl_file = 0;
            ctr_writ_claims_mstr = 0;

            ctr_rewrit_batctrl_file = 0;
            ctr_rewrit_claims_mstr = 0;
            ctr_rewrit_const_mstr = 0;
            ctr_del_batctrl_file = 0;

            //objBatctrl_rec.batctrl_rec = 0;
            objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
            ws_doc_nbr = "0";
            ws_doc_nbr_alpha = "000";

            //objBatctrl_rec.batctrl_batch_type = "";
            //objBatctrl_rec.batctrl_hosp = "";
            //objBatctrl_rec.batctrl_adj_cd = "";
            //objBatctrl_rec.batctrl_i_o_pat_ind = "";


            //claim_header_rec = "";
            await Initialize_ClmHdr_Record_ScreenVariables();

            //claim_detail_rec = "";
            await Initialize_Clmdtl_Record_ScreenVariables();

            clmhdr_claim_id_grp = "";

            clmhdr_adj_cd_sub_type_ss = 0;
            clmhdr_doc_nbr_ohip = 0;
            clmhdr_doc_spec_cd = 0;
            clmhdr_refer_doc_nbr = 0;
            clmhdr_diag_cd = 0;
            clmhdr_agent_cd = 0;
            clmhdr_date_admit_grp = "";
            clmhdr_adj_oma_cd = "";

            clmhdr_doc_dept = 0;
            clmhdr_curr_payment = 0;
            clmhdr_date_period_end_grp = "";

            clmhdr_cycle_nbr = 0;
            clmhdr_amt_tech_billed = 0;
            clmhdr_amt_tech_paid = 0;
            clmhdr_tot_claim_ar_oma = 0;
            clmhdr_tot_claim_ar_ohip = 0;
            clmhdr_manual_and_tape_paymnts = 0;
            clmhdr_orig_batch_id_grp = "";
            clmhdr_submit_date_grp = "";
            clmhdr_serv_date = 0;

            ws_svc_posted = 0;
            ws_posted_oma = 0;
            ws_posted_ohip = 0;
            ws_orig_total_svc = 0;
            ws_orig_oma = 0;
            ws_orig_ohip = 0;

            clmdtl_id_grp = "";
            clmdtl_agent_cd = 0;
            clmdtl_nbr_serv = 0;
            //clmdtl_sv_date = 0;
            clmdtl_consecutive_sv_date[1] = 0;
            clmdtl_consecutive_sv_date[2] = 0;
            clmdtl_consecutive_sv_date[3] = 0;
            clmdtl_amt_tech_billed = 0;
            clmdtl_fee_oma = 0;
            clmdtl_fee_ohip = 0;
            clmdtl_cycle_nbr = 0;
            clmdtl_diag_cd = 0;
            clmdtl_line_no = 0;
            clmdtl_orig_batch_id_grp = "";

        }

        private async Task aa0_10_acpt_old_new_batch_opt()
        {
            await Exit_Trakker();

            option = "";

            //     display scr-title-batch-control-data.;
            Display("scr-title-batch-control-data.");

            //     display scr-old-or-new-batch-option.;
            Display("scr-old-or-new-batch-option.");

            //     perform aa1-acpt-old-or-new-batch-opt	thru	aa1-99-exit.;
            await aa1_acpt_old_or_new_batch_opt();
            await aa1_99_exit();

            // if stop-option then;            
            if (option.Equals(stop_option))
            {
                // 	    go to aa0-99-exit.;
                await aa0_99_exit();
                return;
            }

            // if old-batch then            
            if (option.Equals(old_batch))
            {
                // 	   display scr-acpt-batch-nbr;
                Display("scr-acpt-batch-nbr.");
                // 	   accept  scr-acpt-batch-nbr;
                await Prompt("batctrl_bat_clinic_nbr_1_2");
                await Prompt("batctrl_bat_doc_nbr");
                await Prompt("batctrl_bat_week");
                await Prompt("batctrl_bat_day");

                batctrl_batch_nbr = Util.Str(batctrl_bat_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(batctrl_bat_doc_nbr).PadRight(3) + Util.Str(batctrl_bat_week).PadLeft(2, '0') + Util.Str(batctrl_bat_day);

                // 	   perform aa2-read-batctrl-file		thru	aa2-99-exit;
                await aa2_read_batctrl_file();
                await aa2_99_exit();

                // 	   if not-ok or (     batctrl-batch-type not = "P" and batctrl-batch-type not = "A") then            
                if (flag.Equals(not_ok) || Util.Str(batctrl_batch_type).ToUpper() != "P" && Util.Str(batctrl_batch_type).ToUpper() != "A")
                {
                    err_ind = 2;
                    // 	 perform za0-common-error		thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();

                    //  go to aa0-10-acpt-old-new-batch-opt;
                    await aa0_10_acpt_old_new_batch_opt();
                    return;
                }
                else
                {
                    flag = "Y";
                    // 	   perform aa5-verify-batch-status thru aa5-99-exit;
                    await aa5_verify_batch_status();
                    await aa5_99_exit();

                    // 	       if not-ok then            
                    if (flag.Equals(not_ok))
                    {
                        // 		      go to aa0-10-acpt-old-new-batch-opt;
                        await aa0_10_acpt_old_new_batch_opt();
                        return;
                    }
                    else
                    {
                        // 	         perform xa0-disp-batctrl-data  thru	xa0-99-exit;
                        await xa0_disp_batctrl_data();
                        await xa0_99_exit();

                        change_reply = "";
                        // 	         perform xb0-allow-change-of-estimates;
                        // 					        thru xb0-99-exit;
                        // 		              until  change-reply = "N";

                        do
                        {
                            await xb0_allow_change_of_estimates();
                            await xb0_99_exit();
                        } while (Util.Str(change_reply).ToUpper() != "N");

                        // 	         display scr-title-batch-control-data;
                        Display("scr-title-batch-control-data.");

                        ws_batctrl_amt_act = Util.NumDec(batctrl_amt_act);
                        // 	         if batctrl-last-claim-nbr = zero then
                        if (Util.NumInt(batctrl_last_claim_nbr) == 0)
                        {
                            // 		        next sentence;
                        }
                        else
                        {
                            // 		        perform aa3-disp-last-claim-in-batch thru	aa3-99-exit            
                            await aa3_disp_last_claim_in_batch();
                            await aa3_99_exit();
                        }
                    }
                }
            }
            else
            {
                err_ind = 0;
                // 	   perform aa4-acpt-new-batch-hdr-info	thru	aa4-99-exit;
                _aa4_acpt_new_batch_hdr_info:
                await aa4_acpt_new_batch_hdr_info();
                string retval = await aa4_10();
                if (retval.Equals("aa4_acpt_new_batch_hdr_info"))
                {
                    goto _aa4_acpt_new_batch_hdr_info;
                }
                await aa4_99_exit();

                // 	   if err-ind not = 0 then            
                if (err_ind != 0)
                {
                    // 	       go to aa0-10-acpt-old-new-batch-opt;
                    await aa0_10_acpt_old_new_batch_opt();
                    return;
                }
                else
                {
                    // 	      perform xb1-input-batctrl-est	thru	xb1-99-exit;
                    await xb1_input_batctrl_est();
                    await xb1_99_exit();

                    change_reply = "";
                    // 	      perform xb0-allow-change-of-estimates thru	xb0-99-exit;
                    // 		      until   change-reply = "N";
                    do
                    {
                        await xb0_allow_change_of_estimates();
                        await xb0_99_exit();
                    } while (Util.Str(change_reply).ToUpper() != "N");
                    //        objBatctrl_rec.batctrl_last_claim_nbr = 0;
                    batctrl_last_claim_nbr = 0;
                }
            }
        }

        private async Task aa0_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task aa1_acpt_old_or_new_batch_opt()
        {
            await Exit_Trakker();

            //     accept scr-old-or-new-batch-option.;
            Display("scr-old-or-new-batch-option.");
            await Prompt("option");

            // if old-batch or new-batch  or stop-option  then;            
            if (option.Equals(old_batch) || option.Equals(new_batch) || option.Equals(stop_option))
            {
                // 	  next sentence;
            }
            else
            {
                err_ind = 1;
                //  perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to aa1-acpt-old-or-new-batch-opt.;
                await aa1_acpt_old_or_new_batch_opt();
                return;
            }
        }

        private async Task aa1_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa2_read_batctrl_file()
        {
            await Exit_Trakker();

            //objBatctrl_rec.key_batctrl_file = objBatctrl_rec.batctrl_batch_nbr;

            //     read batch-ctrl-file  key is key-batctrl-file;
            // 	invalid key;
            //        flag = "N";
            // 		go to aa2-99-exit.;

            objBatctrl_rec = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = batctrl_batch_nbr
            }.Collection().FirstOrDefault();

            if (objBatctrl_rec == null)
            {
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                flag = "N";
                // go to aa2-99-exit.;
                await aa2_99_exit();
                return;
            }

            await assign_batchcontrol_to_screen_variables();

            flag = "Y";
            //     add  1					to	ctr-read-batctrl-file.;
            ctr_read_batctrl_file++;
        }

        private async Task aa2_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa3_disp_last_claim_in_batch()
        {
            await Exit_Trakker();

            clmhdr_batch_nbr = Util.Str(batctrl_batch_nbr);
            clmhdr_claim_nbr = Util.NumInt(batctrl_last_claim_nbr);
            clmhdr_zeroed_oma_suff_adj_grp = "";
            clmhdr_adj_oma_cd = "";
            clmhdr_adj_oma_suff = "";
            clmhdr_adj_adj_nbr = 0;

            //objClaims_mstr_dtl_rec.clmdtl_b_data = clmhdr_claim_id;
            clmhdr_zeroed_oma_suff_adj_grp = Util.Str(clmhdr_adj_oma_cd).PadRight(4) + Util.Str(clmhdr_adj_oma_suff).PadRight(1) + Util.Str(clmhdr_adj_adj_nbr).PadRight(1);
            clmhdr_claim_id_grp = Util.Str(clmhdr_batch_nbr).PadLeft(8, '0') + Util.Str(clmhdr_claim_nbr).PadLeft(2, '0') + clmhdr_zeroed_oma_suff_adj_grp;

            clmdtl_b_data_grp = clmhdr_claim_id_grp;

            clmdtl_b_batch_num = clmhdr_batch_nbr;
            clmdtl_b_batch_nbr = clmdtl_b_batch_num;
            clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(0, 2));
            clmdtl_b_doc_nbr = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(2, 3);
            clmdtl_b_doc_nbr_2_4 = clmdtl_b_doc_nbr;
            clmdtl_b_batch_number = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3);
            clmdtl_b_week = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 2));
            clmdtl_b_day = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(7, 1));
            clmdtl_b_batch_number_numeric = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3));

            clmdtl_b_claim_nbr = clmhdr_claim_nbr;
            clmdtl_b_oma_cd = clmhdr_adj_oma_cd;
            clmdtl_b_oma_suff = clmhdr_adj_oma_suff;
            clmdtl_b_adj_nbr = Util.Str(clmhdr_adj_adj_nbr);

            clmdtl_b_key_type = "B";

            //     perform xc0-read-claims-mstr	thru	xc0-99-exit.;
            await xc0_read_claims_mstr();
            await xc0_99_exit();

            //  if not-ok then            
            if (flag.Equals(not_ok))
            {
                err_ind = 4;
                //   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	   go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            ws_doc_nbr = clmhdr_doc_nbr;
            ws_doc_nbr_alpha = ws_doc_nbr;

            //     perform xd0-read-clmdtl		thru	xd0-99-exit.;
            await xd0_read_clmdtl();
            await xd0_99_exit();

            clmdtl_fee_ohip = clmrec_dtl_fee_ohip;
            ws_posted_ohip = clmdtl_fee_ohip;
            ws_orig_ohip = clmrec_dtl_fee_ohip; //clmdtl_fee_ohip;

            ws_posted_oma = clmrec_dtl_fee_oma; //clmdtl_fee_oma;
            ws_orig_oma = clmrec_dtl_fee_oma; //clmdtl_fee_oma;

            clmhdr_adj_oma_cd = clmhdr_adj_oma_cd.PadLeft(4, '0');
            clmhdr_adj_oma_suff = clmhdr_adj_oma_suff.PadRight(1, '0');

            //     display scr-acpt-clmhdr.;
            Display("scr-acpt-clmhdr.");

            //     display scr-acpt-clmhdr-tit-1.;
            Display("scr-acpt-clmhdr-tit-1.");

            //     display scr-acpt-clmhdr-dtl-1.;
            Display("scr-acpt-clmhdr-dtl-1.");

            //     display confirm.;
            Display("confirm.");

            //     stop " ".;
            Display("scr-stop.");
            await Prompt("space_stop");
            Display("blank-line-24.");
        }

        private async Task aa3_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa4_acpt_new_batch_hdr_info()
        {
            await Exit_Trakker();

            //  display scr-acpt-batch-type.;
            Display("scr-acpt-batch-type.");

            //     perform aa41-acpt-batch-type		thru	aa41-99-exit.;
            await aa41_acpt_batch_type();
            await aa41_99_exit();

            batctrl_batch_nbr = "0";
        }

        private async Task<string> aa4_10()
        {
            await Exit_Trakker();

            //     display scr-acpt-batch-nbr.;
            Display("scr-acpt-batch-nbr.");

            //     perform aa42-acpt-orig-batch-nbr		thru	aa42-99-exit.;
            await aa42_acpt_orig_batch_nbr();
            await aa42_99_exit();

            //     perform la0-acpt-verification		thru	la0-99-exit.;
            await la0_acpt_verification();
            await la0_99_exit();

            // if flag = "M" then
            if (Util.Str(flag).ToUpper() == "M")
            {
                // 	  go to aa4-acpt-new-batch-hdr-info;                
                return "aa4_acpt_new_batch_hdr_info";
            }
            // else if flag = "N" then            
            else if (Util.Str(flag).ToUpper() == "N")
            {
                err_ind = 99;
                // 	    go to aa4-99-exit;
                await aa4_99_exit();
                return "aa4_99_exit";
            }
            else
            {
                // 	    next sentence.;
            }

            batctrl_date_batch_entered = sys_date_grp;

            //     perform aa43-obtain-period-and-cycle	thru	aa43-99-exit.;
            await aa43_obtain_period_and_cycle();
            await aa43_99_exit();

            //     display scr-val-batch-period-cycle.;
            Display("scr-val-batch-period-cycle.");

            //     display scr-acpt-mask.;
            Display("scr-acpt-mask.");

            //     perform aa48-acpt-adj-cd			thru	aa48-99-exit.;
            await aa48_acpt_adj_cd();
            await aa48_99_exit();

            //     perform aa47-acpt-agent-cd			thru	aa47-99-exit.;
            await aa47_acpt_agent_cd();
            await aa47_99_exit();

            //     perform aa46-acpt-loc			thru	aa46-99-exit.;
            await aa46_acpt_loc();
            await aa46_99_exit();

            //objBatctrl_rec.BATCTRL_CALC_AR_DUE = 0;
            batctrl_calc_ar_due = 0;
            //objBatctrl_rec.BATCTRL_CALC_TOT_REV = 0;
            batctrl_calc_tot_rev = 0;
            //objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT = 0;
            batctrl_manual_pay_tot = 0;
            // objBatctrl_rec.BATCTRL_AMT_EST = 0;
            batctrl_amt_est = 0;
            // objBatctrl_rec.BATCTRL_AMT_ACT = 0;
            batctrl_amt_act = 0;
            ws_batctrl_amt_act = 0;
            //objBatctrl_rec.BATCTRL_SVC_EST = 0;
            batctrl_svc_est = 0;
            // objBatctrl_rec.BATCTRL_SVC_ACT = 0;
            batctrl_svc_act = 0;
            ws_batctrl_amt_diff = 0;
            ws_batctrl_svc_diff = 0;

            //     perform aa9-write-batctrl-file		thru	aa9-99-exit.;
            await aa9_write_batctrl_file();
            await aa9_99_exit();

            // if ok then            
            if (flag.Equals(ok))
            {
                ws_save_batctrl_key = batctrl_batch_nbr; //  key_batctrl_file;
            }
            else
            {
                err_ind = 19;
                //  perform za0-common-error		thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to aa4-99-exit.;                
                return "aa4_99_exit";
            }

            //     display scr-lit-batctrl-data.;
            Display("scr-lit-batctrl-data.");

            //     display scr-val-batctrl-data.;
            Display("scr-val-batctrl-data.");

            err_ind = 0;
            return string.Empty;
        }

        private async Task aa4_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa41_acpt_batch_type()
        {
            await Exit_Trakker();

            //     accept scr-batctrl-batch-type.;
            Display("scr-acpt-batch-type.", "scr-batctrl-batch-type");
            await Prompt("batctrl_batch_type");

            // if batctrl-batch-type =   "P" or "A"  then            
            if (Util.Str(batctrl_batch_type).ToUpper().Equals("P") || Util.Str(batctrl_batch_type).ToUpper().Equals("A"))
            {
                // 	  next sentence;
            }
            else
            {
                err_ind = 14;
                // 	perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	go to aa41-acpt-batch-type.;
                await aa41_acpt_batch_type();
                return;
            }
        }

        private async Task aa41_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa42_acpt_orig_batch_nbr()
        {
            await Exit_Trakker();

            //     accept scr-batctrl-clinic-nbr-1-2.;
            Display("scr-acpt-batch-nbr.", "scr-batctrl-clinic-nbr-1-2");
            await Prompt("batctrl_bat_clinic_nbr_1_2");

            flag = "Y";

            //   perform xj0-read-const-mstr			thru	xj0-99-exit.;
            await xj0_read_const_mstr();
            await xj0_99_exit();


            // if flag = "N" then            
            if (Util.Str(flag).ToUpper() == "N")
            {
                err_ind = 20;
                // 	  perform za0-common-error		thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to aa42-acpt-orig-batch-nbr.;
                await aa42_acpt_orig_batch_nbr();
                return;
            }

            batctrl_clinic_nbr = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR);

            //     accept  scr-batctrl-doc-nbr.;
            Display("scr-acpt-batch-nbr.", "scr-batctrl-doc-nbr");
            await Prompt("batctrl_bat_doc_nbr");

            //     display scr-batctrl-doc-nbr.;
            Display("scr-acpt-batch-nbr.", "scr-batctrl-doc-nbr");

            //     accept  scr-batctrl-week.;
            Display("scr-acpt-batch-nbr.", "scr-batctrl-week");
            await Prompt("batctrl_bat_week");

            //     accept  scr-batctrl-day.;
            Display("scr-acpt-batch-nbr.", "scr-batctrl-day");
            await Prompt("batctrl_bat_day");

            batctrl_batch_nbr = Util.Str(batctrl_bat_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(batctrl_bat_doc_nbr).PadRight(3) + Util.Str(batctrl_bat_week).PadLeft(2, '0') + Util.Str(batctrl_bat_day).PadLeft(1, '0');
        }

        private async Task aa42_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa43_obtain_period_and_cycle()
        {
            await Exit_Trakker();

            //objBatctrl_rec.BATCTRL_CYCLE_NBR = objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR;            
            batctrl_cycle_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
            //objBatctrl_rec.BATCTRL_DATE_PERIOD_END = Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY) + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM) + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            batctrl_date_period_end_grp = Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY.ToString()).PadLeft(4, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM.ToString()).PadLeft(2, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD.ToString()).PadLeft(2, '0');
            batctrl_date_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            batctrl_date_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            batctrl_date_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
        }

        private async Task aa43_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa46_acpt_loc()
        {
            await Exit_Trakker();

            // if   batctrl-adj-cd = "R" then            
            if (Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                batctrl_loc = "X999";
                // 	   display scr-batctrl-loc;
                Display("scr-acpt-mask.", "scr-batctrl-loc");
                // 	   accept scr-batctrl-loc;
                await Prompt("batctrl_loc");
            }
            // else if batctrl-adj-cd = "M" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "M")
            {
                batctrl_loc = "MISC";
                // 	    display scr-batctrl-loc;
                Display("scr-acpt-mask.", "scr-batctrl-loc");
            }
            else
            {
                batctrl_loc = "";
            }

            //     display scr-batctrl-loc.;
            Display("scr-acpt-mask.", "scr-batctrl-loc");
        }

        private async Task aa46_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa47_acpt_agent_cd()
        {
            await Exit_Trakker();

            //     accept  scr-batctrl-agent-cd.;
            Display("scr-acpt-mask.", "scr-batctrl-agent-cd");
            await Prompt("batctrl_agent_cd");
        }

        private async Task aa47_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa48_acpt_adj_cd()
        {
            await Exit_Trakker();

            //     accept scr-batctrl-adj-cd.;
            Display("scr-acpt-mask.", "scr-batctrl-adj-cd");
            await Prompt("batctrl_adj_cd");

            // if batctrl-batch-type = "A" then            
            if (Util.Str(batctrl_batch_type).ToUpper().Equals("A"))
            {
                // 	   if batctrl-adj-cd =   "A" or "B" or "R"  then           
                if (Util.Str(batctrl_adj_cd).ToUpper().Equals("A") || Util.Str(batctrl_adj_cd).ToUpper().Equals("B") || Util.Str(batctrl_adj_cd).ToUpper().Equals("R"))
                {
                    // 	      next sentence;
                }
                else
                {
                    err_ind = 11;
                    // 	 perform za0-common-error		thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	      go to aa48-acpt-adj-cd;
                    await aa48_acpt_adj_cd();
                    return;
                }
            }
            // else if batctrl-adj-cd =   "C"  or "M" 	then            
            else if (Util.Str(batctrl_adj_cd).ToUpper().Equals("C") || Util.Str(batctrl_adj_cd).ToUpper().Equals("M"))
            {
                // 	    next sentence;
            }
            else
            {
                err_ind = 12;
                // 	    perform za0-common-error		thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to aa48-acpt-adj-cd.;
                await aa48_acpt_adj_cd();
                return;
            }


            //  if  batctrl-adj-cd =   "A" or "B" or "C"  or "M"  or "R"  then
            if (Util.Str(batctrl_adj_cd).ToUpper().Equals("A") || Util.Str(batctrl_adj_cd).ToUpper().Equals("B") || Util.Str(batctrl_adj_cd).ToUpper().Equals("C")
                || Util.Str(batctrl_adj_cd).ToUpper().Equals("M") || Util.Str(batctrl_adj_cd).ToUpper().Equals("R"))
            {
                //   	next sentence;
            }
            else
            {
                err_ind = 6;
                //   perform za0-common-error		thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to aa48-acpt-adj-cd.;
                await aa48_acpt_adj_cd();
                return;
            }

            //  if batctrl-batch-type = "A" and batctrl-adj-cd = "B" then            
            if (Util.Str(batctrl_batch_type).ToUpper().Equals("A") || Util.Str(batctrl_adj_cd).ToUpper().Equals("B"))
            {
                batctrl_adj_cd_sub_type = "M";
            }
        }

        private async Task aa48_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa5_verify_batch_status()
        {
            await Exit_Trakker();

            //  if batctrl-batch-status > "1" then
            if (Util.NumInt(batctrl_batch_status) > 1)
            {
                err_ind = 41;
                //  perform za0-common-error		thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	   display scr-acpt-change-password;
                // 	   accept  scr-acpt-change-password;
                Display("scr-acpt-change-password.");
                await Prompt("password_input");

                // 	   if password-input = password-special-privledges then            
                if (password_input == password_special_privledges)
                {
                    flag = "Y";
                }
                else
                {
                    flag = "N";
                }
            }
            else
            {
                // 	  next sentence.;
            }
        }

        private async Task aa5_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task aa9_write_batctrl_file()
        {
            await Exit_Trakker();

            // move batctrl-batch-nbr			to	key-batctrl-file. 
            //objBatctrl_rec.key_batctrl_file = objBatctrl_rec.batctrl_batch_nbr;

            //  write  batctrl-rec;
            // 	invalid key;
            //        flag = "N";
            // 	    go to aa9-99-exit.;

            try
            {
                objBatctrl_rec = null;
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                await assign_variable_to_batctrl();
                objBatctrl_rec.RecordState = State.Added;
                objBatctrl_rec.Submit();
            }
            catch (Exception e)
            {
                flag = "N";
                // 	 go to aa9-99-exit.;
                await aa9_99_exit();
                return;
            }

            flag = "Y";
            //     add  1					to	ctr-writ-batctrl-file.;
            ctr_writ_batctrl_file++;
        }

        private async Task aa9_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task<string> ab0_processing()
        {
            await Exit_Trakker();

            //  perform ba0-preset-hdr-data-from-ctrl	thru	ba0-99-exit.;
            await ba0_preset_hdr_data_from_ctrl();
            await ba0_99_exit();


            ws_posted_ohip = 0;
            ws_posted_oma = 0;
            ws_amt_tech = 0;
            ws_prof_ohip = 0;
            ws_prof_oma = 0;

            // if batctrl-adj-cd = 'M' then
            if (Util.Str(batctrl_adj_cd).ToUpper().Equals("M"))
            {
                clmhdr_adj_cd_sub_type = "0";
            }

            // if batctrl-last-claim-nbr > 98 then
            if (Util.NumInt(batctrl_last_claim_nbr) > 98)
            {
                // 	   display scr-acpt-clmhdr;
                Display("scr-acpt-clmhdr.");
                err_ind = 38;
                //   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                flag_eoj = "E";
                // 	   go to ab0-99-exit.;                
                return "ab0_99_exit";
            }

            //     add  1;
            // 	 batctrl-last-claim-nbr		giving	batctrl-last-claim-nbr;
            // 						clmhdr-orig-claim-nbr.;

            clmhdr_orig_claim_nbr = batctrl_last_claim_nbr + 1;
            batctrl_last_claim_nbr++;

            clmhdr_batch_nbr = Util.Str(batctrl_batch_nbr);
            clmhdr_claim_nbr = Util.NumInt(batctrl_last_claim_nbr);
            clmhdr_zeroed_oma_suff_adj_grp = "";
            clmhdr_adj_oma_cd = "0000";
            clmhdr_adj_oma_suff = "0";
            clmhdr_adj_adj_nbr = 0;

            //clmdtl_b_data = clmhdr_claim_id;
            clmdtl_b_batch_num = clmhdr_batch_nbr;
            clmdtl_b_batch_nbr = clmdtl_b_batch_num;
            clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(0, 2));
            clmdtl_b_doc_nbr = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(2, 3);
            clmdtl_b_doc_nbr_2_4 = clmdtl_b_doc_nbr;
            clmdtl_b_batch_number = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3);
            clmdtl_b_week = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 2));
            clmdtl_b_day = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(7, 1));
            clmdtl_b_batch_number_numeric = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3));

            clmdtl_b_claim_nbr = clmhdr_claim_nbr;
            clmdtl_b_oma_cd = clmhdr_adj_oma_cd;
            clmdtl_b_oma_suff = clmhdr_adj_oma_suff;
            clmdtl_b_adj_nbr = Util.Str(clmhdr_adj_adj_nbr);

            clmdtl_b_key_type = "B";

            //  perform xe0-read-claims-mstr	thru	xe0-99-exit.;
            await xe0_read_claims_mstr();
            await xe0_99_exit();


            // if  ok then
            if (flag.Equals(ok))
            {
                // 	   perform ab4-subtract-1-from-claim-nbr	thru ab4-99-exit;
                await ab4_subtract_1_from_claim_nbr();
                await ab4_99_exit();

                // 	   perform ab5-ring-bell		thru	ab5-99-exit   5 times;
                for (int i = 1; i <= 5; i++)
                {
                    await ab5_ring_bell();
                    await ab5_99_exit();
                }

                err_ind = 39;
                //   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                flag_eoj = "E";
                //   	go to ab0-99-exit;                
                return "ab0_99_exit";
            }
            else
            {
                // 	display scr-title-claim-rec-data;
                Display("scr-title-claim-rec-data.");

                // 	display scr-acpt-clmhdr;
                Display("scr-acpt-clmhdr.");

                // 	display scr-acpt-clmhdr-tit-1.;
                Display("scr-acpt-clmhdr-tit-1.");
            }
            return string.Empty;
        }

        private async Task<string> ab0_10_input_claim()
        {
            await Exit_Trakker();

            //     perform ab1-acpt-claim-id			thru ab1-99-exit.;
            _ab1_acpt_claim_id:
            string retval = await ab1_acpt_claim_id();
            if (retval.Equals("ab1_99_exit"))
            {
                goto _ab1_99_exit;
            }
            retval = await ab1_50();
            if (retval.Equals("ab1_acpt_claim_id"))
            {
                goto _ab1_acpt_claim_id;
            }
            _ab1_99_exit:
            await ab1_99_exit();


            //  if eoj then      
            if (flag_eoj.Equals(eoj))
            {
                //  	perform ab4-subtract-1-from-claim-nbr	thru ab4-99-exit;
                await ab4_subtract_1_from_claim_nbr();
                await ab4_99_exit();

                // 	go to ab0-99-exit.;                
                return "ab0_99_exit";
            }

            //  if clmhdr-doc-nbr not = zero then;            
            if (!string.IsNullOrWhiteSpace(clmhdr_doc_nbr) && Util.Str(clmhdr_doc_nbr) != "000")   //Util.NumInt(clmhdr_doc_nbr) != 0)
            {
                clmdtl_b_key_type = "B";
                //clmdtl_b_data = clmhdr_claim_id;
                clmhdr_batch_nbr = Util.Str(clmhdr_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(clmhdr_doc_nbr).PadLeft(3, '0') + Util.Str(clmhdr_week).PadLeft(2,'0') + Util.Str(clmhdr_day);
                clmdtl_b_batch_num = clmhdr_batch_nbr;
                clmdtl_b_batch_nbr = clmdtl_b_batch_num;
                clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(0, 2));
                clmdtl_b_doc_nbr = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(2, 3);
                clmdtl_b_doc_nbr_2_4 = clmdtl_b_doc_nbr;
                clmdtl_b_batch_number = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3);
                clmdtl_b_week = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 2));
                clmdtl_b_day = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(7, 1));
                clmdtl_b_batch_number_numeric = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3));

                clmdtl_b_claim_nbr = clmhdr_claim_nbr;
                clmdtl_b_oma_cd = clmhdr_adj_oma_cd;
                clmdtl_b_oma_suff = clmhdr_adj_oma_suff;
                clmdtl_b_adj_nbr = Util.Str(clmhdr_adj_adj_nbr);

                // 	    perform xe0-read-claims-mstr		thru	xe0-99-exit;
                await xe0_read_claims_mstr();
                await xe0_99_exit();

                // 	    if not-ok then            
                if (flag.Equals(not_ok))
                {
                    err_ind = 10;
                    // 	 perform za0-common-error		thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();

                    // 	  go to ab0-10-input-claim;
                    await ab0_10_input_claim();
                    return string.Empty;
                }
                //  	else if   ( batctrl-adj-cd  = "C" and clmrec-hdr-agent-cd not = batctrl-agent-cd ) or (    batctrl-adj-cd      not = "C" and clmrec-dtl-agent-cd not = batctrl-agent-cd ) then            
                else if (
                    (Util.Str(batctrl_adj_cd).ToUpper() == "C" && clmrec_hdr_agent_cd != Util.NumInt(batctrl_agent_cd)) || (Util.Str(batctrl_adj_cd) != "C" && clmrec_dtl_agent_cd != Util.NumInt(batctrl_agent_cd))
                    )
                {
                    err_ind = 33;
                    //  perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    //   go to ab0-10-input-claim;
                    await ab0_10_input_claim();
                    return string.Empty;
                }
                // 	    else if batctrl-adj-cd = "C" then            
                else if (Util.Str(batctrl_adj_cd).ToUpper() == "C")
                {
                    ws_orig_ohip = clmrec_dtl_fee_ohip; 
                    ws_orig_oma = clmrec_dtl_fee_oma; 
                    ws_save_claims_header = await Assign_Claims_mstr_Rec_To_GroupName();  
                    ws_save_claims_feedback = feedback_claims_mstr;
                    ws_save_batctrl_key = Util.Str(batctrl_batch_nbr); //  key_batctrl_file;
                    // 		    display scr-orig-ohip scr-orig-oma;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-orig-ohip");
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-orig-oma");
                }
                else
                {
                    hold_adjusted_clms_sv_date = clmrec_dtl_sv_date;
                    ws_orig_ohip = clmrec_dtl_fee_ohip;
                    ws_orig_oma = clmrec_dtl_fee_oma;
                    //   display scr-orig-ohip scr-orig-oma;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-orig-ohip");
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-orig-oma");
                }
            }
            else
            {
                // 	next sentence.;
            }


            // if batctrl-adj-cd =   "M"  or "R" then            
            if (Util.Str(batctrl_adj_cd).ToUpper().Equals("M") || Util.Str(batctrl_adj_cd).ToUpper().Equals("R"))
            {
                // 	   next sentence;
            }
            else
            {
                // 	   perform da0-verify-ok-to-modify-claim 	thru	da0-99-exit;      //..
                retval = await da0_verify_ok_to_modify_claim();
                await da0_90_reset_batctrl();
                await da0_99_exit();

                // 	   if ws-flag-ok-to-adjust = "N" then            
                if (Util.Str(ws_flag_ok_to_adjust).ToUpper() == "N")
                {
                    // 	      go to ab0-10-input-claim;
                    await ab0_10_input_claim();
                    return string.Empty;
                }
                else
                {
                    // 	      perform fa0-obtain-clmhdr-data		thru	fa0-99-exit.;
                    await fa0_obtain_clmhdr_data();
                    await fa0_99_exit();

                }
            }
            return string.Empty;
        }

        private async Task<string> ab0_50_acpt_details()
        {
            await Exit_Trakker();

            //     perform ja0-acpt-clmhdr-detail			thru	ja0-99-exit.;  //..
            string retval = await ja0_acpt_clmhdr_detail();
            if (retval.Equals("ja0_99_exit"))
            {
                goto _ja0_99_exit;
            }
            await ja0_20_input_amt();
            retval = await ja0_90_display_oma();
            await ja0_95_acpt_tech_portion();
            _ja0_99_exit:
            await ja0_99_exit();

            //  if err-data then
            if (flag_err_data.Equals(err_data))
            {
                // 	go to ab0-10-input-claim.;                
                return "ab0_10_input_claim";
            }
            return string.Empty;
        }

        private async Task<string> ab0_60_acpt_verification()
        {
            await Exit_Trakker();

            //     perform la0-acpt-verification		thru	la0-99-exit.;
            await la0_acpt_verification();
            await la0_99_exit();

            // if flag = "L" and batctrl-adj-cd = "R" then
            if (flag == "L" && Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                //          accept scr-clmhdr-loc;
                Display("scr-acpt-clmhdr.", "scr-clmhdr-loc");
                await Prompt("clmhdr_loc");

                //     go to ab0-60-acpt-verification;
                await ab0_60_acpt_verification();
                return string.Empty;
            }
            // else if flag = "L" then            
            else if (flag == "L")
            {
                // 	    accept scr-reference;
                Display("scr-acpt-clmhdr.", "scr-reference");
                await Prompt("clmhdr_reference");

                // 	    go to ab0-60-acpt-verification;
                await ab0_60_acpt_verification();
                return string.Empty;
            }
            // else if flag = "M"  then            
            else if (flag == "M")
            {
                // 	    go to ab0-10-input-claim;                
                return "ab0_10_input_claim";
            }
            // else if flag = "N" then            
            else if (flag == "N")
            {
                // 	    display scr-reject-entry;
                Display("scr-reject-entry.");

                // 	    display confirm;
                Display("confirm.");

                // 	    stop " ";
                // 	    display blank-line-24;
                Display("blank-line-24.");

                // 	    subtract 1				from	batctrl-last-claim-nbr;
                // 						        giving	batctrl-last-claim-nbr;
                // 							            clmhdr-orig-claim-nbr.;

                batctrl_last_claim_nbr = Util.NumInt(batctrl_last_claim_nbr) - 1;
                clmhdr_orig_claim_nbr = Util.NumInt(batctrl_last_claim_nbr) - 1;

            }

            // if flag = "Y" then            
            if (flag == "Y")
            {
                //   	add ws-posted-ohip 			to ws-batctrl-amt-act;
                ws_batctrl_amt_act += ws_posted_ohip;

                //  	if  ws-batctrl-amt-act > 99999.99 then            
                if (ws_batctrl_amt_act > 99999.99M)
                {
                    // 	        perform ab4-subtract-1-from-claim-nbr thru ab4-99-exit;
                    await ab4_subtract_1_from_claim_nbr();
                    await ab4_99_exit();

                    // 	        perform ab5-ring-bell	thru	ab5-99-exit   5 times;
                    for (int i = 1; i <= 5; i++)
                    {
                        await ab5_ring_bell();
                        await ab5_99_exit();
                    }

                    err_ind = 48;
                    // 	  perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    flag_eoj = "E";
                    //  go to ab0-99-exit;                    
                    return "ab0_99_exit";
                }
                else
                {
                    // 	        perform ab3-create-claim-id		thru	ab3-99-exit;
                    string retval = await ab3_create_claim_id();
                    if (retval.Equals("ab3_99_exit"))
                    {
                        goto _ab3_99_exit;
                    }
                    _ab3_10_claim_nbr_loop:
                    retval = await ab3_10_claim_nbr_loop();
                    if (retval.Equals("ab3_99_exit"))
                    {
                        goto _ab3_99_exit;
                    }
                    retval = await ab3_20_try_again();
                    if (retval.Equals("ab3_10_claim_nbr_loop"))
                    {
                        goto _ab3_10_claim_nbr_loop;
                    }
                    _ab3_99_exit:
                    await ab3_99_exit();

                    // 	        perform ma0-write-clmhdr		thru	ma0-99-exit;
                    await ma0_write_clmhdr();
                    await ma0_99_exit();

                    // 	        perform ab2-preset-clmdtl-data	thru	ab2-99-exit;
                    await ab2_preset_clmdtl_data();
                    await ab2_99_exit();

                    // 	        perform na0-write-clmdtl		thru	na0-99-exit;
                    await na0_write_clmdtl();
                    await na0_99_exit();

                    // 	    perform pa0-update-adjusted-claim	thru	pa0-99-exit.;
                    await pa0_update_adjusted_claim();
                    await pa0_99_exit();
                }
            }
            return string.Empty;
        }

        private async Task ab0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task<string> ab1_acpt_claim_id()
        {
            await Exit_Trakker();

            flag_dummy_claim_id = "N";
            clmhdr_week = 0;
            clmhdr_day = 0;
            clmhdr_claim_nbr = 0;


            //     display scr-acpt-clmhdr-dtl-1.;
            //     accept scr-hdr-doc-nbr.;
            Display("scr-acpt-clmhdr-dtl-1.");
            await Prompt("ws_doc_nbr_alpha");

            // if ws-doc-nbr-alpha = "***"  then            
            if (ws_doc_nbr_alpha == "***")
            {
                flag_eoj = "E";
                // 	go to ab1-99-exit;                
                return "ab1_99_exit";
            }
            else
            {
                // 	next sentence.;
            }

            ws_doc_nbr_alpha = ws_doc_nbr_alpha.PadLeft(3, '0');
            clmhdr_doc_nbr = ws_doc_nbr_alpha;

            // if clmhdr-doc-nbr not = zero then            
            if (!string.IsNullOrWhiteSpace(clmhdr_doc_nbr) && Util.Str(clmhdr_doc_nbr) != "0" && Util.Str(clmhdr_doc_nbr) != "00" && Util.Str(clmhdr_doc_nbr) != "000")
            {
                // 	  accept scr-hdr-week;
                Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-week");
                await Prompt("clmhdr_week");

                // 	  accept scr-hdr-day;                
                Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-day");
                await Prompt("clmhdr_day");

                // 	  accept scr-hdr-claim-nbr;
                Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-claim-nbr");
                await Prompt("clmhdr_claim_nbr");

                clmhdr_batch_nbr = Util.Str(clmhdr_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(clmhdr_doc_nbr).PadRight(3) + Util.Str(clmhdr_week).PadLeft(2,'0') + Util.Str(clmhdr_day).PadRight(1);

                // 	  if batctrl-adj-cd = "C" then            
                if (Util.Str(batctrl_adj_cd).ToUpper() == "C")
                {
                    // 	    go to ab1-99-exit;                    
                    return "ab1_99_exit";
                }
                else
                {
                    clmhdr_adj_oma_cd = "XXXX";
                    clmhdr_adj_oma_suff = "A";
                    // 	    display scr-hdr-oma-cd;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-cd");
                    // 	    display scr-hdr-oma-suff;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-suff");
                    // 	    accept scr-hdr-oma-cd;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-cd");
                    await Prompt("clmhdr_adj_oma_cd");
                    // 	    accept scr-hdr-oma-suff;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-suff");
                    await Prompt("clmhdr_adj_oma_suff");
                    // 	    go to ab1-99-exit;                    
                    return "ab1_99_exit";
                }
            }
            else
            {
                // 	next sentence.;
            }
            return string.Empty;
        }

        private async Task<string> ab1_50()
        {
            await Exit_Trakker();

            // if clmhdr-doc-nbr = zero and (batctrl-adj-cd = "M" or "R") then  
            if (Util.NumInt(clmhdr_doc_nbr) == 0 && (Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "R")
                )
            {
                flag_dummy_claim_id = "Y";
                clmhdr_adj_oma_cd = "MISC";
                clmhdr_adj_oma_suff = "";
                // 	  display scr-hdr-oma-cd;
                Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-cd");

                // 	  display scr-hdr-oma-suff;
                Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-suff");

                // 	  if batctrl-adj-cd = "M" or "R" then 
                if (Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "R")
                {
                    // 	     accept scr-hdr-oma-cd;
                    Display("scr-acpt-clmhdr-dtl-1.", "scr-hdr-oma-cd");
                    await Prompt("clmhdr_adj_oma_cd");

                    // 	     if clmhdr-adj-oma-cd not = "MISC" then            
                    if (clmhdr_adj_oma_cd != "MISC")
                    {
                        //          objFee_mstr_rec.fee_oma_cd = clmhdr_adj_oma_cd;
                        objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(clmhdr_adj_oma_cd).PadRight(4).Substring(0, 1);
                        objFee_mstr_rec.FILLER_NUMERIC = Util.Str(clmhdr_adj_oma_cd).PadRight(4).Substring(1, 3);
                        // 		    perform xh0-read-oma-fee-mstr	thru xh0-99-exit;
                        await xh0_read_oma_fee_mstr();
                        await xh0_99_exit();
                        // 		    if not-ok then            
                        if (flag.Equals(not_ok))
                        {
                            err_ind = 28;
                            //    perform za0-common-error	thru za0-99-exit;
                            await za0_common_error();
                            await za0_99_exit();
                            clmhdr_adj_oma_cd = "";
                            // 	    go to ab1-50;
                            await ab1_50();
                            return string.Empty;
                        }
                        else
                        {
                            // 		       next sentence;
                        }
                    }
                    else
                    {
                        // 		  next sentence;
                    }
                }
                else
                {
                    // 	    next sentence;
                }
            }
            else
            {
                err_ind = 8;
                // 	 perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	 go to ab1-acpt-claim-id.;                
                return "ab1_acpt_claim_id";
            }

            // if batctrl-adj-cd = 'M' then            
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M")
            {
                //      objFee_mstr_rec.fee_oma_cd = clmhdr_adj_oma_cd;
                objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(clmhdr_adj_oma_cd).PadRight(4).Substring(0, 1);
                objFee_mstr_rec.FILLER_NUMERIC = Util.Str(clmhdr_adj_oma_cd).PadRight(4).Substring(1, 3);
                //   	perform xh0-read-oma-fee-mstr	thru xh0-99-exit;
                await xh0_read_oma_fee_mstr();
                await xh0_99_exit();

                // 		if not-ok then            
                if (flag.Equals(not_ok))
                {
                    err_ind = 28;
                    //   perform za0-common-error	thru za0-99-exit;
                    za0_common_error();
                    za0_99_exit();
                    clmhdr_adj_oma_cd = "";
                    //  go to ab1-50;
                    await ab1_50();
                    return string.Empty;
                }
                else
                {
                    // 		    next sentence;
                    //            display scr-clear-misc-pay-code.;
                    Display("scr-clear-misc-pay-code.");
                }
            }

            //  if batctrl-adj-cd = "M" then 
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M")
            {
                //    	perform ab6-acpt-misc-pay-code		thru ab6-99-exit.;
                await ab6_acpt_misc_pay_code();
                await ab6_99_exit();
            }
            return string.Empty;
        }

        private async Task ab1_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ab2_preset_clmdtl_data()
        {
            await Exit_Trakker();

            clmdtl_batch_nbr = clmhdr_batch_nbr;
            clmdtl_claim_nbr = clmhdr_claim_nbr;
            clmdtl_agent_cd = clmhdr_agent_cd;
            clmdtl_adj_cd = clmhdr_adj_cd;

            clmdtl_nbr_serv = ws_svc_posted;

            // if clmhdr-adj-cd =   "A" or "B"  then 
            if (Util.Str(clmhdr_adj_cd) == "A" || Util.Str(clmhdr_adj_cd) == "B")
            {
                clmdtl_sv_date_grp = hold_adjusted_clms_sv_date;
                clmdtl_sv_yy = Util.NumInt(Util.Str(clmdtl_sv_date_grp).PadRight(8).Substring(0, 4));
                clmdtl_sv_mm = Util.NumInt(Util.Str(clmdtl_sv_date_grp).PadRight(8).Substring(4, 2));
                clmdtl_sv_dd = Util.NumInt(Util.Str(clmdtl_sv_date_grp).PadRight(8).Substring(6, 2));
            }
            // else if clmhdr-adj-cd = "C" then
            else if (clmhdr_adj_cd == "C")
            {
                clmdtl_sv_date_grp = hold_adjusted_clms_de_date;
                clmdtl_sv_yy = Util.NumInt(Util.Str(clmdtl_sv_date_grp).PadRight(8).Substring(0, 4));
                clmdtl_sv_mm = Util.NumInt(Util.Str(clmdtl_sv_date_grp).PadRight(8).Substring(4, 2));
                clmdtl_sv_dd = Util.NumInt(Util.Str(clmdtl_sv_date_grp).PadRight(8).Substring(6, 2));
            }
            else
            {
                clmdtl_sv_yy = sys_yy;
                clmdtl_sv_mm = sys_mm;
                clmdtl_sv_dd = sys_dd;
            }

            clmdtl_consecutive_dates[1] = "0";
            clmdtl_consecutive_dates[2] = "0";
            clmdtl_consecutive_dates[3] = "0";

            clmdtl_fee_oma = ws_posted_oma;

            clmhdr_date_period_end_grp = Util.Str(clmhdr_period_end_yy).PadLeft(4, '0') + Util.Str(clmhdr_period_end_mm).PadLeft(2, '0') + Util.Str(clmhdr_period_end_dd).PadLeft(2, '0');
            clmdtl_date_period_end = clmhdr_date_period_end_grp;
            clmdtl_cycle_nbr = clmhdr_cycle_nbr;

            clmhdr_orig_batch_nbr_grp = Util.Str(clmhdr_orig_batch_nbr_1_2).PadLeft(2, '0') + Util.Str(clmhdr_orig_batch_nbr_4_9).PadRight(6);
            clmhdr_orig_batch_id_grp = clmhdr_orig_batch_nbr_grp + Util.Str(clmhdr_orig_claim_nbr).PadLeft(2, '0');

            clmdtl_orig_batch_id_grp = clmhdr_orig_batch_id_grp;
            clmdtl_orig_batch_nbr = Util.Str(clmdtl_orig_batch_id_grp).PadRight(10).Substring(0, 8);
            clmdtl_orig_batch_nbr_r_grp = clmdtl_orig_batch_nbr;
            clmdtl_orig_batch_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_orig_batch_nbr_r_grp).PadRight(8).Substring(0, 2));
            clmdtl_orig_batch_nbr_4_9 = Util.Str(clmdtl_orig_batch_nbr_r_grp).PadRight(8).Substring(2, 6);

            clmdtl_orig_claim_nbr_in_batch = Util.NumInt(Util.Str(clmdtl_orig_batch_id_grp).PadRight(10).Substring(8, 2));

            clmdtl_orig_batch_id_r_grp = clmdtl_orig_batch_id_grp;
            clmdtl_orig_complete_batch_nbr = Util.NumLongInt(clmdtl_orig_batch_id_r_grp);
            clmdtl_orig_complete_batch_n_r_grp = Util.Str(clmdtl_orig_complete_batch_nbr);
            clmdtl_orig_clinic_number = Util.NumInt(Util.Str(clmdtl_orig_complete_batch_n_r_grp).PadRight(10).Substring(0, 2));
            clmdtl_orig_doc_number = Util.Str(clmdtl_orig_complete_batch_n_r_grp).PadRight(10).Substring(2, 3);
            clmdtl_orig_batch_number = Util.NumInt(Util.Str(clmdtl_orig_complete_batch_n_r_grp).PadRight(10).Substring(5, 3));
            clmdtl_orig_claim_number = Util.NumInt(Util.Str(clmdtl_orig_complete_batch_n_r_grp).PadRight(10).Substring(8, 2));
        }

        private async Task ab2_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task<string> ab3_create_claim_id()
        {
            await Exit_Trakker();

            // if dummy-claim-id-required then 
            if (flag_dummy_claim_id.Equals(dummy_claim_id_required))
            {
                // 	  next sentence;
            }
            else
            {
                //	go to ab3-99-exit.;                
                return "ab3_99_exit";
            }

            clmhdr_batch_nbr_3_6 = ws_doc_nbr;
            clmhdr_batch_nbr_7_9 = Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(2, 3)); // batctrl_bat_doc_nbr;
            clmhdr_batch_nbr = Util.Str(clmhdr_batch_nbr).PadRight(8).Substring(0, 2) + Util.Str(clmhdr_batch_nbr_3_6) + Util.Str(clmhdr_batch_nbr_7_9.ToString()).PadRight(3,'0');
            clmhdr_claim_nbr = 01;
            //     go to ab3-99-exit.;            
            return "ab3_99_exit";

            // *--------------------code no longer used----------------
            // * (build dummy claim id that will not duplicate existing key)

            /* clmhdr_batch_nbr_3_6 = ws_doc_nbr;
            //     if batctrl-adj-cd = "M";
            //     then;
            //clmhdr_batch_nbr_7_9 = "156";
            //     else;
            //clmhdr_batch_nbr_7_9 = "999";
            clmhdr_claim_nbr = 1;
            //objClaims_mstr_dtl_rec.clmdtl_b_key_type = "B";
            //objClaims_mstr_dtl_rec.clmdtl_b_data = clmhdr_claim_id; */
        }

        private async Task<string> ab3_10_claim_nbr_loop()
        {
            await Exit_Trakker();

            //  read  claims-mstr;
            // 	   key is  key-claims-mstr;
            // 	   invalid key;
            //          clmhdr_claim_nbr = objClaims_mstr_dtl_rec.clmdtl_b_data;
            // 	     display scr-acpt-clmhdr-dtl-1;
            // 	     display confirm;
            // 	     stop " ";
            // 	     go to ab3-99-exit.;

            Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = clmdtl_b_key_type,
                WhereClmdtl_batch_nbr = clmdtl_b_batch_num,
                WhereClmdtl_claim_nbr = clmdtl_b_claim_nbr,
                WhereClmdtl_oma_cd = clmdtl_b_oma_cd,
                WhereClmdtl_oma_suff = clmdtl_b_oma_suff,
                WhereClmdtl_adj_nbr = Util.NumInt(clmdtl_b_adj_nbr)
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(20000, false);

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                clmhdr_claim_nbr = Util.NumInt(clmdtl_b_data_grp);
                // 	     display scr-acpt-clmhdr-dtl-1;
                Display("scr-acpt-clmhdr-dtl-1.");

                // 	     display confirm;
                Display("confirm.");

                // 	     stop " ";
                // 	     go to ab3-99-exit.;                
                return "ab3_99_exit";
            }

            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[0];
            return string.Empty;
        }

        private async Task<string> ab3_20_try_again()
        {
            await Exit_Trakker();

            // if clmdtl-b-claim-nbr = 99 then            
            if (clmdtl_b_claim_nbr == 99)
            {
                err_ind = 18;
                // 	  perform za0-common-error thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to az0-end-of-job;
                await az0_end_of_job();
                return string.Empty;
            }
            else
            {
                // 	 add  1			to clmdtl-b-claim-nbr;
                clmdtl_b_claim_nbr++;
                // 	 go to ab3-10-claim-nbr-loop.;                
                return "ab3_10_claim_nbr_loop";
            }
            return string.Empty;
        }

        private async Task ab3_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ab4_subtract_1_from_claim_nbr()
        {
            await Exit_Trakker();

            //     subtract 1				from	batctrl-last-claim-nbr;
            // 					giving	batctrl-last-claim-nbr;
            // 						clmhdr-orig-claim-nbr.;

            clmhdr_orig_claim_nbr = Util.NumInt(batctrl_last_claim_nbr) - 1;
            batctrl_last_claim_nbr = Util.NumInt(batctrl_last_claim_nbr) - 1;
        }

        private async Task ab4_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ab5_ring_bell()
        {
            await Exit_Trakker();

            //     display ring-bell.;
            Display("ring-bell.");
        }

        private async Task ab5_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ab6_acpt_misc_pay_code()
        {
            await Exit_Trakker();

            //     accept scr-ws-doc-nbr.;
            Display("scr-acpt-clmhdr-dtl-1.", "scr-ws-doc-nbr");
            await Prompt("ws_doc_nbr");

            // if ws-doc-nbr not = zero then;            
            if (!string.IsNullOrWhiteSpace(ws_doc_nbr) && (Util.Str(ws_doc_nbr) != "0" && Util.Str(ws_doc_nbr) != "00"  && Util.Str(ws_doc_nbr) != "000" ))
            {
                doc_nbr = ws_doc_nbr;
                // 	 perform xf0-read-doc-mstr	thru xf0-99-exit.;
                await xf0_read_doc_mstr();
                await xf0_99_exit();
            }
            //     display scr-doc-name.;
            Display("scr-disp-doc-name.", "scr-doc-name");


            F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection = new F020C_DOC_CLINIC_NEXT_BATCH_NBR
            {
                WhereDoc_nbr = objDoc_mstr_rec.DOC_NBR
            }.Collection();


            // If ok;
            if (Util.Str(flag).Equals(ok)
            //           and (     batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr;
                        && (Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2)) != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[0].DOC_CLINIC_NBR)
            //                and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-2;
                        && Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2)) != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[1].DOC_CLINIC_NBR)
            //                and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-3;
                        && Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2)) != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[2].DOC_CLINIC_NBR)
            //                and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-4;
                        && Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2)) != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[3].DOC_CLINIC_NBR)
            //                and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-5;
                        && Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2)) != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[4].DOC_CLINIC_NBR)
            //                and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-6;
                        && Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2)) != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[5].DOC_CLINIC_NBR)
            // 	      );
            )
            //      then;
            )
            {
                flag_err_data = "N";
                err_ind = 51;
                //     perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                //     	go to ab6-acpt-misc-pay-code.;
                await ab6_acpt_misc_pay_code();
                return;
            }

            // If ok and doc-date-fac-term not = zeroes  and doc-date-fac-term not = spaces and doc-date-fac-term < sys-date  then      
            if (Util.Str(flag).Equals(ok) && Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_YY) + Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_MM) + Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_DD) > 0 && Util.NumInt(Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_YY).PadLeft(4,'0') + Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_MM).PadLeft(2,'0') + Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_DD).PadLeft(2,'0')) < Util.NumInt(sys_date_grp))
            {
                flag_err_data = "N";
                ws_date_grp = Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_YY).PadLeft(4, '0') + Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_MM).PadLeft(2, '0') + Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_DD).PadLeft(2, '0');    //objDoc_mstr_rec.doc_date_fac_term;
                ws_yy = Util.NumInt(ws_date_grp.Substring(0, 4));
                ws_mm = Util.NumInt(ws_date_grp.Substring(4, 2));
                ws_dd = Util.NumInt(ws_date_grp.Substring(6, 2));
                //        if  ( (ws-yy  * 365) + (ws-mm  * 30) + ws-dd ) > (sys-yy * 365) + (sys-mm * 30) + sys-dd - 180 then 
                if (((ws_yy * 365) + (ws_mm * 30) + ws_dd) > (sys_yy * 365) + (sys_mm * 30) + sys_dd - 180)
                {
                    err_ind = 49;
                    //     	      perform za1-common-warning thru za1-99-exit;
                    await za1_common_warning();
                    await za1_99_exit();
                    //            if confirm-space = '!' then            
                    if (confirm_space == "!")
                    {
                        //     	         go to ab6-acpt-misc-pay-code;
                        await ab6_acpt_misc_pay_code();
                        return;
                    }
                    else
                    {
                        // 		          next sentence;
                    }
                }
                else
                {
                    err_ind = 53;
                    //             perform za0-common-error   thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    //             if confirm-space = '*' then            
                    if (confirm_space == "*")
                    {
                        // 	           	  display scr-acpt-change-password;
                        // 	     	      accept  scr-acpt-change-password;
                        Display("scr-acpt-change-password.");
                        await Prompt("password_input");

                        // 	     	      if password-input  =  password  or  password-special-privledges then            
                        if (password_input == password || password_input == password_special_privledges)
                        {
                            // 		            go to ab6-99-exit;
                            await ab6_99_exit();
                            return;
                        }
                        else
                        {
                            //     	            go to ab6-acpt-misc-pay-code;
                            await ab6_acpt_misc_pay_code();
                            return;
                        }
                    }
                    else
                    {
                        //     	    go to ab6-acpt-misc-pay-code.;
                        await ab6_acpt_misc_pay_code();
                        return;
                    }
                }
            }


            // if ws-doc-nbr = zero or not-ok then            
            if (string.IsNullOrWhiteSpace(ws_doc_nbr) || Util.Str(ws_doc_nbr) == "0" || Util.Str(ws_doc_nbr) == "00" ||  Util.Str(ws_doc_nbr) == "000" || Util.Str(flag).Equals(not_ok))
            {
                flag_err_data = "N";
                err_ind = 7;
                //      perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                //       go to ab6-acpt-misc-pay-code.;
                await ab6_acpt_misc_pay_code();
                return;
            }

            objF040_dtl_rec = new F040_DTL();

            // move clmhdr-adj-oma-cd 		to oma-cd. 
            objF040_dtl_rec.FEE_OMA_CD = clmhdr_adj_oma_cd;

            //move doc-dept           to dept-no.
            objF040_dtl_rec.DEPT_NBR = objDoc_mstr_rec.DOC_DEPT;

            //move ws-doc - nbr         to oma-doc - nbr.
            objF040_dtl_rec.DOC_NBR = ws_doc_nbr;


            // perform xi0-read-oma-dtl		thru xi0-99-exit.;
            await xi0_read_oma_dtl();
            await xi0_99_exit();

            // if ok and data-entry-flag not = 'V' then  
            if (flag.Equals(ok) && Util.Str(objF040_dtl_rec.DATA_ENTRY_FLAG) != "V")
            {
                flag_err_data = "N";
                err_ind = 52;
                //  	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                //     	go to ab6-acpt-misc-pay-code.;
                await ab6_acpt_misc_pay_code();
                return;
            }

            //     display scr-misc-pay-code-lit.;
            Display("scr-misc-pay-code-lit.");
            //     display scr-misc-pay-code.;
            Display("scr-misc-pay-code.");

            // if clmhdr-adj-cd-sub-type not = zero then           
            if (!string.IsNullOrWhiteSpace(clmhdr_adj_cd_sub_type) &&  Util.Str(clmhdr_adj_cd_sub_type) != "0")
            {
                //   perform ab61-access-const-mstr-rec-3 thru ab61-99-exit;
                await ab61_access_const_mstr_rec_3();
                await ab61_99_exit();

                //   	if const-misc-curr(clmhdr-adj-cd-sub-type-ss) = zero then            
                if (base.CONST_MISC_CURR(objConstants_mstr_rec_3, clmhdr_adj_cd_sub_type_ss) == 0)
                {
                    err_ind = 26;
                    // 	   perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	 go to ab6-acpt-misc-pay-code;
                    await ab6_acpt_misc_pay_code();
                    return;
                }
                else
                {
                    //   multiply const-misc-curr(clmhdr-adj-cd-sub-type-ss);
                    // 					by 100;
                    // 					giving ws-misc-code-perc;
                    ws_misc_code_perc = base.CONST_MISC_CURR(objConstants_mstr_rec_3, clmhdr_adj_cd_sub_type_ss);

                    // 	        display scr-misc-pay-code-perc;
                    Display("scr-misc-pay-code-perc.");
                    batctrl_adj_cd_sub_type = clmhdr_adj_cd_sub_type;
                }
            }
            else
            {
                ws_misc_code_perc = 0;
                // 	 display scr-misc-pay-code-perc.;
                Display("scr-misc-pay-code-perc.");
            }
        }

        private async Task ab6_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ab61_access_const_mstr_rec_3()
        {
            await Exit_Trakker();

            objConstants_mstr_rec_3.CONST_REC_NBR = 3;
            //     read iconst-mstr;
            // 	invalid key;
            //         err_ind = 42;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            objConstants_mstr_rec_3 = new CONSTANTS_MSTR_REC_3
            {
                WhereConst_rec_nbr = 3
            }.Collection().FirstOrDefault();

            if (objConstants_mstr_rec_3 == null)
            {
                objConstants_mstr_rec_3 = new CONSTANTS_MSTR_REC_3();
                err_ind = 42;
                // 	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }
        }

        private async Task ab61_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task<string> ac0_totals()
        {
            await Exit_Trakker();

            //  if batctrl-last-claim-nbr < 1 then            
            if (Util.NumInt(batctrl_last_claim_nbr) < 1)
            {
                //    objBatctrl_rec.key_batctrl_file = ws_save_batctrl_key;
                batctrl_batch_nbr = ws_save_batctrl_key;

                //    	perform az1-delete-batctrl-rec	thru az1-99-exit;
                await az1_delete_batctrl_rec();
                await az1_99_exit();

                // 	    if  ok then            
                if (flag.Equals(ok))
                {
                    // 	       go to ac0-99-exit;                    
                    return "ac0_99_exit";
                }
                else
                {
                    err_ind = 37;
                    // 	      perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	      go to ac0-99-exit;                    
                    return "ac0_99_exit";
                }
            }
            else
            {
                batctrl_nbr_claims_in_batch = batctrl_last_claim_nbr;
            }
            return string.Empty;
        }

        private async Task ac0_50()
        {
            await Exit_Trakker();

            //     perform xa0-disp-batctrl-data	  thru xa0-99-exit;
            await xa0_disp_batctrl_data();
            await xa0_99_exit();

            // if batctrl-amt-est not = batctrl-amt-act then            
            if (batctrl_amt_est != batctrl_amt_act)
            {
                err_ind = 50;
                //  perform za1-common-warning	thru za1-99-exit.;
                await za1_common_warning();
                await za1_99_exit();
            }

            change_reply = "Y";

            //     perform xb0-allow-change-of-estimates thru xb0-99-exit;
            // 			until    change-reply = "N".;

            do
            {
                await xb0_allow_change_of_estimates();
                await xb0_99_exit();
            } while (Util.Str(change_reply).ToUpper() != "N");

            // if batctrl-amt-est = batctrl-amt-act then            
            if (batctrl_amt_est == batctrl_amt_act)
            {
                batctrl_batch_status = "1";
            }
            else
            {
                batctrl_batch_status = "0";
            }

            //    objBatctrl_rec.key_batctrl_file = objBatctrl_rec.batctrl_batch_nbr;

            //  perform az2-rewrite-batctrl-rec	thru az2-99-exit.;
            await az2_rewrite_batctrl_rec();
            await az2_99_exit();

            //  if not-ok  then            
            if (flag.Equals(not_ok))
            {
                err_ind = 35;
                // 	   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
            }
            else
            {
                // 	    next sentence.;
            }

            //     accept  sys-time			from time.;
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
            //     display scr-closing-screen.;
            Display("scr-closing-screen.");

            //     display confirm.;
            Display("confirm.");
        }

        private async Task ac0_99_exit()
        {
            await Exit_Trakker();

            //    exit.;
        }

        private async Task az0_end_of_job()
        {
            await Exit_Trakker();
            await az0_10();
        }

        private async Task az0_10()
        {           
            //     display blank-screen.;
            Display("blank-screen.");

            //     close	batch-ctrl-file;
            // 		claims-mstr;
            // 		iconst-mstr;
            // 		doc-mstr;
            // 		loc-mstr;
            // 		f040-dtl;
            // 		oma-fee-mstr.;
            //     call program "$obj/menu".;
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private async Task az0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task az1_delete_batctrl_rec()
        {
            await Exit_Trakker();

            flag = "Y";
            //     delete    batch-ctrl-file;
            // 	invalid key;
            //         flag = "N";

            if (objBatctrl_rec.Delete() == false)
            {
                flag = "N";
            }

            //     add 1				to ctr-del-batctrl-file.;
            ctr_del_batctrl_file++;
        }

        private async Task az1_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task az2_rewrite_batctrl_rec()
        {
            await Exit_Trakker();

            //     rewrite    batctrl-rec;
            // 	   invalid key;
            //        flag = "N";
            // 	    go to az2-99-exit.;

            try
            {
                await assign_variable_to_batctrl();
                objBatctrl_rec.RecordState = State.Modified;
                objBatctrl_rec.Submit();
            }
            catch (Exception e)
            {
                flag = "N";
                //  go to az2-99-exit.;
                await az2_99_exit();
                return;
            }

            flag = "Y";
            //     add  1				to ctr-rewrit-batctrl-file.;
            ctr_rewrit_batctrl_file++;
        }

        private async Task az2_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ba0_preset_hdr_data_from_ctrl()
        {
            await Exit_Trakker();

            //claim_detail_rec = "";
            await Initialize_Clmdtl_Record_ScreenVariables();

            //clmdtl_id = 0;
            clmdtl_batch_nbr = "";
            clmdtl_claim_nbr = 0;
            clmdtl_oma_cd = "0";
            clmdtl_oma_suff = "";
            clmdtl_adj_nbr = 0;

            clmdtl_agent_cd = 0;
            clmdtl_nbr_serv = 0;
            clmdtl_sv_date_grp = "";
            clmdtl_sv_yy = 0;
            clmdtl_sv_mm = 0;
            clmdtl_sv_dd = 0;

            clmdtl_consecutive_sv_date[1] = 0;
            clmdtl_consecutive_sv_date[2] = 0;
            clmdtl_consecutive_sv_date[3] = 0;
            clmdtl_amt_tech_billed = 0;
            clmdtl_fee_oma = 0;
            clmdtl_fee_ohip = 0;
            clmdtl_cycle_nbr = 0;
            clmdtl_diag_cd = 0;
            clmdtl_line_no = 0;
            clmdtl_orig_batch_id_grp = "";
            clmdtl_orig_batch_nbr = "";
            clmdtl_orig_batch_nbr_r_grp = "";
            clmdtl_orig_batch_nbr_1_2 = 0;
            clmdtl_orig_batch_nbr_4_9 = "";
            clmdtl_orig_claim_nbr_in_batch = 0;

            hold_week = Util.Str(clmhdr_week);
            hold_day = Util.Str(clmhdr_day);

            //claim_header_rec = 0;
            await Initialize_ClmHdr_Record_ScreenVariables();

            ws_svc_posted = 0;
            ws_posted_oma = 0;
            ws_posted_ohip = 0;
            ws_orig_total_svc = 0;
            ws_orig_oma = 0;
            ws_orig_ohip = 0;

            clmhdr_reference = "";
            clmhdr_week = Util.NumInt(hold_week);
            clmhdr_day = Util.NumInt(hold_day);
            clmhdr_orig_batch_nbr_grp = Util.Str(batctrl_batch_nbr);
            clmhdr_orig_batch_nbr_1_2 = Util.NumInt(clmhdr_orig_batch_nbr_grp.PadRight(8).Substring(0, 2));
            clmhdr_orig_batch_nbr_4_9 = Util.Str(clmhdr_orig_batch_nbr_grp.PadRight(8).Substring(2, 6));

            clmhdr_zeroed_oma_suff_adj_grp = "";
            clmhdr_adj_oma_cd = "";
            clmhdr_adj_oma_suff = "";
            clmhdr_adj_adj_nbr = 0;

            clmhdr_batch_type = Util.Str(batctrl_batch_type);
            clmhdr_clinic_nbr_1_2 = Util.NumInt(Util.Str(batctrl_batch_nbr).PadRight(8).Substring(0, 2));  //batctrl_bat_clinic_nbr_1_2;
            clmhdr_loc = Util.Str(batctrl_loc);
            clmhdr_agent_cd = Util.NumInt(batctrl_agent_cd);
            clmhdr_adj_cd = Util.Str(batctrl_adj_cd);
            clmhdr_date_period_end_grp = Util.Str(batctrl_date_period_end_grp);
            clmhdr_period_end_yy = Util.NumInt(Util.Str(clmhdr_date_period_end_grp).PadRight(8).Substring(0, 4));
            clmhdr_period_end_mm = Util.NumInt(Util.Str(clmhdr_date_period_end_grp).PadRight(8).Substring(4, 2));
            clmhdr_period_end_dd = Util.NumInt(Util.Str(clmhdr_date_period_end_grp).PadRight(8).Substring(6, 2));

            clmhdr_cycle_nbr = Util.NumInt(batctrl_cycle_nbr);
            clmhdr_adj_cd_sub_type = Util.Str(batctrl_adj_cd_sub_type);
        }

        private async Task ba0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task<string> da0_verify_ok_to_modify_claim()
        {
            await Exit_Trakker();

            await assign_variable_to_batctrl();
            //ws_save_batctrl_rec = objBatctrl_rec.batctrl_rec;
            objws_save_batctrl_rec = objBatctrl_rec.ShallowCopyClone();
            ws_save_batctrl_feedback = feedback_batctrl_file;
            ws_save_batctrl_key = batctrl_batch_nbr; // key_batctrl_file;

            batctrl_batch_nbr = clmhdr_batch_nbr;

            //  read  batch-ctrl-file	key is key-batctrl-file;
            // 	     invalid key;
            //          ws_flag_ok_to_adjust = "Y";
            // 	    go to da0-90-reset-batctrl.;

            objBatctrl_rec = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = clmhdr_batch_nbr
            }.Collection().FirstOrDefault();

            if (objBatctrl_rec == null)
            {
                ws_flag_ok_to_adjust = "Y";
                // go to da0-90-reset-batctrl.;                
                return "da0_90_reset_batctrl";
            }

            await assign_batchcontrol_to_screen_variables();

            //  if batctrl-batch-status < 3 then           
            if (Util.NumInt(batctrl_batch_status) < 3)
            {
                err_ind = 13;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                ws_flag_ok_to_adjust = "N";
            }
            else
            {
                ws_flag_ok_to_adjust = "Y";
            }
            return string.Empty;
        }

        private async Task da0_90_reset_batctrl()
        {
            await Exit_Trakker();

            //objBatctrl_rec.batctrl_rec = ws_save_batctrl_rec;
            objBatctrl_rec = objws_save_batctrl_rec.ShallowCopyClone();
            await assign_batchcontrol_to_screen_variables();

            feedback_batctrl_file = Util.Str(ws_save_batctrl_feedback);

            //objBatctrl_rec.key_batctrl_file = ws_save_batctrl_key;
            batctrl_batch_nbr = Util.Str(ws_save_batctrl_key);

        }

        private async Task da0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task fa0_obtain_clmhdr_data()
        {
            await Exit_Trakker();

            clmdtl_b_oma_cd = "0";
            clmdtl_b_oma_suff = "0";
            clmdtl_b_adj_nbr = "0";

            // if batctrl-adj-cd not = "C" then   
            if (Util.Str(batctrl_adj_cd).ToUpper() != "C")
            {
                // 	   perform xe0-read-claims-mstr	thru xe0-99-exit;
                await xe0_read_claims_mstr(true);
                await xe0_99_exit();
                // 	   if not-ok then 
                if (flag.Equals(not_ok))
                {
                    err_ind = 6;
                    //     perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	 go to az0-end-of-job;
                    await az0_end_of_job();
                    return;
                }
                else
                {
                    ws_save_claims_feedback = feedback_claims_mstr;
                    //        ws_save_claims_header = objClaims_mstr_rec.claims_mstr_hdr_rec;
                    objws_save_claims_header = objClaims_mstr_dtl_rec.ShallowCopyClone();
                }
            }
            else
            {
                hold_adjusted_clms_de_date = clmrec_hdr_date_claim;
            }


            // if clmhdr-loc = zeros or spaces then 
            if (Util.NumInt(clmhdr_loc) == 0 || string.IsNullOrWhiteSpace(clmhdr_loc))
            {
                clmhdr_loc = clmrec_hdr_loc;
            }

            clmhdr_diag_cd = clmrec_hdr_diag_cd;
            clmhdr_hosp = clmrec_hdr_hosp;
            clmhdr_i_o_pat_ind = clmrec_hdr_i_o_pat_ind;

            clmdtl_p_batch_nbr_grp = Util.Str(clmdtl_p_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(clmdtl_p_doc_nbr).PadRight(3) + Util.Str(clmdtl_p_week).PadLeft(2, '0') + Util.Str(clmdtl_p_day).PadLeft(1, '0');
            clmdtl_p_data_grp = clmdtl_p_batch_nbr_grp + Util.Str(clmdtl_p_claim_nbr).PadLeft(2, '0') + Util.Str(clmdtl_p_oma_cd).PadLeft(4, '0') + Util.Str(clmdtl_p_oma_suff).PadRight(1) + Util.Str(clmdtl_p_adj_nbr).PadRight(1);
            clmdtl_p_claims_mstr_grp = clmdtl_p_key_type + clmdtl_p_data_grp;
            clmhdr_pat_ohip_id_or_chart_grp = clmdtl_p_claims_mstr_grp;

            //  clmhdr_pat_key_type = Util.Str(clmhdr_pat_ohip_id_or_chart_grp).PadRight(16).Substring(0, 1);
            clmhdr_pat_key_data_grp = Util.Str(clmhdr_pat_ohip_id_or_chart_grp).PadRight(16).Substring(1, 15);
            clmhdr_pat_key_ohip = Util.Str(clmhdr_pat_ohip_id_or_chart_grp).PadRight(16).Substring(1, 8);

            clmhdr_pat_key_type = "I";

            clmhdr_pat_acronym_grp = clmrec_hdr_pat_acronym;
            clmhdr_pat_acronym6 = Util.Str(clmhdr_pat_acronym_grp).PadRight(9).Substring(0, 6);
            clmhdr_pat_acronym3 = Util.Str(clmhdr_pat_acronym_grp).PadRight(9).Substring(6, 3);

            doc_nbr = clmhdr_doc_nbr;
            //  perform xf0-read-doc-mstr thru xf0-99-exit.;
            await xf0_read_doc_mstr();
            await xf0_99_exit();

            // if not-ok then
            if (flag.Equals(not_ok))
            {
                flag_err_data = "N";
                err_ind = 7;
                //  perform za0-common-error thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                clmhdr_doc_dept = clmrec_doc_dept_nbr;
            }
            else
            {
                // 	display scr-doc-name;
                Display("scr-disp-doc-name.", "scr-doc-name");
                clmhdr_doc_dept = Util.NumInt(objDoc_mstr_rec.DOC_DEPT);
            }

            // if clmrec-hdr-status-ohip = '00' then 
            if (clmrec_hdr_status_ohip == "00")
            {
                clmhdr_reference = "";
            }
            else
            {
                clmhdr_reference = clmrec_hdr_status_ohip;
            }

            //     display scr-reference.;
            Display("scr-acpt-clmhdr.", "scr-reference");
        }

        private async Task fa0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task<string> ja0_acpt_clmhdr_detail()
        {
            await Exit_Trakker();

            flag_err_data = "Y";
            //  display scr-clmhdr-loc.;
            Display("scr-acpt-clmhdr.", "scr-clmhdr-loc");

            // if clmhdr-doc-nbr not = zero then 
            if (!string.IsNullOrWhiteSpace(clmhdr_doc_nbr) &&  Util.Str(clmhdr_doc_nbr) != "000")
            {
                ws_doc_nbr = clmhdr_doc_nbr;
                // 	  display scr-ws-doc-nbr;
                Display("scr-acpt-clmhdr-dtl-1.", "scr-ws-doc-nbr");
                // 	  go to ja0-20-input-amt.;                
                return "ja0_20_input_amt";
            }

            // if batctrl-adj-cd = 'M' then            
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M")
            {
                //    go to ja0-20-input-amt.;                
                return "ja0_20_input_amt";
            }

            //     accept scr-ws-doc-nbr.;
            Display("scr-acpt-clmhdr-dtl-1.", "scr-ws-doc-nbr");
            await Prompt("ws_doc_nbr");

            // if ws-doc-nbr not = zero then;
            if (!string.IsNullOrWhiteSpace(ws_doc_nbr) && Util.Str(ws_doc_nbr) != "000")
            {
                doc_nbr = ws_doc_nbr;
                // 	perform xf0-read-doc-mstr	thru xf0-99-exit;
                await xf0_read_doc_mstr();
                await xf0_99_exit();

                // 	  if ok then  
                if (flag.Equals(ok))
                {
                    // 	     display scr-doc-name;
                    Display("scr-disp-doc-name.", "scr-doc-name");
                    // 	     go to ja0-20-input-amt.;                    
                    return "ja0_20_input_amt";
                }
            }

            flag_err_data = "N";
            err_ind = 7;

            //   perform za0-common-error		thru za0-99-exit.;
            await za0_common_error();
            await za0_99_exit();
            //   go to ja0-99-exit.;            
            return "ja0_99_exit";

            return string.Empty;
        }

        private async Task ja0_20_input_amt()
        {
            await Exit_Trakker();

            //     display scr-ohip-posted.;
            //     accept  scr-ohip-posted.;
            Display("scr-disp-clmhdr-dtl-2.", "scr-ohip-posted");
            await Prompt("ws_posted_ohip");

            // if ws-posted-ohip = zero then            
            if (ws_posted_ohip == 0)
            {
                err_ind = 17;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to ja0-20-input-amt.;
                await ja0_20_input_amt();
                return;
            }

            // if  batctrl-batch-type = "P" and batctrl-adj-cd     = "C" then            
            if (Util.Str(batctrl_batch_type).ToUpper() == "P" && Util.Str(batctrl_adj_cd).ToUpper() == "C")
            {
                // 	    subtract ws-posted-ohip		from	zero;
                // 					giving	ws-posted-ohip;
               // ws_posted_ohip = 0 - Util.NumDec( ws_posted_ohip);

                // 	    display scr-ohip-posted.;
                Display("scr-disp-clmhdr-dtl-2.", "scr-ohip-posted");
            }

            clmdtl_fee_ohip = ws_posted_ohip;

            // if  batctrl-agent-cd  not = 0 or (batctrl-adj-cd = 'R' or 'M' or 'C' or 'A')  then            
            if (Util.NumInt(batctrl_agent_cd) != 0 || (Util.Str(batctrl_adj_cd).ToUpper() == "R" || Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "C" || Util.Str(batctrl_adj_cd).ToUpper() == "A"))
            {
                ws_posted_oma = ws_posted_ohip;
            }
            // else if batctrl-adj-cd = "B" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "B")
            {
                // 	    perform ja1-calc-fee-oma-for-adj-b;
                // 					thru ja1-99-exit;
                await ja1_calc_fee_oma_for_adj_b();
                await ja1_99_exit();
            }
            else
            {
                // 	    multiply ws-posted-ohip	by 100	giving ws-posted-oma;
                ws_posted_oma = ws_posted_ohip * 100;

                // 	    divide ws-posted-oma	by  70	giving ws-posted-oma;
                // 						       clmdtl-fee-oma.;
                ws_posted_oma = ws_posted_oma / 70;
                clmdtl_fee_oma = ws_posted_oma / 70;
            }
        }

        private async Task<string> ja0_90_display_oma()
        {
            await Exit_Trakker();

            //     display scr-oma-posted.;
            Display("scr-disp-clmhdr-dtl-2.", "scr-oma-posted");

            ws_hold_posted_oma = ws_posted_oma;

            // if  batctrl-adj-cd = 'R' or 'M' or 'C' or 'A' then            
            if (Util.Str(batctrl_adj_cd).ToUpper() == "R" || Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "C" || Util.Str(batctrl_adj_cd).ToUpper() == "A")
            {
                // 	   go to ja0-95-acpt-tech-portion.;               
                return "ja0_95_acpt_tech_portion";
            }

            //  accept scr-oma-posted.;
            Display("scr-disp-clmhdr-dtl-2.", "scr-oma-posted");
            await Prompt("ws_posted_oma");

            // if ws-posted-oma = zero  then            
            if (Util.NumInt(ws_posted_oma) == 0)
            {
                err_ind = 44;
                // 	  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                ws_posted_oma = ws_hold_posted_oma;
                // 	  go to ja0-90-display-oma;
                await ja0_90_display_oma();
                return string.Empty;
            }
            // else if ws-hold-posted-oma = zero then            
            else if (Util.NumInt(ws_hold_posted_oma) == 0)
            {
                // 	    next sentence;
            }
            else
            {
                // 	    perform ja2-check-for-50-perc;
                //                                    	thru ja2-99-exit;
                await ja2_check_for_50_perc();
                await ja2_99_exit();

                // 	    if ws-hold-50-perc < temp then;         
                if (ws_hold_50_perc < temp)
                {
                    err_ind = 43;
                    // 		    perform za0-common-error;
                    //                            		thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    ws_posted_oma = ws_hold_posted_oma;
                    // 		    go to ja0-90-display-oma;
                    await ja0_90_display_oma();
                    return string.Empty;
                }
                else
                {
                    // 		   next sentence.;
                }
            }

            clmdtl_fee_oma = ws_posted_oma;
            return string.Empty;
        }

        private async Task ja0_95_acpt_tech_portion()
        {
            await Exit_Trakker();

            //     display scr-amt-tech.;
            //     accept  scr-amt-tech.;
            Display("scr-disp-clmhdr-dtl-3.", "scr-amt-tech");
            await Prompt("ws_amt_tech");

            // if  batctrl-batch-type = "P" and batctrl-adj-cd  = "C" then            
            if (Util.Str(batctrl_batch_type).ToUpper() == "P" && Util.Str(batctrl_adj_cd).ToUpper() == "C")
            {
                // 	    subtract ws-amt-tech   		from	zero;
                // 					giving	ws-amt-tech;

                //ws_amt_tech = 0 - Util.NumDec(ws_amt_tech);

                // 	    display scr-amt-tech.;
                Display("scr-disp-clmhdr-dtl-3.", "scr-amt-tech");
            }


            // if  ( ws-posted-ohip > zero  and ws-amt-tech    < zero ) or (    ws-posted-ohip < zero and ws-amt-tech    > zero )  then 
            if ((ws_posted_ohip > 0 && ws_amt_tech < 0) || (ws_posted_ohip < 0 && ws_amt_tech > 0))
            {
                err_ind = 47;
                //      perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                //         go to ja0-95-acpt-tech-portion.;
                await ja0_95_acpt_tech_portion();
                return;
            }

            abs_posted_ohip = ws_posted_ohip;
            abs_posted_oma = ws_posted_oma;
            abs_amt_tech = ws_amt_tech;

            // if abs-posted-ohip >= abs-posted-oma and abs-amt-tech    >  abs-posted-ohip then            
            if (Math.Abs(abs_posted_ohip) >= Math.Abs(abs_posted_oma) && Math.Abs(abs_amt_tech) > Math.Abs(abs_posted_ohip))
            {
                err_ind = 45;
                // 	   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ja0-95-acpt-tech-portion;
                await ja0_95_acpt_tech_portion();
                return;
            }
            // else if    abs-posted-ohip < abs-posted-oma and abs-amt-tech    > abs-posted-oma then
            else if (Math.Abs(abs_posted_ohip) < Math.Abs(abs_posted_oma) && Math.Abs(abs_amt_tech) > Math.Abs(abs_posted_oma))
            {
                err_ind = 45;
                // 	 perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to ja0-95-acpt-tech-portion;
                await ja0_95_acpt_tech_portion();
                return;
            }
            // else  if   abs-amt-tech >   abs-posted-ohip  or abs-posted-oma then            
            else if (Math.Abs(abs_amt_tech) > Math.Abs(abs_posted_ohip) || Math.Abs(abs_amt_tech) > Math.Abs(abs_posted_oma))
            {
                err_ind = 46;
                // perform za1-common-warning	thru za1-99-exit.;
                await za1_common_warning();
                await za1_99_exit();
            }

            //     subtract ws-amt-tech from ws-posted-ohip giving ws-prof-ohip.;
            ws_prof_ohip = ws_posted_ohip - ws_amt_tech;
            //     subtract ws-amt-tech from ws-posted-oma  giving ws-prof-oma.;
            ws_prof_oma = ws_posted_oma - ws_amt_tech;

            def_agent_code = Util.Str(batctrl_agent_cd);

            //  if def-agent-ohip then     
            if (def_agent_code.Equals(def_agent_ohip))
            {
                // 	    display scr-prof-ohip;
                Display("scr-disp-clmhdr-dtl-3.", "scr-prof-ohip");
            }
            else
            {
                // 	    display scr-prof-oma.;
                Display("scr-disp-clmhdr-dtl-3.", "scr-prof-oma");
            }

            clmdtl_amt_tech_billed = ws_amt_tech;

            // if clmhdr-loc = "0000" then 
            if (clmhdr_loc == "0000")
            {
                // 	   accept scr-clmhdr-loc.;
                Display("scr-acpt-clmhdr.", "scr-clmhdr-loc");
                await Prompt("clmhdr_loc");
            }

            //     accept scr-reference.;
            Display("scr-acpt-clmhdr.", "scr-reference");
            await Prompt("clmhdr_reference");
        }

        private async Task ja0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ja1_calc_fee_oma_for_adj_b()
        {
            await Exit_Trakker();

            //     divide ws-orig-oma			by ws-orig-ohip;
            // 					giving clmdtl-fee-oma.;

            clmdtl_fee_oma = Util.Divide(ws_orig_oma, ws_orig_ohip);  

            //     multiply clmdtl-fee-oma		by     ws-posted-ohip;
            // 					giving clmdtl-fee-oma;
            // 					       ws-posted-oma.;

            ws_posted_oma = clmdtl_fee_oma * ws_posted_ohip;
            clmdtl_fee_oma = clmdtl_fee_oma * ws_posted_ohip;            
        }

        private async Task ja1_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ja2_check_for_50_perc()
        {
            await Exit_Trakker();

            //     subtract ws-posted-oma		from ws-hold-posted-oma;
            // 					giving	temp.;
            temp = ws_hold_posted_oma - ws_posted_oma;

            //  if temp < zero then 
            if (temp < 0)
            {
                // 	multiply temp 			by -1;
                // 					giving temp.;
                temp = temp * -1;
            }

            //     divide 2				into ws-hold-posted-oma;
            // 					giving ws-hold-50-perc.;

            ws_hold_50_perc = ws_hold_posted_oma / 2;

            // if ws-hold-50-perc < zero then            
            if (ws_hold_50_perc < 0)
            {
                //  	multiply ws-hold-50-perc	by -1;
                // 					giving ws-hold-50-perc.;
                ws_hold_50_perc = ws_hold_50_perc * -1;
            }
        }

        private async Task ja2_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task la0_acpt_verification()
        {
            await Exit_Trakker();

            //     display verification-screen.;
            //     accept  verification-screen.;
            Display("verification-screen.");
            await Prompt("flag");

            // if flag =   "Y"  or "N" or "M" or "L" then            
            if (Util.Str(flag).ToUpper() == "Y" || Util.Str(flag).ToUpper() == "N" || Util.Str(flag).ToUpper() == "M" || Util.Str(flag).ToUpper() == "L")
            {
                // 	   next sentence;
            }
            else
            {
                err_ind = 1;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	go to la0-acpt-verification.;
                await la0_acpt_verification();
                return;
            }
        }

        private async Task la0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task ma0_write_clmhdr()
        {
            await Exit_Trakker();

            clmdtl_oma_cd = clmhdr_adj_oma_cd;
            clmdtl_oma_suff = clmhdr_adj_oma_suff;

            clmhdr_zeroed_oma_suff_adj_grp = "000000";
            clmhdr_adj_oma_cd = "0000";
            clmhdr_adj_oma_suff = "0";
            clmhdr_adj_adj_nbr = 0;


            clmhdr_date_sys = sys_date_long_child;
            clmhdr_date_cash_tape_payment = sys_date_long_child;

            // if batctrl-adj-cd =    "M" or "R"   then    
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                clmhdr_i_o_pat_ind = "O";
                clmhdr_doc_dept = Util.NumInt(objDoc_mstr_rec.DOC_DEPT);
            }

            clmhdr_tape_submit_ind = "N";
            clmhdr_status_ohip = "0";

            // if  batctrl-adj-cd = "M" then; 
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M")
            {
                clmhdr_pat_ohip_id_or_chart_grp = "";
                clmhdr_pat_key_type = "";
                clmhdr_pat_key_data_grp = "";
                clmhdr_pat_key_ohip = "";
                clmhdr_pat_acronym_grp = "";
                clmhdr_pat_acronym6 = "";
                clmhdr_pat_acronym3 = "";
            }
            // else if batctrl-adj-cd = "R" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                clmhdr_pat_ohip_id_or_chart_grp = "";
                clmhdr_pat_key_type = "";
                clmhdr_pat_key_data_grp = "";
                clmhdr_pat_key_ohip = "";
                clmhdr_pat_acronym_grp = "";
                clmhdr_pat_acronym6 = "";
                clmhdr_pat_acronym3 = "";
            }
            else
            {
                // 	    next sentence.;
            }

            //     add ws-posted-ohip			to batctrl-amt-act.;
            batctrl_amt_act = Util.NumDec(batctrl_amt_act) + ws_posted_ohip;

            // if batctrl-adj-cd = "A" then            
            if (Util.Str(batctrl_adj_cd).ToUpper() == "A")
            {
                // 	   add ws-posted-oma		to clmhdr-tot-claim-ar-oma;
                clmhdr_tot_claim_ar_oma += ws_posted_oma;

                // 	   add ws-posted-ohip		to clmhdr-tot-claim-ar-ohip;
                // 					               batctrl-calc-ar-due;
                clmhdr_tot_claim_ar_ohip = clmhdr_tot_claim_ar_ohip + ws_posted_ohip;
                batctrl_calc_ar_due = Util.NumDec(batctrl_calc_ar_due) + ws_posted_ohip;

                // 	   add ws-amt-tech			to clmhdr-amt-tech-billed;
                clmhdr_amt_tech_billed = clmhdr_amt_tech_billed + ws_amt_tech;
            }
            // else if batctrl-adj-cd = "B" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "B")
            {
                // 	    add ws-posted-ohip		to batctrl-calc-ar-due;
                // 					               batctrl-calc-tot-rev;
                // 					               clmhdr-tot-claim-ar-ohip;
                batctrl_calc_ar_due = Util.NumDec(batctrl_calc_ar_due) + ws_posted_ohip;
                batctrl_calc_tot_rev = Util.NumDec(batctrl_calc_tot_rev) + ws_posted_ohip;
                clmhdr_tot_claim_ar_ohip = clmhdr_tot_claim_ar_ohip + ws_posted_ohip;

                // 	    add ws-posted-oma		to clmhdr-tot-claim-ar-oma;
                clmhdr_tot_claim_ar_oma = clmhdr_tot_claim_ar_oma + ws_posted_oma;

                // 	    add ws-amt-tech		to clmhdr-amt-tech-billed;
                clmhdr_amt_tech_billed = clmhdr_amt_tech_billed + ws_amt_tech;
            }
            // else if batctrl-adj-cd = "C"then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "C")
            {
                // 		add ws-posted-ohip	to clmhdr-manual-and-tape-paymnts;
                // 					           batctrl-manual-pay-tot;
                clmhdr_manual_and_tape_paymnts = clmhdr_manual_and_tape_paymnts + ws_posted_ohip;
                batctrl_manual_pay_tot = Util.NumDec(batctrl_manual_pay_tot) + ws_posted_ohip;

                // 		add ws-amt-tech		 to clmhdr-amt-tech-paid;
                clmhdr_amt_tech_paid = clmhdr_amt_tech_paid + ws_amt_tech;
            }
            // else if batctrl-adj-cd = "M" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "M")
            {
                // 		 add ws-posted-ohip	to clmhdr-manual-and-tape-paymnts;
                // 				 	           batctrl-manual-pay-tot;
                // 					           batctrl-calc-tot-rev;

                clmhdr_manual_and_tape_paymnts = clmhdr_manual_and_tape_paymnts + ws_posted_ohip;
                batctrl_manual_pay_tot = Util.NumDec(batctrl_manual_pay_tot) + ws_posted_ohip;
                batctrl_calc_tot_rev = Util.NumDec(batctrl_calc_tot_rev) + ws_posted_ohip;

                // 		add ws-amt-tech	to clmhdr-amt-tech-paid;
                clmhdr_amt_tech_paid = clmhdr_amt_tech_paid + ws_amt_tech;
            }
            // else if batctrl-adj-cd = "R" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                // 		add ws-posted-ohip	to batctrl-calc-tot-rev;
                // 						       clmhdr-tot-claim-ar-ohip;
                batctrl_calc_tot_rev = Util.NumDec(batctrl_calc_tot_rev) + ws_posted_ohip;
                clmhdr_tot_claim_ar_ohip = clmhdr_tot_claim_ar_ohip + ws_posted_ohip;

                // 		add ws-posted-oma	to clmhdr-tot-claim-ar-oma;
                clmhdr_tot_claim_ar_oma = clmhdr_tot_claim_ar_oma + ws_posted_oma;
                // 		add ws-amt-tech		to   clmhdr-amt-tech-billed;
                clmhdr_amt_tech_billed = clmhdr_amt_tech_billed + ws_amt_tech;
            }
            else
            {
                // 			next sentence.;
            }

            clmdtl_b_key_type = "B";

            clmhdr_orig_batch_nbr_grp = Util.Str(clmhdr_orig_batch_nbr_1_2).PadLeft(2, '0') + Util.Str(clmhdr_orig_batch_nbr_4_9).PadRight(6);
            clmhdr_orig_batch_id_grp = clmhdr_orig_batch_nbr_grp + Util.Str(clmhdr_orig_claim_nbr).PadLeft(2, '0');
            clmdtl_b_data_grp = clmhdr_orig_batch_id_grp;
            clmdtl_b_batch_num = clmhdr_orig_batch_nbr_grp; //clmdtl_b_data_grp;



            clmdtl_b_oma_cd = "0000";
            clmdtl_b_oma_suff = "0";
            clmdtl_b_adj_nbr = "0";

            key_claims_mstr_grp = Util.Str(clmdtl_b_key_type).PadRight(1) + Util.Str(clmdtl_b_batch_num).PadRight(8) + Util.Str(clmdtl_b_claim_nbr).PadLeft(2, '0') + Util.Str(clmdtl_b_oma_cd).PadLeft(4, '0') + clmdtl_b_oma_suff.PadRight(1) + clmdtl_b_adj_nbr.PadRight(1);
            k_clmhdr_claims_mstr_grp = key_claims_mstr_grp;

            k_clmhdr_b_key_type = k_clmhdr_claims_mstr_grp.PadRight(17).Substring(0, 1);
            k_clmhdr_b_batch_num = k_clmhdr_claims_mstr_grp.PadRight(17).Substring(1, 8);

            k_clmhdr_b_claim_nbr = Util.NumInt(k_clmhdr_claims_mstr_grp.PadRight(17).Substring(9, 2));
            k_clmhdr_b_oma_cd = k_clmhdr_claims_mstr_grp.PadRight(17).Substring(11, 4);
            k_clmhdr_b_oma_suff = k_clmhdr_claims_mstr_grp.PadRight(17).Substring(15, 1);
            k_clmhdr_b_adj_nbr = k_clmhdr_claims_mstr_grp.PadRight(17).Substring(16, 1);

            clmdtl_p_key_type = "Z"; // Note:   P_key_type...

            // Todo... Not sure about this code below...???
            clmdtl_p_batch_nbr_grp = Util.Str(clmdtl_p_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(clmdtl_p_doc_nbr).PadRight(3) + Util.Str(clmdtl_p_week).PadLeft(2, '0') + Util.Str(clmdtl_p_day).PadLeft(1, '0');
            clmdtl_p_data_grp = clmdtl_p_batch_nbr_grp + Util.Str(clmdtl_p_claim_nbr).PadLeft(2, '0') + Util.Str(clmdtl_p_oma_cd).PadLeft(4, '0') + Util.Str(clmdtl_p_oma_suff).PadRight(1) + Util.Str(clmdtl_p_adj_nbr).PadRight(1);
            clmdtl_p_claims_mstr_grp = clmdtl_p_key_type + clmdtl_p_data_grp;
            k_clmhdr_p_claims_mstr_grp = clmdtl_p_claims_mstr_grp;
            k_clmhdr_p_key_type = Util.Str(k_clmhdr_p_claims_mstr_grp).PadRight(17).Substring(0, 1);
            k_clmhdr_p_data_grp = Util.Str(k_clmhdr_p_claims_mstr_grp).PadRight(17).Substring(1, 16);
            k_clmhdr_p_batch_nbr_grp = Util.Str(k_clmhdr_p_data_grp).PadRight(16).Substring(0, 8);
            k_clmhdr_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(k_clmhdr_p_batch_nbr_grp).PadRight(8).Substring(0, 2));
            k_clmhdr_p_doc_nbr = Util.Str(k_clmhdr_p_batch_nbr_grp).PadRight(8).Substring(2, 3);
            k_clmhdr_p_week = Util.NumInt(Util.Str(k_clmhdr_p_batch_nbr_grp).PadRight(8).Substring(5, 2));
            k_clmhdr_p_day = Util.NumInt(Util.Str(k_clmhdr_p_batch_nbr_grp).PadRight(8).Substring(7, 1));

            k_clmhdr_p_claim_nbr = Util.NumInt(Util.Str(k_clmhdr_p_data_grp).PadRight(16).Substring(8, 2));
            k_clmhdr_p_oma_cd = Util.Str(k_clmhdr_p_data_grp).PadRight(16).Substring(10, 4);
            k_clmhdr_p_oma_suff = Util.Str(k_clmhdr_p_data_grp).PadRight(16).Substring(14, 1);
            k_clmhdr_p_adj_nbr = Util.Str(k_clmhdr_p_data_grp).PadRight(16).Substring(15, 1);

            //   write claims-mstr-rec  from  claim-header-rec;
            // 	      invalid key;
            //         err_ind = 29;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            if (await Write_Claims_Hdr_Rec() == false)
            {
                err_ind = 29;
                // 	  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            //     add  1				to ctr-writ-claims-mstr.;
            ctr_writ_claims_mstr++;
        }

        private async Task ma0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task na0_write_clmdtl()
        {
            await Exit_Trakker();

            clmdtl_adj_nbr = 1;

            clmdtl_b_key_type = "B";
            clmrec_hdr_b_key_type = "B";
            k_clmdtl_b_key_type = "B";

            clmhdr_orig_batch_nbr_grp = clmhdr_orig_batch_nbr_1_2 + clmhdr_orig_batch_nbr_4_9;
            clmhdr_orig_batch_id_grp = clmhdr_orig_batch_nbr_grp + clmhdr_orig_claim_nbr;

            clmdtl_b_data_grp = clmhdr_orig_batch_id_grp;

            clmdtl_b_batch_num = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(0, 8);
            clmdtl_b_batch_nbr = clmdtl_b_batch_num;
            clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(0, 2));
            clmdtl_b_doc_nbr = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(2, 3);
            clmdtl_b_doc_nbr_r = clmdtl_b_doc_nbr;
            clmdtl_b_doc_nbr_2_4 = clmdtl_b_doc_nbr_r;
            clmdtl_b_batch_number = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3);
            clmdtl_b_week = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 2));
            clmdtl_b_day = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(7, 1));
            clmdtl_b_batch_number_numeric = Util.NumInt(clmdtl_b_batch_number);

            clmdtl_b_claim_nbr = Util.NumInt(Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(8, 2));
            clmdtl_b_oma_cd = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(10, 4);
            clmdtl_b_oma_suff = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(14, 1);
            clmdtl_b_adj_nbr = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(15, 1);

            clmrec_hdr_b_data_grp = clmhdr_orig_batch_id_grp;

            clmrec_hdr_b_batch_num = Util.Str(clmrec_hdr_b_data_grp).PadRight(16).Substring(0, 8);
            clmrec_hdr_b_batch_nbr = clmrec_hdr_b_batch_num;
            clmrec_hdr_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmrec_hdr_b_batch_nbr).PadRight(8).Substring(0, 2));
            clmrec_hdr_b_doc_nbr = Util.Str(clmrec_hdr_b_batch_nbr).PadRight(8).Substring(2, 3);
            clmrec_hdr_b_doc_nbr_r = clmrec_hdr_b_doc_nbr;
            clmrec_hdr_b_doc_nbr_2_4 = clmrec_hdr_b_doc_nbr_r;
            clmrec_hdr_b_batch_number_grp = Util.Str(clmrec_hdr_b_batch_nbr).PadRight(8).Substring(5, 3);
            clmrec_hdr_b_week = Util.NumInt(Util.Str(clmrec_hdr_b_batch_nbr).PadRight(8).Substring(5, 2));
            clmrec_hdr_b_day = Util.NumInt(Util.Str(clmrec_hdr_b_batch_nbr).PadRight(8).Substring(7, 1));


            clmrec_hdr_b_claim_nbr = Util.NumInt(Util.Str(clmrec_hdr_b_data_grp).PadRight(16).Substring(8, 2));
            clmrec_hdr_b_oma_cd = Util.Str(clmrec_hdr_b_data_grp).PadRight(16).Substring(10, 4);
            clmrec_hdr_b_oma_suff = Util.Str(clmrec_hdr_b_data_grp).PadRight(16).Substring(14, 1);
            clmrec_hdr_b_adj_nbr = Util.Str(clmrec_hdr_b_data_grp).PadRight(16).Substring(15, 1);

            k_clmdtl_b_data_grp = clmhdr_orig_batch_id_grp;

            k_clmdtl_b_batch_num = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(0, 8);
            k_clmdtl_b_batch_nbr_grp = k_clmdtl_b_batch_num;
            k_clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(0, 2));
            k_clmdtl_b_doc_nbr = Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(2, 3);
            k_clmdtl_b_doc_nbr_r_grp = k_clmdtl_b_doc_nbr;
            k_clmdtl_b_doc_nbr_2_4 = k_clmdtl_b_doc_nbr_r_grp;
            k_clmdtl_b_batch_number_grp = Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(5, 3);
            k_clmdtl_b_week = Util.NumInt(Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(5, 2));
            k_clmdtl_b_day = Util.NumInt(Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(7, 1));

            k_clmdtl_b_claim_nbr = Util.NumInt(Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(8, 2));
            k_clmdtl_b_oma_cd = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(10, 4);
            k_clmdtl_b_oma_suff = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(14, 1);
            k_clmdtl_b_adj_nbr = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(15, 1);

            //  if clmdtl-oma-cd =   spaces  or zeros then
            if (string.IsNullOrWhiteSpace(clmdtl_oma_cd))  //|| Util.NumInt(clmdtl_oma_cd) == 0)
            {
                // 	    if clmhdr-batch-type = "A" then            
                if (Util.Str(clmhdr_batch_type).ToUpper() == "A")
                {
                    clmdtl_oma_cd = "ADJU";
                    clmdtl_oma_suff = "S";
                }
                // 	    else if clmhdr-batch-type = "P" then            
                else if (Util.Str(clmhdr_batch_type).ToUpper() == "P")
                {
                    clmdtl_oma_cd = "PAID";
                    clmdtl_oma_suff = "";
                }
                else
                {
                    // 		   next sentence;
                }
            }
            else
            {
                // 	   next sentence.;
            }

            clmdtl_b_oma_cd = clmdtl_oma_cd;
            clmdtl_b_oma_suff = clmdtl_oma_suff;
            clmdtl_b_adj_nbr = "0";

            //objClaim_detail_rec.K_clmdtl_claims_mstr = objClaims_mstr_dtl_rec.key_claims_mstr;
            // 						of claim-detail-rec.;


            key_claims_mstr_grp = Util.Str(clmdtl_b_key_type).PadRight(1) + Util.Str(clmdtl_b_batch_num).PadRight(8) + Util.Str(clmdtl_b_claim_nbr).PadLeft(2, '0') + Util.Str(clmdtl_b_oma_cd).PadLeft(4, '0') + clmdtl_b_oma_suff.PadRight(1) + clmdtl_b_adj_nbr.PadRight(1);

            k_clmdtl_claims_mstr_grp = key_claims_mstr_grp;

            k_clmdtl_b_key_type = Util.Str(k_clmdtl_claims_mstr_grp).PadRight(17).Substring(0, 1);
            k_clmdtl_b_data_grp = Util.Str(k_clmdtl_claims_mstr_grp).PadRight(17).Substring(1, 16);
            k_clmdtl_b_batch_num = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(0, 8);
            k_clmdtl_b_batch_nbr_grp = k_clmdtl_b_batch_num;
            k_clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(0, 2));
            k_clmdtl_b_doc_nbr = Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(2, 3);
            k_clmdtl_b_doc_nbr_r_grp = k_clmdtl_b_doc_nbr;
            k_clmdtl_b_doc_nbr_2_4 = k_clmdtl_b_doc_nbr_r_grp;
            k_clmdtl_b_batch_number_grp = Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(5, 3);
            k_clmdtl_b_week = Util.NumInt(Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(5, 2));
            k_clmdtl_b_day = Util.NumInt(Util.Str(k_clmdtl_b_batch_nbr_grp).PadRight(8).Substring(7, 1));
            k_clmdtl_b_data_r_grp = k_clmdtl_b_data_grp;
            k_clmdtl_b_pat_id = Util.Str(k_clmdtl_b_data_r_grp).PadRight(18).Substring(0, 15);

            k_clmdtl_b_claim_nbr = Util.NumInt(Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(8, 2));
            k_clmdtl_b_oma_cd = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(10, 4);
            k_clmdtl_b_oma_suff = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(14, 1);
            k_clmdtl_b_adj_nbr = Util.Str(k_clmdtl_b_data_grp).PadRight(16).Substring(15, 1);

            //move "Z"  to clmdtl-p-key-type of claims-mstr-rec.
            clmdtl_p_key_type = "Z";

            //move clmdtl-p-claims-mstr to k-clmdtl-p-claims-mstr of claim-detail-rec.
            clmdtl_p_batch_nbr_grp = Util.Str(clmdtl_p_clinic_nbr_1_2).PadLeft(2, '0') + Util.Str(clmdtl_p_doc_nbr).PadRight(3) + Util.Str(clmdtl_p_week).PadLeft(2, '0') + Util.Str(clmdtl_p_day).PadLeft(1, '0');
            clmdtl_p_data_grp = clmdtl_p_batch_nbr_grp + clmdtl_p_claim_nbr + clmdtl_p_oma_cd + clmdtl_p_oma_suff + clmdtl_p_adj_nbr;
            clmdtl_p_claims_mstr_grp = Util.Str(clmdtl_p_key_type).PadRight(1) + clmdtl_p_data_grp;

            k_clmdtl_p_claims_mstr_grp = clmdtl_p_claims_mstr_grp;

            k_clmdtl_p_key_type = Util.Str(k_clmdtl_p_claims_mstr_grp).PadRight(17).Substring(0, 1);
            k_clmdtl_p_data_grp = Util.Str(k_clmdtl_p_claims_mstr_grp).PadRight(17).Substring(1, 16);
            k_clmdtl_p_batch_nbr_grp = Util.Str(k_clmdtl_p_data_grp).PadRight(16).Substring(0, 8);
            k_clmdtl_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(k_clmdtl_p_batch_nbr_grp).PadRight(8).Substring(0, 2));
            k_clmdtl_p_doc_nbr = Util.Str(k_clmdtl_p_batch_nbr_grp).PadRight(8).Substring(2, 3);
            k_clmdtl_p_week = Util.NumInt(Util.Str(k_clmdtl_p_batch_nbr_grp).PadRight(8).Substring(5, 2));
            k_clmdtl_p_day = Util.NumInt(Util.Str(k_clmdtl_p_batch_nbr_grp).PadRight(8).Substring(7, 1));

            k_clmdtl_p_claim_nbr = Util.NumInt(Util.Str(k_clmdtl_p_data_grp).PadRight(16).Substring(8, 2));
            k_clmdtl_p_oma_cd = Util.Str(Util.Str(k_clmdtl_p_data_grp).PadRight(16).Substring(10, 4));
            k_clmdtl_p_oma_suff = Util.Str(Util.Str(k_clmdtl_p_data_grp).PadRight(16).Substring(14, 1));
            k_clmdtl_p_adj_nbr = Util.Str(Util.Str(k_clmdtl_p_data_grp).PadRight(16).Substring(15, 1));

            //   write claims-mstr-rec  from  claim-detail-rec;
            // 	invalid key;
            //         err_ind = 30;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            if (await Write_Claims_Dtl_Rec() == false)
            {
                err_ind = 30;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	  go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            //     add 1				to ctr-writ-claims-mstr.;
            ctr_writ_claims_mstr++;

            // if batctrl-adj-cd =   "M"  or "R"  then            
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                //    	   go to na0-99-exit.;
                await na0_99_exit();
                return;
            }

            //move clmdtl-id   to      clmdtl-b-data.

            clmdtl_id_grp = Util.Str(clmdtl_batch_nbr).PadRight(8) + Util.Str(clmdtl_claim_nbr).PadLeft(2, '0') + Util.Str(clmdtl_oma_cd).PadRight(4) + Util.Str(clmdtl_oma_suff).PadRight(1) + Util.Str(clmdtl_adj_nbr).PadLeft(1, '0');
            clmdtl_b_data_grp = clmdtl_id_grp;

            clmdtl_b_batch_num = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(0, 8);
            clmdtl_b_batch_nbr = clmdtl_b_batch_num;
            clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(0, 2));
            clmdtl_b_doc_nbr = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(2, 3);
            clmdtl_b_doc_nbr_r = clmdtl_b_doc_nbr;
            clmdtl_b_doc_nbr_2_4 = clmdtl_b_doc_nbr_r;
            clmdtl_b_batch_number = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3);
            clmdtl_b_week = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 2));
            clmdtl_b_day = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(7, 1));
            clmdtl_b_batch_number_numeric = Util.NumInt(clmdtl_b_batch_number);

            clmdtl_b_claim_nbr = Util.NumInt(Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(8, 2));
            clmdtl_b_oma_cd = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(10, 4);
            clmdtl_b_oma_suff = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(14, 1);
            clmdtl_b_adj_nbr = Util.Str(clmdtl_b_data_grp).PadRight(16).Substring(15, 1);

            clmdtl_b_key_type = "B";

            // move "Z"                to clmdtl-p-key-type of claims-mstr-rec.
            clmdtl_p_key_type = "Z";


            // write            claims-mstr-rec;
            // 	invalid key;
            //        err_ind = 31;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            //*(all transactions except 'M' and 'R' adjust existing claims and as
            //*   such must the detail recs must  appear in the claim being adjusted
            //*   as well as the adjustment claim.  DG cobol used a 2nd write inverted
            //* to create the appropriate 2nd key for the detail rec however in
            //*MF cobol the only way to get a 2nd "B" key is to do an 2nd write.
            //*Therefore the write invert is changed to a simple write with the
            //*"B" key setup for the adjusted claim and the "P" or
            //* alternative key is set to "Z" so that it is in a sequence position
            //* that all other programs will ignore.)

            if (await Write_Claims_Dtl_Rec() == false)
            {
                err_ind = 31;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	 go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            //  add 1				to ctr-writ-claims-mstr.;
            ctr_writ_claims_mstr++;
        }

        private async Task na0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task pa0_update_adjusted_claim()
        {
            await Exit_Trakker();

            // if batctrl-adj-cd =   "M" or "R" then 
            if (Util.Str(batctrl_adj_cd).ToUpper() == "M" || Util.Str(batctrl_adj_cd).ToUpper() == "R")
            {
                // 	   go to pa0-99-exit.;
                await pa0_99_exit();
                return;
            }

            if (objws_save_claims_header != null)
            {
                //claim_header_rec = ws_save_claims_header;
                objClaims_mstr_dtl_rec = objws_save_claims_header.ShallowCopyClone();
                //await Clmhdr_Record_To_ScreenVariables();
                await Assign_ClaimsHeader_To_Claims_mstr_Rec();
            }

            feedback_claims_mstr = ws_save_claims_feedback;

            clmdtl_b_key_type = "B";

            clmhdr_zeroed_oma_suff_adj_grp = Util.Str(clmhdr_adj_oma_cd).PadRight(4) + Util.Str(clmhdr_adj_oma_suff).PadRight(1) + Util.Str(clmhdr_adj_adj_nbr).PadRight(1);
            clmhdr_claim_id_grp = Util.Str(clmhdr_batch_nbr).PadLeft(8, '0') + Util.Str(clmhdr_claim_nbr).PadLeft(2, '0') + clmhdr_zeroed_oma_suff_adj_grp;

            clmdtl_b_data_grp = clmhdr_claim_id_grp;

            clmdtl_b_batch_num = clmhdr_batch_nbr;
            clmdtl_b_batch_nbr = clmdtl_b_batch_num;
            clmdtl_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(0, 2));
            clmdtl_b_doc_nbr = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(2, 3);
            clmdtl_b_doc_nbr_2_4 = clmdtl_b_doc_nbr;
            clmdtl_b_batch_number = Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3);
            clmdtl_b_week = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 2));
            clmdtl_b_day = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(7, 1));
            clmdtl_b_batch_number_numeric = Util.NumInt(Util.Str(clmdtl_b_batch_nbr).PadRight(8).Substring(5, 3));

            clmdtl_b_claim_nbr = clmhdr_claim_nbr;
            clmdtl_b_oma_cd = clmhdr_adj_oma_cd;
            clmdtl_b_oma_suff = clmhdr_adj_oma_suff;
            clmdtl_b_adj_nbr = Util.Str(clmhdr_adj_adj_nbr);

            claims_occur = 0;
            feedback_claims_mstr = "0";

            //  perform xc0-read-claims-mstr		thru xc0-99-exit.;
            await xc0_read_claims_mstr();
            await xc0_99_exit();

            // if flag = "N" then 
            if (Util.Str(flag).ToUpper() == "N")
            {
                err_ind = 40;
                // 	   perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }

            // if batctrl-adj-cd = "A" then 
            if (Util.Str(batctrl_adj_cd).ToUpper() == "A")
            {
                //     add ws-posted-oma			to clmhdr-tot-claim-ar-oma;
                clmhdr_tot_claim_ar_oma = clmhdr_tot_claim_ar_oma + ws_posted_oma;
                // 	   add ws-posted-ohip			to clmhdr-tot-claim-ar-ohip;
                clmhdr_tot_claim_ar_ohip = clmhdr_tot_claim_ar_ohip + ws_posted_ohip;
                //     add ws-amt-tech 			to clmhdr-amt-tech-billed;
                clmhdr_amt_tech_billed = clmhdr_amt_tech_billed + ws_amt_tech;
            }
            // else if batctrl-adj-cd = "B" then            
            else if (Util.Str(batctrl_adj_cd).ToUpper() == "B")
            {
                // 	    add ws-posted-oma			to clmhdr-tot-claim-ar-oma;
                clmhdr_tot_claim_ar_oma = clmhdr_tot_claim_ar_oma + ws_posted_oma;
                // 	    add ws-posted-ohip			to clmhdr-tot-claim-ar-ohip;
                clmhdr_tot_claim_ar_ohip = clmhdr_tot_claim_ar_ohip + ws_posted_ohip;
                // 	    add ws-amt-tech			to clmhdr-amt-tech-billed;
                clmhdr_amt_tech_billed = clmhdr_amt_tech_billed + ws_amt_tech;
            }
            // else if batctrl-adj-cd = "C" then            
            else if (Util.Str(batctrl_adj_cd) == "C")
            {
                // 		add ws-posted-ohip		to clmhdr-manual-and-tape-paymnts;
                clmhdr_manual_and_tape_paymnts = clmhdr_manual_and_tape_paymnts + ws_posted_ohip;
                // 		add ws-posted-ohip		to clmhdr-curr-payment;
                clmhdr_curr_payment = clmhdr_curr_payment + ws_posted_ohip;
                // 		add ws-amt-tech			to clmhdr-amt-tech-paid;
                clmhdr_amt_tech_paid = clmhdr_amt_tech_paid + ws_amt_tech;
            }
            else
            {
                // 		next sentence.;
            }

            //objClaims_mstr_rec.claims_mstr_rec = claim_header_rec;            

            //  rewrite  claims-mstr-rec;
            // 	invalid key;
            //      err_ind = 34;
            // 	    perform za0-common-error		thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            if (await Rewrite_Claims_Hdr_Rec() == false)
            {
                err_ind = 34;
                //  perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to az0-end-of-job.;
                await az0_end_of_job();
                return;
            }
        }

        private async Task pa0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xa0_disp_batctrl_data()
        {
            await Exit_Trakker();

            //     display scr-title-batch-control-data.;
            Display("scr-title-batch-control-data.");

            //     display scr-acpt-batch-nbr.;
            Display("scr-acpt-batch-nbr.");

            //     display scr-acpt-batch-type.;
            Display("scr-acpt-batch-type.");

            //     display scr-val-batch-period-cycle.;
            Display("scr-val-batch-period-cycle.");

            //     display scr-acpt-mask.;
            Display("scr-acpt-mask.");

            //     display scr-lit-batctrl-data.;
            Display("scr-lit-batctrl-data.");

            //     subtract batctrl-amt-act			from      batctrl-amt-est;
            // 						giving ws-batctrl-amt-diff.;
            ws_batctrl_amt_diff = Util.NumDec(batctrl_amt_est) - Util.NumDec(batctrl_amt_act);

            //     display scr-val-batctrl-data.;
            Display("scr-val-batctrl-data.");
        }

        private async Task xa0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xb0_allow_change_of_estimates()
        {
            await Exit_Trakker();

            //     display scr-acpt-change-verification.;
            //     accept  scr-acpt-change-verification.;
            Display("scr-acpt-change-verification.");
            await Prompt("change_reply");

            // if change-reply = "Y" then
            if (Util.Str(change_reply).ToUpper() == "Y")
            {
                // 	   display scr-acpt-change-password;
                // 	   accept  scr-acpt-change-password;
                password_input = string.Empty;
                Display("scr-acpt-change-password.");
                await Prompt("password_input");

                // 	   if password-input  =  password  or  password-special-privledges then 
                if (password_input == password || password_input == password_special_privledges)
                {
                    // 	      perform xb1-input-batctrl-est	thru xb1-99-exit;
                    await xb1_input_batctrl_est();
                    await xb1_99_exit();
                    // 	      go to xb0-allow-change-of-estimates;
                    await xb0_allow_change_of_estimates();
                    return;
                }
                else
                {
                    err_ind = 3;
                    // 	 perform za0-common-error		thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	      go to xb0-allow-change-of-estimates.;
                    await xb0_allow_change_of_estimates();
                    return;
                }
            }
        }

        private async Task xb0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xb1_input_batctrl_est()
        {
            await Exit_Trakker();

            //     accept  scr-amt-est.;
            Display("scr-val-batctrl-data.", "scr-amt-est");
            await Prompt("batctrl_amt_est");


            // if  batctrl-batch-type = "P" and batctrl-adj-cd     = "C"  then  
            if (Util.Str(batctrl_batch_type).ToUpper() == "P" && Util.Str(batctrl_adj_cd).ToUpper() == "C")
            {
                // 	    subtract batctrl-amt-est		from	zero;
                // 						giving	batctrl-amt-est;
                //batctrl_amt_est = 0 - Math.Abs(Util.NumDec(batctrl_amt_est));     

                batctrl_amt_est = 0 - Util.NumDec(batctrl_amt_est);

                // 	    display scr-amt-est.;
                Display("scr-val-batctrl-data.", "scr-amt-est");
            }

            // if password-input = password-special-privledges then            
            if (password_input == password_special_privledges)
            {
                // 	   accept scr-amt-act.;
                Display("scr-val-batctrl-data.", "scr-amt-act");
                await Prompt("batctrl_amt_act");
            }

            //     subtract batctrl-amt-act			from      batctrl-amt-est;
            // 						giving ws-batctrl-amt-diff.;
            ws_batctrl_amt_diff = Util.NumDec(batctrl_amt_est) - Util.NumDec(batctrl_amt_act);

            //     display scr-amt-diff.;
            Display("scr-val-batctrl-data.", "scr-amt-diff");
        }

        private async Task xb1_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xc0_read_claims_mstr()
        {
            await Exit_Trakker();

            //  read claims-mstr	into claim-header-rec	  key is key-claims-mstr;
            // 	invalid key;
            //          flag = "N";
            // 		go to xc0-99-exit.;

            Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = clmdtl_b_key_type,
                WhereKey_clm_batch_nbr = clmhdr_batch_nbr,
                WhereKey_clm_claim_nbr = clmhdr_claim_nbr
                //WhereClmhdr_adj_oma_cd = clmdtl_b_oma_cd,
                //WhereClmhdr_adj_oma_suff = clmdtl_b_oma_suff,
                //WhereClmhdr_adj_adj_nbr = clmdtl_b_adj_nbr
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(2000, false);

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                flag = "N";
                // go to xc0-99-exit.;
                await xc0_99_exit();
                return;
            }

            ctr_read_claims_mstr = 0;
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[ctr_read_claims_mstr];
            await Clmhdr_Record_To_ScreenVariables();
            //await Assign_ClaimsHeader_To_Claims_mstr_Rec();

            flag = "Y";
            //     add  1				to	ctr-read-claims-mstr.;
            ctr_read_claims_mstr++;
        }

        private async Task xc0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xd0_read_clmdtl()
        {
            await Exit_Trakker();

            //  read    claims-mstr    next   into claim-detail-rec;
            // 	at end;
            //       flag = "N";		 		 
            // 	 go xd0-99-exit.;

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {                
                flag = "N";
                //  go xd0-99-exit.;
                await xd0_99_exit();
                return;
            }
            else if (ctr_read_claims_mstr >= Claims_mstr_dtl_rec_Collection.Count())
            {
                objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[Claims_mstr_dtl_rec_Collection.Count() - 1];
                await Assign_ClaimsDetail_To_Claims_mstr_dtl_Rec();
                flag = "N";
                //  go xd0-99-exit.;
                await xd0_99_exit();
                return;
            }
            else
            {
                objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[ctr_read_claims_mstr];
                //await Clmdtl_Record_To_ScreenVariables();
                await Assign_ClaimsDetail_To_Claims_mstr_dtl_Rec();
            }

            flag = "Y";
            //     add	1					to ctr-read-claims-mstr.;
            ctr_read_claims_mstr++;
        }

        private async Task xd0_99_exit()
        {
            await Exit_Trakker();
            //     exit.;
        }

        private async Task xe0_read_claims_mstr(bool isHeader = false)
        {
            await Exit_Trakker();

            claims_occur = 0;
            feedback_claims_mstr = "";

            //  read claims-mstr		key is key-claims-mstr;
            // 	invalid key;
            //         flag = "N";
            // 	    go to xe0-99-exit.;

            /* if (isHeader)
             {
                 Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
                 {
                     WhereKey_clm_type = clmdtl_b_key_type,
                     WhereKey_clm_batch_nbr = clmhdr_batch_nbr,
                     WhereKey_clm_claim_nbr = clmhdr_claim_nbr,                    
                 }.Collection_HDR_DTL_INNERJOIN_UsingTop(20000, false);
             }
             else
             { */
            
            Claims_mstr_dtl_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = clmdtl_b_key_type,
                WhereKey_clm_batch_nbr = clmhdr_batch_nbr, 
                WhereKey_clm_claim_nbr = clmhdr_claim_nbr, 
                WhereClmdtl_oma_cd = Util.Str(clmhdr_adj_oma_cd).Replace("0000", ""),  
                WhereClmdtl_oma_suff = Util.Str(clmhdr_adj_oma_suff).Replace("0","") 
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(20000, false);
            //}

            if (Claims_mstr_dtl_rec_Collection.Count() == 0)
            {
                flag = "N";
                //         flag = "N";
                // 	    go to xe0-99-exit.;
                await xe0_99_exit();
                return;
            }

            ctr_read_claims_mstr = 0;
            objClaims_mstr_dtl_rec = Claims_mstr_dtl_rec_Collection[ctr_read_claims_mstr];
            //await Clmhdr_Record_To_ScreenVariables();
            await Assign_ClaimsHeader_To_Claims_mstr_Rec();
            // await Clmdtl_Record_To_ScreenVariables();
            await Assign_ClaimsDetail_To_Claims_mstr_dtl_Rec();

            flag = "Y";
            //     add  1				to ctr-read-claims-mstr.;
            ctr_read_claims_mstr++;
        }

        private async Task xe0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xf0_read_doc_mstr()
        {
            await Exit_Trakker();

            //     read  doc-mstr;
            // 	invalid key;
            //         flag = "N";
            // 		go to xf0-99-exit.;

            objDoc_mstr_rec = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = doc_nbr
            }.Collection().FirstOrDefault();

            if (objDoc_mstr_rec == null)
            {
                flag = "N";
                // go to xf0-99-exit.;
                await xf0_99_exit();
                return;
            }

            doc_name = Util.Str(objDoc_mstr_rec.DOC_NAME);

            flag = "Y";
            //     add  1				to ctr-read-doc-mstr.;
            ctr_read_doc_mstr++;
        }

        private async Task xf0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xh0_read_oma_fee_mstr()
        {
            await Exit_Trakker();

            //     read  oma-fee-mstr;
            // 	invalid key;
            //         flag = "N";
            // 		go to xh0-99-exit.;

            objFee_mstr_rec = new F040_OMA_FEE_MSTR
            {
                WhereFee_oma_cd_ltr1 = objFee_mstr_rec.FEE_OMA_CD_LTR1,
                WhereFiller_numeric = objFee_mstr_rec.FILLER_NUMERIC

            }.Collection().FirstOrDefault();

            if (objFee_mstr_rec == null)
            {
                objFee_mstr_rec = new F040_OMA_FEE_MSTR();
                flag = "N";
                // go to xh0-99-exit.;
                await xh0_99_exit();
                return;
            }

            flag = "Y";
            //     add  1				to ctr-read-oma-mstr.;
            ctr_read_oma_mstr++;
        }

        private async Task xh0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task xi0_read_oma_dtl()
        {
            await Exit_Trakker();

            //    read  f040-dtl;
            //        invalid key;
            //           flag = "N";
            // 	      go to xi0-99-exit.;

            F040_dtl_rec_Collection = new F040_DTL
            {
                WhereDoc_nbr = ws_doc_nbr
            }.Collection();

            if (F040_dtl_rec_Collection.Count() == 0)
            {
                objF040_dtl_rec = new F040_DTL();
                flag = "N";
                //   go to xi0-99-exit.;
                await xi0_99_exit();
                return;
            }

            objF040_dtl_rec = F040_dtl_rec_Collection[0];
            flag = "Y";
        }

        private async Task xi0_99_exit()
        {
            await Exit_Trakker();

            //    exit.;
        }

        private async Task xj0_read_const_mstr()
        {
            await Exit_Trakker();

            //  read    iconst-mstr;
            // 	invalid key;
            //         flag = "N";
            // 	    go to xj0-99-exit.;

            objIconst_mstr_rec = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = batctrl_bat_clinic_nbr_1_2
            }.Collection().FirstOrDefault();

            if (objIconst_mstr_rec == null)
            {
                objIconst_mstr_rec = new ICONST_MSTR_REC();
                flag = "N";
                // 	    go to xj0-99-exit.;
                await xj0_99_exit();
                return;
            }

            flag = "Y";
            //     add  1				to ctr-read-const-mstr.;
            ctr_read_const_mstr++;
        }

        private async Task xj0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task za0_common_error()
        {
            await Exit_Trakker();

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            //     accept scr-confirm.;
            Display("err-msg-line.");
            await Prompt("err_msg_comment");

            //     display blank-line-24.;
            Display("blank-line-24.");
        }

        private async Task za0_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        private async Task za1_common_warning()
        {
            await Exit_Trakker();

            err_msg_comment = err_msg[err_ind];
            //     display wrn-msg-line.;
            Display("wrn-msg-line.");

            confirm_space = "";
            //     accept scr-confirm.;
            Display("scr-confirm");
            await Prompt("confirm_space");

            // if confirm-space  = '!' or '*' then            
            if (confirm_space == "!" || confirm_space == "*")
            {
                //   	next sentence;
            }
            else
            {
                //   	go to za1-common-warning.;
                await za1_common_warning();
                return;
            }

            //     display blank-line-24.;
            Display("blank-line-24.");
        }

        private async Task za1_99_exit()
        {
            await Exit_Trakker();

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {
            await Exit_Trakker();

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            //sys_date_blank = 0;
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
            clmhdr_batch_nbr = "";
            clmhdr_clinic_nbr_1_2 = 0;
            clmhdr_doc_nbr = "";
            clmhdr_week = 0;
            clmhdr_day = 0;

            clmhdr_batch_nbr_3_6 = "";
            clmhdr_batch_nbr_7_9 = 0;

            clmhdr_claim_nbr = 0;

            clmhdr_zeroed_oma_suff_adj_grp = "";
            clmhdr_adj_oma_cd = "";
            clmhdr_adj_oma_suff = "";
            clmhdr_adj_adj_nbr = 0;

            clmhdr_batch_type = "";
            clmhdr_adj_cd_sub_type = "";
            clmhdr_adj_cd_sub_type_ss = 0;

            clmhdr_doc_nbr_ohip = 0;
            clmhdr_doc_spec_cd = 0;
            clmhdr_refer_doc_nbr = 0;
            clmhdr_diag_cd = 0;
            clmhdr_loc = "";
            clmhdr_hosp = "";
            clmhdr_payroll = "";
            clmhdr_agent_cd = 0;
            clmhdr_adj_cd = "";
            clmhdr_tape_submit_ind = "";
            clmhdr_i_o_pat_ind = "";
            clmhdr_pat_ohip_id_or_chart_grp = "";
            clmhdr_pat_key_type = "";
            clmhdr_pat_key_data_grp = "";
            clmhdr_pat_key_ohip = "";
            clmhdr_pat_acronym_grp = "";
            clmhdr_pat_acronym6 = "";
            clmhdr_pat_acronym3 = "";
            clmhdr_reference = "";

            clmhdr_date_admit_yy = "";
            clmhdr_date_admit_yy_r_grp = "";
            clmhdr_date_admit_yy_12 = "";
            clmhdr_date_admit_yy_34 = "";
            clmhdr_date_admit_mm = 0;
            clmhdr_date_admit_dd_r = "";
            clmhdr_date_admit_dd = 0;
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
            clmhdr_p_claims_mstr_grp = "";
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
            clmdtl_p_data_grp = "";
            clmdtl_p_batch_nbr_grp = "";
            clmdtl_p_clinic_nbr_1_2 = 0;
            clmdtl_p_doc_nbr = "";
            clmdtl_p_week = 0;
            clmdtl_p_day = 0;
            clmdtl_p_claim_nbr = 0;
            clmdtl_p_oma_cd = "";
            clmdtl_p_oma_suff = "";
            clmdtl_p_adj_nbr = "";
        }

        private async Task Initialize_Claims_mstr_dtl_Rec()
        {
            clmrec_dtl_oma_cd = "";
            clmrec_dtl_agent_cd = 0;
            clmrec_dtl_adj_cd = "";
            clmrec_dtl_nbr_serv = 0;
            clmrec_dtl_sv_date = "";
            clmrec_dtl_consec_dates_grp = new string[4];
            clmrec_dtl_sv_nbr = new int[4];
            clmrec_dtl_amt_tech_billed = 0;
            clmrec_dtl_fee_oma = 0;
            clmrec_dtl_fee_ohip = 0;

            clmdtl_b_key_type = "";
            clmdtl_b_data_grp = "";
            clmdtl_b_batch_num = "";
            clmdtl_b_batch_nbr = "";
            clmdtl_b_clinic_nbr_1_2 = 0;
            clmdtl_b_doc_nbr = "";
            clmdtl_b_doc_nbr_r = "";
            clmdtl_b_doc_nbr_2_4 = "";
            clmdtl_b_batch_number = "";
            clmdtl_b_week = 0;
            clmdtl_b_day = 0;
            clmdtl_b_batch_number_numeric = 0;
            clmdtl_b_claim_nbr = 0;
            clmdtl_b_oma_cd = "";
            clmdtl_b_oma_suff = "";
            clmdtl_b_adj_nbr = "";
            clmdtl_b_data_r = "";
            clmdtl_b_pat_id = "";
            clmdtl_p_claims_mstr_grp = "";
            clmdtl_p_key_type = "";
            clmdtl_p_data_grp = "";
            clmdtl_p_batch_nbr_grp = "";
            clmdtl_p_clinic_nbr_1_2 = 0;
            clmdtl_p_doc_nbr = "";
            clmdtl_p_week = 0;
            clmdtl_p_day = 0;
            clmdtl_p_claim_nbr = 0;
            clmdtl_p_oma_cd = "";
            clmdtl_p_oma_suff = "";
            clmdtl_p_adj_nbr = "";
        }

        private async Task Initialize_Claims_mstr_Rec()
        {
            clmrec_hdr_clinic_nbr_1_2 = 0;
            clmrec_zeroed_oma_suff_adj = "";
            clmrec_zeroed_area = 0;
            clmrec_hdr_batch_type = "";
            clmrec_hdr_diag_cd = 0;
            clmrec_hdr_loc = "";
            clmrec_hdr_hosp = "";
            clmrec_hdr_payroll = "";
            clmrec_hdr_agent_cd = 0;
            clmrec_hdr_i_o_pat_ind = "";
            clmrec_hdr_ohip_id_or_chart = "";
            clmrec_hdr_pat_acronym = "";

            clmrec_doc_dept_nbr = 0;
            clmrec_hdr_date_claim = "";
            clmrec_hdr_amt_tech_billed = 0;
            clmrec_hdr_amt_tech_paid = 0;
            clmrec_hdr_tot_claim_ar_oma = 0;
            clmrec_hdr_tot_claim_ar_ohip = 0;
            clmrec_hdr_manual_tape_pymnts = 0;
            clmrec_hdr_status_ohip = "";

            clmrec_hdr_b_key_type = "";
            clmrec_hdr_b_data_grp = "";
            clmrec_hdr_b_batch_num = "";
            clmrec_hdr_b_batch_nbr = "";
            clmrec_hdr_b_clinic_nbr_1_2 = 0;
            clmrec_hdr_b_doc_nbr = "";
            clmrec_hdr_b_doc_nbr_r = "";
            clmrec_hdr_b_doc_nbr_2_4 = "";
            clmrec_hdr_b_batch_number_grp = "";
            clmrec_hdr_b_week = 0;
            clmrec_hdr_b_day = 0;
            clmrec_hdr_b_claim_nbr = 0;
            clmrec_hdr_b_oma_cd = "";
            clmrec_hdr_b_oma_suff = "";
            clmrec_hdr_b_adj_nbr = "";
            clmrec_hdr_b_data_r = "";
            clmrec_hdr_b_pat_id = "";
        }

        private async Task Assign_ClaimsHeader_To_Claims_mstr_Rec()
        {
            clmrec_hdr_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmrec_zeroed_oma_suff_adj = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF);
            clmrec_zeroed_area = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_CD) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_ADJ_NBR));
            clmrec_hdr_batch_type = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_TYPE);
            clmrec_hdr_diag_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_DIAG_CD);
            clmrec_hdr_loc = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_LOC);
            clmrec_hdr_hosp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_HOSP);
            clmrec_hdr_payroll = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_HOSP);
            clmrec_hdr_agent_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_AGENT_CD);
            clmrec_hdr_i_o_pat_ind = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_I_O_PAT_IND);
            clmrec_hdr_ohip_id_or_chart = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_TYPE) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_DATA);
            clmrec_hdr_pat_acronym = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_ACRONYM6) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_ACRONYM3);

            clmrec_doc_dept_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_DOC_DEPT);
            //clmrec_hdr_date_claim = objClaims_mstr_dtl_rec.clmhdr_date
            clmrec_hdr_amt_tech_billed = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_AMT_TECH_BILLED);
            clmrec_hdr_amt_tech_paid = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_AMT_TECH_PAID);
            clmrec_hdr_tot_claim_ar_oma = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_TOT_CLAIM_AR_OMA);
            clmrec_hdr_tot_claim_ar_ohip = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            clmrec_hdr_manual_tape_pymnts = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            clmrec_hdr_status_ohip = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_STATUS_OHIP);

            clmrec_hdr_b_key_type = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_TYPE);
            clmrec_hdr_b_data_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_CLAIM_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_CD) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_ADJ_NBR);
            clmrec_hdr_b_batch_num = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR);
            clmrec_hdr_b_batch_nbr = clmrec_hdr_b_batch_num;
            clmrec_hdr_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmrec_hdr_b_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmrec_hdr_b_doc_nbr_r = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmrec_hdr_b_doc_nbr_2_4 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmrec_hdr_b_batch_number_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 3);
            clmrec_hdr_b_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmrec_hdr_b_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmrec_hdr_b_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_CLAIM_NBR);
            clmrec_hdr_b_oma_cd = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_CD);
            clmrec_hdr_b_oma_suff = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF);
            clmrec_hdr_b_adj_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_ADJ_NBR);
            clmrec_hdr_b_data_r = clmrec_hdr_b_data_grp;
            clmrec_hdr_b_pat_id = clmrec_hdr_b_data_grp.PadRight(16).Substring(0, 15);
        }

        private async Task Assign_ClaimsDetail_To_Claims_mstr_dtl_Rec()
        {
            clmrec_dtl_oma_cd = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_OMA_CD);
            clmrec_dtl_agent_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_AGENT_CD);
            clmrec_dtl_adj_cd = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_ADJ_CD);
            clmrec_dtl_nbr_serv = Util.NumInt(objClaims_mstr_dtl_rec.CLMDTL_NBR_SERV);
            clmrec_dtl_sv_date = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_YY).PadLeft(4, '0') + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_MM).PadLeft(2, '0') + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_DD).PadLeft(2, '0');
            clmdtl_consec_dates_grp = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_CONSEC_DATES_R);
            clmrec_dtl_sv_nbr[1] = Util.NumInt(Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(0, 1));
            clmdtl_sv_day[1] = Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(1, 2);
            clmrec_dtl_sv_nbr[2] = Util.NumInt(Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(3, 1));
            clmdtl_sv_day[2] = Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(4, 2);
            clmrec_dtl_sv_nbr[3] = Util.NumInt(Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(6, 1));
            clmdtl_sv_day[3] = Util.Str(clmdtl_consec_dates_grp).PadRight(9).Substring(7, 2);
            clmrec_dtl_amt_tech_billed = Util.NumDec(objClaims_mstr_dtl_rec.CLMDTL_AMT_TECH_BILLED);
            clmrec_dtl_fee_oma = Util.NumDec(objClaims_mstr_dtl_rec.CLMDTL_FEE_OMA);
            clmrec_dtl_fee_ohip = Util.NumDec(objClaims_mstr_dtl_rec.CLMDTL_FEE_OHIP);
        }

        private async Task Clmhdr_Record_To_ScreenVariables()
        {
            clmhdr_batch_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR);
            clmhdr_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).Substring(0, 2));
            clmhdr_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1));

            clmhdr_batch_nbr_3_6 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_batch_nbr_7_9 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 3));

            clmhdr_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_CLAIM_NBR);

            //clmhdr_zeroed_oma_suff_adj_grp
            clmhdr_adj_oma_cd = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_CD);
            clmhdr_adj_oma_suff = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF);
            clmhdr_adj_adj_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_ADJ_ADJ_NBR);

            clmhdr_batch_type = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_TYPE);
            clmhdr_adj_cd_sub_type = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_CD_SUB_TYPE);
            clmhdr_adj_cd_sub_type_ss = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_ADJ_CD_SUB_TYPE);

            clmhdr_doc_nbr_ohip = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_DOC_NBR_OHIP);
            clmhdr_doc_spec_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_DOC_SPEC_CD);
            clmhdr_refer_doc_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_REFER_DOC_NBR);
            clmhdr_diag_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_DIAG_CD);
            clmhdr_loc = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_LOC);
            clmhdr_hosp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_HOSP);
            clmhdr_payroll = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_HOSP);
            clmhdr_agent_cd = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_AGENT_CD);
            clmhdr_adj_cd = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_CD);
            clmhdr_tape_submit_ind = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_TAPE_SUBMIT_IND);
            clmhdr_i_o_pat_ind = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_I_O_PAT_IND);
            //clmhdr_pat_ohip_id_or_chart 
            clmhdr_pat_key_type = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_TYPE);
            clmhdr_pat_key_data_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_DATA);
            clmhdr_pat_key_ohip = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_KEY_DATA).PadRight(15, ' ').Substring(0, 8);
            //clmhdr_pat_acronym_grp 
            clmhdr_pat_acronym6 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_ACRONYM6).PadRight(9).Substring(0, 6);
            clmhdr_pat_acronym3 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_PAT_ACRONYM3);
            clmhdr_reference = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_REFERENCE);

            clmhdr_date_admit_yy = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(0, 4);
            clmhdr_date_admit_yy_r_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(0, 4);
            clmhdr_date_admit_yy_12 = clmhdr_date_admit_yy.Substring(0, 2);
            clmhdr_date_admit_yy_34 = clmhdr_date_admit_yy.Substring(2, 2);
            clmhdr_date_admit_mm = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(4, 2));
            clmhdr_date_admit_dd_r = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(4, 2);
            clmhdr_date_admit_dd = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(6, 2));
            clmhdr_date_admit_dd_r = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT).PadRight(8).Substring(6, 2);
            clmhdr_date_admit_r = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_ADMIT));
            clmhdr_doc_dept = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_DOC_DEPT);
            clmhdr_date_cash_tape_payment = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_MSG_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_REPRINT_FLAG) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SUB_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_AUTO_LOGOUT) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_FEE_COMPLEX) + Util.Str(objClaims_mstr_dtl_rec.FILLER).PadRight(2);
            clmhdr_curr_payment = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_CURR_PAYMENT);
            clmhdr_date_period_end_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_PERIOD_END);
            clmhdr_period_end_yy = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_PERIOD_END).Substring(0, 4));
            clmhdr_period_end_mm = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_PERIOD_END).Substring(4, 2));
            clmhdr_period_end_dd = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_PERIOD_END).Substring(6, 2));
            clmhdr_cycle_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_CYCLE_NBR);
            clmhdr_date_sys = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_DATE_SYS);
            clmhdr_amt_tech_billed = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_AMT_TECH_BILLED);
            clmhdr_amt_tech_paid = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_AMT_TECH_PAID);
            clmhdr_tot_claim_ar_oma = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_TOT_CLAIM_AR_OMA);
            clmhdr_tot_claim_ar_ohip = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            clmhdr_manual_and_tape_paymnts = Util.NumDec(objClaims_mstr_dtl_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            clmhdr_status_ohip = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_STATUS_OHIP);
            clmhdr_manual_review = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_MANUAL_REVIEW);
            clmhdr_submit_date_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SUBMIT_DATE);
            clmhdr_submit_yy = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SUBMIT_DATE).PadRight(8).Substring(0, 4));
            clmhdr_submit_mm = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SUBMIT_DATE).PadRight(8).Substring(4, 2));
            clmhdr_submit_dd = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SUBMIT_DATE).PadRight(8).Substring(6, 2));
            clmhdr_confidential_flag = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_CONFIDENTIAL_FLAG);
            clmhdr_serv_date = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_SERV_DATE);
            clmhdr_elig_error = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ELIG_ERROR);
            clmhdr_elig_status = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ELIG_STATUS);
            clmhdr_serv_error = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SERV_ERROR);
            clmhdr_serv_status = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_SERV_STATUS);
            clmhdr_orig_batch_id_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_batch_nbr_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_batch_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmhdr_orig_batch_nbr_4_9 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(2, 6);
            clmhdr_orig_batch_nbr_next_def_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_batch_nbr_4_6 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_orig_batch_nbr_7_8 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_orig_batch_nbr_9 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmhdr_orig_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_ORIG_CLAIM_NBR);
            clmhdr_orig_batch_id_r_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_orig_complete_batch_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ORIG_BATCH_NBR);
            clmhdr_b_key_type = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_TYPE);
            clmhdr_b_data_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_CLAIM_NBR) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_CD) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF) + Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_ADJ_NBR);
            clmhdr_b_batch_num = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR);
            clmhdr_b_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).Substring(0, 2));
            clmhdr_b_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).Substring(2, 3);
            clmhdr_b_doc_nbr_r_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).Substring(2, 3);
            clmhdr_b_doc_nbr_2_4 = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).Substring(2, 3);
            clmhdr_b_batch_number_grp = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR);
            clmhdr_b_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_b_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmhdr_b_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.CLMHDR_CLAIM_NBR);
            clmhdr_b_oma_cd = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_CD);
            clmhdr_b_oma_suff = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF);
            clmhdr_b_adj_nbr = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_ADJ_NBR);
            clmhdr_b_data_r_grp = Util.Str(clmhdr_b_data_grp).PadRight(15);
            clmhdr_b_pat_id = clmhdr_b_data_r_grp.Substring(0, 15);
            // clmhdr_p_claims_mstr_grp
            clmhdr_p_key_type = Util.Str(objClaims_mstr_dtl_rec.KEY_P_CLM_TYPE);
            clmhdr_p_data_grp = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR) + Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_CLAIM_NBR) + Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_SERV_CODE) + Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_ADJ_NBR);
            clmhdr_p_batch_nbr_grp = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR);
            clmhdr_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmhdr_p_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmhdr_p_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmhdr_p_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmhdr_p_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.KEY_CLM_CLAIM_NBR);
            clmhdr_p_oma_cd = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_SERV_CODE); // todo....not sure...???
            clmhdr_p_oma_suff = Util.Str(objClaims_mstr_dtl_rec.CLMHDR_ADJ_OMA_SUFF);  // todo... not surel....???
            clmhdr_p_adj_nbr = objClaims_mstr_dtl_rec.KEY_CLM_ADJ_NBR;
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
            clmdtl_sv_date_grp = Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_YY).PadLeft(4, '0') + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_MM).PadLeft(2, '0') + Util.Str(objClaims_mstr_dtl_rec.CLMDTL_SV_DD).PadLeft(2, '0');
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
            clmdtl_p_data_grp = Util.Str(objClaims_mstr_dtl_rec.KEY_P_CLM_DATA);
            /*clmdtl_p_batch_nbr_grp = Util.Str(clmdtl_p_data_grp).PadRight(16).Substring(0, 8);
            clmdtl_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(clmdtl_p_batch_nbr_grp).PadRight(8).Substring(0, 2));
            clmdtl_p_doc_nbr = Util.Str(clmdtl_p_batch_nbr_grp).PadRight(8).Substring(2, 3);
            clmdtl_p_week = Util.NumInt(Util.Str(clmdtl_p_batch_nbr_grp).PadRight(8).Substring(5, 2));
            clmdtl_p_day = Util.NumInt(Util.Str(clmdtl_p_batch_nbr_grp).PadRight(8).Substring(7, 1));

            clmdtl_p_claim_nbr = Util.NumInt(Util.Str(clmdtl_p_data_grp).PadRight(16).Substring(8, 2));
            clmdtl_p_oma_cd = Util.Str(clmdtl_p_data_grp).PadRight(16).Substring(10, 4);
            clmdtl_p_oma_suff = Util.Str(clmdtl_p_data_grp).PadRight(16).Substring(14, 1);
            clmdtl_p_adj_nbr = Util.Str(clmdtl_p_data_grp).PadRight(16).Substring(15, 1); */

            clmdtl_p_batch_nbr_grp = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR);
            clmdtl_p_clinic_nbr_1_2 = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(0, 2));
            clmdtl_p_doc_nbr = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(2, 3);
            clmdtl_p_week = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(5, 2));
            clmdtl_p_day = Util.NumInt(Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR).PadRight(8).Substring(7, 1));
            clmdtl_p_claim_nbr = Util.NumInt(objClaims_mstr_dtl_rec.KEY_CLM_CLAIM_NBR);
            //clmdtl_p_oma_cd =    //todo...??
            //clmdtl_p_oma_suff =  //todo...??
            clmdtl_p_adj_nbr = Util.Str(objClaims_mstr_dtl_rec.KEY_CLM_ADJ_NBR);
        }

        private async Task<string> Assign_Claims_mstr_Rec_To_GroupName()
        {
            return claims_mstr_hdr_rec_grp = Util.Str(clmrec_hdr_clinic_nbr_1_2).PadLeft(2, '0') +    
                                       new string(' ', 8) +
                                     Util.Str(clmrec_zeroed_oma_suff_adj).PadRight(6) +   
                                     Util.Str(clmrec_hdr_batch_type).PadRight(1) +  
                                       new string(' ', 15) +
                                    Util.Str(clmrec_hdr_diag_cd).PadLeft(3, '0') + 
                                    Util.Str(clmrec_hdr_loc).PadRight(4) +  
                                    Util.Str(clmrec_hdr_hosp).PadRight(1) + 

                                    Util.Str(clmrec_hdr_agent_cd).PadLeft(1, '0') + 
                                     new string(' ', 2) +
                                    Util.Str(clmrec_hdr_i_o_pat_ind).PadRight(1) +  
                                    Util.Str(clmrec_hdr_ohip_id_or_chart).PadRight(16) + 
                                    Util.Str(clmrec_hdr_pat_acronym).PadRight(9) +  
                                    new string(' ', 19) +
                                    Util.Str(clmrec_doc_dept_nbr).PadLeft(2, '0') +  
                                    new string(' ', 25) +
                                    Util.Str(clmrec_hdr_date_claim).PadRight(8) + 
                                   Util.Str(clmrec_hdr_amt_tech_billed).PadLeft(6, '0') + 
                                   Util.Str(clmrec_hdr_amt_tech_paid).PadLeft(6, '0') + 
                                   Util.Str(clmrec_hdr_tot_claim_ar_oma).PadLeft(7, '0') + 
                                   Util.Str(clmrec_hdr_tot_claim_ar_ohip).PadLeft(7, '0') + 
                                   Util.Str(clmrec_hdr_manual_tape_pymnts).PadLeft(7, '0') + 
                                   Util.Str(clmrec_hdr_status_ohip).PadRight(2) + 
                                   new string(' ', 36) +
                                   Util.Str(clmrec_hdr_b_key_type).PadRight(1) +
                                   Util.Str(clmrec_hdr_b_batch_num).PadRight(8) +
                                   Util.Str(clmrec_hdr_b_claim_nbr).PadLeft(2, '0') +
                                   Util.Str(clmrec_hdr_b_oma_cd).PadLeft(4) +    // pic x999
                                   Util.Str(clmrec_hdr_b_oma_suff).PadRight(1) +
                                   Util.Str(clmrec_hdr_b_adj_nbr).PadRight(1);
        }

        private async Task<bool> Write_Claims_Hdr_Rec()
        {
            try
            {
                //  write claims-mstr-rec  from  claim-header-rec;

                F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR = null;
                objF002_CLAIMS_MSTR_HDR = new F002_CLAIMS_MSTR_HDR();

                objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_NBR = Util.Str(clmhdr_batch_nbr); 
                objF002_CLAIMS_MSTR_HDR.CLMHDR_CLAIM_NBR = Util.NumInt(clmhdr_claim_nbr);     
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_CD = Util.Str(clmhdr_adj_oma_cd); //Util.Str(clmrec_hdr_b_oma_cd);  
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_SUFF = Util.Str(clmhdr_adj_oma_suff);  //Util.Str(clmrec_hdr_b_oma_suff); 
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_ADJ_NBR = Util.Str(clmhdr_adj_adj_nbr); // Util.Str(clmrec_hdr_b_adj_nbr); 
                objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_TYPE = Util.Str(clmhdr_batch_type);  //Util.Str(clmrec_hdr_batch_type); 
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE = Util.Str(clmhdr_adj_cd_sub_type);
                clmhdr_adj_cd_sub_type = Util.Str(clmhdr_adj_cd_sub_type_ss);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_NBR_OHIP = Util.NumInt(clmhdr_doc_nbr_ohip);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_SPEC_CD = Util.NumInt(clmhdr_doc_spec_cd);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_REFER_DOC_NBR = Util.NumInt(clmhdr_refer_doc_nbr);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DIAG_CD = Util.NumInt(clmrec_hdr_diag_cd);  //Util.NumInt(clmhdr_diag_cd);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_LOC = Util.Str(clmhdr_loc);  //Util.Str(clmrec_hdr_loc); 
                objF002_CLAIMS_MSTR_HDR.CLMHDR_HOSP = Util.Str(clmrec_hdr_hosp);  //Util.Str(clmhdr_hosp);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_AGENT_CD = Util.NumInt(clmhdr_agent_cd);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD = Util.Str(clmhdr_adj_cd);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_TAPE_SUBMIT_IND = Util.Str(clmhdr_tape_submit_ind);
                objF002_CLAIMS_MSTR_HDR.WhereClmhdr_i_o_pat_ind = Util.Str(clmrec_hdr_i_o_pat_ind);  // Util.Str(clmhdr_i_o_pat_ind);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_KEY_TYPE = Util.Str(clmrec_hdr_ohip_id_or_chart).PadRight(16).Substring(0, 1); //Util.Str(clmhdr_pat_key_type);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_KEY_DATA = Util.Str(clmrec_hdr_ohip_id_or_chart).PadRight(16).Substring(1, 15);  //Util.Str(clmhdr_pat_key_data_grp);
                //filler            
                objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_ACRONYM6 = Util.Str(clmrec_hdr_pat_acronym).PadRight(9).Substring(0, 6);  // Util.Str(clmhdr_pat_acronym_grp).PadRight(9).Substring(0, 6);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_ACRONYM3 = Util.Str(clmrec_hdr_pat_acronym).PadRight(9).Substring(6, 3);  //Util.Str(clmhdr_pat_acronym_grp).PadRight(9).Substring(6, 3);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_REFERENCE = Util.Str(clmhdr_reference);

                clmhdr_date_admit_grp = Util.Str(clmhdr_date_admit_yy).PadLeft(4, '0') + Util.Str(clmhdr_date_admit_mm).PadLeft(2, '0') + Util.Str(clmhdr_date_admit_dd).PadLeft(2, '0');
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT = Util.Str(clmhdr_date_admit_grp);
                //objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT = Util.Str(Util.NumDec(clmhdr_date_admit_r));
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT = Util.NumInt(clmhdr_doc_dept);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_MSG_NBR = Util.Str(clmhdr_msg_nbr);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_REPRINT_FLAG = Util.Str(clmhdr_reprint_flag);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_SUB_NBR = Util.Str(clmhdr_sub_nbr);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_AUTO_LOGOUT = Util.Str(clmhdr_auto_logout);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_FEE_COMPLEX = Util.Str(clmhdr_fee_complex);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_CURR_PAYMENT = Util.NumDec(clmhdr_curr_payment);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END = Util.NumDec(clmhdr_date_period_end_grp);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_CYCLE_NBR = Util.NumDec(clmhdr_cycle_nbr);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS = Util.Str(clmhdr_date_sys);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_BILLED = Util.NumDec(clmrec_hdr_amt_tech_billed);  // Util.NumDec(clmhdr_amt_tech_billed);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_PAID = Util.NumDec(clmrec_hdr_amt_tech_paid);  //Util.NumDec(clmhdr_amt_tech_paid);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OMA = Util.NumDec(clmhdr_tot_claim_ar_oma);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP = Util.NumDec(clmhdr_tot_claim_ar_ohip);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS = Util.NumDec(clmrec_hdr_manual_tape_pymnts);  //clmhdr_manual_and_tape_paymnts;
                objF002_CLAIMS_MSTR_HDR.CLMHDR_STATUS_OHIP = Util.Str(clmrec_hdr_status_ohip); // Util.Str(clmhdr_status_ohip);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_REVIEW = Util.Str(clmhdr_manual_review);

                clmhdr_submit_date_grp = Util.Str(clmhdr_submit_yy).PadLeft(4, '0') + Util.Str(clmhdr_submit_mm).PadLeft(2, '0') + Util.Str(clmhdr_submit_dd).PadLeft(2, '0');
                objF002_CLAIMS_MSTR_HDR.CLMHDR_SUBMIT_DATE = Util.NumDec(clmhdr_submit_date_grp);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_CONFIDENTIAL_FLAG = Util.Str(clmhdr_confidential_flag);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_DATE = Util.NumInt(clmhdr_serv_date);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ELIG_ERROR = Util.Str(clmhdr_elig_error);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ELIG_STATUS = Util.Str(clmhdr_elig_status);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_ERROR = Util.Str(clmhdr_serv_error);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_STATUS = Util.Str(clmhdr_serv_status);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_BATCH_NBR = Util.Str(clmhdr_orig_batch_nbr_grp);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_CLAIM_NBR = Util.NumDec(clmhdr_orig_claim_nbr);                

                objF002_CLAIMS_MSTR_HDR.KEY_CLM_TYPE = Util.Str(clmrec_hdr_b_key_type);  // Util.Str(clmhdr_b_key_type);                
                objF002_CLAIMS_MSTR_HDR.KEY_P_CLM_TYPE = Util.Str(clmhdr_p_key_type);
                objF002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR = Util.Str(clmhdr_orig_batch_nbr_grp);
                objF002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR = Util.NumDec(clmhdr_orig_claim_nbr);
                objF002_CLAIMS_MSTR_HDR.KEY_CLM_ADJ_NBR = Util.Str(clmrec_hdr_b_adj_nbr); //Util.Str(clmhdr_p_adj_nbr);
                objF002_CLAIMS_MSTR_HDR.KEY_CLM_SERV_CODE = "0000";

                objF002_CLAIMS_MSTR_HDR.RecordState = State.Added;
                objF002_CLAIMS_MSTR_HDR.Submit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> Write_Claims_Dtl_Rec()
        {
            try
            {
                F002_CLAIMS_MSTR_DTL objClaims_mstr_dtl_rec = null;
                objClaims_mstr_dtl_rec = new F002_CLAIMS_MSTR_DTL();

                objClaims_mstr_dtl_rec.CLMDTL_BATCH_NBR = Util.Str(clmdtl_batch_nbr);  
                objClaims_mstr_dtl_rec.CLMDTL_CLAIM_NBR = Util.NumInt(clmdtl_claim_nbr);    
                objClaims_mstr_dtl_rec.CLMDTL_OMA_CD = Util.Str(clmdtl_oma_cd);
                objClaims_mstr_dtl_rec.CLMDTL_OMA_SUFF = Util.Str(clmdtl_oma_suff);
                objClaims_mstr_dtl_rec.CLMDTL_ADJ_NBR = Util.NumDec(clmdtl_adj_nbr);
                objClaims_mstr_dtl_rec.CLMDTL_REV_GROUP_CD = Util.Str(clmdtl_rev_group_cd);
                objClaims_mstr_dtl_rec.CLMDTL_AGENT_CD = Util.NumDec(clmdtl_agent_cd);
                objClaims_mstr_dtl_rec.CLMDTL_ADJ_CD =  Util.Str(clmdtl_adj_cd);
                objClaims_mstr_dtl_rec.CLMDTL_NBR_SERV = Util.NumDec(clmdtl_nbr_serv);
                objClaims_mstr_dtl_rec.CLMDTL_SV_YY = Util.NumDec(clmdtl_sv_yy);
                objClaims_mstr_dtl_rec.CLMDTL_SV_MM = Util.NumDec(clmdtl_sv_mm);
                objClaims_mstr_dtl_rec.CLMDTL_SV_DD = Util.NumDec(clmdtl_sv_dd);
                objClaims_mstr_dtl_rec.CLMDTL_CONSEC_DATES_R = Util.Str(clmdtl_consec_dates_grp);

                objClaims_mstr_dtl_rec.CLMDTL_AMT_TECH_BILLED = Util.NumDec(clmrec_dtl_amt_tech_billed);  //Util.NumDec(clmdtl_amt_tech_billed);
                objClaims_mstr_dtl_rec.CLMDTL_FEE_OMA = Util.NumDec(clmdtl_fee_oma);
                objClaims_mstr_dtl_rec.CLMDTL_FEE_OHIP = Util.NumDec(clmdtl_fee_ohip);
                objClaims_mstr_dtl_rec.CLMDTL_DATE_PERIOD_END = Util.Str(clmdtl_date_period_end);
                objClaims_mstr_dtl_rec.CLMDTL_CYCLE_NBR = Util.NumDec(clmdtl_cycle_nbr);
                objClaims_mstr_dtl_rec.CLMDTL_DIAG_CD = Util.NumDec(clmdtl_diag_cd);
                objClaims_mstr_dtl_rec.CLMDTL_LINE_NO = Util.NumDec(clmdtl_line_no);
                objClaims_mstr_dtl_rec.CLMDTL_RESUBMIT_FLAG = Util.Str(clmdtl_resubmit_flag);
                objClaims_mstr_dtl_rec.CLMDTL_RESERVE_FOR_FUTURE = Util.Str(clmdtl_reserve_for_future);
                objClaims_mstr_dtl_rec.CLMDTL_DESC = Util.Str(clmdtl_desc);
                objClaims_mstr_dtl_rec.CLMDTL_FILLER9 = Util.Str(clmdtl_filler);

                objClaims_mstr_dtl_rec.CLMDTL_ORIG_BATCH_NBR = Util.Str(clmhdr_orig_batch_nbr_grp);
                objClaims_mstr_dtl_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = Util.NumInt(clmhdr_orig_claim_nbr);
                objClaims_mstr_dtl_rec.KEY_CLM_TYPE = Util.Str(clmdtl_b_key_type);                

                objClaims_mstr_dtl_rec.KEY_P_CLM_TYPE = Util.Str(clmdtl_p_key_type);
                objClaims_mstr_dtl_rec.KEY_P_CLM_DATA = Util.Str(clmdtl_p_data_grp);
                objClaims_mstr_dtl_rec.KEY_CLM_BATCH_NBR = Util.Str(clmhdr_orig_batch_nbr_grp);
                objClaims_mstr_dtl_rec.KEY_CLM_CLAIM_NBR = Util.NumInt(clmhdr_orig_claim_nbr);

                objClaims_mstr_dtl_rec.KEY_CLM_ADJ_NBR = clmdtl_b_adj_nbr;  //clmdtl_p_adj_nbr;
                objClaims_mstr_dtl_rec.RecordState = State.Added;
                objClaims_mstr_dtl_rec.Submit();

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> Rewrite_Claims_Hdr_Rec()
        {
            try
            {
                // rewrite claims-mstr-rec		from claim-header-rec;
                F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR = new F002_CLAIMS_MSTR_HDR
                {
                    WhereRowid = objClaims_mstr_dtl_rec.ROWID_HDR
                }.Collection().FirstOrDefault();

                objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OMA = clmhdr_tot_claim_ar_oma;
                objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP = Util.NumDec(clmhdr_tot_claim_ar_ohip);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_BILLED = Util.NumDec(clmhdr_amt_tech_billed);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS = Util.NumDec(clmhdr_manual_and_tape_paymnts);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_CURR_PAYMENT = Util.NumDec(clmhdr_curr_payment);
                objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_PAID = Util.NumDec(clmhdr_amt_tech_paid);

                /*  objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_NBR = Util.Str(clmhdr_batch_nbr);               
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_CLAIM_NBR = Util.NumDec(clmhdr_claim_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_CD = Util.Str(clmhdr_adj_oma_cd);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_SUFF = Util.Str(clmhdr_adj_oma_suff);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_ADJ_NBR = Util.Str(clmhdr_adj_adj_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_TYPE = Util.Str(clmhdr_batch_type);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE = Util.Str(clmhdr_adj_cd_sub_type);
                  clmhdr_adj_cd_sub_type = Util.Str(clmhdr_adj_cd_sub_type_ss);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_NBR_OHIP = Util.NumInt(clmhdr_doc_nbr_ohip);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_SPEC_CD = Util.NumDec(clmhdr_doc_spec_cd);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_REFER_DOC_NBR = Util.NumDec(clmhdr_refer_doc_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DIAG_CD = Util.NumDec(clmhdr_diag_cd);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_LOC = Util.Str(clmhdr_loc);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_HOSP = Util.Str(clmhdr_hosp);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_AGENT_CD = Util.NumInt(clmhdr_agent_cd);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD = Util.Str(clmhdr_adj_cd);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_TAPE_SUBMIT_IND = Util.Str(clmhdr_tape_submit_ind);
                  objF002_CLAIMS_MSTR_HDR.WhereClmhdr_i_o_pat_ind = Util.Str(clmhdr_i_o_pat_ind);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_KEY_TYPE = Util.Str(clmhdr_pat_key_type);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_KEY_DATA = Util.Str(clmhdr_pat_key_data_grp);

                  objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_ACRONYM6 = Util.Str(clmhdr_pat_acronym_grp).PadRight(9).Substring(0, 6);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_ACRONYM3 = Util.Str(clmhdr_pat_acronym_grp).PadRight(9).Substring(6, 3);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_REFERENCE = clmhdr_reference;

                  clmhdr_date_admit_grp = Util.Str(clmhdr_date_admit_yy).PadLeft(4, '0') + Util.Str(clmhdr_date_admit_mm).PadLeft(2, '0') + Util.Str(clmhdr_date_admit_dd).PadLeft(2, '0');
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT = Util.Str(clmhdr_date_admit_grp);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT = Util.Str(Util.NumDec(clmhdr_date_admit_r));
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT = Util.NumInt(clmhdr_doc_dept);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_MSG_NBR = Util.Str(clmhdr_msg_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_REPRINT_FLAG = Util.Str(clmhdr_reprint_flag);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_SUB_NBR = Util.Str(clmhdr_sub_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_AUTO_LOGOUT = Util.Str(clmhdr_auto_logout);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_FEE_COMPLEX = Util.Str(clmhdr_fee_complex);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_CURR_PAYMENT = Util.NumDec(clmhdr_curr_payment);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END = Util.NumDec(clmhdr_date_period_end_grp);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_CYCLE_NBR = Util.NumDec(clmhdr_cycle_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS = Util.Str(clmhdr_date_sys);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_BILLED = Util.NumDec(clmhdr_amt_tech_billed);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_PAID = Util.NumDec(clmhdr_amt_tech_paid);
                  //objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OMA = clmhdr_tot_claim_ar_oma;
                 // objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP = Util.NumDec(clmhdr_tot_claim_ar_ohip);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS = Util.NumDec(clmhdr_manual_and_tape_paymnts);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_STATUS_OHIP = Util.Str(clmhdr_status_ohip);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_REVIEW = Util.Str(clmhdr_manual_review);

                  clmhdr_submit_date_grp = Util.Str(clmhdr_submit_yy).PadLeft(4, '0') + Util.Str(clmhdr_submit_mm).PadLeft(2, '0') + Util.Str(clmhdr_submit_dd).PadLeft(2, '0');
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_SUBMIT_DATE = Util.NumDec(clmhdr_submit_date_grp);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_CONFIDENTIAL_FLAG = Util.Str(clmhdr_confidential_flag);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_DATE = Util.NumInt(clmhdr_serv_date);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ELIG_ERROR = Util.Str(clmhdr_elig_error);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ELIG_STATUS = Util.Str(clmhdr_elig_status);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_ERROR = Util.Str(clmhdr_serv_error);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_STATUS = Util.Str(clmhdr_serv_status);                
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_BATCH_NBR = Util.Str(clmhdr_orig_batch_nbr_grp);               
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_CLAIM_NBR = Util.NumDec(clmhdr_orig_claim_nbr);                

                  objF002_CLAIMS_MSTR_HDR.KEY_CLM_TYPE = Util.Str(clmhdr_b_key_type);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_NBR = Util.Str(clmhdr_b_batch_num);               
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_CLAIM_NBR = Util.NumDec(clmhdr_b_claim_nbr);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_CD = Util.Str(clmhdr_b_oma_cd);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_SUFF = Util.Str(clmhdr_b_oma_suff);
                  objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_ADJ_NBR = Util.Str(clmhdr_b_adj_nbr);

                  objF002_CLAIMS_MSTR_HDR.KEY_P_CLM_TYPE = Util.Str(clmhdr_p_key_type);
                  objF002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR = Util.Str(clmhdr_batch_nbr);  //Util.Str(clmhdr_p_batch_nbr_grp);                

                  objF002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR = Util.NumDec(clmhdr_p_claim_nbr);  // todo:  ????                
                  objF002_CLAIMS_MSTR_HDR.KEY_CLM_ADJ_NBR = Util.Str(clmhdr_p_adj_nbr);   // todo:  ???? */

                objF002_CLAIMS_MSTR_HDR.RecordState = State.Modified;
                objF002_CLAIMS_MSTR_HDR.Submit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private async Task assign_variable_to_batctrl()
        {
            objBatctrl_rec.BATCTRL_BATCH_NBR = Util.Str(batctrl_batch_nbr);
            objBatctrl_rec.BATCTRL_BATCH_TYPE = Util.Str(batctrl_batch_type);
            objBatctrl_rec.BATCTRL_ADJ_CD = Util.Str(batctrl_adj_cd);
            objBatctrl_rec.BATCTRL_ADJ_CD_SUB_TYPE = Util.Str(batctrl_adj_cd_sub_type);
            objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR = Util.NumInt(batctrl_last_claim_nbr);
            objBatctrl_rec.BATCTRL_CLINIC_NBR = Util.Str(batctrl_clinic_nbr);
            objBatctrl_rec.BATCTRL_DOC_NBR_OHIP = Util.NumInt(batctrl_doc_nbr_ohip);
            objBatctrl_rec.BATCTRL_HOSP = Util.Str(batctrl_hosp);
            objBatctrl_rec.BATCTRL_LOC = Util.Str(batctrl_loc);
            objBatctrl_rec.BATCTRL_AGENT_CD = Util.NumInt(batctrl_agent_cd);
            objBatctrl_rec.BATCTRL_I_O_PAT_IND = Util.Str(batctrl_i_o_pat_ind);
            objBatctrl_rec.BATCTRL_DATE_BATCH_ENTERED = Util.Str(batctrl_date_batch_entered);
            objBatctrl_rec.BATCTRL_DATE_PERIOD_END = Util.Str(batctrl_date_period_end_yy).PadLeft(4, '0') + Util.Str(batctrl_date_period_end_mm).PadLeft(2, '0') + Util.Str(batctrl_date_period_end_dd).PadLeft(2, '0');
            objBatctrl_rec.BATCTRL_CYCLE_NBR = Util.NumInt(batctrl_cycle_nbr);
            objBatctrl_rec.BATCTRL_AMT_EST = Util.NumDec(batctrl_amt_est);
            objBatctrl_rec.BATCTRL_AMT_ACT = Util.NumDec(batctrl_amt_act);
            objBatctrl_rec.BATCTRL_SVC_EST = Util.NumDec(batctrl_svc_est);
            objBatctrl_rec.BATCTRL_SVC_ACT = Util.NumDec(batctrl_svc_act);
            objBatctrl_rec.BATCTRL_AR_YY_MM = Util.Str(batctrl_ar_yy_mm);
            objBatctrl_rec.BATCTRL_CALC_AR_DUE = Util.NumDec(batctrl_calc_ar_due);
            objBatctrl_rec.BATCTRL_CALC_TOT_REV = Util.NumDec(batctrl_calc_tot_rev);
            objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT = Util.NumDec(batctrl_manual_pay_tot);
            objBatctrl_rec.BATCTRL_BATCH_STATUS = Util.Str(batctrl_batch_status);
            objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH = Util.NumDec(batctrl_nbr_claims_in_batch);
        }

        private async Task assign_batchcontrol_to_screen_variables()
        {
            batctrl_batch_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR);
            batctrl_batch_type = Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE);
            batctrl_adj_cd = Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD);
            batctrl_adj_cd_sub_type = Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD_SUB_TYPE);
            batctrl_last_claim_nbr = Util.NumInt(objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR);
            batctrl_clinic_nbr = Util.Str(objBatctrl_rec.BATCTRL_CLINIC_NBR);
            batctrl_doc_nbr_ohip = Util.NumInt(objBatctrl_rec.BATCTRL_DOC_NBR_OHIP);
            batctrl_hosp = Util.Str(objBatctrl_rec.BATCTRL_HOSP);
            batctrl_loc = Util.Str(objBatctrl_rec.BATCTRL_LOC);
            batctrl_agent_cd = Util.NumInt(objBatctrl_rec.BATCTRL_AGENT_CD);
            batctrl_i_o_pat_ind = Util.Str(objBatctrl_rec.BATCTRL_I_O_PAT_IND);
            batctrl_date_batch_entered = Util.Str(objBatctrl_rec.BATCTRL_DATE_BATCH_ENTERED);
            batctrl_date_period_end_yy = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadLeft(4, '0').Substring(0, 4));
            batctrl_date_period_end_mm = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadLeft(4, '0').Substring(4, 2));
            batctrl_date_period_end_dd = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadLeft(4, '0').Substring(6, 2));
            batctrl_cycle_nbr = Util.NumInt(objBatctrl_rec.BATCTRL_CYCLE_NBR);
            batctrl_amt_est = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_EST);
            batctrl_amt_act = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_ACT);
            batctrl_svc_est = Util.NumInt(objBatctrl_rec.BATCTRL_SVC_EST);
            batctrl_svc_act = Util.NumInt(objBatctrl_rec.BATCTRL_SVC_ACT);
            batctrl_ar_yy_mm = Util.Str(objBatctrl_rec.BATCTRL_AR_YY_MM);
            batctrl_calc_ar_due = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);
            batctrl_calc_tot_rev = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
            batctrl_manual_pay_tot = Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
            batctrl_batch_status = Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS);
            batctrl_nbr_claims_in_batch = Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH);
        }

        #endregion

        private async Task Exit_Trakker()
        {
            if (IsExitForm) await az0_10();
        }

        public async Task destroy_objects()
        {
            objBatctrl_rec = null;
            Batctrl_rec_Collection = null;
            objClaims_mstr_dtl_rec = null;
            Claims_mstr_dtl_rec_Collection = null;
            objLoc_mstr_rec = null;
            Loc_mstr_rec_Collection = null;
            objFee_mstr_rec = null;
            Fee_mstr_rec_Collection = null;
            objIconst_mstr_rec = null;
            Iconst_mstr_rec_Collection = null;
            objConstants_mstr_rec_3 = null;
            Constants_mstr_rec_3_Collection = null;
        }
    }
}

