using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Core.Windows.UI;
using rma.Cobol.Includes;
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
    public class U030cViewModel: CommonFunctionScr
    {                
       /* public U030cViewModel(Grid grid):base(grid)
        {           
            base.GridAddControl();
            isBatchProcess = false;
        } */

        public U030cViewModel()
        {
        }

        #region FD Section
        // FD: claims_keys
        private Claims_keys_record objClaims_keys_record = null;
        private ObservableCollection<Claims_keys_record> Claims_keys_record_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private Claims_mstr_rec objClaims_mstr_rec = null;
        private ObservableCollection<Claims_mstr_rec> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private Claims_mstr_dtl_rec objClaims_mstr_dtl_rec = null;
        private ObservableCollection<Claims_mstr_dtl_rec> Claims_mstr_dtl_rec_Collection;

        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int claims_occur;
        private string common_status_file;

        private string status_indicators_grp;
        private string status_cobol_claims_keys_grp;
        private string status_cobol_claims_keys1 = "0";
        private string status_cobol_claims_keys2 = "0";
        private int status_cobol_claims_keys_bin;
        private string status_cobol_claims_mstr_grp;
        private string status_cobol_claims_mstr1 = "0";
        private string status_cobol_claims_mstr2 = "0";
        private int status_cobol_claims_mstr_bin;
        private string status_cobol_display_grp;
        private string status_cobol_display1;
        //private string filler;
        private int status_cobol_display2;
        private string feedback_claims_mstr;
        private string error_flag = "N";
        private string eof_claims_mstr = "N";
        private string eof_claims_keys = "N";
        private string blank_line = "";

        private string counters_grp;
        private int ctr_claims_key_reads;
        private int ctr_claims_mstr_reads;
        private int ctr_nbr_keys_rec_writes;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string filler = "CLAIM NOT FOUND";
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp;
        private string sys_date_long;
        private string sys_date_long_r_grp;
        private int sys_yy;
        private string sys_yy_alpha_grp;
        private int sys_y1;
        private int sys_y2;
        private int sys_y3;
        private int sys_y4;
        private int sys_mm;
        private int sys_dd;
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

        private string claim_header_rec_grp;
        private string clmhdr_claim_id_grp;
        private string clmhdr_batch_nbr;
        private string clmhdr_batch_nbr_r1_grp;
        private int clmhdr_clinic_nbr_1_2;
        private string clmhdr_doc_nbr;
        private string clmhdr_week;
        private string clmhdr_day;
        private string clmhdr_batch_nbr_r2_grp;
        //private string filler;
        private string clmhdr_batch_nbr_3_6;
        private int clmhdr_batch_nbr_7_9;
        private int clmhdr_claim_nbr;
        private string clmhdr_zeroed_oma_suff_adj_grp;
        private string clmhdr_adj_oma_cd;
        private string clmhdr_adj_oma_suff;
        private int clmhdr_adj_adj_nbr;
        private int clmhdr_zeroed_area;
        private string clmhdr_batch_type;
        private string clmhdr_adj_cd_sub_type;
        private int clmhdr_adj_cd_sub_type_ss;
        private string clmhdr_claim_source_cd;
        private int clmhdr_doc_nbr_ohip;
        private int clmhdr_doc_spec_cd;
        private int clmhdr_refer_doc_nbr;
        private int clmhdr_diag_cd;
        private string clmhdr_loc;
        private string clmhdr_hosp;
        private string clmhdr_payroll;
        private int clmhdr_agent_cd;
        private string clmhdr_adj_cd;
        private string clmhdr_tape_submit_ind;
        private string clmhdr_i_o_pat_ind;
        private string clmhdr_pat_ohip_id_or_chart_grp;
        private string clmhdr_pat_key_type;
        private string clmhdr_pat_key_data_grp;
        private string clmhdr_pat_key_ohip;
       // private string filler;
        private string clmhdr_pat_acronym_grp;
        private string clmhdr_pat_acronym6;
        private string clmhdr_pat_acronym3;
        private string clmhdr_reference_grp;
        private string clmhdr_ref1;
        private string clmhdr_ref2;
        private string clmhdr_ref3;
        private string clmhdr_ref4;
        private string clmhdr_ref5;
        private string clmhdr_ref6;
        private string clmhdr_ref7;
        private string clmhdr_ref8;
        private string clmhdr_ref9;
        private string clmhdr_ref10;
        private string clmhdr_ref11;
        private string clmhdr_reference_r_grp;
        private string clmhdr_ref_date1_grp;
        private int clmhdr_ref_date_yy;
        private int clmhdr_ref_date_mm;
        private int clmhdr_ref_date_dd;
        private string clmhdr_ref_inits;
        private string clmhdr_reference_r1_grp;
        //private string filler;
        private string clmhdr_ref_date2;
        //private string filler;
        private string clmhdr_reference_r2_grp;
        //private string filler;
        private string clmhdr_ref_date3;
        //private string filler;
        private string clmhdr_reference_r3_grp;
        //private string filler;
        private string clmhdr_ref_date4;
        private string clmhdr_date_admit_grp;
        private string clmhdr_date_admit_yy;
        private string clmhdr_date_admit_yy_r_grp;
        private string clmhdr_date_admit_yy_12;
        private string clmhdr_date_admit_yy_34;
        private int clmhdr_date_admit_mm;
        private string clmhdr_date_admit_mm_r;
        private int clmhdr_date_admit_dd;
        private string clmhdr_date_admit_dd_r;
        private int clmhdr_date_admit_r;
        private string clmhdr_date_admit_r2_grp;
        private int clmhdr_date_admit_12;
        private int clmhdr_date_admit_38;
        private int clmhdr_doc_dept;
        private string clmhdr_date_cash_tape_payment;
        private string clmhdr_date_cash_tape_paymt_r_grp;
        private int clmhdr_date_cash_tape_paymt_12;
        private int clmhdr_date_cash_tape_paymt_38;
        private string clmhdr_direct_bills_clm_info_grp;
        private string clmhdr_msg_nbr;
        private string clmhdr_reprint_flag;
        private string clmhdr_sub_nbr;
        private string clmhdr_auto_logout;
        private string clmhdr_fee_complex;
        //private string filler;
        private decimal clmhdr_curr_payment;
        private string clmhdr_date_period_end_grp;
        private int clmhdr_period_end_yy;
        private int clmhdr_period_end_mm;
        private int clmhdr_period_end_dd;
        private int clmhdr_cycle_nbr;
        private string clmhdr_date_sys;
        private string clmhdr_date_sys_r_grp;
        private int clmhdr_date_sys_12;
        private int clmhdr_date_sys_38;
        private decimal clmhdr_amt_tech_billed;
        private decimal clmhdr_amt_tech_paid;
        private decimal clmhdr_tot_claim_ar_oma;
        private decimal clmhdr_tot_claim_ar_ohip;
        private decimal clmhdr_manual_and_tape_paymnts;
        private string clmhdr_status_ohip;
        private string clmhdr_manual_review;
        private string clmhdr_submit_date_grp;
        private int clmhdr_submit_yy;
        private int clmhdr_submit_mm;
        private int clmhdr_submit_dd;
        private string clmhdr_confidential_flag;
        private int clmhdr_serv_date;
        private string clmhdr_elig_error;
        private string clmhdr_elig_status;
        private string clmhdr_serv_error;
        private string clmhdr_serv_status;
        private string clmhdr_orig_batch_id_grp;
        private string clmhdr_orig_batch_nbr_grp;
        private int clmhdr_orig_batch_nbr_1_2;
        private string clmhdr_orig_batch_nbr_4_9;
        private string clmhdr_orig_batch_nbr_next_def_grp;
        //private int filler;
        private string clmhdr_orig_batch_nbr_4_6;
        private int clmhdr_orig_batch_nbr_7_8;
        private int clmhdr_orig_batch_nbr_9;
        private int clmhdr_orig_claim_nbr;
        private string clmhdr_orig_batch_id_r_grp;
        private string clmhdr_orig_complete_batch_nbr;
        private string k_clmhdr_claims_mstr_grp;
        private string k_clmhdr_b_key_type;
        private string k_clmhdr_b_data_grp;
        private string k_clmhdr_b_batch_num;
        private string k_clmhdr_b_batch_nbr_grp;
        private int k_clmhdr_b_clinic_nbr_1_2;
        private string k_clmhdr_b_doc_nbr;
        private string k_clmhdr_b_doc_nbr_r_grp;
        private string k_clmhdr_b_doc_nbr_2_4;
        private string k_clmhdr_b_batch_number_grp;
        private int k_clmhdr_b_week;
        private int k_clmhdr_b_day;
        private int k_clmhdr_b_claim_nbr;
        private string k_clmhdr_b_oma_cd;
        private string k_clmhdr_b_oma_suff;
        private string k_clmhdr_b_adj_nbr;
        private string k_clmhdr_b_data_r_grp;
        private string k_clmhdr_b_pat_id;
        //private string filler;
        private string k_clmhdr_p_claims_mstr_grp;
        private string k_clmhdr_p_key_type;
        private string k_clmhdr_p_data_grp;
        private string k_clmhdr_p_batch_nbr_grp;
        private int k_clmhdr_p_clinic_nbr_1_2;
        private string k_clmhdr_p_doc_nbr;
        private int k_clmhdr_p_week;
        private int k_clmhdr_p_day;
        private int k_clmhdr_p_claim_nbr;
        private string k_clmhdr_p_oma_cd;
        private string k_clmhdr_p_oma_suff;
        private string k_clmhdr_p_adj_nbr;

        private string claim_detail_rec_grp;
        private string clmdtl_id_grp;
        private string clmdtl_batch_nbr;
        private int clmdtl_claim_nbr;
        private string clmdtl_oma_cd;
        private string clmdtl_oma_suff;
        private int clmdtl_adj_nbr;
        private string clmdtl_det_rec_grp;
        private string clmdtl_rev_group_cd;
        private int clmdtl_agent_cd;
        private string clmdtl_adj_cd;
        private int clmdtl_nbr_serv;
        private string clmdtl_nbr_serv_r_grp;
        private string clmdtl_adjust_reprint;
        //private string filler;
        private string clmdtl_sv_date_grp;
        private int clmdtl_sv_yy;
        private int clmdtl_sv_mm;
        private int clmdtl_sv_dd;
        private string clmdtl_consec_dates_grp;
        private int[] clmdtl_consecutive_sv_date = new int[4];
        private string clmdtl_consec_dates_r_grp;
        private string[] clmdtl_consecutive_dates = new string[4];
        private int[] clmdtl_sv_nbr = new int[4];
        private string[] clmdtl_sv_day = new string[4];
        private decimal clmdtl_amt_tech_billed;
        private decimal clmdtl_fee_oma;
        private decimal clmdtl_fee_ohip;
        private string clmdtl_date_period_end;
        private int clmdtl_cycle_nbr;
        private int clmdtl_diag_cd;
        private int clmdtl_line_no;
        private string clmdtl_resubmit_flag;
        private string clmdtl_reserve_for_future;
        private string clmdtl_desc_rec_grp;
        private string clmdtl_desc;
        //private string filler;
        private string clmdtl_filler;
        private string clmdtl_orig_batch_id_grp;
        private string clmdtl_orig_batch_nbr;
        private string clmdtl_orig_batch_nbr_r_grp;
        private int clmdtl_orig_batch_nbr_1_2;
        private string clmdtl_orig_batch_nbr_4_9;
        private int clmdtl_orig_claim_nbr_in_batch;
        private string clmdtl_orig_batch_id_r_grp;
        private int clmdtl_orig_complete_batch_nbr;
        private string clmdtl_orig_complete_batch_n_r_grp;
        private int clmdtl_orig_clinic_number;
        private string clmdtl_orig_doc_number;
        private int clmdtl_orig_batch_number;
        private int clmdtl_orig_claim_number;
        private string k_clmdtl_claims_mstr_grp;
        private string k_clmdtl_b_key_type;
        private string k_clmdtl_b_data_grp;
        private string k_clmdtl_b_batch_num;
        private string k_clmdtl_b_batch_nbr_grp;
        private int k_clmdtl_b_clinic_nbr_1_2;
        private string k_clmdtl_b_doc_nbr;
        private string k_clmdtl_b_doc_nbr_r_grp;
        private string k_clmdtl_b_doc_nbr_2_4;
        private string k_clmdtl_b_batch_number_grp;
        private int k_clmdtl_b_week;
        private int k_clmdtl_b_day;
        private int k_clmdtl_b_claim_nbr;
        private string k_clmdtl_b_oma_cd;
        private string k_clmdtl_b_oma_suff;
        private string k_clmdtl_b_adj_nbr;
        private string k_clmdtl_b_data_r_grp;
        private string k_clmdtl_b_pat_id;
        //private string filler;
        private string k_clmdtl_p_claims_mstr_grp;
        private string k_clmdtl_p_key_type;
        private string k_clmdtl_p_data_grp;
        private string k_clmdtl_p_batch_nbr_grp;
        private int k_clmdtl_p_clinic_nbr_1_2;
        private string k_clmdtl_p_doc_nbr;
        private int k_clmdtl_p_week;
        private int k_clmdtl_p_day;
        private int k_clmdtl_p_claim_nbr;
        private string k_clmdtl_p_oma_cd;
        private string k_clmdtl_p_oma_suff;
        private string k_clmdtl_p_adj_nbr;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_claim_header_mstr_file_section()
        {
            //     use after standard error procedure on claims-mstr.;
        }

        private void err_claims_mstr()
        {
            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
            status_cobol_display1 = status_cobol_claims_mstr1;
            //     if   status-cobol-claims-mstr1 <> 9;
            //     then;
            //status_cobol_display2 = status_cobol_claims_mstr2;
            //     else;
            //status_cobol_claims_mstr1 = low_values;
            status_cobol_display2 = status_cobol_claims_mstr_bin;
            //     display "Claims Mstr error = ", status-cobol-display.;
            //     stop run.;
        }

        private void err_claims_keys_file_section()
        {
            //     use after standard error procedure on claims-keys.;
        }

        private void err_claims_keys()
        {
            //     stop "ERROR IN ACCESSING KEYS FILE".;
            // common_status_file = status_cobol_claims_keys;
            //     display common-status-file;
            //     stop run.;
        }
        private void end_declaratives()
        {
        }

        private void mainline_section()
        {

            //     perform aa0-initialization			thru aa0-99-exit.;
            aa0_initialization();
            aa0_99_exit();

            //     perform ab0-processing			thru ab0-99-exit;
            // 		until	eof-claims-keys	= 'Y'.;
            do
            {
                ab0_processing();
                ab0_99_exit();
            }
            while (!eof_claims_keys.Equals("Y"));

           //     perform az0-finalization			thru az0-99-exit.;
                az0_finalization();
                az0_99_exit();

            //     stop run.;
        }

        private void aa0_initialization()
        {

            //     open input 	claims-keys.;
            //     open i-o	claims-mstr.;
            //     perform ya0-read-keys	thru	ya0-99-exit.;
        }

        private void aa0_99_exit()
        {
            //     exit.;
        }
        private void ab0_processing()
        {

            //     perform ya1-read-claims-mstr	thru	ya1-99-exit.;
            ya1_read_claims_mstr();
            ya1_99_exit();

            //     perform xa0-write-inverted-key	thru	xa0-99-exit.;
            xa0_write_inverted_key();
            xa0_99_exit();

            //     perform ya0-read-keys		thru	ya0-99-exit.;
            ya0_read_keys();
            ya0_99_exit();
        }

        private void ab0_99_exit()
        {
            //     exit.;
        }
        private void az0_finalization()
        {
            //     close claims-mstr;
            // 	  claims-keys.;
            //     stop run.;
        }
        private void az0_99_exit()
        {
            //     exit.;
        }
        private void xa0_write_inverted_key()
        {

            k_clmdtl_b_key_type = "B";
            //k_clmdtl_b_data = clmdtl_id;
            k_clmdtl_p_key_type = "Z";
            //k_clmdtl_p_data = clmdtl_id;

            //     write claims-mstr-rec from claim-detail-rec;
            // 	invalid key;
            //             display "ERROR IN WRITE INVERTED - ", key-claims-mstr;
            // 	    stop run.;

            status_cobol_display1 = status_cobol_claims_mstr1;

            //     if   status-cobol-claims-mstr1 <> 9 then            
            //          status_cobol_display2 = status_cobol_claims_mstr2;
            //     else;
            //status_cobol_claims_mstr1 = low_values;
            status_cobol_display2 = status_cobol_claims_mstr_bin;

            //     if status-cobol-claims-mstr1 <> 0 then            
            //         display "Claims Mstr error = ", status-cobol-display.;

            //     add 1				to ctr-nbr-keys-rec-writes.;
        }

        private void xa0_99_exit()
        {
            //     exit.;
        }
        private void ya0_read_keys()
        {
            //     read claims-keys;
            // 	at end move "Y" to eof-claims-keys.;
            //     add 1		to 	ctr-claims-key-reads.;
        }

        private void ya0_99_exit()
        {
            //    exit.;
        }

        private void ya1_read_claims_mstr()
        {
            claims_occur = 0;
            feedback_claims_mstr = "0";

            // 				feedback-claims-mstr.;           

            //objClaims_mstr_dtl_rec.key_claims_mstr = objClaims_keys_record.b_key;

            //     read claims-mstr into claim-detail-rec;    // index
            //         key is key-claims-mstr;
            // 	invalid key;
            //             stop run.;

            //     add 1		to 	ctr-claims-mstr-reads.;
        }

        private void ya1_99_exit()
        {
            //     exit.;
        }

        #endregion
    }
}

