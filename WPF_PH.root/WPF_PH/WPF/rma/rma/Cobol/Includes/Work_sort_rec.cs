using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Work_sort_rec
    {
        	 //01  work-sort-rec. 
	 //public  string Work_sort_rec { get; set;}
	 //  03  wf-sort-key. 
	 public  string Wf_sort_key { get; set;}
	 //    05  wf-dept     pic 99. 
	 public  int Wf_dept { get; set;}
	 //    05  wf-class-code    pic x. 
	 public  string Wf_class_code { get; set;}
	 //    05  wf-doc-nbr    pic x(3). 
	 public  string Wf_doc_nbr { get; set;}
	 //    05  wf-oma-cd. 
	 public  string Wf_oma_cd { get; set;}
	 // 10  wf-oma-code-ltr   pic x. 
	 public  string Wf_oma_code_ltr { get; set;}
	 // 10  filler    pic x(4). 
	 public  string Filler { get; set;}
	 //  03  wf-data. 
	 public  string Wf_data { get; set;}
	 //    05  wf-month-to-date. 
	 public  string Wf_month_to_date { get; set;}
	 // 10  wf-mtd-svcs    pic s9(8). 
	 public  int Wf_mtd_svcs { get; set;}
	 // 10  wf-mtd-amt    pic s9(9)v99. 
	 public  decimal Wf_mtd_amt { get; set;}
	 //    05  wf-year-to-date. 
	 public  string Wf_year_to_date { get; set;}
	 // 10  wf-ytd-svcs    pic s9(8). 
	 public  int Wf_ytd_svcs { get; set;}
	 // 10  wf-ytd-amt    pic s9(9)v99. 
	 public  decimal Wf_ytd_amt { get; set;}

}
}
