using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_r_record
    {
        	 //01  edt-r-record. 
	 //public  string Edt_r_record { get; set;}
	 //    05  edt-r-trans-id    pic xx. 
	 public  string Edt_r_trans_id { get; set;}
	 //    05  edt-r-record-type   pic x. 
	 public  string Edt_r_record_type { get; set;}
	 //    05  edt-r-registration-nbr    pic x(12).
	 public  string Edt_r_registration_nbr { get; set;}
	 //    05  edt-r-last-name    pic x(9).
	 public  string Edt_r_last_name { get; set;}
	 //    05  edt-r-first-name   pic x(5).
	 public  string Edt_r_first_name { get; set;}
	 //    05  edt-r-sex                pic x. 
	 public  string Edt_r_sex { get; set;}
	 //    05  edt-r-prov-cd     pic xx. 
	 public  string Edt_r_prov_cd { get; set;}
	 //    05  edt-r-filler                            pic x(32). 
	 public  string Edt_r_filler { get; set;}
	 //    05  edt-r-error-cd-1   pic x(3).
	 public  string Edt_r_error_cd_1 { get; set;}
	 //    05  edt-r-error-cd-2   pic x(3).
	 public  string Edt_r_error_cd_2 { get; set;}
	 //    05  edt-r-error-cd-3   pic x(3).
	 public  string Edt_r_error_cd_3 { get; set;}
	 //    05  edt-r-error-cd-4   pic x(3).
	 public  string Edt_r_error_cd_4 { get; set;}
	 //    05  edt-r-error-cd-5   pic x(3).
	 public  string Edt_r_error_cd_5 { get; set;}

}
}
