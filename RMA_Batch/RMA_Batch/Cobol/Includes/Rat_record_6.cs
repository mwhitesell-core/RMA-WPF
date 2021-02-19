using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rat_record_6
    {        	
	 //    05  rat-6-trans-id    pic xx. 
	 public  string Rat_6_trans_id { get; set;}
	 //    05  rat-6-record-type   pic x. 
	 public  string Rat_6_record_type { get; set;}
	 //    05  rat-6-amt-claims-adj   pic 9(7)v99. 
	 public  decimal Rat_6_amt_claims_adj { get; set;}
	 //    05  rat-6-amt-claims-adj-sgn  pic x. 
	 public  string Rat_6_amt_claims_adj_sgn { get; set;}
	 //    05  rat-6-amt-advances   pic 9(7)v99. 
	 public  decimal Rat_6_amt_advances { get; set;}
	 //    05  rat-6-amt-advances-sgn   pic x. 
	 public  string Rat_6_amt_advances_sgn { get; set;}
	 //    05  rat-6-amt-reductions   pic 9(7)v99. 
	 public  decimal Rat_6_amt_reductions { get; set;}
	 //    05  rat-6-amt-reductions-sgn  pic x. 
	 public  string Rat_6_amt_reductions_sgn { get; set;}
	 //    05  rat-6-amt-deductions   pic 9(7)v99. 
	 public  decimal Rat_6_amt_deductions { get; set;}
	 //    05  rat-6-amt-deductions-sgn  pic x. 
	 public  string Rat_6_amt_deductions_sgn { get; set;}
	 //    05  rat-6-filler    pic x(38). 
	 public  string Rat_6_filler { get; set;}

}
}
