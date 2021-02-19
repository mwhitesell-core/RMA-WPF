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
    public class R005ViewModel : CommonFunctionScr
    {
    
        #region FD Section
            	 // FD: print_file
	 private Prt_line objPrt_line = null;
	 private ObservableCollection<Prt_line> Prt_line_Collection;

	 // FD: docash_mstr	Copy : f051_doc_cash_mstr.fd
	 private F051_DOC_CASH_MSTR objF051_DOC_CASH_MSTR = null;
	 private ObservableCollection<F051_DOC_CASH_MSTR> Docash_master_rec_Collection;

	 // FD: doc_mstr	Copy : f020_doctor_mstr.fd
	 private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
	 private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

	 // FD: iconst_mstr	Copy : f090_constants_mstr.fd
	 private ICONST_MSTR_REC objIconst_mstr_rec = null;
	 private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;




        #endregion
        
        #region Properties
             
        #endregion
        
        #region Working Storage Section
            	 private int ss;
	 private int ss_agent;
	 private int ss_const;
	 private string ws_closing_msg = "REPORT IS IN FILE R005";
	 private int ss_from;
	 private int ss_to;
	 private int agent;
	 private int dept;
	 private string eof_docash_mstr = "N";
	 private string status_file = "0";
	 private string status_cobol_doc_mstr = "0";
	 private string status_cobol_docash_mstr = "0";
	 private string status_cobol_iconst_mstr = "0";
	 private string status_audit_rpt = "0";
	 private string status_print_file = "0";
	 private string feedback_docash_mstr = "0";
	 private string feedback_iconst_mstr = "0";
	 private string printer_file_name = "r005";
	 private int page_cnt;
	 private decimal doc_mtd_total;
	 private decimal doc_ytd_total;
	 private decimal dept_mtd_total;
	 private decimal dept_ytd_total;
	 private string final_totals_being_printed = "N";
	 private string doc_desc_2b_printed;
	 private int docash_agency_type_r;
	 private int line_cnt;
	 private int err_ind;
	 private string ws_reply;
	 private decimal ws_temp_cash;
	 private int docash_read;
	 private int doc_mstr_read;
	 private int loc_mstr_read;

	 private string save_docash_key_grp;
	 private string save_clinic_1_2;
	 private int save_dept;
	 private string save_doc_nbr;
	 private string save_location;
	 private string save_oma_cd;
	 private string request_clinic;
	 private string ws_request_clinic_ident;
	 private string blank_line = "";
	 private int max_nbr_agents = 10;
	 private int ss_level_doc = 1;
	 private int ss_level_dept = 2;
	 private int ss_level_grand = 3;

	 private string counters_grp;
	 private string[] totals =  new string[4];
	 private string [,] by_agent =  new string[4,11];
	 private string [,] agent_code =  new string[4,11];
	 private decimal[,] mtd_total =  new decimal[4,11];
	 private decimal[,] ytd_total =  new decimal[4,11];

	 private string error_message_table_grp;
	 private string error_messages_grp;
	 /*private string filler = "invalid reply";
	 private string filler = "INVALID CLINIC NUMBER";
	 private string filler = "NO CASH RECORDS FOR THIS CLINIC"; */
	 private string error_messages_r_grp;
     private string[] err_msg = {"", "invalid reply", "INVALID CLINIC NUMBER", "NO CASH RECORDS FOR THIS CLINIC" };
	 private string err_msg_comment;

	 //private string l1_detail_line_grp;
	 private string filler = "";
	 private int l1_dept_nbr;
	 //private string filler = "";
	 private string l1_doctor_nbr;
	 //private string filler = "";
	 private string l1_doctor_name;
	 //private string filler = "";
	 private int l1_agent;
	 //private string filler = "";
	 private decimal l1_mtd_cash;
	 //private string filler = "";
	 private decimal l1_ytd_cash;
	 //private string filler = "";

	 //private string t1_doctor_total_grp;
	 //private string filler = "";
	 //private string filler = "doctor total";
	 //private string filler = "";
	 private decimal t1_mtd;
	 private decimal t1_ytd;
	 //private string filler = "";

	 //private string t2_dept_total_title_grp;
	 private string t2_department_or_agent;
	 private string t2_grand_or_agent;
	 //private string filler = "TOTAL **    ";
	 private string t2_dept_or_agent;
	 //private string filler = "MONTH";
	 //private string filler = "";
	 //private string filler = "year to";
	 //private string filler = "";

	 //private string t2_dept_total_title_2_grp;
	 //private string filler = "";
	 //private string filler = "to date";
	 //private string filler = "";
	 //private string filler = "DATE";
	 //private string filler = "";

	 //private string t3_dept_total_detail_grp;
	 //private string filler = "";
	 private int t3_agent;
	 //private string filler = "";
	 private decimal t3_mtd;
	 //private string filler = "";
	 private decimal t3_ytd;
	 //private string filler = "";

	 //private string t4_dept_final_total_grp;
	 //private string filler = "";
	 private int t4_dept_nbr;
	 //private string filler = "";
	 //private string filler = "TOTAL";
	 //private string filler = "";
	 private decimal t4_mtd;
	 //private string filler = "*";
	 private decimal t4_ytd;
	 //private string filler = "*";

	 //private string h1_head_line_grp;
	 //private string filler = "R005";
	 //private string filler = "/";
	 private int h1_clinic_nbr;
	 //private string filler = "";
	 private string h1_alpha_month;
	 //private string filler = "";
	 private int h1_num_day;
	 //private string filler = "";
	 private string h1_year;
	 //private string filler = "";
	 //private string filler = "* MONTHLY CASH APPLIED REPORT *";
	 //private string filler = "";
	 private int h1_yy;
	 //private string filler = "/";
	 private int h1_mm;
	 //private string filler = "/";
	 private int h1_dd;
	 //private string filler = "  PAGE ";
	 private int h1_page;
	 //private string filler = "";

	 //private string h1a_clinic_line_grp;
	 //private string filler = "";
	 private string h1a_clinic_name;
	 //private string filler = "";

	 //private string h2_head_line_grp;
	 //private string filler = "DEPARTMENT";
	 //private string filler = "DOCTOR";
	 //private string filler = "DOCTOR";
	 //private string filler = "AGENT";
	 //private string filler = "MONTH";
	 //private string filler = "year to";

	 //private string h3_head_line_grp;
	 //private string filler = "  number";
	 //private string filler = "NUMBER";
	 //private string filler = "NAME";
	 //private string filler = "CODE";
	 //private string filler = "to date";
	 //private string filler = "DATE";
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

	 private string month_descs_and_max_days_mth_grp;
	 private string mth_desc_max_days_grp;
	 /*private string filler = '31  january031';
	 private string filler = '29 february059';
	 private string filler = '31    march090';
	 private string filler = '30    april120';
	 private string filler = '31      may151';
	 private string filler = '30     june181';
	 private string filler = '31     july212';
	 private string filler = '31   august243';
	 private string filler = '30SEPTEMBER273';
	 private string filler = '31  october304';
	 private string filler = '30 november334';
	 private string filler = '31 december365'; */
	 private string mth_desc_max_days_r_grp;
	 private string[] mth_desc_max_days_occur =  new string[13];
     private int[] max_nbr_days = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
     private string[] mth_desc = { "", "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
     private int[] nbr_julian_days_ytd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

    private string prm_ws_request_clinic_ident;
        private string prm_ws_reply;

        private string endOfJob = "End of Job";

        private ReportPrint objPrint_File = null;

 
        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
	 {

	 }

	 private void err_iconst_mstr_file_section()
	 {

		 //     use after standard error procedure on iconst-mstr.;
	 }

	 private void err_iconst_mstr()
	 {

		 //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
		 status_file = status_cobol_iconst_mstr;
		 //     display status-file.;
		 //     stop run.;
	 }

	 private void err_docash_mstr_file_section()
	 {

		 //     use after standard error procedure on docash-mstr.;
	 }

	 private void err_docash_mstr()
	 {

		 //     stop "ERROR IN ACCESSING DOCASH MASTER ".;
		 status_file = status_cobol_docash_mstr;
		 //     display status-file.;
		 //     stop run.;
	 }

	 private void err_doc_mstr_file_section()
	 {

		 //     use after standard error procedure on doc-mstr.;
	 }

	 private void err_doc_mstr()
	 {

		 //     stop "ERROR IN ACCESSING DOCTOR MSTR ".;
		 status_file = status_cobol_doc_mstr;
		 //     display status-file.;
		 //     stop run.;
	 }

	 private void end_declaratives()
	 {

	 }

	 private void main_line_section()
	 {

	 }

	 public void mainline(string ws_request_clinic_ident, string ws_reply)
	 {
            try {
                prm_ws_request_clinic_ident = ws_request_clinic_ident;
                prm_ws_reply = ws_reply;

                objPrt_line = null;
                objPrt_line = new Prt_line();

                objF051_DOC_CASH_MSTR = new F051_DOC_CASH_MSTR();
                Docash_master_rec_Collection = new ObservableCollection<F051_DOC_CASH_MSTR>();

                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objIconst_mstr_rec = new ICONST_MSTR_REC();
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objPrint_File = null;
                objPrint_File = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + printer_file_name);

                //  perform aa0-initialization		thru	aa0-99-exit.;
                aa0_initialization();
                aa0_10();
                aa0_20();
                aa0_99_exit();

                // perform ab0-process-records		thru 	ab0-99-exit;
                // until eof-docash-mstr = "Y".;
                do
                {
                    ab0_process_records();
                    ab0_99_exit();
                } while (!eof_docash_mstr.ToUpper().Equals("Y"));

                //     perform az0-finalization		thru	az0-99-exit.;
                az0_finalization();
                az0_99_exit();
                //     stop run.;
            }  catch (Exception e)
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
                {
                    objPrint_File.Close();
                    objPrint_File = null;
                }
            }
        }

	 private void aa0_initialization()
	 {
            //     accept sys-date			from 	date.;
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

            run_yy = sys_yy;
            run_mm = sys_mm;
            run_dd = sys_dd;

		 //     open input iconst-mstr.;
	 }

	 private void aa0_10()
	 {
            //     accept ws-request-clinic-ident;
            ws_request_clinic_ident = prm_ws_request_clinic_ident;

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_request_clinic_ident;

            // read iconst-mstr invalid key;            
            //       err_ind = 2;
            // 	     perform za0-common-error		thru za0-99-exit;
            // 	     go to  aa0-10.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumDec(ws_request_clinic_ident)
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 2;
                za0_common_error();
                za0_99_exit();
                return;
            }
            else
            {
                objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();
            }

            h1_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
            h1_year = Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h1_num_day = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
		    h1_alpha_month = Util.Str(mth_desc[ Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM)]);
            h1a_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);
            t2_department_or_agent = "     ** DEPARTMENT";
     }

	 private void aa0_20()
	 {
            //  accept ws-reply;
            ws_reply = prm_ws_reply;

            //  if ws-reply = "Y" then;            
            //        continue;
            //  else if ws-reply = "N" then;            
            // 	    go to az0-100-end-job;
            // 	else;
            //      err_ind = 1;
		   // 	    perform za0-common-error		thru	za0-99-exit;
		   // 	    go to aa0-20.;

            if (ws_reply.ToUpper() == "Y")
            {
                // continue
            }
            else if (ws_reply.ToUpper() == "N")
            {
                az0_100_end_job();
                throw new Exception(endOfJob);
            }
            else
            {
                err_ind = 1;
                za0_common_error();
                za0_99_exit();
                throw new Exception(endOfJob);
            }

            //     open input  doc-mstr;
            //                 docash-mstr.;
            //     open output print-file.;

            //     perform aa1-zero-counters		thru aa1-99-exit;
            // 	varying ss-from;
            // 	from    1 by 1;
            // 	until   ss-from > ss-level-grand.;

            ss_from = 1;
            do
            {
                aa1_zero_counters();
                aa1_99_exit();
                ss_from++;
            } while (ss_from <= ss_level_grand);

		 h1_yy = run_yy;
		 h1_mm = run_mm;
		 h1_dd = run_dd;

            //objDocash_master_rec.Docash_key = "0";
            objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2 = "";
            objF051_DOC_CASH_MSTR.DOCASH_DEPT = 0;
            objF051_DOC_CASH_MSTR.DOCASH_DOC_NBR = "";
            objF051_DOC_CASH_MSTR.DOCASH_LOCATION = "";
            objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE = "";

            objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2  = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);

            // perform rb0-read-docash-approx	thru	rb0-99-exit.;
            rb0_read_docash_approx();
            rb0_99_exit();

            // if  eof-docash-mstr = "Y" or docash-clinic-1-2 not = ws-request-clinic-ident then;            
            //     err_ind = 3;
            // 	   perform za0-common-error	thru	za0-99-exit;
            //     go to az0-10-error-shutdown.;

            if (eof_docash_mstr.ToUpper() == "Y" || Util.Str(objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2) !=  ws_request_clinic_ident)
            {
                 err_ind = 3;
                // perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //     go to az0-10-error-shutdown.;
                az0_10_error_shutdown();
                return;
            }

            //save_docash_key_grp = objDocash_master_rec   Docash_key;
            save_clinic_1_2 = objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2;
            save_dept =  Util.NumInt(objF051_DOC_CASH_MSTR.DOCASH_DEPT);
            save_doc_nbr = objF051_DOC_CASH_MSTR.DOCASH_DOC_NBR;
            save_location = objF051_DOC_CASH_MSTR.DOCASH_LOCATION;
            save_oma_cd = objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE;

            line_cnt = 90;
	 }

	 private void aa0_99_exit()
	 {
		 //     exit.;
	 }

	 private void aa1_zero_counters()
	 {

            //     perform aa10-zero-cntrs		thru aa10-99-exit;
            // 	varying ss-to;
            // 	from    1 by 1;
            // 	until   ss-to > max-nbr-agents.;

            ss_to = 1;
            do
            {
                aa10_zero_cntrs();
                aa10_99_exit();
                ss_to++;
            } while (ss_to <= max_nbr_agents);
	 }

	 private void aa1_99_exit()
	 {
		 //     exit.;
	 }

	 private void aa10_zero_cntrs()
	 {

		 agent_code[ss_from,ss_to] = "";
		 mtd_total[ss_from,ss_to] = 0;
		 ytd_total[ss_from,ss_to] = 0;		
	 }

	 private void aa10_99_exit()
	 {
		 //     exit.;
	 }

	 private void ab0_process_records()
	 {

            // perform ba0-cash-record		thru	ba0-99-exit.;
            ba0_cash_record();
            ba0_99_exit();

            // perform ra0-read-next-docash	thru	ra0-99-exit.;
            ra0_read_next_docash();
            ra0_99_exit();

            //  if eof-docash-mstr = "Y" then;            
            // 	   go to ab0-99-exit.;

            if (eof_docash_mstr.ToUpper().Equals("Y"))
            {
                ab0_99_exit();
                return;
            }

            // if docash-dept = save-dept then;            
            // 	   if docash-doc-nbr   = save-doc-nbr then;            
            // 	       next sentence;
            // 	   else;
            // 	       perform ca0-doctor-break	thru	ca0-99-exit;
            //         save_docash_key = objDocash_master_rec.docash_key;
            // else;
            //    	perform ca0-doctor-break	thru	ca0-99-exit;
            // 	    perform ea0-dept-break		thru	ea0-99-exit;
            //      save_docash_key = objDocash_master_rec.docash_key;

            if (objF051_DOC_CASH_MSTR.DOCASH_DEPT == save_dept)
            {
                if (objF051_DOC_CASH_MSTR.DOCASH_DOC_NBR == save_doc_nbr)
                {
                    // next sentence..
                }
                else
                {
                    ca0_doctor_break();
                    ca0_99_exit();
                    // save_docash_key = objDocash_master_rec.docash_key   docash_key;

                    save_clinic_1_2 = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2);
                    save_dept = Util.NumInt(objF051_DOC_CASH_MSTR.DOCASH_DEPT);
                    save_doc_nbr = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_DOC_NBR);
                    save_location = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_LOCATION);
                    save_oma_cd = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE);
                    this.save_docash_key_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma_cd);
                }
            }else
            {
                // perform ca0-doctor-break thru	ca0-99-exit;
                ca0_doctor_break();
                ca0_99_exit();

                //  perform ea0-dept-break		thru	ea0-99-exit;
                ea0_dept_break();
                ea0_99_exit();

                //  save_docash_key = objDocash_master_rec.docash_key;
                save_clinic_1_2 = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2);
                save_dept = Util.NumInt(objF051_DOC_CASH_MSTR.DOCASH_DEPT);
                save_doc_nbr = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_DOC_NBR);
                save_location = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_LOCATION);
                save_oma_cd = Util.Str(objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE);
                this.save_docash_key_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma_cd);
            }
        }

        private void ab0_99_exit()
	 {
		 //     exit.;
	 }

	 private void az0_finalization()
	 {
            //  perform ca0-doctor-break		thru	ca0-99-exit.;
            ca0_doctor_break();
            ca0_99_exit();

            //     perform ea0-dept-break		thru	ea0-99-exit.;
            ea0_dept_break();
            ea0_99_exit();

            //     perform az1-print-grand-totals	thru	az1-99-exit.;
            az1_print_grand_totals();
            az1_99_exit();
        }

	 private void az0_10_error_shutdown()
	 {

		 //     close doc-mstr;
		 // 	  docash-mstr;
		 // 	  print-file.;
	 }

	 private void az0_100_end_job()
	 {
		 //     accept sys-time			from time.;
		 //     stop run.;
	 }

	 private void az0_99_exit()
	 {
		 //     exit.;
	 }

	 private void az1_print_grand_totals()
	 {

		 t2_department_or_agent = "";
            t2_department_or_agent = "          ** AGENT";
         t2_grand_or_agent = " GRAND";
		 t2_dept_or_agent = "AGENT";
            // perform wa1-heading-routine		thru	wa1-99-exit.;
            wa1_heading_routine();
            wa1_49_exit();

            //     write prt-line from t2-dept-total-title	after advancing 3 lines.;
            objPrint_File.print(true);
            objPrint_File.print(true);            
            objPrint_File.print(t2_dept_total_title_grp(),1,true);

            //     write prt-line from t2-dept-total-title-2	after advancing 1 line.;          
            objPrint_File.print(t2_dept_total_title_2_grp(), 1, true);

            final_totals_being_printed = "Y";
		    ss_from = ss_level_grand;
		    ss_to = ss_level_grand;

            //  perform eb0-prt-and-roll-tots	thru	eb0-99-exit.;
            eb0_prt_and_roll_tots();
            eb0_99_exit();
     }

	 private void az1_99_exit()
	 {
		 //     exit.;
	 }

	 private void ba0_cash_record()
	 {
        // if docash-agency-type = 0  then;            
        //    ss_agent = 10;
	    //  else;
		 //   ss_agent = objDocash_master_rec.docash_agency_type;

          if (Util.NumInt(objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE) == 0 )
          {
                ss_agent = 10;
          } else
          {
                ss_agent = Util.NumInt(objF051_DOC_CASH_MSTR.DOCASH_AGENCY_TYPE);
          }


		 agent_code[ss_level_doc,ss_agent] = "X";
            //     add docash-mtd-in-rec		to	mtd-total (ss-level-doc, ss-agent).;
            mtd_total[ss_level_doc, ss_agent] = mtd_total[ss_level_doc, ss_agent] +  Util.NumDec(objF051_DOC_CASH_MSTR.DOCASH_MTD_IN_REC);

            //     add docash-ytd-in-rec		to	ytd-total (ss-level-doc, ss-agent).;
            ytd_total[ss_level_doc, ss_agent] = ytd_total[ss_level_doc, ss_agent] + Util.NumDec(objF051_DOC_CASH_MSTR.DOCASH_YTD_IN_REC);
        }

	 private void ba0_99_exit()
	 {
		 //     exit.;
	 }

	 private void ca0_doctor_break()
	 {

		 l1_dept_nbr = save_dept;
		 l1_doctor_nbr = save_doc_nbr;

		 objDoc_mstr_rec.DOC_NBR = save_doc_nbr;
		 
		 err_ind = 0;
            // perform sa0-read-docmstr	thru	sa0-99-exit.;
            sa0_read_docmstr();
            sa0_99_exit();

            // if err-ind = zero then;            
            //    l1_doctor_name = objDoc_mstr_rec.doc_name;
            //  else;
            //     l1_doctor_name = "";

            if (err_ind == 0)
            {
                l1_doctor_name = Util.Str(objDoc_mstr_rec.DOC_NAME);
            }

            doc_desc_2b_printed = "Y";

            //  perform cb0-prt-doc-agent-tots	thru	bb1-99-exit;
            // 	varying agent;
            // 	from 1 by 1;
            // 	until   agent > max-nbr-agents.;

            agent = 1;
            do
            {
                cb0_prt_doc_agent_tots();
                bb1_99_exit();
                agent++;
            } while (agent <= max_nbr_agents);


         t1_mtd = doc_mtd_total;
		 t1_ytd = doc_ytd_total;
            //     write prt-line from t1-doctor-total after advancing 1 lines.;
            
            objPrint_File.print(t1_doctor_total_grp(),1,true);

            //     add 1			to	line-cnt.;
            line_cnt++;

         doc_mtd_total = 0;
		 doc_ytd_total = 0;
		 
		 ss_from = ss_level_doc;
		 ss_to = ss_level_dept;

            //  perform cd0-clr-doc-agent-tots-and-sum;
            // 		thru	cd0-99-exit;
            // 	varying agent;
            // 	from 1 by 1;
            // 	until   agent > max-nbr-agents.;

            agent = 1;

            do
            {
                cd0_clr_doc_agent_tots_and_sum();
                cd0_99_exit();
                agent++;
            } while (agent <= max_nbr_agents);
     }

	 private void ca0_99_exit()
	 {
		 //     exit.;
	 }

	 private void cb0_prt_doc_agent_tots()
	 {
            // if agent-code (ss-level-doc, agent) = "X" then;            
            //    l1_agent = agent;
            // 	  add  mtd-total (ss-level-doc, agent)	to	doc-mtd-total;
            // 	  add  ytd-total (ss-level-doc, agent)	to	doc-ytd-total;
            // 	  perform wa0-write-doc-line		thru	wa0-99-exit.;

            if (agent_code[ss_level_doc,agent] == "X")
            {
                 l1_agent = agent;
                l1_mtd_cash = mtd_total[ss_level_doc, agent];
                l1_ytd_cash = ytd_total[ss_level_doc, agent];
                doc_mtd_total = doc_mtd_total + mtd_total[ss_level_doc, agent];                
                doc_ytd_total = doc_ytd_total + ytd_total[ss_level_doc, agent];                
                wa0_write_doc_line();
                wa0_99_exit();
            }
        }

      private void bb1_99_exit()
	 {
		 //     exit.;
	 }

	 private void cd0_clr_doc_agent_tots_and_sum()
	 {
            //  if agent-code (ss-from, agent) = "X" then;  
            //     move agent-code(ss - from, agent)    to agent-code(ss - to, agent)
            // 	   add  mtd-total  (ss-from, agent)	to mtd-total  (ss-to, agent);
            // 	   add  ytd-total  (ss-from, agent)	to ytd-total  (ss-to, agent).;

            if (agent_code[ss_from,agent] == "X")
            {
                //     move agent-code(ss - from, agent)    to agent-code(ss - to, agent)
                agent_code[ss_to, agent] = agent_code[ss_from, agent];
                // 	   add  mtd-total  (ss-from, agent)	to mtd-total  (ss-to, agent);
                mtd_total[ss_to, agent] = mtd_total[ss_to, agent] + mtd_total[ss_from, agent];
                // 	   add  ytd-total  (ss-from, agent)	to ytd-total  (ss-to, agent).;
                ytd_total[ss_to, agent] = ytd_total[ss_to, agent] + ytd_total[ss_from, agent];
            }

            //     agent_code[ss_from,agent] = "";
            mtd_total[ss_from,agent] = 0;
		    ytd_total[ss_from,agent] = 0;		 
	 }

	 private void cd0_99_exit()
	 {
		 //     exit.;
	 }

	 private void ea0_dept_break()
	 {

		 t2_grand_or_agent = "/AGENT";
		 t2_dept_or_agent = "AGENT";

            // perform wa1-heading-routine		thru	wa1-99-exit.;
            wa1_heading_routine();
            wa1_49_exit();

            //     write prt-line from t2-dept-total-title after advancing 3 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(t2_dept_total_title_grp(), 1, true);

            //     write prt-line from t2-dept-total-title-2 after advancing 1 lines.;            
            objPrint_File.print(t2_dept_total_title_2_grp(), 1, true);

            ss_from = ss_level_dept;
		    ss_to = ss_level_grand;

            // perform eb0-prt-and-roll-tots	thru	eb0-99-exit.;
            eb0_prt_and_roll_tots();
            eb0_99_exit();
     }

	 private void ea0_99_exit()
	 {
		 //     exit.;
	 }

	 private void eb0_prt_and_roll_tots()
	 {

		 dept = save_dept;

            //  perform eb1-prt-agent-tots		thru 	eb1-99-exit;
            // 	varying agent;
            // 	from    1 by 1;
            // 	until   agent > max-nbr-agents.;

            agent = 1;
            do
            {
                eb1_prt_agent_tots();
                eb1_99_exit();
                agent++;
            } while (agent <= max_nbr_agents);

            //  perform eb2-roll-agent-tots		thru 	eb2-99-exit;
            // 	varying agent;
            // 	from    1 by 1;
            // 	until   agent > max-nbr-agents.;

            agent = 1;
            do
            {
                eb2_roll_agent_tots();
                eb2_99_exit();
                agent++;
            } while (agent <= max_nbr_agents);

            // if final-totals-being-printed = "Y" then;            
            //    t4_dept_nbr = 0;
		    // else;
		    //    t4_dept_nbr = save_dept;

            if (final_totals_being_printed.ToUpper().Equals("Y"))
            {
                t4_dept_nbr = 0;
            } else
            {
                t4_dept_nbr = save_dept;
            }

		 t4_mtd = dept_mtd_total;
		 t4_ytd = dept_ytd_total;
            //  write prt-line	from t4-dept-final-total after advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(t4_dept_final_total_grp(), 1, true);

            line_cnt = 70;
		    dept_mtd_total = 0;
		    dept_ytd_total = 0;		 
	 }
	 private void eb0_99_exit()
	 {
		 //     exit.;
	 }

	 private void eb1_prt_agent_tots()
	 {
            // if agent-code (ss-from, agent) = "X" then;            
            //    t3_agent = agent;
            //    move mtd-total(ss - from, agent) to t3-mtd
            //    move ytd-total(ss - from, agent) to t3-ytd
            // 	  write prt-line from	t3-dept-total-detail after advancing 2 lines

            if (agent_code[ss_from,agent] == "X")
            {
                t3_agent = agent;                
                t3_mtd = mtd_total[ss_from, agent];                
                t3_ytd = ytd_total[ss_from, agent];                                
                objPrint_File.print(true);
                objPrint_File.print(t3_dept_total_detail_grp(), 1, true);
            }
        }

        private void eb1_99_exit()
	 {
		 //     exit.;
	 }

	 private void eb2_roll_agent_tots()
	 {

            //  if agent-code (ss-from, agent) = "X" then;            
            // 	   add  mtd-total (ss-from, agent)	to	dept-mtd-total rounded;
            // 	   add  ytd-total (ss-from, agent)	to	dept-ytd-total rounded;
            // 	   if final-totals-being-printed = "N" then;            
            //        agent_code[ss_to,agent] = "X";
            // 	      add  mtd-total (ss-from, agent) to	mtd-total  (ss-to, agent)rounded;            
            // 	      add  ytd-total (ss-from, agent) to	ytd-total  (ss-to, agent)rounded;            
            //        agent_code[ss_from,agent] = "";
		    //        mtd_total[ss_from,agent] = 0;
		   // 						ytd_total  [ss-from, agent] = 0

            if (agent_code[ss_from,agent] == "X")
            {
                // 	   add  mtd-total (ss-from, agent)	to	dept-mtd-total rounded;
                dept_mtd_total = dept_mtd_total +   Util.Round(Util.NumDec(mtd_total[ss_from, agent]),2);  // todo: watch this...                
                // 	   add  ytd-total (ss-from, agent)	to	dept-ytd-total rounded;
                dept_ytd_total = dept_ytd_total + Util.Round(ytd_total[ss_from, agent],2); // todo....rounded not sure what's the decimal places???                
                if (final_totals_being_printed == "N")
                {
                   agent_code[ss_to,agent] = "X";
                    // 	      add  mtd-total (ss-from, agent) to	mtd-total  (ss-to, agent)rounded;  
                    mtd_total[ss_to, agent] += Util.Round(mtd_total[ss_from, agent],2);
                    
                    // 	      add  ytd-total (ss-from, agent) to	ytd-total  (ss-to, agent)rounded;         
                    ytd_total[ss_to, agent] += Util.Round(ytd_total[ss_from, agent],2);                    

                    agent_code[ss_from,agent] = "";
                    mtd_total[ss_from,agent] = 0;
                    ytd_total[ss_from, agent] = 0;
                }
            }

        }

	 private void eb2_99_exit()
	 {

		 //     exit.;
	 }

	 private void ra0_read_next_docash()
	 {

            //  read  docash-mstr   next at end;            
            //       eof_docash_mstr = "Y";
            // 	      go to ra0-99-exit.;

           /* objF051_DOC_CASH_MSTR = new F051_DOC_CASH_MSTR
            {
            }.Collection_ReadNext(objF051_DOC_CASH_MSTR);

            if (objF051_DOC_CASH_MSTR == null)
            {
                eof_docash_mstr = "Y";
                //   go to ra0-99-exit.;
                ra0_99_exit();
                return;
            } */
           
            /*  bool isRetrieve = false;
              Docash_master_rec_Collection = new F051_DOC_CASH_MSTR
              {
                  WhereDocash_clinic_1_2 = save_clinic_1_2,
                  WhereDocash_dept = save_dept,
                  WhereDocash_doc_nbr = save_doc_nbr,
                  WhereDocash_location = save_location,
                  WhereDocash_agency_type = save_oma_cd
              }.Collection_UsingStart(ref isRetrieve, Docash_master_rec_Collection); */

              if (Docash_master_rec_Collection.Count() == 0 )
              {
                  eof_docash_mstr = "Y";
                  //   go to ra0-99-exit.;
                  ra0_99_exit();
                  return;
              }
              else
              {
                  if (docash_read >= Docash_master_rec_Collection.Count())
                  {
                      eof_docash_mstr = "Y";
                      //   go to ra0-99-exit.;
                      ra0_99_exit();
                      return;
                  }
                  else
                  {
                    objF051_DOC_CASH_MSTR = Docash_master_rec_Collection[docash_read];
                      docash_read++;
                  }
              } 

            //  if docash-clinic-1-2 not = ws-request-clinic-ident then;            
            //     eof_docash_mstr = "Y";
            // 	   go to ra0-99-exit.;

            if (objF051_DOC_CASH_MSTR.DOCASH_CLINIC_1_2 != ws_request_clinic_ident)
            {
                eof_docash_mstr = "Y";
                ra0_99_exit();
                return;
            }

            //     add 1				to docash-read.;          
        }

	 private void ra0_99_exit()
	 {
		 //     exit.;
	 }

        private void rb0_read_docash_approx()
        {

            // start docash-mstr key is greater than or equal to docash-key;
            // 	invalid key;
            //     eof_docash_mstr = "Y";
            // 	 go to rb0-99-exit.;
            //     read docash-mstr next.;

           /* objF051_DOC_CASH_MSTR = new F051_DOC_CASH_MSTR
            {
                WhereDocash_clinic_1_2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2),
                WhereDocash_dept = save_dept,
                WhereDocash_doc_nbr = save_doc_nbr,
                WhereDocash_location = save_location,
                WhereDocash_agency_type = save_oma_cd
            }.Collection_ReadStart();

            if (objF051_DOC_CASH_MSTR == null)
            {
                eof_docash_mstr = "Y";
                ra0_99_exit();
                return;
            }

            docash_read++; */

              bool isRetrieve = false;
            /* Docash_master_rec_Collection = new F051_DOC_CASH_MSTR
             {
                 WhereDocash_clinic_1_2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2),
                 WhereDocash_dept = save_dept,
                 WhereDocash_doc_nbr = save_doc_nbr,
                 WhereDocash_location = save_location,
                 WhereDocash_agency_type = save_oma_cd
             }.Collection_UsingStart(ref isRetrieve, Docash_master_rec_Collection); */

            Docash_master_rec_Collection = new F051_DOC_CASH_MSTR
            {
                WhereDocash_clinic_1_2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2)                
            }.Collection();

            if (Docash_master_rec_Collection.Count() == 0)
              {
                  eof_docash_mstr = "Y";                
                  ra0_99_exit();
                  return;
              }
              else
              {
                  if (docash_read >= Docash_master_rec_Collection.Count())
                  {
                      eof_docash_mstr = "Y";                    
                      ra0_99_exit();
                      return;
                  }
                  else
                  {
                      objF051_DOC_CASH_MSTR = Docash_master_rec_Collection[docash_read];                    
                      docash_read++;
                  }
              }  
        }

	 private void rb0_99_exit()
	 {
		 //     exit.;
	 }

	 private void sa0_read_docmstr()
	 {

		 err_ind = 0;
            //  read doc-mstr;
            // 	invalid key;
            //          err_ind = 4;
            // 	    go to sa0-99-exit.;

            Doc_mstr_rec_Collection = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = save_doc_nbr
            }.Collection();

            if (Doc_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 4;
                sa0_99_exit();
                return;
            }
            else
            {
                objDoc_mstr_rec = Doc_mstr_rec_Collection.FirstOrDefault();
            }

            //     add 1				to doc-mstr-read.;
            doc_mstr_read++;
        }

	 private void sa0_99_exit()
	 {
		 //     exit.;
	 }

	 private void wa0_write_doc_line()
	 {

            // if line-cnt > 60 then;            
            // 	   perform wa1-heading-routine	thru wa1-99-exit.;

            if (line_cnt > 60)
            {
                wa1_heading_routine();
                wa1_49_exit();
            }

            // if doc-desc-2b-printed = "N" then;            
            //    l1_dept_nbr = 0;
    		//    l1_doctor_nbr = "";
		    //    l1_doctor_name = "";
		    // 	  write prt-line from l1-detail-line after advancing 1 lines;
		    // 	  add 1			to line-cnt;
		    // else;
		    //    doc_desc_2b_printed = "N";
		    // 	  write prt-line from l1-detail-line after advancing 2 line;
		    // 	  add 2			to line-cnt.;

            if (Util.Str(doc_desc_2b_printed).ToUpper().Equals("N"))
            {
                l1_dept_nbr = 0;
                l1_doctor_nbr = "";
                l1_doctor_name = "";

                // 	  write prt-line from l1-detail-line after advancing 1 lines;                
                objPrint_File.print(l1_detail_line_grp(), 1, true);

                // 	  add 1			to line-cnt;
                line_cnt++;
            }
            else
            {
                 doc_desc_2b_printed = "N";
                // write prt-line from l1-detail-line after advancing 2 line;                
                objPrint_File.print(true);
                objPrint_File.print(l1_detail_line_grp(), 1, true);

                // 	  add 2			to line-cnt.;
                line_cnt = line_cnt + 2;
            }
        }

	 private void wa0_99_exit()
	 {
		 //     exit.;
	 }

	 private void wa1_heading_routine()
	 {
         //  add 1				to page-cnt.;
            page_cnt++;

		    h1_page = page_cnt;

            // write prt-line from h1-head-line	after advancing page.;            
            objPrint_File.PageBreak();
            objPrint_File.print(h1_head_line_grp(), 1, true);

            //     write prt-line from h1a-clinic-line	after advancing 1 lines.;            
            objPrint_File.print(h1a_clinic_line_grp(), 1, true);
        }

	 private void wa1_49_exit()
	 {
            //     write prt-line from h2-head-line	after advancing 3 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(h2_head_line_grp(),1,true);

            //     write prt-line from h3-head-line	after advancing 1 lines.;            
            objPrint_File.print(h3_head_line_grp(), 1, true);

            //     write prt-line from blank-line	after advancing 1 lines.;
            objPrint_File.print(" ", 1, true);

            line_cnt = 7;
	 }

	 private void wa1_99_exit()
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
		 //   exit.;
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

        private string l1_detail_line_grp()
        {
            return  new string(' ', 3) + 
                    Util.Str(l1_dept_nbr).PadLeft(2, '0') + 
                    new string(' ', 11) + 
                    Util.Str(l1_doctor_nbr).PadRight(5) + 
                    new string(' ', 4) + 
                    Util.Str(l1_doctor_name).PadRight(21).Substring(0,21) + 
                    new string(' ', 2) + 
                    Util.Str(l1_agent).PadLeft(2, '0').Substring(1,1) + 
                    new string(' ', 2) + 
                    Util.ImpliedDecimalFormat("#,#.00", l1_mtd_cash, 2, 13) + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,#.00", l1_ytd_cash, 2, 14) + 
                    new string(' ', 44);
        }

        private string t1_doctor_total_grp()
        {
           return  new string(' ', 30) + 
                   "DOCTOR TOTAL" + 
                   new string(' ', 7) + 
                   Util.ImpliedDecimalFormat("#,#.00", t1_mtd, 2, 15) + 
                   Util.ImpliedDecimalFormat("#,#.00", t1_ytd, 2, 15) + 
                   new string(' ', 53);
        }

        private string t2_dept_total_title_grp()
        {
              return  Util.Str(t2_department_or_agent).PadRight(18) + 
                      Util.Str(t2_grand_or_agent).PadRight(7) + 
                      "TOTAL **    " + 
                      Util.Str(t2_dept_or_agent).PadRight(19) + 
                      "MONTH" + 
                      new string(' ', 11) + 
                      "YEAR TO";
        }

        private string t2_dept_total_title_2_grp()
        {
            return  new string(' ', 55) + 
                    "TO DATE" + 
                    new string(' ', 13) + 
                    "DATE" + 
                    new string(' ', 53);
        }

        private string t3_dept_total_detail_grp()
        {
             return   new string(' ', 39) +
                      Util.Str(t3_agent).PadLeft(2).Substring(1,1) + 
                      new string(' ', 8) + 
                      Util.ImpliedDecimalFormat("#,#.00", t3_mtd, 2, 15) + 
                      new string(' ', 2) + 
                      Util.ImpliedDecimalFormat("#,#.00", t3_ytd, 2, 15) + 
                      new string(' ', 53);
        }

        private string t4_dept_final_total_grp()
        {
            return new string(' ', 12) +
                    Util.Str(t4_dept_nbr).PadLeft(2, ' ') +
                    new string(' ', 23) +
                    "TOTAL" +
                    new string(' ', 6) +
                    Util.ImpliedDecimalFormat("#,#.00", t4_mtd, 2, 15) +
                    "*".PadRight(2) +
                    Util.ImpliedDecimalFormat("#,#.00", t4_ytd, 2, 15) +
                    "*".PadRight(51); 
        }

        private string h1_head_line_grp()
        {
            return  "R005".PadRight(7) + 
                    "/" +
                    Util.Str(h1_clinic_nbr).PadLeft(2, '0') + 
                    new string(' ', 1) + 
                    Util.Str(h1_alpha_month).PadRight(9) + 
                    new string(' ', 1) + 
                    Util.Str(h1_num_day).PadLeft(2, ' ') + 
                    new string(' ', 2) + 
                    Util.Str(h1_year).PadRight(4, ' ') + 
                    new string(' ', 1) + 
                    "* MONTHLY CASH APPLIED REPORT *".PadRight(31) + 
                    new string(' ', 2) +
                    Util.Str(h1_year).PadLeft(4, '0') + 
                    "/" + 
                    Util.Str(h1_mm).PadLeft(2, '0') + 
                    "/" + 
                    Util.Str(h1_dd).PadLeft(2, '0') + 
                    "  PAGE ".PadRight(7) + 
                    Util.Str(h1_page).PadLeft(3, ' ') + 
                    new string(' ', 59);
        }

        private string h1a_clinic_line_grp()
        {
            return new string(' ', 34) + 
                   Util.Str(h1a_clinic_name).PadRight(20) + 
                   new string(' ', 78);
        }

        private string h2_head_line_grp()
        {
            return "DEPARTMENT".PadRight(15) + 
                   "DOCTOR".PadRight(10) + 
                   "DOCTOR".PadRight(20) + 
                   "AGENT".PadRight(12) + 
                   "MONTH".PadRight(14) + 
                   "YEAR TO".PadRight(61);
        }

        private string h3_head_line_grp()
        {
            return "  NUMBER".PadRight(15) + 
                   "NUMBER".PadRight(11) + 
                   "NAME".PadRight(20) + 
                   "CODE".PadRight(10) + 
                   "TO DATE".PadRight(17) + 
                   "DATE".PadRight(59);
        }

        #endregion
    }
}

