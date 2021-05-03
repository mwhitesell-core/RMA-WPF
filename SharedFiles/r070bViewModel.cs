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
using System.Text;

namespace rma.Views
{
    public class R070bViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: work_file_in
        private Work_in_rec objWork_in_rec = null;
        private ObservableCollection<Work_in_rec> Work_in_rec_Collection;

        // FD: work_file_out
        private Work_out_rec objWork_out_rec = null;
        private ObservableCollection<Work_out_rec> Work_out_rec_Collection;

        // FD: work_file_out	Copy : r070_claims_work_mstr.sd
        private Claims_work_rec objClaims_work_rec = null;
        private ObservableCollection<Claims_work_rec> Claims_work_rec_Collection;

        // FD: param_file	Copy : r070_param_file.fd
        private Param_file_rec objParam_file_rec = null;
        private ObservableCollection<Param_file_rec> Param_file_rec_Collection;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private string work_sort_name = "r070_work_sort";
        private string par_file_name = "r070_par_file";
        private int err_ind = 0;
        private string stat_work_sort = "0";
        private string common_status_file = "0";
        private string stat_work_in = "0";
        private string stat_work_out = "0";
        private string status_cobol_param_file = "0";
        private string stat_cobol_claims_work_mstr = "0";

        private string counters_grp;
        private int ctr_work_file_reads;
        private int ctr_sorted_work_file_reads;

        private string work_file_in_name_grp;
        private string filler = "r070_work_mstr_";
        private string work_file_in_clinic_nbr;

        private string work_file_out_name_grp;
        //private string filler = "r070_srt_work_mstr_";
        private string work_file_out_clinic_nbr;

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "NO PARAMETER FILE SUPPLIED";
        //private string filler = "NO WORK MASTER FOR THIS CLINIC";
        private string error_messages_r_grp;
        private string[] err_msg = { "", "NO PARAMETER FILE SUPPLIED", "NO WORK MASTER FOR THIS CLINIC" };
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

        private void err_work_sort_file_section()
        {

            // 	use after error procedure on work-sort.;
        }

        private void err_work_sort()
        {

            // 	stop "ERROR ACCESSING SORT WORK FILE".;
            common_status_file = stat_work_sort;
            // 	display common-status-file.;
            // 	stop run.;
        }

        private void err_work_file_in_section()
        {

            // 	use after error procedure on work-file-in.;
        }

        private void err_work_in()
        {

            // 	stop "ERROR ACCESSING WORK FILE".;
            common_status_file = stat_work_in;
            // 	display common-status-file.;
            // 	stop run.;
        }

        private void err_work_file_out_section()
        {

            // 	use after error procedure on work-file-out.;
        }

        private void err_work_out()
        {

            // 	stop "ERROR IN ACCESSING SORTED WORK FILE".;
            common_status_file = stat_work_out;
            // 	display common-status-file.;
            // 	stop run.;
        }

        private void end_declaratives()
        {

        }

