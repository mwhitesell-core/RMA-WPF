using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_9_record
    {
        	 //01  edt-9-record.
	 //public  string Edt_9_record { get; set;}
	 //    05  edt-9-trans-id    pic xx. 
	 public  string Edt_9_trans_id { get; set;}
	 //    05  edt-9-record-type   pic x. 
	 public  string Edt_9_record_type { get; set;}
	 //    05  edt-9-hdr-1-count      pic 9(7). 
	 public  int Edt_9_hdr_1_count { get; set;}
	 //    05  edt-9-hdr-2-count    pic 9(7). 
	 public  int Edt_9_hdr_2_count { get; set;}
	 //    05  edt-9-item-count      pic 9(7). 
	 public  int Edt_9_item_count { get; set;}
	 //    05  edt-9-message-count   pic 9(7). 
	 public  int Edt_9_message_count { get; set;}
	 //    05  edt-9-filler    pic x(48). 
	 public  string Edt_9_filler { get; set;}

}
}
