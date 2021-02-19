using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtest
{
    public class F011_pat_mstr_elig_history_rec
    {
        	 //01 f011-pat-mstr-elig-history-rec.
	 //public  string F011_pat_mstr_elig_history_rec { get; set;}
	 //    05 pat-elig-history-key.
	 public  string Pat_elig_history_key { get; set;}
	 // 10  key-pat-mstr.
	 public  string Key_pat_mstr { get; set;}
	 //            15  pat-i-key                   pic x.
	 public  string Pat_i_key { get; set;}
	 //            15  pat-con-nbr                 pic 99.
	 public  int Pat_con_nbr { get; set;}
	 //            15  pat-i-nbr                   pic 9(12).
	 public  int Pat_i_nbr { get; set;}
	 //            15  filler                      pic x.
	 public  string Filler { get; set;}
	 // 10  pat-date-last-maint             pic 9(8).
	 public  int Pat_date_last_maint { get; set;}
	 // 10  pat-time-last-maint             pic 9(8).
	 public  int Pat_time_last_maint { get; set;}
	 //    05  pat-expiry-date.
	 public  string Pat_expiry_date { get; set;}
	 //        10  pat-expiry-yy               pic 99.
	 public  int Pat_expiry_yy { get; set;}
	 //        10  pat-expiry-mm               pic 99.
	 public  int Pat_expiry_mm { get; set;}
	 //    05  pat-health-nbr                  pic 9(10).
	 public  int Pat_health_nbr { get; set;}
	 //    05  pat-health-nbr-last             pic 9(10).
	 public  int Pat_health_nbr_last { get; set;}
	 //    05  pat-version-cd.
	 public  string Pat_version_cd { get; set;}
	 //        10  pat-version-cd-1            pic x.
	 public  string Pat_version_cd_1 { get; set;}
	 //        10  pat-version-cd-2            pic x.
	 public  string Pat_version_cd_2 { get; set;}
	 //    05  pat-version-cd-last  pic x(2).
	 public  string Pat_version_cd_last { get; set;}
	 //    05  pat-birth-date   pic 9(8).
	 public  int Pat_birth_date { get; set;}
	 //    05  pat-birth-date-last   pic 9(8).
	 public  int Pat_birth_date_last { get; set;}

}
}
