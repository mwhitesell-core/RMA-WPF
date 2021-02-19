using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Msg_sub_mstr_rec
    {
        	 //01 msg-sub-mstr-rec.  
	 //public  string Msg_sub_mstr_rec { get; set;}
	 //    05  msg-sub-key.  
	 public  string Msg_sub_key { get; set;}
	 // 10  msg-sub-key-1   pic x.  
	 public  string Msg_sub_key_1 { get; set;}
	 // 10  msg-sub-key-23.  
	 public  string Msg_sub_key_23 { get; set;}
	 //     15  msg-sub-key-2   pic x.  
	 public  string Msg_sub_key_2 { get; set;}
	 //     15  msg-sub-key-3   pic x.  
	 public  string Msg_sub_key_3 { get; set;}
	 //    05  msg-rec.  
	 public  string Msg_rec { get; set;}
	 //        10  msg-reprint-flag   pic x.  
	 public  string Msg_reprint_flag { get; set;}
	 //        10  msg-auto-logout   pic x.  
	 public  string Msg_auto_logout { get; set;}
	 //        10  msg-dtl1    pic x(47).  
	 public  string Msg_dtl1 { get; set;}
	 //        10  msg-dtl2    pic x(47).  
	 public  string Msg_dtl2 { get; set;}
	 //        10  msg-dtl3    pic x(47).  
	 public  string Msg_dtl3 { get; set;}
	 //        10  msg-dtl4    pic x(47).  
	 public  string Msg_dtl4 { get; set;}
	 //    05  sub-rec redefines msg-rec.  
	 public  string Sub_rec { get; set;}
	 //        10  sub-name    pic x(25).  
	 public  string Sub_name { get; set;}
	 // 10  sub-fee-complex   pic x.  
	 public  string Sub_fee_complex { get; set;}
	 // 10  sub-auto-logout   pic x.  
	 public  string Sub_auto_logout { get; set;}
	 // 10  filler    pic x(163).  
	 public  string Filler { get; set;}

}
}
