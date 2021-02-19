using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using rma.Cobol.Includes;
using RmaDAL;


namespace rma.Cobol.Reports
{
    public class R153b : CommonFunction
    {
        //copy "f020_doctor_mstr.slr".          
        private   F020_DOCTOR_MSTR objF020_DOCTOR_MSTR = null;
        private   ObservableCollection<F020_DOCTOR_MSTR> F020_DOCTOR_MSTR_Collection;

        //copy "f060_cheque_reg_mstr.slr". 
        private   F060_CHEQUE_REG_MSTR objF060_CHEQUE_REG_MSTR = null;
        private   ObservableCollection<F060_CHEQUE_REG_MSTR> F060_CHEQUE_REG_MSTR_Collection;

        //copy "f070_dept_mstr.slr". 
        private   F070_DEPT_MSTR objF070_DEPT_MSTR = null;
        private   ObservableCollection<F070_DEPT_MSTR> F070_DEPT_MSTR_Collection;

        //copy "f080_bank_mstr.slr".      
        private   F080_BANK_MSTR objF080_BANK_MSTR = null;
        private   ObservableCollection<F080_BANK_MSTR> F080_BANK_MSTR_Collection;

        //copy "f090_constants_mstr.slr". 
        private   ICONST_MSTR_REC objICONST_MSTR_REC = null;
        private   ObservableCollection<ICONST_MSTR_REC> ICONST_MSTR_REC_Collection;
        
        private   Eft_constant_file objEft_constant_file;

        //copy "eft_logical_rec_file.slr". 
        private   Work_file_rec objWork_file_rec;
        private   ObservableCollection<Work_file_rec> Work_file_rec_Collection;

        private   Sorted_Record objSorted_Record;
        private   ObservableCollection<Sorted_Record> Sorted_Record_Collection;

        private   Output_record objOutput_record;
        private   ObservableCollection<Output_record> Output_record_Collection;

        private   Eft_record_type_a objEft_record_type_a = null;
        private   ObservableCollection<Eft_record_type_a> Eft_record_type_a_Collection;

        private   Eft_record_type_c objEft_record_type_c = null;
        private   ObservableCollection<Eft_record_type_c> Eft_record_type_c_Collection;

        private   Eft_record_type_z objEft_record_type_z = null;
        private   ObservableCollection<Eft_record_type_z> Eft_record_type_z_Collection;

        private   F020C_DOC_CLINIC_NEXT_BATCH_NBR objF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
        private   ObservableCollection<F020C_DOC_CLINIC_NEXT_BATCH_NBR> F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection = null;

        private   Print_file_a objPrint_file_a = null;
        private   ObservableCollection<Print_file_a> Print_file_a_Collection;

        private   Print_file_b objPrint_file_b = null;
        private   ObservableCollection<Print_file_b> Print_file_b_Collection;

        private   Print_file_c objPrint_file_c = null;
        private   ObservableCollection<Print_file_c> Print_file_c_Collection;

        private   ReportPrint objPrtSummary = null;
        private   ReportPrint objPrtLineA = null;
        private   ReportPrint objPrtLineB = null;
        private   ReportPrint objPrtLineC = null;
        private   Summary_eft objSummary_eft = null;

        private   string _reportSummaryFile;
        private   string _reportPrintAFile;
        private   string _reportPrintBFile;
        private   string _reportPrintCFile;

        private   CONSTANTS_MSTR_REC_3 objConstants_Mstr_Rec_3;  
        private   ObservableCollection<CONSTANTS_MSTR_REC_3> Constants_Mstr_Rec_3_Collection;

        private   U119_chgeft_rec objU119_chgeft_rec = null;
        private   ObservableCollection<U119_chgeft_rec> U119_chgeft_rec_Collection;

        //copy "r153_bank_info.ws".
        //77   ws-nbr-settlement-accounts pic 99          value 4.
        private   new int ws_nbr_settlement_accounts = 4;

        //77   ws-settlement-account-1      pic x(12)       value "7701918     ".
        private   new string ws_settlement_account_1 = "7701918     ";

        //77   ws-institution-id-1          pic 9(9)        value 001000562.  
        private   new int ws_institution_id_1 = 001000562;

        //77   ws-settlement-account-2      pic x(12)       value "1172611     ".
        private   new string ws_settlement_account_2 = "1172611     ";

        //77   ws-institution-id-2          pic 9(9)        value 001000062.  
        private   new int ws_institution_id_2 = 001000062;

        //77   ws-settlement-account-3      pic x(12)       value "9594213     ".
        private   new string ws_settlement_account_3 = "9594213     ";

        //77   ws-institution-id-3          pic 9(9)        value 001000062.
        private   new int ws_institution_id_3 = 001000062;

        //77   ws-settlement-account-4      pic x(12)       value "9079319     ".
        private   new string ws_settlement_account_4 = "9079319     ";

        //77   ws-institution-id-4          pic 9(9)        value 001000062.
        private   new int ws_institution_id_4 = 001000062;

        //01   ws-settlement-account pic x(12).
        private   new string ws_settlement_account;

        //01   ws-account-return		pic x(12).  
        private   new string ws_account_return;

        //01   ws-institution-id.
        private   new string ws_institution_id_grp;

        //05  ws-bank-nbr-id pic 9(4).
        private   new int ws_bank_nbr_id_child;

        //05  ws-bank-branch-id pic 9(5).
        private   new int ws_bank_branch_id_child;

        //01   ws-institution-return.  
        private   new string ws_institution_return_grp;
        //05  ws-bank-nbr-return     pic 9(4).
        private   new int ws_bank_nbr_return_child;
        //05  ws-bank-branch-return 	pic 9(5).
        private   new int ws_bank_branch_return_child;

        //77   ws-dest-data-centre pic 9(5)        value 01020.  
        private   new int ws_dest_data_centre = 01020;

        //  77   ws-short-name pic x(15)       value "  R. M. A.    ".                        
        //private   string ws_short_name = "  R. M. A.    ";

        //77   ws-long-name pic x(30)       value " Regional Medical Associates  ".    
        //private   string ws_long_name = " Regional Medical Associates  ";

        //01   ws-originator-numbers.
       // private   string ws_originator_numbers_grp;

        //05  ws-originator-nbr-clinic-22  pic x(10)       value "0102024944".
        //private   string ws_originator_nbr_clinic_22 = "0102024944";
        //05  ws-originator-nbr-clinic-81  pic x(10)       value "0102006210".
        //private   string ws_originator_nbr_clinic_81 = "0102006210";
        //05  ws-originator-nbr-clinic-85  pic x(10)       value "0102018480".
        //private   string ws_originator_nbr_clinic_85 = "0102018480";
        //05  ws-originator-nbr-clinic-mp pic x(10)       value "0102117527".
        private   new string ws_originator_nbr_clinic_mp_child = "0102117527";
        // 01   ws-file-creation-nbr pic 9(4)        value 1.
        //private   int ws_file_creation_nbr = 1;

        //77  sel-clinic pic xx value zeroes.
        private   string sel_clinic;
        //77  sel-ok pic x value spaces.
        private   string sel_ok;
        //77  yearend-option pic x value "N". 
        private   string yearend_option = "N";
        //77  err-ind pic 99 		value zeroes.
        private   int err_ind;
        //77  max-nbr-lines pic 99   	value 60. 
        private   int max_nbr_lines = 60;
        //77  max-form-lines pic 99		value 44.    
        private   int max_form_lines = 44;
        //77  form-cnt pic 99  	value zeroes. 
        private   int form_cnt;
        //77  page-cnt pic 9999    	value zeroes. 
        private   int page_cnt;
        //77  total-earnings pic s9(8)v99 value zero.
        private   decimal total_earnings;
        //77  ws-difference pic s9(8)v99 value zero.
        private   decimal ws_difference;
        //77  ws-inits pic x(6)    value spaces.
        private   string ws_inits;
        //77  ws-inits-name pic x(30)   value spaces.
        private   string ws_inits_name;
        //77  ws-final-total pic 9(7)v99 value zeroes.
        private   decimal ws_final_total;
        //77  ws-bank-total pic 9(6)v99 value zeroes.
        private   decimal ws_bank_total;
        //77  ws-bank-total-1			pic 9(7)v99 value zeroes.
        private   decimal ws_bank_total_1;
        //77  ws-rounded-total pic 9(4) 	value zeroes.
        private   int ws_rounded_total;
        //77  cur-bank-cd-branch pic x(9)    value spaces.
        private   string cur_bank_cd_branch;
        //77  total-flag pic x value "N". 
        private   string total_flag = "N";
        //77  ws-print-percent pic 999v99 value zeroes.
        private   decimal ws_print_percent;
        //77  ws-print-gross-misc-total pic s9(6)v99 value zeroes.
        private   decimal ws_print_gross_misc_total;
        //77  ws-print-mtd-misc-total pic s9(6)v99 value zeroes.
        private   decimal ws_print_mtd_misc_total;
        //77  ws-print-ytd-misc-total pic s9(6)v99 value zeroes.
        private   decimal ws_print_ytd_misc_total;

        //77  ws-closing-msg-a pic x(50)   value  "Doctor Statements are in file: r123a". 
        private   string ws_closing_msg_a = "Doctor Statements are in file: r153a";
        //77  ws-closing-msg-b pic x(50)   value  "Bank Deposit list is in file:  r123b". 
        private   string ws_closing_msg_b = "Bank Deposit list is in file:  r153b";
        //77  ws-closing-msg-c pic x(50)   value  "Bank Cheques are in file:      r123c". 
        private   string ws_closing_msg_c = "Bank Cheques are in file:      r153c";

        //77   n-doc-nbr pic x(3)          value spaces.
        private   string n_doc_nbr;
        //77   n-doc-dept pic s9(2)         value zero.
        private   int n_doc_dept;
        //77   n-chgeft-amt-n pic s9(7)v99 value zero.
        private   decimal n_chgeft_amt_n;

        //77  print-file-a-name pic x(5)    value "r123a". 
        private   string print_file_a_name = "r153a";
        //77  print-file-b-name pic x(5)        value "r123b". 
        private   string print_file_b_name = "r153b";
        //77  print-file-c-name pic x(5)        value "r123c". 
        private   string print_file_c_name = "r153c";
        //77  print-summary-eft pic x(8)     value "r123ef". 
        private   string print_summary_eft = "r153ef";

        //77  ss-chq pic 99		value zeroes.
        private   int ss_chq;
        //77  ss-misc pic 99		value zeroes. 
        private   int ss_misc;
        //77  ss-amt pic 99		value zeroes. 
        private   int ss_amt;
        //77  ss-perc pic 99		value zeroes. 
        private   int ss_perc;
        //77  ss-mtd pic 9		value 1. 
        private   int ss_mtd = 1;
        //77  ss-ytd pic 9		value 2.              
        private   int ss_ytd = 2;
        //77  ss-mth-nbr pic 99		value zeroes. 
        private   int ss_mth_nbr;

        //77  eof-chq-reg-mstr pic x value "N". 
        private   string eof_chq_reg_mstr = "N";
        //77  eof-doctor-mstr pic x value "N". 
        private   string eof_doctor_mstr = "N";
        //77  eof-work-file pic x value "N". 
        private   string eof_work_file = "N";
        //77 eof-u119-chgeft-file pic x value "N". 
        private   string eof_u119_chgeft_file = "N";

        //77  common-status-file pic x(2)       value zero.
        private   string common_status_file;
        //77  status-prt-file-a pic xx value zero.
        private   string status_prt_file_a;
        //77  status-prt-file-b pic xx value zero.
        private   string status_prt_file_b;
        //77  status-prt-file-c pic xx value zero.
        private   string status_prt_file_c;
        //77  status-prt-file-d pic xx value zero.
        private   string status_prt_file_d;
        //77  status-dept-mstr pic x(11)       value spaces.
        private   string status_dept_mstr;
        //77  status-bank-mstr pic x(11)       value spaces.
        private   string status_bank_mstr;
        //77  status-cobol-bank-mstr pic x(2)        value zero.
        private   string status_cobol_bank_mstr;
        //77  status-chq-reg-mstr pic x(11)   value spaces.
        private   string status_chq_reg_mstr;
        //77  status-cobol-chq-reg-mstr pic xx value zero.
        private   string status_cobol_chq_reg_mstr;
        //77  status-iconst-mstr pic x(11)       value spaces.
        private   string status_iconst_mstr;
        //77  status-cobol-iconst-mstr pic xx value zero.
        private   string status_cobol_iconst_mstr;
        //77  status-doc-mstr pic x(11)       value spaces.
        private   string status_doc_mstr;
        //77  status-cobol-doc-mstr pic x(2)    value zero.
        private   string status_cobol_doc_mstr;
        //77  status-cobol-dept-mstr pic x(2)        value zero.
        private   string status_cobol_dept_mstr;
        //77  status-sort-file pic x(11)       value zeroes.
        private   string status_sort_file;
        //77  status-u119-chgeft-file pic x(11)       value zeroes.
        private   string status_u119_chgeft_file;

        private   string feedback_doc_mstr;
        //77  feedback-cheque-reg-mstr pic x(4)    value spaces.
        private   string feedback_cheque_reg_mstr;
        //77  feedback-iconst-mstr pic x(4)    value spaces.
        private   string feedback_iconst_mstr;

        // 01  ws-chq-date.
        private   string ws_chq_date_grp;
        // 05  ws-chq-yr pic 9(4)        value zeroes.
        private   int ws_chq_yr_child;
        // 05  ws-chq-mth pic 99		value zeroes. 
        private   int ws_chq_mth_child;
        // 05  ws-chq-day pic 99		value zeroes. 
        private   int ws_chq_day_child;

        // 01  ws-per-end-date.
        private   string ws_per_end_date_grp;
        //  05  ws-per-end-yr pic 9(4)        value zeroes.
        private   int ws_per_end_yr_child;
        // 05  ws-per-end-mth pic 99		value zeroes. 
        private   int ws_per_end_mth_child;
        // 05  ws-per-end-day pic 99		value zeroes. 
        private   int ws_per_end_day_child;

        // 01  counters.
        private   string counters_grp;
        // 05  ctr-chq-reads pic 9(7)    value zero.
        private   long ctr_chq_reads_child;
        // 05  ctr-u119-chgeft-reads pic 9(7)    value zero.
        private   long ctr_u119_chgeft_reads_child;
        // 05  ctr-wf-reads pic 9(7)    value zero.
        private   long ctr_wf_reads_child;
        // 05  ctr-wf-writes pic 9(7)    value zero.
        private   long ctr_wf_writes_child;
        //05  ctr-doc-mstr-reads pic 9(7)    value zero.
        private   long ctr_doc_mstr_reads_child;
        // 05  ctr-bank-mstr-reads pic 9(7)    value zero.
        private   long ctr_bank_mstr_reads_child;
        // 05  ctr-lines pic 99      value zero. 
        private   int ctr_lines_child;
        // 05  ctr-nbr-lines pic 99      value zero. 
        private   int ctr_nbr_lines_child;
        // 05  ctr-rpt-writes pic 9(7)    value zero.
        private   long ctr_rpt_writes_child;
        // 05  ctr-cheques pic 999     value zero. 
        private   int ctr_cheques_child;
        // 05  ctr-nbr-misc-lines pic 99      value zero. 
        private   int ctr_nbr_misc_lines_child;

        //01  ws-initials.
        private   string ws_initials_grp;
        //05  ws-1st-init.
        private   string ws_1st_init_grp_child;
        //10  ws-init1 pic x.
        private   string ws_init1_child;
        //10  ws-dot1 pic x.
        private   string ws_dot1_child;
        //05  ws-2nd-init.
        private   string ws_2nd_init_grp_child;
        //10  ws-init2 pic x.
        private   string ws_init2_child;
        //10  ws-dot2 pic x.
        private   string ws_dot2;
        //05  ws-3rd-init.
        private   string ws_3rd_init_grp_child;
        // 10  ws-init3 pic x.
        private   string ws_init3_child;
        // 10  ws-dot3 pic x.
        private   string ws_dot3_child;

        //01  ws-postal-code.
        private   string ws_postal_code_grp;
        // 05  ws-pc-153			pic xxx.
        private   string ws_pc_153_child;
        // 05  ws-pc-456			pic xxx. 
        private   string ws_pc_456_child;

        //01  ws-doctor-totals.
        private   string ws_doctor_totals_grp;
        // 05  ws-doc-totals-mtd-ytd occurs 2 times.
        private   string[] ws_doc_totals_mtd_ytd_grp_child = new string[2];
        //10  ws-misc-gross occurs 10 times pic s9(6)v99.
        private   decimal[,] ws_misc_gross_child = new decimal[11, 11];
        // 10  ws-misc-net occurs 10 times pic s9(6)v99.
        private   decimal[,] ws_misc_net_child = new decimal[11, 11];
        // 10  ws-bill-gross pic s9(6)v99.
        private   decimal[] ws_bill_gross_child = new decimal[3];
        // 10  ws-bill-net pic s9(6)v99.
        private   decimal[] ws_bill_net_child = new decimal[3];
        // 10  ws-inc pic s9(6)v99.
        private   decimal[] ws_inc = new decimal[3];
        // 10  ws-net-inc pic s9(6)v99.
        private   decimal[] ws_net_inc_child = new decimal[3];
        //10  ws-exp-amt pic s9(6)v99.
        private   decimal[] ws_exp_amt_child = new decimal[3];
        //10  ws-ceil-amt pic s9(6)v99.
        private   decimal[] ws_ceil_amt_child = new decimal[3];
        //10  ws-pay-due pic s9(6)v99.
        private   decimal[] ws_pay_due_child = new decimal[3];
        //10  ws-tax pic s9(6)v99.
        private   decimal[] ws_tax_child = new decimal[3];
        //10  ws-bank-deposit pic s9(6)v99.
        private   decimal[] ws_bank_deposit_child = new decimal[3];
        //10  ws-manual-chqs pic s9(6)v99.
        private   decimal[] ws_manual_chqs_child = new decimal[3];
        //05  ws-final-totals-mtd-ytd occurs 2 times.
        private   string[] ws_final_totals_mtd_ytd_grp_child = new string[3];
        //10  ws-fin-misc-gross occurs 10 times pic s9(8)v99.
        private   decimal[,] ws_fin_misc_gross = new decimal[11, 11];
        //10  ws-fin-misc-net occurs 10 times pic s9(8)v99.
        private   decimal[,] ws_fin_misc_net_child = new decimal[11, 11];
        //10  ws-fin-bill-gross pic s9(8)v99.
        private   decimal[] ws_fin_bill_gross_child = new decimal[3];
        //10  ws-fin-bill-net pic s9(8)v99.
        private   decimal[] ws_fin_bill_net_child = new decimal[3];
        //10  ws-fin-inc pic s9(8)v99.
        private   decimal[] ws_fin_inc_child = new decimal[3];

        //10  ws-fin-exp-amt pic s9(8)v99.
        private   decimal[] ws_fin_exp_amt_child = new decimal[3];
        //10  ws-fin-ceil-amt pic s9(8)v99.
        private   decimal[] ws_fin_ceil_amt_child = new decimal[3];
        //10  ws-fin-pay-due pic s9(8)v99.
        private   decimal[] ws_fin_pay_due_child = new decimal[3];
        //10  ws-fin-tax pic s9(8)v99.
        private   decimal[] ws_fin_tax_child = new decimal[3];
        //10  ws-fin-deposit pic s9(8)v99.
        private   decimal[] ws_fin_deposit_child = new decimal[3];
        //10  ws-fin-man-chqs pic s9(8)v99.
        private   decimal[] ws_fin_man_chqs_child = new decimal[3];

        // 77  ws-closing-msg-d pic x(50)       value  "EFT Disk File is in file: eft_tape". 
        private   string ws_closing_msg_d = "EFT Disk File is in file: eft_tape";

        //77  ws-closing-msg-e pic x(50)       value  "EFT Report Summary is in: r123eft". 
        private   string ws_closing_msg_e = "EFT Report Summary is in: r153eft";

        //77  status-prt-summary-eft pic xx value zeros.
        private   string status_prt_summary_eft;

        //77   datecheck-option pic x value "N". 
        private   string datecheck_option = "N";

        //77   ws-version-nbr pic 9(4)	value zeroes.
        private   int ws_version_nbr;
        //77   ws-record-count pic 999         value 1. 
        private   int ws_record_count = 1;

        //77   ws-transaction-type pic 999         value 470. 
        private   int ws_transaction_type = 470;
        //77   ws-payee-acc-nbr pic x(12)       value spaces.
        private   string ws_payee_acc_nbr;
        //77   ws-stored-trans-type pic 999         value zeroes. 
        private   int ws_stored_trans_type;

        //77   ws-sin-nbr pic x(19)       value spaces.
        private   string ws_sin_nbr;
        //77   ws-sundry pic x(15)       value spaces.
        private   string ws_sundry;
        //77   ws-invalid-indicator pic 9(11)       value zeroes.
        private   long ws_invalid_indicator;
        //77   ws-settlement-indicator pic 99          value   01. 
        private   int ws_settlement_indicator = 01;

        //77   ws-seg-two-six pic x(1200)     value spaces.
        private   string ws_seg_two_six;
        //77   ws-reserved pic x(22)       value zeroes.
        private   string ws_reserved;
        //77   i pic 99          value   01. 
        private   int i = 01;

        //77   ws-total-debit-value pic 9(12)v99 value zeroes.
        private   decimal ws_total_debit_value;
        //77   ws-total-debit-nbr pic 9(8)        value zeroes.
        private   int ws_total_debit_nbr;
        //77   ws-total-credit-value pic 9(12)v99 value zeroes.
        private   decimal ws_total_credit_value;
        //77   ws-total-credit-nbr pic 9(8)        value zeroes.
        private   int ws_total_credit_nbr;

        //77   ws-work-file-a pic x(16)       value "work_file_a_r153". 
        private   string ws_work_file_a = "work_file_a_r153";
        //77   ws-sorted-file pic x(16)       value "sorted_file_r153". 
        private   string ws_sorted_file = "sorted_file_r153";
        //77   ws-output-file pic x(13)       value "eft_tape_r153". 
        private   string ws_output_file = "eft_tape_r153";

        //01   ws-payee-name.
        private   string ws_payee_name_grp;
        //05  ws-payee-last-name pic x(24)   value spaces.
        private   string ws_payee_last_name_child;
        //05  ws-payee-initial pic x(6)    value spaces.
        private   string ws_payee_initial_child;

        //01  ws-fund-avail-date.        
        private   string ws_fund_avail_date_grp;
        // 05  ws-fund-yr pic 999 	value zeroes.
        private   int ws_fund_yr_child;
        //05  ws-fund-day pic 999 	value zeroes. 
        private   int ws_fund_day_child;

        //01   ws-tape-creation-date.        
        private   string ws_tape_creation_date_grp;
        //05  ws-tape-yr pic 999		value zeroes.
        private   int ws_tape_yr_child;
        //05  ws-tape-day pic 999		value zeroes. 
        private   int ws_tape_day_child;

        //01   ws-rec-type.
        private   string ws_rec_type_grp;
        //05  ws-rec-a pic x value 'A'. 
        private   string ws_rec_a_child = "A";
        // 05  ws-rec-d pic x value 'D'. 
        private   string ws_rec_d_child = "D";
        // 05  ws-rec-z pic x value 'Z'. 
        private   string ws_rec_z_child = "Z";

        //01   ws-bank-code.
        private   string ws_bank_code_grp;
        //  05  ws-bank-nbr pic 9(4). 
        private   int ws_bank_nbr_child;
        // 05  ws-bank-branch pic 9(5). 
        private   long ws_bank_branch_child;

        //*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
        //01   ws-xx pic xx value "  ". 
        private   string ws_xx = "  ";

        // 01  month-descs-and-max-days-mth.
        private   string month_descs_and_max_days_mth_grp;
        //05  mth-desc-max-days.
        private   string mth_desc_max_days_grp_child = "31  JANUARY031" + "29 FEBRUARY059" + "31    MARCH090" + "30    APRIL120" + "31      MAY151" + "30     JUNE181" + "31     JULY212" + "31   AUGUST243" + "30SEPTEMBER273" + "31  OCTOBER304" + "30 NOVEMBER334" + "31 DECEMBER365";

        //   05  mth-desc-max-days-r redefines mth-desc-max-days.
        private   string mth_desc_max_days_r_child_redefines;  // = mth_desc_max_days_grp_child;
        // 10  mth-desc-max-days-occur occurs  12  times.
        private   string[] mth_desc_max_days_occur_grp_child = new string[12];
        //15  max-nbr-days pic 99.  
        private   int[] max_nbr_days = new int[12];
        //15  mth-desc pic x(9).  
        private   string[] mth_desc_child = new string[12];
        //15  nbr-julian-days-ytd pic 9(3).  
        private   int[] nbr_julian_days_ytd_child = new int[12];

