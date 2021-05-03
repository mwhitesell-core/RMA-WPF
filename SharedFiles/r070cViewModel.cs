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
using System.Diagnostics;

namespace rma.Views
{
    public class R070cViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private ReportPrint objPrt_line = null;
        private ObservableCollection<Prt_line> Prt_line_Collection;

        // FD: param_file	Copy : r070_param_file.fd
        private Param_file_rec objParam_file_rec = null;
        private ObservableCollection<Param_file_rec> Param_file_rec_Collection;

        // FD: claims_work_mstr	Copy : r070_claims_work_mstr.fd
        private Claims_work_rec objClaims_work_rec = null;
        private ObservableCollection<Claims_work_rec> Claims_work_rec_Collection;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int pat_occur;
        private string common_status_file = "0";
        private string status_cobol_claims_work_mstr = "0";
        private string status_cobol_param_file = "0";
        private string status_prt_file = "0";
        private int err_ind = 0;
        private string header_done = "N";
        private string eof_work_mstr = "N";
        private string totals_written = "N";
        private string display_key_type;
        private string flag;
        private string ok;
        private string not_ok;
        private string error_flag = "N";
        private int i;
        private int record_status;
        private int line_cnt = 0;
        private int page_cnt = 0;
        private string ws_reply;
        private string ws_date_reply;
        private decimal dept_tot_amount;
        private decimal balance_due;
        private int write_off_nbr_of_clms;
        private decimal write_off_totals;
        private decimal current_tot;
        private decimal _30_day_tot;
        private decimal _60_day_tot;
        private decimal _90_day_tot;
        private decimal _120_day_tot;
        private decimal _150_day_tot;
        private decimal _180_day_tot;
        private int current_nbr_of_clms;
        private int _30_day_nbr_of_clms;
        private int _60_day_nbr_of_clms;
        private int _90_day_nbr_of_clms;
        private int _120_day_nbr_of_clms;
        private int _150_day_nbr_of_clms;
        private int _180_day_nbr_of_clms;
        private decimal final_ohip_fee;
        private decimal final_amt_paid;
        private decimal final_bal_due;
        private decimal total_ohip_fee;
        private decimal total_bal_due;
        private decimal total_amt_paid;
        private decimal total_amount;
        private int total_nbr_of_clms;
        private decimal[] final_grand_amount = new decimal[12];
        private int[] final_grand_nbr_of_clms = new int[12];
        private decimal grand_amount;
        private int grand_nbr_of_clms;
        private int tp_sub_nbr;

        private string sub_total_table_grp;
        private decimal[] sub_tot = new decimal[100];

        private string dept_total_table_grp;
        private decimal[] dept_tot = new decimal[100];
        private string blank_line = "";
        private int hold_ws_age_category;
        private int save_agent_cd;

        private string work_file_name_grp;
        private string filler = "r070_srt_work_mstr_";
        private string work_file_clinic_nbr;

        private string param_file_name_grp;
        //private string filler = "r070_par_file";

        private string print_file_name_grp;
        private string printer_file_name = "r070_";
        private string print_file_nbr;

        private string counters_grp;
        private int ctr_claims_work_mstr_reads;
        private int ctr_detail_lines_writes;
        private int ctr_param_file_reads;

        private string test_date_grp;
        private int test_date_yy;
        private int test_date_mm;
        private int test_date_dd;

        //private string head_line_1_grp;
        //private string filler = "r070  /";
        private int h1_clinic_nbr;
        //private string filler = "";
        private string h1_month;
        //private string filler = space;
        private int h1_day;
        //private string filler = ", ";
        private int h1_year;
        //private string filler = "";
        //private string filler = "* ACCOUNTS RECEIVABLE TRIAL BALANCE *";
        //private string filler = "";
        //private string filler = "RUN DATE ";
        private string header_date;
        //private string filler = "";
        //private string filler = "page ";
        private int h1_page;

        //private string head_line_2_grp;
        //private string filler = "";
        private string h2_clinic;
        //private string filler = "";

        //private string head_line_3_grp;
        //private string filler = " AGENT ";
        private string h3_agent;
        //private string filler = "";
        private string h3_title;
        //private string filler = "";

        //private string head_line_4_grp;
        //private string filler = "  PATIENT   PATIENT ID/    CLAIM   ";
        //private string filler = "    OH SUB    OMA        OHIP     A";
        //private string filler = "MOUNT    BALANCE   PERIOD   SERVICE";
        //private string filler = " DAY  BATCH   TAPE ACTION  ";

        //private string head_line_5_grp;
        //private string filler = "  ACRONYM   CHART NUMBER   NUMBER/D";
        //private string filler = "EPT IP NBR    FEE        FEE       ";
        //private string filler = "PAID       DUE      DATE     DATE  ";
        //private string filler = " OLD  NUMBER  SUB  TAKEN   ";

        //private string head_line_6_grp;
        //private string filler = "";
        //private string filler = "AGE CATEGORY      AMOUNT        #OF CLAIMS";
        //private string filler = "";

        //private string head_line_7_grp;
        //private string filler = "departmental summary";
        //private string filler = "";

        //private string head_line_8_grp;
        //private string filler = "subdivisional summary";
        //private string filler = "";

        //private string head_line_9_grp;
        private string h9_title;
        //private string filler = space;
        //private string filler = "$ amount";
        //private string filler = "";
        //private string filler = "# claims";
        //private string filler = "";

        //private string head_line_10_grp;
        //private string filler = "DEPT";
        //private string filler = "AMT";

        //private string head_line_11_grp;
        //private string filler = "SUB";
        //private string filler = "AMT";

        //private string head_line_12_grp;
        //private string filler = "-----------------------------------------------------";
        private string head_line_12_msg;
        //private string filler = "-----------------------------------------------------";

        //private string head_line_13_grp;
        /*private string filler = "";
        private string filler = "0";
        private string filler = "1";
        private string filler = "2";
        private string filler = "3";
        private string filler = "4";
        private string filler = "5";
        private string filler = "6";
        private string filler = "7";
        private string filler = "8";
        private string filler = "9"; */

        //private string detail_line_1_grp;
        private string d1_age_ind;
        private string d1_pat_acron;
        //private string filler;
        private string d1_pat_id;
        //private string filler;
        private string d1_clm_nbr;
        private string d1_claim_nbr;
        private string d1_slash_1a;
        private string d1_dept_nbr;
        //private string filler;
        private string d1_ohip_stat_grp;
        private string d1_ohip_stat_1;
        private string d1_ohip_stat_2;
        //private string filler;
        //private string filler;
        private string d1_sub_nbr;
        private decimal d1_oma_fee;
        //private string filler;
        private decimal d1_ohip_fee;
        //private string filler;
        private decimal d1_amount_paid;
        //private string filler;
        private decimal d1_balance_due;
        //private string filler;
        private string d1_period_end_date_grp;
        private string d1_period_yy;
        private string d1_slash1;
        private string d1_period_mm;
        private string d1_slash2;
        private string d1_period_dd;
        //private string filler;
        private string d1_ser_date_grp;
        private string d1_ser_yy;
        private string d1_slash3;
        private string d1_ser_mm;
        private string d1_slash4;
        private string d1_ser_dd;
        //private string filler;
        private string d1_day_old;
        //private string filler;
        private string d1_batch_nbr_1_2;
        private string d1_batch_nbr_4_9;
        //private string filler;
        private string d1_tape_submit_ind;
        //private string filler;
        private string d1_act_taken_grp;
        private string d1_act_taken;
        //private string d1_act_taken_1;
        //private string filler;
        //private int d1_act_taken_2;
        //private string filler;

        //private string detail_line_2_grp;
        //private string filler = "";
        private string tot_title;
        //private string filler = "";
        private decimal tot_amt;
        //private string filler = "";
        private int tot_nbr_of_clms;
        //private string filler = "";

        //private string detail_line_3_grp;
        //private string filler = "";
        private string tot_title_1 = "* TOTAL *";
        //private string filler = "";
        private decimal tot_amt_1;
        //private string filler = "";
        private int tot_nbr_of_clms_1;
        //private string filler = "";

