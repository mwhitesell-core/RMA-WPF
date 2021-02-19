using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_t_record
    {
        	 //01  edt-t-record. 
	 //public  string Edt_t_record { get; set;}
	 //    05  edt-t-trans-id    pic xx. 
	 public  string Edt_t_trans_id { get; set;}
	 //    05  edt-t-record-type   pic x. 
	 public  string Edt_t_record_type { get; set;}
	 //    05  edt-t-service-cd   pic x(5). 
	 public  string Edt_t_service_cd { get; set;}
	 //    05  edt-t-filler-1    pic xx. 
	 public  string Edt_t_filler_1 { get; set;}
	 //    05  edt-t-amount-sub   pic 9(4)v99. 
	 public  decimal Edt_t_amount_sub { get; set;}
	 //    05  edt-t-nbr-of-serv   pic xx.
	 public  string Edt_t_nbr_of_serv { get; set;}
	 //    05  edt-t-service-date   pic x(8). 
	 public  string Edt_t_service_date { get; set;}
	 //    05  edt-t-diag-cd      pic x(4). 
	 public  string Edt_t_diag_cd { get; set;}
	 //    05  edt-t-filler-2    pic x(32). 
	 public  string Edt_t_filler_2 { get; set;}
	 //    05  edt-t-explan-cd    pic xx. 
	 public  string Edt_t_explan_cd { get; set;}
	 //    05  edt-t-error-cd-1   pic x(3).
	 public  string Edt_t_error_cd_1 { get; set;}
	 //    05  edt-t-error-cd-2   pic x(3).
	 public  string Edt_t_error_cd_2 { get; set;}
	 //    05  edt-t-error-cd-3   pic x(3).
	 public  string Edt_t_error_cd_3 { get; set;}
	 //    05  edt-t-error-cd-4   pic x(3).
	 public  string Edt_t_error_cd_4 { get; set;}
	 //    05  edt-t-error-cd-5   pic x(3).
	 public  string Edt_t_error_cd_5 { get; set;}

}
}
