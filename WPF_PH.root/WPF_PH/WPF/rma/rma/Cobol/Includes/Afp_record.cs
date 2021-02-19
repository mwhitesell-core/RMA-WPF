using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Afp_record
    {        	
	 //    05  afp-record-id      pic x(3).
	 public  string Afp_record_id { get; set;}
	 //    05  afp-record-data    pic x(132).
	 public  string Afp_record_data { get; set;}
	 //    05  afp-cr             pic x.
	 public  string Afp_cr { get; set;}

     public object Aft_Record_Reference { get; set; }

    }
}
