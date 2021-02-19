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
    public class R004_cycleViewModel : CommonFunctionScr
    {

        public R004_cycleViewModel()
        {

        }

        #region FD Section
        // FD: print_file
        private Print_record objPrint_record = null;
        private ObservableCollection<Print_record> Print_record_Collection;

        // FD: batch_ctrl_file	Copy : f001_batch_control_file.fd
        private F001_BATCH_CONTROL_FILE objBatctrl_rec = null;
        private ObservableCollection<F001_BATCH_CONTROL_FILE> Batctrl_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private Claims_mstr_rec objClaims_mstr_rec = null;
        private ObservableCollection<Claims_mstr_rec> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private Claims_mstr_dtl_rec objClaims_mstr_dtl_rec = null;
        private ObservableCollection<Claims_mstr_dtl_rec> Claims_mstr_dtl_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        // private F002_CLAIMS_MSTR_HDR objClaim_header_rec = null;
        // private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claim_header_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_DTL objClaim_detail_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claim_detail_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        private ReportPrint objPrintFile = null;
        private SqlConnection objConn;

        #endregion

        #region Properties
        /* private string _common_status_file;
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
         } */

        private int _ctr_batctrl_file_reads;
        public int ctr_batctrl_file_reads
        {
            get
            {
                return _ctr_batctrl_file_reads;
            }
            set
            {
                if (_ctr_batctrl_file_reads != value)
                {
                    _ctr_batctrl_file_reads = value;
                    RaisePropertyChanged("ctr_batctrl_file_reads");
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

        private int _iconst_clinic_cycle_nbr;
        public int iconst_clinic_cycle_nbr
        {
            get
            {
                return _iconst_clinic_cycle_nbr;
            }
            set
            {
                if (_iconst_clinic_cycle_nbr != value)
                {
                    _iconst_clinic_cycle_nbr = value;
                    RaisePropertyChanged("iconst_clinic_cycle_nbr");
                }
            }
        }

        private string _iconst_clinic_name;
        public string iconst_clinic_name
        {
            get
            {
                return _iconst_clinic_name;
            }
            set
            {
                if (_iconst_clinic_name != value)
                {
                    _iconst_clinic_name = value;
                    _iconst_clinic_name = _iconst_clinic_name.ToUpper();
                    RaisePropertyChanged("iconst_clinic_name");
                }
            }
        }

        private string _iconst_clinic_nbr_1_2;
        public string iconst_clinic_nbr_1_2
        {
            get
            {
                return _iconst_clinic_nbr_1_2;
            }
            set
            {
                if (_iconst_clinic_nbr_1_2 != value)
                {
                    _iconst_clinic_nbr_1_2 = value;
                    _iconst_clinic_nbr_1_2 = _iconst_clinic_nbr_1_2.ToUpper();
                    RaisePropertyChanged("iconst_clinic_nbr_1_2");
                }
            }
        }

        private string _iconst_date_period_end_dd;
        public string iconst_date_period_end_dd
        {
            get
            {
                return _iconst_date_period_end_dd;
            }
            set
            {
                if (_iconst_date_period_end_dd != value)
                {
                    _iconst_date_period_end_dd = value;
                    _iconst_date_period_end_dd = _iconst_date_period_end_dd.ToUpper();
                    RaisePropertyChanged("iconst_date_period_end_dd");
                }
            }
        }

        private string _iconst_date_period_end_mm;
        public string iconst_date_period_end_mm
        {
            get
            {
                return _iconst_date_period_end_mm;
            }
            set
            {
                if (_iconst_date_period_end_mm != value)
                {
                    _iconst_date_period_end_mm = value;
                    _iconst_date_period_end_mm = _iconst_date_period_end_mm.ToUpper();
                    RaisePropertyChanged("iconst_date_period_end_mm");
                }
            }
        }

        private string _iconst_date_period_end_yy;
        public string iconst_date_period_end_yy
        {
            get
            {
                return _iconst_date_period_end_yy;
            }
            set
            {
                if (_iconst_date_period_end_yy != value)
                {
                    _iconst_date_period_end_yy = value;
                    _iconst_date_period_end_yy = _iconst_date_period_end_yy.ToUpper();
                    RaisePropertyChanged("iconst_date_period_end_yy");
                }
            }
        }

        /*private string _print_file_name;
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

        /*private int _ws_reply;
        public int ws_reply
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
                    RaisePropertyChanged("ws_reply");
                }
            }
        } */


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name = "r004_c";
        private string option;
        private int max_nbr_lines = 60;
        private int ctr_lines = 90;
        private int nbr_lines_2_advance;
        private int page_ctr;
        private string ws_i_o_pat_ind;
        private string ws_reply;
        private decimal batch_total = 0;
        private decimal batch_diff = 0;
        private decimal ws_fee_ohip;
        private int ws_nbr_serv;
        private int nbr_rec_processed;
        private decimal ws_rev_calcd = 0;
        private decimal rev_calcd_total = 0;
        private decimal update_amt_total = 0;
        private decimal diff_total = 0;
        private string hold_clmhdr_batch_nbr;
        private int hold_clmhdr_claim_nbr;
        private string ws_doctor_nbr;
        private string const_mstr_rec_nbr;
        private string feedback_claims_mstr;
        private string feedback_batctrl_file;
        private string feedback_iconst_mstr;
        private string blank_line = "";
        private int ws_period_end;
        private string eof_batctrl_file = "N";
        private string eof_claims_dtl = "N";
        private string eof_claims_mstr = "N";
        private string eof_work_file = "N";
        private string new_header = "N";
        private int sub1 = 0;
        private string common_status_file;
        private string status_cobol_batctrl_file = "0";
        private string status_cobol_claims_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_prt_file = "0";
        private string status_sort_file;
        private int hold_clinic_nbr;
        private int claims_occur;

        private string tmp_doc_nbr_alpha_grp;
        private string[] tmp_batch_nbr_index = new string[9];
        private string flag_request_complete;
        private string flag_request_complete_y = "Y";
        private string flag_request_complete_n = "N";
        private string flag_rec;
        private string valid_rec = "Y";
        private string invalid_rec = "N";

        private string tbl_totals_grp;
        private string[] tbl_bat_type_and_tots = new string[9];
        private string[,] tbl_agent_and_sums = new string[9, 12];
        private decimal[,,] tbl_tot = new decimal[9, 12, 11];

        private string tbl_totals_variable_ss_grp;
        private int ss_temp1;
        private int ss_type;
        private int ss_agent;
        private int ss_item;
        private int ss_type_from;
        private int ss_type_to;
        private int ss_agent_from;
        private int ss_agent_to;
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
        private int ss_batctrl_offset = 0;
        private int ss_clmhdr_offset = 4;
        private int batctrl_clm_offset;

        private string tbl_fin_tot_desc_grp;
        private string fin_tot_descs_grp;
        //private string filler = "CLINIC 'A' ADJUST.";
        //private string filler = "CLINIC 'C' PAYMENT";
        private string fin_tot_desc_r_grp;
        private string[] fin_total_desc = new string[3];
        private string[] fin_tot_desc = { "", "CLINIC 'A' ADJUST.", "CLINIC 'C' PAYMENT" };

        private string ss_fin_tots_grp;
        private int ss_a = 1;
        private int ss_c = 2;
        private int ss;

        private string tbl_fin_tots_grp;
        private string[] fin_tots = new string[3];
        private decimal[] fin_tot_a_r = new decimal[3];
        private decimal[] fin_tot_rev = new decimal[3];
        private decimal[] fin_tot_cash = new decimal[3];
        private int[] fin_tot_nbr = new int[3];

        private string tbl_batch_type_desciptions_grp;
        private string tbl_batch_type_descs_grp;
        /*private string filler = "claims          ";
        private string filler = "adjustments- 'a'";
        private string filler = "adjustments- 'b'";
        private string filler = "adjustments- 'r'";
        private string filler = "PAYMENTS   - 'M'";
        private string filler = "PAYMENTS   - 'C'";
        private string filler = "                ";
        private string filler = "GRAND TOTALS    ";*/
        private string tbl_batch_type_descs_r_grp;
        private string[] batch_descs = new string[9];
        private string[] desc_bat_type = { "", "CLAIMS       ", "ADJUSTMENTS- ", "ADJUSTMENTS- ", "ADJUSTMENTS- ", "PAYMENTS   - ", "PAYMENTS   - ", "             ", "GRAND TOTALS " };
        private string[] desc_adj_type = { "", "     ", "'A'  ", "'B'  ", "'R'  ", "'M'  ", "'C'  ", "     ", "     " };
        private string sw_printed_bat_type;
        private string sw_printed_adj_type;

        private string final_totals_grp;
        private decimal fin_tot_1;
        private decimal fin_tot_2;
        private decimal fin_tot_3;
        private decimal fin_tot_4;
        private decimal fin_tot_5;
        private decimal fin_tot_6;
        private decimal fin_tot_7;
        private decimal fin_tot_8;
        private decimal fin_tot_a_a_r;
        private decimal fin_tot_a_rev;
        private decimal fin_tot_a_cash;
        private decimal fin_tot_a_nbr;
        private decimal fin_tot_c_a_r;
        private decimal fin_tot_c_rev;
        private decimal fin_tot_c_cash;
        private decimal fin_tot_c_nbr;

        private string counters_grp;
        //private int ctr_batctrl_file_reads;
        //private int ctr_claims_mstr_reads;
        private int ctr_work_file_writes;
        private int ctr_work_file_reads;
        private int ctr_pages;

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "invalid reply";
        private string filler = "INVALID READ ON CONSTANTS MASTER";
        private string filler = "****  CAN BE RE-USED  ****";
        private string filler = "NO BATCTRL FILE SUPPLIED";
        private string filler = "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER";
        private string filler = "NO APPROPRIATE RECORDS IN BATCTRL FILE"; */
        private string err_msg_7_grp;
        //private string filler = "NO CLAIMS FOR THIS BATCH";
        private string err_msg_7_key;
        private string err_msg_8_grp;
        //private string filler = "CLAIMS READ APPROX ERROR";
        private string err_msg_8_key;
        private string err_msg_9_grp;
        //private string filler = "CLAIMS STATUS ERROR 23 OR 99";
        private string err_msg_9_key;
        private string err_msg_10_grp;
        //private string filler = "CLAIMS INVALID KEY TYPE";
        private string err_msg_10_key;
        private string error_messages_r_grp;
        private string[] err_msg = { "", "INVALID REPLY", "INVALID READ ON CONSTANTS MASTER", "****  CAN BE RE-USED  ****", "NO BATCTRL FILE SUPPLIED", "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER", "NO APPROPRIATE RECORDS IN BATCTRL FILE",
                                    "NO CLAIMS FOR THIS BATCH", "CLAIMS READ APPROX ERROR","CLAIMS STATUS ERROR 23 OR 99" , "CLAIMS INVALID KEY TYPE" };  // todo.. err-msg-7-key, err-msg-8-key, err-msg-9-key, err-msg-10-key
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

        //private string h1_head_grp;
        //private string filler = "R004_C/";
        private int h1_clinic_nbr;
        //private string filler = "";
        //private string filler = "P.E.D.";
        //private string filler = "/";
        private int h1_ped_yy;
        //private string filler = "/";
        private int h1_ped_mm;
        private int h1_ped_dd;
        //private string filler = "";
        // private string filler = "* CYCLE CLAIMS AND ADJUSTMENT TRANSACTION SUMMARY *";
        //private string filler = "run date";
        private string h1_date;
        //private string filler = "";
        //private string filler = "PAGE";
        private int h1_page;

        //private string h2_head_grp;
        //private string filler = "CLINIC";
        private int h2_clinic_nbr;
        //private string filler = "";
        //private string filler = "CYCLE";
        private int h2_cycle_nbr;
        /*private string filler = "";
        private string filler = "-----------";
        private string filler = " BATCH   CONTROL  FILE-";
        private string filler = "-------------";
        private string filler = "--------------";
        private string filler = "----claims  master---------------"; */

        //private string h3_head_grp;
        /*private string filler = "";
        private string filler = "AGENT";
        private string filler = "net a/r";
        private string filler = " NET REV";
        private string filler = "cash amt";
        private string filler = "NBR";
        private string filler = "oma amt";
        private string filler = "ohip amt";
        private string filler = "cash amt";
        private string filler = "NBR";*/

        //private string t1_print_line_grp;
        private string t1_desc_grp;
        private string t1_desc_a;
        private string t1_desc_b;
        private string t1_dash;
        private string filler;
        private int t1_agent_cd;
        //private string filler;
        private decimal t1_detail_1;
        //private string filler;
        private decimal t1_detail_2;
        //private string filler;
        private decimal t1_detail_3;
        //private string filler;
        private int t1_detail_4;
        //private string filler;
        private decimal t1_detail_5;
        //private string filler;
        private decimal t1_detail_6;
        //private string filler;
        private decimal t1_detail_7;
        //private string filler;
        private int t1_detail_8;
        //private string filler;
        //private string blank_line;
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

        private string endOfJob = "End of Job";
        private bool isRetrieving = false;
        private int row;
        private bool isReadNextRecord = false;
        private int ctr;
        private int nbrRecords = 10000;
        private int readCtr = 0;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "R004_CYCLE              CYCLE TRANSACTION SUMMARY",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 74,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 77,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "10",Col = 10,Data1 = "CLINIC ID      :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "10",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "12",Col = 10,Data1 = "CLINIC NAME    :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "12",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(20)",MaxLength = 20,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "14",Col = 10,Data1 = "PERIOD END DATE:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "14",Col = 30,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_date_period_end_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "14",Col = 34,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "14",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_date_period_end_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "14",Col = 37,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "14",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_date_period_end_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "16",Col = 29,Data1 = "CYCLE =",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-ped-cycle.",Line = "16",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_cycle_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "20",Col = 10,Data1 = "CONTINUE?  (ENTER Y OR N )",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "05",GroupNameLevel1 = "msg-continue.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reply"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "24",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "24",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "24",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "24",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "24",Col = 22,Data1 = "PROGRAM R004_CYCLE IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "NUMBER OF BATCTRL-FILE ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_batctrl_file_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "9",Col = 20,Data1 = "NUMBER OF CLAIM MSTR ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "9",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_claims_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM R004_CYCLE ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 50,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 53,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 58,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 60,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "REPORT IS IN FILE: ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(20)",MaxLength = 20,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_batctrl_file_section()
        {

            //     use after standard error procedure on batch-ctrl-file.;
        }

        private void err_batctrl()
        {

            common_status_file = status_cobol_batctrl_file;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING BATCH CONTROL FILE".;
            Console.WriteLine("ERROR IN ACCESSING BATCH CONTROL FILE");
            throw new Exception(endOfJob);
        }

        private void err_constants_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_constants_mstr()
        {

            common_status_file = status_cobol_iconst_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING ICONSTANTS MASTER".;
            Console.WriteLine("ERROR IN ACCESSING ICONSTANTS MASTER");
            throw new Exception(endOfJob);
        }

        private void err_claim_header_mstr_file_section()
        {

            //     use after standard error procedure on claims-mstr.;
        }

        private void err_claims_mstr()
        {

            common_status_file = status_cobol_claims_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
            Console.WriteLine("ERROR IN ACCESSING CLAIMS MASTER");
            throw new Exception(endOfJob);
        }

        private void end_declaratives()
        {

        }

        public void mainline()
        {
            
            try
            {

                objPrint_record = null;
                objPrint_record = new Print_record();

                objBatctrl_rec = null;
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();

                Batctrl_rec_Collection = null;
                Batctrl_rec_Collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

                // objClaim_header_rec = null;
                // objClaim_header_rec = new F002_CLAIMS_MSTR_HDR();

                // Claim_header_rec_Collection = null;
                // Claim_header_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();

                objClaim_detail_rec = null;
                objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL();

                Claim_detail_rec_Collection = null;
                Claim_detail_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

                objIconst_mstr_rec = null;
                objIconst_mstr_rec = new ICONST_MSTR_REC();

                Iconst_mstr_rec_Collection = null;
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objPrintFile = null;
                objPrintFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

                objConn = objClaim_detail_rec.Connection();

                //     perform aa0-initialization		thru aa0-99-exit.;
                aa0_initialization();
                aa0_20_continue_y_n();
                aa0_99_exit();

                //     perform ab0-processing      	thru ab0-99-exit.;
                ab0_processing();
                ab0_99_exit();

                //  perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
                az0_99_exit();

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
            //counters = 0;
            ctr_batctrl_file_reads = 0;
            ctr_claims_mstr_reads = 0;
            ctr_work_file_writes = 0;
            ctr_work_file_reads = 0;
            ctr_pages = 0;
            row = 0;

            //     accept sys-date			from 	date.;
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

            //  perform y2k-default-sysdate         thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;

            //     accept sys-time			from 	time.;
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
            //     display scr-title.;
            Console.WriteLine("R004_CYCLE              CYCLE TRANSACTION SUMMARY " + sys_yy.ToString() + "/" + sys_mm.ToString() + "/" + sys_dd.ToString());
        }

        private void aa0_20_continue_y_n()
        {
            
            ws_reply = "Y";

            // if ws-reply =   "Y" or "N" then;            
            if (ws_reply.ToUpper().Equals("Y") || ws_reply.ToUpper().Equals("N"))
            {
                // 	   next sentence;
            }
            else
            {
                err_ind = 1;
                //  perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to aa0-20-continue-y-n.;
                aa0_20_continue_y_n();
                return;
            }

            // if ws-reply = "N" then            
            if (Util.Str(ws_reply).ToUpper().Equals("N"))
            {
                //          accept sys-time		from 	time;
                //          display scr-closing-screen;
                Console.WriteLine("NUMBER OF BATCTRL-FILE ACCESSES = " + ctr_batctrl_file_reads.ToString());
                Console.WriteLine("NUMBER OF CLAIM MSTR ACCESSES = " + ctr_claims_mstr_reads.ToString());
                Console.WriteLine("PROGRAM R004_CYCLE ENDING");

                //          display confirm;
                //          stop run;
                throw new Exception(endOfJob);
            }
            else
            {
                // 	   display program-in-progress;
                Console.WriteLine("PROGRAM R004_CYCLE IN PROGRESS");

                // 	   open output	print-file;
                // 	    open input	batch-ctrl-file;
                // 	    iconst-mstr;
                // 	   claims-mstr.;
            }

            //tbl_totals = 0;
            tbl_totals_grp = "0";
            tbl_bat_type_and_tots = new string[9];
            tbl_agent_and_sums = new string[9, 12];
            tbl_tot = new decimal[9, 12, 11];

            //tbl_fin_tots = 0;
            fin_tots = new string[3];
            fin_tot_a_r = new decimal[3];
            fin_tot_rev = new decimal[3];
            fin_tot_cash = new decimal[3];
            fin_tot_nbr = new int[3];

            //final_totals = 0;
            fin_tot_1 = 0;
            fin_tot_2 = 0;
            fin_tot_3 = 0;
            fin_tot_4 = 0;
            fin_tot_5 = 0;
            fin_tot_6 = 0;
            fin_tot_7 = 0;
            fin_tot_8 = 0;

            fin_tot_a_a_r = 0;
            fin_tot_a_rev = 0;
            fin_tot_a_cash = 0;
            fin_tot_a_nbr = 0;
            fin_tot_c_a_r = 0;
            fin_tot_c_rev = 0;
            fin_tot_c_cash = 0;
            fin_tot_c_nbr = 0;

            page_ctr = 0;

            t1_print_line_grp(true);

            run_date_grp = Util.Str(run_yy).PadLeft(4, '0') + "/" + Util.Str(run_mm).PadLeft(2, '0') + "/" + Util.Str(run_dd).PadLeft(2, '0');
            h1_date = run_date_grp;

            //objBatctrl_rec.key_batctrl_file = "";

            //  start batch-ctrl-file key is greater than or equal to key-batctrl-file;
            //   	invalid key;
            //          err_ind = 4;
            // 	        perform za0-common-error	thru 	za0-99-exit;
            // 	        go to az0-end-of-job.;

            isRetrieving = false;

            /* Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
             {
                 WhereBatctrl_batch_nbr = ""
             }.Collection_All(ref isRetrieving, Batctrl_rec_Collection); */

            Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
            {
                // WhereBatctrl_batch_status = "1,2"

            }.Collection_UsingIN(ref isRetrieving, Batctrl_rec_Collection, true);

            //     read batch-ctrl-file next.;
            //     add 1				to 	ctr-batctrl-file-reads.;

            if (Batctrl_rec_Collection.Count() == 0)
            {
                err_ind = 4;
                //  perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //   go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];
            ctr_batctrl_file_reads++;

            //     perform xa0-read-disp-save-clinic-info;
            // 					thru	xa0-99-exit.;

            xa0_read_disp_save_clinic_info();
            xa0_99_exit();

            //  perform aa1-sel-read-next-batctrl	thru 	aa1-99-exit;
            //    	until   eof-batctrl-file = "Y";
            // 	     or valid-rec.;

            do
            {
                aa1_sel_read_next_batctrl();
                aa1_99_exit();
            } while (!eof_batctrl_file.ToUpper().Equals("Y") && !flag_rec.Equals(valid_rec));


            // if eof-batctrl-file = "Y" then          
            if (eof_batctrl_file.ToUpper().Equals("Y"))
            {
                // 	   perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	   go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            //  perform aa11-read-claim		thru 	aa11-99-exit.;
            aa11_read_claim();
            aa11_99_exit();

            new_header = "Y";
        }

        private void aa0_99_exit()
        {            
            //     exit.;
        }

        private void aa1_sel_read_next_batctrl()
        {            

            // if batctrl-bat-clinic-nbr-1-2 not = hold-clinic-nbr then      
            if (Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2)) != hold_clinic_nbr)
            {
                // 	perform xa1-end-of-clinic	thru	xa1-99-exit;
                xa1_end_of_clinic();
                xa1_99_exit();
                // 	perform xa0-read-disp-save-clinic-info;
                // 					thru	xa0-99-exit.;
                xa0_read_disp_save_clinic_info();
                xa0_99_exit();
            }

            // if (batctrl-date-period-end = iconst-date-period-end ) and (    batctrl-batch-status    = "1" or batctrl-batch-status    = "2") and (   (batctrl-batch-type     = "C") or (    batctrl-batch-type     = "A"  and batctrl-adj-cd         = "B" or "R")   or (    batctrl-batch-type     = "P"  and batctrl-adj-cd         = "M"))  then            
            if (
                 (Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(0, 4)) == Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY.ToString()) && Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(4, 2)) == Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM.ToString()) && Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(6, 2)) == Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD.ToString()))
                  && (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).Equals("1") || Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).Equals("2"))
                  && ((Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C")) || (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("A") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("B") || Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("R")) || (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("P") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("M")))
                )
            {
                batctrl_clm_offset = ss_batctrl_offset;
                //   perform sa2-add-batch-totals	thru	sa2-99-exit;
                sa2_add_batch_totals();
                sa2_99_exit();
                flag_rec = "Y";
                //  go to aa1-99-exit;
                aa1_99_exit();
                return;
            }
            else
            {
                flag_rec = "N";
                //   if  ( batctrl-date-period-end = iconst-date-period-end  and (   batctrl-batch-status    = "1"  or batctrl-batch-status    = "2") ) then            
                if ((Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(0, 4)) == Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY) && Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(4, 2)) == Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM) && Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(6, 2)) == Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD))
                     && (objBatctrl_rec.BATCTRL_BATCH_STATUS.Equals("1") || objBatctrl_rec.BATCTRL_BATCH_STATUS.Equals("2"))
                    )
                {
                    // 	 perform sa4-tot-non-processed-batches thru sa4-99-exit;            
                    sa4_tot_non_processed_batches();
                    sa4_99_exit();
                }
                else
                {
                    // 	       next sentence.;
                }
            }

            //  read batch-ctrl-file next;
            // 	    at end;
            //         err_ind = 6;
            //         eof_batctrl_file = "Y";
            // 	        go to aa1-99-exit.;

            //     add 1				to 	ctr-batctrl-file-reads.;

            if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
            {
                err_ind = 6;
                eof_batctrl_file = "Y";
                //  go to aa1-99-exit.;
                aa1_99_exit();
                return;
            }

            objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];
            ctr_batctrl_file_reads++;
        }

        private void aa1_99_exit()
        {            
            //     exit.;
        }

        private void aa11_read_claim()
        {            

            // perform aa2-read-clmhdr		thru 	aa2-99-exit.;
            aa2_read_clmhdr();
            aa2_99_exit();

            // if   batctrl-batch-nbr	 not = clmhdr-orig-batch-nbr;            
            //       or batctrl-bat-clinic-nbr-1-2 not = clmhdr-clinic-nbr-1-2;
            //       or batctrl-date-period-end not = clmhdr-date-period-end then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR) != Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR)
                || Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2) != Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(0, 2)
                || Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END) != Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END))
            {
                err_ind = 7;
                err_msg_7_key = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR);  //batctrl_batch_nbr;
                //   perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //   go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }
        }

        private void aa11_99_exit()
        {            

            //     exit.;
        }

        private void aa2_read_clmhdr()
        {            

            //objClaim_header_rec.clmhdr_claim_id = 0;
            objClaim_detail_rec.CLMHDR_BATCH_NBR = "";
            objClaim_detail_rec.CLMHDR_CLAIM_NBR = 0;
            objClaim_detail_rec.CLMHDR_ADJ_OMA_CD = "0";
            objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF = "";
            objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR = "";

            objClaim_detail_rec.CLMHDR_BATCH_NBR = objBatctrl_rec.BATCTRL_BATCH_NBR;

            objClaim_detail_rec.CLMHDR_CLAIM_NBR = 1;

            //objClaims_mstr_dtl_rec.key_claims_mstr = "";
            objClaim_detail_rec.KEY_CLM_TYPE = "";
            objClaim_detail_rec.CLMDTL_BATCH_NBR = "";
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;

            //objClaims_mstr_dtl_rec.clmdtl_b_oma_cd = "";
            objClaim_detail_rec.CLMDTL_OMA_CD = "";

            //objClaims_mstr_dtl_rec.clmdtl_b_oma_suff = "";
            objClaim_detail_rec.CLMDTL_OMA_SUFF = "";

            //objClaims_mstr_dtl_rec.clmdtl_b_data = objClaim_header_rec.clmhdr_claim_id;
            objClaim_detail_rec.CLMDTL_BATCH_NBR = objClaim_detail_rec.CLMHDR_BATCH_NBR;
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = objClaim_detail_rec.CLMHDR_CLAIM_NBR;
            objClaim_detail_rec.CLMDTL_OMA_CD = objClaim_detail_rec.CLMHDR_ADJ_OMA_CD;
            objClaim_detail_rec.CLMDTL_OMA_SUFF = objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF;
            objClaim_detail_rec.CLMDTL_ADJ_NBR = Util.NumDec(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR);

            //objClaims_mstr_dtl_rec.clmdtl_b_key_type = "B";
            objClaim_detail_rec.KEY_CLM_TYPE = "B";

            // start claims-mstr key is greater than or equal to key-claims-mstr;
            // 	     invalid key;
            //          err_ind = 8;
            //          err_msg_8_key = objBatctrl_rec.batctrl_batch_nbr;
            // 	        perform za0-common-error	thru	za0-99-exit;
            // 	        go to az0-end-of-job.;

            //     read claims-mstr next.;

            /*  Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL 
               {
                   WhereKey_clm_type = objClaim_detail_rec.KEY_CLM_TYPE,
                   WhereClmhdr_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,
                   WhereClmhdr_claim_nbr = objClaim_detail_rec.CLMDTL_CLAIM_NBR,
                   WhereClmhdr_adj_oma_cd = objClaim_detail_rec.CLMDTL_OMA_CD,
                   WhereClmhdr_adj_oma_suff = objClaim_detail_rec.CLMDTL_OMA_SUFF,
                   WhereClmhdr_adj_adj_nbr = Util.Str(objClaim_detail_rec.CLMDTL_ADJ_NBR)
               }.Collection_HDR_DTL_INNERJOIN_UsingTop(); */

            Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = objClaim_detail_rec.KEY_CLM_TYPE,
                WhereKey_clm_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,
                WhereKey_clm_claim_nbr = objClaim_detail_rec.CLMHDR_CLAIM_NBR
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(nbrRecords, false, objConn);

            if (Claim_detail_rec_Collection.Count() == 0)
            {
                err_ind = 8;
                err_msg_8_key = objBatctrl_rec.BATCTRL_BATCH_NBR;
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }

            row = 0;
            objClaim_detail_rec = Claim_detail_rec_Collection[row];
            row++;

            //  if status-cobol-claims-mstr =  23 or 99  then;            
            //      err_ind = 9;
            //      err_msg_9_key = objBatctrl_rec.batctrl_batch_nbr;
            // 	    perform za0-common-error	thru	za0-99-exit;
            // 	    go to az0-end-of-job.;

            // if clmdtl-b-key-type not = "B" then;            
            if (Util.Str(objClaim_detail_rec.KEY_CLM_TYPE).ToUpper() != "B")
            {
                err_ind = 10;
                err_msg_10_key = objBatctrl_rec.BATCTRL_BATCH_NBR; // batctrl_batch_nbr;
                // 	   perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	   go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            //     add 1				to 	ctr-claims-mstr-reads.;
            ctr_claims_mstr_reads++;

            hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR);  // clmhdr_orig_batch_nbr;
            hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);  // clmhdr_orig_claim_nbr;
        }

        private void aa2_99_exit()
        {            

            //     exit.;
        }

        private void ab0_processing()
        {            

            while (eof_claims_mstr.ToUpper().Equals("N"))
            {

                // if  clmhdr-orig-batch-nbr  not = batctrl-batch-nbr  or clmhdr-date-period-end not = batctrl-date-period-end  then            
                if (Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR) || Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
                {
                    // 	perform ga0-read-next-batch	thru	ga0-99-exit.;
                    ga0_read_next_batch();
                    ga0_99_exit();
                }

                // if eof-batctrl-file = "Y" then;            
                if (eof_batctrl_file.ToUpper().Equals("Y"))
                {
                    // 	  go to ab0-99-exit.;
                    ab0_99_exit();
                    return;
                }

                batctrl_clm_offset = ss_clmhdr_offset;
                //  perform sa0-add-claim-totals	thru	sa0-99-exit.;
                sa0_add_claim_totals();
                sa0_99_exit();

                new_header = "N";
                eof_claims_dtl = "N";

                //  perform ba0-process-dtl-recs	thru	ba0-99-exit;
                // 		until eof-claims-dtl = "Y".;

                isReadNextRecord = false;
                readCtr = 0;

                do
                {
                    ba0_process_dtl_recs(isReadNextRecord);
                    ba0_99_exit();
                    isReadNextRecord = true;

                    if (Util.Str(new_header).ToUpper().Equals("Y") && readCtr == 0)
                    {
                        eof_claims_dtl = "N";
                    }
                } while (eof_claims_dtl.ToUpper() != "Y");

                // if eof-claims-mstr     = "N" and new-header      not = "Y"  then;           
                if (eof_claims_mstr.ToUpper() == "N" && new_header.ToUpper() != "Y")
                {
                    // 	   perform ha0-read-clmhdr-next	thru	ha0-99-exit.;
                    ha0_read_clmhdr_next();
                    ha0_99_exit();
                }

                // if eof-claims-mstr = "N"  then            
                /*if (eof_claims_mstr.ToUpper().Equals("N"))
                {
                    // 	  go to ab0-processing.;
                    ab0_processing();
                    return;
                }*/
            }
        }

        private void ab0_99_exit()
        {            
            //     exit.;
        }

        private void az0_end_of_job()
        {            

            //     perform xa1-end-of-clinic		thru	xa1-99-exit.;
            xa1_end_of_clinic();
            xa1_99_exit();

            //     perform yb1-print-final-totals	thru	yb1-99-exit.;
            yb1_print_final_totals();
            yb1_99_exit();

            //     close batch-ctrl-file;
            // 	  print-file;
            // 	  iconst-mstr;
            // 	  claims-mstr.;
            //     display blank-screen.;
            //     accept sys-time			from 	time.;
            //     display scr-closing-screen.;
            Console.WriteLine("NUMBER OF BATCTRL-FILE ACCESSES = " + ctr_batctrl_file_reads);
            Console.WriteLine("NUMBER OF CLAIM MSTR ACCESSES = " + ctr_claims_mstr_reads);
            Console.WriteLine("PROGRAM R004_CYCLE ENDING");
            Console.WriteLine(sys_yy.ToString() + "/" + sys_mm.ToString() + "/" + sys_dd.ToString() + " " + sys_hrs.ToString() + ":" + sys_min.ToString());
            Console.WriteLine("");
            Console.WriteLine("REPORT IS IN FILE: " + print_file_name);

            //     stop run.;
        }

        private void az0_99_exit()
        {            
            //     exit.;
        }

        private void ba0_process_dtl_recs(bool isReadNext = false)
        {            

            do
            {

                // read claims-mstr next;
                // 	     at end;
                //         eof_claims_dtl = "Y";
                //         eof_claims_mstr = "Y";
                // 	       go to ba0-99-exit.;

                /*objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL
                {
                }.Collection_HDR_DTL_INNERJOIN_ReadNext(objClaim_detail_rec); */

                if (isReadNext)
                {
                    readCtr++;
                    if (row >= Claim_detail_rec_Collection.Count())
                    {
                        eof_claims_dtl = "Y";
                        eof_claims_mstr = "Y";
                        //  go to ba0-99-exit.;
                        ba0_99_exit();
                        return;
                    }

                    objClaim_detail_rec = Claim_detail_rec_Collection[row];
                    row++;
                    ctr_claims_mstr_reads++;
                }

                if (isReadNext == false)
                {
                    readCtr = 0;
                }



                // if clmdtl-b-key-type not = "B" then            
                if (Util.Str(objClaim_detail_rec.KEY_CLM_TYPE).ToUpper() != "B")
                {
                    eof_claims_dtl = "Y";
                    eof_claims_mstr = "Y";
                    // 	  go to ba0-99-exit.;
                    ba0_99_exit();
                    return;
                }

                // if batctrl-batch-type     = "C" and clmdtl-adj-nbr     not = 0  then            
                /* if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C") && Util.NumInt(objClaim_detail_rec.CLMDTL_ADJ_NBR) != 0) {
                     // 	  go to ba0-process-dtl-recs.;
                     ba0_process_dtl_recs();
                     return;
                 } */


                if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C") && Util.NumInt(objClaim_detail_rec.CLMDTL_ADJ_NBR) != 0)
                {
                    // recursive...
                    isReadNext = true;
                }
                else
                {

                    // if clmdtl-oma-cd = "ZZZZ" then            
                    if (Util.Str(objClaim_detail_rec.CLMDTL_OMA_CD) == "ZZZZ")
                    {
                        isReadNext = true;
                        // eof_claims_dtl = "Y";
                        // 	   go to  ba0-99-exit.;
                        ba0_99_exit();                        
                    }

                    // if clmhdr-zeroed-area is numeric then       
                    if (Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD) && Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF) && Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR))
                    {
                        // 	  if clmhdr-zeroed-area = zero then        
                        //if (Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD) == 0 && Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF) == 0 && Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR) == 0)
                        if (Util.Str(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD).CompareTo("0") == 0 && Util.Str(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF).CompareTo("0") == 0 && Util.Str(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR).CompareTo("0") == 0)
                        {
                            hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR);  //clmhdr_orig_batch_nbr;
                            hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR); // clmhdr_orig_claim_nbr;
                            new_header = "Y";
                            eof_claims_dtl = "Y";
                            //   go to ba0-99-exit;
                            ba0_99_exit();
                            return;
                        }
                        else
                        {
                            // 	     next sentence;
                        }
                    }
                    else
                    {
                        // 	   next sentence.;
                    }

                    // if clmdtl-orig-batch-nbr not = hold-clmhdr-batch-nbr or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr  then    
                    if (objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR != hold_clmhdr_batch_nbr || objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH != hold_clmhdr_claim_nbr)
                    {
                        new_header = "Y";
                        eof_claims_dtl = "Y";
                        hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR);  //clmhdr_orig_batch_nbr;
                        hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR); // clmhdr_orig_claim_nbr;
                    }
                }
            } while (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C") && Util.NumInt(objClaim_detail_rec.CLMDTL_ADJ_NBR) != 0);
        }

        private void ba0_99_exit()
        {            
            //     exit.;
        }

        private void ga0_read_next_batch()
        {            

            // read batch-ctrl-file next;
            // 	    at end;
            //        eof_batctrl_file = "Y";
            // 	      go to ga0-99-exit.;

            //     add 1				to ctr-batctrl-file-reads.;

            if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
            {
                eof_batctrl_file = "Y";
                // go to ga0-99-exit.;
                ga0_99_exit();
                return;
            }

            objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];
            ctr_batctrl_file_reads++;

            flag_rec = "N";

            //  perform aa1-sel-read-next-batctrl	thru aa1-99-exit;
            // 	until   eof-batctrl-file = "Y";
            // 	     or valid-rec.;

            do
            {
                aa1_sel_read_next_batctrl();
                aa1_99_exit();
            } while (eof_batctrl_file.ToUpper() != "Y" && !flag_rec.Equals(valid_rec));

            // if eof-batctrl-file = "Y" then            
            if (eof_batctrl_file.ToUpper().Equals("Y"))
            {
                // 	  go to ga0-99-exit.;
                ga0_99_exit();
                return;
            }

            //  if clmhdr-orig-batch-nbr  not = batctrl-batch-nbr or clmhdr-date-period-end not = batctrl-date-period-end  then   
            if (Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR) || Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                // 	   perform aa11-read-claim		thru	aa11-99-exit.;
                aa11_read_claim();
                aa11_99_exit();
            }
        }

        private void ga0_99_exit()
        {            

            //     exit.;
        }

        private void ha0_read_clmhdr_next()
        {            

            //objClaims_mstr_dtl_rec.clmdtl_b_data = 0;
            objClaim_detail_rec.CLMDTL_BATCH_NBR = "";
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;
            objClaim_detail_rec.CLMDTL_OMA_CD = "";
            objClaim_detail_rec.CLMDTL_OMA_SUFF = "";
            objClaim_detail_rec.CLMDTL_ADJ_NBR = 0;

            // if clmdtl-orig-claim-nbr-in-batch = 99 then            
            if (Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH) == 99)
            {
                // 	  perform xx0-increment-batch-nbr thru    xx0-99-exit;
                xx0_increment_batch_nbr();
                xx0_99_exit();

                objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = 1;
            }
            else
            {
                // 	   add 1				to      clmdtl-orig-claim-nbr-in-batch.;
                objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH) + 1;
            }

            // objClaims_mstr_dtl_rec.clmdtl_b_batch_nbr = objClaim_detail_rec.clmdtl_orig_batch_nbr;
            objClaim_detail_rec.CLMDTL_BATCH_NBR = objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR;

            // objClaims_mstr_dtl_rec.clmdtl_b_claim_nbr = objClaim_detail_rec.clmdtl_orig_claim_nbr_in_batch;
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH;

            // start claims-mstr key is greater than or equal to key-claims-mstr.;
            //     read claims-mstr next;
            //       at end;
            //         eof_claims_mstr = "Y";
            // 	       go to ha0-99-exit.;

            Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = objClaim_detail_rec.KEY_CLM_TYPE,
                WhereKey_clm_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,
                WhereKey_clm_claim_nbr = objClaim_detail_rec.CLMHDR_CLAIM_NBR
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(nbrRecords, false, objConn);

            if (Claim_detail_rec_Collection.Count() == 0)
            {
                eof_claims_mstr = "Y";
                //  go to ha0-99-exit.;
                ha0_99_exit();
                return;
            }

            row = 0;
            objClaim_detail_rec = Claim_detail_rec_Collection[row];
            row++;

            //     add 1				to	ctr-claims-mstr-reads.;
            ctr_claims_mstr_reads++;

            if (objClaim_detail_rec == null)
            {
                eof_claims_mstr = "Y";
                // go to ha0-99-exit.;
                ha0_99_exit();
                return;
            }

            // if clmdtl-b-key-type      not = "B" then;            
            if (Util.Str(objClaim_detail_rec.KEY_CLM_TYPE) != "B")
            {
                eof_claims_mstr = "Y";
                // 	   go to ha0-99-exit.;
                ha0_99_exit();
                return;
            }



            hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR); //clmhdr_orig_batch_nbr;
            hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);  //clmhdr_orig_claim_nbr;
        }

        private void ha0_99_exit()
        {            
            //     exit.;
        }

        private void sa0_add_claim_totals()
        {            

            //  perform sa1-find-ss-type 		thru	sa1-99-exit.;
            sa1_find_ss_type();
            sa1_99_exit();

            //     add  1, clmhdr-agent-cd		giving	ss-agent.;
            ss_agent = Util.NumInt(objClaim_detail_rec.CLMHDR_AGENT_CD) + 1;

            //     add batctrl-clm-offset, ss-a-r-oma	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_a_r_oma;

            //     add clmhdr-tot-claim-ar-oma		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OMA);

            //     add batctrl-clm-offset, ss-a-r-ohip	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_a_r_ohip;

            //     add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-ype, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);

            //     add batctrl-clm-offset, ss-cash	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_cash;

            //     add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);

            //     add batctrl-clm-offset, ss-nbr	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_nbr;
            //     add 1                  		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] = Util.NumDec(tbl_tot[ss_type, ss_agent, ss_temp1]) + 1;
        }

        private void sa0_99_exit()
        {            
            //     exit.;
        }

        private void sa1_find_ss_type()
        {            

            // if clmhdr-batch-type = "C"  then            
            //    ss_type = ss_claims;
            // else if clmhdr-batch-type = "A" then            
            // 	    if clmhdr-adj-cd = "A" then            
            //          ss_type = ss_adj_a;
            // 	    else if clmhdr-adj-cd = "B" then            
            //            ss_type = ss_adj_b;
            // 		else;
            //          ss_type = ss_adj_r;
            // else if clmhdr-adj-cd = "M" then            
            //     ss_type = ss_pay_m;
            // else;
            //    ss_type = ss_pay_c;

            // if clmhdr-batch-type = "C"  then            
            if (Util.Str(objClaim_detail_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C"))
            {
                ss_type = ss_claims;
            }
            // else if clmhdr-batch-type = "A" then            
            else if (objClaim_detail_rec.CLMHDR_BATCH_TYPE.ToUpper().Equals("A"))
            {
                // 	    if clmhdr-adj-cd = "A" then            
                if (Util.Str(objClaim_detail_rec.CLMHDR_ADJ_CD).ToUpper().Equals("A"))
                {
                    ss_type = ss_adj_a;
                }
                // 	    else if clmhdr-adj-cd = "B" then            
                else if (Util.Str(objClaim_detail_rec.CLMHDR_ADJ_CD).ToUpper().Equals("B"))
                {
                    ss_type = ss_adj_b;
                }
                else
                {
                    ss_type = ss_adj_r;
                }
            }
            // else if clmhdr-adj-cd = "M" then            
            else if (Util.Str(objClaim_detail_rec.CLMHDR_ADJ_CD).ToUpper().Equals("M"))
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
            //     exit.;
        }

        private void sa2_add_batch_totals()
        {            

            //   perform sa3-find-ss-type 		thru	sa3-99-exit.;
            sa3_find_ss_type();
            sa3_99_exit();

            //     add  1, batctrl-agent-cd		giving	ss-agent.;
            ss_agent = Util.NumInt(objBatctrl_rec.BATCTRL_AGENT_CD) + 1;

            //     add batctrl-clm-offset, ss-a-r-oma	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_a_r_oma;

            //     add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);

            //     add batctrl-clm-offset, ss-a-r-ohip	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_a_r_ohip;

            //     add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);

            //     add batctrl-clm-offset, ss-cash	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_cash;

            //     add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);

            //     perform sa21-check-nbr-claims-field	thru	sa21-99-exit.;
            sa21_check_nbr_claims_field();
            sa21_99_exit();

            //     add batctrl-clm-offset, ss-nbr	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_nbr;

            //     add batctrl-nbr-claims-in-batch	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH);
        }

        private void sa2_99_exit()
        {            
            //     exit.;
        }

        private void sa21_check_nbr_claims_field()
        {            

            // if  batctrl-nbr-claims-in-batch not numeric or  batctrl-nbr-claims-in-batch = zero then            
            if (!Util.IsNumeric(Util.Str(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH)) || Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH) == 0)
            {
                objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH = Util.NumDec(objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR); //batctrl_last_claim_nbr;

            }
        }

        private void sa21_99_exit()
        {            
            //     exit.;
        }

        private void sa3_find_ss_type()
        {            

            // if batctrl-batch-type = "C" then;            
            //    ss_type = ss_claims;
            //  else if batctrl-batch-type = "A" then            
            // 	    if batctrl-adj-cd = "A" then;            
            //         ss_type = ss_adj_a;
            // 	    else if batctrl-adj-cd = "B" then            
            //          ss_type = ss_adj_b;
            // 		else;
            //          ss_type = ss_adj_r;
            // else if batctrl-adj-cd = "M"  then            
            //      ss_type = ss_pay_m;
            // else;
            //      ss_type = ss_pay_c;

            // if batctrl-batch-type = "C" then;            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                ss_type = ss_claims;
            }
            //  else if batctrl-batch-type = "A" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("A"))
            {
                // 	    if batctrl-adj-cd = "A" then;         
                if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("A"))
                {
                    ss_type = ss_adj_a;
                }
                // 	    else if batctrl-adj-cd = "B" then            
                else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("B"))
                {
                    ss_type = ss_adj_b;
                }
                else
                {
                    ss_type = ss_adj_r;
                }
            }
            // else if batctrl-adj-cd = "M"  then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("M"))
            {
                ss_type = ss_pay_m;
            }
            else
            {
                ss_type = ss_pay_c;
            }
        }

        private void sa3_99_exit()
        {            
            //     exit.;
        }

        private void sa4_tot_non_processed_batches()
        {            

            // if batctrl-batch-type = "A" and batctrl-adj-cd     = "A"  then     
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("A") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("A"))
            {
                ss = ss_a;
                // 	  add batctrl-manual-pay-tot          	to	fin-tot-cash( ss );
                fin_tot_cash[ss] += Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
            }
            // else if    batctrl-batch-type = "P"  and batctrl-adj-cd     = "C" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("P") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C"))
            {
                ss = ss_c;
                // 	   subtract batctrl-manual-pay-tot     from	fin-tot-cash( ss );
                fin_tot_cash[ss] = fin_tot_cash[ss] - Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
            }
            else
            {
                // 	    go to sa4-99-exit.;
                sa4_99_exit();
                return;
            }

            //     add batctrl-calc-ar-due     		to	fin-tot-a-r ( ss ).;
            fin_tot_a_r[ss] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);
            //     add batctrl-calc-tot-rev     		to	fin-tot-rev ( ss ).;
            fin_tot_rev[ss] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
            //  perform sa21-check-nbr-claims-field	thru	sa21-99-exit.;
            sa21_check_nbr_claims_field();
            sa21_99_exit();
            //     add batctrl-nbr-claims-in-batch		to	fin-tot-nbr ( ss ).;
            fin_tot_nbr[ss] += Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH);
        }

        private void sa4_99_exit()
        {            
            //     exit.;
        }

        private void tb0_write_line()
        {            

            //     add  nbr-lines-2-advance 				to	ctr-lines.;
            ctr_lines += nbr_lines_2_advance;

            // if ctr-lines > max-nbr-lines then;
            if (ctr_lines > max_nbr_lines)
            {
                //  	perform tc0-print-headings			thru	tc0-99-exit.;
                tc0_print_headings();
                tc0_99_exit();
            }

            //     write   print-record  from t1-print-line   after advancing  nbr-lines-2-advance.;
            for (int i = 1; i < nbr_lines_2_advance; i++)
            {
                objPrintFile.print(true);
            }

            objPrint_record.Print_record1 = t1_print_line_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            if (!Util.Str(t1_desc_a).ToUpper().Trim().Equals("TOTAL") && !Util.Str(t1_desc_a).ToUpper().Trim().Equals("TOTALS"))
            {
                //t1_print_line = "";
                MoveSpaceToT1PrintLine();
            }
            else if (ss_type == ss_grand_tot)
            {
                //t1_print_line = "";
                MoveSpaceToT1PrintLine();
            }

            nbr_lines_2_advance = 1;
        }

        private void tb0_99_exit()
        {            
            //     exit.;
        }

        private void tc0_print_headings()
        {            
            //     add 1					to	page-ctr.;
            page_ctr++;

            h1_page = page_ctr;

            //     write print-record from h1-head after advancing page.;

            objPrint_record.Print_record1 = h1_head_grp();
            objPrintFile.PageBreak();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h2-head after advancing 2 lines.;            
            objPrint_record.Print_record1 = h2_head_grp();
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h3-head after advancing 2 lines.;            
            objPrint_record.Print_record1 = h3_head_grp();
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            nbr_lines_2_advance = 2;
            ctr_lines = 6;
        }

        private void tc0_99_exit()
        {            
            //     exit.;
        }

        private void tc1_roll_type_tot_to_grand()
        {            

            ss_type_from = ss_type_tot;
            ss_type_to = ss_grand_tot;
            //     perform te0-roll-and-zero-totals	thru	te0-99-exit;
            // 	varying  ss-agent-from;
            // 	from  1;
            // 	by    1;
            // 	until    ss-agent-from > max-nbr-agents + 1.;

            ss_agent_from = 1;
            do
            {
                te0_roll_and_zero_totals();
                te0_99_exit();
                ss_agent_from++;
            } while (ss_agent_from <= (max_nbr_agents + 1));
        }

        private void tc1_99_exit()
        {            
            //     exit.;
        }

        private void te0_roll_and_zero_totals()
        {            

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
            //     exit.;
        }

        private void tg0_move_vals_to_line()
        {            

            //move tbl-tot(ss - type - from, ss - agent, 1)   to t1-detail - 1.
            t1_detail_1 = tbl_tot[ss_type_from, ss_agent, 1];
            //move tbl-tot(ss - type - from, ss - agent, 2)   to t1-detail - 2.
            t1_detail_2 = tbl_tot[ss_type_from, ss_agent, 2];
            //move tbl - tot(ss - type - from, ss - agent, 3)   to t1-detail - 3.
            t1_detail_3 = tbl_tot[ss_type_from, ss_agent, 3];
            //move tbl - tot(ss - type - from, ss - agent, 4)   to t1-detail - 4.
            t1_detail_4 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 4]);
            //move tbl - tot(ss - type - from, ss - agent, 5)   to t1-detail - 5.
            t1_detail_5 = tbl_tot[ss_type_from, ss_agent, 5];
            //move tbl - tot(ss - type - from, ss - agent, 6)   to t1-detail - 6.
            t1_detail_6 = tbl_tot[ss_type_from, ss_agent, 6];
            //move tbl - tot(ss - type - from, ss - agent, 7)   to t1-detail - 7.
            t1_detail_7 = tbl_tot[ss_type_from, ss_agent, 7];
            //move tbl - tot(ss - type - from, ss - agent, 8)   to t1-detail - 8.
            t1_detail_8 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 8]);
        }

        private void tg0_99_exit()
        {            
            //     exit.;
        }

        private void xa0_read_disp_save_clinic_info()
        {            

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = objBatctrl_rec.batctrl_bat_clinic_nbr_1_2;
            objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = Util.NumDec(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2));
            hold_clinic_nbr = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2)); //objBatctrl_rec.batctrl_bat_clinic_nbr_1_2;

            //  read iconst-mstr;
            //     	invalid key;
            //         err_ind = 2;
            // 		   perform za0-common-error	thru za0-99-exit;
            //         go to xa0-99-exit.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumDec(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2))
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 2;
                //  perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //         go to xa0-99-exit.;
                xa0_99_exit();
                return;
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            //     display ring-bell.;

            //     display scr-clinic-ped-cycle.;
            Console.WriteLine("CLINIC ID      :" + Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2));
            Console.WriteLine("CLINIC NAME    :" + Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME));
            Console.WriteLine("PERIOD END DATE:" + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY) + "/" + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM).PadLeft(2, '0') + "/" + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD).PadLeft(2, '0'));

            h1_ped_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h1_ped_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h1_ped_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_cycle_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
            h2_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
            h1_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);

        }

        private void xa0_99_exit()
        {            
            //     exit.;
        }

        private void xa1_end_of_clinic()
        {            

            //  perform zb0-print-totals-summary	thru	zb0-99-exit.;
            zb0_print_totals_summary();
            zb0_99_exit();

            //     perform zf0-print-non-proc-tots	thru	zf0-99-exit;
            // 	    varying ss;
            // 	    from 1;
            // 	    by   1;
            // 	    until  ss > 2.;

            ss = 1;
            do
            {
                zf0_print_non_proc_tots();
                zf0_99_exit();
                ss++;
            } while (ss <= 2);

            //     perform ya1-add-to-fin-tots		thru	ya1-99-exit.;
            ya1_add_to_fin_tots();
            ya1_99_exit();

            //tbl_totals = 0;
            tbl_totals_grp = "0";
            tbl_bat_type_and_tots = new string[9];
            tbl_agent_and_sums = new string[9, 12];
            tbl_tot = new decimal[9, 12, 11];

            //tbl_fin_tots = 0;
            fin_tots = new string[3];
            fin_tot_a_r = new decimal[3];
            fin_tot_rev = new decimal[3];
            fin_tot_cash = new decimal[3];
            fin_tot_nbr = new int[3];

        }

        private void xa1_99_exit()
        {            
            //     exit.;
        }

        private void xx0_increment_batch_nbr()
        {            

            flag_request_complete = "N";

            // if clmdtl-orig-batch-number = 999 then            
            if (Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR) == 999)
            {
                tmp_doc_nbr_alpha_grp = objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR.PadRight(10, ' ').Substring(2, 3);  //clmdtl_orig_doc_number;
                tmp_batch_nbr_index[1] = tmp_doc_nbr_alpha_grp.Substring(0, 1);
                tmp_batch_nbr_index[2] = tmp_doc_nbr_alpha_grp.Substring(1, 1);
                tmp_batch_nbr_index[3] = tmp_doc_nbr_alpha_grp.Substring(2, 1);
                //      display "BEFORE: " clmdtl-orig-doc-number;
                Console.Write("BEFORE: " + objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR.PadRight(10, ' ').Substring(2, 3));
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
                } while (ss > 0 && !flag_request_complete.Equals(flag_request_complete_y));

                //     objClaim_detail_rec.clmdtl_orig_doc_number = tmp_doc_nbr_alpha;
                //     display "AFTER : " clmdtl-orig-doc-number;
                Console.WriteLine("AFTER : " + tmp_doc_nbr_alpha_grp);
                //     display " ";
                //     objClaim_detail_rec.clmdtl_orig_batch_number = 000;
                objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR = "0";
            }
            else
            {
                //         add 1                           to       clmdtl-orig-batch-number.;
                int temp = Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR) + 1;
                objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR = temp.ToString();
            }
        }

        private void xx0_99_exit()
        {            
            //    exit.;
        }

        private void xx1_process_1_doc_position()
        {            

            if (tmp_batch_nbr_index[ss] == "0")
            {
                tmp_batch_nbr_index[ss] = "1";
                //     go to xx1-90-return;\
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "1")
            {
                tmp_batch_nbr_index[ss] = "2";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "2")
            {
                tmp_batch_nbr_index[ss] = "3";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "3")
            {
                tmp_batch_nbr_index[ss] = "4";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "4")
            {
                tmp_batch_nbr_index[ss] = "5";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "5")
            {
                tmp_batch_nbr_index[ss] = "6";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "6")
            {
                tmp_batch_nbr_index[ss] = "7";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "7")
            {
                tmp_batch_nbr_index[ss] = "8";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "8")
            {
                tmp_batch_nbr_index[ss] = "9";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "9")
            {
                tmp_batch_nbr_index[ss] = "A";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "A")
            {
                tmp_batch_nbr_index[ss] = "B";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "B")
            {
                tmp_batch_nbr_index[ss] = "C";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "C")
            {
                tmp_batch_nbr_index[ss] = "D";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "D")
            {
                tmp_batch_nbr_index[ss] = "E";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "E")
            {
                tmp_batch_nbr_index[ss] = "F";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "F")
            {
                tmp_batch_nbr_index[ss] = "G";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "G")
            {
                tmp_batch_nbr_index[ss] = "H";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "H")
            {
                tmp_batch_nbr_index[ss] = "I";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "I")
            {
                tmp_batch_nbr_index[ss] = "J";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "J")
            {
                tmp_batch_nbr_index[ss] = "K";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "K")
            {
                tmp_batch_nbr_index[ss] = "L";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "L")
            {
                tmp_batch_nbr_index[ss] = "M";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "M")
            {
                tmp_batch_nbr_index[ss] = "N";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "N")
            {
                tmp_batch_nbr_index[ss] = "O";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "O")
            {
                tmp_batch_nbr_index[ss] = "P";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "P")
            {
                tmp_batch_nbr_index[ss] = "Q";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Q")
            {
                tmp_batch_nbr_index[ss] = "R";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "R")
            {
                tmp_batch_nbr_index[ss] = "S";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "S")
            {
                tmp_batch_nbr_index[ss] = "T";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "T")
            {
                tmp_batch_nbr_index[ss] = "U";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "U")
            {
                tmp_batch_nbr_index[ss] = "V";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "V")
            {
                tmp_batch_nbr_index[ss] = "W";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "W")
            {
                tmp_batch_nbr_index[ss] = "X";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "X")
            {
                tmp_batch_nbr_index[ss] = "Y";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Y")
            {
                tmp_batch_nbr_index[ss] = "Z";
                //     go to xx1-90-return;
                xx1_90_return();
                return;
            }
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

            flag_request_complete = "Y";
        }

        private void xx1_99_exit()
        {
         
            //     exit.;
        }

        private void ya1_add_to_fin_tots()
        {            

            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 1 ) to	fin-tot-1.;
            fin_tot_1 += tbl_tot[ss_grand_tot, ss_agent_tot, 1];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 2 ) to	fin-tot-2.;
            fin_tot_2 += tbl_tot[ss_grand_tot, ss_agent_tot, 2];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 3 ) to	fin-tot-3.;
            fin_tot_3 += tbl_tot[ss_grand_tot, ss_agent_tot, 3];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 4 ) to	fin-tot-4.;
            fin_tot_4 += tbl_tot[ss_grand_tot, ss_agent_tot, 4];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 5 ) to	fin-tot-5.;
            fin_tot_5 += tbl_tot[ss_grand_tot, ss_agent_tot, 5];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 6 ) to	fin-tot-6.;
            fin_tot_6 += tbl_tot[ss_grand_tot, ss_agent_tot, 6];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 7 ) to	fin-tot-7.;
            fin_tot_7 += tbl_tot[ss_grand_tot, ss_agent_tot, 7];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 8 ) to	fin-tot-8.;
            fin_tot_8 += tbl_tot[ss_grand_tot, ss_agent_tot, 8];

            //     add fin-tot-a-r  (ss-a)			to	fin-tot-a-a-r.;
            fin_tot_a_a_r += fin_tot_a_r[ss_a];
            //     add fin-tot-rev  (ss-a)			to	fin-tot-a-rev.;
            fin_tot_a_rev += fin_tot_rev[ss_a];
            //     add fin-tot-cash (ss-a)			to	fin-tot-a-cash.;
            fin_tot_a_cash += fin_tot_cash[ss_a];
            //     add fin-tot-nbr  (ss-a)			to	fin-tot-a-nbr.;
            fin_tot_a_nbr += fin_tot_nbr[ss_a];
            //     add fin-tot-a-r  (ss-c)			to	fin-tot-c-a-r.;
            fin_tot_c_a_r += fin_tot_a_r[ss_c];
            //     add fin-tot-rev  (ss-c)			to	fin-tot-c-rev.;
            fin_tot_c_rev += fin_tot_rev[ss_c];
            //     add fin-tot-cash (ss-c)			to	fin-tot-c-cash.;
            fin_tot_c_cash += fin_tot_cash[ss_c];
            //     add fin-tot-nbr  (ss-c)			to	fin-tot-c-nbr.;
            fin_tot_c_nbr += fin_tot_nbr[ss_c];
        }

        private void ya1_99_exit()
        {            
            //     exit.;
        }

        private void yb1_print_final_totals()
        {            

            h1_ped_yy = 0;
            h1_ped_mm = 0;
            h1_ped_dd = 0;
            h2_cycle_nbr = 0;
            h2_clinic_nbr = 0;

            ctr_lines = 90;
            //t1_desc_grp = "FINAL TOTALS";
            t1_desc_a = "FINAL TOTALS ";
            t1_desc_b = "     ";

            t1_detail_1 = fin_tot_1;
            t1_detail_2 = fin_tot_2;
            t1_detail_3 = fin_tot_3;
            t1_detail_4 = Util.NumInt(fin_tot_4);
            t1_detail_5 = fin_tot_5;
            t1_detail_6 = fin_tot_6;
            t1_detail_7 = fin_tot_7;
            t1_detail_8 = Util.NumInt(fin_tot_8);
            nbr_lines_2_advance = 3;
            //     perform tb0-write-line	thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            //move "FINAL 'A' ADJUST."   to t1-desc.
            //t1_desc_grp = "FINAL 'A' ADJUST.";
            t1_desc_a = "FINAL 'A' ADJUST. ";
            t1_desc_b = "";

            t1_detail_1 = fin_tot_a_a_r;
            t1_detail_2 = fin_tot_a_rev;
            t1_detail_3 = fin_tot_a_cash;
            t1_detail_4 = Util.NumInt(fin_tot_a_nbr);
            nbr_lines_2_advance = 2;
            //     perform tb0-write-line	thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            //move "FINAL 'C' PAYMENTS"  to t1-desc.
            //t1_desc_grp = "FINAL 'C' PAYMENTS";
            t1_desc_a = "FINAL 'C' PAYMENTS";
            t1_desc_b = "";

            t1_detail_1 = fin_tot_c_a_r;
            t1_detail_2 = fin_tot_c_rev;
            t1_detail_3 = fin_tot_c_cash;
            t1_detail_4 = Util.NumInt(fin_tot_c_nbr);
            nbr_lines_2_advance = 2;
            //     perform tb0-write-line	thru	tb0-99-exit.;

            tb0_write_line();
            tb0_99_exit();
        }

        private void yb1_99_exit()
        {            
            //     exit.;
        }

        private void za0_common_error()
        {            

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;

            if (err_ind == 7)
            {
                Console.WriteLine("NO CLAIMS FOR THIS BATCH " + err_msg_7_key);
            }
            else if (err_ind == 8)
            {
                Console.WriteLine("CLAIMS READ APPROX ERROR" + err_msg_8_key);
            }
            else if (err_ind == 9)
            {
                Console.WriteLine("CLAIMS STATUS ERROR 23 OR 99" + err_msg_9_key);
            }
            else if (err_ind == 10)
            {
                Console.WriteLine("CLAIMS INVALID KEY TYPE " + err_msg_10_key);
            }
            else
            {
                Console.WriteLine(" ERROR -  " + err_msg_comment);
            }

            //     display confirm.;
            //     stop " ".;
            //     display blank-line-24.;
        }

        private void za0_99_exit()
        {            
            //     exit.;
        }

        private void zb0_print_totals_summary()
        {
            
            ctr_lines = 98;
            sw_printed_bat_type = "N";
            sw_printed_adj_type = "N";

            //     perform zc0-process-batch-totals	thru	zc0-99-exit;
            // 	    varying ss-type;
            // 	    from  1;
            // 	    by    1;
            // 	    until   ss-type > max-nbr-types.;

            ss_type = 1;
            do
            {
                zc0_process_batch_totals();
                zc0_99_exit();
                ss_type++;
            } while (ss_type < max_nbr_types);


            ss_type = ss_grand_tot;
            //     perform zc0-process-batch-totals	thru	zc0-99-exit.;

            zc0_process_batch_totals();
            zc0_99_exit();
        }

        private void zb0_99_exit()
        {            
            //     exit.;
        }

        private void zc0_process_batch_totals()
        {            

            //     perform zd0-prt-agent-vals-and-sum	thru	zd0-99-exit;
            // 	    varying ss-agent;
            // 	    from  1;
            // 	    by    1;
            // 	    until    ss-agent > max-nbr-agents.;

            ss_agent = 1;
            do
            {
                zd0_prt_agent_vals_and_sum();
                zd0_99_exit();
                ss_agent++;
            } while (ss_agent <= max_nbr_agents);



            // if ss-type not =     ss-claims and ss-grand-tot  then            
            if (ss_type != ss_claims && ss_type != ss_grand_tot)
            {
                // 	   if sw-printed-adj-type = "Y" then       
                if (Util.Str(sw_printed_adj_type).ToUpper().Equals("Y"))
                {
                    //t1_desc_grp = " TOTAL";
                    t1_desc_a = "             TOTAL";
                    t1_desc_b = "";
                    ss_type_from = ss_type;
                    ss_agent = ss_agent_tot;
                    // 	       perform tg0-move-vals-to-line	thru	tg0-99-exit;
                    tg0_move_vals_to_line();
                    tg0_99_exit();
                    // 	       perform tb0-write-line		thru	tb0-99-exit;
                    tb0_write_line();
                    tb0_99_exit();
                }
                else
                {
                    // 	       next sentence;
                }
            }
            else
            {
                // 	    next sentence.;
            }

            sw_printed_adj_type = "N";

            // if ss-type not = ss-grand-tot  then;          
            if (ss_type != ss_grand_tot)
            {
                ss_type_from = ss_type;
                ss_type_to = ss_type_tot;
                //     perform te0-roll-and-zero-totals		thru	te0-99-exit;
                //     	        varying ss-agent-from;
                // 	        from  1;
                // 	        by    1;
                // 	        until   ss-agent-from > max-nbr-agents + 1.;
                ss_agent_from = 1;
                do
                {
                    te0_roll_and_zero_totals();
                    te0_99_exit();
                    ss_agent_from++;
                } while (ss_agent_from <= (max_nbr_agents + 1));
            }

            // if ss-type = ss-claims or ss-adj-r or ss-pay-c or ss-grand-tot then;            
            // 	  if sw-printed-bat-type = "Y" then            
            //        sw_printed_bat_type = "N";
            //        nbr_lines_2_advance = 2;
            //        t1_desc = " TOTALS";
            // 	      if ss-type = ss-grand-tot then            
            //           ss_type_from = ss_grand_tot;
            //           ss_agent = ss_agent_tot;
            // 	         perform tg0-move-vals-to-line	thru	tg0-99-exit;
            // 	         perform tb0-write-line		thru	tb0-99-exit;
            // 	      else;
            //           ss_type_from = ss_type_tot;
            //           ss_agent = ss_agent_tot;
            // 	         perform tg0-move-vals-to-line	thru	tg0-99-exit;
            // 	         perform tb0-write-line		thru	tb0-99-exit;
            // 		     perform tc1-roll-type-tot-to-grand;
            // 						thru	tc1-99-exit;
            // else if ss-type not = ss-grand-tot then            
            // 	        perform tc1-roll-type-tot-to-grand;
            // 	                                      	thru	tc1-99-exit.;

            // if ss-type = ss-claims or ss-adj-r or ss-pay-c or ss-grand-tot then;            
            //   if (ss_type == ss_claims || ss_type ==  ss_adj_r  ||  ss_type == ss_pay_c || ss_type == ss_grand_tot )  {
            if (ss_type == ss_claims || ss_type == ss_adj_r || ss_type == ss_pay_c || ss_type == ss_grand_tot || ss_type == ss_pay_m)  // added ss_type == ss_pay_m
            {
                // 	  if sw-printed-bat-type = "Y" then            
                if (Util.Str(sw_printed_bat_type).ToUpper().Equals("Y"))
                {
                    sw_printed_bat_type = "N";
                    nbr_lines_2_advance = 2;
                    //t1_desc_grp = " TOTALS";
                    t1_desc_a = "    TOTALS";
                    t1_desc_b = "";
                    // 	      if ss-type = ss-grand-tot then            
                    if (ss_type == ss_grand_tot)
                    {
                        ss_type_from = ss_grand_tot;
                        ss_agent = ss_agent_tot;
                        // 	         perform tg0-move-vals-to-line	thru	tg0-99-exit;
                        tg0_move_vals_to_line();
                        tg0_99_exit();
                        // 	         perform tb0-write-line		thru	tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();
                    }
                    else
                    {
                        ss_type_from = ss_type_tot;
                        ss_agent = ss_agent_tot;
                        // 	       perform tg0-move-vals-to-line	thru	tg0-99-exit;
                        // if (!Util.Str(t1_desc_a).Trim().ToUpper().Equals("TOTALS"))
                        if (ss_type != ss_adj_a && ss_type != ss_adj_b && ss_type != ss_adj_r)
                        {
                            tg0_move_vals_to_line();
                        }
                        tg0_99_exit();
                        // 	         perform tb0-write-line		thru	tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();
                        // 		     perform tc1-roll-type-tot-to-grand thru	tc1-99-exit;                        
                        tc1_roll_type_tot_to_grand();
                        tc1_99_exit();
                    }
                }
            }
            // else if ss-type not = ss-grand-tot then            
            else if (ss_type != ss_grand_tot)
            {
                //   perform tc1-roll-type-tot-to-grand thru	tc1-99-exit.;
                tc1_roll_type_tot_to_grand();
                tc1_99_exit();
            }
        }

        private void zc0_99_exit()
        {            
            //     exit.;
        }

        private void zd0_prt_agent_vals_and_sum()
        {            

            // add ss-nbr, ss-offset 		giving ss-temp1.;
            ss_temp1 = ss_nbr + ss_offset;

            // if tbl-tot (ss-type, ss-agent, ss-nbr) = zero  and tbl-tot (ss-type, ss-agent, ss-temp1 ) = zero then            
            if (tbl_tot[ss_type, ss_agent, ss_nbr] == 0 && tbl_tot[ss_type, ss_agent, ss_temp1] == 0)
            {
                // 	  go to zd0-99-exit.;
                zd0_99_exit();
                return;
            }

            t1_desc_grp = "";
            t1_desc_a = "";
            t1_desc_b = "";

            // if sw-printed-bat-type = "N" then;       
            if (sw_printed_bat_type.ToUpper().Equals("N"))
            {
                sw_printed_bat_type = "Y";
                t1_desc_a = desc_bat_type[ss_type];
                nbr_lines_2_advance = 3;
            }

            // if sw-printed-adj-type = "N" then           
            if (sw_printed_adj_type.ToUpper().Equals("N"))
            {
                sw_printed_adj_type = "Y";
                t1_desc_b = desc_adj_type[ss_type];
            }

            t1_dash = "-";
            //     subtract 1				from	ss-agent;
            // 					giving	t1-agent-cd.;
            t1_agent_cd = ss_agent - 1;

            ss_type_from = ss_type;
            //     perform tg0-move-vals-to-line	thru	tg0-99-exit.;
            tg0_move_vals_to_line();
            tg0_99_exit();

            //     perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            // if ss-type = ss-grand-tot then            
            if (ss_type == ss_grand_tot)
            {
                // 	  go to zd0-99-exit.;
                zd0_99_exit();
                return;
            }

            //     add tbl-tot (ss-type, ss-agent, 1 )		to tbl-tot (ss-type    ,ss-agent-tot, 1 ).;
            tbl_tot[ss_type, ss_agent_tot, 1] += tbl_tot[ss_type, ss_agent, 1];
            //     add tbl-tot (ss-type, ss-agent, 2 )		to tbl-tot (ss-type    ,ss-agent-tot, 2 ).;
            tbl_tot[ss_type, ss_agent_tot, 2] += tbl_tot[ss_type, ss_agent, 2];
            //     add tbl-tot (ss-type, ss-agent, 3 )		to tbl-tot (ss-type    ,ss-agent-tot, 3 ).;
            tbl_tot[ss_type, ss_agent_tot, 3] += tbl_tot[ss_type, ss_agent, 3];
            //     add tbl-tot (ss-type, ss-agent, 4 )		to tbl-tot (ss-type    ,ss-agent-tot, 4 ).;
            tbl_tot[ss_type, ss_agent_tot, 4] += tbl_tot[ss_type, ss_agent, 4];
            //     add tbl-tot (ss-type, ss-agent, 5 )		to tbl-tot (ss-type    ,ss-agent-tot, 5 ).;
            tbl_tot[ss_type, ss_agent_tot, 5] += tbl_tot[ss_type, ss_agent, 5];
            //     add tbl-tot (ss-type, ss-agent, 6 )		to tbl-tot (ss-type    ,ss-agent-tot, 6 ).;
            tbl_tot[ss_type, ss_agent_tot, 6] += tbl_tot[ss_type, ss_agent, 6];
            //     add tbl-tot (ss-type, ss-agent, 7 )		to tbl-tot (ss-type    ,ss-agent-tot, 7 ).;
            tbl_tot[ss_type, ss_agent_tot, 7] += tbl_tot[ss_type, ss_agent, 7];
            //     add tbl-tot (ss-type, ss-agent, 8 )		to tbl-tot (ss-type    ,ss-agent-tot, 8 ).;
            tbl_tot[ss_type, ss_agent_tot, 8] += tbl_tot[ss_type, ss_agent, 8];
        }

        private void zd0_99_exit()
        {            
            //     exit.;
        }

        private void zf0_print_non_proc_tots()
        {            

            //move fin-tot - desc(ss)         to t1-desc.
            t1_desc_grp = fin_tot_desc[ss];
            t1_desc_a = Util.Str(t1_desc_grp).PadRight(18, ' ').Substring(0, 13);
            t1_desc_b = Util.Str(t1_desc_grp).PadRight(18, ' ').Substring(13, 5);

            t1_detail_1 = fin_tot_a_r[ss];
            t1_detail_2 = fin_tot_rev[ss];
            t1_detail_4 = fin_tot_nbr[ss];

            nbr_lines_2_advance = 2;
            //  perform tb0-write-line			thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();
        }

        private void zf0_99_exit()
        {            
            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate()
        {            

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {            

            //     exit.;
        }

        private void MoveSpaceToT1PrintLine()
        {            

            t1_desc_a = "";
            t1_desc_b = "";
            t1_dash = "";
            t1_agent_cd = 0;
            t1_detail_1 = 0;
            t1_detail_2 = 0;
            t1_detail_3 = 0;
            t1_detail_4 = 0;
            t1_detail_5 = 0;
            t1_detail_6 = 0;
            t1_detail_7 = 0;
            t1_detail_8 = 0;
        }

        private string h1_head_grp()
        {            

            return "R004_C/".PadRight(7, ' ') +
                           Util.Str(h1_clinic_nbr).PadLeft(2, '0') +
                           new string(' ', 6) +
                           "P.E.D.".PadRight(7, ' ') +
                           Util.BlankWhenZero(h1_ped_yy, 4) +
                           "/" +
                           Util.BlankWhenZero(h1_ped_mm, 2) +
                           "/" +
                           Util.BlankWhenZero(h1_ped_dd, 2) +
                           new string(' ', 7) +
                           "* CYCLE CLAIMS AND ADJUSTMENT TRANSACTION SUMMARY *".PadRight(58, ' ') +
                           "RUN DATE".PadRight(9, ' ') +
                           Util.Str(h1_date).PadRight(10, ' ') +
                           new string(' ', 6) +
                           "PAGE".PadRight(5, ' ') +
                           Util.ImpliedIntegerFormat("#,0", h1_page, 5, false);
        }

        private string h2_head_grp()
        {            

            return "CLINIC".PadRight(8, ' ') +
                          Util.BlankWhenZero(h2_clinic_nbr, 2) +
                          new string(' ', 2) +
                          "CYCLE".PadRight(6, ' ') +
                          Util.BlankWhenZero("#", h2_cycle_nbr, 3) +
                          new string(' ', 9) +
                          "-----------".PadRight(11, ' ') +
                          " BATCH   CONTROL  FILE-".PadRight(23, ' ') +
                          "-------------".PadRight(20, ' ') +
                          "--------------".PadRight(14, ' ') +
                          "----CLAIMS  MASTER---------------".PadRight(35, ' ');
        }

        private string h3_head_grp()
        {            

            return new string(' ', 17) +
                           "AGENT".PadRight(12, ' ') +
                           "NET A/R".PadRight(14, ' ') +
                           " NET REV".PadRight(15, ' ') +
                           "CASH AMT".PadRight(15, ' ') +
                           "NBR".PadRight(10, ' ') +
                           "OMA AMT".PadRight(14, ' ') +
                           "OHIP AMT".PadRight(15, ' ') +
                           "CASH AMT".PadRight(15, ' ') +
                           "NBR".PadRight(5, ' ');
        }

        private string t1_print_line_grp(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                t1_desc_a = "";
                t1_desc_b = "";
                t1_dash = "";
                t1_agent_cd = 0;
                t1_detail_1 = 0;
                t1_detail_2 = 0;
                t1_detail_3 = 0;
                t1_detail_4 = 0;
                t1_detail_5 = 0;
                t1_detail_6 = 0;
                t1_detail_7 = 0;
                t1_detail_8 = 0;
                return string.Empty;
            }
            else
            {
                string retValue = string.Empty;

                if (Util.Str(t1_desc_a).Trim().Equals("TOTAL") || Util.Str(t1_desc_b).Trim().Equals("JUST.") || Util.Str(t1_desc_b).Trim().Equals("YMENT") ||
                    Util.Str(t1_desc_a).Trim().ToUpper().Contains("FINAL"))
                {
                    retValue = Util.Str(t1_desc_a) +
                                         Util.Str(t1_desc_b) +
                                         Util.Str(t1_dash).PadRight(1, ' ') +
                                         new string(' ', 1) +
                                         " " +
                                         new string(' ', 2) +
                                         Util.ImpliedDecimalFormat("#,0.00", t1_detail_1, 2, 14) +
                                         new string(' ', 1) +
                                         Util.ImpliedDecimalFormat("#,0.00", t1_detail_2, 2, 14) +
                                         new string(' ', 2) +
                                         Util.ImpliedDecimalFormat("#,0.00", t1_detail_3, 2, 13) +
                                         new string(' ', 2) +
                                         Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                                         new string(' ', 1) +
                                         Util.ImpliedDecimalFormat("#,0.00", t1_detail_5, 2, 14) +
                                         new string(' ', 1) +
                                         Util.ImpliedDecimalFormat("#,0.00", t1_detail_6, 2, 14) +
                                         new string(' ', 2) +
                                         Util.ImpliedDecimalFormat("#,0.00", t1_detail_7, 2, 13) +
                                         new string(' ', 2) +
                                         string.Format("{0:#,0}", t1_detail_8).PadLeft(7, ' ') +
                                         new string(' ', 2);

                    if (Util.Str(t1_desc_b).Trim().Equals("JUST.") || Util.Str(t1_desc_b).Trim().Equals("YMENT") || Util.Str(t1_desc_a).Trim().Equals("FINAL 'A' ADJUST.") || Util.Str(t1_desc_a).Trim().Equals("FINAL 'C' PAYMENTS"))
                    {
                        if (Util.NumInt(t1_detail_5) == 0 && Util.NumInt(t1_detail_6) == 0 && Util.NumInt(t1_detail_7) == 0 && Util.NumInt(t1_detail_8) == 0)
                        {
                            retValue = Util.Str(t1_desc_a) +
                                       Util.Str(t1_desc_b) +
                                       Util.Str(t1_dash).PadRight(1, ' ') +
                                       new string(' ', 1) +
                                       " " +
                                       new string(' ', 2) +
                                       Util.ImpliedDecimalFormat("#,0.00", t1_detail_1, 2, 14) +
                                       new string(' ', 1) +
                                       Util.ImpliedDecimalFormat("#,0.00", t1_detail_2, 2, 14) +
                                       new string(' ', 2) +
                                       Util.ImpliedDecimalFormat("#,0.00", t1_detail_3, 2, 13) +
                                       new string(' ', 2) +
                                       Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                                       new string(' ', 1) +
                                       new string(' ', 14) +   // Util.ImpliedDecimalFormat("#,0.00", t1_detail_5, 2, 14) +
                                       new string(' ', 1) +
                                       new string(' ', 14) +  //Util.ImpliedDecimalFormat("#,0.00", t1_detail_6, 2, 14) +
                                       new string(' ', 2) +
                                       new string(' ', 13) +   //Util.ImpliedDecimalFormat("#,0.00", t1_detail_7, 2, 13) +
                                       new string(' ', 2) +
                                       new string(' ', 7) +  //string.Format("{0:#,0}", t1_detail_8).PadLeft(7, ' ') +
                                       new string(' ', 2);
                        }
                    }
                }
                else if (Util.Str(t1_desc_a).Trim().Equals("TOTALS"))
                {
                    retValue = Util.Str(t1_desc_a).PadRight(13, ' ') +
                                     Util.Str(t1_desc_b).PadRight(5, ' ') +
                                     Util.Str(t1_dash).PadRight(1, ' ') +
                                     new string(' ', 1) +
                                     " " +
                                     new string(' ', 2) +
                                     Util.ImpliedDecimalFormat("#,0.00", t1_detail_1, 2, 14) +
                                     new string(' ', 1) +
                                     Util.ImpliedDecimalFormat("#,0.00", t1_detail_2, 2, 14) +
                                     new string(' ', 2) +
                                     Util.ImpliedDecimalFormat("#,0.00", t1_detail_3, 2, 13) +
                                     new string(' ', 2) +
                                     Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                                     new string(' ', 1) +
                                     Util.ImpliedDecimalFormat("#,0.00", t1_detail_5, 2, 14) +
                                     new string(' ', 1) +
                                     Util.ImpliedDecimalFormat("#,0.00", t1_detail_6, 2, 14) +
                                     new string(' ', 2) +
                                     Util.ImpliedDecimalFormat("#,0.00", t1_detail_7, 2, 13) +
                                     new string(' ', 2) +
                                     string.Format("{0:#,0}", t1_detail_8).PadLeft(7, ' ') +
                                     new string(' ', 2);
                }
                else
                {
                    retValue = Util.Str(t1_desc_a).PadRight(13, ' ').Substring(0, 13) +
                                    Util.Str(t1_desc_b).PadRight(5, ' ').Substring(0, 5) +
                                    Util.Str(t1_dash).PadRight(1, ' ') +
                                    new string(' ', 1) +
                                    Util.Str(t1_agent_cd).PadLeft(1, '0') +
                                    new string(' ', 2) +
                                    Util.ImpliedDecimalFormat("#,0.00", t1_detail_1, 2, 14) +
                                    new string(' ', 1) +
                                    Util.ImpliedDecimalFormat("#,0.00", t1_detail_2, 2, 14) +
                                    new string(' ', 2) +
                                    Util.ImpliedDecimalFormat("#,0.00", t1_detail_3, 2, 13) +
                                    new string(' ', 2) +
                                    Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                                    new string(' ', 1) +
                                    Util.ImpliedDecimalFormat("#,0.00", t1_detail_5, 2, 14) +
                                    new string(' ', 1) +
                                    Util.ImpliedDecimalFormat("#,0.00", t1_detail_6, 2, 14) +
                                    new string(' ', 2) +
                                    Util.ImpliedDecimalFormat("#,0.00", t1_detail_7, 2, 13) +
                                    new string(' ', 2) +
                                    string.Format("{0:#,0}", t1_detail_8).PadLeft(7, ' ') +
                                    new string(' ', 2);
                }

                return retValue;
            }
        }

        #endregion
    }
}

