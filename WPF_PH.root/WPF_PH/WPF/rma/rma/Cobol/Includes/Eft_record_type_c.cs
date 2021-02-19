using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    //copy "eft_logical_rec_file.fd". 
    public class Eft_record_type_c
    {
        // 05    c-01-record-type pic a.
        public string c_01_record_type { get; set; }
        // 05    c-02-record-count pic 9(9). 
        public long c_02_record_count { get; set; }
        // 05    c-03-originator-nbr pic x(10). 
        public string c_03_originator_nbr { get; set; }
        // 05    c-03-file-creation-nbr pic 9(04).
        public int c_03_file_creation_nbr { get; set; }

        // 05    c-04-transaction-type pic 9(3). 
        public int c_04_transaction_type { get; set; }
        // 05    c-05-amount pic 9(8)v99.
        public decimal c_05_amount { get; set; }
        // 05    c-06-fund-available-date pic 9(6). 
        public long c_06_fund_available_date { get; set; }
        // 05    c-07-bank-nbr pic 9(9). 
        public long c_07_bank_nbr { get; set; }
        // 05    c-08-payee-acc-nbr pic x(12). 
        public string c_08_payee_acc_nbr { get; set; }
        // 05    c-09-reserved pic x(22). 
        public string c_09_reserved { get; set; }
        // 05    c-10-stored-trans-type pic 9(3). 
        public int c_10_stored_trans_type { get; set; }
        // 05    c-11-short-name pic x(15). 
        public string c_11_short_name { get; set; }
        // 05    c-12-payee-name pic x(30). 
        public string c_12_payee_name { get; set; }
        // 05    c-13-long-name pic x(30). 
        public string c_13_long_name { get; set; }
        // 05    c-14-originator-nbr pic x(10). 
        public string c_14_originator_nbr { get; set; }
        // 05    c-15-cross-ref-nbr pic x(19). 
        public string c_15_cross_ref_nbr { get; set; }
        // 05    c-16-institution-return         pic 9(9). 
        public long c_16_institution_return { get; set; }
        // 05    c-17-account-return             pic x(12). 
        public string c_17_account_return { get; set; }
        // 05    c-18-sundry pic x(15). 
        public string c_18_sundry { get; set; }
        // 05    c-19-filler pic x(22). 
        public string c_19_filler { get; set; }
        // 05    c-20-settlement-indicator pic 9(2). 
        public int c_20_settlement_indicator { get; set; }
        // 05    c-21-invalid-indicator pic 9(11). 
        public long c_21_invalid_indicator { get; set; }
        // 05    c-seg-two-six pic x(1200). 
        public string c_seg_two_six { get; set; }
    }
}
