using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Sorted_Record
    {
        //    05   s-record-type pic x.
        public string s_record_type { get; set; }
        //  05   s-record-count pic x(9). 
        public string s_record_count { get; set; }
        //  05   s-originator-nbr pic x(10).
        public string s_originator_nbr { get; set; }
        //  05   s-file-creation-nbr pic x(4).
        public string s_file_creation_nbr { get; set; }
        //  05   s-mix-1                         pic x(150). 
        public string s_mix_1 { get; set; }
        // 05   s-x-ref-nbr pic x(3). 
        public string s_x_ref_nbr { get; set; }
        //  05   s-mix-2			  pic x(1287). 
        public string s_mix_2 { get; set; }
    }
}
