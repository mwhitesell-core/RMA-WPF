using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    //copy "eft_logical_rec_file.fd". 

    public class Eft_record_type_a
    {
        public Eft_record_type_a()
        {
            institution_id_child = new long[11];
            settlement_account_child = new string[11];
        }

        // 05   a-01-record-type pic x.
        public string a_01_record_type { get; set; }
        // 05   a-02-record-count pic 9(9). 
        public long a_02_record_count { get; set; }
        // 05   a-03-originator-number pic x(10). 
        public string a_03_originator_number { get; set; }
        // 05   a-04-file-creation-number pic 9(4). 
        public int a_04_file_creation_number { get; set; }
        // 05   a-05-creation-date pic 9(6). 
        public long a_05_creation_date { get; set; }
        // 05   a-06-destination-data-centre pic 9(5). 
        public long a_06_destination_data_centre { get; set; }
        // 05   a-07-filler pic x(1213). 
        public string a_07_filler { get; set; }
        // 05   a-08-version-number pic 9(4). 
        public int a_08_version_number { get; set; }
        // 05   a-09-settlement-account pic 99. 
        public int a_09_settlement_account { get; set; }

        // 05   a-10-institution-account.
        public string[] a_10_institution_account_grp { get; set; }
        // 10   institution-account occurs  10 times.
        public string[] institution_account_grp_child { get; set; }
        // 15   institution-id pic 9(9). 
        public long[] institution_id_child { get; set; }
        // 15   settlement-account pic x(12).
        public string[] settlement_account_child { get; set; }

        public object eft_record_type_c_Reference { get; set; }

        public object eft_record_type_z_Reference { get; set; }
    }
}
