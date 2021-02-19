using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class r051_work_rec
    {
        //03  wf-sort-key.
        public string wf_sort_key { get; set; }
        //   05  wf-dept pic 99. 
        public int wf_dept { get; set; }
        //   05  wf-class-code pic x.
        public string wf_class_code { get; set; }
        //   05  wf-doc-nbr pic x(3). 
        public string wf_doc_nbr { get; set; }
        //   05  wf-oma-cd.
        public string wf_oma_cd { get; set; }
        //       10  wf-oma-code-ltr pic x.
        public string wf_oma_code_ltr { get; set; }
        //       10  filler pic x(4). 
        public string filler { get; set; }
        //03  wf-data.
        public string wf_data { get; set; }
        //    05  wf-month-to-date.
        public string wf_month_to_date {get;set;}
        //       10  wf-mtd-svcs pic s9(8). 
        public int wf_mtd_svcs { get; set; }
        //       10  wf-mtd-amt pic s9(9)v99.
        public string wf_mtd_amt { get; set; }
        //    05  wf-year-to-date.
        public string wf_year_to_date { get; set; }
        //      10  wf-ytd-svcs pic s9(8). 
        public int wf_ytd_svcs { get; set; }
        //      10  wf-ytd-amt pic s9(9)v99.
        public string wf_ytd_amt { get; set; }
    }
}
