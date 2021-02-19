using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class U119_payeft_rec
    {
        // 05   w-doc-nbr pic x(3). 
        public string w_doc_nbr { get; set; }
        //05   filler-sign2 pic x(1).
        public string filler_sign2 { get; set; }
        //05   w-doc-dept pic 9(2). 
        public int w_doc_dept { get; set; }
        // 05   filler-sign pic x(01). 
        public string filler_sign { get; set; }
        // 05   w-payeft-amt-n pic 9(13)v99.
        public decimal w_payeft_amt_n { get; set; }
    }
}
