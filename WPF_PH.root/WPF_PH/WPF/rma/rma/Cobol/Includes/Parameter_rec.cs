using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Parameter_rec
    {
        	 //01  parameter-rec. 
	 //public  string Parameter_rec { get; set;}
	 //    05  parms-1.
	 public  string Parms_1 { get; set;}
	 //        10  parameter-type   pic x.
	 public  string Parameter_type { get; set;}
	 //        10  parameter-batch-nbr   pic x(08).
	 public  string Parameter_batch_nbr { get; set;}
	 //        10  parameter-claim-nbr   pic 9(02).
	 public  int Parameter_claim_nbr { get; set;}
	 // 10  filler    pic x(08).
	 public  string Filler { get; set;}
	 //    05  parms-2 redefines parms-1.
	 public  string Parms_2 { get; set;}
	 // 10  parameter-pat-ikey.
	 public  string Parameter_pat_ikey { get; set;}
	 //            15 parameter-pat-key-type  pic x(01).
	 public  string Parameter_pat_key_type { get; set;}
	 //     15 parameter-pat-key-data  pic x(15).
	 public  string Parameter_pat_key_data { get; set;}
	 //        10  filler    pic x(04).
	// public  string Filler { get; set;}

}
}
