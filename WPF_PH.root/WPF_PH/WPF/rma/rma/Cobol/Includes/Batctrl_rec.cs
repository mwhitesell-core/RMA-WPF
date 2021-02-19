using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Batctrl_rec
    {
        	 //01  batctrl-rec.  
	// public  string Batctrl_rec { get; set;}
	 //    05  batctrl-batch-nbr.  
	 public  string Batctrl_batch_nbr { get; set;}
	 // 10  batctrl-bat-clinic-nbr-1-2  pic 99.     
	 public  int Batctrl_bat_clinic_nbr_1_2 { get; set;}
	 // 10  batctrl-bat-doc-nbr   pic x(3).   
	 public  string Batctrl_bat_doc_nbr { get; set;}
	 // 10  batctrl-bat-week-day.  
	 public  string Batctrl_bat_week_day { get; set;}
	 //     15  batctrl-bat-week  pic 99.  
	 public  int Batctrl_bat_week { get; set;}
	 //     15  batctrl-bat-day   pic 9.  
	 public  int Batctrl_bat_day { get; set;}
	 // 10  batctrl-bat-week-day-r redefines batctrl-bat-week-day         pic 999.  
	 public  int Batctrl_bat_week_day_r { get; set;}
	 //    05  key-batctrl-file-r redefines batctrl-batch-nbr.
	 public  string Key_batctrl_file_r { get; set;}
	 //        10  key-batctrl-file    pic x(8).
	 public  string Key_batctrl_file { get; set;}
	 //    05  batctrl-batch-type   pic x.  
	 public  string Batctrl_batch_type { get; set;}
	 //    05  batctrl-adj-cd    pic x.  
	 public  string Batctrl_adj_cd { get; set;}
	 //    05  batctrl-adj-cd-sub-type   pic x.  
	 public  string Batctrl_adj_cd_sub_type { get; set;}
	 //    05  batctrl-last-claim-nbr   pic 99.  
	 public  int Batctrl_last_claim_nbr { get; set;}
	 //    05  batctrl-clinic-nbr.  
	 public  string Batctrl_clinic_nbr { get; set;}
	 // 10  batctrl-clinic-nbr-1-2  pic xx.     
	 public  string Batctrl_clinic_nbr_1_2 { get; set;}
	 // 10  batctrl-clinic-nbr-3-4  pic xx.     
	 public  string Batctrl_clinic_nbr_3_4 { get; set;}
	 //    05  batctrl-doc-nbr-ohip   pic 9(6).  
	 public  int Batctrl_doc_nbr_ohip { get; set;}
	 //    05  batctrl-hosp    pic x.  
	 public  string Batctrl_hosp { get; set;}
	 //    05  batctrl-payroll redefines batctrl-hosp  pic x.
	 public  string Batctrl_payroll { get; set;}
	 //    05  batctrl-loc.  
	 public  string Batctrl_loc { get; set;}
	 // 10  batctrl-loc1   pic x.         
	 public  string Batctrl_loc1 { get; set;}
	 // 10  batctrl-loc2-4   pic xxx.
	 public  string Batctrl_loc2_4 { get; set;}
	 //    05  batctrl-agent-cd   pic 9.  
	 public  int Batctrl_agent_cd { get; set;}
	 //    05  batctrl-i-o-pat-ind   pic x.  
	 public  string Batctrl_i_o_pat_ind { get; set;}
	 //    05  batctrl-date-batch-entered  pic x(8).  
	 public  string Batctrl_date_batch_entered { get; set;}
	 //    05  batctrl-date-period-end.  
	 public  string Batctrl_date_period_end { get; set;}
	 // 10 batctrl-date-period-end-yy  pic xxxx. 
	 public  string Batctrl_date_period_end_yy { get; set;}
	 // 10 batctrl-date-period-end-mm  pic xx.  
	 public  string Batctrl_date_period_end_mm { get; set;}
	 // 10 batctrl-date-period-end-dd  pic xx.  
	 public  string Batctrl_date_period_end_dd { get; set;}
	 //    05  batctrl-cycle-nbr   pic 999.          
	 public  int Batctrl_cycle_nbr { get; set;}
	 //    05  batctrl-amt-est    pic s9(7)v99.  
	 public  decimal Batctrl_amt_est { get; set;}
	 //    05  batctrl-amt-act    pic s9(7)v99.  
	 public  decimal Batctrl_amt_act { get; set;}
	 //    05  batctrl-svc-est    pic 9(4).  
	 public  int Batctrl_svc_est { get; set;}
	 //    05  batctrl-svc-act    pic 9(4).  
	 public  int Batctrl_svc_act { get; set;}
	 //    05  batctrl-ar-yy-mm   pic x(6).  
	 public  string Batctrl_ar_yy_mm { get; set;}
	 //    05  batctrl-calc-ar-due   pic s9(7)v99.  
	 public  decimal Batctrl_calc_ar_due { get; set;}
	 //    05  batctrl-calc-tot-rev   pic s9(7)v99.  
	 public  decimal Batctrl_calc_tot_rev { get; set;}
	 //    05  batctrl-manual-pay-tot   pic s9(7)v99.  
	 public  decimal Batctrl_manual_pay_tot { get; set;}
	 //    05  batctrl-batch-status   pic x.  
	 public  string Batctrl_batch_status { get; set;}
	 //    05  batctrl-nbr-claims-in-batch  pic 99.  
	 public  int Batctrl_nbr_claims_in_batch { get; set;}

}
}
