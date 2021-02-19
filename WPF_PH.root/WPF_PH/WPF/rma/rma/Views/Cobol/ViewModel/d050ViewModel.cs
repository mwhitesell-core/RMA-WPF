using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Core.Windows.UI;
using rma.Cobol.Includes;
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
    public class D050ViewModel: CommonFunctionScr
    {         
       /* public D050ViewModel(Grid grid):base(grid)
        {
            ScreenDataCollection = ScreenSection();
            GridAddControl();
            isBatchProcess = false;
            mainline();
        } */

        public D050ViewModel()
        {

        }
        public D050ViewModel(string ws_request_clinic_nbr,
                              string ws_dept,
                              string ws_doc_nbr,
                              string ws_loc_1,
                              string ws_loc_2,
                              string ws_loc_3,
                              string ws_loc_4,
                              string ws_loc_5,
                              string ws_oma_cd_1,
                              string ws_oma_cd_2,
                              string flag_user_resp)           
        {
            isBatchProcess = true;
            mainline(ws_request_clinic_nbr,
                     ws_dept,
                     ws_doc_nbr,
                     ws_loc_1,
                     ws_loc_2,
                     ws_loc_3,
                     ws_loc_4,
                     ws_loc_5,
                     ws_oma_cd_1,
                     ws_oma_cd_2,
                    flag_user_resp);

        }

        #region FD Section
        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private Doc_Mstr_Rec objDoc_mstr_rec = null;
        private ObservableCollection<Doc_Mstr_Rec> Doc_mstr_rec_Collection;

        // FD: loc_mstr	Copy : f030_locations_mstr.fd
        private Loc_mstr_rec objLoc_mstr_rec = null;
        private ObservableCollection<Loc_mstr_rec> Loc_mstr_rec_Collection;

        // FD: docrev_mstr	Copy : f050_doc_revenue_mstr.fd
        private Docrev_master_rec objDocrev_master_rec = null;
        private ObservableCollection<Docrev_master_rec> Docrev_master_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        //private Iconst_mstr_rec objIconst_mstr_rec = null;
        //private ObservableCollection<Iconst_mstr_rec> Iconst_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private Dept_Mstr_Rec objDept_mstr_rec = null;
        private ObservableCollection<Dept_Mstr_Rec> Dept_mstr_rec_Collection;

        private CONSTANTS_MSTR_REC_3 objConstants_mstr_rec_3 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_3> Constants_mstr_rec_3_Collection;

        private F020_DOCTOR_MSTR objF020_DOCTOR_MSTR = null;
        private ObservableCollection<F020_DOCTOR_MSTR> F020_DOCTOR_MSTR_Collection;

        private F070_DEPT_MSTR objF070_DEPT_MSTR = null;
        private ObservableCollection<F070_DEPT_MSTR> F070_DEPT_MSTR_Collection;

        private F030_LOCATIONS_MSTR objF030_LOCATIONS_MSTR = null;
        private ObservableCollection<F030_LOCATIONS_MSTR> F030_LOCATIONS_MSTR_Collection;

        private F050_DOC_REVENUE_MSTR objF050_DOC_REVENUE_MSTR = null;
        private ObservableCollection<F050_DOC_REVENUE_MSTR> F050_DOC_REVENUE_MSTR_Collection;

        #endregion

        #region Properties
        private int __sys_yy;
        public int sys_yy
        {
            get
            {
                return __sys_yy;
            }
            set
            {
                if (__sys_yy != value)
                {
                    __sys_yy = value;
                    RaisePropertyChanged("sys_yy");
                }
            }
        }

        private int __sys_mm;
        public int sys_mm
        {
            get
            {
                return __sys_mm;
            }
            set
            {
                if (__sys_mm != value)
                {
                    __sys_mm = value;
                    RaisePropertyChanged("sys_mm");
                }
            }
        }

        private int __sys_dd;
        public int sys_dd
        {
            get
            {
                return __sys_dd;
            }
            set
            {
                if (__sys_dd != value)
                {
                    __sys_dd = value;
                    RaisePropertyChanged("sys_dd");
                }
            }
        }

        private string _flag_user_resp;
        public string flag_user_resp
        {
            get
            {
                return _flag_user_resp;
            }
            set
            {
                if (_flag_user_resp != value)
                {
                    _flag_user_resp = value;
                    RaisePropertyChanged("flag_user_resp");
                }
            }
        }

        private string __flag;
        public string flag
        {
            get
            {
                return __flag;
            }
            set
            {
                if (__flag != value)
                {
                    __flag = value;
                    RaisePropertyChanged("flag");
                }
            }
        }

        private string _ws_request_clinic_nbr;
        public string ws_request_clinic_nbr
        {
            get
            {
                return _ws_request_clinic_nbr;
            }
            set
            {
                if (_ws_request_clinic_nbr != value)
                {
                    _ws_request_clinic_nbr = value;
                    RaisePropertyChanged("ws_request_clinic_nbr");
                }
            }
        }

        private string _ws_dept;
        public string ws_dept
        {
            get
            {
                return _ws_dept;
            }
            set
            {
                if (_ws_dept != value)
                {
                    _ws_dept = value;
                    RaisePropertyChanged("ws_dept");
                }
            }
        }

        private string _ws_dept_name;
        public string ws_dept_name
        {
            get
            {
                return _ws_dept_name;
            }
            set
            {
                if (_ws_dept_name != value)
                {
                    _ws_dept_name = value;
                    RaisePropertyChanged("ws_dept_name");
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
                    RaisePropertyChanged("ws_doc_nbr");
                }
            }
        }

        private string _ws_loc_1;
        public string ws_loc_1
        {
            get
            {
                return _ws_loc_1;
            }
            set
            {
                if (_ws_loc_1 != value)
                {
                    _ws_loc_1 = value;
                    RaisePropertyChanged("ws_loc_1");
                }
            }
        }

        private string _ws_loc_2;
        public string ws_loc_2
        {
            get
            {
                return _ws_loc_2;
            }
            set
            {
                if (_ws_loc_2 != value)
                {
                    _ws_loc_2 = value;
                    RaisePropertyChanged("ws_loc_2");
                }
            }
        }

        private string _ws_loc_3;
        public string ws_loc_3
        {
            get
            {
                return _ws_loc_3;
            }
            set
            {
                if (_ws_loc_3 != value)
                {
                    _ws_loc_3 = value;
                    RaisePropertyChanged("ws_loc_3");
                }
            }
        }

        private string _ws_loc_4;
        public string ws_loc_4
        {
            get
            {
                return _ws_loc_4;
            }
            set
            {
                if (_ws_loc_4 != value)
                {
                    _ws_loc_4 = value;
                    RaisePropertyChanged("ws_loc_4");
                }
            }
        }

        private string _ws_loc_5;
        public string ws_loc_5
        {
            get
            {
                return _ws_loc_5;
            }
            set
            {
                if (_ws_loc_5 != value)
                {
                    _ws_loc_5 = value;
                    RaisePropertyChanged("ws_loc_5");
                }
            }
        }

        private string _ws_oma_cd_1;
        public string ws_oma_cd_1
        {
            get
            {
                return _ws_oma_cd_1;
            }
            set
            {
                if (_ws_oma_cd_1 != value)
                {
                    _ws_oma_cd_1 = value;
                    RaisePropertyChanged("ws_oma_cd_1");
                }
            }
        }

        private string _ws_oma_cd_2;
        public string ws_oma_cd_2
        {
            get
            {
                return _ws_oma_cd_2;
            }
            set
            {
                if (_ws_oma_cd_2 != value)
                {
                    _ws_oma_cd_2 = value;
                    RaisePropertyChanged("ws_oma_cd_2");
                }
            }
        }

        private int _ws_in_svc_mtd;
        public int ws_in_svc_mtd
        {
            get
            {
                return _ws_in_svc_mtd;
            }
            set
            {
                if (_ws_in_svc_mtd != value)
                {
                    _ws_in_svc_mtd = value;
                    RaisePropertyChanged("ws_in_svc_mtd");
                }
            }
        }

        private decimal _ws_in_amt_mtd;
        public decimal ws_in_amt_mtd
        {
            get
            {
                return _ws_in_amt_mtd;
            }
            set
            {
                if (_ws_in_amt_mtd != value)
                {
                    _ws_in_amt_mtd = value;
                    RaisePropertyChanged("ws_in_amt_mtd");
                }
            }
        }

        private int _ws_out_svc_mtd;
        public int ws_out_svc_mtd
        {
            get
            {
                return _ws_out_svc_mtd;
            }
            set
            {
                if (_ws_out_svc_mtd != value)
                {
                    _ws_out_svc_mtd = value;
                    RaisePropertyChanged("ws_out_svc_mtd");
                }
            }
        }

        private decimal _ws_out_amt_mtd;
        public decimal ws_out_amt_mtd
        {
            get
            {
                return _ws_out_amt_mtd;
            }
            set
            {
                if (_ws_out_amt_mtd != value)
                {
                    _ws_out_amt_mtd = value;
                    RaisePropertyChanged("ws_out_amt_mtd");
                }
            }
        }

        private int _ws_misc_svc_mtd;
        public int ws_misc_svc_mtd
        {
            get
            {
                return _ws_misc_svc_mtd;
            }
            set
            {
                if (_ws_misc_svc_mtd != value)
                {
                    _ws_misc_svc_mtd = value;
                    RaisePropertyChanged("ws_misc_svc_mtd");
                }
            }
        }

        private decimal _ws_misc_amt_mtd;
        public decimal ws_misc_amt_mtd
        {
            get
            {
                return _ws_misc_amt_mtd;
            }
            set
            {
                if (_ws_misc_amt_mtd != value)
                {
                    _ws_misc_amt_mtd = value;
                    RaisePropertyChanged("ws_misc_amt_mtd");
                }
            }
        }

        private int _ws_total_svc_mtd;
        public int ws_total_svc_mtd
        {
            get
            {
                return _ws_total_svc_mtd;
            }
            set
            {
                if (_ws_total_svc_mtd != value)
                {
                    _ws_total_svc_mtd = value;
                    RaisePropertyChanged("ws_total_svc_mtd");
                }
            }
        }

        private decimal _ws_total_amt_mtd;
        public decimal ws_total_amt_mtd
        {
            get
            {
                return _ws_total_amt_mtd;
            }
            set
            {
                if (_ws_total_amt_mtd != value)
                {
                    _ws_total_amt_mtd = value;
                    RaisePropertyChanged("ws_total_amt_mtd");
                }
            }
        }

        private int _ws_in_svc_ytd;
        public int ws_in_svc_ytd
        {
            get
            {
                return _ws_in_svc_ytd;
            }
            set
            {
                if (_ws_in_svc_ytd != value)
                {
                    _ws_in_svc_ytd = value;
                    RaisePropertyChanged("ws_in_svc_ytd");
                }
            }
        }

        private decimal _ws_in_amt_ytd;
        public decimal ws_in_amt_ytd
        {
            get
            {
                return _ws_in_amt_ytd;
            }
            set
            {
                if (_ws_in_amt_ytd != value)
                {
                    _ws_in_amt_ytd = value;
                    RaisePropertyChanged("ws_in_amt_ytd");
                }
            }
        }

        private int _ws_out_svc_ytd;
        public int ws_out_svc_ytd
        {
            get
            {
                return _ws_out_svc_ytd;
            }
            set
            {
                if (_ws_out_svc_ytd != value)
                {
                    _ws_out_svc_ytd = value;
                    RaisePropertyChanged("ws_out_svc_ytd");
                }
            }
        }

        private decimal _ws_out_amt_ytd;
        public decimal ws_out_amt_ytd
        {
            get
            {
                return _ws_out_amt_ytd;
            }
            set
            {
                if (_ws_out_amt_ytd != value)
                {
                    _ws_out_amt_ytd = value;
                    RaisePropertyChanged("ws_out_amt_ytd");
                }
            }
        }

        private int _ws_misc_svc_ytd;
        public int ws_misc_svc_ytd
        {
            get
            {
                return _ws_misc_svc_ytd;
            }
            set
            {
                if (_ws_misc_svc_ytd != value)
                {
                    _ws_misc_svc_ytd = value;
                    RaisePropertyChanged("ws_misc_svc_ytd");
                }
            }
        }

        private decimal _ws_misc_amt_ytd;
        public decimal ws_misc_amt_ytd
        {
            get
            {
                return _ws_misc_amt_ytd;
            }
            set
            {
                if (_ws_misc_amt_ytd != value)
                {
                    _ws_misc_amt_ytd = value;
                    RaisePropertyChanged("ws_misc_amt_ytd");
                }
            }
        }

        private int _ws_total_svc_ytd;
        public int ws_total_svc_ytd
        {
            get
            {
                return _ws_total_svc_ytd;
            }
            set
            {
                if (_ws_total_svc_ytd != value)
                {
                    _ws_total_svc_ytd = value;
                    RaisePropertyChanged("ws_total_svc_ytd");
                }
            }
        }

        private decimal _ws_total_amt_ytd;
        public decimal ws_total_amt_ytd
        {
            get
            {
                return _ws_total_amt_ytd;
            }
            set
            {
                if (_ws_total_amt_ytd != value)
                {
                    _ws_total_amt_ytd = value;
                    RaisePropertyChanged("ws_total_amt_ytd");
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
                    RaisePropertyChanged("err_msg_comment");
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
                    RaisePropertyChanged("confirm_space");
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
                    RaisePropertyChanged("ws_file_err_msg");
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
                    RaisePropertyChanged("ws_disp_pat_key_type");
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
                    RaisePropertyChanged("status_common");
                }
            }
        }
       
        private int _ctr_read_docrev_mstr;
        public int ctr_read_docrev_mstr
        {
            get
            {
                return _ctr_read_docrev_mstr;
            }
            set
            {
                if (_ctr_read_docrev_mstr != value)
                {
                    _ctr_read_docrev_mstr = value;
                    RaisePropertyChanged("ctr_read_docrev_mstr");
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

        private int _ctr_read_pat_mstr;
        public  int  ctr_read_pat_mstr
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

        private int _ctr_read_subscr_mstr;
        public int ctr_read_subscr_mstr
        {
            get
            {
                return _ctr_read_subscr_mstr;
            }
            set
            {
                if (_ctr_read_subscr_mstr != value)
                {
                    _ctr_read_subscr_mstr = value;
                    RaisePropertyChanged("ctr_read_subscr_mstr");
                }
            }
        }
        
        private string _docrev_doc_nbr_before;
        public string docrev_doc_nbr_before
        {
            get
            {
                return _docrev_doc_nbr_before;
            }
            set
            {
                if (_docrev_doc_nbr_before != value)
                {
                    _docrev_doc_nbr_before = value;
                    RaisePropertyChanged("docrev_doc_nbr_before");
                }
            }
        }

        private string _docrev_doc_nbr_after;
        public string docrev_doc_nbr_after
        {
            get
            {
                return _docrev_doc_nbr_after;
            }
            set
            {
                if (_docrev_doc_nbr_after != value)
                {
                    _docrev_doc_nbr_after = value;
                    RaisePropertyChanged("docrev_doc_nbr_after");
                }
            }
        }

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string reply;
        private string change_reply;
        //private string ws_disp_pat_key_type;
        private string ws_disp_pat_err_msg;
        private int ws_max_nbr_lines = 56;
        //private string ws_file_err_msg = "";
        private int ws_max_nbr_loc = 5;
        private string option;
        private int pat_count;
        private string display_key_type;
        private int temp;
        private string end_job = "N";
        private string eof_docrev_mstr = "N";
        //private string confirm_space = space;

        private string macro_cli_grp;
        //private string filler = "PRINT_D050_SCREENS.CLI";
        private string hard_copy_flag = "N";
        private string hard_copy = "Y";
        private string no_hard_copy = "N";
        //private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        //private string flag_user_resp;
        private string flag_verif_acc = "A";
        private string flag_verif_rej = "R";
        private string flag_verif_mod = "M";
        private string flag_valid_ohip_or_chart;
        private string valid_ohip = "Y";
        private string valid_chart = "Y";
        private string invalid_ohip = "N";
        private string invalid_chart = "N";
        private string flag_request_complete;
        private string flag_request_complete_y = "Y";
        private string flag_request_complete_n = "N";
        private string flag_carry_1;
        private string carry_1_yes = "Y";
        private string carry_1_no = "N";
        private string flag_valid_docrev_rec;
        private string flag_valid_docrev_rec_y = "Y";
        private string flag_valid_docrev_rec_n = "N";
        private string flag_skip_read_approx;
        private string flag_skip_read_approx_y = "Y";
        private string flag_skip_read_approx_n = "N";

        private string ws_date_grp;
        private int ws_yy;
        private int ws_mm;
        private int ws_dd;
        private int ss;
        private int ss_loc_ptr;
        private int subs;
        private string feedback_subs_mstr;
        private string feedback_docrev_mstr;
        private string feedback_iconst_mstr;
        private string eof_filename_here = "N";
        //private string status_common;
        private string status_dept_mstr = "0";
        private string status_prt_file = "0";
        private string status_docrev_mstr = "0";
        private string status_cobol_docrev_mstr;
        private string status_cobol_doc_mstr;
        private string status_cobol_loc_mstr;
        private string status_cobol_iconst_mstr;
        private string status_cobol_dept_mstr;
        private string status_loc_mstr = "0";
        private string status_doc_mstr = "0";
        private string status_iconst_mstr = "0";

        private string counters_grp;
        //private int ctr_read_pat_mstr;
        //private int ctr_read_subscr_mstr;
        //private int ctr_read_docrev_mstr;

        private string ws_hold_scr_values_grp;
        //private string ws_request_clinic_nbr_grp;
        private string ws_request_clinic_nbr_1;
        //private string filler;
        //private string ws_dept;
        private string ws_dept_r_grp;
        private string ws_dept_1;
        private string flag_dept_unknown = "?";
        private string ws_dept_2;
        private int ws_dept_num;
        //private string ws_dept_name;
        //private string ws_doc_nbr;
        private string ws_doc_nbr_r_grp;
        private string ws_doc_nbr_1;
        private string flag_doc_nbr_all = "*";
        //private string filler;
        private string ws_scr_loc_grp;
        //private string ws_loc_1;
        private string ws_loc_1_r_grp;
        private string ws_loc_1_1;
        private string flag_loc_all = "*";
        //private string filler;
        //private string ws_loc_2;
        //private string ws_loc_3;
        //private string ws_loc_4;
        //private string ws_loc_5;
        private string ws_loc_r_grp;
        private string[] ws_loc = new string[6];
        private string ws_hold_scr_oma_cd_grp;
        //private string ws_oma_cd_1;
        private string ws_oma_cd_1_r_grp;
        private string ws_oma_cd_1_1;
        private string flag_oma_cd_all = "*";
        //private string filler;
        //private string ws_oma_cd_2;
        private string ws_oma_cd_r_grp;
        private string[] ws_oma_cd = new string[3];

        private string tmp_doc_nbr_alpha_grp;        
        private string tmp_doc_nbr_pos_1;
        private string tmp_doc_nbr_pos_2_3;
        private string tmp_doc_nbr_apha_r1_grp;
        private string tmp_doc_nbr_pos_1_2;
        //private string filler;
        //private string tmp_doc_nbr_apha_r1_grp;
        //private string tmp_doc_nbr_pos_1;        
        //private string tmp_doc_nbr_pos_1;
        private string tmp_doc_nbr_apha_r2_grp;
        private string[] tmp_doc_nbr_pos = new string[4];

        private string hold_doc_key_grp;
        private string hold_clinic_nbr;
        private int hold_dept;
        private string hold_doc_nbr;
        private string hold_loc;
        private string hold_oma_cd;

        private string ws_fees_oma_grp;
        private string ws_fees_grp;
        private string ws_fees_mtd_grp;
        //private int ws_in_svc_mtd;
        //private decimal ws_in_amt_mtd;
        //private int ws_out_svc_mtd;
        //private decimal ws_out_amt_mtd;
        //private int ws_misc_svc_mtd;
        //private decimal ws_misc_amt_mtd;
        //private int ws_total_svc_mtd;
        //private decimal ws_total_amt_mtd;
        private string ws_fees_ytd_grp;
        //private int ws_in_svc_ytd;
        //private decimal ws_in_amt_ytd;
        //private int ws_out_svc_ytd;
        //private decimal ws_out_amt_ytd;
        //private int ws_misc_svc_ytd;
        //private decimal ws_misc_amt_ytd;
        //private int ws_total_svc_ytd;
        //private decimal ws_total_amt_ytd;
        private string ws_fees_r_grp;
        private string[] ws_fees_mtd_ytd = new string[3];
        private int[] ws_in_svc = new int[3];
        private decimal[] ws_in_amt = new decimal[3];
        private int[] ws_out_svc = new int[3];
        private decimal[] ws_out_amt = new decimal[3];
        private int[] ws_misc_svc = new int[3];
        private decimal[] ws_misc_amt = new decimal[3];
        private int[] ws_total_svc = new int[3];
        private decimal[] ws_total_amt = new decimal[3];

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "invalid reply";
        private string filler = "NO DOCTORS FOUND IN THIS DEPT.";
        private string filler = "CLINIC NOT FOUND ON CONSTANTS MASTER";
        private string filler = "spare                 ";
        private string filler = "LOCATION NOT FOUND ON LOCATIONS MASTER";
        private string filler = "NO DOCTOR REVENUE RECORDS FOUND";
        private string filler = "spare                  ";
        private string filler = "FIRST OMA CODE MUST BE <= SECOND ENTERED";
        private string filler = "INVALID DOCTOR NBR";
        private string filler = "INVALID DEPT NBR";
        private string filler = "IF DEPT UNKNOWN, MUST PROVIDE A VALID DOCTOR NBR";
        private string filler = "DOCTOR NOT FOUND ON DOCTOR MSTR";
        private string filler = "NO DEPARTMENT ON FILE IN DEPT MSTR"; */
        private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "NO DOCTORS FOUND IN THIS DEPT.", "CLINIC NOT FOUND ON CONSTANTS MASTER" , "spare                 " , "LOCATION NOT FOUND ON LOCATIONS MASTER" , "NO DOCTOR REVENUE RECORDS FOUND" ,
                                        "spare                  ", "FIRST OMA CODE MUST BE <= SECOND ENTERED", "INVALID DOCTOR NBR","INVALID DEPT NBR","IF DEPT UNKNOWN, MUST PROVIDE A VALID DOCTOR NBR", "DOCTOR NOT FOUND ON DOCTOR MSTR", "NO DEPARTMENT ON FILE IN DEPT MSTR"};
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
       // private string filler = ":";
        private int run_min;
       // private string filler = ":";
        private int run_sec;

       // Parameter variables
        string prm_ws_request_clinic_nbr;
        string prm_ws_dept;
        string prm_ws_doc_nbr;
        string prm_ws_loc_1;
        string prm_ws_loc_2;
        string prm_ws_loc_3;
        string prm_ws_loc_4;
        string prm_ws_loc_5;
        string prm_ws_oma_cd_1;
        string prm_ws_oma_cd_2;
        string prm_flag_user_resp;

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 1,Data1 = "D050",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 28,Data1 = "* DOCTOR REVENUE INQUIRY *",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 77,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 78,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 80,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "01",Col = 81,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title-doc-rev-inq.",Line = "03",Col = 4,Data1 = "SEARCH CRITERIA:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-line-13-15.",Line = "15",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-line-13-15.",Line = "17",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-total-lines.",Line = "15",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-total-lines.",Line = "16",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-total-lines.",Line = "17",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-total-lines.",Line = "19",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-blank-total-lines.",Line = "23",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "05",Col = 7,Data1 = "CLINIC      :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "07",Col = 7,Data1 = "DEPT        :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "07",Col = 54,Data1 = "(?  DEPT - IF UNKNOWN     )",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "09",Col = 7,Data1 = "DOCTOR      :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "09",Col = 54,Data1 = "(*  DOC  - FOR ENTIRE DEPT)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "11",Col = 7,Data1 = "LOCATION(S) :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "11",Col = 54,Data1 = "(*  FOR ALL LOCATIONS     )",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "13",Col = 7,Data1 = "OMA CODE(S) :        THRU",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-doc-key-lit.",Line = "13",Col = 54,Data1 = "(*  FOR ALL CODES         )",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-user-verif.",Line = "15",Col = 11,Data1 = "ACCEPT/REJECT/MODIFY SELECTION CRITERIA (A/R/M)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-user-verif.",Line = "15",Col = 59,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "flag_user_resp",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-search-in-prog.",Line = "17",Col = 11,Data1 = "SEARCH IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-total-lit.",Line = "15",Col = 6,Data1 = "---IN PATIENT----  --OUT PATIENT---",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-total-lit.",Line = "15",Col = 43,Data1 = "-MISCELLANEOUS--   ------TOTALS------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-total-lit.",Line = "16",Col = 8,Data1 = "SVC         AMT    SVC        AMT   SVC",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-total-lit.",Line = "16",Col = 56,Data1 = "AMT      SVC         AMT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-total-lit.",Line = "17",Col = 1,Data1 = "MTD",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-total-lit.",Line = "19",Col = 1,Data1 = "YTD",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-hard-copy.",Line = "23",Col = 41,Data1 = "HARD COPY (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-hard-copy.",Line = "23",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "05",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_request_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "07",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_dept",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "07",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_dept_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "09",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(3)",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "11",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_loc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "11",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "11",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "11",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "11",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "13",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x9999",MaxLength = 5,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_oma_cd_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-doc-key.",Line = "13",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x9999",MaxLength = 5,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_oma_cd_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 5,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_in_svc_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zz9.99-",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_in_amt_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_out_svc_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zz9.99-",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_out_amt_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_misc_svc_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zz9.99-",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_misc_amt_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz,zz9",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_total_svc_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "17",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz,zz9.99-",MaxLength = 11,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_total_amt_mtd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 5,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_in_svc_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zz9.99-",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_in_amt_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_out_svc_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zz9.99-",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_out_amt_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz,zz9",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_misc_svc_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zz9.99-",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_misc_amt_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz,zz9",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_total_svc_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dis-totals.",Line = "19",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzzz,zz9.99-",MaxLength = 11,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_total_amt_ytd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Display,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "23",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(42)",MaxLength = 42,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_file_err_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_disp_pat_key_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_common",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen.",Line = "24",Col = 58,Data1 = "ACCEPT (Y/N/M) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen.",Line = "24",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 59,Data1 = "REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "6",Col = 20,Data1 = "# OF DOCREV MASTER READS  =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "6",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_read_docrev_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM D050 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         //...         

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-nbr.",Line = "5",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_request_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept.",Line = "7",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_dept",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-name.",Line = "7",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_dept_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-doc-nbr.",Line = "9",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(3)",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-loc-1.",Line = "11",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_loc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-loc-2.",Line = "11",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-loc-3.",Line = "11",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-loc-4.",Line = "11",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-loc-5.",Line = "11",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_loc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-oma-cd-1.",Line = "13",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x9999",MaxLength = 5,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_oma_cd_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-oma-cd-2.",Line = "13",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x9999",MaxLength = 5,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_oma_cd_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "docrev-doc-nbr-Before.",Line = "22",Col = 1,Data1 = "BEFORE: ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "docrev-doc-nbr-Before.",Line = "22",Col = 9,Data1 = "",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "docrev_doc_nbr_before",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "docrev-doc-nbr-After.",Line = "22",Col = 1,Data1 = "AFTER: ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "docrev-doc-nbr-After.",Line = "22",Col = 9,Data1 = "",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "docrev_doc_nbr_after",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }
        private void err_docrev_mstr_file_section()
        {
            //     use after standard error procedure on docrev-mstr.;
        }

        private void err_docrev_mstr()
        {
            status_common = status_docrev_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING DOCREV MASTER".;
        }

        private void err_iconst_mstr_file_section()
        {
            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_iconst_mstr()
        {
            status_common = status_iconst_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
        }

        private void err_loc_mstr_file_section()
        {
            //     use after standard error procedure on loc-mstr.;
        }

        private void err_loc_mstr()
        {
            status_common = status_loc_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING LOCATIONS MASTER".;
        }
        private void err_doc_mstr_file_section()
        {
            //     use after standard error procedure on doc-mstr.;
        }
        private void err_doc_mstr()
        {
            status_common = status_doc_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING DOCTOR MASTER".;
        }
        private void err_dept_mstr_file_section()
        {
            //     use after standard error procedure on dept-mstr.;
        }
        private void err_dept_mstr()
        {
            //     stop "ERROR IN ACCESSING DEPT MASTER ".;
            status_common = status_dept_mstr;
            //     display file-status-display.;
            //     stop run.;
        }
        private void end_declaratives()
        {

        }

        private void main_line_section()
        {
        }

        //scr-clinic-nbr   ws-request-clinic-nbr xx // screen name input
        //scr-dept    ws-dept   xx  // screen name input
        // scr-doc-nbr   WS-DOC-NBR  x(3)  // screen name input required
        // scr-loc-1     ws-loc-1  x999 rquired
        // scr-loc-2     ws-loc-2  x999
        // scr-loc-3     ws-loc-3  x999
        // scr-loc-4     ws-loc-4  x999
        // scr-loc-5.    ws-loc-5  x999 
        // scr-oma-cd-1   ws-oma-cd-1  x9999  required
        // scr-oma-cd-2   ws-oma-cd-2  x9999  

        // scr-acpt-user-verif   // screen name
        // scr-acpt-hard-copy    // screen name  user input
        //                  FLAG-USER-RESP   x   (A / R / M)
        //                  flag-user-resp   x   (A / R / M) 

        // scr-confirm.    screen name  confirm-space  x  
        // 

        public async  void mainline(string ws_request_clinic_nbr = "",
                              string ws_dept = "",
                              string ws_doc_nbr = "",
                              string ws_loc_1 = "",
                              string ws_loc_2 = "",
                              string ws_loc_3 = "",
                              string ws_loc_4 = "",
                              string ws_loc_5 = "",
                              string ws_oma_cd_1 = "",
                              string ws_oma_cd_2 = "",
                              string flag_user_resp = ""
                             )
        {
            prm_ws_request_clinic_nbr = ws_request_clinic_nbr;
            prm_ws_dept = ws_dept;
            prm_ws_doc_nbr = ws_doc_nbr;
            prm_ws_loc_1 = ws_loc_1;
            prm_ws_loc_2 = ws_loc_2;
            prm_ws_loc_3 = ws_loc_3;
            prm_ws_loc_4 = ws_loc_4;
            prm_ws_loc_5 = ws_loc_5;
            prm_ws_oma_cd_1 = ws_oma_cd_1;
            prm_ws_oma_cd_2 = ws_oma_cd_2;
            prm_flag_user_resp = flag_user_resp;

            objDoc_mstr_rec = null;
            objDoc_mstr_rec = new Doc_Mstr_Rec();
            Doc_mstr_rec_Collection = new ObservableCollection<Doc_Mstr_Rec>();

            objLoc_mstr_rec = null;
            objLoc_mstr_rec = new Loc_mstr_rec();
            Loc_mstr_rec_Collection = new ObservableCollection<Loc_mstr_rec>();

            objDocrev_master_rec = null;
            objDocrev_master_rec = new Docrev_master_rec();
            Docrev_master_rec_Collection = new ObservableCollection<Docrev_master_rec>();

            objDept_mstr_rec = null;
            objDept_mstr_rec = new Dept_Mstr_Rec();
            Dept_mstr_rec_Collection = new ObservableCollection<Dept_Mstr_Rec>();

            //objConstants_mstr_rec_1 = null;
            //objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1();
            //Constants_mstr_rec_1_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_1>();

            objF070_DEPT_MSTR = null;
            objF070_DEPT_MSTR = new F070_DEPT_MSTR();
            F070_DEPT_MSTR_Collection = new ObservableCollection<F070_DEPT_MSTR>();

            objF030_LOCATIONS_MSTR = null;
            objF030_LOCATIONS_MSTR = new F030_LOCATIONS_MSTR();
            F030_LOCATIONS_MSTR_Collection = new ObservableCollection<F030_LOCATIONS_MSTR>();

            objF050_DOC_REVENUE_MSTR = null;
            objF050_DOC_REVENUE_MSTR = new F050_DOC_REVENUE_MSTR();
            F050_DOC_REVENUE_MSTR_Collection = new ObservableCollection<F050_DOC_REVENUE_MSTR>();


        //     perform aa0-initialization		thru aa0-99-exit.;
            await aa0_initialization();
            await aa0_99_exit();

            //     perform ab0-processing		thru ab0-99-exit;
            // 	until end-job = "Y".;

            do
            {
                await ab0_processing();
                await ab0_99_exit();
            } while (!end_job.Equals("Y"));

            //     perform az0-end-of-job		thru az0-99-exit.;
            await az0_end_of_job();
            await az0_99_exit();

            //     stop run.;
        }

        private async Task aa0_initialization()
        {

            //     accept sys-date			from date.;
            sys_date_grp = DateTime.Now.ToString();
            sys_date_long_child = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = DateTime.Now.Year;
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(DateTime.Now.Year.ToString().Substring(0, 1));
            sys_y2 = Util.NumInt(DateTime.Now.Year.ToString().Substring(1, 1));
            sys_y3 = Util.NumInt(DateTime.Now.Year.ToString().Substring(2, 1));
            sys_y4 = Util.NumInt(DateTime.Now.Year.ToString().Substring(3, 1));
            sys_mm = DateTime.Now.Month;
            sys_dd = DateTime.Now.Day;

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
            //     open input  iconst-mstr;
            // 		loc-mstr;
            // 		dept-mstr;
            // 		doc-mstr;
            // 		docrev-mstr.;
            //     display scr-title-doc-rev-inq.;
            //     display scr-dis-doc-key-lit.;

            Display("scr-title-doc-rev-inq.");
            Display("scr-dis-doc-key-lit.");

            //counters = 0;
            ctr_read_pat_mstr = 0;
            ctr_read_subscr_mstr = 0;
            ctr_read_docrev_mstr = 0;

            //     perform xa0-clear-values		thru xa0-99-exit.;

            await xa0_clear_values();
            await xa0_99_exit();
        }
        private async Task aa0_99_exit()
        {
            //     exit.;
        }
        private async Task az0_end_of_job()
        {

            //     if hard-copy then;            
            // 	        call 'CLI' using macro-cli.;

            //     display blank-screen.;
            ClearScreen();

            //     accept sys-time			from time.;
            //     display scr-closing-screen.;
            Display("scr-closing-screen.");

            //     display confirm.;
            //     close iconst-mstr;
            // 	  loc-mstr;
            // 	  dept-mstr;
            // 	  doc-mstr;
            // 	  docrev-mstr.;

            //     call program "menu".;

            //     stop run.;
        }

        private async Task az0_99_exit()
        {

            //     exit.;
        }

        private async Task ab0_processing()
        {

            //     perform ba0-acpt-clinic		thru ba0-99-exit.;
            await ba0_acpt_clinic();
            await ba0_99_exit();

            //     if end-job = 'Y' then            
            // 	        go to ab0-99-exit.;

            if (end_job.Equals("Y"))
            {
                await ab0_99_exit();
                return;
            }

            //     perform da0-acpt-dept-doc		thru da0-99-exit.;
            await da0_acpt_dept_doc();
            await da0_10_acpt_doc_nbr();
            await da0_99_exit();

            flag = "Y";

            //     perform fa0-acpt-loc		thru fa0-99-exit;
            // 	varying subs from 1 by 1;
            // 	until   subs > 5;
            // 	     or not-ok.;

            subs = 1;
            do
            {
                await fa0_acpt_loc();
                await fa0_99_exit();
                subs++;
            } while (subs <= 5 && flag.Equals("Y"));

            //     if flag-loc-all then;            
            //         hold_loc = "";
            //     else;
            //        hold_loc = ws_loc[1];
            if(ws_loc_1_1.Equals(flag_loc_all)) // todo...
            {
                hold_loc = "";
            }
            else
            {               
                hold_loc = ws_loc[1];
            }

            //     perform ha0-acpt-oma-code		thru ha0-99-exit.;
            await ha0_acpt_oma_code();
            await ha0_10_acpt_cd_2();
            await ha0_99_exit();

            //        flag_user_resp = "A";
            flag_user_resp = "A";

            //     perform ja0-acpt-user-verif		thru ja0-99-exit.;
            await ja0_acpt_user_verif();
            await ja0_99_exit();

            // if flag-verif-rej then;            
            //    end_job = "Y";
            // 	   go to ab0-99-exit;
            // else if flag-verif-mod then
            // 	    go to ab0-99-exit;
            // 	else
            // 	    next sentence.;

            if (flag_user_resp.Equals(flag_verif_rej))
            {
                end_job = "Y";
                await ab0_99_exit();
                return;
            }
            else if (flag_user_resp.Equals(flag_verif_mod))
            {
                await ab0_99_exit();
                return;
            }
            else
            {
                // next sentence;
            }

            //     display scr-dis-search-in-prog.;
            Display("scr-dis-search-in-prog.");

            flag_request_complete = "N";
            flag_valid_docrev_rec = "N";
            
            ss_loc_ptr = 1;
            hold_doc_key_grp = Util.Str(hold_clinic_nbr) + Util.Str(hold_dept) + Util.Str(hold_doc_nbr) + Util.Str(hold_loc) + Util.Str(hold_oma_cd);
            objDocrev_master_rec.Docrev_key = hold_doc_key_grp;
            flag = "Y";
            //     perform xe0-read-docrev-approx	thru xe0-99-exit.;
            await xe0_read_docrev_approx();
            await xe0_99_exit();

            //     perform la0-select-proc-rd-nxt-docrev;
            // 					thru la0-99-exit;
            // 	until flag-request-complete-y.;

            do
            {
                await la0_select_proc_rd_nxt_docrev();
                await la0_99_exit();
            } while (!flag_request_complete.Equals(flag_request_complete_y));

            //     display scr-blank-line-13-15.;
            //     display scr-dis-total-lit.;
            //     display scr-dis-totals.;

            Display("scr-blank-line-13-15.");
            Display("scr-dis-total-lit.");
            Display("scr-dis-totals.");

            flag = "N";

            //     perform pa0-print-copy		thru pa0-99-exit.;
            await pa0_print_copy();
            await pa0_99_exit();

            //     perform xa0-clear-values		thru xa0-99-exit.;
            await xa0_clear_values();
            await xa0_99_exit();

            //     display scr-blank-total-lines.;
            Display("scr-blank-total-lines.");

            //     if flag-oma-cd-all  then            
            // 	display scr-oma-cd-1;
            // 	display scr-oma-cd-2.;           

            if (ws_oma_cd_1_1.Equals(flag_oma_cd_all))  // todo... check the value
            {
                Display("scr-oma-cd-1.");
                Display("scr-oma-cd-2.");
            }
        }

        private async Task ab0_99_exit()
        {
            //     exit.;
        }
        private async Task ba0_acpt_clinic()
        {
            //     accept scr-clinic-nbr.;
            Display("scr-clinic-nbr.");
           await Prompt("ws_request_clinic_nbr", isBatchProcess);

            // if ws-request-clinic-nbr-1 = '*' then            
            //  end_job = "Y";
            // 	go to ba0-99-exit.;

            if (ws_request_clinic_nbr_1.Equals("*"))  // todo..
            {
                end_job = "Y";
                await ba0_99_exit();
                return;
            }

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_request_clinic_nbr;   // TODO....  ws_request_clinic_nbr ???  1,2 or 3 ???

            // read iconst-mstr;
            // 	invalid key;
            //  err_ind = 3;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to ba0-acpt-clinic.;
            hold_clinic_nbr = ws_request_clinic_nbr;
        }

        private async Task ba0_99_exit()
        {
            //     exit.;
        }

        private async Task da0_acpt_dept_doc()
        {
            //     accept scr-dept.;
            Display("scr-dept.");
            await Prompt("ws_dept", isBatchProcess);            

            // if   ws-dept-r = '1 ' or ws-dept-r = '2 ' or ws-dept-r = '3 ' or ws-dept-r = '4 ' or ws-dept-r = '5 ' or ws-dept-r = '6 ' or ws-dept-r = '7 ' or ws-dept-r = '8 ' or ws-dept-r = '9 ' then                                                                                                      
            //     ws_dept_2 = ws_dept_1;
            //     ws_dept_1 = "0";
            // 	   display scr-dept.;

            if (ws_dept.Trim().Equals("1") || ws_dept.Trim().Equals("2") || ws_dept.Trim().Equals("3") || ws_dept.Trim().Equals("4") || ws_dept.Trim().Equals("5") ||
                ws_dept.Trim().Equals("6") || ws_dept.Trim().Equals("7") || ws_dept.Trim().Equals("8") || ws_dept.Trim().Equals("9"))
            {
                ws_dept_1 = ws_dept;
                ws_dept_2 = ws_dept_1;   // todo.. watch out the value...
                ws_dept_1 = "0";
            }

            // if not flag-dept-unknown and   ws-dept-num not numeric then            
            //    err_ind = 10;
            // 	  perform za0-common-error	thru za0-99-exit;
            //    ws_dept = "";
            //    ws_dept_name = "";
            //    display scr-dept;
            // 	  display scr-dept-name;
            // 	  go to da0-acpt-dept-doc.;

            if (!ws_dept.Equals(flag_dept_unknown)  &&  !Util.IsNumeric(ws_dept))  // todo.. check the value  flag_dept_unknown
            {
                err_ind = 10;
                await za0_common_error();
                await za0_99_exit();
                ws_dept = "";
                ws_dept_name = "";
                Display("scr-dept.");
                Display("scr-dept-name.");
                await da0_acpt_dept_doc();
                return;
            }

            // if  not flag-dept-unknown then;            
            //     objDept_mstr_rec.dept_nbr = Util.NumInt(ws_dept);
            //     perform da2-read-dept-mstr	thru da2-99-exit;
            //     ws_dept_name = objDept_mstr_rec.dept_name;
            //     display scr-dept-name.;

            if (!ws_dept.Contains(flag_dept_unknown))   // todo check the value 
            {
                objDept_mstr_rec.dept_nbr = Util.NumInt(ws_dept);
                await da2_read_dept_mstr();
                await da2_99_exit();
                ws_dept_name = objF070_DEPT_MSTR.DEPT_NAME;
                Display("scr-dept-name.");
            }
        }

        private async Task da0_10_acpt_doc_nbr()
        {
            //     accept scr-doc-nbr.;
            Display("scr-doc-nbr.");
            await Prompt("ws_doc_nbr", isBatchProcess);  // todo. this is using refine in WS.

            // if flag-doc-nbr-all or  (    (ws-doc-nbr >= "000"  and ws-doc-nbr <= "999" ) or (    ws-doc-nbr >= "A00"  and ws-doc-nbr <= "ZZZ" )  )  then                                                                   
            //   	next sentence
            //  else
            //      ws_doc_nbr = ""
            //      err_ind = 9
            // 	    perform za0-common-error	thru za0-99-exit
            // 	    display scr-doc-nbr
            // 	    if flag-dept-unknown then            
            // 	        go to da0-acpt-dept-doc;
            // 	    else
            // 	        go to da0-10-acpt-doc-nbr .

            ws_doc_nbr = ws_doc_nbr.PadRight(3, ' ');
            ws_doc_nbr_1 = ws_doc_nbr.Substring(0, 1);

            // if (ws_doc_nbr_1.Equals(this.flag_doc_nbr_all) || (Util.NumInt(ws_doc_nbr) >= 0 && Util.NumInt(ws_doc_nbr) <= 999) || Util.Str(ws_doc_nbr) >= "A00" && Util.Str(ws_doc_nbr) <= "ZZZ")) {
            if (ws_doc_nbr_1.Trim().Equals(this.flag_doc_nbr_all) || (Util.NumInt(ws_doc_nbr) >= 0 && Util.NumInt(ws_doc_nbr) <= 999) ||  (ws_doc_nbr.Trim().CompareTo("A00") >= 0 && ws_doc_nbr.Trim().CompareTo("ZZZ") <= 0)) {  
                   // next sentence
            }
            else
            {
                ws_doc_nbr = "";
                err_ind = 9;
                await za0_common_error();
                await za0_99_exit();
                Display("scr-doc-nbr.");
                ws_dept = ws_dept.PadRight(2, ' ');
                ws_dept_1 = ws_dept.Substring(0, 1);
                if (ws_dept_1.Equals(this.flag_dept_unknown))  // todo....
                {
                    await da0_acpt_dept_doc();
                    return;
                }else
                {
                    await da0_10_acpt_doc_nbr();
                    return;
                }
            }

            //if flag-dept-unknown and flag-doc-nbr-all then                       
            //   err_ind = 11;
            // 	perform za0-common-error	thru za0-99-exit;
            // 	go to da0-acpt-dept-doc.;
            ws_doc_nbr = ws_doc_nbr.PadRight(3, ' ');
            ws_doc_nbr_1 = ws_doc_nbr.Substring(0, 1);
            if (ws_dept_1.Trim().Equals(this.flag_dept_unknown) && ws_doc_nbr_1.Trim().Equals(flag_doc_nbr_all))
            {
                err_ind = 11;
                await za0_common_error();
                await za0_99_exit();
                await da0_acpt_dept_doc();
                return;
            }

            // if flag-dept-unknown then            
            //    flag = "Y";
            // 	  perform da1-access-doc-for-dept	thru da1-99-exit;
            // 	  if ok then            
            // 	     display scr-dept;
            //       objDept_mstr_rec.dept_nbr = ws_dept_num;
            //       perform da2-read-dept-mstr		thru da2-99-exit;
            //       ws_dept_name = objDept_mstr_rec.dept_name;
            //       display scr-dept-name;
            // 	  else
            // 	    go to da0-10-acpt-doc-nbr;
            // else;
            //         next sentence.;

            ws_dept = ws_dept.PadRight(2, ' ');
            ws_dept_1 = ws_dept.Substring(0, 1);
            if (ws_dept_1.Trim().Equals(this.flag_dept_unknown))
            {
                flag = "Y";
                await da1_access_doc_for_dept();
                await da1_99_exit();
                if (flag.Trim().Equals(ok))
                {
                    Display("scr-dept.");
                    objDept_mstr_rec.dept_nbr = ws_dept_num;
                    await da2_read_dept_mstr();
                    await da2_99_exit();
                    ws_dept_name = objDept_mstr_rec.dept_name;
                    Display("scr-dept-name.");
                }
                else
                {
                   await da0_10_acpt_doc_nbr();
                    return;
                }
            }else
            {
                // next sentence
            }

            hold_dept = ws_dept_num;

            // if flag-doc-nbr-all then;            
            //     hold_doc_nbr = "";
            // else;
            //    hold_doc_nbr = ws_doc_nbr;

            if (ws_doc_nbr_1.Trim().Equals(this.flag_doc_nbr_all))
            {
                hold_doc_nbr = "";
            }else
            {
                hold_doc_nbr = ws_doc_nbr;
            }
        }

        private async Task da0_99_exit()
        {
            //     exit.;
        }
        private async Task da1_access_doc_for_dept()
        {
            // objDoc_mstr_rec.doc_nbr = ws_doc_nbr;
            //     read doc-mstr;
            // 	invalid key;
            // flag = "N";
            // err_ind = 12;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to da1-99-exit.;
            // ws_dept_num = objDoc_mstr_rec.doc_dept;

            F020_DOCTOR_MSTR_Collection = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = ws_doc_nbr
            }.Collection();

            objF020_DOCTOR_MSTR = F020_DOCTOR_MSTR_Collection.FirstOrDefault();

            if(F020_DOCTOR_MSTR_Collection.Count == 0)
            {
                objF020_DOCTOR_MSTR = new F020_DOCTOR_MSTR();
                flag = "N";
                err_ind = 12;
                await za0_common_error();
                await za0_99_exit();
                await da1_99_exit();
                return;
            }
            ws_dept_num = Util.NumInt(objF020_DOCTOR_MSTR.DOC_DEPT); 
        }

        private async Task da1_99_exit()
        {
            //     exit.;
        }

        private async Task da2_read_dept_mstr()
        {
            //  read dept-mstr;
            // 	invalid key;
            // err_ind = 13;
            // 	    perform za0-common-error	thru za0-99-exit;
            //objDept_mstr_rec.dept_name = "'UNKNOWN DEPT'";

            ws_dept_num = Util.NumInt(ws_dept);
            F070_DEPT_MSTR_Collection = new F070_DEPT_MSTR
            {
                WhereDept_nbr = ws_dept_num
            }.Collection();

            objF070_DEPT_MSTR = F070_DEPT_MSTR_Collection.FirstOrDefault();

            if (F070_DEPT_MSTR_Collection.Count() == 0)
            {
                objF070_DEPT_MSTR = new F070_DEPT_MSTR();
                err_ind = 13;
                await za0_common_error();
                await za0_99_exit();
                objF070_DEPT_MSTR.DEPT_NAME = "'UNKNOWN DEPT'";
            }
        }
        private async Task da2_99_exit()
        {
            //     exit.;
        }

        private async Task fa0_acpt_loc()
        {
            // if subs = 1 then            
            //   	accept scr-loc-1;
            // 	    if flag-loc-all then;            
            //          flag = "N";
            //          ws_loc_2 = "";
            // 					   ws-loc-3;
            // 					   ws-loc-4;
            // 					   ws-loc-5;
            // 	        display scr-loc-2;
            // 	        display scr-loc-3;
            // 	        display scr-loc-4;
            // 	        display scr-loc-5;
            // 	        go to fa0-99-exit;
            // 	    else
            // 	        next sentence;
            // else if subs = 2 then                      
            // 	    accept scr-loc-2;
            // else if subs = 3 then;            
            // 		accept scr-loc-3;
            // else if subs = 4 then            
            // 		    accept scr-loc-4;
            //  else;
            // 		    accept scr-loc-5.;

            if (subs == 1)
            {
                Display("scr-loc-1.");
                await Prompt("ws_loc_1", isBatchProcess);

                ws_loc[1] = ws_loc_1;  // redefines...

                ws_loc_1 = ws_loc_1.PadRight(4, ' ');
                ws_loc_1_1 = ws_loc_1.Substring(0, 1);
                if (ws_loc_1_1.Equals(flag_loc_all))
                {
                    flag = "N";
                    ws_loc_2 = string.Empty;
                    ws_loc_3 = string.Empty;
                    ws_loc_4 = string.Empty;
                    ws_loc_5 = string.Empty;

                    Display("scr-loc-2.");
                    Display("scr-loc-3.");
                    Display("scr-loc-4.");
                    Display("scr-loc-5.");
                    await fa0_99_exit();
                    return;
                }
                else
                {
                    // next sentence
                }
            }
            else if (subs == 2)
            {
               Display("scr-loc-2.");
               await Prompt("ws_loc_2", isBatchProcess);
               ws_loc[2] = ws_loc_2;
            }
            else if (subs == 3)
            {
                Display("scr-loc-3.");
                await Prompt("ws_loc_3", isBatchProcess);
                ws_loc[3] = ws_loc_3;
            }
            else if (subs == 4)
            {
                Display("scr-loc-4.");
                await Prompt("ws_loc_4", isBatchProcess);
                ws_loc[4] = ws_loc_4;
            }
            else
            {
                Display("scr-loc-5.");
                await Prompt("ws_loc_5", isBatchProcess);
                ws_loc[5] = ws_loc_5;
            }

            // if ws-loc(subs) = spaces then            
            //    flag = "N"
            // 	  if subs = 2 then;            
            //        ws_loc_3 = "";
            //        ws_loc_4 = "";
            //        ws_loc_5 = "";            
            // 	      display scr-loc-3;
            // 	      display scr-loc-4;
            // 	      display scr-loc-5;
            // 	      go to fa0-99-exit;
            // 	  else if subs = 3 then;           
            //        ws_loc_4 = "";
            //        ws_loc_5 = "";            
            // 		  display scr-loc-4;
            // 		  display scr-loc-5;
            // 		  go to fa0-99-exit;
            // 	  else if subs = 4 then            
            //        ws_loc_5 = "";
            // 		  display scr-loc-5;
            // 		  go to fa0-99-exit;
            //    else;
            // 		  go to fa0-99-exit;
            // else;
            // 	   next sentence.;

            if (string.IsNullOrWhiteSpace(ws_loc[subs]))
            {
                flag = "N";
                if (subs == 2)
                {
                    ws_loc_3 = "";
                    ws_loc_4 = "";
                    ws_loc_5 = "";
                    Display("scr-loc-3.");
                    Display("scr-loc-4.");
                    Display("scr-loc-5.");
                    await fa0_99_exit();
                    return;
                }
                else if (subs == 3)
                {
                    ws_loc_4 = "";
                    ws_loc_5 = "";
                    Display("scr-loc-4.");
                    Display("scr-loc-5.");
                    await fa0_99_exit();
                    return;
                }
                else if (subs == 4)
                {
                    ws_loc_5 = "";
                    Display("scr-loc-5.");
                    await fa0_99_exit();
                    return;
                }
                else
                {
                    await fa0_99_exit();
                    return;
                }
            }

            // flag = "Y";
            // perform fa1-read-loc-mstr		thru fa1-99-exit.;

            flag = "Y";
            await fa1_read_loc_mstr();
            await fa1_99_exit();

            // if not-ok then            
            // 	   go to fa0-acpt-loc.;

            if (flag.Equals(not_ok))
            {
                await fa0_acpt_loc();
                return;
            }
        }
        private async Task fa0_99_exit()
        {
            //     exit.;
        }
        private async Task fa1_read_loc_mstr()
        {
            //objLoc_mstr_rec.loc_nbr = ws_loc[subs];
            //     read loc-mstr;
            // 	invalid key;
            //err_ind = 5;
            // 	    perform za0-common-error	thru za0-99-exit;
            //flag = "N";
            
            objF030_LOCATIONS_MSTR.LOC_NBR = ws_loc[subs];
            F030_LOCATIONS_MSTR_Collection = new F030_LOCATIONS_MSTR
            {
                WhereLoc_nbr = ws_loc[subs]
            }.Collection();

            objF030_LOCATIONS_MSTR = F030_LOCATIONS_MSTR_Collection.FirstOrDefault();

            if (F030_LOCATIONS_MSTR_Collection.Count() == 0)
            {
                err_ind = 5;
                await za0_common_error();
                await za0_99_exit();
                flag = "N";
            }
        }
        private async Task fa1_99_exit()
        {
            //     exit.;
        }
        private async Task ha0_acpt_oma_code()
        {
            //     accept scr-oma-cd-1.;
            Display("scr-oma-cd-1.");
            await Prompt("ws_oma_cd_1", isBatchProcess);

            ws_oma_cd_1 = ws_oma_cd_1.PadRight(5, ' ');
            ws_oma_cd_1_1 = ws_oma_cd_1.Substring(0, 1);

            //if flag-oma-cd-all then            
            //   ws_oma_cd_2 = "";
            // 	 display scr-oma-cd-2;
            //   hold_oma_cd = "0";
            //   ws_oma_cd_1 = "0";
            //   ws_oma_cd_2 = "ZZZZZ";
            // 	go to ha0-99-exit.;

            if (ws_oma_cd_1_1.Equals(this.flag_oma_cd_all))
            {
                ws_oma_cd_2 = "";
                Display("scr-oma-cd-2.");
                hold_oma_cd = "0";
                ws_oma_cd_1 = "0";
                ws_oma_cd_2 = "ZZZZZ";
                await ha0_99_exit();
                return;
            }

            hold_oma_cd = ws_oma_cd_1;
        }

        private async Task ha0_10_acpt_cd_2()
        {
            // accept scr-oma-cd-2.;
            Display("scr-oma-cd-2.");
            await Prompt("ws_oma_cd_2", isBatchProcess);

            // if ws-oma-cd-2 = spaces then;            
            //    ws_oma_cd_2 = ws_oma_cd_1;
            // 	  go to ha0-99-exit.;

            if(string.IsNullOrWhiteSpace(ws_oma_cd_2))
            {
                ws_oma_cd_2 = ws_oma_cd_1;
                await ha0_99_exit();
                return;
            }

            // if ws-oma-cd-2 < ws-oma-cd-1 then;            
            //    err_ind = 8;
            // 	perform za0-common-error	thru za0-99-exit;
            // 	go to ha0-acpt-oma-code.;

            // if (Util.NumInt(ws_oma_cd_2) < Util.NumInt(ws_oma_cd_1))  // todo check the value
            if ( ws_oma_cd_2.Trim().CompareTo(ws_oma_cd_1.Trim()) < 0)  // todo check the value
            {
                err_ind = 8;
                await za0_common_error();
                await za0_99_exit();
                await ha0_acpt_oma_code();
                return;
            }
        }
        private async Task ha0_99_exit()
        {
            //     exit.;
        }

        private async Task ja0_acpt_user_verif()
        {
            //     display scr-acpt-user-verif.;
            //     accept scr-acpt-user-verif.;
            Display("scr-acpt-user-verif.");
            await Prompt("flag_user_resp", isBatchProcess);

            // if flag-user-resp = 'A' or flag-user-resp = 'R' or flag-user-resp = 'M' then            
            // 	  next sentence;
            // else;
            //    err_ind = 1;
            // 	  perform za0-common-error	thru za0-99-exit;
            //    flag_user_resp = "' '";
            // 	  go to ja0-acpt-user-verif.;

            if (flag_user_resp.ToUpper().Equals("A") || flag_user_resp.ToUpper().Equals("R") || flag_user_resp.ToUpper().Equals("M"))
            {
                // next sentence
            } else
            {
                err_ind = 1;
                await za0_common_error();
                await za0_99_exit();
                flag_user_resp = " ";
                await ja0_acpt_user_verif();
                return;
            }
        }
        private async Task ja0_99_exit()
        {
            //     exit.;
        }

        private async Task la0_select_proc_rd_nxt_docrev()
        {
            flag_valid_docrev_rec = "N";

            //     perform lb0-select-docrev		thru lb0-99-exit;
            // 		until   flag-valid-docrev-rec-y;
            // 		     or flag-request-complete-y.;

            do
            {
                await lb0_select_docrev();
                await lb0_90_read_docrev_approx();
                await lb0_99_exit();
            } while (!flag_valid_docrev_rec.Equals(this.flag_valid_docrev_rec_y) && !flag_valid_docrev_rec.Equals(this.flag_request_complete_y));

            // if flag-request-complete-n then            
            // 	    perform ld0-process-dept-rd-nxt	thru ld0-99-exit.;

            if (flag_request_complete.Equals(this.flag_request_complete_n))
            {
               await ld0_process_dept_rd_nxt();
               await ld0_99_exit();
            }
        }
        private async Task la0_99_exit()
        {
            //     exit.;
        }

        private async Task lb0_select_docrev()
        {
            // if docrev-dept not = hold-dept then            
            //     flag_request_complete = "Y";
            // 	   go to lb0-99-exit.;

            if (!objF050_DOC_REVENUE_MSTR.DOCREV_DEPT.Equals(hold_dept))
            {
                flag_request_complete = "Y";
                await lb0_99_exit();
                return;
            }

            // if flag-doc-nbr-all and flag-loc-all then            
            // 	  perform lb3-check-oma-cd	thru lb3-99-exit;
            // 	  if ok then            
            //       flag_valid_docrev_rec = "Y";
            // 	     go to lb0-99-exit;
            // 	  else if flag-skip-read-approx-y then                       
            // 		 go to lb0-99-exit;
            // 	  else
            //       go to lb0-90-read-docrev-approx;
            // else
            // 	  next sentence.;

            ws_doc_nbr_1 = ws_doc_nbr.PadRight(3,' ').Substring(0, 1);
            ws_loc_1_1 = ws_loc_1.PadRight(4,' ').Substring(0, 1);
            if (ws_doc_nbr_1.Equals(this.flag_doc_nbr_all) && ws_loc_1_1.Equals(this.flag_loc_all))
            {
                await lb3_check_oma_cd();
                await lb3_99_exit();
                if (flag.Equals(ok))
                {
                    flag_valid_docrev_rec = "Y";
                    await lb0_99_exit();
                    return;
                }
                else if (flag_skip_read_approx.Equals(this.flag_skip_read_approx_y))
                {
                    await lb0_99_exit();
                    return;
                }
                else
                {
                    await lb0_90_read_docrev_approx();
                    return;
                }
            }

            //  if flag-doc-nbr-all and not flag-loc-all then                       
            // 	   if docrev-location = ws-loc(ss-loc-ptr) then            
            // 	        perform lb3-check-oma-cd	thru lb3-99-exit;
            // 	        if ok then            
            //             flag_valid_docrev_rec = "Y";
            // 		       go to lb0-99-exit;
            // 	        else if flag-skip-read-approx-y then                      
            // 		       go to lb0-99-exit;
            // 		    else;
            // 		       go to lb0-90-read-docrev-approx;
            // 	   else if docrev-location < ws-loc(ss-loc-ptr) then                       
            //          hold_doc_nbr = objDocrev_master_rec.docrev_doc_nbr;
            //          hold_loc = ws_loc[ss_loc_ptr];
            // 		    go to lb0-90-read-docrev-approx;
            // 	   else
            // 		    perform lb1-obtain-nxt-loc thru lb1-99-exit;
            // 		    if ok then            
            // 		       perform xx0-increment-doc-nbr;
            // 					thru xx0-99-exit;
            //             hold_doc_nbr = objDocrev_master_rec.docrev_doc_nbr;
            //             ss_loc_ptr = 1;
            //             hold_loc = ws_loc[ss_loc_ptr];
            // 		       go to lb0-90-read-docrev-approx;
            // 		    else;
            // 		       go to lb0-90-read-docrev-approx;
            //  else;
            // 	   next sentence.;

            if (ws_doc_nbr_1.Equals(this.flag_doc_nbr_all) && !ws_loc_1_1.Equals(this.flag_loc_all))
            {
                if (objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION.Equals(ws_loc[ss_loc_ptr]))
                {
                   await lb3_check_oma_cd();
                   await lb3_99_exit();
                   if(flag.Equals(ok))
                    {
                        flag_valid_docrev_rec = "Y";
                        await lb0_99_exit();
                        return;
                    }
                   else if (flag_skip_read_approx.Equals(this.flag_skip_read_approx_y))
                    {
                        await lb0_99_exit();
                        return;
                    }
                   else
                    {
                        await lb0_90_read_docrev_approx();
                        return;
                    }
                }
                // else if (objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION < ws_loc[ss_loc_ptr]) // TODO: Icomparable
                else if (Util.Str(objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION).Trim().CompareTo(Util.Str(ws_loc[ss_loc_ptr]).Trim())  < 0 ) 
                {
                    hold_doc_nbr = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
                    hold_loc = ws_loc[ss_loc_ptr];
                    await lb0_90_read_docrev_approx();
                    return;
                }
                else
                {
                    await lb1_obtain_nxt_loc();
                    await lb1_99_exit();
                    if (flag.Equals(ok))
                    {
                        await xx0_increment_doc_nbr();
                        await xx0_99_exit();
                        hold_doc_nbr = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
                        ss_loc_ptr = 1;
                        hold_loc = ws_loc[ss_loc_ptr];
                        await lb0_90_read_docrev_approx();
                        return;
                    }
                    else
                    {
                        await lb0_90_read_docrev_approx();
                        return;
                    }
                }
            } else
            {
                // next sentence;
            }

            //  if not flag-doc-nbr-all and not flag-loc-all then                       
            // 	      if docrev-doc-nbr not = hold-doc-nbr then            
            //           flag_request_complete = "Y";
            // 	         go to lb0-99-exit;
            // 	      else if docrev-location not = hold-loc then                       
            // 		         perform lb1-obtain-nxt-loc;
            // 					thru lb1-99-exit;
            // 		        if ok then            
            //                  flag_request_complete = "Y";
            // 		            go to lb0-99-exit;
            // 		        else
            // 		            go to lb0-90-read-docrev-approx
            // 	     else
            // 		        perform lb3-check-oma-cd;
            // 					thru lb3-99-exit;
            // 		       if ok then;
            //                flag_valid_docrev_rec = "Y";
            // 		          go to lb0-99-exit;
            // 		       else if flag-skip-read-approx-y then                       
            // 			        go to lb0-99-exit;
            // 		       else;
            // 			        perform lb1-obtain-nxt-loc;
            // 					     thru lb1-99-exit;
            // 			        if ok then            
            //                      flag_request_complete = "Y";
            // 			            go to lb0-99-exit;
            // 			        else;
            // 			            go to lb0-90-read-docrev-approx;
            //  else;
            // 	   next sentence.;

            if (!ws_doc_nbr_1.Equals(this.flag_doc_nbr_all) && !ws_loc_1_1.Equals(this.flag_loc_all))
            {
                if (objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR != hold_doc_nbr )
                {
                    flag_request_complete = "Y";
                    await lb0_99_exit();
                    return;
                }
                else if (objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION != hold_loc)
                {
                    await lb1_obtain_nxt_loc();
                    await lb1_99_exit();
                    if (flag.Equals(ok))
                    {
                        flag_request_complete = "Y";
                        await lb0_99_exit();
                        return;
                    }
                    else
                    {
                        await lb0_90_read_docrev_approx();
                        return;
                    }
                }
                else
                {
                    await lb3_check_oma_cd();
                    await lb3_99_exit();
                    if (flag.Equals(ok))
                    {
                        flag_valid_docrev_rec = "Y";
                        await lb0_99_exit();
                        return;
                    }
                    else if (flag_skip_read_approx.Equals(this.flag_skip_read_approx_y))
                    {
                        await lb0_99_exit();
                        return;
                    }
                    else
                    {
                        await lb1_obtain_nxt_loc();
                        await lb1_99_exit();
                        if(flag.Equals(ok))
                        {
                            flag_request_complete = "Y";
                            await lb0_99_exit();
                            return;
                        }
                        else
                        {
                            await lb0_90_read_docrev_approx();
                            return;
                        }
                    }
                }
            }
            else
            {
                // next sentence
            }

            //  if not flag-doc-nbr-all and flag-loc-all  then;                       
            // 	      if docrev-doc-nbr not = hold-doc-nbr then            
            //            flag_request_complete = "Y";
            // 	          go to lb0-99-exit;
            // 	      else;
            // 	          perform lb3-check-oma-cd	thru lb3-99-exit;
            // 	          if ok then            
            //               flag_valid_docrev_rec = "Y";
            // 		         go to lb0-99-exit;
            // 	          else if flag-skip-read-approx-y then                      
            // 		         go to lb0-99-exit;
            // 		      else;
            // 		         next sentence;
            //  else;
            // 	   next sentence.;

            if (!ws_doc_nbr_1.Equals(this.flag_doc_nbr_all) && ws_loc_1_1.Equals(this.flag_loc_all))
            {
                if (objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR != hold_doc_nbr)
                {
                    flag_request_complete = "Y";
                    await lb0_99_exit();
                    return;
                }
                else
                {
                    await lb3_check_oma_cd();
                    await lb3_99_exit();
                    if (flag.Equals(ok))
                    {
                        flag_valid_docrev_rec = "Y";
                        await lb0_99_exit();
                        return;
                    }
                    else if (flag_skip_read_approx.Equals(this.flag_skip_read_approx_y))
                    {
                        await lb0_99_exit();
                        return;
                    }
                    else
                    {
                        // next sentence
                    }
                }
            }
            else
            {
                // next sentence..
            }
        }

        private async Task lb0_90_read_docrev_approx()
        {

            // objDocrev_master_rec.docrev_key = hold_doc_key;
            // flag = "Y";
            //     perform xe0-read-docrev-approx	thru xe0-99-exit.;

            // hold_doc_key
            //  hold-clinic-nbr
            //  hold-dept
            //  hold-doc-nbr
            //  hold-loc
            //  hold-oma-cd 

            objF050_DOC_REVENUE_MSTR.WhereDocrev_clinic_1_2 = hold_clinic_nbr;
            objF050_DOC_REVENUE_MSTR.WhereDocrev_dept = hold_dept;
            objF050_DOC_REVENUE_MSTR.WhereDocrev_doc_nbr = hold_doc_nbr;
            objF050_DOC_REVENUE_MSTR.WhereDocrev_location = hold_loc;
            objF050_DOC_REVENUE_MSTR.WhereDocrev_oma_code = hold_oma_cd;

            flag = "Y";
            await xe0_read_docrev_approx();
            await xe0_99_exit();
        }

        private async Task lb0_99_exit()
        {
            //    exit.;
        }

        private async Task lb1_obtain_nxt_loc()
        {
            // if ss-loc-ptr < ws-max-nbr-loc and ws-loc(ss-loc-ptr + 1) not = spaces then            
            // 	  add 1				to ss-loc-ptr;
            //    hold_loc = ws_loc[ss_loc_ptr];
            //    flag = "N";
            // else
            //    flag = "Y";

            if (ss_loc_ptr < ws_max_nbr_loc && !string.IsNullOrWhiteSpace(ws_loc[ss_loc_ptr + 1]) )
            {
                ss_loc_ptr++;
                hold_loc = ws_loc[ss_loc_ptr];
                flag = "N";
            }
            else
            {
                flag = "Y";
            }

            // if flag-oma-cd-all then            
            //    hold_oma_cd = "0";
            // else
            //    hold_oma_cd = ws_oma_cd_1;

            ws_oma_cd_1 = ws_oma_cd_1.PadRight(5, ' ');
            ws_oma_cd_1_1 = ws_oma_cd_1.Substring(0, 1);

            if (ws_oma_cd_1_1.Equals(flag_oma_cd_all))
            {
                hold_oma_cd = "0";
            }else
            {
                hold_oma_cd = ws_oma_cd_1;
            }
        }

        private async Task lb1_99_exit()
        {
            //     exit.;
        }
        private async Task lb3_check_oma_cd()
        {

            // if  docrev-oma-cd not < ws-oma-cd-1 and docrev-oma-cd not > ws-oma-cd-2 then            
            //     flag = "Y";
            // 	    go to lb3-99-exit;
            // else;
            //      flag_skip_read_approx = "N";
            //      flag = "N";            
            // 	    if docrev-oma-cd < ws-oma-cd-1 then            
            // 	          perform xc0-read-next-docrev;
            // 					thru xc0-99-exit;
            //            flag_skip_read_approx = "Y";
            // 	          go to lb3-99-exit;
            // 	     else;
            // 	          next sentence.;

            //if (objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE < ws_oma_cd_1 && !objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE > ws_oma_cd_2 ) // todo  Icomparable
            if (Util.Str(objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE).Trim().CompareTo( Util.Str(ws_oma_cd_1).Trim()) < 0 && Util.Str(objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE).Trim().CompareTo(Util.Str(ws_oma_cd_2).Trim())  <= 0 ) // todo  Icomparable
            {
                flag = "Y";
                await lb3_99_exit();
                return;
            }
            else
            {
                flag_skip_read_approx = "N";
                flag = "N";
                //if (objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE < ws_oma_cd_1) // todo  Icomparable
                if (Util.Str(objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE).Trim().CompareTo(Util.Str(ws_oma_cd_1).Trim()) < 0) // todo  Icomparable
                {
                    await xc0_read_next_docrev();
                    await xc0_99_exit();
                    flag_skip_read_approx = "Y";
                    await lb3_99_exit();
                    return;

                } else
                {
                    // next sentence
                }
            }


            // hold_oma_cd = "ZZZZZ";
            // if flag-loc-all then            
            //     hold_loc = objDocrev_master_rec.docrev_location;

            hold_oma_cd = "ZZZZZ";
            ws_loc_1 = ws_loc_1.PadRight(4, ' ');
            ws_loc_1_1 = ws_loc_1.Substring(0, 1);

            if (ws_loc_1_1.Equals(flag_loc_all))
            {
                hold_loc = objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION;
            }

            // if flag-doc-nbr-all then            
            //     hold_doc_nbr = objDocrev_master_rec.docrev_doc_nbr;

            ws_doc_nbr = ws_doc_nbr.PadRight(3, ' ');
            ws_doc_nbr_1 = ws_doc_nbr.Substring(0, 1);
            if (ws_doc_nbr_1.Equals(this.flag_doc_nbr_all))
            {
                hold_doc_nbr = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
            }
        }

        private async Task lb3_99_exit()
        {
            //     exit.;
        }

        private async Task ld0_process_dept_rd_nxt()
        {
            //     perform ld1-update-cntrs		thru ld1-99-exit.;
            await ld1_update_cntrs();
            await ld1_99_exit();

            //     perform xc0-read-next-docrev	thru xc0-99-exit.;
            await xc0_read_next_docrev();
            await xc0_99_exit();
        }

        private async Task ld0_99_exit()
        {
            //     exit.;
        }

        private async Task ld1_update_cntrs()
        {

            // if docrev-location = 'MISC' then;            
            // 	    add docrev-mtd-out-svc		to ws-misc-svc-mtd;
            // 					                   ws-total-svc-mtd;
            // 	    add docrev-mtd-out-rec		to ws-misc-amt-mtd;
            // 					               ws-total-amt-mtd;
            // 	    add docrev-ytd-out-svc		to ws-misc-svc-ytd;
            // 					               ws-total-svc-ytd;
            // 	    add docrev-ytd-out-rec		to ws-misc-amt-ytd;
            // 					               ws-total-amt-ytd;
            // else;
            // 	    add docrev-mtd-in-svc		to ws-in-svc-mtd;
            // 		  			                   ws-total-svc-mtd;
            // 	    add docrev-mtd-in-rec		to ws-in-amt-mtd;
            // 					                   ws-total-amt-mtd;
            // 	    add docrev-mtd-out-svc		to ws-out-svc-mtd;
            // 					                   ws-total-svc-mtd;
            // 	    add docrev-mtd-out-rec		to ws-out-amt-mtd;
            // 					                   ws-total-amt-mtd;
            // 	    add docrev-ytd-in-svc		to ws-in-svc-ytd;
            // 					                   ws-total-svc-ytd;
            // 	    add docrev-ytd-in-rec		to ws-in-amt-ytd;
            // 					                   ws-total-amt-ytd;
            // 	    add docrev-ytd-out-svc		to ws-out-svc-ytd;
            // 					                   ws-total-svc-ytd;
            // 	    add docrev-ytd-out-rec		to ws-out-amt-ytd;
            // 					                   ws-total-amt-ytd.;

            if (objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION.ToUpper().Equals("MISC"))
            {
                // 	    add docrev-mtd-out-svc		to ws-misc-svc-mtd;
                // 					                   ws-total-svc-mtd;
                ws_misc_svc_mtd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_SVC);
                ws_total_svc_mtd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_SVC);

                // 	    add docrev-mtd-out-rec		to ws-misc-amt-mtd;
                // 					               ws-total-amt-mtd;
                ws_misc_amt_mtd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_REC);
                ws_total_amt_mtd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_REC);

                // 	    add docrev-ytd-out-svc		to ws-misc-svc-ytd;
                // 					               ws-total-svc-ytd;
                ws_misc_svc_ytd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_SVC);
                ws_total_svc_ytd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_SVC);

                // 	    add docrev-ytd-out-rec		to ws-misc-amt-ytd;
                // 					               ws-total-amt-ytd;
                ws_misc_amt_ytd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_REC);
                ws_total_amt_ytd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_REC);
            }
            else
            {
                // 	    add docrev-mtd-in-svc		to ws-in-svc-mtd;
                // 		  			                   ws-total-svc-mtd;
                ws_in_svc_mtd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_IN_SVC);
                ws_total_svc_mtd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_IN_SVC);

                // 	    add docrev-mtd-in-rec		to ws-in-amt-mtd;
                // 					                   ws-total-amt-mtd;
                ws_in_amt_mtd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_IN_REC);
                ws_total_amt_mtd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_IN_REC);

                // 	    add docrev-mtd-out-svc		to ws-out-svc-mtd;
                // 					                   ws-total-svc-mtd;
                ws_out_svc_mtd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_SVC);
                ws_total_svc_mtd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_SVC);

                // 	    add docrev-mtd-out-rec		to ws-out-amt-mtd;
                // 					                   ws-total-amt-mtd;
                ws_out_amt_mtd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_REC);
                ws_total_amt_mtd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_REC);

                // 	    add docrev-ytd-in-svc		to ws-in-svc-ytd;
                // 					                   ws-total-svc-ytd;
                ws_in_svc_ytd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_IN_SVC);
                ws_total_svc_ytd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_IN_SVC);

                // 	    add docrev-ytd-in-rec		to ws-in-amt-ytd;
                // 					                   ws-total-amt-ytd;
                ws_in_amt_ytd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_IN_REC);
                ws_total_amt_ytd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_IN_REC);

                // 	    add docrev-ytd-out-svc		to ws-out-svc-ytd;
                // 					                   ws-total-svc-ytd;
                ws_out_svc_ytd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_SVC);
                ws_total_svc_ytd += Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_SVC);

                // 	    add docrev-ytd-out-rec		to ws-out-amt-ytd;
                // 					                   ws-total-amt-ytd.;
                ws_out_amt_ytd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_REC);
                ws_total_amt_ytd += Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_REC);
            }
        }
        private async Task ld1_99_exit()
        {
            //     exit.;
        }
        private async Task pa0_print_copy()
        {
            //     display scr-acpt-hard-copy.;
            //     accept  scr-acpt-hard-copy.;
            //     if ok;
            //     then;
            // 	perform pa1-print-hard-copy	thru pa1-99-exit.;

            Display("scr-acpt-hard-copy.");
            await Prompt("flag", isBatchProcess);

            if (flag.Equals(ok))
            {
               await  pa1_print_hard_copy();
               await pa1_99_exit();
            }
        }
        private async Task pa0_99_exit()
        {
            //     exit.;
        }

        private async Task pa1_print_hard_copy()
        {
            hard_copy_flag = "Y";
        }

        private async Task pa1_99_exit()
        {
            //     exit.;
        }

        private async Task xa0_clear_values()
        {

            //ws_hold_scr_values = "";            
            ws_request_clinic_nbr_1 = string.Empty;
            ws_dept = string.Empty;
            ws_dept_r_grp = string.Empty;
            ws_dept_1 = string.Empty;
            ws_dept_2 = string.Empty;
            ws_dept_num = 0;
            ws_dept_name = string.Empty;
            ws_doc_nbr = string.Empty;
            ws_doc_nbr_1 = string.Empty;
            ws_loc_1 = string.Empty;
            ws_loc_1_1 = string.Empty;
            ws_loc_2 = string.Empty;
            ws_loc_3 = string.Empty;
            ws_loc_4 = string.Empty;
            ws_loc_5 = string.Empty;        
            ws_loc = new string[6];
            ws_oma_cd_1 = string.Empty;
            ws_oma_cd_1_1 = string.Empty;
            ws_oma_cd_2 = string.Empty;        
            ws_oma_cd = new string[3];


            //hold_doc_key = "";        
            hold_clinic_nbr = string.Empty;
            hold_dept = 0;
            hold_doc_nbr = string.Empty;
            hold_loc = string.Empty;
            hold_oma_cd = string.Empty;

            ws_request_clinic_nbr = "";
            ws_dept_name = "";

            // if ws-oma-cd-1 = zeros and ws-oma-cd-2 = "ZZZZZ" then            
            //ws_oma_cd_1 = "*";
            //ws_oma_cd_2 = "";

            if (Util.NumInt(ws_oma_cd_1) == 0 && ws_oma_cd_2 == "ZZZZZ")
            {
                ws_oma_cd_1 = "*";
                ws_oma_cd_2 = "";
            }

            // ws_fees_oma = 0;
            ws_in_svc_mtd = 0;
            ws_in_amt_mtd = 0;
            ws_out_svc_mtd = 0;
            ws_out_amt_mtd = 0;
            ws_misc_svc_mtd = 0;
            ws_misc_amt_mtd = 0;
            ws_total_svc_mtd = 0;
            ws_total_amt_mtd = 0;
            ws_in_svc_ytd = 0;
            ws_in_amt_ytd = 0;
            ws_out_svc_ytd = 0;
            ws_out_amt_ytd = 0;
            ws_misc_svc_ytd = 0;
            ws_misc_amt_ytd = 0;
            ws_total_svc_ytd = 0;
            ws_total_amt_ytd = 0;        
            ws_fees_mtd_ytd = new string[3];
            ws_in_svc = new int[3];
            ws_in_amt = new decimal[3];
            ws_out_svc = new int[3];
            ws_out_amt = new decimal[3];
            ws_misc_svc = new int[3];
            ws_misc_amt = new decimal[3];
            ws_total_svc = new int[3];
            ws_total_amt = new decimal[3];

            ws_dept = "0";
            hold_dept = 0;
            hold_doc_nbr = "0";            
        }
        private async Task xa0_99_exit()
        {
            //     exit.;
        }
        private async Task xc0_read_next_docrev()
        {
            // read docrev-mstr next;
            // 	at end;
            //flag_request_complete = "Y";
            // 	    go to xc0-99-exit.;
            //     add 1				to ctr-read-docrev-mstr.;
           
            F050_DOC_REVENUE_MSTR_Collection = new F050_DOC_REVENUE_MSTR  // using the sequential read after reading the starting record point
            {
                WhereDocrev_clinic_1_2 = hold_clinic_nbr,
                WhereDocrev_dept = hold_dept,
                WhereDocrev_doc_nbr = hold_doc_nbr,
                WhereDocrev_location = hold_loc,
                WhereDocrev_oma_code = hold_oma_cd
            }.Collection_UsingStart();
                        
            if (F050_DOC_REVENUE_MSTR_Collection.Count() == 0)
            {
                flag_request_complete = "Y";
                await xc0_99_exit();
                return;
            }
            else
            {
                if (ctr_read_docrev_mstr >= F050_DOC_REVENUE_MSTR_Collection.Count())
                {
                    flag_request_complete = "Y";
                    await xc0_99_exit();
                    return;
                }
                else
                {
                    var ctr = 0;
                    foreach(var obj in F050_DOC_REVENUE_MSTR_Collection)
                    {
                        if (ctr == ctr_read_docrev_mstr)
                        {
                            objF050_DOC_REVENUE_MSTR = obj;
                            ctr_read_docrev_mstr++;
                            break;
                        }
                        ctr++;
                    }
                }
            }
        }
        private async Task xc0_99_exit()
        {
            //     exit.;
        }
        private async Task xe0_read_docrev_approx()
        {
            //  start docrev-mstr key is greater than or equal to docrev-key;
            // 	invalid key;
            //      err_ind = 6;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;
           
            //  read docrev-mstr next;
            //    	at end;
            //      err_ind = 6;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;
            //     add 1				to ctr-read-docrev-mstr.;
           

            F050_DOC_REVENUE_MSTR_Collection = new F050_DOC_REVENUE_MSTR  // using the sequential read after reading the starting record point
            {
                WhereDocrev_clinic_1_2 = hold_clinic_nbr,
                WhereDocrev_dept = hold_dept,
                WhereDocrev_doc_nbr = hold_doc_nbr,
                WhereDocrev_location = hold_loc,
                WhereDocrev_oma_code = hold_oma_cd
            }.Collection_UsingStart();

            if (F050_DOC_REVENUE_MSTR_Collection.Count() == 0)
            {
                err_ind = 6;
                await za0_common_error();
                await za0_99_exit();
                await az0_end_of_job();
                return;
            }
            else
            {
                if (ctr_read_docrev_mstr >= F050_DOC_REVENUE_MSTR_Collection.Count())
                {
                    err_ind = 6;
                    await za0_common_error();
                    await za0_99_exit();
                    await az0_end_of_job();
                    return;
                }
                else
                {
                    var ctr = 0;
                    foreach (var obj in F050_DOC_REVENUE_MSTR_Collection)
                    {
                        if (ctr == ctr_read_docrev_mstr)
                        {
                            objF050_DOC_REVENUE_MSTR = obj;
                            ctr_read_docrev_mstr++;
                            break;
                        }
                        ctr++;
                    }
                }
            }            
        }
        private async Task xe0_99_exit()
        {
            //     exit.;
        }
        private async Task xx0_increment_doc_nbr()
        {
            //flag_request_complete = "N";
            //     display "BEFORE: " docrev-doc-nbr.;
            //     perform xx1-process-1-doc-position	thru xx1-99-exit;
            // 	varying   ss from 1 by 1;
            // 	until     ss > 3;
            //            or      flag-request-complete-y.;
            //     display "AFTER : " docrev-doc-nbr.;

            flag_request_complete = "N";
            docrev_doc_nbr_before = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
            Display("docrev-doc-nbr-Before.");

            ss = 1;
            do {
                await xx1_process_1_doc_position();
                await xx0_90_return();
                await xx1_99_exit();
                ss++;
            } while (ss <= 3 && !flag_request_complete.Equals(this.flag_request_complete_y));

            docrev_doc_nbr_after = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
            Display("docrev-doc-nbr-After.");
        }
        private async Task xx0_99_exit()
        {
            //    exit.;
        }
        private async Task xx1_process_1_doc_position()
        {
            // if tmp-doc-nbr-pos(ss) = "0" then;            
            //     tmp_doc_nbr_pos[ss] = "1";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "1" then            
            //     tmp_doc_nbr_pos[ss] = "2";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "2" then;                      
            //     tmp_doc_nbr_pos[ss] = "3";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "3"  then;            
            //     tmp_doc_nbr_pos[ss] = "4";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "4" then;                     
            //     tmp_doc_nbr_pos[ss] = "5";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "5"  then;            
            //     tmp_doc_nbr_pos[ss] = "6";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "6" then;            
            //     tmp_doc_nbr_pos[ss] = "7";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "7" then            
            //     tmp_doc_nbr_pos[ss] = "8";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "8" then            
            //     tmp_doc_nbr_pos[ss] = "9";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "9" then            
            //     tmp_doc_nbr_pos[ss] = "A";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "A" then;            
            //     tmp_doc_nbr_pos[ss] = "B";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "B" then;                       
            //     tmp_doc_nbr_pos[ss] = "C";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "C" then            
            //     tmp_doc_nbr_pos[ss] = "D";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "D" then            
            //     tmp_doc_nbr_pos[ss] = "E";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "E" then                       
            //     tmp_doc_nbr_pos[ss] = "F";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "F" then            
            //     tmp_doc_nbr_pos[ss] = "G";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "G" then            
            //     tmp_doc_nbr_pos[ss] = "H";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "H" then            
            //     tmp_doc_nbr_pos[ss] = "I";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "I" then                       
            //     tmp_doc_nbr_pos[ss] = "J";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "J" then                        
            //     tmp_doc_nbr_pos[ss] = "K";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "K" then            
            //     tmp_doc_nbr_pos[ss] = "L";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "L" then            
            //     tmp_doc_nbr_pos[ss] = "M";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "M" then            
            //     tmp_doc_nbr_pos[ss] = "N";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "N" then            
            //     tmp_doc_nbr_pos[ss] = "O";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "O" then            
            //     tmp_doc_nbr_pos[ss] = "P";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "P" then            
            //     tmp_doc_nbr_pos[ss] = "Q";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "B" then            
            //     tmp_doc_nbr_pos[ss] = "R";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "R" then            
            //     tmp_doc_nbr_pos[ss] = "S";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "S" then                        
            //     tmp_doc_nbr_pos[ss] = "T";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "T" then                       
            //     tmp_doc_nbr_pos[ss] = "U";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "U" then                       
            //     tmp_doc_nbr_pos[ss] = "V";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "V" then            
            //     tmp_doc_nbr_pos[ss] = "W";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "W" then            
            //     tmp_doc_nbr_pos[ss] = "X";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "X" then                        
            //     tmp_doc_nbr_pos[ss] = "Y";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "Y" then                        
            //     tmp_doc_nbr_pos[ss] = "Z";
            // 	   go to xx0-90-return;
            // else if tmp-doc-nbr-pos(ss) = "Z" then                       
            //     tmp_doc_nbr_pos[ss] = "0";
            // 	   go to xx0-99-exit.;


            if (tmp_doc_nbr_pos[ss] == "0")
            {
                tmp_doc_nbr_pos[ss] = "1";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "1")
            {
                tmp_doc_nbr_pos[ss] = "2";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "2")
            {
                tmp_doc_nbr_pos[ss] = "3";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "3")
            {
                tmp_doc_nbr_pos[ss] = "4";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "4")
            {
                tmp_doc_nbr_pos[ss] = "5";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "5")
            {
                tmp_doc_nbr_pos[ss] = "6";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "6")
            {
                tmp_doc_nbr_pos[ss] = "7";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "7")
            {
                tmp_doc_nbr_pos[ss] = "8";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "8")
            {
                tmp_doc_nbr_pos[ss] = "9";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "9")
            {
                tmp_doc_nbr_pos[ss] = "A";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "A")
            {
                tmp_doc_nbr_pos[ss] = "B";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "B")
            {
                tmp_doc_nbr_pos[ss] = "C";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "C")
            {
                tmp_doc_nbr_pos[ss] = "D";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "D")
            {
                tmp_doc_nbr_pos[ss] = "E";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "E")
            {
                tmp_doc_nbr_pos[ss] = "F";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "F")
            {
                tmp_doc_nbr_pos[ss] = "G";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "G")
            {
                tmp_doc_nbr_pos[ss] = "H";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "H")
            {
                tmp_doc_nbr_pos[ss] = "I";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "I")
            {
                tmp_doc_nbr_pos[ss] = "J";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "J")
            {
                tmp_doc_nbr_pos[ss] = "K";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "K")
            {
                tmp_doc_nbr_pos[ss] = "L";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "L")
            {
                tmp_doc_nbr_pos[ss] = "M";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "M")
            {
                tmp_doc_nbr_pos[ss] = "N";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "N")
            {
                tmp_doc_nbr_pos[ss] = "O";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "O")
            {
                tmp_doc_nbr_pos[ss] = "P";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "P")
            {
                tmp_doc_nbr_pos[ss] = "Q";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "B")
            {
                tmp_doc_nbr_pos[ss] = "R";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "R")
            {
                tmp_doc_nbr_pos[ss] = "S";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "S")
            {
                tmp_doc_nbr_pos[ss] = "T";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "T")
            {
                tmp_doc_nbr_pos[ss] = "U";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "U")
            {
                tmp_doc_nbr_pos[ss] = "V";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "V")
            {
                tmp_doc_nbr_pos[ss] = "W";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "W")
            {
                tmp_doc_nbr_pos[ss] = "X";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "X")
            {
                tmp_doc_nbr_pos[ss] = "Y";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "Y")
            {
                tmp_doc_nbr_pos[ss] = "Z";
                await xx0_90_return();
                return;
            }
            else if (tmp_doc_nbr_pos[ss] == "Z")
            {
                     tmp_doc_nbr_pos[ss] = "0";
                 	   await xx0_90_return();
                return;
            }

        }
        private async Task xx0_90_return()
        {
            flag_request_complete = "Y";
        }
        private async Task xx1_99_exit()
        {
            //     exit.;
        }
        private async Task za0_common_error()
        {
            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            //     accept scr-confirm.;
            //     display blank-line-24.;

            Display("err-msg-line.");
            await Prompt("confirm_space", isBatchProcess);
            EraseRow(24);
        }
        private async Task za0_99_exit()
        {
            //     exit.;
        }
        #endregion
    }
}

