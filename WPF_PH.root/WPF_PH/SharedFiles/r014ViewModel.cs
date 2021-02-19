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
    public class R014ViewModel: CommonFunctionScr
    {
    
        public R014ViewModel() {
            
        }

        #region FD Section
            	 // FD: print_file
	 private Print_record objPrint_record = null;
	 private ObservableCollection<Print_record> Print_record_Collection;

        // FD: batch_ctrl_file	Copy : f001_batch_control_file.fd
        private F001_BATCH_CONTROL_FILE objBatctrl_rec = null;
        private ObservableCollection<F001_BATCH_CONTROL_FILE> Batctrl_rec_Collection;

        private ICONST_MSTR_REC objICONST_MSTR_REC = null;
        private ObservableCollection<ICONST_MSTR_REC>  ICONST_MSTR_REC_Collection;

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

	 private int _err_ctr;
	 public int err_ctr
	 {
		 get
		 {
			  return _err_ctr;
		 }
		 set
		 {
			  if (_err_ctr != value)
			   {
				_err_ctr = value;
				RaisePropertyChanged("err_ctr");
			   }
		 }
	 }

	 private decimal _err_ctr_ar_due;
	 public decimal err_ctr_ar_due
	 {
		 get
		 {
			  return _err_ctr_ar_due;
		 }
		 set
		 {
			  if (_err_ctr_ar_due != value)
			   {
				_err_ctr_ar_due = value;
				RaisePropertyChanged("err_ctr_ar_due");
			   }
		 }
	 }

	 private decimal _err_ctr_tot_rev;
	 public decimal err_ctr_tot_rev
	 {
		 get
		 {
			  return _err_ctr_tot_rev;
		 }
		 set
		 {
			  if (_err_ctr_tot_rev != value)
			   {
				_err_ctr_tot_rev = value;
				RaisePropertyChanged("err_ctr_tot_rev");
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

	 private string _print_file_name;
	 public string print_file_name
	 {
		 get
		 {
                return _print_file_name = "r014";
         }
		 /*set
		 {
			  if (_print_file_name != value)
			   {
				_print_file_name = value;
				_print_file_name = _print_file_name.ToUpper();
				RaisePropertyChanged("print_file_name");
			   }
		 } */
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


        #endregion
        
        #region Working Storage Section
            	 private int err_ind = 0;
	 //private string print_file_name = "r014";
	 private string const_mstr_rec_nbr;
	 private string eof_batctrl_file = "N";
	 //private string common_status_file;
	 private string status_cobol_batctrl_file = "0";
	 private string status_cobol_iconst_mstr = "0";
	 private string status_prt_file = "0";

	 private decimal ws_temp_sum = 0;
	 private decimal ws_total = 0;
	 private int ws_agent;
	 private int ss_adj_type;
	 private int agent;
	 private int clinic_nbr;
	 private int cycle_nbr;
	 private string ws_clinic_name;
	 private decimal ws_temp_cash;
	 //private int err_ctr;
	 //private decimal err_ctr_ar_due;
	 //private decimal err_ctr_tot_rev;
	 private string feedback_batctrl_file;
	 private string feedback_iconst_mstr;
	 private int sel_clinic_nbr;
	 private string ws_reply;
	 private int hold_clinic_nbr;

	 private string agent_table_subscripts_grp;
	 private int ss_billing = 1;
	 private int ss_misc = 2;
	 private int ss_ar_and_rev = 3;
	 private int ss_rev_only = 4;
	 private int ss_bad_debts = 5;
	 private int ss_cash = 6;

	 private string agent_table_grp;
	 private string[] agent_totals =  new string[11];
	 private decimal[,] current_sums =  new decimal[11,7];
	 private decimal[,] mtd_sums =  new decimal[11,7];

	 private string totals_table_grp;
	 private decimal[] current_totals =  new decimal[7];
	 private decimal[] mtd_totals =  new decimal[7];
	 private string flag;
        private string ok = "Y";
        private string not_ok = "N";

	 private string counters_grp;
	 //private int ctr_batctrl_file_reads;

	 private string error_message_table_grp;
	 private string error_messages_grp;
	 //private string filler = "invalid reply";
	 //private string filler = "INVALID READ ON CONSTANTS MASTER";
	 //private string filler = "invalid reply";
	 //private string filler = "NO BATCTRL FILE SUPPLIED OR NO CORRESPONDING CLINICS";
	 //private string filler = "NO BATCHES FOR THIS MONTH IN FILE";
	 private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "INVALID READ ON CONSTANTS MASTER", "invalid reply", "NO BATCTRL FILE SUPPLIED OR NO CORRESPONDING CLINICS", "NO BATCHES FOR THIS MONTH IN FILE"};
	 //private string err_msg_comment;

	 private string e1_error_line_grp;
	 private string e1_error_word = "***  ERROR - ";
	 private string e1_error_msg;

	 private string h1_head_grp;
	 //private string filler = "r014  /";
	 private int h1_clinic_nbr;
	 //private string filler = "";
	 //private string filler = "** CYCLE AGENT SUMMARY REPORT **";
	 //private string filler = "page   1";

	 private string h2_head_grp;
	 //private string filler = "";
	 //private string filler = "AGENT";
	 //private string filler = "BILLING";
	 //private string filler = "miscellaneous  adjustments";
	 //private string filler = "REVENUE";
	 //private string filler = "BAD";
	 //private string filler = "cash      period";

	 private string h3_head_grp;
	 //private string filler = "";
	 //private string filler = "CODE";
	 //private string filler = "A/R & REVENUE";
	 //private string filler = "INCOME     A/R & REVENUE";
	 //private string filler = "ONLY";
	 //private string filler = "DEBTS";
	 //private string filler = "RECEIVED";

	 private string h4_head_grp;
	 //private string filler = "";
	 private string h4_clinic_name;
	 //private string filler = "month ending";
	 private string h4_yy;
	 //private string filler = "/";
	 private string h4_mm;
	 //private string filler = "/";
	 private string h4_dd;
	 //private string filler = "";

	 private string h5_head_grp;
	 //private string filler = "";
	 //private string filler = "GRAND TOTAL CYCLE # ";
	 private int h5_cycle_nbr;
	 //private string filler = "";

	 private string l1_print_line_grp;
	 private string l1_part_1_grp;
	 private string filler;
	 private int l1_agent_cd;
	 //private string filler;
	 private string l1_totals;
	 private string[] l1_part_2 =  new string[6];
	 private decimal[] l1_amount =  new decimal[6];
	 //private string[] filler =  new string[6];
	 //private string filler;
	 private decimal l1_cash;
	 private string l1_period;

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

        private bool isRetrieving;
        private string endOfJob = "End of Job";
        private int ctr;
        private bool isPrintDetails = false;
        private bool isProcess = false;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection ()
	{
		ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
		{
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "12",Col = 20,Data1 = "CYCLE AGENT SUMMARY REPORT - CONTINUE (Y/N)?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 20,Data1 = "NUMBER OF BATCH-CTRL-MSTR ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_batctrl_file_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 20,Data1 = "PROGRAM R014 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "PRINT REPORT IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen-err-display.",Line = "16",Col = 20,Data1 = "NBR OF INCORRECT BATCH/ADJUST. CODES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen-err-display.",Line = "16",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "err_ctr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen-err-display.",Line = "18",Col = 20,Data1 = "TOTAL REJECTED CALCULATED A/R DUE    = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen-err-display.",Line = "18",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(4)9.99",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "err_ctr_ar_due",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen-err-display.",Line = "20",Col = 20,Data1 = "TOTAL REJECTED CALCULATED REVENUE    = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen-err-display.",Line = "20",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(4)9.99",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "err_ctr_tot_rev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""} 

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
	 }

	 private void err_constants_mstr_file_ection()
	 {

		 //     use after standard error procedure on iconst-mstr.;
	 }

	 private void err_constants_mstr()
	 {

		 common_status_file = status_cobol_iconst_mstr;
		 //     display file-status-display.;
		 //     stop "ERROR IN ACCESSING ICONSTANTS MASTER".;
	 }

	 private void end_declaratives()
	 {

	 }

	 private void main_line_section()
	 {

	 }

	 public void mainline()
	 {         
            try {
                objPrint_record = null;
                objPrint_record = new Print_record();

                objICONST_MSTR_REC = null;
                objICONST_MSTR_REC = new ICONST_MSTR_REC();

                ICONST_MSTR_REC_Collection = null;
                ICONST_MSTR_REC_Collection = new ObservableCollection<ICONST_MSTR_REC>();

        objPrintFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

                //     perform aa0-initialization		thru aa0-99-exit.;
                 aa0_initialization();
                //aa0_10_continue_y_n();
                //aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit;
                // 		until eof-batctrl-file = 'Y'.;
                if (aa0_10_continue_y_n())
                {
                    aa0_99_exit();
                    do
                    {                        
                        ab0_processing();
                        ab0_99_exit();

                    } while (!eof_batctrl_file.ToUpper().Equals("Y"));
                }

                //     perform az0-end-of-job		thru az0-99-exit.;
                 az0_end_of_job();
                 az0_10_end_of_job();
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
        }

	 private void aa0_initialization()
	 {            

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
		 //     open input	batch-ctrl-file;
		 // 		iconst-mstr.;

		 agent_table_grp = "0";
         agent_totals = new string[11];
         current_sums = new decimal[11, 7];
         mtd_sums = new decimal[11, 7];


        totals_table_grp = "0";
        current_totals = new decimal[7];
        mtd_totals = new decimal[7];
        
        l1_print_line_grp = "";
        l1_part_1_grp = "";
        l1_agent_cd = 0;
        l1_totals = "";
        l1_part_2 = new string[6];
        l1_amount = new decimal[6];
        l1_cash = 0;
        l1_period = "";

            //     display scr-title.;
            Console.WriteLine("CYCLE AGENT SUMMARY REPORT - CONTINUE (Y/N)?");
           // ws_reply = Console.ReadLine();
    }

	 private bool aa0_10_continue_y_n()
	 {            
            ws_reply = "Y";

            //  if ws-reply =   "Y" or "N"  then            
            if (Util.Str(ws_reply).ToUpper().Equals("Y") || Util.Str(ws_reply).ToUpper().Equals("N")) {
                // 	    if ws-reply = "Y" then            
                if (Util.Str(ws_reply).ToUpper().Equals("Y")) {
                    // 	        next sentence;
                }
                else {
                    // 	       go to az0-10-end-of-job;
                     az0_10_end_of_job();
                    return false;
                }
            }
            else {
                     err_ind = 1;
                //   perform za0-common-error	thru za0-99-exit;
                 za0_common_error();
                 za0_99_exit();
                // 	   go to aa0-10-continue-y-n.;
                 aa0_10_continue_y_n();
                return true;
            }

            //     open output print-file.;

            //         key_batctrl_file = 0;

            //     start batch-ctrl-file key is greater than or equal to key-batctrl-file;
            //       invalid key;
            //           err_ind = 4;
            // 	      perform za0-common-error	thru	za0-99-exit;
            // 	      go to az0-end-of-job.;

            //     read batch-ctrl-file next.;

            isRetrieving = false;

            Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = "" 
            }.Collection_Using_Start_Key_BatCtrl_File(ref isRetrieving, Batctrl_rec_Collection);

            if (Batctrl_rec_Collection.Count() == 0)
            {
                         err_ind = 4;
                //    perform za0-common-error	thru	za0-99-exit;
                 za0_common_error();
                 za0_99_exit();
                // 	      go to az0-end-of-job.;
                az0_end_of_job();
                return false;
            }
            objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];                        

            //     add 1				to	ctr-batctrl-file-reads.;
            ctr_batctrl_file_reads++;

            //     perform xc0-read-const-mstr		thru	xc0-99-exit.;
            xc0_read_const_mstr();
            xc0_99_exit();

            if (Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2)) == hold_clinic_nbr )  // added
            {
                //     perform xa0-save-clinic-info	thru	xa0-99-exit.;
                xa0_save_clinic_info();
                xa0_99_exit();
            } else if (hold_clinic_nbr == 0)
            {
                //     perform xa0-save-clinic-info	thru	xa0-99-exit.;
                xa0_save_clinic_info();
                xa0_99_exit();
            }

            //     perform ad0-sel-read-batch-ctrl-file thru	ad0-99-exit.;
             ad0_sel_read_batch_ctrl_file();
            ad0_99_exit();

            // if eof-batctrl-file = "Y" then  
            if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y") ) {
                     err_ind = 5;
                // 	   perform za0-common-error	thru	za0-99-exit;
                 za0_common_error();
                 za0_99_exit();
                // 	   go to az0-end-of-job.;
                 az0_end_of_job();
                return false;
            }
            return true;
        }

        private void aa0_99_exit()
	 {            
            //     exit.;
        }

	 private void az0_end_of_job()
	 {            

            //     close batch-ctrl-file;
            // 	  iconst-mstr.;

            objBatctrl_rec = null;
            Batctrl_rec_Collection = null;
     }

	 private void az0_10_end_of_job()
	 {            

            //     close print-file.;
            objPrintFile.Close();
            //     display blank-screen.;
            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");
            //     display scr-closing-screen.;
            Console.WriteLine("NUMBER OF BATCH - CTRL - MSTR ACCESSES = "  + Util.Str(ctr_batctrl_file_reads));
            Console.WriteLine("PROGRAM R014 ENDING "  + sys_yy + "/" + sys_mm + "/" + sys_dd + "   "  + sys_hrs + ":" + sys_min);
            Console.WriteLine("PRINT REPORT IS IN FILE - " + print_file_name);

            //  if err-ctr > zero then            
            if (err_ctr > 0) {
                // 	    display scr-closing-screen-err-display.;
                Console.WriteLine("NBR OF INCORRECT BATCH/ADJUST. CODES = " + Util.Str(err_ctr));
                Console.WriteLine("TOTAL REJECTED CALCULATED A/R DUE    = " + Util.Str(err_ctr_ar_due));
                Console.WriteLine("TOTAL REJECTED CALCULATED REVENUE    = " + Util.Str(err_ctr_tot_rev));
            }
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
	 {            
            //     exit.;
        }

	 private void ab0_processing()
	 {            

            // if batctrl-bat-clinic-nbr-1-2 not = hold-clinic-nbr then
            if (Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8).Substring(0,2)) != hold_clinic_nbr ) {
                if (isProcess)  // added
                {
                    // 	   perform ab1-print-clinic-totals	thru	ab1-99-exit;
                    ab1_print_clinic_totals();
                    ab1_99_exit();
                    // 	   perform ac0-build-sums		thru	ac0-99-exit;
                    ac0_build_sums();
                    ac0_99_exit();
                    // ctr_batctrl_file_reads++;
                }
                else
                {
                    xa0_save_clinic_info(); // added
                    ctr_batctrl_file_reads--;
                }
            }
            else {
                // 	   perform ac0-build-sums		thru	ac0-99-exit.;
                 ac0_build_sums();
                 ac0_99_exit();
            }

            //  perform xb0-read-next-batch		thru	xb0-99-exit.;
             xb0_read_next_batch();
             xb0_99_exit();

            //  perform ad0-sel-read-batch-ctrl-file thru	ad0-99-exit.;
            isPrintDetails = false;
             ad0_sel_read_batch_ctrl_file();
             ad0_99_exit();

            //  if eof-batctrl-file = "Y"  then 
            if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y") || isPrintDetails == true ) {
                // 	    perform ab1-print-clinic-totals	thru	ab1-99-exit;
                 ab1_print_clinic_totals();
                 ab1_99_exit();
                // 	    go to ab0-99-exit.;
                 ab0_99_exit();

                if (isPrintDetails == true)
                {
                    ad0_sel_read_batch_ctrl_file();
                }
                return;
            }
        }

        private void ab0_99_exit()
	 {            

            //     exit.;
        }

	 private void ab1_print_clinic_totals()
	 {      

            //     perform ag0-sum-agent-totals 		thru	ag0-99-exit;
            // 	varying agent;
            // 	from 1 by 1;
            // 	until   agent > 10.;

            agent = 1;
            do
            {
                ag0_sum_agent_totals();
                ag0_99_exit();
                agent++;
            } while (agent <= 10);

            //     perform af0-print-headings			thru	af0-99-exit.;
            af0_print_headings();
            af0_99_exit();

            //     perform ah0-print-detail-lines		thru	ah0-99-exit;
            // 	varying agent;
            // 	from 1 by 1;
            // 	until agent > 10.;

            agent = 1;
            do
            {
                ah0_print_detail_lines();
                ah0_99_exit();
                agent++;
            } while (agent <= 10);

            //     perform ai0-print-totals			thru	ai0-99-exit.;
            ai0_print_totals();
            ai0_99_exit();

            agent_table_grp = "0";
         agent_totals = new string[11];
         current_sums = new decimal[11, 7];
         mtd_sums = new decimal[11, 7];

        totals_table_grp = "0";
        current_totals = new decimal[7];
        mtd_totals = new decimal[7];

            //  if eof-batctrl-file not = 'Y' then 
            if (!Util.Str(eof_batctrl_file).ToUpper().Equals("Y") ) {
                //   	perform xa0-save-clinic-info		thru	xa0-99-exit.;
                 xa0_save_clinic_info();
                 xa0_99_exit();
            }
    }

        private void ab1_99_exit()
	 {            

            //     exit.;
        }

	 private void ac0_build_sums()
	 {            

            agent = Util.NumInt(objBatctrl_rec.BATCTRL_AGENT_CD);

            //     add 1					to	agent.;
            agent++;

            ss_adj_type = 0;

            //  if batctrl-adj-cd =    " " or "0" then  
            if (string.IsNullOrWhiteSpace(objBatctrl_rec.BATCTRL_ADJ_CD) ||  Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).Equals("0")) {
                ss_adj_type = 1;
            }
            else {
                // 	    perform ac1-determine-adj-pay-category	thru	ac1-99-exit;
                 ac1_determine_adj_pay_category();
                 ac1_99_exit();

                // 	    if ss-adj-type = zero then            
                if (ss_adj_type == 0 ) {
                    // 	       go to ac0-99-exit;
                     ac0_99_exit();
                    return; 
                }
                else {
                    // 	       next sentence.;
                }
            }


            //  if   batctrl-batch-status = "1" or batctrl-batch-status = "2" then 
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).Equals("1") || Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).Equals("2")) {
                // 	     if   batctrl-adj-cd = "R" then            
                if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("R")) {
                    // 	          add     batctrl-calc-tot-rev	to	current-sums (agent,ss-adj-type);
                    current_sums[agent, ss_adj_type] = current_sums[agent, ss_adj_type] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
                }
                // 	     else if batctrl-adj-cd = "M" then            
                else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("M") ) {
                    // 		      add batctrl-calc-tot-rev			to	current-sums (agent,ss-adj-type);
                    // 								                    current-sums (agent,ss-cash);
                    current_sums[agent, ss_adj_type] = current_sums[agent, ss_adj_type] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
                    current_sums[agent, ss_cash] = current_sums[agent, ss_cash] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
                }
                // 	    else if batctrl-adj-cd = "C" then            
                else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C") ) {
                    // 		    subtract batctrl-manual-pay-tot	from	zero;
                    // 							giving	ws-temp-sum;
                    ws_temp_sum = 0 - Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
                    // 		     add ws-temp-sum			to	current-sums (agent,ss-adj-type);
                    current_sums[agent, ss_adj_type] = current_sums[agent, ss_adj_type] + ws_temp_sum;
                }
                else {
                    // 		    add batctrl-calc-ar-due		to	current-sums (agent,ss-adj-type);
                    current_sums[agent, ss_adj_type] = current_sums[agent, ss_adj_type] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);
                }
            }
            else {
                // 	    next sentence.;
            }

            // if batctrl-batch-status not = "0" then;
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS) != "0") {
                // 	  if batctrl-adj-cd = "R" then
                if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("R")) {
                    // 	    add     batctrl-calc-tot-rev	to	mtd-sums (agent,ss-adj-type);
                    mtd_sums[agent, ss_adj_type] = mtd_sums[agent, ss_adj_type] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);                    
                }
                // 	  else if batctrl-adj-cd = "M" then            
                else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("M") ) {
                    // 		add batctrl-calc-tot-rev		to	mtd-sums (agent,ss-adj-type);
                    mtd_sums[agent, ss_adj_type] = mtd_sums[agent, ss_adj_type] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);                    
                    // 							                 mtd-sums (agent,ss-cash);
                    mtd_sums[agent, ss_cash] = mtd_sums[agent, ss_cash] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
                }
                // 	  else if batctrl-adj-cd = "C" then            
                else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C")) {
                    // 		    subtract batctrl-manual-pay-tot	from	zero;
                    // 							giving	ws-temp-sum;
                    ws_temp_sum = 0 - Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);                   
                    // 		    add ws-temp-sum			to	mtd-sums (agent,ss-adj-type);
                    mtd_sums[agent, ss_adj_type] = mtd_sums[agent, ss_adj_type] + ws_temp_sum;                    
                }
                else {
                    // 		    add batctrl-calc-ar-due		to	mtd-sums (agent,ss-adj-type);
                    mtd_sums[agent, ss_adj_type] = mtd_sums[agent, ss_adj_type] + Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);                    
                }
            }
            else {
                //   	next sentence.;
            }
        }

        private void ac0_99_exit()
	 {            
            //     exit.;
        }

	 private void ac1_determine_adj_pay_category()
	 {            

            // if batctrl-adj-cd = "M" then 
            if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("M")) {
                ss_adj_type = 2;
            }
            // else if batctrl-adj-cd = "B" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("B")) {
                ss_adj_type = 3;
            }
            // else if batctrl-adj-cd = "R" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("R") ) {
                    ss_adj_type = 4;
            }
            // else if batctrl-adj-cd = "A" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("A")) {
                    ss_adj_type = 5;
            }
            // else if batctrl-adj-cd = "C" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C")) {
                    ss_adj_type = 6;
            }
            else {
                     ss_adj_type = 0;
                // 	   add 1				to	err-ctr;
                err_ctr++;
                // 	   add batctrl-calc-ar-due		to	err-ctr-ar-due;
                err_ctr_ar_due += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);
                //        add batctrl-calc-tot-rev	to	err-ctr-tot-rev.;
                err_ctr_tot_rev += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
            }
	 }

	 private void ac1_99_exit()
	 {            
            //     exit.;
        }

	 private void ad0_sel_read_batch_ctrl_file()
	 {            

            bool isExit = false;
            while (isExit == false)
            {                

                //  if eof-batctrl-file = 'Y'  then 
                if (Util.Str(eof_batctrl_file).ToUpper().Equals("y"))
                {
                    // 	   go to ad0-99-exit.;
                    ad0_99_exit();
                    break;
                }

                //  if batctrl-bat-clinic-nbr-1-2 not = hold-clinic-nbr then 
                if (Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8).Substring(0, 2)) != hold_clinic_nbr)
                {
                    // 	   perform xc0-read-const-mstr	thru xc0-99-exit.;
                    xc0_read_const_mstr();
                    xc0_99_exit();
                    isPrintDetails =  isProcess == true ? true : false;                     
                    break;
                }

                //  if  batctrl-batch-status	> "0" and batctrl-date-period-end = iconst-date-period-end then 
                if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS).CompareTo("0") > 0 && Util.NumInt(objBatctrl_rec.BATCTRL_DATE_PERIOD_END) == Util.NumInt(Util.Str(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY.ToString()) + Util.Str(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_MM.ToString()).PadLeft(2, '0') + Util.Str(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_DD.ToString()).PadLeft(2, '0')))
                {
                    isProcess = true;
                    // 	    next sentence;                   
                    break;
                }
                else
                {
                    // 	    perform xb0-read-next-batch	thru	xb0-99-exit;
                    xb0_read_next_batch();
                    xb0_99_exit();

                    // 	    if eof-batctrl-file = 'Y' then            
                    if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y"))
                    {
                        // 	       go to ad0-99-exit;
                        ad0_99_exit();
                        break;
                    }
                    else
                    {
                        // go to ad0-sel-read-batch-ctrl-file.;
                       // ad0_sel_read_batch_ctrl_file();
                       // return;
                    }
                }
            }
        }

        private void ad0_99_exit()
	 {            

            //     exit.;
        }

	 private void af0_print_headings()
	 {            

            //     write print-record			from	h1-head after advancing page.;
            objPrint_record.Print_record1 = h1_head();
            objPrintFile.PageBreak();
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //     write print-record from h4-head after advancing 1 line.;
            objPrint_record.Print_record1 = h4_head();            
            objPrintFile.print(objPrint_record.Print_record1, 1, true);
            //     write print-record from h5-head after advancing 2 lines.;
            objPrint_record.Print_record1 = h5_head();            
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);
            //     write print-record from h2-head after advancing 2 lines.;
            objPrint_record.Print_record1 = h2_head();            
            objPrintFile.print(true);
            objPrintFile.print(objPrint_record.Print_record1, 1, true);
            //     write print-record from h3-head after advancing 1 line.;
            objPrint_record.Print_record1 = h3_head();            
            objPrintFile.print(objPrint_record.Print_record1, 1, true);
	 }

	 private void af0_99_exit()
	 {         
            //     exit.;
        }

	 private void ag0_sum_agent_totals()
	 {            

            //     perform ag1-add-totals		thru ag1-99-exit;
            // 	varying ss-adj-type;
            // 	from 1 by 1;
            // 	until ss-adj-type > 6.;

            ss_adj_type = 1;
            do
            {
                ag1_add_totals();
                ag1_99_exit();
                ss_adj_type++;
            } while (ss_adj_type <= 6);

	 }

	 private void ag0_99_exit()
	 {            

            //     exit.;
        }

	 private void ag1_add_totals()
	 {            

            //     add current-sums (agent, ss-adj-type)	to	current-totals (ss-adj-type).;
            current_totals[ss_adj_type] += current_sums[agent, ss_adj_type];
            //     add mtd-sums (agent, ss-adj-type)		to	mtd-totals (ss-adj-type).;
            mtd_totals[ss_adj_type] += mtd_sums[agent, ss_adj_type];
        }

	 private void ag1_99_exit()
	 {      
            //     exit.;
        }

	 private void ah0_print_detail_lines()
	 {            

            ws_total = 0;

            //  add mtd-sums (agent,1);
            // 	mtd-sums (agent,2);
            // 	mtd-sums (agent,3);
            // 	mtd-sums (agent,4);
            // 	mtd-sums (agent,5);
            // 	mtd-sums (agent,6)		to	ws-total.;
            ws_total = mtd_sums[agent, 1] + mtd_sums[agent, 2] + mtd_sums[agent, 3] + mtd_sums[agent, 4] + mtd_sums[agent, 5] + mtd_sums[agent, 6];

            // if ws-total not = 0 then            
            if (ws_total != 0 ) {
                // 	   compute ws-agent = agent - 1;
                  ws_agent = agent - 1;
                //     l1_agent_cd = ws_agent;
                l1_agent_cd = ws_agent;
                //     perform ah1-cur-sums-to-prt-line thru ah1-99-exit;
                // 	    varying ss-adj-type;
                // 	    from 1 by 1;
                // 	    until ss-adj-type > 5;
                ss_adj_type = 1;
                do
                {
                    ah1_cur_sums_to_prt_line();
                    ah1_99_exit();
                    ss_adj_type++;
                } while (ss_adj_type <= 5);

                      l1_cash = current_sums[agent,6];
                      l1_period = " CURRENT";
                // 	    write print-record		from	l1-print-line after advancing 2 lines;
                //objPrintFile.print(true);
                objPrintFile.print(true);
                objPrint_record.Print_record1 = l1_print_line();
                objPrintFile.print(objPrint_record.Print_record1, 1, true);
                //      l1_print_line = "";
                l1_print_line(true);
                // 	    perform ah2-mtd-sums-to-prt-line thru ah2-99-exit;
                // 	       varying ss-adj-type;
                // 	       from 1 by 1;
                // 	       until ss-adj-type > 5;
                ss_adj_type = 1;
                do
                {
                    ah2_mtd_sums_to_prt_line();
                    ah2_99_exit();
                    ss_adj_type++;
                } while (ss_adj_type <= 5);

                l1_cash = mtd_sums[agent, 6];
                l1_period = " M.T.D.";
                // 	     write print-record from l1-print-line after advancing 1 line;
                string temp = l1_print_line();
                temp = "".PadRight(9) + temp.Substring(9);
                objPrint_record.Print_record1 = temp;                
                objPrintFile.print(objPrint_record.Print_record1, 1, true);
                //      l1_print_line = "";
                l1_print_line(true);
            }
	 }

	 private void ah0_99_exit()
	 {            
            //     exit.;
        }

	 private void ah1_cur_sums_to_prt_line()
	 {            

            //move current-sums(agent, ss - adj - type)   to l1-amount(ss - adj - type).
            l1_amount[ss_adj_type] = current_sums[agent, ss_adj_type];
     }

	 private void ah1_99_exit()
	 {            

            //     exit.;
        }

	 private void ah2_mtd_sums_to_prt_line()
	 {            

            //move mtd-sums(agent, ss - adj - type)       to l1-amount(ss - adj - type).
            l1_amount[ss_adj_type] = mtd_sums[agent, ss_adj_type];
     }

	 private void ah2_99_exit()
	 {            
            //     exit.;
        }

	 private void ai0_print_totals()
	 {
            
            //move " TOTALS *"			to	l1-totals. 
            l1_totals = " TOTALS *";
            //     perform ai1-cur-ttl-to-prt-line	thru ai1-99-exit;
            // 	varying ss-adj-type;
            // 	from 1 by 1;
            // 	until ss-adj-type > 5.;
            ss_adj_type = 1;
            do
            {
                ai1_cur_ttl_to_prt_line();
                ai1_99_exit();
                ss_adj_type++;
            } while (ss_adj_type <= 5);


            l1_cash = current_totals[6];
		    l1_period = " CURRENT";
            //     write print-record 			from	l1-print-line after advancing 3 lines.;
            string temp = l1_print_line();
            temp = l1_totals + temp.Substring(9);
            objPrint_record.Print_record1 = temp;
            objPrintFile.print(true);
            objPrintFile.print(true);            
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //l1_print_line = "";
            l1_print_line(true);

            //     perform ai2-mtd-ttl-to-prt-line	thru ai2-99-exit;
            // 	varying ss-adj-type;
            // 	from 1 by 1;
            // 	until ss-adj-type > 5.;
            ss_adj_type = 1;
            do
            {
                ai2_mtd_ttl_to_prt_line();
                ai2_99_exit();
                ss_adj_type++;
            } while (ss_adj_type <= 5);

		 l1_cash = mtd_totals[6];
		 l1_period = " M.T.D.";
            //     write print-record from l1-print-line after advancing 1 line.;
            temp = l1_print_line();
            temp = "         " + temp.Substring(9);
            objPrint_record.Print_record1 = temp;            
            objPrintFile.print(objPrint_record.Print_record1, 1, true);

            //l1_print_line = "";
            l1_print_line(true);
	 }

	 private void ai0_99_exit()
	 {            
            //     exit.;
        }

	 private void ai1_cur_ttl_to_prt_line()
	 {      

            //move current-totals(ss - adj - type)       to l1-amount(ss - adj - type).
            l1_amount[ss_adj_type] = current_totals[ss_adj_type];
     }

	 private void ai1_99_exit()
	 {            

            //     exit.;
        }

	 private void ai2_mtd_ttl_to_prt_line()
	 {            

            // move mtd-totals (ss-adj-type)		to	l1-amount (ss-adj-type). 
            l1_amount[ss_adj_type] = mtd_totals[ss_adj_type];
        }

        private void ai2_99_exit()
	 {            

            //     exit.;
        }

	 private void xa0_save_clinic_info()
	 {
            
            hold_clinic_nbr = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8).Substring(0,2));  //batctrl_bat_clinic_nbr_1_2;

            h1_clinic_nbr = Util.NumInt(objICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2);  //iconst_clinic_nbr_1_2;
            h4_clinic_name = Util.Str(objICONST_MSTR_REC.ICONST_CLINIC_NAME);   //iconst_clinic_name;
            h4_yy = Util.Str(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY);  // iconst_date_period_end_yy;
            h4_mm = Util.Str(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_MM);  // iconst_date_period_end_mm;
            h4_dd = Util.Str(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_DD); //  iconst_date_period_end_dd;
            h5_cycle_nbr = Util.NumInt(objICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR); // iconst_clinic_cycle_nbr;
            isProcess = false;
     }

	 private void xa0_99_exit()
	 {            
            //     exit.;
        }

	 private void xb0_read_next_batch()
	 {            

            //     read batch-ctrl-file next;
            // 	at end;
            //         eof_batctrl_file = 'Y';
            // 	    go to xb0-99-exit.;

            if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count() || Batctrl_rec_Collection.Count() == 0)
            {
                    eof_batctrl_file = "Y";
                // 	 go to xb0-99-exit.;
                xb0_99_exit();
                return; 
            }

            objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];            

            //     add 1				to ctr-batctrl-file-reads.;
            ctr_batctrl_file_reads++;
        }

	 private void xb0_99_exit()
	 {            

            //     exit.;
        }

	 private void xc0_read_const_mstr()
	 {            

            //iconst_clinic_nbr_1_2 = batctrl_bat_clinic_nbr_1_2;

            //  read iconst-mstr;
            //     	invalid key;
            //         err_ind = 2;
            // 	       perform za0-common-error	thru	za0-99-exit;
            // 	      go to az0-end-of-job.;

            objICONST_MSTR_REC = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8).Substring(0,2))
            }.Collection().FirstOrDefault();

            if (objICONST_MSTR_REC == null)
            {
                         err_ind = 2;
                //       perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	      go to az0-end-of-job.;
                az0_end_of_job();
                return; 
            }
        }

	 private void xc0_99_exit()
	 {            
            //     exit.;
        }

	 private void za0_common_error()
	 {            

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            Console.WriteLine(" ERROR -  " + err_msg_comment);

		 //     display confirm.;
		 //     stop " ".;
		 //     display blank-line-24.;
	 }

	 private void za0_99_exit()
	 {            
            //     exit.;
     }

       private string h1_head(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                h1_clinic_nbr = 0;
                return string.Empty;
            }
            else
            {
                return "R014  /".PadRight(7) +
                        Util.Str(h1_clinic_nbr).PadLeft(2, ' ') +
                        new string(' ', 40) +
                        "** CYCLE AGENT SUMMARY REPORT **".PadRight(73) +
                        "PAGE   1".PadRight(10);
            }
        }

        private string h2_head(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                return string.Empty;
            }
            else {
                return new string(' ', 3) +
                       "AGENT".PadRight(17) +
                       "BILLING".PadRight(16) +
                       "MISCELLANEOUS  ADJUSTMENTS".PadRight(35) +
                       "REVENUE".PadRight(18) +
                       "BAD".PadRight(26) +
                       "CASH      PERIOD".PadRight(17);
            }
        }

        private string h3_head(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                return string.Empty;
            }
            else {
                return new string(' ', 4) +
                       "CODE".PadRight(13) +
                       "A/R & REVENUE".PadRight(22) +
                       "INCOME     A/R & REVENUE".PadRight(33) +
                       "ONLY".PadRight(16) +
                       "DEBTS".PadRight(25) +
                       "RECEIVED".PadRight(19);
            }
        }

        private string h4_head(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                h4_clinic_name = string.Empty;
                h4_yy = string.Empty;
                h4_mm = string.Empty;
                h4_dd = string.Empty;
                return string.Empty;
            }
            else
            {
                return new string(' ', 52) +
                       Util.Str(h4_clinic_name).PadRight(45) +
                       "MONTH ENDING".PadRight(13) +
                       Util.Str(h4_yy).PadLeft(4,'0') +
                       "/" +
                       Util.Str(h4_mm).PadLeft(2,'0') +
                       "/" +
                       Util.Str(h4_dd).PadLeft(2,'0') +
                       new string(' ', 14);
            }
        }

        private string h5_head(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                h5_cycle_nbr = 0;
                return string.Empty;
            }
            else {
                return new string(' ', 52) +
                       "GRAND TOTAL CYCLE # ".PadRight(20) +
                       Util.Str(h5_cycle_nbr).PadLeft(3, '0') +
                       new string(' ', 57);
            }
        }

        private string l1_print_line(bool isClearValues = false)
        {            

            if (isClearValues)
            {
                l1_agent_cd = 0;
                l1_amount = new decimal[6];
                l1_cash = 0;
                l1_period = string.Empty;
                return string.Empty;
            }
            else {
                return new string(' ', 5) +
                       Util.Str(l1_agent_cd).PadLeft(1, '0') +
                       new string(' ', 10) +
                       Util.ImpliedDecimalFormat("#,0.00", l1_amount[1], 2, 14) +
                       new string(' ', 3) +
                       Util.ImpliedDecimalFormat("#,0.00", l1_amount[2], 2, 14) +
                       new string(' ', 3) +
                       Util.ImpliedDecimalFormat("#,0.00", l1_amount[3], 2, 14) +
                       new string(' ', 3) +
                       Util.ImpliedDecimalFormat("#,0.00", l1_amount[4], 2, 14) +
                       new string(' ', 3) +
                       Util.ImpliedDecimalFormat("#,0.00", l1_amount[5], 2, 14) +
                       new string(' ', 3) +
                       new string(' ', 9) +
                       Util.ImpliedDecimalFormat("#,0.00", l1_cash, 2, 14) +
                       Util.Str(l1_period).PadRight(10);
            }
        }

        #endregion
    }
}

