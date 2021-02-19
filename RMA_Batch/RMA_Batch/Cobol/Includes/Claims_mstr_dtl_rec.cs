using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Claims_mstr_dtl_rec
    {        	 
	 //    10  filler                                  pic x(10).
	 public  string Filler { get; set;}
	 //    10  clmrec-dtl-oma-cd                       pic x(4).
	 public  string Clmrec_dtl_oma_cd { get; set;}
	 //    10  filler                                  pic x(5).
	 //public  string Filler { get; set;}
	 //    10  clmrec-dtl-agent-cd                     pic  9.
	 public  int Clmrec_dtl_agent_cd { get; set;}
	 //    10  clmrec-dtl-adj-cd                       pic  x.
	 public  string Clmrec_dtl_adj_cd { get; set;}
	 //    10  clmrec-dtl-nbr-serv                     pic 99.
	 public  int Clmrec_dtl_nbr_serv { get; set;}
	 //    10  clmrec-dtl-sv-date                      pic x(8).
	 public  string Clmrec_dtl_sv_date { get; set;}
	 //    10  clmrec-dtl-consec-dates occurs 3 times.
	 public  string[] Clmrec_dtl_consec_dates { get; set;}
	 //        15  clmrec-dtl-sv-nbr                   pic 9.
	 public  int[] Clmrec_dtl_sv_nbr { get; set;}
	 //        15  filler                              pic xx.
	 //public  string[] Filler { get; set;}
	 //    10  clmrec-dtl-amt-tech-billed              pic s9(4)v99.
	 public  decimal Clmrec_dtl_amt_tech_billed { get; set;}
	 //    10  clmrec-dtl-fee-oma                      pic s9(5)v99.
	 public  decimal Clmrec_dtl_fee_oma { get; set;}
	 //    10  clmrec-dtl-fee-ohip                     pic s9(5)v99.
	 public  decimal Clmrec_dtl_fee_ohip { get; set;}
	 //    10  filler                                  pic x(134).
	 //public  string Filler { get; set;}
	 //10  key-claims-mstr.
	 public  string Key_claims_mstr { get; set;}
	 //    20  clmdtl-b-key-type                        pic x.
	 public  string Clmdtl_b_key_type { get; set;}
	 //    20  clmdtl-b-data.
	 public  string Clmdtl_b_data { get; set;}
	 //        25  clmdtl-b-batch-num                   pic x(8).
	 public  string Clmdtl_b_batch_num { get; set;}
	 //        25  clmdtl-b-batch-nbr redefines clmdtl-b-batch-num.
	 public  string Clmdtl_b_batch_nbr { get; set;}
	 //            30  clmdtl-b-clinic-nbr-1-2          pic 99.
	 public  int Clmdtl_b_clinic_nbr_1_2 { get; set;}
	 //            30  clmdtl-b-doc-nbr                 pic x(3).
	 public  string Clmdtl_b_doc_nbr { get; set;}
	 //            30  clmdtl-b-doc-nbr-r redefines clmdtl-b-doc-nbr.
	 public  string Clmdtl_b_doc_nbr_r { get; set;}
	 //                35  clmdtl-b-doc-nbr-2-4         pic xxx.
	 public  string Clmdtl_b_doc_nbr_2_4 { get; set;}
	 //            30  clmdtl-b-batch-number.
	 public  string Clmdtl_b_batch_number { get; set;}
	 //                35  clmdtl-b-week                pic 99.
	 public  int Clmdtl_b_week { get; set;}
	 //                35  clmdtl-b-day                 pic 9.
	 public  int Clmdtl_b_day { get; set;}
	 //     30  clmdtl-b-batch-number-numeric redefines  clmdtl-b-batch-number       pic 9(3).
	 public  int Clmdtl_b_batch_number_numeric { get; set;}
	 //        25  clmdtl-b-claim-nbr                   pic 99.
	 public  int Clmdtl_b_claim_nbr { get; set;}
	 //        25  clmdtl-b-oma-cd                      pic x999.
	 public  string Clmdtl_b_oma_cd { get; set;}
	 //        25  clmdtl-b-oma-suff                    pic x.
	 public  string Clmdtl_b_oma_suff { get; set;}
	 //        25  clmdtl-b-adj-nbr                     pic x.
	 public  string Clmdtl_b_adj_nbr { get; set;}
	 //    20  clmdtl-b-data-r  redefines  clmdtl-b-data.
	 public  string Clmdtl_b_data_r { get; set;}
	 //        25  clmdtl-b-pat-id                      pic x(15).
	 public  string Clmdtl_b_pat_id { get; set;}
	 //        25  filler                               pic x.
	 //public  string Filler { get; set;}
	 //10  clmdtl-p-claims-mstr.
	 public  string Clmdtl_p_claims_mstr { get; set;}
	 //    20  clmdtl-p-key-type                        pic x.
	 public  string Clmdtl_p_key_type { get; set;}
	 //    20  clmdtl-p-data.
	 public  string Clmdtl_p_data { get; set;}
	 //        25  clmdtl-p-batch-nbr.
	 public  string Clmdtl_p_batch_nbr { get; set;}
	 //            30  clmdtl-p-clinic-nbr-1-2      pic  99.
	 public  int Clmdtl_p_clinic_nbr_1_2 { get; set;}
	 //            30  clmdtl-p-doc-nbr             pic x(3).
	 public  string Clmdtl_p_doc_nbr { get; set;}
	 //            30  clmdtl-p-week                pic 99.
	 public  int Clmdtl_p_week { get; set;}
	 //            30  clmdtl-p-day                 pic 9.
	 public  int Clmdtl_p_day { get; set;}
	 //        25  clmdtl-p-claim-nbr               pic 99.
	 public  int Clmdtl_p_claim_nbr { get; set;}
	 //        25  clmdtl-p-oma-cd                  pic x999.
	 public  string Clmdtl_p_oma_cd { get; set;}
	 //        25  clmdtl-p-oma-suff                pic x.
	 public  string Clmdtl_p_oma_suff { get; set;}
	 //        25  clmdtl-p-adj-nbr                 pic x.
	 public  string Clmdtl_p_adj_nbr { get; set;}

}
}
