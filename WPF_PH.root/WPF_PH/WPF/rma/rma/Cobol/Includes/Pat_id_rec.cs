using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Pat_id_rec
    {
        	 //01 pat-id-rec.  
	// public  string Pat_id_rec { get; set;}
	 //    05  clmhdr-pat-ohip-id-or-chart             pic x(16).  
	 public  string Clmhdr_pat_ohip_id_or_chart { get; set;}
	 //    05  pat-last-birth-date                     pic 9(8).
	 public  int Pat_last_birth_date { get; set;}
	 //    05  pat-last-version-cd                     pic xx.  
	 public  string Pat_last_version_cd { get; set;}
	 //    05  pat-old-surname                         pic x(25).  
	 public  string Pat_old_surname { get; set;}
	 //    05  pat-old-given-name                      pic x(17).  
	 public  string Pat_old_given_name { get; set;}
	 //    05  pat-old-health-nbr                      pic 9(10).  
	 public  int Pat_old_health_nbr { get; set;}
	 //    05  pat-old-chart-nbr                       pic x(10).  
	 public  string Pat_old_chart_nbr { get; set;}
	 //    05  pat-old-chart-nbr-2                     pic x(10).  
	 public  string Pat_old_chart_nbr_2 { get; set;}
	 //    05  pat-old-chart-nbr-3                     pic x(10).  
	 public  string Pat_old_chart_nbr_3 { get; set;}
	 //    05  pat-old-chart-nbr-4                     pic x(10).  
	 public  string Pat_old_chart_nbr_4 { get; set;}
	 //    05  pat-old-chart-nbr-5                     pic x(11).  
	 public  string Pat_old_chart_nbr_5 { get; set;}
	 //    05  pat-old-addr1                           pic x(21).  
	 public  string Pat_old_addr1 { get; set;}
	 //    05  pat-old-addr2                           pic x(21).  
	 public  string Pat_old_addr2 { get; set;}
	 //    05  pat-old-addr3                           pic x(21).  
	 public  string Pat_old_addr3 { get; set;}

}
}
