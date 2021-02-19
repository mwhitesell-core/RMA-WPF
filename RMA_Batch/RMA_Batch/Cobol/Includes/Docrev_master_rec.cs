using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Docrev_master_rec
    {        	 
	 //    05  docrev-key. 
	 public  string Docrev_key { get; set;}
	 // 10  docrev-clinic-1-2  pic x(2). 
	 public  string Docrev_clinic_1_2 { get; set;}
	 // 10  docrev-dept   pic 99. 
	 public  int Docrev_dept { get; set;}
	 // 10  docrev-doc-nbr  pic xxx. 
	 public  string Docrev_doc_nbr { get; set;}
	 // 10  docrev-location  pic x999. 
	 public  string Docrev_location { get; set;}
	 // 10  docrev-oma-cd  pic x(5). 
	 public  string Docrev_oma_cd { get; set;}
	 // 10  docrev-oma-cd-r redefines docrev-oma-cd. 
	 public  string Docrev_oma_cd_r { get; set;}
	 //     15 docrev-oma-code  pic x(4). 
	 public  string Docrev_oma_code { get; set;}
	 //     15 docrev-oma-suff  pic x. 
	 public  string Docrev_oma_suff { get; set;}
	 //     15 docrev-adj-cd-sub-type redefines docrev-oma-suff       pic x. 
	 public  string Docrev_adj_cd_sub_type { get; set;}
	 //    05  docrev-month-to-date. 
	 public  string Docrev_month_to_date { get; set;}
	 // 10  docrev-mtd-in-rec  pic s9(6)v99. 
	 public  decimal Docrev_mtd_in_rec { get; set;}
	 // 10  docrev-mtd-in-svc  pic s9(4). 
	 public  int Docrev_mtd_in_svc { get; set;}
	 // 10  docrev-mtd-out-rec  pic s9(6)v99. 
	 public  decimal Docrev_mtd_out_rec { get; set;}
	 // 10  docrev-mtd-out-svc  pic s9(4).  
	 public  int Docrev_mtd_out_svc { get; set;}
	 //    05  docrev-year-to-date. 
	 public  string Docrev_year_to_date { get; set;}
	 // 10  docrev-ytd-in-rec  pic s9(6)v99.   
	 public  decimal Docrev_ytd_in_rec { get; set;}
	 // 10  docrev-ytd-in-svc  pic s9(5). 
	 public  int Docrev_ytd_in_svc { get; set;}
	 // 10  docrev-ytd-out-rec  pic s9(6)v99.   
	 public  decimal Docrev_ytd_out_rec { get; set;}
	 // 10  docrev-ytd-out-svc  pic s9(5).  
	 public  int Docrev_ytd_out_svc { get; set;}

}
}
