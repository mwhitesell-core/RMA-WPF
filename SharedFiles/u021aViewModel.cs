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
    public class U021aViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: edt_hx_error_file	Copy : u021_edt_submission_error_hx_file.fd
        private Edt_1_record objEdt_1_record = null;
        private ObservableCollection<Edt_1_record> Edt_1_record_Collection;

        // FD: edt_hx_error_file	Copy : u021_edt_submission_error_hx_file.fd
        private Edt_h_record objEdt_h_record = null;
        private ObservableCollection<Edt_h_record> Edt_h_record_Collection;

        // FD: edt_hx_error_file	Copy : u021_edt_submission_error_hx_file.fd
        private Edt_r_record objEdt_r_record = null;
        private ObservableCollection<Edt_r_record> Edt_r_record_Collection;

        // FD: edt_hx_error_file	Copy : u021_edt_submission_error_hx_file.fd
        private Edt_t_record objEdt_t_record = null;
        private ObservableCollection<Edt_t_record> Edt_t_record_Collection;

        // FD: edt_hx_error_file	Copy : u021_edt_submission_error_hx_file.fd
        private Edt_8_record objEdt_8_record = null;
        private ObservableCollection<Edt_8_record> Edt_8_record_Collection;

        // FD: edt_hx_error_file	Copy : u021_edt_submission_error_hx_file.fd
        private Edt_9_record objEdt_9_record = null;
        private ObservableCollection<Edt_9_record> Edt_9_record_Collection;

        // FD: edt_1ht_file	Copy : u021_edt_1ht_file.fd
        private Edt_1ht_record objEdt_1ht_record = null;
        private ObservableCollection<Edt_1ht_record> Edt_1ht_record_Collection;

        // FD: edt_rmb_file	Copy : u021_edt_rmb_file.fd
        private Edt_rmb_record objEdt_rmb_record = null;
        private ObservableCollection<Edt_rmb_record> Edt_rmb_record_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private CONSTANTS_MSTR_REC_1 objIconst_mstr_rec_1 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_1> Iconst_mstr_rec_1_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_1.ws
        //private Constants_mstr_rec_1 objConstants_mstr_rec_1 = null;
        //private ObservableCollection<Constants_mstr_rec_1> Constants_mstr_rec_1_Collection;

        private ICONST_MSTR_REC objICONST_MSTR_REC = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        private WriteFile objedt_hx_error_file = null;
        //01  edt-1-record
        //01  edt-h-record
        //01  edt-r-record
        //01  edt-t-record
        //01  edt-8-record
        //01  edt-9-record

        private WriteFile objedt_1ht_file = null;
        //01  edt-1ht-record.

        private WriteFile objedt_rmb_file = null;
        // 01  edt-rmb-record

        #endregion

        #region Properties
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

        private string _ws_request_clinic_ident;
        public string ws_request_clinic_ident
        {
            get
            {
                return _ws_request_clinic_ident;
            }
            set
            {
                if (_ws_request_clinic_ident != value)
                {
                    _ws_request_clinic_ident = value;
                    _ws_request_clinic_ident = _ws_request_clinic_ident.ToUpper();
                    RaisePropertyChanged("ws_request_clinic_ident");
                }
            }
        }

        private int _ws_reply;
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

        private int _ws_sel_month;
        public int ws_sel_month
        {
            get
            {
                return _ws_sel_month;
            }
            set
            {
                if (_ws_sel_month != value)
                {
                    _ws_sel_month = value;
                    RaisePropertyChanged("ws_sel_month");
                }
            }
        }

        private int _ws_scr_day;
        public int ws_scr_day
        {
            get
            {
                return _ws_scr_day;
            }
            set
            {
                if (_ws_scr_day != value)
                {
                    _ws_scr_day = value;
                    RaisePropertyChanged("ws_scr_day");
                }
            }
        }

        private string _ws_scr_month;
        public string ws_scr_month
        {
            get
            {
                return _ws_scr_month;
            }
            set
            {
                if (_ws_scr_month != value)
                {
                    _ws_scr_month = value;
                    _ws_scr_month = _ws_scr_month.ToUpper();
                    RaisePropertyChanged("ws_scr_month");
                }
            }
        }

        private int _ws_scr_year;
        public int ws_scr_year
        {
            get
            {
                return _ws_scr_year;
            }
            set
            {
                if (_ws_scr_year != value)
                {
                    _ws_scr_year = value;
                    RaisePropertyChanged("ws_scr_year");
                }
            }
        }

        private string _ws_flag_tape_mth;
        public string ws_flag_tape_mth
        {
            get
            {
                return _ws_flag_tape_mth;
            }
            set
            {
                if (_ws_flag_tape_mth != value)
                {
                    _ws_flag_tape_mth = value;
                    _ws_flag_tape_mth = _ws_flag_tape_mth.ToUpper();
                    RaisePropertyChanged("ws_flag_tape_mth");
                }
            }
        }

        private string _ws_flag_over_mth;
        public string ws_flag_over_mth
        {
            get
            {
                return _ws_flag_over_mth;
            }
            set
            {
                if (_ws_flag_over_mth != value)
                {
                    _ws_flag_over_mth = value;
                    _ws_flag_over_mth = _ws_flag_over_mth.ToUpper();
                    RaisePropertyChanged("ws_flag_over_mth");
                }
            }
        }

        private string _ws_confirm_reply;
        public string ws_confirm_reply
        {
            get
            {
                return _ws_confirm_reply;
            }
            set
            {
                if (_ws_confirm_reply != value)
                {
                    _ws_confirm_reply = value;
                    RaisePropertyChanged("ws_confirm_reply");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int ws_unique_rec_ctr = 0;
        private string ws_orig_file_name = string.Empty;
        private int err_ind = 0;
        private string last_account_nbr = string.Empty;
        private decimal ws_doll_amt = 0;
        private string status_file = string.Empty;
        private string status_iconst_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private int i = 0;
        private string group_nbr_flag = string.Empty;
        private string group_nbr_found = "Y";
        private string group_nbr_not_found = "N";
        private string edt_eof_flag = string.Empty;
        private string edt_eof = "Y";
        private string hcp_rmb_flag = string.Empty;
        private string rmb_claims = "Y";
        private string hcp_claims = "N";
        private string last_record = string.Empty;
        private string last_record_is_item = "T";
        private string last_record_is_message = "8";

        private string ws_edt_1_group_nbr_grp = string.Empty;
        private int ws_edt_clinic_nbr = 0;
        private int ws_clinic_nbr = 0;
        private string ws_edt_1_moh_off_cd = string.Empty;
        private string ws_edt_1_station_nbr = string.Empty;
        private int ws_edt_1_process_date = 0;
        private int ws_edt_1_doc_nbr = 0;
        private string ws_edt_1_specialty_cd = string.Empty;

        private string counters_grp = string.Empty;
        private int ctr_edt_tape_reads = 0;
        private int ctr_edt_rec1_reads = 0;
        private int ctr_edt_rech_reads = 0;
        private int ctr_edt_recr_reads = 0;
        private int ctr_edt_rect_reads = 0;
        private int ctr_edt_rec8_reads = 0;
        private int ctr_edt_rec9_reads = 0;
        private int ctr_hcp_dtl_writes = 0;
        private int ctr_rmb_dtl_writes = 0;
        private int hcp_records = 0;
        private int rmb_records = 0;

        private string error_message_table_grp = string.Empty;
        private string error_messages_grp = string.Empty;
        private string error_messages_r_grp = string.Empty;
        private string[] err_msg = {"", "NO RAT TAPE HEADER - RECORD #1 ", "RAT TAPE RECORD #5 DOES NOT BELONG IN SERIES", "INVALID GROUP IDENTIFIER", "RAT TAPE MONTH MUST BE NUMERIC ONLY", "GROUP IDENTIFICATION MUST BE NUMERIC", "invalid reply",
                                  "CONSTANT MSTR RECORD 1 DOES NOT EXIST" };

        private string e1_error_line_grp = string.Empty;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg = string.Empty;
        private int century_year = 0;
        private int century_date = 0;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp = string.Empty;
        private string sys_date_long = string.Empty;
        private string sys_date_long_r_grp = string.Empty;
        private string sys_yy_alpha_grp = string.Empty;
        private int sys_y1 = 0;
        private int sys_y2 = 0;
        private int sys_y3 = 0;
        private int sys_y4 = 0;
        private int sys_date_numeric = 0;

        private string sys_date_y2kfix_grp = string.Empty;
        private string sys_date_left = string.Empty;
        private string filler = string.Empty;

        private string sys_date_y2kfixed_grp = string.Empty;
        private string sys_date_blank = string.Empty;
        private string sys_date_right = string.Empty;
        private string sys_date_temp = string.Empty;

        private string run_date_grp = string.Empty;
        private int run_yy = 0;
        private int run_mm = 0;
        private int run_dd = 0;

        private string sys_time_grp = string.Empty;
        private int sys_hrs = 0;
        private int sys_min = 0;
        private int sys_sec = 0;
        private int sys_hdr = 0;

        private string run_time_grp = string.Empty;
        private int run_hrs = 0;
        private int run_min = 0;
        private int run_sec = 0;

        private string month_descs_and_max_days_mth_grp = string.Empty;
        private string mth_desc_max_days_grp = string.Empty;
        private string mth_desc_max_days_r_grp = string.Empty;
        private string[] mth_desc_max_days_occur = new string[13];
        private int[] max_nbr_days = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private string[] mth_desc = { "", "january", "february", "march", "april", "may", "june", "july", "august", "SEPTEMBER", "october", "november", "december" };
        private int[] nbr_julian_days_ytd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

        private string prm_ws_request_clinic_ident = string.Empty;
        private int prm_ws_sel_month = 0;
        private string prm_ws_orig_file_name = string.Empty;
        private string prm_ws_confirm_reply = string.Empty;
        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "U031A",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 20,Data1 = "RAT ERROR FILE APPLICATION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "06",Col = 20,Data1 = "ENTER CLINIC IDENT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "06",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_request_clinic_ident",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "08",Col = 10,Data1 = "CONTINUE?  (ENTER Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "21",Col = 20,Data1 = "PROGRAM U031A IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -   ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-month-id.",Line = "10",Col = 20,Data1 = "ENTER RAT TAPE MONTH",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-month-id.",Line = "10",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_sel_month",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-search-rec-type-1.",Line = "12",Col = 20,Data1 = "NOW SEARCHING FOR RAT ERROR RECORD TYPE 1",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date.",Line = "14",Col = 20,Data1 = "Process date is",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date.",Line = "14",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_scr_day",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date.",Line = "14",Col = 39,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(9)",MaxLength = 9,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_scr_month",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date.",Line = "14",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_scr_year",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-accept-mth.",Line = "17",Col = 20,Data1 = "ACCEPT THIS TAPE MONTH (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-accept-mth.",Line = "17",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_flag_tape_mth",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "19",Col = 20,Data1 = "MONTH ENTERED AND MONTH FOUND ON TAPE DON'T MATCH",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "20",Col = 20,Data1 = "DO YOU STILL WANT TO CONTINUE (Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "20",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_flag_over_mth",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "22",Col = 20,Data1 = "* WARNING * YOU HAVE ENTERED 'N' ! RE-ENTER TO CONFIRM",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "23",Col = 20,Data1 = "DO YOU STILL WANT TO CONTINUE (Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_confirm_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        public void mainline(string ws_request_clinic_ident, int ws_sel_month, string ws_orig_file_name, string ws_confirm_reply)
        {
            try
            {
                prm_ws_request_clinic_ident = ws_request_clinic_ident;
                prm_ws_sel_month = ws_sel_month;
                prm_ws_orig_file_name = ws_orig_file_name;
                prm_ws_confirm_reply = ws_confirm_reply;

                objedt_1ht_file = new WriteFile(Directory.GetCurrentDirectory() + "\\u021a_edt_1ht_file.dat", false);
                objedt_rmb_file = new WriteFile(Directory.GetCurrentDirectory() + "\\u021a_edt_rmb_file.dat", false);

                objEdt_1_record = new Edt_1_record();
                objEdt_h_record = new Edt_h_record();
                objEdt_r_record = new Edt_r_record();
                objEdt_t_record = new Edt_t_record();
                objEdt_8_record = new Edt_8_record();
                objEdt_9_record = new Edt_9_record();

                Edt_1_record_Collection = Read_edt_hx_error_file();

                //     perform aa0-initialization              thru aa0-99-exit.;
                aa0_initialization();

                i = 1;
                aa0_10_accept_clinic();

                if (group_nbr_flag == group_nbr_not_found)
                {
                    err_ind = 3;
                    za0_common_error();
                }
                else
                {
                    aa0_15_accept_month();
                    aa0_20_continue_reading();
                    aa0_99_exit();
                }

                //     perform ab0-processing             	    thru ab0-99-exit;
                //        until edt-eof.;

                if (Edt_1_record_Collection.Count() >0 ) {                    
                    ctr_edt_tape_reads = 0;
                    xa0_read_edt_tape();
                    edt_eof_flag = "N";
                    do
                    {
                        string retVal = ab0_processing();
                        if (retVal.Equals("ab0_99_exit")) goto _ab0_99_exit;
                        ab0_10_read_next_rat();
                        _ab0_99_exit:
                        ab0_99_exit();
                    } while (edt_eof_flag != edt_eof);
                }

                //  perform az0-end-of-job                  thru az0-99-exit.;
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
                if (objedt_hx_error_file != null)
                    objedt_hx_error_file.CloseOutputFile();

                if (objedt_1ht_file != null)
                    objedt_1ht_file.CloseOutputFile();

                if (objedt_rmb_file != null)
                    objedt_rmb_file.CloseOutputFile();
            }
        }

        private void aa0_initialization()
        {
            //     accept sys-date                           from date.;
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

            //     perform y2k-default-sysdate               thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;

            //     accept sys-time                   	      from time.;

            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            //move sys-hrs            to run-hrs.
            run_hrs = sys_hrs;

            //move sys - min            to run-min.
            run_min = sys_min;

            //move sys - sec            to run-sec.
            run_sec = sys_sec;


            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //counters = 0;
            ctr_edt_tape_reads = 0;
            ctr_edt_rec1_reads = 0;
            ctr_edt_rech_reads = 0;
            ctr_edt_recr_reads = 0;
            ctr_edt_rect_reads = 0;
            ctr_edt_rec8_reads = 0;
            ctr_edt_rec9_reads = 0;
            ctr_hcp_dtl_writes = 0;
            ctr_rmb_dtl_writes = 0;
            hcp_records = 0;
            rmb_records = 0;

            edt_eof_flag = "N";
            hcp_rmb_flag = "N";
            group_nbr_flag = "N";

            // open input iconst-mstr.;
            //    objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 01;

            // read iconst-mstr;
            // 	 invalid key;
            //           err_ind = 7;
            //           perform za0-common-error         thru za0-99-exit;
            //           perform zb0-abend                thru zb0-99-exit.;

            objIconst_mstr_rec_1 = new CONSTANTS_MSTR_REC_1
            {
                WhereConst_rec_nbr = 1
            }.Collection().FirstOrDefault();

            if (objIconst_mstr_rec_1 == null)
            {
                err_ind = 7;
                za0_common_error();
                za0_99_exit();
                zb0_abend();
                zb0_99_exit();
            }
        }

        private void aa0_10_accept_clinic()
        {

            //  accept ws-request-clinic-ident.;
            ws_request_clinic_ident = prm_ws_request_clinic_ident;

            //  perform aa3-verify-group-nbr    thru aa3-99-exit;
            //         varying i from 1 by 1;
            //    	until   group-nbr-found or i > 63.;

            do
            {
                aa3_verify_group_nbr();
                aa3_99_exit();
                i++;
            } while (group_nbr_flag == group_nbr_not_found && i <= 63);

            //  if group-nbr-not-found  then;            
            // if (group_nbr_flag == group_nbr_not_found)
            // {
            //    err_ind = 3;
            //    //  perform za0-common-error    thru za0-99-exit;
            //    za0_common_error();
            //    za0_99_exit();
            //    //  go to aa0-10-accept-clinic.;
            //    aa0_10_accept_clinic();
            //    return;
            // }
        }

        private void aa0_15_accept_month()
        {

            //     accept ws-sel-month.;
            ws_sel_month = prm_ws_sel_month;

            // if ws-sel-month  is not numeric  then;            
            if (!Util.IsNumeric(ws_sel_month.ToString()))
            {
                err_ind = 4;
                //perform za0-common-error             thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                ws_sel_month = 0;
                err_ind = 0;
                //       go to aa0-15-accept-month.;
                //aa0_15_accept_month();
                return;
            }

            // accept ws-orig-file-name.;
            ws_orig_file_name = prm_ws_orig_file_name;

            //     open input     edt-hx-error-file.;  // todo... ???
            //     open extend edt-rmb-file;
            //                 edt-1ht-file .;
        }

        private void aa0_20_continue_reading()
        {
            _continue_reading:

            do
            {
                xa0_read_edt_tape();
                xa0_99_exit();
            } while (objEdt_1_record.Edt_1_record_type != "1" && edt_eof_flag != edt_eof);

            if (edt_eof_flag != edt_eof)
            {
               
                    if (ws_request_clinic_ident == objEdt_1_record.Edt_1_group_nbr)
                    {
                        if (objEdt_1_record.Edt_1_record_type == "1")
                        {
                            ctr_edt_rec1_reads++;
                            aa1_record_1_process();
                            aa1_99_exit();
                            string retval =  aa2_certify_month();
                            if (retval.Equals("aa2_99_exit")) goto _aa2_99_exit;
                            aa2_10_confirm_neg_response();
                        _aa2_99_exit:
                            aa2_99_exit();
                        }
                        else
                        {
                              goto _continue_reading;
                        }
                    }
                    else
                    {
                        //xa0_read_edt_tape();
                        //xa0_99_exit();
                       goto _continue_reading;
                    }               
            }
            else if (ctr_edt_tape_reads >=  Edt_1_record_Collection.Count() )
            {
                return; 
            }
            else 
            {
                err_ind = 1;
                za0_common_error();
                za0_99_exit();
                zb0_abend();
                zb1_close_files();
                zb0_99_exit();
            }

            // perform xa0-read - edt - tape                   thru xa0-99 - exit.
            goto _continue_reading;            
        }
        
        private void aa0_99_exit()
        {
            //     exit.;
        }

        private void aa1_record_1_process()
        {
            ws_edt_1_group_nbr_grp = "0000";
            ws_edt_clinic_nbr = 0;

            ws_edt_clinic_nbr = ws_clinic_nbr;

            ws_edt_1_moh_off_cd = objEdt_1_record.Edt_1_moh_off_cd;
            ws_edt_1_station_nbr = objEdt_1_record.Edt_1_station_nbr;
            ws_edt_1_process_date = Util.NumInt(objEdt_1_record.Edt_1_process_date);
            ws_edt_1_doc_nbr = objEdt_1_record.Edt_1_doc_nbr;
            ws_edt_1_specialty_cd = objEdt_1_record.Edt_1_specialty_cd;
        }

        private void aa1_99_exit()
        {
            //     exit.;
        }
        private string aa2_certify_month()
        {

            ws_scr_day = objEdt_1_record.Edt_1_process_date_dd;
            ws_scr_year = objEdt_1_record.Edt_1_process_date_yy;
            ws_scr_month = mth_desc[objEdt_1_record.Edt_1_process_date_mm];
            ws_flag_tape_mth = "Y";

            // if ws-sel-month  not = edt-1-process-date-mm then;       
            if (ws_sel_month != objEdt_1_record.Edt_1_process_date_mm)
            {
                if (ws_flag_tape_mth == "Y")
                {
                    //             next sentence;
                }
                else
                {
                    // go to  zb1-close-files;
                    zb1_close_files();
                    return string.Empty;
                }
            }
            else if (ws_flag_tape_mth == "Y")
            {
                //  go to aa2-99-exit;                
                return "aa2_99_exit";
            }
            else
            {
                //  go to  zb1-close-files.;
                zb1_close_files();
                return string.Empty;
            }

            ws_flag_over_mth = "Y";
            if (ws_flag_over_mth == "Y")
            {
                //  go to aa2-99-exit.;                
                return "aa2_99_exit";
            }

            return string.Empty;
        }

        private void aa2_10_confirm_neg_response()
        {
            ws_confirm_reply = Util.Str(prm_ws_confirm_reply).ToUpper();

            if (Util.Str(ws_confirm_reply).ToUpper() == "Y" || Util.Str(ws_confirm_reply).ToUpper() == "N")
            {
                // 	  next sentence;
            }
            else
            {
                err_ind = 6;
                //  perform za0-common-error        thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to aa2-10-confirm-neg-response.;
                aa2_10_confirm_neg_response();
                return;
            }

            if (ws_confirm_reply == "Y")
            {
                //         next sentence;
            }
            else
            {
                //  go to zb1-close-files.;
                zb1_close_files();
                return;
            }
        }

        private void aa2_99_exit()
        {

            //     exit.;
        }

        private void aa3_verify_group_nbr()
        {
            // if ws-request-clinic-ident = const-clinic-nbr(i)  then;            

            if (ws_request_clinic_ident == CONST_CLINIC_NBR(objIconst_mstr_rec_1, i))
            {
                ws_clinic_nbr = CONST_CLINIC_NBR_1_2(objIconst_mstr_rec_1, i);  //const_clinic_nbr_1_2[i];
                group_nbr_flag = "Y";
            }
            else 
            {

                objICONST_MSTR_REC = null;
                objICONST_MSTR_REC = new ICONST_MSTR_REC
                {
                    WhereIconst_clinic_nbr = ws_request_clinic_ident
                }.Collection().FirstOrDefault();                 

                if (objICONST_MSTR_REC != null)
                {
                    ws_clinic_nbr = Util.NumInt(objICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2);
                    group_nbr_flag = "Y";
                }
            } 
        }

        private void aa3_99_exit()
        {
            //     exit.;
        }
        private string  ab0_processing()
        {
            // if edt-1-record-type = "1"  then;            
            if (objEdt_1_record.Edt_1_record_type == "1")
            {
                //    if ws-request-clinic-ident not = edt-1-group-nbr 	then;            
                if (ws_request_clinic_ident != objEdt_1_record.Edt_1_group_nbr)
                {
                    edt_eof_flag = "Y";
                    //    go to ab0-99-exit.;                    
                    return "ab0_99_exit";
                }
            }

            //  perform xa1-create-tape-files thru xa1-99-exit.;
            xa1_create_tape_files();
            xa1_99_exit();

            return string.Empty;
        }

        private void ab0_10_read_next_rat()
        {
            //  perform xa0-read-edt-tape             thru xa0-99-exit.;
            xa0_read_edt_tape();
            xa0_99_exit();
        }

        private void ab0_99_exit()
        {
            //     exit.;
        }

        private void az0_end_of_job()
        {

            //     display " ".;
            //     display "OHIP RATS READ          "       ctr-edt-tape-reads.;
            //     display "OHIP RATS REC 1 READ    "       ctr-edt-rec1-reads.;
            //     display "OHIP RATS REC H READ    "       ctr-edt-rech-reads.;
            //     display "OHIP RATS REC R READ    "       ctr-edt-recr-reads.;
            //     display "OHIP RATS REC T READ    "       ctr-edt-rect-reads.;
            //     display "OHIP RATS REC 8 READ    "       ctr-edt-rec8-reads.;
            //     display "OHIP RATS REC 9 READ    "       ctr-edt-rec9-reads.;
            //     display "HCP HEADER REC READ     "       hcp-records.;
            //     display "RMB HEADER REC READ     "       rmb-records.;
            //     display "HCP DTL REC WRITE       "       ctr-hcp-dtl-writes.;
            //     display "RMB DTL REC WRITE       "       ctr-rmb-dtl-writes.;


            Console.WriteLine("OHIP RATS READ          " + ctr_edt_tape_reads);
            Console.WriteLine("OHIP RATS REC 1 READ    " + ctr_edt_rec1_reads);
            Console.WriteLine("OHIP RATS REC H READ    " + ctr_edt_rech_reads);
            Console.WriteLine("OHIP RATS REC R READ    " + ctr_edt_recr_reads);
            Console.WriteLine("OHIP RATS REC T READ    " + ctr_edt_rect_reads);
            Console.WriteLine("OHIP RATS REC 8 READ    " + ctr_edt_rec8_reads);
            Console.WriteLine("OHIP RATS REC 9 READ    " + ctr_edt_rec9_reads);
            Console.WriteLine("HCP HEADER REC READ     " + hcp_records);
            Console.WriteLine("RMB HEADER REC READ     " + rmb_records);
            Console.WriteLine("HCP DTL REC WRITE       " + ctr_hcp_dtl_writes);
            Console.WriteLine("RMB DTL REC WRITE       " + ctr_rmb_dtl_writes);

            //     close iconst-mstr;
            //           edt-hx-error-file;
            //    	  edt-1ht-file;
            //    	  edt-rmb-file .;
            //     display " ".;
            //     display "NORMAL END OF JOB - U031A ".;
            Console.WriteLine("NORMAL END OF JOB - U031A ");
            //     stop run.;
        }

        private void az0_99_exit()
        {
            //     exit.;
        }

        private void xa0_read_edt_tape()
        {
            //  read edt-hx-error-file;
            //          at end;
            //    edt_eof_flag = "Y";
            //               go to xa0-99-exit.;

            if (Edt_1_record_Collection == null || Edt_1_record_Collection.Count() == 0)     // Todo... u021_edt_submission_error_hx_file.fd  Where 
            {
                edt_eof_flag = "Y";
                xa0_99_exit();
                return;
            }
            else if (Edt_1_record_Collection == null || ctr_edt_tape_reads >= Edt_1_record_Collection.Count())
            {
                edt_eof_flag = "Y";
                xa0_99_exit();
                return;
            }
            else
            {
                objEdt_1_record = Edt_1_record_Collection[ctr_edt_tape_reads];
               

                if (objEdt_1_record.Edt_1_record_type.Equals("1"))
                {
                    objEdt_1_record = Edt_1_record_Collection[ctr_edt_tape_reads];
                }
                else if (objEdt_1_record.Edt_1_record_type.ToUpper().Equals("H"))
                {
                    objEdt_h_record = objEdt_1_record.Edt_Reference as Edt_h_record;
                }
                else if (objEdt_1_record.Edt_1_record_type.ToUpper().Equals("R"))
                {
                    objEdt_r_record = objEdt_1_record.Edt_Reference as Edt_r_record;
                }
                else if (objEdt_1_record.Edt_1_record_type.ToUpper().Equals("T"))
                {
                    objEdt_t_record = objEdt_1_record.Edt_Reference as Edt_t_record;
                }
                else if (objEdt_1_record.Edt_1_record_type.Equals("8"))
                {
                    objEdt_8_record = objEdt_1_record.Edt_Reference as Edt_8_record;
                }
                else if (objEdt_1_record.Edt_1_record_type.Equals("9"))
                {
                    objEdt_9_record = objEdt_1_record.Edt_Reference as Edt_9_record;
                }
                ctr_edt_tape_reads++;
               
            }

            //     add 1 to ctr-edt-tape-reads.;
        }

        private void xa0_99_exit()
        {
            //     exit.;
        }

        private void xa1_create_tape_files()
        {

            if (objEdt_1_record.Edt_1_record_type == "1")
            {
                //         add 1                              to ctr-edt-rec1-reads;
               //if (ctr_edt_tape_reads < Edt_1_record_Collection.Count())  ctr_edt_rec1_reads++;
                //         perform aa1-record-1-process;
                aa1_record_1_process();
            }
            else if (objEdt_1_record.Edt_1_record_type == "H")
            {
                //     	add 1                              to ctr-edt-rech-reads;
                if (ctr_edt_tape_reads < Edt_1_record_Collection.Count()) ctr_edt_rech_reads++;
                //    	perform xb0-process-rec-h          thru xb0-99-exit;
                xb0_process_rec_h();
                xb0_99_exit();
            }
            else if (objEdt_1_record.Edt_1_record_type == "R")
            {
                //     	add 1                              to ctr-edt-recr-reads;
                if (ctr_edt_tape_reads < Edt_1_record_Collection.Count()) ctr_edt_recr_reads++;
                //    	perform xb1-process-rec-r          thru xb1-99-exit;
                xb1_process_rec_r();
                xb1_99_exit();
            }
            else if (objEdt_1_record.Edt_1_record_type == "T")
            {
                //     add 1                         to ctr-edt-rect-reads;
                if (ctr_edt_tape_reads < Edt_1_record_Collection.Count()) ctr_edt_rect_reads++;
                //     perform xb2-process-rec-t     thru xb2-99-exit;
                xb2_process_rec_t();
                xb2_99_exit();
            }
            else if (objEdt_1_record.Edt_1_record_type == "8")
            {
                //    add 1                   to ctr-edt-rec8-reads;
                if (ctr_edt_tape_reads < Edt_1_record_Collection.Count()) ctr_edt_rec8_reads++;

                //    perform xb3-process-rec-8  thru xb3-99-exit;
                xb3_process_rec_8();
                xb3_99_exit();
            }
            else if (objEdt_1_record.Edt_1_record_type == "9")
            {
                //  add 1                   to ctr-edt-rec9-reads;
                 ctr_edt_rec9_reads++;

                //  perform xb4-process-rec-9  thru xb4-99-exit.;
                xb4_process_rec_9();
                xb4_99_exit();
            }
        }

        private void xa1_99_exit()
        {
            //     exit.;
        }

        private void xb0_process_rec_h()
        {
            //  if last-record-is-item  then;     
            if (last_record.Equals(last_record_is_item))
            {
                // 	     if hcp-claims then;            
                if (hcp_rmb_flag.Equals(hcp_claims))
                {
                    // 	perform xc1-write-1ht-record 	thru xc1-99-exit;
                    xc1_write_1ht_record();
                    xc1_99_exit();
                }
                else
                {
                    // 	perform xc2-write-rmb-record 	thru xc2-99-exit.;
                    xc2_write_rmb_record();
                    xc2_99_exit();
                }
            }

            // if edt-h-pay-prog =  'HCP' then;       
            if (objEdt_h_record.Edt_h_pay_prog == "HCP")
            {
                hcp_rmb_flag = "N";
            }
            else
            {
                hcp_rmb_flag = "Y";
            }

            //     add 1 			 	to ws-unique-rec-ctr.;
            ws_unique_rec_ctr++;

            if (hcp_rmb_flag.Equals(hcp_claims))
            {
                //         add 1                           to hcp-records;
                hcp_records++;

                //objEdt_1ht_record.edt_  Edt_1ht_record = "";
                objEdt_1ht_record = new Edt_1ht_record();
                objEdt_1ht_record.Edt_1ht_orig_seq_nbr = ws_unique_rec_ctr;
                objEdt_1ht_record.Edt_1ht_file_name = ws_orig_file_name;
                objEdt_1ht_record.Edt_1ht_group_nbr = ws_edt_clinic_nbr + "00"; // ws_edt_1_group_nbr_grp;
                objEdt_1ht_record.Edt_1ht_moh_off_cd = ws_edt_1_moh_off_cd;
                objEdt_1ht_record.Edt_1ht_station_nbr = ws_edt_1_station_nbr;
                objEdt_1ht_record.Edt_1ht_process_date = ws_edt_1_process_date;
                objEdt_1ht_record.Edt_1ht_doc_nbr = ws_edt_1_doc_nbr;
                objEdt_1ht_record.Edt_1ht_specialty_cd = ws_edt_1_specialty_cd;
                objEdt_1ht_record.Edt_1ht_health_nbr = objEdt_h_record.Edt_h_health_nbr;
                objEdt_1ht_record.Edt_1ht_version_cd = objEdt_h_record.Edt_h_version_cd;
                objEdt_1ht_record.Edt_1ht_birth_date = Util.NumInt(objEdt_h_record.Edt_h_birth_date);
                objEdt_1ht_record.Edt_1ht_account_nbr = objEdt_h_record.Edt_h_account_nbr;
                objEdt_1ht_record.Edt_1ht_pay_prog = objEdt_h_record.Edt_h_pay_prog;
                objEdt_1ht_record.Edt_1ht_payee = objEdt_h_record.Edt_h_payee;
                objEdt_1ht_record.Edt_1ht_refer_doc_nbr = objEdt_h_record.Edt_h_doc_nbr;
                objEdt_1ht_record.Edt_1ht_facility_nbr = objEdt_h_record.Edt_h_facility_nbr;
                objEdt_1ht_record.Edt_1ht_admit_date = objEdt_h_record.Edt_h_patient_admission_date;
                objEdt_1ht_record.Edt_1ht_loc_cd = objEdt_h_record.Edt_h_location_cd;
                objEdt_1ht_record.Edt_1ht_error_h_cd_1 = objEdt_h_record.Edt_h_error_cd_1;
                objEdt_1ht_record.Edt_1ht_error_h_cd_2 = objEdt_h_record.Edt_h_error_cd_2;
                objEdt_1ht_record.Edt_1ht_error_h_cd_3 = objEdt_h_record.Edt_h_error_cd_3;
                objEdt_1ht_record.Edt_1ht_error_h_cd_4 = objEdt_h_record.Edt_h_error_cd_4;
                objEdt_1ht_record.Edt_1ht_error_h_cd_5 = objEdt_h_record.Edt_h_error_cd_5;
            }
            else if (hcp_rmb_flag.Equals(rmb_claims))
            {
                //         add 1                           to rmb-records;
                rmb_records++;
                objEdt_rmb_record = new Edt_rmb_record();  //edt_rmb_record = "";
                objEdt_rmb_record.Edt_rmb_orig_seq_nbr = Util.Str(ws_unique_rec_ctr);
                objEdt_rmb_record.Edt_rmb_file_name = ws_orig_file_name;
                objEdt_rmb_record.Edt_rmb_group_nbr = ws_edt_clinic_nbr + "00";   //ws_edt_1_group_nbr;
                objEdt_rmb_record.Edt_rmb_moh_off_cd = ws_edt_1_moh_off_cd;
                objEdt_rmb_record.Edt_rmb_station_nbr = ws_edt_1_station_nbr;
                objEdt_rmb_record.Edt_rmb_process_date = ws_edt_1_process_date;
                objEdt_rmb_record.Edt_rmb_doc_nbr = ws_edt_1_doc_nbr;
                objEdt_rmb_record.Edt_rmb_specialty_cd = ws_edt_1_specialty_cd;
                objEdt_rmb_record.Edt_rmb_health_nbr = objEdt_h_record.Edt_h_health_nbr;
                objEdt_rmb_record.Edt_rmb_version_cd = objEdt_h_record.Edt_h_version_cd;
                objEdt_rmb_record.Edt_rmb_birth_date = Util.NumInt(objEdt_h_record.Edt_h_birth_date);
                objEdt_rmb_record.Edt_rmb_account_nbr = objEdt_h_record.Edt_h_account_nbr;
                objEdt_rmb_record.Edt_rmb_pay_prog = objEdt_h_record.Edt_h_pay_prog;
                objEdt_rmb_record.Edt_rmb_payee = objEdt_h_record.Edt_h_payee;
                objEdt_rmb_record.Edt_rmb_refer_doc_nbr = objEdt_h_record.Edt_h_doc_nbr;
                objEdt_rmb_record.Edt_rmb_facility_nbr = objEdt_h_record.Edt_h_facility_nbr;
                objEdt_rmb_record.Edt_rmb_admit_date = objEdt_h_record.Edt_h_patient_admission_date;
                objEdt_rmb_record.Edt_rmb_loc_cd = objEdt_h_record.Edt_h_location_cd;
                objEdt_rmb_record.Edt_rmb_error_h_cd_1 = objEdt_h_record.Edt_h_error_cd_1;
                objEdt_rmb_record.Edt_rmb_error_h_cd_2 = objEdt_h_record.Edt_h_error_cd_2;
                objEdt_rmb_record.Edt_rmb_error_h_cd_3 = objEdt_h_record.Edt_h_error_cd_3;
                objEdt_rmb_record.Edt_rmb_error_h_cd_4 = objEdt_h_record.Edt_h_error_cd_4;
                objEdt_rmb_record.Edt_rmb_error_h_cd_5 = objEdt_h_record.Edt_h_error_cd_5;
            }

            last_record = "H";
        }
        private void xb0_99_exit()
        {
            //     exit.;
        }
        private void xb1_process_rec_r()
        {
            //     add 1 			 	to ws-unique-rec-ctr.;
            ws_unique_rec_ctr++;

            // if rmb-claims  then;    
            if (hcp_rmb_flag.Equals(rmb_claims))
            {
                objEdt_rmb_record.Edt_rmb_orig_seq_nbr = Util.Str(ws_unique_rec_ctr);
                objEdt_rmb_record.Edt_rmb_file_name = ws_orig_file_name;
                objEdt_rmb_record.Edt_rmb_registration_nbr = objEdt_r_record.Edt_r_registration_nbr;
                objEdt_rmb_record.Edt_rmb_last_name = objEdt_r_record.Edt_r_last_name;
                objEdt_rmb_record.Edt_rmb_first_name = objEdt_r_record.Edt_r_first_name;
                objEdt_rmb_record.Edt_rmb_sex = objEdt_r_record.Edt_r_sex;
                objEdt_rmb_record.Edt_rmb_prov_cd = objEdt_r_record.Edt_r_prov_cd;
                objEdt_rmb_record.Edt_rmb_error_r_cd_1 = objEdt_r_record.Edt_r_error_cd_1;
                objEdt_rmb_record.Edt_rmb_error_r_cd_2 = objEdt_r_record.Edt_r_error_cd_2;
                objEdt_rmb_record.Edt_rmb_error_r_cd_3 = objEdt_r_record.Edt_r_error_cd_3;
                objEdt_rmb_record.Edt_rmb_error_r_cd_4 = objEdt_r_record.Edt_r_error_cd_4;
                objEdt_rmb_record.Edt_rmb_error_r_cd_5 = objEdt_r_record.Edt_r_error_cd_5;
            }
        }

        private void xb1_99_exit()
        {
            //    exit.;
        }

        private void xb2_process_rec_t()
        {

            //  if last-record-is-item  then;       
            if (last_record.Equals(last_record_is_item))
            {
                // 	     if hcp-claims then;       
                if (hcp_rmb_flag.Equals(hcp_claims))
                {
                    // 	         perform xc1-write-1ht-record 	thru xc1-99-exit;
                    xc1_write_1ht_record();
                    xc1_99_exit();
                }
                else
                {
                    //   perform xc2-write-rmb-record 	thru xc2-99-exit.;
                    xc2_write_rmb_record();
                    xc2_99_exit();
                }
            }

            //     add 1 			 	to ws-unique-rec-ctr.;
            ws_unique_rec_ctr++;

            // if hcp-claims  then;            
            if (hcp_rmb_flag.Equals(hcp_claims))
            {
                objEdt_1ht_record.Edt_1ht_orig_seq_nbr = ws_unique_rec_ctr;
                objEdt_1ht_record.Edt_1ht_file_name = ws_orig_file_name;
                objEdt_1ht_record.Edt_1ht_service_cd = objEdt_t_record.Edt_t_service_cd;
                objEdt_1ht_record.Edt_1ht_amount_sub = objEdt_t_record.Edt_t_amount_sub;
                objEdt_1ht_record.Edt_1ht_nbr_of_serv = Util.NumInt(objEdt_t_record.Edt_t_nbr_of_serv);
                objEdt_1ht_record.Edt_1ht_service_date = Util.NumInt(objEdt_t_record.Edt_t_service_date);
                objEdt_1ht_record.Edt_1ht_diag_cd = objEdt_t_record.Edt_t_diag_cd;
                objEdt_1ht_record.Edt_1ht_t_explan_cd = objEdt_t_record.Edt_t_explan_cd;
                objEdt_1ht_record.Edt_1ht_error_t_cd_1 = objEdt_t_record.Edt_t_error_cd_1;
                objEdt_1ht_record.Edt_1ht_error_t_cd_2 = objEdt_t_record.Edt_t_error_cd_2;
                objEdt_1ht_record.Edt_1ht_error_t_cd_3 = objEdt_t_record.Edt_t_error_cd_3;
                objEdt_1ht_record.Edt_1ht_error_t_cd_4 = objEdt_t_record.Edt_t_error_cd_4;
                objEdt_1ht_record.Edt_1ht_error_t_cd_5 = objEdt_t_record.Edt_t_error_cd_5;
                objEdt_1ht_record.Edt_1ht_8_explan_cd = "";
                objEdt_1ht_record.Edt_1ht_8_explan_desc = "";
            }
            else if (hcp_rmb_flag.Equals(rmb_claims))
            {
                objEdt_rmb_record.Edt_rmb_orig_seq_nbr = Util.Str(ws_unique_rec_ctr);
                objEdt_rmb_record.Edt_rmb_file_name = ws_orig_file_name;
                objEdt_rmb_record.Edt_rmb_service_cd = objEdt_t_record.Edt_t_service_cd;
                objEdt_rmb_record.Edt_rmb_amount_sub = objEdt_t_record.Edt_t_amount_sub;
                objEdt_rmb_record.Edt_rmb_nbr_of_serv = Util.NumInt(objEdt_t_record.Edt_t_nbr_of_serv);
                objEdt_rmb_record.Edt_rmb_service_date = Util.NumInt(objEdt_t_record.Edt_t_service_date);
                objEdt_rmb_record.Edt_rmb_diag_cd = objEdt_t_record.Edt_t_diag_cd;
                objEdt_rmb_record.Edt_rmb_t_explan_cd = objEdt_t_record.Edt_t_explan_cd;
                objEdt_rmb_record.Edt_rmb_error_t_cd_1 = objEdt_t_record.Edt_t_error_cd_1;
                objEdt_rmb_record.Edt_rmb_error_t_cd_2 = objEdt_t_record.Edt_t_error_cd_2;
                objEdt_rmb_record.Edt_rmb_error_t_cd_3 = objEdt_t_record.Edt_t_error_cd_3;
                objEdt_rmb_record.Edt_rmb_error_t_cd_4 = objEdt_t_record.Edt_t_error_cd_4;
                objEdt_rmb_record.Edt_rmb_error_t_cd_5 = objEdt_t_record.Edt_t_error_cd_5;
                objEdt_rmb_record.Edt_rmb_8_explan_cd = "";
                objEdt_rmb_record.Edt_rmb_8_explan_desc = "";
            }

            last_record = "T";
        }

        private void xb2_99_exit()
        {
            //     exit.;
        }

        private void xb3_process_rec_8()
        {

            //     add 1 			 	to ws-unique-rec-ctr.;
            ws_unique_rec_ctr++;

            // if hcp-claims  then;            
            if (hcp_rmb_flag.Equals(hcp_claims))
            {
                objEdt_1ht_record.Edt_1ht_orig_seq_nbr = ws_unique_rec_ctr;
                objEdt_1ht_record.Edt_1ht_file_name = ws_orig_file_name;
                objEdt_1ht_record.Edt_1ht_8_explan_cd = objEdt_8_record.Edt_8_explan_cd;
                objEdt_1ht_record.Edt_1ht_8_explan_desc = objEdt_8_record.Edt_8_explan_desc;
                //   perform xc1-write-1ht-record    thru xc1-99-exit;
                xc1_write_1ht_record();
                xc1_99_exit();
            }
            // else if rmb-claims  then;            
            else if (hcp_rmb_flag.Equals(rmb_claims))
            {
                objEdt_rmb_record.Edt_rmb_orig_seq_nbr = Util.Str(ws_unique_rec_ctr);
                objEdt_rmb_record.Edt_rmb_file_name = ws_orig_file_name;
                objEdt_rmb_record.Edt_rmb_8_explan_cd = objEdt_8_record.Edt_8_explan_cd;
                objEdt_rmb_record.Edt_rmb_8_explan_desc = objEdt_8_record.Edt_8_explan_desc;
                // perform xc2-write-rmb-record    thru xc2-99-exit.;
                xc2_write_rmb_record();
                xc2_99_exit();
            }

            last_record = "8";
        }

        private void xb3_99_exit()
        {
            //     exit.;
        }

        private void xb4_process_rec_9()
        {

            // if last-record-is-item then;            
            if (last_record.Equals(last_record_is_item))
            {
                // 	    if hcp-claims then;           
                if (hcp_rmb_flag.Equals(hcp_claims))
                {
                    // 	 perform xc1-write-1ht-record 	thru xc1-99-exit;
                    xc1_write_1ht_record();
                    xc1_99_exit();
                }
                else
                {
                    // 	  perform xc2-write-rmb-record 	thru xc2-99-exit.;
                    xc2_write_rmb_record();
                    xc2_99_exit();
                }
            }

            last_record = "9";
        }

        private void xb4_99_exit()
        {
            //     exit.;
        }

        private void xc1_write_1ht_record()
        {
            //     write edt-1ht-record.;
            string tmpRecord = Util.Str(objEdt_1ht_record.Edt_1ht_moh_off_cd).PadRight(1) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_group_nbr).PadRight(4) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_doc_nbr).PadLeft(6, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_specialty_cd).PadRight(2) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_station_nbr).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_process_date).PadLeft(8, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_health_nbr).PadRight(10) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_version_cd).PadRight(2) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_birth_date).PadLeft(8, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_account_nbr).PadRight(8) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_orig_seq_nbr).PadLeft(6, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_pay_prog).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_payee).PadRight(1) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_refer_doc_nbr).PadLeft(6, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_facility_nbr).PadRight(4) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_admit_date).PadLeft(8, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_loc_cd).PadRight(4) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_h_cd_1).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_h_cd_2).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_h_cd_3).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_h_cd_4).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_h_cd_5).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_service_cd).PadRight(5) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_amount_sub).PadLeft(6, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_nbr_of_serv).PadLeft(2, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_service_date).PadLeft(8, '0') +
                               Util.Str(objEdt_1ht_record.Edt_1ht_diag_cd).PadRight(4) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_t_explan_cd).PadRight(2) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_t_cd_1).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_t_cd_2).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_t_cd_3).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_t_cd_4).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_error_t_cd_5).PadRight(3) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_8_explan_cd).PadRight(2) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_8_explan_desc).PadRight(55) +
                               Util.Str(objEdt_1ht_record.Edt_1ht_file_name).PadRight(12);

            objedt_1ht_file.AppendOutputFile(tmpRecord, false);
            ctr_hcp_dtl_writes++;

            //     add 1				to ctr-hcp-dtl-writes.;
        }

        private void xc1_99_exit()
        {
            //     exit.;
        }
        private void xc2_write_rmb_record()
        {
            //     write edt-rmb-record.;

            string tmpRecord = Util.Str(objEdt_rmb_record.Edt_rmb_moh_off_cd).PadRight(1) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_group_nbr).PadRight(4) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_doc_nbr).PadLeft(6, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_specialty_cd).PadRight(2) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_station_nbr).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_process_date).PadLeft(8, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_health_nbr).PadRight(10) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_version_cd).PadRight(2) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_birth_date).PadLeft(8, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_account_nbr).PadLeft(8) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_orig_seq_nbr).PadRight(6,'0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_pay_prog).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_payee).PadRight(1) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_refer_doc_nbr).PadLeft(6, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_facility_nbr).PadRight(4) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_admit_date).PadLeft(8, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_loc_cd).PadRight(4) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_h_cd_1).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_h_cd_2).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_h_cd_3).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_h_cd_4).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_h_cd_5).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_registration_nbr).PadRight(12) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_last_name).PadRight(9) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_first_name).PadRight(5) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_sex).PadRight(1) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_prov_cd).PadRight(2) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_r_cd_1).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_r_cd_2).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_r_cd_3).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_r_cd_4).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_r_cd_5).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_service_cd).PadRight(5) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_amount_sub).PadLeft(6, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_nbr_of_serv).PadLeft(2, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_service_date).PadLeft(8, '0') +
                               Util.Str(objEdt_rmb_record.Edt_rmb_diag_cd).PadRight(4) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_t_explan_cd).PadRight(2) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_t_cd_1).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_t_cd_2).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_t_cd_3).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_t_cd_4).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_error_t_cd_5).PadRight(3) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_8_explan_cd).PadRight(2) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_8_explan_desc).PadRight(55) +
                               Util.Str(objEdt_rmb_record.Edt_rmb_file_name).PadRight(12);

            objedt_rmb_file.AppendOutputFile(tmpRecord, false);
            ctr_rmb_dtl_writes++;

            //     add 1				to ctr-rmb-dtl-writes.;
        }

        private void xc2_99_exit()
        {
            //     exit.;
        }

        private void za0_common_error()
        {
            e1_error_msg = err_msg[err_ind];
            //     display confirm.;
            //     display e1-error-line.;
        }

        private void za0_99_exit()
        {
            //     exit.;
        }

        private void zb0_abend()
        {
            //     display "U021A ABENDING";
            //     display " ".;

            Console.WriteLine("U021A ABENDING");
            Console.WriteLine("");
        }

        private void zb1_close_files()
        {
            //     close iconst-mstr;
            //           edt-hx-error-file;
            //           edt-1ht-file;
            //           edt-rmb-file.;
            //     stop run.;
            throw new Exception(endOfJob);
        }
        private void zb0_99_exit()
        {
            //     exit.;
        }

        // y2k_default_century_year.rtn
        private void y2k_add_century_to_year()
        {
            //  if century-year > 99  then;            
            if (century_year > 99)
            {
                // 	   next sentence;
            }
            //  else if century-year = 99 then;            
            else if (century_year == 99)
            {
                //     add 1900                to   century-year;
                century_year += 1900;
            }
            else
            {
                //             add 2000		    to	 century-year.;
                century_year += 2000;
            }
        }

        // y2k_default_century_year.rtn
        private void y2k_99_exit()
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
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        #endregion
    }
}

