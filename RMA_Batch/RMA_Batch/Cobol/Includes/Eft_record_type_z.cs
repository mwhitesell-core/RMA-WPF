using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    //copy "eft_logical_rec_file.fd". 
    public class Eft_record_type_z
    {
        //05    z-01-record-type pic a.
        public string z_01_record_type { get; set; }
        //     05    z-02-record-count pic 9(9). 
        public long z_02_record_count { get; set; }
        // 05    z-03-originator-nbr pic x(10). 
        public string z_03_originator_nbr { get; set; }
        //05    z-03-file-creation-number pic 9(4). 
        public int z_03_file_creation_number { get; set; }
        // 05    z-04-total-debit-value pic 9(12)v99.
        public decimal z_04_total_debit_value { get; set; }
        // 05    z-05-total-debit-nbr pic 9(8). 
        public long z_05_total_debit_nbr { get; set; }
        // 05    z-06-total-credit-value pic 9(12)v99.
        public decimal z_06_total_credit_value { get; set; }
        // 05    z-07-total-credit-nbr pic 9(8). 
        public long z_07_total_credit_nbr { get; set; }
        // 05    z-08-filler pic x(1396). 
        public string z_08_filler { get; set; }
    }
}
