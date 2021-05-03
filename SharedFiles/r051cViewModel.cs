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
    public class R051cViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file_one
        private ReportPrint objPrint_record_one = null;
        private ObservableCollection<Print_record_one> Print_record_one_Collection;

        // FD: print_file_summ
        //private Print_record_summ objPrint_record_summ = null;
        private ObservableCollection<Print_record_summ> Print_record_summ_Collection;

        // FD: print_file_two
        private ReportPrint objPrint_record_two = null;
        private ObservableCollection<Print_record_two> Print_record_two_Collection;

        // FD: r051_work_file	Copy : r051_docrev_work_mstr.fd
        private r051_work_rec objWork_file_rec = null;
        private ObservableCollection<r051_work_rec> Work_file_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        // FD: oma_fee_mstr	Copy : f040_oma_fee_mstr.fd
        private F040_OMA_FEE_MSTR objFee_mstr_rec = null;
        private ObservableCollection<F040_OMA_FEE_MSTR> Fee_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private F070_DEPT_MSTR objDept_mstr_rec = null;
        private ObservableCollection<F070_DEPT_MSTR> Dept_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_4.ws
        private CONSTANTS_MSTR_REC_4 objConstants_mstr_rec_4 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_4> Constants_mstr_rec_4_Collection;

        // FD: iconst_mstr	Copy : r051_parm_file.fd
        private Parm_file_rec objParm_file_rec = null;
        private ObservableCollection<Parm_file_rec> Parm_file_rec_Collection;

        private ReportPrint objPrint_record_summ;
        private Work_in_rec objWork_in_rec = null;

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

        private int _ctr_doc_mstr_reads;
        public int ctr_doc_mstr_reads
        {
            get
            {
                return _ctr_doc_mstr_reads;
            }
            set
            {
                if (_ctr_doc_mstr_reads != value)
                {
                    _ctr_doc_mstr_reads = value;
                    RaisePropertyChanged("ctr_doc_mstr_reads");
                }
            }
        }

        /* private int _ctr_work_file_reads;
         public int ctr_work_file_reads
         {
             get
             {
                  return _ctr_work_file_reads;
             }
             set
             {
                  if (_ctr_work_file_reads != value)
                   {
                    _ctr_work_file_reads = value;
                    RaisePropertyChanged("ctr_work_file_reads");
                   }
             }
         } */

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

        /* private string _print_file_name_one;
         public string print_file_name_one
         {
             get
             {
                  return _print_file_name_one;
             }
             set
             {
                  if (_print_file_name_one != value)
                   {
                    _print_file_name_one = value;
                    _print_file_name_one = _print_file_name_one.ToUpper();
                    RaisePropertyChanged("print_file_name_one");
                   }
             }
         } */

        /* private string _print_file_name_two;
         public string print_file_name_two
         {
             get
             {
                  return _print_file_name_two;
             }
             set
             {
                  if (_print_file_name_two != value)
                   {
                    _print_file_name_two = value;
                    _print_file_name_two = _print_file_name_two.ToUpper();
                    RaisePropertyChanged("print_file_name_two");
                   }
             }
         } */


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name_one = "r051ca";
        private string print_file_name_summ = "r051ca_summ";
        private string print_file_name_two = "r051cb";
        private string option;
        private int nbr_of_lines_to_print;
        private int max_nbr_lines = 60;
        private int ctr_lines = 70;
        private int summ_max_nbr_lines = 60;
        private int summ_ctr_lines = 70;
        private int parm_rec_nbr;
        private string blank_line = "";
        private int subs;
        private int subs1;
        private int subs_dept_clinic;
        private int subs_class_code;
        private int subs_present_nbr_classes;
        private int subs_max_nbr_classes;
        private int subs_dept = 1;
        private int subs_clinic = 2;
        private int subs_class_total;
        private int subs_print_classes;
        private int hold_dept;
        private string hold_class_code;
        private string hold_doc_nbr;
        private string hold_oma_cd;
        private string hold_oma_cd_ltr;
        private int ws_mtd_svc;
        private decimal ws_mtd_amt;
        private decimal ws_mtd_avg;
        private decimal ws_mtd_perc;
        private decimal ws_mtd_sum_next_level;
        private int ws_ytd_svc;
        private decimal ws_ytd_amt;
        private decimal ws_ytd_avg;
        private decimal ws_ytd_perc;
        private decimal ws_ytd_sum_next_level;
        private string ws_ohip_code_desc_lit = "OHIP  ----------OHIP CODE DESCRIPTION ---------------";
        private string ws_dept_lit = "DEPARTMENT CLASS TOTALS";
        private string ws_clinic_lit = "CLINIC CLASS TOTALS";
        private string ws_doc_name_inits;
        private string feedback_oma_fee_mstr;
        private string feedback_iconst_mstr;
        private string eof_doctor_mstr = "N";
        private string eof_work_file = "N";
        private string eof_dept_mstr = "N";
        private string eof_oma_mstr = "N";
        //private string common_status_file;
        private string status_cobol_doc_mstr = "0";
        private string status_cobol_parm_file = "0";
        private string status_cobol_dept_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_oma_mstr = "0";
        private string status_prt_file = "0";
        private string status_prt_file_one = "0";
        private string status_prt_file_summ = "0";
        private string status_prt_file_two = "0";
        private string flag_end_work_rec;
        private string flag_end_work_rec_y = "Y";
        private string flag_end_work_rec_n = "N";
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string flag_clinic_totals;
        private string flag_clinic_totals_y = "Y";
        private string flag_clinic_totals_n = "N";

        private string totals_grp;
        private string total_indiv_oma_cd_grp;
        private int total_indiv_oma_cd_mtd_svc;
        private decimal total_indiv_oma_cd_mtd_amt;
        private int total_indiv_oma_cd_ytd_svc;
        private decimal total_indiv_oma_cd_ytd_amt;
        private string total_ltr_grp;
        private int total_ltr_mtd_svc;
        private decimal total_ltr_mtd_amt;
        private int total_ltr_ytd_svc;
        private decimal total_ltr_ytd_amt;
        private string total_clinic_dept_grp;
        private int total_clinic_dept_mtd_svc;
        private decimal total_clinic_dept_mtd_amt;
        private int total_clinic_dept_ytd_svc;
        private decimal total_clinic_dept_ytd_amt;
        private string total_dept_doc_grp;
        private int total_dept_doc_mtd_svc;
        private decimal total_dept_doc_mtd_amt;
        private int total_dept_doc_ytd_svc;
        private decimal total_dept_doc_ytd_amt;
        private string total_class_grp;
        private int total_class_mtd_svc;
        private decimal total_class_mtd_amt;
        private int total_class_ytd_svc;
        private decimal total_class_ytd_amt;

        private string ws_class_codes_grp;
        private string[] ws_total_by_dept_clinic = new string[3];
        private string[,] ws_max_class_codes = new string[3, 17];
        private string[,] ws_class_code = new string[3, 17];
        private string[,] ws_class_code_desc = new string[3, 17];
        private int[,] ws_class_mtd_svc = new int[3, 17];
        private decimal[,] ws_class_mtd_amt = new decimal[3, 17];
        private int[,] ws_class_ytd_svc = new int[3, 17];
        private decimal[,] ws_class_ytd_amt = new decimal[3, 17];
        private string ws_xx = "  ";

        private string counters_grp;
        private int ctr_work_file_reads;
        //private int ctr_doc_mstr_reads;
        private int ctr_pages;
        private int ctr_report_pages;
        private int summ_ctr_pages;

        private string error_message_table_grp;
        private string error_messages_grp;
        /* private string filler = "invalid reply";
         private string filler = "NO PARAMETER FILE SUPPLIED";
         private string filler = "NO SORT WORK FILE FOUND";
         private string filler = "INVALID WRITE TO PARAMETER FILE";
         private string filler = "INVALID PARAMETER STATUS";
         private string filler = "CONSTANTS MASTER READ ERROR";
         private string filler = "TOO MANY CLASS CODES FOUND";
         private string filler = "DEPARMENT MASTER RECORD NOT FOUND";
         private string filler = "*** CAN BE RE-USED ***";
         private string filler = "*** CAN BE RE-USED ***";
         private string filler = "*** CAN BE RE-USED ***";
         private string filler = "*** CAN BE RE-USED ***";
         private string filler = "*** CAN BE RE-USED ***";
         private string filler = "*** CAN BE RE-USED ***"; */
        private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "NO PARAMETER FILE SUPPLIED" , "NO SORT WORK FILE FOUND" , "INVALID WRITE TO PARAMETER FILE" , "INVALID PARAMETER STATUS" , "CONSTANTS MASTER READ ERROR" ,
                                        "TOO MANY CLASS CODES FOUND", "DEPARMENT MASTER RECORD NOT FOUND","*** CAN BE RE-USED ***","*** CAN BE RE-USED ***","*** CAN BE RE-USED ***","*** CAN BE RE-USED ***","*** CAN BE RE-USED ***",
                                        "*** CAN BE RE-USED ***" };

        //private string err_msg_comment_grp;
        private string err_msg_key_type;
        private string err_msg_key;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

        //private string h1_head_grp;
        private string h1_report_nbr;
        //private string filler = "/";
        private int h1_clinic_nbr;
        //private string filler = "";
        //private string filler = "P.E.D.";
        private string h1_ped_grp;
        private int h1_ped_yy;
        //private string filler = "/";
        private int h1_ped_mm;
        //private string filler = "/";
        private int h1_ped_dd;
        //private string filler = "";
        private string h1_title;
        //private string filler = "run date:";
        private string h1_run_date_grp;
        private int h1_run_date_yy;
        //private string filler = "/";
        private int h1_run_date_mm;
        //private string filler = "/";
        private int h1_run_date_dd;
        //private string filler = "";
        //private string filler = "PAGE";
        private int h1_page_nbr;
        //private string filler = "/";
        private int h1_report_page_nbr;

        //private string summ_head_grp;
        private string summ_report_nbr;
        //private string filler = "/";
        private int summ_clinic_nbr;
        //private string filler = "";
        //private string filler = "P.E.D.";
        private string summ_ped_grp;
        private int summ_ped_yy;
        //private string filler = "/";
        private int summ_ped_mm;
        //private string filler = "/";
        private int summ_ped_dd;
        //private string filler = "";
        private string summ_title;
        //private string filler = "run date:";
        private string summ_run_date_grp;
        private int summ_run_date_yy;
        //private string filler = "/";
        private int summ_run_date_mm;
        //private string filler = "/";
        private int summ_run_date_dd;
        //private string filler = "";
        //private string filler = "PAGE";
        private int summ_page_nbr;

        //private string h2_head_grp;
        //private string filler = "";
        private string h2_clinic_name;
        //private string filler = "";

        //private string h2a_head_grp;
        //private string filler = 'DOCTOR';
        private string h2a_doc_nbr;
        //private string filler = "";
        private string h2a_doc_name_inits;

        //private string h3_head_grp;
        //private string filler = "";
        //private string filler = "----------- M . T . D . -----------   -------------- Y . T . D . ------------";

        //private string h4_head_grp;
        //private string filler = "";
        //private string filler = "SVC    $ AMT      $ AVG    PERCENT";
        //private string filler = "SVC     $ AMT       $ AVG    PERCENT";

        //private string h5_head_grp;
        private string h5_ohip_code_desc_lit = "";
        private string h5_doc_dept_lit = "";
        private string h5_doc_dept_lit2 = "";

        //private string h6_head_grp;
        //private string filler = "";
        //private string filler = "dept #";
        private int h6_dept_nbr;
        //private string filler = " - ";
        private string h6_dept_name;

        //private string h7_head_grp;
        //private string filler = "";
        //private string filler = "CLASS";
        private string h7_class;
        //private string filler = "- ";
        private string h7_class_desc;

        //private string h8_head_grp;
        private string h8_total_lit;

        //private string print_line_grp;
        private string l1_print_line_grp;
        private string l1_oma_cd;
        private string l1_desc;
        private int l1_mtd_svc;
        private string filler;
        private decimal l1_mtd_amt;
        //private string filler;
        private decimal l1_mtd_avg;
        private decimal l1_mtd_perc;
        private string l1_mtd_perc_sign;
        private int l1_ytd_svc;
        //private string filler;
        private decimal l1_ytd_amt;
        //private string filler;
        private decimal l1_ytd_avg;
        private decimal l1_ytd_perc;
        private string l1_ytd_perc_sign;
        //private string l2_print_line_grp;
        private string l2_ltr;
        private string l2_dashes;
        private string l2_total_lit;
        private int l2_mtd_svc;
        //private string filler;
        private decimal l2_mtd_amt;
        //private string filler;
        private decimal l2_mtd_avg;
        private decimal l2_mtd_perc;
        private string l2_mtd_perc_sign;
        private int l2_ytd_svc;
        //private string filler;
        private decimal l2_ytd_amt;
        //private string filler;
        private decimal l2_ytd_avg;
        private decimal l2_ytd_perc;
        private string l2_ytd_perc_sign;
        //private string t1_print_line_grp;
        private string t1_doc_lit;
        private string t1_doc_nbr;
        //private string filler;
        private string t1_total_lit;
        private int t1_mtd_svc;
        //private string filler;
        private decimal t1_mtd_amt;
        //private string filler;
        private decimal t1_mtd_avg;
        private decimal t1_mtd_perc;
        private string t1_mtd_perc_sign;
        private int t1_ytd_svc;
        //private string filler;
        private decimal t1_ytd_amt;
        //private string filler;
        private decimal t1_ytd_avg;
        private decimal t1_ytd_perc;
        private string t1_ytd_perc_sign;
        //private string t2_print_line_grp;
        private string t2_dept_lit;
        private string t2_class_code_r_grp;
        private string t2_class_code;
        private string t2_col;
        private string t2_class_code_desc;
        private int t2_mtd_svc;
        //private string filler;
        private decimal t2_mtd_amt;
        //private string filler;
        private decimal t2_mtd_avg;
        private decimal t2_mtd_perc;
        private string t2_mtd_perc_sign;
        private int t2_ytd_svc;
        //private string filler;
        private decimal t2_ytd_amt;
        //private string filler;
        private decimal t2_ytd_avg;
        private decimal t2_ytd_perc;
        private string t2_ytd_perc_sign;
        //private string t3_print_line_grp;
        private string t3_dept_lit;
        private int t3_mtd_svc;
        //private string filler;
        private decimal t3_mtd_amt;
        //private string filler;
        private decimal t3_mtd_avg;
        private decimal t3_mtd_perc;
        private string t3_mtd_perc_sign;
        private int t3_ytd_svc;
        //private string filler;
        private decimal t3_ytd_amt;
        //private string filler;
        private decimal t3_ytd_avg;
        private decimal t3_ytd_perc;
        private string t3_ytd_perc_sign;
        //private string t4_print_line_grp;
        private string t4_clinic_lit;
        private int t4_mtd_svc;
        //private string filler;
        private decimal t4_mtd_amt;
        //private string filler;
        private decimal t4_mtd_avg;
        private decimal t4_mtd_perc;
        private string t4_mtd_perc_sign;
        private int t4_ytd_svc;
        //private string filler;
        private decimal t4_ytd_amt;
        //private string filler;
        private decimal t4_ytd_avg;
        private decimal t4_ytd_perc;
        private string t4_ytd_perc_sign;

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

        private string high_value = "F";

        private string endOfJob = "End of Job";
        private int ctr;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "24",Col = 20,Data1 = "PROGRAM R051C IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 20,Data1 = "NBR OF DOCTOR-MSTR ACCESSESS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_doc_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "15",Col = 20,Data1 = "NBR OF WORK-FILE REC READ = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "15",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_work_file_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM R051C ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-rpt1.",Line = "22",Col = 20,Data1 = "PRINT REPORT1 IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-rpt1.",Line = "22",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_one",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-rpt2.",Line = "22",Col = 20,Data1 = "PRINT REPORT2 IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-rpt2.",Line = "22",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_two",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private void err_doc_mstr()
        {

            common_status_file = status_cobol_doc_mstr;
            common_status_file = status_cobol_doc_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING DOCTOR MASTER".;
        }

        private void err_dept_mstr_file_section()
        {

            //     use after standard error procedure on dept-mstr.;
        }

        private void err_dept_mstr()
        {

            common_status_file = status_cobol_dept_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING DEPARTMENT MASTER".;
        }

        private void err_iconst_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_iconst_mstr()
        {

            common_status_file = status_cobol_iconst_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
        }

        private void err_oma_fee_mstr_file_section()
        {

            //     use after standard error procedure on oma-fee-mstr.;
        }

        private void err_oma_fee_mstr()
        {

            common_status_file = status_cobol_oma_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING OMA FEE MASTER".;
        }

        private void err_print_file_one_section()
        {

            //     use after standard error procedure on print-file-one.;
        }

        private void err_file_one()
        {

            common_status_file = status_prt_file_one;
            //     display file-status-display.;
            //     stop "ERROR ON PRINT FILE ONE (R051CA)".;
        }

        private void err_print_file_summ_section()
        {

            //     use after standard error procedure on print-file-summ.;
        }

        private void err_file_summ()
        {

            common_status_file = status_prt_file_summ;
            //     display file-status-display.;
            //     stop "ERROR ON PRINT FILE SUMM (R051CA_SUMM)".;
        }

        private void err_print_file_two_section()
        {

            //     use after standard error procedure on print-file-two.;
        }

        private void err_file_two()
        {

            common_status_file = status_prt_file_two;
            //     display file-status-display.;
            //     stop "ERROR ON PRINT FILE TWO (R051CB)".;
        }

        private void end_declaratives()
        {

        }

        private void main_line_section()
        {

        }

        public void mainline()
        {            
            try
            {

                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objFee_mstr_rec = new F040_OMA_FEE_MSTR();
                Fee_mstr_rec_Collection = new ObservableCollection<F040_OMA_FEE_MSTR>();

                objDept_mstr_rec = new F070_DEPT_MSTR();
                Dept_mstr_rec_Collection = new ObservableCollection<F070_DEPT_MSTR>();

                objIconst_mstr_rec = new ICONST_MSTR_REC();
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objConstants_mstr_rec_4 = new CONSTANTS_MSTR_REC_4();
                Constants_mstr_rec_4_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_4>();

                objWork_file_rec = new r051_work_rec();
                Work_file_rec_Collection = Read_R051_Sort_Work_Mstr();

                /*
               Work_file_rec_Collection.Clear();
                foreach (var obj in Read_R051_Sort_Work_Mstr().Where(x => x.wf_doc_nbr == "59N"))   //"01N")) // debugging only.
                {
                    Work_file_rec_Collection.Add(obj);
                } */

                objParm_file_rec = new Parm_file_rec();
                Parm_file_rec_Collection = Read_R051_parm_file();

                objParm_file_rec = Parm_file_rec_Collection.FirstOrDefault();

                if (objParm_file_rec == null)
                    objParm_file_rec = new Parm_file_rec();

                if (Util.NumInt(objParm_file_rec.Parm_status) < 3)
                {

                    objPrint_record_one = new ReportPrint(Directory.GetCurrentDirectory() + "\\r051ca");                    
                    objPrint_record_summ = new ReportPrint(Directory.GetCurrentDirectory() + "\\r051ca_summ");
                }

                objPrint_record_two = new ReportPrint(Directory.GetCurrentDirectory() + "\\r051cb");

                // perform aa0-initialization           thru aa0-99-exit.;
                aa0_initialization();
                aa0_99_exit();
               

                if (Util.NumInt(objParm_file_rec.Parm_status) == 1)
                {
                    //  perform ab0-process-r051ca      thru ab0-99-exit;
                    //                 until flag-end-work-rec-y;

                    do
                    {
                        ab0_process_r051ca();
                        ab0_10_check_rec();
                        ab0_99_exit();
                    } while (!Util.Str(flag_end_work_rec).ToUpper().Equals(flag_end_work_rec_y));

                }
                else if (Util.NumInt( objParm_file_rec.Parm_status) == 3)
                {
                    //         perform ad0-process-r051cb  thru ad0-99-exit;
                    //                 until flag-end-work-rec-y;

                    do
                    {
                        ad0_process_r051cb();
                        ad0_10_check_rec();
                        ad0_99_exit();
                    } while (!Util.Str(flag_end_work_rec).ToUpper().Equals(flag_end_work_rec_y));
                }
                else
                {
                    err_ind = 5;
                    //  perform za0-common-error    thru za0-99-exit;
                    za0_common_error();
                    za0_99_exit();

                    //  go to az0-10-end-of-job.;
                    az0_10_end_of_job();
                    return;
                }

                // perform az0-end-of-job                thru az0-99-exit.;
                az0_end_of_job();
                az0_10_end_of_job();
                az0_99_exit();
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
                if (objPrint_record_summ != null)
                    objPrint_record_summ.Close();

                if (objPrint_record_one != null)
                    objPrint_record_one.Close();

                if (objPrint_record_two != null)
                    objPrint_record_two.Close();
            }

            //     stop run.;
        }

        private void aa0_initialization()
        {            

            //     accept sys-date                        from    date.;
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

            run_mm = sys_mm;
            summ_run_date_mm = sys_mm;
            h1_run_date_mm = sys_mm;

            run_dd = sys_dd;
            summ_run_date_dd = sys_dd;
            h1_run_date_dd = sys_dd;

            run_yy = sys_yy;
            summ_run_date_yy = sys_yy;
            h1_run_date_yy = sys_yy;

            //     accept sys-time                      from    time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;

            //     display program-in-progress.;
            Console.WriteLine("PROGRAM R051C IN PROGRESS");

            //     open input  r051-work-file;
            //           dept-mstr;
            //                oma-fee-mstr;
            //             iconst-mstr;
            //              doc-mstr.;
            //     open i-o   parameter-file.;

            flag_clinic_totals = "N";
            objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 4;

            //  read iconst-mstr;
            //       invalid key;
            //         err_ind = 6;
            //         perform za0-common-error    thru    za0-99-exit;
            //          go to az0-10-end-of-job.;

            objConstants_mstr_rec_4 = new CONSTANTS_MSTR_REC_4
            {
                WhereConst_rec_nbr = 4
            }.Collection().FirstOrDefault();

            if (objConstants_mstr_rec_4 == null)
            {
                err_ind = 6;
                //  perform za0-common-error    thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //  go to az0-10-end-of-job.;
                az0_10_end_of_job();
                return;
            }

            subs_dept_clinic = 1;

            // perform xs0-clear-class-tbl                thru    xs0-99-exit;
            //      varying subs from 1 by 1;
            //         until subs > const-nbr-classes + 1.;

            subs = 1;
            do
            {
                xs0_clear_class_tbl();
                xs0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1);


            subs_dept_clinic = 2;

            //     perform xs0-clear-class-tbl                thru    xs0-99-exit;
            //      varying subs from 1 by 1;
            //         until subs > const-nbr-classes + 1.;

            subs = 1;
            do
            {
                xs0_clear_class_tbl();
                xs0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1);

            //counters = 0;
            ctr_work_file_reads = 0;
            ctr_doc_mstr_reads = 0;
            ctr_pages = 0;
            ctr_report_pages = 0;
            summ_ctr_pages = 0;

            //totals = 0;
            total_indiv_oma_cd_grp = "";
            total_indiv_oma_cd_mtd_svc = 0;
            total_indiv_oma_cd_mtd_amt = 0;
            total_indiv_oma_cd_ytd_svc = 0;
            total_indiv_oma_cd_ytd_amt = 0;
            total_ltr_grp = "";
            total_ltr_mtd_svc = 0;
            total_ltr_mtd_amt = 0;
            total_ltr_ytd_svc = 0;
            total_ltr_ytd_amt = 0;
            total_clinic_dept_grp = "";
            total_clinic_dept_mtd_svc = 0;
            total_clinic_dept_mtd_amt = 0;
            total_clinic_dept_ytd_svc = 0;
            total_clinic_dept_ytd_amt = 0;
            total_dept_doc_grp = "";
            total_dept_doc_mtd_svc = 0;
            total_dept_doc_mtd_amt = 0;
            total_dept_doc_ytd_svc = 0;
            total_dept_doc_ytd_amt = 0;
            total_class_grp = "";
            total_class_mtd_svc = 0;
            total_class_mtd_amt = 0;
            total_class_ytd_svc = 0;
            total_class_ytd_amt = 0;


            ctr_pages = 1;
            ctr_report_pages = 1;
            summ_ctr_pages = 1;
            subs_dept_clinic = 1;
            subs_max_nbr_classes = 1;
            subs_class_code = 1;

            //print_line = "";
            initialize_print_line_grp();
            
            //objWork_file_rec.work_file_rec = "";

            //  perform xc0-read-work-rec             thru    xc0-99-exit.;
            xc0_read_work_rec();
            xc0_99_exit();

            // if flag-end-work-rec-y then;            
            if (Util.Str(flag_end_work_rec).ToUpper().Equals(flag_end_work_rec_y))
            {
                err_ind = 3;
                //  perform za0-common-error        thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //        go to az0-10-end-of-job;
                az0_10_end_of_job();
                return;
            }
            else
            {
                hold_dept = objWork_file_rec.wf_dept;
                hold_class_code = objWork_file_rec.wf_class_code;
                ws_class_code[subs_dept_clinic, subs_class_code] = objWork_file_rec.wf_class_code;
                hold_doc_nbr = objWork_file_rec.wf_doc_nbr;
                hold_oma_cd = objWork_file_rec.wf_oma_cd;
                hold_oma_cd_ltr = objWork_file_rec.wf_oma_code_ltr;
            }


            parm_rec_nbr = 1;

            //  read parameter-file;
            //       invalid key;
            //          err_ind = 2;
            //          perform za0-common-error    thru    za0-99-exit;
            //          go to az0-10-end-of-job.;

            if (Parm_file_rec_Collection.Count() > 0)
            {
                objParm_file_rec = Parm_file_rec_Collection.FirstOrDefault();
            }
            else
            {
                err_ind = 2;
                // perform za0-common-error    thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to az0-10-end-of-job.;
                az0_10_end_of_job();
                return;
            }


            h1_clinic_nbr = Util.NumInt(objParm_file_rec.Parm_clinic_nbr);
            summ_clinic_nbr = Util.NumInt(objParm_file_rec.Parm_clinic_nbr);

            h2_clinic_name = objParm_file_rec.Parm_clinic_name;
            h1_ped_yy = objParm_file_rec.Parm_ped_yy;
            summ_ped_yy = objParm_file_rec.Parm_ped_yy;

            h1_ped_mm = objParm_file_rec.Parm_ped_mm;
            summ_ped_mm = objParm_file_rec.Parm_ped_mm;

            h1_ped_dd = objParm_file_rec.Parm_ped_dd;
            summ_ped_dd = objParm_file_rec.Parm_ped_dd;

            // if parm-status = 1 then;            
            if (objParm_file_rec.Parm_status == 1)
            {
                //      open output print-file-one;
                //      open output print-file-summ;
                h1_report_nbr = print_file_name_one;
                summ_report_nbr = print_file_name_summ;
            }
            // else if parm-status = 3 then;            
            else if (objParm_file_rec.Parm_status == 3)
            {
                //         open output print-file-two;
                         h1_report_nbr = print_file_name_two;
            }
            else
            {
                err_ind = 5;
                //   perform za0-common-error    thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to az0-10-end-of-job.;
                az0_10_end_of_job();
                return;
            }

            h5_ohip_code_desc_lit = ws_ohip_code_desc_lit;
        }

        private void aa0_99_exit()
        {            

            //     exit.;
        }

        private void az0_end_of_job()
        {            

            //     perform ba0-oma-cd-break         thru ba0-99-exit.;
            ba0_oma_cd_break();
            ba0_99_exit();

            flag_clinic_totals = "Y";

            // if parm-status = 1 then;            
            if (objParm_file_rec.Parm_status == 1)
            {
                //  perform da0-doc-nbr-break       thru da0-99-exit;
                da0_doc_nbr_break();
                da0_99_exit();

                //  perform fa0-dept-break          thru fa0-99-exit;
                fa0_dept_break();
                fa0_99_exit();

                //      close print-file-one;
                //      close print-file-summ;
            }
            else
            {
                ws_mtd_sum_next_level = total_class_mtd_amt;
                ws_ytd_sum_next_level = total_class_ytd_amt;
                subs_print_classes = subs_class_code;
                //  perform la1-print-totals        thru la1-99-exit;
                la1_print_totals();
                la1_99_exit();

                //  perform ea0-dept-break-b        thru ea0-99-exit;
                ea0_dept_break_b();
                ea0_99_exit();

                subs_dept_clinic = 2;
                h8_total_lit = ws_clinic_lit;

                h5_doc_dept_lit = "OF CLINIC";
                h5_doc_dept_lit2 = "OF CLINIC";

                subs_max_nbr_classes = subs_present_nbr_classes;
                //  perform la0-class-totals        thru la0-99-exit;
                la0_class_totals();
                la0_10_check_code();
                la0_99_exit();

                //  perform az3-print-total-clinic  thru az3-99-exit;
                az3_print_total_clinic();
                az3_99_exit();

                //  close print-file-two.;
            }

            //     add 1                        to parm-status.;
            objParm_file_rec.Parm_status++;

            objParm_file_rec.Parm_program_nbr = "R051C";

            //     rewrite parm-file-rec;
            //              invalid key;
            //              err_ind = 4;
            //              perform za0-common-error    thru za0-99-exit.;

            Update_R051_Parm_File(Parm_file_rec_Collection, false);

            //     display blank-screen.;

            //     accept sys-time                   from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            //     display scr-closing-screen.;
            Console.WriteLine("NBR OF DOCTOR-MSTR ACCESSESS = " + ctr_doc_mstr_reads);
            Console.WriteLine("");
            Console.WriteLine("NBR OF WORK - FILE REC READ = " + ctr_work_file_reads);
            Console.WriteLine("");
            Console.WriteLine("PROGRAM R051C ENDING" + sys_yy + "/" + sys_mm + "/" + sys_dd + sys_hrs + ":" + sys_min);

            //  if parm-status = 2 then;            
            if (objParm_file_rec.Parm_status == 2)
            {
                //      display scr-closing-rpt1;
                Console.WriteLine("PRINT REPORT1 IS IN FILE - " + print_file_name_one);
            }
            else
            {
                //     display scr-closing-rpt2.;
                Console.WriteLine("PRINT REPORT2 IS IN FILE - " + print_file_name_two);
            }
        }

        private void az0_10_end_of_job()
        {            

            //     close r051-work-file;
            //       parameter-file;
            //           oma-fee-mstr;
            //     dept-mstr;
            //        iconst-mstr;
            //      doc-mstr.;
            //     stop run.;
            new Exception(endOfJob);
        }

        private void az0_99_exit()
        {            

            //     exit.;
        }

        private void az3_print_total_clinic()
        {            

            ws_mtd_svc = total_clinic_dept_mtd_svc;
            ws_mtd_amt = total_clinic_dept_mtd_amt;
            ws_ytd_svc = total_clinic_dept_ytd_svc;
            ws_ytd_amt = total_clinic_dept_ytd_amt;

            // perform xd0-calc-avg-perc             thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            //move "** CLINIC GRAND TOTALS **"   to t4-clinic - lit.
            t4_clinic_lit = "** CLINIC GRAND TOTALS **";

            t4_mtd_svc = total_clinic_dept_mtd_svc;
            t4_mtd_amt = total_clinic_dept_mtd_amt;
            t4_ytd_svc = total_clinic_dept_ytd_svc;
            t4_ytd_amt = total_clinic_dept_ytd_amt;

            t4_mtd_avg = ws_mtd_avg;
            t4_mtd_perc = ws_mtd_perc;
            t4_ytd_avg = ws_ytd_avg;
            t4_ytd_perc = ws_ytd_perc;

            // if ws-mtd-perc < zero then;            
            if (ws_mtd_perc < 0)
            {
                t4_mtd_perc_sign = "-";
            }
            else
            {
                t4_mtd_perc_sign = "%";
            }

            // if ws-ytd-perc < zero   then;           
            if (ws_ytd_perc < 0)
            {
                t4_ytd_perc_sign = "-";
            }
            else
            {
                t4_ytd_perc_sign = "%";
            }

            nbr_of_lines_to_print = 2;

            //     perform xf0-write-print-line-b     thru xf0-99-exit.;
            xf0_write_print_line_b(4);
            xf0_99_exit();
        }

        private void az3_99_exit()
        {            

            //     exit.;
        }

        private void ab0_process_r051ca()
        {            

            // if hold-dept not = wf-dept then;            
            if (hold_dept != objWork_file_rec.wf_dept)
            {
                //  perform ba0-oma-cd-break        thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();

                // perform da0-doc-nbr-break       thru da0-99-exit;
                da0_doc_nbr_break();
                da0_99_exit();

                ws_mtd_sum_next_level = total_clinic_dept_mtd_amt;
                ws_ytd_sum_next_level = total_clinic_dept_ytd_amt;
                //  perform fa0-dept-break          thru fa0-99-exit;
                fa0_dept_break();
                fa0_99_exit();

                ctr_lines = 70;
                ctr_pages = 1;
                subs_class_code = 1;
                subs_max_nbr_classes = 1;
                h5_ohip_code_desc_lit = ws_ohip_code_desc_lit;
            }
            // else if hold-doc-nbr not = wf-doc-nbr then;            
            else if (hold_doc_nbr != objWork_file_rec.wf_doc_nbr)
            {
                //   perform ba0-oma-cd-break    thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();

                //  perform da0-doc-nbr-break   thru da0-99-exit;
                da0_doc_nbr_break();
                da0_99_exit();

                //  perform na0-check-class-code thru na0-99-exit;
                na0_check_class_code();
                na0_99_exit();

                ctr_lines = 70;
                ctr_pages = 1;
                h5_ohip_code_desc_lit = ws_ohip_code_desc_lit;
            }
            // else if hold-oma-cd-ltr not = wf-oma-code-ltr then;            
            else if (hold_oma_cd_ltr != objWork_file_rec.wf_oma_code_ltr)
            {
                //  perform ba0-oma-cd-break thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();
            }
            // else if hold-oma-cd not = wf-oma-cd   then;            
            else if (hold_oma_cd != objWork_file_rec.wf_oma_cd)
            {
                //  perform ba0-oma-cd-break thru ba0-99-exit;                
                ba0_oma_cd_break();
                ba0_99_exit();
            }
            else
            {
                // next sentence.;
            }
        }

        private void ab0_10_check_rec()
        {            

            reprocess:
            

            //  if wf-dept = zero then;            
            if (objWork_file_rec.wf_dept == 0)
            {
                //  perform xc0-read-work-rec       thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();
                //  go to ab0-10-check-rec;
                //ab0_10_check_rec();
                if (Util.Str(flag_end_work_rec).ToUpper() != "Y")
                {
                    goto reprocess;
                }                
                return;
            }
            //  else if wf-class-code = zero  then;            
            else if (objWork_file_rec.wf_class_code == "0")
            {
                //   perform xt0-new-dept-head   thru xt0-99-exit;
                xt0_new_dept_head();
                xt0_99_exit();

                //   perform xp0-clinic-dept-total-rec thru xp0-99-exit;
                xp0_clinic_dept_total_rec();
                xp0_99_exit();

                //   perform xc0-read-work-rec   thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                //   go to ab0-10-check-rec;
                //ab0_10_check_rec();
                goto reprocess;
                return;
            }
            //  else if wf-doc-nbr = zero  then;            
            else if ( Util.Str(objWork_file_rec.wf_doc_nbr) == "000")
            {
                //  perform xu0-new-class-head thru xu0-99-exit;
                xu0_new_class_head();
                xu0_10_get_desc();
                xu0_99_exit();

                //  perform xr0-class-tot-rec thru xr0-99-exit;
                xr0_class_tot_rec();
                xr0_99_exit();

                //  perform xc0-read-work-rec thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                // go to ab0-10-check-rec;
                //ab0_10_check_rec();
                goto reprocess;
                return;
            }
            //  else if wf-oma-cd = zero then;            
            else if (objWork_file_rec.wf_oma_code_ltr == "0")
            {
                //  perform xq0-dept-doc-total-rec thru xq0-99-exit;
                xq0_dept_doc_total_rec();
                xq0_99_exit();

                //   perform xc0-read-work-rec  thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                //  go to ab0-10-check-rec;
                //ab0_10_check_rec();
                goto reprocess;
                return;
            }
            else
            {
                //                 next sentence.;
            }

            //  perform ja0-process-work-rec  thru ja0-99-exit.;
            ja0_process_work_rec();
            ja0_99_exit();

            hold_dept = objWork_file_rec.wf_dept;
            hold_class_code = objWork_file_rec.wf_class_code;
            ws_class_code[subs_dept_clinic, subs_class_code] = objWork_file_rec.wf_class_code;

            hold_doc_nbr = objWork_file_rec.wf_doc_nbr;
            hold_oma_cd = objWork_file_rec.wf_oma_cd;
            hold_oma_cd_ltr = objWork_file_rec.wf_oma_code_ltr;

            //  perform xc0-read-work-rec        thru xc0-99-exit.;
            xc0_read_work_rec();
            xc0_99_exit();
        }

        private void ab0_99_exit()
        {            

            //     exit.;
        }

        private void ad0_process_r051cb()
        {            

            // if hold-dept not = wf-dept then;            
            if (hold_dept != objWork_file_rec.wf_dept)
            {
                //  perform ba0-oma-cd-break        thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();

                ws_mtd_sum_next_level = total_class_mtd_amt;
                ws_ytd_sum_next_level = total_class_ytd_amt;
                subs_print_classes = subs_class_code;
                //  perform la1-print-totals        thru la1-99-exit;
                la1_print_totals();
                la1_99_exit();

                //  perform ea0-dept-break-b        thru ea0-99-exit;
                ea0_dept_break_b();
                ea0_99_exit();

                //  perform xs0-clear-class-tbl     thru xs0-99-exit;
                //                 varying subs from 1 by 1;
                //                 until subs > const-nbr-classes + 1;

                subs = 1;
                do
                {
                    xs0_clear_class_tbl();
                    xs0_99_exit();
                    subs++;
                } while (subs <= (objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1));  // todo: verify   objConstants_mstr_rec_4..???

                ctr_lines = 70;
                ctr_pages = 1;
                subs_class_code = 1;
                subs_max_nbr_classes = 1;
                h5_ohip_code_desc_lit = ws_ohip_code_desc_lit;
            }
            //   else if hold-class-code not = wf-class-code then;            
            else if (hold_class_code != objWork_file_rec.wf_class_code)
            {
                //  perform ba0-oma-cd-break    thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();

                //  perform la3-bump-totals     thru la3-99-exit;
                la3_bump_totals();
                la3_99_exit();

                ws_mtd_sum_next_level = total_class_mtd_amt;
                ws_ytd_sum_next_level = total_class_ytd_amt;
                subs_print_classes = subs_class_code;
                //  perform la1-print-totals    thru la1-99-exit;
                la1_print_totals();
                la1_99_exit();

                subs_class_code++;
                subs_max_nbr_classes++;
                ctr_lines = 70;
                ctr_pages = 1;
                h5_ohip_code_desc_lit = ws_ohip_code_desc_lit;
            }
            //  else if hold-oma-cd-ltr not = wf-oma-code-ltr then;     
            else if (hold_oma_cd_ltr != objWork_file_rec.wf_oma_code_ltr)
            {
                //  perform ba0-oma-cd-break thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();
            }
            //   else if hold-oma-cd not = wf-oma-cd then;            
            else if (hold_oma_cd != objWork_file_rec.wf_oma_cd)
            {
                //  perform ba0-oma-cd-break thru ba0-99-exit;
                ba0_oma_cd_break();
                ba0_99_exit();
            }
            else
            {
                //                 next sentence.;
            }
        }

        private void ad0_10_check_rec()
        {            

            Process:
            

            // if wf-dept = zero then;            
            if (objWork_file_rec.wf_dept == 0)
            {
                //  perform xp0-clinic-dept-total-rec thru xp0-99-exit;
                xp0_clinic_dept_total_rec();
                xp0_99_exit();

                //  perform xc0-read-work-rec       thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                if (Util.Str(flag_end_work_rec).ToUpper().Equals("Y"))
                {
                    return; 
                }

                //  go to ad0-10-check-rec;                
                goto Process;                
            }
            // else if wf-class-code = zero then;            
            else if (objWork_file_rec.wf_class_code == "0")
            {
                //  perform xt0-new-dept-head   thru xt0-99-exit;
                xt0_new_dept_head();
                xt0_99_exit();

                //  perform xq0-dept-doc-total-rec  thru xq0-99-exit;
                xq0_dept_doc_total_rec();
                xq0_99_exit();

                //  perform xc0-read-work-rec   thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                //  go to ad0-10-check-rec;                
                goto Process;                
            }
            //  else if wf-doc-nbr = zero then;            
            else if (objWork_file_rec.wf_doc_nbr == "000")  //"0")
            {
                //  perform xu0-new-class-head thru xu0-99-exit;
                xu0_new_class_head();
                xu0_10_get_desc();
                xu0_99_exit();

                //  perform xr0-class-tot-rec thru xr0-99-exit;
                xr0_class_tot_rec();
                xr0_99_exit();

                //  perform xc0-read-work-rec  thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                //  go to ad0-10-check-rec;                
                goto Process;                                
            }
            // else if wf-oma-cd = zero;  then;            
            else if (objWork_file_rec.wf_oma_cd == "00000") //"0")
            {
                // perform xc0-read-work-rec  thru xc0-99-exit;
                xc0_read_work_rec();
                xc0_99_exit();

                // go to ad0-10-check-rec;
                goto Process;                
            }
            else
            {
                //                 next sentence.;
            }

            //  perform ja0-process-work-rec  thru ja0-99-exit.;
            ja0_process_work_rec();
            ja0_99_exit();

            hold_dept = objWork_file_rec.wf_dept;
            hold_class_code = objWork_file_rec.wf_class_code;
            ws_class_code[subs_dept_clinic, subs_class_code] = objWork_file_rec.wf_class_code;

            hold_oma_cd = objWork_file_rec.wf_oma_cd;
            hold_oma_cd_ltr = objWork_file_rec.wf_oma_code_ltr;

            // perform xc0-read-work-rec        thru xc0-99-exit.;
            xc0_read_work_rec();
            xc0_99_exit();
        }

        private void ad0_99_exit()
        {            

            //     exit.;
        }

        private void ba0_oma_cd_break()
        {            

            ws_mtd_svc = total_indiv_oma_cd_mtd_svc;
            ws_mtd_amt = total_indiv_oma_cd_mtd_amt;
            ws_ytd_svc = total_indiv_oma_cd_ytd_svc;
            ws_ytd_amt = total_indiv_oma_cd_ytd_amt;

            // if parm-status = 1 then;            
            if (objParm_file_rec.Parm_status == 1)
            {
                ws_mtd_sum_next_level = total_dept_doc_mtd_amt;
                ws_ytd_sum_next_level = total_dept_doc_ytd_amt;
            }
            else
            {
                ws_mtd_sum_next_level = total_class_mtd_amt;
                ws_ytd_sum_next_level = total_class_ytd_amt;
            }

            //  perform xd0-calc-avg-perc         thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            //  perform ba1-print-indiv-oma-cd-line        thru ba1-99-exit.;
            ba1_print_indiv_oma_cd_line();
            ba1_99_exit();

            //  perform ba3-clear-indiv-totals     thru ba3-99-exit.;
            ba3_clear_indiv_totals();
            ba3_99_exit();
        }

        private void ba0_99_exit()
        {            

            //     exit.;
        }

        private void ba1_print_indiv_oma_cd_line()
        {            

            l1_oma_cd = hold_oma_cd;

            //move hold-oma - cd   to l1-oma - cd
            //                        fee-oma-cd.

            objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(hold_oma_cd).PadRight(5).Substring(0, 1);
            objFee_mstr_rec.FILLER_NUMERIC = Util.Str(hold_oma_cd).PadRight(5).Substring(1, 3);

            // perform xm0-access-oma-fee-mstr       thru xm0-99-exit.;
            xm0_access_oma_fee_mstr();
            xm0_99_exit();

            l1_desc = objFee_mstr_rec.FEE_DESC;
            l1_mtd_svc = total_indiv_oma_cd_mtd_svc;
            l1_mtd_amt = total_indiv_oma_cd_mtd_amt;
            l1_ytd_svc = total_indiv_oma_cd_ytd_svc;
            l1_ytd_amt = total_indiv_oma_cd_ytd_amt;
            l1_mtd_avg = ws_mtd_avg;
            l1_mtd_perc = ws_mtd_perc;
            l1_ytd_avg = ws_ytd_avg;
            l1_ytd_perc = ws_ytd_perc;

            if (ws_mtd_perc < 0)
            {
                if (Util.Str(ws_mtd_perc).PadRight(10).Substring(0, 8).Equals("-0.00000"))
                {
                    l1_mtd_perc_sign = "%";
                }
                else
                {
                    l1_mtd_perc_sign = "-";
                }
            }
            else
            {
                l1_mtd_perc_sign = "%";
            }

            if (ws_ytd_perc < 0)
            {
                if ( Util.Str(l1_ytd_perc).PadRight(10).Substring(0,8).Equals("-0.00000"))
                {
                    l1_ytd_perc_sign = "%";
                }
                else
                {
                    l1_ytd_perc_sign = "-";
                }
            }
            else
            {
                l1_ytd_perc_sign = "%";
            }

            nbr_of_lines_to_print = 1;

            //if parm-status = 1 then;
            if (objParm_file_rec.Parm_status == 1)
            {
                //perform xe0-write - print - line - a  thru xe0-99 - exit;
                xe0_write_print_line_a();
                xe0_99_exit();
            }
            else
            {
                //perform xf0-write - print - line - b  thru xf0-99 - exit.;
                xf0_write_print_line_b(1);
                xf0_99_exit();
            }
        }

        private void ba1_99_exit()
        {            

            //     exit.;
        }

        private void ba3_clear_indiv_totals()
        {            

            total_indiv_oma_cd_mtd_svc = 0;
            total_indiv_oma_cd_mtd_amt = 0;
            total_indiv_oma_cd_ytd_svc = 0;
            total_indiv_oma_cd_ytd_amt = 0;
        }

        private void ba3_99_exit()
        {            

            //     exit.;
        }

        private void da0_doc_nbr_break()
        {            

            ws_mtd_svc = total_dept_doc_mtd_svc;
            ws_mtd_amt = total_dept_doc_mtd_amt;
            ws_ytd_svc = total_dept_doc_ytd_svc;
            ws_ytd_amt = total_dept_doc_ytd_amt;
            ws_mtd_sum_next_level = total_dept_doc_mtd_amt;
            ws_ytd_sum_next_level = total_dept_doc_ytd_amt;

            // perform xd0-calc-avg-perc          thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            h5_doc_dept_lit = "   OF DOC";
            h5_doc_dept_lit2 = "   OF DOC";

            // perform da1-print-doc-total-line   thru da1-99-exit.;
            da1_print_doc_total_line();
            da1_99_exit();

            ws_mtd_sum_next_level = total_class_mtd_amt;
            ws_ytd_sum_next_level = total_class_ytd_amt;

            //  perform xd0-calc-avg-perc          thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            h5_doc_dept_lit = " OF CLASS";
            h5_doc_dept_lit2 = " OF CLASS";

            h5_ohip_code_desc_lit = "";

            // if summ-ctr-lines > summ-max-nbr-lines then;            
            //   perform xy0-headings-summ       thru xy0-99-exit.;

            if (summ_ctr_lines > summ_max_nbr_lines)
            {
                xy0_headings_summ();
                xy0_99_exit();
            }

            //  perform da2-print-doc-total-line  thru da2-99-exit.;
            da2_print_doc_total_line();
            da2_99_exit();
        }

        private void da0_99_exit()
        {            

            //     exit.;
        }

        private void da1_print_doc_total_line()
        {            

            t1_doc_lit = "DOCTOR";
            t1_doc_nbr = hold_doc_nbr;
            t1_total_lit = "TOTALS";
            t1_mtd_svc = total_dept_doc_mtd_svc;
            t1_mtd_amt = total_dept_doc_mtd_amt;
            t1_ytd_svc = total_dept_doc_ytd_svc;
            t1_ytd_amt = total_dept_doc_ytd_amt;
            t1_mtd_avg = ws_mtd_avg;
            t1_mtd_perc = ws_mtd_perc;
            t1_ytd_avg = ws_ytd_avg;
            t1_ytd_perc = ws_ytd_perc;

            if (ws_mtd_perc < 0)
            {
                t1_mtd_perc_sign = "-";
            }
            else
            {
                t1_mtd_perc_sign = "%";
            }

            if (ws_ytd_perc < 0)
            {
                t1_ytd_perc_sign = "-";
            }
            else
            {
                t1_ytd_perc_sign = "%";
            }

            nbr_of_lines_to_print = 2;
            ctr_lines = 0;

            // perform xe0-write-print-line-a thru xe0-99-exit.;
            xe0_write_print_line_a(3);
            xe0_99_exit();
        }
        private void da1_99_exit()
        {            

            //     exit.;
        }

        private void da2_print_doc_total_line()
        {            

            t1_doc_lit = "DOCTOR";
            t1_doc_nbr = hold_doc_nbr;
            objDoc_mstr_rec.DOC_NBR = hold_doc_nbr;

            //  perform xk0-access-doc-mstr              thru    xk0-99-exit.;
            xk0_access_doc_mstr();
            xk0_99_exit();

            //  perform xa1-doc-name-inits              thru    xa1-99-exit.;
            xa1_doc_name_inits();
            xa1_99_exit();

            t1_total_lit = ws_doc_name_inits;
            t1_mtd_svc = total_dept_doc_mtd_svc;
            t1_mtd_amt = total_dept_doc_mtd_amt;
            t1_ytd_svc = total_dept_doc_ytd_svc;
            t1_ytd_amt = total_dept_doc_ytd_amt;
            t1_mtd_avg = ws_mtd_avg;
            t1_mtd_perc = ws_mtd_perc;
            t1_ytd_avg = ws_ytd_avg;
            t1_ytd_perc = ws_ytd_perc;

            if (ws_mtd_perc < 0)
            {
                t1_mtd_perc_sign = "-";
            }
            else
            {
                t1_mtd_perc_sign = "%";
            }

            if (ws_ytd_perc < 0)
            {
                t1_ytd_perc_sign = "-";
            }
            else
            {
                t1_ytd_perc_sign = "%";
            }

            // write print-record-summ from print-line after advancing 2 lines.;
            
            objPrint_record_summ.print(true);
            objPrint_record_summ.print(t1_print_line_grp(), 1, true);

            //     add  2                             to summ-ctr-lines.;
            summ_ctr_lines += 2;

            //print_line = "";
            initialize_print_line_grp();
           
        }

        private void da2_99_exit()
        {            

            //     exit.;
        }

        private void ea0_dept_break_b()
        {            

            h8_total_lit = ws_dept_lit;
            h5_doc_dept_lit = "  OF DEPT";
            h5_doc_dept_lit2 = "  OF DEPT";

            h5_ohip_code_desc_lit = "";
            ws_mtd_sum_next_level = total_dept_doc_mtd_amt;
            ws_ytd_sum_next_level = total_dept_doc_ytd_amt;

            // perform la0-class-totals           thru la0-99-exit.;
            la0_class_totals();
            la0_10_check_code();
            la0_99_exit();

            ws_mtd_svc = total_dept_doc_mtd_svc;
            ws_mtd_amt = total_dept_doc_mtd_amt;
            ws_ytd_svc = total_dept_doc_ytd_svc;
            ws_ytd_amt = total_dept_doc_ytd_amt;

            // perform xd0-calc-avg-perc  thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            //  perform ea1-print-dept-total-line-b        thru ea1-99-exit.;
            ea1_print_dept_total_line_b();
            ea1_99_exit();

            h5_doc_dept_lit = "OF CLINIC";
            h5_doc_dept_lit2 = "OF CLINIC";

            ws_mtd_sum_next_level = total_clinic_dept_mtd_amt;
            ws_ytd_sum_next_level = total_clinic_dept_ytd_amt;

            // perform la0-class-totals           thru la0-99-exit.;
            la0_class_totals();
            la0_10_check_code();
            la0_99_exit();

            // if subs-dept-clinic = subs-dept then;      
            if (subs_dept_clinic == subs_dept)
            {
                //  perform la3-bump-totals         thru la3-99-exit.;
                la3_bump_totals();
                la3_99_exit();
            }

            ws_mtd_svc = total_dept_doc_mtd_svc;
            ws_ytd_svc = total_dept_doc_ytd_svc;
            ws_mtd_amt = total_dept_doc_mtd_amt;
            ws_ytd_amt = total_dept_doc_ytd_amt;
            ws_mtd_sum_next_level = total_clinic_dept_mtd_amt;
            ws_ytd_sum_next_level = total_clinic_dept_ytd_amt;

            //     perform xd0-calc-avg-perc          thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            //  perform ea1-print-dept-total-line-b        thru ea1-99-exit.;
            ea1_print_dept_total_line_b();
            ea1_99_exit();
        }

        private void ea0_99_exit()
        {            

            //     exit.;
        }

        private void ea1_print_dept_total_line_b()
        {            

            t3_dept_lit = "**DEPARTMENT TOTALS**";
            t3_mtd_svc = total_dept_doc_mtd_svc;
            t3_mtd_amt = total_dept_doc_mtd_amt;
            t3_ytd_svc = total_dept_doc_ytd_svc;
            t3_ytd_amt = total_dept_doc_ytd_amt;

            t3_mtd_avg = ws_mtd_avg;
            t3_mtd_perc = ws_mtd_perc;
            t3_ytd_avg = ws_ytd_avg;
            t3_ytd_perc = ws_ytd_perc;

            // if ws-mtd-perc < zero then;   
            if (ws_mtd_perc < 0)
            {
                t3_mtd_perc_sign = "-";
            }
            else
            {
                t3_mtd_perc_sign = "%";
            }

            if (ws_ytd_perc < 0)
            {
                t3_ytd_perc_sign = "-";
            }
            else
            {
                t3_ytd_perc_sign = "%";
            }

            if (ctr_lines > 56)
            {
                // perform xb0-headings-b          thru xb0-99-exit;
                xb0_headings_b();
                xb0_99_exit();

                nbr_of_lines_to_print = 2;
            }
            else
            {
                nbr_of_lines_to_print = 3;
            }

            ctr_lines = 0;
            //  perform xf0-write-print-line-b thru xf0-99-exit.;
            xf0_write_print_line_b(3);
            xf0_99_exit();
        }

        private void ea1_99_exit()
        {            

            //     exit.;
        }

        private void fa0_dept_break()
        {            

            h8_total_lit = ws_dept_lit;
            h5_doc_dept_lit = "  OF DEPT";
            h5_doc_dept_lit2 = "  OF DEPT";

            h5_ohip_code_desc_lit = "";

            //  perform la0-class-totals           thru la0-99-exit.;
            la0_class_totals();
            la0_10_check_code();
            la0_99_exit();

            //     perform xs0-clear-class-tbl             thru xs0-99-exit;
            //         varying subs from 1 by 1;
            //         until   subs > const-nbr-classes + 1.;

            subs = 1;
            do
            {
                xs0_clear_class_tbl();
                xs0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1); // verify...


            ws_mtd_svc = total_clinic_dept_mtd_svc;
            ws_mtd_amt = total_clinic_dept_mtd_amt;
            ws_ytd_svc = total_clinic_dept_ytd_svc;
            ws_ytd_amt = total_clinic_dept_ytd_amt;
            ws_mtd_sum_next_level = total_clinic_dept_mtd_amt;
            ws_ytd_sum_next_level = total_clinic_dept_ytd_amt;

            // perform xd0-calc-avg-perc          thru xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            // perform fa1-print-dept-total-line  thru fa1-99-exit.;
            fa1_print_dept_total_line();
            fa1_99_exit();
        }

        private void fa0_99_exit()
        {            

            //     exit.;
        }

        private void fa1_print_dept_total_line()
        {            

            t2_dept_lit = "** DEPARTMENT TOTALS **";
            t2_mtd_svc = total_clinic_dept_mtd_svc;
            t2_mtd_amt = total_clinic_dept_mtd_amt;
            t2_ytd_svc = total_clinic_dept_ytd_svc;
            t2_ytd_amt = total_clinic_dept_ytd_amt;

            t2_mtd_avg = ws_mtd_avg;
            t2_mtd_perc = ws_mtd_perc;
            t2_ytd_avg = ws_ytd_avg;
            t2_ytd_perc = ws_ytd_perc;

            if (ws_mtd_perc < 0)
            {
                t2_mtd_perc_sign = "-";
            }
            else
            {
                t2_mtd_perc_sign = "%";
            }

            if (ws_ytd_perc < 0)
            {
                t2_ytd_perc_sign = "-";
            }
            else
            {
                t2_ytd_perc_sign = "%";
            }

            nbr_of_lines_to_print = 2;

            // perform xe0-write-print-line-a     thru xe0-99-exit.;
            xe0_write_print_line_a(4);
            xe0_99_exit();
        }

        private void fa1_99_exit()
        {            

            //     exit.;
        }

        private void ja0_process_work_rec()
        {            

            //     add wf-mtd-svcs          to total-indiv-oma-cd-mtd-svc;
            //                                       total-ltr-mtd-svc;
            //                                        ws-class-mtd-svc(subs-dept-clinic,subs-class-code).;

            total_indiv_oma_cd_mtd_svc += objWork_file_rec.wf_mtd_svcs;
            total_ltr_mtd_svc += objWork_file_rec.wf_mtd_svcs;
            ws_class_mtd_svc[subs_dept_clinic, subs_class_code] += objWork_file_rec.wf_mtd_svcs;


            //     add wf-mtd-amt                        to total-indiv-oma-cd-mtd-amt;
            //                                       total-ltr-mtd-amt;
            //                                       ws-class-mtd-amt(subs-dept-clinic,subs-class-code).;

            total_indiv_oma_cd_mtd_amt += Util.ConvertZoneToNumeric(objWork_file_rec.wf_mtd_amt);
            total_ltr_mtd_amt += Util.ConvertZoneToNumeric(objWork_file_rec.wf_mtd_amt);
            ws_class_mtd_amt[subs_dept_clinic, subs_class_code] += Util.ConvertZoneToNumeric(objWork_file_rec.wf_mtd_amt);

            //     add wf-ytd-svcs                       to total-indiv-oma-cd-ytd-svc;
            //                                       total-ltr-ytd-svc;
            //                                       ws-class-ytd-svc(subs-dept-clinic,subs-class-code).;

            total_indiv_oma_cd_ytd_svc += objWork_file_rec.wf_ytd_svcs;
            total_ltr_ytd_svc += objWork_file_rec.wf_ytd_svcs;
            ws_class_ytd_svc[subs_dept_clinic, subs_class_code] += objWork_file_rec.wf_ytd_svcs;

            //  add wf-ytd-amt    to total-indiv-oma-cd-ytd-amt;
            //                       total-ltr-ytd-amt;
            //                       ws-class-ytd-amt(subs-dept-clinic,subs-class-code).;

            decimal convertZoneValue = Util.ConvertZoneToNumeric(objWork_file_rec.wf_ytd_amt);

            if (convertZoneValue < 0 &&  Math.Abs(convertZoneValue).ToString().Length  == 1)
            {
                convertZoneValue = Util.AddDecimalPoint(convertZoneValue, 100);
            }

            if (total_indiv_oma_cd_ytd_amt != 0)
            {
                total_indiv_oma_cd_ytd_amt += Util.ConvertZoneToNumeric(objWork_file_rec.wf_ytd_amt);
            }
            else
            {
                total_indiv_oma_cd_ytd_amt += convertZoneValue;
            }

            total_ltr_ytd_amt += Util.ConvertZoneToNumeric(objWork_file_rec.wf_ytd_amt);
            ws_class_ytd_amt[subs_dept_clinic, subs_class_code] += Util.ConvertZoneToNumeric(objWork_file_rec.wf_ytd_amt);
        }

        private void ja0_99_exit()
        {            

            //     exit.;
        }

        private void la0_class_totals()
        {            

            //  if subs-dept-clinic = subs-clinic then;            
            if (subs_dept_clinic == subs_clinic)
            {
                h1_page_nbr = 1;
            }
            else
            {
                h1_page_nbr = ctr_pages;
            }

            h1_report_page_nbr = ctr_report_pages;

            //if parm-status = 1  then;            
            if (objParm_file_rec.Parm_status == 1)
            {
                //       write print-record-one from h1-head after   advancing page;
                
                objPrint_record_one.PageBreak();
                objPrint_record_one.print(h1_head_grp(), 1, true);

                //  write print-record-one from h2-head after   advancing 1 line;                
                objPrint_record_one.print(h2_head_grp(), 1, true);

                //         if flag-clinic-totals-y then;            
                if (flag_clinic_totals.ToUpper().Equals(flag_clinic_totals_y))
                {
                    //               write print-record-one from h8-head  after   advancing 2 lines;                    
                    objPrint_record_one.print(true);
                    objPrint_record_one.print(h8_head_grp(), 1, true);

                    //               write print-record-one from h3-head  after   advancing 2 lines;                    
                    objPrint_record_one.print(true);
                    objPrint_record_one.print(h3_head_grp(), 1, true);

                    //               write print-record-one from h4-head   after   advancing 1 line;                    
                    objPrint_record_one.print(h4_head_grp(), 1, true);

                    //               write print-record-one from h5-head  after   advancing 1 line;                    
                    objPrint_record_one.print(h5_head_grp(), 1, true);

                }
                else
                {
                    //               write print-record-one from h6-head after   advancing 2 lines;                    
                    objPrint_record_one.print(true);
                    objPrint_record_one.print(h6_head_grp(), 1, true);

                    //               write print-record-one from h8-head  after   advancing 2 lines;                    
                    objPrint_record_one.print(true);
                    objPrint_record_one.print(h8_head_grp(), 1, true);

                    //               write print-record-one from h3-head  after   advancing 2 lines;                    
                    objPrint_record_one.print(true);
                    objPrint_record_one.print(h3_head_grp(), 1, true);
                    //                                 
                    //               write print-record-one from h4-head   after   advancing 1 line;                    
                    objPrint_record_one.print(h4_head_grp(), 1, true);

                    //               write print-record-one from h5-head  after   advancing 1 line;                    
                    objPrint_record_one.print(h5_head_grp(), 1, true);
                }
            }
            else
            {
                //         write print-record-two from h1-head after   advancing page;                                
                objPrint_record_two.PageBreak();
                objPrint_record_two.print(h1_head_grp(), 1, true);

                //         write print-record-two from h2-head after   advancing 1 line;                
                objPrint_record_two.print(h2_head_grp(), 1, true);


                //         if flag-clinic-totals-y then;           
                if (flag_clinic_totals.ToUpper().Equals(flag_clinic_totals_y))
                {
                    //               write print-record-two from h8-head  after   advancing 2 lines;                    
                    objPrint_record_two.print(true);
                    objPrint_record_two.print(h8_head_grp(), 1, true);

                    //               write print-record-two from h3-head   after   advancing 2 lines;                    
                    objPrint_record_two.print(true);
                    objPrint_record_two.print(h3_head_grp(), 1, true);

                    //               write print-record-two from h4-head   after   advancing 1 line;                   
                    objPrint_record_two.print(h4_head_grp(), 1, true);

                    //               write print-record-two from h5-head    after   advancing 1 line;                    
                    objPrint_record_two.print(h5_head_grp(), 1, true);
                }
                else
                {
                    //               write print-record-two from h6-head   after   advancing 2 lines;                    
                    objPrint_record_two.print(true);
                    objPrint_record_two.print(h6_head_grp(), 1, true);

                    //               write print-record-two from h8-head   after   advancing 2 lines;                    
                    objPrint_record_two.print(true);
                    objPrint_record_two.print(h8_head_grp(), 1, true);

                    //               write print-record-two from h3-head    after   advancing 2 lines;                    
                    objPrint_record_two.print(true);
                    objPrint_record_two.print(h3_head_grp(), 1, true);

                    //               write print-record-two from h4-head   after   advancing 1 line;                    
                    objPrint_record_two.print(h4_head_grp(), 1, true);

                    //               write print-record-two from h5-head    after   advancing 1 line.;                    
                    objPrint_record_two.print(h5_head_grp(), 1, true);
                }
            }

            ctr_lines = 10;
            //     add 1                             to      ctr-pages.;
            ctr_pages++;
            //     add 1                             to      ctr-report-pages.;
            ctr_report_pages++;

            subs_print_classes = 1;
        }

        private void la0_10_check_code()
        {            

            // if subs-print-classes > subs-max-nbr-classes then;            
            if (subs_print_classes > subs_max_nbr_classes)
            {
                //    next sentence;
            }
            else
            {
                // perform la1-print-totals        thru    la1-99-exit;
                la1_print_totals();
                la1_99_exit();

                //      add 1                           to      subs-print-classes;
                subs_print_classes++;

                //       go to la0-10-check-code.;
                la0_10_check_code();
                return;
            }
        }

        private void la0_99_exit()
        {            

            //     exit.;
        }

        private void la1_print_totals()
        {            

            //   move ws-class-mtd-svc(subs-dept-clinic, subs-print-classes)
            //                          to t2-mtd-svc
            //                                     ws-mtd-svc.

            t2_mtd_svc = ws_class_mtd_svc[subs_dept_clinic, subs_print_classes];
            ws_mtd_svc = ws_class_mtd_svc[subs_dept_clinic, subs_print_classes];


            // move ws-class-mtd-amt(subs-dept-clinic, subs-print-classes)
            //                             to t2-mtd-amt
            //                                     ws-mtd-amt.

            t2_mtd_amt = ws_class_mtd_amt[subs_dept_clinic, subs_print_classes];
            ws_mtd_amt = ws_class_mtd_amt[subs_dept_clinic, subs_print_classes];

            // move ws-class-ytd-svc(subs-dept-clinic, subs-print-classes)
            //                             to t2-ytd-svc
            //                                      ws-ytd-svc.

            t2_ytd_svc = ws_class_ytd_svc[subs_dept_clinic, subs_print_classes];
            ws_ytd_svc = ws_class_ytd_svc[subs_dept_clinic, subs_print_classes];


            //move ws-class-ytd-amt(subs-dept-clinic, subs-print-classes)
            //                             to t2-ytd-amt
            //                                     ws-ytd-amt.

            t2_ytd_amt = ws_class_ytd_amt[subs_dept_clinic, subs_print_classes];
            ws_ytd_amt = ws_class_ytd_amt[subs_dept_clinic, subs_print_classes];

            //  perform xd0-calc-avg-perc                thru    xd0-99-exit.;
            xd0_calc_avg_perc();
            xd0_99_exit();

            t2_mtd_avg = ws_mtd_avg;
            t2_ytd_avg = ws_ytd_avg;
            t2_mtd_perc = ws_mtd_perc;
            t2_ytd_perc = ws_ytd_perc;

            if (ws_mtd_perc < 0)
            {
                t2_mtd_perc_sign = "-";
            }
            else
            {
                t2_mtd_perc_sign = "%";
            }

            if (ws_ytd_perc < 0)
            {
                t2_ytd_perc_sign = "-";
            }
            else
            {
                 t2_ytd_perc_sign = "%";
            }

            t2_class_code = ws_class_code[subs_dept_clinic, subs_print_classes];

            t2_col = ": ";

            t2_class_code_desc = ws_class_code_desc[subs_dept_clinic, subs_print_classes];

            nbr_of_lines_to_print = 2;

            // if parm-status = 1 then;            
            if (objParm_file_rec.Parm_status == 1)
            {
                //     perform xe0-write-print-line-a  thru    xe0-99-exit;
                xe0_write_print_line_a(4);
                xe0_99_exit();
            }
            else
            {
                //  perform xf0-write-print-line-b  thru    xf0-99-exit.;
                xf0_write_print_line_b();
                xf0_99_exit();
            }
        }

        private void la1_99_exit()
        {            
            //     exit.;
        }

        private void la3_bump_totals()
        {            

            flag = "N";
            subs_class_total = 1;

            // if subs-present-nbr-classes not = zero then;        
            if (subs_present_nbr_classes != 0)
            {
                //      perform la31-search-class-tbl   thru    la31-99-exit;
                //             varying subs1 from 1 by 1;
                //                until   subs1 > subs-present-nbr-classes;
                //                  or ok.;

                subs1 = 1;
                do
                {
                    la31_search_class_tbl();
                    la31_99_exit();
                    subs1++;
                } while (subs1 <= subs_present_nbr_classes && flag != ok);
            }


            // if ok then;       
            if (flag.ToUpper().Equals(ok))
            {
                //    next sentence;
            }
            else
            {
                //       add 1                           to      subs-present-nbr-classes;
                subs_present_nbr_classes++;

                //    if subs-present-nbr-classes > const-nbr-classes + 1 then;            
                if (subs_present_nbr_classes > (objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1))
                {
                    err_ind = 7;
                    //              perform za0-common-error    thru    za0-99-exit;
                    za0_common_error();
                    za0_99_exit();
                    //              go to az0-end-of-job;
                    az0_end_of_job();
                    return;
                }
                else
                {
                    ws_class_code[subs_clinic, subs_class_total] = ws_class_code[subs_dept_clinic, subs_class_code];
                    ws_class_code_desc[subs_clinic, subs_class_total] = ws_class_code_desc[subs_dept_clinic, subs_class_code];
                }
            }


            //     add ws-class-mtd-svc(subs-dept-clinic,subs-class-code);
            //                                         to      ws-class-mtd-svc(subs-clinic,subs-class-total).;

            ws_class_mtd_svc[subs_clinic, subs_class_total] += ws_class_mtd_svc[subs_dept_clinic, subs_class_code];

            //     add ws-class-mtd-amt(subs-dept-clinic,subs-class-code);
            //                                        to      ws-class-mtd-amt(subs-clinic,subs-class-total).;
            ws_class_mtd_amt[subs_clinic, subs_class_total] += ws_class_mtd_amt[subs_dept_clinic, subs_class_code];

            //     add ws-class-ytd-svc(subs-dept-clinic,subs-class-code);
            //                                        to      ws-class-ytd-svc(subs-clinic,subs-class-total).;

            ws_class_ytd_svc[subs_clinic, subs_class_total] += ws_class_ytd_svc[subs_dept_clinic, subs_class_code];

            //     add ws-class-ytd-amt(subs-dept-clinic,subs-class-code);
            //                                        to      ws-class-ytd-amt(subs-clinic,subs-class-total).;

            ws_class_ytd_amt[subs_clinic, subs_class_total] += ws_class_ytd_amt[subs_dept_clinic, subs_class_code];
        }

        private void la3_99_exit()
        {            

            //     exit.;
        }

        private void la31_search_class_tbl()
        {            

            // if ws-class-code(subs-dept-clinic,subs-class-code) = ws-class-code(subs-clinic,subs-class-total) then;            
            if (Util.Str(ws_class_code[subs_dept_clinic, subs_class_code]) == Util.Str(ws_class_code[subs_clinic, subs_class_total]))
            {
                flag = "Y";
            }
            else
            {
                //         add 1                       to      subs-class-total.;
                subs_class_total++;
            }
        }

        private void la31_99_exit()
        {            

            //     exit.;
        }

        private void na0_check_class_code()
        {            

            // if hold-class-code not = wf-class-code then;            
            if (hold_class_code != objWork_file_rec.wf_class_code)
            {
                //     add 1                           to subs-class-code;
                //                                          subs-max-nbr-classes;
                subs_class_code++;
                subs_max_nbr_classes++;
                //  perform xu0-new-class-head      thru xu0-99-exit.;
                xu0_new_class_head();
                xu0_10_get_desc();
                xu0_99_exit();
            }
        }

        private void na0_99_exit()
        {            

            //     exit.;
        }

        private void xa0_headings_a()
        {            

            h1_page_nbr = ctr_pages;
            h1_report_page_nbr = ctr_report_pages;
            h1_title = "* PHYSICIAN REVENUE ANALYSIS *";

            objDoc_mstr_rec.DOC_NBR = hold_doc_nbr;
            h2a_doc_nbr = hold_doc_nbr;

            //     perform xk0-access-doc-mstr             thru    xk0-99-exit.;
            xk0_access_doc_mstr();
            xk0_99_exit();

            //     perform xa1-doc-name-inits              thru    xa1-99-exit.;
            xa1_doc_name_inits();
            xa1_99_exit();

            h2a_doc_name_inits = ws_doc_name_inits;
            h6_dept_nbr = hold_dept;

            //     write print-record-one from h1-head after advancing page.;            
            objPrint_record_one.PageBreak();
            objPrint_record_one.print(h1_head_grp(), 1, true);

            //     write print-record-one from h2-head after advancing 1 line.;            
            objPrint_record_one.print(h2_head_grp(), 1, true);

            //     write print-record-one from h6-head after advancing 2 lines.;            
            objPrint_record_one.print(true);
            objPrint_record_one.print(h6_head_grp(), 1, true);

            //     write print-record-one from h7-head after advancing 1 line.;            
            objPrint_record_one.print(h7_head_grp(), 1, true);

            //     write print-record-one from h2a-head after advancing 2 lines.;            
            objPrint_record_one.print(true);
            objPrint_record_one.print(h2a_head_grp(), 1, true);

            //     write print-record-one from h3-head after advancing 1 line.;            
            objPrint_record_one.print(h3_head_grp(), 1, true);

            //     write print-record-one from h4-head after advancing 1 line.;            
            objPrint_record_one.print(h4_head_grp(), 1, true);

            //     write print-record-one from h5-head after advancing 1 line.;            
            objPrint_record_one.print(h5_head_grp(), 1, true);

            ctr_lines = 10;
            //     add 1                           to      ctr-pages.;
            ctr_pages++;
            //     add 1                             to      ctr-report-pages.;
            ctr_report_pages++;
        }

        private void xa0_99_exit()
        {            

            //     exit.;
        }

        private void xa1_doc_name_inits()
        {            

            ws_doc_name_inits = "";
            // if doc-init3 not = spaces then;            
            if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT3))
            {
                //     string doc-name                 delimited by ws-xx,;
                //             " "                      delimited by size,;
                //              doc-init1                delimited by size,;
                //              "."                      delimited by size,;
                //              doc-init2                delimited by size,;
                //              "."                      delimited by size,;
                //              doc-init3                delimited by size,;
                //              "."                      delimited by size,;
                //                                       into    ws-doc-name-inits;

                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME) + Util.Str(ws_xx) + " " + Util.Str(objDoc_mstr_rec.DOC_INIT1) + "." + Util.Str(objDoc_mstr_rec.DOC_INIT2) + "." + Util.Str(objDoc_mstr_rec.DOC_INIT3) + ".";
            }
            // else if doc-init2 not = spaces then;            
            else if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT2))
            {
                //         string doc-name             delimited by ws-xx,;
                //          " "                         delimited by size,;
                //           doc-init1                   delimited by size,;
                //           "."                         delimited by size,;
                //           doc-init2                   delimited by size,;
                //           "."                         delimited by size,;
                //                                       into    ws-doc-name-inits;

                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME) + Util.Str(ws_xx) + " " + Util.Str(objDoc_mstr_rec.DOC_INIT1) + "." + Util.Str(objDoc_mstr_rec.DOC_INIT2) + ".";
            }
            // else  if doc-init1 not = spaces  then;      
            else if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT1))
            {
                //             string doc-name         delimited by ws-xx,;
                //              " "                     delimited by size,;
                //               doc-init1               delimited by size,;
                //               "."                     delimited by size,;
                //                                       into    ws-doc-name-inits;

                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME) + Util.Str(ws_xx) + " " + Util.Str(objDoc_mstr_rec.DOC_INIT1) + ".";
            }
            else
            {
                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME);
            }
        }

        private void xa1_99_exit()
        {            

            //     exit.;
        }

        private void xb0_headings_b()
        {            

            h1_page_nbr = ctr_pages;
            h1_report_page_nbr = ctr_report_pages;
            h1_title = "* DEPARTMENT PRACTICE ANALYSIS *";

            //     write print-record-two from h1-head after advancing page.;            
            objPrint_record_two.PageBreak();
            objPrint_record_two.print(h1_head_grp(), 1, true);

            //     write print-record-two from h2-head after advancing 1 line.;            
            objPrint_record_two.print(h2_head_grp(), 1, true);

            //     write print-record-two from h6-head after advancing 2 lines.;            
            objPrint_record_two.print(true);
            objPrint_record_two.print(h6_head_grp(), 1, true);

            //     write print-record-two from h7-head after advancing 1 line.;            
            objPrint_record_two.print(h7_head_grp(), 1, true);

            //     write print-record-two from h3-head after advancing 2 lines.;            
            objPrint_record_two.print(true);
            objPrint_record_two.print(h3_head_grp(), 1, true);

            //     write print-record-two from h4-head after advancing 1 line.;            
            objPrint_record_two.print(h4_head_grp(), 1, true);

            //     write print-record-two from h5-head after advancing 1 line.;            
            objPrint_record_two.print(h5_head_grp(), 1, true);

            ctr_lines = 9;

            //     add 1                           to      ctr-pages.;
            ctr_pages++;

            //     add 1                             to      ctr-report-pages.;
            ctr_report_pages++;

        }

        private void xb0_99_exit()
        {            

            //     exit.;
        }

        private void xc0_read_work_rec()
        {            

            // read r051-work-file;
            //         at end;
            //         flag_end_work_rec = "Y";
            //         go to xc0-99-exit.;

            if (Work_file_rec_Collection.Count() == 0)
            {
                flag_end_work_rec = "Y";
                // go to xc0-99-exit.;
                xc0_99_exit();
                return;
            }
            else
            {
                if (ctr_work_file_reads >= Work_file_rec_Collection.Count())
                {
                    flag_end_work_rec = "Y";
                    xc0_99_exit();
                    return;
                }
                else
                {
                    objWork_file_rec = Work_file_rec_Collection[ctr_work_file_reads];
                    ctr_work_file_reads++;
                }
            }

            // if wf-class-code = high-value then;            
            //     objWork_file_rec.wf_class_code = "";

            if (objWork_file_rec.wf_class_code == high_value)  //todo:  high_value ...
            {
               // objWork_file_rec.wf_class_code = "";
            }
        }

        private void xc0_99_exit()
        {            

            //     exit.;
        }

        private void xd0_calc_avg_perc()
        {            

            ws_mtd_avg = 0;
            ws_mtd_perc = 0;
            ws_ytd_avg = 0;
            ws_ytd_perc = 0;

            //     divide ws-mtd-svc                       into ws-mtd-amt;
            //                                  giving ws-mtd-avg rounded.;

            // ws_mtd_avg = ws_mtd_amt / ( ws_mtd_svc == 0 ? 1 : ws_mtd_svc);
            ws_mtd_avg = (ws_mtd_svc != 0) ? Util.NumInt(Math.Round(ws_mtd_amt / ws_mtd_svc,2)) : 0;

            //     divide ws-mtd-sum-next-level      into ws-mtd-amt;
            //                                  giving ws-mtd-perc rounded.;

            // ws_mtd_perc = ws_mtd_amt / (ws_mtd_sum_next_level == 0 ? 1 : ws_mtd_sum_next_level);
            ws_mtd_perc = (ws_mtd_sum_next_level != 0) ? ws_mtd_amt / ws_mtd_sum_next_level : 0; 

            //     multiply ws-mtd-perc             by 100;
            //                                   giving ws-mtd-perc rounded.;

            ws_mtd_perc = ws_mtd_perc * 100;

            //     divide ws-ytd-svc                        into ws-ytd-amt;
            //                                  giving ws-ytd-avg rounded.;

            //ws_ytd_avg = ws_ytd_amt / (ws_ytd_svc == 0 ? 1 : ws_ytd_svc);
            ws_ytd_avg = (ws_ytd_svc != 0) ?   Util.NumInt(Math.Round(ws_ytd_amt / ws_ytd_svc,2)) : 0;


            //     divide ws-ytd-sum-next-level      into ws-ytd-amt;
            //                                  giving ws-ytd-perc rounded.;

            ws_ytd_perc = ws_ytd_amt / (ws_ytd_sum_next_level == 0 ? 1 : ws_ytd_sum_next_level);           

            //     multiply ws-ytd-perc             by 100;
            //                                   giving ws-ytd-perc rounded.;

            ws_ytd_perc = ws_ytd_perc * 100;
        }

        private void xd0_99_exit()
        {            

            //     exit.;
        }

        private void xe0_write_print_line_a(int option = 1)
        {            

            // add nbr-of-lines-to-print           to      ctr-lines.;
            ctr_lines += nbr_of_lines_to_print;

            // if ctr-lines > max-nbr-lines then;    
            if (ctr_lines > max_nbr_lines)
            {
                h5_doc_dept_lit = "   OF DOC";
                h5_doc_dept_lit2 = "   OF DOC";

                //  perform xa0-headings-a          thru    xa0-99-exit.;
                xa0_headings_a();
                xa0_99_exit();
            }

            //     write print-record-one from print-line after advancing nbr-of-lines-to-print line.;
            
            for (var i = 1; i < nbr_of_lines_to_print; i++)
            {
                objPrint_record_one.print(true);
            }
           
            switch(option)
            {
                case 1:
                    objPrint_record_one.print(print_line_grp(), 1, true);
                    break;
                case 2:
                    objPrint_record_one.print(l2_print_line_grp(), 1, true);
                    break;
                case 3:
                    objPrint_record_one.print(t1_print_line_grp(), 1, true);
                    break;
                case 4:
                    objPrint_record_one.print(t2_print_line_grp(), 1, true);
                    break;
                case 5:
                    objPrint_record_one.print(t3_print_line_grp(), 1, true);
                    break;
                case 6:
                    objPrint_record_one.print(t4_print_line_grp(), 1, true);
                    break;
            }

            //print_line = "";
            initialize_print_line_grp();            
        }

        private void xe0_99_exit()
        {            

            //     exit.;
        }

        private void xf0_write_print_line_b(int option = 2)
        {            

            // add nbr-of-lines-to-print            to      ctr-lines.;
            ctr_lines += nbr_of_lines_to_print;

            // if ctr-lines > max-nbr-lines then;    
            if (ctr_lines > max_nbr_lines)
            {
                h5_doc_dept_lit = " OF CLASS";
                h5_doc_dept_lit2 = " OF CLASS";

                // perform xb0-headings-b          thru    xb0-99-exit.;
                xb0_headings_b();
                xb0_99_exit();
            }

            //  write print-record-two from print-line after advancing nbr-of-lines-to-print line.;
            
            for (var i = 1; i < nbr_of_lines_to_print; i++)
            {
                objPrint_record_two.print(true);
            }

            if (option == 1)
            {
                objPrint_record_two.print(print_line_grp(), 1, true);
            }
            else if (option == 2)
            {
                objPrint_record_two.print(t2_print_line_grp(), 1, true);
            }
            else if (option == 3)
            {
                objPrint_record_two.print(t3_print_line_grp(), 1, true);
            }
            else if (option == 4 )
            {
                objPrint_record_two.print(t4_print_line_grp(), 1, true);
            }
            else
            {
                objPrint_record_two.print(print_line_grp(), 1, true);
            }
            

            //print_line = "";
            initialize_print_line_grp();            
        }

        private void xf0_99_exit()
        {            

            //     exit.;
        }

        private void xk0_access_doc_mstr()
        {            

            //     read doc-mstr;
            //        invalid key;
            //objDoc_mstr_rec.DOC_NAME = "UNKNOWN DOCTOR";

            Doc_mstr_rec_Collection = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = hold_doc_nbr
            }.Collection();

            if (Doc_mstr_rec_Collection.Count() == 0)
            {
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                objDoc_mstr_rec.DOC_NAME = "UNKNOWN DOCTOR";
            } else
            {
                objDoc_mstr_rec = Doc_mstr_rec_Collection.FirstOrDefault();
            }
        }

        private void xk0_99_exit()
        {            

            //     exit.;
        }

        private void xm0_access_oma_fee_mstr()
        {            

            //     read oma-fee-mstr;
            //  invalid key;
            //                                      to fee-desc.;

            Fee_mstr_rec_Collection = new F040_OMA_FEE_MSTR
            {
                // Todo:  Not sure of ther critieria... ????
                WhereFee_oma_cd_ltr1 = objFee_mstr_rec.FEE_OMA_CD_LTR1,
                WhereFiller_numeric = objFee_mstr_rec.FILLER_NUMERIC

            }.Collection();

            if (Fee_mstr_rec_Collection.Count() == 0)
            {
                objFee_mstr_rec = new F040_OMA_FEE_MSTR();
                objFee_mstr_rec.FEE_DESC = "UNKNOWN CODE DESCRIPTION";
            }
            else
            {
                objFee_mstr_rec = Fee_mstr_rec_Collection.FirstOrDefault();
            }

        }

        private void xm0_99_exit()
        {            

            //     exit.;
        }

        private void xp0_clinic_dept_total_rec()
        {            

            total_clinic_dept_mtd_svc = objWork_file_rec.wf_mtd_svcs;
            total_clinic_dept_mtd_amt = Util.ConvertZoneToNumericLong(Util.Str(objWork_file_rec.wf_mtd_amt));
            total_clinic_dept_ytd_svc = objWork_file_rec.wf_ytd_svcs;
            total_clinic_dept_ytd_amt = Util.ConvertZoneToNumericLong(Util.Str(objWork_file_rec.wf_ytd_amt));
        }

        private void xp0_99_exit()
        {            

            //     exit.;
        }

        private void xq0_dept_doc_total_rec()
        {            

            total_dept_doc_mtd_svc = objWork_file_rec.wf_mtd_svcs;
            total_dept_doc_mtd_amt = Util.ConvertZoneToNumericLong(objWork_file_rec.wf_mtd_amt);
            total_dept_doc_ytd_svc = objWork_file_rec.wf_ytd_svcs;
            total_dept_doc_ytd_amt = Util.ConvertZoneToNumericLong(objWork_file_rec.wf_ytd_amt);
        }
        private void xq0_99_exit()
        {            

            //     exit.;
        }

        private void xr0_class_tot_rec()
        {            

            total_class_mtd_svc = objWork_file_rec.wf_mtd_svcs;
            total_class_mtd_amt = Util.ConvertZoneToNumericLong(objWork_file_rec.wf_mtd_amt);
            total_class_ytd_svc = objWork_file_rec.wf_ytd_svcs;
            total_class_ytd_amt = Util.ConvertZoneToNumericLong(objWork_file_rec.wf_ytd_amt);
        }

        private void xr0_99_exit()
        {            

            //     exit.;
        }

        private void xs0_clear_class_tbl()
        {            

            ws_class_code[subs_dept_clinic, subs] = "";
            ws_class_code_desc[subs_dept_clinic, subs] = "";

            ws_class_mtd_svc[subs_dept_clinic, subs] = 0;
            ws_class_mtd_amt[subs_dept_clinic, subs] = 0;
            ws_class_ytd_svc[subs_dept_clinic, subs] = 0;
            ws_class_ytd_amt[subs_dept_clinic, subs] = 0;

        }

        private void xs0_99_exit()
        {            

            //     exit.;
        }

        private void xt0_new_dept_head()
        {            


            h6_dept_nbr = objWork_file_rec.wf_dept;
            objDept_mstr_rec.DEPT_NBR = objWork_file_rec.wf_dept;

            // read dept-mstr;
            //   invalid key;
            //      objDept_mstr_rec.dept_name = "'UNKNOWN DEPT'";

            objDept_mstr_rec = new F070_DEPT_MSTR
            {
                WhereDept_nbr = objWork_file_rec.wf_dept
            }.Collection().FirstOrDefault();

            if (objDept_mstr_rec == null)
            {
                objDept_mstr_rec = new F070_DEPT_MSTR();
                objDept_mstr_rec.DEPT_NAME = "UNKNOWN DEPT";
            }

            h6_dept_name = objDept_mstr_rec.DEPT_NAME;
        }

        private void xt0_99_exit()
        {            

            //     exit.;
        }

        private void xu0_new_class_head()
        {            

            subs = 1;
        }

        private void xu0_10_get_desc()
        {            


            // if wf-class-code = const-class-ltr(subs) then;            
            if (objWork_file_rec.wf_class_code == CONST_CLASS_LTR(objConstants_mstr_rec_4, subs))
            {
                h7_class_desc = CONST_CLASS_DESC(objConstants_mstr_rec_4, subs);
                ws_class_code_desc[subs_dept_clinic, subs_class_code] = CONST_CLASS_DESC(objConstants_mstr_rec_4, subs);
            }
            // else if subs < const-nbr-classes  then            
            else if (subs < objConstants_mstr_rec_4.CONST_NBR_CLASSES)
            {
                //      add 1                       to subs;
                subs++;
                //      go to xu0-10-get-desc;
                xu0_10_get_desc();
                return;
            }
            else
            {
                h7_class_desc = "UNKNOWN DESC";
                ws_class_code_desc[subs_dept_clinic, subs_class_code] = "UNKNOWN DESC";
            }

            ws_class_code[subs_dept_clinic, subs_class_code] = objWork_file_rec.wf_class_code;
            h7_class = objWork_file_rec.wf_class_code;
        }

        private void xu0_99_exit()
        {            

            //     exit.;
        }

        private void xy0_headings_summ()
        {            


            summ_page_nbr = summ_ctr_pages;
            summ_title = "* PHYSICIAN REVENUE ANALYSIS *";

            //     write print-record-summ from summ-head after advancing page.;            
            objPrint_record_summ.PageBreak();
            objPrint_record_summ.print(summ_head_grp(), 1, true);

            //     write print-record-summ from h2-head after advancing 1 line.;            
            objPrint_record_summ.print(h2_head_grp(), 1, true);

            //     write print-record-summ from h3-head after advancing 2 line.;            
            objPrint_record_summ.print(true);
            objPrint_record_summ.print(h3_head_grp(), 1, true);

            //     write print-record-summ from h4-head after advancing 1 line.;            
            objPrint_record_summ.print(h4_head_grp(), 1, true);

            //     write print-record-summ from h5-head after advancing 1 line.;            
            objPrint_record_summ.print(h5_head_grp(), 1, true);

            summ_ctr_lines = 6;

            //     add 1                                to      summ-ctr-pages.;
            summ_ctr_pages++;
        }

        private void xy0_99_exit()
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

        private string h1_head_grp()
        {            

            return Util.Str(h1_report_nbr).PadRight(6) + 
                   "/" + 
                   string.Format("{0:##}", h1_clinic_nbr).PadLeft(2) + 
                   new string(' ', 3) + 
                   "P.E.D.".PadRight(7) + 
                   Util.Str(h1_ped_yy).PadLeft(4) + 
                   "/" + 
                   Util.Str(h1_ped_mm).PadLeft(2, '0') + 
                   "/" + 
                   Util.Str(h1_ped_dd).PadLeft(2, '0') +
                   new string(' ', 20) + 
                   Util.Str(h1_title).PadRight(45) + 
                   "RUN DATE:".PadRight(11) + 
                   Util.Str(h1_run_date_yy).PadLeft(4) + 
                   "/" + 
                   Util.Str(h1_run_date_mm).PadLeft(2, '0') + 
                   "/" + 
                   Util.Str(h1_run_date_dd).PadLeft(2, '0') + 
                   new string(' ', 4) + 
                   "PAGE".PadRight(5) +
                   Util.Str(h1_page_nbr).PadLeft(3) + 
                   "/" + 
                   Util.Str(h1_report_page_nbr).PadLeft(3);
        }

        private string summ_head_grp()
        {            

            return  Util.Str(summ_report_nbr).PadRight(11) + 
                    "/" + 
                    string.Format("{0:##}", summ_clinic_nbr).PadLeft(2) +
                    new string(' ', 3) + 
                    "P.E.D.".PadRight(7) + 
                    Util.Str(summ_ped_yy).PadLeft(4, '0') + 
                    "/" + 
                    Util.Str(summ_ped_mm).PadLeft(2, '0') + 
                    "/" + 
                    Util.Str(summ_ped_dd).PadLeft(2, '0') + 
                    new string(' ', 15) + 
                    Util.Str(summ_title).PadRight(45) +
                   "RUN DATE:".PadRight(11) + 
                   Util.Str(summ_run_date_yy).PadLeft(4, '0') + 
                   "/" + 
                   Util.Str(summ_run_date_mm).PadLeft(2, '0') + 
                   "/" + 
                   Util.Str(summ_run_date_dd).PadLeft(2, '0') + 
                   new string(' ', 8) + 
                   "PAGE".PadRight(5) + 
                   string.Format("{0:##0}", summ_page_nbr).PadLeft(3);
        }

        private string h2_head_grp()
        {            

            return new string(' ', 56) + 
                   Util.Str(h2_clinic_name).PadRight(20) + 
                   new string(' ', 56);
        }

        private string h2a_head_grp()
        {            

            return  "DOCTOR".PadRight(7) + 
                   Util.Str(h2a_doc_nbr).PadRight(3) + 
                   new string(' ', 3) + 
                   Util.Str(h2a_doc_name_inits).PadRight(119);
        }

        private string h3_head_grp()
        {            

            return  new string(' ', 55) + 
                    "----------- M . T . D . -----------   -------------- Y . T . D . ------------".PadRight(77);
        }

        private string h4_head_grp()
        {            

            return  new string(' ', 56) + 
                    "SVC    $ AMT      $ AVG    PERCENT".PadRight(40) + 
                    "SVC     $ AMT       $ AVG    PERCENT".PadRight(36);
        }

        private string h5_head_grp()
        {            

            return  Util.Str(h5_ohip_code_desc_lit).PadRight(81) + 
                    Util.Str(h5_doc_dept_lit).PadRight(42) + 
                    Util.Str(h5_doc_dept_lit2).PadRight(9);
        }

        private string h6_head_grp()
        {            

            return  new string(' ', 49) + 
                    "DEPT #".PadRight(6) + 
                    Util.Str(h6_dept_nbr).PadLeft(2, '0') + 
                    " - ".PadRight(3) + 
                    Util.Str(h6_dept_name).PadRight(72);
        }

        private string h7_head_grp()
        {            

            return  new string(' ', 49) + 
                    "CLASS".PadRight(7) + 
                    Util.Str(h7_class).PadRight(2) + 
                    "- ".PadRight(2) + 
                    Util.Str(h7_class_desc).PadRight(72);
        }

        private string h8_head_grp()
        {            

            return  Util.Str(h8_total_lit).PadRight(132);
        }

        private string print_line_grp()
        {            

            return Util.Str(l1_oma_cd).PadRight(6) +          //  l1_print_line
                             Util.Str(l1_desc).PadRight(49) +
                             Util.Str(l1_mtd_svc).PadLeft(4) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", l1_mtd_amt, 2, 12) +
                             new string(' ', 2) +
                             Util.ImpliedDecimalFormat("#,0.00", Util.DecimalValuePadZerosRight(Math.Truncate(l1_mtd_avg)/ 100,2), 2, 9) +
                              //string.Format("{0:0.00}", l1_mtd_perc).PadLeft(6) +
                              //Util.ImpliedDecimalFormat("0.00", l1_mtd_perc, 2, 6, false) +
                              string.Format("{0:0.00}", l1_mtd_perc).PadLeft(6).Replace("-", " ") +
                             Util.Str(l1_mtd_perc_sign).PadRight(4) +
                             string.Format("{0:#0}", l1_ytd_svc).PadLeft(6) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", l1_ytd_amt, 2, 13) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", Util.DecimalValuePadZerosRight(Math.Truncate(l1_ytd_avg) /100,2), 2, 11) +
                           //  string.Format("{0:0.00}", l1_ytd_perc).PadLeft(6) +
                            //Util.ImpliedDecimalFormat("0.00", l1_ytd_perc,2,6,false).Replace("-"," ") +
                             string.Format("{0:0.00}", l1_ytd_perc).PadLeft(6).Replace("-"," ") +
                             Util.Str(l1_ytd_perc_sign).PadRight(1); 
                             

                             
        }

        private string l2_print_line_grp()
        {            

            return Util.Str(l2_ltr).PadRight(1) +     // l2-print-line redefines l1-print-line 
                            Util.Str(l2_dashes).PadRight(6) +
                            Util.Str(l2_total_lit).PadRight(47) +
                            Util.Str(l2_mtd_svc).PadLeft(5) +
                            new string(' ', 1) +
                            Util.ImpliedDecimalFormat("#,0.00", l2_mtd_amt, 2, 12) +
                            new string(' ', 1) +
                            Util.ImpliedDecimalFormat("#,0.00", l2_mtd_avg, 2, 10) +
                            string.Format("{0:0.00}", l2_mtd_perc).PadLeft(6) +
                            Util.Str(l2_mtd_perc_sign).PadRight(3) +
                            Util.Str(l2_ytd_svc).PadLeft(7) +
                            new string(' ', 1) +
                            Util.ImpliedDecimalFormat("0.00", l2_ytd_amt, 2, 13) +
                            new string(' ', 1) +
                            Util.ImpliedDecimalFormat("#,0.00", l2_ytd_avg, 2, 11) +
                            string.Format("0.00", l2_ytd_perc).PadLeft(6) +
                            Util.Str(l2_ytd_perc_sign).PadRight(1);
        }

        private string t1_print_line_grp()
        {            

            return   Util.Str(t1_doc_lit).PadRight(8) +       // t1-print-line redefines l2-print-line. 
                             Util.Str(t1_doc_nbr).PadRight(3) +
                             new string(' ', 3) +
                             Util.Str(t1_total_lit).PadRight(38) +
                             string.Format("{0:#,0}", t1_mtd_svc).PadLeft(7) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("0.00", t1_mtd_amt, 2, 12) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", Util.DecimalValuePadZerosRight(Math.Truncate(t1_mtd_avg) /100,2), 2, 10) +
                             string.Format("{0:0.00}", t1_mtd_perc).Replace("-","").PadLeft(6) +   
                             Util.Str(t1_mtd_perc_sign).PadRight(3) +
                             Util.Str(t1_ytd_svc).PadLeft(7) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("0.00", t1_ytd_amt, 2, 13) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("0.00", Util.DecimalValuePadZerosRight(Math.Truncate(t1_ytd_avg) /100,2), 2, 11) +
                             string.Format("{0:0.00}", t1_ytd_perc).Replace("-","").PadLeft(6) +   
                             Util.Str(t1_ytd_perc_sign).PadRight(1);
        }

        private string t2_print_line_grp()
        {            

            if (!string.IsNullOrWhiteSpace(t2_dept_lit))
            {
                   return    Util.Str(t2_dept_lit).PadRight(51) +     // t2-print-line redefines t1-print-line.
                                                      //Util.Str(t2_class_code).PadRight(1) +    Redefines...
                                                      //Util.Str(t2_col).PadRight(2) +
                                                      //Util.Str(t2_class_code_desc).PadRight(48) + 
                              Util.Str(t2_mtd_svc).PadLeft(8) +
                              new string(' ', 1) +
                              Util.ImpliedDecimalFormat("0.00", t2_mtd_amt, 2, 12) +
                              new string(' ', 1) +
                              Util.ImpliedDecimalFormat("#,0.00", Util.DecimalValuePadZerosRight( Math.Truncate(t2_mtd_avg) /100,2), 2, 10) +
                              string.Format("{0:0.00}", t2_mtd_perc).PadLeft(6) +
                              Util.Str(t2_mtd_perc_sign).PadRight(2) +
                              Util.Str(t2_ytd_svc).PadLeft(8) +
                              new string(' ', 1) +
                              Util.ImpliedDecimalFormat("0.00", t2_ytd_amt, 2, 13) +
                              new string(' ', 1) +
                              Util.ImpliedDecimalFormat("0.00", Util.DecimalValuePadZerosRight(Math.Truncate(t2_ytd_avg) /100,2), 2, 11) +
                              string.Format("{0:0.00}", t2_ytd_perc).PadLeft(6) +
                              Util.Str(t2_ytd_perc_sign).PadRight(1); 
            }
            else
            {
                if (Util.Str(t2_class_code).ToUpper() == "P")
                {
                    t2_class_code_desc = "PART TIME";
                }
                else if (Util.Str(t2_class_code).ToUpper() == "F")
                {
                    t2_class_code_desc = "FULL TIME";
                }
                    return     Util.Str(t2_class_code).PadRight(1) +   // Redefines...
                               Util.Str(t2_col).PadRight(2) +
                               Util.Str(t2_class_code_desc).PadRight(48) +

                                Util.Str(t2_mtd_svc).PadLeft(8) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#,0.00", t2_mtd_amt, 2, 12) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#,0.00", Util.DecimalValuePadZerosRight(Math.Truncate(t2_mtd_avg) /100,2), 2, 10) +
                                string.Format("{0:0.00}", t2_mtd_perc).PadLeft(6) +
                                Util.Str(t2_mtd_perc_sign).PadRight(2) +
                                Util.Str(t2_ytd_svc).PadLeft(8) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#,0.00", t2_ytd_amt, 2, 13) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#,0.00", Util.DecimalValuePadZerosRight(Math.Truncate(t2_ytd_avg)/ 100,2), 2, 11) +
                                string.Format("{0:0.00}", t2_ytd_perc).PadLeft(6) +
                                Util.Str(t2_ytd_perc_sign).PadRight(1);                
            }
        }

        private string t3_print_line_grp()
        {            

            return    Util.Str(t3_dept_lit).PadRight(51) +    // t3-print-line redefines t2-print-line. 
                             Util.Str(t3_mtd_svc).PadLeft(8) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t3_mtd_amt, 2, 12) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t3_mtd_avg, 2, 10) +
                             string.Format("{0:0.00}", t3_mtd_perc).PadLeft(6) +
                             Util.Str(t3_mtd_perc_sign).PadRight(2) +
                             Util.Str(t3_ytd_svc).PadLeft(8) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t3_ytd_amt, 2, 13) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t3_ytd_avg, 2, 11) +
                             string.Format("{0:0.00}", t3_ytd_perc).PadLeft(6) +
                             Util.Str(t3_ytd_perc_sign).PadRight(1);
        }

        private string t4_print_line_grp()
        {            

            return  Util.Str(t4_clinic_lit).PadRight(51) +   // t4-print-line redefines t3-print-line.
                             Util.Str(t4_mtd_svc).PadLeft(8) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t4_mtd_amt, 2, 12) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t4_mtd_avg, 2, 10) +
                             string.Format("{0:0.00}", t4_mtd_perc).PadLeft(6) +
                             Util.Str(t4_mtd_perc_sign).PadRight(2) +
                             Util.Str(t4_ytd_svc).PadLeft(8) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t4_ytd_amt, 2, 13) +
                             new string(' ', 1) +
                             Util.ImpliedDecimalFormat("#,0.00", t4_ytd_avg, 2, 11) +
                             string.Format("{0:0.00}", t4_ytd_perc).PadLeft(6) +
                             Util.Str(t4_ytd_perc_sign).PadRight(1);
        }

        private void initialize_print_line_grp()
        {            

            l1_print_line_grp = "";
            l1_oma_cd = "";
            l1_desc = "";
            l1_mtd_svc = 0;
            filler = "";
            l1_mtd_amt = 0;
            //private string filler;
            l1_mtd_avg = 0;
            l1_mtd_perc = 0;
            l1_mtd_perc_sign = "";
            l1_ytd_svc = 0;

            l1_ytd_amt = 0;

            l1_ytd_avg = 0;
            l1_ytd_perc = 0;
            l1_ytd_perc_sign = "";
            //l2_print_line_grp = "";
            l2_ltr = "";
            l2_dashes = "";
            l2_total_lit = "";
            l2_mtd_svc = 0;

            l2_mtd_amt = 0;

            l2_mtd_avg = 0;
            l2_mtd_perc = 0;
            l2_mtd_perc_sign = "";
            l2_ytd_svc = 0;

            l2_ytd_amt = 0;
            l2_ytd_avg = 0;
            l2_ytd_perc = 0;
            l2_ytd_perc_sign = "";
           // t1_print_line_grp = "";
            t1_doc_lit = "";
            t1_doc_nbr = "";
            t1_total_lit = "";
            t1_mtd_svc = 0;
            t1_mtd_amt = 0;
            t1_mtd_avg = 0;
            t1_mtd_perc = 0;
            t1_mtd_perc_sign = "";
            t1_ytd_svc = 0;
            t1_ytd_amt = 0;

            t1_ytd_avg = 0;
            t1_ytd_perc = 0;
            t1_ytd_perc_sign = "";
           // t2_print_line_grp = "";
            t2_dept_lit = "";
            t2_class_code_r_grp = "";
            t2_class_code = "";
            t2_col = "";
            t2_class_code_desc = "";
            t2_mtd_svc = 0;
            t2_mtd_amt = 0;
            t2_mtd_avg = 0;
            t2_mtd_perc = 0;
            t2_mtd_perc_sign = "";
            t2_ytd_svc = 0;
            t2_ytd_amt = 0;
            t2_ytd_avg = 0;
            t2_ytd_perc = 0;
            t2_ytd_perc_sign = "";
          //  t3_print_line_grp = "";
            t3_dept_lit = "";
            t3_mtd_svc = 0;
            t3_mtd_amt = 0;
            t3_mtd_avg = 0;
            t3_mtd_perc = 0;
            t3_mtd_perc_sign = "";
            t3_ytd_svc = 0;
            t3_ytd_amt = 0;
            t3_ytd_avg = 0;
            t3_ytd_perc = 0;
            t3_ytd_perc_sign = "";
           // t4_print_line_grp = "";
            t4_clinic_lit = "";
            t4_mtd_svc = 0;
            t4_mtd_amt = 0;
            t4_mtd_avg = 0;
            t4_mtd_perc = 0;
            t4_mtd_perc_sign = "";
            t4_ytd_svc = 0;
            t4_ytd_amt = 0;
            t4_ytd_avg = 0;
            t4_ytd_perc = 0;
            t4_ytd_perc_sign = "";
        }

        #endregion
    }
}