        // 01  error-message-table. 
        private   string error_message_table_grp;

        //05  error-messages. 
        private   string[] error_messages = { "", "Invalid REPLY", "Invalid YEAR", "Invalid MONTH", "Invalid DAY", "Invalid CLINIC Number", "No CHEQUE Records for this Clinic", "CANNOT access conmstr Rec 3", "CHEQUE DATE less than PERIOD END DATE", "Invalid PAYROLL Clinic entered" };
        // 10  filler				pic x(60)   value  "Invalid REPLY". 		            
        // 10  filler				pic x(60)   value  "Invalid YEAR". 		            
        // 10  filler				pic x(60)   value  "Invalid MONTH". 		            
        // 10  filler				pic x(60)   value  "Invalid DAY". 		            
        // 10  filler				pic x(60)   value  "Invalid CLINIC Number". 		            
        // 10  filler				pic x(60)   value  "No CHEQUE Records for this Clinic". 		            
        // 10  filler				pic x(60)   value  "CANNOT access conmstr Rec 3". 		            
        // 10  filler				pic x(60)   value  "CHEQUE DATE less than PERIOD END DATE". 		            
        // 10  filler				pic x(60)   value  "Invalid PAYROLL Clinic entered".    

        // 05  error-messages-r redefines error-messages. 
        private string[] error_messages_r_redefines; // = error_messages; //new string[10];
        // 10  err-msg				pic x(60)  occurs 10 times.
        private   string[] err_msg_child = new string[10];

        // 01  err-msg-comment pic x(60). 
        private   string err_msg_comment;

        //01  e1-error-line.
        private   string e1_error_line_grp;
        // 05  e1-error-word pic x(13)    value  "***  ERROR - ". 
        private   string e1_error_word_child = "***  ERROR - ";
        // 05  e1-error-msg pic x(119). 
        private   string e1_error_msg_child;

        // 01  r153a-head-first.
        private   string r153a_head_first_grp = "R153A" + new string(' ', 127);
        //05  filler pic x(5)    value  "R153A". 		
        //05  filler pic x(127)      value spaces.

        //01  r153a-head-1. 
        private string r153a_head_1_grp; // = "TO:".PadRight(7) + "DR." + Util.Str(r153a_h1_inits_name_child).PadRight(30) + new string(' ', 3) + "NBR:".PadRight(6) + Util.Str(r153a_h1_doc_nbr_child).PadRight(3);
        //05  filler pic x(7)    value  "TO:". 		        
        //05  filler pic xxxx value  "DR.". 		        
        //05  r123a-h1-inits-name pic x(30)   value spaces.
        private   string r153a_h1_inits_name_child;
        // 05  filler pic xxx value spaces.
        // 05  filler pic x(6)    value  "NBR:". 		                
        // 05  r123a-h1-doc-nbr pic xxx value spaces.        
        private   string r153a_h1_doc_nbr_child;

        // 01  r153a-head-1-1. 
        private string r153a_head_1_1_grp; // = new string(' ', 7) + Util.Str(r153a_h1_1_dept_name_child).PadRight(30) + new string(' ', 7) + "DEPT:".PadRight(6) + r153a_h1_dept_child.ToString(); 
        // 05 filler pic x(7)        value spaces.
        // 05 r123a-h1-1-dept-name pic x(30). 
        private   string r153a_h1_1_dept_name_child;
        // 05 filler pic x(7)    value spaces.
        // 05  filler pic x(6)    value   "DEPT:". 		        
        // 05  r123a-h1-dept pic 99		value zeroes.
        private   int r153a_h1_dept_child;

        //01  r153a-head-2. 
        private   string r153a_head_2_grp = "FROM:" + "MR. JOHN E. MCCUTCHEON, FACMGA, EXECUTIVE DIRECTOR";

        //01  r153a-head-3. 
        private string r153a_head_3_grp; // = "DATE:" + r153a_h3_yr_child.ToString() + "/" + r153a_h3_mth_child.ToString() + "/" + r153a_h3_day_child.ToString();
        //05  filler pic x(7)    value  "DATE:". 		                
        //05  r123a-h3-yr pic 9(4)        value zeroes.
        private   int r153a_h3_yr_child;
        //05  filler pic x value "/". 
        //05  r123a-h3-mth pic 99		value zeroes. 
        private   int r153a_h3_mth_child;
        // 05  filler pic x value "/". 
        // 05  r123a-h3-day pic 99		value zeroes. 
        private   int r153a_h3_day_child;

        //01  r153a-head-4. 
        private   string r153a_head_4_grp = new string(' ', 29) + "REGIONAL MEDICAL ASSOCIATES".PadRight(40);
        // 05  filler pic x(29)   value spaces.
        // 05  filler pic x(40)   value 
        //     "REGIONAL MEDICAL ASSOCIATES". 

        //01  r153a-head-5. 
        private string r153a_head_5_grp; // = new string(' ', 14) + "STATEMENT OF EARNINGS FOR THE PERIOD ENDING".PadRight(44) + r153a_h5_yr_child.ToString() + "/" + r153a_h5_mth_child.ToString() + "/" + r153a_h5_day_child.ToString();
        //05  filler pic x(14)   value spaces.
        //05  filler pic x(44)   value 
        //"STATEMENT OF EARNINGS FOR THE PERIOD ENDING". 
        // 05  r123a-h5-yr pic 9(4)        value zeroes.
        private   int r153a_h5_yr_child;
        //05  filler pic x value "/". 
        //05  r123a-h5-mth pic 99		value zeroes. 
        private   int r153a_h5_mth_child;
        //05  filler pic x value "/". 
        //05  r123a-h5-day pic 99		value zeroes.  
        private   int r153a_h5_day_child;

        // 01  r153a-head-6. 
        private   string r153a_head_6_grp = new string(' ', 67) + "SINCE";
        // 05  filler pic x(67)   value spaces.
        //05  filler pic x(5)    value  "SINCE". 

        //01  r153a-head-7. 
        private string r153a_head_7_grp; // = new string(' ', 45) + "THIS MONTH".PadRight(10) + new string(' ', 8) + "JULY 1, " + r153a_h7_yr_child.ToString();
        //05  filler pic x(45)   value spaces.
        //05  filler pic x(10)   value 
        //    "THIS MONTH". 
        //05  filler pic x(8)    value spaces.
        //05  filler pic x(8)    value 
        //    "JULY 1, ".         
        //05  r123a-h7-yr pic 9(4). 
        private   int r153a_h7_yr_child;

        //01  r153a-tot-head.
        private   string r153a_tot_head_grp = new string(' ', 20) + "***** STATEMENT OF EARNINGS FINAL TOTALS *****".PadRight(60);
        //05  filler pic x(20)   value spaces.
        //05  filler pic x(60)   value  "***** STATEMENT OF EARNINGS FINAL TOTALS *****". 

        // 01  underscore-detail.
        private   string underscore_detail_grp = new string(' ', 6) + "-----------" + new string(' ', 26) + "------------" + new string(' ', 7) + "-------------";
        private   string underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";

        //01  r153a-prt-1. 
        private string r153a_prt_1_grp; // = new string(' ', 6) + r153a_p1_lit_1_child + String.Format("{0:0,0.00}", r153a_p1_gross_child) + new string(' ', 1) + "MISC.INCOME @".PadRight(14) + String.Format("{0:0,0.00}", r153a_p1_percent_child) + "%" + new string(' ', 3)
                                        //             + r153a_p1_lit_2_child + String.Format("{0:0,0.00}", r153a_p1_mtd_child) + new string(' ', 6) + r153a_p1_lit_3_child + String.Format("{0:0,0.00}", r153a_p1_ytd_child);
        // 05  filler pic x(6)    value spaces.
        // 05  r153a-p1-lit-1				pic x       value "$". 
        private   string r153a_p1_lit_1_child = "$";
        // 05  r123a-p1-gross pic zzz, zz9.99-	value zeroes.         
        private   decimal r153a_p1_gross_child;
        // 05  filler pic x value spaces.
        // 05  filler pic x(14)   value  "MISC.INCOME @".         		        
        // 05  r123a-p1-percent pic zz9.99.         
        private   decimal r153a_p1_percent_child;
        //  05  r153a-p1-percent-r redefines r123a-p1-percent pic xxxxxx.
        private string r153a_p1_percent_r_child_redefine; // = r153a_p1_percent_child.ToString();
        // 05  filler pic x value "%".         
        // 05  filler pic x(3)    value spaces.
        // 05  r153a-p1-lit-2				pic x       value "$". 
        private   string r153a_p1_lit_2_child = "$";
        //  05  r153a-p1-mtd pic zzzz, zz9.99-	value zeroes. 
        private   decimal r153a_p1_mtd_child;
        //   05  filler pic x(6)    value spaces.         
        //   05  r123a-p1-lit-3				pic x       value "$".                   
        private   string r153a_p1_lit_3_child = "$";
        //   05  r153a-p1-ytd pic zzzzz, zz9.99-	value zeroes.  
        private   decimal r153a_p1_ytd_child;

        //01  r153a-prt-2. 
        private string r153a_prt_2_grp; // = new string(' ', 6) + "$" + String.Format("{0:0,0.00}", r153a_p2_gross_child) + new string(' ', 2) + "TOTAL MISC. INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p2_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p2_ytd_child);
        //05  filler pic x(6)    value spaces.
        //05  filler pic x value "$". 
        //05  r123a-p2-gross pic zzz, zz9.99-	value zeroes. 
        private   decimal r153a_p2_gross_child;
        // 05  filler pic xx value spaces.
        //05  filler pic x(23)   value  "TOTAL MISC. INCOME". 		    
        // 05  filler pic x value "$". 
        //05  r123a-p2-mtd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p2_mtd_child;
        //05  filler pic x(6)    value spaces.
        //05  filler pic x value "$". 
        //05  r123a-p2-ytd pic zzzzz, zz9.99-	value zeroes. 
        private   decimal r153a_p2_ytd_child;

        //01  r153a-prt-3. 
        private string r153a_prt_3_grp; // = new string(' ', 2) + Util.Str(r153a_p3_plus_lit_child).PadRight(6) + new string(' ', 5) + Util.Str(r153a_p3_lit_1_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_gross_child) + " " + "BILLINGS    @ " + string.Format("{0:0,0.00}", r153a_p3_percent_child) + "%" + new string(' ', 3) + Util.Str(r153a_p3_lit_2_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_mtd_child) + new string(' ', 6) + Util.Str(r153a_p3_lit_3_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_ytd_child);
        //05  filler pic xx value spaces.
        //05  r123a-p3-plus-lit pic x(6).              
        private   string r153a_p3_plus_lit_child;
        //05  r123a-p3-plus-lit-r redefines r123a-p3-plus-lit.
        private string r153a_p3_plus_lit_r_child_redefine; // = r153a_p3_plus_lit_child;
        //10  filler pic x(5). 
        //10  r123a-p3-lit-1			pic x.
        private   string r153a_p3_lit_1_child;
        //05  r123a-p3-gross pic zz, zz9.99-	value zeroes.     
        private   decimal r153a_p3_gross_child;
        //05  filler pic x value spaces.
        //05  filler pic x(14)   value  "BILLINGS    @ ".     		    
        //05  r123a-p3-percent pic zz9.99. 
        private   decimal r153a_p3_percent_child;
        //05  r123a-p3-percent-r redefines r123a-p3-percent pic xxxxxx.
        private string r153a_p3_percent_r_child_redefine; // = r153a_p3_percent_child.ToString();
        //05  filler pic x value "%".     
        //05  filler pic x(3)    value spaces.
        //05  r123a-p3-lit-2				pic x       value spaces. 
        private   string r153a_p3_lit_2_child;
        //05  r123a-p3-mtd pic zzzz, zz9.99-	value zeroes. 
        private   decimal r153a_p3_mtd_child;
        //05  filler pic x(6)    value spaces.
        //05  r123a-p3-lit-3				pic x       value spaces. 
        private   string r153a_p3_lit_3_child;
        //05  r123a-p3-ytd pic zzzzz, zz9.99-	value zeroes. 
        private   string r153a_p3_ytd_child;

        //01  r153a-prt-3-a.
        private string r153a_prt_3_a_grp; // = new string(' ', 20) + "LESS FACULTY EXPENSE".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p3_a_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p3_a_ytd_child);
        // 05  filler pic x(20)   value spaces.
        // 05  filler pic x(23)   value  "LESS FACULTY EXPENSE". 		        
        // 05  filler pic x value "$". 
        // 05  r123a-p3-a-mtd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p3_a_mtd_child;
        // 05  filler pic x(6)    value spaces.
        // 05  filler pic x value "$". 
        // 05  r123a-p3-a-ytd pic zzzzz, zz9.99-	value zeroes. 
        private   decimal r153a_p3_a_ytd_child;

        //01  r153a-prt-4. 
        private string r153a_prt_4_grp; // = new string(' ', 20) + "TOTAL INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p4_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p4_ytd_child);
        //05  filler pic x(20)   value spaces.
        // 05  filler pic x(23)   value  "TOTAL INCOME". 		        
        // 05  filler pic x value "$". 
        // 05  r123a-p4-mtd pic zzzz,zz9.99-	value zeros.
        private   decimal r153a_p4_mtd_child;
        //    05  filler pic x(6)    value spaces.
        //  05  filler pic x value "$". 
        //  05  r123a-p4-ytd pic zzzzz, zz9.99-	value zeroes. 
        private   decimal r153a_p4_ytd_child;

        // 01  r153a-prt-4-a.
        private string r153a_prt_4_a_grp; // = new string(' ', 20) + "NET INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p4_a_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p4_a_ytd_child);
        // 05  filler pic x(20)   value spaces.
        // 05  filler pic x(23)   value  "NET INCOME". 		        
        // 05  filler pic x value "$". 
        // 05  r123a-p4-a-mtd pic zzzz,zz9.99-	value zeros.
        private   decimal r153a_p4_a_mtd_child;
        // 05  filler pic x(6)    value spaces.
        // 05  filler pic x value "$". 
        // 05  r123a-p4-a-ytd pic zzzzz, zz9.99-	value zeroes. 
        private   decimal r153a_p4_a_ytd_child;

        // 01  r153a-prt-5. 
        private string r153a_prt_5_grp; // = new string(' ', 20) + "CEILING IS".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p5_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p5_ytd_child);
        // 05  filler pic x(20)   value spaces.
        // 05  filler pic x(23)   value  "CEILING IS". 		        
        // 05  filler pic x value "$". 
        // 05  r123a-p5-mtd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p5_mtd_child;
        // 05  filler pic x(6)    value spaces.
        // 05  filler pic x value "$". 
        // 05  r123a-p5-ytd pic zzzzz, zz9.99-	value zeroes.
        private   decimal r153a_p5_ytd_child;

        // 01  r153a-prt-6. 
        private string r153a_prt_6_grp; // = new string(' ', 8) + "PAYMENT DUE".PadRight(35) + "$" + string.Format("{0:0,0.00}", r153a_p6_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p6_ytd_child);
        // 05  filler pic x(8)    value spaces.
        // 05  filler pic x(35)   value  "PAYMENT DUE". 		    
        // 05  filler pic x value "$". 
        // 05  r123a-p6-mtd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p6_mtd_child;
        // 05  filler pic x(6)    value spaces.
        // 05  filler pic x value "$". 
        // 05  r123a-p6-ytd pic zzzzz, zz9.99-	value zeroes. 
        private   string r153a_p6_ytd_child;

        //01  r153a-prt-7. 
        private string r153a_prt_7_grp; // = new string(' ', 8) + "LESS INCOME TAX".PadRight(34) + "(" + string.Format("{0:0,0.00}", r153a_p7_mtd_child) + ")" + "(" + string.Format("{0:0,0.00}", r153a_p7_ytd_child) + ")";
        //05  filler pic x(8)    value spaces.
        //05  filler pic x(34)   value "LESS INCOME TAX".
        //05  filler pic xx value "(". 
        //05  r123a-p7-mtd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p7_mtd_child;
        //05  filler pic x(05)   value ")". 
        // 05  filler pic x(02)   value "(". 
        // 05  r123a-p7-ytd pic zzzzz,zz9.99-	value zeroes.
        private   string r153a_p7_ytd_child;
        //05  filler pic x value ")". 

        //01  r153a-prt-8. 
        private string r153a_prt_8_grp; // = new string(' ', 8) + "AUTOMATIC BANK DEPOSIT ON ".PadRight(26) + r153a_p8_yr_child.ToString() + "/" + r153a_p8_mth_child.ToString() + "/" + r153a_p8_day_child.ToString() + " $" + string.Format("{0:0,0.00}", r153a_p8_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p8_ytd_child);
        //05  filler pic x(08)     value spaces.
        //05  filler pic x(26)     value "AUTOMATIC BANK DEPOSIT ON ".  
        //05  r153a-p8-yr pic 9(04).      
        private   int r153a_p8_yr_child;
        // 05  filler pic x(01)     value "/". 
        // 05  r153a-p8-mth pic 9(02). 
        private   int r153a_p8_mth_child;
        //05  filler pic x(01)     value "/". 
        // 05  r153a-p8-day pic 9(02). 
        private   int r153a_p8_day_child;
        // 05  filler pic x(02)     value " $". 
        // 05  r153a-p8-mtd pic zzzz,zz9.99-  value zero.
        private   decimal r153a_p8_mtd_child;
        //05  filler pic x(06)     value spaces.
        // 05  filler pic x(01)     value "$". 
        // 05  r153a-p8-ytd pic zzzzz,zz9.99- value zero.
        private   decimal r153a_p8_ytd_child;

        //01  r153a-prt-9.       
        private string r153a_prt_9_grp; // = new string(' ', 8) + Util.Str(yearend_label_child).PadRight(35) + "$" + string.Format("{0:0,0.00}", r153a_p9_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p9_ytd_child);
        // 05  filler pic x(08)   value spaces.
        //05  yearend-label pic x(35)   value spaces.
        private   string yearend_label_child = new string(' ', 35);
        //05  filler pic x(01)   value "$". 
        //05  r153a-p9-mtd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p9_mtd_child;
        //05  filler pic x(06)   value spaces.
        // 05  filler pic x(01)   value "$". 
        // 05  r153a-p9-ytd pic zzzz,zz9.99-	value zeroes.
        private   decimal r153a_p9_ytd_child;

        //01  r153a-prt-9-a.
        private string r153a_prt_9_a_grp; // = new string(' ', 8) + new string(' ', 35) + new string(' ', 20) + string.Format("{0:0,0.00}", r153a_p9_a_ytd);
        //05  filler pic x(08)       value spaces.
        //05  filler pic x(35)       value
        //05  filler pic x(20)       value spaces.
        //05  r153a-p9-a-ytd pic zzzzz, zz9.99-       value ze
        private   decimal r153a_p9_a_ytd;

        //01  r153a-prt-10.    
        private   string r153a_prt_10_grp = new string(' ', 8) + "A DETAILED LIST SHOWING EACH SERVICE FOR THE CURRENT MONTH IS MAILED".PadRight(68);
        //05  filler pic x(8)    value spaces.
        //05  filler pic x(68)   value  "A DETAILED LIST SHOWING EACH SERVICE FOR THE CURRENT MONTH IS MAILED". 

        //01  r153a-prt-11.     
        private   string r153a_prt_11_grp = new string(' ', 8) + "TO YOUR OFFICE AT THE END OF EACH MONTH.  IF I CAN BE OF ANY ASSISTANCE,".PadRight(78);
        //05  filler pic x(8)    value spaces.
        //05  filler pic x(78)   value  "TO YOUR OFFICE AT THE END OF EACH MONTH.  IF I CAN BE OF ANY ASSISTANCE,". 

        //01  r153a-prt-12.     
        private   string r153a_prt_12_grp = new string(' ', 8) + "PLEASE CALL ME AT EXTENSION 2170 OR 525-9766.".PadRight(68);
        //05  filler pic x(8)    value spaces.
        //05  filler pic x(68)   value  "PLEASE CALL ME AT EXTENSION 2170 OR 525-9766.". 

        //    **************************************************************** 
        //    * for yearend only.
        //    ************************************************************ 

        // 01  r153a-prt-13. 
        private   string r153a_prt_13_grp = new string(' ', 20) + "FINAL YEAREND STATEMENT".PadRight(112);
        // 05  filler pic x(20)   value spaces.
        // 05  filler pic x(112)      value   "FINAL YEAREND STATEMENT". 

        //01  r153a-prt-14. 
        private   string r153a_prt_14_grp = new string(' ', 20) + "G.S.T. INCLUDED, G.S.T. REGISTRATION NUMBER R104453774".PadRight(112);
        //05  filler pic x(20)   value spaces.
        //05  filler pic x(112)      value              "G.S.T. INCLUDED, G.S.T. REGISTRATION NUMBER R104453774". 

        //01  r153a-prt-err.
        private   string r153a_prt_err_grp = "********************" + "ERROR - COLUMNS DO NOT BALANCE".PadRight(30) + "********************";
        //05  filler pic x(20)   value  "********************". 		        
        //05  filler pic x(30)   value  "ERROR - COLUMNS DO NOT BALANCE". 		        
        //05  filler pic x(20)   value  "********************". 

        // 01  r153b-head-first.
        private   string r153b_head_first_grp = "R153B" + new string(' ', 72);
        //05  filler pic x(5)    value "R123B". 
        //05  filler pic x(72)   value spaces.

        // 01  r153b-head-1. 
        private string r153b_head_1_grp; // = " " + r153b_h1_page_child.ToString() + new string(' ', 12) + Util.Str(r153b_h1_bank_name_child).PadRight(30) + new string(' ', 21);
        // 05  filler pic x value spaces.
        // 05  r123b-h1-page pic zzz9 value zeroes.
        private   int r153b_h1_page_child;
        // 05  filler pic x(12)   value spaces.
        // 05  r123b-h1-bank-name pic x(30)   value spaces.
        private   string r153b_h1_bank_name_child = new string(' ', 30);
        // 05  filler pic x(21)   value spaces.

        //01  r153b-head-2. 
        private string r153b_head_2_grp; // = new string(' ', 17) + Util.Str(r153b_h2_bank_addr_child).PadRight(43) + r153b_h2_mth_child.ToString() + " " + r153b_h2_day_child.ToString() + " " + r153b_h2_yr_child.ToString() + new string(' ', 9);
        //05  filler pic x(17)   value spaces.
        //05  r123b-h2-bank-addr pic x(43)   value spaces.
        private   string r153b_h2_bank_addr_child = new string(' ', 43);
        //05  r123b-h2-mth pic 99		value zeroes. 
        private   int r153b_h2_mth_child;
        //05  filler pic x value spaces.
        //05  r123b-h2-day pic 99		value zeroes. 
        private   int r153b_h2_day_child;
        //05  filler pic x value spaces.
        //05  r123b-h2-yr pic 9(4)        value zeroes.
        private   int r153b_h2_yr_child;
        //05  filler pic x(9)    value spaces.

        //01  r153b-head-2a.
        private string r153b_head_2a_grp; // = new string(' ', 17) + Util.Str(r153b_h2a_bank_addr_child).PadRight(60);
        //05  filler pic x(17)   value spaces.
        //05  r123b-h2a-bank-addr pic x(60)   value spaces.
        private   string r153b_h2a_bank_addr_child = new string(' ', 60);

        //01  r153b-head-3. 
        private string r153b_head_3_grp; // = new string(' ', 17) + Util.Str(r153b_h3_pc_153).PadRight(3) + " " + Util.Str(r153b_h3_pc_456_child).PadRight(3) + new string(' ', 61);
        // 05  filler pic x(17)   value spaces.
        //05  r153b-h3-pc-153			pic xxx. 
        private   string r153b_h3_pc_153 = new string(' ', 3);
        //05  filler pic x value spaces.
        // 05  r153b-h3-pc-456			pic xxx. 
        private   string r153b_h3_pc_456_child;
        // 05  filler pic x(61)   value spaces.

        //01  r153b-prt-1.    
        private string r153b_prt_1_grp; // = new string(' ', 9) + Util.Str(r153b_p1_acct_child).PadRight(12) + new string(' ', 2) + Util.Str(r153b_p1_dr_lit_child).PadRight(4) + Util.Str(r153b_p1_inits_child).PadRight(6) + Util.Str(r153b_p1_name_child).PadRight(24) + " " + string.Format("{0:C}", r153b_p1_pay_child);
        //05  filler pic x(9). 
        //05  r153b-p1-acct pic x(12). 
        private   string r153b_p1_acct_child = new string(' ', 12);
        //05  filler pic x(2). 
        //05  r153b-p1-dr-lit pic x(4). 
        private   string r153b_p1_dr_lit_child = new string(' ', 4);
        //05  r153b-p1-inits pic x(6). 
        private   string r153b_p1_inits_child = new string(' ', 6);
        //05  r153b-p1-name pic x(24). 
        private   string r153b_p1_name_child = new string(' ', 24);
        //05  filler pic x.
        //05  r153b-p1-pay pic $zzzz,zz9vb99.
        private   decimal r153b_p1_pay_child;

