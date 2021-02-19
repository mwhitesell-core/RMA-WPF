using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Tp_pat_mstr_rec
    {
        	 //01 tp-pat-mstr-rec. 
	 //public  string Tp_pat_mstr_rec { get; set;}
	 //    05  tp-pat-func-code                pic xx. 
	 public  string Tp_pat_func_code { get; set;}
	 //    05  tp-pat-doctor-nbr  pic 9(6). 
	 public  int Tp_pat_doctor_nbr { get; set;}
	 //    05  tp-pat-account-id  pic x(08). 
	 public  string Tp_pat_account_id { get; set;}
	 //    05  tp-pat-subscr-surname. 
	 public  string Tp_pat_subscr_surname { get; set;}
	 // 10  tp-pat-subscr-surname-6 pic x(6). 
	 public  string Tp_pat_subscr_surname_6 { get; set;}
	 //  10  tp-pat-subscr-surname-18 pic x(19). 
	 public  string Tp_pat_subscr_surname_18 { get; set;}
	 //    05  tp-pat-first-name. 
	 public  string Tp_pat_first_name { get; set;}
	 // 10  tp-pat-first-name-3  pic x(3). 
	 public  string Tp_pat_first_name_3 { get; set;}
	 //  10  tp-pat-first-name-21 pic x(21). 
	 public  string Tp_pat_first_name_21 { get; set;}
	 //    05  tp-pat-birth-date               pic x(8). 
	 public  string Tp_pat_birth_date { get; set;}
	 //    05  tp-pat-birth-date-r   redefines tp-pat-birth-date. 
	 public  string Tp_pat_birth_date_r { get; set;}
	 //  10  tp-pat-birth-yy             pic 9999. 
	 public  int Tp_pat_birth_yy { get; set;}
	 //  10  tp-pat-birth-mm             pic 99. 
	 public  int Tp_pat_birth_mm { get; set;}
	 //  10  tp-pat-birth-dd             pic 99. 
	 public  int Tp_pat_birth_dd { get; set;}
	 //    05  tp-pat-sex                      pic x. 
	 public  string Tp_pat_sex { get; set;}
	 //    05  tp-pat-id-no                    pic x(9). 
	 public  string Tp_pat_id_no { get; set;}
	 //    05  tp-pat-id-no-r        redefines tp-pat-id-no. 
	 public  string Tp_pat_id_no_r { get; set;}
	 // 10  tp-pat-id-no-first-8-digits. 
	 public  string Tp_pat_id_no_first_8_digits { get; set;}
	 //            15  tp-pat-id-no-yy         pic 99. 
	 public  int Tp_pat_id_no_yy { get; set;}
	 //            15  tp-pat-id-no-mm         pic 99. 
	 public  int Tp_pat_id_no_mm { get; set;}
	 //      15  tp-pat-id-no-5-digit pic x. 
	 public  string Tp_pat_id_no_5_digit { get; set;}
	 //      15  tp-pat-id-no-6-7-digit pic 9(2). 
	 public  int Tp_pat_id_no_6_7_digit { get; set;}
	 //       15  tp-pat-id-no-8-digit    pic 9. 
	 public  int Tp_pat_id_no_8_digit { get; set;}
	 //  10  tp-pat-id-no-9-digit pic x. 
	 public  string Tp_pat_id_no_9_digit { get; set;}
	 //    05  tp-pat-street-addr              pic x(28). 
	 public  string Tp_pat_street_addr { get; set;}
	 //    05  tp-pat-city                     pic x(18). 
	 public  string Tp_pat_city { get; set;}
	 //    05  tp-pat-prov                     pic x(4). 
	 public  string Tp_pat_prov { get; set;}
	 //    05  tp-pat-postal-code              pic x(9). 
	 public  string Tp_pat_postal_code { get; set;}
	 //    05  tp-pat-postal-code-r     redefines tp-pat-postal-code. 
	 public  string Tp_pat_postal_code_r { get; set;}
	 //        10  tp-pat-postal-code-1 pic x. 
	 public  string Tp_pat_postal_code_1 { get; set;}
	 //        10  tp-pat-postal-code-2 pic x. 
	 public  string Tp_pat_postal_code_2 { get; set;}
	 //        10  tp-pat-postal-code-3 pic x. 
	 public  string Tp_pat_postal_code_3 { get; set;}
	 //        10  tp-pat-postal-code-4 pic x. 
	 public  string Tp_pat_postal_code_4 { get; set;}
	 //        10  tp-pat-postal-code-5 pic x. 
	 public  string Tp_pat_postal_code_5 { get; set;}
	 //        10  tp-pat-postal-code-6 pic x. 
	 public  string Tp_pat_postal_code_6 { get; set;}
	 // 10  filler   pic x(3).
	 public  string Filler { get; set;}
	 //    05  tp-pat-phone-no                 pic x(20). 
	 public  string Tp_pat_phone_no { get; set;}
	 //    05  tp-pat-ohip-health-no. 
	 public  string Tp_pat_ohip_health_no { get; set;}
	 //     10  tp-pat-health-no            pic x(10). 
	 public  string Tp_pat_health_no { get; set;}
	 // 10  tp-pat-ohip-filler  pic x(2). 
	 public  string Tp_pat_ohip_filler { get; set;}
	 //    05  tp-pat-version-cd.
	 public  string Tp_pat_version_cd { get; set;}
	 // 10  tp-pat-version-cd-1  pic x.
	 public  string Tp_pat_version_cd_1 { get; set;}
	 // 10  tp-pat-version-cd-2  pic x.
	 public  string Tp_pat_version_cd_2 { get; set;}
	 //    05  tp-pat-relationship  pic x(01). 
	 public  string Tp_pat_relationship { get; set;}
	 //    05  tp-pat-last-name  pic x(25). 
	 public  string Tp_pat_last_name { get; set;}
	 //    05  tp-pat-subscr-initials    pic x(3). 
	 public  string Tp_pat_subscr_initials { get; set;}
	 //    05  tp-pat-agent-cd   pic 9.
	 public  int Tp_pat_agent_cd { get; set;}
        public string seq_pat_doctor_nbr { get; set; }

    }
}
