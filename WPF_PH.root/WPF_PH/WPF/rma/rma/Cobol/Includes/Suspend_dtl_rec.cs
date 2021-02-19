using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Suspend_dtl_rec
    {
        	 //01  suspend-dtl-rec.
	 //public  string Suspend_dtl_rec { get; set;}
	 //    05  clmdtl-id.
	 public  string Clmdtl_id { get; set;}
	 //        10  clmdtl-batch-nbr                    pic x(8).
	 public  string Clmdtl_batch_nbr { get; set;}
	 //        10  clmdtl-claim-nbr                    pic 9(2).
	 public  int Clmdtl_claim_nbr { get; set;}
	 //        10  clmdtl-oma-cd                       pic xxxx.
	 public  string Clmdtl_oma_cd { get; set;}
	 //        10  clmdtl-oma-suff                     pic x.
	 public  string Clmdtl_oma_suff { get; set;}
	 //        10  clmdtl-adj-nbr                      pic 9.
	 public  int Clmdtl_adj_nbr { get; set;}
	 //    05  clmdtl-det-rec.
	 public  string Clmdtl_det_rec { get; set;}
	 //        10  clmdtl-rev-group-cd                 pic xxx.
	 public  string Clmdtl_rev_group_cd { get; set;}
	 //        10  clmdtl-agent-cd                     pic 9.
	 public  int Clmdtl_agent_cd { get; set;}
	 //        10  clmdtl-adj-cd                       pic x.
	 public  string Clmdtl_adj_cd { get; set;}
	 //        10  clmdtl-nbr-serv                     pic 99.
	 public  int Clmdtl_nbr_serv { get; set;}
	 //        10  clmdtl-nbr-serv-alpha redefines clmdtl-nbr-serv pic xx.
	 public  string Clmdtl_nbr_serv_alpha { get; set;}
	 //        10  clmdtl-sv-date.
	 public  string Clmdtl_sv_date { get; set;}
	 //            15  clmdtl-sv-yy                    pic 9999.
	 public  int Clmdtl_sv_yy { get; set;}
	 //            15  clmdtl-sv-mm                    pic 99.
	 public  int Clmdtl_sv_mm { get; set;}
	 //            15  clmdtl-sv-dd                    pic 99.
	 public  int Clmdtl_sv_dd { get; set;}
	 //        10  clmdtl-consec-dates.
	 public  string Clmdtl_consec_dates { get; set;}
	 //            15  clmdtl-consecutive-sv-date  occurs 3 times.
	 public  string[] Clmdtl_consecutive_sv_date { get; set;}
	 //         20  clmdtl-sv-nbr  pic 9.
	 public  int[] Clmdtl_sv_nbr { get; set;}
	 //    20  clmdtl-sv-day  pic xx.
	 public  string[] Clmdtl_sv_day { get; set;}
	 //        10  clmdtl-amt-tech-billed              pic s9(4)v99.
	 public  decimal Clmdtl_amt_tech_billed { get; set;}
	 //        10  clmdtl-fee-oma                      pic s9(5)v99.
	 public  decimal Clmdtl_fee_oma { get; set;}
	 //        10  clmdtl-fee-oma-alpha redefines clmdtl-fee-oma pic x(7).
	 public  string Clmdtl_fee_oma_alpha { get; set;}
	 //        10  clmdtl-fee-ohip                     pic s9(5)v99.
	 public  decimal Clmdtl_fee_ohip { get; set;}
	 //        10  clmdtl-fee-ohip-alpha redefines clmdtl-fee-ohip pic x(7).
	 public  string Clmdtl_fee_ohip_alpha { get; set;}
	 //        10  clmdtl-date-period-end              pic x(8).
	 public  string Clmdtl_date_period_end { get; set;}
	 //        10  clmdtl-cycle-nbr                    pic 999.
	 public  int Clmdtl_cycle_nbr { get; set;}
	 //        10  clmdtl-diag-cd                      pic 999.
	 public  int Clmdtl_diag_cd { get; set;}
	 //        10  clmdtl-diag-cd-alpha                 redefines clmdtl-diag-cd        pic xxx.
	 public  string Clmdtl_diag_cd_alpha { get; set;}
	 //        10  clmdtl-diag-cd-local                pic 999.
	 public  int Clmdtl_diag_cd_local { get; set;}
	 //        10  clmdtl-diag-cd-local-alpha                   redefines clmdtl-diag-cd-local  pic xxx.
	 public  string Clmdtl_diag_cd_local_alpha { get; set;}
	 //    05  clmdtl-status                           pic x.
	 public  string Clmdtl_status { get; set;}
	 //    05  suspend-dtl-id.
	 public  string Suspend_dtl_id { get; set;}
	 //        10  clmdtl-doc-pract-nbr                pic 9(6).
	 public  int Clmdtl_doc_pract_nbr { get; set;}
	 //        10  clmdtl-accounting-nbr              pic x(8).
	 public  string Clmdtl_accounting_nbr { get; set;}

}
}
