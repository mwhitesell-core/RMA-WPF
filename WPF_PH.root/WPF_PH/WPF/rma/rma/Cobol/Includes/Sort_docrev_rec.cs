using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Sort_docrev_rec
    {
        //01  sort-docrev-rec. 
        //public  string Sort_docrev_rec { get; set;}
        //    05  wk-docrev-key. 
        public string Wk_docrev_key { get; set; }
        // 10  wk-docrev-clinic-1-2 pic x(2). 
        public string Wk_docrev_clinic_1_2 { get; set; }
        // 10  wk-docrev-dept  pic 99. 
        public int Wk_docrev_dept { get; set; }
        // 10  wk-docrev-doc-nbr  pic xxx. 
        public string Wk_docrev_doc_nbr { get; set; }
        // 10  wk-docrev-location  pic x999. 
        public string Wk_docrev_location { get; set; }
        // 10  wk-docrev-oma-cd            pic x(5). 
        public string Wk_docrev_oma_cd { get; set; }
        // 10  wk-docrev-oma-cd-r redefines wk-docrev-oma-cd. 
        public string Wk_docrev_oma_cd_r { get; set; }
        //     15  wk-docrev-oma-code pic x(4). 
        public string Wk_docrev_oma_code { get; set; }
        //     15  wk-docrev-oma-suff pic x. 
        public string Wk_docrev_oma_suff { get; set; }
        // 10  wk-docrev-cash-record redefines wk-docrev-oma-cd-r. 
        public string Wk_docrev_cash_record { get; set; }
        //     15  wk-docrev-agency-type pic x. 
        public string Wk_docrev_agency_type { get; set; }
        //     15  filler               pic xxxx. 
        public string Filler { get; set; }
        //    05  wk-docrev-month-to-date. 

        //05  wk-docrev-class-code pic x.
        public string wk_docrev_class_code { get; set; }
        public string Wk_docrev_month_to_date { get; set; }
        // 10  wk-docrev-mtd-in-rec pic s9(6)v99. 
        public decimal Wk_docrev_mtd_in_rec { get; set; }
        // 10  wk-docrev-mtd-in-svc pic s9(4). 
        public int Wk_docrev_mtd_in_svc { get; set; }
        // 10  wk-docrev-mtd-out-rec pic s9(6)v99. 
        public decimal Wk_docrev_mtd_out_rec { get; set; }
        // 10  wk-docrev-mtd-out-svc pic s9(4). 
        public int Wk_docrev_mtd_out_svc { get; set; }
        //    05  wk-docrev-year-to-date. 
        public string Wk_docrev_year_to_date { get; set; }
        // 10  wk-docrev-ytd-in-rec pic s9(6)v99.   
        public decimal Wk_docrev_ytd_in_rec { get; set; }
        // 10  wk-docrev-ytd-in-svc pic s9(5). 
        public int Wk_docrev_ytd_in_svc { get; set; }
        // 10  wk-docrev-ytd-out-rec pic s9(6)v99.   
        public decimal Wk_docrev_ytd_out_rec { get; set; }
        // 10  wk-docrev-ytd-out-svc pic s9(5).  
        public int Wk_docrev_ytd_out_svc { get; set; }

    }
}
