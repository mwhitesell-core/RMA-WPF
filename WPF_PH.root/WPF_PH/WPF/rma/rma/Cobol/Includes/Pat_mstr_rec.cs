using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Pat_mstr_rec
    {
        	 //01 pat-mstr-rec.   
	 //public  string Pat_mstr_rec { get; set;}
	 //    05  pat-acronym.   
	 public  string Pat_acronym { get; set;}
	 // 10  pat-acronym-first6  pic x(6).   
	 public  string Pat_acronym_first6 { get; set;}
	 // 10  pat-acronym-last3  pic xxx.   
	 public  string Pat_acronym_last3 { get; set;}
	 //    05  pat-ohip-mmyy.   
	 public  string Pat_ohip_mmyy { get; set;}
	 //     10  pat-ohip-out-prov.   
	 public  string Pat_ohip_out_prov { get; set;}
	 //     15  pat-ohip-nbr  pic 9(8).   
	 public  int Pat_ohip_nbr { get; set;}
	 //     15  pat-mm   pic 99.   
	 public  int Pat_mm { get; set;}
	 //     15  pat-yy   pic 99.   
	 public  int Pat_yy { get; set;}
	 // 10  filler   pic x(3).   
	 public  string Filler { get; set;}
	 //    05  pat-ohip-mmyy-r  redefines pat-ohip-mmyy.   
	 public  string Pat_ohip_mmyy_r { get; set;}
	 //        10  pat-direct-alpha.   
	 public  string Pat_direct_alpha { get; set;}
	 //     15  pat-alpha1  pic x.   
	 public  string Pat_alpha1 { get; set;}
	 //     15  pat-alpha2-3  pic xx.   
	 public  string Pat_alpha2_3 { get; set;}
	 // 10  pat-direct-yy  pic xx.   
	 public  string Pat_direct_yy { get; set;}
	 // 10  pat-direct-mm  pic xx.   
	 public  string Pat_direct_mm { get; set;}
	 // 10  pat-direct-dd  pic xx.   
	 public  string Pat_direct_dd { get; set;}
	 //        10  pat-direct-filler        pic x(6).   
	 public  string Pat_direct_filler { get; set;}
	 //    05  pat-chart-nbr.   
	 public  string Pat_chart_nbr { get; set;}
	 // 10  pat-chart-1st-char  pic x.   
	 public  string Pat_chart_1st_char { get; set;}
	 // 10  pat-chart-remainder  pic x(9).
	 public  string Pat_chart_remainder { get; set;}
	 //    05  pat-chart-nbr-2.   
	 public  string Pat_chart_nbr_2 { get; set;}
	 // 10  pat-chart-1st-char  pic x.   
	// public  string Pat_chart_1st_char { get; set;}
	 // 10  pat-chart-remainder  pic x(9).
	 //public  string Pat_chart_remainder { get; set;}
	 //    05  pat-chart-nbr-3.   
	 public  string Pat_chart_nbr_3 { get; set;}
	 // 10  pat-chart-1st-char  pic x.   
	 //public  string Pat_chart_1st_char { get; set;}
	 // 10  pat-chart-remainder  pic x(9).
	 //public  string Pat_chart_remainder { get; set;}
	 //    05  pat-chart-nbr-4.   
	 public  string Pat_chart_nbr_4 { get; set;}
	 // 10  pat-chart-1st-char  pic x.   
	 //public  string Pat_chart_1st_char { get; set;}
	 // 10  pat-chart-remainder  pic x(9).
	 //public  string Pat_chart_remainder { get; set;}
	 //    05  pat-chart-nbr-5.   
	 public  string Pat_chart_nbr_5 { get; set;}
	 // 10  pat-chart-1st-char  pic x.   
	 //public  string Pat_chart_1st_char { get; set;}
	 // 10  pat-chart-remainder  pic x(10).
	 //public  string Pat_chart_remainder { get; set;}
	 //    05  pat-full-name.
	 public  string Pat_full_name { get; set;}
	 //        10  pat-surname   pic x(25).   
	 public  string Pat_surname { get; set;}
	 //        10  pat-surname-r  redefines  pat-surname.   
	 public  string Pat_surname_r { get; set;}
	 //     15  pat-surname-first6  pic x(6).   
	 public  string Pat_surname_first6 { get; set;}
	 //     15  pat-surname-last19 pic x(19). 
	 public  string Pat_surname_last19 { get; set;}
	 //        10  pat-surname-rr  redefines  pat-surname.   
	 public  string Pat_surname_rr { get; set;}
	 //     15  pat-surname-first3 pic x(3).   
	 public  string Pat_surname_first3 { get; set;}
	 //     15  pat-surname-last22 pic x(22).   
	 public  string Pat_surname_last22 { get; set;}
	 //        10  pat-given-name  pic x(17).   
	 public  string Pat_given_name { get; set;}
	 //        10  pat-given-name-r  redefines  pat-given-name.   
	 public  string Pat_given_name_r { get; set;}
	 //       15  pat-given-name-first3 pic xxx.   
	 public  string Pat_given_name_first3 { get; set;}
	 //     15  pat-given-name-last14 pic x(14).   
	 public  string Pat_given_name_last14 { get; set;}
	 //        10  pat-given-name-rr redefines pat-given-name-r.   
	 public  string Pat_given_name_rr { get; set;}
	 //     15  pat-given-name-first1 pic x.   
	 public  string Pat_given_name_first1 { get; set;}
	 //     15  filler   pic x(16).   
	 //public  string Filler { get; set;}
	 //    05  pat-init.   
	 public  string Pat_init { get; set;}
	 // 10  pat-init1   pic x.   
	 public  string Pat_init1 { get; set;}
	 // 10  pat-init2   pic x.   
	 public  string Pat_init2 { get; set;}
	 // 10  pat-init3   pic x.   
	 public  string Pat_init3 { get; set;}
	 //    05  pat-location-field.   
	 public  string Pat_location_field { get; set;}
	 // 10  pat-location-field-1-3 pic x(3).   
	 public  string Pat_location_field_1_3 { get; set;}
	 // 10  filler   pic x(1).   
	 //public  string Filler { get; set;}
	 //    05  pat-last-doc-nbr-seen  pic x(3).   
	 public  string Pat_last_doc_nbr_seen { get; set;}
	 //    05  pat-birth-date   pic 9(8).   
	 public  int Pat_birth_date { get; set;}
	 //    05  pat-birth-date-r  redefines  pat-birth-date.   
	 public  string Pat_birth_date_r { get; set;}
	 //        10  pat-birth-date-yy  pic 9999.   
	 public  int Pat_birth_date_yy { get; set;}
	 // 10  pat-birth-date-mm  pic 99.   
	 public  int Pat_birth_date_mm { get; set;}
	 // 10  pat-birth-date-dd  pic 99.   
	 public  int Pat_birth_date_dd { get; set;}
	 //    05  pat-date-last-maint             pic 9(8).   
	 public  int Pat_date_last_maint { get; set;}
	 //    05  pat-date-last-maint-r redefines pat-date-last-maint.   
	 public  string Pat_date_last_maint_r { get; set;}
	 // 10  pat-date-last-maint-yy pic 9999.   
	 public  int Pat_date_last_maint_yy { get; set;}
	 // 10  pat-date-last-maint-mm pic 99.   
	 public  int Pat_date_last_maint_mm { get; set;}
	 // 10  pat-date-last-maint-dd pic 99.   
	 public  int Pat_date_last_maint_dd { get; set;}
	 //    05  pat-date-last-visit   pic 9(8).   
	 public  int Pat_date_last_visit { get; set;}
	 //    05  pat-date-last-visit-r redefines pat-date-last-visit.   
	 public  string Pat_date_last_visit_r { get; set;}
	 // 10  pat-date-last-visit-yy pic 9999.   
	 public  int Pat_date_last_visit_yy { get; set;}
	 // 10  pat-date-last-visit-mm pic 99.   
	 public  int Pat_date_last_visit_mm { get; set;}
	 // 10  pat-date-last-visit-dd pic 99.   
	 public  int Pat_date_last_visit_dd { get; set;}
	 //    05  pat-date-last-admit   pic 9(8).   
	 public  int Pat_date_last_admit { get; set;}
	 //    05  pat-date-last-admit-r redefines pat-date-last-admit.   
	 public  string Pat_date_last_admit_r { get; set;}
	 // 10  pat-date-last-admit-yy pic 9999.   
	 public  int Pat_date_last_admit_yy { get; set;}
	 // 10  pat-date-last-admit-mm pic 99.   
	 public  int Pat_date_last_admit_mm { get; set;}
	 // 10  pat-date-last-admit-dd pic 99.   
	 public  int Pat_date_last_admit_dd { get; set;}
	 //     05  pat-phone-nbr.   
	 public  string Pat_phone_nbr { get; set;}
	 //  10  pat-phone-nbr-first3 pic 999.   
	 public  int Pat_phone_nbr_first3 { get; set;}
	 //  10  pat-phone-nbr-last4  pic 9(4).   
	 public  int Pat_phone_nbr_last4 { get; set;}
	 // 10  pat-phone-nbr-remainder pic x(13).
	 public  string Pat_phone_nbr_remainder { get; set;}
	 //    05  pat-total-nbr-visits  pic 9(5).   
	 public  int Pat_total_nbr_visits { get; set;}
	 //    05  pat-total-nbr-claims  pic 9(5).   
	 public  int Pat_total_nbr_claims { get; set;}
	 //    05  pat-sex    pic x.   
	 public  string Pat_sex { get; set;}
	 //    05  pat-in-out   pic x.   
	 public  string Pat_in_out { get; set;}
	 //    05  pat-nbr-outstanding-claims pic 9(4).   
	 public  int Pat_nbr_outstanding_claims { get; set;}
	 //    05  key-pat-mstr.   
	 public  string Key_pat_mstr { get; set;}
	 //        10  pat-i-key      pic x.   
	 public  string Pat_i_key { get; set;}
	 // 10  pat-con-nbr   pic 99.   
	 public  int Pat_con_nbr { get; set;}
	 // 10  pat-i-nbr   pic 9(12).   
	 public  int Pat_i_nbr { get; set;}
	 // 10  filler   pic x.   
	 //public  string Filler { get; set;}
	 //    05  pat-health-nbr                  pic 9(10).   
	 public  int Pat_health_nbr { get; set;}
	 //    05  pat-version-cd.
	 public  string Pat_version_cd { get; set;}
	 // 10  pat-version-cd-1  pic x.
	 public  string Pat_version_cd_1 { get; set;}
	 // 10  pat-version-cd-2  pic x.
	 public  string Pat_version_cd_2 { get; set;}
	 //    05  pat-health-65-ind               pic x.   
	 public  string Pat_health_65_ind { get; set;}
	 //    05  pat-expiry-date.   
	 public  string Pat_expiry_date { get; set;}
	 //        10  pat-expiry-yy               pic 99.  
	 public  int Pat_expiry_yy { get; set;}
	 //        10  pat-expiry-mm               pic 99.   
	 public  int Pat_expiry_mm { get; set;}
	 //    05  pat-prov-cd                     pic xx.   
	 public  string Pat_prov_cd { get; set;}
	 //    05  subscr-addr1   pic x(30).   
	 public  string Subscr_addr1 { get; set;}
	 //    05  subscr-addr2   pic x(30).   
	 public  string Subscr_addr2 { get; set;}
	 //    05  subscr-addr3   pic x(30).   
	 public  string Subscr_addr3 { get; set;}
	 //    05  subscr-prov-cd                  pic xx.   
	 public  string Subscr_prov_cd { get; set;}
	 //    05  subscr-postal-cd  pic x(10).   
	 public  string Subscr_postal_cd { get; set;}
	 //    05  subscr-postal-cd-r  redefines  subscr-postal-cd.   
	 public  string Subscr_postal_cd_r { get; set;}
	 // 10  subscr-post-code1.   
	 public  string Subscr_post_code1 { get; set;}
	 //     15  subscr-post-cd1  pic x.   
	 public  string Subscr_post_cd1 { get; set;}
	 //     15  subscr-post-cd2  pic 9.   
	 public  string Subscr_post_cd2 { get; set;}
	 //     15  subscr-post-cd3  pic x.   
	 public  string Subscr_post_cd3 { get; set;}
	 // 10  subscr-post-code2.   
	 public  string Subscr_post_code2 { get; set;}
	 //     15  subscr-post-cd4  pic 9.   
	 public  string Subscr_post_cd4 { get; set;}
	 //     15  subscr-post-cd5  pic x.   
	 public  string Subscr_post_cd5 { get; set;}
	 //     15  subscr-post-cd6  pic 9.   
	 public  string Subscr_post_cd6 { get; set;}
	 // 10  filler   pic x(4).
	 //public  string Filler { get; set;}
	 //    05  subscr-msg-data.   
	 public  string Subscr_msg_data { get; set;}
	 //        10  subscr-msg-nbr  pic xx.   
	 public  string Subscr_msg_nbr { get; set;}
	 //        10  subscr-date-msg-nbr-eff-to  pic 9(8).   
	 public  int Subscr_date_msg_nbr_eff_to { get; set;}
	 //        10  subscr-date-msg-nbr-eff-to-r                  redefines subscr-date-msg-nbr-eff-to.   
	 public  string Subscr_date_msg_nbr_eff_to_r { get; set;}
	 //     15  subscr-date-msg-nbr-eff-to-yy  pic 9999.   
	 public  int Subscr_date_msg_nbr_eff_to_yy { get; set;}
	 //     15  subscr-date-msg-nbr-eff-to-mm  pic 99.   
	 public  int Subscr_date_msg_nbr_eff_to_mm { get; set;}
	 //         15  subscr-date-msg-nbr-eff-to-dd  pic 99.   
	 public  int Subscr_date_msg_nbr_eff_to_dd { get; set;}
	 //        10  subscr-date-msg-nbr-eff-to-r1                 redefines subscr-date-msg-nbr-eff-to-r          pic x(8).   
	 public  string Subscr_date_msg_nbr_eff_to_r1 { get; set;}
	 //        10  subscr-date-last-statement  pic 9(8).   
	 public  int Subscr_date_last_statement { get; set;}
	 //        10  subscr-date-last-statement-r           redefines subscr-date-last-statement.   
	 public  string Subscr_date_last_statement_r { get; set;}
	 //     15  subscr-date-last-statement-yy  pic 9999.   
	 public  int Subscr_date_last_statement_yy { get; set;}
	 //     15  subscr-date-last-statement-mm  pic 99.   
	 public  int Subscr_date_last_statement_mm { get; set;}
	 //     15  subscr-date-last-statement-dd  pic 99.   
	 public  int Subscr_date_last_statement_dd { get; set;}
	 //    05  subscr-auto-update    pic x.   
	 public  string Subscr_auto_update { get; set;}
	 //    05  pat-last-mod-by     pic x(5).
	 public  string Pat_last_mod_by { get; set;}
	 //    05  pat-date-last-elig-mailing                      pic 9(8).
	 public  int Pat_date_last_elig_mailing { get; set;}
	 //    05  pat-date-last-elig-maint                        pic 9(8).
	 public  int Pat_date_last_elig_maint { get; set;}
	 //    05  pat-last-birth-date                             pic 9(8).
	 public  int Pat_last_birth_date { get; set;}
	 //    05  pat-last-version-cd                             pic x(2).   
	 public  string Pat_last_version_cd { get; set;}
	 //    05  pat-mess-code                                   pic x(3).   
	 public  string Pat_mess_code { get; set;}
	 //    05  pat-country                                     pic x(1).   
	 public  string Pat_country { get; set;}
	 //    05  pat-no-of-letter-sent                           pic 99.   
	 public  int Pat_no_of_letter_sent { get; set;}
	 //    05  pat-dialysis              pic x(1).   
	 public  string Pat_dialysis { get; set;}
	 //    05  pat-ohip-validiation-status                     pic x.
	 public  string Pat_ohip_validiation_status { get; set;}
	 //    05  pat-obec-status           pic x(1).   
	 public  string Pat_obec_status { get; set;}

}
}
