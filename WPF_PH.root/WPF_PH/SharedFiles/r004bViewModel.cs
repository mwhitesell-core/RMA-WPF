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
    public class R004bViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: r004_work_file
        private Work_in_rec objWork_in_rec = null;
        private ObservableCollection<Work_in_rec> Work_in_rec_Collection;

        // FD: r004_sort_work_file
        private Work_out_rec objWork_out_rec = null;
        private ObservableCollection<Work_out_rec> Work_out_rec_Collection;

        // FD: r004_sort_work_file	Copy : r004_claims_work_mstr.sd
        private Work_sort_rec objWork_sort_rec = null;
        private ObservableCollection<Work_sort_rec> Work_sort_rec_Collection;

        private WriteFile objr004_work_file = null;
        private WriteFile objr004_sort_work_file = null;
        private WriteFile objr004_sort_work = null;

        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name = "r004";
        private string option;
        private int sel_month;
        private string work_file_in_name = "r004wf";
        private string work_file_out_name = "r004_sort_work_mstr";
        private string common_status_file;
        private string status_sort_file;
        private int sel_clinic_nbr;

        private string counters_grp;
        private int ctr_batctrl_file_reads;
        private int ctr_claims_mstr_reads;
        private int ctr_work_file_writes;
        private int ctr_work_file_reads;
        private int ctr_doc_mstr_reads;
        private int ctr_pages;

        private string error_message_table_grp;
        private string error_messages_grp;
        /* private string filler = "invalid reply";
         private string filler = "INVALID READ ON CONSTANTS MASTER";
         private string filler = "invalid reply";
         private string filler = "NO BATCTRL FILE SUPPLIED";
         private string filler = "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER";
         private string filler = "NO APPROPRIATE RECORDS IN BATCTRL FILE";
         private string filler = "NO CLAIMS FOR THIS BATCH";
         private string filler = "NO HEADER FOR CURRENT BATCH";
         private string filler = "invalid month";
         private string filler = "ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING";
         private string filler = "INVALID BATCH TYPE";
         private string filler = "WORK FILE EMPTY";
         private string filler = "INVALID READ ON DOCTOR MASTER FILE"; */
        private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "INVALID READ ON CONSTANTS MASTER", "invalid reply", "NO BATCTRL FILE SUPPLIED", "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER", "NO APPROPRIATE RECORDS IN BATCTRL FILE",
                                       "NO CLAIMS FOR THIS BATCH", "NO HEADER FOR CURRENT BATCH", "invalid month", "ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING", "INVALID BATCH TYPE", "WORK FILE EMPTY", "INVALID READ ON DOCTOR MASTER FILE"};
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

        private int lineCtr;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void main_line_section()
        {

        }

        public void mainline()
        {
            try
            {
                objWork_in_rec = null;
                objWork_in_rec = new Work_in_rec();

                Work_in_rec_Collection = null;
                Work_in_rec_Collection = new ObservableCollection<Work_in_rec>();

                objWork_out_rec = null;
                objWork_out_rec = new Work_out_rec();
                Work_out_rec_Collection = new ObservableCollection<Work_out_rec>();

                objWork_sort_rec = null;
                objWork_sort_rec = new Work_sort_rec();
                Work_sort_rec_Collection = new ObservableCollection<Work_sort_rec>();

                objr004_work_file = null;
                //objr004_work_file = new WriteFile(Directory.GetCurrentDirectory() + "\\r004wf");

                objr004_sort_work_file = null;
                objr004_sort_work_file = new WriteFile(Directory.GetCurrentDirectory() + "\\" + work_file_out_name);

                objr004_sort_work = null;
                objr004_sort_work = new WriteFile(Directory.GetCurrentDirectory() + "\\" + "r004_sort_work");

                //     perform aa0-initialization		thru aa0-99-exit.;
                aa0_initialization();
                aa0_99_exit();

                //     sort r004-sort-work;
                //       on ascending key wf-doctor-id,;
                // 		       wf-patient-name,;
                // 		       wf-service-date,;
                // 			wf-claim-id,;
                // 			wf-oma-cd;
                //       using r004-work-file;
                //       giving r004-sort-work-file.;

                foreach (var objWork_file_rec in Read_R004WF_SequentialFile().OrderBy(a => a.Wf_dept).ThenBy(b => b.Wf_doc_nbr).ThenBy(c => c.Wf_pat_surname).ThenBy(d => d.Wf_pat_acronym3).ThenBy(e => e.Wf_service_date_yy).ThenBy(f => f.Wf_service_date_mm).ThenBy(g => g.Wf_service_date_dd).ThenBy(h => h.Wf_claim_clinic_nbr_1_2).ThenBy(i => i.Wf_claim_doctor_nbr).ThenBy(j => j.Wf_claim_week).ThenBy(k => k.Wf_claim_day).ThenBy(l => l.Wf_claim_nbr).ThenBy(m => m.Wf_oma_cd).ThenBy(n => n.Wf_oma_suff))
                {
                   
                    string tmpRecord = Util.Str(objWork_file_rec.Wf_dept).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_doc_nbr).PadRight(3, ' ') +
                        Util.Str(objWork_file_rec.Wf_pat_surname).PadRight(6, ' ') +
                        Util.Str(objWork_file_rec.Wf_pat_acronym3).PadRight(3, ' ') +
                        Util.Str(objWork_file_rec.Wf_claim_clinic_nbr_1_2).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_claim_doctor_nbr).PadRight(3, ' ') +
                        Util.Str(objWork_file_rec.Wf_claim_week).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_claim_day).PadLeft(1, '0') +
                        Util.Str(objWork_file_rec.Wf_claim_nbr).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_pat_id_or_chart).PadRight(15, ' ') +
                        Util.Str(objWork_file_rec.Wf_agent_cd).PadLeft(1, '0') +
                        Util.Str(objWork_file_rec.Wf_adj_cd).PadRight(1, ' ') +
                        Util.Str(objWork_file_rec.Wf_payroll).PadRight(1, ' ') +

                       Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.Wf_claim_oma), 8, true).PadLeft(7, '0') +          // 05  wf-claim-oma				pic s9(5)v99.  ???

                      Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.Wf_claim_ohip), 8, true).PadLeft(7, '0') +         // 05  wf-claim-ohip				pic s9(5)v99. 
                        Util.Str(objWork_file_rec.Wf_service_date_yy).PadLeft(4, '0') +
                        Util.Str(objWork_file_rec.Wf_service_date_mm).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_service_date_dd).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_claim_date_sys_yy).PadLeft(4, '0') +
                        Util.Str(objWork_file_rec.Wf_claim_date_sys_mm).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_claim_date_sys_dd).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_diag_cd).PadLeft(3, '0') +
                        Util.Str(objWork_file_rec.Wf_oma_cd).PadRight(4, ' ') +
                        Util.Str(objWork_file_rec.Wf_oma_suff).PadRight(1, ' ') +
                        Util.Str(objWork_file_rec.Wf_nbr_serv).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_orig_clinic_nbr_1_2).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_orig_doc_nbr).PadRight(3, ' ') +
                        Util.Str(objWork_file_rec.Wf_orig_week).PadRight(2, ' ') +
                        Util.Str(objWork_file_rec.Wf_orig_day).PadRight(1, ' ') +
                        Util.Str(objWork_file_rec.Wf_orig_claim_nbr).PadLeft(2, '0') +
                        Util.Str(objWork_file_rec.Wf_ref_field).PadRight(9, ' ') +
                        Util.Str(objWork_file_rec.Wf_trans_cd).PadRight(1, ' ') +
                       Util.BlankWhenZero(Util.NumInt(Util.ConvertZone(Util.NumInt(objWork_file_rec.Wf_amt_tech_billed), 8, true)), 7) +   //Util.Str(objWork_file_rec.Wf_amt_tech_billed).PadLeft(7,'0') +            // 05  wf-amt-tech-billed			pic s9(5)v99. 
                        Util.Str(objWork_file_rec.Wf_adj_cd_sub_type).PadRight(1, ' ');

                    objr004_sort_work_file.AppendOutputFile(tmpRecord);
                }

                //     perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
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
                if (objr004_work_file != null)
                    objr004_work_file.CloseOutputFile();
                if (objr004_sort_work_file != null)
                    objr004_sort_work_file.CloseOutputFile();
                if (objr004_sort_work != null)
                    objr004_sort_work.CloseOutputFile();
            }
        }

        private void aa0_initialization()
        {
            //     accept sys-date			from date.;
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

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;
        }

        private void aa0_99_exit()
        {
            //     exit.;
        }

        private void az0_end_of_job()
        {
            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;

            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {
            //     exit.;
        }

        private void za0_common_error()
        {
            err_msg_comment = err_msg[err_ind];
            //     display err-msg-comment.;
            Console.WriteLine(err_msg_comment);
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
            sys_date_numeric = sys_date_numeric + 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {

            //     exit.;
        }

        #endregion
    }
}

