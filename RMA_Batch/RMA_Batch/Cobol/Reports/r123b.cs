using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using rma.Cobol;
using RmaDAL;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.IO;

namespace rma.Cobol.Reports
{
    public class R123b : CommonFunction
    {

        //copy "f090_constants_mstr.slr". 
        private ICONST_MSTR_REC objICONST_MSTR_REC = null;
        private ObservableCollection<ICONST_MSTR_REC> ICONST_MSTR_REC_Collection;

        //copy "f090_const_mstr_rec_3.ws".
        private CONSTANTS_MSTR_REC_3 objCONSTANTS_MSTR_REC_3 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_3> CONSTANTS_MSTR_REC_3_Collection;

        //select eft-logical-rec-file
        //      assign to ws-work-file-a
        //      organization is sequential.

        //fd eft-logical-rec-file
        private Eft_record_type_a objEft_record_type_a = null;
        private ObservableCollection<Eft_record_type_a> Eft_record_type_a_Collection;

        private Eft_record_type_c objEft_record_type_c = null;
        private ObservableCollection<Eft_record_type_c> Eft_record_type_c_Collection;

        private Eft_record_type_z objEft_record_type_z = null;
        private ObservableCollection<Eft_record_type_z> Eft_record_type_z_Collection;

        private Output_record objOutput_record = null;
        private ObservableCollection<Output_record> Output_record_Collection;

        private WriteFile objOutPut_File = null;


        //77  sel-clinic pic 99		value zeroes.
        private int sel_clinic;

        //77  err-ind pic 99 		value zeroes. 
        private int err_ind;

        //77  common-status-file pic x(2)       value zero.
        private string common_status_file;

        //77  status-iconst-mstr pic x(11)       value spaces.
        private string status_iconst_mstr;

        //77  status-cobol-iconst-mstr pic xx value zero.
        private string status_cobol_iconst_mstr;

        //77   ws-work-file-a pic x(11)       value "work_file_a". 
        private string ws_work_file_a = "work_file_a";
        //77   ws-sorted-file pic x(11)       value "sorted_file". 
        private string ws_sorted_file = "sorted_file";
        //77   ws-output-file pic x(8)        value "eft_tape". 
        private string ws_output_file = "eft_tape";

        // 01  month-descs-and-max-days-mth.
        private string month_descs_and_max_days_mth_grp;
        //05  mth-desc-max-days.
        private string mth_desc_max_days_grp_child = "31  JANUARY031" + "29 FEBRUARY059" + "31    MARCH090" + "30    APRIL120" + "31      MAY151" + "30     JUNE181" + "31     JULY212" + "31   AUGUST243" + "30SEPTEMBER273" + "31  OCTOBER304" + "30 NOVEMBER334" + "31 DECEMBER365";