        //01  r153c-head-first.
        private   string r153c_head_first_grp = "R153C" + new string(' ', 80);
        //05  filler pic x(5)  value "R153C". 
        //05  filler pic x(80) value spaces.

        //01 r153c-head-1. 
        private   string r153c_head_1_grp = "  RMA MONTH'S EARNINGS".PadRight(85);
        // 05  filler pic x(85) value  "  RMA MONTH'S EARNINGS". 

        //01  r153c-prt-1. 
        private string r153c_prt_1_grp; // = new string(' ', 27) + string.Format("{0:C}", r153c_p1_chq_amt_child) + new string(' ', 12) + Util.Str(r153c_p1_mth_child).PadRight(10) + r153c_p1_day_child.ToString() + Util.Str(r153c_p1_comma_child).PadRight(2) + r153c_p1_yr_child.ToString();
        //05  filler pic x(27). 
        //05  r153c-p1-chq-amt pic $$$$,$$9vb99.
        private   decimal r153c_p1_chq_amt_child;
        //05  filler pic x(12). 
        //05  r153c-p1-mth pic x(10). 
        private   string r153c_p1_mth_child = new string(' ', 10);
        //05  r153c-p1-day pic z9.
        private   int r153c_p1_day_child;
        //05  r153c-p1-comma pic x(2). 
        private   string r153c_p1_comma_child = new string(' ', 2);
        //05  r153c-p1-yr pic 9(4). 
        private   int r153c_p1_yr_child;

        //01  r153c-prt-2. 
        private string r153c_prt_2_grp; // = new string(' ', 8) + Util.Str(r153c_p2_lit1_chld).PadRight(16) + r153c_p2_hundreds_child.ToString() + Util.Str(r153c_p2_lit2_child).PadRight(28) + string.Format("{0:c}", r153c_p2_chq_amt_child);
        //05  filler pic x(8). 
        //05  r153c-p2-lit1 pic x(16). 
        private   string r153c_p2_lit1_chld = new string(' ', 16);
        //05  r153c-p2-hundreds pic ***9. 
        private   int r153c_p2_hundreds_child;
        //05  r153c-p2-lit2 pic x(28).    
        private   string r153c_p2_lit2_child = new string(' ', 28);
        //05  r153c-p2-chq-amt pic $$$$,$$9.99. 
        private   decimal r153c_p2_chq_amt_child;

        //01  r153c-prt-3. 
        private string r153c_prt_3_grp; // = new string(' ', 8) + Util.Str(r153c_p3_pc_153_child).PadRight(3) + " " + Util.Str(r153c_p3_pc_456_child).PadRight(3);
        //05  filler pic x(8). 
        //05  r123c-p3-pc-123			pic xxx.
        private   string r153c_p3_pc_153_child = new string(' ', 3);
        //05  filler pic x.
        //05  r123c-p3-pc-456			pic xxx. 
        private   string r153c_p3_pc_456_child = new string(' ', 3);

        //01  r153c-prt-4. 
        private string r153c_prt_4_grp; // = new string(' ', 8) + Util.Str(r153c_p4_bank_name_child).PadRight(77);
        //05  filler pic x(8). 
        //05  r153c-p4-bank-name pic x(77). 
        private   string r153c_p4_bank_name_child = new string(' ', 77);

        //01  r153c-prt-5. 
        private string r153c_prt_5_grp; // = new string(' ', 8) + Util.Str(r153c_p5_bank_addr1_child).PadRight(77);
        //05  filler pic x(8). 
        //05  r123c-p5-bank-addr1 pic x(77). 
        private   string r153c_p5_bank_addr1_child = new string(' ', 77);

        //01  r153c-prt-5a.
        private string r153c_prt_5a_grp; // = new string(' ', 8) + Util.Str(r153c_p5_bank_addr2_child).PadRight(77);
        //05  filler pic x(8). 
        //05  r153c-p5-bank-addr2 pic x(77). 
        private   string r153c_p5_bank_addr2_child = new string(' ', 77);

        //01  r153c-prt-6. 
        private string r153c_prt_6_grp; // = new string(' ', 8) + Util.Str(r153c_p6_city_prov_child).PadRight(77);
        //05  filler pic x(8). 
        //05  r153c-p6-city-prov pic x(77). 
        private   string r153c_p6_city_prov_child = new string(' ', 77);

        //01 r153c-prt-7.                           
        private string r153c_prt_7_grp; // = new string(' ', 9) + Util.Str(r153c_p7_tot_chq_child).PadRight(14) + r153c_p7_nbr_chqs_child.ToString() + Util.Str(r153c_p7_tot_amt_child).PadRight(13) + string.Format("{0:0,0.00}", r153c_p7_fin_total_child);
        //05  filler pic x(9). 
        //05  r153c-p7-tot-chq pic x(14). 
        private   string r153c_p7_tot_chq_child = new string(' ', 14);
        //05  r153c-p7-nbr-chqs pic zzz9.
        private   int r153c_p7_nbr_chqs_child;
        //05  r153c-p7-tot-amt pic x(13). 
        private   string r153c_p7_tot_amt_child = new string(' ', 13);
        //05  r153c-p7-fin-total pic zzzz,zz9.99. 
        private   decimal r153c_p7_fin_total_child;

        //01  blank-line.
        private   string blank_line_grp = new string(' ', 132);
        //05  filler pic x(132)  value spaces.

        //01  month-table.
        private string month_table_grp; // = months_list_child;
        //    05  months-list.
        private   string months_list_child = "JANUARY".PadRight(9) + "FEBRUARY".PadRight(9) + "MARCH".PadRight(9) + "APRIL".PadRight(9) + "MAY".PadRight(9) + "JUNE".PadRight(9) +
                                                  "JULY".PadRight(9) + "AUGUST".PadRight(9) + "SEPTEMBER".PadRight(9) + "OCTOBER".PadRight(9) + "NOVEMBER".PadRight(9) + "DECEMBER".PadRight(9);

        //05  months-list-1 redefines months-list.
        private string months_list_1_child; // = months_list_child;
        //10  t-month pic x(9) occurs 12 times.
        private   string[] t_month_child = { "JANUARY".PadRight(9), "FEBRUARY".PadRight(9),  "MARCH".PadRight(9) , "APRIL".PadRight(9) , "MAY".PadRight(9) , "JUNE".PadRight(9),
                                                  "JULY".PadRight(9) , "AUGUST".PadRight(9) , "SEPTEMBER".PadRight(9) , "OCTOBER".PadRight(9) , "NOVEMBER".PadRight(9) , "DECEMBER".PadRight(9) };


        //01  eft-prt-head.
        private   string eft_prt_head_grp = "R153EF" + new string(' ', 126);
        //  05  filler pic x(6)   value "R153EF". 
        //  05  filler pic x(126) value spaces.

        //01  eft-prt-1. 
        private   string eft_prt_1_grp = "               SUMMARY REPORT FOR E.F.T. TAPE CREATION  ".PadRight(80);
        // 05  filler pic x(80)  value "               SUMMARY REPORT FOR E.F.T. TAPE CREATION  ". 

        //01  eft-prt-2. 
        private string eft_prt_2_grp; // = new string(' ', 20) + "FILE CREATION NUMBER : ".PadRight(30) + string.Format("{0:0}", eft_creation_child);
       //   05  filler pic x(20)  value spaces.
       //   05  filler pic x(30)  value "FILE CREATION NUMBER : ". 
       //   05  eft-creation pic zzz9.
        private   int eft_creation_child;

        //01  eft-prt-3. 
        private string eft_prt_3_grp; // = new string(' ', 20) + "VERSION NUMBER       :".PadRight(30) + eft_version_child.ToString();
        //05  filler pic x(20)  value spaces.
        //05  filler pic x(30)  value "VERSION NUMBER       :". 
        //05  eft-version pic zzz9.
        private   int eft_version_child;

        //01  eft-prt-4. 
        private string eft_prt_4_grp; // = new string(' ', 20) + "DATE FUND TO BE AVAILABLE : ".PadRight(30) + eft_f_yr_child.ToString() + "/" + eft_f_day_chld.ToString() + "   JULIAN DATE".PadRight(20);
        //05  filler pic x(20)  value spaces.
        //05  filler pic x(30)  value "DATE FUND TO BE AVAILABLE : ". 
        //05  eft-f-yr pic z99.
        private   int eft_f_yr_child;
        //05  filler pic x value "/". 
        //05  eft-f-day pic zz9.
        private   int eft_f_day_chld;
        //05  filler pic x(20)  value "   JULIAN DATE". 

        //01  eft-prt-5. 
        private string eft_prt_5_grp; // = new string(' ', 20) + "TOTAL NUMBER OF RECORDS      : ".PadRight(34) + eft_record_child.ToString();
        //05  filler pic x(20)  value spaces.
        //05  filler pic x(34)  value "TOTAL NUMBER OF RECORDS      : ". 
        //05  eft-record pic zzzzzzzz9.
        private   int eft_record_child;

        //01  eft-prt-6. 
        private string eft_prt_6_grp; // = new string(' ', 20) + "TOTAL NUMBER OF TRANSACTIONS : ".PadRight(34) + eft_tran_child.ToString();
        //05  filler pic x(20)  value spaces.
        //05  filler pic x(34)  value "TOTAL NUMBER OF TRANSACTIONS : ". 
        //05  eft-tran pic zzzzzzzz9.
        private   int eft_tran_child;

        //01  eft-prt-7. 
        private string eft_prt_7_grp; // = new string(' ', 20) + "TOTAL VALUE  OF TRANSACTIONS : ".PadRight(34) + string.Format("{0:c}", eft_value_child);
        //05  filler pic x(20)  value spaces.
        //05  filler pic x(34)  value "TOTAL VALUE  OF TRANSACTIONS : ". 
        //05  eft-value pic $$$,$$$,$$$,$$9.99. 
        private   decimal eft_value_child;

        //01  eft-prt-8. 
        private string eft_prt_8_grp; // = new string(' ', 20) + "TAPE CREATION DATE :".PadRight(30) + string.Format("{0:0}", eft_sy_yr_child) + "/" + string.Format("{0:0}", eft_sy_day_child) + "   JULIAN DATE".PadRight(20);
        //05  filler pic x(20)  value spaces.
        //05  filler pic x(30)  value "TAPE CREATION DATE :". 
        //* (y2k - no change - left as CIBC format ' 0yy' + julian date)
        //05  eft-sy-yr pic z99.
        private   int eft_sy_yr_child;
        //05  filler pic x value "/". 
        //05  eft-sy-day pic zz9.
        private   int eft_sy_day_child;
        //05  filler pic x(20)  value "   JULIAN DATE". 

