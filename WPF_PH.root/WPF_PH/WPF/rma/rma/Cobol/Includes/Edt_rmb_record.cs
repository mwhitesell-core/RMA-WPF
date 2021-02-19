using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_rmb_record
    {
        	 //01  edt-rmb-record. 
	 //public  string Edt_rmb_record { get; set;}
	 //    05  edt-rmb-moh-off-cd                pic x. 
	 public  string Edt_rmb_moh_off_cd { get; set;}
	 //    05  edt-rmb-group-nbr   pic x(4). 
	 public  string Edt_rmb_group_nbr { get; set;}
	 //    05  edt-rmb-doc-nbr    pic 9(6).
	 public  int Edt_rmb_doc_nbr { get; set;}
	 //    05  edt-rmb-specialty-cd   pic xx.
	 public  string Edt_rmb_specialty_cd { get; set;}
	 //    05  edt-rmb-station-nbr      pic x(3).
	 public  string Edt_rmb_station_nbr { get; set;}
	 //    05  edt-rmb-process-date   pic 9(8). 
	 public  int Edt_rmb_process_date { get; set;}
	 //    05  edt-rmb-health-nbr    pic x(10). 
	 public  string Edt_rmb_health_nbr { get; set;}
	 //    05  edt-rmb-version-cd   pic xx. 
	 public  string Edt_rmb_version_cd { get; set;}
	 //    05  edt-rmb-birth-date        pic 9(8). 
	 public  int Edt_rmb_birth_date { get; set;}
	 //    05  edt-rmb-account-nbr       pic x(8). 
	 public  string Edt_rmb_account_nbr { get; set;}
	 //    05  edt-rmb-orig-seq-nbr      pic x(6). 
	 public  string Edt_rmb_orig_seq_nbr { get; set;}
	 //    05  edt-rmb-pay-prog              pic xxx. 
	 public  string Edt_rmb_pay_prog { get; set;}
	 //    05  edt-rmb-payee    pic x.
	 public  string Edt_rmb_payee { get; set;}
	 //    05  edt-rmb-refer-doc-nbr   pic 9(6). 
	 public  int Edt_rmb_refer_doc_nbr { get; set;}
	 //    05  edt-rmb-facility-nbr   pic x(4).
	 public  string Edt_rmb_facility_nbr { get; set;}
	 //    05  edt-rmb-admit-date   pic 9(8).
	 public  int Edt_rmb_admit_date { get; set;}
	 //    05  edt-rmb-loc-cd    pic x(4).
	 public  string Edt_rmb_loc_cd { get; set;}
	 //    05  edt-rmb-error-h-cd-1   pic x(3).
	 public  string Edt_rmb_error_h_cd_1 { get; set;}
	 //    05  edt-rmb-error-h-cd-2   pic x(3).
	 public  string Edt_rmb_error_h_cd_2 { get; set;}
	 //    05  edt-rmb-error-h-cd-3   pic x(3).
	 public  string Edt_rmb_error_h_cd_3 { get; set;}
	 //    05  edt-rmb-error-h-cd-4   pic x(3).
	 public  string Edt_rmb_error_h_cd_4 { get; set;}
	 //    05  edt-rmb-error-h-cd-5   pic x(3).
	 public  string Edt_rmb_error_h_cd_5 { get; set;}
	 //   05  edt-rmb-registration-nbr   pic x(12).
	 public  string Edt_rmb_registration_nbr { get; set;}
	 //   05  edt-rmb-last-name   pic x(9).
	 public  string Edt_rmb_last_name { get; set;}
	 //   05  edt-rmb-first-name   pic x(5).
	 public  string Edt_rmb_first_name { get; set;}
	 //   05  edt-rmb-sex    pic x.
	 public  string Edt_rmb_sex { get; set;}
	 //   05  edt-rmb-prov-cd    pic x(2).
	 public  string Edt_rmb_prov_cd { get; set;}
	 //   05  edt-rmb-error-r-cd-1   pic x(3).
	 public  string Edt_rmb_error_r_cd_1 { get; set;}
	 //   05  edt-rmb-error-r-cd-2   pic x(3).
	 public  string Edt_rmb_error_r_cd_2 { get; set;}
	 //   05  edt-rmb-error-r-cd-3   pic x(3).
	 public  string Edt_rmb_error_r_cd_3 { get; set;}
	 //   05  edt-rmb-error-r-cd-4   pic x(3).
	 public  string Edt_rmb_error_r_cd_4 { get; set;}
	 //   05  edt-rmb-error-r-cd-5   pic x(3).
	 public  string Edt_rmb_error_r_cd_5 { get; set;}
	 //    05  edt-rmb-service-cd   pic x(5). 
	 public  string Edt_rmb_service_cd { get; set;}
	 //    05  edt-rmb-amount-sub   pic 9(4)v99. 
	 public  decimal Edt_rmb_amount_sub { get; set;}
	 //    05  edt-rmb-nbr-of-serv   pic 99. 
	 public  int Edt_rmb_nbr_of_serv { get; set;}
	 //    05  edt-rmb-service-date                    pic 9(8). 
	 public  int Edt_rmb_service_date { get; set;}
	 //    05  edt-rmb-diag-cd                         pic x(4). 
	 public  string Edt_rmb_diag_cd { get; set;}
	 //    05  edt-rmb-t-explan-cd   pic xx. 
	 public  string Edt_rmb_t_explan_cd { get; set;}
	 //    05  edt-rmb-error-t-cd-1   pic x(3).
	 public  string Edt_rmb_error_t_cd_1 { get; set;}
	 //    05  edt-rmb-error-t-cd-2   pic x(3).
	 public  string Edt_rmb_error_t_cd_2 { get; set;}
	 //    05  edt-rmb-error-t-cd-3   pic x(3).
	 public  string Edt_rmb_error_t_cd_3 { get; set;}
	 //    05  edt-rmb-error-t-cd-4   pic x(3).
	 public  string Edt_rmb_error_t_cd_4 { get; set;}
	 //    05  edt-rmb-error-t-cd-5   pic x(3).
	 public  string Edt_rmb_error_t_cd_5 { get; set;}
	 //    05  edt-rmb-8-explan-cd   pic xx. 
	 public  string Edt_rmb_8_explan_cd { get; set;}
	 //    05  edt-rmb-8-explan-desc   pic x(55).
	 public  string Edt_rmb_8_explan_desc { get; set;}
	 //    05  edt-rmb-file-name   pic x(12).
	 public  string Edt_rmb_file_name { get; set;}

}
}