        private string detail_line_8_grp;
        //private string filler = "";
        //private string filler = "amt w/o";
        //private string filler = "";
        private decimal w_o_tot_amount;
        //private string filler = "";
        private int w_o_tot_nbr_of_clms;
        //private string filler = "";

        //private string detail_line_9_grp;
        //private string filler = "";
        private decimal d9_amount;
        //private string filler = "";
        private int d9_nbr_of_clms;
        //private string filler = "";

        //private string detail_line_10_grp;
        private int d10_dept_nbr;
        //private string filler = "";
        private decimal dept_tot_amt;
        //private string filler = "";

        //private string detail_line_11_grp;
        //private string filler = space;
        private int d11_sub_nbr;
        //private string filler = "";
        private decimal sub_tot_amt;
        //private string filler = "";

        //private string detail_line_12_grp;
        private string d12_msg;
        private string d12_ctr_r_grp;
        private int d12_ctr;
        //private string filler = "";
        private decimal d12_ctr_total;
        //private string filler = "";

        //private string detail_line_13_grp;
        private string[] d13_nbr_amt_var_r = new string[11];
        private string[] d13_nbr_var_r = new string[11];
        private string[] d13_blanks = new string[11];
        private int[] d13_nbr_var = new int[11];
        private string[] d13_amt_var_r = new string[11];
        private decimal[] d13_amt_var = new decimal[11];

        //private string head_line_final_grp;
        /*private string filler = space;
        private string filler = "TOTAL OHIP FEE";
        private string filler = "";
        private string filler = "TOTAL AMT PAID";
        private string filler = "";
        private string filler = "TOTAL BALANCE DUE";
        private string filler = ""; */

