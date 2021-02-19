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
    public delegate void New703ExitCobolScreen();
    public class Newu703ViewModel : CommonFunctionScr
    {
        public event New703ExitCobolScreen ExitCobol;

        public Newu703ViewModel() {

        }

        #region FD Section
        // FD: audit_file_a
        private Rpt_rec_a objRpt_rec_a = null;
        private ObservableCollection<Rpt_rec_a> Rpt_rec_a_Collection;

        // FD: audit_file_b
        private Rpt_rec_b objRpt_rec_b = null;
        private ObservableCollection<Rpt_rec_b> Rpt_rec_b_Collection;

        // FD: audit_file_c
        private Rpt_rec_c objRpt_rec_c = null;
        private ObservableCollection<Rpt_rec_c> Rpt_rec_c_Collection;

        // FD: tp_pat_mstr	Copy : f010_tp_pat_file.fd
        private Tp_pat_mstr_rec objTp_pat_mstr_rec = null;
        private ObservableCollection<Tp_pat_mstr_rec> Tp_pat_mstr_rec_Collection;

        // FD: seq_pat_ikey_file	Copy : f010_seq_patient_file.fd
        private Seq_pat_ikey_file_rec objSeq_pat_ikey_file_rec = null;
        private ObservableCollection<Seq_pat_ikey_file_rec> Seq_pat_ikey_file_rec_Collection;

        // FD: new_pat_file	Copy : f010_new_patient_file.fd
        private New_pat_file_rec objNew_pat_file_rec = null;
        private ObservableCollection<New_pat_file_rec> New_pat_file_rec_Collection;

        // FD: pat_mstr	Copy : f010_patient_mstr.fd
        private F010_PAT_MSTR objPat_mstr_rec = null;
        private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;

        // FD: pat_elig_history	Copy : f011_pat_mstr_elig_history.fd
        private F011_PAT_MSTR_ELIG_HISTORY objF011_pat_mstr_elig_history_rec = null;
        private ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY> F011_pat_mstr_elig_history_rec_Collection;

        // FD: rejected_claims	Copy : f085_rejected_claims.fd
        private REJECTED_CLAIMS  objRejected_claims_rec = null;
        private ObservableCollection<REJECTED_CLAIMS> Rejected_claims_rec_Collection;

        // FD: corrected_pat	Copy : f086_pat_id.fd
        private F086_PAT_ID objPat_id_rec = null;
        private ObservableCollection<F086_PAT_ID> Pat_id_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_5.ws
        private CONSTANTS_MSTR_REC_5 objConstants_mstr_rec_5 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_5> Constants_mstr_rec_5_Collection;

        ReportPrint objAudit_File_a;
        ReportPrint objAudit_File_b;
        ReportPrint objAudit_File_c;

        WriteFile objSeq_pat_ikey_file = null;
        WriteFile objobjNew_pat_file = null;



        #endregion

        #region Properties
        private string _print_file_name_a;
        public string print_file_name_a
        {
            get
            {
                return _print_file_name_a = "ru703a";
            }
           /* set
            {
                if (_print_file_name_a != value)
                {
                    _print_file_name_a = value;
                    _print_file_name_a = _print_file_name_a.ToUpper();
                    RaisePropertyChanged("print_file_name_a");
                }
            } */
        } 

        private string _print_file_name_b;
        public string print_file_name_b
        {
            get
            {
                return _print_file_name_b = "ru703b";
            }
           /* set
            {
                if (_print_file_name_b != value)
                {
                    _print_file_name_b = value;
                    _print_file_name_b = _print_file_name_b.ToUpper();
                    RaisePropertyChanged("print_file_name_b");
                }
            } */
        }

        private string _print_file_name_c;
        public string print_file_name_c
        {
            get
            {
                return _print_file_name_c = "ru703c";
            }
            /*set
            {
                if (_print_file_name_c != value)
                {
                    _print_file_name_c = value;
                    _print_file_name_c = _print_file_name_c.ToUpper();
                    RaisePropertyChanged("print_file_name_c");
                }
            } */
        } 

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
        private string tp_patient_file_name = "submit_disk_pat_in.sf";
        private string seq_patient_file_name = "submit_disk_pat_out";
        private string new_patient_file_name = "submit_disk_pat_new";
       // private string print_file_name_a = "ru703a";
       // private string print_file_name_b = "ru703b";
       // private string print_file_name_c = "ru703c";
        private string feedback_iconst_mstr;
        private string feedback_tp_pat_mstr;
        private string feedback_seq_pat_file;
        private string feedback_new_pat_file;
        private int sub;
        private int err_ind = 0;
        private int space_ctr = 0;

        private string status_indicators_grp;
        //private string status_file;
        private string status_audit_rpt_a = "0";
        private string status_audit_rpt_b = "0";
        private string status_audit_rpt_c = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_tp_pat_mstr = "0";
        private string status_cobol_seq_pat_file = "0";
        private string status_cobol_new_pat_file = "0";
        private string status_cobol_pat_elig_history = "0";
        private string status_cobol_rejected_claims = "0";
        private string status_corrected_pat = "0";
        private string status_cobol_pat_mstr_grp;
        private string status_cobol_pat_mstr1 = "0";
        private string status_cobol_pat_mstr2 = "0";
        private int status_cobol_pat_mstr_binary;
        private string status_cobol_display_grp;
        private string status_cobol_display1;
        //private string filler;
        private int status_cobol_display2;
        private string status_cobol_pat_mstr_hc = "0";
        private string status_cobol_pat_mstr_od = "0";
        private string status_cobol_pat_mstr_acr = "0";
        private string ws_last_name;

        private string ws_first_name_grp;
        private string ws_first_name_1;
        private string ws_first_name_11;
        private string filler;
        private string ws_subscr_surname;

        private string ws_street_addr_grp;
        private string ws_street_addr1;
        private string ws_street_addr2;

        private string ws_city_prov_grp;
        private string ws_city;
        //private string filler;
        private string ws_prov;
        private string ws_prov_cd;

        private string ws_detail_grp;
        private string ws_detail_field;
        private string ws_detail_field_r_grp;
        private string[] ws_detail_byte = new string[29];

        private string ws_phone_no_grp;
        private string ws_area_code;
        private string ws_local_phone_no;

        private string ws_birth_date_grp;
        private int ws_birth_date_yy;
        private int ws_birth_date_mm;
        private int ws_birth_date_dd;

        private string hold_chart_no_grp;
        private string hold_chart_id_no;

        private int hold_health_nbr;

        private string hold_ohip_mmyy_grp;
        private string hold_ohip_no;
        private string hold_ohip_mm;
        private string hold_ohip_yy;


        private string hold_orig_chart_no;
        private string hold_new_chart_no;

        private string hold_acronym_grp;
        private string hold_last_name;
        private string hold_first_name;
        private string hold_orig_acronym;
        private string hold_new_acronym;

        private string hold_version_cd_grp;
        private string hold_version_cd_1;
        private string hold_version_cd_2;

        private string save_pat_ikey_grp;
        private int save_con_nbr;
        private int save_i_nbr;

        private string flag_ohip_vs_chart;
        private string health = "H ";
        private string ohip = "O ";
        private string chart = "C ";
        private string health_and_ohip = "HO";
        private string health_and_chart = "HC";
        private string ohip_and_chart = "OC";
        private string all_three = "AL";

        private int pat_occur;
        private int pat_occur_od;
        private int pat_occur_hc;
        private int pat_occur_acr;
        private int pat_occur_chrt;

        private int hold_pat_occur;
        private int hold_orig_acron_pat_occur;
        private int hold_orig_chart_pat_occur;
        private string ws_feedback_pat_mstr;
        private string hold_feedback_pat_mstr;
        private string hold_orig_acron_feedback;
        private string hold_orig_chrt_feedback;
        private string hold_orig_hc_feedback;
        private string hold_orig_od_feedback;
        private string feedback_pat_mstr;
        private string feedback_pat_mstr_od;
        private string feedback_pat_mstr_hc;
        private string feedback_pat_mstr_acr;
        private string feedback_pat_mstr_chrt;

        private string x_key_pat_mstr_grp;
        private string x_key_pat_mstr_dtl_grp;
        private string x_pat_i_key;
        private int x_pat_con_nbr;
        private int x_pat_i_nbr;
        private string x_filler;
        private string x_key_pat_mstr_r;   //redefines x-key-pat-mstr.    
        private string x_key_pat_mstr_test_grp;
        private string x_ikey_1_digit;
        private string x_ikey_2_11_digits;

        private string hold_pat_ikey_grp;
        private string hold_pat_i_key;
        private int hold_iconst_con_nbr;
        private int hold_iconst_nx_ikey;
        private string eof_tp_pat_mstr;
        private string eof_tape = "Y";
        private string not_eof_tape = "N";
        private string pat_flag;
        private string pat_exist = "Y";
        private string pat_not_exist = "N";
        private string pat_change_flag;
        private string pat_change = "Y";
        private string pat_not_change = "N";
        private string flag_change_version_cd;
        private string version_cd_changed = "Y";
        private string version_cd_not_changed = "N";
        private string flag_old_version_cd;
        private string old_version_cd_matches = "Y";
        private string old_version_cd_doesnt_match = "N";
        private string flag_birth_date_change;
        private string birth_date_changed = "Y";
        private string birth_date_not_changed = "N";
        private string flag_old_birth_date;
        private string old_birth_date_matches = "Y";
        private string old_birth_date_doesnt_match = "N";
        private string flag_1_vs_2_character_ver_cd;
        private string one_char_ver_cd_vs_2_char = "Y";
        private string edit_flag;
        private string valid_record = "Y";
        private string invalid_record = "N";
        private string province_flag;
        private string province_found = "Y";
        private string province_not_found = "N";

        private string counters_grp;
        private int ctr_tp_pat_mstr_reads;
        private int ctr_seq_pat_file_writes;
        private int ctr_new_pat_file_writes;
        private int ctr_pat_mstr_writes;
        private int ctr_pat_mstr_exists;
        private int ctr_write_corrected_pat;
        private int ctr_write_pat_elig_hist;
        private int ctr_error_rpt_writes;
        private int ctr_warnings_rpt_writes;
        private int ctr_page_a;
        private int ctr_page_b;
        private int ctr_page_c;
        private int ctr_reject;
        private int ctr_warning;
        private int ctr_update;

        private string ws_pat_mstr_rec_grp;
        private string ws_pat_acronym_grp;
        private string ws_pat_acronym_first6;
        private string ws_pat_acronym_last3;
        private string ws_pat_ohip_mmyy_grp;
        private string ws_pat_ohip_out_prov_grp;
        private int ws_pat_ohip_nbr;
        private string ws_pat_ohip_nbr_r_alpha;
        private string ws_pat_ohip_nbr_MB_def_grp;
        private int ws_pat_ohip_nbr_MB;
        //private string filler;
        private string ws_pat_ohip_nbr_NT_def_grp;
        private string ws_pat_ohip_nbr_NT_1_char;
        private int ws_pat_ohip_nbr_NT;
        private int ws_pat_mm;
        private int ws_pat_yy;
        //private string filler;
        private string ws_pat_ohip_mmyy_r_grp;
        private string ws_pat_direct_alpha_grp;
        private string ws_pat_alpha1;
        private string ws_pat_alpha2_3;
        private string ws_pat_direct_yy;
        private string ws_pat_direct_mm;
        private string ws_pat_direct_dd;
        private string ws_pat_direct_filler;
        private string ws_pat_chart_nbr_grp;
        private string pat_chart_1st_char;
        private string pat_chart_remainder;
        private string ws_pat_chart_nbr_2_grp;
        private string pat_chart_1st_char_2;
        private string pat_chart_remainder_2;
        private string ws_pat_chart_nbr_3_grp;
        private string pat_chart_1st_char_3;
        private string pat_chart_remainder_3;
        private string ws_pat_chart_nbr_4_grp;
        private string pat_chart_1st_char_4;
        private string pat_chart_remainder_4;
        private string ws_pat_chart_nbr_5_grp;
        private string pat_chart_1st_char_5;
        private string pat_chart_remainder_5;
        private string ws_pat_surname;
        private string ws_pat_surname_r_grp;
        private string ws_pat_surname_first6;
        private string ws_pat_surname_last19;
        private string ws_pat_surname_rr_grp;
        private string ws_pat_surname_first3;
        private string ws_pat_surname_last22;
        private string ws_pat_given_name;
        private string ws_pat_given_name_r_grp;
        private string ws_pat_given_name_first3;
        private string ws_pat_given_name_last14;
        private string ws_pat_given_name_rr_grp;
        private string ws_pat_given_name_first1;
        //private string filler;
        private string ws_pat_init_grp;
        private string ws_pat_init1;
        private string ws_pat_init2;
        private string ws_pat_init3;
        private string ws_pat_location_field_grp;
        private string ws_pat_location_field_1_3;
        //private string filler;
        private string ws_pat_last_doc_nbr_seen;
        private int ws_pat_birth_date;
        private string ws_pat_birth_date_r_grp;
        private int ws_pat_birth_date_yy;
        private string ws_pat_birth_date_yy_r_grp;
        private int ws_pat_birth_date_yy_12;
        private int ws_pat_birth_date_yy_34;
        private int ws_pat_birth_date_mm;
        private int ws_pat_birth_date_dd;
        private int ws_pat_date_last_maint;
        private string ws_pat_date_last_maint_r_grp;
        private int ws_pat_date_last_maint_yy;
        private int ws_pat_date_last_maint_mm;
        private int ws_pat_date_last_maint_dd;
        private int ws_pat_date_last_visit;
        private string ws_pat_date_last_visit_r_grp;
        private int ws_pat_date_last_visit_yy;
        private int ws_pat_date_last_visit_mm;
        private int ws_pat_date_last_visit_dd;
        private int ws_pat_date_last_admit;
        private string ws_pat_date_last_admit_r_grp;
        private int ws_pat_date_last_admit_yy;
        private int ws_pat_date_last_admit_mm;
        private int ws_pat_date_last_admit_dd;
        private string ws_pat_phone_nbr_grp;
        private int ws_pat_phone_nbr_first3;
        private int ws_pat_phone_nbr_last4;
        private string ws_pat_phone_nbr_remainder;
        private int ws_pat_total_nbr_visits;
        private int ws_pat_total_nbr_claims;
        private string ws_pat_sex;
        private string ws_pat_in_out;
        private int ws_pat_nbr_outstanding_claims;
        private string ws_key_pat_mstr_grp;
        private string ws_pat_i_key;
        private int ws_pat_con_nbr;
        private int ws_pat_i_nbr;
        //private string filler;
        private int ws_pat_health_nbr;
        private string ws_pat_version_cd;
        //private string ws_pat_version_cd_1;
        //private string ws_pat_version_cd_2;
        private string ws_pat_health_65_ind;
        private string ws_pat_expiry_date_grp;
        private int ws_pat_expiry_yy;
        private int ws_pat_expiry_mm;
        private string ws_pat_prov_cd;
        private string ws_subscr_addr1;
        private string ws_subscr_addr2;
        private string ws_subscr_addr3;
        private string ws_subscr_prov_cd;
        private string ws_subscr_postal_cd;
        private string ws_subscr_postal_cd_r_grp;
        private string ws_subscr_post_code1_grp;
        private string ws_subscr_post_cd1;
        private int ws_subscr_post_cd2;
        private string ws_subscr_post_cd3;
        private string ws_subscr_post_code2_grp;
        private int ws_subscr_post_cd4;
        private string ws_subscr_post_cd5;
        private int ws_subscr_post_cd6;
        //private string filler;
        private string ws_subscr_msg_data_grp;
        private string ws_subscr_msg_nbr;
        private int ws_subscr_dt_msg_no_eff_to;
        private string ws_subscr_dt_msg_no_eff_to_r_grp;
        private int ws_subscr_dt_msg_no_eff_to_yy;
        private int ws_subscr_dt_msg_no_eff_to_mm;
        private int ws_subscr_dt_msg_no_eff_to_dd;
        private string ws_subscr_dt_msg_no_eff_to_r1;
        private int ws_subscr_date_last_statement;
        private string ws_subscr_date_last_stmnt_r_grp;
        private int ws_subscr_date_last_stmnt_yy;
        private int ws_subscr_date_last_stmnt_mm;
        private int ws_subscr_date_last_stmnt_dd;
        private string ws_subscr_auto_update;
        private string ws_pat_last_mod_by;
        private int ws_pat_date_last_elig_mailing;
        private int ws_pat_date_last_elig_maint;
        private int ws_pat_last_birth_date;
        private string ws_pat_last_birth_date_r_grp;
        private int ws_pat_last_birth_date_yy;
        private int ws_pat_last_birth_date_mm;
        private int ws_pat_last_birth_date_dd;
        private string ws_pat_last_version_cd;
        private string ws_pat_mess_code;
        private string ws_pat_country;
        private int ws_pat_no_of_letter_sent;
        private string ws_pat_dialysis;
        private string ws_pat_ohip_validiation_status;
        private string ws_pat_obec_status;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string[] err_msg = {"", "FUNCTION CODE MUST BE  AA  (ADD)",
                                "HEALTH NO AND CHART NO BOTH CAN'T BE BLANK",
                                "SURNAME CAN'T BE BLANK ",
                                "OVERFLOW ON PATIENT'S SURNAME",
                                "FIRST NAME CAN'T BE BLANK",
                                "OVERFLOW ON PATIENT'S FIRST NAME",
                                "INVALID BIRTH YEAR, MUST BE NUMERIC",
                                "INVALID BIRTH MONTH, MUST BE NUMERIC",
                                "BIRTH MONTH MUST BE BETWEEN 1 TO 12 INCLUSIVE",
                                "INVALID DAY, MUST BE NUMERIC",
                                "BIRTH DAY MUST BE BETWEEN 1 TO 31 INCLUSIVE",
                                "FEB. CAN'T HAVE MORE THAN 29 DAYS",
                                "APR.,JUNE,SEPT.,NOV., ONLY HAVE 30 DAYS",
                                "SEX MUST BE M-MALE  OR  F-FEMALE",
                                "FIRST 8 DIGITS OF ID NO MUST BE NUMERIC",
                                "THE 9TH DIGIT OF ID NO MUST BE NUMERIC OR SPACE",
                                "YY OF ID NO MUST MATCH BIRTH-YY",
                                "MM OF ID NO MUST MATCH BIRTH-MM",
                                "SINCE SEX IS F, LAST DIGIT OF ID NO MUST BE EVEN",
                                "SINCE SEX IS M, LAST DIGIT OF ID NO MUST BE ODD",
                                "STREET ADDRESS  CAN'T BE BLANK",
                                "CITY CAN'T BE BLANK",
                                "OVERFLOW ON CITY",
                                "PROV CAN'T BE BLANK",
                                "INVALID PROVINCE - NOT FOUND FROM THE TABLE",
                                "POSTAL CODE 1 OR 3 OR 5 MUST BE ALPHABETIC",
                                "POSTAL CODE 2 OR 4 OR 6 MUST BE NUMERIC",
                                "VERSION CODE MUST BE ALPHA",
                                "HEALTH NUMBER MUST BE NUMERIC",
                                "INVALID OHIP NUMBER",
                                "SUBSCRIBER SURNAME CAN'T BE BLANK",
                                "OVERFLOW ON SUBSCRIBER'S SURNAME",
                                "RELATIONSHIP MUST BE H-HOLDER  S-SPOUSE  D-DEPENDANT",
                                "FIRST RECORD IS C2, IT IS NOT ALLOWED",
                                "C2 RECORD IS IGNORED BECAUSE C1 RECORD IS INVALID",
                                "OHIP NBR ONLY PATIENT ALREADY EXISTS",
                                "OHIP/CHART NBR PATIENT ALREADY EXISTS",
                                "PATIENT CHART NBR ALREADY EXISTS ",
                                "THERE IS NO 'C2' RECORD FOR THIS 'C1' RECORD",
                                "OHIP NO ALREADY EXISTS WITH CHART NO, CAN'T ADD NEW CHART NO",
                                "THE ACRONYM KEY EXISTS, BUT DATABASE CORRUPTED ",
                                "SUBSCRIBER DOESN'T EXIST",
                                "SUBSCR-AUTO-UPDATE IS 'N', CAN'T CHANGE PAT/SUBSCR MSTR",
                                "CHART EXISTS IN SUBSCR-MSTR, BUT NOT IN PAT-MSTR",
                                "THE CHANGED OHIP NO IS NOT ALLOWED",
                                "OHIP KEY WITH BIRTH MM OR YY CHANGED IS NOT ALLOWED",
                                "CHANGE FROM OHIP TO CHART IS NOT ALLOWED",
                                "CHART NO ALREADY EXISTS WITH OHIP NO, CAN'T ADD NEW OHIP NO",
                                "THE NEW SUBSCR ID EXISTS, CAN'T CHANGE PAT/SUBSCR MSTR",
                               "THE ORIG ACRONYM DOES NOT EXIST, DATA BASE CORRUPTED",
                               "THE NEW ACRONYM KEY EXISTS, CAN'T ADD/CHANGE RECORD",
                               "C1 KEY NOT EXIST, ATTEMPTING TO ADD C2 OHIP BUT IT EXISTS",
                               "C1 KEY NOT EXIST, ATTEMPTING TO ADD C2 CHART BUT IT EXISTS",
                               "** ERROR ** - DUPLICATE IKEY - CONTACT DYAD IMMEDIATELY",
                               "New Patient ADDED to Patient Master",
                               "Patient BIRTH DATE changed",
                               "Patient VERSION CODE changed",
                               "Patient BIRTH DATE and VERSION CODE changed",
                               "Patient OTHER THAN the Birth Date/Version Code changed",
                               "VERSION CODE CANNOT BE NUMERIC"};
        private string error_messages_r_grp;
        //private string[] err_msg =  new string[61];
        private int max_error_message_table = 60;

        private string err_msg_table_grp;
        private string err_no;
        private string err_filler;
        private string err_msg_comment;

        private string prov_table_grp;
        private string province_grp;
        private string[] prov = {"", "ALBTAB",
   	                         "NFLDNL",
   	                         "SASKSK",
   	                         "man mb",
   	                         "nwt nt",
   	                         "ont on",
   	                         "pei pe",
   	                         "que pq",
   	                         "yuk yt",
   	                         "bc  bc",
   	                         "nb  nb",
   	                         "ns  ns",
   	                         "oth ot",
   	                         "nu  nu"};
	 private string province_r_grp;
	 //private string[] prov =  new string[15];
	 //private string[] old_prov =  new string[15];
     private string[] old_prov = {"", "ALBT",
                                "NFLD",
                                "SASK",
                                "man ",
                                "nwt ",
                                "ont ",
                                "pei ",
                                "que ",
                                "yuk ",
                                "bc  ",
                                "nb  ",
                                "ns  ",
                                "oth ",
                                "nu  "};

      //private string[] new_prov =  new string[15];
      private string[] new_prov = {"", "AB",
                                "NL",
                                "SK",
                                "mb",
                                "nt",
                                "on",
                                "pe",
                                "pq",
                                "yt",
                                "bc",
                                "nb",
                                "ns",
                                "ot",
                                "nu"};

        private string h1_head_grp = "ru703a".PadRight(40) + "Diskette Submittal - Patient Upload ERROR Report".PadRight(53);
     //private string filler = "ru703a";
     //private string filler = "Diskette Submittal - Patient Upload ERROR Report";
    // private string filler = "RUN DATE :";
	 private string h1_run_date;
	 //private string filler = "";
	 //private string filler = "  page";
	 private int h1_page_no; 

	 private string h2_head_grp;
	 /*private string filler = "* FUNC CD";
	 private string filler = "last  name";
	 private string filler = "first  name";
	 private string filler = "BIRTH DATE  SEX";
	 private string filler = "CHART #  HEALTH #";
	 private string filler = "subscriber surname";
	 private string filler = "INITIALS"; */

	 private string h3_head_grp;
	 //private string filler = "ru703b";
	 //private string filler = "Diskette Submittal - Patient Upload AUDIT Report";
	 //private string filler = "RUN DATE :";
	 private string h3_run_date;
	 //private string filler = "";
	 //private string filler = "  page";
	 private int h3_page_no;

	 private string h4_head_grp;
	 //private string filler = "ru703c";
	 //private string filler = "Diskette Submittal - Patient Addition UPDATE EXCEPTIONS Report";
	 //private string filler = "RUN DATE :";
	 private string h4_run_date;
	 //private string filler = "";
	 //private string filler = "  page";
	 private int h4_page_no;

	 private string h5_head_grp;
	 /*private string filler = "";
	 private string filler = "health/acct'ing #";
	 private string filler = "birth date";
	 private string filler = "version cd";
	 private string filler = ""; */

	 private string l1_line_grp;
	 //private string filler;
	 private string l1_func_cd;
	 //private string filler;
	 private string l1_last_name;
	 //private string filler;
	 private string l1_first_name;
	 //private string filler;
	 private string l1_date_grp;
	 private int l1_yy;
	 private string l1_slash1 = "/";
	 private int l1_mm;
	 private string l1_slash2 = "/";
	 private int l1_dd;
	 //private string filler;
	 private string l1_sex;
	 //private string filler;
	 private string l1_id_no;
	 //private string filler;
	 private string l1_health_no;
	 //private string filler;
	 private string l1_subscr_name;
	 //private string filler;
	 private string l1_subscr_init;
	 //private string filler;

	 private string l2_line_grp;
	 //private string filler = "  ADDRESS: ";
	 private string l2_street_addr;
	 //private string filler = ", ";
	 private string l2_city;
	 //private string filler = ", ";
	 private string l2_prov;
	 //private string filler = ", ";
	 private string l2_postal_cd;
	 //private string filler = " PHONE: ";
	 private string l2_phone_no;
	 //private string filler = "";
	 //private string filler = "  VERSION: ";
	 private string l2_version_cd;
	 //private string filler = " MESSAGE ID: ";
	 private string l2_mess_id;

	 private string l3_line_grp;
	 private int l3_doc_ohip_nbr;
	 //private string filler;
	 private string l3_doc_accounting_nbr;
	 //private string filler;

	 private string l4_line_grp;
	 private string l4_title;
	 private int l4_ctr;
	 //private string filler;

	 private string prt_det_line1_grp;
	 private string prt_lit1 = "";
	 private string prt_ohip_health_nbr;
	 //private string filler = "";
	 private int rma_birth_date_yy;
	 //private string filler = "/";
	 private int rma_birth_date_mm;
	 //private string filler = "/";
	 private int rma_birth_date_dd;
	 //private string filler = "";
	 private string rma_version_cd;
	 //private string filler = "";
	 private string rma_prov_cd;
	 //private string filler = "";
	 private string rma_reason_desc = "";

	 private string prt_det_line2_grp;
	 private string prt_lit2 = "";
	 private int disk_doctor_nbr;
	 private string disk_account_id = "";
	 //private string filler = "";
	 private int disk_birth_date_yy;
	 //private string filler = "/";
	 private int disk_birth_date_mm;
	 //private string filler = "/";
	 private int disk_birth_date_dd;
	 //private string filler = "";
	 private string disk_version_cd;
	 //private string filler = "";
	 private string disk_prov_cd;
	 //private string filler = "";

	/* private string hold_chart_no_grp;
	 private string hold_chart_id_no;
	 private int hold_health_nbr;

	 private string hold_ohip_mmyy_grp;
	 private string hold_ohip_no;
	 private string hold_ohip_mm;
	 private string hold_ohip_yy;
	 //private string filler;
	 private string hold_orig_chart_no;
	 private string hold_new_chart_no;

	 private string hold_acronym_grp;
	 private string hold_last_name;
	 private string hold_first_name;
	 private string hold_orig_acronym;
	 private string hold_new_acronym;

	 private string hold_version_cd_grp;
	 private string hold_version_cd_1;
	 private string hold_version_cd_2;

	 private string save_pat_ikey_grp;
	 private int save_con_nbr;
	 private int save_i_nbr;
	 private string flag_ohip_vs_chart;
	 private string health_and_ohip;
	 private string health_and_chart;
	 private string ohip_and_chart;
	 private string all_three;
	 private int pat_occur;
	 private int pat_occur_od;
	 private int pat_occur_hc;
	 private int pat_occur_acr;
	 private int pat_occur_chrt;
	 private int hold_pat_occur;
	 private int hold_orig_acron_pat_occur;
	 private int hold_orig_chart_pat_occur;
	 private string ws_feedback_pat_mstr;
	 private string hold_feedback_pat_mstr;
	 private string hold_orig_acron_feedback;
	 private string hold_orig_chrt_feedback;
	 private string hold_orig_hc_feedback;
	 private string hold_orig_od_feedback;
	 private string feedback_pat_mstr;
	 private string feedback_pat_mstr_od;
	 private string feedback_pat_mstr_hc;
	 private string feedback_pat_mstr_acr;
	 private string feedback_pat_mstr_chrt;

	 private string x_key_pat_mstr_grp;
	 private string x_key_pat_mstr_dtl_grp;
	 private string x_pat_i_key;
	 private int x_pat_con_nbr;
	 private int x_pat_i_nbr;
	 private string x_filler; */

	 private string x_key_pat_mstr_r_grp;
	 //private string filler;
	 //private string x_key_pat_mstr_test_grp;
	 //private string x_ikey_1_digit;
	 private string x_ikey_2_11_digits_grp;
	 private string x_ikey_2_digit;
	 private string x_ikey_3_11_digits;
	 //private string filler;

	 private string x_pat_chart_nbr_4_grp;
	 private string x_pat_chart4_1_digit;
	 private string x_pat_chart4_9_digits;

	/* private string ws_pat_mstr_rec_grp;
	 private string ws_pat_acronym_grp;
	 private string ws_pat_acronym_first6;
	 private string ws_pat_acronym_last3;
	 private string ws_pat_ohip_mmyy_grp;
	 private string ws_pat_ohip_out_prov_grp;
	 private int ws_pat_ohip_nbr;
	 private string ws_pat_ohip_nbr_r_alpha;
	 private string ws_pat_ohip_nbr_MB_def_grp;
	 private int ws_pat_ohip_nbr_MB;
	 //private string filler;
	 private string ws_pat_ohip_nbr_NT_def_grp;
	 private string ws_pat_ohip_nbr_NT_1_char;
	 private int ws_pat_ohip_nbr_NT;
	 private int ws_pat_mm;
	 private int ws_pat_yy;
	 //private string filler;
	 private string ws_pat_ohip_mmyy_r_grp;
	 private string ws_pat_direct_alpha_grp;
	 private string ws_pat_alpha1;
	 private string ws_pat_alpha2_3;
	 private string ws_pat_direct_yy;
	 private string ws_pat_direct_mm;
	 private string ws_pat_direct_dd;
	 private string ws_pat_direct_filler;
	 private string ws_pat_chart_nbr_grp;
	 private string pat_chart_1st_char;
	 private string pat_chart_remainder;
	 private string ws_pat_chart_nbr_2_grp;
	 //private string pat_chart_1st_char;
	 //private string pat_chart_remainder;
	 private string ws_pat_chart_nbr_3_grp;
	 //private string pat_chart_1st_char;
	 //private string pat_chart_remainder;
	 private string ws_pat_chart_nbr_4_grp;
	 //private string pat_chart_1st_char;
	 //private string pat_chart_remainder;
	 private string ws_pat_chart_nbr_5_grp;
	 //private string pat_chart_1st_char;
	 //private string pat_chart_remainder;
	 private string ws_pat_surname;
	 private string ws_pat_surname_r_grp;
	 private string ws_pat_surname_first6;
	 private string ws_pat_surname_last19;
	 private string ws_pat_surname_rr_grp;
	 private string ws_pat_surname_first3;
	 private string ws_pat_surname_last22;
	 private string ws_pat_given_name;
	 private string ws_pat_given_name_r_grp;
	 private string ws_pat_given_name_first3;
	 private string ws_pat_given_name_last14;
	 private string ws_pat_given_name_rr_grp;
	 private string ws_pat_given_name_first1;
	 //private string filler;
	 private string ws_pat_init_grp;
	 private string ws_pat_init1;
	 private string ws_pat_init2;
	 private string ws_pat_init3;
	 private string ws_pat_location_field_grp;
	 private string ws_pat_location_field_1_3;
	 //private string filler;
	 private string ws_pat_last_doc_nbr_seen;
	 private int ws_pat_birth_date;
	 private string ws_pat_birth_date_r_grp;
	 private int ws_pat_birth_date_yy;
	 private string ws_pat_birth_date_yy_r_grp;
	 private int ws_pat_birth_date_yy_12;
	 private int ws_pat_birth_date_yy_34;
	 private int ws_pat_birth_date_mm;
	 private int ws_pat_birth_date_dd;
	 private int ws_pat_date_last_maint;
	 private string ws_pat_date_last_maint_r_grp;
	 private int ws_pat_date_last_maint_yy;
	 private int ws_pat_date_last_maint_mm;
	 private int ws_pat_date_last_maint_dd;
	 private int ws_pat_date_last_visit;
	 private string ws_pat_date_last_visit_r_grp;
	 private int ws_pat_date_last_visit_yy;
	 private int ws_pat_date_last_visit_mm;
	 private int ws_pat_date_last_visit_dd;
	 private int ws_pat_date_last_admit;
	 private string ws_pat_date_last_admit_r_grp;
	 private int ws_pat_date_last_admit_yy;
	 private int ws_pat_date_last_admit_mm;
	 private int ws_pat_date_last_admit_dd;
	 private string ws_pat_phone_nbr_grp;
	 private int ws_pat_phone_nbr_first3;
	 private int ws_pat_phone_nbr_last4;
	 private string ws_pat_phone_nbr_remainder;
	 private int ws_pat_total_nbr_visits;
	 private int ws_pat_total_nbr_claims;
	 private string ws_pat_sex;
	 private string ws_pat_in_out;
	 private int ws_pat_nbr_outstanding_claims;
	 private string ws_key_pat_mstr_grp;
	 private string ws_pat_i_key;
	 private int ws_pat_con_nbr;
	 private int ws_pat_i_nbr;
	 //private string filler;
	 private int ws_pat_health_nbr;
	 private string ws_pat_version_cd_grp;
	 private string ws_pat_version_cd_1;
	 private string ws_pat_version_cd_2;
	 private string ws_pat_health_65_ind;
	 private string ws_pat_expiry_date_grp;
	 private int ws_pat_expiry_yy;
	 private int ws_pat_expiry_mm;
	 private string ws_pat_prov_cd;
	 private string ws_subscr_addr1;
	 private string ws_subscr_addr2;
	 private string ws_subscr_addr3;
	 private string ws_subscr_prov_cd;
	 private string ws_subscr_postal_cd;
	 private string ws_subscr_postal_cd_r_grp;
	 private string ws_subscr_post_code1_grp;
	 private string ws_subscr_post_cd1;
	 private int ws_subscr_post_cd2;
	 private string ws_subscr_post_cd3;
	 private string ws_subscr_post_code2_grp;
	 private int ws_subscr_post_cd4;
	 private string ws_subscr_post_cd5;
	 private int ws_subscr_post_cd6;
	 //private string filler;
	 private string ws_subscr_msg_data_grp;
	 private string ws_subscr_msg_nbr;
	 private int ws_subscr_dt_msg_no_eff_to;
	 private string ws_subscr_dt_msg_no_eff_to_r_grp;
	 private int ws_subscr_dt_msg_no_eff_to_yy;
	 private int ws_subscr_dt_msg_no_eff_to_mm;
	 private int ws_subscr_dt_msg_no_eff_to_dd;
	 private string ws_subscr_dt_msg_no_eff_to_r1;
	 private int ws_subscr_date_last_statement;
	 private string ws_subscr_date_last_stmnt_r_grp;
	 private int ws_subscr_date_last_stmnt_yy;
	 private int ws_subscr_date_last_stmnt_mm;
	 private int ws_subscr_date_last_stmnt_dd;
	 private string ws_subscr_auto_update;
	 private string ws_pat_last_mod_by;
	 private int ws_pat_date_last_elig_mailing;
	 private int ws_pat_date_last_elig_maint;
	 private int ws_pat_last_birth_date;
	 private string ws_pat_last_birth_date_r_grp;
	 private int ws_pat_last_birth_date_yy;
	 private int ws_pat_last_birth_date_mm;
	 private int ws_pat_last_birth_date_dd;
	 private string ws_pat_last_version_cd;
	 private string ws_pat_mess_code;
	 private string ws_pat_country;
	 private int ws_pat_no_of_letter_sent;
	 private string ws_pat_dialysis;
	 private string ws_pat_ohip_validiation_status;
	 private string ws_pat_obec_status; */
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
        private string pat_acronym_first6;
        private string pat_acronym_last3;
        private string pat_ohip_mmyy_grp;
        private string pat_ohip_out_prov_grp;
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
        //private string pat_chart_1st_char ;        
        //private string pat_chart_remainder ;        
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

        private int pat_mstr_Rec_ctr;  //Rec ctr for Pat Mstr.
        private int pat_mstr_Rec_WS_ctr; // Rect ctr for Past Mstr using WS prefix .
        private string low_values = "A";

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection ()
	{
		ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
		{
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "12",Col = 10,Data1 = "DISKETTE SUBMITTAL PATIENT UPLOAD BEING PROCESSED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 1,Data1 = "PROGRAM U703 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 46,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 56,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 10,Data1 = "AUDIT REPORTS ARE IN FILES - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 43,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_a",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 51,Data1 = "&",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 54,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_b",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 62,Data1 = "&",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_c",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""} 

		};
		return ScreenDataCollection;
	}
 
        #endregion
        
        #region Procedure Divsion
            	 private async Task declaratives()
	 {

	 }

	 private async Task err_tp_pat_mstr_file_section()
	 {

		 //     use after standard error procedure on tp-pat-mstr.;
	 }

	 private async Task err_tp_pat_mstr()
	 {

		 //     stop "ERROR IN ACCESSING TP PATIENT MASTER".;
		 status_file = status_cobol_tp_pat_mstr;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task err_seq_pat_ikey_file_section()
	 {

		 //     use after standard error procedure on seq-pat-ikey-file.;
	 }

	 private async Task err_seq_pat_ikey()
	 {

		 //     stop "ERROR IN ACCESSING SEQUENTIAL OUTPUT PATIENT I-KEY FILE".;
		 status_file = status_cobol_seq_pat_file;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task err_new_pat_file_section()
	 {

		 //     use after standard error procedure on new-pat-file.;
	 }

	 private async Task err_new_pat()
	 {

		 //     stop "ERROR IN ACCESSING SEQENTIAL NEW PATIENT FILE".;
		 status_file = status_cobol_new_pat_file;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task err_pat_mstr_file_section()
	 {

		 //     use after standard error procedure on pat-mstr.;
	 }

	 private async Task err_pat_mstr()
	 {

		 //     stop "ERROR IN ACCESSING PATIENT MASTER".;
		 //status_file = status_cobol_pat_mstr;
		 //     display file-status-display.;
		 status_cobol_display1 = status_cobol_pat_mstr1;
		 //     if   status-cobol-pat-mstr1 <> 9;
		 //     then;
		 //status_cobol_display2 = status_cobol_pat_mstr2;
		 //     else;
		 //status_cobol_pat_mstr1 = low_values;
		 status_cobol_display2 = status_cobol_pat_mstr_binary;
		 //     display "Patient error = ", status-cobol-display.;
		 //     stop run.;
	 }

	 private async Task err_iconst_mstr_file_section()
	 {

		 //     use after standard error procedure on iconst-mstr.;
	 }

	 private async Task err_iconst_mstr()
	 {

		 //     stop "ERROR IN ACCESSING CONSTANT MASTER".;
		 status_file = status_cobol_iconst_mstr;
            //     display file-status-display.;
            //     stop run.;
            throw new Exception("ERROR IN ACCESSING CONSTANT MASTER");
	 }

	 private async Task err_audit_rpt_file_a_section()
	 {

		 //     use after standard error procedure on audit-file-a.;
	 }

	 private async Task err_audit_rpt_a()
	 {

		 //     stop "ERROR IN WRITING TO AUDIT REPORT FILE-A".;
		 status_file = status_audit_rpt_a;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task err_audit_rpt_file_b_section()
	 {

		 //     use after standard error procedure on audit-file-b.;
	 }

	 private async Task err_audit_rpt_b()
	 {

		 //     stop "ERROR IN WRITING TO AUDIT REPORT FILE-B".;
		 status_file = status_audit_rpt_b;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task err_audit_rpt_file_c_section()
	 {

		 //     use after standard error procedure on audit-file-c.;
	 }

	 private async Task err_audit_rpt_c()
	 {

		 //     stop "ERROR IN WRITING TO AUDIT REPORT FILE-C".;
		 status_file = status_audit_rpt_c;
		 //     display file-status-display.;
		 //     stop run.;
	 }

	 private async Task end_declaratives()
	 {

	 }

	 private async Task main_line_section()
	 {

	 }

        private async Task initialize_objects()
        {
            objRpt_rec_a = null;
            objRpt_rec_a = new Rpt_rec_a();

            Rpt_rec_a_Collection = null;
            Rpt_rec_a_Collection = new ObservableCollection<Rpt_rec_a>();

            objRpt_rec_b = null;
            objRpt_rec_b = new Rpt_rec_b();

            Rpt_rec_b_Collection = null;
            Rpt_rec_b_Collection = new ObservableCollection<Rpt_rec_b>();

            objRpt_rec_c = null;
            objRpt_rec_c = new Rpt_rec_c();

            Rpt_rec_c_Collection = null;
            Rpt_rec_c_Collection = new ObservableCollection<Rpt_rec_c>();

            objTp_pat_mstr_rec = null;
            objTp_pat_mstr_rec = new Tp_pat_mstr_rec();

            Tp_pat_mstr_rec_Collection = null;
            Tp_pat_mstr_rec_Collection = new ObservableCollection<Tp_pat_mstr_rec>();

            objSeq_pat_ikey_file_rec = null;
            objSeq_pat_ikey_file_rec = new Seq_pat_ikey_file_rec();

            Seq_pat_ikey_file_rec_Collection = null;
            Seq_pat_ikey_file_rec_Collection = new ObservableCollection<Seq_pat_ikey_file_rec>();

            objNew_pat_file_rec = null;
            objNew_pat_file_rec = new New_pat_file_rec();

            New_pat_file_rec_Collection = null;
            New_pat_file_rec_Collection = new ObservableCollection<New_pat_file_rec>();

            objPat_mstr_rec = null;
            objPat_mstr_rec = new F010_PAT_MSTR();

            Pat_mstr_rec_Collection = null;
            Pat_mstr_rec_Collection = new ObservableCollection<F010_PAT_MSTR>();

            objF011_pat_mstr_elig_history_rec = null;
            objF011_pat_mstr_elig_history_rec = new F011_PAT_MSTR_ELIG_HISTORY();

            F011_pat_mstr_elig_history_rec_Collection = null;
            F011_pat_mstr_elig_history_rec_Collection = new ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>();

            objRejected_claims_rec = null;
            objRejected_claims_rec = new REJECTED_CLAIMS();

            Rejected_claims_rec_Collection = null;
            Rejected_claims_rec_Collection = new ObservableCollection<REJECTED_CLAIMS>();

            objPat_id_rec = null;
            objPat_id_rec = new F086_PAT_ID();

            Pat_id_rec_Collection = null;
            Pat_id_rec_Collection = new ObservableCollection<F086_PAT_ID>();

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();

            Iconst_mstr_rec_Collection = null;
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objConstants_mstr_rec_5 = null;
            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5();

            Constants_mstr_rec_5_Collection = null;
            Constants_mstr_rec_5_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_5>();

            objAudit_File_a = null;
            objAudit_File_a = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_a);

            objAudit_File_b = null;
            objAudit_File_b = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_b);

            objAudit_File_c = null;
            objAudit_File_c = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_c);

            objSeq_pat_ikey_file = null;
            objSeq_pat_ikey_file = new WriteFile(Directory.GetCurrentDirectory() + "\\" + seq_patient_file_name, false);

            objobjNew_pat_file = null;
            objobjNew_pat_file = new WriteFile(Directory.GetCurrentDirectory() + "\\" + new_patient_file_name, false);
        }

	 public async Task mainline()
	 {
            try {

                await initialize_objects();

                //     perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit;
                //             until eof-tape.;

                do
                {
                    await ab0_processing();
                    await ab0_80_read_next_rec();
                    await ab0_99_exit();
                } while (!eof_tp_pat_mstr.Equals(eof_tape));


                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_99_exit();

        //     stop run.;
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

            //     open input 	tp-pat-mstr.;

            //     open i-o  	pat-mstr;
            // 		        pat-elig-history;
            // 	            iconst-mstr.;

            //     open extend corrected-pat.;

            //     open output audit-file-a;
            //     		audit-file-b;
            //     		audit-file-c;
            // 		    seq-pat-ikey-file;
            // 		    new-pat-file.;

            //counters = 0;
            ctr_tp_pat_mstr_reads = 0;
            ctr_seq_pat_file_writes = 0;
            ctr_new_pat_file_writes = 0;
            ctr_pat_mstr_writes = 0;
            ctr_pat_mstr_exists = 0;
            ctr_write_corrected_pat = 0;
            ctr_write_pat_elig_hist = 0;
            ctr_error_rpt_writes = 0;
            ctr_warnings_rpt_writes = 0;
            ctr_page_a = 0;
            ctr_page_b = 0;
            ctr_page_c = 0;
            ctr_reject = 0;
            ctr_warning = 0;
            ctr_update = 0;

            //     add 1 				to ctr-page-a.;
            ctr_page_a++;

            h1_run_date = run_date_grp;
           h3_run_date = run_date_grp;
            h4_run_date = run_date_grp;
           
            h1_page_no = ctr_page_a;
            //     write rpt-rec-a from h1-head after advancing page.;
            objRpt_rec_a.Rpt_rec_a1 = "ru703a".PadRight(40) +
                                      "Diskette Submittal - Patient Upload ERROR Report".PadRight(53) +
                                      "RUN DATE :".PadRight(11) +
                                      Util.Str(h1_run_date).PadRight(10) +
                                      new string(' ', 5) +
                                      "  PAGE".PadRight(7) +
                                      Util.ImpliedIntegerFormat("#0", h1_page_no, 3, false);
            objAudit_File_a.PageBreak();
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);


            //objRpt_rec_a.rpt_rec_a = "";
            objRpt_rec_a.Rpt_rec_a1 = "";

            //     write rpt-rec-a after advancing 2 lines.;
            objAudit_File_a.print(true);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

            //     perform aa1-print-message-table  	thru aa1-99-exit;
            //             varying sub from 1 by 1;
            //             until sub >  max-error-message-table.;

            sub = 1;
            do
            {
                await aa1_print_message_table();
                await aa1_99_exit();
                sub++;
            } while (sub <= max_error_message_table);


            //objConstants_mstr_rec_5.const_rec_5_rec_nbr = 5;

            //  read iconst-mstr;
            //    	invalid key;
            // 		  go to err-iconst-mstr.;
            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5
            {
                WhereConst_rec_nbr = 5
            }.Collection().FirstOrDefault();

            if (objConstants_mstr_rec_5 == null)
            {
                //  go to err-iconst-mstr.;
                await err_iconst_mstr();
                return; 
            }

            hold_pat_i_key = "I";
            hold_iconst_con_nbr = Util.NumInt(CONST_CON_NBR_GET(objConstants_mstr_rec_5, 25));
            hold_iconst_nx_ikey = Util.NumInt(CONST_NX_AVAIL_PAT_GET(objConstants_mstr_rec_5, 25));

            //l3_line = "all "-"";  //todo: not sure about this....???
            l3_line_grp = new string('-', 132);

		 ctr_reject = 20;
		 ctr_update = 20;
		 ctr_warning = 20;
		 
		 eof_tp_pat_mstr = "N";

            //     display scr-title.;
            Display("scr-title.");

            //     perform ya0-read-next-tape          thru ya0-99-exit.;
            await ya0_read_next_tape();
            await ya0_99_exit();
     }

	 private async Task aa0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task aa1_print_message_table()
	 {

		 objRpt_rec_a.Rpt_rec_a1 = "";

		 err_msg_table_grp = "";
            err_no = "";
            err_filler = "";
            err_msg_comment = "";

		 err_no = Util.Str(sub);

		 err_filler = ":";
		 err_msg_comment = err_msg[sub];

            //     write rpt-rec-a from err-msg-table after advancing 1 line.;
            err_msg_table_grp = Util.Str(err_no).PadRight(4) + Util.Str(err_filler).PadRight(3) + Util.Str(err_msg_comment).PadRight(64);
            objRpt_rec_a.Rpt_rec_a1 = err_msg_table_grp;
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
	 }

	 private async Task aa1_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ab0_processing()
	 {

		 pat_flag = "N";

            // if  (tp-pat-prov = 'ON' or 'ONT') and tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9 and tp-pat-ohip-health-no is numeric then
            if ( (Util.Str(objTp_pat_mstr_rec.Tp_pat_prov).ToUpper() == "ON" || Util.Str(objTp_pat_mstr_rec.Tp_pat_prov).ToUpper() == "ONT" ) && 
                 Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 6 && Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 9 && Util.IsNumeric(objTp_pat_mstr_rec.Tp_pat_ohip_health_no)  ) {

                // move tp-pat-ohip-health-no              to pat-health-nbr of pat-mstr
                pat_health_nbr = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);

                //  perform yb0-3-read-hc-pat-mstr          thru yb0-3-99-exit;
                await yb0_3_read_hc_pat_mstr();
                await yb0_3_99_exit();
            }
            // else if tp-pat-ohip-health-no not = spaces then  
            else if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_ohip_health_no)) {
                //      objPat_mstr.Pat_ohip_mmyy = objTp_pat_mstr_rec.tp_pat_ohip_health_no;

                //move tp-pat-ohip-health-no              to pat-ohip-mmyy of pat-mstr
                pat_ohip_mmyy_grp = Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);

                //      perform yb0-5-read-od-pat-mstr          thru yb0-5-99-exit.;
                await yb0_5_read_od_pat_mstr();
                await yb0_5_99_exit();
            }

            // if  pat-exist  then
            if (pat_flag.Equals(pat_exist) ) {
                // 	   perform yd0-build-seq-pat-rec		thru yd0-99-exit;
                await yd0_build_seq_pat_rec();
                await yd0_99_exit();
                // 	   perform ye0-write-seq-pat-rec		thru ye0-99-exit;
                await ye0_write_seq_pat_rec();
                await ye0_99_exit();

                //    add 1					to ctr-pat-mstr-exists;
                ctr_pat_mstr_exists++;
                // 	   perform yg0-check-update-pat		thru yg0-99-exit;
                await yg0_check_update_pat();
                await yg0_80();
                await yg0_99_exit();
                // 	   go to ab0-80-read-next-rec.;
                await ab0_80_read_next_rec();
                return; 
            }

            //   perform ba0-preliminary-edit-patient 	thru	ba0-99-exit.;
            await ba0_preliminary_edit_patient();
            await ba0_edit_birth_date_version_cd();
            await ba0_99_exit();

            // if valid-record  then
            if (edit_flag.Equals(valid_record) ) {
                //   	perform ca0-add-mode-processing		thru	ca0-99-exit;
                await ca0_add_mode_processing();
                await ca0_99_exit();
            }
            else {
                // 	   perform xa0-write-tp-error-report	thru	xa0-99-exit.;
                await xa0_write_tp_error_report();
                await xa0_99_exit();
            }
        }

        private async Task ab0_80_read_next_rec()
	 {

            //     perform ya0-read-next-tape			thru	ya0-99-exit.;
            await ya0_read_next_tape();
            await ya0_99_exit();
     }

	 private async Task ab0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task az0_end_of_job()
	 {

            //  perform az1-totals			thru az1-99-exit.;
            await az1_totals();
            await az1_99_exit();

            // objConstants_mstr_rec_5.const_rec_5_rec_nbr = 5;

            //     read iconst-mstr with lock;
            //         invalid key;
            //            go to err-iconst-mstr.;

            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5
            {
                WhereConst_rec_nbr = 5
            }.Collection().FirstOrDefault();

            if (objConstants_mstr_rec_5 == null)
            {
                //    go to err-iconst-mstr.;
                await err_iconst_mstr();
                return; 
            }

            //const_con_nbr[25] = hold_iconst_con_nbr;
            CONST_CON_NBR_SET(objConstants_mstr_rec_5, 25, hold_iconst_con_nbr);
            //const_nx_avail_pat[25] = hold_iconst_nx_ikey;
            CONST_NX_AVAIL_PAT_SET(objConstants_mstr_rec_5, 25, hold_iconst_nx_ikey);

            //   rewrite iconst-mstr-rec;
            // 	invalid key;
            // 		go to err-iconst-mstr.;

            try {
                objConstants_mstr_rec_5.RecordState = State.Modified;
                objConstants_mstr_rec_5.Submit();
            } catch (Exception e)
            {
                // go to err-iconst-mstr.;
                await err_iconst_mstr();
                return; 
            }

            //     close tp-pat-mstr;
            // 	  seq-pat-ikey-file;
            // 	  new-pat-file;
            // 	  pat-mstr;
            // 	  pat-elig-history;

            //           corrected-pat;

            // 	  iconst-mstr;
            // 	  audit-file-a;
            // 	  audit-file-b;
            //           audit-file-c.;

            //     display scr-closing-screen.;
            Display("scr-closing-screen.");
        }

	 private async Task az0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task az1_totals()
	 {

            //     add 1			 	to ctr-page-b.;
            ctr_page_b++;

             h3_page_no = ctr_page_b;
            //   write rpt-rec-b from h3-head after advancing page.;
            objRpt_rec_b.Rpt_rec_b1 = "ru703b".PadRight(40) +
                                      "Diskette Submittal - Patient Upload AUDIT Report".PadRight(53) +
                                      "RUN DATE :".PadRight(11) +
                                      Util.Str(h3_run_date).PadRight(10) +
                                      new string(' ', 5) +
                                      "  PAGE".PadRight(7) +
                                      Util.ImpliedIntegerFormat("#0", h3_page_no, 3, false);
            objAudit_File_b.PageBreak();
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //  move "NUMBER OF PATIENTS ON TAPE = " to l4-title.;
            l4_title = "NUMBER OF PATIENTS ON TAPE = ";

            l4_ctr = ctr_tp_pat_mstr_reads;
            //   write rpt-rec-b			from l4-line after advancing 3 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objRpt_rec_b.Rpt_rec_b1 = l4_line_grp;
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            // move "NUMBER OF PATS OUTPUT W/ I-KEYS= " to l4-title. 
            l4_title = "NUMBER OF PATS OUTPUT W/ I-KEYS= ";

            l4_ctr = ctr_seq_pat_file_writes;
            //     write rpt-rec-b			from l4-line after advancing 3 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            //  move "NUMBER OF NEW PATS FOR REPORT" 					to l4-title.;
            l4_title = "NUMBER OF NEW PATS FOR REPORT";

            l4_ctr = ctr_new_pat_file_writes;
            //     write rpt-rec-b			from l4-line after advancing 3 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            // move "NUMBER OF PATIENTS ADDED F010= " 					to l4-title.;
            l4_title = "NUMBER OF PATIENTS ADDED F010= ";

            l4_ctr = ctr_pat_mstr_writes;

            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);            
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            // move "NUMBER OF PATIENTS EXIST F010= " 					to l4-title.;
            l4_title = "NUMBER OF PATIENTS EXIST F010= ";

            l4_ctr = ctr_pat_mstr_exists;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            // move "NUMBER OF WARNINGS PRINTED = " 					to l4-title.;
            l4_title = "NUMBER OF WARNINGS PRINTED = ";

            l4_ctr = ctr_warnings_rpt_writes;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            //  move "NUMBER OF REJECTED RECORDS = " 					to l4-title.;
            l4_title = "NUMBER OF REJECTED RECORDS = ";

            l4_ctr = ctr_error_rpt_writes;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;

            // move "NUMBER OF PAT UPDATED RECORDS = " 					to l4-title.;
            l4_title = "NUMBER OF PAT UPDATED RECORDS = ";
            l4_ctr = ctr_update;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            l4_line_grp = Util.Str(l4_title).PadRight(45) + Util.ImpliedIntegerFormat("#0", l4_ctr, 4, false) + new string(' ', 83);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            l4_line_grp = "";
            l4_title = "";
            l4_ctr = 0;
        }

	 private async Task az1_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ba0_preliminary_edit_patient()
	 {

		 edit_flag = "Y";

            //  if  (tp-pat-id-no   = spaces)  and (tp-pat-ohip-health-no = spaces or tp-pat-ohip-health-no = zeroes) then 
            if ((string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_id_no))  &&  (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_ohip_health_no)  || Util.NumInt(objTp_pat_mstr_rec.Tp_pat_ohip_health_no) == 0  )) {
                edit_flag = "N";
                err_ind = 2;
                // 	go to ba0-99-exit.;
               await  ba0_99_exit();
                return; 
            }

            //  if tp-pat-last-name = spaces  then
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_last_name)) {
                     edit_flag = "N";
                     err_ind = 3;
                //     go to ba0-99-exit;
                await ba0_99_exit();
                return; 
            }
            else {
                ws_last_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_last_name);
            }

            // if tp-pat-first-name = spaces then 
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_first_name)) {
                   edit_flag = "N";
                   err_ind = 5;
                //       go to ba0-99-exit;
                await ba0_99_exit();
                return; 
            }
            else {
                   ws_first_name_grp = Util.Str(objTp_pat_mstr_rec.Tp_pat_first_name);
                ws_first_name_1 = Util.Str(ws_first_name_grp).PadRight(12).Substring(0, 1);
                ws_first_name_11 = Util.Str(ws_first_name_grp).PadRight(12).Substring(1, 11);
            }

            // if tp-pat-ohip-health-no = spaces then 
            if ( string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_ohip_health_no)) {
                // 	   next sentence;
            }
            // else if tp-pat-health-no is not numeric   and (tp-pat-prov = 'ON' or 'ONT')  and  (tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9) then            
            else if ( !Util.IsNumeric(objTp_pat_mstr_rec.Tp_pat_health_no) && (Util.Str(objTp_pat_mstr_rec.Tp_pat_prov).ToUpper() == "ON" || Util.Str(objTp_pat_mstr_rec.Tp_pat_prov).ToUpper() == "ONT") &&
                    (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 6 && Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 9)    ) {
                     edit_flag = "N";
                     err_ind = 29;
                //    go to ba0-99-exit.;
                await ba0_99_exit();
                return; 
            }
	 }

	 private async Task ba0_edit_birth_date_version_cd()
	 {

            // if tp-pat-birth-yy is not numeric then 
            if (!Util.IsNumeric(objTp_pat_mstr_rec.Tp_pat_birth_yy.ToString())) {
                    edit_flag = "N";
                    err_ind = 7;
                // 	  go to ba0-99-exit.;
                await ba0_99_exit();
                return; 
            }

            // if tp-pat-birth-mm is not numeric then
            if (!Util.IsNumeric(objTp_pat_mstr_rec.Tp_pat_birth_mm.ToString()) ) {
                     edit_flag = "N";
                     err_ind = 8;
                // 	   go to ba0-99-exit;
                await ba0_99_exit();
                return; 
            }
            // else if tp-pat-birth-mm < 1 or > 12  then
            else if (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) < 1 || Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) > 12 ) {
                     edit_flag = "N";
                     err_ind = 9;
                //      go to ba0-99-exit.;
                await ba0_99_exit();
                return; 
            }

            //  if tp-pat-birth-dd is not numeric then 
            if (!Util.IsNumeric(objTp_pat_mstr_rec.Tp_pat_birth_dd.ToString()) ) {
                     edit_flag = "N";
                     err_ind = 10;
                //   go to ba0-99-exit;
                await ba0_99_exit();
                return; 
            }
            //  else if tp-pat-birth-dd  < 1  or > 31 then            
            else if (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd) < 1 || Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd) > 31 ) {
                     edit_flag = "N";
                     err_ind = 11;
                //     go to ba0-99-exit.;
                await ba0_99_exit();
                return; 
            }

            //  if tp-pat-birth-mm = 2 then
            if (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) == 2 ) {
                //   	if tp-pat-birth-dd > 29 then            
                if (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd) > 29 ) {
                            edit_flag = "N";
                            err_ind = 12;
                    //      go to ba0-99-exit.;
                    await ba0_99_exit();
                    return; 
                }
            }

            //  if tp-pat-birth-mm =   4 or 6 or 9 or 11 then  
            if (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) == 4 || Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) == 6 || Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) == 9 || 
                  Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm) == 11) {
                //   	if tp-pat-birth-dd > 30 then            
                if (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd) > 30 ) {
                            edit_flag = "N";
                            err_ind = 13;
                    //      go to ba0-99-exit.;
                    await ba0_99_exit();
                    return; 
                }
            }

            objTp_pat_mstr_rec.Tp_pat_version_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd_1) + Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd_2);

            hold_version_cd_grp = objTp_pat_mstr_rec.Tp_pat_version_cd;

            hold_version_cd_1 = Util.Str(hold_version_cd_grp).PadRight(2).Substring(0, 1);
            hold_version_cd_2 = Util.Str(hold_version_cd_grp).PadRight(2).Substring(1, 1);

            //  if   hold-version-cd-1 numeric or hold-version-cd-2 numeric    then; 
            if ( Util.IsNumeric(hold_version_cd_1) || Util.IsNumeric(hold_version_cd_2)) {
                     edit_flag = "N";
                     err_ind = 60;
            }
            //  else if tp-pat-version-cd not = spaces then            
            else if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_version_cd)) {
                //      perform dd0-check-version-cd     thru dd0-99-exit.;
                await dd0_check_version_cd();
                await dd0_99_exit();
            }
        }

        private async Task ba0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task bb0_search_space_trailing()
	 {

            //  if ws-detail-byte(sub) = spaces then 
            if (string.IsNullOrWhiteSpace(ws_detail_byte[sub])) {
                // 	   add 1 				to space-ctr.;
                space_ctr++;
            }
        }

        private async Task bb0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task bc0_search_province()
	 {

            // if tp-pat-prov = old-prov(sub) then
            if (objTp_pat_mstr_rec.Tp_pat_prov == old_prov[sub] ) {
                ws_prov = Util.Str(objTp_pat_mstr_rec.Tp_pat_prov);
                ws_prov_cd = new_prov[sub];
                province_flag = "Y";
            }
	 }

	 private async Task bc0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task bd0_search_new_province()
	 {

            // if tp-pat-prov = new-prov(sub) then 
            if (objTp_pat_mstr_rec.Tp_pat_prov == new_prov[sub] ) {
                ws_prov = Util.Str(objTp_pat_mstr_rec.Tp_pat_prov);
                ws_prov_cd = objTp_pat_mstr_rec.Tp_pat_prov;

                province_flag = "Y";
            }
	 }

	 private async Task bd0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task be0_secondary_edit_patient()
	 {

		 edit_flag = "Y";

            // if tp-pat-sex = "M" or "F" then 
            if (Util.Str(objTp_pat_mstr_rec.Tp_pat_sex).ToUpper() == "M" || Util.Str(objTp_pat_mstr_rec.Tp_pat_sex).ToUpper() == "F"  ) {
                //  	next sentence;
            }
            else {
                edit_flag = "N";
                err_ind = 14;
                //  go to be0-99-exit.;
                await be0_99_exit();
                return; 
            }

            // if tp-pat-street-addr = spaces then
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_street_addr)) {
                     edit_flag = "N";
                     err_ind = 21;
                //   go to be0-99-exit;
                await be0_99_exit();
                return; 
            }
            else {
                 ws_street_addr_grp = "";
                 ws_street_addr_grp = Util.Str(objTp_pat_mstr_rec.Tp_pat_street_addr);
                ws_street_addr1 = Util.Str(ws_street_addr_grp).PadRight(28).Substring(0, 21);
                ws_street_addr2 = Util.Str(ws_street_addr_grp).PadRight(28).Substring(21, 7);
            }

		 ws_city_prov_grp = "";
            ws_city = "";
            ws_prov = "";

		 ws_prov_cd = "";

            //  if tp-pat-city = spaces  then 
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_city)) {
                edit_flag = "N";
                err_ind = 22;
            }
            else {
                   ws_city = Util.Str(objTp_pat_mstr_rec.Tp_pat_city);
            }

            // if tp-pat-prov = spaces then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_prov))
            {
                err_ind = 24;
            }
            else
            {
                province_flag = "N";
                ws_prov_cd = "";
                ws_prov = "";

                //        perform bc0-search-province 	thru bc0-99-exit;
                // 		varying sub from 1 by 1;
                // 		until (province-found or sub > 14);

                sub = 1;
                do
                {
                    await bc0_search_province();
                    await bc0_99_exit();
                    sub++;
                } while (!province_flag.Equals(province_found) && sub <= 14);


                // 	  if province-not-found then  
                if (province_flag.Equals(province_not_found))
                {
                    // 	      perform bd0-search-new-province thru bd0-99-exit;
                    // 		    varying sub from 1 by 1;
                    // 		    until (province-found or sub > 14);

                    sub = 1;
                    do
                    {
                        await bd0_search_new_province();
                        await bd0_99_exit();
                        sub++;
                    } while (!province_flag.Equals(province_found) && sub <= 14);

                    // 	      if province-not-found then  
                    if (province_flag.Equals(province_not_found) ) {
                                   err_ind = 25;
                    }
                    else {
                        // 	    	next sentence.;
                    }
                }
            }

            //  if tp-pat-subscr-surname = spaces  then 
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_subscr_surname)) {
                   ws_subscr_surname = Util.Str(objTp_pat_mstr_rec.Tp_pat_last_name);
            }
            else {
                  ws_subscr_surname = Util.Str(objTp_pat_mstr_rec.Tp_pat_subscr_surname);
            }

            // if tp-pat-subscr-initials = spaces then 
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_subscr_initials)) {
                 objTp_pat_mstr_rec.Tp_pat_subscr_initials = ws_first_name_1;
            }
        }

        private async Task be0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ca0_add_mode_processing()
	 {

            // if tp-pat-prov = 'ON' or 'ONT' and (tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9)  then
            if (Util.Str(objTp_pat_mstr_rec.Tp_pat_prov).ToUpper() == "ON" || Util.Str(objTp_pat_mstr_rec.Tp_pat_prov).ToUpper() == "ONT" && (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 6 && Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 9  )  ) {
                //      move tp-pat-ohip-health-no              to pat-health-nbr of pat-mstr
                pat_health_nbr = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);
                //     	perform yb0-3-read-hc-pat-mstr    	thru yb0-3-99-exit;
                await yb0_3_read_hc_pat_mstr();
                await yb0_3_99_exit();
            }
            else {
                //      move tp-pat-ohip-health-no              to pat-ohip-mmyy of pat-mstr
                pat_ohip_mmyy_grp = Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);
                //     	perform yb0-5-read-od-pat-mstr    	thru yb0-5-99-exit.;
                await yb0_5_read_od_pat_mstr();
                await yb0_5_99_exit();
            }

            // if  pat-exist then
            if (pat_flag.Equals(pat_exist) ) {
                // 	   perform yd0-build-seq-pat-rec		thru yd0-99-exit;
                await yd0_build_seq_pat_rec();
                await yd0_99_exit();

                // 	   perform ye0-write-seq-pat-rec		thru ye0-99-exit;
                await ye0_write_seq_pat_rec();
                await ye0_99_exit();

                // 	   add 1					to ctr-pat-mstr-exists;
                ctr_pat_mstr_exists++;
                // 	   perform yg0-check-update-pat		thru yg0-99-exit;
                await yg0_check_update_pat();
                await yg0_80();
                await yg0_99_exit();

                // 	   go to ca0-99-exit.;
                await ca0_99_exit();
                return; 
            }

            //  perform cc0-determine-if-acron-exist	thru cc0-99-exit.;
            await cc0_determine_if_acron_exist();
            await cc0_10_check_acron();
            await cc0_99_exit();

            // if  pat-not-exist then 
            if (pat_flag.Equals(pat_not_exist) ) {
                // 	   perform be0-secondary-edit-patient	thru be0-99-exit;
                await be0_secondary_edit_patient();
                await be0_99_exit();

                //     if invalid-record then  
                if (edit_flag.Equals(invalid_record) ) {
                    // 	      perform xa0-write-tp-error-report  thru xa0-99-exit;
                    await xa0_write_tp_error_report();
                    await xa0_99_exit();
                }
                else {
                    // 	      perform cb0-add-pat	        thru cb0-99-exit.;
                    await cb0_add_pat();
                    await cb0_99_exit();
                }
            }
        }

        private async Task ca0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task cb0_add_pat()
	 {

            //     perform ga0-build-patient	  		thru ga0-99-exit.;
            await ga0_build_patient();
            await ga0_99_exit();
            //     perform yb1-write-patient   		thru yb1-99-exit.;
            await yb1_write_patient();
            await yb1_99_exit();

            //     perform yd0-build-seq-pat-rec		thru yd0-99-exit.;
            await yd0_build_seq_pat_rec();
            await yd0_99_exit();

            //     perform ye0-write-seq-pat-rec		thru ye0-99-exit.;
            await ye0_write_seq_pat_rec();
            await ye0_99_exit();

            //     perform gf0-build-new-patient  		thru gf0-99-exit.;
            await gf0_build_new_patient();
            await gf0_99_exit();

            //     perform yf0-write-new-patient   		thru yf0-99-exit.;
            await yf0_write_new_patient();
            await yf0_99_exit();

            err_ind = 55;
            //     perform xd0-write-audit-report		thru xd0-99-exit.;
           await xd0_write_audit_report();
            await xd0_99_exit();
     }

	 private async Task cb0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task cc0_determine_if_acron_exist()
	 {

            hold_last_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_last_name);
            hold_first_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_first_name);

            //objPat_mstr_rec.pat_acronym = hold_acronym;

            hold_acronym_grp = Util.Str(hold_last_name) + Util.Str(hold_first_name);

            pat_acronym_grp = hold_acronym_grp;

            pat_acronym_first6 = Util.Str(pat_acronym_grp).PadRight(9).Substring(0, 6);
            pat_acronym_last3 = Util.Str(pat_acronym_grp).PadRight(9).Substring(6, 3);

            //     perform yb0-read-acr-pat-mstr		thru yb0-99-exit.;
            await yb0_read_acr_pat_mstr();
            await yb0_99_exit();

            //  if pat-not-exist then 
            if (pat_flag.Equals(pat_not_exist) ) {
                // 	   go to cc0-99-exit.;
                await cc0_99_exit();
                return; 
            }

           pat_flag = "Y";
	 }

	 private async Task cc0_10_check_acron()
	 {

            // if  (tp-pat-ohip-health-no   = pat-health-nbr of pat-mstr) or (tp-pat-ohip-health-no   = pat-ohip-mmyy  of pat-mstr)  then 
            if ((Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no) == Util.Str(pat_health_nbr)) || (Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no) == Util.Str(pat_ohip_mmyy_grp))) {
                     err_ind = 41;
                // 	   perform xa0-write-tp-error-report	thru xa0-99-exit;
                await xa0_write_tp_error_report();
                await xa0_99_exit();
            }
            else {
                // 	   perform yb0-10-read-next-pat-mstr	thru yb0-10-99-exit;
                await yb0_10_read_next_pat_mstr();
                await yb0_10_99_exit();

                // 	   if pat-not-exist then
                if (pat_flag.Equals(pat_not_exist) ) {
                    // 	      go to cc0-99-exit;
                    await cc0_99_exit();
                    return; 
                }
                //	   else  if pat-exist then; 
                else if (pat_flag.Equals(pat_exist) ) {
                    // 	   	  go to cc0-10-check-acron.;
                    await cc0_10_check_acron();
                    return; 
                }
            }
        }

        private async Task cc0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task dd0_check_version_cd()
	 {

            //   if hold-version-cd-1 = ' ' then 
            if (string.IsNullOrWhiteSpace(hold_version_cd_1)) {
                //        next sentence                 
            }
            //   else if hold-version-cd-1 = 'a' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("a")) {
                //        move 'A' to hold-version-cd-1 
                hold_version_cd_1 = "A";
            }
            //   else if hold-version-cd-1 = 'b' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("b")) {
                //        move 'B' to hold-version-cd-1 
                hold_version_cd_1 = "B";
            }
            //   else if hold-version-cd-1 = 'c' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("c"))
            {
                //        move 'C' to hold-version-cd-1 
                hold_version_cd_1 = "C";
            }
            //   else if hold-version-cd-1 = 'd' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("d"))
            {
                //        move 'D' to hold-version-cd-1 
                hold_version_cd_1 = "D";
            }
            //   else if hold-version-cd-1 = 'e' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("e"))
            {
                //         move 'E' to hold-version-cd-1 
                hold_version_cd_1 = "E";
            }
            //   else if hold-version-cd-1 = 'f' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("f"))
            {
                //         move 'F' to hold-version-cd-1 
                hold_version_cd_1 = "F";
            }
            //   else if hold-version-cd-1 = 'g' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("g"))
            {
                //        move 'G' to hold-version-cd-1 
                hold_version_cd_1 = "G";
            }
            //   else if hold-version-cd-1 = 'h' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("h"))
            {
                //        move 'H' to hold-version-cd-1 
                hold_version_cd_1 = "H";
            }
            //   else  if hold-version-cd-1 = 'i' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("i"))
            {
                //        move 'I' to hold-version-cd-1 
                hold_version_cd_1 = "I";
            }
            //   else if hold-version-cd-1 = 'j' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("j"))
            {
                //        move 'J' to hold-version-cd-1 
                hold_version_cd_1 = "J";
            }
            //   else if hold-version-cd-1 = 'k' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("k"))
            {
                //       move 'K' to hold-version-cd-1 
                hold_version_cd_1 = "K";
            }
            //   else if hold-version-cd-1 = 'l' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("l"))
            {
                //       move 'L' to hold-version-cd-1 
                hold_version_cd_1 = "L";
            }
            //   else if hold-version-cd-1 = 'm' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("m"))
            {
                //       move 'M' to hold-version-cd-1 
                hold_version_cd_1 = "M";
            }
            //   else if hold-version-cd-1 = 'n' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("n"))
            {
                //       move 'N' to hold-version-cd-1 
                hold_version_cd_1 = "N";
            }
            //   else if hold-version-cd-1 = 'o' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("o"))
            {
                //       move 'O' to hold-version-cd-1 
                hold_version_cd_1 = "O";
            }
            //   else if hold-version-cd-1 = 'p' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("p"))
            {
                //        move 'P' to hold-version-cd-1 
                hold_version_cd_1 = "P";
            }
            //   else if hold-version-cd-1 = 'q' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("q"))
            {
                //        move 'Q' to hold-version-cd-1 
                hold_version_cd_1 = "Q";
            }
            //   else if hold-version-cd-1 = 'r' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("r"))
            {
                //        move 'R' to hold-version-cd-1 
                hold_version_cd_1 = "R";
            }
            //   else if hold-version-cd-1 = 's' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("s"))
            {
                //        move 'S' to hold-version-cd-1 
                hold_version_cd_1 = "S";
            }
            //   else if hold-version-cd-1 = 't' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("t"))
            {
                //        move 'T' to hold-version-cd-1 
                hold_version_cd_1 = "T";
            }
            //   else if hold-version-cd-1 = 'u' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("u"))
            {
                //        move 'U' to hold-version-cd-1 
                hold_version_cd_1 = "U";
            }
            //   else if hold-version-cd-1 = 'v' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("v"))
            {
                //        move 'V' to hold-version-cd-1 
                hold_version_cd_1 = "V";
            }
            //   else if hold-version-cd-1 = 'w' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("w"))
            {
                //        move 'W' to hold-version-cd-1 
                hold_version_cd_1 = "W";
            }
            //   else if hold-version-cd-1 = 'x' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("x"))
            {
                //       move 'X' to hold-version-cd-1 
                hold_version_cd_1 = "X";
            }
            //   else if hold-version-cd-1 = 'y' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("y"))
            {
                //       move 'Y' to hold-version-cd-1 
                hold_version_cd_1 = "Y";
            }
            //   else if hold-version-cd-1 = 'z' then 
            else if (Util.Str(hold_version_cd_1).ToLower().Equals("z"))
            {
                //        move 'Z' to hold-version-cd-1.;
                hold_version_cd_1 = "Z";
            }

            //   if hold-version-cd-2 = ' ' then 
            if (string.IsNullOrWhiteSpace(hold_version_cd_2))
            {
                //         next sentence                 
            }
            //   else if hold-version-cd-2 = 'a' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("a"))
            {
                //        move 'A' to hold-version-cd-2 
                hold_version_cd_2 = "A";
            }
            //   else if hold-version-cd-2 = 'b' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("b"))
            {
                //        move 'B' to hold-version-cd-2 
                hold_version_cd_2 = "B";
            }
            //   else if hold-version-cd-2 = 'c' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("c"))
            {
                //        move 'C' to hold-version-cd-2 
                hold_version_cd_2 = "C";
            }
            //   else if hold-version-cd-2 = 'd' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("d"))
            {
                //         move 'D' to hold-version-cd-2 
                hold_version_cd_2 = "D";
            }
            //   else if hold-version-cd-2 = 'e' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("e"))
            {
                //         move 'E' to hold-version-cd-2 
                hold_version_cd_2 = "E";
            }
            //   else if hold-version-cd-2 = 'f' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("f"))
            {
                //        move 'F' to hold-version-cd-2 
                hold_version_cd_2 = "F";
            }
            //   else if hold-version-cd-2 = 'g' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("g"))
            {
                //         move 'G' to hold-version-cd-2 
                hold_version_cd_2 = "G";
            }
            //   else if hold-version-cd-2 = 'h' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("h"))
            {
                //        move 'H' to hold-version-cd-2 
                hold_version_cd_2 = "H";
            }
            //   else if hold-version-cd-2 = 'i' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("i"))
            {
                //        move 'I' to hold-version-cd-2 
                hold_version_cd_2 = "I";
            }
            //   else if hold-version-cd-2 = 'j' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("j"))
            {
                //        move 'J' to hold-version-cd-2 
                hold_version_cd_2 = "J";
            }
            //   else if hold-version-cd-2 = 'k' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("k"))
            {
                //        move 'K' to hold-version-cd-2 
                hold_version_cd_2 = "K";
            }
            //   else if hold-version-cd-2 = 'l' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("l"))
            {
                //        move 'L' to hold-version-cd-2 
                hold_version_cd_2 = "L";
            }
            //   else if hold-version-cd-2 = 'm' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("m"))
            {
                //        move 'M' to hold-version-cd-2 
                hold_version_cd_2 = "M";
            }
            //   else if hold-version-cd-2 = 'n' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("n"))
            {
                //        move 'N' to hold-version-cd-2 
                hold_version_cd_2 = "N";
            }
            //   else if hold-version-cd-2 = 'o' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("o"))
            {
                //        move 'O' to hold-version-cd-2 
                hold_version_cd_2 = "O";
            }
            //   else if hold-version-cd-2 = 'p' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("p"))
            {
                //        move 'P' to hold-version-cd-2 
                hold_version_cd_2 = "P";
            }
            //   else if hold-version-cd-2 = 'q' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("q"))
            {
                //        move 'Q' to hold-version-cd-2 
                hold_version_cd_2 = "Q";
            }
            //   else if hold-version-cd-2 = 'r' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("r"))
            {
                //        move 'R' to hold-version-cd-2 
                hold_version_cd_2 = "R";
            }
            //   else if hold-version-cd-2 = 's' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("s"))
            {
                //        move 'S' to hold-version-cd-2 
                hold_version_cd_2 = "S";
            }
            //   else if hold-version-cd-2 = 't' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("t"))
            {
                //        move 'T' to hold-version-cd-2 
                hold_version_cd_2 = "T";
            }
            //   else if hold-version-cd-2 = 'u' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("u"))
            {
                //        move 'U' to hold-version-cd-2 
                hold_version_cd_2 = "U";
            }
            //   else if hold-version-cd-2 = 'v' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("v"))
            {
                //        move 'V' to hold-version-cd-2 
                hold_version_cd_2 = "V";
            }
            //   else  if hold-version-cd-2 = 'w' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("w"))
            {
                //        move 'W' to hold-version-cd-2 
                hold_version_cd_2 = "W";
            }
            //   else if hold-version-cd-2 = 'x' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("x"))
            {
                //        move 'X' to hold-version-cd-2 
                hold_version_cd_2 = "X";
            }
            //   else if hold-version-cd-2 = 'y' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("y"))
            {
                //        move 'Y' to hold-version-cd-2 
                hold_version_cd_2 = "Y";
            }
            //   else if hold-version-cd-2 = 'z' then 
            else if (Util.Str(hold_version_cd_2).ToLower().Equals("z"))
            {
                //         move 'Z' to hold-version-cd-2.;
                hold_version_cd_2 = "Z";
            }            

            hold_version_cd_grp = Util.Str(hold_version_cd_1) + Util.Str(hold_version_cd_2);

            objTp_pat_mstr_rec.Tp_pat_version_cd = hold_version_cd_grp;

            objTp_pat_mstr_rec.Tp_pat_version_cd_1 = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd).PadRight(2).Substring(0, 1);
            objTp_pat_mstr_rec.Tp_pat_version_cd_2 = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd).PadRight(2).Substring(1, 1);

            //   if   hold-version-cd = spaces;
            if ( string.IsNullOrWhiteSpace(hold_version_cd_grp)
            //         or  (     hold-version-cd-2 = spaces;
                || ( string.IsNullOrWhiteSpace(hold_version_cd_2)
            //              and (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z');
                && ( Util.Str(hold_version_cd_1).ToUpper().CompareTo("A") >= 0 &&  Util.Str(hold_version_cd_1).ToUpper().CompareTo("Z") <= 0
            //             );
                           )
            //         or  (    (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z');
                ||  (Util.Str(hold_version_cd_1).ToUpper().CompareTo("A") >= 0  &&  Util.Str(hold_version_cd_1).ToUpper().CompareTo("Z") <= 0  )
            //              and (hold-version-cd-2 >= 'A' and hold-version-cd-2 <= 'Z');
                 && (Util.Str(hold_version_cd_2).ToUpper().CompareTo("A") >= 0  &&  Util.Str(hold_version_cd_2).ToUpper().CompareTo("Z") <= 0 )
            //             );
            )
            //   then;
            )
            {
                //         next sentence;
            }
            else {
                       edit_flag = "N";
                       err_ind = 28;
            }
        }

	 private async Task dd0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ga0_build_patient()
	 {

            //ws_pat_mstr_rec = "";
            await Initialize_ws_pat_mstr_Rec();

            ws_pat_surname = ws_last_name;
		 ws_pat_acronym_first6 = ws_last_name;

            ws_first_name_grp = Util.Str(ws_first_name_1) + Util.Str(ws_first_name_11);
         ws_pat_given_name = ws_first_name_grp;
		 ws_pat_init1 = ws_first_name_grp;
		 ws_pat_acronym_last3 = ws_first_name_grp;
		 
		 ws_pat_birth_date_yy = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_yy);

		 ws_pat_birth_date_mm = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm);

		 ws_pat_birth_date_dd = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd);

		 ws_pat_sex = Util.Str(objTp_pat_mstr_rec.Tp_pat_sex);

         ws_pat_phone_nbr_grp = Util.Str(objTp_pat_mstr_rec.Tp_pat_phone_no);

            ws_pat_phone_nbr_first3 = Util.NumInt(Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(0, 3));
            ws_pat_phone_nbr_last4 = Util.NumInt(Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(3, 4));
            ws_pat_phone_nbr_remainder = Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(7, 13);

            ws_pat_in_out = "O";

		 ws_pat_date_last_maint = Util.NumInt(sys_date_long);

		 ws_pat_nbr_outstanding_claims = 0;

		 ws_pat_i_key = hold_pat_i_key;
		 ws_pat_con_nbr = hold_iconst_con_nbr;
		 ws_pat_i_nbr = hold_iconst_nx_ikey;

            // if ws-prov-cd = 'ON' and (tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9) then
            if (ws_prov_cd == "ON" && (Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 6 && Util.NumInt(objTp_pat_mstr_rec.Tp_pat_agent_cd) != 9 ) ) {
                   ws_pat_health_nbr = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);
            }
            else {
                     ws_pat_ohip_mmyy_grp = objTp_pat_mstr_rec.Tp_pat_ohip_health_no;

                     ws_pat_ohip_out_prov_grp = ws_pat_ohip_mmyy_grp;
                     ws_pat_ohip_nbr = Util.NumInt(ws_pat_ohip_out_prov_grp);
                     ws_pat_ohip_nbr_r_alpha = Util.Str(ws_pat_ohip_nbr);
                     ws_pat_ohip_nbr_MB_def_grp = Util.Str(ws_pat_ohip_nbr_r_alpha).PadRight(8);
                     ws_pat_ohip_nbr_MB = Util.NumInt(Util.Str(ws_pat_ohip_nbr_MB_def_grp).Substring(0, 6));
                     ws_pat_ohip_nbr_NT_def_grp = Util.Str(ws_pat_ohip_nbr);
                     ws_pat_ohip_nbr_NT_1_char = Util.Str(ws_pat_ohip_nbr_NT_def_grp).PadRight(8).Substring(0, 1);
                     ws_pat_ohip_nbr_NT = Util.NumInt(Util.Str(ws_pat_ohip_nbr_NT_def_grp).PadRight(8).Substring(1, 7));

                     ws_pat_mm = Util.NumInt(Util.Str(ws_pat_ohip_mmyy_grp).PadRight(12).Substring(7, 2));
                     ws_pat_yy = Util.NumInt(Util.Str(ws_pat_ohip_mmyy_grp).PadRight(12).Substring(9, 2));

                ws_pat_health_nbr = 0;
            }

		 ws_pat_health_65_ind = "N";
		 ws_pat_expiry_date_grp = "0000";
         ws_pat_expiry_yy = 0;
            ws_pat_expiry_mm = 0;

         ws_pat_version_cd = objTp_pat_mstr_rec.Tp_pat_version_cd;            

		 ws_subscr_addr1 = objTp_pat_mstr_rec.Tp_pat_street_addr;
		 ws_subscr_addr3 = objTp_pat_mstr_rec.Tp_pat_city;
		 ws_pat_prov_cd = ws_prov_cd;
		 ws_subscr_prov_cd = ws_prov_cd;

		 ws_subscr_postal_cd = objTp_pat_mstr_rec.Tp_pat_postal_code;
		 ws_subscr_auto_update = "Y";
		 ws_subscr_msg_nbr = "00";
	 }

	 private async Task ga0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ge0_increment_nx_avail_pat()
	 {
            try
            {
                // add 1				to hold-iconst-nx-ikey;
                hold_iconst_nx_ikey++;
            }
            catch (Exception e)
            {
                // 	on size error;
                hold_iconst_nx_ikey = 1;
            }

            try
            {
                // 		add 1			to hold-iconst-con-nbr;
                hold_iconst_con_nbr++;
            }
            catch (Exception e)
            {
                // 		    on size error;
                hold_iconst_con_nbr = 25;
            }
	 }

	 private async Task ge0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task gf0_build_new_patient()
	 {

		 objNew_pat_file_rec.New_pat_ohip = objTp_pat_mstr_rec.Tp_pat_ohip_health_no;
		 objNew_pat_file_rec.New_pat_surname = ws_last_name;

         ws_first_name_grp = Util.Str(ws_first_name_1) + Util.Str(ws_first_name_11);
         objNew_pat_file_rec.New_pat_first_name = ws_first_name_grp;
		 objNew_pat_file_rec.New_pat_subscr_surname = ws_subscr_surname;
		 objNew_pat_file_rec.New_pat_address_line_1 = objTp_pat_mstr_rec.Tp_pat_street_addr;
		 objNew_pat_file_rec.New_pat_address_line_2 = ws_city;
		 objNew_pat_file_rec.New_pat_address_line_3 = ws_prov;
		 objNew_pat_file_rec.New_pat_postal_code = objTp_pat_mstr_rec.Tp_pat_postal_code;
		 objNew_pat_file_rec.New_pat_birth_date = objTp_pat_mstr_rec.Tp_pat_birth_date;
		 objNew_pat_file_rec.New_pat_sex = objTp_pat_mstr_rec.Tp_pat_sex;
	 }

	 private async Task gf0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task xa0_write_tp_error_report()
	 {

		 l1_line_grp = "";
            l1_func_cd = "";
            l1_last_name = "";
            l1_first_name = "";
            l1_date_grp = "";
            l1_yy = 0;
            l1_mm = 0;
            l1_dd = 0;
            l1_sex = "";
            l1_id_no = "";
            l1_health_no = "";
            l1_subscr_name = "";
            l1_subscr_init = "";


         l2_version_cd = "";
		 l2_street_addr = "";
		 l2_city = "";
		 l2_prov = "";
		 l2_postal_cd = "";
		 l2_phone_no = "";
		 l2_mess_id = "";
		 
		 l1_func_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_func_code);
		 l1_last_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_last_name);
		 l1_first_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_first_name);

		 l1_yy = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_yy);
		 l1_mm = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm);
		 l1_dd = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd);
		 l1_slash1 = "/";
		 l1_slash2 = "/";
		 
		 l1_sex = Util.Str(objTp_pat_mstr_rec.Tp_pat_sex);
         l1_id_no = Util.Str(objTp_pat_mstr_rec.Tp_pat_id_no);
         l1_health_no = Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);
         l2_version_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd);
         l1_subscr_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_subscr_surname);
         l1_subscr_init = Util.Str(objTp_pat_mstr_rec.Tp_pat_subscr_initials);
         l2_street_addr = Util.Str(objTp_pat_mstr_rec.Tp_pat_street_addr);
         l2_city = Util.Str(objTp_pat_mstr_rec.Tp_pat_city);
         l2_prov = Util.Str(objTp_pat_mstr_rec.Tp_pat_prov);
         l2_postal_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_postal_code);
         l2_phone_no = Util.Str(objTp_pat_mstr_rec.Tp_pat_phone_no);

          l2_mess_id = Util.Str(err_ind);

            //  if ctr-reject > 8 then 
            if (Util.NumInt(ctr_reject) > 8) {
                       ctr_reject = 0;
                //        add 1				 to ctr-page-a;
                ctr_page_a++;
                h1_page_no = ctr_page_a;
                //        write rpt-rec-a from h1-head after advancing page;
                objRpt_rec_a.Rpt_rec_a1 = "ru703a".PadRight(40) +
                                     "Diskette Submittal - Patient Upload ERROR Report".PadRight(53) +
                                     "RUN DATE :".PadRight(11) +
                                     Util.Str(h1_run_date).PadRight(10) +
                                     new string(' ', 5) +
                                     "  PAGE".PadRight(7) +
                                     Util.ImpliedIntegerFormat("#0", h1_page_no, 3, false);
                objAudit_File_a.PageBreak();
                objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

                objRpt_rec_a.Rpt_rec_a1 = "";
                //   write rpt-rec-a after advancing 1 line.;
                objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            }

            //     write rpt-rec-a from h2-head after advancing 2 lines.;
            objRpt_rec_a.Rpt_rec_a1 = "* FUNC CD".PadRight(17) +
                                       "LAST  NAME".PadRight(26) +
                                       "FIRST  NAME".PadRight(18) +
                                       "BIRTH DATE  SEX".PadRight(17) +
                                       "CHART #  HEALTH #".PadRight(24) +
                                       "SUBSCRIBER SURNAME".PadRight(22) +
                                       "INITIALS".PadRight(10);
            objAudit_File_a.print(true);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);


            //     write rpt-rec-a from l1-line after advancing 1 line.;
            objRpt_rec_a.Rpt_rec_a1 = new string(' ', 4) +
                                      Util.Str(l1_func_cd).PadRight(2) +
                                      new string(' ', 4) +
                                      Util.Str(l1_last_name).PadRight(24) +
                                      new string(' ', 2) +
                                      Util.Str(l1_first_name).PadRight(24) +
                                      new string(' ', 1) +
                                      Util.Str(l1_yy).PadLeft(4, '0') +
                                      Util.Str(l1_slash1).PadRight(1) +
                                      Util.Str(l1_mm).PadLeft(2, '0') +
                                      Util.Str(l1_slash2).PadRight(1) +
                                      Util.Str(l1_dd).PadLeft(2, '0') +
                                      new string(' ', 3) +
                                      Util.Str(l1_sex).PadRight(1) +
                                      new string(' ', 1) +
                                      Util.Str(l1_id_no).PadRight(9) +
                                      new string(' ', 2) +
                                      Util.Str(l1_health_no).PadRight(12) +
                                      new string(' ', 2) +
                                      Util.Str(l1_subscr_name).PadRight(24) +
                                      new string(' ', 3) +
                                      Util.Str(l1_subscr_init).PadRight(3) +
                                      new string(' ', 3);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

            //     write rpt-rec-a from l2-line after advancing 3 lines.;
            objRpt_rec_a.Rpt_rec_a1 = "  ADDRESS: ".PadRight(11) +
                                       Util.Str(l2_street_addr).PadRight(28) +
                                       ", ".PadRight(2) +
                                       Util.Str(l2_city).PadRight(18) +
                                       ", ".PadRight(2) +
                                       Util.Str(l2_prov).PadRight(4) +
                                       ", ".PadRight(2) +
                                       Util.Str(l2_postal_cd).PadRight(6) +
                                       " PHONE: ".PadRight(8) +
                                       Util.Str(l2_phone_no).PadRight(20) +
                                       new string(' ', 2) +
                                       "  VERSION: ".PadRight(11) +
                                       Util.Str(l2_version_cd).PadRight(2) +
                                       " MESSAGE ID: ".PadRight(13) +
                                       Util.Str(l2_mess_id).PadRight(2);
            objAudit_File_a.print(true);
            objAudit_File_a.print(true);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

            //  l3_line = "all "-"";   // todo: not sure about this code ...?
            l3_line_grp = new string('-', 132);

            l3_doc_ohip_nbr = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_doctor_nbr);

            l3_doc_accounting_nbr = Util.Str(objTp_pat_mstr_rec.Tp_pat_account_id);

            //     write rpt-rec-a from l3-line after advancing 1 line.;
            objRpt_rec_a.Rpt_rec_a1 = Util.Str(l3_doc_ohip_nbr).PadLeft(6, '0') +
                                      new string('-', 1) +
                                      Util.Str(l3_doc_accounting_nbr).PadRight(8) +
                                      new string('-', 117);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

            //     add 1				  to ctr-reject.;
            ctr_reject++;

            //     add 1				  to ctr-error-rpt-writes.;
            ctr_error_rpt_writes++;
        }

	 private async Task xa0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task xd0_write_audit_report()
	 {

            l1_line_grp = "";
            l1_func_cd = "";
            l1_last_name = "";
            l1_first_name = "";
            l1_date_grp = "";
            l1_yy = 0;
            l1_mm = 0;
            l1_dd = 0;
            l1_sex = "";
            l1_id_no = "";
            l1_health_no = "";
            l1_subscr_name = "";
            l1_subscr_init = "";

            l2_version_cd = "";
		 l2_street_addr = "";
		 l2_city = "";
		 l2_prov = "";
		 l2_postal_cd = "";
		 l2_phone_no = "";
		 l2_mess_id = "";
		 
		 l1_func_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_func_code);
		 l1_last_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_last_name);
		 l1_first_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_first_name);

		 l1_yy = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_yy);
		 l1_mm = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_mm);
		 l1_dd = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_birth_dd);
		 l1_slash1 = "/";
		 l1_slash2 = "/";


            l1_sex = Util.Str(objTp_pat_mstr_rec.Tp_pat_sex);
            l1_id_no = Util.Str(objTp_pat_mstr_rec.Tp_pat_id_no);
            l1_health_no = Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);
            l2_version_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd);
            l1_subscr_name = Util.Str(objTp_pat_mstr_rec.Tp_pat_subscr_surname);
            l1_subscr_init = Util.Str(objTp_pat_mstr_rec.Tp_pat_subscr_initials);
            l2_street_addr = Util.Str(objTp_pat_mstr_rec.Tp_pat_street_addr);
            l2_city = Util.Str(objTp_pat_mstr_rec.Tp_pat_city);
            l2_prov = Util.Str(objTp_pat_mstr_rec.Tp_pat_prov);
            l2_postal_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_postal_code);
            l2_phone_no = Util.Str(objTp_pat_mstr_rec.Tp_pat_phone_no);

            l2_mess_id = Util.Str(err_ind);

            // if ctr-warning > 9 then
            if (ctr_warning > 9 ) {
                    ctr_warning = 0;
                //     add 1				 to ctr-page-b;
                ctr_page_b++;
                     h3_page_no = ctr_page_b;
                //     write rpt-rec-b from h3-head after advancing page;
                objRpt_rec_b.Rpt_rec_b1 = "ru703b".PadRight(40) +
                                     "Diskette Submittal - Patient Upload AUDIT Report".PadRight(53) +
                                     "RUN DATE :".PadRight(11) +
                                     Util.Str(h3_run_date).PadRight(10) +
                                     new string(' ', 5) +
                                     "  PAGE".PadRight(7) +
                                     Util.ImpliedIntegerFormat("#0", h3_page_no, 3, false);
                objAudit_File_b.PageBreak();
                objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

                 objRpt_rec_b.Rpt_rec_b1 = "";
                //      write rpt-rec-b after advancing 1 line.;
                objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            }


            //     write rpt-rec-b from h2-head after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = "* FUNC CD".PadRight(17) +
                                          "LAST  NAME".PadRight(26) +
                                          "FIRST  NAME".PadRight(18) +
                                          "BIRTH DATE  SEX".PadRight(17) +
                                          "CHART #  HEALTH #".PadRight(24) +
                                          "SUBSCRIBER SURNAME".PadRight(22) +
                                          "INITIALS".PadRight(10);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     write rpt-rec-b from l1-line after advancing 1 line.;
            objRpt_rec_b.Rpt_rec_b1  = new string(' ', 4) +
                                     Util.Str(l1_func_cd).PadRight(2) +
                                     new string(' ', 4) +
                                     Util.Str(l1_last_name).PadRight(24) +
                                     new string(' ', 2) +
                                     Util.Str(l1_first_name).PadRight(24) +
                                     new string(' ', 1) +
                                     Util.Str(l1_yy).PadLeft(4, '0') +
                                     Util.Str(l1_slash1).PadRight(1) +
                                     Util.Str(l1_mm).PadLeft(2, '0') +
                                     Util.Str(l1_slash2).PadRight(1) +
                                     Util.Str(l1_dd).PadLeft(2, '0') +
                                     new string(' ', 3) +
                                     Util.Str(l1_sex).PadRight(1) +
                                     new string(' ', 1) +
                                     Util.Str(l1_id_no).PadRight(9) +
                                     new string(' ', 2) +
                                     Util.Str(l1_health_no).PadRight(12) +
                                     new string(' ', 2) +
                                     Util.Str(l1_subscr_name).PadRight(24) +
                                     new string(' ', 3) +
                                     Util.Str(l1_subscr_init).PadRight(3) +
                                     new string(' ', 3);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     write rpt-rec-b from l2-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1  = "  ADDRESS: ".PadRight(11) +
                                       Util.Str(l2_street_addr).PadRight(28) +
                                       ", ".PadRight(2) +
                                       Util.Str(l2_city).PadRight(18) +
                                       ", ".PadRight(2) +
                                       Util.Str(l2_prov).PadRight(4) +
                                       ", ".PadRight(2) +
                                       Util.Str(l2_postal_cd).PadRight(6) +
                                       " PHONE: ".PadRight(8) +
                                       Util.Str(l2_phone_no).PadRight(20) +
                                       new string(' ', 2) +
                                       "  VERSION: ".PadRight(11) +
                                       Util.Str(l2_version_cd).PadRight(2) +
                                       " MESSAGE ID: ".PadRight(13) +
                                       Util.Str(l2_mess_id).PadRight(2);
            
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //l3_line = "all "-"";
            l3_line_grp = new string('-', 132);

            //     write rpt-rec-b from l3-line after advancing 1 line.;
            objRpt_rec_b.Rpt_rec_b1 = l3_line_grp;
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     add 1				  to ctr-warning.;
            ctr_warning++;

            //     add 1				  to ctr-warnings-rpt-writes.;
            ctr_warnings_rpt_writes++;
        }

	 private async Task xd0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task xe0_write_update_exception_rpt()
	 {

            // if ctr-update  > 18  then  
            if (ctr_update > 18) {
                     ctr_update = 0;
                //      add 1				 to ctr-page-c;
                ctr_page_c++;
                h4_page_no = ctr_page_c;
                //      write rpt-rec-c from h4-head after advancing page;
                objRpt_rec_c.Rpt_rec_c1 = "ru703c".PadRight(28) +
                                           "Diskette Submittal - Patient Addition UPDATE EXCEPTIONS Report".PadRight(65) +
                                           "RUN DATE :".PadRight(11) +
                                           Util.Str(h4_run_date).PadRight(10) +
                                           new string(' ', 5) +
                                           "  PAGE".PadRight(7) +
                                           Util.ImpliedIntegerFormat("#0", h4_page_no, 3, false);
                objAudit_File_c.PageBreak();
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

                 objRpt_rec_c.Rpt_rec_c1 = "";

                //        write rpt-rec-c after advancing 1 line;
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

                //        write rpt-rec-c from h5-head after 1 line;
                objRpt_rec_c.Rpt_rec_c1 = new string(' ', 10) +
                                          "HEALTH/ACCT'ING #".PadRight(22) +
                                          "BIRTH DATE".PadRight(20) +
                                          "VERSION CD".PadRight(20) +
                                          new string(' ', 50);
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

                 objRpt_rec_c.Rpt_rec_c1  = "";
                //        write rpt-rec-c after advancing 1 line.;
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);
            }

             prt_lit1 = "RMA";
             prt_lit2 = "Incoming";
             prt_ohip_health_nbr = Util.Str(objTp_pat_mstr_rec.Tp_pat_ohip_health_no);
             disk_doctor_nbr = Util.NumInt(objTp_pat_mstr_rec.Tp_pat_doctor_nbr);
             disk_account_id = Util.Str(objTp_pat_mstr_rec.Tp_pat_account_id);

            //  if  old-version-cd-matches  and old-birth-date-matches then
            if (flag_old_version_cd.Equals(old_version_cd_matches) && flag_old_birth_date.Equals(old_birth_date_matches)) {
                //      move "VERSION CD and BIRTH DATE = RMA's OLD value" to rma-reason-desc
                rma_reason_desc = "VERSION CD and BIRTH DATE = RMA's OLD value";
            }
            //  else if    old-version-cd-matches and birth-date-changed and old-birth-date-doesnt-match then
            else if (flag_old_version_cd.Equals(old_version_cd_matches) &&  flag_birth_date_change.Equals(birth_date_changed) &&  flag_old_birth_date.Equals(old_birth_date_doesnt_match)) {
                //      move "VERSION CD = RMA's OLD value (BIRTH DATE Updated)" to rma-reason-desc
                rma_reason_desc = "VERSION CD = RMA's OLD value (BIRTH DATE Updated)";
            }
            //  else if    old-birth-date-matches and version-cd-changed  and old-version-cd-doesnt-match then
            else if (flag_old_birth_date.Equals(old_birth_date_matches) &&  flag_change_version_cd.Equals(version_cd_changed)  && flag_old_version_cd.Equals(old_version_cd_doesnt_match)) {
                //      move "BIRTH DATE = RMA's OLD value (VERSION CD Updated)" to rma-reason-desc
                rma_reason_desc = "BIRTH DATE = RMA's OLD value (VERSION CD Updated)";
            }
            //  else if    version-cd-changed and old-version-cd-matches then
            else if (flag_change_version_cd.Equals(version_cd_changed) &&   flag_old_version_cd.Equals(old_version_cd_matches)) {
                //      move "VERSION CD = RMA's OLD value"	     to rma-reason-desc
                rma_reason_desc = "VERSION CD = RMA's OLD value";
            }
            //  else  if    birth-date-changed and old-birth-date-matches then
            else if (flag_birth_date_change.Equals(birth_date_changed) &&  flag_old_birth_date.Equals( old_birth_date_matches)) {
                //     move "BIRTH DATE = RMA's OLD value"	     to rma-reason-desc
                rma_reason_desc = "BIRTH DATE = RMA's OLD value";
            }
            else {
                    rma_reason_desc = "UnknownUpdateExceptionerror";
            }

            //     write rpt-rec-c from prt-det-line1 after advancing 2 lines.;
            objRpt_rec_c.Rpt_rec_c1 = Util.Str(prt_lit1).PadRight(10) +
                                      Util.Str(prt_ohip_health_nbr).PadRight(12) +
                                      new string(' ', 9) +
                                      Util.Str(rma_birth_date_yy).PadLeft(4, '0') +
                                      "/" +
                                      Util.Str(rma_birth_date_mm).PadLeft(2, '0') +
                                      "/" +
                                      Util.Str(rma_birth_date_dd).PadLeft(2, '0') +
                                      new string(' ', 9) +
                                      Util.Str(rma_version_cd).PadRight(2) +
                                      new string(' ', 10) +
                                      Util.Str(rma_prov_cd).PadRight(2) +
                                      new string(' ', 10) +
                                      Util.Str(rma_reason_desc).PadRight(60);
            objAudit_File_c.print(true);
            objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

            //     write rpt-rec-c from prt-det-line2 after advancing 1 line.;
            objRpt_rec_c.Rpt_rec_c1 = Util.Str(prt_lit2).PadRight(10) +
                                      Util.Str(disk_doctor_nbr).PadLeft(6, '0') +
                                      Util.Str(disk_account_id).PadRight(8) +
                                      new string(' ', 7) +
                                      Util.Str(disk_birth_date_yy).PadLeft(4, '0') +
                                      "/" +
                                      Util.Str(disk_birth_date_mm).PadLeft(2, '0') +
                                      "/" +
                                      Util.Str(disk_birth_date_dd).PadLeft(2, '0') +
                                      new string(' ', 9) +
                                      Util.Str(disk_version_cd).PadRight(2) +
                                      new string(' ', 10) +
                                      Util.Str(disk_prov_cd).PadRight(2) +
                                      new string(' ', 70);
            objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

            //     add 1				  to ctr-update.;
            ctr_update++;
        }

	 private async Task xe0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ya0_read_next_tape()
	 {

            //  read tp-pat-mstr;
            // 	at end;
            //         eof_tp_pat_mstr = "Y";
            // 	    go to ya0-99-exit.;

            if (ctr_tp_pat_mstr_reads >= Tp_pat_mstr_rec_Collection.Count() || Tp_pat_mstr_rec_Collection.Count() == 0)
            {
                     eof_tp_pat_mstr = "Y";
                // 	 go to ya0-99-exit.;
                await ya0_99_exit();
                return; 
            }

            objTp_pat_mstr_rec = Tp_pat_mstr_rec_Collection[ctr_tp_pat_mstr_reads];

            //     add 1				to ctr-tp-pat-mstr-reads.;
            ctr_tp_pat_mstr_reads++;
     }

	 private async Task ya0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb0_read_acr_pat_mstr()
	 {

		 pat_flag = "Y";
		 pat_occur = 0;
		 feedback_pat_mstr_acr = "0";

            //  read pat-mstr;
            //         key is pat-acronym;
            // 	invalid key;
            //        pat_flag = "N";
            // 	    go to yb0-99-exit.;

            hold_acronym_grp = Util.Str(hold_last_name) + Util.Str(hold_first_name);

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_acronym_first6 = Util.Str(hold_acronym_grp).PadRight(9).Substring(0,6),
                WherePat_acronym_last3 = Util.Str(hold_acronym_grp).PadRight(9).Substring(6, 3)
            }.Collection();

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                  pat_flag = "N";
                // 	    go to yb0-99-exit.;
                await yb0_99_exit();
                return; 
            }

            pat_mstr_Rec_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_Rec_ctr];
            await PatMstr_To_ScreenVariables();
        }

	 private async Task yb0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb0_3_read_hc_pat_mstr()
	 {

		 pat_flag = "Y";
		 feedback_pat_mstr_hc = "0";

            //  read pat-mstr into ws-pat-mstr-rec;
            //        key is pat-health-nbr of pat-mstr;
            // 	invalid key;
            //         pat_flag = "N";
            // 	    go to yb0-3-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_health_nbr = pat_health_nbr
            }.Collection();

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                  pat_flag = "N";
                //  go to yb0-3-99-exit.;
                await yb0_3_99_exit();
                return; 
            }

            pat_mstr_Rec_WS_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_Rec_WS_ctr];
            await PatMstr_Record_To_WsPatmstrRec_ScreenVariables();
     }

	 private async Task yb0_3_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb0_5_read_od_pat_mstr()
	 {

		 pat_flag = "Y";
		 feedback_pat_mstr_od = "0";
            //        read pat-mstr into ws-pat-mstr-rec;
            //        key is pat-ohip-mmyy of pat-mstr;
            // 	invalid key;
            //         pat_flag = "N";
            // 	    go to yb0-5-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                  //wherepat_ohi = pat_health_nbr
                  WherePat_direct_alpha = Util.Str(pat_ohip_mmyy_grp).PadRight(15).Substring(0,3),
                  WherePat_direct_yy = Util.NumInt(Util.Str(pat_ohip_mmyy_grp).PadRight(15).Substring(3, 2)),
                 WherePat_direct_mm = Util.NumInt(Util.Str(pat_ohip_mmyy_grp).PadRight(15).Substring(5, 2)),
                  WherePat_direct_dd = Util.NumInt(Util.Str(pat_ohip_mmyy_grp).PadRight(15).Substring(7, 2)),
                WherePat_direct_last_6 = Util.Str(pat_ohip_mmyy_grp).PadRight(15).Substring(9, 6)
            }.Collection();

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                pat_flag = "N";
                // 	    go to yb0-5-99-exit.;
                await yb0_5_99_exit();
                return;
            }

            pat_mstr_Rec_WS_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_Rec_WS_ctr];
            await PatMstr_Record_To_WsPatmstrRec_ScreenVariables();
        }

	 private async Task yb0_5_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb0_10_read_next_pat_mstr()
	 {

		 pat_flag = "Y";

            //   read pat-mstr next;
            // 	at end;
            //        pat_flag = "N";
            // 	    go to yb0-10-99-exit.;

            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_Rec_ctr];
            pat_mstr_Rec_ctr++;
            await PatMstr_To_ScreenVariables();

            //  if pat-acronym not = hold-acronym then;   
            hold_acronym_grp = hold_last_name + hold_first_name;
            if (pat_acronym_grp  != hold_acronym_grp) {
                   pat_flag = "N";
            }
        }

	 private async Task yb0_10_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb1_write_patient()
	 {

            //     perform yc5-check-dup-ikey			thru yc5-99-exit.;
            await yc5_check_dup_ikey();
            await yc5_99_exit();

            //    objPat_mstr_rec.pat_mstr_rec = ws_pat_mstr_rec;
            await Assign_ws_pat_mstr_rec_to_Pat_Mstr_Rec_from();

            //     perform yb2-write-pat-i-key			thru yb2-99-exit.;
            await yb2_write_pat_i_key();
            await yb2_99_exit();

            //     perform ge0-increment-nx-avail-pat		thru ge0-99-exit.;
            await ge0_increment_nx_avail_pat();
            await ge0_99_exit();
        }

	 private async Task yb1_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb2_write_pat_i_key()
	 {

            // if pat-ohip-mmyy = " " or pat-ohip-mmyy = zero then   
            if (string.IsNullOrWhiteSpace(pat_ohip_mmyy_grp) || Util.NumInt(pat_ohip_mmyy_grp) == 0) {                

                pat_ohip_mmyy_grp = Util.Str(ws_pat_i_nbr);

                pat_ohip_nbr = Util.NumInt(Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(0, 8));
                pat_mm = Util.NumInt(Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(8, 2));
                pat_yy = Util.NumInt(Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(10, 2));

                pat_direct_alpha_grp = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(0, 3);
                pat_alpha1 = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(0, 1);
                pat_alpha2_3 = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(1, 2);

                pat_direct_yy = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(3, 2);
                pat_direct_mm = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(5, 2);
                pat_direct_dd = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(7, 2);
                pat_direct_filler = Util.Str(pat_ohip_mmyy_grp).PadRight(12).Substring(9, 3);

            }

            key_pat_mstr_grp = Util.Str(pat_i_key).PadRight(1) + Util.Str(pat_con_nbr).PadLeft(2,'0') + Util.Str(pat_i_nbr).PadLeft(12,'0');

            x_key_pat_mstr_grp = key_pat_mstr_grp;

            x_pat_i_key = Util.Str(x_key_pat_mstr_grp).PadRight(16).Substring(0, 1);
            x_pat_con_nbr = Util.NumInt(Util.Str(x_key_pat_mstr_grp).PadRight(16).Substring(1, 2));
            x_pat_i_nbr = Util.NumInt(Util.Str(x_key_pat_mstr_grp).PadRight(16).Substring(3, 12));

            // if pat-chart-nbr   = spaces then
            pat_chart_nbr_grp = Util.Str(pat_chart_1st_char) + Util.Str(pat_chart_remainder);
            if (string.IsNullOrWhiteSpace(pat_chart_nbr_grp)) {
                pat_chart_nbr_grp = x_ikey_2_11_digits;

                pat_chart_1st_char = Util.Str(pat_chart_nbr_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder = Util.Str(pat_chart_nbr_grp).PadRight(10).Substring(1, 9);
            }

            // if pat-chart-nbr-2   = spaces then
            pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2) + Util.Str(pat_chart_remainder_2);
            if (string.IsNullOrWhiteSpace(pat_chart_nbr_2_grp)) {
                pat_chart_nbr_2_grp = x_ikey_2_11_digits;

                pat_chart_1st_char_2 = Util.Str(pat_chart_nbr_2_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder_2 = Util.Str(pat_chart_nbr_2_grp).PadRight(10).Substring(1, 9);
            }

            // if pat-chart-nbr-3   = spaces then 
            pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3) + Util.Str(pat_chart_remainder_3);
            if (string.IsNullOrWhiteSpace(pat_chart_nbr_3_grp) ) {
                pat_chart_nbr_3_grp = x_ikey_2_11_digits;

                pat_chart_1st_char_3= Util.Str(pat_chart_nbr_3_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder_3 = Util.Str(pat_chart_nbr_3_grp).PadRight(10).Substring(1, 9);
            }

            // if pat-chart-nbr-4   = spaces then
            pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4) + Util.Str(pat_chart_remainder_4);
            if (string.IsNullOrWhiteSpace(pat_chart_nbr_4_grp) ) {
                   x_pat_chart4_1_digit = "?";  
                   x_pat_chart4_9_digits = x_ikey_3_11_digits;

                x_pat_chart_nbr_4_grp = Util.Str(x_pat_chart4_1_digit) + Util.Str(x_pat_chart4_9_digits);
                 pat_chart_nbr_4_grp = x_pat_chart_nbr_4_grp;   
            }

            //  if pat-chart-nbr-5 = spaces then 
            pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5) + Util.Str(pat_chart_remainder_5);
            if (string.IsNullOrWhiteSpace(pat_chart_nbr_5_grp)) {

                x_key_pat_mstr_test_grp = Util.Str(x_ikey_1_digit) + Util.Str(x_ikey_2_11_digits);
                pat_chart_nbr_5_grp = x_key_pat_mstr_test_grp;

                pat_chart_1st_char_5 = Util.Str(pat_chart_nbr_5_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder_5 = Util.Str(pat_chart_nbr_5_grp).PadRight(10).Substring(1, 9);
            }

            //  write pat-mstr-rec;
            //   	invalid key;
            // 	    go to err-pat-mstr.;

            if (await Write_Pat_Mstr_Rec() == false)
            {
                // 	    go to err-pat-mstr.;
                await err_pat_mstr();
                return; 
            }

            status_cobol_display1 = status_cobol_pat_mstr1;

            //   if   status-cobol-pat-mstr1 <> 9 then
            if (Util.NumInt(status_cobol_pat_mstr1) != 9 ) {
                    status_cobol_display2 = Util.NumInt(status_cobol_pat_mstr2);
            }
            else {
                      status_cobol_pat_mstr1 = low_values;
                      status_cobol_display2 = status_cobol_pat_mstr_binary;
            }

            //     if status-cobol-pat-mstr1 <> 0 then; 
            if (Util.NumInt(status_cobol_pat_mstr1) != 0) {
                // 	      display "Patient error = ", status-cobol-display.;
            }


            //     add 1				to ctr-pat-mstr-writes.;
            ctr_pat_mstr_writes++;
        }

        private async Task yb2_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb7_write_hc_key()
	 {

	 }

	 private async Task yb7_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb8_write_acr_key()
	 {

	 }

	 private async Task yb8_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yb9_write_od_key()
	 {

	 }

	 private async Task yb9_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yc5_check_dup_ikey()
	 {

            hold_pat_ikey_grp = Util.Str(hold_pat_i_key).PadRight(1) + Util.Str(hold_iconst_con_nbr).PadLeft(2, '0') + Util.Str(hold_iconst_nx_ikey).PadLeft(12, '0');

            key_pat_mstr_grp = hold_pat_ikey_grp;

            pat_i_key = Util.Str(hold_pat_ikey_grp).PadRight(15).Substring(0, 1);
            pat_con_nbr = Util.NumInt(Util.Str(hold_pat_ikey_grp).PadRight(15).Substring(1, 2));
            pat_i_nbr = Util.NumInt(Util.Str(hold_pat_ikey_grp).PadRight(15).Substring(3, 12));


            //  read pat-mstr;
            // 	  invalid key;
            // 	     go to yc5-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_i_key = pat_i_key,
                WherePat_con_nbr = pat_con_nbr,
                WherePat_i_nbr = pat_i_nbr
            }.Collection();

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                // 	     go to yc5-99-exit.;
                await yc5_99_exit();
                return; 
            }

            objPat_mstr_rec = Pat_mstr_rec_Collection[0];

                   err_ind = 54;
            //     display err-msg(err-ind).;
            Console.WriteLine(err_msg[err_ind]);

            //     display key-pat-mstr of pat-mstr.;
            Console.WriteLine(key_pat_mstr_grp);

            //     perform xa0-write-tp-error-report		thru xa0-99-exit.;
            await xa0_write_tp_error_report();
            await xa0_99_exit();

            //     perform err-pat-mstr.;
            await err_pat_mstr();
            
        }

	 private async Task yc5_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yd0_build_seq_pat_rec()
	 {

		 objSeq_pat_ikey_file_rec.Seq_pat_doctor_nbr = objTp_pat_mstr_rec.Tp_pat_doctor_nbr;
		 objSeq_pat_ikey_file_rec.Seq_pat_account_id = objTp_pat_mstr_rec.Tp_pat_account_id;

		 save_con_nbr = ws_pat_con_nbr;
		 save_i_nbr = ws_pat_i_nbr;

         save_pat_ikey_grp = Util.Str(save_con_nbr).PadLeft(2, '0') + Util.Str(save_i_nbr).PadLeft(12, '0');
         objSeq_pat_ikey_file_rec.Seq_pat_i_key = save_pat_ikey_grp;

         ws_pat_acronym_grp = Util.Str(ws_pat_acronym_first6).PadRight(6) + Util.Str(ws_pat_acronym_last3).PadRight(3);
         objSeq_pat_ikey_file_rec.Seq_pat_acronym = ws_pat_acronym_grp;
		 objSeq_pat_ikey_file_rec.Seq_pat_province = ws_pat_prov_cd;
	 }

	 private async Task yd0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task ye0_write_seq_pat_rec()
	 {

            //     write seq-pat-ikey-file-rec.;
            string tempData = Util.Str(objSeq_pat_ikey_file_rec.Seq_pat_doctor_nbr).PadLeft(6, '0') +
                         Util.Str(objSeq_pat_ikey_file_rec.Seq_pat_account_id).PadRight(8) +
                         Util.Str(objSeq_pat_ikey_file_rec.Seq_pat_i_key).PadRight(14) +
                         Util.Str(objSeq_pat_ikey_file_rec.Seq_pat_acronym).PadRight(9) +
                         Util.Str(objSeq_pat_ikey_file_rec.Seq_pat_province).PadRight(2);

            objSeq_pat_ikey_file.AppendOutputFile(tempData, true);

            //     add 1				to	ctr-seq-pat-file-writes.;\
            ctr_seq_pat_file_writes++;
        }

	 private async Task ye0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yf0_write_new_patient()
	 {

            //     write new-pat-file-rec.;

            string tempData = Util.Str(objNew_pat_file_rec.New_pat_ohip).PadRight(12) +
                              Util.Str(objNew_pat_file_rec.New_pat_surname).PadRight(25) +
                              Util.Str(objNew_pat_file_rec.New_pat_first_name).PadRight(17) +
                              Util.Str(objNew_pat_file_rec.New_pat_subscr_surname).PadRight(25) +
                              Util.Str(objNew_pat_file_rec.New_pat_address_line_1).PadRight(30) +
                              Util.Str(objNew_pat_file_rec.New_pat_address_line_2).PadRight(30) +
                              Util.Str(objNew_pat_file_rec.New_pat_address_line_3).PadRight(30) +
                              Util.Str(objNew_pat_file_rec.New_pat_address_prov_cd).PadRight(2) +
                              Util.Str(objNew_pat_file_rec.New_pat_postal_code).PadRight(10) +
                              Util.Str(objNew_pat_file_rec.New_pat_birth_date).PadRight(8) +
                              Util.Str(objNew_pat_file_rec.New_pat_sex).PadRight(1);

            objobjNew_pat_file.AppendOutputFile(tempData);

            //     add 1				to	ctr-new-pat-file-writes.;
            ctr_new_pat_file_writes++;
        }

	 private async Task yf0_99_exit()
	 {

		 //     exit.;
	 }

	 private async Task yg0_check_update_pat()
	 {

            edit_flag = "Y";

            //  perform ba0-edit-birth-date-version-cd 	thru ba0-99-exit.;
            await ba0_edit_birth_date_version_cd();
            await ba0_99_exit();

            // if invalid-record then 
            if (edit_flag.Equals(invalid_record) ) {
                // 	  perform xa0-write-tp-error-report	thru xa0-99-exit;
                await xa0_write_tp_error_report();
                await xa0_99_exit();
                //    go to yg0-99-exit.;
                await yg0_99_exit();
                return; 
            }

            //objPat_id_rec.pat_id_rec = "";
            objPat_id_rec = new F086_PAT_ID();
            objPat_id_rec.PAT_OLD_SURNAME = ws_pat_surname;
            objPat_id_rec.PAT_OLD_GIVEN_NAME = ws_pat_given_name;
            objPat_id_rec.PAT_OLD_HEALTH_NBR  = ws_pat_health_nbr;

            ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char).PadRight(1) + Util.Str(pat_chart_remainder).PadRight(9);
            objPat_id_rec.PAT_OLD_CHART_NBR  = ws_pat_chart_nbr_grp;

            ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2).PadRight(1) + Util.Str(pat_chart_remainder_2).PadRight(9);
            objPat_id_rec.PAT_OLD_CHART_NBR_2 = ws_pat_chart_nbr_2_grp;

            ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3).PadRight(1) + Util.Str(pat_chart_remainder_3).PadRight(9);
            objPat_id_rec.PAT_OLD_CHART_NBR_3 = ws_pat_chart_nbr_3_grp;

            ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4).PadRight(1) + Util.Str(pat_chart_remainder_4).PadRight(9);
            objPat_id_rec.PAT_OLD_CHART_NBR_4  = ws_pat_chart_nbr_4_grp;

            ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5).PadRight(1) + Util.Str(pat_chart_remainder_5).PadRight(9);
            objPat_id_rec.PAT_OLD_CHART_NBR_5  = ws_pat_chart_nbr_5_grp;
            objPat_id_rec.PAT_OLD_ADDR1  = ws_subscr_addr1;
            objPat_id_rec.PAT_OLD_ADDR2  = ws_subscr_addr2;
            objPat_id_rec.PAT_OLD_ADDR3  = ws_subscr_addr3;

            //prt_det_line1 = "";
              prt_lit1 = "";
            prt_ohip_health_nbr = "";
            rma_birth_date_yy = 0;
            rma_birth_date_mm = 0;
            rma_birth_date_dd = 0;
            rma_version_cd = "";
            rma_prov_cd = "";
            rma_reason_desc = "";

            //prt_det_line2 = "";
            prt_lit2 = "";
            disk_doctor_nbr = 0;
            disk_account_id = "";
            disk_birth_date_yy = 0;
            disk_birth_date_mm = 0;
            disk_birth_date_dd = 0;
            disk_version_cd = "";
            disk_prov_cd = "";

            pat_change_flag = "N";

            ws_birth_date_yy = objTp_pat_mstr_rec.Tp_pat_birth_yy;
            ws_birth_date_mm = objTp_pat_mstr_rec.Tp_pat_birth_mm;
            ws_birth_date_dd = objTp_pat_mstr_rec.Tp_pat_birth_dd;

            flag_change_version_cd = "N";
		 flag_birth_date_change = "N";
		 flag_old_version_cd = "N";
		 flag_old_birth_date = "N";

            // if  ws-birth-date <> 0 and ws-birth-date not = ws-pat-birth-date then 

            ws_birth_date_grp = Util.Str(ws_birth_date_yy).PadLeft(4, '0') + Util.Str(ws_birth_date_mm).PadLeft(2, '0') + Util.Str(ws_birth_date_dd).PadLeft(2, '0');
            if (Util.NumInt(ws_birth_date_grp) != 0 && Util.NumInt(ws_birth_date_grp) != ws_pat_birth_date ) {
                     flag_birth_date_change = "Y";
                // 	   if ws-birth-date not = ws-pat-last-birth-date then            
                if (Util.NumInt(ws_birth_date_grp) != ws_pat_last_birth_date ) {
                            ws_pat_last_birth_date = ws_pat_birth_date;
                           ws_pat_birth_date = Util.NumInt(ws_birth_date_grp);
                }
                else {
                    flag_old_birth_date = "Y";
                    rma_birth_date_yy = ws_pat_birth_date_yy;
                    rma_birth_date_mm = ws_pat_birth_date_mm;
                    rma_birth_date_dd = ws_pat_birth_date_dd;
                    disk_birth_date_yy = ws_birth_date_yy;
                    disk_birth_date_mm = ws_birth_date_mm;
                    disk_birth_date_dd = ws_birth_date_dd;
                }
            }


            // if tp-pat-prov    not = ws-pat-prov-cd then 
            if (Util.Str(objTp_pat_mstr_rec.Tp_pat_prov) != Util.Str(ws_pat_prov_cd)) {
                   rma_prov_cd = ws_pat_prov_cd;
                   ws_pat_prov_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_prov);
                   disk_prov_cd  =  Util.Str(objTp_pat_mstr_rec.Tp_pat_prov);
                   pat_change_flag = "Y";
            }

            // if ( (    tp-pat-version-cd-1 = " " or tp-pat-version-cd-2 = " ") and (    pat-version-cd-1 of pat-mstr <> " "  and pat-version-cd-2 of pat-mstr <> " "  )  )  then
            if (
                 ((string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_version_cd_1)  || string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_version_cd_2)) && ( Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(0,1) != " "  && Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(1, 1) != " ")  ) 
                ) {
                        flag_1_vs_2_character_ver_cd = "Y";
            }
            else {
                       flag_1_vs_2_character_ver_cd = "N";
            }


            //  if  tp-pat-version-cd <> ' ' and tp-pat-version-cd <> ws-pat-version-cd  and not one-char-ver-cd-vs-2-char  then 
            if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.Tp_pat_version_cd) && objTp_pat_mstr_rec.Tp_pat_version_cd != ws_pat_version_cd  && !flag_1_vs_2_character_ver_cd.Equals(one_char_ver_cd_vs_2_char) ) {
                      flag_change_version_cd = "Y";
                // 	    if tp-pat-version-cd <> ws-pat-last-version-cd then            
                if (objTp_pat_mstr_rec.Tp_pat_version_cd != ws_pat_last_version_cd) {
                             ws_pat_last_version_cd = ws_pat_version_cd;
                             rma_version_cd = ws_pat_version_cd;
                             ws_pat_version_cd = objTp_pat_mstr_rec.Tp_pat_version_cd;
                     	     disk_version_cd  = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd);
                }
                else {
                             flag_old_version_cd = "Y";
                             rma_version_cd = ws_pat_version_cd;
                             disk_version_cd = Util.Str(objTp_pat_mstr_rec.Tp_pat_version_cd);
                }
            }

            // if  ( version-cd-changed and old-version-cd-matches ) or (     birth-date-changed  and  old-birth-date-matches )  then 
            if ((( flag_change_version_cd.Equals(version_cd_changed) && flag_old_version_cd.Equals(old_version_cd_matches))) || (flag_birth_date_change.Equals(birth_date_changed) && flag_old_birth_date.Equals(old_birth_date_matches)))
                 {
                // 	   perform xe0-write-update-exception-rpt    thru xe0-99-exit.;
                await xe0_write_update_exception_rpt();
                await xe0_99_exit();
            }


            //  if   pat-change or (    version-cd-changed  and old-version-cd-doesnt-match )   or (    birth-date-changed  and old-birth-date-doesnt-match ) then 
            if (pat_change_flag.Equals(pat_change)  || (flag_change_version_cd.Equals(version_cd_changed)  && flag_old_version_cd.Equals(old_version_cd_doesnt_match)) || ( flag_birth_date_change.Equals(birth_date_changed)  && flag_old_birth_date.Equals(old_birth_date_doesnt_match))) {
                // 	    go to yg0-80;
                await yg0_80();
                return; 
            }
            else {
                // 	    go to yg0-99-exit.;
                await yg0_99_exit();
                return; 
            }
        }

        private async Task yg0_80()
	 {

            //  if (  birth-date-changed  and old-birth-date-doesnt-match ) and (    version-cd-changed  and old-version-cd-doesnt-match  )  then
            if ((flag_birth_date_change.Equals(birth_date_changed) && flag_old_birth_date.Equals(old_birth_date_doesnt_match)) && (flag_change_version_cd.Equals(version_cd_changed) && flag_old_version_cd.Equals(old_version_cd_doesnt_match))) {
                err_ind = 58;
            }
            // else  if   (    birth-date-changed and old-birth-date-doesnt-match ) then            
            else if (flag_birth_date_change.Equals(birth_date_changed) && flag_old_birth_date.Equals(old_birth_date_doesnt_match)) {
                err_ind = 56;
            }
            //  else if   (    version-cd-changed and old-version-cd-doesnt-match  )  then 
            else if (flag_change_version_cd.Equals(version_cd_changed) && flag_old_version_cd.Equals(old_version_cd_doesnt_match)) {
                       err_ind = 57;
            }
            //  else if   pat-change  then            
            else if ( pat_change_flag.Equals(pat_change))
                  err_ind = 59;

            //     perform xd0-write-audit-report      thru xd0-99-exit.;
            await xd0_write_audit_report();
            await xd0_99_exit();


            // if  (  version-cd-changed  and old-version-cd-doesnt-match  )  or (    birth-date-changed and old-birth-date-doesnt-match  ) then  
            if (
                 (flag_change_version_cd.Equals(version_cd_changed)  && flag_old_version_cd.Equals(old_version_cd_doesnt_match)  ) || ( flag_birth_date_change.Equals( birth_date_changed) && flag_old_birth_date.Equals(old_birth_date_doesnt_match))
                ) {
                //     perform yy0-process-pat-elig-change	thru yy0-99-exit.;
                await yy0_process_pat_elig_change();
                await yy0_99_exit();
            }

            ws_pat_date_last_maint = Util.NumInt(sys_date_long_child);

            //     rewrite pat-mstr-rec 		from ws-pat-mstr-rec.;
            await Rewrite_Pat_Mstr_Rec_from_ws_pat_mstr_rec();
        }

        private async Task yg0_99_exit()
	 {

		 //     exit.;
	 }

	 // process_pat_eligibility_change.rtn
	 private async Task yy0_process_pat_elig_change()
	 {

		 ws_pat_date_last_maint = Util.NumInt(sys_date_long_child);

            ws_pat_date_last_elig_maint = Util.NumInt(sys_date_long_child);

		 ws_pat_no_of_letter_sent = 0;

            //  if  ws-pat-mess-code <> spaces then  
            if (!string.IsNullOrWhiteSpace( ws_pat_mess_code)) {
                ws_pat_mess_code = "";
            }

            //     perform yy1-write-corrected-pat-rec	thru	yy1-99-exit.;
            await yy1_write_corrected_pat_rec();
            await yy1_99_exit();

            //     perform yy2-write-pat-elig-hist-rec	thru	yy2-99-exit.;
            await yy2_write_pat_elig_hist_rec();
            await yy2_99_exit();
        }

	 // process_pat_eligibility_change.rtn
	 private async Task yy0_99_exit()
	 {

		 //     exit.;
	 }

	 // process_pat_eligibility_change.rtn
	 private async Task yy1_write_corrected_pat_rec()
	 {


            //move key-pat-mstr of pat-mstr to clmhdr-pat-ohip-id-or-chart  of pat-id-rec.
            objPat_id_rec.CLMHDR_PAT_OHIP_ID_OR_CHART = Util.Str(pat_i_key).PadRight(1) +  Util.Str(pat_con_nbr).PadLeft(2,'0') +  Util.Str(pat_i_nbr).PadLeft(12,'0') + new string(' ',1);

            objPat_id_rec.PAT_LAST_BIRTH_DATE  = ws_pat_last_birth_date;
            objPat_id_rec.PAT_LAST_VERSION_CD  = ws_pat_last_version_cd;

            //     write pat-id-rec.;
            objPat_id_rec.RecordState = State.Added;
            objPat_id_rec.Submit();

            //     add 1                       to ctr-write-corrected-pat.;
            ctr_write_corrected_pat++;
        }

        // process_pat_eligibility_change.rtn
        private async Task yy1_99_exit()
	 {

		 //     exit.;
	 }

	 // process_pat_eligibility_change.rtn
	 private async Task yy2_write_pat_elig_hist_rec()
	 {

            //objPat_elig_history.Key_pat_mstr = objPat_mstr.Key_pat_mstr;
            objF011_pat_mstr_elig_history_rec.PAT_I_KEY = pat_i_key;
            objF011_pat_mstr_elig_history_rec.PAT_CON_NBR = pat_con_nbr;
            objF011_pat_mstr_elig_history_rec.PAT_I_NBR = pat_i_nbr;

            //objPat_elig_history.Pat_expiry_date = objPat_mstr.Pat_expiry_date;
            objF011_pat_mstr_elig_history_rec.PAT_EXPIRY_YY = pat_expiry_yy;
            objF011_pat_mstr_elig_history_rec.PAT_EXPIRY_MM = pat_expiry_mm;

            //objPat_elig_history.Pat_health_nbr = objPat_mstr.Pat_health_nbr;
            objF011_pat_mstr_elig_history_rec.PAT_HEALTH_NBR = pat_health_nbr;

            //objPat_elig_history.Pat_health_nbr_last = objPat_mstr.Pat_health_nbr;
            objF011_pat_mstr_elig_history_rec.PAT_LAST_HEALTH_NBR = pat_health_nbr;

            //objPat_elig_history.Pat_birth_date = ws_pat_birth_date;
            objF011_pat_mstr_elig_history_rec.PAT_BIRTH_DATE = ws_pat_birth_date;

            //objPat_elig_history.Pat_birth_date_last = ws_pat_last_birth_date;
            objF011_pat_mstr_elig_history_rec.PAT_BIRTH_DATE_LAST = ws_pat_last_birth_date;

            //objPat_elig_history.Pat_version_cd = ws_pat_version_cd;
            objF011_pat_mstr_elig_history_rec.PAT_VERSION_CD = ws_pat_version_cd;

            //objPat_elig_history.Pat_version_cd_last = ws_pat_last_version_cd;
            objF011_pat_mstr_elig_history_rec.PAT_LAST_VERSION_CD  = ws_pat_last_version_cd;

            //objPat_elig_history.Pat_date_last_maint = sys_date;
            objF011_pat_mstr_elig_history_rec.PAT_DATE_LAST_MAINT = Util.NumInt(sys_date_long_child);

            //     accept sys-time                  from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));


            //    objPat_elig_history.Pat_time_last_maint = sys_time;
            objF011_pat_mstr_elig_history_rec.PAT_DATE_LAST_MAINT =  Util.NumInt(Util.Str(sys_hrs) + Util.Str(sys_min) + Util.Str(sys_sec));

            //     write f011-pat-mstr-elig-history-rec.;
            objF011_pat_mstr_elig_history_rec.RecordState = State.Added;
            objF011_pat_mstr_elig_history_rec.Submit();

            //     add 1                            to ctr-write-pat-elig-hist.;
            ctr_write_pat_elig_hist++;
        }

	 // process_pat_eligibility_change.rtn
	 private async Task yy2_99_exit()
	 {

		 //     exit.;
		 // 	replacing ==clmhdr-pat-ohip-id-or-chart of claim-header-rec==;
		 // 	       by ==tp-pat-ohip-health-no==.;
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


        private async Task Initialize_ws_pat_mstr_Rec()
        {
            ws_pat_mstr_rec_grp = "";
            ws_pat_acronym_grp = "";
            ws_pat_acronym_first6 = "";
            ws_pat_acronym_last3 = "";
            ws_pat_ohip_mmyy_grp = "";
            ws_pat_ohip_out_prov_grp = "";
            ws_pat_ohip_nbr = 0;
            ws_pat_ohip_nbr_r_alpha = "";
            ws_pat_ohip_nbr_MB_def_grp = "";
            ws_pat_ohip_nbr_MB = 0;
            //filler;
            ws_pat_ohip_nbr_NT_def_grp = "";
            ws_pat_ohip_nbr_NT_1_char = "";
            ws_pat_ohip_nbr_NT = 0;
            ws_pat_mm = 0;
            ws_pat_yy = 0;
            ws_pat_ohip_mmyy_r_grp = "";
            ws_pat_direct_alpha_grp = "";
            ws_pat_alpha1 = "";
            ws_pat_alpha2_3 = "";
            ws_pat_direct_yy = "";
            ws_pat_direct_mm = "";
            ws_pat_direct_dd = "";
            ws_pat_direct_filler = "";
            ws_pat_chart_nbr_grp = "";
            pat_chart_1st_char = "";
            pat_chart_remainder = "";
            ws_pat_chart_nbr_2_grp = "";
            pat_chart_1st_char_2 = "";
            pat_chart_remainder_2 = "";
            ws_pat_chart_nbr_3_grp = "";
            pat_chart_1st_char_3 = "";
            pat_chart_remainder_3 = "";
            ws_pat_chart_nbr_4_grp = "";
            pat_chart_1st_char_4 = "";
            pat_chart_remainder_4 = "";
            ws_pat_chart_nbr_5_grp = "";
            pat_chart_1st_char_5 = "";
            pat_chart_remainder_5 = "";
            ws_pat_surname = "";
            ws_pat_surname_r_grp = "";
            ws_pat_surname_first6 = "";
            ws_pat_surname_last19 = "";
            ws_pat_surname_rr_grp = "";
            ws_pat_surname_first3 = "";
            ws_pat_surname_last22 = "";
            ws_pat_given_name = "";
            ws_pat_given_name_r_grp = "";
            ws_pat_given_name_first3 = "";
            ws_pat_given_name_last14 = "";
            ws_pat_given_name_rr_grp = "";
            ws_pat_given_name_first1 = "";
            ws_pat_init_grp = "";
            ws_pat_init1 = "";
            ws_pat_init2 = "";
            ws_pat_init3 = "";
            ws_pat_location_field_grp = "";
            ws_pat_location_field_1_3 = "";
            ws_pat_last_doc_nbr_seen = "";
            ws_pat_birth_date = 0;
            ws_pat_birth_date_r_grp = "";
            ws_pat_birth_date_yy = 0;
            ws_pat_birth_date_yy_r_grp = "";
            ws_pat_birth_date_yy_12 = 0;
            ws_pat_birth_date_yy_34 = 0;
            ws_pat_birth_date_mm = 0;
            ws_pat_birth_date_dd = 0;
            ws_pat_date_last_maint = 0;
            ws_pat_date_last_maint_r_grp = "";
            ws_pat_date_last_maint_yy = 0;
            ws_pat_date_last_maint_mm = 0;
            ws_pat_date_last_maint_dd = 0;
            ws_pat_date_last_visit = 0;
            ws_pat_date_last_visit_r_grp = "";
            ws_pat_date_last_visit_yy = 0;
            ws_pat_date_last_visit_mm = 0;
            ws_pat_date_last_visit_dd = 0;
            ws_pat_date_last_admit = 0;
            ws_pat_date_last_admit_r_grp = "";
            ws_pat_date_last_admit_yy = 0;
            ws_pat_date_last_admit_mm = 0;
            ws_pat_date_last_admit_dd = 0;
            ws_pat_phone_nbr_grp = "";
            ws_pat_phone_nbr_first3 = 0;
            ws_pat_phone_nbr_last4 = 0;
            ws_pat_phone_nbr_remainder = "";
            ws_pat_total_nbr_visits = 0;
            ws_pat_total_nbr_claims = 0;
            ws_pat_sex = "";
            ws_pat_in_out = "";
            ws_pat_nbr_outstanding_claims = 0;
            ws_key_pat_mstr_grp = "";
            ws_pat_i_key = "";
            ws_pat_con_nbr = 0;
            ws_pat_i_nbr = 0;
            ws_pat_health_nbr = 0;
            ws_pat_version_cd = "";
            //ws_pat_version_cd_1 = "";
            //ws_pat_version_cd_2 = "";
            ws_pat_health_65_ind = "";
            ws_pat_expiry_date_grp = "";
            ws_pat_expiry_yy = 0;
            ws_pat_expiry_mm = 0;
            ws_pat_prov_cd = "";
            ws_subscr_addr1 = "";
            ws_subscr_addr2 = "";
            ws_subscr_addr3 = "";
            ws_subscr_prov_cd = "";
            ws_subscr_postal_cd = "";
            ws_subscr_postal_cd_r_grp = "";
            ws_subscr_post_code1_grp = "";
            ws_subscr_post_cd1 = "";
            ws_subscr_post_cd2 = 0;
            ws_subscr_post_cd3 = "";
            ws_subscr_post_code2_grp = "";
            ws_subscr_post_cd4 = 0;
            ws_subscr_post_cd5 = "";
            ws_subscr_post_cd6 = 0;
            ws_subscr_msg_data_grp = "";
            ws_subscr_msg_nbr = "";
            ws_subscr_dt_msg_no_eff_to = 0;
            ws_subscr_dt_msg_no_eff_to_r_grp = "";
            ws_subscr_dt_msg_no_eff_to_yy = 0;
            ws_subscr_dt_msg_no_eff_to_mm = 0;
            ws_subscr_dt_msg_no_eff_to_dd = 0;
            ws_subscr_dt_msg_no_eff_to_r1 = "";
            ws_subscr_date_last_statement = 0;
            ws_subscr_date_last_stmnt_r_grp = "";
            ws_subscr_date_last_stmnt_yy = 0;
            ws_subscr_date_last_stmnt_mm = 0;
            ws_subscr_date_last_stmnt_dd = 0;
            ws_subscr_auto_update = "";
            ws_pat_last_mod_by = "";
            ws_pat_date_last_elig_mailing = 0;
            ws_pat_date_last_elig_maint = 0;
            ws_pat_last_birth_date = 0;
            ws_pat_last_birth_date_r_grp = "";
            ws_pat_last_birth_date_yy = 0;
            ws_pat_last_birth_date_mm = 0;
            ws_pat_last_birth_date_dd = 0;
            ws_pat_last_version_cd = "";
            ws_pat_mess_code = "";
            ws_pat_country = "";
            ws_pat_no_of_letter_sent = 0;
            ws_pat_dialysis = "";
            ws_pat_ohip_validiation_status = "";
            ws_pat_obec_status = "";
        }

        private async Task PatMstr_Record_To_WsPatmstrRec_ScreenVariables()
        {
            // F010_PAT_MSTR
            // move to ws-pat-mstr-rec

            ws_pat_acronym_grp = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6) + Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);
            ws_pat_acronym_first6 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6);
            ws_pat_acronym_last3 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);

            ws_pat_ohip_out_prov_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadRight(2) + new string(' ', 6);
            ws_pat_ohip_nbr = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(0, 8));
            ws_pat_ohip_nbr_r_alpha = ws_pat_ohip_out_prov_grp.Substring(0, 8);
            ws_pat_ohip_nbr_MB_def_grp = ws_pat_ohip_out_prov_grp.Substring(0, 8);
            ws_pat_ohip_nbr_MB = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(0, 6));
            ws_pat_ohip_nbr_NT_1_char = ws_pat_ohip_out_prov_grp.Substring(0, 1);
            ws_pat_ohip_nbr_NT = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(1, 7));
            ws_pat_mm = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(8, 2));
            ws_pat_yy = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(10, 2));
            ws_pat_direct_alpha_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA);
            ws_pat_alpha1 = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).Substring(0, 1);
            ws_pat_alpha2_3 = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).Substring(1, 2);
            ws_pat_direct_yy = Util.Str(objPat_mstr_rec.PAT_DIRECT_YY);
            ws_pat_direct_mm = Util.Str(objPat_mstr_rec.PAT_DIRECT_MM);
            ws_pat_direct_dd = Util.Str(objPat_mstr_rec.PAT_DIRECT_DD);
            //ws_pat_direct_filler = objPat_mstr_rec.pat_
            ws_pat_chart_nbr_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(1, 9);
            ws_pat_chart_nbr_2_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2);
            pat_chart_1st_char_2 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(0, 1);
            pat_chart_remainder_2 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(1, 9);
            ws_pat_chart_nbr_3_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3);
            pat_chart_1st_char_3 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(0, 1);
            pat_chart_remainder_3 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(1, 9);
            ws_pat_chart_nbr_4_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4);
            pat_chart_1st_char_4 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(0, 1);
            pat_chart_remainder_4 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(1, 9);
            ws_pat_chart_nbr_5_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5);
            pat_chart_1st_char_5 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(0, 1);
            pat_chart_remainder_5 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(1, 9);
            ws_pat_surname = Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22);
            ws_pat_surname_r_grp = Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22);
            ws_pat_surname_first6 = ws_pat_surname_r_grp.PadRight(25).Substring(0, 6);
            ws_pat_surname_last19 = ws_pat_surname_r_grp.PadRight(25).Substring(6, 19);
            ws_pat_surname_rr_grp = ws_pat_surname;
            ws_pat_surname_first3 = ws_pat_surname.PadRight(25).Substring(0, 3);
            ws_pat_surname_last22 = ws_pat_surname.PadRight(25).Substring(3, 22);
            ws_pat_given_name = Util.Str(objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1).PadRight(1) + Util.Str(objPat_mstr_rec.FILLER3).PadRight(16);
            ws_pat_given_name_r_grp = ws_pat_given_name;
            ws_pat_given_name_first3 = ws_pat_given_name_r_grp.Substring(0, 3);
            ws_pat_given_name_last14 = ws_pat_given_name_r_grp.Substring(3, 14);
            ws_pat_given_name_rr_grp = ws_pat_given_name_r_grp;
            ws_pat_given_name_first1 = ws_pat_given_name_rr_grp.Substring(0, 1);
            //filler 
            ws_pat_init_grp = Util.Str(objPat_mstr_rec.PAT_INIT1) + Util.Str(objPat_mstr_rec.PAT_INIT2) + Util.Str(objPat_mstr_rec.PAT_INIT3);
            ws_pat_location_field_grp = Util.Str(objPat_mstr_rec.PAT_LOCATION_FIELD);
            ws_pat_location_field_1_3 = ws_pat_location_field_grp.PadRight(4).Substring(0, 3);
            ws_pat_last_doc_nbr_seen = Util.Str(objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN);
            ws_pat_birth_date = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY) + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_MM) + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_DD));
            ws_pat_birth_date_r_grp = Util.Str(ws_pat_birth_date);
            ws_pat_birth_date_yy = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_YY);
            ws_pat_birth_date_yy_r_grp = Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY);
            ws_pat_birth_date_yy_12 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY).PadRight(4).Substring(0, 2));
            ws_pat_birth_date_yy_34 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY).PadRight(4).Substring(2, 2));
            ws_pat_birth_date_mm = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_MM);
            ws_pat_birth_date_dd = Util.NumInt(objPat_mstr_rec.PAT_BIRTH_DATE_DD);
            ws_pat_date_last_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_MAINT);
            ws_pat_date_last_maint_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT);
            ws_pat_date_last_maint_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(0, 4));
            ws_pat_date_last_maint_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(4, 2));
            ws_pat_date_last_maint_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadRight(8).Substring(6, 2));
            ws_pat_date_last_visit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            ws_pat_date_last_visit_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            ws_pat_date_last_visit_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(0, 4));
            ws_pat_date_last_visit_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(4, 2));
            ws_pat_date_last_visit_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadRight(8).Substring(6, 2));
            ws_pat_date_last_admit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            ws_pat_date_last_admit_r_grp = Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            ws_pat_date_last_admit_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(0, 4));
            ws_pat_date_last_admit_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(4, 2));
            ws_pat_date_last_admit_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadRight(8).Substring(6, 2));
            ws_pat_phone_nbr_grp = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR);
            ws_pat_phone_nbr_first3 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(0, 3));
            ws_pat_phone_nbr_last4 = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(3, 4));
            ws_pat_phone_nbr_remainder = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR).PadRight(20).Substring(7, 13);
            ws_pat_total_nbr_visits = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_VISITS);
            ws_pat_total_nbr_claims = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS);
            ws_pat_sex = Util.Str(objPat_mstr_rec.PAT_SEX);
            ws_pat_in_out = Util.Str(objPat_mstr_rec.PAT_IN_OUT);
            ws_pat_nbr_outstanding_claims = Util.NumInt(objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS);
            ws_key_pat_mstr_grp = Util.Str(objPat_mstr_rec.PAT_I_KEY) + Util.Str(objPat_mstr_rec.PAT_CON_NBR) + Util.Str(objPat_mstr_rec.PAT_I_NBR);
            ws_pat_i_key = Util.Str(objPat_mstr_rec.PAT_I_KEY);
            ws_pat_con_nbr = Util.NumInt(objPat_mstr_rec.PAT_CON_NBR);
            ws_pat_i_nbr = Util.NumInt(objPat_mstr_rec.PAT_I_NBR);
            ws_pat_health_nbr = Util.NumInt(objPat_mstr_rec.PAT_HEALTH_NBR);
            ws_pat_version_cd = Util.Str(objPat_mstr_rec.PAT_VERSION_CD);
            //ws_pat_version_cd_1 = Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(0, 1);
            //ws_pat_version_cd_2 = Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(1, 1);
            ws_pat_health_65_ind = Util.Str(objPat_mstr_rec.PAT_HEALTH_65_IND);
            ws_pat_expiry_date_grp = Util.Str(objPat_mstr_rec.PAT_EXPIRY_YY).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_EXPIRY_MM).PadLeft(2, '0');
            ws_pat_expiry_yy = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_YY);
            ws_pat_expiry_mm = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_MM);
            ws_pat_prov_cd = Util.Str(objPat_mstr_rec.PAT_PROV_CD);
            ws_subscr_addr1 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR1);
            ws_subscr_addr2 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR2);
            ws_subscr_addr3 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR3);
            ws_subscr_prov_cd = Util.Str(objPat_mstr_rec.SUBSCR_PROV_CD);
            ws_subscr_postal_cd = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            ws_subscr_postal_cd_r_grp = ws_subscr_postal_cd;
            ws_subscr_post_code1_grp = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            ws_subscr_post_cd1 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1);
            ws_subscr_post_cd2 = Util.NumInt(objPat_mstr_rec.SUBSCR_POST_CD2);
            ws_subscr_post_cd3 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            ws_subscr_post_code2_grp = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            ws_subscr_post_cd4 = Util.NumInt(objPat_mstr_rec.SUBSCR_POST_CD4);
            ws_subscr_post_cd5 = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5);
            ws_subscr_post_cd6 = Util.NumInt(objPat_mstr_rec.SUBSCR_POST_CD6);
            //ws_subscr_msg_data_grp
            ws_subscr_msg_nbr = Util.Str(objPat_mstr_rec.SUBSCR_MSG_NBR);
            ws_subscr_dt_msg_no_eff_to = Util.NumInt(Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD));
            ws_subscr_dt_msg_no_eff_to_r_grp = Util.Str(ws_subscr_dt_msg_no_eff_to);
            ws_subscr_dt_msg_no_eff_to_yy = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY);
            ws_subscr_dt_msg_no_eff_to_mm = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM);
            ws_subscr_dt_msg_no_eff_to_dd = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD);
            ws_subscr_dt_msg_no_eff_to_r1 = ws_subscr_dt_msg_no_eff_to_r_grp;
            ws_subscr_date_last_statement = Util.NumInt(Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM) + Util.Str(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD));
            ws_subscr_date_last_stmnt_r_grp = Util.Str(ws_subscr_date_last_statement);
            ws_subscr_date_last_stmnt_yy = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY);
            ws_subscr_date_last_stmnt_mm = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM);
            ws_subscr_date_last_stmnt_dd = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD);
            ws_subscr_auto_update = Util.Str(objPat_mstr_rec.SUBSCR_AUTO_UPDATE);
            ws_pat_last_mod_by = Util.Str(objPat_mstr_rec.PAT_LAST_MOD_BY);
            ws_pat_date_last_elig_mailing = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING);
            ws_pat_date_last_elig_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT);
            ws_pat_last_birth_date = Util.NumInt(objPat_mstr_rec.PAT_LAST_BIRTH_DATE);
            ws_pat_last_birth_date_r_grp = Util.Str(ws_pat_last_birth_date);
            ws_pat_last_birth_date_yy = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_LAST_BIRTH_DATE).PadRight(8).Substring(0, 4));
            ws_pat_last_birth_date_mm = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_LAST_BIRTH_DATE).PadRight(8).Substring(4, 2));
            ws_pat_last_birth_date_dd = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_LAST_BIRTH_DATE).PadRight(8).Substring(6, 2));
            ws_pat_last_version_cd = Util.Str(objPat_mstr_rec.PAT_LAST_VERSION_CD);
            ws_pat_mess_code = Util.Str(objPat_mstr_rec.PAT_MESS_CODE);
            ws_pat_country = Util.Str(objPat_mstr_rec.PAT_COUNTRY);
            ws_pat_no_of_letter_sent = Util.NumInt(objPat_mstr_rec.PAT_NO_OF_LETTER_SENT);
            ws_pat_dialysis = Util.Str(objPat_mstr_rec.PAT_DIALYSIS);
            ws_pat_ohip_validiation_status = Util.Str(objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS);
            ws_pat_obec_status = Util.Str(objPat_mstr_rec.PAT_OBEC_STATUS);
        }

        private async Task Assign_ws_pat_mstr_rec_to_Pat_Mstr_Rec_from()
        {
              //    objPat_mstr_rec.pat_mstr_rec = ws_pat_mstr_rec;
           
                objPat_mstr_rec.PAT_ACRONYM_FIRST6 = ws_pat_acronym_first6;
                objPat_mstr_rec.PAT_ACRONYM_LAST3 = ws_pat_acronym_last3;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_alpha1;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_alpha2_3;
                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumDec(ws_pat_direct_yy);
                objPat_mstr_rec.PAT_DIRECT_MM = Util.NumDec(ws_pat_direct_mm);
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumDec(ws_pat_direct_dd);

                ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char).PadRight(1) + Util.Str(pat_chart_remainder).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR = ws_pat_chart_nbr_grp;

                ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2).PadRight(1) + Util.Str(pat_chart_remainder_2).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_2 = ws_pat_chart_nbr_2_grp;

                ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3).PadRight(1) + Util.Str(pat_chart_remainder_3).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_3 = ws_pat_chart_nbr_3_grp;

                ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4).PadRight(1) + Util.Str(pat_chart_remainder_4).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_4 = ws_pat_chart_nbr_4_grp;

                ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5).PadRight(1) + Util.Str(pat_chart_remainder_5).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_5 = ws_pat_chart_nbr_5_grp;

                objPat_mstr_rec.PAT_LOCATION_FIELD = ws_pat_location_field_grp;
                objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN = ws_pat_last_doc_nbr_seen;
                objPat_mstr_rec.PAT_BIRTH_DATE_YY = Util.NumDec(ws_pat_birth_date_yy);
                objPat_mstr_rec.PAT_BIRTH_DATE_MM = Util.NumDec(ws_pat_birth_date_mm);
                objPat_mstr_rec.PAT_BIRTH_DATE_DD = Util.NumDec(ws_pat_birth_date_dd);
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = ws_pat_date_last_maint;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumDec(ws_pat_date_last_maint_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = ws_pat_date_last_visit;
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = Util.NumDec(ws_pat_date_last_visit_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = ws_pat_date_last_admit;
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = Util.NumDec(ws_pat_date_last_admit_r_grp);
                objPat_mstr_rec.PAT_PHONE_NBR = ws_pat_phone_nbr_grp;
                objPat_mstr_rec.PAT_TOTAL_NBR_VISITS = ws_pat_total_nbr_visits;
                objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS = ws_pat_total_nbr_claims;
                objPat_mstr_rec.PAT_SEX = ws_pat_sex;
                objPat_mstr_rec.PAT_IN_OUT = ws_pat_in_out;
                objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS = ws_pat_nbr_outstanding_claims;
                objPat_mstr_rec.PAT_I_KEY = ws_pat_i_key;
                objPat_mstr_rec.PAT_CON_NBR = ws_pat_con_nbr;
                objPat_mstr_rec.PAT_I_NBR = ws_pat_i_nbr;
                objPat_mstr_rec.PAT_HEALTH_NBR = ws_pat_health_nbr;
                objPat_mstr_rec.PAT_VERSION_CD = ws_pat_version_cd; // this is not groupname anymore... other cobol program, it's a group name and contains a children variables.
                objPat_mstr_rec.PAT_HEALTH_65_IND = ws_pat_health_65_ind;
                objPat_mstr_rec.PAT_EXPIRY_YY = ws_pat_expiry_yy;
                objPat_mstr_rec.PAT_EXPIRY_MM = Util.NumDec(ws_pat_expiry_mm);
                objPat_mstr_rec.PAT_PROV_CD = ws_pat_prov_cd;
                objPat_mstr_rec.SUBSCR_ADDR1 = ws_subscr_addr1;
                objPat_mstr_rec.SUBSCR_ADDR2 = ws_subscr_addr2;
                objPat_mstr_rec.SUBSCR_ADDR3 = ws_subscr_addr3;
                objPat_mstr_rec.SUBSCR_PROV_CD = ws_subscr_prov_cd;
                objPat_mstr_rec.SUBSCR_POST_CD1 = this.ws_subscr_post_cd1;
                objPat_mstr_rec.SUBSCR_POST_CD2 = ws_subscr_post_cd2;
                objPat_mstr_rec.SUBSCR_POST_CD3 = ws_subscr_post_cd3;
                objPat_mstr_rec.SUBSCR_POST_CD4 = ws_subscr_post_cd4;
                objPat_mstr_rec.SUBSCR_POST_CD5 = ws_subscr_post_cd5;
                objPat_mstr_rec.SUBSCR_POST_CD6 = ws_subscr_post_cd6;
                objPat_mstr_rec.SUBSCR_MSG_NBR = ws_subscr_msg_nbr;
                ws_subscr_dt_msg_no_eff_to = Util.NumInt(ws_subscr_dt_msg_no_eff_to_r_grp);
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ws_subscr_dt_msg_no_eff_to_yy;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ws_subscr_dt_msg_no_eff_to_mm;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ws_subscr_dt_msg_no_eff_to_dd;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY = ws_subscr_date_last_stmnt_yy;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM = ws_subscr_date_last_stmnt_mm;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD = ws_subscr_date_last_stmnt_dd;
                objPat_mstr_rec.SUBSCR_AUTO_UPDATE = ws_subscr_auto_update;
                objPat_mstr_rec.PAT_LAST_MOD_BY = ws_pat_last_mod_by;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING = ws_pat_date_last_elig_mailing;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT = ws_pat_date_last_elig_maint;
                objPat_mstr_rec.PAT_LAST_BIRTH_DATE = ws_pat_last_birth_date;
                ws_pat_last_birth_date = Util.NumInt(ws_pat_last_birth_date_r_grp);
                objPat_mstr_rec.PAT_LAST_VERSION_CD = ws_pat_last_version_cd;
                objPat_mstr_rec.PAT_MESS_CODE = ws_pat_mess_code;
                objPat_mstr_rec.PAT_COUNTRY = ws_pat_country;
                objPat_mstr_rec.PAT_NO_OF_LETTER_SENT = ws_pat_no_of_letter_sent;
                objPat_mstr_rec.PAT_DIALYSIS = ws_pat_dialysis;
                objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS = ws_pat_ohip_validiation_status;
                objPat_mstr_rec.PAT_OBEC_STATUS = ws_pat_obec_status;
                        
        }

        private async Task<bool> Rewrite_Pat_Mstr_Rec_from_ws_pat_mstr_rec()
        {
            //     rewrite pat-mstr-rec    from ws-pat-mstr-rec;

            try
            {

                objPat_mstr_rec.PAT_ACRONYM_FIRST6 = ws_pat_acronym_first6;
                objPat_mstr_rec.PAT_ACRONYM_LAST3 = ws_pat_acronym_last3;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_alpha1;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_alpha2_3;
                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumDec(ws_pat_direct_yy);
                objPat_mstr_rec.PAT_DIRECT_MM = Util.NumDec(ws_pat_direct_mm);
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumDec(ws_pat_direct_dd);

                ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char).PadRight(1) + Util.Str(pat_chart_remainder).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR = ws_pat_chart_nbr_grp;

                ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2).PadRight(1) + Util.Str(pat_chart_remainder_2).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_2 = ws_pat_chart_nbr_2_grp;

                ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3).PadRight(1) + Util.Str(pat_chart_remainder_3).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_3 = ws_pat_chart_nbr_3_grp;

                ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4).PadRight(1) + Util.Str(pat_chart_remainder_4).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_4 = ws_pat_chart_nbr_4_grp;

                ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5).PadRight(1) + Util.Str(pat_chart_remainder_5).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_5 = ws_pat_chart_nbr_5_grp;
                
                objPat_mstr_rec.PAT_LOCATION_FIELD = ws_pat_location_field_grp;
                objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN = ws_pat_last_doc_nbr_seen;
                objPat_mstr_rec.PAT_BIRTH_DATE_YY = Util.NumDec(ws_pat_birth_date_yy);
                objPat_mstr_rec.PAT_BIRTH_DATE_MM = Util.NumDec(ws_pat_birth_date_mm);
                objPat_mstr_rec.PAT_BIRTH_DATE_DD = Util.NumDec(ws_pat_birth_date_dd);
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = ws_pat_date_last_maint;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumDec(ws_pat_date_last_maint_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = ws_pat_date_last_visit;
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = Util.NumDec(ws_pat_date_last_visit_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = ws_pat_date_last_admit;
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = Util.NumDec(ws_pat_date_last_admit_r_grp);
                objPat_mstr_rec.PAT_PHONE_NBR = ws_pat_phone_nbr_grp;
                objPat_mstr_rec.PAT_TOTAL_NBR_VISITS = ws_pat_total_nbr_visits;
                objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS = ws_pat_total_nbr_claims;
                objPat_mstr_rec.PAT_SEX = ws_pat_sex;
                objPat_mstr_rec.PAT_IN_OUT = ws_pat_in_out;
                objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS = ws_pat_nbr_outstanding_claims;
                objPat_mstr_rec.PAT_I_KEY = ws_pat_i_key;
                objPat_mstr_rec.PAT_CON_NBR = ws_pat_con_nbr;
                objPat_mstr_rec.PAT_I_NBR = ws_pat_i_nbr;
                objPat_mstr_rec.PAT_HEALTH_NBR = ws_pat_health_nbr;
                objPat_mstr_rec.PAT_VERSION_CD = ws_pat_version_cd; // this is not groupname anymore... other cobol program, it's a group name and contains a children variables.
                objPat_mstr_rec.PAT_HEALTH_65_IND = ws_pat_health_65_ind;
                objPat_mstr_rec.PAT_EXPIRY_YY = ws_pat_expiry_yy;
                objPat_mstr_rec.PAT_EXPIRY_MM = Util.NumDec(ws_pat_expiry_mm);
                objPat_mstr_rec.PAT_PROV_CD = ws_pat_prov_cd;
                objPat_mstr_rec.SUBSCR_ADDR1 = ws_subscr_addr1;
                objPat_mstr_rec.SUBSCR_ADDR2 = ws_subscr_addr2;
                objPat_mstr_rec.SUBSCR_ADDR3 = ws_subscr_addr3;
                objPat_mstr_rec.SUBSCR_PROV_CD = ws_subscr_prov_cd;
                objPat_mstr_rec.SUBSCR_POST_CD1 = this.ws_subscr_post_cd1;
                objPat_mstr_rec.SUBSCR_POST_CD2 = ws_subscr_post_cd2;
                objPat_mstr_rec.SUBSCR_POST_CD3 = ws_subscr_post_cd3;
                objPat_mstr_rec.SUBSCR_POST_CD4 = ws_subscr_post_cd4;
                objPat_mstr_rec.SUBSCR_POST_CD5 = ws_subscr_post_cd5;
                objPat_mstr_rec.SUBSCR_POST_CD6 = ws_subscr_post_cd6;
                objPat_mstr_rec.SUBSCR_MSG_NBR = ws_subscr_msg_nbr;
                ws_subscr_dt_msg_no_eff_to = Util.NumInt(ws_subscr_dt_msg_no_eff_to_r_grp);
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ws_subscr_dt_msg_no_eff_to_yy;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ws_subscr_dt_msg_no_eff_to_mm;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ws_subscr_dt_msg_no_eff_to_dd;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY = ws_subscr_date_last_stmnt_yy;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM = ws_subscr_date_last_stmnt_mm;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD = ws_subscr_date_last_stmnt_dd;
                objPat_mstr_rec.SUBSCR_AUTO_UPDATE = ws_subscr_auto_update;
                objPat_mstr_rec.PAT_LAST_MOD_BY = ws_pat_last_mod_by;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING = ws_pat_date_last_elig_mailing;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT = ws_pat_date_last_elig_maint;
                objPat_mstr_rec.PAT_LAST_BIRTH_DATE = ws_pat_last_birth_date;
                ws_pat_last_birth_date = Util.NumInt(ws_pat_last_birth_date_r_grp);
                objPat_mstr_rec.PAT_LAST_VERSION_CD = ws_pat_last_version_cd;
                objPat_mstr_rec.PAT_MESS_CODE = ws_pat_mess_code;
                objPat_mstr_rec.PAT_COUNTRY = ws_pat_country;
                objPat_mstr_rec.PAT_NO_OF_LETTER_SENT = ws_pat_no_of_letter_sent;
                objPat_mstr_rec.PAT_DIALYSIS = ws_pat_dialysis;
                objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS = ws_pat_ohip_validiation_status;
                objPat_mstr_rec.PAT_OBEC_STATUS = ws_pat_obec_status;

                objPat_mstr_rec.RecordState = State.Modified;
                objPat_mstr_rec.Submit();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> Write_Pat_Mstr_Rec_from_ws_pat_mstr_rec()
        {
            //     write pat-mstr-rec    from ws-pat-mstr-rec;

            try
            {
                F010_PAT_MSTR objPat_mstr_rec = null;
                objPat_mstr_rec = new F010_PAT_MSTR();

                objPat_mstr_rec.PAT_ACRONYM_FIRST6 = ws_pat_acronym_first6;
                objPat_mstr_rec.PAT_ACRONYM_LAST3 = ws_pat_acronym_last3;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_alpha1;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_alpha2_3;
                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumDec(ws_pat_direct_yy);
                objPat_mstr_rec.PAT_DIRECT_MM = Util.NumDec(ws_pat_direct_mm);
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumDec(ws_pat_direct_dd);

                ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char).PadRight(1) + Util.Str(pat_chart_remainder).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR = ws_pat_chart_nbr_grp;

                ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2).PadRight(1) + Util.Str(pat_chart_remainder_2).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_2 = ws_pat_chart_nbr_2_grp;

                ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3).PadRight(1) + Util.Str(pat_chart_remainder_3).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_3 = ws_pat_chart_nbr_3_grp;

                ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4).PadRight(1) + Util.Str(pat_chart_remainder_4).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_4 = ws_pat_chart_nbr_4_grp;

                ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5).PadRight(1) + Util.Str(pat_chart_remainder_5).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_5 = ws_pat_chart_nbr_5_grp;
                
                objPat_mstr_rec.PAT_LOCATION_FIELD = ws_pat_location_field_grp;
                objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN = ws_pat_last_doc_nbr_seen;
                objPat_mstr_rec.PAT_BIRTH_DATE_YY = Util.NumDec(ws_pat_birth_date_yy);
                objPat_mstr_rec.PAT_BIRTH_DATE_MM = Util.NumDec(ws_pat_birth_date_mm);
                objPat_mstr_rec.PAT_BIRTH_DATE_DD = Util.NumDec(ws_pat_birth_date_dd);
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = ws_pat_date_last_maint;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumDec(ws_pat_date_last_maint_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = ws_pat_date_last_visit;
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = Util.NumDec(ws_pat_date_last_visit_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = ws_pat_date_last_admit;
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = Util.NumDec(ws_pat_date_last_admit_r_grp);
                objPat_mstr_rec.PAT_PHONE_NBR = ws_pat_phone_nbr_grp;
                objPat_mstr_rec.PAT_TOTAL_NBR_VISITS = ws_pat_total_nbr_visits;
                objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS = ws_pat_total_nbr_claims;
                objPat_mstr_rec.PAT_SEX = ws_pat_sex;
                objPat_mstr_rec.PAT_IN_OUT = ws_pat_in_out;
                objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS = ws_pat_nbr_outstanding_claims;
                objPat_mstr_rec.PAT_I_KEY = ws_pat_i_key;
                objPat_mstr_rec.PAT_CON_NBR = ws_pat_con_nbr;
                objPat_mstr_rec.PAT_I_NBR = ws_pat_i_nbr;
                objPat_mstr_rec.PAT_HEALTH_NBR = ws_pat_health_nbr;
                objPat_mstr_rec.PAT_VERSION_CD = ws_pat_version_cd;
                objPat_mstr_rec.PAT_HEALTH_65_IND = ws_pat_health_65_ind;
                objPat_mstr_rec.PAT_EXPIRY_YY = ws_pat_expiry_yy;
                objPat_mstr_rec.PAT_EXPIRY_MM = Util.NumDec(ws_pat_expiry_mm);
                objPat_mstr_rec.PAT_PROV_CD = ws_pat_prov_cd;
                objPat_mstr_rec.SUBSCR_ADDR1 = ws_subscr_addr1;
                objPat_mstr_rec.SUBSCR_ADDR2 = ws_subscr_addr2;
                objPat_mstr_rec.SUBSCR_ADDR3 = ws_subscr_addr3;
                objPat_mstr_rec.SUBSCR_PROV_CD = ws_subscr_prov_cd;
                objPat_mstr_rec.SUBSCR_POST_CD1 = this.ws_subscr_post_cd1;
                objPat_mstr_rec.SUBSCR_POST_CD2 = ws_subscr_post_cd2;
                objPat_mstr_rec.SUBSCR_POST_CD3 = ws_subscr_post_cd3;
                objPat_mstr_rec.SUBSCR_POST_CD4 = ws_subscr_post_cd4;
                objPat_mstr_rec.SUBSCR_POST_CD5 = ws_subscr_post_cd5;
                objPat_mstr_rec.SUBSCR_POST_CD6 = ws_subscr_post_cd6;
                objPat_mstr_rec.SUBSCR_MSG_NBR = ws_subscr_msg_nbr;
                ws_subscr_dt_msg_no_eff_to = Util.NumInt(ws_subscr_dt_msg_no_eff_to_r_grp);
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ws_subscr_dt_msg_no_eff_to_yy;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ws_subscr_dt_msg_no_eff_to_mm;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ws_subscr_dt_msg_no_eff_to_dd;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY = ws_subscr_date_last_stmnt_yy;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM = ws_subscr_date_last_stmnt_mm;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD = ws_subscr_date_last_stmnt_dd;
                objPat_mstr_rec.SUBSCR_AUTO_UPDATE = ws_subscr_auto_update;
                objPat_mstr_rec.PAT_LAST_MOD_BY = ws_pat_last_mod_by;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING = ws_pat_date_last_elig_mailing;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT = ws_pat_date_last_elig_maint;
                objPat_mstr_rec.PAT_LAST_BIRTH_DATE = ws_pat_last_birth_date;
                ws_pat_last_birth_date = Util.NumInt(ws_pat_last_birth_date_r_grp);
                objPat_mstr_rec.PAT_LAST_VERSION_CD = ws_pat_last_version_cd;  // this is not groupname anymore... other cobol program, it's a group name and contains a children variables.
                objPat_mstr_rec.PAT_MESS_CODE = ws_pat_mess_code;
                objPat_mstr_rec.PAT_COUNTRY = ws_pat_country;
                objPat_mstr_rec.PAT_NO_OF_LETTER_SENT = ws_pat_no_of_letter_sent;
                objPat_mstr_rec.PAT_DIALYSIS = ws_pat_dialysis;
                objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS = ws_pat_ohip_validiation_status;
                objPat_mstr_rec.PAT_OBEC_STATUS = ws_pat_obec_status;

                objPat_mstr_rec.RecordState = State.Added;
                objPat_mstr_rec.Submit();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> Write_Pat_Mstr_Rec()
        {
            try
            {
                F010_PAT_MSTR objPat_mstr_rec = null;
                objPat_mstr_rec = new F010_PAT_MSTR();

                objPat_mstr_rec.PAT_ACRONYM_FIRST6 = pat_acronym_first6;
                objPat_mstr_rec.PAT_ACRONYM_LAST3 = pat_acronym_last3;

                objPat_mstr_rec.PAT_DIRECT_ALPHA = pat_direct_alpha_grp;
                /* pat_ohip_nbr_r_alpha = pat_ohip_out_prov_grp.Substring(0, 8);
                 pat_ohip_nbr_MB_def_grp = pat_ohip_out_prov_grp.Substring(0, 8);
                 pat_ohip_nbr_MB = Util.NumInt(pat_ohip_out_prov_grp.Substring(0, 6));
                 pat_ohip_nbr_NT_1_char = pat_ohip_out_prov_grp.Substring(0, 1);
                 pat_ohip_nbr_NT = Util.NumInt(pat_ohip_out_prov_grp.Substring(1, 7)); */

                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumDec(pat_direct_yy);
                objPat_mstr_rec.PAT_DIRECT_MM = Util.NumDec(pat_direct_mm);
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumDec(pat_direct_dd);

                pat_chart_nbr_grp = Util.Str(pat_chart_1st_char).PadRight(1) + Util.Str(pat_chart_remainder).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR = pat_chart_nbr_grp;

                pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char_2).PadRight(1) + Util.Str(pat_chart_remainder_2).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_2 = pat_chart_nbr_2_grp;

                pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char_3).PadRight(1) + Util.Str(pat_chart_remainder_3).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_3 = pat_chart_nbr_3_grp;

                pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char_4).PadRight(1) + Util.Str(pat_chart_remainder_4).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_4 = pat_chart_nbr_4_grp;

                pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char_5).PadRight(1) + Util.Str(pat_chart_remainder_5).PadRight(9);
                objPat_mstr_rec.PAT_CHART_NBR_5 = pat_chart_nbr_5_grp;

                objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1 = pat_given_name.PadRight(1);
                //filler                 
                objPat_mstr_rec.PAT_LOCATION_FIELD = pat_location_field_grp;
                objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN = pat_last_doc_nbr_seen;
                objPat_mstr_rec.PAT_BIRTH_DATE_YY = pat_birth_date_yy;
                objPat_mstr_rec.PAT_BIRTH_DATE_MM = pat_birth_date_mm;
                objPat_mstr_rec.PAT_BIRTH_DATE_DD = pat_birth_date_dd;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = pat_date_last_maint;
                objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumDec(pat_date_last_maint_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = pat_date_last_visit;
                objPat_mstr_rec.PAT_DATE_LAST_VISIT = Util.NumDec(pat_date_last_visit_r_grp);
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = pat_date_last_admit;
                objPat_mstr_rec.PAT_DATE_LAST_ADMIT = Util.NumDec(pat_date_last_admit_r_grp);
                objPat_mstr_rec.PAT_PHONE_NBR = pat_phone_nbr_grp;
                objPat_mstr_rec.PAT_TOTAL_NBR_VISITS = pat_total_nbr_visits;
                objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS = pat_total_nbr_claims;
                objPat_mstr_rec.PAT_SEX = pat_sex;
                objPat_mstr_rec.PAT_IN_OUT = pat_in_out;
                objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS = pat_nbr_outstanding_claims;
                objPat_mstr_rec.PAT_I_KEY = pat_i_key;
                objPat_mstr_rec.PAT_CON_NBR = pat_con_nbr;
                objPat_mstr_rec.PAT_I_NBR = pat_i_nbr;
                objPat_mstr_rec.PAT_HEALTH_NBR = Util.NumDec(pat_health_nbr);
                objPat_mstr_rec.PAT_VERSION_CD = pat_version_cd_grp;
                objPat_mstr_rec.PAT_HEALTH_65_IND = pat_health_65_ind;
                objPat_mstr_rec.PAT_EXPIRY_YY = pat_expiry_yy;
                objPat_mstr_rec.PAT_EXPIRY_MM = pat_expiry_mm;
                objPat_mstr_rec.PAT_PROV_CD = pat_prov_cd;
                objPat_mstr_rec.SUBSCR_ADDR1 = subscr_addr1;
                objPat_mstr_rec.SUBSCR_ADDR2 = subscr_addr2;
                objPat_mstr_rec.SUBSCR_ADDR3 = subscr_addr3;
                objPat_mstr_rec.SUBSCR_PROV_CD = subscr_prov_cd;
                objPat_mstr_rec.SUBSCR_POST_CD1 = subscr_post_cd1;
                objPat_mstr_rec.SUBSCR_POST_CD2 = subscr_post_cd2;
                objPat_mstr_rec.SUBSCR_POST_CD3 = subscr_post_cd3;
                objPat_mstr_rec.SUBSCR_POST_CD4 = subscr_post_cd4;
                objPat_mstr_rec.SUBSCR_POST_CD5 = subscr_post_cd5;
                objPat_mstr_rec.SUBSCR_POST_CD6 = subscr_post_cd6;
                objPat_mstr_rec.SUBSCR_MSG_NBR = subscr_msg_nbr;
                subscr_date_msg_nbr_eff_to = Util.NumInt(subscr_date_msg_nbr_eff_to_r);
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = subscr_date_msg_nbr_eff_to_yy;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = subscr_date_msg_nbr_eff_to_mm;
                objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = subscr_date_msg_nbr_eff_to_dd;
                subscr_date_last_statement = Util.NumInt(subscr_date_last_statement_r_grp);
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY = subscr_date_last_statement_yy;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM = subscr_date_last_statement_mm;
                objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD = subscr_date_last_statement_dd;
                objPat_mstr_rec.SUBSCR_AUTO_UPDATE = subscr_auto_update;
                objPat_mstr_rec.PAT_LAST_MOD_BY = pat_last_mod_by;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING = pat_date_last_elig_mailing;
                objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT = pat_date_last_elig_maint;
                objPat_mstr_rec.PAT_LAST_BIRTH_DATE = pat_last_birth_date;
                objPat_mstr_rec.PAT_LAST_VERSION_CD = pat_last_version_cd;
                objPat_mstr_rec.PAT_MESS_CODE = pat_mess_code;
                objPat_mstr_rec.PAT_COUNTRY = pat_country;
                objPat_mstr_rec.PAT_NO_OF_LETTER_SENT = pat_no_of_letter_sent;
                objPat_mstr_rec.PAT_DIALYSIS = pat_dialysis;
                objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS = pat_ohip_validiation_status;
                objPat_mstr_rec.PAT_OBEC_STATUS = pat_obec_status;

                objPat_mstr_rec.RecordState = State.Added;
                objPat_mstr_rec.Submit();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> PatMstr_To_ScreenVariables()
        {
            pat_acronym_grp = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6) + Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);
            pat_acronym_first6 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6);
            pat_acronym_last3 = Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);

            pat_ohip_out_prov_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadRight(2) + new string(' ', 6);
            pat_ohip_nbr = Util.NumInt(pat_ohip_out_prov_grp.Substring(0, 8));
            pat_mm = Util.NumInt(pat_ohip_out_prov_grp.Substring(8, 2));
            pat_yy = Util.NumInt(pat_ohip_out_prov_grp.Substring(10, 2));

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
            

            pat_chart_nbr_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
            pat_chart_1st_char = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(0, 1);
            pat_chart_remainder = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10).Substring(1, 9);
            pat_chart_nbr_2_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2);
            pat_chart_1st_char_2 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(0, 1);
            pat_chart_remainder_2 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10).Substring(1, 9);
            pat_chart_nbr_3_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3);
            pat_chart_1st_char_3 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(0, 1);
            pat_chart_remainder_3 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10).Substring(1, 9);
            pat_chart_nbr_4_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4);
            pat_chart_1st_char_4 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(0, 1);
            pat_chart_remainder_4 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10).Substring(1, 9);
            pat_chart_nbr_5_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5);
            pat_chart_1st_char_5 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(0, 1);
            pat_chart_remainder_5 = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(10).Substring(1, 9);
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
            pat_given_name_first1 = pat_given_name_rr_grp.Substring(0, 1);
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
            subscr_date_msg_nbr_eff_to_r1 = subscr_date_msg_nbr_eff_to_r;  //subscr_dt_msg_no_eff_to_r_grp;
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
            objRpt_rec_a = null;            
            Rpt_rec_a_Collection = null;            
            objRpt_rec_b = null;            
            Rpt_rec_b_Collection = null;            
            objRpt_rec_c = null;            
            Rpt_rec_c_Collection = null;            
            objTp_pat_mstr_rec = null;            
            Tp_pat_mstr_rec_Collection = null;            
            objSeq_pat_ikey_file_rec = null;            
            Seq_pat_ikey_file_rec_Collection = null;            
            objNew_pat_file_rec = null;            
            New_pat_file_rec_Collection = null;            
            objPat_mstr_rec = null;            
            Pat_mstr_rec_Collection = null;            
            objF011_pat_mstr_elig_history_rec = null;            
            F011_pat_mstr_elig_history_rec_Collection = null;            
            objRejected_claims_rec = null;            
            Rejected_claims_rec_Collection = null;            
            objPat_id_rec = null;            
            Pat_id_rec_Collection = null;            
            objIconst_mstr_rec = null;            
            Iconst_mstr_rec_Collection = null;            
            objConstants_mstr_rec_5 = null;            
            Constants_mstr_rec_5_Collection = null;            
            objAudit_File_a = null;            
            objAudit_File_b = null;            
            objAudit_File_c = null;            
            objSeq_pat_ikey_file = null;            
            objobjNew_pat_file = null;            
        }

        #endregion
    }
}

