using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Suspend_hdr_rec
    {
        	 //01  suspend-hdr-rec.
	 //public  string Suspend_hdr_rec { get; set;}
	 //    05  clmhdr-claim-id.
	 public  string Clmhdr_claim_id { get; set;}
	 //       10  clmhdr-batch-nbr                    pic x(8).
	 public  string Clmhdr_batch_nbr { get; set;}
	 //       10  clmhdr-batch-nbr-r1 redefines clmhdr-batch-nbr.
	 public  string Clmhdr_batch_nbr_r1 { get; set;}
	 //           15  clmhdr-clinic-nbr-1-2           pic 99.
	 public  int Clmhdr_clinic_nbr_1_2 { get; set;}
	 //           15  clmhdr-doc-nbr                  pic x(3).
	 public  string Clmhdr_doc_nbr { get; set;}
	 //           15  clmhdr-week                     pic 99.
	 public  int Clmhdr_week { get; set;}
	 //           15  clmhdr-day                      pic 9.
	 public  int Clmhdr_day { get; set;}
	 //       10  clmhdr-claim-nbr                    pic 9(2).
	 public  int Clmhdr_claim_nbr { get; set;}
	 //       10  clmhdr-zeroed-oma-suff-adj.
	 public  string Clmhdr_zeroed_oma_suff_adj { get; set;}
	 //           15  clmhdr-adj-oma-cd               pic x999.
	 public  string Clmhdr_adj_oma_cd { get; set;}
	 //           15  clmhdr-adj-oma-suff             pic x.
	 public  string Clmhdr_adj_oma_suff { get; set;}
	 //           15  clmhdr-adj-adj-nbr              pic 9.
	 public  int Clmhdr_adj_adj_nbr { get; set;}
	 //    05  clmhdr-batch-type                      pic x.
	 public  string Clmhdr_batch_type { get; set;}
	 //    05  clmhdr-adj-cd-sub-type                 pic x.
	 public  string Clmhdr_adj_cd_sub_type { get; set;}
	 //    05  clmhdr-claim-source-cd    redefines clmhdr-adj-cd-sub-type                                                pic x.
	 public  string Clmhdr_claim_source_cd { get; set;}
	 //    05  clmhdr-doc-nbr-ohip                    pic 9(6).
	 public  int Clmhdr_doc_nbr_ohip { get; set;}
	 //    05  clmhdr-doc-nbr-ohip-alpha redefines         clmhdr-doc-nbr-ohip                    pic x(6).
	 public  string Clmhdr_doc_nbr_ohip_alpha { get; set;}
	 //    05  clmhdr-doc-spec-cd                     pic 9(2).
	 public  int Clmhdr_doc_spec_cd { get; set;}
	 //    05  clmhdr-doc-spec-cd-alpha redefines         clmhdr-doc-spec-cd                     pic x(2).
	 public  string Clmhdr_doc_spec_cd_alpha { get; set;}
	 //    05  clmhdr-refer-doc-nbr                   pic 9(6).
	 public  int Clmhdr_refer_doc_nbr { get; set;}
	 //    05  clmhdr-refer-doc-nbr-alpha redefines         clmhdr-refer-doc-nbr                   pic x(6).
	 public  string Clmhdr_refer_doc_nbr_alpha { get; set;}
	 //    05  clmhdr-diag-cd                         pic 9(3).
	 public  int Clmhdr_diag_cd { get; set;}
	 //    05  clmhdr-diag-cd-alpha redefines         clmhdr-diag-cd                         pic x(3).
	 public  string Clmhdr_diag_cd_alpha { get; set;}
	 //    05  clmhdr-loc                             pic x999.
	 public  string Clmhdr_loc { get; set;}
	 //    05  clmhdr-hosp                            pic x.
	 public  string Clmhdr_hosp { get; set;}
	 //    05  clmhdr-agent-cd                        pic x.
	 public  string Clmhdr_agent_cd { get; set;}
	 //    05  clmhdr-adj-cd                          pic x.
	 public  string Clmhdr_adj_cd { get; set;}
	 //    05  clmhdr-tape-submit-ind                 pic x.
	 public  string Clmhdr_tape_submit_ind { get; set;}
	 //    05  clmhdr-i-o-pat-ind                     pic x.
	 public  string Clmhdr_i_o_pat_ind { get; set;}
	 //    05  clmhdr-pat-ohip-id-or-chart.
	 public  string Clmhdr_pat_ohip_id_or_chart { get; set;}
	 //        10  clmhdr-pat-key-type                pic a.
	 public  string Clmhdr_pat_key_type { get; set;}
	 //        10  clmhdr-pat-key-data.
	 public  string Clmhdr_pat_key_data { get; set;}
	 //            15  clmhdr-pat-key-ohip            pic x(8).
	 public  string Clmhdr_pat_key_ohip { get; set;}
	 //            15  filler                         pic x(7).
	 public  string Filler { get; set;}
	 //    05  clmhdr-pat-acronym.
	 public  string Clmhdr_pat_acronym { get; set;}
	 //        10  clmhdr-pat-acronym6                pic x(6).
	 public  string Clmhdr_pat_acronym6 { get; set;}
	 //        10  clmhdr-pat-acronym3                pic x(3).
	 public  string Clmhdr_pat_acronym3 { get; set;}
	 //    05  clmhdr-reference.
	 public  string Clmhdr_reference { get; set;}
	 //        10  clmhdr-ref1                        pic x.
	 public  string Clmhdr_ref1 { get; set;}
	 //        10  clmhdr-ref2                        pic x.
	 public  string Clmhdr_ref2 { get; set;}
	 //        10  clmhdr-ref3                        pic x.
	 public  string Clmhdr_ref3 { get; set;}
	 //        10  clmhdr-ref4                        pic x.
	 public  string Clmhdr_ref4 { get; set;}
	 //        10  clmhdr-ref5                        pic x.
	 public  string Clmhdr_ref5 { get; set;}
	 //        10  clmhdr-ref6                        pic x.
	 public  string Clmhdr_ref6 { get; set;}
	 //        10  clmhdr-ref7                        pic x.
	 public  string Clmhdr_ref7 { get; set;}
	 //        10  clmhdr-ref8                        pic x.
	 public  string Clmhdr_ref8 { get; set;}
	 //        10  clmhdr-ref9                        pic x.
	 public  string Clmhdr_ref9 { get; set;}
	 //        10  clmhdr-ref10                       pic x.
	 public  string Clmhdr_ref10 { get; set;}
	 //        10  clmhdr-ref11                       pic x.
	 public  string Clmhdr_ref11 { get; set;}
	 //    05  clmhdr-date-admit.
	 public  string Clmhdr_date_admit { get; set;}
	 //        10  clmhdr-date-admit-yy               pic x(4).
	 public  string Clmhdr_date_admit_yy { get; set;}
	 //        10  clmhdr-date-admit-yy-r redefines             clmhdr-date-admit-yy.
	 public  string Clmhdr_date_admit_yy_r { get; set;}
	 //            15 clmhdr-date-admit-yy-12         pic 99.
	 public  int Clmhdr_date_admit_yy_12 { get; set;}
	 //            15 clmhdr-date-admit-yy-34         pic 99.
	 public  int Clmhdr_date_admit_yy_34 { get; set;}
	 //        10  clmhdr-date-admit-mm               pic 99.
	 public  int Clmhdr_date_admit_mm { get; set;}
	 //        10  clmhdr-date-admit-dd               pic 99.
	 public  int Clmhdr_date_admit_dd { get; set;}
	 //    05  clmhdr-doc-dept                        pic 99.
	 public  int Clmhdr_doc_dept { get; set;}
	 //    05  clmhdr-date-cash-tape-payment          pic x(8).
	 public  string Clmhdr_date_cash_tape_payment { get; set;}
	 //    05  clmhdr-direct-bills-clm-info  redefines clmhdr-date-cash-tape-payment.
	 public  string Clmhdr_direct_bills_clm_info { get; set;}
	 //        10  clmhdr-msg-nbr                     pic xx.
	 public  string Clmhdr_msg_nbr { get; set;}
	 //        10  clmhdr-reprint-flag                pic x.
	 public  string Clmhdr_reprint_flag { get; set;}
	 //        10  clmhdr-sub-nbr                     pic x.
	 public  string Clmhdr_sub_nbr { get; set;}
	 //        10  clmhdr-auto-logout                 pic x.
	 public  string Clmhdr_auto_logout { get; set;}
	 //        10  clmhdr-fee-complex                 pic x.
	 public  string Clmhdr_fee_complex { get; set;}
	 //        10  filler                             pic x(2).
	// public  string Filler { get; set;}
	 //    05  clmhdr-curr-payment                    pic s9(5)v99.
	 public  decimal Clmhdr_curr_payment { get; set;}
	 //    05  clmhdr-date-period-end.
	 public  string Clmhdr_date_period_end { get; set;}
	 //        10  clmhdr-period-end-yy               pic 9(4).
	 public  int Clmhdr_period_end_yy { get; set;}
	 //        10  clmhdr-period-end-mm               pic 99.
	 public  int Clmhdr_period_end_mm { get; set;}
	 //        10  clmhdr-period-end-dd               pic 99.
	 public  int Clmhdr_period_end_dd { get; set;}
	 //    05  clmhdr-cycle-nbr                       pic 99.
	 public  int Clmhdr_cycle_nbr { get; set;}
	 //    05  clmhdr-date-sys                        pic x(8).
	 public  string Clmhdr_date_sys { get; set;}
	 //    05  clmhdr-amt-tech-billed                 pic s9(4)v99.
	 public  decimal Clmhdr_amt_tech_billed { get; set;}
	 //    05  clmhdr-amt-tech-paid                   pic s9(4)v99.
	 public  decimal Clmhdr_amt_tech_paid { get; set;}
	 //    05  clmhdr-tot-claim-ar-oma                pic s9(5)v99.
	 public  decimal Clmhdr_tot_claim_ar_oma { get; set;}
	 //    05  clmhdr-tot-claim-ar-ohip               pic s9(5)v99.
	 public  decimal Clmhdr_tot_claim_ar_ohip { get; set;}
	 //    05  clmhdr-manual-tape-payments            pic s9(5)v99.
	 public  decimal Clmhdr_manual_tape_payments { get; set;}
	 //    05  clmhdr-status-ohip                     pic xx.
	 public  string Clmhdr_status_ohip { get; set;}
	 //    05  clmhdr-orig-batch-id                   pic x(10).
	 public  string Clmhdr_orig_batch_id { get; set;}
	 //    05  clmhdr-status                          pic x.
	 public  string Clmhdr_status { get; set;}
	 //    05  clmhdr-health-care-nbr                  pic x(12).
	 public  string Clmhdr_health_care_nbr { get; set;}
	 //    05  clmhdr-health-care-ver                  pic x(02).
	 public  string Clmhdr_health_care_ver { get; set;}
	 //    05  clmhdr-health-care-prov                 pic x(02).
	 public  string Clmhdr_health_care_prov { get; set;}
	 //    05  clmhdr-relationship                     pic x(01).
	 public  string Clmhdr_relationship { get; set;}
	 //    05  clmhdr-manual-review redefines clmhdr-relationship   pic x(01).
	 public  string Clmhdr_manual_review { get; set;}
	 //    05  clmhdr-patient-surname                  pic x(25).
	 public  string Clmhdr_patient_surname { get; set;}
	 //    05  clmhdr-subscr-initials                  pic x(03).
	 public  string Clmhdr_subscr_initials { get; set;}
	 //    05  clmhdr-wcb-claim-nbr                    pic x(09).
	 public  string Clmhdr_wcb_claim_nbr { get; set;}
	 //    05  clmhdr-wcb-accident-date              pic x(08).
	 public  string Clmhdr_wcb_accident_date { get; set;}
	 //    05  clmhdr-wcb-employer-name-addr         pic x(40).
	 public  string Clmhdr_wcb_employer_name_addr { get; set;}
	 //    05  clmhdr-wcb-employer-postal-cd         pic x(06).
	 public  string Clmhdr_wcb_employer_postal_cd { get; set;}
	 //    05  clmhdr-confidential-flag              pic x(1).
	 public  string Clmhdr_confidential_flag { get; set;}
	 //    05  clmhdr-nbr-suspend-desc-recs       pic 9(2).
	 public  int Clmhdr_nbr_suspend_desc_recs { get; set;}
	 //    05  filler                               pic x(1).
	// public  string Filler { get; set;}
	 //    05  suspend-hdr-id.
	 public  string Suspend_hdr_id { get; set;}
	 //        10  clmhdr-doc-pract-nbr              pic 9(6).
	 public  int Clmhdr_doc_pract_nbr { get; set;}
	 //        10  clmhdr-accounting-nbr             pic x(8).
	 public  string Clmhdr_accounting_nbr { get; set;}
	 //    05  suspend-hdr-acr.
	 public  string Suspend_hdr_acr { get; set;}
	 //   10  susp-hdr-doc-nbr   pic x(3).
	 public  string Susp_hdr_doc_nbr { get; set;}
	 // 10  susp-hdr-clinic-nbr   pic 99.
	 public  int Susp_hdr_clinic_nbr { get; set;}
	 // 10  susp-hdr-acronym.
	 public  string Susp_hdr_acronym { get; set;}
	 //     15  susp-hdr-acronym-1-6  pic x(6).
	 public  string Susp_hdr_acronym_1_6 { get; set;}
	 //     15  susp-hdr-acronym-7-9  pic x(3).
	 public  string Susp_hdr_acronym_7_9 { get; set;}
	 // 10  susp-hdr-accounting-nbr  pic x(8).
	 public  string Susp_hdr_accounting_nbr { get; set;}

}
}
