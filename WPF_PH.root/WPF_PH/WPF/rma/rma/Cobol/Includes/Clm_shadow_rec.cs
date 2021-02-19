using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Clm_shadow_rec
    {
        	 //01 clm-shadow-rec.
	 //public  string Clm_shadow_rec { get; set;}
	 //    05  clm-shadow-key.
	 public  string Clm_shadow_key { get; set;}
	 //        10  clm-shadow-clinic                   pic 99.
	 public  int Clm_shadow_clinic { get; set;}
	 //        10  clm-shadow-subdivision              pic x.
	 public  string Clm_shadow_subdivision { get; set;}
	 //        10  clm-shadow-patient.
	 public  string Clm_shadow_patient { get; set;}
	 //            15  clm-shadow-pat-key-type         pic a.
	 public  string Clm_shadow_pat_key_type { get; set;}
	 //            15  clm-shadow-pat-key-data.
	 public  string Clm_shadow_pat_key_data { get; set;}
	 //                20  clm-shadow-pat-key-ohip     pic x(08).
	 public  string Clm_shadow_pat_key_ohip { get; set;}
	 //                20  filler                      pic x(07).
	 public  string Filler { get; set;}
	 //        10  clm-shadow-batch-nbr                pic x(08).
	 public  string Clm_shadow_batch_nbr { get; set;}
	 //        10  clm-shadow-claim-nbr                pic 9(02).
	 public  int Clm_shadow_claim_nbr { get; set;}

}
}
