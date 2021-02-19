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
    public class U041ViewModel : CommonFunctionScr
    {

        public U041ViewModel()
        {

        }

        #region FD Section
        // FD: audit_file
        private Audit_record objAudit_rec = null;
        private ObservableCollection<Audit_record> Audit_rec_Collection;

        // FD: error_file
        private Error_record objError_rec = null;
        private ObservableCollection<Error_record> Error_rec_Collection;

        // FD: oma_fee_mstr	Copy : f040_oma_fee_mstr.fd
        private F040_OMA_FEE_MSTR objFee_mstr_rec = null;
        private ObservableCollection<F040_OMA_FEE_MSTR> Fee_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_2.ws
        private CONSTANTS_MSTR_REC_2 objConstants_mstr_rec_2 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_2> Constants_mstr_rec_2_Collection;

        // FD: ohip_benefit_sched_tape	Copy : t040_ohip_sched_tape.fd
        private Ohip_Benefit_Sched_Rec objOhip_benefit_sched_rec = null;
        private ObservableCollection<Ohip_Benefit_Sched_Rec> Ohip_benefit_sched_rec_Collection;

        private ReportPrint objAuditFile = null;
        private ReportPrint objErrorFile = null;


        #endregion

        #region Properties
        private string _bypass_code_1;
        public string bypass_code_1
        {
            get
            {
                return _bypass_code_1;
            }
            set
            {
                if (_bypass_code_1 != value)
                {
                    _bypass_code_1 = value;
                    _bypass_code_1 = _bypass_code_1.ToUpper();
                    RaisePropertyChanged("bypass_code_1");
                }
            }
        }

        private string _bypass_code_10;
        public string bypass_code_10
        {
            get
            {
                return _bypass_code_10;
            }
            set
            {
                if (_bypass_code_10 != value)
                {
                    _bypass_code_10 = value;
                    _bypass_code_10 = _bypass_code_10.ToUpper();
                    RaisePropertyChanged("bypass_code_10");
                }
            }
        }

        private string _bypass_code_2;
        public string bypass_code_2
        {
            get
            {
                return _bypass_code_2;
            }
            set
            {
                if (_bypass_code_2 != value)
                {
                    _bypass_code_2 = value;
                    _bypass_code_2 = _bypass_code_2.ToUpper();
                    RaisePropertyChanged("bypass_code_2");
                }
            }
        }

        private string _bypass_code_3;
        public string bypass_code_3
        {
            get
            {
                return _bypass_code_3;
            }
            set
            {
                if (_bypass_code_3 != value)
                {
                    _bypass_code_3 = value;
                    _bypass_code_3 = _bypass_code_3.ToUpper();
                    RaisePropertyChanged("bypass_code_3");
                }
            }
        }

        private string _bypass_code_4;
        public string bypass_code_4
        {
            get
            {
                return _bypass_code_4;
            }
            set
            {
                if (_bypass_code_4 != value)
                {
                    _bypass_code_4 = value;
                    _bypass_code_4 = _bypass_code_4.ToUpper();
                    RaisePropertyChanged("bypass_code_4");
                }
            }
        }

        private string _bypass_code_5;
        public string bypass_code_5
        {
            get
            {
                return _bypass_code_5;
            }
            set
            {
                if (_bypass_code_5 != value)
                {
                    _bypass_code_5 = value;
                    _bypass_code_5 = _bypass_code_5.ToUpper();
                    RaisePropertyChanged("bypass_code_5");
                }
            }
        }

        private string _bypass_code_6;
        public string bypass_code_6
        {
            get
            {
                return _bypass_code_6;
            }
            set
            {
                if (_bypass_code_6 != value)
                {
                    _bypass_code_6 = value;
                    _bypass_code_6 = _bypass_code_6.ToUpper();
                    RaisePropertyChanged("bypass_code_6");
                }
            }
        }

        private string _bypass_code_7;
        public string bypass_code_7
        {
            get
            {
                return _bypass_code_7;
            }
            set
            {
                if (_bypass_code_7 != value)
                {
                    _bypass_code_7 = value;
                    _bypass_code_7 = _bypass_code_7.ToUpper();
                    RaisePropertyChanged("bypass_code_7");
                }
            }
        }

        private string _bypass_code_8;
        public string bypass_code_8
        {
            get
            {
                return _bypass_code_8;
            }
            set
            {
                if (_bypass_code_8 != value)
                {
                    _bypass_code_8 = value;
                    _bypass_code_8 = _bypass_code_8.ToUpper();
                    RaisePropertyChanged("bypass_code_8");
                }
            }
        }

        private string _bypass_code_9;
        public string bypass_code_9
        {
            get
            {
                return _bypass_code_9;
            }
            set
            {
                if (_bypass_code_9 != value)
                {
                    _bypass_code_9 = value;
                    _bypass_code_9 = _bypass_code_9.ToUpper();
                    RaisePropertyChanged("bypass_code_9");
                }
            }
        }

        private decimal _const_asst_h_curr;
        public decimal const_asst_h_curr
        {
            get
            {
                return _const_asst_h_curr;
            }
            set
            {
                if (_const_asst_h_curr != value)
                {
                    _const_asst_h_curr = value;
                    RaisePropertyChanged("const_asst_h_curr");
                }
            }
        }

        private decimal _const_cert_h_curr;
        public decimal const_cert_h_curr
        {
            get
            {
                return _const_cert_h_curr;
            }
            set
            {
                if (_const_cert_h_curr != value)
                {
                    _const_cert_h_curr = value;
                    RaisePropertyChanged("const_cert_h_curr");
                }
            }
        }

        private int _const_dd_curr;
        public int const_dd_curr
        {
            get
            {
                return _const_dd_curr;
            }
            set
            {
                if (_const_dd_curr != value)
                {
                    _const_dd_curr = value;
                    RaisePropertyChanged("const_dd_curr");
                }
            }
        }

        private int _const_mm_curr;
        public int const_mm_curr
        {
            get
            {
                return _const_mm_curr;
            }
            set
            {
                if (_const_mm_curr != value)
                {
                    _const_mm_curr = value;
                    RaisePropertyChanged("const_mm_curr");
                }
            }
        }

        private decimal _const_reg_h_curr;
        public decimal const_reg_h_curr
        {
            get
            {
                return _const_reg_h_curr;
            }
            set
            {
                if (_const_reg_h_curr != value)
                {
                    _const_reg_h_curr = value;
                    RaisePropertyChanged("const_reg_h_curr");
                }
            }
        }

        private int _const_yy_curr;
        public int const_yy_curr
        {
            get
            {
                return _const_yy_curr;
            }
            set
            {
                if (_const_yy_curr != value)
                {
                    _const_yy_curr = value;
                    RaisePropertyChanged("const_yy_curr");
                }
            }
        }

        private int _ctr_nbr_errors;
        public int ctr_nbr_errors
        {
            get
            {
                return _ctr_nbr_errors;
            }
            set
            {
                if (_ctr_nbr_errors != value)
                {
                    _ctr_nbr_errors = value;
                    RaisePropertyChanged("ctr_nbr_errors");
                }
            }
        }

        private int _ctr_rates_implemented;
        public int ctr_rates_implemented
        {
            get
            {
                return _ctr_rates_implemented;
            }
            set
            {
                if (_ctr_rates_implemented != value)
                {
                    _ctr_rates_implemented = value;
                    RaisePropertyChanged("ctr_rates_implemented");
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

        private string _ohip_code;
        public string ohip_code
        {
            get
            {
                return _ohip_code;
            }
            set
            {
                if (_ohip_code != value)
                {
                    _ohip_code = value;
                    _ohip_code = _ohip_code.ToUpper();
                    RaisePropertyChanged("ohip_code");
                }
            }
        }

        public string print_file_1
        {
            get
            {
                return "AUDIT REPORT IS IN RU041A";
            }

        }


        public string print_file_2
        {
            get
            {
                return "ERROR REPORT IS IN RU041B";
            }
        }

        private string _reverify_flag;
        public string reverify_flag
        {
            get
            {
                return _reverify_flag;
            }
            set
            {
                if (_reverify_flag != value)
                {
                    _reverify_flag = value;
                    _reverify_flag = _reverify_flag.ToUpper();
                    RaisePropertyChanged("reverify_flag");
                }
            }
        }

        private string _sel_code;
        public string sel_code
        {
            get
            {
                return _sel_code;
            }
            set
            {
                if (_sel_code != value)
                {
                    _sel_code = value;
                    _sel_code = _sel_code.ToUpper();
                    RaisePropertyChanged("sel_code");
                }
            }
        }

        private string _status_file;
        public string status_file
        {
            get
            {
                return _status_file;
            }
            set
            {
                if (_status_file != value)
                {
                    _status_file = value;
                    _status_file = _status_file.ToUpper();
                    RaisePropertyChanged("status_file");
                }
            }
        }

        private int _sys_date_long;
        public int sys_date_long
        {
            get
            {
                return _sys_date_long;
            }
            set
            {
                if (_sys_date_long != value)
                {
                    _sys_date_long = value;
                    RaisePropertyChanged("sys_date_long");
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

        private string _verify_flag;
        public string verify_flag
        {
            get
            {
                return _verify_flag;
            }
            set
            {
                if (_verify_flag != value)
                {
                    _verify_flag = value;
                    _verify_flag = _verify_flag.ToUpper();
                    RaisePropertyChanged("verify_flag");
                }
            }
        }

        private int _ws_expected_ohip_reads;
        public int ws_expected_ohip_reads
        {
            get
            {
                return _ws_expected_ohip_reads;
            }
            set
            {
                if (_ws_expected_ohip_reads != value)
                {
                    _ws_expected_ohip_reads = value;
                    RaisePropertyChanged("ws_expected_ohip_reads");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private long temp_1 = 0;
        private int ws_2_yrs_ago = 0;
        private decimal ws_anae_asst_bypass_ind = 0.9999M;
        //private int ws_expected_ohip_reads = 0;
        private int ws_rec_nbr;
        private int ws_rec_rem;
        private string print_file_1_name = "ru041a";
        //private string print_file_1 = "AUDIT REPORT IS IN RU041A";
        private string print_file_2_name = "ru041b";
        //private string print_file_2 = "ERROR REPORT IS IN RU041B";

        private string subscripts_grp;
        private int ss;
        private int ss_rate_count;
        private int ss_bypass_count;


        private string ohip_fee_sched_subscripts_grp;
        private int ss_tape_gp = 1;
        private int ss_tape_asst = 2;
        private int ss_tape_spec = 3;
        private int ss_tape_anae = 4;
        private int ss_tape_non_anae = 5;


        private string feedback_oma_fee_mstr = string.Empty;
        private string feedback_iconst_mstr = string.Empty;
        //private string status_file = "0";
        private string status_audit_rpt = "0";
        private string status_cobol_oma_mstr = "0";
        private string status_cobol_ohip_file = "0";
        private string status_error_rpt = "0";
        private string status_cobol_iconst_mstr = "0";

        //private string sel_code_grp;
        private string sel_code_ltr = "";
        private string sel_code_nbr = "";

        private string ohip_flag;
        private string ohip_eof = "Y";
        private string ohip_not_eof = "N";

        private string oma_flag;
        private string oma_eof = "Y";
        private string oma_not_eof = "N";

        private string oma_code_type_check;
        private string skip_oma = "Y";
        private string dont_skip_oma = "N";

        //private string verify_flag;
        private string verify_ok = "Y";
        private string verify_not_ok = "N";

        //private string reverify_flag;
        private string reverify_ok = "Y";
        private string reverify_not_ok = "N";

        private string fees_valid_flag;
        private string fees_valid = "Y";
        private string fees_not_valid = "N";

        private string bypass_check;
        private string bypass = "Y";
        private string dont_bypass = "N";

        private string bypass_codes_table_grp;
        private string screen_bypass_codes_grp;
        //private string bypass_code_1 = " ";
        //private string bypass_code_2 = " ";
        //private string bypass_code_3 = " ";
        //private string bypass_code_4 = " ";
        //private string bypass_code_5 = " ";
        //private string bypass_code_6 = " ";
        //private string bypass_code_7 = " ";
        //private string bypass_code_8 = " ";
        //private string bypass_code_9 = " ";
        //private string bypass_code_10 = " ";
        private string screen_bypass_codes_r_grp;
        private string[] bypass_code = new string[11];

        private string ws_units_table_grp;
        private int ws_asst_units = 0;
        private decimal ws_asst_rem = 0;
        private int ws_anae_units = 0;
        private decimal ws_anae_rem = 0;
        private int ws_non_anae_units = 0;
        private decimal ws_non_anae_rem = 0;

        private string counters_grp;
        private int ctr_oma_reads;
        private int ctr_no_rma_code;
        //private int ctr_rates_implemented;
        //private int ctr_nbr_errors;
        private int ctr_zero_fees;
        private int ctr_no_ohip_rate;
        private int ctr_old_terminations;
        private int ctr_h1_page;
        private int ctr_h1_lines;
        private int ctr_h2_page;
        private int ctr_h2_lines;
        private int ctr_actual_ohip_reads;

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "invalid entry";
        //private string filler = "conmstr read error";
        //private string filler = "oma-fee-mstr read error";
        //private string filler = "oma-fee-mstr write error";
        // private string filler = "ohip-schedule read error";
        // private string filler = "valid code not on rma file";
        // private string filler = "effective dates disagree";
        // private string filler = "user specified bypass";
        // private string filler = "no ohip rate for code";
        // private string filler = "units not integer";
        // private string filler = "percentage add-on code";
        // private string filler = "diagnostic radiation code";
        // private string filler = "anae.,non-anae.units differ";
        // private string filler = "terminated code on rma file";
        // private string filler = "gen.& spec.fees differ";
        // private string filler = "fee too large for fee mstr";
        // private string filler = "too many decimal positions";
        // private string filler = "bad icc code on rma file";
        // private string filler = "a required fee is "0"";
        // private string filler = "new code - all fees "0"";
        private string error_messages_r_grp;
        private string[] err_msg =
              {"",
            "invalid entry",
            "conmstr read error",
            "oma-fee-mstr read error",
            "oma-fee-mstr write error",
            "ohip-schedule read error",
            "valid code not on rma file",
            "effective dates disagree",
            "user specified bypass",
            "no ohip rate for code",
            "units not integer",
            "percentage add-on code",
            "diagnostic radiation code",
            "anae.,non-anae.units differ",
            "terminated code on rma file",
            "gen.& spec.fees differ",
            "fee too large for fee mstr",
            "too many decimal positions",
            "bad icc code on rma file",
            "a required fee is zero",
            "new code - all fees zero"
        };
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  error - ";
        private string e1_error_msg;

        private string blank_line_grp;
        private string filler = "";

        // private string t1_total_line_grp;
        // private string filler = "";
        //private string filler = "new rates implemented";
        private int t1_rates_implemented;
        // private string filler = "";
        //private string filler = "nbr.of codes on error report";
        private int t1_nbr_errors;
        // private string filler = "";
        // private string filler = "printed-valid codes not on rma";
        private int t1_no_rma_code;

        // private string t2_total_line_grp;
        //private string filler = "";
        //private string filler = "printed-no ohip rate for code";
        private int t2_no_ohip_rate;
        //private string filler = "";
        //private string filler = "not printed-terminated before 19";
        private int t2_2_yrs_ago;
        private int t2_old_terminations;
        //private string filler = "";
        //private string filler = "not printed-all rates "0"";
        private int t2_zero_fees;

        // private string t3_total_line_grp;
        // private string filler = "";
        //private string filler = "nbr.of ohip codes expected:";
        private int t3_expected_ohip = 0;
        // private string filler = "";
        // private string filler = "nbr.of ohip codes read:";
        private int t3_actual_ohip = 0;
        // private string filler = space;
        // private string filler = "difference:";
        private int t3_difference = 0;

        // private string t4_total_line_grp;
        // private string filler = "";
        // private string filler = "bypassed codes were:";
        private string[] t4_code_section = new string[11];
        private string[] t4_code = new string[11];
        // private string[] filler =  new string[11];

        //private string h1_head_grp;
        //private string filler = "ru041a";
        //private string filler = "ohip rate changes - implemented";
        //private string filler = "run date";
        private string h1_run_date;
        //private string filler = "";
        //private string filler = "page";
        private int h1_page_nbr;

        // private string h1_title_1_grp;
        // private string filler = "from constants master:";
        // private string filler = "effective date";
        private int h1_const_yr = 0;
        // private string filler = "/";
        private int h1_const_mth = 0;
        // private string filler = "/";
        private int h1_const_day = 0;
        // private string filler = "";
        // private string filler = "asst. rate";
        private decimal h1_asst_rate = 0;
        // private string filler = "";
        // private string filler = "cert.anaesthetist";
        private decimal h1_cert_rate = 0;
        // private string filler = "";
        // private string filler = "reg.anaesthetist";
        private decimal h1_reg_rate = 0;

        // private string h1_title_2_grp;
        // private string filler = "";
        // private string filler = "code";
        // private string filler = "effective";
        // private string filler = "icc";
        // private string filler = "gen.p/technical";
        // private string filler = "special/profess";
        // private string filler = "assistant";
        // private string filler = "anaesthetist";

        // private string h1_title_3_grp;
        // private string filler = "";
        // private string filler = "date";
        // private string filler = "code";
        // private string filler = "curr";
        // private string filler = "tape";
        // private string filler = "curr";
        // private string filler = "tape";
        // private string filler = "curr";
        // private string filler = "tape";
        // private string filler = "curr";
        // private string filler = "tape";

        // private string h1_detail_line_grp;
        private string h1_rates_same = "****";
        private string h1_code_nbr;
        private int h1_effective_yr = 0;
        private string h1_slash1 = "/";
        private int h1_effective_mth = 0;
        private string h1_slash2 = "/";
        private int h1_effective_day = 0;
        private string h1_effective_date = "";
        // private string filler = "";
        private string h1_icc_code = "";
        // private string filler = "";
        private decimal[] h1_old_rate12 = new decimal[3];
        private decimal[] h1_new_rate12 = new decimal[3];
        private int[] h1_old_rate34 = new int[3];
        private int[] h1_new_rate34 = new int[3];
        private string h1_old_rate_1 = "";
        private string h1_new_rate_1 = "";
        private string h1_old_rate_2 = "";
        private string h1_new_rate_2 = "";
        private string h1_old_rate_3 = "";
        private string h1_new_rate_3 = "";
        private string h1_old_rate_4 = "";
        private string h1_new_rate_4 = "";

        // private string h2_head_grp;
        // private string filler = "ru041b";
        // private string filler = "ohip rate changes - not implemented";
        // private string filler = "run date";
        private string h2_run_date;
        // private string filler = "";
        // private string filler = "page";
        private int h2_page_nbr;

        /* private string h2_title_1_grp;
         private string filler = "code";
         private string filler = "icc";
         private string filler = "effective";
         private string filler = "reason";
         private string filler = "termination";
         private string filler = "g.p./";
         private string filler = "specialist/";
         private string filler = "assistant";
         private string filler = "cert.";
         private string filler = "reg."; */

        /* private string h2_title_2_grp;
         private string filler = "";
         private string filler = "code";
         private string filler = "date";
         private string filler = "date";
         private string filler = "technical";
         private string filler = "professional";
         private string filler = "anaesthetist";
         private string filler = "anaesthetist"; */

        // private string h2_detail_line_grp;
        private string h2_code;
        private string h2_icc_code = "";
        private int h2_effective_yr = 0;
        private string h2_slash1 = "/";
        private int h2_effective_mth = 0;
        private string h2_slash2 = "/";
        private int h2_effective_day = 0;
        private string h2_effective_date = "";
        // private string filler = "";
        private string h2_reason;
        private int h2_termination_yr = 0;
        private string h2_slash3 = "/";
        private int h2_termination_mth = 0;
        private string h2_slash4 = "/";
        private int h2_termination_day = 0;
        private string h2_termination_date = "";
        private string[] h2_rates = new string[6];
        private decimal[] h2_new_rate = new decimal[6];
        private string h2_new_rate_1 = "";
        private string h2_new_rate_2 = "";
        private string h2_new_rate_3 = "";
        private string h2_new_rate_4 = "";
        private string h2_new_rate_5 = "";
        private string[] h2_err_ind = new string[6];

        // private string h2_stars_grp;
        // private string filler = "*****************************************************";
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp;
        //private string sys_date_long;
       // private string sys_date_long_r_grp;
        private int sys_yy;
        private string sys_yy_alpha_grp;
        private int sys_y1;
        private int sys_y2;
        private int sys_y3;
        private int sys_y4;
        private int sys_mm;
        private int sys_dd;
        private int sys_date_numeric;

        private string sys_date_y2kfix_grp;
        private string sys_date_left;
        //private string filler;

        private string sys_date_y2kfixed_grp;
        private string sys_date_blank;
        private string sys_date_right;
        private string sys_date_temp;

        // private string run_date_grp;
        private int run_yy;
        // private string filler = "/";
        private int run_mm;
        // private string filler = "/";
        private int run_dd;

        // private string sys_time_grp;
        //private int sys_hrs;
        //private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        // private string run_time_grp;
        private int run_hrs;
        //private string filler = ":";
        private int run_min;
        // private string filler = ":";
        private int run_sec;

        private string endOfJob = "End of Job";
        private int ctr;

        private bool isRetrieving;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "u041",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 20,Data1 = "update oma fee master file from ohip tape",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9999/99/99",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 1,Data1 = "current date and ohip rates are:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 40,Data1 = "effective date",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 68,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_yy_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 72,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_mm_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "07",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_dd_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "08",Col = 40,Data1 = "assistants",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "08",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "09",Col = 40,Data1 = "cert.anaesthetists",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "09",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "10",Col = 40,Data1 = "reg. anaesthetists",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "10",Col = 68,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(4)9.99",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "12",Col = 1,Data1 = "number of records on ohip tape:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "rates-message.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_expected_ohip_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ohip-reads"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "18",Col = 30,Data1 = "program u041 in progress",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "19",Col = 30,Data1 = "currently at record",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "19",Col = 58,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ohip_code",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-rec-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "file status = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(02)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " error -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "enter-bypass-codes.",Line = "15",Col = 1,Data1 = "enter up to 10 codes for which the new ohip rates will be bypassed:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "enter-bypass-codes.",Line = "15",Col = 72,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sel_code",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-code"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "enter-bypass-codes.",Line = "16",Col = 1,Data1 = "(enter '*' to complete input)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 1,Data1 = "BYPASS CODES ARE:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 19,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 29,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 39,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 54,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 59,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "bypass-codes-display.",Line = "17",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "bypass_code_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "14",Col = 20,Data1 = "NEW OHIP RATES IMPLEMENTED = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "14",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rates_implemented",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "15",Col = 20,Data1 = "NEW OHIP RATES NOT IMPLEMENTED = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "15",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_nbr_errors",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "18",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "19",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM U041 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9999/99/99",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verify-display.",Line = "22",Col = 40,Data1 = "ACCEPT (Y/N) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verify-display.",Line = "22",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "verify_flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-verify"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "reverify-display.",Line = "23",Col = 40,Data1 = "CONTINUE PROCESSING (Y/N)  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "reverify-display.",Line = "23",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "reverify_flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reverify"}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_iconst_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private async Task err_iconst_mstr()
        {

            //     display blank-line-24.;
            //     stop "ERROR IN ACCESSING ICONST MASTER".;
            status_file = status_cobol_iconst_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_ohip_tape_file_section()
        {

            //     use after standard error procedure on ohip-benefit-sched-tape.;
        }

        private async Task err_ohip_benefit_sched_tape()
        {

            //     display blank-line-24.;
            //     stop "ERROR IN ACCESSING OHIP RATE TAPE FILE".;
            status_file = status_cobol_ohip_file;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_oma_fee_mstr_file_section()
        {

            //     use after standard error procedure on oma-fee-mstr.;
        }

        private async Task err_oma_fee_mstr()
        {

            //     display blank-line-24.;
            //     stop "ERROR IN ACCESSING OMA FEE MASTER".;
            status_file = status_cobol_oma_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {

        }

        private async Task initialize_objects()
        {
            objAudit_rec = null;
            objAudit_rec = new Audit_record();

            Audit_rec_Collection = null;
            Audit_rec_Collection = new ObservableCollection<Audit_record>();

            objError_rec = null;
            objError_rec = new Error_record();

            Error_rec_Collection = null;
            Error_rec_Collection = new ObservableCollection<Error_record>();

            objFee_mstr_rec = null;
            objFee_mstr_rec = new F040_OMA_FEE_MSTR();

            Fee_mstr_rec_Collection = null;
            Fee_mstr_rec_Collection = new ObservableCollection<F040_OMA_FEE_MSTR>();

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();

            objConstants_mstr_rec_2 = null;
            objConstants_mstr_rec_2 = new CONSTANTS_MSTR_REC_2();

            Constants_mstr_rec_2_Collection = null;
            Constants_mstr_rec_2_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_2>();

            objOhip_benefit_sched_rec = null;
            objOhip_benefit_sched_rec = new Ohip_Benefit_Sched_Rec();

            objAuditFile = null;
            objAuditFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_1_name);

            objErrorFile = null;
            objErrorFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_2_name);

            Ohip_benefit_sched_rec_Collection =  Read_Ohip_Benefit_Sched_Tape();
    }

        public async Task mainline()
        {
            Util.Trakker(++ctr, "mainline");

            try {
                await initialize_objects();

                //     perform aa0-initialization		thru aa0-99-exit.; //
                await aa0_initialization();
                await aa0_100_nbr_ohip_recs();
                await aa0_200_accept_display();
                await aa0_200_reverify_display();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit.;  //
                _ab0_processing:
                string retval = await ab0_processing();
                if (retval.Equals("ab0_99_exit"))
                {
                    goto _ab0_99_exit;
                }
                retval =  await ab0_100_next_code();
                if (retval.Equals("ab0_processing"))
                {
                    goto _ab0_processing;
                }
                _ab0_99_exit:
                await ab0_99_exit();

                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_99_exit();

                //     stop run.;
            }catch  (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            finally
            {
                if (objAuditFile != null)
                {
                    objAuditFile.Close();
                    objAuditFile = null;
                }
                if (objErrorFile != null )
                {
                    objErrorFile.Close();
                    objErrorFile = null;
                }
            }
        }

        private async Task aa0_initialization()
        {
            Util.Trakker(++ctr, "aa0_initialization");

            //     accept sys-date			from	date.;
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
            h1_run_date = await run_date_grp();
            h2_run_date = await run_date_grp();

            //     accept sys-time			from	time.;            
            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //counters = 0;
            ctr_oma_reads = 0;
            ctr_no_rma_code = 0;
            ctr_rates_implemented = 0;
            ctr_nbr_errors = 0;
            ctr_zero_fees = 0;
            ctr_no_ohip_rate = 0;
            ctr_old_terminations = 0;
            ctr_h1_page = 0;
            ctr_h1_lines = 0;
            ctr_h2_page = 0;
            ctr_h2_lines = 0;
            ctr_actual_ohip_reads = 0;


            // ws_units_table = 0;
            ws_asst_units = 0;
            ws_asst_rem = 0;
            ws_anae_units = 0;
            ws_anae_rem = 0;
            ws_non_anae_units = 0;
            ws_non_anae_rem = 0;

            ctr_h1_lines = 90;
            ctr_h2_lines = 90;
            
            t4_code_section[1] = "";
            t4_code_section[2] = "";
            t4_code_section[3] = "";
            t4_code_section[4] = "";
            t4_code_section[5] = "";
            t4_code_section[6] = "";
            t4_code_section[7] = "";
            t4_code_section[8] = "";
            t4_code_section[9] = "";
            t4_code_section[10] = "";            
           await h1_detail_line_grp(true);            
           await h2_detail_line_grp(true);

            //     subtract 2				from	sys-yy;
            // 					giving	ws-2-yrs-ago.;
            ws_2_yrs_ago = sys_yy - 2;

            //     open input	iconst-mstr.;

            // objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 2;
            //   read iconst-mstr;
            //    	invalid key;
            //        err_ind = 2;
            // 	      perform za0-common-error	thru	za0-99-exit;
            // 	      go to az0-end-of-job.;

            objConstants_mstr_rec_2 = new CONSTANTS_MSTR_REC_2
            {
                WhereConst_rec_nbr = 2
            }.Collection().FirstOrDefault();

            if (objConstants_mstr_rec_2 == null)
            {
                err_ind = 2;
                await za0_common_error();
                await za0_99_exit();

                await az0_end_of_job();
                return;
            }

            //     close iconst-mstr.;
            h1_const_yr = Util.NumInt(objConstants_mstr_rec_2.CONST_YY_CURR);
            h1_const_mth = Util.NumInt(objConstants_mstr_rec_2.CONST_MM_CURR);
            h1_const_day = Util.NumInt(objConstants_mstr_rec_2.CONST_DD_CURR);
            h1_asst_rate = Util.NumDec(objConstants_mstr_rec_2.CONST_ASST_H_CURR);
            h1_reg_rate = Util.NumDec(objConstants_mstr_rec_2.CONST_REG_H_CURR);
            h1_cert_rate = Util.NumDec(objConstants_mstr_rec_2.CONST_CERT_H_CURR);
            //     display scr-title.;
            Console.WriteLine("u041               " + "update oma fee master file from ohip tape     " + sys_date_long.ToString());
        }

        private async Task aa0_100_nbr_ohip_recs()
        {
            Util.Trakker(++ctr, "aa0_100_nbr_ohip_recs");

            //     display rates-message.;
            //     accept scr-ohip-reads.;
            Console.WriteLine("current date and ohip rates are:      " + "effective date             " +  Util.Str(objConstants_mstr_rec_2.CONST_YY_CURR) + "/" + Util.Str(objConstants_mstr_rec_2.CONST_MM_CURR).PadLeft(2,'0') + "/" + Util.Str(objConstants_mstr_rec_2.CONST_DD_CURR).PadLeft(2,'0'));
            Console.WriteLine("                                      " + "assistants                 " + Util.Str(objConstants_mstr_rec_2.CONST_ASST_H_CURR));
            Console.WriteLine("                                      " + "cert.anaesthetists         " + Util.Str(objConstants_mstr_rec_2.CONST_CERT_H_CURR));
            Console.WriteLine("                                      " + "reg. anaesthetists         " + Util.Str(objConstants_mstr_rec_2.CONST_REG_H_CURR));
            Console.WriteLine("");
            Console.WriteLine("number of records on ohip tape:       " + Util.Str(ws_expected_ohip_reads));

            ws_expected_ohip_reads = Util.NumInt(Console.ReadLine());


            // if ws-expected-ohip-reads not > 0 then            
            if (ws_expected_ohip_reads <= 0) {
                   ws_expected_ohip_reads = 0;
                // 	   go to aa0-100-nbr-ohip-recs.;
                await aa0_100_nbr_ohip_recs();
                return;
            }

            //  perform aa1-accept-bypass-codes	thru	aa1-99-exit;
            // 	    varying ss-bypass-count;
            // 	    from 1;
            // 	    by   1;
            // 	    until   ss-bypass-count > 10;
            // 		 or sel-code-ltr = "*".;

            ss_bypass_count = 1;
            do
            {
                await aa1_accept_bypass_codes();  //
                await aa1_100_edit_loop();
                await aa1_99_exit();
                ss_bypass_count++;
            } while (ss_bypass_count <= 10 && sel_code_ltr != "*");

            verify_flag = string.Empty;
            reverify_flag = string.Empty;
        }

        private async Task aa0_200_accept_display()
        {
            Util.Trakker(++ctr, "aa0_200_accept_display");

            //     display verify-display.;
            //     accept scr-verify.;
            Console.WriteLine("                                     " + "ACCEPT (Y/N) ");
            verify_flag = Console.ReadLine();

            //  if verify-ok or verify-not-ok then            
            if (Util.Str(verify_flag).Equals(verify_ok) || Util.Str(verify_flag).Equals(verify_not_ok)) {
                // 	    next sentence;
            }
            else {
                      err_ind = 1;
                // 	    perform za0-common-error thru   za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to aa0-200-accept-display.;
                await aa0_200_accept_display();
            }
        }

        private async Task aa0_200_reverify_display()
        {
            Util.Trakker(++ctr, "aa0_200_reverify_display");

            // if verify-not-ok then;            
            if (Util.Str(verify_flag).Equals(verify_not_ok)) {
                // 	   display reverify-display;
                Console.WriteLine("CONTINUE PROCESSING (Y/N)  ");
                //     accept scr-reverify;
                reverify_flag = Console.ReadLine();
                // 	   if reverify-not-ok then            
                if (Util.Str(reverify_flag).Equals(reverify_not_ok)) 
                {
                    // 	      stop run;            
                    throw new Exception(endOfJob);
                }
                // 	   else if reverify-ok then;            
                else if (Util.Str(reverify_flag).Equals(reverify_ok) ) {
                    // 		  next sentence;
                }
                else {
                    // 		  go to aa0-200-reverify-display.;
                    await aa0_200_reverify_display();
                }
            }


            objOhip_benefit_sched_rec.ohip_code_grp = "";
            //     display program-in-progress.;
            Console.WriteLine("                             " + "program u041 in progress");
            Console.WriteLine("                             " + "currently at record" + Util.Str(objOhip_benefit_sched_rec.ohip_code_grp));

            //     open input  ohip-benefit-sched-tape.;
            //     open i-o    oma-fee-mstr.;
            //     open output audit-file.;
            //     open output error-file.;

            Fee_mstr_rec_Collection = new F040_OMA_FEE_MSTR
            {

            }.Collection();

            ohip_flag = "N";
            oma_flag = "N";
            
            fees_valid_flag = "Y";

            //  perform fa0-read-ohip		thru	fa0-99-exit.;
            await fa0_read_ohip();
            await fa0_99_exit();

            //  perform ha0-read-oma		thru	ha0-99-exit.;
            await ha0_read_oma();
            await ha0_99_exit();
        }

        private async Task aa0_99_exit()
        {
            Util.Trakker(++ctr, "aa0_99_exit");

            //     exit.;
        }

        private async Task aa1_accept_bypass_codes()
        {
            Util.Trakker(++ctr, "aa1_accept_bypass_codes");
        }

        private async Task aa1_100_edit_loop()
        {           
            _aa1_100_edit_loop:

            Util.Trakker(++ctr, "aa1_100_edit_loop");

            err_ind = 0;
            sel_code = "";

            //     display enter-bypass-codes.;           
            //     accept scr-code.;
            Console.WriteLine("enter up to 10 codes for which the new ohip rates will be bypassed:");
            Console.WriteLine("(enter '*' to complete input)");
            sel_code = Console.ReadLine();

            sel_code_ltr = Util.Str(sel_code).PadRight(4).Substring(0, 1);
            sel_code_nbr = Util.Str(sel_code).PadRight(4).Substring(1, 3);

            // if sel-code-ltr = "*" then      
            if (Util.Str(sel_code_ltr).Equals("*")) {
                // 	  go to aa1-99-exit.;
                await aa1_99_exit();
                return; 
            }

            // if sel-code-ltr numeric  or sel-code-ltr = " "  then     
            if (Util.IsNumeric(sel_code_ltr) || string.IsNullOrWhiteSpace(sel_code_ltr)) {
                  err_ind = 1;
                // 	  perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to aa1-100-edit-loop;            
                goto _aa1_100_edit_loop;
                return;
            }
            // else if sel-code-nbr = " " or sel-code-nbr not numeric then            
            else if (string.IsNullOrWhiteSpace(sel_code_nbr) || !Util.IsNumeric(sel_code_nbr)) {
                    err_ind = 14;
                // 	  perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to aa1-100-edit-loop;
                goto _aa1_100_edit_loop;
                return;
            }
            else {
                // 	    next sentence.;
            }

            bypass_code[ss_bypass_count] = sel_code;

            bypass_code_1 = bypass_code[1];
            bypass_code_2 = bypass_code[2];
            bypass_code_3 = bypass_code[3];
            bypass_code_4 = bypass_code[4];
            bypass_code_5 = bypass_code[5];
            bypass_code_6 = bypass_code[6];
            bypass_code_7 = bypass_code[7];
            bypass_code_8 = bypass_code[8];
            bypass_code_9 = bypass_code[9];
            bypass_code_10 = bypass_code[10];

            //         display bypass-codes-display.;
            Console.WriteLine("BYPASS CODES ARE:" + bypass_code_1 + " " + bypass_code_2 + " " + bypass_code_3 + " " + bypass_code_4 + " " + bypass_code_5 + " " + bypass_code_6 + " " + bypass_code_7 + " " + bypass_code_8 + " " + bypass_code_9 + " " + bypass_code_10);
        }

        private async Task aa1_99_exit()
        {
            Util.Trakker(++ctr, "aa1_99_exit");
            //     exit.;
        }

        private async Task az0_end_of_job()
        {
            Util.Trakker(++ctr, "az0_end_of_job");

            //     display blank-screen.;
            //     perform az1-end-totals		thru	az1-99-exit.;
            await az1_end_totals();
            await az1_99_exit();

            //     perform zb0-dump-file-rec-cntrs	thru 	zb0-99-exit.;
            await zb0_dump_file_rec_cntrs();
            await zb0_99_exit();

            //     close oma-fee-mstr;
            // 	  error-file;
            // 	  ohip-benefit-sched-tape;
            // 	  audit-file.;
            //     stop run.;

            throw new Exception(endOfJob);
        }

        private async Task az0_99_exit()
        {
            Util.Trakker(++ctr, "az0_99_exit");
            //     exit.;
        }

        private async Task az1_end_totals()
        {
            Util.Trakker(++ctr, "az1_end_totals");

            //     add 4				to	ctr-h1-lines;
            // 						ctr-h2-lines.;
            ctr_h1_lines += 4;
            ctr_h2_lines += 4;

            //     perform ra0-check-audit-lines	thru	ra0-99-exit.;
            await ra0_check_audit_lines();
            await ra0_99_exit();

            //     perform da0-check-error-lines	thru	da0-99-exit.;
            await da0_check_error_lines();
            await da0_99_exit();

            t1_rates_implemented = ctr_rates_implemented;
            t1_no_rma_code = ctr_no_rma_code;
            t1_nbr_errors = ctr_nbr_errors;

            //     write audit-rec from t1-total-line	after	2 lines.;
            objAuditFile.print(true);
            objAuditFile.print(true);
            objAudit_rec.Audit_record1 = await t1_total_line_grp();
            objAuditFile.print(objAudit_rec.Audit_record1,1,true);
            objAuditFile.print(true);

            //     write error-rec from t1-total-line	after	2 lines.;
            objError_rec.Error_rec = await t1_total_line_grp();
            objErrorFile.print(objError_rec.Error_rec, 1, true);
            objErrorFile.print(true);

            await t1_total_line_grp(true);

            t2_no_ohip_rate = ctr_no_ohip_rate;
            t2_2_yrs_ago = ws_2_yrs_ago;
            t2_old_terminations = ctr_old_terminations;

            t2_zero_fees = ctr_zero_fees;

            //     write audit-rec from t2-total-line	after	2 lines.;
            objAudit_rec.Audit_record1 = await t2_total_line_grp();
            objAuditFile.print(true);
            objAuditFile.print(objAudit_rec.Audit_record1, 1, true);
            objAuditFile.print(true);

            //     write error-rec from t2-total-line	after	2 lines.;
            objError_rec.Error_rec = await t2_total_line_grp();
            objErrorFile.print(true);
            objErrorFile.print(objError_rec.Error_rec, 1, true);
            
            await t2_total_line_grp(true);

            t3_expected_ohip = ws_expected_ohip_reads;
            t3_actual_ohip = ctr_actual_ohip_reads;

            //     subtract ctr-actual-ohip-reads	from	ws-expected-ohip-reads.;
            ws_expected_ohip_reads = ws_expected_ohip_reads - ctr_actual_ohip_reads;

            t3_difference = ws_expected_ohip_reads;

            //     write audit-rec from t3-total-line	after 	3 lines.;
            objAudit_rec.Audit_record1 = await t3_total_line_grp();
            objAuditFile.print(true);
            objAuditFile.print(true);
            objAuditFile.print(objAudit_rec.Audit_record1, 1, true);

            //     write error-rec from t3-total-line  after   3 lines.;
            objErrorFile.print(true);
            objError_rec.Error_rec = await t3_total_line_grp();
            objErrorFile.print(true);
            objErrorFile.print(true);
            objErrorFile.print(objError_rec.Error_rec, 1, true);
            
            await t3_total_line_grp(true);

            //     perform az2-bypass-codes		thru	az2-99-exit;
            // 	    varying ss-bypass-count;
            // 	    	    from 1 by 1;
            // 	    until   ss-bypass-count > 10.;

            ss_bypass_count = 1;
            do
            {
                await az2_bypass_codes();
                await az2_99_exit();
                ss_bypass_count++;
            } while (ss_bypass_count <= 10);

            //     write audit-rec from t4-total-line  after 	2 lines.;
            objAuditFile.print(true);
            objAudit_rec.Audit_record1 = await t4_total_line_grp();
            objAuditFile.print(true);
            objAuditFile.print(objAudit_rec.Audit_record1, 1, true);

            //     write error-rec from t4-total-line	after 	2 lines.;
            objErrorFile.print(true);
            objError_rec.Error_rec = await t4_total_line_grp();
            objErrorFile.print(true);
            objErrorFile.print(objError_rec.Error_rec, 1, true);
           
            await t4_total_line_grp(true);
        }

        private async Task az1_99_exit()
        {
            Util.Trakker(++ctr, "az1_99_exit");

            //     exit.;
        }

        private async Task az2_bypass_codes()
        {
            Util.Trakker(++ctr, "az2_bypass_codes");

            t4_code[ss_bypass_count] = bypass_code[ss_bypass_count];
            t4_code_section[ss_bypass_count] = bypass_code[ss_bypass_count];
        }

        private async Task az2_99_exit()
        {
            Util.Trakker(++ctr, "az2_99_exit");

            //     exit.;
        }

        private async Task<string> ab0_processing()
        {
            _ab0_processing:

            Util.Trakker(++ctr, "ab0_processing");

            if (objFee_mstr_rec.FEE_OMA_CD_LTR1 == "C" && objFee_mstr_rec.FILLER_NUMERIC == "108")
            {
                int zz = 1;
            }

            // if ohip-eof then            
            if (Util.Str(ohip_flag).Equals(ohip_eof)) {
                // 	  if oma-eof then     
                if (Util.Str(oma_flag).Equals(oma_eof)) {
                    // 	      go to ab0-99-exit;
                    return "ab0_99_exit";
                }
                else {
                    // 	      perform ab1-no-ohip-rate	thru	ab1-99-exit;
                    await ab1_no_ohip_rate();
                    await ab1_99_exit();
                    // 	      perform ha0-read-oma	thru	ha0-99-exit;
                    await ha0_read_oma();
                    await ha0_99_exit();
                    err_ind = 0;
                    // 	      go to ab0-processing;
                    goto _ab0_processing;
                    return string.Empty;
                }
            }
            // else if oma-eof then            
            else if (Util.Str(oma_flag).Equals(oma_eof) ) {
                // 	    perform ab2-new-code	thru	ab2-99-exit;
                await ab2_new_code();
                await ab2_99_exit();
                // 	    perform fa0-read-ohip	thru	fa0-99-exit;
                await fa0_read_ohip();
                await fa0_99_exit();
                err_ind = 0;
                // 	    go to ab0-processing;
                goto _ab0_processing;
                return string.Empty;
            }
            else {
                // 	    next sentence.;
            }


            // if ohip-code = fee-oma-cd then     
            if (Util.Str(objOhip_benefit_sched_rec.ohip_code_grp) == Util.Str(objFee_mstr_rec.FEE_OMA_CD_LTR1) + Util.Str(objFee_mstr_rec.FILLER_NUMERIC)) {
                // 	   next sentence;            
            }
            // else if ohip-code > fee-oma-cd then            
            else if (Util.Str(objOhip_benefit_sched_rec.ohip_code_grp).CompareTo(Util.Str(objFee_mstr_rec.FEE_OMA_CD_LTR1) + Util.Str(objFee_mstr_rec.FILLER_NUMERIC)) > 0) {
                // 	    perform ab1-no-ohip-rate	thru	ab1-99-exit;
                await ab1_no_ohip_rate();
                await ab1_99_exit();
                // 	    perform ha0-read-oma	thru	ha0-99-exit;
                await ha0_read_oma();
                await ha0_99_exit();
                // 	    go to ab0-processing;
                goto _ab0_processing;
                return string.Empty;
            }
            else {
                //      perform ab2-new-code	thru	ab2-99-exit;
                await ab2_new_code();
                await ab2_99_exit();
                // 	    perform fa0-read-ohip	thru	fa0-99-exit;
                await fa0_read_ohip();
                await fa0_99_exit();
                // 	    go to ab0-processing.;
                goto _ab0_processing;
                return string.Empty;
            }

            oma_code_type_check = "N";
            //     perform va0-skip-rec-types		thru	va0-99-exit.;
            await va0_skip_rec_types();
            await va0_99_exit();

            // if skip-oma then            
            if (Util.Str(oma_code_type_check).Equals(skip_oma)) {
                // 	  perform pa0-print-error		thru	pa0-99-exit;
                await pa0_print_error();
                await pa0_100_print_line();
                await pa0_99_exit();
                // 	  go to ab0-100-next-code.;
                return "ab0_100_next_code";
            }

            bypass_check = "N";
            //  perform ta0-check-for-bypass	thru	ta0-99-exit;
            // 	varying	ss-bypass-count;
            // 		from 1	by 1;
            // 	until	ss-bypass-count > 10;
            // 	    or	bypass.;

            ss_bypass_count = 1;
            do
            {
               await ta0_check_for_bypass();
                await ta0_99_exit();
                ss_bypass_count++;
            } while (ss_bypass_count <= 10 && !bypass_check.Equals(bypass));

            // if bypass  then            
            if (Util.Str(bypass_check).Equals(bypass) ) {
                    err_ind = 8;
                // 	perform pa0-print-error		thru	pa0-99-exit;
               await pa0_print_error();
               await pa0_100_print_line();
               await pa0_99_exit();
                // 	  go to ab0-100-next-code.;
                return "ab0_100_next_code";
            }

            // if ohip-termination-date < sys-date-long-r then   
            if (Util.Str(objOhip_benefit_sched_rec.ohip_termination_date_grp).CompareTo(await sys_date_long_r_grp()) < 0 ) {
                // 	  if ohip-termination-yr < ws-2-yrs-ago then            
                if (objOhip_benefit_sched_rec.ohip_termination_yr < ws_2_yrs_ago ) {
                    // 	     add 1			to	ctr-old-terminations;
                    ctr_old_terminations++;
                    // 	     go to ab0-100-next-code;
                    return "ab0_100_next_code";
                }
                else {
                          err_ind = 14;
                    // 	  perform pa0-print-error	thru	pa0-99-exit;
                    await pa0_print_error();
                    await pa0_100_print_line();
                    await pa0_99_exit();

                    //  go to ab0-100-next-code;
                    return "ab0_100_next_code";
                }
            }
            else {
                //   	next sentence.;
            }


            //  if     ohip-fees (ss-tape-gp)       = zero;
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] == 0
            //        and ohip-fees (ss-tape-asst)     = zero;
               && objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] == 0
            //        and ohip-fees (ss-tape-spec)     = zero;
               && objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0
            //        and ohip-fees (ss-tape-anae)     = zero;
               && objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == 0
            //        and ohip-fees (ss-tape-non-anae) = zero then;
               && objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] == 0
            )
            {
                //     	 add 1				to	ctr-zero-fees;
                ctr_zero_fees++;
                // 	     go to ab0-100-next-code.;
                return "ab0_100_next_ code";
            }

            objFee_mstr_rec.FEE_DATE_YY = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_date_grp.PadRight(8, '0').Substring(0, 4));
            objFee_mstr_rec.FEE_DATE_MM = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_date_grp.PadRight(8, '0').Substring(4, 2));
            objFee_mstr_rec.FEE_DATE_DD = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_date_grp.PadRight(8, '0').Substring(6, 2));

            //  if fee-icc-sec =    "CP";
            if (objFee_mstr_rec.FEE_ICC_SEC == "CP"
            // 		     or "CV";
               || objFee_mstr_rec.FEE_ICC_SEC == "CV"
            // 		     or "DT";
               || objFee_mstr_rec.FEE_ICC_SEC == "DT"
            // 		     or "DU";
               || objFee_mstr_rec.FEE_ICC_SEC == "DU"
            // 		     or "NM";
               || objFee_mstr_rec.FEE_ICC_SEC == "NM"
            // 		     or "PF";
                || objFee_mstr_rec.FEE_ICC_SEC == "PF"
            // 		     or "SP";
                || objFee_mstr_rec.FEE_ICC_SEC == "SP"
            // 		     or "DR" then;
                || objFee_mstr_rec.FEE_ICC_SEC == "DR"
            )
            {                
                //         next sentence;
            }
            else {
                     err_ind = 18;
                // 	    perform pa0-print-error		thru	pa0-99-exit;
                await pa0_print_error();
                await pa0_100_print_line();
                await pa0_99_exit();
                //      go to ab0-100-next-code.;
                return "ab0_100_next_code";
            }

            //  if fee-icc-sec = "CP" then;   
            if (Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("CP")) {
                // 	    perform ja0-validate-cp		thru	ja0-99-exit;            
                await ja0_validate_cp();
                await ja0_99_exit();
            }
            // 	elseif fee-icc-sec = "CV" then;            
            else if (Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("CV")) {
                // 	    perform jb0-validate-cv	thru	jb0-99-exit;    
                await jb0_validate_cv();
                await jb0_99_exit();
            }
            //  else if fee-icc-sec = "DT"  then            
            else if (Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("DT")) {
                // 		perform jc0-validate-dt thru	jc0-99-exit;            
                await jc0_validate_dt();
                await jc0_99_exit();
            }
            //  else if fee-icc-sec =  "DR" then            
            else if (Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("DR")) {
                // 		    perform jd0-validate-dr   thru jd0-99-exit;            
                await jd0_validate_dr();
                await jd0_99_exit();
            }
            //  else if fee-icc-sec =   "DU" or "NM" or "PF" then            
            else if (Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("DU") || Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("NM") || Util.Str(objFee_mstr_rec.FEE_ICC_SEC).ToUpper().Equals("PF")) {
                // 			perform je0-validate-du-nm-pf thru je0-99-exit;
                await je0_validate_du_nm_pf();
                await je0_99_exit();
            }
            else {
                // 	 	perform jf0-validate-sp thru jf0-99-exit.;
                await jf0_validate_sp();
                await jf0_99_exit();
            }

            //  if fees-not-valid then   
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid)) {
                // 	    perform pa0-print-error		thru	pa0-99-exit;
                await pa0_print_error();
                await pa0_100_print_line();
                await pa0_99_exit();
                // 	    go to ab0-100-next-code.;
                return "ab0_100_next_code";
            }

            //     perform ba0-print-audit           	thru	ba0-99-exit.;
            await ba0_print_audit();
            await ba0_99_exit();
            //     perform na0-rewrite-record		thru	na0-99-exit.;
            await na0_rewrite_record();
            await na0_99_exit();

            return string.Empty;
        }

        private async Task<string> ab0_100_next_code()
        {
            Util.Trakker(++ctr, "ab0_100_next_code");

            fees_valid_flag = "Y";
            //     perform fa0-read-ohip		thru	fa0-99-exit.;
            await fa0_read_ohip();
            await fa0_99_exit();
            //     perform ha0-read-oma		thru	ha0-99-exit.;
            await ha0_read_oma();
            await ha0_99_exit();

            //     go to ab0-processing.;
            return "ab0_processing";
        }

        private async Task ab0_99_exit()
        {
            Util.Trakker(++ctr, "ab0_99_exit");

            //     exit.;
        }

        private async Task ab1_no_ohip_rate()
        {
            Util.Trakker(++ctr, "ab1_no_ohip_rate");

            //     add 1				to	ctr-no-ohip-rate.;
            ctr_no_ohip_rate++;
            err_ind = 9;
            //     perform pa0-print-error		thru	pa0-99-exit.;
            await pa0_print_error();
            await pa0_100_print_line();
            await pa0_99_exit();
        }

        private async Task ab1_99_exit()
        {
            Util.Trakker(++ctr, "ab1_99_exit");

            //     exit.;
        }

        private async Task ab2_new_code()
        {
            Util.Trakker(++ctr, "ab2_new_code");

            // if ohip-termination-date < sys-date-long-r then            
            if (Util.Str(objOhip_benefit_sched_rec.ohip_termination_date_grp).CompareTo(await sys_date_long_r_grp()) < 0 ) {
                // 	   add 1				to	ctr-old-terminations;            
                ctr_old_terminations++;
            }
            // else if     ohip-fees (ss-tape-gp)       = zero;
            else if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] == 0
            // 	   and ohip-fees (ss-tape-asst)     = zero;
            &&  objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] == 0
            // 	   and ohip-fees (ss-tape-spec)     = zero;
            && objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0
            // 	   and ohip-fees (ss-tape-anae)     = zero;
            && objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == 0
            // 	   and ohip-fees (ss-tape-non-anae) = zero then;            
            && objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] == 0
            )
            {
                // 	    add 1			to	ctr-zero-fees;
                ctr_zero_fees++;
                err_ind = 20;
                // 	    perform pa0-print-error	thru	pa0-99-exit;
                await pa0_print_error();
                await pa0_100_print_line();
                await pa0_99_exit();
            }
            else {
                // 	    add 1			to	ctr-no-rma-code;
                ctr_no_rma_code++;
                err_ind = 6;
                // 	    perform pa0-print-error	thru	pa0-99-exit.;
                await pa0_print_error();
                await pa0_100_print_line();
                await pa0_99_exit();
            }
        }

        private async Task ab2_99_exit()
        {
            Util.Trakker(++ctr, "ab2_99_exit");

            //     exit.;
        }

        private async Task ba0_print_audit()
        {
            Util.Trakker(++ctr, "ba0_print_audit");

            //     perform ra0-check-audit-lines	thru	ra0-99-exit.;
            await ra0_check_audit_lines();
            await ra0_99_exit();

            h1_code_nbr = Util.Str(objOhip_benefit_sched_rec.ohip_code_grp);
            h1_icc_code = Util.Str(objFee_mstr_rec.FEE_ICC_SEC);
            h1_effective_yr = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_yr);
            h1_effective_mth = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_mth);
            h1_effective_day = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_day);

            h1_slash1 = "/";
            h1_slash2 = "/";

            if (h1_effective_yr == 0)
            {
                h1_effective_date = string.Empty;
            }
            else
            {
                h1_effective_date = Util.Str(h1_effective_yr) + h1_slash1 + Util.Str(h1_effective_mth).PadLeft(2, '0') + h1_slash2 + Util.Str(h1_effective_day).PadLeft(2, '0');
            }

            //  if  fee-curr-h-fee-1 = fee-prev-h-fee-1;
            if (Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1) == Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_1)
            // 	    and fee-curr-h-asst  = fee-prev-h-asst;
                && Util.NumDec(objFee_mstr_rec.FEE_CURR_H_ASST) == Util.NumDec(objFee_mstr_rec.FEE_PREV_H_ASST)
            // 	    and fee-curr-h-fee-2 = fee-prev-h-fee-2;
                && Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2) == Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_2)
            // 	    and fee-curr-h-anae  = fee-prev-h-anae then            
                && Util.NumDec(objFee_mstr_rec.FEE_CURR_H_ANAE) == Util.NumDec(objFee_mstr_rec.FEE_PREV_H_ANAE)
            )
            {
                  h1_rates_same = "****";
            }

            //  write audit-rec from h1-detail-line	after	2 lines.;
            objAudit_rec.Audit_record1 = await h1_detail_line_grp();
            objAuditFile.print(true);
            objAuditFile.print(true);
            objAuditFile.print(objAudit_rec.Audit_record1, 1, true);

            //  h1_detail_line = "";
            await h1_detail_line_grp(true);

            //  add 1				to	ctr-rates-implemented.;
            ctr_rates_implemented++;
        }

        private async Task ba0_99_exit()
        {
            Util.Trakker(++ctr, "ba0_99_exit");
            //     exit.;
        }

        private async Task da0_check_error_lines()
        {
            Util.Trakker(++ctr, "da0_check_error_lines");

            //     add 1					to	ctr-h2-lines.;
            ctr_h2_lines++;

            // if ctr-h2-lines > 27 then            
            if (ctr_h2_lines > 27) {
                // 	   add 1					to	ctr-h2-page;
                ctr_h2_page++;
                h2_page_nbr = ctr_h2_page;
                ctr_h2_lines = 0;
                // 	   write error-rec from h2-head		after	page;
                objError_rec.Error_rec = await h2_head_grp();
                objErrorFile.PageBreak();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
                objErrorFile.print(true);

                // 	   write error-rec from h1-title-1		after	1 line;
                objError_rec.Error_rec = await h1_title_1_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
                objErrorFile.print(true);
                objErrorFile.print(true);

                // 	   write error-rec from h2-title-1		after	2 lines;
                objError_rec.Error_rec = await h2_title_1_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
                objErrorFile.print(string.Empty, 1, true);

                // 	   write error-rec from h2-title-2		after	1 line.;
                objError_rec.Error_rec = await h2_title_2_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
            }
        }

        private async Task da0_99_exit()
        {
            Util.Trakker(++ctr, "da0_99_exit");

            //     exit.;
        }

        private async Task fa0_read_ohip()
        {
            Util.Trakker(++ctr, "fa0_read_ohip");

            //ws_units_table = 0;
            ws_asst_units = 0;
            ws_asst_rem = 0;
            ws_anae_units = 0;
            ws_anae_rem = 0;
            ws_non_anae_units = 0;
            ws_non_anae_rem = 0;

            // read ohip-benefit-sched-tape next;
            // 	   at end;
            //       ohip_flag = "Y";
            // 	    go to fa0-99-exit.;

            if (ctr_actual_ohip_reads >= Ohip_benefit_sched_rec_Collection.Count())
            {
                 ohip_flag = "Y";
                // 	    go to fa0-99-exit.;
                await fa0_99_exit();
                return; 
            }

            objOhip_benefit_sched_rec = Ohip_benefit_sched_rec_Collection[ctr_actual_ohip_reads];

            //     add 1				to	ctr-actual-ohip-reads.;
            ctr_actual_ohip_reads++;

            // if ohip-fees (ss-tape-gp)   not = zero  and ohip-fees (ss-tape-spec)  = zero  then       
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] != 0 && objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0 ) {
                //    move ohip-fees (ss-tape-gp)             to      ohip-fees (ss-tape-spec)     
                objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp];
                //     divide	ctr-actual-ohip-reads	by	100;
                // 					giving	ws-rec-nbr;
                ws_rec_nbr = ctr_actual_ohip_reads / 100;
                // 					remainder ws-rec-rem.;
                ws_rec_rem = ctr_actual_ohip_reads % 100;
            }

            //  if ws-rec-rem = zero then            
            if (ws_rec_rem == 0 ) {
                // 	   display scr-rec-nbr.;
                Console.WriteLine(objOhip_benefit_sched_rec.ohip_code_grp);
            }
        }

        private async Task fa0_99_exit()
        {
            Util.Trakker(++ctr, "fa0_99_exit");
            //     exit.;
        }

        private async Task ha0_read_oma()
        {
            Util.Trakker(++ctr, "ha0_read_oma");

            //  read oma-fee-mstr next;
            //    	at end;
            //         oma_flag = "Y";
            // 	       go to ha0-99-exit.;

            if (ctr_oma_reads >= Fee_mstr_rec_Collection.Count())
            {
                 oma_flag = "Y";
                // 	       go to ha0-99-exit.;
                await ha0_99_exit();
                return;
            }
            objFee_mstr_rec = Fee_mstr_rec_Collection[ctr_oma_reads];

            //     add 1				to	ctr-oma-reads.;
            ctr_oma_reads++;
        }

        private async Task ha0_99_exit()
        {
            Util.Trakker(++ctr, "ha0_99_exit");

            //     exit.;
        }

        private async Task ja0_validate_cp()
        {
            Util.Trakker(++ctr, "ja0_validate_cp");

            // perform wb0-check-gp-spec		thru	wb0-99-exit.;
            await wb0_check_gp_spec();
            await wb0_99_exit();

            // if fees-not-valid then     
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid)) {
                // 	   go to ja0-99-exit.;
                await ja0_99_exit();
                return;
            }

            // perform wc0-check-anae		thru	wc0-99-exit.;
            await wc0_check_anae();
            await wc0_99_exit();

            // if fees-not-valid then   
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid)) {
                // 	  go to ja0-99-exit.;
                await ja0_99_exit();
                return;
            }

            ss_rate_count = ss_tape_spec;
            // perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            // if fees-not-valid then    
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	  go to ja0-99-exit.;
                await ja0_99_exit();
                return;
            }

            // if ohip-fees (ss-tape-spec) = zero then;      
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0 ) {
                   err_ind = 19;
                   fees_valid_flag = "N";
                // 	  go to ja0-99-exit.;
                await ja0_99_exit();
                return; 
            }

            //fee_curr_h_fee_2 = 0;
            FEE_CURRENT_PREVIOUS_YEARS_Fee_2_SET(objFee_mstr_rec,1,2,0);

            //objFee_mstr_rec.fee_curr_h_asst = 0;
            base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_SET(objFee_mstr_rec, 1, 2, 0);

            h1_old_rate12[1] = FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, 1, 2);    //fee_curr_h_fee_1;
            h1_new_rate12[1] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec];

            //fee_curr_h_fee_1 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec];
            FEE_CURRENT_PREVIOUS_YEARS_Fee_1_SET(objFee_mstr_rec, 1, 2, objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec]/10);

            // if ws-anae-units not = zero then;    
            if (ws_anae_units != 0 ) {
                h1_old_rate34[2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);
                h1_new_rate34[2] = ws_anae_units;
                objFee_mstr_rec.FEE_CURR_H_ANAE = ws_anae_units;   
            }
            // else if fee-curr-h-anae = zero then            
            else if (Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE) == 0 ) {
                // 	    next sentence;
            }
            else {
                h1_old_rate34[2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE); // fee_curr_h_anae;
                h1_new_rate34[2] = 0;
                objFee_mstr_rec.FEE_CURR_H_ANAE = 0;  // 	   fee-curr-h-anae.;
            }
        }

        private async Task ja0_99_exit()
        {
            Util.Trakker(++ctr, "ja0_99_exit");

            //     exit.;
        }

        private async Task jb0_validate_cv()
        {
            Util.Trakker(++ctr, "jb0_validate_cv");

            //  perform wb0-check-gp-spec		thru	wb0-99-exit.;
            await wb0_check_gp_spec();
            await wb0_99_exit();

            //  if fees-not-valid then;       
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	    go to jb0-99-exit.;
                await jb0_99_exit();
                return;
            }

            ss_rate_count = ss_tape_spec;
            //  perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            // if fees-not-valid then;            
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	  go to jb0-99-exit.;
                await jb0_99_exit();
                return;
            }

            // if ohip-fees (ss-tape-spec) = zero then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0 ) {
                err_ind = 19;
                fees_valid_flag = "N";
                // 	go to jb0-99-exit.;
                await jb0_99_exit();
                return; 
            }

            //fee_curr_h_fee_2 = 0;            
            objFee_mstr_rec.FEE_CURR_H_FEE_2 = 0;
            objFee_mstr_rec.FEE_CURR_H_ASST = 0;
            objFee_mstr_rec.FEE_CURR_H_ANAE = 0;

            h1_old_rate12[2] = FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, 1, 2);    //fee_curr_h_fee_1;

            h1_new_rate12[2] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec];            
           objFee_mstr_rec.FEE_CURR_H_FEE_1 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec]/10;
        }

        private async Task jb0_99_exit()
        {
            Util.Trakker(++ctr, "jb0_99_exit");

            //     exit.;
        }

        private async Task jc0_validate_dt()
        {
            Util.Trakker(++ctr, "jc0_validate_dt");

            // perform wb0-check-gp-spec		thru	wb0-99-exit.;
            await wb0_check_gp_spec();
            await wb0_99_exit();

            // if fees-not-valid then
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid)) {
                // 	   go to jc0-99-exit.;
                await jc0_99_exit();
                return; 
            }

            // perform wc0-check-anae		thru	wc0-99-exit.;
            await wc0_check_anae();
            await wc0_99_exit();

            // if fees-not-valid then;            
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	  go to jc0-99-exit.;
                await jc0_99_exit();
                return; 
            }

            ss_rate_count = ss_tape_spec;
            // perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            // if fees-not-valid then
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid)) {
                // 	   go to jc0-99-exit.;
                await jc0_99_exit();
                return; 
            }

            // if ohip-fees (ss-tape-spec) = zero then;        
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0 ) {
                err_ind = 19;
                fees_valid_flag = "N";
                // 	go to jc0-99-exit.;
                await jc0_99_exit();
                return; 
            }

            objFee_mstr_rec.FEE_CURR_H_ASST = 0;

            h1_old_rate12[2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1)/10; //  fee_curr_h_fee_1;
            h1_new_rate12[2] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec];
            objFee_mstr_rec.FEE_CURR_H_FEE_1 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec]/10;

            // if ws-anae-units not = zero then;       
            if (ws_anae_units != 0) {
                h1_old_rate34[2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);  
                h1_new_rate34[2] = ws_anae_units;
                objFee_mstr_rec.FEE_CURR_H_ANAE =  ws_anae_units;
            }
            // else if fee-curr-h-anae = zero then;            
            else if (Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE) == 0 ) {
                // 	    next sentence;
            }
            else {
                h1_old_rate34[2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE); 
                h1_new_rate34[2] = 0;
                objFee_mstr_rec.FEE_CURR_H_ANAE = 0;
            }
        }

        private async Task jc0_99_exit()
        {
            Util.Trakker(++ctr, "jc0_99_exit");

            //     exit.;
        }

        private async Task jd0_validate_dr()
        {
            Util.Trakker(++ctr, "jd0_validate_dr");

            ss_rate_count = ss_tape_asst;
            // perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            // if fees-not-valid then            
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	   go to jd0-99-exit.;
                await jd0_99_exit();
                return; 
            }

            ss_rate_count = ss_tape_anae;

            // if ohip-fees (ss-tape-anae) not = zero  then         
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] != 0 ) {
                // 	   next sentence;            
            }
            // else if ohip-fees (ss-tape-non-anae) not = zero then;            
            else if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] != 0 ) {
                   objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae];
            }

            // perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            // if fees-not-valid then;            
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	   go to jd0-99-exit.;
                await jd0_99_exit();
                return; 
            }

            // if  ohip-fees (ss-tape-asst) = zero  or  ohip-fees (ss-tape-anae) = zero then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] == 0  || objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == 0) {
                     err_ind = 19;
                     fees_valid_flag = "N";
                //    go to jd0-99-exit.;
                await jd0_99_exit();
                return; 
            }

            objFee_mstr_rec.FEE_CURR_H_ASST = 0;
            objFee_mstr_rec.FEE_CURR_H_ANAE = 0;

            h1_old_rate12[1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1)/10;   //fee_curr_h_fee_1;
            h1_new_rate12[1] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst];
            objFee_mstr_rec.FEE_CURR_H_FEE_1 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst]/10;

            h1_old_rate12[2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2)/10;   //fee_curr_h_fee_2;

            h1_new_rate12[2] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae];
            objFee_mstr_rec.FEE_CURR_H_FEE_2 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae]/10;
        }

        private async Task jd0_99_exit()
        {
            Util.Trakker(++ctr, "jd0_99_exit");

            //     exit.;
        }

        private async Task je0_validate_du_nm_pf()
        {
            Util.Trakker(++ctr, "je0_validate_du_nm_pf");

            ss_rate_count = ss_tape_asst;
            //  perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            //  if fees-not-valid then;    
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	    go to je0-99-exit.;
                await je0_99_exit();
                return; 
            }

            ss_rate_count = ss_tape_anae;
            // perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            // if fees-not-valid then;     
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	   go to je0-99-exit.;
                await je0_99_exit();
                return; 
            }

            // if ohip-fees (ss-tape-asst) = zero or ohip-fees (ss-tape-anae) = zero then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] == 0 || objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == 0 ) {
                    err_ind = 19;
                    fees_valid_flag = "N";
                // 	   go to je0-99-exit.;
                await je0_99_exit();
                return; 
            }

            objFee_mstr_rec.FEE_CURR_H_ASST = 0;
            objFee_mstr_rec.FEE_CURR_H_ANAE = 0;

            h1_old_rate12[1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1)/10;  //fee_curr_h_fee_1;
            h1_new_rate12[1] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst];
            objFee_mstr_rec.FEE_CURR_H_FEE_1 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst]/10;   //fee-curr-h-fee-1

            h1_old_rate12[2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2)/10;  //fee_curr_h_fee_2;

            h1_new_rate12[2] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae];
            objFee_mstr_rec.FEE_CURR_H_FEE_2 = objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae]/10;  
        }

        private async Task je0_99_exit()
        {
            Util.Trakker(++ctr, "je0_99_exit");

            //     exit.;
        }

        private async Task jf0_validate_sp()
        {
            Util.Trakker(++ctr, "jf0_validate_sp");

            // perform wb0-check-gp-spec		thru	wb0-99-exit.;
            await wb0_check_gp_spec();
            await wb0_99_exit();

            // if fees-not-valid then;     
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                //   	go to jf0-99-exit.;
                await jf0_99_exit();
                return; 
            }

            ss_rate_count = ss_tape_spec;
            //  perform wa0-check-range		thru	wa0-99-exit.;
            await wa0_check_range();
            await wa0_99_exit();

            //  if fees-not-valid then   
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	   go to jf0-99-exit.;
                await jf0_99_exit();
                return; 
            }

            //  perform wd0-check-asst		thru	wd0-99-exit.;
            await wd0_check_asst();
            await wd0_99_exit();

            // if fees-not-valid then            
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	  go to jf0-99-exit.;
                await jf0_99_exit();
                return; 
            }

            //  perform wc0-check-anae		thru	wc0-99-exit.;
            await wc0_check_anae();
            await wc0_99_exit();

            //  if fees-not-valid then   
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	    go to jf0-99-exit.;
                await jf0_99_exit();
                return; 
            }

            // if  ws-asst-units = zero;
            if (ws_asst_units == 0
            //     and ws-anae-units            = zero;
              && ws_anae_units == 0
            //     and ohip-fees (ss-tape-spec) = zero then;            
               && objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0
            )
            {
                     err_ind = 19;
                     fees_valid_flag = "N";
                // 	go to jf0-99-exit.;
                await jf0_99_exit();
                return;
            }
            
            objFee_mstr_rec.FEE_CURR_H_FEE_2 = 0;

            h1_old_rate34[1] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ASST);
            h1_new_rate34[1] = ws_asst_units;
            objFee_mstr_rec.FEE_CURR_H_ASST  = ws_asst_units;

            // if ohip-fees (ss-tape-spec) not = zero then;       
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] != 0 ) {
                h1_old_rate12[2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1)/10;  //fee_curr_h_fee_1;
                h1_new_rate12[2] = Util.NumDec(objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec]);  
                objFee_mstr_rec.FEE_CURR_H_FEE_1  = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec]/10;  
            }
            // else if fee-curr-h-fee-1 = zero then
            else if (Util.NumInt(objFee_mstr_rec.FEE_CURR_H_FEE_1) == 0 ) {
                // 	    next sentence;
            }
            else {
                h1_old_rate12[2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1)/10;   //fee_curr_h_fee_1;
                h1_new_rate12[2] = 0;
                objFee_mstr_rec.FEE_CURR_H_FEE_1 = 0; 
            }

            // if ws-anae-units not = zero  then;       
            if (ws_anae_units != 0) {
                h1_old_rate34[2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);    //   fee_curr_h_anae;
                h1_new_rate34[2] = ws_anae_units;
                objFee_mstr_rec.FEE_CURR_H_ANAE = ws_anae_units;	
            }
            // else if fee-curr-h-anae = zero 	then;
            else if (Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE) == 0 ) {
                // 	    next sentence;
            }
            else {
                h1_old_rate34[2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);   //   fee_curr_h_anae;
                h1_new_rate34[2] = 0;
                objFee_mstr_rec.FEE_CURR_H_ANAE = 0;   
            }
        }

        private async Task jf0_99_exit()
        {
            Util.Trakker(++ctr, "jf0_99_exit");

            //     exit.;
        }

        private async Task na0_rewrite_record()
        {
            Util.Trakker(++ctr, "na0_rewrite_record");

            //      compute fee-curr-a-fee-1 = fee-curr-h-fee-1 * 2.13.;
            objFee_mstr_rec.FEE_CURR_A_FEE_1 = Util.NumInt(Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1) * 2.13M);
            //      compute fee-curr-a-fee-2 = fee-curr-h-fee-2 * 2.13.;
            objFee_mstr_rec.FEE_CURR_A_FEE_2 = Util.NumInt(Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2) * 2.13M);

            if (Util.Str(objFee_mstr_rec.FEE_CURR_H_ASST).Length > 2)
            {
                objFee_mstr_rec.FEE_CURR_H_ASST = Util.NumDec(Util.Str(objFee_mstr_rec.FEE_CURR_H_ASST).Substring(0, 2));
                objFee_mstr_rec.FEE_CURR_A_ASST = objFee_mstr_rec.FEE_CURR_H_ASST;   //fee_curr_h_asst;
            }
            else {

                objFee_mstr_rec.FEE_CURR_A_ASST = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_ASST);   //fee_curr_h_asst;
            }

            if (Util.Str(objFee_mstr_rec.FEE_CURR_H_ANAE).Length > 2)
            {
                objFee_mstr_rec.FEE_CURR_H_ANAE = Util.NumDec(Util.Str(objFee_mstr_rec.FEE_CURR_H_ANAE).Substring(0, 2));
                objFee_mstr_rec.FEE_CURR_A_ANAE = objFee_mstr_rec.FEE_CURR_H_ANAE;  //  fee_curr_h_anae;
            }
            else
            {
                objFee_mstr_rec.FEE_CURR_A_ANAE =  Util.NumDec(objFee_mstr_rec.FEE_CURR_H_ANAE); //  fee_curr_h_anae;
            }

            //     rewrite fee-mstr-rec.;
            objFee_mstr_rec.RecordState = State.Modified;
            objFee_mstr_rec.Submit();
        }

        private async Task na0_99_exit()
        {
            Util.Trakker(++ctr, "na0_99_exit");

            //     exit.;
        }

        private async Task<string> pa0_print_error()
        {
            Util.Trakker(++ctr, "pa0_print_error");

            // if err-ind = 6 then;     
            if (err_ind == 6 ) {
                //   	add 1				to	ctr-h2-lines.;
                ctr_h2_lines++;
            }

            // perform da0-check-error-lines	thru	da0-99-exit.;
            await da0_check_error_lines();
            await da0_99_exit();

            h2_reason = err_msg[err_ind];

            // if err-ind = 9 then            
            if (err_ind == 9 ) {
                h2_code = Util.Str(objFee_mstr_rec.FEE_OMA_CD_LTR1) + Util.Str(objFee_mstr_rec.FILLER_NUMERIC); //  fee_oma_cd;
                // 	  go to pa0-100-print-line.;
                return  "pa0_100_print_line";                
            }


            // if fees-not-valid  then            
            if (Util.Str(fees_valid_flag).Equals(fees_not_valid) ) {
                // 	  if ss-rate-count = ss-tape-asst then            
                if (ss_rate_count == ss_tape_asst) {
                          h2_err_ind[3] = "*";            
                }
                // 	  else  if ss-rate-count = ss-tape-spec then            
                else if (ss_rate_count == ss_tape_spec) {
                          h2_err_ind[2] = "*";
                }
                else {
                         h2_err_ind[ss_rate_count] = "*";
                }
            }

            h2_code = Util.Str(objOhip_benefit_sched_rec.ohip_code_grp);

            // if err-ind not = 6  then;       
            if (err_ind != 6 ) {
                h2_icc_code = Util.Str(objFee_mstr_rec.FEE_ICC_SEC); // fee_icc_sec;
            }


            h2_effective_yr = Util.NumInt(objOhip_benefit_sched_rec.ohip_effective_yr);
            h2_effective_mth = objOhip_benefit_sched_rec.ohip_effective_mth;
            h2_effective_day = objOhip_benefit_sched_rec.ohip_effective_day;
            h2_slash1 = "/";
            h2_slash2 = "/";

            if (h2_effective_yr == 0)
            {
                h2_effective_date = string.Empty;
            }
            else
            {
                h2_effective_date = Util.Str(h2_effective_yr) + h2_slash1 + Util.Str(h2_effective_mth).PadLeft(2, '0') + h2_slash2 + Util.Str(h2_effective_day).PadLeft(2, '0');
            }

            h2_reason = err_msg[err_ind];

            // if ohip-termination-date not = 99999999 then            
            if (Util.NumLongInt(objOhip_benefit_sched_rec.ohip_termination_date_grp) != 99999999) {
                h2_termination_yr = objOhip_benefit_sched_rec.ohip_termination_yr;
                h2_termination_mth = objOhip_benefit_sched_rec.ohip_termination_mth;
                h2_termination_day = objOhip_benefit_sched_rec.ohip_termination_day;
                h2_slash3 = "/";
                h2_slash4 = "/";

                if (h2_termination_yr == 0)
                {
                    h2_termination_date = string.Empty;
                }
                else
                {
                    h2_termination_date = Util.Str(h2_termination_yr) + h2_slash3 + Util.Str(h2_termination_mth).PadLeft(2, '0') + h2_slash4 + Util.Str(h2_termination_day).PadLeft(2, '0');
                }
            }

            // if ohip-fees (ss-tape-gp) not = zero then;
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] != 0 ) {
                //    move ohip-fees (ss-tape-gp)	to	h2-new-rate (1). 
                h2_new_rate[1] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp];
            }

            // if ohip-fees (ss-tape-asst) not = zero then;
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] != 0 ) {
                //    move ohip-fees (ss-tape-asst)	to	h2-new-rate (3). 
                h2_new_rate[3] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst];
            }

            // if ohip-fees (ss-tape-spec) not = zero  then
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] != 0 ) {
                //     move ohip-fees (ss-tape-spec)	to	h2-new-rate (2).  
                h2_new_rate[2] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec];
            }

            // if ohip-fees (ss-tape-anae) not = zero then;
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] != 0 ) {
                //    move ohip-fees (ss-tape-anae)	to	h2-new-rate (4). 
                h2_new_rate[4] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae];
            }

            // if ohip-fees (ss-tape-non-anae) not = zero then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] != 0 ) {
                // 	 move ohip-fees (ss-tape-non-anae) 	to	h2-new-rate (5).;
                h2_new_rate[5] = objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae];
            }

            return string.Empty;
        }

        private async Task pa0_100_print_line()
        {
            Util.Trakker(++ctr, "pa0_100_print_line");

            //     write error-rec from blank-line	after	1 line.;
            objError_rec.Error_rec = string.Empty;
            objErrorFile.print(objError_rec.Error_rec, 1, true);

            //  if err-ind = 6  then;            
            if (err_ind == 6 ) {
                objErrorFile.print(true);
                objErrorFile.print(true);
                // 	    write error-rec from h2-stars	after	1 line;
                objError_rec.Error_rec = await h2_stars_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
                objErrorFile.print(true);

                // 	    write error-rec from h2-detail-line after 1 line;            
                objError_rec.Error_rec = await h2_detail_line_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
                objErrorFile.print(true);

                // 	    write error-rec from h2-stars	after	1 line;
                objError_rec.Error_rec = await h2_stars_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
            }
            else {
                objErrorFile.print(true);
                objErrorFile.print(true);
                //    	write error-rec from h2-detail-line after 1 line.;
                objError_rec.Error_rec = await h2_detail_line_grp();
                objErrorFile.print(objError_rec.Error_rec, 1, true);
            }
            
            await h2_detail_line_grp(true);
            err_ind = 0;
            //     add 1				to	ctr-nbr-errors.;
            ctr_nbr_errors++;
        }

        private async Task pa0_99_exit()
        {
            Util.Trakker(++ctr, "pa0_99_exit");

            //     exit.;
        }

        private async Task ra0_check_audit_lines()
        {
            Util.Trakker(++ctr, "ra0_check_audit_lines");

            //  add 1				to	ctr-h1-lines.;
            ctr_h1_lines++;

            //  if ctr-h1-lines > 27 then;            
            if (ctr_h1_lines > 27 ) {
                // 	    add 1				to	ctr-h1-page;
                ctr_h1_page++;
                h1_page_nbr = ctr_h1_page;
                ctr_h1_lines = 0;
                // 	    write audit-rec from h1-head	after	page;
                objAuditFile.PageBreak();
                objAudit_rec.Audit_record1 = await h1_head_grp();
                objAuditFile.print(objAudit_rec.Audit_record1, 1, true);
                objAuditFile.print(true);
                //    	write audit-rec from h1-title-1 after	1 line;
                objAudit_rec.Audit_record1 = await h1_title_1_grp();
                objAuditFile.print(objAudit_rec.Audit_record1, 1, true);
                objAuditFile.print(true);
                objAuditFile.print(true);
                // 	    write audit-rec from h1-title-2 after	2 lines;
                objAudit_rec.Audit_record1 = await h1_title_2_grp();
                objAuditFile.print(objAudit_rec.Audit_record1, 1, true);
                objAuditFile.print(true);
                //    	write audit-rec from h1-title-3	after	1 line.;
                objAudit_rec.Audit_record1 = await h1_title_3_grp();
                objAuditFile.print(objAudit_rec.Audit_record1, 1, true);
            }
        }

        private async Task ra0_99_exit()
        {
            Util.Trakker(++ctr, "ra0_99_exit");

            //     exit.;
        }

        private async Task ta0_check_for_bypass()
        {
            Util.Trakker(++ctr, "ta0_check_for_bypass");

            // if ohip-code = bypass-code (ss-bypass-count) then;
            if (objOhip_benefit_sched_rec.ohip_code_grp == bypass_code[ss_bypass_count]) {
                bypass_check = "Y";
            }
        }

        private async Task ta0_99_exit()
        {
            Util.Trakker(++ctr, "ta0_99_exit");

            //     exit.;
        }

        private async Task va0_skip_rec_types()
        {
            Util.Trakker(++ctr, "va0_skip_rec_types");

            // if fee-curr-add-on-perc-flat-ind =   "P" or "B"  then;            
            if (Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND).ToUpper().Equals("P") || Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND).ToUpper().Equals("B")) {
                oma_code_type_check = "Y";
                err_ind = 11;
            }
            else {
                // 	    next sentence.;
            }
        }

        private async Task va0_99_exit()
        {
            Util.Trakker(++ctr, "va0_99_exit");

            //     exit.;
        }

        private async Task<string> wa0_check_range()
        {
            Util.Trakker(++ctr, "wa0_check_range");

            // if ohip-fees (ss-rate-count) = zero or ws-anae-asst-bypass-ind  then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_rate_count] == 0 || objOhip_benefit_sched_rec.ohip_fees[ss_rate_count] == ws_anae_asst_bypass_ind) {
                // 	   go to wa0-99-exit.;                
                return "wa0_99_exit";
            }

            //  multiply ohip-fees (ss-rate-count) 	by 	10000 	giving	temp-1.
            temp_1 = Util.NumInt(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_rate_count]).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_rate_count]).Trim().Length - 2, 2));

            // if temp-1 not = zero then            
            if (temp_1 != 0  ) {
                err_ind = 17;
                fees_valid_flag = "N";
            }

            // if ohip-fees (ss-rate-count) > 99999.99  then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_rate_count] / 10000 > 99999.99M) {
                err_ind = 16;
                fees_valid_flag = "N";
                // 	go to ja0-99-exit.;
                return "ja0-99-exit";
            }
            return string.Empty;
        }

        private async Task wa0_99_exit()
        {
            Util.Trakker(++ctr, "wa0_99_exit");

            //     exit.;
        }

        private async Task wb0_check_gp_spec()
        {
            Util.Trakker(++ctr, "wb0_check_gp_spec");

            ss_rate_count = 1;

            //  if ohip-fees (ss-tape-gp)   = zero or = ws-anae-asst-bypass-ind   then      
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] == 0 || objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] ==  ws_anae_asst_bypass_ind) {
                // 	    next sentence;            
            }
            // 	else if ohip-fees (ss-tape-spec)   = zero or = ws-anae-asst-bypass-ind then            
            else if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == 0 || objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec] == ws_anae_asst_bypass_ind ) {
                // 	    next sentence;            
            }
            //  else if ohip-fees (ss-tape-gp) not = ohip-fees (ss-tape-spec) then;            
            else if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_gp] != objOhip_benefit_sched_rec.ohip_fees[ss_tape_spec]) {
                     err_ind = 15;
                     fees_valid_flag = "N";
            }
        }

        private async Task wb0_99_exit()
        {
            Util.Trakker(++ctr, "wb0_99_exit");

            //     exit.;
        }

        private async Task<string> wc0_check_anae()
        {
            Util.Trakker(++ctr, "wc0_check_anae");

            ss_rate_count = ss_tape_anae;

            // if  ohip-fees (ss-tape-anae    ) = zero and ohip-fees (ss-tape-non-anae) = zero  then      
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == 0 && objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] == 0 ) {
                // 	  go to wc0-99-exit.;
                return "wc0_99_exit";
            }

            // if  ( ohip-fees (ss-tape-anae    ) = ws-anae-asst-bypass-ind );
            if ( objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == ws_anae_asst_bypass_ind
            //       or ( ohip-fees (ss-tape-non-anae) = ws-anae-asst-bypass-ind ) then      
                || (objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] == ws_anae_asst_bypass_ind )      
            )
            {
                ws_anae_units = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);
                // 	     go to wc0-99-exit.;
                return "wc0_99_exit";
            }

            //     divide ohip-fees (ss-tape-anae    )	by	const-cert-h-curr;
            // 					giving	ws-anae-units;
            // 					remainder ws-anae-rem.;
            ws_anae_units = Util.NumInt((objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000) / (objConstants_mstr_rec_2.CONST_CERT_H_CURR / 100));
            //ws_anae_rem = Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] % objConstants_mstr_rec_2.CONST_CERT_H_CURR);

            if (Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000) % Util.NumInt(objConstants_mstr_rec_2.CONST_CERT_H_CURR / 100) == 0 && Util.NumInt(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000).IndexOf(".") + 1)) == 0)
            {
                ws_anae_rem = 0;
            }
            else
            {
                if (Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000) % Util.NumInt(objConstants_mstr_rec_2.CONST_CERT_H_CURR / 100) != 0)
                {
                    ws_anae_rem = Util.NumInt((objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000) % (objConstants_mstr_rec_2.CONST_CERT_H_CURR / 100));
                }
                else
                {
                    if (Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000).IndexOf(".") > -1)
                    {
                        ws_anae_rem = Util.NumDec(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] / 10000).IndexOf(".")));
                    }
                    else
                    {
                        ws_anae_rem = 0;
                    }
                }
            }



            //     divide ohip-fees (ss-tape-non-anae)	by	const-reg-h-curr;
            // 					giving	ws-non-anae-units;
            // 					remainder ws-non-anae-rem.;

            ws_non_anae_units = Util.NumInt((objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000) / (objConstants_mstr_rec_2.CONST_REG_H_CURR / 100));
            //ws_non_anae_rem = Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] % objConstants_mstr_rec_2.CONST_REG_H_CURR);

            if (Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000) % Util.NumInt(objConstants_mstr_rec_2.CONST_REG_H_CURR / 100) == 0 && Util.NumInt(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000).IndexOf(".") + 1)) == 0)
            {
                ws_non_anae_rem = 0;
            }
            else
            {
                if (Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000) % Util.NumInt(objConstants_mstr_rec_2.CONST_REG_H_CURR / 100) != 0)
                {
                    ws_non_anae_rem = Util.NumInt((objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000) % (objConstants_mstr_rec_2.CONST_REG_H_CURR / 100));
                }
                else
                {
                    if (Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000).IndexOf(".") > -1)
                    {
                        ws_non_anae_rem = Util.NumDec(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] / 10000).IndexOf(".")));
                    }
                    else
                    {
                        ws_non_anae_rem = 0;
                    }
                }
            }

            //  if  ws-anae-units   = ws-non-anae-units;
            if (ws_anae_units == ws_non_anae_units 
                //       and ws-anae-rem     = zero;
                 && ws_anae_rem == 0
                //       and ws-non-anae-rem = zero then;           
                &&  ws_non_anae_rem == 0
                ) {
                // 	    go to wc0-99-exit.;
                return "wc0_99_exit";
            }

            // if ohip-fees (ss-tape-anae) = ohip-fees (ss-tape-non-anae)  then            
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_anae] == objOhip_benefit_sched_rec.ohip_fees[ss_tape_non_anae] ) {
                // 	  if ws-anae-rem = zero then;           
                if (ws_anae_rem == 0 ) {
                    // 	      next sentence;            
                }
                // 	  else if ws-non-anae-rem = zero then            
                else if (ws_non_anae_rem  == 0 ) {
                        ws_anae_units = ws_non_anae_units;
                }
                else {
                           err_ind = 10;
                           fees_valid_flag = "N";
                    // 		  go to wc0-99-exit;
                    return "wc0_99_exit";
                }
            }
            else {
                    err_ind = 13;
                    fees_valid_flag = "N";
                // 	   go to wc0-99-exit.;
                return "wc0_99_exit";
            }

            // if ws-anae-units > 99 then            
            if (ws_anae_units > 90 ) {
                   err_ind = 16;
                  fees_valid_flag = "N";
            }

            return string.Empty;
        }

        private async Task wc0_99_exit()
        {
            Util.Trakker(++ctr, "wc0_99_exit");

            //     exit.;
        }

        private async Task wd0_check_asst()
        {
            Util.Trakker(++ctr, "wd0_check_asst");

            ss_rate_count = ss_tape_asst;

            // if ohip-fees (ss-tape-asst) = zero then       
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] == 0) {
                //    	go to wd0-99-exit.;
                await wd0_99_exit();
                return; 
            }

            // if ohip-fees (ss-tape-asst) = ws-anae-asst-bypass-ind then;    
            if (objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000 == ws_anae_asst_bypass_ind ) {
                ws_asst_units = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ASST);
                // 	   go to wd0-99-exit.;
                await wd0_99_exit();
                return;
            }

            //     divide ohip-fees (ss-tape-asst)	by	const-asst-h-curr;
            // 					giving	ws-asst-units;
            // 					remainder ws-asst-rem.;
            ws_asst_units = Util.NumInt((objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst]/10000) / (objConstants_mstr_rec_2.CONST_ASST_H_CURR/100));


            if (Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst]/10000) % Util.NumInt(objConstants_mstr_rec_2.CONST_ASST_H_CURR/100) == 0 && Util.NumInt(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst]/10000).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000).IndexOf(".") + 1)) == 0)
            {
                ws_asst_rem = 0;
            }
            else
            {
                if (Util.NumInt(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000) % Util.NumInt(objConstants_mstr_rec_2.CONST_ASST_H_CURR / 100) != 0)
                {
                    ws_asst_rem = Util.NumInt((objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000) % (objConstants_mstr_rec_2.CONST_ASST_H_CURR / 100));
                }
                else
                {
                    if (Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000).IndexOf(".") > -1)
                    {
                        ws_asst_rem = Util.NumDec(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000).Substring(Util.Str(objOhip_benefit_sched_rec.ohip_fees[ss_tape_asst] / 10000).IndexOf(".")));
                    }
                    else
                    {
                        ws_asst_rem = 0;
                    }
                }
            }

            // if ws-asst-units > 99 then    
            if (ws_asst_units > 90 ) {
                err_ind = 16;
                fees_valid_flag = "N";
                // 	  go to wd0-99-exit.;
                await wd0_99_exit();
                return; 
            }

            // if ws-asst-rem not = zero then   
            if (ws_asst_rem != 0 ) {
                  err_ind = 10;
                 fees_valid_flag = "N";
            }
        }

        private async Task wd0_99_exit()
        {
            Util.Trakker(++ctr, "wd0_99_exit");

            //     exit.;
        }

        private async Task za0_common_error()
        {
            Util.Trakker(++ctr, "za0_common_error");

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            Console.WriteLine(" error -  " + err_msg_comment);
            //     display confirm.;
            //     stop " ".;
            string tmp =  Console.ReadLine();
            //     display blank-line-24.;
        }

        private async Task za0_99_exit()
        {
            Util.Trakker(++ctr, "za0_99_exit");

            //     exit.;
        }

        private async Task zb0_dump_file_rec_cntrs()
        {
            Util.Trakker(++ctr, "zb0_dump_file_rec_cntrs");

            //     display closing-screen.;
            Console.WriteLine("NEW OHIP RATES IMPLEMENTED = " + ctr_rates_implemented);
            Console.WriteLine("NEW OHIP RATES NOT IMPLEMENTED = " + ctr_nbr_errors);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(print_file_1);
            Console.WriteLine(print_file_2);
            Console.WriteLine("                   " + "PROGRAM U041 ENDING" + sys_date_long_child.ToString() + " " + sys_hrs.ToString() + ":" + sys_min.ToString());
        }

        private async Task zb0_99_exit()
        {
            Util.Trakker(++ctr, "zb0_99_exit");

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {
            Util.Trakker(++ctr, "y2k_default_sysdate");

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            Util.Trakker(++ctr, "y2k_default_sysdate_exit");

            //     exit.;
        }

        private async Task<string> t1_total_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "t1_total_line_grp");

            if (isInitialize)
            {
                t1_rates_implemented = 0;
                t1_nbr_errors = 0;
                t1_no_rma_code = 0;
                return string.Empty;
            }
            else {
                return new string(' ', 2) +
                       "new rates implemented".PadRight(30) +
                       Util.Str(t1_rates_implemented).PadLeft(7, ' ') +
                       new string(' ', 6) +
                       "nbr.of codes on error report".PadRight(34) +
                       Util.Str(t1_nbr_errors).PadLeft(7, ' ') +
                       new string(' ', 6) +
                       "printed-valid codes not on rma".PadRight(30) +
                       Util.Str(t1_no_rma_code).PadLeft(7, ' ');
            }
        }

        private async Task<string> t2_total_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "t2_total_line_grp");

            if (isInitialize)
            {
                t2_no_ohip_rate = 0;
                t2_2_yrs_ago = 0;
                t2_old_terminations = 0;
                t2_zero_fees = 0;
                return string.Empty;
            }
            else {
                return new string(' ', 2) +
                      "printed-no ohip rate for code".PadRight(30) +
                      Util.Str(t2_no_ohip_rate).PadLeft(7, ' ') +
                      new string(' ', 6) +
                      "not printed-terminated before 19".PadRight(32) +
                      Util.Str(t2_2_yrs_ago).PadLeft(4, ' ') +
                      Util.Str(t2_old_terminations).PadLeft(7, ' ') +
                      new string(' ', 4) +
                      "not printed-all rates zero".PadRight(30) +
                      Util.Str(t2_zero_fees).PadLeft(7, ' ');
            }
        }

        private async Task<string> t3_total_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "t3_total_line_grp");

            string t3_diff = t3_difference.ToString() == "0" ? Util.Str("", 9) : Util.ImpliedIntegerFormat("#,0", t3_difference, 9, false, false);

            if (isInitialize)
            {
                t3_expected_ohip = 0;
                t3_actual_ohip = 0;
                t3_difference = 0;
                return string.Empty;
            }
            else {
                return new string(' ', 2) +
                      "nbr.of ohip codes expected:".PadRight(28) +
                      Util.ImpliedIntegerFormat("#,0", t3_expected_ohip, 9, false, false) +
                      new string(' ', 6) +
                      "nbr.of ohip codes read:".PadRight(32) +
                      Util.ImpliedIntegerFormat("#,0", t3_actual_ohip, 9, false, false) +
                      new string(' ', 10) +
                      "difference:".PadRight(28) +
                      t3_diff;
            }
        }

        private async Task<string> t4_total_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "t4_total_line_grp");

            if (isInitialize)
            {
                t4_code_section[1] = string.Empty;
                t4_code_section[2] = string.Empty;
                t4_code_section[3] = string.Empty;
                t4_code_section[4] = string.Empty;
                t4_code_section[5] = string.Empty;
                t4_code_section[6] = string.Empty;
                t4_code_section[7] = string.Empty;
                t4_code_section[8] = string.Empty;
                t4_code_section[9] = string.Empty;
                t4_code_section[10] = string.Empty;
                return string.Empty;
            }
            else {
                return new string(' ', 2) +
                       "bypassed codes were:".PadRight(33) +
                       Util.Str(t4_code_section[1]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[2]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[3]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[4]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[5]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[6]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[7]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[8]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[9]).PadRight(4) +
                       new string(' ', 5) +
                       Util.Str(t4_code_section[10]).PadRight(4) +
                       new string(' ', 5);
            }
        }

        private async Task<string> h1_head_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "h1_head_grp");

            if (isInitialize)
            {
                h1_run_date = string.Empty;
                h1_page_nbr = 0;
                return string.Empty;
            }
            else {
                return "ru041a".PadRight(50) +
                       "ohip rate changes - implemented".PadRight(52) +
                       "run date".PadRight(9) +
                       Util.Str(h1_run_date).PadRight(8) +
                       new string(' ', 4) +
                       "page".PadRight(5) +
                       Util.ImpliedIntegerFormat("#0", h1_page_nbr, 4, false, false);
            }
        }

        private async Task<string> h1_title_1_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "h1_title_1_grp");

            if (isInitialize)
            {
                h1_const_yr = 0;
                h1_const_mth = 0;
                h1_const_day = 0;
                h1_asst_rate = 0;
                h1_cert_rate = 0;
                h1_reg_rate = 0;
                return string.Empty;
            }
            else {
                return "from constants master:".PadRight(28) +
                        "effective date".PadRight(15) +
                        Util.Str(h1_const_yr).PadLeft(4, '0') +
                        "/" +
                        Util.Str(h1_const_mth).PadLeft(2, '0') +
                        "/" +
                       Util.Str(h1_const_day).PadLeft(2, '0') +
                       new string(' ', 5) +
                       "asst. rate".PadRight(10) +
                       Util.ImpliedDecimalFormat("#0.00", h1_asst_rate, 2, 5, false, false) +
                       new string(' ', 4) +
                       "cert.anaesthetist".PadRight(18) +
                       Util.ImpliedDecimalFormat("#0.00", h1_cert_rate, 2, 5, false, false) +
                       new string(' ', 8) +
                       "reg.anaesthetist".PadRight(19) +
                       Util.ImpliedDecimalFormat("#0.00", h1_reg_rate, 2, 5, false, false);
            }
        }

        private async Task<string> h1_title_2_grp()
        {
            Util.Trakker(++ctr, "h1_title_2_grp");

            return new string(' ', 4) +
                   "code".PadRight(9) +
                   "effective".PadRight(12) +
                   "icc".PadRight(11) +
                   "gen.p/technical".PadRight(22) +
                   "special/profess".PadRight(31) +
                   "assistant".PadRight(12) +
                   "anaesthetist".PadRight(23);
        }

        private async Task<string> h1_title_3_grp()
        {
            Util.Trakker(++ctr, "h1_title_3_grp");

            return new string(' ', 15) +
                   "date".PadRight(9) +
                   "code".PadRight(12) +
                   "curr".PadRight(11) +
                   "tape".PadRight(11) +
                   "curr".PadRight(11) +
                   "tape".PadRight(17) +
                   "curr".PadRight(12) +
                   "tape".PadRight(20) +
                   "curr".PadRight(9) +
                   "tape".PadRight(11);
        }

        private async Task<string> h1_detail_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "h1_detail_line_grp");

            if (isInitialize)
            {
                h1_rates_same = string.Empty;
                h1_code_nbr = string.Empty;
                h1_effective_yr = 0;
                h1_effective_mth = 0;
                h1_effective_day = 0;
                h1_effective_date = string.Empty;
                h1_icc_code = string.Empty;
                h1_old_rate12[1] = 0;
                h1_new_rate12[1] = 0;
                h1_old_rate12[2] = 0;
                h1_new_rate12[2] = 0;
                h1_old_rate34[1] = 0;
                h1_old_rate34[2] = 0;
                h1_new_rate34[1] = 0;
                h1_new_rate34[2] = 0;
                h1_old_rate_1 = string.Empty;
                h1_new_rate_1 = string.Empty;
                h1_old_rate_2 = string.Empty;
                h1_new_rate_2 = string.Empty;
                h1_old_rate_3 = string.Empty;
                h1_new_rate_3 = string.Empty;
                h1_old_rate_4 = string.Empty;
                h1_new_rate_4 = string.Empty;
                return string.Empty;
            }
            else {

                h1_old_rate_1 = h1_old_rate12[1].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedDecimalFormat("#,0.00", h1_old_rate12[1], 2, 9, false);
                h1_old_rate_2 = h1_old_rate12[2].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedDecimalFormat("#,0.00", h1_old_rate12[2], 2, 9, false);
                h1_new_rate_1 = h1_new_rate12[1].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedDecimalFormat("#,0.00", h1_new_rate12[1]/100, 2, 9, false);
                h1_new_rate_2 = h1_new_rate12[2].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedDecimalFormat("#,0.00", h1_new_rate12[2]/100, 2, 9, false);
                h1_old_rate_4 = h1_old_rate34[2].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedIntegerFormat("#0", h1_old_rate34[2], 2, false);
                h1_new_rate_4 = h1_new_rate34[2].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedIntegerFormat("#0", h1_new_rate34[2], 2, false);

                if (h1_icc_code == "SP")
                {
                    h1_old_rate_3 = Util.ImpliedIntegerFormat("#0", h1_old_rate34[1], 2, false);
                    h1_new_rate_3 = Util.ImpliedIntegerFormat("#0", h1_new_rate34[1], 2, false);
                }
                else
                {
                    h1_old_rate_3 = h1_old_rate34[1].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedIntegerFormat("#0", h1_old_rate34[1], 2, false);
                    h1_new_rate_3 = h1_new_rate34[1].ToString() == "0" ? Util.Str("", 9) : Util.ImpliedIntegerFormat("#0", h1_new_rate34[1], 2, false);
                }

                return Util.Str(h1_rates_same).PadRight(4) +
                       Util.Str(h1_code_nbr).PadRight(9) +
                       //Util.Str(h1_effective_yr).PadLeft(4, '0') +
                       //Util.Str(h1_slash1).PadRight(1) +
                       //Util.Str(h1_effective_mth).PadLeft(2, '0') +
                       //Util.Str(h1_slash2).PadRight(2) +
                       //Util.Str(h1_effective_day).PadLeft(2, '0') +
                       h1_effective_date.PadRight(10) +
                       new string(' ', 4) +
                       Util.Str(h1_icc_code).PadRight(2) +
                       new string(' ', 4) +
                       h1_old_rate_1 +
                       new string(' ', 2) +
                       h1_new_rate_1 +
                       new string(' ', 2) +
                       h1_old_rate_2 +
                       new string(' ', 2) +
                       h1_new_rate_2 +
                       new string(' ', 13) +
                       h1_old_rate_3 +
                       new string(' ', 11) +
                       h1_new_rate_3 +
                       new string(' ', 14) +
                       h1_old_rate_4 +
                       new string(' ', 7) +
                       h1_new_rate_4;
            }
        }

        private async Task<string> h2_head_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "h2_head_grp");

            if (isInitialize)
            {
                h2_run_date = string.Empty;
                h2_page_nbr = 0;
                return string.Empty;
            }
            else {
                return "ru041b".PadRight(48) +
                       "ohip rate changes - not implemented".PadRight(54) +
                       "run date".PadRight(9) +
                       Util.Str(h2_run_date).PadRight(8) +
                       new string(' ', 4) +
                       "page".PadRight(5) +
                       Util.ImpliedIntegerFormat("#0", h2_page_nbr, 4, false);
            }
        }

        private async Task<string> h2_title_1_grp()
        {
            Util.Trakker(++ctr, "h2_title_1_grp");

            return "code".PadRight(7) +
                    "icc".PadRight(4) +
                    "effective".PadRight(13) +
                    "reason".PadRight(23) +
                    "termination".PadRight(16) +
                    "g.p./".PadRight(10) +
                    "specialist/".PadRight(19) +
                    "assistant".PadRight(17) +
                    "cert.".PadRight(15) +
                    "reg.".PadRight(4);
        }

        private async Task<string> h2_title_2_grp()
        {
            Util.Trakker(++ctr, "h2_title_2_grp");

            return new string(' ', 6) +
                   "code".PadRight(7) +
                   "date".PadRight(38) +
                   "date".PadRight(10) +
                   "technical".PadRight(12) +
                   "professional".PadRight(32) +
                   "anaesthetist".PadRight(15) +
                   "anaesthetist".PadRight(13);
        }

        private async Task<string> h2_detail_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "h2_detail_line_grp");

            if (isInitialize)
            {
                h2_code = string.Empty;
                h2_icc_code = string.Empty;
                h2_effective_yr = 0;
                h2_effective_mth = 0;
                h2_effective_day = 0;
                h2_effective_date = string.Empty;
                h2_reason = string.Empty;
                h2_termination_yr = 0;
                h2_termination_mth = 0;
                h2_termination_day = 0;
                h2_termination_date = string.Empty;
                h2_new_rate[1] = 0;
                h2_new_rate_1 = string.Empty;
                h2_err_ind[1] = string.Empty;
                h2_new_rate[2] = 0;
                h2_new_rate_2 = string.Empty;
                h2_err_ind[2] = string.Empty;
                h2_new_rate[3] = 0;
                h2_new_rate_3 = string.Empty;
                h2_err_ind[3] = string.Empty;
                h2_new_rate[4] = 0;
                h2_new_rate_4 = string.Empty;
                h2_err_ind[4] = string.Empty;
                h2_new_rate[5] = 0;
                h2_new_rate_5 = string.Empty;
                h2_err_ind[5] = string.Empty;

                return string.Empty;
            }
            else
            {
                h2_new_rate_1 = h2_new_rate[1].ToString() == "0" ? Util.Str(" ", 14) : Util.ImpliedDecimalFormat("#,0.0000", h2_new_rate[1], 4, 14, false);
                h2_new_rate_2 = h2_new_rate[2].ToString() == "0" ? Util.Str(" ", 14) : Util.ImpliedDecimalFormat("#,0.0000", h2_new_rate[2], 4, 14, false);
                h2_new_rate_3 = h2_new_rate[3].ToString() == "0" ? Util.Str(" ", 14) : Util.ImpliedDecimalFormat("#,0.0000", h2_new_rate[3], 4, 14, false);
                h2_new_rate_4 = h2_new_rate[4].ToString() == "0" ? Util.Str(" ", 14) : Util.ImpliedDecimalFormat("#,0.0000", h2_new_rate[4], 4, 14, false);
                h2_new_rate_5 = h2_new_rate[5].ToString() == "0" ? Util.Str(" ", 14) : Util.ImpliedDecimalFormat("#,0.00", h2_new_rate[5], 4, 14, false);

                return Util.Str(h2_code).PadRight(7) +
                       Util.Str(h2_icc_code).PadRight(4) +
                       //Util.Str(h2_effective_yr).PadLeft(4, '0') +
                       //Util.Str(h2_slash1).PadRight(1) +
                       //Util.Str(h2_effective_mth).PadLeft(2, '0') +
                       //Util.Str(h2_slash2).PadRight(1) +
                       //Util.Str(h2_effective_day).PadLeft(2, '0') +
                       h2_effective_date.PadRight(10) +
                       new string(' ', 1) +
                       Util.Str(h2_reason).PadRight(28) +
                       //Util.Str(h2_termination_yr).PadLeft(4, '0') +
                       //Util.Str(h2_slash3).PadRight(1) +
                       //Util.Str(h2_termination_mth).PadLeft(2, '0') +
                       //Util.Str(h2_slash4).PadRight(1) +
                       //Util.Str(h2_termination_day).PadLeft(2, '0') +
                       h2_termination_date.PadRight(10) +
                       h2_new_rate_1 +
                       Util.Str(h2_err_ind[1]).PadRight(1) +
                       h2_new_rate_2 +
                       Util.Str(h2_err_ind[2]).PadRight(1) +
                       h2_new_rate_3 +
                       Util.Str(h2_err_ind[3]).PadRight(1) +
                       h2_new_rate_4 +
                       Util.Str(h2_err_ind[4]).PadRight(1) +
                       h2_new_rate_5 +
                       Util.Str(h2_err_ind[5]).PadRight(1);
            }
        }

        private async Task<string> h2_stars_grp()
        {
            Util.Trakker(++ctr, "h2_stars_grp");

            return "*****************************************************";
        }

        private async Task<string> run_date_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "run_date_grp");

            if (isInitialize)
            {
                run_yy = 0;
                run_mm = 0;
                run_dd = 0;
                return string.Empty;
            }
            else {
                return Util.Str(run_yy).PadLeft(4, '0') +
                       "/" +
                       Util.Str(run_mm).PadLeft(2, '0') +
                       "/" +
                       Util.Str(run_dd).PadLeft(2, '0');
            }
        }

        private async Task<string> run_time_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "run_time_grp");

            if (isInitialize)
            {
                run_hrs = 0;
                run_min = 0;
                run_sec = 0;
                return string.Empty;
            }
            else {
                return Util.Str(run_hrs).PadLeft(2, '0') +
                      ":" +
                      Util.Str(run_min).PadLeft(2, '0') +
                      ":" +
                      Util.Str(run_sec).PadLeft(2, '0');
            }
        }

        private async Task<string> sys_time_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "sys_time_grp");

            if (isInitialize)
            {
                sys_hrs = 0;
                sys_min = 0;
                sys_sec = 0;
                sys_hdr = 0;
                return string.Empty;
            }
            else {
                return Util.Str(sys_hrs).PadLeft(2, '0') +
                       Util.Str(sys_min).PadLeft(2, '0') +
                       Util.Str(sys_sec).PadLeft(2, '0') +
                       Util.Str(sys_hdr).PadLeft(2, '0');
            }
        }        

        private async Task<string> sys_date_long_r_grp()
        {
            Util.Trakker(++ctr, "sys_date_long_r_grp");

            return Util.Str(sys_yy).PadLeft(4, '0') +
                   Util.Str(sys_mm).PadLeft(2, '0') +
                   Util.Str(sys_dd).PadLeft(2, '0');
        }

        #endregion
    }
}