        public void mainline()  //  _section()
        {

            try
            {
                //  perform aa0-initialization			thru aa0-99-exit.;
                aa0_initialization();
                aa0_99_exit();

                foreach (var objParam_file_rec in Param_file_rec_Collection)
                {
                    work_file_in_clinic_nbr = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2);
                    work_file_out_clinic_nbr = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2);

                    Claims_work_rec_Collection = Read_Claims_Work_Rec(work_file_in_clinic_nbr);

                    //     sort  work-sort;
                    //       on ascending key 	wk-sort-record-status,;
                    // 			wk-agent-cd,;
                    //       on descending key wk-age-category,;
                    //       on ascending key 	wk-clm-nbr;
                    //       using work-file-in;
                    //       giving work-file-out.;

                    WriteFile objWork_file_out = new WriteFile(Directory.GetCurrentDirectory() + "\\r070_srt_work_mstr_" + work_file_out_clinic_nbr);
                    StringBuilder str = null;
                    str = new StringBuilder();

                    //"r070_srt_work_mstr_"
                    foreach (var obj in Claims_work_rec_Collection.OrderBy(a => a.Wk_sort_record_status).ThenBy(b => b.Wk_agent_cd).ThenByDescending(c => c.Wk_age_category).ThenBy(d => d.Wk_clm_nbr))
                    {
                        str.Clear();
                        str.Append(Util.Str(obj.Wk_dept_nbr).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_sort_record_status).PadLeft(1, '0') +
                                         Util.Str(obj.Wk_agent_cd).PadLeft(1, '0') +
                                         Util.Str(obj.Wk_age_category).PadLeft(1, '0') +
                                         Util.Str(obj.Wk_pat_acronym).PadRight(9) +
                                         Util.Str(obj.Wk_pat_id_1).PadRight(3) +
                                         Util.Str(obj.Wk_pat_id_2).PadRight(12) +
                                         Util.Str(obj.Wk_clinic_nbr).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_doc_nbr).PadRight(3) +
                                         Util.Str(obj.Wk_week).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_day).PadLeft(1, '0') +
                                         Util.Str(obj.Wk_claim_nbr).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_ohip_stat_1).PadRight(1) +
                                         Util.Str(obj.Wk_ohip_stat_2).PadLeft(1, '0') +
                                         Util.Str(obj.Wk_sub_nbr).PadRight(1) +
                                         Util.ConvertZone(Util.NumInt(obj.Wk_oma_fee), 9,true) +   //  s9(6)v99
                                         Util.ConvertZone(Util.NumInt(obj.Wk_ohip_fee), 9,true) +   //  s9(6)v99
                                         Util.ConvertZone(Util.NumInt(obj.Wk_amount_paid), 9,true) +  //  s9(6)v99
                                         Util.ConvertZone(Util.NumInt(obj.Wk_balance_due), 9,true) +   //  s9(6)v99
                                         Util.Str(obj.Wk_period_end_yy).PadLeft(4, '0') +
                                         Util.Str(obj.Wk_period_end_mm).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_period_end_dd).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_ser_yy).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_ser_mm).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_ser_dd).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_day_old).PadRight(3) +
                                         Util.Str(obj.Wk_batch_nbr_1_2).PadLeft(2, '0') +
                                         Util.Str(obj.Wk_batch_nbr_4_9).PadRight(6) +
                                         Util.Str(obj.Wk_tape_submit_ind).PadRight(1) +
                                         Util.Str(obj.Wk_act_taken_1).PadRight(3) +
                                         Util.Str(obj.Wk_act_taken_2).PadLeft(8, '0'));

                        objWork_file_out.AppendOutputFile(str.ToString());
                    }
                    objWork_file_out.CloseOutputFile();
                    objWork_file_out = null;
                }

                //     perform az0-finalization			thru az0-99-exit.;
                az0_finalization();
                az0_99_exit();

            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            //     stop run.;
        }

        private void aa0_initialization()
        {
            Param_file_rec_Collection = Read_Param_file_rec_Collection();

            // open input param-file.;
            //     read param-file;
            //          at end;
            //           err_ind = 1;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to az0-finalization.;

            if (Param_file_rec_Collection.Count() == 0)
            {
                err_ind = 1;
                za0_common_error();
                za0_99_exit();
                az0_finalization();
                throw new Exception(endOfJob);
            }
            else
            {
                objParam_file_rec = Param_file_rec_Collection.FirstOrDefault();
            }

            work_file_in_clinic_nbr = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2);
            work_file_out_clinic_nbr = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2);

            //     accept sys-date				from date.;
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
        }

        private void aa0_99_exit()
        {
            //     exit.;
        }

        private void az0_finalization() //_section()
        {

            //     accept sys-time				from time.;
            //      close  param-file.;
            //     stop run.;
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
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        #endregion
    }
}

