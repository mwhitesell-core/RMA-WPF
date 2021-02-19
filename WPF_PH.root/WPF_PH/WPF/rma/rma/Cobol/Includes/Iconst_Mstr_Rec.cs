using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    //Note: Table not found in RMA101C database 
    //copy "f090_constants_mstr.fd". 
    public class Iconst_Mstr_Rec
    {
        //   05  iconst-clinic-nbr-1-2			pic   99.  
        public int iconst_clinic_nbr_1_2 { get; set; }

        // 05  iconst-clinic-nbr pic  x(4).  
        public string iconst_clinic_nbr { get; set; }
        // 05  iconst-clinic-name pic x(20).  
        public string iconst_clinic_name { get; set; }
        // 05  iconst-clinic-cycle-nbr pic   99.  
        public int iconst_clinic_cycle_nbr { get; set; }
        //  05  iconst-date-period-end.
        public string iconst_date_period_end_grp { get; set; }

        // 10  iconst-date-period-end-yy pic   9999.  
        public int iconst_date_period_end_yy_child { get; set; }
        // 10  iconst-date-period-end-mm pic   99.  
        public int iconst_date_period_end_mm_child { get; set; }
        // 10  iconst-date-period-end-dd pic   99.  
        public int iconst_date_period_end_dd_child { get; set; }

        // 05  iconst-clinic-addr.
        public string iconst_clinic_addr_grp { get; set; }
        // 10  iconst-clinic-addr-l1 pic  x(25).  
        public string iconst_clinic_addr_l1_child { get; set; }
        // 10  iconst-clinic-addr-l2 pic  x(25).  
        public string iconst_clinic_addr_l2 { get; set; }
        // 10  iconst-clinic-addr-l3 pic  x(25).  
        public string iconst_clinic_addr_l3_child { get; set; }
        // 05  iconst-clinic-addr-r redefines iconst-clinic-addr.
        public string iconst_clinic_addr_r_child_redefines { get; set; }
        //10  iconst-clinic-addr pic x(25)   occurs  3  times.
        public string[] iconst_clinic_addr { get; set; }
        //05  iconst-clinic-card-colour pic    x.
        public string iconst_clinic_card_colour { get; set; }
        //05  iconst-clinic-over-lim1 pic 99v99.
        public decimal iconst_clinic_over_lim1 { get; set; }
        //05  iconst-clinic-under-lim2 pic 99v99.
        public decimal iconst_clinic_under_lim2 { get; set; }
        //05  iconst-clinic-under-lim3 pic 99v99.
        public decimal iconst_clinic_under_lim3 { get; set; }
        //05  iconst-clinic-over-lim4 pic 99v99.
        public decimal iconst_clinic_over_lim4 { get; set; }

        // 05  iconst-clinic-batch-nbr pic x(6).  
        public string iconst_clinic_batch_nbr { get; set; }

        //05  iconst-reduction-factor pic 99v99.
        public decimal iconst_reduction_factor { get; set; }
        //05  iconst-overpay-factor pic 99v99.
        public decimal iconst_overpay_factor { get; set; }
        //05  filler pic x(106).  
        public string filler { get; set; }
        //05  iconst-clinic-pay-batch-nbr pic x(6).  
        public string iconst_clinic_pay_batch_nbr { get; set; }
        //05  filler pic x(130).  
        public string filler1 { get; set; }
    }
}