        //   05  mth-desc-max-days-r redefines mth-desc-max-days.
        private string mth_desc_max_days_r_child_redefines;  // = mth_desc_max_days_grp_child;
        // 10  mth-desc-max-days-occur occurs  12  times.
        private string[] mth_desc_max_days_occur_grp_child = new string[12];
        //15  max-nbr-days pic 99.  
        private int[] max_nbr_days = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        //15  mth-desc pic x(9).  
        private string[] mth_desc_child = { "", "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
        //15  nbr-julian-days-ytd pic 9(3).  
        private int[] nbr_julian_days_ytd_child = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

        //01  error-message-table.
        private string error_message_table_grp;

        //05  error-messages.
	    //    10  filler pic x(60)   value  "INVALID CLINIC NUMBER". 
        private string [] error_messages = {"", "INVALID CLINIC NUMBER"};
		
        //05  error-messages-r redefines error-messages.
        //    10  err-msg pic x(60) occurs 1 times.
         private string[] err_msg =  {"", "INVALID CLINIC NUMBER"};

        //01  err-msg-comment pic x(60). 
        private string err_msg_comment;

        private string endOfJob = "End of Job";

        //Parameters
        private int prm_sel_clinic;

        public R123b(string Name, int Level):base(Name,Level)
        {
            this.ScreenType = ScreenTypes.QTP;
        }

        public bool MainLine(int selClinic)
        {
            try {
                prm_sel_clinic = selClinic;

                objICONST_MSTR_REC = null;
                objICONST_MSTR_REC = new ICONST_MSTR_REC();

                ICONST_MSTR_REC_Collection = null;
                ICONST_MSTR_REC_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objOutput_record = null;
                objOutput_record = new Output_record();
                Output_record_Collection = new ObservableCollection<Output_record>();

                objOutPut_File = null;
                objOutPut_File = new WriteFile(Directory.GetCurrentDirectory() + "\\" + ws_output_file + ".txt", true);

                //perform aa0-initialization          thru aa0-99 - exit.
                aa0_initialization();
                aa0_10_clinic();
                aa0_99_exit();

                //perform ab3 - sort - eft - record         thru ab3-99 - exit.
                ab3_sort_eft_record();
                ab3_99_exit();

                //perform az0 - end - of - job          thru az0-99 - exit.
                az0_end_of_job();
                za0_99_exit();

                //stop run.
            } catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            return true;
        }

        private void aa0_initialization()
        {
            //accept sys-date         from date.
            sys_date_grp = DateTime.Now.ToString();
            sys_date_long_child = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy_child = DateTime.Now.Year;
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1_child = Util.NumInt(DateTime.Now.Year.ToString().Substring(0, 1));
            sys_y2_child = Util.NumInt(DateTime.Now.Year.ToString().Substring(1, 1));
            sys_y3_child = Util.NumInt(DateTime.Now.Year.ToString().Substring(2, 1));
            sys_y4_child = Util.NumInt(DateTime.Now.Year.ToString().Substring(3, 1));
            sys_mm_child = DateTime.Now.Month;
            sys_dd_child = DateTime.Now.Day;

            //perform y2k-default- sysdate     thru y2k-default- sysdate - exit.
            y2k_default_sysdate();
            y2k_default_sysdate_exit();
        }

        private void aa0_10_clinic()
        {
            //accept sel-clinic.
            sel_clinic = prm_sel_clinic;
            //move sel - clinic         to iconst-clinic - nbr - 1 - 2.

            ICONST_MSTR_REC_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = sel_clinic
            }.Collection();

            objICONST_MSTR_REC = ICONST_MSTR_REC_Collection.FirstOrDefault() ?? new ICONST_MSTR_REC();

            /*read iconst-mstr
                invalid key
                    move 1              to err-ind
                    perform za0-common - error    thru za0-99 - exit
                    go to aa0 - 10 - clinic. */

            if (ICONST_MSTR_REC_Collection.Count == 0)
            {
                err_ind = 1;
                za0_common_error();
                za0_99_exit();
                //aa0_10_clinic();
                //return;
                throw new Exception(endOfJob);
            }
        }

        private void aa0_99_exit()
        {
        }

