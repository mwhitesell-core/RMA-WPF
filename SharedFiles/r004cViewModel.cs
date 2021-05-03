using System;
using System.Linq;
using System.Collections.ObjectModel;
using rma.Cobol;
using RmaDAL;
using System.IO;

namespace rma.Views
{
    public class R004cViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private Print_record objPrint_record = null;
        private ObservableCollection<Print_record> Print_record_Collection;

        // FD: r004_work_file	Copy : r004_claims_work_mstr.fd
        private R004_Work_file_rec objWork_file_rec = null;
        private ObservableCollection<R004_Work_file_rec> Work_file_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private F070_DEPT_MSTR objDept_mstr_rec = null;
        private ObservableCollection<F070_DEPT_MSTR> Dept_mstr_rec_Collection;

        // FD: parameter_file	Copy : r004_parm_file.fd
        private Parm_file_rec objParm_file_rec = null;
        private ObservableCollection<Parm_file_rec> Parm_file_rec_Collection;

        private ReportPrint objPrint_File = null;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name = "r004";
        private string option;
        private int max_nbr_lines = 60;
        private int ctr_lines = 70;
        private string ws_i_o_pat_ind;
        private decimal batch_total = 0;
        private decimal batch_diff = 0;
        private decimal ws_fee_ohip;
        private int ws_nbr_serv;
        private int nbr_rec_processed;
        private decimal ws_rev_calcd = 0;
        private decimal rev_calcd_total = 0;
        private decimal update_amt_total = 0;
        private decimal diff_total = 0;
        private int ws_agent = 0;
        private int ss_agent = 0;
        private int ss_oma_ohip = 0;
        private int ss_trans_type = 0;
        private string hold_clmhdr_batch_nbr;
        private int hold_clmhdr_claim_nbr;
        private int sel_month;
        private string const_mstr_rec_nbr;
        private string feedback_claims_mstr;
        private string feedback_docrev_mstr;
        private string feedback_batctrl_file;
        private string feedback_iconst_mstr;
        private string blank_line = "";
        private string ws_print_auto = "N";
        private string eof_batctrl_file = "N";
        private string eof_claims_dtl = "N";
        private string eof_claims_mstr = "N";
        private string eof_doctor_mstr = "N";
        private string eof_work_file = "N";
        private string new_header = "N";
        private int sub1 = 0;
        private string common_status_file;
        private string status_cobol_batctrl_file = "0";
        private string status_cobol_claims_mstr = "0";
        private string status_cobol_dept_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_prt_file = "0";
        private string status_sort_file;
        private int sel_clinic_nbr;
        private int claims_occur;
        private string flag_rec;
        private string valid_rec;
        private string invalid_rec;

        private string prev_doc_nbr_grp;
        private int prev_dept;
        private string prev_doctor_nbr;

        private string totals_table_grp;
        private string[] oma_or_ohip = new string[3];
        private string[,] totals = new string[3, 7];
        private decimal[,,] doc_totals = new decimal[3, 7, 12];
        private decimal[,,] dept_totals = new decimal[3, 7, 12];
        private decimal[,,] grand_totals = new decimal[3, 7, 12];

        private string adj_totals_table_grp;
        private string[] adj_totals = new string[5];
        private string[,] adj_agent_breakdown = new string[5, 12];
        private decimal[,] adj_doc_totals = new decimal[5, 12];
        private decimal[,] adj_dept_totals = new decimal[5, 12];
        private decimal[,] adj_grand_totals = new decimal[5, 12];

        private string counters_grp;
        private int ctr_claims_work_reads;
        private int ctr_claims_mstr_reads;
        private int ctr_work_file_writes;
        private int ctr_work_file_reads;
        private int ctr_doc_mstr_reads;
        private int ctr_pages;

