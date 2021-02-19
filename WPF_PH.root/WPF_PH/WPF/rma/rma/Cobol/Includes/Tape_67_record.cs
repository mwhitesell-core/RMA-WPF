using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Tape_67_record
    {        	
	 //    05  rat-67-amt-claims-adj   pic s9(7)v99. 
	 public  decimal Rat_67_amt_claims_adj { get; set;}
	 //    05  rat-67-amt-advances   pic s9(7)v99. 
	 public  decimal Rat_67_amt_advances { get; set;}
	 //    05  rat-67-amt-reductions   pic s9(7)v99. 
	 public  decimal Rat_67_amt_reductions { get; set;}
	 //    05  rat-67-amt-deductions   pic s9(7)v99. 
	 public  decimal Rat_67_amt_deductions { get; set;}
	 //    05  rat-67-trans-cd    pic xx. 
	 public  string Rat_67_trans_cd { get; set;}
	 //    05  rat-67-cheque-ind   pic x. 
	 public  string Rat_67_cheque_ind { get; set;}
	 //    05  rat-67-trans-date                   pic 9(8). 
	 public  int Rat_67_trans_date { get; set;}
	 //    05  rat-67-trans-amt   pic s9(6)v99. 
	 public  decimal Rat_67_trans_amt { get; set;}
	 //    05  rat-67-trans-message      pic x(50). 
	 public  string Rat_67_trans_message { get; set;}
	 //    05  rat-67-total-clinic-amt   pic s9(7)v99. 
	 public  decimal Rat_67_total_clinic_amt { get; set;}
	 //    05  rat-67-amt-bill                pic s9(7)v99. 
	 public  decimal Rat_67_amt_bill { get; set;}
	 //    05  rat-67-amt-paid                pic s9(7)v99. 
	 public  decimal Rat_67_amt_paid { get; set;}

}
}
