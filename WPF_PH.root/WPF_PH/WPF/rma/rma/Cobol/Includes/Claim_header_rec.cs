using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Claim_header_rec
    {
        	 //01  claim-header-rec.
	// public  string Claim_header_rec { get; set;}
	 //    05  clmhdr-claim-id.
	 public  string Clmhdr_claim_id { get; set;}
	 //        10  clmhdr-batch-nbr                    pic x(8).
	 public  string Clmhdr_batch_nbr { get; set;}
	 //        10  clmhdr-batch-nbr-r1 redefines clmhdr-batch-nbr.
	 public  string Clmhdr_batch_nbr_r1 { get; set;}
	 //            15  clmhdr-clinic-nbr-1-2           pic 99.
	 public  int Clmhdr_clinic_nbr_1_2 { get; set;}
	 //            15  clmhdr-doc-nbr                  pic x(3).
	 public  string Clmhdr_doc_nbr { get; set;}
	 //            15  clmhdr-week                     pic xx.
	 public  string Clmhdr_week { get; set;}
	 //            15  clmhdr-day                      pic x.
	 public  string Clmhdr_day { get; set;}
	 //        10  clmhdr-batch-nbr-r2 redefines clmhdr-batch-nbr.
	 public  string Clmhdr_batch_nbr_r2 { get; set;}
	 //            15  filler                          pic xx.
	 public  string Filler { get; set;}
	 //            15  clmhdr-batch-nbr-3-6            pic x(3).
	 public  string Clmhdr_batch_nbr_3_6 { get; set;}
	 //            15  clmhdr-batch-nbr-7-9            pic 999.
	 public  int Clmhdr_batch_nbr_7_9 { get; set;}
	 //        10  clmhdr-claim-nbr                    pic 9(2).
	 public  int Clmhdr_claim_nbr { get; set;}
	 //        10  clmhdr-zeroed-oma-suff-adj.
	 public  string Clmhdr_zeroed_oma_suff_adj { get; set;}
	 //            15  clmhdr-adj-oma-cd               pic x999.
	 public  string Clmhdr_adj_oma_cd { get; set;}
	 //            15  clmhdr-adj-oma-suff             pic x.
	 public  string Clmhdr_adj_oma_suff { get; set;}
	 //            15  clmhdr-adj-adj-nbr              pic 9.
	 public  int Clmhdr_adj_adj_nbr { get; set;}
	 //    05  clmhdr-batch-type                       pic x.
	 public  string Clmhdr_batch_type { get; set;}
	 //    05  clmhdr-adj-cd-sub-type                  pic x.
	 public  string Clmhdr_adj_cd_sub_type { get; set;}
	 //    05  clmhdr-doc-nbr-ohip                     pic 9(6).
	 public  int Clmhdr_doc_nbr_ohip { get; set;}
	 //    05  clmhdr-doc-spec-cd                      pic 99.
	 public  int Clmhdr_doc_spec_cd { get; set;}
	 //    05  clmhdr-refer-doc-nbr                    pic 9(6).
	 public  int Clmhdr_refer_doc_nbr { get; set;}
	 //    05  clmhdr-diag-cd                          pic 999.
	 public  int Clmhdr_diag_cd { get; set;}
	 //    05  clmhdr-loc                              pic x999.
	 public  string Clmhdr_loc { get; set;}
	 //    05  clmhdr-hosp                             pic x.
	 public  string Clmhdr_hosp { get; set;}
	 //    05  clmhdr-payroll redefines clmhdr-hosp    pic x.
	 public  string Clmhdr_payroll { get; set;}
	 //    05  clmhdr-agent-cd                         pic 9.
	 public  int Clmhdr_agent_cd { get; set;}
	 //    05  clmhdr-adj-cd                           pic x.
	 public  string Clmhdr_adj_cd { get; set;}
	 //    05  clmhdr-tape-submit-ind                  pic x.
	 public  string Clmhdr_tape_submit_ind { get; set;}
	 //    05  clmhdr-i-o-pat-ind                      pic x.
	 public  string Clmhdr_i_o_pat_ind { get; set;}
	 //    05  clmhdr-pat-ohip-id-or-chart.
	 public  string Clmhdr_pat_ohip_id_or_chart { get; set;}
	 //        10  clmhdr-pat-key-type                 pic a.
	 public  string Clmhdr_pat_key_type { get; set;}
	 //        10  clmhdr-pat-key-data.
	 public  string Clmhdr_pat_key_data { get; set;}
	 //            15  clmhdr-pat-key-ohip             pic x(8).
	 public  string Clmhdr_pat_key_ohip { get; set;}
	 //            15  filler                          pic x(7).
	// public  string Filler { get; set;}
	 //    05  clmhdr-pat-acronym.
	 public  string Clmhdr_pat_acronym { get; set;}
	 //        10  clmhdr-pat-acronym6                 pic x(6).
	 public  string Clmhdr_pat_acronym6 { get; set;}
	 //        10  clmhdr-pat-acronym3                 pic x(3).
	 public  string Clmhdr_pat_acronym3 { get; set;}
	 //    05  clmhdr-reference.
	 public  string Clmhdr_reference { get; set;}
	 //        10  clmhdr-ref1                         pic x.
	 public  string Clmhdr_ref1 { get; set;}
	 //        10  clmhdr-ref2                         pic x.
	 public  string Clmhdr_ref2 { get; set;}
	 //        10  clmhdr-ref3                         pic x.
	 public  string Clmhdr_ref3 { get; set;}
	 //        10  clmhdr-ref4                         pic x.
	 public  string Clmhdr_ref4 { get; set;}
	 //        10  clmhdr-ref5                         pic x.
	 public  string Clmhdr_ref5 { get; set;}
	 //        10  clmhdr-ref6                         pic x.
	 public  string Clmhdr_ref6 { get; set;}
	 //        10  clmhdr-ref7                         pic x.
	 public  string Clmhdr_ref7 { get; set;}
	 //        10  clmhdr-ref8                         pic x.
	 public  string Clmhdr_ref8 { get; set;}
	 //        10  clmhdr-ref9                         pic x.
	 public  string Clmhdr_ref9 { get; set;}
	 //        10  clmhdr-ref10                        pic x.
	 public  string Clmhdr_ref10 { get; set;}
	 //        10  clmhdr-ref11                        pic x.
	 public  string Clmhdr_ref11 { get; set;}
	 //    05  clmhdr-reference-r redefines clmhdr-reference.
	 public  string Clmhdr_reference_r { get; set;}
	 //        10  clmhdr-ref-date1.
	 public  string Clmhdr_ref_date1 { get; set;}
	 //            15  clmhdr-ref-date-yy              pic 9(4).
	 public  int Clmhdr_ref_date_yy { get; set;}
	 //            15  clmhdr-ref-date-mm              pic 9(2).
	 public  int Clmhdr_ref_date_mm { get; set;}
	 //            15  clmhdr-ref-date-dd              pic 9(2).
	 public  int Clmhdr_ref_date_dd { get; set;}
	 //        10  clmhdr-ref-inits                    pic x(3).
	 public  string Clmhdr_ref_inits { get; set;}
	 //    05  clmhdr-reference-r1 redefines clmhdr-reference-r.
	 public  string Clmhdr_reference_r1 { get; set;}
	 //        10  filler                              pic x.
	// public  string Filler { get; set;}
	 //        10  clmhdr-ref-date2                    pic x(8).
	 public  string Clmhdr_ref_date2 { get; set;}
	 //        10  filler                              pic x(2).
	// public  string Filler { get; set;}
	 //    05  clmhdr-reference-r2 redefines clmhdr-reference-r1.
	 public  string Clmhdr_reference_r2 { get; set;}
	 //        10  filler                              pic x(2).
	// public  string Filler { get; set;}
	 //        10  clmhdr-ref-date3                    pic x(8).
	 public  string Clmhdr_ref_date3 { get; set;}
	 //        10  filler                              pic x(1).
	 //public  string Filler { get; set;}
	 //    05  clmhdr-reference-r3 redefines clmhdr-reference-r2.
	 public  string Clmhdr_reference_r3 { get; set;}
	 //        10  filler                              pic x(3).
	 //public  string Filler { get; set;}
	 //        10  clmhdr-ref-date4                    pic x(8).
	 public  string Clmhdr_ref_date4 { get; set;}
	 //    05  clmhdr-date-admit.
	 public  string Clmhdr_date_admit { get; set;}
	 //        10  clmhdr-date-admit-yy                pic x(4).
	 public  string Clmhdr_date_admit_yy { get; set;}
	 //     15  clmhdr-date-admit-yy-12  pic xx.
	 public  string Clmhdr_date_admit_yy_12 { get; set;}
	 //     15  clmhdr-date-admit-yy-34  pic xx.
	 public  string Clmhdr_date_admit_yy_34 { get; set;}
	 //        10  clmhdr-date-admit-mm                pic 99.
	 public  int Clmhdr_date_admit_mm { get; set;}
	 //        10  clmhdr-date-admit-dd                pic 99.
	 public  int Clmhdr_date_admit_dd { get; set;}
	 //    05  clmhdr-date-admit-r2 redefines clmhdr-date-admit-r.
	 public  string Clmhdr_date_admit_r2 { get; set;}
	 // 10 clmhdr-date-admit-12   pic 9(2).
	 public  int Clmhdr_date_admit_12 { get; set;}
	 // 10 clmhdr-date-admit-38   pic 9(6).
	 public  int Clmhdr_date_admit_38 { get; set;}
	 //    05  clmhdr-doc-dept                         pic 99.
	 public  int Clmhdr_doc_dept { get; set;}
	 //    05  clmhdr-date-cash-tape-payment           pic x(8).
	 public  string Clmhdr_date_cash_tape_payment { get; set;}
	 // 10  clmhdr-date-cash-tape-paymt-12 pic 9(2).
	 public  int Clmhdr_date_cash_tape_paymt_12 { get; set;}
	 // 10  clmhdr-date-cash-tape-paymt-38 pic 9(6).
	 public  int Clmhdr_date_cash_tape_paymt_38 { get; set;}
	 //    05  clmhdr-direct-bills-clm-info  redefines clmhdr-date-cash-tape-payment.
	 public  string Clmhdr_direct_bills_clm_info { get; set;}
	 //        10  clmhdr-msg-nbr                      pic xx.
	 public  string Clmhdr_msg_nbr { get; set;}
	 //        10  clmhdr-reprint-flag                 pic x.
	 public  string Clmhdr_reprint_flag { get; set;}
	 //        10  clmhdr-sub-nbr                      pic x.
	 public  string Clmhdr_sub_nbr { get; set;}
	 //        10  clmhdr-auto-logout                  pic x.
	 public  string Clmhdr_auto_logout { get; set;}
	 //        10  clmhdr-fee-complex                  pic x.
	 public  string Clmhdr_fee_complex { get; set;}
	 // 10  filler    pic xx.
	// public  string Filler { get; set;}
	 //    05  clmhdr-curr-payment                     pic s9(5)v99.
	 public  decimal Clmhdr_curr_payment { get; set;}
	 //    05  clmhdr-date-period-end.
	 public  string Clmhdr_date_period_end { get; set;}
	 //        10  clmhdr-period-end-yy                pic 9(4).
	 public  int Clmhdr_period_end_yy { get; set;}
	 //        10  clmhdr-period-end-mm                pic 99.
	 public  int Clmhdr_period_end_mm { get; set;}
	 //        10  clmhdr-period-end-dd                pic 99.
	 public  int Clmhdr_period_end_dd { get; set;}
	 //    05  clmhdr-cycle-nbr                        pic 99.
	 public  int Clmhdr_cycle_nbr { get; set;}
	 //    05  clmhdr-date-sys                         pic x(8).
	 public  string Clmhdr_date_sys { get; set;}
	 //    05  clmhdr-date-sys-r redefines clmhdr-date-sys.
	 public  string Clmhdr_date_sys_r { get; set;}
	 // 10  clmhdr-date-sys-12   pic 9(2).
	 public  int Clmhdr_date_sys_12 { get; set;}
	 // 10  clmhdr-date-sys-38   pic 9(6).
	 public  int Clmhdr_date_sys_38 { get; set;}
	 //    05  clmhdr-amt-tech-billed                  pic s9(4)v99.
	 public  decimal Clmhdr_amt_tech_billed { get; set;}
	 //    05  clmhdr-amt-tech-paid                    pic s9(4)v99.
	 public  decimal Clmhdr_amt_tech_paid { get; set;}
	 //    05  clmhdr-tot-claim-ar-oma                 pic s9(5)v99.
	 public  decimal Clmhdr_tot_claim_ar_oma { get; set;}
	 //    05  clmhdr-tot-claim-ar-ohip                pic s9(5)v99.
	 public  decimal Clmhdr_tot_claim_ar_ohip { get; set;}
	 //    05  clmhdr-manual-and-tape-paymnts          pic s9(5)v99.
	 public  decimal Clmhdr_manual_and_tape_paymnts { get; set;}
	 //    05  clmhdr-status-ohip                      pic xx.
	 public  string Clmhdr_status_ohip { get; set;}
	 //    05  clmhdr-manual-review                    pic x.
	 public  string Clmhdr_manual_review { get; set;}
	 //    05  clmhdr-submit-date.
	 public  string Clmhdr_submit_date { get; set;}
	 //        10  clmhdr-submit-yy                    pic 9(4).
	 public  int Clmhdr_submit_yy { get; set;}
	 //        10  clmhdr-submit-mm                    pic 99.
	 public  int Clmhdr_submit_mm { get; set;}
	 //        10  clmhdr-submit-dd                    pic 99.
	 public  int Clmhdr_submit_dd { get; set;}
	 //    05  clmhdr-confidential-flag                pic x.
	 public  string Clmhdr_confidential_flag { get; set;}
	 //    05  clmhdr-serv-date                        pic 9(8).
	 public  int Clmhdr_serv_date { get; set;}
	 //    05  clmhdr-elig-error   pic x(3).
	 public  string Clmhdr_elig_error { get; set;}
	 //    05  clmhdr-elig-status   pic x.
	 public  string Clmhdr_elig_status { get; set;}
	 //    05  clmhdr-serv-error   pic x(3).
	 public  string Clmhdr_serv_error { get; set;}
	 //    05  clmhdr-serv-status   pic x.
	 public  string Clmhdr_serv_status { get; set;}
	 //    05  clmhdr-orig-batch-id.
	 public  string Clmhdr_orig_batch_id { get; set;}
	 //        10  clmhdr-orig-batch-nbr.
	 public  string Clmhdr_orig_batch_nbr { get; set;}
	 //            15  clmhdr-orig-batch-nbr-1-2       pic  99.
	 public  int Clmhdr_orig_batch_nbr_1_2 { get; set;}
	 //            15  clmhdr-orig-batch-nbr-4-9       pic x(6).
	 public  string Clmhdr_orig_batch_nbr_4_9 { get; set;}
	 //        10  clmhdr-orig-batch-nbr-next-def      redefines clmhdr-orig-batch-nbr.
	 public  string Clmhdr_orig_batch_nbr_next_def { get; set;}
	 //            15  filler                          pic  99.
	// public  int Filler { get; set;}
	 //            15  clmhdr-orig-batch-nbr-4-6       pic x(3).
	 public  string Clmhdr_orig_batch_nbr_4_6 { get; set;}
	 //            15  clmhdr-orig-batch-nbr-7-8       pic  99.
	 public  int Clmhdr_orig_batch_nbr_7_8 { get; set;}
	 //            15  clmhdr-orig-batch-nbr-9         pic   9.
	 public  int Clmhdr_orig_batch_nbr_9 { get; set;}
	 //        10  clmhdr-orig-claim-nbr               pic  99.
	 public  int Clmhdr_orig_claim_nbr { get; set;}
	 //    05  clmhdr-orig-batch-id-r  redefines clmhdr-orig-batch-id.
	 public  string Clmhdr_orig_batch_id_r { get; set;}
	 //        10  clmhdr-orig-complete-batch-nbr      pic x(10).
	 public  string Clmhdr_orig_complete_batch_nbr { get; set;}
	 //05  k-clmhdr-claims-mstr.
	 public  string K_clmhdr_claims_mstr { get; set;}
	 //    20  k-clmhdr-b-key-type                        pic x.
	 public  string K_clmhdr_b_key_type { get; set;}
	 //    20  k-clmhdr-b-data.
	 public  string K_clmhdr_b_data { get; set;}
	 //        25  k-clmhdr-b-batch-num                   pic x(8).
	 public  string K_clmhdr_b_batch_num { get; set;}
	 //        25  k-clmhdr-b-batch-nbr redefines k-clmhdr-b-batch-num.
	 public  string K_clmhdr_b_batch_nbr { get; set;}
	 //            30  k-clmhdr-b-clinic-nbr-1-2          pic 99.
	 public  int K_clmhdr_b_clinic_nbr_1_2 { get; set;}
	 //            30  k-clmhdr-b-doc-nbr                 pic x(3).
	 public  string K_clmhdr_b_doc_nbr { get; set;}
	 //            30  k-clmhdr-b-doc-nbr-r redefines k-clmhdr-b-doc-nbr.
	 public  string K_clmhdr_b_doc_nbr_r { get; set;}
	 //                35  k-clmhdr-b-doc-nbr-2-4         pic xxx.
	 public  string K_clmhdr_b_doc_nbr_2_4 { get; set;}
	 //            30  k-clmhdr-b-batch-number.
	 public  string K_clmhdr_b_batch_number { get; set;}
	 //                35  k-clmhdr-b-week                pic 99.
	 public  int K_clmhdr_b_week { get; set;}
	 //                35  k-clmhdr-b-day                 pic 9.
	 public  int K_clmhdr_b_day { get; set;}
	 //        25  k-clmhdr-b-claim-nbr                   pic 99.
	 public  int K_clmhdr_b_claim_nbr { get; set;}
	 //        25  k-clmhdr-b-oma-cd                      pic x999.
	 public  string K_clmhdr_b_oma_cd { get; set;}
	 //        25  k-clmhdr-b-oma-suff                    pic x.
	 public  string K_clmhdr_b_oma_suff { get; set;}
	 //        25  k-clmhdr-b-adj-nbr                     pic x.
	 public  string K_clmhdr_b_adj_nbr { get; set;}
	 //    20  k-clmhdr-b-data-r  redefines  k-clmhdr-b-data.
	 public  string K_clmhdr_b_data_r { get; set;}
	 //        25  k-clmhdr-b-pat-id                      pic x(15).
	 public  string K_clmhdr_b_pat_id { get; set;}
	 //        25  filler                                 pic x.
	// public  string Filler { get; set;}
	 //05  k-clmhdr-p-claims-mstr.
	 public  string K_clmhdr_p_claims_mstr { get; set;}
	 //    20  k-clmhdr-p-key-type                        pic x.
	 public  string K_clmhdr_p_key_type { get; set;}
	 //    20  k-clmhdr-p-data.
	 public  string K_clmhdr_p_data { get; set;}
	 //        25  k-clmhdr-p-batch-nbr.
	 public  string K_clmhdr_p_batch_nbr { get; set;}
	 //            30  k-clmhdr-p-clinic-nbr-1-2      pic  99.
	 public  int K_clmhdr_p_clinic_nbr_1_2 { get; set;}
	 //            30  k-clmhdr-p-doc-nbr             pic x(3).
	 public  string K_clmhdr_p_doc_nbr { get; set;}
	 //            30  k-clmhdr-p-week                pic 99.
	 public  int K_clmhdr_p_week { get; set;}
	 //            30  k-clmhdr-p-day                 pic 9.
	 public  int K_clmhdr_p_day { get; set;}
	 //        25  k-clmhdr-p-claim-nbr               pic 99.
	 public  int K_clmhdr_p_claim_nbr { get; set;}
	 //        25  k-clmhdr-p-oma-cd                  pic x999.
	 public  string K_clmhdr_p_oma_cd { get; set;}
	 //        25  k-clmhdr-p-oma-suff                pic x.
	 public  string K_clmhdr_p_oma_suff { get; set;}
	 //        25  k-clmhdr-p-adj-nbr                 pic x.
	 public  string K_clmhdr_p_adj_nbr { get; set;}

}
}
