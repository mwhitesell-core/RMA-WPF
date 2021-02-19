using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Claims_work_rec
    {
        	 //01  claims-work-rec. 
	 //public  string Claims_work_rec { get; set;}
	 //    05  wk-dept-nbr    pic 99. 
	 public  int Wk_dept_nbr { get; set;}
	 //    05  wk-sort-record-status   pic 9. 
	 public  int Wk_sort_record_status { get; set;}
	 //    05  wk-agent-cd    pic 9. 
	 public  int Wk_agent_cd { get; set;}
	 //    05  wk-age-category    pic 9. 
	 public  int Wk_age_category { get; set;}
	 //    05  wk-pat-acronym     pic x(9). 
	 public  string Wk_pat_acronym { get; set;}
        public string Wk_pat_acronym_1 { get; set; }
        public string Wk_pat_acronym_2 { get; set; }
        //    05  wk-pat-id. 
        public string Wk_pat_id { get; set;}
	 //        10 wk-pat-id-1       pic xxx. 
	 public  string Wk_pat_id_1 { get; set;}
	 //        10 wk-pat-id-2    pic x(12). 
	 public  string Wk_pat_id_2 { get; set;}
	 //    05  wk-pat-id-r redefines wk-pat-id. 
	 public  string Wk_pat_id_r { get; set;}
	 // 10  wk-ohip-nbr    pic x(8). 
	 public  string Wk_ohip_nbr { get; set;}
	 //    10  filler    pic x(7). 
	 public  string Filler { get; set;}
	 //    05  wk-pat-hc-r redefines wk-pat-id. 
	 public  string Wk_pat_hc_r { get; set;}
	 // 10  wk-health-nbr   pic x(10). 
	 public  string Wk_health_nbr { get; set;}
	 //    10  filler    pic x(5). 
	 //public  string Filler { get; set;}
	 //    05  wk-clm-nbr. 
	 public  string Wk_clm_nbr { get; set;}
	 //        10 wk-clinic-nbr   pic 99. 
	 public  int Wk_clinic_nbr { get; set;}
	 //        10 wk-doc-nbr    pic x(3). 
	 public  string Wk_doc_nbr { get; set;}
	 //        10 wk-week    pic 99. 
	 public  int Wk_week { get; set;}
	 //        10 wk-day    pic 9. 
	 public  int Wk_day { get; set;}
	 //        10  wk-claim-nbr   pic 99. 
	 public  int Wk_claim_nbr { get; set;}
	 //    05  wk-ohip-stat.   
	 public  string Wk_ohip_stat { get; set;}
	 //        10  wk-ohip-stat-1   pic x. 
	 public  string Wk_ohip_stat_1 { get; set;}
        //        10  wk-ohip-stat-2                      pic 9. 
        //public  int Wk_ohip_stat_2 { get; set;}
        public  string Wk_ohip_stat_2 { get; set;}
        //    05  wk-sub-nbr    pic x. 
        public string Wk_sub_nbr { get; set;}
	 //    05  wk-oma-fee    pic s9(6)v99. 
	 public  decimal Wk_oma_fee { get; set;}
	 //    05  wk-ohip-fee    pic s9(6)v99. 
	 public  decimal Wk_ohip_fee { get; set;}
	 //    05  wk-amount-paid    pic s9(6)v99. 
	 public  decimal Wk_amount_paid { get; set;}
	 //    05  wk-balance-due    pic s9(6)v99. 
	 public  decimal Wk_balance_due { get; set;}
	 //    05  wk-period-end-date.    
	 public  string Wk_period_end_date { get; set;}
	 //        10  wk-period-end-yy   pic 9999. 
	 public  int Wk_period_end_yy { get; set;}
	 //        10  wk-period-end-mm   pic 99. 
	 public  int Wk_period_end_mm { get; set;}
	 //        10  wk-period-end-dd   pic 99. 
	 public  int Wk_period_end_dd { get; set;}
	 //    05  wk-ser-date. 
	 public  string Wk_ser_date { get; set;}
	 //        10  wk-ser-yy    pic 9999. 
	 public  int Wk_ser_yy { get; set;}
	 //        10  wk-ser-mm    pic 99.       
	 public  int Wk_ser_mm { get; set;}
	 //        10  wk-ser-dd    pic 99.  
	 public  int Wk_ser_dd { get; set;}
	 //    05  wk-day-old    pic xxx. 
	 public  string Wk_day_old { get; set;}
	 //    05  wk-batch-nbr-1-2   pic 99.      
	 public  int Wk_batch_nbr_1_2 { get; set;}
	 //    05  wk-batch-nbr-4-9   pic x(6). 
	 public  string Wk_batch_nbr_4_9 { get; set;}
	 //    05  wk-tape-submit-ind   pic x. 
	 public  string Wk_tape_submit_ind { get; set;}
	 //    05  wk-act-taken. 
	 public  string Wk_act_taken { get; set;}
	 //        10 wk-act-taken-1   pic xxx.
	 public  string Wk_act_taken_1 { get; set;}
	 //        10 wk-act-taken-2   pic 9(8). 
	 //mw public  int Wk_act_taken_2 { get; set;}

        public string Wk_act_taken_2 { get; set; }

    }
}
