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
    public delegate void U993ExitCobolScreen();
    public class U993ViewModel : CommonFunctionScr
    {
        public event U993ExitCobolScreen ExitCobol;

        public U993ViewModel() {
            
        }

        #region FD Section
            	 // FD: audit_file
	 private Audit_record objAudit_record = null;
	 private ObservableCollection<Audit_record> Audit_record_Collection;

	 // FD: pat_mstr	Copy : f010_patient_mstr.fd
	 private F010_PAT_MSTR objPat_mstr_rec = null;
	 private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;

	 // FD: iconst_mstr	Copy : f090_constants_mstr.fd
	 private ICONST_MSTR_REC objIconst_mstr_rec = null;
	 private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

	 // FD: iconst_mstr	Copy : f090_const_mstr_rec_5.ws
	 private CONSTANTS_MSTR_REC_5 objConstants_mstr_rec_5 = null;
	 private ObservableCollection<CONSTANTS_MSTR_REC_5> Constants_mstr_rec_5_Collection;

        private ReportPrint objAudit_File = null;


        #endregion
        
        #region Properties
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

	 private string _status_file;
	 public string status_file
	 {
		 get
		 {
			  return _status_file;
		 }
		 set
		 {
			  if (_status_file != value)
			   {
				_status_file = value;
				_status_file = _status_file.ToUpper();
				RaisePropertyChanged("status_file");
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


        #endregion
        
        #region Working Storage Section
            	 private int err_ind = 0;
	 private string print_file_name = "ru993";
	 private int pat_occur;
	 private string feedback_pat_mstr;
	 private string feedback_iconst_mstr;
	 private int con_num;
	 private int next_con_num;

	 private string status_indicators_grp;
	 //private string status_file;
	 private string status_cobol_pat_mstr = "0";
	 private string status_cobol_iconst_mstr = "0";
	 private string status_audit_rpt = "0";

	 private string counters_grp;
	 private int ctr_iconst_ikey_rewrites;
	 private int ctr_pat_approx_reads;
	 private int ctr_pat_backward_reads;
	 private int ctr_audit_rpt_writes;

	 private string error_message_table_grp;
	 private string error_messages_grp;
	 /*private string filler = "FATAL - NO SUCH CONSTANTS MSTR REC 5";
	 private string filler = "FATAL - RE-WRITING CONSTANTS MSTR";
	 private string filler = "NO OHIP KEYS ON FILE";
	 private string filler = "NO KEYS BELOW I KEYS"; */
	 private string error_messages_r_grp;
        private string[] err_msg =
            {"", "FATAL - NO SUCH CONSTANTS MSTR REC 5" ,
                 "FATAL - RE-WRITING CONSTANTS MSTR",
                  "NO OHIP KEYS ON FILE" ,
                  "NO KEYS BELOW I KEYS" };

        

	 private string l1_print_line_grp;
	 private string l1_desc;
	 private int l1_value;
	 private string filler;

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

        private string pat_acronym_grp;
        private string pat_acronym;
        private string pat_acronym_first6;
        private string pat_acronym_last3;
        private string pat_ohip_mmyy;
        private string pat_ohip_out_prov;
        private int pat_ohip_nbr;
        private int pat_mm;
        private int pat_yy;
        private string Filler;
        private string pat_ohip_mmyy_r;
        private string pat_direct_alpha_grp;
        private string pat_alpha1;
        private string pat_alpha2_3;
        private string pat_direct_yy;
        private string pat_direct_mm;
        private string pat_direct_dd;
        private string pat_direct_filler;
        private string pat_chart_nbr_grp;
        private string pat_chart_1st_char ;        
        private string pat_chart_remainder ;        
        private string pat_chart_nbr_2_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;        
        private string pat_chart_nbr_3_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;        
        private string pat_chart_nbr_4_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;        
        private string pat_chart_nbr_5_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;        
        private string pat_full_name;
        private string pat_surname;
        private string pat_surname_r_grp;
        private string pat_surname_first6;
        private string pat_surname_last19;
        private string pat_surname_rr_grp;
        private string pat_surname_first3;
        private string pat_surname_last22;
        private string pat_given_name;
        private string pat_given_name_r_grp;
        private string pat_given_name_first3;
        private string pat_given_name_last14;
        private string pat_given_name_rr_grp;
        private string pat_given_name_first1;
        private string pat_init_grp;
        private string pat_init1;
        private string pat_init2;
        private string pat_init3;
        private string pat_location_field_grp;
        private string pat_location_field_1_3;
        private string pat_last_doc_nbr_seen;
        private int pat_birth_date;
        private string pat_birth_date_r_grp;
        private int pat_birth_date_yy;
        private int pat_birth_date_mm;
        private int pat_birth_date_dd;
        private int pat_date_last_maint;
        private string pat_date_last_maint_r_grp;
        private int pat_date_last_maint_yy;
        private int pat_date_last_maint_mm;
        private int pat_date_last_maint_dd;
        private int pat_date_last_visit;
        private string pat_date_last_visit_r_grp;
        private int pat_date_last_visit_yy;
        private int pat_date_last_visit_mm;
        private int pat_date_last_visit_dd;
        private int pat_date_last_admit;
        private string pat_date_last_admit_r_grp;
        private int pat_date_last_admit_yy;
        private int pat_date_last_admit_mm;
        private int pat_date_last_admit_dd;
        private string pat_phone_nbr_grp;
        private int pat_phone_nbr_first3;
        private int pat_phone_nbr_last4;
        private string pat_phone_nbr_remainder;
        private int pat_total_nbr_visits;
        private int pat_total_nbr_claims;
        private string pat_sex;
        private string pat_in_out;
        private int pat_nbr_outstanding_claims;
        private string key_pat_mstr_grp;
        private string pat_i_key;
        private int pat_con_nbr;
        private int pat_i_nbr;
        private int pat_health_nbr;
        private string pat_version_cd_grp;
        private string pat_version_cd_1;
        private string pat_version_cd_2;
        private string pat_health_65_ind;
        private string pat_expiry_date_grp;
        private int pat_expiry_yy;
        private int pat_expiry_mm;
        private string pat_prov_cd;
        private string subscr_addr1;
        private string subscr_addr2;
        private string subscr_addr3;
        private string subscr_prov_cd;
        private string subscr_postal_cd;
        private string subscr_postal_cd_r_grp;
        private string subscr_post_code1_grp;
        private string subscr_post_cd1;
        private int subscr_post_cd2;
        private string subscr_post_cd3;
        private string subscr_post_code2_grp;
        private int subscr_post_cd4;
        private string subscr_post_cd5;
        private int subscr_post_cd6;
        private string subscr_msg_data;
        private string subscr_msg_nbr;
        private int subscr_date_msg_nbr_eff_to;
        private string subscr_date_msg_nbr_eff_to_r;
        private int subscr_date_msg_nbr_eff_to_yy;
        private int subscr_date_msg_nbr_eff_to_mm;
        private int subscr_date_msg_nbr_eff_to_dd;
        private string subscr_date_msg_nbr_eff_to_r1;
        private int subscr_date_last_statement;
        private string subscr_date_last_statement_r_grp;
        private int subscr_date_last_statement_yy;
        private int subscr_date_last_statement_mm;
        private int subscr_date_last_statement_dd;
        private string subscr_auto_update;
        private string pat_last_mod_by;
        private int pat_date_last_elig_mailing;
        private int pat_date_last_elig_maint;
        private int pat_last_birth_date ;        
        private string pat_last_version_cd ;        
        private string pat_mess_code;
        private string pat_country;
        private int pat_no_of_letter_sent;
        private string pat_dialysis;
        private string pat_ohip_validiation_status;
        private string pat_obec_status;

        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection ()
	{
		ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
		{
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "12",Col = 16,Data1 = "PROGRAM U993 NOW BEING PROCESSED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 1,Data1 = "ERROR IN ACCESSING PAT MSTR - KEY = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 38,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(16)",MaxLength = 16,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "key_pat_mstr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-pat-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 1,Data1 = "PROGRAM U993 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "AUDIT REPORT IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(5)",MaxLength = 5,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""} 

		};
		return ScreenDataCollection;
	}
 
        #endregion
        
        #region Procedure Divsion
            	 private async Task declaratives()
	 {

	 }

	 private async Task err_iconst_mstr_file_section()
	 {

		 //     use after standard error procedure on iconst-mstr.;
	 }

	 private async Task err_iconst_mstr()
	 {

		 //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
		 status_file = status_cobol_iconst_mstr;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task err_pat_mstr_file_section()
	 {

		 //     use after standard error procedure on pat-mstr.;
	 }

	 private async Task err_pat_mstr()
	 {

		 status_file = status_cobol_pat_mstr;
		 //     display file-pat-status-display.;
		 //     stop run.;
	 }

	 private async Task err_audit_rpt_file_section()
	 {

		 //     use after standard error procedure on audit-file.;
	 }

	 private async Task err_audit_rpt()
	 {

		 //     stop "ERROR IN WRITING TO AUDIT REPORT FILE".;
		 status_file = status_audit_rpt;
		 //     display file-status-display.;
	 }

	 private async Task end_declaratives()
	 {

	 }

	 private async Task main_line_section()
	 {

	 }

        private async Task initialize_objects()
        {
            objAudit_File = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

            objPat_mstr_rec = null;
            objPat_mstr_rec = new F010_PAT_MSTR();

            Pat_mstr_rec_Collection = null;
            Pat_mstr_rec_Collection = new ObservableCollection<F010_PAT_MSTR>();

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();

            Iconst_mstr_rec_Collection = null;
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objConstants_mstr_rec_5 = null;
            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5();

            Constants_mstr_rec_5_Collection = null;
            Constants_mstr_rec_5_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_5>();
        }

	 public async Task mainline()
	 {
            try {

                await initialize_objects();

        //     perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit.;
                ab0_processing();
                ab0_99_exit();

                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_10_end_of_job();
                await az0_99_exit();

            } catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {

                }
            }
	 }

	 private async Task aa0_initialization()
	 {

            //     accept sys-date			from date.;
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

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            await y2k_default_sysdate();
            await y2k_default_sysdate_exit();

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
            //     open input	pat-mstr.;
            //     open i-o    iconst-mstr.;
            //     open output audit-file.;
            //     counters = 0;
            //objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 5;

            //     read iconst-mstr;
            // 	invalid key;
            //         err_ind = 1;
            // 		perform za0-common-error thru	za0-99-exit;
            // 		go to az0-10-end-of-job.;

            objIconst_mstr_rec = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = 5
            }.Collection().FirstOrDefault();

            if (objIconst_mstr_rec == null)
            {
                  err_ind = 1;
                // perform za0-common-error thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 		go to az0-10-end-of-job.;
                await az0_10_end_of_job();
                return; 
            }
           
        }

	 private async Task aa0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task az0_end_of_job()
	 {

            //     rewrite iconst-mstr-rec;
            // 	invalid key;
            //         err_ind = 2;
            // 		perform za0-common-error thru	za0-99-exit.;

            try {

                objIconst_mstr_rec.RecordState = State.Modified;
                objIconst_mstr_rec.Submit();
            } catch (Exception e)
            {
                   err_ind = 2;
                // perform za0-common-error thru	za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
                return; 
            }

            //     add 1				to ctr-iconst-ikey-rewrites.;
            ctr_iconst_ikey_rewrites++;

            //     perform az1-totals			thru az1-99-exit.;
            await az1_totals();
            await az1_99_exit();
        }

	 private async Task az0_10_end_of_job()
	 {

		 //     close pat-mstr;
		 // 	  iconst-mstr;
		 // 	  audit-file.;
		 //     stop run.;
	 }

	 private async Task az0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task az1_totals()
	 {

		 l1_print_line_grp = "";
            l1_desc = "";
            l1_value = 0;

            l1_desc = "NUMBER OF PAT MSTR APPROX READS = ";

         l1_value = ctr_pat_approx_reads;

            //     write audit-record			from l1-print-line after advancing page.;
            l1_print_line_grp = Util.Str(l1_desc).PadRight(60) +  Util.ImpliedIntegerFormat("#0", l1_value,7, false)  + new string(' ', 65);
            objAudit_record.Audit_record1 = l1_print_line_grp;
            objAudit_File.PageBreak();
            objAudit_File.print(objAudit_record.Audit_record1, 1,true);

            l1_print_line_grp = "";
            l1_desc = "";
            l1_value = 0;

            l1_desc = "NUMBER OF PAT MSTR BACKWARDS READS = ";
            l1_value = ctr_pat_backward_reads;

            //     write audit-record			from l1-print-line after advancing 2 lines.;
            l1_print_line_grp = Util.Str(l1_desc).PadRight(60) + Util.ImpliedIntegerFormat("#0", l1_value, 7, false) + new string(' ', 65);            
            objAudit_record.Audit_record1 = l1_print_line_grp;

            objAudit_File.print(true);
            objAudit_File.print(objAudit_record.Audit_record1, 1, true);

		   l1_print_line_grp = "";
           l1_desc = "NUMBER OF ICONST IKEY REWRITE = ";
           l1_value = ctr_iconst_ikey_rewrites;
            l1_print_line_grp = Util.Str(l1_desc).PadRight(60) + Util.ImpliedIntegerFormat("#0", l1_value, 7, false) + new string(' ', 65);

            //     write audit-record			from l1-print-line after advancing 2 lines.;
            objAudit_record.Audit_record1 = l1_print_line_grp;
            objAudit_File.print(true);
            objAudit_File.print(objAudit_record.Audit_record1, 1, true);

             l1_print_line_grp = "";
            l1_desc = "NUMBER OF AUDIT REPORT WRITES = ";
            l1_value = ctr_audit_rpt_writes;
            l1_print_line_grp = Util.Str(l1_desc).PadRight(60) + Util.ImpliedIntegerFormat("#0", l1_value, 7, false) + new string(' ', 65);
            //     write audit-record			from l1-print-line after advancing 2 lines.;
            objAudit_record.Audit_record1 = l1_print_line_grp;
            objAudit_File.print(true);
            objAudit_File.print(objAudit_record.Audit_record1, 1, true);
        }

	 private async Task az1_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ab0_processing()
	 {

            //     perform ab1-update-con-ikey		thru ab1-99-exit;
            // 	varying con-num from 2 by 1;
            // 		until con-num > 25.;

            con_num = 2;
            do
            {
                await ab1_update_con_ikey();
                await ab1_99_exit();
                con_num++;
            } while (con_num <= 25);

            //     perform ab2-update-lastcon-ikey	thru ab2-99-exit.;
            await ab2_update_lastcon_ikey();
            await ab2_99_exit();
     }

	 private async Task ab0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ab1_update_con_ikey()
	 {

            //pat_mstr_rec = "";
            await Initialize_PatMstr_Rec();
            
            pat_i_key = "I";

            //   next-con-num  =  con-num  +  1.;
            next_con_num = con_num + 1;
                        
            pat_con_nbr = next_con_num;
                        
            pat_i_nbr  = 0;

		      pat_occur = 0;

            //     start pat-mstr  key is greater than or equal to key-pat-mstr.;

            bool isRetrieve = false;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_i_key = pat_i_key,
                WherePat_con_nbr = pat_con_nbr,
                WherePat_i_nbr = pat_i_nbr
            }.Collection_UsingStart(ref isRetrieve, Pat_mstr_rec_Collection);



            //Todo:  Watch out the code below!!! it tries to read the next record and then read previous...????

            //     read pat-mstr next;
            //         at end;
            //          err_ind = 3;
            // 	        perform za0-common-error	thru    za0-99-exit;
            // 	        go to az0-end-of-job.;

            //     add 1				to	ctr-pat-approx-reads.;

            //     read pat-mstr previous;
            // 	      at end;
            //        err_ind = 4;
            // 	      perform za0-common-error	thru    za0-99-exit;
            // 	      go to az0-end-of-job.;

            //     add 1				to	ctr-pat-backward-reads.;

            if (Pat_mstr_rec_Collection.Count() == 0 )
            {
                         err_ind = 3;
                //       perform za0-common-error	thru    za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	        go to az0-end-of-job.;
                await az0_end_of_job();
                return; 
            }

            objPat_mstr_rec = Pat_mstr_rec_Collection[ctr_pat_approx_reads];
            await PatMstr_To_ScreenVariables();

            //  if  pat-con-nbr not = con-num then  
            if (Util.NumInt(pat_con_nbr) != con_num) {
                //    	go to ab1-99-exit.;
                await ab1_99_exit();
                return;
            }

            //     compute const-nx-avail-pat(con-num)  =  pat-i-nbr  +  1.;
            base.CONST_NX_AVAIL_PAT_SET(objConstants_mstr_rec_5, con_num, Util.NumInt(pat_i_nbr) + 1);
        }

        private async Task ab1_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ab2_update_lastcon_ikey()
	 {

		 con_num = 25;

            //pat_mstr_rec = "";
           await Initialize_PatMstr_Rec();

            pat_i_key = "I";

            //     compute     next-con-num  =  con-num  +  1.;
            next_con_num = con_num + 1;

            pat_con_nbr = next_con_num;

            pat_i_nbr = 0;

            pat_occur = 0;

            //  start pat-mstr  key is LESS than or equal to key-pat-mstr.;

            //     read pat-mstr next;
            //       at end;
            //          err_ind = 3;
            //          perform za0-common-error        thru    za0-99-exit;
            //          go to az0-end-of-job.;

            bool isRetrieve = false;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR     
            {
                WherePat_i_key = pat_i_key,
                WherePat_con_nbr = pat_con_nbr,
                WherePat_i_nbr = pat_i_nbr
            }.Collection_UsingStart_LessThanEqual(ref isRetrieve, Pat_mstr_rec_Collection);   // Todo: Watchout! this is using Less than equal for sequential read.

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                   err_ind = 3;
                //          perform za0-common-error        thru    za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                //          go to az0-end-of-job.;
                await az0_end_of_job();
               return; 
            }

            objPat_mstr_rec = Pat_mstr_rec_Collection[ctr_pat_approx_reads];
            await PatMstr_To_ScreenVariables();

            //     add 1                               to      ctr-pat-approx-reads.;
            ctr_pat_approx_reads++;

            //  if  pat-con-nbr not = con-num then  
            if (pat_con_nbr != con_num  ) {
                //         go to ab2-99-exit.;
                await ab2_99_exit();
                return; 
            }

            //     compute const-nx-avail-pat(con-num)  =  pat-i-nbr  +  1.;
            base.CONST_NX_AVAIL_PAT_SET(objConstants_mstr_rec_5, con_num, pat_i_nbr + 1);
        }

        private async Task ab2_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task za0_common_error()
	 {

		    objAudit_record.Audit_record1 = err_msg[err_ind];

            //     write audit-record			after advancing 2 lines.;
            objAudit_File.print(true);
            objAudit_File.print(objAudit_record.Audit_record1,1,true);

            //     add 1				to ctr-audit-rpt-writes.;
            ctr_audit_rpt_writes++;
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

        private async Task Initialize_PatMstr_Rec()
        {
            pat_acronym_grp = "";
            pat_acronym_first6 = "";
            pat_acronym_last3 = "";

            pat_ohip_out_prov = "";
            pat_ohip_nbr = 0;
            pat_mm = 0;
            pat_yy = 0;

            pat_direct_alpha_grp = "";
            pat_alpha1 = "";
            pat_alpha2_3 = "";

            /*pat_ohip_nbr_r_alpha = "";
            pat_ohip_nbr_MB_def_grp = "";
            pat_ohip_nbr_MB = 0;
            pat_ohip_nbr_NT_1_char = "";
            pat_ohip_nbr_NT = 0; */

            pat_direct_yy = "";
            pat_direct_mm = "";
            pat_direct_dd = "";
            //ws_pat_direct_filler = objPat_mstr_rec.pat_

            pat_chart_nbr_grp = "";
            pat_chart_1st_char = "";
            pat_chart_remainder = "";
            pat_chart_nbr_2_grp = "";
            pat_chart_1st_char = "";
            pat_chart_remainder = "";
            pat_chart_nbr_3_grp = "";
            pat_chart_1st_char = "";
            pat_chart_remainder = "";
            pat_chart_nbr_4_grp = "";
            pat_chart_1st_char = "";
            pat_chart_remainder = "";
            pat_chart_nbr_5_grp = "";
            pat_chart_1st_char = "";
            pat_chart_remainder = "";
            pat_surname = "";
            pat_surname_r_grp = "";
            pat_surname_first6 = "";
            pat_surname_last19 = "";
            pat_surname_rr_grp = "";
            pat_surname_first3 = "";
            pat_surname_last22 = "";
            pat_given_name = "";
            pat_given_name_r_grp = "";
            pat_given_name_first3 = "";
            pat_given_name_last14 = "";
            pat_given_name_rr_grp = "";
            pat_given_name_first1 = "";
            //filler 
            pat_init_grp = "";
            pat_location_field_grp = "";
            pat_location_field_1_3 = "";
            pat_last_doc_nbr_seen = "";
            pat_birth_date = 0;
            pat_birth_date_r_grp = "";
            pat_birth_date_yy = 0;
            pat_birth_date_mm = 0;
            pat_birth_date_dd = 0;
            pat_date_last_maint = 0;
            pat_date_last_maint_r_grp = "";
            pat_date_last_maint_yy = 0;
            pat_date_last_maint_mm = 0;
            pat_date_last_maint_dd = 0;
            pat_date_last_visit = 0;
            pat_date_last_visit_r_grp = "";
            pat_date_last_visit_yy = 0;
            pat_date_last_visit_mm = 0;
            pat_date_last_visit_dd = 0;
            pat_date_last_admit = 0;
            pat_date_last_admit_r_grp = "";
            pat_date_last_admit_yy = 0;
            pat_date_last_admit_mm = 0;
            pat_date_last_admit_dd = 0;
            pat_phone_nbr_grp = "";
            pat_phone_nbr_first3 = 0;
            pat_phone_nbr_last4 = 0;
            pat_phone_nbr_remainder = "";
            pat_total_nbr_visits = 0;
            pat_total_nbr_claims = 0;
            pat_sex = "";
            pat_in_out = "";
            pat_nbr_outstanding_claims = 0;
            key_pat_mstr_grp = "";
            pat_i_key = "";
            pat_con_nbr = 0;
            pat_i_nbr = 0;
            pat_health_nbr = 0;
            pat_version_cd_grp = "";
            pat_version_cd_1 = "";
            pat_version_cd_2 = "";
            pat_health_65_ind = "";
            pat_expiry_date_grp = "";
            pat_expiry_yy = 0;
            pat_expiry_mm = 0;
            pat_prov_cd = "";
            subscr_addr1 = "";
            subscr_addr2 = "";
            subscr_addr3 = "";
            subscr_prov_cd = "";
            subscr_postal_cd = "";
            subscr_postal_cd_r_grp = "";
            subscr_post_code1_grp = "";
            subscr_post_cd1 = "";
            subscr_post_cd2 = 0;
            subscr_post_cd3 = "";
            subscr_post_code2_grp = "";
            subscr_post_cd4 = 0;
            subscr_post_cd5 = "";
            subscr_post_cd6 = 0;

            subscr_msg_nbr = "";
            subscr_date_msg_nbr_eff_to = 0;
            subscr_date_msg_nbr_eff_to_r = "";
            subscr_date_msg_nbr_eff_to_yy = 0;
            subscr_date_msg_nbr_eff_to_mm = 0;
            subscr_date_msg_nbr_eff_to_dd = 0;
            subscr_date_msg_nbr_eff_to_r1 = "";
            subscr_date_last_statement = 0;
            subscr_date_last_statement_r_grp = "";
            subscr_date_last_statement_yy = 0;
            subscr_date_last_statement_mm = 0;
            subscr_date_last_statement_dd = 0;
            subscr_auto_update = "";
            pat_last_mod_by = "";
            pat_date_last_elig_mailing = 0;
            pat_date_last_elig_maint = 0;
            pat_last_birth_date = 0;
            pat_last_version_cd = "";
            pat_mess_code = "";
            pat_country = "";
            pat_no_of_letter_sent = 0;
            pat_dialysis = "";
            pat_ohip_validiation_status = "";
            pat_obec_status = "";
        }

        private async Task<bool> PatMstr_To_ScreenVariables()
        {
            pat_acronym_grp = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6) + Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);
            pat_acronym_first6 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6);
            pat_acronym_last3 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);

            pat_ohip_out_prov = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadRight(2) + new string(' ', 6);
            pat_ohip_nbr = Util.NumInt(pat_ohip_out_prov.Substring(0, 8));
            pat_mm = Util.NumInt(pat_ohip_out_prov.Substring(8, 2));
            pat_yy = Util.NumInt(pat_ohip_out_prov.Substring(10, 2));

            pat_direct_alpha_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA);
            pat_alpha1 = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).Substring(0, 1);
            pat_alpha2_3 = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).Substring(1, 2);

            /*pat_ohip_nbr_r_alpha = ws_pat_ohip_out_prov_grp.Substring(0, 8);
            pat_ohip_nbr_MB_def_grp = ws_pat_ohip_out_prov_grp.Substring(0, 8);
            pat_ohip_nbr_MB = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(0, 6));
            pat_ohip_nbr_NT_1_char = ws_pat_ohip_out_prov_grp.Substring(0, 1);
            pat_ohip_nbr_NT = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(1, 7)); */

            pat_direct_yy = Util.Str(objPat_mstr_rec.PAT_DIRECT_YY);
            pat_direct_mm = Util.Str(objPat_mstr_rec.PAT_DIRECT_MM);
            pat_direct_dd = Util.Str(objPat_mstr_rec.PAT_DIRECT_DD);
            //ws_pat_direct_filler = objPat_mstr_rec.pat_

            pat_chart_nbr_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(1, 9);
            pat_chart_nbr_2_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(1, 9);
            pat_chart_nbr_3_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(1, 9);
            pat_chart_nbr_4_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(1, 9);
            pat_chart_nbr_5_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(1, 9);
            pat_surname = Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22);
            pat_surname_r_grp = Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22);
            pat_surname_first6 = pat_surname_r_grp.PadRight(25).Substring(0, 6);
            pat_surname_last19 = pat_surname_r_grp.PadRight(25).Substring(6, 19);
            pat_surname_rr_grp = pat_surname;
            pat_surname_first3 = pat_surname.PadRight(25).Substring(0, 3);
            pat_surname_last22 = pat_surname.PadRight(25).Substring(3, 22);
            pat_given_name = Util.Str(objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1).PadRight(1) + Util.Str(objPat_mstr_rec.FILLER3).PadRight(16);
            pat_given_name_r_grp = pat_given_name;
            pat_given_name_first3 = pat_given_name_r_grp.Substring(0, 3);
            pat_given_name_last14 = pat_given_name_r_grp.Substring(3, 14);
            pat_given_name_rr_grp = pat_given_name_r_grp;
            pat_given_name_first1 = pat_given_name_r_grp.Substring(0, 1);
            //filler 
            pat_init_grp = Util.Str(objPat_mstr_rec.PAT_INIT1) + Util.Str(objPat_mstr_rec.PAT_INIT2) + Util.Str(objPat_mstr_rec.PAT_INIT3);
            pat_location_field_grp = Util.Str(objPat_mstr_rec.PAT_LOCATION_FIELD);
            pat_location_field_1_3 = pat_location_field_grp.PadRight(4).Substring(0, 3);
            pat_last_doc_nbr_seen = Util.Str(objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN);
            pat_birth_date = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY) + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_MM) + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_DD));
            pat_birth_date_r_grp = Util.Str(pat_birth_date);
            pat_birth_date_yy = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_YY);
            pat_birth_date_mm = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_MM);
            pat_birth_date_dd = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_DD);
            pat_date_last_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_MAINT);
            pat_date_last_maint_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT);
            pat_date_last_maint_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(0, 4));
            pat_date_last_maint_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(4, 2));
            pat_date_last_maint_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(6, 2));
            pat_date_last_visit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            pat_date_last_visit_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            pat_date_last_visit_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(0, 4));
            pat_date_last_visit_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(4, 2));
            pat_date_last_visit_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(6, 2));
            pat_date_last_admit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            pat_date_last_admit_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            pat_date_last_admit_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(0, 4));
            pat_date_last_admit_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(4, 2));
            pat_date_last_admit_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(6, 2));
            pat_phone_nbr_grp = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR);
            pat_phone_nbr_first3 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(0, 3));
            pat_phone_nbr_last4 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(3, 4));
            pat_phone_nbr_remainder = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(7, 13);
            pat_total_nbr_visits = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_VISITS);
            pat_total_nbr_claims = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS);
            pat_sex = Util.Str(objPat_mstr_rec.PAT_SEX);
            pat_in_out = Util.Str(objPat_mstr_rec.PAT_IN_OUT);
            pat_nbr_outstanding_claims = Util.NumInt(objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS);
            key_pat_mstr_grp = Util.Str(objPat_mstr_rec.PAT_I_KEY) + Util.Str(objPat_mstr_rec.PAT_CON_NBR) + Util.Str(objPat_mstr_rec.PAT_I_NBR);
            pat_i_key = Util.Str(objPat_mstr_rec.PAT_I_KEY);
            pat_con_nbr = Util.NumInt(objPat_mstr_rec.PAT_CON_NBR);
            pat_i_nbr = Util.NumInt(objPat_mstr_rec.PAT_I_NBR);
            pat_health_nbr = Util.NumInt(objPat_mstr_rec.PAT_HEALTH_NBR);
            pat_version_cd_grp = Util.Str(objPat_mstr_rec.PAT_VERSION_CD);
            pat_version_cd_1 = Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(0, 1);
            pat_version_cd_2 = Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(1, 1);
            pat_health_65_ind = Util.Str(objPat_mstr_rec.PAT_HEALTH_65_IND);
            pat_expiry_date_grp = Util.Str(objPat_mstr_rec.PAT_EXPIRY_YY).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_EXPIRY_MM).PadLeft(2, '0');
            pat_expiry_yy = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_YY);
            pat_expiry_mm = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_MM);
            pat_prov_cd = Util.Str(objPat_mstr_rec.PAT_PROV_CD);
            subscr_addr1 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR1);
            subscr_addr2 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR2);
            subscr_addr3 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR3);
            subscr_prov_cd = Util.Str(objPat_mstr_rec.SUBSCR_PROV_CD);
            subscr_postal_cd = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            subscr_postal_cd_r_grp = subscr_postal_cd;
            subscr_post_code1_grp = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            subscr_post_cd1 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1);
            subscr_post_cd2 = Util.NumInt(objPat_mstr_rec.SUBSCR_POST_CD2);
            subscr_post_cd3 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            subscr_post_code2_grp = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            subscr_post_cd4 = Util.NumInt(objPat_mstr_rec.SUBSCR_POST_CD4);
            subscr_post_cd5 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5);
            subscr_post_cd6 = Util.NumInt(objPat_mstr_rec.SUBSCR_POST_CD6);
            
            subscr_msg_nbr = Util.Str(objPat_mstr_rec.SUBSCR_MSG_NBR);
            subscr_date_msg_nbr_eff_to = Util.NumInt(Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD));
            subscr_date_msg_nbr_eff_to_r = Util.Str(subscr_date_msg_nbr_eff_to);
            subscr_date_msg_nbr_eff_to_yy = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY);
            subscr_date_msg_nbr_eff_to_mm = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM);
            subscr_date_msg_nbr_eff_to_dd = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD);
            subscr_date_msg_nbr_eff_to_r1 = subscr_date_msg_nbr_eff_to_r; //subscr_dt_msg_no_eff_to_r_grp;
            subscr_date_last_statement = Util.NumInt(Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD));
            subscr_date_last_statement_r_grp = Util.Str(subscr_date_last_statement);
            subscr_date_last_statement_yy = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY);
            subscr_date_last_statement_mm = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM);
            subscr_date_last_statement_dd = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD);
            subscr_auto_update = Util.Str(objPat_mstr_rec.SUBSCR_AUTO_UPDATE);
            pat_last_mod_by = Util.Str(objPat_mstr_rec.PAT_LAST_MOD_BY);
            pat_date_last_elig_mailing = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING);
            pat_date_last_elig_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT);
            pat_last_birth_date = Util.NumInt(objPat_mstr_rec.PAT_LAST_BIRTH_DATE);
            pat_last_version_cd = Util.Str(objPat_mstr_rec.PAT_LAST_VERSION_CD);
            pat_mess_code = Util.Str(objPat_mstr_rec.PAT_MESS_CODE);
            pat_country = Util.Str(objPat_mstr_rec.PAT_COUNTRY);
            pat_no_of_letter_sent = Util.NumInt(objPat_mstr_rec.PAT_NO_OF_LETTER_SENT);
            pat_dialysis = Util.Str(objPat_mstr_rec.PAT_DIALYSIS);
            pat_ohip_validiation_status = Util.Str(objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS);
            pat_obec_status = Util.Str(objPat_mstr_rec.PAT_OBEC_STATUS);

            return true;
        }

        public async Task destroy_objects()
        {
            objAudit_File = null;
            objPat_mstr_rec = null;            
            Pat_mstr_rec_Collection = null;            
            objIconst_mstr_rec = null;            
            Iconst_mstr_rec_Collection = null;            
            objConstants_mstr_rec_5 = null;            
            Constants_mstr_rec_5_Collection = null;            
        }

        #endregion
    }
}

