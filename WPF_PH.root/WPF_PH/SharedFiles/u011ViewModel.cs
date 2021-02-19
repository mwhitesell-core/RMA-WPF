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
    public class U011ViewModel : CommonFunctionScr
    {

        public U011ViewModel()
        {

        }

        #region FD Section
        // FD: tp_pat_mstr_out
        private Tp_pat_mstr_rec_out objTp_pat_mstr_rec_out = null;
        private WriteFile objTp_pat_mstr_rec_out_File = null;
        private ObservableCollection<Tp_pat_mstr_rec_out> Tp_pat_mstr_rec_out_Collection;

        // FD: audit_file_a
        private Rpt_rec_a objRpt_rec_a = null;
        private ObservableCollection<Rpt_rec_a> Rpt_rec_a_Collection;

        // FD: audit_file_b
        private Rpt_rec_b objRpt_rec_b = null;
        private ObservableCollection<Rpt_rec_b> Rpt_rec_b_Collection;

        // FD: audit_file_c
        private Rpt_rec_c objRpt_rec_c = null;
        private ObservableCollection<Rpt_rec_c> Rpt_rec_c_Collection;

        // FD: tp_pat_mstr	Copy : f010_tp_pat_mstr.fd
        private Tp_pat_mstr_rec1 objTp_pat_mstr_rec = null;
        private ObservableCollection<Tp_pat_mstr_rec1> Tp_pat_mstr_rec_Collection;

        // FD: pat_mstr	Copy : f010_patient_mstr.fd
        private F010_PAT_MSTR objPat_mstr_rec = null;
        private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;

        // FD: pat_elig_history	Copy : f011_pat_mstr_elig_history.fd
        private F011_PAT_MSTR_ELIG_HISTORY objF011_pat_mstr_elig_history_rec = null;
        private ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY> F011_pat_mstr_elig_history_rec_Collection;

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

        WriteFile objTp_mstr_file_out;

        #endregion

        #region Properties
        private string _print_file_name_a;
        /* public string print_file_name_a
         {
             get
             {
                  return _print_file_name_a;
             }
             set
             {
                  if (_print_file_name_a != value)
                   {
                    _print_file_name_a = value;
                    _print_file_name_a = _print_file_name_a.ToUpper();
                    RaisePropertyChanged("print_file_name_a");
                   }
             }
         }

         private string _print_file_name_b;
         public string print_file_name_b
         {
             get
             {
                  return _print_file_name_b;
             }
             set
             {
                  if (_print_file_name_b != value)
                   {
                    _print_file_name_b = value;
                    _print_file_name_b = _print_file_name_b.ToUpper();
                    RaisePropertyChanged("print_file_name_b");
                   }
             }
         }

         private string _print_file_name_c;
         public string print_file_name_c
         {
             get
             {
                  return _print_file_name_c;
             }
             set
             {
                  if (_print_file_name_c != value)
                   {
                    _print_file_name_c = value;
                    _print_file_name_c = _print_file_name_c.ToUpper();
                    RaisePropertyChanged("print_file_name_c");
                   }
             }
         }
            */
        /* private string _status_file;
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
            */
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
        private string tp_patient_file_name = "meditech_patient_file.u011";
        private string tp_patient_file_name_out = "meditech_patient_file.out";
        private string print_file_name_a = "ru011a";
        private string print_file_name_b = "ru011b";
        private string print_file_name_c = "ru011c";
        private string feedback_iconst_mstr;
        private string feedback_tp_pat_mstr;

        private string mrn_site;
        private string mrn_is_mumc = "m";
        private string mrn_is_chedoke = "c";
        private string mrn_is_henderson = "h";
        private string mrn_is_general = "g";
        private string mrn_is_stjoes = "s";

        private string mrn_is_Haldimand_War = "d";
        private string mrn_is_West_Haldimand = "e";
        private string mrn_is_Stpeter = "f";
        private string mrn_is_West_Lincoln = "w";
        private string mrn_is_Bay_Area = "z";
        private string mrn_is_Stjoe_Brant = "b";

        private string ws_rma_chart_nbr_grp;
        private string ws_rma_chart_site_chld;
        private string ws_rma_chart_2_4_chld;
        private string ws_rma_chart_5_11_grp;
        private string ws_rma_chart_5_9_chld;
        private string ws_rma_chart_10_11_chld;
        private int sub;
        private int err_ind = 0;
        private int space_ctr = 0;
        private int ws_val_total;
        private int dummy;
        private decimal rem_even;
        private int max_nbr_digits;

        private string status_indicators_grp;
        private string status_file;
        private string status_pat_mstr = "0";
        private string status_tp_pat_mstr = "0";
        private string status_tp_pat_mstr_out = "0";
        private string status_pat_mstr_od = "0";
        private string status_pat_mstr_hc = "0";
        private string status_pat_mstr_acr = "0";
        private string status_pat_mstr_chrt = "0";
        private string status_iconst_mstr = "0";
        private string status_audit_rpt_a = "0";
        private string status_audit_rpt_b = "0";
        private string status_audit_rpt_c = "0";
        private string status_cobol_tp_pat_mstr = "0";
        private string status_cobol_tp_pat_mstr_out = "0";
        private string status_cobol_pat_mstr_grp;
        private string status_cobol_pat_mstr1 = "0";
        private string status_cobol_pat_mstr2 = "0";
        private int status_cobol_pat_mstr_bin;
        private string status_cobol_pat_mstr_out_grp;
        private string status_cobol_pat_mstr1_out = "0";
        private string status_cobol_pat_mstr2_out = "0";
        private int status_cobol_pat_mstr_bin_out;
        private string status_cobol_display_grp;
        private string status_cobol_display1;
        //private string filler;
        private int status_cobol_display2;
        private string status_cobol_pat_elig_history_grp;
        private string status_cobol_pat_elig_history1 = "0";
        private string status_cobol_pat_elig_history2 = "0";
        private string status_corrected_pat = "0";
        private string status_cobol_iconst_mstr = "0";
        private string ws_i_last_name;

        private string ws_i_first_name_grp;
        private string ws_i_first_name_1;
        private string ws_i_first_name_11;
        private string ws_i_first_name_12;

        private string ws_i_street_addr_grp;
        private string ws_i_street_addr1;
        private string ws_i_street_addr2;

        private string ws_i_city_prov_grp;
        private string ws_i_city;
        //private string filler;
        private string ws_i_prov;

        private string ws_i_detail_grp;
        private string ws_i_detail_field;
        private string ws_i_detail_field_r_grp;
        private string[] ws_i_detail_byte = new string[29];

        private string ws_i_phone_no_grp;
        private string ws_i_area_code;
        private string ws_i_local_phone_no;
        private string phone_filler;

        private string x_key_pat_mstr_grp;
        private string x_key_pat_mstr_dtl_grp;
        private string x_pat_i_key;
        private int x_pat_con_nbr;
        private long x_pat_i_nbr;
        private string x_filler;

        //01  x-key-pat-mstr-r redefines x-key-pat-mstr.
        private string x_key_pat_mstr_r_grp;
        // 05  filler pic x(4).
        //  05  x-key-pat-mstr-test.
        private string x_key_pat_mstr_test_grp;
        //    10  x-ikey-1-digit pic x.
        private string x_ikey_1_digit_chld;
        //    10  x-ikey-2-11-digits pic x(10).
        private string x_ikey_2_11_digits_chld;
        private string x_ikey_2_digit_chld;
        private string x_ikey_3_11_digits_chld;
        // 05  filler pic x.

        private string x_pat_chart_nbr_4_grp;
        private string x_pat_chart4_1_digit;
        private string x_pat_chart4_9_digits;

        // 01  hold-chart-no.
        private string hold_chart_no_grp;
        //05  hold-chart-id-no pic x(11).
        private string hold_chart_id_no;

        //01  hold-health-nbr pic 9(10).
        private long hold_health_nbr;

        //01  hold-ohip-mmyy.
        private string hold_ohip_mmyy_grp;
        // 05  hold-ohip-no pic x(8).
        private string hold_ohip_no_chld;
        // 05  hold-ohip-mm pic xx.
        private string hold_ohip_mm_chld;
        // 05  hold-ohip-yy pic xx.
        private string hold_ohip_yy_chld;
        // 05  filler pic x(3).

        // 01  hold-orig-chart-no pic x(15).
        private string hold_orig_chart_no;

        //01  hold-new-chart-no pic x(15).
        private string hold_new_chart_no;

        //01  hold-acronym.
        private string hold_acronym_grp;
        //  05  hold-last-name pic x(6).
        private string hold_last_name_chld;
        //05  hold-first-name pic x(3).
        private string hold_first_name_chld;

        // 01  hold-orig-acronym pic x(9).
        private string hold_orig_acronym;
        //01  hold-new-acronym pic x(9).
        private string hold_new_acronym;

        // 01  hold-version-cd.
        private string hold_version_cd_grp;
        //05  hold-version-cd-1                       pic x.
        private string hold_version_cd_1_chld;
        //05  hold-version-cd-2                       pic x.
        private string hold_version_cd_2_chld;

        //01  save-pat-ikey.
        private string save_pat_ikey_grp;
        //05  save-con-nbr pic 99.
        private int save_con_nbr_chld;
        //05  save-i-nbr pic 9(12).
        private long save_i_nbr_chld;

        //01  flag-ohip-vs-chart pic xx.
        private string flag_ohip_vs_chart;
        //88  health value "H ".
        private string health = "H ";
        //88  ohip value "O ".
        private string ohip = "O ";
        //88  chart value "C ".
        private string chart = "C ";
        //88  health-and-ohip value "HO".
        private string health_and_ohip = "HO";
        //88  health-and-chart value "HC".
        private string health_and_chart = "HC";
        //88  ohip-and-chart value "OC".
        private string ohip_and_chart = "OC";
        // 88  all-three value "AL".
        private string all_three = "AL";


        //77  pat-occur pic 9(12).
        private long pat_occur;
        //77  pat-occur-od pic 9(12).
        private long pat_occur_od;
        //77  pat-occur-hc pic 9(12).
        private long pat_occur_hc;
        //77  pat-occur-acr pic 9(12).
        private long pat_occur_acr;
        //77  pat-occur-chrt pic 9(12).
        private long pat_occur_chrt;
        //77  hold-pat-occur pic 9(12).
        private long hold_pat_occur;
        //77  hold-orig-acron-pat-occur pic 9(12).
        private long hold_orig_acron_pat_occur;
        //77  hold-orig-chart-pat-occur pic 9(12).
        private long hold_orig_chart_pat_occur;
        //77  ws-feedback-pat-mstr pic x(4).
        private string ws_feedback_pat_mstr;
        //77  hold-feedback-pat-mstr pic x(4).
        private string hold_feedback_pat_mstr;
        //77  hold-orig-acron-feedback pic x(4).
        private string hold_orig_acron_feedback;
        //77  hold-orig-chrt-feedback pic x(4).
        private string hold_orig_chrt_feedback;
        //77  hold-orig-hc-feedback pic x(4).
        private string hold_orig_hc_feedback;
        //77  hold-orig-od-feedback pic x(4).
        private string hold_orig_od_feedback;
        //77  feedback-pat-mstr pic x(4).
        private string feedback_pat_mstr;
        //77  feedback-pat-mstr-od pic x(4).
        private string feedback_pat_mstr_od;
        //77  feedback-pat-mstr-hc pic x(4).
        private string feedback_pat_mstr_hc;
        //77  feedback-pat-mstr-acr pic x(4).
        private string feedback_pat_mstr_acr;
        //77  feedback-pat-mstr-chrt pic x(4).
        private string feedback_pat_mstr_chrt;

        //---
        private string hold_pat_ikey_grp;
        private int hold_iconst_con_nbr_chld;
        private int hold_iconst_nx_ikey_chld;

        private string test_birth_date_grp;
        private int test_birth_yy;
        private int test_birth_mm;
        private int test_birth_dd;

        private string ikey;

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

        private string subscr_flag;
        private string subscr_exist = "Y";
        private string subscr_not_exist = "N";

        private string edit_flag;
        private string valid_record = "Y";
        private string invalid_record = "N";

        private string edit_chart_flag;
        private string valid_chart_key = "Y";
        private string invalid_chart_key = "N";

        private string province_flag;
        private string province_found = "Y";
        private string province_not_found = "N";

        private string health_flag;
        private string valid_health = "Y";
        private string invalid_health = "N";

        private string ohip_flag;
        private string valid_ohip = "Y";
        private string invalid_ohip = "N";

        private string ohip_chart_flag;
        private string chart_to_ohip = "Y";
        private string ohip_to_chart = "N";

        private string chart_flag;
        private string chart_change = "Y";
        private string chart_not_change = "N";
        private string chart_add = "A";

        private string counters_grp;
        private int ctr_pat_mstr_no_update;
        private int ctr_tp_pat_mstr_reads;
        private int ctr_pat_mstr_writes;
        private int ctr_pat_mstr_out_writes;
        private int ctr_write_corrected_pat;
        private int ctr_good_c1;
        private int ctr_pat_mstr_rewrites;
        private int ctr_write_pat_elig_hist;
        private int ctr_error_rpt_writes;
        private int ctr_warnings_rpt_writes;
        private int ctr_audit_rpt_writes;
        private int ctr_exception_rpt_writes;
        private int ctr_page_a;
        private int ctr_page_b;
        private int ctr_page_c;
        private int ctr_reject;
        private int ctr_warning;
        private int ctr_exception;
        private int ctr_audit;
        private int ctr_update;


        //01  ws-nbr-val.
        private string ws_nbr_val_grp;
        //05  ws-nbr-to-b-val pic 9(8).
        private int ws_nbr_to_b_val_chld;
        //05  ws-nbr-to-b-val-r redefines ws-nbr-to-b-val.
        private string ws_nbr_to_b_val_r;
        //    10  ws-nbr-to-b-val-1-8 occurs 8 times pic 9.
        private int[] ws_nbr_to_b_val_1_8_chld = new int[9];
        //05  ws-sum-1-2-val.
        private string ws_sum_1_2_val_grp;
        //    10  ws-sum-1-2-val-r occurs 7 times.
        private int[] ws_sum_1_2_val_r = new int[8];
        //        15  ws-sum-1-2-val-r1 pic 99.
        private int[] ws_sum_1_2_val_r1 = new int[8];
        //        15  ws-sum-1-2-val-r1-r redefines ws-sum-1-2-val-r1.
        private int[] ws_sum_1_2_val_r1_r = new int[8];
        //            20  ws-sum-1            pic 9   occurs 2 times.
        private int[,] ws_sum_1 = new int[8, 3];
        //05  ws-sum-1-2-val-r-sep redefines ws-sum-1-2-val.
        private int[] ws_sum_1_2_val_r_sep = new int[8];
        //    10  ws-sum-1-2 occurs 7 times pic 99.
        private int[] ws_sum_1_2 = new int[8];


        // 01  ws-hc-nbr-val.
        private string ws_hc_nbr_val_grp;
        //   05  ws-hc-nbr-to-b-val pic 9(10).
        private long ws_hc_nbr_to_b_val;
        //   05  ws-hc-nbr-to-b-val-r redefines ws-hc-nbr-to-b-val.
        private long ws_hc_nbr_to_b_val_r;
        //       10  ws-hc-nbr-to-b-val-1-10 occurs 10 times pic 9.
        private int[] ws_hc_nbr_to_b_val_1_10 = new int[11];

        //   05  ws-hc-sum-1-2-val.
        private string ws_hc_sum_1_2_val_grp;
        //       10  ws-hc-sum-1-2-val-r occurs 9 times.
        private int[] ws_hc_sum_1_2_val_r = new int[10];
        //           15  ws-hc-sum-1-2-val-r1 pic 99.
        private int[] ws_hc_sum_1_2_val_r1_chld = new int[10];
        //           15  ws-hc-sum-1-2-val-r1-r redefines ws-hc-sum-1-2-val-r1.
        private int[] ws_hc_sum_1_2_val_r1_r = new int[10];
        //               20  ws-hc-sum-1                 pic 9   occurs 2 times.
        private int[] ws_hc_sum_1_chld = new int[3];
        //   05  ws-hc-sum-1-2-val-r-sep redefines ws-hc-sum-1-2-val.
        private int[] ws_hc_sum_1_2_val_r_sep = new int[10];
        //       10  ws-hc-sum-1-2 occurs 9 times pic 99.
        private int[] ws_hc_sum_1_2_chld = new int[10];


        // 01 ws-tp-pat-mstr-rec.
        private string ws_tp_pat_mstr_rec;
        // 05  ws-tp-pat-func-code pic xx.
        private string ws_tp_pat_func_code;
        //    05  ws-tp-pat-last-name
        private string ws_tp_pat_last_name_grp;
        // 10  ws-tp-pat-last-name-6               pic x(6).
        private string ws_tp_pat_last_name_6_chld;
        // 10  ws-tp-pat-last-name-18              pic x(18).
        private string ws_tp_pat_last_name_18_chld;
        //     05  ws-tp-pat-first-name.
        private string ws_tp_pat_first_name_grp;
        //  10  ws-tp-pat-first-name-3              pic x(3).
        private string ws_tp_pat_first_name_3_chld;
        //   10  ws-tp-pat-first-name-21     pic x(21).
        private string ws_tp_pat_first_name_21_chld;
        // 05  ws-tp-pat-birth-date pic x(10).
        private string ws_tp_pat_birth_date;
        //  05  ws-tp-pat-birth-date-r redefines ws-tp-pat-birth-date.
        private string ws_tp_pat_birth_date_r;
        //  10  ws-tp-pat-birth-yy pic 9(4).
        private int ws_tp_pat_birth_yy;
        //    10  ws-tp-pat-birth-yy-r redefines ws-tp-pat-birth-yy.
        private int ws_tp_pat_birth_yy_r;
        //    15 ws-tp-pat-birth-yy-first-2  pic 9(2).
        private int ws_tp_pat_birth_yy_first_2_chld;
        //  15 ws-tp-pat-birth-yy-last-2   pic 9(2).
        private int ws_tp_pat_birth_yy_last_2_chld;
        //   10  ws-tp-pat-slash1 pic x.
        private string ws_tp_pat_slash1;
        //  10  ws-tp-pat-birth-mm pic 99.
        private int ws_tp_pat_birth_mm;
        //   10  ws-tp-pat-slash2 pic x.
        private string ws_tp_pat_slash2;
        //     10  ws-tp-pat-birth-dd pic 99.
        private int ws_tp_pat_birth_dd;
        //  05  ws-tp-pat-sex pic x.
        private string ws_tp_pat_sex;
        // 05  ws-tp-pat-id-no pic x(15).
        private string ws_tp_pat_id_no;
        //   05  ws-tp-pat-id-no-r redefines ws-tp-pat-id-no.
        private string ws_tp_pat_id_no_r;
        //      10  ws-tp-pat-id-no-first-8-digits.
        private string ws_tp_pat_id_no_first_8_digits_grp;
        //         15  ws-tp-pat-id-no-site pic x.
        private string ws_tp_pat_id_no_site_chld;
        //        15  ws-tp-pat-id-no-yy pic 99.
        private int ws_tp_pat_id_no_yy_chld;
        //        15  ws-tp-pat-id-no-mm pic 99.
        private int ws_tp_pat_id_no_mm_chld;
        //   15  ws-tp-pat-id-no-5-digit pic x.
        private string ws_tp_pat_id_no_5_digit_chld;
        //    15  ws-tp-pat-id-no-6-7-digit pic 9(2).
        private int ws_tp_pat_id_no_6_7_digit_chld;
        //   15  ws-tp-pat-id-no-8-digit pic 9.
        private int ws_tp_pat_id_no_8_digit_chld;
        //  15  ws-tp-pat-id-no-reminder pic x(5).
        private string ws_tp_pat_id_no_reminder_chld;
        //   10  ws-tp-pat-id-no-last-digit pic x.
        private string ws_tp_pat_id_no_last_digit_chld;
        //    05  ws-tp-pat-id-no-r2 redefines ws-tp-pat-id-no.
        private string ws_tp_pat_id_no_r2_grp;
        //     10  ws-tp-pat-id-no-alpha pic x.
        private string ws_tp_pat_id_no_alpha_chld;
        //   10  ws-tp-pat-id-no-9-digits.
        private string ws_tp_pat_id_no_9_digits_grp;
        //  15  ws-tp-pat-id-no-1-3-digits pic 9(3).
        private int ws_tp_pat_id_no_1_3_digits_chld;
        //  15  ws-tp-pat-id-no-4-9-digits pic 9(6).
        private int ws_tp_pat_id_no_4_9_digits_chld;
        //    10  ws-tp-pat-id-no-10-digit pic x.
        private string ws_tp_pat_id_no_10_digit_chld;
        //    10  ws-tp-pat-id-no-filler pic x(4).
        private string ws_tp_pat_id_no_filler_chld;
        //   05  ws-tp-pat-street-addr pic x(28).
        private string ws_tp_pat_street_addr;
        // 05  ws-tp-pat-street-addr2 pic x(28).
        private string ws_tp_pat_street_addr2;
        //  05  ws-tp-pat-city pic x(18).
        private string ws_tp_pat_city;
        //  05  ws-tp-pat-prov pic x(2).
        private string ws_tp_pat_prov;
        //  05  ws-tp-pat-postal-code pic x(6).
        private string ws_tp_pat_postal_code;
        // 05  ws-tp-pat-postal-code-r redefines ws-tp-pat-postal-code.
        private string ws_tp_pat_postal_code_r_grp;
        // 10  ws-tp-pat-postal-code-1     pic x.
        private string ws_tp_pat_postal_code_1_chld;
        //  10  ws-tp-pat-postal-code-2     pic x.
        private string ws_tp_pat_postal_code_2_chld;
        // 10  ws-tp-pat-postal-code-3     pic x.
        private string ws_tp_pat_postal_code_3_chld;
        // 10  ws-tp-pat-postal-code-4     pic x.
        private string ws_tp_pat_postal_code_4_chld;
        // 10  ws-tp-pat-postal-code-5     pic x.
        private string ws_tp_pat_postal_code_5_chld;
        //  10  ws-tp-pat-postal-code-6     pic x.
        private string ws_tp_pat_postal_code_6_chld;
        //   05  ws-tp-pat-phone-no pic x(20).
        private string ws_tp_pat_phone_no;
        //  05  ws-tp-pat-ohip-no pic x(8).
        private string ws_tp_pat_ohip_no_chld;
        //   05  ws-tp-pat-health-nbr pic x(10).
        private string ws_tp_pat_health_nbr;
        // 05  ws-tp-pat-version-cd.
        private string ws_tp_pat_version_cd_grp;
        //     10  ws-tp-pat-version-cd-1              pic x.
        private string ws_tp_pat_version_cd_1_chld;
        //   10  ws-tp-pat-version-cd-2              pic x.
        private string ws_tp_pat_version_cd_2_chld;
        //   05  ws-tp-pat-health-65-ind pic x.
        private string ws_tp_pat_health_65_ind;
        //    05  ws-tp-pat-expiry-date.
        private string ws_tp_pat_expiry_date_grp;
        //     10  ws-tp-pat-expiry-mm pic 99.
        private int ws_tp_pat_expiry_mm_chld;
        //   10  ws-tp-pat-expiry-yy pic 99.
        private int ws_tp_pat_expiry_yy_chld;

        //    05  filler pic x.


        // 01 ws-pat-mstr-rec.
        private string ws_pat_mstr_rec;
        //   05  ws-pat-acronym.
        private string ws_pat_acronym_grp;
        //      10  ws-pat-acronym-first6 pic x(6).
        private string ws_pat_acronym_first6_chld;
        //      10  ws-pat-acronym-last3 pic xxx.
        private string ws_pat_acronym_last3_chld;

        //    05  ws-pat-ohip-mmyy.
        private string ws_pat_ohip_mmyy_grp;
        //       10  ws-pat-ohip-out-prov.
        private string ws_pat_ohip_out_prov_grp;
        //          15  ws-pat-ohip-nbr pic 9(8).
        private int ws_pat_ohip_nbr_chld;
        //          15  ws-pat-ohip-nbr-r-alpha redefines ws-pat-ohip-nbr pic x(8).                                                
        private string ws_pat_ohip_nbr_r_alpha;
        //          15  ws-pat-ohip-nbr-MB-def redefines ws-pat-ohip-nbr.
        private string ws_pat_ohip_nbr_MB_def;
        //               20  ws-pat-ohip-nbr-MB pic 9(6).
        private int ws_pat_ohip_nbr_MB_chld;
        //               20  filler pic x(2).
        //          15  ws-pat-ohip-nbr-NT-def redefines ws-pat-ohip-nbr.
        private string ws_pat_ohip_nbr_NT_def_grp;
        //              20  ws-pat-ohip-nbr-NT-1-char pic x(1).
        private string ws_pat_ohip_nbr_NT_1_char_chld;
        //              20  ws-pat-ohip-nbr-NT pic 9(7).
        private int ws_pat_ohip_nbr_NT_chld;
        //          15  ws-pat-mm pic 99.
        private int ws_pat_mm_chld;
        //          15  ws-pat-yy pic 99.
        private int ws_pat_yy_chld;
        //       10  filler pic x(3).
        //   05  ws-pat-ohip-mmyy-r redefines ws-pat-ohip-mmyy.
        private string ws_pat_ohip_mmyy_r;
        //       10  ws-pat-direct-alpha.
        private string ws_pat_direct_alpha_grp;
        //           15  ws-pat-alpha1 pic x.
        private string ws_pat_alpha1_chld;
        //           15  ws-pat-alpha2-3         pic xx.
        private string ws_pat_alpha2_3_chld;
        //       10  ws-pat-direct-yy pic xx.
        private string ws_pat_direct_yy;
        //       10  ws-pat-direct-mm pic xx.
        private string ws_pat_direct_mm;
        //       10  ws-pat-direct-dd pic xx.
        private string ws_pat_direct_dd;
        //       10  ws-pat-direct-filler pic x(6).
        private string ws_pat_direct_filler;
        //   05  ws-pat-chart-nbr.
        private string ws_pat_chart_nbr_grp;
        //       10  pat-chart-1st-char pic x.
        private string pat_chart_1st_char_chld;
        //        10  pat-chart-remainder pic x(9).
        private string pat_chart_remainder_chld;
        //   05  ws-pat-chart-nbr-2.
        private string ws_pat_chart_nbr_2_grp;
        //       10  pat-chart-1st-char pic x.
        private string pat_chart_1st_char2_chld;
        //       10  pat-chart-remainder pic x(9).
        private string pat_chart_remainder2_chld;
        //   05  ws-pat-chart-nbr-3.
        private string ws_pat_chart_nbr_3_grp;
        //        10  pat-chart-1st-char pic x.
        private string pat_chart_1st_char3_chld;
        //        10  pat-chart-remainder pic x(9).
        private string pat_chart_remainder3_chld;
        //   05  ws-pat-chart-nbr-4.
        private string ws_pat_chart_nbr_4_grp;
        //        10  pat-chart-1st-char pic x.
        private string pat_chart_1st_char4_chld;
        //        10  pat-chart-remainder pic x(9).
        private string pat_chart_remainder4_chld;
        //   05  ws-pat-chart-nbr-5.
        private string ws_pat_chart_nbr_5_grp;
        //        10  pat-chart-1st-char pic x.
        private string pat_chart_1st_char5_chld;
        //        10  pat-chart-remainder pic x(10).
        private string pat_chart_remainder5_chld;

        //   05  ws-pat-surname pic x(25).
        private string ws_pat_surname;

        //   05  ws-pat-surname-r redefines  ws-pat-surname.
        private string ws_pat_surname_r_grp;
        //        10  ws-pat-surname-first6 pic x(6).
        private string ws_pat_surname_first6_chld;
        //        10  ws-pat-surname-last19 pic x(19).
        private string ws_pat_surname_last19_chld;
        //   05  ws-pat-surname-rr redefines  ws-pat-surname.
        private string ws_pat_surname_rr_grp;
        //        10  ws-pat-surname-first3 pic x(3).
        private string ws_pat_surname_first3_chld;
        //        10  ws-pat-surname-last22 pic x(22).
        private string ws_pat_surname_last22_chld;

        //  05  ws-pat-given-name pic x(17).
        private string ws_pat_given_name;
        //  05  ws-pat-given-name-r redefines  ws-pat-given-name.
        private string ws_pat_given_name_r_grp;
        //        10  ws-pat-given-name-first3 pic xxx.
        private string ws_pat_given_name_first3_chld;
        //         10  ws-pat-given-name-last14 pic x(14).
        private string ws_pat_given_name_last14_chld;
        //   05  ws-pat-given-name-rr redefines ws-pat-given-name-r.
        private string ws_pat_given_name_rr_grp;
        //         10  ws-pat-given-name-first1 pic x.
        private string ws_pat_given_name_first1_chld;
        //         10  filler pic x(16).
        private string ws_filler3;
        //  05  ws-pat-init.
        private string ws_pat_init_grp;
        //       10  ws-pat-init1 pic x.
        private string ws_pat_init1_chld;
        //       10  ws-pat-init2 pic x.
        private string ws_pat_init2_chld;
        //       10  ws-pat-init3 pic x.
        private string ws_pat_init3_chld;
        //  05  ws-pat-location-field.
        private string ws_pat_location_field_grp;
        //       10  ws-pat-location-field-1-3           pic x(3).
        private string ws_pat_location_field_1_3_chld;
        //        10  filler pic x(1).
        private string ws_filler;
        //  05  ws-pat-last-doc-nbr-seen pic x(3).
        private string ws_pat_last_doc_nbr_seen;

        //   05  ws-pat-birth-date pic 9(8).
        private int ws_pat_birth_date;

        //   05  ws-pat-birth-date-r redefines  ws-pat-birth-date.
        private string ws_pat_birth_date_r_grp;
        //        10  ws-pat-birth-date-yy pic 9(4).
        private int ws_pat_birth_date_yy_chld;
        //       10  ws-pat-birth-date-yy-r redefines ws-pat-birth-date-yy.
        private string ws_pat_birth_date_yy_r_grp;
        //             15 ws-pat-birth-date-yy-12      pic 99.
        private int ws_pat_birth_date_yy_12_chld;
        //             15 ws-pat-birth-date-yy-34      pic 99.
        private int ws_pat_birth_date_yy_34_chld;
        //       10  ws-pat-birth-date-mm pic 99.
        private int ws_pat_birth_date_mm_chld;
        //       10  ws-pat-birth-date-dd pic 99.
        private int ws_pat_birth_date_dd_chld;

        //  05  ws-pat-date-last-maint pic 9(8).
        private int ws_pat_date_last_maint;

        //  05  ws-pat-date-last-maint-r redefines ws-pat-date-last-maint.
        private string ws_pat_date_last_maint_r_grp;
        //       10  ws-pat-date-last-maint-yy pic 9(4).
        private int ws_pat_date_last_maint_yy_chld;
        //       10  ws-pat-date-last-maint-mm pic 99.
        private int ws_pat_date_last_maint_mm_chld;
        //       10  ws-pat-date-last-maint-dd pic 99.
        private int ws_pat_date_last_maint_dd_chld;

        // 05  ws-pat-date-last-visit pic 9(8).
        private int ws_pat_date_last_visit;
        // 05  ws-pat-date-last-visit-r redefines ws-pat-date-last-visit.
        private string ws_pat_date_last_visit_r_grp;
        //      10  ws-pat-date-last-visit-yy pic 9(4).
        private int ws_pat_date_last_visit_yy_chld;
        //      10  ws-pat-date-last-visit-mm pic 99.
        private int ws_pat_date_last_visit_mm_chld;
        //      10  ws-pat-date-last-visit-dd pic 99.
        private int ws_pat_date_last_visit_dd_chld;

        //  05  ws-pat-date-last-admit pic 9(8).
        private int ws_pat_date_last_admit;
        //  05  ws-pat-date-last-admit-r redefines ws-pat-date-last-admit.
        private string ws_pat_date_last_admit_r_grp;
        //      10  ws-pat-date-last-admit-yy pic 9(4).
        private int ws_pat_date_last_admit_yy_chld;
        //      10  ws-pat-date-last-admit-mm pic 99.
        private int ws_pat_date_last_admit_mm_chld;
        //      10  ws-pat-date-last-admit-dd pic 99.
        private int ws_pat_date_last_admit_dd_chld;

        //  05  ws-pat-phone-nbr.
        private string ws_pat_phone_nbr_grp;
        //      10  ws-pat-phone-nbr-first3 pic 999.
        private int ws_pat_phone_nbr_first3_chld;
        //      10  ws-pat-phone-nbr-last4 pic 9(4).
        private int ws_pat_phone_nbr_last4_chld;
        //      10  ws-pat-phone-nbr-remainder pic x(13).
        private string ws_pat_phone_nbr_remainder_chld;

        //  05  ws-pat-total-nbr-visits pic 9(5).
        private int ws_pat_total_nbr_visits;
        //  05  ws-pat-total-nbr-claims pic 9(5).
        private int ws_pat_total_nbr_claims;
        //  05  ws-pat-sex pic x.
        private string ws_pat_sex;
        //  05  ws-pat-in-out                           pic x.
        private string ws_pat_in_out;


        // 05  ws-pat-nbr-outstanding-claims pic 9(4).
        private int ws_pat_nbr_outstanding_claims;


        // 05  ws-key-pat-mstr.
        private string ws_key_pat_mstr_grp;
        //     10  ws-pat-i-key pic x.
        private string ws_pat_i_key_chld;
        //     10  ws-pat-con-nbr pic 99.
        private int ws_pat_con_nbr_chld;
        //     10  ws-pat-i-nbr pic 9(12).
        private long ws_pat_i_nbr_chld;
        //     10  filler pic x.
        private string ws_filler4;
        // 05  ws-pat-health-nbr pic 9(10).
        private long ws_pat_health_nbr;
        // 05  ws-pat-version-cd pic xx.
        private string ws_pat_version_cd;
        // 05  ws-pat-health-65-ind pic x.
        private string ws_pat_health_65_ind;
        // 05  ws-pat-expiry-date.
        private string ws_pat_expiry_date_grp;
        //     10  ws-pat-expiry-yy pic 99.
        private int ws_pat_expiry_yy_chld;
        //     10  ws-pat-expiry-mm pic 99.
        private int ws_pat_expiry_mm_chld;
        // 05  ws-pat-prov-cd pic xx.
        private string ws_pat_prov_cd;

        // 05  ws-subscr-addr1 pic x(30).
        private string ws_subscr_addr1;
        // 05  ws-subscr-addr2 pic x(30).
        private string ws_subscr_addr2;
        // 05  ws-subscr-addr3 pic x(30).
        private string ws_subscr_addr3;
        // 05  ws-subscr-prov-cd pic x(2).
        private string ws_subscr_prov_cd;

        // 05  ws-subscr-postal-cd pic x(10).
        private string ws_subscr_postal_cd;

        // 05  ws-subscr-postal-cd-r redefines  ws-subscr-postal-cd.
        private string ws_subscr_postal_cd_r_grp;
        //     10  ws-subscr-post-code1.
        private string ws_subscr_post_code1_grp;
        //         15  ws-subscr-post-cd1 pic x.
        private string ws_subscr_post_cd1_chld;
        //         15  ws-subscr-post-cd2 pic 9.
        private string ws_subscr_post_cd2_chld;
        //         15  ws-subscr-post-cd3 pic x.
        private string ws_subscr_post_cd3_chld;

        //     10  ws-subscr-post-code2.
        private string ws_subscr_post_code2_grp;
        //         15  ws-subscr-post-cd4 pic 9.
        private string ws_subscr_post_cd4_chld;
        //         15  ws-subscr-post-cd5 pic x.
        private string ws_subscr_post_cd5_chld;
        //         15  ws-subscr-post-cd6 pic 9.
        private string ws_subscr_post_cd6_chld;
        //     10  filler pic x(4).
        private string ws_filler2;
        // 05  ws-subscr-msg-data.
        private string ws_subscr_msg_data_grp;
        //     10  ws-subscr-msg-nbr pic xx.
        private string ws_subscr_msg_nbr;
        //     10  ws-subscr-dt-msg-no-eff-to pic 9(8).
        private int ws_subscr_dt_msg_no_eff_to;
        //     10  ws-subscr-dt-msg-no-eff-to-r redefines ws-subscr-dt-msg-no-eff-to.
        private string ws_subscr_dt_msg_no_eff_to_r_grp;
        //         15  ws-subscr-dt-msg-no-eff-to-yy pic 9(4).
        private int ws_subscr_dt_msg_no_eff_to_yy_chld;
        //         15  ws-subscr-dt-msg-no-eff-to-mm pic 99.
        private int ws_subscr_dt_msg_no_eff_to_mm_chld;
        //         15  ws-subscr-dt-msg-no-eff-to-dd pic 99.
        private int ws_subscr_dt_msg_no_eff_to_dd_chld;
        //     10  ws-subscr-dt-msg-no-eff-to-r1 redefines ws-subscr-dt-msg-no-eff-to-r pic x(8).                                                        
        private string ws_subscr_dt_msg_no_eff_to_r1;
        //     10  ws-subscr-date-last-statement pic 9(8).
        private int ws_subscr_date_last_statement;
        //     10  ws-subscr-date-last-stmnt-r  redefines ws-subscr-date-last-statement.
        private string ws_subscr_date_last_stmnt_r_grp;
        //         15  ws-subscr-date-last-stmnt-yy pic 9(4).
        private int ws_subscr_date_last_stmnt_yy_chld;
        //         15  ws-subscr-date-last-stmnt-mm pic 99.
        private int ws_subscr_date_last_stmnt_mm_chld;
        //         15  ws-subscr-date-last-stmnt-dd pic 99.
        private int ws_subscr_date_last_stmnt_dd_chld;
        // 05  ws-subscr-auto-update pic x.
        private string ws_subscr_auto_update;
        // 05  ws-pat-last-mod-by pic x(5).
        private string ws_pat_last_mod_by;
        // 05  ws-pat-date-last-elig-mailing pic 9(8).
        private int ws_pat_date_last_elig_mailing;
        // 05  ws-pat-date-last-elig-maint pic 9(8).
        private int ws_pat_date_last_elig_maint;
        // 05  ws-pat-last-birth-date pic 9(8).
        private int ws_pat_last_birth_date;
        // 05  ws-pat-last-birth-date-r redefines ws-pat-last-birth-date.
        private string ws_pat_last_birth_date_r_grp;
        //     10 ws-pat-last-birth-date-yy pic 9(4).
        private int ws_pat_last_birth_date_yy_chld;
        //     10 ws-pat-last-birth-date-mm pic 9(2).
        private int ws_pat_last_birth_date_mm_chld;
        //     10 ws-pat-last-birth-date-dd pic 9(2).
        private int ws_pat_last_birth_date_dd_chld;
        // 05  ws-pat-last-version-cd pic x(2).
        private string ws_pat_last_version_cd;
        // 05  ws-pat-mess-code pic x(3).   
        private string ws_pat_mess_code;
        // 05  ws-pat-country pic x(1).
        private string ws_pat_country;

        // 05  ws-pat-no-of-letter-sent pic 99.
        private int ws_pat_no_of_letter_sent;
        // 05  ws-pat-dialysis pic x(1).
        private string ws_pat_dialysis;
        // 05  ws-pat-ohip-validiation-status pic x.   
        private string ws_pat_ohip_validiation_status;
        // 05  ws-pat-obec-status pic x(1).
        private string ws_pat_obec_status;


        private string ws_save_id_no_grp;
        private string ws_save_id_no_alpha;
        private string ws_save_id_no_first_8_digits_grp;
        private int ws_save_id_no_yy_chld;
        private int ws_save_id_no_mm_chld;
        private int ws_save_id_no_5_6_digit_chld;
        private int ws_save_id_no_7_digit_chld;
        private int ws_save_id_no_8_digit_chld;
        private string ws_save_id_no_9_digit;

        private string ws_stjoe_id_no_grp;
        private string ws_stjoe_id_no_alpha_chld = "J";
        private int ws_stjoe_id_no_pos_1_chld;
        private string ws_stjoe_id_no_pos_2_10_chld;

        private string ws_xx = "  ";

        private string error_message_table_grp;
        private string error_messages_grp;
        private string[] err_msg = {"", "FUNC CODE MUST BE AA-ADD OR (C1 OR C2)-CHANGE",
                                     "HEALTH NBR,OHIP NO AND ID NO CAN'T BE ALL BLANK",
                                     "SURNAME CAN'T BE BLANK ",
                                     "Version Code can't be NUMERIC",
                                     "FIRST NAME CAN'T BE BLANK",
                                     "HEALTH NBR,OHIP NO CAN'T BE ALL BLANK",
                                     "INVALID YEAR, MUST BE NUMERIC",
                                     "INVALID MONTH, MUST BE NUMERIC",
                                     "BIRTH MONTH MUST BE BETWEEN 1 TO 12 INCLUSIVE",
                                     "INVALID DAY, MUST BE NUMERIC",
                                     "BIRTH DAY MUST BE BETWEEN 1 TO 31 INCLUSIVE",
                                     "FEB. CAN'T HAVE MORE THAN 29 DAYS",
                                     "APR.,JUNE,SEPT.,NOV., ONLY HAVE 30 DAYS",
                                      "SEX MUST BE M-MALE  OR  F-FEMALE",
                                      "MRN contains characters where numerics expected",
                                      "MRN contains numerics where spaces expected",
                                      "Version Code must be ALPHA",
                                      "can be re-used",
                                     "can be re-used",
                                     "can be re-used",
                                     "STREET ADDRESS  CAN'T BE BLANK",
                                     "CITY CAN'T BE BLANK",
                                     "Birth date can't be  >  run date or birth year <  1880",
                                     "PROV CAN'T BE BLANK",
                                     "INVALID PROVINCE - NOT FOUND FROM THE TABLE",
                                     "NOT changing incoming VERSION Code because = OLD RMA value",
                                     "NOT changing incoming  Birth Date  because = OLD RMA value",
                                     "SPARE                       ",
                                     "OHIP NUMBER MUST BE NUMERIC",
                                     "INVALID OHIP NUMBER",
                                     "HEALTH NUMBER MUST BE NUMERIC",
                                     "ADDING PATIENT BUT PATIENT HEALTH NBR ALREADY EXISTS",
                                     "INVALID HEALTH CARE NUMBER",
                                     "FIRST RECORD IS C2, IT IS NOT ALLOWED",
                                     "Non St. Joe chart nbr must have 9 digits after the prefix",
                                     "PATIENT OHIP KEY ALREADY EXISTS CAN'T ADD PATIENT",
                                     "HEALTH NBR CAN'T EXIST WITH NON-ONTARIO PATIENT",
                                     "PATIENT CHART KEY ALREADY EXISTS CAN'T ADD PATIENT ",
                                     "St. Joe chart nbr must have 10 digits after the prefix 'J'",
                                     "Non-Ontario patients MUST have a Registration Number     ",
                                     "The ACRONYM key EXISTS, but database corrupted in AA record",
                                     "Adding a HEALTH CARE Number to existing patient (was #66)",
                                     "Adding a new OHIP Nbr to existing patient (previously #77)",
                                     "Adding a new CHART Nbr to existing patient (previously #88)",
                                     "FYI only - new patient added (previously message #99)",
                                     "chart nbr prefix must be M,K,H,0,J,D,E,F,W,ZB",
                                    "chart nbr must be 9 digits after the prefix",
                                    "chart nbr is longer than 11 characters",
                                    "Henderson chart nbr must start either H002 or H003",
                                    "ATTEMPTING TO CHANGE HEALTH NBR- THIS NUMBER ALREADY ON FILE",
                                    "THE NEW ACRONYM (C2) EXISTS, BUT DATABASE CORRUPTED",
                                    "General chart nbr must start either 0001 or 0005",
                                    "C1 KEY NOT EXIST, ATTEMPTING TO ADD C2 CHART BUT IT EXISTS",
                                    "** ERROR ** - DUPLICATE IKEY - CONTACT DYAD IMMEDIATELY",
                                    "New Patient ADDED to Patient Master (previously #99)",
                                    "Patient BIRTH DATE changed",
                                    "Patient VERSION CODE changed",
                                    "Patient BIRTH DATE and VERSION CODE changed",
                                    "Patient OTHER THAN the Birth Date/Version Code changed" };
        private string error_messages_r_grp;
        //private string[] err_msg =  new string[60];
        private int ws_max_nbr_messages_in_tbl = 59;

        private string err_msg_table_grp;
        private string err_no;
        private string err_filler;
        private string err_msg_comment;

        private string prov_table_grp;
        private string province_grp;
        /* private string filler = "ALBTAB";
         private string filler = "NFLDNL";
         private string filler = "SASKSK";
         private string filler = "MAN MB";
         private string filler = "NWT NT";
         private string filler = "ONT ON";
         private string filler = "PEI PE";
         private string filler = "QUE PQ";
         private string filler = "YUK YT";
         private string filler = "BC  BC";
         private string filler = "NB  NB";
         private string filler = "NS  NS";
         private string filler = "OTH OT"; */
        private string province_r_grp;
        private string[] prov = new string[14];
        //private string[] old_prov =  new string[14];

        private string[] old_prov = {"", "ALBT",
                                         "NFLD",
                                         "SASK",
                                         "MAN ",
                                         "NWT ",
                                         "ONT ",
                                         "PEI ",
                                         "QUE ",
                                         "YUK ",
                                         "BC  ",
                                         "NB  ",
                                         "NS  ",
                                         "OTH " };

        private string[] new_prov = {"",
                                     "AB",
                                     "NL",
                                     "SK",
                                     "MB",
                                     "NT",
                                     "ON",
                                     "PE",
                                     "PQ",
                                     "YT",
                                     "BC",
                                     "NB",
                                     "NS",
                                     "OT" };

        // private string h1_head_grp;
        // private string filler = "RU011A";
        // private string filler = "Patient Transfer File - Upload ERROR Report";
        // private string filler = "RUN DATE :";
        private string h1_run_date;
        // private string filler = "";
        // private string filler = "  page";
        private int h1_page_no;

        /* private string h2_head_grp;
         private string filler = "* FUNC CD";
         private string filler = "last  name";
         private string filler = "first  name";
         private string filler = "BIRTH DTE SEX";
         private string filler = "ID NO         OHIP  NO";
         private string filler = " HEALTH NUMBER             "; */

        // private string h3_head_grp;
        //private string filler = "RU011B";
        //private string filler = "Patient Transfer File - Upload  AUDIT Report";
        //private string filler = "RUN DATE :";
        private string h3_run_date;
        //private string filler = "";
        //private string filler = "  page";
        private int h3_page_no;

        // private string h4_head_grp;
        // private string filler = "RU011C";
        // private string filler = "Patient Transfer File -  Update EXCEPTIONS Report";
        // private string filler = "RUN DATE :";
        private string h4_run_date;
        // private string filler = "";
        // private string filler = "  page";
        private int h4_page_no;

        private bool isRetrieving;

        // private string h5_head_grp;
        // private string filler = "";
        // private string filler = "health/acct'ing #";
        // private string filler = "birth date";
        // private string filler = "version cd";
        // private string filler = "";

        // private string l1_line_grp;
        // private string filler;
        private string l1_func_cd;
        //private string filler;
        private string l1_last_name;
        // private string filler;
        private string l1_first_name;
        // private string filler;
        private string l1_date_grp;
        private int l1_yy;
        private string l1_slash1;
        private int l1_mm;
        private string l1_slash2;
        private int l1_dd;
        //private string filler;
        private string l1_sex;
        //private string filler;
        private string l1_id_no;
        //private string filler;
        private string l1_ohip_no;
        //private string filler;
        private string l1_health_nbr;
        //private string filler;

        //private string l2_line_grp;
        //private string filler = "  ADDRESS: ";
        private string l2_street_addr;
        // private string filler = ", ";
        private string l2_city;
        //private string filler = ", ";
        private string l2_prov;
        //private string filler = ", ";
        private string l2_postal_cd;
        //private string filler = "    PHONE: ";
        private string l2_phone_no;
        //private string filler = "  VERSION:  ";
        private string l2_version_cd;
        //private string filler = "   MESSAGE: ";
        private string l2_mess_id;

        private string l3_line;

        // private string l4_line_grp;
        private string l4_title;
        private int l4_ctr;
        // private string filler;

        //private string l5_line_grp;
        //private string filler = "TAPE VERSION CODE:";
        private string l5_tp_pat_version_cd;
        //private string filler = "          RMA VERSION CODE:";
        private string l5_ws_pat_version_cd;
        //private string filler = "          CHART NUMBER:";
        private string l5_chart_nbr;
        //private string filler = "    MESSAGE ID: ";
        private string l5_mess_id;

        //private string prt_det_line1_grp;
        private string prt_lit1 = "";
        private string prt_ohip_health_nbr;
        private string filler = "";
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

        // private string prt_det_line2_grp;
        private string prt_lit2 = "";
        private int disk_doctor_nbr;
        private string disk_account_id = "";
        // private string filler = "";
        private int disk_birth_date_yy;
        // private string filler = "/";
        private int disk_birth_date_mm;
        // private string filler = "/";
        private int disk_birth_date_dd;
        // private string filler = "";
        private string disk_version_cd;
        // private string filler = "";
        private string disk_prov_cd;
        // private string filler = "";

        private int save_con_nbr;
        private int save_i_nbr;

        //private string ws_nbr_val_grp;
        private int ws_nbr_to_b_val;
        private string ws_nbr_to_b_val_r_grp;
        private int[] ws_nbr_to_b_val_1_8 = new int[9];
        //private string ws_sum_1_2_val_grp;
        //private string[] ws_sum_1_2_val_r =  new string[8];
        //private int[] ws_sum_1_2_val_r1 =  new int[8];
        //private string[] ws_sum_1_2_val_r1_r =  new string[8];
        //private int[,] ws_sum_1 =  new int[8,3];
        //private string[] ws_sum_1_2_val_r_sep =  new string[8];
        //private int[,] ws_sum_1_2 =  new int[8,8];

        //private string ws_hc_nbr_val_grp;
        //private long ws_hc_nbr_to_b_val;
        private string ws_hc_nbr_to_b_val_r_grp;
        //private int[] ws_hc_nbr_to_b_val_1_10 =  new int[11];
        //private string ws_hc_sum_1_2_val_grp;
        //private string[] ws_hc_sum_1_2_val_r =  new string[10];
        private int[] ws_hc_sum_1_2_val_r1 = new int[10];
        //private string[] ws_hc_sum_1_2_val_r1_r =  new string[10];
        private int[,] ws_hc_sum_1 = new int[10, 3];
        //private string[] ws_hc_sum_1_2_val_r_sep =  new string[10];
        private int[] ws_hc_sum_1_2 = new int[10];

        private string ws_tp_pat_mstr_rec_grp;
        //private string ws_tp_pat_func_code;
        //private string ws_tp_pat_last_name_grp;
        //private string ws_tp_pat_last_name_6;
        //private string ws_tp_pat_last_name_18;
        //private string ws_tp_pat_first_name_grp;
        //private string ws_tp_pat_first_name_3;
        //private string ws_tp_pat_first_name_21;
        //private string ws_tp_pat_birth_date;
        private string ws_tp_pat_birth_date_r_grp;
        //private int ws_tp_pat_birth_yy;
        private string ws_tp_pat_birth_yy_r_grp;
        //private int ws_tp_pat_birth_yy_first_2;
        //private int ws_tp_pat_birth_yy_last_2;
        //private string ws_tp_pat_slash1;
        //private int ws_tp_pat_birth_mm;
        //private string ws_tp_pat_slash2;
        //private int ws_tp_pat_birth_dd;
        //private string ws_tp_pat_sex;
        //private string ws_tp_pat_id_no;
        private string ws_tp_pat_id_no_r_grp;
        //private string ws_tp_pat_id_no_first_8_digits_grp;
        private string ws_tp_pat_id_no_site;
        private int ws_tp_pat_id_no_yy;
        private int ws_tp_pat_id_no_mm;
        private string ws_tp_pat_id_no_5_digit;
        private int ws_tp_pat_id_no_6_7_digit;
        private int ws_tp_pat_id_no_8_digit;
        private string ws_tp_pat_id_no_reminder;
        private string ws_tp_pat_id_no_last_digit;
        //private string ws_tp_pat_id_no_r2_grp;
        private string ws_tp_pat_id_no_alpha;
        //private string ws_tp_pat_id_no_9_digits_grp;
        private int ws_tp_pat_id_no_1_3_digits;
        private int ws_tp_pat_id_no_4_9_digits;
        private string ws_tp_pat_id_no_10_digit;
        private string ws_tp_pat_id_no_filler;
        //private string ws_tp_pat_street_addr;
        //private string ws_tp_pat_street_addr2;
        //private string ws_tp_pat_city;
        //private string ws_tp_pat_prov;
        //private string ws_tp_pat_postal_code;
        //private string ws_tp_pat_postal_code_r_grp;
        private string ws_tp_pat_postal_code_1;
        private string ws_tp_pat_postal_code_2;
        private string ws_tp_pat_postal_code_3;
        private string ws_tp_pat_postal_code_4;
        private string ws_tp_pat_postal_code_5;
        private string ws_tp_pat_postal_code_6;
        //private string ws_tp_pat_phone_no;
        private string ws_tp_pat_ohip_no;
        //private string ws_tp_pat_health_nbr;
        //private string ws_tp_pat_version_cd_grp;
        //private string ws_tp_pat_version_cd_1;
        //private string ws_tp_pat_version_cd_2;
        //private string ws_tp_pat_health_65_ind;
        //private string ws_tp_pat_expiry_date_grp;
        //private int ws_tp_pat_expiry_mm;
        //private int ws_tp_pat_expiry_yy;
        //private string filler;

        private string ws_pat_mstr_rec_grp;
        //private string ws_pat_acronym_grp;
        //private string ws_pat_acronym_first6;
        //private string ws_pat_acronym_last3;
        //private string ws_pat_ohip_mmyy_grp;
        //private string ws_pat_ohip_out_prov_grp;
        //private int ws_pat_ohip_nbr;
        //private string ws_pat_ohip_nbr_r_alpha;
        private string ws_pat_ohip_nbr_MB_def_grp;
        //private int ws_pat_ohip_nbr_MB;
        //private string filler;
        //private string ws_pat_ohip_nbr_NT_def_grp;
        //private string ws_pat_ohip_nbr_NT_1_char;
        //private int ws_pat_ohip_nbr_NT;
        //private int ws_pat_mm;
        //private int ws_pat_yy;
        //private string filler;
        private string ws_pat_ohip_mmyy_r_grp;
        //private string ws_pat_direct_alpha_grp;
        //private string ws_pat_alpha1;
        //private string ws_pat_alpha2_3;
        //private string ws_pat_direct_yy;
        //private string ws_pat_direct_mm;
        //private string ws_pat_direct_dd;
        //private string ws_pat_direct_filler;
        //private string ws_pat_chart_nbr_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;
        //private string ws_pat_chart_nbr_2_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;
        //private string ws_pat_chart_nbr_3_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;
        //private string ws_pat_chart_nbr_4_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;
        //private string ws_pat_chart_nbr_5_grp;
        //private string pat_chart_1st_char;
        //private string pat_chart_remainder;
        //private string ws_pat_surname;
        //private string ws_pat_surname_r_grp;
        //private string ws_pat_surname_first6;
        //private string ws_pat_surname_last19;
        //private string ws_pat_surname_rr_grp;
        //private string ws_pat_surname_first3;
        //private string ws_pat_surname_last22;
        //private string ws_pat_given_name;
        //private string ws_pat_given_name_r_grp;
        //private string ws_pat_given_name_first3;
        //private string ws_pat_given_name_last14;
        //private string ws_pat_given_name_rr_grp;
        //private string ws_pat_given_name_first1;
        //private string filler;
        //private string ws_pat_init_grp;
        //private string ws_pat_init1;
        //private string ws_pat_init2;
        //private string ws_pat_init3;
        //private string ws_pat_location_field_grp;
        //private string ws_pat_location_field_1_3;
        //private string filler;
        //private string ws_pat_last_doc_nbr_seen;
        //private int ws_pat_birth_date;
        //private string ws_pat_birth_date_r_grp;
        //private int ws_pat_birth_date_yy;
        //private string ws_pat_birth_date_yy_r_grp;
        //private int ws_pat_birth_date_yy_12;
        //private int ws_pat_birth_date_yy_34;
        // private int ws_pat_birth_date_mm;
        // private int ws_pat_birth_date_dd;
        //private int ws_pat_date_last_maint;
        //private string ws_pat_date_last_maint_r_grp;
        //private int ws_pat_date_last_maint_yy;
        //private int ws_pat_date_last_maint_mm;
        //private int ws_pat_date_last_maint_dd;
        //private int ws_pat_date_last_visit;
        //private string ws_pat_date_last_visit_r_grp;
        //private int ws_pat_date_last_visit_yy;
        //private int ws_pat_date_last_visit_mm;
        //private int ws_pat_date_last_visit_dd;
        //private int ws_pat_date_last_admit;
        //private string ws_pat_date_last_admit_r_grp;
        //private int ws_pat_date_last_admit_yy;
        //private int ws_pat_date_last_admit_mm;
        //private int ws_pat_date_last_admit_dd;
        //private string ws_pat_phone_nbr_grp;
        //private int ws_pat_phone_nbr_first3;
        //private int ws_pat_phone_nbr_last4;
        //private string ws_pat_phone_nbr_remainder;
        //private int ws_pat_total_nbr_visits;
        //private int ws_pat_total_nbr_claims;
        //private string ws_pat_sex;
        //private string ws_pat_in_out;
        //private int ws_pat_nbr_outstanding_claims;
        //private string ws_key_pat_mstr_grp;
        //private string ws_pat_i_key;
        //private int ws_pat_con_nbr;
        //private int ws_pat_i_nbr;
        //private string filler;
        //private int ws_pat_health_nbr;
        // private string ws_pat_version_cd_grp;
        // private string ws_pat_version_cd_1;
        //private string ws_pat_version_cd_2;
        //private string ws_pat_health_65_ind;
        //private string ws_pat_expiry_date_grp;
        //private int ws_pat_expiry_yy;
        //private int ws_pat_expiry_mm;
        //private string ws_pat_prov_cd;
        //private string ws_subscr_addr1;
        //private string ws_subscr_addr2;
        //private string ws_subscr_addr3;
        //private string ws_subscr_prov_cd;
        //private string ws_subscr_postal_cd;
        //private string ws_subscr_postal_cd_r_grp;
        //private string ws_subscr_post_code1_grp;
        //private string ws_subscr_post_cd1;
        //private int ws_subscr_post_cd2;
        //private string ws_subscr_post_cd3;
        //private string ws_subscr_post_code2_grp;
        //private int ws_subscr_post_cd4;
        //private string ws_subscr_post_cd5;
        //private int ws_subscr_post_cd6;
        //private string filler;
        //private string ws_subscr_msg_data_grp;
        //private string ws_subscr_msg_nbr;
        //private int ws_subscr_dt_msg_no_eff_to;
        //private string ws_subscr_dt_msg_no_eff_to_r_grp;
        //private int ws_subscr_dt_msg_no_eff_to_yy;
        //private int ws_subscr_dt_msg_no_eff_to_mm;
        //private int ws_subscr_dt_msg_no_eff_to_dd;
        //private string ws_subscr_dt_msg_no_eff_to_r1;
        //private int ws_subscr_date_last_statement;
        //private string ws_subscr_date_last_stmnt_r_grp;
        //private int ws_subscr_date_last_stmnt_yy;
        //private int ws_subscr_date_last_stmnt_mm;
        //private int ws_subscr_date_last_stmnt_dd;
        //private string ws_subscr_auto_update;
        //private string ws_pat_last_mod_by;
        //private int ws_pat_date_last_elig_mailing;
        //private int ws_pat_date_last_elig_maint;
        //private int ws_pat_last_birth_date;
        //private string ws_pat_last_birth_date_r_grp;
        //private int ws_pat_last_birth_date_yy;
        //private int ws_pat_last_birth_date_mm;
        //private int ws_pat_last_birth_date_dd;
        //private string ws_pat_last_version_cd;
        //private string ws_pat_mess_code;
        //private string ws_pat_country;
        //private int ws_pat_no_of_letter_sent;
        //private string ws_pat_dialysis;
        //private string ws_pat_ohip_validiation_status;
        //private string ws_pat_obec_status;
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

        //private string run_date_grp;
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

        //private string run_time_grp;
        private int run_hrs;
        // private string filler = ":";
        private int run_min;
        // private string filler = ":";
        private int run_sec;

        private string endOfJob = "End of Job";

        private int pat_mstr_row_ctr;
        private int ctr;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "12",Col = 16,Data1 = "PATIENT TRANSFER NOW BEING PROCESSED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 1,Data1 = "PROGRAM U011 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 10,Data1 = "AUDIT REPORTS ARE IN FILES - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 43,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_a",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 51,Data1 = "&",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 54,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_b",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 65,Data1 = "&",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 68,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(8)",MaxLength = 8,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name_c",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

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
            status_file = status_tp_pat_mstr;
            //     display file-status-display.;
            //     stop " ".;
            status_file = status_cobol_tp_pat_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_tp_pat_mstr_file_out_section()
        {

            //     use after standard error procedure on tp-pat-mstr-out.;
        }

        private async Task err_tp_pat_mstr_out()
        {

            //     stop "ERROR IN ACCESSING TP PATIENT OUT FILE".;
            status_file = status_tp_pat_mstr_out;
            //     display file-status-display.;
            //     stop " ".;
            status_file = status_cobol_tp_pat_mstr_out;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_pat_mstr_file_section()
        {

            //     use after standard error procedure on pat-mstr.;
        }

        private async Task err_pat_mstr()
        {

            //     stop "ERROR IN ACCESSING PATIENT MASTER I-KEY".;
            status_file = status_pat_mstr;
            //     display file-status-display.;
            //     stop " ".;
            // status_file = status_cobol_pat_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_iconst_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private async Task err_iconst_mstr()
        {

            //     stop "ERROR IN ACCESSING CONSTANT MASTER".;
            status_file = status_iconst_mstr;
            //     display file-status-display.;
            //     stop run.;
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
            objTp_pat_mstr_rec_out = new Tp_pat_mstr_rec_out();
            objTp_pat_mstr_rec_out_File = new WriteFile(Directory.GetCurrentDirectory() + "\\" + tp_patient_file_name_out);
            Tp_pat_mstr_rec_out_Collection = new ObservableCollection<Tp_pat_mstr_rec_out>();

            objRpt_rec_a = new Rpt_rec_a();
            Rpt_rec_a_Collection = new ObservableCollection<Rpt_rec_a>();

            objRpt_rec_b = new Rpt_rec_b();
            Rpt_rec_b_Collection = new ObservableCollection<Rpt_rec_b>();

            objRpt_rec_c = new Rpt_rec_c();
            Rpt_rec_c_Collection = new ObservableCollection<Rpt_rec_c>();

            objTp_pat_mstr_rec = null;
            objTp_pat_mstr_rec = new Tp_pat_mstr_rec1();

            Tp_pat_mstr_rec_Collection = null;
            Tp_pat_mstr_rec_Collection = base.Read_meditech_patient_file_u011_SequentialFile();

            objPat_mstr_rec = new F010_PAT_MSTR();
            Pat_mstr_rec_Collection = new ObservableCollection<F010_PAT_MSTR>();

            objF011_pat_mstr_elig_history_rec = new F011_PAT_MSTR_ELIG_HISTORY();
            F011_pat_mstr_elig_history_rec_Collection = new ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>();

            objPat_id_rec = new F086_PAT_ID();
            Pat_id_rec_Collection = new ObservableCollection<F086_PAT_ID>();

            objIconst_mstr_rec = new ICONST_MSTR_REC();
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5();
            Constants_mstr_rec_5_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_5>();

            objAudit_File_a = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_a);
            objAudit_File_b = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_b);
            objAudit_File_c = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name_c);
           
        }

        public async Task mainline()
        {
            Util.Trakker(++ctr, "mainline");
            try
            {
                await initialize_objects();

                //     perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit;
                //             until eof-tape.;

                do
                {
                    await ab0_processing();
                    await ab0_99_exit();
                } while (!eof_tp_pat_mstr.Equals(eof_tape));


                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_99_exit();

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
                if (objAudit_File_a != null)
                {
                    objAudit_File_a.Close();
                    objAudit_File_a = null;
                }

                if (objAudit_File_b != null)
                {
                    objAudit_File_b.Close();
                    objAudit_File_b = null;
                }

                if (objAudit_File_c != null)
                {
                    objAudit_File_c.Close();
                    objAudit_File_c = null;
                }

                if (objTp_mstr_file_out != null)
                {
                    objTp_mstr_file_out.CloseOutputFile();
                    objTp_mstr_file_out = null;
                }

                if (objTp_pat_mstr_rec_out_File != null)
                {
                    objTp_pat_mstr_rec_out_File.CloseOutputFile();
                    objTp_pat_mstr_rec_out_File = null;
                }
            }
        }

        private async Task aa0_initialization()
        {
            Util.Trakker(++ctr, "aa0_initialization");

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

            //     perform y2k-default-sysdate         thru y2k-default-sysdate-exit.;
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
            // 	        iconst-mstr;
            // 	     	pat-elig-history.;
            //     open output  tp-pat-mstr-out.;
            //     open extend corrected-pat.;
            //     open output audit-file-a;
            //     		audit-file-b;
            //     		audit-file-c.;
            //counters = 0;
            ctr_pat_mstr_no_update = 0;
            ctr_tp_pat_mstr_reads = 0;
            ctr_pat_mstr_writes = 0;
            ctr_pat_mstr_out_writes = 0;
            ctr_write_corrected_pat = 0;
            ctr_good_c1 = 0;
            ctr_pat_mstr_rewrites = 0;
            ctr_write_pat_elig_hist = 0;
            ctr_error_rpt_writes = 0;
            ctr_warnings_rpt_writes = 0;
            ctr_audit_rpt_writes = 0;
            ctr_exception_rpt_writes = 0;
            ctr_page_a = 0;
            ctr_page_b = 0;
            ctr_page_c = 0;
            ctr_reject = 0;
            ctr_warning = 0;
            ctr_exception = 0;
            ctr_audit = 0;
            ctr_update = 0;


            //     add 1 				to ctr-page-a.;
            ctr_page_a++;

            h1_run_date = await run_date_grp();
            h4_run_date = await run_date_grp();
            h3_run_date = await run_date_grp();

            h1_page_no = ctr_page_a;
            //     write rpt-rec-a from h1-head after advancing page.;
            objRpt_rec_a.Rpt_rec_a1 = await h1_head_grp();
            objAudit_File_a.PageBreak();
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);


            objRpt_rec_a.Rpt_rec_a1 = "";
            //     write rpt-rec-a after advancing 2 lines.;
            objAudit_File_a.print(true);
            objAudit_File_a.print(true); // added
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);


            //     perform aa1-print-message-table  	thru aa1-99-exit;
            //             varying sub from 1 by 1;
            //             until sub > ws-max-nbr-messages-in-tbl.;

            sub = 1;
            do
            {
                await aa1_print_message_table();
                await aa1_99_exit();
                sub++;
            } while (sub <= ws_max_nbr_messages_in_tbl);


            //objConstants_mstr_rec_5.const_rec_5_rec_nbr = 5;
            //     read iconst-mstr;
            // 	invalid key;
            // 		go to err-iconst-mstr.;
            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5
            {
                WhereConst_rec_nbr = 5
            }.Collection().FirstOrDefault();

            if (objConstants_mstr_rec_5 == null)
            {
                await err_iconst_mstr();
                return;
            }


            //hold_iconst_con_nbr = const_con_nbr[25];
            //hold_iconst_nx_ikey = const_nx_avail_pat[25];

            hold_pat_ikey_grp = "I";
            hold_iconst_con_nbr_chld = Util.NumInt(CONST_CON_NBR_GET(objConstants_mstr_rec_5, 25));
            hold_iconst_nx_ikey_chld = Util.NumInt(CONST_NX_AVAIL_PAT_GET(objConstants_mstr_rec_5, 25));


            l3_line = "-".PadRight(132, '-');
            ctr_reject = 20;
            ctr_warning = 20;
            ctr_exception = 20;
            ctr_audit = 20;

            eof_tp_pat_mstr = "N";

            //     perform ya0-read-next-tape          thru ya0-99-exit.;
            await ya0_read_next_tape();
            await ya0_99_exit();
        }

        private async Task aa0_99_exit()
        {
            Util.Trakker(++ctr, "aa0_99_exit");
            //     exit.;
        }

        private async Task aa1_print_message_table()
        {
            Util.Trakker(++ctr, "aa1_print_message_table");

            objRpt_rec_a.Rpt_rec_a1 = "";
            err_msg_table_grp = "";
            err_no = "";
            err_filler = "";
            err_msg_comment = "";

            err_no = Util.Str(sub);
            err_filler = ":";
            err_msg_comment = err_msg[sub];

            //     write rpt-rec-a from err-msg-table after advancing 1 line.;
            err_msg_table_grp = Util.Str(err_no).PadLeft(2, '0').PadRight(4) + Util.Str(err_filler).PadRight(3) + Util.Str(err_msg_comment).PadRight(64);
            objRpt_rec_a.Rpt_rec_a1 = err_msg_table_grp;
            objAudit_File_a.print(true);   // added
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
        }

        private async Task aa1_99_exit()
        {
            Util.Trakker(++ctr, "aa1_99_exit");

            //     exit.;
        }

        private async Task ab0_processing()
        {
            Util.Trakker(++ctr, "ab0_processing");

            // if tp-pat-func-code = "C2" then;            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2"))
            {
                // 	   add 1					to ctr-error-rpt-writes;
                ctr_error_rpt_writes++;
            }
            // else;
            else
            {
                //     	perform ba0-preliminary-edit-patient 	thru ba0-99-exit;
                string retVal =  await ba0_preliminary_edit_patient();
                if (Util.Str(retVal).Equals("ba0_99_exit")) goto _ba0_99_exit;
                await ba0_10_cont_edit_patient();
                _ba0_99_exit:
                await ba0_99_exit();

                //     	if invalid-record and tp-pat-func-code = "C1" then;            
                if (Util.Str(edit_flag).Equals(invalid_record) && Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).Equals("C1"))
                {
                    //           ws_tp_pat_mstr_rec = objTp_pat_mstr_rec.tp_pat_mstr_rec;
                    await move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec();
                    //           perform xb0-write-ws-error-report   thru xb0-99-exit;
                    await xb0_write_ws_error_report();
                    await xb0_99_exit();
                    //           perform ya0-read-next-tape		thru ya0-99-exit;
                    await ya0_read_next_tape();

                    await ya0_99_exit();
                    // 	         if tp-pat-func-code = "C2" then;            
                    if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2"))
                    {
                        // 		           add 1	to ctr-error-rpt-writes;
                        ctr_error_rpt_writes++;
                    }
                    // 	         else;
                    else
                    {
                        // 		           perform ba0-preliminary-edit-patient thru ba0-99-exit;
                        await ba0_preliminary_edit_patient();
                        await ba0_10_cont_edit_patient();
                        await ba0_99_exit();
                        // 	             if valid-record then            
                        if (Util.Str(edit_flag).Equals(valid_record))
                        {
                            //                     ws_tp_pat_mstr_rec = objTp_pat_mstr_rec.tp_pat_mstr_rec;
                            await move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec();
                            // 		               if tp-pat-func-code = "AA" then            
                            if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA"))
                            {
                                // 		                   perform ca0-add-mode-processing thru ca0-99-exit;            
                                await ca0_add_mode_processing();
                                await ca0_99_exit();
                            }
                            // 		       	       else if tp-pat-func-code = "C1" then            
                            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C1"))
                            {
                                //  		    	       perform da0-change-mode-processing thru da0-99-exit;
                                await da0_change_mode_processing();
                                await da0_99_exit();
                            }
                            // 			           else;
                            else
                            {
                                // 			               next sentence;
                            }
                        }
                        // 		          else if tp-pat-func-code = "AA" then            
                        else if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA"))
                        {
                            // 		    	       perform xa0-write-tp-error-report  	thru xa0-99-exit;
                            await xa0_write_tp_error_report();
                            await xa0_99_exit();
                        }
                        // 		          else;
                        else
                        {
                            // 			           add 1			to ctr-error-rpt-writes;            
                            ctr_error_rpt_writes++;
                        }
                    }
                }
                // 	   else if invalid-record then;            
                else if (Util.Str(edit_flag).Equals(invalid_record))
                {
                    // 	    	perform xa0-write-tp-error-report	thru xa0-99-exit;
                    await xa0_write_tp_error_report();
                    await xa0_99_exit();
                }
                // 	   else;
                else
                {
                    //          ws_tp_pat_mstr_rec = objTp_pat_mstr_rec.tp_pat_mstr_rec;
                    await move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec();
                    //        	if tp-pat-func-code = "AA" 	then      
                    if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA"))
                    {
                        //             perform ca0-add-mode-processing	thru ca0-99-exit;
                        await ca0_add_mode_processing();
                        await ca0_99_exit();
                    }
                    //          else if tp-pat-func-code = "C1" then            
                    else if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C1"))
                    {
                        //             	perform da0-change-mode-processing thru da0-99-exit.;
                        await da0_change_mode_processing();
                        await da0_99_exit();
                    }
                }
            }

            //     perform ya0-read-next-tape			thru ya0-99-exit.;
            await ya0_read_next_tape();
            await ya0_99_exit();
        }

        private async Task ab0_99_exit()
        {
            Util.Trakker(++ctr, "ab0_99_exit");
            //     exit.;
        }

        private async Task az0_end_of_job()
        {
            Util.Trakker(++ctr, "az0_end_of_job");

            //     perform az1-totals			thru az1-99-exit.;
            await az1_totals();
            await az1_99_exit();

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
            CONST_CON_NBR_SET(objConstants_mstr_rec_5, 25, hold_iconst_con_nbr_chld);

            //const_nx_avail_pat[25] = hold_iconst_nx_ikey;
            CONST_NX_AVAIL_PAT_SET(objConstants_mstr_rec_5, 25, hold_iconst_nx_ikey_chld);

            //     rewrite iconst-mstr-rec;
            // 	invalid key;
            // 		go to err-iconst-mstr.;

            try
            {
                objConstants_mstr_rec_5.RecordState = State.Modified;
                objConstants_mstr_rec_5.Submit();
            }
            catch (Exception e)
            {
                // go to err-iconst-mstr.;
                await err_iconst_mstr();
                return;
            }

            //     close tp-pat-mstr;
            // 	  pat-mstr;
            //    	  pat-elig-history;
            //           corrected-pat;
            // 	tp-pat-mstr-out;
            // 	  iconst-mstr;
            // 	  audit-file-a;
            //           audit-file-b;
            // 	  audit-file-c.;
        }

        private async Task az0_99_exit()
        {
            Util.Trakker(++ctr, "az0_99_exit");
            //     exit.;
        }

        private async Task az1_totals()
        {
            Util.Trakker(++ctr, "az1_totals");

            //     add 1			 	to ctr-page-b.;
            ctr_page_b++;

            h3_page_no = ctr_page_b;
            //     write rpt-rec-b from h3-head after advancing page.;
            objRpt_rec_b.Rpt_rec_b1 = await h3_head_grp();
            objAudit_File_b.PageBreak();
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //move "NUMBER OF RECORDS  ON TAPE = " 					to l4-title.;
            l4_title = "NUMBER OF RECORDS  ON TAPE = ";

            l4_ctr = ctr_tp_pat_mstr_reads;
            //     write rpt-rec-b			from l4-line after advancing 3 lines.;
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(true); // added
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1);

            await l4_line_grp(true);
            //  move "NUMBER OF PATIENTS ADDED = "					to l4-title.;
            l4_title = "NUMBER OF PATIENTS ADDED = ";
            l4_ctr = ctr_pat_mstr_writes;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true); 
            objAudit_File_b.print(true); 
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            await l4_line_grp(true);
            // move "NUMBER OF PATIENTS UPDATED = "					to l4-title.;
            l4_title = "NUMBER OF PATIENTS UPDATED = ";
            l4_ctr = ctr_pat_mstr_rewrites;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            await l4_line_grp(true);

            // "NUMBER OF CHANGES NOT DONE    = "  					to l4-title.;
            l4_title = "NUMBER OF CHANGES NOT DONE    = ";
            l4_ctr = ctr_pat_mstr_no_update;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            await l4_line_grp(true);
            // "NUMBER OF REJECTED RECORDS = "					to l4-title.;
            l4_title = "NUMBER OF REJECTED RECORDS = ";

            l4_ctr = ctr_error_rpt_writes;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            await l4_line_grp(true);
            //  "NUMBER OF GOOD C1  RECORDS = "					to l4-title.;
            l4_title = "NUMBER OF GOOD C1  RECORDS = ";
            l4_ctr = ctr_good_c1;
            //     write rpt-rec-b			from l4-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            await l4_line_grp(true);

            // move "NUMBER OF WARNINGS PRINTED = "					to l4-title.;
            l4_title = "NUMBER OF WARNINGS PRINTED = ";
            l4_ctr = ctr_warnings_rpt_writes;
            //     write rpt-rec-b			from l4-line after advancing 3 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            await l4_line_grp(true);
            // 	"NUMBER OF AUDITS   PRINTED = "				to l4-title.;
            l4_title = "NUMBER OF AUDITS   PRINTED = ";
            l4_ctr = ctr_audit_rpt_writes;
            //     write rpt-rec-b			from l4-line after advancing 3 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //l4_line = "";
            await l4_line_grp(true);
            // "NUMBER OF EXCEPTION  PRINTED = "					to l4-title.;
            l4_title = "NUMBER OF EXCEPTION  PRINTED = ";
            l4_ctr = ctr_exception_rpt_writes;
            //     write rpt-rec-b			from l4-line after advancing 3 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l4_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            await l4_line_grp(true);
        }

        private async Task az1_99_exit()
        {
            Util.Trakker(++ctr, "az1_99_exit");
            //     exit.;
        }

        private async Task<string> ba0_preliminary_edit_patient()
        {
            Util.Trakker(++ctr, "ba0_preliminary_edit_patient");

            edit_flag = "Y";

            //  if tp-pat-func-code = "AA" or "C1" or "C2"  then;            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C1") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2"))
            {
                //         next sentence;
            }
            //   else;
            else
            {
                edit_flag = "N";
                err_ind = 1;
                //   	go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //   if (tp-pat-health-nbr = zeroes  or spaces) and tp-pat-id-no = spaces and  tp-pat-ohip-no = spaces  then;            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_nbr) && string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no) && string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_ohip_no))
            {
                edit_flag = "N";
                err_ind = 2;
                //    go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //   if (tp-pat-health-nbr = zeroes  or spaces) and tp-pat-ohip-no = spaces  then                       
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_nbr) && string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_ohip_no))
            {
                edit_flag = "N";
                err_ind = 6;
                // 	go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //  if tp-pat-last-name = spaces then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_last_name))
            {
                edit_flag = "N";
                err_ind = 3;
                //     go to ba0-99-exit;                
                return "ba0_99_exit";
            }
            else
            {
                ws_i_last_name = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);
            }

            //  if tp-pat-first-name = spaces then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_first_name))
            {
                edit_flag = "N";
                err_ind = 5;
                //  go to ba0-99-exit;                
                return "ba0_99_exit";
            }
            else
            {
                ws_i_first_name_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);
                ws_i_first_name_1 = Util.Str(ws_i_first_name_grp).PadRight(24).Substring(0, 1);
                ws_i_first_name_11 = Util.Str(ws_i_first_name_grp).PadRight(24).Substring(1, 11);
                ws_i_first_name_12 = Util.Str(ws_i_first_name_grp).PadRight(24).Substring(12, 12);
            }

            //  if tp-pat-birth-yy is not numeric then            
            if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy) == 0)
            {
                edit_flag = "N";
                err_ind = 7;
                // 	    go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //  if tp-pat-birth-mm is not numeric then            
            if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) == 0)
            {
                edit_flag = "N";
                err_ind = 8;
                // 	   go to ba0-99-exit;                            
                return "ba0_99_exit";
            }
            // 	else if tp-pat-birth-mm < 1 or > 12 then            
            else if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) < 1 || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) > 12)
            {
                edit_flag = "N";
                err_ind = 9;
                //     go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //  if tp-pat-birth-dd is not numeric  then            
            if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) == 0)
            {
                edit_flag = "N";
                err_ind = 10;
                // 	   go to ba0-99-exit;                            
                return "ba0_99_exit";
            }
            //  else if tp-pat-birth-dd  < 1  or > 31  then            
            else if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) < 1 || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) > 31)
            {
                edit_flag = "N";
                err_ind = 11;
                //     go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //  if tp-pat-birth-mm = 2 then            
            if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) == 2)
            {
                //     if tp-pat-birth-dd > 29 then            
                if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) > 29)
                {
                    edit_flag = "N";
                    err_ind = 12;
                    //         go to ba0-99-exit.;                    
                    return "ba0_99_exit";
                }
            }

            //  if tp-pat-birth-mm =   4 or 6 or 9 or 11 then            
            if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) == 4 || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) == 6 || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) == 9 || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) == 11)
            {
                //  	if tp-pat-birth-dd > 30 then            
                if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) > 30)
                {
                    edit_flag = "N";
                    err_ind = 13;
                    //  	   go to ba0-99-exit.;                    
                    return "ba0_99_exit";
                }
            }

            test_birth_yy = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy);
            test_birth_mm = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm);
            test_birth_dd = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd);

            //  if test-birth-date > sys-date-long or tp-pat-birth-yy < 1880  then            
            test_birth_date_grp = Util.Str(Util.NumInt(test_birth_yy)).PadLeft(4, '0') + Util.Str(Util.NumInt(test_birth_mm)).PadLeft(2, '0') + Util.Str(Util.NumInt(test_birth_dd)).PadLeft(2, '0');
            if (Util.NumInt(test_birth_date_grp) > Util.NumInt(sys_date_long_child) || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy) < 1880)
            {
                err_ind = 23;
                edit_flag = "N";
                // 	go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //  if tp-pat-sex = "M" or "F" then            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_sex).ToUpper().Equals("M") || Util.Str(objTp_pat_mstr_rec.tp_pat_sex).ToUpper().Equals("F"))
            {
                //  	next sentence;            
            }
            //  else if tp-pat-func-code = "AA" or "C2" then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2"))
            {
                edit_flag = "N";
                err_ind = 14;
                //    go to ba0-99-exit.;                
                return "ba0_99_exit";
            }

            //  if tp-pat-id-no = spaces then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no))
            {
                // 	    go to ba0-10-cont-edit-patient.;                
                return "ba0_10_cont_edit_patient";
            }

            ws_save_id_no_grp = "";
            ws_save_id_no_alpha = string.Empty;
            ws_save_id_no_first_8_digits_grp = string.Empty;
            ws_save_id_no_yy_chld = 0;
            ws_save_id_no_mm_chld = 0;
            ws_save_id_no_5_6_digit_chld = 0;
            ws_save_id_no_7_digit_chld = 0;
            ws_save_id_no_8_digit_chld = 0;
            ws_save_id_no_9_digit = string.Empty;


            mrn_site = "";
            edit_chart_flag = "Y";

            //  if tp-pat-id-no-site = 'J' and tp-pat-id-no-pos-11 = ' ' then;            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("J") && string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no_pos_11))
            {
                ws_stjoe_id_no_pos_1_chld = 0;
                ws_stjoe_id_no_pos_2_10_chld = objTp_pat_mstr_rec.tp_pat_id_no_pos_2_10;

                ws_stjoe_id_no_grp = Util.Str(ws_stjoe_id_no_alpha_chld) + Util.Str(ws_stjoe_id_no_pos_1_chld) + Util.Str(ws_stjoe_id_no_pos_2_10_chld);
                objTp_pat_mstr_rec.tp_pat_id_no = ws_stjoe_id_no_grp.PadRight(15);
                objTp_pat_mstr_rec.tp_pat_id_no_first_8_digits = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(0, 14);
                objTp_pat_mstr_rec.tp_pat_id_no_site = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(0, 1);
                objTp_pat_mstr_rec.tp_pat_id_no_yy = Util.NumInt(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(1, 2));
                objTp_pat_mstr_rec.tp_pat_id_no_mm = Util.NumInt(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(3, 2));
                objTp_pat_mstr_rec.tp_pat_id_no_5_digit = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(5, 1);
                objTp_pat_mstr_rec.tp_pat_id_no_6_7_digit = Util.NumInt(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(6, 2));
                objTp_pat_mstr_rec.tp_pat_id_no_8_digit = Util.NumInt(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(8, 1));
                objTp_pat_mstr_rec.tp_pat_id_no_reminder = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(9, 5);
                objTp_pat_mstr_rec.tp_pat_id_no_last_digit = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(14, 1);
                objTp_pat_mstr_rec.tp_pat_id_no_pos_1 = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(0, 1);
                objTp_pat_mstr_rec.tp_pat_id_no_pos_2_10 = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(1, 9);
                objTp_pat_mstr_rec.tp_pat_id_no_pos_2_4 = Util.NumInt(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(1, 3));
                objTp_pat_mstr_rec.tp_pat_id_no_pos_5_10 = Util.NumInt(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(4, 6));
                objTp_pat_mstr_rec.tp_pat_id_no_pos_11 = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(10, 1);
                objTp_pat_mstr_rec.tp_pat_id_no_pos_12_15 = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Substring(11, 4);
            }

            //  if tp-pat-id-no-site  = 'M' or 'K' or 'H' or '0' or 'J' or'D' or 'E' or 'F' or 'W' or 'Z'  then            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("M") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("K") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("H") ||
                Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("0") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("J") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("D") ||
                Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("E") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("F") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("W") ||
                Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("Z"))
            {
                // 	     next sentence;
            }
            else
            {
                edit_chart_flag = "N";
                err_ind = 46;
                //       go to ba0-10-cont-edit-patient.;                
                return "ba0_10_cont_edit_patient";
            }

            //  if  tp-pat-id-no-site = "M" then            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("M"))
            {
                      mrn_site = "m";            
            }
            //  else if   tp-pat-id-no-site = "K" then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("K"))
            {
                       mrn_site = "c";            
            }
            //  else if   tp-pat-id-no-site = "H" then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("H"))
            {
                       mrn_site = "h";            
            }
            //  else; if   tp-pat-id-no-site = "0"  then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("0"))
            {
                       mrn_site = "g";            
            }
            //  elseif   tp-pat-id-no-site = "D" then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("D"))
            {
                      mrn_site = "d";            
            }
            //  else if   tp-pat-id-no-site = "E"  then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("E"))
            {
                      mrn_site = "e";            
            }
            //  else if   tp-pat-id-no-site = "F"  then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("F"))
            {
                      mrn_site = "f";            
            }
            //  else if   tp-pat-id-no-site = "W"  then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("W"))
            {
                     mrn_site = "w";            
            }
            //  else;  if   tp-pat-id-no-site = "Z" then;            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("Z"))
            {
                     mrn_site = "z";            
            }
            //  elseif   tp-pat-id-no-site = "J" and  tp-pat-id-no-reminder = spaces  then                       
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("J") && string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no_reminder))
            {
                mrn_site = "b";
                // 	   go to ba0-10-cont-edit-patient;                            
                return "ba0_10_cont_edit_patient";
            }
            //  else if   tp-pat-id-no-site = "J" then;            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("J"))
            {
                mrn_site = "s";
            }


            // if  tp-pat-id-no-pos-2-10 is not numeric and tp-pat-id-no-site  not = "Z"  then                      
            if (!Util.IsNumeric(objTp_pat_mstr_rec.tp_pat_id_no_pos_2_10) && !Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_site).ToUpper().Equals("Z"))
            {
                edit_chart_flag = "N";
                err_ind = 47;
                //   go to ba0-10-cont-edit-patient.;                
                return "ba0_10_cont_edit_patient";
            }


            // if  mrn-is-stjoes and tp-pat-id-no-pos-11 is not numeric   then            
            if (Util.Str(mrn_site).Equals(mrn_is_stjoes) &&  (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_pos_11).Trim().Length < 1 || !Util.IsNumeric(objTp_pat_mstr_rec.tp_pat_id_no_pos_11)))
            {
                edit_chart_flag = "N";
                err_ind = 39;
                // 	 go to ba0-10-cont-edit-patient.;                
                return "ba0_10_cont_edit_patient";
            }


            // if  tp-pat-id-no-pos-12-15 not = spaces or (    not mrn-is-stjoes  and tp-pat-id-no-pos-11 not = space )   then       
            if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no_pos_12_15) || (!Util.Str(mrn_site).Equals(mrn_is_stjoes) && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no_pos_11)))
            {
                edit_chart_flag = "N";
                err_ind = 48;
                //   go to ba0-10-cont-edit-patient.;                
                return "ba0_10_cont_edit_patient";
            }


            // if mrn-is-henderson then            
            if (Util.Str(mrn_site).Equals(mrn_is_henderson))
            {
                //   if tp-pat-id-no-pos-2-4 = '002' or '003' then            
                if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_pos_2_4).PadLeft(3,'0').Equals("002") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_pos_2_4).PadLeft(3,'0').Equals("003"))
                {
                    // 	    next sentence;
                }
                else
                {
                    edit_chart_flag = "N";
                    err_ind = 49;
                    //    go to ba0-10-cont-edit-patient.;                    
                    return "ba0_10_cont_edit_patient";
                }
            }


            // if mrn-is-general then            
            if (Util.Str(mrn_site).Equals(mrn_is_general))
            {
                //    if tp-pat-id-no-pos-2-4 = '001' or '005' then            
                if (Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_pos_2_4).PadLeft(3,'0').Equals("001") || Util.Str(objTp_pat_mstr_rec.tp_pat_id_no_pos_2_4).PadLeft(3,'0').Equals("005"))
                {
                    // 	     next sentence;
                }
                else
                {
                    edit_chart_flag = "N";
                    err_ind = 52;
                    // 	    go to ba0-10-cont-edit-patient.;                    
                    return "ba0_10_cont_edit_patient";
                }
            }
            return string.Empty;
        }

        private async Task<string> ba0_10_cont_edit_patient()
        {
            Util.Trakker(++ctr, "ba0_10_cont_edit_patient");

            // if tp-pat-street-addr = spaces and  (tp-pat-func-code = "AA" or "C2") then;         
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_street_addr) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                edit_flag = "N";
                err_ind = 21;
                // 	  go to ba0-99-exit;                            
                return "ba0_99_exit";
            }
            // else if tp-pat-street-addr not = spaces and  (tp-pat-func-code = "AA" or "C2") then            
            else if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_street_addr) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                ws_i_street_addr_grp = "";
                ws_i_street_addr1 = string.Empty;
                ws_i_street_addr2 = string.Empty;
                ws_i_street_addr_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr);
                ws_i_street_addr1 = Util.Str(ws_i_street_addr_grp).PadRight(28).Substring(0, 21);
                ws_i_street_addr2 = Util.Str(ws_i_street_addr_grp).PadRight(28).Substring(21, 7);
            }


            ws_i_city_prov_grp = "";
            ws_i_city = string.Empty;
            ws_i_prov = string.Empty;

            //if tp-pat-city = spaces  and (tp-pat-func-code = "AA" or "C2") then          
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_city) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                edit_flag = "N";
                err_ind = 22;
                // 	 go to ba0-99-exit;                            
                return "ba0_99_exit";
            }
            //else if tp-pat-city not = spaces  and (tp-pat-func-code = "AA" or "C2") then            
            else if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_city) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                ws_i_city = Util.Str(objTp_pat_mstr_rec.tp_pat_city);
            }


            // if tp-pat-prov = spaces and (tp-pat-func-code = "AA" or "C2" ) then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_prov) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                objTp_pat_mstr_rec.tp_pat_prov = "ON";
            }
            // else if tp-pat-prov not = spaces and (tp-pat-func-code = "AA" or "C2" ) then            
            else if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_prov) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                province_flag = "N";
                //      perform bc0-search-province 	thru bc0-99-exit;
                // 	 	    varying sub from 1 by 1;
                // 		    until (province-found or sub > 13);
                sub = 1;
                do
                {
                    await bc0_search_province();
                    await bc0_99_exit();
                    sub++;
                } while (!province_flag.Equals(province_found) && sub <= 13);
                // 	    if province-not-found then            
                if (province_flag.Equals(province_not_found))
                {
                    objTp_pat_mstr_rec.tp_pat_prov = "ON";
                }
            }


            // if (tp-pat-prov not = 'ON' and tp-pat-health-nbr not = spaces and tp-pat-health-nbr not = zeroes) and (tp-pat-func-code = 'AA' or 'C2')  then;            
            if ((!Util.Str(objTp_pat_mstr_rec.tp_pat_prov).ToUpper().Equals("ON") && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_nbr) && Util.NumLongInt(objTp_pat_mstr_rec.tp_pat_health_nbr) > 0) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                edit_flag = "N";
                err_ind = 37;
                //    go to ba0-99-exit.;                
                return "ba0_99_exit";
            }


            // if (tp-pat-prov not = 'ON' and tp-pat-ohip-no  = spaces) and (tp-pat-func-code = 'AA' or 'C2')  then            
            if ((!Util.Str(objTp_pat_mstr_rec.tp_pat_prov).ToUpper().Equals("ON") && string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_ohip_no)) && (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA") || Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2")))
            {
                edit_flag = "N";
                err_ind = 40;
                //  go to ba0-99-exit.;                
                return "ba0_99_exit";
            }


            // if tp-pat-health-nbr = spaces or tp-pat-health-nbr = zero  then                       
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_nbr) || Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr).Equals("0"))
            {
                // 	   next sentence;            
            }
            // else if tp-pat-health-nbr is not numeric then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr).Trim().Length < 10 || !Util.IsNumeric(objTp_pat_mstr_rec.tp_pat_health_nbr)) // data type is string
            {
                edit_flag = "N";
                err_ind = 31;
                //     go to ba0-99-exit;                            
                return "ba0_99_exit";
            }
            // else if tp-pat-prov = "ON" then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_prov).ToUpper().Equals("ON"))
            {
                // 	  perform be0-verify-health-nbr	thru be0-99-exit;  //
                await be0_verify_health_nbr();
                await be0_10_total_loop();
                await be0_99_exit();

                //  if invalid-health then            
                if (Util.Str(health_flag).Equals(invalid_health))
                {
                    edit_flag = "N";
                    err_ind = 33;
                    // 		 go to ba0-99-exit.;                    
                    return "ba0_99_exit";
                }
            }


            // if tp-pat-ohip-no = spaces then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_ohip_no))
            {
                // 	   next sentence;            
            }
            // else if tp-pat-ohip-no is not numeric then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no).Trim().Length < 8 ||!Util.IsNumeric(objTp_pat_mstr_rec.tp_pat_ohip_no))
            {
                edit_flag = "N";
                err_ind = 29;
                //     go to ba0-99-exit;                            
                return "ba0_99_exit";
            }
            // else if tp-pat-prov = 'ON' then            
            else if (Util.Str(objTp_pat_mstr_rec.tp_pat_prov).ToUpper().Equals("ON"))
            {
                // 	   perform bd0-verify-ohip-nbr	thru bd0-99-exit;  //
                await bd0_verify_ohip_nbr();
                await bd0_10_total_loop();
                await bd0_99_exit();
                // 	   if invalid-ohip then            
                if (Util.Str(ohip_flag).Equals(invalid_ohip))
                {
                    edit_flag = "N";
                    err_ind = 30;
                    // 	     go to ba0-99-exit.;                    
                    return "ba0_99_exit";
                }
            }

            hold_version_cd_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd).PadRight(2);
            hold_version_cd_1_chld = Util.Str(hold_version_cd_grp).Substring(0, 1);
            hold_version_cd_2_chld = Util.Str(hold_version_cd_grp).Substring(1, 1);

            // if hold-version-cd-1 numeric or hold-version-cd-2 numeric then            
            if (Util.IsNumeric(hold_version_cd_1_chld) || Util.IsNumeric(hold_version_cd_2_chld))
            {
                edit_flag = "N";
                err_ind = 4;
            }
            // else if tp-pat-version-cd not = spaces then            
            else if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_version_cd))
            {
                //    perform dd0-check-version-cd     thru dd0-99-exit.;
                await dd0_check_version_cd();
                await dd0_99_exit();
            }
            return string.Empty;
        }

        private async Task ba0_99_exit()
        {
            Util.Trakker(++ctr, "ba0_99_exit");

            //     exit.;
        }

        private async Task bb0_search_space_trailing()
        {
            Util.Trakker(++ctr, "bb0_search_space_trailing");

            // if ws-i-detail-byte(sub) = spaces then            
            if (string.IsNullOrWhiteSpace(ws_i_detail_byte[sub]))
            {
                // 	   add 1 				to space-ctr.;
                space_ctr++;
            }
        }

        private async Task bb0_99_exit()
        {
            Util.Trakker(++ctr, "bb0_99_exit");

            //     exit.;
        }

        private async Task bc0_search_province()
        {
            Util.Trakker(++ctr, "bc0_search_province");

            //  if tp-pat-prov = new-prov(sub) then
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_prov).ToUpper().Equals(new_prov[sub]))
            {
                ws_i_prov = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
                province_flag = "Y";
            }
        }

        private async Task bc0_99_exit()
        {
            Util.Trakker(++ctr, "bc0_99_exit");

            //     exit.;
        }

        private async Task bd0_verify_ohip_nbr()
        {
            Util.Trakker(++ctr, "bd0_verify_ohip_nbr");

            max_nbr_digits = 7;
            ws_nbr_to_b_val = Util.NumInt(objTp_pat_mstr_rec.tp_pat_ohip_no);
            ws_val_total = 0;
            //     perform bd1-odd-even		thru bd1-99-exit;
            // 					varying sub from 1 by 1;
            // 					until sub > max-nbr-digits.;
            sub = 1;
            do
            {
                await bd1_odd_even();
                await bd1_99_exit();
                sub++;
            } while (sub <= max_nbr_digits);
        }

        private async Task bd0_10_total_loop()
        {
            Util.Trakker(++ctr, "bd0_10_total_loop");

            _bd0_10_total_loop:
            // if ws-val-total = 10 then            
            if (ws_val_total == 10)
            {
                ws_val_total = 0;
            }
            // else	if ws-val-total > 10 then            
            else if (ws_val_total > 10)
            {
                // 	    subtract 10 from ws-val-total giving ws-val-total            
                ws_val_total = ws_val_total - 10;
                // 	    go to bd0-10-total-loop;
                goto _bd0_10_total_loop;                
            }
            else
            {
                // 	    subtract ws-val-total 	from 10 giving ws-val-total.
                ws_val_total = 10 - ws_val_total;
            }


            // if ws-val-total not = ws-nbr-to-b-val-1-8(8) then     
            if (ws_val_total != ws_nbr_to_b_val_1_8[8])
            {
                ohip_flag = "N";
            }
            else
            {
                ohip_flag = "Y";
            }
        }

        private async Task bd0_99_exit()
        {
            Util.Trakker(++ctr, "bd0_99_exit");

            //     exit.;
        }

        private async Task bd1_odd_even()
        {
            Util.Trakker(++ctr, "bd1_odd_even");

            //  divide 2	into sub giving dummy;            
            // 					remainder rem-even.;
            dummy = sub / 2;
            rem_even = sub % 2;

            // if rem-even = zero then    
            if (Util.NumInt(rem_even) == 0)
            {
                ws_sum_1_2[sub] = Util.NumInt(ws_nbr_to_b_val_1_8[sub]);
            }
            else
            {
                //   	add ws-nbr-to-b-val-1-8(sub);
                // 	        ws-nbr-to-b-val-1-8(sub)	giving ws-sum-1-2(sub).;
                ws_sum_1_2[sub] = ws_nbr_to_b_val_1_8[sub] + ws_nbr_to_b_val_1_8[sub];
            }


            //     add ws-sum-1(sub,1);
            //   	ws-sum-1(sub,2);
            // 	ws-val-total			giving ws-val-total.; 
            ws_val_total = ws_val_total + ws_sum_1[sub, 1] + ws_sum_1[sub, 2];
        }

        private async Task bd1_99_exit()
        {
            Util.Trakker(++ctr, "bd1_99_exit");

            //     exit.;
        }

        private async Task be0_verify_health_nbr()
        {
            Util.Trakker(++ctr, "be0_verify_health_nbr");

            max_nbr_digits = 9;
            ws_hc_nbr_to_b_val = Util.NumLongInt(objTp_pat_mstr_rec.tp_pat_health_nbr);
            ws_val_total = 0;
            //     perform be1-odd-even		thru be1-99-exit;
            // 					varying sub from 1 by 1;
            // 					until sub > max-nbr-digits.;

            sub = 1;
            do
            {
                await be1_odd_even();
                await be1_99_exit();
                sub++;
            } while (sub <= max_nbr_digits);
        }

        private async Task be0_10_total_loop()
        {
            Util.Trakker(++ctr, "be0_10_total_loop");

            _be0_10_total_loop:
            // if ws-val-total = 10  then      
            if (ws_val_total == 10)
            {
                ws_val_total = 0;
            }
            // else if ws-val-total > 10 then            
            else if (ws_val_total > 10)
            {
                // 	    subtract 10	from ws-val-total giving ws-val-total            
                ws_val_total = ws_val_total - 10;
                // 	    go to be0-10-total-loop;
                goto _be0_10_total_loop;                
            }
            else
            {
                //     subtract ws-val-total 	from 10 giving ws-val-total.
                ws_val_total = 10 - ws_val_total;
            }


            // if ws-val-total not = ws-hc-nbr-to-b-val-1-10(10) then            
            if (ws_val_total != ws_hc_nbr_to_b_val_1_10[10])
            {
                health_flag = "N";
            }
            else
            {
                health_flag = "Y";
            }
        }

        private async Task be0_99_exit()
        {
            Util.Trakker(++ctr, "be0_99_exit");
            //     exit.;
        }

        private async Task be1_odd_even()
        {
            Util.Trakker(++ctr, "be1_odd_even");

            //     divide 2				into sub;
            // 					giving dummy;
            // 					remainder rem-even.;
            dummy = sub / 2;
            rem_even = sub % 2;


            ws_hc_nbr_to_b_val_1_10[1] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(0, 1));
            ws_hc_nbr_to_b_val_1_10[2] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(1, 1));
            ws_hc_nbr_to_b_val_1_10[3] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(2, 1));
            ws_hc_nbr_to_b_val_1_10[4] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(3, 1));
            ws_hc_nbr_to_b_val_1_10[5] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(4, 1));
            ws_hc_nbr_to_b_val_1_10[6] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(5, 1));
            ws_hc_nbr_to_b_val_1_10[7] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(6, 1));
            ws_hc_nbr_to_b_val_1_10[8] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(7, 1));
            ws_hc_nbr_to_b_val_1_10[9] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(8, 1));
            ws_hc_nbr_to_b_val_1_10[10] = Util.NumInt(Util.Str(ws_hc_nbr_to_b_val).PadLeft(10, '0').Substring(9, 1));


            // if rem-even = zero then            
            if (rem_even == 0)
            {
                ws_hc_sum_1_2[sub] = ws_hc_nbr_to_b_val_1_10[sub];
            }
            else
            {
                // 	  add ws-hc-nbr-to-b-val-1-10(sub);
                // 	      ws-hc-nbr-to-b-val-1-10(sub)	giving ws-hc-sum-1-2(sub).;
                ws_hc_sum_1_2[sub] = ws_hc_nbr_to_b_val_1_10[sub] + ws_hc_nbr_to_b_val_1_10[sub];
            }

            ws_hc_sum_1_2_val_r1[sub] =  ws_hc_sum_1_2[sub];
            ws_hc_sum_1[sub, 1] = Util.NumInt(Util.Str(ws_hc_sum_1_2_val_r1[sub]).PadLeft(2, '0').Substring(0,1));
            ws_hc_sum_1[sub, 2] = Util.NumInt(Util.Str(ws_hc_sum_1_2_val_r1[sub]).PadLeft(2, '0').Substring(1, 1));

            //  add ws-hc-sum-1(sub,1);
            //      ws-hc-sum-1(sub,2);
            // 	   ws-val-total			giving ws-val-total.;
            ws_val_total = Util.NumInt(ws_val_total) + Util.NumInt(ws_hc_sum_1[sub, 1]) + Util.NumInt(ws_hc_sum_1[sub, 2]);
        }

        private async Task be1_99_exit()
        {
            Util.Trakker(++ctr, "be1_99_exit");

            //     exit.;
        }

        private async Task ca0_add_mode_processing()
        {
            Util.Trakker(++ctr, "ca0_add_mode_processing");

            //     perform fa0-build-key-pat-mstr		thru fa0-99-exit.;
            await fa0_build_key_pat_mstr();
            await fa0_99_exit();

            // if pat-exist then            
            if (Util.Str(pat_flag).Equals(pat_exist))
            {
                err_ind = 32;
                //  perform  xa0-write-tp-error-report     thru xa0-99-exit;
                await xa0_write_tp_error_report();
                await xa0_99_exit();
            }
            // else;
            else
            {
                // 	  perform cc0-determine-if-acron-exist	thru cc0-99-exit;
                string retval =  await cc0_determine_if_acron_exist();
                if (retval.Equals("cc0_99_exit")) goto _cc0_99_exit;
                await cc0_10_check_acron();
                _cc0_99_exit:
                await cc0_99_exit();

                // 	  if ( health  or ohip or chart) and pat-not-exist then        
                if ((Util.Str(flag_ohip_vs_chart).Equals(health) || Util.Str(flag_ohip_vs_chart).Equals(ohip) || Util.Str(flag_ohip_vs_chart).Equals(chart)) && Util.Str(pat_flag).Equals(pat_not_exist))
                {
                    // 	       perform ga0-build-patient 	        thru ga0-99-exit;
                    await ga0_build_patient();
                    await ga0_99_exit();
                    //         perform yb1-write-patient           thru yb1-99-exit;
                    await yb1_write_patient();
                    await yb1_99_exit();
                }
                // 	  else if all-three and pat-not-exist then            
                else if (Util.Str(flag_ohip_vs_chart).Equals(all_three) && Util.Str(pat_flag).Equals(pat_not_exist))
                {
                    hold_ohip_mmyy_grp = Util.Str(hold_ohip_no_chld).PadRight(8) + Util.Str(hold_ohip_mm_chld).PadRight(2) + Util.Str(hold_ohip_yy_chld).PadRight(2) + new string(' ', 3);
                    objPat_mstr_rec.PAT_DIRECT_ALPHA = Util.Str(hold_ohip_mmyy_grp).Substring(0, 3);
                    objPat_mstr_rec.PAT_DIRECT_YY = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(3, 2));
                    objPat_mstr_rec.PAT_DIRECT_MM = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(5, 2));
                    objPat_mstr_rec.PAT_DIRECT_DD = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(7, 2));

                    //         perform yb0-2-read-od-pat-mstr  thru yb0-2-99-exit;
                    await yb0_2_read_od_pat_mstr();
                    await yb0_2_99_exit();
                    //         if pat-exist then;            
                    if (Util.Str(pat_flag).Equals(pat_exist))
                    {
                        err_ind = 36;
                        //         perform xa0-write-tp-error-report thru xa0-99-exit;
                        await xa0_write_tp_error_report();
                        await xa0_99_exit();
                    }
                    //          else;
                    else
                    {
                        //                 perform yb0-5-read-chrt-pat-mstr thru yb0-5-99-exit;
                        await yb0_5_read_chrt_pat_mstr();
                        await yb0_5_99_exit();
                        //         	       if pat-exist then     
                        if (pat_flag.Equals(pat_exist))
                        {
                            err_ind = 38;
                            //   perform xa0-write-tp-error-report thru xa0-99-exit            
                            await xa0_write_tp_error_report();
                            await xa0_99_exit();
                        }
                        else
                        {
                            //                    perform ga0-build-patient      thru ga0-99-exit;
                            await ga0_build_patient();
                            await ga0_99_exit();
                            //                    perform yb1-write-patient      thru yb1-99-exit;            
                            await yb1_write_patient();
                            await yb1_99_exit();
                        }
                    }
                }
                //    else if health-and-chart and pat-not-exist then            
                else if (Util.Str(flag_ohip_vs_chart).Equals(health_and_chart) && Util.Str(pat_flag).Equals(pat_not_exist))
                {
                    //         perform yb0-5-read-chrt-pat-mstr thru yb0-5-99-exit;
                    await yb0_5_read_chrt_pat_mstr();
                    await yb0_5_99_exit();

                    //         if pat-exist then            
                    if (Util.Str(pat_flag).Equals(pat_exist))
                    {
                        err_ind = 38;
                        //       perform xa0-write-tp-error-report thru xa0-99-exit            
                        await xa0_write_tp_error_report();
                        await xa0_99_exit();
                    }
                    else
                    {
                        //              perform ga0-build-patient      thru ga0-99-exit;
                        await ga0_build_patient();
                        await ga0_99_exit();
                        //              perform yb1-write-patient      thru yb1-99-exit;
                        await yb1_write_patient();
                        await yb1_99_exit();
                    }
                }
                //   else if ohip-and-chart and pat-not-exist then            
                else if (Util.Str(flag_ohip_vs_chart).Equals(ohip_and_chart) && Util.Str(pat_flag).Equals(pat_not_exist))
                {
                    //         perform yb0-5-read-chrt-pat-mstr thru yb0-5-99-exit;
                    await yb0_5_read_chrt_pat_mstr();
                    await yb0_5_99_exit();
                    //         if pat-exist then;            
                    if (pat_flag.Equals(pat_exist))
                    {
                        err_ind = 38;
                        // 	          perform xa0-write-tp-error-report thru xa0-99-exit            
                        await xa0_write_tp_error_report();
                        await xa0_99_exit();
                    }
                    else
                    {
                        //            perform ga0-build-patient   thru ga0-99-exit;
                        await ga0_build_patient();
                        await ga0_99_exit();
                        //            perform yb1-write-patient   thru yb1-99-exit;            
                        await yb1_write_patient();
                        await yb1_99_exit();
                    }
                }
                //   else if  health-and-ohip and pat-not-exist   then            
                else if (Util.Str(flag_ohip_vs_chart).Equals(health_and_ohip) && Util.Str(pat_flag).Equals(pat_not_exist))
                {
                    //        objPat_mstr_rec.pat_ohip_mmyy = hold_ohip_mmyy;
                    hold_ohip_mmyy_grp = Util.Str(hold_ohip_no_chld).PadRight(8) + Util.Str(hold_ohip_mm_chld).PadRight(2) + Util.Str(hold_ohip_yy_chld).PadRight(2) + new string(' ', 3);
                    objPat_mstr_rec.PAT_DIRECT_ALPHA = Util.Str(hold_ohip_mmyy_grp).Substring(0, 3);
                    objPat_mstr_rec.PAT_DIRECT_YY = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(3, 2));
                    objPat_mstr_rec.PAT_DIRECT_MM = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(5, 2));
                    objPat_mstr_rec.PAT_DIRECT_DD = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(7, 2));

                    //        perform yb0-2-read-od-pat-mstr thru yb0-2-99-exit;
                    await yb0_2_read_od_pat_mstr();
                    await yb0_2_99_exit();
                    //        if pat-exist  then             
                    if (Util.Str(pat_flag).Equals(pat_exist))
                    {
                        err_ind = 36;
                        // 		     perform xa0-write-tp-error-report thru xa0-99-exit            
                        await xa0_write_tp_error_report();
                        await xa0_99_exit();
                    }
                    else
                    {
                        //           perform ga0-build-patient   thru ga0-99-exit;
                        await ga0_build_patient();
                        await ga0_99_exit();
                        //           perform yb1-write-patient   thru yb1-99-exit.;
                        await yb1_write_patient();
                        await yb1_99_exit();
                    }
                }
            }
        }

        private async Task ca0_99_exit()
        {
            Util.Trakker(++ctr, "ca0_99_exit");

            //     exit.;
        }

        private async Task<string> cc0_determine_if_acron_exist()
        {
            Util.Trakker(++ctr, "cc0_determine_if_acron_exist");

            hold_last_name_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);
            hold_first_name_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);
            hold_acronym_grp = Util.Str(hold_last_name_chld).Substring(0, 6) + Util.Str(hold_first_name_chld).Substring(0, 3);

            hold_acronym_grp = Util.Str(hold_last_name_chld).PadRight(6) + Util.Str(hold_first_name_chld).PadRight(3);
            objPat_mstr_rec.PAT_ACRONYM_FIRST6 = Util.Str(hold_acronym_grp).Substring(0, 6);
            objPat_mstr_rec.PAT_ACRONYM_LAST3 = Util.Str(hold_acronym_grp).Substring(6, 3);

            //  perform yb0-4-read-acr-pat-mstr		thru yb0-4-99-exit.;
            await yb0_4_read_acr_pat_mstr();
            await yb0_4_99_exit();

            // if pat-not-exist then            
            if (Util.Str(pat_flag).Equals(pat_not_exist))
            {
                // 	   go to cc0-99-exit.;                
                return "cc0_99_exit";
            }

            pat_flag = "Y";

            return string.Empty;
        }

        private async Task<string> cc0_10_check_acron()
        {
            Util.Trakker(++ctr, "cc0_10_check_acron");

            _cc0_10_check_acron:
            hold_ohip_mmyy_grp = Util.Str(hold_ohip_no_chld).PadRight(8) + Util.Str(hold_ohip_mm_chld).PadRight(2) + Util.Str(hold_ohip_yy_chld) + new string(' ', 3);
            hold_chart_no_grp = Util.Str(hold_chart_id_no);

            //     if   (    hold-health-nbr      = pat-health-nbr of pat-mstr;
            if ((hold_health_nbr == Util.NumLongInt(objPat_mstr_rec.PAT_HEALTH_NBR)
            //           and hold-health-nbr  not = spaces;
                        && !string.IsNullOrWhiteSpace(hold_health_nbr.ToString())
                         //           and hold-health-nbr  not = zeroes );
                         && Util.Str(hold_health_nbr) != "0")    // todo watch out not= zeroes....
            //       or (    hold-ohip-mmyy       = pat-ohip-mmyy-r;
                     || (hold_ohip_mmyy_grp == (Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadRight(2, '0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_LAST_6).PadRight(6))
            //           and hold-ohip-mmyy   not = spaces );
                      && !string.IsNullOrWhiteSpace(hold_ohip_mmyy_grp))
                     //       or (    hold-chart-no        = pat-chart-nbr;
                     || (Util.Str(hold_chart_id_no).Trim() == Util.Str(objPat_mstr_rec.PAT_CHART_NBR).Trim()
            //           and hold-chart-no    not = spaces );
                     && !string.IsNullOrWhiteSpace(hold_chart_id_no))
                     //       or (    hold-chart-no        = pat-chart-nbr-2;
                     || (Util.Str(hold_chart_id_no).Trim() == Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).Trim()
            //           and hold-chart-no    not = spaces );
                        && !string.IsNullOrWhiteSpace(hold_chart_no_grp))
            //       or (    hold-chart-no        = pat-chart-nbr-3;
                     || (Util.Str(hold_chart_no_grp).Trim() == Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).Trim()
            //           and hold-chart-no    not = spaces );
                      && !string.IsNullOrWhiteSpace(hold_chart_no_grp))
                     //       or (    hold-chart-no        = pat-chart-nbr-4;
                     || (Util.Str(hold_chart_no_grp).Trim() == Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).Trim()
            //           and hold-chart-no    not = spaces );
                     && !string.IsNullOrWhiteSpace(hold_chart_no_grp))
                     //       or (    hold-chart-no        = pat-chart-nbr-5;
                     || (Util.Str(hold_chart_no_grp).Trim() == Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).Trim()
            //           and hold-chart-no    not = spaces );
                     && !string.IsNullOrWhiteSpace(hold_chart_no_grp))
            //    then;
            )
            {
                //         if tp-pat-func-code = 'AA' then            
                if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA"))
                {
                    err_ind = 41;
                    // 	         perform xa0-write-tp-error-report	thru xa0-99-exit;            
                    await xa0_write_tp_error_report();
                    await xa0_99_exit();
                }
                //         else if tp-pat-func-code = 'C2' then            
                else if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C2"))
                {
                    err_ind = 51;
                    //          perform xa0-write-tp-error-report thru xa0-99-exit            
                    await xa0_write_tp_error_report();
                    await xa0_99_exit();
                }
                else
                {
                    //                 next sentence;
                }
            }
            else
            {
                // 	      perform yb0-10-read-next-pat-mstr	thru yb0-10-99-exit;
                await yb0_10_read_next_pat_mstr();
                await yb0_10_99_exit();

                // 	      if pat-not-exist then            
                if (Util.Str(pat_flag).Equals(pat_not_exist))
                {
                    // 	         go to cc0-99-exit;                                
                    return "cc0_99_exit";
                }
                // 	      else if pat-exist then            
                else if (Util.Str(pat_flag).Equals(pat_exist))
                {
                    // 		    go to cc0-10-check-acron.;
                    goto _cc0_10_check_acron;
                }
            }

            return string.Empty;
        }

        private async Task cc0_99_exit()
        {
            Util.Trakker(++ctr, "cc0_99_exit");
            //     exit.;
        }

        private async Task da0_change_mode_processing()
        {
            Util.Trakker(++ctr, "da0_change_mode_processing");

            _da0_change_mode_processing:

            //     perform ya0-read-next-tape     		thru ya0-99-exit.;
            await ya0_read_next_tape();
            await ya0_99_exit();

            //  if eof-tape then;           
            if (eof_tp_pat_mstr.Equals(eof_tape))
            {
                //         go to da0-99-exit.;
                await da0_99_exit();
                return;
            }

            // if tp-pat-func-code = "C1" then            
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("C1"))
            {
                // 	   add 1 					to ctr-error-rpt-writes;
                ctr_error_rpt_writes++;
                //     ws_tp_pat_mstr_rec = objTp_pat_mstr_rec.tp_pat_mstr_rec;
                await move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec();
                // 	   go to da0-change-mode-processing;
                goto _da0_change_mode_processing;                
            }
            //  else;
            else
            {
                // 	   perform ba0-preliminary-edit-patient   	thru ba0-99-exit;
                string retval =   await ba0_preliminary_edit_patient();
                if (Util.Str(retval).Equals("ba0_99_exit")) goto _ba0_99_exit;
                await ba0_10_cont_edit_patient();
                _ba0_99_exit:
                await ba0_99_exit();
                // 	   if invalid-record then            
                if (Util.Str(edit_flag).Equals(invalid_record))
                {
                    // 	      if tp-pat-func-code = "AA" then            
                    if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA"))
                    {
                        // 	    	 perform xb0-write-ws-error-report	thru xb0-99-exit;
                        await xb0_write_ws_error_report();
                        await xb0_99_exit();
                        // 	    	 perform xa0-write-tp-error-report	thru xa0-99-exit;
                        await xa0_write_tp_error_report();
                        await xa0_99_exit();
                        // 		     go to da0-99-exit;
                        await da0_99_exit();
                        return;
                    }
                    else
                    {
                        // 		     add 1	to ctr-error-rpt-writes;
                        ctr_error_rpt_writes++;
                        // 	    	 perform xa0-write-tp-error-report	thru xa0-99-exit;
                        await xa0_write_tp_error_report();
                        await xa0_99_exit();
                        // 		     go to da0-99-exit;            
                        await da0_99_exit();
                        return;
                    }
                }
                // 	   else if tp-pat-func-code = "AA" then            
                else if (Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).ToUpper().Equals("AA"))
                {
                    // 		  add 1				to ctr-error-rpt-writes;
                    ctr_error_rpt_writes++;
                    //        ws_tp_pat_mstr_rec = objTp_pat_mstr_rec.tp_pat_mstr_rec;
                    await move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec();
                    // 		  perform ca0-add-mode-processing thru ca0-99-exit;
                    await ca0_add_mode_processing();
                    await ca0_99_exit();
                }
                // 	   else;
                else
                {
                    // 	      perform db0-determine-key-exist	thru db0-99-exit.;
                    await db0_determine_key_exist();
                    await db0_99_exit();
                }
            }
        }

        private async Task da0_99_exit()
        {
            Util.Trakker(++ctr, "da0_99_exit");

            //     exit.;
        }

        private async Task db0_determine_key_exist()
        {
            Util.Trakker(++ctr, "db0_determine_key_exist");

            //  perform fa0-build-key-pat-mstr		thru fa0-99-exit.;
            await fa0_build_key_pat_mstr();
            await fa0_99_exit();

            // if pat-not-exist then          
            if (Util.Str(pat_flag).Equals(pat_not_exist))
            {
                // 	  add 1					to ctr-error-rpt-writes;
                ctr_error_rpt_writes++;
                //    ws_tp_pat_mstr_rec = "";
                //    ws_tp_pat_mstr_rec = objTp_pat_mstr_rec.tp_pat_mstr_rec;
                await move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec();
                // 	  perform ca0-add-mode-processing		thru ca0-99-exit;
                await ca0_add_mode_processing();
                await ca0_99_exit();
            }
            else
            {
                //   	add 1					to ctr-good-c1;
                ctr_good_c1++;
                //     perform dc0-change-check                thru dc0-99-exit.;
                await dc0_change_check();
                await dc0_80();
                await dc0_99_exit();
            }
        }

        private async Task db0_99_exit()
        {
            Util.Trakker(++ctr, "db0_99_exit");
            //     exit.;
        }

        private async Task dc0_change_check()
        {
            Util.Trakker(++ctr, "dc0_change_check");

            //objPat_id_rec.pat_id_rec = "";
            objPat_id_rec = new F086_PAT_ID();

            //objTp_pat_mstr_rec_out.tp_pat_mstr_rec_out = "";
            objTp_pat_mstr_rec_out = new Tp_pat_mstr_rec_out();

            //objPat_id_rec.pat_old_surname = ws_pat_surname;
            objPat_id_rec.PAT_OLD_SURNAME = ws_pat_surname;
            //objPat_id_rec.pat_old_given_name = ws_pat_given_name;
            objPat_id_rec.PAT_OLD_GIVEN_NAME = ws_pat_given_name;
            //objPat_id_rec.pat_old_health_nbr = ws_pat_health_nbr;
            objPat_id_rec.PAT_OLD_HEALTH_NBR = ws_pat_health_nbr;
            //objPat_id_rec.pat_old_chart_nbr = ws_pat_chart_nbr;
            ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char_chld) + Util.Str(pat_chart_remainder_chld);
            objPat_id_rec.PAT_OLD_CHART_NBR = ws_pat_chart_nbr_grp;

            //objPat_id_rec.pat_old_chart_nbr_2 = ws_pat_chart_nbr_2;
            ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char2_chld) + Util.Str(pat_chart_remainder2_chld);
            objPat_id_rec.PAT_OLD_CHART_NBR_2 = ws_pat_chart_nbr_2_grp;

            //objPat_id_rec.pat_old_chart_nbr_3 = ws_pat_chart_nbr_3;
            ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char3_chld) + Util.Str(pat_chart_remainder3_chld);
            objPat_id_rec.PAT_OLD_CHART_NBR_3 = ws_pat_chart_nbr_3_grp;

            //objPat_id_rec.pat_old_chart_nbr_4 = ws_pat_chart_nbr_4;
            ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char4_chld) + Util.Str(pat_chart_remainder4_chld);
            objPat_id_rec.PAT_OLD_CHART_NBR_4 = ws_pat_chart_nbr_4_grp;

            //objPat_id_rec.pat_old_chart_nbr_5 = ws_pat_chart_nbr_5;
            ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char5_chld) + Util.Str(pat_chart_remainder5_chld);
            objPat_id_rec.PAT_OLD_CHART_NBR_5 = ws_pat_chart_nbr_5_grp;

            //objPat_id_rec.pat_old_addr1 = ws_subscr_addr1;
            objPat_id_rec.PAT_OLD_ADDR1 = Util.Str(ws_subscr_addr1);
            //objPat_id_rec.pat_old_addr2 = ws_subscr_addr2;
            objPat_id_rec.PAT_OLD_ADDR2 = Util.Str(ws_subscr_addr2);
            //objPat_id_rec.pat_old_addr3 = ws_subscr_addr3;
            objPat_id_rec.PAT_OLD_ADDR3 = Util.Str(ws_subscr_addr3);

            flag_change_version_cd = "N";
            flag_birth_date_change = "N";
            pat_change_flag = "N";
            flag_old_version_cd = "N";
            flag_old_birth_date = "N";

            // if ( (  tp-pat-version-cd-1 = " ";
            if (((string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_version_cd_1)
                     //               or tp-pat-version-cd-2 = " ";
                     || string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_version_cd_2)
            //             );
                           )
                       //         and (    pat-version-cd-1 of pat-mstr <> " ";
                       && (Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(0, 1) != " "
                            //              and pat-version-cd-2 of pat-mstr <> " ";
                            && Util.Str(objPat_mstr_rec.PAT_VERSION_CD).PadRight(2).Substring(1, 1) != " "
            //             );
                           )
            //        );
                      )
            //     then;
            )
            {
                flag_1_vs_2_character_ver_cd = "Y";
            }
            else
            {
                flag_1_vs_2_character_ver_cd = "N";
            }


            // if  tp-pat-version-cd <> ' ';
            if (!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_version_cd)
            //       and tp-pat-version-cd <> ws-pat-version-cd;
                     && !Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd).Trim().Equals(Util.Str(ws_pat_version_cd).Trim())
            //       and not one-char-ver-cd-vs-2-char;
                     && !Util.Str(flag_1_vs_2_character_ver_cd).Trim().Equals(Util.Str(one_char_ver_cd_vs_2_char).Trim())
            //     then;
            )
            {
                flag_change_version_cd = "Y";
                //      if tp-pat-version-cd <> ws-pat-last-version-cd then            
                if (!Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd).Trim().Equals(Util.Str(ws_pat_last_version_cd).Trim()))
                {
                    ws_pat_last_version_cd = Util.Str(ws_pat_version_cd);
                    ws_pat_version_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd);
                    pat_change_flag = "Y";
                }
                else
                {
                    flag_old_version_cd = "Y";
                    rma_version_cd = Util.Str(ws_pat_version_cd);
                    disk_version_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd);
                }
            }

            //  if    tp-pat-birth-yy <> zero;
            if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy) != 0
                  //       and tp-pat-birth-mm <> zero;
                  && Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) != 0
                  //       and tp-pat-birth-dd <> zero;
                  && Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) != 0
                  //       and (   tp-pat-birth-yy <> ws-pat-birth-date-yy;
                  && (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy) != ws_pat_birth_date_yy_chld
            //            or tp-pat-birth-mm <> ws-pat-birth-date-mm;
                          || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) != ws_pat_birth_date_mm_chld
            //            or tp-pat-birth-dd <> ws-pat-birth-date-dd;
                          || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) != ws_pat_birth_date_dd_chld
            // 	  );
                  )
            //     then;
            )
            {
                flag_birth_date_change = "Y";
                //        if  tp-pat-birth-yy <> ws-pat-last-birth-date-yy;
                if (Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy) != ws_pat_last_birth_date_yy_chld
                //            or  tp-pat-birth-mm <> ws-pat-last-birth-date-mm;
                              || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm) != ws_pat_last_birth_date_mm_chld
                //            or  tp-pat-birth-dd <> ws-pat-last-birth-date-dd;
                              || Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd) != ws_pat_last_birth_date_dd_chld
                //            then;
                )
                {
                    ws_pat_last_birth_date = Util.NumInt(ws_pat_birth_date);
                    ws_pat_birth_date_yy_chld = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy);
                    ws_pat_birth_date_mm_chld = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm);
                    ws_pat_birth_date_dd_chld = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd);
                    pat_change_flag = "Y";
                }
                else
                {
                    flag_old_birth_date = "Y";
                    disk_birth_date_yy = objTp_pat_mstr_rec.tp_pat_birth_yy;
                    disk_birth_date_mm = objTp_pat_mstr_rec.tp_pat_birth_mm;
                    disk_birth_date_dd = objTp_pat_mstr_rec.tp_pat_birth_dd;
                    rma_birth_date_yy = ws_pat_birth_date_yy_chld;
                    rma_birth_date_mm = ws_pat_birth_date_mm_chld;
                    rma_birth_date_dd = ws_pat_birth_date_dd_chld;
                }
            }

            // if (  version-cd-changed;
            if ((Util.Str(flag_change_version_cd).Equals(version_cd_changed)
                      //           and old-version-cd-matches;
                      && Util.Str(flag_old_version_cd).Equals(old_version_cd_matches)
                     //          );
                     )
                  //       or (     birth-date-changed;
                  || (Util.Str(flag_birth_date_change).Equals(birth_date_changed)
                      //           and  old-birth-date-matches;
                      && Util.Str(flag_old_birth_date).Equals(old_birth_date_matches)
                     //          );
                     )
            //     then;
            )
            {
                //         perform xe0-write-update-exception-rpt    thru xe0-99-exit.;
                await xe0_write_update_exception_rpt();
                await xe0_99_exit();
            }

            // if  ( tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char_chld) + Util.Str(pat_chart_remainder_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
                   // 	   and tp-pat-id-no      not = ws-pat-chart-nbr;
                   && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_grp).Trim()
            // 	  )
                  )
            //      and  mrn-is-mumc;
                    && Util.Str(mrn_site).Equals(mrn_is_mumc)
            //     then;
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_grp = objTp_pat_mstr_rec.tp_pat_id_no;
                pat_chart_1st_char_chld = Util.Str(ws_pat_chart_nbr_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder_chld = Util.Str(ws_pat_chart_nbr_grp).PadRight(10).Substring(1, 9);
            }

            // if (tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char2_chld) + Util.Str(pat_chart_remainder2_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
                // 	and tp-pat-id-no      not = ws-pat-chart-nbr-2;
                && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_2_grp).Trim()
            // 	 )
                 )
            //      and  mrn-is-chedoke;
                    && Util.Str(mrn_site).Equals(mrn_is_chedoke)
            //     then;
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_2_grp = objTp_pat_mstr_rec.tp_pat_id_no;
                pat_chart_1st_char2_chld = Util.Str(ws_pat_chart_nbr_2_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder2_chld = Util.Str(ws_pat_chart_nbr_2_grp).PadRight(10).Substring(1, 9);
            }

            //if ( tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char3_chld) + Util.Str(pat_chart_remainder3_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
                  // 	  and tp-pat-id-no      not = ws-pat-chart-nbr-3;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_3_grp).Trim()
            // 	 )
                 )
            //      and  mrn-is-henderson;
                 && Util.Str(mrn_site).Equals(mrn_is_henderson)
            //     then;
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_3_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
                pat_chart_1st_char3_chld = Util.Str(ws_pat_chart_nbr_3_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder3_chld = Util.Str(ws_pat_chart_nbr_3_grp).PadRight(10).Substring(1, 9);
            }

            //if (tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char4_chld) + Util.Str(pat_chart_remainder4_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
                  // 	  and tp-pat-id-no      not = ws-pat-chart-nbr-4;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_4_grp).Trim()
            // 	 )
                 )
            //      and  mrn-is-general;
                    && Util.Str(mrn_site).Equals(mrn_is_general)
            //     then
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_4_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
                pat_chart_1st_char4_chld = Util.Str(ws_pat_chart_nbr_4_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder4_chld = Util.Str(ws_pat_chart_nbr_4_grp).PadRight(10).Substring(1, 9);
            }

            // if  (tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char5_chld) + Util.Str(pat_chart_remainder5_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
                  // 	  and tp-pat-id-no      not = ws-pat-chart-nbr-5;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_5_grp).Trim()
                 // 	 )
                 )
                   //      and  mrn-is-stjoes;
                   && Util.Str(mrn_site).Equals(mrn_is_stjoes)
           //     then
           )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_5_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
                pat_chart_1st_char5_chld = Util.Str(ws_pat_chart_nbr_5_grp).PadRight(11).Substring(0, 1);
                pat_chart_remainder5_chld = Util.Str(ws_pat_chart_nbr_5_grp).PadRight(11).Substring(1, 10);
            }

            ws_rma_chart_nbr_grp = ws_pat_chart_nbr_grp;
            ws_rma_chart_site_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(0, 1);
            ws_rma_chart_2_4_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(1, 3);
            ws_rma_chart_5_11_grp = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 7);
            ws_rma_chart_5_9_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 5);
            ws_rma_chart_10_11_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(9, 2);

            // if (tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char_chld) + Util.Str(pat_chart_remainder_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
            // 	  and tp-pat-id-no      not = ws-pat-chart-nbr;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_grp).Trim()
            // 	  and ws-rma-chart-site not = 'M';
                  && !Util.Str(ws_rma_chart_site_chld).ToUpper().Equals("M")
            // 	 )
                 )
            //      and  mrn-is-West-Lincoln;
                    && Util.Str(mrn_site).Equals(mrn_is_West_Lincoln)
            //     then;
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
                pat_chart_1st_char_chld = Util.Str(ws_pat_chart_nbr_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder_chld = Util.Str(ws_pat_chart_nbr_grp).PadRight(10).Substring(1, 9);
            }

            ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char2_chld) + Util.Str(pat_chart_remainder2_chld);
            ws_rma_chart_nbr_grp = ws_pat_chart_nbr_2_grp;
            ws_rma_chart_site_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(0, 1);
            ws_rma_chart_2_4_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(1, 3);
            ws_rma_chart_5_11_grp = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 7);
            ws_rma_chart_5_9_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 5);
            ws_rma_chart_10_11_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(9, 2);

            // if (tp-pat-id-no  not = spaces;
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
            // 	  and tp-pat-id-no      not = ws-pat-chart-nbr-2;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_2_grp).Trim()
            // 	  and ws-rma-chart-site not = 'K';
                  && !Util.Str(ws_rma_chart_site_chld).ToUpper().Equals("K")
            // 	 )
                 )
            //      and  mrn-is-Bay-Area;
                   && Util.Str(mrn_site).Equals(mrn_is_Bay_Area)
            //     then
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_2_grp = objTp_pat_mstr_rec.tp_pat_id_no;
                pat_chart_1st_char2_chld = Util.Str(ws_pat_chart_nbr_2_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder2_chld = Util.Str(ws_pat_chart_nbr_2_grp).PadRight(10).Substring(1, 9);
            }

            ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char4_chld) + Util.Str(pat_chart_remainder4_chld);
            ws_rma_chart_nbr_grp = ws_pat_chart_nbr_4_grp;
            ws_rma_chart_site_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(0, 1);
            ws_rma_chart_2_4_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(1, 3);
            ws_rma_chart_5_11_grp = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 7);
            ws_rma_chart_5_9_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 5);
            ws_rma_chart_10_11_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(9, 2);
            ws_key_pat_mstr_grp = Util.Str(ws_pat_i_key_chld).PadRight(1) + Util.Str(ws_pat_con_nbr_chld).PadLeft(2, '0') + Util.Str(ws_pat_i_nbr_chld).PadLeft(12, '0') + new string(' ', 1);
            x_key_pat_mstr_grp = ws_key_pat_mstr_grp;
            x_key_pat_mstr_dtl_grp = x_key_pat_mstr_grp;
            x_pat_i_key = Util.Str(x_key_pat_mstr_dtl_grp).PadRight(16).Substring(0, 1);
            x_pat_con_nbr = Util.NumInt(Util.Str(x_key_pat_mstr_dtl_grp).PadRight(16).Substring(1, 2));
            x_pat_i_nbr = Util.NumInt(Util.Str(x_key_pat_mstr_dtl_grp).PadRight(16).Substring(3, 12));
            x_filler = Util.Str(x_key_pat_mstr_dtl_grp).PadRight(16).Substring(15, 1);
            x_key_pat_mstr_r_grp = x_key_pat_mstr_grp;
            x_key_pat_mstr_test_grp = Util.Str(x_key_pat_mstr_r_grp).Substring(4, 11);
            x_ikey_1_digit_chld = x_key_pat_mstr_test_grp.Substring(0, 1);
            x_ikey_2_11_digits_chld = x_key_pat_mstr_test_grp.Substring(1, 10);
            x_ikey_3_11_digits_chld = x_key_pat_mstr_test_grp.Substring(2, 9);

            // if ( tp-pat-id-no      not = spaces;
            ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char4_chld) + Util.Str(pat_chart_remainder4_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
            // 	  and tp-pat-id-no      not = ws-pat-chart-nbr-4;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_4_grp).Trim()
            // 	  and (  (     ws-rma-chart-site not = '0';
                  && ((Util.Str(ws_rma_chart_site_chld) != "0"
            //                    and ws-rma-chart-2-4  not = '001' and not = '005';
                                  && Util.Str(ws_rma_chart_2_4_chld) != "001" && Util.Str(ws_rma_chart_2_4_chld) != "005"
            // 		 )
                     )
            // 	       or ws-pat-chart-nbr-4 = x-key-pat-mstr;
                       || Util.Str(ws_pat_chart_nbr_4_grp) == Util.Str(x_key_pat_mstr_grp)
            // 	      )
                      )
            // 	 )
                 )
            //      and (    mrn-is-Haldimand-War;
                    && (Util.Str(mrn_site).Equals(mrn_is_Haldimand_War)
            // 	  or  mrn-is-West-Haldimand;
                  || Util.Str(mrn_site).Equals(mrn_is_West_Haldimand)
            // 	  or  mrn-is-Stpeter;
                  || Util.Str(mrn_site).Equals(mrn_is_Stpeter)
            //          )
                        )
            //     then
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_4_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
                pat_chart_1st_char4_chld = Util.Str(ws_pat_chart_nbr_4_grp).PadRight(10).Substring(0, 1);
                pat_chart_remainder4_chld = Util.Str(ws_pat_chart_nbr_4_grp).PadRight(10).Substring(1, 9);
            }

            ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char5_chld) + Util.Str(pat_chart_remainder5_chld);
            ws_rma_chart_nbr_grp = ws_pat_chart_nbr_5_grp;
            ws_rma_chart_site_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(0, 1);
            ws_rma_chart_2_4_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(1, 3);
            ws_rma_chart_5_11_grp = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 7);
            ws_rma_chart_5_9_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(4, 5);
            ws_rma_chart_10_11_chld = Util.Str(ws_rma_chart_nbr_grp).PadRight(11).Substring(9, 2);

            // if (tp-pat-id-no not = spaces;
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_id_no)
            // 	  and tp-pat-id-no      not = ws-pat-chart-nbr-5;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).Trim() != Util.Str(ws_pat_chart_nbr_5_grp).Trim()
            // 	  and (   ws-rma-chart-site not = 'J';
                  && (Util.Str(ws_rma_chart_site_chld) != "J"
            //                or  ws-rma-chart-10-11 not numeric;
                              || (Util.Str(ws_rma_chart_10_11_chld).Trim().Length < 2 || !Util.IsNumeric(ws_rma_chart_10_11_chld))
            //               )
                             )
            // 	 )
                 )
            //      and mrn-is-Stjoe-Brant;
                    && Util.Str(mrn_site).Equals(mrn_is_Stjoe_Brant)
            //     then
            )
            {
                pat_change_flag = "Y";
                ws_pat_chart_nbr_5_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
                pat_chart_1st_char_chld = Util.Str(ws_pat_chart_nbr_5_grp).PadRight(11).Substring(0, 1);
                pat_chart_remainder_chld = Util.Str(ws_pat_chart_nbr_5_grp).PadRight(11).Substring(1, 10);
            }

            // if (tp-pat-ohip-no   not = spaces;
            ws_pat_ohip_mmyy_grp = Util.Str(ws_pat_ohip_nbr_chld);
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_ohip_no)
            // 	  and tp-pat-ohip-no   not = ws-pat-ohip-mmyy;
                  && Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no).Trim() != Util.Str(ws_pat_ohip_mmyy_grp).Trim()
            // 	 )
                 )
            //     then
            )
            {
                pat_change_flag = "Y";
                ws_pat_ohip_mmyy_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no);
                ws_pat_ohip_out_prov_grp = Util.Str(ws_pat_ohip_mmyy_grp).PadLeft(12, '0');
                ws_pat_ohip_nbr_chld = Util.NumInt(ws_pat_ohip_out_prov_grp);
                ws_pat_ohip_nbr_r_alpha = Util.Str(ws_pat_ohip_nbr_chld).PadLeft(8, '0');
                ws_pat_ohip_nbr_MB_def = Util.Str(ws_pat_ohip_nbr_chld).PadLeft(8, '0');
                ws_pat_ohip_nbr_MB_chld = Util.NumInt(Util.Str(ws_pat_ohip_nbr_MB_def).Substring(0, 6));
                // filler
                ws_pat_ohip_nbr_NT_def_grp = Util.Str(ws_pat_ohip_nbr_chld).PadLeft(8, '0');
                ws_pat_ohip_nbr_NT_1_char_chld = Util.Str(ws_pat_ohip_nbr_NT_def_grp).Substring(0, 1);
                ws_pat_ohip_nbr_NT_chld = Util.NumInt(Util.Str(ws_pat_ohip_nbr_NT_def_grp).Substring(1, 7));
                ws_pat_mm_chld = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(7, 2));
                ws_pat_yy_chld = Util.NumInt(ws_pat_ohip_out_prov_grp.Substring(9, 2));
            }
        }

        private async Task dc0_80()
        {
            Util.Trakker(++ctr, "dc0_80");

            //  if tp-pat-health-65-ind = " "  then;           
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_65_ind))
            {
                objTp_pat_mstr_rec.tp_pat_health_65_ind = "N";
            }


            // If (version-cd-changed;
            if ((Util.Str(flag_change_version_cd).Equals(version_cd_changed)
            //               and old-version-cd-doesnt-match;
                             && Util.Str(flag_old_version_cd).Equals(old_version_cd_doesnt_match)
            //              );
                            )
            //         or   (    birth-date-changed;
                       || (Util.Str(flag_birth_date_change).Equals(birth_date_changed)
                             //               and old-birth-date-doesnt-match;
                             && Util.Str(flag_old_birth_date).Equals(old_birth_date_doesnt_match)
                            //              );
                            )
            //     then;
            )
            {
                //         perform yy0-process-pat-elig-change thru  yy0-99-exit;
                await yy0_process_pat_elig_change();
                await yy0_99_exit();
                //         perform wa0-write-audit-rpt-of-update  thru  wa0-99-exit.
                await wa0_write_audit_rpt_of_update();
                await wa0_99_exit();
            }

            // if tp-pat-sex              not = ws-pat-sex;
            if (!Util.Str(objTp_pat_mstr_rec.tp_pat_sex).Trim().Equals(Util.Str(ws_pat_sex).Trim())
            // 	and  tp-pat-sex		     not = spaces;
                && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_sex)
            //     then;
            )
            {
                ws_pat_sex = Util.Str(objTp_pat_mstr_rec.tp_pat_sex);
                pat_change_flag = "Y";
            }

            // if  (    tp-pat-prov             not = ws-pat-prov-cd;
            if ((Util.Str(objTp_pat_mstr_rec.tp_pat_prov).Trim() != Util.Str(ws_pat_prov_cd).Trim()
            //          and tp-pat-prov             not = spaces;
                        && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_prov)
            //          and tp-pat-prov             not = '.';
                        && Util.Str(objTp_pat_mstr_rec.tp_pat_prov).Trim() != "."
            //          and tp-pat-prov             not = '..';
                        && Util.Str(objTp_pat_mstr_rec.tp_pat_prov).Trim() != ".."
            //         );
                       )
            //     then;
            )
            {
                ws_pat_prov_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
                ws_subscr_prov_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
                pat_change_flag = "Y";
            }

            // if  tp-pat-postal-code      	not = ws-subscr-postal-cd;
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code).Trim() != Util.Str(ws_subscr_postal_cd).Trim()
            //     and tp-pat-postal-code 		not = spaces;
                   && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_postal_code)
            //     and tp-pat-postal-code 		not = '.';
                   && Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code).Trim() != "."
            //     then;
            )
            {
                ws_subscr_postal_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code);
                pat_change_flag = "Y";
            }

            // if tp-pat-phone-no         not = ws-pat-phone-nbr;
            // ws_pat_phone_nbr_grp = Util.Str(ws_pat_phone_nbr_first3_chld).PadLeft(3, '0') + Util.Str(ws_pat_phone_nbr_last4_chld).PadLeft(4, '0') + Util.Str(ws_pat_phone_nbr_remainder_chld);
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no).Trim() != Util.Str(ws_pat_phone_nbr_grp).Trim()
            //        and   tp-pat-phone-no	     not = spaces;
                      && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_phone_no)
            //        and   tp-pat-phone-no	     not = '.';
                      && Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no).Trim() != "."
            //     then;
            )
            {
                ws_pat_phone_nbr_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no);
                ws_pat_phone_nbr_first3_chld = Util.NumInt(Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(0, 3));
                ws_pat_phone_nbr_last4_chld = Util.NumInt(Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(3, 4));
                ws_pat_phone_nbr_remainder_chld = Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(7);
                pat_change_flag = "Y";
            }

            // if  tp-pat-street-addr      not = ws-subscr-addr1;
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr).Trim() != Util.Str(ws_subscr_addr1).Trim()
            //     and  tp-pat-street-addr      not = spaces;
                   && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_street_addr)
            //     and  tp-pat-street-addr      not = '.';
                   && Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr).Trim() != "."
            //     then;
            )
            {
                ws_subscr_addr1 = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr);
                pat_change_flag = "Y";
            }

            // if  tp-pat-street-addr2     not = ws-subscr-addr2;
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr2).Trim() != Util.Str(ws_subscr_addr2).Trim()
            //     and  tp-pat-street-addr2     not = spaces;
                   && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_street_addr2)
            //     and  tp-pat-street-addr2     not = '.';
                   && Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr2).Trim() != "."
            //     then;
            )
            {
                ws_subscr_addr2 = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr2);
                pat_change_flag = "Y";
            }

            // if  tp-pat-city             not = ws-subscr-addr3;
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_city).Trim() != Util.Str(ws_subscr_addr3).Trim()
            //     and  tp-pat-city             not = spaces;
                   && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_city)
            //     and  tp-pat-city             not = '.';
                   && Util.Str(objTp_pat_mstr_rec.tp_pat_city).Trim() != "."
            //    then;
            )
            {
                ws_subscr_addr3 = Util.Str(objTp_pat_mstr_rec.tp_pat_city);
                pat_change_flag = "Y";
            }

            // if  tp-pat-last-name	     not = ws-pat-surname then            
            if (!Util.Str(objTp_pat_mstr_rec.tp_pat_last_name).Trim().Equals(Util.Str(ws_pat_surname).Trim()))
            {
                ws_pat_surname = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);
                ws_pat_acronym_first6_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name).PadRight(24).Substring(0, 6);
                pat_change_flag = "Y";
            }

            // if  tp-pat-first-name       not = ws-pat-given-name then            
            if (!Util.Str(objTp_pat_mstr_rec.tp_pat_first_name).Trim().Equals(Util.Str(ws_pat_given_name).Trim()))
            {
                ws_pat_given_name = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);
                ws_pat_acronym_last3_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name).PadRight(17).Substring(0, 3);
                ws_pat_init1_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name).Substring(0, 1);
                ws_pat_init_grp = ws_pat_init1_chld + ws_pat_init2_chld + ws_pat_init3_chld;
                pat_change_flag = "Y";
            }

            // if  tp-pat-health-65-ind    not = ws-pat-health-65-ind;
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_health_65_ind).Trim() != Util.Str(ws_pat_health_65_ind).Trim()
            //     and tp-pat-health-65-ind    not = spaces then;            
                   && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_65_ind)
            )
            {
                ws_pat_health_65_ind = Util.Str(objTp_pat_mstr_rec.tp_pat_health_65_ind);
                pat_change_flag = "Y";
            }

            // if  tp-pat-expiry-date      not = ws-pat-expiry-date;
            ws_pat_expiry_date_grp = Util.Str(ws_pat_expiry_yy_chld).PadLeft(2, '0') + Util.Str(ws_pat_expiry_mm_chld).PadLeft(2, '0');
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_expiry_date).Trim() != Util.Str(ws_pat_expiry_date_grp).Trim()
            //     and   tp-pat-expiry-date	     not = spaces;
                   && !string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_expiry_date)
            //     and   tp-pat-expiry-date      not = '0000';
                   && Util.Str(objTp_pat_mstr_rec.tp_pat_expiry_date).Trim() != "0000"
            //     then;
            )
            {
                ws_pat_expiry_date_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_expiry_date);
                ws_pat_expiry_yy_chld = Util.NumInt(Util.Str(ws_pat_expiry_date_grp).PadRight(4).Substring(0, 2));
                ws_pat_expiry_mm_chld = Util.NumInt(Util.Str(ws_pat_expiry_date_grp).PadRight(4).Substring(2, 2));
                pat_change_flag = "Y";
            }

            // if pat-change then            
            if (Util.Str(pat_change_flag).Equals(pat_change))
            {
                //     objPat_mstr_rec.pat_mstr_rec = ws_pat_mstr_rec;

                await move_ws_pat_mstr_rec_to_pat_mstr_rec();
                feedback_pat_mstr = Util.Str(ws_feedback_pat_mstr);
                //   perform yc6-rewrite-patient  thru yc6-99-exit;

                await yc6_rewrite_patient();

                await yc6_99_exit();
                //    add 1                        to    ctr-pat-mstr-rewrites;
                ctr_pat_mstr_rewrites++;
            }
            else
            {
                //    add 1                        to    ctr-pat-mstr-no-update.;
                ctr_pat_mstr_no_update++;
            }


            //if ( tp-pat-health-nbr not = spaces
            if ((!string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_nbr)
            // 	   and tp-pat-health-nbr not = zero
                   && Util.NumLongInt(objTp_pat_mstr_rec.tp_pat_health_nbr) > 0
                   // 	   )
                   )
            //      and (    ws-tp-pat-health-nbr = spaces;
                    && (string.IsNullOrWhiteSpace(ws_tp_pat_health_nbr)
            // 	 and ws-tp-pat-health-nbr not = zero;
                 && Util.NumLongInt(ws_tp_pat_health_nbr) > 0
                 // 	 )
                 )
            //     then;
            )
            {
                objPat_mstr_rec.PAT_HEALTH_NBR = Util.NumLongInt(objTp_pat_mstr_rec.tp_pat_health_nbr);
                //         perform yb0-3-read-hc-pat-mstr   thru yb0-3-99-exit;
                await yb0_3_read_hc_pat_mstr();
                await yb0_3_99_exit();

                //         if (   ws-pat-health-nbr = spaces;
                if ((string.IsNullOrWhiteSpace(ws_pat_health_nbr.ToString())
                // 	           or ws-pat-health-nbr = zero );
                      || ws_pat_health_nbr == 0)
                // 	          and pat-not-exist;
                        && pat_flag.Equals(pat_not_exist)
                //         then;
                )
                {
                    ws_pat_health_nbr = Util.NumLongInt(objTp_pat_mstr_rec.tp_pat_health_nbr);
                    //             objPat_mstr_rec.pat_mstr_rec = ws_pat_mstr_rec;
                    await move_ws_pat_mstr_rec_to_pat_mstr_rec();
                    //             perform yc6-rewrite-patient   thru yc6-99-exit;
                    await yc6_rewrite_patient();

                    await yc6_99_exit();
                    err_ind = 66;
                    //             perform xd0-write-tp-warning-report  thru xd0-99-exit;
                    await xd0_write_tp_warning_report();
                    await xd0_99_exit();
                }
                else
                {
                    err_ind = 50;
                    //             perform xa0-write-tp-error-report   thru xa0-99-exit;
                    await xa0_write_tp_error_report();
                    await xa0_99_exit();
                    // 	        subtract 1			 from ctr-error-rpt-writes.;
                    ctr_error_rpt_writes--;
                }
            }
        }

        private async Task dc0_99_exit()
        {
            Util.Trakker(++ctr, "dc0_99_exit");

            //     exit.;
        }

        private async Task dd0_check_version_cd()
        {
            Util.Trakker(++ctr, "dd0_check_version_cd");

            //   if hold-version-cd-1 = ' ' then next sentence                 
            if (string.IsNullOrWhiteSpace(hold_version_cd_1_chld))
            {
                // next sentence                 
            }
            //   else if hold-version-cd-1 = 'a' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("a"))
            {
                // move 'A' to hold-version-cd-1 
                hold_version_cd_1_chld = "A";
            }
            //   else if hold-version-cd-1 = 'b' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("b"))
            {
                // move 'B' to hold-version-cd-1 
                hold_version_cd_1_chld = "B";
            }
            //   else if hold-version-cd-1 = 'c' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("c"))
            {
                // move 'C' to hold-version-cd-1 
                hold_version_cd_1_chld = "C";
            }
            //   else if hold-version-cd-1 = 'd' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("d"))
            {
                // move 'D' to hold-version-cd-1 
                hold_version_cd_1_chld = "D";
            }
            //   else if hold-version-cd-1 = 'e' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("e"))
            {
                // move 'E' to hold-version-cd-1 
                hold_version_cd_1_chld = "E";
            }
            //   else if hold-version-cd-1 = 'f' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("f"))
            {
                // move 'F' to hold-version-cd-1 
                hold_version_cd_1_chld = "F";
            }
            //   else if hold-version-cd-1 = 'g' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("g"))
            {
                // move 'G' to hold-version-cd-1 
                hold_version_cd_1_chld = "G";
            }
            //   else if hold-version-cd-1 = 'h' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("h"))
            {
                // move 'H' to hold-version-cd-1 
                hold_version_cd_1_chld = "H";
            }
            //   else if hold-version-cd-1 = 'i' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("i"))
            {
                // move 'I' to hold-version-cd-1 
                hold_version_cd_1_chld = "I";
            }
            //   else if hold-version-cd-1 = 'j' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("j"))
            {
                // move 'J' to hold-version-cd-1 
                hold_version_cd_1_chld = "J";
            }
            //   else if hold-version-cd-1 = 'k' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("k"))
            {
                // move 'K' to hold-version-cd-1 
                hold_version_cd_1_chld = "K";
            }
            //   else if hold-version-cd-1 = 'l' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("l"))
            {
                // move 'L' to hold-version-cd-1 
                hold_version_cd_1_chld = "L";
            }
            //   else if hold-version-cd-1 = 'm' then move 
            else if (Util.Str(hold_version_cd_1_chld).Equals("m"))
            {
                // 'M' to hold-version-cd-1 
                hold_version_cd_1_chld = "M";
            }
            //   else if hold-version-cd-1 = 'n' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("n"))
            {
                // move 'N' to hold-version-cd-1 
                hold_version_cd_1_chld = "N";
            }
            //   else if hold-version-cd-1 = 'o' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("o"))
            {
                // move 'O' to hold-version-cd-1 
                hold_version_cd_1_chld = "O";
            }
            //   else ;if hold-version-cd-1 = 'p' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("p"))
            {
                // move 'P' to hold-version-cd-1 
                hold_version_cd_1_chld = "P";
            }
            //   else if hold-version-cd-1 = 'q' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("q"))
            {
                // move 'Q' to hold-version-cd-1 
                hold_version_cd_1_chld = "Q";
            }
            //   else if hold-version-cd-1 = 'r' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("r"))
            {
                // move 'R' to hold-version-cd-1 
                hold_version_cd_1_chld = "R";
            }
            //   else if hold-version-cd-1 = 's' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("s"))
            {
                // move 'S' to hold-version-cd-1 
                hold_version_cd_1_chld = "S";
            }
            //   else if hold-version-cd-1 = 't' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("t"))
            {
                // move 'T' to hold-version-cd-1 
                hold_version_cd_1_chld = "T";
            }
            //   else if hold-version-cd-1 = 'u' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("u"))
            {
                // move 'U' to hold-version-cd-1 
                hold_version_cd_1_chld = "U";
            }
            //   else if hold-version-cd-1 = 'v' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("v"))
            {
                // move 'V' to hold-version-cd-1 
                hold_version_cd_1_chld = "V";
            }
            //   else if hold-version-cd-1 = 'w' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("w"))
            {
                // move 'W' to hold-version-cd-1 
                hold_version_cd_1_chld = "W";
            }
            //   else if hold-version-cd-1 = 'x' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("x"))
            {
                // move 'X' to hold-version-cd-1 
                hold_version_cd_1_chld = "X";
            }
            //   else if hold-version-cd-1 = 'y' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("y"))
            {
                // move 'Y' to hold-version-cd-1 
                hold_version_cd_1_chld = "Y";
            }
            //   else if hold-version-cd-1 = 'z' then 
            else if (Util.Str(hold_version_cd_1_chld).Equals("z"))
            {
                // move 'Z' to hold-version-cd-1.;
                hold_version_cd_1_chld = "Z";
            }


            //   if hold-version-cd-2 = ' ' then 
            if (string.IsNullOrWhiteSpace(hold_version_cd_2_chld))
            {
                // next sentence       
            }
            //   else if hold-version-cd-2 = 'a' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("a"))
            {
                // move 'A' to hold-version-cd-2
                hold_version_cd_2_chld = "A";
            }
            //   else if hold-version-cd-2 = 'b' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("b"))
            {
                // move 'B' to hold-version-cd-2 
                hold_version_cd_2_chld = "B";
            }
            //   else if hold-version-cd-2 = 'c' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("c"))
            {
                // move 'C' to hold-version-cd-2 
                hold_version_cd_2_chld = "C";
            }
            //   else if hold-version-cd-2 = 'd' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("d"))
            {
                // move 'D' to hold-version-cd-2 
                hold_version_cd_2_chld = "D";
            }
            //   else if hold-version-cd-2 = 'e' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("e"))
            {
                // move 'E' to hold-version-cd-2 
                hold_version_cd_2_chld = "E";
            }
            //   else if hold-version-cd-2 = 'f' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("f"))
            {
                // move 'F' to hold-version-cd-2 
                hold_version_cd_2_chld = "F";
            }
            //   else if hold-version-cd-2 = 'g' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("g"))
            {
                // move 'G' to hold-version-cd-2 
                hold_version_cd_2_chld = "G";
            }
            //   else if hold-version-cd-2 = 'h' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("h"))
            {
                // move 'H' to hold-version-cd-2 
                hold_version_cd_2_chld = "H";
            }
            //   else if hold-version-cd-2 = 'i' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("i"))
            {
                // move 'I' to hold-version-cd-2 
                hold_version_cd_2_chld = "I";
            }
            //   else if hold-version-cd-2 = 'j' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("j"))
            {
                // move 'J' to hold-version-cd-2 
                hold_version_cd_2_chld = "J";
            }
            //   else if hold-version-cd-2 = 'k' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("k"))
            {
                // move 'K' to hold-version-cd-2 
                hold_version_cd_2_chld = "K";
            }
            //   else if hold-version-cd-2 = 'l' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("l"))
            {
                // move 'L' to hold-version-cd-2 
                hold_version_cd_2_chld = "L";
            }
            //   else if hold-version-cd-2 = 'm' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("m"))
            {
                // move 'M' to hold-version-cd-2 
                hold_version_cd_2_chld = "M";
            }
            //   else if hold-version-cd-2 = 'n' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("n"))
            {
                // move 'N' to hold-version-cd-2 
                hold_version_cd_2_chld = "N";
            }
            //   else if hold-version-cd-2 = 'o' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("o"))
            {
                // move 'O' to hold-version-cd-2 
                hold_version_cd_2_chld = "O";
            }
            //   else if hold-version-cd-2 = 'p' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("p"))
            {
                // move 'P' to hold-version-cd-2 
                hold_version_cd_2_chld = "P";
            }
            //   else if hold-version-cd-2 = 'q' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("q"))
            {
                // move 'Q' to hold-version-cd-2 
                hold_version_cd_2_chld = "Q";
            }
            //   else if hold-version-cd-2 = 'r' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("r"))
            {
                // move 'R' to hold-version-cd-2 
                hold_version_cd_2_chld = "R";
            }
            //   else if hold-version-cd-2 = 's' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("s"))
            {
                // move 'S' to hold-version-cd-2 
                hold_version_cd_2_chld = "S";
            }
            //   else if hold-version-cd-2 = 't' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("t"))
            {
                // move 'T' to hold-version-cd-2 
                hold_version_cd_2_chld = "T";
            }
            //   else if hold-version-cd-2 = 'u' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("u"))
            {
                // move 'U' to hold-version-cd-2 
                hold_version_cd_2_chld = "U";
            }
            //   else if hold-version-cd-2 = 'v' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("v"))
            {
                // move 'V' to hold-version-cd-2 
                hold_version_cd_2_chld = "V";
            }
            //   else if hold-version-cd-2 = 'w' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("w"))
            {
                // move 'W' to hold-version-cd-2 
                hold_version_cd_2_chld = "W";
            }
            //   else if hold-version-cd-2 = 'x' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("x"))
            {
                // move 'X' to hold-version-cd-2 
                hold_version_cd_2_chld = "X";
            }
            //   else if hold-version-cd-2 = 'y' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("y"))
            {
                // move 'Y' to hold-version-cd-2 
                hold_version_cd_2_chld = "Y";
            }
            //   else if hold-version-cd-2 = 'z' then 
            else if (Util.Str(hold_version_cd_2_chld).Equals("z"))
            {
                //move 'Z' to hold-version - cd - 2.;
                hold_version_cd_2_chld = "Z";
            }


            hold_version_cd_grp = Util.Str(hold_version_cd_1_chld) + Util.Str(hold_version_cd_2_chld);
            objTp_pat_mstr_rec.tp_pat_version_cd = hold_version_cd_grp;


            // if   hold-version-cd = spaces;
            if (string.IsNullOrWhiteSpace(hold_version_cd_grp)
            // 	or  (     hold-version-cd-2 = spaces;
                || (string.IsNullOrWhiteSpace(hold_version_cd_2_chld)
            // 	     and (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z');
                     && (Util.Str(hold_version_cd_1_chld).ToUpper().CompareTo("A") >= 0 && Util.Str(hold_version_cd_1_chld).ToUpper().CompareTo("Z") <= 0)
            // 	    );
                    )
            // 	or  (    (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z');
                || ((Util.Str(hold_version_cd_1_chld).ToUpper().CompareTo("A") >= 0 && Util.Str(hold_version_cd_1_chld).ToUpper().CompareTo("Z") <= 0)
            // 	     and (hold-version-cd-2 >= 'A' and hold-version-cd-2 <= 'Z');
                     && (Util.Str(hold_version_cd_2_chld).ToUpper().CompareTo("A") >= 0 && Util.Str(hold_version_cd_2_chld).ToUpper().CompareTo("Z") <= 0)
            // 	    );
                    )
            )
            {
                //   then;
                // 	     next sentence;
            }
            else
            {
                edit_flag = "N";
                err_ind = 17;
            }
        }

        private async Task dd0_99_exit()
        {
            Util.Trakker(++ctr, "dd0_99_exit");

            //     exit.;
        }

        private async Task fa0_build_key_pat_mstr()
        {
            Util.Trakker(++ctr, "fa0_build_key_pat_mstr");

            hold_ohip_mmyy_grp = "";
            hold_ohip_no_chld = string.Empty;
            hold_ohip_mm_chld = string.Empty;
            hold_ohip_yy_chld = string.Empty;


            hold_chart_no_grp = "";
            hold_chart_id_no = string.Empty;


            hold_orig_hc_feedback = "";
            hold_orig_od_feedback = "";
            hold_orig_chrt_feedback = "";
            flag_ohip_vs_chart = "";

            hold_health_nbr = 0;

            // if ws-tp-pat-health-nbr not = spaces and  ws-tp-pat-health-nbr not = zero  then            
            if (!string.IsNullOrWhiteSpace(ws_tp_pat_health_nbr) && (Util.IsNumeric(ws_tp_pat_health_nbr) && Util.NumLongInt(ws_tp_pat_health_nbr) != 0))
            {
                hold_health_nbr = Util.NumLongInt(ws_tp_pat_health_nbr);
                flag_ohip_vs_chart = "H ";
                objPat_mstr_rec.PAT_HEALTH_NBR = hold_health_nbr; ;
                //     perform yb0-3-read-hc-pat-mstr  	thru yb0-3-99-exit;
                await yb0_3_read_hc_pat_mstr();
                await yb0_3_99_exit();
            }
            // else if ws-tp-pat-ohip-no not = spaces then            
            else if (!string.IsNullOrWhiteSpace(ws_tp_pat_ohip_no))
            {
                hold_ohip_no_chld = ws_tp_pat_ohip_no;
                hold_ohip_mm_chld = ws_tp_pat_birth_mm.ToString();
                hold_ohip_yy_chld = ws_tp_pat_birth_yy_last_2_chld.ToString();
                flag_ohip_vs_chart = "O ";
                
                //objPat_mstr_rec.PAT_DIRECT_ALPHA                      
                hold_ohip_mmyy_grp = Util.Str(hold_ohip_no_chld).PadRight(8) + Util.Str(hold_ohip_mm_chld).PadRight(2) + Util.Str(hold_ohip_yy_chld).PadRight(2) + new string(' ', 3);
                objPat_mstr_rec.PAT_DIRECT_ALPHA = Util.Str(hold_ohip_mmyy_grp).Substring(0, 3);
                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(3, 2));
                objPat_mstr_rec.PAT_DIRECT_MM = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(5, 2));
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(7, 2));
                //     perform yb0-2-read-od-pat-mstr  	thru yb0-2-99-exit;
                await yb0_2_read_od_pat_mstr();
                await yb0_2_99_exit();
            }
            else
            {
                hold_chart_id_no = ws_tp_pat_id_no;
                flag_ohip_vs_chart = "C ";
                //   perform Yb0-5-read-chrt-pat-mstr 	thru yb0-5-99-exit.;                
                await yb0_5_read_chrt_pat_mstr();
                await yb0_5_99_exit();
            }


            // if  ( ws-tp-pat-health-nbr not = spaces;
            if ((!string.IsNullOrWhiteSpace(ws_tp_pat_health_nbr)
            // 	     and ws-tp-pat-health-nbr not = zero);
                     && (Util.IsNumeric(ws_tp_pat_health_nbr) && Util.NumLongInt(ws_tp_pat_health_nbr) != 0))
            //       and ws-tp-pat-ohip-no        not = spaces;
                     && !string.IsNullOrWhiteSpace(ws_tp_pat_ohip_no)
            //       and ws-tp-pat-id-no          not = spaces;
                    && !string.IsNullOrWhiteSpace(ws_tp_pat_id_no)
            //      then;
            )
            {
                flag_ohip_vs_chart = "AL";
                hold_chart_id_no = ws_tp_pat_id_no;
                hold_ohip_no_chld = ws_tp_pat_ohip_no;
            }
            // else if (ws-tp-pat-health-nbr not = spaces and;
            else if ((!string.IsNullOrWhiteSpace(ws_tp_pat_health_nbr) &&
            //            ws-tp-pat-health-nbr not = zero);
                          (Util.IsNumeric(ws_tp_pat_health_nbr) && Util.NumLongInt(ws_tp_pat_health_nbr) != 0))
            //            and ws-tp-pat-ohip-no not = spaces then            
                          && !string.IsNullOrWhiteSpace(ws_tp_pat_ohip_no)
            )
            {
                flag_ohip_vs_chart = "HO";
                hold_ohip_no_chld = Util.Str(ws_tp_pat_ohip_no);
            }
            // else if (ws-tp-pat-health-nbr not = spaces and;
            else if ((!string.IsNullOrWhiteSpace(ws_tp_pat_health_nbr) &&
                           //                ws-tp-pat-health-nbr not = zero);
                           (Util.IsNumeric(ws_tp_pat_health_nbr) && Util.NumLongInt(ws_tp_pat_health_nbr) != 0))
            //                and ws-tp-pat-id-no not = spaces;
                             && !string.IsNullOrWhiteSpace(ws_tp_pat_id_no)
            //     then;
            )
            {
                flag_ohip_vs_chart = "HC";
                hold_chart_id_no = ws_tp_pat_id_no;
            }
            // else if (ws-tp-pat-ohip-no not = spaces;
            else if ((!string.IsNullOrWhiteSpace(ws_tp_pat_ohip_no)
            //                     and ws-tp-pat-id-no not = spaces);
                                   && !string.IsNullOrWhiteSpace(ws_tp_pat_id_no))
            //                 then;
            )
            {
                flag_ohip_vs_chart = "OC";
                hold_chart_id_no = ws_tp_pat_id_no;
            }
        }

        private async Task fa0_99_exit()
        {
            Util.Trakker(++ctr, "fa0_99_exit");

            //     exit.;
        }

        private async Task ga0_build_patient()
        {
            Util.Trakker(++ctr, "ga0_build_patient");

            ws_pat_mstr_rec = "";
            await initialize_ws_pat_mstr_rec();

            ws_pat_surname = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);
            ws_pat_acronym_first6_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);

            ws_pat_given_name = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);
            ws_pat_init1_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name).Substring(0, 1);
            ws_pat_acronym_last3_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);

            ws_pat_birth_date_yy_chld = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_yy);
            ws_pat_birth_date_mm_chld = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_mm);
            ws_pat_birth_date_dd_chld = Util.NumInt(objTp_pat_mstr_rec.tp_pat_birth_dd);
            ws_pat_sex = Util.Str(objTp_pat_mstr_rec.tp_pat_sex);
            ws_pat_phone_nbr_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no);
            ws_pat_phone_nbr_first3_chld = Util.NumInt(Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(0, 3));
            ws_pat_phone_nbr_last4_chld = Util.NumInt(Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(3, 4));
            ws_pat_phone_nbr_remainder_chld = Util.Str(ws_pat_phone_nbr_grp).PadRight(20).Substring(7, 13);


            ws_pat_in_out = "O";
            ws_pat_date_last_maint = Util.NumInt(sys_date_long_child);
            ws_pat_nbr_outstanding_claims = 0;

            hold_ohip_mmyy_grp = Util.Str(hold_ohip_no_chld).PadRight(8) + Util.Str(hold_ohip_mm_chld).PadRight(2) + Util.Str(hold_ohip_yy_chld).PadRight(2) + new string(' ', 3);
            ws_pat_ohip_mmyy_grp = hold_ohip_mmyy_grp;
            ws_pat_ohip_out_prov_grp = Util.Str(ws_pat_ohip_mmyy_grp).PadRight(15);
            ws_pat_ohip_nbr_chld = Util.NumInt(Util.Str(ws_pat_ohip_out_prov_grp).Substring(0, 8));
            ws_pat_ohip_nbr_r_alpha = ws_pat_ohip_nbr_chld.ToString();
            ws_pat_ohip_nbr_MB_def_grp = ws_pat_ohip_nbr_chld.ToString();
            ws_pat_ohip_nbr_MB_chld = Util.NumInt(Util.Str(ws_pat_ohip_nbr_MB_def_grp).PadRight(8).Substring(0, 6));
            ws_pat_ohip_nbr_NT_def_grp = ws_pat_ohip_nbr_chld.ToString();
            ws_pat_ohip_nbr_NT_1_char_chld = Util.Str(ws_pat_ohip_nbr_NT_def_grp).PadRight(8).Substring(0, 1);
            ws_pat_ohip_nbr_NT_chld = Util.NumInt(Util.Str(ws_pat_ohip_nbr_NT_def_grp).PadRight(8).Substring(1, 7));
            ws_pat_mm_chld = Util.NumInt(Util.Str(ws_pat_ohip_mmyy_grp).PadRight(15).Substring(8, 2));
            ws_pat_yy_chld = Util.NumInt(Util.Str(ws_pat_ohip_mmyy_grp).PadRight(15).Substring(10, 2));

            ws_pat_ohip_mmyy_r_grp = Util.Str(ws_pat_ohip_mmyy_grp).PadRight(15);
            ws_pat_direct_alpha_grp = ws_pat_ohip_mmyy_r_grp.Substring(0, 3);
            ws_pat_alpha1_chld = ws_pat_direct_alpha_grp.Substring(0, 1);
            ws_pat_alpha2_3_chld = ws_pat_direct_alpha_grp.Substring(1);
            ws_pat_direct_yy = ws_pat_ohip_mmyy_r_grp.Substring(3, 2);
            ws_pat_direct_mm = ws_pat_ohip_mmyy_r_grp.Substring(5, 2);
            ws_pat_direct_dd = ws_pat_ohip_mmyy_r_grp.Substring(7, 2);
            ws_pat_direct_filler = ws_pat_ohip_mmyy_r_grp.Substring(9, 2);

            // if valid-chart-key then            
            if (Util.Str(edit_chart_flag).Equals(valid_chart_key))
            {
                //     if mrn-is-mumc or mrn-is-West-Lincoln then
                if (Util.Str(mrn_site).Equals(mrn_is_mumc) || Util.Str(mrn_site).Equals(mrn_is_West_Lincoln))
                {
                    //          move hold-chart-no		to ws-pat-chart-nbr;
                    hold_chart_no_grp = Util.Str(hold_chart_id_no).PadRight(11);
                    ws_pat_chart_nbr_grp = hold_chart_no_grp;
                    pat_chart_1st_char_chld = Util.Str(ws_pat_chart_nbr_grp).Substring(0, 1);
                    pat_chart_remainder_chld = Util.Str(ws_pat_chart_nbr_grp).Substring(1, 9);
                }
                //     else if mrn-is-chedoke or mrn-is-Bay-Area  then            
                else if (Util.Str(mrn_site).Equals(mrn_is_chedoke) || Util.Str(mrn_site).Equals(mrn_is_Bay_Area))
                {
                    //           move hold-chart-no	to ws-pat-chart-nbr-2;
                    hold_chart_no_grp = Util.Str(hold_chart_id_no).PadRight(11);
                    ws_pat_chart_nbr_2_grp = hold_chart_no_grp;
                    pat_chart_1st_char2_chld = Util.Str(ws_pat_chart_nbr_2_grp).Substring(0, 1);
                    pat_chart_remainder2_chld = Util.Str(ws_pat_chart_nbr_2_grp).Substring(1, 9);
                }
                //     else if mrn-is-henderson then
                else if (Util.Str(mrn_site).Equals(mrn_is_henderson))
                {
                    // 	         move hold-chart-no	to ws-pat-chart-nbr-3;
                    hold_chart_no_grp = Util.Str(hold_chart_id_no).PadRight(11);
                    ws_pat_chart_nbr_3_grp = hold_chart_no_grp;
                    pat_chart_1st_char3_chld = Util.Str(ws_pat_chart_nbr_3_grp).Substring(0, 1);
                    pat_chart_remainder3_chld = Util.Str(ws_pat_chart_nbr_3_grp).Substring(1, 9);
                }
                //     else if mrn-is-general;
                else if (Util.Str(mrn_site).Equals(mrn_is_general)
                //          or mrn-is-Haldimand-War;
                            || Util.Str(mrn_site).Equals(mrn_is_Haldimand_War)
                //          or mrn-is-West-Haldimand;
                            || Util.Str(mrn_site).Equals(mrn_is_West_Haldimand)
                //          or mrn-is-Stpeter;
                            || Util.Str(mrn_site).Equals(mrn_is_Stpeter)
                // 	      then 
                )
                {
                    //           move hold-chart-no	to ws-pat-chart-nbr-4;
                    hold_chart_no_grp = Util.Str(hold_chart_id_no).PadRight(11);
                    ws_pat_chart_nbr_4_grp = hold_chart_no_grp;
                    pat_chart_1st_char4_chld = Util.Str(ws_pat_chart_nbr_4_grp).Substring(0, 1);
                    pat_chart_remainder4_chld = Util.Str(ws_pat_chart_nbr_4_grp).Substring(1, 9);
                }
                //     else if mrn-is-stjoes or mrn-is-Stjoe-Brant  then   
                else if (Util.Str(mrn_site).Equals(mrn_is_stjoes) || Util.Str(mrn_site).Equals(mrn_is_Stjoe_Brant))
                {
                    //          move hold-chart-no	to ws-pat-chart-nbr-5.;
                    hold_chart_no_grp = Util.Str(hold_chart_id_no).PadRight(11);
                    ws_pat_chart_nbr_5_grp = hold_chart_no_grp;
                    pat_chart_1st_char5_chld = Util.Str(ws_pat_chart_nbr_5_grp).Substring(0, 1);
                    pat_chart_remainder5_chld = Util.Str(ws_pat_chart_nbr_5_grp).Substring(1, 10);
                }
            }


            ws_pat_health_nbr = hold_health_nbr;
            ws_pat_i_key_chld = "I";

            ws_pat_con_nbr_chld = hold_iconst_con_nbr_chld;
            ws_pat_i_nbr_chld = hold_iconst_nx_ikey_chld;
            ws_subscr_addr1 = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr);
            ws_subscr_addr2 = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr2);
            ws_subscr_addr3 = Util.Str(objTp_pat_mstr_rec.tp_pat_city);

            // if tp-pat-prov = ' ' or  '.' or  '..' then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_prov) || Util.Str(objTp_pat_mstr_rec.tp_pat_prov).Trim().Equals(".") || Util.Str(objTp_pat_mstr_rec.tp_pat_prov).Trim().Equals(".."))
            {
                objTp_pat_mstr_rec.tp_pat_prov = "ON";
            }


            ws_pat_prov_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
            ws_subscr_prov_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);

            ws_subscr_postal_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code);
            ws_subscr_auto_update = "Y";
            ws_subscr_msg_nbr = "00";
            ws_pat_version_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd);
            ws_pat_expiry_date_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_expiry_date).PadLeft(4, '0');
            ws_pat_expiry_yy_chld = Util.NumInt(Util.Str(ws_pat_expiry_date_grp).Substring(0, 2));
            ws_pat_expiry_mm_chld = Util.NumInt(Util.Str(ws_pat_expiry_date_grp).Substring(2, 2));

            // if tp-pat-health-65-ind = " " then            
            if (string.IsNullOrWhiteSpace(objTp_pat_mstr_rec.tp_pat_health_65_ind))
            {
                ws_pat_health_65_ind = "N";
            }
            else
            {
                ws_pat_health_65_ind = Util.Str(objTp_pat_mstr_rec.tp_pat_health_65_ind);
            }
        }

        private async Task ga0_99_exit()
        {
            Util.Trakker(++ctr, "ga0_99_exit");

            //     exit.;
        }

        private async Task ge0_increment_nx_avail_pat()
        {
            Util.Trakker(++ctr, "ge0_increment_nx_avail_pat");

            //  add 1				to hold-iconst-nx-ikey;
            // 	on size error;
            //        hold_iconst_nx_ikey = 1;
            // 		add 1			to hold-iconst-con-nbr;
            //	 on size error;
            //     hold_iconst_con_nbr = 25;

            try
            {
                hold_iconst_nx_ikey_chld++;
            }
            catch (Exception e)
            {
                hold_iconst_nx_ikey_chld = 1;
                hold_iconst_con_nbr_chld++;
                try
                {
                    hold_iconst_con_nbr_chld++;
                }
                catch (Exception ex)
                {
                    hold_iconst_con_nbr_chld = 25;
                }
            }
        }

        private async Task ge0_99_exit()
        {
            Util.Trakker(++ctr, "ge0_99_exit");

            //     exit.;
        }

        private async Task wa0_write_audit_rpt_of_update()
        {
            Util.Trakker(++ctr, "wa0_write_audit_rpt_of_update");

            // if  ( birth-date-changed and old-birth-date-doesnt-match ) and (version-cd-changed   and old-version-cd-doesnt-match  ) then                        
            if ((Util.Str(flag_birth_date_change).Equals(birth_date_changed) && Util.Str(flag_old_birth_date).Equals(old_birth_date_doesnt_match)) && (Util.Str(flag_change_version_cd).Equals(version_cd_changed) && Util.Str(flag_old_version_cd).Equals(old_version_cd_doesnt_match)))
            {
                err_ind = 58;
            }
            //  else if ( birth-date-changed and old-birth-date-doesnt-match) then            
            else if (Util.Str(flag_birth_date_change).Equals(birth_date_changed) && Util.Str(flag_old_birth_date).Equals(old_birth_date_doesnt_match))
            {
                err_ind = 56;
            }
            //  else if  ( version-cd-changed and old-version-cd-doesnt-match )  then            
            else if (Util.Str(flag_change_version_cd).Equals(version_cd_changed) && Util.Str(flag_old_version_cd).Equals(old_version_cd_doesnt_match))
            {
                err_ind = 57;
            }
            //  else if   pat-change then            
            else if (Util.Str(pat_change_flag).Equals(pat_change))
            {
                err_ind = 59;
            }

            //     perform wa1-write-audit-report      thru wa1-99-exit.;
            await wa1_write_audit_report();
            await wa1_99_exit();

        }

        private async Task wa0_99_exit()
        {
            Util.Trakker(++ctr, "wa0_99_exit");

            //     exit.;
        }

        private async Task wa1_write_audit_report()
        {
            Util.Trakker(++ctr, "wa1_write_audit_report");
        }

        private async Task wa1_99_exit()
        {
            Util.Trakker(++ctr, "wa1_99_exit");

            //     exit.;
        }

        private async Task xa0_write_tp_error_report()
        {
            Util.Trakker(++ctr, "xa0_write_tp_error_report");

            // l1_line = "";
            await l1_line_grp(true);
            l2_version_cd = "";
            l2_street_addr = "";
            l2_city = "";
            l2_prov = "";
            l2_postal_cd = "";
            l2_phone_no = "";
            l2_mess_id = "";

            l1_func_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_func_code);
            l1_last_name = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);
            l1_first_name = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);
            l1_date_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_birth_date).PadRight(10);
            l1_yy = Util.NumInt(Util.Str(l1_date_grp).Substring(0, 4));
            l1_slash1 = "/";
            l1_mm = Util.NumInt(Util.Str(l1_date_grp).Substring(5, 2));
            l1_slash2 = "/";
            l1_dd = Util.NumInt(Util.Str(l1_date_grp).Substring(8, 2));

            l1_sex = Util.Str(objTp_pat_mstr_rec.tp_pat_sex);
            l1_id_no = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
            l1_ohip_no = Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no);
            l1_health_nbr = Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr);
            l2_version_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd);
            l2_street_addr = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr);
            l2_city = Util.Str(objTp_pat_mstr_rec.tp_pat_city);
            l2_prov = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
            l2_postal_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code);
            l2_phone_no = Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no);
            l2_mess_id = err_ind.ToString();


            // if ctr-reject > 9  then            
            if (ctr_reject > 9)
            {
                ctr_reject = 0;
                //    add 1				 to ctr-page-a;
                ctr_page_a++;
                h1_page_no = ctr_page_a;
                //    write rpt-rec-a from h1-head after advancing page;
                objRpt_rec_a.Rpt_rec_a1 = await h1_head_grp();
                objAudit_File_a.PageBreak();
                objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

                //    objRpt_rec_a.rpt_rec_a = "";
                objRpt_rec_a.Rpt_rec_a1 = string.Empty;
                //    write rpt-rec-a after advancing 1 line.;
                objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            }

            //     write rpt-rec-a from h2-head after advancing 2 lines.;
            objRpt_rec_a.Rpt_rec_a1 = await h2_head_grp();
            objAudit_File_a.print(true);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            //     write rpt-rec-a from l1-line after advancing 1 line.;
            objRpt_rec_a.Rpt_rec_a1 = await l1_line_grp();
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            //     write rpt-rec-a from l2-line after advancing 2 lines.;
            objRpt_rec_a.Rpt_rec_a1 = await l2_line_grp();
            objAudit_File_a.print(true);
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            //     write rpt-rec-a from l3-line after advancing 1 line.;
            objRpt_rec_a.Rpt_rec_a1 = l3_line; ;
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

            //     add 1				  to ctr-reject.;
            ctr_reject++;
            //     add 1				  to ctr-error-rpt-writes.;
            ctr_error_rpt_writes++;
        }

        private async Task xa0_99_exit()
        {
            Util.Trakker(++ctr, "xa0_99_exit");

            //     exit.;
        }

        private async Task xb0_write_ws_error_report()
        {
            Util.Trakker(++ctr, "xb0_write_ws_error_report");

            // l1_line = "";
            await l1_line_grp(true);
            l2_version_cd = "";
            l2_street_addr = "";
            l2_city = "";
            l2_prov = "";
            l2_postal_cd = "";
            l2_phone_no = "";
            l2_mess_id = "";

            l1_func_cd = ws_tp_pat_func_code;

            ws_tp_pat_last_name_grp = Util.Str(ws_tp_pat_last_name_6_chld).PadRight(6) + Util.Str(ws_tp_pat_last_name_18_chld).PadRight(18);
            l1_last_name = ws_tp_pat_last_name_grp;

            ws_tp_pat_first_name_grp = Util.Str(ws_tp_pat_first_name_3_chld).PadRight(3) + Util.Str(ws_tp_pat_first_name_21_chld).PadRight(21);
            l1_first_name = ws_tp_pat_first_name_grp;

            l1_date_grp = Util.Str(ws_tp_pat_birth_date).PadRight(10);
            l1_yy = Util.NumInt(Util.Str(l1_date_grp).Substring(0, 4).PadLeft(4, '0'));
            l1_slash1 = Util.Str(l1_date_grp).Substring(4, 1);
            l1_mm = Util.NumInt(Util.Str(l1_date_grp).Substring(5, 2).PadLeft(2, '0'));
            l1_slash2 = Util.Str(l1_date_grp).Substring(7, 1);
            l1_dd = Util.NumInt(Util.Str(l1_date_grp).Substring(8, 2));

            l1_sex = Util.Str(ws_tp_pat_sex);
            l1_id_no = Util.Str(ws_tp_pat_id_no);
            l1_ohip_no = Util.Str(ws_tp_pat_ohip_no);
            l1_health_nbr = Util.Str(ws_tp_pat_health_nbr);

            ws_tp_pat_version_cd_grp = Util.Str(ws_tp_pat_version_cd_1_chld).PadRight(1) + Util.Str(ws_tp_pat_version_cd_2_chld).PadRight(1);
            l2_version_cd = ws_tp_pat_version_cd_grp;
            l2_street_addr = Util.Str(ws_tp_pat_street_addr);
            l2_city = Util.Str(ws_tp_pat_city);
            l2_prov = Util.Str(ws_tp_pat_prov);
            l2_postal_cd = Util.Str(ws_tp_pat_postal_code);
            l2_phone_no = Util.Str(ws_tp_pat_phone_no);
            l2_mess_id = err_ind.ToString();


            // if ctr-reject > 9  then            
            if (ctr_reject > 9)
            {
                ctr_reject = 0;
                //    add 1				 to ctr-page-a;
                ctr_page_a++;
                h1_page_no = ctr_page_a;
                //    write rpt-rec-a from h1-head after advancing page;
                objRpt_rec_a.Rpt_rec_a1 = await h1_head_grp();
                objAudit_File_a.PageBreak();
                objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
                //    objRpt_rec_a.rpt_rec_a = "";
                objRpt_rec_a.Rpt_rec_a1 = string.Empty;
                //    write rpt-rec-a after advancing 1 line.;
                objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
                objAudit_File_a.print(true);  // added
            }

            //     write rpt-rec-a from h2-head after advancing 1 line.;
            objRpt_rec_a.Rpt_rec_a1 = await h2_head_grp();
            objAudit_File_a.print(true); // added
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            //     write rpt-rec-a from l1-line after advancing 1 line.;
            objRpt_rec_a.Rpt_rec_a1 = await l1_line_grp();
            objAudit_File_a.print(true); // added
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);
            //     write rpt-rec-a from l2-line after advancing 2 lines.;
            objRpt_rec_a.Rpt_rec_a1 = await l2_line_grp();
            objAudit_File_a.print(true);
            objAudit_File_a.print(true); // added
            objAudit_File_a.print(objRpt_rec_a.Rpt_rec_a1, 1, true);

            //     add 1				  to ctr-reject.;
            ctr_reject++;
            //     add 1				  to ctr-error-rpt-writes.;
            ctr_error_rpt_writes++;
        }

        private async Task xb0_99_exit()
        {
            Util.Trakker(++ctr, "xb0_99_exit");

            //     exit.;
        }

        private async Task xc0_write_ws_warning_report()
        {
            Util.Trakker(++ctr, "xc0_write_ws_warning_report");

            // l1_line = "";
            await l1_line_grp(true);
            l2_version_cd = "";
            l2_street_addr = "";
            l2_city = "";
            l2_prov = "";
            l2_postal_cd = "";
            l2_phone_no = "";
            l2_mess_id = "";

            l1_func_cd = ws_tp_pat_func_code;
            ws_tp_pat_last_name_grp = Util.Str(ws_tp_pat_last_name_6_chld).PadRight(6) + Util.Str(ws_tp_pat_last_name_18_chld).PadRight(18);
            l1_last_name = ws_tp_pat_last_name_grp;

            ws_tp_pat_first_name_grp = Util.Str(ws_tp_pat_first_name_3_chld).PadRight(3) + Util.Str(ws_tp_pat_first_name_21_chld).PadRight(21);
            l1_first_name = ws_tp_pat_first_name_grp;
            l1_date_grp = Util.Str(ws_tp_pat_birth_date).PadRight(10);
            l1_yy = Util.NumInt(Util.Str(l1_date_grp).Substring(0, 4).PadLeft(4, '0'));
            l1_slash1 = Util.Str(l1_date_grp).Substring(5, 1);
            l1_mm = Util.NumInt(Util.Str(l1_date_grp).Substring(6, 2));
            l1_slash2 = Util.Str(l1_date_grp).Substring(8, 1);
            l1_dd = Util.NumInt(Util.Str(l1_date_grp).Substring(9, 2));

            l1_sex = Util.Str(ws_tp_pat_sex);
            l1_id_no = Util.Str(ws_tp_pat_id_no);
            l1_ohip_no = Util.Str(ws_tp_pat_ohip_no);
            l1_health_nbr = Util.Str(ws_tp_pat_health_nbr);

            l2_version_cd = ws_tp_pat_version_cd_grp;
            l2_street_addr = ws_tp_pat_street_addr;
            l2_city = ws_tp_pat_city;
            l2_prov = ws_tp_pat_prov;
            l2_postal_cd = ws_tp_pat_postal_code;
            l2_phone_no = ws_tp_pat_phone_no;
            l2_mess_id = err_ind.ToString();

            // if ctr-warning > 9 then            
            if (ctr_warning > 9)
            {
                ctr_warning = 0;
                //      add 1				 to ctr-page-b;
                ctr_page_b++;
                h3_page_no = ctr_page_b;
                //      write rpt-rec-b from h3-head after advancing page;
                objRpt_rec_b.Rpt_rec_b1 = await h3_head_grp();
                objAudit_File_b.PageBreak();
                objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
                //       objRpt_rec_b.rpt_rec_b = "";
                objRpt_rec_b.Rpt_rec_b1 = string.Empty;
                //      write rpt-rec-b after advancing 1 line.;
                objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            }

            //     write rpt-rec-b from h2-head after advancing 1 line.;
            objRpt_rec_b.Rpt_rec_b1 = await h2_head_grp();
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     write rpt-rec-b from l1-line after advancing 1 line.;
            objRpt_rec_b.Rpt_rec_b1 = await l1_line_grp();
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     write rpt-rec-b from l2-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l2_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     add 1				  to ctr-warning.;
            ctr_warning++;
            //     add 1				  to ctr-warnings-rpt-writes.;
            ctr_warnings_rpt_writes++;
        }

        private async Task xc0_99_exit()
        {
            Util.Trakker(++ctr, "xc0_99_exit");

            //     exit.;
        }

        private async Task xd0_write_tp_warning_report()
        {
            Util.Trakker(++ctr, "xd0_write_tp_warning_report");

            // l1_line = "";
            await l1_line_grp(true);
            l2_version_cd = "";
            l2_street_addr = "";
            l2_city = "";
            l2_prov = "";
            l2_postal_cd = "";
            l2_phone_no = "";
            l2_mess_id = "";

            l1_func_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_func_code);
            l1_last_name = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name);
            l1_first_name = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name);
            l1_date_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_birth_date).PadRight(10);
            l1_yy = Util.NumInt(Util.Str(l1_date_grp).Substring(0, 4).PadLeft(4, '0'));
            l1_slash1 = Util.Str(l1_date_grp).Substring(4, 1);
            l1_mm = Util.NumInt(Util.Str(l1_date_grp).Substring(5, 2));
            l1_slash2 = Util.Str(l1_date_grp).Substring(7, 1);
            l1_dd = Util.NumInt(Util.Str(l1_date_grp).Substring(8, 2));

            l1_sex = Util.Str(objTp_pat_mstr_rec.tp_pat_sex);
            l1_id_no = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no);
            l1_ohip_no = Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no);
            l1_health_nbr = Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr);
            l2_version_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd);
            l2_street_addr = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr);
            l2_city = Util.Str(objTp_pat_mstr_rec.tp_pat_city);
            l2_prov = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
            l2_postal_cd = Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code);
            l2_phone_no = Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no);
            l2_mess_id = err_ind.ToString();

            // if ctr-warning > 9 then  
            if (ctr_warning > 9)
            {
                ctr_warning = 0;
                //    add 1				 to ctr-page-b;
                ctr_page_b++;
                h3_page_no = ctr_page_b;
                //    write rpt-rec-b from h3-head after advancing page;
                objRpt_rec_b.Rpt_rec_b1 = await h3_head_grp();
                objAudit_File_b.PageBreak();
                objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
                //   objRpt_rec_b.rpt_rec_b = "";
                objRpt_rec_b.Rpt_rec_b1 = string.Empty;
                //    write rpt-rec-b after advancing 1 line.;
                objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
                objAudit_File_b.print(true); // added
            }

            //     write rpt-rec-b from h2-head after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await h2_head_grp();
            objAudit_File_b.print(true); // added
            objAudit_File_b.print(true);
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            //     write rpt-rec-b from l1-line after advancing 1 line.;
            objRpt_rec_b.Rpt_rec_b1 = await l1_line_grp();
            objAudit_File_b.print(true); // added
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            //     write rpt-rec-b from l2-line after advancing 2 lines.;
            objRpt_rec_b.Rpt_rec_b1 = await l2_line_grp();
            objAudit_File_b.print(true);
            objAudit_File_b.print(true); // added
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);
            //     write rpt-rec-b from l3-line after advancing 1 line.;
            objRpt_rec_b.Rpt_rec_b1 = l3_line;
            objAudit_File_b.print(true); // added
            objAudit_File_b.print(objRpt_rec_b.Rpt_rec_b1, 1, true);

            //     add 1				  to ctr-warning.;
            ctr_warning++;
            //     add 1				  to ctr-warnings-rpt-writes.;
            ctr_warnings_rpt_writes++;
        }

        private async Task xd0_99_exit()
        {
            Util.Trakker(++ctr, "xd0_99_exit");

            //     exit.;
        }

        private async Task xe0_write_update_exception_rpt()
        {
            Util.Trakker(++ctr, "xe0_write_update_exception_rpt");

            // if ctr-exception > 15 then            
            if (ctr_exception > 15)
            {
                ctr_exception = 0;
                //    add 1				 to ctr-page-c;
                ctr_page_c++;
                h4_page_no = ctr_page_c;
                //   write rpt-rec-c from h4-head after advancing page;
                objRpt_rec_c.Rpt_rec_c1 = await h4_head_grp();
                objAudit_File_c.PageBreak();
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);
                //   objRpt_rec_c.rpt_rec_c = "";
                objRpt_rec_c.Rpt_rec_c1 = string.Empty;
                //   write rpt-rec-c from h5-head after advancing 1 line;
                objRpt_rec_c.Rpt_rec_c1 = await h5_head_grp();
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);
                //   objRpt_rec_c.rpt_rec_c = "";
                objRpt_rec_c.Rpt_rec_c1 = string.Empty;
                //    write rpt-rec-c after advancing 1 line.;
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);
                objRpt_rec_c.Rpt_rec_c1 = string.Empty;    // added c                
                objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);  // added c
            }


            prt_lit1 = "RMA";
            prt_lit2 = "Incoming";
            prt_ohip_health_nbr = Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr);


            // if old-version-cd-matches and old-birth-date-matches then;         
            if (Util.Str(flag_old_version_cd).Equals(old_version_cd_matches) && Util.Str(flag_old_birth_date).Equals(old_birth_date_matches))
            {
                //     move "VERSION CD and BIRTH DATE = RMA's OLD value" to rma-reason-desc            
                rma_reason_desc = "VERSION CD and BIRTH DATE = RMA's OLD value";
            }
            // else if    old-version-cd-matches and birth-date-changed  and old-birth-date-doesnt-match  then                      
            else if (Util.Str(flag_old_version_cd).Equals(old_version_cd_matches) && Util.Str(flag_birth_date_change).Equals(birth_date_changed) && Util.Str(flag_old_birth_date).Equals(old_birth_date_doesnt_match))
            {
                //     move "VERSION CD = RMA's OLD value (BIRTH DATE Updated)" to rma-reason-d            
                rma_reason_desc = "VERSION CD = RMA's OLD value (BIRTH DATE Updated)";
            }
            //  else if  old-birth-date-matches  and version-cd-changed  and old-version-cd-doesnt-match  then;
            else if (Util.Str(flag_old_birth_date).Equals(old_birth_date_matches) && Util.Str(flag_change_version_cd).Equals(version_cd_changed) && Util.Str(flag_old_version_cd).Equals(old_version_cd_doesnt_match))
            {
                //      move "BIRTH DATE = RMA's OLD value (VERSION CD Updated)" to rma-reason-d            
                rma_reason_desc = "BIRTH DATE = RMA's OLD value (VERSION CD Updated)";
            }
            // else if    version-cd-changed  and old-version-cd-matches  then;          
            else if (Util.Str(flag_change_version_cd).Equals(version_cd_changed) && Util.Str(flag_old_version_cd).Equals(old_version_cd_matches))
            {
                //      move "VERSION CD = RMA's OLD value"          to rma-reason-desc    
                rma_reason_desc = "VERSION CD = RMA's OLD value";
            }
            // else if    birth-date-changed  and old-birth-date-matches then;
            else if (Util.Str(flag_birth_date_change).Equals(birth_date_changed) && Util.Str(flag_old_birth_date).Equals(old_birth_date_matches) )
            {
                //     move "BIRTH DATE = RMA's OLD value"          to rma-reason-desc
                rma_reason_desc = "BIRTH DATE = RMA's OLD value";
            }
            // else;
            else
            {
                rma_reason_desc = "Unknown Update Exception error";
            }

            //     write rpt-rec-c from prt-det-line1 after advancing 2 lines.;
            objRpt_rec_c.Rpt_rec_c1 = await prt_det_line1_grp();
            objAudit_File_c.print(true); // added c
            objAudit_File_c.print(true); 
            objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

            //     write rpt-rec-c from prt-det-line2 after advancing 1 line.;
            objRpt_rec_c.Rpt_rec_c1 = await prt_det_line2_grp();
            objAudit_File_c.print(true); // added c
            objAudit_File_c.print(objRpt_rec_c.Rpt_rec_c1, 1, true);

            //     add 1				  to ctr-exception.;
            ctr_exception++;
            //     add 1				  to ctr-exception-rpt-writes.;
            ctr_exception_rpt_writes++;

            prt_lit1 = "";
            prt_ohip_health_nbr = "";
            rma_version_cd = "";
            rma_prov_cd = "";
            rma_reason_desc = "";
            prt_lit2 = "";
            disk_account_id = "";
            disk_version_cd = "";
            disk_prov_cd = "";

            rma_birth_date_yy = 0;
            rma_birth_date_mm = 0;
            rma_birth_date_dd = 0;
            disk_birth_date_yy = 0;
            disk_birth_date_mm = 0;
            disk_birth_date_dd = 0;

        }

        private async Task xe0_99_exit()
        {
            Util.Trakker(++ctr, "xe0_99_exit");
            //     exit.;
        }

        private async Task ya0_read_next_tape()
        {
            Util.Trakker(++ctr, "ya0_read_next_tape");

            //  read tp-pat-mstr at end            
            //       eof_tp_pat_mstr = "Y";
            // 	     go to ya0-99-exit.;
            if (Tp_pat_mstr_rec_Collection.Count() == 0 || ctr_tp_pat_mstr_reads >= Tp_pat_mstr_rec_Collection.Count() || Tp_pat_mstr_rec_Collection == null)
            {
                      eof_tp_pat_mstr = "Y";
                // 	     go to ya0-99-exit.;
                await ya0_99_exit();
                return; 
            }
            else
            {
                objTp_pat_mstr_rec = Tp_pat_mstr_rec_Collection[ctr_tp_pat_mstr_reads];
                ctr_tp_pat_mstr_reads++;
            }

            // if  tp-pat-last-name-6 = "FINK  " and tp-pat-first-name  = "BABYGIRL" then
            if (Util.Str(objTp_pat_mstr_rec.tp_pat_last_name_6).ToUpper().Trim().Equals("FINK") && Util.Str(objTp_pat_mstr_rec.tp_pat_first_name).Trim().ToUpper().Equals("BABYGIRL") ) {
                //      add 1 to ctr-tp-pat-mstr-reads.;
                ctr_tp_pat_mstr_reads++;
            }

            //     add 1				to ctr-tp-pat-mstr-reads.;            
        }

        private async Task ya0_99_exit()
        {
            Util.Trakker(++ctr, "ya0_99_exit");

            //     exit.;
        }

        private async Task yb0_read_pat_mstr()
        {
            Util.Trakker(++ctr, "yb0_read_pat_mstr");

            pat_flag = "Y";
            pat_occur = 0;
            feedback_pat_mstr = "0";

            // read pat-mstr;
            // 	invalid key;
            //      pat_flag = "N";
            // 	    go to yb0-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                // todo......
            }.Collection(null);

            if (Pat_mstr_rec_Collection == null ||  Pat_mstr_rec_Collection.Count() == 0 )
            {
                 pat_flag = "N";
                //  go to yb0-99-exit.;
                await yb0_99_exit();
                return; 
            }
            pat_mstr_row_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
            pat_mstr_row_ctr++;
        }

        private async Task yb0_99_exit()
        {
            Util.Trakker(++ctr, "yb0_99_exit");

            //     exit.;
        }

        private async Task yb0_2_read_od_pat_mstr()
        {
            Util.Trakker(++ctr, "yb0_2_read_od_pat_mstr");

            pat_flag = "Y";
            pat_occur_od = 0;
            feedback_pat_mstr_od = "0";

            // read pat-mstr;
            //         key is pat-ohip-mmyy;
            //            invalid key;
            //             pat_flag = "N";
            // 	           go to yb0-2-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_direct_alpha = Util.Str(hold_ohip_mmyy_grp).Substring(0, 3),   // todo: watch out the values!!!!
                WherePat_direct_yy = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(3, 2)),
                WherePat_direct_mm = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(5, 2)),
                WherePat_direct_dd = Util.NumInt(Util.Str(hold_ohip_mmyy_grp).Substring(7, 2)),
                //WherePat_direct_last_6 =   //todo...?
            }.Collection(null);

            if (Pat_mstr_rec_Collection.Count() == 0 )
            {
                pat_flag = "N";
                await yb0_2_99_exit();
                return;
            }

            pat_mstr_row_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
            pat_mstr_row_ctr++;


            //ws_pat_mstr_rec = objPat_mstr_rec.pat_mstr_rec;
            await move_pat_mstr_rec_to_ws_pat_mstr_rec();

            ws_feedback_pat_mstr = feedback_pat_mstr_od;
        }

        private async Task yb0_2_99_exit()
        {
            Util.Trakker(++ctr, "yb0_2_99_exit");

            //     exit.;
        }

        private async Task yb0_3_read_hc_pat_mstr()
        {
            Util.Trakker(++ctr, "yb0_3_read_hc_pat_mstr");

            pat_flag = "Y";
            pat_occur_hc = 0;
            feedback_pat_mstr_hc = "0";

            isRetrieving = false;

            // read pat-mstr;
            //         key is pat-health-nbr of pat-mstr;
            //         invalid key;
            //            pat_flag = "N";
            // 	          go to yb0-3-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_health_nbr = hold_health_nbr
            }.Collection_HealthNumber(ref isRetrieving, Pat_mstr_rec_Collection);
        //}.Collection(null);
            

            if (Pat_mstr_rec_Collection.Count() == 0 )
            {
                objPat_mstr_rec = new F010_PAT_MSTR();
                pat_flag = "N";
                await yb0_3_99_exit();
                return;
            }

            pat_mstr_row_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
            pat_mstr_row_ctr++;

            // ws_pat_mstr_rec = objPat_mstr_rec.pat_mstr_rec;
            await move_pat_mstr_rec_to_ws_pat_mstr_rec();

            ws_feedback_pat_mstr = feedback_pat_mstr_hc;
        }

        private async Task yb0_3_99_exit()
        {
            Util.Trakker(++ctr, "yb0_3_99_exit");

            //     exit.;
        }

        private async Task yb0_4_read_acr_pat_mstr()
        {
            Util.Trakker(++ctr, "yb0_4_read_acr_pat_mstr");

            pat_flag = "Y";
            pat_occur_acr = 0;
            feedback_pat_mstr_acr = "0";


            //  read pat-mstr;
            //         key is pat-acronym;
            //            invalid key;
            //              pat_flag = "N";
            // 	            go to yb0-4-99-exit.;
            hold_acronym_grp = Util.Str(hold_last_name_chld).PadRight(6).Substring(0, 6) + Util.Str(hold_first_name_chld).PadRight(3).Substring(0, 3);

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_acronym_first6 = Util.Str(hold_acronym_grp).Substring(0, 6),
                WherePat_acronym_last3 = Util.Str(hold_acronym_grp).Substring(6, 3)
            }.Collection(null);

            if (Pat_mstr_rec_Collection.Count() == 0)
            {
                    pat_flag = "N";
                 await yb0_4_99_exit();
                return; 
            }

            pat_mstr_row_ctr = 0;
            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
            pat_mstr_row_ctr++;            

            //ws_pat_mstr_rec = objPat_mstr_rec.pat_mstr_rec;
            await move_pat_mstr_rec_to_ws_pat_mstr_rec();

        }

        private async Task yb0_4_99_exit()
        {
            Util.Trakker(++ctr, "yb0_4_99_exit");

            //     exit.;
        }

        private async Task yb0_5_read_chrt_pat_mstr()
        {
            Util.Trakker(++ctr, "yb0_5_read_chrt_pat_mstr");

            // if invalid-chart-key then            
            if (edit_chart_flag.Equals(invalid_chart_key) ) {
                // 	   go to yb0-5-99-exit.;
                await yb0_5_99_exit();
                return; 
            }

            pat_flag = "Y";
            pat_occur_chrt = 0;
            feedback_pat_mstr_chrt = "0";


            hold_chart_no_grp = Util.Str(hold_chart_id_no);
            // if mrn-is-mumc or mrn-is-West-Lincoln then            
            if (Util.Str(mrn_site).Equals(mrn_is_mumc) ||  Util.Str(mrn_site).Equals(mrn_is_West_Lincoln)) {
                //       objPat_mstr_rec.pat_chart_nbr = hold_chart_no;

                //       read pat-mstr;
                //             key is pat-chart-nbr;
                //               invalid key;
                //                  pat_flag = "N";
                //                 go to yb0-5-99-exit;            
                Pat_mstr_rec_Collection = new F010_PAT_MSTR
                {
                    WherePat_chart_nbr = hold_chart_no_grp
                }.Collection(null);

                if (Pat_mstr_rec_Collection.Count() >  0 )
                {
                    pat_mstr_row_ctr = 0;
                    objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
                    pat_mstr_row_ctr++;
                }
                else
                {
                     pat_flag = "N";                    
                    await yb0_5_99_exit();
                    return; 
                }
            }
            //  else if mrn-is-chedoke or mrn-is-Bay-Area then            
            else if (Util.Str(mrn_site).Equals(mrn_is_chedoke) || Util.Str(mrn_site).Equals(mrn_is_Bay_Area)) {
                //        objPat_mstr_rec.pat_chart_nbr_2 = hold_chart_no;
                //        read pat-mstr;
                //             key is pat-chart-nbr-2;
                //               invalid key;
                //                 pat_flag = "N";
                //                 go to yb0-5-99-exit;            
                Pat_mstr_rec_Collection = new F010_PAT_MSTR
                {
                    WherePat_chart_nbr_2 = hold_chart_no_grp
                }.Collection(null);

                if (Pat_mstr_rec_Collection.Count() > 0)
                {
                    pat_mstr_row_ctr = 0;
                    objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
                    pat_mstr_row_ctr++;
                }
                else
                {
                    pat_flag = "N";
                    await yb0_5_99_exit();
                    return;
                }
            }
            // else if mrn-is-henderson then            
            else if (Util.Str(mrn_site).Equals(mrn_is_henderson)  ) {
                //       objPat_mstr_rec.pat_chart_nbr_3 = hold_chart_no;
                //       read pat-mstr;
                //             key is pat-chart-nbr-3;
                //               invalid key;
                //                 pat_flag = "N";
                //                go to yb0-5-99-exit;
                Pat_mstr_rec_Collection = new F010_PAT_MSTR
                {
                    WherePat_chart_nbr_3 = hold_chart_no_grp
                }.Collection(null);

                if (Pat_mstr_rec_Collection.Count() > 0)
                {
                    pat_mstr_row_ctr = 0;
                    objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
                    pat_mstr_row_ctr++;
                }
                else
                {
                    pat_flag = "N";
                    await yb0_5_99_exit();
                    return;
                }
            }
            // else if mrn-is-general or mrn-is-Haldimand-War or mrn-is-West-Haldimand or mrn-is-Stpeter then            
            else if (Util.Str(mrn_site).Equals(mrn_is_general) || Util.Str(mrn_site).Equals(mrn_is_Haldimand_War) || Util.Str(mrn_site).Equals(mrn_is_West_Haldimand) || Util.Str(mrn_site).Equals(mrn_is_Stpeter) ) {
                //         objPat_mstr_rec.pat_chart_nbr_4 = hold_chart_no;
                //         read pat-mstr;
                //             key is pat-chart-nbr-4;
                //               invalid key;
                //                  pat_flag = "N";
                //                  go to yb0-5-99-exit;
                Pat_mstr_rec_Collection = new F010_PAT_MSTR
                {
                    WherePat_chart_nbr_4 = hold_chart_no_grp
                }.Collection(null);

                if (Pat_mstr_rec_Collection.Count() > 0)
                {
                    pat_mstr_row_ctr = 0;
                    objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
                    pat_mstr_row_ctr++;
                }
                else
                {
                    pat_flag = "N";
                    await yb0_5_99_exit();
                    return;
                }
            }
            // else if mrn-is-stjoes or mrn-is-Stjoe-Brant  then            
            else if (Util.Str(mrn_site).Equals(mrn_is_stjoes) || Util.Str(mrn_site).Equals(mrn_is_Stjoe_Brant) ) {
                //        objPat_mstr_rec.pat_chart_nbr_5 = hold_chart_no;
                //        read pat-mstr;
                //             key is pat-chart-nbr-5;
                //               invalid key;
                //                 pat_flag = "N";
                //                 go to yb0-5-99-exit;
                Pat_mstr_rec_Collection = new F010_PAT_MSTR
                {
                    WherePat_chart_nbr_5 = hold_chart_no_grp
                }.Collection(null);

                if (Pat_mstr_rec_Collection.Count() > 0)
                {
                    pat_mstr_row_ctr = 0;
                    objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
                    pat_mstr_row_ctr++;
                }
                else
                {
                    pat_flag = "N";
                    await yb0_5_99_exit();
                    return;
                }
            }
            else {
                //       objPat_mstr_rec.pat_chart_nbr_5 = hold_chart_no;
                //       read pat-mstr;
                //             key is pat-chart-nbr-5;
                //               invalid key;
                //                 pat_flag = "N";
                //                 go to yb0-5-99-exit.;
                Pat_mstr_rec_Collection = new F010_PAT_MSTR
                {
                    WherePat_chart_nbr_5 = hold_chart_no_grp
                }.Collection(null);

                if (Pat_mstr_rec_Collection.Count() > 0)
                {
                    pat_mstr_row_ctr = 0;
                    objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
                    pat_mstr_row_ctr++;
                }
                else
                {
                    pat_flag = "N";
                    await yb0_5_99_exit();
                    return;
                }
            }

            // ws_pat_mstr_rec = objPat_mstr_rec.pat_mstr_rec;
            await move_pat_mstr_rec_to_ws_pat_mstr_rec();

            ws_feedback_pat_mstr = feedback_pat_mstr_chrt;
        }

        private async Task yb0_5_99_exit()
        {
            Util.Trakker(++ctr, "yb0_5_99_exit");

            //     exit.;
        }

        private async Task yb0_10_read_next_pat_mstr()
        {
            Util.Trakker(++ctr, "yb0_10_read_next_pat_mstr");

            pat_flag = "Y";

            // read pat-mstr next;
            // 	at end;
            //      pat_flag = "N";
            // 	    go to yb0-10-99-exit.;
            
            if (pat_mstr_row_ctr >= Pat_mstr_rec_Collection.Count() || Pat_mstr_rec_Collection == null)
            {
                    pat_flag = "N";                
                await yb0_10_99_exit();
                return; 
            }

            objPat_mstr_rec = Pat_mstr_rec_Collection[pat_mstr_row_ctr];
            pat_mstr_row_ctr++;

            //     if 	pat-acronym not = hold-acronym;
            if (!Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6).Equals(hold_last_name_chld) && !Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3).Equals(hold_last_name_chld) ) {
                pat_flag = "N";
            }
        }

        private async Task yb0_10_99_exit()
        {
            Util.Trakker(++ctr, "yb0_10_99_exit");

            //     exit.;
        }

        private async Task yb1_write_patient()
        {
            Util.Trakker(++ctr, "yb1_write_patient");

            //  perform yc5-check-dup-ikey			thru yc5-99-exit.;
            await yc5_check_dup_ikey();
            await yc5_99_exit();

            //   objPat_mstr_rec.pat_mstr_rec = ws_pat_mstr_rec;
            await move_ws_pat_mstr_rec_to_pat_mstr_rec();

            //     perform yb2-write-pat-i-key			thru yb2-99-exit.;
            await yb2_write_pat_i_key();
            await yb2_99_exit();

            //     perform ge0-increment-nx-avail-pat		thru ge0-99-exit.;
            await ge0_increment_nx_avail_pat();
            await ge0_99_exit();

            err_ind = 55;
            //     perform xd0-write-tp-warning-report         thru xd0-99-exit.;
            await xd0_write_tp_warning_report();
            await xd0_99_exit();

            //     perform ye0-write-out-accepted-pat-rec	thru ye0-99-exit.;
            await ye0_write_out_accepted_pat_rec();
            await ye0_99_exit();
        }

        private async Task yb1_99_exit()
        {
            Util.Trakker(++ctr, "yb1_99_exit");

            //     exit.;
        }

        private async Task yb2_write_pat_i_key()
        {
            Util.Trakker(++ctr, "yb2_write_pat_i_key");

            // if   pat-ohip-mmyy = " "  or pat-ohip-mmyy = zero then            
            if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_DIRECT_ALPHA) && Util.NumInt(objPat_mstr_rec.PAT_DIRECT_YY) == 0  && Util.NumInt(objPat_mstr_rec.PAT_DIRECT_MM) == 0  && Util.NumInt(objPat_mstr_rec.PAT_DIRECT_DD) == 0 ) {
                //     objPat_mstr_rec.pat_ohip_mmyy = ws_pat_i_nbr;
                objPat_mstr_rec.PAT_DIRECT_ALPHA = Util.Str(ws_pat_i_nbr_chld).PadLeft(15).Substring(0, 3);
                objPat_mstr_rec.PAT_DIRECT_YY = Util.NumInt(Util.Str(ws_pat_i_nbr_chld).PadLeft(15).Substring(3, 2));
                objPat_mstr_rec.PAT_DIRECT_MM  = Util.NumInt(Util.Str(ws_pat_i_nbr_chld).PadLeft(15).Substring(5, 2));
                objPat_mstr_rec.PAT_DIRECT_DD = Util.NumInt(Util.Str(ws_pat_i_nbr_chld).PadLeft(15).Substring(7, 2));
                objPat_mstr_rec.PAT_DIRECT_LAST_6 = Util.Str(ws_pat_i_nbr_chld).PadLeft(15).Substring(9, 6);
            }

            //  x_key_pat_mstr = objPat_mstr.Key_pat_mstr;
            x_key_pat_mstr_grp = Util.Str(objPat_mstr_rec.PAT_I_KEY).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_CON_NBR).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_I_NBR).PadLeft(12, '0') + new string(' ', 1);

            // if pat-chart-nbr   = spaces  then            
            if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_CHART_NBR)) {
                //     objPat_mstr_rec.pat_chart_nbr = x_ikey_2_11_digits;
                objPat_mstr_rec.PAT_CHART_NBR = x_ikey_2_11_digits_chld;
            }

            // if pat-chart-nbr-2   = spaces then            
            if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_CHART_NBR_2)) {
                //     objPat_mstr_rec.pat_chart_nbr_2 = x_ikey_2_11_digits;
                objPat_mstr_rec.PAT_CHART_NBR_2 = x_ikey_2_11_digits_chld;
            }

            // if pat-chart-nbr-3   = spaces then            
            if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_CHART_NBR_3)) {
                //    objPat_mstr_rec.pat_chart_nbr_3 = x_ikey_2_11_digits;
                objPat_mstr_rec.PAT_CHART_NBR_3 = x_ikey_2_11_digits_chld;
            }

            // if pat-chart-nbr-4   = spaces then
            if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_CHART_NBR_4))
            {
                x_pat_chart4_1_digit = "?";
                x_pat_chart4_9_digits = x_ikey_3_11_digits_chld;
                objPat_mstr_rec.PAT_CHART_NBR_4 = x_pat_chart4_1_digit + x_pat_chart4_9_digits;
            }

            // if pat-chart-nbr-5 = spaces then            
            if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_CHART_NBR_5))
            {
                //      objPat_mstr_rec.pat_chart_nbr_5 = x_key_pat_mstr_test;
                x_key_pat_mstr_test_grp = Util.Str(x_ikey_1_digit_chld).PadRight(1) + Util.Str(x_ikey_2_11_digits_chld).PadRight(10);
                objPat_mstr_rec.PAT_CHART_NBR_5 = x_key_pat_mstr_test_grp;
            }

            //  write pat-mstr-rec;
            //   	invalid key;
            // 	    go to err-pat-mstr.;

            try
            {
                objPat_mstr_rec.RecordState = State.Added;
                objPat_mstr_rec.Submit();
            } catch (Exception e)
            {
                await err_pat_mstr();
                return;
            }


            status_cobol_display1 = status_cobol_pat_mstr1;
            // if   status-cobol-pat-mstr1 <> 9 then            
            //     status_cobol_display2 = status_cobol_pat_mstr2;
            // else;
            //     status_cobol_pat_mstr1 = low_values;
            //     status_cobol_display2 = status_cobol_pat_mstr_bin;


            //  if status-cobol-pat-mstr1 <> 0 then            
            //     display "Patient error = ", status-cobol-display.;

            //   add 1				to ctr-pat-mstr-writes.;
            ctr_pat_mstr_writes++;
        }

        private async Task yb2_99_exit()
        {
            Util.Trakker(++ctr, "yb2_99_exit");
            //     exit.;
        }

        private async Task yc5_check_dup_ikey()
        {
            Util.Trakker(++ctr, "yc5_check_dup_ikey");

            //objPat_mstr.Pat_i_key = "I";
            objPat_mstr_rec.PAT_I_KEY = "I";
            //objPat_mstr.Pat_con_nbr = hold_iconst_con_nbr;
            objPat_mstr_rec.PAT_CON_NBR = hold_iconst_con_nbr_chld;
            //objPat_mstr.Pat_i_nbr = hold_iconst_nx_ikey;
            objPat_mstr_rec.PAT_I_NBR = hold_iconst_nx_ikey_chld;

            // read pat-mstr;
            // 	invalid key;
            // 	     go to yc5-99-exit.;

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_i_key = "I",
                WherePat_con_nbr = hold_iconst_con_nbr_chld,
                WherePat_i_nbr = hold_iconst_nx_ikey_chld
            }.Collection(null);

            if (Pat_mstr_rec_Collection.Count() == 0 )
            {
                // 	     go to yc5-99-exit.;
                await yc5_99_exit();
                return; 
            }

                   err_ind = 54;
            //     display err-msg(err-ind).;
            //     display key-pat-mstr of pat-mstr.;

            //     perform xb0-write-ws-error-report		thru xb0-99-exit.;
            await xb0_write_ws_error_report();
            await xb0_99_exit();

            //     perform err-pat-mstr.;
            await  err_pat_mstr();            
        }

        private async Task yc5_99_exit()
        {
            Util.Trakker(++ctr, "yc5_99_exit");

            //     exit.;
        }

        private async Task yc6_rewrite_patient()
        {
            Util.Trakker(++ctr, "yc6_rewrite_patient");

            // objPat_mstr_rec.Pat_date_last_maint = sys_date_long;
            objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumDec(sys_date_long_child);

            //     rewrite pat-mstr-rec;
            // 	invalid key;
            //             go to err-pat-mstr.;

            try
            {
                objPat_mstr_rec.RecordState = State.Modified;
                objPat_mstr_rec.Submit();
            } catch (Exception e)
            {
                await err_pat_mstr();
                return;
            }

            //     perform ye0-write-out-accepted-pat-rec	thru ye0-99-exit.;
            await ye0_write_out_accepted_pat_rec();
            await ye0_99_exit();
        }

        private async Task yc6_99_exit()
        {
            Util.Trakker(++ctr, "yc6_99_exit");

            //     exit.;
        }

        private async Task ye0_write_out_accepted_pat_rec()
        {
            Util.Trakker(++ctr, "ye0_write_out_accepted_pat_rec");

            // objTp_pat_mstr_rec_out.tp_pat_mstr_rec_out_orig = objTp_pat_mstr_rec.tp_pat_mstr_rec;
            objTp_pat_mstr_rec_out.Tp_pat_mstr_rec_out_orig = await tp_pat_mstr_rec_get();

            //     add 1				to ctr-pat-mstr-out-writes.;
            ctr_pat_mstr_out_writes++;

            objTp_pat_mstr_rec_out.Sequence_nbr_num  = ctr_pat_mstr_out_writes;

            //     write tp-pat-mstr-rec-out;
            // 	invalid key;
            // 	    go to err-tp-pat-mstr-out.;

            try
            { 
                string tmp = Util.Str(objTp_pat_mstr_rec_out.Sequence_nbr_num).PadLeft(6, '0') + Util.Str(objTp_pat_mstr_rec_out.Tp_pat_mstr_rec_out_orig).PadRight(204);
                objTp_pat_mstr_rec_out_File.AppendOutputFile(tmp);
            }catch (Exception e)
            {
                await err_tp_pat_mstr_out();
                return; 
            }

            //status_cobol_display1 = status_cobol_pat_mstr1_out;
            //     if   status-cobol-pat-mstr1-out <> 9;
            //     then;
            //status_cobol_display2 = status_cobol_pat_mstr2_out;
            //     else;
            // status_cobol_pat_mstr1 = low_values;
            //status_cobol_display2 = status_cobol_pat_mstr_bin_out;
            //     if status-cobol-pat-mstr1-out <> 0;
            //     then;
            //         display "Patient error = ", status-cobol-display.;
        }

        private async Task ye0_99_exit()
        {
            Util.Trakker(++ctr, "ye0_99_exit");

            //     exit.;
        }

        private async Task zz1_process_chart_nbr()
        {
            Util.Trakker(++ctr, "zz1_process_chart_nbr");

            // x_key_pat_mstr = objPat_mstr.Key_pat_mstr;
            x_key_pat_mstr_grp = Util.Str(objPat_mstr_rec.PAT_I_KEY).PadRight(1) + Util.Str(objPat_mstr_rec.PAT_CON_NBR).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_I_NBR).PadLeft(12, '0') + new string(' ', 1);
            x_key_pat_mstr_dtl_grp = x_key_pat_mstr_grp;
            x_pat_i_key = Util.Str(x_key_pat_mstr_dtl_grp).Substring(0, 1);
            x_pat_con_nbr = Util.NumInt(Util.Str(x_key_pat_mstr_dtl_grp).Substring(1, 2));
            x_pat_i_nbr = Util.NumLongInt(Util.Str(x_key_pat_mstr_dtl_grp).Substring(3, 12));
            x_filler = Util.Str(x_key_pat_mstr_dtl_grp).Substring(15, 1);

            x_key_pat_mstr_r_grp = x_key_pat_mstr_grp;
            x_key_pat_mstr_test_grp = Util.Str(x_key_pat_mstr_r_grp).Substring(4, 11);
            x_ikey_1_digit_chld = x_key_pat_mstr_test_grp.Substring(0, 1);
            x_ikey_2_11_digits_chld = x_key_pat_mstr_test_grp.Substring(1, 10);
            x_ikey_3_11_digits_chld = x_key_pat_mstr_test_grp.Substring(2, 9);

            // if pat-chart-nbr   = x-ikey-2-11-digits then     
            if (Util.Str(objPat_mstr_rec.PAT_CHART_NBR).Trim().Equals(x_ikey_2_11_digits_chld)) {
                //    objPat_mstr_rec.pat_chart_nbr = "";
                objPat_mstr_rec.PAT_CHART_NBR = string.Empty;
            }

            // if pat-chart-nbr-2 = x-ikey-2-11-digits then    
            if (Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).Trim().Equals(x_ikey_2_11_digits_chld)) {
                //     objPat_mstr_rec.pat_chart_nbr_2 = "";
                objPat_mstr_rec.PAT_CHART_NBR_2 = string.Empty;
            }

            // if pat-chart-nbr-3 = x-ikey-2-11-digits then    
            if (Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).Trim().Equals(x_ikey_2_11_digits_chld)) {
                //     objPat_mstr_rec.pat_chart_nbr_3 = "";
                objPat_mstr_rec.PAT_CHART_NBR_3 = string.Empty;
            }

            x_pat_chart_nbr_4_grp = objPat_mstr_rec.PAT_CHART_NBR_4;
            x_pat_chart4_1_digit = objPat_mstr_rec.PAT_CHART_NBR_4.Substring(0, 1);
            x_pat_chart4_9_digits = objPat_mstr_rec.PAT_CHART_NBR_4.Substring(1, 9);
            if (x_pat_chart4_1_digit == "?" && x_pat_chart4_9_digits == x_ikey_3_11_digits_chld)
            {
                objPat_mstr_rec.PAT_CHART_NBR_4 = string.Empty;
            }

            // if pat-chart-nbr-5 = x-key-pat-mstr-test then   
            if (Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).Trim().Equals(x_key_pat_mstr_test_grp))
            {
                //    objPat_mstr_rec.pat_chart_nbr_5 = "";
                objPat_mstr_rec.PAT_CHART_NBR_5 = string.Empty;
            }
        }

        private async Task zz1_99_exit()
        {
            Util.Trakker(++ctr, "zz1_99_exit");

            //     exit.;
        }

        // y2k_default_century_year.rtn
        private async Task y2k_add_century_to_year()
        {
            Util.Trakker(++ctr, "y2k_add_century_to_year");

            // if century-year > 99 then     
            if (century_year > 90 ) {
                // 	  next sentence;            
            }
            // else if century-year = 99 then            
            else if (century_year == 99 ) {
                //    add 1900                to   century-year;
                century_year += 1900;
            }
            else {
                //      add 2000		    to	 century-year.;
                century_year += 2000;
            }
        }

        // y2k_default_century_year.rtn
        private async Task y2k_99_exit()
        {
            Util.Trakker(++ctr, "y2k_99_exit");

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {
            Util.Trakker(++ctr, "y2k_default_sysdate");

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            Util.Trakker(++ctr, "y2k_default_sysdate_exit");

            //     exit.;
        }

        // process_pat_eligibility_change.rtn
        private async Task yy0_process_pat_elig_change()
        {
            Util.Trakker(++ctr, "yy0_process_pat_elig_change");

            ws_pat_date_last_maint = Util.NumInt(sys_date_long_child);  

            ws_pat_date_last_elig_maint = Util.NumInt(sys_date_long_child);
            ws_pat_no_of_letter_sent = 0;

            // if     ws-pat-mess-code <> spaces  then            
            if (!string.IsNullOrWhiteSpace(ws_pat_mess_code)) {
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
            Util.Trakker(++ctr, "yy0_99_exit");

            //     exit.;
        }

        // process_pat_eligibility_change.rtn
        private async Task yy1_write_corrected_pat_rec()
        {
            Util.Trakker(++ctr, "yy1_write_corrected_pat_rec");

            // objPat_id_rec.Clmhdr_pat_ohip_id_or_chart = objPat_mstr.Key_pat_mstr;
            objPat_id_rec.CLMHDR_PAT_OHIP_ID_OR_CHART = Util.Str(objPat_mstr_rec.PAT_I_KEY).PadRight(1) + Util.Str(objPat_mstr_rec.PAT_CON_NBR).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_I_NBR).PadLeft(2, '0') + new string(' ', 1);

            // objPat_id_rec.Pat_last_birth_date = ws_pat_last_birth_date;
            objPat_id_rec.PAT_LAST_BIRTH_DATE = ws_pat_last_birth_date;

            // objPat_id_rec.Pat_last_version_cd = ws_pat_last_version_cd;
            objPat_id_rec.PAT_LAST_VERSION_CD = Util.Str(ws_pat_last_version_cd);

            //     write pat-id-rec.;
            objPat_id_rec.RecordState = State.Added;
            objPat_id_rec.Submit();

            //     add 1                       to ctr-write-corrected-pat.;
            ctr_write_corrected_pat++;
        }

        // process_pat_eligibility_change.rtn
        private async Task yy1_99_exit()
        {
            Util.Trakker(++ctr, "yy1_99_exit");

            //     exit.;
        }

        // process_pat_eligibility_change.rtn
        private async Task yy2_write_pat_elig_hist_rec()
        {
            Util.Trakker(++ctr, "yy2_write_pat_elig_hist_rec");

            //objPat_elig_history.Key_pat_mstr = objPat_mstr.Key_pat_mstr;
            objF011_pat_mstr_elig_history_rec.PAT_I_KEY = objPat_mstr_rec.PAT_I_KEY;
            objF011_pat_mstr_elig_history_rec.PAT_CON_NBR = objPat_mstr_rec.PAT_CON_NBR;
            objF011_pat_mstr_elig_history_rec.PAT_I_NBR = objPat_mstr_rec.PAT_I_NBR;

            //objPat_elig_history.Pat_expiry_date = objPat_mstr.Pat_expiry_date;
            objF011_pat_mstr_elig_history_rec.PAT_EXPIRY_MM = objPat_mstr_rec.PAT_EXPIRY_MM;
            objF011_pat_mstr_elig_history_rec.PAT_EXPIRY_YY = objPat_mstr_rec.PAT_EXPIRY_YY;

            //objPat_elig_history.Pat_health_nbr = objPat_mstr.Pat_health_nbr;
            objF011_pat_mstr_elig_history_rec.PAT_HEALTH_NBR = objPat_mstr_rec.PAT_HEALTH_NBR;

            //objPat_elig_history.Pat_health_nbr_last = objPat_mstr.Pat_health_nbr;
            objF011_pat_mstr_elig_history_rec.PAT_LAST_HEALTH_NBR = objPat_mstr_rec.PAT_HEALTH_NBR;

            //objPat_elig_history.Pat_birth_date = ws_pat_birth_date;
            objF011_pat_mstr_elig_history_rec.PAT_BIRTH_DATE = ws_pat_birth_date;

            //objPat_elig_history.Pat_birth_date_last = ws_pat_last_birth_date;
            objF011_pat_mstr_elig_history_rec.PAT_BIRTH_DATE_LAST = ws_pat_last_birth_date;

            //objPat_elig_history.Pat_version_cd = ws_pat_version_cd;
            objF011_pat_mstr_elig_history_rec.PAT_VERSION_CD = ws_pat_version_cd;

            //objPat_elig_history.Pat_version_cd_last = ws_pat_last_version_cd;
            objF011_pat_mstr_elig_history_rec.PAT_LAST_VERSION_CD = ws_pat_last_version_cd;

            //objPat_elig_history.Pat_date_last_maint = sys_date;
            objF011_pat_mstr_elig_history_rec.PAT_DATE_LAST_MAINT = Util.NumLongInt(sys_date_long_child);

            //     accept sys-time                  from time.;
            //objPat_elig_history.Pat_time_last_maint = sys_time;
            objF011_pat_mstr_elig_history_rec.ENTRY_TIME_LONG = Util.NumLongInt(DateTime.Now.ToString("hh") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"));

            //     write f011-pat-mstr-elig-history-rec.;
            objF011_pat_mstr_elig_history_rec.RecordState = State.Added;
            objF011_pat_mstr_elig_history_rec.Submit();

            //     add 1                            to ctr-write-pat-elig-hist.;
            ctr_write_pat_elig_hist++;
        }

        // process_pat_eligibility_change.rtn
        private async Task yy2_99_exit()
        {
            Util.Trakker(++ctr, "yy2_99_exit");

            //     exit.;
        }


        private async Task<string> h1_head_grp()
        {
            Util.Trakker(++ctr, "h1_head_grp");
            
                return "RU011A".PadRight(33, ' ') +
                        "Patient Transfer File - Upload ERROR Report".PadRight(63) +
                        "RUN DATE :".PadRight(11, ' ') +
                        Util.Str(h1_run_date).PadRight(10, ' ') +
                        "".PadRight(5, ' ') +
                       "  PAGE".PadRight(7, ' ') +
                       Util.ImpliedIntegerFormat("#0", h1_page_no, 3, false);            
        }

        private async Task<string> h2_head_grp()
        {
            Util.Trakker(++ctr, "h2_head_grp");

            return "* FUNC CD".PadRight(17, ' ') +
                     "LAST  NAME".PadRight(26, ' ') +
                     "FIRST  NAME".PadRight(18, ' ') +
                     "BIRTH DTE SEX".PadRight(17, ' ') +
                     "ID NO         OHIP  NO".PadRight(27, ' ') +
                     " HEALTH NUMBER             ".PadRight(27, ' ');
        }

        private async Task<string> h3_head_grp()
        {
            Util.Trakker(++ctr, "h3_head_grp");

            return "RU011B".PadRight(33, ' ') +
                    "Patient Transfer File - Upload  AUDIT Report".PadRight(63) +
                    "RUN DATE :".PadRight(11) +
                    Util.Str(h3_run_date).PadRight(10) +
                     "".PadRight(5) +
                    "  PAGE".PadRight(7) +
                   Util.ImpliedIntegerFormat("#0", h3_page_no, 3, false);
        }

        private async Task<string> h4_head_grp()
        {
            Util.Trakker(++ctr, "h4_head_grp");

            return "RU011C".PadRight(33) +
                   "Patient Transfer File -  Update EXCEPTIONS Report".PadRight(63) +
                   "RUN DATE :".PadRight(11) +
                  Util.Str(h4_run_date).PadRight(10) +
                   "".PadRight(5) +
                   "  PAGE".PadRight(7) +
                  Util.ImpliedIntegerFormat("#0", h4_page_no, 3, false);
        }

        private async Task<string> h5_head_grp()
        {
            Util.Trakker(++ctr, "h5_head_grp");

            return "".PadRight(10) +
                   "HEALTH/ACCT'ING #".PadRight(22) +
                   "BIRTH DATE".PadRight(20) +
                    "VERSION CD".PadRight(20) +
                    "".PadRight(50);
        }

        private async Task<string> l1_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "l1_line_grp");

            if (isInitialize)
            {
                l1_func_cd = string.Empty;
                l1_last_name = string.Empty;
                l1_first_name = string.Empty;
                l1_date_grp = string.Empty;
                l1_yy = 0;
                l1_mm = 0;
                l1_dd = 0;
                l1_sex = string.Empty;
                l1_id_no = string.Empty;
                l1_ohip_no = string.Empty;
                l1_health_nbr = string.Empty;
                return string.Empty;
            }
            else
            {
                return "".PadRight(4) +
                       Util.Str(l1_func_cd).PadRight(2) +
                        "".PadRight(4) +
                       Util.Str(l1_last_name).PadRight(24) +
                       "".PadRight(2) +
                       Util.Str(l1_first_name).PadRight(24) +
                       "".PadRight(1) +
                      // l1_date_grp;
                      Util.BlankWhenZero("0000",l1_yy,4).Trim() +  //  Util.Str(l1_yy).PadLeft(4, '0') +
                      Util.Str(l1_slash1).PadRight(1) +
                      Util.BlankWhenZero("00",l1_mm,2).Trim() +   //Util.Str(l1_mm).PadLeft(2, '0') +
                     Util.Str(l1_slash2).PadRight(1) +
                     Util.BlankWhenZero("00",l1_dd,2).Trim() +   //Util.Str(l1_dd).PadLeft(2, '0') +
                     "".PadRight(1) +
                     Util.Str(l1_sex).PadRight(1) +
                     "".PadRight(3) +
                    Util.Str(l1_id_no).PadRight(15) +
                    "".PadRight(2) +
                    Util.Str(l1_ohip_no).PadRight(8) +
                    "".PadRight(4) +
                    Util.Str(l1_health_nbr).PadRight(10) +
                    "".PadRight(17);
            }
        }

        private async Task<string> l2_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "l2_line_grp");

            if (isInitialize)
            {
                l2_street_addr = string.Empty;
                l2_city = string.Empty;
                l2_prov = string.Empty;
                l2_postal_cd = string.Empty;
                l2_phone_no = string.Empty;
                l2_version_cd = string.Empty;
                l2_mess_id = string.Empty;
                return string.Empty;
            }
            else
            {
                return "  ADDRESS: ".PadRight(11) +
               Util.Str(l2_street_addr).PadRight(28) +
                ", " +
               Util.Str(l2_city).PadRight(18) +
                ", " +
               Util.Str(l2_prov).PadRight(4) +
                ", " +
               Util.Str(l2_postal_cd).PadRight(6) +
                "    PHONE: ".PadRight(11) +
               Util.Str(l2_phone_no).PadRight(20) +
                "  VERSION:  ".PadRight(12) +
               Util.Str(l2_version_cd).PadRight(2) +
                "   MESSAGE: ".PadRight(12) +
              Util.Str(l2_mess_id).PadLeft(2, '0');
            }
        }

        private async Task<string> l4_line_grp(bool isInitialize = false)
        {
            Util.Trakker(++ctr, "l4_line_grp");

            if (isInitialize)
            {
                l4_title = string.Empty;
                l4_ctr = 0;
                return string.Empty;
            }
            else
            {
                return Util.Str(l4_title).PadRight(45) +
                      Util.ImpliedIntegerFormat("#0", l4_ctr, 5, false) +
                      "".PadRight(82);
            }
        }

        private async Task<string> l5_line_grp()
        {
            Util.Trakker(++ctr, "l5_line_grp");

            return "TAPE VERSION CODE:".PadRight(20) +
                     Util.Str(l5_tp_pat_version_cd).PadRight(2) +
                    "          RMA VERSION CODE:".PadRight(30) +
                    Util.Str(l5_ws_pat_version_cd).PadRight(2) +
                     "          CHART NUMBER:".PadRight(25) +
                   Util.Str(l5_chart_nbr).PadRight(30) +
                    "    MESSAGE ID: ".PadRight(16) +
                   Util.Str(l5_mess_id).PadLeft(2, '0');
        }

        private async Task<string> prt_det_line1_grp()
        {
            Util.Trakker(++ctr, "prt_det_line1_grp");

            return Util.Str(prt_lit1).PadRight(10) +
                    Util.Str(prt_ohip_health_nbr).PadRight(12) +
                     "".PadRight(9) +
                    Util.Str(rma_birth_date_yy).PadLeft(4, '0') +
                     "/" +
                    Util.Str(rma_birth_date_mm).PadLeft(2, '0') +
                    "/" +
                    Util.Str(rma_birth_date_dd).PadLeft(2, '0') +
                    "".PadRight(9) +
                    Util.Str(rma_version_cd).PadRight(2) +
                    "".PadRight(10) +
                   Util.Str(rma_prov_cd).PadRight(2) +
                   "".PadRight(10) +
                   Util.Str(rma_reason_desc).PadRight(60);
        }

        private async Task<string> prt_det_line2_grp()
        {
            Util.Trakker(++ctr, "prt_det_line2_grp");

            return Util.Str(prt_lit2).PadRight(10) +
                   Util.BlankWhenZero(Util.Str(disk_doctor_nbr).PadLeft(6, '0'),6) +
                   Util.Str(disk_account_id).PadRight(8) +
                   "".PadRight(7) +
                   Util.Str(disk_birth_date_yy).PadLeft(4, '0') +
                   "/" +
                   Util.Str(disk_birth_date_mm).PadLeft(2, '0') +
                   "/" +
                  Util.Str(disk_birth_date_dd).PadLeft(2, '0') +
                   "".PadRight(9) +
                  Util.Str(disk_version_cd).PadRight(2) +
                   "".PadRight(10) +
                  Util.Str(disk_prov_cd).PadRight(2) +
                  "".PadRight(70);
        }

        private async Task<string> run_date_grp()
        {
            Util.Trakker(++ctr, "run_date_grp");

            return Util.Str(run_yy).PadLeft(4, '0') +
                     "/" +
                    Util.Str(run_mm).PadLeft(2, '0') +
                     "/" +
                   Util.Str(run_dd).PadLeft(2, '0');
        }

        private async Task<string> run_time_grp()
        {
            Util.Trakker(++ctr, "run_time_grp");

            return Util.Str(run_hrs).PadLeft(2, '0') +
                    ":" +
                  Util.Str(run_min).PadLeft(2, '0') +
                    ":" +
                 Util.Str(run_sec).PadLeft(2, '0');
        }

        private async Task initialize_ws_pat_mstr_rec()
        {
            Util.Trakker(++ctr, "initialize_ws_pat_mstr_rec");

            //    05  ws - pat - acronym.
            ws_pat_acronym_grp = string.Empty;
            //10  ws - pat - acronym - first6               pic x(6).
            ws_pat_acronym_first6_chld = string.Empty;
            //      10  ws - pat - acronym - last3                pic xxx.
            ws_pat_acronym_last3_chld = string.Empty;

            //  05  ws - pat - ohip - mmyy.
            ws_pat_ohip_mmyy_grp = string.Empty;

            //      10  ws - pat - ohip -out -prov.
            ws_pat_ohip_out_prov_grp = string.Empty;

            //          15  ws - pat - ohip - nbr                 pic 9(8).
            ws_pat_ohip_nbr_chld = 0;

            //          15  ws - pat - ohip - nbr - r - alpha redefines ws - pat - ohip - nbr
            ws_pat_ohip_nbr_r_alpha = string.Empty;
            //                                              pic x(8).


            //          15  ws - pat - ohip - nbr - MB - def redefines ws - pat - ohip - nbr.
            ws_pat_ohip_nbr_MB_def = string.Empty;

            //              20  ws - pat - ohip - nbr - MB          pic 9(6).
            ws_pat_ohip_nbr_MB_chld = 0;

            //              20  filler                      pic x(2).

            //          15  ws - pat - ohip - nbr - NT - def redefines ws - pat - ohip - nbr.
            ws_pat_ohip_nbr_NT_def_grp = string.Empty;

            //              20  ws - pat - ohip - nbr - NT - 1 - char   pic x(1).
            ws_pat_ohip_nbr_NT_1_char_chld = string.Empty;

            //              20  ws - pat - ohip - nbr - NT          pic 9(7).
            ws_pat_ohip_nbr_NT_chld = 0;

            //          15  ws - pat - mm                       pic 99.
            ws_pat_mm_chld = 0;

            //          15  ws - pat - yy                       pic 99.
            ws_pat_yy_chld = 0;

            //      10  filler                              pic x(3).

            //  05  ws - pat - ohip - mmyy - r  redefines ws - pat - ohip - mmyy.
            ws_pat_ohip_mmyy_r = string.Empty;

            //      10  ws - pat - direct - alpha.
            ws_pat_direct_alpha_grp = string.Empty;

            //          15  ws - pat - alpha1                   pic x.
            ws_pat_alpha1_chld = string.Empty;

            //          15  ws - pat - alpha2 - 3         pic xx.
            ws_pat_alpha2_3_chld = string.Empty;

            //      10  ws - pat - direct - yy                    pic xx.
            ws_pat_direct_yy = string.Empty;

            //      10  ws - pat - direct - mm                    pic xx.
            ws_pat_direct_mm = string.Empty;


            //      10  ws - pat - direct - dd                    pic xx.
            ws_pat_direct_dd = string.Empty;

            //      10  ws - pat - direct - filler        pic x(6).
            ws_pat_direct_filler = string.Empty;


            //  05  ws - pat - chart - nbr.
            ws_pat_chart_nbr_grp = string.Empty;

            //      10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char_chld = string.Empty;

            //      10  pat - chart - remainder         pic x(9).
            pat_chart_remainder_chld = string.Empty;

            //  05  ws - pat - chart - nbr - 2.
            ws_pat_chart_nbr_2_grp = string.Empty;

            //      10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char2_chld = string.Empty;

            //      10  pat - chart - remainder         pic x(9).
            pat_chart_remainder2_chld = string.Empty;

            //  05  ws - pat - chart - nbr - 3.
            ws_pat_chart_nbr_3_grp = string.Empty;

            //      10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char3_chld = string.Empty;

            //      10  pat - chart - remainder         pic x(9).
            pat_chart_remainder3_chld = string.Empty;

            //  05  ws - pat - chart - nbr - 4.
            ws_pat_chart_nbr_4_grp = string.Empty;

            //      10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char4_chld = string.Empty;

            //      10  pat - chart - remainder         pic x(9).
            pat_chart_remainder4_chld = string.Empty;

            //  05  ws - pat - chart - nbr - 5.
            ws_pat_chart_nbr_5_grp = string.Empty;

            //      10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char5_chld = string.Empty;

            //      10  pat - chart - remainder         pic x(10).
            pat_chart_remainder5_chld = string.Empty;


            //  05  ws - pat - surname                          pic x(25).
            ws_pat_surname = string.Empty;

            //  05  ws - pat - surname - r  redefines  ws - pat - surname.
            ws_pat_surname_r_grp = string.Empty;

            //      10  ws - pat - surname - first6               pic x(6).
            ws_pat_surname_first6_chld = string.Empty;

            //      10  ws - pat - surname - last19               pic x(19).
            ws_pat_surname_last19_chld = string.Empty;

            //  05  ws - pat - surname - rr  redefines  ws - pat - surname.
            ws_pat_surname_rr_grp = string.Empty;

            //      10  ws - pat - surname - first3               pic x(3).
            ws_pat_surname_first3_chld = string.Empty;

            //      10  ws - pat - surname - last22               pic x(22).
            ws_pat_surname_last22_chld = string.Empty;

            //  05  ws - pat - given - name                       pic x(17).
            ws_pat_given_name = string.Empty;

            //  05  ws - pat - given - name - r  redefines  ws - pat - given - name.
            ws_pat_given_name_r_grp = string.Empty;

            //      10  ws - pat - given - name - first3            pic xxx.
            ws_pat_given_name_first3_chld = string.Empty;

            //      10  ws - pat - given - name - last14            pic x(14).
            ws_pat_given_name_last14_chld = string.Empty;

            //  05  ws - pat - given - name - rr redefines ws - pat - given - name - r.
            ws_pat_given_name_rr_grp = string.Empty;

            //      10  ws - pat - given - name - first1            pic x.
            ws_pat_given_name_first1_chld = string.Empty;

            //      10  filler                              pic x(16).


            //  05  ws - pat - init.
            ws_pat_init_grp = string.Empty;

            //      10  ws - pat - init1                        pic x.
            ws_pat_init1_chld = string.Empty;

            //      10  ws - pat - init2                        pic x.
            ws_pat_init2_chld = string.Empty;

            //      10  ws - pat - init3                        pic x.
            ws_pat_init3_chld = string.Empty;

            //  05  ws - pat - location - field.
            ws_pat_location_field_grp = string.Empty;

            //      10  ws - pat - location - field - 1 - 3           pic x(3).
            ws_pat_location_field_1_3_chld = string.Empty;

            //      10  filler                              pic x(1).
            ws_filler = string.Empty;

            //  05  ws - pat - last - doc - nbr - seen                pic x(3).
            ws_pat_last_doc_nbr_seen = string.Empty;

            //  05  ws - pat - birth - date                       pic 9(8).
            ws_pat_birth_date = 0;

            //  05  ws - pat - birth - date - r  redefines  ws - pat - birth - date.
            ws_pat_birth_date_r_grp = string.Empty;

            //      10  ws - pat - birth - date - yy                pic 9(4).
            ws_pat_birth_date_yy_chld = 0;

            //      10  ws - pat - birth - date - yy - r redefines ws - pat - birth - date - yy.
            ws_pat_birth_date_yy_r_grp = string.Empty;

            //              15 ws - pat - birth - date - yy - 12      pic 99.
            ws_pat_birth_date_yy_12_chld = 0;

            //              15 ws - pat - birth - date - yy - 34      pic 99.
            ws_pat_birth_date_yy_34_chld = 0;

            //      10  ws - pat - birth - date - mm                pic 99.
            ws_pat_birth_date_mm_chld = 0;

            //      10  ws - pat - birth - date - dd                pic 99.
            ws_pat_birth_date_dd_chld = 0;

            //  05  ws - pat - date - last - maint                  pic 9(8).
            ws_pat_date_last_maint = 0;

            //  05  ws - pat - date - last - maint - r redefines ws - pat - date - last - maint.
            ws_pat_date_last_maint_r_grp = string.Empty;

            //      10  ws - pat - date - last - maint - yy           pic 9(4).
            ws_pat_date_last_maint_yy_chld = 0;

            //      10  ws - pat - date - last - maint - mm           pic 99.
            ws_pat_date_last_maint_mm_chld = 0;

            //      10  ws - pat - date - last - maint - dd           pic 99.
            ws_pat_date_last_maint_dd_chld = 0;


            //  05  ws - pat - date - last - visit          pic 9(8).
            ws_pat_date_last_visit = 0;

            //  05  ws - pat - date - last - visit - r redefines ws - pat - date - last - visit.
            ws_pat_date_last_visit_r_grp = string.Empty;

            //      10  ws - pat - date - last - visit - yy           pic 9(4).
            ws_pat_date_last_visit_yy_chld = 0;

            //      10  ws - pat - date - last - visit - mm           pic 99.
            ws_pat_date_last_visit_mm_chld = 0;

            //      10  ws - pat - date - last - visit - dd           pic 99.
            ws_pat_date_last_visit_dd_chld = 0;


            //  05  ws - pat - date - last - admit          pic 9(8).
            ws_pat_date_last_admit = 0;

            //  05  ws - pat - date - last - admit - r redefines ws - pat - date - last - admit.
            ws_pat_date_last_admit_r_grp = string.Empty;

            //      10  ws - pat - date - last - admit - yy           pic 9(4).
            ws_pat_date_last_admit_yy_chld = 0;

            //      10  ws - pat - date - last - admit - mm           pic 99.
            ws_pat_date_last_admit_mm_chld = 0;

            //      10  ws - pat - date - last - admit - dd           pic 99.
            ws_pat_date_last_admit_dd_chld = 0;


            //  05  ws - pat - phone - nbr.
            ws_pat_phone_nbr_grp = string.Empty;

            //      10  ws - pat - phone - nbr - first3             pic 999.
            ws_pat_phone_nbr_first3_chld = 0;

            //      10  ws - pat - phone - nbr - last4              pic 9(4).
            ws_pat_phone_nbr_last4_chld = 0;

            //      10  ws - pat - phone - nbr - remainder          pic x(13).
            ws_pat_phone_nbr_remainder_chld = string.Empty;

            //  05  ws - pat - total - nbr - visits                 pic 9(5).
            ws_pat_total_nbr_visits = 0;

            //  05  ws - pat - total - nbr - claims                 pic 9(5).
            ws_pat_total_nbr_claims = 0;

            //  05  ws - pat - sex                              pic x.
            ws_pat_sex = string.Empty;

            //  05  ws - pat -in-out pic x.
            ws_pat_in_out = string.Empty;

            //  05  ws - pat - nbr - outstanding - claims           pic 9(4).
            ws_pat_nbr_outstanding_claims = 0;

            //  05  ws - key - pat - mstr.
            ws_key_pat_mstr_grp = string.Empty;
            //      10  ws - pat - i - key                        pic x.
            ws_pat_i_key_chld = string.Empty;
            //      10  ws - pat - con - nbr                      pic 99.
            ws_pat_con_nbr_chld = 0;
            //      10  ws - pat - i - nbr                        pic 9(12).
            ws_pat_i_nbr_chld = 0;

            //      10  filler                              pic x.
            ws_filler4 = string.Empty;

            //  05  ws - pat - health - nbr                       pic 9(10).
            ws_pat_health_nbr = 0;

            //  05  ws - pat - version - cd                       pic xx.
            ws_pat_version_cd = string.Empty;

            //  05  ws - pat - health - 65 - ind                    pic x.
            ws_pat_health_65_ind = string.Empty;

            //  05  ws - pat - expiry - date.
            ws_pat_expiry_date_grp = string.Empty;

            //      10  ws - pat - expiry - yy                    pic 99.
            ws_pat_expiry_yy_chld = 0;

            //      10  ws - pat - expiry - mm                    pic 99.
            ws_pat_expiry_mm_chld = 0;

            //  05  ws - pat - prov - cd                          pic xx.
            ws_pat_prov_cd = string.Empty;

            //  05  ws - subscr - addr1                         pic x(30).
            ws_subscr_addr1 = string.Empty;
            //  05  ws - subscr - addr2                         pic x(30).
            ws_subscr_addr2 = string.Empty;
            //  05  ws - subscr - addr3                         pic x(30).
            ws_subscr_addr3 = string.Empty;
            //  05  ws - subscr - prov - cd                       pic x(2).
            ws_subscr_prov_cd = string.Empty;

            //  05  ws - subscr - postal - cd                     pic x(10).
            ws_subscr_postal_cd = string.Empty;

            //  05  ws - subscr - postal - cd - r  redefines  ws - subscr - postal - cd.
            ws_subscr_postal_cd_r_grp = string.Empty;
            //      10  ws - subscr - post - code1.
            ws_subscr_post_code1_grp = string.Empty;
            //          15  ws - subscr - post - cd1                      pic x.
            ws_subscr_post_cd1_chld = string.Empty;
            //          15  ws - subscr - post - cd2                      pic 9.
            ws_subscr_post_cd2_chld = string.Empty;
            //          15  ws - subscr - post - cd3                      pic x.
            ws_subscr_post_cd3_chld = string.Empty;
            //      10  ws - subscr - post - code2.
            ws_subscr_post_code2_grp = string.Empty;
            //          15  ws - subscr - post - cd4                      pic 9.
            ws_subscr_post_cd4_chld = string.Empty;
            //          15  ws - subscr - post - cd5                      pic x.
            ws_subscr_post_cd5_chld = string.Empty;
            //          15  ws - subscr - post - cd6                      pic 9.
            ws_subscr_post_cd6_chld = string.Empty;
            //      10  filler                                      pic x(4).
            ws_filler2 = string.Empty;

            //  05  ws - subscr - msg - data.
            ws_subscr_msg_data_grp = string.Empty;
            //      10  ws - subscr - msg - nbr                           pic xx.
            ws_subscr_msg_nbr = string.Empty;
            //      10  ws - subscr - dt - msg - no - eff - to                  pic 9(8).
            ws_subscr_dt_msg_no_eff_to = 0;
            //      10  ws - subscr - dt - msg - no - eff - to - r
            ws_subscr_dt_msg_no_eff_to_r_grp = string.Empty;
            //            redefines ws - subscr - dt - msg - no - eff - to.            

            //          15  ws - subscr - dt - msg - no - eff - to - yy   pic 9(4).
            ws_subscr_dt_msg_no_eff_to_yy_chld = 0;
            //          15  ws - subscr - dt - msg - no - eff - to - mm   pic 99.
            ws_subscr_dt_msg_no_eff_to_mm_chld = 0;
            //          15  ws - subscr - dt - msg - no - eff - to - dd   pic 99.
            ws_subscr_dt_msg_no_eff_to_dd_chld = 0;
            //      10  ws - subscr - dt - msg - no - eff - to - r1
            ws_subscr_dt_msg_no_eff_to_r1 = string.Empty;
            //            redefines ws - subscr - dt - msg - no - eff - to - r      
            //                                                      pic x(8).

            //      10  ws - subscr - date - last - statement               pic 9(8).
            ws_subscr_date_last_statement = 0;
            //      10  ws - subscr - date - last - stmnt - r      
            //            redefines ws - subscr - date - last - statement.
            ws_subscr_date_last_stmnt_r_grp = string.Empty;
            //          15  ws - subscr - date - last - stmnt - yy    pic 9(4).
            ws_subscr_date_last_stmnt_yy_chld = 0;
            //          15  ws - subscr - date - last - stmnt - mm    pic 99.
            ws_subscr_date_last_stmnt_mm_chld = 0;
            //          15  ws - subscr - date - last - stmnt - dd    pic 99.
            ws_subscr_date_last_stmnt_dd_chld = 0;
            //  05  ws - subscr - auto - update                           pic x.
            ws_subscr_auto_update = string.Empty;
            //  05  ws - pat - last - mod - by                              pic x(5).
            ws_pat_last_mod_by = string.Empty;
            //  05  ws - pat - date - last - elig - mailing                   pic 9(8).
            ws_pat_date_last_elig_mailing = 0;
            //  05  ws - pat - date - last - elig - maint                     pic 9(8).
            ws_pat_date_last_elig_maint = 0;
            //  05  ws - pat - last - birth - date                          pic 9(8).
            ws_pat_last_birth_date = 0;
            //  05  ws - pat - last - birth - date - r redefines ws - pat - last - birth - date.
            ws_pat_last_birth_date_r_grp = string.Empty;
            //      10 ws - pat - last - birth - date - yy                    pic 9(4).
            ws_pat_last_birth_date_yy_chld = 0;
            //      10 ws - pat - last - birth - date - mm                    pic 9(2).
            ws_pat_last_birth_date_mm_chld = 0;
            //      10 ws - pat - last - birth - date - dd                    pic 9(2).
            ws_pat_last_birth_date_dd_chld = 0;
            //  05  ws - pat - last - version - cd                          pic x(2).
            ws_pat_last_version_cd = string.Empty;
            //  05  ws - pat - mess - code                                pic x(3).
            ws_pat_mess_code = string.Empty;
            //  05  ws - pat - country                                  pic x(1).
            ws_pat_country = string.Empty;
            //  05  ws - pat - no - of - letter - sent                        pic 99.
            ws_pat_no_of_letter_sent = 0;
            //  05  ws - pat - dialysis                                 pic x(1).
            ws_pat_dialysis = string.Empty;
            //  05  ws - pat - ohip - validiation - status                  pic x.
            ws_pat_ohip_validiation_status = string.Empty;
            //  05  ws - pat - obec - status                              pic x(1).
            ws_pat_obec_status = string.Empty;

        }

        private async Task move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec()
        {
            Util.Trakker(++ctr, "move_ObjTp_Pat_Mstr_to_Ws_Tp_Pat_Mstr_Rec");

            ws_tp_pat_func_code = Util.Str(objTp_pat_mstr_rec.tp_pat_func_code);
            ws_tp_pat_last_name_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name).PadRight(24);
            ws_tp_pat_last_name_6_chld = Util.Str(ws_tp_pat_last_name_grp).Substring(0, 6);
            ws_tp_pat_last_name_18_chld = Util.Str(ws_tp_pat_last_name_grp).Substring(6, 18);
            ws_tp_pat_first_name_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name).PadRight(24);
            ws_tp_pat_first_name_3_chld = Util.Str(ws_tp_pat_first_name_grp).Substring(0, 3);
            ws_tp_pat_first_name_21_chld = Util.Str(ws_tp_pat_first_name_grp).Substring(3, 21);
            ws_tp_pat_birth_date = Util.Str(objTp_pat_mstr_rec.tp_pat_birth_date).PadRight(10);
            ws_tp_pat_birth_date_r = ws_tp_pat_birth_date;
            ws_tp_pat_birth_yy = Util.NumInt(Util.Str(ws_tp_pat_birth_date_r).Substring(0, 4));
            ws_tp_pat_birth_yy_r = Util.NumInt(ws_tp_pat_birth_yy);
            ws_tp_pat_birth_yy_first_2_chld = Util.NumInt(Util.Str(ws_tp_pat_birth_yy).PadRight(4).Substring(0, 2));
            ws_tp_pat_birth_yy_last_2_chld = Util.NumInt(Util.Str(ws_tp_pat_birth_yy).PadRight(4).Substring(2, 2));
            ws_tp_pat_slash1 = Util.Str(ws_tp_pat_birth_date_r).Substring(4, 1);
            ws_tp_pat_birth_mm = Util.NumInt(Util.Str(ws_tp_pat_birth_date_r).Substring(5, 2));
            ws_tp_pat_slash2 = Util.Str(ws_tp_pat_birth_date_r).Substring(7, 1);
            ws_tp_pat_birth_dd = Util.NumInt(Util.Str(ws_tp_pat_birth_date_r).Substring(8, 2));
            ws_tp_pat_sex = Util.Str(objTp_pat_mstr_rec.tp_pat_sex);
            ws_tp_pat_id_no = Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).PadRight(15);
            ws_tp_pat_id_no_r = ws_tp_pat_id_no;
            ws_tp_pat_id_no_first_8_digits_grp = Util.Str(ws_tp_pat_id_no_r).Substring(0, 14);
            ws_tp_pat_id_no_site = Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(0, 1);
            ws_tp_pat_id_no_yy = Util.NumInt(Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(1, 2));
            ws_tp_pat_id_no_mm = Util.NumInt(Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(2, 2));
            ws_tp_pat_id_no_5_digit = Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(4, 1);
            ws_tp_pat_id_no_6_7_digit = Util.NumInt(Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(5, 2));
            ws_tp_pat_id_no_8_digit = Util.NumInt(Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(7, 1));
            ws_tp_pat_id_no_reminder = Util.Str(ws_tp_pat_id_no_first_8_digits_grp).Substring(8, 5);
            ws_tp_pat_id_no_last_digit = Util.Str(ws_tp_pat_id_no_r).Substring(14, 1);
            ws_tp_pat_id_no_r2_grp = Util.Str(ws_tp_pat_id_no).PadRight(15);
            ws_tp_pat_id_no_alpha = Util.Str(ws_tp_pat_id_no_r2_grp).Substring(0, 1);
            ws_tp_pat_id_no_9_digits_grp = Util.Str(ws_tp_pat_id_no_r2_grp).Substring(1, 9);
            ws_tp_pat_id_no_1_3_digits = Util.NumInt(Util.Str(ws_tp_pat_id_no_9_digits_grp).Substring(0, 3));
            ws_tp_pat_id_no_4_9_digits = Util.NumInt(Util.Str(ws_tp_pat_id_no_9_digits_grp).Substring(3, 6));
            ws_tp_pat_id_no_10_digit = Util.Str(ws_tp_pat_id_no_r2_grp).Substring(10, 1);
            ws_tp_pat_id_no_filler = Util.Str(ws_tp_pat_id_no_r2_grp).Substring(11, 4);
            ws_tp_pat_street_addr = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr);
            ws_tp_pat_street_addr2 = Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr); // todo..??? ws_tp_pat_street_addr2
            ws_tp_pat_city = Util.Str(objTp_pat_mstr_rec.tp_pat_city);
            ws_tp_pat_prov = Util.Str(objTp_pat_mstr_rec.tp_pat_prov);
            ws_tp_pat_postal_code = Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code).PadRight(6);
            ws_tp_pat_postal_code_r_grp = ws_tp_pat_postal_code;
            ws_tp_pat_postal_code_1 = Util.Str(ws_tp_pat_postal_code_r_grp).Substring(0, 1);
            ws_tp_pat_postal_code_2 = Util.Str(ws_tp_pat_postal_code_r_grp).Substring(1, 1);
            ws_tp_pat_postal_code_3 = Util.Str(ws_tp_pat_postal_code_r_grp).Substring(2, 1);
            ws_tp_pat_postal_code_4 = Util.Str(ws_tp_pat_postal_code_r_grp).Substring(3, 1);
            ws_tp_pat_postal_code_5 = Util.Str(ws_tp_pat_postal_code_r_grp).Substring(4, 1);
            ws_tp_pat_postal_code_6 = Util.Str(ws_tp_pat_postal_code_r_grp).Substring(5, 1);
            ws_tp_pat_phone_no = Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no);
            ws_tp_pat_ohip_no = Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no);
            ws_tp_pat_health_nbr = Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr);
            ws_tp_pat_version_cd_grp = objTp_pat_mstr_rec.tp_pat_version_cd;
            ws_tp_pat_version_cd_1_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd_1);
            ws_tp_pat_version_cd_2_chld = Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd_2);
            ws_tp_pat_health_65_ind = Util.Str(objTp_pat_mstr_rec.tp_pat_health_65_ind);
            ws_tp_pat_expiry_date_grp = Util.Str(objTp_pat_mstr_rec.tp_pat_expiry_date).PadLeft(4, '0');
            ws_tp_pat_expiry_mm_chld = Util.NumInt(Util.Str(ws_tp_pat_expiry_date_grp).Substring(0, 2));
            ws_tp_pat_expiry_yy_chld = Util.NumInt(Util.Str(ws_tp_pat_expiry_date_grp).Substring(2, 2));
        }

        private async Task move_ws_pat_mstr_rec_to_pat_mstr_rec()
        {
            Util.Trakker(++ctr, "move_ws_pat_mstr_rec_to_pat_mstr_rec");

            objPat_mstr_rec.PAT_ACRONYM_FIRST6 = Util.Str(ws_pat_acronym_first6_chld);
            objPat_mstr_rec.PAT_ACRONYM_LAST3 = Util.Str(ws_pat_acronym_last3_chld);

            objPat_mstr_rec.PAT_DIRECT_YY = Util.NumInt(ws_pat_direct_yy);
            objPat_mstr_rec.PAT_DIRECT_MM = Util.NumInt(ws_pat_direct_mm);
            objPat_mstr_rec.PAT_DIRECT_DD = Util.NumInt(ws_pat_direct_dd);
            objPat_mstr_rec.PAT_DIRECT_LAST_6 = Util.Str(ws_pat_direct_filler).Trim();

            ws_pat_direct_alpha_grp = Util.Str(ws_pat_alpha1_chld).PadRight(1) + Util.Str(ws_pat_alpha2_3_chld).PadRight(2);
            objPat_mstr_rec.PAT_DIRECT_ALPHA = ws_pat_direct_alpha_grp.TrimEnd();

            ws_pat_chart_nbr_grp = Util.Str(pat_chart_1st_char_chld).PadRight(1) + Util.Str(pat_chart_remainder_chld).PadRight(9);
            objPat_mstr_rec.PAT_CHART_NBR = ws_pat_chart_nbr_grp.TrimEnd();

            ws_pat_chart_nbr_2_grp = Util.Str(pat_chart_1st_char2_chld).PadRight(1) + Util.Str(pat_chart_remainder2_chld).PadRight(9);
            objPat_mstr_rec.PAT_CHART_NBR_2 = ws_pat_chart_nbr_2_grp.TrimEnd();

            ws_pat_chart_nbr_3_grp = Util.Str(pat_chart_1st_char3_chld).PadRight(1) + Util.Str(pat_chart_remainder3_chld).PadRight(9);
            objPat_mstr_rec.PAT_CHART_NBR_3 = ws_pat_chart_nbr_3_grp.TrimEnd();

            ws_pat_chart_nbr_4_grp = Util.Str(pat_chart_1st_char4_chld).PadRight(1) + Util.Str(pat_chart_remainder4_chld).PadRight(9);
            objPat_mstr_rec.PAT_CHART_NBR_4 = ws_pat_chart_nbr_4_grp.TrimEnd();

            ws_pat_chart_nbr_5_grp = Util.Str(pat_chart_1st_char5_chld).PadRight(1) + Util.Str(pat_chart_remainder5_chld).PadRight(10);
            objPat_mstr_rec.PAT_CHART_NBR_5 = ws_pat_chart_nbr_5_grp.TrimEnd();

            ws_pat_surname_first3_chld = Util.Str(ws_pat_surname).PadRight(25).Substring(0, 3);
            ws_pat_surname_last22_chld = Util.Str(ws_pat_surname).PadRight(25).Substring(3, 22).TrimEnd();
            objPat_mstr_rec.PAT_SURNAME_FIRST3 = ws_pat_surname_first3_chld;
            objPat_mstr_rec.PAT_SURNAME_LAST22 = ws_pat_surname_last22_chld;

            ws_pat_given_name_first1_chld = Util.Str(ws_pat_given_name).PadRight(17).Substring(0, 1);
            ws_filler3 = Util.Str(ws_pat_given_name).PadRight(17).Substring(1, 16).TrimEnd();
            objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1 = ws_pat_given_name_first1_chld;
            objPat_mstr_rec.FILLER3 = ws_filler3;

            ws_pat_init1_chld = Util.Str(ws_pat_init_grp).PadRight(3).Substring(0, 1);
            ws_pat_init2_chld = Util.Str(ws_pat_init_grp).PadRight(3).Substring(1, 1);
            ws_pat_init3_chld = Util.Str(ws_pat_init_grp).PadRight(3).Substring(2, 1);
            objPat_mstr_rec.PAT_INIT1 = ws_pat_init1_chld;
            objPat_mstr_rec.PAT_INIT2 = ws_pat_init2_chld;
            objPat_mstr_rec.PAT_INIT3 = ws_pat_init3_chld;

            ws_pat_location_field_grp = Util.Str(ws_pat_location_field_1_3_chld).PadRight(3) + Util.Str(ws_filler).PadRight(1);
            objPat_mstr_rec.PAT_LOCATION_FIELD = ws_pat_location_field_grp.TrimEnd();

            objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN = Util.Str(ws_pat_last_doc_nbr_seen).Trim();           

            objPat_mstr_rec.PAT_BIRTH_DATE_YY = ws_pat_birth_date_yy_chld;
            objPat_mstr_rec.PAT_BIRTH_DATE_MM = ws_pat_birth_date_mm_chld;
            objPat_mstr_rec.PAT_BIRTH_DATE_DD = ws_pat_birth_date_dd_chld;

            objPat_mstr_rec.PAT_DATE_LAST_MAINT = Util.NumInt(ws_pat_date_last_maint);
            objPat_mstr_rec.PAT_DATE_LAST_VISIT = ws_pat_date_last_visit;

            objPat_mstr_rec.PAT_DATE_LAST_ADMIT = ws_pat_date_last_admit;

            //ws_pat_phone_nbr_grp = Util.Str(ws_pat_phone_nbr_first3_chld).PadLeft(3, '0') + Util.Str(ws_pat_phone_nbr_last4_chld).PadLeft(4, '0') + Util.Str(ws_pat_phone_nbr_remainder_chld).PadRight(13);
            objPat_mstr_rec.PAT_PHONE_NBR = ws_pat_phone_nbr_grp.TrimEnd();

            objPat_mstr_rec.PAT_TOTAL_NBR_VISITS = ws_pat_total_nbr_visits;
            objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS = ws_pat_total_nbr_claims;

            objPat_mstr_rec.PAT_SEX = Util.Str(ws_pat_sex).Trim();
            objPat_mstr_rec.PAT_IN_OUT = Util.Str(ws_pat_in_out).Trim();
            objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS = ws_pat_nbr_outstanding_claims;

            objPat_mstr_rec.PAT_I_KEY = Util.Str(ws_pat_i_key_chld).TrimEnd();
            objPat_mstr_rec.PAT_CON_NBR = Util.NumInt(ws_pat_con_nbr_chld);
            objPat_mstr_rec.PAT_I_NBR = Util.NumLongInt(ws_pat_i_nbr_chld);
            objPat_mstr_rec.FILLER4 = Util.Str(ws_filler4).TrimEnd();

            objPat_mstr_rec.PAT_HEALTH_NBR = Util.NumLongInt(ws_pat_health_nbr);
            objPat_mstr_rec.PAT_VERSION_CD = ws_pat_version_cd.TrimEnd();
            objPat_mstr_rec.PAT_HEALTH_65_IND = Util.Str(ws_pat_health_65_ind).Trim();

            ws_pat_expiry_yy_chld = Util.NumInt(Util.Str(ws_pat_expiry_date_grp).PadLeft(4, '0').Substring(0, 2));
            ws_pat_expiry_mm_chld = Util.NumInt(Util.Str(ws_pat_expiry_date_grp).PadLeft(4, '0').Substring(2, 2));
            objPat_mstr_rec.PAT_EXPIRY_YY = ws_pat_expiry_yy_chld;
            objPat_mstr_rec.PAT_EXPIRY_MM = ws_pat_expiry_mm_chld;

            objPat_mstr_rec.PAT_PROV_CD = Util.Str(ws_pat_prov_cd).TrimEnd();
            objPat_mstr_rec.SUBSCR_ADDR1 = Util.Str(ws_subscr_addr1).TrimEnd();
            objPat_mstr_rec.SUBSCR_ADDR2 = Util.Str(ws_subscr_addr2).TrimEnd();
            objPat_mstr_rec.SUBSCR_ADDR3 = Util.Str(ws_subscr_addr3).TrimEnd();

            objPat_mstr_rec.SUBSCR_PROV_CD = Util.Str(ws_subscr_prov_cd).TrimEnd();

            ws_subscr_post_cd1_chld = ws_subscr_postal_cd.PadRight(6).Substring(0, 1);
            ws_subscr_post_cd2_chld = ws_subscr_postal_cd.PadRight(6).Substring(1, 1);
            ws_subscr_post_cd3_chld = ws_subscr_postal_cd.PadRight(6).Substring(2, 1);
            ws_subscr_post_cd4_chld = ws_subscr_postal_cd.PadRight(6).Substring(3, 1);
            ws_subscr_post_cd5_chld = ws_subscr_postal_cd.PadRight(6).Substring(4, 1);
            ws_subscr_post_cd6_chld = ws_subscr_postal_cd.PadRight(6).Substring(5, 1);
            objPat_mstr_rec.SUBSCR_POST_CD1 = Util.Str(ws_subscr_post_cd1_chld).TrimEnd();
            objPat_mstr_rec.SUBSCR_POST_CD2 = Util.Str(ws_subscr_post_cd2_chld).TrimEnd();
            objPat_mstr_rec.SUBSCR_POST_CD3 = Util.Str(ws_subscr_post_cd3_chld).TrimEnd();
            objPat_mstr_rec.SUBSCR_POST_CD4 = Util.Str(ws_subscr_post_cd4_chld).TrimEnd();
            objPat_mstr_rec.SUBSCR_POST_CD5 = Util.Str(ws_subscr_post_cd5_chld).TrimEnd();
            objPat_mstr_rec.SUBSCR_POST_CD6 = Util.Str(ws_subscr_post_cd6_chld).TrimEnd();
            objPat_mstr_rec.FILLER = Util.Str(ws_filler2).TrimEnd();

            objPat_mstr_rec.SUBSCR_MSG_NBR = Util.Str(ws_subscr_msg_nbr).TrimEnd();
            objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ws_subscr_dt_msg_no_eff_to_yy_chld;
            objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ws_subscr_dt_msg_no_eff_to_mm_chld;
            objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ws_subscr_dt_msg_no_eff_to_dd_chld;

            objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY = Util.NumInt(ws_subscr_date_last_stmnt_yy_chld);
            objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM = Util.NumInt(ws_subscr_date_last_stmnt_mm_chld);
            objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD = Util.NumInt(ws_subscr_date_last_stmnt_dd_chld);

            objPat_mstr_rec.SUBSCR_AUTO_UPDATE = Util.Str(ws_subscr_auto_update).TrimEnd();
            objPat_mstr_rec.PAT_LAST_MOD_BY = Util.Str(ws_pat_last_mod_by).TrimEnd();
            objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING = ws_pat_date_last_elig_mailing;
            objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT = ws_pat_date_last_elig_maint;
            objPat_mstr_rec.PAT_LAST_BIRTH_DATE = ws_pat_last_birth_date;
            objPat_mstr_rec.PAT_LAST_VERSION_CD = Util.Str(ws_pat_last_version_cd).TrimEnd();
            objPat_mstr_rec.PAT_MESS_CODE = Util.Str(ws_pat_mess_code).TrimEnd();
            objPat_mstr_rec.PAT_COUNTRY = Util.Str(ws_pat_country).TrimEnd();
            objPat_mstr_rec.PAT_NO_OF_LETTER_SENT = ws_pat_no_of_letter_sent;
            objPat_mstr_rec.PAT_DIALYSIS = ws_pat_dialysis.TrimEnd();
            objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS = Util.Str(ws_pat_ohip_validiation_status).TrimEnd();
            objPat_mstr_rec.PAT_OBEC_STATUS = Util.Str(ws_pat_obec_status).TrimEnd();
        }

        private async Task move_pat_mstr_rec_to_ws_pat_mstr_rec()
        {
            Util.Trakker(++ctr, "move_pat_mstr_rec_to_ws_pat_mstr_rec");

            ws_pat_acronym_first6_chld = Util.Str(objPat_mstr_rec.PAT_ACRONYM_FIRST6);
            ws_pat_acronym_last3_chld = Util.Str(objPat_mstr_rec.PAT_ACRONYM_LAST3);

            //10  ws - pat - ohip -out-prov.
            //    15  ws - pat - ohip - nbr                 pic 9(8).
            //    15  ws - pat - ohip - nbr - r - alpha redefines ws-pat - ohip - nbr
            //                                    pic x(8).

            //    15  ws - pat - ohip - nbr - MB - def redefines ws - pat - ohip - nbr.
            //        20  ws - pat - ohip - nbr - MB          pic 9(6).
            //        20  filler                      pic x(2).
            //    15  ws - pat - ohip - nbr - NT - def redefines ws - pat - ohip - nbr.
            //        20  ws - pat - ohip - nbr - NT - 1 - char   pic x(1).
            //        20  ws - pat - ohip - nbr - NT          pic 9(7).
            //    15  ws - pat - mm                       pic 99.
            //    15  ws - pat - yy                       pic 99.
            //10  filler                              pic x(3).

            ws_pat_direct_alpha_grp = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3);
            ws_pat_alpha1_chld = Util.Str(ws_pat_direct_alpha_grp).Substring(0, 1);
            ws_pat_alpha2_3_chld = Util.Str(ws_pat_direct_alpha_grp).Substring(1, 2);

            ws_pat_direct_yy = Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadLeft(2, '0');
            ws_pat_direct_mm = Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadLeft(2, '0');
            ws_pat_direct_dd = Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadLeft(2, '0');
            ws_pat_direct_filler = Util.Str(objPat_mstr_rec.PAT_DIRECT_LAST_6).PadRight(6);

            //05  ws - pat - chart - nbr.
            ws_pat_chart_nbr_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR).PadRight(10);
            //    10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char_chld = Util.Str(ws_pat_chart_nbr_grp).Substring(0, 1);
            //    10  pat - chart - remainder         pic x(9).
            pat_chart_remainder_chld = Util.Str(ws_pat_chart_nbr_grp).Substring(1, 9);
            //05  ws - pat - chart - nbr - 2.
            ws_pat_chart_nbr_2_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_2).PadRight(10);
            //        10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char2_chld = Util.Str(ws_pat_chart_nbr_2_grp).Substring(0, 1);
            //        10  pat - chart - remainder         pic x(9).
            pat_chart_remainder2_chld = Util.Str(ws_pat_chart_nbr_2_grp).Substring(1, 9);
            //05  ws - pat - chart - nbr - 3.
            ws_pat_chart_nbr_3_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_3).PadRight(10);
            //        10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char3_chld = Util.Str(ws_pat_chart_nbr_3_grp).Substring(0, 1);
            //        10  pat - chart - remainder         pic x(9).
            pat_chart_remainder3_chld = Util.Str(ws_pat_chart_nbr_3_grp).Substring(1, 9);
            //05  ws - pat - chart - nbr - 4.
            ws_pat_chart_nbr_4_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_4).PadRight(10);
            //        10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char4_chld = Util.Str(ws_pat_chart_nbr_4_grp).Substring(0, 1);
            //        10  pat - chart - remainder         pic x(9).
            pat_chart_remainder4_chld = Util.Str(ws_pat_chart_nbr_4_grp).Substring(1, 9);
            //05  ws - pat - chart - nbr - 5.    
            ws_pat_chart_nbr_5_grp = Util.Str(objPat_mstr_rec.PAT_CHART_NBR_5).PadRight(11);
            //        10  pat - chart - 1st - char          pic x.
            pat_chart_1st_char5_chld = Util.Str(ws_pat_chart_nbr_5_grp).Substring(0, 1);
            //        10  pat - chart - remainder         pic x(10).
            pat_chart_remainder5_chld = Util.Str(ws_pat_chart_nbr_5_grp).Substring(1, 10);

            ws_pat_surname = (Util.Str(objPat_mstr_rec.PAT_SURNAME_FIRST3).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_SURNAME_LAST22).PadRight(22)).Substring(0, 25);

            // 05  ws - pat - surname - r  redefines ws-pat - surname.
            ws_pat_surname_r_grp = ws_pat_surname;
            //    10  ws - pat - surname - first6               pic x(6).
            ws_pat_surname_first6_chld = Util.Str(ws_pat_surname_r_grp).Substring(0, 6);
            //   10  ws - pat - surname - last19               pic x(19).
            ws_pat_surname_last19_chld = Util.Str(ws_pat_surname_r_grp).Substring(6, 19);
            //05  ws - pat - surname - rr  redefines ws-pat - surname.
            ws_pat_surname_rr_grp = ws_pat_surname;
            //    10  ws - pat - surname - first3               pic x(3).
            ws_pat_surname_first3_chld = Util.Str(ws_pat_surname_rr_grp).Substring(0, 3);
            //  10  ws - pat - surname - last22               pic x(22).
            ws_pat_surname_last22_chld = Util.Str(ws_pat_surname_rr_grp).Substring(3, 22);

            //05  ws - pat - given - name                       pic x(17).
            ws_pat_given_name = (Util.Str(objPat_mstr_rec.PAT_GIVEN_NAME_FIRST1).PadRight(1) + Util.Str(objPat_mstr_rec.FILLER3).PadRight(16)).Substring(0, 17);
            //05  ws - pat - given - name - r  redefines  ws - pat - given - name.
            ws_pat_given_name_r_grp = ws_pat_given_name;
            //      10  ws - pat - given - name - first3            pic xxx.
            ws_pat_given_name_first3_chld = Util.Str(ws_pat_given_name_r_grp).Substring(0, 3);
            //      10  ws - pat - given - name - last14            pic x(14).
            ws_pat_given_name_last14_chld = Util.Str(ws_pat_given_name_r_grp).Substring(3, 14);
            //05  ws - pat - given - name - rr redefines ws - pat - given - name - r.
            ws_pat_given_name_rr_grp = ws_pat_given_name_r_grp;
            //      10  ws - pat - given - name - first1            pic x.
            ws_pat_given_name_first1_chld = Util.Str(ws_pat_given_name_rr_grp).Substring(0, 1);
            //      10  filler                              pic x(16).

            ws_pat_init_grp = Util.Str(objPat_mstr_rec.PAT_INIT1).PadRight(1) + Util.Str(objPat_mstr_rec.PAT_INIT2).PadRight(1) + Util.Str(objPat_mstr_rec.PAT_INIT3).PadRight(1);
            ws_pat_init1_chld = Util.Str(ws_pat_init_grp).Substring(0, 1);
            ws_pat_init2_chld = Util.Str(ws_pat_init_grp).Substring(1, 1);
            ws_pat_init3_chld = Util.Str(ws_pat_init_grp).Substring(2, 1);

            ws_pat_location_field_grp = Util.Str(objPat_mstr_rec.PAT_LOCATION_FIELD).PadRight(4);
            ws_pat_location_field_1_3_chld = Util.Str(ws_pat_location_field_grp).Substring(0, 3);
            ws_filler = Util.Str(ws_pat_location_field_grp).Substring(3, 1);

            ws_pat_last_doc_nbr_seen = Util.Str(objPat_mstr_rec.PAT_LAST_DOC_NBR_SEEN);
            ws_pat_birth_date = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY.ToString()).PadLeft(4, '0') + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_MM.ToString()).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_DD.ToString()).PadLeft(2, '0'));

            ws_pat_birth_date_r_grp = Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_YY.ToString()).PadLeft(4, '0') + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_MM.ToString()).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_BIRTH_DATE_DD.ToString()).PadLeft(2, '0'); //Util.Str(ws_pat_birth_date);
            ws_pat_birth_date_yy_chld = Util.NumInt(Util.Str(ws_pat_birth_date_r_grp).Substring(0, 4));
            ws_pat_birth_date_yy_12_chld = Util.NumInt(Util.Str(ws_pat_birth_date_r_grp).Substring(0, 2));
            ws_pat_birth_date_yy_34_chld = Util.NumInt(Util.Str(ws_pat_birth_date_r_grp).Substring(2, 2));
            ws_pat_birth_date_mm_chld = Util.NumInt(Util.Str(ws_pat_birth_date_r_grp).Substring(4, 2));
            ws_pat_birth_date_dd_chld = Util.NumInt(Util.Str(ws_pat_birth_date_r_grp).Substring(6, 2));

            ws_pat_date_last_maint = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadLeft(8, '0'));
            ws_pat_date_last_maint_yy_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadLeft(8, '0').Substring(0, 4));
            ws_pat_date_last_maint_mm_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadLeft(8, '0').Substring(4, 2));
            ws_pat_date_last_maint_dd_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_MAINT).PadLeft(8, '0').Substring(6, 2));

            ws_pat_date_last_visit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_VISIT);
            ws_pat_date_last_visit_yy_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadLeft(8, '0').Substring(0, 4));
            ws_pat_date_last_visit_mm_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadLeft(8, '0').Substring(4, 2));
            ws_pat_date_last_visit_dd_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_VISIT).PadLeft(8, '0').Substring(6, 2));

            ws_pat_date_last_admit = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ADMIT);
            ws_pat_date_last_admit_yy_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadLeft(8, '0').Substring(0, 4));
            ws_pat_date_last_admit_mm_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadLeft(8, '0').Substring(4, 2));
            ws_pat_date_last_admit_dd_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_DATE_LAST_ADMIT).PadLeft(8, '0').Substring(6, 2));

            ws_pat_phone_nbr_grp = Util.Str(objPat_mstr_rec.PAT_PHONE_NBR);  // todo...for the children ..??

            ws_pat_total_nbr_visits = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_VISITS);
            ws_pat_total_nbr_claims = Util.NumInt(objPat_mstr_rec.PAT_TOTAL_NBR_CLAIMS);

            ws_pat_sex = Util.Str(objPat_mstr_rec.PAT_SEX);

            ws_pat_in_out = Util.Str(objPat_mstr_rec.PAT_IN_OUT);

            ws_pat_nbr_outstanding_claims = Util.NumInt(objPat_mstr_rec.PAT_NBR_OUTSTANDING_CLAIMS);

            ws_pat_i_key_chld = Util.Str(objPat_mstr_rec.PAT_I_KEY);
            ws_pat_con_nbr_chld = Util.NumInt(objPat_mstr_rec.PAT_CON_NBR);
            ws_pat_i_nbr_chld = Util.NumLongInt(objPat_mstr_rec.PAT_I_NBR);
            ws_filler4 = Util.Str(objPat_mstr_rec.FILLER4);

            ws_pat_health_nbr = Util.NumLongInt(objPat_mstr_rec.PAT_HEALTH_NBR);
            ws_pat_version_cd = Util.Str(objPat_mstr_rec.PAT_VERSION_CD);
            ws_pat_health_65_ind = Util.Str(objPat_mstr_rec.PAT_HEALTH_65_IND);

            ws_pat_expiry_yy_chld = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_YY);
            ws_pat_expiry_mm_chld = Util.NumInt(objPat_mstr_rec.PAT_EXPIRY_MM);
            ws_pat_expiry_date_grp = Util.Str(objPat_mstr_rec.PAT_EXPIRY_YY).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_EXPIRY_MM).PadLeft(2, '0');

            ws_pat_prov_cd = Util.Str(objPat_mstr_rec.PAT_PROV_CD);

            ws_subscr_postal_cd = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5) + Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            
            ws_subscr_addr1 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR1);
            ws_subscr_addr2 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR2);
            ws_subscr_addr3 = Util.Str(objPat_mstr_rec.SUBSCR_ADDR3);

            ws_subscr_prov_cd = Util.Str(objPat_mstr_rec.SUBSCR_PROV_CD);

            ws_subscr_post_cd1_chld = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD1);
            ws_subscr_post_cd2_chld = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD2);
            ws_subscr_post_cd3_chld = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD3);
            ws_subscr_post_code1_grp =  ws_subscr_post_cd1_chld + Util.Str(ws_subscr_post_cd2_chld) + ws_subscr_post_cd3_chld;

            ws_subscr_post_cd4_chld = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD4);
            ws_subscr_post_cd5_chld = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD5);
            ws_subscr_post_cd6_chld = Util.Str(objPat_mstr_rec.SUBSCR_POST_CD6);
            ws_subscr_post_code2_grp = ws_subscr_post_cd4_chld + Util.Str(ws_subscr_post_cd5_chld) + ws_subscr_post_cd6_chld;

            ws_subscr_postal_cd = ws_subscr_post_code1_grp + ws_subscr_post_code2_grp + new string(' ', 4);
            ws_filler2 = Util.Str(objPat_mstr_rec.FILLER);

            ws_subscr_msg_nbr = Util.Str(objPat_mstr_rec.SUBSCR_MSG_NBR);
            ws_subscr_dt_msg_no_eff_to_yy_chld = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY);
            ws_subscr_dt_msg_no_eff_to_mm_chld = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM);
            ws_subscr_dt_msg_no_eff_to_dd_chld = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD);

            ws_subscr_date_last_stmnt_yy_chld = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_YY);
            ws_subscr_date_last_stmnt_mm_chld = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_MM);
            ws_subscr_date_last_stmnt_dd_chld = Util.NumInt(objPat_mstr_rec.SUBSCR_DATE_LAST_STATEMENT_DD);

            ws_subscr_auto_update = Util.Str(objPat_mstr_rec.SUBSCR_AUTO_UPDATE);
            ws_pat_last_mod_by = Util.Str(objPat_mstr_rec.PAT_LAST_MOD_BY);
            ws_pat_date_last_elig_mailing = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAILING);
            ws_pat_date_last_elig_maint = Util.NumInt(objPat_mstr_rec.PAT_DATE_LAST_ELIG_MAINT);
            ws_pat_last_birth_date = Util.NumInt(objPat_mstr_rec.PAT_LAST_BIRTH_DATE);
            ws_pat_last_birth_date_yy_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_LAST_BIRTH_DATE).PadLeft(8, '0').Substring(0, 4));
            ws_pat_last_birth_date_mm_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_LAST_BIRTH_DATE).PadLeft(8, '0').Substring(4, 2));
            ws_pat_last_birth_date_dd_chld = Util.NumInt(Util.Str(objPat_mstr_rec.PAT_LAST_BIRTH_DATE).PadLeft(8, '0').Substring(6, 2));

            ws_pat_last_version_cd = Util.Str(objPat_mstr_rec.PAT_LAST_VERSION_CD);
            ws_pat_mess_code = Util.Str(objPat_mstr_rec.PAT_MESS_CODE);
            ws_pat_country = Util.Str(objPat_mstr_rec.PAT_COUNTRY);

            ws_pat_no_of_letter_sent = Util.NumInt(objPat_mstr_rec.PAT_NO_OF_LETTER_SENT);
            ws_pat_dialysis = Util.Str(objPat_mstr_rec.PAT_DIALYSIS);
            ws_pat_ohip_validiation_status = Util.Str(objPat_mstr_rec.PAT_OHIP_VALIDATION_STATUS);
            ws_pat_obec_status = Util.Str(objPat_mstr_rec.PAT_OBEC_STATUS);            
        }

        private async Task<string> tp_pat_mstr_rec_get()
        {
            Util.Trakker(++ctr, "tp_pat_mstr_rec_get");

            StringBuilder retVal = null;
            retVal = new StringBuilder();

            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_func_code).PadRight(2));
            objTp_pat_mstr_rec.tp_pat_last_name = Util.Str(objTp_pat_mstr_rec.tp_pat_last_name_6).PadRight(6) + Util.Str(objTp_pat_mstr_rec.tp_pat_last_name_18).PadRight(18);
            retVal.Append(objTp_pat_mstr_rec.tp_pat_last_name);
            objTp_pat_mstr_rec.tp_pat_first_name = Util.Str(objTp_pat_mstr_rec.tp_pat_first_name_3).PadRight(3) + Util.Str(objTp_pat_mstr_rec.tp_pat_first_name_21).PadRight(21);
            retVal.Append(objTp_pat_mstr_rec.tp_pat_first_name);
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_birth_date).PadRight(10));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_sex).PadRight(1));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_id_no).PadRight(15));  // note: It has redefines...

            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr).PadRight(28));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_street_addr2).PadRight(28));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_city).PadRight(18));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_prov).PadRight(2));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_postal_code).PadRight(6));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_phone_no).PadRight(20));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_ohip_no).PadRight(8));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_health_nbr).PadRight(10));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_version_cd).Substring(0, 2).PadRight(2));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_health_65_ind).PadRight(1));
            retVal.Append(Util.Str(objTp_pat_mstr_rec.tp_pat_expiry_date).PadLeft(4, '0'));
            retVal.Append(new string(' ', 1));

            return retVal.ToString();
        }

        #endregion
    }
}

