using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rat_record_1
    {     
	 //    05  rat-1-trans-cd    pic xx. 
	 public  string Rat_1_trans_cd { get; set;}
	 //    05  rat-1-record-type   pic x. 
	 public  string Rat_1_record_type { get; set;}
	 //    05  rat-1-release-id   pic x(3).
	 public  string Rat_1_release_id { get; set;}
	 //    05  rat-1-filler-1    pic x. 
	 public  string Rat_1_filler_1 { get; set;}
	 //    05  rat-1-group-nbr    pic x(4). 
	 public  string Rat_1_group_nbr { get; set;}
	 //    05  rat-1-doc-nbr    pic 9(6). 
	 public  int Rat_1_doc_nbr { get; set;}
	 //    05  rat-1-specialty-cd   pic xx. 
	 public  string Rat_1_specialty_cd { get; set;}
	 //    05  rat-1-moh-off-cd   pic x. 
	 public  string Rat_1_moh_off_cd { get; set;}
	 //    05  rat-1-data-seq-nbr   pic 9. 
	 public  int Rat_1_data_seq_nbr { get; set;}
	 //    05  rat-1-payment-date. 
	 public  string Rat_1_payment_date { get; set;}
	 //  10  rat-1-payment-date-yy  pic 9(4). 
	 public  int Rat_1_payment_date_yy { get; set;}
	 // 10  rat-1-payment-date-mm  pic 99. 
	 public  int Rat_1_payment_date_mm { get; set;}
	 // 10  rat-1-payment-date-dd  pic 99. 
	 public  int Rat_1_payment_date_dd { get; set;}
	 //    05  rat-1-payee-name. 
	 public  string Rat_1_payee_name { get; set;}
	 // 10  rat-1-last-name   pic x(25). 
	 public  string Rat_1_last_name { get; set;}
	 // 10  rat-1-title       pic xxx. 
	 public  string Rat_1_title { get; set;}
	 // 10  rat-1-initials    pic xx. 
	 public  string Rat_1_initials { get; set;}
	 //    05  rat-1-tot-amt-pay   pic 9(7)v99. 
	 public  decimal Rat_1_tot_amt_pay { get; set;}
	 //    05  rat-1-tot-amt-pay-sign   pic x. 
	 public  string Rat_1_tot_amt_pay_sign { get; set;}
	 //    05  rat-1-cheq-nbr    pic x(8). 
	 public  string Rat_1_cheq_nbr { get; set;}
	 //     05  rat-1-filler-2    pic x(3). 
	 public  string Rat_1_filler_2 { get; set;}
        public object RatRecord_Reference { get; set; }
    }
}
