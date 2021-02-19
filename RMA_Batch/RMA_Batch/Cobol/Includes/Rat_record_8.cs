using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Rat_record_8
    {        	
	 //    05  rat-8-trans-id    pic xx. 
	 public  string Rat_8_trans_id { get; set;}
	 //    05  rat-8-record-type   pic x. 
	 public  string Rat_8_record_type { get; set;}
	 //    05  rat-8-mess-text     pic x(70). 
	 public  string Rat_8_mess_text { get; set;}
	 //    05  rat-8-filler        pic x(4). 
	 public  string Rat_8_filler { get; set;}

}
}
