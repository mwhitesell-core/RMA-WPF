using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class R004_Work_file_rec
    {
        //01  work-file-rec. 
        public string Work_file_rec { get; set; }
        //    05  wf-doctor-id. 
        public string Wf_doctor_id { get; set; }
        // 10  wf-dept    pic 99. 
        public int Wf_dept { get; set; }
        // 10  wf-doc-nbr    pic xxx. 
        public string Wf_doc_nbr { get; set; }
        //    05  wf-patient-name. 
        public string Wf_patient_name { get; set; }
        // 10  wf-pat-surname   pic x(6). 
        public string Wf_pat_surname { get; set; }
        // 10  wf-pat-acronym3   pic x(3). 
        public string Wf_pat_acronym3 { get; set; }
        //    05  wf-claim-id. 
        public string Wf_claim_id { get; set; }
        // 10  wf-claim-batch-nbr. 
        public string Wf_claim_batch_nbr { get; set; }
        //     15  wf-claim-clinic-nbr-1-2  pic 99. 
        public int Wf_claim_clinic_nbr_1_2 { get; set; }
        //     15  wf-claim-doctor-nbr  pic x(3). 
        public string Wf_claim_doctor_nbr { get; set; }
        //     15  wf-claim-week   pic 99. 
        public int Wf_claim_week { get; set; }
        //     15  wf-claim-day   pic 9. 
        public int Wf_claim_day { get; set; }
        // 10  wf-claim-nbr   pic 99. 
        public int Wf_claim_nbr { get; set; }
        //    05  wf-pat-id-or-chart   pic x(15). 
        public string Wf_pat_id_or_chart { get; set; }
        //    05  wf-agent-cd-adj. 
        public string Wf_agent_cd_adj { get; set; }
        // 10 wf-agent-cd    pic 9. 
        public int Wf_agent_cd { get; set; }
        // 10 wf-adj-cd    pic x. 
        public string Wf_adj_cd { get; set; }
        //    05  wf-payroll    pic x.
        public string Wf_payroll { get; set; }
        //    05  wf-claim-oma    pic s9(5)v99. 
        public decimal Wf_claim_oma { get; set; }
        //    05  wf-claim-ohip    pic s9(5)v99. 
        public decimal Wf_claim_ohip { get; set; }
        //    05  wf-service-date.   
        public string Wf_service_date { get; set; }
        // 10  wf-service-date-yy   pic 9999. 
        public int Wf_service_date_yy { get; set; }
        // 10  wf-service-date-mm   pic 99. 
        public int Wf_service_date_mm { get; set; }
        // 10  wf-service-date-dd   pic 99. 
        public int Wf_service_date_dd { get; set; }
        //    05  wf-claim-date-sys. 
        public string Wf_claim_date_sys { get; set; }
        // 10  wf-claim-date-sys-yy  pic 9999. 
        public int Wf_claim_date_sys_yy { get; set; }
        // 10  wf-claim-date-sys-mm  pic 99.             
        public int Wf_claim_date_sys_mm { get; set; }
        // 10  wf-claim-date-sys-dd  pic 99. 
        public int Wf_claim_date_sys_dd { get; set; }
        //    05  wf-diag-cd    pic 999. 
        public int Wf_diag_cd { get; set; }
        //    05  wf-oma-code. 
        public string Wf_oma_code { get; set; }
        // 10  wf-oma-cd    pic x(4). 
        public string Wf_oma_cd { get; set; }
        // 10  wf-oma-suff    pic x. 
        public string Wf_oma_suff { get; set; }
        //    05  wf-nbr-serv    pic 99. 
        public int Wf_nbr_serv { get; set; }
        //    05  wf-orig-claim-id. 
        public string Wf_orig_claim_id { get; set; }
        // 10  wf-orig-clinic-nbr-1-2  pic 99. 
        public int Wf_orig_clinic_nbr_1_2 { get; set; }
        // 10  wf-orig-doc-nbr   pic x(3). 
        public string Wf_orig_doc_nbr { get; set; }
        // 10  wf-orig-week   pic xx. 
        public string Wf_orig_week { get; set; }
        // 10  wf-orig-day    pic x. 
        public string Wf_orig_day { get; set; }
        // 10  wf-orig-claim-nbr   pic 99. 
        public int Wf_orig_claim_nbr { get; set; }
        //    05  wf-ref-field    pic x(9). 
        public string Wf_ref_field { get; set; }
        //    05  wf-trans-cd    pic x. 
        public string Wf_trans_cd { get; set; }
        //    05  wf-amt-tech-billed   pic s9(5)v99. 
        public decimal Wf_amt_tech_billed { get; set; }
        //    05  wf-adj-cd-sub-type    pic x. 
        public string Wf_adj_cd_sub_type { get; set; }

    }
}
