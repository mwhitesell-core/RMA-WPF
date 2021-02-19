using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Diskout_output_rec
    {
        	 //01  diskout-output-rec. 
	 //public  string Diskout_output_rec { get; set;}
	 // 10  diskout-clmhdr-clinic-nbr  pic x(2).
	 public  string Diskout_clmhdr_clinic_nbr { get; set;}
	 //        10  diskout-clmhdr-claim  pic x(8). 
	 public  string Diskout_clmhdr_claim { get; set;}
	 //        10  diskout-oma-svc-cd. 
	 public  string Diskout_oma_svc_cd { get; set;}
	 //            15  diskout-oma-svc-code         pic x(4). 
	 public  string Diskout_oma_svc_code { get; set;}
	 //            15  diskout-oma-svc-suff         pic x. 
	 public  string Diskout_oma_svc_suff { get; set;}
	 //        10  diskout-ohip-amt-billed         pic 9(4)v99. 
	 public  decimal Diskout_ohip_amt_billed { get; set;}
	 //        10  diskout-svc-date. 
	 public  string Diskout_svc_date { get; set;}
	 //            15  diskout-svc-date-yy         pic 9(4). 
	 public  int Diskout_svc_date_yy { get; set;}
	 //            15  diskout-svc-date-mm         pic 99. 
	 public  int Diskout_svc_date_mm { get; set;}
	 //            15  diskout-svc-date-dd         pic 99. 
	 public  int Diskout_svc_date_dd { get; set;}
	 //        10  diskout-nbr-serv                 pic 99. 
	 public  int Diskout_nbr_serv { get; set;}
	 //        10  diskout-oma-amt-billed         pic 9(4)v99. 
	 public  decimal Diskout_oma_amt_billed { get; set;}
	 //        10  diskout-priced-tech            pic 9(4)v99. 
	 public  decimal Diskout_priced_tech { get; set;}
	 //        10  diskout-basic-tech             pic 9(4)v99. 
	 public  decimal Diskout_basic_tech { get; set;}
	 //        10  diskout-basic-prof              pic 9(4)v99. 
	 public  decimal Diskout_basic_prof { get; set;}
	 //        10  diskout-basic-fee               pic 9(4)v99. 
	 public  decimal Diskout_basic_fee { get; set;}
	 //        10  diskout-cr                          pic x. 
	 public  string Diskout_cr { get; set;}
	 //        10  diskout-lf                          pic x. 
	 public  string Diskout_lf { get; set;}

}
}
