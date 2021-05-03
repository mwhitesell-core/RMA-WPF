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
    public class R051bViewModel : CommonFunctionScr
    {
    
        #region FD Section
            	 // FD: r051_work_file
	 private Work_in_rec objWork_in_rec	= null;
	 private ObservableCollection<Work_in_rec> Work_in_rec_Collection;

	 // FD: r051_sort_work_file
	 private Work_out_rec objWork_out_rec = null;
	 private ObservableCollection<Work_out_rec> Work_out_rec_Collection;

	 // FD: r051_sort_work_file	Copy : r051_docrev_work_mstr.sd
	 private Work_sort_rec objWork_sort_rec = null;
	 private ObservableCollection<Work_sort_rec> Work_sort_rec_Collection;

	 // FD: r051_sort_work_file	Copy : r051_parm_file.fd
	 private Parm_file_rec objParm_file_rec = null;
	 private ObservableCollection<Parm_file_rec> Parm_file_rec_Collection;

     private ObservableCollection<r051_work_rec> Work_file_rec_Collection;
        private WriteFile objSort_Work_File;

        #endregion
        
        #region Properties
             
        #endregion
        
        #region Working Storage Section
            	 private int err_ind = 0;
	 private string print_file_name = "r051";
	 private string option;
	 private int parm_rec_nbr;
	 private string work_file_in_name = "r051wf";
	 private string work_file_out_name = "r051_sort_work_mstr";
	 private string common_status_file;
	 private string status_sort_file;
	 private string status_parm_file = "0";

	 private string counters_grp;
	 private int ctr_work_file_writes;
	 private int ctr_work_file_reads;

	 private string error_message_table_grp;
	 private string error_messages_grp;
	 /*private string filler = "invalid reply";
	 private string filler = "INVALID READ ON PARAMETER FILE";
	 private string filler = "INVALID WRITE TO PARAMETER FILE";
	 private string filler = "INVALID PARAMETER STATUS";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***";
	 private string filler = "*** CAN BE RE-USED ***"; */
	 private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "INVALID READ ON PARAMETER FILE" , "INVALID WRITE TO PARAMETER FILE" , "INVALID PARAMETER STATUS", "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***" ,
                                       "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***", "*** CAN BE RE-USED ***"};
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
	 private string filler;

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
        private StringBuilder str;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void main_line_section()
	 {

	 }

	 public void mainline()
	 {
            try {

                objWork_in_rec = new Work_in_rec();
                Work_in_rec_Collection = new ObservableCollection<Work_in_rec>();

                objWork_out_rec = new Work_out_rec();
                Work_out_rec_Collection = new ObservableCollection<Work_out_rec>();

                objWork_sort_rec = new Work_sort_rec();
                Work_sort_rec_Collection = new ObservableCollection<Work_sort_rec>();

                objParm_file_rec = new Parm_file_rec();
                Parm_file_rec_Collection = Read_R051_parm_file();

                Work_file_rec_Collection = Read_R051_Work_Rec_SequentialFile();

                objSort_Work_File = new WriteFile(Directory.GetCurrentDirectory() + "\\" + work_file_out_name);

                //  perform aa0-initialization		thru aa0-99-exit.;
                aa0_initialization();
                aa0_99_exit();

                //  perform ab0-processing		thru ab0-99-exit.;
                ab0_processing();
                ab0_99_exit();

                //  perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
                az0_10_abend();
                az0_99_exit();

                //     stop run.;
            } catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            finally
            {
                if (objSort_Work_File != null)
                    objSort_Work_File.CloseOutputFile();
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

            //  perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            //     open i-o	parameter-file.;

            parm_rec_nbr = 1;

            //  read parameter-file;
            //    	invalid key;
            //           err_ind = 2;
            // 	         perform za0-common-error	thru za0-99-exit;
            // 	         go to az0-10-abend.;

            if (Parm_file_rec_Collection.Count() > 0)
            {
                objParm_file_rec = Parm_file_rec_Collection[0];
            }
            else
            {
                err_ind = 2;
                //  perform za0-common-error	thru za0-99-exit.;
                za0_common_error();
                za0_99_exit();
            }
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
            run_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            objParm_file_rec.Parm_program_nbr = "R051b";

            //     add 1				to parm-status.;
            objParm_file_rec.Parm_status++;

            //  rewrite parm-file-rec;
            //    	invalid key;
            //         err_ind = 3;
            // 	       perform za0-common-error	thru	za0-99-exit.;

            //todo: Verify the legacy if it's a linefeed or continious record.  And this should update the TEXT FILE : r051_parm_file NOT APPENDING A RECORD.
            Update_R051_Parm_File(Parm_file_rec_Collection );  //Todo Verify the values after updating the objParm_file_rec.
        }

	 private void az0_10_abend()
	 {

            //     close	parameter-file.;
            //     stop run.;
            throw new Exception(endOfJob);
	 }

	 private void az0_99_exit()
	 {

		 //     exit.;
	 }

	 private void ab0_processing()
	 {

            // if parm-status = zero then;            
            // 	   sort r051-sort-work;
            // 	    	on ascending key	wf-sort-key;
            // 		    using r051-work-file;
            // 		    giving r051-sort-work-file;
            //  else if parm-status = 2 then;            
            // 	    sort r051-sort-work;
            // 		    on ascending key	wf-dept,;
            // 					wf-class-code;
            // 					wf-oma-cd;
            // 					wf-doc-nbr;
            // 		    using r051-work-file;
            // 		    giving r051-sort-work-file;
            // 	else;
            //      err_ind = 4;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-10-abend.;

            str = new StringBuilder();

            if (objParm_file_rec.Parm_status == 0)
            {
               
                 foreach (var obj in Work_file_rec_Collection.OrderBy(a => a.wf_dept).ThenBy(b => b.wf_class_code).ThenBy(c => c.wf_doc_nbr).ThenBy(d => d.wf_oma_code_ltr).ThenBy(e => e.filler))               
                {
                      str.Clear();
                  

                     str.Append(Util.Str(obj.wf_dept).PadLeft(2, '0') +
                           Util.Str(obj.wf_class_code).PadRight(1) +
                           Util.Str(obj.wf_doc_nbr).PadRight(3, '0') +
                           Util.Str(obj.wf_oma_cd).PadRight(5, '0') +
                           Util.ConvertZone(obj.wf_mtd_svcs, 9, true) +
                           obj.wf_mtd_amt +
                           Util.ConvertZone(obj.wf_ytd_svcs, 9, true) +
                           obj.wf_ytd_amt);  

                    objSort_Work_File.AppendOutputFile(str.ToString());
                }                
            }
            else if (objParm_file_rec.Parm_status == 2)
            {
                str = new StringBuilder();
                foreach (var obj in Work_file_rec_Collection.OrderBy(a => a.wf_dept).ThenBy(b => b.wf_class_code).ThenBy(c => c.wf_oma_code_ltr).ThenBy(d => d.filler).ThenBy(e => e.wf_doc_nbr))
                {
                    str.Clear();

                    str.Append(Util.Str(obj.wf_dept).PadLeft(2, '0') +
                              Util.Str(obj.wf_class_code).PadRight(1) +
                              Util.Str(obj.wf_doc_nbr).PadRight(3, '0') +
                              Util.Str(obj.wf_oma_cd).PadRight(5, '0') +
                              Util.ConvertZone(obj.wf_mtd_svcs, 9, true) +
                              obj.wf_mtd_amt +
                              Util.ConvertZone(obj.wf_ytd_svcs, 9, true) +
                              obj.wf_ytd_amt);
                    objSort_Work_File.AppendOutputFile(str.ToString());
                }
                
            }
            else
            {
                 err_ind = 4;
                //  perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-10-abend.;
                az0_10_abend();
                return;

            }
        }

	 private void ab0_99_exit()
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
	 }

	 // y2k_default_sysdate_century.rtn
	 private void y2k_default_sysdate_exit()
	 {

		 //     exit.;
	 }

        #endregion
    }
}


