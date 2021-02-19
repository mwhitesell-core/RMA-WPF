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
    public class U140ViewModel : CommonFunctionScr
    {        

        public U140ViewModel()
        {
            isBatchProcess = true;
            mainline();
        }
       

        #region FD Section       

        // FD: afp_a1f_file
        private Afp_a1f_record objAfp_a1f_record = null;
        private ObservableCollection<Afp_a1f_record> Afp_a1f_record_Collection;

        // FD: afp_a2g_file
        private Afp_a2g_record objAfp_a2g_record = null;
        private ObservableCollection<Afp_a2g_record> Afp_a2g_record_Collection;

        // FD: afp_a2s_file
        private Afp_a2s_record objAfp_a2s_record = null;
        private ObservableCollection<Afp_a2s_record> Afp_a2s_record_Collection;

        // FD: afp_a3c_file
        private Afp_a3c_record objAfp_a3c_record = null;
        private ObservableCollection<Afp_a3c_record> Afp_a3c_record_Collection;

        // FD: afp_a4t_file
        private Afp_a4t_record objAfp_a4t_record = null;
        private ObservableCollection<Afp_a4t_record> Afp_a4t_record_Collection;

        // FD: afp_fixed_payments	Copy : u140_afp_fixed_payments.fd
        private Afp_record objAfp_record = null;
        private ObservableCollection<Afp_record> Afp_record_Collection;
       
        // FD: iconst_mstr	Copy : f090_const_mstr_rec_1.ws
        private CONSTANTS_MSTR_REC_1 objConstants_mstr_rec_1 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_1> Constants_mstr_rec_1_Collection;

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

        private decimal _ws_doll_amt;
        public decimal ws_doll_amt
        {
            get
            {
                return _ws_doll_amt;
            }
            set
            {
                if (_ws_doll_amt != value)
                {
                    _ws_doll_amt = value;
                    RaisePropertyChanged("ws_doll_amt");
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

        private int _ws_confirm_reply;
        public int ws_confirm_reply
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

        private int _ctr_rat_tape_reads;
        public int ctr_rat_tape_reads
        {
            get
            {
                return _ctr_rat_tape_reads;
            }
            set
            {
                if (_ctr_rat_tape_reads != value)
                {
                    _ctr_rat_tape_reads = value;
                    RaisePropertyChanged("ctr_rat_tape_reads");
                }
            }
        }

        // ctr_rat_rec1_reads  1 -8
        private int _ctr_rat_rec1_reads;
        public int ctr_rat_rec1_reads
        {
            get
            {
                return _ctr_rat_rec1_reads;
            }
            set
            {
                if (_ctr_rat_rec1_reads != value)
                {
                    _ctr_rat_rec1_reads = value;
                    RaisePropertyChanged("ctr_rat_rec1_reads");
                }
            }
        }

        private int _ctr_rat_rec2_reads;
        public int ctr_rat_rec2_reads
        {
            get
            {
                return _ctr_rat_rec2_reads;
            }
            set
            {
                if (_ctr_rat_rec2_reads != value)
                {
                    _ctr_rat_rec2_reads = value;
                    RaisePropertyChanged("ctr_rat_rec2_reads");
                }
            }
        }

        private int _ctr_rat_rec3_reads;
        public int ctr_rat_rec3_reads
        {
            get
            {
                return _ctr_rat_rec3_reads;
            }
            set
            {
                if (_ctr_rat_rec3_reads != value)
                {
                    _ctr_rat_rec3_reads = value;
                    RaisePropertyChanged("ctr_rat_rec3_reads");
                }
            }
        }

        private int _ctr_rat_rec4_reads;
        public int ctr_rat_rec4_reads
        {
            get
            {
                return _ctr_rat_rec4_reads;
            }
            set
            {
                if (_ctr_rat_rec4_reads != value)
                {
                    _ctr_rat_rec4_reads = value;
                    RaisePropertyChanged("ctr_rat_rec4_reads");
                }
            }
        }

        private int _ctr_rat_rec5_reads;
        public int ctr_rat_rec5_reads
        {
            get
            {
                return _ctr_rat_rec5_reads;
            }
            set
            {
                if (_ctr_rat_rec5_reads != value)
                {
                    _ctr_rat_rec5_reads = value;
                    RaisePropertyChanged("ctr_rat_rec5_reads");
                }
            }
        }

        private int _ctr_rat_rec6_reads;
        public int ctr_rat_rec6_reads
        {
            get
            {
                return _ctr_rat_rec6_reads;
            }
            set
            {
                if (_ctr_rat_rec6_reads != value)
                {
                    _ctr_rat_rec6_reads = value;
                    RaisePropertyChanged("ctr_rat_rec6_reads");
                }
            }
        }

        private int _ctr_rat_rec7_reads;
        public int ctr_rat_rec7_reads
        {
            get
            {
                return _ctr_rat_rec7_reads;
            }
            set
            {
                if (_ctr_rat_rec7_reads != value)
                {
                    _ctr_rat_rec7_reads = value;
                    RaisePropertyChanged("ctr_rat_rec7_reads");
                }
            }
        }

        private int _ctr_rat_rec8_reads;
        public int ctr_rat_rec8_reads
        {
            get
            {
                return _ctr_rat_rec8_reads;
            }
            set
            {
                if (_ctr_rat_rec8_reads != value)
                {
                    _ctr_rat_rec8_reads = value;
                    RaisePropertyChanged("ctr_rat_rec8_reads");
                }
            }
        }

        private int _hcp_records;
        public int hcp_records
        {
            get
            {
                return _hcp_records;
            }
            set
            {
                if (_hcp_records != value)
                {
                    _hcp_records = value;
                    RaisePropertyChanged("hcp_records");
                }
            }
        }

        // rmb_records
        private int _rmb_records;
        public int rmb_records
        {
            get
            {
                return _rmb_records;
            }
            set
            {
                if (_rmb_records != value)
                {
                    _rmb_records = value;
                    RaisePropertyChanged("rmb_records");
                }
            }
        }

        private string _e1_error_msg;
        public string e1_error_msg
        {
            get
            {
                return _e1_error_msg;
            }
            set
            {
                if (_e1_error_msg != value)
                {
                    _e1_error_msg = value;
                    _e1_error_msg = _e1_error_msg.ToUpper();
                    RaisePropertyChanged("e1_error_msg");
                }
            }
        }

        private int _ctr_afp_file_reads;
        public int ctr_afp_file_reads
        {
            get
            {
                return _ctr_afp_file_reads;
            }
            set
            {
                if (_ctr_afp_file_reads != value)
                {
                    _ctr_afp_file_reads = value;
                    RaisePropertyChanged("ctr_afp_file_reads");
                }
            }
        }

        private int _ctr_afp_rec1_reads;
        public int ctr_afp_rec1_reads
        {
            get
            {
                return _ctr_afp_rec1_reads;
            }
            set
            {
                if (_ctr_afp_rec1_reads != value)
                {
                    _ctr_afp_rec1_reads = value;
                    RaisePropertyChanged("ctr_afp_rec1_reads");
                }
            }
        }

        private int _ctr_afp_rec2_reads;
        public int ctr_afp_rec2_reads
        {
            get
            {
                return _ctr_afp_rec2_reads;
            }
            set
            {
                if (_ctr_afp_rec2_reads != value)
                {
                    _ctr_afp_rec2_reads = value;
                    RaisePropertyChanged("ctr_afp_rec2_reads");
                }
            }
        }

        private int _ctr_afp_rec3_reads;
        public int ctr_afp_rec3_reads
        {
            get
            {
                return _ctr_afp_rec3_reads;
            }
            set
            {
                if (_ctr_afp_rec3_reads != value)
                {
                    _ctr_afp_rec3_reads = value;
                    RaisePropertyChanged("ctr_afp_rec3_reads");
                }
            }
        }

        private int _ctr_afp_rec4_reads;
        public int ctr_afp_rec4_reads
        {
            get
            {
                return _ctr_afp_rec4_reads;
            }
            set
            {
                if (_ctr_afp_rec4_reads != value)
                {
                    _ctr_afp_rec4_reads = value;
                    RaisePropertyChanged("ctr_afp_rec4_reads");
                }
            }
        }

        private int _ctr_afp_rec5_reads;
        public int ctr_afp_rec5_reads
        {
            get
            {
                return _ctr_afp_rec5_reads;
            }
            set
            {
                if (_ctr_afp_rec5_reads != value)
                {
                    _ctr_afp_rec5_reads = value;
                    RaisePropertyChanged("ctr_afp_rec5_reads");
                }
            }
        }

        private int _ctr_afp_rec6_reads;
        public int ctr_afp_rec6_reads
        {
            get
            {
                return _ctr_afp_rec6_reads;
            }
            set
            {
                if (_ctr_afp_rec6_reads != value)
                {
                    _ctr_afp_rec6_reads = value;
                    RaisePropertyChanged("ctr_afp_rec6_reads");
                }
            }
        }

        private int _ctr_afp_rec7_reads;
        public int ctr_afp_rec7_reads
        {
            get
            {
                return _ctr_afp_rec7_reads;
            }
            set
            {
                if (_ctr_afp_rec7_reads != value)
                {
                    _ctr_afp_rec7_reads = value;
                    RaisePropertyChanged("ctr_afp_rec7_reads");
                }
            }
        }

        private int _ctr_afp_rec8_reads;
        public int ctr_afp_rec8_reads
        {
            get
            {
                return _ctr_afp_rec8_reads;
            }
            set
            {
                if (_ctr_afp_rec8_reads != value)
                {
                    _ctr_afp_rec8_reads = value;
                    RaisePropertyChanged("ctr_afp_rec8_reads");
                }
            }
        }

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string last_claim_nbr;
        //private int ws_sel_month;
        //private string ws_flag_tape_mth;
        //private string ws_flag_over_mth;
        //private int ws_scr_day;
        //private int ws_scr_year;
        //private string ws_scr_month;
        //private decimal ws_doll_amt;
        private string ws_request_clinic_ident;
        //private string ws_reply;
        //private string ws_confirm_reply;
        private decimal ws_afp_67_amt_bill;
        private decimal ws_afp_67_amt_paid;
        private string status_file;
        private string status_iconst_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string feedback_iconst_mstr;
        private int i;
        private string group_nbr_flag;
        private string group_nbr_found;
        private string group_nbr_not_found;
        private string afp_eof_flag;
        private string afp_eof;

        private string ws_afp_1_group_nbr_grp;
        private int ws_afp_clinic_nbr;
        private string filler;
        private int ws_clinic_nbr;
        private string ws_afp_1_moh_off_cd;
        private int ws_afp_1_data_seq_nbr;
        private int ws_afp_1_payment_date;
        private string ws_afp_1_last_name;
        private string ws_afp_1_title;
        private string ws_afp_1_initials;
        private decimal ws_afp_1_tot_amt_pay;
        private string ws_afp_1_cheq_nbr;

        private string counters_grp;
        /*private int ctr_afp_file_reads;
        private int ctr_afp_rec1_reads;
        private int ctr_afp_rec2_reads;
        private int ctr_afp_rec3_reads;
        private int ctr_afp_rec4_reads;
        private int ctr_afp_rec5_reads;
        private int ctr_afp_rec6_reads;
        private int ctr_afp_rec7_reads;
        private int ctr_afp_rec8_reads; */

        private string error_message_table_grp;
        private string error_messages_grp;
        /* private string filler = "Incoming AFP file is Empty!";
         private string filler = "Invalid Record ID found!";
         private string filler = "INVALID GROUP IDENTIFIER";
         private string filler = "RAT TAPE MONTH MUST BE NUMERIC ONLY";
         private string filler = "GROUP IDENTIFICATION MUST BE NUMERIC";
         private string filler = "invalid reply";
         private string filler = "CONSTANT MSTR RECORD 1 DOES NOT EXIST"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "Incoming AFP file is Empty!", "Invalid Record ID found!", "INVALID GROUP IDENTIFIER", "RAT TAPE MONTH MUST BE NUMERIC ONLY", "GROUP IDENTIFICATION MUST BE NUMERIC", "invalid reply", "CONSTANT MSTR RECORD 1 DOES NOT EXIST" };
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        // private string e1_error_msg;
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

        private string month_descs_and_max_days_mth_grp;
        private string mth_desc_max_days_grp;
        /* private string filler = '31  january031';
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

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "u130",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 20,Data1 = "AFP Conversion Payment",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "08",Col = 10,Data1 = "CONTINUE?  (ENTER Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "21",Col = 20,Data1 = "PROGRAM U030 IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -   ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-month-id.",Line = "10",Col = 20,Data1 = "ENTER RAT TAPE MONTH",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-month-id.",Line = "10",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_sel_month",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-search-rec-type-1.",Line = "12",Col = 20,Data1 = "NOW SEARCHING FOR RAT TAPE RECORD TYPE 1",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 20,Data1 = "DATE OF TAPE IS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_scr_day",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 39,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(9)",MaxLength = 9,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_scr_month",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_scr_year",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "15",Col = 20,Data1 = "RAT TAPE CLINIC AMOUNT $",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "15",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z,zzz,zz9.99",MaxLength = 10,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_doll_amt",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-accept-mth.",Line = "17",Col = 20,Data1 = "ACCEPT THIS TAPE MONTH (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-accept-mth.",Line = "17",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_flag_tape_mth",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "19",Col = 20,Data1 = "MONTH ENTERED AND MONTH FOUND ON TAPE DON'T MATCH",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "20",Col = 20,Data1 = "DO YOU STILL WANT TO CONTINUE (Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "20",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_flag_over_mth",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "22",Col = 20,Data1 = "* WARNING * YOU HAVE ENTERED 'N' ! RE-ENTER TO CONFIRM",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "23",Col = 20,Data1 = "DO YOU STILL WANT TO CONTINUE (Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_confirm_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "e1-error-line.",Line = "23",Col = 1,Data1 = "***  ERROR - ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "e1-error-line.",Line = "23",Col = 14,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(119)", MaxLength=119, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "e1_error_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "abend.",Line = "23",Col = 1,Data1 = "U030 ABENDING",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

          // ... 
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "2",Col = 1,Data1 = "OHIP RATS READ          ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "3",Col = 1,Data1 = "OHIP RATS REC 1 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "4",Col = 1,Data1 = "OHIP RATS REC 2 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "5",Col = 1,Data1 = "OHIP RATS REC 3 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "6",Col = 1,Data1 = "OHIP RATS REC 4 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "7",Col = 1,Data1 = "OHIP RATS REC 5 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "8",Col = 1,Data1 = "OHIP RATS REC 6 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "9",Col = 1,Data1 = "OHIP RATS REC 7 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "10",Col = 1,Data1 = "OHIP RATS REC 8 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "2",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)", MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_file_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "3",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec1_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "4",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec2_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "5",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec3_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "6",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec4_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "7",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec5_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "8",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec6_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "9",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec7_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "10",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_afp_rec8_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
        new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "15",Col = 1,Data1 = "NORMAL END OF JOB - u140 ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion

        private async Task initialize_objects()
        {
            objAfp_record = null;
            Afp_a1f_record_Collection = new ObservableCollection<Afp_a1f_record>();

            objAfp_a2g_record = null;
            Afp_a2g_record_Collection = new ObservableCollection<Afp_a2g_record>();

            objAfp_a2s_record = null;
            Afp_a2s_record_Collection = new ObservableCollection<Afp_a2s_record>();

            objAfp_a3c_record = null;
            Afp_a3c_record_Collection = new ObservableCollection<Afp_a3c_record>();

            objAfp_a4t_record = null;
            Afp_a4t_record_Collection = new ObservableCollection<Afp_a4t_record>();

            objAfp_record = null;
            Afp_record_Collection = new ObservableCollection<Afp_record>();
        }
        public async void mainline()
        {

            await initialize_objects();

            Afp_record_Collection = base.Read_U140_afp_fixed_payments_DAT_SequentialFile();

            //     perform aa0-initialization        	thru aa0-99-exit.;
            await aa0_initialization();
            await aa0_10_accept_clinic();
            await aa0_15_accept_month();
            await aa0_20_continue_reading();
            await aa0_99_exit();

            //     perform ab0-processing             	thru ab0-99-exit;
            //        until afp-eof.;

            do
            {
                await ab0_processing();
                await ab0_10_read_next_afp();
                await ab0_99_exit();
            }
            while (!afp_eof_flag.Equals("Y"));

            //     perform az0-end-of-job              thru az0-99-exit.;
            await az0_end_of_job();
            await az0_99_exit();
            //     stop run.;
        }
        private async Task aa0_initialization()
        {
            //     accept sys-date                        from date.;
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

            //     perform y2k-default-sysdate         thru y2k-default-sysdate-exit.;
            await y2k_default_sysdate();
            await y2k_default_sysdate_exit();
            //     accept sys-time                   from time.;
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
            //counters = 0;
            ctr_rat_tape_reads = 0;
            ctr_rat_rec1_reads = 0;
            ctr_rat_rec2_reads = 0;
            ctr_rat_rec3_reads = 0;
            ctr_rat_rec4_reads = 0;
            ctr_rat_rec5_reads = 0;
            ctr_rat_rec6_reads = 0;
            ctr_rat_rec7_reads = 0;
            ctr_rat_rec8_reads = 0;
            hcp_records = 0;
            rmb_records = 0;

            afp_eof_flag = "N";
            group_nbr_flag = "N";
            //     open input iconst-mstr.;
            //     objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 01;
            //     read iconst-mstr;
            //     invalid key;
            //             err_ind = 7;
            //                perform za0-common-error        thru za0-99-exit;
            //                 perform zb0-abend               thru zb0-99-exit.;
            //     display scr-title.;

            Constants_mstr_rec_1_Collection = new CONSTANTS_MSTR_REC_1
            {
                WhereConst_rec_nbr = 1
            }.Collection();

            if (Constants_mstr_rec_1_Collection.Count == 0)
            {
                err_ind = 7;
                await za0_common_error();
                await za0_99_exit();
                await zb0_abend();
                await zb0_99_exit();
            }
            else
            {
                objConstants_mstr_rec_1 = Constants_mstr_rec_1_Collection.FirstOrDefault();
            }

            ClearScreen();
            Display("scr-title.");
            Console.WriteLine("u140" + new string(' ', 20) + "AFP Conversion Payment" + new string(' ', 24) + Util.Str(sys_yy) + "/" + Util.Str(sys_mm) + "/" + Util.Str(sys_dd));
        }
        private async Task aa0_10_accept_clinic()
        {
        }
        private async Task aa0_15_accept_month()
        {
            //     open input  afp-fixed-payments.;
            //     open output afp-a1f-file;
            // 		afp-a2g-file;
            // 		afp-a2s-file;
            // 		afp-a3c-file;
            // 		afp-a4t-file.;
        }

        private async Task aa0_20_continue_reading()
        {
            //     perform xa0-read-afp-file              thru xa0-99-exit;
            await xa0_read_afp_file();
            await xa0_99_exit();

            //     if afp-eof then;            
            //        err_ind = 1;
            // 	      perform za0-common-error                thru    za0-99-exit;
            //        perform zb0-abend                       thru    zb0-99-exit.;

            if (afp_eof_flag.ToUpper().Equals("Y"))
            {
                err_ind = 1;
                await za0_common_error();
                await za0_99_exit();
                await zb0_abend();
                await zb1_close_files();
                await zb0_99_exit();
            }
        }
        private async Task aa0_99_exit()
        {
            //     exit.;
        }
        private async Task ab0_processing()
        {
            //     if afp-record-id = "A1F" then;            
            //          objAfp_a1f_record					pic.afp_a1f_record = objAfp_record.afp_record;
            //  	    write afp-a1f-record;            
            //      else if afp-record-id = "A2G" then            
            //           objAfp_a2g_record pic.afp_a2g_record = objAfp_record.afp_record;
            //  	     write afp-a2g-record;
            //     else if afp-record-id = "A2S" then;                       
            //           objAfp_a2s_record pic.afp_a2s_record = objAfp_record.afp_record;
            //  	     write afp-a2s-record;
            //     else if afp-record-id = "A3C" then            
            //           objAfp_a3c_record pic.afp_a3c_record = objAfp_record.afp_record;
            //  	     write afp-a3c-record;
            //     else if afp-record-id = "A4T" then;            
            //          objAfp_a4t_record pic.afp_a4t_record = objAfp_record.afp_record;
            //  	    write afp-a4t-record;
            //     else;
            //          err_ind = 2;
            //           perform za0-common-error    thru za0-99-exit;
            // 	       display ctr-afp-file-reads;
            // 	       stop "Error at above record number ";
            // 	       stop run.;

            if (objAfp_record.Afp_record_id.Equals("A1F"))
            {               
                //  	    write afp-a1f-record;            
                AFP_A1F_FILE objAFP_A1F_FILE = null;
                objAFP_A1F_FILE = new AFP_A1F_FILE();
                objAFP_A1F_FILE.AFP_TRANSACTION_ID = objAfp_record.Afp_record_data.Substring(0, 2);
                objAFP_A1F_FILE.AFP_RECORD_ID = objAfp_record.Afp_record_data.Substring(2, 1);
                objAFP_A1F_FILE.FILLER_1 = objAfp_record.Afp_record_data.Substring(3, 1);
                objAFP_A1F_FILE.AFP_GOVERNANCE_GROUP = objAfp_record.Afp_record_data.Substring(4, 4);
                objAFP_A1F_FILE.FILLER_2 = objAfp_record.Afp_record_data.Substring(8, 6);
                objAFP_A1F_FILE.AFP_GROUP_NAME = objAfp_record.Afp_record_data.Substring(14, 75);
                objAFP_A1F_FILE.AFP_PAYMENT_SIGN = objAfp_record.Afp_record_data.Substring(89, 1);
                objAFP_A1F_FILE.AFP_PAYMENT_AMT = Util.NumDec(objAfp_record.Afp_record_data.Substring(90, 11));
                objAFP_A1F_FILE.FILLER_3 = objAfp_record.Afp_record_data.Substring(101, 5);
                objAFP_A1F_FILE.AFP_REPORTING_MTH = objAfp_record.Afp_record_data.Substring(106, 6);
                objAFP_A1F_FILE.AFP_RELEASE_ID = objAfp_record.Afp_record_data.Substring(112, 3);
                objAFP_A1F_FILE.FILLER_4 = objAfp_record.Afp_record_data.Substring(115, 19);
                objAFP_A1F_FILE.RecordState = State.Added;
                objAFP_A1F_FILE.Submit();

            }
            else if (objAfp_record.Afp_record_id.Equals("A2G"))
            {
                objAfp_a2g_record = objAfp_record.Aft_Record_Reference as Afp_a2g_record;
                //  	     write afp-a2g-record;         

                AFP_A2G_FILE objAFP_A2G_FILE = null;
                objAFP_A2G_FILE = new AFP_A2G_FILE();
                objAFP_A2G_FILE.AFP_TRANSACTION_ID = objAfp_a2g_record.Afp_a2g_record1.Substring(0, 2);
                objAFP_A2G_FILE.AFP_RECORD_ID = objAfp_a2g_record.Afp_a2g_record1.Substring(2, 1);
                objAFP_A2G_FILE.FILLER_1 = objAfp_a2g_record.Afp_a2g_record1.Substring(3, 1);
                objAFP_A2G_FILE.DOC_AFP_PAYM_GROUP = objAfp_a2g_record.Afp_a2g_record1.Substring(4, 4);
                objAFP_A2G_FILE.FILLER_2 = objAfp_a2g_record.Afp_a2g_record1.Substring(8, 6);
                objAFP_A2G_FILE.AFP_GROUP_NAME = objAfp_a2g_record.Afp_a2g_record1.Substring(14, 75);
                objAFP_A2G_FILE.AFP_PAYMENT_SIGN = objAfp_a2g_record.Afp_a2g_record1.Substring(89, 1);
                objAFP_A2G_FILE.AFP_PAYMENT_AMT = Util.NumDec(objAfp_a2g_record.Afp_a2g_record1.Substring(90, 11));
                objAFP_A2G_FILE.AFP_PAYMENT_PERCENTAGE = Util.NumDec(objAfp_a2g_record.Afp_a2g_record1.Substring(101, 5));
                objAFP_A2G_FILE.AFP_SUBMISSION_SIGN = objAfp_a2g_record.Afp_a2g_record1.Substring(106, 1);
                objAFP_A2G_FILE.AFP_SUBMISSION_AMT = Util.NumDec(objAfp_a2g_record.Afp_a2g_record1.Substring(107, 11));
                objAFP_A2G_FILE.FILLER_3 = objAfp_a2g_record.Afp_a2g_record1.Substring(118, 16);
                objAFP_A2G_FILE.RecordState = State.Added;
                objAFP_A2G_FILE.Submit();
            }
            else if (objAfp_record.Afp_record_id.Equals("A2S"))
            {
                objAfp_a2s_record = objAfp_record.Aft_Record_Reference as Afp_a2s_record;
                // 	     write afp-a2s-record;            
                AFP_A2S_FILE objAFP_A2S_FILE = null;
                objAFP_A2S_FILE = new AFP_A2S_FILE();
                objAFP_A2S_FILE.AFP_TRANSACTION_ID = objAfp_a2s_record.Afp_a2s_record1.Substring(0, 2);
                objAFP_A2S_FILE.AFP_RECORD_ID = objAfp_a2s_record.Afp_a2s_record1.Substring(2, 1);
                objAFP_A2S_FILE.FILLER_1 = objAfp_a2s_record.Afp_a2s_record1.Substring(3, 1);
                objAFP_A2S_FILE.DOC_AFP_PAYM_GROUP = objAfp_a2s_record.Afp_a2s_record1.Substring(4, 4);
                objAFP_A2S_FILE.DOC_AFP_PAYM_SOLO = objAfp_a2s_record.Afp_a2s_record1.Substring(8, 6);
                objAFP_A2S_FILE.AFP_SOLO_NAME = objAfp_a2s_record.Afp_a2s_record1.Substring(14, 75);
                objAFP_A2S_FILE.AFP_CONVERSION_SIGN = objAfp_a2s_record.Afp_a2s_record1.Substring(89, 1);
                objAFP_A2S_FILE.AFP_CONVERSION_AMT = Util.NumDec(objAfp_a2s_record.Afp_a2s_record1.Substring(90, 11));
                objAFP_A2S_FILE.AFP_PAYMENT_PERCENTAGE = Util.NumDec(objAfp_a2s_record.Afp_a2s_record1.Substring(101, 5));
                objAFP_A2S_FILE.AFP_SUBMISSION_SIGN = objAfp_a2s_record.Afp_a2s_record1.Substring(106, 1);
                objAFP_A2S_FILE.AFP_SUBMISSION_AMT = Util.NumDec(objAfp_a2s_record.Afp_a2s_record1.Substring(107, 11));
                objAFP_A2S_FILE.FILLER_3 = objAfp_a2s_record.Afp_a2s_record1.Substring(118, 16);
                objAFP_A2S_FILE.RecordState = State.Added;
                objAFP_A2S_FILE.Submit();
            }
            else if (objAfp_record.Afp_record_id.Equals("A3C"))
            {
                objAfp_a3c_record = objAfp_record.Aft_Record_Reference as Afp_a3c_record;
                //  write afp-a3c-record;                 
                AFP_A3C_FILE objAFP_A3C_FILE = null;
                objAFP_A3C_FILE = new AFP_A3C_FILE();
                objAFP_A3C_FILE.AFP_TRANSACTION_ID = objAfp_a3c_record.Afp_a3c_record1.Substring(0, 2);
                objAFP_A3C_FILE.AFP_RECORD_ID = objAfp_a3c_record.Afp_a3c_record1.Substring(2, 1);
                objAFP_A3C_FILE.FILLER_1 = objAfp_a3c_record.Afp_a3c_record1.Substring(3, 86);
                objAFP_A3C_FILE.AFP_PAYMENT_SIGN = objAfp_a3c_record.Afp_a3c_record1.Substring(89, 1);
                objAFP_A3C_FILE.AFP_PAYMENT_AMT = Util.NumDec(objAfp_a3c_record.Afp_a3c_record1.Substring(90, 11));
                objAFP_A3C_FILE.FILLER_3 = objAfp_a3c_record.Afp_a3c_record1.Substring(101, 34);
                objAFP_A3C_FILE.RecordState = State.Added;
                objAFP_A3C_FILE.Submit();
            }
            else if (objAfp_record.Afp_record_id.Equals("A4T"))
            {
                objAfp_a4t_record = objAfp_record.Aft_Record_Reference as Afp_a4t_record;
                //  	    write afp-a4t-record;       
                AFP_A4T_FILE objAFP_A4T_FILE = null;
                objAFP_A4T_FILE = new AFP_A4T_FILE();
                objAFP_A4T_FILE.AFP_TRANSACTION_ID = objAfp_a4t_record.Afp_a4t_record1.Substring(0, 2);
                objAFP_A4T_FILE.AFP_RECORD_ID = objAfp_a4t_record.Afp_a4t_record1.Substring(2, 1);
                objAFP_A4T_FILE.FILLER_1 = objAfp_a4t_record.Afp_a4t_record1.Substring(3, 86);
                objAFP_A4T_FILE.AFP_PAYMENT_SIGN = objAfp_a4t_record.Afp_a4t_record1.Substring(89, 1);
                objAFP_A4T_FILE.AFP_PAYMENT_AMT = Util.NumDec(objAfp_a4t_record.Afp_a4t_record1.Substring(90, 11));
                objAFP_A4T_FILE.FILLER_3 = objAfp_a4t_record.Afp_a4t_record1.Substring(101, 34);
                objAFP_A4T_FILE.RecordState = State.Added;
                objAFP_A4T_FILE.Submit();
            }
            else
            {
                err_ind = 2;
                await za0_common_error();
                await za0_99_exit();
                //stop "Error at above record number ";
                Console.WriteLine("Error at above record number ");
                // 	       stop run.;
            }
        }
        private async Task ab0_10_read_next_afp()
        {
            //     perform xa0-read-afp-file             thru xa0-99-exit.;
            await xa0_read_afp_file();
            await xa0_99_exit();
        }
        private async Task ab0_99_exit()
        {
            //     exit.;
        }

        private async Task az0_end_of_job()
        {
            //     display blank-screen.;
            //     display " ".;
            //     display "OHIP RATS READ          "   ctr-afp-file-reads.;
            //     display "OHIP RATS REC 1 READ    "       ctr-afp-rec1-reads.;
            //     display "OHIP RATS REC 2 READ    "       ctr-afp-rec2-reads.;
            //     display "OHIP RATS REC 3 READ    "       ctr-afp-rec3-reads.;
            //     display "OHIP RATS REC 4 READ    "       ctr-afp-rec4-reads.;
            //     display "OHIP RATS REC 5 READ    "       ctr-afp-rec5-reads.;
            //     display "OHIP RATS REC 6 READ    "       ctr-afp-rec6-reads.;
            //     display "OHIP RATS REC 7 READ    "       ctr-afp-rec7-reads.;
            //     display "OHIP RATS REC 8 READ    "       ctr-afp-rec8-reads.;
            //     close 	iconst-mstr;
            //           	afp-fixed-payments;
            //     		afp-a1f-file;
            // 		afp-a2g-file;
            // 		afp-a2s-file;
            // 		afp-a3c-file;
            // 		afp-a4t-file.;
            //     display " ".;
            //     display "NORMAL END OF JOB - u140 ".;
            //     stop run.;
            
            ClearScreen();
            Display("end_of_job_summary.");
            Console.WriteLine("OHIP RATS READ          " + Util.Str(ctr_afp_file_reads));
            Console.WriteLine("OHIP RATS REC 1 READ    " + Util.Str(ctr_afp_rec1_reads));
            Console.WriteLine("OHIP RATS REC 2 READ    " + Util.Str(ctr_afp_rec2_reads));
            Console.WriteLine("OHIP RATS REC 3 READ    " + Util.Str(ctr_afp_rec3_reads));
            Console.WriteLine("OHIP RATS REC 4 READ    " + Util.Str(ctr_afp_rec4_reads));
            Console.WriteLine("OHIP RATS REC 5 READ    " + Util.Str(ctr_afp_rec5_reads));
            Console.WriteLine("OHIP RATS REC 6 READ    " + Util.Str(ctr_afp_rec6_reads));
            Console.WriteLine("OHIP RATS REC 7 READ    " + Util.Str(ctr_afp_rec7_reads));
            Console.WriteLine("OHIP RATS REC 8 READ    " + Util.Str(ctr_afp_rec8_reads));

        }
        private async Task az0_99_exit()
        {
            //     exit.;
        }

        private async Task xa0_read_afp_file()
        {
            //     read afp-fixed-payments;
            //        at end;
            //       afp_eof_flag = "Y";
            //         	go to xa0-99-exit.;
            //     add 1 to ctr-afp-file-reads.;

            if (Afp_record_Collection.Count() == 0)
            {
                afp_eof_flag = "Y";
                await xa0_99_exit();
                return;
            }
            else
            {
                if (ctr_afp_file_reads >= Afp_record_Collection.Count())
                {
                    afp_eof_flag = "Y";
                    await xa0_99_exit();
                    return;
                }
                else
                {                  
                    objAfp_record = Afp_record_Collection[ctr_afp_file_reads];
                    ctr_afp_file_reads++;
                }
            }
        }
        private async Task xa0_99_exit()
        {
            //     exit.;
        }
        private async Task za0_common_error()
        {
            e1_error_msg = err_msg[err_ind];
            //     display confirm.;
            //     display e1-error-line.;
            Display("e1-error-line.");
            Console.WriteLine("***  ERROR - " + Util.Str(e1_error_msg));
        }
        private async Task za0_99_exit()
        {
            //     exit.;
        }
        private async Task zb0_abend()
        {
            //     display "u140 ABENDING";
            //     display " ".;
            EraseRowRange(23, 23);
            Display("abend.");
            Console.WriteLine("u140 ABENDING");
        }

        private async Task zb1_close_files()
        {
            //     close 	iconst-mstr;
            //           	afp-fixed-payments;
            //     		afp-a1f-file;
            // 		afp-a2g-file;
            // 		afp-a2s-file;
            // 		afp-a3c-file;
            // 		afp-a4t-file.;
            //     stop run.;
        }

        private async Task zb0_99_exit()
        {
            //     exit.;
        }

        // y2k_default_century_year.rtn
        private async Task y2k_add_century_to_year()
        {
            //     if century-year > 99;
            //     then;
            // 	next sentence;
            //     else;
            // 	if century-year = 99;
            // 	then;
            //             add 1900                to   century-year;
            // 	else;
            //             add 2000		    to	 century-year.;
            if (century_year > 99)
            {
                // next sentence
            }
            else if (century_year == 99)
            {
                century_year += 1900;
            }
            else
            {
                century_year += 2000;
            }
        }

        // y2k_default_century_year.rtn
        private async Task y2k_99_exit()
        {
            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {
            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        public async Task destroy_objects()
        {
            objAfp_record = null;            
            objAfp_a2g_record = null;            
            objAfp_a2s_record = null;            
            objAfp_a3c_record = null;            
            objAfp_a4t_record = null;            
            objAfp_record = null;            
        }

        #endregion
    }
}

