using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rat_record_7
    {        	
	 //    05  rat-7-trans-id    pic xx. 
	 public  string Rat_7_trans_id { get; set;}
	 //    05  rat-7-record-type   pic x. 
	 public  string Rat_7_record_type { get; set;}
	 //    05  rat-7-trans-cd    pic xx. 
	 public  string Rat_7_trans_cd { get; set;}
	 //    05  rat-7-cheque-ind   pic x. 
	 public  string Rat_7_cheque_ind { get; set;}
	 //    05  rat-7-trans-date   pic 9(8). 
	 public  int Rat_7_trans_date { get; set;}
	 //    05  rat-7-trans-amt         pic 9(6)v99. 
	 public  decimal Rat_7_trans_amt { get; set;}
	 //    05  rat-7-trans-amt-sgn          pic x. 
	 public  string Rat_7_trans_amt_sgn { get; set;}
	 //    05  rat-7-trans-message    pic x(50). 
	 public  string Rat_7_trans_message { get; set;}
	 //    05  rat-7-filler       pic x(4). 
	 public  string Rat_7_filler { get; set;}

}
}
