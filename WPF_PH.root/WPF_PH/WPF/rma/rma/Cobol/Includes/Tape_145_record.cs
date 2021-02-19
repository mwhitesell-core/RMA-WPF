using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Tape_145_record
    {        
        //05  rat-145-group-nbr pic x(4). 
        public string Rat_145_group_nbr { get; set; }

        //05  rat-145-moh-off-cd pic x.
        public string Rat_145_moh_off_cd { get; set; }

        //05  rat-145-data-seq-nbr pic 9. 
        public int Rat_145_data_seq_nbr { get; set; }


        //05  rat-145-payment-date pic 9(8). 
        public int Rat_145_payment_date { get; set; }

        //05  rat-145-payee-name.
        public string Rat_145_payee_name_grp { get; set; }
	    // 10  rat-145-pay-last-name pic x(25). 
        public string Rat_145_pay_last_name { get; set; }

         //   10  rat-145-pay-title pic xxx.
         public string Rat_145_pay_title { get; set; }

        //   10  rat-145-pay-initials pic xx.
        public string Rat_145_pay_initials { get; set; }
        //05  rat-145-tot-amt-pay pic s9(7)v99.
        public decimal Rat_145_tot_amt_pay { get; set; }
        //05  rat-145-cheq-nbr pic x(8). 
        public string Rat_145_cheq_nbr { get; set; }
        //05  rat-145-claim-nbr pic x(11). 
        public string Rat_145_claim_nbr { get; set; }

        //05  rat-145-trans-type pic 9. 
        public int Rat_145_trans_type { get; set; }

        //05  rat-145-doc-nbr pic 9(6). 
        public int Rat_145_doc_nbr { get; set; }

        //05  rat-145-specialty-cd pic xx.
        public string Rat_145_specialty_cd { get; set; }
        //05  rat-145-account-nbr pic x(8). 
        public string Rat_145_account_nbr { get; set; }
        //05  rat-145-last-name pic x(14). 
        public string Rat_145_last_name { get; set; }
        //05  rat-145-first-name pic x(5). 
        public string Rat_145_first_name { get; set; }

        //05  rat-145-prov-cd pic xx.
        public string Rat_145_prov_cd { get; set; }
        //05  rat-145-health-ohip-nbr pic x(12). 
        public string Rat_145_health_ohip_nbr { get; set; }

        //05  rat-145-version-cd pic xx.
        public string Rat_145_version_cd { get; set; }

        //05  rat-145-pay-prog pic xxx.
        public string Rat_145_pay_prog { get; set; }
        //05  rat-145-conv-health-nbr pic x(10). 
        public string Rat_145_conv_health_nbr { get; set; }

        //05  rat-145-service-date pic 9(8). 
        public int Rat_145_service_date { get; set; }

        //05  rat-145-nbr-of-serv pic 99. 
        public int Rat_145_nbr_of_serv { get; set; }
        //05  rat-145-service-cd pic x(5). 
        public string Rat_145_service_cd { get; set; }

        //05  rat-145-eligibility-ind pic x.
        public string Rat_145_eligibility_ind { get; set; }

        //05  rat-145-amount-sub pic 9(4)v99.
        public decimal Rat_145_amount_sub { get; set; }
        //05  rat-145-amt-paid pic s9(4)v99.
        public decimal Rat_145_amt_paid { get; set; }

        //05  rat-145-explan-cd pic xx.
        public string Rat_145_explan_cd { get; set; }
    }
}
