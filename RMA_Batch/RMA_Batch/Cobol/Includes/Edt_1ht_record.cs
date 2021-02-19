using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_1ht_record
    {
        	 //01  edt-1ht-record. 
	 //public  string Edt_1ht_record { get; set;}
	 //    05  edt-1ht-moh-off-cd                pic x. 
	 public  string Edt_1ht_moh_off_cd { get; set;}
	 //    05  edt-1ht-group-nbr   pic x(4). 
	 public  string Edt_1ht_group_nbr { get; set;}
	 //    05  edt-1ht-doc-nbr    pic 9(6).
	 public  int Edt_1ht_doc_nbr { get; set;}
	 //    05  edt-1ht-specialty-cd   pic xx.
	 public  string Edt_1ht_specialty_cd { get; set;}
	 //    05  edt-1ht-station-nbr       pic x(3).
	 public  string Edt_1ht_station_nbr { get; set;}
	 //    05  edt-1ht-process-date   pic 9(8). 
	 public  int Edt_1ht_process_date { get; set;}
	 //    05  edt-1ht-health-nbr    pic x(10). 
	 public  string Edt_1ht_health_nbr { get; set;}
	 //    05  edt-1ht-version-cd   pic xx. 
	 public  string Edt_1ht_version_cd { get; set;}
	 //    05  edt-1ht-birth-date        pic 9(8). 
	 public  int Edt_1ht_birth_date { get; set;}
	 //    05  edt-1ht-account-nbr       pic x(8). 
	 public  string Edt_1ht_account_nbr { get; set;}
	 //    05  edt-1ht-orig-seq-nbr      pic 9(6). 
	 public  int Edt_1ht_orig_seq_nbr { get; set;}
	 //    05  edt-1ht-pay-prog              pic xxx. 
	 public  string Edt_1ht_pay_prog { get; set;}
	 //    05  edt-1ht-payee    pic x.
	 public  string Edt_1ht_payee { get; set;}
	 //    05  edt-1ht-refer-doc-nbr   pic 9(6). 
	 public  int Edt_1ht_refer_doc_nbr { get; set;}
	 //    05  edt-1ht-facility-nbr   pic x(4).
	 public  string Edt_1ht_facility_nbr { get; set;}
	 //    05  edt-1ht-admit-date   pic 9(8).
	 public  int Edt_1ht_admit_date { get; set;}
	 //    05  edt-1ht-loc-cd    pic x(4).
	 public  string Edt_1ht_loc_cd { get; set;}
	 //    05  edt-1ht-error-h-cd-1   pic x(3).
	 public  string Edt_1ht_error_h_cd_1 { get; set;}
	 //    05  edt-1ht-error-h-cd-2   pic x(3).
	 public  string Edt_1ht_error_h_cd_2 { get; set;}
	 //    05  edt-1ht-error-h-cd-3   pic x(3).
	 public  string Edt_1ht_error_h_cd_3 { get; set;}
	 //    05  edt-1ht-error-h-cd-4   pic x(3).
	 public  string Edt_1ht_error_h_cd_4 { get; set;}
	 //    05  edt-1ht-error-h-cd-5   pic x(3).
	 public  string Edt_1ht_error_h_cd_5 { get; set;}
	 //    05  edt-1ht-service-cd   pic x(5). 
	 public  string Edt_1ht_service_cd { get; set;}
	 //    05  edt-1ht-amount-sub   pic 9(4)v99. 
	 public  decimal Edt_1ht_amount_sub { get; set;}
	 //    05  edt-1ht-nbr-of-serv   pic 99. 
	 public  int Edt_1ht_nbr_of_serv { get; set;}
	 //    05  edt-1ht-service-date                    pic 9(8). 
	 public  int Edt_1ht_service_date { get; set;}
	 //    05  edt-1ht-diag-cd                         pic x(4). 
	 public  string Edt_1ht_diag_cd { get; set;}
	 //    05  edt-1ht-t-explan-cd   pic xx. 
	 public  string Edt_1ht_t_explan_cd { get; set;}
	 //    05  edt-1ht-error-t-cd-1   pic x(3).
	 public  string Edt_1ht_error_t_cd_1 { get; set;}
	 //    05  edt-1ht-error-t-cd-2   pic x(3).
	 public  string Edt_1ht_error_t_cd_2 { get; set;}
	 //    05  edt-1ht-error-t-cd-3   pic x(3).
	 public  string Edt_1ht_error_t_cd_3 { get; set;}
	 //    05  edt-1ht-error-t-cd-4   pic x(3).
	 public  string Edt_1ht_error_t_cd_4 { get; set;}
	 //    05  edt-1ht-error-t-cd-5   pic x(3).
	 public  string Edt_1ht_error_t_cd_5 { get; set;}
	 //    05  edt-1ht-8-explan-cd   pic xx. 
	 public  string Edt_1ht_8_explan_cd { get; set;}
	 //    05  edt-1ht-8-explan-desc   pic x(55).
	 public  string Edt_1ht_8_explan_desc { get; set;}
	 //    05  edt-1ht-file-name   pic x(12).
	 public  string Edt_1ht_file_name { get; set;}

}
}