        private void ab3_sort_eft_record()
        {
            /* sort sorted-file
                 on ascending key s-record - type,
                                       s - record - count,
                                       s - x -ref-nbr
                 using    eft - logical - rec - file
                 giving output-file. */

            Eft_record_type_a_Collection = Read_Workfile_a_SequentialFile();

            foreach (var obj in Eft_record_type_a_Collection.OrderBy(a => a.a_01_record_type).OrderBy(b => b.a_02_record_count).OrderBy(c => c.a_03_originator_number))
            {
                if (obj.a_01_record_type.ToUpper().Equals("A"))
                {
                    Eft_record_type_a objEft_record_type_a = obj;
                    objOutput_record.OutPut_Record = Util.Str(objEft_record_type_a.a_01_record_type).PadRight(1, ' ') +
                             objEft_record_type_a.a_02_record_count.ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.a_03_originator_number).PadRight(10, ' ') +
                             objEft_record_type_a.a_04_file_creation_number.ToString().PadLeft(4, '0') +
                             objEft_record_type_a.a_05_creation_date.ToString().PadLeft(6, '0') +
                             objEft_record_type_a.a_06_destination_data_centre.ToString().PadLeft(5, '0') +
                             Util.Str(objEft_record_type_a.a_07_filler).PadRight(1213, ' ') +
                             objEft_record_type_a.a_08_version_number.ToString().PadLeft(4, '0') +
                             objEft_record_type_a.a_09_settlement_account.ToString().PadLeft(2, '0') +
                             objEft_record_type_a.institution_id_child[1].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[1]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[2].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[2]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[3].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[3]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[4].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[4]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[5].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[5]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[6].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[6]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[7].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[7]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[8].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[8]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[9].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[9]).PadRight(12, ' ') +
                             objEft_record_type_a.institution_id_child[10].ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_a.settlement_account_child[10]).PadRight(12, ' ');
                }
                else if (obj.a_01_record_type.ToUpper().Equals("C"))
                {
                    Eft_record_type_c objEft_record_type_c = obj.eft_record_type_c_Reference as Eft_record_type_c;

                    objOutput_record.OutPut_Record = Util.Str(objEft_record_type_c.c_01_record_type).PadRight(1, ' ') +
                             objEft_record_type_c.c_02_record_count.ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_c.c_03_originator_nbr).PadRight(10, ' ') +
                             objEft_record_type_c.c_03_file_creation_nbr.ToString().PadLeft(4, '0') +
                             objEft_record_type_c.c_04_transaction_type.ToString().PadLeft(3, '0') +
                             objEft_record_type_c.c_05_amount.ToString().PadLeft(10, '0') +   // 9(8)v99
                             objEft_record_type_c.c_06_fund_available_date.ToString().PadLeft(6, '0') +
                             objEft_record_type_c.c_07_bank_nbr.ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_c.c_08_payee_acc_nbr).PadRight(12, ' ') +
                             Util.Str(objEft_record_type_c.c_09_reserved).PadRight(22, ' ') +
                             objEft_record_type_c.c_10_stored_trans_type.ToString().PadLeft(3, '0') +
                             Util.Str(objEft_record_type_c.c_11_short_name).PadRight(15, ' ') +
                             Util.Str(objEft_record_type_c.c_12_payee_name).PadRight(30, ' ') +
                             Util.Str(objEft_record_type_c.c_13_long_name).PadRight(30, ' ') +
                             Util.Str(objEft_record_type_c.c_14_originator_nbr).PadRight(10, ' ') +
                             Util.Str(objEft_record_type_c.c_15_cross_ref_nbr).PadRight(19, ' ') +
                             objEft_record_type_c.c_16_institution_return.ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_c.c_17_account_return).PadRight(12, ' ') +
                             Util.Str(objEft_record_type_c.c_18_sundry).PadRight(15, ' ') +
                             Util.Str(objEft_record_type_c.c_19_filler).PadRight(22, ' ') +
                             objEft_record_type_c.c_20_settlement_indicator.ToString().PadLeft(2, '0') +
                             objEft_record_type_c.c_21_invalid_indicator.ToString().PadLeft(11, '0') +
                             Util.Str(objEft_record_type_c.c_seg_two_six).PadRight(1200, ' ');
                }
                else if (obj.a_01_record_type.ToUpper().Equals("Z"))
                {
                    Eft_record_type_z objEft_record_type_z = obj.eft_record_type_z_Reference as Eft_record_type_z;

                    objOutput_record.OutPut_Record = Util.Str(objEft_record_type_z.z_01_record_type).PadRight(1, ' ') +
                             objEft_record_type_z.z_02_record_count.ToString().PadLeft(9, '0') +
                             Util.Str(objEft_record_type_z.z_03_originator_nbr).PadRight(10, ' ') +
                             objEft_record_type_z.z_03_file_creation_number.ToString().PadLeft(4, '0') +
                             objEft_record_type_z.z_04_total_debit_value.ToString().PadLeft(14, '0') +  // 9(12)v99
                             objEft_record_type_z.z_05_total_debit_nbr.ToString().PadLeft(8, '0') +
                             objEft_record_type_z.z_06_total_credit_value.ToString().PadLeft(14, '0') + // 9(12)v99
                             objEft_record_type_z.z_07_total_credit_nbr.ToString().PadLeft(8, '0') +
                             Util.Str(objEft_record_type_z.z_08_filler).PadRight(1396, ' ');
                }

                objOutPut_File.AppendOutputFile(objOutput_record.OutPut_Record, false);
            }
        }

        private void ab3_99_exit()
        {

        }
        private void az0_end_of_job()
        {
            //accept sys-time         from time.
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs_child = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min_child = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec_child = Convert.ToInt32(DateTime.Now.ToString("ss"));

            // stop run.
        }
        private void az0_99_exit()
        {
        }
        private void za0_common_error()
        {
            //move err-msg(err - ind)      to err-msg - comment.
            err_msg_comment = err_msg[err_ind];

            //display err - msg - comment.
            Console.WriteLine(err_msg_comment);
        }
        private void za0_99_exit()
        {
        }

        //copy "y2k_default_sysdate_century.rtn".
        private void y2k_default_sysdate()
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

        private void y2k_default_sysdate_exit()
        {

        }
    }
}