        private string error_message_table_grp;
        private string error_messages_grp;
        /* private string filler = "invalid reply";
         private string filler = "NO PARAMETER FILE SUPPLIED";
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
         private string filler = "INVALID READ ON DOCTOR MASTER FILE";
         private string filler = "INVALID READ ON CLAIMS WORK FILE";
         private string filler = "INVALID WF-ADJ-CD-SUB-TYPE IE NOT M OR A";
         private string filler = "DEPARTMENT MASTER READ ERROR";*/
        private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "NO PARAMETER FILE SUPPLIED", "invalid reply", "NO BATCTRL FILE SUPPLIED", "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER", "NO APPROPRIATE RECORDS IN BATCTRL FILE",
                                   "NO CLAIMS FOR THIS BATCH", "NO HEADER FOR CURRENT BATCH", "invalid month", "ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING", "INVALID BATCH TYPE",
                                   "WORK FILE EMPTY", "INVALID READ ON DOCTOR MASTER FILE", "INVALID READ ON CLAIMS WORK FILE", "INVALID WF-ADJ-CD-SUB-TYPE IE NOT M OR A", "DEPARTMENT MASTER READ ERROR"};

        private string err_msg_comment_grp;
        private string err_msg_key_type;
        private string err_msg_key;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

        //private string h1_head_grp;
        private string filler = "r004  /";
        private int h1_clinic_nbr;
        //private string filler = "";
        //private string filler = "DATE";
        private string h1_date_grp;
        private int h1_yy;
        //private string filler = "/";
        private int h1_mm;
        //private string filler = "/";
        private int h1_dd;
        //private string filler = "";
        //private string filler = "* MONTHLY CLAIMS AND ADJUSTMENTS TRANSACTION SUMMARY *";   //todo....
        //private string filler = "page ";
        private int h1_page_nbr;

        //private string h2_head_grp;
        //private string filler = "";
        private string h2_clinic_name;
        //private string filler = "";
        //private string filler = "department #";
        private int h2_dept_nbr;
        //private string filler = "";
        private string h2_dept_name;

        //private string h3_head_grp;
        //private string filler = "";
        //private string filler = "DOCTOR-";
        private string h3_doc_nbr;
        //private string filler = "";
        private string h3_doc_name;
        //private string filler = "";

        //private string h4_head_grp;
        //private string filler = "";
        //private string filler = "PATIENT     CLAIM   PATIENT ID/  AGENT";
        //private string filler = " ADJ/or      OHIP    ADJUSTMENT SERVICE";
        //private string filler = "CLAIM   DIAG  OMA  #OF  BATCH     FORM#";

        //private string h5_head_grp;
        //private string filler = "";
        //private string filler = "NAME       NUMBER  CHART NUMBER  CODE";
        //private string filler = " SOURCE       FEE      AMOUNT     DATE";
        //private string filler = "DATE   CODE  CODE SRV  NUMBER    NOTE";

        //private string h6_head_grp;
        //private string filler = " doctor";
        private string h6_doc_nbr;
        //private string filler = "";

        //private string h7_head_grp;
        //private string filler = "DEPARTMENTAL SUMMARY  DEPT #";
        private int h7_dept_nbr;
        //private string filler = "";

        //private string h8_head_grp;
        //private string filler = "";
        private string h8_clinic_name;

        //private string h9_head_grp;
        //private string filler = "-----------------------------------------------------";
        private string h9_head_msg;
        //private string filler = "-----------------------------------------------------";

        //private string h10_head_grp;
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
        private string filler = "9";
        private string filler = "TOTAL"; */

        //private string print_line_grp;

        private string l1_print_line_grp;
        private string l1_pat_surname;
        private string l1_pat_acronym3;
        private string l1_clmhdr_claim_nbr_grp;
        private int l1_claim_clinic1;
        private string l1_claim_doc_nbr;
        private int l1_claim_week;
        private int l1_claim_day;
        private int l1_claim_nbr;
        //private string filler;
        private string l1_patient_id;
        //private string filler;
        private int l1_agent_code;
        //private string filler;
        private string l1_a_m_adj_grp;
        private string l1_adj_code;
        private string l1_filler_slash;
        private string l1_adj_cd_sub_type;
        //private string filler = "";
        private decimal l1_tot_claim_ohip;
        //private string filler = "";
        private decimal l1_tot_claim_ohip_adj;
        private string l1_tot_claim_ohip_adj_r;
        //private string filler;
        private string l1_service_date_grp;
        private int l1_service_date_yy;
        private string l1_slash1;
        private int l1_service_date_mm;
        private string l1_slash2;
        private int l1_service_date_dd;
        //private string filler;
        private string l1_claim_date_grp;
        private int l1_claim_date_yy;
        private string l1_slash3;
        private int l1_claim_date_mm;
        private string l1_slash4;
        private int l1_claim_date_dd;
        //private string filler;
        private int l1_diag_cd;
        //private string filler;
        private string l1_oma_code_grp;
        private string l1_oma_cd;
        private string l1_oma_suff;
        //private string filler;
        private int l1_nbr_of_services;
        //private string filler;
        private string l1_batch_nbr_grp;
        private int l1_batch_clinic1;
        private string l1_batch_doc_nbr;
        private string l1_batch_week;
        private string l1_batch_day;
        //private string filler;
        private string l1_ref_field;
        //private string l2_print_line_grp;
        private string l2_type;
        private string[] l2_ohip_totals_r = new string[11];
        private decimal[] l2_ohip_totals = new decimal[11];
        private decimal l2_agent_total;
        //private string l3_print_line_grp;
        //private string filler;
        private string l3_ohip;
        //private string l4_print_line_grp;
        //private string filler;
        private string l4_type;
        private decimal l4_adj_tot;

        //private string l5_print_line_grp;
        //private string filler = "            -------    -------    -------    -------";
        //private string filler = "    -------    -------    -------    -------    -------";
        //private string filler = "    -------    ----------";
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
        private int ctr;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private void err_doc_mstr()
        {
            common_status_file = status_cobol_doc_mstr;
            //     display common-status-file.;
            //     stop "ERROR IN ACCESSING DOCTOR MASTER".;
        }

        private void err_dept_mstr_file_section()
        {

            //     use after standard error procedure on dept-mstr.;
        }

        private void err_dept_mstr()
        {

            //     stop "ERROR IN ACCESSING DEPT MASTER ".;
            common_status_file = status_cobol_dept_mstr;
            //     display common-status-file.;
            //     stop run.;
        }

        private void end_declaratives()
        {

        }

        private void main_line_section()
        {

        }
        public void mainline(string print_auto)
        {            
            try
            {
                ws_print_auto = print_auto;

                objPrint_File = null;
                objPrint_File = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

                objWork_file_rec = new R004_Work_file_rec();
                Work_file_rec_Collection = Read_R004WF_After_Sorted_SequentialFile();

                objPrint_record = null;
                objPrint_record = new Print_record();

                objDoc_mstr_rec = null;
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objDept_mstr_rec = new F070_DEPT_MSTR();
                Dept_mstr_rec_Collection = new ObservableCollection<F070_DEPT_MSTR>();

                objParm_file_rec = null;
                objParm_file_rec = new Parm_file_rec();
                Parm_file_rec_Collection = new ObservableCollection<Parm_file_rec>();

                Parm_file_rec_Collection = Read_Parm_File_SequentialFile();

                //     perform aa0-initialization		thru aa0-99-exit.;        
                aa0_initialization();
                foreach (var obj in Parm_file_rec_Collection)
                {  // Note: not sure about the loop on this...pls. verify..??? 
                    objParm_file_rec = obj;
                    aa1_scr_reply_edit();
                    aa0_99_exit();

                    //     perform ab2-create-report		thru ab2-99-exit.;
                    ab2_create_report();
                    ab2_99_exit();
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
                if (objPrint_File != null)
                    objPrint_File.Close();
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
        }

        private void aa1_scr_reply_edit()
        {            

            //  accept  ws-print-auto;

            // if ws-print-auto = "Y"  or ws-print-auto = "N" then; 
            if (Util.Str(ws_print_auto).ToUpper().Equals("Y") || Util.Str(ws_print_auto).ToUpper().Equals("N"))
            {
                //    next sentence;
            }
            else
            {
                //      go to aa1-scr-reply-edit.;
                aa1_scr_reply_edit();
                return;
            }

            //     open input	r004-work-file;
            // 		dept-mstr;
            // 		parameter-file;
            // 		doc-mstr.;
            //     open output print-file.;

            //counters = 0;
            ctr_claims_work_reads = 0;
            ctr_claims_mstr_reads = 0;
            ctr_work_file_writes = 0;
            ctr_work_file_reads = 0;
            ctr_doc_mstr_reads = 0;
            ctr_pages = 0;


            ctr_pages = 1;

            //print_line = "";
            Initialize_PrintLine();


            objWork_file_rec = new R004_Work_file_rec();

            oma_or_ohip = new string[3];
            totals = new string[3, 7];
            doc_totals = new decimal[3, 7, 12];
            dept_totals = new decimal[3, 7, 12];
            grand_totals = new decimal[3, 7, 12];

            adj_totals = new string[5];
            adj_agent_breakdown = new string[5, 12];
            adj_doc_totals = new decimal[5, 12];
            adj_dept_totals = new decimal[5, 12];
            adj_grand_totals = new decimal[5, 12];

            //     read parameter-file;
            //  	at end;
            //err_ind = 2;
            //  	    perform za0-common-error	thru za0-99-exit;
            //  	    go to az0-end-of-job.;           

            h1_clinic_nbr = Util.NumInt(objParm_file_rec.Parm_clinic_nbr);
            h2_clinic_name = Util.Str(objParm_file_rec.Parm_clinic_name);
            h8_clinic_name = Util.Str(objParm_file_rec.Parm_clinic_name);

            h1_yy = Util.NumInt(objParm_file_rec.Parm_ped_yy);
            h1_mm = Util.NumInt(objParm_file_rec.Parm_ped_mm);
            h1_dd = Util.NumInt(objParm_file_rec.Parm_ped_dd);
        }

        private void aa0_99_exit()
        {            
            //     exit.;
        }

        private void az0_end_of_job()
        {            

            //     close r004-work-file;
            //           dept-mstr;
            // 	  parameter-file;
            // 	  doc-mstr;
            // 	  print-file.;
            //     accept sys-time			from time.;
            //     stop run.;

            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {            
            //     exit.;
        }

        private void ab2_create_report()
        {            

            //  read  r004-work-file at end;            
            //        err_ind = 12;
            // 	      perform za0-common-error	thru	za0-99-exit;
            // 	      go to az0-end-of-job.;

            //     add 1				to	ctr-work-file-reads.;

            if (Work_file_rec_Collection.Count() == 0)
            {
                err_ind = 12;
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }
            else
            {
                if (ctr_work_file_reads >= Work_file_rec_Collection.Count())
                {
                    az0_end_of_job();
                    return;
                }
                else
                {
                    objWork_file_rec = Work_file_rec_Collection[ctr_work_file_reads];
                    ctr_work_file_reads++;
                }
            }

            // prev_doc_nbr = objWork_file_rec.Wf_doctor_id; 
            prev_doc_nbr_grp = Util.Str(objWork_file_rec.Wf_dept) + Util.Str(objWork_file_rec.Wf_doc_nbr);
            prev_dept = Util.NumInt(objWork_file_rec.Wf_dept);
            prev_doctor_nbr = Util.Str(objWork_file_rec.Wf_doc_nbr);

            //  perform kb0-read-doc-mstr		thru	kb0-99-exit.;
            kb0_read_doc_mstr();
            kb0_99_exit();

            // perform ki0-read-dept-mstr          thru    ki0-99-exit.;
            ki0_read_dept_mstr();
            ki0_99_exit();

            h3_doc_nbr = objWork_file_rec.Wf_doc_nbr;
            h3_doc_name = objDoc_mstr_rec.DOC_NAME;
            h2_dept_nbr = objWork_file_rec.Wf_dept;
            h2_dept_name = objDept_mstr_rec.DEPT_NAME;

            //     perform ja0-build-write-report	thru	ja0-99-exit;
            // 		until eof-work-file = "Y".;
            do
            {
                ja0_build_write_report();
                ja0_99_exit();
            } while (!eof_work_file.ToUpper().Equals("Y"));

            //     perform kh0-write-grand-totals	thru	kh0-99-exit.;
            kh0_write_grand_totals();
            kh0_99_exit();
        }

        private void ab2_99_exit()
        {            

            //     exit.;
        }

        private void ja0_build_write_report()
        {            

            //     perform jb0-build-write-dept-rprt	thru	jb0-99-exit;
            // 	until   wf-dept   not = prev-dept;
            // 	     or eof-work-file = "Y".;

            do
            {
                jb0_build_write_dept_rprt();
                jb0_99_exit();
            } while (objWork_file_rec.Wf_dept == prev_dept && !eof_work_file.ToUpper().Equals("Y"));

            //     perform jc0-write-doc-totals	thru	jc0-99-exit.;
            jc0_write_doc_totals();
            jc0_99_exit();

            //     perform kf0-obtain-dept-ttls	thru	kf0-99-exit;
            // 	varying sub1;
            // 	from    1 by 1;
            // 	until   sub1 > 2.;

            sub1 = 1;
            do
            {
                kf0_obtain_dept_ttls();
                kf0_99_exit();
                sub1++;
            } while (sub1 <= 2);

            //     perform kf1-obtain-adj-dept-ttls	thru	kf1-99-exit;
            // 	varying sub1;
            // 	from    1 by 1;
            // 	until   sub1 > 4.;

            sub1 = 1;
            do
            {
                kf1_obtain_adj_dept_ttls();
                kf1_99_exit();
                sub1++;
            } while (sub1 <= 4);

            //     perform kg0-write-dept-totals	thru	kg0-99-exit.;
            kg0_write_dept_totals();
            kg0_99_exit();

            //     perform la0-zero-to-dept-ttls	thru	la0-99-exit;
            // 	varying sub1;
            // 	from    1 by 1;
            // 	until   sub1 > 6.;

            sub1 = 1;
            do
            {
                la0_zero_to_dept_ttls();
                la0_99_exit();
                sub1++;
            } while (sub1 <= 6);

            //     perform lc0-zero-to-adj-dept-ttls	thru	lc0-99-exit;
            // 	varying ss-agent;
            // 	from    1 by 1;
            // 	until   ss-agent > 11.;

            ss_agent = 1;
            do
            {
                lc0_zero_to_adj_dept_ttls();
                lc0_99_exit();
                ss_agent++;
            } while (ss_agent <= 11);

            // if eof-work-file not = "Y";
            //    h2_dept_nbr = objWork_file_rec.wf_dept;
            //    prev_doc_nbr = objWork_file_rec.wf_doctor_id;
            // 	  perform kb0-read-doc-mstr	thru	kb0-99-exit;
            //    h3_doc_nbr = objWork_file_rec.wf_doc_nbr;
            //    h3_doc_name = objDoc_mstr_rec.doc_name;
            //   perform ki0-read-dept-mstr      thru    ki0-99-exit;
            //   h2_dept_name = objDept_mstr_rec.dept_name;


            if (!eof_work_file.ToUpper().Equals("Y"))
            {
                h2_dept_nbr = objWork_file_rec.Wf_dept;
                prev_doc_nbr_grp = Util.Str(objWork_file_rec.Wf_dept) + Util.Str(objWork_file_rec.Wf_doc_nbr);
                prev_dept = Util.NumInt(objWork_file_rec.Wf_dept);
                prev_doctor_nbr = Util.Str(objWork_file_rec.Wf_doc_nbr);

                //perform kb0-read-doc-mstr	thru	kb0-99-exit;
                kb0_read_doc_mstr();
                kb0_99_exit();

                h3_doc_nbr = Util.Str(objWork_file_rec.Wf_doc_nbr);
                h3_doc_name = Util.Str(objDoc_mstr_rec.DOC_NAME);

                // perform ki0-read-dept-mstr      thru    ki0-99-exit
                ki0_read_dept_mstr();
                ki0_99_exit();
                h2_dept_name = Util.Str(objDept_mstr_rec.DEPT_NAME);
            }
        }

        private void ja0_99_exit()
        {            
            //     exit.;
        }

        private void jb0_build_write_dept_rprt()
        {            

            // if wf-doctor-id not = prev-doc-nbr then;           
            // 	  perform jc0-write-doc-totals	thru	jc0-99-exit;
            //    prev_doctor_nbr = objWork_file_rec.wf_doc_nbr;
            //    h3_doc_nbr = objWork_file_rec.wf_doc_nbr;
            // 	  perform kb0-read-doc-mstr	thru	kb0-99-exit;
            //h3_doc_name = objDoc_mstr_rec.doc_name;

           
            if ( Util.Str(Util.Str(objWork_file_rec.Wf_dept) + Util.Str(objWork_file_rec.Wf_doc_nbr)) != prev_doc_nbr_grp)
            {
                //perform jc0-write-doc-totals	thru	jc0-99-exit;
                jc0_write_doc_totals();
                jc0_99_exit();

                prev_doc_nbr_grp = Util.Str(objWork_file_rec.Wf_dept) + Util.Str(objWork_file_rec.Wf_doc_nbr);
                prev_doctor_nbr = objWork_file_rec.Wf_doc_nbr;
                h3_doc_nbr = objWork_file_rec.Wf_doc_nbr;

                //  perform kb0-read-doc-mstr	thru	kb0-99-exit;
                kb0_read_doc_mstr();
                kb0_99_exit();

                h3_doc_name =  Util.Str(objDoc_mstr_rec.DOC_NAME);
            }


            //     perform ka0-build-prt-line-and-ttls	thru	ka0-99-exit.;
            ka0_build_prt_line_and_ttls();            
            ka0_99_exit();

            // if ws-print-auto = "N" and wf-adj-cd = "B" and wf-adj-cd-sub-type = "A"  then;            
            //    print_line = "";
            // else;
            //     	perform kc0-write-print-line	thru	kc0-99-exit.;

            if (ws_print_auto.ToUpper().Equals("N") && objWork_file_rec.Wf_adj_cd.ToUpper().Equals("B") && objWork_file_rec.Wf_adj_cd_sub_type.ToUpper().Equals("A"))
            {
                //print_line_grp
                Initialize_PrintLine();
            }
            else
            {
                //perform kc0-write - print - line    thru kc0-99 - exit.;
                kc0_write_print_line();
                kc0_99_exit();
            }

            // read  r004-work-file at end;            
            //      eof_work_file = "Y";
            // 	    go to jb0-99-exit.;
            //     add 1				to	ctr-work-file-reads.;

            if (Work_file_rec_Collection.Count() == 0)
            {
                eof_work_file = "Y";
                jb0_99_exit();
                return;
            }
            else
            {
                if (ctr_work_file_reads >= Work_file_rec_Collection.Count())
                {
                    objWork_file_rec = new R004_Work_file_rec();
                    eof_work_file = "Y";
                    jb0_99_exit();
                    return;
                }
                else
                {
                    objWork_file_rec = Work_file_rec_Collection[ctr_work_file_reads];
                    ctr_work_file_reads++;
                }
            }

        }

        private void jb0_99_exit()
        {            
            //    exit.;
        }

        private void jc0_write_doc_totals()
        {            

            //     perform kd0-obtain-doc-totals	thru	kd0-99-exit;
            // 	varying sub1;
            // 	from    1 by 1;
            // 	until   sub1 > 2.;

            sub1 = 1;
            do
            {
                kd0_obtain_doc_totals();
                kd0_99_exit();
                sub1++;
            } while (sub1 <= 2);

            //     perform kd1-obtain-adj-doc-totals	thru	kd1-99-exit;
            // 	varying sub1;
            // 	from    1 by 1;
            // 	until   sub1 > 4.;

            sub1 = 1;
            do
            {
                kd1_obtain_adj_doc_totals();
                kd1_99_exit();
                sub1++;
            } while (sub1 <= 4);

            //     perform ke0-print-doc-totals	thru	ke0-99-exit.;
            //     perform lb0-zero-to-doc-ttls	thru	lb0-99-exit;
            // 	varying sub1;
            // 	from    1 by 1;
            // 	until   sub1 > 6.;

            ke0_print_doc_totals();
            ke0_99_exit();

            sub1 = 1;
            do
            {
                // perform lb0-zero - to - doc - ttls    thru lb0-99 - exit;
                lb0_zero_to_doc_ttls();
                lb0_99_exit();
                sub1++;
            } while (sub1 <= 6);

            //     perform ld0-zero-to-adj-doc-ttls	thru	ld0-99-exit;
            // 	varying ss-agent;
            // 	from    1 by 1;
            // 	until   ss-agent > 11.;

            ss_agent = 1;
            do
            {
                ld0_zero_to_adj_doc_ttls();
                ld0_99_exit();
                ss_agent++;
            } while (ss_agent <= 11);
        }

        private void jc0_99_exit()
        {            
            //     exit.;
        }

        private void ka0_build_prt_line_and_ttls()
        {            

            l1_pat_surname = objWork_file_rec.Wf_pat_surname;
            l1_pat_acronym3 = objWork_file_rec.Wf_pat_acronym3;

            // if wf-trans-cd not  = " "  then;            
            //     l1_claim_clinic1 = objWork_file_rec.wf_claim_clinic_nbr_1_2;
            //     l1_claim_doc_nbr = objWork_file_rec.wf_claim_doctor_nbr;
            //     l1_claim_week = objWork_file_rec.wf_claim_week;
            //     l1_claim_day = objWork_file_rec.wf_claim_day;
            //     l1_claim_nbr = objWork_file_rec.wf_claim_nbr;
            // else;
            //     l1_claim_clinic1 = objWork_file_rec.wf_orig_clinic_nbr_1_2;
            //     l1_claim_doc_nbr = objWork_file_rec.wf_orig_doc_nbr;
            //     l1_claim_week = objWork_file_rec.wf_orig_week;
            //     l1_claim_day = objWork_file_rec.wf_orig_day;
            //     l1_claim_nbr = objWork_file_rec.wf_orig_claim_nbr;

            if (!string.IsNullOrWhiteSpace(objWork_file_rec.Wf_trans_cd))
            {
                l1_claim_clinic1 = objWork_file_rec.Wf_claim_clinic_nbr_1_2;
                l1_claim_doc_nbr = objWork_file_rec.Wf_claim_doctor_nbr;
                l1_claim_week = objWork_file_rec.Wf_claim_week;
                l1_claim_day = objWork_file_rec.Wf_claim_day;
                l1_claim_nbr = objWork_file_rec.Wf_claim_nbr;
            }
            else
            {
                l1_claim_clinic1 = objWork_file_rec.Wf_orig_clinic_nbr_1_2;
                l1_claim_doc_nbr = objWork_file_rec.Wf_orig_doc_nbr;
                l1_claim_week = Util.NumInt(objWork_file_rec.Wf_orig_week);
                l1_claim_day = Util.NumInt(objWork_file_rec.Wf_orig_day);
                l1_claim_nbr = objWork_file_rec.Wf_orig_claim_nbr;
            }


            // if wf-pat-id-or-chart = zeros then;            
            //    l1_patient_id = "";
            //  else;
            //    l1_patient_id = objWork_file_rec.wf_pat_id_or_chart;

            if (Util.NumLongInt(objWork_file_rec.Wf_pat_id_or_chart) == 0)
            {
                l1_patient_id = "";
            }
            else
            {
                l1_patient_id = objWork_file_rec.Wf_pat_id_or_chart;
            }

            objWork_file_rec.Wf_agent_cd_adj = Util.Str(objWork_file_rec.Wf_agent_cd) + Util.Str(objWork_file_rec.Wf_adj_cd);
            l1_agent_code = Util.NumInt(objWork_file_rec.Wf_agent_cd_adj);
            l1_service_date_yy = objWork_file_rec.Wf_service_date_yy;
            l1_service_date_mm = objWork_file_rec.Wf_service_date_mm;
            l1_service_date_dd = objWork_file_rec.Wf_service_date_dd;
            l1_claim_date_yy = objWork_file_rec.Wf_claim_date_sys_yy;
            l1_claim_date_mm = objWork_file_rec.Wf_claim_date_sys_mm;
            l1_claim_date_dd = objWork_file_rec.Wf_claim_date_sys_dd;
            l1_slash1 = "/";
            l1_slash2 = "/";
            l1_slash3 = "/";
            l1_slash4 = "/";

            l1_diag_cd = objWork_file_rec.Wf_diag_cd;

            objWork_file_rec.Wf_oma_code = Util.Str(objWork_file_rec.Wf_oma_cd) + Util.Str(objWork_file_rec.Wf_oma_suff);

            l1_oma_cd = objWork_file_rec.Wf_oma_cd;
            l1_oma_suff = objWork_file_rec.Wf_oma_suff;
            l1_oma_code_grp = l1_oma_cd + l1_oma_suff;

            l1_nbr_of_services = objWork_file_rec.Wf_nbr_serv;

            l1_batch_clinic1 = objWork_file_rec.Wf_orig_clinic_nbr_1_2;
            l1_batch_doc_nbr = objWork_file_rec.Wf_orig_doc_nbr;
            l1_batch_week = objWork_file_rec.Wf_orig_week;
            l1_batch_day = objWork_file_rec.Wf_orig_day;
            l1_ref_field = objWork_file_rec.Wf_ref_field;

            // if wf-trans-cd =   " " or "M" then;            
            //    l1_tot_claim_ohip = objWork_file_rec.wf_claim_ohip;
            //  else;
            //    l1_tot_claim_ohip_adj = objWork_file_rec.wf_claim_ohip;

            if (string.IsNullOrWhiteSpace(objWork_file_rec.Wf_trans_cd) || objWork_file_rec.Wf_trans_cd.ToUpper().Equals("M"))
            {
                l1_tot_claim_ohip = objWork_file_rec.Wf_claim_ohip;
            }
            else
            {
                l1_tot_claim_ohip_adj = objWork_file_rec.Wf_claim_ohip;
            }

            l1_adj_code = objWork_file_rec.Wf_adj_cd;

            // if wf-adj-cd-sub-type not = '0' and wf-adj-cd-sub-type not = 'S' and wf-adj-cd-sub-type not = ' ' then;            
            //    l1_adj_cd_sub_type = objWork_file_rec.wf_adj_cd_sub_type;
            //     l1_filler_slash = "/";

            if (objWork_file_rec.Wf_adj_cd_sub_type != "0" && objWork_file_rec.Wf_adj_cd_sub_type.ToUpper() != "S" && !string.IsNullOrWhiteSpace(objWork_file_rec.Wf_adj_cd_sub_type))
            {
                l1_adj_cd_sub_type = objWork_file_rec.Wf_adj_cd_sub_type;
                l1_filler_slash = "/";
            }

            //move wf-agent - cd                        to ws-agent.
            ws_agent = objWork_file_rec.Wf_agent_cd;

            // if wf-trans-cd = " " then;            
            //    	add wf-claim-ohip		to	doc-totals (2,1,ws-agent + 1);
            // 						doc-totals (2,4,ws-agent + 1);
            // else if wf-trans-cd = "B"  then;            
            // 		add wf-claim-ohip	to	doc-totals (2,2,ws-agent + 1);
            // 						doc-totals (2,5,ws-agent + 1);
            // 		perform ka1-determine-man-or-auto thru ka1-99-exit;
            // else if wf-trans-cd = "M" then;            
            // 		    add wf-claim-ohip	to	doc-totals (2,4,ws-agent + 1);
            // else;
            //      add wf-claim-ohip	to	doc-totals (2,5,ws-agent + 1);
            //                              adj-doc-totals (3,ws-agent + 1).;

            if (string.IsNullOrWhiteSpace(objWork_file_rec.Wf_trans_cd))
            {
                doc_totals[2, 1, ws_agent + 1] = doc_totals[2, 1, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
                doc_totals[2, 4, ws_agent + 1] = doc_totals[2, 4, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
            }
            else if (objWork_file_rec.Wf_trans_cd.ToUpper() == "B")
            {
                doc_totals[2, 2, ws_agent + 1] = doc_totals[2, 2, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
                doc_totals[2, 5, ws_agent + 1] = doc_totals[2, 5, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip; ;
                //perform ka1-determine - man - or - auto thru ka1-99 - exit;
                ka1_determine_man_or_auto();
                ka1_99_exit();
            }
            else if (objWork_file_rec.Wf_trans_cd.ToUpper() == "M")
            {
                doc_totals[2, 4, ws_agent + 1] = doc_totals[2, 4, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
            }
            else
            {
                doc_totals[2, 5, ws_agent + 1] = doc_totals[2, 5, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
                adj_doc_totals[3, ws_agent + 1] = adj_doc_totals[3, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
            }

        }
       
        private void ka0_99_exit()
        {            
            //     exit.;
        }

        private void ka1_determine_man_or_auto()
        {            

            // if wf-adj-cd-sub-type = "A" then;            
            //         add wf-claim-ohip      to       adj-doc-totals (2,ws-agent + 1);
            //                                         adj-doc-totals (4,ws-agent + 1);
            //  else if wf-adj-cd-sub-type = "M" then;            
            //             add wf-claim-ohip  to       adj-doc-totals (1,ws-agent + 1);
            //                                         adj-doc-totals (3,ws-agent + 1);
            //  else;
            //       err_ind = 15;
            //       perform za0-common-error;
            //       go to az0-end-of-job.;

            if (objWork_file_rec.Wf_adj_cd_sub_type.ToUpper().Equals("A"))
            {
                adj_doc_totals[2, ws_agent + 1] = adj_doc_totals[2, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
                adj_doc_totals[4, ws_agent + 1] = adj_doc_totals[4, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
            }
            else if (objWork_file_rec.Wf_adj_cd_sub_type.ToUpper() == "M")
            {
                adj_doc_totals[1, ws_agent + 1] = adj_doc_totals[1, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
                adj_doc_totals[3, ws_agent + 1] = adj_doc_totals[3, ws_agent + 1] + objWork_file_rec.Wf_claim_ohip;
            }
            else
            {
                err_ind = 15;
                za0_common_error();
                az0_end_of_job();
                return;
            }
        }

        private void ka1_99_exit()
        {            
            //     exit.;
        }

        private void kb0_read_doc_mstr()
        {            

            objDoc_mstr_rec.DOC_NBR = objWork_file_rec.Wf_doc_nbr;

            // read doc-mstr 
            //      invalid key;            
            //           err_ind = 13;
            // 	         perform za0-common-error	thru	za0-99-exit;
            //           err_msg_key_type = ""DOCTOR NUMBER"";
            //           err_msg_key = objDoc_mstr_rec.doc_nbr;
            //           perform za0-common-error	thru	za0-99-exit;
            //           err_msg_key_type = ""CLAIM NUMBER"";
            //           err_msg_key = objWork_file_rec.wf_claim_id;
            //     	     perform za0-common-error    thru    za0-99-exit;
            // 	         go to az0-end-of-job.;

            objDoc_mstr_rec = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = objWork_file_rec.Wf_doc_nbr
            }.Collection().FirstOrDefault();

            if (objDoc_mstr_rec == null)
            {
                // 	         perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                err_msg_key_type = "DOCTOR NUMBER";
                err_msg_key = objDoc_mstr_rec.DOC_NBR;
                //perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                err_msg_key_type = "CLAIM NUMBER";

                objWork_file_rec.Wf_claim_batch_nbr = Util.Str(objWork_file_rec.Wf_claim_clinic_nbr_1_2) + objWork_file_rec.Wf_claim_doctor_nbr + Util.Str(objWork_file_rec.Wf_claim_week) + Util.Str(objWork_file_rec.Wf_claim_day);
                objWork_file_rec.Wf_claim_id = objWork_file_rec.Wf_claim_batch_nbr + objWork_file_rec.Wf_claim_nbr;
                err_msg_key = objWork_file_rec.Wf_claim_id;
                //     	     perform za0-common-error    thru    za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	         go to az0-end-of-job
                az0_end_of_job();
                return;
            }

            //     add 1				to	ctr-doc-mstr-reads.;
            ctr_doc_mstr_reads++;
        }

        private void kb0_99_exit()
        {            
            //     exit.;
        }

        private void kc0_write_print_line()
        {            

            // if ctr-lines > max-nbr-lines then;            
            // 	  perform xa0-headings		thru	xa0-99-exit.;

            if (ctr_lines > max_nbr_lines)
            {
                // perform xa0-headings        thru xa0-99 - exit.;
                xa0_headings();
                xa0_99_exit();
            }

            objPrint_record.Print_record1 = print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4



            //    write print-record	from print-line after advancing 1 line.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //print_line = "";
            Initialize_PrintLine();

            //     add 1				to	ctr-lines.;
            ctr_lines++;
        }

        private void kc0_99_exit()
        {            
            //     exit.;
        }

        private void kd0_obtain_doc_totals()
        {            

            //     perform le0-obtain-doc-agent-totals   thru le0-99-exit;
            //            varying ss-agent;
            //            from 1  by 1;
            //            until   ss-agent > 10.;

            ss_agent = 1;
            do
            {
                le0_obtain_doc_agent_totals();
                le0_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);
        }

        private void kd0_99_exit()
        {            

            //     exit.;
        }

        private void kd1_obtain_adj_doc_totals()
        {            

            //     perform kd2-obtain-adj-doc-agent-tot   thru kd2-99-exit;
            //            varying ss-agent;
            //            from 1  by 1;
            //            until   ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kd2_obtain_adj_doc_agent_tot();
                kd2_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);
        }

        private void kd1_99_exit()
        {            
            //     exit.;
        }

        private void kd2_obtain_adj_doc_agent_tot()
        {            

            //     add adj-doc-totals (sub1,ss-agent)	to adj-dept-totals (sub1,ss-agent).;
            adj_dept_totals[sub1, ss_agent] = adj_dept_totals[sub1, ss_agent] + adj_doc_totals[sub1, ss_agent];
        }

        private void kd2_99_exit()
        {            
            //     exit.;
        }

        private void ke0_print_doc_totals()
        {            

            // if ctr-lines > (max-nbr-lines - 14) then;            
            if (ctr_lines > (max_nbr_lines - 14))
            {
                h1_page_nbr = ctr_pages;
                // 	  write print-record from h1-head after advancing page;
                // h1_head_grp = "R004  /" + Util.Str(h1_clinic_nbr).PadLeft(2) + new string(' ', 1) + "DATE" + Util.Str(h1_yy).PadLeft(4) + "/" + Util.Str(h1_mm).PadLeft(2) + "/" + Util.Str(h1_dd).PadLeft(2) + new string(' ', 12) + "* MONTHLY CLAIMS AND ADJUSTMENTS TRANSACTION SUMMARY *" + "PAGE " + string.Format("{0:#,0}", h1_page_nbr).PadLeft(5);
                objPrint_File.PageBreak();
                objPrint_File.print(h1_head_grp(), 1, true);

                //    write print-record from h2-head after advancing 1 line;
                //h2_head_grp = new string(' ', 54) + Util.Str(h2_clinic_name).PadRight(20) + new string(' ', 12) + "DEPARTMENT #" + Util.Str(h2_dept_nbr).PadLeft(2) + new string(' ', 1) + Util.Str(h2_dept_name).PadRight(30);
                objPrint_File.print(h2_head_grp(), 1, true);

                // 	  write print-record from h3-head after advancing 1 line;                
                objPrint_File.print(h3_head_grp(), 1, true);
                // 	  add 3				to 	ctr-lines;
                ctr_lines = ctr_lines + 3;
                // 	  add 1				to	ctr-pages.;
                ctr_pages++;
            }
            
            h6_doc_nbr = prev_doctor_nbr;

            //  write print-record from h6-head after advancing 3 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h6_head_grp(), 1, true);

            h9_head_msg = "--EFFECT ON A/R BY AGENT--";
            //  write print-record from h9-head after advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(h9_head_grp(), 1, true);

            //  write print-record from h10-head after advancing 1 line.;            
            objPrint_File.print(h10_head_grp(), 1, true);

            //  print_line = "";
            Initialize_PrintLine();

            l2_type = "RECV'D";
            ss_oma_ohip = 2;
            ss_trans_type = 1;

            //     perform ke1-doc-print-setup 	thru	ke1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                ke1_doc_print_setup();
                ke1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);


            l2_agent_total = doc_totals[2, 1, 11];
            //   write print-record from print-line after advancing 2 lines.;
            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            objPrint_File.print(true);
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //   print_line = "";
            Initialize_PrintLine();

            l2_type = "A/R ADJ";

            //  if ws-print-auto = "N" then;     
            if (ws_print_auto.ToUpper() == "N")
            {
                //     write print-record from print-line after advancing 1 line;
                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //     print_line = "";
                Initialize_PrintLine();

                l2_type = " MANUAL";
                ss_trans_type = 1;
                //     perform ke2-doc-adj-print-setup 	thru	ke2-99-exit;
                //            	varying ss-agent;
                // 	      	 from 1	by 1;
                // 		    until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke2_doc_adj_print_setup();
                    ke2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_doc_totals[1, 11];

                // write print-record from print-line after advancing 1 line;
                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //    write print-record	from print-line after advancing 1 line.;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //    print_line = "";
                Initialize_PrintLine();

                l2_type = " COMPUTE";
                ss_trans_type = 2;
                //     perform ke2-doc-adj-print-setup 	thru	ke2-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke2_doc_adj_print_setup();
                    ke2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_doc_totals[2, 11];

                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //      write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //      print_line = "";
                Initialize_PrintLine();

                //      write print-record from l5-print-line after advancing 1 line;                
                objPrint_File.print(l5_print_line_grp(), 1, true);

                //     print_line = "";
                Initialize_PrintLine();

                l2_type = " TOTAL";
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //     perform ke1-doc-print-setup 	thru	ke1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke1_doc_print_setup();
                    ke1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = doc_totals[2, 2, 11];

                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //     print_line = "";
                Initialize_PrintLine();
            }
            // else;
            else
            {
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //      perform ke1-doc-print-setup 	thru	ke1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke1_doc_print_setup();
                    ke1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);


                l2_agent_total = doc_totals[2, 2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //      write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //      print_line = "";
                Initialize_PrintLine();
            }

            l2_type = "TOT A/R";
            ss_oma_ohip = 2;
            ss_trans_type = 3;
            //   perform ke1-doc-print-setup 	thru	ke1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                ke1_doc_print_setup();
                ke1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = doc_totals[2, 3, 11];

            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //  write print-record from print-line after advancing 1 line.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //     print_line = "";
            Initialize_PrintLine();

            //     add 14				to 	ctr-lines.;
            ctr_lines = ctr_lines + 14;
            //  	add 3				to 	ctr-lines;
            ctr_lines = ctr_lines + 3;

            h9_head_msg = "EFFECT ON REVENUE BY AGENT";
            //     write print-record from h9-head    after advancing 3 line.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h9_head_grp(), 1, true);

            //     write print-record from h10-head   after advancing 1 line.;            
            objPrint_File.print(h10_head_grp(), 1, true);

            //     print_line = "";
            Initialize_PrintLine();


            l2_type = "REVENU";
            ss_oma_ohip = 2;
            ss_trans_type = 4;

            //     perform ke1-doc-print-setup 	thru	ke1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            //  	until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                ke1_doc_print_setup();
                ke1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = doc_totals[2, 4, 11];

            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 2 line.;
            objPrint_File.print(true);
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //     print_line = "";
            Initialize_PrintLine();

            l2_type = "REV ADJ";

            // if ws-print-auto = "N" then;    
            if (ws_print_auto.ToUpper() == "N")
            {

                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);


                //        print_line = "";
                Initialize_PrintLine();

                l2_type = " MANUAL";
                ss_trans_type = 3;
                //        perform ke2-doc-adj-print-setup 	thru	ke2-99-exit;
                //                	varying ss-agent;
                // 		            from 1	by 1;
                // 		     until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke2_doc_adj_print_setup();
                    ke2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_doc_totals[3, 11];

                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                l2_type = " COMPUTE";
                ss_trans_type = 4;
                //       perform ke2-doc-adj-print-setup 	thru	ke2-99-exit;
                //                	varying ss-agent;
                // 		            from 1	by 1;
                // 		            until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke2_doc_adj_print_setup();
                    ke2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_doc_totals[4, 11];

                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //         write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //         print_line = "";
                Initialize_PrintLine();

                //         write print-record from l5-print-line after advancing 1 line;                
                objPrint_File.print(l5_print_line_grp(), 1, true);

                //         print_line = "";
                Initialize_PrintLine();

                l2_type = " TOTAL";
                ss_oma_ohip = 2;
                ss_trans_type = 5;
                //         perform ke1-doc-print-setup 	thru	ke1-99-exit;
                //                	varying ss-agent;
                // 	       	from 1	by 1;
                // 		    until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke1_doc_print_setup();
                    ke1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = doc_totals[2, 5, 11];

                objPrint_record.Print_record1 = print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }
            else
            {
                ss_oma_ohip = 2;
                ss_trans_type = 5;
                //        perform ke1-doc-print-setup 	thru	ke1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    ke1_doc_print_setup();
                    ke1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = doc_totals[2, 5, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //print_line = "";
                Initialize_PrintLine();
            }

            l2_type = "TOT REV";
            ss_oma_ohip = 2;
            ss_trans_type = 6;
            //  perform ke1-doc-print-setup 	thru	ke1-99-exit;
            //                	varying ss-agent;
            //     from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                ke1_doc_print_setup();
                ke1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = doc_totals[2, 6, 11];

            /* objPrint_record.Print_record1 = Util.Str(l1_pat_surname).PadRight(7, ' ') + Util.Str(l1_pat_acronym3).PadRight(4, ' ') + Util.Str(l1_claim_clinic1).PadLeft(2) + Util.Str(l1_claim_doc_nbr).PadRight(3, ' ') + Util.Str(l1_claim_week).PadLeft(2) + Util.Str(l1_claim_day).PadLeft(1) + Util.Str(l1_claim_nbr).PadLeft(2) +
                                          new string(' ', 1) + Util.Str(l1_patient_id).PadRight(15) + new string(' ', 2) + Util.Str(l1_agent_code).PadLeft(1) + new string(' ', 3) + Util.Str(l1_adj_code).PadRight(1) + Util.Str(l1_filler_slash).PadRight(1) + Util.Str(l1_adj_cd_sub_type).PadRight(1) + new string(' ', 4) +
                                          Util.ImpliedDecimalFormat("#0.00", l1_tot_claim_ohip, 2, 9) + new string(' ', 4) + Util.ImpliedDecimalFormat("#0.00", l1_tot_claim_ohip_adj, 2, 9) + new string(' ', 1) + Util.Str(l1_service_date_yy).PadLeft(4) + Util.Str(l1_slash1).PadRight(1) + Util.Str(l1_service_date_mm).PadRight(2) +
                                          Util.Str(l1_slash2).PadRight(1) + Util.Str(l1_service_date_dd).PadLeft(2) + new string(' ', 2) + Util.Str(l1_claim_date_yy).PadLeft(4) + Util.Str(l1_slash3).PadRight(1) + Util.Str(l1_claim_date_mm).PadLeft(2) + Util.Str(l1_slash4).PadRight(1) + Util.Str(l1_claim_date_dd).PadLeft(2) +
                                          new string(' ', 2) + Util.Str(l1_diag_cd).PadLeft(3) + new string(' ', 2) + Util.Str(l1_oma_cd).PadRight(4) + Util.Str(l1_oma_suff).PadRight(1) + new string(' ', 1) + Util.Str(l1_nbr_of_services).PadLeft(3) + new string(' ', 2) + Util.Str(l1_batch_clinic1).PadLeft(2) + Util.Str(l1_batch_doc_nbr).PadRight(3) +
                                          Util.Str(l1_batch_week).PadRight(2) + Util.Str(l1_batch_day).PadRight(1) + new string(' ', 2) + Util.Str(l1_ref_field).PadRight(9); */
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            objPrint_record.Print_record1 = l2_print_line_grp();

            //   write print-record from print-line after advancing 1 line.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //   print_line = "";
            Initialize_PrintLine();

            //    add 12				to 	ctr-lines.;
            ctr_lines = ctr_lines + 12;
            //   ctr_lines = 70;
            ctr_lines = 70;
        }

        private void ke0_99_exit()
        {            
            //     exit.;
        }

        private void ke1_doc_print_setup()
        {            

            l2_ohip_totals[ss_agent] = doc_totals[ss_oma_ohip, ss_trans_type, ss_agent];

            //     add  doc-totals(ss-oma-ohip,ss-trans-type,ss-agent)     to;
            //          doc-totals(ss-oma-ohip,ss-trans-type,11).;

            doc_totals[ss_oma_ohip, ss_trans_type, 11] = doc_totals[ss_oma_ohip, ss_trans_type, 11] + doc_totals[ss_oma_ohip, ss_trans_type, ss_agent];
        }

        private void ke1_99_exit()
        {            

            //     exit.;
        }

        private void ke2_doc_adj_print_setup()
        {            

            l2_ohip_totals[ss_agent] = adj_doc_totals[ss_trans_type, ss_agent];

            //     add  adj-doc-totals(ss-trans-type,ss-agent)     to;
            //          adj-doc-totals(ss-trans-type,11).;

            adj_doc_totals[ss_trans_type, 11] = adj_doc_totals[ss_trans_type, 11] + adj_doc_totals[ss_trans_type, ss_agent];
        }

        private void ke2_99_exit()
        {            

            //     exit.;
        }

        private void kf0_obtain_dept_ttls()
        {            

            //     perform lf0-obtain-dept-agent-totals       thru  lf0-99-exit;
            //           varying ss-agent;
            //           from 1  by 1;
            //           until   ss-agent > 10.;

            ss_agent = 1;
            do
            {
                lf0_obtain_dept_agent_totals();
                lf0_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);
        }

        private void kf0_99_exit()
        {            
            //     exit.;
        }

        private void kf1_obtain_adj_dept_ttls()
        {            

            //     perform kf2-obtain-adj-dept-agent-tot    thru  kf2-99-exit;
            //           varying ss-agent;
            //           from 1  by 1;
            //           until   ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kf2_obtain_adj_dept_agent_tot();
                kf2_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);
        }

        private void kf1_99_exit()
        {            

            //     exit.;
        }

        private void kf2_obtain_adj_dept_agent_tot()
        {            

            //     add adj-dept-totals (sub1,ss-agent)  to adj-grand-totals (sub1,ss-agent).;
            adj_grand_totals[sub1, ss_agent] = adj_grand_totals[sub1, ss_agent] + adj_dept_totals[sub1, ss_agent];
        }

        private void kf2_99_exit()
        {            
            //     exit.;
        }

        private void kg0_write_dept_totals()
        {            

            h1_page_nbr = ctr_pages;
            // 	write print-record from h1-head after advancing page;            
            objPrint_File.PageBreak();
            objPrint_File.print(h1_head_grp(), 1, true);

            //  	write print-record from h2-head after advancing 1 line;            
            objPrint_File.print(h2_head_grp(), 1, true);

            // 	add 2				to	ctr-lines;
            ctr_lines = ctr_lines + 2;
            // 	add 1				to 	ctr-pages.;
            ctr_pages++;

            h7_dept_nbr = prev_dept;

            //     write print-record from h7-head after advancing 5 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h7_head_grp(), 1, true);

            //print_line = "";
            Initialize_PrintLine();

            h9_head_msg = "--EFFECT ON A/R BY AGENT--";
            //   write print-record from h9-head    after advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(h9_head_grp(), 1, true);

            //     write print-record from h10-head   after advancing 2 lines.;            
            objPrint_File.print(h10_head_grp(), 1, true);

            //print_line = "";
            Initialize_PrintLine();

            l2_type = "RECV'D";
            ss_oma_ohip = 2;
            ss_trans_type = 1;
            //     perform kg1-dept-print-setup 	thru	kg1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kg1_dept_print_setup();
                kg1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = dept_totals[2, 1, 11];


            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //  write print-record from print-line after advancing 2 lines.;
            objPrint_File.print(true);
            objPrint_File.print(objPrint_record.Print_record1, 1, true);


            //  print_line = "";
            Initialize_PrintLine();

            l2_type = "A/R ADJ";

            // if ws-print-auto = "N"  then;            
            if (ws_print_auto.ToUpper() == "N")
            {

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                l2_type = " MANUAL";
                ss_trans_type = 1;
                //         perform kg2-dept-adj-print-setup 	thru	kg2-99-exit;
                //                	varying ss-agent;
                // 		            from 1	by 1;
                // 		            until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg2_dept_adj_print_setup();
                    kg2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_dept_totals[1, 11];


                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                l2_type = " COMPUTE";
                ss_trans_type = 2;
                //        perform kg2-dept-adj-print-setup 	thru	kg2-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg2_dept_adj_print_setup();
                    kg2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_dept_totals[2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //  write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                //        write print-record from l5-print-line after advancing 1 line;                
                objPrint_File.print(l5_print_line_grp(), 1, true);

                //       print_line = "";
                Initialize_PrintLine();

                l2_type = " TOTAL";
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //        perform kg1-dept-print-setup 	thru	kg1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg1_dept_print_setup();
                    kg1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = dept_totals[2, 2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }
            else
            {
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //        perform kg1-dept-print-setup 	thru	kg1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg1_dept_print_setup();
                    kg1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = dept_totals[2, 2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //         print_line = "";
                Initialize_PrintLine();
            }


            l2_type = "TOT A/R";
            ss_oma_ohip = 2;
            ss_trans_type = 3;
            //     perform kg1-dept-print-setup 	thru	kg1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kg1_dept_print_setup();
                kg1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);


            l2_agent_total = dept_totals[2, 3, 11];

            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //    write print-record from print-line after advancing 1 line.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //   print_line = "";
            Initialize_PrintLine();

            //     add 17				to 	ctr-lines.;
            ctr_lines = ctr_lines + 17;

            //    move "EFFECT ON REVENUE BY AGENT"  to h9-head - msg.
            h9_head_msg = "EFFECT ON REVENUE BY AGENT";

            //     write print-record from h9-head    after advancing 3 line.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h9_head_grp(), 1, true);

            //     write print-record from h10-head   after advancing 1 line.;            
            objPrint_File.print(h10_head_grp(), 1, true);

            //     print_line = "";
            Initialize_PrintLine();

            l2_type = "REVENU";
            ss_oma_ohip = 2;
            ss_trans_type = 4;
            //     perform kg1-dept-print-setup 	thru	kg1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kg1_dept_print_setup();
                kg1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = dept_totals[2, 4, 11];

            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 2 line.;
            objPrint_File.print(true);
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //     print_line = "";
            Initialize_PrintLine();

            l2_type = "REV ADJ";

            // if ws-print-auto = "N" then;          
            if (ws_print_auto.ToUpper() == "N")
            {
                //     write print-record from print-line after advancing 1 line;
                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //     print_line = "";
                Initialize_PrintLine();

                l2_type = " MANUAL";
                ss_trans_type = 2;
                //      perform kg2-dept-adj-print-setup 	thru	kg2-99-exit;
                //                	varying ss-agent;
                // 	      	from 1	by 1;
                // 		    until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg2_dept_adj_print_setup();
                    kg2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_dept_totals[3, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //      print_line = "";
                Initialize_PrintLine();

                l2_type = " COMPUTE";
                ss_trans_type = 4;
                //        perform kg2-dept-adj-print-setup 	thru	kg2-99-exit;
                //                	varying ss-agent;
                // 		  from 1	by 1;
                // 		  until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg2_dept_adj_print_setup();
                    kg2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_dept_totals[4, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //         print_line = "";
                Initialize_PrintLine();

                //        write print-record from l5-print-line after advancing 1 line;                
                objPrint_File.print(l5_print_line_grp(), 1, true);

                //         print_line = "";
                Initialize_PrintLine();

                l2_type = " TOTAL";
                ss_oma_ohip = 2;
                ss_trans_type = 5;
                //        perform kg1-dept-print-setup 	thru	kg1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent++;
                do
                {
                    kg1_dept_print_setup();
                    kg1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = dept_totals[2, 5, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }
            else
            {
                ss_oma_ohip = 2;
                ss_trans_type = 5;
                //        perform kg1-dept-print-setup 	thru	kg1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kg1_dept_print_setup();
                    kg1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = dept_totals[2, 5, 11];


                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }

            l2_type = "TOT REV";
            ss_oma_ohip = 2;
            ss_trans_type = 6;
            //     perform kg1-dept-print-setup 	thru	kg1-99-exit;
            //                	varying ss-agent;
            // 		from 1	by 1;
            // 		until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kg1_dept_print_setup();
                kg1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = dept_totals[2, 6, 11];


            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 1 line.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //print_line = "";
            Initialize_PrintLine();

            ctr_lines = 70;
        }

        private void kg0_99_exit()
        {            
            //     exit.;
        }

        private void kg1_dept_print_setup()
        {            

            l2_ohip_totals[ss_agent] = dept_totals[ss_oma_ohip, ss_trans_type, ss_agent];

            //     add  dept-totals(ss-oma-ohip,ss-trans-type,ss-agent)    to;
            //          dept-totals(ss-oma-ohip,ss-trans-type,11).;

            dept_totals[ss_oma_ohip, ss_trans_type, 11] = dept_totals[ss_oma_ohip, ss_trans_type, 11] + dept_totals[ss_oma_ohip, ss_trans_type, ss_agent];
        }

        private void kg1_99_exit()
        {            
            //     exit.;
        }

        private void kg2_dept_adj_print_setup()
        {            
            l2_ohip_totals[ss_agent] = adj_dept_totals[ss_trans_type, ss_agent];

            //     add  adj-dept-totals(ss-trans-type,ss-agent)    to;
            //          adj-dept-totals(ss-trans-type,11).;

            adj_dept_totals[ss_trans_type, 11] = adj_dept_totals[ss_trans_type, 11] + adj_dept_totals[ss_trans_type, ss_agent];

        }

        private void kg2_99_exit()
        {            
            //     exit.;
        }

        private void kh0_write_grand_totals()
        {            

            h1_page_nbr = ctr_pages;
            //     write print-record from h1-head after advancing page.;            
            objPrint_File.PageBreak();
            objPrint_File.print(h1_head_grp(), 1, true);

            //     write print-record from h8-head after advancing 1 line.;            
            objPrint_File.print(h8_head_grp(), 1, true);

            //     perform lg0-obtain-grand-agent-totals    thru   lg0-99-exit;
            //        		varying 	ss-agent;
            // 		from 1		by 1;
            // 		until		ss-agent > 10.;

            ss_agent = 1;
            do
            {
                lg0_obtain_grand_agent_totals();
                lg0_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            h8_clinic_name = "GRAND TOTALS";
            //     write print-record from h8-head    after advancing  5 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h8_head_grp(), 1, true);

            //print_line = "";
            Initialize_PrintLine();

            h9_head_msg = "--EFFECT ON A/R BY AGENT--";
            //     write print-record from h9-head    after advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(h9_head_grp(), 1, true);

            //     write print-record from h10-head   after advancing 1 line.;            
            objPrint_File.print(h10_head_grp(), 1, true);

            //print_line = "";
            Initialize_PrintLine();

            l2_type = "RECV'D";
            ss_oma_ohip = 2;
            ss_trans_type = 1;
            //     perform kh1-grand-print-setup 	thru	kh1-99-exit;
            //              varying ss-agent;
            //              from 1	by 1;
            // 	     until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kh1_grand_print_setup();
                kh1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = grand_totals[2, 1, 11];

            //     write print-record from print-line after advancing 1 lines.;
            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 1 lines.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //print_line = "";
            Initialize_PrintLine();


            l2_type = "A/R ADJ";
            //  if ws-print-auto = "N" then;       
            if (ws_print_auto.ToUpper() == "N")
            {
                //      write print-record from print-line after advancing 1 line;
                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //      write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //      print_line = "";
                Initialize_PrintLine();

                l2_type = " MANUAL";
                ss_trans_type = 1;
                //      perform kh2-grand-adj-print-setup 	thru	kh2-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh2_grand_adj_print_setup();
                    kh2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_grand_totals[1, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //       write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //       print_line = "";
                Initialize_PrintLine();

                l2_type = " COMPUTE";
                ss_trans_type = 2;
                //      perform kh2-grand-adj-print-setup 	thru	kh2-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh2_grand_adj_print_setup();
                    kh2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_grand_totals[2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                //        write print-record from l5-print-line after advancing 1 line;                
                objPrint_File.print(l5_print_line_grp(), 1, true);

                //         print_line = "";
                Initialize_PrintLine();

                l2_type = " TOTAL";
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //        perform kh1-grand-print-setup 	thru	kh1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh1_grand_print_setup();
                    kh1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = grand_totals[2, 2, 11];


                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //       write print-record from print-line after advancing 1 lines;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //       print_line = "";
                Initialize_PrintLine();
            }
            else
            {
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //        perform kh1-grand-print-setup 	thru	kh1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh1_grand_print_setup();
                    kh1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = grand_totals[2, 2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 lines;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }

            l2_type = "TOT A/R";
            ss_oma_ohip = 2;
            ss_trans_type = 3;
            //     perform kh1-grand-print-setup 	thru	kh1-99-exit;
            //              varying ss-agent;
            // 	     from 1	by 1;
            // 	     until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kh1_grand_print_setup();
                kh1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = grand_totals[2, 3, 11];

            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 1 lines.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //     print_line = "";
            Initialize_PrintLine();

            h9_head_msg = "EFFECT ON REVENUE BY AGENT";
            //     write print-record from h9-head    after advancing 3 line.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h9_head_grp(), 1, true);

            //     write print-record from h10-head   after advancing 1 line.;            
            objPrint_File.print(h10_head_grp(), 1, true);

            //     print_line = "";
            Initialize_PrintLine();


            l2_type = "REVENU";
            ss_oma_ohip = 2;
            ss_trans_type = 4;
            //     perform kh1-grand-print-setup 	thru	kh1-99-exit;
            //              varying ss-agent;
            // 	     from 1	by 1;
            // 	     until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kh1_grand_print_setup();
                kh1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = grand_totals[2, 4, 11];

            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 1 lines.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //     print_line = "";
            Initialize_PrintLine();

            l2_type = "REV ADJ";

            // if ws-print-auto = "N" then;            
            if (ws_print_auto.ToUpper() == "N")
            {

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //     write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //     print_line = "";
                Initialize_PrintLine();


                l2_type = " MANUAL";
                ss_trans_type = 3;
                //      perform kh2-grand-adj-print-setup 	thru	kh2-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh2_grand_adj_print_setup();
                    kh2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_grand_totals[1, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                l2_type = " COMPUTE";
                ss_trans_type = 4;
                //        perform kh2-grand-adj-print-setup 	thru	kh2-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh2_grand_adj_print_setup();
                    kh2_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = adj_grand_totals[2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 line;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                //        write print-record from l5-print-line after advancing 1 line;                
                objPrint_File.print(l5_print_line_grp(), 1, true);

                //        print_line = "";
                Initialize_PrintLine();

                l2_type = " TOTAL";
                ss_oma_ohip = 2;
                ss_trans_type = 2;
                //        perform kh1-grand-print-setup 	thru	kh1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh1_grand_print_setup();
                    kh1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = grand_totals[2, 2, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 lines;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }
            else
            {
                ss_oma_ohip = 2;
                ss_trans_type = 5;
                //        perform kh1-grand-print-setup 	thru	kh1-99-exit;
                //                	varying ss-agent;
                // 		from 1	by 1;
                // 		until 	ss-agent > 10;

                ss_agent = 1;
                do
                {
                    kh1_grand_print_setup();
                    kh1_99_exit();
                    ss_agent++;
                } while (ss_agent <= 10);

                l2_agent_total = grand_totals[2, 5, 11];

                objPrint_record.Print_record1 = l2_print_line_grp();
                // todo... 
                //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
                //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
                //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
                //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

                //        write print-record from print-line after advancing 1 lines;
                objPrint_File.print(objPrint_record.Print_record1, 1, true);

                //        print_line = "";
                Initialize_PrintLine();
            }

            l2_type = "TOT REV";
            ss_oma_ohip = 2;
            ss_trans_type = 6;
            //     perform kh1-grand-print-setup 	thru	kh1-99-exit;
            //              varying ss-agent;
            // 	     from 1	by 1;
            // 	     until 	ss-agent > 10.;

            ss_agent = 1;
            do
            {
                kh1_grand_print_setup();
                kh1_99_exit();
                ss_agent++;
            } while (ss_agent <= 10);

            l2_agent_total = grand_totals[2, 6, 11];


            objPrint_record.Print_record1 = l2_print_line_grp();
            // todo... 
            //Util.Str(l2_type).PadRight(9) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) + // l2
            //Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) + Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) + Util.ImpliedDecimalFormat("#,0.00", l2_agent_total, 2, 13) + // l2
            //new string(' ', 62) + Util.Str(l3_ohip, 70) +   // l3
            //new string(' ', 4) + Util.Str(l4_type).PadRight(116) + Util.ImpliedDecimalFormat("#,0.00", l4_adj_tot, 2, 12);  // l4

            //     write print-record from print-line after advancing 1 lines.;
            objPrint_File.print(objPrint_record.Print_record1, 1, true);

            //     print_line = "";
            Initialize_PrintLine();
        }

        private void kh0_99_exit()
        {            
            //     exit.;
        }

        private void kh1_grand_print_setup()
        {            

            l2_ohip_totals[ss_agent] = grand_totals[ss_oma_ohip, ss_trans_type, ss_agent];

            //     add grand-totals(ss-oma-ohip,ss-trans-type,ss-agent)    to;
            //         grand-totals(ss-oma-ohip,ss-trans-type,11).;

            grand_totals[ss_oma_ohip, ss_trans_type, 11] = grand_totals[ss_oma_ohip, ss_trans_type, 11] + grand_totals[ss_oma_ohip, ss_trans_type, ss_agent];
        }

        private void kh1_99_exit()
        {            
            //     exit.;
        }

        private void kh2_grand_adj_print_setup()
        {            

            l2_ohip_totals[ss_agent] = adj_grand_totals[ss_trans_type, ss_agent];

            //     add adj-grand-totals(ss-trans-type,ss-agent)    to;
            //         adj-grand-totals(ss-trans-type,11).;

            adj_grand_totals[ss_trans_type, 11] = adj_grand_totals[ss_trans_type, 11] + adj_grand_totals[ss_trans_type, ss_agent];
        }

        private void kh2_99_exit()
        {            
            //     exit.;
        }

        private void la0_zero_to_dept_ttls()
        {            

            dept_totals[2, sub1, 1] = 0;
            dept_totals[2, sub1, 2] = 0;
            dept_totals[2, sub1, 3] = 0;
            dept_totals[2, sub1, 4] = 0;
            dept_totals[2, sub1, 5] = 0;
            dept_totals[2, sub1, 6] = 0;
            dept_totals[2, sub1, 7] = 0;
            dept_totals[2, sub1, 8] = 0;
            dept_totals[2, sub1, 9] = 0;
            dept_totals[2, sub1, 10] = 0;
            dept_totals[2, sub1, 11] = 0;
        }

        private void la0_99_exit()
        {            
            //     exit.;
        }

        private void lb0_zero_to_doc_ttls()
        {            

            doc_totals[2, sub1, 1] = 0;
            doc_totals[2, sub1, 2] = 0;
            doc_totals[2, sub1, 3] = 0;
            doc_totals[2, sub1, 4] = 0;
            doc_totals[2, sub1, 5] = 0;
            doc_totals[2, sub1, 6] = 0;
            doc_totals[2, sub1, 7] = 0;
            doc_totals[2, sub1, 8] = 0;
            doc_totals[2, sub1, 9] = 0;
            doc_totals[2, sub1, 10] = 0;
            doc_totals[2, sub1, 11] = 0;
        }

        private void lb0_99_exit()
        {            
            //     exit.;
        }

        private void lc0_zero_to_adj_dept_ttls()
        {            

            adj_dept_totals[1, ss_agent] = 0;
            adj_dept_totals[2, ss_agent] = 0;
            adj_dept_totals[3, ss_agent] = 0;
            adj_dept_totals[4, ss_agent] = 0;
        }

        private void lc0_99_exit()
        {            
            //     exit.;
        }

        private void ld0_zero_to_adj_doc_ttls()
        {            
            adj_doc_totals[1, ss_agent] = 0;
            adj_doc_totals[2, ss_agent] = 0;
            adj_doc_totals[3, ss_agent] = 0;
            adj_doc_totals[4, ss_agent] = 0;
        }

        private void ld0_99_exit()
        {            
            //     exit.;
        }

        private void le0_obtain_doc_agent_totals()
        {            

            //     add doc-totals (sub1,1,ss-agent)	to	dept-totals (sub1,1,ss-agent);
            // 						doc-totals (sub1,3,ss-agent).;

            dept_totals[sub1, 1, ss_agent] = dept_totals[sub1, 1, ss_agent] + doc_totals[sub1, 1, ss_agent];
            doc_totals[sub1, 3, ss_agent] = doc_totals[sub1, 3, ss_agent] + doc_totals[sub1, 1, ss_agent];

            //     add doc-totals (sub1,2,ss-agent)	to	dept-totals (sub1,2,ss-agent);
            // 						doc-totals (sub1,3,ss-agent).;

            dept_totals[sub1, 2, ss_agent] = dept_totals[sub1, 2, ss_agent] + doc_totals[sub1, 2, ss_agent]; ;
            doc_totals[sub1, 3, ss_agent] = doc_totals[sub1, 3, ss_agent] + doc_totals[sub1, 2, ss_agent];

            //     add doc-totals (sub1,4,ss-agent)	to	dept-totals (sub1,4,ss-agent);
            // 						doc-totals (sub1,6,ss-agent).;

            dept_totals[sub1, 4, ss_agent] = dept_totals[sub1, 4, ss_agent] + doc_totals[sub1, 4, ss_agent]; ;
            doc_totals[sub1, 6, ss_agent] = doc_totals[sub1, 6, ss_agent] + doc_totals[sub1, 4, ss_agent];

            //     add doc-totals (sub1,5,ss-agent)	to	dept-totals (sub1,5,ss-agent);
            // 						doc-totals (sub1,6,ss-agent).;

            dept_totals[sub1, 5, ss_agent] = dept_totals[sub1, 5, ss_agent] + doc_totals[sub1, 5, ss_agent];
            doc_totals[sub1, 6, ss_agent] = doc_totals[sub1, 6, ss_agent] + doc_totals[sub1, 5, ss_agent];
        }

        private void le0_99_exit()
        {            
            //     exit.;
        }

        private void lf0_obtain_dept_agent_totals()
        {            

            //     add dept-totals (sub1,1,ss-agent)	to	grand-totals (sub1,1,ss-agent);
            // 						dept-totals (sub1,3,ss-agent).;

            grand_totals[sub1, 1, ss_agent] = grand_totals[sub1, 1, ss_agent] + dept_totals[sub1, 1, ss_agent];
            dept_totals[sub1, 3, ss_agent] = dept_totals[sub1, 3, ss_agent] + dept_totals[sub1, 1, ss_agent];

            //     add dept-totals (sub1,2,ss-agent)	to	grand-totals (sub1,2,ss-agent);
            // 						dept-totals (sub1,3,ss-agent).;

            grand_totals[sub1, 2, ss_agent] = grand_totals[sub1, 2, ss_agent] + dept_totals[sub1, 2, ss_agent];
            dept_totals[sub1, 3, ss_agent] = dept_totals[sub1, 3, ss_agent] + dept_totals[sub1, 2, ss_agent];

            //     add dept-totals (sub1,4,ss-agent)	to	grand-totals (sub1,4,ss-agent);
            // 						dept-totals (sub1,6,ss-agent).;

            grand_totals[sub1, 4, ss_agent] = grand_totals[sub1, 4, ss_agent] + dept_totals[sub1, 4, ss_agent];
            dept_totals[sub1, 6, ss_agent] = dept_totals[sub1, 6, ss_agent] + dept_totals[sub1, 4, ss_agent];

            //     add dept-totals (sub1,5,ss-agent)	to	grand-totals (sub1,5,ss-agent);
            // 						dept-totals (sub1,6,ss-agent).;

            grand_totals[sub1, 5, ss_agent] = grand_totals[sub1, 5, ss_agent] + dept_totals[sub1, 5, ss_agent];
            dept_totals[sub1, 6, ss_agent] = dept_totals[sub1, 6, ss_agent] + dept_totals[sub1, 5, ss_agent];
        }

        private void lf0_99_exit()
        {            
            //     exit.;
        }

        private void lg0_obtain_grand_agent_totals()
        {            

            //     compute grand-totals (2,3,ss-agent) = grand-totals (2,1,ss-agent) +;
            // 				 grand-totals (2,2,ss-agent).;

            grand_totals[2, 3, ss_agent] = grand_totals[2, 1, ss_agent] + grand_totals[2, 2, ss_agent];

            //     compute grand-totals (2,6,ss-agent) = grand-totals (2,4,ss-agent) +;
            // 				 grand-totals (2,5,ss-agent).;

            grand_totals[2, 6, ss_agent] = grand_totals[2, 4, ss_agent] + grand_totals[2, 5, ss_agent];
        }

        private void lg0_99_exit()
        {            
            //     exit;
        }

        private void ki0_read_dept_mstr()
        {            

            //objDept_mstr_rec.dept_nbr = objWork_file_rec.wf_dept;
            //     read dept-mstr;
            // 	invalid key;
            //err_ind = 16;
            // 	    perform za0-common-error	thru za0-99-exit;
            //objDept_mstr_rec.dept_name = "'UNKNOWN DEPT'";


            Dept_mstr_rec_Collection = new F070_DEPT_MSTR
            {
                WhereDept_nbr = objWork_file_rec.Wf_dept
            }.Collection();

            if (Dept_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 16;
                za0_common_error();
                za0_99_exit();
                objDept_mstr_rec.DEPT_NAME = "UNKNOWN DEPT";
            }
            else
            {
                objDept_mstr_rec = Dept_mstr_rec_Collection.FirstOrDefault();
            }

        }

        private void ki0_99_exit()
        {            
            //     exit.;
        }

        private void xa0_headings()
        {            

            h1_page_nbr = ctr_pages;
            //     write print-record from h1-head after advancing page.;            
            objPrint_File.PageBreak();
            objPrint_File.print(h1_head_grp(), 1, true);

            //     write print-record from h2-head after advancing 1 line.;            
            objPrint_File.print(h2_head_grp(), 1, true);

            //     write print-record from h3-head after advancing 1 line.;            
            objPrint_File.print(h3_head_grp(), 1, true);

            //     write print-record from h4-head after advancing 2 line.;            
            objPrint_File.print(true);
            objPrint_File.print(h4_head_grp(), 1, true);

            //     write print-record from h5-head after advancing 1 line.;            
            objPrint_File.print(h5_head_grp(), 1, true);

            //     write print-record from blank-line after advancing 1 line.;
            objPrint_File.print(true);

            ctr_lines = 7;
            //     add 1				to	ctr-pages.;
            ctr_pages++;
        }

        private void xa0_99_exit()
        {            
            //     exit.;
        }

        private void za0_common_error()
        {            

            err_msg_comment_grp = err_msg[err_ind];
            //     display err-msg-comment.;
            Console.WriteLine(err_msg_comment_grp);
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

        private void Initialize_PrintLine()
        {            

            l1_print_line_grp = string.Empty;
            l1_pat_surname = string.Empty;
            l1_pat_acronym3 = string.Empty;
            l1_clmhdr_claim_nbr_grp = string.Empty;
            l1_claim_clinic1 = 0;
            l1_claim_doc_nbr = string.Empty;
            l1_claim_week = 0;
            l1_claim_day = 0;
            l1_claim_nbr = 0;
            l1_patient_id = string.Empty;
            l1_agent_code = 0;
            l1_a_m_adj_grp = string.Empty;
            l1_adj_code = string.Empty;
            l1_filler_slash = string.Empty;
            l1_adj_cd_sub_type = string.Empty;
            l1_tot_claim_ohip = 0;
            l1_tot_claim_ohip_adj = 0;
            l1_tot_claim_ohip_adj_r = string.Empty;
            l1_service_date_grp = string.Empty;
            l1_service_date_yy = 0;
            l1_slash1 = string.Empty;
            l1_service_date_mm = 0;
            l1_slash2 = string.Empty;
            l1_service_date_dd = 0;
            l1_claim_date_grp = string.Empty;
            l1_claim_date_yy = 0;
            l1_slash3 = string.Empty;
            l1_claim_date_mm = 0;
            l1_slash4 = string.Empty;
            l1_claim_date_dd = 0;
            l1_oma_code_grp = string.Empty;
            l1_oma_cd = string.Empty;
            l1_oma_suff = string.Empty;
            l1_nbr_of_services = 0;
            l1_batch_nbr_grp = string.Empty;
            l1_batch_clinic1 = 0;
            l1_batch_doc_nbr = string.Empty;
            l1_batch_week = string.Empty;
            l1_batch_day = string.Empty;
            l1_ref_field = string.Empty;
           // l2_print_line_grp = string.Empty;
            l2_type = string.Empty;
            l2_ohip_totals_r = new string[11];
            l2_ohip_totals = new decimal[11];
            l2_agent_total = 0;
           // l3_print_line_grp = string.Empty;
            l3_ohip = string.Empty;
           // l4_print_line_grp = string.Empty;
            l4_type = string.Empty;
            l4_adj_tot = 0;
        }

        private string h1_head_grp()
        {            

            return "R004  /".PadRight(7) +
                   Util.Str(h1_clinic_nbr).PadLeft(2) +
                   new string(' ', 1) +
                   "DATE".PadRight(5) +
                   Util.Str(h1_yy).PadLeft(4) +
                   "/" +
                   Util.Str(h1_mm).PadLeft(2,'0') +
                   "/" +
                   Util.Str(h1_dd).PadLeft(2,'0') +
                   new string(' ', 12) +
                   "* MONTHLY CLAIMS AND ADJUSTMENTS TRANSACTION SUMMARY *".PadRight(85) +
                   "PAGE ".PadRight(5) +
                   string.Format("{0:#,0}", h1_page_nbr).PadLeft(5);
        }

        private string h2_head_grp()
        {            
            return new string(' ', 54) +
                    Util.Str(h2_clinic_name).PadRight(20) +
                    new string(' ', 12) +
                    "DEPARTMENT #" +
                    Util.Str(h2_dept_nbr).PadLeft(2,'0') +
                    new string(' ', 1) +
                    Util.Str(h2_dept_name).PadRight(30);
        }

        private string h3_head_grp()
        {            

            return new string(' ', 86) +
                  "DOCTOR-" +
                  Util.Str(h3_doc_nbr).PadRight(3) +
                  new string(' ', 1) +
                  Util.Str(h3_doc_name).PadRight(24) +
                  new string(' ', 11);
        }

        private string h4_head_grp()
        {            

            return new string(' ', 2) +
                    "PATIENT     CLAIM   PATIENT ID/  AGENT".PadRight(39) +
                    " ADJ/or      OHIP    ADJUSTMENT SERVICE".PadRight(48) +
                    "CLAIM   DIAG  OMA  #OF  BATCH     FORM#".PadRight(43);
        }

        private string h5_head_grp()
        {            
            return new string(' ', 3) +
                "NAME       NUMBER  CHART NUMBER  CODE".PadRight(38) +
                " SOURCE       FEE      AMOUNT     DATE".PadRight(49) +
                "DATE   CODE  CODE SRV  NUMBER    NOTE".PadRight(42);
        }

        private string h6_head_grp()
        {            

            return " DOCTOR".PadRight(8) +
                Util.Str(h6_doc_nbr).PadRight(3) +
                new string(' ', 121);
        }

        private string h7_head_grp()
        {            

            return "DEPARTMENTAL SUMMARY  DEPT #".PadRight(30) +
                    Util.Str(h7_dept_nbr).PadLeft(2,'0') +
                    new string(' ', 100);
        }

        private string h8_head_grp()
        {            
            return new string(' ', 60) +
                    Util.Str(h8_clinic_name).PadRight(72);
        }

        private string h9_head_grp()
        {            
            return "-----------------------------------------------------" +
                    Util.Str(h9_head_msg).PadRight(26) +
                    "-----------------------------------------------------";
        }

        private string h10_head_grp()
        {            

            return new string(' ', 16) +
                    Util.Str("0").PadRight(11) +
                    Util.Str("1").PadRight(11) +
                    Util.Str("2").PadRight(11) +
                    Util.Str("3").PadRight(11) +
                    Util.Str("4").PadRight(11) +
                    Util.Str("5").PadRight(11) +
                    Util.Str("6").PadRight(11) +
                    Util.Str("7").PadRight(11) +
                    Util.Str("8").PadRight(11) +
                    Util.Str("9").PadRight(11) +
                    Util.Str("TOTAL").PadRight(11);
        }

        private string l5_print_line_grp()
        {            

            return "            -------    -------    -------    -------" +
                    "    -------    -------    -------    -------    -------" +
                    "    -------    ----------";
        }

        private string print_line_grp()
        {            

            return Util.Str(l1_pat_surname).PadRight(7, ' ') +
                    Util.Str(l1_pat_acronym3).PadRight(4, ' ') +
                    Util.Str(l1_claim_clinic1).PadLeft(2) +
                    Util.Str(l1_claim_doc_nbr).PadRight(3, ' ') +
                    Util.Str(l1_claim_week).PadLeft(2,'0') +
                    Util.Str(l1_claim_day).PadLeft(1) +
                    Util.Str(l1_claim_nbr).PadLeft(2,'0') +
                    new string(' ', 1) +
                    Util.Str(l1_patient_id).PadRight(15) +
                    new string(' ', 2) +
                    Util.Str(l1_agent_code).PadLeft(1) +
                    new string(' ', 3) +
                    Util.Str(l1_adj_code).PadRight(1) +
                    Util.Str(l1_filler_slash).PadRight(1) +
                    Util.Str(l1_adj_cd_sub_type).PadRight(1) +
                    new string(' ', 4) +
                    Util.BlankWhenZero(Util.ImpliedDecimalFormat("#0.00", l1_tot_claim_ohip, 2, 9),9) +   //Util.ImpliedDecimalFormat("#0.00", l1_tot_claim_ohip, 2, 9) +
                    new string(' ', 4) +
                    Util.BlankWhenZero(Util.ImpliedDecimalFormat("#0.00", l1_tot_claim_ohip_adj, 2, 9),9) +
                    new string(' ', 1) +
                    Util.Str(l1_service_date_yy).PadLeft(4) +
                    Util.Str(l1_slash1).PadRight(1) +
                    Util.Str(l1_service_date_mm).PadLeft(2,'0') +
                    Util.Str(l1_slash2).PadRight(1) +
                    Util.Str(l1_service_date_dd).PadLeft(2,'0') +
                    new string(' ', 2) +
                    Util.Str(l1_claim_date_yy).PadLeft(4) +
                    Util.Str(l1_slash3).PadRight(1) +
                    Util.Str(l1_claim_date_mm).PadLeft(2,'0') +
                    Util.Str(l1_slash4).PadRight(1) +
                    Util.Str(l1_claim_date_dd).PadLeft(2,'0') +
                    new string(' ', 2) +
                    Util.BlankWhenZero(Util.Str(l1_diag_cd).PadLeft(3,'0'),3) +
                    new string(' ', 2) +
                    Util.Str(l1_oma_cd).PadRight(4) +
                    Util.Str(l1_oma_suff).PadRight(1) +
                    new string(' ', 1) +
                    Util.Str(l1_nbr_of_services).PadLeft(3) +
                    new string(' ', 2) +
                    Util.Str(l1_batch_clinic1).PadLeft(2) +
                    Util.Str(l1_batch_doc_nbr).PadRight(3) +
                    Util.Str(l1_batch_week).PadRight(2) +
                    Util.Str(l1_batch_day).PadRight(1) +
                    new string(' ', 2) +
                    Util.Str(l1_ref_field).PadRight(9);
        }

        private string l2_print_line_grp()
        {
            return Util.Str(l2_type).PadRight(9) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[1], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[2], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[3], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[4], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[5], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[6], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[7], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[8], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[9], 2, 11) +
                   Util.ImpliedDecimalFormat("#0.00", l2_ohip_totals[10], 2, 11) +
                   Util.ImpliedDecimalFormat("#####,##0.00", l2_agent_total, 2, 13, true, true);

        }

        private string l3_print_line_grp()
        {
            return new string(' ', 62) +
                   Util.Str(l3_ohip).PadRight(70);
        }

        private string l4_print_line_grp()
        {
            return new string(' ', 4) +
                     Util.Str(l4_type).PadRight(116) +
                    Util.ImpliedDecimalFormat("####,##0.00", l4_adj_tot, 2, 12, true, true);
        }

        #endregion
    }
}

