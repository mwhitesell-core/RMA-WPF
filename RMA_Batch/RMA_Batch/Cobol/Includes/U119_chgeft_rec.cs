using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class U119_chgeft_rec
    {

        public string w_doc_nbr { get; set; }

        public string filler_sign2 { get; set; }
        public int w_doc_dept { get; set; }
        public string filler_sign
        {
            get; set;
        }
        public decimal w_chgeft_amt_n { get; set; }

    }  
}
