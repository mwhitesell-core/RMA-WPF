using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Tape_rmb_record
    {        	
	 //    05  rat-rmb-group-nbr   pic x(4). 
	 public  string Rat_rmb_group_nbr { get; set;}
	 //    05  rat-rmb-moh-off-cd                pic x. 
	 public  string Rat_rmb_moh_off_cd { get; set;}
	 //    05  rat-rmb-data-seq-nbr                    pic 9. 
	 public  int Rat_rmb_data_seq_nbr { get; set;}
	 //    05  rat-rmb-payment-date   pic 9(8). 
	 public  int Rat_rmb_payment_date { get; set;}
	 //    05  rat-rmb-payee-name. 
	 public  string Rat_rmb_payee_name { get; set;}
	 // 10  rat-rmb-pay-last-name     pic x(25). 
	 public  string Rat_rmb_pay_last_name { get; set;}
	 //        10  rat-rmb-pay-title   pic xxx. 
	 public  string Rat_rmb_pay_title { get; set;}
	 //        10  rat-rmb-pay-initials      pic xx. 
	 public  string Rat_rmb_pay_initials { get; set;}
	 //    05  rat-rmb-tot-amt-pay   pic s9(7)v99. 
	 public  decimal Rat_rmb_tot_amt_pay { get; set;}
	 //    05  rat-rmb-cheq-nbr   pic x(8). 
	 public  string Rat_rmb_cheq_nbr { get; set;}
	 //    05  rat-rmb-claim-nbr          pic x(11). 
	 public  string Rat_rmb_claim_nbr { get; set;}
	 //    05  rat-rmb-trans-type   pic 9. 
	 public  int Rat_rmb_trans_type { get; set;}
	 //    05  rat-rmb-doc-nbr    pic 9(6). 
	 public  int Rat_rmb_doc_nbr { get; set;}
	 //    05  rat-rmb-specialty-cd       pic xx. 
	 public  string Rat_rmb_specialty_cd { get; set;}
	 //    05  rat-rmb-account-nbr       pic x(8). 
	 public  string Rat_rmb_account_nbr { get; set;}
	 //    05  rat-rmb-last-name        pic x(14). 
	 public  string Rat_rmb_last_name { get; set;}
	 //    05  rat-rmb-first-name       pic x(5). 
	 public  string Rat_rmb_first_name { get; set;}
	 //    05  rat-rmb-prov-cd          pic xx. 
	 public  string Rat_rmb_prov_cd { get; set;}
	 //    05  rat-rmb-health-ohip-nbr   pic x(12). 
	 public  string Rat_rmb_health_ohip_nbr { get; set;}
	 //    05  rat-rmb-version-cd   pic xx. 
	 public  string Rat_rmb_version_cd { get; set;}
	 //    05  rat-rmb-pay-prog              pic xxx. 
	 public  string Rat_rmb_pay_prog { get; set;}
	 //    05  rat-rmb-conv-health-nbr   pic x(10). 
	 public  string Rat_rmb_conv_health_nbr { get; set;}
	 //    05  rat-rmb-service-date                    pic 9(8). 
	 public  int Rat_rmb_service_date { get; set;}
	 //    05  rat-rmb-nbr-of-serv   pic 99. 
	 public  int Rat_rmb_nbr_of_serv { get; set;}
	 //    05  rat-rmb-service-cd   pic x(5). 
	 public  string Rat_rmb_service_cd { get; set;}
	 //    05  rat-rmb-eligibility-ind   pic x. 
	 public  string Rat_rmb_eligibility_ind { get; set;}
	 //    05  rat-rmb-amount-sub   pic 9(4)v99. 
	 public  decimal Rat_rmb_amount_sub { get; set;}
	 //    05  rat-rmb-amt-paid   pic s9(4)v99. 
	 public  decimal Rat_rmb_amt_paid { get; set;}
	 //    05  rat-rmb-explan-cd   pic xx. 
	 public  string Rat_rmb_explan_cd { get; set;}

}
}
