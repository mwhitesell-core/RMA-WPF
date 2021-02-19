using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Claims_extra_mstr_rec
    {
        //01  claims-extra-mstr-rec.  
        //public  string Claims_extra_mstr_rec { get; set;}
        //    05  clmhdr-rma-clm-nbr.  
        public string Clmhdr_rma_clm_nbr { get; set; }
        // 10  clmhdr-rma-batch-nbr pic x(8).  
        public string Clmhdr_rma_batch_nbr { get; set; }
        // 10  clmhdr-rma-claim-nbr pic 99.  
        public int Clmhdr_rma_claim_nbr { get; set; }
        //    05  clmhdr-ohip-clm-nbr  pic x(11).  
        public string Clmhdr_ohip_clm_nbr { get; set; }

    }
}
