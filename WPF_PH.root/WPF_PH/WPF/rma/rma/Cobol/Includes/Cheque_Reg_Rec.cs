using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Cheque_Reg_Rec
    {
        public Cheque_Reg_Rec()
        {
            chq_doc_data_grp = new string[19];
            chq_reg_perc_bill_child = new decimal[19];
            chq_reg_perc_misc_child = new decimal[19];
            chq_reg_pay_code_child = new string[19];
            chq_reg_perc_tax_child = new decimal[19];
            chq_reg_mth_bill_amt_child = new decimal[19];

            chq_reg_mth_misc_amt_child = new decimal[11];
            chq_reg_mth_exp_amt_child = new decimal[19];
            chq_reg_comp_ann_exp_this_pay_child = new decimal[19];
            chq_reg_mth_ceil_amt_child = new decimal[19];
            chq_reg_comp_ann_ceil_this_pay_child = new decimal[19];
            chq_reg_earnings_this_mth_child = new decimal[19];
            chq_reg_regular_pay_this_mth_child = new decimal[19];
            chq_reg_regular_tax_this_mth_child = new decimal[19];
            chq_reg_man_pay_this_mth_child = new decimal[19];
            chq_reg_man_tax_this_mth_child = new decimal[19];

            chq_reg_pay_date_child = new long[19];
        }

        // 05  chq-reg-key.
        public string chq_reg_key_group { get; set; }
        //10  chq-reg-clinic-nbr-1-2		pic 99. 
        public int chq_reg_clinic_nbr_1_2_child { get; set; }
        //  10  chq-reg-dept pic 99. 
        public int chq_reg_dept_child { get; set; }
        //  10  chq-reg-doc-nbr pic x(3). 
        public string chq_reg_doc_nbr_child { get; set; }

        // 05  chq-doc-data occurs 18 times.
        public string[] chq_doc_data_grp { get; set; } // = new string[18];
                                                       //10  chq-reg-perc-bill pic 9v9999 comp-3. 
        public decimal[] chq_reg_perc_bill_child { get; set; } //= new decimal[18];
                                                               //  10  chq-reg-perc-misc pic 9v9999 comp-3. 
        public decimal[] chq_reg_perc_misc_child { get; set; } //= new decimal[18];
                                                               // 10  chq-reg-pay-code pic x.
        public string[] chq_reg_pay_code_child { get; set; } //=  new string[18];
                                                             //  10  chq-reg-perc-tax pic 9v9999 comp-3. 
        public decimal[] chq_reg_perc_tax_child { get; set; } //= new decimal[18];
                                                              //  10  chq-reg-mth-bill-amt pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_mth_bill_amt_child { get; set; } //= new decimal[18];

        // 10  chq-reg-mth-misc-amt occurs 10 times
        //  pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_mth_misc_amt_child { get; set; } //= new decimal[10];
                                                                  //    10  chq-reg-mth-exp-amt pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_mth_exp_amt_child { get; set; } //= new decimal[18];
                                                                 // 10  chq-reg-comp-ann-exp-this-pay pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_comp_ann_exp_this_pay_child { get; set; } // = new decimal[18];
                                                                           // 10  chq-reg-mth-ceil-amt pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_mth_ceil_amt_child { get; set; } // = new decimal[18];
                                                                  // 10  chq-reg-comp-ann-ceil-this-pay pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_comp_ann_ceil_this_pay_child { get; set; } // = new decimal[18];
                                                                            //10  chq-reg-earnings-this-mth pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_earnings_this_mth_child { get; set; } // = new decimal[18];
                                                                       // 10  chq-reg-regular-pay-this-mth pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_regular_pay_this_mth_child { get; set; } // = new decimal[18];
                                                                          // 10  chq-reg-regular-tax-this-mth pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_regular_tax_this_mth_child { get; set; } // = new decimal[18];
                                                                          // 10  chq-reg-man-pay-this-mth pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_man_pay_this_mth_child { get; set; } // = new decimal[18];
                                                                      // 10  chq-reg-man-tax-this-mth pic s9(7)v99 comp-3. 
        public decimal[] chq_reg_man_tax_this_mth_child { get; set; } // = new decimal[18];
                                                                      //  10  chq-reg-pay-date pic 9(8).  
        public long[] chq_reg_pay_date_child { get; set; } // = new long[18];

    }
}
