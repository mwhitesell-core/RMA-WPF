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
using System.Collections;

namespace rma.Views
{
    public class R001bViewModel: CommonFunctionScr
    {

        public R001bViewModel()
        {

        }

        #region FD Section
        // FD: print_file
        private Print_record objPrint_record = null;
        private ObservableCollection<Print_record> Print_record_Collection;

	 // FD: batch_ctrl_file	Copy : f001_batch_control_file.fd
	    private F001_BATCH_CONTROL_FILE objBatctrl_rec = null;
        private ObservableCollection<F001_BATCH_CONTROL_FILE> Batctrl_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        private ReportPrint objPrintFile = null;

        #endregion

        #region Properties
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

        private int _doc_mstr_reads;
        public int doc_mstr_reads
        {
            get
            {
                return _doc_mstr_reads;
            }
            set
            {
                if (_doc_mstr_reads != value)
                {
                    _doc_mstr_reads = value;
                    RaisePropertyChanged("doc_mstr_reads");
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


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name = "r001b";
        private string option;
        private string const_mstr_rec_nbr;
        private int max_nbr_lines = 55;
        private int ctr_page;
        private int ctr_line;
        private string feedback_batctrl_file;
        private string feedback_iconst_mstr;
        private int hold_clinic_nbr;
        private string ws_reply;

        private string ws_date_sv_grp;
        private int ws_date_sv_yy;
        private int ws_date_sv_mm;
        private int ws_date_sv_dd;
        private string eof_batctrl_file = "N";
        //private string common_status_file;
        private string status_cobol_batctrl_file = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_prt_file = "0";
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string last_page_flag;
        private string last_page = "Y";
        private string not_last_page = "N";

        private string counters_grp;
        //private int ctr_batctrl_file_reads;
        //private int doc_mstr_reads;
        private int nbr_lines_to_advance;
        private string sw_printed_bat_type;
        private string sw_printed_adj_type;

        private string tbl_totals_grp;
        private string[] tbl_bat_type_and_tots = new string[9];
        private string[,] tbl_agent_and_sums = new string[9, 12];
        private decimal[,,] tbl_tot = new decimal[9, 12,11];

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
        private int ss_a_r = 1;
        private int ss_rev = 2;
        private int ss_cash = 3;
        private int ss_nbr_claims = 4;
        private int ss_nbr_svcs = 5;
        private int ss_offset = 5;
        private int ss_cyc_offset = 0;
        private int ss_mtd_offset = 5;
        private int cyc_mtd_offset;

        private string tbl_batch_type_desciptions_grp;
        private string tbl_batch_type_descs_grp;
        private string filler = "claims          ";
        /*private string filler = "adjustments- 'a'";
        private string filler = "adjustments- 'b'";
        private string filler = "adjustments- 'r'";
        private string filler = "PAYMENTS   - 'M'";
        private string filler = "PAYMENTS   - 'C'";
        private string filler = "                ";
        private string filler = "GRAND TOTALS    ";*/
        private string tbl_batch_type_descs_r_grp;
        private string[] batch_descs = new string[9];
        //private string[] desc_bat_type = new string[9];
        private string[] desc_bat_type = { "", "CLAIMS       ", "ADJUSTMENTS- ", "ADJUSTMENTS- ", "ADJUSTMENTS- ", "PAYMENTS   - ", "PAYMENTS   - ", "             ", "GRAND TOTALS " };
        //private string[] desc_adj_type = new string[9];
        private string[] desc_adj_type = { "", "     ", "'A'  ", "'B'  ", "'R'  ", "'M'  ", "'C'  ", "     ", "     " };

        private string clinic_totals_grp;
        private decimal clinic_tot_1;
        private decimal clinic_tot_2;
        private decimal clinic_tot_3;
        private decimal clinic_tot_4;
        private decimal clinic_tot_5;
        private decimal clinic_tot_6;
        private decimal clinic_tot_7;
        private decimal clinic_tot_8;
        private decimal clinic_tot_9;
        private decimal clinic_tot_10;
        private decimal clinic2_tot_1;
        private decimal clinic2_tot_2;
        private decimal clinic2_tot_3;
        private decimal clinic2_tot_4;
        private decimal clinic2_tot_5;
        private decimal clinic2_tot_6;
        private decimal clinic2_tot_7;
        private decimal clinic2_tot_8;
        private decimal clinic2_tot_9;
        private decimal clinic2_tot_10;

        private string final_totals_grp;
        private decimal fin_tot_1;
        private decimal fin_tot_2;
        private decimal fin_tot_3;
        private decimal fin_tot_4;
        private decimal fin_tot_5;
        private decimal fin_tot_6;
        private decimal fin_tot_7;
        private decimal fin_tot_8;
        private decimal fin_tot_9;
        private decimal fin_tot_10;

        private string disk_totals_grp;
        private decimal[] disk_tot_tab = new decimal[11];

        private string disk_finals_grp;
        private decimal[] disk_grnd_tab = new decimal[11];

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "invalid reply";
        private string filler = "NO CONSTANTS MASTER SUPPLIED";
        private string filler = "INVALID CLINIC NBR";
        private string filler = "NO BATCTRL FILE SUPPLIED";*/
        private string error_messages_r_grp;
        private string[] err_msg = { "", "invalid reply", "NO CONSTANTS MASTER SUPPLIED", "INVALID CLINIC NBR", "NO BATCTRL FILE OR NO CORRESP CLINICS OR NO BALANCED BATCHES" };
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

        //private string h1_head_grp;
        //private string filler = "r001b /";
        private int h1_clinic_nbr;
        /*private string filler = "";
        private string filler = "-  COMPLETE BATCH SUMMARY REPORT  -";
        private string filler = "PAGE";*/
        private int h1_page;

        //private string h2_head_grp;
        //private string filler = "  CYCLE #";
        private int h2_cycle;
        //private string filler = "  PERIOD END:";
        private int h2_period_end_yy;
        //private string filler = "/";
        private int h2_period_end_mm;
        //private string filler = "/";
        private int h2_period_end_dd;
        //private string filler = "";
        private string h2_clinic_name;

        //private string h3_head_grp;
        /*private string filler = "";
        private string filler = "BATCH";
        private string filler = "AG";
        private string filler = "bat /adj";
        private string filler = "DOC";
        private string filler = "HOS";
        private string filler = "LOC";
        private string filler = "I/O";
        private string filler = "DATE";
        private string filler = "A/R";
        private string filler = "REVENUE";
        private string filler = "CASH";
        private string filler = "NBR";
        private string filler = "CYCLE";
        private string filler = "P.E.D.";
        private string filler = "STATUS"; */

        //private string h4_head_grp;
        /*private string filler = "";
        private string filler = "NUMBER";
        private string filler = "DP";
        private string filler = "TYPE/CODE";
        private string filler = "REG";
        private string filler = "ENTERED";
        private string filler = "AMOUNT";
        private string filler = "AMOUNT";
        private string filler = "AMOUNT";
        private string filler = "CLAIMS";
        private string filler = "NBR";*/

        //private string h5_head_grp;
        //private string filler = "CLINIC";
        private int h5_clinic_nbr;
        /*private string filler = "";
        private string filler = "---------------";
        private string filler = "M. T. D.    T O T A L S";
        private string filler = "------------";
        private string filler = "----------------";
        private string filler = "Y. T. D.    T O T A L S-----------";*/

        //private string h6_head_grp;
        /*private string filler = "";
        private string filler = "AGENT";
        private string filler = "net a/r";
        private string filler = " NET REV";
        private string filler = "CASH";
        private string filler = "CLAIMS";
        private string filler = "SVC'S";
        private string filler = "net a/r";
        private string filler = " NET REV";
        private string filler = "CASH";
        private string filler = "CLAIMS";
        private string filler = "SVC'S";*/

        //private string print_line_grp;
        private string l1_print_line_grp;
        private string l1_batch_nbr_grp;
        private int l1_batch_nbr_1_2;
        private string l1_doc_nbr;
        private int l1_week;
        private int l1_day;
        private string l1_slash_1a;
        private int l1_dept_code;
        //private string filler;
        private int l1_agent_code;
        //private string filler;
        private string l1_batch_type;
        private string l1_slash_1;
        private string l1_adj_code;
        private string l1_dash;
        private string l1_adj_cd_sub_type;
        private int l1_doc_nbr_ohip;
        //private string filler;
        private string l1_hos;
        //private string filler;
        private string l1_loc_grp;
        private string l1_loc_1;
        private string l1_loc_2_4;
        //private string filler;
        private string l1_i_o_pat_ind;
        private int l1_date_yy;
        private string l1_slash_2;
        private int l1_date_mm;
        private string l1_slash_3;
        private int l1_date_dd;
        //private string filler;
        private decimal l1_amt_ar;
        //private string filler;
        private decimal l1_amt_rev;
        //private string filler;
        private decimal l1_amt_cash;
        //private string filler;
        private int l1_last_claim;
        //private string filler;
        private int l1_cycle;
        //private string filler;
        private int l1_ped_yy;
        private string l1_slash_4;
        private int l1_ped_mm;
        private string l1_slash_5;
        private int l1_ped_dd;
        //private string filler;
        private string l1_status;
        //private string filler;
        private string t1_print_line_grp;
        private string t1_desc_grp;
        private string t1_desc_a;
        private string t1_desc_b;
        private string t1_dash;
        //private string filler;
        private int t1_agent_cd;
        private decimal t1_detail_1;
        private decimal t1_detail_2;
        private decimal t1_detail_3;
        //private string filler;
        private int t1_detail_4;
        //private string filler;
        private int t1_detail_5;
        //private string filler;
        private decimal t1_detail_6;
        private decimal t1_detail_7;
        private decimal t1_detail_8;
        private int t1_detail_9;
        private int t1_detail_10;
        private string t1_final_line_grp;
        private string t1_fin_desc;
        private decimal t1_fin_detail_1;
        //private string filler;
        private decimal t1_fin_detail_2;
        //private string filler;
        private decimal t1_fin_detail_3;
        //private string filler;
        private int t1_fin_detail_4;
        //private string filler;
        private int t1_fin_detail_5;
        //private string filler;
        private string blank_line;
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
        private decimal t1_detail_1_totals;  //added
        private decimal t1_detail_2_totals;
        private decimal t1_detail_3_totals;        
        private int t1_detail_4_totals;        
        private int t1_detail_5_totals;        
        private decimal t1_detail_6_totals;
        private decimal t1_detail_7_totals;
        private decimal t1_detail_8_totals;
        private int t1_detail_9_totals;
        private int t1_detail_10_totals;


        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "12",Col = 25,Data1 = "BATCH SUMMARY REPORT - CONTINUE (Y/N) ?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-prog-in-prog.",Line = "14",Col = 30,Data1 = "R001B IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "3",Col = 20,Data1 = "NUMBER OF DOC-MSTR-FILE ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "3",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "doc_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "NUMBER OF BATCTRL-FILE ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_batctrl_file_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM R001B ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "PRINT REPORT IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private  void declaratives()
        {

        }

        private  void err_batctrl_file_section()
        {

            //     use after standard error procedure on batch-ctrl-file.;
        }

        private  void err_batctrl()
        {

            common_status_file = status_cobol_batctrl_file;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING BATCH CONTROL FILE".;
        }

        private  void err_constants_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private  void err_constants_mstr()
        {

            common_status_file = status_cobol_iconst_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING ICONSTANTS MASTER".;
        }

        private  void err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private  void err_doc_mstr()
        {

            //     stop "ERROR IN ACCESSING DOC MASTER ".;
            common_status_file = status_cobol_doc_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private  void end_declaratives()
        {

        }

        private  void main_line_section()
        {

        }

        public  void mainline()
        {

            try {

                objPrint_record = null;
                objPrint_record = new Print_record();

                Print_record_Collection = null;
                Print_record_Collection = new ObservableCollection<Print_record>();

                objBatctrl_rec = null;
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();

                Batctrl_rec_Collection = null;
                Batctrl_rec_Collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

                objIconst_mstr_rec = null;
                objIconst_mstr_rec = new ICONST_MSTR_REC();

                Iconst_mstr_rec_Collection = null;
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objDoc_mstr_rec = null;
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();

                Doc_mstr_rec_Collection = null;
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objPrintFile = null;
                objPrintFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

                // perform aa0-initialization		thru aa0-99-exit.;

                aa0_initialization();
                aa0_10_continue_y_n();
                aa0_99_exit();

                // perform ab0-processing		thru ab0-99-exit.;
                ab0_processing();
                ab0_99_exit();

                // perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
                az0_99_exit();

                //     stop run.;
            } catch (Exception e)
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

        private  void aa0_initialization()
        {

            //     accept sys-date			from 	date.;
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
            Console.WriteLine("BATCH SUMMARY REPORT - CONTINUE (Y/N) ? Y");
        }

        private  void aa0_10_continue_y_n()
        {

            ws_reply = "Y";

            // if ws-reply =   "Y"  or "N"  then                      
            // 	   if ws-reply = "Y" 	then            
            // 	      next sentence;
            // 	   else;
            // 	       stop run;
            //else;
            //    err_ind = 1;
            // 	  perform za0-common-error	thru 	za0-99-exit;
            // 	  go to aa0-10-continue-y-n.;

            //     display scr-prog-in-prog.;

            //     open input	batch-ctrl-file;
            //                 doc-mstr.;

            //     open input  iconst-mstr.;
            //     open output print-file.;

            //counters = 0;
            ctr_batctrl_file_reads = 0;
            doc_mstr_reads = 0;

            //tbl_totals = 0;
            tbl_totals_grp = "0";
            tbl_bat_type_and_tots = new string[9];
            tbl_agent_and_sums = new string[9, 12];  // todo...dimensions
            tbl_tot = new decimal[9, 12, 11];            // todo...

            //final_totals = 0;
            final_totals_grp = "0";
            fin_tot_1 = 0;
            fin_tot_2 = 0;
            fin_tot_3 = 0;
            fin_tot_4 = 0;
            fin_tot_5 = 0;
            fin_tot_6 = 0;
            fin_tot_7 = 0;
            fin_tot_8 = 0;
            fin_tot_9 = 0;
            fin_tot_10 = 0;

            //disk_totals = 0;
            disk_totals_grp = "0";
            disk_tot_tab = new decimal[11];

            //disk_finals = 0;
            disk_finals_grp = "0";
            disk_grnd_tab = new decimal[11];

            ctr_page = 0;
           
            ctr_line = 65;
            last_page_flag = "N";

            //print_line = "";
            MoveSpacesToPrintLine();

            blank_line = "";

            //objBatctrl_rec.batctrl_batch_nbr = "";
            objBatctrl_rec.BATCTRL_BATCH_NBR = "";

            // perform xf0-read-next-batch		thru	xf0-99-exit.;
            xf0_read_next_batch();
            xf0_99_exit();

            if (eof_batctrl_file.ToUpper().Equals("Y"))
            {
                 err_ind = 4;
                // perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            //  perform xd0-zero-clinic-totals	thru	xd0-99-exit.;
            xd0_zero_clinic_totals();
            xd0_99_exit();

            //  perform xb0-save-clinic-info	thru	xb0-99-exit.;
            xb0_save_clinic_info();
            xb0_99_exit();
        }

        private  void aa0_99_exit()
        {
            //     exit.;
        }

        private  void az0_end_of_job()
        {

            //  perform zb0-print-clinic-tots-summary 	thru	zb0-99-exit.;
            zb0_print_clinic_tots_summary();
            zb0_99_exit();

            //  perform xc1-add-to-fin-totals		thru	xc1-99-exit.;
            xc1_add_to_fin_totals();
            xc1_99_exit();

            //  perform ze0-move-and-print-fin-tot		thru	ze0-99-exit.;
            ze0_move_and_print_fin_tot();
            ze0_99_exit();

            //     close batch-ctrl-file;
            //           doc-mstr;
            // 	  iconst-mstr;
            // 	  print-file.;

            //     display blank-screen.;
            //     accept sys-time			from time.;

            //     display scr-closing-screen.;
            Console.WriteLine("NUMBER OF DOC-MSTR-FILE ACCESSES = " + doc_mstr_reads.ToString());
            Console.WriteLine("NUMBER OF BATCTRL - FILE ACCESSES = " + ctr_batctrl_file_reads.ToString());
            Console.WriteLine("PROGRAM R001B ENDING " + sys_yy.ToString() + "/" + sys_mm.ToString() + "/" + sys_dd.ToString() + " " + sys_hrs.ToString() + ":" + sys_min.ToString());
            Console.WriteLine("PRINT REPORT IS IN FILE - " + print_file_name);
            //     stop run.;
        }

        private  void az0_99_exit()
        {
            //     exit.;
        }

        private  void ab0_processing()
        {

            while (Util.Str(eof_batctrl_file).ToUpper().Equals("N"))
            {

                // if batctrl-bat-clinic-nbr-1-2	not = hold-clinic-nbr  then;     
                if (Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2)) != hold_clinic_nbr)
                {
                    //  perform xc0-print-clinic-totals	thru xc0-99-exit;
                    xc0_print_clinic_totals();
                    xc0_99_exit();

                    //  perform xc1-add-to-fin-totals	thru xc1-99-exit;
                    xc1_add_to_fin_totals();
                    xc1_99_exit();

                    // 	perform xd0-zero-clinic-totals	thru xd0-99-exit;
                    xd0_zero_clinic_totals();
                    xd0_99_exit();

                    // 	perform xb0-save-clinic-info	thru xb0-99-exit.;
                    xb0_save_clinic_info();
                    xb0_99_exit();
                }

                // perform ea0-move-fields		thru 	ea0-99-exit.;
                ea0_move_fields();
                ea0_99_exit();

                // perform ba0-write-detail-line	thru 	ba0-99-exit.;
                ba0_write_detail_line();
                ba0_99_exit();

                // if batctrl-batch-status < "4"  then;            
                if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).CompareTo("4") < 0)
                {
                    cyc_mtd_offset = ss_cyc_offset;
                    // 	  perform sa0-add-batch-totals	thru sa0-99-exit;
                    sa0_add_batch_totals();
                    sa0_99_exit();
                    cyc_mtd_offset = ss_mtd_offset;

                    // perform sa0-add-batch-totals	thru sa0-99-exit;
                    sa0_add_batch_totals();
                    sa0_99_exit();
                }
                else
                {
                    cyc_mtd_offset = ss_mtd_offset;
                    //  perform sa0-add-batch-totals	thru	sa0-99-exit.;
                    sa0_add_batch_totals();
                    sa0_99_exit();
                }

                //  perform xf0-read-next-batch		thru 	xf0-99-exit.;
                xf0_read_next_batch();
                xf0_99_exit();

                // if eof-batctrl-file = "N"  then;            
               /* if (Util.Str(eof_batctrl_file).ToUpper().Equals("N"))
                {
                    // 	  go to ab0-processing;
                    ab0_processing();
                    return;
                }
                else
                {
                    //    next sentence.;
                } */
            }
        }

        private  void ab0_99_exit()
        {
            //     exit.;
        }

        private  void ba0_write_detail_line()
        {

            //     add 1				to ctr-line.;
            ctr_line++;

            if (ctr_line > max_nbr_lines)
            {
                // perform xa0-headings		thru xa0-99-exit.;
                xa0_headings();
                xa0_99_exit();
            }

            // write print-record    from print-line after advancing 1 line.;            
            objPrint_record.Print_record1 = print_line_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);
            objPrint_record.Print_record1 = blank_line;
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();
        }

        private  void ba0_99_exit()
        {

            //     exit.;
        }

        private  void ea0_move_fields()
        {

            l1_batch_nbr_1_2 = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8,' ').Substring(0, 2));  //batctrl_bat_clinic_nbr_1_2;
            l1_doc_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(2, 3);  // batctrl_bat_doc_nbr;
            l1_week = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(5, 2));   //batctrl_bat_week;
            l1_day = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(7, 1));  //batctrl_bat_day;
            objDoc_mstr_rec.DOC_NBR = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(2, 3);  //batctrl_bat_doc_nbr;

            // perform xf1-read-doc-mstr		thru	xf1-99-exit.;
            xf1_read_doc_mstr();
            xf1_99_exit();

            l1_slash_1a = "/";

            l1_dept_code = Util.NumInt(objDoc_mstr_rec.DOC_DEPT);

            l1_agent_code = Util.NumInt(objBatctrl_rec.BATCTRL_AGENT_CD);

            l1_batch_type = Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE);
            l1_slash_1 = "/";

            l1_adj_code = Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD);

            // if batctrl-adj-cd-sub-type not = '0' then;        
            if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD_SUB_TYPE) != "0") {
                l1_adj_cd_sub_type = Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD_SUB_TYPE);
                l1_dash = "/";
            }

            l1_doc_nbr_ohip = Util.NumInt(objBatctrl_rec.BATCTRL_DOC_NBR_OHIP);
            l1_hos = Util.Str(objBatctrl_rec.BATCTRL_HOSP);
            l1_loc_1 = Util.Str(objBatctrl_rec.BATCTRL_LOC).PadRight(4, ' ').Substring(0,1);  //batctrl_loc1;
            l1_loc_2_4 = Util.Str(objBatctrl_rec.BATCTRL_LOC).PadRight(4, ' ').Substring(1, 3);  //batctrl_loc2_4;
            l1_i_o_pat_ind = Util.Str(objBatctrl_rec.BATCTRL_I_O_PAT_IND); // batctrl_i_o_pat_ind;
            ws_date_sv_grp = Util.Str(objBatctrl_rec.BATCTRL_DATE_BATCH_ENTERED); // batctrl_date_batch_entered;
            ws_date_sv_yy = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_BATCH_ENTERED).PadRight(8, ' ').Substring(0, 4));
            ws_date_sv_mm = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_BATCH_ENTERED).PadRight(8, ' ').Substring(4, 2));
            ws_date_sv_dd = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_BATCH_ENTERED).PadRight(8, ' ').Substring(6, 2));

            l1_date_yy = ws_date_sv_yy;
            l1_slash_2 = "/";
            l1_date_mm = ws_date_sv_mm;
            l1_slash_3 = "/";
            l1_date_dd = ws_date_sv_dd;

            l1_amt_ar = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);  //batctrl_calc_ar_due;
            l1_amt_rev = Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
            l1_amt_cash = Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);  //batctrl_manual_pay_tot;
            l1_last_claim = Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH); //batctrl_nbr_claims_in_batch;


            // if  ( batctrl-cycle-nbr		= iconst-clinic-cycle-nbr and batctrl-date-period-end	= iconst-date-period-end );            
            //         or    batctrl-date-period-end not = iconst-date-period-end then;            
            if (( Util.NumInt(objBatctrl_rec.BATCTRL_CYCLE_NBR) == Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR) && Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END) == Util.Str(Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY.ToString()).PadLeft(4, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM.ToString()).PadLeft(2, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD.ToString()).PadLeft(2, '0'))) ||
                 Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END) != Util.Str(Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY.ToString()).PadLeft(4, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM.ToString()).PadLeft(2, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD.ToString()).PadLeft(2, '0'))) {
                       l1_cycle = 0;
            }
            else {
                l1_cycle = Util.NumInt(objBatctrl_rec.BATCTRL_CYCLE_NBR); 
            }

            l1_ped_yy = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(0, 4)); // batctrl_date_period_end_yy;
             l1_slash_4 = "/";
             l1_ped_mm = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(4, 2)); //objBatctrl_rec.batctrl_date_period_end_mm;
             l1_slash_5 = "/";
             l1_ped_dd = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END).PadRight(8, ' ').Substring(6, 2));  //batctrl_date_period_end_dd;

            // if batctrl-batch-status = "4"  then;            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS) == "4") {
                   l1_status = "";
            }
            else {
                l1_status = Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS);  //batctrl_batch_status;
            }
        }

        private  void ea0_99_exit()
        {
            //     exit.;
        }

        private  void sa0_add_batch_totals()
        {

            //  perform sa1-find-ss-type 		thru	sa1-99-exit.;
            sa1_find_ss_type();
            sa1_99_exit();

            //     add  1, batctrl-agent-cd		giving	ss-agent.;
            ss_agent = Util.NumInt(objBatctrl_rec.BATCTRL_AGENT_CD) + 1;

            //     add cyc-mtd-offset, ss-a-r			giving ss-temp1.;
            ss_temp1 = cyc_mtd_offset + ss_a_r;

            //     add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);

            //     add cyc-mtd-offset, ss-rev			giving ss-temp1.;
            ss_temp1 = cyc_mtd_offset + ss_rev;

            //     add batctrl-calc-tot-rev 			to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);

            //     add cyc-mtd-offset, ss-cash			giving ss-temp1.;
            ss_temp1 = cyc_mtd_offset + ss_cash;

            //     add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);

            //     add cyc-mtd-offset, ss-nbr-claims		giving ss-temp1.;
            ss_temp1 = cyc_mtd_offset + ss_nbr_claims;

            //     add batctrl-nbr-claims-in-batch		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH);

            //     add cyc-mtd-offset, ss-nbr-svcs  		giving ss-temp1.;
            ss_temp1 = cyc_mtd_offset + ss_nbr_svcs;

            //     add batctrl-svc-act				to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_SVC_ACT);

            // if batctrl-batch-type = "C" and batctrl-adj-cd-sub-type = "D"  or batctrl-adj-cd-sub-type = "W"  then;            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD_SUB_TYPE).ToUpper().Equals("D") || Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD_SUB_TYPE).ToUpper().Equals("W") ) {
                //         add cyc-mtd-offset, ss-a-r       	giving ss-temp1;
                ss_temp1 = cyc_mtd_offset + ss_a_r;
                //         add batctrl-calc-ar-due     		to	disk-tot-tab (ss-temp1);
                disk_tot_tab[ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);
                //         add cyc-mtd-offset, ss-nbr-claims	giving ss-temp1;
                ss_temp1 = cyc_mtd_offset + ss_nbr_claims;
                //         add batctrl-nbr-claims-in-batch		to	disk-tot-tab (ss-temp1);
                disk_tot_tab[ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH);
                //         add cyc-mtd-offset, ss-nbr-svcs  	giving ss-temp1;
                ss_temp1 = cyc_mtd_offset + ss_nbr_svcs;
                //         add batctrl-svc-act			to	disk-tot-tab (ss-temp1).;
                disk_tot_tab[ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_SVC_ACT);
            }
        }

        private  void sa0_99_exit()
        {

            //     exit.;
        }

        private  void sa1_find_ss_type()
        {

            // if batctrl-batch-type = "C"  then            
            //     ss_type = ss_claims;
            // else if batctrl-batch-type = "A" then
            // 	    if batctrl-adj-cd = "A"  then            
            //         ss_type = ss_adj_a;
            // 	    else if batctrl-adj-cd = "B" then            
            //         ss_type = ss_adj_b;
            // 		else;
            //         ss_type = ss_adj_r
            // 	else if batctrl-adj-cd = "M"  then;            
            //      ss_type = ss_pay_m;
            // 	else;
            //     ss_type = ss_pay_c;

            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                ss_type = ss_claims;
            }
            else if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("A"))
            {
                if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("A"))
                {
                    ss_type = ss_adj_a;
                }
                else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("B"))
                {
                    ss_type = ss_adj_b;
                }
                else
                {
                    ss_type = ss_adj_r;
                }
            }
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("M") )
            {
                 ss_type = ss_pay_m;
            }
            else
            {
                ss_type = ss_pay_c;
            }
        }

        private  void sa1_99_exit()
        {
            //     exit.;
        }

        private  void tc1_roll_type_tot_to_grand()
        {

            ss_type_from = ss_type_tot;
            ss_type_to = ss_grand_tot;

            //  perform te0-roll-and-zero-totals	thru	te0-99-exit;
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
            } while (ss_agent_from <=  max_nbr_agents + 1);
        }

        private  void tc1_99_exit()
        {
            //     exit.;
        }

        private  void te0_roll_and_zero_totals()
        {

            //     add tbl-tot (ss-type-from, ss-agent-from, 1 )  to tbl-tot (ss-type-to, ss-agent-from, 1 ).;
            tbl_tot[ss_type_to, ss_agent_from, 1] += Util.NumDec(tbl_tot[ss_type_from, ss_agent_from, 1]);

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

            //     add tbl-tot (ss-type-from, ss-agent-from, 9 )  to tbl-tot (ss-type-to, ss-agent-from, 9 ).;
            tbl_tot[ss_type_to, ss_agent_from, 9] += tbl_tot[ss_type_from, ss_agent_from, 9];

            //     add tbl-tot (ss-type-from, ss-agent-from, 10 ) to tbl-tot (ss-type-to, ss-agent-from, 10 ).;
            tbl_tot[ss_type_to, ss_agent_from, 10] += tbl_tot[ss_type_from, ss_agent_from, 10];

            tbl_tot[ss_type_from, ss_agent_from, 1] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 2] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 3] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 4] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 5] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 6] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 7] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 8] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 9] = 0;
            tbl_tot[ss_type_from, ss_agent_from, 10] = 0;
        }

        private  void te0_99_exit()
        {

            //     exit.;
        }

        private  void tb0_write_line(int option = 1)
        {

            //     add  nbr-lines-to-advance				to	ctr-line.;
            ctr_line += nbr_lines_to_advance;

            if (ctr_line > max_nbr_lines)
            {
                // perform tc0-print-headings			thru	tc0-99-exit.;
                tc0_print_headings();
                tc0_99_exit();
            }

            //     write   print-record  from print-line      after advancing  nbr-lines-to-advance lines.;                       
            if (option == 2)
            {
                objPrint_record.Print_record1 = t1_final_line(); 
            }
            else
            {
                objPrint_record.Print_record1 = t1_print_line(); 
            }

            for (int i = 1; i < nbr_lines_to_advance; i++)
            {
                objPrintFile.print(true);
            }

            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();
            nbr_lines_to_advance = 1;
        }

        private  void tb0_99_exit()
        {
            //     exit.;
        }

        private  void tc0_print_headings()
        {

            //     add 1					to	ctr-page.;
            ctr_page++;
            h1_page = ctr_page;

            //     write print-record from h1-head after advancing page.;                        
            objPrint_record.Print_record1 = h1_head_grp();
            objPrintFile.PageBreak();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h2-head after advancing 2 lines.;            
            objPrint_record.Print_record1 = h2_head_grp();
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            if (last_page_flag.Equals(not_last_page))
            {
                h5_clinic_nbr = hold_clinic_nbr;
            }

            //     write print-record from h5-head after advancing 2 lines.;            
            objPrintFile.print(true);
            objPrint_record.Print_record1 = h5_head_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h6-head after advancing 1 line.;            
            objPrint_record.Print_record1 = h6_head_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from blank-line after advancing 1 line.;
            blank_line = new string(' ', 132);
            objPrint_record.Print_record1 = blank_line;
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            ctr_line = 6;
        }

        private  void tc0_99_exit()
        {
            //     exit.;
        }

        private  void tg0_move_vals_to_line(bool isAccumulate = true)
        {
            // move tbl-tot(ss - type - from, ss - agent, 1)  to t1-detail - 1.
            t1_detail_1 = tbl_tot[ss_type_from, ss_agent, 1];

            // move tbl - tot(ss - type - from, ss - agent, 2)   to t1-detail - 2.
            t1_detail_2 = tbl_tot[ss_type_from, ss_agent, 2];

            // move tbl - tot(ss - type - from, ss - agent, 3)   to t1-detail - 3.
            t1_detail_3= tbl_tot[ss_type_from, ss_agent, 3];

            // move tbl - tot(ss - type - from, ss - agent, 4)   to t1-detail - 4.
            t1_detail_4 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 4]);

            // move tbl - tot(ss - type - from, ss - agent, 5)   to t1-detail - 5.
            t1_detail_5 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 5]);

            // move tbl - tot(ss - type - from, ss - agent, 6)   to t1-detail - 6.
            t1_detail_6 = tbl_tot[ss_type_from, ss_agent, 6];

            // move tbl - tot(ss - type - from, ss - agent, 7)   to t1-detail - 7.
            t1_detail_7 = tbl_tot[ss_type_from, ss_agent, 7];

            // move tbl - tot(ss - type - from, ss - agent, 8)   to t1-detail - 8.
            t1_detail_8 = tbl_tot[ss_type_from, ss_agent, 8];

            // move tbl - tot(ss - type - from, ss - agent, 9)   to t1-detail - 9.
            t1_detail_9 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 9]);

            // move tbl - tot(ss - type - from, ss - agent, 10)  to t1-detail - 10.
            t1_detail_10 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 10]);
            if (isAccumulate)
            {
                Accum_total_var();
            }
        }

        private  void tg0_99_exit()
        {

            //     exit.;
        }

        private  void xa0_headings()
        {

            //     add 1				to ctr-page.;
            ctr_page++;

            h1_page = ctr_page;

            //     write print-record from h1-head after advancing page.;            
            objPrint_record.Print_record1 = h1_head_grp();
            objPrintFile.PageBreak();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h2-head after advancing 1 line.;            
            objPrint_record.Print_record1 = h2_head_grp();            
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h3-head after advancing 2 lines.;            
            objPrint_record.Print_record1 = h3_head_grp();
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h4-head after advancing 1 line.;            
            objPrint_record.Print_record1 = h4_head_grp();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from blank-line after advancing 1 line.;
            objPrint_record.Print_record1 = blank_line;
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            ctr_line = 6;
        }

        private  void xa0_99_exit()
        {

            //     exit.;
        }

        private  void xb0_save_clinic_info()
        {

            hold_clinic_nbr = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8,' ').Substring(0,2));  //batctrl_bat_clinic_nbr_1_2;

            objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2  = Util.NumDec(hold_clinic_nbr);

            //  read iconst-mstr;
            //  	invalid key;
            //          err_ind = 2;
            //  	    perform za0-common-error	thru 	za0-99-exit;
            //  	    go to az0-end-of-job.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumDec(hold_clinic_nbr)
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                 err_ind = 2;
                //  perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
            h2_cycle = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
            h2_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h2_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h2_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);
        }

        private  void xb0_99_exit()
        {

            //     exit.;
        }

        private  void xc0_print_clinic_totals()
        {

            //     perform zb0-print-clinic-tots-summary;
            // 					thru 	zb0-99-exit.;

            zb0_print_clinic_tots_summary();
            zb0_99_exit();
        }

        private  void xc0_99_exit()
        {
            //     exit.;
        }

        private  void xc1_add_to_fin_totals()
        {

            //  if hold-clinic-nbr > 59 and hold-clinic-nbr < 67  then;
            if (hold_clinic_nbr > 59 && hold_clinic_nbr < 67) {
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	clinic-tot-1;
                clinic_tot_1 += tbl_tot[ss_grand_tot, ss_agent_tot, 1];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	clinic-tot-2;
                clinic_tot_2 += tbl_tot[ss_grand_tot, ss_agent_tot, 2];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	clinic-tot-3;
                clinic_tot_3 += tbl_tot[ss_grand_tot, ss_agent_tot, 3];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	clinic-tot-4;
                clinic_tot_4 += tbl_tot[ss_grand_tot, ss_agent_tot, 4];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	clinic-tot-5;
                clinic_tot_5 += tbl_tot[ss_grand_tot, ss_agent_tot, 5];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	clinic-tot-6;
                clinic_tot_6 += tbl_tot[ss_grand_tot, ss_agent_tot, 6];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	clinic-tot-7;
                clinic_tot_7 += tbl_tot[ss_grand_tot, ss_agent_tot, 7];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	clinic-tot-8;
                clinic_tot_8 += tbl_tot[ss_grand_tot, ss_agent_tot, 8];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	clinic-tot-9;
                clinic_tot_9 += tbl_tot[ss_grand_tot, ss_agent_tot, 9];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	clinic-tot-10 .;
                clinic_tot_10 += tbl_tot[ss_grand_tot, ss_agent_tot, 10];
            }


            // if hold-clinic-nbr > 70 and hold-clinic-nbr < 76 then;            
            if (hold_clinic_nbr > 70 && hold_clinic_nbr < 76) {
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	clinic2-tot-1;
                clinic2_tot_1 += tbl_tot[ss_grand_tot, ss_agent_tot, 1];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	clinic2-tot-2;
                clinic2_tot_2 += tbl_tot[ss_grand_tot, ss_agent_tot, 2];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	clinic2-tot-3;
                clinic2_tot_3 += tbl_tot[ss_grand_tot, ss_agent_tot, 3];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	clinic2-tot-4;
                clinic2_tot_4 += tbl_tot[ss_grand_tot, ss_agent_tot, 4];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	clinic2-tot-5;
                clinic2_tot_5 += tbl_tot[ss_grand_tot, ss_agent_tot, 5];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	clinic2-tot-6;
                clinic2_tot_6 += tbl_tot[ss_grand_tot, ss_agent_tot, 6];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	clinic2-tot-7;
                clinic2_tot_7 += tbl_tot[ss_grand_tot, ss_agent_tot, 7];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	clinic2-tot-8;
                clinic2_tot_8 += tbl_tot[ss_grand_tot, ss_agent_tot, 8];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	clinic2-tot-9;
                clinic2_tot_9 += tbl_tot[ss_grand_tot, ss_agent_tot, 9];
                //     add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	clinic2-tot-10.;
                clinic2_tot_10 += tbl_tot[ss_grand_tot, ss_agent_tot, 10];
            }

            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	fin-tot-1.;
            fin_tot_1 += tbl_tot[ss_grand_tot, ss_agent_tot, 1];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	fin-tot-2.;
            fin_tot_2 += tbl_tot[ss_grand_tot, ss_agent_tot, 2];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	fin-tot-3.;
            fin_tot_3 += tbl_tot[ss_grand_tot, ss_agent_tot, 3];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	fin-tot-4.;
            fin_tot_4 += tbl_tot[ss_grand_tot, ss_agent_tot, 4];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	fin-tot-5.;
            fin_tot_5 += tbl_tot[ss_grand_tot, ss_agent_tot, 5];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	fin-tot-6.;
            fin_tot_6 += tbl_tot[ss_grand_tot, ss_agent_tot, 6];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	fin-tot-7.;
            fin_tot_7 += tbl_tot[ss_grand_tot, ss_agent_tot, 7];
           // Debug.WriteLine("fin_tot_7 = " + fin_tot_7);
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	fin-tot-8.;
            fin_tot_8 += tbl_tot[ss_grand_tot, ss_agent_tot, 8];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	fin-tot-9.;
            fin_tot_9 += tbl_tot[ss_grand_tot, ss_agent_tot, 9];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	fin-tot-10.;
            fin_tot_10 += tbl_tot[ss_grand_tot, ss_agent_tot, 10];

            //     add disk-tot-tab ( 1 )                              to      disk-grnd-tab (1).;
            disk_grnd_tab[1] += disk_tot_tab[1];
            //     add disk-tot-tab ( 4 )                              to      disk-grnd-tab (4).;
            disk_grnd_tab[4] += disk_tot_tab[4];
            //     add disk-tot-tab ( 5 )                              to      disk-grnd-tab (5).;
            disk_grnd_tab[5] += disk_tot_tab[5];
            //     add disk-tot-tab ( 6 )                              to      disk-grnd-tab (6).;
            disk_grnd_tab[6] += disk_tot_tab[6];
            //     add disk-tot-tab ( 9 )                              to      disk-grnd-tab (9).;
            disk_grnd_tab[9] += disk_tot_tab[9];
            //     add disk-tot-tab ( 10 )                             to      disk-grnd-tab (10).;
            disk_grnd_tab[10] += disk_tot_tab[10];
        }

        private  void xc1_99_exit()
        {

            //     exit.;
        }

        private  void xd0_zero_clinic_totals()
        {

            //tbl_totals = 0;
            tbl_tot = new decimal[9, 12, 11];

            //disk_totals = 0;
            disk_totals_grp = "0";
            disk_tot_tab = new decimal[11];
        }

        private  void xd0_99_exit()
        {
            //     exit.;
        }

        private  void xf0_read_next_batch()
        {

            // read batch-ctrl-file next;
            // 	    at end;
            //        eof_batctrl_file = "Y";
            // 	    go to xf0-99-exit.;

            bool isRetrieve = false;

            Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
            {

            }.Collection_All(ref isRetrieve, Batctrl_rec_Collection,true);

            if (isRetrieve)
                ctr_batctrl_file_reads = 0;

            if (Batctrl_rec_Collection.Count() == 0)
            {
                eof_batctrl_file = "Y";               
                xf0_99_exit();
                return;
            }
            else
            {
                if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
                {
                    eof_batctrl_file = "Y";                    
                    xf0_99_exit();
                    return;
                }
                else
                {
                    objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];
                    ctr_batctrl_file_reads++;
                }
            }

            //  if key-batctrl-file = 'ZZZZZZZZ' then;
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).ToUpper().Equals("ZZZZZZZZ")) {  // todo
                eof_batctrl_file = "Y";
                // 	    go to xf0-99-exit.;
                xf0_99_exit();
                return;
            }

            // if batctrl-batch-type = "P" and batctrl-adj-cd     = "C"  then            
            if (objBatctrl_rec.BATCTRL_BATCH_TYPE.ToUpper().Equals("P") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C")) {
                // 	    subtract batctrl-calc-ar-due	from zero;
                // 					giving batctrl-calc-ar-due;

                objBatctrl_rec.BATCTRL_CALC_AR_DUE = 0 -  Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);

                // 	    subtract batctrl-calc-tot-rev	from zero;
                // 					giving batctrl-calc-tot-rev;
                objBatctrl_rec.BATCTRL_CALC_TOT_REV = 0 - Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);

                // 	    subtract batctrl-manual-pay-tot	from zero;
                // 					giving	batctrl-manual-pay-tot.;
                objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT = 0 - Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
            }
        }

        private  void xf0_99_exit()
        {
            //     exit.;
        }

        private  void xf1_read_doc_mstr()
        {

            //  read doc-mstr;
            // 	invalid key;
            //        objDoc_mstr_rec.doc_name = "INVALID DOCTOR";
            // 	    go to xf1-99-exit.;

            Doc_mstr_rec_Collection = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(2, 3)
            }.Collection();

            if (Doc_mstr_rec_Collection.Count()  == 0)
            {
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                objDoc_mstr_rec.DOC_NAME = "INVALID DOCTOR";
                xf1_99_exit();
                return;
            }

            //     add 1				to	doc-mstr-reads.;
            objDoc_mstr_rec = Doc_mstr_rec_Collection.FirstOrDefault();
            doc_mstr_reads++;
        }

        private  void xf1_99_exit()
        {

            //     exit.;
        }

        private  void za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            Console.WriteLine(" ERROR -  " + err_msg_comment);
            //     display confirm.;
            //     stop " ".;
            //     display blank-line-24.;
        }

        private  void za0_99_exit()
        {

            //     exit.;
        }

        private  void zb0_print_clinic_tots_summary()
        {

            ctr_line = 98;
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
            } while (ss_type <= max_nbr_types);


            ss_type = ss_grand_tot;

            //  perform zc0-process-batch-totals	thru	zc0-99-exit.;
            zc0_process_batch_totals();
            zc0_99_exit();

            nbr_lines_to_advance = 2;
            t1_desc_a = "DISKETTE TOTALS   ";
            t1_desc_b = "";
            t1_detail_1 = disk_tot_tab[1];
            t1_detail_2 = disk_tot_tab[1];
            t1_detail_4 = Util.NumInt(disk_tot_tab[4]);
            t1_detail_5 = Util.NumInt(disk_tot_tab[5]);
            t1_detail_6 = disk_tot_tab[6];
            t1_detail_7 = disk_tot_tab[6];
            t1_detail_9 = Util.NumInt(disk_tot_tab[9]);
            t1_detail_10 = Util.NumInt(disk_tot_tab[10]);

            // perform tb0-write-line              thru tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            ctr_line = 98;
        }

        private  void zb0_99_exit()
        {
            //     exit.;
        }

        private  void zc0_process_batch_totals()
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


            // if ss-type not =     ss-claims  and ss-grand-tot  then            
            if (ss_type != ss_claims && ss_type != ss_grand_tot) {  // todo...???
                // if sw-printed-adj-type = "Y" then     
                if (sw_printed_adj_type.ToUpper().Equals("Y") ) {
                     t1_desc_a = "             TOTAL";
                    t1_dash = "";
                    t1_desc_b = "";
                     ss_type_from = ss_type;
                    ss_agent = ss_agent_tot;
                    // 	perform tg0-move-vals-to-line	thru	tg0-99-exit;
                    tg0_move_vals_to_line(false);                    
                    tg0_99_exit();

                    //  perform tb0-write-line		thru	tb0-99-exit;
                    tb0_write_line();
                    tb0_99_exit();
                }
                else {
                    // 	        next sentence;
                }
            }
            else {
                //    	next sentence.;
            }

            sw_printed_adj_type = "N";

            // if ss-type not = ss-grand-tot then            
            if (ss_type != ss_grand_tot) {
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
                } while (ss_agent_from <= max_nbr_agents + 1);
            }


            // if ss-type =    ss-claims or ss-adj-r  or ss-pay-c   or ss-grand-tot then    
            if (ss_type == ss_claims || ss_type ==  ss_adj_r || ss_type == ss_pay_c || ss_type == ss_grand_tot ) {
                // 	   if sw-printed-bat-type = "Y" then            
                if (Util.Str(sw_printed_bat_type).ToUpper().Equals("Y")) {
                             sw_printed_bat_type = "N";
                             nbr_lines_to_advance = 2;
                             t1_desc_a = "    TOTALS";
                             t1_desc_b = "";
                             t1_dash = "";                             
                    if (ss_type == ss_grand_tot)
                    {
                         ss_type_from = ss_grand_tot;
                         ss_agent = ss_agent_tot;
                        // 	perform tg0-move-vals-to-line	thru	tg0-99-exit;
                        tg0_move_vals_to_line(false);
                        tg0_99_exit();
                        Assign_total_var();
                        //  perform tb0-write-line		thru	tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();
                    }
                    else
                    {
                        ss_type_from = ss_type_tot;
                        ss_agent = ss_agent_tot;
                        //  perform tg0-move-vals-to-line	thru	tg0-99-exit;
                        tg0_move_vals_to_line(false);
                        tg0_99_exit();
                        Assign_total_var();

                        // perform tb0-write-line		thru	tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();

                        //  perform tc1-roll-type-tot-to-grand;
                        // 						thru	tc1-99-exit;

                        tc1_roll_type_tot_to_grand();
                        tc1_99_exit();
                    }
                }
            }
            // else if ss-type not = ss-grand-tot then            
            else if (ss_type != ss_grand_tot) {
                // 	 perform tc1-roll-type-tot-to-grand;
                // 	                              	thru	tc1-99-exit.;
                tc1_roll_type_tot_to_grand();
                tc1_99_exit();
            }
        }

        private  void zc0_99_exit()
        {
            //     exit.;
        }

        private  void zd0_prt_agent_vals_and_sum()
        {

            //     add ss-nbr-claims, ss-offset	giving ss-temp1.;
            ss_temp1 = ss_nbr_claims + ss_offset;

            // if tbl-tot (ss-type, ss-agent, ss-nbr-claims) = zero and tbl-tot (ss-type, ss-agent, ss-temp1 ) = zero then            
            if (tbl_tot[ss_type, ss_agent, ss_nbr_claims] == 0 && tbl_tot[ss_type, ss_agent, ss_temp1] == 0)  {
                // 	    go to zd0-99-exit.;
                zd0_99_exit();
                return;
            }


            t1_desc_grp = "";
            t1_desc_a = "";
            t1_desc_b = "";

            if (sw_printed_bat_type.ToUpper().Equals("N"))
            {
                sw_printed_bat_type = "Y";
                t1_desc_a = desc_bat_type[ss_type];
                nbr_lines_to_advance = 3;
                Initialize_total_var();
            }

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

            //  perform tg0-move-vals-to-line	thru	tg0-99-exit.;
            tg0_move_vals_to_line();
            tg0_99_exit();

            //  perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            if (ss_type == ss_grand_tot)
            {
                // go to zd0-99-exit.;
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
            //     add tbl-tot (ss-type, ss-agent, 9 )		to tbl-tot (ss-type    ,ss-agent-tot, 9 ).;
            tbl_tot[ss_type, ss_agent_tot, 9] += tbl_tot[ss_type, ss_agent, 9];
            //     add tbl-tot (ss-type, ss-agent, 10 )	to tbl-tot (ss-type    ,ss-agent-tot, 10 ).;
            tbl_tot[ss_type, ss_agent_tot, 10] += tbl_tot[ss_type, ss_agent, 10];
        }

        private  void zd0_99_exit()
        {
            //     exit.;
        }

        private  void ze0_move_and_print_fin_tot()
        {

            hold_clinic_nbr = 60;

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 60;
            //                                            iconst-clinic-nbr-1-2.;
            //     read iconst-mstr;
            //         invalid key;
            //           err_ind = 2;
            //             perform za0-common-error    thru za0-99-exit;
            //             go to az0-end-of-job.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = 60
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                 err_ind = 2;
                //             perform za0-common-error    thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
            h5_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);

            h2_cycle = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
            h2_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h2_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h2_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);

            t1_desc_a = "CLINIC 60 TOTALS ";
            t1_desc_b = "";

            t1_detail_1 = clinic_tot_1;
            t1_detail_2 = clinic_tot_2;
            t1_detail_3 = clinic_tot_3;
            t1_detail_4 = Util.NumInt(clinic_tot_4);
            t1_detail_5 = Util.NumInt(clinic_tot_5);
            t1_detail_6 = clinic_tot_6;
            t1_detail_7 = clinic_tot_7;
            t1_detail_8 = clinic_tot_8;
            t1_detail_9 = Util.NumInt(clinic_tot_9);
            t1_detail_10 = Util.NumInt(clinic_tot_10);

            nbr_lines_to_advance = 3;
            //     perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            ctr_line = 98;
            hold_clinic_nbr = 70;
            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 70;

            //     read iconst-mstr;
            //         invalid key;
            //             err_ind = 2;
            //             perform za0-common-error    thru za0-99-exit;
            //             go to az0-end-of-job.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = 70
            }.Collection();

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
            h5_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);

            h2_cycle = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
            h2_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h2_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h2_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);

            t1_desc_a = "CLINIC 70 TOTALS ";
            t1_desc_b = "";

            t1_detail_1 = clinic2_tot_1;
            t1_detail_2 = clinic2_tot_2;
            t1_detail_3 = clinic2_tot_3;
            t1_detail_4 = Util.NumInt(clinic2_tot_4);
            t1_detail_5 = Util.NumInt(clinic2_tot_5);
            t1_detail_6 = clinic2_tot_6;
            t1_detail_7 = clinic2_tot_7;
            t1_detail_8 = clinic2_tot_8;
            t1_detail_9 = Util.NumInt(clinic2_tot_9);
            t1_detail_10 = Util.NumInt(clinic2_tot_10);

            nbr_lines_to_advance = 3;
            //     perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            ctr_line = 98;
            t1_desc_a = " FINAL TOTALS    ";
            t1_desc_b = "";
            t1_detail_1 = fin_tot_1;
            t1_detail_2 = fin_tot_2;
            t1_detail_3 = fin_tot_3;
            t1_detail_4 = Util.NumInt(fin_tot_4);
            t1_detail_5 = Util.NumInt(fin_tot_5);
            t1_detail_6 = fin_tot_6;
            t1_detail_7 = fin_tot_7;
            t1_detail_8 = fin_tot_8;
            t1_detail_9 = Util.NumInt(fin_tot_9);
            t1_detail_10 = Util.NumInt(fin_tot_10);

            h1_clinic_nbr = 0;
            h2_cycle = 0;
            h2_period_end_yy = 0;
            h2_period_end_mm = 0;
            h2_period_end_dd = 0;
            h5_clinic_nbr = 0;
          
            h2_clinic_name = "";

            last_page_flag = "Y";
            nbr_lines_to_advance = 3;
            //     perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();

            //move "DISKETTE MTD TOTAL"           to t1-fin - desc.
            t1_fin_desc = "DISKETTE MTD TOTAL";

            t1_fin_detail_1 = disk_grnd_tab[1];
            t1_fin_detail_2 = disk_grnd_tab[1];
            t1_fin_detail_4 = Util.NumInt(disk_grnd_tab[4]);
            t1_fin_detail_5 = Util.NumInt(disk_grnd_tab[5]);
            //     perform tb0-write-line              thru tb0-99-exit.;
            tb0_write_line(2);
            tb0_99_exit();

            nbr_lines_to_advance = 2;
            //move "DISKETTE YTD TOTAL"           to t1-fin - desc.
            t1_fin_desc = "DISKETTE YTD TOTAL";

            t1_fin_detail_1 = disk_grnd_tab[6];
            t1_fin_detail_2 = disk_grnd_tab[6];
            t1_fin_detail_4 = Util.NumInt(disk_grnd_tab[9]);
            t1_fin_detail_5 = Util.NumInt(disk_grnd_tab[10]);

            //     perform tb0-write-line              thru tb0-99-exit.;
            tb0_write_line(2);
            tb0_99_exit();

            //move " FINAL MTD TOTALS  "     to t1-fin - desc.
            t1_fin_desc = " FINAL MTD TOTALS  ";

            t1_fin_detail_1 = fin_tot_1;
            t1_fin_detail_2 = fin_tot_2;
            t1_fin_detail_3 = fin_tot_3;
            t1_fin_detail_4 = Util.NumInt(fin_tot_4);
            t1_fin_detail_5 = Util.NumInt(fin_tot_5);


            nbr_lines_to_advance = 3;
            // perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line(2);
            tb0_99_exit();

            //move " FINAL YTD TOTALS  "      to t1-fin - desc.
            t1_fin_desc = " FINAL YTD TOTALS  ";

           t1_fin_detail_1 = fin_tot_6;
            t1_fin_detail_2 = fin_tot_7;
            t1_fin_detail_3 = fin_tot_8;
            t1_fin_detail_4 = Util.NumInt(fin_tot_9);
            t1_fin_detail_5 = Util.NumInt(fin_tot_10);
            nbr_lines_to_advance = 2;

            //     perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line(2);
            tb0_99_exit();
        }

        private  void ze0_99_exit()
        {
            //     exit.;
        }

        private void MoveSpacesToPrintLine()
        {
            l1_batch_nbr_1_2 = 0;
            l1_doc_nbr = "";
            l1_week = 0;
            l1_day = 0;
            l1_slash_1a = "";
            //l1_dept_code = 0;
            l1_agent_code = 0;
            l1_batch_type = "";
            l1_slash_1 = "";
            l1_adj_code = "";
            l1_dash = "";
            l1_adj_cd_sub_type = "";
            l1_doc_nbr_ohip = 0;
            l1_hos = "";
            l1_loc_1 = "";
            l1_loc_2_4 = "";
            l1_i_o_pat_ind = "";
            l1_date_yy = 0;
            l1_slash_2 = "";
            l1_date_mm = 0;
            l1_slash_3 = "";
            l1_date_dd = 0;
            l1_amt_ar = 0;
            l1_amt_rev = 0;
            l1_amt_cash = 0;
            l1_last_claim = 0;
            l1_cycle = 0;
            l1_ped_yy = 0;
            l1_slash_4 = "";
            l1_ped_mm = 0;
            l1_slash_5 = "";
            l1_ped_dd = 0;
            l1_status = "";

        }

        private string h1_head_grp()
        {
            return "R001B /" +
                    Util.BlankWhenZero(h1_clinic_nbr,2) +    // Util.Str(h1_clinic_nbr).PadLeft(2, ' ') +
                     new string(' ', 40) +
                     "-  COMPLETE BATCH SUMMARY REPORT  -".PadRight(74) +                     
                     "PAGE".PadRight(5) +
                     Util.ImpliedIntegerFormat("#0", h1_page, 4, false); 
        }

        private string h2_head_grp()
        {
            return "  CYCLE #" + 
                    Util.BlankWhenZero("##0", h2_cycle,3).Trim().PadLeft(3) +    // Util.Str(h2_cycle).PadLeft(3, ' ') + 
                    "  PERIOD END:" + 
                    Util.BlankWhenZero(h2_period_end_yy, 4) + 
                    "/" + 
                    Util.BlankWhenZero(h2_period_end_mm, 2) + 
                    "/" + 
                    Util.BlankWhenZero(h2_period_end_dd, 2) + 
                    new string(' ', 14) + 
                    Util.Str(h2_clinic_name).PadRight(81, ' ');
        }

        private string h3_head_grp()
        {
            return new string(' ', 1) + 
                   "BATCH".PadRight(12, ' ') + 
                   "AG".PadRight(4, ' ') + 
                   "BAT /ADJ".PadRight(11, ' ') + 
                   "DOC".PadRight(6, ' ') + 
                   "HOS".PadRight(5, ' ') + 
                   "LOC".PadRight(5, ' ') + 
                   "I/O".PadRight(6, ' ') + 
                   "DATE".PadRight(14, ' ') + 
                   "A/R".PadRight(10, ' ') + 
                   "REVENUE".PadRight(12, ' ') +
                   "CASH".PadRight(9, ' ') + 
                   "NBR".PadRight(6, ' ') + 
                   "CYCLE".PadRight(8, ' ') + 
                   "P.E.D.".PadRight(11, ' ') + 
                   "STATUS".PadRight(12, ' ');
        }

        private string h4_head_grp()
        {
            return  new string(' ', 1) + 
                    "NUMBER".PadRight(8, ' ') + 
                    "DP".PadRight(7, ' ') + 
                    "TYPE/CODE".PadRight(12, ' ') + 
                    "REG".PadRight(21, ' ') + 
                    "ENTERED".PadRight(12, ' ') + 
                    "AMOUNT".PadRight(11, ' ') + 
                    "AMOUNT".PadRight(11, ' ') + 
                    "AMOUNT".PadRight(9, ' ') + 
                    "CLAIMS".PadRight(8, ' ') + 
                    "NBR".PadRight(32, ' ');
        }

        private string h5_head_grp()
        {
            return "CLINIC".PadRight(8, ' ') +
                    Util.BlankWhenZero(h5_clinic_nbr,2) +    // Util.Str(h5_clinic_nbr).PadLeft(2, ' ') + 
                    new string(' ', 15) + 
                    "---------------".PadRight(15, ' ') + 
                    "M. T. D.    T O T A L S".PadRight(23, ' ') + 
                    "------------".PadRight(18, ' ') + 
                    "----------------".PadRight(16, ' ') + 
                    "Y. T. D.    T O T A L S-----------".PadRight(35, ' ');
        }

        private string h6_head_grp()
        {
            return new string(' ', 17) + 
                   "AGENT".PadRight(8, ' ') + 
                   "NET A/R".PadRight(13, ' ') + 
                   " NET REV".PadRight(16, ' ') + 
                   "CASH".PadRight(8, ' ') + 
                   "CLAIMS".PadRight(8, ' ') + 
                   "SVC'S".PadRight(11, ' ') + 
                   "NET A/R".PadRight(13, ' ') + 
                   " NET REV".PadRight(16, ' ') + 
                   "CASH".PadRight(8, ' ') + 
                   "CLAIMS".PadRight(8, ' ') + 
                   "SVC'S".PadRight(6, ' ');
        }

        private string print_line_grp()
        {
            return  Util.Str(l1_batch_nbr_1_2).PadLeft(2, '0') + 
                    Util.Str(l1_doc_nbr).PadRight(3, ' ') + 
                    Util.Str(l1_week).PadLeft(2, '0') + 
                    Util.Str(l1_day).PadLeft(1, '0') + 
                    Util.Str(l1_slash_1a).PadRight(1, ' ') + 
                    Util.Str(l1_dept_code).PadLeft(2, '0') + 
                    new string(' ', 3) + 
                    Util.Str(l1_agent_code).PadLeft(1, '0') + 
                    new string(' ', 3) + 
                    Util.Str(l1_batch_type).PadRight(2, ' ') + 
                    Util.Str(l1_slash_1).PadRight(2, ' ') +
                    Util.Str(l1_adj_code).PadRight(1, ' ') + 
                    Util.Str(l1_dash).PadRight(1, ' ') + 
                    Util.Str(l1_adj_cd_sub_type).PadRight(2, ' ') + 
                    Util.BlankWhenZero(l1_doc_nbr_ohip, 6) + 
                    new string(' ', 3) + 
                    Util.Str(l1_hos).PadRight(1, ' ') + 
                    new string(' ', 3) + 
                    Util.Str(l1_loc_1).PadRight(1, ' ') + 
                    Util.Str(l1_loc_2_4).PadRight(3, ' ') + 
                    new string(' ', 2) + 
                    Util.Str(l1_i_o_pat_ind).PadRight(4, ' ') + 
                    Util.Str(l1_date_yy).PadLeft(4, '0') +
                    Util.Str(l1_slash_2).PadRight(1, ' ') + 
                    Util.Str(l1_date_mm).PadLeft(2, '0') + 
                    Util.Str(l1_slash_3).PadRight(1, ' ') + 
                    Util.Str(l1_date_dd).PadLeft(2, '0') + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,0.00", l1_amt_ar, 2, 12, true,true) + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,0.00", l1_amt_rev, 2, 12,true,true) + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,0.00", l1_amt_cash, 2, 12,true,true) + 
                    new string(' ', 1) +
                    Util.Str(l1_last_claim).PadLeft(2, '0') + 
                    new string(' ', 1) + 
                    Util.BlankWhenZero("#",l1_cycle,3) +   // Util.Str(l1_cycle).PadLeft(3, ' ') + 
                    new string(' ', 3) + 
                    Util.Str(l1_ped_yy).PadLeft(4, '0') + 
                    Util.Str(l1_slash_4).PadRight(1, ' ') + 
                    Util.Str(l1_ped_mm).PadLeft(2, '0') + 
                    Util.Str(l1_slash_5).PadRight(1, ' ') + 
                    Util.Str(l1_ped_dd).PadLeft(2, '0') + 
                    new string(' ', 4) + 
                    Util.Str(l1_status).PadRight(1, ' ') + 
                    new string(' ', 9);
        }

        private string t1_print_line()
        {

            t1_desc_grp = Util.Str(t1_desc_a).PadRight(13) + Util.Str(t1_desc_b).PadRight(5);
            if (Util.Str(t1_desc_a).ToUpper().Trim() == "TOTAL" || Util.Str(t1_desc_a).ToUpper().Trim() == "DISKETTE TOTALS" || Util.Str(t1_desc_a).ToUpper().Trim() == "CLINIC 60 TOTALS" || Util.Str(t1_desc_a).ToUpper().Trim() == "CLINIC 70 TOTALS" || Util.Str(t1_desc_a).ToUpper().Trim() == "FINAL TOTALS" || Util.Str(t1_desc_a).ToUpper().Trim() == "DISKETTE MTD TOTAL"
                || Util.Str(t1_desc_a).ToUpper().Trim() == "DISKETTE YTD TOTAL" || Util.Str(t1_desc_a).ToUpper().Trim() == "FINAL MTD TOTALS" || Util.Str(t1_desc_a).ToUpper().Trim() == "FINAL YTD TOTALS")
            {
                t1_desc_grp = Util.Str(t1_desc_a).PadRight(13) + Util.Str(t1_desc_b);
            }
            string tempAgentCode = string.IsNullOrWhiteSpace(t1_dash) ? "".PadRight(1) : Util.Str(t1_agent_cd);


            if (Util.Str(t1_desc_a).ToUpper().Trim() == "DISKETTE TOTALS")
            {
                return t1_desc_grp +
                      Util.Str(t1_dash).PadRight(1) +
                 new string(' ', 1) +
                 tempAgentCode +    // Util.Str(t1_agent_cd).PadLeft(1, '0') +
                 Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_1, 2, 13, true, true) +
                 Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_2, 2, 13, true, true) +
                 new string(' ', 13) +   //Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_3, 2, 13, true, true) +
                 new string(' ', 1) +
                 Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                 new string(' ', 1) +
                 Util.ImpliedIntegerFormat("#,0", t1_detail_5, 7, false) +
                 new string(' ', 1) +
                 Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_6, 2, 13, true, true) +
                 Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_7, 2, 13, true, true) +
                 new string(' ',13) +   //Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_8, 2, 13, true, true) +
                 Util.ImpliedIntegerFormat("####,##0", t1_detail_9, 8, false, true) +
                 Util.ImpliedIntegerFormat("####,##0", t1_detail_10, 8, false, true);
            }
            else
            {
                return t1_desc_grp +
                       Util.Str(t1_dash).PadRight(1) +
                  new string(' ', 1) +
                  tempAgentCode +    // Util.Str(t1_agent_cd).PadLeft(1, '0') +
                  Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_1, 2, 13, true, true) +
                  Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_2, 2, 13, true, true) +
                  Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_3, 2, 13, true, true) +
                  new string(' ', 1) +
                  Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                  new string(' ', 1) +
                  Util.ImpliedIntegerFormat("#,0", t1_detail_5, 7, false) +
                  new string(' ', 1) +
                  Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_6, 2, 13, true, true) +
                  Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_7, 2, 13, true, true) +
                  Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_8, 2, 13, true, true) +
                  Util.ImpliedIntegerFormat("####,##0", t1_detail_9, 8, false, true) +
                  Util.ImpliedIntegerFormat("####,##0", t1_detail_10, 8, false, true);
            }

          /*  return tempAgentCode +  // Util.Str(t1_desc_a).PadRight(13) +
                    //Util.Str(t1_desc_b).PadRight(5) +
                   Util.Str(t1_dash).PadRight(1) +
                   new string(' ', 1) +
                   Util.Str(t1_agent_cd).PadLeft(1, '0') +
                   Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_1, 2, 13, true, true) +
                   Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_2, 2, 13, true, true) +
                   Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_3, 2, 13, true, true) +
                   new string(' ', 1) +
                   Util.ImpliedIntegerFormat("#,0", t1_detail_4, 7, false) +
                   new string(' ', 1) +
                   Util.ImpliedIntegerFormat("#,0", t1_detail_5, 7, false) +
                   new string(' ', 1) +
                   Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_6, 2, 13, true, true) +
                   Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_7, 2, 13, true, true) +
                   Util.ImpliedDecimalFormat("#####,##0.00", t1_detail_8, 2, 13, true, true) +
                   Util.ImpliedIntegerFormat("####,##0", t1_detail_9,8, false, true) +
                   Util.ImpliedIntegerFormat("####,##0", t1_detail_10,8, false, true); */
        }

        private string t1_final_line()
        {
            if (Util.Str(t1_fin_desc).ToUpper().Equals("DISKETTE MTD TOTAL") || Util.Str(t1_fin_desc).ToUpper().Equals("DISKETTE YTD TOTAL"))
            {
                return Util.Str(t1_fin_desc).PadRight(20) +
                    Util.BlankWhenZero("#,0.00", t1_fin_detail_1, 2, 15).Trim().PadRight(15) +     // Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_1, 2, 15) +
                     new string(' ', 2) +
                    Util.BlankWhenZero("#,0.00", t1_fin_detail_2, 2, 15).Trim().PadRight(15) +    //Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_2, 2, 15) +
                     new string(' ', 2) +
                     new string(' ',15) +    //Util.BlankWhenZero("#,0.00", t1_fin_detail_3, 2, 15) +   
                     new string(' ', 2) +
                     Util.ImpliedIntegerFormat("#,0", t1_fin_detail_4, 10) +
                     new string(' ', 1) +
                     Util.ImpliedIntegerFormat("#,0", t1_fin_detail_5, 10) +
                     new string(' ', 41);
            }
            else if (Util.Str(t1_fin_desc).ToUpper().Trim().Equals("FINAL MTD TOTALS") || Util.Str(t1_fin_desc).ToUpper().Trim().Equals("FINAL YTD TOTALS"))
            {
                return Util.Str(t1_fin_desc).PadRight(20) +
                    Util.BlankWhenZero("#,0.00", t1_fin_detail_1, 2, 15) +     // Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_1, 2, 15) +
                     new string(' ', 2) +
                    Util.BlankWhenZero("#,0.00", t1_fin_detail_2, 2, 15) +    //Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_2, 2, 15) +
                     new string(' ', 2) +
                     Util.BlankWhenZero("#,0.00", t1_fin_detail_3, 2, 15) +   
                     new string(' ', 2) +
                     Util.ImpliedIntegerFormat("#,0", t1_fin_detail_4, 10) +
                     new string(' ', 1) +
                     Util.ImpliedIntegerFormat("#,0", t1_fin_detail_5, 10) +
                     new string(' ', 41);
            }
            else {
                return Util.Str(t1_fin_desc).PadRight(20) +
                      Util.BlankWhenZero("#,0.00", t1_fin_detail_1, 2, 15) +     // Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_1, 2, 15) +
                       new string(' ', 2) +
                      Util.BlankWhenZero("#,0.00", t1_fin_detail_2, 2, 15) +    //Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_2, 2, 15) +
                       new string(' ', 2) +
                       Util.BlankWhenZero("#,0.00", t1_fin_detail_3, 2, 15) +   //Util.ImpliedDecimalFormat("#,0.00", t1_fin_detail_3, 2, 15) +
                       new string(' ', 2) +
                       Util.ImpliedIntegerFormat("#,0", t1_fin_detail_4, 9) +
                       new string(' ', 2) +
                       Util.ImpliedIntegerFormat("#,0", t1_fin_detail_5, 9) +
                       new string(' ', 41);
            }
        }

        private void Initialize_total_var()
        {
            t1_detail_1_totals = 0;
            t1_detail_2_totals = 0;
            t1_detail_3_totals = 0;
            t1_detail_4_totals = 0; ;
            t1_detail_5_totals = 0;
            t1_detail_6_totals = 0;
            t1_detail_7_totals = 0;
            t1_detail_8_totals = 0;
            t1_detail_9_totals = 0;
            t1_detail_10_totals = 0;
    }

        private void Accum_total_var()
        {
            t1_detail_1_totals += t1_detail_1;
            t1_detail_2_totals += t1_detail_2;
            t1_detail_3_totals += t1_detail_3;
            t1_detail_4_totals += t1_detail_4;
            t1_detail_5_totals += t1_detail_5;
            t1_detail_6_totals += t1_detail_6;
            t1_detail_7_totals += t1_detail_7;
            t1_detail_8_totals += t1_detail_8;
            t1_detail_9_totals += t1_detail_9;
            t1_detail_10_totals += t1_detail_10;
        }

        private void Assign_total_var()
        {
            t1_detail_1 = t1_detail_1_totals;
            t1_detail_2 = t1_detail_2_totals;
            t1_detail_3 = t1_detail_3_totals;
            t1_detail_4 = t1_detail_4_totals;
            t1_detail_5 = t1_detail_5_totals;
            t1_detail_6 = t1_detail_6_totals;
            t1_detail_7 = t1_detail_7_totals;
            t1_detail_8 = t1_detail_8_totals;
            t1_detail_9 = t1_detail_9_totals;
            t1_detail_10 = t1_detail_10_totals;
        }




        #endregion
    }
}


