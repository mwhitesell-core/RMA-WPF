using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Suspend_desc_rec
    {
        	 //01  suspend-desc-rec.
	 //public  string Suspend_desc_rec { get; set;}
	 //    05  clmdtl-suspend-desc   pic x(70).
	 public  string Clmdtl_suspend_desc { get; set;}
	 //    05  clmdtl-status                           pic x.
	 public  string Clmdtl_status { get; set;}
	 //    05  suspend-dtl-id.
	 public  string Suspend_dtl_id { get; set;}
	 //        10  clmdtl-doc-pract-nbr                pic 9(6).
	 public  int Clmdtl_doc_pract_nbr { get; set;}
	 //        10  clmdtl-accounting-nbr               pic x(8).
	 public  string Clmdtl_accounting_nbr { get; set;}
	 //        10  clmdtl-line-no   pic 99.
	 public  int Clmdtl_line_no { get; set;}

}
}
