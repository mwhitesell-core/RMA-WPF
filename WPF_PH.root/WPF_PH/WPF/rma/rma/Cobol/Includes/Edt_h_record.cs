using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_h_record
    {
        	 //01  edt-h-record. 
	 //public  string Edt_h_record { get; set;}
	 //    05  edt-h-trans-id    pic xx. 
	 public  string Edt_h_trans_id { get; set;}
	 //    05  edt-h-record-type   pic x. 
	 public  string Edt_h_record_type { get; set;}
	 //    05  edt-h-health-nbr   pic x(10). 
	 public  string Edt_h_health_nbr { get; set;}
	 //    05  edt-h-version-cd   pic xx. 
	 public  string Edt_h_version_cd { get; set;}
	 //    05  edt-h-birth-date   pic x(8).
	 public  string Edt_h_birth_date { get; set;}
	 //    05  edt-h-account-nbr        pic x(8). 
	 public  string Edt_h_account_nbr { get; set;}
	 //    05  edt-h-pay-prog    pic xxx. 
	 public  string Edt_h_pay_prog { get; set;}
	 //    05  edt-h-payee        pic x. 
	 public  string Edt_h_payee { get; set;}
	 //    05  edt-h-doc-nbr    pic 9(6). 
	 public  int Edt_h_doc_nbr { get; set;}
	 //    05  edt-h-facility-nbr   pic x(4).
	 public  string Edt_h_facility_nbr { get; set;}
	 //    05  edt-h-patient-admission-date  pic 9(8).
	 public  int Edt_h_patient_admission_date { get; set;}
	 //    05  edt-h-refer-licence-nbr   pic x(4).
	 public  string Edt_h_refer_licence_nbr { get; set;}
	 //    05  edt-h-location-cd   pic x(4).
	 public  string Edt_h_location_cd { get; set;}
	 //    05  edt-h-filler                            pic x(3). 
	 public  string Edt_h_filler { get; set;}
	 //    05  edt-h-error-cd-1   pic x(3).
	 public  string Edt_h_error_cd_1 { get; set;}
	 //    05  edt-h-error-cd-2   pic x(3).
	 public  string Edt_h_error_cd_2 { get; set;}
	 //    05  edt-h-error-cd-3   pic x(3).
	 public  string Edt_h_error_cd_3 { get; set;}
	 //    05  edt-h-error-cd-4   pic x(3).
	 public  string Edt_h_error_cd_4 { get; set;}
	 //    05  edt-h-error-cd-5   pic x(3).
	 public  string Edt_h_error_cd_5 { get; set;}

}
}
