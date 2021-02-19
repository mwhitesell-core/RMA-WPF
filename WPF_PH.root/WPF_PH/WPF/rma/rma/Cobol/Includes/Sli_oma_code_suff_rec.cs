using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Sli_oma_code_suff_rec
    {
        	 //01  sli-oma-code-suff-rec.
	// public  string Sli_oma_code_suff_rec { get; set;}
	 //    05  sli-oma-code-suff.
	 public  string Sli_oma_code_suff { get; set;}
	 //        10  sli-oma-code          pic x(4).
	 public  string Sli_oma_code { get; set;}
	 // 10  sli-oma-suff                        pic x(1).      
	 public  string Sli_oma_suff { get; set;}
	 // 10  sli-code                            pic x(4).
	 public  string Sli_code { get; set;}
	 //    05  sli-admit-ind              pic x(1).  
	 public  string Sli_admit_ind { get; set;}

}
}
