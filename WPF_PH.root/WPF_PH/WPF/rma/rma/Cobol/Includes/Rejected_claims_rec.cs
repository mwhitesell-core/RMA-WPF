using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rejected_claims_rec
    {
        	 //01  rejected-claims-rec. 
	// public  string Rejected_claims_rec { get; set;}
	 //    05  claim-nbr    pic x(10). 
	 public  string Claim_nbr { get; set;}
	 //    05  doc-nbr                                 pic x(3). 
	 public  string Doc_nbr { get; set;}
	 //    05  clmhdr-pat-id                           pic x(16). 
	 public  string Clmhdr_pat_id { get; set;}
	 //    05  rejected-loc                            pic x(4). 
	 public  string Rejected_loc { get; set;}
	 //    05  mess-code                               pic x(3). 
	 public  string Mess_code { get; set;}
	 //    05  logically-deleted-flag   pic x.
	 public  string Logically_deleted_flag { get; set;}
	 //    05  clmhdr-submit-date        pic 9(8).
	 public  int Clmhdr_submit_date { get; set;}

}
}
