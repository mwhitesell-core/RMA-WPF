using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    //WS_Doctor_Totals
    public class WS_DOC_TOTALS_MTD_YTD
    {
        public WS_DOC_TOTALS_MTD_YTD()
        {
            ws_misc_gross = new decimal[11];
            ws_misc_net = new decimal[11];
        }

        public decimal[] ws_misc_gross { get; set; }

        public decimal[] ws_misc_net { get; set; }
        public decimal ws_bill_gross { get; set; }
        public decimal ws_bill_net { get; set; }

        public decimal ws_inc { get; set; }
        public decimal ws_net_inc { get; set; }
        public decimal ws_exp_amt { get; set; }
        public decimal ws_ceil_amt { get; set; }
        public decimal ws_pay_due { get; set; }
        public decimal ws_tax { get; set; }
        public decimal ws_bank_deposit { get; set; }
        public decimal ws_manual_chqs { get; set; }
    }
}
