using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Ru701_work_rec
    {
        	 //01  ru701-work-rec.       
	 //public  string Ru701_work_rec { get; set;}
	 //    05  ru701-sort-key.
	 public  string Ru701_sort_key { get; set;}
	 // 10  ru701-doc-nbr               pic x(3).
	 public  string Ru701_doc_nbr { get; set;}
	 //        10  ru701-clinic-nbr       pic x(2). 
	 public  string Ru701_clinic_nbr { get; set;}
	 //        10  ru701-doc-spec-cd   pic 9(2).
	 public  int Ru701_doc_spec_cd { get; set;}
	 //        10  ru701-pat-acronym               pic x(9).
	 public  string Ru701_pat_acronym { get; set;}
	 //        10  ru701-accounting-nbr  pic x(8).
	 public  string Ru701_accounting_nbr { get; set;}
	 //        10  ru701-orig-rec-no                 pic 9(5). 
	 public  int Ru701_orig_rec_no { get; set;}
	 //        10  ru701-acronym-flag                pic x.
	 public  string Ru701_acronym_flag { get; set;}
	 //        10  ru701-page-area                   pic x.
	 public  string Ru701_page_area { get; set;}
	 // 10  ru701-acronym   pic x(9).
	 public  string Ru701_acronym { get; set;}
	 // 10  ru701-line-no   pic 99.
	 public  int Ru701_line_no { get; set;}
	 //    05  ru701-print-line   pic x(132).
	 public  string Ru701_print_line { get; set;}

}
}
