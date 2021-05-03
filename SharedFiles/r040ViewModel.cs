using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using RmaDAL;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.IO;
using System.Diagnostics;
using rma.Cobol;
namespace rma.Views
{
    public class R040ViewModel : CommonFunctionScr
    {

        public R040ViewModel() {

        }

        #region FD Section
        // FD: print_file
        private Print_record objPrint_record = null;


        // FD: oma_fee_mstr	Copy : f040_oma_fee_mstr.fd
        private F040_OMA_FEE_MSTR objFee_mstr_rec = null;
        private ObservableCollection<F040_OMA_FEE_MSTR> Fee_mstr_rec_Collection;

        private ReportPrint objPrint_file = null; 


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

        private int _ctr_oma_fee_mstr_reads;
        public int ctr_oma_fee_mstr_reads
        {
            get
            {
                return _ctr_oma_fee_mstr_reads;
            }
            set
            {
                if (_ctr_oma_fee_mstr_reads != value)
                {
                    _ctr_oma_fee_mstr_reads = value;
                    RaisePropertyChanged("ctr_oma_fee_mstr_reads");
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

        /* private string _ws_closing_msg;
         public string ws_closing_msg
         {
             get
             {
                  return _ws_closing_msg;
             }
             set
             {
                  if (_ws_closing_msg != value)
                   {
                    _ws_closing_msg = value;
                    _ws_closing_msg = _ws_closing_msg.ToUpper();
                    RaisePropertyChanged("ws_closing_msg");
                   }
             }
         } */

        private string _ws_continue;
        public string ws_continue
        {
            get
            {
                return _ws_continue;
            }
            set
            {
                if (_ws_continue != value)
                {
                    _ws_continue = value;
                    _ws_continue = _ws_continue.ToUpper();
                    RaisePropertyChanged("ws_continue");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string ws_closing_msg = "REPORT IS IN FILE R040";
        //private string ws_continue = "";
        private string print_file_name = "r040";
        private int max_nbr_lines_1 = 56;
        private int max_nbr_lines_2 = 56;
        private int ctr_lines = 70;
        private string feedback_oma_fee_mstr;
        private string eof_oma_mstr = "N";
        private string status_prt_file = "0";
        //private string common_status_file;
        private string status_cobol_oma_mstr = "0";

        private string counters_grp;
        //private int ctr_oma_fee_mstr_reads;
        private int ctr_pages;

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "NO OMA-FEE-MASTER SUPPLIED";
        //private string filler = "invalid reply";
        private string error_messages_r_grp;
        private string[] err_msg =
           { "", "NO OMA-FEE-MASTER SUPPLIED",
            "invalid reply"
        };
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

        //private string h1_head_grp;
        //private string filler = "R040";
        //private string filler = "OMA FEE REPORT";
        //private string filler = "run date";
        private string h1_date_grp;
        private int h1_yy;
        private string h1_slash1;
        private int h1_mm;
        private string h1_slash2;
        private int h1_dd;
        private string filler = "";
        //private string filler = "PAGE";
        private int h1_page;

        // private string h2_head_grp;
        // private string filler = "OMA   ASSOC SUFF PAGE EFFECT.  BLTRL";
        // private string filler = "DESCRIPTION";
        // private string filler = "icc-    reduc";
        // private string filler = "ADD ON CODES";

        //	 private string h3_head_grp;
        // private string filler = "CODE";
        // private string filler = " M ";
        // private string filler = "DATE";
        // private string filler = "ID";
        // private string filler = "code    code";
        // private string filler = "CD-1 CD-2 CD-3 CD-4";

        //private string h4_head_grp;
        //private string filler = " A-FEE-1   H-FEE-1   A-FEE-2   H-FEE-2";
        //private string filler = "A-   H-   A-   H-   MAX-GEN   MAX-PRO";
        //private string filler = "PRCNT/ DIAG PHY HOSP I-O ADM  SPEC SPEC";

       // private string h5_head_grp;
        //private string filler = "";
        //private string filler = "ANAE ANAE ASST ASST";
        //private string filler = "FLAT   IND  IND IND  IND IND   FR   TO";

       // private string l1_print_line_grp;
        private string l1_oma_code;
        //private string filler;
        private string l1_assoc;
        //private string filler;
        private string l1_m_suff_allowed;
        private string l1_page;
        //private string filler;
        private string l1_effect_date_grp;
        private int l1_date_yy;
        private string l1_slash1;
        private int l1_date_mm;
        private string l1_slash2;
        private int l1_date_dd;
        //private string filler;
        private string l1_bltrl_id;
        private string l1_description;
        private string l1_icc_code;
//        private string filler;
        private string l1_reduc_code;
        //private string filler;
        private string l1_cd_1;
       // private string filler;
        private string l1_cd_2;
       // private string filler;
        private string l1_cd_3;
        //private string filler;
        private string l1_cd_4;

        //private string l2_print_line_grp;
        private decimal l2_a_fee_1;
        //private string filler;
        private decimal l2_h_fee_1;
        //private string filler;
        private decimal l2_a_fee_2;
        //private string filler;
        private decimal l2_h_fee_2;
        //private string filler;
        private int l2_a_anae;
        //private string filler;
        private int l2_h_anae;
        //private string filler;
        private int l2_a_asst;
        //private string filler;
        private int l2_h_asst;
        //private string filler;
        private decimal l2_max_gen;
        //private string filler;
        private decimal l2_max_pro;
        //private string filler;
        private string l2_current;
        private string l2_prcnt_flat;
        private string l2_diag_ind;
        private string l2_phy_ind;
        private string l2_hosp_ind;
        private string l2_i_o_ind;
        private string l2_adm_ind;
        private int l2_spec_fr;
        //private string filler;
        private int l2_spec_to;
        //private string filler;
        //private string filler;

        //private string l3_print_line_grp;
        private decimal l3_a_fee_1;
        //private string filler;
        private decimal l3_h_fee_1;
        //private string filler;
        private decimal l3_a_fee_2;
        //private string filler;
        private decimal l3_h_fee_2;
        //private string filler;
        private int l3_a_anae;
        //private string filler;
        private int l3_h_anae;
        //private string filler;
        private int l3_a_asst;
        //private string filler;
        private int l3_h_asst;
        //private string filler;
        private decimal l3_max_gen;
        //private string filler;
        private decimal l3_max_pro;
        //private string filler;
        private string l3_prev_yr;
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
       // private string filler;

        private string sys_date_y2kfixed_grp;
        private string sys_date_blank;
        private string sys_date_right;
        private string sys_date_temp;

        private string run_date_grp;
        private int run_yy;
       // private string filler = "/";
        private int run_mm;
       // private string filler = "/";
        private int run_dd;

        private string sys_time_grp;
        //private int sys_hrs;
        //private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        private string run_time_grp;
        private int run_hrs;
       // private string filler = ":";
        private int run_min;
       // private string filler = ":";
        private int run_sec;
        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "R040",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 32,Data1 = "PRINT FEE MASTER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "05",Col = 25,Data1 = "CONTINUE (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "05",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_continue",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-continue"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "08",Col = 30,Data1 = "PROGRAM R040 IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "07",Col = 30,Data1 = "NUMBER OF OMA-FEE-MSTR READS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "07",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_oma_fee_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 30,Data1 = "PROGRAM R040 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 55,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 56,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 58,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 59,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 64,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "19",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 30,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_closing_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_oma_fee_file_section()
        {

            //     use after standard error procedure on oma-fee-mstr.;
        }

        private async Task err_oma_fee_mstr()
        {

            common_status_file = status_cobol_oma_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING OMA-FEE MASTER".;
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {

        }

        private async Task initialize_objects()
        {
            objFee_mstr_rec = null;
            objFee_mstr_rec = new F040_OMA_FEE_MSTR();

            Fee_mstr_rec_Collection = null;
            Fee_mstr_rec_Collection = new F040_OMA_FEE_MSTR
            {
            }.Collection();

            objPrint_file = null;
            objPrint_file = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

            objPrint_record = null;
            objPrint_record = new Print_record();

        }

        public async Task mainline()
        {
            try {

                await initialize_objects();

                //     perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                string retval =  await aa0_10_acc_rej();
                if (retval.Equals("az0_100_end_job"))
                {
                    goto _az0_100_end_job;
                }
                else if (retval.Equals("az0_end_of_job"))
                {
                    goto _az0_end_of_job;
                }
                await aa0_99_exit();

                //     perform ab0-mainline		thru ab0-99-exit.;
                await ab0_mainline();
                await ab0_99_exit();

                //     perform az0-end-of-job		thru az0-99-exit.;
                _az0_end_of_job:
                await az0_end_of_job();
                _az0_100_end_job:
                await az0_100_end_job();
                await az0_99_exit();

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
                if (objPrint_file != null)
                {
                    objPrint_file.Close();
                    objPrint_file = null;
                }
                await destroy_objects();
            }
        }

        private async Task aa0_initialization()
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

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;
            //     accept sys-time			from time.;
            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     display scr-title.;
            Console.WriteLine("R040" + new string(' ', 32) + Util.Str(sys_yy).PadLeft(4, '0') + "/" + Util.Str(sys_mm).PadLeft(2, '0') + "/" + Util.Str(sys_dd).PadLeft(2, '0'));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("CONTINUE (Y/N)");            
        }

        private async Task<string> aa0_10_acc_rej()
        {

            //     accept scr-continue.;
            ws_continue = Console.ReadLine();


            // if ws-continue = "Y" then;            
            if (Util.Str(ws_continue).ToUpper().Equals("Y")) {
                // 	   display program-in-progress;
                Console.WriteLine("PROGRAM R040 IN PROGRESS");
            }
            // else if ws-continue = "N" then            
            else if (Util.Str(ws_continue).ToUpper().Equals("N")) {
                // 	    go to az0-100-end-job;                
                return "az0_100_end_job";
            }
            else {
                      err_ind = 2;
                // 	    perform za0-common-error		thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to aa0-10-acc-rej.;            
                return await aa0_10_acc_rej();
                
            }

            await l1_print_line_grp(true);            
            await l2_print_line_grp(true);            
            await l3_print_line_grp(true);

            //counters = 0;
            ctr_oma_fee_mstr_reads = 0;
            ctr_pages = 0;

            //     open input oma-fee-mstr.;
            //     open output print-file.;

            //     perform bc0-read-oma-fee-mstr	thru	bc0-99-exit.;
            await bc0_read_oma_fee_mstr();
            await bc0_99_exit();

            //  if eof-oma-mstr = "Y" then;            
            if (Util.Str(eof_oma_mstr).ToUpper().Equals("Y")) {
                err_ind = 1;
                // 	perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	go to az0-end-of-job.;
                return "az0_end_of_job";
            }

            h1_mm = run_mm;
            h1_dd = run_dd;
            h1_yy = run_yy;
            h1_slash1 = "/";
            h1_slash2 = "/";

            return string.Empty;            
        }

        private async Task aa0_99_exit()
        {

            //     exit.;
        }

        private async Task az0_end_of_job()
        {

            //     close oma-fee-mstr.;
            objFee_mstr_rec = null;
            Fee_mstr_rec_Collection = null;            
        }

        private async Task az0_100_end_job()
        {

            //     accept sys-time			from time.;
            //     display scr-closing-screen.;
            Console.WriteLine("NUMBER OF OMA-FEE-MSTR READS" + Util.Str(ctr_oma_fee_mstr_reads)) ;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("PROGRAM R040 ENDING" + Util.Str(sys_yy).PadLeft(4,'0') + "/" + Util.Str(sys_mm).PadLeft(2,'0') + "/" + Util.Str(sys_dd).PadLeft(2,'0') + " " + Util.Str(sys_hrs) + ":" +  Util.Str(sys_min));
            Console.WriteLine("");
            Console.WriteLine(ws_closing_msg);

            //     stop run.;
            throw new Exception(endOfJob);
        }

        private async Task az0_99_exit()
        {

            //     exit.;
        }

        private async Task ab0_mainline()
        {
            _mainline:

            //     perform ba0-build-print-line	thru	ba0-99-exit.;
            await ba0_build_print_line();
            await ba0_99_exit();

            //     perform bb0-write-print-line	thru	bb0-99-exit.;
            await bb0_write_print_line();
            await bb0_99_exit();

            //     perform bc0-read-oma-fee-mstr	thru	bc0-99-exit.;
            await bc0_read_oma_fee_mstr();
            await bc0_99_exit();

            //  if eof-oma-mstr not = "Y" then;            
            if (!Util.Str(eof_oma_mstr).ToUpper().Equals("Y")) {
                // 	   go to ab0-mainline.;
                goto _mainline;                
            }
        }

        private async Task ab0_99_exit()
        {

            //     exit.;
        }

        private async Task ba0_build_print_line()
        {
            l1_oma_code = Util.Str(objFee_mstr_rec.FEE_OMA_CD_LTR1) + Util.Str(objFee_mstr_rec.FILLER_NUMERIC);
            l1_assoc = "";
            l1_m_suff_allowed = Util.Str(objFee_mstr_rec.FEE_SPECIAL_M_SUFFIX_IND);
            l1_page = (Util.Str(objFee_mstr_rec.FEE_CURR_PAGE_ALPHA, 2) + Util.Str(objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC).PadLeft(3, '0')).Substring(0, 3);  // fee_curr_page;
            l1_date_yy = Util.NumInt(objFee_mstr_rec.FEE_DATE_YY);
            l1_date_mm = Util.NumInt(objFee_mstr_rec.FEE_DATE_MM);  
            l1_date_dd = Util.NumInt(objFee_mstr_rec.FEE_DATE_DD); 
            l1_slash1 = "/";
            l1_slash2 = "/";
            
            l1_bltrl_id = "";
            l1_description = Util.Str(objFee_mstr_rec.FEE_DESC);

            if (objFee_mstr_rec.FEE_ICC_SEC.Trim() == "" && objFee_mstr_rec.FEE_ICC_CAT == 0 && objFee_mstr_rec.FEE_ICC_GRP == 0 && objFee_mstr_rec.FEE_ICC_REDUC_IND == 0)
            {
                l1_icc_code = "";
            }
            else
            {
                l1_icc_code = Util.Str(objFee_mstr_rec.FEE_ICC_SEC) + Util.Str(objFee_mstr_rec.FEE_ICC_CAT).PadLeft(1, '0') + Util.Str(objFee_mstr_rec.FEE_ICC_GRP).PadLeft(2, '0') + Util.Str(objFee_mstr_rec.FEE_ICC_REDUC_IND).PadLeft(1, '0');     //fee_icc_code;
            }

            l1_reduc_code = "";
            l1_cd_1 = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD1);  // fee_curr_add_on_cd[1];
            l1_cd_2 = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD2);  //fee_curr_add_on_cd[2];
            l1_cd_3 = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD3); //fee_curr_add_on_cd[3];
            l1_cd_4 = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD4);  //fee_curr_add_on_cd[4];
            //l2_a_fee_1 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, 1, 1);  //fee_1[1, 1];
            //l2_h_fee_1 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, 1, 2); //  fee_1[1, 2];
            //l2_a_fee_2 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(objFee_mstr_rec, 1, 1); // fee_2[1, 1];
            //l2_h_fee_2 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(objFee_mstr_rec, 1, 2);  //fee_2[1, 2];
            l2_a_fee_1 = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_FEE_1/10);
            l2_h_fee_1 = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_FEE_1/10);
            l2_a_fee_2 = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_FEE_2/10);
            l2_h_fee_2 = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_FEE_2/10);
            l2_a_anae = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(objFee_mstr_rec, 1, 1));  // fee_anae[1, 1];
            l2_h_anae = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(objFee_mstr_rec, 1, 2)); // fee_anae[1, 2];
            l2_a_asst = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(objFee_mstr_rec, 1, 1));   //fee_asst[1, 1];
            l2_h_asst = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(objFee_mstr_rec, 1, 2));  //fee_asst[1, 2];
            l2_max_gen = 0;
            l2_max_pro = 0;
            l2_current = "CURRENT";
            l2_prcnt_flat = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND); //fee_curr_add_on_perc_flat_ind;
            l2_diag_ind = Util.Str(objFee_mstr_rec.FEE_DIAG_IND); // fee_diag_ind;
            l2_phy_ind = Util.Str(objFee_mstr_rec.FEE_PHY_IND);  //fee_phy_ind;
            l2_hosp_ind = Util.Str(objFee_mstr_rec.FEE_HOSP_NBR_IND);  //fee_hosp_nbr_ind;
            l2_i_o_ind = Util.Str(objFee_mstr_rec.FEE_I_O_IND); //fee_i_o_ind;
            l2_adm_ind = Util.Str(objFee_mstr_rec.FEE_ADMIT_IND); //fee_admit_ind;
            l2_spec_fr = Util.NumInt(objFee_mstr_rec.FEE_SPEC_FR); //fee_spec_fr;
            l2_spec_to = Util.NumInt(objFee_mstr_rec.FEE_SPEC_TO); //fee_spec_to;
            //l3_a_fee_1 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, 2, 1); // fee_1[2, 1];
            //l3_h_fee_1 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, 2, 2);   // fee_1[2, 2];
            //l3_a_fee_2 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(objFee_mstr_rec, 2, 1);   //fee_2[2, 1];
            //l3_h_fee_2 = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(objFee_mstr_rec, 2, 2);   // fee_2[2, 2];
            l3_a_fee_1 = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_FEE_1 / 10); // fee_1[2, 1];
            l3_h_fee_1 = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_FEE_1 / 10);   // fee_1[2, 2];
            l3_a_fee_2 = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_FEE_2 / 10);   //fee_2[2, 1];
            l3_h_fee_2 = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_FEE_2 / 10);   // fee_2[2, 2];
            l3_a_anae = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(objFee_mstr_rec, 2, 1));   //fee_anae[2, 1];
            l3_h_anae = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(objFee_mstr_rec, 2, 2)); // fee_anae[2, 2];
            l3_a_asst = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(objFee_mstr_rec, 2, 1));  //fee_asst[2, 1];
            l3_h_asst = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(objFee_mstr_rec, 2, 2));  //fee_asst[2, 2];
            l3_max_gen = 0;
            l3_max_pro = 0;
            l3_prev_yr = "PREV. YR";
        }

        private async Task ba0_99_exit()
        {

            //     exit.;
        }

        private async Task bb0_write_print_line()
        {

            // if ctr-lines > max-nbr-lines-1 then;            
            if (ctr_lines > max_nbr_lines_1 ) {
                //   	perform ca0-write-headings	thru	ca0-99-exit.;
                await ca0_write_headings();
                await ca0_99_exit();
            }

            //     write print-record from h2-head after advancing 3 lines.;
            objPrint_record.Print_record1 = await h2_head_grp();
            objPrint_file.print(true);
            objPrint_file.print(true);
            objPrint_file.print(true);
            objPrint_file.print(objPrint_record.Print_record1, 1, true);
            objPrint_file.print(true);

            //     write print-record from h3-head after advancing 1 line.;
            objPrint_record.Print_record1 = await h3_head_grp();
            objPrint_file.print(objPrint_record.Print_record1, 1, true);
            objPrint_file.print(true);

            //     write print-record from l1-print-line after advancing 1 line.;
            objPrint_record.Print_record1 = await l1_print_line_grp();
            objPrint_file.print(objPrint_record.Print_record1, 1, true);
            objPrint_file.print(true);

            //     add 5				to	ctr-lines.;
            ctr_lines += 5;

            // if ctr-lines > max-nbr-lines-1  then;            
            if (ctr_lines > max_nbr_lines_1 ) {
                // 	   perform ca0-write-headings	thru	ca0-99-exit.;
                await ca0_write_headings();
                await ca0_99_exit();
            }

            //     write print-record from h4-head after advancing 2 line.;
            objPrint_record.Print_record1 = await h4_head_grp();
            objPrint_file.print(true);
            objPrint_file.print(objPrint_record.Print_record1, 1, true);
            objPrint_file.print(true);

            //     write print-record from h5-head after advancing 1 line.;
            objPrint_record.Print_record1 = await h5_head_grp();
            objPrint_file.print(objPrint_record.Print_record1, 1, true);
            objPrint_file.print(true);

            //     write print-record from l2-print-line after advancing 1 line.;
            objPrint_record.Print_record1 = await l2_print_line_grp();
            objPrint_file.print(objPrint_record.Print_record1, 1, true);
            objPrint_file.print(true);

            //     write print-record from l3-print-line after advancing 1 line.;
            objPrint_record.Print_record1 = await l3_print_line_grp();
            objPrint_file.print(objPrint_record.Print_record1, 1, true);

            //     add 5				to	ctr-lines.;
            ctr_lines += 5;
            
            await l1_print_line_grp(true);            
            await l2_print_line_grp(true);            
            await l3_print_line_grp(true);            
        }

        private async Task bb0_99_exit()
        {

            //     exit.;
        }

        private async Task<string> bc0_read_oma_fee_mstr()
        {

            //     read oma-fee-mstr next;
            //       at end;
            //         eof_oma_mstr = "Y";
            // 	       go to bc0-99-exit.;

            if (ctr_oma_fee_mstr_reads >= Fee_mstr_rec_Collection.Count() || Fee_mstr_rec_Collection.Count() == 0)
            {
                eof_oma_mstr = "Y";
                return "bc0_99_exit";
            }

            objFee_mstr_rec = Fee_mstr_rec_Collection[ctr_oma_fee_mstr_reads];

            //     add 1				to ctr-oma-fee-mstr-reads.;
            ctr_oma_fee_mstr_reads++;

            return string.Empty;
        }

        private async Task bc0_99_exit()
        {

            //   exit.;
        }

        private async Task ca0_write_headings()
        {

            //     add 1				to	ctr-pages.;
            ctr_pages++;

            h1_page = ctr_pages;
            //     write print-record from h1-head after advancing page.;
            objPrint_file.PageBreak();
            objPrint_record.Print_record1 = await h1_head_grp();
            objPrint_file.print(objPrint_record.Print_record1, 1, true);

            ctr_lines = 1;
        }

        private async Task ca0_99_exit()
        {

            //     exit.;
        }

        private async Task za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            Console.WriteLine(" ERROR -  " + err_msg_comment);
            //     display confirm.;
            //     stop " ".;
            //     display blank-line-24.;
        }

        private async Task za0_99_exit()
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

        private async Task<string> h1_head_grp()
        {
            return "R040".PadRight(50) +
                   "OMA FEE REPORT".PadRight(51) +
                   "RUN DATE".PadRight(9) +
                   Util.Str(h1_yy).PadLeft(4, '0') +
                   Util.Str(h1_slash1).PadRight(1) +
                  Util.Str(h1_mm).PadLeft(2, '0') +
                  Util.Str(h1_slash2).PadRight(1) +
                  Util.Str(h1_dd).PadLeft(2, '0') +
                  new string(' ', 3) +
                  "PAGE".PadRight(5) +
                  Util.ImpliedIntegerFormat("#0", h1_page, 4, false);
        }

        private async Task<string> h2_head_grp()
        {
            return "OMA   ASSOC SUFF PAGE EFFECT.  BLTRL".PadRight(47) +
                   "DESCRIPTION".PadRight(48) +
                   "ICC-    REDUC".PadRight(21) +
                   "ADD ON CODES".PadRight(16);
        }

        private async Task<string> h3_head_grp()
        {
            return "CODE".PadRight(12) +
                   " M ".PadRight(10) +
                   "DATE".PadRight(10) +
                   "ID".PadRight(63) +
                   "CODE    CODE".PadRight(18) +
                   "CD-1 CD-2 CD-3 CD-4".PadRight(19);
        }

        private async Task<string> h4_head_grp()
        {
            return " A-FEE-1   H-FEE-1   A-FEE-2   H-FEE-2".PadRight(40) +
                   "A-   H-   A-   H-   MAX-GEN   MAX-PRO".PadRight(53) +
                   "PRCNT/ DIAG PHY HOSP I-O ADM  SPEC SPEC".PadRight(39);
        }

        private async Task<string> h5_head_grp()
        {
            return new string(' ', 40) +
                   "ANAE ANAE ASST ASST".PadRight(53) +
                   "FLAT   IND  IND IND  IND IND   FR   TO".PadRight(39);
        }

        private async Task<string> l1_print_line_grp(bool initializeValue = false)
        {
            if (initializeValue)
            {
                l1_oma_code = string.Empty;
                l1_assoc = string.Empty;
                l1_m_suff_allowed = string.Empty;
                l1_page = string.Empty;
                l1_date_yy = 0;
                l1_date_mm = 0;
                l1_date_dd = 0;
                l1_bltrl_id = string.Empty;
                l1_description = string.Empty;
                l1_icc_code = string.Empty;
                l1_reduc_code = string.Empty;
                l1_cd_1 = string.Empty;
                l1_cd_2 = string.Empty;
                l1_cd_3 = string.Empty;
                l1_cd_4 = string.Empty;



                return string.Empty;
            }
            else
            {

                return Util.Str(l1_oma_code).PadRight(4) +
                       new string(' ', 2) +
                       Util.Str(l1_assoc).PadRight(4) +
                       new string(' ', 3) +
                       Util.Str(l1_m_suff_allowed).PadRight(4) +
                       Util.Str(l1_page).PadLeft(3) +
                       new string(' ', 2) +
                       Util.Str(l1_date_yy).PadLeft(4, '0') +
                       Util.Str(l1_slash1).PadRight(1) +
                       Util.Str(l1_date_mm).PadLeft(2, '0') +
                       Util.Str(l1_slash2).PadRight(1) +
                       Util.Str(l1_date_dd).PadLeft(2, '0') +
                       new string(' ', 2) +
                       Util.Str(l1_bltrl_id).PadRight(6) +
                       Util.Str(l1_description).PadRight(56) +
                       Util.Str(l1_icc_code).PadRight(6) +
                       new string(' ', 3) +
                       Util.Str(l1_reduc_code).PadRight(5) +
                       new string(' ', 3) +
                       Util.Str(l1_cd_1).PadRight(4) +
                       new string(' ', 1) +
                       Util.Str(l1_cd_2).PadRight(4) +   // x999
                       new string(' ', 1) +
                       Util.Str(l1_cd_3).PadRight(4) +   // x999
                       new string(' ', 1) +
                       Util.Str(l1_cd_4).PadRight(4);    // x999
            }
        }

        private async Task<string> l2_print_line_grp(bool initializeValue = false)
        {
            if (initializeValue)
            {
                l2_a_fee_1 = 0;
                l2_h_fee_1 = 0;
                l2_a_fee_2 = 0;
                l2_h_fee_2 = 0;
                l2_a_anae = 0;
                l2_h_anae = 0;
                l2_a_asst = 0;
                l2_h_asst = 0;
                l2_max_gen = 0;
                l2_max_pro = 0;
                l2_current = string.Empty;
                l2_prcnt_flat = string.Empty;
                l2_diag_ind = string.Empty;
                l2_phy_ind = string.Empty;
                l2_hosp_ind = string.Empty;
                l2_i_o_ind = string.Empty;
                l2_adm_ind = string.Empty;
                l2_spec_fr = 0;
                l2_spec_to = 0;

                return string.Empty;
            }
            else {
                return Util.ImpliedDecimalFormat("#0.00", l2_a_fee_1, 2, 9, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l2_h_fee_1, 2, 9, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l2_a_fee_2, 2, 9, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l2_h_fee_2, 2, 9, true) +
                       new string(' ', 2) +
                       Util.Str(l2_a_anae).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l2_h_anae).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l2_a_asst).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l2_h_asst).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.ImpliedDecimalFormat("#0.00", l2_max_gen, 2, 9, true) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l2_max_pro, 2, 9, true) +
                       new string(' ', 1) +
                       Util.Str(l2_current).PadRight(14) +
                       Util.Str(l2_prcnt_flat).PadRight(7) +
                       Util.Str(l2_diag_ind).PadRight(4) +
                       Util.Str(l2_phy_ind).PadRight(4) +
                       Util.Str(l2_hosp_ind).PadRight(5) +
                       Util.Str(l2_i_o_ind).PadRight(4) +
                       Util.Str(l2_adm_ind).PadRight(5) +
                       Util.Str(l2_spec_fr).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l2_spec_to).PadLeft(2, '0') +
                       new string(' ', 1) +
                       new string(' ', 3);
            }
        }

        private async Task<string> l3_print_line_grp(bool initializeValue = false)
        {
            if (initializeValue)
            {
                l3_a_fee_1 = 0;
                l3_h_fee_1 = 0;
                l3_a_fee_2 = 0;
                l3_h_fee_2 = 0;
                l3_a_anae = 0;
                l3_h_anae = 0;
                l3_a_asst = 0;
                l3_h_asst = 0;
                l3_max_gen = 0;
                l3_max_pro = 0;
                l3_prev_yr = string.Empty;

                return string.Empty;
            }
            else {
                return Util.ImpliedDecimalFormat("#0.00", l3_a_fee_1, 2, 9) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l3_h_fee_1, 2, 9) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l3_a_fee_2, 2, 9) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l3_h_fee_2, 2, 9) +
                       new string(' ', 2) +
                       Util.Str(l3_a_anae).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l3_h_anae).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l3_a_asst).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.Str(l3_h_asst).PadLeft(2, '0') +
                       new string(' ', 3) +
                       Util.ImpliedDecimalFormat("#0.00", l3_max_gen, 2, 9) +
                       new string(' ', 1) +
                       Util.ImpliedDecimalFormat("#0.00", l3_max_pro, 2, 9) +
                       new string(' ', 1) +
                       Util.Str(l3_prev_yr).PadRight(51);
            }
        }

        public async Task destroy_objects()
        {
            objFee_mstr_rec = null;
            Fee_mstr_rec_Collection = null;
        }

        #endregion
    }
}

