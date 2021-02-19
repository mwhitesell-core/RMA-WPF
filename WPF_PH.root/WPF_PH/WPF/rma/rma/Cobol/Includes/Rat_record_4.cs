using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rat_record_4
    {        	
	 //    05  rat-4-trans-id    pic xx. 
	 public  string Rat_4_trans_id { get; set;}
	 //    05  rat-4-record-type   pic x. 
	 public  string Rat_4_record_type { get; set;}
	 //    05  rat-4-claim-nbr                  pic x(11). 
	 public  string Rat_4_claim_nbr { get; set;}
	 //    05  rat-4-trans-type   pic 9. 
	 public  int Rat_4_trans_type { get; set;}
	 //    05  rat-4-doc-nbr    pic 9(6). 
	 public  int Rat_4_doc_nbr { get; set;}
	 //    05  rat-4-specialty-cd     pic 99. 
	 public  int Rat_4_specialty_cd { get; set;}
	 //    05  rat-4-account-nbr        pic x(8). 
	 public  string Rat_4_account_nbr { get; set;}
	 //    05  rat-4-last-name    pic x(14). 
	 public  string Rat_4_last_name { get; set;}
	 //    05  rat-4-first-name            pic x(5). 
	 public  string Rat_4_first_name { get; set;}
	 //    05  rat-4-prov-cd    pic xx. 
	 public  string Rat_4_prov_cd { get; set;}
	 //    05  rat-4-health-ohip-nbr   pic x(12). 
	 public  string Rat_4_health_ohip_nbr { get; set;}
	 //    05  rat-4-version-cd   pic xx. 
	 public  string Rat_4_version_cd { get; set;}
	 //    05  rat-4-pay-prog    pic xxx. 
	 public  string Rat_4_pay_prog { get; set;}
	 //    05  rat-4-ministry-location-cd  pic x(4).
	 public  string Rat_4_ministry_location_cd { get; set;}
	 //    05  rat-4-filler                            pic x(8). 
	 public  string Rat_4_filler { get; set;}

}
}
