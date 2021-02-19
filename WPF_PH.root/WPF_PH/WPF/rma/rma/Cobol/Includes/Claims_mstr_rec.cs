using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Claims_mstr_rec
    {        	
	 //  05  claims-mstr-hdr-rec.
	 public  string Claims_mstr_hdr_rec { get; set;}
	 //    10  clmrec-hdr-clinic-nbr-1-2               pic 99.
	 public  int Clmrec_hdr_clinic_nbr_1_2 { get; set;}
	 //    10  filler                                  pic x(08).
	 public  string Filler { get; set;}
	 //    10  clmrec-zeroed-oma-suff-adj              pic x(06).
	 public  string Clmrec_zeroed_oma_suff_adj { get; set;}
	 //    10  clmrec-zeroed-area redefines clmrec-zeroed-oma-suff-adj                                                 pic 9(06).
	 public  int Clmrec_zeroed_area { get; set;}
	 //    10  clmrec-hdr-batch-type                   pic x.
	 public  string Clmrec_hdr_batch_type { get; set;}
	 //    10  filler                                  pic x(15).
	// public  string Filler { get; set;}
	 //    10  clmrec-hdr-diag-cd                      pic 9(3).
	 public  int Clmrec_hdr_diag_cd { get; set;}
	 //    10  clmrec-hdr-loc                          pic x(4).
	 public  string Clmrec_hdr_loc { get; set;}
	 //    10  clmrec-hdr-hosp                         pic x.
	 public  string Clmrec_hdr_hosp { get; set;}
	 //    10  clmrec-hdr-payroll redefines clmrec-hdr-hosp pic x.
	 public  string Clmrec_hdr_payroll { get; set;}
	 //    10  clmrec-hdr-agent-cd                     pic 9.
	 public  int Clmrec_hdr_agent_cd { get; set;}
	 //    10  filler                                  pic x(2).
	//public  string Filler { get; set;}
	 //    10  clmrec-hdr-i-o-pat-ind                  pic x.
	 public  string Clmrec_hdr_i_o_pat_ind { get; set;}
	 //    10  clmrec-hdr-ohip-id-or-chart             pic x(16).
	 public  string Clmrec_hdr_ohip_id_or_chart { get; set;}
	 //    10  clmrec-hdr-pat-acronym                  pic x(9).
	 public  string Clmrec_hdr_pat_acronym { get; set;}
	 //    10  filler                                  pic x(19). 
	// public  string Filler { get; set;}
	 //    10  clmrec-doc-dept-nbr                     pic 99.
	 public  int Clmrec_doc_dept_nbr { get; set;}
	 //    10  filler                                  pic x(25).
	// public  string Filler { get; set;}
	 //    10  clmrec-hdr-date-claim                   pic x(8).
	 public  string Clmrec_hdr_date_claim { get; set;}
	 //    10  clmrec-hdr-amt-tech-billed              pic s9(4)v99.
	 public  decimal Clmrec_hdr_amt_tech_billed { get; set;}
	 //    10  clmrec-hdr-amt-tech-paid                pic s9(4)v99.
	 public  decimal Clmrec_hdr_amt_tech_paid { get; set;}
	 //    10  clmrec-hdr-tot-claim-ar-oma             pic s9(5)v99.
	 public  decimal Clmrec_hdr_tot_claim_ar_oma { get; set;}
	 //    10  clmrec-hdr-tot-claim-ar-ohip            pic s9(5)v99.
	 public  decimal Clmrec_hdr_tot_claim_ar_ohip { get; set;}
	 //    10  clmrec-hdr-manual-tape-pymnts           pic s9(5)v99.
	 public  decimal Clmrec_hdr_manual_tape_pymnts { get; set;}
	 //    10  clmrec-hdr-status-ohip                  pic xx.
	 public  string Clmrec_hdr_status_ohip { get; set;}
	 //    10  filler                                  pic x(36).
	 //public  string Filler { get; set;}
	 //10  k-key-claims-mstr.
	 public  string K_key_claims_mstr { get; set;}
	 //    20  clmrec-hdr-b-key-type                        pic x.
	 public  string Clmrec_hdr_b_key_type { get; set;}
	 //    20  clmrec-hdr-b-data.
	 public  string Clmrec_hdr_b_data { get; set;}
	 //        25  clmrec-hdr-b-batch-num                   pic x(8).
	 public  string Clmrec_hdr_b_batch_num { get; set;}
	 //        25  clmrec-hdr-b-batch-nbr redefines clmrec-hdr-b-batch-num.
	 public  string Clmrec_hdr_b_batch_nbr { get; set;}
	 //            30  clmrec-hdr-b-clinic-nbr-1-2          pic 99.
	 public  int Clmrec_hdr_b_clinic_nbr_1_2 { get; set;}
	 //            30  clmrec-hdr-b-doc-nbr                 pic x(3).
	 public  string Clmrec_hdr_b_doc_nbr { get; set;}
	 //            30  clmrec-hdr-b-doc-nbr-r redefines clmrec-hdr-b-doc-nbr.
	 public  string Clmrec_hdr_b_doc_nbr_r { get; set;}
	 //                35  clmrec-hdr-b-doc-nbr-2-4         pic xxx.
	 public  string Clmrec_hdr_b_doc_nbr_2_4 { get; set;}
	 //            30  clmrec-hdr-b-batch-number.
	 public  string Clmrec_hdr_b_batch_number { get; set;}
	 //                35  clmrec-hdr-b-week                pic 99.
	 public  int Clmrec_hdr_b_week { get; set;}
	 //                35  clmrec-hdr-b-day                 pic 9.
	 public  int Clmrec_hdr_b_day { get; set;}
	 //        25  clmrec-hdr-b-claim-nbr                   pic 99.
	 public  int Clmrec_hdr_b_claim_nbr { get; set;}
	 //        25  clmrec-hdr-b-oma-cd                      pic x999.
	 public  string Clmrec_hdr_b_oma_cd { get; set;}
	 //        25  clmrec-hdr-b-oma-suff                    pic x.
	 public  string Clmrec_hdr_b_oma_suff { get; set;}
	 //        25  clmrec-hdr-b-adj-nbr                     pic x.
	 public  string Clmrec_hdr_b_adj_nbr { get; set;}
	 //    20  clmrec-hdr-b-data-r  redefines  clmrec-hdr-b-data.
	 public  string Clmrec_hdr_b_data_r { get; set;}
	 //        25  clmrec-hdr-b-pat-id                      pic x(15).
	 public  string Clmrec_hdr_b_pat_id { get; set;}
	 //        25  filler                                   pic x.
	// public  string Filler { get; set;}
	 //10  k-clmdtl-p-claims-mstr.
	 public  string K_clmdtl_p_claims_mstr { get; set;}
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
