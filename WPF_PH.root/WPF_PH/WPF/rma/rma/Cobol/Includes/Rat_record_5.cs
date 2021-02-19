using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rat_record_5
    {        	
	 //    05  rat-5-trans-id    pic xx. 
	 public  string Rat_5_trans_id { get; set;}
	 //    05  rat-5-record-type   pic x. 
	 public  string Rat_5_record_type { get; set;}
	 //    05  rat-5-claim-nbr    pic x(11). 
	 public  string Rat_5_claim_nbr { get; set;}
	 //    05  rat-5-trans-type   pic 9. 
	 public  int Rat_5_trans_type { get; set;}
	 //    05  rat-5-service-date   pic 9(8). 
	 public  int Rat_5_service_date { get; set;}
	 //    05  rat-5-nbr-of-serv   pic 99. 
	 public  int Rat_5_nbr_of_serv { get; set;}
	 //    05  rat-5-service-cd   pic x(5). 
	 public  string Rat_5_service_cd { get; set;}
	 //    05  rat-5-eligibility-ind   pic x. 
	 public  string Rat_5_eligibility_ind { get; set;}
	 //    05  rat-5-amount-sub   pic 9(4)v99. 
	 public  decimal Rat_5_amount_sub { get; set;}
	 //    05  rat-5-amt-paid    pic 9(4)v99. 
	 public  decimal Rat_5_amt_paid { get; set;}
	 //    05  rat-5-amt-paid-sign   pic x. 
	 public  string Rat_5_amt_paid_sign { get; set;}
	 //    05  rat-5-explan-cd    pic xx. 
	 public  string Rat_5_explan_cd { get; set;}
	 //    05  rat-5-filler-2    pic x(35). 
	 public  string Rat_5_filler_2 { get; set;}

}
}
