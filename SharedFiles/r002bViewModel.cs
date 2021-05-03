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
    public class R002bViewModel : CommonFunctionScr
    {

        public R002bViewModel()
        {

        }

        #region FD Section
        // FD: print_file_1
        private Print1_record objPrint1_record = null;
        private ObservableCollection<Print1_record> Print1_record_Collection;

        // FD: print_file_2
        private Print2_record objPrint2_record = null;
        private ObservableCollection<Print2_record> Print2_record_Collection;

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
        private F002_CLAIMS_MSTR_HDR objClaim_header_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claim_header_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_DTL objClaim_detail_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claim_detail_rec_Collection;

        // FD: pat_mstr	Copy : f010_patient_mstr.fd
        private F010_PAT_MSTR objPat_mstr_rec = null;
        private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        private ReportPrint objPrintFile1 = null;
        private ReportPrint objPrintFile2 = null;

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

        private int _ctr_pat_mstr_reads;
        public int ctr_pat_mstr_reads
        {
            get
            {
                return _ctr_pat_mstr_reads;
            }
            set
            {
                if (_ctr_pat_mstr_reads != value)
                {
                    _ctr_pat_mstr_reads = value;
                    RaisePropertyChanged("ctr_pat_mstr_reads");
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

        private string _key_pat_mstr;
        public string key_pat_mstr
        {
            get
            {
                return _key_pat_mstr;
            }
            set
            {
                if (_key_pat_mstr != value)
                {
                    _key_pat_mstr = value;
                    _key_pat_mstr = _key_pat_mstr.ToUpper();
                    RaisePropertyChanged("key_pat_mstr");
                }
            }
        }

        /* private string _print_file_name_1;
         public string print_file_name_1
         {
             get
             {
                 return _print_file_name_1;
             }
             set
             {
                 if (_print_file_name_1 != value)
                 {
                     _print_file_name_1 = value;
                     _print_file_name_1 = _print_file_name_1.ToUpper();
                     RaisePropertyChanged("print_file_name_1");
                 }
             }
         }

         private string _print_file_name_2;
         public string print_file_name_2
         {
             get
             {
                 return _print_file_name_2;
             }
             set
             {
                 if (_print_file_name_2 != value)
                 {
                     _print_file_name_2 = value;
                     _print_file_name_2 = _print_file_name_2.ToUpper();
                     RaisePropertyChanged("print_file_name_2");
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
        private string ws_reply;
        private int err_ind = 0;
        private string print_file_name_1 = "r002ba";
        private string print_file_name_2 = "r002bb";
        private string option;
        private string const_mstr_rec_nbr;
        private int difference;
        private decimal diff;
        private int max_nbr_lines = 60;
        private int ctr_page_1;
        private int ctr_page_2;
        private int ctr_line;
        private int nbr_lines_to_advance;
        private int total_lines;
        private string first_desc = "Y";
        private int claim_nbr;
        private string hold_clmhdr_status_ohip;
        private string hold_clmhdr_batch_nbr;
        private int hold_clmhdr_claim_nbr;
        private int hold_clinic_nbr;
        private string feedback_claims_mstr;
        private string feedback_pat_mstr;
        private string feedback_batctrl_file;
        private string feedback_iconst_mstr;
        private int subs;
        private int subs_const;
        private int subs_hosp;
        private int act_sum_nbr_serv = 0;
        private decimal act_sum_fee_oma_ohip = 0;
        private int claims_occur;
        private int pat_occur;
        private string eof_batctrl_file = "N";
        private string eof_claims_dtl = "N";
        private string eof_claims_mstr = "N";
        //private string common_status_file;
        private string status_cobol_batctrl_file = "0";
        private string status_cobol_claims_mstr = "0";
        private string status_cobol_pat_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_prt_file_1 = "0";
        private string status_prt_file_2 = "0";
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string flag_rec;
        private string valid_rec = "Y";
        private string invalid_rec = "N";
        private string last_page_flag;
        private string last_page = "Y";
        private string not_last_page = "N";

        private string counters_grp;
        //private int ctr_batctrl_file_reads;
        //private int ctr_claims_mstr_reads;
        //private int ctr_pat_mstr_reads;
        private decimal ctr_fee_oma;
        private decimal ctr_fee_ohip;

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
        private int ss_net_a_r = 1;
        private int ss_net_rev = 2;
        private int ss_cash = 3;
        private int ss_nbr_claims = 4;
        private int ss_nbr_svcs = 5;
        private int ss_offset = 5;
        private int ss_batctrl_offset = 0;
        private int ss_clmhdr_offset = 5;
        private int batctrl_clm_offset;

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
        private string[] desc_bat_type = { "", "claims       ", "adjustments- ", "adjustments- ", "adjustments- ", "PAYMENTS   - ", "PAYMENTS   - ", "             ", "GRAND TOTALS " };
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
        private decimal fin_tot_9;
        private decimal fin_tot_10;

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "invalid reply";
        private string filler = "INVALID READ ON CONSTANTS MASTER";
        private string filler = "INVALID CLINIC NBR";
        private string filler = "NO BATCTRL FILE SUPPLIED";
        private string filler = "****   CAN BE RE-USED   ****";
        private string filler = "NO SUITABLE BATCHES IN BATCTRL FILE";
        private string filler = "NO CLAIMS FOR THIS CLINIC"; */
        private string batch_miss_err_grp;
        //private string filler = "NO CLAIM FOR CURRENT BATCH - F001/F002 = ";
        private string miss_batch_nbr;
        //private string filler = "/";
        private string miss_f002_batch_nbr;
        private int miss_claim_nbr;
        //private string filler = "INVALID READ ON PATIENT MSTR";
        private string wrong_claim_err_grp;
        //private string filler = "DIFFERENT PED - F001/F002 = ";
        private string wrong_batch_nbr;
        private int wrong_claim_nbr;
        //private string filler = "/";
        private string wrong_f001_ped;
        //private string filler = "/";
        private string wrong_f002_ped;
        private string error_messages_r_grp;
        private string[] err_msg = new string[11] { "", "INVALID REPLY",
                                                       "INVALID READ ON CONSTANTS MASTER",
                                                       "INVALID CLINIC NBR",
                                                       "NO BATCTRL FILE SUPPLIED",
                                                       "****   CAN BE RE-USED   ****" ,
                                                       "NO SUITABLE BATCHES IN BATCTRL FILE",
                                                      "NO CLAIMS FOR THIS CLINIC",
                                                       "","INVALID READ ON PATIENT MSTR","DIFFERENT PED - F001/F002 = " };  // todo...
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

        //private string h1_head_grp;
        private string h1_rpt_name;
        //private string filler = "/";
        private int h1_clinic_nbr;
        //private string filler = "";
        //private string filler = "BATCH TYPE - ";
        private string h1_batch_type;
        //private string filler = "";
        //private string filler = "UNBALANCED BATCH ";
        private string h1_rpt_type;
        //private string filler = "REPORT";
        //private string filler = "run date";
        private string h1_run_yy;
        //private string filler = "/";
        private string h1_run_mm;
        //private string filler = "/";
        private string h1_run_dd;
        //private string filler = "";
        //private string filler = "PAGE";
        private int h1_page;

        //private string h2_head_grp;
        //private string filler = "";
        private string h2_clinic_name;

        //private string h3_head_grp;
        //private string filler = "";
        //private string filler = "cycle #";
        private int h3_cycle;
        //private string filler = "  BATCH NO.";
        private string h3_batch_nbr_grp;
        private int h3_clinic1;
        private string h3_doc_nbr;
        private int h3_week;
        private int h3_day;
        //private string filler = "";
        //private string filler = "FOR THE PERIOD ENDING:";
        private int h3_period_end_yy;
        //private string filler = "/";
        private int h3_period_end_mm;
        //private string filler = "/";
        private int h3_period_end_dd;
        //private string filler = ""; 

        //private string h4_head_grp;
        /*private string filler = "   CLAIM       PATIENT     PAT";
        private string filler = "IENT ID/   DOCTOR  DIAG   REF";
        private string filler = " DR HOSP    LOCATION AG  P  RE";
        private string filler = "FERENCE  ADM DATE"; */

        //private string h5_head_grp;
        /*private string filler = "  NUMBER    DP ACRONYM     CHA";
        private string filler = "RT NUMBER    NBR   CODE   (CON";
        private string filler = "SEC. DATE)   OMA CD  AJ     RS";
        private string filler = "N & SRV  SVC DATE     OMA";
        private string filler = " ohip";*/

        //private string t1_head_grp;
        /*private string filler = "";
        private string filler = "NUMBER";
        private string filler = "TOTAL";*/

        //private string t2_head_grp;
        /*private string filler = "";
        private string filler = "OF";
        private string filler = "of $";*/

        //private string t3_head_grp;
        /*private string filler = "";
        private string filler = "SERVICES";
        private string filler = "INPUT";*/

        //private string t4_head_grp;
        //private string filler = "";
        //private string filler = "CLINIC";
        private int t4_clinic_nbr;
        /*private string filler = "";
        private string filler = "---------------";
        private string filler = "BATCH   CONTROL   FILE";
        private string filler = "-------------";
        private string filler = "------------------";
        private string filler = "claims   master-----------------"; */

        //private string t5_head_grp;
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
        private string filler = "SVC'S"; */

        //private string print_line_grp;
        //'private string l1_print_line_grp;
        private string l1_batch_nbr_grp;
        private int l1_clinic1;
        private string l1_doc_nbr;
        private int l1_week;
        private int l1_day;
        private string l1_dash;
        private int l1_claim_nbr;
        private string l1_slash;
        private int l1_doc_dept;
        private string filler;
        private string l1_patient_acronym_grp;
        private string l1_patient_acronym6;
        private string l1_patient_acronym3;
        private string l1_pat_id_chart_id;
        private string l1_doc_nbr2;
        //private string filler;
        private int l1_diag_code;
        //private string filler;
        private int l1_refer_doc_nbr;
        //private string filler;
        private int l1_hosp;
        //private string filler;
        private string l1_location;
        //private string filler;
        private int l1_agent_cd;
        //private string filler;
        private string l1_pat_in_out;
        //private string filler;
        private string l1_reference;
        private string l1_admit_date_grp;
        private int l1_admit_date_yy;
        private string l1_slash1;
        private int l1_admit_date_mm;
        private string l1_slash2;
        private int l1_admit_date_dd;
        //private string filler;
        private string l1_brace_l1;
        private decimal l1_ar_oma;
        private string l1_brace_r1;
        private string l1_brace_l2;
        private decimal l1_ar_ohip;
        private string l1_brace_r2;
        //private string l2_print_line_grp;
        //private string filler;
        private string[] l2_consecutive_dates = new string[4];
        //private string[] filler = new string[4];
        private int[] l2_sv_nbr = new int[4];
        private int[] l2_sv_day = new int[4];
        private string[] l2_sv_day_alpha = new string[4];
        //private string[] filler = new string[4];
        private string l2_oma_cd;
        private string l2_oma_suff;
        private string l2_adj_cd;
        private string l2_card_colour;
        private string l2_rsn;
        //private string filler;
        private int l2_srv;
        //private string filler;
        private string l2_svc_date_grp;
        private int l2_svc_date_yy;
        private string l2_slash1;
        private int l2_svc_date_mm;
        private string l2_slash2;
        private int l2_svc_date_dd;
        //private string filler;
        private decimal l2_fee_oma;
        //private string filler;
        private decimal l2_fee_ohip;
        //private string filler;
        private string l3_print_line_grp;
        //private string filler;
        private decimal l3_fee_total_oma;
        //private string filler;
        private decimal l3_fee_total_ohip;
        //private string filler;
        private string l4_print_line_grp;
        private string l4_claim_desc;
        //private string filler;
        //private string t1_print_line_grp;
        //private string filler;
        private string t1_total_lit;
        private int t1_nbr_services;
        //private string filler;
        private decimal t1_amt_input;
        //private string filler;
        private string t2_print_line_grp;
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
        private int t2_detail_5;
        //private string filler;
        private decimal t2_detail_6;
        //private string filler;
        private decimal t2_detail_7;
        //private string filler;
        private decimal t2_detail_8;
        //private string filler;
        private int t2_detail_9;
        //private string filler;
        private int t2_detail_10;
        private string blank_line;

        private string hosp_table_grp;
        private string hosp_values_grp;
        /*private string filler = "A1992";
        private string filler = "B1160";
        private string filler = "C1972";
        private string filler = "D1557";
        private string filler = "E1146";
        private string filler = "F3361";
        private string filler = "G1982";
        private string filler = "H1983";
        private string filler = "I3309";
        private string filler = "J2003";
        private string filler = "K1076";
        private string filler = "L1538";
        private string filler = "M1994";
        private string filler = "N1591";
        private string filler = "O1172";
        private string filler = "P1524";
        private string filler = "Q3446";
        private string filler = "R1978";
        private string filler = "S2006";
        private string filler = "T1406";
        private string filler = "U1542";
        private string filler = "V1149";
        private string filler = "W0000";
        private string filler = "X1082";
        private string filler = "Y1020";
        private string filler = "Z1987";
        private string filler = "11965";
        private string filler = "21969";
        private string filler = "33401";
        private string filler = "42001";
        private string filler = "51966";
        private string filler = "61967";
        private string filler = "73409";
        private string filler = "83642";
        private string filler = "93251"; */
        private string hosp_values_r_grp;
        private string[] hosp_code_nbr = new string[36];
        private string[] hosp_code = { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] hosp_nbr = { "","1992","1160", "1972", "1557", "1146", "3361", "1982", "1983", "3309", "2003", "1076", "1538", "1994", "1591", "1172", "1524", "3446",
                                         "1978", "2006", "1406", "1542", "1149", "0000", "1082", "1020", "1987","1965","1969","3401","2001","1966","1967","3409","3642","3251" };
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
        private int debug_ctr;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "12",Col = 30,Data1 = "CONTINUE (Y/N) ?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-prog-in-prog.",Line = "14",Col = 30,Data1 = "R002B IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 1,Data1 = "ERROR IN ACCESSING PAT MSTR - KEY = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(16)",MaxLength = 16,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "key_pat_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "NUMBER OF BATCTRL-FILE ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_batctrl_file_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "9",Col = 20,Data1 = "NUMBER OF CLMHDR ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "9",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_claims_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "11",Col = 20,Data1 = "NUMBER OF PATIENT MSTR ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "11",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_pat_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM R002B ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 49,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 56,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "PRINT REPORTS FOUND IN - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(6)",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(6)",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

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

        private void err_pat_mstr_file_section()
        {

            //     use after standard error procedure on pat-mstr.;
        }

        private void err_pat_mstr()
        {

            common_status_file = status_cobol_pat_mstr;
            //     display file-pat-status-display.;
            Console.WriteLine("ERROR IN ACCESSING PAT MSTR - KEY = " + key_pat_mstr + " FILE STATUS = " + common_status_file);
            //     stop "PROGRAM ABORTED - HIT NEWLINE".;
            Console.WriteLine("PROGRAM ABORTED - HIT NEWLINE");
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void end_declaratives()
        {

        }

        private void main_line_section()
        {

        }

        //  public void mainline(string wsReply)
        public void mainline()
        {
            Util.Trakker(++debug_ctr, "mainline");
            try
            {

                objPrint1_record = null;
                objPrint1_record = new Print1_record();

                objPrint2_record = null;
                objPrint2_record = new Print2_record();

                objBatctrl_rec = null;
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();

                Batctrl_rec_Collection = null;
                Batctrl_rec_Collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

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

                objPat_mstr_rec = null;
                objPat_mstr_rec = new F010_PAT_MSTR();

                objPrintFile1 = null;
                objPrintFile1 = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_1);

                objPrintFile2 = null;
                objPrintFile2 = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_2);

               // ws_reply = wsReply;

                // perform aa0-initialization		thru 	aa0-99-exit.;
                aa0_initialization();
                do
                {
                    aa0_10_continue_y_n();
                    aa0_99_exit();

                    // perform ab0-processing		thru 	ab0-99-exit.;
                    ab0_processing();
                    ab0_10_claim_loop();
                    ab0_99_exit();
                }
                while (Util.Str(eof_batctrl_file).ToUpper() != "Y");

                 //  perform az0-end-of-job		thru 	az0-99-exit.;
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
                if (objPrintFile1 != null)
                    objPrintFile1.Close();

                if (objPrintFile2 != null)
                    objPrintFile2.Close();
            }
        }

        private void aa0_initialization()
        {
            Util.Trakker(++debug_ctr, "aa0_initialization");

            //     accept sys-date			from 	date.;
            sys_date_grp = Sysdate();  //DateTime.Now.ToString();
            sys_date_long_child = sys_date_grp.Substring(0, 4) + sys_date_grp.Substring(4, 2) + sys_date_grp.Substring(6, 2);    //DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = Util.NumInt(sys_date_grp.Substring(0, 4));  //DateTime.Now.Year;
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(sys_date_grp.Substring(0, 1));     // Util.NumInt(DateTime.Now.Year.ToString().Substring(0, 1));
            sys_y2 = Util.NumInt(sys_date_grp.Substring(1, 1)); // Util.NumInt(DateTime.Now.Year.ToString().Substring(1, 1));
            sys_y3 = Util.NumInt(sys_date_grp.Substring(2, 1));  //Util.NumInt(DateTime.Now.Year.ToString().Substring(2, 1));
            sys_y4 = Util.NumInt(sys_date_grp.Substring(3, 1));  //Util.NumInt(DateTime.Now.Year.ToString().Substring(3, 1));
            sys_mm = Util.NumInt(sys_date_grp.Substring(4, 2));  //DateTime.Now.Month;
            sys_dd = Util.NumInt(sys_date_grp.Substring(6, 2));  //DateTime.Now.Day;

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
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
            Console.WriteLine("CONTINUE(Y / N) ? " + ws_reply);
        }

        private void aa0_10_continue_y_n()
        {           
            Util.Trakker(++debug_ctr, "aa0_10_continue_y_n");

            if (Util.Str(ws_reply).ToUpper() != "Y")
            {

                //     accept scr-reply.;
                ws_reply = Console.ReadLine();

                // if ws-reply =   "Y" or "N" then            
                if (Util.Str(ws_reply).ToUpper().Equals("Y"))
                {
                    // 	  if ws-reply = "Y" then            
                    if (Util.Str(ws_reply).ToUpper().Equals("Y"))
                    {
                        // 	     next sentence;
                    }
                    else
                    {
                        // 	      stop run;
                        throw new Exception(endOfJob);
                    }
                }
                else
                {
                    err_ind = 1;
                    //  perform za0-common-error	thru 	za0-99-exit;
                    za0_common_error();
                    za0_99_exit();

                    //  go to aa0-10-continue-y-n.;
                    aa0_10_continue_y_n();
                    return;
                }

                //     display scr-prog-in-prog.;
                Console.WriteLine("R002B IN PROGRESS");

                //  open input	batch-ctrl-file;
                // 		claims-mstr;
                // 		pat-mstr;
                // 		iconst-mstr.;
                //     open output print-file-1;
                // 		print-file-2.;

                //counters = 0;
                ctr_batctrl_file_reads = 0;
                ctr_claims_mstr_reads = 0;
                ctr_pat_mstr_reads = 0;
                ctr_fee_oma = 0;
                ctr_fee_ohip = 0;

                claim_nbr = 0;
                ctr_page_1 = 0;
                ctr_page_2 = 0;
            }

            //tbl_totals = 0;
            tbl_totals_grp = "0";
            tbl_bat_type_and_tots = new string[9];
            tbl_agent_and_sums = new string[9, 12];
            tbl_tot = new decimal[9, 12, 11];

            last_page_flag = "N";
            // perform xb0-reset-batch-totals	thru	xb0-99-exit.;
            xb0_reset_batch_totals();
            xb0_99_exit();

            //print_line = "";
            MoveSpacesToPrintLine();

            blank_line = "";

            h1_run_yy = Util.Str(run_yy);
            h1_run_mm = Util.Str(run_mm);
            h1_run_dd = Util.Str(run_dd);

            //objBatctrl_rec.batctrl_batch_nbr = "";

            // start batch-ctrl-file key is greater than or equal to key-batctrl-file;
            // 	    invalid key;
            //           err_ind = 4;
            // 	         perform za0-common-error	thru 	za0-99-exit;
            // 	         go to az0-end-of-job.;

            isRetrieving = false;
          

            Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = "",
                WhereBatctrl_batch_status = "0"
                
            }.Collection_Using_Start_Key_BatCtrl_File(ref isRetrieving, Batctrl_rec_Collection);

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

            //  perform aa1-sel-read-next-batctrl	thru 	aa1-99-exit;
            // 	       until   eof-batctrl-file = "Y";
            // 	          or valid-rec.;

            do
            {
                aa1_sel_read_next_batctrl();
                aa1_99_exit();
            } while (Util.Str(eof_batctrl_file).ToUpper() != "Y" && !Util.Str(flag_rec).Equals(valid_rec));


            //  if eof-batctrl-file = "Y" then            
            if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y"))
            {
                // 	     perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            batctrl_clm_offset = ss_batctrl_offset;
            //     perform sa2-add-batch-totals	thru 	sa2-99-exit.;
            sa2_add_batch_totals();
            sa2_99_exit();

            //     perform xd0-hold-clinic-info	thru	xd0-99-exit.;
            xd0_hold_clinic_info();
            xd0_99_exit();

            // perform aa11-read-claim		thru 	aa11-99-exit.;
            aa11_read_claim();
            aa11_99_exit();
        }

        private void aa0_99_exit()
        {
            Util.Trakker(++debug_ctr, "aa0_99_exit");
            //     exit.;
        }

        private void aa1_sel_read_next_batctrl()
        {
            Util.Trakker(++debug_ctr, "aa1_sel_read_next_batctrl");

            // if batctrl-batch-status =    "0" then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_STATUS) == "0")                      
            {
                flag_rec = "Y";
                //   perform xc0-batch-heading-info	thru 	xc0-99-exit;
                xc0_batch_heading_info();
                xc0_99_exit();

                //  go to aa1-99-exit.;
                aa1_99_exit();
                return;
            }

            //  read batch-ctrl-file next;
            // 	     at end;
            //        err_ind = 6;
            //        eof_batctrl_file = "Y";
            // 	      go to aa1-99-exit.;

            //     add 1				to 	ctr-batctrl-file-reads.;

            if ( Batctrl_rec_Collection.Count() == 0)
            {
                err_ind = 6;
                eof_batctrl_file = "Y";
                // go to aa1-99-exit.;
                aa1_99_exit();
                return;
            }
            else
            {
                if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
                {
                    err_ind = 6;
                    eof_batctrl_file = "Y";
                    // go to aa1-99-exit.;
                    aa1_99_exit();
                    return;
                }
                else
                {
                    objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];
                    ctr_batctrl_file_reads++;
                }
            }
        }

        private void aa1_99_exit()
        {
            Util.Trakker(++debug_ctr, "aa1_99_exit");
            //     exit.;
        }

        private void aa11_read_claim()
        {
            Util.Trakker(++debug_ctr, "aa11_read_claim");
            // perform aa2-read-clmhdr		thru 	aa2-99-exit.;
            aa2_read_clmhdr();
            aa2_99_exit();

            // if (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) then            
            if (Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR))
            {
                err_ind = 8;
                miss_batch_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR);
                miss_f002_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR); // clmhdr_orig_batch_nbr;
                miss_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);  // clmhdr_orig_claim_nbr;
                //  perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            // if (clmhdr-date-period-end not = batctrl-date-period-end) then;            
            if (Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                err_ind = 10;
                wrong_batch_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR);
                wrong_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);
                wrong_f001_ped = Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END);
                wrong_f002_ped = Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END);

                // perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // 	go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }
        }

        private void aa11_99_exit()
        {
            Util.Trakker(++debug_ctr, "aa11_99_exit");
            //     exit.;
        }

        private void aa2_read_clmhdr()
        {
            Util.Trakker(++debug_ctr, "aa2_read_clmhdr");
            //objClaim_header_rec.clmhdr_clai clmhdr_claim_id = 0;
            objClaim_detail_rec.CLMHDR_BATCH_NBR = "";
            objClaim_detail_rec.CLMHDR_CLAIM_NBR = 0;
            objClaim_detail_rec.CLMHDR_ADJ_OMA_CD = "0000";
            objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF = "0";
            objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR = "0";

            //objClaim_header_rec.clmhdr_batch_nbr = objBatctrl_rec.batctrl_batch_nbr;
            objClaim_detail_rec.CLMHDR_BATCH_NBR = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR);

            //objClaim_header_rec.clmhdr_claim_nbr = 1;
            objClaim_detail_rec.CLMHDR_CLAIM_NBR = 1;

            //objClaims_mstr_dtl_rec.clmdtl_b_key_type = "B";
            objClaim_detail_rec.KEY_CLM_TYPE = "B";

            //objClaims_mstr_dtl_rec.clmdtl_b_data = objClaim_header_rec.clmhdr_claim_id;
            objClaim_detail_rec.CLMDTL_BATCH_NBR = Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR);
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = Util.NumDec(objClaim_detail_rec.CLMHDR_CLAIM_NBR);
            objClaim_detail_rec.CLMDTL_OMA_CD = Util.Str(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD);
            objClaim_detail_rec.CLMDTL_OMA_SUFF = Util.Str(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF);
            objClaim_detail_rec.CLMDTL_ADJ_NBR = Util.NumDec(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR);

            // start claims-mstr key is greater than or equal to key-claims-mstr;
            //   	invalid key;
            //      err_ind = 7;
            // 	    perform za0-common-error	thru 	za0-99-exit;
            // 	    go to az0-end-of-job.;

            //     read claims-mstr next.;

            objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL //F002_CLAIMS_MSTR_HDR
            {
                WhereKey_clm_type = objClaim_detail_rec.KEY_CLM_TYPE,
               /* WhereClmhdr_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,
                WhereClmhdr_claim_nbr = objClaim_detail_rec.CLMDTL_CLAIM_NBR,
                WhereClmhdr_adj_oma_cd = objClaim_detail_rec.CLMDTL_OMA_CD,
                WhereClmhdr_adj_oma_suff = objClaim_detail_rec.CLMDTL_OMA_SUFF,
                WhereClmhdr_adj_adj_nbr = Util.Str(objClaim_detail_rec.CLMDTL_ADJ_NBR) */
                WhereKey_clm_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,
                WhereKey_clm_claim_nbr = objClaim_detail_rec.CLMDTL_CLAIM_NBR,
                WhereKey_clm_serv_code = objClaim_detail_rec.CLMDTL_OMA_CD + objClaim_detail_rec.CLMDTL_OMA_SUFF,
                WhereKey_clm_adj_nbr = Util.Str(objClaim_detail_rec.CLMDTL_ADJ_NBR)
            }.Collection_HDR_DTL_INNERJOIN_ReadStart();  //Collection_ReadStart();

            if (objClaim_detail_rec == null)
            {
                err_ind = 7;
                //  perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            // if status-cobol-claims-mstr = 23 or 99 then            
            //     err_ind = 7;
            // 	   perform za0-common-error	thru 	za0-99-exit;
            // 	   go to az0-end-of-job.;

            // 23- record not found
            // 99 - record lock 
            if (Util.NumInt(status_cobol_claims_mstr) == 23 || Util.NumInt(status_cobol_claims_mstr) == 99)  // todo... ????
            {
                err_ind = 7;
                //perform za0-common - error    thru za0-99 - exit;
                za0_common_error();
                za0_99_exit();

                az0_end_of_job();
                return;
            }

            //  if clmdtl-b-key-type not = "B"  then      
            if (objClaim_detail_rec.KEY_CLM_TYPE != "B")
            {
                err_ind = 7;
                //  perform za0-common-error	thru 	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            //     add 1				to 	ctr-claims-mstr-reads.;
            ctr_claims_mstr_reads++;

            hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR); //clmhdr_orig_batch_nbr;
            hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);  //clmhdr_orig_claim_nbr;
            hold_clmhdr_status_ohip = Util.Str(objClaim_detail_rec.CLMHDR_STATUS_OHIP); //clmhdr_status_ohip;
        }

        private void aa2_99_exit()
        {
            Util.Trakker(++debug_ctr, "aa2_99_exit");
            //     exit.;
        }

        private void az0_end_of_job()
        {
            Util.Trakker(++debug_ctr, "az0_end_of_job");

            //  perform xc1-add-to-fin-totals 	thru	xc1-99-exit.;
            xc1_add_to_fin_totals();
            xc1_99_exit();

            //   perform ze0-move-and-print-fin-tot	thru	ze0-99-exit.;
            ze0_move_and_print_fin_tot();
            ze0_99_exit();

            //     close batch-ctrl-file;
            // 	  claims-mstr;
            // 	  pat-mstr;
            // 	  iconst-mstr;
            // 	  print-file-1;
            // 	  print-file-2.;
            //     display blank-screen.;

            //     accept sys-time			from 	time.;            
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            //     display scr-closing-screen.;
            Console.WriteLine("NUMBER OF BATCTRL-FILE ACCESSES = " + ctr_batctrl_file_reads);
            Console.WriteLine("NUMBER OF CLMHDR ACCESSES = " + ctr_claims_mstr_reads);
            Console.WriteLine("NUMBER OF PATIENT MSTR ACCESSES = " + ctr_pat_mstr_reads);
            Console.WriteLine("PROGRAM R002B ENDING");
            Console.WriteLine(sys_yy + "/" + sys_mm + "/" + sys_dd + "  " + sys_hrs + ":" + sys_min);
            Console.WriteLine("PRINT REPORTS FOUND IN - " + print_file_name_1 + "  " + print_file_name_2);

            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {
            Util.Trakker(++debug_ctr, "az0_99_exit");
            //     exit.;
        }

        private void ab0_processing()
        {
            Util.Trakker(++debug_ctr, "ab0_processing");

            // if (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr)  or (clmhdr-date-period-end not = batctrl-date-period-end)  then     
            if (Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR) || Util.NumInt(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.NumInt(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                //  perform fa0-print-and-zero-batch-tots thru	fa0-99-exit;
                fa0_print_and_zero_batch_tots();
                fa0_99_exit();

                //  perform ga0-read-next-batch	thru 	ga0-99-exit;
                ga0_read_next_batch();
                ga0_99_exit();

                // 	    if eof-batctrl-file = "Y" then;      
                if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y"))
                {
                    // 	perform xe0-print-clinic-totals thru	xe0-99-exit
                    xe0_print_clinic_totals();
                    xe0_99_exit();

                    //  go to ab0-99-exit;
                    ab0_99_exit();
                    return;
                }
                else
                {
                    // 	perform xb0-reset-batch-totals thru 	xb0-99-exit            
                    xb0_reset_batch_totals();
                    xb0_99_exit();

                    // 	  if batctrl-bat-clinic-nbr-1-2  not = hold-clinic-nbr then            
                    if (Util.NumInt(objBatctrl_rec.BATCTRL_BATCH_NBR.PadRight(8, ' ').Substring(0, 2)) != hold_clinic_nbr)
                    {
                        //  perform xe0-print-clinic-totals thru	xe0-99-exit;            
                        xe0_print_clinic_totals();
                        xe0_99_exit();

                        //  perform xc1-add-to-fin-totals thru	xc1-99-exit            
                        xc1_add_to_fin_totals();
                        xc1_99_exit();

                        // 	perform xf0-zero-clinic-totals thru	xf0-99-exit            
                        xf0_zero_clinic_totals();
                        xf0_99_exit();

                        // 	perform xd0-hold-clinic-info thru    xd0-99-exit;            
                        xd0_hold_clinic_info();
                        xd0_99_exit();

                        // 	perform xc0-batch-heading-info thru	xc0-99-exit;            
                        xc0_batch_heading_info();
                        xc0_99_exit();

                        batctrl_clm_offset = ss_batctrl_offset;

                        // 	perform sa2-add-batch-totals thru 	sa2-99-exit            
                        sa2_add_batch_totals();
                        sa2_99_exit();
                    }
                    else
                    {
                        batctrl_clm_offset = ss_batctrl_offset;
                        //  perform sa2-add-batch-totals thru 	sa2-99-exit;            
                        sa2_add_batch_totals();
                        sa2_99_exit();
                    }
                }
            }
            else
            {
                //   	next sentence.;
            }

            //  perform ca1-move-print-hdr		thru 	ca1-99-exit.;
            ca1_move_print_hdr();
            ca1_99_exit();

            eof_claims_dtl = "N";
            first_desc = "Y";
        }

        private void ab0_10_claim_loop()
        {
            Util.Trakker(++debug_ctr, "ab0_10_claim_loop");

            //  perform da0-read-dtl-next-clm	thru 	da0-99-exit.;
            da0_read_dtl_next_clm();
            da0_99_exit();

            //  if eof-claims-dtl = "N" then;            
            if (Util.Str(eof_claims_dtl).ToUpper() == "N")
            {
                // 	   perform da1-move-print-dtl	thru 	da1-99-exit;
                da1_move_print_dtl();
                da1_99_exit();
                // 	   go to ab0-10-claim-loop.;
                ab0_10_claim_loop();
                return;
            }

            //  if first-desc = "Y" then            
            if (Util.Str(first_desc).ToUpper().Equals("Y"))
            {
                // 	    perform ea0-print-claims-totals	thru 	ea0-99-exit.;
                ea0_print_claims_totals();
                ea0_99_exit();
            }

            //  if eof-claims-mstr = "N" then            
            if (Util.Str(eof_claims_mstr).ToUpper().Equals("N"))
            {
                // 	    go to ab0-processing;
                ab0_processing();
                return;
            }
            else
            {
                // perform fa0-print-and-zero-batch-tots thru 	fa0-99-exit;
                fa0_print_and_zero_batch_tots();
                fa0_99_exit();

                //  perform xe0-print-clinic-totals	thru 	xe0-99-exit.;
                xe0_print_clinic_totals();
                xe0_99_exit();
            }
        }

        private void ab0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ab0_99_exit");
            //     exit.;
        }

        private void ac0_check_nbr_claims_field()
        {
            Util.Trakker(++debug_ctr, "ac0_check_nbr_claims_field");

            // if batctrl-nbr-claims-in-batch not numeric or  batctrl-nbr-claims-in-batch = zero then;            
            if (!Util.IsNumeric(Util.NumDec(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH).ToString()) || Util.NumInt(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH) == 0)
            {
                objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH = Util.NumDec(objBatctrl_rec.BATCTRL_LAST_CLAIM_NBR);
            }
        }

        private void ac0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ac0_99_exit");
            //     exit.;
        }

        private void ba0_write_detail_line()
        {
            Util.Trakker(++debug_ctr, "ba0_write_detail_line");

            //  add nbr-lines-to-advance		to 	ctr-line.;
            ctr_line += nbr_lines_to_advance;

            // if ctr-line > max-nbr-lines then;            
            if (ctr_line > max_nbr_lines)
            {
                // 	  perform xa0-headings		thru 	xa0-99-exit.;
                xa0_headings();
                xa0_99_exit();
            }

            // write print1-record    from print-line after advancing nbr-lines-to-advance line.;            
            for (int i = 1; i < nbr_lines_to_advance; i++)
            {
                objPrintFile1.print(true);
            }

            objPrint1_record.Print1_record1 = print_line_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();
            nbr_lines_to_advance = 0;
        }

        private void ba0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ba0_99_exit");
            //     exit.;
        }

        private void ca0_read_next_batctrl()
        {
            Util.Trakker(++debug_ctr, "ca0_read_next_batctrl");

            // if (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr)  or (clmhdr-date-period-end not = batctrl-date-period-end) then            
            if (Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR) || Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                // 	   perform fa0-print-and-zero-batch-tots thru 	fa0-99-exit;            
                fa0_print_and_zero_batch_tots();
                fa0_99_exit();
                //  perform ga0-read-next-batch	thru 	ga0-99-exit;
                ga0_read_next_batch();
                ga0_99_exit();
                // 	   if eof-batctrl-file = "Y" then            
                if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y"))
                {
                    // 	      go to ca0-99-exit;
                    ca0_99_exit();
                    return;
                }
                else
                {
                    //  perform xb0-reset-batch-totals thru 	xb0-99-exit;            
                    xb0_reset_batch_totals();
                    xb0_99_exit();

                    //  perform xa0-headings	thru 	xa0-99-exit.;
                    xa0_headings();
                    xa0_99_exit();
                }
            }

            //     perform ca1-move-print-hdr		thru 	ca1-99-exit.;
            ca1_move_print_hdr();
            ca1_99_exit();
        }

        private void ca0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ca0_99_exit");
            //     exit.;
        }

        private void ca1_move_print_hdr()
        {
            Util.Trakker(++debug_ctr, "ca1_move_print_hdr");

            batctrl_clm_offset = ss_clmhdr_offset;
            //     perform sa0-add-clmhdr-totals	thru	sa0-99-exit.;
            sa0_add_clmhdr_totals();
            sa0_99_exit();

            // if ctr-line + 7  > max-nbr-lines then            
            if ((ctr_line + 7) > max_nbr_lines)
            {
                //      perform xa0-headings		thru 	xa0-99-exit.;
                xa0_headings();
                xa0_99_exit();
            }

            // if batctrl-batch-type =    "P" or "A" then        
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("P") || Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("A"))
            {
                l1_clinic1 = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8, ' ').Substring(0, 2)); //  clmhdr_orig_batch_nbr_1_2;
                l1_doc_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8, ' ').Substring(2, 3);  //clmhdr_orig_batch_nbr_4_6;
                l1_week = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR.PadRight(8, ' ').Substring(5, 2)); //clmhdr_orig_batch_nbr_7_8;
                l1_day = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR.PadRight(8, ' ').Substring(7, 1)); //clmhdr_orig_batch_nbr_9;
                l1_dash = "_";
                l1_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);  //clmhdr_orig_claim_nbr;
                nbr_lines_to_advance = 2;
                //  perform ba0-write-detail-line	thru 	ba0-99-exit;
                ba0_write_detail_line();
                ba0_99_exit();
                nbr_lines_to_advance = 1;
            }
            else
            {
                nbr_lines_to_advance = 2;
            }

            l1_clinic1 = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(0, 2));  //clmhdr_clinic_nbr_1_2;
            l1_doc_nbr = Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(2, 3); //clmhdr_doc_nbr;
            l1_day = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(7, 1)); //clmhdr_day;
            l1_week = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(5, 2)); //clmhdr_week;
            l1_dash = "_";
            l1_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_CLAIM_NBR);
            l1_slash = "/";
            l1_doc_dept = Util.NumInt(objClaim_detail_rec.CLMHDR_DOC_DEPT); //clmhdr_doc_dept;
            l1_patient_acronym6 = Util.Str(objClaim_detail_rec.CLMHDR_PAT_ACRONYM6); //clmhdr_pat_acronym6;
            l1_patient_acronym3 = Util.Str(objClaim_detail_rec.CLMHDR_PAT_ACRONYM3); //clmhdr_pat_acronym3;

            // if clmhdr-pat-key-data = spaces or " " then;            
            if (string.IsNullOrWhiteSpace(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA))
            {
                l1_pat_id_chart_id = "";
            }
            else
            {
                // 	  perform ya0-read-pat		thru	ya0-99-exit.;
                ya0_read_pat();
                ya0_99_exit();
            }

            l1_doc_nbr2 = Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8, ' ').Substring(2, 3);  //clmhdr_doc_nbr;
            l1_diag_code = Util.NumInt(objClaim_detail_rec.CLMHDR_DIAG_CD);  //clmhdr_diag_cd;
            l1_refer_doc_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_REFER_DOC_NBR);  //clmhdr_refer_doc_nbr;
            //  perform ca11-move-hosp		thru 	ca11-99-exit.;
            CA11_MOVE_HOSP();
            CA11_10_HOSP_LOOP();
            CA11_99_EXIT();

            l1_location = Util.Str(objClaim_detail_rec.CLMHDR_LOC);  //clmhdr_loc;
            l1_agent_cd = Util.NumInt(objClaim_detail_rec.CLMHDR_AGENT_CD); //clmhdr_agent_cd;
            l1_pat_in_out = Util.Str(objClaim_detail_rec.CLMHDR_I_O_PAT_IND);  //clmhdr_i_o_pat_ind;
            l1_reference = Util.Str(objClaim_detail_rec.CLMHDR_REFERENCE); //clmhdr_reference;
            l1_admit_date_yy = Util.NumInt(objClaim_detail_rec.CLMHDR_DATE_ADMIT.PadRight(8, ' ').Substring(0, 4));  //clmhdr_date_admit_yy;
            l1_slash1 = "/";
            l1_slash2 = "/";

            l1_admit_date_mm = Util.NumInt(objClaim_detail_rec.CLMHDR_DATE_ADMIT.PadRight(8, ' ').Substring(4, 2)); //clmhdr_date_admit_mm;
            l1_admit_date_dd = Util.NumInt(objClaim_detail_rec.CLMHDR_DATE_ADMIT.PadRight(8, ' ').Substring(6, 2));  //clmhdr_date_admit_dd;
            l1_brace_l1 = "[";
            l1_ar_oma = Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OMA); //clmhdr_tot_claim_ar_oma;
            l1_brace_r1 = "]";
            l1_brace_l2 = "[";
            l1_ar_ohip = Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);  //clmhdr_tot_claim_ar_ohip;
            l1_brace_r2 = "]";

            // if batctrl-batch-type = 'C' then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                // 	  add clmhdr-tot-claim-ar-oma	to 	act-sum-fee-oma-ohip;
                act_sum_fee_oma_ohip += Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OMA);
            }
            else
            {
                //    add clmhdr-tot-claim-ar-ohip	to 	act-sum-fee-oma-ohip.;
                act_sum_fee_oma_ohip += Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            }

            //  perform ba0-write-detail-line	thru 	ba0-99-exit.;
            ba0_write_detail_line();
            ba0_99_exit();
        }

        private void ca1_99_exit()
        {
            Util.Trakker(++debug_ctr, "ca1_99_exit");
            //     exit.;
        }

        // hosp_nbr_code_to_nbr.rtn
        private void CA11_MOVE_HOSP()
        {
            Util.Trakker(++debug_ctr, "CA11_MOVE_HOSP");

            //SUBS_HOSP = ZERO;
            subs_hosp = 0;
        }

        // hosp_nbr_code_to_nbr.rtn
        private void CA11_10_HOSP_LOOP()
        {
            Util.Trakker(++debug_ctr, "CA11_10_HOSP_LOOP");

            //     ADD 1			TO	SUBS-HOSP.;
            subs_hosp++;

            // IF CLMHDR-HOSP = HOSP-CODE (SUBS-HOSP) THEN            
            if (objClaim_detail_rec.CLMHDR_HOSP == hosp_code[subs_hosp])
            {
                l1_hosp = Util.NumInt(hosp_nbr[subs_hosp]);  //HOSP_NBR[SUBS_HOSP];            
                // 	  GO TO CA11-99-EXIT.;
                CA11_99_EXIT();
                return;
            }

            // IF SUBS-HOSP < 35 THEN;            
            if (subs_hosp < 35)
            {
                // 	  GO TO CA11-10-HOSP-LOOP;
                CA11_10_HOSP_LOOP();
                return;
            }
            else
            {
                l1_hosp = 0;
            }
        }

        // hosp_nbr_code_to_nbr.rtn
        private void CA11_99_EXIT()
        {
            Util.Trakker(++debug_ctr, "CA11_99_EXIT");
            //     EXIT.;
        }

        private void da0_read_dtl_next_clm()
        {
            Util.Trakker(++debug_ctr, "da0_read_dtl_next_clm");

            // read claims-mstr next at end            
            //      eof_claims_dtl = "Y";
            //      eof_claims_mstr = "Y";
            // 	    go to da0-99-exit.;

            objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL
            {
            }.Collection_HDR_DTL_INNERJOIN_ReadNext(objClaim_detail_rec);

            if (objClaim_detail_rec == null)
            {
                eof_claims_dtl = "Y";
                eof_claims_mstr = "Y";
                //  go to da0-99-exit.;
                da0_99_exit();
                return;
            }            
            ctr_claims_mstr_reads++;

            // if clmdtl-b-key-type not = "B" then;            
            if (Util.Str(objClaim_detail_rec.KEY_CLM_TYPE) != "B")
            {
                eof_claims_dtl = "Y";
                eof_claims_mstr = "Y";
                // go to da0-99-exit.;
                da0_99_exit();
                return;
            }

            // if clmdtl-adj-nbr not = 0 and batctrl-batch-type = "C"  then            
            if (Util.NumInt(objClaim_detail_rec.CLMDTL_ADJ_NBR) != 0 && Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                // 	   go to da0-read-dtl-next-clm.;
                da0_read_dtl_next_clm();
                return;
            }

            // if clmhdr-zeroed-area is numeric then;            
            if (Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD) && Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF) && Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR))
            {
                // 	   if clmhdr-zeroed-area = zero then;            
                if (Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD) == 0 && Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF) == 0 && Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR) == 0)
                {
                    hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR);  //clmhdr_orig_batch_nbr;
                    hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR); //clmhdr_orig_claim_nbr;
                    hold_clmhdr_status_ohip = Util.Str(objClaim_detail_rec.CLMHDR_STATUS_OHIP); //clmhdr_status_ohip;
                    eof_claims_dtl = "Y";
                    // 	      go to da0-99-exit;
                    da0_99_exit();
                    return;
                }
                else
                {
                    // 	      next sentence;
                }
            }
            else
            {
                // 	  next sentence.;
            }

            // if clmdtl-orig-batch-nbr not = hold-clmhdr-batch-nbr or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr then            
            if (Util.Str(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR) != Util.Str(hold_clmhdr_batch_nbr) || Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH) != Util.NumInt(hold_clmhdr_claim_nbr))
            {
                eof_claims_dtl = "Y";
            }
        }

        private void da0_99_exit()
        {
            Util.Trakker(++debug_ctr, "da0_99_exit");
            //     exit.;
        }

        private void da1_move_print_dtl()
        {
            Util.Trakker(++debug_ctr, "da1_move_print_dtl");

            // if clmdtl-oma-cd = "ZZZZ" then            
            if (objClaim_detail_rec.CLMDTL_OMA_CD.ToUpper().Equals("ZZZZ"))
            {
                // 	   if first-desc = "Y" then            
                if (Util.Str(first_desc).ToUpper().Equals("Y"))
                {
                    //     perform ea0-print-claims-totals thru 	ea0-99-exit            
                    ea0_print_claims_totals();
                    ea0_99_exit();
                    first_desc = "N";
                }
                else
                {
                    // 	       next sentence;
                }
            }
            else
            {
                //  perform da12-move-print-dtl	thru 	da12-99-exit;
                da12_move_print_dtl();
                da12_10_date_loop();
                da12_99_exit();

                //  perform da13-add-to-claim-totals thru 	da13-99-exit;            
                da13_add_to_claim_totals();
                da13_99_exit();

                //  go to da1-99-exit.;
                da1_99_exit();
                return;
            }

            //  perform da11-move-print-desc	thru 	da11-99-exit.;
            da11_move_print_desc();
            da11_99_exit();
        }

        private void da1_99_exit()
        {
            Util.Trakker(++debug_ctr, "da1_99_exit");
            //     exit.;
        }

        private void da11_move_print_desc()
        {
            Util.Trakker(++debug_ctr, "da11_move_print_desc");

            l4_claim_desc = Util.Str(objClaim_detail_rec.CLMDTL_DESC); //clmdtl_desc;
            nbr_lines_to_advance = 1;
            //  perform ba0-write-detail-line	thru 	ba0-99-exit.;
            ba0_write_detail_line();
            ba0_99_exit();
        }

        private void da11_99_exit()
        {
            Util.Trakker(++debug_ctr, "da11_99_exit");
            //     exit.;
        }

        private void da12_move_print_dtl()
        {
            Util.Trakker(++debug_ctr, "da12_move_print_dtl");
            subs = 1;
        }

        private void da12_10_date_loop()
        {
            Util.Trakker(++debug_ctr, "da12_10_date_loop");

            // add clmdtl-sv-nbr (subs)		to 	act-sum-nbr-serv.;
            act_sum_nbr_serv += Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, subs));

            //move clmdtl-sv - nbr(subs)       to l2-sv - nbr(subs).
            l2_sv_nbr[subs] = Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, subs));

            // if clmdtl-sv-day (subs) numeric then;
            if (Util.IsNumeric(CLMDTL_SV_DAY(objClaim_detail_rec, subs)))
            {
                //     move clmdtl-sv-day (subs)	to 	l2-sv-day (subs) 
                l2_sv_day[subs] = Util.NumInt(CLMDTL_SV_DAY(objClaim_detail_rec, subs));
            }
            else
            {
                //    move clmdtl-sv-day (subs)	to 	l2-sv-day-alpha (subs). 
                l2_sv_day_alpha[subs] = CLMDTL_SV_DAY(objClaim_detail_rec, subs);
            }

            // add 1				to 	subs.;
            subs++;

            // if subs < 4 then            
            if (subs < 4)
            {
                // 	  go to da12-10-date-loop.;
                da12_10_date_loop();
                return;
            }

            l2_oma_cd = Util.Str(objClaim_detail_rec.CLMDTL_OMA_CD); //clmdtl_oma_cd;
            l2_oma_suff = Util.Str(objClaim_detail_rec.CLMDTL_OMA_SUFF);
            l2_adj_cd = Util.Str(objClaim_detail_rec.CLMDTL_ADJ_CD);
            l2_rsn = Util.Str(hold_clmhdr_status_ohip);
            l2_srv = Util.NumInt(objClaim_detail_rec.CLMDTL_NBR_SERV);

            l2_svc_date_yy = Util.NumInt(objClaim_detail_rec.CLMDTL_SV_YY);  // clmdtl_sv_yy;
            l2_svc_date_mm = Util.NumInt(objClaim_detail_rec.CLMDTL_SV_MM);
            l2_svc_date_dd = Util.NumInt(objClaim_detail_rec.CLMDTL_SV_DD);
            l2_slash1 = "/";
            l2_slash2 = "/";

            l2_fee_oma = Util.NumDec(objClaim_detail_rec.CLMDTL_FEE_OMA);  //clmdtl_fee_oma;
            l2_fee_ohip = Util.NumDec(objClaim_detail_rec.CLMDTL_FEE_OHIP);  //clmdtl_fee_ohip;

            //     add clmdtl-nbr-serv			to 	act-sum-nbr-serv.;
            act_sum_nbr_serv += Util.NumInt(objClaim_detail_rec.CLMDTL_NBR_SERV);

            nbr_lines_to_advance = 1;

            //  perform ba0-write-detail-line	thru 	ba0-99-exit.;
            ba0_write_detail_line();
            ba0_99_exit();
        }

        private void da12_99_exit()
        {
            Util.Trakker(++debug_ctr, "da12_99_exit");
            //     exit.;
        }

        private void da13_add_to_claim_totals()
        {
            Util.Trakker(++debug_ctr, "da13_add_to_claim_totals");

            //     add clmdtl-fee-oma			to 	ctr-fee-oma.;
            ctr_fee_oma += Util.NumDec(objClaim_detail_rec.CLMDTL_FEE_OMA);

            //     add clmdtl-fee-ohip			to 	ctr-fee-ohip.;
            ctr_fee_ohip += Util.NumDec(objClaim_detail_rec.CLMDTL_FEE_OHIP);

            //     add batctrl-clm-offset, ss-nbr-svcs	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_nbr_svcs;

            //     add clmdtl-nbr-serv;
            // 	clmdtl-sv-nbr (1);
            // 	clmdtl-sv-nbr (2);
            // 	clmdtl-sv-nbr (3)		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;

            tbl_tot[ss_type, ss_agent, ss_temp1] += (Util.NumDec(objClaim_detail_rec.CLMDTL_NBR_SERV) + Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, 1)) + Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, 2)) + Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, 3)));

        }

        private void da13_99_exit()
        {
            Util.Trakker(++debug_ctr, "da13_99_exit");
            //     exit.;
        }

        private void ea0_print_claims_totals()
        {
            Util.Trakker(++debug_ctr, "ea0_print_claims_totals");

            l3_fee_total_oma = ctr_fee_oma;
            l3_fee_total_ohip = ctr_fee_ohip;

            //     add 1				to 	ctr-line.;
            ctr_line++;

            //     write print1-record from print-line after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = print_line_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();

            ctr_fee_oma = 0;
            ctr_fee_ohip = 0;
        }

        private void ea0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ea0_99_exit");
            //     exit.;
        }

        private void fa0_print_and_zero_batch_tots()
        {
            Util.Trakker(++debug_ctr, "fa0_print_and_zero_batch_tots");

            //     add 11					ctr-line;
            // 					giving 	total-lines.;

            total_lines = ctr_line + 11;

            // if total-lines > max-nbr-lines then;            
            if (total_lines > max_nbr_lines)
            {
                //  	write print1-record from t1-head after advancing page;                                
                objPrint1_record.Print1_record1 = t1_head_grp();
                objPrintFile1.PageBreak();
                objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);
            }
            else
            {
                // 	   write print1-record from t1-head after advancing 2 lines.;                
                objPrint1_record.Print1_record1 = t1_head_grp();
                objPrintFile1.print(true);
                objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);
            }

            //     write print1-record from t2-head after advancing 1 line.;            
            objPrint1_record.Print1_record1 = t2_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from t3-head after advancing 1 line.;            
            objPrint1_record.Print1_record1 = t3_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            t1_total_lit = "(AUDIT TOTALS)";
            t1_nbr_services = act_sum_nbr_serv;
            t1_amt_input = act_sum_fee_oma_ohip;
            //  write print1-record from t1-print-line after 2 lines.;              
            objPrint1_record.Print1_record1 = t1_print_line_grp();
            objPrintFile1.print(true);
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();

            t1_total_lit = "COMPUTER TOTALS";
            t1_nbr_services = Util.NumInt(objBatctrl_rec.BATCTRL_SVC_ACT);  //batctrl_svc_act;
            t1_amt_input = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_ACT);  //batctrl_amt_act;
            //     write print1-record from t1-print-line after 1 line.;            
            objPrint1_record.Print1_record1 = t1_print_line_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);
            //print_line = "";
            MoveSpacesToPrintLine();

            t1_total_lit = "BATCHING TOTALS";
            t1_nbr_services = Util.NumInt(objBatctrl_rec.BATCTRL_SVC_EST);  //batctrl_svc_est;
            t1_amt_input = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_EST); // batctrl_amt_est;
            //     write print1-record from t1-print-line after 2 lines.;            
            objPrint1_record.Print1_record1 = t1_print_line_grp();
            objPrintFile1.print(true);
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();

            t1_total_lit = "DIFFERENCE";
            //     subtract batctrl-svc-est		from 	batctrl-svc-act;
            // 					giving 	difference.;
            difference = Util.NumInt(objBatctrl_rec.BATCTRL_SVC_ACT) - Util.NumInt(objBatctrl_rec.BATCTRL_SVC_EST);
            t1_nbr_services = difference;
            //     subtract batctrl-amt-est		from 	batctrl-amt-act;
            // 					giving 	diff.;
            diff = Util.NumDec(objBatctrl_rec.BATCTRL_AMT_ACT) - Util.NumDec(objBatctrl_rec.BATCTRL_AMT_EST);
            t1_amt_input = diff;
            //     write print1-record			from 	t1-print-line after;
            // 					     	advancing 2 lines.;            
            objPrint1_record.Print1_record1 = t1_print_line_grp();
            objPrintFile1.print(true);
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();

            //  perform xb0-reset-batch-totals	thru	xb0-99-exit.;
            xb0_reset_batch_totals();
            xb0_99_exit();
        }

        private void fa0_99_exit()
        {
            Util.Trakker(++debug_ctr, "fa0_99_exit");
            //     exit.;
        }

        private void ga0_read_next_batch()
        {
            Util.Trakker(++debug_ctr, "ga0_read_next_batch");

            // read batch-ctrl-file next;
            // 	at end;
            //      eof_batctrl_file = "Y";
            // 	    go to ga0-99-exit.;

            if (Batctrl_rec_Collection.Count() == 0)
            {
                eof_batctrl_file = "Y";
                //go to ga0-99-exit.;
                ga0_99_exit();
                return;
            }
            else
            {
                if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
                {
                    eof_batctrl_file = "Y";
                    //go to ga0-99-exit.;
                    ga0_99_exit();
                    return;
                }
                else
                {
                    objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];
                    ctr_batctrl_file_reads++;
                }
            }

            flag_rec = "N";

            //  perform aa1-sel-read-next-batctrl	thru 	aa1-99-exit;
            // 	        until   eof-batctrl-file = "Y";
            // 	         or valid-rec.;

            do
            {
                aa1_sel_read_next_batctrl();
                aa1_99_exit();
            } while (Util.Str(eof_batctrl_file).ToUpper() != "Y" && !Util.Str(flag_rec).Equals(valid_rec));


            // if eof-batctrl-file = 'Y' then            
            if (Util.Str(eof_batctrl_file).ToUpper().Equals("Y"))
            {
                // 	   go to ga0-99-exit.;
                ga0_99_exit();
                return;
            }

            // if (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) or (clmhdr-date-period-end not = batctrl-date-period-end) then            
            if ((Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR) != Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR)) || (Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END)))
            {
                // 	  perform aa11-read-claim		thru 	aa11-99-exit.;
                aa11_read_claim();
                aa11_99_exit();
            }
        }

        private void ga0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ga0_99_exit");
            //     exit.;
        }

        private void sa0_add_clmhdr_totals()
        {
            Util.Trakker(++debug_ctr, "sa0_add_clmhdr_totals");

            // if clmhdr-adj-cd = "C" then;            
            if (Util.Str(objClaim_detail_rec.CLMHDR_ADJ_CD).ToUpper().Equals("C"))
            {
                // 	   subtract clmhdr-manual-and-tape-paymnts;
                // 					from	zero;
                // 					giving	clmhdr-manual-and-tape-paymnts.;
                objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS = 0 - Util.NumDec(objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            }

            //  perform sa1-find-ss-type 		thru	sa1-99-exit.;
            sa1_find_ss_type();
            sa1_99_exit();

            //  add  1, clmhdr-agent-cd		giving	ss-agent.;
            ss_agent = Util.NumInt(objClaim_detail_rec.CLMHDR_AGENT_CD) + 1;

            //  if ss-type not = ss-adj-r then            
            if (ss_type != ss_adj_r)
            {
                // 	    add batctrl-clm-offset, ss-net-a-r	giving ss-temp1;
                ss_temp1 = ss_net_a_r + batctrl_clm_offset;
                //      add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
                tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            }

            //  if ss-type not = ss-adj-a then            
            if (ss_type != ss_adj_a)
            {
                // 	    add batctrl-clm-offset, ss-net-rev	giving ss-temp1;
                ss_temp1 = batctrl_clm_offset + ss_net_rev;
                //      add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
                tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            }

            //     add batctrl-clm-offset, ss-cash		giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_cash;
            //     add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);

            // if ss-type = ss-pay-m then;            
            if (ss_type == ss_pay_m)
            {
                // 	   add batctrl-clm-offset, ss-net-rev	giving ss-temp1;
                ss_temp1 = batctrl_clm_offset + ss_net_rev;
                //     add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
                tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            }

            //     add batctrl-clm-offset, ss-nbr-claims	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_nbr_claims;
            //     add 1                  		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += 1;
        }

        private void sa0_99_exit()
        {
            Util.Trakker(++debug_ctr, "sa0_99_exit");
            //     exit.;
        }

        private void sa1_find_ss_type()
        {
            Util.Trakker(++debug_ctr, "sa1_find_ss_type");

            // if clmhdr-batch-type = "C" then;            
            //      ss_type = ss_claims;
            // else if clmhdr-batch-type = "A" then;            
            // 	    if clmhdr-adj-cd = "A" then            
            //          ss_type = ss_adj_a;
            // 	    else if clmhdr-adj-cd = "B" then            
            //           ss_type = ss_adj_b;
            // 		else;
            //           ss_type = ss_adj_r;
            //else if clmhdr-adj-cd = "M"  then            
            //     ss_type = ss_pay_m;
            //else;
            //    ss_type = ss_pay_c;

            // if clmhdr-batch-type = "C" then;            
            if (Util.Str(objClaim_detail_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("C"))
            {
                ss_type = ss_claims;
            }
            // else if clmhdr-batch-type = "A" then;            
            else if (Util.Str(objClaim_detail_rec.CLMHDR_BATCH_TYPE).ToUpper().Equals("A"))
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
            //else if clmhdr-adj-cd = "M"  then            
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
            Util.Trakker(++debug_ctr, " sa1_99_exit");

            //     exit.;
        }

        private void sa2_add_batch_totals()
        {
            Util.Trakker(++debug_ctr, "sa2_add_batch_totals");

            //     perform ac0-check-nbr-claims-field	thru	ac0-99-exit.;
            ac0_check_nbr_claims_field();
            ac0_99_exit();

            //    perform sa3-find-ss-type 		thru	sa3-99-exit.;
            sa3_find_ss_type();
            sa3_99_exit();


            //  if batctrl-batch-type = "P" and  batctrl-adj-cd     = "C" then    
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("P") && Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("C"))
            {
                // 	   subtract batctrl-manual-pay-tot		from	zero;
                // 						giving	batctrl-manual-pay-tot.;
                objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT = 0 - Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
            }

            //     add  1, batctrl-agent-cd		giving	ss-agent.;
            ss_agent = Util.NumInt(objBatctrl_rec.BATCTRL_AGENT_CD) + 1;

            //     add batctrl-clm-offset, ss-net-a-r		giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_net_a_r;
            //     add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_AR_DUE);
            //     add batctrl-clm-offset, ss-net-rev		giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_net_rev;
            //     add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_CALC_TOT_REV);
            //     add batctrl-clm-offset, ss-cash		giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_cash;
            //     add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_MANUAL_PAY_TOT);
            //     add batctrl-clm-offset, ss-nbr-claims	giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_nbr_claims;
            //     add batctrl-nbr-claims-in-batch             to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_NBR_CLAIMS_IN_BATCH);
            //     add batctrl-clm-offset, ss-nbr-svcs		giving ss-temp1.;
            ss_temp1 = batctrl_clm_offset + ss_nbr_svcs;
            //     add batctrl-svc-act              		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).;
            tbl_tot[ss_type, ss_agent, ss_temp1] += Util.NumDec(objBatctrl_rec.BATCTRL_SVC_ACT);
        }

        private void sa2_99_exit()
        {
            Util.Trakker(++debug_ctr, "sa2_99_exit");
            //     exit.;
        }

        private void sa3_find_ss_type()
        {
            Util.Trakker(++debug_ctr, "sa3_find_ss_type");

            // if batctrl-batch-type = "C" then;            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                ss_type = ss_claims;
            }
            // else if batctrl-batch-type = "A" then            
            else if (objBatctrl_rec.BATCTRL_BATCH_TYPE.ToUpper().Equals("A"))
            {
                // 	    if batctrl-adj-cd = "A" then            
                if (Util.Str(objBatctrl_rec.BATCTRL_ADJ_CD).ToUpper().Equals("A"))
                {
                    ss_type = ss_adj_a;
                }
                // 	    else if batctrl-adj-cd = "B" then            
                else if (objBatctrl_rec.BATCTRL_ADJ_CD.ToUpper().Equals("B"))
                {
                    ss_type = ss_adj_b;
                }
                else
                {
                    ss_type = ss_adj_r;
                }
            }
            // else if batctrl-adj-cd = "M" then            
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
            Util.Trakker(++debug_ctr, "sa3_99_exit");
            //     exit.;
        }

        private void tc1_roll_type_tot_to_grand()
        {
            Util.Trakker(++debug_ctr, "tc1_roll_type_tot_to_grand");

            ss_type_from = ss_type_tot;
            ss_type_to = ss_grand_tot;

            //  perform te0-roll-and-zero-totals	thru	te0-99-exit;
            // 	                varying  ss-agent-from;
            // 	                from  1;
            // 	                by    1;
            // 	               until    ss-agent-from > max-nbr-agents + 1.;

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
            Util.Trakker(++debug_ctr, "tc1_99_exit");
            //     exit.;
        }

        private void te0_roll_and_zero_totals()
        {
            Util.Trakker(++debug_ctr, "te0_roll_and_zero_totals");

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

        private void te0_99_exit()
        {
            Util.Trakker(++debug_ctr, "te0_99_exit");

            //     exit.;
        }

        private void tg0_move_vals_to_line()
        {
            Util.Trakker(++debug_ctr, "tg0_move_vals_to_line");

            //move tbl-tot(ss - type - from, ss - agent, 1)  to t2-detail - 1.
            t2_detail_1 = tbl_tot[ss_type_from, ss_agent, 1];
            //move tbl - tot(ss - type - from, ss - agent, 2)   to t2-detail - 2.
            t2_detail_2 = tbl_tot[ss_type_from, ss_agent, 2];
            //move tbl - tot(ss - type - from, ss - agent, 3)   to t2-detail - 3.
            t2_detail_3 = tbl_tot[ss_type_from, ss_agent, 3];
            //move tbl - tot(ss - type- from, ss - agent, 4)   to t2-detail - 4.
            t2_detail_4 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 4]);
            //move tbl - tot(ss - type - from, ss - agent, 5)   to t2-detail - 5.
            t2_detail_5 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 5]);
            //move tbl - tot(ss - type - from, ss - agent, 6)   to t2-detail - 6.
            t2_detail_6 = tbl_tot[ss_type_from, ss_agent, 6];
            //move tbl - tot(ss - type - from, ss - agent, 7)   to t2-detail - 7.
            t2_detail_7 = tbl_tot[ss_type_from, ss_agent, 7];
            //move tbl - tot(ss - type - from, ss - agent, 8)   to t2-detail - 8.
            t2_detail_8 = tbl_tot[ss_type_from, ss_agent, 8];
            //move tbl - tot(ss - type - from, ss - agent, 9)   to t2-detail - 9.
            t2_detail_9 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 9]);
            //move tbl - tot(ss - type - from, ss - agent, 10)  to t2-detail - 10.
            t2_detail_10 = Util.NumInt(tbl_tot[ss_type_from, ss_agent, 10]);
        }

        private void tg0_99_exit()
        {
            Util.Trakker(++debug_ctr, "tg0_99_exit");

            //     exit.;
        }

        private void tb0_write_line()
        {
            Util.Trakker(++debug_ctr, "tb0_write_line");

            //     add  nbr-lines-to-advance				to	ctr-line.;
            ctr_line += nbr_lines_to_advance;

            // if ctr-line > max-nbr-lines  then;
            if (ctr_line > max_nbr_lines)
            {
                //  	perform tc0-print-headings			thru	tc0-99-exit.;
                tc0_print_headings();
                tc0_99_exit();
            }

            //     write   print1-record  from l1-print-line   after advancing  nbr-lines-to-advance lines.;
            for (int i = 1; i < nbr_lines_to_advance; i++)
            {
                objPrintFile1.print(true);
            }

            objPrint1_record.Print1_record1 = t2_print_line(); //print_line_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write   print2-record  from l1-print-line   after advancing  nbr-lines-to-advance lines.;
            for (int i = 1; i < nbr_lines_to_advance; i++)
            {
                objPrintFile2.print(true);
            }

            objPrint2_record.Print2_record1 = t2_print_line(); //print_line_grp();
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            //print_line = "";
            MoveSpacesToPrintLine();
            nbr_lines_to_advance = 1;
        }

        private void tb0_99_exit()
        {
            Util.Trakker(++debug_ctr, "tb0_99_exit");
            //     exit.;
        }

        private void tc0_print_headings()
        {
            Util.Trakker(++debug_ctr, "tc0_print_headings");

            //  add 1				to	ctr-page-2.;
            ctr_page_2++;

            // if not-last-page then            
            if (Util.Str(last_page_flag).Equals(not_last_page))
            {
                h1_clinic_nbr = hold_clinic_nbr;
            }

            h1_page = ctr_page_2;
            h1_rpt_name = print_file_name_2;
            h1_batch_type = "";
            h1_rpt_type = "SUMMARY";
            //     write print2-record from h1-head 	after 	advancing page.;
            
            objPrintFile2.PageBreak();
            objPrint2_record.Print2_record1 = h1_head_grp();
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            //     write print2-record from h2-head 	after 	advancing 1 line.;            
            objPrint2_record.Print2_record1 = h2_head_grp();
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            h3_batch_nbr_grp = "";
            h3_clinic1 = 0;
            h3_doc_nbr = "";
            h3_week = 0;
            h3_day = 0;

            //   write print2-record from h3-head 	after 	advancing 1 line.;            
            objPrint2_record.Print2_record1 = h3_head_grp();
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            // if not-last-page then        
            if (last_page_flag.Equals(not_last_page))
            {
                t4_clinic_nbr = hold_clinic_nbr;
            }

            //     write print2-record from t4-head 	after 	advancing 2 lines.;            
            objPrint2_record.Print2_record1 = t4_head_grp();
            objPrintFile2.print(true);
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            //     write print2-record from t5-head 	after 	advancing 1 line.;            
            objPrint2_record.Print2_record1 = t5_head_grp();
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            //     write print2-record from blank-line after 	advancing 1 line.;
            objPrint2_record.Print2_record1 = new string(' ', 132);
            objPrintFile2.print(objPrint2_record.Print2_record1, 1, true);

            //     add 1				to	ctr-page-1.;
            ctr_page_1++;

            // if not-last-page then;            
            if (last_page_flag.Equals(not_last_page))
            {
                h1_clinic_nbr = hold_clinic_nbr;
            }

            h1_page = ctr_page_1;
            h1_rpt_name = print_file_name_1;
            h1_batch_type = "";
            h1_rpt_type = "DETAIL";
            //     write print1-record from h1-head 	after 	advancing page.;            
            objPrintFile1.PageBreak();
            objPrint1_record.Print1_record1 = h1_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from h2-head 	after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = h2_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            h3_batch_nbr_grp = "";
            h3_clinic1 = 0;
            h3_doc_nbr = "";
            h3_week = 0;
            h3_day = 0;

            //     write print1-record from h3-head 	after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = h3_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            // if not-last-page then;            
            if (last_page_flag.Equals(not_last_page))
            {
                t4_clinic_nbr = hold_clinic_nbr;
            }

            //     write print1-record from t4-head 	after 	advancing 2 lines.;            
            objPrint1_record.Print1_record1 = t4_head_grp();
            objPrintFile1.print(true);
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from t5-head 	after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = t5_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from blank-line after 	advancing 1 line.;
            objPrint1_record.Print1_record1 = new string(' ', 132);
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            ctr_line = 6;
            h1_rpt_name = print_file_name_1;
        }

        private void tc0_99_exit()
        {
            Util.Trakker(++debug_ctr, "tc0_99_exit");
            //     exit.;
        }

        private void xa0_headings()
        {
            Util.Trakker(++debug_ctr, "xa0_headings");

            //     add 1				to 	ctr-page-1.;
            ctr_page_1++;

            h1_rpt_name = print_file_name_1;
            h1_clinic_nbr = hold_clinic_nbr;
            h1_page = ctr_page_1;

            //     write print1-record from h1-head 	after 	advancing page.;            
            objPrint1_record.Print1_record1 = h1_head_grp();
            objPrintFile1.PageBreak();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from h2-head 	after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = h2_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from h3-head 	after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = h3_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from h4-head 	after 	advancing 2 lines.;            
            objPrint1_record.Print1_record1 = h4_head_grp();
            objPrintFile1.print(true);
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            //     write print1-record from h5-head 	after 	advancing 1 line.;            
            objPrint1_record.Print1_record1 = h5_head_grp();
            objPrintFile1.print(objPrint1_record.Print1_record1, 1, true);

            ctr_line = 6;
        }

        private void xa0_99_exit()
        {
            Util.Trakker(++debug_ctr, "xa0_99_exit");
            //     exit.;
        }

        private void xb0_reset_batch_totals()
        {
            Util.Trakker(++debug_ctr, "xb0_reset_batch_totals");

            act_sum_nbr_serv = 0;
            act_sum_fee_oma_ohip = 0;

            ctr_line = 98;
        }

        private void xb0_99_exit()
        {
            Util.Trakker(++debug_ctr, "xb0_99_exit");
            //     exit.;
        }

        private void xc0_batch_heading_info()
        {
            Util.Trakker(++debug_ctr, "xc0_batch_heading_info");

            // if batctrl-batch-type = "C" then            
            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("C"))
            {
                h1_batch_type = "CLAIMS";
            }
            // else if batctrl-batch-type = "P" then            
            else if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_TYPE).ToUpper().Equals("P"))
            {
                h1_batch_type = "PAYMENT";
            }
            else
            {
                h1_batch_type = "ADJUSTMENT";
            }

            h3_clinic1 = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2));  //batctrl_bat_clinic_nbr_1_2;
            h3_doc_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(2, 3);  //batctrl_bat_doc_nbr;
            h3_week = Util.NumInt(objBatctrl_rec.BATCTRL_BATCH_NBR.PadRight(8, ' ').Substring(5, 2));  //batctrl_bat_week;
            h3_day = Util.NumInt(objBatctrl_rec.BATCTRL_BATCH_NBR.PadRight(8, ' ').Substring(7, 1)); //batctrl_bat_day;
        }

        private void xc0_99_exit()
        {
            Util.Trakker(++debug_ctr, "xc0_99_exit");
            //     exit.;
        }

        private void xc1_add_to_fin_totals()
        {
            Util.Trakker(++debug_ctr, "xc1_add_to_fin_totals");

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
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	fin-tot-8.;
            fin_tot_8 += tbl_tot[ss_grand_tot, ss_agent_tot, 8];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	fin-tot-9.;
            fin_tot_9 += tbl_tot[ss_grand_tot, ss_agent_tot, 9];
            //     add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) to	fin-tot-10.;
            fin_tot_10 += tbl_tot[ss_grand_tot, ss_agent_tot, 10];
        }

        private void xc1_99_exit()
        {
            Util.Trakker(++debug_ctr, "xc1_99_exit");
            //     exit.;
        }

        private void xd0_hold_clinic_info()
        {
            Util.Trakker(++debug_ctr, "xd0_hold_clinic_info");

            hold_clinic_nbr = Util.NumInt(Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).PadRight(8, ' ').Substring(0, 2));  //batctrl_bat_clinic_nbr_1_2;

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = hold_clinic_nbr;

            //  read iconst-mstr;
            //  	invalid key;
            //         err_ind = 2;
            //  	    perform za0-common-error	thru za0-99-exit;
            //  	    go to az0-end-of-job.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = hold_clinic_nbr
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 2;
                //   perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-end-of-job.;
                az0_end_of_job();
                return;
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
            h3_cycle = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
            h3_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h3_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h3_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);
        }

        private void xd0_99_exit()
        {
            Util.Trakker(++debug_ctr, "xd0_99_exit");
            //     exit.;
        }

        private void xe0_print_clinic_totals()
        {
            Util.Trakker(++debug_ctr, "xe0_print_clinic_totals");

            ctr_line = 98;
            sw_printed_bat_type = "N";
            sw_printed_adj_type = "N";

            //     perform xe1-process-batch-totals	thru	xe1-99-exit;
            // 	    varying ss-type;
            // 	    from  1;
            // 	    by    1;
            // 	    until   ss-type > max-nbr-types.;

            ss_type = 1;
            do
            {
                xe1_process_batch_totals();
                xe1_99_exit();
                ss_type++;
            } while (ss_type <= max_nbr_lines);

            ss_type = ss_grand_tot;

            //  perform xe1-process-batch-totals	thru	xe1-99-exit.;
            xe1_process_batch_totals();
            xe1_99_exit();

            ctr_line = 98;
        }

        private void xe0_99_exit()
        {
            Util.Trakker(++debug_ctr, "xe0_99_exit");
            //     exit.;
        }

        private void xe1_process_batch_totals()
        {
            Util.Trakker(++debug_ctr, "xe1_process_batch_totals");

            //     perform xe11-prt-agent-vals-and-sum	thru	xe11-99-exit;
            // 	    varying ss-agent;
            // 	    from  1;
            // 	    by    1;
            // 	    until    ss-agent > max-nbr-agents.;

            ss_agent = 1;
            do
            {
                xe11_prt_agent_vals_and_sum();
                xe11_99_exit();
                ss_agent++;
            } while (ss_agent <= max_nbr_agents);


            // if ss-type not =  ss-claims  and ss-grand-tot  then       
            if (ss_type != ss_claims && ss_type != ss_grand_tot)
            {
                //   	if sw-printed-adj-type = "Y" then            
                if (Util.Str(sw_printed_adj_type).ToUpper().Equals("Y"))
                {
                    t2_desc_grp = " TOTAL";
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
                //    	next sentence.;
            }

            sw_printed_adj_type = "N";

            //  if ss-type not = ss-grand-tot then            
            if (ss_type != ss_grand_tot)
            {
                ss_type_from = ss_type;
                ss_type_to = ss_type_tot;
                //      perform te0-roll-and-zero-totals		thru	te0-99-exit;
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

            // if ss-type =    ss-claims or ss-adj-r  or ss-pay-c   or ss-grand-tot  then            
            // 	  if sw-printed-bat-type = "Y" then            
            //        sw_printed_bat_type = "N";
            //        nbr_lines_to_advance = 2;
            //        t2_desc = " TOTALS";
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
            // 		      perform tc1-roll-type-tot-to-grand;
            // 						thru	tc1-99-exit;
            // else if ss-type not = ss-grand-tot  then;            
            // 	        perform tc1-roll-type-tot-to-grand;
            // 	                          thru	tc1-99-exit.;

            // if ss-type =    ss-claims or ss-adj-r  or ss-pay-c   or ss-grand-tot  then     
            if (ss_type == ss_claims || ss_type == ss_adj_r || ss_type == ss_pay_c || ss_type == ss_grand_tot)
            {
                // 	  if sw-printed-bat-type = "Y" then           
                if (Util.Str(sw_printed_bat_type).ToUpper().Equals("Y"))
                {
                    sw_printed_bat_type = "N";
                    nbr_lines_to_advance = 2;
                    t2_desc_grp = " TOTALS";
                    // 	      if ss-type = ss-grand-tot then            
                    if (ss_type == ss_grand_tot)
                    {
                        ss_type_from = ss_grand_tot;
                        ss_agent = ss_agent_tot;
                        // 	      perform tg0-move-vals-to-line	thru	tg0-99-exit;
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
                        // 	         perform tg0-move-vals-to-line	thru	tg0-99-exit;
                        tg0_move_vals_to_line();
                        tg0_99_exit();
                        // 	         perform tb0-write-line		thru	tb0-99-exit;
                        tb0_write_line();
                        tb0_99_exit();

                        //       perform tc1-roll-type-tot-to-grand thru	tc1-99-exit;
                        tc1_roll_type_tot_to_grand();
                        tc1_99_exit();
                    }
                }
            }
            // else if ss-type not = ss-grand-tot  then;            
            else if (ss_type != ss_grand_tot)
            {
                // 	    perform tc1-roll-type-tot-to-grand thru	tc1-99-exit.;
                tc1_roll_type_tot_to_grand();
                tc1_99_exit();
            }
        }

        private void xe1_99_exit()
        {
            Util.Trakker(++debug_ctr, "xe1_99_exit");
            //     exit.;
        }

        private void xe11_prt_agent_vals_and_sum()
        {
            Util.Trakker(++debug_ctr, "xe11_prt_agent_vals_and_sum");

            //     add ss-nbr-claims, ss-offset	giving ss-temp1.;
            ss_temp1 = ss_nbr_claims + ss_offset;

            //  if tbl-tot (ss-type, ss-agent, ss-nbr-claims) 		    = zero  and tbl-tot (ss-type, ss-agent, ss-temp1 )  = zero then           
            if (tbl_tot[ss_type, ss_agent, ss_nbr_claims] == 0 && tbl_tot[ss_type, ss_agent, ss_temp1] == 0)
            {
                // 	    go to xe11-99-exit.;
                xe11_99_exit();
                return;
            }

            t2_desc_grp = "";

            //  if sw-printed-bat-type = "N" then            
            if (Util.Str(sw_printed_bat_type).ToUpper().Equals("N"))
            {
                sw_printed_bat_type = "Y";
                t2_desc_a = desc_bat_type[ss_type];
                nbr_lines_to_advance = 3;
            }

            // if sw-printed-adj-type = "N" then            
            if (Util.Str(sw_printed_adj_type).ToUpper().Equals("N"))
            {
                sw_printed_adj_type = "Y";
                t2_desc_b = desc_adj_type[ss_type];
            }

            t2_dash = "_";
            //     subtract 1				from	ss-agent;
            // 					giving	t2-agent-cd.;
            t2_agent_cd = ss_agent - 1;

            ss_type_from = ss_type;
            //    perform tg0-move-vals-to-line	thru	tg0-99-exit.;
            tg0_move_vals_to_line();
            tg0_99_exit();

            //    perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();


            // if ss-type = ss-grand-tot then            
            if (ss_type == ss_grand_tot)
            {
                // 	  go to xe11-99-exit.;
                xe11_99_exit();
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

        private void xe11_99_exit()
        {
            Util.Trakker(++debug_ctr, "xe11_99_exit");
            //     exit.;
        }

        private void xf0_zero_clinic_totals()
        {
            Util.Trakker(++debug_ctr, "xf0_zero_clinic_totals");

            //tbl_totals = 0;
            tbl_totals_grp = "0";
            tbl_bat_type_and_tots = new string[9];
            tbl_agent_and_sums = new string[9, 12];
            tbl_tot = new decimal[9, 12, 11];
        }

        private void xf0_99_exit()
        {
            Util.Trakker(++debug_ctr, "xf0_99_exit");
        }

        private void ya0_read_pat()
        {
            Util.Trakker(++debug_ctr, "ya0_read_pat");

            //objPat_mstr_rec.key_pat_mstr = objClaim_header_rec.clmhdr_pat_ohip_id_or_chart;

            /*05  clmhdr - pat - ohip - id - or - chart.
               10  clmhdr - pat - key - type                 pic a.
               10  clmhdr - pat - key - data.
                    15  clmhdr - pat - key - ohip             pic x(8).
                    15  filler                          pic x(7). */

            /*05  key - pat - mstr.
                10  pat - i - key                   pic x.
                10  pat - con - nbr                 pic 99.
                10  pat - i - nbr                   pic 9(12).
                10  filler pic x. */

            objPat_mstr_rec.PAT_I_KEY = Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_TYPE);
            objPat_mstr_rec.PAT_CON_NBR = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA).PadRight(15, ' ').Substring(0, 2));
            objPat_mstr_rec.PAT_I_NBR = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA).PadRight(15, ' ').Substring(2, 12));

            //     read pat-mstr;
            //  	invalid key;
            //          err_ind = 9;
            // 	        perform za0-common-error	thru	za0-99-exit;
            // 	        perform err-pat-mstr.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_i_key = objPat_mstr_rec.PAT_I_KEY,
                WherePat_con_nbr = objPat_mstr_rec.PAT_CON_NBR,
                WherePat_i_nbr = objPat_mstr_rec.PAT_I_NBR
            }.Collection(Pat_mstr_rec_Collection);

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 9;
                //   perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //   perform err-pat-mstr.;
                err_pat_mstr();
                return;
            }
            else
            {
                objPat_mstr_rec = Pat_mstr_rec_Collection.FirstOrDefault();
                ctr_pat_mstr_reads++;               
            } 

            // if pat-ohip-mmyy-r not = spaces then            
            if (!string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_DIRECT_ALPHA) && !string.IsNullOrWhiteSpace(Util.Str(objPat_mstr_rec.PAT_DIRECT_YY)) && !string.IsNullOrWhiteSpace(Util.Str(objPat_mstr_rec.PAT_DIRECT_MM)) && !string.IsNullOrWhiteSpace(Util.Str(objPat_mstr_rec.PAT_DIRECT_DD)))
            {
                //     l1_pat_id_chart_id = objPat_mstr_rec.pat_ohip_mmyy_r;
                l1_pat_id_chart_id = objPat_mstr_rec.PAT_DIRECT_ALPHA + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY) + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM) + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD); //pat_ohip_mmyy_r;
            }
            else
            {
                l1_pat_id_chart_id = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
            } 
        }

        private void ya0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ya0_99_exit");
            //     exit.;
        }

        private void za0_common_error()
        {
            Util.Trakker(++debug_ctr, "za0_common_error");

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;

            if (err_ind == 8)
            {
                Console.WriteLine("NO CLAIM FOR CURRENT BATCH - F001/F002 = " + miss_batch_nbr + "/" + miss_f002_batch_nbr + Util.Str(miss_claim_nbr));
            }
            else if (err_ind == 10)
            {
                Console.WriteLine("DIFFERENT PED - F001/F002 = " + wrong_batch_nbr + Util.Str(wrong_claim_nbr) + "/" + wrong_f001_ped + "/" + wrong_f002_ped);
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
            Util.Trakker(++debug_ctr, "za0_99_exit");
            //     exit.;
        }

        private void ze0_move_and_print_fin_tot()
        {
            Util.Trakker(++debug_ctr, "ze0_move_and_print_fin_tot");

            // t2_desc_grp = "FINALTOTALS";
            t2_desc_a = "FINAL TOTALS";
             t2_detail_1 = fin_tot_1;
            t2_detail_2 = fin_tot_2;
            t2_detail_3 = fin_tot_3;
            t2_detail_4 = Util.NumInt(fin_tot_4);
            t2_detail_5 = Util.NumInt(fin_tot_5);
            t2_detail_6 = fin_tot_6;
            t2_detail_7 = fin_tot_7;
            t2_detail_8 = fin_tot_8;
            t2_detail_9 = Util.NumInt(fin_tot_9);
            t2_detail_10 = Util.NumInt(fin_tot_10);
            h2_clinic_name = "";
            h3_cycle = 0;
            h3_period_end_yy = 0;
            h3_period_end_mm = 0;
            h3_period_end_dd = 0;
            h1_clinic_nbr = 0;
            t4_clinic_nbr = 0;

            last_page_flag = "Y";
            nbr_lines_to_advance = 3;
            //     perform tb0-write-line		thru	tb0-99-exit.;
            tb0_write_line();
            tb0_99_exit();
        }

        private void ze0_99_exit()
        {
            Util.Trakker(++debug_ctr, "ze0_99_exit");

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate()
        {
            Util.Trakker(++debug_ctr, "y2k_default_sysdate");

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {
            Util.Trakker(++debug_ctr, "y2k_default_sysdate_exit");
            //     exit.;
        }

        private void MoveSpacesToPrintLine()
        {
            Util.Trakker(++debug_ctr, "MoveSpacesToPrintLine ");

            l1_clinic1 = 0;
            l1_doc_nbr = "";
            l1_week = 0;
            l1_day = 0;
            l1_dash = "";
            l1_claim_nbr = 0;
            l1_slash = "";
            l1_doc_dept = 0;
            l1_patient_acronym6 = "";
            l1_patient_acronym3 = "";
            l1_pat_id_chart_id = "";
            l1_doc_nbr2 = "";
            l1_diag_code = 0;
            l1_refer_doc_nbr = 0;
            l1_hosp = 0;
            l1_location = "";
            l1_agent_cd = 0;
            l1_pat_in_out = "";
            l1_reference = "";
            l1_admit_date_yy = 0;
            l1_slash1 = "";
            l1_admit_date_mm = 0;
            l1_slash2 = "";
            l1_admit_date_dd = 0;
            l1_brace_l1 = "";
            l1_ar_oma = 0;
            l1_brace_r1 = "";
            l1_brace_l2 = "";
            l1_ar_ohip = 0;
            l1_brace_r2 = "";
        }

        private string h1_head_grp()
        {
           return Util.Str(h1_rpt_name).PadRight(6, ' ') +
                          "/" +
                          Util.ImpliedIntegerFormat("##",h1_clinic_nbr,2, false) +
                          new string(' ', 5) +
                          "BATCH TYPE - ".PadRight(13, ' ') +
                          Util.Str(h1_batch_type).PadRight(10, ' ') +
                          new string(' ', 6) +
                          "UNBALANCED BATCH ".PadRight(17, ' ') +
                          Util.Str(h1_rpt_type).PadRight(8, ' ') +
                          "REPORT".PadRight(30, ' ') +
                          "RUN DATE".PadRight(9, ' ') +
                          Util.Str(h1_run_yy).PadLeft(4, '0') +
                          "/" +
                          Util.Str(h1_run_mm).PadLeft(2, '0') +
                          "/" +
                          Util.Str(h1_run_dd).PadLeft(2, '0') +
                          new string(' ', 4) +
                          "PAGE".PadRight(5, ' ') +
                         string.Format("{0:#,0}", h1_page).PadLeft(5, ' ');
        }

        private string h2_head_grp()
        {
            return  new string(' ', 56) + 
                    Util.Str(h2_clinic_name).PadRight(76, ' ');
        }

        private string h3_head_grp()
        {
            return  new string(' ', 44) + 
                    "CYCLE #".PadRight(8, ' ') + 
                    Util.ImpliedIntegerFormat("#",h3_cycle,3) + 
                    "  BATCH NO.".PadRight(12, ' ') + 
                    Util.BlankWhenZero(h3_clinic1,2) + 
                    Util.Str(h3_doc_nbr).PadRight(3, ' ') + 
                    Util.BlankWhenZero(h3_week,2) + 
                    Util.BlankWhenZero(h3_day,1) +
                    new string(' ', 21) + 
                    "FOR THE PERIOD ENDING:".PadRight(23, ' ') + 
                    Util.BlankWhenZero(h3_period_end_yy, 4) + 
                    "/" + 
                    Util.BlankWhenZero (h3_period_end_mm,2) + 
                    "/" + 
                    Util.BlankWhenZero(h3_period_end_dd, 2) + 
                    new string(' ', 3);
        }

        private string h4_head_grp()
        {
            return  "   CLAIM       PATIENT     PAT".PadRight(30, ' ');
        }

        private string h5_head_grp()
        {
            return  "  NUMBER    DP ACRONYM     CHA".PadRight(30, ' ') + 
                    "RT NUMBER    NBR   CODE   (CON".PadRight(30, ' ') + 
                    "SEC. DATE)   OMA CD  AJ     RS".PadRight(30, ' ') + 
                    "N & SRV  SVC DATE     OMA".PadRight(30, ' ') + 
                    " OHIP".PadRight(12, ' ');
        }

        private string t1_head_grp()
        {
            return  new string(' ', 47) + 
                    "NUMBER".PadRight(13, ' ') + 
                    "TOTAL".PadRight(72, ' ');
        }

        private string t2_head_grp()
        {
            return  new string(' ', 49) + 
                    "OF".PadRight(12, ' ') + 
                    "OF $".PadRight(71, ' ');
        }

        private string t3_head_grp()
        {
            return  new string(' ', 46) + 
                    "SERVICES".PadRight(14, ' ') + 
                    "INPUT".PadRight(72, ' ');
        }

        private string t4_head_grp()
        {
            return new string(' ', 2) + 
                   "CLINIC".PadRight(8, ' ') + 
                   Util.BlankWhenZero(t4_clinic_nbr,2) + 
                   new string(' ', 13) + 
                   "---------------".PadRight(15, ' ') + 
                   "BATCH   CONTROL   FILE".PadRight(22, ' ') + 
                   "-------------".PadRight(19, ' ') + 
                   "------------------".PadRight(18, ' ') + 
                   "CLAIMS   MASTER-----------------".PadRight(33, ' ');
        }

        private string t5_head_grp()
        {
            return  new string(' ', 17) + 
                   "AGENT".PadRight(8, ' ') + 
                   "NET A/R".PadRight(13, ' ') + 
                   " NET REV".PadRight(16, ' ') + 
                   "CASH".PadRight(8, ' ') + 
                   "CLAIMS".PadRight(8, ' ') + 
                   "SVC'S".PadRight(8, ' ') + 
                   "NET A/R".PadRight(13, ' ') + 
                   " NET REV".PadRight(16, ' ') + 
                   "CASH".PadRight(8, ' ') + 
                   "CLAIMS".PadRight(8, ' ') + 
                   "SVC'S".PadRight(6, ' ');
        }

        private string print_line_grp()
        {
            return  Util.Str(l1_clinic1).PadLeft(2, '0') + 
                    Util.Str(l1_doc_nbr).PadRight(3, ' ') + 
                    Util.Str(l1_week).PadLeft(2, '0') + 
                    Util.Str(l1_day).PadLeft(1, '0') + 
                    Util.Str(l1_dash).PadRight(1, ' ') + 
                    Util.Str(l1_claim_nbr).PadLeft(2, '0') + 
                    Util.Str(l1_slash).PadRight(1, ' ') + 
                    Util.Str(l1_doc_dept).PadLeft(2, '0') + 
                    new string(' ', 1) + 
                    Util.Str(l1_patient_acronym6).PadRight(7, ' ') + 
                    Util.Str(l1_patient_acronym3).PadRight(5, ' ') +
                    Util.Str(l1_pat_id_chart_id).PadRight(16, ' ') + 
                    Util.Str(l1_doc_nbr2).PadRight(3, ' ') + 
                    new string(' ', 4) + 
                    Util.BlankWhenZero(l1_diag_code, 3) + 
                    new string(' ', 3) + 
                    Util.BlankWhenZero(l1_refer_doc_nbr, 6) + 
                    new string(' ', 2) + 
                    Util.BlankWhenZero(l1_hosp, 4) + 
                    new string(' ', 5) + 
                    string.Format("{0:#000}", l1_location) + 
                    new string(' ', 3) + 
                    Util.Str(l1_agent_cd).PadLeft(1, '0') + 
                    new string(' ', 2) + 
                    Util.Str(l1_pat_in_out).PadRight(1, ' ') +
                    new string(' ', 2) + 
                    Util.Str(l1_reference).PadRight(11, ' ') + 
                    Util.Str(l1_admit_date_yy).PadLeft(4, '0') + 
                    Util.Str(l1_slash1).PadRight(1, ' ') + 
                    Util.Str(l1_admit_date_mm).PadLeft(2, '0') + 
                    Util.Str(l1_slash2).PadRight(1, ' ') + 
                    Util.Str(l1_admit_date_dd).PadLeft(2, '0') + 
                    new string(' ', 1) + 
                    Util.Str(l1_brace_l1).PadRight(1, ' ') + 
                    Util.ImpliedDecimalFormat("0.00", l1_ar_oma, 2, 9) + 
                    Util.Str(l1_brace_r1).PadRight(2, ' ') + 
                    Util.Str(l1_brace_l2).PadRight(1, ' ') +
                    Util.ImpliedDecimalFormat("0.00", l1_ar_ohip, 2, 9) + 
                    Util.Str(l1_brace_r2).PadRight(2, ' ');
        }

        private string l1_print_line_grp()
        {
            return Util.Str(l1_clinic1).PadLeft(2, '0') +
                    Util.Str(l1_doc_nbr).PadRight(3, ' ') +
                    Util.Str(l1_week).PadLeft(2, '0') +
                    Util.Str(l1_day).PadLeft(1, '0') +
                    Util.Str(l1_dash).PadRight(1, ' ') +
                    Util.Str(l1_claim_nbr).PadLeft(2, '0') +
                    Util.Str(l1_slash).PadRight(1, ' ') +
                    Util.Str(l1_doc_dept).PadLeft(2, '0') +
                    new string(' ', 1) +
                    Util.Str(l1_patient_acronym6).PadRight(7, ' ') +
                    Util.Str(l1_patient_acronym3).PadRight(5, ' ') +
                    Util.Str(l1_pat_id_chart_id).PadRight(16, ' ') +
                    Util.Str(l1_doc_nbr2).PadRight(3, ' ') +
                    new string(' ', 4) +
                    Util.BlankWhenZero(l1_diag_code, 3) +
                    new string(' ', 3) +
                    Util.BlankWhenZero(l1_refer_doc_nbr, 6) +
                    new string(' ', 2) +
                    Util.BlankWhenZero(l1_hosp, 4) +
                    new string(' ', 5) +
                    string.Format("{0:#000}", l1_location) +
                    new string(' ', 3) +
                    Util.Str(l1_agent_cd).PadLeft(1, '0') +
                    new string(' ', 2) +
                    Util.Str(l1_pat_in_out).PadRight(1, ' ') +
                    new string(' ', 2) +
                    Util.Str(l1_reference).PadRight(11, ' ') +
                    Util.Str(l1_admit_date_yy).PadLeft(4, '0') +
                    Util.Str(l1_slash1).PadRight(1, ' ') +
                    Util.Str(l1_admit_date_mm).PadLeft(2, '0') +
                    Util.Str(l1_slash2).PadRight(1, ' ') +
                    Util.Str(l1_admit_date_dd).PadLeft(2, '0') +
                    new string(' ', 1) +
                    Util.Str(l1_brace_l1).PadRight(1, ' ') +
                    Util.ImpliedDecimalFormat("0.00", l1_ar_oma, 2, 9) +
                    Util.Str(l1_brace_r1).PadRight(2, ' ') +
                    Util.Str(l1_brace_l2).PadRight(1, ' ') +
                    Util.ImpliedDecimalFormat("0.00", l1_ar_ohip, 2, 9) +
                    Util.Str(l1_brace_r2).PadRight(2, ' ');
        }

        private string l2_print_line_grp()
        {
            return new string(' ', 55) +
                   Util.BlankWhenZero(l2_sv_nbr[1], 2) +
                   new string(' ', 1) +
                   Util.BlankWhenZero(l2_sv_day[1], 2) +
                   new string(' ', 1) +

                   Util.BlankWhenZero(l2_sv_nbr[2], 2) +
                   new string(' ', 1) +
                   Util.BlankWhenZero(l2_sv_day[2], 2) +
                   new string(' ', 1) +

                   Util.BlankWhenZero(l2_sv_nbr[3], 2) +
                   new string(' ', 1) +
                   Util.BlankWhenZero(l2_sv_day[3], 2) +
                   new string(' ', 1) +
                   Util.Str(l2_oma_cd).PadRight(4) +
                  Util.Str(l2_oma_suff).PadRight(5) +
                  Util.Str(l2_adj_cd).PadRight(3) +
                  Util.Str(l2_card_colour).PadRight(3) +
                  Util.ImpliedIntegerFormat("#0",Util.NumInt(l2_rsn), 2, false) +
                  new string(' ', 2) +
                  Util.Str(l2_srv).PadLeft(2, '0') +
                  new string(' ', 3) +
                  Util.Str(l2_svc_date_yy).PadLeft(4, '0') +
                  Util.Str(l2_slash1).PadRight(1) +
                  Util.Str(l2_svc_date_mm).PadLeft(2, '0') +
                  Util.Str(l2_slash2).PadRight(1) +
                  Util.Str(l2_svc_date_dd).PadLeft(2, '0') +
                  new string(' ', 1) +
                  Util.ImpliedDecimalFormat("#,#.00", l2_fee_oma,2, 10) +
                  new string(' ', 2) +
                  Util.ImpliedDecimalFormat("#,#.00", l2_fee_ohip,2, 10) +
                  new string(' ', 2);
        }

        private string l3_print_line()
        {
            return new string(' ', 108) +
                    Util.ImpliedDecimalFormat("#,#.00", l3_fee_total_oma, 2, 10) +
                    new string(' ', 2) +
                    Util.ImpliedDecimalFormat("#,#.00", l3_fee_total_ohip, 2, 10) +
                    new string(' ', 2);
        }

        private string l4_print_line()
        {
            return Util.Str(l4_claim_desc).PadRight(45) +
                   new string(' ', 87);
        }

        private string t1_print_line()
        {
            return new string(' ', 25) +
                    Util.Str(t1_total_lit).PadRight(22) +
                    Util.ImpliedIntegerFormat("#,0", t1_nbr_services, 7) +
                    new string(' ', 2) +
                    Util.ImpliedDecimalFormat("#,#,00", t1_amt_input, 2, 13) +
                    new string(' ', 63);
        }

        private string t2_print_line()
        {
            t2_desc_grp = Util.Str(t2_desc_a).PadRight(13) + Util.Str(t2_desc_b).PadRight(5);
            return t2_desc_grp +
                   Util.Str(t2_dash).PadRight(1) +
                   new string(' ', 1) +
                   Util.BlankWhenZero(t2_agent_cd,1) +
                   new string(' ', 1) +
                   Util.ImpliedDecimalFormat("#,0.00", t2_detail_1, 2, 12) +
                   new string(' ', 1) +
                   Util.ImpliedDecimalFormat("#,0.00", t2_detail_2, 2, 12) +
                   new string(' ', 1) +
                   Util.ImpliedDecimalFormat("#,0.00", t2_detail_3, 2, 12) +
                   new string(' ', 1) +
                   Util.ImpliedIntegerFormat("#.0", t2_detail_4, 7, false) +
                   new string(' ', 1) +
                   Util.ImpliedIntegerFormat("#,0", t2_detail_5, 7, false) +
                   new string(' ', 2) +
                   Util.ImpliedDecimalFormat("#,0.00", t2_detail_6, 2, 12) +
                   new string(' ', 1) +
                   Util.ImpliedDecimalFormat("#,0.00", t2_detail_7, 2, 12) +
                   new string(' ', 1) +
                   Util.ImpliedDecimalFormat("#,0.00", t2_detail_8, 2, 12) +
                   new string(' ', 1) +
                   Util.ImpliedIntegerFormat("#,0", t2_detail_9, 7, false) +
                   new string(' ', 1) +
                  Util.ImpliedIntegerFormat("#,0", t2_detail_10, 7, false);
        }

        private string t1_print_line_grp()
        {
            return  new string(' ', 25) + 
                    Util.Str(t1_total_lit).PadRight(22, ' ') + 
                    Util.ImpliedIntegerFormat("#,0", t1_nbr_services, 7) + 
                    new string(' ', 2) + 
                    Util.ImpliedDecimalFormat("#,#.00", t1_amt_input, 2, 13) + 
                    new string(' ', 63);
        }

        #endregion
    }
}


