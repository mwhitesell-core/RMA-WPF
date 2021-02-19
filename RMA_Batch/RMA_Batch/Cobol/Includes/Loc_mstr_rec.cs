using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Loc_mstr_rec
    {        	
	 //    05  loc-nbr    pic x999.     
	 public  string Loc_nbr { get; set;}
	 //    05  loc-nbr-r     redefines loc-nbr  pic x(4).  
	 public  string Loc_nbr_r { get; set;}
	 //    05  loc-clinic-nbr   pic 9(4).  
	 public  int Loc_clinic_nbr { get; set;}
	 //    05  loc-hospital-nbr  pic 9(4).  
	 public  int Loc_hospital_nbr { get; set;}
	 //    05  loc-hospital-code  pic x(4).
	 public  string Loc_hospital_code { get; set;}
	 //    05  loc-card-colour   pic x(1).  
	 public  string Loc_card_colour { get; set;}
	 //    05  loc-in-out-ind redefines loc-card-colour      pic x(1).
	 public  string Loc_in_out_ind { get; set;}
	 //    05  loc-name   pic x(24).  
	 public  string Loc_name { get; set;}
	 //    05  loc-ministry-loc-code  pic 9(4).
	 public  int Loc_ministry_loc_code { get; set;}
	 //    05  loc-payroll-flag  pic x(1).
	 public  string Loc_payroll_flag { get; set;}
	 //    05  loc-active-for-entry  pic x(1). 
	 public  string Loc_active_for_entry { get; set;}
	 //    05  loc-service-location-indicator  pic x(4).
	 public  string Loc_service_location_indicator { get; set;}
	 //    05  filler-reserved-for-nip  pic x(9).
	 public  string Filler_reserved_for_nip { get; set;}

}
}
