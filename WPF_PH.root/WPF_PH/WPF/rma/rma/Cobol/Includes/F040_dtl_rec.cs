using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class F040_dtl_rec
    {
        	 //01 f040-dtl-rec.   
	 //public  string F040_dtl_rec { get; set;}
	 //    05  oma-dept.
	 public  string Oma_dept { get; set;}
	 // 10  oma-cd    pic x(4).
	 public  string Oma_cd { get; set;}
	 // 10  dept-no     pic 99.   
	 public  int Dept_no { get; set;}
	 //        10  oma-doc-nbr    pic x(3).
	 public  string Oma_doc_nbr { get; set;}
	 //    05  data-entry-flag    pic x.
	 public  string Data_entry_flag { get; set;}

}
}