        //private string detail_line_final_grp;
        //private string filler = "";
        private decimal d_final_ohip_fee;
        //private string filler = "";
        private decimal d_final_amt_paid;
        //private string filler = "";
        private decimal d_final_bal_due;
        //private string filler = "";

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "INVALID READ ON PARAMETER FILE";
        private string filler = "CLINIC # FROM PARAM-FILE & CLAIM-MSTR ARE NOT EQUAL";
        private string filler = "INVALID READ ON CLAIMS WORK MSTR";
        private string filler = "INVALID DEPT NUMBER ON WORK FILE ( <1 OR >99 )";
        private string filler = "INVALID SUBDIVISION NBR ON WORK FILE"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "INVALID READ ON PARAMETER FILE", "CLINIC # FROM PARAM-FILE & CLAIM-MSTR ARE NOT EQUAL", "INVALID READ ON CLAIMS WORK MSTR", "INVALID DEPT NUMBER ON WORK FILE ( <1 OR >99 )", "INVALID SUBDIVISION NBR ON WORK FILE" };
        private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp;
        private string sys_date_long;
        private string sys_date_long_r_grp;
        private int sys_yy;
        private string sys_yy_alpha_grp;
        private int sys_y1;
        private int sys_y2;
        private int sys_y3;
        private int sys_y4;
        private int sys_mm;
        private int sys_dd;
        private int sys_date_numeric;

        private string sys_date_y2kfix_grp;
        private string sys_date_left;
        //private string filler;

        private string sys_date_y2kfixed_grp;
        private string sys_date_blank;
        private string sys_date_right;
        private string sys_date_temp;

        private string run_date_grp;
        private int run_yy;
        //private string filler = "/";
        private int run_mm;
        //private string filler = "/";
        private int run_dd;

        private string sys_time_grp;
        private int sys_hrs;
        private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        private string run_time_grp;
        private int run_hrs;
        //private string filler = ":";
        private int run_min;
        //private string filler = ":";
        private int run_sec;

        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_parameter_file_section()
        {

            //     use after standard error procedure on param-file.;
        }

        private void err_param_file()
        {

            //     stop "ERROR IN ACCESSING PARAMETER FILE".;
            common_status_file = status_cobol_param_file;
            //     display common-status-file.;
            //     stop run.;
        }

        private void err_claim_work_mstr_file_section()
        {

            //     use after standard error procedure on claims-work-mstr.;
        }

        private void err_claims_work_mstr()
        {

            //     stop "ERROR IN ACCESSING CLAIMS WORK MASTER".;
            common_status_file = status_cobol_claims_work_mstr;
            //     display common-status-file.;
            //     stop run.;
        }

        private void end_declaratives()
        {

        }

        public void mainline() //_section()
        {
            try
            {

                Param_file_rec_Collection = Read_Param_file_rec_Collection();

                //Note: Check the values fromt he Param file if it's many rows. Bec. it is used to pass as parameter in  Read_r070_srt_work_mstr.

                //   perform aa0-initialization			thru aa0-99-exit.;
                aa0_initialization();
                aa0_99_exit();


                objPrt_line = new ReportPrint(Directory.GetCurrentDirectory() + "\\r070_" + print_file_nbr);

                //   perform  ab2-create-report			thru ab2-99-exit.;
                ab2_create_report();
                ab2_10_building_report();
                ab2_99_exit();

                //     perform az0-finalization			thru az0-99-exit.;
                az0_finalization();
                az0_10_end_of_job();
                az0_99_exit();

                //     stop run.;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            finally
            {
                if (objPrt_line != null)
                    objPrt_line.Close();
            }
        }

        private void aa0_initialization()
        {

            //    move	zeros				to record-status;
            record_status = 0;
            // 					   balance-due;
            balance_due = 0;
            // 					   grand-amount;
            grand_amount = 0;
            //  					   grand-nbr-of-clms;
            grand_nbr_of_clms = 0;
            // 					   save-agent-cd;
            save_agent_cd = 0;
            // 					   counters;
            ctr_claims_work_mstr_reads = 0;
            ctr_detail_lines_writes = 0;
            ctr_param_file_reads = 0;

            final_grand_nbr_of_clms[1] = 0;
            final_grand_nbr_of_clms[2] = 0;
            final_grand_nbr_of_clms[3] = 0;
            final_grand_nbr_of_clms[4] = 0;
            final_grand_nbr_of_clms[5] = 0;
            final_grand_nbr_of_clms[6] = 0;
            final_grand_nbr_of_clms[7] = 0;
            final_grand_nbr_of_clms[8] = 0;
            final_grand_nbr_of_clms[9] = 0;
            final_grand_nbr_of_clms[10] = 0;
            final_grand_nbr_of_clms[11] = 0;


            final_grand_amount[1] = 0;
            final_grand_amount[2] = 0;
            final_grand_amount[3] = 0;
            final_grand_amount[4] = 0;
            final_grand_amount[5] = 0;
            final_grand_amount[6] = 0;
            final_grand_amount[7] = 0;
            final_grand_amount[8] = 0;
            final_grand_amount[9] = 0;
            final_grand_amount[10] = 0;
            final_grand_amount[11] = 0;

            // open input param-file.;

            // read param-file;
            // 	   at end;
            //        err_ind = 1;
            // 	      perform za0-common-error		thru za0-99-exit;
            // 	      go to az0-10-end-of-job.;           

            if (Param_file_rec_Collection.Count() == 0)
            {
                err_ind = 1;
                za0_common_error();
                za0_99_exit();
                az0_10_end_of_job();
                return;
            }
            else
            {
                objParam_file_rec = Param_file_rec_Collection.FirstOrDefault();
            }

            //     add 1					to  ctr-param-file-reads.;
            ctr_param_file_reads++;

            run_mm = objParam_file_rec.Param_date_mm;
            run_dd = objParam_file_rec.Param_date_dd;
            run_yy = objParam_file_rec.Param_date_yy;

            work_file_clinic_nbr = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2);
            print_file_nbr = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2);


            //     open  input  claims-work-mstr.;
            //     open  output print-file.;
            objParam_file_rec.Param_run_date = Util.Str(objParam_file_rec.Param_date_yy) + Util.Str(objParam_file_rec.Param_date_mm).PadLeft(2, '0') + Util.Str(objParam_file_rec.Param_date_dd).PadLeft(2, '0');

            header_date = objParam_file_rec.Param_run_date;

            Claims_work_rec_Collection = Read_r070_srt_work_mstr(Util.Str(objParam_file_rec.Param_clinic_nbr_1_2));

            h3_title = "";
            //detail_line_12 = "";
            d12_msg = "";
            d12_ctr = 0;
            d12_ctr_total = 0;

            //detail_line_13 = "";
            d13_nbr_amt_var_r = new string[11];
            d13_blanks = new string[11];
            d13_nbr_var = new int[11];
            d13_amt_var_r = new string[11];
            d13_amt_var = new decimal[11];

            line_cnt = 90;

            //  read claims-work-mstr;
            //         at end;
            //           err_ind = 3;
            // 	      perform za0-common-error		thru za0-99-exit;
            // 	      go to az0-10-end-of-job.;

            //     add 1					to ctr-claims-work-mstr-reads.;

            if (Claims_work_rec_Collection.Count() > 0)
            {
                objClaims_work_rec = Claims_work_rec_Collection[ctr_claims_work_mstr_reads];
                ctr_claims_work_mstr_reads++;
            }
            else
            {
                err_ind = 3;
                //  perform za0-common-error		thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // 	      go to az0-10-end-of-job.;
                az0_10_end_of_job();
                return;
            }

            // if param-clinic-nbr-1-2 not = wk-clinic-nbr then;         
            if (objParam_file_rec.Param_clinic_nbr_1_2 != objClaims_work_rec.Wk_clinic_nbr)
            {
                err_ind = 2;
                //  perform za0-common-error		thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //        go to az0-10-end-of-job.;
                az0_10_end_of_job();
                return;
            }

            //  accept sys-date		from	 date.;
            sys_date_grp = Sysdate();
            sys_date_long_child = sys_date_grp.Substring(0, 4) + sys_date_grp.Substring(4, 2) + sys_date_grp.Substring(6, 2);
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = Util.NumInt(sys_date_grp.Substring(0, 4));
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(sys_date_grp.Substring(0, 1));
            sys_y2 = Util.NumInt(sys_date_grp.Substring(1, 1));
            sys_y3 = Util.NumInt(sys_date_grp.Substring(2, 1));
            sys_y4 = Util.NumInt(sys_date_grp.Substring(3, 1));
            sys_mm = Util.NumInt(sys_date_grp.Substring(4, 2));
            sys_dd = Util.NumInt(sys_date_grp.Substring(6, 2));

            //  perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            test_date_yy = sys_yy;
            test_date_mm = sys_mm;
            test_date_dd = sys_dd;

            //  perform  aa1-set-test-date	thru	 aa1-99-exit	4 times.;
            aa1_set_test_date();
            aa1_99_exit();

            aa1_set_test_date();
            aa1_99_exit();

            aa1_set_test_date();
            aa1_99_exit();

            aa1_set_test_date();
            aa1_99_exit();

            test_date_grp = Util.Str(test_date_yy).PadLeft(4, '0') + Util.Str(test_date_mm).PadLeft(2, '0') + Util.Str(test_date_dd).PadLeft(2, '0'); //sys_date_grp;

            h1_clinic_nbr =  Util.NumInt(objParam_file_rec.Param_clinic_nbr_1_2);
            h1_year = Util.NumInt(objParam_file_rec.Param_date_period_end_yy);
            h1_day = Util.NumInt(objParam_file_rec.Param_date_period_end_dd);
            h1_month = Util.Str(objParam_file_rec.Param_date_period_end_mm).ToUpper().Trim();
            h2_clinic = Util.Str(objParam_file_rec.Param_clinic_name);
        }
        private void aa0_99_exit()
        {
            //     exit.;
        }
        private void aa1_set_test_date()
        {
            //     subtract 1 from test-date-mm.;

            test_date_mm--;

            // if test-date-mm = zero  then;            
            if (test_date_mm == 0)
            {
                test_date_mm = 12;
                // 	   subtract 1 				from test-date-yy.;
                test_date_yy--;
            }
        }
        private void aa1_99_exit()
        {
            //     exit.;
        }

        private void ab2_create_report() //_section()
        {

            //  perform ca3-clear-totals			thru ca3-99-exit.;
            ca3_clear_totals();
            ca3_99_exit();

            hold_ws_age_category = Util.NumInt(objClaims_work_rec.Wk_age_category);
            save_agent_cd = Util.NumInt(objClaims_work_rec.Wk_agent_cd);
        }

        private void ab2_10_building_report()
        {

            while (Util.Str(eof_work_mstr).ToUpper() != "Y")
            {

                //  if wk-sort-record-status not = 9 then;            
                if (Util.NumInt(objClaims_work_rec.Wk_sort_record_status) != 9)
                {
                    // 	      perform ba0-process-report 		thru ba0-99-exit;
                    // 	              until wk-sort-record-status = 9 or;
                    // 	              eof-work-mstr = "Y";

                    do
                    {
                        ba0_process_report();
                        ba0_99_exit();
                    } while (Util.NumInt(objClaims_work_rec.Wk_sort_record_status) != 9 && Util.Str(eof_work_mstr).ToUpper() != "Y");


                    // 	      perform ba1-process-totals		thru ba1-99-exit;
                    ba1_process_totals();
                    ba1_99_exit();

                    // 		  move "FINAL TOTALS **EXCLUDING** WRITE OFFS" 				to   h9-title;
                    h9_title = "FINAL TOTALS **EXCLUDING** WRITE OFFS";

                    // 	      perform wa6-write-final-totals		thru wa6-99-exit;
                    wa6_write_final_totals();
                    wa6_99_exit();
                }
                else
                {
                    //        move "WRITE OFF REPORT"			to   h3-title 
                    h3_title = "WRITE OFF REPORT";
                    save_agent_cd = objClaims_work_rec.Wk_agent_cd;
                    // 	      perform ba0-process-report		thru ba0-99-exit;
                    // 	                until eof-work-mstr = "Y";

                    do
                    {
                        ba0_process_report();
                        ba0_99_exit();
                    } while (eof_work_mstr != "Y");

                    // 	      perform ba1-process-totals		thru ba1-99-exit;
                    ba1_process_totals();
                    ba1_99_exit();

                    h9_title = "FINALWRITEOFFTOTALS";
                    // 	      perform wa6-write-final-totals		thru wa6-99-exit.;
                    wa6_write_final_totals();
                    wa6_99_exit();
                }

                //  if eof-work-mstr not = "Y" then;            
                //if (eof_work_mstr != "Y")
                //{
                // 	   go to ab2-10-building-report.;
                //    ab2_10_building_report();
                //    return;
                //}

                if (eof_work_mstr == "Y")
                {
                    break;
                }
            }
        }
        private void ab2_99_exit()
        {

            //     exit.;
        }
        private void ba0_process_report()
        {

            Reprocess:

            // if wk-agent-cd = save-agent-cd then;            
            if (objClaims_work_rec.Wk_agent_cd == save_agent_cd)
            {
                //         perform ta0-add-to-totals		thru ta0-99-exit;
                ta0_add_to_totals();
                ta0_99_exit();
                //         perform ta1-add-to-dept-totals		thru ta1-99-exit;
                ta1_add_to_dept_totals();
                ta1_99_exit();
                // 	       perform ta2-add-to-sub-totals		thru ta2-99-exit;
                ta2_add_to_sub_totals();
                ta2_99_exit();
                //         perform wa1-write-detail-line  		thru wa1-99-exit;
                wa1_write_detail_line();
                wa1_99_exit();
            }
            else
            {
                // 	       perform ba1-process-totals		thru ba1-99-exit;
                ba1_process_totals();
                ba1_99_exit();
                //         go to ba0-process-report.;
                //ba0_process_report();
                goto Reprocess;
                return;
            }

            //  read claims-work-mstr;
            //   	at end;
            //         eof_work_mstr = "Y";
            // 		   go to ba0-99-exit.;

            if (ctr_claims_work_mstr_reads < Claims_work_rec_Collection.Count())
            {
                objClaims_work_rec = Claims_work_rec_Collection[ctr_claims_work_mstr_reads];
                ctr_claims_work_mstr_reads++;
            }
            else
            {
                eof_work_mstr = "Y";
                ba0_99_exit();
                return;
            }

            //     add 1					to ctr-claims-work-mstr-reads.;
        }

        private void ba0_99_exit()
        {
            //     exit.;
        }

        private void ba1_process_totals()
        {

            //     perform ta3-add-to-final-totals		thru ta3-99-exit.;
            ta3_add_to_final_totals();
            ta3_99_exit();

            //     perform wa2-write-total-detail-lines	thru wa2-99-exit.;
            wa2_write_total_detail_lines();
            wa2_99_exit();

            //     perform wa5-write-dept-summary-lines	thru wa5-99-exit.;
            wa5_write_dept_summary_lines();
            wa5_99_exit();

            // if save-agent-cd = 6  then;            
            if (save_agent_cd == 6)
            {
                //   	perform wa8-write-sub-summary-lines	thru wa8-99-exit.;
                wa8_write_sub_summary_lines();
                wa8_99_exit();
            }

            //     perform ca3-clear-totals			thru ca3-99-exit.;
            ca3_clear_totals();
            ca3_99_exit();

            save_agent_cd = objClaims_work_rec.Wk_agent_cd;
        }

        private void ba1_99_exit()
        {

            //     exit.;
        }

        private void az0_finalization() //_section()
        {
            //     perform wa7-write-final-gr-totals		thru   wa7-99-exit.;
            wa7_write_final_gr_totals();
            wa7_99_exit();
        }

        private void az0_10_end_of_job()
        {
            //     close claims-work-mstr;
            //           param-file;
            //           print-file.;
            //     accept sys-date				from     date.;
            sys_date_grp = Sysdate();
            sys_date_long_child = sys_date_grp.Substring(0, 4) + sys_date_grp.Substring(4, 2) + sys_date_grp.Substring(6, 2);
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = Util.NumInt(sys_date_grp.Substring(0, 4));
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(sys_date_grp.Substring(0, 1));
            sys_y2 = Util.NumInt(sys_date_grp.Substring(1, 1));
            sys_y3 = Util.NumInt(sys_date_grp.Substring(2, 1));
            sys_y4 = Util.NumInt(sys_date_grp.Substring(3, 1));
            sys_mm = Util.NumInt(sys_date_grp.Substring(4, 2));
            sys_dd = Util.NumInt(sys_date_grp.Substring(6, 2));

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            //     accept sys-time				from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs_child = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min_child = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec_child = Convert.ToInt32(DateTime.Now.ToString("ss"));
           
            //     stop run.;

            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {
            //     exit.;
        }

        private void ca3_clear_totals()
        {

            current_tot = 0;
            _30_day_tot = 0;
            _60_day_tot = 0;
            _90_day_tot = 0;
            _120_day_tot = 0;
            _150_day_tot = 0;
            _180_day_tot = 0;
            //dept_total_table = 0;
            dept_tot = new decimal[100];
            //sub_total_table = 0;
            sub_tot = new decimal[100];
            current_nbr_of_clms = 0;
            _30_day_nbr_of_clms = 0;
            _60_day_nbr_of_clms = 0;
            _90_day_nbr_of_clms = 0;
            _120_day_nbr_of_clms = 0;
            _150_day_nbr_of_clms = 0;
            _180_day_nbr_of_clms = 0;
            total_amount = 0;
            total_nbr_of_clms = 0;

            line_cnt = 90;
        }

        private void ca3_99_exit()
        {

            //     exit.;
        }

        private void ma1_move_to_print_rpt()
        {

            //detail_line_1 = "";
            initialize_detail_line_1();

            // if test-date > wk-ser-date then;
            objClaims_work_rec.Wk_ser_date = Util.Str(objClaims_work_rec.Wk_ser_yy).PadLeft(4, '0') + Util.Str(objClaims_work_rec.Wk_ser_mm).PadLeft(2, '0') + Util.Str(objClaims_work_rec.Wk_ser_dd).PadLeft(2, '0');
            if (Util.NumInt(test_date_grp) > Util.NumInt(objClaims_work_rec.Wk_ser_date))
            {
                d1_age_ind = "*";
            }

            d1_pat_acron = Util.Str(objClaims_work_rec.Wk_pat_acronym).Substring(0, 6) + " " + Util.Str(objClaims_work_rec.Wk_pat_acronym).Substring(6, 3);
            d1_pat_id = Util.Str(objClaims_work_rec.Wk_pat_id_1) + Util.Str(objClaims_work_rec.Wk_pat_id_2).Trim();
            d1_clm_nbr = Util.Str(objClaims_work_rec.Wk_clinic_nbr) + Util.Str(objClaims_work_rec.Wk_doc_nbr) + Util.Str(objClaims_work_rec.Wk_week).PadLeft(2, '0') + Util.Str(objClaims_work_rec.Wk_day);
            d1_claim_nbr = Util.Str(objClaims_work_rec.Wk_claim_nbr);
            d1_slash_1a = "/";
            d1_dept_nbr = Util.Str(objClaims_work_rec.Wk_dept_nbr);

            d1_ohip_stat_grp = Util.Str(objClaims_work_rec.Wk_ohip_stat);
            d1_ohip_stat_1 = Util.Str(objClaims_work_rec.Wk_ohip_stat_1);
            d1_ohip_stat_2 = Util.Str(objClaims_work_rec.Wk_ohip_stat_2);

            d1_sub_nbr = objClaims_work_rec.Wk_sub_nbr == "0" ? Util.Str(" ") : Util.Str(objClaims_work_rec.Wk_sub_nbr);
            d1_oma_fee = Util.NumInt(objClaims_work_rec.Wk_oma_fee);
            d1_ohip_fee = Util.NumInt(objClaims_work_rec.Wk_ohip_fee);
            d1_amount_paid = Util.NumInt(objClaims_work_rec.Wk_amount_paid);
            d1_balance_due = Util.NumInt(objClaims_work_rec.Wk_balance_due);
            d1_period_yy = Util.Str(objClaims_work_rec.Wk_period_end_yy.ToString().Substring(2, 2));
            d1_period_mm = Util.Str(objClaims_work_rec.Wk_period_end_mm);
            d1_period_dd = Util.Str(objClaims_work_rec.Wk_period_end_dd);

            if (objClaims_work_rec.Wk_ser_yy > 0)
            {
                d1_ser_yy = Util.Str(objClaims_work_rec.Wk_ser_yy.ToString().Substring(2, 2));
            }
            else
            {
                d1_ser_yy = Util.Str(objClaims_work_rec.Wk_ser_yy);
            }

            d1_ser_mm = Util.Str(objClaims_work_rec.Wk_ser_mm);
            d1_ser_dd = Util.Str(objClaims_work_rec.Wk_ser_dd);

            d1_slash1 = "/";
            d1_slash2 = "/";
            d1_slash3 = "/";
            d1_slash4 = "/";


            d1_day_old = Util.Str(objClaims_work_rec.Wk_day_old);
            d1_batch_nbr_1_2 = Util.Str(objClaims_work_rec.Wk_batch_nbr_1_2);
            d1_batch_nbr_4_9 = Util.Str(objClaims_work_rec.Wk_batch_nbr_4_9);
            d1_act_taken_grp = Util.Str(objClaims_work_rec.Wk_act_taken);
            d1_act_taken = Util.Str(objClaims_work_rec.Wk_act_taken_1) + Util.Str(objClaims_work_rec.Wk_act_taken_2);
            //d1_act_taken_1 = Util.Str(objClaims_work_rec.Wk_act_taken_1).Trim();
            //d1_act_taken_2 = Util.NumInt(objClaims_work_rec.Wk_act_taken_2);
            d1_tape_submit_ind = Util.Str(objClaims_work_rec.Wk_tape_submit_ind);
            h3_agent = Util.Str(objClaims_work_rec.Wk_agent_cd);
        }

        private void ma1_99_exit()
        {
            //     exit.;
        }

        private void ta0_add_to_totals()
        {

            //     if  wk-age-category =  0 then;            
            if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 0)
            {
                //         add wk-balance-due		to current-tot;
                current_tot += Util.NumDec(objClaims_work_rec.Wk_balance_due);
                //         add 1				to current-nbr-of-clms;
                current_nbr_of_clms++;
            }
            else if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 1)
            {
                //             add wk-balance-due		to 30-day-tot;
                _30_day_tot += Util.NumDec(objClaims_work_rec.Wk_balance_due);

                //     	    add 1			to 30-day-nbr-of-clms;
                _30_day_nbr_of_clms++;
            }
            else if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 2)
            {
                // 	   	    add wk-balance-due	to 60-day-tot;
                _60_day_tot += Util.NumDec(objClaims_work_rec.Wk_balance_due);
                // 		    add 1			to 60-day-nbr-of-clms;
                _60_day_nbr_of_clms++;
            }
            else if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 3)
            {
                // 		    add wk-balance-due	to 90-day-tot;
                _90_day_tot += Util.NumDec(objClaims_work_rec.Wk_balance_due);
                // 		    add 1		to 90-day-nbr-of-clms;
                _90_day_nbr_of_clms++;
            }
            else if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 4)
            {
                // 			add wk-balance-due      to 120-day-tot;
                _120_day_tot += Util.NumDec(objClaims_work_rec.Wk_balance_due);
                // 			add 1			to 120-day-nbr-of-clms;
                _120_day_nbr_of_clms++;
            }
            else if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 5)
            {
                // 			    add wk-balance-due	to 150-day-tot;
                _150_day_tot += objClaims_work_rec.Wk_balance_due;
                // 			    add 1		to 150-day-nbr-of-clms;
                _150_day_nbr_of_clms++;
            }
            else if (Util.NumInt(objClaims_work_rec.Wk_age_category) == 6)
            {
                // 				add wk-balance-due to 180-day-tot;
                _180_day_tot += objClaims_work_rec.Wk_balance_due;
                // 				add 1	      	   to 180-day-nbr-of-clms.;
                _180_day_nbr_of_clms++;
            }
        }

        private void ta0_99_exit()
        {
            //     exit.;
        }

        private void ta1_add_to_dept_totals()
        {
            // if wk-dept-nbr < 1 or wk-dept-nbr > 99 then;          
            if (Util.NumInt(objClaims_work_rec.Wk_dept_nbr) < 1 || Util.NumInt(objClaims_work_rec.Wk_dept_nbr) > 99)
            {
                err_ind = 4;
                //         perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //         go to az0-finalization;
                az0_finalization();
                return;
            }
            else
            {
                //        add wk-balance-due 		to  dept-tot(wk-dept-nbr);
                // 					    total-bal-due;
                // 					    final-bal-due;

                dept_tot[objClaims_work_rec.Wk_dept_nbr] += Util.NumDec(objClaims_work_rec.Wk_balance_due);
                total_bal_due += Util.NumDec(objClaims_work_rec.Wk_balance_due);
                final_bal_due += Util.NumDec(objClaims_work_rec.Wk_balance_due);

                // 	      add wk-ohip-fee			to  total-ohip-fee;
                // 					    final-ohip-fee;

                total_ohip_fee += Util.NumDec(objClaims_work_rec.Wk_ohip_fee);
                final_ohip_fee += Util.NumDec(objClaims_work_rec.Wk_ohip_fee);

                // 	      add wk-amount-paid		to  total-amt-paid;
                // 					    final-amt-paid.;

                total_amt_paid += Util.NumDec(objClaims_work_rec.Wk_amount_paid);
                final_amt_paid += Util.NumDec(objClaims_work_rec.Wk_amount_paid);
            }
        }

        private void ta1_99_exit()
        {
            //     exit.;
        }

        private void ta2_add_to_sub_totals()
        {
            // if wk-agent-cd = 6  then;            
            if (objClaims_work_rec.Wk_agent_cd == 6)
            {
                tp_sub_nbr = Util.NumInt(objClaims_work_rec.Wk_sub_nbr);
                // 	     add 1				to tp-sub-nbr;
                tp_sub_nbr++;
                // 	     add wk-balance-due 		to sub-tot(tp-sub-nbr).;
                sub_tot[tp_sub_nbr] += Util.NumDec(objClaims_work_rec.Wk_balance_due);
            }
        }

        private void ta2_99_exit()
        {
            //     exit.;
        }

        private void ta3_add_to_final_totals()
        {

            //     compute total-amount = (current-tot;
            // 			 	+ 30-day-tot;
            // 				+ 60-day-tot;
            // 				+ 90-day-tot;
            // 				+ 120-day-tot;
            // 				+ 150-day-tot;
            // 				+ 180-day-tot).;

            total_amount = (current_tot
                                  + _30_day_tot
                                 + _60_day_tot
                                 + _90_day_tot
                                 + _120_day_tot
                                 + _150_day_tot
                                 + _180_day_tot);

            //     compute total-nbr-of-clms = (current-nbr-of-clms;
            // 				+ 30-day-nbr-of-clms;
            // 				+ 60-day-nbr-of-clms;
            // 				+ 90-day-nbr-of-clms;
            // 				+ 120-day-nbr-of-clms;
            // 				+ 150-day-nbr-of-clms;
            // 				+ 180-day-nbr-of-clms).;

            total_nbr_of_clms = (current_nbr_of_clms
                                 + _30_day_nbr_of_clms
                                 + _60_day_nbr_of_clms
                                 + _90_day_nbr_of_clms
                                 + _120_day_nbr_of_clms
                                 + _150_day_nbr_of_clms
                                 + _180_day_nbr_of_clms);


            //     add total-amount 		to grand-amount;
            // 				   final-grand-amount(save-agent-cd + 1).;

            grand_amount += total_amount;
            final_grand_amount[save_agent_cd + 1] += total_amount;

            //     add total-nbr-of-clms	to grand-nbr-of-clms;
            //  				   final-grand-nbr-of-clms(save-agent-cd + 1).;

            grand_nbr_of_clms += total_nbr_of_clms;
            final_grand_nbr_of_clms[save_agent_cd + 1] += total_nbr_of_clms; ;
        }

        private void ta3_99_exit()
        {
            //     exit.;
        }

        private void wa1_write_detail_line()
        {

            // if wk-age-category not = hold-ws-age-category then;
            if (Util.NumInt(objClaims_work_rec.Wk_age_category) != hold_ws_age_category)
            {
                line_cnt = 98;
            }

            //     add 1				to	line-cnt.;
            line_cnt++;

            //  if line-cnt > 60  then;            
            if (line_cnt > 60)
            {
                //         perform wa3-write-heading-for-rpt	thru wa3-99-exit.;
                wa3_write_heading_for_rpt();
                wa3_99_exit();
            }

            //     perform ma1-move-to-print-rpt           	thru ma1-99-exit.;
            ma1_move_to_print_rpt();
            ma1_99_exit();

            //     write prt-line from detail-line-1 after advancing 1 line.;

            //05  d1 - pat - acron                pic x(6)bxxx.            
            objPrt_line.print(detail_line_1_grp(), 1, true);
            objPrt_line.print(true);


            //     add 1				to 	ctr-detail-lines-writes.;
            ctr_detail_lines_writes++;

            hold_ws_age_category = Util.NumInt(objClaims_work_rec.Wk_age_category);
        }
        private void wa1_99_exit()
        {
            //     exit.;
        }

        private void wa2_write_total_detail_lines()
        {

            //detail_line_1 = "";
            initialize_detail_line_1();



            d1_ohip_fee = total_ohip_fee;
            d1_amount_paid = total_amt_paid;
            d1_balance_due = total_bal_due;

            //     write prt-line from detail-line-1;
            // 					after advancing 2 lines.;

            objPrt_line.print(true);
            objPrt_line.print(detail_line_1_grp(), 1, true);


            total_ohip_fee = 0;
            total_amt_paid = 0;
            total_bal_due = 0;

            // if line-cnt > 24  then;            
            if (line_cnt > 24)
            {
                //         add 1				to page-cnt;
                page_cnt++;

                h1_page = page_cnt;
                //         write prt-line from head-line-1 after advancing  page;                
                objPrt_line.PageBreak();
                objPrt_line.print(head_line_1_grp(), 1, true);

                h3_agent = Util.Str(save_agent_cd);

                //         write prt-line from blank-line 	after advancing 1 line;
                objPrt_line.print(true);
                objPrt_line.print(true);
                objPrt_line.print(true);

                //         write prt-line from head-line-3 after advancing 1 line.;                
                objPrt_line.print(head_line_3_grp(), 1, true);
            }


            //     write prt-line from head-line-6 	after advancing 3 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_6_grp(), 1, true);

            //     write prt-line from blank-line.;
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);

            tot_title = " CURRENT";
            tot_amt = current_tot;
            tot_nbr_of_clms = current_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_title = " 30-DAYS";
            tot_amt = _30_day_tot;
            tot_nbr_of_clms = _30_day_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_title = " 60-DAYS";
            tot_amt = _60_day_tot;
            tot_nbr_of_clms = _60_day_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_title = " 90-DAYS";
            tot_amt = _90_day_tot;
            tot_nbr_of_clms = _90_day_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_title = "120_DAYS";
            tot_amt = _120_day_tot;
            tot_nbr_of_clms = _120_day_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_title = "150_DAYS";
            tot_amt = _150_day_tot;
            tot_nbr_of_clms = _150_day_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_title = "180_DAYS";
            tot_amt = _180_day_tot;
            tot_nbr_of_clms = _180_day_nbr_of_clms;

            //     write prt-line from detail-line-2.;            
            objPrt_line.print(detail_line_2_grp(), 1, true);
            objPrt_line.print(true);

            tot_amt_1 = total_amount;
            tot_nbr_of_clms_1 = total_nbr_of_clms;

            //     write prt-line from detail-line-3.;            
            objPrt_line.print(detail_line_3_grp(), 1, true);
        }
        private void wa2_99_exit()
        {
            //     exit.;
        }
        private void wa3_write_heading_for_rpt()
        {

            //     add 1 				to page-cnt.;
            page_cnt++;

            h1_page = page_cnt;

            line_cnt = 0;

            //     write prt-line from head-line-1 	after advancing page.;            
            objPrt_line.PageBreak();
            objPrt_line.print(head_line_1_grp(), 1, true);
            objPrt_line.print(true);

            //     write prt-line from head-line-2.;            
            objPrt_line.print(head_line_2_grp(), 1, true);
            objPrt_line.print(true);

            h3_agent = Util.Str(save_agent_cd);

            //     write prt-line from head-line-3.;            
            objPrt_line.print(head_line_3_grp(), 1, true);

            //     write prt-line from head-line-4 	after advancing 2 line.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_4_grp(), 1, true);
            objPrt_line.print(true);

            //     write prt-line from head-line-5.;            
            objPrt_line.print(head_line_5_grp(), 1, true);

            //     write prt-line from blank-line.;
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);

            line_cnt = 7;
        }
        private void wa3_99_exit()
        {
            //     exit.;
        }
        private void wa5_write_dept_summary_lines()
        {
            //     write prt-line from head-line-7 after advancing 5 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_7_grp(), 1, true);

            //     write prt-line from head-line-10 after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_10_grp(), 1, true);

            //     write prt-line from blank-line.;
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);

            //     perform xa0-write-dept-totals	thru xa0-99-exit;
            //         varying i from 1 by 1 until i > 99.;

            i = 1;
            do
            {
                xa0_write_dept_totals();
                xa0_99_exit();
                i++;
            } while (i <= 99);
        }
        private void wa5_99_exit()
        {
            //     exit.;
        }
        private void wa6_write_final_totals()
        {

            //     add 4				to line-cnt.;
            line_cnt += 4;

            // if line-cnt > 60 then;            
            if (line_cnt > 60)
            {
                // 	   add 1				to page-cnt;
                page_cnt++;
                h1_page = page_cnt;
                // 	write prt-line from head-line-1 after advancing page;                
                objPrt_line.PageBreak();
                objPrt_line.print(head_line_1_grp(), 1, true);
                objPrt_line.print(true);

                // 	write prt-line from head-line-2.;                
                objPrt_line.print(head_line_2_grp(), 1, true);
            }

            //     write prt-line from head-line-9 after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_9_grp(), 1, true);


            d9_amount = grand_amount;
            d9_nbr_of_clms = grand_nbr_of_clms;
            //     write prt-line from detail-line-9 	after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(detail_line_9_grp(), 1, true);

            line_cnt = 0;
            grand_amount = 0;
            grand_nbr_of_clms = 0;

            line_cnt = 60;
        }
        private void wa6_99_exit()
        {
            //     exit.;
        }
        private void wa7_write_final_gr_totals()
        {

            //     add 1				to	page-cnt.;
            page_cnt++;
            h1_page = page_cnt;
            //     write prt-line from head-line-1 after advancing page.;            
            objPrt_line.PageBreak();
            objPrt_line.print(head_line_1_grp(), 1, true);
            objPrt_line.print(true);

            //     write prt-line from head-line-2.;            
            objPrt_line.print(head_line_2_grp(), 1, true);

            h9_title = "FINAL TOTALS **INCLUDING** WRITE OFFS";

            //     write prt-line from head-line-9 after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_9_grp(), 1, true);

            head_line_12_msg = "NUMBER OF CLAIMS BY AGENT";

            //     write prt-line from head-line-12 after advancing 3 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_12_grp(), 1, true);

            //     write prt-line from head-line-13 after advancing 1 line.;            
            objPrt_line.print(true);
            objPrt_line.print(head_line_13_grp(), 1, true);
            objPrt_line.print(true);


            //     perform wa7a-build-prt-line thru wa7a-99-exit;
            //               varying i;
            //               from 1 by 1;
            //               until i > 10.;

            i = 1;
            do
            {
                wa7a_build_prt_line();
                wa7a_99_exit();
                i++;
            } while (i <= 10);

            //   write prt-line from detail-line-13 after advancing 1 line.;

            /* 01 detail - line - 13.
             10  d13 - nbr - amt - var - r occurs 10 times.
                 15  d13 - nbr - var - r.
                     20  d13 - blanks                  pic xxxx. 
                     20  d13 - nbr - var                 pic 9(9).
                 15  d13 - amt - var - r  redefines d13-nbr - var - r.
                     20  d13 - amt - var                 pic z,zzz,zz9.99-. */

            objPrt_line.print(detail_line_13_grp(true), 1, true);   


            d12_msg = "TOTAL:";
            d12_ctr = final_grand_nbr_of_clms[11];
            //     write prt-line from detail-line-12 after advancing 2 line.;

            /*  01  detail - line - 12.
                  10  d12 - msg             pic x(7).
                  10  d12 - ctr - r.
                      15  d12 - ctr             pic 9(9).
                      15  filler              pic x(6)       value spaces.
                  10  d12 - ctr - total redefines d12 - ctr - r   pic zzz, zzz, zz9.99 -.
                  10  filler              pic x(107)     value spaces. */

            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(detail_line_12_grp(true), 1, true);  // todo....


            head_line_12_msg = "-AMOUNT CLAIMED BY AGENT-";

            //     write prt-line from head-line-12 after advancing 3 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_12_grp(), 1, true);
            objPrt_line.print(true);


            //     write prt-line from head-line-13 after advancing 1 line.;            
            objPrt_line.print(head_line_13_grp(), 1, true);
            objPrt_line.print(true);

            //     perform wa7b-build-prt-line thru wa7b-99-exit;
            //               varying i;
            //               from 1 by 1;
            //               until i > 10.;

            i = 1;
            do
            {
                wa7b_build_prt_line();
                wa7b_99_exit();
                i++;
            } while (i <= 10);

            //     write prt-line from detail-line-13 after advancing 1 line.;            
            objPrt_line.print(detail_line_13_grp(false), 1, true);
            d12_ctr_total = final_grand_amount[11];
            //     write prt-line from detail-line-12 after advancing 2 line.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(detail_line_12_grp(false), 1, true);

            //     write prt-line from blank-line.;
            objPrt_line.print(true);

            //     write prt-line from head-line-final  after advancing 3 line.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_final_grp(), 1, true);

            d_final_ohip_fee = final_ohip_fee;
            d_final_amt_paid = final_amt_paid;
            d_final_bal_due = final_bal_due;

            //  write prt-line from detail-line-final after advancing 2 line.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(detail_line_final_grp(), 1, true);

        }
        private void wa7_99_exit()
        {
            //     exit.;
        }
        private void wa8_write_sub_summary_lines()
        {

            //     write prt-line from head-line-8 after advancing 5 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(true);
            objPrt_line.print(head_line_8_grp(), 1, true);

            //   write prt-line from head-line-11 after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(head_line_11_grp(), 1, true);

            //     write prt-line from blank-line.;
            objPrt_line.print(true);

            //     perform xa1-write-sub-totals 	thru xa1-99-exit;
            // 	varying i from 1 by 1 until i > 10.;

            i = 1;
            do
            {
                xa1_write_sub_totals();
                xa1_99_exit();
                i++;
            } while (i <= 10);
        }
        private void wa8_99_exit()
        {
            //     exit.;
        }
        private void wa7a_build_prt_line()
        {

            d13_nbr_var[i] = final_grand_nbr_of_clms[i];
            //     add  final-grand-nbr-of-clms(i) to  final-grand-nbr-of-clms(11).;
            final_grand_nbr_of_clms[11] += final_grand_nbr_of_clms[i];
        }
        private void wa7a_99_exit()
        {
            //     exit.;
        }
        private void wa7b_build_prt_line()
        {
            d13_amt_var[i] = final_grand_amount[i];
            //     add  final-grand-amount(i)      to  final-grand-amount(11).;
            final_grand_amount[11] += final_grand_amount[i];
        }
        private void wa7b_99_exit()
        {
            //     exit.;
        }
        private void xa0_write_dept_totals()
        {
            // if dept-tot(i) not > zero then;
            if (dept_tot[i] <= 0)
            {
                // 	go to xa0-99-exit.;
                xa0_99_exit();
                return;
            }


            d10_dept_nbr = i;
            dept_tot_amt = dept_tot[i];
            //     write prt-line from detail-line-10.;            
            objPrt_line.print(detail_line_10_grp(), 1, true);
            objPrt_line.print(true);

        }
        private void xa0_99_exit()
        {
            //     exit.;
        }
        private void xa1_write_sub_totals()
        {

            // if sub-tot(i) not > zero then;            
            if (sub_tot[i] <= 0)
            {
                xa1_99_exit();
                return;
            }

            //  subtract 1		from i			giving d11-sub-nbr.;
            d11_sub_nbr = i - 1;

            sub_tot_amt = sub_tot[i];

            //     write prt-line from detail-line-11.;            
            objPrt_line.print(detail_line_11_grp(), 1, true);

        }
        private void xa1_99_exit()
        {
            //     exit.;
        }

        private void za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-comment.;
            Console.WriteLine(err_msg_comment);
            error_flag = "Y";
        }

        private void za0_99_exit()
        {
            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate()
        {

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        private string head_line_1_grp()
        {
            return "R070  /".PadRight(7) +
                     Util.Str(h1_clinic_nbr).PadLeft(2) +
                     new string(' ', 1) +
                     Util.Str(h1_month).PadLeft(9) +
                     new string(' ', 1) +
                     string.Format("{0:#0}", h1_day).PadLeft(2) +
                     ", " +
                     Util.Str(h1_year).PadLeft(4, '0') +
                     new string(' ', 19) +
                     "* ACCOUNTS RECEIVABLE TRIAL BALANCE *".PadRight(37) +
                    new string(' ', 12) +
                    "RUN DATE ".PadRight(9) +
                    (Util.Str(header_date).Substring(0, 4) + "/" + Util.Str(header_date).Substring(4, 2) + "/" + Util.Str(header_date).Substring(6, 2)).PadRight(10) +
                    new string(' ', 7) +
                    "PAGE ".PadRight(5) +
                    string.Format("{0:#,0}", h1_page).PadLeft(5);
        }

        private string head_line_2_grp()
        {
            return new string(' ', 55) +
                     Util.Str(h2_clinic).PadRight(20) +
                     new string(' ', 57);
        }

        private string head_line_3_grp()
        {
            return " AGENT ".PadRight(7) +
                     Util.Str(h3_agent).PadRight(1) +
                     new string(' ', 5) +
                     Util.Str(h3_title).PadRight(20) +
                     new string(' ', 119);
        }

        private string head_line_4_grp()
        {
            return "  PATIENT   PATIENT ID/    CLAIM   ".PadRight(35) +
                     "    OH SUB    OMA        OHIP     A".PadRight(35) +
                     "MOUNT    BALANCE   PERIOD   SERVICE".PadRight(35) +
                     " DAY  BATCH   TAPE ACTION  ".PadRight(27);
        }

        private string head_line_5_grp()
        {
            return "  ACRONYM   CHART NUMBER   NUMBER/D".PadRight(35) +
                    "EPT IP NBR    FEE        FEE       ".PadRight(35) +
                    "PAID       DUE      DATE     DATE  ".PadRight(35) +
                    " OLD  NUMBER  SUB  TAKEN   ".PadRight(27);
        }

        private string head_line_6_grp()
        {
            return new string(' ', 5) +
                    "AGE CATEGORY      AMOUNT        #OF CLAIMS".PadRight(42) +
                    new string(' ', 85);
        }

        private string head_line_7_grp()
        {
            return "DEPARTMENTAL SUMMARY".PadRight(20) +
                     new string(' ', 112);
        }

        private string head_line_8_grp()
        {
            return "SUBDIVISIONAL SUMMARY".PadRight(21) +
                     new string(' ', 111);
        }

        private string head_line_9_grp()
        {
            return Util.Str(h9_title).PadRight(40) +
                     new string(' ', 15) +
                     "$ AMOUNT".PadRight(8) +
                     new string(' ', 5) +
                     "# CLAIMS".PadRight(8) +
                     new string(' ', 56);
        }

        private string head_line_10_grp()
        {
            return "DEPT".PadRight(28) +
                     "AMT".PadRight(104);
        }

        private string head_line_11_grp()
        {
            return "SUB".PadRight(28) +
                    "AMT".PadRight(104);
        }

        private string head_line_12_grp()
        {
            return "-----------------------------------------------------".PadRight(53) +
                     Util.Str(head_line_12_msg).PadRight(25) +
                     "-----------------------------------------------------".PadRight(54);
        }

        private string head_line_13_grp()
        {
            return new string(' ', 8) +
                    "0".PadRight(13) +
                    "1".PadRight(13) +
                    "2".PadRight(13) +
                    "3".PadRight(13) +
                    "4".PadRight(13) +
                    "5".PadRight(13) +
                    "6".PadRight(13) +
                    "7".PadRight(13) +
                    "8".PadRight(13) +
                    "9".PadRight(13) +
                    new string(' ', 1);
        }

        private string detail_line_1_grp()
        {
            return Util.Str(d1_age_ind).PadRight(1) +
                     Util.Str(d1_pat_acron).PadRight(10) +
                     new string(' ', 1) +
                     Util.Str(d1_pat_id).PadRight(12) +
                     new string(' ', 1) +
                     Util.Str(d1_clm_nbr).PadRight(8, ' ') +
                     Util.Str(d1_claim_nbr).PadLeft(2, ' ') +
                     Util.Str(d1_slash_1a).PadRight(1) +
                     Util.Str(d1_dept_nbr).PadLeft(2) +
                     new string(' ', 1) +
                     Util.Str(d1_ohip_stat_1).PadRight(1) +
                     Util.Str(d1_ohip_stat_2).PadLeft(1) +
                     new string(' ', 1) +
                     Util.Str(d1_sub_nbr).PadRight(3, ' ') +
                     new string(' ', 1) +
                     Util.ImpliedDecimalFormat("0.00", d1_oma_fee, 2, 8) +
                     new string(' ', 1) +
                     Util.ImpliedDecimalFormat("0.00", d1_ohip_fee, 2, 10) +
                     new string(' ', 1) +
                     Util.ImpliedDecimalFormat("0.00", d1_amount_paid, 2, 10) +
                     new string(' ', 1) +
                     Util.ImpliedDecimalFormat("0.00", d1_balance_due, 2, 10) +
                     new string(' ', 1) +
                     Util.Str(d1_period_yy).PadLeft(2) +
                     Util.Str(d1_slash1).PadRight(1) +
                     Util.Str(d1_period_mm).PadLeft(2) +
                     Util.Str(d1_slash2).PadRight(1) +
                     Util.Str(d1_period_dd).PadLeft(2) +
                     new string(' ', 1) +
                     Util.Str(d1_ser_yy).PadLeft(2) +
                     Util.Str(d1_slash3).PadRight(1) +
                     Util.Str(d1_ser_mm).PadLeft(2) +
                     Util.Str(d1_slash4).PadRight(1) +
                     Util.Str(d1_ser_dd).PadLeft(2) +
                     new string(' ', 1) +
                     Util.Str(d1_day_old).PadRight(3) +
                     new string(' ', 1) +
                     Util.Str(d1_batch_nbr_1_2).PadLeft(2) +
                     Util.Str(d1_batch_nbr_4_9).PadRight(6) +
                     new string(' ', 1) +
                     Util.Str(d1_tape_submit_ind).PadRight(1) +
                     new string(' ', 1) +
                     Util.Str(d1_act_taken).PadRight(11) +
                     //Util.Str(d1_act_taken_1).PadRight(2, '0') +
                     //new string(' ', 1) +
                     //Util.Str(d1_act_taken_2).PadLeft(6, '0') +
                     new string(' ', 2);
        }

        private string detail_line_2_grp()
        {
            return new string(' ', 6) +
                    Util.Str(tot_title).PadRight(8) +
                    new string(' ', 3) +
                    Util.ImpliedDecimalFormat("#,0.00", tot_amt, 2, 14) +
                    new string(' ', 7) +
                    string.Format("{0:#,0}", tot_nbr_of_clms).PadLeft(7) +
                    new string(' ', 88);
        }

        private string detail_line_3_grp()
        {
            return new string(' ', 6) +
                     "* TOTAL *".PadRight(9) +
                     new string(' ', 2) +
                     Util.ImpliedDecimalFormat("#,0.00", tot_amt_1, 2, 14) +
                     new string(' ', 7) +
                     string.Format("{0:#,0}", tot_nbr_of_clms_1).PadLeft(7) +
                     new string(' ', 87);
        }

        private string detail_line_9_grp()
        {
            return new string(' ', 50) +
                    Util.ImpliedDecimalFormat("#,0.00", d9_amount, 2, 14) +
                    new string(' ', 5) +
                    string.Format("{0:#,0}", d9_nbr_of_clms).PadLeft(7) +
                    new string(' ', 56);
        }

        private string detail_line_10_grp()
        {
            return Util.Str(d10_dept_nbr).PadLeft(2, '0') +
                     new string(' ', 16) +
                     Util.ImpliedDecimalFormat("#,0.00", dept_tot_amt, 2, 14) +
                     new string(' ', 100);
        }

        private string detail_line_11_grp()
        {
            return new string(' ', 1) +
                Util.Str(d11_sub_nbr).PadLeft(1, '0') +
                new string(' ', 16) +
                Util.ImpliedDecimalFormat("#,0.00", sub_tot_amt, 2, 14) +
                new string(' ', 100);
        }

        private string detail_line_12_grp(bool isCount)
        {
            if (isCount == true)
            {
                return Util.Str(d12_msg).PadRight(7) + Util.Str(d12_ctr).PadLeft(9, '0') + new string(' ', 113);
            }
            else
            {
                return Util.Str(d12_msg).PadRight(7) + Util.ImpliedDecimalFormat("#,0.00", d12_ctr_total, 2, 15) + new string(' ', 113);
            }
        }

        private string detail_line_13_grp(bool isNumber)
        {
            if (isNumber == true)
            {
                return Util.Str(d13_blanks[1]).PadRight(4) + Util.Str(d13_nbr_var[1]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[2]).PadRight(4) + Util.Str(d13_nbr_var[2]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[3]).PadRight(4) + Util.Str(d13_nbr_var[3]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[4]).PadRight(4) + Util.Str(d13_nbr_var[4]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[5]).PadRight(4) + Util.Str(d13_nbr_var[5]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[6]).PadRight(4) + Util.Str(d13_nbr_var[6]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[7]).PadRight(4) + Util.Str(d13_nbr_var[7]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[8]).PadRight(4) + Util.Str(d13_nbr_var[8]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[9]).PadRight(4) + Util.Str(d13_nbr_var[9]).PadLeft(9, '0') +
                       Util.Str(d13_blanks[10]).PadRight(4) + Util.Str(d13_nbr_var[10]).PadLeft(9, '0');

            }
            else
            {
                return Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[1], 2, 13) + Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[2], 2, 13) +
                       Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[3], 2, 13) + Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[4], 2, 13) +
                       Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[5], 2, 13) + Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[6], 2, 13) +
                       Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[7], 2, 13) + Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[8], 2, 13) +
                       Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[9], 2, 13) + Util.ImpliedDecimalFormat("#,0.00", d13_amt_var[10], 2, 13);
            }
        }

        private string head_line_final_grp()
        {
            return new string(' ', 15) +
                    "TOTAL OHIP FEE".PadRight(15) +
                    new string(' ', 5) +
                    "TOTAL AMT PAID".PadRight(15) +
                    new string(' ', 5) +
                    "TOTAL BALANCE DUE".PadRight(20) +
                    new string(' ', 57);
        }

        private string detail_line_final_grp()
        {
            return new string(' ', 15) +
                     Util.ImpliedDecimalFormat("#,0.00", d_final_ohip_fee, 2, 15) +
                     new string(' ', 5) +
                     Util.ImpliedDecimalFormat("#,0.00", d_final_amt_paid, 2, 15) +
                     new string(' ', 8) +
                     Util.ImpliedDecimalFormat("#,0.00", d_final_bal_due, 2, 15) +
                     new string(' ', 59);
        }

        private void initialize_detail_line_1()
        {
            d1_age_ind = "";
            d1_pat_acron = "";
            d1_pat_id = "";
            d1_clm_nbr = "";
            d1_claim_nbr = "";
            d1_slash_1a = "";
            d1_dept_nbr = "";
            d1_ohip_stat_grp = "";
            d1_ohip_stat_1 = "";
            d1_ohip_stat_2 = "";
            d1_sub_nbr = "";
            d1_oma_fee = 0;
            d1_ohip_fee = 0;
            d1_amount_paid = 0;
            d1_balance_due = 0;
            d1_period_end_date_grp = "";
            d1_period_yy = "";
            d1_slash1 = "";
            d1_period_mm = "";
            d1_slash2 = "";
            d1_period_dd = "";
            d1_ser_date_grp = "";
            d1_ser_yy = "";
            d1_slash3 = "";
            d1_ser_mm = "";
            d1_slash4 = "";
            d1_ser_dd = "";
            d1_day_old = "";
            d1_batch_nbr_1_2 = "";
            d1_batch_nbr_4_9 = "";
            d1_tape_submit_ind = "";
            d1_act_taken_grp = "";
            d1_act_taken = "";
            //d1_act_taken_1 = "";
            //d1_act_taken_2 = 0;
        }

        #endregion
    }
}

