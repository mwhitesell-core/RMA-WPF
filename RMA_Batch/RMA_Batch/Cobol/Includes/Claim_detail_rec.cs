using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Claim_detail_rec
    {
        	 //01  claim-detail-rec.
	// public  string Claim_detail_rec { get; set;}
	 //    05  clmdtl-id.
	 public  string Clmdtl_id { get; set;}
	 //        10  clmdtl-batch-nbr                    pic x(8).
	 public  string Clmdtl_batch_nbr { get; set;}
	 //        10  clmdtl-claim-nbr                    pic 9(2).
	 public  int Clmdtl_claim_nbr { get; set;}
	 //        10  clmdtl-oma-cd                       pic xxxx.
	 public  string Clmdtl_oma_cd { get; set;}
	 //        10  clmdtl-oma-suff                     pic x.
	 public  string Clmdtl_oma_suff { get; set;}
	 //        10  clmdtl-adj-nbr                      pic 9.
	 public  int Clmdtl_adj_nbr { get; set;}
	 //    05  clmdtl-det-rec.
	 public  string Clmdtl_det_rec { get; set;}
	 //        10  clmdtl-rev-group-cd                 pic xxx.
	 public  string Clmdtl_rev_group_cd { get; set;}
	 //        10  clmdtl-agent-cd                     pic 9.
	 public  int Clmdtl_agent_cd { get; set;}
	 //        10  clmdtl-adj-cd                       pic x.
	 public  string Clmdtl_adj_cd { get; set;}
	 //        10  clmdtl-nbr-serv                     pic 99.
	 public  int Clmdtl_nbr_serv { get; set;}
	 //        10  clmdtl-nbr-serv-r redefines clmdtl-nbr-serv.
	 public  string Clmdtl_nbr_serv_r { get; set;}
	 //            15  clmdtl-adjust-reprint           pic x.
	 public  string Clmdtl_adjust_reprint { get; set;}
	 //            15  filler                          pic x.
	 public  string Filler { get; set;}
	 //        10  clmdtl-sv-date.
	 public  string Clmdtl_sv_date { get; set;}
	 //            15  clmdtl-sv-yy                    pic 9999.
	 public  int Clmdtl_sv_yy { get; set;}
	 //            15  clmdtl-sv-mm                    pic 99.
	 public  int Clmdtl_sv_mm { get; set;}
	 //            15  clmdtl-sv-dd                    pic 99.
	 public  int Clmdtl_sv_dd { get; set;}
	 //        10  clmdtl-consec-dates.
	 public  string Clmdtl_consec_dates { get; set;}
	 //        10  clmdtl-consec-dates-r  redefines  clmdtl-consec-dates.
	 public  string Clmdtl_consec_dates_r { get; set;}
	 //            15  clmdtl-consecutive-dates    occurs 3 times.
	 public  string[] Clmdtl_consecutive_dates { get; set;}
	 //                20  clmdtl-sv-nbr               pic  9.
	 public  int[] Clmdtl_sv_nbr { get; set;}
	 //                20  clmdtl-sv-day               pic xx.
	 public  string[] Clmdtl_sv_day { get; set;}
	 //        10  clmdtl-amt-tech-billed              pic s9(4)v99.
	 public  decimal Clmdtl_amt_tech_billed { get; set;}
	 //        10  clmdtl-fee-oma                      pic s9(5)v99.
	 public  decimal Clmdtl_fee_oma { get; set;}
	 //        10  clmdtl-fee-ohip                     pic s9(5)v99.
	 public  decimal Clmdtl_fee_ohip { get; set;}
	 //        10  clmdtl-date-period-end              pic x(8).
	 public  string Clmdtl_date_period_end { get; set;}
	 //        10  clmdtl-cycle-nbr                    pic 999.
	 public  int Clmdtl_cycle_nbr { get; set;}
	 //        10  clmdtl-diag-cd                      pic 999.
	 public  int Clmdtl_diag_cd { get; set;}
	 //        10  clmdtl-line-no                      pic 99.
	 public  int Clmdtl_line_no { get; set;}
	 //       10  clmdtl-resubmit-flag                pic x.
	 public  string Clmdtl_resubmit_flag { get; set;}
	 //       10  clmdtl-reserve-for-future           pic x(3).
	 public  string Clmdtl_reserve_for_future { get; set;}
	 //    05  clmdtl-desc-rec redefines clmdtl-det-rec.
	 public  string Clmdtl_desc_rec { get; set;}
	 //        10  clmdtl-desc                         pic x(22).
	 public  string Clmdtl_desc { get; set;}
	 //        10  filler                              pic x(42).
	// public  string Filler { get; set;}
	 //    05  clmdtl-filler                           pic x(104).  
	 public  string Clmdtl_filler { get; set;}
	 //    05  clmdtl-orig-batch-id.
	 public  string Clmdtl_orig_batch_id { get; set;}
	 //        10  clmdtl-orig-batch-nbr               pic x(8).
	 public  string Clmdtl_orig_batch_nbr { get; set;}
	 //        10  clmdtl-orig-batch-nbr-r redefines clmdtl-orig-batch-nbr.
	 public  string Clmdtl_orig_batch_nbr_r { get; set;}
	 //            15  clmdtl-orig-batch-nbr-1-2       pic 99.
	 public  int Clmdtl_orig_batch_nbr_1_2 { get; set;}
	 //            15  clmdtl-orig-batch-nbr-4-9       pic x(6).
	 public  string Clmdtl_orig_batch_nbr_4_9 { get; set;}
	 //        10  clmdtl-orig-claim-nbr-in-batch      pic 99.
	 public  int Clmdtl_orig_claim_nbr_in_batch { get; set;}
	 //    05  clmdtl-orig-batch-id-r  redefines clmdtl-orig-batch-id.
	 public  string Clmdtl_orig_batch_id_r { get; set;}
	 //        10  clmdtl-orig-complete-batch-nbr      pic 9(10).
	 public  int Clmdtl_orig_complete_batch_nbr { get; set;}
	 // 10  clmdtl-orig-complete-batch-n-r redefines clmdtl-orig-complete-batch-nbr.
	 public  string Clmdtl_orig_complete_batch_n_r { get; set;}
	 //     15  clmdtl-orig-clinic-number       pic 99.
	 public  int Clmdtl_orig_clinic_number { get; set;}
	 //     15  clmdtl-orig-doc-number   pic x(3).
	 public  string Clmdtl_orig_doc_number { get; set;}
	 //     15  clmdtl-orig-batch-number  pic 9(3).
	 public  int Clmdtl_orig_batch_number { get; set;}
	 //     15  clmdtl-orig-claim-number  pic 9(2).
	 public  int Clmdtl_orig_claim_number { get; set;}
	 //05  k-clmdtl-claims-mstr.
	 public  string K_clmdtl_claims_mstr { get; set;}
	 //    20  k-clmdtl-b-key-type                        pic x.
	 public  string K_clmdtl_b_key_type { get; set;}
	 //    20  k-clmdtl-b-data.
	 public  string K_clmdtl_b_data { get; set;}
	 //        25  k-clmdtl-b-batch-num                   pic x(8).
	 public  string K_clmdtl_b_batch_num { get; set;}
	 //        25  k-clmdtl-b-batch-nbr redefines k-clmdtl-b-batch-num.
	 public  string K_clmdtl_b_batch_nbr { get; set;}
	 //            30  k-clmdtl-b-clinic-nbr-1-2          pic 99.
	 public  int K_clmdtl_b_clinic_nbr_1_2 { get; set;}
	 //            30  k-clmdtl-b-doc-nbr                 pic x(3).
	 public  string K_clmdtl_b_doc_nbr { get; set;}
	 //            30  k-clmdtl-b-doc-nbr-r redefines k-clmdtl-b-doc-nbr.
	 public  string K_clmdtl_b_doc_nbr_r { get; set;}
	 //                35  k-clmdtl-b-doc-nbr-2-4         pic xxx.
	 public  string K_clmdtl_b_doc_nbr_2_4 { get; set;}
	 //            30  k-clmdtl-b-batch-number.
	 public  string K_clmdtl_b_batch_number { get; set;}
	 //                35  k-clmdtl-b-week                pic 99.
	 public  int K_clmdtl_b_week { get; set;}
	 //                35  k-clmdtl-b-day                 pic 9.
	 public  int K_clmdtl_b_day { get; set;}
	 //        25  k-clmdtl-b-claim-nbr                   pic 99.
	 public  int K_clmdtl_b_claim_nbr { get; set;}
	 //        25  k-clmdtl-b-oma-cd                      pic x999.
	 public  string K_clmdtl_b_oma_cd { get; set;}
	 //        25  k-clmdtl-b-oma-suff                    pic x.
	 public  string K_clmdtl_b_oma_suff { get; set;}
	 //        25  k-clmdtl-b-adj-nbr                     pic x.
	 public  string K_clmdtl_b_adj_nbr { get; set;}
	 //    20  k-clmdtl-b-data-r  redefines  k-clmdtl-b-data.
	 public  string K_clmdtl_b_data_r { get; set;}
	 //        25  k-clmdtl-b-pat-id                      pic x(15).
	 public  string K_clmdtl_b_pat_id { get; set;}
	 //        25  filler                                 pic x.
	// public  string Filler { get; set;}
	 //05  k-clmdtl-p-claims-mstr.
	 public  string K_clmdtl_p_claims_mstr { get; set;}
	 //    20  k-clmdtl-p-key-type                        pic x.
	 public  string K_clmdtl_p_key_type { get; set;}
	 //    20  k-clmdtl-p-data.
	 public  string K_clmdtl_p_data { get; set;}
	 //        25  k-clmdtl-p-batch-nbr.
	 public  string K_clmdtl_p_batch_nbr { get; set;}
	 //            30  k-clmdtl-p-clinic-nbr-1-2      pic  99.
	 public  int K_clmdtl_p_clinic_nbr_1_2 { get; set;}
	 //            30  k-clmdtl-p-doc-nbr             pic x(3).
	 public  string K_clmdtl_p_doc_nbr { get; set;}
	 //            30  k-clmdtl-p-week                pic 99.
	 public  int K_clmdtl_p_week { get; set;}
	 //            30  k-clmdtl-p-day                 pic 9.
	 public  int K_clmdtl_p_day { get; set;}
	 //        25  k-clmdtl-p-claim-nbr               pic 99.
	 public  int K_clmdtl_p_claim_nbr { get; set;}
	 //        25  k-clmdtl-p-oma-cd                  pic x999.
	 public  string K_clmdtl_p_oma_cd { get; set;}
	 //        25  k-clmdtl-p-oma-suff                pic x.
	 public  string K_clmdtl_p_oma_suff { get; set;}
	 //        25  k-clmdtl-p-adj-nbr                 pic x.
	 public  string K_clmdtl_p_adj_nbr { get; set;}

}
}
