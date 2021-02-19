using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Audit_record				
    {
        	 //01  audit-record    pic x(132).      
	 public  string Audit_record1 { get; set;}

     }

    public class Error_record
    {
        public string  Error_rec { get; set; }
    }

    public class Ohip_Benefit_Sched_Rec
    {
        public Ohip_Benefit_Sched_Rec()
        {
            ohip_fees = new decimal[6];
        }

        public string ohip_code_grp { get; set; }
        public string ohip_code_ltr { get; set; }
        public int ohip_code_nbr { get; set; }

        public string ohip_effective_date_grp { get; set; }
        public int ohip_effective_yr { get; set; }
        public int ohip_effective_mth { get; set; }
        public int ohip_effective_day { get; set; }

        public string ohip_termination_date_grp { get; set; }
        public int ohip_termination_yr { get; set; }
        public int ohip_termination_mth { get; set; }
        public int ohip_termination_day { get; set; }
        public decimal[]  ohip_fees { get; set; }
        public string filler { get; set; }
    }
}
