using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Adj_claim_rec
    {
        	 //01  adj-claim-rec.  
	 //public  string Adj_claim_rec { get; set;}
	 //    05  adj-batch-nbr   pic x(8).  
	 public  string Adj_batch_nbr { get; set;}
	 //    05  adj-claim-nbr   pic 9(2).  
	 public  int Adj_claim_nbr { get; set;}
	 //    05  adj-oma-cd-suff   pic x(5).  
	 public  string Adj_oma_cd_suff { get; set;}
	 //    05  adj-serv-date   pic 9(8).  
	 public  int Adj_serv_date { get; set;}
	 //    05  adj-agent-cd   pic 9.  
	 public  int Adj_agent_cd { get; set;}
	 //    05  adj-pat-acronym   pic x(9).  
	 public  string Adj_pat_acronym { get; set;}
	 //    05  adj-amt-bal   pic s9(5)v99.  
	 public  decimal Adj_amt_bal { get; set;}
	 //    05  adj-diag-cd   pic 9(3).  
	 public  int Adj_diag_cd { get; set;}
	 //    05  adj-line-no   pic 99.  
	 public  int Adj_line_no { get; set;}

}
}
