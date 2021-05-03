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
    public class u030aViewModel: CommonFunctionScr
    {          
        /*public u030aViewModel(Grid grid ):base(grid)
        {
            ScreenDataCollection = ScreenSection();
            GridAddControl();
            isBatchProcess = false;
            mainline();
        } */

        public u030aViewModel()
        {
            isBatchProcess = false;
        }

        public u030aViewModel(string ws_request_clinic_ident, //2215
                              int ws_sel_month, // 06
                              string ws_flag_tape_mth, //y
                              string ws_flag_over_mth, // y
                              string ws_confirm_reply)
        {
            isBatchProcess = true;
            mainline(ws_request_clinic_ident, ws_sel_month, ws_flag_tape_mth, ws_flag_over_mth, ws_confirm_reply);
        }


        #region FD Section
        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_1 objRat_record_1 = null;
        private ObservableCollection<Rat_record_1> Rat_record_1_Collection;

        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_2_3 objRat_record_2_3 = null;
        private ObservableCollection<Rat_record_2_3> Rat_record_2_3_Collection;

        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_4 objRat_record_4 = null;
        private ObservableCollection<Rat_record_4> Rat_record_4_Collection;

        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_5 objRat_record_5 = null;
        private ObservableCollection<Rat_record_5> Rat_record_5_Collection;

        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_6 objRat_record_6 = null;
        private ObservableCollection<Rat_record_6> Rat_record_6_Collection;

        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_7 objRat_record_7 = null;
        private ObservableCollection<Rat_record_7> Rat_record_7_Collection;

        // FD: ohip_rat_tape	Copy : u030_ohip_rat_tape.fd
        private Rat_record_8 objRat_record_8 = null;
        private ObservableCollection<Rat_record_8> Rat_record_8_Collection;

        // FD: tape_145_file	Copy : u030_tape_145_file.fd
        private Tape_145_record objTape_145_record = null;
        private ObservableCollection<Tape_145_record> Tape_145_record_Collection;

        // FD: tape_rmb_file	Copy : u030_tape_rmb_file.fd
        private Tape_rmb_record objTape_rmb_record = null;
        private ObservableCollection<Tape_rmb_record> Tape_rmb_record_Collection;

        // FD: tape_67_file	Copy : u030_tape_67_file.fd
        private Tape_67_record objTape_67_record = null;
        private ObservableCollection<Tape_67_record> Tape_67_record_Collection;

        // FD: tape_8_file	Copy : u030_tape_8_file.fd
        private Tape_8_record objTape_8_record = null;
        private ObservableCollection<Tape_8_record> Tape_8_record_Collection;
        
        // FD: iconst_mstr	Copy : f090_const_mstr_rec_1.ws
        private CONSTANTS_MSTR_REC_1 objConstants_mstr_rec_1 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_1> Constants_mstr_rec_1_Collection;

        private U030_TAPE_8_FILE objU030_TAPE_8_FILE = null;
        private U030_TAPE_67_FILE objU030_TAPE_67_FILE = null;
        private U030_TAPE_RMB_FILE objU030_TAPE_RMB_FILE = null;
        private U030_TAPE_145_FILE objU030_TAPE_145_FILE = null;

       

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        //private string last_claim_nbr;
        //private int ws_sel_month;
        //private string ws_flag_tape_mth;
        //private string ws_flag_over_mth;
        //private int ws_scr_day;
        //private int ws_scr_year;
        //private string ws_scr_month;
        //private decimal ws_doll_amt;
        //private string ws_request_clinic_ident; // change to properties
        //private string ws_reply;
        //private string ws_confirm_reply;
        private decimal ws_rat_67_amt_bill;
        private decimal ws_rat_67_amt_paid;
        private string status_file;
        private string status_iconst_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string feedback_iconst_mstr;
        private int i;
        private string group_nbr_flag;
        private string group_nbr_found = "Y";
        private string group_nbr_not_found = "N";

        private string rat_eof_flag;
        private string rat_eof = "Y";
        private string hcp_rmb_flag;
        private string rmb_claims = "Y";
        private string hcp_claims = "N";

        private string ws_rat_1_group_nbr_grp;
        private int ws_rat_clinic_nbr;
        private string filler;
        private int ws_clinic_nbr;
        private string ws_rat_1_moh_off_cd;
        private int ws_rat_1_data_seq_nbr;
        private int ws_rat_1_payment_date;
        private string ws_rat_1_last_name;
        private string ws_rat_1_title;
        private string ws_rat_1_initials;
        private decimal ws_rat_1_tot_amt_pay;
        private string ws_rat_1_cheq_nbr;

        private string counters_grp;
        /*private int ctr_rat_tape_reads;
        private int ctr_rat_rec1_reads;
        private int ctr_rat_rec2_reads;
        private int ctr_rat_rec3_reads;
        private int ctr_rat_rec4_reads;
        private int ctr_rat_rec5_reads;
        private int ctr_rat_rec6_reads;
        private int ctr_rat_rec7_reads;
        private int ctr_rat_rec8_reads;
        private int hcp_records;
        private int rmb_records; */

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "NO RAT TAPE HEADER - RECORD #1 ";
        private string filler = "RAT TAPE RECORD #5 DOES NOT BELONG IN SERIES";
        private string filler = "INVALID GROUP IDENTIFIER";
        private string filler = "RAT TAPE MONTH MUST BE NUMERIC ONLY";
        private string filler = "GROUP IDENTIFICATION MUST BE NUMERIC";
        private string filler = "invalid reply";
        private string filler = "CONSTANT MSTR RECORD 1 DOES NOT EXIST"; */
        private string error_messages_r_grp;
        private string[] err_msg = {"", "NO RAT TAPE HEADER - RECORD #1 ", "RAT TAPE RECORD #5 DOES NOT BELONG IN SERIES", "INVALID GROUP IDENTIFIER", "RAT TAPE MONTH MUST BE NUMERIC ONLY",
                                         "GROUP IDENTIFICATION MUST BE NUMERIC","invalid reply","CONSTANT MSTR RECORD 1 DOES NOT EXIST"};
        private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        //private string e1_error_msg;
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

        private object objU030_OHIP_RAT_TAPE;
        private ObservableCollection<Rat_record_1> U030_OHIP_RAT_TAPE_Collection;

        private IEnumerator<object> U030_OHIP_RAT_TAPE_Enumerator;
        private bool FTF = true;
        private int debug_ctr;
        private bool clinicInvalid = false;
        

        private string prm_ws_request_clinic_ident;
        private int prm_ws_sel_month;
        private string prm_ws_flag_tape_mth;
        private string prm_ws_flag_over_mth;
        private string prm_ws_confirm_reply;

        private ObservableCollection<U030_TAPE_145_FILE> U030_TAPE_145_FILE_Collection;
        private ObservableCollection<U030_TAPE_RMB_FILE> U030_TAPE_RMB_FILE_Collection;
        private ObservableCollection<U030_TAPE_67_FILE> U030_TAPE_67_FILE_Collection;
        private ObservableCollection<U030_TAPE_8_FILE> U030_TAPE_8_FILE_Collection;

        private StringBuilder str = null;        

        //Testing
        private int xc1_write_145_record_ctr;
        private int xc2_write_rmb_record_ctr;
        private int xc3_write_67_record_ctr;
        private int xc4_write_8_record_ctr;

        #endregion

        #region Screen Section
        public  ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
                {
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "U030A",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 20,Data1 = "RAT TAPE APPLICATION",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)", MaxLength=4,  RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength= 2, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength=2, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "06",Col = 20,Data1 = "ENTER CLINIC IDENT",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "06",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength=4, RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_request_clinic_ident",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "08",Col = 10,Data1 = "CONTINUE?  (ENTER Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-continue.",Line = "12",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength=1, RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "ws_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "21",Col = 20,Data1 = "PROGRAM U030 IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -   ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)", MaxLength=60, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-month-id.",Line = "10",Col = 20,Data1 = "ENTER RAT TAPE MONTH",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-month-id.",Line = "10",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx", MaxLength=2, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_sel_month",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-search-rec-type-1.",Line = "12",Col = 20,Data1 = "NOW SEARCHING FOR RAT TAPE RECORD TYPE 1",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 20,Data1 = "DATE OF TAPE IS",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99", MaxLength=2, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_scr_day",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 39,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(9)", MaxLength=9, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_scr_month",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "14",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength=4, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_scr_year",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "15",Col = 20,Data1 = "RAT TAPE CLINIC AMOUNT $",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-date-and-dol-amount.",Line = "15",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z,zzz,zz9.99", MaxLength=10, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_doll_amt",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-accept-mth.",Line = "17",Col = 20,Data1 = "ACCEPT THIS TAPE MONTH (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-accept-mth.",Line = "17",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x", MaxLength=1, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_flag_tape_mth",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "19",Col = 20,Data1 = "MONTH ENTERED AND MONTH FOUND ON TAPE DON'T MATCH",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "20",Col = 20,Data1 = "DO YOU STILL WANT TO CONTINUE (Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-override-mth.",Line = "20",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x", MaxLength=1, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_flag_over_mth",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "22",Col = 20,Data1 = "* WARNING * YOU HAVE ENTERED 'N' ! RE-ENTER TO CONFIRM",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "23",Col = 20,Data1 = "DO YOU STILL WANT TO CONTINUE (Y OR N)",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm-neg-response.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x", MaxLength=1, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_confirm_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ring-bell.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 // Added 
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "2",Col = 1,Data1 = "OHIP RATS READ          ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "3",Col = 1,Data1 = "OHIP RATS REC 1 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "4",Col = 1,Data1 = "OHIP RATS REC 2 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "5",Col = 1,Data1 = "OHIP RATS REC 3 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "6",Col = 1,Data1 = "OHIP RATS REC 4 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "7",Col = 1,Data1 = "OHIP RATS REC 5 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "8",Col = 1,Data1 = "OHIP RATS REC 6 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "9",Col = 1,Data1 = "OHIP RATS REC 7 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "10",Col = 1,Data1 = "OHIP RATS REC 8 READ    ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "11",Col = 1,Data1 = "HCP HEADER REC READ     ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "12",Col = 1,Data1 = "RMB HEADER REC READ     ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "2",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)", MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_tape_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "3",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec1_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "4",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec2_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "5",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec3_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "6",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec4_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "7",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec5_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "8",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec6_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "9",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec7_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "10",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_rat_rec8_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "11",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "hcp_records",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "12",Col = 25,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(9)",MaxLength=9, RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "rmb_records",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end_of_job_summary.",Line = "15",Col = 1,Data1 = "NORMAL END OF JOB - U030 ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "common_error.",Line = "23",Col = 1,Data1 = "***  ERROR - ",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "common_error.",Line = "23",Col = 15,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(119)", MaxLength=119, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "e1_error_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "abend.",Line = "23",Col = 1,Data1 = "U030 ABENDING",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 // ...
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ab0_processing.",Line = "20",Col = 1,Data1 = "RAT 5 CLAIM NBR=",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ab0_processing.",Line = "21",Col = 1,Data1 = "LAST CLAIM NBR =",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ab0_processing.",Line = "22",Col = 1,Data1 = "HIT NEW-LINE TO CONTINUE",RowStatus = rowStatus.Display,NumericFormat = "",RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ab0_processing.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(20)", MaxLength=20, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "rat_5_claim_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
                 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "ab0_processing.",Line = "21",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(20)", MaxLength=20, RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "last_claim_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

                };
            return ScreenDataCollection;
        }

        #endregion

        #region Properties

        private string _ws_request_clinic_ident;
        public string  ws_request_clinic_ident
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

        public string _ws_reply;
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
                    _ws_confirm_reply = _ws_confirm_reply.ToUpper();
                    RaisePropertyChanged("ws_confirm_reply");
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
                if(_ws_scr_day != value)
                {
                    _ws_scr_day = value;
                    RaisePropertyChanged("ws_scr_day");
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

        private decimal _ws_doll_amt;
        public decimal ws_doll_amt
        {
            get
            {
                return _ws_doll_amt;
            }
            set
            {
                if ( _ws_doll_amt != value)
                {
                    _ws_doll_amt = value;
                    RaisePropertyChanged("ws_doll_amt");
                }
            }
        }

        private string  _ws_flag_tape_mth;
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

        // *
        private string _rat_5_claim_nbr;
        public string rat_5_claim_nbr
        {
            get
            {
                return _rat_5_claim_nbr;
            }
            set
            {
                if (_rat_5_claim_nbr != value)
                {
                    _rat_5_claim_nbr = value;
                    _rat_5_claim_nbr = _rat_5_claim_nbr.ToUpper();
                    RaisePropertyChanged("rat_5_claim_nbr");
                }
            }
        }

        private string _last_claim_nbr;
        public string last_claim_nbr
        {
           get
            {
                return _last_claim_nbr;
            }
            set
            {
                if (_last_claim_nbr != value)
                {
                    _last_claim_nbr = value;
                    _last_claim_nbr = _last_claim_nbr.ToUpper();
                    RaisePropertyChanged("last_claim_nbr");
                }
            }
        }

        #endregion
       
        #region Procedure Divsion
        public async  void mainline(string ws_request_clinic_ident = "", //2215
                              int ws_sel_month = 0, // 06
                              string ws_flag_tape_mth = "", //y
                              string ws_flag_over_mth = "", // y
                              string ws_confirm_reply = "")  //y
        {            
            prm_ws_request_clinic_ident = ws_request_clinic_ident;
            prm_ws_sel_month = ws_sel_month;
            prm_ws_flag_tape_mth = ws_flag_tape_mth;
            prm_ws_flag_over_mth = ws_flag_over_mth;
            prm_ws_confirm_reply = ws_confirm_reply;


            objRat_record_1 = null;
            objRat_record_1 = new Rat_record_1();
            Rat_record_1_Collection = new ObservableCollection<Rat_record_1>();

            objRat_record_2_3 = null;
            objRat_record_2_3 = new Rat_record_2_3();
            Rat_record_2_3_Collection = new ObservableCollection<Rat_record_2_3>();

            objRat_record_4 = null;
            objRat_record_4 = new Rat_record_4();
            Rat_record_4_Collection = new ObservableCollection<Rat_record_4>();

            objRat_record_5 = null;
            objRat_record_5 = new Rat_record_5();
            Rat_record_5_Collection = new ObservableCollection<Rat_record_5>();

            objRat_record_6 = null;
            objRat_record_6 = new Rat_record_6();
            Rat_record_6_Collection = new ObservableCollection<Rat_record_6>();

            objRat_record_7 = null;
            objRat_record_7 = new Rat_record_7();
            Rat_record_7_Collection = new ObservableCollection<Rat_record_7>();

            objRat_record_8 = null;
            objRat_record_8 = new Rat_record_8();
            Rat_record_8_Collection = new ObservableCollection<Rat_record_8>();

            objTape_145_record = null;
            objTape_145_record = new Tape_145_record();
            Tape_145_record_Collection = new ObservableCollection<Tape_145_record>();

            objTape_rmb_record = null;
            objTape_rmb_record = new Tape_rmb_record();
            Tape_rmb_record_Collection = new ObservableCollection<Tape_rmb_record>();

            objTape_67_record = null;
            objTape_67_record = new Tape_67_record();
            Tape_67_record_Collection = new ObservableCollection<Tape_67_record>();

            objTape_8_record = null;
            objTape_8_record = new Tape_8_record();
            Tape_8_record_Collection = new ObservableCollection<Tape_8_record>();
           
            objConstants_mstr_rec_1 = null;
            objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1();
            Constants_mstr_rec_1_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_1>();

            objU030_OHIP_RAT_TAPE = new object();
            U030_OHIP_RAT_TAPE_Collection = base.Read_U030_OHIP_RAT_TAPE_SequentialFile();
                                             
            U030_TAPE_145_FILE_Collection = new ObservableCollection<U030_TAPE_145_FILE>();
            U030_TAPE_RMB_FILE_Collection = new ObservableCollection<U030_TAPE_RMB_FILE>();
            U030_TAPE_67_FILE_Collection = new ObservableCollection<U030_TAPE_67_FILE>();
            U030_TAPE_8_FILE_Collection = new ObservableCollection<U030_TAPE_8_FILE>();
            str = new StringBuilder();

            //     perform aa0-initialization              thru aa0-99-exit.;
            await aa0_initialization();            
            await aa0_10_accept_clinic();
            if (isBatchProcess && clinicInvalid) return;
            await aa0_15_accept_month();
            await aa0_20_continue_reading();
            await aa0_99_exit();

            //     perform ab0-processing             thru ab0-99-exit;
            //        until rat-eof.;
            ws_rat_1_tot_amt_pay = 0;
            while (!Util.Str(rat_eof_flag).ToUpper().Equals("Y"))
            {
                await ab0_processing();
                await ab0_10_read_next_rat();
                await ab0_99_exit();
            }
           
            /*U030_TAPE_8_FILE objU030_TAPE_8_FILE = null;
            objU030_TAPE_8_FILE = new U030_TAPE_8_FILE();
            objU030_TAPE_8_FILE.BulkInsert(U030_TAPE_8_FILE_Collection); */

            WriteFile objU030_TAPE_8_FILE_TextFile = null;
            objU030_TAPE_8_FILE_TextFile = new WriteFile(Directory.GetCurrentDirectory() + "\\" + "U030_TAPE_8_FILE.dat", false);
            str.Clear();

            foreach (var obj in U030_TAPE_8_FILE_Collection)
            {
                str.Append( Util.Str(obj.RAT_8_MESSAGE_TEXT).PadRight(70));
            }

            objU030_TAPE_8_FILE_TextFile.AppendOutputFile(str.ToString().Replace(Environment.NewLine,""),false);
            objU030_TAPE_8_FILE_TextFile.CloseOutputFile();
           
            WriteFile objU030_TAPE_67_FILE_TextFile = null;
            objU030_TAPE_67_FILE_TextFile = new WriteFile(Directory.GetCurrentDirectory() + "\\" + "U030_TAPE_67_FILE.dat", false);
            str.Clear();
            
            foreach(var obj in U030_TAPE_67_FILE_Collection)
            {
                str.Append(  Util.ConvertZone(Util.NumInt(obj.RAT_67_AMT_CLAIMS_ADJ), 10) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_AMT_ADVANCES), 10) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_AMT_REDUCTIONS), 10) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_AMT_DEDUCTIONS), 10) +
                             Util.Str(obj.RAT_67_TRANS_CD).PadRight(2) +
                             Util.Str(obj.RAT_67_CHEQUE_IND).PadRight(1) +
                             Util.Str(obj.RAT_67_TRANS_DATE).PadLeft(8, '0') +                            
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_TRANS_AMT), 9) + 
                             Util.Str(obj.RAT_67_TRANS_MESSAGE).PadRight(50) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_TOTAL_CLINIC_AMT), 10) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_AMT_BILL), 10) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_67_AMT_PAID), 10));
            }

            objU030_TAPE_67_FILE_TextFile.AppendOutputFile(str.ToString().Replace(Environment.NewLine,""),false);
            objU030_TAPE_67_FILE_TextFile.CloseOutputFile();
           
            WriteFile objU030_TAPE_RMB_FILE_TextFile = null;
            objU030_TAPE_RMB_FILE_TextFile = new WriteFile(Directory.GetCurrentDirectory() + "\\" + "U030_TAPE_RMB_FILE.dat",false);
            str.Clear();

            foreach (var obj in U030_TAPE_RMB_FILE_Collection)
            {
                  str.Append(Util.Str(obj.RAT_RMB_GROUP_NBR).PadRight(4) +
                             Util.Str(obj.RAT_RMB_MOH_OFF_CD).PadRight(1) +
                             Util.Str(obj.RAT_RMB_DATA_SEQ_NBR).PadLeft(1) +
                             Util.Str(obj.RAT_RMB_PAYMENT_DATE).PadLeft(8) +
                             Util.Str(obj.RAT_RMB_PAY_LAST_NAME).PadRight(25) +
                             Util.Str(obj.RAT_RMB_PAY_TITLE).PadRight(3) +
                             Util.Str(obj.RAT_RMB_PAY_INITIALS).PadRight(2) +
                             Util.ConvertZone(Util.NumInt(obj.RAT_RMB_TOT_AMT_PAY), 10) +
                             Util.Str(obj.RAT_RMB_CHEQ_NBR).PadRight(8) +
                             Util.Str(obj.RAT_RMB_CLAIM_NBR).PadRight(11) +
                             Util.Str(obj.RAT_RMB_TRANS_TYPE).PadLeft(1, '0') +
                             Util.Str(obj.RAT_RMB_DOC_NBR).PadLeft(6, '0') +
                             Util.Str(obj.RAT_RMB_SPECIALTY_CD).PadLeft(2,'0') +
                             Util.Str(obj.RAT_RMB_ACCOUNT_NBR).PadRight(8) +
                             Util.Str(obj.RAT_RMB_LAST_NAME).PadRight(14) +
                             Util.Str(obj.RAT_RMB_FIRST_NAME).PadRight(5) +
                             Util.Str(obj.RAT_RMB_PROV_CD).PadRight(2) +
                             Util.Str(obj.RAT_RMB_HEALTH_OHIP_NBR).PadRight(12) +
                             Util.Str(obj.RAT_RMB_VERSION_CD).PadRight(2) +
                             Util.Str(obj.RAT_RMB_PAY_PROG).PadRight(3) +
                             Util.Str(obj.RAT_RMB_CONV_HEALTH_NBR).PadRight(10) +
                             Util.Str(obj.RAT_RMB_SERVICE_DATE).PadLeft(8, '0') +
                             Util.Str(obj.RAT_RMB_NBR_OF_SERV).PadLeft(2, '0') +
                             Util.Str(obj.RAT_RMB_SERVICE_CD).PadRight(5) +
                             Util.Str(obj.RAT_RMB_ELIGIBILITY_IND).PadRight(1) +
                             Util.Str(obj.RAT_RMB_AMOUNT_SUB).PadLeft(6, '0') +
                             Util.ConvertZone(Util.NumInt(obj.RAT_RMB_AMT_PAID), 7) +
                             Util.Str(obj.RAT_RMB_EXPLAN_CD).PadRight(2));
            }
            objU030_TAPE_RMB_FILE_TextFile.AppendOutputFile(str.ToString().Replace(Environment.NewLine,""),false);
            objU030_TAPE_RMB_FILE_TextFile.CloseOutputFile();
            
            WriteFile objU030_TAPE_145_FILE_TextFile = null;
            objU030_TAPE_145_FILE_TextFile = new WriteFile(Directory.GetCurrentDirectory() + "\\" + "U030_TAPE_145_FILE.dat",false);
            str.Clear();
           
            foreach (var obj in U030_TAPE_145_FILE_Collection)
            {
                str.Append (Util.Str(obj.RAT_145_GROUP_NBR).PadRight(4) +
                            Util.Str(obj.RAT_145_MOH_OFF_CD).PadRight(1) +
                            Util.Str(obj.RAT_145_DATA_SEQ_NBR).PadLeft(1, '0') +
                            Util.Str(obj.RAT_145_PAYMENT_DATE).PadLeft(8, '0') +
                            Util.Str(obj.RAT_145_PAY_LAST_NAME).PadRight(25) +
                            Util.Str(obj.RAT_145_PAY_TITLE).PadRight(3) +
                            Util.Str(obj.RAT_145_PAY_INITIALS).PadRight(2) +
                            Util.ConvertZone(Util.NumInt(obj.RAT_145_TOT_AMT_PAY), 10) +
                            Util.Str(obj.RAT_145_CHEQ_NBR).PadRight(8) +
                            Util.Str(obj.RAT_145_CLAIM_NBR).PadRight(11) +
                            Util.Str(obj.RAT_145_TRANS_TYPE).PadLeft(1, '0') +
                            Util.Str(obj.RAT_145_DOC_NBR).PadLeft(6, '0') +
                            Util.Str(obj.RAT_145_SPECIALTY_CD).PadLeft(2,'0') +
                            Util.Str(obj.RAT_145_ACCOUNT_NBR).PadRight(8) +
                            Util.Str(obj.RAT_145_LAST_NAME).PadRight(14) +
                            Util.Str(obj.RAT_145_FIRST_NAME).PadRight(5) +
                            Util.Str(obj.RAT_145_PROV_CD).PadRight(2) +
                            Util.Str(obj.RAT_145_HEALTH_OHIP_NBR).PadRight(12) +
                            Util.Str(obj.RAT_145_VERSION_CD).PadRight(2) +
                            Util.Str(obj.RAT_145_PAY_PROG).PadRight(3) +
                            Util.Str(obj.RAT_145_CONV_HEALTH_NBR).PadRight(10) +
                            Util.Str(obj.RAT_145_SERVICE_DATE).PadLeft(8, '0') +
                            Util.Str(obj.RAT_145_NBR_OF_SERV).PadLeft(2, '0') +
                            Util.Str(obj.RAT_145_SERVICE_CD).PadRight(5) +
                            Util.Str(obj.RAT_145_ELIGIBILITY_IND).PadRight(1) +
                            Util.Str(obj.RAT_145_AMOUNT_SUB).PadLeft(6, '0') +
                            Util.ConvertZone(Util.NumInt(obj.RAT_145_AMT_PAID), 7,true) +
                            Util.Str(obj.RAT_145_EXPLAN_CD).PadRight(2));                               
            }

            objU030_TAPE_145_FILE_TextFile.AppendOutputFile(str.ToString().Replace(Environment.NewLine,""),false);
            objU030_TAPE_145_FILE_TextFile.CloseOutputFile();

            // perform az0-end-of-job              thru az0-99-exit.;
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

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;

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

            rat_eof_flag = "N";
            hcp_rmb_flag = "N";
            group_nbr_flag = "N";
            //     open input iconst-mstr.;
            // objCONSTANTS_MSTR_REC_1.iconst_clinic_nbr_1_2 = 01;
            //     read iconst-mstr;
            //    invalid key;
            //      err_ind = 7;
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
            Console.WriteLine("U030A" + new string(' ',16) + "RAT TAPE APPLICATION" + new string(' ', 28) +  Util.Str(sys_yy) + "/" + Util.Str(sys_mm) + "/" + Util.Str(sys_dd));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("ENTER CLINIC IDENT  " + prm_ws_request_clinic_ident);
           
        }

        private async Task aa0_10_accept_clinic()
        {           
            //     accept ws-request-clinic-ident.;          
            ws_request_clinic_ident = prm_ws_request_clinic_ident;
            await Prompt("ws_request_clinic_ident", isBatchProcess);  
            
            //     display scr-clinic-nbr.;
            
            //       perform aa3-verify-group-nbr    thru aa3-99-exit;
            //         varying i from 1 by 1;
            //    until   group-nbr-found or i > 63.;

            i = 1;
            while (group_nbr_flag.ToUpper().Equals("N") && i <= 63)
            {
                await aa3_verify_group_nbr();
                await aa3_99_exit();
                i++;
            }

            //       if group-nbr-not-found;
            //   then;
            //         err_ind = 3;
            //           perform za0-common-error    thru za0-99-exit;
            //             go to aa0-10-accept-clinic.;
            //     display scr-month-id.;

            if (group_nbr_flag.ToUpper().Equals("N"))
            {
                err_ind = 3;
                await za0_common_error();
                await za0_99_exit();
                if (!isBatchProcess)
                {
                    await aa0_10_accept_clinic();
                }
                else
                {
                    clinicInvalid = true;
                }
                return;
            }           
        }

        private  async Task aa0_15_accept_month()
        {           
            //     accept ws-sel-month.;
            ws_sel_month = prm_ws_sel_month;

            //     display scr-month-id.;
            Display("scr-month-id.");

            Console.WriteLine("ENTER RAT TAPE MONTH " + Util.Str(ws_sel_month).PadLeft(2,'0'));

            //    if ws-sel-month  is not numeric;
            //     then;
            //err_ind = 4;
            //         perform za0-common-error             thru za0-99-exit;
            //ws_sel_month = 0;
            //err_ind = 0;
            //       go to aa0-15-accept-month.;

            if (!Util.IsNumeric(Util.Str(ws_sel_month)))
            {
                err_ind = 4;
                await za0_common_error();
                await za0_99_exit();
                ws_sel_month = 0;
                err_ind = 0;
                await aa0_15_accept_month();
                return;
            }

            //     display scr-search-rec-type-1.;
            Display("scr-search-rec-type-1.");
            Console.WriteLine("NOW SEARCHING FOR RAT TAPE RECORD TYPE 1");

            //     open input     ohip-rat-tape.;   // todo..  Read the text file and populate the collection.
            //     open output tape-rmb-file;
            //           tape-8-file;
            //              tape-145-file;
            //            tape-67-file.;           
        }

        private  async Task aa0_20_continue_reading()
        {           
            //     perform xa0-read-rat-tape              thru xa0-99-exit;
            //         until rat-1-record-type = "1";
            //       or rat-eof.;

            do
            {
                await xa0_read_rat_tape();
                await xa0_99_exit();
            } while (objRat_record_1.Rat_1_record_type != "1" && !rat_eof_flag.ToUpper().Equals("Y"));

                //     if not rat-eof then;                  
                //         if ws-request-clinic-ident = rat-1-group-nbr then; 
                //         
                //             if rat-1-record-type = "1" then;             
                //                 add 1                           to ctr-rat-rec1-reads;
                //                 perform aa1-record-1-process       thru    aa1-99-exit;
                //                 perform aa2-certify-month       thru    aa2-99-exit;
                //             else;
                //                 go to aa0-20-continue-reading;
                //         else;
                //             perform xa0-read-rat-tape           thru    xa0-99-exit;
                //             go to aa0-20-continue-reading;
                //     else;
                //        err_ind = 1;
                //        erform za0-common-error                thru    za0-99-exit;
                //        perform zb0-abend                       thru    zb0-99-exit.;
                //        perform xa0-read-rat-tape                      thru    xa0-99-exit.;


            if (!rat_eof_flag.ToUpper().Equals("Y"))
            {
                if (ws_request_clinic_ident == objRat_record_1.Rat_1_group_nbr)
                {
                    if (objRat_record_1.Rat_1_record_type == "1")
                    {
                        ctr_rat_rec1_reads++;
                        await aa1_record_1_process();
                        await aa1_99_exit();
                        await aa2_certify_month();
                        await aa2_99_exit();
                    }
                    else
                    {
                        await aa0_20_continue_reading();
                        return;
                    }
                }
                else
                {
                    await xa0_read_rat_tape();
                    await xa0_99_exit();
                    if (rat_eof_flag != "Y")
                    {
                        await aa0_20_continue_reading();
                    }
                    return;
                }
            }
            else
            {
                err_ind = 1;
                await za0_common_error();
                await za0_99_exit();
                await zb0_abend();
                await zb0_99_exit();
                await xa0_read_rat_tape();
                await xa0_99_exit();
            }
        }

        private async Task aa0_99_exit()
        {
            //     exit.;
        }

        private async Task aa1_record_1_process()
        {           
            ws_rat_1_group_nbr_grp = "0000";
            ws_rat_clinic_nbr = 0;

            ws_rat_clinic_nbr = ws_clinic_nbr;
            ws_rat_1_group_nbr_grp = ws_rat_clinic_nbr + "00";
            ws_rat_1_moh_off_cd = objRat_record_1.Rat_1_moh_off_cd;
            ws_rat_1_data_seq_nbr = objRat_record_1.Rat_1_data_seq_nbr;
            ws_rat_1_payment_date = Util.NumInt(objRat_record_1.Rat_1_payment_date);
            ws_rat_1_last_name = objRat_record_1.Rat_1_last_name;
            ws_rat_1_title = objRat_record_1.Rat_1_title;
            ws_rat_1_initials = objRat_record_1.Rat_1_initials;
            ws_rat_1_cheq_nbr = objRat_record_1.Rat_1_cheq_nbr;

            //     if   rat-1-tot-amt-pay-sign = ' ' then;            
            //       add  rat-1-tot-amt-pay  to ws-rat-1-tot-amt-pay;
            //     else;
            //        compute ws-rat-1-tot-amt-pay = ws-rat-1-tot-amt-pay;
            //              + (rat-1-tot-amt-pay * -1).;

            if (string.IsNullOrWhiteSpace(objRat_record_1.Rat_1_tot_amt_pay_sign))
            {
                ws_rat_1_tot_amt_pay = ws_rat_1_tot_amt_pay + objRat_record_1.Rat_1_tot_amt_pay;
            }
            else
            {
                ws_rat_1_tot_amt_pay = ws_rat_1_tot_amt_pay + (objRat_record_1.Rat_1_tot_amt_pay * -1);
            }
        }

        private async Task aa1_99_exit()
        {
            //     exit.;
        }

        private async Task aa2_certify_month()
        {           
            ws_scr_day = objRat_record_1.Rat_1_payment_date_dd;
            ws_scr_year = objRat_record_1.Rat_1_payment_date_yy;
            ws_scr_month = mth_desc[objRat_record_1.Rat_1_payment_date_mm];
            ws_doll_amt = ws_rat_1_tot_amt_pay;

            //     display scr-date-and-dol-amount.;
            //Console.WriteLine("DATE OF TAPE IS " + Util.Str(ws_scr_day) + " " + Util.Str(ws_scr_month) + " " + Util.Str(ws_scr_year));
            //Console.WriteLine("RAT TAPE CLINIC AMOUNT $" + " " + string.Format("{0:#,0.00}", ws_doll_amt));
            Display("scr-date-and-dol-amount.");

            Console.WriteLine("DATE OF TAPE IS " + Util.Str( ws_scr_day) + " " + Util.Str(ws_scr_month) + " " + Util.Str(ws_scr_year));
            Console.WriteLine("RAT TAPE CLINIC AMOUNT $ "  +  string.Format("{0:#,0.00}",  Util.ImpliedDecimal(Util.Str(ws_doll_amt),2 )));

            await Prompt("ws_scr_day", isBatchProcess);
            await Prompt("ws_scr_month", isBatchProcess);
            await Prompt("ws_scr_year", isBatchProcess);
            await Prompt("ws_doll_amt", isBatchProcess);
                        
            //     display scr-accept-mth.;            
            //     accept  ws-flag-tape-mth.;
            //     display  scr-tape-mth.;
            ws_flag_tape_mth = prm_ws_flag_tape_mth;            
            Display("scr-accept-mth." );
            Console.WriteLine("ACCEPT THIS TAPE MONTH (Y/N)" + " " + Util.Str(ws_flag_tape_mth));

            await Prompt("ws_flag_tape_mth", isBatchProcess);

            //     if ws-sel-month  not = rat-1-payment-date-mm then;             
            //         if ws-flag-tape-mth = "Y" then;             
            //             next sentence;
            //        else;
            //          go to  zb1-close-files;
            //     else if ws-flag-tape-mth = "Y" then;            
            //         display program-in-progress;
            //         go to aa2-99-exit;
            //     else;
            //         go to  zb1-close-files.;

            if (ws_sel_month != objRat_record_1.Rat_1_payment_date_mm)
            {
                if (ws_flag_tape_mth.ToUpper().Equals("Y"))
                {
                    // next sentence
                }
                else
                {
                    await zb1_close_files();
                    return;
                }
            }
            else if (ws_flag_tape_mth.ToUpper().Equals("Y"))
            {                
                Display("program-in-progress.");
                Console.WriteLine("PROGRAM U030 IN PROGRESS");
                await aa2_99_exit();
                return;
            }
            else
            {
                await zb1_close_files();
                return;
            }

            //     display scr-override-mth.;
            //     accept ws-flag-over-mth.;
            //     display  scr-override-mth.;            
            ws_flag_over_mth = prm_ws_flag_over_mth;           
            Display("scr-override-mth.");
            Console.WriteLine("MONTH ENTERED AND MONTH FOUND ON TAPE DON'T MATCH");
            Console.WriteLine("DO YOU STILL WANT TO CONTINUE (Y OR N) " + Util.Str(ws_flag_over_mth));            
            await Prompt("ws_flag_over_mth", isBatchProcess);

            //     if ws-flag-over-mth  = "Y";
            //     then;
            //   display program-in-progress;
            //      go to aa2-99-exit.;

            if (ws_flag_over_mth.ToUpper().Equals("Y"))
            {                
                Display("program-in-progress.");
                Console.WriteLine("PROGRAM U030 IN PROGRESS");
                await aa2_99_exit();
                return;
            }
        }

        private async Task aa2_10_confirm_neg_response()
        {           
            //     display scr-confirm-neg-response.;
            //     accept ws-confirm-reply.;
            //     display confirm-reply.;       

            
            ws_confirm_reply = prm_ws_confirm_reply;            
            Display("scr-confirm-neg-response.");
            Console.WriteLine("* WARNING * YOU HAVE ENTERED 'N' ! RE-ENTER TO CONFIRM");
            Console.WriteLine("DO YOU STILL WANT TO CONTINUE (Y OR N)" + Util.Str(ws_confirm_reply));

            // if ws-confirm-reply =   "Y"  or "N"; then;            
            //    next sentence;
            // else;
            //     err_ind = 6;
            //  perform za0-common-error        thru    za0-99-exit;
            //      go to aa2-10-confirm-neg-response.;

            if (ws_confirm_reply.ToUpper().Equals("Y") || ws_confirm_reply.ToUpper().Equals("N"))
            {
                // next sentence
            }
            else
            {
                err_ind = 6;
                await za0_common_error();
                await za0_99_exit();
                await  aa2_10_confirm_neg_response();
                return;
            }

            //     if ws-confirm-reply = "Y";
            //     then;
            //         next sentence;
            //     else;
            //    go to zb1-close-files.;

            if (ws_confirm_reply.ToUpper().Equals("Y"))
            {
                // next sentence
            }
            else
            {
                await zb1_close_files();
                return;
            }
        }

        private async Task aa2_99_exit()
        {
            //     exit.;
        }

        private async Task aa3_verify_group_nbr()
        {
            //     if ws-request-clinic-ident = const-clinic-nbr(i);  // TODO...
            //     then;
            //        ws_clinic_nbr = const_clinic_nbr_1_2[i];
            //        move 'Y'                to group-nbr-flag. 

            ICONST_MSTR_REC objICONST_MSTR_REC = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr = ws_request_clinic_ident
            }.Collection().FirstOrDefault();

            if (objICONST_MSTR_REC != null)
            {
                if (ws_request_clinic_ident == objICONST_MSTR_REC.ICONST_CLINIC_NBR)
                {
                    ws_clinic_nbr = Util.NumInt(objICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2);  
                    group_nbr_flag = "Y";
                }
            }
        }

        private async Task aa3_99_exit()
        {
            //     exit.;
        }

        private async Task ab0_processing()
        {           
            //     if rat-1-record-type = "1" then;            
            //       if ws-request-clinic-ident not = rat-1-group-nbr then;            
            //            rat_eof_flag = "Y";
            //            go to ab0-99-exit.;

            if (objRat_record_1.Rat_1_record_type.Equals("1"))
            {
                if (ws_request_clinic_ident != objRat_record_1.Rat_1_group_nbr)
                {
                    rat_eof_flag = "Y";
                    await ab0_99_exit();
                    return;
                }
            }

            //     perform xa1-create-tape-files thru xa1-99-exit.;
            await xa1_create_tape_files();
            await xa1_99_exit();


            //     if rat-1-record-type = "4" then;            
            //          last_claim_nbr = objRat_record_4.Rat_4_claim_nbr;

            if (objRat_record_1.Rat_1_record_type.Equals("4"))
            {
                objRat_record_4 = objRat_record_1.RatRecord_Reference as Rat_record_4;
                last_claim_nbr = objRat_record_4.Rat_4_claim_nbr;
            }

            //     if rat-1-record-type = "5" then;            
            //        if rat-5-claim-nbr = last-claim-nbr then;            
            //            next sentence;
            //        else;
            //            err_ind = 2;
            //            perform za0-common-error    thru za0-99-exit;
            //            display "RAT 5 CLAIM NBR=", rat-5-claim-nbr;
            //            display "LAST CLAIM NBR =", last-claim-nbr;
            //            stop "HIT NEW-LINE TO CONTINUE";
            //            err_ind = 0;
            //            go to ab0-10-read-next-rat.;

            if (objRat_record_1.Rat_1_record_type.Equals("5"))
            {
                objRat_record_5 = objRat_record_1.RatRecord_Reference as Rat_record_5;
                if (objRat_record_5.Rat_5_claim_nbr.Equals(last_claim_nbr))
                {
                    // next sentence
                }
                else
                {
                    err_ind = 2;
                    await za0_common_error();
                    await za0_99_exit();
                    rat_5_claim_nbr = Util.Str(objRat_record_5.Rat_5_claim_nbr);
                    Display("ab0_processing.");
                    Console.WriteLine("RAT 5 CLAIM NBR=" + rat_5_claim_nbr);
                    Console.WriteLine("LAST CLAIM NBR =" + Util.Str(last_claim_nbr));
                    Console.WriteLine("HIT NEW-LINE TO CONTINUE");
                    //Console.ReadKey();
                    err_ind = 0;
                    await ab0_10_read_next_rat();
                    return;
                }
            }

            //     if rat-1-record-type = '7';
            //     then;
            //hcp_rmb_flag = "Y";

            if (objRat_record_1.Rat_1_record_type.Equals("7"))
            {
                hcp_rmb_flag = "Y";
            }
        }

        private async Task ab0_10_read_next_rat()
        {           
            //     perform xa0-read-rat-tape             thru xa0-99-exit.;
            await xa0_read_rat_tape();
            await xa0_99_exit();
        }

        private async Task ab0_99_exit()
        {
            //     exit.;
        }

        private async Task az0_end_of_job()
        {                      
            ClearScreen();
            Display("end_of_job_summary.");
            Console.WriteLine("OHIP RATS READ          "  +  Util.Str(ctr_rat_tape_reads));
            Console.WriteLine("OHIP RATS REC 1 READ    "  +  Util.Str(ctr_rat_rec1_reads));
            Console.WriteLine("OHIP RATS REC 2 READ    " + Util.Str(ctr_rat_rec2_reads));
            Console.WriteLine("OHIP RATS REC 3 READ    " + Util.Str(ctr_rat_rec3_reads));
            Console.WriteLine("OHIP RATS REC 4 READ    " + Util.Str(ctr_rat_rec4_reads));
            Console.WriteLine("OHIP RATS REC 5 READ    " + Util.Str(ctr_rat_rec5_reads));
            Console.WriteLine("OHIP RATS REC 6 READ    " + Util.Str(ctr_rat_rec6_reads));
            Console.WriteLine("OHIP RATS REC 7 READ    " + Util.Str(ctr_rat_rec7_reads));
            Console.WriteLine("OHIP RATS REC 8 READ    " + Util.Str(ctr_rat_rec8_reads));
            Console.WriteLine("HCP HEADER REC READ     " + Util.Str(hcp_records));
            Console.WriteLine("RMB HEADER REC READ     " + Util.Str(rmb_records));

            //     close iconst-mstr;
            //           ohip-rat-tape;
            //    tape-145-file;
            //    tape-rmb-file;
            //    tape-67-file;
            //     tape-8-file.;
            //     display " ".;
            Console.WriteLine( "NORMAL END OF JOB - U030 ");
            //     stop run.;            
        }

        private async Task az0_99_exit()
        {
            //     exit.;
        }

        private async Task xa0_read_rat_tape()
        {           
            //     read ohip-rat-tape;   
            //        at end;
            //rat_eof_flag = "Y";
            //         go to xa0-99-exit.;
            //     add 1 to ctr-rat-tape-reads.;

            if (U030_OHIP_RAT_TAPE_Collection.Count() == 0)
            {
                rat_eof_flag = "Y";
                await xa0_99_exit();
                return;
            }
            else
            {
                if (ctr_rat_tape_reads >= U030_OHIP_RAT_TAPE_Collection.Count())
                {
                    rat_eof_flag = "Y";
                    await xa0_99_exit();
                    return;
                }
                else
                {
                    //int tmp = (ctr_rat_tape_reads + 1) % 1000;
                    //if (tmp == 0) Console.WriteLine("Processing Record Number : " + (ctr_rat_tape_reads + 1).ToString() +  " Time : " +  DateTime.Now.ToString());
                    objRat_record_1 = U030_OHIP_RAT_TAPE_Collection[ctr_rat_tape_reads]; 
                    ctr_rat_tape_reads++;
                    
                }
            }
        }

        private async Task xa0_99_exit()
        {
            //     exit.;
        }

        private async Task xa1_create_tape_files()
        {           
            //     if rat-1-record-type = '1' then            
            //        add 1  to ctr-rat-rec1-reads;
            //        perform aa1-record-1-process.

            if (objRat_record_1.Rat_1_record_type.Equals("1"))
            {
                ctr_rat_rec1_reads++;                
                await aa1_record_1_process();
            }

            //     if rat-1-record-type = '2' then            
            //            add 1   to ctr-rat-rec2-reads
            //     else if rat-1-record-type = '3' then            
            //         add 1  to ctr-rat-rec3-reads.

            if (objRat_record_1.Rat_1_record_type.Equals("2"))
            {
                ctr_rat_rec2_reads++;
            }
            else if (objRat_record_1.Rat_1_record_type.Equals("3"))
            {
                ctr_rat_rec3_reads++;
            }

            //     if rat-1-record-type = '4' then;            
            //            add 1                                   to ctr-rat-rec4-reads;
            //             perform xb0-process-rec-4               thru xb0-99-exit;
            //     else if rat-1-record-type = '5' then;             
            //           add 1                               to ctr-rat-rec5-reads;
            //            perform xb1-process-rec-5           thru xb1-99-exit;
            //     else if rat-1-record-type = '6' then;            
            //             add 1                           to ctr-rat-rec6-reads;
            //            perform xb2-process-rec-6       thru xb2-99-exit;
            //     else if rat-1-record-type = '7' then;            
            //           add 1                       to ctr-rat-rec7-reads;
            //           perform xb3-process-rec-7   thru xb3-99-exit;
            //     else if rat-1-record-type = '8' then;            
            //          add 1                   to ctr-rat-rec8-reads;
            //          perform xb4-process-rec-8  thru xb4-99-exit.;

            if (objRat_record_1.Rat_1_record_type.Equals("4"))
            {
                ctr_rat_rec4_reads++;
                objRat_record_4 = objRat_record_1.RatRecord_Reference as Rat_record_4;
                await xb0_process_rec_4();
                await xb0_99_exit();
            }
            else if (objRat_record_1.Rat_1_record_type.Equals("5"))
            {
                ctr_rat_rec5_reads++;
                objRat_record_5 = objRat_record_1.RatRecord_Reference as Rat_record_5;
                await xb1_process_rec_5();
                await xb1_99_exit();
            }
            else if (objRat_record_1.Rat_1_record_type.Equals("6"))
            {
                ctr_rat_rec6_reads++;
                objRat_record_6 = objRat_record_1.RatRecord_Reference as Rat_record_6;
                await xb2_process_rec_6();
                await xb2_99_exit();
            }
            else if (objRat_record_1.Rat_1_record_type.Equals("7"))
            {
                ctr_rat_rec7_reads++;
                objRat_record_7 = objRat_record_1.RatRecord_Reference as Rat_record_7;
                await xb3_process_rec_7();
                await xb3_99_exit();
            }
            else if (objRat_record_1.Rat_1_record_type.Equals("8"))
            {
                ctr_rat_rec8_reads++;
                objRat_record_8 = objRat_record_1.RatRecord_Reference as Rat_record_8;
                await xb4_process_rec_8();
                await xb4_99_exit();
            }
        }
        private async Task xa1_99_exit()
        {
            //     exit.;
        }
        private async Task xb0_process_rec_4()
        {           
            //     if rat-4-prov-cd = 'ON'then            
            //         hcp_rmb_flag = "N";
            //     else;
            //         hcp_rmb_flag = "Y";

            if (objRat_record_4.Rat_4_prov_cd.Equals("ON"))
            {
                hcp_rmb_flag = "N";
            }
            else
            {
                hcp_rmb_flag = "Y";
            }

            //     if hcp-claims then        
            if (hcp_rmb_flag.Equals(hcp_claims))
            {
                hcp_records++;
                //objTape_145_record.Tape_145_record = "";
                objTape_145_record = new Tape_145_record();

                //objTape_145_record.Rat_145_group_nbr = ws_rat_1_group_nbr;
                //ws_rat_1_group_nbr_grp = ws_rat_clinic_nbr + new string(' ', 2);
                objTape_145_record.Rat_145_group_nbr = ws_rat_1_group_nbr_grp;

                objTape_145_record.Rat_145_moh_off_cd = ws_rat_1_moh_off_cd;
                objTape_145_record.Rat_145_data_seq_nbr = ws_rat_1_data_seq_nbr;
                objTape_145_record.Rat_145_payment_date = ws_rat_1_payment_date;
                objTape_145_record.Rat_145_pay_last_name = ws_rat_1_last_name;
                objTape_145_record.Rat_145_pay_title = ws_rat_1_title;
                objTape_145_record.Rat_145_pay_initials = ws_rat_1_initials;
                objTape_145_record.Rat_145_tot_amt_pay = ws_rat_1_tot_amt_pay;
                objTape_145_record.Rat_145_cheq_nbr = ws_rat_1_cheq_nbr;
                objTape_145_record.Rat_145_claim_nbr = objRat_record_4.Rat_4_claim_nbr;
                objTape_145_record.Rat_145_trans_type = objRat_record_4.Rat_4_trans_type;
                objTape_145_record.Rat_145_doc_nbr = objRat_record_4.Rat_4_doc_nbr;
                objTape_145_record.Rat_145_specialty_cd = Util.Str(objRat_record_4.Rat_4_specialty_cd);
                objTape_145_record.Rat_145_account_nbr = objRat_record_4.Rat_4_account_nbr;
                objTape_145_record.Rat_145_last_name = objRat_record_4.Rat_4_last_name;
                objTape_145_record.Rat_145_first_name = objRat_record_4.Rat_4_first_name;
                objTape_145_record.Rat_145_prov_cd = objRat_record_4.Rat_4_prov_cd;
                objTape_145_record.Rat_145_health_ohip_nbr = objRat_record_4.Rat_4_health_ohip_nbr;
                objTape_145_record.Rat_145_version_cd = objRat_record_4.Rat_4_version_cd;
                objTape_145_record.Rat_145_pay_prog = objRat_record_4.Rat_4_pay_prog;
                objTape_145_record.Rat_145_conv_health_nbr = "";
            }
            //     else if rmb-claims then     
            else if (hcp_rmb_flag.Equals(rmb_claims))
            {
                rmb_records++;
                //objTape_rmb_record.tape_rmb_record = "";
                objTape_rmb_record = new Tape_rmb_record();

                //objTape_rmb_record.Rat_rmb_group_nbr = ws_rat_1_group_nbr;
                //ws_rat_1_group_nbr_grp = ws_rat_clinic_nbr + new string(' ', 2);
                objTape_rmb_record.Rat_rmb_group_nbr = ws_rat_1_group_nbr_grp;
                objTape_rmb_record.Rat_rmb_moh_off_cd = ws_rat_1_moh_off_cd;
                objTape_rmb_record.Rat_rmb_data_seq_nbr = ws_rat_1_data_seq_nbr;
                objTape_rmb_record.Rat_rmb_payment_date = ws_rat_1_payment_date;
                objTape_rmb_record.Rat_rmb_pay_last_name = ws_rat_1_last_name;
                objTape_rmb_record.Rat_rmb_pay_title = ws_rat_1_title;
                objTape_rmb_record.Rat_rmb_pay_initials = ws_rat_1_initials;
                objTape_rmb_record.Rat_rmb_tot_amt_pay = ws_rat_1_tot_amt_pay;
                objTape_rmb_record.Rat_rmb_cheq_nbr = ws_rat_1_cheq_nbr;
                objTape_rmb_record.Rat_rmb_claim_nbr = objRat_record_4.Rat_4_claim_nbr;
                objTape_rmb_record.Rat_rmb_trans_type = objRat_record_4.Rat_4_trans_type;
                objTape_rmb_record.Rat_rmb_doc_nbr = objRat_record_4.Rat_4_doc_nbr;
                objTape_rmb_record.Rat_rmb_specialty_cd = Util.Str(objRat_record_4.Rat_4_specialty_cd);
                objTape_rmb_record.Rat_rmb_account_nbr = objRat_record_4.Rat_4_account_nbr;
                objTape_rmb_record.Rat_rmb_last_name = objRat_record_4.Rat_4_last_name;
                objTape_rmb_record.Rat_rmb_first_name = objRat_record_4.Rat_4_first_name;
                objTape_rmb_record.Rat_rmb_prov_cd = objRat_record_4.Rat_4_prov_cd;
                objTape_rmb_record.Rat_rmb_health_ohip_nbr = objRat_record_4.Rat_4_health_ohip_nbr;
                objTape_rmb_record.Rat_rmb_version_cd = objRat_record_4.Rat_4_version_cd;
                objTape_rmb_record.Rat_rmb_pay_prog = objRat_record_4.Rat_4_pay_prog;
                objTape_rmb_record.Rat_rmb_conv_health_nbr = "";
            }
        }

        private async Task xb0_99_exit()
        {
            //     exit.;
        }
        private async Task xb1_process_rec_5()
        {            
            //     if hcp-claims then
            if (hcp_rmb_flag.Equals("N"))
            {
                objTape_145_record.Rat_145_service_date = objRat_record_5.Rat_5_service_date;
                objTape_145_record.Rat_145_nbr_of_serv = objRat_record_5.Rat_5_nbr_of_serv;
                objTape_145_record.Rat_145_service_cd = objRat_record_5.Rat_5_service_cd;
                objTape_145_record.Rat_145_eligibility_ind = objRat_record_5.Rat_5_eligibility_ind;
                objTape_145_record.Rat_145_amount_sub = objRat_record_5.Rat_5_amount_sub;
                //    if   rat-5-amt-paid-sign = ' ' then
                if (string.IsNullOrWhiteSpace(objRat_record_5.Rat_5_amt_paid_sign))
                {
                    objTape_145_record.Rat_145_amt_paid = objRat_record_5.Rat_5_amt_paid;
                }
                else
                {
                    //         multiply rat-5-amt-paid by -1 giving;
                    //                                            rat-145-amt-paid;
                    objTape_145_record.Rat_145_amt_paid = objRat_record_5.Rat_5_amt_paid * -1;
                }
                objTape_145_record.Rat_145_explan_cd = objRat_record_5.Rat_5_explan_cd;
                //     add  rat-5-amount-sub           to ws-rat-67-amt-bill;
                ws_rat_67_amt_bill += objRat_record_5.Rat_5_amount_sub;
                //    add  rat-145-amt-paid           to ws-rat-67-amt-paid;
                ws_rat_67_amt_paid += objTape_145_record.Rat_145_amt_paid;
                //    perform xc1-write-145-record thru xc1-99-exit;
                await xc1_write_145_record();
                await xc1_99_exit();
            }
            //     else if rmb-claims then;
            else if (hcp_rmb_flag.Equals("Y"))
            {
                objTape_rmb_record.Rat_rmb_service_date = objRat_record_5.Rat_5_service_date;
                objTape_rmb_record.Rat_rmb_nbr_of_serv = objRat_record_5.Rat_5_nbr_of_serv;
                objTape_rmb_record.Rat_rmb_service_cd = objRat_record_5.Rat_5_service_cd;
                objTape_rmb_record.Rat_rmb_eligibility_ind = objRat_record_5.Rat_5_eligibility_ind;
                objTape_rmb_record.Rat_rmb_amount_sub = objRat_record_5.Rat_5_amount_sub;
                //    if   rat-5-amt-paid-sign = ' ' then
                if (string.IsNullOrWhiteSpace(objRat_record_5.Rat_5_amt_paid_sign))
                {
                    objTape_rmb_record.Rat_rmb_amt_paid = objRat_record_5.Rat_5_amt_paid;
                }
                else
                {
                    //         multiply rat-5-amt-paid by -1 giving;
                    //                                            rat-rmb-amt-paid;
                    objTape_rmb_record.Rat_rmb_amt_paid = objRat_record_5.Rat_5_amt_paid * -1;
                }
                objTape_rmb_record.Rat_rmb_explan_cd = objRat_record_5.Rat_5_explan_cd;
                //    perform xc2-write-rmb-record    thru xc2-99-exit.;
                await xc2_write_rmb_record();
                await xc2_99_exit();
            }
        }

        private async Task xb1_99_exit()
        {

            //     exit.;
        }

        private async Task xb2_process_rec_6()
        {            
            //     if rat-6-amt-claims-adj-sgn = ' ' then            
            if (string.IsNullOrWhiteSpace(objRat_record_6.Rat_6_amt_claims_adj_sgn))
            {
                objTape_67_record.Rat_67_amt_claims_adj = objRat_record_6.Rat_6_amt_claims_adj;
            }
            else
            {
                //     multiply rat-6-amt-claims-adj by -1 giving rat-67-amt-claims-adj.;
                objTape_67_record.Rat_67_amt_claims_adj = objRat_record_6.Rat_6_amt_claims_adj * -1;
            }

            //     if rat-6-amt-advances-sgn = ' '  then            
            if (string.IsNullOrWhiteSpace(objRat_record_6.Rat_6_amt_advances_sgn))
            {
                objTape_67_record.Rat_67_amt_advances = objRat_record_6.Rat_6_amt_advances;
            }
            else
            {
                //       multiply rat-6-amt-advances by -1 giving rat-67-amt-advances.
                objTape_67_record.Rat_67_amt_advances = objRat_record_6.Rat_6_amt_advances * -1;
            }

            //     if rat-6-amt-reductions-sgn = ' ' then;            
            if (string.IsNullOrWhiteSpace(objRat_record_6.Rat_6_amt_reductions_sgn))
            {
                objTape_67_record.Rat_67_amt_reductions = objRat_record_6.Rat_6_amt_reductions;
            }
            else
            {
                //     multiply rat-6-amt-reductions by -1 giving rat-67-amt-reductions.;
                objTape_67_record.Rat_67_amt_reductions = objRat_record_6.Rat_6_amt_reductions;
            }

            //     if rat-6-amt-deductions-sgn = ' ' then;
            if (string.IsNullOrWhiteSpace(objRat_record_6.Rat_6_amt_deductions_sgn))
            {
                objTape_67_record.Rat_67_amt_deductions = objRat_record_6.Rat_6_amt_deductions;
            }
            else
            {
                //     multiply rat-6-amt-deductions by -1 giving rat-67-amt-deductions.; 
                objTape_67_record.Rat_67_amt_deductions = objRat_record_6.Rat_6_amt_deductions;
            }
        }

        private async Task xb2_99_exit()
        {
            //     exit.;
        }

        private async Task xb3_process_rec_7()
        {            
            objTape_67_record = null;
            objTape_67_record = new Tape_67_record();
            objTape_67_record.Rat_67_trans_cd = objRat_record_7.Rat_7_trans_cd;
            objTape_67_record.Rat_67_cheque_ind = objRat_record_7.Rat_7_cheque_ind;
            objTape_67_record.Rat_67_trans_date = objRat_record_7.Rat_7_trans_date;
            objTape_67_record.Rat_67_trans_message = objRat_record_7.Rat_7_trans_message;

            //     if   rat-7-trans-amt-sgn = ' ' then;
            if (string.IsNullOrWhiteSpace(objRat_record_7.Rat_7_trans_amt_sgn))
            {
                objTape_67_record.Rat_67_trans_amt = objRat_record_7.Rat_7_trans_amt;
            }
            else
            {
                //      multiply rat-7-trans-amt by -1 giving;
                //                                       rat-67-trans-amt.;
                objTape_67_record.Rat_67_trans_amt = objRat_record_7.Rat_7_trans_amt * -1;
            }

            objTape_67_record.Rat_67_total_clinic_amt = ws_rat_1_tot_amt_pay;
            objTape_67_record.Rat_67_amt_bill = ws_rat_67_amt_bill;
            objTape_67_record.Rat_67_amt_paid = ws_rat_67_amt_paid;

            //     perform xc3-write-67-record              thru xc3-99-exit.;
            await xc3_write_67_record();
            await xc3_99_exit();
        }

        private async Task xb3_99_exit()
        {
            //     exit.;
        }

        private async Task xb4_process_rec_8()
        {            
            objTape_8_record = null;
            objTape_8_record = new Tape_8_record();
            objTape_8_record.Rat_8_message_text = objRat_record_8.Rat_8_mess_text;

            //     perform xc4-write-8-record            thru xc4-99-exit.;
            await xc4_write_8_record();
            await xc4_99_exit();
        }

        private async Task xb4_99_exit()
        {
            //     exit.;
        }

        private async Task xc1_write_145_record()
        {
            //     write tape-145-record.;           
            U030_TAPE_145_FILE objU030_TAPE_145_FILE = null;
            objU030_TAPE_145_FILE = new U030_TAPE_145_FILE();

            objU030_TAPE_145_FILE.RAT_145_GROUP_NBR = objTape_145_record.Rat_145_group_nbr;
            objU030_TAPE_145_FILE.RAT_145_MOH_OFF_CD = objTape_145_record.Rat_145_moh_off_cd;
            objU030_TAPE_145_FILE.RAT_145_DATA_SEQ_NBR = objTape_145_record.Rat_145_data_seq_nbr;
            objU030_TAPE_145_FILE.RAT_145_PAYMENT_DATE = objTape_145_record.Rat_145_payment_date;
            objU030_TAPE_145_FILE.RAT_145_PAY_LAST_NAME = objTape_145_record.Rat_145_pay_last_name;
            objU030_TAPE_145_FILE.RAT_145_PAY_TITLE = objTape_145_record.Rat_145_pay_title;
            objU030_TAPE_145_FILE.RAT_145_PAY_INITIALS = objTape_145_record.Rat_145_pay_initials;
            objU030_TAPE_145_FILE.RAT_145_TOT_AMT_PAY = objTape_145_record.Rat_145_tot_amt_pay;
            objU030_TAPE_145_FILE.RAT_145_CHEQ_NBR = objTape_145_record.Rat_145_cheq_nbr;
            objU030_TAPE_145_FILE.RAT_145_CLAIM_NBR = objTape_145_record.Rat_145_claim_nbr;
            objU030_TAPE_145_FILE.RAT_145_TRANS_TYPE = objTape_145_record.Rat_145_trans_type;
            objU030_TAPE_145_FILE.RAT_145_DOC_NBR = objTape_145_record.Rat_145_doc_nbr;
            objU030_TAPE_145_FILE.RAT_145_SPECIALTY_CD = Util.NumDec(objTape_145_record.Rat_145_specialty_cd);
            objU030_TAPE_145_FILE.RAT_145_ACCOUNT_NBR = objTape_145_record.Rat_145_account_nbr;
            objU030_TAPE_145_FILE.RAT_145_LAST_NAME = objTape_145_record.Rat_145_last_name;
            objU030_TAPE_145_FILE.RAT_145_FIRST_NAME = objTape_145_record.Rat_145_first_name;
            objU030_TAPE_145_FILE.RAT_145_PROV_CD = objTape_145_record.Rat_145_prov_cd;
            objU030_TAPE_145_FILE.RAT_145_HEALTH_OHIP_NBR = objTape_145_record.Rat_145_health_ohip_nbr;
            objU030_TAPE_145_FILE.RAT_145_VERSION_CD = objTape_145_record.Rat_145_version_cd;
            objU030_TAPE_145_FILE.RAT_145_PAY_PROG = objTape_145_record.Rat_145_pay_prog;
            objU030_TAPE_145_FILE.RAT_145_CONV_HEALTH_NBR = objTape_145_record.Rat_145_conv_health_nbr;
            objU030_TAPE_145_FILE.RAT_145_SERVICE_DATE = objTape_145_record.Rat_145_service_date;
            objU030_TAPE_145_FILE.RAT_145_NBR_OF_SERV = objTape_145_record.Rat_145_nbr_of_serv;
            objU030_TAPE_145_FILE.RAT_145_SERVICE_CD = objTape_145_record.Rat_145_service_cd;
            objU030_TAPE_145_FILE.RAT_145_ELIGIBILITY_IND = objTape_145_record.Rat_145_eligibility_ind;
            objU030_TAPE_145_FILE.RAT_145_AMOUNT_SUB = objTape_145_record.Rat_145_amount_sub;
            objU030_TAPE_145_FILE.RAT_145_AMT_PAID = objTape_145_record.Rat_145_amt_paid;
            objU030_TAPE_145_FILE.RAT_145_EXPLAN_CD = objTape_145_record.Rat_145_explan_cd;            
            U030_TAPE_145_FILE_Collection.Add(objU030_TAPE_145_FILE);
            xc1_write_145_record_ctr++;
            //int tmp = (xc1_write_145_record_ctr) % 100;
            //if (tmp == 0) Console.WriteLine("xc1_write_145_record Processing Record Number : " + (xc1_write_145_record_ctr).ToString() + " Time : " + DateTime.Now.ToString());
        }
        private async Task xc1_99_exit()
        {
            //     exit.;
        }
        private async Task xc2_write_rmb_record()
        {
            //     write tape-rmb-record.;
            U030_TAPE_RMB_FILE objU030_TAPE_RMB_FILE = null;
            objU030_TAPE_RMB_FILE = new U030_TAPE_RMB_FILE();

            objU030_TAPE_RMB_FILE.RAT_RMB_GROUP_NBR = objTape_rmb_record.Rat_rmb_group_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_MOH_OFF_CD = objTape_rmb_record.Rat_rmb_moh_off_cd;
            objU030_TAPE_RMB_FILE.RAT_RMB_DATA_SEQ_NBR = objTape_rmb_record.Rat_rmb_data_seq_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_PAYMENT_DATE = objTape_rmb_record.Rat_rmb_payment_date;
            objU030_TAPE_RMB_FILE.RAT_RMB_PAY_LAST_NAME = objTape_rmb_record.Rat_rmb_pay_last_name;
            objU030_TAPE_RMB_FILE.RAT_RMB_PAY_TITLE = objTape_rmb_record.Rat_rmb_pay_title;
            objU030_TAPE_RMB_FILE.RAT_RMB_PAY_INITIALS = objTape_rmb_record.Rat_rmb_pay_initials;
            objU030_TAPE_RMB_FILE.RAT_RMB_TOT_AMT_PAY = objTape_rmb_record.Rat_rmb_tot_amt_pay;
            objU030_TAPE_RMB_FILE.RAT_RMB_CHEQ_NBR = objTape_rmb_record.Rat_rmb_cheq_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_CLAIM_NBR = objTape_rmb_record.Rat_rmb_claim_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_TRANS_TYPE = objTape_rmb_record.Rat_rmb_trans_type;
            objU030_TAPE_RMB_FILE.RAT_RMB_DOC_NBR = objTape_rmb_record.Rat_rmb_doc_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_SPECIALTY_CD = Util.NumDec(objTape_rmb_record.Rat_rmb_specialty_cd);
            objU030_TAPE_RMB_FILE.RAT_RMB_ACCOUNT_NBR = objTape_rmb_record.Rat_rmb_account_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_LAST_NAME = objTape_rmb_record.Rat_rmb_last_name;
            objU030_TAPE_RMB_FILE.RAT_RMB_FIRST_NAME = objTape_rmb_record.Rat_rmb_first_name;
            objU030_TAPE_RMB_FILE.RAT_RMB_PROV_CD = objTape_rmb_record.Rat_rmb_prov_cd;
            objU030_TAPE_RMB_FILE.RAT_RMB_HEALTH_OHIP_NBR = objTape_rmb_record.Rat_rmb_health_ohip_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_VERSION_CD = objTape_rmb_record.Rat_rmb_version_cd;
            objU030_TAPE_RMB_FILE.RAT_RMB_PAY_PROG = objTape_rmb_record.Rat_rmb_pay_prog;
            objU030_TAPE_RMB_FILE.RAT_RMB_CONV_HEALTH_NBR = objTape_rmb_record.Rat_rmb_conv_health_nbr;
            objU030_TAPE_RMB_FILE.RAT_RMB_SERVICE_DATE = objTape_rmb_record.Rat_rmb_service_date;
            objU030_TAPE_RMB_FILE.RAT_RMB_NBR_OF_SERV = objTape_rmb_record.Rat_rmb_nbr_of_serv;
            objU030_TAPE_RMB_FILE.RAT_RMB_SERVICE_CD = objTape_rmb_record.Rat_rmb_service_cd;
            objU030_TAPE_RMB_FILE.RAT_RMB_ELIGIBILITY_IND = objTape_rmb_record.Rat_rmb_eligibility_ind;
            objU030_TAPE_RMB_FILE.RAT_RMB_AMOUNT_SUB = objTape_rmb_record.Rat_rmb_amount_sub;
            objU030_TAPE_RMB_FILE.RAT_RMB_AMT_PAID = objTape_rmb_record.Rat_rmb_amt_paid;
            objU030_TAPE_RMB_FILE.RAT_RMB_EXPLAN_CD = objTape_rmb_record.Rat_rmb_explan_cd;            
            U030_TAPE_RMB_FILE_Collection.Add(objU030_TAPE_RMB_FILE);
            xc2_write_rmb_record_ctr++;
            //int tmp = (xc2_write_rmb_record_ctr) % 100;
            //if (tmp == 0) Console.WriteLine("xc2_write_rmb_record Processing Record Number : " + (xc2_write_rmb_record_ctr).ToString() + " Time : " + DateTime.Now.ToString());
        }

        private async Task xc2_99_exit()
        {
            //     exit.;
        }
        private async Task xc3_write_67_record()
        {
            //     write tape-67-record.;
            U030_TAPE_67_FILE objU030_TAPE_67_FILE = null;
            objU030_TAPE_67_FILE = new U030_TAPE_67_FILE();

            objU030_TAPE_67_FILE.RAT_67_AMT_CLAIMS_ADJ = objTape_67_record.Rat_67_amt_claims_adj;
            objU030_TAPE_67_FILE.RAT_67_AMT_ADVANCES = objTape_67_record.Rat_67_amt_advances;
            objU030_TAPE_67_FILE.RAT_67_AMT_REDUCTIONS = objTape_67_record.Rat_67_amt_reductions;
            objU030_TAPE_67_FILE.RAT_67_AMT_DEDUCTIONS = objTape_67_record.Rat_67_amt_deductions;
            objU030_TAPE_67_FILE.RAT_67_TRANS_CD = objTape_67_record.Rat_67_trans_cd;
            objU030_TAPE_67_FILE.RAT_67_CHEQUE_IND = objTape_67_record.Rat_67_cheque_ind;
            objU030_TAPE_67_FILE.RAT_67_TRANS_DATE = objTape_67_record.Rat_67_trans_date;
            objU030_TAPE_67_FILE.RAT_67_TRANS_AMT = objTape_67_record.Rat_67_trans_amt;
            objU030_TAPE_67_FILE.RAT_67_TRANS_MESSAGE = objTape_67_record.Rat_67_trans_message;
            objU030_TAPE_67_FILE.RAT_67_TOTAL_CLINIC_AMT = objTape_67_record.Rat_67_total_clinic_amt;
            objU030_TAPE_67_FILE.RAT_67_AMT_BILL = objTape_67_record.Rat_67_amt_bill;
            objU030_TAPE_67_FILE.RAT_67_AMT_PAID = objTape_67_record.Rat_67_amt_paid;            
            U030_TAPE_67_FILE_Collection.Add(objU030_TAPE_67_FILE);
            xc3_write_67_record_ctr++;
            //int tmp = (xc3_write_67_record_ctr) % 100;
            //if (tmp == 0) Console.WriteLine("xc3_write_67_record Processing Record Number : " + (xc3_write_67_record_ctr).ToString() + " Time : " + DateTime.Now.ToString());
        }
        private async Task xc3_99_exit()
        {
            //     exit.;
        }
        private async Task xc4_write_8_record()
        {
            //     write tape-8-record.;
            U030_TAPE_8_FILE objU030_TAPE_8_FILE = null;
            objU030_TAPE_8_FILE = new U030_TAPE_8_FILE();

            objU030_TAPE_8_FILE.RAT_8_MESSAGE_TEXT = objTape_8_record.Rat_8_message_text;            
            U030_TAPE_8_FILE_Collection.Add(objU030_TAPE_8_FILE);
             xc4_write_8_record_ctr++;
            //int tmp = (xc4_write_8_record_ctr) % 100;
            //if (tmp == 0) Console.WriteLine("xc4_write_8_record Processing Record Number : " + (xc4_write_8_record_ctr).ToString() + " Time : " + DateTime.Now.ToString());
        }

        private async Task xc4_99_exit()
        {
            //     exit.;
        }
        private async Task za0_common_error()
        {            
            e1_error_msg = err_msg[err_ind];
            //     display confirm.;
            //     display e1-error-line.;

            EraseRowRange(23, 23);
            Display("common_error.");
            Console.WriteLine("***  ERROR - " + e1_error_msg);
        }

        private async Task za0_99_exit()
        {
            //     exit.;
        }

        private async Task zb0_abend()
        {            
            //     display "U030 ABENDING";
            //     display " ".;

            EraseRowRange(23, 23);
            Display("abend.");
            Console.WriteLine("U030 ABENDING");
        }

        private async Task zb1_close_files()
        {            
            //     close iconst-mstr;
            //         ohip-rat-tape;
            //    tape-145-file;
            //    tape-rmb-file;
            //    tape-67-file;
            //     tape-8-file.;
            //     stop run.;
        }

        private async Task zb0_99_exit()
        {
            //     exit.;
        }

        // y2k_default_century_year.rtn
        private async Task y2k_add_century_to_year()
        {            
            //  if century-year > 99 then            
            // 	   next sentence;
            //  else if century-year = 99 then            
            //             add 1900                to   century-year;
            // 	else
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
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        #endregion

    }
}