        public   bool Execute()
        {
            try
            {
                objEft_record_type_a = null;
                objEft_record_type_a = new Eft_record_type_a();

                objEft_record_type_c = null;
                objEft_record_type_c = new Eft_record_type_c();

                Eft_record_type_a_Collection = null;
                Eft_record_type_a_Collection = new ObservableCollection<Eft_record_type_a>();

                Eft_record_type_c_Collection = null;
                Eft_record_type_c_Collection = new ObservableCollection<Eft_record_type_c>();

                objEft_record_type_z = null;
                objEft_record_type_z = new Eft_record_type_z();

                Eft_record_type_z_Collection = new ObservableCollection<Eft_record_type_z>();

                objPrint_file_a = null;
                objPrint_file_a = new Print_file_a();
                Print_file_a_Collection = new ObservableCollection<Print_file_a>();

                objPrint_file_b = null;
                objPrint_file_b = new Print_file_b();
                Print_file_b_Collection = new ObservableCollection<Print_file_b>();

                objPrint_file_c = null;
                objPrint_file_c = new Print_file_c();
                Print_file_c_Collection = new ObservableCollection<Print_file_c>();

                objEft_constant_file = null;
                objEft_constant_file = new Eft_constant_file();

                objU119_chgeft_rec = null;
                objU119_chgeft_rec = new U119_chgeft_rec();
                U119_chgeft_rec_Collection = new ObservableCollection<U119_chgeft_rec>();

                objOutput_record = null;
                objOutput_record = new Output_record();
                Output_record_Collection = new ObservableCollection<Output_record>();

                _reportSummaryFile = Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.TempDir + "\\R153b_Summary_Temp_" + Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.CurrentUser.ADUserName + "_" + Util.DateTimeStamp() + ".txt";
                objPrtSummary = null;
                objPrtSummary = new ReportPrint(_reportSummaryFile);

                _reportPrintAFile = Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.TempDir + "\\R153b_PrintA_Temp_" + Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.CurrentUser.ADUserName + "_" + Util.DateTimeStamp() + ".txt";
                objPrtLineA = null;
                objPrtLineA = new ReportPrint(_reportPrintAFile);

                _reportPrintBFile = Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.TempDir + "\\R153b_PrintB_Temp_" + Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.CurrentUser.ADUserName + "_" + Util.DateTimeStamp() + ".txt";
                objPrtLineB = null;
                objPrtLineB = new ReportPrint(_reportPrintBFile);

                _reportPrintCFile = Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.TempDir + "\\R153b_PrintC_Temp_" + Core.Windows.UI.Core.Windows.UI.ApplicationState.Current.CurrentUser.ADUserName + "_" + Util.DateTimeStamp() + ".txt";
                objPrtLineC = null;
                objPrtLineC = new ReportPrint(_reportPrintCFile);

                objSummary_eft = null;
                objSummary_eft = new Summary_eft();

                objConstants_Mstr_Rec_3 = null;
                objConstants_Mstr_Rec_3 = new CONSTANTS_MSTR_REC_3();
                Constants_Mstr_Rec_3_Collection = new CONSTANTS_MSTR_REC_3 { }.Collection();
                objConstants_Mstr_Rec_3 = Constants_Mstr_Rec_3_Collection.FirstOrDefault();

                //perform aa0-initialization          thru aa0-99 - exit.
                aa0_initialization();
                aa0_10_clinic();
                aa0_99_exit();

                //*------------------------------------------------------------------*
                //*eft diskfile is created while deposit - listing is created*
                //*------------------------------------------------------------------*

                //perform ab3-sort - eft - record         thru ab3-99 - exit.
                ab3_sort_eft_record();
                ab3_99_exit();

                //perform az0 - end - of - job          thru az0-99 - exit.
                az0_end_of_job();
                az0_100_end_job();
                az0_99_exit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }

        //sec-51 section 51

        private   void aa0_initialization()
        {
            //accept sys-date         from date.
            sys_date_grp = DateTime.Now.ToString();

            //perform y2k-default- sysdate     thru y2k-default- sysdate - exit.
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            //move sys - dd             to run-dd.
            run_dd_child = sys_dd_child;

            //move sys - yy             to run-yy.
            run_yy_child = sys_yy_child;

            //accept sys - time         from time.
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            run_hrs_child = Convert.ToInt32(DateTime.Now.ToString("HH"));
            run_min_child = Convert.ToInt32(DateTime.Now.ToString("mm"));
            run_sec_child = Convert.ToInt32(DateTime.Now.ToString("ss"));

            //move spaces                to r153b-prt - 1            
            //            r153c - prt - 1
            //            r153c - prt - 2
            //            r153c - prt - 3
            //            r153c - prt - 4
            //            r153c - prt - 5
            //            r153c - prt - 5a
            //            r153c - prt - 6
            //            r153c - prt - 7.

            //move zero               to counters
            counters_grp = "0";
            ctr_chq_reads_child = 0;
            ctr_u119_chgeft_reads_child = 0;
            ctr_wf_reads_child = 0;
            ctr_wf_writes_child = 0;
            ctr_doc_mstr_reads_child = 0;
            ctr_bank_mstr_reads_child = 0;
            ctr_lines_child = 0;
            ctr_nbr_lines_child = 0;
            ctr_rpt_writes_child = 0;
            ctr_cheques_child = 0;
            ctr_nbr_misc_lines_child = 0;

            //            ws - bank - total
            ws_bank_total = 0;
            //            ws - final - totals - mtd - ytd(ss - mtd)
            ws_final_totals_mtd_ytd_grp_child[ss_mtd] = "0";
            //            ws - final - totals - mtd - ytd(ss - ytd).
            ws_final_totals_mtd_ytd_grp_child[ss_ytd] = "0";

            //open input iconst - mstr.
            ICONST_MSTR_REC_Collection = new ICONST_MSTR_REC().Collection();
            objICONST_MSTR_REC = ICONST_MSTR_REC_Collection.FirstOrDefault();
        }

        private   void aa0_10_clinic()
        {
            //accept sel-clinic.
            sel_clinic = Console.ReadLine();

            //move sel - clinic         to iconst-clinic - nbr - 1 - 2.

            //move sel - clinic         to iconst-clinic - nbr - 1 - 2.
            objICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2 = Util.NumDec(sel_clinic);

            //read iconst - mstr
            //       invalid key
            //          move 5              to err-ind
            //         perform za0-common - error    thru za0-99 - exit
            //         go to aa0 - 10 - clinic.

            ICONST_MSTR_REC_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumDec(sel_clinic)
            }.Collection();

            if (ICONST_MSTR_REC_Collection.Count() == 0)
            {
                err_ind = 5;
                za0_common_error();
                za0_99_exit();
                aa0_10_clinic();
                return;
            }
            else
            {
                objICONST_MSTR_REC = ICONST_MSTR_REC_Collection.FirstOrDefault();

                //move iconst-date - period - end - yy      to ws-per - end - yr.
                ws_per_end_yr_child = Util.NumInt(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY);

                //move iconst-date - period - end - mm  to ws-per - end - mth.
                ws_per_end_mth_child = Util.NumInt(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_MM);

                //move iconst-date - period - end - dd  to ws-per - end - day.
                ws_per_end_day_child = Util.NumInt(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_DD);

                //if iconst - date - period - end - mm < 7 then
                if (objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_MM < 7)
                {
                    //   subtract 1          from iconst-date - period - end - yy.
                    objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY = objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY - 1;
                }

                //move iconst-date - period - end - yy  to r153a-h7 - yr.
                r153a_h7_yr_child = Util.NumInt(objICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY);

                //****************************************************************
                //*move iconst - date - period - end - mm      to ss-chq.
                //* (u119 - chgeft - file values moved into 1st occurence of fiscal yr of f060
                //* record and therefore hardcode subscript to 7)

                //move 7                              to ss-chq.
                ss_chq = 7;

                //* ***************************************************************

                //if ss - chq < 7 then
                if (ss_chq < 7)
                {
                    //    add 12              to ss-chq.
                    ss_chq = ss_chq + 12;
                }

                //move 3             to iconst-clinic - nbr - 1 - 2.
                objICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2 = 3;

                //read iconst-mstr
                //invalid key
                //    move 7          to err-ind
                //    perform za0-common - error    thru za0-99 - exit
                //    close iconst-mstr
                //    go to az0 - 100 - end - job.

                ICONST_MSTR_REC_Collection = new ICONST_MSTR_REC
                {
                    WhereIconst_clinic_nbr_1_2 = 3
                }.Collection();

                if (ICONST_MSTR_REC_Collection.Count == 0)
                {
                    err_ind = 7;
                    za0_common_error();
                    za0_99_exit();
                    az0_100_end_job();
                    return;
                }
                else
                {
                    objICONST_MSTR_REC = ICONST_MSTR_REC_Collection.FirstOrDefault();
                }

                //close iconst - mstr.
                //move sys - yy             to ws-chq - yr.
                ws_chq_yr_child = sys_yy_child;
                //move sys - mm             to ws-chq - mth.
                ws_chq_mth_child = sys_mm_child;
                //move sys - dd             to ws-chq - day.
                ws_chq_day_child = sys_dd_child;


                //perform aa1-initialize - rec - a  thru aa1-99 - exit
                //  varying i         from    1   by   1
                //  until i         greater than    10.

                i = 1;
                do
                {
                    aa1_initialize_rec_a();
                    aa1_99_exit();
                    i++;

                } while (i <= 10);

                //move   ws - rec - a                  to a-01 - record - type.
                objEft_record_type_a.a_01_record_type = ws_rec_a_child;

                //move   ws - record - count           to a-02 - record - count.
                objEft_record_type_a.a_02_record_count = ws_record_count;

                //*(verify that valid payroll clinic was entered)
                //if sel - clinic = 22 then
                if (Util.NumInt(sel_clinic) == 22)
                {
                    //     move ws - originator - nbr - clinic - 22  to a-03 - originator - number
                    objEft_record_type_a.a_03_originator_number = ws_originator_nbr_clinic_22_child;
                }
                //else if sel - clinic = 81 then
                else if (Util.NumInt(sel_clinic) == 81)
                {
                    //     move ws - originator - nbr - clinic - 81  to a-03 - originator - number
                    objEft_record_type_a.a_03_originator_number = ws_originator_nbr_clinic_81_child;
                }
                //else if sel - clinic = 85 then
                else if (Util.NumInt(sel_clinic) == 85)
                {
                    //     move ws - originator - nbr - clinic - 85  to a-03 - originator - number
                    objEft_record_type_a.a_03_originator_number = ws_originator_nbr_clinic_85_child;
                }
                //else if sel - clinic = 99 then
                else if (Util.NumInt(sel_clinic) == 99)
                {
                    //     move ws - originator - nbr - clinic - mp  to a-03 - originator - number
                    objEft_record_type_a.a_03_originator_number = ws_originator_nbr_clinic_mp_child;
                }
                else
                {
                    //     move 9                          to err-ind
                    err_ind = 9;
                    //     perform za0-common - error        thru za0-99 - exit
                    za0_common_error();
                    za0_99_exit();
                    //     go to az0 - end - of - job.
                    az0_end_of_job();
                    return;
                }

                //move ws-file - creation - nbr      to a-04 - file - creation - number.
                objEft_record_type_a.a_04_file_creation_number = ws_file_creation_nbr;

                //*y2k

                // move ws-tape - creation - date     to a-05 - creation - date.
                ws_tape_creation_date_grp = Util.Str(ws_tape_yr_child + ws_tape_day_child);
                objEft_record_type_a.a_05_creation_date = Util.NumLongInt(ws_tape_creation_date_grp);

                // move   ws - dest - data - centre       to a-06 - destination - data - centre.
                objEft_record_type_a.a_06_destination_data_centre = ws_dest_data_centre;

                // move   spaces to    a - 07 - filler.
                objEft_record_type_a.a_07_filler = string.Empty;

                // move   ws - version - nbr            to a-08 - version - number.
                objEft_record_type_a.a_08_version_number = ws_version_nbr;

                //move ws-nbr - settlement - accounts to a-09 - settlement - account.
                objEft_record_type_a.a_09_settlement_account = ws_nbr_settlement_accounts;

                //move   ws - settlement - account     to settlement-account(1).
                objEft_record_type_a.settlement_account_child[1] = ws_settlement_account;

                //move   ws - institution - id         to institution-id(1).
                ws_institution_id_grp = Util.Str(ws_bank_nbr_id_child) + Util.Str(ws_bank_branch_id_child);
                objEft_record_type_a.institution_id_child[1] = Util.NumLongInt(ws_institution_id_grp);

                //*(y2k)
                //move sys - yy             to r153a-h3 - yr.
                r153a_h3_yr_child = sys_yy_child;
                //move sys - mm             to r153a-h3 - mth.
                r153a_h3_mth_child = sys_mm_child;
                //move sys - dd             to r153a-h3 - day.
                r153a_h3_day_child = sys_dd_child;

                //* (y2k)
                //move ws - per - end - yr          to r153a-h5 - yr.
                r153a_h5_yr_child = ws_per_end_yr_child;

                //move ws - per - end - mth         to r153a-h5 - mth.
                r153a_h5_mth_child = ws_per_end_mth_child;

                //move ws - per - end - day         to r153a-h5 - day.
                r153a_h5_day_child = ws_per_end_day_child;

                //*(y2k)
                // move ws - chq - yr          to r153a-p8 - yr.
                r153a_p8_yr_child = ws_chq_yr_child;

                // move ws - chq - mth         to r153a-p8 - mth.
                r153a_p8_mth_child = ws_chq_mth_child;

                // move ws - chq - day         to r153a-p8 - day.
                r153a_p8_day_child = ws_chq_day_child;

                // move 1              to r153b-h1 - page.
                r153b_h1_page_child = 1;

                // move ws - chq - mth         to r153b-h2 - mth.
                r153b_h2_mth_child = ws_chq_mth_child;

                // move ws - chq - day         to r153b-h2 - day.
                r153b_h2_day_child = ws_chq_day_child;

                //*(y2k)
                // move ws - chq - yr          to r153b-h2 - yr.
                r153b_h2_yr_child = ws_chq_yr_child;

                // move 999999.99          to r153c-p1 - chq - amt.
                r153c_p1_chq_amt_child = 999999.99M;

                // move t - month(ws - chq - mth)       to r153c-p1 - mth.
                r153c_p1_mth_child = t_month_child[ws_chq_mth_child];

                // move ws - chq - day         to r153c-p1 - day.
                r153c_p1_day_child = ws_chq_day_child;

                //* (y2k)
                //move ws - chq - yr          to r153c-p1 - yr.
                r153c_p1_yr_child = ws_chq_yr_child;

                //move ","                to r153c-p1 - comma.
                r153c_p1_comma_child = ",";

                //* (y2k)           
                //move zeroes to  chq - reg - key.

                //move sel - clinic         to chq-reg - clinic - nbr - 1 - 2.
                objF060_CHEQUE_REG_MSTR.CHQ_REG_CLINIC_NBR_1_2 = Util.NumDec(sel_clinic);

                //add 1             to ctr-chq - reads.
                ctr_chq_reads_child++;

                //if chq - reg - clinic - nbr - 1 - 2 not = sel - clinic then
                if (Util.NumInt(objF060_CHEQUE_REG_MSTR.CHQ_REG_CLINIC_NBR_1_2) != Util.NumInt(sel_clinic)) {
                    //   move 6              to err-ind
                    err_ind = 6;
                    //   perform za0-common - error    thru za0-99 - exit
                    za0_common_error();
                    za0_99_exit();
                    //   go to az0 - end - of - job.
                    az0_end_of_job();
                    return;
                }

                //if eof - chq - reg - mstr = "Y" then
                if (eof_chq_reg_mstr.ToUpper().Equals("Y")) {
                    //     move 6              to err-ind
                    err_ind = 6;
                    //     perform za0-common - error    thru za0-99 - exit
                    za0_common_error();
                    za0_99_exit();
                    //     go to az0 - end - of - job.
                    az0_end_of_job();
                    return;
                }
            }
        }
        private   void aa0_99_exit()
        {
        }
        private   void aa1_initialize_rec_a()
        {
            //move zeroes       to institution-id(i).
            objEft_record_type_a.institution_id_child[i] = 0;

            //move      spaces to  settlement - account(i).
            objEft_record_type_a.settlement_account_child[i] = string.Empty;
        }
        private   void aa1_99_exit()
        {
        }
        private   void az0_end_of_job()
        {
        }
        private   void az0_100_end_job()
        {
            //accept sys-time         from time.
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs_child = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min_child = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec_child = Convert.ToInt32(DateTime.Now.ToString("ss"));
        }
        private   void az0_99_exit()
        {
        }
        private   void ab1_wf_stmnts()
        {
            //perform da0-read - doc - mstr       thru da0-99 - exit.
            da0_read_doc_mstr();
            da0_99_exit();

            //perform db0 - read - dept - mstr      thru db0-99 - exit.
            db0_read_dept_mstr();
            db0_99_exit();

            //perform ua1 - add - to - totals       thru ua1-99 - exit
            //   varying ss-mth - nbr
            //      from    7
            //      by      1
            //     until ss-mth - nbr > ss - chq.

            ss_mth_nbr = 7;
            do
            {
                ua1_add_to_totals();
                ua1_99_exit();
                ss_mth_nbr++;
            } while (ss_mth_nbr <= ss_chq);

            //*(suppress print if zero)

            //if    chq - reg - mth - misc - amt(ss - chq, 1) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 2) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 3) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 4) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 5) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 6) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 7) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 8) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 9) = zero
            //      and chq-reg - mth - misc - amt(ss - chq, 10) = zero
            //      and chq-reg - mth - bill - amt(ss - chq) = zero
            //      and ws-misc - gross(ss - ytd, 1) = zero
            //      and ws-misc - gross(ss - ytd, 2) = zero
            //      and ws-misc - gross(ss - ytd, 3) = zero
            //      and ws-misc - gross(ss - ytd, 4) = zero
            //      and ws-misc - gross(ss - ytd, 5) = zero
            //      and ws-misc - gross(ss - ytd, 6) = zero
            //      and ws-misc - gross(ss - ytd, 7) = zero
            //      and ws-misc - gross(ss - ytd, 8) = zero
            //      and ws-misc - gross(ss - ytd, 9) = zero
            //      and ws-misc - gross(ss - ytd, 10) = zero
            //      and ws-bill - gross(ss - ytd) = zero
            //      and ws-inc(ss - ytd) = zero
            //      and ws-pay - due(ss - ytd) = zero
            //      and ws-tax(ss - ytd) = zero
            //      and ws-bank - deposit(ss - ytd) = zero
            //      and ws-manual - chqs(ss - ytd) = zero then
            //     go to ab1-10 - next - record.

            if (CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 1) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 2) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 2) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 4) == 0 &&
              CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 5) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 6) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 7) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 8) == 0 &&
              CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 9) == 0 && CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, 10) == 0 &&
              CHQ_REG_MTH_BILL_AMT(objF060_CHEQUE_REG_MSTR, ss_chq) == 0
              && ws_misc_gross_child[ss_ytd, 1] == 0
              && ws_misc_gross_child[ss_ytd, 2] == 0
              && ws_misc_gross_child[ss_ytd, 3] == 0
              && ws_misc_gross_child[ss_ytd, 4] == 0
              && ws_misc_gross_child[ss_ytd, 5] == 0
              && ws_misc_gross_child[ss_ytd, 6] == 0
              && ws_misc_gross_child[ss_ytd, 7] == 0
              && ws_misc_gross_child[ss_ytd, 8] == 0
              && ws_misc_gross_child[ss_ytd, 9] == 0
              && ws_misc_gross_child[ss_ytd, 10] == 0
              && ws_bill_gross_child[ss_ytd] == 0
              && ws_inc[ss_ytd] == 0
              && ws_pay_due_child[ss_ytd] == 0
              && ws_tax_child[ss_ytd] == 0
              && ws_bank_deposit_child[ss_ytd] == 0
              && ws_manual_chqs_child[ss_ytd] == 0)
            {
                ab1_10_next_record();
                return;
            }

            //perform wa0-write - headings          thru wa0-99 - exit.
            wa0_write_headings();
            wa0_99_exit();

            //perform wa1 - write - report            thru wa1-99 - exit.
            wa1_write_report();
            wa1_99_exit();

            //if chq - reg - regular - pay - this - mth(ss - chq) not = 0 then
            if (CHQ_REG_REGULAR_PAY_THIS_MTH(objF060_CHEQUE_REG_MSTR,ss_chq) != 0) {
                //    perform wb0 - write - c - record              thru wb0-99 - exit
                wb0_write_c_record();
                wb0_99_exit();
                //    perform ba0-write - wf            thru ba0-99 - exit.
                ba0_write_wf();
                ba0_99_exit();
            }
        }
        private   void ab1_10_next_record()
        {
            // perform bb0-read - next - chq               thru bb0-99 - exit.
            bb0_read_next_chq();
            bb0_99_exit();

            //if eof - chq - reg - mstr not = "Y" then
            if (!eof_chq_reg_mstr.ToUpper().Equals("Y")) {
                //   go to ab1-wf - stmnts.
                ab1_wf_stmnts();
                return;
            }

            //perform wa3-print - totals            thru wa3-99 - exit.
            wa3_print_totals();
            wa3_99_exit();

            //perform wb1 - write - z - record          thru wb1-99 - exit.
            wb1_write_z_record();
            wb1_99_exit();
        }
        private   void ab1_99_exit()
        {
        }
        private   void wb0_write_c_record()
        {
            //add    1   to ws-record - count.
            ws_record_count++;

            //add    1   to ws-total - debit - nbr.
            ws_total_debit_nbr++;

            //add ws-bank - deposit(ss - mtd)       to ws-total - debit - value.
            ws_total_debit_value = ws_total_debit_value +  ws_bank_deposit_child[ss_mtd];

            //move doc-bank - nbr           to ws-bank - nbr.
            ws_bank_nbr_child = Util.NumInt(objF020_DOCTOR_MSTR.DOC_BANK_NBR);

            //move   doc - bank - branch                to ws-bank - branch.
            ws_bank_branch_child =  Util.NumLongInt(objF020_DOCTOR_MSTR.DOC_BANK_BRANCH);

            //move   doc - bank - acct                  to ws-payee - acc - nbr.
            ws_payee_acc_nbr = objF020_DOCTOR_MSTR.DOC_BANK_ACCT;

            //move   doc - nbr                        to ws-sin - nbr.
            ws_sin_nbr = objF020_DOCTOR_MSTR.DOC_NBR;

            //move   doc - name           to ws-payee - last - name.
            ws_payee_last_name_child = objF020_DOCTOR_MSTR.DOC_NAME;

            //move   doc - inits              to ws-payee - initial.
            ws_payee_initial_child = objF020_DOCTOR_MSTR.DOC_INIT1 + objF020_DOCTOR_MSTR.DOC_INIT2 + objF020_DOCTOR_MSTR.DOC_INIT3;

            //move ws-rec - d                       to c-01 - record - type.
            objEft_record_type_c.c_01_record_type = ws_rec_d_child;

            //move   ws - record - count                to c-02 - record - count.
            objEft_record_type_c.c_02_record_count = ws_record_count;

            //if sel - clinic = 22 then
            if (Util.NumInt(sel_clinic) == 2)
            {
                //   move ws - originator - nbr - clinic - 22  to c-03 - originator - nbr
                objEft_record_type_c.c_03_originator_nbr = ws_originator_nbr_clinic_22_child;
            }
            //else if sel - clinic = 81 then
            else if (Util.NumInt(sel_clinic) == 81)
            {
                //   move ws - originator - nbr - clinic - 81  to c-03 - originator - nbr
                objEft_record_type_c.c_03_originator_nbr = ws_originator_nbr_clinic_81_child;
            }
            //else if sel - clinic = 85 then
            else if (Util.NumInt(sel_clinic) == 85)
            {
                //   move ws - originator - nbr - clinic - 85  to c-03 - originator - nbr
                objEft_record_type_c.c_03_originator_nbr = ws_originator_nbr_clinic_85_child;
            }
            //else if sel - clinic = 99 then
            else if (Util.NumInt(sel_clinic) == 99)
            {
                //   move ws - originator - nbr - clinic - mp  to c-03 - originator - nbr
                objEft_record_type_c.c_03_originator_nbr = ws_originator_nbr_clinic_mp_child;
            }
            else
            {
                //   move 9                          to err-ind
                err_ind = 9;
                //   perform za0-common - error        thru za0-99 - exit
                za0_common_error();
                za0_99_exit();
                //   go to az0 - end - of - job.
                az0_end_of_job();
                return;
            }

            //move ws-file - creation - nbr      to a-04 - file - creation - number.
            objEft_record_type_a.a_04_file_creation_number = ws_file_creation_nbr;

            //move   ws - transaction - type            to c-04 - transaction - type.
            objEft_record_type_c.c_04_transaction_type = ws_transaction_type;

            //move   ws - bank - deposit(ss - mtd)       to c-05 - amount.
            objEft_record_type_c.c_05_amount = ws_bank_deposit_child[ss_mtd];

            //* (y2k)
            //move   ws - fund - avail - date             to c-06 - fund - available - date.
            ws_fund_avail_date_grp = Util.Str(ws_fund_yr_child) + Util.Str(ws_fund_day_child);
            objEft_record_type_c.c_06_fund_available_date = Util.NumLongInt(ws_fund_avail_date_grp);

            //move   ws - bank - code                   to c-07 - bank - nbr.
            ws_bank_code_grp = Util.Str(ws_bank_nbr_child) + Util.Str(ws_bank_branch_child);
            objEft_record_type_c.c_07_bank_nbr = Util.NumLongInt(ws_bank_code_grp);

            //move   ws - payee - acc - nbr               to c-08 - payee - acc - nbr.
            objEft_record_type_c.c_08_payee_acc_nbr = ws_payee_acc_nbr;

            //move   ws - reserved                    to c-09 - reserved.
            objEft_record_type_c.c_09_reserved = ws_reserved;

            //move   ws - stored - trans - type           to c-10 - stored - trans - type.
            objEft_record_type_c.c_10_stored_trans_type = ws_stored_trans_type;

            //move   ws - short - name                  to c-11 - short - name.
            objEft_record_type_c.c_11_short_name = ws_short_name;

            //move   ws - payee - name          to c-12 - payee - name.
            ws_payee_name_grp = ws_payee_last_name_child + ws_payee_initial_child;
            objEft_record_type_c.c_12_payee_name = ws_payee_name_grp;

            //move   ws - long - name                   to c-13 - long - name.
            objEft_record_type_c.c_13_long_name = ws_long_name;

            //if sel - clinic = 22 then
            if (Util.NumInt(sel_clinic) == 22)
            {
                //   move ws - originator - nbr - clinic - 22  to c-14 - originator - nbr
            }
            //else if sel - clinic = 81 then
            else if (Util.NumInt(sel_clinic) == 81)
            {
                //   move ws - originator - nbr - clinic - 81  to c-14 - originator - nbr
                objEft_record_type_c.c_14_originator_nbr = ws_originator_nbr_clinic_81_child;
            }
            //else if sel - clinic = 85 then
            else if (Util.NumInt(sel_clinic) == 85)
            {
                //    move ws - originator - nbr - clinic - 85  to c-14 - originator - nbr
                objEft_record_type_c.c_14_originator_nbr = ws_originator_nbr_clinic_85_child;
            }
            //else if sel - clinic = 99 then
            else if (Util.NumInt(sel_clinic) == 99)
            {
                //    move ws - originator - nbr - clinic - mp  to c-14 - originator - nbr
                objEft_record_type_c.c_14_originator_nbr = ws_originator_nbr_clinic_mp_child;
            }
            else
            {
                //    move 9                          to err-ind
                err_ind = 9;
                //    perform za0-common - error        thru za0-99 - exit
                za0_common_error();
                za0_99_exit();
                //    go to az0 - end - of - job.
                az0_end_of_job();
                return;
            }

            //move ws-sin - nbr                     to c-15 - cross -ref-nbr.
            objEft_record_type_c.c_15_cross_ref_nbr = ws_sin_nbr;

            //move   ws - institution -return to  c - 16 - institution -return.
            ws_institution_return_grp = Util.Str(ws_bank_nbr_return_child) + Util.Str(ws_bank_branch_return_child);
            objEft_record_type_c.c_16_institution_return = Util.NumLongInt(ws_institution_return_grp);

            //move   ws - account -return to  c - 17 - account -return.
            objEft_record_type_c.c_17_account_return = ws_account_return;

            //move   ws - sundry                      to c-18 - sundry.
            objEft_record_type_c.c_18_sundry = ws_sundry;

            //move   spaces to  c - 19 - filler.
            objEft_record_type_c.c_19_filler = string.Empty;

            //move   ws - settlement - indicator        to c-20 - settlement - indicator.
            objEft_record_type_c.c_20_settlement_indicator = ws_settlement_indicator;

            //move   ws - invalid - indicator           to c-21 - invalid - indicator.
            objEft_record_type_c.c_21_invalid_indicator = ws_invalid_indicator;

            //move   ws - seg - two - six                 to c-seg - two - six.
            objEft_record_type_c.c_seg_two_six = ws_seg_two_six;
        }    
        private   void wb0_99_exit()
        {
        }
        // sec_60  section 60.
        private   void wb1_write_z_record()
        {
            //add    1                  to ws-record - count.
            ws_record_count++;

            // move   ws - rec - z                       to z-01 - record - type.
            objEft_record_type_z.z_01_record_type = ws_rec_z_child;

            // move   ws - record - count        to z-02 - record - count.
            objEft_record_type_z.z_02_record_count = ws_record_count;

            //if sel - clinic = 22 then
            if (Util.NumInt(sel_clinic) == 22)
            {
                //   move ws - originator - nbr - clinic - 22  to z-03 - originator - nbr
                objEft_record_type_z.z_03_originator_nbr = ws_originator_nbr_clinic_22_child;
            }
            //else if sel - clinic = 81 then
            else if (Util.NumInt(sel_clinic) == 81)
            {
                //   move ws - originator - nbr - clinic - 81  to z-03 - originator - nbr
                objEft_record_type_z.z_03_originator_nbr = ws_originator_nbr_clinic_81_child;
            }
            //else if sel - clinic = 85 then
            else if (Util.NumInt(sel_clinic) == 85)
            {
                //   move ws - originator - nbr - clinic - 85  to z-03 - originator - nbr
                objEft_record_type_z.z_03_originator_nbr = ws_originator_nbr_clinic_85_child;
            }
            //else if sel - clinic = 99 then
            else if (Util.NumInt(sel_clinic) == 99)
            {
                //   move ws - originator - nbr - clinic - mp  to z-03 - originator - nbr
                objEft_record_type_z.z_03_originator_nbr = ws_originator_nbr_clinic_mp_child;
            }
            else
            {
                //   move 9                            to err-ind
                err_ind = 9;
                //   perform za0-common - error          thru za0-99 - exit
                za0_common_error();
                za0_99_exit();
                //   go to az0 - end - of - job.
                az0_end_of_job();
                return;
            }

            //move ws-file - creation - nbr           to z-03 - file - creation - number.
            objEft_record_type_z.z_03_file_creation_number = ws_file_creation_nbr;

            //move   ws - total - debit - value           to z-04 - total - debit - value.
            objEft_record_type_z.z_04_total_debit_value = ws_total_debit_value;

            //move   ws - total - debit - nbr             to z-05 - total - debit - nbr.
            objEft_record_type_z.z_05_total_debit_nbr = ws_total_debit_nbr;

            //move   ws - total - credit - value          to z-06 - total - credit - value.
            objEft_record_type_z.z_06_total_credit_value = ws_total_credit_value;

            //move   ws - total - credit - nbr            to z-07 - total - credit - nbr.
            objEft_record_type_z.z_07_total_credit_nbr = ws_total_credit_nbr;

            //move   spaces to  z - 08 - filler.
            objEft_record_type_z.z_08_filler = string.Empty;

            //write eft-record - type - z.  // TODO: Insert in Table or collection??
            Eft_record_type_z_Collection.Add(objEft_record_type_z);
        }
        private   void wb1_99_exit()
        {
        }
        private   void fa0_eft_summary()
        {
            //move spaces        to prt-summary.                        

            //write   prt - summary   from eft-prt - head  after page. // Todo: After page.            
            eft_prt_head_grp = "R153EF" + new string(' ', 126);
            objSummary_eft.prt_summary = eft_prt_head_grp;
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //move spaces        to prt-summary.

            //move eft - prt - 1     to prt-summary.                      
            eft_prt_1_grp = "               SUMMARY REPORT FOR E.F.T. TAPE CREATION  ".PadRight(80);
            objSummary_eft.prt_summary = eft_prt_1_grp;

            //write prt-summary   after advancing 5 lines.
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //move ws-file - creation - nbr    to eft-creation.
            eft_creation_child = ws_file_creation_nbr;

            //move ws - version - nbr          to eft-version.
            eft_version_child = ws_version_nbr;

            //*(y2k)
            //move ws - fund - yr              to eft-f - yr.
            eft_f_yr_child = ws_fund_yr_child;

            //move ws - fund - day             to eft-f - day.
            eft_f_day_chld = ws_fund_day_child;

            //move ws - record - count         to eft-record.
            eft_record_child = ws_record_count;

            //move ws-total - debit - nbr     to eft-tran.
            eft_tran_child = ws_total_debit_nbr;

            //move ws-total - debit - value   to eft-value.
            eft_value_child = ws_total_debit_value;

            //*(y2k)
            //move ws - tape - yr              to eft-sy - yr.
            eft_sy_yr_child = ws_tape_yr_child;

            //move ws - tape - day             to eft-sy - day.
            eft_sy_day_child = ws_tape_day_child;

            //write    prt - summary  from eft-prt - 2  after  2  lines.
            eft_prt_2_grp = new string(' ', 20) + "FILE CREATION NUMBER : ".PadRight(30) + string.Format("{0:0}", eft_creation_child);
            objSummary_eft.prt_summary = eft_prt_2_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //write prt-summary  from eft-prt - 3  after  2  lines.
            eft_prt_3_grp = new string(' ', 20) + "VERSION NUMBER       :".PadRight(30) + eft_version_child.ToString();
            objSummary_eft.prt_summary = eft_prt_3_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //write prt-summary  from eft-prt - 4  after  2  lines.
            eft_prt_4_grp = new string(' ', 20) + "DATE FUND TO BE AVAILABLE : ".PadRight(30) + eft_f_yr_child.ToString() + "/" + eft_f_day_chld.ToString() + "   JULIAN DATE".PadRight(20);
            objSummary_eft.prt_summary = eft_prt_4_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //write prt-summary  from eft-prt - 5  after  2  lines.
            eft_prt_5_grp = new string(' ', 20) + "TOTAL NUMBER OF RECORDS      : ".PadRight(34) + eft_record_child.ToString();
            objSummary_eft.prt_summary = eft_prt_5_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //write prt-summary  from eft-prt - 6  after  2  lines.
            eft_prt_6_grp = new string(' ', 20) + "TOTAL NUMBER OF TRANSACTIONS : ".PadRight(34) + eft_tran_child.ToString();
            objSummary_eft.prt_summary = eft_prt_6_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //write prt-summary  from eft-prt - 7  after  2  lines.
            eft_prt_7_grp = new string(' ', 20) + "TOTAL VALUE  OF TRANSACTIONS : ".PadRight(34) + string.Format("{0:c}", eft_value_child);
            objSummary_eft.prt_summary = eft_prt_7_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);

            //write prt-summary  from eft-prt - 8  after  2  lines.
            eft_prt_8_grp = new string(' ', 20) + "TAPE CREATION DATE :".PadRight(30) + string.Format("{0:0}", eft_sy_yr_child) + "/" + string.Format("{0:0}", eft_sy_day_child) + "   JULIAN DATE".PadRight(20);
            objSummary_eft.prt_summary = eft_prt_8_grp;
            objPrtSummary.print(true);
            objPrtSummary.print(true);
            objPrtSummary.print(objSummary_eft.prt_summary, 1, true);
        }
        private   void fa0_99_exit()
        {
        }
        private   void ab2_bank_list_chqs()
        {
            //perform cc2-read - work - file      thru cc2-99 - exit.
            cc2_read_work_file();
            cc2_99_exit();

            //move 0              to cur-bank - cd - branch.
            cur_bank_cd_branch = "0";
        }
        private   void ab2_10_next_record()
        {
            //if wf - bank - cd - branch not = cur - bank - cd - branch then
            objWork_file_rec.wf_bank_cd_branch_grp = objWork_file_rec.wf_bank_cd_child + objWork_file_rec.wf_bank_branch_child;
            if (objWork_file_rec.wf_bank_cd_branch_grp != cur_bank_cd_branch ) {
                //   move wf - bank - cd - branch        to cur-bank - cd - branch
                cur_bank_cd_branch = objWork_file_rec.wf_bank_cd_branch_grp;
                //   perform ca0-get - address - bank - mstr thru ca0-99 - exit
                ca0_get_address_bank_mstr();
                ca0_99_exit();

                //   perform cb0-print - headings    thru cb0-99 - exit
                cb0_print_headings();
                cb0_99_exit();

                //   perform ea0-bank - info - to - chq      thru ea0-99 - exit.
                ea0_bank_info_to_chq();
                ea0_99_exit();
            }

            //perform cc0-process - docs - by - branch  thru cc0-99 - exit
            //      until wf-bank - cd - branch not = cur - bank - cd - branch
            //      or eof-work - file = "Y".

            do {
                cc0_process_docs_by_branch();
                cc0_99_exit();
            } while (objWork_file_rec.wf_bank_cd_child == cur_bank_cd_branch && eof_work_file.ToUpper() != "Y");

            //if ws - bank - total not = zeroes then
            if (ws_bank_total != 0 ) {
                //   perform cd0 - write - bank - total    thru cd0-99 - exit
                cd0_write_bank_total();
                cd0_99_exit();
                //   perform eb0-write - chq       thru eb0-99 - exit.
                eb0_write_chq();
                eb0_99_exit();
            }

            //if eof - work - file not = "Y" then
            if (!eof_work_file.ToUpper().Equals("Y")) {
                //   go to ab2-10 - next - record.
                ab2_10_next_record();
                return;
            }

            //perform ed0-print - totals        thru ed0-99 - exit.
            ed0_print_totals();
            ed0_99_exit();
        }
        private   void ab2_99_exit()
        {
        }
        private   void ab3_sort_eft_record()
        {
            //sort sorted-file
            //    on ascending key s-record - type, 
            //                          s - record - count, 
            //                          s - x -ref-nbr
            //    using    eft - logical - rec - file
            //    giving output-file.

            // Todo: Note sure, pls. verify this...
            foreach (var obj in Eft_record_type_a_Collection.OrderBy(a => a.a_01_record_type).OrderBy(b => b.a_02_record_count).OrderBy(c => c.a_03_originator_number))
            {
                objOutput_record.OutPut_Record = Util.Str(obj.a_01_record_type) + Util.Str(obj.a_02_record_count) + Util.Str(obj.a_03_originator_number) + Util.Str(obj.a_04_file_creation_number) + Util.Str(obj.a_05_creation_date) +
                                                 Util.Str(obj.a_06_destination_data_centre) + Util.Str(obj.a_07_filler) + Util.Str(obj.a_08_version_number) + Util.Str(obj.a_09_settlement_account) +  //Util.Str(obj.a_10_institution_account_grp) +
                                                 Util.Str(obj.institution_account_grp_child[1]) + Util.Str(obj.institution_account_grp_child[2]) + Util.Str(obj.institution_account_grp_child[3]) + Util.Str(obj.institution_account_grp_child[4]) + Util.Str(obj.institution_account_grp_child[5]) +
                                                 Util.Str(obj.institution_account_grp_child[6]) + Util.Str(obj.institution_account_grp_child[7]) + Util.Str(obj.institution_account_grp_child[8]) + Util.Str(obj.institution_account_grp_child[9]) + Util.Str(obj.institution_account_grp_child[10]) +
                                                 Util.Str(obj.institution_id_child[1]) + Util.Str(obj.institution_id_child[2]) + Util.Str(obj.institution_id_child[3]) + Util.Str(obj.institution_id_child[4]) + Util.Str(obj.institution_id_child[5]) +
                                                 Util.Str(obj.institution_id_child[6]) + Util.Str(obj.institution_id_child[7]) + Util.Str(obj.institution_id_child[8]) + Util.Str(obj.institution_id_child[9]) + Util.Str(obj.institution_id_child[10]) +
                                                 Util.Str(obj.settlement_account_child[1]) + Util.Str(obj.institution_id_child[2]) + Util.Str(obj.institution_id_child[3]) + Util.Str(obj.institution_id_child[4]) + Util.Str(obj.institution_id_child[5]) +
                                                 Util.Str(obj.institution_id_child[6]) + Util.Str(obj.institution_id_child[7]) + Util.Str(obj.institution_id_child[8]) + Util.Str(obj.institution_id_child[9]) + Util.Str(obj.institution_id_child[10]);

                Output_record_Collection.Add(objOutput_record);
            }
        }
        private   void ab3_99_exit()
        {
        }
        private   void ba0_write_wf()
        {
            //if sel - clinic not = doc - clinic - nbr then
            F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection = new F020C_DOC_CLINIC_NEXT_BATCH_NBR
            {
                WhereDoc_nbr = objF020_DOCTOR_MSTR.DOC_NBR
            }.Collection();

            bool exist = false;
            foreach (F020C_DOC_CLINIC_NEXT_BATCH_NBR obj in F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection)
            {
                if (Util.NumInt(sel_clinic) == Util.NumInt(obj.DOC_CLINIC_NBR))
                {
                    exist = true;
                }
            }

            if (!exist)
            {
                ba0_99_exit();
                return;
            }

            //move doc-bank - nbr           to wf-bank - cd.
            objWork_file_rec.wf_bank_cd_child = Util.Str(objF020_DOCTOR_MSTR.DOC_BANK_NBR);

            //move doc - bank - branch        to wf-bank - branch.
            objWork_file_rec.wf_bank_branch_child = Util.Str(objF020_DOCTOR_MSTR.DOC_BANK_BRANCH);

            //move doc - bank - acct          to wf-bank - acct - nbr.
            objWork_file_rec.wf_bank_acct_nbr = objF020_DOCTOR_MSTR.DOC_BANK_ACCT;

            //move doc - nbr            to wf-doc - nbr.
            objWork_file_rec.wf_doc_nbr = objF020_DOCTOR_MSTR.DOC_NBR;

            //move doc - inits          to wf-doc - inits.
            objWork_file_rec.wf_init1_child = objF020_DOCTOR_MSTR.DOC_INIT1;
            objWork_file_rec.wf_init2_child = objF020_DOCTOR_MSTR.DOC_INIT2;
            objWork_file_rec.wf_init3_child = objF020_DOCTOR_MSTR.DOC_INIT3;
            objWork_file_rec.wf_doc_inits_grp = objF020_DOCTOR_MSTR.DOC_INIT1 + objF020_DOCTOR_MSTR.DOC_INIT2 + objF020_DOCTOR_MSTR.DOC_INIT3;

            //move doc - name           to wf-doc - name.
            objWork_file_rec.wf_doc_name = objF020_DOCTOR_MSTR.DOC_NAME;

            //move chq - reg - regular - pay - this - mth(ss - chq) to	wf-pay. 
            objWork_file_rec.wf_pay = CHQ_REG_REGULAR_PAY_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_chq);

            //move chq-reg - pay - date(ss - chq)  to wf-period - end.
            objWork_file_rec.wf_period_yy_child = Util.NumInt(CHQ_REG_PAY_DATE(objF060_CHEQUE_REG_MSTR, ss_chq).ToString().Substring(0, 4)); //todo: verify the value..
            objWork_file_rec.wf_period_mm_child = Util.NumInt(CHQ_REG_PAY_DATE(objF060_CHEQUE_REG_MSTR, ss_chq).ToString().Substring(4, 2));
            objWork_file_rec.wf_period_dd_child = Util.NumInt(CHQ_REG_PAY_DATE(objF060_CHEQUE_REG_MSTR, ss_chq).ToString().Substring(6, 2));

            objWork_file_rec.wf_period_end_grp = Util.Str(objWork_file_rec.wf_period_yy_child) + Util.Str(objWork_file_rec.wf_period_mm_child) + Util.Str(objWork_file_rec.wf_period_dd_child);

            //release work - file - rec.
            Work_file_rec_Collection.Add(objWork_file_rec);

            //add 1               to ctr-wf - writes.
            ctr_wf_writes_child++;
        }
        private   void ba0_99_exit()
        {
        }
        private   void bb0_read_next_chq()
        {
            //add 1              to ctr-chq - reads.
            ctr_chq_reads_child++;

            //perform xa0-read - u119 - build - f060    thru xa0-99 - exit.
            xa0_read_u119_build_f060();
            xa0_99_exit();
        }
        private   void bb0_99_exit()
        {
        }
        private   void ca0_get_address_bank_mstr()
        {
            //move cur-bank - cd - branch     to bank-cd.
            objF080_BANK_MSTR.BANK_CD = cur_bank_cd_branch;

            //read bank-mstr
            //       invalid key
            //           move "ADDRESS UNKNOWN"  to bank-name
            //           move spaces             to bank-address1
            //                                      bank - address2
            //                                      bank - city - prov
            //                                      bank - postal - cd
            //     go to ca0 - 99 - exit.

            F080_BANK_MSTR_Collection = new F080_BANK_MSTR
            {
                WhereBank_cd = cur_bank_cd_branch
            }.Collection();

            objF080_BANK_MSTR = new F080_BANK_MSTR();

            if (F080_BANK_MSTR_Collection.Count() == 0)
            {
                objF080_BANK_MSTR.BANK_NAME = "ADDRESS UNKNOWN";
                objF080_BANK_MSTR.BANK_ADDRESS1 = string.Empty;
                objF080_BANK_MSTR.BANK_ADDRESS2 = string.Empty;
                objF080_BANK_MSTR.BANK_CITY = string.Empty;
                objF080_BANK_MSTR.BANK_PROV = string.Empty;

                //go to ca0 - 99 - exit.
                ca0_99_exit();
                return;
            }
            else
            {
                if (ctr_bank_mstr_reads_child >= F080_BANK_MSTR_Collection.Count())
                {
                    objF080_BANK_MSTR.BANK_NAME = "ADDRESS UNKNOWN";
                    objF080_BANK_MSTR.BANK_ADDRESS1 = string.Empty;
                    objF080_BANK_MSTR.BANK_ADDRESS2 = string.Empty;
                    objF080_BANK_MSTR.BANK_CITY = string.Empty;
                    objF080_BANK_MSTR.BANK_PROV = string.Empty;

                    //go to ca0 - 99 - exit.
                    ca0_99_exit();
                    return;
                }
                else
                {
                    var ctr = 0;
                    foreach (F080_BANK_MSTR obj in F080_BANK_MSTR_Collection)
                    {
                        if (ctr == ctr_bank_mstr_reads_child)
                        {
                            objF080_BANK_MSTR = obj;
                            //add 1               to ctr-bank - mstr - reads.
                            ctr_bank_mstr_reads_child++;
                            break;
                        }
                        ctr++;
                    }
                }
            }
        }
        private   void ca0_99_exit()
        {
        }
        private   void cb0_print_headings()
        {
            // write prt-line - b from r153b-head - first  after page.  // todo: After page.
            r153b_head_first_grp = "R153B" + new string(' ', 72);
            objPrint_file_b.prt_line_b = r153b_head_first_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            // add 1               to page-cnt.
            page_cnt++;

            // move page - cnt           to r153b-h1 - page.
            r153b_h1_page_child = page_cnt;

            // move bank - name          to r153b-h1 - bank - name.
            r153b_h1_bank_name_child = objF080_BANK_MSTR.BANK_NAME;

            // write prt-line - b from r153b-head - 1  after   1 line.
            r153b_head_1_grp = " " + r153b_h1_page_child.ToString() + new string(' ', 12) + Util.Str(r153b_h1_bank_name_child).PadRight(30) + new string(' ', 21);
            objPrint_file_b.prt_line_b = r153b_head_1_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            // move spaces             to r153b-h1 - bank - name.
            r153b_h1_bank_name_child = string.Empty;

            // move bank - address1          to r153b-h2 - bank - addr.
            r153b_h2_bank_addr_child = objF080_BANK_MSTR.BANK_ADDRESS1;

            // move ws - chq - mth         to r153b-h2 - mth.
            r153b_h2_mth_child = ws_chq_mth_child;

            //move ws - chq - day         to r153b-h2 - day.
            r153b_h2_day_child = ws_chq_day_child;

            //*(y2k)
            //move ws - chq - yr          to r153b-h2 - yr.
            r153b_h2_yr_child = ws_chq_yr_child;

            //write prt - line - b from r153b-head - 2  after   1 line.
            r153b_head_2_grp = new string(' ', 17) + Util.Str(r153b_h2_bank_addr_child).PadRight(43) + r153b_h2_mth_child.ToString() + " " + r153b_h2_day_child.ToString() + " " + r153b_h2_yr_child.ToString() + new string(' ', 9);
            objPrint_file_b.prt_line_b = r153b_head_2_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //move spaces             to r153b-head - 2.
            r153b_head_2_grp = string.Empty;

            //move bank - address2          to r153b-h2a - bank - addr.
            r153b_h2a_bank_addr_child = objF080_BANK_MSTR.BANK_ADDRESS2;

            //write prt - line - b from r153b-head - 2a after   1 line.
            r153b_head_2a_grp = new string(' ', 17) + Util.Str(r153b_h2a_bank_addr_child).PadRight(60);
            objPrint_file_b.prt_line_b = r153b_head_2a_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //move spaces             to r153b-head - 2a.
            r153b_head_2a_grp = string.Empty;

            //move bank-city - prov         to r153b-h2a - bank - addr.
            r153b_h2a_bank_addr_child = objF080_BANK_MSTR.BANK_CITY + objF080_BANK_MSTR.BANK_PROV;

            //write prt - line - b from r153b-head - 2a after   1 line.
            r153b_head_2a_grp = new string(' ', 17) + Util.Str(r153b_h2a_bank_addr_child).PadRight(60);
            objPrint_file_b.prt_line_b = r153b_head_2a_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //move spaces             to r153b-head - 2a.
            r153b_head_2a_grp = string.Empty;

            //move bank-postal - cd         to ws-postal - code.
            ws_postal_code_grp = objF080_BANK_MSTR.BANK_PC1 + objF080_BANK_MSTR.BANK_PC2 + objF080_BANK_MSTR.BANK_PC3 + objF080_BANK_MSTR.BANK_PC4 + objF080_BANK_MSTR.BANK_PC5 + objF080_BANK_MSTR.BANK_PC6;

            //move ws - pc - 153      to r153b-h3 - pc - 153.
            r153b_h3_pc_153 = ws_pc_153_child;

            //move ws - pc - 456      to r153b-h3 - pc - 456.
            r153b_h3_pc_456_child = ws_pc_456_child;

            //write prt - line - b from r153b-head - 3  after   1 line.
            r153b_head_3_grp = new string(' ', 17) + Util.Str(r153b_h3_pc_153).PadRight(3) + " " + Util.Str(r153b_h3_pc_456_child).PadRight(3) + new string(' ', 61);
            objPrint_file_b.prt_line_b = r153b_head_3_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //move spaces             to r153b-head - 3.
            r153b_head_3_grp = string.Empty;

            //write prt - line - b from r153b-head - 2  after   5 lines.
            r153b_head_2_grp = new string(' ', 17) + Util.Str(r153b_h2_bank_addr_child).PadRight(43) + r153b_h2_mth_child.ToString() + " " + r153b_h2_day_child.ToString() + " " + r153b_h2_yr_child.ToString() + new string(' ', 9);
            objPrint_file_b.prt_line_b = r153b_head_2_grp;
            objPrtLineB.print(true);
            objPrtLineB.print(true);
            objPrtLineB.print(true);
            objPrtLineB.print(true);
            objPrtLineB.print(true);
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //move 19             to ctr-lines.
            ctr_lines_child = 19;
            //move zeros to  form - cnt.
            form_cnt = 0;
        }
        private   void cb0_99_exit()
        {
        }
        private   void cc0_process_docs_by_branch()
        {
            //move wf-bank - acct - nbr           to r153b-p1 - acct.
            r153b_p1_acct_child = objWork_file_rec.wf_bank_acct_nbr;

            //move "DR."              to r153b-p1 - dr - lit.
            r153b_p1_dr_lit_child = "DR.";

            //move spaces to  ws - inits
            //                ws - initials.

            ws_inits = string.Empty;
            ws_initials_grp = string.Empty;
            ws_1st_init_grp_child = string.Empty;
            ws_init1_child = string.Empty;
            ws_dot1_child = string.Empty;
            ws_2nd_init_grp_child = string.Empty;
            ws_init2_child = string.Empty;
            ws_dot2 = string.Empty;
            ws_3rd_init_grp_child = string.Empty;
            ws_init3_child = string.Empty;
            ws_dot3_child = string.Empty;
            
            //if wf - init1 not = spaces then
            if (!string.IsNullOrWhiteSpace(objWork_file_rec.wf_init1_child))
            {
                //     move wf - init1           to ws-init1
                ws_init1_child = objWork_file_rec.wf_init1_child;
                //     move "."            to ws-dot1.
                ws_dot1_child = ".";
            }
            
            //if wf - init2 not = spaces then
            if (!string.IsNullOrWhiteSpace(objWork_file_rec.wf_init2_child))
            {
                //      move wf - init2           to ws-init2
                ws_init2_child = objWork_file_rec.wf_init2_child;
                //      move "."            to ws-dot2.
                ws_dot2 = ".";
            }

            //if wf - init3 not = spaces then
            if (!string.IsNullOrWhiteSpace(objWork_file_rec.wf_init3_child))
            {
                //   move wf - init3           to ws-init3
                ws_init3_child = objWork_file_rec.wf_init3_child;
                //   move "."            to ws-dot3.
                ws_dot3_child = ".";
            }            

            //string ws-1st - init delimited by spaces, 
            //       ws - 2nd - init delimited by spaces, 
            //       ws - 3rd - init delimited by spaces, 
            //		   into ws-inits.

            ws_1st_init_grp_child = ws_init1_child + ws_dot1_child;
            ws_2nd_init_grp_child = ws_init2_child + ws_dot2;
            ws_3rd_init_grp_child = ws_init3_child + ws_dot3_child;

            ws_inits = ws_1st_init_grp_child + ws_2nd_init_grp_child + ws_3rd_init_grp_child;

            //move ws-inits           to r153b-p1 - inits.
            r153b_p1_inits_child = ws_inits;

            //move wf - doc - name        to r153b-p1 - name.
            r153b_p1_name_child = objWork_file_rec.wf_doc_name;

            //move wf - pay             to r153b-p1 - pay.
            r153b_p1_pay_child = objWork_file_rec.wf_pay;

            //perform cc1 - write - detail - line   thru cc1-99 - exit.
            cc1_write_detail_line();
            cc1_99_exit();

            //add wf - pay              to ws-bank - total.
            ws_bank_total = ws_bank_total + objWork_file_rec.wf_pay;

            //perform cc2 - read - work - file      thru cc2-99 - exit.
            cc2_read_work_file();
            cc2_99_exit();
        }
        private   void cc0_99_exit()
        {
        }
        private   void cc1_write_detail_line()
        {
            //if ctr - lines > max - nbr - lines then
            if (ctr_lines_child > max_nbr_lines) {
                //   perform cb0 - print - headings  thru cb0-99 - exit.
                cb0_print_headings();
                cb0_99_exit();
            }

            //if total - flag = "Y" then
            if (total_flag.ToUpper().Equals("Y")) {
                //    write prt - line - b from r153b-prt - 1 after advancing ctr - nbr - lines lines
                r153b_prt_1_grp = new string(' ', 9) + Util.Str(r153b_p1_acct_child).PadRight(12) + new string(' ', 2) + Util.Str(r153b_p1_dr_lit_child).PadRight(4) + Util.Str(r153b_p1_inits_child).PadRight(6) + Util.Str(r153b_p1_name_child).PadRight(24) + " " + string.Format("{0:C}", r153b_p1_pay_child);
                objPrint_file_b.prt_line_b = r153b_prt_1_grp;

                for (int i = 1; i <= ctr_nbr_lines_child; i++)
                {
                    objPrtLineB.print(true);
                }
                objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

                //    move "N" to total-flag
                total_flag = "N";
            }
            else {
                //    write prt-line - b from r153b-prt - 1 after advancing 2 lines.
                r153b_prt_1_grp = new string(' ', 9) + Util.Str(r153b_p1_acct_child).PadRight(12) + new string(' ', 2) + Util.Str(r153b_p1_dr_lit_child).PadRight(4) + Util.Str(r153b_p1_inits_child).PadRight(6) + Util.Str(r153b_p1_name_child).PadRight(24) + " " + string.Format("{0:C}", r153b_p1_pay_child);
                objPrint_file_b.prt_line_b = r153b_prt_1_grp;
                objPrtLineB.print(true);
                objPrtLineB.print(true);
                objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);
            }

            //move spaces        to r153b-prt - 1.
            r153b_prt_1_grp = string.Empty;

            //add 2              to ctr-lines
            //                     form - cnt.
            ctr_lines_child = ctr_lines_child + 2;
            form_cnt = form_cnt + 2;
        }
        private   void cc1_99_exit()
        {
        }
        private   void cc2_read_work_file()
        {
            //return r153 - work - file
            //         at end
            //         move "Y"            to eof-work - file
            //         go to cc2 - 99 - exit.

            //add 1               to ctr-wf - reads.
            
            Work_file_rec_Collection = new ObservableCollection<Work_file_rec>(); // todo: Where's the data?? this is not a table in SQL Server.

            if (Work_file_rec_Collection.Count() == 0)
            {
                eof_work_file = "Y";
                cc2_99_exit();
                return;
            }
            else
            {
                if (ctr_wf_reads_child >= Work_file_rec_Collection.Count())
                {
                    eof_work_file = "Y";
                    cc2_99_exit();
                    return;
                }
                else
                {
                    var ctr = 0;
                    foreach (Work_file_rec obj in Work_file_rec_Collection.OrderBy(x => x.wf_bank_cd_branch_grp).ThenBy(y => y.wf_bank_acct_nbr).ThenBy(z => z.wf_doc_nbr))
                    {
                        if (ctr == ctr_wf_reads_child)
                        {
                            objWork_file_rec = obj;
                            ctr_wf_reads_child++;
                            break;
                        }
                        ctr++;
                    }
                }
            }
        }
        private   void cc2_99_exit()
        {
        }
        private   void cd0_write_bank_total()
        {
            //move "BANK TOTAL"           to r153b-p1 - name.
            r153b_p1_name_child = "BANK TOTAL";

            //move ws - bank - total          to r153b-p1 - pay.
            r153b_p1_pay_child = ws_bank_total;

            //subtract form - cnt from max-form - lines giving ctr-nbr - lines.
            ctr_nbr_lines_child = max_form_lines - form_cnt;

            //move "Y"                to total-flag.
            total_flag = "Y";

            //perform cc1 - write - detail - line   thru cc1-99 - exit.
            cc1_write_detail_line();
            cc1_99_exit();
        }
        private   void cd0_99_exit()
        {
        }
        private   void da0_read_doc_mstr()
        {
            //move chq-reg - doc - nbr        to doc-nbr.
            objF020_DOCTOR_MSTR.DOC_NBR = objF060_CHEQUE_REG_MSTR.CHQ_REG_DOC_NBR;

            //move zeroes to  ws - doc - totals - mtd - ytd(ss - mtd)
            //                ws - doc - totals - mtd - ytd(ss - ytd).

            for (var col = 1; col <= 10; col++)
            {
                ws_misc_gross_child[ss_mtd, col] = 0;
            }

            for (var col = 1; col <= 10; col++)
            {
                ws_misc_gross_child[ss_ytd, col] = 0;
            }

            for (var col = 1; col <= 10; col++)
            {
                ws_misc_net_child[ss_mtd, col] = 0;
            }
            for (var col = 1; col <= 10; col++)
            {
                ws_misc_net_child[ss_ytd, col] = 0;
            }

            ws_bill_gross_child[ss_mtd] = 0;
            ws_bill_gross_child[ss_ytd] = 0;

            ws_bill_net_child[ss_mtd] = 0;
            ws_bill_net_child[ss_ytd] = 0;

            ws_inc[ss_mtd] = 0;
            ws_inc[ss_ytd] = 0;

            ws_net_inc_child[ss_mtd] = 0;
            ws_net_inc_child[ss_ytd] = 0;

            ws_exp_amt_child[ss_mtd] = 0;
            ws_exp_amt_child[ss_ytd] = 0;

            ws_ceil_amt_child[ss_mtd] = 0;
            ws_ceil_amt_child[ss_ytd] = 0;

            ws_pay_due_child[ss_mtd] = 0;
            ws_pay_due_child[ss_ytd] = 0;

            ws_tax_child[ss_mtd] = 0;
            ws_tax_child[ss_ytd] = 0;

            ws_bank_deposit_child[ss_mtd] = 0;
            ws_bank_deposit_child[ss_ytd] = 0;

            ws_manual_chqs_child[ss_mtd] = 0;
            ws_manual_chqs_child[ss_ytd] = 0;

            //read doc-mstr
            //       invalid key
            //         move spaces         to doc-mstr - rec
            //         move chq-reg - doc - nbr        to doc-nbr
            //         move "***UNKNOWN***"        to doc-name
            //         move zeros          to doc-bank - nbr
            //                                doc - bank - branch
            //                                doc - bank - acct
            //         move chq-reg - clinic - nbr - 1 - 2 to doc-clinic - nbr
            //                  go to da0 - 99 - exit.

            //add 1               to ctr-doc - mstr - reads.

            F020_DOCTOR_MSTR_Collection = null;
            F020_DOCTOR_MSTR_Collection = new F020_DOCTOR_MSTR().Collection();

            if (F020_DOCTOR_MSTR_Collection.Count() == 0)
            {
                //    move spaces         to doc-mstr - rec
                objF020_DOCTOR_MSTR = null;
                //    move chq-reg - doc - nbr        to doc-nbr
                objF020_DOCTOR_MSTR.DOC_NBR = objF060_CHEQUE_REG_MSTR.CHQ_REG_DOC_NBR;
                //    move "***UNKNOWN***"        to doc-name
                objF020_DOCTOR_MSTR.DOC_NAME = "***UNKNOWN***";
                //    move zeros          to doc-bank - nbr
                objF020_DOCTOR_MSTR.DOC_BANK_NBR = 0;
                //                        doc - bank - branch
                objF020_DOCTOR_MSTR.DOC_BANK_BRANCH = 0;
                //                        doc - bank - acct
                objF020_DOCTOR_MSTR.DOC_BANK_ACCT = "0";
                //    move chq-reg - clinic - nbr - 1 - 2 to doc-clinic - nbr

                foreach (var obj in F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection)
                {
                    obj.DOC_CLINIC_NBR = objF060_CHEQUE_REG_MSTR.CHQ_REG_CLINIC_NBR_1_2;
                }
                //    go to da0 - 99 - exit.
                da0_99_exit();
                return;
            }
            else
            {
                if (ctr_doc_mstr_reads_child >= F020_DOCTOR_MSTR_Collection.Count())
                {
                    //    move spaces         to doc-mstr - rec
                    objF020_DOCTOR_MSTR = null;
                    //    move chq-reg - doc - nbr        to doc-nbr
                    objF020_DOCTOR_MSTR.DOC_NBR = objF060_CHEQUE_REG_MSTR.CHQ_REG_DOC_NBR;
                    //    move "***UNKNOWN***"        to doc-name
                    objF020_DOCTOR_MSTR.DOC_NAME = "***UNKNOWN***";
                    //    move zeros          to doc-bank - nbr
                    objF020_DOCTOR_MSTR.DOC_BANK_NBR = 0;
                    //                        doc - bank - branch
                    objF020_DOCTOR_MSTR.DOC_BANK_BRANCH = 0;
                    //                        doc - bank - acct
                    objF020_DOCTOR_MSTR.DOC_BANK_ACCT = "0";
                    //    move chq-reg - clinic - nbr - 1 - 2 to doc-clinic - nbr

                    foreach (var obj in F020C_DOC_CLINIC_NEXT_BATCH_NBR_Collection)
                    {
                        obj.DOC_CLINIC_NBR = objF060_CHEQUE_REG_MSTR.CHQ_REG_CLINIC_NBR_1_2;
                    }
                    //    go to da0 - 99 - exit.
                    da0_99_exit();
                    return;
                }
                else
                {
                    var ctr = 0;
                    foreach (F020_DOCTOR_MSTR obj in F020_DOCTOR_MSTR_Collection)
                    {
                        if (ctr == ctr_doc_mstr_reads_child)
                        {
                            objF020_DOCTOR_MSTR = obj;
                            ctr_doc_mstr_reads_child++;
                            break;
                        }
                        ctr++;
                    }
                }
            }
        }
        private   void da0_99_exit()
        {
        }
        private   void db0_read_dept_mstr()
        {
            //move doc-dept to dept-nbr.
            objF070_DEPT_MSTR.DEPT_NBR = objF020_DOCTOR_MSTR.DOC_DEPT;

            //read dept - mstr
            //    invalid key
            //     move "***INVALID DEPT NUMBER***" to dept-name.

            F070_DEPT_MSTR_Collection = new F070_DEPT_MSTR
            {
                WhereDept_nbr = objF020_DOCTOR_MSTR.DOC_DEPT
            }.Collection();

            if (F070_DEPT_MSTR_Collection.Count == 0)
            {
                objF070_DEPT_MSTR = new F070_DEPT_MSTR();
                objF070_DEPT_MSTR.DEPT_NAME = "***INVALID DEPT NUMBER***";
            }
            else
            {
                objF070_DEPT_MSTR = F070_DEPT_MSTR_Collection.FirstOrDefault();
            }
        }
        private   void db0_99_exit()
        {
        }
        private   void ea0_bank_info_to_chq()
        {
            //move bank-name          to r153c-p4 - bank - name.
            r153c_p4_bank_name_child = objF080_BANK_MSTR.BANK_NAME;
            //move bank - address1          to r153c-p5 - bank - addr1.
            r153c_p5_bank_addr1_child = objF080_BANK_MSTR.BANK_ADDRESS1;
            //move bank - address2          to r153c-p5 - bank - addr2.
            r153c_p5_bank_addr2_child = objF080_BANK_MSTR.BANK_ADDRESS2;
            //move bank - city - prov         to r153c-p6 - city - prov.
            r153c_p6_city_prov_child = objF080_BANK_MSTR.BANK_CITY + " " + objF080_BANK_MSTR.BANK_PROV;

            //move bank - postal - cd         to ws-postal - code.                        
            ws_postal_code_grp = objF080_BANK_MSTR.BANK_PC1 + objF080_BANK_MSTR.BANK_PC2 + objF080_BANK_MSTR.BANK_PC3 + objF080_BANK_MSTR.BANK_PC4 + objF080_BANK_MSTR.BANK_PC5 + objF080_BANK_MSTR.BANK_PC6;

            //move ws-pc - 153          to r153c-p3 - pc - 153.
            ws_pc_153_child = objF080_BANK_MSTR.BANK_PC1 + objF080_BANK_MSTR.BANK_PC2 + objF080_BANK_MSTR.BANK_PC3;
            r153c_p3_pc_153_child = ws_pc_153_child;

            //move ws - pc - 456          to r153c-p3 - pc - 456.
            ws_pc_456_child = objF080_BANK_MSTR.BANK_PC4 + objF080_BANK_MSTR.BANK_PC5 + objF080_BANK_MSTR.BANK_PC6;
            r153c_p3_pc_456_child = ws_pc_456_child;
        }
        private   void ea0_99_exit()
        {
        }
        private   void eb0_write_chq()
        {
            //move ws-bank - total          to r153c-p1 - chq - amt
            //                                 r153c - p2 - chq - amt.

            r153c_p1_chq_amt_child = ws_bank_total;
            r153c_p2_chq_amt_child = ws_bank_total;

            //* **rounded off total to nearest hundred
            // add 99.99, ws - bank - total        giving ws-bank - total - 1.
            ws_bank_total_1 = ws_bank_total + 99.99M;

            // divide 100              into ws-bank - total - 1
            //                          giving ws-rounded - total.
            ws_rounded_total = Util.NumInt(ws_bank_total_1 / 100);

            // move ws - rounded - total       to r153c-p2 - hundreds.
            r153c_p2_hundreds_child = ws_rounded_total;

            //write prt-line - c from r153c-head - first     after page.  // Todo: After page...
            r153c_head_first_grp = "R153C" + new string(' ', 80);
            objPrint_file_c.prt_line_c = r153c_head_first_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-head - 1  after   5 lines.
            r153c_head_1_grp = "  RMA MONTH'S EARNINGS".PadRight(85);
            objPrint_file_c.prt_line_c = r153c_head_1_grp;
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-prt - 1   after   1 line.
            r153c_prt_1_grp = new string(' ', 27) + string.Format("{0:C}", r153c_p1_chq_amt_child) + new string(' ', 12) + Util.Str(r153c_p1_mth_child).PadRight(10) + r153c_p1_day_child.ToString() + Util.Str(r153c_p1_comma_child).PadRight(2) + r153c_p1_yr_child.ToString();
            objPrint_file_c.prt_line_c = r153c_prt_1_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //move "NOT TO EXCEED***"     to r153c-p2 - lit1.
            r153c_p2_lit1_chld = "NOT TO EXCEED***";

            //move "****HUNDRED DOLLARS"      to r153c-p2 - lit2.
            r153c_p2_lit2_child = "****HUNDRED DOLLARS";

            //write prt - line - c from r153c-prt - 2   after   6 lines.
            r153c_prt_2_grp = new string(' ', 8) + Util.Str(r153c_p2_lit1_chld).PadRight(16) + r153c_p2_hundreds_child.ToString() + Util.Str(r153c_p2_lit2_child).PadRight(28) + string.Format("{0:c}", r153c_p2_chq_amt_child);
            objPrint_file_c.prt_line_c = r153c_prt_2_grp;
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-prt - 4   after   4 lines.
            r153c_prt_4_grp = new string(' ', 8) + Util.Str(r153c_p4_bank_name_child).PadRight(77);
            objPrint_file_c.prt_line_c = r153c_prt_4_grp;
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(true);
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-prt - 5   after   1 line.
            r153c_prt_5_grp = new string(' ', 8) + Util.Str(r153c_p5_bank_addr1_child).PadRight(77);
            objPrint_file_c.prt_line_c = r153c_prt_5_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-prt - 5a after   1 line.
            r153c_prt_5a_grp = new string(' ', 8) + Util.Str(r153c_p5_bank_addr2_child).PadRight(77);
            objPrint_file_c.prt_line_c = r153c_prt_5a_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-prt - 6   after   1 line.
            r153c_prt_6_grp = new string(' ', 8) + Util.Str(r153c_p6_city_prov_child).PadRight(77);
            objPrint_file_c.prt_line_c = r153c_prt_6_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //write prt-line - c from r153c-prt - 3   after   1 line.
            r153c_prt_3_grp = new string(' ', 8) + Util.Str(r153c_p3_pc_153_child).PadRight(3) + " " + Util.Str(r153c_p3_pc_456_child).PadRight(3);
            objPrint_file_c.prt_line_c = r153c_prt_3_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //move spaces             to r153c-prt - 2
            //                           r153c - prt - 3
            //                           r153c - prt - 4
            //                           r153c - prt - 5
            //                           r153c - prt - 5a
            //                           r153c - prt - 6.
            r153c_prt_2_grp = string.Empty;
            r153c_prt_3_grp = string.Empty;
            r153c_prt_4_grp = string.Empty;
            r153c_prt_5_grp = string.Empty;
            r153c_prt_5a_grp = string.Empty;
            r153c_prt_6_grp = string.Empty;

            //add 1               to ctr-cheques.
            ctr_cheques_child++;
            //add ws - bank - total           to ws-final - total.
            ws_final_total = ws_final_total + ws_bank_total;
            //move 0              to ws-bank - total.
            ws_bank_total = 0;
        }
        private   void eb0_99_exit()
        {
        }
        private   void ed0_print_totals()
        {
            //add 1              to page-cnt.
            page_cnt++;

            //move page - cnt           to r153b-h1 - page.
            r153b_h1_page_child = page_cnt;

            //write prt-line - b from r153b-head - first  after page.  // todo: After page
            r153b_head_first_grp = "R153B" + new string(' ', 72);
            objPrint_file_b.prt_line_b = r153b_head_first_grp;
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //move "FINAL TOTAL"          to r153b-p1 - name.
            r153b_p1_name_child = "FINAL TOTAL";

            //move ws - final - total         to r153b-p1 - pay.
            r153b_p1_pay_child = ws_final_total;

            //write prt - line - b from r153b-prt - 1   after   19 lines.
            r153b_prt_1_grp = new string(' ', 9) + Util.Str(r153b_p1_acct_child).PadRight(12) + new string(' ', 2) + Util.Str(r153b_p1_dr_lit_child).PadRight(4) + Util.Str(r153b_p1_inits_child).PadRight(6) + Util.Str(r153b_p1_name_child).PadRight(24) + " " + string.Format("{0:C}", r153b_p1_pay_child);
            objPrint_file_b.prt_line_b = r153b_prt_1_grp;
            
            for (var i = 1; i <=19; i++)
            {
                objPrtLineB.print(true);
            }
            objPrtLineB.print(objPrint_file_b.prt_line_b, 1, true);

            //write prt-line - c from r153c-head - first       after page.  // todo: After page
            r153c_head_first_grp = "R153C" + new string(' ', 80);
            objPrint_file_c.prt_line_c = r153c_head_first_grp;
            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);

            //move "TOTAL CHEQUES-"       to r153c-p7 - tot - chq.
            r153c_p7_tot_chq_child = "TOTAL CHEQUES-";

            //move "  TOTAL AMT-"         to r153c-p7 - tot - amt.
            r153c_p7_tot_amt_child = "  TOTAL AMT-";

            //move ctr - cheques            to r153c-p7 - nbr - chqs.
            r153c_p7_nbr_chqs_child = ctr_cheques_child;

            //move ws - final - total         to r153c-p7 - fin - total.
            r153c_p7_fin_total_child = ws_final_total;

            //write prt - line - c from r153c-prt - 7   after   18 lines.
            r153c_prt_7_grp = new string(' ', 9) + Util.Str(r153c_p7_tot_chq_child).PadRight(14) + r153c_p7_nbr_chqs_child.ToString() + Util.Str(r153c_p7_tot_amt_child).PadRight(13) + string.Format("{0:0,0.00}", r153c_p7_fin_total_child);
            objPrint_file_c.prt_line_c = r153c_prt_7_grp;

            for(int i= 1; i<=18;i++)
            {
                objPrtLineC.print(true);
            }

            objPrtLineC.print(objPrint_file_c.prt_line_c, 1, true);
        }
        private   void ed0_99_exit()
        {
        }
        private   void ua1_add_to_totals()
        {
            //*calculate net mtd

            //if chq - reg - mth - misc - amt(ss - mth - nbr, 1) not = zeroes then
            if (CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR,ss_mth_nbr,1) != 0) {
                //    add chq - reg - mth - misc - amt(ss - mth - nbr, 1)
                //                       to ws-misc - gross(ss - mtd, 1)
                ws_misc_gross_child[ss_mtd, 1] = ws_misc_gross_child[ss_mtd, 1] +  CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr, 1);

                //    multiply chq-reg - mth - misc - amt(ss - mth - nbr, 1)
                //                    by chq-reg - perc - misc(ss - mth - nbr)
                //                    giving ws-misc - net(ss - mtd, 1) rounded

                ws_misc_net_child[ss_mtd, 1] = CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr, 1) * CHQ_REG_PERC_MISC(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

                //    add ws - misc - net(ss - mtd, 1)      to ws-inc(ss - mtd).
                ws_inc[ss_mtd] = ws_inc[ss_mtd] + ws_misc_net_child[ss_mtd, 1];
            }

            //perform ua2-remaining - misc      thru ua2-99 - exit
            //                           varying ss-misc
            //                           from 2 by 1
            //                            until ss-misc > 10.

            ss_misc = 2;
            do
            {
                ua2_remaining_misc();
                ua2_99_exit();
                ss_misc++;
            } while (ss_misc <= 10);

            //if chq - reg - mth - bill - amt(ss - mth - nbr) not = zeroes then
            if (CHQ_REG_MTH_BILL_AMT(objF060_CHEQUE_REG_MSTR,ss_mth_nbr)!= 0) {
                //   add chq - reg - mth - bill - amt(ss - mth - nbr) to ws-bill - gross(ss - mtd)
                ws_bill_gross_child[ss_mtd] = ws_bill_gross_child[ss_mtd] + CHQ_REG_MTH_BILL_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

                //   multiply chq-reg - mth - bill - amt(ss - mth - nbr)
                //                          by chq-reg - perc - bill(ss - mth - nbr)
                //                          giving ws-bill - net(ss - mtd) rounded
                ws_bill_net_child[ss_mtd] = CHQ_REG_MTH_BILL_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr) * CHQ_REG_PERC_BILL(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

                //   add ws - bill - net(ss - mtd)            to ws-inc(ss - mtd).
                ws_inc[ss_mtd] = ws_inc[ss_mtd] + ws_bill_net_child[ss_mtd];
            }

            //move chq-reg - mth - exp - amt(ss - mth - nbr)  to ws-exp - amt(ss - mtd).
            ws_exp_amt_child[ss_mtd] =  CHQ_REG_MTH_EXP_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

            //move chq - reg - mth - ceil - amt(ss - mth - nbr)  to ws-ceil - amt(ss - mtd).
            ws_ceil_amt_child[ss_mtd] = CHQ_REG_MTH_CEIL_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

            //add chq - reg - earnings - this - mth(ss - mth - nbr)
            //    chq - reg - man - tax - this - mth(ss - mth - nbr)
            //    chq - reg - man - pay - this - mth(ss - mth - nbr)
            //                      giving ws-pay - due(ss - mtd).

            ws_pay_due_child[ss_mtd] = CHQ_REG_EARNINGS_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr) + CHQ_REG_MAN_TAX_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr) + CHQ_REG_MAN_PAY_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

            //add chq - reg - regular - tax - this - mth(ss - mth - nbr)
            //    chq - reg - man - tax - this - mth(ss - mth - nbr)
            //                                giving ws-tax(ss - mtd).

            ws_tax_child[ss_mtd] = CHQ_REG_REGULAR_TAX_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr) + CHQ_REG_MAN_TAX_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

            //move chq - reg - regular - pay - this - mth(ss - mth - nbr)
            //                            to ws-bank - deposit(ss - mtd).
            ws_bank_deposit_child[ss_mtd] = CHQ_REG_REGULAR_PAY_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

            //move chq - reg - man - pay - this - mth(ss - mth - nbr)
            //                       to ws-manual - chqs(ss - mtd).
            ws_manual_chqs_child[ss_mtd] = CHQ_REG_MAN_PAY_THIS_MTH(objF060_CHEQUE_REG_MSTR, ss_mth_nbr);

            //*update ytd
            //perform ua3 - add - misc - to - ytd     thru ua3-99 - exit
            //                            varying ss-misc
            //                            from 1 by 1
            //                            until ss-misc > 10.

            ss_misc = 1;
            do
            {
                ua3_add_misc_to_ytd();
                ua3_99_exit();
                ss_misc++;
            } while (ss_misc <= 10);

            // add ws - bill - gross(ss - mtd)    to ws-bill - gross(ss - ytd).
            ws_bill_gross_child[ss_ytd] = ws_bill_gross_child[ss_ytd] + ws_bill_gross_child[ss_mtd];

            //add ws - bill - net(ss - mtd)    to ws-bill - net(ss - ytd).
            ws_bill_net_child[ss_ytd] = ws_bill_net_child[ss_ytd] + ws_bill_net_child[ss_mtd];

            //add ws - inc(ss - mtd)    to ws-inc(ss - ytd).
            ws_inc[ss_ytd] = ws_inc[ss_ytd] + ws_inc[ss_mtd];

            //add ws-exp - amt(ss - mtd)    to ws-exp - amt(ss - ytd).
            ws_exp_amt_child[ss_ytd] = ws_exp_amt_child[ss_ytd] + ws_exp_amt_child[ss_mtd];

            //add ws - ceil - amt(ss - mtd)    to ws-ceil - amt(ss - ytd).
            ws_ceil_amt_child[ss_ytd] = ws_ceil_amt_child[ss_ytd] + ws_ceil_amt_child[ss_mtd];

            //add ws - pay - due(ss - mtd)    to ws-pay - due(ss - ytd).
            ws_pay_due_child[ss_ytd] = ws_pay_due_child[ss_ytd] + ws_pay_due_child[ss_mtd];

            //add ws - tax(ss - mtd)    to ws-tax(ss - ytd).
            ws_tax_child[ss_ytd] = ws_tax_child[ss_ytd] + ws_tax_child[ss_mtd];

            //add ws - bank - deposit(ss - mtd)    to ws-bank - deposit(ss - ytd).
            ws_bank_deposit_child[ss_ytd] = ws_bank_deposit_child[ss_ytd] + ws_bank_deposit_child[ss_mtd];

            //add ws - manual - chqs(ss - mtd)    to ws-manual - chqs(ss - ytd).
            ws_manual_chqs_child[ss_ytd] = ws_manual_chqs_child[ss_ytd] + ws_manual_chqs_child[ss_mtd];

            //if ss - mth - nbr not = ss - chq then
            if (ss_mth_nbr != ss_chq) {
                //   move zeroes to  ws - doc - totals - mtd - ytd(ss - mtd).
                ws_doc_totals_mtd_ytd_grp_child[ss_mtd] = "0";
                ws_misc_gross_child[ss_mtd, 1] = 0M;
                ws_misc_gross_child[ss_mtd, 2] = 0M;
                ws_misc_gross_child[ss_mtd, 3] = 0M;
                ws_misc_gross_child[ss_mtd, 4] = 0M;
                ws_misc_gross_child[ss_mtd, 5] = 0M;
                ws_misc_gross_child[ss_mtd, 6] = 0M;
                ws_misc_gross_child[ss_mtd, 7] = 0M;
                ws_misc_gross_child[ss_mtd, 8] = 0M;
                ws_misc_gross_child[ss_mtd, 9] = 0M;
                ws_misc_gross_child[ss_mtd, 10] = 0M;

                ws_misc_net_child[ss_mtd, 1] = 0M;
                ws_misc_net_child[ss_mtd, 2] = 0M;
                ws_misc_net_child[ss_mtd, 3] = 0M;
                ws_misc_net_child[ss_mtd, 4] = 0M;
                ws_misc_net_child[ss_mtd, 5] = 0M;
                ws_misc_net_child[ss_mtd, 6] = 0M;
                ws_misc_net_child[ss_mtd, 7] = 0M;
                ws_misc_net_child[ss_mtd, 8] = 0M;
                ws_misc_net_child[ss_mtd, 9] = 0M;
                ws_misc_net_child[ss_mtd, 10] = 0M;

                ws_bill_gross_child[ss_mtd] = 0;
                ws_bill_net_child[ss_mtd] = 0;
                ws_inc[ss_mtd] = 0;
                ws_net_inc_child[ss_mtd] = 0;
                ws_exp_amt_child[ss_mtd] = 0;
                ws_ceil_amt_child[ss_mtd] = 0;
                ws_pay_due_child[ss_mtd] = 0;
                ws_tax_child[ss_mtd] = 0;
                ws_bank_deposit_child[ss_mtd] = 0;
                ws_manual_chqs_child[ss_mtd] = 0;
            }
        }
        private   void ua1_99_exit()
        {
        }
        private   void ua2_remaining_misc()
        {
            //if chq - reg - mth - misc - amt(ss - mth - nbr, ss - misc) not = zeroes then
            if (CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR,ss_mth_nbr,ss_misc) != 0) {
                //      add chq - reg - mth - misc - amt(ss - mth - nbr, ss - misc)
                //                          to ws-misc - gross(ss - mtd, ss - misc)
                ws_misc_gross_child[ss_mtd, ss_misc] = ws_misc_gross_child[ss_mtd, ss_misc] +  CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr, ss_misc);

                //    subtract 1          from ss-misc
                //                          giving ss-perc
                ss_perc = ss_misc - 1;

                //    multiply chq-reg - mth - misc - amt(ss - mth - nbr, ss - misc)
                //                            by  const-misc - curr(ss - perc)
                //                            giving ws-misc - net(ss - mtd, ss - misc) rounded
                ws_misc_net_child[ss_mtd, ss_misc] = CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_mth_nbr, ss_misc) * CONST_MISC_CURR(objConstants_Mstr_Rec_3, ss_perc);

                //   add ws - misc - net(ss - mtd, ss - misc)   to ws-inc(ss - mtd).
                ws_inc[ss_mtd] = ws_inc[ss_mtd] + ws_misc_net_child[ss_mtd, ss_misc];
            }
        }

        private   void ua2_99_exit()
        {
        }
        private   void ua3_add_misc_to_ytd()
        {
            //add ws-misc - net(ss - mtd, ss - misc)   to ws-misc - net(ss - ytd, ss - misc).
            ws_misc_net_child[ss_ytd, ss_misc] = ws_misc_net_child[ss_ytd, ss_misc] + ws_misc_net_child[ss_mtd, ss_misc];

            //add ws - misc - gross(ss - mtd, ss - misc) to ws-misc - gross(ss - ytd, ss - misc).
            ws_misc_gross_child[ss_ytd, ss_misc] = ws_misc_gross_child[ss_ytd, ss_misc] + ws_misc_gross_child[ss_mtd, ss_misc];
        }

        private   void ua3_99_exit()
        {
        }
        private   void wa0_write_headings()
        {
            //move spaces             to ws-initials
            //                           ws - inits - name.

            ws_initials_grp = string.Empty;
            ws_init1_child = string.Empty;
            ws_dot1_child = string.Empty;
            ws_1st_init_grp_child = string.Empty;

            ws_init2_child = string.Empty;
            ws_dot2 = string.Empty;
            ws_2nd_init_grp_child = string.Empty;

            ws_init3_child = string.Empty;
            ws_dot3_child = string.Empty;
            ws_3rd_init_grp_child = string.Empty;

            ws_inits_name = string.Empty;

            //if doc - init1 not = spaces then
            //    move doc - init1          to ws-init1
            //    move "."            to ws-dot1.
            
            if (!string.IsNullOrWhiteSpace(objF020_DOCTOR_MSTR.DOC_INIT1))
            {
                ws_init1_child = objF020_DOCTOR_MSTR.DOC_INIT1;             
                ws_dot1_child = ".";
            }

            //if doc - init2 not = spaces then
            //    move doc - init2          to ws-init2
            //    move "."            to ws-dot2.
            
            if (!string.IsNullOrWhiteSpace(objF020_DOCTOR_MSTR.DOC_INIT2))
            {                
                ws_init2_child = objF020_DOCTOR_MSTR.DOC_INIT2;             
                ws_dot2 = ".";
            }
            
            //if doc - init3 not = spaces then
            if (!string.IsNullOrWhiteSpace(objF020_DOCTOR_MSTR.DOC_INIT3))
            {
                //     move doc - init3          to ws-init3
                ws_init3_child = objF020_DOCTOR_MSTR.DOC_INIT3;
                //     move "."            to ws-dot3.
                ws_dot3_child = ".";
            }

            // string ws-1st - init delimited by spaces,  
            //        ws - 2nd - init delimited by spaces, 
            //        ws - 3rd - init delimited by spaces, 
            //        doc - name delimited by ws - xx, 
            //		                    into ws-inits - name.

            ws_1st_init_grp_child = ws_init1_child + ws_dot1_child;
            ws_2nd_init_grp_child = ws_init2_child + ws_dot2;
            ws_3rd_init_grp_child = ws_init3_child + ws_dot3_child;

            ws_inits_name = ws_1st_init_grp_child + ws_2nd_init_grp_child + ws_3rd_init_grp_child + objF020_DOCTOR_MSTR.DOC_NAME;

            //move ws-inits - name          to r153a-h1 - inits - name.
            r153a_h1_inits_name_child = ws_inits_name;

            //move doc - nbr            to r153a-h1 - doc - nbr.
            r153a_h1_doc_nbr_child = objF020_DOCTOR_MSTR.DOC_NBR;

            //move doc - dept           to r153a-h1 - dept.
            r153a_h1_dept_child = Util.NumInt(objF020_DOCTOR_MSTR.DOC_DEPT);

            //move dept - name          to r153a-h1 - 1 - dept - name.
            r153a_h1_1_dept_name_child = objF070_DEPT_MSTR.DEPT_NAME;

            //write prt - line - a from r153a-head - first  after page.   //todo After page...
            r153a_head_first_grp = "R153A" + new string(' ', 127);
            objPrint_file_a.prt_line_a = r153a_head_first_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 1  after   1 line.
            r153a_head_1_grp = "TO:".PadRight(7) + "DR." + Util.Str(r153a_h1_inits_name_child).PadRight(30) + new string(' ', 3) + "NBR:".PadRight(6) + Util.Str(r153a_h1_doc_nbr_child).PadRight(3);
            objPrint_file_a.prt_line_a = r153a_head_1_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 1 - 1  after  1 line.
            r153a_head_1_1_grp = new string(' ', 7) + Util.Str(r153a_h1_1_dept_name_child).PadRight(30) + new string(' ', 7) + "DEPT:".PadRight(6) + r153a_h1_dept_child.ToString();
            objPrint_file_a.prt_line_a = r153a_head_1_1_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 2  after   2 lines.
            r153a_head_2_grp = "FROM:" + "MR. JOHN E. MCCUTCHEON, FACMGA, EXECUTIVE DIRECTOR";
            objPrint_file_a.prt_line_a = r153a_head_2_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 3  after   2 lines.
            r153a_head_3_grp = "DATE:" + r153a_h3_yr_child.ToString() + "/" + r153a_h3_mth_child.ToString() + "/" + r153a_h3_day_child.ToString();
            objPrint_file_a.prt_line_a = r153a_head_3_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 4  after   5 lines.
            r153a_head_4_grp = new string(' ', 29) + "REGIONAL MEDICAL ASSOCIATES".PadRight(40);
            objPrint_file_a.prt_line_a = r153a_head_4_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 5  after   2 lines.
            r153a_head_5_grp = new string(' ', 14) + "STATEMENT OF EARNINGS FOR THE PERIOD ENDING".PadRight(44) + r153a_h5_yr_child.ToString() + "/" + r153a_h5_mth_child.ToString() + "/" + r153a_h5_day_child.ToString();
            objPrint_file_a.prt_line_a = r153a_head_5_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 6  after   3 lines.
            r153a_head_6_grp = new string(' ', 67) + "SINCE";
            objPrint_file_a.prt_line_a = r153a_head_6_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-head - 7  after   1 line.
            r153a_head_7_grp = new string(' ', 45) + "THIS MONTH".PadRight(10) + new string(' ', 8) + "JULY 1, " + r153a_h7_yr_child.ToString();
            objPrint_file_a.prt_line_a = r153a_head_7_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from blank-line    after   1 line.
            blank_line_grp = new string(' ', 132);
            objPrint_file_a.prt_line_a = blank_line_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
        }
        private   void wa0_99_exit()
        {
        }
        private   void wa1_write_report()
        {
            // move zeroes  to ctr-nbr - misc - lines
            ctr_nbr_misc_lines_child = 0;
            //             ws - print - gross - misc - total
            ws_print_gross_misc_total = 0;
            //             ws - print - mtd - misc - total
            ws_print_mtd_misc_total = 0;
            //             ws - print - ytd - misc - total.
            ws_print_ytd_misc_total = 0;

            //perform wa2-print - misc      thru wa2-99 - exit
            //           varying ss-misc
            //           from 1 by 1
            //           until ss-misc > 10.

            ss_misc = 1;
            do
            {
                wa2_print_misc();
                wa2_99_exit();
                ss_misc++;
            } while (ss_misc <= 10);

            //if ctr - nbr - misc - lines > 1 then
            if (ctr_nbr_misc_lines_child > 1) {
                //    write prt - line - a from underscore-detail after 1 line
                underscore_detail_grp = new string(' ', 6) + "-----------" + new string(' ', 26) + "------------" + new string(' ', 7) + "-------------";
                objPrint_file_a.prt_line_a = underscore_detail_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

                //    move ws - print - gross - misc - total  to r153a-p2 - gross
                r153a_p2_gross_child = ws_print_gross_misc_total;

                //    move ws-print - mtd - misc - total    to r153a-p2 - mtd
                r153a_p2_mtd_child = ws_print_mtd_misc_total;

                //    move ws-print - ytd - misc - total    to r153a-p2 - ytd
                r153a_p2_ytd_child = ws_print_ytd_misc_total;

                //    write prt-line - a from r153a-prt - 2   after   1 line.
                r153a_prt_2_grp = new string(' ', 6) + "$" + String.Format("{0:0,0.00}", r153a_p2_gross_child) + new string(' ', 2) + "TOTAL MISC. INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p2_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p2_ytd_child);
                objPrint_file_a.prt_line_a = r153a_prt_2_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //move spaces                to r153a-p3 - plus - lit.
            r153a_p3_plus_lit_child = string.Empty;

            //if ctr - nbr - misc - lines = zero then
            if (ctr_nbr_misc_lines_child == 0) {
                //        move "$"            to r153a-p3 - lit - 1
                r153a_p3_lit_1_child = "$";
                //                               r153a - p3 - lit - 2
                r153a_p3_lit_2_child = "$";
                //                               r153a - p3 - lit - 3
                r153a_p3_lit_3_child = "$";
            }
            else {
                //       move "PLUS"         to r153a-p3 - plus - lit
                r153a_p3_plus_lit_child = "PLUS";
                //       move spaces         to r153a-p3 - lit - 2
                r153a_p3_lit_2_child = string.Empty;
                //       r153a - p3 - lit - 3.
                r153a_p3_lit_3_child = string.Empty;
            }

            //move chq-reg - mth - bill - amt(ss - chq)
            //                       to r153a-p3 - gross.
            r153a_p3_gross_child = CHQ_REG_MTH_BILL_AMT(objF060_CHEQUE_REG_MSTR, ss_chq);

            //multiply chq - reg - perc - bill(ss - chq)
            //                       by  100
            //        giving ws-print - percent.
            ws_print_percent = CHQ_REG_PERC_BILL(objF060_CHEQUE_REG_MSTR, ss_chq) * 100;

            //move ws - print - percent       to r153a-p3 - percent.
            r153a_p3_percent_child = ws_print_percent;

            //move ws - bill - net(ss - mtd)           to r153a-p3 - mtd.
            r153a_p3_mtd_child = ws_bill_net_child[ss_mtd];
            //move ws - bill - net(ss - ytd)           to r153a-p3 - ytd.
            r153a_p3_ytd_child = Util.Str(ws_bill_net_child[ss_ytd]);
            //  write prt - line - a from r153a-prt - 3   after   1 line.
            r153a_prt_3_grp = new string(' ', 2) + Util.Str(r153a_p3_plus_lit_child).PadRight(6) + new string(' ', 5) + Util.Str(r153a_p3_lit_1_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_gross_child) + " " + "BILLINGS    @ " + string.Format("{0:0,0.00}", r153a_p3_percent_child) + "%" + new string(' ', 3) + Util.Str(r153a_p3_lit_2_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_mtd_child) + new string(' ', 6) + Util.Str(r153a_p3_lit_3_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_3_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //*'IF' stmt.added for faculty expense detail line

            //if ctr - nbr - misc - lines > zero   or ws-exp - amt(ss - ytd) > zero then
            if (ctr_nbr_misc_lines_child > 0 || ws_exp_amt_child[ss_ytd] > 0 ) {
                //     write prt - line - a from underscore-total after 1 line
                underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
                objPrint_file_a.prt_line_a = underscore_total_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

                //     move ws - inc(ss - mtd)            to r153a-p4 - mtd
                r153a_p4_mtd_child = ws_inc[ss_mtd];
                //     move ws-inc(ss - ytd)            to r153a-p4 - ytd
                r153a_p4_ytd_child = ws_inc[ss_ytd];
                //     write prt-line - a from r153a-prt - 4 after 1 line.
                r153a_prt_4_grp = new string(' ', 20) + "TOTAL INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p4_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p4_ytd_child);
                objPrint_file_a.prt_line_a = r153a_prt_4_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //if  doc - ep - pay - code not = "4" then
            if (!objF020_DOCTOR_MSTR.DOC_EP_PAY_CODE.Equals("4")) {
                //    next sentence
            }
            else {
                //    move ws-exp - amt(ss - mtd)         to r153a-p3 - a - mtd
                r153a_p3_a_mtd_child = ws_exp_amt_child[ss_mtd];
                //    move ws-exp - amt(ss - ytd)         to r153a-p3 - a - ytd
                r153a_p3_a_ytd_child = ws_exp_amt_child[ss_ytd];
                //    write prt-line - a from r153a-prt - 3 - a after 1 line.
                r153a_prt_3_a_grp = new string(' ', 20) + "LESS FACULTY EXPENSE".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p3_a_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p3_a_ytd_child);
                objPrint_file_a.prt_line_a = r153a_prt_3_a_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //write prt-line - a from underscore-total after 1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //subtract ws-exp - amt(ss - mtd)             from ws-inc(ss - mtd)
            //                                 giving ws-net - inc(ss - mtd).
            ws_net_inc_child[ss_mtd] = ws_inc[ss_mtd] - ws_exp_amt_child[ss_mtd];

            //subtract ws - exp - amt(ss - ytd)             from ws-inc(ss - ytd)
            //                                      giving ws-net - inc(ss - ytd).
            ws_net_inc_child[ss_ytd] = ws_inc[ss_ytd] - ws_exp_amt_child[ss_ytd];

            //move ws - net - inc(ss - mtd)            to r153a-p4 - a - mtd.
            r153a_p4_a_mtd_child = ws_net_inc_child[ss_mtd];

            //move ws - net - inc(ss - ytd)            to r153a-p4 - a - ytd.
            r153a_p4_a_ytd_child = ws_net_inc_child[ss_ytd];
            //write prt - line - a from r153a-prt - 4 - a after 1 line.
            r153a_prt_4_a_grp = new string(' ', 20) + "NET INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p4_a_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p4_a_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_4_a_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-ceil - amt(ss - mtd)       to r153a-p5 - mtd.
            r153a_p5_mtd_child = ws_ceil_amt_child[ss_mtd];

            //move ws - ceil - amt(ss - ytd)       to r153a-p5 - ytd.
            r153a_p5_ytd_child = ws_ceil_amt_child[ss_ytd];
            //write prt - line - a from r153a-prt - 5   after   2 lines.
            r153a_prt_5_grp = new string(' ', 20) + "CEILING IS".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p5_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p5_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_5_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-pay - due(ss - mtd)            to r153a-p6 - mtd.
            r153a_p6_mtd_child = ws_pay_due_child[ss_mtd];

            //move ws - pay - due(ss - ytd)            to r153a-p6 - ytd.
            r153a_p6_ytd_child = Util.Str(ws_pay_due_child[ss_ytd]);

            //write prt - line - a from r153a-prt - 6   after   5 lines.
            r153a_prt_6_grp = new string(' ', 8) + "PAYMENT DUE".PadRight(35) + "$" + string.Format("{0:0,0.00}", r153a_p6_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p6_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_6_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-tax(ss - mtd)            to r153a-p7 - mtd.
            r153a_p7_mtd_child = ws_tax_child[ss_mtd];

            //move ws - tax(ss - ytd)            to r153a-p7 - ytd.
            r153a_p7_ytd_child = Util.Str(ws_tax_child[ss_ytd]);

            //write prt - line - a from r153a-prt - 7   after   1 line.
            r153a_prt_7_grp = new string(' ', 8) + "LESS INCOME TAX".PadRight(34) + "(" + string.Format("{0:0,0.00}", r153a_p7_mtd_child) + ")" + "(" + string.Format("{0:0,0.00}", r153a_p7_ytd_child) + ")";
            objPrint_file_a.prt_line_a = r153a_prt_7_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from underscore-total after    1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            // *(print deposit only if non - zer0 m.t.d.or y.t.d.amounts) 
            //if   ws - bank - deposit(ss - mtd) = zero and ws-bank - deposit(ss - ytd) = zero then
            if (ws_bank_deposit_child[ss_mtd] == 0 && ws_bank_deposit_child[ss_ytd] == 0) {
                //     next sentence
            }
            else {
                //     move ws-bank - deposit(ss - mtd)       to r153a-p8 - mtd
                r153a_p8_mtd_child = ws_bank_deposit_child[ss_mtd];
                //     move ws-bank - deposit(ss - ytd)       to r153a-p8 - ytd
                r153a_p8_ytd_child = ws_bank_deposit_child[ss_ytd];
                //     write prt-line - a from r153a-prt - 8   after   1 line.
                r153a_prt_8_grp = new string(' ', 8) + "AUTOMATIC BANK DEPOSIT ON ".PadRight(26) + r153a_p8_yr_child.ToString() + "/" + r153a_p8_mth_child.ToString() + "/" + r153a_p8_day_child.ToString() + " $" + string.Format("{0:0,0.00}", r153a_p8_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p8_ytd_child);
                objPrint_file_a.prt_line_a = r153a_prt_8_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //*(print manual payments only if non - zero m.t.d.or y.t.d.amounts) 
            //if    ws - manual - chqs(ss - mtd) = zero and ws-manual - chqs(ss - ytd) = zero then
            if (ws_manual_chqs_child[ss_mtd] == 0 && ws_manual_chqs_child[ss_ytd] == 0) {
                //      next sentence
            }
            else {
                //      move ws-manual - chqs(ss - mtd)        to r153a-p9 - mtd
                r153a_p9_mtd_child = ws_manual_chqs_child[ss_mtd];
                //      move ws-manual - chqs(ss - ytd)        to r153a-p9 - ytd
                r153a_p9_ytd_child = ws_manual_chqs_child[ss_ytd];
                //      write prt-line - a from r153a-prt - 9   after   1 line.
                r153a_prt_9_grp = new string(' ', 8) + Util.Str(yearend_label_child).PadRight(35) + "$" + string.Format("{0:0,0.00}", r153a_p9_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p9_ytd_child);
                objPrint_file_a.prt_line_a = r153a_prt_9_grp;
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //write prt-line - a from underscore-total after    1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from underscore-total after    1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move zero                              to total-earnings.
            total_earnings = 0;

            //add ws - tax(ss - ytd)                    to total-earnings.
            total_earnings = ws_tax_child[ss_ytd];

            //add ws - bank - deposit(ss - ytd)           to total-earnings.
            total_earnings = total_earnings + ws_bank_deposit_child[ss_ytd];

            //add ws - manual - chqs(ss - ytd)            to total-earnings.
            total_earnings = total_earnings + ws_manual_chqs_child[ss_ytd];

            //subtract ws - inc(ss - ytd)             from total-earnings
            //                                    giving ws-difference.
            ws_difference = total_earnings - ws_inc[ss_ytd];

            //if ws - difference > 0 then
            if (ws_difference > 0 ) {
                //     move ws - difference                 to r153a-p9 - a - ytd
                r153a_p9_a_ytd = ws_difference;
                //     write prt-line - a      from r153a-prt - 9 - a  after 2 lines.
                r153a_prt_9_a_grp = new string(' ', 8) + new string(' ', 35) + new string(' ', 20) + string.Format("{0:0,0.00}", r153a_p9_a_ytd);
                objPrint_file_a.prt_line_a = r153a_prt_9_a_grp;
                objPrtLineA.print(true);
                objPrtLineA.print(true);
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //write prt-line - a from r153a-prt - 10  after   2 lines.
            r153a_prt_10_grp = new string(' ', 8) + "A DETAILED LIST SHOWING EACH SERVICE FOR THE CURRENT MONTH IS MAILED".PadRight(68);
            objPrint_file_a.prt_line_a = r153a_prt_10_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-prt - 11  after   1 line.
            r153a_prt_11_grp = new string(' ', 8) + "TO YOUR OFFICE AT THE END OF EACH MONTH.  IF I CAN BE OF ANY ASSISTANCE,".PadRight(78);
            objPrint_file_a.prt_line_a = r153a_prt_11_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from r153a-prt - 12  after   1 line.
            r153a_prt_12_grp = new string(' ', 8) + "PLEASE CALL ME AT EXTENSION 2170 OR 525-9766.".PadRight(68);
            objPrint_file_a.prt_line_a = r153a_prt_12_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //if doc - full - part - ind = "P" then
            if (objF020_DOCTOR_MSTR.DOC_FULL_PART_IND.ToUpper().Equals("P")) {
                //    write prt - line - a from r153a-prt - 14   after    2 lines
                r153a_prt_14_grp = new string(' ', 20) + "G.S.T. INCLUDED, G.S.T. REGISTRATION NUMBER R104453774".PadRight(112);
                objPrint_file_a.prt_line_a = r153a_prt_14_grp;
                objPrtLineA.print(true);
                objPrtLineA.print(true);
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //if yearend - option = "Y" then
            if (yearend_option.ToUpper().Equals("Y")) {
                //   write prt - line - a from r153a-prt - 13   after    2 lines
                r153a_prt_13_grp = new string(' ', 20) + "FINAL YEAREND STATEMENT".PadRight(112);
                objPrint_file_a.prt_line_a = r153a_prt_13_grp;
                objPrtLineA.print(true);
                objPrtLineA.print(true);
                objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);
            }

            //add 1              to ctr-rpt - writes.
            ctr_rpt_writes_child++;

            //* update final statement totals

            //perform wa1a - add - misc       thru wa1a-99 - exit
            //               varying ss-misc
            //               from 1 by 1
            //               until ss-misc > 10.

            ss_misc = 1;
            do
            {
                wa1a_add_misc();
                wa1a_99_exit();
                ss_misc++;
            } while (ss_misc <= 10);

            //add ws - bill - gross(ss - mtd)      to ws-fin - bill - gross(ss - mtd).
            ws_fin_bill_gross_child[ss_mtd] = ws_fin_bill_gross_child[ss_mtd] + ws_bill_gross_child[ss_mtd];

            //add ws - bill - gross(ss - ytd)      to ws-fin - bill - gross(ss - ytd).
            ws_fin_bill_gross_child[ss_ytd] = ws_fin_bill_gross_child[ss_ytd] + ws_bill_gross_child[ss_ytd];

            //add ws - bill - net(ss - mtd)        to ws-fin - bill - net(ss - mtd).
            ws_fin_bill_net_child[ss_mtd] = ws_fin_bill_net_child[ss_mtd] + ws_bill_net_child[ss_mtd];

            //add ws - bill - net(ss - ytd)        to ws-fin - bill - net(ss - ytd).
            ws_fin_bill_net_child[ss_ytd] = ws_fin_bill_net_child[ss_ytd] + ws_bill_net_child[ss_ytd];

            //add ws - inc(ss - mtd)         to ws-fin - inc(ss - mtd).
            ws_fin_inc_child[ss_mtd] = ws_fin_inc_child[ss_mtd] + ws_inc[ss_mtd];
            //add ws - inc(ss - ytd)         to ws-fin - inc(ss - ytd).
            ws_fin_inc_child[ss_ytd] = ws_fin_inc_child[ss_ytd] + ws_inc[ss_ytd];


            //*following two stmts. added.may / 86  k.p.

            //add ws - exp - amt(ss - mtd)     to ws-fin - exp - amt(ss - mtd).
            ws_fin_exp_amt_child[ss_mtd] = ws_fin_exp_amt_child[ss_mtd] + ws_exp_amt_child[ss_mtd];

            //add ws - exp - amt(ss - ytd)     to ws-fin - exp - amt(ss - ytd).
            ws_fin_exp_amt_child[ss_ytd] = ws_fin_exp_amt_child[ss_ytd] + ws_exp_amt_child[ss_ytd];

            //add ws - ceil - amt(ss - mtd)        to ws-fin - ceil - amt(ss - mtd).
            ws_fin_ceil_amt_child[ss_mtd] = ws_fin_ceil_amt_child[ss_mtd] + ws_ceil_amt_child[ss_mtd];

            //add ws - ceil - amt(ss - ytd)        to ws-fin - ceil - amt(ss - ytd).
            ws_fin_ceil_amt_child[ss_ytd] = ws_fin_ceil_amt_child[ss_ytd] + ws_ceil_amt_child[ss_ytd];

            //add ws - pay - due(ss - mtd)     to ws-fin - pay - due(ss - mtd).
            ws_fin_pay_due_child[ss_mtd] = ws_fin_pay_due_child[ss_mtd] + ws_pay_due_child[ss_mtd];

            //add ws - pay - due(ss - ytd)     to ws-fin - pay - due(ss - ytd).
            ws_fin_pay_due_child[ss_ytd] = ws_fin_pay_due_child[ss_ytd] + ws_pay_due_child[ss_ytd];

            //add ws - tax(ss - mtd)         to ws-fin - tax(ss - mtd).
            ws_fin_tax_child[ss_mtd] = ws_fin_tax_child[ss_mtd] + ws_tax_child[ss_mtd];

            //add ws - tax(ss - ytd)         to ws-fin - tax(ss - ytd).
            ws_fin_tax_child[ss_ytd] = ws_fin_tax_child[ss_ytd] + ws_tax_child[ss_ytd];

            //add ws - bank - deposit(ss - mtd)    to ws-fin - deposit(ss - mtd).
            ws_fin_deposit_child[ss_mtd] = ws_fin_deposit_child[ss_mtd] + ws_bank_deposit_child[ss_mtd];

            //add ws - bank - deposit(ss - ytd)    to ws-fin - deposit(ss - ytd).
            ws_fin_deposit_child[ss_ytd] = ws_fin_deposit_child[ss_ytd] + ws_bank_deposit_child[ss_ytd];

            //add ws - manual - chqs(ss - mtd)    to ws-fin - man - chqs(ss - mtd).
            ws_fin_man_chqs_child[ss_mtd] = ws_fin_man_chqs_child[ss_mtd] + ws_manual_chqs_child[ss_mtd];

            //add ws - manual - chqs(ss - ytd)    to ws-fin - man - chqs(ss - ytd).
            ws_fin_man_chqs_child[ss_ytd] = ws_fin_man_chqs_child[ss_ytd] + ws_manual_chqs_child[ss_ytd];

            //* verify that statement totals agree

            //add ws-print - mtd - misc - total     to ws-bill - net(ss - mtd).
            ws_bill_net_child[ss_mtd] = ws_bill_net_child[ss_mtd] + ws_print_mtd_misc_total;

            //add ws - print - ytd - misc - total     to ws-bill - net(ss - ytd).
            ws_bill_net_child[ss_ytd] = ws_bill_net_child[ss_ytd] + ws_print_ytd_misc_total;

            //subtract ws-tax(ss - mtd)            from ws-pay - due(ss - mtd).
            ws_pay_due_child[ss_mtd] = ws_pay_due_child[ss_mtd] - ws_tax_child[ss_mtd];

            //subtract ws - tax(ss - ytd)            from ws-pay - due(ss - ytd).
            ws_pay_due_child[ss_ytd] = ws_pay_due_child[ss_ytd] - ws_tax_child[ss_ytd];
        }
        private   void wa1_99_exit()
        {
        }
        private   void wa1a_add_misc()
        {
            //add ws-misc - gross(ss - mtd, ss - misc)  to ws-fin - misc - gross(ss - mtd, ss - misc).
            ws_fin_misc_gross[ss_mtd, ss_misc] = ws_fin_misc_gross[ss_mtd, ss_misc] + ws_misc_gross_child[ss_mtd, ss_misc];

            //add ws - misc - gross(ss - ytd, ss - misc)  to ws-fin - misc - gross(ss - ytd, ss - misc).
            ws_fin_misc_gross[ss_ytd, ss_misc] = ws_fin_misc_gross[ss_ytd, ss_misc] + ws_misc_gross_child[ss_ytd, ss_misc];

            //add ws - misc - net(ss - mtd, ss - misc)        to ws-fin - misc - net(ss - mtd, ss - misc).
            ws_fin_misc_net_child[ss_mtd, ss_misc] = ws_fin_misc_net_child[ss_mtd, ss_misc] + ws_misc_net_child[ss_mtd, ss_misc];

            //add ws - misc - net(ss - ytd, ss - misc)        to ws-fin - misc - net(ss - ytd, ss - misc).
            ws_fin_misc_net_child[ss_ytd, ss_misc] = ws_fin_misc_net_child[ss_ytd, ss_misc] + ws_misc_net_child[ss_ytd, ss_misc];
        }
        private   void wa1a_99_exit()
        {
        }
        private   void wa2_print_misc()
        {
            //if ws - misc - net(ss - ytd, ss - misc) = zeroes then
            if (ws_misc_net_child[ss_ytd,ss_misc] == 0) {
                //   go to wa2-99 - exit.
                wa2_99_exit();
                return;
            }

            //if ctr - nbr - misc - lines = zeroes then
            if (ctr_nbr_misc_lines_child == 0) {
                //       move "$"            to r153a-p1 - lit - 1
                r153a_p1_lit_1_child = "$";
                //                              r153a - p1 - lit - 2
                r153a_p1_lit_2_child = "$";
                //                              r153a - p1 - lit - 3
                r153a_p1_lit_3_child = "$";
            }
            else {
                //       move spaces         to r153a-p1 - lit - 1
                r153a_p1_lit_1_child = string.Empty;
                //                              r153a - p1 - lit - 2
                r153a_p1_lit_2_child = string.Empty;
                //                              r153a - p1 - lit - 3.
                r153a_p1_lit_3_child = string.Empty;
            }

            //move chq-reg - mth - misc - amt(ss - chq, ss - misc)
            //        to r153a-p1 - gross.
            r153a_p1_gross_child = CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, ss_misc);

            //add chq - reg - mth - misc - amt(ss - chq, ss - misc)
            //        to ws-print - gross - misc - total.
            ws_print_gross_misc_total = ws_print_gross_misc_total + CHQ_REG_MTH_MISC_AMT(objF060_CHEQUE_REG_MSTR, ss_chq, ss_misc);

            //if ss - misc = 1 then
            if (ss_misc == 1) {
                //    multiply chq - reg - perc - misc(ss - chq) by 100
                //        giving ws-print - percent
                ws_print_percent = CHQ_REG_PERC_MISC(objF060_CHEQUE_REG_MSTR, ss_chq) * 100;
            }
            else {
                //    subtract 1          from ss-misc
                //                        giving ss-perc
                ss_perc = ss_misc - 1;

                //    multiply const-misc - curr(ss - perc) by   100
                //                 giving ws-print - percent.
                ws_print_percent = CONST_MISC_CURR(objConstants_Mstr_Rec_3, ss_perc) * 100;
            }

            //move ws-print - percent       to r153a-p1 - percent.
            r153a_p1_percent_child = ws_print_percent;

            //move ws - misc - net(ss - mtd, ss - misc)      to r153a-p1 - mtd.
            r153a_p1_mtd_child = ws_misc_net_child[ss_mtd, ss_misc];

            //add  ws - misc - net(ss - mtd, ss - misc)      to ws-print - mtd - misc - total.
            ws_print_mtd_misc_total = ws_print_mtd_misc_total + ws_misc_net_child[ss_mtd, ss_misc];

            //move ws - misc - net(ss - ytd, ss - misc)      to r153a-p1 - ytd.
            r153a_p1_ytd_child = ws_misc_net_child[ss_ytd, ss_misc];

            //add  ws - misc - net(ss - ytd, ss - misc)      to ws-print - ytd - misc - total.
            ws_print_ytd_misc_total = ws_print_ytd_misc_total + ws_misc_net_child[ss_ytd, ss_misc];

            //write prt - line - a from r153a-prt - 1   after   1 line.
            r153a_prt_1_grp = new string(' ', 6) + r153a_p1_lit_1_child + String.Format("{0:0,0.00}", r153a_p1_gross_child) + new string(' ', 1) + "MISC.INCOME @".PadRight(14) + String.Format("{0:0,0.00}", r153a_p1_percent_child) + "%" + new string(' ', 3)
                                                     + r153a_p1_lit_2_child + String.Format("{0:0,0.00}", r153a_p1_mtd_child) + new string(' ', 6) + r153a_p1_lit_3_child + String.Format("{0:0,0.00}", r153a_p1_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_1_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //add 1               to ctr-nbr - misc - lines.
            ctr_nbr_misc_lines_child++;

            //move spaces to  r153a - p1 - lit - 1
            r153a_p1_lit_1_child = string.Empty;
            //                r153a - p1 - lit - 2
            r153a_p1_lit_2_child = string.Empty;
            //                r153a - p1 - lit - 3.
            r153a_p1_lit_3_child = string.Empty;
        } 

        private   void wa2_99_exit()
        {
        }
        private   void wa3_print_totals()
        {
            //*print the pgm name at the upper left corner for the last page
            //* of the report r153a

            //write prt - line - a from r153a-head - first after page.  //TODO: After page
            r153a_head_first_grp = "R153A" + new string(' ', 127);
            objPrint_file_a.prt_line_a = r153a_head_first_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt - line - a from r153a-head - 3   after  2 lines.
            r153a_head_3_grp = "DATE:" + r153a_h3_yr_child.ToString() + "/" + r153a_h3_mth_child.ToString() + "/" + r153a_h3_day_child.ToString();
            objPrint_file_a.prt_line_a = r153a_head_3_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt - line - a from r153a-head - 4   after  2 lines.
            r153a_head_4_grp = new string(' ', 29) + "REGIONAL MEDICAL ASSOCIATES".PadRight(40);
            objPrint_file_a.prt_line_a = r153a_head_4_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt - line - a from r153a-tot - head after  2 lines.
            r153a_tot_head_grp = new string(' ', 20) + "***** STATEMENT OF EARNINGS FINAL TOTALS *****".PadRight(60);
            objPrint_file_a.prt_line_a = r153a_tot_head_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt - line - a from r153a-head - 6   after  3 lines.
            r153a_head_6_grp = new string(' ', 67) + "SINCE";
            objPrint_file_a.prt_line_a = r153a_head_6_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt - line - a from r153a-head - 7   after  1 line.
            r153a_head_7_grp = new string(' ', 45) + "THIS MONTH".PadRight(10) + new string(' ', 8) + "JULY 1, " + r153a_h7_yr_child.ToString();
            objPrint_file_a.prt_line_a = r153a_head_7_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt - line - a from blank-line     after  1 line.
            blank_line_grp = new string(' ', 132);
            objPrint_file_a.prt_line_a = blank_line_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move "$"                to  r153a - p1 - lit - 1
            r153a_p1_lit_1_child = "$";
            //                            r153a - p1 - lit - 2
            r153a_p1_lit_2_child = "$";
            //                            r153a - p1 - lit - 3.
            r153a_p1_lit_3_child = "$";

            //move 0              to  ws - print - gross - misc - total
            ws_print_gross_misc_total = 0;
            //                        ws - print - mtd - misc - total
            ws_print_mtd_misc_total = 0;
            //                        ws - print - ytd - misc - total.
            ws_print_ytd_misc_total = 0;

            //perform wa3a - print - misc     thru    wa3a - 99 - exit
            //                  varying ss - misc
            //                  from 1 by 1
            //                  until   ss - misc > 10.

            ss_misc = 1;
            do
            {
                wa3a_print_misc();
                wa3a_99_exit();
                ss_misc++;
            } while (ss_misc <= 10);

            //write prt - line - a from underscore-detail after 1 line.
            underscore_detail_grp = new string(' ', 6) + "-----------" + new string(' ', 26) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_detail_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws - print - gross - misc - total  to  r153a - p2 - gross.
            r153a_p2_gross_child = ws_print_gross_misc_total;

            //move ws - print - mtd - misc - total    to  r153a - p2 - mtd.
            r153a_p2_mtd_child = ws_print_mtd_misc_total;

            //move ws - print - ytd - misc - total    to  r153a - p2 - ytd.
            r153a_p2_ytd_child = ws_print_ytd_misc_total;

            //write prt - line - a from r153a-prt - 2   after   1 line.
            r153a_prt_2_grp = new string(' ', 6) + "$" + String.Format("{0:0,0.00}", r153a_p2_gross_child) + new string(' ', 2) + "TOTAL MISC. INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p2_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p2_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_2_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move "PLUS"             to  r153a - p3 - plus - lit.
            r153a_p3_plus_lit_child = "PLUS";
            //move spaces             to  r153a - p3 - lit - 2
            r153a_p3_lit_2_child = string.Empty;
            //                            r153a - p3 - lit - 3.
            r153a_p3_lit_3_child = string.Empty;

            //move ws - fin - bill - gross(ss - mtd)     to  r153a - p3 - gross.
            r153a_p3_gross_child = ws_fin_bill_gross_child[ss_mtd];

            //move spaces             to  r153a - p3 - percent - r.
            r153a_p3_percent_r_child_redefine = string.Empty;

            //move ws - fin - bill - net(ss - mtd)       to  r153a - p3 - mtd.
            r153a_p3_mtd_child = ws_fin_bill_net_child[ss_mtd];

            //move ws - fin - bill - net(ss - ytd)       to  r153a - p3 - ytd.
            r153a_p3_ytd_child = Util.Str(ws_fin_bill_net_child[ss_ytd]);

            //write prt - line - a from r153a-prt - 3   after   1 line.
            r153a_prt_3_grp = new string(' ', 2) + Util.Str(r153a_p3_plus_lit_child).PadRight(6) + new string(' ', 5) + Util.Str(r153a_p3_lit_1_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_gross_child) + " " + "BILLINGS    @ " + string.Format("{0:0,0.00}", r153a_p3_percent_child) + "%" + new string(' ', 3) + Util.Str(r153a_p3_lit_2_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_mtd_child) + new string(' ', 6) + Util.Str(r153a_p3_lit_3_child).PadRight(1) + string.Format("{0:0,0.00}", r153a_p3_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_3_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //*following two stmts. added may/ 85  k.p.

            //move ws - fin - exp - amt(ss - mtd)    to r153a-p3 - a - mtd.
            r153a_p3_a_mtd_child = ws_fin_exp_amt_child[ss_mtd];

            //move ws - fin - exp - amt(ss - ytd)    to r153a-p3 - a - ytd.
            r153a_p3_a_ytd_child = ws_fin_exp_amt_child[ss_ytd];

            //write prt - line - a from r153a-prt - 3 - a after   1 line.
            r153a_prt_3_a_grp = new string(' ', 20) + "LESS FACULTY EXPENSE".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p3_a_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p3_a_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_3_a_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from underscore-total after   1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-fin - inc(ss - mtd)        to r153a-p4 - mtd.
            r153a_p4_mtd_child = ws_fin_inc_child[ss_mtd];

            //move ws - fin - inc(ss - ytd)        to r153a-p4 - ytd.
            r153a_p4_ytd_child = ws_fin_inc_child[ss_ytd];

            //write prt - line - a from r153a-prt - 4   after   1 line.
            r153a_prt_4_grp = new string(' ', 20) + "TOTAL INCOME".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p4_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p4_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_4_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-fin - ceil - amt(ss - mtd)   to r153a-p5 - mtd.
            r153a_p5_mtd_child = ws_fin_ceil_amt_child[ss_mtd];

            //move ws - fin - ceil - amt(ss - ytd)   to r153a-p5 - ytd.
            r153a_p5_ytd_child = ws_fin_ceil_amt_child[ss_ytd];

            //write prt - line - a from r153a-prt - 5   after   2 lines.
            r153a_prt_5_grp = new string(' ', 20) + "CEILING IS".PadRight(23) + "$" + string.Format("{0:0,0.00}", r153a_p5_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p5_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_5_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-fin - pay - due(ss - mtd)    to r153a-p6 - mtd.
            r153a_p6_mtd_child = ws_fin_pay_due_child[ss_mtd];

            //move ws - fin - pay - due(ss - ytd)    to r153a-p6 - ytd.
            r153a_p6_ytd_child = Util.Str(ws_fin_pay_due_child[ss_ytd]);

            //write prt - line - a from r153a-prt - 6   after   5 lines.
            r153a_prt_6_grp = new string(' ', 8) + "PAYMENT DUE".PadRight(35) + "$" + string.Format("{0:0,0.00}", r153a_p6_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p6_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_6_grp;
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(true);
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-fin - tax(ss - mtd)        to r153a-p7 - mtd.
            r153a_p7_mtd_child = ws_fin_tax_child[ss_mtd];

            //move ws - fin - tax(ss - ytd)        to r153a-p7 - ytd.
            r153a_p7_ytd_child = Util.Str(ws_fin_tax_child[ss_ytd]);

            //write prt - line - a from r153a-prt - 7   after   1 line.
            r153a_prt_7_grp = new string(' ', 8) + "LESS INCOME TAX".PadRight(34) + "(" + string.Format("{0:0,0.00}", r153a_p7_mtd_child) + ")" + "(" + string.Format("{0:0,0.00}", r153a_p7_ytd_child) + ")";
            objPrint_file_a.prt_line_a = r153a_prt_7_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from underscore-total after   1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-fin - deposit(ss - mtd)    to r153a-p8 - mtd.
            r153a_p8_mtd_child = ws_fin_deposit_child[ss_mtd];

            //move ws - fin - deposit(ss - ytd)    to r153a-p8 - ytd.
            r153a_p8_ytd_child = ws_fin_deposit_child[ss_ytd];

            //write prt - line - a from r153a-prt - 8   after   1 line.
            r153a_prt_8_grp = new string(' ', 8) + "AUTOMATIC BANK DEPOSIT ON ".PadRight(26) + r153a_p8_yr_child.ToString() + "/" + r153a_p8_mth_child.ToString() + "/" + r153a_p8_day_child.ToString() + " $" + string.Format("{0:0,0.00}", r153a_p8_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p8_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_8_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move ws-fin - man - chqs(ss - mtd)    to r153a-p9 - mtd.
            r153a_p9_mtd_child = ws_fin_man_chqs_child[ss_mtd];

            //move ws - fin - man - chqs(ss - ytd)    to r153a-p9 - ytd.
            r153a_p9_ytd_child = ws_fin_man_chqs_child[ss_ytd];

            //write prt - line - a from r153a-prt - 9   after   1 line.
            r153a_prt_9_grp = new string(' ', 8) + Util.Str(yearend_label_child).PadRight(35) + "$" + string.Format("{0:0,0.00}", r153a_p9_mtd_child) + new string(' ', 6) + "$" + string.Format("{0:0,0.00}", r153a_p9_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_9_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //write prt-line - a from underscore-total after   1 line.
            underscore_total_grp = new string(' ', 43) + "------------" + new string(' ', 7) + "-------------";
            objPrint_file_a.prt_line_a = underscore_total_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //add ws-print - mtd - misc - total     to ws-fin - bill - net(ss - mtd).
            ws_fin_bill_net_child[ss_mtd] = ws_fin_bill_net_child[ss_mtd] + ws_print_mtd_misc_total;

            //add ws - print - ytd - misc - total     to ws-fin - bill - net(ss - ytd).
            ws_fin_bill_net_child[ss_ytd] = ws_fin_bill_net_child[ss_ytd] + ws_print_ytd_misc_total;

            //subtract ws-fin - tax(ss - mtd)   from ws-fin - pay - due(ss - mtd).
            ws_fin_pay_due_child[ss_mtd] = ws_fin_pay_due_child[ss_mtd] - ws_fin_tax_child[ss_mtd];

            //subtract ws - fin - tax(ss - ytd)    from ws-fin - pay - due(ss - ytd).
            ws_fin_pay_due_child[ss_ytd] = ws_fin_pay_due_child[ss_ytd] - ws_fin_tax_child[ss_ytd];
          }
        private   void wa3_99_exit()
        {
        }
        private   void wa3a_print_misc()
        {
            //move ws-fin - misc - gross(ss - mtd, ss - misc) to r153a-p1 - gross.
            r153a_p1_gross_child = ws_fin_misc_gross[ss_mtd, ss_misc];

            //if ss - misc = 1 then
            if (ss_misc == 1) {
                //     move spaces to  r153a - p1 - percent - r
                r153a_p1_percent_r_child_redefine = string.Empty;
            }
            else {
                //    subtract 1          from ss-misc
                //                        giving ss-perc
                ss_perc = ss_misc - 1;

                //    multiply const-misc - curr(ss - perc) by   100
                //                       giving ws-print - percent
                ws_print_percent = CONST_MISC_CURR(objConstants_Mstr_Rec_3, ss_perc) * 100;

                //    move ws-print - percent          to r153a-p1 - percent.
                r153a_p1_percent_child = ws_print_percent;
            }

            //move ws-fin - misc - net(ss - mtd, ss - misc)  to r153a-p1 - mtd.
            r153a_p1_mtd_child = ws_fin_misc_net_child[ss_mtd, ss_misc];

            //move ws - fin - misc - net(ss - ytd, ss - misc)  to r153a-p1 - ytd.
            r153a_p1_ytd_child = ws_fin_misc_net_child[ss_ytd, ss_misc];

            //write prt - line - a from r153a-prt - 1   after   1 line.
            r153a_prt_1_grp = new string(' ', 6) + r153a_p1_lit_1_child + String.Format("{0:0,0.00}", r153a_p1_gross_child) + new string(' ', 1) + "MISC.INCOME @".PadRight(14) + String.Format("{0:0,0.00}", r153a_p1_percent_child) + "%" + new string(' ', 3)
                                                     + r153a_p1_lit_2_child + String.Format("{0:0,0.00}", r153a_p1_mtd_child) + new string(' ', 6) + r153a_p1_lit_3_child + String.Format("{0:0,0.00}", r153a_p1_ytd_child);
            objPrint_file_a.prt_line_a = r153a_prt_1_grp;
            objPrtLineA.print(objPrint_file_a.prt_line_a, 1, true);

            //move spaces             to r153a-p1 - lit - 1
            r153a_p1_lit_1_child = string.Empty;
            //                           r153a - p1 - lit - 2
            r153a_p1_lit_2_child = string.Empty;
            //                           r153a - p1 - lit - 3.
            r153a_p1_lit_3_child = string.Empty;

            //add ws - fin - misc - gross(ss - mtd, ss - misc) to ws-print - gross - misc - total.
            ws_print_gross_misc_total = ws_print_gross_misc_total + ws_fin_misc_gross[ss_mtd, ss_misc];

            //add ws - fin - misc - net(ss - mtd, ss - misc)   to ws-print - mtd - misc - total.
            ws_print_mtd_misc_total = ws_print_mtd_misc_total + ws_fin_misc_net_child[ss_mtd, ss_misc];

            //add ws - fin - misc - net(ss - ytd, ss - misc)   to ws-print - ytd - misc - total.
            ws_print_ytd_misc_total = ws_print_ytd_misc_total + ws_fin_misc_net_child[ss_ytd, ss_misc];
        }
        private   void wa3a_99_exit()
        {
        }
        private   void xa0_read_u119_build_f060()
        {
            //*(zero f060 cheque reg before moving in u119 values) 

            //move zeros              to cheque-reg - rec.
            objF060_CHEQUE_REG_MSTR = new F060_CHEQUE_REG_MSTR();

            //perform xb1 - zero - chq        thru xb1-99 - exit.
            xb1_zero_chq();
            xb1_99_exit();

            //read u119 - chgeft - file
            //            at end
            //            move "Y"         to eof-u119 - chgeft - file
            //            move "Y"         to eof-chq - reg - mstr
            //            go to xa0 - 99 - exit.

            U119_chgeft_rec_Collection = new ObservableCollection<U119_chgeft_rec>();  //TODO: Not sure where the data came from on this??

            if (U119_chgeft_rec_Collection.Count == 0)                           /// Todo: make a reqd sequential on this colleciton.
            {
                //            move "Y"         to eof-u119 - chgeft - file
                eof_u119_chgeft_file = "Y";
                //            move "Y"         to eof-chq - reg - mstr
                eof_chq_reg_mstr = "Y";
                //            go to xa0 - 99 - exit.
                xa0_99_exit();
                return;
            }
            else
            {
                if (ctr_u119_chgeft_reads_child >= U119_chgeft_rec_Collection.Count())
                {
                    //            move "Y"         to eof-u119 - chgeft - file
                    eof_u119_chgeft_file = "Y";
                    //            move "Y"         to eof-chq - reg - mstr
                    eof_chq_reg_mstr = "Y";
                    //            go to xa0 - 99 - exit.
                    xa0_99_exit();
                    return;
                }
                else
                {
                    var ctr = 0;
                    foreach (U119_chgeft_rec obj in U119_chgeft_rec_Collection)
                    {
                        if (ctr == ctr_u119_chgeft_reads_child)
                        {
                            objU119_chgeft_rec = obj;
                            //add 1               to ctr-u119 - chgeft - reads.
                            ctr_u119_chgeft_reads_child++;
                            break;
                        }
                        ctr++;
                    }
                }

                //move 0              to n-doc - dept.
                n_doc_dept = 0;

                //move w - doc - dept         to n-doc - dept.
                n_doc_dept = objU119_chgeft_rec.w_doc_dept;

                //move spaces             to n-doc - nbr.
                n_doc_nbr = string.Empty;

                //move w-doc - nbr          to n-doc - nbr.
                n_doc_nbr = objU119_chgeft_rec.w_doc_nbr;

                //move 0                  to n-chgeft - amt - n.
                n_chgeft_amt_n = 0;

                //move w - chgeft - amt - n         to n-chgeft - amt - n.
                n_chgeft_amt_n = objU119_chgeft_rec.w_chgeft_amt_n;

                //move sel-clinic         to chq-reg - clinic - nbr - 1 - 2.
                objF060_CHEQUE_REG_MSTR.CHQ_REG_CLINIC_NBR_1_2 = Util.NumDec(sel_clinic);

                //move n - doc - dept                     to chq-reg - dept.
                objF060_CHEQUE_REG_MSTR.CHQ_REG_DEPT = n_doc_dept;

                //move n - doc - nbr                      to chq-reg - doc - nbr.
                objF060_CHEQUE_REG_MSTR.CHQ_REG_DOC_NBR = n_doc_nbr;

                //move n - chgeft - amt - n
                //                         to chq-reg - regular - pay - this - mth(ss - chq).
                CHQ_REG_REGULAR_TAX_THIS_MTH_SET(objF060_CHEQUE_REG_MSTR, ss_chq, n_chgeft_amt_n);
            }
        }
        private   void xa0_99_exit()
        {
        }
        private   void xb1_zero_chq()
        {
            //move 0  to chq-reg - perc - bill(ss - chq).
            CHQ_REG_PERC_BILL_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - perc - misc(ss - chq).
            CHQ_REG_PERC_MISC_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - pay - code(ss - chq).
            CHQ_REG_PAY_CODE_SET(objF060_CHEQUE_REG_MSTR, ss_chq, "0");

            //move 0  to chq-reg - perc - tax(ss - chq).
            CHQ_REG_PERC_TAX_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - mth - bill - amt(ss - chq).
            CHQ_REG_MTH_BILL_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 1)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 1, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 2)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 2, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 3)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 3, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 4)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 4, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 5)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 5, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 6)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 6, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 7)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 7, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 8)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 8, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 9)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 9, 0);

            //move 0  to chq-reg - mth - misc - amt(ss - chq, 10)
            CHQ_REG_MTH_MISC_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 10, 0);

            //move 0  to chq-reg - mth - exp - amt(ss - chq).
            CHQ_REG_MTH_EXP_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - comp - ann - exp - this - pay(ss - chq).
            CHQ_REG_COMP_ANN_EXP_THIS_PAY_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - mth - ceil - amt(ss - chq).
            CHQ_REG_MTH_CEIL_AMT_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - comp - ann - ceil - this - pay(ss - chq).
            CHQ_REG_COMP_ANN_CEIL_THIS_PAY_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - earnings - this - mth(ss - chq).
            CHQ_REG_EARNINGS_THIS_MTH_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - regular - pay - this - mth(ss - chq).
            CHQ_REG_REGULAR_PAY_THIS_MTH_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - regular - tax - this - mth(ss - chq).
            CHQ_REG_REGULAR_TAX_THIS_MTH_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - man - pay - this - mth(ss - chq).
            CHQ_REG_MAN_PAY_THIS_MTH_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - man - tax - this - mth(ss - chq).
            CHQ_REG_MAN_TAX_THIS_MTH_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);

            //move 0  to chq-reg - pay - date(ss - chq).
            CHQ_REG_PAY_DATE_SET(objF060_CHEQUE_REG_MSTR, ss_chq, 0);
        }
        private   void xb1_99_exit()
        {
        }
        private   void za0_common_error()
        {
            // move err-msg(err - ind)      to err-msg - comment.
            err_msg_comment = err_msg_child[err_ind];

            // display err - msg - comment.
            Console.WriteLine(err_msg_comment);
        }
        private   void za0_99_exit()
        {
        }
      // copy "y2k_default_sysdate_century.rtn".
        private   void y2k_default_sysdate()
        {
            //move sys-date - left                  to sys-date - temp.
            sys_date_temp = sys_date_left_child;

            //move sys - date - temp                  to sys-date - right.
            sys_date_right_child = sys_date_temp;

            //move zeros to sys - date - blank.
            sys_date_blank_child = "0";

            //add 20000000                        to sys-date - numeric. 
            sys_date_numeric_redefines = sys_date_numeric_redefines + 20000000;
        }
        private   void y2k_default_sysdate_exit()
        {
        }
    }
}
