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
using System.Data.SqlClient;

namespace rma.Views
{
    public class R071ViewModel : CommonFunctionScr
    {

        public R071ViewModel()
        {

        }

        #region FD Section
        // FD: print_file
        private Print_record objPrint_record = null;
        private ObservableCollection<Print_record> Print_record_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private F002_CLAIMS_MSTR_HDR objClaims_mstr_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private F002_CLAIMS_MSTR_DTL objClaims_mstr_dtl_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claims_mstr_dtl_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_HDR objClaim_header_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claim_header_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_DTL objClaim_detail_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claim_detail_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        private F002_CLAIMS_MSTR_HDR objClaims_mstr_clinic_nbrs;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> objClaims_mstr_clinic_nbrs_Collection;

        private ReportPrint objPrintFile = null;

        private SqlConnection objSqlConnection;

        #endregion

        #region Properties
        private int _begin_hrs;
        public int begin_hrs
        {
            get
            {
                return _begin_hrs;
            }
            set
            {
                if (_begin_hrs != value)
                {
                    _begin_hrs = value;
                    RaisePropertyChanged("begin_hrs");
                }
            }
        }

        private int _begin_min;
        public int begin_min
        {
            get
            {
                return _begin_min;
            }
            set
            {
                if (_begin_min != value)
                {
                    _begin_min = value;
                    RaisePropertyChanged("begin_min");
                }
            }
        }

        private string _common_status_file;
        public string common_status_file
        {
            get
            {
                return _common_status_file;
            }
            set
            {
                if (_common_status_file != value)
                {
                    _common_status_file = value;
                    _common_status_file = _common_status_file.ToUpper();
                    RaisePropertyChanged("common_status_file");
                }
            }
        }

        private int _ctr_claims_mstr_reads;
        public int ctr_claims_mstr_reads
        {
            get
            {
                return _ctr_claims_mstr_reads;
            }
            set
            {
                if (_ctr_claims_mstr_reads != value)
                {
                    _ctr_claims_mstr_reads = value;
                    RaisePropertyChanged("ctr_claims_mstr_reads");
                }
            }
        }

        //mw
        private int _ctr_claims_a;
        public int ctr_claims_a
        {
            get
            {
                return _ctr_claims_a;
            }
            set
            {
                if (_ctr_claims_a != value)
                {
                    _ctr_claims_a = value;
                    RaisePropertyChanged("ctr_claims_a");
                }
            }
        }

        private int _ctr_claims_b;
        public int ctr_claims_b
        {
            get
            {
                return _ctr_claims_b;
            }
            set
            {
                if (_ctr_claims_b != value)
                {
                    _ctr_claims_b = value;
                    RaisePropertyChanged("ctr_claims_b");
                }
            }
        }

        private int _ctr_claims_c;
        public int ctr_claims_c
        {
            get
            {
                return _ctr_claims_c;
            }
            set
            {
                if (_ctr_claims_c != value)
                {
                    _ctr_claims_c = value;
                    RaisePropertyChanged("ctr_claims_c");
                }
            }
        }

        //mw

        private int _ctr_nbr_dtl_rec_reads;
        public int ctr_nbr_dtl_rec_reads
        {
            get
            {
                return _ctr_nbr_dtl_rec_reads;
            }
            set
            {
                if (_ctr_nbr_dtl_rec_reads != value)
                {
                    _ctr_nbr_dtl_rec_reads = value;
                    RaisePropertyChanged("ctr_nbr_dtl_rec_reads");
                }
            }
        }

        private int _ctr_nbr_hdr_rec_reads;
        public int ctr_nbr_hdr_rec_reads
        {
            get
            {
                return _ctr_nbr_hdr_rec_reads;
            }
            set
            {
                if (_ctr_nbr_hdr_rec_reads != value)
                {
                    _ctr_nbr_hdr_rec_reads = value;
                    RaisePropertyChanged("ctr_nbr_hdr_rec_reads");
                }
            }
        }

        private int _cutoff_date;
        public int cutoff_date
        {
            get
            {
                return _cutoff_date;
            }
            set
            {
                if (_cutoff_date != value)
                {
                    _cutoff_date = value;
                    RaisePropertyChanged("cutoff_date");
                }
            }
        }

        private int _elapsed_hrs;
        public int elapsed_hrs
        {
            get
            {
                return _elapsed_hrs;
            }
            set
            {
                if (_elapsed_hrs != value)
                {
                    _elapsed_hrs = value;
                    RaisePropertyChanged("elapsed_hrs");
                }
            }
        }

