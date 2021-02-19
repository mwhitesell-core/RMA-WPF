using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Seq_pat_ikey_file_rec
    {
        	 //01 seq-pat-ikey-file-rec. 
	//public  string Seq_pat_ikey_file_rec { get; set;}
	 //   05 seq-pat-doctor-nbr  pic 9(06). 
	 public  int Seq_pat_doctor_nbr { get; set;}
	 //   05 seq-pat-account-id  pic x(08). 
	 public  string Seq_pat_account_id { get; set;}
	 //   05 seq-pat-i-key   pic x(14). 
	 public  string Seq_pat_i_key { get; set;}
	 //   05 seq-pat-acronym                   pic x(9).
	 public  string Seq_pat_acronym { get; set;}
	 //   05 seq-pat-province                  pic x(2).
	 public  string Seq_pat_province { get; set;}

}
}
