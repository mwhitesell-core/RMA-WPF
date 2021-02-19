using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Tp_pat_mstr_rec_out
    {
        	 //01 tp-pat-mstr-rec-out.
	// public  string Tp_pat_mstr_rec_out { get; set;}
	 //   05 sequence-nbr    pic x(6).
	 public  string Sequence_nbr { get; set;}
	 //   05 sequence-nbr-num redefines sequence-nbr pic 9(6).
	 public  int Sequence_nbr_num { get; set;}
	 //   05 tp-pat-mstr-rec-out-orig   pic x(204).
	 public  string Tp_pat_mstr_rec_out_orig { get; set;}

}
}
