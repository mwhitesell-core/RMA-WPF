using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Docash_master_rec
    {
        	 //01  docash-master-rec. 
	// public  string Docash_master_rec { get; set;}
	 //    05  docash-key. 
	 public  string Docash_key { get; set;}
	 // 10  docash-clinic-1-2  pic x(2). 
	 public  string Docash_clinic_1_2 { get; set;}
	 // 10  docash-dept   pic 99. 
	 public  int Docash_dept { get; set;}
	 // 10  docash-doc-nbr  pic xxx. 
	 public  string Docash_doc_nbr { get; set;}
	 // 10  docash-location  pic x999. 
	 public  string Docash_location { get; set;}
	 // 10  docash-agency-type  pic x. 
	 public  string Docash_agency_type { get; set;}
	 //    05  docash-month-to-date. 
	 public  string Docash_month_to_date { get; set;}
	 // 10  docash-mtd-in-rec  pic s9(6)v99. 
	 public  decimal Docash_mtd_in_rec { get; set;}
	 // 10  docash-mtd-in-svc  pic s9(3). 
	 public  int Docash_mtd_in_svc { get; set;}
	 //    05  docash-year-to-date. 
	 public  string Docash_year_to_date { get; set;}
	 // 10  docash-ytd-in-rec  pic s9(7)v99.   
	 public  decimal Docash_ytd_in_rec { get; set;}
	 // 10  docash-ytd-in-svc  pic s9(5). 
	 public  int Docash_ytd_in_svc { get; set;}
	 // 10  filler   pic x(9).
	 public  string Filler { get; set;}

}
}
