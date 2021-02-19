using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Dept_Mstr_Rec
    {
        //05  dept-nbr pic 99.    
        public int dept_nbr { get; set; }
        //05  dept-name pic x(30). 
        public string dept_name { get; set; }
        //05  dept-addr1 pic x(30).  
        public string dept_addr1 { get; set; }
        //05  dept-addr2 pic x(30). 
        public string dept_addr2 { get; set; }
        //05  dept-addr3 pic x(30). 
        public string dept_addr3 { get; set; }
        //05  dept-chairman pic x(25). 
        public string dept_chairman { get; set; }
        //05  dept-co-ordinator pic x(25). 
        public string dept_co_ordinator { get; set; }

        //05  dept-nbr-docs pic 999. 
        public int dept_nbr_docs { get; set; }

        //05  dept-company pic 99.
        public int dept_company { get; set; }
        //05  filler pic x(23). 
        public string filler { get; set; }
    }
}
