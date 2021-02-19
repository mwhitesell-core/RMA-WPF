using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class WS_FINAL_TOTALS_MTD_YTD
    {
        public WS_FINAL_TOTALS_MTD_YTD()
        {
            ws_fin_misc_gross = new decimal[11];
            ws_fin_misc_net = new decimal[11];
        }

        public decimal[] ws_fin_misc_gross { get; set; }

        public decimal[] ws_fin_misc_net { get; set; }

        public decimal ws_fin_bill_gross { get; set; }
        public decimal ws_fin_bill_net { get; set; }
        public decimal ws_fin_inc { get; set; }

        public decimal ws_fin_exp_amt { get; set; }
        public decimal ws_fin_ceil_amt { get; set; }
        public decimal ws_fin_pay_due { get; set; }
        public decimal ws_fin_tax { get; set; }
        public decimal ws_fin_deposit { get; set; }
        public decimal ws_fin_man_chqs { get; set; }
    }
}
