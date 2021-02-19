using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Company_mstr_rec
    {
        // 05  company-nbr pic 99.
        public int company_nbr { get; set; }
        //  05  company-name pic x(40). 
        public string company_name { get; set; }
        //  05  bank-info.
        public string bank_info_grp { get; set; }
        //  10  bank-nbr pic 9(4).   
        public int bank_nbr_child { get; set; }
        //  10  bank-branch pic 9(5).   
        public long bank_branch_child { get; set; }
        //  10  bank-account-nbr pic x(12).   
        public string bank_account_nbr_child { get; set; }
        // 05  filler pic x(7). 
        public string filler { get; set; }
    }
}
