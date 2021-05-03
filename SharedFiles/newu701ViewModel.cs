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
    public delegate void Newu701ExitCobolScreen();
    public class Newu701ViewModel : CommonFunctionScr
    {
        public event Newu701ExitCobolScreen ExitCobol;

        public Newu701ViewModel()
        {

        }

        #region FD Section
        // FD: unpriced_claims_file
        private Unpriced_claims_record objUnpriced_claims_record = null;
        private ObservableCollection<Unpriced_claims_record> Unpriced_claims_record_Collection;

        // FD: priced_claims_file
        private Diskout_output_rec objDiskout_output_rec = null;
        private ObservableCollection<Diskout_output_rec> Diskout_output_rec_Collection;

        // FD: ru701_work_file
        private Ru701_work_rec objRu701_work_rec = null;
        private ObservableCollection<Ru701_work_rec> Ru701_work_rec_Collection;

        // FD: report_file
        private Rpt_line objRpt_line = null;
        private ObservableCollection<Rpt_line> Rpt_line_Collection;

        // FD: suspend_hdr	Copy : f002_suspend_hdr.fd
        private F002_SUSPEND_HDR objSuspend_hdr_rec = null;
        private ObservableCollection<F002_SUSPEND_HDR> Suspend_hdr_rec_Collection;

        // FD: suspend_dtl	Copy : f002_suspend_dtl.fd
        private F002_SUSPEND_DTL objSuspend_dtl_rec = null;
        private ObservableCollection<F002_SUSPEND_DTL> Suspend_dtl_rec_Collection;

        // FD: suspend_address	Copy : f002_suspend_address.fd
        private F002_SUSPEND_ADDRESS objSuspend_address_rec = null;
        private ObservableCollection<F002_SUSPEND_ADDRESS> Suspend_address_rec_Collection;

        // FD: suspend_desc	Copy : f002_suspend_desc.fd
        private F002_SUSPEND_DESC objSuspend_desc_rec = null;
        private ObservableCollection<F002_SUSPEND_DESC> Suspend_desc_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        private F020C_DOC_CLINIC_NEXT_BATCH_NBR objF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
        private ObservableCollection<F020C_DOC_CLINIC_NEXT_BATCH_NBR> F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection;

        private F020L_DOC_LOCATIONS objF020L_DOC_LOCATIONS = null;
        private ObservableCollection<F020L_DOC_LOCATIONS> F020L_DOC_LOCATIONS_Collection = null;

        // FD: loc_mstr	Copy : f030_locations_mstr.fd
        private F030_LOCATIONS_MSTR objLoc_mstr_rec = null;
        private ObservableCollection<F030_LOCATIONS_MSTR> Loc_mstr_rec_Collection;

        // FD: oma_fee_mstr	Copy : f040_oma_fee_mstr.fd
        private F040_OMA_FEE_MSTR objFee_mstr_rec = null;
        private ObservableCollection<F040_OMA_FEE_MSTR> Fee_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_2.ws
        private CONSTANTS_MSTR_REC_2 objConstants_mstr_rec_2 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_2> Constants_mstr_rec_2_Collection;

        private CONSTANTS_MSTR_REC_1 objConstants_mstr_rec_1 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_1> Constants_mstr_rec_1_Collection;


        // FD: diag_mstr	Copy : f091_diagnostic_codes.fd
        private F091_DIAG_CODES_MSTR objDiag_rec = null;
        private ObservableCollection<F091_DIAG_CODES_MSTR> Diag_rec_Collection;

        // FD: sli_oma_code_suff_mstr	Copy : f201_sli_oma_code_suff.fd
        private F201_SLI_OMA_CODE_SUFF objSli_oma_code_suff_rec = null;
        private ObservableCollection<F201_SLI_OMA_CODE_SUFF> Sli_oma_code_suff_rec_Collection;

        private WriteFile objSuspend_Hdr = null;
        private WriteFile objSuspend_Dtl = null;
        private WriteFile objSuspend_Address = null;
        private WriteFile objSuspend_Desc = null;
        private WriteFile objPrice_Claims_File = null;


        #endregion

        #region Properties
        private string _flag_claim_source;
        public string flag_claim_source
        {
            get
            {
                return _flag_claim_source;
            }
            set
            {
                if (_flag_claim_source != value)
                {
                    _flag_claim_source = value;
                    _flag_claim_source = _flag_claim_source.ToUpper();
                    RaisePropertyChanged("flag_claim_source");
                }
            }
        }

        private string _flag_create_priced_file;
        public string flag_create_priced_file
        {
            get
            {
                return _flag_create_priced_file;
            }
            set
            {
                if (_flag_create_priced_file != value)
                {
                    _flag_create_priced_file = value;
                    _flag_create_priced_file = _flag_create_priced_file.ToUpper();
                    RaisePropertyChanged("flag_create_priced_file");
                }
            }
        }

        private string _flag_retain_prices;
        public string flag_retain_prices
        {
            get
            {
                return _flag_retain_prices;
            }
            set
            {
                if (_flag_retain_prices != value)
                {
                    _flag_retain_prices = value;
                    _flag_retain_prices = _flag_retain_prices.ToUpper();
                    RaisePropertyChanged("flag_retain_prices");
                }
            }
        }

        private string _flag_update_suspense;
        public string flag_update_suspense
        {
            get
            {
                return _flag_update_suspense;
            }
            set
            {
                if (_flag_update_suspense != value)
                {
                    _flag_update_suspense = value;
                    _flag_update_suspense = _flag_update_suspense.ToUpper();
                    RaisePropertyChanged("flag_update_suspense");
                }
            }
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

        private int _sys_date;
        public int sys_date
        {
            get
            {
                return _sys_date;
            }
            set
            {
                if (_sys_date != value)
                {
                    _sys_date = value;
                    RaisePropertyChanged("sys_date");
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

        private string _ws_agent_default_reply;
        public string ws_agent_default_reply
        {
            get
            {
                return _ws_agent_default_reply;
            }
            set
            {
                if (_ws_agent_default_reply != value)
                {
                    _ws_agent_default_reply = value;
                    _ws_agent_default_reply = _ws_agent_default_reply.ToUpper();
                    RaisePropertyChanged("ws_agent_default_reply");
                }
            }
        }

        private int _ws_default_clinic_nbr;
        public int ws_default_clinic_nbr
        {
            get
            {
                return _ws_default_clinic_nbr;
            }
            set
            {
                if (_ws_default_clinic_nbr != value)
                {
                    _ws_default_clinic_nbr = value;
                    RaisePropertyChanged("ws_default_clinic_nbr");
                }
            }
        }

        private string _ws_doc_nbr;
        public string ws_doc_nbr
        {
            get
            {
                return _ws_doc_nbr;
            }
            set
            {
                if (_ws_doc_nbr != value)
                {
                    _ws_doc_nbr = value;
                    _ws_doc_nbr = _ws_doc_nbr.ToUpper();
                    RaisePropertyChanged("ws_doc_nbr");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private string site_id = "RMA";
        private string password_input;
        private string password_special_privledges = "xxx";
        private string confirm = string.Empty;
        private string scr_hold_oma_cd = string.Empty;
        private string scr_hold_oma_suff = string.Empty;
        private string scr_hold_sv_date_yy_12 = string.Empty;
        private string scr_hold_sv_date_yy_34 = string.Empty;
        private string scr_hold_sv_date_mm = string.Empty;
        private string scr_hold_sv_date_dd = string.Empty;
        private string scr_hold_sv_nbr_0 = string.Empty;
        private string scr_hold_fee_oma = string.Empty;
        private string scr_hold_fee_ohip = string.Empty;
        private string scr_acpt_det_desc = string.Empty;
        private string scr_last_claim = string.Empty;
        private int pline = 0;

        private string ws_1_null = "x00";  // todo... this is Hex
        private string ws_4_nulls = "00000000"; // todo x00000000   this is hex

        private string ws_warning_literal = "* Warning * -";
        private string ws_error_literal = "**ERROR** - ";

        private string temp_phone_nbr_grp;
        private string temp_phone_nbr_justified_left_grp;
        private int temp_phone_nbr_1_7;
        private int temp_phone_nbr_8_10;
        private string temp_phone_nbr_justified_right_grp;
        private int temp_phone_nbr_1_3;
        private int temp_phone_nbr_4_10;

        private string batch_rec_grp;
        private string batch_dist_cd;
        private string batch_identifier;
        private string batch_group_nbr;
        private int batch_provider_nbr;
        private int batch_specialty;
        private int batch_pay_type;
        private int nbr_of_services;

        private string header_rec_grp;
        private string hdr_ohip_nbr_grp;
        private string nf_ohip_nbr;
        private string bc_ns_ohip_nbr_grp;
        private string bc_ns_10_digits;
        private string bc_ns_last_digits;
        private string ab_nb_sk_yt_ohip_nbr_grp;
        private string ab_nb_sk_yt_9_digits;
        private string ab_nb_sk_yt_last_digits;
        private string pe_ohip_nbr_grp;
        private string pe_8_digits;
        private string pe_last_digits;
        private string nt_ohip_nbr_grp;
        private string nt_first_digit;
        private string nt_7_digits;
        private string nt_last_digits;
        private string mb_ohip_nbr_grp;
        private string mb_9_digits;
        private string mb_last_digits;

        private string hdr_surname;
        private string hdr_first_name;

        private string hdr_birth_date_long_grp;
        private int hdr_birth_date;
        private int hdr_birth_date_dd;
        private string hdr_sex;
        private string hdr_accounting_nbr;
        private int hdr_refer_pract_nbr;
        private string hdr_hosp_nbr;
        private string hdr_i_o_ind;
        private string hdr_admit_date_grp;
        private string hdr_admit_yy;
        private int hdr_admit_mm;
        private int hdr_admit_dd;
        private string hdr_manual_review;
        private string hdr_health_care_nbr;
        private string hdr_health_care_ver;
        private string hdr_health_care_prov;
        private string hdr_relationship;
        private string hdr_patient_surname;
        private string hdr_subscr_initials;
        private string hdr_agent_cd;

        private string hdr_loc_code_grp;
        private string hdr_loc_alpha;
        private string hdr_loc_nbr;

        private string hdr_direct_key_grp;
        private string hdr_surname_3;
        private int hdr_birthdate_yymm;
        private int hdr_birthdate_dd;

        private string ws_doc_mstr_rec_data_grp;
        private int ws_doc_nx_batch_nbr;
        private int ws_doc_dept;
        private int ws_doc_ohip_nbr;
        private int ws_doc_spec_cd;
        private string ws_doc_locations_grp;
        private string[] ws_doc_loc = new string[31];

        private string detail_rec_grp;
        private string dtl_oma_cd;
        private string dtl_oma_suff;
        private decimal dtl_fee_billed;
        private int dtl_nbr_of_serv;
        private string dtl_serv_date_grp;
        private int dtl_serv_date_yy;
        private int dtl_serv_date_mm;
        private int dtl_serv_date_dd;
        private string dtl_diag_code;

        private string trailer_rec_grp;
        private int trl_h_count;
        private int trl_r_count;
        private int trl_t_count;
        private int trl_a_count;
        private int trl_b_count;

        private string audit_file = "ru701";
        private int suspend_dtl_occur;
        private int ws_carriage_ctrl = 0;
        private int ctr_lines_printed = 99;
        private int max_lines_per_page = 60;
        private int ws_rpt_page_nbr = 0;
        //private string ws_agent_default_reply = "";

        //private string ws_doc_nbr = "";

        //private int ws_default_clinic_nbr = 0;
        private string ws_default_batch_location = " ";
        private string ws_default_batch_i_o_ind = " ";

        private string ws_default_payroll_flag;

        private string flag_zero_fee;
        private string feedback_iconst_mstr;
        private int ws_tot_serv = 0;
        private string ws_special_add_on_cd_entered;

        private string ws_e078_premium;

        private string ws_e020;
        private string ws_e719;
        private string ws_e720;
        private string ws_e717;
        private string ws_e702;
        private string ws_g123;

        private string ws_g223;
        private string ws_g265;
        private string ws_g385;
        private string ws_g281;
        private string ws_e793;
        private string ws_e022_e017_e016;
        private string ws_z570;
        private string ws_z571;
        private string ws_z555_z580;
        private string ws_z515_z760;
        private string ws_g228;
        private string ws_g231;
        private string ws_g264;
        private string ws_g384;
        private string ws_g381;
        private string ws_r905_s800;
        private string ws_annna;
        private string ws_gnnna;
        private string ws_k991_u997;

        private string ws_c998;
        private string ws_c999;
        private string ws_e798;
        private string ws_z400;
        private string ws_g400_other_codes;
        private string ws_e409_e410;
        private string ws_c990_to_c997;
        private string ws_cnnn;
        private string ws_e450;
        private string ws_j315;

        private string ws_c985;
        private string ws_g222;
        private string ws_g248_g062;
        private string ws_a770_a775;
        private string ws_X9nn;
        private string ws_h112_h113;
        private string ws_hnnn;
        private string ws_g489_s323;
        private string ws_g222_z805;
        private string ws_p014_p016;
        private string ws_g221;
        private string ws_g220;
        private string ws_s322_a198;
        private string ws_a765_c765;
        private string ws_g521_g395;
        private string ws_h104_h124;
        private string ws_g345_g339;
        private string ws_g431_g479;
        private string ws_gnnn;
        private string ws_annn;

        private string ws_c983;
        private string ws_j025;
        private string ws_j021;
        private string ws_j022;
        private string ws_z608;
        private string ws_z611_z602;
        private string ws_z403;
        private string ws_z408;
        private string ws_a195;
        private string ws_k002;
        private string ws_c122_c143;
        private string ws_e083;
        private string ws_c122_c982;
        private string ws_g489_g376;

        private string ws_a197_a198;
        private string ws_k189;
        private string ws_a190_a795;
        private string ws_k960;
        private string ws_k990;
        private string ws_k961;
        private string ws_k992;
        private string ws_k962;
        private string ws_k994;
        private string ws_k963;
        private string ws_k998;
        private string ws_k964;
        private string ws_k996;
        private string ws_c960;
        private string ws_c990;
        private string ws_c961;
        private string ws_c992;
        private string ws_c962;
        private string ws_c994;
        private string ws_c963;
        private string ws_c986;
        private string ws_c964;
        private string ws_c996;

        private string ws_e676;

        private string ws_a120;
        private string ws_z491_to_z499;

        private string ws_g556;
        private string ws_g400_g620;
        private string ws_g325;
        private string ws_cnnn_c101;
        private string ws_e402_e403;
        private string ws_g247;
        private string ws_e797;
        private string ws_z491_z580;
        private string ws_e414;
        private string ws_p030;
        private string ws_a895;
        private string ws_wnnn;
        private string ws_knnn;
        private string ws_z512;
        private string ws_z514;
        private string ws_z580;
        private int ws_total_nbr_svc;
        private string ws_edit_80;
        private string ws_a075;

        private int ws_pricing_nbr_serv;
        private decimal ws_highest_grp_tot;
        private int ws_highest_grp_nbr;
        private string flag_new_sec;

        private string flag_z_highest_grp;

        private int rate_found_ss;
        private int subs;
        private int ss;
        private int sub;
        private int ss1;
        private int ss2;
        private int ss_basic_times;
        private int ss_basic_times_desc_rec;
        private int ss_from_plus_one;
        private int ss_const;
        private int subs_table_addr;
        private int i;
        private int ss_from;
        private int ss_to;
        private int ss_sec;
        private int ss_grp;
        private int ss_grp_tot;
        private int ss_clmhdr;
        private int ss_tech_prof_suff;
        private int ss_clmdtl_oma;
        private int ss_clmdtl_next_avail_dtl;
        private int ss_clmdtl_new_dtl;
        private int ss_clmdtl_tech_prof_suff;
        private int ss_hold_clmdtl_oma;
        private int ss_price;
        private int ss_write_dtl;
        private int ss_clmdtl_desc;
        private int ss_conseq_dd;
        private int ss_ind;
        private int ss_plus_one;
        private int ss_x;
        private int ss_suffix;

        private decimal ws_hold_wcb_rate;
        private decimal ws_reduc_rate98;
        private decimal ws_reduc_rate99;
        private decimal ws_reduc_rate;

        private int ws_search_clinic_nbr_1_2;
        private int curr = 1;
        private int prev = 2;
        private int oma = 1;
        private int ohip = 2;
        private int ss_curr_prev;
        private string space_char = " ";
        private string carriage_return = "\r"; // x"0D";   todo
        private string line_feed = "\n";   //  x"0A";  todo
        private decimal ws_hold_temp_1;
        private int ws_hold_temp_2;
        private int ws_hold_temp_3;

        private int bt_clinic_nbr_1_2 = 0;
        private int subs_hosp;

        private string ws_date_yymmdd_grp;
        private int ws_date_yy;
        private int ws_date_mm;
        private int ws_date_dd;

        private string ws_nbr_10;

        private int ws_birth_date;
        private int ws_sv_date;

        private int ws_sv_date_c1;
        private int ws_sv_date_c2;

        private string hold_suspend_hdr_rec;

        private string ws_iconst_mstr_rec_data_grp;
        private int ws_iconst_clinic_nbr_1_2;
        private int ws_iconst_clinic_nbr;
        private int ws_iconst_clinic_cycle_nbr;
        private int ws_iconst_date_period_end;
        private string ws_iconst_clinic_card_colour;

        //private string audit_line_grp;
        private string filler = "";
        private string audit_title;
        private int audit_value;
        //private string filler = "";
        private int audit_value_2;
        //private string filler = "";
        private int audit_value_3;
        //private string filler = "";
        private int audit_value_4;
        //private string filler = "";
        private int audit_value_5;

        private string status_values_grp;
        private string status_infos_grp;
        private string status_unpriced_claims = "0";
        private string status_priced_claims_file = "0";
        private string status_iconst_mstr = "0";
        private string status_doc_mstr = "0";
        private string status_oma_mstr = "0";

        private string status_suspend_hdr = "0";
        private string status_suspend_dtl = "0";

        private string status_suspend_desc = "0";

        private string status_suspend_addr = "0";
        private string status_diag_mstr = "0";
        //private string status_file;

        private string status_cobol_grp;
        private string status_cobol_unpriced_claims = "0";
        private string status_cobol_priced_claims = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_cobol_oma_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_suspend_hdr = "0";
        private string status_cobol_suspend_dtl = "0";

        private string status_cobol_suspend_desc = "0";

        private string status_cobol_suspend_addr = "0";
        private string status_cobol_diag_mstr = "0";
        private string status_report = "0";
        private string status_cobol_loc_mstr = "0";
        private string status_cobol_error_claims = "0";

        private string status_cobol_ru701_work_file = "0";
        private string status_cobol_sli_oma_mstr = "0";

        private string feedback_values_grp;
        private string feedback_doc_mstr = "0";
        private string feedback_oma_fee_mstr = "0";
        private string feedback_suspend_hdr = "0";
        private string feedback_suspend_dtl = "0";
        private string feedback_suspend_addr = "0";
        private string feedback_diag_mstr = "0";

        private string flag_adjudication_required;
        private string adjudication_desc_required = "Y";

        private string ic_flag = "N";
        private string ic_entered = "Y";
        private string ic_not_entered = "N";

        private string flag;
        private string ok = "Y";
        private string not_ok = "N";

        private string eof_input_file_flag = "N";
        private string eof_input_file = "Y";

        private string fatal_error_flag = "";
        private string fatal_error = "Y";

        private string flag_lock;
        private string rec_locked = "Y";
        private string rec_not_locked = "N";

        private string flag_ohip_vs_chart;
        private string qhip = "O";
        private string chart = "C";
        private string direct = "D";

        private string flag_valid_ohip_or_chart;
        private string valid_ohip = "Y";
        private string valid_chart = "Y";
        private string invalid_ohip = "N";
        private string invalid_chart = "N";

        private string flag_ohip_mmyy;
        private string valid_mmyy = "Y";
        private string invalid_mmyy = "N";

        private string flag_err_data;
        private string err_data = "N";
        private string ok_data = "Y";

        private string flag_done_clmdtl_recs;
        private string done_clmdtl_recs_yes = "Y";

        private string flag_eoj;
        private string eoj_create_new_patient = "C";
        private string eoj = "E";

        private string flag_tech_prof_suffix_rule;
        private string tech_prof_suff_rule_applied = "Y";

        private string flag_sec_reduction_needed;

        private string flag_report_desc;
        private string report_desc_required = "Y";

        private string ws_oma_cd_grp;
        private string ws_oma_cd_1;
        private int ws_oma_cd_2_4;

        private string skip_process_this_acct_id_flag;
        private string skip_processing_this_acct_id = "Y";
        private string skip_hdr_addr_but_write_dtl = "D";

        private string hold_in_rec_type_grp;
        private string hold_trans_id;
        private string hold_rec_type;

        private string record_type_flags;
        private string b_record = "HEB";
        private string h_record = "HEH";
        private string r_record = "HER";
        private string t_record = "HET";
        private string a_record = "HEA";
        private string e_record = "HEE";

        private string last_record_type_flag;
        private string last_record_is_b = "HEB";
        private string last_record_is_h = "HEH";
        private string last_record_is_r = "HER";
        private string last_record_is_t = "HET";
        private string last_record_is_a = "HEA";
        private string last_record_is_e = "HEE";

        private string counters_grp;
        private int ctr_read_const_mstr;
        private int ctr_diskout_writes;
        private int ctr_suspend_hdr_writes;
        private int ctr_suspend_dtl_writes;

        private int ctr_suspend_desc_writes;

        private int ctr_suspend_addr_writes;
        private int ctr_recs_read;
        private int ctr_b_recs_read_skipped;
        private int ctr_h_recs_read_skipped;
        private int ctr_r_recs_read_skipped;
        private int ctr_t_recs_read_skipped;
        private int ctr_a_recs_read_skipped;
        private int ctr_e_recs_read_skipped;
        private int ctr_b_recs_read;
        private int ctr_h_recs_read;
        private int ctr_r_recs_read;
        private int ctr_t_recs_read;
        private int ctr_a_recs_read;
        private int ctr_e_recs_read;
        private int ctr_h_recs_skipped;
        private int ctr_r_recs_skipped;
        private int ctr_t_recs_skipped;
        private int ctr_a_recs_skipped;
        private int ctr_tot_b_recs;
        private int ctr_tot_h_recs;
        private int ctr_tot_r_recs;
        private int ctr_tot_t_recs;
        private int ctr_tot_a_recs;
        private decimal ctr_tot_dollars_read;

        private decimal ctr_tot_dollars_oma;
        private decimal ctr_tot_dollars_ohip;

        private decimal ctr_tot_tech_claim;
        private int ctr_tot_svcs_read;

        private int ctr_hdr2_rec;
        private int ctr_addr_rec;

        private string flag_date;
        private string valid_date = "Y";
        private string invalid_date = "N";

        private string flag_consec;
        private string valid_consec = "Y";
        private string invalid_consec = "N";

        private string flag_clinic;
        private string clinic_found = "Y";
        private string clinic_not_found = "N";

        private string flag_doc_clinic;
        private string valid_doc_clinic = "Y";
        private string invalid_doc_clinic = "N";

        private string flag_hosp_nbr;
        private string valid_hosp_nbr = "Y";
        private string invalid_hosp_nbr = "N";

        private string flag_agent_cd;
        private string valid_agent_cd = "Y";
        private string invalid_agent_cd = "N";

        private string flag_in_out_ind;
        private string valid_in_out_ind = "Y";
        private string invalid_in_out_ind = "N";

        private string flag_doc;
        private string doc_found = "Y";
        private string doc_not_found = "N";

        private string flag_oscar_provider;
        private string oscar_provider_found = "Y";
        private string oscar_provider_not_found = "N";

        private string flag_oma;
        private string valid_oma_code = "Y";
        private string invalid_oma_code = "N";

        private string flag_agent_code;
        private string valid_agent_cd_code = "Y";
        private string invalid_agent_cd_code = "N";

        private string flag_refer_phys;
        private string valid_refer_phys = "Y";
        private string invalid_refer_phys = "N";

        private string flag_refer_doc;
        private string refer_doc_require = "Y";
        private string refer_doc_not_require = "N";

        private string flag_location;
        private string valid_location = "Y";
        private string invalid_location = "N";

        private string flag_ohip;
        //private string valid_ohip = "Y";
        //private string invalid_ohip = "N";

        private string flag_diag_cd;
        private string valid_diag_code = "Y";
        private string invalid_diag_code = "N";

        private string detail_written_flag;
        private string detail_written = "Y";
        private string detail_not_written = "N";

        private string ws_chk_ind;

        private int ws_val_total;
        private int date_difference_in_days;
        private decimal rem_even;
        private int max_nbr_digits = 7;
        private int max_doc_locations = 30;

        private int ss_max_nbr_oma_det_rec_allow = 90;

        private string hold_claim_detail_recs_grp;
        private string hold_oma_recs_grp;
        private string hold_accounting_nbr;

        //private string[] hold_oma_rec_grp = new string[91];
        //private string[] hold_oma_cd_grp = new string[91];
        private string[] hold_oma_cd_alpha = new string[91];
        private string[] hold_oma_cd_num_grp = new string[91];
        private int[] hold_oma_cd_num_1 = new int[91];
        private int[] hold_oma_cd_num_2 = new int[91];
        private int[] hold_oma_cd_num_3 = new int[91];
        private string[] hold_oma_suff = new string[91];
        private int[] hold_sv_nbr_serv_incoming = new int[91];
        private int[] hold_sv_nbr_serv = new int[91];
        private string[] hold_admit_date_icc_grp = new string[91];
        private string[] hold_sv_date_grp = new string[91];
        private int[] hold_sv_date_yy = new int[91];
        private int[] hold_sv_date_yy_r_grp = new int[91];
        private int[] hold_sv_date_yy_12 = new int[91];
        private int[] hold_sv_date_yy_34 = new int[91];
        private int[] hold_sv_date_mm = new int[91];
        private int[] hold_sv_date_dd = new int[91];
        private string[] hold_icc_cd_grp = new string[91];
        private string[] hold_icc_sec = new string[91];
        private string[] hold_icc_grp = new string[91];

        private string[] hold_key_r_grp = new string[91];
        //20  filler pic x(6).
        private string[] hold_sort_key_1 = new string[91];
        private string[,] hold_svnbr_days_conseq = new string[91, 4];
        private int[,] hold_sv_nbr = new int[91, 4];
        private string[,] hold_sv_day = new string[91, 4];
        private int[,] hold_sv_day_num = new int[91, 4];      //redefines hold-sv-day pic 99.

        private string[] hold_override_price = new string[91];
        private string[] hold_bilateral = new string[91];
        private decimal[] hold_fee_incoming = new decimal[91];

        private decimal[] hold_fee_oma = new decimal[91];
        private int[] hold_fee_oma_r = new int[91];
        private decimal[] hold_fee_ohip = new decimal[91];
        private int[] hold_fee_ohip_r = new int[91];
        private decimal[] hold_priced_tech = new decimal[91];
        private decimal[] hold_basic_tech = new decimal[91];
        private decimal[] hold_basic_prof = new decimal[91];
        private decimal[] hold_basic_fee = new decimal[91];

        private string[,] hold_oma_rec_ind = new string[91, 9];

        private string[,] hold_oma_add_on_cd = new string[91, 11];

        private string[,] hold_oma_ind_card_requireds = new string[91, 4];
        private string[,] hold_oma_ind_card_required = new string[91, 4];

        private string[,] hold_oma_fees = new string[91, 3];
        private decimal[,] hold_oma_fee_1 = new decimal[91, 3];
        private decimal[,] hold_oma_fee_2 = new decimal[91, 3];
        private decimal[,] hold_fee_min = new decimal[91, 3];
        private decimal[,] hold_fee_max = new decimal[91, 3];
        private int[,] hold_oma_fee_anae = new int[91, 3];
        private int[,] hold_oma_fee_asst = new int[91, 3];

        private int[] hold_ss_curr_prev = new int[91];

        private string[] hold_flag_fee_used = new string[91];

        private string[] hold_flag_sec_group = new string[91];
        private int[] hold_flag_sec = new int[91];
        private int[] hold_flag_grp = new int[91];

        private int[] hold_diag_cd = new int[91];
        private int[] hold_line_no = new int[91];

        private string hold_sort_oma_rec;  // pic x(274).

        private string hold_descriptions_grp;
        private string hold_desc_1;
        private string hold_desc_2;
        private string hold_desc_3;
        private string hold_desc_4;
        private string hold_desc_5;

        private string hold_descs_r_grp;
        private string[] hold_descs = new string[6];
        private string[] hold_desc = new string[6];

        private string hold_desc_tmp_grp;
        private string hold_desc_tmp_start;
        private string hold_desc_tmp_end;

        //private string hold_basic_times_desc_grp;
        private string[] hold_basic_plus_times_desc = new string[3];
        private int[] hold_basic_units = new int[3];
        private string[] hold_basic_b = new string[3];
        private int[] hold_times_units = new int[3];
        private string[] hold_times_t = new string[3];

        private string hold_grp_totals_tbl_grp;
        private decimal[] hold_grp_tot = new decimal[91];
        private decimal[] hold_grp_nbr = new decimal[91];
        private int[] hold_grp_nbr_sec = new int[91];
        private int[] hold_grp_nbr_grp = new int[91];

        private int ss_max_nbr_locs_in_doc_rec = 30;
        private int ss_max_nbr_of_desc_rec_allow = 5;

        private string flag_desc_rec;
        private string basic_plus_times_entry = "BT";
        private string adjudication_desc_entry = "A";

        //private string flag_update_suspense;
        private string update_suspense = "Y";
        private string dont_update_suspense = "N";

        //private string flag_create_priced_file;
        private string create_priced_file = "Y";
        private string dont_create_priced_file = "N";

        //private string flag_claim_source;
        private string web_claim = "W";
        private string online_claim = "O";
        private string diskette_claim = "D";
        private string price_only_claim = "P";

        private string flag_payroll;

        //private string flag_retain_prices;
        private string retain_incoming_prices = "Y";
        private string override_with_rma_prices = "N";

        private int ss_diag_ind = 1;
        private int ss_phy_ind = 2;
        private int ss_hosp_nbr_ind = 3;
        private int ss_i_o_ind = 4;
        private int ss_admit_ind = 5;
        private int ss_add_on_perc_or_flat_ind = 6;
        private int ss_special_m_suffix_ind = 7;
        private int ss_tech_ind = 8;

        private string province_flag;
        private string province_found = "Y";
        private string province_not_found = "N";

        private string prov_table_grp;
        private string province_grp;
        private string[] prov = {"", "ON",
                                "AB",
                                "NL",
                                "SK",
                                "MB",
                                "NT",
                                "PE",
                                "YT",
                                "BC",
                                "NB",
                                "NS",
                                "NU"};
        private string province_r_grp;
        //private string[] prov =  new string[13];

        // private string heading_l1_grp; // = "RU701".PadRight(8) + "run date:".PadRight(10) + Util.Str(l1_run_date).PadRight(10) + new string(' ', 6) + "OHIP Diskette Upload into Suspense - ERROR/WARNING/AUDIT Report".PadRight(66) + "PAGE:".PadRight(6) + Util.Str(rpt_page_nbr).PadLeft(4);
        //private string filler = "RU701";
        //private string filler = "run date:";
        private string l1_run_date;
        // private string filler = "";
        // private string filler = "OHIP Diskette Upload into Suspense - ERROR/WARNING/AUDIT Report";
        //   private string filler = "PAGE:";
        private int rpt_page_nbr;

        //private string heading_l2_grp; // = "doctor: ".PadRight(8) + Util.Str(h_l2_doctor_nbr).PadRight(3) + " / " + Util.Str(h_l2_doctor_initials).PadRight(3) + new string(' ', 1) + Util.Str(h_l2_doctor_name).PadRight(24) + " CLINIC/SPECIALTY: ".PadRight(20) + Util.Str(h_l2_clinic).PadRight(4) + " / " + Util.Str(h_l2_specialty).PadRight(3);
        //private string filler = "doctor: ";
        private string h_l2_doctor_nbr;
        //private string filler = " / ";
        private string h_l2_doctor_initials;
        //private string filler = " ";
        private string h_l2_doctor_name;
        //private string filler = " CLINIC/SPECIALTY: ";
        private string h_l2_clinic;
        //private string filler = " / ";
        private string h_l2_specialty;

        private int err_ind = 0;
        private string err_msg_comment;
        private string save_prt_line;

        private string e1_error_line_grp;
        private string e1_error_word = "*** ERROR- ";
        private string e1_error_msg;
        private string e1_error_key;

        private string def_agent_code;
        private string def_agent_ohip = "0";
        private string def_agent_in_pat_diag_billing = "1";
        private string def_agent_ohip_wcb = "2";
        private string def_agent_icu_direct_bill = "3";
        private string def_agent_ohip_not_valid = "4";
        private string def_agent_moh_reduction = "5";
        private string def_agent_bill_direct = "6";  //"4"  todo: 2 values assign in 1 variable...
        private string def_agent_misc_payments = "7";
        private string def_agent_alternate_funding = "8";
        private string def_agent_wcb = "9";
        private string def_agent_ifhp_direct = "x";
        private string def_agent_ontario_direct = "x";
        private string def_agent_foreign_direct = "x";
        private string def_agent_reciprocal = "x";
        private string def_agent_quebec_direct = "x";
        private string default_area_code = "905";

        private string swap_phone_nbr_grp;
        private string swap_phone_nbr_1_7;
        //private string filler;
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        //private string sys_date_grp;
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
        //private string filler = ":";
        private int run_min;
        //private string filler = ":";
        private int run_sec;

        private string ws_check_digit_nbrs_grp;
        private int ws_temp;
        private int ws_temp_1;
        private int ws_temp_2;
        private string ws_temp_2_r_grp;
        private int ws_temp_2a;
        private int ws_temp_2b;

        private string ws_check_nbr_grp;
        private int ws_chk_nbr;
        private string ws_chk_nbr_r_grp;
        private int ws_chk_nbr_1;
        private int ws_chk_nbr_2;
        private int ws_chk_nbr_3;
        private int ws_chk_nbr_4;
        private int ws_chk_nbr_5;
        private int ws_chk_nbr_6;
        private int ws_chk_nbr_7;
        private int ws_chk_nbr_8;

        private string ws_check_digit_nbrs_10_grp;
        private int ws_temp_10;
        private int ws_temp_1_10;
        private int ws_temp_2_10;
        private string ws_temp_2_10_r_grp;
        private int ws_temp_2a_10;
        private int ws_temp_2b_10;

        private string ws_check_nbr_10_grp;
        private long ws_chk_nbr_10;
        private string ws_chk_nbr_10_r_grp;
        private int ws_chk_nbr_1_10;
        private int ws_chk_nbr_2_10;
        private int ws_chk_nbr_3_10;
        private int ws_chk_nbr_4_10;
        private int ws_chk_nbr_5_10;
        private int ws_chk_nbr_6_10;
        private int ws_chk_nbr_7_10;
        private int ws_chk_nbr_8_10;
        private int ws_chk_nbr_9_10;
        private int ws_chk_nbr_10_10;

        private string ws_nbr_val_grp;
        private int ws_nbr_to_b_val;
        private string ws_nbr_to_b_val_r_grp;
        private int[] ws_nbr_to_b_val_1_8 = new int[9];
        private string ws_sum_1_2_val_grp;
        private string[] ws_sum_1_2_val_r = new string[8];
        private int[] ws_sum_1_2_val_r1 = new int[8];
        private string[] ws_sum_1_2_val_r1_r = new string[8];
        private int[,] ws_sum_1 = new int[8, 3];
        private string[] ws_sum_1_2_val_r_sep = new string[8];
        private int[,] ws_sum_1_2 = new int[8, 8];

        private string ws_hc_nbr_val_grp;
        private int ws_hc_nbr_to_b_val;
        private string ws_hc_nbr_to_b_val_r_grp;
        private int[] ws_hc_nbr_to_b_val_1_10 = new int[11];
        private string ws_hc_sum_1_2_val_grp;
        private string[] ws_hc_sum_1_2_val_r = new string[10];
        private int[] ws_hc_sum_1_2_val_r1 = new int[10];
        private string[] ws_hc_sum_1_2_val_r1_r = new string[10];
        private int[,] ws_hc_sum_1 = new int[10, 3];
        private string[] ws_hc_sum_1_2_val_r_sep = new string[10];
        private int[,] ws_hc_sum_1_2 = new int[10, 10];

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
        private string[] mth_desc = { "", "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
        private int[] nbr_julian_days_ytd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

        private string hosp_table_grp;
        private string hosp_values_grp;
        private string[] hosp_code_nbr = {"", "A1992",
                                         "B1160",
                                         "C1972",
                                         "D1557",
                                         "E1146",
                                         "F3361",
                                         "G1982",
                                         "H1983",
                                         "I3309",
                                         "J2003",
                                         "K1076",
                                         "L1538",
                                         "M1994",
                                         "N1591",
                                         "O1172",
                                         "P1524",
                                         "Q3446",
                                         "R1978",
                                         "S2006",
                                         "T1406",
                                         "U1542",
                                         "V1149",
                                         "W0000",
                                         "X1082",
                                         "Y1020",
                                         "Z1987",
                                         "11965",
                                         "21969",
                                         "33401",
                                         "42001",
                                         "51966",
                                         "61967",
                                         "73409",
                                         "83642",
                                         "93251"};
        private string hosp_values_r_grp;
        //private string[] hosp_code_nbr =  new string[36];
        //private string[] hosp_code =  new string[36];
        private string[] hosp_code = {"", "A",
                                         "B",
                                         "C",
                                         "D",
                                         "E",
                                         "F",
                                         "G",
                                         "H",
                                         "I",
                                         "J",
                                         "K",
                                         "L",
                                         "M",
                                         "N",
                                         "O",
                                         "P",
                                         "Q",
                                         "R",
                                         "S",
                                         "T",
                                         "U",
                                         "V",
                                         "W",
                                         "X",
                                         "Y",
                                         "Z",
                                         "1",
                                         "2",
                                         "3",
                                         "4",
                                         "5",
                                         "6",
                                         "7",
                                         "8",
                                         "9"};

        //private string[] hosp_nbr =  new string[36];
        private string[] hosp_nbr = {"", "1992",
                                         "1160",
                                         "1972",
                                         "1557",
                                         "1146",
                                         "3361",
                                         "1982",
                                         "1983",
                                         "3309",
                                         "2003",
                                         "1076",
                                         "1538",
                                         "1994",
                                         "1591",
                                         "1172",
                                         "1524",
                                         "3446",
                                         "1978",
                                         "2006",
                                         "1406",
                                         "1542",
                                         "1149",
                                         "0000",
                                         "1082",
                                         "1020",
                                         "1987",
                                         "1965",
                                         "1969",
                                         "3401",
                                         "2001",
                                         "1966",
                                         "1967",
                                         "3409",
                                         "3642",
                                         "3251"};

        private string constants_mstr_rec_1_grp;
        private int const_rec_1_rec_nbr;
        private int const_max_nbr_clinics;
        private string const_clinic_data_grp;
        private string[] const_clinic_data_r = new string[64];
        private int[] const_clinic_nbr_1_2 = new int[64];
        private string[] const_clinic_nbr = new string[64];
        private string const_scr_data_grp;
        private int const_clinic_1_2_nbr_1;
        private string const_clinic_nbr_1;
        private int const_clinic_1_2_nbr_2;
        private string const_clinic_nbr_2;
        private int const_clinic_1_2_nbr_3;
        private string const_clinic_nbr_3;
        private int const_clinic_1_2_nbr_4;
        private string const_clinic_nbr_4;
        private int const_clinic_1_2_nbr_5;
        private string const_clinic_nbr_5;
        private int const_clinic_1_2_nbr_6;
        private string const_clinic_nbr_6;
        private int const_clinic_1_2_nbr_7;
        private string const_clinic_nbr_7;
        private int const_clinic_1_2_nbr_8;
        private string const_clinic_nbr_8;
        private int const_clinic_1_2_nbr_9;
        private string const_clinic_nbr_9;
        private int const_clinic_1_2_nbr_10;
        private string const_clinic_nbr_10;
        private int const_clinic_1_2_nbr_11;
        private string const_clinic_nbr_11;
        private int const_clinic_1_2_nbr_12;
        private string const_clinic_nbr_12;
        private int const_clinic_1_2_nbr_13;
        private string const_clinic_nbr_13;
        private int const_clinic_1_2_nbr_14;
        private string const_clinic_nbr_14;
        private int const_clinic_1_2_nbr_15;
        private string const_clinic_nbr_15;
        private int const_clinic_1_2_nbr_16;
        private string const_clinic_nbr_16;
        private int const_clinic_1_2_nbr_17;
        private string const_clinic_nbr_17;
        private int const_clinic_1_2_nbr_18;
        private string const_clinic_nbr_18;
        private int const_clinic_1_2_nbr_19;
        private string const_clinic_nbr_19;
        private int const_clinic_1_2_nbr_20;
        private string const_clinic_nbr_20;
        private int const_clinic_1_2_nbr_21;
        private string const_clinic_nbr_21;
        private int const_clinic_1_2_nbr_22;
        private string const_clinic_nbr_22;
        private int const_clinic_1_2_nbr_23;
        private string const_clinic_nbr_23;
        private int const_clinic_1_2_nbr_24;
        private string const_clinic_nbr_24;
        private int const_clinic_1_2_nbr_25;
        private string const_clinic_nbr_25;
        private int const_clinic_1_2_nbr_26;
        private string const_clinic_nbr_26;
        private int const_clinic_1_2_nbr_27;
        private string const_clinic_nbr_27;
        private int const_clinic_1_2_nbr_28;
        private string const_clinic_nbr_28;
        private int const_clinic_1_2_nbr_29;
        private string const_clinic_nbr_29;
        private int const_clinic_1_2_nbr_30;
        private string const_clinic_nbr_30;
        private int const_clinic_1_2_nbr_31;
        private string const_clinic_nbr_31;
        private int const_clinic_1_2_nbr_32;
        private string const_clinic_nbr_32;
        private int const_clinic_1_2_nbr_33;
        private string const_clinic_nbr_33;
        private int const_clinic_1_2_nbr_34;
        private string const_clinic_nbr_34;
        private int const_clinic_1_2_nbr_35;
        private string const_clinic_nbr_35;
        private int const_clinic_1_2_nbr_36;
        private string const_clinic_nbr_36;
        private int const_clinic_1_2_nbr_37;
        private string const_clinic_nbr_37;
        private int const_clinic_1_2_nbr_38;
        private string const_clinic_nbr_38;
        private int const_clinic_1_2_nbr_39;
        private string const_clinic_nbr_39;
        private int const_clinic_1_2_nbr_40;
        private string const_clinic_nbr_40;
        private int const_clinic_1_2_nbr_41;
        private string const_clinic_nbr_41;
        private int const_clinic_1_2_nbr_42;
        private string const_clinic_nbr_42;
        private int const_clinic_1_2_nbr_43;
        private string const_clinic_nbr_43;
        private int const_clinic_1_2_nbr_44;
        private string const_clinic_nbr_44;
        private int const_clinic_1_2_nbr_45;
        private string const_clinic_nbr_45;
        private int const_clinic_1_2_nbr_46;
        private string const_clinic_nbr_46;
        private int const_clinic_1_2_nbr_47;
        private string const_clinic_nbr_47;
        private int const_clinic_1_2_nbr_48;
        private string const_clinic_nbr_48;
        private int const_clinic_1_2_nbr_49;
        private string const_clinic_nbr_49;
        private int const_clinic_1_2_nbr_50;
        private string const_clinic_nbr_50;
        private int const_clinic_1_2_nbr_51;
        private string const_clinic_nbr_51;
        private int const_clinic_1_2_nbr_52;
        private string const_clinic_nbr_52;
        private int const_clinic_1_2_nbr_53;
        private string const_clinic_nbr_53;
        private int const_clinic_1_2_nbr_54;
        private string const_clinic_nbr_54;
        private int const_clinic_1_2_nbr_55;
        private string const_clinic_nbr_55;
        private int const_clinic_1_2_nbr_56;
        private string const_clinic_nbr_56;
        private int const_clinic_1_2_nbr_57;
        private string const_clinic_nbr_57;
        private int const_clinic_1_2_nbr_58;
        private string const_clinic_nbr_58;
        private int const_clinic_1_2_nbr_59;
        private string const_clinic_nbr_59;
        private int const_clinic_1_2_nbr_60;
        private string const_clinic_nbr_60;
        private int const_clinic_1_2_nbr_61;
        private string const_clinic_nbr_61;
        private int const_clinic_1_2_nbr_62;
        private string const_clinic_nbr_62;
        private int const_clinic_1_2_nbr_63;
        private string const_clinic_nbr_63;
        //private string filler;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string filler_grp;
        private string err_warn_msg = "";
        //private string filler = "Batch = ";
        private string err_msg_pract_nbr;
        //private string filler = "/";
        private string err_msg_account_id;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "**ERROR** - NO SUCH DOCTOR FOUND ON FILE - ";
        private string err_msg_doc_nbr;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID LOCATION CODE FOR DOCTOR: BATCH CONTAINED LOCATION - ";
        private string err_msg_loc_cd;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID SPECIALITY CODE: BATCH CONTAINED SPECIALITY - ";
        private string err_msg_batch_spec_cd;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "                         DOCTOR'S  SPECIALTIES ARE - ";
        private string err_msg_doc_spec_cd;
        //private string filler = " / ";
        private string err_msg_doc_spec_cd_2;
        //private string filler = " / ";
        private string err_msg_doc_spec_cd_3;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "**ERROR** - INVALID CLINIC ID: BATCH CONTAINED CLINIC - ";
        private string err_msg_clinic_id;
        //private string filler = "";
        //private string filler = "**ERROR** - FIRST RECORD FOUND IN FILE WAS NOT A 'B'ATCH RECORD ";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID OMA CODE - ACCOUNTING NBR = ";
        private string err_accounting_nbr;
        //private string filler;
        //private string filler = "              DUPLICATE ACCOUNT ID FOUND IN SUSPENSE (HEADER) FILE";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID WRITE NEW CLAIMS HDR - 'B' KEY=";
        private string bkey_clmhdr_err_msg = "";
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID WRITE NEW CLAIMS HDR -'P' KEY = ";
        private string pkey_clm_err_msg = "";
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID REFERRING PHYSICIAN: BATCH CONTAINED CLINIC - ";
        private string err_refer_phys_nbr;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID PATIENT OHIP NBR: BATCH CONTAINED CLINIC - ";
        private string err_ohip_no;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID DIAG CODE: ";
        private string err_diag_code;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID I-O-INDICATOR: ";
        private string err_i_o_ind;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "NBR OF HEADER1 RECORDS READ IS NOT =  NBR OF HEADER1 RECORDS FROM TRAILER RECORD. ";
        private int err_ctr_h_count;
        //private string filler = "/";
        private int err_trl_h_count;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "NBR OF ITEM RECORDS READ IS NOT =  NBR OF ITEM RECORDS FROM TRAILER RECORD. ";
        private int err_ctr_t_count;
        //private string filler = "/";
        private int err_trl_t_count;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "NBR OF ADDRESS RECORDS IS NOT =  NBR OF ADDRESS RECORDS FROM TRAILER RECORD.  ";
        private int err_ctr_a_count;
        //private string filler = "/";
        private int err_trl_a_count;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "NBR OF BATCH RECORDS READ IS NOT =  NBR OF BATCH RECORDS FROM TRAILER RECORD";
        private int err_ctr_b_count;
        //private string filler = "/";
        private int err_trl_b_count;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID AGENT CODE:    ";
        private string err_agent_cd;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "DOCTOR SPECIALITY: ";
        private string err_21_value_1;
        //private string filler = "  NOT VALID FOR OHIP CODE: ";
        private string err_21_value_2;
        //private string filler = " RANGE: ";
        private string err_21_value_3;
        //private string filler = " THRU ";
        private string err_21_value_4;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "OMA CODE: ";
        private string err_22_oma_cd;
        //private string filler = "  REQUIRES -  ";
        private string err_22_msg;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID HOSPITAL NBR: ";
        private string err_hosp_nbr;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "SERVICE NOT WITHIN 231 days OF SYSTEM DATE:";
        private string err_24_service_date;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "DIRECT BILL CLAIM MISSING - MSG / AUTO LOGOUT / FEE COMPLEXITY / ... INFO";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID -ADMIT- DATE: ";
        private string err_admit_date;
        //private string filler;

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID INITIAL SERVICE DATE:";
        private string err_27_service_date;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID CONSECUTIVE SERVICES DATES/SVC'S:";
        private string err_additional_servs;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID HEALTH CARE NBR:";
        private string err_health_care_nbr;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "invalid province:";
        private string err_province;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID MANUAL REVIEW: ";
        private string err_manual_review;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID DEPT NO:  BATCH CONTAINED DEPT NO - ";
        private string err_msg_batch_dept_no;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "                  DOCTOR'S DEPT NO          - ";
        private string err_msg_doc_dept_no;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "NBR OF HEADER2 RECORDS READ IS NOT =  NBR OF HEADER2 RECORDS FROM TRAILER RECORD.  ";
        private int err_ctr_r_count;
        //private string filler = "/";
        private int err_trl_r_count;
        // private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID PROVIDER NO:  BATCH CONTAINED PROVIDER NO - ";
        private string err_msg_batch_prov_nbr;
        // private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "                  DOCTOR'S PROVIDER NO      - ";
        private string err_msg_doc_prov_nbr;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID BIRTH DATE:";
        private string err_birth_date;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "ZERO NUMBER OF SERVICE";
        private string err_nbr_of_serv;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "ZERO AMOUNT BILLED";
        private int err_fee_billed;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID SIZE OF HEALTH CARE NBR - Province/Nbr: ";
        private string err_prov;
        //private string filler = " / ";
        private string err_ohip_nbr;
        //private string filler;
        //private string filler = "CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS OF PROBLEM";
        //private string filler = "SERIOUS ERROR #10 - UNABLE TO READ CONSTANT MSTR REC #2 ";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID GROUP NBR: BATCH CONTAINED GROUP NBR - ";
        private string err_msg_group_nbr;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "SERVICE DATE: ";
        private string err_44_service_date;
        //private string filler = "IS PRIOR TO ADMIT DATE:";
        private string err_44_admit_date;
        //private string filler;
        //private string filler = "SERIOUS ERROR #11 - UNABLE TO READ CONSTANT MSTR REC #1 ";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID RELATIONSHIP: ";
        private string err_relationship;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "   REFERRING DOCTOR: - ";
        private string err_msg_referring_doc;
        //private string filler = " AND PROVIDER DOCTOR ARE THE SAME: - ";
        private string err_msg_provider_doc;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "      SERVICE DATE: - ";
        private string err_msg_svr_date;
        //private string filler = " IS GREATER THAN SYSTEM DATE: - ";
        private string err_msg_sys_date;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "OMA CODE I/O IND: ";
        private string err_49_oma_cd;
        //private string filler = " DOES NOT MATCH CLMHDR-2 REC I/O IND: ";
        private string err_49_hdr_cd;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = " MISSING DETAIL RECORDS FOR CLAIM: ";
        private string err_no_detail_claim;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "INVALID LOCATION CODE: BATCH CONTAINED LOCATION - ";
        private string err_51_loc_cd;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Incoming fee not = RMA priced fee  ";
        private decimal err_52_incoming_fee;
        //private string filler = " / ";
        private decimal err_52_ohip_fee;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Incoming I/O ind not = RMA I/O ind ";
        private string err_53_incoming_i_o_ind;
        //private string filler = " / ";
        private string err_53_i_o_ind;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Require facility number with premium cd ";
        //private string filler = " / ";
        private string err_54_prem_code;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Wrong hospital number with premium cd ";
        //private string filler = " / ";
        private string err_55_hosp_code;
        //private string filler = " / ";
        private string err_55_prem_code;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Wrong locn cd- must with 112/153/400/250/422/401/055/326/122";
        //private string filler = "/344/111/354/333/777";
        //private string filler = " / ";
        private string err_56_loc_code;
        //private string filler = " / ";
        private string err_56_prem_code;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "**ERROR** - INVALID CLINIC NBR FOR THE DOCTOR -         ";
        private int err_msg_doc_clinic;
        //private string filler = "";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "ADMIT DATE: ";
        private string err_58_admit_date;
        //private string filler = "  IS PRIOR TO BIRTH DATE:";
        private string err_58_birth_date;
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Doc Specialty = ";
        private int err_59_doc_spec;
        //private string filler = ", Birth date =  ";
        private string err_59_birth_date;
        //private string filler = "  and age must be >= 60";
        //private string filler;


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Doc Specialty = ";
        private int err_60_doc_spec;
        //private string filler = ", Birth date =  ";
        private string err_60_birth_date;
        //private string filler = "  and age must be >= 65 with diagnostic code 290";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Service Date  = ";
        private string err_61_serv_date;
        //private string filler = ", Birth date =  ";
        private string err_61_birth_date;
        //private string filler = "  and service date must be > birth date";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Location code = ";
        private string err_62_loc_code;
        //private string filler = ", clinic nbr = ";
        private int err_62_clinic_nbr;
        //private string filler = "  and wrong location for clinic 61 - 74";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Oma code = E420, check pricing";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "doc nbr = 049 and oma code = Z425 - take out manual review";


        //private string filler_grp;
        //private string filler = "";
        //private string filler = "check for E078 premium";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "check c122";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "check c123";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "check c124";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Check number of services for C suffix code";
        private string err_oma_cd;
        private string err_oma_suff;
        private string err_nbr_serv;
        private string err_nbr_serv_incoming;
        //private string filler = "";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E020C only allowed with E022C, E017C or E016C";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E719 only allowed with Z570";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E720 only allowed with Z571";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E717 only allowed with specific colonsocopy codes";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E702 only allowed with specific codes";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G123 only allowed with G228";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G223 only allowed with G231";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G265 only allowed with G264";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G385 only allowed with G384";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G281 only allowed with G381";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Maximum number of services exceeded";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E793 only allowed with specific procedures";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "P022 deleted as of 2008/02/01";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "K120 deleted as of 2008/02/01";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "A007 not allowed  for specialty '26'";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Check fee and services of E400";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Check fee and services of E401";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E798 allowed only with  Z400";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Check fee of E409/E410";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Use General Listing code with special visit premium";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E450 may only be billed with J315";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G222 not allowed with G248, G125, G118 or G062";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "A770 or A775 or A075 not allowed with special visit premium";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Z432C deleted as of 2009/10/01";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "H112 / H113 not allowed with another 'H' code";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Patient is underage for G489 / S323";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G222, Z804 or Z805 not allowed with P014C or P016C";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "H prefixed E.R. codes must be agent 2 or 9 in clinic 22";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G221 only allowed with G220";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Patient must be under 16 for service";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Patient is overage for H267";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Reassessment not allowed with resuscitation";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Assessment included in chemotherapy code";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Check suffix on 'G' code or premium code";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Patient must be 16 and under";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "J021 and J022 should be at 50% with J025";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Referring doctor must be an optometrist";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Referral must be a midwife";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Referring doctor cannot be an optometrist";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Z611 or Z602 not allowed with Z608";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Z176 or Z154 must have manual review";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Z175 - Z192 must have manual review";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Z403 with Z408 must have manual review";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "A195 with K002 requires manual review with times of each service";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Add E083 to MRP code";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "E083 only allowed with specific codes";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Clarification required to add J021";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Echo needs admit date for in-patient";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Oma code suffix  / SLI  does not have admit date";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Oma code suffix  / SLI  does not require admit date";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Patient is overage for service";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "K189 only allowed with specific codes";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Travel Premium billed incorrectly";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Check fee and services for E676B";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Canot use time units calculator for counselling";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "G556 only allowed with Day 1 per diem";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "A120 only allowed with colonscopy codes";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "Referral cannot be a midwife";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "DOCTOR HAS BEEN TERMINATED + 6 MONTHS :";
        private string err_128_term_date;
        //private string filler;

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "**FATAL ERROR** - INVALID REC TYPE - RECORD MISALIGNED:  ";
        private string err_rec_type;
        //private string filler = "";

        //private string filler_grp;
        //private string filler = "";
        //private string filler = "LOCATION Code not currently active for data entry = ";

        private string err_130_loc_cd;
        //private string filler = ""; 
        private string error_messages_r_grp;
        private string[] err_msg = new string[141];     //new string[131];            

        //    {"",
        //     Util.Str(err_warn_msg).PadRight(14) + "Batch = ".PadRight(8) + Util.Str(err_msg_pract_nbr).PadRight(6) + "/" + Util.Str(err_msg_account_id).PadRight(8) + new string(' ',95)
        // };

        private string endOfJob = "End of Job";
        private ReportPrint objReportFile = null;
        private WriteFile objRu701_Work_File = null;
        private WriteFile objPriced_Claims_File = null;
        private WriteFile objUnpriced_claims_file = null;
        private string low_values = "00";
        private int ctr;
        private int unrpiced_rec_ctr = 0;

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "03",Col = 10,Data1 = "Price claims/create Priced File/Upload to Suspense",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-current-system-date.",Line = "05",Col = 5,Data1 = "Current System Date",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-current-system-date.",Line = "05",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99999999",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_date",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-claim-source-default-reply.",Line = "07",Col = 5,Data1 = "Enter Claim SOURCE - 'W'eb / 'D'iskette / 'P'rice only [ ]",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-claim-source-default-reply.",Line = "07",Col = 70,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(01)",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag_claim_source",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-update-suspense-reply.",Line = "11",Col = 5,Data1 = "Do you want to upload claims to Suspense- [Y]/N ?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-update-suspense-reply.",Line = "11",Col = 70,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(01)",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag_update_suspense",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-create-priced-file-reply.",Line = "12",Col = 5,Data1 = "Do you want to create Priced File         [Y]/N ?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-create-priced-file-reply.",Line = "12",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(01)",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag_create_priced_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-retain-prices-reply.",Line = "14",Col = 5,Data1 = "Do you want to RETAIN Incoming prices- [Y]/N ?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-retain-prices-reply.",Line = "14",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(01)",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag_retain_prices",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-agent-default-reply.",Line = "16",Col = 5,Data1 = "Do you want to default 'BLANK' AGENT Codes to 'OHIP' (ie. '0') ?",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-agent-default-reply.",Line = "16",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(01)",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_agent_default_reply",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-doc-nbr.",Line = "15",Col = 5,Data1 = "Enter the DOCTOR NBR or press 'newline' to default to 0    :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-doc-nbr.",Line = "15",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(3)",MaxLength = 3,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_doc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-nbr.",Line = "17",Col = 5,Data1 = "Enter the CLINIC NBR or press 'newline' to default to 22(15):",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clinic-nbr.",Line = "17",Col = 68,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(2)",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ws_default_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-last-claim-lit.",Line = "03",Col = 65,Data1 = "Nbr of Svc",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-in-progress-message.",Line = "19",Col = 20,Data1 = "PROGRAM  NEWU701  NOW IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 1,Data1 = "PROGRAM NEWU701 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 10,Data1 = "AUDIT REPORT IS IN FILE - RU701",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_input_diskette_file_section()
        {

            //     use after standard error procedure on unpriced-claims-file.;
        }

        private async Task err_input_diskette()
        {

            //     stop "ERROR IN ACCESSING: dISKETTE INPUT FILE".;
            status_file = status_unpriced_claims;
            //     display file-status-display.;
            status_file = status_cobol_unpriced_claims;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_suspend_hdr_file_section()
        {

            //     use after standard error procedure on suspend-hdr.;
        }

        private async Task err_suspend_hdr()
        {

            //     display 'declarative status = ', status-suspend-hdr, ' cobol-status =  ', status-cobol-suspend-hdr.;
            //     stop ' '.;
            //     if   status-suspend-hdr       = "7013";
            //       or status-cobol-suspend-hdr = "22";
            //     then;
            //         go to err-suspend-hdr-50.;
            //     stop "ERROR IN ACCESSING: SUSPEND-HEADER";
            status_file = status_suspend_hdr;
            //     display file-status-display;
            status_file = status_cobol_suspend_hdr;
            //     display file-status-display;
            //     stop run.;
        }

        private async Task err_suspend_hdr_50()
        {

            skip_process_this_acct_id_flag = "D";
            //hold_suspend_hdr_rec = objSuspend_hdr_rec.suspend_hdr_rec;
            //     read suspend-hdr;
            //         invalid key;
            //           display  "SERIOUS IMPOSSIBLE ERROR #1 SUSPEND HDR FILE - KEY IS = ",suspend-hdr-id           stop run.;
            //objSuspend_hdr_rec.clmhdr_status = "Y";
            //     rewrite suspend-hdr-rec;
            //         invalid key;
            //            display "SERIOUS IMPOSSIBLE ERROR #2 SUSPEND HDR FILE - KEY IS = ",suspend-hdr-id;
            //            stop run.;
            //     display 'declarative flag = ', skip-process-this-acct-id-flag, ', account = ', clmhdr-doc-pract-nbr, clmhdr-accounting-nbr .;
            //     stop " ".;
            //objSuspend_hdr_rec.suspend_hdr_rec = hold_suspend_hdr_rec;
        }

        private async Task err_suspend_hdr_99_exit()
        {

            //     exit.;
        }

        private async Task err_suspend_dtl_file_section()
        {

            //     use after standard error procedure on suspend-dtl.;
        }

        private async Task err_suspend_dtl()
        {

            //     stop "ERROR IN ACCESSING: SUSPEND-DETAIL".;
            status_file = status_suspend_dtl;
            //     display file-status-display.;
            status_file = status_cobol_suspend_dtl;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_suspend_desc_file_section()
        {

            //     use after standard error procedure on suspend-desc.;
        }

        private async Task err_suspend_desc()
        {

            //     stop "ERROR IN ACCESSING: SUSPEND-DETAIL".;
            status_file = status_suspend_desc;
            //     display file-status-display.;
            status_file = status_cobol_suspend_desc;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_suspend_addr_file_section()
        {

            //     use after standard error procedure on suspend-address.;
        }

        private async Task err_suspend_addr()
        {

            //     stop "ERROR IN ACCESSING: SUSPEND-ADDRESS".;
            status_file = status_suspend_addr;
            //     display file-status-display.;
            status_file = status_cobol_suspend_addr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private async Task err_doc_mstr()
        {

            //     stop "ERROR IN ACCESSING: DOCTOR MASTER".;
            status_file = status_doc_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_diagnostics_mstr_file_section()
        {

            //     use after standard error procedure on diag-mstr.;
        }

        private async Task err_diagnostics_mstr()
        {

            //     stop "ERROR IN ACCESSING: DIAGNOSTIC CODES MASTER".;
            status_file = status_diag_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_constants_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private async Task err_constants_mstr()
        {

            //     if status-iconst-mstr = "7015";
            //     then;
            fatal_error_flag = "Y";
            ws_carriage_ctrl = 2;
            err_ind = 41;
            //err_warn_msg = ws_error_literal;
            //err_msg_clinic_id = batch_group_nbr;
            //         perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
            //     else;
            status_file = status_iconst_mstr;
            //         display  file-status-display;
            //         display "ERROR IN ACCESSING CONSTANTS MASTER";
            //         stop run.;
        }

        private async Task err_report_file_section()
        {

            //     use after standard error procedure on report-file.;
        }

        private async Task err_report()
        {

            //     stop "ERROR IN WRITING TO AUDIT REPORT: RU701".;
            status_file = status_report;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task end_declaratives()
        {

        }

        private async Task initialize_objects()
        {
            Util.Trakker(++ctr, "initialize_objects");

            objUnpriced_claims_record = null;
            objUnpriced_claims_record = new Unpriced_claims_record();


            Unpriced_claims_record_Collection = null;
            Unpriced_claims_record_Collection = Read_Unpriced_Claims_File_SequentialFile();

            objDiskout_output_rec = null;
            objDiskout_output_rec = new Diskout_output_rec();

            Diskout_output_rec_Collection = null;
            Diskout_output_rec_Collection = new ObservableCollection<Diskout_output_rec>();

            objRu701_work_rec = null;
            objRu701_work_rec = new Ru701_work_rec();

            Ru701_work_rec_Collection = null;
            Ru701_work_rec_Collection = new ObservableCollection<Ru701_work_rec>();

            objRpt_line = null;
            objRpt_line = new Rpt_line();

            objReportFile = null;
            objReportFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + audit_file);

            objRu701_Work_File = null;
            objRu701_Work_File = new WriteFile(Directory.GetCurrentDirectory() + "\\ru701_work_file.dat");

            objPriced_Claims_File = null;
            objPriced_Claims_File = new WriteFile(Directory.GetCurrentDirectory() + "\\submit_disk_susp.out");

            Rpt_line_Collection = null;
            Rpt_line_Collection = new ObservableCollection<Rpt_line>();

            objSuspend_hdr_rec = null;
            objSuspend_hdr_rec = new F002_SUSPEND_HDR();

            Suspend_hdr_rec_Collection = null;
            Suspend_hdr_rec_Collection = new ObservableCollection<F002_SUSPEND_HDR>();

            objSuspend_dtl_rec = null;
            objSuspend_dtl_rec = new F002_SUSPEND_DTL();

            Suspend_dtl_rec_Collection = null;
            Suspend_dtl_rec_Collection = new ObservableCollection<F002_SUSPEND_DTL>();

            objSuspend_address_rec = null;
            objSuspend_address_rec = new F002_SUSPEND_ADDRESS();

            Suspend_address_rec_Collection = null;
            Suspend_address_rec_Collection = new ObservableCollection<F002_SUSPEND_ADDRESS>();

            objSuspend_desc_rec = null;
            objSuspend_desc_rec = new F002_SUSPEND_DESC();

            Suspend_desc_rec_Collection = null;
            Suspend_desc_rec_Collection = new ObservableCollection<F002_SUSPEND_DESC>();

            objSuspend_Hdr = new WriteFile(Directory.GetCurrentDirectory() + "\\F002_SUSPEND_HDR.dat");
            objSuspend_Dtl = new WriteFile(Directory.GetCurrentDirectory() + "\\F002_SUSPEND_DTL.dat");
            objSuspend_Address = new WriteFile(Directory.GetCurrentDirectory() + "\\F002_SUSPEND_ADDRESS.dat");
            objSuspend_Desc = new WriteFile(Directory.GetCurrentDirectory() + "\\F002_SUSPEND_DESC.dat");

            objDoc_mstr_rec = null;
            objDoc_mstr_rec = new F020_DOCTOR_MSTR();

            Doc_mstr_rec_Collection = null;
            Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

            objLoc_mstr_rec = null;
            objLoc_mstr_rec = new F030_LOCATIONS_MSTR();

            Loc_mstr_rec_Collection = null;
            Loc_mstr_rec_Collection = new ObservableCollection<F030_LOCATIONS_MSTR>();

            objFee_mstr_rec = null;
            objFee_mstr_rec = new F040_OMA_FEE_MSTR();

            Fee_mstr_rec_Collection = null;
            Fee_mstr_rec_Collection = new ObservableCollection<F040_OMA_FEE_MSTR>();

            objF020L_DOC_LOCATIONS = null;
            objF020L_DOC_LOCATIONS = new F020L_DOC_LOCATIONS();

            F020L_DOC_LOCATIONS_Collection = null;
            F020L_DOC_LOCATIONS_Collection = new ObservableCollection<F020L_DOC_LOCATIONS>();

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();

            Iconst_mstr_rec_Collection = null;
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objConstants_mstr_rec_2 = null;
            objConstants_mstr_rec_2 = new CONSTANTS_MSTR_REC_2();

            Constants_mstr_rec_2_Collection = null;
            Constants_mstr_rec_2_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_2>();

            objDiag_rec = null;
            objDiag_rec = new F091_DIAG_CODES_MSTR();

            Diag_rec_Collection = null;
            Diag_rec_Collection = new ObservableCollection<F091_DIAG_CODES_MSTR>();

            objSli_oma_code_suff_rec = null;
            objSli_oma_code_suff_rec = new F201_SLI_OMA_CODE_SUFF();

            Sli_oma_code_suff_rec_Collection = null;
            Sli_oma_code_suff_rec_Collection = new ObservableCollection<F201_SLI_OMA_CODE_SUFF>();

            objConstants_mstr_rec_1 = null;
            objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1();

            Constants_mstr_rec_1_Collection = null;
            Constants_mstr_rec_1_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_1>();
        }

        public async Task mainline_section()
        {
            Util.Trakker(++ctr, "mainline_section");

            try
            {
                await initialize_objects();

                //     perform aa0-initialization          thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_05_default_claim_source();
                string retval = await aa0_07_retain_prices();
                await aa0_09_update_suspense();
                await aa0_10_create_priced_file();
                await aa0_20_default_agent();
                await aa0_99_exit();

                //     perform ab0-processing              thru ab0-99-exit;
                //             until   eof-input-file;
                //                  or fatal-error.;

                do
                {
                    await ab0_processing();
                    await ab0_99_exit();
                } while (!eof_input_file_flag.Equals(eof_input_file) && !fatal_error_flag.Equals(fatal_error));

                //     perform az0-finalization            thru az0-99-exit.;
                await az0_finalization();
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
                if (objReportFile != null)
                {
                    objReportFile.Close();
                    objReportFile = null;
                }

                if (objRu701_Work_File != null)
                {
                    objRu701_Work_File.CloseOutputFile();
                    objRu701_Work_File = null;
                }

                if (objPriced_Claims_File != null)
                {
                    objPriced_Claims_File.CloseOutputFile();
                    objPriced_Claims_File = null;
                }

                if (objSuspend_Hdr != null)
                {
                    objSuspend_Hdr.CloseOutputFile();
                    objSuspend_Hdr = null;
                }

                if (objSuspend_Dtl != null)
                {
                    objSuspend_Dtl.CloseOutputFile();
                    objSuspend_Dtl = null;
                }

                if (objSuspend_Address != null)
                {
                    objSuspend_Address.CloseOutputFile();
                    objSuspend_Address = null;
                }

                if (objSuspend_Desc != null)
                {
                    objSuspend_Desc.CloseOutputFile();
                    objSuspend_Desc = null;
                }
            }
        }



        private async Task aa0_initialization()
        {
            Util.Trakker(++ctr, "aa0_initialization");

            //     display scr-title.;
            //Display("scr-title.");
            Console.WriteLine("Price claims/create Priced File/Upload to Suspense");

            //     accept sys-date             from date.;
            sys_date_grp = Sysdate();
            sys_date = Util.NumInt(sys_date_grp);
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

            //     display scr-current-system-date.;
            //Display("scr-current-system-date.");
            Console.WriteLine("Current System Date" + "                  " + Util.Str(sys_date_long_child));

            //     accept  scr-current-system-date.;
            //await Prompt("sys_date");

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;

            // run_date_grp = run_yy + "/" + run_mm + "/" + run_dd;
            l1_run_date = await run_date_grp();

            //     accept sys-time             from time.;
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

            ws_doc_nbr = "";
            ws_default_clinic_nbr = 22;

            //     display scr-claim-source-default-reply.;
            //Display("scr-claim-source-default-reply.");            
           // Console.WriteLine("Enter Claim SOURCE - 'W'eb / 'D'iskette / 'P'rice only [ ]                   " + Util.Str(flag_claim_source));

            //     display scr-retain-prices-reply.;
            //Display("scr-retain-prices-reply.");            
            //Console.WriteLine("Do you want to RETAIN Incoming prices- [Y]/N ?                               " + Util.Str(flag_retain_prices));

            //     display scr-update-suspense-reply.;
            //Display("scr-update-suspense-reply.");            
            //Console.WriteLine("Do you want to upload claims to Suspense- [Y]/N ?                            " + Util.Str(flag_update_suspense));

            //     display scr-create-priced-file-reply.;
            //Display("scr-create-priced-file-reply.");            
            //Console.WriteLine("Do you want to create Priced File         [Y]/N ?                            " + Util.Str(flag_create_priced_file));

            //     display scr-agent-default-reply.;
            //Display("scr-agent-default-reply.");            
            //Console.WriteLine("Do you want to default 'BLANK' AGENT Codes to 'OHIP' (ie. '0') ?             " + Util.Str(ws_agent_default_reply));
        }

        private async Task aa0_05_default_claim_source()
        {
            Util.Trakker(++ctr, "aa0_05_default_claim_source");

            //     display scr-claim-source-default-reply.;
            //Display("scr-claim-source-default-reply.");                        
            Console.WriteLine("Enter Claim SOURCE - 'W'eb / 'D'iskette / 'P'rice only [ ]                   "); // + Util.Str(flag_claim_source));

            flag_claim_source = Console.ReadLine();

            //     accept  scr-claim-source-default-reply.;
            //await Prompt("flag_claim_source");

            //  if web-claim  or diskette-claim or price-only-claim then
            if (Util.Str(flag_claim_source).Equals(web_claim) || Util.Str(flag_claim_source).Equals(diskette_claim) || Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                //    	next sentence;
            }
            else
            {
                // 	   go to aa0-05-default-claim-source.;
                await aa0_05_default_claim_source();
                return;
            }
        }

        private async Task<string> aa0_07_retain_prices()
        {
            Util.Trakker(++ctr, "aa0_07_retain_prices");

            //  if web-claim  then
            if (Util.Str(flag_claim_source).Equals(web_claim))
            {
                flag_retain_prices = "N";
                // 	   go to aa0-09-update-suspense;                
                return "aa0_09_update_suspense";
            }
            //  else if price-only-claim then
            else if (Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                flag_retain_prices = "N";
                // 	   go to aa0-09-update-suspense.;                
                return "aa0_09_update_suspense";
            }

            flag_retain_prices = "Y";
            //     accept  scr-retain-prices-reply.;
            //Display("scr-retain-prices-reply.");                        
            Console.WriteLine("Do you want to RETAIN Incoming prices- [Y]/N ?                               "); //  + Util.Str(flag_retain_prices));
            //await Prompt("flag_retain_prices");
            flag_retain_prices = Console.ReadLine();

            //  if  retain-incoming-prices or override-with-rma-prices  then      
            if (Util.Str(flag_retain_prices).Equals(retain_incoming_prices) || Util.Str(flag_retain_prices).Equals(override_with_rma_prices))
            {
                //   	next sentence;
            }
            else
            {
                // 	   go to aa0-07-retain-prices.;                
                await aa0_07_retain_prices();
            }
            return string.Empty;
        }

        private async Task<string> aa0_09_update_suspense()
        {
            Util.Trakker(++ctr, "aa0_09_update_suspense");

            //     display scr-retain-prices-reply.;
            //Display("scr-retain-prices-reply.");            
            //Console.WriteLine("Do you want to RETAIN Incoming prices- [Y]/N ?                               "); // + Util.Str(flag_retain_prices));

            //  if web-claim then            
            if (Util.Str(flag_claim_source).Equals(web_claim))
            {
                flag_update_suspense = "Y";
                // 	   go to aa0-10-create-priced-file;                
                return "aa0_10_create_priced_file";
            }
            //  else if price-only-claim then            
            else if (Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                flag_update_suspense = "N";
                // 	    go to aa0-10-create-priced-file.;                
                return "aa0_10_create_priced_file";
            }

            flag_update_suspense = "Y";
            //     accept  scr-update-suspense-reply.;
            //Display("scr-update-suspense-reply.");
            //await Prompt("flag_update_suspense");            
            Console.WriteLine("Do you want to upload claims to Suspense- [Y]/N ?                            "); // + Util.Str(flag_update_suspense));
            flag_update_suspense = Console.ReadLine();

            //  if  update-suspense or dont-update-suspense then    
            if (Util.Str(flag_update_suspense).Equals(update_suspense) || Util.Str(flag_update_suspense).Equals(dont_update_suspense))
            {
                // 	    next sentence;
            }
            else
            {
                // 	    go to aa0-09-update-suspense.;
                await aa0_09_update_suspense();
            }
            return string.Empty;
        }

        private async Task<string> aa0_10_create_priced_file()
        {
            Util.Trakker(++ctr, "aa0_10_create_priced_file");

            //     display scr-update-suspense-reply.;
            //Display("scr-update-suspense-reply.");            
           // Console.WriteLine("Do you want to upload claims to Suspense- [Y]/N ?                            "); // + Util.Str(flag_update_suspense));

            // if web-claim  then            
            if (Util.Str(flag_claim_source).Equals(web_claim))
            {
                flag_create_priced_file = "Y";
                // 	  go to aa0-20-default-agent;                
                return "aa0_20_default_agent";
            }
            // else if price-only-claim then            
            else if (Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                flag_create_priced_file = "Y";
                // 	   go to aa0-20-default-agent.;                
                return "aa0_20_default_agent";
            }

            flag_create_priced_file = "Y";

            //     accept  scr-create-priced-file-reply.;
            //Display("scr-create-priced-file-reply.");
            //await Prompt("flag_create_priced_file");            
            Console.WriteLine("Do you want to create Priced File         [Y]/N ?                            "); // +  Util.Str(flag_create_priced_file));
            flag_create_priced_file = Console.ReadLine();

            //  if  create-priced-file or dont-create-priced-file then   
            if (Util.Str(flag_create_priced_file).Equals(create_priced_file) || Util.Str(flag_create_priced_file).Equals(dont_create_priced_file))
            {
                // 	    next sentence;
            }
            else
            {
                // 	    go to aa0-10-create-priced-file.;
                await aa0_10_create_priced_file();
            }

            return string.Empty;
        }

        private async Task<string> aa0_20_default_agent()
        {
            Util.Trakker(++ctr, "aa0_20_default_agent");

            //     display scr-create-priced-file-reply.;
            //Display("scr-create-priced-file-reply.");            
            Console.WriteLine("Do you want to create Priced File         [Y]/N ?                            " + Util.Str(flag_create_priced_file));

            ws_agent_default_reply = "Y";
            //     display scr-agent-default-reply.;
            //Display("scr-agent-default-reply.");            
            Console.WriteLine("Do you want to default 'BLANK' AGENT Codes to 'OHIP' (ie. '0') ?             " + Util.Str(ws_agent_default_reply));

            // if ws-agent-default-reply = "Y" or "N" then            
            if (Util.Str(ws_agent_default_reply).ToUpper().Equals("Y") || Util.Str(ws_agent_default_reply).ToUpper().Equals("N"))
            {
                // 	  next sentence;
            }
            else
            {
                //     go to aa0-20-default-agent.;
                await aa0_20_default_agent();
                return string.Empty;
            }

            //     display scr-doc-nbr.;
            //Display("scr-doc-nbr.");            
            Console.WriteLine("Enter the DOCTOR NBR or press 'newline' to default to 0    :                 " +  Util.Str(ws_doc_nbr));

            //     display scr-clinic-nbr.;
            //Display("scr-clinic-nbr.");
            Console.WriteLine("Enter the CLINIC NBR or press 'newline' to default to 22(15):                " + Util.Str(ws_default_clinic_nbr));

            //     display scr-in-progress-message.;
            //Display("scr-in-progress-message.");
            Console.WriteLine("PROGRAM  NEWU701  NOW IN PROGRESS");

            //objSuspend_hdr_rec.suspend_hdr_rec = "";
            objSuspend_hdr_rec = new F002_SUSPEND_HDR();

            //objSuspend_dtl_rec.suspend_dtl_rec = "";
            objSuspend_dtl_rec = new F002_SUSPEND_DTL();

            //objSuspend_address_rec.suspend_address_rec = "";
            objSuspend_address_rec = new F002_SUSPEND_ADDRESS();

            suspend_dtl_occur = 0;
            ws_temp = 0;
            //counters = 0;
            ctr_read_const_mstr = 0;
            ctr_diskout_writes = 0;
            ctr_suspend_hdr_writes = 0;
            ctr_suspend_dtl_writes = 0;
            ctr_suspend_desc_writes = 0;
            ctr_suspend_addr_writes = 0;
            ctr_recs_read = 0;
            ctr_b_recs_read_skipped = 0;
            ctr_h_recs_read_skipped = 0;
            ctr_r_recs_read_skipped = 0;
            ctr_t_recs_read_skipped = 0;
            ctr_a_recs_read_skipped = 0;
            ctr_e_recs_read_skipped = 0;
            ctr_b_recs_read = 0;
            ctr_h_recs_read = 0;
            ctr_r_recs_read = 0;
            ctr_t_recs_read = 0;
            ctr_a_recs_read = 0;
            ctr_e_recs_read = 0;
            ctr_h_recs_skipped = 0;
            ctr_r_recs_skipped = 0;
            ctr_t_recs_skipped = 0;
            ctr_a_recs_skipped = 0;
            ctr_tot_b_recs = 0;
            ctr_tot_h_recs = 0;
            ctr_tot_r_recs = 0;
            ctr_tot_t_recs = 0;
            ctr_tot_a_recs = 0;
            ctr_tot_dollars_read = 0;
            ctr_tot_dollars_oma = 0;
            ctr_tot_dollars_ohip = 0;
            ctr_tot_tech_claim = 0;
            ctr_tot_svcs_read = 0;
            ctr_hdr2_rec = 0;
            ctr_addr_rec = 0;


            //     open input  unpriced-claims-file;
            //                 loc-mstr;
            //                 doc-mstr;
            //                 diag-mstr;
            //                 oma-fee-mstr;
            // 		sli-oma-code-suff-mstr;
            //                 iconst-mstr.;

            //     open i-o    suspend-hdr;
            //                 suspend-dtl;
            //   		        suspend-desc;
            //                 suspend-address.;

            //     open output report-file;
            // 	         	ru701-work-file;
            //                 priced-claims-file.;

            //hold_oma_recs = "";
            hold_oma_recs_grp = "";
            hold_accounting_nbr = "";

            //hold_oma_rec_grp = new string[91];
            //hold_oma_cd_grp = new string[91];
            hold_oma_cd_alpha = new string[91];
            hold_oma_cd_num_grp = new string[91];
            hold_oma_cd_num_1 = new int[91];
            hold_oma_cd_num_2 = new int[91];
            hold_oma_cd_num_3 = new int[91];
            hold_oma_suff = new string[91];
            hold_sv_nbr_serv_incoming = new int[91];
            hold_sv_nbr_serv = new int[91];
            hold_admit_date_icc_grp = new string[91];
            hold_sv_date_grp = new string[91];
            hold_sv_date_yy = new int[91];
            hold_sv_date_yy_r_grp = new int[91];
            hold_sv_date_yy_12 = new int[91];
            hold_sv_date_yy_34 = new int[91];
            hold_sv_date_mm = new int[91];
            hold_sv_date_dd = new int[91];
            hold_icc_cd_grp = new string[91];
            hold_icc_sec = new string[91];
            hold_icc_grp = new string[91];

            hold_key_r_grp = new string[91];
            hold_sort_key_1 = new string[91];
            hold_svnbr_days_conseq = new string[91, 4];
            hold_sv_nbr = new int[91, 4];
            hold_sv_day = new string[91, 4];
            hold_sv_day_num = new int[91, 4];

            hold_override_price = new string[91];
            hold_bilateral = new string[91];
            hold_fee_incoming = new decimal[91];

            hold_fee_oma = new decimal[91];
            hold_fee_oma_r = new int[91];
            hold_fee_ohip = new decimal[91];
            hold_fee_ohip_r = new int[91];
            hold_priced_tech = new decimal[91];
            hold_basic_tech = new decimal[91];
            hold_basic_prof = new decimal[91];
            hold_basic_fee = new decimal[91];

            hold_oma_rec_ind = new string[91, 9];

            hold_oma_add_on_cd = new string[91, 11];

            hold_oma_ind_card_requireds = new string[91, 4];
            hold_oma_ind_card_required = new string[91, 4];

            hold_oma_fees = new string[91, 3];
            hold_oma_fee_1 = new decimal[91, 3];
            hold_oma_fee_2 = new decimal[91, 3];
            hold_fee_min = new decimal[91, 3];
            hold_fee_max = new decimal[91, 3];
            hold_oma_fee_anae = new int[91, 3];
            hold_oma_fee_asst = new int[91, 3];

            hold_ss_curr_prev = new int[91];

            hold_flag_fee_used = new string[91];

            hold_flag_sec_group = new string[91];
            hold_flag_sec = new int[91];
            hold_flag_grp = new int[91];

            hold_diag_cd = new int[91];
            hold_line_no = new int[91];


            //     perform aa1-init-hold-oma-rec      thru    aa1-99-exit;
            // 		varying i;
            //    		from    1;
            //    		by      1;
            // 		until   i  > ss-max-nbr-oma-det-rec-allow.;

            i = 1;
            do
            {
                await aa1_init_hold_oma_rec();
                await aa1_99_exit();
                i++;
            } while (i <= ss_max_nbr_oma_det_rec_allow);

            objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 1;
            //     perform uj1-read-isam-const-mstr thru   uj1-99-exit.;
            await uj1_read_isam_const_mstr();
            await uj1_99_exit();

            //  if fatal-error then 
            if (Util.Str(fatal_error_flag).Equals(fatal_error))
            {
                fatal_error_flag = "Y";
                ws_carriage_ctrl = 2;
                err_ind = 45;
                err_warn_msg = ws_error_literal;
                //    perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //        go to aa0-99-exit;                
                return "aa0_99_exit";
            }
            else
            {
                //        constants_mstr_rec_1 = objConstants_mstr_rec_2.constants_mstr_rec_2;
                objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1
                {
                    WhereConst_rec_nbr = 1
                }.Collection().FirstOrDefault();
            }

            objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 2;
            //     perform uj1-read-isam-const-mstr thru   uj1-99-exit.;
            await uj1_read_isam_const_mstr();
            await uj1_99_exit();


            //  if fatal-error then;      
            if (Util.Str(fatal_error_flag).Equals(fatal_error))
            {
                fatal_error_flag = "Y";
                ws_carriage_ctrl = 2;
                err_ind = 42;
                err_warn_msg = ws_error_literal;
                //    perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //        go to aa0-99-exit.;                
                return "aa0_99_exit";
            }

            //     perform ta0-read-diskette                   thru ta0-99-exit.;
            await ta0_read_diskette();
            await ta0_99_exit();

            //  if b-record  then            
            if (Util.Str(record_type_flags).Equals(b_record))
            {
                //         add 1                           to      ctr-b-recs-read;
                ctr_b_recs_read++;
                //         perform ea0-proc-rec-type-batch thru    ea0-99-exit;
                await ea0_proc_rec_type_batch();
                await ea0_99_exit();

                //         if fatal-error then 
                if (Util.Str(fatal_error_flag).Equals(fatal_error))
                {
                    //            go to aa0-99-exit;                    
                    return "aa0_99_exit";
                }
                else
                {
                    //             perform ta0-read-diskette   thru    ta0-99-exit;
                    await ta0_read_diskette();
                    await ta0_99_exit();
                }
            }
            else
            {
                fatal_error_flag = "Y";
                ws_carriage_ctrl = 2;
                err_ind = 7;
                err_warn_msg = ws_error_literal;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.                
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            ss_clmdtl_oma = 0;
            ws_special_add_on_cd_entered = "N";

            ws_e078_premium = "N";

            ws_e020 = "N";
            ws_e719 = "N";
            ws_e720 = "N";
            ws_e717 = "N";
            ws_e702 = "N";
            ws_g123 = "N";
            ws_g223 = "N";

            ws_g265 = "N";
            ws_g385 = "N";
            ws_g281 = "N";
            ws_e793 = "N";
            ws_e022_e017_e016 = "N";
            ws_z570 = "N";
            ws_z571 = "N";
            ws_z555_z580 = "N";
            ws_z515_z760 = "N";
            ws_g228 = "N";
            ws_g231 = "N";
            ws_g264 = "N";
            ws_g384 = "N";
            ws_g381 = "N";
            ws_r905_s800 = "N";
            ws_annna = "N";
            ws_gnnna = "N";
            ws_k991_u997 = "N";

            ws_c998 = "N";
            ws_c999 = "N";
            ws_e798 = "N";
            ws_z400 = "N";
            ws_g400_other_codes = "N";
            ws_e409_e410 = "N";
            ws_c990_to_c997 = "N";
            ws_cnnn = "N";
            ws_e450 = "N";
            ws_j315 = "N";

            ws_c985 = "N";
            ws_g248_g062 = "N";
            ws_g222 = "N";
            ws_a770_a775 = "N";
            ws_X9nn = "N";
            ws_h112_h113 = "N";
            ws_hnnn = "N";
            ws_g489_s323 = "N";
            ws_g222_z805 = "N";
            ws_p014_p016 = "N";
            ws_g221 = "N";
            ws_g220 = "N";
            ws_s322_a198 = "N";
            ws_a765_c765 = "N";
            ws_g521_g395 = "N";
            ws_h104_h124 = "N";
            ws_g345_g339 = "N";
            ws_g431_g479 = "N";
            ws_gnnn = "N";
            ws_annn = "N";

            ws_c983 = "N";
            ws_j025 = "N";
            ws_j021 = "N";
            ws_j022 = "N";
            ws_z608 = "N";
            ws_z611_z602 = "N";
            ws_z403 = "N";
            ws_z408 = "N";
            ws_a195 = "N";
            ws_k002 = "N";
            ws_c122_c143 = "N";
            ws_e083 = "N";
            ws_c122_c982 = "N";
            ws_g489_g376 = "N";

            ws_a197_a198 = "N";
            ws_k189 = "N";
            ws_a190_a795 = "N";
            ws_k960 = "N";
            ws_k990 = "N";
            ws_k961 = "N";
            ws_k992 = "N";
            ws_k962 = "N";
            ws_k994 = "N";
            ws_k963 = "N";
            ws_k998 = "N";
            ws_k964 = "N";
            ws_k996 = "N";
            ws_c960 = "N";
            ws_c990 = "N";
            ws_c961 = "N";
            ws_c992 = "N";
            ws_c962 = "N";
            ws_c994 = "N";
            ws_c963 = "N";
            ws_c986 = "N";
            ws_c964 = "N";
            ws_c996 = "N";
            ws_e676 = "N";

            ws_g556 = "N";
            ws_g400_g620 = "N";
            ws_a120 = "N";
            ws_z491_to_z499 = "N";
            ws_g325 = "N";
            ws_e402_e403 = "N";
            ws_g247 = "N";
            ws_e797 = "N";
            ws_z491_z580 = "N";
            ws_e414 = "N";
            ws_p030 = "N";
            ws_a895 = "N";
            ws_wnnn = "N";
            ws_knnn = "N";
            ws_z512 = "N";
            ws_z514 = "N";
            ws_z580 = "N";
            ws_cnnn_c101 = "N";
            ws_total_nbr_svc = 0;
            ws_edit_80 = "N";
            ws_a075 = "N";

            ws_sv_date_c1 = 0;
            ws_sv_date_c2 = 0;

            //objDiskout_output_rec.diskout_cr = carriage_return;
            objDiskout_output_rec.Diskout_cr = carriage_return;
            //objDiskout_output_rec.diskout_lf = line_feed;
            objDiskout_output_rec.Diskout_lf = line_feed;

            return string.Empty;
        }

        private async Task aa0_99_exit()
        {
            Util.Trakker(++ctr, "aa0_99_exit");

            //     exit.;
        }

        private async Task aa1_init_hold_oma_rec()
        {
            Util.Trakker(++ctr, "aa1_init_hold_oma_rec");

            hold_sv_nbr_serv[i] = 0;
            hold_sv_date_yy[i] = 0;
            hold_sv_date_mm[i] = 0;
            hold_sv_date_dd[i] = 0;
            hold_icc_grp[i] = "00";
            hold_fee_incoming[i] = 0;
            hold_sv_nbr_serv_incoming[i] = 0;

            hold_ss_curr_prev[i] = 0;

            hold_fee_oma[i] = 0;
            hold_fee_ohip[i] = 0;
            hold_priced_tech[i] = 0;
            hold_basic_tech[i] = 0;
            hold_basic_prof[i] = 0;
            hold_basic_fee[i] = 0;
            hold_flag_sec[i] = 0;
            hold_flag_grp[i] = 0;
            hold_diag_cd[i] = 0;
            hold_line_no[i] = 0;

            //     perform aa2-init-oma-fees 	thru aa2-99-exit;
            // 	varying ss1;
            // 	from    1;
            //          by	1;
            // 	until   ss1 > 2.;

            ss1 = 1;
            do
            {
                await aa2_init_oma_fees();
                await aa2_99_exit();
                ss1++;
            } while (ss1 <= 2);

            //     perform aa3-init-sv-nbr  thru aa3-99-exit;
            // 	varying ss1;
            // 	from    1;
            // 	 by	1;
            // 	until   ss1 > 3.;

            ss1 = 1;
            do
            {
                await aa3_init_sv_nbr();
                await aa3_99_exit();
                ss1++;
            } while (ss1 <= 3);
        }

        private async Task aa1_99_exit()
        {
            Util.Trakker(++ctr, "aa1_99_exit");

            //     exit.;
        }

        private async Task aa2_init_oma_fees()
        {
            Util.Trakker(++ctr, "aa2_init_oma_fees");

            hold_oma_fee_1[i, ss1] = 0;
            hold_oma_fee_2[i, ss1] = 0;
            hold_oma_fee_anae[i, ss1] = 0;
            hold_oma_fee_asst[i, ss1] = 0;
        }

        private async Task aa2_99_exit()
        {
            Util.Trakker(++ctr, "aa2_99_exit");

            //     exit.;
        }

        private async Task aa3_init_sv_nbr()
        {
            Util.Trakker(++ctr, "aa3_init_sv_nbr");

            hold_sv_nbr[i, ss1] = 0;
        }

        private async Task aa3_99_exit()
        {
            Util.Trakker(++ctr, "aa3_99_exit");

            //     exit.;
        }

        private async Task<string> ab0_processing()
        {
            Util.Trakker(++ctr, "ab0_processing");
          
            // if b-record then            
            if (Util.Str(record_type_flags).Equals(b_record))
            {
                //         add 1                                   to      ctr-b-recs-read;
                ctr_b_recs_read++;
                //         perform ea0-proc-rec-type-batch         thru    ea0-99-exit;
                await ea0_proc_rec_type_batch();
                await ea0_99_exit();
            }
            // else if h-record  then  
            else if (Util.Str(record_type_flags).Equals(h_record))
            {
                //         add 1                                   to      ctr-h-recs-read;
                ctr_h_recs_read++;
                //         perform fa0-proc-rec-type-header1       thru    fa0-99-exit;
                await fa0_proc_rec_type_header1();
                await fa0_99_exit();
            }
            // else if r-record then            
            else if (Util.Str(record_type_flags).Equals(r_record))
            {
                //         add 1                                   to      ctr-r-recs-read;
                ctr_r_recs_read++;
                ctr_hdr2_rec = 1;
                //          perform ga0-proc-rec-type-header2       thru    ga0-99-exit;
                string retval =  await ga0_proc_rec_type_header2();
                await ga0_90();
                await ga0_99_exit();
            }
            // else if t-record  then 
            else if (Util.Str(record_type_flags).Equals(t_record))
            {
                //         add 1                                   to      ctr-t-recs-read;
                ctr_t_recs_read++;
                //         perform ha0-proc-rec-type-detail        thru    ha0-99-exit;
                await ha0_proc_rec_type_detail();   //
                await ha0_90_after_2nd_detail();
                await ha0_99_exit();
            }
            // else if a-record then 
            else if (Util.Str(record_type_flags).Equals(a_record))
            {
                //         add 1                                   to      ctr-a-recs-read;
                ctr_a_recs_read++;
                ctr_addr_rec = 1;
                //         perform ia0-proc-rec-type-address       thru    ia0-99-exit;
                await ia0_proc_rec_type_address();
                await ia0_99_exit();
            }
            //  else if e-record then
            else if (Util.Str(record_type_flags).Equals(e_record))
            {
                //         add 1                                   to      ctr-e-recs-read;
                ctr_e_recs_read++;
                //         perform ka0-proc-rec-type-trailer       thru    ka0-99-exit;
                await ka0_proc_rec_type_trailer();
                await ka0_99_exit();
            }
            else
            {
                err_warn_msg = ws_error_literal;
                //       perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                fatal_error_flag = "Y";
                err_ind = 129;

                hold_in_rec_type_grp = Util.Str(hold_trans_id).PadRight(2) + Util.Str(hold_rec_type);
                err_rec_type = hold_in_rec_type_grp;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //         go to ab0-99-exit.;                
                return "ab0_99_exit";
            }

            //  if skip-processing-this-acct-id then 
            if (Util.Str(skip_process_this_acct_id_flag).Equals(skip_processing_this_acct_id))
            {
                //        objUnpriced_claims_record.unpriced_claims_record = "";
                objUnpriced_claims_record = new Unpriced_claims_record();
                //   perform ta0-read-diskette               thru    ta0-99-exit until  b-record or eof-input-file 
                await ta0_read_diskette();
                await ta0_99_exit();
            }
            //  else if not eof-input-file            
            else if (!Util.Str(eof_input_file_flag).Equals(eof_input_file))
            {
                //        perform ta0-read-diskette               thru    ta0-99-exit.;
                await ta0_read_diskette();
                await ta0_99_exit();
            }

            return string.Empty;
        }

        private async Task ab0_99_exit()
        {
            Util.Trakker(++ctr, "ab0_99_exit");

            //     exit.;
        }

        private async Task az0_finalization()
        {
            Util.Trakker(++ctr, "az0_finalization");

            //    close unpriced-claims-file;
            objUnpriced_claims_record = null;
            Unpriced_claims_record_Collection = null;

            //          priced-claims-file;

            //          suspend-hdr;
            objSuspend_hdr_rec = null;
            Suspend_hdr_rec_Collection = null;
            //          suspend-dtl;
            objSuspend_dtl_rec = null;
            Suspend_dtl_rec_Collection = null;
            //          suspend-address;
            objSuspend_address_rec = null;
            Suspend_address_rec_Collection = null;

            //   	 suspend-desc;
            objSuspend_desc_rec = null;
            Suspend_desc_rec_Collection = null;

            //          doc-mstr;
            objDoc_mstr_rec = null;
            Doc_mstr_rec_Collection = null;
            //          loc-mstr;
            objLoc_mstr_rec = null;
            Loc_mstr_rec_Collection = null;
            //          oma-fee-mstr;
            objFee_mstr_rec = null;
            Fee_mstr_rec_Collection = null;
            //          diag-mstr;
            objDiag_rec = null;
            Diag_rec_Collection = null;
            //          iconst-mstr;
            objConstants_mstr_rec_1 = null;
            Constants_mstr_rec_1_Collection = null;
            objConstants_mstr_rec_2 = null;
            Constants_mstr_rec_2_Collection = null;

            // 	 ru701-work-file;
            objRu701_work_rec = null;
            Ru701_work_rec_Collection = null;
            // 	 sli-oma-code-suff-mstr;
            objSli_oma_code_suff_rec = null;
            Sli_oma_code_suff_rec_Collection = null;
            //          report-file.;
            objRpt_line = null;
            Rpt_line_Collection = null;
        }

        private async Task az0_99_exit()
        {
            Util.Trakker(++ctr, "az0_99_exit");

            //     exit.;
        }

        // db0_mod10_check_digit.rtn
        /*   private async Task db0_mod10_check_digit()
           {

               //     add  ws-chk-nbr-2;
               // 	 ws-chk-nbr-4;
               // 	 ws-chk-nbr-6			giving ws-temp.;

               ws_temp = ws_chk_nbr_2 + ws_chk_nbr_4 + ws_chk_nbr_6;

               //     add  ws-chk-nbr-1;
               // 	 ws-chk-nbr-1			giving ws-temp-2.;
               ws_temp_2 = ws_chk_nbr_1 + ws_chk_nbr_1;

               //     add  ws-temp-2a;
               // 	 ws-temp-2b			to ws-temp.;
               ws_temp = ws_temp_2a + ws_temp_2b;

               //     add  ws-chk-nbr-3;
               // 	 ws-chk-nbr-3			giving ws-temp-2.;
               ws_temp_2 = ws_chk_nbr_3 + ws_chk_nbr_3;

               //     add  ws-temp-2a;
               // 	 ws-temp-2b			to ws-temp.;
               ws_temp = ws_temp_2a + ws_temp_2b;

               //     add  ws-chk-nbr-5;
               // 	 ws-chk-nbr-5			giving ws-temp-2.;
               ws_temp_2 = ws_chk_nbr_5 + ws_chk_nbr_5;

               //     add  ws-temp-2a;
               // 	 ws-temp-2b			to ws-temp.;
               ws_temp = ws_temp_2a + ws_temp_2b;

               //     add  ws-chk-nbr-7;
               // 	 ws-chk-nbr-7			giving ws-temp-2.;
               ws_temp_2 = ws_chk_nbr_7 + ws_chk_nbr_7;

               //     add  ws-temp-2a;
               // 	 ws-temp-2b			to ws-temp.;
               ws_temp = ws_temp_2a + ws_temp_2b;

               //     divide   ws-temp    by  10		giving ws-temp-1.;
               ws_temp_1 = ws_temp / 10;

               //     multiply ws-temp-1  by  10		giving ws-temp-1.;
               ws_temp_1 = ws_temp_1 * 10;

               //     subtract ws-temp-1			from ws-temp.;
               ws_temp = ws_temp - ws_temp_1;

               //     subtract ws-temp			from 10;
               // 					giving ws-temp.;
               ws_temp = 10 - ws_temp;

               //  if  ws-temp  = ws-chk-nbr-8  or (    ws-temp      = 10 and ws-chk-nbr-8 =  0 ) then
               if (ws_temp == ws_chk_nbr_8 || (ws_temp == 10 && ws_chk_nbr_8 == 0))
               {
                   flag = "y";
               }
               else
               {
                   flag = "n";
               }
           } */

        private async Task db0_mod10_check_digit()
        {
            Util.Trakker(++ctr, "db0_mod10_check_digit");

            // add  ws-chk-nbr-2;
            // 	     ws-chk-nbr-4;
            // 	     ws-chk-nbr-6			giving ws-temp.;

            ws_temp = ws_chk_nbr_2 + ws_chk_nbr_4 + ws_chk_nbr_6;

            // add  ws-chk-nbr-1;
            // 	    ws-chk-nbr-1			giving ws-temp-2.;

            ws_temp_2 = ws_chk_nbr_1 + ws_chk_nbr_1;

            ws_temp_2a = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(0, 1));
            ws_temp_2b = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(1, 1));

            // add  ws-temp-2a;
            // 	    ws-temp-2b			to ws-temp.;

            ws_temp = ws_temp_2a + ws_temp_2b;

            // add  ws-chk-nbr-3;
            // 	    ws-chk-nbr-3			giving ws-temp-2.;
            ws_temp_2 = ws_chk_nbr_3 + ws_chk_nbr_3;

            ws_temp_2a = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(0, 1));
            ws_temp_2b = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(1, 1));

            // add  ws-temp-2a;
            // 	    ws-temp-2b			to ws-temp.;
            ws_temp = ws_temp_2a + ws_temp_2b;

            // add  ws-chk-nbr-5;
            // 	    ws-chk-nbr-5			giving ws-temp-2.;
            ws_temp_2 = ws_chk_nbr_5 + ws_chk_nbr_5;

            ws_temp_2a = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(0, 1));
            ws_temp_2b = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(1, 1));

            // add  ws-temp-2a;
            // 	    ws-temp-2b			to ws-temp.;
            ws_temp = ws_temp_2a + ws_temp_2b;

            // add  ws-chk-nbr-7;
            // 	    ws-chk-nbr-7			giving ws-temp-2.;
            ws_temp_2 = ws_chk_nbr_7 + ws_chk_nbr_7;

            ws_temp_2a = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(0, 1));
            ws_temp_2b = Util.NumInt(Util.Str(ws_temp_2).PadRight(2, '0').Substring(1, 1));

            // add  ws-temp-2a;
            // 	    ws-temp-2b			to ws-temp.;
            ws_temp = ws_temp_2a + ws_temp_2b;

            // divide   ws-temp    by  10		giving ws-temp-1.;
            ws_temp_1 = ws_temp / 10;

            // multiply ws-temp-1  by  10		giving ws-temp-1.;
            ws_temp_1 = ws_temp_1 * 10;

            //  subtract ws-temp-1			from ws-temp.;
            ws_temp = ws_temp - ws_temp_1;

            //  subtract ws-temp			from 10;
            // 					giving ws-temp.;
            ws_temp = 10 - ws_temp;

            // if ws-temp  = ws-chk-nbr-8 or ( ws-temp = 10   and ws-chk-nbr-8 =  0 )  then            
            if (ws_temp == ws_chk_nbr_8 || (ws_temp == 10 && ws_chk_nbr_8 == 0))
            {
                flag = "y";
            }
            else
            {
                flag = "n";
            }
        }

        // db0_mod10_check_digit.rtn
        private async Task db0_99_exit()
        {
            Util.Trakker(++ctr, "db0_99_exit");

            //     exit.;
        }

        // db0a_mod10_check_digit_10.rtn
        /*  private async Task db0a_mod10_check_digit_10()
          {

              //     add  ws-chk-nbr-2-10;
              // 	 ws-chk-nbr-4-10;
              // 	 ws-chk-nbr-6-10;
              // 	 ws-chk-nbr-8-10		giving ws-temp-10.;
              ws_temp_10 = ws_chk_nbr_2_10 + ws_chk_nbr_4_10 + ws_chk_nbr_6_10 + ws_chk_nbr_8_10;

              //     add  ws-chk-nbr-1-10;
              // 	 ws-chk-nbr-1-10		giving ws-temp-2-10.;
              ws_temp_2_10 = ws_chk_nbr_1_10 + ws_chk_nbr_1_10;

              //     add  ws-temp-2a-10;
              // 	 ws-temp-2b-10			to ws-temp-10.;
              ws_temp_10 = ws_temp_2a_10 + ws_temp_2b_10;

              //     add  ws-chk-nbr-3-10;
              // 	 ws-chk-nbr-3-10		giving ws-temp-2-10.;
              ws_temp_2_10 = ws_chk_nbr_3_10 + ws_chk_nbr_3_10;

              //     add  ws-temp-2a-10;
              // 	 ws-temp-2b-10			to ws-temp-10.;
              ws_temp_10 = ws_temp_2a_10 + ws_temp_2b_10;

              //     add  ws-chk-nbr-5-10;
              // 	 ws-chk-nbr-5-10		giving ws-temp-2-10.;
              ws_temp_2_10 = ws_chk_nbr_5_10 + ws_chk_nbr_5_10;

              //     add  ws-temp-2a-10;
              // 	 ws-temp-2b-10			to ws-temp-10.;
              ws_temp_10 = ws_temp_2a_10 + ws_temp_2b_10;

              //     add  ws-chk-nbr-7-10;
              // 	 ws-chk-nbr-7-10		giving ws-temp-2-10.;
              ws_temp_2_10 = ws_chk_nbr_7_10 + ws_chk_nbr_7_10;

              //     add  ws-temp-2a-10;
              // 	 ws-temp-2b-10			to ws-temp-10.;
              ws_temp_10 = ws_temp_2a_10 + ws_temp_2b_10;

              //     add  ws-chk-nbr-9-10;
              // 	 ws-chk-nbr-9-10		giving ws-temp-2-10.;
              ws_temp_2_10 = ws_chk_nbr_9_10 + ws_chk_nbr_9_10;

              //     add  ws-temp-2a-10;
              // 	 ws-temp-2b-10			to ws-temp-10.;
              ws_temp_10 = ws_temp_2a_10 + ws_temp_2b_10;

              //     divide   ws-temp-10 by  10		giving ws-temp-1-10.;
              ws_temp_1_10 = ws_temp_10 / 10;

              //     multiply ws-temp-1-10 by 10		giving ws-temp-1-10.;
              ws_temp_1_10 = ws_temp_1_10 * 10;

              //     subtract ws-temp-1-10		from ws-temp-10.;
              ws_temp_10 = ws_temp_10 - ws_temp_1_10;

              //     subtract ws-temp-10			from 10;
              // 					giving ws-temp-10.;
              ws_temp_10 = 10 - ws_temp_10;

              //  if  ws-temp-10   = ws-chk-nbr-10-10 or (    ws-temp-10   = 10 and ws-chk-nbr-10-10 =  0 ) then 
              if (ws_temp_10 == ws_chk_nbr_10_10 || (ws_temp_10 == 10 && ws_chk_nbr_10_10 == 0))
              {
                  flag = "Y";
              }
              else
              {
                  flag = "N";
              }
          } */

        private async Task db0a_mod10_check_digit_10()
        {
            Util.Trakker(++ctr, "db0a_mod10_check_digit_10");

            //  add  ws-chk-nbr-2-10;
            // 	 ws-chk-nbr-4-10;
            // 	 ws-chk-nbr-6-10;
            // 	 ws-chk-nbr-8-10		giving ws-temp-10.;

            ws_chk_nbr_1_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(0, 1));
            ws_chk_nbr_2_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(1, 1));
            ws_chk_nbr_3_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(2, 1));
            ws_chk_nbr_4_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(3, 1));
            ws_chk_nbr_5_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(4, 1));
            ws_chk_nbr_6_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(5, 1));
            ws_chk_nbr_7_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(6, 1));
            ws_chk_nbr_8_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(7, 1));
            ws_chk_nbr_9_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(8, 1));
            ws_chk_nbr_10_10 = Util.NumInt(ws_chk_nbr_10.ToString().Substring(9, 1));

            ws_temp_10 = ws_chk_nbr_2_10 + ws_chk_nbr_4_10 + ws_chk_nbr_6_10 + ws_chk_nbr_8_10;

            //  add ws-chk-nbr-1-10;
            // 	    ws-chk-nbr-1-10		giving ws-temp-2-10.;
            ws_temp_2_10 = ws_chk_nbr_1_10 + ws_chk_nbr_1_10;

            ws_temp_2a_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 0, 1));

            if (ws_temp_2_10 > 9)
            {
                ws_temp_2b_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 1, 1));
            }
            else
            {
                ws_temp_2b_10 = 0;
            }

            //  add  ws-temp-2a-10;
            // 	     ws-temp-2b-10			to ws-temp-10.;
            ws_temp_10 += ws_temp_2a_10 + ws_temp_2b_10;

            //  add  ws-chk-nbr-3-10;
            // 	     ws-chk-nbr-3-10		giving ws-temp-2-10.;
            ws_temp_2_10 = ws_chk_nbr_3_10 + ws_chk_nbr_3_10;

            ws_temp_2a_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 0, 1));

            if (ws_temp_2_10 > 9)
            {
                ws_temp_2b_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 1, 1));
            }
            else
            {
                ws_temp_2b_10 = 0;
            }

            // add  ws-temp-2a-10;
            // 	    ws-temp-2b-10			to ws-temp-10.;
            ws_temp_10 += ws_temp_2a_10 + ws_temp_2b_10;

            // add  ws-chk-nbr-5-10;
            // 	    ws-chk-nbr-5-10		giving ws-temp-2-10.;
            ws_temp_2_10 = ws_chk_nbr_5_10 + ws_chk_nbr_5_10;

            ws_temp_2a_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 0, 1));

            if (ws_temp_2_10 > 9)
            {
                ws_temp_2b_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 1, 1));
            }
            else
            {
                ws_temp_2b_10 = 0;
            }

            // add  ws-temp-2a-10;
            // 	    ws-temp-2b-10			to ws-temp-10.;
            ws_temp_10 += ws_temp_2a_10 + ws_temp_2b_10;

            // add  ws-chk-nbr-7-10;
            // 	    ws-chk-nbr-7-10		giving ws-temp-2-10.;
            ws_temp_2_10 = ws_chk_nbr_7_10 + ws_chk_nbr_7_10;

            ws_temp_2a_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 0, 1));

            if (ws_temp_2_10 > 9)
            {
                ws_temp_2b_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 1, 1));
            }
            else
            {
                ws_temp_2b_10 = 0;
            }

            // add  ws-temp-2a-10;
            // 	    ws-temp-2b-10			to ws-temp-10.;
            ws_temp_10 += ws_temp_2a_10 + ws_temp_2b_10;

            // add  ws-chk-nbr-9-10;
            // 	    ws-chk-nbr-9-10		giving ws-temp-2-10.;
            ws_temp_2_10 = ws_chk_nbr_9_10 + ws_chk_nbr_9_10;

            ws_temp_2a_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 0, 1));

            if (ws_temp_2_10 > 9)
            {
                ws_temp_2b_10 = Util.NumInt(Util.Substring(Util.Str(ws_temp_2_10), 1, 1));
            }
            else
            {
                ws_temp_2b_10 = 0;
            }

            // add  ws-temp-2a-10;
            // 	    ws-temp-2b-10			to ws-temp-10.;
            ws_temp_10 += ws_temp_2a_10 + ws_temp_2b_10;

            // divide   ws-temp-10 by  10		giving ws-temp-1-10.;
            ws_temp_1_10 = ws_temp_10 / 10;

            // multiply ws-temp-1-10 by 10		giving ws-temp-1-10.;
            ws_temp_1_10 = ws_temp_1_10 * 10;

            // subtract ws-temp-1-10		from ws-temp-10.;
            ws_temp_10 = ws_temp_10 - ws_temp_1_10;

            // subtract ws-temp-10			from 10;
            // 					giving ws-temp-10.;
            ws_temp_10 = 10 - ws_temp_10;

            // if ws-temp-10  = ws-chk-nbr-10-10 or (    ws-temp-10   = 10   and ws-chk-nbr-10-10 =  0 )  then            
            if (ws_temp_10 == ws_chk_nbr_10_10 || (ws_temp_10 == 10 && ws_chk_nbr_10_10 == 0))
            {
                flag = "Y";
            }
            else
            {
                flag = "N";
            }
        }

        // db0a_mod10_check_digit_10.rtn
        private async Task db0a_99_exit()
        {
            Util.Trakker(++ctr, "db0a_99_exit");

            //     exit.;
        }

        // dc0_mod10_check_digit_alt.rtn
        private async Task dc0_mod10_check_digit_for_1_2()
        {
            Util.Trakker(++ctr, "dc0_mod10_check_digit_for_1_2");

            //     go to dc0-98-exit.;
            await dc0_98_exit();
            return;

            //ws_temp = 0;
            //ws_temp_1 = 0;
            //ws_temp_2 = 0;
            // 					   ws-temp-1;
            // 					   ws-temp-2.;
            //     add  ws-chk-nbr-2;
            // 	 ws-chk-nbr-4;
            // 	 ws-chk-nbr-6			giving ws-temp.;
            //     add  ws-chk-nbr-1;
            // 	 ws-chk-nbr-1			giving ws-temp-2.;
            //     add  ws-temp-2a			to ws-temp-1.;
            //     add  ws-temp-2b			to ws-temp.;
            //     add  ws-chk-nbr-3;
            // 	 ws-chk-nbr-3			giving ws-temp-2.;
            //     add  ws-temp-2a			to ws-temp-1.;
            //     add	 ws-temp-2b			to ws-temp.;
            //     add  ws-chk-nbr-5;
            // 	 ws-chk-nbr-5			giving ws-temp-2.;
            //     add  ws-temp-2a			to ws-temp-1.;
            //     add	 ws-temp-2b			to ws-temp.;
            //     add  ws-chk-nbr-7;
            // 	 ws-chk-nbr-7			giving ws-temp-2.;
            //     add  ws-temp-2a			to ws-temp-1.;
            //     add	 ws-temp-2b			to ws-temp.;
            //   ws_temp_2 = ws_temp;
            //     add  ws-temp-2b			to ws-temp-1.;
            //     subtract ws-temp-1			from 10;
            // 					giving ws-temp.;
            //     if        ws-temp      = ws-chk-nbr-8;
            //     then;
            //flag = "Y";
            //     else;
            //flag = "N";
        }

        // dc0_mod10_check_digit_alt.rtn
        private async Task dc0_98_exit()
        {
            Util.Trakker(++ctr, "dc0_98_exit");

            flag = "Y";
        }

        // dc0_mod10_check_digit_alt.rtn
        private async Task dc0_99_exit()
        {
            Util.Trakker(++ctr, "dc0_99_exit");

            //     exit.;
        }

        private async Task ea0_proc_rec_type_batch()
        {
            Util.Trakker(++ctr, "ea0_proc_rec_type_batch");

            //     perform xx0-process-hold-dtls	thru xx0-99-exit.;
            await xx0_process_hold_dtls();
            await xx0_99_exit();

            //objSuspend_hdr_rec.clmhdr_pat_acronym = "";
            objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM6 = "";
            objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM3 = "";

            hdr_accounting_nbr = "";
            hold_accounting_nbr = "";

            //counters = 0;
            ctr_read_const_mstr = 0;
            ctr_diskout_writes = 0;
            ctr_suspend_hdr_writes = 0;
            ctr_suspend_dtl_writes = 0;
            ctr_suspend_desc_writes = 0;
            ctr_suspend_addr_writes = 0;
            ctr_recs_read = 0;
            ctr_b_recs_read_skipped = 0;
            ctr_h_recs_read_skipped = 0;
            ctr_r_recs_read_skipped = 0;
            ctr_t_recs_read_skipped = 0;
            ctr_a_recs_read_skipped = 0;
            ctr_e_recs_read_skipped = 0;
            ctr_b_recs_read = 0;
            ctr_h_recs_read = 0;
            ctr_r_recs_read = 0;
            ctr_t_recs_read = 0;
            ctr_a_recs_read = 0;
            ctr_e_recs_read = 0;
            ctr_h_recs_skipped = 0;
            ctr_r_recs_skipped = 0;
            ctr_t_recs_skipped = 0;
            ctr_a_recs_skipped = 0;
            ctr_tot_b_recs = 0;
            ctr_tot_h_recs = 0;
            ctr_tot_r_recs = 0;
            ctr_tot_t_recs = 0;
            ctr_tot_a_recs = 0;
            ctr_tot_dollars_read = 0;
            ctr_tot_dollars_oma = 0;
            ctr_tot_dollars_ohip = 0;
            ctr_tot_tech_claim = 0;
            ctr_tot_svcs_read = 0;
            ctr_hdr2_rec = 0;
            ctr_addr_rec = 0;

            ctr_b_recs_read = 1;
            ctr_recs_read = 1;

            batch_dist_cd = Util.Str(objUnpriced_claims_record.Unpriced_moh_code);
            
            objUnpriced_claims_record.Unpriced_bathdr_batch_nbr_grp = Util.Str(objUnpriced_claims_record.Unpriced_bathdr_batch_nbr_date).PadLeft(8, '0') + Util.Str(objUnpriced_claims_record.Unpriced_bathdr_batch_nbr_seq).PadLeft(4, '0');

            batch_identifier = objUnpriced_claims_record.Unpriced_bathdr_batch_nbr_grp;
            batch_group_nbr = Util.Str(objUnpriced_claims_record.Unpriced_bathdr_fac_no);
            batch_provider_nbr = Util.NumInt(objUnpriced_claims_record.Unpriced_bathdr_prov_ohip_no);
            batch_specialty = Util.NumInt(objUnpriced_claims_record.Unpriced_bathdr_spec_cd);
            batch_pay_type = 0;

            //  if unpriced-bathdr-clinic-1-2 = 85  then
            if (Util.NumInt(objUnpriced_claims_record.Unpriced_bathdr_clinic_1_2) == 85)
            {
                ws_default_payroll_flag = "B";
            }
            else
            {
                ws_default_payroll_flag = "A";
            }

            // if unpriced-default-batch-loc not = " " then
            if (!string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_default_batch_loc))
            {
                ws_default_batch_location = Util.Str(objUnpriced_claims_record.Unpriced_default_batch_loc);
            }
            else
            {
                ws_default_batch_location = "";
            }

            // if unpriced-default-batch-i-o-ind not = " " then
            if (!string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_default_batch_i_o_ind))
            {
                ws_default_batch_i_o_ind = Util.Str(objUnpriced_claims_record.Unpriced_default_batch_i_o_ind);
            }
            else
            {
                ws_default_batch_i_o_ind = "";
            }

            //     perform ea10-determine-clinic-nbr   thru    ea10-99-exit.;
            await ea10_determine_clinic_nbr();
            await ea10_99_exit();

            //  if fatal-error then 
            if (fatal_error_flag.Equals(fatal_error))
            {
                //         go to ea0-99-exit.;
                await ea0_99_exit();
                return;
            }

            //     objDoc_mstr_rec.doc_nbr = objUnpriced_claims_record.unpriced_bathdr_doc_nbr;
            objDoc_mstr_rec.DOC_NBR = Util.Str(objUnpriced_claims_record.Unpriced_bathdr_doc_nbr);

            //     perform tb0-read-doc                thru    tb0-99-exit.;
            await tb0_read_doc();
            await tb0_99_exit();


            //     if doc-found then 
            if (Util.Str(flag_doc).Equals(doc_found))
            {
                //         perform ea11-check-doctor-specialty    thru    ea11-99-exit;
                await ea11_check_doctor_specialty();
                await ea11_99_exit();
                //         perform ea12-check-dept-no              thru    ea12-99-exit;
                await ea12_check_dept_no();
                await ea12_99_exit();

                //         perform ea13-check-provider-nbr         thru    ea13-99-exit;
                await ea13_check_provider_nbr();
                await ea13_99_exit();
                //         perform ea14-check-doctor-clinic        thru    ea14-99-exit;
                await ea14_check_doctor_clinic();
                await ea14_99_exit();
            }
            else
            {
                fatal_error_flag = "Y";
                ws_carriage_ctrl = 2;
                err_ind = 2;
                err_warn_msg = ws_error_literal;
                err_msg_doc_nbr = Util.Str(objUnpriced_claims_record.Unpriced_bathdr_doc_nbr);
                //         perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.;            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task ea0_99_exit()
        {
            Util.Trakker(++ctr, "ea0_99_exit");

            //     exit.;
        }

        private async Task ea10_determine_clinic_nbr()
        {
            Util.Trakker(++ctr, "ea10_determine_clinic_nbr");

            flag_clinic = "N";

            //     perform ea10a-search-clinic-tbl     thru ea10a-99-exit;
            //         varying sub;
            //         from   1;
            //         by     1;
            //         until   sub > const-max-nbr-clinics;
            //              or clinic-found.;

            sub = 1;
            do
            {
                await ea10a_search_clinic_tbl();
                await ea10a_99_exit();
                sub++;
            } while (sub <= Util.NumInt(objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS) && !Util.Str(flag_clinic).Equals(clinic_found));


            // if  clinic-not-found  and ws-default-clinic-nbr = 00 then  
            if (Util.Str(flag_clinic).Equals(clinic_not_found) && ws_default_clinic_nbr == 0)
            {
                fatal_error_flag = "Y";
                ws_carriage_ctrl = 2;
                err_ind = 6;
                err_warn_msg = ws_error_literal;
                err_msg_clinic_id = batch_group_nbr;
                //        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
            // else if  clinic-not-found and ws-default-clinic-nbr not = 00  then
            else if (Util.Str(flag_clinic).Equals(clinic_not_found) && ws_default_clinic_nbr != 0)
            {
                objUnpriced_claims_record.Unpriced_bathdr_clinic_1_2 = ws_default_clinic_nbr;
                bt_clinic_nbr_1_2 = ws_default_clinic_nbr;
                batch_group_nbr = Util.Str(ws_default_clinic_nbr);
            }
        }

        private async Task ea10_99_exit()
        {
            Util.Trakker(++ctr, "ea10_99_exit");

            //     exit.;
        }

        private async Task ea10a_search_clinic_tbl()
        {
            Util.Trakker(++ctr, "ea10a_search_clinic_tbl");

            //  if unpriced-bathdr-clinic-1-2 = const-clinic-nbr-1-2 (sub)  then            
            if (objUnpriced_claims_record.Unpriced_bathdr_clinic_1_2 == CONST_CLINIC_NBR_1_2(objConstants_mstr_rec_1, sub))
            {
                bt_clinic_nbr_1_2 = CONST_CLINIC_NBR_1_2(objConstants_mstr_rec_1, sub);
                batch_group_nbr = Util.Str(CONST_CLINIC_NBR(objConstants_mstr_rec_1, sub));
                flag_clinic = "Y";
            }
        }

        private async Task ea10a_99_exit()
        {
            Util.Trakker(++ctr, "ea10a_99_exit");

            //     exit.;
        }

        private async Task ea11_check_doctor_specialty()
        {
            Util.Trakker(++ctr, "ea11_check_doctor_specialty");

            // if  batch-specialty not = doc-spec-cd and batch-specialty not = doc-spec-cd-2 and batch-specialty not = doc-spec-cd-3 and not price-only-claim  then 
            if (batch_specialty != Util.NumInt(objDoc_mstr_rec.DOC_SPEC_CD) && batch_specialty != Util.NumInt(objDoc_mstr_rec.DOC_SPEC_CD_2) && batch_specialty != Util.NumInt(objDoc_mstr_rec.DOC_SPEC_CD_3) && !flag_claim_source.Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 4;
                err_msg_batch_spec_cd = Util.Str(batch_specialty);
                //    perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 5;
                err_msg_doc_spec_cd = Util.Str(objDoc_mstr_rec.DOC_SPEC_CD);
                err_msg_doc_spec_cd_2 = Util.Str(objDoc_mstr_rec.DOC_SPEC_CD_2);
                err_msg_doc_spec_cd_3 = Util.Str(objDoc_mstr_rec.DOC_SPEC_CD_3);
                //      perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task ea11_99_exit()
        {
            Util.Trakker(++ctr, "ea11_99_exit");

            //     exit.;
        }

        private async Task ea12_check_dept_no()
        {
            Util.Trakker(++ctr, "ea12_check_dept_no");

            //  if  unpriced-bathdr-dept  not = doc-dept and not price-only-claim then 
            if (Util.NumInt(objUnpriced_claims_record.Unpriced_bathdr_dept) != Util.NumInt(objDoc_mstr_rec.DOC_DEPT) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 32;
                err_msg_batch_dept_no = Util.Str(objUnpriced_claims_record.Unpriced_bathdr_dept);
                //         perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 33;
                err_msg_doc_dept_no = Util.Str(objDoc_mstr_rec.DOC_DEPT);
                //         perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task ea12_99_exit()
        {
            Util.Trakker(++ctr, "ea12_99_exit");

            //     exit.;
        }

        private async Task ea13_check_provider_nbr()
        {
            Util.Trakker(++ctr, "ea13_check_provider_nbr");

            //  if  unpriced-bathdr-prov-ohip-no   not = doc-pract-nbr and not price-only-claim  then            
            if (Util.NumInt(objUnpriced_claims_record.Unpriced_bathdr_prov_ohip_no) != Util.NumInt(objDoc_mstr_rec.DOC_OHIP_NBR) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 35;
                err_msg_batch_prov_nbr = Util.Str(objUnpriced_claims_record.Unpriced_bathdr_prov_ohip_no);
                //    perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 36;
                err_msg_doc_prov_nbr = Util.Str(objDoc_mstr_rec.DOC_OHIP_NBR);  //doc_pract_nbr;
                //         perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task ea13_99_exit()
        {
            Util.Trakker(++ctr, "ea13_99_exit");

            //     exit.;
        }

        private async Task ea14_check_doctor_clinic()
        {
            Util.Trakker(++ctr, "ea14_check_doctor_clinic");

            flag_doc_clinic = "Y";

            F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection = new F020C_DOC_CLINIC_NEXT_BATCH_NBR
            {
                WhereDoc_nbr = objDoc_mstr_rec.DOC_NBR
            }.Collection();



            //  if  bt-clinic-nbr-1-2 not = doc-clinic-nbr and bt-clinic-nbr-1-2 not = doc-clinic-nbr-2            
            if (bt_clinic_nbr_1_2 != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[0].DOC_CLINIC_NBR) && bt_clinic_nbr_1_2 != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[1].DOC_CLINIC_NBR)
                //      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-3 and bt-clinic-nbr-1-2 not = doc-clinic-nbr-4;    
                && bt_clinic_nbr_1_2 != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[2].DOC_CLINIC_NBR) && bt_clinic_nbr_1_2 != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[3].DOC_CLINIC_NBR)
                //      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-5 and bt-clinic-nbr-1-2 not = doc-clinic-nbr-6            
                && bt_clinic_nbr_1_2 != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[4].DOC_CLINIC_NBR) && bt_clinic_nbr_1_2 != Util.NumInt(F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection[5].DOC_CLINIC_NBR)
                //      and not price-only-claim then            
                && !flag_claim_source.Equals(price_only_claim)
        )
            {

                err_warn_msg = ws_error_literal;
                //         perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();

                ws_carriage_ctrl = 1;
                err_ind = 57;
                err_msg_doc_clinic = bt_clinic_nbr_1_2;
                flag_doc_clinic = "N";
                //         perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task ea14_99_exit()
        {
            Util.Trakker(++ctr, "ea14_99_exit");

            //     exit.;
        }

        private async Task fa0_proc_rec_type_header1()
        {
            Util.Trakker(++ctr, "fa0_proc_rec_type_header1");

            //     perform xx0-process-hold-dtls	thru xx0-99-exit.;
            await xx0_process_hold_dtls();
            await xx0_99_exit();

            skip_process_this_acct_id_flag = "N";

            //   perform fb0-build-susp-hdr-rec      thru fb0-99-exit.;
            await fb0_build_susp_hdr_rec();
            await fb0_99_exit();

            //  if skip-processing-this-acct-id then 
            if (Util.Str(skip_process_this_acct_id_flag).Equals(skip_processing_this_acct_id))
            {
                //         go to fa0-99-exit.;
                await fa0_99_exit();
                return;
            }

            //     perform fd0-build-susp-addr-rec-hdr1 thru    fd0-99-exit.
            await fd0_build_susp_addr_rec_hdr1();
            await fd0_99_exit();

            ctr_hdr2_rec = 0;
            ctr_addr_rec = 0;
        }

        private async Task fa0_99_exit()
        {
            Util.Trakker(++ctr, "fa0_99_exit");

            //     exit.;
        }

        private async Task fb0_build_susp_hdr_rec()
        {
            Util.Trakker(++ctr, "fb0_build_susp_hdr_rec");

            // if last-record-is-h or detail-written then
            if (Util.Str(last_record_type_flag).Equals(last_record_is_h) || Util.Str(detail_written_flag).Equals(detail_written))
            {
                detail_written_flag = "N";
                //     perform tf0-write-addr-rec      thru tf0-99-exit.;
                await tf0_write_addr_rec();
                await tf0_99_exit();
            }

            //header_rec = "";
            await Initialize_Header_Rec();

            hdr_birth_date = 0;
            hdr_birth_date_dd = 0;
            hdr_refer_pract_nbr = 0;
            hdr_admit_yy = "0";
            hdr_admit_mm = 0;
            hdr_admit_dd = 0;

            //objSuspend_hdr_rec.suspend_hdr_rec = "";
            objSuspend_hdr_rec = new F002_SUSPEND_HDR();

            //objSuspend_hdr_rec.clmhdr_batch_nbr = 0;
            objSuspend_hdr_rec.CLMHDR_BATCH_NBR = "00" + Util.Str(objDoc_mstr_rec.DOC_NBR) + "000";

            objUnpriced_claims_record.Unpriced_clmhdr_claim_grp = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_doc_nbr).PadRight(3) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_wk).PadRight(2) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_day).PadRight(1) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_claim_nbr).PadRight(2);
            hold_accounting_nbr = objUnpriced_claims_record.Unpriced_clmhdr_claim_grp; //  Unpriced_clmhdr_claim;

            hdr_accounting_nbr = objUnpriced_claims_record.Unpriced_clmhdr_claim_grp;

            objSuspend_hdr_rec.CLMHDR_DOC_NBR = Util.Str(objDoc_mstr_rec.DOC_NBR);

            hdr_health_care_nbr = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_health_nbr);

            //// if unpriced-clmhdr-birth-date = spaces  then
             objUnpriced_claims_record.Unpriced_clmhdr_birth_date_grp = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_birth_date_yy).PadLeft(4,'0') + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_birth_date_mm).PadLeft(2,'0') + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_birth_date_dd).PadLeft(2,'0');
            if (string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_clmhdr_birth_date_grp) || Util.NumInt(objUnpriced_claims_record.Unpriced_clmhdr_birth_date_grp) == 0) {
                    hdr_birth_date_long_grp = "0";
                    hdr_birth_date = 0;
                    hdr_birth_date_dd = 0;
            }
            else {
                   hdr_birth_date_long_grp = objUnpriced_claims_record.Unpriced_clmhdr_birth_date_grp;
                hdr_birth_date = Util.NumInt(Util.Str(hdr_birth_date_long_grp).PadRight(8).Substring(0, 6));
                hdr_birth_date_dd = Util.NumInt(Util.Str(hdr_birth_date_long_grp).PadRight(8).Substring(6, 2));
            }

            //     inspect unpriced-clmhdr-ref-doc-nbr replacing all space-char by zeros.;
            objUnpriced_claims_record.Unpriced_clmhdr_ref_doc_nbr = Util.NumInt(Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_ref_doc_nbr).Replace(' ', '0'));

            // if unpriced-clmhdr-ref-doc-nbr = spaces then
            if (string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_clmhdr_ref_doc_nbr.ToString()) || Util.NumInt(objUnpriced_claims_record.Unpriced_clmhdr_ref_doc_nbr) == 0)
            {
                hdr_refer_pract_nbr = 0;
            }
            else
            {
                hdr_refer_pract_nbr = objUnpriced_claims_record.Unpriced_clmhdr_ref_doc_nbr;
            }

            hdr_hosp_nbr = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_hosp_nbr);
            hdr_manual_review = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_man_review);

            // if unpriced-clmhdr-admit-date = spaces then  
             objUnpriced_claims_record.Unpriced_clmhdr_admit_date_grp = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_admit_date_yy).PadRight(4,'0') + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_admit_date_mm).PadRight(2,'0') + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_admit_date_dd).PadRight(2,'0');
            if (string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_clmhdr_admit_date_grp) || Util.NumInt(objUnpriced_claims_record.Unpriced_clmhdr_admit_date_grp) == 0) {
                     hdr_admit_date_grp = "0";
                     hdr_admit_yy = "0";
                     hdr_admit_mm = 0;
                     hdr_admit_dd = 0;
            }
            else {
                      hdr_admit_date_grp = objUnpriced_claims_record.Unpriced_clmhdr_admit_date_grp;
                      hdr_admit_yy = Util.Str(hdr_admit_date_grp).PadRight(8).Substring(0, 4);
                      hdr_admit_mm = Util.NumInt(Util.Str(hdr_admit_date_grp).PadRight(8).Substring(4, 2));
                      hdr_admit_dd = Util.NumInt(Util.Str(hdr_admit_date_grp).PadRight(8).Substring(6, 2));
            }

            hdr_health_care_ver = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_version_cd);

            //   objSuspend_hdr_rec.clmhdr_zeroed_oma_suff_adj = 0;
            objSuspend_hdr_rec.CLMHDR_ADJ_OMA_CD = "0";
            objSuspend_hdr_rec.CLMHDR_ADJ_OMA_SUFF = "0";
            objSuspend_hdr_rec.CLMHDR_ADJ_ADJ_NBRF = "0";

            objSuspend_hdr_rec.CLMHDR_BATCH_TYPE = "C";

            objSuspend_hdr_rec.CLMHDR_ADJ_CD_SUB_TYPE = Util.Str(flag_claim_source);

            //  if invalid-doc-clinic then 
            if (Util.Str(flag_doc_clinic).Equals(invalid_doc_clinic))
            {
                objSuspend_hdr_rec.CLMHDR_CLINIC_NBR_1_2 = 00;
            }
            else
            {
                objSuspend_hdr_rec.CLMHDR_CLINIC_NBR_1_2 = bt_clinic_nbr_1_2;
            }

            objSuspend_hdr_rec.CLMHDR_DOC_NBR_OHIP = batch_provider_nbr;
            objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD = batch_specialty;

            //  if hdr-refer-pract-nbr not = spaces and not = zeros then            
            if (!string.IsNullOrWhiteSpace(hdr_refer_pract_nbr.ToString()) && hdr_refer_pract_nbr != 0)
            {
                //     perform fb02-verify-referring-phys-nbr thru    fb02-99-exit   
                await fb02_verify_referring_phys_nbr();
                await fb02_99_exit();

                objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR = hdr_refer_pract_nbr;
            }

            //  if  hdr-refer-pract-nbr = 0  and (    bt-clinic-nbr-1-2 >= 61 and bt-clinic-nbr-1-2 <= 66   )  then 
            if (hdr_refer_pract_nbr == 0 && (bt_clinic_nbr_1_2 >= 61 && bt_clinic_nbr_1_2 <= 66))
            {
                objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR = batch_provider_nbr;
            }

            //  if  hdr-refer-pract-nbr = 0 and (    bt-clinic-nbr-1-2 >= 71 and bt-clinic-nbr-1-2 <= 75 ) then 
            if (hdr_refer_pract_nbr == 0 && (bt_clinic_nbr_1_2 >= 71 && bt_clinic_nbr_1_2 <= 75))
            {
                objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR = batch_provider_nbr;
            }

            //  if ws-agent-default-reply = "Y" then            
            if (Util.Str(ws_agent_default_reply).ToUpper() == "Y")
            {
                objSuspend_hdr_rec.CLMHDR_TAPE_SUBMIT_IND = "Y";
                objSuspend_hdr_rec.CLMHDR_AGENT_CD = 0;
                hdr_agent_cd = "0";
            }


            objSuspend_hdr_rec.CLMHDR_ADJ_CD = "";
            objSuspend_hdr_rec.CLMHDR_STATUS_OHIP = "0";
            objSuspend_hdr_rec.CLMHDR_REFERENCE = "";

            //  if  (   hdr-loc-code = ws-4-nulls  or hdr-loc-code = spaces)   and ws-default-batch-location not = spaces  then  
            hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
            if ((hdr_loc_code_grp == ws_4_nulls || string.IsNullOrWhiteSpace(hdr_loc_code_grp)) && !string.IsNullOrWhiteSpace(ws_default_batch_location))
            {
                objSuspend_hdr_rec.CLMHDR_LOC = Util.Str(ws_default_batch_location);
            }

            //  if  (   hdr-i-o-ind = ws-1-null or hdr-i-o-ind = spaces) and ws-default-batch-i-o-ind not = spaces then 
            if ((hdr_i_o_ind == ws_1_null || string.IsNullOrWhiteSpace(hdr_i_o_ind)) && !string.IsNullOrWhiteSpace(ws_default_batch_i_o_ind))
            {
                objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND = ws_default_batch_i_o_ind;
            }

            // if hdr-admit-date not = spaces and not = zeros then            
            if (!string.IsNullOrWhiteSpace(hdr_admit_date_grp) && hdr_admit_date_grp != "0")
            {
                ws_date_yy = Util.NumInt(hdr_admit_yy);
                ws_date_mm = hdr_admit_mm;
                ws_date_dd = hdr_admit_dd;
                //        perform xd0-verify-date thru    xd0-99-exit;
                await xd0_verify_date();
                await xd0_99_exit();
                //        if   invalid-date and not price-only-claim then            
                if (Util.Str(flag_date).Equals(invalid_date) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //          perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 26;
                    hdr_admit_date_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
                    err_admit_date = hdr_admit_date_grp;
                    //              perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
                    //             objSuspend_hdr_rec.clmhdr_date_admit_yy = hdr_admit_yy;
                    //             objSuspend_hdr_rec.clmhdr_date_admit_mm = hdr_admit_mm;
                    //             objSuspend_hdr_rec.clmhdr_date_admit_dd = hdr_admit_dd;
                    objSuspend_hdr_rec.CLMHDR_DATE_ADMIT = Util.Str(hdr_admit_yy).PadLeft(4,'0') + Util.Str(hdr_admit_mm).PadLeft(2,'0') + Util.Str(hdr_admit_dd).PadLeft(2,'0');
                
            }

            //  if hdr-admit-date not = spaces and not = zeros then             
            if (!string.IsNullOrWhiteSpace(hdr_admit_date_grp) && hdr_admit_date_grp != "0")
            {
                //  if  hdr-admit-date < hdr-birth-date-long and not price-only-claim then         
                hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
                if (Util.Str(hdr_admit_date_grp).CompareTo(hdr_birth_date_long_grp) < 0 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //          perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 58;
                    err_58_admit_date = hdr_admit_date_grp;
                    hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
                    err_58_birth_date = hdr_birth_date_long_grp;
                    //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_DATE_ADMIT = "????????";
                }
            }


            objSuspend_hdr_rec.CLMHDR_DATE_SYS = Util.Str(sys_date_long_child);
            objSuspend_hdr_rec.CLMHDR_DOC_DEPT = objDoc_mstr_rec.DOC_DEPT;
            objSuspend_hdr_rec.CLMHDR_CURR_PAYMENT = 0;
            objSuspend_hdr_rec.CLMHDR_AMT_TECH_BILLED = 0;
            objSuspend_hdr_rec.CLMHDR_AMT_TECH_PAID = 0;


            //  if hdr-health-care-nbr not = spaces and not = zeros  then 
            if (!string.IsNullOrWhiteSpace(hdr_health_care_nbr) && hdr_health_care_nbr != "0")
            {
                objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = hdr_health_care_nbr;
                objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_health_care_nbr;
                objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
            }

            objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_VER = hdr_health_care_ver;

            // if  hdr-manual-review =  spaces or 'Y' or 'N' then 
            if (string.IsNullOrWhiteSpace(hdr_manual_review) || Util.Str(hdr_manual_review).ToUpper() == "Y" || Util.Str(hdr_manual_review).ToUpper() == "N")
            {
                objSuspend_hdr_rec.CLMHDR_RELATIONSHIP = hdr_manual_review;
            }
            // else if not price-only-claim then            
            else if (!Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_warning_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 31;
                err_manual_review = hdr_manual_review;
                //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                objSuspend_hdr_rec.CLMHDR_RELATIONSHIP = hdr_manual_review;
            }


            // objSuspend_hdr_rec.clmhdr_doc_pract_nbr = objDoc_mstr_rec.doc_pract_nbr;
            objSuspend_hdr_rec.CLMHDR_DOC_OHIP_NBR = objDoc_mstr_rec.DOC_OHIP_NBR;
            //objSuspend_hdr_rec.clmhdr_accounting_nbr = hdr_accounting_nbr;
            objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR = hdr_accounting_nbr;

            objSuspend_hdr_rec.SUSP_HDR_DOC_NBR = objSuspend_hdr_rec.CLMHDR_DOC_NBR;
            objSuspend_hdr_rec.SUSP_HDR_CLINIC_NBR = bt_clinic_nbr_1_2;
            objSuspend_hdr_rec.SUSP_HDR_ACCOUNTING_NBR = hold_accounting_nbr;
            objSuspend_hdr_rec.DEBUG_INFO = string.Empty.PadRight(512, ' ');
            objSuspend_hdr_rec.ERROR_FLAG = 0;
            objSuspend_hdr_rec.INPUT_FILE_LOCATION = string.Empty.PadRight(256, ' ');
        }

        private async Task fb0_99_exit()
        {
            Util.Trakker(++ctr, "fb0_99_exit");

            //     exit.;
        }

        private async Task fb0a_search_province()
        {
            Util.Trakker(++ctr, "fb0a_search_province");

            //if hdr-health-care-prov = prov(sub) then 
            if (hdr_health_care_prov == prov[sub])
            {
                province_flag = "Y";
            }
        }

        private async Task fb0a_99_exit()
        {
            Util.Trakker(++ctr, "fb0a_99_exit");

            //     exit.;
        }

        private async Task fb02_verify_referring_phys_nbr()
        {
            Util.Trakker(++ctr, "fb02_verify_referring_phys_nbr");

            ws_chk_nbr = hdr_refer_pract_nbr;

            // if  ws-chk-nbr-8   = 1 or  ws-chk-nbr-8   = 2   then
            if (ws_chk_nbr_8 == 1 || ws_chk_nbr_8 == 2)
            {
                //    perform dc0-mod10-check-digit-for-1-2 thru dc0-99-exit;
                await dc0_mod10_check_digit_for_1_2();
                await dc0_98_exit();
            }
            else
            {
                //     perform db0-mod10-check-digit  thru    db0-99-exit.;
                await db0_mod10_check_digit();
                await db0_99_exit();
            }

            flag_refer_phys = flag;

            // if invalid-refer-phys and not price-only-claim then
            if (Util.Str(flag_refer_phys).Equals(invalid_refer_phys) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 12;
                err_refer_phys_nbr = Util.Str(hdr_refer_pract_nbr);
                //   perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  hdr-refer-pract-nbr = batch-provider-nbr and (   bt-clinic-nbr-1-2 < 60 or bt-clinic-nbr-1-2 > 75 ) and not price-only-claim  then            
            if (hdr_refer_pract_nbr == batch_provider_nbr && (bt_clinic_nbr_1_2 < 60 || bt_clinic_nbr_1_2 > 75) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 47;
                err_msg_referring_doc = Util.Str(hdr_refer_pract_nbr);
                err_msg_provider_doc = Util.Str(batch_provider_nbr);
                //     perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task fb02_99_exit()
        {
            Util.Trakker(++ctr, "fb02_99_exit");

            //     exit.;
        }

        private async Task fb03_verify_diag_code()
        {
            Util.Trakker(++ctr, "fb03_verify_diag_code");

            string tempDiagcode = objDiag_rec.DIAG_CD;
            flag_diag_cd = "Y";

            //  read diag-mstr;
            //         invalid key;
            //             if not price-only-claim then            
            //                 err_warn_msg = ws_error_literal;
            // 	               perform xb0-print-warning-line  thru    xb0-99-exit;
            //                 ws_carriage_ctrl = 1;
            //                 err_ind = 14;
            //                 err_diag_code = objDiag_rec.diag_cd;
            // 	               perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
            //                 flag_diag_cd = "N";

            objDiag_rec = new F091_DIAG_CODES_MSTR
            {
                WhereDiag_cd = objDiag_rec.DIAG_CD
            }.Collection().FirstOrDefault();

            if (objDiag_rec == null)
            {
                objDiag_rec = new F091_DIAG_CODES_MSTR();
                if (!Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //  perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 14;
                    err_diag_code = tempDiagcode;
                    // 	       perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    flag_diag_cd = "N";
                }
            }
        }

        private async Task fb03_99_exit()
        {
            Util.Trakker(++ctr, "fb03_99_exit");

            //     exit.;
        }

        private async Task fb04_verify_doc_location()
        {
            Util.Trakker(++ctr, "fb04_verify_doc_location");

            // if Hdr-loc-code = spaces and ws-default-batch-location not = spaces and not price-only-claim then
            hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
            if (string.IsNullOrWhiteSpace(hdr_loc_code_grp) && !string.IsNullOrWhiteSpace(ws_default_batch_location) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                hdr_loc_code_grp = ws_default_batch_location;
                hdr_loc_alpha = Util.Str(hdr_loc_code_grp).PadRight(4).Substring(0, 1);
                hdr_loc_nbr = Util.Str(hdr_loc_code_grp).PadRight(4).Substring(1, 3);
            }

            flag_location = "N";

            //  if hdr-loc-code not = spaces then
            hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
            if (!string.IsNullOrWhiteSpace(hdr_loc_code_grp))
            {
                //         perform fb04a-search-doc-location       thru    fb04a-99-exit;
                //             varying sub;
                //             from 1;
                //             by   1;
                //             until   sub > max-doc-locations;
                //                  or valid-location.;

                sub = 1;
                do
                {
                    await fb04a_search_doc_location();
                    await fb04a_99_exit();
                    sub++;
                } while (sub <= max_doc_locations && !flag_location.Equals(valid_location));
            }

            //  if  invalid-location and not price-only-claim then 
            if (Util.Str(flag_location).Equals(invalid_location) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //       perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 3;
                hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
                err_msg_loc_cd = hdr_loc_code_grp;
                //        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task fb04_99_exit()
        {
            Util.Trakker(++ctr, "fb04_99_exit");

            //     exit.;
        }

        private async Task fb04a_search_doc_location()
        {
            Util.Trakker(++ctr, "fb04a_search_doc_location");

            F020L_DOC_LOCATIONS_Collection = new F020L_DOC_LOCATIONS
            {
                WhereDoc_nbr = objDoc_mstr_rec.DOC_NBR
            }.Collection();

            if (F020L_DOC_LOCATIONS_Collection.Count() > 0)
            {
                // if hdr-loc-code = doc-loc(sub)  then 
                hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
                if (F020L_DOC_LOCATIONS_Collection.Count() > 0 && sub <= F020L_DOC_LOCATIONS_Collection.Count())
                {
                    if (hdr_loc_code_grp == F020L_DOC_LOCATIONS_Collection[sub -1].DOC_LOC)
                    {
                        flag_location = "Y";
                    }
                }
            }
        }

        private async Task fb04a_99_exit()
        {
            Util.Trakker(++ctr, "fb04a_99_exit");
            //     exit.;
        }

        private async Task fb04b_read_loc_mstr()
        {
            Util.Trakker(++ctr, "fb04b_read_loc_mstr");

            //objLoc_mstr_rec.loc_nbr = hdr_loc_code;

            hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
            objLoc_mstr_rec = new F030_LOCATIONS_MSTR
            {
                WhereLoc_nbr = hdr_loc_code_grp
            }.Collection().FirstOrDefault();

            //  read loc-mstr;
            //       invalid key;
            //         if not price-only-claim then;            
            //            objLoc_mstr_rec.loc_hospital_nbr = 0;
            //            objLoc_mstr_rec.loc_card_colour = "";
            //            err_warn_msg = ws_error_literal;
            //            perform xb0-print-warning-line  thru    xb0-99-exit;
            //            ws_carriage_ctrl = 1;
            //            err_ind = 51;
            //            err_51_loc_cd = hdr_loc_code;
            //               perform zb0-build-write-err-rpt-line thru    zb0-99-exit.

            if (objLoc_mstr_rec == null)
            {
                //         if not price-only-claim then; 
                if (!Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    objLoc_mstr_rec = new F030_LOCATIONS_MSTR();
                    objLoc_mstr_rec.LOC_HOSPITAL_NBR = 0;
                    objLoc_mstr_rec.LOC_CARD_COLOUR = "";
                    err_warn_msg = ws_error_literal;
                    //   perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 51;
                    err_51_loc_cd = hdr_loc_code_grp;
                    //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            //  if  loc-active-for-entry = "N" then 
            if (Util.Str(objLoc_mstr_rec.LOC_ACTIVE_FOR_ENTRY).ToUpper().Equals("N"))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 130;
                err_130_loc_cd = hdr_loc_code_grp;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task fb04b_99_exit()
        {
            Util.Trakker(++ctr, "fb04b_99_exit");

            //     exit.;
        }

        // hosp_nbr_code_to_nbr.rtn
        private async Task fb05_verify_hospital()
        {
            Util.Trakker(++ctr, "fb05_verify_hospital");

            subs_hosp = 0;
        }

        // hosp_nbr_code_to_nbr.rtn
        private async Task CA11_10_HOSP_LOOP()
        {
            Util.Trakker(++ctr, "CA11_10_HOSP_LOOP");

            //     ADD 1			TO	SUBS-HOSP.;
            //subs_hosp++;

            // IF CLMHDR-HOSP = HOSP-CODE (SUBS-HOSP)  THEN 
            //     L1_HOSP = HOSP_NBR[SUBS_HOSP];
            // 				TO	L1-HOSP;
            // 	   GO TO CA11-99-EXIT.;

            //  IF SUBS-HOSP < 35 THEN            
            // 	    GO TO CA11-10-HOSP-LOOP;
            //  ELSE;
            //     L1_HOSP = ZERO;
        }

        private async Task fb05_10_hosp_loop()
        {
            Util.Trakker(++ctr, "fb05_10_hosp_loop");

            //ADD 1  TO SUBS-HOSP.
            subs_hosp++;

            //IF hdr-hosp-nbr = hosp-nbr(SUBS-HOSP) THEN    
            if (hdr_hosp_nbr == hosp_nbr[subs_hosp])
            {
                //    MOVE hosp-code(SUBS-HOSP) TO clmhdr-hosp
                objSuspend_hdr_rec.CLMHDR_HOSP = hosp_code[subs_hosp];
                //    GO TO fb05-99-exit.
                await fb05_99_exit();
                return;
            }

            //  IF SUBS-HOSP< 35  THEN
            if (subs_hosp < 35)
            {
                //     GO TO fb05-10-hosp-loop
                await fb05_10_hosp_loop();
                return;
            }
            else
            {
                //     MOVE ZERO               TO      clmhdr-hosp.
                objSuspend_hdr_rec.CLMHDR_HOSP = "0";
            }
        }

        private async Task fb05_99_exit()
        {
            Util.Trakker(++ctr, "fb05_99_exit");
        }

        // hosp_nbr_code_to_nbr.rtn
        private async Task CA11_99_EXIT()
        {
            Util.Trakker(++ctr, "CA11_99_EXIT");

            //     EXIT.;
            //      replacing  ==ca11-move-hosp==      by ==fb05-verify-hospital==;
            //                 ==ca11-10-hosp-loop==   by ==fb05-10-hosp-loop==;
            //                 ==ca11-99-exit==        by ==fb05-99-exit==;
            //                 ==clmhdr-hosp==         by ==hdr-hosp-nbr==;
            //                 ==hosp-nbr==            by ==hosp-code==;
            //                 ==hosp-code==           by ==hosp-nbr==;
            //                 ==spaces==              by =="?"==;
            //                 ==l1-hosp==             by ==clmhdr-hosp==.;
        }

        // verify_agent_code.rtn
        private async Task fb06_verify_agent()
        {
            Util.Trakker(++ctr, "fb06_verify_agent");

            //MOVE hdr-agent - cd                   TO DEF-AGENT - CODE.
            def_agent_code = hdr_agent_cd;

            // IF  DEF-AGENT-OHIP OR DEF-AGENT-OHIP-WCB OR DEF-AGENT-IN-PAT-DIAG-BILLING OR DEF-AGENT-OHIP-NOT-VALID  OR DEF-AGENT-BILL-DIRECT  OR DEF-AGENT-WCB THEN 
            if (Util.Str(def_agent_code).Equals(def_agent_ohip) || Util.Str(def_agent_code).Equals(def_agent_ohip_wcb) || Util.Str(def_agent_code).Equals(def_agent_in_pat_diag_billing) || Util.Str(def_agent_code).Equals(def_agent_ohip_not_valid) || Util.Str(def_agent_code).Equals(def_agent_bill_direct) || Util.Str(def_agent_code).Equals(def_agent_wcb))
            {
                flag_agent_cd = "Y";
            }
            else
            {
                flag_agent_cd = "N";
            }
        }

        private async Task fb06_99_exit()
        {
            Util.Trakker(++ctr, "fb06_99_exit");

            //     EXIT.;
        }

        // verify_agent_code.rtn
        private async Task XX00_99_EXIT()
        {
            Util.Trakker(++ctr, "XX00_99_EXIT");

            //      replacing  ==xx00-verify-agent==   by ==fb06-verify-agent==;
            //                 ==xx00-99-exit==        by ==fb06-99-exit==;
            //                 ==agent-2b-tested==     by ==hdr-agent-cd==.;
        }

        private async Task fb07_verify_in_out_ind()
        {
            Util.Trakker(++ctr, "fb07_verify_in_out_ind");

            //  if  hdr-i-o-ind = spaces and ws-default-batch-i-o-ind not = spaces then 
            if (string.IsNullOrWhiteSpace(hdr_i_o_ind) && !string.IsNullOrWhiteSpace(ws_default_batch_i_o_ind))
            {
                hdr_i_o_ind = ws_default_batch_i_o_ind;
            }

            //  if hdr-i-o-ind = "1" or "2" or "I" or "O" or spaces then
            if (Util.Str(hdr_i_o_ind) == "1" || Util.Str(hdr_i_o_ind) == "2" || Util.Str(hdr_i_o_ind).ToUpper() == "I" || Util.Str(hdr_i_o_ind).ToUpper() == "O" || string.IsNullOrWhiteSpace(hdr_i_o_ind))
            {
                flag_in_out_ind = "Y";
            }
            else
            {
                flag_in_out_ind = "N";
            }
        }

        private async Task fb07_99_exit()
        {
            Util.Trakker(++ctr, "fb07_99_exit");

            //     exit.;
        }

        private async Task fd0_build_susp_addr_rec_hdr1()
        {
            Util.Trakker(++ctr, "fd0_build_susp_addr_rec_hdr1");

            //objSuspend_address_rec.suspend_address_rec = "";
            objSuspend_address_rec = new F002_SUSPEND_ADDRESS();

            //objSuspend_address_rec.addr_birth_date = hdr_birth_date_long;
            hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
            objSuspend_address_rec.ADD_BIRTH_DATE = Util.NumInt(hdr_birth_date_long_grp);

            // if  hdr-birth-date-long = spaces or zeros  and not price-only-claim  then
            if (string.IsNullOrWhiteSpace(hdr_birth_date_long_grp) || hdr_birth_date_long_grp == "0" && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_warning_literal;
                //      perform xb0-print-warning-line thru xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 37;
                err_birth_date = hdr_birth_date_long_grp;
                //      perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
            else
            {
                ws_date_yy = Util.NumInt(Util.Str(objSuspend_address_rec.ADD_BIRTH_DATE).PadRight(8).Substring(0, 4));   // todo: check the values...
                ws_date_mm = Util.NumInt(Util.Str(objSuspend_address_rec.ADD_BIRTH_DATE).PadRight(8).Substring(4, 2));
                ws_date_dd = Util.NumInt(Util.Str(objSuspend_address_rec.ADD_BIRTH_DATE).PadRight(8).Substring(6, 2));
                //     perform xd0-verify-date thru xd0-99-exit;
                await xd0_verify_date();
                await xd0_99_exit();
                //         if  invalid-date and not price-only-claim then 
                if (Util.Str(flag_date).Equals(invalid_date) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //           perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 37;
                    hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
                    err_birth_date = hdr_birth_date_long_grp;
                    //                perform zb0-build-write-err-rpt-line thru zb0-99-exit.;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            //objSuspend_address_rec.addr_doc_pract_nbr = objSuspend_hdr_rec.clmhdr_doc_pract_nbr;
            objSuspend_address_rec.ADD_DOC_OHIP_NBR = Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_OHIP_NBR);

            //objSuspend_address_rec.addr_accounting_nbr = objSuspend_hdr_rec.clmhdr_accounting_nbr;
            objSuspend_address_rec.ADD_ACCOUNTING_NBR = Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR);
            objSuspend_address_rec.DEBUG_INFO = string.Empty.PadRight(256, ' ');
            objSuspend_address_rec.ERROR_FLAG = 0;
            objSuspend_address_rec.INPUT_FILE_LOCATION = string.Empty.PadRight(256, ' ');
        }

        private async Task fd0_99_exit()
        {
            Util.Trakker(++ctr, "fd0_99_exit");

            //     exit.;
        }

        private async Task<string> ga0_proc_rec_type_header2()
        {
            Util.Trakker(++ctr, "ga0_proc_rec_type_header2");

            // if unpriced-clmhdr-claim = 00523321 then  
            objUnpriced_claims_record.Unpriced_clmhdr_claim_grp = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_doc_nbr).PadRight(3) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_wk).PadRight(2) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_day).PadRight(1) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_claim_nbr).PadRight(2);
            if (Util.NumInt(objUnpriced_claims_record.Unpriced_clmhdr_claim_grp) == 00523321) {
                // 	   next sentence.;
            }

            //objSuspend_hdr_rec.clmhdr_pat_acronym6 = objUnpriced_claims_record.unpriced_clmhdr_pat_surname;
            objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM6 = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_pat_surname).Substring(0, 6);

            //objSuspend_hdr_rec.clmhdr_patient_surname = objUnpriced_claims_record.unpriced_clmhdr_pat_surname;
            objSuspend_hdr_rec.CLMHDR_PATIENT_SURNAME = objUnpriced_claims_record.Unpriced_clmhdr_pat_surname;

            //objSuspend_hdr_rec.clmhdr_pat_acronym3 = objUnpriced_claims_record.unpriced_clmhdr_given_name;
            objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM3 = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_given_name).Substring(0, 3);

            //objSuspend_hdr_rec.clmhdr_subscr_initials = objUnpriced_claims_record.unpriced_clmhdr_given_name;
            objSuspend_hdr_rec.CLMHDR_SUBSCR_INITIALS = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_given_name).Substring(0, 3);

            // objSuspend_hdr_rec.susp_hdr_acronym = objSuspend_hdr_rec.clmhdr_pat_acronym;
            objSuspend_hdr_rec.SUSP_HDR_ACRONYM = Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM6).PadRight(6) + Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM3);

            //  if  unpriced-confidentiality-flag = "Y" or hdr-manual-review  = "Y"  then 
            if (Util.Str(objUnpriced_claims_record.Unpriced_confidentiality_flag).ToUpper() == "Y" || Util.Str(hdr_manual_review).ToUpper() == "Y")
            {
                hdr_manual_review = "Y";
            }
            else
            {
                hdr_manual_review = " ";
            }

            //  if   unpriced-confidentiality-flag = "Y" then            
            if (Util.Str(objUnpriced_claims_record.Unpriced_confidentiality_flag).ToUpper() == "Y")
            {
                objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG = "Y";
            }
            else
            {
                objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG = " ";
            }

            hdr_loc_code_grp = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_loc_code);
            hdr_loc_alpha = Util.Str(hdr_loc_code_grp).PadRight(4).Substring(0, 1);
            hdr_loc_nbr = Util.Str(hdr_loc_code_grp).PadRight(4).Substring(1, 3);

            //   perform fb04-verify-doc-location    thru    fb04-99-exit.;
            await fb04_verify_doc_location();
            await fb04_99_exit();

            //   objSuspend_hdr_rec.clmhdr_loc = hdr_loc_code;
            objSuspend_hdr_rec.CLMHDR_LOC = hdr_loc_code_grp;

            // if  (  (bt-clinic-nbr-1-2 >= 61 and bt-clinic-nbr-1-2  <= 66) or   (bt-clinic-nbr-1-2 >= 71 and bt-clinic-nbr-1-2  <= 74))  and  not price-only-claim  then            
            if (((bt_clinic_nbr_1_2 >= 61 && bt_clinic_nbr_1_2 <= 66) || (bt_clinic_nbr_1_2 >= 71 && bt_clinic_nbr_1_2 <= 74)) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                // 	    if    hdr-loc-code not = 'M233';
                if (hdr_loc_code_grp != "M233"
                // 	          and hdr-loc-code not = 'M521';
                    && hdr_loc_code_grp != "M521"
                // 	          and hdr-loc-code not = 'M525';
                     && hdr_loc_code_grp != "M525"
                // 	          and hdr-loc-code not = 'M540';
                     && hdr_loc_code_grp != "M540"
                // 	          and hdr-loc-code not = 'M541';
                     && hdr_loc_code_grp != "M541"
                // 	          and hdr-loc-code not = 'M542';
                     && hdr_loc_code_grp != "M542"
                // 	          and hdr-loc-code not = 'M544';
                     && hdr_loc_code_grp != "M544"
                // 	          and hdr-loc-code not = 'M545';
                     && hdr_loc_code_grp != "M545"
                // 	          and hdr-loc-code not = 'M546';
                     && hdr_loc_code_grp != "M546"
                // 	          and hdr-loc-code not = 'M547';
                      && hdr_loc_code_grp != "M547"
                // 	          and hdr-loc-code not = 'M555';
                      && hdr_loc_code_grp != "M555"
                // 	          and hdr-loc-code not = 'M556' 
                      && hdr_loc_code_grp != "M556"
                //      then;
                )
                {
                    err_warn_msg = ws_warning_literal;
                    //           perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 62;
                    err_62_clinic_nbr = bt_clinic_nbr_1_2;
                    err_62_loc_code = hdr_loc_code_grp;
                    objSuspend_hdr_rec.CLMHDR_LOC = "????";
                    //             perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            //   perform fb04b-read-loc-mstr		thru	fb04b-99-exit.;
            await fb04b_read_loc_mstr();
            await fb04b_99_exit();

            //   objSuspend_hdr_rec.clmhdr_hosp = objLoc_mstr_rec.loc_hospital_nbr;
            objSuspend_hdr_rec.CLMHDR_HOSP = Util.Str(objLoc_mstr_rec.LOC_HOSPITAL_NBR);

            //   objSuspend_hdr_rec.clmhdr_hosp = ws_default_payroll_flag;
            objSuspend_hdr_rec.CLMHDR_HOSP = ws_default_payroll_flag;

            //   hdr_agent_cd = objUnpriced_claims_record.unpriced_clmhdr_agent_cd;
            hdr_agent_cd = objUnpriced_claims_record.Unpriced_clmhdr_agent_cd;

            //   perform fb06-verify-agent           thru    fb06-99-exit.;
            await fb06_verify_agent();
            await fb06_99_exit();

            //  if  invalid-agent-cd  and not price-only-claim then 
            if (Util.Str(flag_agent_cd).Equals(invalid_agent_cd) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 20;
                err_agent_cd = hdr_agent_cd;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //    objSuspend_hdr_rec.clmhdr_agent_cd = hdr_agent_cd;
            objSuspend_hdr_rec.CLMHDR_AGENT_CD = Util.NumInt(hdr_agent_cd);

            //  if  def-agent-ohip or def-agent-ohip-wcb  then           
            if (Util.Str(def_agent_code).Equals(def_agent_ohip) || Util.Str(def_agent_code).Equals(def_agent_ohip_wcb))
            {
                //       objSuspend_hdr_rec.clmhdr_date_cash_tape_payment = 0;
                objSuspend_hdr_rec.CLMHDR_DATE_CASH_TAPE_PAYMENT = "0";
            }
            //  else if not price-only-claim  then            
            else if (!Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                // 	     if clmhdr-agent-cd = 6 then            
                if (Util.NumInt(objSuspend_hdr_rec.CLMHDR_AGENT_CD) == 6)
                {
                    objSuspend_hdr_rec.CLMHDR_MSG_NBR = "00";
                    objSuspend_hdr_rec.CLMHDR_REPRINT_FLAG = "N";
                    objSuspend_hdr_rec.CLMHDR_SUB_NBR = "0";
                    objSuspend_hdr_rec.CLMHDR_AUTO_LOGOUT = "N";
                    objSuspend_hdr_rec.CLMHDR_FEE_COMPLEX = "0";
                }
                else
                {
                    err_warn_msg = ws_warning_literal;
                    //          perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 25;
                    //           perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_MSG_NBR = "??";
                    objSuspend_hdr_rec.CLMHDR_REPRINT_FLAG = "?";
                    objSuspend_hdr_rec.CLMHDR_SUB_NBR = "?";
                    objSuspend_hdr_rec.CLMHDR_AUTO_LOGOUT = "?";
                    objSuspend_hdr_rec.CLMHDR_FEE_COMPLEX = "?";
                }
            }


            //  if clmhdr-agent-cd = 0 or 2 then        
            if (Util.NumInt(objSuspend_hdr_rec.CLMHDR_AGENT_CD) == 0 || Util.NumInt(objSuspend_hdr_rec.CLMHDR_AGENT_CD) == 2)
            {
                objSuspend_hdr_rec.CLMHDR_TAPE_SUBMIT_IND = "Y";
            }
            else
            {
                objSuspend_hdr_rec.CLMHDR_TAPE_SUBMIT_IND = "N";
            }

            //  if clmhdr-agent-cd =  9 then            
            if (Util.NumInt(objSuspend_hdr_rec.CLMHDR_AGENT_CD) == 9)
            {
                objSuspend_hdr_rec.CLMHDR_STATUS = "I";
            }

            hdr_i_o_ind = Util.Str(objLoc_mstr_rec.LOC_CARD_COLOUR);

            // if  unpriced-clmhdr-i-o-ind  not =   hdr-i-o-ind and not price-only-claim  then            
            if (Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_i_o_ind) != Util.Str(hdr_i_o_ind) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_warning_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 53;
                err_53_incoming_i_o_ind = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_i_o_ind);
                err_53_i_o_ind = hdr_i_o_ind;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit .
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //     perform fb07-verify-in-out-ind      thru    fb07-99-exit.;
            await fb07_verify_in_out_ind();
            await fb07_99_exit();

            //  if invalid-in-out-ind and not price-only-claim  then  
            if (Util.Str(flag_in_out_ind).Equals(invalid_in_out_ind) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 15;
                err_i_o_ind = hdr_i_o_ind;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND = Util.Str(hdr_i_o_ind);
            }
            //  else if hdr-i-o-ind = "1" or "I"  then            
            else if (hdr_i_o_ind == "1" || hdr_i_o_ind == "I")
            {
                objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND = "I";
            }
            //  else if hdr-i-o-ind = "2" or "O" then            
            else if (hdr_i_o_ind == "2" || hdr_i_o_ind == "O")
            {
                objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND = "O";
            }
            else
            {
                objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND = "O";
            }


            // if unpriced-clmhdr-prov-cd = spaces or '.' or '..'  then        
            if (string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_clmhdr_prov_cd) || Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_prov_cd).Equals(".") || Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_prov_cd).Equals(".."))
            {
                hdr_health_care_prov = "ON";
            }
            else
            {
                hdr_health_care_prov = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_prov_cd);
            }

            province_flag = "N";

            //     perform fb0a-search-province        thru    fb0a-99-exit;
            //             varying sub from 1 by 1;
            //             until (province-found or sub > 12).;

            sub = 1;
            do
            {
                await fb0a_search_province();
                await fb0a_99_exit();
                sub++;
            } while (!Util.Str(province_flag).Equals(province_found) && sub <= 12);


            // if  province-not-found and not price-only-claim then 
            if (Util.Str(province_flag).Equals(province_not_found) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 30;
                err_province = hdr_health_care_prov;
                hdr_health_care_prov = "ON";
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_PROV = Util.Str(hdr_health_care_prov);

            // if hdr-agent-cd = 6  then;            
            if (Util.NumInt(hdr_agent_cd) == 6)
            {
                hdr_surname_3 =  Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_pat_surname).Substring(0, 3);
                hdr_birthdate_yymm = Convert.ToInt16(Util.Str(hdr_birth_date).Substring(2, 4));
                hdr_birthdate_dd = hdr_birth_date_dd;
                objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                hdr_direct_key_grp = Util.Str(hdr_surname_3) + Util.Str(hdr_birthdate_yymm) + Util.Str(hdr_birthdate_dd).PadLeft(2, '0');
                objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_direct_key_grp.PadRight(15);
                // 	   go to ga0-90.;                
                return "ga0_90";
            }


            // if hdr-health-care-prov not = 'ON'  and unpriced-clmhdr-pat-ohip-nbr not = spaces and unpriced-clmhdr-pat-ohip-nbr not = zeroes then            
            if (Util.Str(hdr_health_care_prov).ToUpper() != "ON" && !string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_clmhdr_pat_ohip_nbr) && Util.NumLongInt(objUnpriced_claims_record.Unpriced_clmhdr_pat_ohip_nbr) != 0)
            {
                hdr_ohip_nbr_grp = objUnpriced_claims_record.Unpriced_clmhdr_pat_ohip_nbr;
                nf_ohip_nbr = hdr_ohip_nbr_grp;

                bc_ns_ohip_nbr_grp = nf_ohip_nbr;    // These are redefines...
                bc_ns_10_digits = Util.Str(nf_ohip_nbr).PadRight(12).Substring(0, 10);
                bc_ns_last_digits = Util.Str(nf_ohip_nbr).PadRight(12).Substring(10, 2);

                ab_nb_sk_yt_ohip_nbr_grp = nf_ohip_nbr;
                ab_nb_sk_yt_9_digits = Util.Str(nf_ohip_nbr).PadRight(12).Substring(0, 9);
                ab_nb_sk_yt_last_digits = Util.Str(nf_ohip_nbr).PadRight(12).Substring(9, 3);

                pe_ohip_nbr_grp = nf_ohip_nbr;
                pe_8_digits = Util.Str(pe_ohip_nbr_grp).PadRight(12).Substring(0, 8);
                pe_last_digits = Util.Str(pe_ohip_nbr_grp).PadRight(12).Substring(8, 4);

                nt_ohip_nbr_grp = nf_ohip_nbr;
                nt_first_digit = Util.Str(nt_ohip_nbr_grp).PadRight(12).Substring(0, 1);
                nt_7_digits = Util.Str(nt_ohip_nbr_grp).PadRight(12).Substring(1, 7);
                nt_last_digits = Util.Str(nt_ohip_nbr_grp).PadRight(12).Substring(8, 4);

                mb_ohip_nbr_grp = nf_ohip_nbr;
                mb_9_digits = Util.Str(mb_ohip_nbr_grp).PadRight(12).Substring(0, 9);
                mb_last_digits = Util.Str(mb_ohip_nbr_grp).PadRight(12).Substring(9, 3);
            }


            // if hdr-health-care-prov = 'ON' then 
            if (Util.Str(hdr_health_care_prov).ToUpper().Equals("ON"))
            {
                //      if  hdr-health-care-nbr = spaces and not price-only-claim  then            
                if (string.IsNullOrWhiteSpace(hdr_health_care_nbr) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru    xb0-99-exit
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 29;
                    err_health_care_nbr = hdr_health_care_nbr;
                    //           perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = "??????????";
                }
                else
                {
                    ws_nbr_10 = hdr_health_care_nbr;
                    //          if  ( ws-nbr-10 not numeric  or ws-nbr-10 = zero ) and not price-only-claim then 
                    if ((!Util.IsNumericValue(ws_nbr_10) || Util.NumLongInt(ws_nbr_10) == 0) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                    {
                        err_warn_msg = ws_error_literal;
                        //                 perform xb0-print-warning-line thru    xb0-99-exit            
                        await xb0_print_warning_line();
                        await xb0_99_exit();
                        ws_carriage_ctrl = 1;
                        err_ind = 29;
                        err_health_care_nbr = hdr_health_care_nbr;
                        //                 perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                        await zb0_build_write_err_rpt_line();
                        await zb0_99_exit();
                        objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = "??????????";
                    }
                    else
                    {
                        ws_check_nbr_10_grp = Util.Str(hdr_health_care_nbr);
                        ws_chk_nbr_10 = Util.NumLongInt(Util.Str(ws_check_nbr_10_grp).PadRight(10, '0'));
                        ws_chk_nbr_10_r_grp = Util.Str(ws_chk_nbr_10).PadRight(10, '0');
                        ws_chk_nbr_1_10 = Util.NumInt(Util.Str(ws_chk_nbr_10_r_grp).Substring(0, 1));


                        //               perform db0a-mod10-check-digit-10 thru  db0a-99-exit;
                        await db0a_mod10_check_digit_10();
                        await db0a_99_exit();

                        //                 if  flag = 'N' and not price-only-claim then            
                        if (Util.Str(flag).ToUpper() == "N" && !Util.Str(flag_claim_source).Equals(price_only_claim))
                        {
                            err_warn_msg = ws_error_literal;
                            //                     perform xb0-print-warning-line thru    xb0-99-exit            
                            await xb0_print_warning_line();
                            await xb0_99_exit();
                            ws_carriage_ctrl = 1;
                            err_ind = 29;
                            err_health_care_nbr = hdr_health_care_nbr;
                            //                     perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                            await zb0_build_write_err_rpt_line();
                            await zb0_99_exit();

                            objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = "??????????";
                        }
                        else
                        {
                            //                     next sentence.;
                        }
                    }
                }
            }


            //  if hdr-health-care-prov = 'NL' then; 
            if (Util.Str(hdr_health_care_prov).ToUpper() == "NL")
            {
                //      if  (  nf-ohip-nbr is not numeric   or (nf-ohip-nbr = spaces or zeros)) and not price-only-claim  then
                if ((!Util.IsNumericValue(nf_ohip_nbr) || (string.IsNullOrWhiteSpace(nf_ohip_nbr) || nf_ohip_nbr == "0")) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 40;
                    err_prov = hdr_health_care_prov;

                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    err_ohip_nbr = hdr_ohip_nbr_grp;
                    //         perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                }
                else
                {
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = hdr_ohip_nbr_grp;
                }
            }
            // else if hdr-health-care-prov = 'BC' or 'NS' then            
            else if (Util.Str(hdr_health_care_prov).ToUpper() == "BC" || Util.Str(hdr_health_care_prov).ToUpper() == "NS")
            {
                //       if  ( (bc-ns-10-digits is not numeric)  or  (bc-ns-10-digits =  spaces or zeros)  or  (bc-ns-last-digits not = spaces))and not price-only-claim then 
                if (((!Util.IsNumericValue(bc_ns_10_digits)) || (string.IsNullOrWhiteSpace(bc_ns_10_digits) || bc_ns_10_digits == "0") || (!string.IsNullOrWhiteSpace(bc_ns_last_digits))) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //          perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 40;
                    err_prov = hdr_health_care_prov;
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    err_ohip_nbr = hdr_ohip_nbr_grp;
                    //            perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                }
                else
                {
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = hdr_ohip_nbr_grp;
                }
            }
            // else if hdr-health-care-prov = 'PE' then 
            else if (Util.Str(hdr_health_care_prov).ToUpper() == "PE")
            {
                //      if  ((pe-8-digits is not numeric)  or  (pe-8-digits =  spaces or zeros) or  (pe-last-digits not = spaces)) and not price-only-claim then 
                if (((!Util.IsNumericValue(pe_8_digits)) || (string.IsNullOrWhiteSpace(pe_8_digits) || pe_8_digits == "0") || (!string.IsNullOrWhiteSpace(pe_last_digits))) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 40;
                    err_prov = hdr_health_care_prov;
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    err_ohip_nbr = hdr_ohip_nbr_grp;
                    //         perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                }
                else
                {
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                            objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = Util.Str(hdr_ohip_nbr_grp);
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = Util.Str(hdr_ohip_nbr_grp);
                }
            }
            // else if hdr-health-care-prov = 'AB' or 'NB' or 'SK' or 'YT' or 'NU' then 
            else if (Util.Str(hdr_health_care_prov).ToUpper() == "AB" || Util.Str(hdr_health_care_prov).ToUpper() == "NB" || Util.Str(hdr_health_care_prov).ToUpper() == "SK" || Util.Str(hdr_health_care_prov).ToUpper() == "YT" || Util.Str(hdr_health_care_prov).ToUpper() == "NU")
            {
                //      if  ( (ab-nb-sk-yt-9-digits is not numeric) or  (ab-nb-sk-yt-9-digits =  spaces or zeros) or  (ab-nb-sk-yt-last-digits not = spaces)) and not price-only-claim then            
                if (((!Util.IsNumericValue(ab_nb_sk_yt_9_digits)) || (string.IsNullOrWhiteSpace(ab_nb_sk_yt_9_digits) || ab_nb_sk_yt_9_digits == "0") || (!string.IsNullOrWhiteSpace(ab_nb_sk_yt_last_digits))) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //           perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 40;
                    err_prov = hdr_health_care_prov;
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    err_ohip_nbr = hdr_ohip_nbr_grp;
                    //           perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = Util.Str(hdr_ohip_nbr_grp);
                }
                else
                {
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = Util.Str(hdr_ohip_nbr_grp);
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = Util.Str(hdr_ohip_nbr_grp);
                }
            }
            // else if hdr-health-care-prov = 'NT' then            
            else if (Util.Str(hdr_health_care_prov).ToUpper() == "NT")
            {  // TODO: nt-first-digit is not alphabetic.... verifty the value ...??
                //      if  ((nt-first-digit is not alphabetic)  or  (nt-first-digit =  spaces) or  (nt-7-digits is not numeric) or  (nt-7-digits =  spaces or zeros) or  (nt-last-digits not = spaces)) and not price-only-claim then            
                if (((Util.IsNumericValue(nt_first_digit)) || (string.IsNullOrWhiteSpace(nt_first_digit)) || (!Util.IsNumericValue(nt_7_digits)) || (string.IsNullOrWhiteSpace(nt_7_digits) || nt_7_digits == "0") || (!string.IsNullOrWhiteSpace(nt_last_digits))) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //           perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 40;
                    err_prov = hdr_health_care_prov;
                    hdr_ohip_nbr_grp = Util.Str(nf_ohip_nbr);
                    err_ohip_nbr =  hdr_ohip_nbr_grp;
                    //           perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                }
                else
                {
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = hdr_ohip_nbr_grp;
                }
            }
            // else if hdr-health-care-prov = 'MB' then 
            else if (Util.Str(hdr_health_care_prov).ToUpper() == "MB")
            {
                //      if  ((mb-9-digits is not numeric)  or  (mb-9-digits =  spaces or zeros) or  (mb-last-digits not = spaces)) and not price-only-claim then            
                if (((!Util.IsNumericValue(mb_9_digits)) || (string.IsNullOrWhiteSpace(mb_9_digits) || mb_9_digits == "0") || (!string.IsNullOrWhiteSpace(mb_last_digits))) && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //           perform xb0-print-warning-line thru xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 40;
                    err_prov = hdr_health_care_prov;
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    err_ohip_nbr = hdr_ohip_nbr_grp;
                    //           perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                }
                else
                {
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE = "O";
                    hdr_ohip_nbr_grp = nf_ohip_nbr;
                    objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA = hdr_ohip_nbr_grp;
                    objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR = hdr_ohip_nbr_grp;
                }
            }
            return string.Empty;
        }

        private async Task ga0_90()
        {
            Util.Trakker(++ctr, "ga0_90");

            //  perform ga1-build-addr-rec-from-hdr2    thru ga1-99-exit.;
            await ga1_build_addr_rec_from_hdr2();
            await ga1_99_exit();
        }

        private async Task ga0_99_exit()
        {
            Util.Trakker(++ctr, "ga0_99_exit");

            //    exit.;
        }

        private async Task ga1_build_addr_rec_from_hdr2()
        {
            Util.Trakker(++ctr, "ga1_build_addr_rec_from_hdr2");

            objSuspend_address_rec.ADD_SURNAME = objUnpriced_claims_record.Unpriced_clmhdr_pat_surname;
            objSuspend_address_rec.ADD_FIRST_NAME = objUnpriced_claims_record.Unpriced_clmhdr_given_name;

            // if  unpriced-clmhdr-sex = "1" then 
            if (Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_sex) == "1")
            {
                objSuspend_address_rec.ADD_SEX = "M";
            }
            // else if   unpriced-clmhdr-sex = "2" then            
            else if (Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_sex) == "2")
            {
                objSuspend_address_rec.ADD_SEX = "F";
            }
            else
            {
                objSuspend_address_rec.ADD_SEX = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_sex);
            }

            objUnpriced_claims_record.Unpriced_clmhdr_phone_no = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no_1_7).PadRight(7) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no_8_10).PadRight(3);
            temp_phone_nbr_grp = objUnpriced_claims_record.Unpriced_clmhdr_phone_no; // Unpriced_clmhdr_phone_no;
            objUnpriced_claims_record.Unpriced_clmhdr_phone_no_1_3 = objUnpriced_claims_record.Unpriced_clmhdr_phone_no.Substring(0, 3);
            objUnpriced_claims_record.Unpriced_clmhdr_phone_no_4_10 = objUnpriced_claims_record.Unpriced_clmhdr_phone_no.Substring(3, 7);

            temp_phone_nbr_justified_left_grp = temp_phone_nbr_grp;
            temp_phone_nbr_1_7 = Util.NumInt(Util.Str(temp_phone_nbr_justified_left_grp).PadRight(10).Substring(0, 7));
            temp_phone_nbr_8_10 = Util.NumInt(Util.Str(temp_phone_nbr_justified_left_grp).PadRight(10).Substring(7, 3));

            temp_phone_nbr_justified_right_grp = temp_phone_nbr_justified_left_grp;
            temp_phone_nbr_1_3 = Util.NumInt(Util.Str(temp_phone_nbr_justified_right_grp).PadRight(10).Substring(0, 3));
            temp_phone_nbr_4_10 = Util.NumInt(Util.Str(temp_phone_nbr_justified_right_grp).PadRight(10).Substring(3, 7));

            // if  ( temp-phone-nbr-1-3  =  0  and temp-phone-nbr-4-10 <> 0  ) or (    temp-phone-nbr-1-7  <> 0  and temp-phone-nbr-8-10 =  0  )   then            
            if ((temp_phone_nbr_1_3 == 0 && temp_phone_nbr_4_10 != 0) || (temp_phone_nbr_1_7 != 0 && temp_phone_nbr_8_10 == 0))
            {
                objUnpriced_claims_record.Unpriced_clmhdr_phone_no_1_3 = default_area_code;
                //     if temp-phone-nbr-8-10 = 0 then            
                if (temp_phone_nbr_8_10 == 0)
                {
                    objUnpriced_claims_record.Unpriced_clmhdr_phone_no_4_10 = Util.Str(temp_phone_nbr_1_7);
                }
                else
                {
                    objUnpriced_claims_record.Unpriced_clmhdr_phone_no_4_10 = Util.Str(temp_phone_nbr_4_10);
                }
            }
            objUnpriced_claims_record.Unpriced_clmhdr_phone_no = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no_1_3).PadRight(3) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no_4_10).PadRight(7);

            // objUnpriced_claims_record.Unpriced_clmhdr_phone_no_grp = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no_1_7).PadRight(7) + Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no_8_10).PadRight(3);
            objSuspend_address_rec.ADD_PHONE_NO = Util.Str(objUnpriced_claims_record.Unpriced_clmhdr_phone_no); // Unpriced_clmhdr_phone_no;
        }

        private async Task ga1_99_exit()
        {
            Util.Trakker(++ctr, "ga1_99_exit");

            //     exit.;
        }

        private async Task gb1_verify_dtl_diag_cd()
        {
            Util.Trakker(++ctr, "gb1_verify_dtl_diag_cd");

            // if hold-diag-cd(ss-write-dtl) = spaces or zeros  then 
            if (hold_diag_cd[ss_write_dtl] == 0)
            {
                //    if  hold-oma-rec-ind (ss-write-dtl, ss-diag-ind) = "Y" and hold-oma-suff    (ss-write-dtl)  = "A" or "M" and not price-only-claim then
                if (hold_oma_rec_ind[ss_write_dtl, ss_diag_ind] == "Y" && hold_oma_suff[ss_write_dtl] == "A" || hold_oma_suff[ss_write_dtl] == "M" && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //        perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 22;

                    //hold_oma_cd_num_grp[ss_write_dtl] = Util.Str(hold_oma_cd_num_1[ss_write_dtl]) + Util.Str(hold_oma_cd_num_2[ss_write_dtl]) + Util.Str(hold_oma_cd_num_3[ss_write_dtl]);
                    //hold_oma_cd_grp[ss_write_dtl] = hold_oma_cd_alpha[ss_write_dtl] + hold_oma_cd_num_grp[ss_write_dtl];
                    err_22_oma_cd = await hold_oma_cd_grp(ss_write_dtl);
                    err_22_msg = "DIAGNOSTIC CODE";
                    //        perform zb0-build-write-err-rpt-line thru    zb0-99-exit;            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                    objSuspend_dtl_rec.CLMDTL_DIAG_CD = 0;
                }
                else
                {
                    objSuspend_dtl_rec.CLMDTL_DIAG_CD = 0;
                }
            }
            else
            {
                objDiag_rec.DIAG_CD = Util.Str(hold_diag_cd[ss_write_dtl]).PadLeft(3, '0');
                //     perform fb03-verify-diag-code     thru    fb03-99-exit;
                await fb03_verify_diag_code();
                await fb03_99_exit();
                objSuspend_dtl_rec.CLMDTL_DIAG_CD = hold_diag_cd[ss_write_dtl];
                //       if clmhdr-diag-cd-alpha = spaces or zeros then 
                if (Util.NumInt(objSuspend_hdr_rec.CLMHDR_DIAG_CD) == 0)
                {
                    objSuspend_hdr_rec.CLMHDR_DIAG_CD = hold_diag_cd[ss_write_dtl];
                }
            }

        }

        private async Task gb1_99_exit()
        {
            Util.Trakker(++ctr, "gb1_99_exit");

            //     exit.;
        }

        // d001_d003_newu701_confidentiality_check.rtn
        private async Task ga11_check_for_confidentially()
        {
            Util.Trakker(++ctr, "ga11_check_for_confidentially");

            //  if clmhdr-confidential-flag =    "Y" or "R" then            
            if (Util.Str(objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG).ToUpper() == "Y" || Util.Str(objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG).ToUpper() == "R")
            {
                // 	     go to ga11-99-exit.;
                await ga11_99_exit();
                return;
            }

            //  perform ga11a-check-conf-ministry		thru ga11a-99-exit.;
            await ga11a_check_conf_ministry();
            await ga11a_99_exit();

            //  if clmhdr-confidential-flag  <> "Y" and <> "R" then            
            if (Util.Str(objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG).ToUpper() != "Y" && Util.Str(objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG).ToUpper() != "R")
            {
                // 	    perform ga11b-check-conf-rma		thru ga11b-99-exit.;
                await ga11b_check_conf_rma();
                await ga11b_99_exit();
            }
        }

        // d001_d003_newu701_confidentiality_check.rtn
        private async Task ga11_99_exit()
        {
            Util.Trakker(++ctr, "ga11_99_exit");

            //     exit.;
        }

        // confidentially_check_ministry_codes.rtn
        private async Task ga11a_check_conf_ministry()
        {
            Util.Trakker(++ctr, "ga11a_check_conf_ministry");

            //  if clmhdr-confidential-flag = "Y" then 
            if (Util.Str(objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG).ToUpper() == "Y")
            {
                // 	go to ga11a-99-exit.;
                await ga11a_99_exit();
                return;
            }

            //hold_oma_cd_num_grp[ss_clmdtl_oma] = Util.Str(hold_oma_cd_num_1[ss_clmdtl_oma]) + Util.Str(hold_oma_cd_num_2[ss_clmdtl_oma]) + Util.Str(hold_oma_cd_num_3[ss_clmdtl_oma]);
            //hold_oma_cd_grp[ss_clmdtl_oma] = hold_oma_cd_alpha[ss_clmdtl_oma] + hold_oma_cd_num_grp[ss_clmdtl_oma];

            //  if hold-diag-cd (ss-clmdtl-oma) =;
            if (hold_diag_cd[ss_clmdtl_oma] == 99
            // 					or 290;
                || hold_diag_cd[ss_clmdtl_oma] == 299
            // 					or 291;
                 || hold_diag_cd[ss_clmdtl_oma] == 291
            // 					or 292;
                 || hold_diag_cd[ss_clmdtl_oma] == 292
            // 					or 295;
                 || hold_diag_cd[ss_clmdtl_oma] == 295
            // 					or 296;
                 || hold_diag_cd[ss_clmdtl_oma] == 296
            // 					or 297;
                 || hold_diag_cd[ss_clmdtl_oma] == 297
            // 					or 298;
                 || hold_diag_cd[ss_clmdtl_oma] == 298
            // 					or 299;
                 || hold_diag_cd[ss_clmdtl_oma] == 299
            // 					or 634;
                 || hold_diag_cd[ss_clmdtl_oma] == 634
            // 					or 635;
                  || hold_diag_cd[ss_clmdtl_oma] == 635
            // 					or 640;
                 || hold_diag_cd[ss_clmdtl_oma] == 640
            // 					or 895;
                  || hold_diag_cd[ss_clmdtl_oma] == 895
            //     then;
            )
            {
                objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG = "R";
            }
            //  else if hold-oma-cd (ss-clmdtl-oma) =;
            else if (
            // 					   'A777';
                await hold_oma_cd_grp(ss_clmdtl_oma) == "A777"
            // 					or 'A902';
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "A902"
            // 					or 'C777';
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C777"
            //     				or 'E108';
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E108"
            // 					or 'E753';
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E753"
            // 					or 'K015';
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "K015"
            //                               		or 'K018';
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "K018"
            // 					or 'K021';
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "K021"
            // 					or 'K051' or 'K052' or 'K053';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "K051" || await hold_oma_cd_grp(ss_clmdtl_oma) == "K052" || await hold_oma_cd_grp(ss_clmdtl_oma) == "K053"
            // 					or 'K061';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "K061"
            // 					or 'K620';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "K620"
            // 					or 'K623' or 'K624';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "K623" || await hold_oma_cd_grp(ss_clmdtl_oma) == "K624"
            // 					or 'K629';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "K629"
            // 					or 'G100';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "G100"
            // 					or 'R200';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "R200"
            // 					or 'R872';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "R872"
            // 					or 'S274';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S274"
            // 					or 'S436';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S436"
            // 					or 'S626';
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S626"
            // 					or 'S738';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S738"
            // 					or 'S741';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S741"
            // 					or 'S752';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S752"
            // 					or 'S756';
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S756"
            // 					or 'S768';
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S768"
            // 					or 'S783';
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S783"
            // 					or 'S785';
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S785"
            // 					or 'W777';
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "W777"
            //         then;
            )
            {
                objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG = "R";
            }
        }

        // confidentially_check_ministry_codes.rtn
        private async Task ga11a_99_exit()
        {
            Util.Trakker(++ctr, "ga11a_99_exit");

            //     exit.;
        }

        // confidentially_check_rma_codes.rtn
        private async Task ga11b_check_conf_rma()
        {
            Util.Trakker(++ctr, "ga11b_check_conf_rma");

            // hold_oma_cd_num_grp[ss_clmdtl_oma] = Util.Str(hold_oma_cd_num_1[ss_clmdtl_oma]) + Util.Str(hold_oma_cd_num_2[ss_clmdtl_oma]) + Util.Str(hold_oma_cd_num_3[ss_clmdtl_oma]);
            // hold_oma_cd_grp[ss_clmdtl_oma] = hold_oma_cd_alpha[ss_clmdtl_oma] + hold_oma_cd_num_grp[ss_clmdtl_oma];


            //  if hold-diag-cd (ss-clmdtl-oma) = 632 or 302 then            
            if (hold_diag_cd[ss_clmdtl_oma] == 632 || hold_diag_cd[ss_clmdtl_oma] == 302)
            {
                objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG = "R";
            }
            //  else if hold-oma-cd (ss-clmdtl-oma) =  'G362' then            
            else if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G362")
            {
                objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG = "R";
            }
        }

        // confidentially_check_rma_codes.rtn
        private async Task ga11b_99_exit()
        {
            Util.Trakker(++ctr, "ga11b_99_exit");

            //     exit.;
        }

        private async Task<string> ha0_proc_rec_type_detail()
        {
            Util.Trakker(++ctr, "ha0_proc_rec_type_detail");

            //     add 1        to                   ss-clmdtl-oma.;
            ss_clmdtl_oma++;

            //hold_oma_cd_grp[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_oma_svc_code;
            await hold_oma_cd_grp_Set(ss_clmdtl_oma, objUnpriced_claims_record.Unpriced_itm1_oma_svc_code);

            hold_oma_cd_alpha[ss_clmdtl_oma] = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(0, 1);
            hold_oma_cd_num_grp[ss_clmdtl_oma] = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(1, 3);
            hold_oma_cd_num_1[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).PadRight(3).Substring(0, 1));
            hold_oma_cd_num_2[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).PadRight(3).Substring(1, 1));
            hold_oma_cd_num_3[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).PadRight(3).Substring(2, 1));

            hold_oma_suff[ss_clmdtl_oma] = Util.Str(objUnpriced_claims_record.Unpriced_itm1_oma_svc_suff);

            //   perform la4-oma-code-edit   	thru la4-99-exit.;
            await la4_oma_code_edit();
            await la4_99_exit();


            //   if hold-oma-cd(ss-clmdtl-oma) =;
            if (
            // 		     "E400";
               await hold_oma_cd_grp(ss_clmdtl_oma) == "E400"
            //                   or "E409";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "E409"
            //                   or "E412";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "E412"
            //                   or "E401";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E401"
            //                   or "E410";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E410"
            //                   or "E413";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E413"
            //                   or "E420";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E420"
            //     then;
            )
            {
                ws_special_add_on_cd_entered = "Y";
            }


            // 	replacing  ==ws-oma-cd== by ==hold-oma-cd(ss-clmdtl-oma)==.;

            hold_fee_incoming[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_oma_amt_billed/100;
            hold_sv_nbr_serv_incoming[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_nbr_serv;

            hold_override_price[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_override_price;

            hold_bilateral[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_bilateral;

            //     inspect unpriced-itm1-oma-amt-billed replacing all space-char by zeros.;
            objUnpriced_claims_record.Unpriced_itm1_oma_amt_billed = Util.NumDec(Util.Str(objUnpriced_claims_record.Unpriced_itm1_oma_amt_billed).Replace(' ', '0')); //check the value on this...

            // if unpriced-itm1-oma-amt-billed not = 0 then            
            if (objUnpriced_claims_record.Unpriced_itm1_oma_amt_billed != 0)
            {
                hold_fee_incoming[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_oma_amt_billed/100;
            }
            else
            {
                hold_fee_oma[ss_clmdtl_oma] = 0;
                hold_basic_prof[ss_clmdtl_oma] = 0;
                hold_fee_ohip[ss_clmdtl_oma] = 0;
            }

            hold_sv_nbr_serv[ss_clmdtl_oma] = Util.NumInt(objUnpriced_claims_record.Unpriced_itm1_nbr_serv);

            hold_sv_nbr[ss_clmdtl_oma, 1] = 0;
            hold_sv_nbr[ss_clmdtl_oma, 2] = 0;
            hold_sv_nbr[ss_clmdtl_oma, 3] = 0;
            hold_sv_day_num[ss_clmdtl_oma, 1] = 0;
            hold_sv_day_num[ss_clmdtl_oma, 2] = 0;
            hold_sv_day_num[ss_clmdtl_oma, 3] = 0;

            //  if unpriced-itm1-override-price = "Y" then            
            if (Util.Str(objUnpriced_claims_record.Unpriced_itm1_override_price).ToUpper() == "Y")
            {
                hold_sv_day[ss_clmdtl_oma, 1] = "OP";
            }
            //  else if unpriced-itm1-bilateral = "Y" then            
            else if (Util.Str(objUnpriced_claims_record.Unpriced_itm1_bilateral).ToUpper() == "Y")
            {
                hold_sv_day[ss_clmdtl_oma, 1] = "BI";
            }

            objUnpriced_claims_record.Unpriced_itm1_svc_date_grp = Util.Str(objUnpriced_claims_record.Unpriced_itm1_svc_date_yy).PadLeft(4,'0') + Util.Str(objUnpriced_claims_record.Unpriced_itm1_svc_date_mm).PadLeft(2,'0') + Util.Str(objUnpriced_claims_record.Unpriced_itm1_svc_date_dd).PadLeft(2,'0');
            hold_sv_date_grp[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm1_svc_date_grp; // Unpriced_itm1_svc_date;
            hold_sv_date_yy[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(0, 4)); // children..
            hold_sv_date_yy_r_grp[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(0, 4));
            hold_sv_date_yy_12[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_yy_r_grp[ss_clmdtl_oma]).PadRight(4).Substring(0, 2));
            hold_sv_date_yy_34[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_yy_r_grp[ss_clmdtl_oma]).PadRight(4).Substring(2, 2));
            hold_sv_date_mm[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(4, 2));
            hold_sv_date_dd[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(6, 2));

            hold_diag_cd[ss_clmdtl_oma] = Util.NumInt(objUnpriced_claims_record.Unpriced_itm1_diag_cd);
            objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(0, 1);
            objFee_mstr_rec.FILLER_NUMERIC = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(1, 3);

            //     perform xc0-check-oma-code          thru xc0-99-exit.;
            await xc0_check_oma_code();
            await xc0_99_exit();

            //     perform ga11-check-for-confidentially thru ga11-99-exit.;
            await ga11_check_for_confidentially();
            await ga11_99_exit();

            //     perform ha12-check-for-sli-oma thru ha12-99-exit.;
            await ha12_check_for_sli_oma();
            await ha12_99_exit();

            //     perform ha1-move-pricing-to-hold	thru ha1-99-exit.;
            await ha1_move_pricing_to_hold();

            hold_sort_key_1[ss_clmdtl_oma] = Util.Str(hold_sv_date_dd[ss_clmdtl_oma]).PadLeft(2, '0') + Util.Str(hold_icc_sec[ss_clmdtl_oma], 2) + Util.Str(hold_icc_grp[ss_clmdtl_oma]).PadLeft(2, '0');
            await ha1_99_exit();

            //  if unpriced-itm2-oma-svc-code = spaces then 
            if (string.IsNullOrWhiteSpace(objUnpriced_claims_record.Unpriced_itm2_oma_svc_code))
            {
                // 	   go to ha0-90-after-2nd-detail.;                
                return "ha0_90_after_2nd_detail";
            }

            //   add 1    to   ss-clmdtl-oma.;
            ss_clmdtl_oma++;

            //hold_oma_cd_grp[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_oma_svc_code;
            await hold_oma_cd_grp_Set(ss_clmdtl_oma, objUnpriced_claims_record.Unpriced_itm2_oma_svc_code);
            hold_oma_cd_alpha[ss_clmdtl_oma] = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(0, 1);
            hold_oma_cd_num_grp[ss_clmdtl_oma] = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(1, 3);
            hold_oma_cd_num_1[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).PadRight(3).Substring(0, 1));
            hold_oma_cd_num_2[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).PadRight(3).Substring(1, 1));
            hold_oma_cd_num_3[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).PadRight(3).Substring(2, 1));

            hold_oma_suff[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_oma_svc_suff;

            //   perform la4-oma-code-edit   	thru la4-99-exit.;
            await la4_oma_code_edit();
            await la4_99_exit();

            //     if hold-oma-cd(ss-clmdtl-oma) =;
            if (
            // 		     "E400";
               await hold_oma_cd_grp(ss_clmdtl_oma) == "E400"
            //                   or "E409";
              || await hold_oma_cd_grp(ss_clmdtl_oma) == "E409"
            //                   or "E412";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "E412"
            //                   or "E401";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "E401"
            //                   or "E410";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "E410"
            //                   or "E413";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E413"
            //                   or "E420";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "E420"
            //     then;
            )
            {
                ws_special_add_on_cd_entered = "Y";
            }


            // 	replacing  ==ws-oma-cd== by ==hold-oma-cd(ss-clmdtl-oma)==.;

            hold_fee_incoming[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_oma_amt_billed/100;
            hold_sv_nbr_serv_incoming[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_nbr_serv;

            hold_override_price[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_override_price;
            hold_bilateral[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_bilateral;

            //  if unpriced-itm2-oma-amt-billed not = 0 then   
            if (Util.NumInt(objUnpriced_claims_record.Unpriced_itm2_oma_amt_billed) != 0)
            {
                hold_fee_incoming[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_oma_amt_billed/100;
            }
            else
            {
                hold_fee_oma[ss_clmdtl_oma] = 0;
                hold_basic_prof[ss_clmdtl_oma] = 0;
                hold_fee_ohip[ss_clmdtl_oma] = 0;
            }

            hold_sv_nbr_serv[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_nbr_serv;

            hold_sv_nbr[ss_clmdtl_oma, 1] = 0;
            hold_sv_nbr[ss_clmdtl_oma, 2] = 0;
            hold_sv_nbr[ss_clmdtl_oma, 3] = 0;
            hold_sv_day_num[ss_clmdtl_oma, 1] = 0;
            hold_sv_day_num[ss_clmdtl_oma, 2] = 0;
            hold_sv_day_num[ss_clmdtl_oma, 3] = 0;

            //  objUnpriced_claims_record.Unpriced_itm2_svc_date_grp = Util.Str(objUnpriced_claims_record.Unpriced_itm2_svc_date_yy).PadLeft(4,'0') + Util.Str(objUnpriced_claims_record.Unpriced_itm2_svc_date_mm).PadLeft(2,'0') + Util.Str(objUnpriced_claims_record.Unpriced_itm2_svc_date_dd).PadLeft(2,'0');
            ///hold_sv_date_grp[ss_clmdtl_oma] = objUnpriced_claims_record.Unpriced_itm2_svc_date_grp; // Unpriced_itm2_svc_date;
            hold_sv_date_yy[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(0, 4)); // children..
            hold_sv_date_yy_r_grp[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(0, 4));
            hold_sv_date_yy_12[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_yy_r_grp[ss_clmdtl_oma]).PadRight(4).Substring(0, 2));
            hold_sv_date_yy_34[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_yy_r_grp[ss_clmdtl_oma]).PadRight(4).Substring(2, 2));
            hold_sv_date_mm[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(4, 2));
            hold_sv_date_dd[ss_clmdtl_oma] = Util.NumInt(Util.Str(hold_sv_date_grp[ss_clmdtl_oma]).PadRight(8).Substring(6, 2));

            hold_diag_cd[ss_clmdtl_oma] = Util.NumInt(objUnpriced_claims_record.Unpriced_itm2_diag_cd);

            // if unpriced-itm2-override-price = "Y"  then            
            if (Util.Str(objUnpriced_claims_record.Unpriced_itm2_override_price).ToUpper() == "Y")
            {
                hold_sv_day[ss_clmdtl_oma, 1] = "OP";
            }
            // else  if unpriced-itm2-bilateral = "Y" then            
            else if (Util.Str(objUnpriced_claims_record.Unpriced_itm2_bilateral).ToUpper() == "Y")
            {
                hold_sv_day[ss_clmdtl_oma, 1] = "BI";
            }

            objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(0, 1);
            objFee_mstr_rec.FILLER_NUMERIC = Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).PadRight(4).Substring(1, 3);

            //     perform xc0-check-oma-code          thru xc0-99-exit.;
            await xc0_check_oma_code();
            await xc0_99_exit();

            //     perform ga11-check-for-confidentially thru ga11-99-exit.;
            await ga11_check_for_confidentially();
            await ga11_99_exit();

            //     perform ha12-check-for-sli-oma thru ha12-99-exit.;
            await ha12_check_for_sli_oma();
            await ha12_99_exit();

            //     perform ha1-move-pricing-to-hold	thru ha1-99-exit.;
            await ha1_move_pricing_to_hold();
            await ha1_99_exit();

            return string.Empty;
        }

        private async Task ha0_90_after_2nd_detail()
        {
            Util.Trakker(++ctr, "ha0_90_after_2nd_detail");

        }

        private async Task ha0_99_exit()
        {
            Util.Trakker(++ctr, "ha0_99_exit");
            //     exit.;
        }

        private async Task ha1_move_pricing_to_hold()
        {
            Util.Trakker(++ctr, "ha1_move_pricing_to_hold");

            hold_line_no[ss_clmdtl_oma] = ss_clmdtl_oma;

            hold_oma_rec_ind[ss_clmdtl_oma, ss_tech_ind] = Util.Str(objFee_mstr_rec.FEE_TECH_IND);
            hold_oma_rec_ind[ss_clmdtl_oma, ss_diag_ind] = Util.Str(objFee_mstr_rec.FEE_DIAG_IND);
            hold_oma_rec_ind[ss_clmdtl_oma, ss_phy_ind] = Util.Str(objFee_mstr_rec.FEE_PHY_IND);
            hold_oma_rec_ind[ss_clmdtl_oma, ss_hosp_nbr_ind] = Util.Str(objFee_mstr_rec.FEE_HOSP_NBR_IND);
            hold_oma_rec_ind[ss_clmdtl_oma, ss_i_o_ind] = Util.Str(objFee_mstr_rec.FEE_I_O_IND);
            hold_oma_rec_ind[ss_clmdtl_oma, ss_admit_ind] = Util.Str(objFee_mstr_rec.FEE_ADMIT_IND);
            hold_oma_rec_ind[ss_clmdtl_oma, ss_special_m_suffix_ind] = Util.Str(objFee_mstr_rec.FEE_SPECIAL_M_SUFFIX_IND);

            hold_icc_sec[ss_clmdtl_oma] = Util.Str(objFee_mstr_rec.FEE_ICC_SEC);
            hold_icc_grp[ss_clmdtl_oma] = Util.Str(objFee_mstr_rec.FEE_ICC_GRP).PadLeft(2, '0');

            // if hold-sv-date (ss-clmdtl-oma) < fee-effective-date then 
            hold_sv_date_grp[ss_clmdtl_oma] = Util.Str(hold_sv_date_yy[ss_clmdtl_oma]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss_clmdtl_oma]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss_clmdtl_oma]).PadLeft(2,'0');
            if (Util.NumInt(hold_sv_date_grp[ss_clmdtl_oma]) < Util.NumInt(Util.Str(objFee_mstr_rec.FEE_DATE_YY.ToString()).PadLeft(4,'0') + Util.Str(objFee_mstr_rec.FEE_DATE_MM.ToString()).PadLeft(2,'0') + Util.Str(objFee_mstr_rec.FEE_DATE_DD.ToString()).PadLeft(2,'0')))
            {
                hold_ss_curr_prev[ss_clmdtl_oma] = prev;
            }
            else
            {
                hold_ss_curr_prev[ss_clmdtl_oma] = curr;
            }

            ss_curr_prev = hold_ss_curr_prev[ss_clmdtl_oma];

            //move fee-1(ss - curr - prev, oma)  to hold-oma - fee - 1(ss - clmdtl - oma, oma).
            hold_oma_fee_1[ss_clmdtl_oma, oma] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, ss_curr_prev, oma)/100; // fee_1[ss_curr_prev, oma];

            //move fee - 2(ss - curr - prev, oma)  to hold-oma - fee - 2(ss - clmdtl - oma, oma).
            hold_oma_fee_2[ss_clmdtl_oma, oma] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(objFee_mstr_rec, ss_curr_prev, oma)/100;

            //move fee-anae(ss - curr - prev, oma)  to hold-oma - fee - anae(ss - clmdtl - oma, oma).
            hold_oma_fee_anae[ss_clmdtl_oma, oma] = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(objFee_mstr_rec, ss_curr_prev, oma));

            //move fee - asst(ss - curr - prev, oma)  to hold-oma - fee - asst(ss - clmdtl - oma, oma).
            hold_oma_fee_asst[ss_clmdtl_oma, oma] = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(objFee_mstr_rec, ss_curr_prev, oma));

            //move fee-1(ss - curr - prev, ohip)  to hold-oma - fee - 1(ss - clmdtl - oma, ohip).
            hold_oma_fee_1[ss_clmdtl_oma, ohip] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(objFee_mstr_rec, ss_curr_prev, ohip)/100;

            //move fee - 2(ss - curr - prev, ohip)  to hold-oma - fee - 2(ss - clmdtl - oma, ohip).
            hold_oma_fee_2[ss_clmdtl_oma, ohip] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(objFee_mstr_rec, ss_curr_prev, ohip)/100;

            hold_oma_fee_anae[ss_clmdtl_oma, ohip] = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(objFee_mstr_rec, ss_curr_prev, ohip));

            hold_oma_fee_asst[ss_clmdtl_oma, ohip] = Util.NumInt(base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(objFee_mstr_rec, ss_curr_prev, ohip));

            //move fee-min(ss - curr - prev, ohip)  to hold-fee - min(ss - clmdtl - oma, ohip).
            hold_fee_min[ss_clmdtl_oma, ohip] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Min_GET(objFee_mstr_rec, ss_curr_prev, ohip);

            //move fee - max(ss - curr - prev, ohip)  to hold-fee - max(ss - clmdtl - oma, ohip).
            hold_fee_max[ss_clmdtl_oma, ohip] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Max_GET(objFee_mstr_rec, ss_curr_prev, ohip);

            //move fee-min(ss - curr - prev, ohip) to hold-fee - min(ss - clmdtl - oma, oma).
            hold_fee_min[ss_clmdtl_oma, oma] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Min_GET(objFee_mstr_rec, ss_curr_prev, ohip);

            //move fee - max(ss - curr - prev, ohip) to hold-fee - max(ss - clmdtl - oma, oma).
            hold_fee_max[ss_clmdtl_oma, oma] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Max_GET(objFee_mstr_rec, ss_curr_prev, ohip);


            hold_oma_add_on_cd[ss_clmdtl_oma, 1] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 1);  // fee_add_on_cd[ss_curr_prev,1];
            hold_oma_add_on_cd[ss_clmdtl_oma, 2] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 2);
            hold_oma_add_on_cd[ss_clmdtl_oma, 3] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 3);
            hold_oma_add_on_cd[ss_clmdtl_oma, 4] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 4);
            hold_oma_add_on_cd[ss_clmdtl_oma, 5] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 5);
            hold_oma_add_on_cd[ss_clmdtl_oma, 6] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 6);
            hold_oma_add_on_cd[ss_clmdtl_oma, 7] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 7);
            hold_oma_add_on_cd[ss_clmdtl_oma, 8] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 8);
            hold_oma_add_on_cd[ss_clmdtl_oma, 9] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 9);
            hold_oma_add_on_cd[ss_clmdtl_oma, 10] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(objFee_mstr_rec, ss_curr_prev, 10);

            //move fee-oma - ind - card - requireds(ss - curr - prev) to hold-oma - ind - card - requireds(ss - clmdtl - oma).  //TODO... Not sure on which column to get the value. aside from Current and Previous...????
            hold_oma_ind_card_requireds[ss_clmdtl_oma, 1] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Requireds_GET(objFee_mstr_rec, ss_curr_prev, 1);
            hold_oma_ind_card_requireds[ss_clmdtl_oma, 2] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Requireds_GET(objFee_mstr_rec, ss_curr_prev, 2);
            hold_oma_ind_card_requireds[ss_clmdtl_oma, 3] = base.FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Requireds_GET(objFee_mstr_rec, ss_curr_prev, 3);

            // if fee-add-on-perc-or-flat-ind(ss-curr-prev) = "P"  or "F" then     
            if (Util.Str(FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(objFee_mstr_rec, ss_curr_prev)).ToUpper() == "P" || Util.Str(FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(objFee_mstr_rec, ss_curr_prev)).ToUpper() == "F")
            {
                //    perform ha1a-addon-fee-fix	thru ha1a-99-exit.;
                await ha1a_addon_fee_fix();
                await ha1a_99_exit();
            }

            // if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P" or "F" then            
            if (Util.Str(FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(objFee_mstr_rec, ss_curr_prev)).ToUpper() == "P" || Util.Str(FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(objFee_mstr_rec, ss_curr_prev)).ToUpper() == "F")
            {
                hold_oma_rec_ind[ss_clmdtl_oma, ss_add_on_perc_or_flat_ind] = FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(objFee_mstr_rec, ss_curr_prev);
            }
            else
            {
                //    move " " to hold-oma-rec-ind (ss-clmdtl-oma,ss-add-on-perc-or-flat-ind).  
                hold_oma_rec_ind[ss_clmdtl_oma, ss_add_on_perc_or_flat_ind] = "";
            }
        }

        private async Task ha1_99_exit()
        {
            Util.Trakker(++ctr, "ha1_99_exit");
            //     exit.;
        }

        private async Task ha1a_addon_fee_fix()
        {
            Util.Trakker(++ctr, "ha1a_addon_fee_fix");

            //  if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"  then
            if (Util.Str(FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(objFee_mstr_rec, ss_curr_prev)).ToUpper() == "P")
            {
                //   compute hold-oma-fee-1 (ss-clmdtl-oma,  oma) = hold-oma-fee-1 (ss-clmdtl-oma,  oma) / 100;
                hold_oma_fee_1[ss_clmdtl_oma, oma] = hold_oma_fee_1[ss_clmdtl_oma, oma] / 100;
                //   compute hold-oma-fee-2 (ss-clmdtl-oma,  oma) = hold-oma-fee-2 (ss-clmdtl-oma,  oma) / 100;
                hold_oma_fee_2[ss_clmdtl_oma, oma] = hold_oma_fee_2[ss_clmdtl_oma, oma] / 100;
                //   compute hold-oma-fee-1 (ss-clmdtl-oma, ohip) =  hold-oma-fee-1 (ss-clmdtl-oma, ohip) / 100;
                hold_oma_fee_1[ss_clmdtl_oma, ohip] = hold_oma_fee_1[ss_clmdtl_oma, ohip] / 100;
                //   compute hold-oma-fee-2 (ss-clmdtl-oma, ohip) = hold-oma-fee-2 (ss-clmdtl-oma, ohip) / 100.;
                hold_oma_fee_2[ss_clmdtl_oma, ohip] = hold_oma_fee_2[ss_clmdtl_oma, ohip] / 100;
            }

            // if  hold-oma-fee-1 (ss-clmdtl-oma,  oma) = 0 then
            if (hold_oma_fee_1[ss_clmdtl_oma, oma] == 0)
            {
                //      move  hold-oma-fee-2 (ss-clmdtl-oma,  oma)	to hold-oma-fee-1(ss-clmdtl-oma,  oma)
                hold_oma_fee_1[ss_clmdtl_oma, oma] = hold_oma_fee_2[ss_clmdtl_oma, oma];
            }
            // else if        hold-oma-fee-2 (ss-clmdtl-oma,  oma) = 0  then
            else if (hold_oma_fee_2[ss_clmdtl_oma, oma] == 0)
            {
                //  	 move  hold-oma-fee-1 (ss-clmdtl-oma,  oma)	to hold-oma-fee-2(ss-clmdtl-oma,  oma) 
                hold_oma_fee_2[ss_clmdtl_oma, oma] = hold_oma_fee_1[ss_clmdtl_oma, oma];
            }
            else
            {
                //             next sentence.;
            }

            //  if   hold-oma-fee-1 (ss-clmdtl-oma, ohip) = 0  then
            if (hold_oma_fee_1[ss_clmdtl_oma, ohip] == 0)
            {
                //       move  hold-oma-fee-2 (ss-clmdtl-oma, ohip)	to hold-oma-fee-1(ss-clmdtl-oma, ohip) 
                hold_oma_fee_1[ss_clmdtl_oma, ohip] = hold_oma_fee_2[ss_clmdtl_oma, ohip];
            }
            //  else  if        hold-oma-fee-2 (ss-clmdtl-oma, ohip) = 0  then
            else if (hold_oma_fee_2[ss_clmdtl_oma, ohip] == 0)
            {
                //      move  hold-oma-fee-1 (ss-clmdtl-oma, ohip)	to hold-oma-fee-2(ss-clmdtl-oma, ohip) 
                hold_oma_fee_2[ss_clmdtl_oma, ohip] = hold_oma_fee_1[ss_clmdtl_oma, ohip];
            }
            else
            {
                //       next sentence.;
            }
        }

        private async Task ha1a_99_exit()
        {
            Util.Trakker(++ctr, "ha1a_99_exit");

            //     exit.;
        }

        // newu701_oscar_dtl_edit_check.rtn
        private async Task ha12_check_for_sli_oma()
        {
            Util.Trakker(++ctr, "ha12_check_for_sli_oma");

            //objSli_oma_code_suff_rec.sli_oma_code = hold_oma_cd[ss_clmdtl_oma];
            //objSli_oma_code_suff_rec.sli_oma_suff = hold_oma_suff[ss_clmdtl_oma];
            //objSli_oma_code_suff_rec.sli_code = objLoc_mstr_rec.loc_service_location_indicator;

            //     read  sli-oma-code-suff-mstr;
            // 	invalid key;
            // 	    go to ha12-99-exit.;

            objSli_oma_code_suff_rec = new F201_SLI_OMA_CODE_SUFF
            {
                WhereClmdtl_oma_cd = await hold_oma_cd_grp(ss_clmdtl_oma),
                WhereClmdtl_oma_suff = hold_oma_suff[ss_clmdtl_oma],
                WhereLoc_service_location_indicator = objLoc_mstr_rec.LOC_SERVICE_LOCATION_INDICATOR
            }.Collection().FirstOrDefault();

            if (objSli_oma_code_suff_rec == null)
            {
                // 	    go to ha12-99-exit.;
                await ha12_99_exit();
                return;
            }

            //  if sli-admit-ind = 'Y' and (hdr-admit-date = spaces or zeroes) then 
            hdr_admit_date_grp = Util.Str(hdr_admit_yy).PadLeft(4, '0') + Util.Str(hdr_admit_mm).PadLeft(2, '0') + Util.Str(hdr_admit_dd).PadLeft(2, '0');
            if (Util.Str(objSli_oma_code_suff_rec.FEE_ADMIT_IND).ToUpper() == "Y" && (string.IsNullOrWhiteSpace(hdr_admit_date_grp) || Util.NumInt(hdr_admit_date_grp) == 0))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 118;
                //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //  if sli-admit-ind = 'N' and (hdr-admit-date not = spaces and not = zeroes) then
            hdr_admit_date_grp = Util.Str(hdr_admit_yy).PadLeft(4, '0') + Util.Str(hdr_admit_mm).PadLeft(2, '0') + Util.Str(hdr_admit_dd).PadLeft(2, '0');
            // if (Util.Str(objSli_oma_code_suff_rec.FEE_ADMIT_IND).ToUpper() == "N" && (!string.IsNullOrWhiteSpace(hdr_admit_date_grp) || Util.NumInt(hdr_admit_date_grp) != 0))
            if (Util.Str(objSli_oma_code_suff_rec.FEE_ADMIT_IND).ToUpper() == "N" && (Util.NumInt(hdr_admit_date_grp) != 0))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 119;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;     
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        // newu701_oscar_dtl_edit_check.rtn
        private async Task ha12_99_exit()
        {
            Util.Trakker(++ctr, "ha12_99_exit");

            //    exit.;
        }

        // newu701_oscar_dtl_edit_check.rtn
        private async Task hb0_build_susp_dtl_rec_dtl()
        {
            Util.Trakker(++ctr, "hb0_build_susp_dtl_rec_dtl");

            //objSuspend_dtl_rec.suspend_dtl_rec = "";
            objSuspend_dtl_rec = new F002_SUSPEND_DTL();

            objSuspend_dtl_rec.CLMDTL_SV_DAY1 = Util.NumDec(hold_sv_day[ss_write_dtl, 1]);
            objSuspend_dtl_rec.CLMDTL_SV_DAY1 = Util.NumDec(hold_sv_day[ss_write_dtl, 2]);
            objSuspend_dtl_rec.CLMDTL_SV_DAY1 = Util.NumDec(hold_sv_day[ss_write_dtl, 3]);

            objSuspend_dtl_rec.CLMDTL_SV_NBR1 = 0;
            objSuspend_dtl_rec.CLMDTL_SV_NBR2 = 0;
            objSuspend_dtl_rec.CLMDTL_SV_NBR_3 = 0;

            objSuspend_dtl_rec.CLMDTL_BATCH_NBR = objSuspend_hdr_rec.CLMHDR_BATCH_NBR;

            objSuspend_dtl_rec.CLMDTL_OMA_CD = await hold_oma_cd_grp(ss_write_dtl);
            objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(await hold_oma_cd_grp(ss_write_dtl)).PadRight(4).Substring(0, 1);
            objFee_mstr_rec.FILLER_NUMERIC = Util.Str(await hold_oma_cd_grp(ss_write_dtl)).PadRight(4).Substring(1, 3);

            objSuspend_dtl_rec.CLMDTL_OMA_SUFF = hold_oma_suff[ss_write_dtl];
            objSuspend_dtl_rec.CLMDTL_ADJ_NBR = 0;
            objSuspend_dtl_rec.CLMDTL_REV_GROUP_CD = "0";
            objSuspend_dtl_rec.CLMDTL_AGENT_CD = objSuspend_hdr_rec.CLMHDR_AGENT_CD;
            objSuspend_dtl_rec.CLMDTL_ADJ_CD = objSuspend_hdr_rec.CLMHDR_ADJ_CD;

            // if  tech-prof-suff-rule-applied and clmhdr-status <> "I" then 
            if (flag_tech_prof_suffix_rule.Equals(tech_prof_suff_rule_applied) && Util.Str(objSuspend_hdr_rec.CLMHDR_STATUS).ToUpper() != "I")
            {
                objSuspend_dtl_rec.CLMDTL_STATUS = "U";
                objSuspend_hdr_rec.CLMHDR_STATUS = "U";
            }
            else
            {
                objSuspend_dtl_rec.CLMDTL_STATUS = objSuspend_hdr_rec.CLMHDR_STATUS;
            }

            //  perform gb1-verify-dtl-diag-cd thru gb1-99-exit.;
            await gb1_verify_dtl_diag_cd();
            await gb1_99_exit();

            // if  hold-sv-nbr-serv(ss-write-dtl) = 0 and not price-only-claim  then            
            if (hold_sv_nbr_serv[ss_write_dtl] == 0 && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line thru xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 38;
                err_nbr_of_serv = Util.Str(hold_sv_nbr_serv[ss_write_dtl]);
                //   perform zb0-build-write-err-rpt-line thru zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
            else
            {
                //     add  hold-sv-nbr-serv(ss-write-dtl) to   ctr-tot-svcs-read            
                ctr_tot_svcs_read += hold_sv_nbr_serv[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_NBR_SERV = hold_sv_nbr_serv[ss_write_dtl];
            }


            // if hold-fee-ohip     (ss-write-dtl)  = 0 and not price-only-claim  then            \
            if (hold_fee_ohip[ss_write_dtl] == 0 && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line thru xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 39;
                err_fee_billed = Util.NumInt(hold_fee_ohip[ss_write_dtl]);
                //    perform zb0-build-write-err-rpt-line thru zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            objSuspend_dtl_rec.CLMDTL_FEE_OMA = hold_fee_oma[ss_write_dtl];
            objSuspend_dtl_rec.CLMDTL_FEE_OHIP = hold_fee_ohip[ss_write_dtl];

            objSuspend_dtl_rec.CLMDTL_AMT_TECH_BILLED = hold_priced_tech[ss_write_dtl];

            //   perform xc0-check-oma-code          thru xc0-99-exit.;
            await xc0_check_oma_code();
            await xc0_99_exit();

            //  if    (   fee-spec-fr < batch-specialty;
            if ((Util.NumInt(objFee_mstr_rec.FEE_SPEC_FR) < batch_specialty
            //            or fee-spec-fr = batch-specialty);
                  || Util.NumInt(objFee_mstr_rec.FEE_SPEC_FR) == batch_specialty)
            //       and (   fee-spec-to = batch-specialty;
                  && (Util.NumInt(objFee_mstr_rec.FEE_SPEC_TO) == batch_specialty
            //            or fee-spec-to > batch-specialty);
                  || Util.NumInt(objFee_mstr_rec.FEE_SPEC_TO) > batch_specialty)
            //     then;
            )
            {
                objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD = Util.NumInt(batch_specialty);
            }
            //     else if not price-only-claim then            
            else if (!Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //        perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 21;
                err_21_value_1 = Util.Str(batch_specialty);

                err_21_value_2 = await hold_oma_cd_grp(ss_write_dtl);
                err_21_value_3 = Util.Str(objFee_mstr_rec.FEE_SPEC_FR);
                err_21_value_4 = Util.Str(objFee_mstr_rec.FEE_SPEC_TO);
                //          perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD = batch_specialty;
            }


            //  if hdr-refer-pract-nbr =   spaces or zeros  then            
            if (string.IsNullOrWhiteSpace(hdr_refer_pract_nbr.ToString()) || Util.NumInt(hdr_refer_pract_nbr) == 0)
            {
                // 	     if  hold-oma-cd-alpha (ss-write-dtl) = 'G' or 'J' or 'X' and fee-phy-ind = 'Y' and not price-only-claim then            
                if (Util.Str(hold_oma_cd_alpha[ss_write_dtl]).ToUpper() == "G" || Util.Str(hold_oma_cd_alpha[ss_write_dtl]).ToUpper() == "J" || Util.Str(hold_oma_cd_alpha[ss_write_dtl]).ToUpper() == "X" && Util.Str(objFee_mstr_rec.FEE_PHY_IND).ToUpper() == "Y" && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR = batch_provider_nbr;
                }
                // 	     else if    fee-phy-ind = "Y" and not price-only-claim then            
                else if (Util.Str(objFee_mstr_rec.FEE_PHY_IND).ToUpper() == "Y" && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 22;

                    err_22_oma_cd = await hold_oma_cd_grp(ss_write_dtl);
                    err_22_msg = "REFERRING PHYSICIAN";
                    //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }


            //  if hold-diag-cd(ss-write-dtl) =   spaces  or zeros then            
            if (string.IsNullOrWhiteSpace(hold_diag_cd[ss_write_dtl].ToString()) || Util.NumInt(hold_diag_cd[ss_write_dtl]) == 0)
            {
                //      if  fee-diag-ind = "Y" and hold-oma-suff (ss-write-dtl)  = "A" or "M"  and not price-only-claim   then            
                if (Util.Str(objFee_mstr_rec.FEE_DIAG_IND).ToUpper() == "Y" && hold_oma_suff[ss_write_dtl] == "A" || hold_oma_suff[ss_write_dtl] == "M" && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //        perform xb0-print-warning-line  thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 22;

                    err_22_oma_cd = await hold_oma_cd_grp(ss_write_dtl);
                    err_22_msg = "DIAGNOSTIC CODE";
                    //       perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }


            //  if hdr-i-o-ind =   spaces or zeros then 
            if (string.IsNullOrWhiteSpace(hdr_i_o_ind) || hdr_i_o_ind == "0")
            {
                //      if (  fee-i-o-ind = "I" or fee-i-o-ind = "O" or fee-i-o-ind = "B" ) and not price-only-claim then 
                if ((Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() == "I" || Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() == "O" || Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() == "B") && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 22;

                    err_22_oma_cd = await hold_oma_cd_grp(ss_write_dtl);
                    //           move "IN/OUT PATIENT INDICATOR" to      err-22-msg;            
                    err_22_msg = "IN/OUT PATIENT INDICATOR";
                    //           perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
                else
                {
                    //           next sentence;
                }
            }
            // else if  ( ( hdr-i-o-ind = "I" and fee-i-o-ind <> "I" and fee-i-o-ind <> "B" ) or (    hdr-i-o-ind = "O" and fee-i-o-ind <> "O"  and fee-i-o-ind <> "B" )) and not price-only-claim  then            
            else if (((Util.Str(hdr_i_o_ind).ToUpper() == "I" && Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() != "I" && Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() != "B") || (Util.Str(hdr_i_o_ind).ToUpper() == "O" && Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() != "O" && Util.Str(objFee_mstr_rec.FEE_I_O_IND).ToUpper() != "B")) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line thru    xb0-99-exit;            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 49;
                err_49_oma_cd = Util.Str(objFee_mstr_rec.FEE_I_O_IND);
                err_49_hdr_cd = hdr_i_o_ind;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if (hdr-hosp-nbr = spaces or zero) and (hold-oma-cd(ss-write-dtl) >= 'K990' and hold-oma-cd(ss-write-dtl) <= 'K997') and not price-only-claim  then            

            if ((string.IsNullOrWhiteSpace(hdr_hosp_nbr) || hdr_hosp_nbr == "0") && (Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("K990") >= 0 && Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("K997") <= 0) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line thru    xb0-99-exit;            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 54;

                err_54_prem_code = await hold_oma_cd_grp(ss_write_dtl);
                //        perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if (hdr-hosp-nbr = 'G000' or 'M200' or 'H000' or 'J000') and (hold-oma-cd(ss-write-dtl) >= 'K990' and hold-oma-cd(ss-write-dtl) <= 'K997') and not price-only-claim   then            
            if ((Util.Str(hdr_hosp_nbr).ToUpper() == "G000" || Util.Str(hdr_hosp_nbr).ToUpper() == "M200" || Util.Str(hdr_hosp_nbr).ToUpper() == "H000" || Util.Str(hdr_hosp_nbr).ToUpper() == "J000") && (Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("K990") >= 0 && Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("K997") <= 0) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line thru    xb0-99-exit            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 55;
                err_55_hosp_code = hdr_hosp_nbr;
                //        move hold-oma-cd(ss-write-dtl)  to      err-55-prem-code;                
                err_55_prem_code = await hold_oma_cd_grp(ss_write_dtl);
                //        perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            //     if (hdr-loc-nbr not = '112' ) and;
            if ((hdr_loc_nbr != "112") &&
            //        (hdr-loc-nbr not = '153' ) and;
                (hdr_loc_nbr != "153") &&
            //        (hdr-loc-nbr not = '400' ) and;
                 (hdr_loc_nbr != "400") &&
                 //        (hdr-loc-nbr not = '250' ) and;
                 (hdr_loc_nbr != "250") &&
                //        (hdr-loc-nbr not = '422' ) and;
                (hdr_loc_nbr != "422") &&
                //        (hdr-loc-nbr not = '401' ) and;
                (hdr_loc_nbr != "401") &&
                //        (hdr-loc-nbr not = '055' ) and;
                (hdr_loc_nbr != "055") &&
                //        (hdr-loc-nbr not = '326' ) and;
                (hdr_loc_nbr != "326") &&
                //        (hdr-loc-nbr not = '122' ) and;
                (hdr_loc_nbr != "122") &&
                //        (hdr-loc-nbr not = '344' ) and;
                (hdr_loc_nbr != "344") &&
                //        (hdr-loc-nbr not = '111' ) and;
                (hdr_loc_nbr != "111") &&
                //        (hdr-loc-nbr not = '354' ) and;
                (hdr_loc_nbr != "354") &&
                //        (hdr-loc-nbr not = '333' ) and;
                (hdr_loc_nbr != "333") &&
                //        (hdr-loc-nbr not = '777' ) and;
                (hdr_loc_nbr != "777") &&
                //       (hold-oma-cd(ss-write-dtl) >= 'K990' and hold-oma-cd(ss-write-dtl) <= 'K997');
                (Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("K990") >= 0 && Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("K997") <= 0)
            //  	  and not price-only-claim;
                 && !Util.Str(flag_claim_source).Equals(price_only_claim)
            //   then;
            )
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line thru    xb0-99-exit            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 56;
                hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
                err_56_loc_code = hdr_loc_code_grp;
                //        move hold-oma-cd(ss-write-dtl)  to      err-56-prem-code;
                err_56_prem_code = await hold_oma_cd_grp(ss_write_dtl);
                //        perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if hdr-admit-date =  spaces or zeros then 
            hdr_admit_date_grp = Util.Str(hdr_admit_yy).PadLeft(4, '0') + Util.Str(hdr_admit_mm).PadLeft(2, '0') + Util.Str(hdr_admit_dd).PadLeft(2, '0');
            if (string.IsNullOrWhiteSpace(hdr_admit_date_grp) || Util.NumInt(hdr_admit_date_grp) == 0)
            {
                //     if  fee-admit-ind = "Y" and not price-only-claim  then            
                if (Util.Str(objFee_mstr_rec.FEE_ADMIT_IND).ToUpper() == "Y" && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //       perform xb0-print-warning-line thru    xb0-99-exit;            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 22;
                    err_22_oma_cd = await hold_oma_cd_grp(ss_write_dtl);
                    err_22_msg = "ADMIT DATE";
                    //       perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }


            // If  hold-oma-cd(ss-write-dtl) = 'C122' or 'C123' or 'C124' and hold-sv-date(ss-write-dtl) >= hdr-admit-date  and not price-only-claim   then             

            hdr_admit_date_grp = Util.Str(hdr_admit_yy).PadLeft(4, '0') + Util.Str(hdr_admit_mm).PadLeft(2, '0') + Util.Str(hdr_admit_dd).PadLeft(2, '0');
            hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2,'0');

            if (await hold_oma_cd_grp(ss_write_dtl) == "C122" || await hold_oma_cd_grp(ss_write_dtl) == "C123" || await hold_oma_cd_grp(ss_write_dtl) == "C124" && Util.NumInt(hold_sv_date_grp[ss_write_dtl]) >= Util.NumInt(hdr_admit_date_grp) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                ws_date_yymmdd_grp = hdr_admit_date_grp;
                ws_date_yy = Util.NumInt(Util.Str(ws_date_yymmdd_grp).PadRight(8).Substring(0, 4));
                ws_date_mm = Util.NumInt(Util.Str(ws_date_yymmdd_grp).PadRight(8).Substring(4, 2));
                ws_date_dd = Util.NumInt(Util.Str(ws_date_yymmdd_grp).PadRight(8).Substring(6, 2));

                //       compute date-difference-in-days =   (  (hold-sv-date-yy(ss-write-dtl) * 365)  + (hold-sv-date-mm(ss-write-dtl) *  30)  +  hold-sv-date-dd(ss-write-dtl) ) - (  (ws-date-yy * 365) + (ws-date-mm *  30)  +  ws-date-dd );            
                date_difference_in_days = ((hold_sv_date_yy[ss_write_dtl] * 365) + (hold_sv_date_mm[ss_write_dtl] * 30) + hold_sv_date_dd[ss_write_dtl]) - ((ws_date_yy * 365) + (ws_date_mm * 30) + ws_date_dd);

                //       if  hold-oma-cd(ss-write-dtl) = 'C122'  and  (date-difference-in-days < 1  or date-difference-in-days > 1) then 
                if (await hold_oma_cd_grp(ss_write_dtl) == "C122" && (date_difference_in_days < 1 || date_difference_in_days > 1))
                {
                    err_warn_msg = ws_error_literal;
                    //          perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 66;
                    //        perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
                //       else if  hold-oma-cd(ss-write-dtl) = 'C123' and  (date-difference-in-days < 2 or date-difference-in-days > 2) then            
                else if (await hold_oma_cd_grp(ss_write_dtl) == "C123" && (date_difference_in_days < 2 || date_difference_in_days > 2))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 67;
                    //         perform zb0-build-write-err-rpt-line  thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
                //      else if  hold-oma-cd(ss-write-dtl) = 'C124' and date-difference-in-days <= 1 then            
                else if (await hold_oma_cd_grp(ss_write_dtl) == "C124" && date_difference_in_days <= 1)
                {
                    err_warn_msg = ws_error_literal;
                    //        perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 68;
                    //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            ws_date_dd = hold_sv_date_dd[ss_write_dtl];
            ws_date_mm = hold_sv_date_mm[ss_write_dtl];
            ws_date_yy = hold_sv_date_yy[ss_write_dtl];

            //  perform xd0-verify-date              thru xd0-99-exit.;
            await xd0_verify_date();
            await xd0_99_exit();

            //  if invalid-date  and not price-only-claim  then      
            hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
            hdr_admit_date_grp = Util.Str(hdr_admit_yy).PadLeft(4, '0') + Util.Str(hdr_admit_mm).PadLeft(2, '0') + Util.Str(hdr_admit_dd).PadLeft(2, '0');
            if (flag_date.Equals(invalid_date) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 27;
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                err_27_service_date = hold_sv_date_grp[ss_write_dtl];
                //     perform zb0-build-write-err-rpt-line  thru    zb0-99-exit;            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
            //  else if  hold-sv-date(ss-write-dtl) > sys-date and not price-only-claim then            
            else if (Util.NumInt(hold_sv_date_grp[ss_write_dtl]) > sys_date && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 48;
                err_msg_svr_date = hold_sv_date_grp[ss_write_dtl];
                err_msg_sys_date = Util.Str(sys_date);
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //objSuspend_dtl_rec. clmdtl_sv_date = "????????";
                objSuspend_dtl_rec.CLMDTL_SV_YY = 00;
                objSuspend_dtl_rec.CLMDTL_SV_MM = 00;
                objSuspend_dtl_rec.CLMDTL_SV_DD = 00;

            }
            // else if ( (hold-sv-date-yy(ss-write-dtl) * 365) + (hold-sv-date-mm(ss-write-dtl) *  30) +  hold-sv-date-dd(ss-write-dtl)  > (doc-date-fac-term-yy * 365) + (doc-date-fac-term-mm * 30) + doc-date-fac-term-dd + 180 ) and doc-date-fac-term not = zeroes and not price-only-claim then            
            else if (((hold_sv_date_yy[ss_write_dtl] * 365) + (hold_sv_date_mm[ss_write_dtl] * 30) + hold_sv_date_dd[ss_write_dtl] > (Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_YY) * 365) + (Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_MM) * 30) + Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_DD) + 180) && Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_YY) != 0 && Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_MM) != 0 && Util.NumInt(objDoc_mstr_rec.DOC_DATE_FAC_TERM_DD) != 0 && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 128;
                err_128_term_date = Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_YY) + Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_MM) + Util.Str(objDoc_mstr_rec.DOC_DATE_FAC_TERM_DD);    //doc_date_fac_term;		 
                                                                                                                                                                                         //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                objSuspend_dtl_rec.CLMDTL_SV_DD = hold_sv_date_dd[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_SV_MM = hold_sv_date_mm[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_SV_YY = hold_sv_date_yy[ss_write_dtl];
            }
            // else if ( (hold-sv-date-yy(ss-write-dtl) * 365) + (hold-sv-date-mm(ss-write-dtl) *  30) +  232 + hold-sv-date-dd(ss-write-dtl) < (sys-yy * 365) + (SYS-MM * 30) + SYS-DD)  and not price-only-claim  then            
            else if (((hold_sv_date_yy[ss_write_dtl] * 365) + (hold_sv_date_mm[ss_write_dtl] * 30) + 232 + hold_sv_date_dd[ss_write_dtl] < (sys_yy * 365) + (sys_mm * 30) + sys_dd) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line thru    xb0-99-exit            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 24;
                err_24_service_date = hold_sv_date_grp[ss_write_dtl];
                //       perform zb0-build-write-err-rpt-line thru  zb0-99-exit;            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //       objSuspend_dtl_rec.clmdtl_sv_date = "????????";
                objSuspend_dtl_rec.CLMDTL_SV_YY = 0;
                objSuspend_dtl_rec.CLMDTL_SV_MM = 0;
                objSuspend_dtl_rec.CLMDTL_SV_DD = 0;
            }
            // else if  hdr-admit-date  not = spaces and hold-sv-date(ss-write-dtl) < hdr-admit-date  and not price-only-claim  then            
            else if (!string.IsNullOrWhiteSpace(hdr_admit_date_grp) && Util.NumInt(hold_sv_date_grp[ss_write_dtl]) < Util.NumInt(hdr_admit_date_grp) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line thru    xb0-99-exit;            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 44;
                err_44_service_date = hold_sv_date_grp[ss_write_dtl];
                err_44_admit_date = hdr_admit_date_grp;
                //     perform zb0-build-write-err-rpt-line  thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //       objSuspend_hdr_rec.clmhdr_date_admit = "????????";
                objSuspend_hdr_rec.CLMHDR_DATE_ADMIT = "????????";

                objSuspend_dtl_rec.CLMDTL_SV_DD = hold_sv_date_dd[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_SV_MM = hold_sv_date_mm[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_SV_YY = hold_sv_date_yy[ss_write_dtl];
            }
            else
            {
                objSuspend_dtl_rec.CLMDTL_SV_DD = hold_sv_date_dd[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_SV_MM = hold_sv_date_mm[ss_write_dtl];
                objSuspend_dtl_rec.CLMDTL_SV_YY = hold_sv_date_yy[ss_write_dtl];
            }

            // if clmhdr-doc-spec-cd = 7 then; 
            if (objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD == 7)
            {
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
                ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                //     compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000;
                date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;
                //     if  (hold-oma-cd(ss-write-dtl) = 'A775' or 'W775' or 'C775') and date-difference-in-days < 65  and hold-diag-cd (ss-write-dtl) not = 290 and not price-only-claim then                            
                if ((await hold_oma_cd_grp(ss_write_dtl) == "A775" || await hold_oma_cd_grp(ss_write_dtl) == "W775" || await hold_oma_cd_grp(ss_write_dtl) == "C775") && date_difference_in_days < 65 && hold_diag_cd[ss_write_dtl] != 290 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //       perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 60;
                    err_60_doc_spec = Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD);
                    hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
                    err_60_birth_date = hdr_birth_date_long_grp;
                    //         perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
                //     else if  date-difference-in-days < 60 and not price-only-claim then
                else if (date_difference_in_days < 60 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //       perform xb0-print-warning-line  thru    xb0-99-exit;            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 59;
                    err_59_doc_spec = Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD);
                    hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
                    err_59_birth_date = hdr_birth_date_long_grp;
                    //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }


            // if  clmhdr-doc-spec-cd = 19  then;            
            if (Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD) == 19)
            {
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
                ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                //     compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000;
                date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;
                // 	   if (hold-oma-cd(ss-write-dtl) = 'A191' or 'A192') and date-difference-in-days < 65 and hold-diag-cd (ss-write-dtl) not = 290 and not price-only-claim then;                            
                if ((await hold_oma_cd_grp(ss_write_dtl) == "A191" || await hold_oma_cd_grp(ss_write_dtl) == "A192") && date_difference_in_days < 65 && hold_diag_cd[ss_write_dtl] != 290 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 60;
                    err_60_doc_spec = Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD);
                    hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
                    err_60_birth_date = hdr_birth_date_long_grp;
                    //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            // if hold-sv-date(ss-write-dtl) < hdr-birth-date-long and not price-only-claim  then 
            hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2,'0');
            hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6,'0') + Util.Str(hdr_birth_date_dd).PadLeft(2,'0');
            if (Util.NumInt(hold_sv_date_grp[ss_write_dtl]) < Util.NumInt(hdr_birth_date_long_grp) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 61;
                err_61_serv_date = hold_sv_date_grp[ss_write_dtl];
                err_61_birth_date = hdr_birth_date_long_grp;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit;            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //     objSuspend_dtl_rec.clmdtl_sv_date = "????????";
                objSuspend_dtl_rec.CLMDTL_SV_YY = 0;
                objSuspend_dtl_rec.CLMDTL_SV_MM = 0;
                objSuspend_dtl_rec.CLMDTL_SV_DD = 0;
            }

            // if  hold-oma-cd (ss-write-dtl) = 'E420' then             
            if (await hold_oma_cd_grp(ss_write_dtl) == "E420")
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line  thru    xb0-99-exit            
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 63;
                //     perform zb0-build-write-err-rpt-line 	thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if hold-oma-cd (ss-write-dtl) = 'Z425' and clmhdr-doc-nbr = '049'  then;                
            if (await hold_oma_cd_grp(ss_write_dtl) == "Z425" && Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_NBR) == "049")
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 64;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //  if  hold-oma-cd (ss-write-dtl) = 'A073' or 'A074' or 'A071' or 'A078';
            if (await hold_oma_cd_grp(ss_write_dtl) == "A073" || await hold_oma_cd_grp(ss_write_dtl) == "A074" || await hold_oma_cd_grp(ss_write_dtl) == "A071" || await hold_oma_cd_grp(ss_write_dtl) == "A078"
            //         			     or 'A183' or  'A184';
            || await hold_oma_cd_grp(ss_write_dtl) == "A183" || await hold_oma_cd_grp(ss_write_dtl) == "A184"
            //         			     or 'A181' or 'A188' or 'A263' or 'A264' or 'A661';
             || await hold_oma_cd_grp(ss_write_dtl) == "A181" || await hold_oma_cd_grp(ss_write_dtl) == "A188" || await hold_oma_cd_grp(ss_write_dtl) == "A263" || await hold_oma_cd_grp(ss_write_dtl) == "A264" || await hold_oma_cd_grp(ss_write_dtl) == "A661"
            //         			     or 'A283' or 'A284' or 'A313' or 'A310' or 'A311';
             || await hold_oma_cd_grp(ss_write_dtl) == "A283" || await hold_oma_cd_grp(ss_write_dtl) == "A284" || await hold_oma_cd_grp(ss_write_dtl) == "A313" || await hold_oma_cd_grp(ss_write_dtl) == "A310" || await hold_oma_cd_grp(ss_write_dtl) == "A311"
            //         			     or 'A318';
               || await hold_oma_cd_grp(ss_write_dtl) == "A318"
            //         			     or 'A473' or 'A474' or 'A471' or 'A478' or 'A483';
               || await hold_oma_cd_grp(ss_write_dtl) == "A473" || await hold_oma_cd_grp(ss_write_dtl) == "A474" || await hold_oma_cd_grp(ss_write_dtl) == "A471" || await hold_oma_cd_grp(ss_write_dtl) == "A478" || await hold_oma_cd_grp(ss_write_dtl) == "A483"
            //         			     or 'A484' or 'A481' or 'A488';
                || await hold_oma_cd_grp(ss_write_dtl) == "A484" || await hold_oma_cd_grp(ss_write_dtl) == "A481" || await hold_oma_cd_grp(ss_write_dtl) == "A488"
            //         			     or 'A613' or 'A614' or 'A611';
               || await hold_oma_cd_grp(ss_write_dtl) == "A613" || await hold_oma_cd_grp(ss_write_dtl) == "A614" || await hold_oma_cd_grp(ss_write_dtl) == "A611"
            //         			     or 'A618' or 'A623' or 'A624' or 'A621' or 'A628';
               || await hold_oma_cd_grp(ss_write_dtl) == "A618" || await hold_oma_cd_grp(ss_write_dtl) == "A623" || await hold_oma_cd_grp(ss_write_dtl) == "A624" || await hold_oma_cd_grp(ss_write_dtl) == "A621" || await hold_oma_cd_grp(ss_write_dtl) == "A628"
            // 				         or 'A340' or 'A341' or 'A343' or 'A348';
               || await hold_oma_cd_grp(ss_write_dtl) == "A340" || await hold_oma_cd_grp(ss_write_dtl) == "A341" || await hold_oma_cd_grp(ss_write_dtl) == "A343" || await hold_oma_cd_grp(ss_write_dtl) == "A348"
            // 				         or 'A262';
                || await hold_oma_cd_grp(ss_write_dtl) == "A262"
            //         			     or 'A153' or 'A154' or 'A151' or 'A158';
                || await hold_oma_cd_grp(ss_write_dtl) == "A153" || await hold_oma_cd_grp(ss_write_dtl) == "A154" || await hold_oma_cd_grp(ss_write_dtl) == "A151" || await hold_oma_cd_grp(ss_write_dtl) == "A158"
            //         			     or 'A443' or 'A444';
                 || await hold_oma_cd_grp(ss_write_dtl) == "A443" || await hold_oma_cd_grp(ss_write_dtl) == "A444"
            //         			     or 'A441' or 'A448' or 'A463' or 'A464' or 'A461';
                || await hold_oma_cd_grp(ss_write_dtl) == "A441" || await hold_oma_cd_grp(ss_write_dtl) == "A448" || await hold_oma_cd_grp(ss_write_dtl) == "A463" || await hold_oma_cd_grp(ss_write_dtl) == "A464" || await hold_oma_cd_grp(ss_write_dtl) == "A461"
            // 				         or 'A468';
                 || await hold_oma_cd_grp(ss_write_dtl) == "A468"
            //    then;
            )
            {
                // 	      if  (	     (    (hold-diag-cd (ss-write-dtl) =    42 or  43 or  44 or 250 or 286 or 287 or 290;
                if ((((hold_diag_cd[ss_write_dtl] == 42 || hold_diag_cd[ss_write_dtl] == 43 || hold_diag_cd[ss_write_dtl] == 44 || hold_diag_cd[ss_write_dtl] == 250 || hold_diag_cd[ss_write_dtl] == 286 || hold_diag_cd[ss_write_dtl] == 287 || hold_diag_cd[ss_write_dtl] == 290
                // 		 				 	or 332 or 340 or 343 or 345 or 402 or 428 or 491;
                   || hold_diag_cd[ss_write_dtl] == 332 || hold_diag_cd[ss_write_dtl] == 340 || hold_diag_cd[ss_write_dtl] == 343 || hold_diag_cd[ss_write_dtl] == 345 || hold_diag_cd[ss_write_dtl] == 402 || hold_diag_cd[ss_write_dtl] == 428 || hold_diag_cd[ss_write_dtl] == 491
                // 					 		or 492 or 493 or 515 or 555 or 556 or 571 or 585;
                    || hold_diag_cd[ss_write_dtl] == 492 || hold_diag_cd[ss_write_dtl] == 493 || hold_diag_cd[ss_write_dtl] == 515 || hold_diag_cd[ss_write_dtl] == 555 || hold_diag_cd[ss_write_dtl] == 556 || hold_diag_cd[ss_write_dtl] == 571 || hold_diag_cd[ss_write_dtl] == 585
                // 					 		or 710 or 714 or 720 or 721 or 758;
                    || hold_diag_cd[ss_write_dtl] == 710 || hold_diag_cd[ss_write_dtl] == 714 || hold_diag_cd[ss_write_dtl] == 720 || hold_diag_cd[ss_write_dtl] == 721 || hold_diag_cd[ss_write_dtl] == 758
                //                          or 299 or 313 or 315 or 765 or 902;
                     || hold_diag_cd[ss_write_dtl] == 299 || hold_diag_cd[ss_write_dtl] == 313 || hold_diag_cd[ss_write_dtl] == 315 || hold_diag_cd[ss_write_dtl] == 765 || hold_diag_cd[ss_write_dtl] == 902
                // 		          );
                   )
                //        	              and  ws-e078-premium = 'N';
                       && Util.Str(ws_e078_premium).ToUpper() == "N"
                // 		     );
                             )
                // 	        or   (    (hold-diag-cd (ss-write-dtl)      not =  42 and not =  43 and not =  44 and not = 250;
                      || ((hold_diag_cd[ss_write_dtl] != 42 && hold_diag_cd[ss_write_dtl] != 43 && hold_diag_cd[ss_write_dtl] != 44 && hold_diag_cd[ss_write_dtl] != 250
                // 							and not = 286 and not = 287 and not = 290 and not = 332;
                      && hold_diag_cd[ss_write_dtl] != 286 && hold_diag_cd[ss_write_dtl] != 287 && hold_diag_cd[ss_write_dtl] != 290 && hold_diag_cd[ss_write_dtl] != 332
                // 							and not = 340 and not = 343 and not = 345 and not = 402;
                      && hold_diag_cd[ss_write_dtl] != 340 && hold_diag_cd[ss_write_dtl] != 343 && hold_diag_cd[ss_write_dtl] != 345 && hold_diag_cd[ss_write_dtl] != 402
                // 							and not = 428 and not = 491 and not = 492 and not = 493;
                      && hold_diag_cd[ss_write_dtl] != 428 && hold_diag_cd[ss_write_dtl] != 491 && hold_diag_cd[ss_write_dtl] != 492 && hold_diag_cd[ss_write_dtl] != 493
                // 							and not = 515 and not = 555 and not = 556 and not = 571;
                      && hold_diag_cd[ss_write_dtl] != 515 && hold_diag_cd[ss_write_dtl] != 555 && hold_diag_cd[ss_write_dtl] != 556 && hold_diag_cd[ss_write_dtl] != 571
                // 							and not = 585 and not = 710 and not = 714 and not = 720;
                      && hold_diag_cd[ss_write_dtl] != 585 && hold_diag_cd[ss_write_dtl] != 710 && hold_diag_cd[ss_write_dtl] != 714 && hold_diag_cd[ss_write_dtl] != 720
                // 							and not = 721 and not = 758;
                      && hold_diag_cd[ss_write_dtl] != 721 && hold_diag_cd[ss_write_dtl] != 758
                // 							and not = 299 and not = 313 and not = 315 and not = 765;
                       && hold_diag_cd[ss_write_dtl] != 299 && hold_diag_cd[ss_write_dtl] != 313 && hold_diag_cd[ss_write_dtl] != 315 && hold_diag_cd[ss_write_dtl] != 765
                // 							and not = 902;
                      && hold_diag_cd[ss_write_dtl] != 902
                // 			  );
                              )
                //        	              and  ws-e078-premium = 'Y';
                         && Util.Str(ws_e078_premium).ToUpper() == "Y"
                // 		     );
                             )
                // 	      );
                          )
                // 	  then;
                )
                {
                    err_warn_msg = ws_error_literal;
                    //           	perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 65;
                    //        	perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            //  if   ( 	(     (   hold-oma-cd (ss-write-dtl) = 'E722';
            if ((((await hold_oma_cd_grp(ss_write_dtl) == "E722"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                 && hold_oma_suff[ss_write_dtl] == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 1;
                 && hold_sv_nbr_serv[ss_write_dtl] != 1
            //                 );
                               )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E010';
                   ((await hold_oma_cd_grp(ss_write_dtl) == "E010"
            //                        or hold-oma-cd (ss-write-dtl) = 'E604';
                    || await hold_oma_cd_grp(ss_write_dtl) == "E604"
            //                        or hold-oma-cd (ss-write-dtl) = 'E956';
                     || await hold_oma_cd_grp(ss_write_dtl) == "E956"
            //                        or hold-oma-cd (ss-write-dtl) = 'E022';
                    || await hold_oma_cd_grp(ss_write_dtl) == "E022"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                    && hold_oma_suff[ss_write_dtl] == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 2;
                    && hold_sv_nbr_serv[ss_write_dtl] != 2
            //                 );
                               )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E667';
                     ((await hold_oma_cd_grp(ss_write_dtl) == "E667"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                    && hold_oma_suff[ss_write_dtl] == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 3;
                    && hold_sv_nbr_serv[ss_write_dtl] != 3
            //                 );
                               )
                           //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E011';
                          ((await hold_oma_cd_grp(ss_write_dtl) == "E011"
            // 	               or hold-oma-cd (ss-write-dtl) = 'E020';
                           || await hold_oma_cd_grp(ss_write_dtl) == "E020"
            // 	               or hold-oma-cd (ss-write-dtl) = 'E024';
                           || await hold_oma_cd_grp(ss_write_dtl) == "E024"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                    && Util.Str(hold_oma_suff[ss_write_dtl]).ToUpper() == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 4;
                    && hold_sv_nbr_serv[ss_write_dtl] != 4
            //                 );
                               )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E012';
                       ((await hold_oma_cd_grp(ss_write_dtl) == "E012"
            //                         or (     hold-oma-cd (ss-write-dtl) >= 'E137';
                        || (Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("E137") >= 0
            //                              and hold-oma-cd (ss-write-dtl) <= 'E141';
                        && Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("E141") <= 0
            //                            );
                                          )
            //                         or (     hold-oma-cd (ss-write-dtl) >= 'E143';
                       || (Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("E143") >= 0
            //                              and hold-oma-cd (ss-write-dtl) <= 'E147';
                       && Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("E147") <= 0
            //                            );
                                          )
            //                         or hold-oma-cd (ss-write-dtl) = 'E149';
                        || Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("E149") == 0
            //                         or hold-oma-cd (ss-write-dtl) = 'Z606';
                        || await hold_oma_cd_grp(ss_write_dtl) == "Z606"
            //                         or hold-oma-cd (ss-write-dtl) = 'Z607';
                        || await hold_oma_cd_grp(ss_write_dtl) == "Z607"
            //                         or (     hold-oma-cd (ss-write-dtl) >= 'Z491';
                        || (Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("Z491") >= 0
            //                              and hold-oma-cd (ss-write-dtl) <= 'Z499';
                        && Util.Str(await hold_oma_cd_grp(ss_write_dtl)).CompareTo("Z499") <= 0
            //                            );
                                          )
            //                         or hold-oma-cd (ss-write-dtl) = 'Z555';
                         || await hold_oma_cd_grp(ss_write_dtl) == "Z555"
            //                         or hold-oma-cd (ss-write-dtl) = 'Z580';
                          || await hold_oma_cd_grp(ss_write_dtl) == "Z580"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                     && hold_oma_suff[ss_write_dtl] == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 5;
                     && hold_sv_nbr_serv[ss_write_dtl] != 5
            //                 );
                               )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'P014';
                         ((await hold_oma_cd_grp(ss_write_dtl) == "P014"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                     && Util.Str(hold_oma_suff[ss_write_dtl]).ToUpper() == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 6;
                     && hold_sv_nbr_serv[ss_write_dtl] != 6
            //                 );
                              )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E676';
                       ((await hold_oma_cd_grp(ss_write_dtl) == "E676"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'B';
                     && hold_oma_suff[ss_write_dtl] == "B"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 6;
                     && hold_sv_nbr_serv[ss_write_dtl] != 6
            //                 );
                               )
                           //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E021';
                           ((await hold_oma_cd_grp(ss_write_dtl) == "E021"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                     && Util.Str(hold_oma_suff[ss_write_dtl]).ToUpper() == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 4;
                     && hold_sv_nbr_serv[ss_write_dtl] != 4
            //                 );
                               )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E017';
                            ((await hold_oma_cd_grp(ss_write_dtl) == "E017"
            //  		       or hold-oma-cd (ss-write-dtl) = 'E025';
                            || await hold_oma_cd_grp(ss_write_dtl) == "E025"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                     && Util.Str(hold_oma_suff[ss_write_dtl]).ToUpper() == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 10;
                     && hold_sv_nbr_serv[ss_write_dtl] != 10
            //                 );
                               )
            //             or;
                           ||
            //             	(     (   hold-oma-cd (ss-write-dtl) = 'E016';
                         ((await hold_oma_cd_grp(ss_write_dtl) == "E016"
            // 		      );
                          )
            // 		 and  hold-oma-suff  (ss-write-dtl) = 'C';
                     && hold_oma_suff[ss_write_dtl] == "C"
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) not = 20;
                     && hold_sv_nbr_serv[ss_write_dtl] != 20
            //                 );
                              )
                        //          );
                        )
            //   then;
            )
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 69;
                err_oma_cd = await hold_oma_cd_grp(ss_write_dtl);
                err_oma_suff = hold_oma_suff[ss_write_dtl];
                err_nbr_serv = Util.Str(hold_sv_nbr_serv[ss_write_dtl]).PadLeft(2,'0');
                err_nbr_serv_incoming = Util.Str(hold_sv_nbr_serv_incoming[ss_write_dtl]).PadLeft(2,'0');
                //        perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  ws-e020 = "Y"  and ws-e022-e017-e016 = "N"  then  
            if (Util.Str(ws_e020).ToUpper() == "Y" && Util.Str(ws_e022_e017_e016).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 70;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if ws-e719 = "Y"  and ws-z570 = "N" then           
            if (Util.Str(ws_e719).ToUpper() == "Y" && Util.Str(ws_z570).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 71;
                //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  ws-e720 = "Y" and ws-z571 = "N"  then          
            if (Util.Str(ws_e720).ToUpper() == "Y" && Util.Str(ws_z571).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 72;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-e717 = "Y" and ws-z555-z580 = "N" and ws-z491-to-z499 = "N" then    
            if (Util.Str(ws_e717).ToUpper() == "Y" && Util.Str(ws_z555_z580).ToUpper() == "N" && Util.Str(ws_z491_to_z499).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 73;
                //    perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if ws-e702 = "Y"  and ws-z515-z760 = "N"  then     
            if (Util.Str(ws_e702).ToUpper() == "Y" && Util.Str(ws_z515_z760).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 74;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-g123 = "Y"  and ws-g228 = "N" then 
            if (Util.Str(ws_g123).ToUpper() == "Y" && Util.Str(ws_g228).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 75;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-g223 = "Y" and ws-g231 = "N" then  
            if (Util.Str(ws_g223).ToUpper() == "Y" && Util.Str(ws_g231).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 76;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-g265 = "Y"  and ws-g264 = "N" then            
            if (Util.Str(ws_g265).ToUpper() == "Y" && Util.Str(ws_g264).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 77;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-g385 = "Y"  and ws-g384 = "N" then            
            if (Util.Str(ws_g385).ToUpper() == "Y" && Util.Str(ws_g384).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 78;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-g281 = "Y" and ws-g381 = "N" then         
            if (Util.Str(ws_g281).ToUpper() == "Y" && Util.Str(ws_g381).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 79;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            //      if   ( 	(    (    hold-oma-cd (ss-write-dtl) = 'G123';
            if ((((await hold_oma_cd_grp(ss_write_dtl) == "G123"
            //                        or hold-oma-cd (ss-write-dtl) = 'E719';
                 || await hold_oma_cd_grp(ss_write_dtl) == "E719"
            //                        or hold-oma-cd (ss-write-dtl) = 'G060';
                 || await hold_oma_cd_grp(ss_write_dtl) == "G060"
            //                        or hold-oma-cd (ss-write-dtl) = 'G061';
                 || await hold_oma_cd_grp(ss_write_dtl) == "G061"
            //                        or hold-oma-cd (ss-write-dtl) = 'J022';
                 || await hold_oma_cd_grp(ss_write_dtl) == "J022"
            // 		     );
                         )
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) > 4;
                   && hold_sv_nbr_serv[ss_write_dtl] > 4
            //                 );
                               )
            //             or;
                           ||
            //             	(    (   hold-oma-cd (ss-write-dtl) = 'G265';
                         ((await hold_oma_cd_grp(ss_write_dtl) == "G265"
            //             	      or hold-oma-cd (ss-write-dtl) = 'G292';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G292"
            //             	      or hold-oma-cd (ss-write-dtl) = 'E837';
                          || await hold_oma_cd_grp(ss_write_dtl) == "E837"
            //             	      or hold-oma-cd (ss-write-dtl) = 'G285';
                          || await hold_oma_cd_grp(ss_write_dtl) == "G285"
            // 		     );
                         )
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) > 3;
                      && hold_sv_nbr_serv[ss_write_dtl] > 3
            //                 );
                               )
            //             or;
                           ||
            //                	(    (   hold-oma-cd (ss-write-dtl) = 'G385';
                                ((await hold_oma_cd_grp(ss_write_dtl) == "G385"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E720';
                         || await hold_oma_cd_grp(ss_write_dtl) == "E720"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G218';
                          || await hold_oma_cd_grp(ss_write_dtl) == "G218"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G219';
                          || await hold_oma_cd_grp(ss_write_dtl) == "G219"
            // 		      or hold-oma-cd (ss-write-dtl) = 'H104';
                         || await hold_oma_cd_grp(ss_write_dtl) == "H104"
            // 		      or hold-oma-cd (ss-write-dtl) = 'H134';
                         || await hold_oma_cd_grp(ss_write_dtl) == "H134"
            // 		      or hold-oma-cd (ss-write-dtl) = 'H124';
                        || await hold_oma_cd_grp(ss_write_dtl) == "H124"
            // 		      or hold-oma-cd (ss-write-dtl) = 'H154';
                         || await hold_oma_cd_grp(ss_write_dtl) == "H154"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G480';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G480"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G482';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G482"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G483';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G483"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G372';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G372"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G379';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G379"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E542';
                         || await hold_oma_cd_grp(ss_write_dtl) == "E542"
            // 		     );
                         )
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) > 2;
                     && hold_sv_nbr_serv[ss_write_dtl] > 2
            //                 );
                               )
                           //             or;
                           ||
                          //                	(    (   hold-oma-cd (ss-write-dtl) = 'E702';
                          ((await hold_oma_cd_grp(ss_write_dtl) == "E702"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E717';
                          || await hold_oma_cd_grp(ss_write_dtl) == "E717"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G223';
                          || await hold_oma_cd_grp(ss_write_dtl) == "G223"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G220';
                          || await hold_oma_cd_grp(ss_write_dtl) == "G220"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G291';
                           || await hold_oma_cd_grp(ss_write_dtl) == "G291"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G286';
                           || await hold_oma_cd_grp(ss_write_dtl) == "G286"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G700';
                           || await hold_oma_cd_grp(ss_write_dtl) == "G700"
            // 		      or hold-oma-cd (ss-write-dtl) = 'Z546';
                           || await hold_oma_cd_grp(ss_write_dtl) == "Z546"
            // 		      or hold-oma-cd (ss-write-dtl) = 'Z566';
                           || await hold_oma_cd_grp(ss_write_dtl) == "Z566"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G395';
                           || await hold_oma_cd_grp(ss_write_dtl) == "G395"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G523';
                            || await hold_oma_cd_grp(ss_write_dtl) == "G523"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G443';
                            || await hold_oma_cd_grp(ss_write_dtl) == "G443"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G530';
                            || await hold_oma_cd_grp(ss_write_dtl) == "G530"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E082';
                            || await hold_oma_cd_grp(ss_write_dtl) == "E082"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E083';
                            || await hold_oma_cd_grp(ss_write_dtl) == "E083"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E409';
                            || await hold_oma_cd_grp(ss_write_dtl) == "E409"
            // 		      or hold-oma-cd (ss-write-dtl) = 'E410';
                             || await hold_oma_cd_grp(ss_write_dtl) == "E410"
            // 		      or hold-oma-cd (ss-write-dtl) = 'Z441';
                             || await hold_oma_cd_grp(ss_write_dtl) == "Z441"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G370';
                             || await hold_oma_cd_grp(ss_write_dtl) == "G370"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G328';
                              || await hold_oma_cd_grp(ss_write_dtl) == "G328"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G420';
                              || await hold_oma_cd_grp(ss_write_dtl) == "G420"
            // 		      or (    hold-oma-cd (ss-write-dtl) = 'E158';
                           || (await hold_oma_cd_grp(ss_write_dtl) == "E158"
            // 			  and hold-oma-suff(ss-write-dtl) = 'A';
                          && hold_oma_suff[ss_write_dtl] == "A"
            // 			 );
                         )
            // 		      or (    hold-oma-cd (ss-write-dtl) = 'E159';
                         || (await hold_oma_cd_grp(ss_write_dtl) == "E159"
            // 			  and hold-oma-suff(ss-write-dtl) = 'A';
                         && hold_oma_suff[ss_write_dtl] == "A"
            // 			 );
                         )
            //                       or hold-oma-cd (ss-write-dtl) = 'J021';
                         || await hold_oma_cd_grp(ss_write_dtl) == "J021"
            // 	    	      or hold-oma-cd (ss-write-dtl) = 'J025';
                         || await hold_oma_cd_grp(ss_write_dtl) == "J025"
            // 		      or hold-oma-cd (ss-write-dtl) = 'G521';
                         || await hold_oma_cd_grp(ss_write_dtl) == "G521"
            // 		     );
                         )
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) > 1;
                    && hold_sv_nbr_serv[ss_write_dtl] > 1
            //                 );
                               )
                           //             or;
                           ||
            //             	(    (   hold-oma-cd (ss-write-dtl) = 'G221';
                          ((await hold_oma_cd_grp(ss_write_dtl) == "G221"
            //             	      or hold-oma-cd (ss-write-dtl) = 'G489';
                               || await hold_oma_cd_grp(ss_write_dtl) == "G489"
            //             	      or hold-oma-cd (ss-write-dtl) = 'G371';
                               || await hold_oma_cd_grp(ss_write_dtl) == "G371"
            // 		     );
                         )
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) > 5;
                     && hold_sv_nbr_serv[ss_write_dtl] > 5
            //                 );
                               )
                           //             or;
                           ||
                            //             	(    (   hold-oma-cd (ss-write-dtl) = 'K630';
                            ((await hold_oma_cd_grp(ss_write_dtl) == "K630"
            // 		     );
                         )
            // 		 and  hold-sv-nbr-serv (ss-write-dtl) > 6;
                     && hold_sv_nbr_serv[ss_write_dtl] > 6
            //                 );
                              )
            //          );
                        )
            //      then;
            )
            {
                err_warn_msg = ws_error_literal;
                //         perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 80;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  hold-oma-cd (ss-write-dtl) = 'A007'  and clmhdr-doc-spec-cd = 26  then                        
            if (await hold_oma_cd_grp(ss_write_dtl) == "A007" && Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD) == 26)
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 84;
                //   perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  ws-c998 = "Y"  or ws-c985 = 'Y' or ws-c983 = 'Y' then     
            if (Util.Str(ws_c998).ToUpper() == "Y" || Util.Str(ws_c985).ToUpper() == "Y" || Util.Str(ws_c983).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 85;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-c999 = "Y" then            
            if (Util.Str(ws_c999).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 86;
                //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-e798 = "Y"  and ws-z400 = "N" then       
            if (Util.Str(ws_e798).ToUpper() == "Y" && Util.Str(ws_z400).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 87;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  ( ws-g400-other-codes = "Y" or ws-g489-g376  = "Y"  )  and ws-e409-e410  = "Y"  then            
            if ((ws_g400_other_codes == "Y" && (ws_e409_e410 == "Y" || ws_g325 == "Y")) || (ws_g489_g376 == "Y" && ws_e409_e410 == "Y"))
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 88;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-c990-to-c997 = "Y" and ws-cnnn = "Y"  and ws-sv-date-c1 = ws-sv-date-c2  then            
            if (Util.Str(ws_c990_to_c997).ToUpper() == "Y" && Util.Str(ws_cnnn).ToUpper() == "Y" && ws_sv_date_c1 == ws_sv_date_c2)
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 89;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if ws-e450 = "Y" and ws-j315 = "N" then
            if (Util.Str(ws_e450).ToUpper() == "Y" && Util.Str(ws_j315) == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 90;
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-g222 = "Y"  and ws-g248-g062 = "Y" then      
            if (Util.Str(ws_g222).ToUpper() == "Y" && Util.Str(ws_g248_g062).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 91;
                //   perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-X9nn = "Y" and ws-a770-a775 = "Y"  then            
            if (Util.Str(ws_X9nn).ToUpper() == "Y" && Util.Str(ws_a770_a775).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 92;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  hold-oma-cd (ss-write-dtl) = "G489" or "S323" then             
            if (Util.Str(await hold_oma_cd_grp(ss_write_dtl)) == "G489" || Util.Str(await hold_oma_cd_grp(ss_write_dtl)) == "S323")
            {
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
                ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                //     compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000;
                date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;

                // 	   if date-difference-in-days < 16 and not price-only-claim then            
                if (date_difference_in_days < 16 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru    xb0-99-exit
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 95;
                    //        perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            // if ws-g222-z805 = 'Y' and ws-p014-p016 = "Y" then         
            if (Util.Str(ws_g222_z805).ToUpper() == "Y" && Util.Str(ws_p014_p016).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 96;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-g221 = 'Y' and ws-g220 = "N" then            
            if (Util.Str(ws_g221).ToUpper() == "Y" && Util.Str(ws_g220).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 98;
                //   perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  ws-s322-a198 = 'Y' then          
            if (Util.Str(ws_s322_a198).ToUpper() == "Y")
            {
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
                ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                //     compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000;
                date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;

                //  if  date-difference-in-days > 15 and not price-only-claim then            
                if (date_difference_in_days > 15 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //         perform xb0-print-warning-line thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 99;
                    //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            // if  hold-oma-cd(ss-write-dtl) = 'H267' then                    
            if (await hold_oma_cd_grp(ss_write_dtl) == "H267")
            {
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
                ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                // 	   if   ws-sv-date not = ws-birth-date then            
                if (ws_sv_date != ws_birth_date)
                {
                    err_warn_msg = ws_error_literal;
                    //      perform xb0-print-warning-line  thru    xb0-99-exit            
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 100;
                    //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            //  if  ws-g521-g395 = 'Y'  and ws-h104-h124 = "Y"  then    
            if (Util.Str(ws_g521_g395).ToUpper() == "Y" && Util.Str(ws_h104_h124).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 101;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //  if  ws-g345-g339 = 'Y' and ws-annn = "Y" then     
            if (Util.Str(ws_g345_g339).ToUpper() == "Y" && Util.Str(ws_annn).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 102;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-g431-g479 = "N";            
            if (Util.Str(ws_g431_g479).ToUpper() == "N"
            //        and (   hold-oma-cd-alpha(ss-write-dtl)  =   "G";
                     && (hold_oma_cd_alpha[ss_write_dtl] == "G"
            //             or hold-oma-cd(ss-write-dtl) = 'E409';
                     || await hold_oma_cd_grp(ss_write_dtl) == "E409"
            //             or hold-oma-cd(ss-write-dtl) = 'E410';
                     || await hold_oma_cd_grp(ss_write_dtl) == "E410"
            //             or hold-oma-cd(ss-write-dtl) = 'E111';
                     || await hold_oma_cd_grp(ss_write_dtl) == "E111"
            // 	    );
                    )
            //        and hold-oma-suff  (ss-write-dtl) =   "C";
                   && hold_oma_suff[ss_write_dtl] == "C"
            //      then;
            )
            {
                err_warn_msg = ws_error_literal;
                //        perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 103;
                //           perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  hold-oma-cd-alpha(ss-write-dtl) = "K" and hold-oma-suff  (ss-write-dtl) = "C"  then            
            if (hold_oma_cd_alpha[ss_write_dtl] == "K" && hold_oma_suff[ss_write_dtl] == "C")
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 124;
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-a765-c765 = 'Y' then 
            if (Util.Str(ws_a765_c765) == "Y")
            {
                hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                //     if  ws-a765-c765 = 'Y'  then            
                if (Util.Str(ws_a765_c765).ToUpper() == "Y")
                {
                    ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                    hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
                    ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                    //  	   compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000;
                    date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;
                    // 	       if  date-difference-in-days > 16 and not price-only-claim  then            
                    if (date_difference_in_days > 16 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                    {
                        err_warn_msg = ws_error_literal;
                        //            perform xb0-print-warning-line  thru    xb0-99-exit;            
                        await xb0_print_warning_line();
                        await xb0_99_exit();
                        ws_carriage_ctrl = 1;
                        err_ind = 104;
                        //       perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                        await zb0_build_write_err_rpt_line();
                        await zb0_99_exit();
                    }
                }
            }

            // if  ws-j025 = 'Y' and (ws-j021 = 'Y' or ws-j022 = 'Y') then            
            if (Util.Str(ws_j025).ToUpper() == "Y" && (Util.Str(ws_j021).ToUpper() == "Y" || Util.Str(ws_j022).ToUpper() == "Y"))
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 105;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  hold-oma-cd(ss-write-dtl) = 'A253'  or hold-oma-cd(ss-write-dtl) = 'A256'  then                
            if (await hold_oma_cd_grp(ss_write_dtl) == "A253" || await hold_oma_cd_grp(ss_write_dtl) == "A256")
            {
                ws_chk_nbr = hdr_refer_pract_nbr;
                ws_chk_nbr_1 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(0, 1));
                ws_chk_nbr_2 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(1, 1));
                ws_chk_nbr_3 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(2, 1));
                ws_chk_nbr_4 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(3, 1));
                ws_chk_nbr_5 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(4, 1));
                ws_chk_nbr_6 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(5, 1));
                ws_chk_nbr_7 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(6, 1));
                ws_chk_nbr_8 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(7, 1));
                //      if ws-chk-nbr-3  not = 8 then           
                if (ws_chk_nbr_3 != 8)
                {
                    err_warn_msg = ws_error_literal;
                    //      perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 106;
                    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }


            //      if    hold-oma-cd(ss-write-dtl) = 'A813';            
            if (await hold_oma_cd_grp(ss_write_dtl) == "A813"
            //         or hold-oma-cd(ss-write-dtl) = 'A815';
                || await hold_oma_cd_grp(ss_write_dtl) == "A815"
            //         or hold-oma-cd(ss-write-dtl) = 'C813';
                || await hold_oma_cd_grp(ss_write_dtl) == "C813"
            //         or hold-oma-cd(ss-write-dtl) = 'C815';
                || await hold_oma_cd_grp(ss_write_dtl) == "C815"
            //         or hold-oma-cd(ss-write-dtl) = 'A800';
                || await hold_oma_cd_grp(ss_write_dtl) == "A800"
            //         or hold-oma-cd(ss-write-dtl) = 'C800';
                || await hold_oma_cd_grp(ss_write_dtl) == "C800"
            //         or hold-oma-cd(ss-write-dtl) = 'A801';
                || await hold_oma_cd_grp(ss_write_dtl) == "A801"
            //         or hold-oma-cd(ss-write-dtl) = 'C801';
                || await hold_oma_cd_grp(ss_write_dtl) == "C801"
            //         or hold-oma-cd(ss-write-dtl) = 'A802';
                || await hold_oma_cd_grp(ss_write_dtl) == "A802"
            //         or hold-oma-cd(ss-write-dtl) = 'C802';
                || await hold_oma_cd_grp(ss_write_dtl) == "C802"
            //         or hold-oma-cd(ss-write-dtl) = 'K224';
                || await hold_oma_cd_grp(ss_write_dtl) == "K224"
            //         or hold-oma-cd(ss-write-dtl) = 'A816';
                || await hold_oma_cd_grp(ss_write_dtl) == "A816"
            //         or hold-oma-cd(ss-write-dtl) = 'C816';
                || await hold_oma_cd_grp(ss_write_dtl) == "C816"
            //      then;
            )
            {
                ws_chk_nbr = hdr_refer_pract_nbr;
                ws_chk_nbr_1 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(0, 1));
                ws_chk_nbr_2 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(1, 1));
                ws_chk_nbr_3 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(2, 1));
                ws_chk_nbr_4 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(3, 1));
                ws_chk_nbr_5 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(4, 1));
                ws_chk_nbr_6 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(5, 1));
                ws_chk_nbr_7 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(6, 1));
                ws_chk_nbr_8 = Util.NumInt(Util.Str(ws_chk_nbr).PadLeft(8).Substring(7, 1));
                //         if ws-chk-nbr-3  not = 7 then            
                if (ws_chk_nbr_3 != 7)
                {
                    err_warn_msg = ws_error_literal;
                    //          perform xb0-print-warning-line  thru    xb0-99-exit;
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 107;
                    //       perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            // if  ws-z608 = 'Y' and ws-z611-z602 = 'Y'  then 
            if (Util.Str(ws_z608).ToUpper() == "Y" && Util.Str(ws_z611_z602).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 109;
                //       perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if  (  hold-oma-cd(ss-write-dtl) = 'Z176';            
            if ((await hold_oma_cd_grp(ss_write_dtl) == "Z176"
            //             or hold-oma-cd(ss-write-dtl) = 'Z154';
                || await hold_oma_cd_grp(ss_write_dtl) == "Z154"
            // 	  );
                  )
            //       and  hold-oma-suff(ss-write-dtl) = 'A';
                && hold_oma_suff[ss_write_dtl] == "A"
            //       and  hdr-manual-review not = 'Y';
                && hdr_manual_review != "Y"
            //       and  hold-sv-nbr-serv (ss-write-dtl) > 5;
                && hold_sv_nbr_serv[ss_write_dtl] > 5
            //   then;
            )
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 110;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }


            // if   (    hold-oma-cd(ss-write-dtl) = 'Z175';            
            if ((await hold_oma_cd_grp(ss_write_dtl) == "Z175"
            //             or hold-oma-cd(ss-write-dtl) = 'Z177';
                || await hold_oma_cd_grp(ss_write_dtl) == "Z177"
            //             or hold-oma-cd(ss-write-dtl) = 'Z179';
                || await hold_oma_cd_grp(ss_write_dtl) == "Z179"
            //             or hold-oma-cd(ss-write-dtl) = 'Z190';
                || await hold_oma_cd_grp(ss_write_dtl) == "Z190"
            //             or hold-oma-cd(ss-write-dtl) = 'Z191';
                || await hold_oma_cd_grp(ss_write_dtl) == "Z191"
            //             or hold-oma-cd(ss-write-dtl) = 'Z192';
                || await hold_oma_cd_grp(ss_write_dtl) == "Z192"
            // 	  );
                  )
            //       and  hold-oma-suff(ss-write-dtl) = 'A';
                 && hold_oma_suff[ss_write_dtl] == "A"
            //       and  hdr-manual-review not = 'Y';
                 && hdr_manual_review != "Y"
            //       and  hold-sv-nbr-serv (ss-write-dtl) > 1;
                 && hold_sv_nbr_serv[ss_write_dtl] > 1
            //  then;
            )
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 111;
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //  if ws-z403 = 'Y' and ws-z408 = 'Y' and hdr-manual-review not = 'Y' then            
            if (Util.Str(ws_z403).ToUpper() == "Y" && Util.Str(ws_z408).ToUpper() == "Y" && Util.Str(hdr_manual_review).ToUpper() != "Y")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 112;
                //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-c122-c143 = 'Y' and ws-e083 not = 'Y'  then     
            if (Util.Str(ws_c122_c143).ToUpper() == "Y" && Util.Str(ws_e083).ToUpper() != "Y")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 114;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-c122-c982 not = 'Y'  and ws-e083 = 'Y' then        
            if (Util.Str(ws_c122_c982).ToUpper() != "Y" && Util.Str(ws_e083).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //   perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 115;
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-j021 not = 'Y'  and ws-j022 = 'Y' then 
            if (Util.Str(ws_j021).ToUpper() != "Y" && Util.Str(ws_j022).ToUpper() == "Y")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 116;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if   (    hold-oma-cd(ss-write-dtl) = 'G571';            
            hdr_loc_code_grp = Util.Str(hdr_loc_alpha) + Util.Str(hdr_loc_nbr);
            hdr_admit_date_grp = Util.Str(hdr_admit_yy).PadLeft(4,'0') + Util.Str(hdr_admit_mm).PadLeft(2,'0') + Util.Str(hdr_admit_dd).PadLeft(2,'0');

            if ((await hold_oma_cd_grp(ss_write_dtl) == "G571"
            //             or hold-oma-cd(ss-write-dtl) = 'G578';
                || await hold_oma_cd_grp(ss_write_dtl) == "G578"
            //             or hold-oma-cd(ss-write-dtl) = 'G581';
                || await hold_oma_cd_grp(ss_write_dtl) == "G581"
            //             or hold-oma-cd(ss-write-dtl) = 'G584';
                || await hold_oma_cd_grp(ss_write_dtl) == "G584"
            // 	  );
                  )
            //       and  hdr-loc-code = 'G430';
                && hdr_loc_code_grp == "G430"
            //       and  hdr-admit-date = zeros or spaces;
                && Util.NumInt(hdr_admit_date_grp) == 0 || string.IsNullOrWhiteSpace(hdr_admit_date_grp)
            //  then;
            )
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 117;
                //       perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-a197-a198 = 'Y'  then            
            hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2,'0');
            hdr_birth_date_long_grp = Util.Str(hdr_birth_date).PadLeft(6, '0') + Util.Str(hdr_birth_date_dd).PadLeft(2, '0');
            if (Util.Str(ws_a197_a198).ToUpper() == "Y")
            {
                ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
                ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
                //     compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000;
                date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;

                // if  date-difference-in-days > 21 and not price-only-claim then   
                if (date_difference_in_days > 21 && !Util.Str(flag_claim_source).Equals(price_only_claim))
                {
                    err_warn_msg = ws_error_literal;
                    //       perform xb0-print-warning-line  thru    xb0-99-exit
                    await xb0_print_warning_line();
                    await xb0_99_exit();
                    ws_carriage_ctrl = 1;
                    err_ind = 120;
                    //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                    await zb0_build_write_err_rpt_line();
                    await zb0_99_exit();
                }
            }

            //  if  ws-k189 = 'Y' and ws-a190-a795 not = 'Y' then            
            if (Util.Str(ws_k189).ToUpper() == "Y" && Util.Str(ws_a190_a795).ToUpper() != "Y")
            {
                err_warn_msg = ws_error_literal;
                //     perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 121;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //      if    (	ws-k960 = 'Y';
            if ((Util.Str(ws_k960).ToUpper() == "Y"
            //        	    and ws-k990 not = 'Y';
                && Util.Str(ws_k990).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-k961 = 'Y';
                || (Util.Str(ws_k961).ToUpper() == "Y"
            //        	    and ws-k992 not = 'Y';
                && Util.Str(ws_k992).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-k962 = 'Y';
                || (Util.Str(ws_k962).ToUpper() == "Y"
            //        	    and ws-k994 not = 'Y';
                 && Util.Str(ws_k994).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-k963 = 'Y';
                     || (Util.Str(ws_k963).ToUpper() == "Y"
            //        	    and ws-k998 not = 'Y';
                     && Util.Str(ws_k998).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-k964 = 'Y';
                      || (Util.Str(ws_k964).ToUpper() == "Y"
            //        	    and ws-k996 not = 'Y';
                       && Util.Str(ws_k996).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-c960 = 'Y';
                   || (Util.Str(ws_c960).ToUpper() == "Y"
            //        	    and ws-c990 not = 'Y';
                    && Util.Str(ws_c990).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-c961 = 'Y';
                      || (Util.Str(ws_c961).ToUpper() == "Y"
            //        	    and ws-c992 not = 'Y';
                       && Util.Str(ws_c992).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-c962 = 'Y';
                     || (Util.Str(ws_c962).ToUpper() == "Y"
            //        	    and ws-c994 not = 'Y';
                        && Util.Str(ws_c994).ToUpper() != "Y"
            //            );
                           )
            //        or  (	ws-c963 = 'Y';
                      || (Util.Str(ws_c963).ToUpper() == "Y"
            //        	    and ws-c986 not = 'Y';
                     && Util.Str(ws_c986).ToUpper() != "Y"
            //            );
                          )
            //        or  (	ws-c964 = 'Y';
                      || (Util.Str(ws_c964).ToUpper() == "Y"
            //        	    and ws-c996 not = 'Y';
                      && Util.Str(ws_c996).ToUpper() != "Y"
            //            );
                          )
            //  then;
            )
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 122;
                //      perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  ws-g556 = "Y"  and ws-g400-g620 = "N" then       
            if (ws_g556 == "Y" && Util.Str(ws_g400_g620).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 125;
                //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if ws-a120 = "Y"  and ws-z491-to-z499 = "N"  then      
            if (Util.Str(ws_a120).ToUpper() == "Y" && Util.Str(ws_z491_to_z499).ToUpper() == "N")
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 126;
                //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //if (Util.Str(ws_e402_e403).ToUpper() == "Y" && Util.Str(ws_g247).ToUpper() != "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 127;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (Util.Str(hold_bilateral[ss_write_dtl]).ToUpper() == "Y" && hold_sv_nbr_serv[ss_write_dtl] == 1)
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 131;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (Util.Str(ws_e797).ToUpper() == "Y" && Util.Str(ws_z491_z580).ToUpper() == "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 132;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (Util.Str(ws_e409_e410).ToUpper() == "Y" && Util.Str(ws_e414).ToUpper() == "Y" && hdr_manual_review != "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 133;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if ((await hold_oma_cd_grp(ss_write_dtl) == "G231" || await hold_oma_cd_grp(ss_write_dtl) == "G223" || await hold_oma_cd_grp(ss_write_dtl) == "Z228") && hold_sv_nbr_serv[ss_write_dtl] > 1 && hdr_manual_review != "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 134;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (await hold_oma_cd_grp(ss_write_dtl) == "K704")
            //{
            //    ws_sv_date = Util.NumInt(hold_sv_date_grp[ss_write_dtl]);
            //    ws_birth_date = Util.NumInt(hdr_birth_date_long_grp);
            //    date_difference_in_days = (ws_sv_date - ws_birth_date) / 10000;

            //    if (date_difference_in_days > 18 && (flag_claim_source != price_only_claim))
            //    {
            //        err_warn_msg = ws_error_literal;
            //        //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //        await xb0_print_warning_line();
            //        await xb0_99_exit();
            //        ws_carriage_ctrl = 1;
            //        err_ind = 120;
            //        //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //        await zb0_build_write_err_rpt_line();
            //        await zb0_99_exit();
            //    }
            //}

            //if (ws_p030 == "Y" && (ws_annn == "Y" || ws_cnnn == "Y"))
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 135;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (ws_a895 == "Y" && (ws_annn != "Y" && ws_wnnn != "Y" && ws_knnn != "Y"))
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 136;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (ws_z512 == "Y" && ws_z514 == "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 137;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (ws_z580 == "Y" && ws_z491_to_z499 == "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 138;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (ws_edit_80 == "Y" && ws_total_nbr_svc > 8)
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 139;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            //if (ws_X9nn == "Y" && ws_a075 == "Y")
            //{
            //    err_warn_msg = ws_error_literal;
            //    //      perform xb0-print-warning-line  thru    xb0-99-exit;
            //    await xb0_print_warning_line();
            //    await xb0_99_exit();
            //    ws_carriage_ctrl = 1;
            //    err_ind = 140;
            //    //      perform zb0-build-write-err-rpt-line  thru    zb0-99-exit.
            //    await zb0_build_write_err_rpt_line();
            //    await zb0_99_exit();
            //}

            objSuspend_dtl_rec.CLMDTL_DOC_OHIP_NBR = Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_OHIP_NBR); //  clmhdr_doc_pract_nbr;
            objSuspend_dtl_rec.CLMDTL_ACCOUNTING_NBR = Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR);
        }

        // newu701_oscar_dtl_edit_check.rtn
        private async Task hb0_99_exit()
        {
            Util.Trakker(++ctr, "hb0_99_exit");

            //     exit.;
        }

        private async Task ia0_proc_rec_type_address()
        {
            Util.Trakker(++ctr, "ia0_proc_rec_type_address");

            objSuspend_address_rec.ADD_ADDRESS_LINE_1 = Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_1);
            objSuspend_address_rec.ADD_ADDRESS_LINE_2 = Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_2);
            objSuspend_address_rec.ADD_ADDRESS_LINE_3 = Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_3);
            objSuspend_address_rec.ADD_POSTAL_CODE = Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_post_cd1) + Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_post_cd2) + Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_post_cd3) + Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_post_cd4) + Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_post_cd5) + Util.Str(objUnpriced_claims_record.Unpriced_pat_addr_post_cd6);
        }

        private async Task ia0_99_exit()
        {
            Util.Trakker(++ctr, "ia0_99_exit");

            //     exit.;
        }

        private async Task ka0_proc_rec_type_trailer()
        {
            Util.Trakker(++ctr, "ka0_proc_rec_type_trailer");

            //     inspect unpriced-trailer-clmhdr1-cnt  replacing all space-char by zeros.;
            objUnpriced_claims_record.Unpriced_trailer_clmhdr1_cnt = Util.NumInt(Util.Str(objUnpriced_claims_record.Unpriced_trailer_clmhdr1_cnt).Replace(' ', '0'));

            //     inspect unpriced-trailer-clmhdr2-cnt  replacing all space-char by zeros.;
            objUnpriced_claims_record.Unpriced_trailer_clmhdr2_cnt = Util.NumInt(Util.Str(objUnpriced_claims_record.Unpriced_trailer_clmhdr2_cnt).Replace(' ', '0'));

            //     inspect unpriced-trailer-itm-cnt      replacing all space-char by zeros.;
            objUnpriced_claims_record.Unpriced_trailer_itm_cnt = Util.NumInt(Util.Str(objUnpriced_claims_record.Unpriced_trailer_itm_cnt).Replace(' ', '0'));

            //     inspect unpriced-trailer-pat-addr-cnt replacing all space-char by zeros.;
            objUnpriced_claims_record.Unpriced_trailer_pat_addr_cnt = Util.NumInt(Util.Str(objUnpriced_claims_record.Unpriced_trailer_pat_addr_cnt).Replace(' ', '0'));

            //     perform xx0-process-hold-dtls	thru xx0-99-exit.;
            await xx0_process_hold_dtls();
            await xx0_99_exit();

            //  if (last-record-is-h) or (detail-written) then 
            if (Util.Str(last_record_type_flag).Equals(last_record_is_h) || Util.Str(detail_written_flag).Equals(detail_written))
            {
                detail_written_flag = "N";
                //      perform tf0-write-addr-rec thru tf0-99-exit.;
                await tf0_write_addr_rec();
                await tf0_99_exit();
            }

            trl_h_count = Util.NumInt(objUnpriced_claims_record.Unpriced_trailer_clmhdr1_cnt);
            trl_r_count = Util.NumInt(objUnpriced_claims_record.Unpriced_trailer_clmhdr2_cnt);
            trl_t_count = Util.NumInt(objUnpriced_claims_record.Unpriced_trailer_itm_cnt);
            trl_a_count = Util.NumInt(objUnpriced_claims_record.Unpriced_trailer_pat_addr_cnt);

            //     add ctr-h-recs-read;
            //         ctr-h-recs-skipped      giving ctr-tot-h-recs.;
            ctr_tot_h_recs = ctr_h_recs_read + ctr_h_recs_skipped;

            //     add ctr-r-recs-read;
            //         ctr-r-recs-skipped      giving ctr-tot-r-recs.;
            ctr_tot_r_recs = ctr_r_recs_read + ctr_r_recs_skipped;

            //     add ctr-t-recs-read;
            //         ctr-t-recs-read-skipped giving ctr-tot-t-recs.;
            ctr_tot_t_recs = ctr_t_recs_read + ctr_t_recs_read_skipped;

            //     add ctr-a-recs-read;
            //         ctr-a-recs-read-skipped giving ctr-tot-a-recs.;
            ctr_tot_a_recs = ctr_a_recs_read + ctr_a_recs_read_skipped;

            //  if trl-h-count not = ctr-tot-h-recs then            
            if (trl_h_count != ctr_tot_h_recs)
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 16;
                err_ctr_h_count = ctr_tot_h_recs;
                err_trl_h_count = trl_h_count;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if trl-r-count not = ctr-tot-r-recs then            
            if (trl_r_count != ctr_tot_r_recs)
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 34;
                err_ctr_r_count = ctr_tot_r_recs;
                err_trl_r_count = trl_r_count;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if trl-t-count not = ctr-tot-t-recs then        
            if (trl_t_count != ctr_tot_t_recs)
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 17;
                err_ctr_t_count = ctr_tot_t_recs;
                err_trl_t_count = trl_t_count;
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if trl-a-count not = ctr-tot-a-recs then    
            if (trl_a_count != ctr_tot_a_recs)
            {
                err_warn_msg = ws_error_literal;
                //    perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 18;
                err_ctr_a_count = ctr_tot_a_recs;
                err_trl_a_count = trl_a_count;
                //    perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            // if  trl-b-count not = zero and trl-b-count not = ctr-b-recs-read then          
            if (trl_b_count != 0 && trl_b_count != ctr_b_recs_read)
            {
                err_warn_msg = ws_error_literal;
                //      perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 19;
                err_ctr_b_count = ctr_b_recs_read;
                err_trl_b_count = trl_b_count;
                //   perform zb0-build-write-err-rpt-line thru    zb0-99-exit.
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }

            //     perform ka1-print-batch-audit-tots  thru    ka1-99-exit.;
            await ka1_print_batch_audit_tots();
            await ka1_99_exit();

            ctr_hdr2_rec = 0;
            ctr_addr_rec = 0;

        }

        private async Task ka0_99_exit()
        {
            Util.Trakker(++ctr, "ka0_99_exit");

            //     exit.;
        }

        private async Task ka1_print_batch_audit_tots()
        {
            Util.Trakker(++ctr, "ka1_print_batch_audit_tots");

            ctr_lines_printed = 99;
            ws_carriage_ctrl = 3;

            objRu701_work_rec.Ru701_page_area = "9";

            audit_title = "**********AUDIT COUNTERS**********";
            audit_value = 0;
            audit_value_2 = 0;
            audit_value_3 = 0;

            //objRpt_line.rpt_line = audit_line;
            objRpt_line.Rpt_line1 = await audit_line_grp();

            //audit_line = "";
            await audit_line_grp(true);
            //   perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();

            await zz0_99_exit();

            ws_carriage_ctrl = 3;
            // move "TOTAL NBR INPUT RECORDS READ= "       to audit-title. 
            audit_title = "TOTAL NBR INPUT RECORDS READ= ";
            audit_value = ctr_recs_read;
            audit_value_2 = ctr_recs_read;

            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            ws_carriage_ctrl = 2;
            // move "NBR OF BATCH   RECORDS READ = "       to audit-title. 
            audit_title = "NBR OF BATCH   RECORDS READ = ";
            audit_value = ctr_b_recs_read;
            audit_value_2 = ctr_b_recs_read;

            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            //  move "NBR OF TRAILER RECORDS READ = "       to audit-title.
            audit_title = "NBR OF TRAILER RECORDS READ = ";
            audit_value = ctr_e_recs_read;
            audit_value_2 = ctr_e_recs_read;

            objRpt_line.Rpt_line1 = await audit_line_grp();

            //audit_line = "";
            await audit_line_grp(true);

            //  perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF HEADER1 RECORDS READ = "       to audit-title. 
            audit_title = "NBR OF HEADER1 RECORDS READ = ";
            audit_value = ctr_h_recs_read;
            audit_value_3 = ctr_h_recs_read;
            audit_value_4 = ctr_h_recs_read;

            objRpt_line.Rpt_line1 = await audit_line_grp();

            //audit_line = "";
            await audit_line_grp(true);

            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF HEADER2 RECORDS READ = "       to audit-title. 
            audit_title = "NBR OF HEADER2 RECORDS READ = ";
            audit_value = ctr_r_recs_read;
            audit_value_3 = ctr_r_recs_read;
            audit_value_4 = ctr_r_recs_read;

            objRpt_line.Rpt_line1 = await audit_line_grp();

            //audit_line = "";
            await audit_line_grp(true);

            //  perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF DETAIL  RECORDS READ = "       to audit-title. 
            audit_title = "NBR OF DETAIL  RECORDS READ = ";
            audit_value = ctr_t_recs_read;
            audit_value_3 = ctr_t_recs_read;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //  perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF DETAIL  RECS SKIPPED = "       to audit-title. 
            audit_title = "NBR OF DETAIL  RECS SKIPPED = ";
            audit_value = ctr_t_recs_read_skipped;
            audit_value_2 = ctr_t_recs_read_skipped;

            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);

            //  perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF ADDRESS RECORDS READ = "       to audit-title. 
            audit_title = "NBR OF ADDRESS RECORDS READ = ";
            audit_value = ctr_a_recs_read;
            audit_value_4 = ctr_a_recs_read;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);

            //   perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "TOTAL SVCS HDRS/DETAILS READ= "       to audit-title. 
            audit_title = "TOTAL SVCS HDRS/DETAILS READ= ";

            audit_value_5 = ctr_tot_svcs_read*100;
            objRpt_line.Rpt_line1 = await audit_line_grp();

            //audit_line = "";
            await audit_line_grp(true);

            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "TOTAL $$$  HDRS/DETAILS READ= "       to audit-title. 
            audit_title = "TOTAL $$$  HDRS/DETAILS READ= ";

            audit_value_5 = Util.NumInt(ctr_tot_dollars_read*100);
            objRpt_line.Rpt_line1 = await audit_line_grp();

            //audit_line = "";
            await audit_line_grp(true);

            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF ADDRESS RECS SKIPPED = "       to audit-title. 
            audit_title = "NBR OF ADDRESS RECS SKIPPED = ";
            audit_value = ctr_a_recs_read_skipped;
            audit_value_2 = ctr_a_recs_read_skipped;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            ws_carriage_ctrl = 3;
            // move "NBR OF HEADER  RECORDS WRITTEN = "    to audit-title. 
            audit_title = "NBR OF HEADER  RECORDS WRITTEN = ";
            audit_value_2 = ctr_suspend_hdr_writes;
            audit_value_4 = ctr_suspend_hdr_writes;

            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);

            //   perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            ws_carriage_ctrl = 2;
            // move "NBR OF HEADER1 RECORDS SKIPPED = "    to audit-title. 
            audit_title = "NBR OF HEADER1 RECORDS SKIPPED = ";
            audit_value_2 = ctr_h_recs_skipped;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF HEADER2 RECORDS SKIPPED = "    to audit-title. 
            audit_title = "NBR OF HEADER2 RECORDS SKIPPED = ";
            audit_value_2 = ctr_r_recs_skipped;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF DETAIL  RECORDS WRITTEN = "    to audit-title. 
            audit_title = "NBR OF DETAIL  RECORDS WRITTEN = ";
            audit_value_2 = ctr_suspend_dtl_writes;
            audit_value_3 = ctr_suspend_dtl_writes;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //  perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF DESCRIPTION RECORDS WRITTEN = "    to audit-title. 
            audit_title = "NBR OF DESCRIPTION RECORDS WRITTEN = ";
            audit_value_2 = ctr_suspend_desc_writes;
            audit_value_3 = ctr_suspend_desc_writes;

            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            // move "NBR OF ADDRESS RECORDS WRITTEN = "    to audit-title. 
            audit_title = "NBR OF ADDRESS RECORDS WRITTEN = ";
            audit_value_4 = ctr_suspend_addr_writes;
            objRpt_line.Rpt_line1 = await audit_line_grp();
            //audit_line = "";
            await audit_line_grp(true);
            //     perform zz0-write-err-rpt-line              thru zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();

            ctr_lines_printed = 99;
        }

        private async Task ka1_99_exit()
        {
            Util.Trakker(++ctr, "ka1_99_exit");

            //     exit.;
        }

        private async Task xb0_print_warning_line()
        {
            Util.Trakker(++ctr, "xb0_print_warning_line");

            ws_carriage_ctrl = 2;
            err_ind = 1;
            err_msg_pract_nbr = Util.Str(batch_provider_nbr);
            err_msg_account_id = Util.Str(hdr_accounting_nbr);
            //     perform zb0-build-write-err-rpt-line thru    zb0-99-exit.;
            await zb0_build_write_err_rpt_line();
            await zb0_99_exit();
        }

        private async Task xb0_99_exit()
        {
            Util.Trakker(++ctr, "xb0_99_exit");

            //     exit.;
        }

        private async Task xd0_verify_date()
        {
            Util.Trakker(++ctr, "xd0_verify_date");

            flag_date = "Y";

            //  if   ws-date-mm < 1 or ws-date-mm > 12  then            
            if (ws_date_mm < 1 || ws_date_mm > 12)
            {
                flag_date = "N";
            }
            //  else  if   ws-date-dd < 1  or ws-date-dd > max-nbr-days (ws-date-mm)   then
            else if (ws_date_dd < 1 || ws_date_dd > max_nbr_days[ws_date_mm])
            {
                flag_date = "N";
            }
        }

        private async Task xd0_99_exit()
        {
            Util.Trakker(++ctr, "xd0_99_exit");
            //     exit.;
        }

        private async Task ta0_read_diskette()
        {
            Util.Trakker(++ctr, "ta0_read_diskette");

            hold_trans_id = Util.Str(objUnpriced_claims_record.Unpriced_trans_id);
            hold_rec_type = Util.Str(objUnpriced_claims_record.Unpriced_input_rec_type);

            hold_in_rec_type_grp = Util.Str(hold_trans_id) + Util.Str(hold_rec_type);
            last_record_type_flag = hold_in_rec_type_grp;

            //unpriced_Claims_record = low_values;  // replacing the null values to spaces..

            // read unpriced-claims-file;
            //         at end;
            //             eof_input_file_flag = "Y";
            //             go to ta0-99-exit.;


            if (unrpiced_rec_ctr >= Unpriced_claims_record_Collection.Count() || Unpriced_claims_record_Collection.Count() == 0)
            {
                eof_input_file_flag = "Y";
                //    go to ta0-99-exit.;
                await ta0_99_exit();
                return;
            }
            else
            {
                objUnpriced_claims_record = Unpriced_claims_record_Collection[unrpiced_rec_ctr];
                unrpiced_rec_ctr++;
            }


            //     inspect unpriced-claims-record replacing all low-values by spaces.;
            //     inspect unpriced-claims-record replacing all carriage-return by spaces.;

            hold_trans_id = Util.Str(objUnpriced_claims_record.Unpriced_trans_id);
            hold_rec_type = Util.Str(objUnpriced_claims_record.Unpriced_input_rec_type);
            hold_in_rec_type_grp = Util.Str(hold_trans_id) + Util.Str(hold_rec_type);
            record_type_flags = hold_in_rec_type_grp;

            //  if skip-processing-this-acct-id and t-record   then 
            if (Util.Str(skip_process_this_acct_id_flag).Equals(skip_processing_this_acct_id) && Util.Str(record_type_flags).Equals(t_record))
            {
                //         add 1                   to      ctr-t-recs-read-skipped;
                ctr_t_recs_read_skipped++;
            }
            //  else if   (skip-processing-this-acct-id or skip-hdr-addr-but-write-dtl)  and a-record  then            
            else if ((Util.Str(skip_process_this_acct_id_flag).Equals(skip_processing_this_acct_id) || Util.Str(skip_process_this_acct_id_flag).Equals(skip_hdr_addr_but_write_dtl)) && Util.Str(record_type_flags).Equals(a_record))
            {
                //             add 1               to      ctr-a-recs-read-skipped;
                ctr_a_recs_read_skipped++;
            }
            else
            {
                //             next sentence.;
            }

            //     add 1                       to      ctr-recs-read.;
            ctr_recs_read++;
        }

        private async Task ta0_99_exit()
        {
            Util.Trakker(++ctr, "ta0_99_exit");

            //     exit.;
        }

        private async Task tb0_read_doc()
        {
            Util.Trakker(++ctr, "tb0_read_doc");

            flag_doc = "Y";
            //     read doc-mstr;
            //         invalid key move "N"    to flag-doc;
            //                     go to tb0-99-exit.;

            objDoc_mstr_rec = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = objUnpriced_claims_record.Unpriced_bathdr_doc_nbr
            }.Collection().FirstOrDefault();

            if (objDoc_mstr_rec == null)
            {
                flag_doc = "N";
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();

                await tb0_99_exit();
                return;
            }
        }

        private async Task tb0_99_exit()
        {
            Util.Trakker(++ctr, "tb0_99_exit");

            //     exit.;
        }

        private async Task tc0_write_hdr_rec()
        {
            Util.Trakker(++ctr, "tc0_write_hdr_rec");

            string tempValues = string.Empty;

            objSuspend_hdr_rec.CLMHDR_TOT_CLAIM_AR_OMA = ctr_tot_dollars_oma;
            objSuspend_hdr_rec.CLMHDR_TOT_CLAIM_AR_OHIP = ctr_tot_dollars_ohip;

            objSuspend_hdr_rec.CLMHDR_AMT_TECH_BILLED = ctr_tot_tech_claim;

            objSuspend_hdr_rec.CLMHDR_TAPE_SUBMIT_IND = "";

            // if  refer-doc-not-require  and clmhdr-refer-doc-nbr not = zeroes then            
            if (flag_refer_doc.Equals(refer_doc_not_require) && Util.NumInt(objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR) != 0)
            {
                objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR = 0;
            }

            // if update-suspense  then     
            if (Util.Str(flag_update_suspense).Equals(update_suspense))
            {
                //      add 1                           to      ctr-suspend-hdr-writes;
                ctr_suspend_hdr_writes++;
                // 	    write suspend-hdr-rec;
                //         invalid key;
                //            skip_process_this_acct_id_flag = "D";
                //            objSuspend_hdr_rec.clmhdr_status = "Y";
                //     		  rewrite suspend-hdr-rec;
                //         	        invalid key;
                //            	   display "SERIOUS IMPOSSIBLE ERROR #2 SUSPEND HDR FILE - KEY IS = ",suspend-hdr-id.;

                try
                {
                    tempValues = Util.Str(objSuspend_hdr_rec.CLMHDR_CLINIC_NBR_1_2).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_NBR).PadRight(3) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_WEEK).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DAY).PadLeft(1, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_CLAIM_NBR).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ADJ_OMA_CD).PadRight(4, '0') +   // x999
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ADJ_OMA_SUFF).PadRight(1, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ADJ_ADJ_NBRF).PadLeft(1, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_BATCH_TYPE).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ADJ_CD_SUB_TYPE).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_NBR_OHIP).PadLeft(6, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_SPEC_CD).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_REFER_DOC_NBR).PadLeft(6, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DIAG_CD).PadLeft(3, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_LOC).PadRight(4) +         // x999
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_HOSP).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_AGENT_CD).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ADJ_CD).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_TAPE_SUBMIT_IND).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_KEY_TYPE).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_KEY_DATA).PadRight(15) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM6).PadRight(6) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM3).PadRight(3) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_REFERENCE).PadRight(11) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DATE_ADMIT).PadLeft(8, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_DEPT).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DATE_CASH_TAPE_PAYMENT).PadRight(8) +
                                  Util.NumInt(objSuspend_hdr_rec.CLMHDR_CURR_PAYMENT).ToString().PadLeft(7, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DATE_PERIOD_END).PadLeft(8, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_CYCLE_NBR).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DATE_SYS).PadRight(8) +
                                  Util.ConvertZone(Util.NumInt(Util.NumDec(objSuspend_hdr_rec.CLMHDR_AMT_TECH_BILLED)*100), 7, true) +
                                  Util.ConvertZone(Util.NumInt(Util.NumDec(objSuspend_hdr_rec.CLMHDR_AMT_TECH_PAID)*100), 7, true) +
                                  Util.ConvertZone(Util.NumInt(Util.NumDec(objSuspend_hdr_rec.CLMHDR_TOT_CLAIM_AR_OMA)*100), 8, true) +
                                  Util.ConvertZone(Util.NumInt(Util.NumDec(objSuspend_hdr_rec.CLMHDR_TOT_CLAIM_AR_OHIP)*100), 8, true) +
                                  Util.ConvertZone(Util.NumInt(Util.NumDec(objSuspend_hdr_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS)*100), 8, true) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_STATUS_OHIP).PadRight(2) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ORIG_CLAIM_NBR).PadLeft(2, '0') + 
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_STATUS).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_NBR).PadRight(12) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_VER).PadRight(2) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_HEALTH_CARE_PROV).PadRight(2) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_RELATIONSHIP).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_PATIENT_SURNAME).PadRight(25) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_SUBSCR_INITIALS).PadRight(3) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_WCB_CLAIM_NBR).PadRight(9) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_WCB_ACCIDENT_DATE).PadLeft(8, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_WCB_EMPLOYER_NAME_ADDR).PadRight(40) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_WCB_EMPLOYER_POSTAL_CODE).PadRight(6) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_CONFIDENTIAL_FLAG).PadRight(1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_NBR_SUSPEND_DESC_RECS).PadLeft(2, '0') +
                                  new string(' ', 1) +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_OHIP_NBR).PadLeft(6, '0') +
                                  Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR).PadRight(8) +
                                  Util.Str(objSuspend_hdr_rec.SUSP_HDR_DOC_NBR).PadRight(3) +
                                  Util.Str(objSuspend_hdr_rec.SUSP_HDR_CLINIC_NBR).PadLeft(2, '0') +
                                  Util.Str(objSuspend_hdr_rec.SUSP_HDR_ACRONYM).PadRight(9) +
                                  Util.Str(objSuspend_hdr_rec.SUSP_HDR_ACCOUNTING_NBR).PadRight(8) +
                                  Util.Str(objSuspend_hdr_rec.DEBUG_INFO).PadRight(512) +
                                  Util.Str(objSuspend_hdr_rec.ERROR_FLAG).PadLeft(1, '0') +
                                  Util.Str(objSuspend_hdr_rec.INPUT_FILE_LOCATION).PadRight(256);

                       objSuspend_Hdr.AppendOutputFile(tempValues);  //

                }
                catch (Exception e)
                {
                    skip_process_this_acct_id_flag = "D";
                    objSuspend_hdr_rec.CLMHDR_STATUS = "Y";
                    Console.WriteLine("SERIOUS IMPOSSIBLE ERROR #2 SUSPEND HDR FILE - KEY IS = " + Util.Str(objSuspend_hdr_rec.CLMHDR_DOC_OHIP_NBR) + Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR));
                }
            }

            // if skip-processing-this-acct-id or skip-hdr-addr-but-write-dtl then            
            if (Util.Str(skip_process_this_acct_id_flag).Equals(skip_processing_this_acct_id) || Util.Str(skip_process_this_acct_id_flag).Equals(skip_hdr_addr_but_write_dtl))
            {
                err_warn_msg = ws_error_literal;
                //         perform xb0-print-warning-line  thru    xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 9;
                //         perform zb0-build-write-err-rpt-line thru    zb0-99-exit            
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //         add 1                           to      ctr-h-recs-skipped;
                ctr_h_recs_skipped++;
                //  	   go to tc0-99-exit.;
                await tc0_99_exit();
                return;
            }

            ctr_tot_dollars_oma = 0;
            ctr_tot_dollars_ohip = 0;
            ctr_tot_tech_claim = 0;

        }

        private async Task tc0_99_exit()
        {
            Util.Trakker(++ctr, "tc0_99_exit");

            //     exit.;
        }

        private async Task td0_write_susp_dtl()
        {
            Util.Trakker(++ctr, "td0_write_susp_dtl");

            // if update-suspense then             
            if (Util.Str(flag_update_suspense).Equals(update_suspense))
            {
                //    	add 1                       to ctr-suspend-dtl-writes;
                ctr_suspend_dtl_writes++;

                string tempValues = Util.Str(objSuspend_dtl_rec.CLMDTL_BATCH_NBR).PadRight(8) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_CLAIM_NBR).PadLeft(2, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_OMA_CD).PadRight(4) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_OMA_SUFF).PadRight(1) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_ADJ_NBR).PadLeft(1, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_REV_GROUP_CD).PadRight(3) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_AGENT_CD).PadLeft(1, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_ADJ_CD).PadRight(1) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_NBR_SERV).PadLeft(2, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_YY).PadLeft(4, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_MM).PadLeft(2, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_DD).PadLeft(2, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_NBR1).PadRight(1, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_DAY1).PadRight(2) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_NBR2).PadRight(1, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_DAY2).PadRight(2) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_NBR3).PadRight(1, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_SV_DAY3).PadRight(2) +
                                    Util.ConvertZone(Util.NumInt(objSuspend_dtl_rec.CLMDTL_AMT_TECH_BILLED*100), 7, true) +
                                    Util.ConvertZone(Util.NumInt(objSuspend_dtl_rec.CLMDTL_FEE_OMA*100), 8, true) +
                                    Util.ConvertZone(Util.NumInt(objSuspend_dtl_rec.CLMDTL_FEE_OHIP*100), 8, true) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_DATE_PERIOD_END).PadRight(8) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_CYCLE_NBR).PadLeft(3, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_DIAG_CD).PadLeft(3, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_DIAG_CD_LOCAL).PadLeft(3, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_STATUS).PadRight(1) +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_DOC_OHIP_NBR).PadLeft(6, '0') +
                                    Util.Str(objSuspend_dtl_rec.CLMDTL_ACCOUNTING_NBR).PadRight(8);


                // 	    write suspend-dtl-rec.;
                objSuspend_Dtl.AppendOutputFile(tempValues);             //      
            }
        }

        private async Task td0_99_exit()
        {
            Util.Trakker(++ctr, "td0_99_exit");

            //     exit.;
        }

        private async Task te0_write_disk_out()
        {
            Util.Trakker(++ctr, "te0_write_disk_out");

            // if create-priced-file then            
            if (flag_create_priced_file.Equals(create_priced_file))
            {
                // 	   add 1                       to ctr-diskout-writes;
                ctr_diskout_writes++;
                // 	   write diskout-output-rec.;
                string tmpData = Util.Str(objDiskout_output_rec.Diskout_clmhdr_clinic_nbr).PadRight(2) +
                             Util.Str(objDiskout_output_rec.Diskout_clmhdr_claim).PadRight(8) +
                             Util.Str(objDiskout_output_rec.Diskout_oma_svc_code).PadRight(4) +
                             Util.Str(objDiskout_output_rec.Diskout_oma_svc_suff).PadRight(1) +
                             Util.Str(objDiskout_output_rec.Diskout_ohip_amt_billed).PadLeft(6, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_svc_date_yy).PadLeft(4, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_svc_date_mm).PadLeft(2, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_svc_date_dd).PadLeft(2, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_nbr_serv).PadLeft(2, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_oma_amt_billed).PadLeft(6, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_priced_tech).PadLeft(6, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_basic_tech).PadLeft(6, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_basic_prof).PadLeft(6, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_basic_fee).PadLeft(6, '0') +
                             Util.Str(objDiskout_output_rec.Diskout_cr).PadRight(1) +
                             Util.Str(objDiskout_output_rec.Diskout_lf).PadRight(1);

                objPriced_Claims_File.AppendOutputFile(tmpData, true);                
            }
        }

        private async Task te0_99_exit()
        {
            Util.Trakker(++ctr, "te0_99_exit");

            //     exit.;
        }

        private async Task tf0_write_addr_rec()
        {
            Util.Trakker(++ctr, "tf0_write_addr_rec");

            //  if update-suspense then 
            if (flag_update_suspense.Equals(update_suspense))
            {
                // 	    add 1                      to ctr-suspend-addr-writes;
                ctr_suspend_addr_writes++;
                // 	    write suspend-address-rec;
                //             invalid key;
                //                go to tf0-99-exit.;

                try
                {
                    string tempValues = Util.Str(objSuspend_address_rec.ADD_ADDRESS_LINE_1).PadRight(25) +
                                       Util.Str(objSuspend_address_rec.ADD_ADDRESS_LINE_2).PadRight(25) +
                                       Util.Str(objSuspend_address_rec.ADD_ADDRESS_LINE_3).PadRight(25) +
                                       Util.Str(objSuspend_address_rec.ADD_POSTAL_CODE).PadRight(9) +
                                       Util.Str(objSuspend_address_rec.ADD_SURNAME).PadRight(25) +
                                       Util.Str(objSuspend_address_rec.ADD_FIRST_NAME).PadRight(25) +
                                       Util.Str(objSuspend_address_rec.ADD_BIRTH_DATE).PadLeft(8, '0') +
                                       Util.Str(objSuspend_address_rec.ADD_SEX).PadRight(1) +
                                       Util.Str(objSuspend_address_rec.ADD_PHONE_NO).PadRight(20) +
                                       Util.Str(objSuspend_address_rec.ADD_DOC_OHIP_NBR).PadLeft(6, '0') +
                                       Util.Str(objSuspend_address_rec.ADD_ACCOUNTING_NBR).PadRight(8) +
                                       Util.Str(objSuspend_address_rec.DEBUG_INFO).PadRight(256) +
                                       Util.Str(objSuspend_address_rec.ERROR_FLAG).PadLeft(1, '0') +
                                       Util.Str(objSuspend_address_rec.INPUT_FILE_LOCATION).PadRight(256);


                    // 	    write suspend-address-rec;
                    objSuspend_Address.AppendOutputFile(tempValues);      //                
                }
                catch (Exception e)
                {
                    await tf0_99_exit();
                    return;
                }
            }
        }

        private async Task tf0_99_exit()
        {
            Util.Trakker(++ctr, "tf0_99_exit");

            //     exit.;
        }

        private async Task tg0_read_oma_fee_mstr()
        {
            Util.Trakker(++ctr, "tg0_read_oma_fee_mstr");

            flag_oma = "Y";
            //     read oma-fee-mstr;
            //         invalid key move "N"    to flag-oma.;

            objFee_mstr_rec = new F040_OMA_FEE_MSTR
            {
                WhereFee_oma_cd_ltr1 = objFee_mstr_rec.FEE_OMA_CD_LTR1,
                WhereFiller_numeric = objFee_mstr_rec.FILLER_NUMERIC
            }.Collection().FirstOrDefault();

            if (objFee_mstr_rec == null)
            {
                objFee_mstr_rec = new F040_OMA_FEE_MSTR();
                flag_oma = "N";
            }
        }

        private async Task tg0_99_exit()
        {
            Util.Trakker(++ctr, "tg0_99_exit");

            //     exit.;
        }

        private async Task uj1_read_isam_const_mstr()
        {
            Util.Trakker(++ctr, "uj1_read_isam_const_mstr");

            flag_lock = "N";
            //     read    iconst-mstr;
            //         invalid key;
            //            fatal_error_flag = "Y";
            //             go to uj1-99-exit.;

            if (objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 == 1)
            {
                objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1
                {
                    WhereConst_rec_nbr = 1
                }.Collection().FirstOrDefault();

                if (objConstants_mstr_rec_1 == null)
                {
                    objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1();
                    fatal_error_flag = "Y";
                    //   go to uj1-99-exit.;
                    await uj1_99_exit();
                    return;
                }
            }
            else if (objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 == 2)
            {
                objConstants_mstr_rec_2 = new CONSTANTS_MSTR_REC_2
                {
                    WhereConst_rec_nbr = 2
                }.Collection().FirstOrDefault();

                if (objConstants_mstr_rec_2 == null)
                {
                    objConstants_mstr_rec_2 = new CONSTANTS_MSTR_REC_2();
                    fatal_error_flag = "Y";
                    //   go to uj1-99-exit.;
                    await uj1_99_exit();
                    return;
                }
            }

            fatal_error_flag = "N";
            //     add  1                              to ctr-read-const-mstr.;
            ctr_read_const_mstr++;
        }

        private async Task uj1_99_exit()
        {
            Util.Trakker(++ctr, "uj1_99_exit");

            //     exit.;
        }

        private async Task xc0_check_oma_code()
        {
            Util.Trakker(++ctr, "xc0_check_oma_code");

            //     perform tg0-read-oma-fee-mstr        thru tg0-99-exit.;
            await tg0_read_oma_fee_mstr();
            await tg0_99_exit();

            //  if  not valid-oma-code and not price-only-claim   then       
            if (!Util.Str(flag_oma).Equals(valid_oma_code) && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                ws_carriage_ctrl = 2;
                err_ind = 8;
                err_accounting_nbr = Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR);
                //      perform zb0-build-write-err-rpt-line    thru    zb0-99-exit;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
                //      objFee_mstr_rec.fee_mstr_rec = "";
                objFee_mstr_rec = new F040_OMA_FEE_MSTR();
            }
        }

        private async Task xc0_99_exit()
        {
            Util.Trakker(++ctr, "xc0_99_exit");

            //     exit.;
        }

        private async Task xx0_process_hold_dtls()
        {
            Util.Trakker(++ctr, "xx0_process_hold_dtls");

            // if batch-provider-nbr = "264978" then
            if (Util.NumInt(batch_provider_nbr) == 264978)
            {
                // 	   if hold-accounting-nbr = "00000004" then            
                if (hold_accounting_nbr == "00000004")
                {
                    // 	       next sentence;
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

            // if ss-clmdtl-oma > 0 then            
            if (ss_clmdtl_oma > 0)
            {
                ss_clmdtl_next_avail_dtl = ss_clmdtl_oma;
                flag_tech_prof_suffix_rule = "N";
                //     perform zz3-apply-tech-prof-suff-rules thru   zz3-99-exit;
                //   		varying ss-tech-prof-suff;
                //    		from    1;
                //  	    by      1;
                // 		    until ss-tech-prof-suff > ss-clmdtl-oma;
                ss_tech_prof_suff = 1;
                do
                {
                    await zz3_apply_tech_prof_suff_rules();
                    await zz3_99_exit();
                    ss_tech_prof_suff++;
                } while (ss_tech_prof_suff <= ss_clmdtl_oma);


                // 	   perform xx1-test-for-new-dtls	thru	xx1-99-exit;
                await xx1_test_for_new_dtls();
                await xx1_99_exit();

                ss_basic_times_desc_rec = 1;
                ss_basic_times = 0;
                //       perform ya0-price-claim         thru    ya0-99-exit;
                string retval =  await ya0_price_claim();
                if (Util.Str(retval).ToLower().Equals("ya0_98_display_fees") )
                {
                    goto _ya0_98_display_fees;
                }
                _ya0_calc_sectional_reductions:
                await ya0_calc_sectional_reductions();
                retval =  await ya0_increment_ss_from();
                if (retval.ToLower().Equals("ya0_calc_sectional_reductions"))
                {
                    goto _ya0_calc_sectional_reductions;
                }
                _ya0_98_display_fees:
                await ya0_98_display_fees();
                await ya0_99_exit();

                // 	   perform xx3-write-susp-desc	thru xx3-99-exit;
                await xx3_write_susp_desc();
                await xx3_99_exit();
                flag_desc_rec = "";
                flag_refer_doc = "N";
                // 	   perform xx2-write-susp-diskout-dtl      thru    xx2-99-exit;
                // 		     varying ss-write-dtl;
                //    		     from    1;
                //    		     by      1;
                // 		     until ss-write-dtl > ss-clmdtl-oma;
                ss_write_dtl = 1;
                do
                {

                    await xx2_write_susp_diskout_dtl();
                    await xx2_99_exit();
                    ss_write_dtl++;
                } while (ss_write_dtl <= ss_clmdtl_oma);

                detail_written_flag = "Y";
                ss_clmdtl_oma = 0;
                ss_price = 0;
                ss_write_dtl = 0;
                ws_special_add_on_cd_entered = "N";
                // 	    perform xx1a-reset-oma-flag	thru xx1a-99-exit;
                await xx1a_reset_oma_flag();
                await xx1a_99_exit();
                await Initialize_hold_oma_recs();
                //         perform aa1-init-hold-oma-rec      thru    aa1-99-exit;
                // 		       varying i;
                //    		       from    1;
                //    		       by      1;
                // 		       until   i  > ss-max-nbr-oma-det-rec-allow;
                i = 1;
                do
                {
                    await aa1_init_hold_oma_rec();
                    await aa1_99_exit();
                    i++;
                } while (i <= ss_max_nbr_oma_det_rec_allow);

                //          perform tc0-write-hdr-rec       thru tc0-99-exit;
                await tc0_write_hdr_rec();
                await tc0_99_exit();
            }
            // else if  ss-clmdtl-oma = 0 and ctr-hdr2-rec = 1 and ctr-addr-rec = 1 and not price-only-claim then            
            else if (ss_clmdtl_oma == 0 && ctr_hdr2_rec == 1 && ctr_addr_rec == 1 && !Util.Str(flag_claim_source).Equals(price_only_claim))
            {
                err_warn_msg = ws_error_literal;
                // 	      perform xb0-print-warning-line thru xb0-99-exit;
                await xb0_print_warning_line();
                await xb0_99_exit();
                ws_carriage_ctrl = 1;
                err_ind = 50;
                err_no_detail_claim = Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR);
                // 	      perform zb0-build-write-err-rpt-line thru zb0-99-exit.;
                await zb0_build_write_err_rpt_line();
                await zb0_99_exit();
            }
        }

        private async Task xx0_99_exit()
        {
            Util.Trakker(++ctr, "xx0_99_exit");

            //     exit.;
        }

        private async Task xx1_test_for_new_dtls()
        {
            Util.Trakker(++ctr, "xx1_test_for_new_dtls");

            //  if ss-clmdtl-next-avail-dtl > ss-clmdtl-oma then            
            if (ss_clmdtl_next_avail_dtl > ss_clmdtl_oma)
            {
                ss_clmdtl_oma = ss_clmdtl_next_avail_dtl;
            }
        }

        private async Task xx1_99_exit()
        {
            Util.Trakker(++ctr, "xx1_99_exit");

            //     exit.;
        }

        private async Task xx1a_reset_oma_flag()
        {
            Util.Trakker(++ctr, "xx1a_reset_oma_flag");

            ws_e078_premium = "N";
            ws_e020 = "N";
            ws_e719 = "N";
            ws_e720 = "N";
            ws_e717 = "N";
            ws_e702 = "N";
            ws_g123 = "N";
            ws_g223 = "N";
            ws_g265 = "N";
            ws_g385 = "N";
            ws_g281 = "N";
            ws_e793 = "N";
            ws_e022_e017_e016 = "N";
            ws_z570 = "N";
            ws_z571 = "N";
            ws_z555_z580 = "N";
            ws_z515_z760 = "N";
            ws_g228 = "N";
            ws_g231 = "N";
            ws_g264 = "N";
            ws_g384 = "N";
            ws_g381 = "N";
            ws_r905_s800 = "N";
            ws_annna = "N";
            ws_gnnna = "N";
            ws_k991_u997 = "N";

            ws_c998 = "N";
            ws_c999 = "N";
            ws_e798 = "N";
            ws_z400 = "N";
            ws_g400_other_codes = "N";
            ws_e409_e410 = "N";
            ws_c990_to_c997 = "N";

            ws_cnnn = "N";
            ws_e450 = "N";
            ws_j315 = "N";

            ws_c985 = "N";
            ws_g248_g062 = "N";
            ws_g222 = "N";
            ws_a770_a775 = "N";
            ws_X9nn = "N";
            ws_h112_h113 = "N";
            ws_hnnn = "N";
            ws_g489_s323 = "N";
            ws_g222_z805 = "N";
            ws_p014_p016 = "N";
            ws_g221 = "N";
            ws_g220 = "N";
            ws_s322_a198 = "N";
            ws_a765_c765 = "N";
            ws_g521_g395 = "N";
            ws_h104_h124 = "N";
            ws_g345_g339 = "N";
            ws_g431_g479 = "N";
            ws_gnnn = "N";
            ws_annn = "N";

            ws_c983 = "N";
            ws_j025 = "N";
            ws_j021 = "N";
            ws_j022 = "N";
            ws_z608 = "N";
            ws_z611_z602 = "N";
            ws_z403 = "N";
            ws_z408 = "N";
            ws_a195 = "N";
            ws_k002 = "N";
            ws_c122_c143 = "N";
            ws_e083 = "N";
            ws_c122_c982 = "N";
            ws_g489_g376 = "N";

            ws_a197_a198 = "N";
            ws_k189 = "N";
            ws_a190_a795 = "N";
            ws_k960 = "N";
            ws_k990 = "N";
            ws_k961 = "N";
            ws_k992 = "N";
            ws_k962 = "N";
            ws_k994 = "N";
            ws_k963 = "N";
            ws_k998 = "N";

            ws_k964 = "N";
            ws_k996 = "N";
            ws_c960 = "N";
            ws_c990 = "N";
            ws_c961 = "N";
            ws_c992 = "N";
            ws_c962 = "N";
            ws_c994 = "N";
            ws_c963 = "N";
            ws_c986 = "N";
            ws_c964 = "N";
            ws_c996 = "N";
            ws_e676 = "N";

            ws_g556 = "N";
            ws_g400_g620 = "N";
            ws_a120 = "N";
            ws_z491_to_z499 = "N";
            ws_g325 = "N";
            ws_e402_e403 = "N";
            ws_g247 = "N";
            ws_e797 = "N";
            ws_z491_z580 = "N";
            ws_e414 = "N";
            ws_p030 = "N";
            ws_a895 = "N";
            ws_wnnn = "N";
            ws_knnn = "N";
            ws_z512 = "N";
            ws_z514 = "N";
            ws_z580 = "N";
            ws_cnnn_c101 = "N";
            ws_total_nbr_svc = 0;
            ws_edit_80 = "N";
            ws_a075 = "N";
        }

        private async Task xx1a_99_exit()
        {
            Util.Trakker(++ctr, "xx1a_99_exit");
        }

        private async Task exit()
        {
            Util.Trakker(++ctr, "exit");
        }

        private async Task xx2_write_susp_diskout_dtl()
        {
            Util.Trakker(++ctr, "xx2_write_susp_diskout_dtl");

            //     add hold-fee-incoming(ss-write-dtl) to   ctr-tot-dollars-read.;
            ctr_tot_dollars_read += hold_fee_incoming[ss_write_dtl];

            //     add hold-fee-ohip(ss-write-dtl)	to   ctr-tot-dollars-ohip.;
            ctr_tot_dollars_ohip += hold_fee_ohip[ss_write_dtl];

            //     add hold-fee-oma (ss-write-dtl)	to   ctr-tot-dollars-oma.;
            ctr_tot_dollars_oma += hold_fee_oma[ss_write_dtl];

            //     add  hold-priced-tech(ss-write-dtl)	to   ctr-tot-tech-claim.;
            ctr_tot_tech_claim += hold_priced_tech[ss_write_dtl];

            //     perform hb0-build-susp-dtl-rec-dtl	thru hb0-99-exit.;
            await hb0_build_susp_dtl_rec_dtl();
            await hb0_99_exit();

            //     perform td0-write-susp-dtl           thru td0-99-exit.;
            await td0_write_susp_dtl();
            await td0_99_exit();

            //     perform xx2a-build-diskout-rec	 thru xx2a-99-exit.;
            await xx2a_build_diskout_rec();
            await xx2a_99_exit();

            //     perform te0-write-disk-out           thru te0-99-exit.;
            await te0_write_disk_out();
            await te0_99_exit();

            //     if hold-oma-rec-ind(ss-write-dtl,ss-phy-ind) = 'Y'  then;            
            if (hold_oma_rec_ind[ss_write_dtl, ss_phy_ind] == "Y")
            {
                flag_refer_doc = "Y";
            }
        }

        private async Task xx2_99_exit()
        {
            Util.Trakker(++ctr, "xx2_99_exit");

            //     exit.;
        }

        private async Task xx2a_build_diskout_rec()
        {
            Util.Trakker(++ctr, "xx2a_build_diskout_rec");

            objDiskout_output_rec.Diskout_clmhdr_claim = Util.Str(hold_accounting_nbr);

            objDiskout_output_rec.Diskout_clmhdr_clinic_nbr = Util.Str(bt_clinic_nbr_1_2);


            objDiskout_output_rec.Diskout_oma_svc_code = await hold_oma_cd_grp(ss_write_dtl);
            objDiskout_output_rec.Diskout_oma_svc_suff = Util.Str(hold_oma_suff[ss_write_dtl]);
            objDiskout_output_rec.Diskout_nbr_serv = Util.NumInt(hold_sv_nbr_serv[ss_write_dtl]);

            hold_sv_date_grp[ss_write_dtl] = Util.Str(hold_sv_date_yy[ss_write_dtl]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss_write_dtl]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss_write_dtl]).PadLeft(2, '0');
            objDiskout_output_rec.Diskout_svc_date = Util.Str(hold_sv_date_grp[ss_write_dtl]);
            objDiskout_output_rec.Diskout_oma_amt_billed = Util.NumDec(hold_fee_oma[ss_write_dtl]) * 100;
            objDiskout_output_rec.Diskout_ohip_amt_billed = Util.NumDec(hold_fee_ohip[ss_write_dtl]) * 100;
            objDiskout_output_rec.Diskout_priced_tech = Util.NumDec(hold_priced_tech[ss_write_dtl]) * 100;
            objDiskout_output_rec.Diskout_basic_tech = Util.NumDec(hold_basic_tech[ss_write_dtl]) * 100;
            objDiskout_output_rec.Diskout_basic_prof = Util.NumDec(hold_basic_prof[ss_write_dtl]) * 100;
            objDiskout_output_rec.Diskout_basic_fee = Util.NumDec(hold_basic_fee[ss_write_dtl]) * 100;
            objDiskout_output_rec.Diskout_cr = carriage_return;

            string tempValues = Util.Str(objDiskout_output_rec.Diskout_clmhdr_clinic_nbr).PadRight(2) +
                                Util.Str(objDiskout_output_rec.Diskout_clmhdr_claim).PadRight(8) +
                                Util.Str(objDiskout_output_rec.Diskout_oma_svc_cd).PadRight(5) +
                                Util.Str(objDiskout_output_rec.Diskout_ohip_amt_billed).PadLeft(6, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_svc_date).PadLeft(8, '0') +  // date
                                Util.Str(objDiskout_output_rec.Diskout_nbr_serv).PadLeft(2, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_oma_amt_billed).PadLeft(6, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_priced_tech).PadLeft(6, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_basic_tech).PadLeft(6, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_basic_prof).PadLeft(6, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_basic_fee).PadLeft(6, '0') +
                                Util.Str(objDiskout_output_rec.Diskout_cr).PadRight(1) +
                                Util.Str(objDiskout_output_rec.Diskout_lf).PadRight(1);

            objPriced_Claims_File.AppendOutputFile(tempValues, true);   //

        }

        private async Task xx2a_99_exit()
        {
            Util.Trakker(++ctr, "xx2a_99_exit");

            //     exit.;
        }

        private async Task xx3_write_susp_desc()
        {
            Util.Trakker(++ctr, "xx3_write_susp_desc");

            objSuspend_desc_rec.CLMDTL_LINE_NO = 0;

            // if adjudication-desc-entry then
            if (Util.Str(flag_desc_rec).Equals(adjudication_desc_entry))
            {
                objSuspend_hdr_rec.CLMHDR_RELATIONSHIP = "Y";
                //     move "G259 BILLED AT 85%"               to clmdtl-suspend-desc of suspen
                objSuspend_desc_rec.CLMDTL_SUSPEND_DESC = "G259 BILLED AT 85%";

                objSuspend_desc_rec.CLMDTL_LINE_NO = 1;
                objSuspend_desc_rec.CLMDTL_DOC_OHIP_NBR = Util.NumInt(objSuspend_hdr_rec.CLMHDR_DOC_OHIP_NBR); // clmhdr_doc_pract_nbr;
                objSuspend_desc_rec.CLMDTL_ACCOUNTING_NBR = Util.Str(objSuspend_hdr_rec.CLMHDR_ACCOUNTING_NBR);
                objSuspend_desc_rec.CLMDTL_STATUS = Util.Str(objSuspend_hdr_rec.CLMHDR_STATUS);
                //     if update-suspense then;            
                if (Util.Str(flag_update_suspense).Equals(update_suspense))
                {
                    // 	          add 1 	to ctr-suspend-desc-writes;
                    ctr_suspend_desc_writes++;

                    string tempValues = Util.Str(objSuspend_desc_rec.CLMDTL_SUSPEND_DESC).PadRight(70) +
                                       Util.Str(objSuspend_desc_rec.CLMDTL_STATUS).PadRight(1) +
                                       Util.Str(objSuspend_desc_rec.CLMDTL_DOC_OHIP_NBR).PadLeft(6, '0') +
                                       Util.Str(objSuspend_desc_rec.CLMDTL_ACCOUNTING_NBR).PadRight(8) +
                                       Util.Str(objSuspend_desc_rec.CLMDTL_LINE_NO).PadLeft(2, '0');

                    //           write suspend-desc-rec.;
                    objSuspend_Desc.AppendOutputFile(tempValues);                   
                }
            }
        }

        private async Task xx3_99_exit()
        {
            Util.Trakker(++ctr, "xx3_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task<string> ya0_price_claim()
        {
            Util.Trakker(++ctr, "ya0_price_claim");

            flag_zero_fee = "N";

            // if  def-agent-wcb then;            
            if (Util.Str(def_agent_code).Equals(def_agent_wcb))
            {
                ss_curr_prev = hold_ss_curr_prev[1];
                ws_hold_wcb_rate = base.CONST_WCB_GET(objConstants_mstr_rec_2, ss_curr_prev)/10000;
            }
            else
            {
                ws_hold_wcb_rate = 1;
            }

            // if ( diskette-claim  and override-with-rma-prices )  then 
            if (Util.Str(flag_claim_source).Equals(diskette_claim) && Util.Str(flag_retain_prices).Equals(override_with_rma_prices))
            {
                // 	     perform ya5-reset-nbr-services-value	thru ya5-99-exit;
                //             varying ss;
                //             from 1 by 1;
                //             until   ss > ss-clmdtl-oma.;

                ss = 1;
                do
                {
                    await ya5_reset_nbr_services_value();
                    await ya5_99_exit();
                    ss++;
                } while (ss <= ss_clmdtl_oma);
            }

            ws_reduc_rate = 1;

            //     perform ya2-find-add-on-reduc-rate          thru ya2-99-exit;
            //         varying subs;
            //         from 1 by 1;
            //         until   subs > const-max-nbr-rates.;

            subs = 1;
            do
            {
                await ya2_find_add_on_reduc_rate();
                await ya2_99_exit();
                subs++;
            } while (subs <= Util.NumInt(objConstants_mstr_rec_2.CONST_MAX_NBR_RATES));

            //     perform yb0-calc-basic-fee                  thru yb0-99-exit;
            //         varying ss;
            //         from 1 by 1;
            //         until   ss > ss-clmdtl-oma.;
            ss = 1;
            do
            {
                string retval =  await yb0_calc_basic_fee();
                if (retval.Equals("yb0_98_technical")) goto _yb0_98_technical;
                await yb0_50();
                _yb0_98_technical:
                await yb0_98_technical();
                await yb0_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);

            //  if ss-clmdtl-oma = 1  then            
            if (ss_clmdtl_oma == 1)
            {
                //         go to ya0-98-display-fees.;                
                return "ya0_98_display_fees";
            }

            //     perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            // if password-input = password-special-privledges then            
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 90;
                //   perform za0-common-error		thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            ss = 1;
            ss2 = 1;

            //     perform yc0-sort-by-icc-and-fee             thru yc0-99-exit;
            //                 until ss2 not < ss-clmdtl-oma.;

            do
            {
                await yc0_sort_by_icc_and_fee();
                await yc0_99_exit();
            } while (ss2 < ss_clmdtl_oma);

            flag_sec_reduction_needed = "N";

            ss_grp_tot = 0;
            hold_grp_totals_tbl_grp = "0";
            hold_grp_tot = new decimal[91];
            hold_grp_nbr = new decimal[91];
            hold_grp_nbr_sec = new int[91];
            hold_grp_nbr_grp = new int[91];

            ss_sec = 1;
            ss_grp = 1;
            hold_flag_sec[1] = 1;
            hold_flag_grp[1] = 1;
            hold_flag_sec_group[1] = Util.Str(hold_flag_sec[1]) + Util.Str(hold_flag_grp[1]);

            //     perform yd0-set-icc-sort-flags              thru yd0-99-exit;
            //         varying ss;
            //         from 2 by 1;
            //         until   ss > ss-clmdtl-oma.;

            ss = 2;
            do
            {
                await yd0_set_icc_sort_flags();
                await yd0_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);

            ss_hold_clmdtl_oma = ss_clmdtl_oma;

            //     perform xa0-display-details                 thru xa0-99-exit;
            //                  varying ss-clmdtl-oma;
            //                  from 1;
            //                  by 1;
            //                  until   ss-clmdtl-oma > ss-hold-clmdtl-oma;
            //                       or ss-clmdtl-oma > ss-max-nbr-oma-det-rec-allow.;

            ss_clmdtl_oma = 1;
            do
            {
                await xa0_display_details();
                await xa0_99_exit();
                ss_clmdtl_oma++;
            } while (ss_clmdtl_oma <= ss_hold_clmdtl_oma || ss_clmdtl_oma <= ss_max_nbr_oma_det_rec_allow);


            ss_clmdtl_oma = ss_hold_clmdtl_oma;

            //  if password-input = password-special-privledges  then        
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 91;
                //   perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            //     perform ye0-group-reductions                thru ye0-99-exit;
            //         varying ss;
            //        from 1 by 1;
            //         until   ss > ss-clmdtl-oma;
            //              or ss > (ss-max-nbr-oma-det-rec-allow - 1) .;

            ss = 1;
            do
            {
                await ye0_group_reductions();
                await ye0_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma && ss <= (ss_max_nbr_oma_det_rec_allow - 1));

            //     perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            //  if password-input = password-special-privledges  then            
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 92;
                //   perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            // if flag-sec-reduction-needed = "N" then            
            if (Util.Str(flag_sec_reduction_needed).ToUpper() == "N")
            {
                //         go to ya0-98-display-fees.;                
                return "ya0_98_display_fees";
            }

            ss_from = 1;
            ss_to = 0;

            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task<string> ya0_calc_sectional_reductions()
        {
            Util.Trakker(++ctr, "ya0_calc_sectional_reductions");

            // if hold-icc-sec (ss-from) not = "SP" then            
            if (hold_icc_sec[ss_from] != "SP")
            {
                ss_to = ss_from;
                //     go to ya0-increment-ss-from.;                
                return "ya0_increment_ss_from";
            }

            //     perform yh0-find-high-grp-within-sec        thru yh0-99-exit.;
            await yh0_find_high_grp_within_sec();   //
            await yh0_100_find_sp_suffix_a();
            await yh0_99_exit();

            // if online-claim then            
            if (Util.Str(flag_claim_source).Equals(online_claim))
            {
                //         display scr-acpt-det-desc.;
                Console.WriteLine(scr_acpt_det_desc);
            }

            // if password-input = password-special-privledges then          
            if (Util.Str(password_input) == Util.Str( password_special_privledges))
            {
                err_ind = 94;
                //     perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            //     perform yi0-sec-reduct-within-sec           thru yi0-99-exit;
            //                 varying ss;
            //                 from ss-from by 1;
            //                 until   ss > ss-to.;

            ss = ss_from;
            do
            {
                await yi0_sec_reduct_within_sec();
                await yi0_99_exit();
                ss++;
            } while (ss <= ss_to);

            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task<string> ya0_increment_ss_from()
        {
            Util.Trakker(++ctr, "ya0_increment_ss_from");

            // if ss-to < ss-clmdtl-oma then            
            if (ss_to < ss_clmdtl_oma)
            {
                //     add  1, ss-to                           giving  ss-from;
                ss_from = ss_to + 1;
                ss_to = 0;
                //     perform ya1-display-fees                thru    ya1-99-exit;
                await ya1_display_fees();
                await ya1_99_exit();

                //     if password-input = password-special-privledges  then            
                if (Util.Str(password_input) == Util.Str(password_special_privledges))
                {
                    err_ind = 95;
                    //         perform za0-common-error                thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    //         go to ya0-calc-sectional-reductions;                    
                    return "ya0_calc_sectional_reductions";
                }
                else
                {
                    //         go to ya0-calc-sectional-reductions.;                    
                    return "ya0_calc_sectional_reductions";
                }
            }
            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task ya0_98_display_fees()
        {
            Util.Trakker(++ctr, "ya0_98_display_fees");

            //     perform yf0-add-on-increases                thru yf0-99-exit;
            //        varying ss;
            //         from 1 by 1;
            //         until   ss > ss-clmdtl-oma.;

            ss = 1;
            do
            {
                await yf0_add_on_increases();
                await yf0_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);


            //     perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            //  if password-input = password-special-privledges then 
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 93;
                //    perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            //  perform yf1-special-add-on-incr             thru yf1-99-exit;
            //         varying ss;
            //         from 1 by 1;
            //         until   ss > ss-clmdtl-oma.;
            ss = 1;
            do
            {
                await yf1_special_add_on_incr();
                await yf1_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);

            //   perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            // if password-input = password-special-privledges  then 
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 96;
                //   perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            //     perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            //  if password-input = password-special-privledges  then            
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 97;
                //    perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            //  perform test-min-max-limits                 thru test-min-max-limits-99-exit;
            //         varying ss;
            //         from 1 by 1;
            //         until   ss > ss-clmdtl-oma.;

            ss = 1;
            do
            {
                await test_min_max_limits();
                await test_min_max_limits_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);


            flag_zero_fee = "Y";

            //     perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            //  if password-input = password-special-privledges then            
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 98;
                //   perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            // if not online-claim then            
            if (!Util.Str(flag_claim_source).Equals(online_claim))
            {
                // 	   perform yz0-reset-verify-prices      thru yz0-99-exit.;
                await yz0_reset_verify_prices();
                await yz0_99_exit();
            }

            //  perform ya3-calc-priced-tech                thru ya3-99-exit;
            //         varying ss;
            //         from 1;
            //         by   1;
            //         until   ss > ss-clmdtl-oma.;
            ss = 1;
            do
            {
                await ya3_calc_priced_tech();
                await ya3_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);

            //     perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            // if password-input = password-special-privledges then      
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 99;
                //    perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }

            ss = 1;
            ss2 = 1;

            //     perform yj0-sort-by-orig-line-no            thru yj0-99-exit;
            //                 until ss2 not < ss-clmdtl-oma.;
            if (ss_clmdtl_oma > 1)
            {
                do
                {
                    await yj0_sort_by_orig_line_no();
                    await yj0_99_exit();
                } while (ss2 < ss_clmdtl_oma);
            }

            //  perform ya1-display-fees                    thru ya1-99-exit.;
            await ya1_display_fees();
            await ya1_99_exit();

            // if password-input = password-special-privledges then
            if (Util.Str(password_input) == Util.Str(password_special_privledges))
            {
                err_ind = 100;
                //    perform za0-common-error                thru za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }
        }

        // pricing_logic.rtn
        private async Task ya0_99_exit()
        {
            Util.Trakker(++ctr, "ya0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ya1_display_fees()
        {
            Util.Trakker(++ctr, "ya1_display_fees");

            ss_hold_clmdtl_oma = ss_clmdtl_oma;

            //     perform ya11-disp-oma-fees                  thru ya11-99-exit;
            //                 varying ss-clmdtl-oma;
            //                 from 1;
            //                 by   1;
            //                 until   ss-clmdtl-oma > ss-hold-clmdtl-oma;
            //                      or ss-clmdtl-oma > ss-max-nbr-oma-det-rec-allow.;

            ss_clmdtl_oma = 1;
            do
            {
                await ya11_disp_oma_fees();
                await ya11_99_exit();
                ss_clmdtl_oma++;
            } while (ss_clmdtl_oma <= ss_hold_clmdtl_oma && ss_clmdtl_oma <= ss_max_nbr_oma_det_rec_allow);

            ss_clmdtl_oma = ss_hold_clmdtl_oma;
        }

        // pricing_logic.rtn
        private async Task ya1_99_exit()
        {
            Util.Trakker(++ctr, "ya1_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ya11_disp_oma_fees()
        {
            Util.Trakker(++ctr, "ya11_disp_oma_fees");

            // if online-claim  then 
            if (Util.Str(flag_claim_source).Equals(online_claim))
            {
                //         next sentence;
            }
            else
            {
                //         go to ya11-99-exit.;
                await ya11_99_exit();
                return;
            }

            //     add ss-clmdtl-oma;
            //         10                              giving pline.;
            pline = ss_clmdtl_oma + 10;

            //     display scr-hold-oma-cd.;
            //     display scr-hold-oma-suff.;
            //     display scr-hold-sv-date-yy-12.;
            //     display scr-hold-sv-date-yy-34.;
            //     display scr-hold-sv-date-mm.;
            //     display scr-hold-sv-date-dd.;
            //     display scr-hold-sv-nbr-0;
            //     display scr-hold-fee-oma.;
            //     display scr-hold-fee-ohip.;

            //  if  hold-fee-ohip(ss-clmdtl-oma) = 0  and flag-zero-fee = 'Y' then    
            if (hold_fee_ohip[ss_clmdtl_oma] == 0 && Util.Str(flag_zero_fee).ToUpper() == "Y")
            {
                e1_error_word = "*Warning_";
                err_ind = 59;
                //     perform za0-common-error        thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                e1_error_word = "*Error_";
            }
        }

        // pricing_logic.rtn
        private async Task ya11_99_exit()
        {
            Util.Trakker(++ctr, "ya11_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ya2_find_add_on_reduc_rate()
        {
            Util.Trakker(++ctr, "ya2_find_add_on_reduc_rate");

            ss_curr_prev = hold_ss_curr_prev[1];

            //  if const-section-group (subs) = 'SP98'  then            
            if (base.CONST_SECTION(objConstants_mstr_rec_2, subs) + Util.Str(CONST_GROUP(objConstants_mstr_rec_2, subs)) == "SP98")
            {
                ws_reduc_rate98 = ss_curr_prev == 1 ?  Util.NumDec(CONST_RATE_CURR(objConstants_mstr_rec_2, subs))/100 : Util.NumDec(CONST_RATE_PREV(objConstants_mstr_rec_2, subs))/100;  // const_rates_curr_prev[subs,ss_curr_prev];
            }
            //  else if const-section-group (subs) = 'SP99' then            
            else if (base.CONST_SECTION(objConstants_mstr_rec_2, subs) + Util.Str(base.CONST_GROUP(objConstants_mstr_rec_2, subs)) == "SP99")
            {
                ws_reduc_rate99 = ss_curr_prev == 1 ? Util.NumDec(CONST_RATE_CURR(objConstants_mstr_rec_2, subs))/100 : Util.NumDec(CONST_RATE_PREV(objConstants_mstr_rec_2, subs))/100;   //const_rates_curr_prev[subs,ss_curr_prev];
            }
            else
            {
                ws_reduc_rate98 = 1;
                ws_reduc_rate99 = 1;
            }

        }

        // pricing_logic.rtn
        private async Task ya2_99_exit()
        {
            Util.Trakker(++ctr, "ya2_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ya3_calc_priced_tech()
        {
            Util.Trakker(++ctr, "ya3_calc_priced_tech");

            //  if  def-agent-wcb  and not hold-fee-ohip-r(ss) = 0 and not hold-fee-oma-r (ss) = 0  then
            if (Util.Str(def_agent_code).Equals(def_agent_wcb) && hold_fee_ohip_r[ss] != 0 && hold_fee_oma_r[ss] != 0)
            {
                //         perform ya4-round-wcb                   thru ya4-99-exit.;
                await ya4_round_wcb();
                await ya4_99_exit();
            }

            //  if  hold-basic-tech(ss) = 0 or hold-basic-fee (ss) = 0 or hold-fee-ohip  (ss) = 0 then     
            if (hold_basic_tech[ss] == 0 || hold_basic_fee[ss] == 0 || hold_fee_ohip[ss] == 0)
            {
                hold_priced_tech[ss] = 0;
            }
            else
            {
                //   compute hold-priced-tech(ss) rounded = (hold-basic-tech(ss) * hold-fee-ohip(ss)) / hold-basic-fee(ss).;
                hold_priced_tech[ss] = Util.Round((hold_basic_tech[ss] * hold_fee_ohip[ss]) / hold_basic_fee[ss], 2);
            }

        }

        // pricing_logic.rtn
        private async Task ya3_99_exit()
        {
            Util.Trakker(++ctr, "ya3_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ya4_round_wcb()
        {
            Util.Trakker(++ctr, "ya4_round_wcb");

            //     divide hold-fee-ohip-r(ss)  by 5;
            //         giving ws-hold-temp-3 remainder ws-hold-temp-2.;

            ws_hold_temp_3 = hold_fee_ohip_r[ss] / 5;
            ws_hold_temp_2 = hold_fee_ohip_r[ss] % 5;

            //  if ws-hold-temp-2 < 3  then            
            if (ws_hold_temp_2 < 3)
            {
                //         subtract ws-hold-temp-2 from hold-fee-ohip-r(ss);
                hold_fee_ohip_r[ss] = hold_fee_ohip_r[ss] - ws_hold_temp_2;
            }
            else
            {
                //         subtract ws-hold-temp-2 from 5 giving ws-hold-temp-2;
                ws_hold_temp_2 = 5 - ws_hold_temp_2;
                //         add      ws-hold-temp-2 to   hold-fee-ohip-r(ss).;
                hold_fee_ohip_r[ss] += ws_hold_temp_2;
            }

            //  divide hold-fee-oma-r(ss)   by 5 giving ws-hold-temp-3 remainder ws-hold-temp-2.;
            ws_hold_temp_3 = hold_fee_oma_r[ss] / 5;
            ws_hold_temp_2 = hold_fee_oma_r[ss] % 5;

            //  if ws-hold-temp-2 < 3 then            
            if (ws_hold_temp_2 < 3)
            {
                //         subtract ws-hold-temp-2 from hold-fee-oma-r(ss);
                hold_fee_oma_r[ss] = hold_fee_oma_r[ss] - ws_hold_temp_2;
            }
            else
            {
                //         subtract ws-hold-temp-2 from 5 giving ws-hold-temp-2;
                ws_hold_temp_2 = 5 - ws_hold_temp_2;
                //         add      ws-hold-temp-2 to   hold-fee-oma-r(ss).;
                hold_fee_oma_r[ss] += ws_hold_temp_2;
            }
        }

        // pricing_logic.rtn
        private async Task ya4_99_exit()
        {
            Util.Trakker(++ctr, "ya4_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ya5_reset_nbr_services_value()
        {
            Util.Trakker(++ctr, "ya5_reset_nbr_services_value");

            // if hold-sv-nbr-serv(ss) not = 0 then            
            if (hold_sv_nbr_serv[ss] != 0)
            {
                //   if hold-oma-suff(ss) = "B" then            
                if (Util.Str(hold_oma_suff[ss]).ToUpper() == "B")
                {
                    // 	    if hold-oma-cd(ss) = "E400" or "E401" then            
                    if (await hold_oma_cd_grp(ss) == "E400" || await hold_oma_cd_grp(ss) == "E401")
                    {
                        hold_sv_nbr_serv[ss] = 0;
                    }
                    else
                    {
                        //              subtract hold-oma-fee-asst (ss,ohip);
                        // 					from   hold-sv-nbr-serv(ss);
                        // 				 	giving hold-sv-nbr-serv(ss);
                        hold_sv_nbr_serv[ss] = hold_sv_nbr_serv[ss] - hold_oma_fee_asst[ss, ohip];
                    }
                }
                // 	 else if hold-oma-suff(ss) = "C" then            
                else if (Util.Str(hold_oma_suff[ss]).ToUpper() == "C")
                {
                    // 	    if hold-oma-cd(ss) = "E400" or "E401" then       
                    if (await hold_oma_cd_grp(ss) == "E400" || await hold_oma_cd_grp(ss) == "E401")
                    {
                        hold_sv_nbr_serv[ss] = 0;
                    }
                    else
                    {
                        //           subtract hold-oma-fee-anae (ss,ohip);
                        // 			    from   hold-sv-nbr-serv(ss);
                        // 					giving hold-sv-nbr-serv(ss).;
                        hold_sv_nbr_serv[ss] = hold_sv_nbr_serv[ss] - hold_oma_fee_anae[ss, ohip];
                    }
                }
            }
        }

        // pricing_logic.rtn
        private async Task ya5_99_exit()
        {
            Util.Trakker(++ctr, "ya5_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task<string> yb0_calc_basic_fee()
        {
            Util.Trakker(++ctr, "yb0_calc_basic_fee");

            //  if hold-oma-cd(ss) = "E409" or "E412"  then         
            if (await hold_oma_cd_grp(ss) == "E409" || await hold_oma_cd_grp(ss) == "E412")
            {
                // 	next sentence.;
            }

            hold_flag_fee_used[ss] = "0";

            // if hold-sv-day ( ss ,1) = "MR" or "OP"  then       
            if (hold_sv_day[ss, 1] == "MR" || hold_sv_day[ss, 1] == "OP")
            {
                //   if  def-agent-ohip  or def-agent-ohip-wcb  or def-agent-alternate-funding  then            
                if (Util.Str(def_agent_code).Equals(def_agent_ohip) || Util.Str(def_agent_code).Equals(def_agent_ohip_wcb) || Util.Str(def_agent_code).Equals(def_agent_alternate_funding))
                {
                    ss_curr_prev = hold_ss_curr_prev[ss];
                    // 	      if online-claim then            
                    if (Util.Str(flag_claim_source).Equals(online_claim))
                    {
                        //       compute hold-fee-ohip (ss) rounded  = hold-fee-oma  (ss) * const-ic (ss-curr-prev);                        
                        if (ss_curr_prev == 1)
                            hold_fee_ohip[ss] = Util.Round(hold_fee_oma[ss] * (Util.NumDec(objConstants_mstr_rec_2.CONST_IC_CURR) / 100),2);
                        else
                            hold_fee_ohip[ss] = Util.Round(hold_fee_oma[ss] * (Util.NumDec(objConstants_mstr_rec_2.CONST_IC_PREV) / 100), 2);
                        //                 go to yb0-98-technical;                        
                        return "yb0_98_technical";
                    }
                    else
                    {
                        //      compute hold-fee-ohip(ss) rounded = hold-fee-incoming  (ss) * const-ic (ss-curr-prev)                        
                        if (ss_curr_prev == 1)
                            hold_fee_ohip[ss] = Util.Round(hold_fee_incoming[ss] * (Util.NumDec(objConstants_mstr_rec_2.CONST_IC_CURR) / 100),2);
                        else
                            hold_fee_ohip[ss] = Util.Round(hold_fee_incoming[ss] * (Util.NumDec(objConstants_mstr_rec_2.CONST_IC_PREV) / 100),2);

                        //                 go to yb0-98-technical;                        
                        return "yb0_98_technical";
                    }
                }
                else
                {
                    //             move  hold-fee-oma  (ss) to hold-fee-ohip (ss)
                    hold_fee_ohip[ss] = hold_fee_oma[ss];
                    //             go to yb0-98-technical.;                    
                    return "yb0_98_technical";
                }
            }

            // if (hold-oma-rec-ind(ss, ss-add-on-perc-or-flat-ind) = "P" or "F" )  and (    hold-oma-suff (ss) <> "B" or hold-oma-cd   (ss) <> "E676"  )  then            
            if (
                (hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind] == "P" || hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind] == "F") && (hold_oma_suff[ss] != "B" || await hold_oma_cd_grp(ss) != "E676")
                )
            {
                hold_fee_oma[ss] = 0;
                hold_fee_ohip[ss] = 0;
                //     go to yb0-98-technical.;
                return "yb0_98_technical";
            }

            ss_curr_prev = hold_ss_curr_prev[ss];

            hold_sv_date_grp[ss] = Util.Str(hold_sv_date_yy[ss]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss]).PadLeft(2,'0');

            //     if   (hold-icc-sec (ss) = "CV");
            if ((hold_icc_sec[ss] == "CV")
            //       or (     (   hold-icc-sec (ss) =   "NM";
                 || ((hold_icc_sec[ss] == "NM"
            //            or      hold-icc-sec (ss) =   "DR";
                  || hold_icc_sec[ss] == "DR"
            //            or      hold-icc-sec (ss) =   "PF";
                  || hold_icc_sec[ss] == "PF"
            //            or      hold-icc-sec (ss) =   "DU");
                  || hold_icc_sec[ss] == "DU")
            //            and hold-oma-suff (ss) = "B"        );
                  && hold_oma_suff[ss] == "B")
            //       or (      hold-icc-sec (ss) = "SP";
                  || (hold_icc_sec[ss] == "SP"
            //            and (hold-oma-suff (ss) = "A" or "M")   );
                  && (hold_oma_suff[ss] == "A" || hold_oma_suff[ss] == "M"))
            //       or (      hold-oma-cd   (ss) = "E676";
                   || (await hold_oma_cd_grp(ss) == "E676"
            //            and  hold-oma-suff (ss) = "B";
                   && hold_oma_suff[ss] == "B"
            //            and  hold-sv-date  (ss) < '20110901'   );
                   && Util.Str(hold_sv_date_grp[ss]).CompareTo("20110901") < 0)
            //       or (      hold-icc-sec (ss) = "CP";
                   || (hold_icc_sec[ss] == "CP"
            //            and (hold-oma-suff (ss) = "A" or "M") );
                   && (hold_oma_suff[ss] == "A" || hold_oma_suff[ss] == "M"))
            //       or (      hold-icc-sec (ss) = "DT";
                   || (hold_icc_sec[ss] == "DT"
            //            and (hold-oma-suff (ss) = "A" or "M")   );
                   && (hold_oma_suff[ss] == "A" || hold_oma_suff[ss] == "M"))
            //     then;
            )
            {
                //          move hold-oma - fee - 1(ss, oma)    to hold-fee - oma(ss)
                hold_fee_oma[ss] = hold_oma_fee_1[ss, oma];
                //          move hold-oma - fee - 1(ss, ohip)   to hold-fee - ohip(ss)
                hold_fee_ohip[ss] = hold_oma_fee_1[ss, ohip];
                hold_flag_fee_used[ss] = "1";
            }
            //     else if   (    (   hold-icc-sec (ss) =   "NM";
            else if (((hold_icc_sec[ss] == "NM"
            //                or     hold-icc-sec (ss) =   "DR";
                   || hold_icc_sec[ss] == "DR"
            //                or     hold-icc-sec (ss) =   "DU";
                   || hold_icc_sec[ss] == "DU"
            //                or     hold-icc-sec (ss) =   "PF");
                   || hold_icc_sec[ss] == "PF")
            //               and hold-oma-suff (ss) = "C"          );
                   && hold_oma_suff[ss] == "C")
            //         then;
            )
            {
                hold_fee_oma[ss] = hold_oma_fee_2[ss, oma];
                //            move hold-oma-fee-2 (ss,ohip) to hold-fee-ohip      (ss)
                hold_fee_ohip[ss] = hold_oma_fee_2[ss, ohip];
                hold_flag_fee_used[ss] = "2";
            }
            //         else if   (    (   hold-icc-sec (ss) =   "NM";
            else if (((hold_icc_sec[ss] == "NM"
            //                    or     hold-icc-sec (ss) =   "DU";
                    || hold_icc_sec[ss] == "DU"
            //                    or     hold-icc-sec (ss) =   "PF";
                    || hold_icc_sec[ss] == "PF"
            //                    or     hold-icc-sec (ss) =   "DR");
                    || hold_icc_sec[ss] == "DR")
            //                   and (hold-oma-suff (ss) = "A" or "M") );
                    && (hold_oma_suff[ss] == "A" || hold_oma_suff[ss] == "M"))
            //             then;
            )
            {
                //                 add hold-oma-fee-1 (ss,oma);
                //                     hold-oma-fee-2 (ss, oma);
                //                                         giving hold-fee-oma   (ss);
                hold_fee_oma[ss] = hold_oma_fee_1[ss, oma] + hold_oma_fee_2[ss, oma];
                //                 add hold-oma-fee-1 (ss,ohip);
                //                     hold-oma-fee-2 (ss,ohip);
                //                                         giving hold-fee-ohip  (ss);
                hold_fee_ohip[ss] = hold_oma_fee_1[ss, ohip] + hold_oma_fee_2[ss, ohip];
                hold_flag_fee_used[ss] = "3";
            }
            //            else if   (     (   hold-icc-sec (ss) = "CP";      
            else if (((hold_icc_sec[ss] == "CP"
            //                             or hold-icc-sec (ss) = "DT";
                    || hold_icc_sec[ss] == "DT"
            //                             or hold-icc-sec (ss) = "SP");
                    || hold_icc_sec[ss] == "SP")
            //                       and  hold-oma-suff (ss) = "C"        );
                    && hold_oma_suff[ss] == "C")
            //                  then;
            )
            {
                //                         if ws-doc-spec-cd = 0 then           
                if (ws_doc_spec_cd == 0)
                {
                    hold_fee_oma[ss] = CONST_REG_GET(objConstants_mstr_rec_2, ss_curr_prev, 2)/100;
                    hold_fee_ohip[ss] = CONST_REG_GET(objConstants_mstr_rec_2, ss_curr_prev, 1)/100;
                }
                else
                {
                    hold_fee_oma[ss] = base.CONST_CERT_GET(objConstants_mstr_rec_2, ss_curr_prev, 2)/100;
                    hold_fee_ohip[ss] = base.CONST_CERT_GET(objConstants_mstr_rec_2, ss_curr_prev, 1)/100;
                }
            }
            //             else if  hold-icc-sec  (ss) = "SP" and hold-oma-suff (ss) = "B"  then      
            else if (hold_icc_sec[ss] == "SP" && hold_oma_suff[ss] == "B")
            {
                hold_fee_oma[ss] = CONST_ASST_GET(objConstants_mstr_rec_2, ss_curr_prev, 2) / 100;
                hold_fee_ohip[ss] = base.CONST_ASST_GET(objConstants_mstr_rec_2, ss_curr_prev, 1)/100;
            }
            else
            {
                //                         next sentence.;
            }


            //  if  hold-sv-day ( ss, 1)  = "BI" and hold-oma-cd-alpha ( ss ) not = "Z"  then      
            if (hold_sv_day[ss, 1] == "BI" && hold_oma_cd_alpha[ss] != "Z")
            {
                //   compute hold-fee-oma  (ss) rounded = hold-fee-oma  (ss) * const-bilateral( ss-curr-prev);
                hold_fee_oma[ss] = Util.Round(hold_fee_oma[ss] * (base.CONST_BILATERAL_GET(objConstants_mstr_rec_2, ss_curr_prev)/100), 2);
                //  compute hold-fee-ohip (ss) rounded = hold-fee-ohip (ss) * const-bilateral( ss-curr-prev);
                hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * (base.CONST_BILATERAL_GET(objConstants_mstr_rec_2, ss_curr_prev)/100), 2);
                //         go to yb0-50;                
                return "yb0_50";
            }
            else
            {
                //         next sentence.;
            }


            //  compute ws-tot-serv = hold-sv-nbr-serv (ss) + hold-sv-nbr      (ss, 1)  + hold-sv-nbr      (ss, 2) + hold-sv-nbr      (ss, 3).;            
            ws_tot_serv = hold_sv_nbr_serv[ss] + hold_sv_nbr[ss, 1] + hold_sv_nbr[ss, 2] + hold_sv_nbr[ss, 3];

            //  if  (hold-oma-suff (ss) =  "B" or "C");            
            if ((hold_oma_suff[ss] == "B" || hold_oma_suff[ss] == "C")
            //        and not (hold-icc-sec(ss)   = "NM" or "PF" or "DU");
                     && !(hold_icc_sec[ss] == "NM" || hold_icc_sec[ss] == "PF" || hold_icc_sec[ss] == "DU")
            //     then;
            )
            {
                flag_desc_rec = "BT";
                //     perform ym0-create-desc-record          thru ym0-99-exit;
                string retval =  await ym0_create_desc_record();
                if (retval.Equals("ym0_99_exit")) goto _ym0_99_exit;
                await ym0_90_display();
                _ym0_99_exit:
                await ym0_99_exit();
            }
            else
            {
                //         next sentence.;
            }


            //  if  hold-oma-suff (ss) = "C"  and (hold-icc-sec (ss)  = "CP" or "DT" or "SP")  then            
            if (Util.Str(hold_oma_suff[ss]).ToUpper() == "C" && (Util.Str(hold_icc_sec[ss]).ToUpper() == "CP" || Util.Str(hold_icc_sec[ss]).ToUpper() == "DT" || Util.Str(hold_icc_sec[ss]).ToUpper() == "SP"))
            {
                //   compute hold-fee-oma  (ss) rounded = hold-fee-oma  (ss) * ( ws-tot-serv + hold-oma-fee-anae (ss,  oma) );
                hold_fee_oma[ss] = Util.Round( hold_fee_oma[ss] * (ws_tot_serv + hold_oma_fee_anae[ss, oma]), 2);
                //   compute hold-fee-ohip (ss) rounded  = hold-fee-ohip (ss) * ( ws-tot-serv + hold-oma-fee-anae (ss, ohip) );
                hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * (ws_tot_serv + hold_oma_fee_anae[ss, ohip]), 2);
                //         add hold-oma-fee-anae ( ss, ohip)               to hold-sv-nbr-serv (ss);

                //Core Added - Picture clause of hold_sv_nbr_serv is "99", so if the sum is greater than 99 only the last 2 digits are used.
                if ((hold_sv_nbr_serv[ss] + hold_oma_fee_anae[ss, ohip]).ToString().Length > 2)
                {
                    hold_sv_nbr_serv[ss] = Util.NumInt((hold_sv_nbr_serv[ss] + hold_oma_fee_anae[ss, ohip]).ToString().Substring((hold_sv_nbr_serv[ss] + hold_oma_fee_anae[ss, ohip]).ToString().Length - 2));
                }
                else
                {
                    hold_sv_nbr_serv[ss] += hold_oma_fee_anae[ss, ohip];
                }
                // 	       add hold-oma-fee-anae ( ss, ohip)		to nbr-of-services;
                nbr_of_services += hold_oma_fee_anae[ss, ohip];

                //         if online-claim then            
                if (Util.Str(flag_claim_source).Equals(online_claim))
                {
                    //  	       display scr-last-claim;                   
                    //             go to yb0-50;                    
                    return "yb0_50";
                }
                else
                {
                    //             go to yb0-50;
                    return "yb0_50";                     
                }
            }
            else
            {
                //         next sentence.;
            }


            //  if  hold-oma-suff (ss) = "B"   and hold-icc-sec (ss) = "SP"  then         
            if (Util.Str(hold_oma_suff[ss]).ToUpper() == "B" && Util.Str(hold_icc_sec[ss]).ToUpper() == "SP")
            {
                //  compute hold-fee-oma  (ss) rounded = hold-fee-oma  (ss) * ( ws-tot-serv + hold-oma-fee-asst (ss,  oma) );
                hold_fee_oma[ss] = Util.Round(hold_fee_oma[ss] * (ws_tot_serv + hold_oma_fee_asst[ss, oma]), 2);
                //  compute hold-fee-ohip (ss) rounded = hold-fee-ohip (ss) * ( ws-tot-serv + hold-oma-fee-asst (ss, ohip) );
                hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * (ws_tot_serv + hold_oma_fee_asst[ss, ohip]), 2);

                //         add hold-oma-fee-asst ( ss, ohip)               to hold-sv-nbr-serv (ss);
                //Core Added - Picture clause of hold_sv_nbr_serv is "99", so if the sum is greater than 99 only the last 2 digits are used.
                if ((hold_sv_nbr_serv[ss] + hold_oma_fee_asst[ss, ohip]).ToString().Length > 2)
                {
                    hold_sv_nbr_serv[ss] = Util.NumInt((hold_sv_nbr_serv[ss] + hold_oma_fee_asst[ss, ohip]).ToString().Substring((hold_sv_nbr_serv[ss] + hold_oma_fee_asst[ss, ohip]).ToString().Length - 2));
                }
                else
                {
                    hold_sv_nbr_serv[ss] += hold_oma_fee_asst[ss, ohip];
                }

                // 	       add hold-oma-fee-asst ( ss, ohip)		to nbr-of-services;
                nbr_of_services += hold_oma_fee_asst[ss, ohip];
                //  	    display scr-last-claim;
                //          go to yb0-50;                
                return "yb0_50";
            }
            else
            {
                //         next sentence.;
            }

            //     compute hold-fee-oma  (ss) rounded = hold-fee-oma  (ss) * ws-tot-serv.;
            hold_fee_oma[ss] = Util.Round(hold_fee_oma[ss] * ws_tot_serv, 2);
            //     compute hold-fee-ohip (ss) rounded = hold-fee-ohip (ss) * ws-tot-serv.;
            hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * ws_tot_serv, 2);

            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task yb0_50()
        {
            Util.Trakker(++ctr, "yb0_50");

            //  if def-agent-wcb  then            
            if (Util.Str(def_agent_code).Equals(def_agent_wcb))
            {
                //    compute hold-fee-ohip (ss) rounded = hold-fee-ohip (ss) * const-wcb( ss-curr-prev);
                hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * (base.CONST_WCB_GET(objConstants_mstr_rec_2, ss_curr_prev)/100), 2);
            }
            // else if def-agent-bill-direct or def-agent-foreign-direct  or def-agent-ifhp-direct  or def-agent-ontario-direct  or def-agent-quebec-direct  then
            if (Util.Str(def_agent_code).Equals(def_agent_bill_direct) || Util.Str(def_agent_code).Equals(def_agent_foreign_direct) || Util.Str(def_agent_code).Equals(def_agent_ifhp_direct) || Util.Str(def_agent_code).Equals(def_agent_ontario_direct) || Util.Str(def_agent_code).Equals(def_agent_quebec_direct))
            {
                //         move hold-fee-oma (ss)      to hold-fee-ohip (ss)
                hold_fee_ohip[ss] = hold_fee_oma[ss];
            }
            else
            {
                //            next sentence.;
            }
        }

        // pricing_logic.rtn
        private async Task yb0_98_technical()
        {
            Util.Trakker(++ctr, "yb0_98_technical");

            // if  hold-sv-day ( ss, 1) = "ER"  and clmhdr-clinic-nbr-1-2 = "88"  and site-id = "RMA"  and (hold-oma-cd-alpha ( ss ) = "D" or "F") then            
            if (hold_sv_day[ss, 1] == "ER" && Util.Str(objSuspend_hdr_rec.CLMHDR_CLINIC_NBR_1_2) == "88" && site_id == "RMA" && (hold_oma_cd_alpha[ss] == "D" || hold_oma_cd_alpha[ss] == "F"))
            {
                //         compute hold-fee-oma  (ss) rounded = hold-fee-oma  (ss) * .75;
                hold_fee_oma[ss] = Util.Round(hold_fee_oma[ss] * .75M, 2);
                //         compute hold-fee-ohip (ss) rounded  = hold-fee-ohip (ss) * .75 
                hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * .75M, 2);
            }
            else
            {
                //          next sentence.;
            }

            // if  hold-oma-cd(ss)    = "G259" and hold-oma-suff(ss)  = "A"  and clmhdr-loc  = "G420"  and clmhdr-i-o-pat-ind = "I" then                        
            if (await hold_oma_cd_grp(ss) == "G259" && hold_oma_suff[ss] == "A" && Util.Str(objSuspend_hdr_rec.CLMHDR_LOC) == "G420" && Util.Str(objSuspend_hdr_rec.CLMHDR_I_O_PAT_IND) == "I")
            {
                //  	compute hold-fee-ohip(ss) = hold-fee-ohip(ss) * .85;
                hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * .85M, 2);
                flag_desc_rec = "A";
                //      perform ym0-create-desc-record	       thru ym0-99-exit;
                string retval =  await ym0_create_desc_record();
                if (retval.ToLower().Equals("ym0_99_exit"))
                {
                    goto _ym0_99_exit;
                }
                await ym0_90_display();
                _ym0_99_exit:
                await ym0_99_exit();
            }
            else
            {
                //      next sentence.;
            }

            hold_basic_fee[ss] = hold_fee_ohip[ss];

            // if  hold-oma-rec-ind (ss,ss-tech-ind) = "Y" or hold-oma-suff    (ss) = 'B'   then            
            if (hold_oma_rec_ind[ss, ss_tech_ind] == "Y" || hold_oma_suff[ss] == "B")
            {
                hold_basic_tech[ss] = hold_basic_fee[ss];
            }
            // else  if hold-oma-suff(ss) = 'C' then            
            else if (hold_oma_suff[ss] == "C")
            {
                hold_basic_tech[ss] = 0;
            }
            // else if hold-icc-sec(ss) = 'NM' or 'DR' or 'DU' or 'PF' then            
            else if (hold_icc_sec[ss] == "NM" || hold_icc_sec[ss] == "DR" || hold_icc_sec[ss] == "DU" || hold_icc_sec[ss] == "PF")
            {
                hold_basic_tech[ss] = hold_oma_fee_1[ss, ohip];
                hold_basic_prof[ss] = hold_oma_fee_2[ss, ohip];
                //   perform yb1-compute-basic-tech  thru yb1-99-exit;
                await yb1_compute_basic_tech();
                await yb1_99_exit();
            }
            else
            {
                hold_basic_tech[ss] = 0;
            }
        }

        // pricing_logic.rtn
        private async Task yb0_99_exit()
        {
            Util.Trakker(++ctr, "yb0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yb1_compute_basic_tech()
        {
            Util.Trakker(++ctr, "yb1_compute_basic_tech");

            //     add hold-basic-tech(ss), hold-basic-prof(ss) giving ws-hold-temp-1.;
            ws_hold_temp_1 = hold_basic_tech[ss] + hold_basic_prof[ss];

            // if ws-hold-temp-1 = zero then            
            if (ws_hold_temp_1 == 0)
            {
                hold_basic_tech[ss] = 0;
            }
            else
            {
                //      compute hold-basic-tech(ss) rounded =  hold-basic-tech(ss) *  (hold-basic-fee(ss) / ws-hold-temp-1).
                hold_basic_tech[ss] = hold_basic_tech[ss] * (hold_basic_fee[ss] / ws_hold_temp_1);
            }

        }

        // pricing_logic.rtn
        private async Task yb1_99_exit()
        {
            Util.Trakker(++ctr, "yb1_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yc0_sort_by_icc_and_fee()
        {
            Util.Trakker(++ctr, "yc0_sort_by_icc_and_fee");

            // if hold-sort-key-1 (ss) > hold-sort-key-1 (ss + 1) then            
            if (Util.Str(hold_sort_key_1[ss]).CompareTo(Util.Str(hold_sort_key_1[ss + 1])) > 0)
            {
                hold_sort_oma_rec = await hold_oma_rec_grp(ss);
                //    move hold-oma-rec (ss + 1)      to hold-oma-rec (ss)                
                await hold_oma_rec_grp_set(ss, await hold_oma_rec_grp(ss + 1));

                //hold_oma_rec[ss+1] = hold_sort_oma_rec;
                await hold_oma_rec_grp_set(ss + 1, hold_sort_oma_rec);

                //    if ss > 1  then;            
                if (ss > 1)
                {
                    //        subtract 1 from ss;
                    ss--;
                    //        go to yc0-sort-by-icc-and-fee;
                    await yc0_sort_by_icc_and_fee();
                    return;
                }
                else
                {
                    //        next sentence;
                }
            }
            // else if hold-sort-key-1 (ss) = hold-sort-key-1 (ss + 1) then            
            else if (hold_sort_key_1[ss] == hold_sort_key_1[ss + 1])
            {
                //     if hold-fee-ohip (ss) < hold-fee-ohip (ss + 1) then;            
                if (hold_fee_ohip[ss] < hold_fee_ohip[ss + 1])
                {
                    hold_sort_oma_rec = await hold_oma_rec_grp(ss);
                    //        move hold-oma-rec (ss + 1)      to hold-oma-rec (ss)
                    await hold_oma_rec_grp_set(ss, await hold_oma_rec_grp(ss + 1));
                    //        hold_oma_rec[ss+1] = hold_sort_oma_rec;
                    await hold_oma_rec_grp_set(ss + 1, hold_sort_oma_rec);
                    //        if ss > 1  then;            
                    if (ss > 1)
                    {
                        //             subtract 1 from ss;
                        ss--;
                        //            go to yc0-sort-by-icc-and-fee.;
                        await yc0_sort_by_icc_and_fee();
                        return;
                    }
                }
            }

            //     add 1,  ss2                                 giving ss2;
            //                                                        ss.;
            ss = ss2 + 1;
            ss2 = ss2 + 1;
            
            
        }

        // pricing_logic.rtn
        private async Task yc0_99_exit()
        {
            Util.Trakker(++ctr, "yc0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yj0_sort_by_orig_line_no()
        {
            Util.Trakker(++ctr, "yj0_sort_by_orig_line_no");

            // if hold-line-no (ss) > hold-line-no (ss + 1)  then;            
            if (hold_line_no[ss] > hold_line_no[ss + 1])
            {
                //     hold_sort_oma_rec = hold_oma_rec[ss];
                hold_sort_oma_rec = await hold_oma_rec_grp(ss);
                //     move hold-oma-rec (ss + 1)      to hold-oma-rec (ss)
                await hold_oma_rec_grp_set(ss, await hold_oma_rec_grp(ss + 1));
                //     hold_oma_rec[ss+1] = hold_sort_oma_rec;
                await hold_oma_rec_grp_set(ss + 1, hold_sort_oma_rec);
                //     if ss > 1 then            
                if (ss > 1)
                {
                    //             subtract 1 from ss;
                    ss--;
                    //             go to yj0-sort-by-orig-line-no;
                    await yj0_sort_by_orig_line_no();
                    return;
                }
                else
                {
                    //             next sentence.;
                }
            }

            //     add 1,  ss2                                 giving ss2;
            //                                                        ss.;
            ss = ss2 + 1;
            ss2 = ss2 + 1;            
            
        }

        // pricing_logic.rtn
        private async Task yj0_99_exit()
        {
            Util.Trakker(++ctr, "yj0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yd0_set_icc_sort_flags()
        {
            Util.Trakker(++ctr, "yd0_set_icc_sort_flags");

            //  if hold-icc-sec (ss) = "SP" then
            if (hold_icc_sec[ss] == "SP")
            {
                flag_sec_reduction_needed = "Y";
            }

            //  if  hold-sv-date    (ss) = hold-sv-date (ss - 1) and hold-oma-rec-ind(ss, ss-add-on-perc-or-flat-ind) <> "P"  and hold-oma-rec-ind(ss, ss-add-on-perc-or-flat-ind) <> "F"  then
            hold_sv_date_grp[ss] = Util.Str(hold_sv_date_yy[ss]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss]).PadLeft(2,'0');
            string tmphold_sv_date = Util.Str(hold_sv_date_yy[ss - 1]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss - 1]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss - 1]).PadLeft(2,'0');
            if (hold_sv_date_grp[ss] == tmphold_sv_date && hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind] != "P" && hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind] != "F")
            {
                //  if  hold-icc-sec (ss) = hold-icc-sec (ss - 1) or hold-icc-sec (ss) = "SP" then            
                if (Util.Str(hold_icc_sec[ss]) == Util.Str(hold_icc_sec[ss - 1]) || hold_icc_sec[ss] == "SP")
                {
                    //          if  hold-icc-grp(ss) = hold-icc-grp (ss - 1) and  (    (hold-icc-cd  (ss) not = "SP00") or (hold-icc-grp (ss) not = "00"  ) ) then
                    if (Util.Str(hold_icc_grp[ss]).PadLeft(2, '0') == Util.Str(hold_icc_grp[ss - 1]).PadLeft(2, '0') && ((Util.Str(hold_icc_sec[ss]) + Util.Str(hold_icc_grp[ss]).PadLeft(2, '0') != "SP00") || (hold_icc_grp[ss].PadLeft(2,'0') != "00")))
                    {
                        //                 move hold-flag-sec (ss - 1) to hold-flag-sec (ss)
                        hold_flag_sec[ss] = hold_flag_sec[ss - 1];
                        //                 move hold-flag-grp (ss - 1) to hold-flag-grp (ss)
                        hold_flag_grp[ss] = hold_flag_grp[ss - 1];
                        //                 go to yd0-99-exit;

                        hold_flag_sec_group[ss] = Util.Str(hold_flag_sec[ss]) + Util.Str(hold_flag_grp[ss]);
                        await yd0_99_exit();
                        return;
                    }
                    else
                    {
                        //                 move hold-flag-sec (ss - 1)     to     hold-flag-sec (ss)
                        hold_flag_sec[ss] = hold_flag_sec[ss - 1];
                        //                 add  1, ss-grp          giving ss-grp;
                        //                                                hold-flag-grp (ss);
                        ss_grp = ss_grp + 1;
                        hold_flag_grp[ss] = ss_grp;
                        //                 go to yd0-99-exit.;

                        hold_flag_sec_group[ss] = Util.Str(hold_flag_sec[ss]) + Util.Str(hold_flag_grp[ss]);
                        await yd0_99_exit();
                        return;
                    }
                }
            }

            //     add 1, ss-sec                               giving ss-sec;
            //                                                         hold-flag-sec (ss).;
            hold_flag_sec[ss] = ss_sec + 1;
            ss_sec = ss_sec + 1;

            ss_grp = 1;
            hold_flag_grp[ss] = 1;

            hold_flag_sec_group[ss] = Util.Str(hold_flag_sec[ss]) + Util.Str(hold_flag_grp[ss]);

        }

        // pricing_logic.rtn
        private async Task yd0_99_exit()
        {
            Util.Trakker(++ctr, "yd0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ye0_group_reductions()
        {
            Util.Trakker(++ctr, "ye0_group_reductions");

            //     add ss, 1                           giving ss-plus-one.;
            ss_plus_one = ss + 1;

            // if  hold-flag-sec-group (ss)  = hold-flag-sec-group (ss-plus-one);
            if (Util.Str(hold_flag_sec_group[ss]) == Util.Str(hold_flag_sec_group[ss_plus_one])
            //        and (hold-icc-grp (ss)     not = "00");
                && (hold_icc_grp[ss].PadLeft(2, '0') != "00")
            //        and (hold-sv-day ( ss, 1)  not = "BI");
                && (hold_sv_day[ss, 1] != "BI")
            //        and (hold-sv-day ( ss, 1)  not = "MR");
                && (hold_sv_day[ss, 1] != "MR")
            //        and (hold-sv-day ( ss, 1)  not = "OP");
                && (hold_sv_day[ss, 1] != "OP")
            //     then;
            )
            {
                rate_found_ss = 0;
                //         perform ye1-find-group-rate     thru ye1-99-exit;
                //                 varying ss-x;
                //                 from 1 by 1;
                //                 until    rate-found-ss not = 0;
                //                       or ss-x > const-max-nbr-rates;
                ss_x = 1;
                do
                {
                    await ye1_find_group_rate();
                    await ye1_99_exit();
                    ss_x++;
                } while (rate_found_ss == 0 && ss_x <= objConstants_mstr_rec_2.CONST_MAX_NBR_RATES);
                ss_curr_prev = hold_ss_curr_prev[ss];
                //   if rate-found-ss not = 0  then;
                if (rate_found_ss != 0)
                {
                    //  compute hold-fee-ohip (ss-plus-one)  rounded = hold-fee-ohip (ss-plus-one) * const-rates-curr-prev ( rate-found-ss, ss-curr-prev);                    
                    if (ss_curr_prev == 1)
                        hold_fee_ohip[ss_plus_one] = Util.Round(hold_fee_ohip[ss_plus_one] * (Util.NumDec(CONST_RATE_CURR(objConstants_mstr_rec_2, rate_found_ss))/100),2);
                    else
                        hold_fee_ohip[ss_plus_one] = Util.Round(hold_fee_ohip[ss_plus_one] * (Util.NumDec(CONST_RATE_PREV(objConstants_mstr_rec_2, rate_found_ss))/100),2);

                    //  compute hold-fee-oma  (ss-plus-one)  rounded =  hold-fee-oma  (ss-plus-one) * const-rates-curr-prev ( rate-found-ss, ss-curr-prev).                    
                    if (ss_curr_prev == 1) {
                        hold_fee_oma[ss_plus_one] = Util.Round(hold_fee_oma[ss_plus_one] * (Util.NumDec(CONST_RATE_CURR(objConstants_mstr_rec_2, rate_found_ss))/100),2);
                    }
                    else
                    {
                        hold_fee_oma[ss_plus_one] = Util.Round(hold_fee_oma[ss_plus_one] * (Util.NumDec(CONST_RATE_PREV(objConstants_mstr_rec_2, rate_found_ss))/100), 2);
                    }
                }
            }
        }

        // pricing_logic.rtn
        private async Task ye0_99_exit()
        {
            Util.Trakker(++ctr, "ye0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task ye1_find_group_rate()
        {
            Util.Trakker(++ctr, "ye1_find_group_rate");

            //  if const-section-group (ss-x) = hold-icc-cd (ss-plus-one)  then         
            hold_icc_cd_grp[ss_plus_one] = hold_icc_sec[ss_plus_one] + hold_icc_grp[ss_plus_one].PadLeft(2, '0');
            if (CONST_SECTION(objConstants_mstr_rec_2, ss_x) + Util.Str(CONST_GROUP(objConstants_mstr_rec_2, ss_x)).PadLeft(2, '0') == hold_icc_cd_grp[ss_plus_one])
            {
                rate_found_ss = ss_x;
            }
        }

        // pricing_logic.rtn
        private async Task ye1_99_exit()
        {
            Util.Trakker(++ctr, "ye1_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yf0_add_on_increases()
        {
            Util.Trakker(++ctr, "yf0_add_on_increases");

            // if  hold-oma-cd (ss) =;            
            // 		     "E400";
            if (await hold_oma_cd_grp(ss) == "E400"
            //                   or "E409";
               || await hold_oma_cd_grp(ss) == "E409"
            //                   or "E412";
                || await hold_oma_cd_grp(ss) == "E412"
            //                   or "E401";
                || await hold_oma_cd_grp(ss) == "E401"
            //                   or "E410";
                || await hold_oma_cd_grp(ss) == "E410"
            //                   or "E413";
                || await hold_oma_cd_grp(ss) == "E413"
            //                   or "E420";
                || await hold_oma_cd_grp(ss) == "E420"
            //        or hold-sv-day(ss,1) = "MR" or "OP";
                || hold_sv_day[ss, 1] == "MR" || hold_sv_day[ss, 1] == "OP"
            //     then;
               )
            {
                //         go to yf0-99-exit.;
                await yf0_99_exit();
                return;
            }


            //     if     ws-special-add-on-cd-entered = "N";
            if (ws_special_add_on_cd_entered == "N"
            //       and (hold-oma-add-on-cd (ss, 1) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 1]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 1]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 2) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 2]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 2]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 3) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 3]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 3]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 4) = spaces  or  zeroes);
                 && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 4]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 4]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 5) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 5]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 5]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 6) = spaces  or  zeroes);
                 && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 6]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 6]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 7) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 7]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 7]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 8) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 8]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 8]) == 0*/)
            //       and (hold-oma-add-on-cd (ss, 9) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 9]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 9]) == 0*/)
            //       and (hold-oma-add-on-cd (ss,10) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 10]) /*|| Util.NumInt(hold_oma_add_on_cd[ss, 10]) == 0*/)
            //     then;
            )
            {
                //         next sentence;
            }
            else
            {
                //         perform yf2-search-oma-recs-4-addon-cd  thru yf2-99-exit;
                //             varying ss2;
                //             from 1 by 1;
                //             until   ss2 > ss-clmdtl-oma.;

                ss2 = 1;
                do
                {
                    string retval =  await yf2_search_oma_recs_4_addon_cd();
                    if (retval.ToLower().Equals("yf2_99_exit") )
                    {
                        goto _yf2_99_exit;
                    }
                    else if (retval.ToLower().Equals("yf2_50"))
                    {
                        goto _yf2_50;
                    }
                    await yf2_30();
                    _yf2_50:
                    await yf2_50();
                    _yf2_99_exit:
                    await yf2_99_exit();
                    ss2++;
                } while (ss2 <= ss_clmdtl_oma);

            }
        }

        // pricing_logic.rtn
        private async Task yf0_99_exit()
        {
            Util.Trakker(++ctr, "yf0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task<string> yf2_search_oma_recs_4_addon_cd()
        {
            Util.Trakker(++ctr, "yf2_search_oma_recs_4_addon_cd");

            // if hold-sv-date (ss2) not = hold-sv-date (ss) then 
            hold_sv_date_grp[ss2] = Util.Str(hold_sv_date_yy[ss2]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss2]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss2]).PadLeft(2,'0');
            string temphold_sv_date = Util.Str(hold_sv_date_yy[ss]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss]).PadLeft(2,'0');
            if (hold_sv_date_grp[ss2] != temphold_sv_date)
            {
                //         go to yf2-99-exit.;                
                return "yf2_99_exit";
            }

            // if hold-icc-cd (ss2) = 'SP98' then 
            hold_icc_cd_grp[ss2] = Util.Str(hold_icc_sec[ss2]) + Util.Str(hold_icc_grp[ss2]).PadLeft(2, '0');
            if (hold_icc_cd_grp[ss2] == "SP98")
            {
                ws_reduc_rate = ws_reduc_rate98;
            }
            // else if hold-icc-cd (ss2) = 'SP99' then            
            else if (hold_icc_cd_grp[ss2] == "SP99")
            {
                ws_reduc_rate = ws_reduc_rate99;
            }
            else
            {
                ws_reduc_rate = 1;
            }


            //     if hold-oma-cd (ss2) =    hold-oma-add-on-cd (ss, 1);            
            if (await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 1]
            //                            or hold-oma-add-on-cd (ss, 2);
               || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 2]
            //                            or hold-oma-add-on-cd (ss, 3);
               || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 3]
            //                            or hold-oma-add-on-cd (ss, 4);
               || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 4]
            //                            or hold-oma-add-on-cd (ss, 5);
               || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 5]
            //                            or hold-oma-add-on-cd (ss, 6);
                || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 6]
            //                            or hold-oma-add-on-cd (ss, 7);
                || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 7]
            //                            or hold-oma-add-on-cd (ss, 8);
                || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 8]
            //                            or hold-oma-add-on-cd (ss, 9);
                || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 9]
            //                            or hold-oma-add-on-cd (ss,10);
                 || await hold_oma_cd_grp(ss2) == hold_oma_add_on_cd[ss, 10]
            //                            or "E400";
                  || await hold_oma_cd_grp(ss2) == "E400"
            //                            or "E401";
                   || await hold_oma_cd_grp(ss2) == "E401"
            //                            or "E420";
                   || await hold_oma_cd_grp(ss2) == "E420"
            //     then;
            )
            {
                //         next sentence;
            }
            else
            {
                //         go to yf2-99-exit.;                
                return "yf2_99_exit";
            }

            hold_icc_cd_grp[ss] = hold_icc_sec[ss] + hold_icc_grp[ss].PadLeft(2, '0');
            hold_oma_cd_num_grp[ss] = Util.Str(hold_oma_cd_num_1[ss]) + Util.Str(hold_oma_cd_num_2[ss]) + Util.Str(hold_oma_cd_num_3[ss]);

            //  if hold-oma-cd(ss2) = "E420" then;
            if (await hold_oma_cd_grp(ss2) == "E420")
            {
                // 	if     hold-oma-cd (ss) <> "E400";
                if (await hold_oma_cd_grp(ss) != "E400"
                     // 	   and hold-oma-cd (ss) <> "E401";
                     && await hold_oma_cd_grp(ss) != "E401"
                     // 	   and hold-oma-cd (ss) <> "E409";
                     && await hold_oma_cd_grp(ss) != "E409"
                      // 	   and hold-oma-cd (ss) <> "E412";
                      && await hold_oma_cd_grp(ss) != "E412"
                      // 	   and hold-oma-cd (ss) <> "E410";
                      && await hold_oma_cd_grp(ss) != "E410"
                       // 	   and hold-oma-cd (ss) <> "E413";
                       && await hold_oma_cd_grp(ss) != "E413"
                       // 	   and hold-oma-cd (ss) <> "E411";
                       && await hold_oma_cd_grp(ss) != "E411"
                      //            and (   ( hold-icc-cd    (ss) =  "SP00";
                      && ((hold_icc_cd_grp[ss] == "SP00"
                                // 	           );
                                )
                          //                 or (    hold-icc-cd    (ss) = "CV00";
                          || (hold_icc_cd_grp[ss] == "CV00"
                           //                     and hold-oma-suff  (ss) = "A";
                           && hold_oma_suff[ss] == "A"
                           // 	            and (   hold-oma-cd-num(ss) < 990;
                           && (Util.NumInt(hold_oma_cd_num_grp[ss]) < 990
                           // 	                 or hold-oma-cd-num(ss) > 997;
                           || Util.NumInt(hold_oma_cd_num_grp[ss]) > 997
                                // 		        );
                                )
                           // 		   );
                           )
                           //                 or (    hold-oma-suff  (ss) = "A";
                           || (hold_oma_suff[ss] == "A"
                             // 	            and (   hold-oma-cd-num(ss) = "G395"                    
                             && (hold_oma_cd_num_grp[ss] == "G395"
                            // 			            or "G391";
                            || hold_oma_cd_num_grp[ss] == "G391"
                            // 			            or "G521";
                            || hold_oma_cd_num_grp[ss] == "G521"
                             // 			            or "G523";
                             || hold_oma_cd_num_grp[ss] == "G523"
                                      // 		             );
                                      )
                               // 	           );
                               )
                            // 	        );
                            )
                //       then;
                )
                {
                    // 	        next sentence;
                }
                else
                {
                    //         go to yf2-99-exit;                    
                    return "yf2_99_exit";
                }
            }
            else
            {
                // 	next sentence.;
            }


            //  if    hold-oma-suff(ss2)      = hold-oma-suff(ss);            
            if (hold_oma_suff[ss2] == hold_oma_suff[ss]
            //        or (    hold-oma-cd  (ss2) = "E420";
                || (await hold_oma_cd_grp(ss2) == "E420"
            // 	   and hold-oma-suff(ss2) = "A";
                 && hold_oma_suff[ss2] == "A"
            // 	  );
                   )
            //     then;
            )
            {
                // 	   next sentence;
            }
            else
            {
                //         go to yf2-99-exit.;                
                return "yf2_99_exit";
            }


            //  if      hold-oma-rec-ind (ss2 , ss-add-on-perc-or-flat-ind) <> "P";
            hold_sv_date_grp[ss2] = Util.Str(hold_sv_date_yy[ss2]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss2]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss2]).PadLeft(2, '0');
            if (hold_oma_rec_ind[ss2, ss_add_on_perc_or_flat_ind] != "P"
            //         or  (    hold-oma-suff (ss2) = "B";
                 || (hold_oma_suff[ss2] == "B"
            // 	     and hold-oma-cd   (ss2) = "E676";
                  && await hold_oma_cd_grp(ss2) == "E676"
            // 	     and hold-sv-date  (ss2) < "20110901";
                  && Util.Str(hold_sv_date_grp[ss2]).CompareTo("20110901") < 0
             // 	    );
             )
            //     then;
            )
            {
                //         go to yf2-30.;                
                return "yf2_30";
            }


            // if  hold-oma-suff (ss2) = "B" and hold-oma-cd   (ss2) = "E676" and hold-sv-date  (ss2) >= "20110901"  then
            if (hold_oma_suff[ss2] == "B" && await hold_oma_cd_grp(ss2) == "E676" && Util.Str(hold_sv_date_grp[ss2]).CompareTo("20110901") >= 0)
            {
                // 	go to yf2-99-exit.;                
                return "yf2_99_exit";
            }


            // if hold-sv-day ( ss2, 1) not = "OP" then;
            if (hold_sv_day[ss2, 1] != "OP")
            {
                //  compute hold-fee-oma  (ss2) rounded =  hold-fee-oma  (ss2)     + (   hold-fee-oma   (ss) * hold-oma-fee-1 (ss2 , oma) * ws-reduc-rate    )
                hold_fee_oma[ss2] = Util.Round(hold_fee_oma[ss2] + (hold_fee_oma[ss] * hold_oma_fee_1[ss2, oma] * ws_reduc_rate), 2);
                //  compute hold-fee-ohip  (ss2) rounded = hold-fee-ohip  (ss2)    + (   hold-fee-ohip   (ss) * hold-oma-fee-1 (ss2 , ohip) * ws-reduc-rate    )
                hold_fee_ohip[ss2] = Util.Round(hold_fee_ohip[ss2] + (hold_fee_ohip[ss] * hold_oma_fee_1[ss2, ohip] * ws_reduc_rate), 2);
                //  if hold-oma-cd (ss2) = "E400"  or "E401"  then;           
                if (await hold_oma_cd_grp(ss2) == "E400" || await hold_oma_cd_grp(ss2) == "E401")
                {
                    //   compute hold-sv-nbr-serv (ss2)  =  hold-sv-nbr-serv ( ss2) + hold-sv-nbr-serv ( ss) + hold-sv-nbr( ss, 1) + hold-sv-nbr ( ss, 2) + hold-sv-nbr( ss, 3);
                    hold_sv_nbr_serv[ss2] = hold_sv_nbr_serv[ss2] + hold_sv_nbr_serv[ss] + hold_sv_nbr[ss, 1] + hold_sv_nbr[ss, 2] + hold_sv_nbr[ss, 3];

                    //Core Added - Picture clause of hold_sv_nbr_serv is "99", so if the sum is greater than 99 only the last 2 digits are used.
                    if (hold_sv_nbr_serv[ss2].ToString().Length > 2)
                    {
                        hold_sv_nbr_serv[ss2] = Util.NumInt(hold_sv_nbr_serv[ss2].ToString().Substring(hold_sv_nbr_serv[ss2].ToString().Length - 2));
                    }

                    // 	 compute nbr-of-services =  nbr-of-services + hold-sv-nbr-serv ( ss) + hold-sv-nbr ( ss, 1) + hold-sv-nbr( ss, 2) + hold-sv-nbr ( ss, 3);
                    nbr_of_services = nbr_of_services + hold_sv_nbr_serv[ss] + hold_sv_nbr[ss, 1] + hold_sv_nbr[ss, 2] + hold_sv_nbr[ss, 3];
                    //   display scr-last-claim;
                    //   go to yf2-50;                    
                    return "yf2_50";
                }
                else
                {
                    //  go to yf2-50;                    
                    return "yf2_50";
                }
            }
            else
            {
                //         next sentence.;
            }

            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task yf2_30()
        {
            Util.Trakker(++ctr, "yf2_30");

            //  compute ws-pricing-nbr-serv =   hold-sv-nbr-serv ( ss2) + hold-sv-nbr( ss2, 1) + hold-sv-nbr ( ss2, 2) + hold-sv-nbr      ( ss2, 3);
            ws_pricing_nbr_serv = hold_sv_nbr_serv[ss2] + hold_sv_nbr[ss2, 1] + hold_sv_nbr[ss2, 2] + hold_sv_nbr[ss2, 3];

            //  if hold-sv-day ( ss2, 1) not = "OP"  then;            
            if (hold_sv_day[ss2, 1] != "OP")
            {
                //   compute hold-fee-oma   (ss2) rounded =  hold-fee-oma (ss2) +   (   hold-oma-fee-2 (ss2 ,  oma) * ws-hold-wcb-rate * ws-pricing-nbr-serv * ws-reduc-rate       );
                hold_fee_oma[ss2] = Util.Round(hold_fee_oma[ss2] + (hold_oma_fee_2[ss2, oma] * ws_hold_wcb_rate * ws_pricing_nbr_serv * ws_reduc_rate), 2);
                //   compute hold-fee-ohip  (ss2) rounded = hold-fee-ohip  (ss2)  +  (   hold-oma-fee-2 (ss2 , ohip)  * ws-hold-wcb-rate * ws-pricing-nbr-serv * ws-reduc-rate       ).
                hold_fee_ohip[ss2] = Util.Round(hold_fee_ohip[ss2] + (hold_oma_fee_2[ss2, ohip] * ws_hold_wcb_rate * ws_pricing_nbr_serv * ws_reduc_rate), 2);
            }
        }

        // pricing_logic.rtn
        private async Task yf2_50()
        {
            Util.Trakker(++ctr, "yf2_50");

            // if def-agent-bill-direct or def-agent-foreign-direct or def-agent-ifhp-direct or def-agent-ontario-direct or def-agent-quebec-direct  then            
            if (Util.Str(def_agent_code).Equals(def_agent_bill_direct) || Util.Str(def_agent_code).Equals(def_agent_foreign_direct) || Util.Str(def_agent_code).Equals(def_agent_ifhp_direct) || Util.Str(def_agent_code).Equals(def_agent_ontario_direct) || Util.Str(def_agent_code).Equals(def_agent_quebec_direct))
            {
                //      move hold-fee-oma (ss)      to hold-fee-ohip (ss)
                hold_fee_ohip[ss] = hold_fee_oma[ss];
            }
            else
            {
                //             next sentence.;
            }
        }

        // pricing_logic.rtn
        private async Task yf2_99_exit()
        {
            Util.Trakker(++ctr, "yf2_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yf1_special_add_on_incr()
        {
            Util.Trakker(++ctr, "yf1_special_add_on_incr");

            //  if   hold-oma-cd (ss) =;
            // 		            "E400";
            if (await hold_oma_cd_grp(ss) == "E400"
            //                   or "E409";
                || await hold_oma_cd_grp(ss) == "E409"
            //                   or "E412";
                || await hold_oma_cd_grp(ss) == "E412"
            //                   or "E401";
                || await hold_oma_cd_grp(ss) == "E401"
            //                   or "E410";
                || await hold_oma_cd_grp(ss) == "E410"
            //                   or "E413";
                || await hold_oma_cd_grp(ss) == "E413"
            //                   or "E420";
                 || await hold_oma_cd_grp(ss) == "E420"
            //     then;
            )
            {
                //         go to yf1-99-exit.;
                await yf1_99_exit();
                return;
            }

            //     if     ws-special-add-on-cd-entered = "N";
            if (ws_special_add_on_cd_entered == "N"
            //       and (hold-oma-add-on-cd (ss, 1) = spaces  or  zeroes);
                 && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 1]) /*|| ( Util.IsNumericValue(hold_oma_add_on_cd[ss, 1]) &&  Util.NumInt(hold_oma_add_on_cd[ss, 1]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 2) = spaces  or  zeroes);
                 && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 2]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 2]) &&   Util.NumInt(hold_oma_add_on_cd[ss, 2]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 3) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 3]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 3]) &&  Util.NumInt(hold_oma_add_on_cd[ss, 3]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 4) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 4]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 4])  &&  Util.NumInt(hold_oma_add_on_cd[ss, 4]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 5) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 5]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 5]) &&  Util.NumInt(hold_oma_add_on_cd[ss, 5]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 6) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 6]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 6])  &&  Util.NumInt(hold_oma_add_on_cd[ss, 6]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 7) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 7]) /*|| ( Util.IsNumericValue(hold_oma_add_on_cd[ss, 7]) &&  Util.NumInt(hold_oma_add_on_cd[ss, 7]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 8) = spaces  or  zeroes);
                 && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 8]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 8]) &&  Util.NumInt(hold_oma_add_on_cd[ss, 8]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss, 9) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 9]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 9]) &&  Util.NumInt(hold_oma_add_on_cd[ss, 9]) == 0)*/)
            //       and (hold-oma-add-on-cd (ss,10) = spaces  or  zeroes);
                && (string.IsNullOrWhiteSpace(hold_oma_add_on_cd[ss, 10]) /*|| (Util.IsNumericValue(hold_oma_add_on_cd[ss, 10]) && Util.NumInt(hold_oma_add_on_cd[ss, 10]) == 0)*/)
            //     then;
            )
            {
                //         next sentence;
            }
            else
            {
                //         perform yf3-search-oma-recs-4-addon-cd  thru yf3-99-exit;
                //             varying ss2;
                //             from 1 by 1;
                //             until   ss2 > ss-clmdtl-oma.;
                ss2 = 1;
                do
                {
                    string retval =  await yf3_search_oma_recs_4_addon_cd();
                    if (retval.ToLower().Equals("yf3_99_exit") )
                    {
                        goto _yf3_99_exit;
                    }
                    else if (retval.ToLower().Equals("yf3_50"))
                    {
                        goto _yf3_50;
                    }
                    await yf3_30();
                    _yf3_50:
                    await yf3_50();
                    _yf3_99_exit:
                    await yf3_99_exit();
                    ss2++;
                } while (ss2 <= ss_clmdtl_oma);
            }
        }

        // pricing_logic.rtn
        private async Task yf1_99_exit()
        {
            Util.Trakker(++ctr, "yf1_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task<string> yf3_search_oma_recs_4_addon_cd()
        {
            Util.Trakker(++ctr, "yf3_search_oma_recs_4_addon_cd");

            // if hold-sv-date (ss2) not = hold-sv-date (ss)  then            
            hold_sv_date_grp[ss] = Util.Str(hold_sv_date_yy[ss]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss]).PadLeft(2, '0');
            string tmpHold_sv_date_grp = Util.Str(hold_sv_date_yy[ss2]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[ss2]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[ss2]).PadLeft(2, '0');
            if (tmpHold_sv_date_grp != hold_sv_date_grp[ss])
            {
                //         go to yf3-99-exit.;                
                return "yf3_99_exit";
            }

            // if hold-icc-cd (ss2) = 'SP98' then       
            hold_icc_cd_grp[ss2] = Util.Str(hold_icc_sec[ss2]).PadRight(2) + Util.Str(hold_icc_grp[ss2]).PadLeft(2, '0');
            if (hold_icc_cd_grp[ss2] == "SP98")
            {
                ws_reduc_rate = ws_reduc_rate98;
            }
            //  else if hold-icc-cd (ss2) = 'SP99'  then            
            else if (hold_icc_cd_grp[ss2] == "SP99")
            {
                ws_reduc_rate = ws_reduc_rate99;
            }
            else
            {
                ws_reduc_rate = 1;
            }


            // if hold-oma-cd(ss2) = "E409" or "E412" or "E410" or "E413" then                     
            if (await hold_oma_cd_grp(ss2) == "E409" || await hold_oma_cd_grp(ss2) == "E412" || await hold_oma_cd_grp(ss2) == "E410" || await hold_oma_cd_grp(ss2) == "E413")
            {
                // 	    if  ( hold-oma-cd(ss) = "G395" or "G391" or "G521" or "G523" ) or (hold-icc-sec(ss) = "CV" ) then                           
                if ((await hold_oma_cd_grp(ss) == "G395" || await hold_oma_cd_grp(ss) == "G391" || await hold_oma_cd_grp(ss) == "G521" || await hold_oma_cd_grp(ss) == "G523") || (hold_icc_sec[ss] == "CV"))
                {
                    // 		     go to yf3-99-exit;                    
                    return "yf3_99_exit";
                }
                else
                {
                    // 		     next sentence;
                }
            }
            else
            {
                //             go to yf3-99-exit.;                
                return "yf3_99_exit";
            }

            //  if hold-oma-suff(ss2) not = hold-oma-suff(ss)  then;            
            if (hold_oma_suff[ss2] != hold_oma_suff[ss])
            {
                //         go to yf3-99-exit.;                
                return "yf3_99_exit";
            }

            // if hold-oma-rec-ind (ss2 , ss-add-on-perc-or-flat-ind) <> "P" then           
            if (hold_oma_rec_ind[ss2, ss_add_on_perc_or_flat_ind] != "P")
            {
                //         go to yf3-30.;                
                return "yf3_30";
            }

            // if hold-sv-day ( ss2, 1) not = "OP" then;       
            if (hold_sv_day[ss2, 1] != "OP")
            {
                //  compute hold-fee-oma  (ss2) rounded = hold-fee-oma  (ss2) + (   hold-fee-oma   (ss)  * hold-oma-fee-1 (ss2 , oma) * ws-reduc-rate    )
                hold_fee_oma[ss2] = Util.Round(hold_fee_oma[ss2] + (hold_fee_oma[ss] * hold_oma_fee_1[ss2, oma] * ws_reduc_rate), 2);
                //  compute hold-fee-ohip  (ss2) rounded = hold-fee-ohip  (ss2)    + (   hold-fee-ohip   (ss)  * hold-oma-fee-1 (ss2 , ohip)   * ws-reduc-rate    )
                hold_fee_ohip[ss2] = Util.Round(hold_fee_ohip[ss2] + (hold_fee_ohip[ss] * hold_oma_fee_1[ss2, ohip] * ws_reduc_rate), 2);
                //         if hold-oma-cd(ss2) = "E409" or "E412"  or "E410" or "E413"  then;                            
                if (await hold_oma_cd_grp(ss2) == "E409" || await hold_oma_cd_grp(ss2) == "E412" || await hold_oma_cd_grp(ss2) == "E410" || await hold_oma_cd_grp(ss2) == "E413")
                {
                    hold_sv_nbr_serv[ss2] = 1;
                    //                 go to yf3-50;                    
                    return "yf3_50";
                }
                else
                {
                    //                 go to yf3-50;                    
                    return "yf3_50";
                }
            }
            else
            {
                //         next sentence.;
            }
            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task yf3_30()
        {
            Util.Trakker(++ctr, "yf3_30");


            //  if hold-oma-cd ( ss2 ) = "E409" or "E412"  or "E410"  or "E413"  then            
            if (await hold_oma_cd_grp(ss2) == "E409" || await hold_oma_cd_grp(ss2) == "E412" || await hold_oma_cd_grp(ss2) == "E410" || await hold_oma_cd_grp(ss2) == "E413")
            {
                ws_pricing_nbr_serv = 1;
            }

            //  if hold-sv-day ( ss2, 1) not = "OP"  then            
            if (hold_sv_day[ss2, 1] != "OP")
            {
                //    compute hold-fee-oma   (ss2) rounded = hold-fee-oma   (ss2)  +   (   hold-oma-fee-2 (ss2 ,  oma)  * ws-hold-wcb-rate  * ws-pricing-nbr-serv  * ws-reduc-rate       )
                hold_fee_oma[ss2] = Util.Round(hold_fee_oma[ss2] + (hold_oma_fee_2[ss2, oma] * ws_hold_wcb_rate * ws_pricing_nbr_serv * ws_reduc_rate), 2);

                //   compute hold-fee-ohip  (ss2) rounded = hold-fee-ohip  (ss2)  +  (   hold-oma-fee-2 (ss2 , ohip) * ws-hold-wcb-rate  * ws-pricing-nbr-serv * ws-reduc-rate       ).
                hold_fee_ohip[ss2] = Util.Round(hold_fee_ohip[ss2] + (hold_oma_fee_2[ss2, ohip] * ws_hold_wcb_rate * ws_pricing_nbr_serv * ws_reduc_rate), 2);
            }
        }

        // pricing_logic.rtn
        private async Task yf3_50()
        {
            Util.Trakker(++ctr, "yf3_50");

            // if  (hold-oma-cd (ss2) = "E409" or "E412" or "E413" or "E410") and hold-sv-day ( ss2, 1) not = "OP" then                        
            if ((await hold_oma_cd_grp(ss2) == "E409" || await hold_oma_cd_grp(ss2) == "E412" || await hold_oma_cd_grp(ss2) == "E413" || await hold_oma_cd_grp(ss2) == "E410") && hold_sv_day[ss2, 1] != "OP")
            {
                //      if  hold-fee-oma (ss2)     < hold-oma-fee-2 (ss2, oma) then            
                if (hold_fee_oma[ss2] < hold_oma_fee_2[ss2, oma])
                {
                    hold_fee_oma[ss2] = hold_oma_fee_2[ss2, oma];
                    //           move hold-oma-fee-2 (ss2,ohip)      to hold-fee-ohip (ss2)
                    hold_fee_ohip[ss2] = hold_oma_fee_2[ss2, ohip];
                }
                else
                {
                    //             next sentence.;
                }
            }


            //  if def-agent-bill-direct or def-agent-foreign-direct  or def-agent-ifhp-direct  or def-agent-ontario-direct or def-agent-quebec-direct  then;
            if (Util.Str(def_agent_code).Equals(def_agent_bill_direct) || Util.Str(def_agent_code).Equals(def_agent_foreign_direct) || Util.Str(def_agent_code).Equals(def_agent_ifhp_direct) || Util.Str(def_agent_code).Equals(def_agent_ontario_direct) || def_agent_code.Equals(def_agent_quebec_direct))
            {
                //     move hold-fee-oma (ss)      to hold-fee-ohip (ss)    
                hold_fee_ohip[ss] = hold_fee_oma[ss];
            }
            else
            {
                //             next sentence.;
            }
        }

        // pricing_logic.rtn
        private async Task yf3_99_exit()
        {
            Util.Trakker(++ctr, "yf3_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yh0_find_high_grp_within_sec()
        {
            Util.Trakker(++ctr, "yh0_find_high_grp_within_sec");

            //hold_grp_totals_tbl = 0;
            hold_grp_tot = new decimal[91];
            hold_grp_nbr = new decimal[91];
            hold_grp_nbr_sec = new int[91];
            hold_grp_nbr_grp = new int[91];

            ss_grp_tot = 0;
            ws_highest_grp_tot = 0;
            ws_highest_grp_nbr = 0;

            flag_new_sec = "N";
        }

        // pricing_logic.rtn
        private async Task yh0_100_find_sp_suffix_a()
        {
            Util.Trakker(++ctr, "yh0_100_find_sp_suffix_a");

            // if hold-oma-suff (ss-from) = "A"  then            
            if (Util.Str(hold_oma_suff[ss_from]).ToUpper() == "A")
            {
                //     add 1                           to      ss-grp-tot;
                ss_grp_tot++;
                ss = ss_from;
                //     perform yh11-add-singular-value thru    yh11-99-exit;
                await yh11_add_singular_value();
                await yh11_99_exit();
            }
            else
            {
                //         add 1                           to      ss-from;
                ss_from++;
                //         if ss-from > ss-clmdtl-oma then            
                if (ss_from > ss_clmdtl_oma)
                {
                    ss_to = ss_clmdtl_oma;
                    flag_new_sec = "Y";
                }
                else
                {
                    //    go to yh0-100-find-sp-suffix-a.;
                    await yh0_100_find_sp_suffix_a();
                    return;
                }
            }

            //     add 1, ss-from                              giving ss-from-plus-one.;
            ss_from_plus_one = ss_from + 1;

            //     perform yh1-calc-group-values               thru yh1-99-exit;
            //                 varying ss;
            //                 from ss-from-plus-one by 1;
            //                 until   flag-new-sec = "Y".;

            ss = ss_from_plus_one;
            do
            {
                await yh1_calc_group_values();
                await yh1_99_exit();
                ss++;
            } while (flag_new_sec != "Y");


            flag_z_highest_grp = "N";

            //     perform yh2-find-highest-value              thru yh2-99-exit;
            //                 varying ss;
            //                 from 1 by 1;
            //                 until ss > ss-grp-tot.;

            ss = 1;
            do
            {
                await yh2_find_highest_value();
                await yh2_99_exit();
                ss++;
            } while (ss <= ss_grp_tot);

        }

        // pricing_logic.rtn
        private async Task yh0_99_exit()
        {
            Util.Trakker(++ctr, "yh0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yh1_calc_group_values()
        {
            Util.Trakker(++ctr, "yh1_calc_group_values");

            //  if ss > ss-clmdtl-oma then            
            if (ss > ss_clmdtl_oma)
            {
                ss_to = ss_clmdtl_oma;
                flag_new_sec = "Y";
                //    go to yh1-99-exit.;
                await yh1_99_exit();
                return;
            }

            //  if hold-oma-suff (ss) = "B" or "C"  then            
            if (Util.Str(hold_oma_suff[ss]).ToUpper() == "B" || Util.Str(hold_oma_suff[ss]).ToUpper() == "C")
            {
                //         go to yh1-99-exit.;
                await yh1_99_exit();
                return;
            }

            //  if hold-icc-sec  (ss) not = "SP"  then            
            if (Util.Str(hold_icc_sec[ss]).ToUpper() != "SP")
            {
                //         next sentence;
            }
            //  else  if  hold-flag-sec-group (ss) = hold-flag-sec-group (ss - 1) then            
            else if (Util.Str(hold_flag_sec_group[ss]) == Util.Str(hold_flag_sec_group[ss - 1]))
            {
                //             perform yh11-add-singular-value     thru    yh11-99-exit;
                await yh11_add_singular_value();
                await yh11_99_exit();
                //             go to yh1-99-exit;
                await yh1_99_exit();
                return;
            }
            //  else if hold-flag-sec (ss) = hold-flag-sec (ss - 1)  then            
            else if (hold_flag_sec[ss] == hold_flag_sec[ss - 1])
            {
                //            add 1                           to ss-grp-tot;
                ss_grp_tot++;
                //            perform yh11-add-singular-value thru    yh11-99-exit;
                await yh11_add_singular_value();
                await yh11_99_exit();
                //           go to yh1-99-exit.;
                await yh1_99_exit();
                return;
            }

            //     subtract 1 from ss                          giving ss-to.;
            ss_to = ss - 1;
            flag_new_sec = "Y";
        }

        // pricing_logic.rtn
        private async Task yh1_99_exit()
        {
            Util.Trakker(++ctr, "yh1_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yh11_add_singular_value()
        {
            Util.Trakker(++ctr, "yh11_add_singular_value");

            // move hold-flag-sec-group (ss)               to hold-grp-nbr (ss-grp-tot).
            hold_grp_nbr[ss_grp_tot] = Util.NumDec(hold_flag_sec_group[ss]);

            //  if hold-flag-fee-used (ss) = "0" then            
            if (Util.Str(hold_flag_fee_used[ss]) == "0")
            {
                //         add hold-fee-oma (ss)                   to hold-grp-tot (ss-grp-tot);
                hold_grp_tot[ss_grp_tot] += hold_fee_oma[ss];
            }
            //  else if hold-flag-fee-used (ss) = "1" then            
            else if (Util.Str(hold_flag_fee_used[ss]) == "1")
            {
                //             add hold-oma-fee-1 (ss, ohip)       to hold-grp-tot (ss-grp-tot);
                hold_grp_tot[ss_grp_tot] += hold_oma_fee_1[ss, ohip];
            }
            //  else if hold-flag-fee-used (ss) = "2" then            
            else if (Util.Str(hold_flag_fee_used[ss]) == "2")
            {
                //         add hold-oma-fee-2 (ss, ohip)   to hold-grp-tot (ss-grp-tot);
                hold_grp_tot[ss_grp_tot] += hold_oma_fee_2[ss, ohip];
            }
            //  else if hold-flag-fee-used (ss) = "3" then            
            else if (Util.Str(hold_flag_fee_used[ss]) == "3")
            {
                //          add hold-oma-fee-1 (ss, ohip);
                //              hold-oma-fee-2 (ss, ohip);
                //              hold-grp-tot (ss-grp-tot) giving hold-grp-tot (ss-grp-tot).;
                hold_grp_tot[ss_grp_tot] = hold_oma_fee_1[ss, ohip] + hold_oma_fee_2[ss, ohip] + hold_grp_tot[ss_grp_tot];
            }
        }

        // pricing_logic.rtn
        private async Task yh11_99_exit()
        {
            Util.Trakker(++ctr, "yh11_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yh2_find_highest_value()
        {
            Util.Trakker(++ctr, "yh2_find_highest_value");

            //  if hold-grp-tot ( ss ) > ws-highest-grp-tot then;            
            if (hold_grp_tot[ss] > ws_highest_grp_tot)
            {
                ws_highest_grp_tot = hold_grp_tot[ss];
                ws_highest_grp_nbr = Util.NumInt(hold_grp_nbr[ss]);
                //         if hold-oma-cd-alpha(ss) = 'Z' then            
                if (Util.Str(hold_oma_cd_alpha[ss]).ToUpper() == "Z")
                {
                    flag_z_highest_grp = "Y";
                }
            }
        }

        // pricing_logic.rtn
        private async Task yh2_99_exit()
        {
            Util.Trakker(++ctr, "yh2_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yi0_sec_reduct_within_sec()
        {
            Util.Trakker(++ctr, "yi0_sec_reduct_within_sec");

            ss_curr_prev = hold_ss_curr_prev[ss];

            //   if     hold-oma-rec-ind(ss, ss-add-on-perc-or-flat-ind) <> "P";
            if (Util.Str(hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind]).ToUpper() != "P"
            //        and hold-oma-rec-ind(ss, ss-add-on-perc-or-flat-ind) <> "F";
                 && Util.Str(hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind]).ToUpper() != "F"
            //        and hold-sv-day     (ss, 1)  <> "MR";
                 && Util.Str(hold_sv_day[ss, 1]).ToUpper() != "MR"
            //        and hold-sv-day     (ss, 1)  <> "OP";
                 && Util.Str(hold_sv_day[ss, 1]).ToUpper() != "OP"
            //        and hold-oma-suff   (ss)     <> "B";
                 && Util.Str(hold_oma_suff[ss]).ToUpper() != "B"
            //        and hold-oma-suff   (ss)     <> "C";
                 && Util.Str(hold_oma_suff[ss]).ToUpper() != "C"
            //     then;
            )
            {
                //         if   hold-flag-sec-group (ss) = ws-highest-grp-nbr or  flag-z-highest-grp = 'Y' then      
                hold_icc_cd_grp[ss] = hold_icc_sec[ss] + hold_icc_grp[ss].PadLeft(2, '0');
                if (Util.NumInt(hold_flag_sec_group[ss]) == ws_highest_grp_nbr || Util.Str(flag_z_highest_grp).ToUpper() == "Y")
                {
                    //             next sentence;                
                }
                //         else if    hold-oma-cd-alpha (ss) <> "Z";
                else if (hold_oma_cd_alpha[ss] != "Z"
                //               and hold-oma-rec-ind  (ss, ss-add-on-perc-or-flat-ind) <> "P";
                      && hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind] != "P"
                //               and hold-oma-rec-ind  (ss, ss-add-on-perc-or-flat-ind) <> "F";
                      && hold_oma_rec_ind[ss, ss_add_on_perc_or_flat_ind] != "F"
                //               and (hold-icc-cd (ss) not = "SP98");
                      && (hold_icc_cd_grp[ss] != "SP98")
                //               and (hold-icc-cd (ss) not = "SP99");
                      && (hold_icc_cd_grp[ss] != "SP99")
                //             then;
                )
                {
                    //   compute hold-fee-oma  (ss) rounded = hold-fee-oma  (ss) * const-sr (ss-curr-prev);
                    hold_fee_oma[ss] = Util.Round( hold_fee_oma[ss] * (Util.NumDec(CONST_SR_GET(objConstants_mstr_rec_2, ss_curr_prev))/100),2);

                    //  compute hold-fee-ohip (ss) rounded = hold-fee-ohip (ss) * const-sr (ss-curr-prev).;
                    hold_fee_ohip[ss] = Util.Round(hold_fee_ohip[ss] * (Util.NumDec(CONST_SR_GET(objConstants_mstr_rec_2, ss_curr_prev))/100),2);
                }
            }
        }

        // pricing_logic.rtn
        private async Task yi0_99_exit()
        {
            Util.Trakker(++ctr, "yi0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task<string> ym0_create_desc_record()
        {
            Util.Trakker(++ctr, "ym0_create_desc_record");

            //  if not online-claim then;            
            if (!Util.Str(flag_claim_source).Equals(online_claim))
            {
                //      if adjudication-desc-entry then            
                if (Util.Str(flag_desc_rec).Equals(adjudication_desc_entry))
                {
                    flag_adjudication_required = "Y";
                    // 	        go to ym0-99-exit;                    
                    return "ym0_99_exit";
                }
                else
                {
                    //     go to ym0-99-exit.;                    
                    return "ym0_99_exit";
                }
            }

            //  if adjudication-desc-entry  then            
            if (Util.Str(flag_desc_rec).Equals(adjudication_desc_entry))
            {
                flag_adjudication_required = "Y";
                //    go to ym0-90-display.;                
                return "ym0_90_display";
            }

            //     add 1                               to ss-basic-times.;
            ss_basic_times++;

            //  if  ( basic-plus-times-entry  and ss-basic-times > 2 )  then 
            if (Util.Str(flag_desc_rec).Equals(basic_plus_times_entry) && ss_basic_times > 2)
            {
                ss_basic_times = 1;
                //    add 1, ss-basic-times-desc-rec  giving ss-basic-times-desc-rec.;
                ss_basic_times_desc_rec = ss_basic_times_desc_rec + 1;
            }

            // if basic-plus-times-entry then         
            if (Util.Str(flag_desc_rec).Equals(basic_plus_times_entry))
            {
                //     move "B +"                        to hold-basic-b (ss-basic-times)   
                hold_basic_b[ss_basic_times] = "B +";
                //     move "T /"                        to hold-times-t (ss-basic-times)
                hold_times_t[ss_basic_times] = "T /";
                hold_times_units[ss_basic_times] = ws_tot_serv;
                // 	   if hold-oma-suff (ss) = "B" then            
                if (Util.Str(hold_oma_suff[ss]).ToUpper() == "B")
                {
                    hold_basic_units[ss_basic_times] = hold_oma_fee_asst[ss, ohip];
                    hold_desc[ss_basic_times_desc_rec] = await hold_basic_times_desc_grp();
                    // 	       go to ym0-90-display;                    
                    return "ym0_90_display";
                }
                else
                {
                    hold_basic_units[ss_basic_times] = hold_oma_fee_anae[ss, ohip];
                    hold_desc[ss_basic_times_desc_rec] = await hold_basic_times_desc_grp();
                    // 	        go to ym0-90-display.;                    
                    return "ym0_90_display";
                }
            }
            return string.Empty;
        }

        // pricing_logic.rtn
        private async Task ym0_90_display()
        {
            Util.Trakker(++ctr, "ym0_90_display");

            //     display scr-acpt-det-desc.;
        }

        // pricing_logic.rtn
        private async Task ym0_99_exit()
        {
            Util.Trakker(++ctr, "ym0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yz0_reset_verify_prices()
        {
            Util.Trakker(++ctr, "yz0_reset_verify_prices");

            //     perform yz1-check-price		thru yz1-99-exit;
            //         varying ss;
            //         from 1 by 1;
            //         until   ss > ss-clmdtl-oma.;

            ss = 1;
            do
            {
                await yz1_check_price();
                await yz1_99_exit();
                ss++;
            } while (ss <= ss_clmdtl_oma);
        }

        // pricing_logic.rtn
        private async Task yz0_99_exit()
        {
            Util.Trakker(++ctr, "yz0_99_exit");

            //     exit.;
        }

        // pricing_logic.rtn
        private async Task yz1_check_price()
        {
            Util.Trakker(++ctr, "yz1_check_price");

            //  if  ( diskette-claim  and retain-incoming-prices ) or  web-claim  and ( retain-incoming-prices   or hold-sv-day (ss,1) = "MR" or "OP"  ) then            
            if ((Util.Str(flag_claim_source).Equals(diskette_claim) && Util.Str(flag_retain_prices).Equals(retain_incoming_prices)) || Util.Str(flag_claim_source).Equals(web_claim) && (Util.Str(flag_retain_prices).Equals(retain_incoming_prices) || Util.Str(hold_sv_day[ss, 1]).ToUpper() == "MR" || Util.Str(hold_sv_day[ss, 1]).ToUpper() == "OP"))
            {
                //    move hold-fee-incoming (ss)     to hold-fee-ohip    (ss).
                hold_fee_ohip[ss] = hold_fee_incoming[ss];
            }

            // if   diskette-claim then;            
            if (Util.Str(flag_claim_source).Equals(diskette_claim))
            {
                hold_sv_nbr_serv[ss] = hold_sv_nbr_serv_incoming[ss];
            }
        }

        // pricing_logic.rtn
        private async Task yz1_99_exit()
        {
            Util.Trakker(++ctr, "yz1_99_exit");

            //     exit.;
        }

        private async Task xa0_display_details()
        {
            Util.Trakker(++ctr, "xa0_display_details");
        }

        private async Task xa0_99_exit()
        {
            Util.Trakker(++ctr, "xa0_99_exit");

            //     exit.;
        }

        private async Task za0_common_error()
        {
            Util.Trakker(++ctr, "za0_common_error");

        }

        private async Task za0_99_exit()
        {
            Util.Trakker(++ctr, "za0_99_exit");

            //     exit.;
        }

        private async Task zb0_build_write_err_rpt_line()
        {
            Util.Trakker(++ctr, "zb0_build_write_err_rpt_line");

            //objRpt_line.rpt_line = err_msg[err_ind];
            objRpt_line.Rpt_line1 = await Err_Message(err_ind);  //err_msg[err_ind];

            //objRu701_work_rec.ru701_page_area = '5';
            objRu701_work_rec.Ru701_page_area = "5";

            //  perform zz0-write-err-rpt-line      thru    zz0-99-exit.;
            await zz0_write_err_rpt_line();
            await zz0_99_exit();
        }

        private async Task zb0_99_exit()
        {
            Util.Trakker(++ctr, "zb0_99_exit");

            //     exit.;
        }

        private async Task zz0_write_err_rpt_line()
        {
            Util.Trakker(++ctr, "zz0_write_err_rpt_line");

            //      add ws-carriage-ctrl               to      ctr-lines-printed.;
            ctr_lines_printed += ws_carriage_ctrl;

            //  if ctr-lines-printed > max-lines-per-page  then            
            if (ctr_lines_printed > max_lines_per_page)
            {
                //      perform zz1-print-headings      thru    zz1-99-exit;
                await zz1_print_headings();
                await zz1_99_exit();
                ws_carriage_ctrl = 1;
            }

            // write rpt-line      after advancing ws - carriage - ctrl lines.;
            for (int i = 1; i <= ws_carriage_ctrl - 1; i++)
            {
                objReportFile.print(true);
            }

            objReportFile.print(objRpt_line.Rpt_line1, 1, true);

            objRu701_work_rec.Ru701_doc_nbr = Util.Str(objDoc_mstr_rec.DOC_NBR).PadRight(3);
            objRu701_work_rec.Ru701_clinic_nbr = Util.Str(bt_clinic_nbr_1_2).PadRight(2);
            objRu701_work_rec.Ru701_doc_spec_cd = Util.NumInt(Util.Str(batch_specialty).PadLeft(2, '0'));
            objRu701_work_rec.Ru701_pat_acronym = Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM6).PadRight(6) + Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM3).PadRight(3); // clmhdr_pat_acronym;
            objRu701_work_rec.Ru701_accounting_nbr = Util.Str(hold_accounting_nbr).PadRight(8);
            objRu701_work_rec.Ru701_print_line = Util.Str(objRpt_line.Rpt_line1).PadRight(132);
            objRu701_work_rec.Ru701_orig_rec_no = Util.NumInt(Util.Str(ctr_recs_read).PadLeft(5, '0'));
            objRu701_work_rec.Ru701_acronym_flag = "N";
            objRu701_work_rec.Ru701_acronym = Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM6).PadRight(6) + Util.Str(objSuspend_hdr_rec.CLMHDR_PAT_ACRONYM3).PadRight(3);
            objRu701_work_rec.Ru701_line_no = Util.NumInt(Util.Str(ctr_lines_printed).PadLeft(2, '0'));
            
            string tempValues = Util.Str(objRu701_work_rec.Ru701_doc_nbr).PadRight(3) +
                                Util.Str(objRu701_work_rec.Ru701_clinic_nbr).PadRight(2) +
                                Util.Str(objRu701_work_rec.Ru701_doc_spec_cd).PadLeft(2, '0') +
                                Util.Str(objRu701_work_rec.Ru701_pat_acronym).PadRight(9) +
                                Util.Str(objRu701_work_rec.Ru701_accounting_nbr).PadRight(8) +
                                Util.Str(objRu701_work_rec.Ru701_orig_rec_no).PadLeft(5, '0') +
                                Util.Str(objRu701_work_rec.Ru701_acronym_flag).PadRight(1) +
                                Util.Str(objRu701_work_rec.Ru701_page_area).PadRight(1) +
                                Util.Str(objRu701_work_rec.Ru701_acronym).PadRight(9) +
                                Util.Str(objRu701_work_rec.Ru701_line_no).PadLeft(2, '0') +
                                Util.Str(objRu701_work_rec.Ru701_print_line).PadRight(132);

            //     write ru701-work-rec.;
            objRu701_Work_File.AppendOutputFile(tempValues);  //
        }

        private async Task zz0_99_exit()
        {
            Util.Trakker(++ctr, "zz0_99_exit");

            //     exit.;
        }

        private async Task zz1_print_headings()
        {
            Util.Trakker(++ctr, "zz1_print_headings");

            save_prt_line = objRpt_line.Rpt_line1;

            //     add 1                          to   ws-rpt-page-nbr.;
            ws_rpt_page_nbr++;

            rpt_page_nbr = ws_rpt_page_nbr;

            //     write rpt-line from heading-l1 after advancing page.;
            objRpt_line.Rpt_line1 = await heading_l1_grp();
            objReportFile.PageBreak();
            objReportFile.print(objRpt_line.Rpt_line1, 1, true);

            h_l2_doctor_nbr = Util.Str(objDoc_mstr_rec.DOC_NBR);
            h_l2_doctor_initials = Util.Str(objDoc_mstr_rec.DOC_INIT1) + Util.Str(objDoc_mstr_rec.DOC_INIT2) + Util.Str(objDoc_mstr_rec.DOC_INIT3);
            h_l2_doctor_name = Util.Str(objDoc_mstr_rec.DOC_NAME);

            h_l2_clinic = batch_group_nbr;
            h_l2_specialty = Util.Str(batch_specialty);

            //     write rpt-line from heading-l2 after advancing 1 line.;
            objRpt_line.Rpt_line1 = await heading_l2_grp();
            objReportFile.print(objRpt_line.Rpt_line1, 1, true);

            objRpt_line.Rpt_line1 = "";
            //     write rpt-line                 after advancing 2 lines.;
            objReportFile.print(true);
            objReportFile.print(objRpt_line.Rpt_line1, 1, true);

            ctr_lines_printed = 2;
            objRpt_line.Rpt_line1 = save_prt_line;
        }

        private async Task zz1_99_exit()
        {
            Util.Trakker(++ctr, "zz1_99_exit");

            //     exit.;
        }

        private async Task zz3_apply_tech_prof_suff_rules()
        {
            Util.Trakker(++ctr, "zz3_apply_tech_prof_suff_rules");

            // if  ( hold-icc-sec (ss-clmdtl-oma) = "PF" or "DU" or "DR" or "NM" ) and ( hold-oma-suff(ss-clmdtl-oma) = "A" ) and ( not diskette-claim) then            
            if ((Util.Str(hold_icc_sec[ss_tech_prof_suff]).ToUpper() == "PF" || Util.Str(hold_icc_sec[ss_tech_prof_suff]).ToUpper() == "DU" || Util.Str(hold_icc_sec[ss_clmdtl_oma]).ToUpper() == "DR" || Util.Str(hold_icc_sec[ss_tech_prof_suff]).ToUpper() == "NM") && (Util.Str(hold_oma_suff[ss_tech_prof_suff]).ToUpper() == "A") && (!Util.Str(flag_claim_source).Equals(diskette_claim)))
            {
                // 	    if    hold-oma-fee-1(ss-clmdtl-oma , ohip)<> 0 and hold-oma-fee-2(ss-clmdtl-oma , ohip) = 0 then            
                if (hold_oma_fee_1[ss_tech_prof_suff, ohip] != 0 && hold_oma_fee_2[ss_tech_prof_suff, ohip] == 0)
                {
                    flag_tech_prof_suffix_rule = "Y";
                    hold_oma_suff[ss_tech_prof_suff] = "B";
                    //         perform xa0-display-details     thru xa0-99-exit;            
                    await xa0_display_details();
                    await xa0_99_exit();
                }
                // 	    else if    hold-oma-fee-1(ss-clmdtl-oma , ohip) = 0 and hold-oma-fee-2(ss-clmdtl-oma , ohip)<> 0 then            
                else if (hold_oma_fee_1[ss_tech_prof_suff, ohip] == 0 && hold_oma_fee_2[ss_tech_prof_suff, ohip] != 0)
                {
                    flag_tech_prof_suffix_rule = "Y";
                    hold_oma_suff[ss_tech_prof_suff] = "C";
                    //        perform xa0-display-details         thru xa0-99-exit;            
                    await xa0_display_details();
                    await xa0_99_exit();
                }
                // 	    else if    hold-oma-fee-1(ss-clmdtl-oma , ohip)<> 0 and hold-oma-fee-2(ss-clmdtl-oma , ohip)<> 0 then            
                else if (hold_oma_fee_1[ss_tech_prof_suff, ohip] != 0 && hold_oma_fee_2[ss_tech_prof_suff, ohip] != 0)
                {
                    // 	         perform zz6-calc-ss-for-next-dtl	thru   zz6-99-exit;
                    await zz6_calc_ss_for_next_dtl();
                    await zz6_99_exit();
                    // 	         if online-claim then;            
                    if (Util.Str(flag_claim_source).Equals(online_claim))
                    {
                        // 	              if ss-clmdtl-new-dtl > ss-max-nbr-oma-det-rec-allow then
                        if (ss_clmdtl_new_dtl > ss_max_nbr_oma_det_rec_allow)
                        {
                            err_ind = 101;
                            // 		               perform za0-common-error	thru za0-99-exit;
                            await za0_common_error();
                            await za0_99_exit();
                            //hold_oma_rec[ss_tech_prof_suff] = "";
                            await hold_oma_rec_grp_Intialize(ss_tech_prof_suff);
                            hold_sv_nbr_serv[ss_tech_prof_suff] = 0;
                            hold_sv_date_grp[ss_tech_prof_suff] = "0";
                            hold_sv_date_yy[ss_tech_prof_suff] = 0;
                            hold_sv_date_mm[ss_tech_prof_suff] = 0;
                            hold_sv_date_dd[ss_tech_prof_suff] = 0;

                            //hold_sv_nbr_days_conseq[ss_clmdtl_oma,1] = "0";
                            hold_sv_nbr[ss_clmdtl_oma, 1] = 0;
                            hold_sv_day[ss_clmdtl_oma, 1] = "";
                            hold_sv_day_num[ss_clmdtl_oma, 1] = 0;

                            //hold_sv_nbr_days_conseq[ss_clmdtl_oma,2] = 0;            
                            hold_sv_nbr[ss_clmdtl_oma, 2] = 0;
                            hold_sv_day[ss_clmdtl_oma, 2] = "";
                            hold_sv_day_num[ss_clmdtl_oma, 2] = 0;

                            //hold_sv_nbr_days_conseq(ss-clmdtl-oma,3) = 0;            
                            hold_sv_nbr[ss_clmdtl_oma, 3] = 0;
                            hold_sv_day[ss_clmdtl_oma, 3] = "";
                            hold_sv_day_num[ss_clmdtl_oma, 3] = 0;

                            hold_fee_incoming[ss_tech_prof_suff] = 0;
                            hold_fee_oma[ss_tech_prof_suff] = 0;
                            hold_fee_ohip[ss_tech_prof_suff] = 0;
                            hold_priced_tech[ss_tech_prof_suff] = 0;
                            hold_basic_tech[ss_tech_prof_suff] = 0;
                            hold_basic_prof[ss_tech_prof_suff] = 0;
                            hold_basic_fee[ss_tech_prof_suff] = 0;
                            hold_oma_fees[ss_clmdtl_oma, 1] = "0";
                            hold_oma_fees[ss_clmdtl_oma, 2] = "0";
                            hold_fee_min[ss_clmdtl_oma, 1] = 0;
                            hold_fee_min[ss_clmdtl_oma, 2] = 0;
                            hold_fee_max[ss_clmdtl_oma, 1] = 0;
                            hold_fee_max[ss_clmdtl_oma, 2] = 0;
                            hold_oma_fee_anae[ss_clmdtl_oma, 1] = 0;
                            hold_oma_fee_anae[ss_clmdtl_oma, 2] = 0;
                            hold_oma_fee_asst[ss_clmdtl_oma, 1] = 0;
                            hold_oma_fee_asst[ss_clmdtl_oma, 2] = 0;
                            hold_ss_curr_prev[ss_tech_prof_suff] = 0;
                            hold_flag_sec_group[ss_tech_prof_suff] = "";
                            hold_diag_cd[ss_tech_prof_suff] = 0;
                            hold_line_no[ss_tech_prof_suff] = 0;
                            // 	                   subtract 1		from                 ss-clmdtl-oma;
                            ss_clmdtl_oma--;
                        }
                        else
                        {
                            // 		               perform zz7-split-a-into-b-and-c thru zz7-99-exit;
                            await zz7_split_a_into_b_and_c();
                            await zz7_99_exit();
                            // 		               add hold-sv-nbr-serv (ss_tech_prof_suff) to  nbr-of-services;            
                            nbr_of_services += hold_sv_nbr_serv[ss_tech_prof_suff];
                            // 		               display scr-last-claim-lit;
                            Display("scr-last-claim-lit.");
                            // 		               perform xa0-display-details      thru xa0-99-exit;
                            await xa0_display_details();
                            await xa0_99_exit();
                            // 		               add 1 			     to   ss-clmdtl-oma;
                            ss_clmdtl_oma++;
                            //                     perform xa0-display-details      thru xa0-99-exit;
                            await xa0_display_details();
                            await xa0_99_exit();
                        }
                    }
                    else
                    {
                        // 		          perform zz7-split-a-into-b-and-c     thru zz7-99-exit;
                        await zz7_split_a_into_b_and_c();
                        await zz7_99_exit();
                        // 		          add 1				     to ss-clmdtl-next-avail-dtl.;
                        ss_clmdtl_next_avail_dtl++;
                    }
                }
            }

            //      replacing  ==ss-clmdtl-oma== by ==ss-tech-prof-suff==.;
        }

        private async Task zz3_99_exit()
        {
            Util.Trakker(++ctr, "zz3_99_exit");

            //     exit.;
        }

        // tech_prof_suff_split_part2.rtn
        private async Task zz6_calc_ss_for_next_dtl()
        {
            Util.Trakker(++ctr, "zz6_calc_ss_for_next_dtl");

            //  if    online-claim then    
            if (Util.Str(flag_claim_source).Equals(online_claim))
            {
                // 	       add 1				to     ss-clmdtl-oma;
                // 					giving ss-clmdtl-new-dtl;
                ss_clmdtl_new_dtl = ss_clmdtl_oma + 1;
            }
            else
            {
                // 	     add 1	to     ss-clmdtl-next-avail-dtl;
                // 					giving ss-clmdtl-new-dtl.;
                ss_clmdtl_new_dtl = ss_clmdtl_next_avail_dtl + 1;
            }
        }

        // tech_prof_suff_split_part2.rtn
        private async Task zz6_99_exit()
        {
            Util.Trakker(++ctr, "zz6_99_exit");

            //     exit.;
        }

        // tech_prof_suff_split_part2.rtn
        private async Task zz7_split_a_into_b_and_c()
        {
            Util.Trakker(++ctr, "zz7_split_a_into_b_and_c");

            flag_tech_prof_suffix_rule = "Y";

            hold_oma_suff[ss_tech_prof_suff] = "B";

            //hold_oma_rec[ss_clmdtl_new_dtl] = hold_oma_rec[ss_clmdtl_oma];
            await hold_oma_rec_grp_set(ss_clmdtl_new_dtl, await hold_oma_rec_grp(ss_tech_prof_suff));

            hold_oma_suff[ss_clmdtl_new_dtl] = "C";
            hold_line_no[ss_clmdtl_new_dtl] = ss_clmdtl_new_dtl;
        }

        // tech_prof_suff_split_part2.rtn
        private async Task zz7_99_exit()
        {
            Util.Trakker(++ctr, "zz7_99_exit");

            //     exit.;
            //      replacing  ==ss-clmdtl-oma== by ==ss-tech-prof-suff==.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {
            Util.Trakker(++ctr, "y2k_default_sysdate");

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            // add 20000000                        to sys_date_numeric;
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            Util.Trakker(++ctr, "y2k_default_sysdate_exit");

            //     exit.;
        }

        // pricing_test_min_max_limits.rtn
        private async Task test_min_max_limits()
        {
            Util.Trakker(++ctr, "test_min_max_limits");

            // if  hold-fee-min    (ss, oma) <> 0 and hold-fee-oma (ss)  <  hold-fee-min(ss, oma)  and hold-sv-day (ss,1) <> "OP" and hold-oma-suff(ss)   = "A" then  
            if (hold_fee_min[ss, oma] != 0 && hold_fee_oma[ss] < hold_fee_min[ss, oma] && Util.Str(hold_sv_day[ss, 1]).ToUpper() != "OP" && Util.Str(hold_oma_suff[ss]).ToUpper() == "A")
            {
                hold_fee_oma[ss] = hold_fee_min[ss, oma]*10;
            }

            //  if  hold-fee-min    (ss,ohip) <> 0 and hold-fee-ohip(ss) <  hold-fee-min(ss,ohip) and hold-sv-day(ss,1) <> "OP" and hold-oma-suff(ss)   = "A"  then            
            if (hold_fee_min[ss, ohip] != 0 && hold_fee_ohip[ss] < hold_fee_min[ss, ohip] && Util.Str(hold_sv_day[ss, 1]).ToUpper() != "OP" && Util.Str(hold_oma_suff[ss]).ToUpper() == "A")
            {
                hold_fee_ohip[ss] = hold_fee_min[ss, ohip]*10;
            }

            // if  hold-fee-max    (ss, oma) <> 0 and hold-fee-oma (ss) > hold-fee-max(ss, oma) and hold-sv-day     (ss,1) <> "OP" and hold-oma-suff(ss)   = "A" then            
            if (hold_fee_max[ss, oma] != 0 && hold_fee_oma[ss] > hold_fee_max[ss, oma] && Util.Str(hold_sv_day[ss, 1]).ToUpper() != "OP" && Util.Str(hold_oma_suff[ss]).ToUpper() == "A")
            {
                hold_fee_oma[ss] = hold_fee_max[ss, oma];
            }

            // if  hold-fee-max    (ss,ohip) <> 0  and hold-fee-ohip (ss) > hold-fee-max(ss,ohip) and hold-sv-day     (ss,1) <> "OP"  and hold-oma-suff(ss)   = "A"  then;            
            if (hold_fee_max[ss, ohip] != 0 && hold_fee_ohip[ss] > hold_fee_max[ss, ohip] && Util.Str(hold_sv_day[ss, 1]).ToUpper() != "OP" && Util.Str(hold_oma_suff[ss]).ToUpper() == "A")
            {
                hold_fee_ohip[ss] = hold_fee_max[ss, ohip];
            }
        }

        // pricing_test_min_max_limits.rtn
        private async Task test_min_max_limits_99_exit()
        {
            Util.Trakker(++ctr, "test_min_max_limits_99_exit");

            //     exit.;
        }

        // d001_newu701_oma_code_edit.rtn
        private async Task la4_oma_code_edit()
        {
            Util.Trakker(++ctr, "la4_oma_code_edit");

            // if hold-oma-cd(ss-clmdtl-oma) =   "E078"  then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E078")
            {
                ws_e078_premium = "Y";
            }

            //  if  hold-oma-cd(ss-clmdtl-oma) =   "E020" and  hold-oma-suff(ss-clmdtl-oma) = "C"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E020" && Util.Str(hold_oma_suff[ss_clmdtl_oma]).ToUpper() == "C")
            {
                ws_e020 = "Y";
            }

            //  if (  hold-oma-cd(ss-clmdtl-oma) =   "E022"  or  hold-oma-cd(ss-clmdtl-oma) =   "E017" or  hold-oma-cd(ss-clmdtl-oma) =   "E016"  ) and  hold-oma-suff(ss-clmdtl-oma) = "C"  then            
            if ((await hold_oma_cd_grp(ss_clmdtl_oma) == "E022" || await hold_oma_cd_grp(ss_clmdtl_oma) == "E017" || await hold_oma_cd_grp(ss_clmdtl_oma) == "E016") && Util.Str(hold_oma_suff[ss_clmdtl_oma]) == "C")
            {
                ws_e022_e017_e016 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E719" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E719")
            {
                ws_e719 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "Z570" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z570")
            {
                ws_z570 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E720" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E720")
            {
                ws_e720 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "Z571" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z571")
            {
                ws_z571 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "E717" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E717")
            {
                ws_e717 = "Y";
            }

            //   if    hold-oma-cd(ss-clmdtl-oma) =   "Z580" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z580")
            {
                ws_z555_z580 = "Y";
            }

            //  if  hold-oma-cd(ss-clmdtl-oma) =   "Z555" or (     hold-oma-cd(ss-clmdtl-oma) >=  "Z491"  and  hold-oma-cd(ss-clmdtl-oma) <=  "Z499"  )  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z555" || (Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).CompareTo("Z491") >= 0 && Util.Str(await hold_oma_cd_grp(ss_clmdtl_oma)).CompareTo("Z499") <= 0))
            {
                ws_z491_to_z499 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E702" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E702")
            {
                ws_e702 = "Y";
            }

            //   if    hold-oma-cd(ss-clmdtl-oma) =   "Z515";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z515"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z399";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z399"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z400";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z400"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z561";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z561"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z558";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z558"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z760";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z760"
            //     then;
            )
            {
                ws_z515_z760 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G123" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G123")
            {
                ws_g123 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G228"  then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G228")
            {
                ws_g228 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G223" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G223")
            {
                ws_g223 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G231" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G231")
            {
                ws_g231 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G265" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G265")
            {
                ws_g265 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G264" then    
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G264")
            {
                ws_g264 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G385" then 
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G385")
            {
                ws_g385 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G384" then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G384")
            {
                ws_g384 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G281" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G281")
            {
                ws_g281 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "G381" then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G381")
            {
                ws_g381 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E793" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E793")
            {
                ws_e793 = "Y";
            }

            //     if    hold-oma-cd(ss-clmdtl-oma) =   "R905";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "R905"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S091";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "S091"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S092";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "S092"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S166";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "S166"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S167";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S167"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S169";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "S169"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S171";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "S171"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S798";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "S798"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S799";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S799"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S800";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S800"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S122";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S122"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S123";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S123"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S125";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S125"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S128";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S128"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S120";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "S120"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S134";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S134"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S149";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S149"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S157";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S157"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S165";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S165"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S172";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "S172"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S168";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S168"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S170";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S170"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S189";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S189"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S213";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S213"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S214";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S214"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S215";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S215"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S217";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S217"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S218";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S218"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S113";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S113"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S114";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S114"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "S115";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "S115"
            //     then;
            )
            {
                ws_r905_s800 = "Y";
            }

            //  if  hold-oma-cd-alpha(ss-clmdtl-oma) =   "A"  and  hold-oma-suff    (ss-clmdtl-oma) =   "A"   then            
            if (Util.Str(hold_oma_cd_alpha[ss_clmdtl_oma]).ToUpper() == "A" && Util.Str(hold_oma_suff[ss_clmdtl_oma]).ToUpper() == "A")
            {
                ws_annna = "Y";
            }

            //  if   hold-oma-cd-alpha(ss-clmdtl-oma) =   "G"  and  hold-oma-suff    (ss-clmdtl-oma) =   "A" then       
            if (Util.Str( hold_oma_cd_alpha[ss_clmdtl_oma]).ToUpper() == "G" && Util.Str(hold_oma_suff[ss_clmdtl_oma]).ToUpper() == "A")
            {
                ws_gnnna = "Y";
            }

            //     if   (    hold-oma-cd(ss-clmdtl-oma) =   "K991";
            if ((await hold_oma_cd_grp(ss_clmdtl_oma) == "K991"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "K993";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "K993"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "K995";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "K995"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "K997";
               || await hold_oma_cd_grp(ss_clmdtl_oma) == "K997"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "U991";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "U991"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "U993";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "U993"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "U995";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "U995"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "U997";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "U997"
            // 	 );
                 )
            //        and  hold-oma-suff    (ss-clmdtl-oma) =   "A";
                && hold_oma_suff[ss_clmdtl_oma] == "A"
            //     then;
            )
            {
                ws_k991_u997 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C998" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C998")
            {
                ws_c998 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C999" then      
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C999")
            {
                ws_c999 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E798" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E798")
            {
                ws_e798 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "Z400" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z400")
            {
                ws_z400 = "Y";
            }

            //     if  hold-oma-cd(ss-clmdtl-oma) =   "G400";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G400"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G401";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "G401"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G402";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "G402"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G557";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G557"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G558";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G558"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G559";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "G559"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G405";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "G405"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G406";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "G406"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G407";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "G407"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "E411";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "E411"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "P001";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "P001"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G210";
                    || await hold_oma_cd_grp(ss_clmdtl_oma) == "G210"
            //     then;
            )
            {
                ws_g400_other_codes = "Y";
            }

            //  if   hold-oma-cd(ss-clmdtl-oma) =   "E409" or  hold-oma-cd(ss-clmdtl-oma) =   "E410"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E409" || await hold_oma_cd_grp(ss_clmdtl_oma) == "E410")
            {
                ws_e409_e410 = "Y";
            }

            //  if   hold-oma-cd(ss-clmdtl-oma) =   "G325"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G325")
            {
                ws_g325 = "Y";
            }

            //     if        hold-oma-cd(ss-clmdtl-oma) =   "C990";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C990"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C991";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "C991"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C992";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C992"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C993";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C993"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C994";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C994"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C995";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C995"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C996";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C996"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C997";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C997"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C986";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C986"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C987";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C987"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C960";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C960"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C961";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C961"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C962";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C962"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C963";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C963"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "C964";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C964"
            //      then;
            )
            {
                hold_sv_date_grp[ss_clmdtl_oma] = Util.Str(hold_sv_date_yy[ss_clmdtl_oma]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss_clmdtl_oma]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss_clmdtl_oma]).PadLeft(2,'0');
                ws_sv_date_c1 = Util.NumInt(hold_sv_date_grp[ss_clmdtl_oma]);
                ws_c990_to_c997 = "Y";
            }

            //     if (      hold-oma-cd(ss-clmdtl-oma) <>   "C990";
            if ((await hold_oma_cd_grp(ss_clmdtl_oma) != "C990"
            //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C991";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C991"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C992";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C992"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C993";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C993"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C994";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C994"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C995";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C995"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C996";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C996"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C997";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C997"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>   "C101";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C101"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C986";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C986"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C987";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C987"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C960";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C960"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C961";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C961"
                 //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C962";
                 && await hold_oma_cd_grp(ss_clmdtl_oma) != "C962"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C963";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C963"
                //          and  hold-oma-cd(ss-clmdtl-oma) <>  "C964";
                && await hold_oma_cd_grp(ss_clmdtl_oma) != "C964"
            //        );
                )
            //       and   hold-oma-cd-alpha(ss-clmdtl-oma) =   "C";
                 && Util.Str(hold_oma_cd_alpha[ss_clmdtl_oma]).ToUpper() == "C"
            //     then;
            )
            {
                hold_sv_date_grp[ss_clmdtl_oma] = Util.Str(hold_sv_date_yy[ss_clmdtl_oma]).PadLeft(4,'0') + Util.Str(hold_sv_date_mm[ss_clmdtl_oma]).PadLeft(2,'0') + Util.Str(hold_sv_date_dd[ss_clmdtl_oma]).PadLeft(2,'0');
                ws_sv_date_c2 = Util.NumInt(hold_sv_date_grp[ss_clmdtl_oma]);
                ws_cnnn = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E450" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E450")
            {
                ws_e450 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "J315" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "J315")
            {
                ws_j315 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C985" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C985")
            {
                ws_c985 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G222" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G222")
            {
                ws_g222 = "Y";
            }

            //     if hold-oma-cd(ss-clmdtl-oma) =   "G248";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G248"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G125";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "G125"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G118";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G118"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G062";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G062"
            //     then;
            )
            {
                ws_g248_g062 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "A775" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "A770" || await hold_oma_cd_grp(ss_clmdtl_oma) == "A775" || await hold_oma_cd_grp(ss_clmdtl_oma) == "A075")
            {
                ws_a770_a775 = "Y";
            }

            //  if   hold-oma-cd-num (ss-clmdtl-oma) >= 900;
            hold_oma_cd_num_grp[ss_clmdtl_oma] = Util.Str(hold_oma_cd_num_1[ss_clmdtl_oma]) + Util.Str(hold_oma_cd_num_2[ss_clmdtl_oma]) + Util.Str(hold_oma_cd_num_3[ss_clmdtl_oma]);
            if (Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).CompareTo("900") >= 0
            // 	  and hold-oma-cd-num (ss-clmdtl-oma) <= 999;
                  && Util.Str(hold_oma_cd_num_grp[ss_clmdtl_oma]).CompareTo("999") <= 0
            //           and (    hold-oma-cd-alpha(ss-clmdtl-oma) =   "C";
                  && (Util.Str(hold_oma_cd_alpha[ss_clmdtl_oma]).ToUpper() == "C"
            //                or  hold-oma-cd-alpha(ss-clmdtl-oma) =   "W";
                   || Util.Str(hold_oma_cd_alpha[ss_clmdtl_oma]).ToUpper() == "W"
            //                or  hold-oma-cd-alpha(ss-clmdtl-oma) =   "K";
                   || Util.Str(hold_oma_cd_alpha[ss_clmdtl_oma]).ToUpper() == "K"
            // 	      );
                      )
            //     then;
            )
            {
                ws_X9nn = "Y";
            }

            //  if   hold-oma-cd(ss-clmdtl-oma) =   "H112" or  hold-oma-cd(ss-clmdtl-oma) =   "H113"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "H112" || await hold_oma_cd_grp(ss_clmdtl_oma) == "H113")
            {
                ws_h112_h113 = "Y";
            }

            //  if  hold-oma-cd(ss-clmdtl-oma) =   "G489"  or  hold-oma-cd(ss-clmdtl-oma) =   "S323"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G489" || await hold_oma_cd_grp(ss_clmdtl_oma) == "S323")
            {
                ws_g489_s323 = "Y";
            }

            //    if    hold-oma-cd(ss-clmdtl-oma) =   "G222";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G222"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z804";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z804"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "Z805";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z805"
            //     then;
            )
            {
                ws_g222_z805 = "Y";
            }

            //  if   (    hold-oma-cd(ss-clmdtl-oma) =   "P014";
            if ((await hold_oma_cd_grp(ss_clmdtl_oma) == "P014"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "P016";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "P016"
            // 	 );
                 )
            //       and  hold-oma-suff(ss-clmdtl-oma) = "C";
                && Util.Str(hold_oma_suff[ss_clmdtl_oma]).ToUpper() == "C"
            //     then;
            )
            {
                ws_p014_p016 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "G221" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G221")
            {
                ws_g221 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G220" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G220")
            {
                ws_g220 = "Y";
            }

            // if  hold-oma-cd(ss-clmdtl-oma) =   "S322" or  hold-oma-cd(ss-clmdtl-oma) =   "S326"   then;
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "S322" || await hold_oma_cd_grp(ss_clmdtl_oma) == "S326")
            {
                ws_s322_a198 = "Y";
            }

            //  if  hold-oma-cd(ss-clmdtl-oma) =   "A765";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "A765"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "C765";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "C765"
            //     then;
            )
            {
                ws_a765_c765 = "Y";
            }

            //  if  hold-oma-cd(ss-clmdtl-oma) =   "G521" or  hold-oma-cd(ss-clmdtl-oma) =   "G395"   then
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G521" || await hold_oma_cd_grp(ss_clmdtl_oma) == "G395")
            {
                ws_g521_g395 = "Y";
            }

            //  if    hold-oma-cd(ss-clmdtl-oma) =   "H104";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "H104"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "H134";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "H134"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "H154";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "H154"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "H124";
                   || await hold_oma_cd_grp(ss_clmdtl_oma) == "H124"
            //     then;
            )
            {
                ws_h104_h124 = "Y";
            }

            //  if    hold-oma-cd(ss-clmdtl-oma) =   "G345";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G345"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "G359";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "G359"
            //       or  hold-oma-cd(ss-clmdtl-oma) =   "G381";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G381"
            //     then;
            )
            {
                ws_g345_g339 = "Y";
            }

            //  if   (    hold-oma-cd(ss-clmdtl-oma) =   "G431";
            if ((await hold_oma_cd_grp(ss_clmdtl_oma) == "G431"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G478";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G478"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G479";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G479"
            // 	 );
                 )
            //        and  hold-oma-suff    (ss-clmdtl-oma) =   "C";
               && hold_oma_suff[ss_clmdtl_oma] == "C"
            )
            {
                //     then;
                ws_g431_g479 = "Y";
            }

            //  if      hold-oma-cd-alpha(ss-clmdtl-oma) =   "A" then       
            if (hold_oma_cd_alpha[ss_clmdtl_oma] == "A")
            {
                ws_annn = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C983"  then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C983")
            {
                ws_c983 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "J025" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "J025")
            {
                ws_j025 = "Y";
            }

            //    if hold-oma-cd(ss-clmdtl-oma) =   "J021"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "J021")
            {
                ws_j021 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "J022" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "J022")
            {
                ws_j022 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "Z608"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z608")
            {
                ws_z608 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "Z611"  or hold-oma-cd(ss-clmdtl-oma) =   "Z602"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z611" || await hold_oma_cd_grp(ss_clmdtl_oma) == "Z602")
            {
                ws_z611_z602 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "Z403"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z403")
            {
                ws_z403 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "Z408"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "Z408")
            {
                ws_z408 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "A195"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "A195")
            {
                ws_a195 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K002"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K002")
            {
                ws_k002 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "C122";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C122"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C123";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "C123"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C124";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C124"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C142";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C142"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C143";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C143"
            //     then;
            )
            {
                ws_c122_c143 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "E083" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "E083")
            {
                ws_e083 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C122";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C122"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C123";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "C123"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C124";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "C124"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C142";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "C142"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C143";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "C143"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C882";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "C882"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "C982";
                  || await hold_oma_cd_grp(ss_clmdtl_oma) == "C982"
            //     or (      hold-oma-cd-alpha(ss-clmdtl-oma) = 'C';
                 || (hold_oma_cd_alpha[ss_clmdtl_oma] == "C"
            // 	and  (hold-oma-cd-num-3(ss-clmdtl-oma) = 2 or 7 or 9);
                && (hold_oma_cd_num_3[ss_clmdtl_oma] == 2 || hold_oma_cd_num_3[ss_clmdtl_oma] == 7 || hold_oma_cd_num_3[ss_clmdtl_oma] == 9)
            //        );
                  )
            //     then;
            )
            {
                ws_c122_c982 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G489"  or hold-oma-cd(ss-clmdtl-oma) =   "G482"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G489"
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "G482")
            {
                ws_g489_g376 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "A197"  or hold-oma-cd(ss-clmdtl-oma) =   "A198"  then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "A197" || await hold_oma_cd_grp(ss_clmdtl_oma) == "A198")
            {
                ws_a197_a198 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K189"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K189")
            {
                ws_k189 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "A190";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "A190"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "A195";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "A195"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "A695";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "A695"
            //     or hold-oma-cd(ss-clmdtl-oma) =   "A795";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "A795"
            //     then;
            )
            {
                ws_a190_a795 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K960"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K960")
            {
                ws_k960 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K990" then
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K990")
            {
                ws_k990 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "K961" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K961")
            {
                ws_k961 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K992" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K992")
            {
                ws_k992 = "Y";
            }

            //     if hold-oma-cd(ss-clmdtl-oma) =   "K962"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K962")
            {
                ws_k962 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K994"  then;            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K994")
            {
                ws_k994 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K963" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K963")
            {
                ws_k963 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K998"  then
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K998")
            {
                ws_k998 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "K964"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K964")
            {
                ws_k964 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "K996"  then
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "K996")
            {
                ws_k996 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C960" then 
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C960")
            {
                ws_c960 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C990" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C990")
            {
                ws_c990 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C961" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C961")
            {
                ws_c961 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C992" then
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C992")
            {
                ws_c992 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "C962" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C962")
            {
                ws_c962 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C994"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C994")
            {
                ws_c994 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C963" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C963")
            {
                ws_c963 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C986" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C986")
            {
                ws_c986 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "C964"  then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C964")
            {
                ws_c964 = "Y";
            }

            // if hold-oma-cd(ss-clmdtl-oma) =   "C996" then            
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "C996")
            {
                ws_c996 = "Y";
            }

            //  if hold-oma-cd(ss-clmdtl-oma) =   "G556" then;     
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G556")
            {
                ws_g556 = "Y";
            }

            //     if 	      hold-oma-cd(ss-clmdtl-oma) =   "G400";
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "G400"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G405";
                || await hold_oma_cd_grp(ss_clmdtl_oma) == "G405"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G557";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G557"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G600";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G600"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G603";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G603"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G604";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G604"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G610";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G610"
            //           or  hold-oma-cd(ss-clmdtl-oma) =   "G620";
                 || await hold_oma_cd_grp(ss_clmdtl_oma) == "G620"
            //     then;
            )
            {
                ws_g400_g620 = "Y";
            }

            //   if hold-oma-cd(ss-clmdtl-oma) =   "A120"  then           
            if (await hold_oma_cd_grp(ss_clmdtl_oma) == "A120")
            {
                ws_a120 = "Y";
            }
        }

        // d001_newu701_oma_code_edit.rtn
        private async Task la4_99_exit()
        {
            Util.Trakker(++ctr, "la4_99_exit");

            //    exit.;
        }

        private async Task<string> Err_Message(int option)
        {
            Util.Trakker(++ctr, "Err_Message");

            switch (option)
            {
                case 1:
                    return err_msg[1] = Util.Str(err_warn_msg).PadRight(14) + "Batch = ".PadRight(8) + Util.Str(err_msg_pract_nbr).PadLeft(6, '0') + "/" + Util.Str(err_msg_account_id).PadRight(8) + new string(' ', 95);
                case 2:
                    return err_msg[2] = new string(' ', 14) + "**ERROR** - NO SUCH DOCTOR FOUND ON FILE - ".PadRight(43) + Util.Str(err_msg_doc_nbr).PadRight(3) + new string(' ', 72);
                case 3:
                    return err_msg[3] = new string(' ', 14) + "INVALID LOCATION CODE FOR DOCTOR: BATCH CONTAINED LOCATION - ".PadRight(61) + Util.Str(err_msg_loc_cd).PadRight(4) + new string(' ', 53);
                case 4:
                    return err_msg[4] = new string(' ', 14) + "INVALID SPECIALITY CODE: BATCH CONTAINED SPECIALITY - ".PadRight(54) + Util.Str(err_msg_batch_spec_cd).PadRight(4) + new string(' ', 60);
                case 5:
                    return err_msg[5] = new string(' ', 14) + "                         DOCTOR'S  SPECIALTIES ARE - ".PadRight(53) + Util.Str(err_msg_doc_spec_cd).PadRight(4) + " / " + Util.Str(err_msg_doc_spec_cd_2).PadRight(4) + " / " + Util.Str(err_msg_doc_spec_cd_3).PadRight(4) + new string(' ', 47);
                case 6:
                    return err_msg[6] = new string(' ', 14) + "**ERROR** - INVALID CLINIC ID: BATCH CONTAINED CLINIC - ".PadRight(56) + Util.Str(err_msg_clinic_id).PadRight(10) + new string(' ', 52);
                case 7:
                    return err_msg[7] = "**ERROR** - FIRST RECORD FOUND IN FILE WAS NOT A 'B'ATCH RECORD ".PadRight(132);
                case 8:
                    return err_msg[8] = new string(' ', 14) + "INVALID OMA CODE - ACCOUNTING NBR = ".PadRight(40) + Util.Str(err_accounting_nbr).PadRight(10) + new string(' ', 68);
                case 9:
                    return err_msg[9] = "              DUPLICATE ACCOUNT ID FOUND IN SUSPENSE (HEADER) FILE".PadRight(132);
                case 10:
                    return err_msg[10] = new string(' ', 14) + "INVALID WRITE NEW CLAIMS HDR - 'B' KEY=".PadRight(40) + Util.Str(bkey_clmhdr_err_msg).PadRight(20) + new string(' ', 58);
                case 11:
                    return err_msg[11] = new string(' ', 14) + "INVALID WRITE NEW CLAIMS HDR -'P' KEY = ".PadRight(40) + Util.Str(pkey_clm_err_msg).PadRight(20) + new string(' ', 58);
                case 12:
                    return err_msg[12] = new string(' ', 14) + "INVALID REFERRING PHYSICIAN: BATCH CONTAINED CLINIC - ".PadRight(54) + Util.Str(err_refer_phys_nbr).PadRight(6) + new string(' ', 58);
                case 13:
                    return err_msg[13] = new string(' ', 14) + "INVALID PATIENT OHIP NBR: BATCH CONTAINED CLINIC - ".PadRight(51) + Util.Str(err_ohip_no).PadRight(8) + new string(' ', 59);
                case 14:
                    return err_msg[14] = new string(' ', 14) + "INVALID DIAG CODE: ".PadRight(51) + Util.Str(err_diag_code).PadRight(3) + new string(' ', 64);
                case 15:
                    return err_msg[15] = new string(' ', 14) + "INVALID I-O-INDICATOR: ".PadRight(51) + Util.Str(err_i_o_ind).PadRight(1) + new string(' ', 66);
                case 16:
                    return err_msg[16] = new string(' ', 14) + "NBR OF HEADER1 RECORDS READ IS NOT =  NBR OF HEADER1 RECORDS FROM TRAILER RECORD. ".PadRight(92) + Util.Str(err_ctr_h_count).PadLeft(5, '0') + "/" + Util.Str(err_trl_h_count).PadLeft(5, '0') + new string(' ', 15);
                case 17:
                    return err_msg[17] = new string(' ', 14) + "NBR OF ITEM RECORDS READ IS NOT =  NBR OF ITEM RECORDS FROM TRAILER RECORD. ".PadRight(92) + Util.Str(err_ctr_t_count).PadLeft(5, '0') + "/" + Util.Str(err_trl_t_count).PadLeft(5, '0') + new string(' ', 15);
                case 18:
                    return err_msg[18] = new string(' ', 14) + "NBR OF ADDRESS RECORDS IS NOT =  NBR OF ADDRESS RECORDS FROM TRAILER RECORD.  ".PadRight(92) + Util.Str(err_ctr_a_count).PadLeft(5, '0') + "/" + Util.Str(err_trl_a_count).PadLeft(5, '0') + new string(' ', 15);
                case 19:
                    return err_msg[19] = new string(' ', 14) + "NBR OF BATCH RECORDS READ IS NOT =  NBR OF BATCH RECORDS FROM TRAILER RECORD".PadRight(92) + Util.Str(err_ctr_b_count).PadLeft(5, '0') + "/" + Util.Str(err_trl_b_count).PadLeft(5, '0') + new string(' ', 15);
                case 20:
                    return err_msg[20] = new string(' ', 14) + "INVALID AGENT CODE:    ".PadRight(51) + Util.Str(err_agent_cd).PadRight(1) + new string(' ', 66);
                case 21:
                    return err_msg[21] = new string(' ', 14) + "DOCTOR SPECIALITY: ".PadRight(20) + Util.Str(err_21_value_1).PadRight(2) + "  NOT VALID FOR OHIP CODE: ".PadRight(27) + Util.Str(err_21_value_2).PadRight(4) + " RANGE: ".PadRight(33) + Util.Str(err_21_value_3).PadLeft(2, '0') + " THRU ".PadRight(6) + Util.Str(err_21_value_4).PadLeft(2, '0') + new string(' ', 22);
                case 22:
                    return err_msg[22] = new string(' ', 14) + "OMA CODE: ".PadRight(10) + Util.Str(err_22_oma_cd).PadRight(4) + "  REQUIRES -  ".PadRight(14) + Util.Str(err_22_msg).PadRight(90);
                case 23:
                    return err_msg[23] = new string(' ', 14) + "INVALID HOSPITAL NBR: ".PadRight(51) + Util.Str(err_hosp_nbr).PadRight(4) + new string(' ', 63);
                case 24:
                    return err_msg[24] = new string(' ', 14) + "SERVICE NOT WITHIN 231 days OF SYSTEM DATE:".PadRight(45) + Util.Str(err_24_service_date).PadRight(8) + new string(' ', 65);
                case 25:
                    return err_msg[25] = new string(' ', 14) + "DIRECT BILL CLAIM MISSING - MSG / AUTO LOGOUT / FEE COMPLEXITY / ... INFO".PadRight(118);
                case 26:
                    return err_msg[26] = new string(' ', 14) + "INVALID -ADMIT- DATE: ".PadRight(22) + Util.Str(err_admit_date).PadRight(8) + new string(' ', 88);
                case 27:
                    return err_msg[27] = new string(' ', 14) + "INVALID INITIAL SERVICE DATE:".PadRight(32) + Util.Str(err_27_service_date).PadRight(8) + new string(' ', 78);
                case 28:
                    return err_msg[28] = new string(' ', 14) + "INVALID CONSECUTIVE SERVICES DATES/SVC'S:".PadRight(42) + Util.Str(err_additional_servs).PadRight(9) + new string(' ', 67);
                case 29:
                    return err_msg[29] = new string(' ', 14) + "INVALID HEALTH CARE NBR:".PadRight(25) + Util.Str(err_health_care_nbr).PadRight(10) + new string(' ', 83);
                case 30:
                    return err_msg[30] = new string(' ', 14) + "INVALID PROVINCE:".PadRight(18) + Util.Str(err_province).PadRight(2) + new string(' ', 98);
                case 31:
                    return err_msg[31] = new string(' ', 14) + "INVALID MANUAL REVIEW: ".PadRight(27) + Util.Str(err_manual_review).PadRight(1) + new string(' ', 90);
                case 32:
                    return err_msg[32] = new string(' ', 14) + "INVALID DEPT NO:  BATCH CONTAINED DEPT NO - ".PadRight(54) + Util.Str(err_msg_batch_dept_no).PadRight(2) + new string(' ', 62);
                case 33:
                    return err_msg[33] = new string(' ', 14) + "                  DOCTOR'S DEPT NO          - ".PadRight(53) + Util.Str(err_msg_doc_dept_no).PadRight(2) + new string(' ', 63);
                case 34:
                    return err_msg[34] = new string(' ', 14) + "NBR OF HEADER2 RECORDS READ IS NOT =  NBR OF HEADER2 RECORDS FROM TRAILER RECORD.  ".PadRight(92) + Util.Str(err_ctr_r_count).PadLeft(5, '0') + "/" + Util.Str(err_trl_r_count).PadLeft(5, '0') + new string(' ', 15);
                case 35:
                    return err_msg[35] = new string(' ', 14) + "INVALID PROVIDER NO:  BATCH CONTAINED PROVIDER NO - ".PadRight(53) + Util.Str(err_msg_batch_prov_nbr).PadRight(6) + new string(' ', 59);
                case 36:
                    return err_msg[36] = new string(' ', 14) + "                  DOCTOR'S PROVIDER NO      - ".PadRight(53) + Util.Str(err_msg_doc_prov_nbr).PadRight(6) + new string(' ', 59);
                case 37:
                    return err_msg[37] = new string(' ', 14) + "INVALID BIRTH DATE:".PadRight(22) + Util.Str(err_birth_date).PadRight(8) + new string(' ', 88);
                case 38:
                    return err_msg[38] = new string(' ', 14) + "ZERO NUMBER OF SERVICE".PadRight(28) + Util.Str(err_nbr_of_serv).PadRight(4) + new string(' ', 86);
                case 39:
                    return err_msg[39] = new string(' ', 14) + "ZERO AMOUNT BILLED".PadRight(28) + Util.Str(err_fee_billed).PadLeft(12, '0') + new string(' ', 78);
                case 40:
                    return err_msg[40] = new string(' ', 14) + "INVALID SIZE OF HEALTH CARE NBR - Province/Nbr: ".PadRight(48) + Util.Str(err_prov).PadRight(2) + " / ".PadRight(3) + Util.Str(err_ohip_nbr).PadRight(12) + new string(' ', 53);
                case 41:
                    return err_msg[41] = "CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS OF PROBLEM".PadRight(132);
                case 42:
                    return err_msg[42] = "SERIOUS ERROR #10 - UNABLE TO READ CONSTANT MSTR REC #2 ".PadRight(132);
                case 43:
                    return err_msg[43] = new string(' ', 14) + "INVALID GROUP NBR: BATCH CONTAINED GROUP NBR - ".PadRight(53) + Util.Str(err_msg_group_nbr).PadRight(6) + new string(' ', 59);
                case 44:
                    return err_msg[44] = new string(' ', 14) + "SERVICE DATE: ".PadRight(15) + Util.Str(err_44_service_date).PadRight(8) + "IS PRIOR TO ADMIT DATE:".PadRight(27) + Util.Str(err_44_admit_date).PadRight(8) + new string(' ', 60);
                case 45:
                    return err_msg[45] = "SERIOUS ERROR #11 - UNABLE TO READ CONSTANT MSTR REC #1 ".PadRight(132);
                case 46:
                    return err_msg[46] = new string(' ', 14) + "INVALID RELATIONSHIP: ".PadRight(27) + Util.Str(err_relationship).PadRight(1) + new string(' ', 90);
                case 47:
                    return err_msg[47] = new string(' ', 14) + "   REFERRING DOCTOR: - ".PadRight(23) + Util.Str(err_msg_referring_doc).PadLeft(6, '0') + " AND PROVIDER DOCTOR ARE THE SAME: - ".PadRight(37) + Util.Str(err_msg_provider_doc).PadLeft(6, '0') + new string(' ', 46);
                case 48:
                    return err_msg[48] = new string(' ', 14) + "      SERVICE DATE: - ".PadRight(22) + Util.Str(err_msg_svr_date).PadRight(8) + " IS GREATER THAN SYSTEM DATE: - ".PadRight(32) + Util.Str(err_msg_sys_date).PadRight(8) + new string(' ', 48);
                case 49:
                    return err_msg[49] = new string(' ', 10) + "OMA CODE I/O IND: ".PadRight(18) + Util.Str(err_49_oma_cd).PadRight(4) + " DOES NOT MATCH CLMHDR-2 REC I/O IND: ".PadRight(38) + Util.Str(err_49_hdr_cd).PadRight(4) + new string(' ', 58);
                case 50:
                    return err_msg[50] = new string(' ', 12) + " MISSING DETAIL RECORDS FOR CLAIM: ".PadRight(36) + Util.Str(err_no_detail_claim).PadRight(8) + new string(' ', 76);
                case 51:
                    return err_msg[51] = new string(' ', 14) + "INVALID LOCATION CODE: BATCH CONTAINED LOCATION - ".PadRight(61) + Util.Str(err_51_loc_cd).PadRight(4) + new string(' ', 53);
                case 52:
                    return err_msg[52] = new string(' ', 14) + "Incoming fee not = RMA priced fee  ".PadRight(35) + Util.ImpliedDecimalFormat("#0.00", err_52_incoming_fee, 2, 7, false);
                case 53:
                    return err_msg[53] = new string(' ', 14) + "Incoming I/O ind not = RMA I/O ind ".PadRight(40) + Util.Str(err_53_incoming_i_o_ind).PadRight(1) + " / ".PadRight(3) + Util.Str(err_53_i_o_ind).PadRight(1) + new string(' ', 73);
                case 54:
                    return err_msg[54] = new string(' ', 14) + "Require facility number with premium cd ".PadRight(40) + " / " + Util.Str(err_54_prem_code).PadRight(4) + new string(' ', 71);
                case 55:
                    return err_msg[55] = new string(' ', 14) + "Wrong hospital number with premium cd ".PadRight(40) + " / ".PadRight(3) + Util.Str(err_55_hosp_code).PadRight(4) + " / ".PadRight(3) + Util.Str(err_55_prem_code).PadRight(4) + new string(' ', 64);
                case 56:
                    return err_msg[56] = new string(' ', 14) + "Wrong locn cd- must with 112/153/400/250/422/401/055/326/122".PadRight(60) + "/344/111/354/333/777".PadRight(20) + " / ".PadRight(3) + Util.Str(err_56_loc_code).PadRight(4) + " / ".PadRight(3) + Util.Str(err_56_prem_code).PadRight(4) + new string(' ', 24);
                case 57:
                    return err_msg[57] = new string(' ', 14) + "**ERROR** - INVALID CLINIC NBR FOR THE DOCTOR -         ".PadRight(56) + Util.Str(err_msg_doc_clinic).PadLeft(2, '0') + new string(' ', 60);
                case 58:
                    return err_msg[58] = new string(' ', 14) + "ADMIT DATE: ".PadRight(15) + Util.Str(err_58_admit_date).PadRight(8) + "  IS PRIOR TO BIRTH DATE:".PadRight(27) + Util.Str(err_58_birth_date).PadRight(8) + new string(' ', 60);
                case 59:
                    return err_msg[59] = new string(' ', 14) + "Doc Specialty = ".PadRight(17) + Util.Str(err_59_doc_spec).PadLeft(2, '0') + ", Birth date =  ".PadRight(17) + Util.Str(err_59_birth_date).PadRight(8) + "  and age must be >= 60".PadRight(27) + new string(' ', 47);
                case 60:
                    return err_msg[60] = new string(' ', 14) + "Doc Specialty = ".PadRight(17) + Util.Str(err_60_doc_spec).PadLeft(2, '0') + ", Birth date =  ".PadRight(17) + Util.Str(err_60_birth_date).PadRight(8) + "  and age must be >= 65 with diagnostic code 290".PadRight(74);
                case 61:
                    return err_msg[61] = new string(' ', 14) + "Service Date  = ".PadRight(17) + Util.Str(err_61_serv_date).PadRight(8) + ", Birth date =  ".PadRight(17) + Util.Str(err_61_birth_date).PadRight(8) + "  and service date must be > birth date".PadRight(68);
                case 62:
                    return err_msg[62] = new string(' ', 14) + "Location code = ".PadRight(17) + Util.Str(err_62_loc_code).PadRight(4) + ", clinic nbr = ".PadRight(17) + Util.Str(err_62_clinic_nbr).PadLeft(2, '0') + "  and wrong location for clinic 61 - 74".PadRight(78);
                case 63:
                    return err_msg[63] = new string(' ', 14) + "Oma code = E420, check pricing".PadRight(118);
                case 64:
                    return err_msg[64] = new string(' ', 14) + "doc nbr = 049 and oma code = Z425 - take out manual review".PadRight(118);
                case 65:
                    return err_msg[65] = new string(' ', 14) + "check for E078 premium".PadRight(118);
                case 66:
                    return err_msg[66] = new string(' ', 14) + "Check C122".PadRight(118);
                case 67:
                    return err_msg[67] = new string(' ', 14) + "Check C123".PadRight(118);
                case 68:
                    return err_msg[68] = new string(' ', 14) + "Check C124".PadRight(118);
                case 69:
                    return err_msg[69] = new string(' ', 14) + "Check number of services for C suffix code".PadRight(58) + Util.Str(err_oma_cd).PadRight(4) + Util.Str(err_oma_suff).PadRight(1) + " / ".PadRight(3) + Util.Str(err_nbr_serv).PadRight(4) + " / ".PadRight(3) + Util.Str(err_nbr_serv_incoming).PadRight(4) + new string(' ', 38);
                case 70:
                    return err_msg[70] = new string(' ', 14) + "E020C only allowed with E022C, E017C or E016C".PadRight(118);
                case 71:
                    return err_msg[71] = new string(' ', 14) + "E719 only allowed with Z570".PadRight(118);
                case 72:
                    return err_msg[72] = new string(' ', 14) + "E720 only allowed with Z571".PadRight(118);
                case 73:
                    return err_msg[73] = new string(' ', 14) + "E717 only allowed with specific colonsocopy codes".PadRight(118);
                case 74:
                    return err_msg[74] = new string(' ', 14) + "E702 only allowed with specific codes".PadRight(118);
                case 75:
                    return err_msg[75] = new string(' ', 14) + "G123 only allowed with G228".PadRight(118);
                case 76:
                    return err_msg[76] = new string(' ', 14) + "G223 only allowed with G231".PadRight(118);
                case 77:
                    return err_msg[77] = new string(' ', 14) + "G265 only allowed with G264".PadRight(118);
                case 78:
                    return err_msg[78] = new string(' ', 14) + "G385 only allowed with G384".PadRight(118);
                case 79:
                    return err_msg[79] = new string(' ', 14) + "G281 only allowed with G381".PadRight(118);
                case 80:
                    return err_msg[80] = new string(' ', 14) + "Maximum number of services exceeded".PadRight(118);
                case 81:
                    return err_msg[81] = new string(' ', 14) + "E793 only allowed with specific procedures".PadRight(118);
                case 82:
                    return err_msg[82] = new string(' ', 14) + "P022 deleted as of 2008/02/01".PadRight(118);
                case 83:
                    return err_msg[83] = new string(' ', 14) + "K120 deleted as of 2008/02/01".PadRight(118);
                case 84:
                    return err_msg[84] = new string(' ', 14) + "A007 not allowed  for specialty '26'".PadRight(118);
                case 85:
                    return err_msg[85] = new string(' ', 14) + "Check fee and services of E400".PadRight(118);
                case 86:
                    return err_msg[86] = new string(' ', 14) + "Check fee and services of E401".PadRight(118);
                case 87:
                    return err_msg[87] = new string(' ', 14) + "E798 allowed only with  Z400".PadRight(118);
                case 88:
                    return err_msg[88] = new string(' ', 14) + "Check fee of E409/E410".PadRight(118);
                case 89:
                    return err_msg[89] = new string(' ', 14) + "Use General Listing code with special visit premium".PadRight(118);
                case 90:
                    return err_msg[90] = new string(' ', 14) + "E450 may only be billed with J315".PadRight(118);
                case 91:
                    return err_msg[91] = new string(' ', 14) + "G222 not allowed with G248, G125, G118 or G062".PadRight(118);
                case 92:
                    return err_msg[92] = new string(' ', 14) + "A770 or A775 or A075 not allowed with special visit premium".PadRight(118);
                case 93:
                    return err_msg[93] = new string(' ', 14) + "Z432C deleted as of 2009/10/01".PadRight(118);
                case 94:
                    return err_msg[94] = new string(' ', 14) + "H112 / H113 not allowed with another 'H' code".PadRight(118);
                case 95:
                    return err_msg[95] = new string(' ', 14) + "Patient is underage for G489 / S323".PadRight(118);
                case 96:
                    return err_msg[96] = new string(' ', 14) + "G222, Z804 or Z805 not allowed with P014C or P016C".PadRight(118);
                case 97:
                    return err_msg[97] = new string(' ', 14) + "H prefixed E.R. codes must be agent 2 or 9 in clinic 22".PadRight(118);
                case 98:
                    return err_msg[98] = new string(' ', 14) + "G221 only allowed with G220".PadRight(118);
                case 99:
                    return err_msg[99] = new string(' ', 14) + "Patient must be under 16 for service".PadRight(118);
                case 100:
                    return err_msg[100] = new string(' ', 14) + "Patient is overage for H267".PadRight(118);
                case 101:
                    return err_msg[101] = new string(' ', 14) + "Reassessment not allowed with resuscitation".PadRight(118);
                case 102:
                    return err_msg[102] = new string(' ', 14) + "Assessment included in chemotherapy code".PadRight(118);
                case 103:
                    return err_msg[103] = new string(' ', 14) + "Check suffix on 'G' code or premium code".PadRight(118);
                case 104:
                    return err_msg[104] = new string(' ', 14) + "Patient must be 16 and under".PadRight(118);
                case 105:
                    return err_msg[105] = new string(' ', 14) + "J021 and J022 should be at 50% with J025".PadRight(118);
                case 106:
                    return err_msg[106] = new string(' ', 14) + "Referring doctor must be an optometrist".PadRight(118);
                case 107:
                    return err_msg[107] = new string(' ', 14) + "Referral must be a midwife".PadRight(118);
                case 108:
                    return err_msg[108] = new string(' ', 14) + "Referring doctor cannot be an optometrist".PadRight(118);
                case 109:
                    return err_msg[109] = new string(' ', 14) + "Z611 or Z602 not allowed with Z608".PadRight(118);
                case 110:
                    return err_msg[110] = new string(' ', 14) + "Z176 or Z154 must have manual review".PadRight(118);
                case 111:
                    return err_msg[111] = new string(' ', 14) + "Z175 - Z192 must have manual review".PadRight(118);
                case 112:
                    return err_msg[112] = new string(' ', 14) + "Z403 with Z408 must have manual review".PadRight(118);
                case 113:
                    return err_msg[113] = new string(' ', 14) + "A195 with K002 requires manual review with times of each service".PadRight(118);
                case 114:
                    return err_msg[114] = new string(' ', 14) + "Add E083 to MRP code".PadRight(118);
                case 115:
                    return err_msg[115] = new string(' ', 14) + "E083 only allowed with specific codes".PadRight(118);
                case 116:
                    return err_msg[116] = new string(' ', 14) + "Clarification required to add J021".PadRight(118);
                case 117:
                    return err_msg[117] = new string(' ', 14) + "Echo needs admit date for in-patient".PadRight(118);
                case 118:
                    return err_msg[118] = new string(' ', 14) + "Oma code suffix  / SLI  does not have admit date".PadRight(118);
                case 119:
                    return err_msg[119] = new string(' ', 14) + "Oma code suffix  / SLI  does not require admit date".PadRight(118);
                case 120:
                    return err_msg[120] = new string(' ', 14) + "Patient is overage for service".PadRight(118);
                case 121:
                    return err_msg[121] = new string(' ', 14) + "K189 only allowed with specific codes".PadRight(118);
                case 122:
                    return err_msg[122] = new string(' ', 14) + "Travel Premium billed incorrectly".PadRight(118);
                case 123:
                    return err_msg[123] = new string(' ', 14) + "Check fee and services for E676B".PadRight(118);
                case 124:
                    return err_msg[124] = new string(' ', 14) + "Canot use time units calculator for counselling".PadRight(118);
                case 125:
                    return err_msg[125] = new string(' ', 14) + "G556 only allowed with Day 1 per diem".PadRight(118);
                case 126:
                    return err_msg[126] = new string(' ', 14) + "A120 only allowed with colonscopy codes".PadRight(118);
                case 127:
                    return err_msg[127] = new string(' ', 14) + "Referral cannot be a midwife".PadRight(118);
                case 128:
                    return err_msg[128] = new string(' ', 14) + "DOCTOR HAS BEEN TERMINATED + 6 MONTHS :".PadRight(45) + Util.Str(err_128_term_date).PadRight(8) + new string(' ', 65);
                case 129:
                    return err_msg[129] = new string(' ', 14) + "**FATAL ERROR** - INVALID REC TYPE - RECORD MISALIGNED:  ".PadRight(60) + Util.Str(err_rec_type).PadRight(3) + new string(' ', 55);
                case 130:
                    return err_msg[130] = new string(' ', 14) + "LOCATION Code not currently active for data entry = ".PadRight(60) + Util.Str(err_130_loc_cd).PadRight(4) + new string(' ', 54);
                case 131:
                    return err_msg[131] = new string(' ', 14) + "Services should be 2".PadRight(118);
                case 132:
                    return err_msg[132] = new string(' ', 14) + "E797 allowed with specific colonoscopy codes only".PadRight(118);
                case 133:
                    return err_msg[133] = new string(' ', 14) + "Requires manual review for E414".PadRight(118);
                case 134:
                    return err_msg[134] = new string(' ', 14) + "Check G231/G223/Z228 for bilateral which requires manual revi".PadRight(118);
                case 135:
                    return err_msg[135] = new string(' ', 14) + "Assessment not allowed with P030".PadRight(118);
                case 136:
                    return err_msg[136] = new string(' ', 14) + "A895 cannot be billed alone".PadRight(118);
                case 137:
                    return err_msg[137] = new string(' ', 14) + "Z514 not allowed with Z512".PadRight(118);
                case 138:
                    return err_msg[138] = new string(' ', 14) + "Z580 not allowed with other colonoscopy code".PadRight(118);
                case 139:
                    return err_msg[139] = new string(' ', 14) + "Nerve block count exceeds 8".PadRight(118);
                case 140:
                    return err_msg[140] = new string(' ', 14) + "Use A070 for consultation with special visit premium".PadRight(118);
                case 141:
                    return err_msg[141] = new string(' ', 14) + "Process as bill direct, or change clinic to proper OHIP clini.".PadRight(118);
            }
            return string.Empty;
        }

        private async Task Initialize_Header_Rec()
        {
            Util.Trakker(++ctr, "Initialize_Header_Rec");

            hdr_ohip_nbr_grp = "";
            nf_ohip_nbr = "";
            bc_ns_ohip_nbr_grp = "";
            bc_ns_10_digits = "";
            bc_ns_last_digits = "";
            ab_nb_sk_yt_ohip_nbr_grp = "";
            ab_nb_sk_yt_9_digits = "";
            ab_nb_sk_yt_last_digits = "";
            pe_ohip_nbr_grp = "";
            pe_8_digits = "";
            pe_last_digits = "";
            nt_ohip_nbr_grp = "";
            nt_first_digit = "";
            nt_7_digits = "";
            nt_last_digits = "";
            mb_ohip_nbr_grp = "";
            mb_9_digits = "";
            mb_last_digits = "";
            hdr_surname = "";
            hdr_first_name = "";
            hdr_birth_date_long_grp = "";
            hdr_birth_date = 0;
            hdr_birth_date_dd = 0;
            hdr_sex = "";
            hdr_accounting_nbr = "";
            hdr_refer_pract_nbr = 0;
            hdr_hosp_nbr = "";
            hdr_i_o_ind = "";
            hdr_admit_date_grp = "";
            hdr_admit_yy = "";
            hdr_admit_mm = 0;
            hdr_admit_dd = 0;
            hdr_manual_review = "";
            hdr_health_care_nbr = "";
            hdr_health_care_ver = "";
            hdr_health_care_prov = "";
            hdr_relationship = "";
            hdr_patient_surname = "";
            hdr_subscr_initials = "";
            hdr_agent_cd = "";
            hdr_loc_code_grp = "";
            hdr_loc_alpha = "";
            hdr_loc_nbr = "";
            hdr_direct_key_grp = "";
            hdr_surname_3 = "";
            hdr_birthdate_yymm = 0;
            hdr_birthdate_dd = 0;
        }

        private async Task Initialize_hold_oma_recs()
        {
            Util.Trakker(++ctr, "Initialize_hold_oma_recs");

            // todo...
            hold_oma_recs_grp = "";
            hold_accounting_nbr = "";

            //private string[] hold_oma_rec_grp = new string[91];
            // hold_oma_cd_grp = new string[91];
            hold_oma_cd_alpha = new string[91];
            hold_oma_cd_num_grp = new string[91];
            hold_oma_cd_num_1 = new int[91];
            hold_oma_cd_num_2 = new int[91];
            hold_oma_cd_num_3 = new int[91];
            hold_oma_suff = new string[91];
            hold_sv_nbr_serv_incoming = new int[91];
            hold_sv_nbr_serv = new int[91];
            hold_admit_date_icc_grp = new string[91];
            hold_sv_date_grp = new string[91];
            hold_sv_date_yy = new int[91];
            hold_sv_date_yy_r_grp = new int[91];
            hold_sv_date_yy_12 = new int[91];
            hold_sv_date_yy_34 = new int[91];
            hold_sv_date_mm = new int[91];
            hold_sv_date_dd = new int[91];
            hold_icc_cd_grp = new string[91];
            hold_icc_sec = new string[91];
            hold_icc_grp = new string[91];

            hold_key_r_grp = new string[91];
            //20  filler pic x(6).
            hold_sort_key_1 = new string[91];
            hold_svnbr_days_conseq = new string[91, 4];
            hold_sv_nbr = new int[91, 4];
            hold_sv_day = new string[91, 4];
            hold_sv_day_num = new int[91, 4];      //redefines hold-sv-day pic 99.

            hold_override_price = new string[91];
            hold_bilateral = new string[91];
            hold_fee_incoming = new decimal[91];

            hold_fee_oma = new decimal[91];
            hold_fee_oma_r = new int[91];
            hold_fee_ohip = new decimal[91];
            hold_fee_ohip_r = new int[91];
            hold_priced_tech = new decimal[91];
            hold_basic_tech = new decimal[91];
            hold_basic_prof = new decimal[91];
            hold_basic_fee = new decimal[91];

            hold_oma_rec_ind = new string[91, 9];

            hold_oma_add_on_cd = new string[91, 11];

            hold_oma_ind_card_requireds = new string[91, 4];
            hold_oma_ind_card_required = new string[91, 4];

            hold_oma_fees = new string[91, 3];
            hold_oma_fee_1 = new decimal[91, 3];
            hold_oma_fee_2 = new decimal[91, 3];
            hold_fee_min = new decimal[91, 3];
            hold_fee_max = new decimal[91, 3];
            hold_oma_fee_anae = new int[91, 3];
            hold_oma_fee_asst = new int[91, 3];

            hold_ss_curr_prev = new int[91];

            hold_flag_fee_used = new string[91];

            hold_flag_sec_group = new string[91];
            hold_flag_sec = new int[91];
            hold_flag_grp = new int[91];

            hold_diag_cd = new int[91];
            hold_line_no = new int[91];
        }

        private async Task<string> audit_line_grp(bool isClearValues = false)
        {
            Util.Trakker(++ctr, "audit_line_grp");

            if (isClearValues)
            {
                audit_title = string.Empty;
                audit_value = 0;
                audit_value_2 = 0;
                audit_value_3 = 0;
                audit_value_4 = 0;
                audit_value_5 = 0;

                return string.Empty;
            }
            else
            {
                return new string(' ', 10) +
                       Util.Str(audit_title).PadRight(36) +
                       Util.ImpliedIntegerFormat("#,#", audit_value, 6, false) +
                       new string(' ', 5) +
                       Util.ImpliedIntegerFormat("#,#", audit_value_2, 6, false) +
                       new string(' ', 5) +
                      Util.ImpliedIntegerFormat("#,#", audit_value_3, 6, false) +
                      new string(' ', 5) +
                      Util.ImpliedIntegerFormat("#,#", audit_value_4, 6, false) +
                      new string(' ', 5) +
                      Util.ImpliedDecimalFormat("#,#.##", audit_value_5, 2, 10, false);
            }
        }

        private async Task<string> hold_oma_rec_grp(int row)
        {
            Util.Trakker(++ctr, "hold_oma_rec_grp");

            string tmpRetVal = string.Empty;

            hold_oma_cd_num_grp[row] = Util.Str(hold_oma_cd_num_1[row]).PadLeft(1, '0') + Util.Str(hold_oma_cd_num_2[row]).PadLeft(1, '0') + Util.Str(hold_oma_cd_num_3[row]).PadLeft(1, '0');
            hold_oma_cd_grp_Set(row, Util.Str(hold_oma_cd_alpha[row]).PadRight(1) + hold_oma_cd_num_grp[row]);

            hold_sv_date_grp[row] = Util.Str(hold_sv_date_yy[row]).PadLeft(4, '0') + Util.Str(hold_sv_date_mm[row]).PadLeft(2, '0') + Util.Str(hold_sv_date_dd[row]).PadLeft(2, '0');
            hold_icc_cd_grp[row] = Util.Str(hold_icc_sec[row]).PadRight(2) + Util.Str(hold_icc_grp[row]).PadLeft(2, '0');
            hold_admit_date_icc_grp[row] = hold_sv_date_grp[row] + hold_icc_cd_grp[row];

            // hold_sv_nbr_days_conseq_grp[]
            string hold_sv_nbr_days_conseq_grp = Util.Str(hold_sv_nbr[row, 1]).PadLeft(1, '0') + Util.Str(hold_sv_day[row, 1]).PadRight(2) + Util.Str(hold_sv_nbr[row, 2]).PadLeft(1, '0') + Util.Str(hold_sv_day[row, 2]).PadRight(2) + Util.Str(hold_sv_nbr[row, 3]).PadLeft(1, '0') + Util.Str(hold_sv_day[row, 3]).PadRight(2);

            if ( Util.Str(hold_sv_nbr_serv[row]).Trim().Length > 2)
            {
                hold_sv_nbr_serv[row] = Util.NumInt(Util.Str(hold_sv_nbr_serv[row]).Substring(Util.Str(hold_sv_nbr_serv[row]).Length - 2));
            }

            tmpRetVal = Util.Str(await hold_oma_cd_grp(row)) + 
                        Util.Str(hold_oma_suff[row]).PadRight(1) + 
                        Util.Str(hold_sv_nbr_serv_incoming[row]).PadLeft(2, '0') + 
                        Util.Str(hold_sv_nbr_serv[row]).PadLeft(2, '0') +  //
                        Util.Str(hold_admit_date_icc_grp[row]) + 
                        Util.Str(hold_sv_nbr_days_conseq_grp) +
                        Util.Str(hold_override_price[row]).PadRight(1) +
                        Util.Str(hold_bilateral[row]).PadRight(1) +
                        Util.Str(Util.NumInt(hold_fee_incoming[row]*100)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_fee_oma[row]*100)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_fee_ohip[row]*100)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_priced_tech[row]*100)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_basic_tech[row]*100)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_basic_prof[row]*100)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_basic_fee[row]*100)).PadLeft(7, '0') +
                        Util.Str(hold_oma_rec_ind[row, 1]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 2]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 3]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 4]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 5]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 6]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 7]).PadRight(1) +
                        Util.Str(hold_oma_rec_ind[row, 8]).PadRight(1) +
                        Util.Str(hold_oma_add_on_cd[row, 1]).PadRight(4) +  // x999
                        Util.Str(hold_oma_add_on_cd[row, 2]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 3]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 4]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 5]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 6]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 7]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 8]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 9]).PadRight(4) +
                        Util.Str(hold_oma_add_on_cd[row, 10]).PadRight(4) +
                        Util.Str(hold_oma_ind_card_required[row, 1]).PadRight(1) +
                        Util.Str(hold_oma_ind_card_required[row, 2]).PadRight(1) +
                        Util.Str(hold_oma_ind_card_required[row, 3]).PadRight(1) +
                        Util.Str(Util.NumInt(hold_oma_fee_1[row, 1]*100)).PadLeft(8, '0') +
                        Util.Str(Util.NumInt(hold_oma_fee_2[row, 1]*100)).PadLeft(8, '0') +
                        Util.Str(Util.NumInt(hold_fee_min[row, 1]*1000)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_fee_max[row, 1]*1000)).PadLeft(7, '0') +
                        Util.Str(hold_oma_fee_anae[row, 1]).PadLeft(2, '0') +
                        Util.Str(hold_oma_fee_asst[row, 1]).PadLeft(2, '0') +
                        Util.Str(Util.NumInt(hold_oma_fee_1[row, 2]*100)).PadLeft(8, '0') +
                        Util.Str(Util.NumInt(hold_oma_fee_2[row, 2]*100)).PadLeft(8, '0') +
                        Util.Str(Util.NumInt(hold_fee_min[row, 2]*1000)).PadLeft(7, '0') +
                        Util.Str(Util.NumInt(hold_fee_max[row, 2]*1000)).PadLeft(7, '0') +
                        Util.Str(hold_oma_fee_anae[row, 2]).PadLeft(2, '0') +
                        Util.Str(hold_oma_fee_asst[row, 2]).PadLeft(2, '0') +
                        Util.Str(hold_ss_curr_prev[row]).PadLeft(1, '0') +
                        Util.Str(hold_flag_fee_used[row]).PadRight(1) +
                        Util.Str(hold_flag_sec[row]).PadLeft(1, '0') +
                        Util.Str(hold_flag_grp[row]).PadLeft(1, '0') +
                        Util.Str(hold_diag_cd[row]).PadLeft(3, '0') +
                        Util.Str(hold_line_no[row]).PadLeft(2, '0');

            return tmpRetVal;
        }

        private async Task hold_oma_rec_grp_set(int row, string value)
        {
            Util.Trakker(++ctr, "hold_oma_rec_grp_set");

            hold_oma_cd_alpha[row] = Util.Str(value).PadRight(274).Substring(0, 1);
            hold_oma_cd_num_1[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(1, 1));
            hold_oma_cd_num_2[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(2, 1));
            hold_oma_cd_num_3[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(3, 1));

            hold_oma_suff[row] = Util.Str(value).PadRight(274).Substring(4, 1);
            hold_sv_nbr_serv_incoming[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(5, 2));
            hold_sv_nbr_serv[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(7, 2));

            hold_sv_date_yy[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(9, 4));
            hold_sv_date_yy_r_grp[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(9, 4));
            hold_sv_date_yy_12[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(9, 2));
            hold_sv_date_yy_34[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(11, 2));
            hold_sv_date_mm[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(13, 2));
            hold_sv_date_dd[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(15, 2));

            hold_icc_sec[row] = Util.Str(value).PadRight(274).Substring(17, 2);
            hold_icc_grp[row] = Util.Str(value).PadRight(274).Substring(19, 2);

            hold_key_r_grp[row] = Util.Str(hold_sv_date_dd[row]).PadLeft(2,'0') + Util.Str(hold_icc_sec[row]).PadRight(2) + Util.Str(hold_icc_grp[row]).PadLeft(2,'0');

            hold_sort_key_1[row] = Util.Str(hold_key_r_grp[row]);

            hold_sv_nbr[row, 1] = Util.NumInt(Util.Str(value).PadRight(274).Substring(21, 1));
            hold_sv_day[row, 1] = Util.Str(value).PadRight(274).Substring(22, 2);
            hold_sv_day_num[row, 1] = Util.NumInt(hold_sv_day[row, 1]);

            hold_sv_nbr[row, 2] = Util.NumInt(Util.Str(value).PadRight(274).Substring(24, 1));
            hold_sv_day[row, 2] = Util.Str(value).PadRight(274).Substring(25, 2);
            hold_sv_day_num[row, 2] = Util.NumInt(hold_sv_day[row, 2]);

            hold_sv_nbr[row, 3] = Util.NumInt(Util.Str(value).PadRight(274).Substring(27, 1));
            hold_sv_day[row, 3] = Util.Str(value).PadRight(274).Substring(28, 2);
            hold_sv_day_num[row, 3] = Util.NumInt(hold_sv_day[row, 3]);

            hold_override_price[row] = Util.Str(value).PadRight(274).Substring(30, 1);
            hold_bilateral[row] = Util.Str(value).PadRight(274).Substring(31, 1);
            hold_fee_incoming[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(32, 7))/100;
            hold_fee_oma[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(39, 7))/100;
            hold_fee_oma_r[row] = Util.NumInt(hold_fee_oma[row]*100);

            hold_fee_ohip[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(46, 7))/100;
            hold_fee_ohip_r[row] = Util.NumInt(hold_fee_ohip[row]*100);

            hold_priced_tech[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(53, 7))/100;
            hold_basic_tech[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(60, 7))/100;
            hold_basic_prof[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(67, 7))/100;
            hold_basic_fee[row] = Util.NumDec(Util.Str(value).PadRight(274).Substring(74, 7))/100;

            hold_oma_rec_ind[row, 1] = Util.Str(value).PadRight(274).Substring(81, 1);
            hold_oma_rec_ind[row, 2] = Util.Str(value).PadRight(274).Substring(82, 1);
            hold_oma_rec_ind[row, 3] = Util.Str(value).PadRight(274).Substring(83, 1);
            hold_oma_rec_ind[row, 4] = Util.Str(value).PadRight(274).Substring(84, 1);
            hold_oma_rec_ind[row, 5] = Util.Str(value).PadRight(274).Substring(85, 1);
            hold_oma_rec_ind[row, 6] = Util.Str(value).PadRight(274).Substring(86, 1);
            hold_oma_rec_ind[row, 7] = Util.Str(value).PadRight(274).Substring(87, 1);
            hold_oma_rec_ind[row, 8] = Util.Str(value).PadRight(274).Substring(88, 1);

            hold_oma_add_on_cd[row, 1] = Util.Str(value).PadRight(274).Substring(89, 4);
            hold_oma_add_on_cd[row, 2] = Util.Str(value).PadRight(274).Substring(93, 4);
            hold_oma_add_on_cd[row, 3] = Util.Str(value).PadRight(274).Substring(97, 4);
            hold_oma_add_on_cd[row, 4] = Util.Str(value).PadRight(274).Substring(101, 4);
            hold_oma_add_on_cd[row, 5] = Util.Str(value).PadRight(274).Substring(105, 4);
            hold_oma_add_on_cd[row, 6] = Util.Str(value).PadRight(274).Substring(109, 4);
            hold_oma_add_on_cd[row, 7] = Util.Str(value).PadRight(274).Substring(113, 4);
            hold_oma_add_on_cd[row, 8] = Util.Str(value).PadRight(274).Substring(117, 4);
            hold_oma_add_on_cd[row, 9] = Util.Str(value).PadRight(274).Substring(121, 4);
            hold_oma_add_on_cd[row, 10] = Util.Str(value).PadRight(274).Substring(125, 4);

            hold_oma_ind_card_required[row, 1] = Util.Str(value).PadRight(274).Substring(129, 1);
            hold_oma_ind_card_required[row, 2] = Util.Str(value).PadRight(274).Substring(130, 1);
            hold_oma_ind_card_required[row, 3] = Util.Str(value).PadRight(274).Substring(131, 1);

            hold_oma_fee_1[row, 1] = Util.NumDec(Util.Str(value).PadRight(274).Substring(132, 8))/100;
            hold_oma_fee_2[row, 1] = Util.NumDec(Util.Str(value).PadRight(274).Substring(140, 8))/100;
            hold_fee_min[row, 1] = Util.NumDec(Util.Str(value).PadRight(274).Substring(148, 7))/1000;
            hold_fee_max[row, 1] = Util.NumDec(Util.Str(value).PadRight(274).Substring(155, 7))/1000;
            hold_oma_fee_anae[row, 1] = Util.NumInt(Util.Str(value).PadRight(274).Substring(162, 2));
            hold_oma_fee_asst[row, 1] = Util.NumInt(Util.Str(value).PadRight(274).Substring(164, 2));

            hold_oma_fee_1[row, 2] = Util.NumDec(Util.Str(value).PadRight(274).Substring(166, 8))/100;
            hold_oma_fee_2[row, 2] = Util.NumDec(Util.Str(value).PadRight(274).Substring(174, 8))/100;
            hold_fee_min[row, 2] = Util.NumDec(Util.Str(value).PadRight(274).Substring(182, 7))/1000;
            hold_fee_max[row, 2] = Util.NumDec(Util.Str(value).PadRight(274).Substring(189, 7))/1000;
            hold_oma_fee_anae[row, 2] = Util.NumInt(Util.Str(value).PadRight(274).Substring(196, 2));
            hold_oma_fee_asst[row, 2] = Util.NumInt(Util.Str(value).PadRight(274).Substring(198, 2));

            hold_ss_curr_prev[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(200, 1));
            hold_flag_fee_used[row] = Util.Str(value).PadRight(274).Substring(201, 1);

            hold_flag_sec[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(202, 1));
            hold_flag_grp[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(203, 1));

            hold_diag_cd[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(204, 3));
            hold_line_no[row] = Util.NumInt(Util.Str(value).PadRight(274).Substring(207, 2));

        }

        private async Task hold_oma_rec_grp_Intialize(int row)
        {
            Util.Trakker(++ctr, "hold_oma_rec_grp_Intialize");

            hold_oma_cd_alpha[row] = "";
            hold_oma_cd_num_1[row] = 0;
            hold_oma_cd_num_2[row] = 0;
            hold_oma_cd_num_3[row] = 0;

            hold_oma_suff[row] = "";
            hold_sv_nbr_serv_incoming[row] = 0;
            hold_sv_nbr_serv[row] = 0;

            hold_sv_date_yy[row] = 0;
            hold_sv_date_yy_r_grp[row] = 0;
            hold_sv_date_yy_12[row] = 0;
            hold_sv_date_yy_34[row] = 0;
            hold_sv_date_mm[row] = 0;
            hold_sv_date_dd[row] = 0;

            hold_icc_sec[row] = "";
            hold_icc_grp[row] = "";

            hold_key_r_grp[row] = "";

            hold_sort_key_1[row] = "";

            hold_sv_nbr[row, 1] = 0;
            hold_sv_day[row, 1] = "";
            hold_sv_day_num[row, 1] = 0;

            hold_sv_nbr[row, 2] = 0;
            hold_sv_day[row, 2] = "";
            hold_sv_day_num[row, 2] = 0;

            hold_sv_nbr[row, 3] = 0;
            hold_sv_day[row, 3] = "";
            hold_sv_day_num[row, 3] = 0;

            hold_override_price[row] = "";
            hold_bilateral[row] = "";
            hold_fee_incoming[row] = 0;
            hold_fee_oma[row] = 0;
            hold_fee_oma_r[row] = 0;

            hold_fee_ohip[row] = 0;
            hold_fee_ohip_r[row] = 0;

            hold_priced_tech[row] = 0;
            hold_basic_tech[row] = 0;
            hold_basic_prof[row] = 0;
            hold_basic_fee[row] = 0;

            hold_oma_rec_ind[row, 1] = "";
            hold_oma_rec_ind[row, 2] = "";
            hold_oma_rec_ind[row, 3] = "";
            hold_oma_rec_ind[row, 4] = "";
            hold_oma_rec_ind[row, 5] = "";
            hold_oma_rec_ind[row, 6] = "";
            hold_oma_rec_ind[row, 7] = "";
            hold_oma_rec_ind[row, 8] = "";

            hold_oma_add_on_cd[row, 1] = "";
            hold_oma_add_on_cd[row, 2] = "";
            hold_oma_add_on_cd[row, 3] = "";
            hold_oma_add_on_cd[row, 4] = "";
            hold_oma_add_on_cd[row, 5] = "";
            hold_oma_add_on_cd[row, 6] = "";
            hold_oma_add_on_cd[row, 7] = "";
            hold_oma_add_on_cd[row, 8] = "";
            hold_oma_add_on_cd[row, 9] = "";
            hold_oma_add_on_cd[row, 10] = "";

            hold_oma_ind_card_required[row, 1] = "";
            hold_oma_ind_card_required[row, 2] = "";
            hold_oma_ind_card_required[row, 3] = "";

            hold_oma_fee_1[row, 1] = 0;
            hold_oma_fee_2[row, 1] = 0;
            hold_fee_min[row, 1] = 0;
            hold_fee_max[row, 1] = 0;
            hold_oma_fee_anae[row, 1] = 0;
            hold_oma_fee_asst[row, 1] = 0;

            hold_oma_fee_1[row, 2] = 0;
            hold_oma_fee_2[row, 2] = 0;
            hold_fee_min[row, 2] = 0;
            hold_fee_max[row, 2] = 0;
            hold_oma_fee_anae[row, 2] = 0;
            hold_oma_fee_asst[row, 2] = 0;

            hold_ss_curr_prev[row] = 0;
            hold_flag_fee_used[row] = "";

            hold_flag_sec[row] = 0;
            hold_flag_grp[row] = 0;

            hold_diag_cd[row] = 0;
            hold_line_no[row] = 0;

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

        private async Task<string> audit_line_grp()
        {
            Util.Trakker(++ctr, "audit_line_grp");

            return new string(' ', 10) +
                   Util.Str(audit_title).PadRight(36) +
                   Util.ImpliedIntegerFormat("#,#", audit_value, 6, false) +
                   new string(' ', 5) +
                   Util.ImpliedIntegerFormat("#,#", audit_value_2, 6, false) +
                   new string(' ', 5) +
                   Util.ImpliedIntegerFormat("#,#", audit_value_3, 6, false) +
                   new string(' ', 5) +
                   Util.ImpliedIntegerFormat("#,#", audit_value_4, 6, false) +
                   new string(' ', 5) +
                   Util.BlankWhenZero("#,###.00", audit_value_5, 2, 10, false);
        }

        private async Task<string> hold_basic_times_desc_grp()
        {
            Util.Trakker(++ctr, "hold_basic_times_desc_grp");

            return Util.Str(hold_basic_units[1]).PadRight(3) +
                   Util.Str(hold_basic_b[1]).PadRight(3) +
                   Util.Str(hold_times_units[1]).PadRight(3) +
                   Util.Str(hold_times_t[1]).PadRight(3) +
                   Util.Str(hold_basic_units[2]).PadRight(3) +
                   Util.Str(hold_basic_b[2]).PadRight(3) +
                   Util.Str(hold_times_units[2]).PadRight(3) +
                   Util.Str(hold_times_t[2]).PadRight(3);
        }

        private async Task<string> heading_l1_grp()
        {
            Util.Trakker(++ctr, "heading_l1_grp");

            return "RU701".PadRight(8) +
                    "RUN DATE:".PadRight(10) +
                    Util.Str(l1_run_date).PadRight(10) +
                    new string(' ', 6) +
                    "OHIP Diskette Upload into Suspense - ERROR/WARNING/AUDIT Report".PadRight(66) +
                    "PAGE:".PadRight(6) +
                    Util.ImpliedIntegerFormat("#0", rpt_page_nbr, 4, false);
        }

        private async Task<string> heading_l2_grp()
        {
            Util.Trakker(++ctr, "heading_l2_grp");

            return "DOCTOR: ".PadRight(8) +
                   Util.Str(h_l2_doctor_nbr).PadRight(3) +
                   " / ".PadRight(3) +
                   Util.Str(h_l2_doctor_initials).PadRight(3) +
                   " ".PadRight(1) +
                   Util.Str(h_l2_doctor_name).PadRight(24) +
                   " CLINIC/SPECIALTY: ".PadRight(20) +
                   Util.Str(h_l2_clinic).PadRight(4) +
                   " / ".PadRight(3) +
                   Util.Str(h_l2_specialty).PadLeft(2, '0');
        }

        private async Task<string> hold_oma_cd_grp(int row)
        {
            Util.Trakker(++ctr, "hold_oma_cd_grp");

            hold_oma_cd_num_grp[row] = Util.Str(hold_oma_cd_num_1[row]) + Util.Str(hold_oma_cd_num_2[row]) + Util.Str(hold_oma_cd_num_3[row]);
            return Util.Str(hold_oma_cd_alpha[row]) + Util.Str(hold_oma_cd_num_grp[row]);
        }

        private async Task hold_oma_cd_grp_Set(int row, string value)
        {
            Util.Trakker(++ctr, "hold_oma_cd_grp_Set");

            hold_oma_cd_alpha[row] = Util.Str(value).PadRight(4).Substring(0, 1);
            hold_oma_cd_num_1[row] = Util.NumInt(Util.Str(value).PadRight(4).Substring(1, 1));
            hold_oma_cd_num_2[row] = Util.NumInt(Util.Str(value).PadRight(4).Substring(2, 1));
            hold_oma_cd_num_3[row] = Util.NumInt(Util.Str(value).PadRight(4).Substring(3, 1));
        }

        public async Task destroy_objects()
        {
            Util.Trakker(++ctr, "destroy_objects");

            objUnpriced_claims_record = null;
            Unpriced_claims_record_Collection = null;
            objDiskout_output_rec = null;
            Diskout_output_rec_Collection = null;
            objRu701_work_rec = null;
            Ru701_work_rec_Collection = null;
            objRpt_line = null;
            objReportFile = null;
            objRu701_Work_File = null;
            Rpt_line_Collection = null;
            objSuspend_hdr_rec = null;
            Suspend_hdr_rec_Collection = null;
            objSuspend_dtl_rec = null;
            Suspend_dtl_rec_Collection = null;
            objSuspend_address_rec = null;
            Suspend_address_rec_Collection = null;
            objSuspend_desc_rec = null;
            Suspend_desc_rec_Collection = null;
            objDoc_mstr_rec = null;
            Doc_mstr_rec_Collection = null;
            objLoc_mstr_rec = null;
            Loc_mstr_rec_Collection = null;
            objFee_mstr_rec = null;
            Fee_mstr_rec_Collection = null;
            objF020L_DOC_LOCATIONS = null;
            F020L_DOC_LOCATIONS_Collection = null;
            objIconst_mstr_rec = null;
            Iconst_mstr_rec_Collection = null;
            objConstants_mstr_rec_2 = null;
            Constants_mstr_rec_2_Collection = null;
            objDiag_rec = null;
            Diag_rec_Collection = null;
            objSli_oma_code_suff_rec = null;
            Sli_oma_code_suff_rec_Collection = null;
            objConstants_mstr_rec_1 = null;
            Constants_mstr_rec_1_Collection = null;
        }

        #endregion
    }
}

