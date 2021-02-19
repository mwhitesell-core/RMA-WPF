using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Work_file_rec
    {
        // 05  wf-bank-cd-branch.
        public string wf_bank_cd_branch_grp { get; set; }
        //10  wf-bank-cd pic x(4). 
        public string wf_bank_cd_child { get; set; }
        //10  wf-bank-branch pic x(5). 
        public string wf_bank_branch_child { get; set; }
        //05  wf-bank-acct-nbr pic x(12). 
        public string wf_bank_acct_nbr { get; set; }

        //05  wf-doc-nbr pic xxx.
        public string wf_doc_nbr { get; set; }

        //05  wf-pay pic s9(6)v99.
        public decimal wf_pay { get; set; }
        //05  wf-doc-inits.
        public string wf_doc_inits_grp { get; set; }
        //10  wf-init1 pic x.
        public string wf_init1_child { get; set; }
        //10  wf-init2 pic x.
        public string wf_init2_child { get; set; }
        //10  wf-init3 pic x.
        public string wf_init3_child { get; set; }
        //05  wf-period-end.
        public string wf_period_end_grp { get; set; }

        //10  wf-period-yy pic 9(4). 
        public int wf_period_yy_child { get; set; }
        //10  wf-period-mm pic 99. 
        public int wf_period_mm_child { get; set; }
        //10  wf-period-dd pic 99. 
        public int wf_period_dd_child { get; set; }
        //05  wf-doc-name pic x(24). 
        public string wf_doc_name { get; set; }
    }
}
