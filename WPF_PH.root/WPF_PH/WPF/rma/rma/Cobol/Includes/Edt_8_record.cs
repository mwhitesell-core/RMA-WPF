using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_8_record
    {
        	 //01  edt-8-record. 
	 //public  string Edt_8_record { get; set;}
	 //    05  edt-8-trans-id    pic xx. 
	 public  string Edt_8_trans_id { get; set;}
	 //    05  edt-8-record-type   pic x. 
	 public  string Edt_8_record_type { get; set;}
	 //    05  edt-8-explan-cd    pic xx. 
	 public  string Edt_8_explan_cd { get; set;}
	 //    05  edt-8-explan-desc   pic x(55).
	 public  string Edt_8_explan_desc { get; set;}
	 //    05  edt-8-filler    pic x(19). 
	 public  string Edt_8_filler { get; set;}

}
}