        private int _elapsed_min;
        public int elapsed_min
        {
            get
            {
                return _elapsed_min;
            }
            set
            {
                if (_elapsed_min != value)
                {
                    _elapsed_min = value;
                    RaisePropertyChanged("elapsed_min");
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

        private string _key_claims_mstr;
        public string key_claims_mstr
        {
            get
            {
                return _key_claims_mstr;
            }
            set
            {
                if (_key_claims_mstr != value)
                {
                    _key_claims_mstr = value;
                    _key_claims_mstr = _key_claims_mstr.ToUpper();
                    RaisePropertyChanged("key_claims_mstr");
                }
            }
        }

        /* private string _print_file_name;
         public string print_file_name
         {
             get
             {
                  return _print_file_name;
             }
             set
             {
                  if (_print_file_name != value)
                   {
                    _print_file_name = value;
                    _print_file_name = _print_file_name.ToUpper();
                    RaisePropertyChanged("print_file_name");
                   }
             }
         } */

        private int _run_dd;
        public int run_dd
        {
            get
            {
                return _run_dd;
            }
            set
            {
                if (_run_dd != value)
                {
                    _run_dd = value;
                    RaisePropertyChanged("run_dd");
                }
            }
        }

        private int _run_mm;
        public int run_mm
        {
            get
            {
                return _run_mm;
            }
            set
            {
                if (_run_mm != value)
                {
                    _run_mm = value;
                    RaisePropertyChanged("run_mm");
                }
            }
        }

        private int _run_yy;
        public int run_yy
        {
            get
            {
                return _run_yy;
            }
            set
            {
                if (_run_yy != value)
                {
                    _run_yy = value;
                    RaisePropertyChanged("run_yy");
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

        private int _sys_hrs_pr;
        public int sys_hrs_pr
        {
            get
            {
                return _sys_hrs_pr;
            }
            set
            {
                if (_sys_hrs_pr != value)
                {
                    _sys_hrs_pr = value;
                    RaisePropertyChanged("sys_hrs_pr");
                }
            }
        }

        private int _sys_min_pr;
        public int sys_min_pr
        {
            get
            {
                return _sys_min_pr;
            }
            set
            {
                if (_sys_min_pr != value)
                {
                    _sys_min_pr = value;
                    RaisePropertyChanged("sys_min_pr");
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

        private string _ws_reply;
        public string ws_reply
        {
            get
            {
                return _ws_reply;
            }
            set
            {
                if (_ws_reply != value)
                {
                    _ws_reply = value;
                    _ws_reply = _ws_reply.ToUpper();
                    RaisePropertyChanged("ws_reply");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int ws_display_counter = 0;
        //private int elapsed_hrs;
        //private int elapsed_min;
        //private int sys_hrs_pr;
        //private int sys_min_pr;
        private int ctr_line;
        private int line_advance;
        private int nbr_lines_2_advance;
        private int max_nbr_lines_per_page = 64;
        private int page_nbr;
        private string save_clinic_ped;
        private int save_clinic_id;
        private int ws_ped_purge_from;
        private int ws_ped_purge_to;
        //private int cutoff_date;
        private string w_clmhdr_date_sys;
        private int w_clmhdr_date_sys_n;
        private string sw_printed_bat_type;
        private string sw_printed_adj_type;
        private int ss;

        private string begin_time_grp;
        //private int begin_hrs;
        //private int begin_min;
        //private int filler;
        private int claims_occur;
        private int claims_occur_new;
        private string status_claims_mstr = "0";
        private string status_claims_mstr_new = "0";
        private string status_iconst_mstr = "0";
        private string status_prt_file = "0";
        private string feedback_claims_mstr;
        private string feedback_claims_mstr_new;
        private string feedback_iconst_mstr;
        private string const_mstr_rec_nbr;
        //private string common_status_file;
        private string status_cobol_claims_mstr = "0";
        private string status_cobol_claims_mstr_new = "0";
        private string status_cobol_iconst_mstr = "0";
        private int err_ind = 0;
        private string header_done = "N";
        private string totals_written = "N";
        private string display_key_type;


        private string site_id = "RMA";
        private string tmp_doc_nbr_alpha_grp;
        private string[] tmp_batch_nbr_index = new string[9];
        private string flag_request_complete;
        private string flag_request_complete_y = "Y";
        private string flag_request_complete_n = "N";
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";

        private string test_batch_grp;
        private string test_batch_nbr;
        private string test_claim_nbr;

        private string curr_batch_grp;
        private string curr_batch_nbr;
        private string curr_claim_nbr;
        private string error_flag = "N";
        private string eof_claims_mstr = "N";
        private string eof_claims_dtl = "N";
        private string end_search_index = "N";
        private int ss_var_err = 14;
        private int age_category;
        private int day_old;
        private string day_old_r;
        private int i;
        private int dept_nbr;
        private int age_yy;
        private int age_mm;
        private int age_dd;
        //private string ws_reply;
        private string ws_date_reply;
        private decimal dept_tot_amount;
        private decimal balance_due;
        private int write_off_nbr_of_clms;
        private string blank_line = "";

        // private string audit_line_grp;
        //private string filler = "";
        private string audit_title;
        //private string filler = "";
        private int audit_count;
        //private string filler = "";
        private string hold_batch_nbr = "0";
        private int hold_claim_nbr = 0;
        private string hold_period_end;

        private string hold_key_grp;
        private string hold_key_clm_batch_nbr_grp;
        private int hold_key_clinic_nbr1;
        private string hold_key_doc_nbr;
        private int hold_key_week;
        private int hold_key_day;
        private int hold_key_claim_nbr;
        private string hold_key_oma_code;
        private string hold_key_oma_suff;
        private string hold_key_adj_nbr;

        //private string sel_report_date_grp;
        private int report_yy;
        //private string filler = "/";
        private int report_mm;
        //private string filler = "/";
        private int report_dd;

        private string counters_per_clinic_grp;
        private int ctr_clinic_delprev_nbr;
        private int ctr_clinic_delcurr_nbr;
        private decimal ctr_clinic_delcurr_amt;
        private decimal ctr_clinic_delprev_amt;
        private int ctr_clinic_concurr_nbr;
        private int ctr_clinic_conprev_nbr;
        private decimal ctr_clinic_concurr_amt;
        private decimal ctr_clinic_conprev_amt;

        private string counters_grp;
        //private int ctr_claims_mstr_reads;
        //private int ctr_nbr_hdr_rec_reads;
        private int ctr_nbr_hdr_rec_writes;
        //private int ctr_nbr_dtl_rec_reads;
        private int ctr_nbr_dtl_rec_writes;
        private int ctr_claims_mstr_in_acctrec;
        private decimal ctr_amt_claims_mstr_in_acctrec;
        private int ctr_claims_mstr_write_offs;
        private decimal ctr_amt_claims_mstr_write_offs;

        private string tbl_totals_grp;
        private string[] tbl_bat_type_and_tots = new string[9];
        private string[,] tbl_agent_and_sums = new string[9, 12];
        private decimal[,,] tbl_tot = new decimal[9, 12, 9];

        private string tbl_totals_variable_ss_grp;
        private int ss_type;
        private int ss_agent;
        private int ss_item;
        private int ss_type_from;
        private int ss_type_to;
        private int ss_agent_from;
        private int ss_agent_to;
        private int ss_temp1;
        private int sys_date_diff;
        private int max_nbr_types = 6;
        private int max_nbr_agents = 10;
        private int max_nbr_items = 8;

        private string ss_tbl_totals_grp;
        private int ss_claims = 1;
        private int ss_adj_a = 2;
        private int ss_adj_b = 3;
        private int ss_adj_r = 4;
        private int ss_pay_m = 5;
        private int ss_pay_c = 6;
        private int ss_type_tot = 7;
        private int ss_grand_tot = 8;
        private int ss_agent_tot = 11;
        private int ss_a_r_oma = 1;
        private int ss_a_r_ohip = 2;
        private int ss_cash = 3;
        private int ss_nbr = 4;
        private int ss_offset = 4;
        private int del_ret_offset;

        private string tbl_batch_type_desciptions_grp;
        private string tbl_batch_type_descs_grp;
        /*private string filler = "claims          ";
        private string filler = "adjustments- 'a'";
        private string filler = "adjustments- 'b'";
        private string filler = "adjustments- 'r'";
        private string filler = "PAYMENTS   - 'M'";
        private string filler = "PAYMENTS   - 'C'";
        private string filler = "                ";
        private string filler = "GRAND TOTALS    "; */
        private string tbl_batch_type_descs_r_grp;
        private string[] batch_descs = new string[9];
        private string[] desc_bat_type = { "", "CLAIMS       ", "ADJUSTMENTS- ", "ADJUSTMENTS- ", "ADJUSTMENTS- ", "PAYMENTS   - ", "PAYMENTS   - ", "             ", "GRAND TOTALS " };
        private string[] desc_adj_type = { "", "     ", "'A'  ", "'B'  ", "'R'  ", "'M'  ", "'C'  ", "     ", "     " };
        private string print_file_name = "r071";

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


        //private string header_1_grp;
        //private string filler = "R071    P.E.D. ";
        private string h1_ped; // blank when zero
                               //private string filler = "";
                               //private string filler = "CLAIMS MASTER CONVERSION VERIFICATION REPORT";
                               //private string filler = "run date";
        private string h1_run_date;
        //private string filler = "";
        //private string filler = "PAGE";
        private int h1_page_nbr;

        //private string print_line_1_grp;
        private string l1_msg;
        private int l1_yy;
        private string l1_slash_1;
        private int l1_mm;
        private string l1_slash_2;
        private int l1_dd;
        //private string filler;
        private int l1_hrs;
        private string l1_colon;
        private int l1_min;
        //private string filler;

        //private string print_line_2_grp;
        private string l2_msg;
        private int l2_ctr;
        //private string filler;

        //private string print_line_3_grp;
        private string l3_msg;
        private decimal l3_amt;
        //private string filler;

        //private string t2_print_line_grp;
        private string t2_desc_grp;
        private string t2_desc_a;
        private string t2_desc_b;
        private string t2_dash;
        //private string filler;
        private int t2_agent_cd;
        //private string filler;
        private decimal t2_detail_1;
        //private string filler;
        private decimal t2_detail_2;
        //private string filler;
        private decimal t2_detail_3;
        //private string filler;
        private int t2_detail_4;
        //private string filler;
        private decimal t2_detail_5;
        //private string filler;
        private decimal t2_detail_6;
        //private string filler;
        private decimal t2_detail_7;
        //private string filler;
        private int t2_detail_8;
        //private string filler;

        private decimal t2_total_1;
        private decimal t2_total_2;
        private decimal t2_total_3;
        private int t2_total_4;
        private decimal t2_total_5;
        private decimal t2_total_6;
        private decimal t2_total_7;
        private int t2_total_8;

        //private string h5_head_grp;
        //private string filler = "";
        //private string filler = "CLINIC";
        private int h5_clinic_nbr;
        //private string filler = "";
        //private string filler = "-----------";
        //private string filler = "WITHIN - WRITEOFF RANGE";
        //private string filler = "-------------";
        //private string filler = "--------------";
        //private string filler = "OUTSIDE - WRITEOFF RANGE---------";

        //private string h6_head_grp;
        //private string filler = "";
        //private string filler = "AGENT";
        //private string filler = "oma amt";
        //private string filler = "ohip amt";
        //private string filler = "cash amt";
        //private string filler = "NBR";
        //private string filler = "oma amt";
        //private string filler = "ohip amt";
        //private string filler = "cash amt";
        //private string filler = "NBR";

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "invalid reply";
        //private string filler = "DO NOT DELETE-THIS SLOT USED FOR VARIABLE ERROR MSGS";
        //private string filler = "INVALID READ CLAIMS MSTR - INVALID KEY ON APPROX";
        //private string filler = "INVALID READ CLAIMS MSTR - STATUS = 23 OR 99";
        private string err_msg_5_grp;
        //private string filler = "INVALID READ ON CONSTANTS MASTER - CLINIC ID = ";
        private string err_msg_clinic_id;
        //private string filler = "FATAL ERROR - NO CLAIMS IN CLAIMS MASTER";
        //private string filler = "**** CAN BE RE-USED ****";
        //private string filler = "**** CAN BE RE-USED ****";
        private string err_msg_9_grp;
        //private string filler = "INVALID WRITE NEW CLAIMS DTL - 'B' KEY=";
        private string bkey_clmdtl_err_msg = "";
        private string err_msg_10_grp;
        //private string filler = "INVALID WRITE NEW CLAIMS HDR - 'B' KEY=";
        private string bkey_clmhdr_err_msg = "";
        private string err_msg_11_grp;
        //private string filler = "INVALID WRITE NEW CLAIMS HDR -'P' KEY = ";
        private string pkey_clm_err_msg = "";
        //private string filler = "**** CAN BE RE-USED ****";
        //private string filler = "**** CAN BE RE-USED ****";
        //private string filler = "**** CAN BE RE-USED ****";
        private string error_messages_r_grp;
        private string[] err_msg = {"", "INVALID REPLY", "DO NOT DELETE-THIS SLOT USED FOR VARIABLE ERROR MSGS", "INVALID READ CLAIMS MSTR - INVALID KEY ON APPROX", "INVALID READ CLAIMS MSTR - STATUS = 23 OR 99",
                                      "INVALID READ ON CONSTANTS MASTER - CLINIC ID = ", "FATAL ERROR - NO CLAIMS IN CLAIMS MASTER", "**** CAN BE RE-USED ****","**** CAN BE RE-USED ****","INVALID WRITE NEW CLAIMS DTL - 'B' KEY=",
                                      "INVALID WRITE NEW CLAIMS HDR - 'B' KEY=","INVALID WRITE NEW CLAIMS HDR -'P' KEY = ","**** CAN BE RE-USED ****","**** CAN BE RE-USED ****","**** CAN BE RE-USED ****"};
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;


        //private string run_date_grp;
        //private int run_yy;
        //private string filler = "/";
        //private int run_mm;
        //private string filler = "/";
        //private int run_dd;

        private string sys_time_grp;
        private int sys_hrs;
        private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        private string run_time_grp;
        private int run_hrs;
        //private string filler = ":";
        private int run_min;
        //private string filler = ":";
        private int run_sec;
        private string ws_agent_flag;
        private string ohip_agent = "0";
        private string direct_bill_agent = "3";   // todo...  = "3" "4" "6";
        private string alt_fund_agent = "8";
        private string wcb_agent = "9";

        private string endOfJob = "End of Job";
        private bool isRetrieving = false;

        private int ctr_clmhdr;
        private int ctr_claims_detail;
        private int ctr;
        private bool eof_per_clinic = false;
        private int tmp_prev_save_clinic_id;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm.",Line = "25",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "R071",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 29,Data1 = "CLAIMS MASTER VERIFICATION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "16",Col = 10,Data1 = "CONTINUE?  (ENTER Y OR N )",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "05",GroupNameLevel1 = "msg-continue.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "reply"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-purge-ped.",Line = "16",Col = 10,Data1 = "ENTER PED CUTOFF DATE YYYYMM01: ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-purge-ped.",Line = "16",Col = 44,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(8)",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "cutoff_date",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ped-date"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-purge-ped.",Line = "18",Col = 10,Data1 = "CONTINUE?  (ENTER Y OR N )",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "05",GroupNameLevel1 = "scr-purge-ped.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reply"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "20",Col = 10,Data1 = "PROGRAM R071 IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "test-key-display.",Line = "22",Col = 5,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(17)",MaxLength = 17,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "key_claims_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "test-key-display.",Line = "22",Col = 30,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_claims_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "11",Col = 20,Data1 = "NUMBER OF CLAIM MSTR READS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "11",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zzz,zz9",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_claims_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "NUMBER OF HEADER RECS READ =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zzz,zz9",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_nbr_hdr_rec_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 20,Data1 = "NUMBER OF DETAIL RECS READ =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zzz,zzz,zz9",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_nbr_dtl_rec_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 20,Data1 = "PROGRAM R071 BEGAN",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "run_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 57,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 58,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "run_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 60,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "run_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "begin_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 66,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 67,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "begin_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM R071 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 57,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 58,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 60,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs_pr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 66,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 67,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min_pr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "22",Col = 20,Data1 = "TOTAL ELAPSED TIME (HH:MM) -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "22",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "elapsed_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "22",Col = 66,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "22",Col = 67,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "elapsed_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "REPORT FOUND IN",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_constants_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_constants_mstr()
        {

            //     stop "ERROR IN ACCESSING ICONSTANTS MASTER".;
            Console.WriteLine("ERROR IN ACCESSING ICONSTANTS MASTER");
            common_status_file = status_cobol_iconst_mstr;
            //     display file-status-display.;
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void err_claim_header_mstr_file_section()
        {

            //     use after standard error procedure on claims-mstr.;
        }

        private void err_claims_mstr()
        {

            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
            Console.WriteLine("ERROR IN ACCESSING CLAIMS MASTER");
            common_status_file = status_cobol_claims_mstr;
            //     display file-status-display.;
            throw new Exception(endOfJob);
        }

        private void end_declaratives()
        {

        }

        private void initialize_objects()
        {

            // Util.Trakker(++ctr, "initialize_objects");

            objPrint_record = null;
            objPrint_record = new Print_record();

            objClaim_header_rec = null;
            objClaim_header_rec = new F002_CLAIMS_MSTR_HDR();

            Claim_header_rec_Collection = null;
            Claim_header_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();

            objClaim_detail_rec = null;
            objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL();

            Claim_detail_rec_Collection = null;
            Claim_detail_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();

            Iconst_mstr_rec_Collection = null;
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objClaims_mstr_clinic_nbrs = null;
            objClaims_mstr_clinic_nbrs = new F002_CLAIMS_MSTR_HDR();

            objClaims_mstr_clinic_nbrs_Collection = null;
            objClaims_mstr_clinic_nbrs_Collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();

            objPrintFile = null;
            objPrintFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

            objClaims_mstr_rec = new F002_CLAIMS_MSTR_HDR();
            objSqlConnection = objClaims_mstr_rec.Connection();

        }

        //cutoffDate 20160630 wsReplay y
        public void mainline(int cutOffDate, string wsReplay)
        {
            // // Util.Trakker(++ctr, "mainline");

            int row_Clinic = 0;
            try
            {
                cutoff_date = cutOffDate;
                ws_reply = wsReplay;

                initialize_objects();

                // perform aa0-initialization                 thru aa0-99-exit.;
                aa0_initialization();

                objClaims_mstr_clinic_nbrs_Collection = new F002_CLAIMS_MSTR_HDR
                {
                    WhereClmhdr_date_period_end = cutoff_date
                }.Collection_ClinicNbr();

                if (objClaims_mstr_clinic_nbrs_Collection.Count() > 0)
                {
                    while (row_Clinic < objClaims_mstr_clinic_nbrs_Collection.Count())
                    {
                        eof_per_clinic = false;
                        objClaims_mstr_clinic_nbrs = objClaims_mstr_clinic_nbrs_Collection[row_Clinic];
                        row_Clinic++;

                        aa0_20_read_claims_mstr();
                        aa0_99_exit();
                        if (eof_per_clinic)
                        {
                            continue;
                        }
                        //  perform ab0-processing             thru ab0-99-exit.;
                        if (row_Clinic == 1)
                        {
                            ab0_processing();

                        }
                        else
                        {
                            ab0_processing(true);
                        }
                        ab0_99_exit();
                        tmp_prev_save_clinic_id = save_clinic_id;
                    }
                    //  perform az0-finalization                   thru az0-99-exit.;
                    az0_finalization();
                    az0_99_exit();
                }
                //     stop run.;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            finally
            {
                if (objPrintFile != null)
                    objPrintFile.Close();
            }
        }

        private void aa0_initialization()
        {
            // Util.Trakker(++ctr, "aa0_initialization");

            //     accept sys-date                   from    date.;
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
            run_yy = sys_yy;
            run_mm = sys_mm;
            run_dd = sys_dd;

            //     accept begin-time                    from    time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            begin_hrs = sys_hrs;
            begin_min = sys_min;

            //     open input     claims-mstr;
            //              iconst-mstr.;

            //     open output print-file.;
            day_old_r = "";

            //print_line_1 = "";
            MoveSpacesToPrintLine();

            balance_due = 0;

            hold_key_grp = "";
            hold_key_clinic_nbr1 = 0;
            hold_key_doc_nbr = "";
            hold_key_week = 0;
            hold_key_day = 0;
            hold_key_claim_nbr = 0;
            hold_key_oma_code = "";
            hold_key_oma_suff = "";
            hold_key_adj_nbr = "";


            page_nbr = 0;
            //tbl_totals = 0;
            tbl_totals_grp = "0";
            tbl_bat_type_and_tots = new string[9];
            tbl_agent_and_sums = new string[9, 12];
            tbl_tot = new decimal[9, 12, 11];

            //counters = 0;
            ctr_claims_mstr_reads = 0;
            ctr_nbr_hdr_rec_reads = 0;
            ctr_nbr_hdr_rec_writes = 0;
            ctr_nbr_dtl_rec_reads = 0;
            ctr_nbr_dtl_rec_writes = 0;
            ctr_claims_mstr_in_acctrec = 0;
            ctr_amt_claims_mstr_in_acctrec = 0;
            ctr_claims_mstr_write_offs = 0;
            ctr_amt_claims_mstr_write_offs = 0;

            //    hold-key;
            hold_key_clm_batch_nbr_grp = "";
            hold_key_clinic_nbr1 = 0;
            hold_key_doc_nbr = "";
            hold_key_week = 0;
            hold_key_day = 0;
            hold_key_claim_nbr = 0;
            hold_key_oma_code = "";
            hold_key_oma_suff = "";
            hold_key_adj_nbr = "";

            ctr_line = 98;
            //h1_run_date = run_date;

            h1_run_date = run_date_grp();

            //     display scr-title.;
            Console.WriteLine("R071" + "CLAIMS MASTER VERIFICATION" + "                                 " + Util.Str(sys_yy) + "/" + Util.Str(sys_mm) + "/" + Util.Str(sys_dd));

            //     display scr-purge-ped.;
            //     accept scr-ped-date.;
            //     accept scr-reply.;
            Console.WriteLine("ENTER PED CUTOFF DATE YYYYMM01: " + cutoff_date.ToString());
            Console.WriteLine("");
            Console.WriteLine("CONTINUE?  (ENTER Y OR N )" + ws_reply);

            // if  ws-reply not = "Y" then            
            if (!ws_reply.ToUpper().Equals("Y"))
            {
                //         go to az0-finalization;
                az0_finalization();
                return;
            }
            else
            {
                //     display program-in-progress.;
                Console.WriteLine("PROGRAM R071 IN PROGRESS");
            }

            //     perform xc0-zero-clinic-ctrs        thru    xc0-99-exit.;
            xc0_zero_clinic_ctrs();
            xc0_99_exit();
        }

        private void aa0_20_read_claims_mstr()
        {
            // Util.Trakker(++ctr, "aa0_20_read_claims_mstr");

            //objClaims_mstr_dtl_rec.clmdtl_b_key_type = "B";
            objClaim_detail_rec.KEY_CLM_TYPE = "B";

            //objClaims_mstr_dtl_rec.clmdtl_b_data = 0;
            objClaim_detail_rec.CLMDTL_BATCH_NBR = "";
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;
            objClaim_detail_rec.CLMDTL_OMA_CD = "";
            objClaim_detail_rec.CLMDTL_OMA_SUFF = "";
            objClaim_detail_rec.CLMDTL_ADJ_NBR = 0;

            //  perform cb0-read-claims-approx        thru    cb0-99-exit.;
            string retval = cb0_read_claims_approx();
            if (retval.Equals("cb0_99_exit"))
            {
                goto _cb0_99_exit;
            }
            cb0_10_check_for_clmhdr();
            _cb0_99_exit:
            cb0_99_exit();

            if (eof_per_clinic) return;  // added  todo...


            // if eof-claims-mstr = "Y" then            
            if (Util.Str(eof_claims_mstr).ToUpper().Equals("Y"))
            {
                err_ind = 6;
                //    perform za0-common-error        thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //   go to az0-finalization;
                az0_finalization();
                return;
            }
            else
            {
                //       next sentence.;
            }

            //  save_clinic_id = objClaim_header_rec.clmhdr_clinic_nbr_1_2;
            save_clinic_id = Util.NumInt(objClaims_mstr_rec.CLMHDR_BATCH_NBR.PadRight(8, ' ').Substring(0, 2));

            //  perform xe0-obtain-clinic-ped        thru    xe0-99-exit.;
            xe0_obtain_clinic_ped();
            xe0_99_exit();
        }

        private void aa0_99_exit()
        {
            // Util.Trakker(++ctr, "aa0_99_exit");

            //     exit.;
        }

        private void ab0_processing(bool isBypass = false)
        {
            // Util.Trakker(++ctr, "ab0_processing");

            _ab0_processing:

            if (!isBypass)
            {

                // if clmhdr-batch-type = "C" or (    clmhdr-batch-nbr = "22188274" and clmhdr-claim-nbr = 04 )  then     
                if (Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C") || (Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Equals("22188274") && Util.NumInt(objClaims_mstr_rec.CLMHDR_CLAIM_NBR) == 4))
                {
                    curr_batch_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR);  // clmhdr_batch_nbr;
                    curr_claim_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_CLAIM_NBR); // clmhdr_claim_nbr;
                }
                else
                {
                    curr_batch_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR);  // clmhdr_orig_batch_nbr;
                    curr_claim_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_CLAIM_NBR); // clmhdr_orig_claim_nbr;
                }

                // if ws-display-counter >= 10000 then            
                if (Util.NumInt(ws_display_counter) >= 10000)
                {
                    // 	  display "Current Batch: " curr-batch;
                    curr_batch_grp = Util.Str(curr_batch_nbr) + Util.Str(curr_claim_nbr);
                    Console.WriteLine("Current Batch: " + curr_batch_grp);
                    ws_display_counter = 0;
                }
                else
                {
                    // 	   add 1				to	ws-display-counter.;
                    ws_display_counter++;
                }

                //  if test-batch > curr-batch then            
                test_batch_grp = Util.Str(test_batch_nbr) + Util.Str(test_claim_nbr);
                curr_batch_grp = Util.Str(curr_batch_nbr) + Util.Str(curr_claim_nbr);
                if (Util.Str(test_batch_grp).CompareTo(curr_batch_grp) > 0)
                {
                    // 	     display "hold / curr: " test-batch  " / " curr-batch;
                    Console.WriteLine("hold / curr: " + Util.Str(test_batch_grp) + " / " + Util.Str(curr_batch_grp));
                    // 	     display "OUT OF SEQUENCE claim found !!!!!!!";
                    Console.WriteLine("OUT OF SEQUENCE claim found !!!!!!!");
                    // 	     display scr-confirm;
                    //       accept  scr-confirm;
                    ws_reply = Console.ReadLine();
                    //       if test-batch = 2290137005  and curr-batch = 2218827404 then     
                    if (Util.NumLongInt(test_batch_grp) == 2290137005 && Util.NumLongInt(curr_batch_grp) == 2218827404)
                    {
                        // 	         display "NOTE: skipping to claim: " key-claims-mstr;
                        Console.WriteLine("NOTE: skipping to claim: " + Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE));  // todo: check the type value if it's  empty or not...???
                                                                                                                          //           objClaims_mstr_dtl_rec.key_claims_mstr = "2290137006";
                        objClaims_mstr_rec.KEY_CLM_BATCH_NBR = "22901370";
                        objClaims_mstr_rec.KEY_CLM_CLAIM_NBR = 6;
                        //           perform cb0-read-claims-approx thru cb0-99-exit;
                        string retval = cb0_read_claims_approx(true);
                        if (retval.Equals("cb0_99_exit")) goto _cb0_99_exit;
                        cb0_10_check_for_clmhdr();
                        _cb0_99_exit:
                        cb0_99_exit();

                        // 	       display "      arrived  at claim: " key-claims-mstr;
                        Console.WriteLine("      arrived  at claim: " + Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR) + Util.Str(objClaims_mstr_rec.CLMHDR_CLAIM_NBR));
                        //           accept scr-confirm;
                        ws_reply = Console.ReadLine();
                    }
                    else
                    {
                        // 	        next sentence;
                    }
                }
                else
                {
                    //     test_batch = curr_batch;
                    curr_batch_grp = Util.Str(curr_batch_nbr) + Util.Str(curr_claim_nbr).PadLeft(2, '0');
                    test_batch_grp = curr_batch_grp;
                    test_batch_nbr = Util.Str(curr_batch_nbr);
                    test_claim_nbr = Util.Str(curr_claim_nbr).PadLeft(2, '0');
                }
            }

            if (isBypass)
            {
                isBypass = false;
                save_clinic_id = tmp_prev_save_clinic_id;
            }

            // if clmhdr-clinic-nbr-1-2 not = save-clinic-id then            
            if (Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2)) != save_clinic_id)
            {
                //    perform zb0-print-totals-summary        thru    zb0-99-exit;
                zb0_print_totals_summary();
                zb0_99_exit();

                //tbl_totals = 0;
                tbl_bat_type_and_tots = new string[9];
                tbl_agent_and_sums = new string[9, 12];
                tbl_tot = new decimal[9, 12, 9];

                //    perform la0-print-clinic-totals         thru    la0-99-exit;
                la0_print_clinic_totals();
                la0_99_exit();

                //    perform xc0-zero-clinic-ctrs            thru    xc0-99-exit;
                xc0_zero_clinic_ctrs();
                xc0_99_exit();

                save_clinic_id = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2));   //clmhdr_clinic_nbr_1_2;
                //    perform xe0-obtain-clinic-ped           thru    xe0-99-exit.;
                xe0_obtain_clinic_ped();
                xe0_99_exit();
            }


            ws_agent_flag = Util.Str(objClaims_mstr_rec.CLMHDR_AGENT_CD); //  clmhdr_agent_cd;


            //    add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-ohip;
            //                                             giving balance-due.;
            balance_due = (Util.NumDec(objClaims_mstr_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS) + Util.NumDec(objClaims_mstr_rec.CLMHDR_TOT_CLAIM_AR_OHIP))/100m;

            w_clmhdr_date_sys = Util.Str(objClaims_mstr_rec.CLMHDR_DATE_SYS);  //objClaim_header_rec.clmhdr_date_sys;
            sys_date_diff = 0;

            //    compute sys-date-diff = (sys-yy * 10000)+(sys-mm * 100)+sys-dd.;
            sys_date_diff = (sys_yy * 10000) + (sys_mm * 100) + sys_dd;

            // if ( site-id = "RMA" and clmhdr-batch-type = "C"  and clmhdr-date-period-end <=  cutoff-date and (	    ((balance-due > -1.00 and balance-due <  1.00)  and (iconst-clinic-card-colour <> 'O'))
            //        	                                                                                         or  (    iconst-clinic-card-colour = 'O' ))            
            // 	  )
            //         or;
            //           (     site-id = "HSC";
            //            and clmhdr-batch-type          = "C";
            //            and clmhdr-date-period-end not greater than cutoff-date;
            //            and (   clmhdr-agent-cd = 1  or (balance-due = 0)            
            //                )
            // 	         )
            //     then;


            if ((site_id == "RMA" && Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C") && Util.NumInt(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END) <= cutoff_date && (((balance_due > -1.00M && balance_due < 1.00M) && (Util.Str(objIconst_mstr_rec.ICONST_CLINIC_CARD_COLOUR) != "O"))
                                                                                                                                                                    || (Util.Str(objIconst_mstr_rec.ICONST_CLINIC_CARD_COLOUR) == "O"))
                  ) || (site_id == "HSC"
                            && Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C")
                            && Util.NumInt(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END) <= cutoff_date
                            && (Util.NumInt(objClaims_mstr_rec.CLMHDR_AGENT_CD) == 1 || (balance_due == 0)
                                )
                         )
               )
            {
                ctr_claims_b += Claim_detail_rec_Collection.Count();

                //      perform ab1-ctr-del             thru    ab1-99-exit;
                ab1_ctr_del();
                ab1_99_exit();

                del_ret_offset = 0;
                //         perform sa0-add-batch-totals    thru    sa0-99-exit;
                sa0_add_batch_totals();
                sa0_99_exit();

                //         perform cb3-add-to-claim-nbr    thru    cb3-99-exit;
                cb3_add_to_claim_nbr();
                cb3_99_exit();

                //         perform cb0-read-claims-approx  thru    cb0-99-exit;
                string retVal = cb0_read_claims_approx(true);
                if (retVal.Equals("cb0_99_exit"))
                {
                    goto _cb0_99_exit;
                }
                cb0_10_check_for_clmhdr();
                _cb0_99_exit:
                cb0_99_exit();

                if (eof_per_clinic == true)
                {
                    return;
                }
            }
            else
            {
                ctr_claims_c += Claim_detail_rec_Collection.Count();

                //         perform ab2-ctr-con             thru    ab2-99-exit;
                ab2_ctr_con();
                ab2_99_exit();

                del_ret_offset = 4;
                //         perform sa0-add-batch-totals    thru    sa0-99-exit;
                sa0_add_batch_totals();
                sa0_99_exit();

                //         perform da6-save-clmhdr-info    thru    da6-99-exit;
                da6_save_clmhdr_info();
                da6_99_exit();

                eof_claims_dtl = "N";
                //      perform ha0-read-dtl-recs       thru    ha0-99-exit;
                //                  until eof-claims-dtl = "Y".;
                do
                {
                    ha0_read_dtl_recs();
                    ha0_99_exit();
                } while (Util.Str(eof_claims_dtl).ToUpper() != "Y");

                // after this it should read the next record not endless loop.

                // added  
                string retVal = cb0_read_claims_approx(true);
                if (retVal.Equals("cb0_99_exit"))
                {
                    goto _cb0_99_exit;
                }
                cb0_10_check_for_clmhdr();
                _cb0_99_exit:
                cb0_99_exit();

                if (eof_per_clinic == true)
                {
                    return;
                }
            }

            // if eof-claims-mstr not = "Y" then            
            if (Util.Str(eof_claims_mstr).ToUpper() != "Y")
            {
                //         go to ab0-processing.;                
                goto _ab0_processing;
            }
        }

        private void ab0_99_exit()
        {
            // Util.Trakker(++ctr, "ab0_99_exit");

            //     exit.;
        }

        private void ab1_ctr_del()
        {
            // Util.Trakker(++ctr, "ab1_ctr_del");

            //     add balance-due                      to      ctr-amt-claims-mstr-write-offs.;
            ctr_amt_claims_mstr_write_offs += Util.NumDec(balance_due);

            //     add 1                           to      ctr-claims-mstr-write-offs.;
            ctr_claims_mstr_write_offs += 1;

            //     if clmhdr-date-period-end < save-clinic-ped then;            
            if (Util.NumInt(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END) < Util.NumInt(save_clinic_ped))
            {
                //        add 1                           to      ctr-clinic-delprev-nbr;
                ctr_clinic_delprev_nbr += 1;
                //         add balance-due                 to      ctr-clinic-delprev-amt;
                ctr_clinic_delprev_amt += Util.NumDec(balance_due);
            }
            else
            {
                //         add 1                           to      ctr-clinic-delcurr-nbr;
                ctr_clinic_delcurr_nbr += 1;
                //         add balance-due                 to      ctr-clinic-delcurr-amt.;
                ctr_clinic_delcurr_amt += balance_due;
            }
        }

        private void ab1_99_exit()
        {
            // Util.Trakker(++ctr, "ab1_99_exit");

            //     exit.;
        }

        private void ab2_ctr_con()
        {
            // Util.Trakker(++ctr, "ab2_ctr_con");

            //     add 1                              to      ctr-claims-mstr-in-acctrec.;
            ctr_claims_mstr_in_acctrec += 1;

            //     add balance-due                      to      ctr-amt-claims-mstr-in-acctrec.;
            ctr_amt_claims_mstr_in_acctrec += Util.NumDec(balance_due);

            //  if clmhdr-date-period-end < save-clinic-ped then;
            if (Util.NumInt(objClaims_mstr_rec.CLMHDR_DATE_PERIOD_END) < Util.NumInt(save_clinic_ped))
            {
                //        add 1                           to      ctr-clinic-conprev-nbr;
                ctr_clinic_conprev_nbr += 1;
                //         add balance-due                 to      ctr-clinic-conprev-amt;
                ctr_clinic_conprev_amt += Util.NumDec(balance_due);
            }
            else
            {
                //        add 1                           to      ctr-clinic-concurr-nbr;
                ctr_clinic_concurr_nbr += 1;
                //       add balance-due                 to      ctr-clinic-concurr-amt.;
                ctr_clinic_concurr_amt += Decimal.Parse(Util.NumDec(balance_due).ToString("0.00"));
            }
        }

        private void ab2_99_exit()
        {
            // Util.Trakker(++ctr, "ab2_99_exit");

            //     exit.;
        }

        private void az0_finalization()
        {
            // Util.Trakker(++ctr, "az0_finalization");

            //     perform zb0-print-totals-summary                thru    zb0-99-exit.;
            zb0_print_totals_summary();
            zb0_99_exit();

            //     perform la0-print-clinic-totals         thru    la0-99-exit.;
            la0_print_clinic_totals();
            la0_99_exit();

            //     accept sys-date                         from    date.;
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
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            //     accept sys-time                                from    time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            sys_hrs_pr = sys_hrs;
            sys_min_pr = sys_min;

            //    perform az1-determine-elapsed-time               thru    az1-99-exit.;
            az1_determine_elapsed_time();
            az1_99_exit();

            //   perform az2-print-audit-report-tots             thru    az2-99-exit.;
            az2_print_audit_report_tots();
            az2_99_exit();

            //     display scr-closing-screen.;
            Console.WriteLine("NUMBER OF CLAIM MSTR READS = " + string.Format("{0:#,0}", ctr_claims_mstr_reads));
            Console.WriteLine("NUMBER OF HEADER RECS READ =" + string.Format("{0:#,0}", ctr_nbr_hdr_rec_reads));
            Console.WriteLine("NUMBER OF DETAIL RECS READ =" + string.Format("{0:#,0}", ctr_nbr_dtl_rec_reads));
            Console.WriteLine("PROGRAM R071 BEGAN         " + run_yy.ToString() + "/" + run_mm + "/" + run_dd + "   " + begin_hrs.ToString() + ":" + begin_min.ToString());
            Console.WriteLine("");
            Console.WriteLine("PROGRAM R071 ENDING      " + sys_yy.ToString() + "/" + sys_mm + "/" + sys_dd + " " + sys_hrs_pr.ToString() + ":" + sys_min_pr.ToString());
            Console.WriteLine("TOTAL ELAPSED TIME (HH:MM) -     " + elapsed_hrs.ToString() + ":" + elapsed_min.ToString());
            Console.WriteLine("REPORT FOUND IN " + print_file_name);

            //     display confirm.;
            //     close iconst-mstr;
            //       claims-mstr;
            //      print-file.;
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {
            // Util.Trakker(++ctr, "az0_99_exit");

            //     exit.;
        }

        private void az1_determine_elapsed_time()
        {
            // Util.Trakker(++ctr, "az1_determine_elapsed_time");

            // if sys-min < begin-min then            
            if (sys_min < begin_min)
            {
                //    add 60  to      sys-min;
                sys_min += 60;
                //     subtract 1                              from    sys-hrs;
                sys_hrs -= 1;
            }
            else
            {
                //       next sentence.;
            }

            elapsed_min = sys_min;
            elapsed_hrs = sys_hrs;
            //     subtract begin-min                              from    elapsed-min.;
            elapsed_min -= Util.NumInt(begin_min);
            //     subtract begin-hrs                              from    elapsed-hrs.;
            _elapsed_hrs -= Util.NumInt(begin_hrs);
        }

        private void az1_99_exit()
        {
            // Util.Trakker(++ctr, "az1_99_exit");

            //     exit.;
        }

        private void az2_print_audit_report_tots()
        {
            // Util.Trakker(++ctr, "az2_print_audit_report_tots");

            ctr_line = 98;
            //   move "G R A N D   T O T A L S"             to l1-msg.
            l1_msg = "G R A N D   T O T A L S";
            line_advance = 3;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();

            // move "CLAIMS BETWEEN -.99 +.99 - NUMBER"    to l2-msg.
            l2_msg = "CLAIMS BETWEEN -.99 +.99 - NUMBER";
            l2_ctr = ctr_claims_mstr_write_offs;
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            //move "CLAIMS BETWEEN -.99 +.99 - AMOUNT"    to l3-msg.
            l3_msg = "CLAIMS BETWEEN -.99 +.99 - AMOUNT";
            l3_amt = ctr_amt_claims_mstr_write_offs;
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(3);
            xa0_99_exit();


            // move "CLAIMS IN A/R            - NUMBER"        to l2-msg.
            l2_msg = "CLAIMS IN A/R            - NUMBER";
            l2_ctr = ctr_claims_mstr_in_acctrec;
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            // move "CLAIMS IN A/R            - AMOUNT"        to      l3-msg. 
            l3_msg = "CLAIMS IN A/R            - AMOUNT";
            l3_amt = ctr_amt_claims_mstr_in_acctrec;
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(3);
            xa0_99_exit();

            // move "(TOTAL CLAIMS RECORDS READ - NUMBER)"     to      l2-msg. 
            l2_msg = "(TOTAL CLAIMS RECORDS READ - NUMBER)";
            l2_ctr = ctr_claims_mstr_reads;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            l2_msg = "(HEADERS READ              - NUMBER)";
            l2_ctr = ctr_nbr_hdr_rec_reads;
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            l2_msg = "(DETAILS READ              - NUMBER)";
            l2_ctr = ctr_nbr_dtl_rec_reads;
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            l1_msg = "PROGRAM STATISTICS";
            ctr_line = 98;
            line_advance = 4;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();

            //  move "PROGRAM R071 BEGAN"                       to      l1-msg. 
            l1_msg = "PROGRAM R071 BEGAN";
            l1_yy = run_yy;
            l1_slash_1 = "/";
            l1_mm = run_mm;
            l1_slash_2 = "/";
            l1_dd = run_dd;
            l1_hrs = begin_hrs;
            l1_min = begin_min;
            l1_colon = ":";
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();

            //  move "PROGRAM R071 ENDED"                       to      l1-msg. 
            l1_msg = "PROGRAM R071 ENDED";
            l1_yy = sys_yy;
            l1_slash_1 = "/";
            l1_mm = sys_mm;
            l1_slash_2 = "/";
            l1_dd = sys_dd;
            l1_hrs = sys_hrs_pr;
            l1_min = sys_min_pr;
            l1_colon = ":";
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();

            l1_msg = "ELAPSED TIME";
            l1_hrs = elapsed_hrs;
            l1_min = elapsed_min;
            l1_colon = ":";
            line_advance = 1;
            //     perform xa0-write-audit-rpt-line               thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();

            //mw
            //l1_msg = "Core Count Total Details";
            //line_advance = 1;
            //xa0_write_audit_rpt_line(1);
            //xa0_99_exit();

            //l1_msg = "Core Count match if";
            //line_advance = 1;
            //xa0_write_audit_rpt_line(1);
            //xa0_99_exit();

            //l1_msg = "Core Count else if";
            //line_advance = 1;
            //xa0_write_audit_rpt_line(1);
            //xa0_99_exit();

            //mw
        }

        private void az2_99_exit()
        {
            // Util.Trakker(++ctr, "az2_99_exit");

            //     exit.;
        }

        private string cb0_read_claims_approx(bool bypass = false)
        {
            // Util.Trakker(++ctr, "cb0_read_claims_approx");

            claims_occur = 0;
            feedback_claims_mstr = "0";

            //     start claims-mstr  key is greater than or equal to key-claims-mstr;
            //          invalid key;
            //          err_ind = 3;
            //           perform za0-common-error       thru    za0-99-exit;
            //           go to az0-finalization.;

            //  read claims-mstr next.;


            if (!bypass)
            {
                Claims_mstr_rec_Collection = new F002_CLAIMS_MSTR_HDR
                {
                    WhereKey_clm_type = "B",
                    WhereClinic_nbr = Util.NumInt(objClaims_mstr_clinic_nbrs.CLINIC_NBR),
                    WhereClmhdr_date_period_end = cutoff_date
                }.Collection_ClinicNbr_CutOff_Date(false, objSqlConnection);
                ctr_clmhdr = 0;
            }
            else  // bypass
            {

                if (ctr_clmhdr >= Claims_mstr_rec_Collection.Count())
                {
                    eof_per_clinic = true;
                    return "cb0_99_exit";
                }
                objClaims_mstr_rec = Claims_mstr_rec_Collection[ctr_clmhdr];
                ctr_clmhdr++;
            }

            if (Claims_mstr_rec_Collection.Count() > 0)
            {
                if (!bypass)
                {
                    objClaims_mstr_rec = Claims_mstr_rec_Collection[ctr_clmhdr];
                    ctr_clmhdr++;
                }

                Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
                {
                    WhereKey_clm_type = objClaims_mstr_rec.KEY_CLM_TYPE,
                    WhereKey_clm_batch_nbr = objClaims_mstr_rec.KEY_CLM_BATCH_NBR,
                    WhereKey_clm_claim_nbr = objClaims_mstr_rec.KEY_CLM_CLAIM_NBR
                }.Collection_Claims_Detail_Using_Header();



                // if status-cobol-claims-mstr = 23 or status-cobol-claims-mstr = 99  then       // record not found an attempt has been made to access a record
                if (Claim_detail_rec_Collection.Count() == 0)
                {
                    err_ind = 4;
                     //         perform za0-common-error thru za0-99-exit;
                     za0_common_error();
                     za0_99_exit();
                     //         go to az0-finalization;
                     az0_finalization();
                     return string.Empty;

                }
                else
                {
                    //         if status-cobol-claims-mstr = 10 then;     //  End of file  or NO next logical record exist. you have reach end of file.     
                    if (Claim_detail_rec_Collection.Count() == 0)
                    {                                                //todo...  ctr-claims-mstr-reads   ???
                        eof_claims_mstr = "Y";
                        //            go to cb0-99-exit;                    
                        return "cb0_99_exit";
                    }
                    else
                    {
                        //ctr_claims_a += Claim_detail_rec_Collection.Count();  //mw

                        ctr_claims_detail = 0;
                        objClaim_detail_rec = Claim_detail_rec_Collection[ctr_claims_detail];  // check the index value for now...
                        eof_claims_mstr = "N";
                    }
                }
            }
            else
            {
                err_ind = 3;
                za0_common_error();
                za0_99_exit();
                //         go to az0-finalization;
                az0_finalization();
            }
            return string.Empty;
        }

        private void cb0_10_check_for_clmhdr()
        {
            // Util.Trakker(++ctr, "cb0_10_check_for_clmhdr");

            // if clmdtl-b-key-type not = 'B' then            
            if (Util.Str(objClaims_mstr_rec.KEY_CLM_TYPE).ToUpper() != "B")
            {
                eof_claims_mstr = "Y";
                //  go to cb0-99-exit;
                cb0_99_exit();
                return;
            }
            else
            {
                //        next sentence.;
            }

            //         add 1                              to      ctr-claims-mstr-reads;
            ctr_claims_mstr_reads++;
            //                                        ctr-nbr-hdr-rec-reads.;
            ctr_nbr_hdr_rec_reads++;

        }

        private void cb0_99_exit()
        {
            // Util.Trakker(++ctr, "cb0_99_exit");

            //     exit.;
        }

        private void cb3_add_to_claim_nbr()
        {
            // Util.Trakker(++ctr, "cb3_add_to_claim_nbr");

            // if  clmdtl-b-claim-nbr = 99 then            
            if (Util.NumInt(objClaims_mstr_rec.CLMHDR_CLAIM_NBR) == 99)
            {
                // objClaims_mstr_dtl_rec.clmdtl_b_claim_nbr = 0;
                objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;
                objClaims_mstr_rec.KEY_CLM_CLAIM_NBR = 0;  // added for the where clause
                // 	    perform xx0-increment-batch-nbr thru    xx0-99-exit;
                xx0_increment_batch_nbr();
                xx0_99_exit();
            }
            else
            {
                //         add 1                           to clmdtl-b-claim-nbr.;
                objClaims_mstr_rec.CLMHDR_CLAIM_NBR += 1;  // objClaim_detail_rec.CLMDTL_CLAIM_NBR += 1;
                objClaims_mstr_rec.KEY_CLM_CLAIM_NBR += 1;  // objClaims_mstr_rec.KEY_CLM_CLAIM_NBR += 1;  // added for the where clause
            }
        }

        private void cb3_99_exit()
        {
            // Util.Trakker(++ctr, "cb3_99_exit");

            //     exit.;
        }

        private void da6_save_clmhdr_info()
        {
            // Util.Trakker(++ctr, "da6_save_clmhdr_info");

            // if clmhdr-batch-type = "C" then;            
            if (Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C"))
            {
                hold_batch_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR);   //objClaim_header_rec.clmhdr_batch_nbr;
                hold_claim_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_CLAIM_NBR);  //objClaim_header_rec.clmhdr_claim_nbr;
            }
            else
            {
                hold_batch_nbr = Util.Str(objClaims_mstr_rec.CLMHDR_ORIG_BATCH_NBR); //objClaim_header_rec.clmhdr_orig_batch_nbr;
                hold_claim_nbr = Util.NumInt(objClaims_mstr_rec.CLMHDR_ORIG_CLAIM_NBR);  //objClaim_header_rec.clmhdr_orig_claim_nbr;
            }
        }

        private void da6_99_exit()
        {
            // Util.Trakker(++ctr, "da6_99_exit");

            //     exit.;
        }

        private void ha0_read_dtl_recs()
        {
            // Util.Trakker(++ctr, "ha0_read_dtl_recs");

            //  perform ja0-read-claims-next        thru    ja0-99-exit.;
            ja0_read_claims_next();
            ja0_99_exit();

            // if eof-claims-dtl = "N" then;            
            if (Util.Str(eof_claims_dtl).ToUpper() == "N")
            {
                //         go to ha0-99-exit;
                ha0_99_exit();
                return;
            }
            else
            {
                //        next sentence.;
            }
        }

        private void ha0_99_exit()
        {
            // Util.Trakker(++ctr, "ha0_99_exit");

            //     exit.;
        }

        private void ja0_read_claims_next()
        {
            // Util.Trakker(++ctr, "ja0_read_claims_next");

            claims_occur = 0;
            feedback_claims_mstr = "0";

            //  read claims-mstr       next;
            //         at end;
            //            eof_claims_mstr = "Y";
            //            eof_claims_dtl = "Y";		 
            //            go to ja0-99-exit.;

            // if (ctr_claims_mstr_reads >= Claim_detail_rec_Collection.Count())
            if (ctr_claims_detail >= Claim_detail_rec_Collection.Count())
            {
                //eof_claims_mstr = "Y";
                eof_claims_dtl = "Y";
                //   go to ja0-99-exit.;
                ja0_99_exit();
                return;
            }

            //objClaim_detail_rec = Claim_detail_rec_Collection[ctr_claims_detail];   //[ctr_claims_mstr_reads];
            ctr_claims_detail++;

            //  if clmdtl-b-key-type not = "B" then        
            if (Util.Str(objClaim_detail_rec.KEY_CLM_TYPE) != "B")
            {
                eof_claims_mstr = "Y";
                eof_claims_dtl = "Y";
                //      go to ja0-99-exit;
                ja0_99_exit();
                return;
            }
            else
            {
                //        next sentence.;
            }

            //  if clmdtl-b-batch-num = hold-batch-nbr and clmdtl-b-claim-nbr = hold-claim-nbr then            
            if (Util.Str(objClaim_detail_rec.CLMDTL_BATCH_NBR) == hold_batch_nbr && Util.NumInt(objClaim_detail_rec.CLMDTL_CLAIM_NBR) == hold_claim_nbr)
            {
                //mw
                //StreamWriter sw = new StreamWriter("Detail Claims matching hold variables.txt", true, System.Text.Encoding.Default);
                //sw.WriteLine(objClaim_detail_rec.CLMDTL_BATCH_NBR.PadRight(15, ' ') + Util.Str(objClaim_detail_rec.CLMDTL_CLAIM_NBR));
                //sw.Flush();
                //sw.Close();
                //sw.Dispose();
                //mw

                eof_claims_dtl = "N";
                //   	add 1                           to      ctr-nbr-dtl-rec-reads;
                ctr_nbr_dtl_rec_reads++;
                ctr_claims_mstr_reads++;
            }
            else
            {
                //mw
                //StreamWriter sw = new StreamWriter("Detail Claims not matching hold variables.txt", true, System.Text.Encoding.Default);
                //sw.WriteLine(hold_batch_nbr.PadRight(15, ' ') + Util.Str(hold_claim_nbr).PadRight(5, ' ') + objClaim_detail_rec.CLMDTL_BATCH_NBR.PadRight(15, ' ') + Util.Str(objClaim_detail_rec.CLMDTL_CLAIM_NBR));
                //sw.Flush();
                //sw.Close();
                //sw.Dispose();
                //mw

                eof_claims_dtl = "Y";
                //  	add 1                           to      ctr-nbr-hdr-rec-reads.;
                //ctr_nbr_hdr_rec_reads++;
            }

            //     add 1                                to      ctr-claims-mstr-reads.;
            //ctr_claims_mstr_reads++;
        }

        private void ja0_99_exit()
        {
            // Util.Trakker(++ctr, "ja0_99_exit");

            //     exit.;
        }

        private void la0_print_clinic_totals()
        {
            // Util.Trakker(++ctr, "la0_print_clinic_totals");

            l1_msg = "CLINIC NUMBER";
            l1_yy = save_clinic_id;
            line_advance = 4;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();

            // move "CLAIMS BETWEEN -.99 +.99 CURRENT  PED - NUMBER"	to	l2-msg. 
            l2_msg = "CLAIMS BETWEEN -.99 +.99 CURRENT  PED - NUMBER";
            l2_ctr = ctr_clinic_delcurr_nbr;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            //move "CLAIMS BETWEEN -.99 +.99 PREVIOUS PED - NUMBER"	to 	l2-msg. 
            l2_msg = "CLAIMS BETWEEN -.99 +.99 PREVIOUS PED - NUMBER";
            l2_ctr = ctr_clinic_delprev_nbr;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            // move "CLAIMS BETWEEN -.99 +.99 CURRENT  PED - AMOUNT"	to	l3-msg. 
            l3_msg = "CLAIMS BETWEEN -.99 +.99 CURRENT  PED - AMOUNT";
            l3_amt = ctr_clinic_delcurr_amt;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(3);
            xa0_99_exit();

            // move "CLAIMS BETWEEN -.99 +.99 PREVIOUS PED - AMOUNT"	to	l3-msg. 
            l3_msg = "CLAIMS BETWEEN -.99 +.99 PREVIOUS PED - AMOUNT";
            l3_amt = ctr_clinic_delprev_amt;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(3);
            xa0_99_exit();

            // move "CLAIMS IN A/R            CURRENT  PED - NUMBER"   to      l2-msg. 
            l2_msg = "CLAIMS IN A/R            CURRENT  PED - NUMBER";
            l2_ctr = ctr_clinic_concurr_nbr;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            // move "CLAIMS IN A/R            PREVIOUS PED - NUMBER"   to      l2-msg. 
            l2_msg = "CLAIMS IN A/R            PREVIOUS PED - NUMBER";
            l2_ctr = ctr_clinic_conprev_nbr;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(2);
            xa0_99_exit();

            // move "CLAIMS IN A/R            CURRENT  PED - AMOUNT"   to      l3-msg. 
            l3_msg = "CLAIMS IN A/R            CURRENT  PED - AMOUNT";
            l3_amt = ctr_clinic_concurr_amt;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(3);
            xa0_99_exit();

            // move "CLAIMS IN A/R            PREVIOUS PED - AMOUNT"   to      l3-msg. 
            l3_msg = "CLAIMS IN A/R            PREVIOUS PED - AMOUNT";
            l3_amt = ctr_clinic_conprev_amt;
            line_advance = 2;
            //     perform xa0-write-audit-rpt-line                       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(3);
            xa0_99_exit();
        }

        private void la0_99_exit()
        {
            // Util.Trakker(++ctr, "la0_99_exit");

            //     exit.;
        }

        private void sa0_add_batch_totals()
        {
            // Util.Trakker(++ctr, "sa0_add_batch_totals");

            //   perform sa1-find-ss-type             thru    sa1-99-exit.;
            sa1_find_ss_type();
            sa1_99_exit();

            //     add  1, clmhdr-agent-cd         giving  ss-agent.;
            ss_agent = Util.NumInt(objClaims_mstr_rec.CLMHDR_AGENT_CD) + 1;

            //   add del-ret-offset, ss-a-r-oma              giving ss-temp1.;
            ss_temp1 = del_ret_offset + ss_a_r_oma;

            //   add clmhdr-tot-claim-ar-oma         to tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaims_mstr_rec.CLMHDR_TOT_CLAIM_AR_OMA);

            //   add del-ret-offset, ss-a-r-ohip             giving ss-temp1.;
            ss_temp1 = del_ret_offset + ss_a_r_ohip;

            //   add clmhdr-tot-claim-ar-ohip        to tbl-tot (ss-type, ss-agent, ss-temp1).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaims_mstr_rec.CLMHDR_TOT_CLAIM_AR_OHIP);

            //   add del-ret-offset, ss-cash                 giving ss-temp1.;
            ss_temp1 = del_ret_offset + ss_cash;

            //   add clmhdr-manual-and-tape-paymnts  to tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaims_mstr_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);

            //   add del-ret-offset, ss-nbr                  giving ss-temp1.;
            ss_temp1 = del_ret_offset + ss_nbr;

            //   add 1                               to tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += 1;
        }

        private void sa0_99_exit()
        {
            // Util.Trakker(++ctr, "sa0_99_exit");

            //     exit.;
        }

        private void sa1_find_ss_type()
        {
            // Util.Trakker(++ctr, "sa1_find_ss_type");

            //     if clmhdr-batch-type = "C";
            //     then;
            //ss_type = ss_claims;
            //     else;
            //  if clmhdr-batch-type = "A";
            //       then;
            //         if clmhdr-adj-cd = "A";
            //           then;
            //ss_type = ss_adj_a;
            //      else;
            //                 if clmhdr-adj-cd = "B";
            //           then;
            //ss_type = ss_adj_b;
            //          else;
            //ss_type = ss_adj_r;
            //    else;
            //            if clmhdr-adj-cd = "M";
            //           then;
            //ss_type = ss_pay_m;
            //      else;
            //ss_type = ss_pay_c;


            // if clmhdr-batch-type = "C"  then            
            if (Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C"))
            {
                ss_type = ss_claims;
            }
            // else if clmhdr-batch-type = "A" then            
            else if (Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("A"))
            {
                //         if clmhdr-adj-cd = "A" then            
                if (Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_CD).ToUpper().Equals("A"))
                {
                    ss_type = ss_adj_a;
                }
                //         else if clmhdr-adj-cd = "B" then            
                else if (Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_CD).ToUpper().Equals("B"))
                {
                    ss_type = ss_adj_b;
                }
                else
                {
                    ss_type = ss_adj_r;
                }
            }
            // else if clmhdr-adj-cd = "M" then                        
            else if (Util.Str(objClaims_mstr_rec.CLMHDR_ADJ_CD).ToUpper().Equals("M"))
            {
                ss_type = ss_pay_m;
            }
            else
            {
                ss_type = ss_pay_c;
            }
        }

        private void sa1_99_exit()
        {
            // Util.Trakker(++ctr, "sa1_99_exit");

            //     exit.;
        }

        private void tb0_write_line(int option = 1)
        {
            // Util.Trakker(++ctr, "tb0_write_line");

            //     add  nbr-lines-2-advance                               to      ctr-line.;
            ctr_line += nbr_lines_2_advance;

            // if ctr-line > max-nbr-lines-per-page then
            if (ctr_line > max_nbr_lines_per_page)
            {
                //    perform tc0-print-headings                      thru    tc0-99-exit.;
                tc0_print_headings();
                tc0_99_exit();
            }

            //     write   print-record  from print-line-1    after advancing  nbr-lines-2-advance lines.;
            for (int i = 0; i < nbr_lines_2_advance; i++)
            {
                objPrintFile.print(true);
            }

            objPrint_record.Print_record1 = t2_print_line_grp();   //print_line_1_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //print_line_1 = "";
            MoveSpacesToPrintLine();

            nbr_lines_2_advance = 1;

            if (t2_desc_a.Trim() == "TOTALS")
            {
                t2_total_1 = 0;
                t2_total_2 = 0;
                t2_total_3 = 0;
                t2_total_4 = 0;
                t2_total_5 = 0;
                t2_total_6 = 0;
                t2_total_7 = 0;
                t2_total_8 = 0;
            }
        }

        private void tb0_99_exit()
        {
            // Util.Trakker(++ctr, "tb0_99_exit");

            //     exit.;
        }

        private void tc0_print_headings()
        {
            // Util.Trakker(++ctr, "tc0_print_headings");

            //     add 1                                   to      page-nbr.;
            page_nbr++;

            h1_ped = save_clinic_ped;  // Todo:  9999/99/99    blank when zero.
            h1_page_nbr = page_nbr;

            //     write print-record from header-1 after advancing page.;            
            objPrintFile.PageBreak();
            objPrintFile.print(true);
            objPrint_record.Print_record1 = header_1_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            h5_clinic_nbr = save_clinic_id;

            //     write print-record from h5-head after advancing 2 lines.;            
            objPrintFile.print(true);
            objPrint_record.Print_record1 = h5_head_grp();
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h6-head after advancing 1 line.;            
            objPrintFile.print(true);
            objPrint_record.Print_record1 = h6_head_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from blank-line after advancing 1 line.;
            objPrintFile.print(true);
            objPrint_record.Print_record1 = new string(' ', 132);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);
            ctr_line = 9;
        }

        private void tc0_99_exit()
        {
            // Util.Trakker(++ctr, "tc0_99_exit");

            //     exit.;
        }

        private void tc1_roll_type_tot_to_grand()
        {
            // Util.Trakker(++ctr, "tc1_roll_type_tot_to_grand");

            ss_type_from = ss_type_tot;
            ss_type_to = ss_grand_tot;

            // perform te0-roll-and-zero-totals thru    te0-99-exit;
            //      varying  ss-agent-from;
            //       from  1;
            //       by    1;
            //       until    ss-agent-from > max-nbr-agents + 1.;

            ss_agent_from = 1;
            do
            {
                te0_roll_and_zero_totals();
                te0_99_exit();
                ss_agent_from++;
            } while (ss_agent_from <= max_nbr_agents + 1);

        }

        private void tc1_99_exit()
        {
            // Util.Trakker(++ctr, "tc1_99_exit");

            //     exit.;
        }

        private void te0_roll_and_zero_totals()
        {
            // Util.Trakker(++ctr, "te0_roll_and_zero_totals");

            //     add tbl-tot (ss-type-from, ss-agent-from, 1 )  to tbl-tot (ss-type-to, ss-agent-from, 1 ).;
            tbl_tot[ss_type_to, ss_agent_from, 1] += tbl_tot[ss_type_from, ss_agent_from, 1];
            //     add tbl-tot (ss-type-from, ss-agent-from, 2 )  to tbl-tot (ss-type-to, ss-agent-from, 2 ).;
            tbl_tot[ss_type_to, ss_agent_from, 2] += tbl_tot[ss_type_from, ss_agent_from, 2];
            //     add tbl-tot (ss-type-from, ss-agent-from, 3 )  to tbl-tot (ss-type-to, ss-agent-from, 3 ).;
            tbl_tot[ss_type_to, ss_agent_from, 3] += tbl_tot[ss_type_from, ss_agent_from, 3];
            //     add tbl-tot (ss-type-from, ss-agent-from, 4 )  to tbl-tot (ss-type-to, ss-agent-from, 4 ).;
            tbl_tot[ss_type_to, ss_agent_from, 4] += tbl_tot[ss_type_from, ss_agent_from, 4];
            //     add tbl-tot (ss-type-from, ss-agent-from, 5 )  to tbl-tot (ss-type-to, ss-agent-from, 5 ).;
            tbl_tot[ss_type_to, ss_agent_from, 5] += tbl_tot[ss_type_from, ss_agent_from, 5];
            //     add tbl-tot (ss-type-from, ss-agent-from, 6 )  to tbl-tot (ss-type-to, ss-agent-from, 6 ).;
            tbl_tot[ss_type_to, ss_agent_from, 6] += tbl_tot[ss_type_from, ss_agent_from, 6];
            //     add tbl-tot (ss-type-from, ss-agent-from, 7 )  to tbl-tot (ss-type-to, ss-agent-from, 7 ).;
            tbl_tot[ss_type_to, ss_agent_from, 7] += tbl_tot[ss_type_from, ss_agent_from, 7];
            //     add tbl-tot (ss-type-from, ss-agent-from, 8 )  to tbl-tot (ss-type-to, ss-agent-from, 8 ).;
            tbl_tot[ss_type_to, ss_agent_from, 8] += tbl_tot[ss_type_from, ss_agent_from, 8];

            tbl_tot[ss_type_from, ss_agent_from, 1] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 2] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 3] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 4] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 5] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 6] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 7] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 8] = 0;
        }

        private void te0_99_exit()
        {
            // Util.Trakker(++ctr, "te0_99_exit");

            //     exit.;
        }

        private void tg0_move_vals_to_line()
        {
            // Util.Trakker(++ctr, "tg0_move_vals_to_line");

            //move tbl-tot(ss - type - from, ss - agent, 1)  to t2-detail - 1.
            t2_detail_1 = tbl_tot[ss_type_from, ss_agent, 1];
            //move tbl - tot(ss - type - from, ss - agent, 2)      to t2-detail - 2.\
            t2_detail_2 = tbl_tot[ss_type_from, ss_agent, 2];
            //move tbl - tot(ss - type - from, ss - agent, 3)      to t2-detail - 3.
            t2_detail_3 = tbl_tot[ss_type_from, ss_agent, 3];
            //move tbl - tot(ss - type - from, ss - agent, 4)      to t2-detail - 4.
            t2_detail_4 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 4]);
            //move tbl - tot(ss - type - from, ss - agent, 5)      to t2-detail - 5.
            t2_detail_5 = tbl_tot[ss_type_from, ss_agent, 5];
            //move tbl - tot(ss - type - from, ss - agent, 6)      to t2-detail - 6.
            t2_detail_6 = tbl_tot[ss_type_from, ss_agent, 6];
            //move tbl - tot(ss - type - from, ss - agent, 7)      to t2-detail - 7.
            t2_detail_7 = tbl_tot[ss_type_from, ss_agent, 7];
            //move tbl - tot(ss - type - from, ss - agent, 8)      to t2-detail - 8.
            t2_detail_8 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 8]);

            if (ss_agent != 11)
            {
                t2_total_1 += t2_detail_1;
                t2_total_2 += t2_detail_2;
                t2_total_3 += t2_detail_3;
                t2_total_4 += t2_detail_4;
                t2_total_5 += t2_detail_5;
                t2_total_6 += t2_detail_6;
                t2_total_7 += t2_detail_7;
                t2_total_8 += t2_detail_8;
            }
        }

        private void tg0_99_exit()
        {
            // Util.Trakker(++ctr, "tg0_99_exit");

            //     exit.;
        }

        private void xa0_write_audit_rpt_line(int option = 1)
        {
            // Util.Trakker(++ctr, "xa0_write_audit_rpt_line");

            //     add line-advance                         to      ctr-line.;
            ctr_line += line_advance;

            // if ctr-line > max-nbr-lines-per-page then            
            if (ctr_line > max_nbr_lines_per_page)
            {
                //     perform xb0-print-headings              thru    xb0-99-exit;
                xb0_print_headings();
                xb0_99_exit();
                //     add line-advance                        to      ctr-line.;
                ctr_line += line_advance;
            }

            //     write print-record              from    print-line-1 after advancing  line-advance  lines.
            for (int i = 1; i < line_advance; i++)
            {
                objPrintFile.print(true);
            }

            if (option == 1)
            {
                objPrint_record.Print_record1 = print_line_1_grp();
            }
            else if (option == 2)
            {
                objPrint_record.Print_record1 = print_line_2_grp();
            }
            else if (option == 3)
            {
                objPrint_record.Print_record1 = print_line_3_grp();
            }
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //print_line_1 = "";
            MoveSpacesToPrintLine();
        }

        private void xa0_99_exit()
        {
            // Util.Trakker(++ctr, "xa0_99_exit");

            //     exit.;
        }

        private void xb0_print_headings()
        {
            // Util.Trakker(++ctr, "xb0_print_headings");

            //     add 1                                  to      page-nbr.;
            page_nbr++;

            h1_ped = "0"; // Todo:  9999/99/99    blank when zero.
            h1_page_nbr = page_nbr;

            //     write  print-record             from    header-1 after advancing page.            
            objPrintFile.PageBreak();
            objPrint_record.Print_record1 = header_1_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            ctr_line = 1;
        }

        private void xb0_99_exit()
        {
            // Util.Trakker(++ctr, "xb0_99_exit");

            //     exit.;
        }

        private void xc0_zero_clinic_ctrs()
        {
            // Util.Trakker(++ctr, "xc0_zero_clinic_ctrs");

            ctr_clinic_delcurr_nbr = 0;
            ctr_clinic_delprev_nbr = 0;
            ctr_clinic_delcurr_amt = 0;
            ctr_clinic_delprev_amt = 0;
            ctr_clinic_concurr_nbr = 0;
            ctr_clinic_conprev_nbr = 0;
            ctr_clinic_concurr_amt = 0;
            ctr_clinic_conprev_amt = 0;

        }

        private void xc0_99_exit()
        {
            // Util.Trakker(++ctr, "xc0_99_exit");

            //     exit.;
        }

        private void xe0_obtain_clinic_ped()
        {
            // Util.Trakker(++ctr, "xe0_obtain_clinic_ped");

            objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = save_clinic_id;

            // read iconst-mstr;
            //    invalid key;
            //      err_msg_clinic_id = objIconst_mstr_rec.iconst_clinic_nbr_1_2;
            //      err_ind = 5;
            //      perform za0-common-error    thru za0-99-exit;
            //      go to az0-finalization.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = save_clinic_id
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                err_msg_clinic_id = save_clinic_id.ToString();
                err_ind = 5;
                //      perform za0-common-error    thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-finalization.;
                az0_finalization();
                return;
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            save_clinic_ped = Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY).PadLeft(4, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM).PadLeft(2, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD).PadLeft(2, '0');
        }

        private void xe0_99_exit()
        {
            // Util.Trakker(++ctr, "xe0_99_exit");

            //     exit.;
        }

        private void xx0_increment_batch_nbr()
        {
            // Util.Trakker(++ctr, "xx0_increment_batch_nbr");

            flag_request_complete = "N";

            // if clmdtl-b-batch-number = 999 then;            
            if (Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(5, 3)) == 999)
            {
                tmp_doc_nbr_alpha_grp = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(2, 3);  //objClaims_mstr_dtl_rec.clmdtl_b_doc_nbr;
                tmp_batch_nbr_index[1] = Util.Str(tmp_doc_nbr_alpha_grp[0]);
                tmp_batch_nbr_index[2] = Util.Str(tmp_doc_nbr_alpha_grp[1]);
                tmp_batch_nbr_index[3] = Util.Str(tmp_doc_nbr_alpha_grp[2]);

                //      perform xx1-process-1-doc-position  thru xx1-99-exit;
                //             varying   ss from 3 by -1;
                //             until     ss = 0;
                //                or      flag-request-complete-y;

                ss = 3;
                do
                {
                    xx1_process_1_doc_position();
                    xx1_90_return();
                    ss--;
                } while (ss > 0 && Util.Str(flag_request_complete) != flag_request_complete_y);

                //     objClaims_mstr_dtl_rec.clmdtl_b_doc_nbr = tmp_doc_nbr_alpha;
                objClaims_mstr_rec.CLMHDR_BATCH_NBR = Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2) + tmp_doc_nbr_alpha_grp + Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 3);  // Note: watch the value !!!
                for (int i = 0; i < tmp_batch_nbr_index.Length; i++)
                {
                    tmp_doc_nbr_alpha_grp += tmp_batch_nbr_index[i];
                }

                Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Insert(2, Util.Str(tmp_doc_nbr_alpha_grp).PadRight(8, ' ').Substring(0, 3));   // todo: Watch out the value. This from array to a field value... This should only insert 3 characters.

                //     objClaims_mstr_dtl_rec.clmdtl_b_batch_number = 000;
                Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).Insert(5, "000");
            }
            else
            {
                //         add 1                           to      clmdtl-b-batch-number-numeric.;
                int tmp = Util.NumInt(Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(5, 3));
                tmp++;
                //Util.Str(objClaims_mstr_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Insert(5, Util.Str(tmp).PadLeft(3, '0'));
                objClaims_mstr_rec.CLMHDR_BATCH_NBR = Util.Str(objClaim_detail_rec.CLMDTL_BATCH_NBR).Substring(0, 5) + Util.Str(tmp.ToString()).PadLeft(3, '0');
            }
        }

        private void xx0_99_exit()
        {
            // Util.Trakker(++ctr, "xx0_99_exit");

            //    exit.;
        }

        private void xx1_process_1_doc_position()
        {
            // Util.Trakker(++ctr, "xx1_process_1_doc_position");

            // if tmp-batch-nbr-index(ss) = "0"  then;            
            if (tmp_batch_nbr_index[ss] == "0")
            {
                tmp_batch_nbr_index[ss] = "1";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "1" then;            
            else if (tmp_batch_nbr_index[ss] == "1")
            {
                tmp_batch_nbr_index[ss] = "2";
                //        go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "2" then            
            else if (tmp_batch_nbr_index[ss] == "2")
            {
                tmp_batch_nbr_index[ss] = "3";
                //        go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "3" then            
            else if (tmp_batch_nbr_index[ss] == "3")
            {
                tmp_batch_nbr_index[ss] = "4";
                //        go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "4" then            
            else if (tmp_batch_nbr_index[ss] == "4")
            {
                tmp_batch_nbr_index[ss] = "5";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            //else if tmp-batch-nbr-index(ss) = "5" then            
            else if (tmp_batch_nbr_index[ss] == "5")
            {
                tmp_batch_nbr_index[ss] = "6";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "6"  then            
            else if (tmp_batch_nbr_index[ss] == "6")
            {
                tmp_batch_nbr_index[ss] = "7";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "7" then            
            else if (tmp_batch_nbr_index[ss] == "7")
            {
                tmp_batch_nbr_index[ss] = "8";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "8" then            
            else if (tmp_batch_nbr_index[ss] == "8")
            {
                tmp_batch_nbr_index[ss] = "9";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "9"  then            
            else if (tmp_batch_nbr_index[ss] == "9")
            {
                tmp_batch_nbr_index[ss] = "A";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "A" then            
            else if (tmp_batch_nbr_index[ss] == "A")
            {
                tmp_batch_nbr_index[ss] = "B";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            //else if tmp-batch-nbr-index(ss) = "B" then            
            else if (tmp_batch_nbr_index[ss] == "B")
            {
                tmp_batch_nbr_index[ss] = "C";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "C" then            
            else if (tmp_batch_nbr_index[ss] == "C")
            {
                tmp_batch_nbr_index[ss] = "D";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "D" then;            
            else if (tmp_batch_nbr_index[ss] == "D")
            {
                tmp_batch_nbr_index[ss] = "E";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "E" then            
            else if (tmp_batch_nbr_index[ss] == "E")
            {
                tmp_batch_nbr_index[ss] = "F";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "F"  then            
            else if (tmp_batch_nbr_index[ss] == "F")
            {
                tmp_batch_nbr_index[ss] = "G";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "G" then            
            else if (tmp_batch_nbr_index[ss] == "G")
            {
                tmp_batch_nbr_index[ss] = "H";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "H"  then            
            else if (tmp_batch_nbr_index[ss] == "H")
            {
                tmp_batch_nbr_index[ss] = "I";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "I" then            
            else if (tmp_batch_nbr_index[ss] == "I")
            {
                tmp_batch_nbr_index[ss] = "J";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "J" then            
            else if (tmp_batch_nbr_index[ss] == "J")
            {
                tmp_batch_nbr_index[ss] = "K";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else  if tmp-batch-nbr-index(ss) = "K"  then            
            else if (tmp_batch_nbr_index[ss] == "K")
            {
                tmp_batch_nbr_index[ss] = "L";
                //      go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "L"  then            
            else if (tmp_batch_nbr_index[ss] == "L")
            {
                tmp_batch_nbr_index[ss] = "M";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            //  else  if tmp-batch-nbr-index(ss) = "M"  then            
            else if (tmp_batch_nbr_index[ss] == "M")
            {
                tmp_batch_nbr_index[ss] = "N";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "N" then            
            else if (tmp_batch_nbr_index[ss] == "N")
            {
                tmp_batch_nbr_index[ss] = "O";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "O" then;            
            else if (tmp_batch_nbr_index[ss] == "O")
            {
                tmp_batch_nbr_index[ss] = "P";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "P"  then            
            else if (tmp_batch_nbr_index[ss] == "P")
            {
                tmp_batch_nbr_index[ss] = "Q";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "B"  then            
            else if (tmp_batch_nbr_index[ss] == "B")
            {
                tmp_batch_nbr_index[ss] = "R";
                //        go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "R" then            
            else if (tmp_batch_nbr_index[ss] == "R")
            {
                tmp_batch_nbr_index[ss] = "S";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            //else if tmp-batch-nbr-index(ss) = "S" then            
            else if (tmp_batch_nbr_index[ss] == "S")
            {
                tmp_batch_nbr_index[ss] = "T";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "T"  then            
            else if (tmp_batch_nbr_index[ss] == "T")
            {
                tmp_batch_nbr_index[ss] = "U";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "U"  then            
            else if (tmp_batch_nbr_index[ss] == "U")
            {
                tmp_batch_nbr_index[ss] = "V";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else if tmp-batch-nbr-index(ss) = "V" then            
            else if (tmp_batch_nbr_index[ss] == "V")
            {
                tmp_batch_nbr_index[ss] = "W";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else  if tmp-batch-nbr-index(ss) = "W"  then            
            else if (tmp_batch_nbr_index[ss] == "W")
            {
                tmp_batch_nbr_index[ss] = "X";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else  if tmp-batch-nbr-index(ss) = "X"   then            
            else if (tmp_batch_nbr_index[ss] == "X")
            {
                tmp_batch_nbr_index[ss] = "Y";
                //         go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else  if tmp-batch-nbr-index(ss) = "Y"  then;            
            else if (tmp_batch_nbr_index[ss] == "Y")
            {
                tmp_batch_nbr_index[ss] = "Z";
                //       go to xx1-90-return;
                xx1_90_return();
                return;
            }
            // else  if tmp-batch-nbr-index(ss) = "Z" then            
            else if (tmp_batch_nbr_index[ss] == "Z")
            {
                tmp_batch_nbr_index[ss] = "0";
                //     go to xx0-99-exit.;
                xx1_90_return();
                return;
            }
        }

        private void xx1_90_return()
        {
            // Util.Trakker(++ctr, "xx1_90_return");

            flag_request_complete = "Y";
        }

        private void xx1_99_exit()
        {

            //     exit.;
        }

        private void za0_common_error()
        {
            // Util.Trakker(++ctr, "za0_common_error");

            e1_error_msg = err_msg[err_ind];
            //     display e1-error-line.;
            if (err_ind == 5)
            {
                Console.WriteLine(e1_error_word.PadRight(13, ' ') + e1_error_msg + Util.Str(err_msg_clinic_id));
            }
            else if (err_ind == 9)
            {
                Console.WriteLine(e1_error_word.PadRight(13, ' ') + e1_error_msg + Util.Str(bkey_clmdtl_err_msg));
            }
            else if (err_ind == 10)
            {
                Console.WriteLine(e1_error_word.PadRight(13, ' ') + e1_error_msg + Util.Str(bkey_clmhdr_err_msg));
            }
            else if (err_ind == 11)
            {
                Console.WriteLine(e1_error_word.PadRight(13, ' ') + e1_error_msg + Util.Str(pkey_clm_err_msg));
            }
            else
            {
                Console.WriteLine(e1_error_word.PadRight(13, ' ') + e1_error_msg);
            }
            //     perform za1-print-err-in-rpt thru    za1-99-exit.;
            za1_print_err_in_rpt();
            za1_99_exit();

            //     display confirm.;
        }

        private void za0_99_exit()
        {
            // Util.Trakker(++ctr, "za0_99_exit");

            //     exit.;
        }

        private void za1_print_err_in_rpt()
        {
            // Util.Trakker(++ctr, "za1_print_err_in_rpt");

            e1_error_line_grp = Util.Str(e1_error_word).PadRight(13, ' ') + Util.Str(e1_error_msg); // .PadRight(67, ' ');
            //print_line_1 = e1_error_line;
            l1_msg = Util.Str(e1_error_line_grp).PadRight(55, ' ');
            //print_line_1_grp = l1_msg + Util.Str(l1_slash_1) + Util.Str(l1_mm).PadLeft(2, '0') + l1_slash_2 + Util.Str(l1_dd).PadLeft(2, '0') + new string(' ', 1) + Util.Str(l1_hrs).PadLeft(2, '0') + l1_colon + Util.Str(l1_min).PadLeft(2, '0') + new string(' ', 61);

            line_advance = 4;
            //     perform xa0-write-audit-rpt-line       thru    xa0-99-exit.;
            xa0_write_audit_rpt_line(1);
            xa0_99_exit();
        }

        private void za1_99_exit()
        {
            // Util.Trakker(++ctr, "za1_99_exit");
            //     exit.;
        }

        private void zb0_print_totals_summary()
        {
            // Util.Trakker(++ctr, "zb0_print_totals_summary");

            ctr_line = 98;
            sw_printed_bat_type = "N";
            sw_printed_adj_type = "N";

            //     perform zc0-process-batch-totals        thru    zc0-99-exit;
            //          varying ss-type;
            //          from  1;
            //          by    1;
            //          until   ss-type > max-nbr-types.;

            ss_type = 1;
            do
            {
                zc0_process_batch_totals();
                zc0_99_exit();
                ss_type++;
            } while (ss_type <= max_nbr_types);

            ss_type = ss_grand_tot;

            //     perform zc0-process-batch-totals thru    zc0-99-exit.;
            zc0_process_batch_totals();
            zc0_99_exit();
        }
        private void zb0_99_exit()
        {
            // Util.Trakker(++ctr, "zb0_99_exit");

            //     exit.;
        }

        private void zc0_process_batch_totals()
        {
            // Util.Trakker(++ctr, "zc0_process_batch_totals");

            //     perform zd0-prt-agent-vals-and-sum  thru    zd0-99-exit;
            //          varying ss-agent;
            //         from  1;
            //          by    1;
            //          until    ss-agent > max-nbr-agents.;

            ss_agent = 1;
            do
            {
                zd0_prt_agent_vals_and_sum();
                zd0_99_exit();
                ss_agent++;
            } while (ss_agent <= max_nbr_agents);

            // if ss-type not = ss-claims and ss-grand-tot then       
            if (ss_type != ss_claims && ss_type != ss_grand_tot)
            {
                // if sw-printed-adj-type = "Y" then         
                if (Util.Str(sw_printed_adj_type).ToUpper().Equals("Y"))
                {
                    t2_desc_a = "             ";
                    t2_desc_b = "TOTAL";
                    t2_desc_grp = "             TOTAL";
                    ss_type_from = ss_type;
                    ss_agent = ss_agent_tot;
                    //    perform tg0-move-vals-to-line       thru    tg0-99-exit;
                    tg0_move_vals_to_line();
                    tg0_99_exit();
                    //   perform tb0-write-line              thru    tb0-99-exit;
                    tb0_write_line();
                    tb0_99_exit();
                }
                else
                {
                    //         next sentence;
                }
            }
            else
            {
                //        next sentence.;
            }

            sw_printed_adj_type = "N";

            // if ss-type not = ss-grand-tot then            
            if (ss_type != ss_grand_tot)
            {
                ss_type_from = ss_type;
                ss_type_to = ss_type_tot;
                //       perform te0-roll-and-zero-totals              thru    te0-99-exit;
                //              varying ss-agent-from;
                //            from  1;
                //          by    1;
                //          until   ss-agent-from > max-nbr-agents + 1.;

                ss_agent_from = 1;
                do
                {
                    te0_roll_and_zero_totals();
                    te0_99_exit();
                    ss_agent_from++;
                } while (ss_agent_from <= (max_nbr_agents + 1));
            }


            // if ss-type = ss-claims or ss-adj-r  or ss-pay-c or ss-grand-tot then            
            //     if sw-printed-bat-type = "Y" then            
            //         sw_printed_bat_type = "N";
            //         nbr_lines_2_advance = 2;
            //         t2_desc = " TOTALS";
            //            if ss-type = ss-grand-tot then            
            //                ss_type_from = ss_grand_tot;
            //                ss_agent = ss_agent_tot;
            //                 perform tg0-move-vals-to-line   thru    tg0-99-exit;
            //                 perform tb0-write-line          thru    tb0-99-exit;
            //             else;
            //                   ss_type_from = ss_type_tot;
            //                   ss_agent = ss_agent_tot;
            //                   perform tg0-move-vals-to-line   thru    tg0-99-exit;
            //                   perform tb0-write-line          thru    tb0-99-exit;
            //                   perform tc1-roll-type-tot-to-grand;
            //                                               thru    tc1-99-exit;
            // elseif ss-type not = ss-grand-tot then                                        // todo:   verify the structure. is it correct?  ... ??? 
            //                 perform tc1-roll-type-tot-to-grand;
            //                                               thru    tc1-99-exit.;


            // if ss-type = ss-claims or ss-adj-r  or ss-pay-c or ss-grand-tot then            
            if (ss_type == ss_claims || ss_type == ss_adj_r || ss_type == ss_pay_c || ss_type == ss_grand_tot)
            {
                //  if sw-printed-bat-type = "Y" then            
                if (Util.Str(sw_printed_bat_type).ToUpper().Equals("Y"))
                {
                    sw_printed_bat_type = "N";
                    nbr_lines_2_advance = 2;
                    t2_desc_a = "    TOTALS";
                    t2_desc_b = "     ";
                    t2_desc_grp = "    TOTALS";
                    //         if ss-type = ss-grand-tot then            
                    if (ss_type == ss_grand_tot)
                    {
                        ss_type_from = ss_grand_tot;
                        ss_agent = ss_agent_tot;
                        //  perform tg0-move-vals-to-line   thru    tg0-99-exit;
                        tg0_move_vals_to_line();
                        tg0_99_exit();
                        //   perform tb0-write-line          thru    tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();
                    }
                    else
                    {
                        ss_type_from = ss_type_tot;
                        ss_agent = ss_agent_tot;
                        //  perform tg0-move-vals-to-line   thru    tg0-99-exit;
                        tg0_move_vals_to_line();
                        tg0_99_exit();

                        //  perform tb0-write-line          thru    tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();

                        //  perform tc1-roll-type-tot-to-grand thru    tc1-99-exit;
                        tc1_roll_type_tot_to_grand();
                        tc1_99_exit();
                    }
                }
            }
            // elseif ss-type not = ss-grand-tot then            
            else if (ss_type != ss_grand_tot)
            {
                //  perform tc1-roll-type-tot-to-grand  thru    tc1-99-exit.
                tc1_roll_type_tot_to_grand();
                tc1_99_exit();
            }

        }

        private void zc0_99_exit()
        {
            // Util.Trakker(++ctr, "zc0_99_exit");

            //     exit.;
        }

        private void zd0_prt_agent_vals_and_sum()
        {
            // Util.Trakker(++ctr, "zd0_prt_agent_vals_and_sum");

            //     add ss-nbr, ss-offset               giving ss-temp1.;
            ss_temp1 = ss_nbr + ss_offset;

            //  if  tbl-tot (ss-type, ss-agent, ss-nbr) = zero and tbl-tot (ss-type, ss-agent, ss-temp1 ) = zero then            
            if (tbl_tot[ss_type, ss_agent, ss_nbr] == 0 && tbl_tot[ss_type, ss_agent, ss_temp1] == 0)
            {
                //     go to zd0-99-exit.;
                zd0_99_exit();
                return;
            }

            t2_desc_a = "";
            t2_desc_b = "";
            t2_desc_grp = "";

            // if sw-printed-bat-type = "N" then            
            if (Util.Str(sw_printed_bat_type).ToUpper().Equals("N"))
            {
                sw_printed_bat_type = "Y";
                t2_desc_a = desc_bat_type[ss_type];
                nbr_lines_2_advance = 3;
            }

            //  if sw-printed-adj-type = "N" then;            
            if (Util.Str(sw_printed_adj_type).ToUpper().Equals("N"))
            {
                sw_printed_adj_type = "Y";
                t2_desc_b = desc_adj_type[ss_type];
            }

            t2_dash = "-";
            //     subtract 1                          from    ss-agent;
            //                                         giving  t2-agent-cd.;
            t2_agent_cd = ss_agent - 1;

            ss_type_from = ss_type;
            //  perform tg0-move-vals-to-line  thru    tg0-99-exit.;
            tg0_move_vals_to_line();
            tg0_99_exit();

            //     perform tb0-write-line          thru    tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            // if ss-type = ss-grand-tot then;            
            if (ss_type == ss_grand_tot)
            {
                //     go to zd0-99-exit.;
                zd0_99_exit();
                return;
            }

            //     add tbl-tot (ss-type, ss-agent, 1 )              to tbl-tot (ss-type    ,ss-agent-tot, 1 ).;
            tbl_tot[ss_type, ss_agent_tot, 1] += tbl_tot[ss_type, ss_agent, 1];
            //     add tbl-tot (ss-type, ss-agent, 2 )              to tbl-tot (ss-type    ,ss-agent-tot, 2 ).;
            tbl_tot[ss_type, ss_agent_tot, 2] += tbl_tot[ss_type, ss_agent, 2];
            //     add tbl-tot (ss-type, ss-agent, 3 )              to tbl-tot (ss-type    ,ss-agent-tot, 3 ).;
            tbl_tot[ss_type, ss_agent_tot, 3] += tbl_tot[ss_type, ss_agent, 3];
            //     add tbl-tot (ss-type, ss-agent, 4 )              to tbl-tot (ss-type    ,ss-agent-tot, 4 ).;
            tbl_tot[ss_type, ss_agent_tot, 4] += tbl_tot[ss_type, ss_agent, 4];
            //     add tbl-tot (ss-type, ss-agent, 5 )              to tbl-tot (ss-type    ,ss-agent-tot, 5 ).;
            tbl_tot[ss_type, ss_agent_tot, 5] += tbl_tot[ss_type, ss_agent, 5];
            //     add tbl-tot (ss-type, ss-agent, 6 )              to tbl-tot (ss-type    ,ss-agent-tot, 6 ).;
            tbl_tot[ss_type, ss_agent_tot, 6] += tbl_tot[ss_type, ss_agent, 6];
            //     add tbl-tot (ss-type, ss-agent, 7 )              to tbl-tot (ss-type    ,ss-agent-tot, 7 ).;
            tbl_tot[ss_type, ss_agent_tot, 7] += tbl_tot[ss_type, ss_agent, 7];
            //     add tbl-tot (ss-type, ss-agent, 8 )              to tbl-tot (ss-type    ,ss-agent-tot, 8 ).;
            tbl_tot[ss_type, ss_agent_tot, 8] += tbl_tot[ss_type, ss_agent, 8];
        }

        private void zd0_99_exit()
        {
            // Util.Trakker(++ctr, "zd0_99_exit");

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate()
        {
            // Util.Trakker(++ctr, "y2k_default_sysdate");

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {
            // Util.Trakker(++ctr, "y2k_default_sysdate_exit");

            //     exit.;
        }

        private void MoveSpacesToPrintLine()
        {
            // Util.Trakker(++ctr, "MoveSpacesToPrintLine");

            l1_msg = "";
            l1_yy = 0;
            l1_slash_1 = "";
            l1_mm = 0;
            l1_slash_2 = "";
            l1_dd = 0;
            l1_hrs = 0;
            l1_colon = "";
            l1_min = 0;

            l2_msg = "";
            l2_ctr = 0;

            l3_msg = "";
            l3_amt = 0;


        }

        private string audit_line_grp()
        {
            // Util.Trakker(++ctr, "audit_line_grp");

            return new string(' ', 10) +
                   Util.Str(audit_title).PadRight(60) +
                   new string(' ', 10) +
                   Util.Str(audit_count).PadLeft(10, '0') +
                   new string(' ', 41);
        }

        private string sel_report_date_grp()
        {
            // Util.Trakker(++ctr, "sel_report_date_grp");

            return Util.Str(report_yy).PadLeft(4, '0') +
                   "/" +
                   Util.Str(report_mm).PadLeft(2, '0') +
                   "/" +
                   Util.Str(report_dd).PadLeft(2, '0');
        }

        private string run_date_grp()
        {
            // Util.Trakker(++ctr, "run_date_grp");

            return Util.Str(run_yy).PadLeft(4, '0') +
                    "/" +
                    Util.Str(run_mm).PadLeft(2, '0') +
                    "/" +
                    Util.Str(run_dd).PadLeft(2, '0');
        }

        private string header_1_grp()
        {
            // Util.Trakker(++ctr, "header_1_grp");

            if (Util.NumInt(Util.Str(h1_ped).PadRight(4).Substring(0, 4)) == 0)
            {
                h1_ped = string.Empty;
            }
            else
            {
                h1_ped = h1_ped.Substring(0, 4) + "/" + h1_ped.Substring(4, 2) + "/" + h1_ped.Substring(6, 2);
            }

            return "R071    P.E.D. ".PadRight(15) +
                   Util.Str(h1_ped).PadRight(10) +    // blank when zero
                   new string(' ', 15) +
                   "CLAIMS MASTER CONVERSION VERIFICATION REPORT".PadRight(57) +
                   "RUN DATE".PadRight(9) +
                   Util.Str(h1_run_date).PadRight(10) +
                   new string(' ', 8) +
                   "PAGE".PadRight(5) +
                   Util.ImpliedIntegerFormat("#0", h1_page_nbr, 3, false);
        }

        private string print_line_1_grp()
        {
            // Util.Trakker(++ctr, "print_line_1_grp");

            if (l1_msg.Equals("PROGRAM STATISTICS"))
            {
                return Util.Str(l1_msg).PadRight(55);
            }
            else if (l1_msg.Equals("ELAPSED TIME"))
            {
                return Util.Str(l1_msg).PadRight(55) +
                      new string(' ', 4) +
                      new string(' ', 1) +
                      new string(' ', 2) +
                      new string(' ', 1) +
                      new string(' ', 2) +
                      new string(' ', 1) +
                      Util.Str(l1_hrs).PadLeft(2, '0') +
                      Util.Str(l1_colon).PadRight(1) +
                      Util.Str(l1_min).PadLeft(2, '0') +
                      new string(' ', 61);
            }
            else if (l1_msg.Equals("G R A N D   T O T A L S"))
            {
                return Util.Str(l1_msg).PadRight(55);
            }
            else if (l1_msg.Equals("CLINIC NUMBER"))
            {
                return Util.Str(l1_msg).PadRight(55) +
                       Util.Str(l1_yy).PadLeft(4, '0');
            }
            else if (l1_msg.Equals("Core Count Total Details"))
            {
                return Util.Str(l1_msg).PadRight(55) +
                    Util.Str(ctr_claims_a);
            }
            else if (l1_msg.Equals("Core Count match if"))
            {
                return Util.Str(l1_msg).PadRight(55) +
                    Util.Str(ctr_claims_b);
            }
            else if (l1_msg.Equals("Core Count else if"))
            {
                return Util.Str(l1_msg).PadRight(55) +
                    Util.Str(ctr_claims_c);
            }
            else
            {
                return Util.Str(l1_msg).PadRight(55) +
                       Util.Str(l1_yy).PadLeft(4, '0') +
                       Util.Str(l1_slash_1).PadRight(1) +
                       Util.Str(l1_mm).PadLeft(2, '0') +
                       Util.Str(l1_slash_2).PadRight(1) +
                       Util.Str(l1_dd).PadLeft(2, '0') +
                       new string(' ', 1) +
                       Util.Str(l1_hrs).PadLeft(2, '0') +
                       Util.Str(l1_colon).PadRight(1) +
                       Util.Str(l1_min).PadLeft(2, '0') +
                       new string(' ', 61);
            }
        }

        private string print_line_2_grp()
        {
            // Util.Trakker(++ctr, "print_line_2_grp");

            return Util.Str(l2_msg).PadRight(55) +
                   Util.ImpliedIntegerFormat("#,0", l2_ctr, 11, false) +
                   new string(' ', 66);
        }

        private string print_line_3_grp()
        {
            // Util.Trakker(++ctr, "print_line_3_grp");

            return Util.Str(l3_msg).PadRight(55) +
                   Util.ImpliedDecimalFormat("#,0.00", l3_amt, 2, 15) +
                   new string(' ', 62);
        }

        private string t2_print_line_grp()
        {
            // Util.Trakker(++ctr, "t2_print_line_grp");

            if (t2_desc_a.Equals("    TOTALS"))
            {
                if (t2_dash.Contains("-"))
                {
                    t2_dash = String.Empty;
                }
                t2_agent_cd = 0;

                return Util.Str(t2_desc_a).PadRight(13) +
                       Util.Str(t2_desc_b).PadRight(5) +
                       Util.Str(t2_dash).PadRight(1) +
                       new string(' ', 1) +
                       Util.BlankWhenZero(t2_agent_cd, 1) +
                       new string(' ', 2) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_total_1, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_total_2, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_total_3, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedIntegerFormat("#,0", t2_total_4, 8, false, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_total_5, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_total_6, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_total_7, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedIntegerFormat("#,0", t2_total_8, 8, false, true) +
                       new string(' ', 4);
            }
            else if (t2_desc_b.Equals("TOTAL") && t2_dash.Contains("-"))
            {
                t2_dash = String.Empty;
                t2_agent_cd = 0;

                return Util.Str(t2_desc_a).PadRight(13) +
                       Util.Str(t2_desc_b).PadRight(5) +
                       Util.Str(t2_dash).PadRight(1) +
                       new string(' ', 4) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_1, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_2, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_3, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedIntegerFormat("#,0", t2_detail_4, 8, false, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_5, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_6, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_7, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedIntegerFormat("#,0", t2_detail_8, 8, false, true) +
                       new string(' ', 4);
            }
            else
            {

                return Util.Str(t2_desc_a).PadRight(13) +
                       Util.Str(t2_desc_b).PadRight(5) +
                       Util.Str(t2_dash).PadRight(1) +
                       new string(' ', 1) +
                       Util.Str(t2_agent_cd).PadLeft(1, '0') +
                       new string(' ', 2) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_1, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_2, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_3, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedIntegerFormat("#,0", t2_detail_4, 8, false, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_5, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_6, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#,0.00", t2_detail_7, 2, 14, true, true) +
                       new string(' ', 1) +
                       Util.ImpliedIntegerFormat("#,0", t2_detail_8, 8, false, true) +
                       new string(' ', 4);
            }
        }

        private string h5_head_grp()
        {
            // Util.Trakker(++ctr, "h5_head_grp");

            return new string(' ', 2) +
                  "CLINIC".PadRight(8) +
                  Util.Str(h5_clinic_nbr).PadLeft(2, '0') +
                  new string(' ', 17) +
                  "-----------".PadRight(11) +
                  "WITHIN - WRITEOFF RANGE".PadRight(23) +
                  "-------------".PadRight(20) +
                  "--------------".PadRight(14) +
                  "OUTSIDE - WRITEOFF RANGE---------".PadRight(35);
        }

        private string h6_head_grp()
        {
            // Util.Trakker(++ctr, "h6_head_grp");

            return new string(' ', 17) +
                   "AGENT".PadRight(12) +
                   "OMA AMT".PadRight(14) +
                   "OHIP AMT".PadRight(15) +
                   "CASH AMT".PadRight(15) +
                   "NBR".PadRight(10) +
                   "OMA AMT".PadRight(14) +
                   "OHIP AMT".PadRight(15) +
                   "CASH AMT".PadRight(15) +
                   "NBR".PadRight(5);
        }

        #endregion
    }
}

